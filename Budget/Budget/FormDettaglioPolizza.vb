Imports System.Text

Public Class FormDettaglioPolizza

    Friend Ramo As Integer
    Friend Polizza As Integer

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Icon = Risorse.Immagini.Icon("budget")
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width * 0.7, Screen.PrimaryScreen.WorkingArea.Height * 0.6)
        Me.Text = "Dettaglio incassi"

        ImpostaControlli()
    End Sub

    Private Sub FormDettaglioPolizza_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Refresh()
        DettaglioPolizza()
    End Sub

    Private Function ImpostaControlli() As Boolean
        On Error Resume Next
        With dgvDettaglio
            .Dock = DockStyle.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
        End With
        Utx.NetFunc.DoppioBuffer(dgvDettaglio)
    End Function

    Private Sub DettaglioPolizza()
        Try
            Me.Cursor = Cursors.WaitCursor

            dgvDettaglio.DataSource = Utx.WsCommand.ExecuteNonQuery(TestoQuery).DataTable
            FormattaGriglia(dgvDettaglio)
            Me.Text = String.Format("Polizza {0}/{1} - Tutti gli anni - incassi {2}", Ramo, Polizza, dgvDettaglio.Rows.Count)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function TestoQuery() As String
        Try
            Return String.Format("SELECT Agenzia,Ramo,Polizza,Contraente,CodiceSubAgente,NumeroAppendice,DataEffettoAppendice,
                DataEffettoTitolo,TipoCarico,Esito,DataFoglioCassa,CodiceCassa,Tassabile,TotaleTitolo,CanoneBox,Frazionamento,
                TipoPagamento,CodiceProdotto,ScadenzaVincolo,EffettoPolizza,ScadenzaPolizza 
                FROM Incassi  
                WHERE Ramo = {0} AND Polizza = {1}
                ORDER BY DataFoglioCassa DESC", Ramo, Polizza)
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Sub FormattaGriglia(ByRef dgv As DataGridView)
        On Error Resume Next

        With dgv
            .SuspendLayout()

            'intestazioni delle colonne
            With .Columns("CodiceSubAgente")
                .HeaderText = "Sub"
                .DefaultCellStyle.BackColor = Color.Gainsboro
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("NumeroAppendice")
                .HeaderText = "App."
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("SubAgenzia")
                .HeaderText = "Sub"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("DataEffettoAppendice")
                .HeaderText = "Effetto appendice"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("DataEffettoTitolo")
                .HeaderText = "Effetto titolo"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("TipoCarico")
                .HeaderText = "Tipo carico"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("DataFoglioCassa")
                .HeaderText = "Data foglio cassa"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("CodiceCassa")
                .HeaderText = "Cassa"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("Tassabile")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,##0.00"
            End With
            With .Columns("TotaleTitolo")
                .HeaderText = "Totale titolo"
                .DefaultCellStyle.BackColor = Color.Moccasin
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,##0.00"
            End With
            With .Columns("CanoneBox")
                .HeaderText = "Canone box"
                .DefaultCellStyle.BackColor = Color.LightPink
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,##0.00"
            End With
            With .Columns("Frazionamento")
                .HeaderText = "Fraz."
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("TipoPagamento")
                .HeaderText = "Pag."
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("CodiceProdotto")
                .HeaderText = "Prodotto"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("ScadenzaVincolo")
                .HeaderText = "Scadenza vincolo"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("EffettoPolizza")
                .HeaderText = "Effetto polizza"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("ScadenzaPolizza")
                .HeaderText = "Scadenza polizza"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns("Agenzia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Ramo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Esito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Prodotto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

            For Each c As DataGridViewColumn In .Columns
                c.SortMode = DataGridViewColumnSortMode.Programmatic
            Next

            .ResumeLayout()
        End With
    End Sub
End Class