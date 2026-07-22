Imports System.Text

Public Class FormDettaglioRg

    Public Property RamoGestione As Integer
    Public Property DataInizioAnalisi As Date
    Public Property DataAnalisi As Date
    Public Property Anno As Integer
    Public Property CodiceSelezionato As String
    Public Property CLausolaSub() As String
    Public Property ClausolaIncorporata As String
    Private ReadOnly FormFiltro As New Utx.FormGestioneFiltro(1000)

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Icon = Risorse.Immagini.Icon("budget")
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width * 0.8, Screen.PrimaryScreen.WorkingArea.Height * 0.8)
        Me.Text = "Dettaglio incassi"

        ImpostaControlli()
    End Sub

    Private Sub FormDettaglioRg_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Text = String.Format("Dettaglio ramo gestione {0}", RamoGestione)
        Me.Refresh()
        DettaglioRg()
    End Sub

    Private Function ImpostaControlli() As Boolean
        On Error Resume Next
        With ButtonEsporta
            .Margin = New Padding(0, 1, 0, 1)
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.Green
            .ForeColor = Color.White
            .Text = "Esporta in csv"
        End With
        With ButtonEsci
            .Margin = New Padding(0, 1, 0, 1)
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With LabelRecord
            .Dock = DockStyle.Fill
            .Margin = New Padding(0, 1, 0, 1)
            .FlatStyle = FlatStyle.Flat
            .Text = ""
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With LabelPeriodo
            .Dock = DockStyle.Fill
            .Margin = New Padding(0, 1, 0, 1)
            .FlatStyle = FlatStyle.Flat
            .Text = ""
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With LabelTotaleTassabile
            .Dock = DockStyle.Fill
            .Margin = New Padding(0, 1, 0, 1)
            .FlatStyle = FlatStyle.Flat
            .BackColor = Utx.AppColor.VerdeAcido
            .Text = ""
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With LabelTotaleLordo
            .Dock = DockStyle.Fill
            .Margin = New Padding(0, 1, 0, 1)
            .FlatStyle = FlatStyle.Flat
            .BackColor = Color.Moccasin
            .Text = ""
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With LabelMedia
            .Dock = DockStyle.Fill
            .Margin = New Padding(0, 1, 0, 1)
            .FlatStyle = FlatStyle.Flat
            .BackColor = Color.LightPink
            .Text = ""
            .TextAlign = ContentAlignment.MiddleCenter
        End With
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

    Private Sub DettaglioRg()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim Inizio As New DateTime(Anno, DataInizioAnalisi.Month, DataInizioAnalisi.Day)
            Dim Fine As New DateTime(Anno, DataAnalisi.Month, DataAnalisi.Day)

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(TestoQuery(RamoGestione, Inizio, Fine), CodiceSelezionato).DataTable
            dgvDettaglio.DataSource = dt

            FormattaGriglia(dgvDettaglio)

            LabelPeriodo.Text = String.Format("Dal {0:d} al {1:d}", Inizio, Fine)

            CalcolaTotali()

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function TestoQuery(RamoGestione As Integer, Inizio As Date, Fine As Date) As String
        Try
            Dim Sql As String = "SELECT Agenzia,Ramo,Polizza,Contraente,CodiceSubAgente,CodiceProduttore,NumeroAppendice,DataEffettoAppendice,
                DataEffettoTitolo,TipoCarico,Esito,DataFoglioCassa,CodiceCassa,Tassabile,TotaleTitolo,CanoneBox,Frazionamento,
                TipoPagamento,CodiceProdotto,ScadenzaVincolo,EffettoPolizza,ScadenzaPolizza,RataIntermedia 
                FROM Incassi 
                WHERE (RamoGestione = {0}) AND (DataFoglioCassa BETWEEN '{1:dd/MM/yyyy}' AND '{2:dd/MM/yyyy}') AND ({3}) AND ({4})
                ORDER BY DataFoglioCassa DESC"
            Return String.Format(Sql.ToString, RamoGestione, Inizio, Fine, _CLausolaSub, ClausolaIncorporata)
        Catch ex As Exception
            Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Sub dgvDettaglio_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDettaglio.RowHeaderMouseClick
        Using f As New FormDettaglioPolizza
            f.Ramo = dgvDettaglio.CurrentRow.Cells("Ramo").Value
            f.Polizza = dgvDettaglio.CurrentRow.Cells("Polizza").Value
            f.ShowDialog()
        End Using
    End Sub

    Private Sub dgvDettaglio_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDettaglio.ColumnHeaderMouseClick
        Try
            'cartella per salvataggio filtro
            FormFiltro.AppName = "BUDGET"
            FormFiltro.FilterFolder = Utx.Globale.Paths.CartellaSettingRete

            'visualizzo la finestra del filtro
            FormFiltro.Visualizza(dgvDettaglio.Columns(e.ColumnIndex))
            CalcolaTotali()
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormattaGriglia(ByRef dgv As DataGridView)
        On Error Resume Next
        With dgv
            .SuspendLayout()
            RemoveHandler dgvDettaglio.CurrentCellChanged, AddressOf dgvDettaglio_CurrentCellChanged
            RemoveHandler dgvDettaglio.CellLeave, AddressOf dgvDettaglio_CellLeave

            'intestazioni delle colonne
            With .Columns("CodiceSubAgente")
                .HeaderText = "Sub"
                .DefaultCellStyle.BackColor = Color.Gainsboro
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("CodiceProduttore")
                .HeaderText = "Prod"
                .DefaultCellStyle.BackColor = Color.LightYellow
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
                .DefaultCellStyle.BackColor = Utx.AppColor.VerdeAcido
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
            With .Columns("RataIntermedia")
                .HeaderText = "Rata intermedia"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns("Agenzia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Ramo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Esito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Prodotto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

            .RowHeadersDefaultCellStyle.SelectionBackColor = Color.Red
            dgvDettaglio_CurrentCellChanged(Me, New EventArgs)

            'autosize intestazioni righe
            .AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders)

            Utx.NetFunc.BloccaOrdinamento(dgv)

            AddHandler dgvDettaglio.CellLeave, AddressOf dgvDettaglio_CellLeave
            AddHandler dgvDettaglio.CurrentCellChanged, AddressOf dgvDettaglio_CurrentCellChanged

            .ResumeLayout()
        End With
    End Sub

    Private Sub dgvDettaglio_CellLeave(sender As Object, e As DataGridViewCellEventArgs)
        On Error Resume Next
        dgvDettaglio.CurrentRow.HeaderCell.Value = ""
    End Sub

    Private Sub dgvDettaglio_CurrentCellChanged(sender As Object, e As EventArgs)
        On Error Resume Next
        dgvDettaglio.CurrentRow.HeaderCell.Value = "Dettaglio"
    End Sub

    Private Sub CalcolaTotali()
        Try
            Dim Tassabile As Double = 0
            Dim Totale As Double = 0

            For Each row As DataGridViewRow In dgvDettaglio.Rows
                Tassabile += row.Cells("Tassabile").Value
                Totale += row.Cells("TotaleTitolo").Value
            Next
            LabelRecord.Text = String.Format("Nr.incassi {0}", dgvDettaglio.Rows.Count)
            LabelTotaleTassabile.Text = String.Format("Totale tassabile: {0:##,###,##0.00}", Tassabile)
            LabelTotaleLordo.Text = String.Format("Totale lordo: {0:##,###,##0.00}", Totale)
            If dgvDettaglio.Rows.Count > 0 Then
                LabelMedia.Text = String.Format("Media tassabile: {0:##,###,##0.00}", Tassabile / dgvDettaglio.Rows.Count)
            Else
                LabelMedia.Text = "Media tassabile: ND"
            End If

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub ButtonEsporta_Click(sender As Object, e As EventArgs) Handles ButtonEsporta.Click
        Utx.NetFunc.Esporta2Csv(dgvDettaglio, String.Format("Dettaglio incassi RG {0}", RamoGestione), Color.Khaki)
    End Sub
End Class