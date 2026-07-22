Imports System.Drawing
Imports System.Net
Imports System.IO
Imports System.Reflection
Imports System.Text

Public MustInherit Class Autenticazione

    Public Enum StatoLogin
        LOGIN
        LOGOUT
        FALLITO
        RETE_NON_DISPONIBILE
    End Enum

    Public Property CookieContainer As Net.CookieContainer
    Public Property Utente As String
    Public Property Password As String
    Public Property Dominio As String
    Public Property Stato As StatoLogin = StatoLogin.LOGOUT
    Public Property UniProxy As New Proxy
    Public Property UrlBase As String = Nothing

    Public Function LogIn(ByVal Utente As String, ByVal Password As String, ByVal Dominio As String) As StatoLogin

        If String.IsNullOrEmpty(Utente) OrElse String.IsNullOrEmpty(Password) Then

            Using f As New FormLogin()

                f.ShowDialog()

                If f.DialogResult = Windows.Forms.DialogResult.OK Then
                    'login uniage
                    Utente = Replace(f.User, "uniage\", "", , , CompareMethod.Text)
                    Password = f.Password
                    Dominio = "uniage"

                    UtNetUtility.Setting.Utente.UniageUser = Utente
                    UtNetUtility.Setting.Utente.UniagePw = Password

                    Environment.SetEnvironmentVariable("UNITOOLS_UNIAGE_USER", Utente)
                    Environment.SetEnvironmentVariable("UNITOOLS_UNIAGE_PW", Password)
                Else
                    Stato = StatoLogin.FALLITO
                    Return Stato
                End If
            End Using
        End If

        UniProxy.AssegnaCredenziali(Utente, Password)

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

    Public MustOverride Function LogIn() As StatoLogin
    Public MustOverride Function LogOut() As StatoLogin
    Public MustOverride Function IsLogged() As StatoLogin
    Public MustOverride Function GetLoggedUrl() As String

    Public Function GetCookies(CookieContainer As CookieContainer) As CookieCollection
        Dim cookieCollection As New CookieCollection()

        Dim table As Hashtable = CookieContainer.GetType().InvokeMember("m_domainTable",
                                                                        BindingFlags.NonPublic Or
                                                                        BindingFlags.GetField Or
                                                                        BindingFlags.Instance,
                                                                        Nothing,
                                                                        CookieContainer,
                                                                        New Object() {})

        For Each key In table.Keys
            Dim skey As String = key.ToString()
            Dim list As SortedList = table(skey).GetType().InvokeMember("m_list",
                                                                    BindingFlags.NonPublic Or
                                                                    BindingFlags.GetField Or
                                                                    BindingFlags.Instance,
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

    Public Function CallWeb(ByVal url As String, Optional ByVal postData As String = Nothing) As String
        Globale.Log.AddLog(url.ToString)
        Try
            Dim request As HttpWebRequest = HttpWebRequest.Create(url)
            request.AllowAutoRedirect = False
            request.Proxy = UniProxy.Proxy

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

            request.Timeout = 30000 '30 secondi

            ' Get the response.
            Dim response As HttpWebResponse = request.GetResponse()
            CookieContainer.Add(response.Cookies)

            Globale.Log.AddLog("status: " & response.StatusDescription)

            Select Case response.StatusCode
                Case HttpStatusCode.Found, HttpStatusCode.Moved, HttpStatusCode.MovedPermanently, HttpStatusCode.TemporaryRedirect
                    Dim newUrl = response.Headers("Location")
                    If newUrl.StartsWith("/") Then
                        Dim a = New Uri(url)
                        newUrl = a.AbsoluteUri.Substring(0, a.AbsoluteUri.LastIndexOf(a.AbsolutePath)) & newUrl
                    End If
                    response.Close()

                    Return CallWeb(newUrl, postData)
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
            Globale.Log.BoxErrore(ex, False)
            Return Nothing
        End Try
    End Function

    Public Function CredenzialiUniageInserite() As Boolean
        Return (String.IsNullOrEmpty(Setting.Utente.UniageUser) = False) And
               (String.IsNullOrEmpty(Setting.Utente.UniagePw) = False)
    End Function
End Class

Public Class AutenticazioneEssig
    Inherits Autenticazione

    Public Shadows Event StatoConnessione(ByVal Stato As LoginEventArgs)
    Dim e As New LoginEventArgs

    Sub New()
        UrlBase = "https://essig.unipolsai.it/"
    End Sub

    Public Overrides Function LogIn() As StatoLogin

        If IsLogged() = StatoLogin.LOGIN Then
            Return Me.Stato
        End If

        CookieContainer = New Net.CookieContainer
        Dim r0 = CallWeb(UrlBase & "essigmenu/home.do")

        If r0 Is Nothing Then
            Me.Stato = StatoLogin.RETE_NON_DISPONIBILE
        ElseIf Not r0.Contains("SECURID_AUTH_STATE_START") Then
            Me.Stato = StatoLogin.FALLITO
        Else
            Dim r1 As String
            If UtNetUtility.Setting.Ambiente.Tipo = Setting.TipoAmbiente.PP Then
                r1 = CallWeb("https://loginapm.unipolsai.it/my.policy",
                             String.Format("username={0}&password={1}&domain={2}&vhost=standard", Utente, Password, Dominio))
            Else
                r1 = CallWeb("https://essig.unipolsai.it/my.policy",
                             String.Format("username={0}&password={1}&domain={2}&vhost=standard", Utente, Password, Dominio))
            End If

            If r1 Is Nothing Then
                Me.Stato = StatoLogin.FALLITO
            ElseIf r1.Contains("ECI_ERR_NO_CICS") = True Then
                Me.Stato = StatoLogin.FALLITO
            ElseIf r1.ToUpper.Contains("href=""/essigmenu/danni/logoff.do""".ToUpper) = True Then
                Me.Stato = StatoLogin.LOGIN
            Else
                Me.Stato = StatoLogin.FALLITO
            End If
        End If
        Return Me.Stato
    End Function

    Public Overrides Function IsLogged() As StatoLogin
        If CookieContainer IsNot Nothing Then
            Dim r0 = CallWeb(UrlBase & "essigmenu/home.do")
            If r0 Is Nothing Then
                Me.Stato = StatoLogin.RETE_NON_DISPONIBILE
            ElseIf r0.Contains("ECI_ERR_NO_CICS") = True Then
                Me.Stato = StatoLogin.FALLITO
            ElseIf r0.ToUpper.Contains("href=""/essigmenu/danni/logoff.do""".ToUpper) = True Then
                Me.Stato = StatoLogin.LOGIN
            Else
                Me.Stato = StatoLogin.LOGOUT
            End If
        Else
            Me.Stato = StatoLogin.LOGOUT
        End If
        Return Me.Stato
    End Function

    Public Overrides Function LogOut() As StatoLogin
        CookieContainer = New CookieContainer
        Dim r = CallWeb(UrlBase & "essigmenu/danni/logoff.do")
        Me.Stato = StatoLogin.LOGOUT
        Return Me.Stato
    End Function

    Public Overrides Function GetLoggedUrl() As String
        Dim CookieCollection = GetCookies(CookieContainer)

        Dim MRHSession = CookieCollection("MRHSession").Value
        Return UrlBase & "F5Networks-SSO-Resp?SSO_ORIG_URI=aHR0cHM6Ly9lc3NpZy51bmlwb2xzYWkuaXQvZXNzaWdtZW51L2hvbWUuZG8%3d&F5SSO_SID=" & MRHSession
    End Function
End Class

Public Class LoginEventArgs

    Inherits EventArgs

    Public Property Stato As String
End Class