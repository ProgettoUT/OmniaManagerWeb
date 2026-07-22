Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports System.Net

Module Funzioni

    'Public Function PcInDominio() As Boolean
    '    Return (Environment.UserDomainName.ToUpper = "UNIAGE" OrElse Environment.UserDomainName.ToUpper = "AURAGE")
    'End Function

    Friend Sub SvuotaDir(PathCartella As String)
        Try
            If Directory.Exists(PathCartella) Then
                For Each f As String In Directory.GetFiles(PathCartella)
                    File.Delete(f)
                Next
            End If
        Catch ex As Exception
            Log.Info("Errore nello svuotare la dir " + PathCartella + ": " + ex.Message)
        End Try
    End Sub

    'Friend Function GetMD5(FilePath As String) As String
    '    Try
    '        If File.Exists(FilePath) = False Then
    '            Return "-ERR: file mancante"
    '        End If

    '        Dim md5 As New MD5CryptoServiceProvider

    '        Using f As New FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
    '            md5.ComputeHash(f)
    '            f.Close()
    '        End Using

    '        Dim hash As Byte() = md5.Hash
    '        Dim buffer As StringBuilder = New StringBuilder

    '        For Each hashByte As Byte In hash
    '            buffer.Append(String.Format("{0:X2}", hashByte))
    '        Next

    '        Return buffer.ToString()

    '    Catch ex As Exception
    '        Return "-ERR: " & ex.Message
    '    End Try
    'End Function

    Friend Function Url2File(Url As String) As String
        Try
            Dim Campi() As String = Url.Split("/")
            Return Campi(UBound(Campi))
        Catch ex As Exception
            Return "Nome file ND"
        End Try
    End Function

    Friend Function DownloadFile(UrlOrigine As String, UrlDest As String) As Boolean
        Try
            Using wc As New WebClient
                Dim NomeFile As String = Path.GetFileName(String.Format("download {0}", Path.GetFileNameWithoutExtension(UrlDest)).Replace("+", ":").Replace("=", "\"))

                IconaNotifica.Icon = My.Resources.liveupdate
                IconaNotifica.Text = Left(NomeFile, 60)
                IconaNotifica.Visible = True

                'se siamo sulla intranet imposto le credenziali e il proxy
                wc.Proxy = Utx.Globale.UniProxy.Proxy
                'non utilizzare la cache
                wc.CachePolicy = New Cache.RequestCachePolicy(Cache.RequestCacheLevel.NoCacheNoStore)
                'scarico il file
                wc.DownloadFile(UrlOrigine, UrlDest)
            End Using

            Return True

        Catch ex As Exception
            Log.Info(String.Format("Errore nel download del file {0} in {1}", Url2File(UrlOrigine), UrlDest), ex)
            'cancella il file se esiste perchè potrebbe essere corrotto
            If File.Exists(UrlDest) Then File.Delete(UrlDest)
            Return False
        End Try
    End Function

    'Public Function ImpostaAmbiente(Ambiente As String) As Globale.TipoAmbiente
    '    Select Case Ambiente
    '        Case "DIR" : Return Globale.TipoAmbiente.DIR
    '        Case "PP" : Return Globale.TipoAmbiente.PP
    '        Case "PP2DIR" : Return Globale.TipoAmbiente.PP2DIR
    '    End Select
    'End Function
End Module
