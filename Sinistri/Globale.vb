Public Class Globale
    'costanti
    Public Shared Log As New Utx.ApplicationLog("Sinistri.log")
    Public MainFont As New Drawing.Font("Tahoma", 9)

    Public Shared Sub ControlloAttivitaInScadenza()
        Dim Notifica As New Utx.FormNotifica
        Try
            With Notifica
                With .LabelMessaggio
                    .Padding = New Windows.Forms.Padding(10)
                    .TextAlign = Drawing.ContentAlignment.TopLeft
                End With
                .ColoreSfondo = Drawing.Color.Moccasin
                .Text = ""
                .Show()
                .Messaggio = "Controllo attivita..."
            End With

            Dim Esito As String
            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.Timeout = 10000
                Esito = s.ControlloAttivitaInScadenza(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Utx.Globale.Token)
            End Using

            With Notifica
                With .LabelMessaggio
                    .Padding = New Windows.Forms.Padding(10)
                    .Font = Utx.AppFont.Bold
                    .Image = Risorse.Immagini.Bitmap("clock")
                    .ImageAlign = Drawing.ContentAlignment.TopRight
                End With
                .Messaggio = String.Format("Attività in scadenza:{0}{0}per CLIENTI {1}{0}per SINISTRI {2}",
                                           Environment.NewLine, Esito.Split(";")(0), Esito.Split(";")(1))
                .Chiudi(5)
            End With

        Catch ex As Exception
            Globale.Log.Info(ex)
            With Notifica
                .Messaggio = ex.Message
                .Chiudi(3)
            End With
        End Try
    End Sub
End Class
