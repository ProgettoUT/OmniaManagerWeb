Imports System.Text

Public Class TabNotifica

    Dim Pagina As New TabPage
    Dim lb As New Label

    Sub New(Agenzia As String,
            ByRef cnArrivi As OleDb.OleDbConnection)

        Pagina.Name = Agenzia
        Pagina.Text = Agenzia

        Pagina.Controls.Add(lb)

        lb.Dock = DockStyle.Fill
        lb.Padding = New Padding(5)

        Dim Notifica As New StringBuilder

        With Globale.DatiArrivati
            Dim Msg As String = "- {0} {1}"

            Notifica.AppendLine("Sono stati scaricati e pronti per l'importazione i seguenti dati:")
            Notifica.AppendLine()

            If .MonitorQt Then Notifica.AppendLine(String.Format(Msg, "Monitoraggio QT", LeggiCalendarioUt(cnArrivi, Utx.Enumerazioni.TipoFileMagia.MonitorQT)))
            If .SinistriBase Then Notifica.AppendLine(String.Format(Msg, "Sinistri AIA", LeggiCalendarioUt(cnArrivi, Utx.Enumerazioni.TipoFileMagia.SinistriBase)))
            'liste
            If .ListeQT Then Notifica.AppendLine(String.Format(Msg, "Liste QT", LeggiCalendarioDoc(cnArrivi, Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO)))
            If .ListeFlex Then Notifica.AppendLine(String.Format(Msg, "Liste flex", LeggiCalendarioDoc(cnArrivi, Utx.Enumerazioni.TipoFileDoc.FLEX)))
            If .Buste Then Notifica.AppendLine(String.Format(Msg, "Invio documenti", LeggiCalendarioDoc(cnArrivi, Utx.Enumerazioni.TipoFileDoc.BUSTE)))

            Notifica.AppendLine()
            Notifica.AppendLine("Per completare il processo entrare in Importa dati e rispondere SI alla richiesta di procedere con l'importazione.")

            lb.Text = Notifica.ToString
        End With
    End Sub

    Public ReadOnly Property NotificaDati() As TabPage
        Get
            Return Pagina
        End Get
    End Property
End Class
