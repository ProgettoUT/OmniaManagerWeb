Imports Microsoft.Web.WebView2.WinForms
Imports Microsoft.Web.WebView2.Core

Public Class FormDebugWeb

    Public Property Url As String

    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.WindowState = Windows.Forms.FormWindowState.Maximized
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'Dim newCookie As CoreWebView2Cookie = WebView2.CoreWebView2.CookieManager.CreateCookie("MyCookieName", "MyCookieValue", ".example.com", "/")        ' Nome
            '' Valore
            '' Dominio (nota il punto iniziale per sottodomini)
            '' Percorso

            'newCookie.IsHttpOnly = True
            'newCookie.IsSecure = True
            'newCookie.Expires = Date.Now.AddDays(7) ' Scadenza tra 7 giorni

            'WebView2.CoreWebView2.CookieManager.AddOrUpdateCookie(newCookie)

            Await WebViewDebug.EnsureCoreWebView2Async()
            WebViewDebug.CoreWebView2.NavigateToString(Url)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class