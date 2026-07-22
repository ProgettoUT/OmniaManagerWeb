
<Serializable>
Public Class EnteGestore

    Public Abilitazioni As AbilitazioniAgenzia
    Public Uniarea As New DatiUniarea
    Public ConfigurazioneServer As New DataTable

    Sub New()
        LeggiProfiloEnte()
    End Sub

    Private mProfiloApp As Utx.Enumerazioni.ProfiloApp
    Public ReadOnly Property ProfiloApp() As Utx.Enumerazioni.ProfiloApp
        Get
#If DEBUG Then
            Return Enumerazioni.ProfiloApp.COMPLETO
#End If
            Return mProfiloApp
        End Get
    End Property

    Private mEsiste As Boolean = False
    Public ReadOnly Property Esiste() As Boolean
        Get
            Return mEsiste
        End Get
    End Property

    Private mCompagnia As Integer = 0
    Public Property Compagnia() As Integer
        Get
            Return mCompagnia
        End Get
        Set(value As Integer)
            mCompagnia = value
        End Set
    End Property

    Private mAgenziaMadre As String = ""
    Public Property AgenziaMadre() As String
        Get
            Return mAgenziaMadre
        End Get
        Set(value As String)
            mAgenziaMadre = value
        End Set
    End Property

    Private mRegione As Integer = 0
    Public Property Regione() As Integer
        Get
            Return mRegione
        End Get
        Set(value As Integer)
            mRegione = value
        End Set
    End Property

    Private mProvincia As String = ""
    Public Property Provincia() As String
        Get
            Return mProvincia
        End Get
        Set(value As String)
            mProvincia = value
        End Set
    End Property

    Private mCodiceSede As String = ""
    Public Property CodiceSede() As String
        Get
            Return mCodiceSede.Trim
        End Get
        Set(value As String)
            mCodiceSede = value
        End Set
    End Property

    Private mCapoluogo As String = ""
    Public Property Capoluogo() As String
        Get
            Return mCapoluogo
        End Get
        Set(value As String)
            mCapoluogo = value
        End Set
    End Property

    Private mLocalita As String = ""
    Public Property Localita() As String
        Get
            Return mLocalita
        End Get
        Set(value As String)
            mLocalita = value
        End Set
    End Property

    Private mIndirizzo As String = ""
    Public Property Indirizzo() As String
        Get
            Return mIndirizzo
        End Get
        Set(value As String)
            mIndirizzo = value
        End Set
    End Property

    Private mCap As String = ""
    Public Property Cap() As String
        Get
            Return mCap
        End Get
        Set(value As String)
            mCap = value
        End Set
    End Property

    Private mNumeroSerie As String = ""
    Public Property NumeroSerie() As String
        Get
            Return mNumeroSerie
        End Get
        Set(value As String)
            mNumeroSerie = value
        End Set
    End Property

    Private mCodiceUtente As String = ""
    Public Property CodiceUtente() As String
        Get
            Return mCodiceUtente
        End Get
        Set(value As String)
            mCodiceUtente = value
        End Set
    End Property

    Private Shared mCodiciGestiti As List(Of String)
    Public Shared Function CodiciGestiti() As List(Of String)
        LeggiCodiciGestiti()
        Return mCodiciGestiti
    End Function

    Public Shared ReadOnly Property StringaCodiciGestiti(Optional Separatore As Char = ";") As String
        Get
            Try
                Dim Codici As String = ""

                For Each codice As String In mCodiciGestiti
                    Codici += codice + Separatore
                Next

                Return Codici.Substring(0, Codici.Length - 1) 'tolgo l'ultimo ;

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return ""
            End Try
        End Get
    End Property

    Public Shared ReadOnly Property ArrayCodiciGestiti() As String()
        Get
            Try
                Dim Codici(mCodiciGestiti.Count - 1) As String
                For k = 0 To mCodiciGestiti.Count - 1
                    Codici(k) = mCodiciGestiti(k)
                Next
                Return Codici
            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return {}
            End Try
        End Get
    End Property

    Private Shared mCodiciPostalizzati As List(Of String)
    Public Shared Function CodiciPostalizzati() As List(Of String)
        LeggiCodiciGestiti()
        Return mCodiciPostalizzati
    End Function

    Public Shared ReadOnly Property StringaCodiciPostalizzati() As String
        Get
            Try
                Dim Codici As String = ""

                For Each codice As String In mCodiciPostalizzati
                    Codici += codice + ";"
                Next

                Return Codici.Substring(0, Codici.Length - 1) 'tolgo l'ultimo ;

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return ""
            End Try
        End Get
    End Property

    Private Shared Sub LeggiCodiciGestiti()
        Try
            If mCodiciGestiti Is Nothing AndAlso Utx.Globale.ProfiloEnteGestore IsNot Nothing Then
                mCodiciGestiti = New List(Of String)
                mCodiciPostalizzati = New List(Of String)

                Using s As New Utx.SettingAgenzia.ConfiguraSede 'Utx.ConfiguraAgenzia 
                    s.Proxy = Utx.Globale.UniProxy.Proxy
                    'gruppo 0 codici collegati - 1 codici gestiti in postalizzazione
                    Dim Risposta As String = s.AgenzieCollegateEx(1, Utx.Globale.ProfiloEnteGestore.AgenziaMadre,
                                                                  Utx.Globale.ProfiloEnteGestore.CodiceSede)
                    For Each a As String In Risposta.Split("|")(0).Split("/")
                        mCodiciGestiti.Add(a)
                    Next
                    For Each a As String In Risposta.Split("|")(1).Split("/")
                        mCodiciPostalizzati.Add(a)
                    Next
                End Using
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Function MenuExtra(AgenziaMadre As String, Sede As String, Utente As String) As DataTable
        Try
            'db: ConfigDownload\Servizi.mdb
            Using s As New Utx.SettingAgenzia.ConfiguraSede With {.Proxy = Utx.Globale.UniProxy.Proxy}
                Return s.MenuExtra(AgenziaMadre, Sede, Utente).Tables(0)
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Info(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Sub LeggiProfiloEnte()
        Try
            If Utx.Tester.EsisteAgenziaXml Then
                Dim sett As Utx.ApplicationUserSetting = Utx.Tester.SettingAgenziaXml
                mEsiste = True
                mCompagnia = 1
                mCodiceSede = sett.LeggiValore("SEDE", "00")
                mAgenziaMadre = sett.LeggiValore("AGENZIA")
                mRegione = 0
                mProvincia = "xx"
                mCapoluogo = "S"
                mLocalita = "xxxx"
                mIndirizzo = "xxxx"
                mCap = "12345"
                mNumeroSerie = "123"
                mCodiceUtente = "123"
            Else
                'imposto agenzia madre
                Using s As New Utx.SettingAgenzia.ConfiguraSede With {.Proxy = Utx.Globale.UniProxy.Proxy}
                    'ritorna: madre;collegate
                    mAgenziaMadre = s.AgenziaMadre(Utx.Globale.UtenteCorrente.AgenziaUtente).Split(";")(0)
                End Using

                Dim Query As String = String.Format("SELECT TOP 1 * FROM ProfiloUtente WHERE Agenzia = {0}",
                                                    Utx.Globale.UtenteCorrente.AgenziaUtente)

                Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(Query, mAgenziaMadre)
                Dim Profilo As DataTable = Risposta.DataTable
                If Profilo.Rows.Count > 0 Then
                    With Profilo.Rows(0)
                        mEsiste = True
                        mCompagnia = .Item("Compagnia")
                        'mAgenziaMadre = .Item("Agenzia")
                        mRegione = .Item("Regione")
                        mProvincia = .Item("Provincia")
                        mCodiceSede = .Item("CodiceSede").ToString.Trim
                        mCapoluogo = .Item("Capoluogo")
                        mLocalita = .Item("Localita")
                        mIndirizzo = .Item("Indirizzo")
                        mCap = .Item("Cap")
                        mNumeroSerie = .Item("NumeroSerie")
                        mCodiceUtente = .Item("CodiceUtente")
                    End With
                End If
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub SalvaProfiloUtente()
        Try
            'cancello eventuali profili precedenti e inserisco il profilo corrente
            Dim SF As New Utx.NetFunc.StringFormatter("DELETE FROM ProfiloUtente
                INSERT INTO ProfiloUtente(Compagnia,Agenzia,Regione,Provincia,CodiceSede,
                Capoluogo,Localita,Indirizzo,Cap,NumeroSerie,CodiceUtente,UltimaModifica) 
                VALUES(@compagnia,@agenzia,@regione,@provincia,@sede,
                @capoluogo,@localita,@indirizzo,@cap,@serie,@codice,@modifica)")

            With SF
                .Parametro("@compagnia", mCompagnia)
                .Parametro("@agenzia", mAgenziaMadre, True)
                .Parametro("@regione", mRegione, True)
                .Parametro("@provincia", mProvincia, True)
                .Parametro("@sede", mCodiceSede, True)
                .Parametro("@capoluogo", mCapoluogo, True)
                .Parametro("@localita", mLocalita, True)
                .Parametro("@indirizzo", mIndirizzo, True)
                .Parametro("@cap", mCap, True)
                .Parametro("@serie", mNumeroSerie, True)
                .Parametro("@codice", mCodiceUtente, True)
                .Parametro("@modifica", Format(Today, "dd/MM/yyyy"), True)
            End With
            Utx.WsCommand.ExecuteNonQuery(SF.StringaFormattata)

            mEsiste = True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            mEsiste = False
        End Try
    End Sub

    Public Sub ImpostaProfiloApp()
        'mProfiloApp = Enumerazioni.ProfiloApp.SINISTRI
        Select Case Abilitazioni.UNITOOLS
            Case 0
                mProfiloApp = Enumerazioni.ProfiloApp.NESSUNO
                'rimuovo la chiave per rileggere da web al prossimo tentativo
                Utx.Globale.SettingGlobale.Rimuovi(Utx.GestioneFlag.TipoFlag.ABILITAZIONI_AGENZIA)
            Case 1
                mProfiloApp = Enumerazioni.ProfiloApp.COMPLETO
            Case 2
                mProfiloApp = Enumerazioni.ProfiloApp.SINISTRI
            Case 3
                mProfiloApp = Enumerazioni.ProfiloApp.POSTALIZZAZIONE
            Case 4
                mProfiloApp = Enumerazioni.ProfiloApp.SINISTRI_POSTALIZZAZIONE
            Case Else
                'per sicurezza in caso di errori
                mProfiloApp = Enumerazioni.ProfiloApp.NESSUNO
        End Select
#If DEBUG Then
        'mProfiloApp = Enumerazioni.ProfiloApp.SINISTRI_POSTALIZZAZIONE
#End If
    End Sub

    'Public Function FunzionalitaDisponibile(Chiave As String) As Boolean
    '    Select Case Utx.Globale.ProfiloEnteGestore.ProfiloApp
    '        Case Utx.Enumerazioni.ProfiloApp.COMPLETO
    '            Return True
    '        Case Utx.Enumerazioni.ProfiloApp.SINISTRI
    '            Select Case Chiave
    '                Case "SCHEDASINISTRI", "STATISTICHE", "CAI", "BAREMES", "REFERENTI", "IMPORTA", "CONFIG", "CAMBIOAGENZIA", "CAMBIAUTENTE", "STRUMENTI", "VEDILOG"
    '                    Return True
    '                Case Else
    '                    Utx.Globale.Log.Info("Funzione '{0}' non abilitata per questo profilo ({1}).", {Chiave, Utx.Globale.ProfiloEnteGestore.ProfiloApp.ToString})
    '                    Return False
    '            End Select
    '        Case Utx.Enumerazioni.ProfiloApp.POSTALIZZAZIONE
    '            Select Case Chiave
    '                Case "ATTIVAPOST", "CONFIGPOST", "AVVISIPOST", "TRACCIAPOST", "IMPORTA", "CONFIG", "CAMBIOAGENZIA", "CAMBIAUTENTE", "STRUMENTI", "VEDILOG"
    '                    Return True
    '                Case Else
    '                    Utx.Globale.Log.Info("Funzione '{0}' non abilitata per questo profilo ({1}).", {Chiave, Utx.Globale.ProfiloEnteGestore.ProfiloApp.ToString})
    '                    Return False
    '            End Select
    '        Case Utx.Enumerazioni.ProfiloApp.SINISTRI_POSTALIZZAZIONE
    '            'da implementare
    '            Return False
    '        Case Else
    '            Return False
    '    End Select
    'End Function

    Public Sub LeggiConfigurazioneServer()
        Try
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                For k = 0 To Utx.EnteGestore.CodiciGestiti().Count - 1
                    ConfigurazioneServer.Merge(s.ConfigAgenzia(Utx.Globale.ProfiloEnteGestore.Compagnia,
                                                               Utx.EnteGestore.CodiciGestiti(k), Utx.Globale.ProfiloEnteGestore.CodiceSede).Tables(0))
                Next
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Function ConfigurazioneCodice(Optional CodiceAgenzia As String = Nothing) As DataTable
        Try
            If CodiceAgenzia Is Nothing Then
                Return ConfigurazioneServer
            Else
                Dim dv As New DataView(ConfigurazioneServer) With {.RowFilter = $"Agenzia = '{CodiceAgenzia}'"}
                Return dv.ToTable
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Function ConfigurazioneCodiciAttivi(CodiceAgenzia As String) As DataTable
        Try
            Dim dv As New DataView(ConfigurazioneServer) With {.RowFilter = String.Format("Agenzia = '{0}' AND DataFine >= #{1:MM/dd/yyyy}#", CodiceAgenzia, Today)}
            Return dv.ToTable
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    <Serializable>
    Public Class DatiUniarea

        Private mDati As DataTable

        Public Sub Init()
            If mDati Is Nothing Then
                Using s As New Utx.ServiziUniarea.accessoCasa
                    s.Proxy = Utx.Globale.UniProxy.Proxy
                    mDati = s.getDatiPostalizzazioneW(Utx.Globale.ProfiloEnteGestore.AgenziaMadre, Utx.NetFunc.TokenAccessoCasa).Tables(0)
                End Using
            End If
        End Sub

        Public ReadOnly Property Agenzia() As String
            Get
                Return mDati.Rows(0)("CodiceAgenzia")
            End Get
        End Property

        Public ReadOnly Property RagioneSociale() As String
            Get
                Return mDati.Rows(0)("RagioneSocialeEG")
            End Get
        End Property

        Public ReadOnly Property Indirizzo() As String
            Get
                Return mDati.Rows(0)("IndirizzoAgenzia")
            End Get
        End Property

        Public ReadOnly Property Cap() As String
            Get
                Return mDati.Rows(0)("CapAgenzia")
            End Get
        End Property

        Public ReadOnly Property Provincia() As String
            Get
                Return mDati.Rows(0)("ProvinciaAgenzia")
            End Get
        End Property

        Public ReadOnly Property Localita() As String
            Get
                Return mDati.Rows(0)("LocalitaAgenzia")
            End Get
        End Property

        Public ReadOnly Property Telefono() As String
            Get
                Return mDati.Rows(0)("TelefonoAgenzia")
            End Get
        End Property

        Public ReadOnly Property Fax() As String
            Get
                Return mDati.Rows(0)("FaxAgenzia")
            End Get
        End Property

        Public ReadOnly Property Email() As String
            Get
                Return mDati.Rows(0)("EmailAgenzia")
            End Get
        End Property

        Public ReadOnly Property Email2() As String
            Get
                Return mDati.Rows(0)("Email2Agenzia")
            End Get
        End Property

        Public ReadOnly Property PEC() As String
            Get
                Return mDati.Rows(0)("PecAgenzia")
            End Get
        End Property
    End Class
End Class

<Serializable>
Public Class AbilitazioniAgenzia

    Public UNITOOLS As Integer
    Public SMS As Boolean
    Public VISURE As Boolean
    Public SISTEMA As Boolean
    Public QUOTATORE As Boolean
    Public UNIGEST As Boolean
    Public POSTALIZZAZIONE As Boolean
    Public PATTO_UNIPOL As Boolean
    Public LISTEQT As Boolean
    Public ARCHIVIO_DATI As Boolean
    Public BUSTE As Boolean

    Sub New()
        LeggiAbilitazioni()
    End Sub

    Public WriteOnly Property Abilitazioni() As String
        Set(value As String)
            Try
                If String.IsNullOrEmpty(value) Then
                    AbilitazioniDefault()
                Else
                    If (value Like "#;#;#;#;#;#;#") = True Then
                        'formato restituito ok
                        Utx.Globale.Log.Info("Formato abilitazione valido: {0}", {value})

                        Dim Check() As String = value.Split(";")

                        UNITOOLS = Check(0)
                        SMS = (Check(1) = 1)
                        VISURE = (Check(2) = 1)
                        SISTEMA = (Check(3) = 1)
                        QUOTATORE = (Check(4) = 1)
                        UNIGEST = (Check(5) = 1)
                        POSTALIZZAZIONE = (Check(6) = 1)
                    Else
                        'formato non valido
                        Utx.Globale.Log.Info("Formato abilitazione NON valido: {0}", {value})
                        Me.AbilitazioniSedeDefault()
                    End If
                End If
            Catch ex As Exception
                AbilitazioniDefault()
            End Try
        End Set
    End Property

    Public WriteOnly Property AbilitazioniSede() As String
        Set(value As String)
            Try
                If String.IsNullOrEmpty(value) Then
                    AbilitazioniDefault()
                Else
                    If (value Like "[NS];[NS];[NS];[NS]") = True Then
                        Utx.Globale.Log.Info("Abilitazione sede letta correttamente")
                        Dim Check() As String = value.Split(";")

                        PATTO_UNIPOL = (Check(0) = "S")
                        LISTEQT = (Check(1) = "S")
                        ARCHIVIO_DATI = (Check(2) = "S")
                        BUSTE = (Check(3) = "S")
                    Else
                        'formato non valido
                        Utx.Globale.Log.Info("Formato abilitazione sede non valido")
                        AbilitazioniSedeDefault()
                    End If
                End If
            Catch ex As Exception
                AbilitazioniSedeDefault()
            End Try
        End Set
    End Property

    Private mDataAggiornamento As Date
    Public Property DataAggiornamento() As Object
        Get
            Return mDataAggiornamento
        End Get
        Set(value As Object)
            If IsDate(value) Then
                mDataAggiornamento = value
            Else
                mDataAggiornamento = CDate("01/01/2000")
            End If
        End Set
    End Property

    Public Sub LeggiAbilitazioni()
        Try
            LeggiAbilitazioniDaFile()

            'rileggo dato dal web
            Globale.PingUniarea = Utx.FunzioniRete.PingUniarea()
            Me.DataAggiornamento = Today

            If Globale.PingUniarea = True Then
                'controllo abilitazioni. il servizio restituisce una stringa di 1 (abilitato) e 0 (non abilitato) 1;0;0...
                If LeggiAbilitazioniWeb() = True Then
                    LeggiAbilitazioniWebSedeSecondaria()
                End If
                SalvaAbilitazioni()
            Else
                'uniarea non risponde tengo le abilitazioni da file ancora per un giorno
                SalvaAbilitazioni()
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            'tengo le abilitazioni da file
        End Try
    End Sub

    Private Function LeggiAbilitazioniWeb() As Boolean
        Try
            Utx.Globale.Log.Info("Leggo abilitazioni web per compagnia {0} agenzia madre {1}", {Utx.Globale.ProfiloEnteGestore.Compagnia, Utx.Globale.ProfiloEnteGestore.AgenziaMadre})
            'in caso di errore il servizio restituisce tutti zero
            Using s As New Utx.ServiziUniarea.accessoCasa With {.Proxy = Utx.Globale.UniProxy.Proxy}
                s.Timeout = 20000 '20 secondi
                Me.Abilitazioni = s.checkMultiploW(Utx.Globale.ProfiloEnteGestore.AgenziaMadre,
                                                   Utx.Globale.ProfiloEnteGestore.Compagnia,
                                                   Utx.NetFunc.TokenAccessoCasa)
            End Using
            Return True
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            'non modifico le abilitazioni così mi tengo quelle da file
            Return False
        End Try
    End Function

    Private Sub LeggiAbilitazioniWebSedeSecondaria()
        Utx.Globale.Log.Info("Leggo abilitazioni web sede secondaria")
        Try
            If Utx.Globale.ProfiloEnteGestore.CodiceSede = "00" Then
                Me.AbilitazioniSede = "S;S;S;S"
            Else
                'per le sedi secondarie leggo le abilitazioni
                Using s As New SettingAgenzia.ConfiguraSede With {.Proxy = Utx.Globale.UniProxy.Proxy}
                    s.Timeout = 20000 '20 secondi
                    Me.AbilitazioniSede = s.AbilitazioniSedeStringa(Utx.Globale.ProfiloEnteGestore.AgenziaMadre,
                                                                    Utx.Globale.ProfiloEnteGestore.Compagnia,
                                                                    Utx.Globale.ProfiloEnteGestore.CodiceSede)
                End Using
            End If
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            'non modifico le abilitazioni
        End Try
    End Sub

    Private Sub LeggiAbilitazioniDaFile()
        Utx.Globale.Log.Info("Leggo abilitazioni da file")
        Dim wrapper As New Utx.Crypto()
        Try
            Dim Temp As String = Utx.Globale.SettingGlobale.LeggiValore(Utx.GestioneFlag.TipoFlag.ABILITAZIONI_AGENZIA)

            If String.IsNullOrEmpty(Temp) Then
                Me.Abilitazioni = ""
            Else
                'se la chiave esiste la decripto
                Dim StringaAbilitazioni As String = wrapper.DecryptData(Temp)
                'controllo il formato
                If (StringaAbilitazioni.Split("|")(1) Like "#;#;#;#;#;#;#;[NS];[NS];[NS];[NS]") = True Then
                    'formato ok
                    Me.DataAggiornamento = StringaAbilitazioni.Split("|")(0)
                    Me.Abilitazioni = StringaAbilitazioni.Split("|")(1).Substring(0, 13)
                    Me.AbilitazioniSede = StringaAbilitazioni.Split("|")(1).Substring(14)
                Else
                    'formato non valido
                    Me.Abilitazioni = ""
                End If
            End If

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            Me.Abilitazioni = ""
        End Try
    End Sub

    Public Sub SalvaAbilitazioni()
        Utx.Globale.Log.Info("Salvo abilitazioni")
        Dim wrapper As New Utx.Crypto()
        Try
            Dim StringaAbilitazioni As String = String.Format("{0:dd/MM/yyyy}|{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11}",
                                                              Me.DataAggiornamento,
                                                              CInt(UNITOOLS), -CInt(SMS), -CInt(VISURE), -CInt(SISTEMA), -CInt(QUOTATORE), -CInt(UNIGEST), -CInt(POSTALIZZAZIONE),
                                                              IIf(PATTO_UNIPOL, "S", "N"), IIf(LISTEQT, "S", "N"), IIf(ARCHIVIO_DATI, "S", "N"), IIf(BUSTE, "S", "N"))
            'salvo le abilitazioni
            Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.ABILITAZIONI_AGENZIA, wrapper.EncryptData(StringaAbilitazioni))
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub AbilitazioniDefault()
        UNITOOLS = 0
        SMS = False
        VISURE = False
        SISTEMA = False
        QUOTATORE = False
        UNIGEST = False
        POSTALIZZAZIONE = False
        Me.DataAggiornamento = ""
    End Sub

    Private Sub AbilitazioniSedeDefault()
        PATTO_UNIPOL = False
        LISTEQT = False
        ARCHIVIO_DATI = False
        BUSTE = False
        Me.DataAggiornamento = ""
    End Sub
End Class
