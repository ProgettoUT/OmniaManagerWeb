Imports System.Net

Public Class Servizi

    Private Shared LinkToCall As String = "http://admin:{0}@{1}/cgi-bin/cgiServer.exx?key={2}OK"

    Public Shared Sub Chiama(NumeroTelefonico As String)
        Try
            If Globale.UtenteCorrente.Telefono Is Nothing Then
                MsgBox("Per attivare la funzione ClickToCall avviare il centralino in Unitools >> Utilità", MsgBoxStyle.Information)
                Globale.Log.Info("Utente centralino non selezionato")
            Else
                NumeroTelefonico = NumeroTelefonico.Trim
                'tolgo +39
                If NumeroTelefonico.StartsWith("+39") Then
                    NumeroTelefonico = NumeroTelefonico.Substring(3)
                End If
                'pulisco da caratteri non numerici
                NumeroTelefonico = Utx.NetFunc.EstraiCaratteri(NumeroTelefonico, Utx.NetFunc.TipoCaratteri.SoloNumerici)
                'chiamo
#If DEBUG Then
                NumeroTelefonico = "0818969933"
#End If
                If Globale.UtenteCorrente.Telefono.Ping Then
                    Dim Link As String = String.Format(LinkToCall, Globale.UtenteCorrente.Telefono.Password, Globale.UtenteCorrente.Telefono.IpTelefono, NumeroTelefonico)
                    Globale.Log.Trace(Link)
                    'chiama

                    Dim wb As New WebBrowser
                    wb.Navigate(Link)
                Else
                    Dim url As String = Regista.ListenerTcp.GetUrlBase("Chiama")
                    url &= "?password=" & Globale.UtenteCorrente.Telefono.Password
                    url &= "&ip=" & Globale.UtenteCorrente.Telefono.IpTelefono
                    url &= "&numero=" & NumeroTelefonico
                    Regista.ListenerFile.Invia(url)
                End If

                Globale.Log.Info("Chiamata in corso al numero {0}", {NumeroTelefonico})

            End If
        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try
    End Sub
End Class
