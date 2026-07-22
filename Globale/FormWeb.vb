Imports System.Windows.Forms

Public Class FormWeb

    Public Url As String
    Public BodyText As String

    Private WithEvents wb As New WebBrowser

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.ShowInTaskbar = False
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub wb_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wb.DocumentCompleted
        BodyText = wb.Document.Body.InnerText
        Me.Close()
    End Sub

    Private Sub FormWeb_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        wb.Navigate(Url)
    End Sub
End Class