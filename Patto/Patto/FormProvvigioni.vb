Public Class FormProvvigioni

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Size = New Size(388, 568)
        Me.Padding = New Padding(0)
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(40, 100)
        Me.TopMost = True
        Me.Text = "Aliquota provvigionali RCA"
        Me.ShowInTaskbar = True
    End Sub

    Private Sub FormProvvigioni_Load(sender As Object, e As EventArgs) Handles Me.Load
        PictureBox1.Margin = New Padding(0)
        PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub
End Class