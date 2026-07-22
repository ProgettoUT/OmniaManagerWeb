Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Xml

Public Class Koine

    Friend Shared Log As New Utx.ApplicationLog("Postalizzazione", LogCondiviso:=True, Sovrascrivi:=False)

    Private Shared mAgenzia As String
    Public Shared Property Agenzia() As String
        Get
            Return mAgenzia
        End Get
        Set(value As String)
            mAgenzia = value
        End Set
    End Property

    Public Shared Function Ambiente() As String
        'i valori restituiti dal servizio sono:
        'avvcom = invio da unitools
        'SIA/TTY = invio dai due applicativi
        'avvtest (NON viene restituito dal servizio) viene usato solo per il debug e non invia
        Try
#If DEBUG Then
            Return "avvtest"
#Else
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Return s.AmbientePostalizzazioneEx(Agenzia)
            End Using
#End If
        Catch ex As Exception
            Log.Info(ex)
            Return "avverror"
        End Try
    End Function

    Public Shared Function Ambiente(Agenzia As String) As String
        'i valori restituiti dal servizio sono:
        'avvcom = invio da unitools
        'SIA/TTY = invio dai due applicativi
        'avvtest (NON viene restituito dal servizio) viene usato solo per il debug e non invia
        Try
#If DEBUG Then
            Return "avvtest"
#Else
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Return s.AmbientePostalizzazioneEx(Agenzia)
            End Using
#End If
        Catch ex As Exception
            Log.Info(ex)
            Return "avverror"
        End Try
    End Function

