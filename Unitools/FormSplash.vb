Public Class FormSplash

    Private WithEvents Login As UtControls.ucLogin

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        With Me
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .StartPosition = FormStartPosition.CenterScreen
            .Size = New Size(450, 300)
            .Font = Utx.AppFont.Normal
            .Icon = Risorse.Immagini.Icon("aua")
        End With
        ImpostaControlli()

        'Me.AutoScaleMode = AutoScaleMode.Dpi

        'Utx.Globale.ScalaControlli(Me)
        'Utx.Globale.ScalaFont(Me)

        Visualizzazione(Not Utx.Sessione.Hide)
    End Sub

    Private _PrimoPiano As Boolean
    Public Property PrimoPiano() As Boolean
        Get
            Return _PrimoPiano
        End Get
        Set(value As Boolean)
            _PrimoPiano = value
            Me.TopMost = _PrimoPiano
            If _PrimoPiano = True Then
                Me.ShowInTaskbar = False
            Else
                Me.ShowInTaskbar = True
                Me.Refresh()
            End If
        End Set
    End Property

    Public Sub LoginRichiesto()
        LabelInfo.Hide()
        Login = New UtControls.ucLogin
        tlpMain.Controls.Add(Login)
        tlpMain.SetCellPosition(Login, New TableLayoutPanelCellPosition(0, 1))
        StatusStrip1.Visible = True
        Me.AcceptButton = Login.ButtonOk
    End Sub

    Private Sub ImpostaControlli()
        Panel1.BorderStyle = BorderStyle.FixedSingle
        StatusStrip1.Visible = False
        With PictureBoxLogoUniarea
            .Dock = DockStyle.Fill
            .BackColor = Color.FromArgb(140, 180, 215)
            .SizeMode = PictureBoxSizeMode.CenterImage
            .Image = Risorse.Immagini.Image("logo_splash")
        End With
        With LabelInfo
            .Margin = New Padding(0)
            .Padding = New Padding(0, 20, 0, 20)
            .BackColor = Color.WhiteSmoke
            .Font = Utx.AppFont.Extra(16, FontStyle.Regular)
            .Text = String.Format("Attendi qualche secondo...{0}{0}stiamo configurando il nuovo ambiente{0}per farti lavorare meglio.", Environment.NewLine)
            .TextAlign = ContentAlignment.TopCenter
            .Image = Risorse.Immagini.Bitmap("clock")
            .ImageAlign = ContentAlignment.BottomCenter
        End With
        With LabelVersione
            .Margin = New Padding(0)
            .ForeColor = Color.DimGray
            .BackColor = Color.Gainsboro
            .Text = Utx.NetFunc.VersioneModulo("InfoUt.dll")
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With LabelStato
            .Text = ""
            .BackColor = Color.Transparent
        End With
        LabelCapsLock.BackColor = Color.Transparent
        StatoCapsLock()
    End Sub

    Private Sub StatoCapsLock()
        If My.Computer.Keyboard.CapsLock Then
            LabelCapsLock.ForeColor = Color.Red
            LabelCapsLock.Text = "Caps lock ON"
        Else
            LabelCapsLock.ForeColor = Color.Gray
            LabelCapsLock.Text = "Caps lock OFF"
        End If
    End Sub

    Private Sub FormSplash_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        tlpMain.Controls.Remove(Login)
        LabelInfo.Visible = True
        StatusStrip1.Visible = False
    End Sub

    Private Sub FormSplash_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Refresh()
    End Sub

    Private Sub LabelStato_TextChanged(sender As Object, e As EventArgs) Handles LabelStato.TextChanged
        StatusStrip1.Refresh()
    End Sub

    Private Sub Login_AnnulloLogin() Handles Login.AnnulloLogin
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Login_StatoLogin(Messaggio As String, Stato As Utx.Autenticazione.StatoLogin) Handles Login.StatoLogin
        LabelStato.Text = Messaggio
        If Stato = Utx.Autenticazione.StatoLogin.LOGIN Then
            Login.Hide()
            LabelInfo.Visible = True
            StatusStrip1.Visible = False

            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub LabelInfo_TextChanged(sender As Object, e As EventArgs) Handles LabelInfo.TextChanged
        LabelInfo.Refresh()
    End Sub

    Private Sub FormSplash_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        Me.Refresh()
    End Sub

    Private Sub LabelInfo_VisibleChanged(sender As Object, e As EventArgs) Handles LabelInfo.VisibleChanged
        LabelInfo.Refresh()
    End Sub

    Private Sub PictureBoxLogoUniarea_Click(sender As Object, e As EventArgs) Handles PictureBoxLogoUniarea.Click
        StatusStrip1.BackColor = Color.Moccasin
    End Sub

    Public Sub Visualizzazione(Attiva As Boolean)
        If Attiva = True Then
            Me.StartPosition = FormStartPosition.CenterScreen
        Else
            Me.StartPosition = FormStartPosition.Manual
            Me.Location = New Point(-10000, 0)
            Me.ShowInTaskbar = False
        End If
    End Sub

    Private Sub Login_PressioneTasto(Tasto As Keys) Handles Login.PressioneTasto
        StatoCapsLock()
    End Sub
End Class