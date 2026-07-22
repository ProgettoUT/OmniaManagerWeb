Imports System.IO

Public Class FormDebug

    Dim s As New UnicontUpload.IcoUniDataExchangeservice

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        With OpenFileDialog1
            .ShowDialog()

            TextBox1.Text = .FileName
        End With

    End Sub

    Private Sub chkProxy_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkProxy.CheckedChanged
        If chkProxy.Checked Then
            'assegno il proxy e le credenziali
            s.Proxy = Utx.Globale.UniProxy.Proxy
        Else
            s.Proxy = Nothing
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        If TextBox1.Text.Trim.Length = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        s.Timeout = 600000

        'inizializzo la sessione
        Dim Sessione As String = s.OpenSession("Guido", "pw", "02379")

        'invio il file
        Globale.UploadFile(Sessione,
                           TextBox1.Text,
                           "INCASSI",
                           #1/1/1900#,
                           #1/1/1900#)

        'visualizzo la lista file del giorno
        ListaFile(Sessione, Now.Date)

        s.CloseSession(Sessione)

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        Dim Sessione As String = s.OpenSession("Guido", "pw", "02379")

        If Not Globale.ErroreOpenSession(Sessione) Then
            ListaFile(Sessione)
            s.CloseSession(Sessione)
        End If
    End Sub

    Private Sub ListaFile(Sessione As String,
                          Optional DataInizio As Date = #1/1/1900#)

        Try
            Dim doc As New Xml.XmlDocument
            doc.LoadXml(s.GetFileList(Sessione, "INCASSI"))

            ListBox1.Items.Clear()

            For Each n As Xml.XmlElement In doc.DocumentElement

                If n.Attributes("uploaddate").Value.Substring(0, 10) >= DataInizio Then

                    ListBox1.Items.Add(String.Format("File: {0} Dal {1} Al {2} - Trasmissione: {3}",
                                                     n.Attributes("filename").Value,
                                                     n.Attributes("dal").Value.Substring(0, 10),
                                                     n.Attributes("al").Value.Substring(0, 10),
                                                     n.Attributes("uploaddate").Value))
                End If
            Next

        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        Dim Sessione As String = s.OpenSession("Guido", "pw", "02379")
        MsgBox(s.GetMaxDate(Sessione, "02379"))
        s.CloseSession(Sessione)

    End Sub

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Icon = Risorse.Immagini.Icon("upload")
    End Sub
End Class