#Region "utilità"
    Private Shared Function AcceptAllCertifications(sender As Object,
                                                    certification As System.Security.Cryptography.X509Certificates.X509Certificate,
                                                    chain As System.Security.Cryptography.X509Certificates.X509Chain,
                                                    sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function
#End Region

    Private Class Json
        'token per sia=B05B539F42E1BA329DC8587A25A4B37E
        'token per tty=P1F51EAF8A45D68CF3DF8DE0C75B48DC

        Private Enum Token
            B05B539F42E1BA329DC8587A25A4B37E 'sia
            P1F51EAF8A45D68CF3DF8DE0C75B48DC 'tty
        End Enum

        Public Class EsitoServizioRest
            Public status As String
            Public warnings As Avviso()
            Public errors As Avviso()
            Public idcampagna As String

            Class Avviso
                Public code As Integer
                Public message As String
            End Class
        End Class

        Private Shared _CredenzialiKoine As String = "guidolampo:guido745"

        Public Shared Function Richiesta(Doc As DocumentoDati) As HttpWebResponse
            Dim request As HttpWebRequest
            Try
#If DEBUG Then
                Dim Endpoint As String = "https://koinecloudws-test.koinesolutions.it/newlot"
#Else
                Dim Endpoint As String = "https://koinecloudws-prod.koinesolutions.it/newlot"
#End If
                request = Net.HttpWebRequest.Create(Endpoint)
                request.Method = WebRequestMethods.Http.Post
                request.ContentType = "application/json"
                request.Headers.Add("Authorization: Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(_CredenzialiKoine)))
                request.Timeout = 30000 '30 secondi

                'creo il body della richiesta (Json.Avvisi(Doc)) e la scrivo nella request
                Using stm As Stream = request.GetRequestStream()
                    Using stmw As New StreamWriter(stm)
                        stmw.Write(Json.Avvisi(Doc))
                    End Using
                End Using
                Return request.GetResponse

            Catch wex As Net.WebException
                Select Case wex.Status
                    Case WebExceptionStatus.ProtocolError
                        MsgBox("Errore nella chiamata al server di postalizzazione.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Case Else
                        MsgBox("Impossibile connettersi ora al server di postalizzazione.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                End Select
                Log.Info($"WebException status: {wex.Status} - {wex.Message}")
                Return request.GetResponse
            Catch ex As Exception
                Log.Errore(ex)
                Return Nothing
            End Try
        End Function

        Public Shared Function Avvisi(doc As DocumentoDati) As String
            Try
                'zippo il file
                Utx.LibreriaZip.ZipFile(doc.FileXml, doc.FileZip)

                'le doppie {{ vengono tradotte in una { come per le virgolette
                Dim Body As String = $"
{{""Identity"": {{}},
""JobCode"": ""{Ambiente()}"",
""LotName"": ""{doc.Lotto}"",
""PostService"": ""pm"",
""FileName"": ""{Path.GetFileName(doc.FileZip)}"",
""FileMD5"": ""{Utx.NetFunc.FileToMD5(doc.FileZip)}"",
""FileContent"": ""{Convert.ToBase64String(File.ReadAllBytes(doc.FileZip))}""}}"

                Soap.StampaDebug(Body, "Avvisi.json")
                Return Body

            Catch ex As Exception
                Log.Errore(ex)
                Return ""
            End Try
        End Function
    End Class

    Private Class Soap

        Private Shared mUserKoine As String = "guidolampo"
        Private Shared mPassworKoine As String = "guido745"

        Private Shared Function SoapEnvelope(Body As String) As String
            Return $"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://webservice.koine.org"">
    <soapenv:Header>
        <wsse:Security xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
            <wsse:UsernameToken>
                <wsse:Username>{mUserKoine}</wsse:Username>
                <wsse:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">{mPassworKoine}</wsse:Password>
            </wsse:UsernameToken>
        </wsse:Security>
    </soapenv:Header>
    {Body}
</soapenv:Envelope>"
        End Function

        Public Shared Function Richiesta(Soap As String) As HttpWebResponse
            Dim req As HttpWebRequest
            Try
                'normalizzo soap
                Soap = Utx.FunzioniHtml.NormalizzaXml(Soap)

                'per i certificati
                ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)

                req = DirectCast(WebRequest.Create("https://ws.sicomunica.it/axis2/services/KoineWebService.KoineWebServiceHttpsSoap11Endpoint"), HttpWebRequest)
                req.Headers.Add("SOAPAction", "http://webservice.koine.org")
                req.ContentType = "text/xml;charset=""utf-8"""
                req.Accept = "text/xml"
                req.Method = "POST"
                req.Proxy = Utx.Globale.UniProxy.Proxy
                req.Timeout = 180000

                'scrivo la richiesta soap nella request
                Using stm As Stream = req.GetRequestStream()
                    Using stmw As New StreamWriter(stm)
                        stmw.Write(Soap)
                    End Using
                End Using
                Return req.GetResponse

            Catch wex As Net.WebException
                Select Case wex.Status
                    Case WebExceptionStatus.ProtocolError
                        MsgBox("Errore nella chiamata al server di postalizzazione.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Case Else
                        MsgBox("Impossibile connettersi ora al server di postalizzazione.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                End Select
                Log.Info($"WebException status: {wex.Status}")
                Log.Info(wex)
                Return req.GetResponse
            Catch ex As Exception
                Log.Errore(ex)
                Return req.GetResponse
            End Try
        End Function

        Public Shared Function xmlConfig() As String
            Dim Body As String = $"
<soapenv:Body>
    <web:ConfigUni>
        {Tag.Identity}
    </web:ConfigUni>
</soapenv:Body>"

            StampaDebug(Body, "Config.xml")
            Return SoapEnvelope(Body)
        End Function

        Public Shared Function XmlConfigUniData() As String
            Dim Body As String = $"
<soapenv:Body>
    <web:ConfigUniData>
        {Tag.IdentityGenerico}
        {Tag.Agenzia}
        {Tag.ElencoCip(mAgenzia)}
        {Tag.ElencoPuntiVendita(mAgenzia)}
        {Tag.ElencoSoggetti(mAgenzia)}
    </web:ConfigUniData>
</soapenv:Body>"

            StampaDebug(Utx.FunzioniHtml.NormalizzaXml(Body), "ConfigUniData.xml")
            Return SoapEnvelope(Body)
        End Function

        Public Shared Function XmlStatoConfig() As String
            Dim Body As String = $"
<soapenv:Body>
    <web:ConfigUniStatus>
        {Tag.Identity}
        {Tag.NumeroAgenzia}
    </web:ConfigUniStatus>
</soapenv:Body>"

            StampaDebug(Body, "StatoConfig.xml")
            Return Soap.SoapEnvelope(Body)
        End Function

        Public Shared Function XmlTracking() As String
            Dim Body As String = $"
<soapenv:Body>
    <web:Tracking>
        {Tag.Identity}
        <Navigation>no</Navigation>
    </web:Tracking>
</soapenv:Body>"

            StampaDebug(Body, "Tracking.xml")
            Return SoapEnvelope(Body)
        End Function

        Public Shared Function XmlInizioPostalizzazione(Optional Agenzia As String = "ALL") As String
            Dim Body As String = $"
<soapenv:Body>
    <web:ConfigUniInizioSped>
        {Tag.Identity}
        <NumeroAgenzia>{Agenzia}</NumeroAgenzia>
    </web:ConfigUniInizioSped>
</soapenv:Body>"

            StampaDebug(Body, "InizioPostalizzazione.xml")
            Return SoapEnvelope(Body)
        End Function

        Private Class Tag
            'classe utilizzata dalla classe koine

            Friend Shared Function UserData() As String
                Return $"
<UserData>
    <LastName>{Utx.Globale.UtenteCorrente.UniageUser}</LastName>
    <FirstName>{Utx.Globale.UtenteCorrente.NomeUtente}</FirstName>
    <Email>unitools@unitools.it</Email>
    <Phone>051.6313108</Phone>
</UserData>"
            End Function

            Friend Shared Function UserKeys() As String
                Return $"
<UserKeys>
    <ClientUserId>{Utx.Globale.UtenteCorrente.UniageUser}_{mAgenzia}</ClientUserId>
    <UserFilter>{mAgenzia}</UserFilter>
    <Role>AgenziaAnagLocale</Role>
</UserKeys>"
            End Function

            Friend Shared Function Agenzia(Optional Abilitazione As Integer = 1) As String
                Utx.Globale.ProfiloEnteGestore.Uniarea.Init()

                Return $"
<Agenzia>
    <CodiceAgenzia>{mAgenzia}</CodiceAgenzia>
    <RagioneSociale>{Utx.Globale.ProfiloEnteGestore.Uniarea.RagioneSociale}</RagioneSociale>
    <Abilitazione>{Abilitazione}</Abilitazione>
</Agenzia>"
            End Function

            Friend Shared Function User() As String
                Return $"
<User>
    {Tag.UserKeys}
    {Tag.UserData()}
</User>"
            End Function

            Friend Shared Function UserGenerico() As String
                Return $"
<User>
    <UserKeys>
        <ClientUserId>0</ClientUserId>
    </UserKeys>
    {Tag.UserData()}
</User>"
            End Function

            Friend Shared Function Identity() As String
                Return $"
<Identity>
    <ClientSystem>unitools</ClientSystem>
    {Tag.User}
</Identity>"
            End Function

            Friend Shared Function IdentityGenerico() As String
                Return $"
<Identity>
    <ClientSystem>unitools</ClientSystem>
    {Tag.UserGenerico}
</Identity>"
            End Function

            Friend Shared Function NumeroAgenzia() As String
                Return $"<NumeroAgenzia>{mAgenzia}</NumeroAgenzia>"
            End Function

            Friend Shared Function ElencoCip(Agenzia As String) As String
                Try
                    Dim Elenco As String = ""
                    For Each dr As DataRow In StrutturaAgenzia.Cip(Agenzia).Rows
                        Elenco &= Cip(dr)
                    Next
                    Return $"
<ElencoCip>
    {Elenco}
</ElencoCip>"
                Catch ex As Exception
                    Log.Errore(ex)
                    Return "<ElencoCip></ElencoCip>"
                End Try
            End Function

            Friend Shared Function Cip(dr As DataRow) As String
                Return $"
<Cip>
    <CodiceCip>{dr("Cip")}</CodiceCip>
    <CodiceRui>{Trim(dr("NumeroRegistro"))}</CodiceRui>
    <PuntoVendita>{dr("PuntoVendita")}</PuntoVendita>
    <CfSoggetto>{Trim(dr("CfSoggetto"))}</CfSoggetto>
    <DataInizio>{dr("DataInizio"):yyyy-MM-dd}</DataInizio>
    <DataFine>{dr("DataFine"):yyyy-MM-dd}</DataFine>
    <IdRuolo>{dr("Ruolo").ToString.Trim}</IdRuolo>
    <DescrizioneRuolo>{dr("DeskRuolo").ToString.Trim}</DescrizioneRuolo>
    <DescrizioneCip>{dr("DeskCip").ToString.Trim}</DescrizioneCip>
</Cip>"
            End Function

            Friend Shared Function ElencoPuntiVendita(Agenzia As String) As String
                Try
                    Dim Elenco As String = ""
                    For Each dr As DataRow In StrutturaAgenzia.PuntiVendita(Agenzia).Rows
                        Elenco &= PuntoVendita(dr)
                    Next
                    Return $"
<ElencoPuntiVendita>
    {Elenco}
</ElencoPuntiVendita>"

                Catch ex As Exception
                    Log.Errore(ex)
                    Return "<ElencoPuntiVendita></ElencoPuntiVendita>"
                End Try
            End Function

            Friend Shared Function PuntoVendita(dr As DataRow) As String
                Dim EmailNotifiche As String = ""
                If PuntoVenditaPrincipale(dr) = True Then
                    EmailNotifiche = Postalizzazione.SettingPostalizzazione.LeggiValore(Utx.GestioneFlag.TipoFlag.POSTALIZZAZIONE_NOTIFICHE)
                End If

                Return $"
<PuntoVendita>
    <DeskPuntoVendita>{Trim(dr("DeskPuntoVendita"))}</DeskPuntoVendita>
    <PuntoVenditaAgenzia>{dr("PuntoVenditaAgenzia")}</PuntoVenditaAgenzia>
    <PuntoVenditaLivello2>{dr("PuntoVenditaLivello2")}</PuntoVenditaLivello2>
    <PuntoVenditaLivello3>{dr("PuntoVenditaLivello3")}</PuntoVenditaLivello3>
    <Indirizzo>{Trim(dr("Indirizzo"))}</Indirizzo>
    <CAP>{dr("CAP")}</CAP>
    <Localita>{Trim(dr("Localita"))}</Localita>
    <Prov>{Trim(dr("Provincia"))}</Prov>
    <Telefono>{Trim(dr("Telefono1"))}</Telefono>
    <Telefono3>{Trim(dr("Telefono3"))}</Telefono3>
    <Fax>{Trim(dr("Fax"))}</Fax>
    <Email>{Trim(dr("Email"))}</Email>
    <Email2>{Trim(dr("Email2"))}</Email2>
    <Email3>{EmailNotifiche}</Email3>
    <Pec>{Trim(dr("PEC"))}</Pec>
</PuntoVendita>"
            End Function

            Friend Shared Function PuntoVenditaPrincipale(dr As DataRow) As Boolean
                Return (dr("PuntoVenditaAgenzia") = dr("PuntoVenditaLivello2")) AndAlso (dr("PuntoVenditaAgenzia") = dr("PuntoVenditaLivello3"))
            End Function

            Friend Shared Function ElencoSoggetti(Agenzia As String) As String
                Try
                    Dim Elenco As String = ""
                    For Each dr As DataRow In StrutturaAgenzia.Soggetti(Agenzia).Rows
                        Elenco &= Soggetto(dr)
                    Next
                    Return $"
<ElencoSoggetti>
    {Elenco}
</ElencoSoggetti>"
                Catch ex As Exception
                    Log.Errore(ex)
                    Return "<ElencoSoggetti></ElencoSoggetti>"
                End Try
            End Function

            Friend Shared Function Soggetto(dr As DataRow) As String
                Return $"
<Soggetto>
    <NomeSoggetto>{Trim(dr("NomeSoggetto"))}</NomeSoggetto>
    <CognomeSoggetto>{Trim(dr("CognomeSoggetto"))}</CognomeSoggetto>
    <CfSoggetto>{Trim(dr("CfSoggetto"))}</CfSoggetto>
    <Telefono1>{Trim(dr("Telefono1"))}</Telefono1>
    <Telefono2>{Trim(dr("Telefono2"))}</Telefono2>
    <Email>{Trim(dr("Email"))}</Email>
</Soggetto>"
            End Function
        End Class

        Friend Shared Sub StampaDebug(Testo As String,
                                      NomeFile As String,
                                      Optional LivelloLog As Utx.ApplicationLog.Livello = Utx.ApplicationLog.Livello.DEBUG)
            Try
#If DEBUG Then
                'così in debug mi stampa sempre
                LivelloLog = Utx.ApplicationLog.Livello.INFO
#End If
                If Utx.ApplicationLog.LivelloLog <= LivelloLog Then
                    File.WriteAllText(Path.Combine(Utx.Globale.Paths.CartellaTempUtente, NomeFile), Testo)
                End If
            Catch ex As Exception
                Log.Info(ex.Message)
            End Try
        End Sub
    End Class

    Public Class Servizi

        Private Shared mLinkConfig As String = ""
        Public Shared ReadOnly Property LinkConfig() As String
            Get
                Return GetLinkConfig()
            End Get
        End Property

        Private Shared mLinkTracking As String = ""
        Public Shared ReadOnly Property LinkTracking() As String
            Get
                Return GetLinkTracking.Replace("https://", "http://")
            End Get
        End Property

        Public Shared ReadOnly Property InizioPostalizzazione(Optional Agenzia As String = "ALL") As DataTable
            Get
                Return GetInizioPostalizzazione(Agenzia)
            End Get
        End Property

        Public Shared ReadOnly Property ConsensoProssimaPostalizzazione(Agenzia As String) As Boolean
            Get
                Try
                    Dim dt As DataTable = GetInizioPostalizzazione(Agenzia)
                    If dt IsNot Nothing Then
                        Return (Utx.FunzioniData.InizioMese(dt.Rows(0)("Inizio")) <= Utx.FunzioniData.InizioMese(Avvisi.InizioPeriodo))
                    Else
                        Return False
                    End If
                Catch ex As Exception
                    Log.Info(ex.Message)
                    Return False
                End Try
            End Get
        End Property

        Private Shared Function GetLinkConfig() As String
            Try
                Dim response As HttpWebResponse = Soap.Richiesta(Soap.xmlConfig)

                If response IsNot Nothing Then
                    Dim Risposta As New RispostaKoine(response)
                    Risposta.Salva()

                    If Risposta.Stato = RispostaKoine.TipoStato.OK Then
                        Return Risposta.ConfigLink
                    Else
                        Log.Info($"Errore {Risposta.CodiceErrore}: {Risposta.Errore}")
                        Return ""
                    End If
                End If
                Return ""

            Catch ex As Exception
                Log.Info(ex)
                Return ""
            End Try
        End Function

        Private Shared Function GetLinkTracking() As String
            Try
                Dim response As HttpWebResponse = Soap.Richiesta(Soap.XmlTracking)

                If response IsNot Nothing Then
                    Dim Risposta As New RispostaKoine(response)
                    Risposta.Salva()

                    If Risposta.Stato = RispostaKoine.TipoStato.OK Then
                        Return Risposta.TrackingLink
                    Else
                        Log.Info($"Errore {Risposta.CodiceErrore}: {Risposta.Errore}")
                    End If
                End If
                Return ""

            Catch ex As Exception
                Log.Info(ex)
                Return ""
            End Try
        End Function

        Private Shared Function GetInizioPostalizzazione(Optional Agenzia As String = "ALL") As DataTable
            Try
                Dim response As HttpWebResponse = Soap.Richiesta(Soap.XmlInizioPostalizzazione(Agenzia))

                If response IsNot Nothing Then
                    Dim Risposta As New RispostaKoine(response)
                    Risposta.Salva()

                    Select Case Risposta.Stato
                        Case RispostaKoine.TipoStato.OK
                            Return Risposta.InizioPostalizzazione

                        Case RispostaKoine.TipoStato.KO
                            Log.Info($"Risposta koinè: {Risposta.Stato}")

                            If Risposta.CodiceErrore IsNot Nothing Then
                                Log.Info($"Errore {Risposta.CodiceErrore}: {Risposta.Errore}")
                            End If
                            Return Nothing

                        Case Else
                            Log.Info($"Risposta koinè: {RispostaKoine.TipoStato.NESSUNA_RISPOSTA}")
                            Return Nothing
                    End Select
                Else
                    Return Nothing
                End If

            Catch ex As Exception
                Log.Info(ex)
                Return Nothing
            End Try
        End Function

        Public Shared Function StatoConfig() As String
            Try
                Dim response As WebResponse = Soap.Richiesta(Soap.XmlStatoConfig())

                If response IsNot Nothing Then
                    Dim Risposta As New RispostaKoine(response)
                    Risposta.Salva()

                    If Risposta.Stato = RispostaKoine.TipoStato.OK Then
                        Return Risposta.TestoStato
                    Else
                        Log.Info($"Errore {Risposta.CodiceErrore}: {Risposta.Errore}")
                        Return RispostaKoine.MessaggioStato.none.ToString
                    End If
                Else
                    Return RispostaKoine.MessaggioStato.none.ToString
                End If

            Catch ex As Exception
                Log.Info(ex)
                Return RispostaKoine.MessaggioStato.none.ToString
            End Try
        End Function

        Public Shared Function InviaStrutturaAgenzia() As String
            Try
#If DEBUG Then
                If MsgBox("DEBUG: inviare la struttura dell'agenzia?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question) = MsgBoxResult.No Then
                    Return "OK"
                End If
#End If
                Dim response As WebResponse = Soap.Richiesta(Soap.XmlConfigUniData())

                If response IsNot Nothing Then
                    Dim Risposta As New RispostaKoine(response)
                    Risposta.Salva()

                    If Risposta.Stato = RispostaKoine.TipoStato.OK Then
                        Return Risposta.TestoStato
                    Else
                        Log.Info($"Errore {Risposta.CodiceErrore}: {Risposta.Errore}")
                        Return $"Errore {Risposta.CodiceErrore}: {Risposta.Errore}"
                    End If
                Else
                    Return "Nessuna risposta dal server"
                End If
            Catch ex As Exception
                Log.Errore(ex)
                Return ex.Message
            End Try
        End Function
    End Class

    Public Class RispostaKoine

        Public Enum TipoStato
            NESSUNA_RISPOSTA
            OK
            KO
        End Enum
        Public Enum MessaggioStato
            none
            complete
            incomplete
            notpresent
            disabled
        End Enum

        Private mRisposta As XmlDocument

        Sub New(response As HttpWebResponse)
            Try
                Dim Xml As String
                Dim responseStream As Stream = response.GetResponseStream()
                Using reader As New StreamReader(responseStream, Encoding.UTF8)
                    Xml = reader.ReadToEnd()
                End Using

                If Xml.IndexOf("<?") > 0 Then
                    Xml = Xml.Remove(0, Xml.IndexOf("<?"))
                End If
                If Xml.LastIndexOf(">") < Xml.Length - 1 Then
                    Xml = Xml.Remove(Xml.LastIndexOf(">") + 1, Xml.Length - Xml.LastIndexOf(">") - 1)
                End If

                mRisposta = New XmlDocument
                mRisposta.LoadXml(Xml)

            Catch ex As Exception
                Log.Errore(ex)
            End Try
        End Sub

        Public ReadOnly Property Stato() As TipoStato
            Get
                If mRisposta.SelectSingleNode("//return/status") IsNot Nothing Then
                    Select Case mRisposta.SelectSingleNode("//return/status").InnerText
                        Case TipoStato.OK.ToString
                            Return TipoStato.OK
                        Case TipoStato.KO.ToString
                            Return TipoStato.KO
                        Case Else
                            Return TipoStato.NESSUNA_RISPOSTA
                    End Select
                Else
                    Return TipoStato.NESSUNA_RISPOSTA
                End If
            End Get
        End Property

        Public ReadOnly Property TestoStato() As String
            Get
                If mRisposta.SelectSingleNode("//return/statusConfigAvvisi") IsNot Nothing Then
                    Return mRisposta.SelectSingleNode("//return/statusConfigAvvisi").InnerText
                Else
                    Return Me.Stato.ToString
                End If
            End Get
        End Property

        Public ReadOnly Property ConfigLink() As String
            Get
                If mRisposta.SelectSingleNode("//return/configUniLink") IsNot Nothing Then
                    Return mRisposta.SelectSingleNode("//return/configUniLink").InnerText
                Else
                    Return ""
                End If
            End Get
        End Property

        Public ReadOnly Property TrackingLink() As String
            Get
                If mRisposta.SelectSingleNode("//return/trackingLink") IsNot Nothing Then
                    Return mRisposta.SelectSingleNode("//return/trackingLink").InnerText
                Else
                    Return ""
                End If
            End Get
        End Property

        Public ReadOnly Property InizioPostalizzazione() As DataTable
            Get
                Dim dt As New DataTable
                With dt.Columns
                    .Add("Agenzia", Type.GetType("System.String"))
                    .Add("Localita", Type.GetType("System.String"))
                    .Add("Inizio", Type.GetType("System.DateTime"))
                End With
                For Each n As XmlNode In mRisposta.SelectNodes("//return/date")

                    Dim dr As DataRow = dt.NewRow
                    dr("Agenzia") = n.Item("codiceAgenzia").InnerText
                    dr("Localita") = n.Item("localita").InnerText

                    If IsDate(n.Item("data").InnerText) Then
                        dr("Inizio") = CDate(n.Item("data").InnerText).ToShortDateString
                    Else
                        dr("Inizio") = DBNull.Value
                    End If
                    dt.Rows.Add(dr)
                Next
                Return dt
            End Get
        End Property

        Public ReadOnly Property Campagna() As String
            Get
                Try
                    If mRisposta.SelectSingleNode("//return/idcampagna") IsNot Nothing Then
                        Return mRisposta.SelectSingleNode("//return/idcampagna").InnerText
                    Else
                        Return ""
                    End If
                Catch ex As Exception
                    Return ""
                End Try
            End Get
        End Property

        Public ReadOnly Property CodiceErrore() As String
            Get
                Try
                    Return mRisposta.SelectSingleNode("//return/errors/code").InnerText
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
        End Property

        Public ReadOnly Property Errore() As String
            Get
                Try
                    Return mRisposta.SelectSingleNode("//return/errors/message").InnerText
                Catch ex As Exception
                    Return "ND"
                End Try
            End Get
        End Property

        Public Sub Salva()
            'in produzione salva la risposta con livello log TRACE/DEBUG 
            If Utx.ApplicationLog.LivelloLog <= Utx.ApplicationLog.Livello.DEBUG Then
                Dim PathFileXml As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "RispostaKoine.xml")
                Dim PathFileTxt As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "RispostaKoine.txt")
                File.Delete(PathFileXml)
                File.Delete(PathFileTxt)
                mRisposta.Save(PathFileXml)
                File.AppendAllText(PathFileTxt, mRisposta.InnerXml)
            Else
#If DEBUG Then
                Dim PathFileXml As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "RispostaKoine.xml")
                Dim PathFileTxt As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "RispostaKoine.txt")
                File.Delete(PathFileXml)
                File.Delete(PathFileTxt)
                mRisposta.Save(PathFileXml)
                File.AppendAllText(PathFileTxt, mRisposta.InnerXml)
#End If
            End If
        End Sub
    End Class

    Public Class StrutturaAgenzia

        Public Shared Function Cip(Agenzia As String) As DataTable
            Try
                Dim Query As String = "SELECT Cip,NumeroRegistro,PuntoVendita,CfSoggetto,DataInizio,DataFine,Ruolo,DeskRuolo,DeskCip 
                    FROM Cip 
                    WHERE Selezionato = CAST(1 AS bit)
                        AND Cip > 0
                        AND DataFine IS NULL"

                Return Utx.WsCommand.ExecuteNonQuery(Query, Agenzia).DataTable

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
                Return Nothing
            End Try
        End Function

        Public Shared Function Soggetti(Agenzia As String) As DataTable
            Try
                Dim Query As String = "SELECT CognomeSoggetto,NomeSoggetto,CfSoggetto,Telefono1,Telefono2,Email 
                    FROM Soggetti 
                    WHERE (Selezionato = CAST(1 AS bit))
                        AND ((FineMandato Is NULL) OR (FineMandato > '01/04/2018')) 
                    UNION 
                    SELECT DISTINCT A.CognomeSoggetto,A.NomeSoggetto,A.CfSoggetto,'' AS Telefono1,'' AS Telefono2,'' AS Email 
                    FROM Cip AS A 
                    LEFT JOIN (SELECT CfSoggetto 
                        FROM Soggetti 
                        WHERE (Selezionato = CAST(1 AS bit)) 
                            AND ((FineMandato Is NULL) OR (FineMandato > '01/04/2018'))) AS B 
                    ON A.CfSoggetto = B.CfSoggetto 
                    WHERE B.CfSoggetto IS NULL 
                        AND ((A.DataFine IS NULL) OR (A.DataFine > '01/04/2018'))
                    ORDER BY CfSoggetto"

                Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query, Agenzia).DataTable

                '+elimino eventuali CfSoggetto doppi
                Dim CFPrec As String = ""
                For k As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(k).Item("CfSoggetto") = CFPrec Then
                        dt.Rows(k).Delete()
                    Else
                        CFPrec = dt.Rows(k).Item("CfSoggetto")
                    End If
                Next
                dt.AcceptChanges()
                Return dt

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
                Return Nothing
            End Try
        End Function

        Public Shared Function PuntiVendita(Agenzia As String) As DataTable
            Try
                'per avere i dati di Uniarea
                Utx.Globale.ProfiloEnteGestore.Uniarea.Init()

                Dim Query As String = $"SELECT DeskPuntoVendita,PuntoVenditaAgenzia,PuntoVenditaLivello2,PuntoVenditaLivello3,Indirizzo,
                        CAP,Localita,Provincia,Telefono1,Telefono3,Fax,'' AS Email,'' AS Email2,'' AS PEC 
                    FROM Punti_Vendita 
                    WHERE (CAST(Selezionato as bit) = 1) 
                        AND (NOT TRIM(DeskPuntoVendita) IS NULL) AND (LEN(DeskPuntoVendita) > 0) 
                        AND (NOT PuntoVenditaAgenzia IS NULL) AND (PuntoVenditaAgenzia > 0) 
                        AND (NOT PuntoVenditaLivello2 IS NULL) AND (PuntoVenditaLivello2 > 0) 
                        AND (NOT PuntoVenditaLivello3 IS NULL) AND (PuntoVenditaLivello3 > 0) 
                        AND ((DataFine IS NULL) OR (DataFine > '01/04/2018'))"

                Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query, Agenzia).DataTable
                'modifico i dati del punto agenzia con i dati provenienti da Uniarea. i dati del punto agenzia NON sono nella tabella punti_vendita
                For Each row As DataRow In dt.Rows
                    If (row("PuntoVenditaAgenzia") = row("PuntoVenditaLivello2")) AndAlso (row("PuntoVenditaLivello2") = row("PuntoVenditaLivello3")) Then
                        With Utx.Globale.ProfiloEnteGestore.Uniarea
                            row("Indirizzo") = .Indirizzo
                            row("CAP") = .Cap
                            row("Localita") = .Localita
                            row("Provincia") = .Provincia
                            row("Telefono1") = .Telefono
                            row("Fax") = .Fax
                            row("Email") = .Email
                            row("Email2") = .Email2
                            row("PEC") = .PEC
                        End With
                    End If
                Next
                Return dt

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
                Return Nothing
            End Try
        End Function
    End Class

