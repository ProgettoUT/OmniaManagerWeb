Public Class FormMigrazione
    Private WithEvents db As New DbManager()

    Private Sub FormMigrazione_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblMessaggio.Font = Utx.AppFont.Bold
        lblMessaggio.Text = ""
    End Sub

    Private Sub buttonMigra_Click(sender As Object, e As EventArgs) Handles buttonMigra.Click
        If MsgBox("Procedere con la migrazione dei dati a sql server", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            buttonMigra.Enabled = False
            ButtonLog.Enabled = False

            Utx.GestioneDatabase.Migrazione()
            Beep()
            buttonMigra.Enabled = True
            ButtonLog.Enabled = True
            MsgBox("Importazione terminata")
            Exit Sub

            db.CreaDatabase()
            'db.ImportaDatabase()
            'If db.VerificaDatabase Then
            '    db.ImportaDatabase()
            'ElseIf MsgBox("Verifica terminata con errori. Procedere comunque con la migrazione?", vbYesNo) = vbYes Then
            '    db.ImportaDatabase()
            'End If

            buttonMigra.Enabled = True
            ButtonLog.Enabled = True
        End If
    End Sub

    Private Sub db_Messaggio(messaggio As String) Handles db.Messaggio
        lblMessaggio.Text = messaggio
        Utx.Globale.Log.Debug(messaggio)
        Application.DoEvents()
    End Sub

    Private Sub ButtonLog_Click(sender As Object, e As EventArgs) Handles ButtonLog.Click
        db.VisualizzaLog()
    End Sub
End Class
