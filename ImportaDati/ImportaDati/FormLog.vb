Public Class FormLog

    Private Sub frmLog_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Visible = False
        If e.CloseReason = CloseReason.UserClosing Then e.Cancel = True
    End Sub

End Class