#Region "avvisi"

    Friend Shared Quietanzamento As New List(Of Quietanza)
    Friend Shared Clienti As New List(Of Cliente)
    Friend Shared ItemScartati As New List(Of Scartati)

    Public Class Avvisi

        Public Event InvioConcluso()

        Sub New()
            mAgenzia = Koine.Agenzia
            'mInizioPeriodo = Avvisi.InizioPeriodo
            'mFinePeriodo = Avvisi.FinePeriodo

            'azzero le liste
            Clienti.Clear()
            Quietanzamento.Clear()
            ItemScartati.Clear()

            LeggiAvvisi()
        End Sub

        Private mAgenzia As String
        Public ReadOnly Property Agenzia() As String
            Get
                Return mAgenzia
            End Get
        End Property

        Public Shared ReadOnly Property InizioPeriodo() As Date
            Get
                Return Utx.FunzioniData.InizioMese(Postalizzazione.InizioAutoPostalizzazione.AddMonths(1))
            End Get
        End Property

        Public Shared ReadOnly Property FinePeriodo() As Date
            Get
                Return Utx.FunzioniData.FineMese(Postalizzazione.InizioAutoPostalizzazione.AddMonths(1))
            End Get
        End Property

        Private mDatiAvvisi As DataTable
        Public Property DatiAvvisi() As DataTable
            Get
                Return mDatiAvvisi
            End Get
            Set(value As DataTable)
                mDatiAvvisi = value
            End Set
        End Property

        Private mDatiClienti As DataTable
        Public ReadOnly Property DatiClienti() As DataTable
            Get
                Return mDatiAvvisi
            End Get
        End Property

        Public Sub LeggiAvvisi()
            Try
                Using s As New Utx.DatabaseOMW.Database
                    s.Proxy = Utx.Globale.UniProxy.Proxy
                    If s.CreaTabella(mAgenzia, "Postalizzazione", Utx.Globale.Token) = True Then
                        'marco gli esclusi per condizioni generali impostate
                        Dim Query As String = $"DECLARE @inizio AS date = '{InizioPeriodo:dd/MM/yyyy}', @fine AS date = '{FinePeriodo:dd/MM/yyyy}'
                            UPDATE Postalizzazione 
                            SET Selezionato = CAST(0 AS bit) 
                            WHERE NOT ((EffettoTitolo BETWEEN @inizio AND @fine) AND 
                                ((TipoCarico IN ('2','3','4')) OR (TipoCarico = '5' AND TotaleTitolo >= 500)) AND 
                                (NOT Frazionamento IN (8,9) OR (Frazionamento = 9 AND RataIntermedia = 'N')) AND
                                (TotaleTitolo > 0 OR ImportoQuota > 0))

                            SELECT Selezionato,SenzaPremio,Agenzia,SubAgenzia,Ramo,Polizza,Contraente,EffettoTitolo,ScadenzaPolizza,TipoCarico,
                                TotaleTitolo,Frazionamento,RataIntermedia,Targa,Prodotto,Convenzione,RamoGestione,Sesso,
                                UPPER(TRIM(A.CodiceFiscale)) AS CodiceFiscale,RID,Quota,Delegataria,ImportoQuota,B.Privacy 
                            FROM Postalizzazione AS A 
                            LEFT JOIN (SELECT DISTINCT CodiceFiscale,ConsensoPrivacy AS Privacy FROM Clienti) AS B 
                            ON A.CodiceFiscale = B.CodiceFiscale 
                            WHERE ((EffettoTitolo BETWEEN @inizio AND @fine) AND 
                                ((TipoCarico IN ('2','3','4')) OR (TipoCarico = '5' AND TotaleTitolo >= 500)) AND 
                                (NOT Frazionamento IN (8,9) OR (Frazionamento = 9 AND RataIntermedia = 'N')) AND
                                (TotaleTitolo > 0 OR ImportoQuota > 0)) 
                            ORDER BY Contraente,Ramo,Polizza"

                        mDatiAvvisi = Utx.WsCommand.ExecuteNonQuery(Query, mAgenzia).DataTable
                    End If
                End Using

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try
        End Sub

        Public Sub VerificaClienti()
            Try
                'creo la lista dei clienti che sono negli arretrati ma non nell'anagrafica
                Dim Query As String = "SELECT A.CodiceFiscale 
                    FROM (SELECT DISTINCT CodiceFiscale FROM Postalizzazione WHERE Selezionato = CAST(1 AS bit)) AS A 
                    LEFT JOIN Clienti AS B 
                    ON A.codicefiscale = B.codicefiscale 
                    WHERE B.CodiceFiscale IS NULL"

                Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query, mAgenzia).DataTable

                'se non trovo l'assicurato lo catturo da essig
                For Each row As DataRow In dt.Rows
                    Utx.Essig.LeggiDatiCliente(row("CodiceFiscale"), mAgenzia)
                Next
                Utx.Globale.Log.Info("Verificati da essig {0} clienti del codice {1}", {dt.Rows.Count, mAgenzia})

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try
        End Sub

        Public Sub LeggiClienti()
            Try
                Dim Query As String = $"SELECT C.CodiceFiscale,Indirizzo,Cap,Localita,Provincia,Sesso,DataNascita,
                    ISNULL(COALESCE(Cellulare,RisCellulare,TelNumero2,TelNumero4),'') AS Telefono,
                    ISNULL(COALESCE(Email,RisMail,EmailIndirizzo1,EmailIndirizzo2),'') AS Email,
                    AgenziaPrevalente,SubAgenzia 
                    FROM Clienti AS C 
                    LEFT JOIN (SELECT CodiceFiscale,TelNumero2,TelNumero4,EmailIndirizzo1,EmailIndirizzo2 
                                FROM Ana_soggetto) AS A 
                        ON C.CodiceFiscale = A.CodiceFiscale
                    INNER JOIN (SELECT DISTINCT CodiceFiscale 
                                FROM Postalizzazione 
                                WHERE EffettoTitolo BETWEEN '{InizioPeriodo:dd/MM/yyyy}' AND '{FinePeriodo:dd/MM/yyyy}') AS B 
                        ON C.CodiceFiscale = B.CodiceFiscale"

                mDatiClienti = Utx.WsCommand.ExecuteNonQuery(Query, mAgenzia).DataTable

                For Each row As DataRow In mDatiClienti.Rows
                    row("CodiceFiscale") = row("CodiceFiscale").ToString.Trim.ToUpper
                Next
                'sostituisco con gli indirizzi della nuova anag
                If CBool(Postalizzazione.SettingPostalizzazione.LeggiValore(Utx.GestioneFlag.TipoFlag.POSTALIZZAZIONE_DOMICILIO, "True")) = True Then
                    LeggiClienti1()
                End If

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try
        End Sub

        Public Sub LeggiClienti1()
            Try
                Dim Query As String = $"SELECT A.CodiceFiscale,ToponimoDomicilio,IndirizzoDomicilio,NumCivicoDomicilio,CapDomicilio,
                    LocalitaDomicilio,ProvinciaDomicilio,IndirizzoDomicilioBreve,LocalitaDomicilioBreve 
                    FROM Clienti1 AS A 
                    INNER JOIN (SELECT DISTINCT CodiceFiscale 
                                FROM Postalizzazione 
                                WHERE EffettoTitolo BETWEEN '{InizioPeriodo:dd/MM/yyyy}' AND '{FinePeriodo:dd/MM/yyyy}') AS B 
                        ON A.CodiceFiscale = B.CodiceFiscale 
                    WHERE CAST(A.CapDomicilio AS int) > 0"

                Dim Clienti1 As DataTable = Utx.WsCommand.ExecuteNonQuery(Query, mAgenzia).DataTable

                'trimmo i CF
                For Each row As DataRow In Clienti1.Rows
                    row("CodiceFiscale") = row("CodiceFiscale").ToString.Trim.ToUpper
                Next

                Clienti1.PrimaryKey = {Clienti1.Columns("CodiceFiscale")}

                Dim Progressivo As Integer = 0

                For Each row As DataRow In mDatiClienti.Rows
                    Dim row1 As DataRow = Clienti1.Rows.Find(row("CodiceFiscale"))
                    'se trovo il cliente nella nuova anagrafica
                    If row1 IsNot Nothing Then
                        Dim NuovoIndirizzo As String, NuovaLocalita As String
                        'indirizzo
                        If row1("ToponimoDomicilio").ToString.EndsWith("'") Then
                            NuovoIndirizzo = $"{row1("ToponimoDomicilio")}{row1("IndirizzoDomicilio")} {row1("NumCivicoDomicilio")}"
                        Else
                            NuovoIndirizzo = $"{row1("ToponimoDomicilio")} {row1("IndirizzoDomicilio")} {row1("NumCivicoDomicilio")}"
                        End If
                        'controllo lunghezza indirizzo max 40 car
                        If NuovoIndirizzo.Length > 40 Then
                            NuovoIndirizzo = row1("IndirizzoDomicilioBreve")
                        End If
                        'località
                        NuovaLocalita = row1("LocalitaDomicilio")
                        If NuovaLocalita.Length > 40 Then
                            NuovaLocalita = row1("LocalitaDomicilioBreve")
                        End If
                        'sostituisco
                        row("Indirizzo") = NuovoIndirizzo
                        row("Cap") = row1("CapDomicilio")
                        row("Localita") = NuovaLocalita
                        row("Provincia") = row1("ProvinciaDomicilio")
                    Else
                        Progressivo += 1
                        Utx.Globale.Log.Info("{0}) codice fiscale '{1}' non trovato nella nuova anagrafica", {Progressivo, row("CodiceFiscale")})
                    End If
                Next

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try
        End Sub

        Public Function LeggiCliente(CodiceFiscale As String) As DataRow
            Try
                Dim Query As String = $"SELECT C.Cognome,C.Nome,Indirizzo,Cap,Localita,Provincia,C.Sesso,C.DataNascita,Email,
                    C.Cellulare,RisCellulare,RisMail,TelNumero2,TelNumero4,EmailIndirizzo1,EmailIndirizzo2,AgenziaPrevalente,SubAgenzia,
                    B.ToponimoDomicilio,B.IndirizzoDomicilio,B.NumCivicoDomicilio,B.CapDomicilio,B.LocalitaDomicilio,B.ProvinciaDomicilio 
                    FROM Clienti AS C 
                    INNER JOIN (SELECT DISTINCT CodiceFiscale 
                                FROM Postalizzazione) AS D 
                        ON C.CodiceFiscale = D.CodiceFiscale
                    LEFT JOIN (SELECT CodiceFiscale,TelNumero2,TelNumero4,EmailIndirizzo1,EmailIndirizzo2 
                                FROM Ana_soggetto) AS A 
                        ON C.CodiceFiscale = A.CodiceFiscale
                    LEFT JOIN Clienti1 AS B 
                        ON C.CodiceFiscale = B.CodiceFiscale 
                    WHERE C.CodiceFiscale = '{CodiceFiscale}'"

                Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query, mAgenzia).DataTable

                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)
                Else
                    Return Nothing
                End If

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
                Return Nothing
            End Try
        End Function

        Public Function Invia(Modo As Postalizzazione.Modalita) As Boolean
            Dim Notifica As New Utx.FormNotifica
            Dim Esito As Boolean = False
            Using Server As New Utx.SettingAgenzia.ConfiguraSede
                Try
                    If UniCom.Koine.Servizi.ConsensoProssimaPostalizzazione(Agenzia) = False Then
                        Utx.Globale.Log.Info($"{Agenzia}: Data inizio spedizione non raggiunta. Operazione annullata.")
                        MsgBox($"{Agenzia}: Data inizio spedizione non raggiunta. Operazione annullata.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                        Exit Function
                    End If
                    Log.Info($"Elaborazione postalizzazione del {InizioPeriodo:MM-yyyy}")

                    With Notifica
                        .ColoreSfondo = Drawing.Color.WhiteSmoke
                        .ColoreBordo = Utx.AppColor.RossoScuro
                        .LabelMessaggio.Font = Utx.AppFont.Bold
                        .Opacity = 1
                        .Text = ""
                        .Show()

                        .Messaggio = $"Postalizzazione {Agenzia}{Environment.NewLine}elaborazione periodo {InizioPeriodo:MM-yyyy}{Environment.NewLine}{Environment.NewLine}Attendere..."
                    End With

                    If PreparaDati() = False Then
                        Esito = False
                        Exit Try
                    End If

                    'se ci sono destinatari
                    If Clienti.Count > 0 Then
                        'creo il documento da inviare
                        Dim doc As New DocumentoDati(InizioPeriodo)

                        'log dati documento
                        Log.Info("Documento da inviare:")
                        Log.Info($"Clienti: {doc.Destinatari} - Titoli: {doc.Titoli} - Comunicazioni: {doc.Comunicazioni}")
#If DEBUG Then
                        'in debug blocco l'invio
                        Notifica.Messaggio = "DEBUG - NO invio"
                        Exit Try
#End If
                        Notifica.Messaggio = $"Postalizzazione {Agenzia}{Environment.NewLine}invio dati periodo {InizioPeriodo:MM-yyyy}{Environment.NewLine}{Environment.NewLine}Attendere..."

                        Dim response As HttpWebResponse = Json.Richiesta(doc)

                        'analizzo la risposta
                        If response IsNot Nothing Then
                            Dim Reader As New StreamReader(response.GetResponseStream())
                            Dim EsitoRest As Json.EsitoServizioRest = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Json.EsitoServizioRest)(Reader.ReadToEnd)

                            If EsitoRest.status = RispostaKoine.TipoStato.OK.ToString Then
                                doc.IdCampagna = EsitoRest.idcampagna

                                Try
                                    'registro invio sul server AUA
                                    Dim CodiciAbilitati As New Utx.SettingItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                                                                           Utx.SettingItem.Chiavi.COMUNICATORE_CODICI_ABILITATI,
                                                                           Utx.SettingOMW.TipoOperazione.LETTURA)

                                    Dim Codici As String = "00000"
                                    If CodiciAbilitati.ItemResult.Esiste AndAlso String.IsNullOrEmpty(CodiciAbilitati.ItemResult.Valore) = False Then
                                        Codici = CodiciAbilitati.ItemResult.Valore
                                    End If

                                    Dim EsitoServer As String = Server.DatiPostalizzazione(Ambiente,
                                                                                       Modo.ToString,
                                                                                       Agenzia,
                                                                                       Utx.Globale.ProfiloEnteGestore.CodiceSede,
                                                                                       Left(Utx.Globale.ProfiloEnteGestore.Localita, 50),
                                                                                       Environment.MachineName,
                                                                                       Utx.Globale.UtenteCorrente.UniageUser,
                                                                                       Koine.Avvisi.InizioPeriodo.Month,
                                                                                       Koine.Avvisi.InizioPeriodo.Year,
                                                                                       Now,
                                                                                       doc.Lotto,
                                                                                       doc.IdCampagna,
                                                                                       doc.Destinatari,
                                                                                       doc.Titoli,
                                                                                       doc.Comunicazioni,
                                                                                       Codici)
                                    If EsitoServer.StartsWith("-ERR") Then
                                        Log.Info(EsitoServer.Split("|")(1))
                                    End If
                                Catch exx As Exception
                                    Log.Info(exx)
                                End Try

                                Try
                                    doc.ArchiviaFile() 'archivio il file nella cartella su M:
                                Catch ex As Exception
                                    'non fare niente, il file può essere recuperato da koinè
                                End Try

                                RegistraInvio(doc) 'registrazione sul db dell'agenzia
                                BackupTabellaPostalizzazione()

                                Log.Info($"Invio avvisi {mAgenzia} del {InizioPeriodo:MM-yyyy} completato")
                                Notifica.Messaggio = $"Postalizzazione {Agenzia}{Environment.NewLine}invio dati periodo {InizioPeriodo:MM-yyyy}{StrDup(2, Environment.NewLine)}COMPLETATO"
                                Esito = True
                                'invio la mail di notifica
                                InviaEmailNotifica()
                                'invia mail per errori in indirizzo
                                If String.IsNullOrEmpty(doc.ErroreIndirizzo) = False Then
                                    InviaEmailErroriIndirizzo(doc)
                                End If
                            Else
                                Server.RegistraErrorePostalizzazione(mAgenzia, EsitoRest.errors(0).message)
                                Log.Info($"Invio avvisi non completato. Errore: {EsitoRest.errors(0).message}")
                                Notifica.Messaggio = $"Postalizzazione {Agenzia}{Environment.NewLine}Errore: {EsitoRest.errors(0).message}{StrDup(2, Environment.NewLine)}NON COMPLETATO"
                                Notifica.ColoreSfondo = Color.Salmon
                                Notifica.ColoreTesto = Color.Black
                                InviaEmailErrore(EsitoRest.errors(0).message)
                            End If
                        Else
                            Server.RegistraErrorePostalizzazione(mAgenzia, "Invio avvisi non completato per errori di connessione")
                            Log.Info("Invio avvisi non completato per errori di connessione")
                            Notifica.Messaggio = $"Postalizzazione {Agenzia}{Environment.NewLine}Errori di connessione{StrDup(2, Environment.NewLine)}NON COMPLETATO"
                            Notifica.ColoreSfondo = Color.Salmon
                            Notifica.ColoreTesto = Color.Black
                            InviaEmailErrore("nessuna risposta dal servizio koine'")
                        End If
                        'cancello i file temporanei
                        File.Delete(doc.FileXml)
                        File.Delete(doc.FileZip)
                    Else
                        'inserisco un record vuoto che mi serve per controllo dal pannello
                        Server.DatiPostalizzazione(Ambiente,
                                               Modo.ToString,
                                               Agenzia,
                                               Utx.Globale.ProfiloEnteGestore.CodiceSede,
                                               Left(Utx.Globale.ProfiloEnteGestore.Localita, 50),
                                               Environment.MachineName,
                                               Utx.Globale.UtenteCorrente.UniageUser,
                                               Koine.Avvisi.InizioPeriodo.Month,
                                               Koine.Avvisi.InizioPeriodo.Year,
                                               Now,
                                               Postalizzazione.IdLotto(mAgenzia),
                                               "ND", 0, 0, 0, "")
                        Log.Info("Non ci sono clienti/scadenze da inviare.")
                        Notifica.Messaggio = $"Postalizzazione {Agenzia}{Environment.NewLine}Non ci sono scadenze da inviare{StrDup(2, Environment.NewLine)}COMPLETATO"
                        Notifica.ColoreSfondo = Color.PaleGreen
                        Notifica.ColoreTesto = Color.Black
                    End If

                Catch ex As Exception
                    Server.RegistraErrorePostalizzazione(mAgenzia, ex.Message)
                    Log.Info($"Invio avvisi NON COMPLETATO. Errore {ex.Message}")
                    Notifica.Messaggio = $"Postalizzazione {Agenzia}{Environment.NewLine}Errore: {ex.Message}{StrDup(2, Environment.NewLine)}NON COMPLETATO"
                    Notifica.ColoreSfondo = Color.Salmon
                    Notifica.ColoreTesto = Color.Black
                    InviaEmailErrore(ex.Message)
                Finally
                    'notifico la conclusione
                    RaiseEvent InvioConcluso()
                    Notifica.Chiudi(10)
                End Try
            End Using
            Return Esito
        End Function

        Private Function PreparaDati() As Boolean
            Try
                Quietanzamento.Clear()

                VerificaClienti()
                LeggiClienti()
                Quietanza.Agenzia = mAgenzia
                Quietanza.DatiClienti = mDatiClienti

                'ordino i dati
                Dim Vista As New DataView(mDatiAvvisi) With {.Sort = "Contraente, Ramo, Polizza"}
                mDatiAvvisi = Vista.ToTable

                For Each row As DataRow In mDatiAvvisi.Rows
                    If row("Selezionato") = True Then
                        Dim Qt As New Quietanza(row)

                        If Qt.Errore = False Then
                            'se non ci sono errori
                            Qt.Effetto = row("EffettoTitolo")
                            Qt.Scadenza = row("ScadenzaPolizza")
                            Qt.Targa = Utx.FunzioniDb.NullToString(row("Targa"))
                            Qt.RataIntermedia = row("RataIntermedia")
                            If row("SenzaPremio") = True Then
                                Qt.Premio = 0
                            Else
                                Qt.Premio = row("TotaleTitolo")
                            End If
                            Quietanzamento.Add(Qt)
                        Else
                            Dim Scartato As New Scartati With {
                                .Contraente = row("Contraente"),
                                .Ramo = row("Ramo"),
                                .Polizza = row("Polizza"),
                                .Descrizione = "Dati non trovati in archivio"}
                            ItemScartati.Add(Scartato)
                        End If
                    End If
                Next
                'aggiorno il log
                Log.Info($"Clienti: {Clienti.Count}")
                Log.Info($"Titoli: {Quietanzamento.Count}")
                'scrivo nel log gli scartati
                Log.Info($"Elementi scartati: {ItemScartati.Count}")
                Log.AumentaRientro()
                For Each s As Scartati In ItemScartati
                    Log.Info($"{s.Ramo}/{s.Polizza} {s.Contraente} ({s.Descrizione})")
                Next
                Log.DiminuisciRientro()

                Return True

            Catch ex As Exception
                Log.Errore(ex)
                Return False
            End Try
        End Function

        Public Sub BackupTabellaPostalizzazione()
            Try
                'cancello backup vecchi: tengo ultimi 3 mesi - copio ultima postalizzazione nella tabella PostalizzazioneBak dove tengo 6 mesi
                'con la prima riga creo la tabella PostalizzazioneBak se non esiste
                'con la seconda cancello i vecchi backup
                Dim Mese As Integer = Koine.Avvisi.InizioPeriodo.AddMonths(-3).Month
                'con la terza faccio il backup del mese corrente
                'infine cancello i backup più vecchi tenendo solo gli ultimi sei mesi
                Dim Query As String = $"IF OBJECT_ID('dbo.[PostalizzazioneBak]', 'U') IS NULL SELECT * INTO PostalizzazioneBak FROM Postalizzazione WHERE 1=0

                    IF OBJECT_ID('dbo.[Postalizzazione_{Mese}]', 'U') IS NOT NULL DROP TABLE dbo.[Postalizzazione_{Mese}]

                    INSERT INTO PostalizzazioneBak SELECT * FROM Postalizzazione
                    
                    DELETE FROM PostalizzazioneBak WHERE EffettoTitolo < '{Utx.FunzioniData.InizioMese(Today.AddMonths(-4)):dd/MM/yyyy}'"

                Utx.WsCommand.ExecuteNonQuery(Query, mAgenzia)
            Catch ex As Exception
                Utx.Globale.Log.Info(ex)
            End Try
        End Sub

        Private Sub InviaEmailNotifica()
