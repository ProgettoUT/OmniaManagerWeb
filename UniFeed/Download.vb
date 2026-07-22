Imports System.Net
Imports System.IO

Public Class Download
    Public ServerName As String = "ftp://10.120.41.129/"

    Public Function Scarica() As Integer
        Return ScaricaDaFtp()
    End Function

    Public Function ScaricaDaFtp() As Integer
        Dim Dirlist As New List(Of String)
        'legge i file presente nella cartella di download
        Try
            Dim request As FtpWebRequest = DirectCast(WebRequest.Create(ServerName), FtpWebRequest)

            request.Method = WebRequestMethods.Ftp.ListDirectory
            request.Credentials = New NetworkCredential(Ut.Globale.UtenteCorrente.UniageUser, Ut.Globale.UtenteCorrente.UniagePw)
            'request.Credentials = New NetworkCredential("158222ao", "Paperona1")

            Dim response = DirectCast(request.GetResponse(), FtpWebResponse)

            Using reader As New StreamReader(response.GetResponseStream)
                Do While reader.Peek <> -1
                    Dirlist.Add(reader.ReadLine)
                Loop
            End Using
            response.Close()
        Catch ex As Exception
        End Try

        'scarica i file nella cartella in arrivo per la successiva fase di importazione
        For Each file In Dirlist
            Try
                Dim request = DirectCast(WebRequest.Create(ServerName & file), FtpWebRequest)
                request.Credentials = New NetworkCredential(Ut.Globale.UtenteCorrente.UniageUser, Ut.Globale.UtenteCorrente.UniagePw)
                request.Method = WebRequestMethods.Ftp.DownloadFile
                request.UseBinary = True

                Dim response = DirectCast(request.GetResponse(), FtpWebResponse)

                Using writer As New StreamWriter(Path.Combine(CartellaArrivo, file))
                    writer.Write(New StreamReader(request.GetResponse().GetResponseStream).ReadToEnd)
                End Using

                Console.WriteLine(file & response.StatusDescription)
                response.Close()
            Catch ex As Exception
            End Try
        Next

        Return 1
    End Function

    Public Function ScaricaDaHttp() As Integer

        Return 0
    End Function
End Class
