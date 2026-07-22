Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing

Public Class FormDocPratica

    Friend Pratica As Pratiche

    Private Const Help As String = "Trascinate nella finestra i file da copiare"
    Private tt As New ToolTip

    Private Sub FormDocPratica_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        lbHelp.Text = Help

        With CheckBoxTopMost
            .Image = Risorse.Immagini.Bitmap("spillo16")
            .ImageAlign = ContentAlignment.MiddleCenter
            .Text = ""
            .Checked = True
        End With
        tt.SetToolTip(CheckBoxTopMost, "in primo piano")

        ListBoxDocumenti.DisplayMember = "Nome"
        ListBoxDocumenti.AllowDrop = True

        CaricaDocumentiPratica(Pratica)
    End Sub

    Private Sub CaricaDocumentiPratica(Pratica As Pratiche)

        If String.IsNullOrEmpty(Pratica.FullPathPratica) Then Exit Sub

        ListBoxDocumenti.Items.Clear()

        For Each f As String In Directory.GetFiles(Pratica.FullPathPratica)

            ListBoxDocumenti.Items.Add(New Documenti(Pratica, Path.GetFileName(f)))
        Next

    End Sub

    Private Sub ListBoxDocumenti_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles ListBoxDocumenti.DragDrop
        Try
            Me.TopMost = False
            Cursor.Current = Cursors.WaitCursor

            Dim FileOrigine As String = e.Data.GetData(DataFormats.FileDrop, True)(0)

            Dim d As New Documenti(Pratica, Path.GetFileName(FileOrigine))
            d.AggiungiProtocollo()
            d.CopiaDocumento(FileOrigine, False)

            ListBoxDocumenti.Items.Add(d)
            ListBoxDocumenti.SelectedIndex = IndiceDocumento(d.Nome)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.TopMost = True

            ListBoxDocumenti.BackColor = Color.White
            lbHelp.Text = Help

            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ListBoxDocumenti_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles ListBoxDocumenti.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then

            e.Effect = DragDropEffects.Copy

            ListBoxDocumenti.BackColor = Color.Yellow
            lbHelp.Text = "Ora lasciate il file"
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ListBoxDocumenti_DragLeave(sender As Object, e As System.EventArgs) Handles ListBoxDocumenti.DragLeave
        ListBoxDocumenti.BackColor = Color.White
        lbHelp.Text = Help
    End Sub

    Private Sub ListBoxDocumenti_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ListBoxDocumenti.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then

                If MsgBox(String.Format("<{0}>{1}Confermate la cancellazione?",
                                        Path.GetFileName(ListBoxDocumenti.Text), vbNewLine),
                          MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then

                    File.Delete(ListBoxDocumenti.SelectedItem.FullPathDoc)
                    CaricaDocumentiPratica(Pratica)
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ListBoxDocumenti_MouseDown(sender As Object, e As MouseEventArgs) Handles ListBoxDocumenti.MouseDown
        Try
            ListBoxDocumenti.AllowDrop = False

            If ListBoxDocumenti.SelectedIndex < 0 Then Exit Sub

            Dim fileList As New Collections.Specialized.StringCollection
            fileList.Add(ListBoxDocumenti.SelectedItem.FullPathDoc)

            Dim dataObj As New DataObject
            dataObj.SetFileDropList(fileList)

            ListBoxDocumenti.DoDragDrop(dataObj, DragDropEffects.Copy)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ListBoxDocumenti_MouseEnter(sender As Object, e As System.EventArgs) Handles ListBoxDocumenti.MouseEnter
        ListBoxDocumenti.AllowDrop = True
    End Sub

    Private Sub CheckBoxTopMost_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxTopMost.CheckedChanged
        If CheckBoxTopMost.Checked Then
            CheckBoxTopMost.BackColor = Color.Gold
        Else
            CheckBoxTopMost.BackColor = SystemColors.Control
        End If
        Me.TopMost = CheckBoxTopMost.Checked
    End Sub

    Private Function IndiceDocumento(NomeDocumento As String) As Integer
        If ListBoxDocumenti.Items.Count = 0 Then
            Return -1
        ElseIf NomeDocumento.Trim.Length = 0 Then
            Return 0
        Else
            For k As Integer = 0 To ListBoxDocumenti.Items.Count - 1
                If ListBoxDocumenti.Items(k).Nome = NomeDocumento Then
                    Return k
                End If
            Next
            'non trovato
            Return 0
        End If
    End Function
End Class