Public Class Postalizzazione

    Public Enum Modalita
        AUTO
        MANUALE
    End Enum

    Public Event RichiestaArretrati(Agenzia As AgenziaConfigPostalizzazione, InizioPeriodo As Date, FinePeriodo As Date)

    Public Shared SettingPostalizzazione As New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.EXTRA, "Postalizzazione")

    Sub New(Agenzia As String)
        mAgenziaConfig = New AgenziaConfigPostalizzazione(Agenzia)
    End Sub

    Private mModo As Modalita
    Public Property Modo() As Modalita
        Get
            Return mModo
        End Get
        Set(value As Modalita)
            mModo = value
        End Set
    End Property

    Private mAgenziaConfig As AgenziaConfigPostalizzazione
    Public Property AgenziaConfig() As AgenziaConfigPostalizzazione
        Get
            Return mAgenziaConfig
        End Get
        Set(value As AgenziaConfigPostalizzazione)
            mAgenziaConfig = value
        End Set
    End Property

    Public Shared ReadOnly Property CodiciAbilitatiUT() As List(Of String)
        Get
            Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                                          Utx.SettingItem.Chiavi.COMUNICATORE_CODICI_ABILITATI,
                                          "", Utx.SettingOMW.TipoOperazione.LETTURA)

            CodiciAbilitatiUT = New List(Of String)

            If Chiave.ItemResult.Esiste Then
                For Each agenzia As String In Chiave.ItemResult.Valore.Split(";")
                    'escludo codici non gestiti in postalizzazione dalla sede
                    If Utx.EnteGestore.CodiciPostalizzati.Contains(agenzia) Then
                        CodiciAbilitatiUT.Add(agenzia)
                    End If
                Next
            End If
        End Get
    End Property

    Private Shared mProssimaEsecuzione As Date = Today
    Public Shared Property ProssimaEsecuzione() As Date
        Get
            'If mProssimaEsecuzione.Year < 2000 Then
            '    mProssimaEsecuzione = OggiPostalizzazione.AddDays(1) 'domani
            '    'per ogni codice postalizzato
            '    For Each agenzia As String In UniCom.Postalizzazione.CodiciAbilitatiUT
            '        If CodicePostalizzato(agenzia) = False Then
            '            'codice non postalizzato eseguo subito
            '            mProssimaEsecuzione = Now
            '            Exit For
            '        End If
            '    Next
            'End If
            Return mProssimaEsecuzione
        End Get
        Set(value As Date)
            mProssimaEsecuzione = value
        End Set
    End Property

    Private Shared Sub LeggiDatePostalizzazione()
        Try
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Dim Temp As String = s.DateAutoPostalizzazioneEx
                mInizioPostalizzazioneManuale = DateSerial(OggiPostalizzazione.Year, OggiPostalizzazione.Month, Temp.Split(";")(0))
                mInizioAutoPostalizzazione = DateSerial(OggiPostalizzazione.Year, OggiPostalizzazione.Month, Temp.Split(";")(1))
                mFineAutoPostalizzazione = DateSerial(OggiPostalizzazione.Year, OggiPostalizzazione.Month, Temp.Split(";")(2))
            End Using
        Catch ex As Exception
            mInizioPostalizzazioneManuale = DateSerial(Today.Year, Today.Month, 25)
            mInizioAutoPostalizzazione = DateSerial(Today.Year, Today.Month, 26)
            mFineAutoPostalizzazione = DateSerial(Today.Year, Today.Month, 26)
        End Try
        'se si è chiuso il periodo di auto postalizzazione vado al mese seguente
        If OggiPostalizzazione > mFineAutoPostalizzazione Then
            mInizioPostalizzazioneManuale = mInizioPostalizzazioneManuale.AddMonths(1)
            mInizioAutoPostalizzazione = mInizioAutoPostalizzazione.AddMonths(1)
            mFineAutoPostalizzazione = mFineAutoPostalizzazione.AddMonths(1)
        End If
    End Sub

    Private Shared mOggiPostalizzazione As Date
    Public Shared ReadOnly Property OggiPostalizzazione() As Date
        Get
            Try
                If mOggiPostalizzazione.Year < 2000 Then
                    Using s As New Utx.SettingAgenzia.ConfiguraSede
                        s.Proxy = Utx.Globale.UniProxy.Proxy
                        mOggiPostalizzazione = s.OggiPostalizzazione
                    End Using
                End If
            Catch ex As Exception
                mOggiPostalizzazione = Today
            End Try
            Return mOggiPostalizzazione
        End Get
    End Property

    Private Shared mInizioPostalizzazioneManuale As Date
    Public Shared ReadOnly Property InizioPostalizzazioneManuale() As Date
        Get
            If (mInizioAutoPostalizzazione.Year < 2000) OrElse (mFineAutoPostalizzazione.Year < 2000) Then
                LeggiDatePostalizzazione()
            End If
            Return mInizioPostalizzazioneManuale
        End Get
    End Property

    Private Shared mInizioAutoPostalizzazione As Date
    Public Shared ReadOnly Property InizioAutoPostalizzazione() As Date
        Get
            If (mInizioAutoPostalizzazione.Year < 2000) OrElse (mFineAutoPostalizzazione.Year < 2000) Then
                LeggiDatePostalizzazione()
            End If
            Return mInizioAutoPostalizzazione
        End Get
    End Property

    Private Shared mFineAutoPostalizzazione As Date
    Public Shared ReadOnly Property FineAutoPostalizzazione() As Date
        Get
            If (mInizioAutoPostalizzazione.Year < 2000) OrElse (mFineAutoPostalizzazione.Year < 2000) Then
                LeggiDatePostalizzazione()
            End If
            Return mFineAutoPostalizzazione
        End Get
    End Property

    Public Function IdLotto() As String
        Return String.Format("{0}_{1:MMyyyy}", mAgenziaConfig.Agenzia, Koine.Avvisi.InizioPeriodo)
    End Function

    Public Shared Function IdLotto(Agenzia As String) As String
        Return String.Format("{0}_{1:MMyyyy}", Agenzia, Koine.Avvisi.InizioPeriodo)
    End Function

    Public Shared Function CodicePostalizzato(Agenzia As String) As Boolean
        Try
            Dim Query As String = String.Format("IF OBJECT_ID('dbo.[StoricoPostalizzazione]', 'U') IS NOT NULL
                    SELECT COUNT(*) FROM StoricoPostalizzazione 
                    WHERE FileDati = '{0}' AND DataRevoca IS NULL
                    ELSE
                    SELECT 0", IdLotto(Agenzia))
            Return Utx.WsCommand.ExecuteScalar(Query).Valore > 0
        Catch ex As Exception
            Koine.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Function ReportInvio(Agenzia As String) As DataTable
        Try
            Dim Query As String = "IF OBJECT_ID('dbo.[StoricoPostalizzazione]', 'U') IS NOT NULL
                SELECT '' AS Periodo,* 
                FROM StoricoPostalizzazione
                ORDER BY DataInvio DESC"

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query, Agenzia).DataTable
            'sistemo il periodo
            For Each row As DataRow In dt.Rows
                row("Periodo") = Right(row("FileDati").ToString.Trim, 6).Insert(2, "-")
            Next
            Return dt
        Catch ex As Exception
            Koine.Log.Errore(ex)
            Return New DataTable
        End Try
    End Function

    Public Function InviaAvvisi() As Boolean
        Try
            RaiseEvent RichiestaArretrati(AgenziaConfig, Koine.Avvisi.InizioPeriodo, Koine.Avvisi.FinePeriodo)

            If AgenziaConfig.LetturaArretrati = True Then
                Dim Notifica As New Utx.FormNotifica
                With Notifica
                    .ColoreSfondo = Drawing.Color.WhiteSmoke
                    .ColoreBordo = Utx.AppColor.RossoScuro
                    .LabelMessaggio.Font = Utx.AppFont.Bold
                    .Opacity = 1
                    .Text = ""
                    .Show()

                    .Messaggio = "Aggiornamento struttura agenzia..."
                End With

                'imposto l'agenzia
                Koine.Agenzia = AgenziaConfig.Agenzia
                'invio i dati dei cip
                Koine.Servizi.InviaStrutturaAgenzia()

                'creo e invio gli avvisi
                Notifica.Messaggio = "Lettura dati..."
                Dim Avvisi As New UniCom.Koine.Avvisi()
                Notifica.ChiusuraImmediata()

                Return Avvisi.Invia(Modalita.AUTO)
            Else
                'la lettura degli arretrati non è riuscita
                Return False
            End If

        Catch ex As Exception
            Koine.Log.Errore(ex)
            Return False
        End Try
    End Function
