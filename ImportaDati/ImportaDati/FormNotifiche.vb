Imports System.IO

Public Class frmNotifiche

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(500, 350)
        Me.Padding = New Padding(5)
        Me.Icon = Risorse.Immagini.Icon("update_green")
        Me.Text = String.Format("{0} - dati in arrivo", Utx.Globale.TitoloApp)

        'aggiungo il tab delle notifiche
        Globale.Notifica.Dock = DockStyle.Fill
        Globale.Notifica.SelectedIndex = 0
        Me.Panel1.Controls.Add(Globale.Notifica)
    End Sub

    Private Sub btnChiudi_Click(sender As System.Object, e As System.EventArgs) Handles btnChiudi.Click
        Me.Close()
    End Sub

    Private Sub frmNotifiche_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.TopMost = True
        Me.Visible = True
    End Sub

    Private Sub frmNotifiche_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        My.Computer.Audio.Play(My.Resources.Notifica, AudioPlayMode.Background)
    End Sub
End Class