Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class EmailLog

    Private Shared CARTELLA_LOGMAIL As String = Path.Combine(CARTELLA_PREVENTIVI, "LOGMAIL")

    Public Sub Add(ByVal preventivo As Prodotto)
        '        If preventivo IsNot Nothing Then
        '            Try
        '                Directory.CreateDirectory(CARTELLA_LOGMAIL)
        '                preventivo.NomeFile = Path.Combine(CARTELLA_LOGMAIL, Globale.licenza.CodiceCompagnia & Globale.licenza.CodiceAgenzia & "_" & preventivo.CodiceProdotto & "_" & Date.Now.Ticks & ".txt")

        '                'Dim fs As FileStream = File.Open(preventivo.NomeFile, FileMode.Create)
        '                'Dim bf As New BinaryFormatter()
        '                'bf.Serialize(fs, preventivo)
        '                'fs.Close()

        '                preventivo.CalcolaLog()
        '                File.WriteAllText(preventivo.NomeFile, logCalcolo)

        '                'Serialize object to a text file.
        '                'Dim x As New Xml.Serialization.XmlSerializer(preventivo.GetType)

        '                'Dim objStreamWriter As New StreamWriter(preventivo.NomeFile)
        '                'x.Serialize(objStreamWriter, preventivo)
        '                'objStreamWriter.Close()

        '            Catch ex As Exception
        '#If DEBUG Then
        '                MsgBox(ex.Message)
        '#End If
        '            End Try

        '        End If
    End Sub

    Private Sub Send()
        '        Dim preventivi As String() = System.IO.Directory.GetFiles(CARTELLA_LOGMAIL, "*.txt")

        '        If preventivi.Length > 0 Then

        '            Try
        '                'If UniCom2.Globale.Ambiente.Tipo = UniCom2.Globale.TipoAmbiente.PP Then
        '                '    Using ApacheMail As New System.Net.Mail.MailMessage()
        '                '        Dim Smtp As New System.Net.Mail.SmtpClient("smtp.gmail.com", 465)
        '                '        Smtp.Credentials = New System.Net.NetworkCredential("log.uniarea@gmail.com", "3rror3log")
        '                '        Smtp.EnableSsl = True

        '                '        Net.WebRequest.DefaultWebProxy = New Proxy().Proxy()
        '                '        ApacheMail.IsBodyHtml = False
        '                '        ApacheMail.From = New System.Net.Mail.MailAddress("preventivo@quotatore.it", "quotatore")
        '                '        ApacheMail.To.Add(New System.Net.Mail.MailAddress("pecoraro.stefano@gmail.com", "Stefano Pecoraro"))
        '                '        ApacheMail.Priority = Net.Mail.MailPriority.Normal
        '                '        ApacheMail.Body = "In allegato il preventivo."
        '                '        ApacheMail.Subject = "Preventivo Quotatore"

        '                '        For Each preventivo In preventivi
        '                '            ApacheMail.Attachments.Add(New System.Net.Mail.Attachment(preventivo))
        '                '        Next
        '                '        Smtp.SendAsync(ApacheMail, "")
        '                '    End Using
        '                'Else
        '                'End If
        '                Dim p As New UniCom2.Postino
        '                p.Ambiente = UniCom2.Postino.TipoAmbiente.PP
        '#If GESIASS Then
        '                p.Smtp = "smptserver"
        '#Else
        '                p.Smtp = "aspmx.l.google.com"
        '#End If
        '                p.Mittente = "log.uniarea@gmail.com"
        '                p.InviaA.Add("pecoraro.stefano@gmail.com")
        '                p.Oggetto = "Preventivo Quotatore"
        '                p.Testo = "In allegato il preventivo."
        '                For Each preventivo In preventivi
        '                    'p.AddAllegato(preventivo)
        '                    p.Testo &= File.ReadAllText(preventivo)
        '                Next
        '                p.InviaMail()
        '                'p.Reset()

        '            Catch ex As Exception
        '                log.utlog.BoxErrore(ex)
        '                Return
        '            End Try

        '            For Each preventivo In preventivi
        '                Try
        '                    File.Delete(preventivo)
        '                Catch ex As Exception
        '                End Try
        '            Next
        '        End If
    End Sub

    Protected Overrides Sub Finalize()
        Send()
        MyBase.Finalize()
    End Sub

End Class
