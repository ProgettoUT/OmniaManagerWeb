Public Class FormWhatsApp

    Private WithEvents WebView1 As New EO.WebBrowser.WinForm.WebControl

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "WhatsApp web"
    End Sub

    Private Sub ImpostaControlli()
        Me.Controls.Add(WebView1)
        WebView1.Dock = DockStyle.Fill
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebView1.Url = "https://web.whatsapp.com"
        'WebBrowser1.Navigate("https://web.whatsapp.com")

    End Sub

    Private Sub WebView1_LoadCompleted(sender As Object, e As EO.WebBrowser.LoadCompletedEventArgs) Handles WebView1.LoadCompleted
        'MsgBox(WebView1.GetText)
    End Sub
End Class