#If Not DEBUG Then
            Try
                'leggo indirizzo mail destinatario notifica
                Dim DestinatarioNotifica As New Utx.SettingItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                                                                Utx.SettingItem.Chiavi.COMUNICATORE_NOTIFICHE,
                                                                Utx.SettingOMW.TipoOperazione.LETTURA)

                Dim nt As New Threading.Thread(Sub()
                                                   Dim Blocco As Utx.Sessione.Blocco = Utx.Globale.SessioneCorrente.AggiungiBlocco(Utx.Sessione.TipoBlocco.TIMER_UNITOOLS, "Invio mail")
                                                   Try
                                                       Dim p As New UniCom.Postino
                                                       With p
                                                           .EmailAutomatica = True
                                                           .Mittente = "info@unitools.it"
                                                           .InviaA.Add(DestinatarioNotifica.ItemResult.Valore)
                                                           .InviaCcn.Add("raffaele.bonghi@auaonline.it")
                                                           .Oggetto = $"Postalizzazione Unitools: Codice {mAgenzia} - Periodo {InizioPeriodo:MM/yyyy}"
                                                           .Testo = $"Postalizzazione Unitools:
Codice {mAgenzia}
Periodo {InizioPeriodo:MM/yyyy}
Postalizzazione del codice conclusa correttamente.

Non rispondere a questa e-mail. E-mail generata automaticamente."
                                                           'allego il log
                                                           .AddAllegato(Log.FullPathLogFile)

                                                           .InviaMail()
                                                       End With
                                                   Catch ex As Exception
                                                       Utx.Globale.Log.Errore(ex)
                                                   End Try
                                                   Utx.Globale.SessioneCorrente.RimuoviBlocco(Blocco)
                                               End Sub)
                nt.Start()
            Catch ex As Exception
                Globale.Log.Errore(ex)
            End Try
