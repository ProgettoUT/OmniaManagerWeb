Public Class FormEssig

    Private Sub FormEssig_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'visualizzo la pagina per il cambio password
        If Setting.Ambiente.Tipo = Setting.TipoAmbiente.PP Then
            WebBrowser1.Navigate(String.Format("https://proxysso-bo.unipolgf.it/changepwd/expire.do?user={0}", Setting.Utente.IdUser))
        Else
            WebBrowser1.Navigate(String.Format("http://proxysso.servizi.gr-u.it/changepwd/expire.do?user={0}", Setting.Utente.IdUser))
        End If
    End Sub
End Class