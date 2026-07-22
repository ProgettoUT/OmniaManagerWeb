Public Class frmCodiciSub

    Private LegamiModificati As Boolean = False
    Private Const MinCodice As Integer = 1
    Private Const MaxCodice As Integer = 99
    Private Const MinCodiceEssig As Integer = 50000
    Private Const MaxCodiceEssig As Integer = 99999

    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Gestione punti vendita"
    End Sub

    Private Sub frmCodiciSub_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Icon = My.Resources.monete

        lstCodiciLegati.CheckOnClick = True

        LeggiPuntiVendita()

    End Sub

    Private Sub frmCodiciSub_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If lstCodiciPrincipali.SelectedIndex >= 0 Then
            SalvaLegami(CodicePvSelezionato)
        End If
    End Sub

    Private Sub LeggiPuntiVendita()
        Try
            'codici sub
            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader("SELECT * FROM PuntiVendita ORDER BY Codice")

            lstCodiciPrincipali.Items.Clear()

            Do While dr.Read
                lstCodiciPrincipali.Items.Add(String.Format("{0} - {1}",
                                                            dr("Codice").ToString.PadLeft(2, "0"),
                                                            dr("Descrizione")))
            Loop

            dr.Close()

            If lstCodiciPrincipali.Items.Count > 0 Then lstCodiciPrincipali.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub lstCodiciPrincipali_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstCodiciPrincipali.SelectedIndexChanged

        Static CodicePrecedente As Integer = -1

        'se il codice non è cambiato (errore nella generazione dell'evento)
        If CodicePrecedente = CodicePvSelezionato() Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        'modifico la descrizione del bottone elimina
        btnEliminaPuntoVendita.Text = String.Format("Elimina il punto vendita selezionato ({0})",
                                                    lstCodiciPrincipali.Text)

        'salvo la combinazione di codici
        If CodicePrecedente >= 0 Then SalvaLegami(CodicePrecedente)

        RemoveHandler lstCodiciLegati.ItemCheck, AddressOf lstCodiciLegati_ItemCheck

        Try
            Label2.Text = String.Format("Sub collegate a {0}", lstCodiciPrincipali.Text.Split("-")(1).Trim)

            CodicePrecedente = CodicePvSelezionato()

            Dim Query As String = "SELECT * 
                FROM 
                (SELECT CodiceSubAgente FROM Incassi GROUP BY CodiceSubAgente
                    UNION 
                SELECT SubAgenzia AS CodiceSubAgente FROM ChiusuraCassa GROUP BY SubAgenzia
                ) AS C 
                LEFT JOIN Legami AS L ON C.CodiceSubAgente = L.CodiceLegato 
                WHERE CodiceSubAgente >= 0"

            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query)

            lstCodiciLegati.Items.Clear()

            Do While dr.Read

                If dr("CodicePrincipale") Is System.DBNull.Value Then
                    lstCodiciLegati.Items.Add(dr("CodiceSubAgente"), False)
                ElseIf String.IsNullOrEmpty(dr("CodicePrincipale")) Then
                    lstCodiciLegati.Items.Add(dr("CodiceSubAgente"), False)
                ElseIf dr("CodicePrincipale") = CodicePvSelezionato() Then
                    lstCodiciLegati.Items.Add(dr("CodiceSubAgente"), True)
                Else
                    'il codice non va aggiunto alla lista perchè abbinato ad altro codice
                End If
            Loop

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            AddHandler lstCodiciLegati.ItemCheck, AddressOf lstCodiciLegati_ItemCheck
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub SalvaLegami(CodicePrincipale As Integer)
        'se non ci sono state modifiche esce
        If LegamiModificati = False Then Exit Sub

        Try
            Dim Query As String = $"DELETE 
                FROM Legami 
                WHERE CodicePrincipale = {CodicePrincipale}"

            Utx.WsCommand.ExecuteNonQueryRecord(Query)

            For Each i As Integer In lstCodiciLegati.CheckedIndices

                Query = $"INSERT INTO Legami (CodicePrincipale, CodiceLegato) 
                    VALUES ({CodicePrincipale},{lstCodiciLegati.Items(i)})"

                Utx.WsCommand.ExecuteNonQueryRecord(Query)
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub lstCodiciLegati_ItemCheck(sender As Object, e As System.Windows.Forms.ItemCheckEventArgs)
        LegamiModificati = True
    End Sub

    Private Sub btnEliminaPuntoVendita_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminaPuntoVendita.Click

        If lstCodiciPrincipali.SelectedIndex < 0 Then Exit Sub

        If MsgBox($"Confermate l'eliminazione del punto vendita {lstCodiciPrincipali.Text}?",
                  MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub

        Try
            Dim Query As String = $"DELETE 
                FROM Legami 
                WHERE CodicePrincipale = {CodicePvSelezionato()}
                
                DELETE 
                FROM PuntiVendita 
                WHERE Codice = {CodicePvSelezionato()}"
            Utx.WsCommand.ExecuteNonQueryRecord(Query)

            LeggiPuntiVendita()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAggiungiPuntoVendita_Click(sender As System.Object, e As System.EventArgs) Handles btnAggiungiPuntoVendita.Click

        If String.IsNullOrEmpty(txtCodicePV.Text.Trim) OrElse
           (txtCodicePV.Text < MinCodice) OrElse
           (txtCodicePV.Text > MaxCodice) Then

            MsgBox(String.Format("Inserire un codice compreso fra {0} e {1}",
                                 MinCodice, MaxCodice), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtCodiceEssig.Text.Trim) Then txtCodiceEssig.Text = 0

        If String.IsNullOrEmpty(txtDescrizionePV.Text.Trim) Then
            MsgBox("Inserire una descrizione per il punto vendita", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Try
            For Each s As String In lstCodiciPrincipali.Items
                If CodicePvSelezionato(s) = txtCodicePV.Text Then
                    MsgBox("Punto vendita già esistente.", MsgBoxStyle.Exclamation)
                    Exit Try
                End If
            Next

            Dim Query As String = String.Format("INSERT INTO PuntiVendita
                (Codice, Descrizione, CodiceEssigReti) 
                VALUES({0},'{1}',{2})", txtCodicePV.Text, txtDescrizionePV.Text, txtCodiceEssig.Text)

            Utx.WsCommand.ExecuteNonQueryRecord(Query)

            LeggiPuntiVendita()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function CodicePvSelezionato() As Integer
        Return lstCodiciPrincipali.Text.Split("-")(0)
    End Function

    Private Function CodicePvSelezionato(PuntoVendita As String) As Integer
        Return PuntoVendita.Split("-")(0)
    End Function
End Class