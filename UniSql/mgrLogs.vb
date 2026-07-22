Imports System.Net
Imports System.Net.Mail

Module mgrLogs
    Public CARTELLA_LOGS As String

    Public Sub maErrorFound( _
                     sCallingModName As String, _
                     sCallingProcName As String, _
                     lErrNumber As Long, _
                     sErrDescription As String, _
                     sErrSource As String, _
                     Optional sParam As String = vbNullString _
                         )

        Dim sErr As String

        sErr = Now & ": " _
                        & sCallingModName & "." & sCallingProcName & ": Errore n° " _
                        & lErrNumber & " " & sErrDescription & " " _
                        & IIf(sErrSource = "", "", "(" & sErrSource & ")") _
                        & IIf(sParam = "", "", vbNewLine & sParam)


        My.Computer.FileSystem.WriteAllText(CARTELLA_LOGS & "Error.log", sErr, True)
#If DEBUG Then
        MsgBox(sErr)
#Else
        sendMail(sCallingModName, sCallingProcName, lErrNumber, sErrDescription, sErrSource, sParam)
#End If
    End Sub

#If TRACE Then
    Public Sub maTrace(sParam As String)
        My.Computer.FileSystem.WriteAllText(CARTELLA_LOGS & "Trace.log", Now & ": " & sParam, True)
    End Sub
#End If

    Public Sub sendHttp( _
                     sCallingModName As String, _
                     sCallingProcName As String, _
                     lErrNumber As Long, _
                     sErrDescription As String, _
                     sErrSource As String, _
                     Optional sParam As String = vbNullString _
                         )
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        'Dim reader As StreamReader

        Try
            ' Create the web request  
            request = DirectCast(WebRequest.Create("http://developer.yahoo.com/"), HttpWebRequest)

            ' Get response  
            response = DirectCast(request.GetResponse(), HttpWebResponse)

            ' Get the response stream into a reader  
            'reader = New StreamReader(response.GetResponseStream())

            ' Console application output  
            'Console.WriteLine(reader.ReadToEnd())
        Finally
            If Not response Is Nothing Then response.Close()
        End Try
    End Sub

    Public Sub sendMail( _
                 sCallingModName As String, _
                 sCallingProcName As String, _
                 lErrNumber As Long, _
                 sErrDescription As String, _
                 sErrSource As String, _
                 Optional sParam As String = vbNullString _
                     )
        Try

            Dim sErr As String = Now & ": " _
                            & sCallingModName & "." & sCallingProcName & ": Errore n° " _
                            & lErrNumber & " " & sErrDescription & " " _
                            & IIf(sErrSource = "", "", "(" & sErrSource & ")") _
                            & IIf(sParam = "", "", vbNewLine & sParam)

            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New Net.NetworkCredential("log.uniarea@gmail.com", "3rror3log")
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            mail = New MailMessage()
            mail.From = New MailAddress("log.uniarea@gmail.com")
            mail.To.Add("log.uniarea@gmail.com")
            mail.Subject = "Estrattore"
            mail.Body = sErr
            SmtpServer.Send(mail)
        Catch ex As Exception
        End Try
    End Sub
End Module
