Imports System.IO

Public Class OmWeb

    Public Enum TipoFileInviato
        GENERICO
        AGGIORNA_INCASSI
    End Enum

    Public Shared Sub InviaDataSet(Agenzia As String, ds As DataSet, Optional AttendiFine As Boolean = False)
        Dim th As New Threading.Thread(Sub()
                                           Using s As New Utx.ServiziOMW.ServizioDatiOMW
                                               s.Proxy = Utx.Globale.UniProxy.Proxy
                                               s.InviaDataset(Agenzia, ds, Utx.Globale.Token)
                                               Utx.Globale.Log.Info("invio dati completato")
                                           End Using
                                       End Sub)
        th.Start()
        If AttendiFine Then
            th.Join()
        End If
    End Sub

    Public Shared Sub InviaFile(Agenzia As String, NomeFile As String, Evento As String, Sovrascrivi As Boolean)
        Invia(Agenzia, NomeFile, Evento, Sovrascrivi)
    End Sub

    Private Shared Function Invia(Agenzia As String, NomeFile As String, Evento As String, Sovrascrivi As Boolean) As Boolean
        Try
            If File.Exists(NomeFile) Then
                Utx.Globale.Log.Info("invio il file: {0}", {NomeFile})

                Dim TagName As String = Path.Combine(Path.GetDirectoryName(NomeFile), String.Format("{0}.{1}", Evento, Path.GetFileName(NomeFile)))
                File.Copy(NomeFile, TagName, True)

                Dim FileZip As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, Path.GetFileNameWithoutExtension(NomeFile) & ".zip")
                File.Delete(FileZip)

                Utx.Globale.Log.Info("zippo il file, attendere...")
                Utx.LibreriaZip.SevenZip.ZipFile(TagName, FileZip)

                Dim CartellaUpload As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Upload")
                Directory.CreateDirectory(CartellaUpload)
                Utx.NetFunc.SvuotaCartella(CartellaUpload)

                Dim fileName As String = FileZip
                Dim fileSizeInMB As Integer = 20
                Dim baseFileName As String = Path.GetFileName(fileName)
                Dim MaxSize As Integer = fileSizeInMB * (1024 * 1024)
                Dim fsBuffer As Byte() = New Byte(1023) {}
                Using fileStream As New FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read)
                    Dim totalFileParts As Integer = 0
                    If fileStream.Length < MaxSize Then
                        totalFileParts = 1
                    Else
                        Dim preciseFileParts As Single = (CSng(fileStream.Length) / CSng(MaxSize))
                        totalFileParts = CInt(Math.Ceiling(preciseFileParts))
                    End If

                    Dim filePartCount As Integer = 0
                    While fileStream.Position < fileStream.Length
                        Dim filePartName As String = String.Format("{0}.part_{1}-{2}", baseFileName, (filePartCount + 1).ToString(), totalFileParts.ToString())
                        filePartName = Path.Combine(CartellaUpload, filePartName)
                        Using fsFilePart As New FileStream(filePartName, FileMode.Create)
                            Dim bytesRemaining As Integer = MaxSize
                            Dim bytesRead As Integer = 0
                            While bytesRemaining > 0
                                bytesRead = fileStream.Read(fsBuffer, 0, Math.Min(bytesRemaining, 1024))

                                If bytesRead = 0 Then
                                    Exit While
                                End If

                                fsFilePart.Write(fsBuffer, 0, bytesRead)
                                bytesRemaining -= bytesRead
                            End While
                        End Using
                        filePartCount += 1
                    End While
                End Using

                'debug
                'Dim Destinazione As String = Path.Combine(Utx.Globale.Paths.CartellaLogs, Path.GetFileName(FileZip))
                'Dim partFiles As String() = Directory.GetFiles(Utx.Globale.Paths.CartellaLogs)
                'Array.Sort(partFiles)
                'Using fs As New FileStream(Destinazione, FileMode.Create)
                '    For Each file As String In partFiles
                '        Utx.Globale.Log.Info("chunk: {0}", {file})
                '        Using Chunk As New FileStream(file, FileMode.Open)
                '            Chunk.CopyTo(fs)
                '        End Using
                '        System.IO.File.Delete(file)
                '    Next
                'End Using

                Using s As New Utx.ServiziOMW.ServizioDatiOMW
                    s.Proxy = Utx.Globale.UniProxy.Proxy
#If DEBUG Then
                    's.Proxy = New System.Net.WebProxy(Utx.Globale.UniProxy.UrlProxy, Utx.Globale.UniProxy.PortaProxy)
                    's.Proxy.Credentials = New Net.NetworkCredential(Utx.Globale.UtenteCorrente.UniageUser,
                    '                                                Utx.Globale.UtenteCorrente.UniagePw,
                    '                                                Utx.Globale.UtenteCorrente.Dominio)
#End If
                    Dim CartellaDest As String = Guid.NewGuid.ToString

                    For Each fileChunk In Directory.GetFiles(CartellaUpload)
                        Dim b As Byte() = File.ReadAllBytes(fileChunk)
                        Utx.Globale.Log.Info("Invio chunk: {0}", {fileChunk})
                        'invio il chunk
                        If s.UploadFileChunk(Agenzia,
                                             b,
                                             Path.GetFileName(fileChunk),
                                             CartellaDest,
                                             Sovrascrivi,
                                             Utx.Globale.Token) = False Then
                            MsgBox("Errore nell'invio del file", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                        End If
                        File.Delete(fileChunk)
                        System.Windows.Forms.Application.DoEvents()
                    Next
                    Utx.Globale.Log.Info("invio file terminato")
                End Using
                GC.Collect()

                File.Delete(TagName)
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function
End Class
