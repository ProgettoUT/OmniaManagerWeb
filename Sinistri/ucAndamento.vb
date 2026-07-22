Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports Telerik.Charting
Imports System.Drawing

Public Class ucAndamento

    Private Riserva, Bilancio, Costo, Spese As New LineSeries()

    Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Dock = Windows.Forms.DockStyle.Fill

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        SplitContainer1.SplitterDistance = SplitContainer1.Height * 0.3

        With dgvAndamento
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .Margin = New Padding(1)
        End With
        Utx.NetFunc.DoppioBuffer(dgvAndamento)

        RadChartView1.Margin = New Padding(0)

        CheckBoxRiserva.Checked = True
        CheckBoxBilancio.Checked = True
        CheckBoxCosto.Checked = True
        CheckBoxSpese.Checked = False
    End Sub

    Private mSinistro As Sinistro
    Public Property Sinistro() As Sinistro
        Get
            Return mSinistro
        End Get
        Set(value As Sinistro)
            mSinistro = value
        End Set
    End Property

    Public Sub LeggiAndamento()
        Try
            If mSinistro Is Nothing Then Exit Sub

            Dim Query As String = String.Format("SELECT AnnoMeseCompetenza AS Aggiornamento,TipoCid,TipoChiusura,StatoTecnico,StatoBilancistico,
                PrimoPreventivo,PagatoDel,PagatoAl,Riserva,RiservaBilancio,DataUltPagam,SpeseDel,SpeseAl,NrPosizioni
                FROM DB{0}.dbo.AndamentoSinistri 
                WHERE AgenziaSinistro = {1} AND EsercizioSinistro = {2} AND NumeroSinistro = {3}
                ORDER BY AnnoMeseCompetenza DESC,TipoChiusura",
                            Utx.Globale.AgenziaRichiesta.CodiceAgenzia, mSinistro.Agenzia, mSinistro.Esercizio, mSinistro.Numero)

            dgvAndamento.DataSource = Utx.WsCommand.ExecuteNonQuery(Query).DataTable
            FormattaGriglia()
            'aggiorna grafico
            Grafico()
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormattaGriglia()
        Try
            With dgvAndamento
                .Columns("Aggiornamento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                With .Columns("TipoCid")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderText = "Tipo CID"
                End With
                With .Columns("TipoChiusura")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderText = "Tipo chiusura Old"
                End With
                With .Columns("StatoTecnico")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderText = "Stato tecnico"
                End With
                With .Columns("StatoBilancistico")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderText = "Stato bilancistico"
                End With
                With .Columns("PrimoPreventivo")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .HeaderText = "Primo preventivo"
                End With
                With .Columns("PagatoDel")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .HeaderText = "Pagato del"
                End With
                With .Columns("PagatoAl")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .HeaderText = "Pagato al"
                End With
                With .Columns("Riserva")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .HeaderText = "Riserva tecnica"
                End With
                With .Columns("RiservaBilancio")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .HeaderText = "Riserva di bilancio"
                End With
                With .Columns("DataUltPagam")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderText = "Ultimo pagamento"
                End With
                With .Columns("SpeseDel")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .HeaderText = "Spese del"
                End With
                With .Columns("SpeseAl")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .HeaderText = "Spese al"
                End With
                With .Columns("NrPosizioni")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderText = "Posizioni"
                End With
            End With

            For Each r As DataGridViewRow In dgvAndamento.Rows
                If r.Cells("TipoChiusura").Value = "RB" Then
                    r.DefaultCellStyle.ForeColor = Color.Red
                End If
            Next

            dgvAndamento.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub Grafico()
        Try
            Dim dt As New DataTable
            With dt.Columns
                .Add("Aggiornamento", GetType(String))
                .Add("Riserva", GetType(Double))
                .Add("RiservaBilancio", GetType(Double))
                .Add("PagatoAl", GetType(Double))
                .Add("SpeseAl", GetType(Double))
            End With

            Dim RPrec, RBPrec, PPrec, SPrec As Double
            RPrec = 0
            RBPrec = 0
            PPrec = 0
            SPrec = 0

            For k As Integer = dgvAndamento.Rows.Count - 1 To 0 Step -1
                Try
                    If dgvAndamento.Rows(k).Cells("TipoChiusura").Value = "RB" Then
                        dt.Rows.Add(Format(dgvAndamento.Rows(k).Cells("Aggiornamento").Value, "dd-MM-yyyy"),
                                    RPrec,
                                    dgvAndamento.Rows(k).Cells("RiservaBilancio").Value,
                                    PPrec,
                                    SPrec)
                        RBPrec = dgvAndamento.Rows(k).Cells("RiservaBilancio").Value
                    Else
                        dt.Rows.Add(Format(dgvAndamento.Rows(k).Cells("Aggiornamento").Value, "dd-MM-yyyy"),
                                    dgvAndamento.Rows(k).Cells("Riserva").Value,
                                    RBPrec,
                                    dgvAndamento.Rows(k).Cells("PagatoAl").Value,
                                    dgvAndamento.Rows(k).Cells("SpeseAl").Value)

                        RPrec = dgvAndamento.Rows(k).Cells("Riserva").Value
                        PPrec = dgvAndamento.Rows(k).Cells("PagatoAl").Value
                        SPrec = dgvAndamento.Rows(k).Cells("SpeseAl").Value
                    End If
                Catch ex As Exception
                    dt.Rows.Add(Format(Today, "dd-MM-yyyy"), 0, 0, 0, 0)
                    RPrec = 0
                    PPrec = 0
                    SPrec = 0

                    Globale.Log.Info(ex)
                End Try
            Next

            Dim controler As New ChartTrackballController()
            AddHandler controler.TextNeeded, AddressOf controler_TextNeeded

            With RadChartView1
                .Series.Clear()
                .ShowLegend = True
                .LegendTitle = "Legenda"
                .Controllers.Add(New SmartLabelsController())
                .ShowGrid = True
                .Controllers.Add(controler)
            End With

            With Spese
                .ValueMember = "SpeseAl"
                .CategoryMember = "Aggiornamento"
                .LegendTitle = "Spese"
                .DataSource = dt
                .ShowLabels = True
                .Palette = New PaletteEntry(Color.Gainsboro, Color.Green)

                If CheckBoxSpese.Checked Then
                    RadChartView1.Series.Add(Spese)
                    'dopo aver aggiunto la serie a RadChart altrimenti non funziona
                    .HorizontalAxis.ClipLabels = False
                End If
            End With
            With Riserva
                .ValueMember = "Riserva"
                .CategoryMember = "Aggiornamento"
                .LegendTitle = "Riserva tecnica"
                .DataSource = dt
                .ShowLabels = True
                .Palette = New PaletteEntry(Color.Gainsboro, Color.Fuchsia)

                If CheckBoxRiserva.Checked Then
                    RadChartView1.Series.Add(Riserva)
                    .HorizontalAxis.ClipLabels = False
                End If
            End With
            With Bilancio
                .ValueMember = "RiservaBilancio"
                .CategoryMember = "Aggiornamento"
                .LegendTitle = "Riserva di bilancio"
                .DataSource = dt
                .ShowLabels = True
                .Palette = New PaletteEntry(Color.Gainsboro, Color.Red)

                If CheckBoxBilancio.Checked Then
                    RadChartView1.Series.Add(Bilancio)
                    .HorizontalAxis.ClipLabels = False
                End If
            End With
            With Costo
                .ValueMember = "PagatoAl"
                .CategoryMember = "Aggiornamento"
                .LegendTitle = "Pagato al"
                .DataSource = dt
                .ShowLabels = True
                .Palette = New PaletteEntry(Color.Gainsboro, Color.Blue)

                If CheckBoxCosto.Checked Then
                    RadChartView1.Series.Add(Costo)
                    .HorizontalAxis.ClipLabels = False
                End If
            End With

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub controler_TextNeeded(sender As Object, e As TextNeededEventArgs)
        Try
            With e.Element
                .BackColor = Color.DodgerBlue
                .ForeColor = Color.White
                .BorderColor = Color.Gainsboro
                .NumberOfColors = 1
                .BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid
            End With

            Dim cdp As CategoricalDataPoint = TryCast(e.Points(0).DataPoint, CategoricalDataPoint)
            e.Text = cdp.Category

            For Each r As DataGridViewRow In dgvAndamento.Rows
                If r.Cells("Aggiornamento").Value = CDate(cdp.Category) Then
                    dgvAndamento.CurrentCell = r.Cells(0)
                End If
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub radChartView1_LabelFormatting(sender As Object, e As ChartViewLabelFormattingEventArgs) Handles RadChartView1.LabelFormatting
        e.LabelElement.BorderColor = Color.Transparent
    End Sub

    Private Sub CheckBoxSpese_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSpese.CheckedChanged
        If CheckBoxSpese.Checked Then
            RadChartView1.Series.Add(Spese)
        Else
            RadChartView1.Series.Remove(Spese)
        End If
    End Sub

    Private Sub CheckBoxBilancio_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxBilancio.CheckedChanged
        If CheckBoxBilancio.Checked Then
            RadChartView1.Series.Add(Bilancio)
        Else
            RadChartView1.Series.Remove(Bilancio)
        End If
    End Sub

    Private Sub CheckBoxCosto_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCosto.CheckedChanged
        If CheckBoxCosto.Checked Then
            RadChartView1.Series.Add(Costo)
        Else
            RadChartView1.Series.Remove(Costo)
        End If
    End Sub

    Private Sub CheckBoxRiserva_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRiserva.CheckedChanged
        If CheckBoxRiserva.Checked Then
            RadChartView1.Series.Add(Riserva)
        Else
            RadChartView1.Series.Remove(Riserva)
        End If
    End Sub

    Private Sub dgvAndamento_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvAndamento.CellFormatting
        If e.ColumnIndex = dgvAndamento.Rows(e.RowIndex).Cells("TipoChiusura").ColumnIndex Then
            If e.Value = "RB" Then
                dgvAndamento.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            End If
        End If
    End Sub
End Class