End Class

Public Class AgenziaConfigPostalizzazione

    Public Event ModificaStatoPostalizzazione(PeriodoPostalizzato As Boolean)

    Sub New(Agenzia As String)
        mAgenzia = Agenzia
        Koine.Agenzia = Agenzia

        Me.StatoConfig = Koine.Servizi.StatoConfig()
        Me.PeriodoPostalizzato = Postalizzazione.CodicePostalizzato(mAgenzia)
    End Sub

    Private mAgenzia As String
    Public Property Agenzia() As String
        Get
            Return mAgenzia
        End Get
        Set(value As String)
            mAgenzia = value
        End Set
    End Property

    Public ReadOnly Property Descrizione() As String
        Get
            Return String.Format("{0} - configurazione {1}", mAgenzia, Me.StatoConfigUT)
        End Get
    End Property

    Private Shared mConfigEnte As Boolean
    Public Shared ReadOnly Property ConfigEnte() As Boolean
        Get
#If DEBUG Then
            Return True 'per debug
#End If
            Return mConfigEnte
        End Get
    End Property

    Private mLetturaArretrati As Boolean
    Public Property LetturaArretrati() As Boolean
        Get
            Return mLetturaArretrati
        End Get
        Set(value As Boolean)
            mLetturaArretrati = value
        End Set
    End Property

    Private mStatoConfig As String
    Public Property StatoConfig() As String
        Get
            Return mStatoConfig
        End Get
        Set(value As String)
            mStatoConfig = value
            'configurazione ente
            Select Case mStatoConfig
                Case Koine.RispostaKoine.MessaggioStato.notpresent.ToString
                    Koine.Servizi.InviaStrutturaAgenzia()
                    mConfigEnte = False
                Case Koine.RispostaKoine.MessaggioStato.incomplete.ToString
                    mConfigEnte = False
                Case Koine.RispostaKoine.MessaggioStato.disabled.ToString
                    MsgBox(String.Format("Il codice {0} risulta disabilitato sul portale di postalizzazione. Contattare l'assistenza.", Agenzia),
                           MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    mConfigEnte = False
                Case Else
                    mConfigEnte = True
            End Select
        End Set
    End Property

    Private mPeriodoPostalizzato As Boolean
    Public Property PeriodoPostalizzato() As Boolean
        Get
            Return mPeriodoPostalizzato
        End Get
        Set(value As Boolean)
            mPeriodoPostalizzato = value
            RaiseEvent ModificaStatoPostalizzazione(mPeriodoPostalizzato)
        End Set
    End Property

    Public ReadOnly Property StatoConfigUT() As String
        Get
            Select Case mStatoConfig
                Case Koine.RispostaKoine.MessaggioStato.complete.ToString
                    Return "completa"
                Case Koine.RispostaKoine.MessaggioStato.incomplete.ToString
                    Return "incompleta"
                Case Koine.RispostaKoine.MessaggioStato.notpresent.ToString
                    Return "incompleta"
                Case Koine.RispostaKoine.MessaggioStato.disabled.ToString
                    Return "disabilitata"
                Case Else
                    Return "indefinita"
            End Select
        End Get
    End Property

    Public Sub AggiornaStatoPostalizzazione()
        Me.PeriodoPostalizzato = Postalizzazione.CodicePostalizzato(mAgenzia)
    End Sub
End Class