#End If
        End Sub

        Private Sub InviaEmailErroriIndirizzo(Doc As DocumentoDati)
#If Not DEBUG Then
            Dim nt As New Threading.Thread(Sub()
                                               Dim Blocco As Utx.Sessione.Blocco = Utx.Globale.SessioneCorrente.AggiungiBlocco(Utx.Sessione.TipoBlocco.TIMER_UNITOOLS, "Invio mail")
                                               Try
                                                   Dim p As New UniCom.Postino
                                                   With p
                                                       .EmailAutomatica = True
                                                       .Mittente = "info@unitools.it"
                                                       .InviaA.Add(Postalizzazione.SettingPostalizzazione.LeggiValore(Utx.GestioneFlag.TipoFlag.POSTALIZZAZIONE_NOTIFICHE))
                                                       .Oggetto = $"ERRORI DI INDIRIZZO IN POSTALIZZAZIONE: Codice {mAgenzia} - Periodo {InizioPeriodo:MM/yyyy}"
                                                       .Testo = $"Nell'effetuare la postalizzazione in oggetto sono stati individuati indirizzi
errati o incompleti. Si tratta spesso di vecchie anagrafiche mai completate.

Le eventuali comunicazioni cartacee, a questi clienti, non verranno ovviamente inviate.

Vi ricordiamo anche che è disponibile l'estrazione 'Indirizzi clienti errati' che vi permette di conoscere tutte le anomalie negli indirizzi e di 
correggerle. Potete anche filtrare lo stato del cliente per estrarre e effettuare le correzioni solo sui clienti effettivi.


Riportiamo di seguito gli errori rilevati per le scadenze in oggetto:

{Doc.ErroreIndirizzo}

* Non rispondere a questa e-mail. E-mail generata automaticamente."

                                                       .InviaMail()
                                                   End With
                                               Catch ex As Exception
                                                   Utx.Globale.Log.Errore(ex)
                                               End Try
                                               Utx.Globale.SessioneCorrente.RimuoviBlocco(Blocco)
                                           End Sub)
            nt.Start()
