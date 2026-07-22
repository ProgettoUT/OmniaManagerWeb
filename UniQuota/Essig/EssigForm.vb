Public Class EssigForm
    Public preventivo As Prodotto
    Private WithEvents navigatore As Essig.Navigatore


    Private Sub cmdChiudi_Click(sender As Object, e As EventArgs) Handles cmdChiudi.Click
        Hide()
    End Sub

    Private Sub EssigForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Show()
        Application.DoEvents()
        SalvaInEssig()
    End Sub


    Public Sub SalvaInEssig()
        Cursor = Cursors.WaitCursor
        cmdChiudi.Enabled = False

        essigLblQuota.Visible = False
        essigLblPremio.Visible = False
        essigLblScarto.Visible = False
        essigLbl0.Visible = False
        essigLbl1.Visible = False
        essigLbl2.Visible = False

        Application.DoEvents()

        Dim pes = preventivo.GetNewPES()
        navigatore = pes.navigatore
        Dim esito = pes.Esporta()

        lblMessaggi.Text = esito.Messaggio

        If esito.ErrorCode = 0 Then
            lblMessaggi.ForeColor = Color.DarkCyan
        Else
            lblMessaggi.ForeColor = Color.DarkRed
        End If

        If esito.ErrorCode = 0 Then
            lblMessaggi.Text = esito.Messaggio

            essigLblQuota.Text = FormatEuro(preventivo.PremioAnnuo)
            essigLblPremio.Text = FormatEuro(esito.PremioAnnuoLordo)
            essigLblScarto.Text = FormatEuro(preventivo.PremioAnnuo - esito.PremioAnnuoLordo)

            essigLblQuota.Visible = True
            essigLblPremio.Visible = True
            essigLblScarto.Visible = True
            essigLbl0.Visible = True
            essigLbl1.Visible = True
            essigLbl2.Visible = True

            esito.InviaEmail(preventivo)
        ElseIf esito.ErrorCode = 1 Then
            With CType(Me.ParentForm, Quotatore)
                .TabProdotti.SelectTab(.TabCliente)
                .txtClienteCodiceFiscale.Focus()
            End With
            Application.DoEvents()
            MsgBox(esito.Messaggio, vbExclamation)
        Else
            essigLblQuota.Text = ""
            essigLblPremio.Text = ""
            essigLblScarto.Text = ""
        End If

        cmdChiudi.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub navigatore_NavigatoreEvent(testo As String, contatore As Integer) Handles navigatore.NavigatoreEvent
        lblTesto.Text = testo
        WaitProgressBar.Value = contatore
        Application.DoEvents()
    End Sub
End Class