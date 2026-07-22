Public Class Servizi

    Dim Sms As UniCom.Sms
    Dim Notifica As Utx.FormNotifica

    Public Function CercaNotificheSms(Optional Attesa As Integer = 3) As Boolean

        Notifica = New Utx.FormNotifica()

        Try
            With Notifica
                .ColoreSfondo = Color.DodgerBlue
                .ColoreTesto = Color.White
                .Opacity = 0.9
                .Text = ""
                .Show()

                'produce anche il refresh della label
                .Messaggio = "Ricerca notifiche SMS in corso..."
            End With

            Sms = New UniCom.Sms

            AddHandler Sms.Stato, AddressOf StatoRecuperoNotifiche

            '-----------------------------
            Dim NotificheRecuperate As Integer = Sms.CercaNotifiche()
            '-----------------------------

            Notifica.Chiudi(Attesa)

            Sms.CancellaFlagDelivery()
            Sms.CreaFlagDelivery(NotificheRecuperate)

        Catch ex As Exception
            Globale.Log.Errore(ex)

            Notifica.ColoreSfondo = Color.Orange
            Notifica.Messaggio = "Errore: operazione annullata"
            Notifica.Chiudi(Attesa)
        End Try

        'se butto giù il processo anche la notifica viene chiusa
        'aspetto 5 secondi prima di uscire per consentire di leggere la notifica
        Threading.Thread.Sleep(Attesa * 1000)
        Return True
    End Function

    Private Sub StatoRecuperoNotifiche(Stato As StatoServizio)
        If (Stato.Messaggio IsNot Nothing) AndAlso Stato.Messaggio.Trim.Length > 0 Then
            Notifica.Messaggio = String.Format(Stato.Messaggio + "{0}Recuperate {1} notifiche",
                                               Environment.NewLine, Stato.Contatore)
        Else
            Notifica.Messaggio = String.Format("Recuperate {0} notifiche", Stato.Contatore)
        End If
    End Sub
End Class
