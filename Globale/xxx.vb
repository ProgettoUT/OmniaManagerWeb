Imports System.Drawing
Imports System.Net
Imports System.IO
Imports System.Reflection
Imports System.Text

Public MustInherit Class Autenticazione

    Public Enum TipoLogin
        UEBA
        ESSIG
        LIQUIDO
        SERTEL
        OWA
        CRM
        ESSIG_UNISALUTE
    End Enum
    Public Enum StatoLogin
        LOGIN
        LOGOUT
        FALLITO
        RETE_NON_DISPONIBILE
        ATTESA
    End Enum

    Public Property CookieContainer As Net.CookieContainer
    Public Property Proxy As System.Net.IWebProxy
    Public Property Utente As String
    Public Property Password As String
    Public Property Dominio As String
    Public Property Stato As StatoLogin = StatoLogin.LOGOUT
    Public Property LoggedUrl As String = Nothing
    Public Property LoginRichiesto As TipoLogin
    Public Property UltimoLogin As Date
    Protected Property UrlStartPage As String = Nothing
    Protected Property UrlLoginPage As String = "https://essig.unipolsai.it/my.policy" 'dal 28/01/2022 sia in intranet che internet
    Public Property MSA As Boolean = False

    Public ReadOnly Property IsLogged As Boolean
        Get
            Return (Stato = StatoLogin.LOGIN)
        End Get
    End Property

    Public Sub New(Optional AutenticazioneMSA As Boolean = False)
#If DEBUG Then
        AutenticazioneMSA = True
