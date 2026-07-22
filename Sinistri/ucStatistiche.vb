Imports System.Windows.Forms
Imports System.Drawing

Public Class ucStatistiche

    Private Enum Tipo
        MIX_COSE_PERSONE = 0
        FREQUENZA_CIP = 1
        FREQUENZA_PRODOTTO = 2
        FREQUENZA_CONVENZIONE = 3
        MEDIA_LIQUIDATO = 4
        MEDIA_LIQUIDATO_COMPARTO = 5
    End Enum
    Private TipoStatistica As Tipo

    Friend WithEvents FormFiltro As Utx.FormGestioneFiltro

    Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Dock = Windows.Forms.DockStyle.Fill

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With LabelDesk
            .Margin = New Padding(0, 1, 0, 1)
            .FlatStyle = FlatStyle.Flat
            .BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            .BackColor = Color.Moccasin
            .Dock = DockStyle.Fill
            .Text = "Statistiche"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With LabelMenu
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            .BackColor = Color.Khaki
            .Dock = DockStyle.Fill
            .Text = "Menù"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonMixCP
            .Margin = New Padding(0, 1, 0, 1)
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.White
            .Text = "Calcola mix C/P"
        End With
        With ButtonFrequenzaCip
            .Margin = New Padding(0, 1, 0, 1)
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.White
            .Text = "Frequenza per CIP"
        End With
        With ButtonFrequenzaRamoProdotto
            .Margin = New Padding(0, 1, 0, 1)
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.White
            .Text = "Frequenza per ramo e prodotto"
        End With
        With ButtonFrequenzaConvenzioni
            .Margin = New Padding(0, 1, 0, 1)
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.White
            .Text = "Frequenza auto per convenzione"
        End With
        With ButtonStatisticheLiquidato
            .Margin = New Padding(0, 1, 0, 1)
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.White
            .Text = "Statistiche sul liquidato"
        End With
        With ButtonStatisticheComparto
            .Margin = New Padding(0, 1, 0, 1)
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.White
            .Text = "Statistiche per comparto"
        End With
        With ButtonEsporta
            .Margin = New Padding(0, 1, 0, 1)
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.Green
            .ForeColor = Color.White
            .Text = "Esporta in CSV"
        End With
        With ButtonEsci
            .Margin = New Padding(0, 1, 0, 1)
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With dgvStatistiche
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .Margin = New Padding(1)
        End With
        Utx.NetFunc.DoppioBuffer(dgvStatistiche)
    End Sub

    Private Sub ButtonMixCP_Click(sender As Object, e As EventArgs) Handles ButtonMixCP.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            TipoStatistica = Tipo.MIX_COSE_PERSONE
            FormFiltro = New Utx.FormGestioneFiltro(1000)

            With dgvStatistiche
                .DataSource = Nothing
                .DataSource = CalcolaMixCP(LabelDesk)

                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                With .Columns("Mix")
                    .HeaderText = "Mix C/P %"
                    .DefaultCellStyle.Format = "##0.00"
                End With
                With .Columns("Diff")
                    .HeaderText = "Diff.% anno precedente"
                    .DefaultCellStyle.Format = "##0.00"
                    .DefaultCellStyle.BackColor = Color.Yellow
                End With
                .Columns("GCose").HeaderText = "Gestionale Cose"
                .Columns("GPersone").HeaderText = "Gestionale Persone"
                With .Columns("MixGest")
                    .HeaderText = "Mix C/P % gestionale"
                    .DefaultCellStyle.Format = "##0.00"
                End With
                With .Columns("DiffGest")
                    .HeaderText = "Diff.% anno precedente gestionale"
                    .DefaultCellStyle.Format = "##0.00"
                    .DefaultCellStyle.BackColor = Color.Yellow
                End With

                .Rows(.Rows.Count - 1).DefaultCellStyle.Font = Utx.AppFont.Bold
                .Rows(.Rows.Count - 1).DefaultCellStyle.ForeColor = Utx.AppColor.RossoScuro
                .Rows(.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Gainsboro

                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            End With
            Utx.NetFunc.BloccaOrdinamento(dgvStatistiche)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonFrequenzaCip_Click(sender As Object, e As EventArgs) Handles ButtonFrequenzaCip.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            TipoStatistica = Tipo.FREQUENZA_CIP
            FormFiltro = New Utx.FormGestioneFiltro(1000)

            With dgvStatistiche
                .DataSource = Nothing
                .DataSource = FrequenzaPerCip(LabelDesk)

                Try
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    .Columns("Codice").HeaderText = "CIP"
                    .Columns("RamoSinistro").HeaderText = "Ramo sinistro"
                    .Columns("NumeroSinistri").HeaderText = "Numero sinistri"
                    .Columns("NumeroPolizze").HeaderText = "Numero polizze"
                    With .Columns("Frequenza")
                        .HeaderText = "Frequenza %"
                        .DefaultCellStyle.Format = "##0.00"
                        .DefaultCellStyle.BackColor = Color.Yellow
                    End With

                    .Rows(.Rows.Count - 1).DefaultCellStyle.Font = Utx.AppFont.Bold
                    .Rows(.Rows.Count - 1).DefaultCellStyle.ForeColor = Utx.AppColor.RossoScuro
                    .Rows(.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Gainsboro

                    .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                Catch ex As Exception
                End Try
            End With
            Utx.NetFunc.BloccaOrdinamento(dgvStatistiche)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonEsporta_Click(sender As Object, e As EventArgs) Handles ButtonEsporta.Click
        Try
            If dgvStatistiche.Rows.Count > 0 Then
                Dim Desk As String = LabelDesk.Text.Replace("/", "-")
                Utx.NetFunc.Esporta2Csv(dgvStatistiche, Desk, Color.Khaki)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub dgvStatistiche_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvStatistiche.CellFormatting
        If TipoStatistica = Tipo.MEDIA_LIQUIDATO OrElse TipoStatistica = Tipo.MEDIA_LIQUIDATO_COMPARTO Then
            If e.ColumnIndex = 1 AndAlso e.Value = Today.Year Then
                dgvStatistiche.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gold
                dgvStatistiche.Rows(e.RowIndex).DefaultCellStyle.Font = Utx.AppFont.Bold
            End If
        End If
    End Sub

    Private Sub dgvStatistiche_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvStatistiche.ColumnHeaderMouseClick
        Try
            If (dgvStatistiche.DataSource IsNot Nothing) Then
                'cartella per salvataggio filtro
                With FormFiltro
                    .AppName = "StatisticheSinistri"
                    .FilterFolder = Utx.Globale.Paths.CartellaSettingRete
                    .TabVisibili(True, False)

                    'visualizzo la finestra del filtro
                    .Visualizza(dgvStatistiche.Columns(e.ColumnIndex))
                End With
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub dgvStatistiche_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvStatistiche.DataSourceChanged
        dgvStatistiche.Refresh()
    End Sub

    Private Sub ButtonFrequenzaRamoProdotto_Click(sender As Object, e As EventArgs) Handles ButtonFrequenzaRamoProdotto.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            TipoStatistica = Tipo.FREQUENZA_PRODOTTO
            FormFiltro = New Utx.FormGestioneFiltro(1000)

            With dgvStatistiche
                .DataSource = Nothing
                .DataSource = FrequenzaPerRamoProdotto(LabelDesk)

                Try
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    .Columns("CodiceProdotto").HeaderText = "Prodotto"
                    .Columns("NumeroSinistri").HeaderText = "Numero sinistri"
                    .Columns("NumeroPolizze").HeaderText = "Numero polizze"
                    With .Columns("Frequenza")
                        .HeaderText = "Frequenza %"
                        .DefaultCellStyle.Format = "##0.00"
                        .DefaultCellStyle.BackColor = Color.Yellow
                    End With
                    With .Rows(0).DefaultCellStyle
                        .Font = Utx.AppFont.Bold
                        .ForeColor = Utx.AppColor.RossoScuro
                        .BackColor = Color.Gainsboro
                    End With
                    .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                    .Rows(1).Selected = True
                Catch ex As Exception
                End Try
            End With
            Utx.NetFunc.BloccaOrdinamento(dgvStatistiche)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonFrequenzaConvenzioni_Click(sender As Object, e As EventArgs) Handles ButtonFrequenzaConvenzioni.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            TipoStatistica = Tipo.FREQUENZA_CONVENZIONE
            FormFiltro = New Utx.FormGestioneFiltro(1000)

            With dgvStatistiche
                .DataSource = Nothing
                .DataSource = FrequenzaAutoPerConvenzioni(LabelDesk)

                Try
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    .Columns("RamoSinistro").HeaderText = "Ramo sinistro"
                    .Columns("NumeroSinistri").HeaderText = "Numero sinistri"
                    .Columns("NumeroPolizze").HeaderText = "Numero polizze"
                    With .Columns("Frequenza")
                        .HeaderText = "Frequenza %"
                        .DefaultCellStyle.Format = "##0.00"
                        .DefaultCellStyle.BackColor = Color.Yellow
                    End With

                    .Rows(.Rows.Count - 1).DefaultCellStyle.Font = Utx.AppFont.Bold
                    .Rows(.Rows.Count - 1).DefaultCellStyle.ForeColor = Utx.AppColor.RossoScuro
                    .Rows(.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Gainsboro

                    .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                Catch ex As Exception
                End Try
            End With
            Utx.NetFunc.BloccaOrdinamento(dgvStatistiche)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonStatisticheLiquidato_Click(sender As Object, e As EventArgs) Handles ButtonStatisticheLiquidato.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            LabelDesk.Text = "Statistiche sul liquidato per RAMO SINISTRO, ANNO e TIPO CID"

            TipoStatistica = Tipo.MEDIA_LIQUIDATO
            FormFiltro = New Utx.FormGestioneFiltro(1000)

            With dgvStatistiche
                .DataSource = Nothing
                .DataSource = StatisticheLiquidato()

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns("EsercizioSinistro").HeaderText = "Esercizio sinistro"
                With .Columns("RamoSinistro")
                    .HeaderText = "Ramo sinistro"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                With .Columns("TipoCid")
                    .HeaderText = "Tipo CID"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns("StatoBilancistico").HeaderText = "Stato bilancistico"
                .Columns("NumeroSinistri").HeaderText = "Numero sinistri"
                With .Columns("Totale")
                    .HeaderText = "Pagato"
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("Media")
                    .HeaderText = "Media sul pagato"
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .DefaultCellStyle.BackColor = Color.Yellow
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With

                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            End With
            Utx.NetFunc.BloccaOrdinamento(dgvStatistiche)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonStatisticheComparto_Click(sender As Object, e As EventArgs) Handles ButtonStatisticheComparto.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            LabelDesk.Text = "Statistiche sul liquidato per COMPARTO e ANNO"

            TipoStatistica = Tipo.MEDIA_LIQUIDATO_COMPARTO
            FormFiltro = New Utx.FormGestioneFiltro(1000)

            With dgvStatistiche
                .DataSource = Nothing
                .DataSource = StatisticheLiquidatoComparto()

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns("EsercizioSinistro").HeaderText = "Esercizio sinistro"
                .Columns("Comparto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns("StatoBilancistico").HeaderText = "Stato bilancistico"
                .Columns("NumeroSinistri").HeaderText = "Numero sinistri"
                With .Columns("Totale")
                    .HeaderText = "Pagato"
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("Media")
                    .HeaderText = "Media sul pagato"
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .DefaultCellStyle.BackColor = Color.Yellow
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With

                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            End With
            Utx.NetFunc.BloccaOrdinamento(dgvStatistiche)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.ParentForm.Close()
    End Sub
End Class
