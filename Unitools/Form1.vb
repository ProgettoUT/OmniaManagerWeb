Public Class Form1

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.WindowState = FormWindowState.Maximized
        Me.Icon = Risorse.Immagini.Icon("uniarea")
        Me.Text = "OmniaManager"

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        WebBrowser1.ScriptErrorsSuppressed = True
        WebBrowser1.Navigate("www.repubblica.it")
    End Sub
End Class
