Public Class FormInvio

    Friend Archiviazione As Boolean = False

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Size = New Size(400, 280)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Globale.MainFont
        Me.Text = "Stampa e archivia buste"
        Me.Icon = My.Resources.archivio

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With ButtonStampa
            .AutoSize = True
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Stampa distinta"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.stampa.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonArchivia
            .AutoSize = True
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Archivia buste"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.archivio.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With CheckedListBoxBuste
            .Margin = New Padding(0)
            .CheckOnClick = True
            .IntegralHeight = False
            .BackColor = Color.LightYellow
        End With
    End Sub

    Private Sub FormInvio_Load(sender As Object, e As EventArgs) Handles Me.Load
        LeggiBusteDisponibili()
    End Sub

    Private Sub LeggiBusteDisponibili()
        Try
            Dim Query As String = "SELECT DataBusta,TipoBusta,COUNT(*) AS NumeroStampati 
                FROM Buste 
                WHERE (NOT DataBusta IS NULL) AND (Inviato = Cast(0 AS bit)) 
                GROUP BY DataBusta,TipoBusta 
                ORDER BY DataBusta,TipoBusta"

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            CheckedListBoxBuste.Items.Clear()

            For Each row As DataRow In dt.Rows
                CheckedListBoxBuste.Items.Add(New Busta(row("TipoBusta"), row("DataBusta"), row("NumeroStampati")))
            Next

            CheckedListBoxBuste.DisplayMember = "Descrizione"
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonArchivia_Click(sender As Object, e As EventArgs) Handles ButtonArchivia.Click
        Try
            If CheckedListBoxBuste.SelectedItems.Count = 0 Then
                MsgBox("Selezionare prima le buste da archiviare", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If MsgBox("Confermate l'archiviazione delle buste selezionate?",
                      MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo + MsgBoxStyle.Information, Globale.TitoloApp) = MsgBoxResult.Yes Then

                ButtonArchivia.Enabled = False

                For k As Integer = 0 To CheckedListBoxBuste.Items.Count - 1

                    Dim b As Busta = CheckedListBoxBuste.Items(k)

                    If CheckedListBoxBuste.GetItemChecked(k) Then

                        If b.DecadeCompleta = True Then
                            'archivio la busta
                            Dim Query As String = String.Format("UPDATE Buste SET Inviato = 1 
                                WHERE (DataBusta = '{0:dd/MM/yyyy}') AND (TipoBusta = '{1}')", b.DataBusta, b.TipoBusta)
                            Globale.Log.Info("archivio la busta: {0} records", {Utx.WsCommand.ExecuteNonQueryRecord(Query)})
                            'archivio le FEA
                            Query = String.Format("UPDATE Buste SET Inviato = 1
                                WHERE (Tipo = 'F') AND (DataFoglioCassa <= '{0:dd/MM/yyyy}')", b.DataBusta)
                            Globale.Log.Info("archivio le FEA: {0} records", {Utx.WsCommand.ExecuteNonQueryRecord(Query)})

                            'se è stata fatta almeno una archiviazione la segnalo così da aggiornare la query in uscita
                            Archiviazione = True
                        Else
                            MsgBox(String.Format("La decade {0:d} non è ancora finita e quindi non è archiviabile.",
                                                 b.DataBusta, MsgBoxStyle.Information, Globale.TitoloApp))
                        End If
                    End If
                Next
                Busta.AggiornaDateDecadi()
                LeggiBusteDisponibili()
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            ButtonArchivia.Enabled = True
        End Try
    End Sub

    Private Sub ButtonStampa_Click(sender As Object, e As EventArgs) Handles ButtonStampa.Click
        Try
            If CheckedListBoxBuste.CheckedItems.Count = 0 Then
                MsgBox("Selezionare prima le buste da stampare", MsgBoxStyle.Exclamation, Globale.TitoloApp)
            Else
                Using p As New PrintDialog
                    'apro dialogo stampante
                    If p.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        'per ogni busta
                        For Each b As Busta In CheckedListBoxBuste.CheckedItems
                            'passo settaggi stampante
                            b.PrintBuste.PrinterSettings = p.PrinterSettings
                            'stampo
                            b.Stampa()
                        Next
                    End If
                End Using
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class