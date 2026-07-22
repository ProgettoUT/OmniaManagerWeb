Public Class NoteBox
    Private mTextNote As String

    Public Property TextNote() As String
        Get
            Return mTextNote
        End Get
        Set(ByVal value As String)
            mTextNote = value
            toolTip1.SetToolTip(PictureBox1, mTextNote)
            toolTip1.SetToolTip(lblNote, mTextNote)
        End Set
    End Property

    Public Property Caption() As String
        Get
            Return lblNote.Text
        End Get
        Set(ByVal value As String)
            lblNote.Text = value
        End Set
    End Property

    Public Event NoteChanged(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub cmdNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Note.txtNote.Text = TextNote
        Note.ShowDialog()
        TextNote = Note.txtNote.Text
        RaiseEvent NoteChanged(Me, New EventArgs())
    End Sub

    Private Sub lblNote_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblNote.LinkClicked
        cmdNote_Click(sender, e)
    End Sub

End Class
