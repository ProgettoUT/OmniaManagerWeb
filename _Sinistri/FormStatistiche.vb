Imports System.Windows.Forms

Public Class FormStatistiche

    'tab e page
    Private WithEvents TabStatistiche As New Utx.UtTabControl
    Private WithEvents TabPageStatistiche As New TabPage
    Public WithEvents Statistiche As New ucStatistiche

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.WindowState = Windows.Forms.FormWindowState.Maximized
        Me.Font = Utx.AppFont.Normal
        Me.Text = "Statistiche sinistri"
        Me.Icon = Risorse.Immagini.Icon("torta")

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        Dim tt As New ToolTip
        'statistiche
        With TabPageStatistiche
            .Name = "Statistiche"
            .Text = "Statistiche"
            .Controls.Add(Statistiche)
        End With
        With TabStatistiche
            .Dock = DockStyle.Fill
            'aggiungo le pagine
            .Controls.Add(TabPageStatistiche)
            .Margin = New Padding(0, 10, 0, 0)
            'colore del tab selezionato
            .ColorStyle = Utx.UtTabControl.TabColorStyle.ORANGE
        End With

        Me.Controls.Add(TabStatistiche)
    End Sub
End Class