Public Class FormEmail
    Public Email As String = Nothing

    Public Sub New()
        InitializeComponent()

        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("owa")

        LinkLabelCasellaPersonale.Font = Utx.AppFont.Bold
        LinkLabelLink0.Font = Utx.AppFont.Bold
        LinkLabelLink1.Font = Utx.AppFont.Bold
        LinkLabelLink2.Font = Utx.AppFont.Bold
        LinkLabelLink3.Font = Utx.AppFont.Bold

        TextBoxCasellaPersonale.Font = Utx.AppFont.Bold
        TextBoxLink0.Font = Utx.AppFont.Bold
        TextBoxLink1.Font = Utx.AppFont.Bold
        TextBoxLink2.Font = Utx.AppFont.Bold
        TextBoxLink3.Font = Utx.AppFont.Bold

        TextBoxCasellaPersonale.Text = "Casella personale di " & Utx.Globale.UtenteCorrente.UniageUser

        TextBoxLink0.Text = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CASELLA_EMAIL_LINK0)
        TextBoxLink1.Text = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CASELLA_EMAIL_LINK1)
        TextBoxLink2.Text = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CASELLA_EMAIL_LINK2)
        TextBoxLink3.Text = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CASELLA_EMAIL_LINK3)

        TextBoxCasellaTextChanged(TextBoxLink0, LinkLabelLink0)
        TextBoxCasellaTextChanged(TextBoxLink1, LinkLabelLink1)
        TextBoxCasellaTextChanged(TextBoxLink2, LinkLabelLink2)
        TextBoxCasellaTextChanged(TextBoxLink3, LinkLabelLink3)

        Me.Icon = Risorse.Immagini.Icon("owa")
    End Sub

    Private Sub LinkLabelCasellaPersonale_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelCasellaPersonale.LinkClicked
        ImpostaEmailEtChiudi("")
    End Sub
    Private Sub LinkLabellink0_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelLink0.LinkClicked
        ImpostaEmailEtChiudi(TextBoxLink0.Text)
    End Sub
    Private Sub LinkLabellink1_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelLink1.LinkClicked
        ImpostaEmailEtChiudi(TextBoxLink1.Text)
    End Sub
    Private Sub LinkLabellink2_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelLink2.LinkClicked
        ImpostaEmailEtChiudi(TextBoxLink2.Text)
    End Sub
    Private Sub LinkLabellink3_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelLink3.LinkClicked
        ImpostaEmailEtChiudi(TextBoxLink3.Text)
    End Sub

    Private Sub ImpostaEmailEtChiudi(email As String)
        Me.Email = email
        Close()
    End Sub

    Private Sub TextBoxCasellaAgenzia_TextChanged(sender As Object, e As EventArgs) Handles TextBoxLink0.TextChanged
        TextBoxCasellaTextChanged(TextBoxLink0, LinkLabelLink0)
    End Sub
    Private Sub TextBoxLink1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxLink1.TextChanged
        TextBoxCasellaTextChanged(TextBoxLink1, LinkLabelLink1)
    End Sub
    Private Sub TextBoxLink2_TextChanged(sender As Object, e As EventArgs) Handles TextBoxLink2.TextChanged
        TextBoxCasellaTextChanged(TextBoxLink2, LinkLabelLink2)
    End Sub
    Private Sub TextBoxLink3_TextChanged(sender As Object, e As EventArgs) Handles TextBoxLink3.TextChanged
        TextBoxCasellaTextChanged(TextBoxLink3, LinkLabelLink3)
    End Sub

    Private Sub TextBoxCasellaTextChanged(TextBoxLink As Windows.Forms.TextBox, LinkLabelLink As Windows.Forms.LinkLabel)
        LinkLabelLink.Enabled = (TextBoxLink.Text.Length > 0)
    End Sub

    Private Sub FormEmail_FormClosed(sender As Object, e As Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CASELLA_EMAIL_LINK0, TextBoxLink0.Text)
        Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CASELLA_EMAIL_LINK1, TextBoxLink1.Text)
        Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CASELLA_EMAIL_LINK2, TextBoxLink2.Text)
        Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CASELLA_EMAIL_LINK3, TextBoxLink3.Text)
    End Sub
End Class