#End If
        End Sub

        Private Sub InviaEmailErrore(DescrizioneErrore As String)
#If Not DEBUG Then
            Dim nt As New Threading.Thread(Sub()
                                               Dim Blocco As Utx.Sessione.Blocco = Utx.Globale.SessioneCorrente.AggiungiBlocco(Utx.Sessione.TipoBlocco.TIMER_UNITOOLS, "Invio mail")
                                               Try
                                                   Dim p As New UniCom.Postino
                                                   With p
                                                       .EmailAutomatica = True
                                                       .Mittente = "info@unitools.it"
                                                       .InviaA.Add("guido.lampo@auaonline.it")
                                                       .InviaCcn.Add("raffaele.bonghi@auaonline.it")
                                                       .Oggetto = $"ERRORE Postalizzazione Unitools: Codice {mAgenzia} - Periodo {InizioPeriodo:MM/yyyy}"
                                                       .Testo = $"Postalizzazione Unitools:

Codice {mAgenzia}
Periodo {InizioPeriodo:MM/yyyy}

* {DescrizioneErrore.ToUpper}

Non rispondere a questa e-mail. E-mail generata automaticamente."
                                                       'allego il log
                                                       .AddAllegato(Log.FullPathLogFile)

                                                       .InviaMail()
                                                   End With
                                               Catch ex As Exception
                                                   Utx.Globale.Log.Errore(ex)
                                               End Try
                                               Utx.Globale.SessioneCorrente.RimuoviBlocco(Blocco)
                                           End Sub)
            nt.Start()
