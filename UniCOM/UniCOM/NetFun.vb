Imports System.IO
Imports Newtonsoft.Json
Imports System.Net

Public Class CNetFun

    'per i test utilizzo l'account (non subaccount):--------------
    'utente: testguido
    'pw: Lampo123?
    'gateway: 2 (perché non invia realmente)
    '-------------------------------------------------------------

    Const ApiToken As String = "d0kOc3QLvxDtl14kHz5.XIieaUxDxdV_ICNIrhtW0EuRL_fpf7"
    Const ApiUrl As String = "https://unicosistema.web-servizi.net/api/rest/v1/sms-batch.json"

    Public Enum AccountError
        XMS_SOAP_ERR_CODICE = -1
        XMS_SOAP_OK = 0
        XMS_SOAP_ERR_LOGIN_EMPTY = 1 'dati login non impostati
        XMS_SOAP_ERR_LOGIN = 2 'login errato
        XMS_SOAP_ERR_AUTH_TOKEN = 3 'AuthToken non valida
        XMS_SOAP_ERR_AUTH_TOKEN_EXPIRED = 4 'AuthToken scaduto, ripetere operazione
        XMS_SOAP_ERR_APIKEY = 5 'API KEY non abilitata o errata
        XMS_SOAP_ERR_APIKEY_NOAUTH = 6 'API KEY non autorizzata

        XMS_SOAP_ERR_CREDIT = 10 'Credito non sufficiente
        XMS_SOAP_ERR_TEXT_EMPTY = 11 'Testo vuoto
        XMS_SOAP_ERR_DATE_INVALID = 12 'Data non valida
        XMS_SOAP_ERR_DATE_PAST = 13 'Data trascorsa
        XMS_SOAP_ERR_GATEWAY = 14 'Gateway non valido
        XMS_SOAP_ERR_SENDER = 15 'Sender non valido

        XMS_SOAP_ERR_NUMBERS_EMPTY = 20 'Nessun numero impostato

        XMS_SOAP_ERR_INVALID_SENDING_ID = 100 'Sending ID non valido

        XMS_SOAP_ERR_SBC_NO_RESELLER = 500 'Non sei un rivenditore
        XMS_SOAP_ERR_SBC_EMPTY_NAME = 501 'Nome subaccount non valido o vuoto
        XMS_SOAP_ERR_SBC_NOT_EXISTS = 502 'Subaccount non esistente o non attivo

        XMS_SOAP_ERR_SBC_ADD_MANDATORY_DATA = 510 'Dati obbligatori assenti
        XMS_SOAP_ERR_SBC_ADD_USER_NOT_VALID = 511 'User non valida
        XMS_SOAP_ERR_SBC_ADD_USER_EXISTS = 512 'User esistente
        XMS_SOAP_ERR_SBC_ADD_EMAIL_NOT_VALID = 513 'Email non valida
        XMS_SOAP_ERR_SBC_ADD_EMAIL_EXISTS = 514 'Email esistente
        XMS_SOAP_ERR_SBC_ADD_PSW_NOT_VALID = 515 'Password non valida
        XMS_SOAP_ERR_SBC_ADD_NUM_NOT_VALID = 516 'Uno dei numeri indicati non e' valido
        XMS_SOAP_ERR_SBC_ADD_DATA_NOT_VALID = 517 'Alcuni dei dati inviati non sono validi, controlla

        XMS_SOAP_ERR_SBC_TRANS_0 = 520 'Transazione deve essere diversa da 0
        XMS_SOAP_ERR_SBC_TRANS_SUP_CREDIT = 521 'Transazione negativa superiore al credito
        XMS_SOAP_ERR_SBC_TRANS_COST_SMS = 522 'Costo SMS non valido
        XMS_SOAP_ERR_SBC_TRANS_COST_SMS_NP = 523 'Non puoi specificare il costo SMS perche' non e' in uso modalita' listino

        XMS_SOAP_ERR_UNKNOWN = 999 'errore interno al server
    End Enum

    Public Esito As New EsitoServizio

    'viene utilizzata una chiave (Id) "3d007168-9c54-4185-b7cc-074d0fa915dd"
    'per abilitare il funzionamento della classe
    'se la chiave viene passata correttamente la classe si auto-configura per l'account rivenditore
    'e consente di impostare il sub-account
    Private mId As String
    'risposte webservice
    Private _Gateway As Integer = 0
    'rivenditore
    Private mRivenditore As String
    Private mPwRivenditore As String
    'sub-account
    Private mUtenteSubaccount As String
    Private mPwUtenteSubaccount As String
    'costanti utilizzate
    Private Const mMillesimiPerSms As Integer = 100 '10 centesimi

    'Public Enum SmsStatus
    '    NonConsegnati = 0 '0	(solo non consegnati)
    '    Consegnati = 1    '1	(solo consegnati)
    '    Esitati = 2       '3    (consegnati e non consegnati senza quelli in attesa)
    '    InAttesa = -1     '-1	(solo in attesa di delivery)
    '    Tutti = -2        '-2	(DEFAULT: tutti i campi)
    'End Enum

    Private Enum SmsDetails
        Corto = 0 '0 (DEFAULT)
        Lungo = 1 '1 (maggiori dettagli oltre 0)
    End Enum

    'Friend Structure NotificaCorta
    '    Friend sending_id As String
    '    Friend sms_id As String
    '    Friend udh_num As String
    '    Friend udh_max As String
    '    Friend udh_group As String
    '    Friend receiver As String
    '    Friend custom_id As String
    '    Friend delivery_status As String
    '    Friend delivery_date As String
    '    Friend delivery_time As String
    '    Friend delivery_code As String
    '    Friend IdtCompleto As String
    'End Structure

    Public Sub New()
        If Utx.Globale.IdAppOk = False Then
            Application.Exit()
        End If

        '"unicosistema"
        '"dW5pY28=" '(unico in base64)
        mRivenditore = Convert.ToBase64String(New Byte() {186, 120, 156, 162, 200, 172, 181, 233, 154})
        mPwRivenditore = Convert.ToBase64String(New Byte() {117, 110, 105, 99, 111})
    End Sub

    Public Property Gateway() As Integer
        Get
            Return _Gateway
        End Get
        Set(Gateway As Integer)
            _Gateway = Gateway
        End Set
    End Property

    'i dati del rivenditore sono già contenuti nella classe: la proprietà viene messa per usi futuri
    Public WriteOnly Property Rivenditore() As String
        Set(value As String)
            mRivenditore = value
        End Set
    End Property

    'i dati del rivenditore sono già contenuti nella classe: la proprietà viene messa per usi futuri
    Public WriteOnly Property PwRivenditore() As String
        Set(value As String)
            mPwRivenditore = value
        End Set
    End Property

    Public Property UtenteSubaccount() As String
        Get
            Return mUtenteSubaccount
        End Get
        Set(value As String)
            mUtenteSubaccount = value
        End Set
    End Property

    Public Property PwUtenteSubaccount() As String
        Get
            Return mPwUtenteSubaccount
        End Get
        Set(value As String)
            mPwUtenteSubaccount = value
        End Set
    End Property

    Public ReadOnly Property MillesimiPerSms()
        Get
            Return mMillesimiPerSms
        End Get
    End Property

    Friend Function InviaSms(Testo As String,
                             Mittente As String,
                             ListaSms As List(Of Destinatario),
                             DataInvio As String) As String
        Try
            Globale.Log.Info("inoltro richiesta invio sms al provider")

            'creo la request
            Dim request As HttpWebRequest = Net.HttpWebRequest.Create(ApiUrl)
            request.Method = WebRequestMethods.Http.Post
            WriteHeaderRequest(request)