#End If
        If Globale.UtenteCorrente IsNot Nothing Then
            Utente = Globale.UtenteCorrente.UniageUser
            Password = Globale.UtenteCorrente.UniagePw
            Dominio = Globale.UtenteCorrente.Dominio
        End If

        MSA = AutenticazioneMSA

        If MSA = True Then
            UrlLoginPage = "https://essig.unipolsai.it"
        End If
    End Sub

    Public Shared Function CodificaUrl(Url As String) As String
        Return Web.HttpUtility.UrlEncode(Url)
    End Function

    Public Function LogIn(Utente As String, Password As String, Dominio As String) As StatoLogin
        _Utente = Utente
        _Password = Password
        _Dominio = Dominio

        If String.IsNullOrEmpty(_Utente) Then
            Throw New Exception("il campo Utente è obbligatorio")
        End If
        If String.IsNullOrEmpty(_Password) Then
            Throw New Exception("il campo Password è obbligatorio")
        End If
        If String.IsNullOrEmpty(_Dominio) Then
            Throw New Exception("il campo Dominio è obbligatorio")
        End If

        Return LogIn()
    End Function

    Public Shared Function GetCookies(CookieContainer As CookieContainer) As CookieCollection
        Dim cookieCollection As New CookieCollection()

        Dim table As Hashtable = CookieContainer.GetType().InvokeMember("m_domainTable",
                                                                        BindingFlags.NonPublic Or BindingFlags.GetField Or BindingFlags.Instance,
                                                                        Nothing,
                                                                        CookieContainer,
                                                                        New Object() {})

        For Each key In table.Keys
            Dim skey As String = key.ToString()
            Dim list As SortedList = table(skey).GetType().InvokeMember("m_list",
                                                                        BindingFlags.NonPublic Or BindingFlags.GetField Or BindingFlags.Instance,
                                                                        Nothing,
                                                                        table(skey),
                                                                        New Object() {})

            For Each listKey In list.Keys
                If skey.Chars(0) = "."c Then
                    skey = skey.Substring(1)
                End If
                Dim url = "https://" & skey & listKey.ToString
                cookieCollection.Add(CookieContainer.GetCookies(New Uri(url)))
            Next
        Next
        Return cookieCollection
    End Function

    Public Shared Sub SetCookies(url As String, Cookies As CookieContainer)
        Try
            For Each c As Cookie In Utx.Autenticazione.GetCookies(Cookies)
                '& "; expires = Sun, 01-Jul-2014 00:00:00 GMT")
                ' "; expires = " & format(now,"ddd, dd-MMM-yyyy 23:59:59")
                If Utx.Globale.InternetSetCookie(url, c.Name, c.Value) = False Then
                    Utx.Globale.Log.Info("SetCookie fallito: name = " & c.Name)
                End If
            Next
        Catch ex As Exception
            Utx.Globale.Log.Info("SetCookie fallito")
            Utx.Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Public Shared Sub LoginRefresh()
        If Utx.Globale.LoginUniage.UltimoLogin.AddMinutes(20) < Now Then
            Dim t As New Threading.Thread(Sub()
                                              Utx.Globale.Log.Info("Eseguo un refresh del login")
                                              Try
                                                  Dim essig As New Utx.AutenticazioneEssig With {.CookieContainer = Utx.Globale.LoginUniage.CookieContainer}
                                                  'faccio una chiamata al menù per simulare attività dell'utente
                                                  essig.CallWeb(essig.UrlBase & "essigSC/start.do?itemId=0101000000&parametri=SC++SC")
                                                  Utx.Globale.LoginUniage.UltimoLogin = Now
                                              Catch ex As Exception
                                                  Utx.Globale.Log.Info(ex)
                                              End Try
                                          End Sub)
            t.Start()
        End If
    End Sub

    Public Function CallWeb(url As String, Optional postData As String = Nothing, Optional AutoRedirect As Boolean = True) As String
        Static Dim indice As Integer = 1
        Try
            Globale.Log.Trace()
            Globale.Log.Trace("tipo login: " & LoginRichiesto.ToString)
            Globale.Log.Trace("url: " & url)
            Globale.Log.Trace("redirect: " & AutoRedirect)

            ServicePointManager.SecurityProtocol = 3072 'fondamentale nei casi in cui i protocolli TSL 1.1/1.2 non vanno in automatico

            Dim request As HttpWebRequest = HttpWebRequest.Create(url)
            request.AllowAutoRedirect = False
            request.Proxy = Utx.Globale.UniProxy.Proxy
            request.Timeout = 100000 'per risolvere l'errore 504 gateway timeout

            If request.Proxy Is Nothing Then
                Globale.Log.Trace("Proxy NON valorizzato")
            Else
                Globale.Log.Trace("Proxy valorizzato")
            End If
            If String.IsNullOrEmpty(postData) Then
                Globale.Log.Trace("Post NON valorizzato")
            Else
                Globale.Log.Trace("Post valorizzato")
            End If

            request.CookieContainer = CookieContainer

            If postData IsNot Nothing Then
                ' Set the Method property of the request to POST.
                request.Method = "POST"

                ' Create POST data and convert it to a byte array.
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)

                ' Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded"

                ' Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length

                ' Get the request stream.
                Dim reqStream As Stream = request.GetRequestStream()

                ' Write the data to the request stream.
                reqStream.Write(byteArray, 0, byteArray.Length)

                ' Close the Stream object.
                reqStream.Close()
            End If

            ' Get the response.
            Dim response As HttpWebResponse = request.GetResponse()
            CookieContainer.Add(response.Cookies)

            Utx.Globale.Log.Trace("CallWeb StatusCode: {0} - {1}", {response.StatusCode, response.StatusDescription})

            Select Case response.StatusCode
                Case HttpStatusCode.Found, HttpStatusCode.MovedPermanently, HttpStatusCode.Moved, HttpStatusCode.TemporaryRedirect
                    Dim newUrl = response.Headers("Location")
                    Utx.Globale.Log.Trace("Location: " & newUrl)

                    If newUrl.StartsWith("/") Then
                        Dim a = New Uri(url)
                        newUrl = a.AbsoluteUri.Substring(0, a.AbsoluteUri.LastIndexOf(a.AbsolutePath)) & newUrl
                    End If
                    response.Close()

                    If AutoRedirect Then
                        Return CallWeb(newUrl, postData)
                    Else
                        Globale.Log.Trace("risposta server: " & newUrl)
                        Return newUrl
                    End If

                Case Else
                    ' Get the stream containing content returned by the server.
                    Dim resStream As Stream = response.GetResponseStream()

                    ' Open the stream using a StreamReader for easy access.
                    Dim reader As New StreamReader(resStream)

                    ' Read the content.
                    Dim responseFromServer As String = reader.ReadToEnd()

                    ' Clean up the streams.
                    reader.Close()
                    resStream.Close()
                    response.Close()

                    Return responseFromServer
            End Select

        Catch ex As Exception
            'server non raggiungibile Err.Number = 5
            Globale.Log.Errore(ex, False)
            Return Nothing
        End Try
    End Function

    Public Overridable Function LogIn() As StatoLogin
        If Stato <> StatoLogin.LOGIN Then
            Utx.Globale.Log.Info("login...")

            CookieContainer = New Net.CookieContainer
            Dim r0 = CallWeb(UrlStartPage)

            If r0 Is Nothing Then
                Stato = StatoLogin.RETE_NON_DISPONIBILE
            ElseIf Not r0.Contains("SECURID_AUTH_STATE_START") Then
                Stato = StatoLogin.FALLITO
            Else
                Dim r1, r2 As String

                If MSA = True Then
                    r1 = CallWeb(UrlLoginPage + "/my.policy", String.Format("username={0}&password={1}&domain={2}&vhost=standard",
                                                                       Web.HttpUtility.UrlEncode(Utente),
                                                                       Web.HttpUtility.UrlEncode(Password),
                                                                       Web.HttpUtility.UrlEncode(Dominio)), False)
                    r2 = CallWeb(UrlLoginPage + "/my.policy", "password=&vhost=standard")

                    If r2.Contains("utag_data") Then
                        Stato = StatoLogin.LOGIN
                        'LoggedUrl = r1
                        Utx.Globale.Log.Info("login effettuato")
                    Else
                        Stato = StatoLogin.FALLITO
                        Utx.Globale.Log.Info("login fallito")
                    End If

                    Stato = StatoLogin.LOGIN

                Else
                    r1 = CallWeb(UrlLoginPage, String.Format("username={0}&password={1}&domain={2}&vhost=standard",
                                                                       Web.HttpUtility.UrlEncode(Utente),
                                                                       Web.HttpUtility.UrlEncode(Password),
                                                                       Web.HttpUtility.UrlEncode(Dominio)), False)
                    If LoginOk(r1) Then
                        Stato = StatoLogin.LOGIN
                        LoggedUrl = r1
                        Utx.Globale.Log.Info("login effettuato")
                    Else
                        Stato = StatoLogin.FALLITO
                        Utx.Globale.Log.Info("login fallito")
                    End If
                End If
            End If
        End If
        Return Stato
    End Function

    Private Function LoginOk(Url As String) As Boolean
        If Url IsNot Nothing AndAlso Url.ToLower.StartsWith("https://") AndAlso (Url.ToLower.Contains("errorcode") = False) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

