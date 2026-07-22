Public Class FormPassword

    Private Sub frmPassword_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.AcceptButton = Button1
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frmPassword_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ControlloPw() = False Then End
    End Sub

    Private Function ControlloPw() As Boolean
        'roberto.5381
        Return (MD5(txtPw.Text) = "E858DAC7BFB8AEAF1C276B3319BE5810")
    End Function

End Class