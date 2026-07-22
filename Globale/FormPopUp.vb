Imports Microsoft.Web.WebView2.WinForms
Imports Microsoft.Web.WebView2.Core

Imports System.Drawing
Imports System.Windows.Forms

Public Class FormPopUp

    Public WithEvents Wv As New WebView2
    Public UrlDoc As String

    Sub New(Titolo As String)

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height)
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width / 2, 0)
        Me.Text = Titolo
        Me.Icon = Risorse.Immagini.Icon("unitools")
        Me.TopMost = True

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        Try
            Wv.Dock = Windows.Forms.DockStyle.Fill
            Me.Controls.Add(Wv)
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Async Sub FormPopUp_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Dim environmentOptions As New CoreWebView2EnvironmentOptions With {.Language = "it-IT"}
            Dim environment As CoreWebView2Environment = Await CoreWebView2Environment.CreateAsync(Nothing, Nothing, environmentOptions)
            Await Wv.EnsureCoreWebView2Async(environment)

            Wv.Source = New Uri(UrlDoc)
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Class