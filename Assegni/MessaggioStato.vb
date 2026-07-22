Public Class MessaggioStato

    Public Shared Sub Messaggio(ByVal Messaggio As String,
                                Optional ByVal Errore As Boolean = False)
        FormMain.LabelMessaggio.Text = Messaggio

        If Errore Then
            FormMain.LabelMessaggio.ForeColor = Color.Red
            Globale.Log.Info("Errore >>> " + Messaggio)
        Else
            FormMain.LabelMessaggio.ForeColor = Color.Black
            Globale.Log.Info(Messaggio)
        End If

        FormMain.StatusStrip1.Refresh()
    End Sub

    Public Shared Sub Messaggio()
        FormMain.LabelMessaggio.ForeColor = Color.Black
        FormMain.StatusStrip1.Refresh()
    End Sub

End Class
