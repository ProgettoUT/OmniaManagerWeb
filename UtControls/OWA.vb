Imports System.Windows.Forms

Public Class OWA
    Inherits TabPage

    Public WithEvents wbOWA As New AxSHDocVw.AxWebBrowser
    Private WithEvents bw As New System.ComponentModel.BackgroundWorker

    Sub New()
        Me.Name = "Owa"
        Me.Text = "Posta"

        wbOWA.Dock = DockStyle.Fill
        Me.Controls.Add(wbOWA)
    End Sub

    Public Sub Naviga()
        wbOWA.Silent = True
        If wbOWA.LocationURL = "" Then
            wbOWA.Navigate(IO.Path.Combine(Utx.Globale.Paths.CartellaModelli, "ut_wait.html"))
        End If
        Dim f As New FormEmail
        f.ShowDialog()
        Dim email As String = f.Email
        f = Nothing

        bw.RunWorkerAsync(email)
    End Sub

    Public Function EsistePaginaWeb() As Boolean
        Return (wbOWA.Document IsNot Nothing)
    End Function

    Public Shared Function PaginaOWA(ByRef Tab As TabControl) As OWA

        Dim Pagina As OWA = Nothing

        For Each p As TabPage In Tab.TabPages
            If TypeOf p Is OWA Then
                Pagina = p
            End If
        Next

        Return Pagina
    End Function

    Private Sub wbUeba_NewWindow2(sender As Object, e As AxSHDocVw.DWebBrowserEvents2_NewWindow2Event) Handles wbOWA.NewWindow2
        Dim f As New UtControls.FormPopUp
        e.ppDisp = f.wbPopUp.Application
        f.Visible = True
    End Sub

    Private Sub bw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw.DoWork
        Dim email = CType(e.Argument, String)

        If email Is Nothing Then
            wbOWA.Navigate("about:blank")
        ElseIf email = "" Then
            Dim LoginOWA = New Utx.AutenticazioneOWA
            LoginOWA.LogIn()
            wbOWA.Navigate(LoginOWA.LoggedUrl)
        ElseIf email.EndsWith("@agenzia.unipol.it") OrElse
               email.ToLower.EndsWith("@agenzia.unipolsai.it") OrElse
               email.ToLower.EndsWith("@agenzia.unipolassicurazioni.it") Then
            Dim LoginOWA = New Utx.AutenticazioneOWA
            LoginOWA.LogInCasellaEmail(email)
            wbOWA.Navigate(LoginOWA.LoggedUrl)
        Else
            wbOWA.Navigate(email)
        End If
    End Sub
End Class