#End If
        End Sub

        Private Sub RegistraInvio(doc As DocumentoDati)
            Try
                Using s As New Utx.DatabaseOMW.Database
                    s.Proxy = Utx.Globale.UniProxy.Proxy
                    If s.CreaTabella(mAgenzia, "StoricoPostalizzazione", Utx.Globale.Token) = True Then
                        Dim Query As String = $"INSERT INTO StoricoPostalizzazione 
                            (DataInvio,FileDati,IdCampagna,Clienti,Titoli,Comunicazioni) 
                            VALUES('{Now:dd/MM/yyyy HH:mm:ss}','{doc.Lotto}','{doc.IdCampagna}',{doc.Destinatari},{doc.Titoli},{doc.Comunicazioni})"

                        Globale.Log.Info($"aggiunto {Utx.WsCommand.ExecuteNonQueryRecord(Query, mAgenzia)} record allo StoricoPostalizzazione")
                    End If
                End Using
            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try
        End Sub
    End Class

    Friend Class Scartati

        Sub New()
        End Sub

        Private mContraente As String
        Public Property Contraente() As String
            Get
                Return mContraente
            End Get
            Set(value As String)
                mContraente = value
            End Set
        End Property

        Private mRamo As Integer
        Public Property Ramo() As Integer
            Get
                Return mRamo
            End Get
            Set(value As Integer)
                mRamo = value
            End Set
        End Property

        Private mPolizza As Integer
        Public Property Polizza() As Integer
            Get
                Return mPolizza
            End Get
            Set(value As Integer)
                mPolizza = value
            End Set
        End Property

        Private mDescrizione As String
        Public Property Descrizione() As String
            Get
                Return mDescrizione
            End Get
            Set(value As String)
                mDescrizione = value
            End Set
        End Property
    End Class

    Friend Class Quietanza

        Friend Shared DatiClienti As DataTable
        Friend Shared DatiProdotti As DataTable
        Friend Shared Agenzia As String

        Sub New(Titolo As DataRow)
            Try
                mRamo = Titolo("Ramo")
                mPolizza = Titolo("Polizza")
                mCodiceFiscale = Titolo("CodiceFiscale")
                mRamogestione = Titolo("RamoGestione")

                Dim Assicurato() As DataRow = DatiClienti.Select("CodiceFiscale = '" & mCodiceFiscale & "'")   '(0)

                If Assicurato.Length > 0 Then
                    'se il cliente non 
                    If Cliente.Esiste(mCodiceFiscale) = False Then
                        Dim cli As New Cliente
                        With cli
                            .Agenzia = Titolo("Agenzia")
                            .CodiceFiscale = mCodiceFiscale
                            .Contraente = Titolo("Contraente")
                            .Indirizzo = Utx.FunzioniDb.NullToString(Assicurato(0)("Indirizzo"))
                            .Cap = Utx.FunzioniDb.NullToString(Assicurato(0)("Cap"))
                            .Localita = Utx.FunzioniDb.NullToString(Assicurato(0)("Localita"))
                            .Provincia = Utx.FunzioniDb.NullToString(Assicurato(0)("Provincia"))
                            .Sesso = Utx.FunzioniDb.NullToString(Assicurato(0)("Sesso"))
                            .DataNascita = Assicurato(0)("DataNascita")
                            .SubAgenzia = Utx.FunzioniDb.NullToString(Titolo("SubAgenzia"))
                            .Cellulare = Utx.FunzioniDb.NullToString(Assicurato(0)("Telefono"))
                            .Email = Utx.FunzioniDb.NullToString(Assicurato(0)("Email"))
                        End With
                        Clienti.Add(cli)
                    End If

                    mDescrizioneProdotto = DescrizioneTitolo(mRamogestione, mRamo)
                Else
                    mErrore = True
                End If

            Catch ex As Exception
                Log.Errore(ex)
            End Try
        End Sub

        Private mCodiceFiscale As String
        Public Property CodiceFiscale() As String
            Get
                Return mCodiceFiscale
            End Get
            Set(value As String)
                mCodiceFiscale = value
            End Set
        End Property

        Private mRamo As Integer
        Public Property Ramo() As Integer
            Get
                Return mRamo
            End Get
            Set(value As Integer)
                mRamo = value
            End Set
        End Property

        Private mPolizza As Integer
        Public Property Polizza() As Integer
            Get
                Return mPolizza
            End Get
            Set(value As Integer)
                mPolizza = value
            End Set
        End Property

        Private mRamogestione As Integer
        Public Property RamoGestione() As Integer
            Get
                Return mRamogestione
            End Get
            Set(value As Integer)
                mRamogestione = value
            End Set
        End Property

        Private mEffetto As Date
        Public Property Effetto() As Date
            Get
                Return mEffetto
            End Get
            Set(value As Date)
                mEffetto = value
            End Set
        End Property

        Private mScadenza As Date
        Public Property Scadenza() As Date
            Get
                Return mScadenza
            End Get
            Set(value As Date)
                mScadenza = value
            End Set
        End Property

        Private mPremio As Double
        Public Property Premio() As Double
            Get
                Return mPremio
            End Get
            Set(value As Double)
                mPremio = value
            End Set
        End Property

        Private mTarga As String
        Public Property Targa() As String
            Get
                Return mTarga
            End Get
            Set(value As String)
                mTarga = Replace(value, " ", "")
            End Set
        End Property

        Private mRataIntermedia As String
        Public Property RataIntermedia() As String
            Get
                Return mRataIntermedia
            End Get
            Set(value As String)
                mRataIntermedia = value
            End Set
        End Property

        Private mDescrizioneProdotto As String
        Public ReadOnly Property DescrizioneProdotto() As String
            Get
                Return mDescrizioneProdotto
            End Get
        End Property

        Private mInseritaDocXml As Boolean
        Public Property InseritaDocXml() As Boolean
            Get
                Return mInseritaDocXml
            End Get
            Set(value As Boolean)
                mInseritaDocXml = value
            End Set
        End Property

        Private mErrore As Boolean
        Public ReadOnly Property Errore() As Boolean
            Get
                Return mErrore
            End Get
        End Property
    End Class

    Friend Class Cliente

        Sub New()
            mInviare = "S"
        End Sub

        Private mInviare As String
        Public Property Inviare() As String
            Get
                Return mInviare
            End Get
            Set(value As String)
                mInviare = value
            End Set
        End Property

        Private mAgenzia As String
        Public Property Agenzia() As String
            Get
                Return mAgenzia
            End Get
            Set(value As String)
                mAgenzia = value
            End Set
        End Property

        Private mSubAgenzia As String
        Public Property SubAgenzia() As String
            Get
                Return mSubAgenzia
            End Get
            Set(value As String)
                mSubAgenzia = value
            End Set
        End Property

        Private mCodiceFiscale As String
        Public Property CodiceFiscale() As String
            Get
                Return mCodiceFiscale.Trim
            End Get
            Set(value As String)
                mCodiceFiscale = value.Trim.ToUpper
            End Set
        End Property

        Private mContraente As String
        Public Property Contraente() As String
            Get
                Return mContraente.Trim
            End Get
            Set(value As String)
                mContraente = value
            End Set
        End Property

        Private mIndirizzo As String
        Public Property Indirizzo() As String
            Get
                Return mIndirizzo.Trim
            End Get
            Set(value As String)
                mIndirizzo = value
            End Set
        End Property

        Private mLocalita As String
        Public Property Localita() As String
            Get
                Return mLocalita.Trim
            End Get
            Set(value As String)
                mLocalita = value
            End Set
        End Property

        Private mCap As String
        Public Property Cap() As String
            Get
                Return mCap
            End Get
            Set(value As String)
                mCap = value
            End Set
        End Property

        Private mProvincia As String
        Public Property Provincia() As String
            Get
                Return mProvincia
            End Get
            Set(value As String)
                mProvincia = value
            End Set
        End Property

        Private mSesso As String
        Public Property Sesso() As String
            Get
                Return mSesso
            End Get
            Set(value As String)
                If String.IsNullOrEmpty(value) Then
                    mSesso = "N"
                Else
                    mSesso = value
                End If
            End Set
        End Property

        Private mDataNascita As Date
        Public Property DataNascita() As Object
            Get
                Return mDataNascita
            End Get
            Set(value As Object)
                If IsDate(value) Then
                    mDataNascita = value
                Else
                    mDataNascita = #1/1/1900#
                End If
            End Set
        End Property

        Private mCellulare As String = ""
        Public Property Cellulare() As String
            Get
                Return Utx.FunzioniFormato.NormalizzaCellulare(mCellulare)
            End Get
            Set(value As String)
                mCellulare = value
            End Set
        End Property

        Private mEmail As String = ""
        Public Property Email() As String
            Get
                Return mEmail.Trim
            End Get
            Set(value As String)
                mEmail = value
            End Set
        End Property

        Public Shared Function Esiste(CodiceFiscale As String) As Boolean
            For Each cli As Cliente In Clienti
                If cli.CodiceFiscale.Trim.ToUpper = CodiceFiscale.Trim.ToUpper Then
                    Return True
                End If
            Next
            Return False
        End Function
    End Class

    Friend Class DocumentoDati

        Private Doc As New XmlDocument

        Sub New(InizioPeriodo As Date)
            mLotto = Postalizzazione.IdLotto(mAgenzia)

            Dim xmlAvvisiNode As XmlElement = Doc.CreateElement("avvisi")
            With xmlAvvisiNode
                .SetAttribute("numerolotto", mLotto)
                .SetAttribute("agenzia", mAgenzia)
                .SetAttribute("elementi", Clienti.Count)
                .SetAttribute("tipo_flusso", "avvisi")
            End With

            mErroreIndirizzo = ""

            'appendo i destinatari
            For Each cli As Cliente In Clienti
                Dim Dest As New DestinatarioXml(cli)
                Dest.Aggiungi(xmlAvvisiNode)
                mDestinatari += 1
                mComunicazioni += Dest.Comunicazioni
                mTitoli += Dest.Titoli

                If String.IsNullOrEmpty(Dest.ErroreIndirizzo) = False Then
                    'se  ci sono errori di indirizzo
                    mErroreIndirizzo &= Environment.NewLine & Dest.ErroreIndirizzo
                End If
            Next

            Doc.AppendChild(xmlAvvisiNode)
            Doc.Save(Me.FileXml)
        End Sub

        Private mErroreIndirizzo As String
        Public ReadOnly Property ErroreIndirizzo() As String
            Get
                Return mErroreIndirizzo
            End Get
        End Property

        Private mLotto As String
        Public ReadOnly Property Lotto() As String
            Get
                Return mLotto
            End Get
        End Property

        Private mIdCampagna As String
        Public Property IdCampagna() As String
            Get
                Return mIdCampagna
            End Get
            Set(value As String)
                mIdCampagna = value
            End Set
        End Property

        Public ReadOnly Property FileXml() As String
            Get
                Return Path.Combine(Utx.Globale.Paths.CartellaTempUtente, mLotto + ".xml")
            End Get
        End Property

        Public ReadOnly Property FileZip() As String
            Get
                Return Path.Combine(Utx.Globale.Paths.CartellaTempUtente, Path.GetFileNameWithoutExtension(Me.FileXml) & ".zip")
            End Get
        End Property

        Private mDestinatari As Integer = 0
        Public ReadOnly Property Destinatari() As Integer
            Get
                Return mDestinatari
            End Get
        End Property

        Private mComunicazioni As Integer = 0
        Public ReadOnly Property Comunicazioni() As Integer
            Get
                Return mComunicazioni
            End Get
        End Property

        Private mTitoli As Integer = 0
        Public ReadOnly Property Titoli() As Integer
            Get
                Return mTitoli
            End Get
        End Property

        Public Sub ArchiviaFile()
            Dim CartellaArchivio As String = Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, "Postalizzazione")
            Directory.CreateDirectory(CartellaArchivio)

            If File.Exists(Me.FileZip) Then
                File.Copy(Me.FileZip, Path.Combine(CartellaArchivio, Path.GetFileName(Me.FileZip)), True)
            End If
        End Sub
    End Class

    Friend Class DestinatarioXml

        Dim mDestinatario As Cliente

        Sub New(Destinatario As Cliente)
            mDestinatario = Destinatario
            mErroreIndirizzo = ""
        End Sub

        Private mErroreIndirizzo As String
        Public ReadOnly Property ErroreIndirizzo() As String
            Get
                Return mErroreIndirizzo
            End Get
        End Property

        Public Sub Aggiungi(ParentNode As XmlNode)
            'controllo problemi in indirizzo destinatario
            With mDestinatario
                If Val(.Cap) = 0 OrElse String.IsNullOrEmpty(.Localita) OrElse String.IsNullOrEmpty(.Indirizzo) Then
                    mErroreIndirizzo = $"{ .CodiceFiscale} { .Contraente} cap: { .Cap} indirizzo: { .Indirizzo} localita: { .Localita}"
                    Log.Info(mErroreIndirizzo)
                End If
            End With

            'seleziono tutte le quietanze del cliente selezionato
            Do While Quietanzamento.FindAll(Function(c) (c.CodiceFiscale = mDestinatario.CodiceFiscale And c.InseritaDocXml = False)).Count > 0

                Dim xmlDest As XmlElement = ParentNode.OwnerDocument.CreateElement("destinatario")
                With xmlDest
                    .SetAttribute("agenzia", mDestinatario.Agenzia)
                    .SetAttribute("codicesa", mDestinatario.CodiceFiscale)
                    .SetAttribute("nominativo", mDestinatario.Contraente)
                    .SetAttribute("indirizzo", mDestinatario.Indirizzo)
                    .SetAttribute("localita", mDestinatario.Localita)
                    .SetAttribute("cap", mDestinatario.Cap)
                    .SetAttribute("comune", "")
                    .SetAttribute("provincia", mDestinatario.Provincia)
                    .SetAttribute("venditore", mDestinatario.SubAgenzia)
                    .SetAttribute("tpcliente", "")
                    .SetAttribute("cf", mDestinatario.CodiceFiscale)
                    .SetAttribute("check-carta", "")
                    .SetAttribute("check-email", "")
                    .SetAttribute("check-sms", "")
                    .SetAttribute("check-sms-landing", "")
                    .SetAttribute("sesso", mDestinatario.Sesso)
                    .SetAttribute("data_nascita", mDestinatario.DataNascita)
                    'appendo i contatti
                    .AppendChild(Telefono(xmlDest))
                    .AppendChild(Email(xmlDest))
                    'appendo le scadenze
                    For Each Qt As Quietanza In Quietanzamento.FindAll(Function(c) (mDestinatario.CodiceFiscale.StartsWith(c.CodiceFiscale) And c.InseritaDocXml = False))
                        .AppendChild(Scadenza(xmlDest, Qt))
                        Qt.InseritaDocXml = True
                        mTitoli += 1
                    Next
                End With
                ParentNode.AppendChild(xmlDest)
                mComunicazioni += 1
            Loop
        End Sub

        Private mComunicazioni As Integer
        Public ReadOnly Property Comunicazioni() As Integer
            Get
                Return mComunicazioni
            End Get
        End Property

        Private mTitoli As Integer
        Public ReadOnly Property Titoli() As Integer
            Get
                Return mTitoli
            End Get
        End Property

        Private Function Telefono(ParentNode As XmlNode) As XmlElement
            Dim xmlEl As XmlElement = ParentNode.OwnerDocument.CreateElement("telefono")
            xmlEl.InnerText = mDestinatario.Cellulare
            Return xmlEl
        End Function

        Private Function Email(ParentNode As XmlNode) As XmlElement
            Dim xmlEl As XmlElement = ParentNode.OwnerDocument.CreateElement("email")
            xmlEl.InnerText = mDestinatario.Email
            Return xmlEl
        End Function

        Private Function Scadenza(ParentNode As XmlNode, Qt As Quietanza) As XmlElement
            Dim xmlEl As XmlElement = ParentNode.OwnerDocument.CreateElement("scadenza")
            With xmlEl
                .SetAttribute("ramogestione", Qt.RamoGestione)
                .SetAttribute("descrizione_prodotto", Qt.DescrizioneProdotto)
                .SetAttribute("polizza", $"{Qt.Ramo}/{Qt.Polizza}")
                .SetAttribute("targa", Qt.Targa)
                .SetAttribute("modello", "")
                .SetAttribute("data_scadenza", Qt.Effetto)

                .SetAttribute("importo", $"{Qt.Premio:###,###,##0.00}")
                .SetAttribute("codicetitolo", "")
                .SetAttribute("cod_cliente", mDestinatario.CodiceFiscale)
                If Qt.RataIntermedia = "S" Then
                    .SetAttribute("tiposcadenza", "intermedia")
                Else
                    .SetAttribute("tiposcadenza", "annuale")
                End If
            End With
            Return xmlEl
        End Function
    End Class

    Private Shared Function DescrizioneTitolo(RamoGestione As Integer, RamoPolizza As Integer) As String
        Select Case RamoGestione
            Case 1 : Return "VEICOLO" 'viene aggiunta la targa da koinè
            Case 2 : Return "AUTO RISCHI DIVERSI"
            Case 3 : Return "INFORTUNI"
            Case 4 : Return "SALUTE"
            Case 5
                If RamoPolizza = 48 OrElse RamoPolizza = 148 Then
                    Return "ABITAZIONE"
                Else
                    Return "RISCHI DIVERSI PERSONE"
                End If
            Case 6 : Return "INCENDIO"
            Case 7 : Return "INCENDIO RISCHI INDUSTRIALI"
            Case 8 : Return "RISCHI TECNOLOGICI"
            Case 9 : Return "FURTO"
            Case 10
                If RamoPolizza = 122 Then
                    Return "MULTIRISCHI PROFESSIONALI"
                Else
                    Return "RESPONSABILITA' CIVILE"
                End If
            Case 11 : Return "TRASPORTI"
            Case 12 : Return "AERONAUTICA"
            Case 13 : Return "CAUZIONI"
            Case 14 : Return "CREDITO"
            Case 15 : Return "RISCHIO IMPIEGO"
            Case 16 : Return "GRANDINE"
            Case 17 : Return "AGRICOLTURA"
            Case 18 : Return "VITA"
            Case 19 : Return "VITA COLLETTIVE"
            Case 20 : Return "FONDI PENSIONE"
            Case 21 : Return "TUTELA LEGALE"
            Case 22 : Return "ASSISTENZA"
            Case 23 : Return "TURISMO"
            Case Else : Return "-"
        End Select
    End Function
#End Region
End Class
