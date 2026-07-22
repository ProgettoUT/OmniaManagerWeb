Public Class FormTargaPolizza
    Public Targa As String
    Public Ramo As Integer
    Public Polizza As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Text = ""
        Me.Font = Utx.AppFont.Normal
        Me.TopMost = True

        LabelTitolo.Font = Utx.AppFont.Bold
        ButtonClose.Font = Utx.AppFont.Bold
        txtTarga.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        txtRamo.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        txtPolizza.BorderStyle = Windows.Forms.BorderStyle.FixedSingle

        txtTarga.Font = Utx.AppFont.Bold
        txtRamo.Font = Utx.AppFont.Bold
        txtPolizza.Font = Utx.AppFont.Bold

        ButtonCerca.Font = Utx.AppFont.Bold
    End Sub

    Private Sub FormTargaPolizza_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtTarga.Focus()
    End Sub

    Private Sub ButtonCerca_Click(sender As Object, e As EventArgs) Handles ButtonCerca.Click
        If Trim(txtRamo.Text).Length > 0 Then
            Ramo = CInt(txtRamo.Text)
        End If

        If Trim(txtPolizza.Text).Length > 0 Then
            Polizza = CInt(txtPolizza.Text)
        End If

        Targa = txtTarga.Text.Replace(" ", "").ToUpper
        DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        DialogResult = Windows.Forms.DialogResult.No
    End Sub
End Class