#If DEBUG Then
            'UtenteSubaccount = "Testguido"
            'PwUtenteSubaccount = "Lampo123?"
#End If
            'creo il body della request
            Dim body As New SmsBatch With {
                .username = UtenteSubaccount,
                .password = PwUtenteSubaccount,
                .sender = Mittente,
                .text_template = Testo}

            'inserisco i destinatari
            For Each d As Destinatario In ListaSms
                body.destinations.Add(New destination(d.Telefono, New placeholders(d.Tokens)))
            Next

#If DEBUG Then
            body.gateway = 99 'questo gateway non invia veramente
#End If
            WriteBodyRequest(request, body)
            RispostaServizio2Esito(GetResponse(request))

            If Esito.EsitoChiamata = True Then
                'restituisce ID di invio
                Globale.Log.Info("ID di spedizione {0}", {Esito.IdSending})
                Return Esito.IdSending
            Else
                Globale.Log.Info("invio al provider non riuscito")
                Return ""
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Errore2Esito(ex)
            Return ""
        End Try
    End Function

    Public Function CercaNotifica(SendingID As String,
                                  Stato As delivery.Status) As ListaNotifiche

        Dim ListaCompleta As New ListaNotifiche

        Try
            Dim IdUtente As String = IdAccount()
            Dim Limit As Integer = 100
            Dim Offset As Integer = 0

            Do While True
                'Dim Variabili As String = String.Format("user_id={0}&sending_batch_id={1}&delivery_status='{2}'&limit={3}&offset={4}",
                '                                        IdUtente, SendingID, Stato.ToString, Limit, Offset)
                Dim Variabili As String = String.Format("user_id={0}&sending_batch_id={1}&limit={2}&offset={3}",
                                                        IdUtente, SendingID, Limit, Offset)

                Dim Url As String = String.Format("https://unicosistema.web-servizi.net/api/rest/v1/sms/delivery.json?{0}", Variabili)
                Dim request As Net.HttpWebRequest = Net.HttpWebRequest.Create(Url)
                request.Method = Net.WebRequestMethods.Http.Get
                WriteHeaderRequest(request)

                Globale.Log.Trace(Url)

                Dim Lista As ListaNotifiche = JsonConvert.DeserializeObject(Of ListaNotifiche)(GetResponse(request))

                'analizzo risposta
                If Lista IsNot Nothing Then
                    ListaNotifiche.Merge(Lista, ListaCompleta)
                Else
                    MsgBox("Recupero notifiche non riuscito. Riprovare più tardi", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Esito.EsitoChiamata = False
                    Return ListaCompleta
                End If

                'verifico se ci sono altre pagine
                If Lista.deliveries.Count < Lista.limit Then
                    'ho recuperato tutto e esco
                    Exit Do
                Else
                    Offset += Limit
                End If
            Loop
            Esito.EsitoChiamata = True
            Return ListaCompleta

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Errore2Esito(ex)
            Return Nothing
        End Try
    End Function

    Public Function IdAccount(Optional UserName As String = Nothing) As String
        Try
            If UserName Is Nothing Then
                UserName = mUtenteSubaccount
            End If

            Dim Url As String = String.Format("https://unicosistema.web-servizi.net/api/rest/v1/users/wallets.json?users={0}", UserName)
            Dim request As Net.HttpWebRequest = Net.HttpWebRequest.Create(Url)
            request.Method = Net.WebRequestMethods.Http.Get
            WriteHeaderRequest(request)

            Dim credito As credito = JsonConvert.DeserializeObject(Of credito)(GetResponse(request))

            If credito.wallets.Count = 1 Then
                Return credito.wallets(0).user.id
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Errore2Esito(ex)
            Return 0
        End Try
    End Function

    Public Function CreditoSubaccount() As Integer
        Try
            Dim Url As String = String.Format("https://unicosistema.web-servizi.net/api/rest/v1/users/wallets.json?users={0}", mUtenteSubaccount)
            Dim request As Net.HttpWebRequest = Net.HttpWebRequest.Create(Url)
            request.Method = Net.WebRequestMethods.Http.Get
            WriteHeaderRequest(request)

            Dim credito As credito = JsonConvert.DeserializeObject(Of credito)(GetResponse(request))

            If credito.wallets.Count = 1 Then
                'calcolo credito in numero sms
                Return credito.wallets(0).amount * 1000 \ MillesimiPerSms
            Else
                Return 0
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Errore2Esito(ex)
            Return 0
        End Try
    End Function

    Friend Sub AddSubaccount()
        Try
            Globale.Log.Info(String.Format("Creo il sub-account {0}", mUtenteSubaccount))

            Dim Url As String = "https://unicosistema.web-servizi.net/api/rest/v1/users/subaccounts.json"
            Dim request As Net.HttpWebRequest = Net.HttpWebRequest.Create(Url)
            request.Method = Net.WebRequestMethods.Http.Post
            WriteHeaderRequest(request)

            Dim trSub As New TransazioneSubAccount
            With trSub.data
                .username = mUtenteSubaccount
                .password = mPwUtenteSubaccount
                .email = String.Format("{0}@{0}.it", .username)
                .lastname = "AUA"
            End With
            WriteBodyRequest(request, trSub)

            Globale.Log.Info(CriptaWin(mUtenteSubaccount + ";" + mPwUtenteSubaccount))

            Try
                Dim esitonf As EsitoCreazioneSubAccount = JsonConvert.DeserializeObject(Of EsitoCreazioneSubAccount)(GetResponse(request))
                If esitonf.created = True Then
                    MsgBox("Account SMS creato correttamente.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    Esito.EsitoChiamata = True
                Else
                    MsgBox("Creazione dell'account SMS non riuscita.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Esito.EsitoChiamata = False
                End If
            Catch ex As Exception
                MsgBox("Creazione dell'account SMS non riuscita.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Esito.EsitoChiamata = False
            End Try

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Errore2Esito(ex)
        End Try
    End Sub

    Public Sub AddSubaccount(Utente As String)
        Try
            Globale.Log.Info(String.Format("Creo il sub-account {0}", Utente))

            Dim Url As String = "https://unicosistema.web-servizi.net/api/rest/v1/users/subaccounts.json"
            Dim request As Net.HttpWebRequest = Net.HttpWebRequest.Create(Url)
            request.Method = Net.WebRequestMethods.Http.Post
            WriteHeaderRequest(request)

            Dim Agenzia As String = Utente.Substring(4, 5)

            Dim trSub As New TransazioneSubAccount
            With trSub.data
                .username = Utente
                .password = "Pw_AUAsms@"
                .email = String.Format("{0}@{0}.it", Utente)
                .lastname = "AUA"
            End With
            WriteBodyRequest(request, trSub)

            Try
                Dim esito As EsitoCreazioneSubAccount = JsonConvert.DeserializeObject(Of EsitoCreazioneSubAccount)(GetResponse(request))
                If esito.created = True Then
                    Globale.Log.Info("Account SMS creato correttamente.")
                Else
                    Globale.Log.Info("Creazione dell'account SMS non riuscita.")
                End If
            Catch ex As Exception
                Globale.Log.Info("Creazione dell'account SMS non riuscita.")
            End Try

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Errore2Esito(ex)
        End Try
    End Sub

    Public Function UpdateSubaccount(NuovoUserName As String) As Boolean
        Try
            'leggo credito vecchio account da trasferire al nuovo
            Dim Credito As Integer = CreditoSubaccount()
            'azzero il credito sul vecchio account
            AddCredito(Credito, TransazioneCredito.TipoTransazione.SUBTRACT)

            'elimino i dati locali del vecchio account - su netfun l'account resta

            'creo il nuovo account
            mUtenteSubaccount = NuovoUserName
            AddSubaccount()

            'ricarico il nuovo account
            AddCredito(Credito, TransazioneCredito.TipoTransazione.ADD)

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Friend Function AddCredito(QuantitaSms As Integer,
                               TipoRicarica As TransazioneCredito.TipoTransazione,
                               Optional DeskRicarica As String = "") As Integer
        Try
            Dim Url As String = String.Format("https://unicosistema.web-servizi.net/api/rest/v1/users/subaccounts/{0}/transactions.json", IdAccount)
            Dim request As Net.HttpWebRequest = Net.HttpWebRequest.Create(Url)
            request.Method = Net.WebRequestMethods.Http.Post
            WriteHeaderRequest(request)

            Dim transazione As New TransazioneCredito(QuantitaSms * mMillesimiPerSms / 1000, TipoRicarica.ToString.ToLower)

            WriteBodyRequest(request, transazione)
            Dim esito As EsitoRicarica = JsonConvert.DeserializeObject(Of EsitoRicarica)(GetResponse(request))

            'la descrizione veniva usata nel vecchio servizio e forse verrà  ripristinata (nota del 15/03/2023)
            'If DeskRicarica = String.Empty Then
            '    If QuantitaSms > 0 Then
            '        DeskRicarica = String.Format("Ricarica (Utente: {0} - Ore: {1:t})", Environment.UserName, Now)
            '    Else
            '        DeskRicarica = String.Format("Addebito delle {0:t}", Now)
            '    End If
            'End If

            If esito.updated = True Then
                'trasformo il credito in numero sms
                Return esito.wallet / MillesimiPerSms * 1000
            Else
                Return 0
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Errore2Esito(ex)
            Return 0
        End Try
    End Function

    Public Function AddCredito(User As String,
                               Importo As Decimal,
                               TipoRicarica As TransazioneCredito.TipoTransazione) As Integer
        Try
            Dim Url As String = String.Format("https://unicosistema.web-servizi.net/api/rest/v1/users/subaccounts/{0}/transactions.json", IdAccount(User))
            Dim request As Net.HttpWebRequest = Net.HttpWebRequest.Create(Url)
            request.Method = Net.WebRequestMethods.Http.Post
            WriteHeaderRequest(request)

            Dim transazione As New TransazioneCredito(Importo, TipoRicarica.ToString.ToLower)

            WriteBodyRequest(request, transazione)
            Dim esito As EsitoRicarica = JsonConvert.DeserializeObject(Of EsitoRicarica)(GetResponse(request))

            If esito.updated = True Then
                'trasformo il credito in numero sms
                Return esito.wallet / MillesimiPerSms * 1000
            Else
                Return 0
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Errore2Esito(ex)
            Return 0
        End Try
    End Function

    Private Sub RispostaServizio2Esito(Risposta As String, Optional ValoreRestituito As Object = Nothing)
        Try
            Dim EsitoRest As EsitoServizioRest = JsonConvert.DeserializeObject(Of EsitoServizioRest)(Risposta)
            Esito.CodiceErrore = EsitoRest.error
            Esito.EsitoChiamata = (Esito.CodiceErrore = 0)
            'Esito.MessaggioErrore = wsNetfun.getErrorDescr(Risposta)
            Esito.ValoreRestituiro = ValoreRestituito
            Esito.IdSending = EsitoRest.sending_batch_id
#If DEBUG Then
            Globale.Log.Info(Esito.IdSending)
#End If
        Catch ex As Exception
            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
            Esito.IdSending = ""
        End Try
    End Sub

    Private Sub Errore2Esito(ex As Exception)
        Esito.EsitoChiamata = False
        Esito.MessaggioErrore = ex.Message
    End Sub

    Private Function DeskErrore(Codice As Integer) As String
        Select Case Codice
            Case 1 : Return "Dati login non impostati"
            Case 2 : Return "Login non corretto"
            Case 10 : Return "Credito non sufficiente"
            Case 11 : Return "Testo SMS vuoto"
            Case 12 : Return "Data non valida"
            Case 13 : Return "Data(trascorsa)"
            Case 14 : Return "Gateway non valido"
            Case 15 : Return "Mittente non valido"
            Case 20 : Return "Nessun numero (destinatario) impostato"
            Case 100 : Return "Codice spedizione non valido (in getDelivery)"
            Case 999 : Return "Errore interno al server"
            Case Else : Return "Errore imprevisto"
        End Select
    End Function

    Public Function DeskErroreAccount(Codice As AccountError) As String
        Select Case Codice
            Case AccountError.XMS_SOAP_ERR_CODICE : Return "Errore da codice"
            Case AccountError.XMS_SOAP_OK : Return "Aggiornamento account eseguito correttamente"
            Case 1 : Return "dati login non impostati"
            Case 2 : Return "login errato"
            Case 3 : Return "AuthToken non valida"
            Case 4 : Return "AuthToken scaduto, ripetere operazione"
            Case 5 : Return "API KEY non abilitata o errata"
            Case 6 : Return "API KEY non autorizzata"

            Case 10 : Return "Credito non sufficiente"
            Case 11 : Return "Testo vuoto"
            Case 12 : Return "Data non valida"
            Case 13 : Return "Data trascorsa"
            Case 14 : Return "Gateway non valido"
            Case 15 : Return "Sender non valido"

            Case 20 : Return "Nessun numero impostato"

            Case 100 : Return "Sending ID non valido"

            Case 500 : Return "Non sei un rivenditore"
            Case 501 : Return "Nome subaccount non valido o vuoto"
            Case 502 : Return "Subaccount non esistente o non attivo"

            Case 510 : Return "Dati obbligatori assenti"
            Case 511 : Return "User non valida"
            Case 512 : Return "User esistente"
            Case 513 : Return "Email non valida"
            Case 514 : Return "Email esistente"
            Case 515 : Return "Password non valida"
            Case 516 : Return "Uno dei numeri indicati non e' valido"
            Case 517 : Return "Alcuni dei dati inviati non sono validi, controlla"

            Case 520 : Return "Transazione deve essere diversa da 0"
            Case 521 : Return "Transazione negativa superiore al credito"
            Case 522 : Return "Costo SMS non valido"
            Case 523 : Return "Non puoi specificare il costo SMS perche' non e' in uso modalita' listino"

            Case 999 : Return "errore interno al server"
            Case Else : Return "Errore imprevisto"
        End Select
    End Function

    Public Sub WriteHeaderRequest(ByRef request As HttpWebRequest)
        request.Proxy = Utx.Globale.UniProxy.Proxy
        request.Accept = "text/json"
        request.ContentType = "application/json"
        request.Headers.Add("X-Api-Token", ApiToken)
    End Sub

    Public Sub WriteBodyRequest(ByRef request As HttpWebRequest, body As Object)
        'scrivo il body nella request
        Using stmw As New StreamWriter(request.GetRequestStream())
            Using writer As New Newtonsoft.Json.JsonTextWriter(stmw)
                Dim serializer As New Newtonsoft.Json.JsonSerializer()
                serializer.Converters.Add(New Converters.JavaScriptDateTimeConverter())
                serializer.NullValueHandling = NullValueHandling.Ignore
                serializer.Formatting = Formatting.Indented
                serializer.Serialize(writer, body)
            End Using
        End Using
#If DEBUG Then
        'StampaJson(body)
#End If
    End Sub

    Public Function GetResponse(request As HttpWebRequest) As String
        Try
            Dim response As HttpWebResponse = request.GetResponse()
            Dim reader As New StreamReader(response.GetResponseStream())
            Return reader.ReadToEnd()
        Catch ex As Exception
            Globale.Log.Info(ex)
            Globale.Log.Trace(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Sub StampaJson(body As Object)
        Dim serializer As New Newtonsoft.Json.JsonSerializer()
        serializer.Converters.Add(New Newtonsoft.Json.Converters.JavaScriptDateTimeConverter())
        serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore

        Using sw As New StreamWriter(Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "jsonbody.txt"))
            Using writer As New Newtonsoft.Json.JsonTextWriter(sw)
                serializer.Converters.Add(New Newtonsoft.Json.Converters.JavaScriptDateTimeConverter())
                serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
                serializer.Formatting = Formatting.Indented
                serializer.Serialize(writer, body)
            End Using
        End Using
    End Sub

#Region "Migrazione"
    Public Shared Function CreditoSubaccountOld(SubAccount As String) As Decimal
        Try
            Dim Credito As String = ""

            Using nf As New Netfun.smsService
                Dim Risposta As String = nf.getCreditSubaccount("unicosistema",
                                                                "dW5pY28=",
                                                                SubAccount,
                                                                Credito)
            End Using

            Return Credito / 1000

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return 0
        End Try
    End Function

    Public Shared Function AddCredito(SubAccount As String, Importo As Decimal) As Integer
        Try
            'per azzerare il vecchio account
            Dim NuovoCredito As String = "" 'passato per riferimento

            Using nf As New Netfun.smsService
                Dim Risposta As String = nf.addTransactionSubaccount("unicosistema",
                                                                     "dW5pY28=",
                                                                     SubAccount,
                                                                     Int(Importo * 1000),
                                                                     "0",
                                                                     "Migrazione",
                                                                     NuovoCredito)
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return 0
        End Try
    End Function
#End Region
End Class
