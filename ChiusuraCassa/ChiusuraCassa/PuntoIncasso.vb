Public Class frmPuntoIncasso

    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub frmPuntoIncasso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Text = "Cambia punto vendita"

        Label1.Text = "Selezionare il punto vendita che ha effettuato l'operazione:"

        LeggiPuntiVendita()

    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub

    Private Sub txtCodiceSub_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub LeggiPuntiVendita()
        Try
            Dim Query As String = "SELECT * FROM PuntiVendita ORDER BY Codice"

            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query)

            cboPuntoVendita.Items.Add("...")

            Do While dr.Read
                cboPuntoVendita.Items.Add(String.Format("{0}. {1}",
                                                        dr("Codice").ToString.PadLeft(2, "0"),
                                                        dr("Descrizione")))
            Loop

            dr.Close()

            If cboPuntoVendita.Items.Count > 0 Then cboPuntoVendita.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class