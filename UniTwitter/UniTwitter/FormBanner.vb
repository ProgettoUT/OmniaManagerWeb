Public Class FormBanner

    Public News As PaginaNews

    Private tt As New ToolTip
    Private WithEvents Timer1 As New Timer

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        With Me
            .Padding = New Padding(0)
            .FormBorderStyle = FormBorderStyle.None
            .ShowInTaskbar = True
            .Size = New Size(News.LarghezzaBanner, News.AltezzaBanner)
            .MinimumSize = New Size(.Width, .Height)
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(Screen.PrimaryScreen.WorkingArea.Right - .Width - 180,
                                  Screen.PrimaryScreen.WorkingArea.Height - .Height - 20)
            .TopMost = True
            .Text = ""
            .Icon = My.Resources.utw
        End With
    End Sub

    Private Sub FormBanner_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Timer1.Dispose()
    End Sub

    Private Sub FormBanner_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Padding = New Padding(0)
        Me.BackColor = Color.Orange

        With ButtonChiudi
            .BackColor = Me.BackColor
            .FlatAppearance.MouseOverBackColor = Color.Gainsboro
            .Text = ""
            .Image = My.Resources.spillo16.ToBitmap
            .ImageAlign = ContentAlignment.TopCenter
            .Size = New Size(21, Me.Height)
            .Location = New Point(Me.Width - .Width, 0)
        End With
        tt.SetToolTip(ButtonChiudi, "Chiudi")

        With wbBanner
            .Dock = DockStyle.None
            .Location = New Point(-11, -16)
            .Size = New Size(Me.Width - 10, (Me.Height - .Top))
            .Margin = New Padding(0)
            .ScriptErrorsSuppressed = True
        End With

        Timer1.Interval = News.Millisecondi
        Timer1.Enabled = True

        wbBanner.Navigate(News.LinkBanner)
    End Sub

    Private Sub ButtonChiudi_Click(sender As Object, e As EventArgs) Handles ButtonChiudi.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub
End Class