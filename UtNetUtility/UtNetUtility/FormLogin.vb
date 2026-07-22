Imports System.Windows.Forms
Imports System.Drawing

Friend Class FormLogin

    Public Property User As String = ""
    Public Property Password As String = ""

    Dim tt As New ToolTip
    Dim ColoreSfordo As Color = Color.White

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Size = New Size(330, 160)
        Me.WindowState = FormWindowState.Normal
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Padding = New Padding(5)
        Me.Font = New Font("Tahoma", 9)
        Me.Text = "Login"
        Me.Icon = My.Resources.chiavi
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Me.AcceptButton = btnOk

        tt.IsBalloon = True
        tt.SetToolTip(btnVediPw, "Visualizza password")

        With LabelInfo
            .Text = "Inserire il nome utente a la password di Windows per il dominio 'uniage'"
            .TextAlign = ContentAlignment.MiddleLeft
        End With

        txtUser.BackColor = ColoreSfordo
        txtPw.BackColor = ColoreSfordo

        txtUser.SelectionStart = txtUser.Text.Length
    End Sub

    Private Sub FormLogin_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Refresh()
        Me.Focus()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click

        If String.IsNullOrEmpty(txtUser.Text.Trim) Then Exit Sub
        If String.IsNullOrEmpty(txtPw.Text.Trim) Then Exit Sub

        User = txtUser.Text.Trim
        Password = txtPw.Text.Trim

        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnVediPw_Click(sender As System.Object, e As System.EventArgs) Handles btnVediPw.Click

        If btnVediPw.Text = "*" Then
            btnVediPw.Text = "A"
            txtPw.PasswordChar = "*"
            tt.SetToolTip(btnVediPw, "Visualizza password")
        Else
            btnVediPw.Text = "*"
            txtPw.PasswordChar = ""
            tt.SetToolTip(btnVediPw, "Nascondi password")
        End If

    End Sub

    Private Sub txtUser_GotFocus(sender As Object, e As System.EventArgs) Handles txtUser.GotFocus
        txtUser.BackColor = Color.Yellow
    End Sub

    Private Sub txtUser_LostFocus(sender As Object, e As System.EventArgs) Handles txtUser.LostFocus
        txtUser.BackColor = ColoreSfordo
    End Sub

    Private Sub txtPw_GotFocus(sender As Object, e As System.EventArgs) Handles txtPw.GotFocus
        txtPw.BackColor = Color.Yellow
    End Sub

    Private Sub txtPw_LostFocus(sender As Object, e As System.EventArgs) Handles txtPw.LostFocus
        txtPw.BackColor = ColoreSfordo
    End Sub

    Private Sub btnAnnulla_Click(sender As System.Object, e As System.EventArgs) Handles btnAnnulla.Click
        txtUser.Text = ""
        txtPw.Text = ""
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class