Public Class FormLoginOWeb

    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.Size = New Drawing.Size(380, 160)
        Me.Font = Utx.AppFont.Normal
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.Text = "Login OM web"

        With LabelMessaggio
            .Text = "Inserire le credenziali per l'accesso a omnia manager web"
            .TextAlign = Drawing.ContentAlignment.MiddleCenter
        End With
        TextBoxPwOW.PasswordChar = "*"
        CheckBoxPW.Font = Utx.AppFont.Bold
    End Sub

    Private mUserOW As String
    Public ReadOnly Property UserOW() As String
        Get
            Return mUserOW
        End Get
    End Property

    Private mPwOW As String
    Public ReadOnly Property PwOW() As String
        Get
            Return mPwOW
        End Get
    End Property

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        Try
            mUserOW = TextBoxUserOW.Text.Trim
            mPwOW = TextBoxPwOW.Text.Trim

            If String.IsNullOrEmpty(mUserOW) OrElse String.IsNullOrEmpty(mPwOW) Then
                MsgBox("Le credenziali inserite non sono valide.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Me.TextBoxUserOW.Focus()
            Else
                SalvaPasswordOW(mUserOW, mPwOW)
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Sub SalvaPasswordOW(User As String, Password As String)
        Try
            Dim wrapper As New Utx.Crypto("19011957")

            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.OW1, wrapper.EncryptData(User))
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.OW2, wrapper.EncryptData(Password))
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormLoginOWeb_Shown(sender As Object, e As EventArgs) Handles Me.Shown
#If DEBUG Then
        TextBoxUserOW.Text = "ANGIOI PAOLO"
        TextBoxPwOW.Text = "OmniaManager2019!"
#End If
        Me.TopMost = True
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub CheckBoxPW_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxPW.CheckedChanged
        If CheckBoxPW.Checked = True Then
            TextBoxPwOW.PasswordChar = ""
        Else
            TextBoxPwOW.PasswordChar = "*"
        End If
    End Sub
End Class