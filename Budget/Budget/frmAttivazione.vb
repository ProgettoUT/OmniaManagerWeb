
Public Class frmAttivazione

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With btnSalvaGruppo
            .Image = Risorse.Immagini.Bitmap("salva16")
            .ImageAlign = ContentAlignment.TopCenter
            .Text = "Salva gruppo"
            .TextAlign = ContentAlignment.BottomCenter
        End With
        With btnEsci
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = ContentAlignment.MiddleRight
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
    End Sub

    Private Sub frmAttivazione_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "Selezionare le figure che si desidera attivare:"

        CaricaFigureAttive()
        ControlloGruppi()
        LeggiGruppi()

        'aggancio il gestore dell'evento ItemCheck solo dopo aver caricato la lista da Db
        AddHandler clbFigure.ItemCheck, AddressOf clbFigure_ItemCheck
    End Sub

    Private Sub CaricaFigureAttive()
        'carica le figure (esclusi i gruppi) nella clb fleggando quelle attive
        Try
            clbFigure.SuspendLayout()

            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader("SELECT * FROM FigureProduttive ORDER BY IdFiguraProduttiva")

            clbFigure.Items.Clear()
            clbFigure.Sorted = True
            Do While dr.Read
                clbFigure.Items.Add(String.Format("{0:0000} {1}", dr("IdFiguraProduttiva"), dr("FiguraProduttiva")), dr("Attiva") = "S")
            Loop

            If clbFigure.Items.Count > 0 Then
                clbFigure.SelectedIndex = 0
            End If

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            clbFigure.ResumeLayout()
        End Try
    End Sub

    Private Sub clbFigure_ItemCheck(sender As Object, e As System.Windows.Forms.ItemCheckEventArgs)
        Try
            Dim CodiceFigura As Integer = clbFigure.Items.Item(e.Index).ToString.Substring(0, 4)

            If (e.NewValue = CheckState.Unchecked) AndAlso (FiguraInGruppo(CodiceFigura)) Then
                MsgBox("La figura fa parte di uno o più gruppi. Modificare i gruppi prima di disattivarla.", MsgBoxStyle.Information)
                'riporta il valore su checked
                e.NewValue = e.CurrentValue
                Exit Try
            End If

            Dim StatoFigura As String = "N"
            If e.NewValue = CheckState.Checked Then StatoFigura = "S"

            Dim Query As String = String.Format("UPDATE FigureProduttive 
                    SET Attiva = '{0}' 
                    WHERE IDFiguraProduttiva = {1}", StatoFigura, clbFigure.Items.Item(e.Index).Substring(0, 4))
            Utx.WsCommand.ExecuteNonQuery(Query)

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Function FiguraInGruppo(CodiceFigura As Integer) As Boolean
        'è vera se la figura appartiene ad un gruppo
        Try
            Return Utx.WsCommand.ExecuteNonQueryRecord(String.Format("SELECT Count(*) FROM GruppiCip WHERE Cip = {0}", CodiceFigura)) > 0
        Catch ex As Exception
            Log.Errore(ex)
            Return True 'blocca modifica dello stato
        End Try
    End Function

    Private Sub CaricaFigureGruppi()
        Try
            Dim Query As String = "SELECT * 
                FROM FigureProduttive 
                WHERE (Attiva = 'S') OR (IdFiguraProduttiva IN (SELECT Cip FROM GruppiCip GROUP BY Cip))"

            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query)

            clbFigureGruppi.Items.Clear()
            clbFigureGruppi.Sorted = True
            Do While dr.Read
                clbFigureGruppi.Items.Add(String.Format("{0:0000} {1}", dr("IdFiguraProduttiva"), dr("FiguraProduttiva")))
            Loop

            If clbFigureGruppi.Items.Count > 0 Then
                clbFigureGruppi.SelectedIndex = 0
            End If

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub LeggiGruppi()
        'riempie combo box con i gruppi in archivio
        Try
            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader("SELECT DISTINCT Gruppo,Descrizione FROM GruppiCip")

            cboGruppi.Items.Clear()
            cboGruppi.Items.Add("0000 Seleziona un gruppo...")
            Do While dr.Read
                cboGruppi.Items.Add(String.Format("{0:0000} {1}", dr("Gruppo"), dr("Descrizione")))
            Loop
            cboGruppi.Sorted = True
            cboGruppi.SelectedIndex = 0

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub ControlloGruppi()
        'controlla la congruenza dei gruppi. se una figura inserita in un gruppo
        'non esiste viene eliminata dal gruppo
        Try
            Utx.WsCommand.ExecuteNonQuery("DELETE FROM GruppiCip WHERE Cip NOT IN (SELECT Cip FROM FigureProduttive)")
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub btnSalvaGruppo_Click(sender As System.Object, e As System.EventArgs) Handles btnSalvaGruppo.Click
        Try
            txtCodiceGruppo.Text = txtCodiceGruppo.Text.Trim

            'controllo sul numero degli elementi
            If clbFigureGruppi.CheckedItems.Count < 2 Then
                MsgBox("Selezionare prima 2 o più elementi da inserire nel gruppo", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Exit Sub
            End If
            'controllo sul codice
            If (IsNumeric(txtCodiceGruppo.Text) = False) OrElse
               (txtCodiceGruppo.Text < 1) OrElse
               (txtCodiceGruppo.Text > 9999) Then
                MsgBox("Impostare un codice gruppo compreso fra 1 e 9999", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Exit Sub
            End If
            'controllo sulla descrizione
            If String.IsNullOrEmpty(txtDesk.Text) Then
                MsgBox("Inserire una descrizione per il gruppo", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Exit Sub
            End If

            '+controllo che il codice non sia già assegnato ad altra figura
            Dim Query As String = String.Format("SELECT COUNT(*) 
                FROM FigureProduttive 
                WHERE IDFiguraProduttiva = {0}", txtCodiceGruppo.Text)

            If Utx.WsCommand.ExecuteScalar(Query).Valore > 0 Then
                MsgBox("Codice già assegnato ad altra figura", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Exit Sub
            End If
            '+controllo che il codice non sia già assegnato ad altro gruppo
            Query = String.Format("SELECT COUNT(*) FROM GruppiCip WHERE Gruppo = {0}", txtCodiceGruppo.Text)
            If Utx.WsCommand.ExecuteScalar(Query).Valore > 0 Then
                If MsgBox(String.Format("Codice di gruppo già assegnato. Modificare il gruppo {0}?", txtCodiceGruppo.Text),
                              MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo, Utx.Globale.TitoloApp) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            txtDesk.Text = txtDesk.Text.Trim

            'cancello il gruppo prima di salvare le nuove impostazioni
            Query = String.Format("DELETE FROM GruppiCip WHERE Gruppo = {0}", txtCodiceGruppo.Text)
            Utx.WsCommand.ExecuteNonQuery(Query)

            'salvo la nuova impostazione del gruppo
            For Each i As Integer In clbFigureGruppi.CheckedIndices
                Query = String.Format("INSERT INTO GruppiCip (Gruppo,Descrizione,Cip) 
                VALUES ({0},'{1}',{2})", txtCodiceGruppo.Text, txtDesk.Text, Microsoft.VisualBasic.Left(clbFigureGruppi.Items(i), 4))
                Utx.WsCommand.ExecuteNonQuery(Query)
            Next
            '+aggiungo il gruppo alla lista delle figure
            FiguraProduttiva.Figure.Add(New FiguraProduttiva(txtCodiceGruppo.Text, txtDesk.Text, FiguraProduttiva.TipoFigura.GRUPPO))

        Catch ex As Exception
            Log.Errore(ex)
        End Try

        CaricaFigureGruppi()
        LeggiGruppi()
    End Sub

    Private Sub cboGruppi_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGruppi.SelectedIndexChanged
        Try
            'deseleziono tutto
            For k As Integer = 0 To clbFigureGruppi.Items.Count - 1
                clbFigureGruppi.SetItemChecked(k, False)
            Next

            If cboGruppi.SelectedIndex > 0 Then
                txtCodiceGruppo.Text = Microsoft.VisualBasic.Left(cboGruppi.Text, 4)
                txtDesk.Text = Microsoft.VisualBasic.Mid(cboGruppi.Text, 5, 100).Trim
                'marca tutte le figure che fanno parte del gruppo
                Dim Query As String = String.Format("SELECT Cip FROM GruppiCip WHERE Gruppo = {0}", cboGruppi.Text.Substring(0, 4))
                Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query)

                If dr.HasRows Then
                    Do While dr.Read
                        For k As Integer = 0 To clbFigureGruppi.Items.Count - 1
                            If Val(clbFigureGruppi.Items.Item(k).Substring(0, 4)) = dr("Cip") Then
                                clbFigureGruppi.SetItemChecked(k, True)
                                Exit For
                            End If
                        Next
                    Loop
                End If
            Else
                txtCodiceGruppo.Text = ""
                txtDesk.Text = ""
            End If

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub btnEsci_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Private Sub btnEliminaGruppo_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminaGruppo.Click
        Try
            If cboGruppi.SelectedIndex = 0 Then
                MsgBox("Selezionare prima il gruppo da eliminare", MsgBoxStyle.Exclamation)
            Else
                Dim Codice As Integer = cboGruppi.Text.Substring(0, 4)

                If MsgBox(String.Format("Confermate l'eliminazione del gruppo {0}?", Codice),
                          MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then

                    If Utx.WsCommand.ExecuteNonQueryRecord(String.Format("DELETE FROM GruppiCip WHERE Gruppo = {0}", Codice)) > 0 Then
                        FiguraProduttiva.EliminaFigura(Codice)
                        FiguraProduttiva.CancellaBudget(Codice)
                        MsgBox(String.Format("Gruppo {0} eliminato corretamente", Codice), MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    End If

                    txtCodiceGruppo.Text = ""
                    txtDesk.Text = ""
                End If
            End If

        Catch ex As Exception
            Log.Errore(ex)
        End Try

        CaricaFigureGruppi()
        LeggiGruppi()
    End Sub

    Private Sub txtCodiceGruppo_KeyPress1(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodiceGruppo.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8
                'non fare niente
            Case Else
                e.KeyChar = ""
        End Select
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then CaricaFigureGruppi()
    End Sub
End Class