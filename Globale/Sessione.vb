Imports System.IO

Public Class Sessione

    Public Enum TipoBlocco
        TIMER_UNITOOLS
        MANUTENZIONE
        MERGE_DATI
        MIGRAZIONE_DATI
        INVIO_DOC
    End Enum

    Public Event ModificaBlocchi()

    'per gestire empiricamente la chiusura dopo l'aggiornamento degli arretrati
    Public Property LetturaArretrati As Date = Now.AddDays(-1)

    Public Blocchi As New List(Of Blocco)
    Public SettingSessioni As Utx.ApplicationUserSetting
    Private mProssimaNotifica As Date = Now
    Private WithEvents Ping As Timers.Timer
    Private mUltimaEsecuzioneTimer As Date = Now


    Sub New()
        On Error Resume Next
        mInizio = Now
        SettingSessioni = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.EXTRA, "Sessioni")
        mVersione = FileVersionInfo.GetVersionInfo(Path.Combine(Utx.Globale.Paths.CartellaApp, "InfoUt.dll")).ProductVersion
        'inizializzo timer
        Ping = New Timers.Timer With {.Interval = 120000, .Enabled = True}
    End Sub

    Private mVersione As String
    Public ReadOnly Property Versione() As String
        Get
            Return mVersione
        End Get
    End Property

    Private mNascosta As Boolean
    Public Property Nascosta() As Boolean
        Get
            Return mNascosta
        End Get
        Set(value As Boolean)
            mNascosta = value
            If mNascosta = True Then
                Utx.Globale.Log.Info()
                Utx.Globale.Log.Info("Avviata sessione AUTOSTART")
                Utx.Globale.Log.Info()
            End If
        End Set
    End Property

    Public ReadOnly Property ChiaveSessione() As String
        Get
            Return Utx.Globale.UtenteCorrente.UniageUser.ToUpper
        End Get
    End Property

    Private mInizio As Date
    Public Property Inizio() As Date
        Get
            Return mInizio
        End Get
        Set(value As Date)
            mInizio = value
        End Set
    End Property

    Public ReadOnly Property IdSessione() As String
        Get
            Return Format(Inizio, "yyyyMMdd.HHmmss")
        End Get
    End Property

    Private mProssimoControlloTimerUnitools As DateTime
    Public Property ProssimoControlloTimerUnitools() As DateTime
        Get
            Return mProssimoControlloTimerUnitools
        End Get
        Set(value As DateTime)
            mProssimoControlloTimerUnitools = value
        End Set
    End Property

    Private mUltimoAggiornamento As Date
    Public ReadOnly Property UltimoAggiornamento() As Date
        Get
            Return mUltimoAggiornamento
        End Get
    End Property

    Public ReadOnly Property Bloccata() As Boolean
        Get
            Return (Blocchi.Count > 0)
        End Get
    End Property

    Private mRichiestaChiusura As Boolean
    Public Property RichiestaChiusura() As Boolean
        Get
            Return mRichiestaChiusura
        End Get
        Set(value As Boolean)
            mRichiestaChiusura = value
        End Set
    End Property

    Public Function Chiusura() As Boolean
        Try
            'chiusura da flag richiesta da informazioni
            Dim FlagChiusura As Object = Utx.Globale.SettingInterop.LeggiValore(Utx.GestioneFlag.TipoFlag.CHIUSURA_FORZATA)
            If FlagChiusura IsNot Nothing Then
                If IsDate(FlagChiusura) Then
                    If DateDiff(DateInterval.Second, FlagChiusura, Now) > 130 Then
                        'è più vecchio di 2 minuti e lo cancello
                        Utx.Globale.SettingInterop.Rimuovi(Utx.GestioneFlag.TipoFlag.CHIUSURA_FORZATA)
                        Return False
                    Else
                        Utx.Globale.Log.Info("Chiusura forzata richiesta da flag")
                        Return True
                    End If
                Else
                    Utx.Globale.Log.Info("Cancellazione flag chiusura forzata probabilmente errato")
                    Utx.Globale.SettingInterop.Rimuovi(Utx.GestioneFlag.TipoFlag.CHIUSURA_FORZATA)
                End If
            End If

            'chiusura di mezzanotte
            If mUltimaEsecuzioneTimer.Date <> Now.Date Then
                'faccio un refresh del token poiché è cambiata la data
                Utx.Globale.Token = Utx.NetFunc.TokenUniWeb + "|" + Utx.Globale.UtenteCorrente.UniageUser
            End If
            Return False

        Catch ex As Exception
            Utx.Globale.SettingInterop.Rimuovi(Utx.GestioneFlag.TipoFlag.CHIUSURA_FORZATA)
            Return False
        End Try
    End Function

    Public ReadOnly Property VisualizzaNotificaRiavvio() As Boolean
        Get
            If mProssimaNotifica < Now Then
                'prossimo controllo fra 5 minuti
                mProssimaNotifica = mProssimaNotifica.AddMinutes(5)
                Return RiavvioRichiesto()
            Else
                Return False
            End If
        End Get
    End Property

    Private mCicliTimer As Integer
    Public Property CicliTimer() As Integer
        Get
            Return mCicliTimer
        End Get
        Set(value As Integer)
            mCicliTimer = value
        End Set
    End Property

    Public Function AggiungiBlocco(Tipo As TipoBlocco,
                                   Optional Descrizione As String = Nothing) As Blocco
        Dim b As New Blocco(Tipo, Descrizione)
        Blocchi.Add(b)
        RaiseEvent ModificaBlocchi()
        Return b
    End Function

    Public Sub RimuoviBlocchi(Tipo As TipoBlocco)
        'rimuove tutti i blocchi di un tipo. usato in genere per debug e forzature
        For Each b As Blocco In Blocchi
            If b.Tipo = Tipo Then
                Blocchi.Remove(b)
            End If
        Next
        RaiseEvent ModificaBlocchi()
    End Sub

    Public Sub RimuoviBlocco(ByRef b As Blocco)
        Blocchi.Remove(b)
        b = Nothing
        RaiseEvent ModificaBlocchi()
    End Sub

    Public Function RiavvioRichiesto() As Boolean
        Try
            'se la variabile inizio non è inizializzata, chiamato da *.exe come ad esempio comunicazioni.exe
            If mInizio < #1/1/1900# Then
                Return False
            Else
                Dim Riavvio As New FileFlag("", FileFlag.Tipo.RIAVVIO)
                Riavvio.Scadenza = Riavvio.Eseguito
                mUltimoAggiornamento = Riavvio.Eseguito 'contiene la data in cui è stato scritto il flag di riavvio da liveupdate
                Return mInizio < Riavvio.Eseguito
            End If
        Catch ex As Exception
            'elimino il flag difettoso
            Dim Riavvio As New FileFlag("", FileFlag.Tipo.RIAVVIO)
            Riavvio.CancellaFlag()
            Return False
        End Try
    End Function

    Public Sub RegistraSessione()
        Try
            SettingSessioni.AggiungiModifica(Me.ChiaveSessione, String.Format("{0}|{1}", Format(mInizio, "dd/MM/yyyy HH:mm:ss"), Format(Now, "dd/MM/yyyy HH:mm:ss")))
        Catch ex As Exception
            Utx.Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Public Sub DeRegistraSessione()
        Try
            SettingSessioni.Rimuovi(ChiaveSessione)
        Catch ex As Exception
            Utx.Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Private Sub Ping_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles Ping.Elapsed
        RegistraSessione()
    End Sub

    Public Shared Function Hide() As Boolean
        Return Command().ToString.ToUpper = "HIDE"
    End Function

    Public Class Blocco

        Sub New(Tipo As TipoBlocco, Optional Descrizione As String = Nothing)
            mTipo = Tipo
            mInizioBlocco = Now
            If Descrizione Is Nothing Then
                mDescrizione = Tipo.ToString
            Else
                mDescrizione = Descrizione
            End If
        End Sub

        Private mTipo As TipoBlocco
        Public ReadOnly Property Tipo() As TipoBlocco
            Get
                Return mTipo
            End Get
        End Property

        Private mDescrizione As String
        Public ReadOnly Property Descrizione() As String
            Get
                Return mDescrizione
            End Get
        End Property

        Public ReadOnly Property DescrizioneEstesa() As String
            Get
                Return String.Format("Blocco > Inizio: {0} - Tipo: {1} ({2})", mInizioBlocco, mTipo, mDescrizione)
            End Get
        End Property

        Private mInizioBlocco As Date
        Public ReadOnly Property InizioBlocco() As Date
            Get
                Return mInizioBlocco
            End Get
        End Property
    End Class

    'Public Class InvitoAllaChiusura

    '    Private mDurata As Integer = 10 'durata massima in minuti

    '    Sub New()
    '        Dim Invito As String = Utx.Globale.SettingInterop.LeggiValore(Utx.GestioneFlag.TipoFlag.INVITO_CHIUSURA_SESSIONE)

    '        Try
    '            If Invito Is Nothing Then
    '                mEsiste = False
    '                mUtenza = ""
    '                mScadenza = #1/1/1900#
    '            Else
    '                mEsiste = True
    '                mUtenza = Invito.Split("|")(0).ToUpper
    '                mScadenza = CDate(Invito.Split("|")(1)).AddMinutes(10)
    '            End If

    '        Catch ex As Exception
    '            Me.Cancella()
    '            mEsiste = False
    '            mUtenza = ""
    '            mScadenza = #1/1/1900#
    '        End Try
    '    End Sub

    '    Private mEsiste As Boolean
    '    Public ReadOnly Property Esiste() As Boolean
    '        Get
    '            Return mEsiste
    '        End Get
    '    End Property

    '    Private mUtenza As String
    '    Public ReadOnly Property Utenza() As String
    '        Get
    '            Return mUtenza
    '        End Get
    '    End Property

    '    Private mScadenza As Date
    '    Public ReadOnly Property Scadenza() As Date
    '        Get
    '            Return mScadenza
    '        End Get
    '    End Property

    '    Public Shared Sub Crea()
    '        Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.INVITO_CHIUSURA_SESSIONE,
    '                                                    String.Format("{0}|{1}", Utx.Globale.UtenteCorrente.UniageUser, Format(Now, "dd/MM/yyyy HH:mm:ss")))
    '    End Sub

    '    Private Sub Cancella()
    '        Utx.Globale.SettingInterop.Rimuovi(Utx.GestioneFlag.TipoFlag.INVITO_CHIUSURA_SESSIONE)
    '    End Sub

    '    Public Sub Messaggio()
    '        If mEsiste AndAlso mUtenza <> Utx.Globale.UtenteCorrente.UniageUser.ToUpper Then
    '            MsgBox(String.Format("L'utente {1} ({2}) ha richiesto la CHIUSURA di {3} per effettuare aggiornamenti e/o manutenzione agli archivi.{0}{0}" +
    '                                 "Si prega di chiudere il programma al più presto per qualche minuto.",
    '                                 Environment.NewLine,
    '                                 mUtenza,
    '                                 Utx.Utente.NomeUtenza(mUtenza),
    '                                 Utx.Globale.TitoloApp), MsgBoxStyle.Information)
    '        End If
    '    End Sub

    '    Public Sub CancellaInvito()
    '        Me.Cancella()
    '    End Sub
    'End Class
End Class
