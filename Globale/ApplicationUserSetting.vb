Imports System.IO
Imports System.Xml.Serialization
Imports System.Text

Public Class ApplicationUserSetting

    Public Enum TipoSetting
        GLOBALE
        UTENTE
        INTEROP
        EXTRA
    End Enum

    Private mImpostazioni As New SerializableDictionary(Of String, String)
    Private ReadOnly mFileSettingBak As String
    Private ReadOnly Log As New ApplicationLog("GestioneSetting.log", Utx.Globale.Paths.CartellaLogs)

    Sub New(Tipo As TipoSetting)
        mTipoFile = Tipo
        Select Case mTipoFile
            Case TipoSetting.GLOBALE
                mFileSetting = Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "Unitools.Setting.xml")
            Case TipoSetting.UTENTE
                mFileSetting = Path.Combine(Utx.Globale.Paths.CartellaSettingRete,
                                            String.Format("{0}.Setting.xml", Utx.Globale.UtenteCorrente.UniageUser))
            Case TipoSetting.INTEROP
                mFileSetting = Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "Interop.Setting.xml")
        End Select
        'file di backup
        mFileSettingBak = mFileSetting + ".bak"
        'leggo le impostazioni
        Me.Leggi()
        'imposta livellolog
        If mTipoFile = TipoSetting.GLOBALE Then
            Utx.ApplicationLog.LivelloLog = Me.LeggiValore(Utx.GestioneFlag.TipoFlag.LIVELLO_LOG, Val(Utx.ApplicationLog.Livello.INFO).ToString)
            Utx.Globale.Log.InfoNoLivello(String.Format("Livello LOG impostato: {0}", Utx.ApplicationLog.LivelloLog))
        End If
    End Sub

    Sub New(Tipo As TipoSetting, NomeFile As String)
        mTipoFile = Tipo
        Select Case mTipoFile
            Case TipoSetting.EXTRA
                mFileSetting = String.Format("{0}\{1}.Setting.xml", Utx.Globale.Paths.CartellaSettingRete, NomeFile)
        End Select
        'file di backup
        mFileSettingBak = mFileSetting + ".bak"
        'leggo le impostazioni
        Me.Leggi()
    End Sub

    Sub New(Tipo As TipoSetting, NomeFile As String, Cartella As String)
        mTipoFile = Tipo
        Select Case mTipoFile
            Case TipoSetting.EXTRA
                mFileSetting = String.Format("{0}\{1}.Setting.xml", Cartella, NomeFile)
        End Select
        'file di backup
        mFileSettingBak = mFileSetting + ".bak"
        'leggo le impostazioni
        Me.Leggi()
    End Sub

    Sub New(UniageUser As String)
        'solo per il setting utente
        mTipoFile = TipoSetting.UTENTE
        mFileSetting = Path.Combine(Utx.Globale.Paths.CartellaSettingRete, String.Format("{0}.Setting.xml", UniageUser))
        'file di backup
        mFileSettingBak = mFileSetting + ".bak"
        'leggo le impostazioni
        Me.Leggi()
    End Sub

    Public ReadOnly Property Impostazioni() As SerializableDictionary(Of String, String)
        Get
            Return mImpostazioni
        End Get
    End Property

    Private mFileSetting As String
    Public ReadOnly Property FileSetting() As String
        Get
            Return mFileSetting
        End Get
    End Property

    Public ReadOnly Property EsisteSetting() As Boolean
        Get
            Return File.Exists(mFileSetting)
        End Get
    End Property

    Private mTipoFile As TipoSetting
    Public ReadOnly Property TipoFile() As TipoSetting
        Get
            Return mTipoFile
        End Get
    End Property

    Public Function EsisteChiave(Chiave As String) As Boolean
        Me.Leggi()
        Return mImpostazioni.ContainsKey(Chiave)
    End Function

    Public Function EsisteChiave(Chiave As Utx.GestioneFlag.TipoFlag) As Boolean
        Me.Leggi()
        Return mImpostazioni.ContainsKey(Chiave.ToString)
    End Function

    Public Sub AggiungiModifica(Chiave As String,
                                Valore As String,
                                Optional SalvaImpostazioni As Boolean = True)
        Try
            Me.Leggi()

            If mImpostazioni.ContainsKey(Chiave) Then
                mImpostazioni.Item(Chiave) = Valore
            Else
                mImpostazioni.Add(Chiave, Valore)
            End If

            If mTipoFile = TipoSetting.UTENTE Then
                If SalvaImpostazioni = True Then Me.Salva()
            Else
                Me.Salva()
            End If
            Log.Trace(String.Format("{0}Funzione: AggiungiModifica{0}Tipo: {1}{0}Chiave: {2}{0}Valore: {3}{0}Utente: {4}{0}",
                                     Environment.NewLine, mTipoFile, Chiave, Valore, Utente))

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Public Sub AggiungiModifica(Chiave As Utx.GestioneFlag.TipoFlag,
                                Valore As String,
                                Optional SalvaImpostazioni As Boolean = True)
        Try
            Me.Leggi()

            If mImpostazioni.ContainsKey(Chiave.ToString) Then
                mImpostazioni.Item(Chiave.ToString) = Valore
            Else
                mImpostazioni.Add(Chiave.ToString, Valore)
            End If

            If mTipoFile = TipoSetting.UTENTE Then
                If SalvaImpostazioni = True Then Me.Salva()
            Else
                Me.Salva()
            End If
            Log.Trace(String.Format("{0}Funzione: AggiungiModifica{0}Tipo: {1}{0}Chiave: {2}{0}Valore: {3}{0}Utente: {4}{0}",
                                     Environment.NewLine, mTipoFile, Chiave, Valore, Utente))

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Public Sub AggiungiModifica(Chiave As Utx.GestioneFlag.TipoFlag,
                                Valore As Date,
                                Optional SalvaImpostazioni As Boolean = True)
        Try
            Me.Leggi()

            If mImpostazioni.ContainsKey(Chiave.ToString) Then
                mImpostazioni.Item(Chiave.ToString) = Format(Valore, "dd/MM/yyyy HH:mm:ss")
            Else
                mImpostazioni.Add(Chiave.ToString, Format(Valore, "dd/MM/yyyy HH:mm:ss"))
            End If

            If mTipoFile = TipoSetting.UTENTE Then
                If SalvaImpostazioni = True Then Me.Salva()
            Else
                Me.Salva()
            End If
            Log.Trace(String.Format("{0}Funzione: AggiungiModifica{0}Tipo: {1}{0}Chiave: {2}{0}Valore: {3}{0}Utente: {4}{0}",
                                     Environment.NewLine, mTipoFile, Chiave, Format(Valore, "dd/MM/yyyy HH:mm:ss"), Utente))

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Public Sub Rimuovi(Chiave As String)
        Try
            If mImpostazioni.ContainsKey(Chiave) Then
                mImpostazioni.Remove(Chiave)
                Me.Salva()
            End If
            Log.Trace(String.Format("{0}Funzione: Rimuovi{0}Tipo: {1}{0}Chiave: {2}{0}Utente: {3}{0}Esiste: {4}{0}",
                                     Environment.NewLine, mTipoFile, Chiave, Utente, Me.EsisteChiave(Chiave)))

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Public Sub Rimuovi(Chiave As Utx.GestioneFlag.TipoFlag)
        Try
            If mImpostazioni.ContainsKey(Chiave.ToString) Then
                mImpostazioni.Remove(Chiave.ToString)
                Me.Salva()
            End If
            Log.Trace(String.Format("{0}Funzione: Rimuovi{0}Tipo: {1}{0}Chiave: {2}{0}Utente: {3}{0}Esiste: {4}{0}",
                                     Environment.NewLine, mTipoFile, Chiave, Utente, Me.EsisteChiave(Chiave)))

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Public Function LeggiValore(Chiave As String) As String
        Try
            Me.Leggi()
            If mImpostazioni.ContainsKey(Chiave) Then
                Return mImpostazioni.Item(Chiave)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Log.Trace(Chiave)
            Log.Trace(ex.Message)
            Return Nothing
        Finally
            Log.Trace(String.Format("{0}Funzione: LeggiValore{0}Tipo: {1}{0}Chiave: {2}{0}Valore letto: {3}{0}Utente: {4}{0}",
                       Environment.NewLine, mTipoFile, Chiave, LeggiValore, Utente))
        End Try
    End Function

    Public Function LeggiValore(Chiave As Utx.GestioneFlag.TipoFlag) As String
        Try
            Me.Leggi()
            If mImpostazioni.ContainsKey(Chiave.ToString) Then
                Return mImpostazioni.Item(Chiave.ToString)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Log.Trace(Chiave.ToString)
            Log.Trace(ex.Message)
            Return Nothing
        Finally
            Log.Trace(String.Format("{0}Funzione: LeggiValore{0}Tipo: {1}{0}Chiave: {2}{0}Valore letto: {3}{0}Utente: {4}{0}",
                       Environment.NewLine, mTipoFile, Chiave, LeggiValore, Utente))
        End Try
    End Function

    Public Function LeggiValore(Chiave As String, ValoreDefault As String) As String
        Try
            Dim Valore As String = LeggiValore(Chiave)
            If Valore Is Nothing Then
                'inizializza chiave al valore di default
                AggiungiModifica(Chiave, ValoreDefault)
                Return ValoreDefault
            Else
                'se il valore di default è una data e il valore letto non lo è
                If IsDate(ValoreDefault) = True AndAlso IsDate(Valore) = False Then
                    AggiungiModifica(Chiave, ValoreDefault)
                    Return ValoreDefault
                Else
                    Return Valore
                End If
            End If
        Catch ex As Exception
            Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Function LeggiValore(Chiave As Utx.GestioneFlag.TipoFlag, ValoreDefault As String) As String
        Try
            Dim Valore As String = LeggiValore(Chiave)
            If Valore Is Nothing Then
                'inizializza chiave al valore di default
                AggiungiModifica(Chiave, ValoreDefault)
                Return ValoreDefault
            Else
                'se il valore di default è una data e il valore letto non lo è
                If IsDate(ValoreDefault) = True AndAlso IsDate(Valore) = False Then
                    AggiungiModifica(Chiave, ValoreDefault)
                    Return ValoreDefault
                Else
                    Return Valore
                End If
            End If
        Catch ex As Exception
            Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Function LeggiValoreCriptato(Chiave As Utx.GestioneFlag.TipoFlag, Key As String, ValoreDefault As String) As String
        Try
            Dim wrapper As New Utx.Crypto(Key)
            Dim Valore As String = LeggiValore(Chiave)

            If Valore Is Nothing Then
                Return ValoreDefault
            Else
                Return wrapper.DecryptData(Valore)
            End If
        Catch ex As Exception
            Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Function LeggiValore(Chiave As Utx.GestioneFlag.TipoFlag, DataOra As DateTime) As String
        Try
            Dim Valore As String = LeggiValore(Chiave)
            If Valore Is Nothing Then
                'inizializza chiave al valore di default
                AggiungiModifica(Chiave, Format(DataOra, "dd/MM/yyyy HH:mm:ss"))
                Return Format(DataOra, "dd/MM/yyyy HH:mm:ss")
            Else
                'il valore deve essere convertibile in data
                If IsDate(Valore) Then
                    Return Valore
                Else
                    MsgBox(String.Format("Il valore '{0}' non è convertibile in una data. Impostare, per tutti gli utenti, il carattere / come separatore delle date e : come separatore nelle ore", Valore), MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    Return Format(DataOra, "dd/MM/yyyy HH:mm:ss")
                End If
            End If
        Catch ex As Exception
            Log.Errore(ex)
            Return Format(DataOra, "dd/MM/yyyy HH:mm:ss")
        End Try
    End Function

    Public Sub Salva()
        Dim Tentativo As Integer = 0

        Try
            Me.Backup()

SalvaDizionario:
            'salvo dati 
            Dim xml_serializer As New XmlSerializer(GetType(SerializableDictionary(Of String, String)))

            Using fs As New FileStream(mFileSetting, FileMode.Create)
                xml_serializer.Serialize(fs, mImpostazioni)
            End Using

            Log.Trace(Me.mFileSetting)
            Log.Trace(String.Format("Salva {0} effettuato al tentativo {1}", mTipoFile, Tentativo))

        Catch ex As Exception
            Log.Info(ex.Message)
            Select Case Tentativo
                Case 0, 1 'faccio 2 nuovi tentativi
                    Log.Info(String.Format("Tentativo {0}: salva {1} - {2}", Tentativo, mTipoFile, Me.mFileSetting))
                    Log.Info(ex.Message)
                    Tentativo += 1
                    Threading.Thread.Sleep(1000) 'aspetto un secondo
                    GoTo SalvaDizionario 'e riprovo
                Case Else
                    Log.Info(Me.mFileSetting)
                    Log.Errore(ex)
            End Select
        End Try
    End Sub

    Public Sub Backup()
        Try
            'se il file esiste faccio un backup
            If File.Exists(mFileSetting) = True Then
                File.Copy(mFileSetting, mFileSettingBak, True)
            End If
        Catch ex As Exception
            Log.Info(ex)
        End Try
    End Sub

    Public Sub Leggi()
        Dim Tentativo As Integer = 0
        Try
LeggiDizionario:
            If File.Exists(mFileSetting) Then
                'leggo le impostazioni
                Dim xml_serializer As New XmlSerializer(GetType(SerializableDictionary(Of String, String)))

                Using fs As New FileStream(mFileSetting, FileMode.Open)
                    mImpostazioni = DirectCast(xml_serializer.Deserialize(fs), SerializableDictionary(Of String, String))
                End Using
            End If

            Log.Trace(String.Format("Lettura {0} effettuata al tentativo {1}", mTipoFile, Tentativo))

        Catch ex As Exception
            Select Case Tentativo
                Case 0, 1
                    Log.Info(String.Format("Leggi {0}: tentativo {1}", mTipoFile, Tentativo))
                    Log.Info(ex.Message)
                    Tentativo += 1
                    Threading.Thread.Sleep(1000) 'aspetto un secondo
                    GoTo LeggiDizionario 'e riprovo
                Case 2
                    Log.Info(String.Format("Leggi: tentativo {0}", Tentativo))
                    Log.Info(ex.Message)
                    'ripristino da backup se esiste
                    If File.Exists(mFileSettingBak) Then
                        File.Copy(mFileSettingBak, mFileSetting, True)
                        'riprovo a leggere
                        Tentativo += 1
                        GoTo LeggiDizionario
                    End If
                Case Else
                    Log.Errore(ex)
            End Select
        End Try
    End Sub

    Public Shared Function LeggiFileSetting(FileSetting As String) As SerializableDictionary(Of String, String)
        Try
            If File.Exists(FileSetting) Then
                'leggo le impostazioni
                Dim xml_serializer As New XmlSerializer(GetType(SerializableDictionary(Of String, String)))

                Using fs As New FileStream(FileSetting, FileMode.Open)
                    Return DirectCast(xml_serializer.Deserialize(fs), SerializableDictionary(Of String, String))
                End Using
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Private Function Utente() As String
        If Utx.Globale.UtenteCorrente Is Nothing Then
            Return "ND"
        Else
            Return Utx.Globale.UtenteCorrente.UniageUser
        End If
    End Function
End Class