Public Class AutenticazioneUeba : Inherits Autenticazione

    Public Shared ReadOnly Property UrlBase As String = "https://ueba.unipolsai.it"

    Sub New()
        LoginRichiesto = TipoLogin.UEBA
        UrlStartPage = UrlBase
    End Sub
End Class

Public Class AutenticazioneEssig : Inherits Autenticazione

    Sub New(Optional Tipo As TipoLogin = TipoLogin.ESSIG)
        LoginRichiesto = Tipo

        Select Case LoginRichiesto
            Case TipoLogin.ESSIG
                UrlLoginPage = "https://essig.unipolsai.it/my.policy"
            Case TipoLogin.ESSIG_UNISALUTE
                UrlLoginPage = "https://essig.unisalute.it/my.policy"
        End Select

        UrlStartPage = UrlBase() & "essigmenu/home.do"
        If Utx.Setting.Ambiente <> Utx.Enumerazioni.TipoAmbiente.PP Then
            UrlLoginPage = UrlBase() & "my.policy"
        End If
    End Sub

    Public Function UrlBase() As String
        Select Case LoginRichiesto
            Case TipoLogin.ESSIG
                Return "https://essig.unipolsai.it/"
            Case TipoLogin.ESSIG_UNISALUTE
                Return "https://essig.unisalute.it/"
            Case Else
                Return ""
        End Select
    End Function
End Class

Public Class AutenticazioneLiquido : Inherits Autenticazione
    Public Shared ReadOnly Property UrlBase As String = "https://essig.unipolsai.it/"

    Sub New()
        LoginRichiesto = TipoLogin.LIQUIDO
        UrlStartPage = UrlBase & "essigSXCC/ClaimCenter.do"
        If Utx.Setting.Ambiente <> Utx.Enumerazioni.TipoAmbiente.PP Then
            UrlLoginPage = UrlBase & "my.policy"
        End If
    End Sub
End Class

Public Class AutenticazioneSertel : Inherits Autenticazione
    Public Shared ReadOnly Property UrlBase As String = "https://essig.unipolsai.it/"

    Sub New()
        LoginRichiesto = TipoLogin.SERTEL
        UrlStartPage = UrlBase & "websinistri/ricerche.aspx"
        If Utx.Setting.Ambiente <> Utx.Enumerazioni.TipoAmbiente.PP Then
            UrlLoginPage = UrlBase & "my.policy"
        End If
    End Sub
End Class

Public Class AutenticazioneCRM : Inherits Autenticazione
    Public Shared ReadOnly Property UrlBase As String = "https://essig.unipolsai.it/"

    Sub New()
        LoginRichiesto = TipoLogin.CRM
        UrlStartPage = UrlBase & "wps/myportal"
    End Sub
End Class

Public Class AutenticazioneOWA : Inherits Autenticazione
    Public Shared ReadOnly Property UrlBase As String = "https://essig.unipolsai.it/"

    Sub New()
        LoginRichiesto = TipoLogin.OWA
    End Sub

    Public Overrides Function LogIn() As StatoLogin

        If Utx.FunzioniRete.PcInDominio Then
            LoggedUrl = "https://posta.unipolsai.it/owa/"
        Else
            LoggedUrl = String.Format("https://posta.unipolsai.it/CookieAuth.dll?Logon?curl=Z2FOWAZ2F&flags=0&forcedownlevel=0&formdir=1&trusted=0&username={2}%5C{0}&password={1}&SubmitCreds=Accedi", Utente, Password, Dominio)
        End If
        Stato = StatoLogin.LOGIN
        Return Stato
    End Function

    Public Function LogInCasellaEmail(CasellaEmail As String) As StatoLogin

        If Utx.FunzioniRete.PcInDominio Then
            LoggedUrl = "https://posta.unipolsai.it/owa/" & CasellaEmail
        Else
            LoggedUrl = String.Format("https://posta.unipolsai.it/CookieAuth.dll?Logon?curl=Z2FOWAZ2F{3}&flags=0&forcedownlevel=0&formdir=1&trusted=0&username={2}%5C{0}&password={1}&SubmitCreds=Accedi", Utente, Password, Dominio, CasellaEmail)
        End If
        Stato = StatoLogin.LOGIN
        Return Stato
    End Function
End Class
