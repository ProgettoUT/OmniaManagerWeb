Imports System.IO

Public Class FormPattoRca

    Public Event RichiestaNumeroSinistro(AgenziaSinistro As Integer,
                                         EsercizioSinistro As Integer,
                                         NumeroSinistro As Long)

    Public Log As New Utx.ApplicationLog("Patto.log")
    Public UrlDoc As String

    Public Const LinkDoc As String = "http://www.utools.it/Unitools/Doc/EvidenzeSinistri/IndexDoc.htm"

    'per toolstrip1 nella scheda evidenze
    Public WithEvents cboAnnoCompetenza As New ComboBox
    Public WithEvents dtpFinoAl As New DateTimePicker
    Public WithEvents btnRiaperti As New Button
    Public WithEvents btnEvidenze As New Button
    Public WithEvents btnPlafonamenti As New Button
    Public WithEvents btnListaCompleta As New Button
    Public WithEvents btnEsci1 As New Button
    'per toolstrip2 nella scheda documenti
    Public WithEvents cboAnnoReport As New ComboBox
    Public WithEvents cboReport As New ComboBox
    Public WithEvents btnReportSP As New Button
    Public WithEvents btnTabellaProvvigioni As New Button
    Public WithEvents btnDocumentiAgenzia As New Button
    Public WithEvents btnDocumentiComuni As New Button
    Public WithEvents btnEsci2 As New Button
    Public WithEvents cboVista As New ComboBox
    Public WithEvents LabelTotaleImpatto As New Label

    Private Vista As ModeView
    Private WithEvents FormFiltro As New Utx.FormGestioneFiltro
    Private NomeBaseTab As String = "Sinistri in evidenza"
    Private WithEvents TipoVisualizzazione As New Visualizzazione

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        If Utx.Globale.IdAppOk = False Then
            Application.Exit()
        End If

        With Me
            .Font = Utx.AppFont.Normal
            .WindowState = FormWindowState.Maximized
            .Icon = Risorse.Immagini.Icon("evidenza")
            .Text = "Remunerazione Rca"
        End With

        UrlDoc = Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, "Documenti_Unipol\Patto_Unipol\Documentazione_SP_Rca")
    End Sub

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        With lbIstruzioni
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Khaki
        End With

        ImpostaToolStrip1()
        ImpostaToolStrip2()
        ImpostaControlli()

        tpMain.Text = NomeBaseTab
        tpDocumenti.Text = "Documentazione"

        'SplitContainer1.Panel2Collapsed = True
        SplitContainer1.SplitterDistance = tpMain.Height * 0.85

        With lbIstruzioni
            .BackColor = Color.Cornsilk
            .Font = Utx.AppFont.Normal
            .Text = "Istruzioni per l'utente:"
        End With

        'per settare il tipo di visualizzazione
        Vista = New ModeView(Me, wbDoc)

        'per rinominare i report della direzione
        'OrdinaReport()
        'RinominaReport()
        RiempiComboAnnoReport()

        AddHandler btnEsci2.Click, AddressOf btnEsci1_Click
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        TabControl1.ColorStyle = Utx.UtTabControl.TabColorStyle.ROSSO
        cboVista.SelectedIndex = 4
    End Sub

    Private Sub ImpostaControlli()
        With ButtonRichiestaSinistro
            .Padding = New Padding(0, 5, 0, 5)
            .Font = Utx.AppFont.Bold
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Image = Risorse.Immagini.Bitmap("sinistro")
            .ImageAlign = ContentAlignment.BottomCenter
            .Text = "Vai alla scheda del sinistro selezionato"
            .TextAlign = ContentAlignment.TopCenter
        End With
        With dgvElencoSinistri
            .Columns.Clear()
            .Font = Utx.AppFont.Normal
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        Utx.NetFunc.DoppioBuffer(dgvElencoSinistri)
    End Sub

    Private Sub ImpostaToolStrip1()

        ToolStrip1.SuspendLayout()
        ToolStrip1.BringToFront()

        With ToolStrip1
            .Font = Utx.AppFont.Normal
            .Visible = False
            .GripStyle = ToolStripGripStyle.Hidden
            .RenderMode = ToolStripRenderMode.Professional
            .Dock = DockStyle.Top
            .Items.Clear()
        End With

        Dim ttch As ToolStripControlHost

        'combo annualità
        ToolStrip1.Items.Add(New ToolStripLabel("Anno di osservazione"))
        With cboAnnoCompetenza
            .AutoSize = False
            .FlatStyle = FlatStyle.Flat
            .Width = 60
            .DropDownStyle = ComboBoxStyle.DropDownList

            For k As Integer = Now.Year - 1 To 2010 Step -1
                .Items.Add(k.ToString)
            Next
            .SelectedIndex = 0
        End With
        ttch = New ToolStripControlHost(cboAnnoCompetenza)
        ToolStrip1.Items.Add(ttch)

        'separatore
        With btnEvidenze
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Width = 70
            .Text = "Sinistri in evidenza"
            .BackColor = Color.Gold
        End With
        ttch = New ToolStripControlHost(btnEvidenze)
        ToolStrip1.Items.Add(ttch)

        ToolStrip1.Items.Add(New ToolStripSeparator)
        With btnRiaperti
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Width = 70
            .Text = "Riaperture"
            .BackColor = Color.Khaki
        End With
        ttch = New ToolStripControlHost(btnRiaperti)
        ToolStrip1.Items.Add(ttch)

        With btnPlafonamenti
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Width = 70
            .Text = "Effetti plafonature"
        End With
        ttch = New ToolStripControlHost(btnPlafonamenti)
        ToolStrip1.Items.Add(ttch)

        ToolStrip1.Items.Add(New ToolStripSeparator)

        With btnListaCompleta
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Width = 200
            .Font = Utx.AppFont.Bold
            .Text = "Elenco sinistri"
        End With
        ttch = New ToolStripControlHost(btnListaCompleta)
        ToolStrip1.Items.Add(ttch)

        ToolStrip1.Items.Add(New ToolStripSeparator)
        With LabelTotaleImpatto
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .BorderStyle = BorderStyle.Fixed3D
            .Width = 350
            .Text = "..."
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        ttch = New ToolStripControlHost(LabelTotaleImpatto)
        ttch.AutoSize = False
        ToolStrip1.Items.Add(ttch)

        With btnEsci1
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Width = 80
            .BackColor = Color.GreenYellow
            .Text = "Esci"
        End With
        ttch = New ToolStripControlHost(btnEsci1)
        ttch.AutoSize = False
        ttch.Alignment = ToolStripItemAlignment.Right
        ToolStrip1.Items.Add(ttch)

        ToolStrip1.Visible = True

        ToolStrip1.ResumeLayout()
    End Sub

    Private Sub ImpostaToolStrip2()

        ToolStrip2.SuspendLayout()
        ToolStrip2.BringToFront()

        With ToolStrip2
            .Visible = False
            .GripStyle = ToolStripGripStyle.Hidden
            .RenderMode = ToolStripRenderMode.Professional
            .Dock = DockStyle.Top
            .Items.Clear()
        End With

        Dim ttch As ToolStripControlHost

        'combo report
        ToolStrip2.Items.Add(New ToolStripLabel("Report S/P"))
        With cboAnnoReport
            .FlatStyle = FlatStyle.Flat
            .AutoSize = False
            .Width = 55
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With
        ttch = New ToolStripControlHost(cboAnnoReport)
        ToolStrip2.Items.Add(ttch)

        With cboReport
            .FlatStyle = FlatStyle.Flat
            .AutoSize = False
            .Width = 220
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With
        ttch = New ToolStripControlHost(cboReport)
        ToolStrip2.Items.Add(ttch)

        With btnReportSP
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Width = 60
            .Text = "Visualizza"
            .BackColor = Color.Gold
        End With
        ttch = New ToolStripControlHost(btnReportSP)
        ToolStrip2.Items.Add(ttch)

        ToolStrip2.Items.Add(New ToolStripSeparator)
        With btnTabellaProvvigioni
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Width = 70
            .BackColor = Color.Khaki
            .Text = "Aliquota variabile"
        End With
        ttch = New ToolStripControlHost(btnTabellaProvvigioni)
        ToolStrip2.Items.Add(ttch)

        ToolStrip2.Items.Add(New ToolStripSeparator)
        With btnDocumentiAgenzia
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Width = 100
            .Text = "Documenti S/P Rca"
        End With
        ttch = New ToolStripControlHost(btnDocumentiAgenzia)
        ToolStrip2.Items.Add(ttch)

        With btnDocumentiComuni
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Width = 100
            .Text = "Documentazione"
        End With
        ttch = New ToolStripControlHost(btnDocumentiComuni)
        ToolStrip2.Items.Add(ttch)

        With btnEsci2
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Width = 80
            .BackColor = Color.GreenYellow
            .Text = "Esci"
        End With
        ttch = New ToolStripControlHost(btnEsci2)
        ttch.AutoSize = False
        ttch.Alignment = ToolStripItemAlignment.Right
        ToolStrip2.Items.Add(ttch)

        'combo viste
        ToolStrip2.Items.Add(New ToolStripSeparator)
        ToolStrip2.Items.Add(New ToolStripLabel("Visualizza"))
        With cboVista
            .FlatStyle = FlatStyle.Flat
            .AutoSize = False
            .Width = 100
            .DropDownStyle = ComboBoxStyle.DropDownList
            .ForeColor = Color.IndianRed

            .Items.Add("Icone")
            .Items.Add("Dettagli")
            .Items.Add("Icone piccole")
            .Items.Add("Elenco")
            .Items.Add("Titoli")

            .SelectedIndex = 4
        End With
        ttch = New ToolStripControlHost(cboVista)
        ToolStrip2.Items.Add(ttch)

        ToolStrip2.Visible = True

        ToolStrip2.ResumeLayout()
    End Sub

    Private Sub Riaperti()
        Try
            Cursor.Current = Cursors.WaitCursor

            dgvElencoSinistri.DataSource = Nothing

            Dim Query As String = String.Format("SELECT intest_pol_9,
                soglia_anno_preced_12 as Soglia,
                esercizio_sx_4,
                FORMAT(age_sin_3,'0000') + '.' + FORMAT(esercizio_sx_4,'0000') + '.' + FORMAT(num_sin_5,'00000') AS Sinistro,
                tipo_chius_10,
                costo_sx_iniz_ep_22 as CostoIniziale,
                costo_fin_sx_ep_lordo_punte_30 AS CostoFinale,
                costo_fin_sx_ep_plafonato_31 AS CostoFinalePlafonato,
                -sopravv_32 AS Impatto 
                FROM SinistriAia 
                WHERE esercizio_sx_4 < AnnoCompetenza AND 
                    AnnoCompetenza = {0} AND 
                    costo_sx_iniz_ep_22 = 0 AND 
                    sopravv_32 <= {1} 
                ORDER BY sopravv_32", cboAnnoCompetenza.Text, -10000)

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            Dim dRow As DataRow, Desk As String
            For Each dRow In dt.Rows
                If IsDBNull(dRow("tipo_chius_10")) Then
                    Desk = ".."
                Else
                    Desk = DeskChiusura(dRow("tipo_chius_10"))
                End If
                dRow("tipo_chius_10") = Desk
            Next

            dgvElencoSinistri.DataSource = dt

            FormattaColonne()

            'blocco ordinamento
            For Each c As DataGridViewColumn In dgvElencoSinistri.Columns
                c.SortMode = DataGridViewColumnSortMode.Programmatic
            Next

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Evidenze()
        Try
            Cursor.Current = Cursors.WaitCursor

            dgvElencoSinistri.DataSource = Nothing

            Dim Query As String = String.Format("SELECT intest_pol_9,
                soglia_anno_preced_12 as Soglia,esercizio_sx_4,
                Format(age_sin_3,'0000') + '.' + Format(esercizio_sx_4,'0000') + '.' + Format(num_sin_5,'00000') AS Sinistro,
                tipo_chius_10,
                costo_sx_iniz_ep_22 AS CostoIniziale,
                costo_fin_sx_ep_lordo_punte_30 AS CostoFinale,
                costo_fin_sx_ep_plafonato_31 AS CostoFinalePlafonato,
                -sopravv_32 as Impatto 
                FROM SinistriAia 
                WHERE esercizio_sx_4 <= {0} AND AnnoCompetenza = {1} AND sopravv_32 <= {2}
                ORDER BY sopravv_32", cboAnnoCompetenza.Text - 2, cboAnnoCompetenza.Text, -10000)

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            Dim dRow As DataRow, Desk As String
            For Each dRow In dt.Rows
                If IsDBNull(dRow("tipo_chius_10")) Then
                    Desk = ".."
                Else
                    Desk = DeskChiusura(dRow("tipo_chius_10"))
                End If
                dRow("tipo_chius_10") = Desk
            Next

            dgvElencoSinistri.DataSource = dt

            FormattaColonne()

            'blocco ordinamento
            For Each c As DataGridViewColumn In dgvElencoSinistri.Columns
                c.SortMode = DataGridViewColumnSortMode.Programmatic
            Next

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Plafonamenti()
        Try
            Cursor.Current = Cursors.WaitCursor

            dgvElencoSinistri.DataSource = Nothing

            Dim Query As String = String.Format("SELECT intest_pol_9,
                IIF(eser_den_11 = 'EC',soglia_anno_corrente_13,soglia_anno_preced_12) AS Soglia,
                esercizio_sx_4,
                FORMAT(age_sin_3,'0000') + '.' + FORMAT(esercizio_sx_4,'0000') + '.' + FORMAT(num_sin_5,'00000') AS Sinistro,
                tipo_chius_10,
                IIF(eser_den_11 = 'EC',0,costo_sx_iniz_ep_22) AS CostoIniziale,
                IIF(eser_den_11 = 'EC',0,costo_sx_iniz_ep_plafonato_23) AS CostoInizialePlafonato,
                IIF(eser_den_11 = 'EC',costo_sx_ec_lordo_punte_20,costo_fin_sx_ep_lordo_punte_30) AS CostoFinale,
                IIF(eser_den_11 = 'EC',costo_sx_ec_plafonato_21,costo_fin_sx_ep_plafonato_31) AS CostoFinalePlafonato,
                IIF(eser_den_11 = 'EC',costo_sx_ec_plafonato_21,-sopravv_32) as Impatto 
                FROM SinistriAia 
                WHERE AnnoCompetenza = {0} AND 
                ((eser_den_11 = 'EP' AND 
                (costo_sx_iniz_ep_22 >= soglia_anno_preced_12 OR costo_fin_sx_ep_lordo_punte_30 >= soglia_anno_preced_12) 
                OR (eser_den_11 = 'EC' AND costo_sx_ec_lordo_punte_20 >= soglia_anno_corrente_13))) 
                ORDER BY sopravv_32", cboAnnoCompetenza.Text)

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            Dim dRow As DataRow, Desk As String
            For Each dRow In dt.Rows
                If IsDBNull(dRow("tipo_chius_10")) Then
                    Desk = ".."
                Else
                    Desk = DeskChiusura(dRow("tipo_chius_10"))
                End If

                dRow("tipo_chius_10") = Desk
            Next

            dgvElencoSinistri.DataSource = dt

            FormattaColonne()
            Utx.NetFunc.BloccaOrdinamento(dgvElencoSinistri)

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function DeskChiusura(TipoChiusura As String) As String
        Select Case TipoChiusura
            Case "", "00" : Return ".."
            Case "02", "04", "05", "08", "09" : Return "LT"
            Case "03" : Return "SS"
            Case Else : Return ""
        End Select
    End Function

    Private Sub ElencoSinistri()
        Try
            Cursor.Current = Cursors.WaitCursor

            dgvElencoSinistri.DataSource = Nothing

            Dim Query As String = String.Format("SELECT 
                CASE
                WHEN eser_den_11 = 'EC' THEN costo_sx_ec_plafonato_21
                ELSE -sopravv_32
                END AS Impatto,* 
                FROM SinistriAia 
                WHERE AnnoCompetenza = {0} 
                ORDER BY sopravv_32", cboAnnoCompetenza.Text)

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            dgvElencoSinistri.SuspendLayout()

            dgvElencoSinistri.DataSource = dt
            CalcolaImpattoTotale()

            'formattazione
            dgvElencoSinistri.Columns(0).DefaultCellStyle.Format = "###,###,##0.00"
            dgvElencoSinistri.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            For k As Integer = 1 To 8
                dgvElencoSinistri.Columns(k).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            For k As Integer = 11 To 12
                dgvElencoSinistri.Columns(k).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            For k As Integer = 13 To dgvElencoSinistri.ColumnCount - 1
                dgvElencoSinistri.Columns(k).DefaultCellStyle.Format = "###,###,##0.00"
                dgvElencoSinistri.Columns(k).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Next
            dgvElencoSinistri.AutoResizeColumns()
            'blocco ordinamento
            Utx.NetFunc.BloccaOrdinamento(dgvElencoSinistri)

            dgvElencoSinistri.ResumeLayout()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CalcolaImpattoTotale()
        Try
            If dgvElencoSinistri.Rows.Count > 0 Then
                Dim totale As Double = 0

                For Each row As DataGridViewRow In dgvElencoSinistri.Rows
                    totale += row.Cells("impatto").Value
                Next
                LabelTotaleImpatto.Text = String.Format("Impatto sinistri visualizzati: {0:#,###,##0.00}", totale)
                If totale > 0 Then
                    LabelTotaleImpatto.BackColor = Color.LightSalmon
                Else
                    LabelTotaleImpatto.BackColor = Color.LightGreen
                End If
            End If
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub btnEsci1_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci1.Click
        Me.Close()
    End Sub

    Private Sub btnRiaperti_Click(sender As Object, e As System.EventArgs) Handles btnRiaperti.Click
        tpMain.Text = btnRiaperti.Text
        Riaperti()

        lbIstruzioni.Text = "Nelle riaperture sono visualizzati i sinistri di esercizi precedenti all'anno di " +
                            "osservazione che, per vari motivi, sono stati riaperti nell'anno considerato." + vbNewLine +
                            "Poiché il processo di riapertura può dar luogo ad incongruenze, " +
                            "si consiglia di effettuare una verifica dei sinistri evidenziati. " +
                            "Di tali sinistri (esercizi 2009 e precedenti) è opportuno verificare che il totale " +
                            "pagato negli anni precedenti, non sia superiore al valore " +
                            "riportato nella colonna (A). In questo caso, la differenza andrebbe scalata " +
                            "dall'impatto del sinistro (colonna B-A). " +
                            "Nella colonna impatto sono da considerarsi a debito dell'agenzia gli importi positivi " +
                            "(in rosso) e a credito dell'agenzia (smontamenti) gli importi negativi (in verde)."
        SplitContainer1.Panel2Collapsed = False
        TipoVisualizzazione.TipoVisualizzazione = Visualizzazione.Tipo.RIAPERTURE
    End Sub

    Private Sub btnEvidenze_Click(sender As Object, e As System.EventArgs) Handles btnEvidenze.Click
        tpMain.Text = btnEvidenze.Text
        Evidenze()

        lbIstruzioni.Text = "Nei sinistri in evidenza sono visualizzati i sinistri di esercizi precedenti all'anno di " +
                            "osservazione che hanno avuto un impatto rilevante nell'anno considerato." + vbNewLine +
                            "Di tali sinistri (esercizi 2009 e precedenti) è opportuno verificare che il totale " +
                            "pagato negli anni precedenti, non sia superiore al valore " +
                            "riportato nella colonna (A). In questo caso, la differenza andrebbe scalata " +
                            "dall'impatto del sinistro (colonna B-A). " +
                            "Nella colonna impatto sono da considerarsi a debito dell'agenzia gli importi positivi " +
                            "(in rosso) e a credito dell'agenzia (smontamenti) gli importi negativi (in verde)."
        SplitContainer1.Panel2Collapsed = False
        TipoVisualizzazione.TipoVisualizzazione = Visualizzazione.Tipo.EVIDENZE
    End Sub

    Private Sub btnPlafonamenti_Click(sender As Object, e As System.EventArgs) Handles btnPlafonamenti.Click
        tpMain.Text = btnPlafonamenti.Text
        Plafonamenti()

        lbIstruzioni.Text = "Negli effetti plafonature sono visualizzati i sinistri con un costo oltre la soglia " +
                            "(plafond) dell'agenzia." + vbNewLine +
                            "Tali sinistri vengono addebitati per un valore massimo pari al plafond che può essere " +
                            "raggiunto anche nel corso di più annualità. " +
                            "L'impatto del sinistro sull'S/P dell'anno osservato è stato riportato nell'ultima colonna " +
                            "ed è ottenuto come differenza fra il costo finale e gli " +
                            "importi già addebitati nelle annualità precedenti. I sinistri oltre soglia nelle " +
                            "annualità precedenti hanno impatto zero. " +
                            "Nella colonna impatto sono da considerarsi a debito dell'agenzia gli importi positivi " +
                            "(in rosso) e a credito dell'agenzia (smontamenti) gli importi negativi (in verde)."
        SplitContainer1.Panel2Collapsed = False
        TipoVisualizzazione.TipoVisualizzazione = Visualizzazione.Tipo.PLAFONATURE
    End Sub

    Private Sub btnListaCompleta_Click(sender As Object, e As System.EventArgs) Handles btnListaCompleta.Click
        tpMain.Text = btnListaCompleta.Text
        ElencoSinistri()

        lbIstruzioni.Text = "Questo è l'elenco completo dei sinistri nell'anno di osservazione così come " +
                            "è stato trasmesso dalla compagnia." + vbNewLine +
                            "E' stata solo aggiunta, per una più facile lettura, la prima colonna che riporta " +
                            "l'impatto del sinistro sul rapporto S/P dell'anno osservato." + vbNewLine +
                            "Nella colonna impatto sono da considerarsi a debito dell'agenzia gli importi positivi " +
                            "(in rosso) e a credito dell'agenzia (smontamenti) gli importi negativi (in verde). " +
                            "In questo elenco è possibile effettuare ricerche per numero sinistro o assicurato."
        SplitContainer1.Panel2Collapsed = False
        TipoVisualizzazione.TipoVisualizzazione = Visualizzazione.Tipo.ELENCO
    End Sub

    Private Sub dgv1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvElencoSinistri.CellFormatting
        On Error Resume Next
        If e.ColumnIndex = dgvElencoSinistri.Columns("Impatto").Index Then
            Select Case e.Value
                Case Is > 0 : e.CellStyle.BackColor = Color.LightSalmon
                Case Is < 0 : e.CellStyle.BackColor = Color.LightGreen
            End Select
        End If
    End Sub

    Private Sub FormattaColonne()

        On Error Resume Next

        With dgvElencoSinistri
            .SuspendLayout()

            With .Columns("intest_pol_9")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .HeaderText = "Assicurato"
            End With
            With .Columns("esercizio_sx_4")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Anno di generazione"
            End With
            With .Columns("num_sin_5")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Numero sinistro"
            End With
            With .Columns("soglia")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0"
                '.DefaultCellStyle.BackColor = Color.Gold
                .HeaderText = "Plafond"
            End With
            With .Columns("tipo_chius_10")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Stato"
            End With
            With .Columns("costo_fin_sx_ep_plafonato_31")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Valore del sinistro plafonato al " +
                              New DateTime(cboAnnoCompetenza.Text, 12, 31).ToShortDateString +
                              " (B)"
            End With
            With .Columns("Impatto")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Impatto su rapporto S/P agenzia (B-A)"
            End With
            With .Columns("CostoIniziale")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Valore al " +
                              New DateTime(cboAnnoCompetenza.Text - 1, 12, 31).ToShortDateString +
                              " (A)"
            End With
            With .Columns("CostoInizialePlafonato")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Valore plafonato al " +
                              New DateTime(cboAnnoCompetenza.Text - 1, 12, 31).ToShortDateString +
                              " (A)"
            End With
            With .Columns("CostoFinale")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Valore al " +
                              New DateTime(cboAnnoCompetenza.Text, 12, 31).ToShortDateString
            End With
            With .Columns("CostoFinalePlafonato")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Valore plafonato al " +
                              New DateTime(cboAnnoCompetenza.Text - 1, 12, 31).ToShortDateString +
                              " (B)"
            End With

            .AutoResizeColumns()

            .ResumeLayout()
        End With
    End Sub

    Private Sub cboAnnoCompetenza_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboAnnoCompetenza.SelectedIndexChanged
        dgvElencoSinistri.DataSource = Nothing
    End Sub

    Private Sub btnIndice_Click(sender As System.Object, e As System.EventArgs)
        wbDoc.Navigate(LinkDoc)
    End Sub

    Private Sub tpDocumenti_Enter(sender As Object, e As System.EventArgs) Handles tpDocumenti.Enter
        SplitContainer1.Panel2Collapsed = True
    End Sub

    Private Sub dgv1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvElencoSinistri.ColumnHeaderMouseClick
        FormFiltro.Visualizza(dgvElencoSinistri.Columns(e.ColumnIndex))
        CalcolaImpattoTotale()
    End Sub

    Private Sub dgvElencoSinistri_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvElencoSinistri.MouseDoubleClick
        If dgvElencoSinistri.CurrentRow IsNot Nothing Then
            RaiseEvent RichiestaNumeroSinistro(dgvElencoSinistri.CurrentRow.Cells("age_sin_3").Value,
                                               dgvElencoSinistri.CurrentRow.Cells("esercizio_sx_4").Value,
                                               dgvElencoSinistri.CurrentRow.Cells("num_sin_5").Value)
        End If
    End Sub

    Private Sub dgv1_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvElencoSinistri.SelectionChanged
        On Error Resume Next

        If dgvElencoSinistri.CurrentRow.Cells("Sinistro") Is Nothing Then
            Clipboard.SetText(dgvElencoSinistri.CurrentRow.Cells("num_sin_5").Value)
        Else
            Clipboard.SetText(dgvElencoSinistri.CurrentRow.Cells("Sinistro").Value.ToString.Split(".")(2))
        End If
    End Sub

    Private Sub btnReportSP_Click(sender As Object, e As System.EventArgs) Handles btnReportSP.Click
        If cboReport.SelectedIndex < 0 Then Exit Sub

        Dim NomeReport As String = cboReport.SelectedItem.FullName

        If File.Exists(NomeReport) Then
            wbDoc.Navigate(NomeReport)
        Else
            'avviso di file non trovato
            Avviso(NomeReport)
            'poi visualizza i documenti comuni
            wbDoc.Navigate(LinkDoc)
        End If
    End Sub

    Private Sub btnTabellaProvvigioni_Click(sender As Object, e As System.EventArgs) Handles btnTabellaProvvigioni.Click
        Dim f As New FormProvvigioni
        f.Show()
    End Sub

    Private Sub btnDocumentiAgenzia_Click(sender As Object, e As System.EventArgs) Handles btnDocumentiAgenzia.Click
        If Directory.Exists(UrlDoc) Then
            cboVista.SelectedIndex = 4
            wbDoc.Navigate(UrlDoc)
        Else
            MsgBox("Cartella documenti non trovata", MsgBoxStyle.Exclamation, "Unitools")
        End If
    End Sub

    Private Sub btnDocumentiComuni_Click(sender As Object, e As System.EventArgs) Handles btnDocumentiComuni.Click
        wbDoc.Navigate(LinkDoc)
    End Sub

    Private Sub Avviso(Optional NomeFile As String = "")
        MsgBox("I dati richiesti non sono stati trovati." + vbNewLine +
               "Attendere la prossima importazione dati e quindi riprovare." + vbNewLine + vbNewLine +
               IIf(NomeFile.Length > 0, "File: " + NomeFile, ""), MsgBoxStyle.Information, "Unitools")
    End Sub

    Private Sub cboVista_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboVista.SelectedIndexChanged
        On Error Resume Next
        Vista.SetView(cboVista.SelectedIndex)
    End Sub

    Private Sub wbDoc_DocumentCompleted(sender As Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles wbDoc.DocumentCompleted
        On Error Resume Next
        Vista.SetView(cboVista.SelectedIndex)
    End Sub

    Private Sub OrdinaReport()

        'se esiste la cartella 2010 ed è vuota la cancella
        Dim PathDoc As String = Path.Combine(UrlDoc, "2010")

        If NumeroFile(PathDoc) = 0 Then
            Directory.Delete(PathDoc, True)
        End If

        'per sicurezza creo le cartelle
        Directory.CreateDirectory(Path.Combine(UrlDoc, "2011"))
        Directory.CreateDirectory(Path.Combine(UrlDoc, "2012"))

        'sposto file
        If File.Exists(Path.Combine(UrlDoc, String.Format("2012\{0}_Rep_aliq_RCA_al122011.pdf", Utx.Globale.AgenziaRichiesta.CodiceAgenzia))) Then
            File.Move(Path.Combine(UrlDoc, String.Format("2012\{0}_Rep_aliq_RCA_al122011.pdf", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)),
                      Path.Combine(UrlDoc, String.Format("2011\{0}_Rep_aliq_RCA_al122011.pdf", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)))
        End If
        If File.Exists(Path.Combine(UrlDoc, String.Format("2012\{0}_Rep_aliq_RCA_biennio.pdf", Utx.Globale.AgenziaRichiesta.CodiceAgenzia))) Then
            File.Move(Path.Combine(UrlDoc, String.Format("2012\{0}_Rep_aliq_RCA_biennio.pdf", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)),
                      Path.Combine(UrlDoc, String.Format("2011\{0}_Rep_aliq_RCA_biennio.pdf", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)))
        End If
        If File.Exists(Path.Combine(UrlDoc, String.Format("2012\{0}_RCA_10_11_NEW.pdf", Utx.Globale.AgenziaRichiesta.CodiceAgenzia))) Then
            File.Move(Path.Combine(UrlDoc, String.Format("2012\{0}_RCA_10_11_NEW.pdf", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)),
                      Path.Combine(UrlDoc, String.Format("2011\{0}_RCA_10_11_NEW.pdf", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)))
        End If
    End Sub

    Private Sub RinominaReport()

        'anno 2011
        Dim NomeFileOld As String = Path.Combine(UrlDoc, String.Format("2011\{0}_Rep_aliq_RCA_biennio.pdf", Utx.Globale.AgenziaRichiesta.CodiceAgenzia))
        Dim NomeFileNew As String = Path.Combine(UrlDoc, String.Format("2011\{0}_SP_RCA_2010_2011.pdf", Utx.Globale.AgenziaRichiesta.CodiceAgenzia))

        If File.Exists(NomeFileOld) And (Not File.Exists(NomeFileNew)) Then
            File.Copy(NomeFileOld, NomeFileNew)
        End If

        NomeFileOld = Path.Combine(UrlDoc, String.Format("2011\{0}_RCA_10_11_NEW.pdf", Utx.Globale.AgenziaRichiesta.CodiceAgenzia))
        NomeFileNew = Path.Combine(UrlDoc, String.Format("2011\{0}_SP_RCA_2010_2011_2.pdf", Utx.Globale.AgenziaRichiesta.CodiceAgenzia))

        If File.Exists(NomeFileOld) And (Not File.Exists(NomeFileNew)) Then
            File.Copy(NomeFileOld, NomeFileNew)
        End If

        'anno dal 2012 in poi
        Dim ModelloOld As String = "{0}\{1}_RCA_{2}_{3}.pdf"
        Dim ModelloNew As String = "{0}\{1}_SP_RCA_{2}_{3}.pdf"

        For Anno As Integer = 2012 To Now.Year - 1
            NomeFileOld = Path.Combine(UrlDoc, String.Format(ModelloOld, Anno, Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Anno - 2001, Anno - 2000))
            NomeFileNew = Path.Combine(UrlDoc, String.Format(ModelloNew, Anno, Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Anno - 1, Anno))

            If File.Exists(NomeFileOld) And (Not File.Exists(NomeFileNew)) Then
                File.Copy(NomeFileOld, NomeFileNew)
            End If
        Next
    End Sub

    Private Sub RiempiComboAnnoReport()
        Try
            Dim di As New DirectoryInfo(UrlDoc)
            Directory.CreateDirectory(UrlDoc) ' se non c'è la creo

            cboAnnoReport.Items.Clear()

            For Each d As DirectoryInfo In di.GetDirectories("????")
                If Val(d.Name) > 0 Then cboAnnoReport.Items.Add(d)
            Next

            cboAnnoReport.Sorted = True
            cboAnnoReport.SelectedIndex = cboAnnoReport.Items.Count - 1

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub RiempiComboReport()
        Try
            Dim PathDoc As New DirectoryInfo(Path.Combine(UrlDoc, cboAnnoReport.Text))

            cboReport.Items.Clear()

            For Each f As FileInfo In PathDoc.GetFiles("*_SP_RCA_*.pdf")
                cboReport.Items.Add(f)
            Next

            'cosa visualizzare nel combo
            cboReport.DisplayMember = "Name"

            'seleziona il più recente con l'indice=0
            If cboReport.Items.Count > 0 Then cboReport.SelectedIndex = 0

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub cboAnnoReport_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboAnnoReport.SelectedIndexChanged
        RiempiComboReport()
    End Sub

    Private Sub cboReport_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboReport.SelectedIndexChanged
        If cboReport.SelectedIndex >= 0 Then btnReportSP_Click(Me, New EventArgs)
    End Sub

    Private Sub ButtonRichiestaSinistro_Click(sender As Object, e As EventArgs) Handles ButtonRichiestaSinistro.Click
        If dgvElencoSinistri.CurrentRow IsNot Nothing Then
            Select Case TipoVisualizzazione.TipoVisualizzazione
                Case Visualizzazione.Tipo.ELENCO
                    RaiseEvent RichiestaNumeroSinistro(dgvElencoSinistri.CurrentRow.Cells("age_sin_3").Value,
                                                       dgvElencoSinistri.CurrentRow.Cells("esercizio_sx_4").Value,
                                                       dgvElencoSinistri.CurrentRow.Cells("num_sin_5").Value)
                Case Else
                    RaiseEvent RichiestaNumeroSinistro(dgvElencoSinistri.CurrentRow.Cells("Sinistro").Value.ToString.Split(".")(0),
                                                       dgvElencoSinistri.CurrentRow.Cells("Sinistro").Value.ToString.Split(".")(1),
                                                       dgvElencoSinistri.CurrentRow.Cells("Sinistro").Value.ToString.Split(".")(2))
            End Select
        End If
    End Sub

    Private Class Visualizzazione

        Public Event CambioVisualizzazione(Tipo As Tipo)

        Public Enum Tipo
            NESSUNA
            RIAPERTURE
            EVIDENZE
            PLAFONATURE
            ELENCO
        End Enum

        Sub New()
            mTipoVisualizzazione = Tipo.NESSUNA
        End Sub

        Private mTipoVisualizzazione As Tipo
        Public Property TipoVisualizzazione() As Tipo
            Get
                Return mTipoVisualizzazione
            End Get
            Set(value As Tipo)
                mTipoVisualizzazione = value
                RaiseEvent CambioVisualizzazione(mTipoVisualizzazione)
            End Set
        End Property
    End Class
End Class
