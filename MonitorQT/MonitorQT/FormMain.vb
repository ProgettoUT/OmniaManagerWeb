Imports System.IO
Imports System.Data.OleDb
Imports System.Text

Public Class FormMain

    Friend FormFiltro As New Utx.FormGestioneFiltro(1000)

    Private Const LinkDoc As String = "http://www.utools.it/Unitools/Doc/MonitorQT/IndexDoc.htm"
    Private Const AliquotaSSN As Double = 10.5

    Private cn As New OleDbConnection
    Private csClasse As New DataGridViewCellStyle
    Private csTotali As New DataGridViewCellStyle
    Private GrigliaFormattata As Boolean = False

    Private dt As New DataTable
    Private da As New OleDbDataAdapter
    Private bs As New BindingSource
    Private cmdTotali As New OleDbCommand

    Private WithEvents cboSaturazione As New ComboBox
    Private WithEvents btnVisualizzaQT As New Button
    Private WithEvents btnExcel As New Button
    Private WithEvents btnStampaTutto As New Button
    Private WithEvents btnAnagCliente As New Button

    Private WhereContraente As String
    Private WhereDate As String
    Private WhereSub As String
    Private WhereProduttore As String
    Private WhereFiltro As String
    Private WhereSaturazione As String

    Private Enum Query
        [QTPreviste]
        [QTUbox]
        [QTConv]
        [QTNoVar]
        [QTVar]
        [QTSost]
        [QTDisdette]
        [QTDisdetteVarA]
        [QTDisdetteVarD]
        [QTDisdetteVarX]
        [IncassiPrevisti]
        [IncassiNoVar]
        [IncassiVar]
        [IncassiDiffVar]
        [IncassiDiffVarFascia]
        [IncassiDiffVarA]
        [IncassiDiffVarD]
        [IncassiDiffVarX]
        [IncassiDisdette]
        [IncassiDisdetteA]
        [IncassiDisdetteD]
        [IncassiDisdetteX]
        [IncassiAnnoPrecedente]
    End Enum

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.WindowState = FormWindowState.Maximized
        Me.Icon = Risorse.Immagini.Icon("monitor")
        Me.Font = Utx.AppFont.Normal

        ImpostaControlli()
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Try
            Log.Info(FileVersionInfo.GetVersionInfo(Path.Combine(Utx.Globale.Paths.CartellaApp, "MonitorQT.dll")).ProductVersion)
            TabQuietanze.ColorStyle = Utx.UtTabControl.TabColorStyle.ROSSO
            TabStat.ColorStyle = Utx.UtTabControl.TabColorStyle.AZZURRO

            Me.Refresh()

            If Not EsisteTabellaQt("MonitorQt") Then
                MsgBox(String.Format("Dati monitor quietanzamento Rca inesistenti.{0}" +
                                     "Attendere l'importazione automatica dei dati.",
                                     Environment.NewLine, MsgBoxStyle.Exclamation))
                Me.Close()
            End If

            Me.SuspendLayout()

            AggiornaFlag()
            ResetControlli()
            txtCerca.Focus()

            Me.ResumeLayout()

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub ImpostaControlli()
        With csClasse
            .Font = New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)
            .BackColor = Color.Linen
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        With csTotali
            .Font = New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)
            .BackColor = Color.GreenYellow
            .Format = "###,##0.00"
            .Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        ToolTip1.SetToolTip(lbTipoQT, "Tipo quietanza")
        ToolTip1.SetToolTip(lbConvenzione, "Convenzione")

        dtpInizio.Value = DataInizioMese(Now)
        dtpFine.Value = DataFineMese(Now)

        TabQuietanze.ItemSize = New Size(150, 25)
        TabStat.ItemSize = New Size(150, 25)

        With btnAnnullaFiltri
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = ContentAlignment.MiddleCenter
            .Text = ""
        End With
        With btnHelp
            .Padding = New Padding(5, 0, 5, 0)
            .Image = Risorse.Immagini.Bitmap("help")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Guida"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With btnEsci
            .Padding = New Padding(5, 0, 5, 0)
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleRight
        End With

        ImpostaToolStripMain()
        ImpostaListaDettaglio()
        ImpostaTab(0)
        ImpostaGrid(dgv1)
        ImpostaNote()
        ImpostaComboFiltro()
        ImpostaGrigliaStat()
        ImpostaGrigliaStat2()

        ToolStripButton1.Tag = True
        ToolStripPbStat.Visible = False
        ToolStripButton2.Visible = False

        With SplitMain
            .IsSplitterFixed = True
            .Panel2MinSize = .Height * 0.25
            .SplitterDistance = .Height * 0.45
            .Panel2Collapsed = False
        End With
        With SplitPannello
            .Panel2MinSize = .Height * 0.25
            .SplitterDistance = .Width * 0.75
            .Panel2Collapsed = False
        End With

        ImpostaGroupBox()

        chkNascondiColonne.Checked = True
        chkBloccaColonne.Checked = True
        chkAutoSize.Checked = True

        gbDettaglio.Text = "Dettaglio quietanza"

        lbMessaggio.Text = ""
        lbTipoVeicolo.Text = ""
        lbTasse.Text = ""
        lbDeskStatistiche.Text = "Incassato auto, nel periodo e per le figure selezionate, su quietanze (tipo carico 4)." +
                                 " Le differenze riportano le variazioni +/- derivanti da variazioni di polizza. Sono escluse (al momento) le sostituzioni."

        LinkLabelPannello.Text = "Nascondi pannello >>"
        LinkLabelDettaglio.Text = "Nascondi dettaglio premi"

        Dim lle As System.Windows.Forms.LinkLabelLinkClickedEventArgs = Nothing
        linklabelpannello_LinkClicked(Me, lle)
    End Sub

    Private Sub ImpostaToolStripMain()
        On Error Resume Next

        With ToolStripMain
            .Font = New Font("Verdana", 9)
            .GripStyle = ToolStripGripStyle.Hidden
            .RenderMode = ToolStripRenderMode.ManagerRenderMode
            .Items.Clear()
        End With

        Dim ttch As ToolStripControlHost

        ToolStripMain.Items.Add(New ToolStripLabel(" Filtro:"))
        With cboSaturazione
            .FlatStyle = FlatStyle.Flat
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Width = 200
            .DropDownWidth = 250
            With .Items
                .Add("Tutte le quietanze")
                .Add("Senza saturazione")
                .Add("Con saturazione")
                .Add("Con saturazione Rca")
                .Add("Con saturazione CVT")
                .Add("Con saturazione massimali")
                .Add("Con saturazione gar.accessori")
                .Add("Con saturazione tutela legale")
                .Add("Con saturazione assistenza")
                .Add("Con saturazione unisalute")
                .Add("Con saturazione infortuni")
            End With
            .SelectedIndex = 0
        End With
        ttch = New ToolStripControlHost(cboSaturazione)
        ttch.AutoSize = False
        ToolStripMain.Items.Add(ttch)

        ToolStripMain.Items.Add(New ToolStripLabel(Space(1)))
        With btnVisualizzaQT
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Visualizza quietanze"
        End With
        ttch = New ToolStripControlHost(btnVisualizzaQT)
        ToolStripMain.Items.Add(ttch)

        ToolStripMain.Items.Add(New ToolStripSeparator)
        With btnExcel
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Esporta in excel"
        End With
        ttch = New ToolStripControlHost(btnExcel)
        ToolStripMain.Items.Add(ttch)

        With btnStampaTutto
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Stampa tutti i dettagli"
        End With
        ttch = New ToolStripControlHost(btnStampaTutto)
        ToolStripMain.Items.Add(ttch)

        'anag cliente
        With btnAnagCliente
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Scheda cliente"
        End With
        ttch = New ToolStripControlHost(btnAnagCliente)
        ToolStripMain.Items.Add(ttch)
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        AllineaLinkLabel()
        RidimensionaColonneDettaglio()
        ImpostaGroupBox()
    End Sub

    Private Sub ImpostaTab(Righe As Integer)
        Elenco.Text = String.Format("Elenco quietanze ({0})", Righe)
    End Sub

    Private Sub ImpostaGroupBox()
        gbDettaglio.Width = SplitMain.Width * 0.75 - 3
        gbGenerale.Width = SplitMain.Width * 0.25 - 3
    End Sub

    Private Sub ImpostaListaDettaglio()
        With lvDettaglio
            .View = View.Details
            .Font = New System.Drawing.Font("Tahoma", 9)

            .Columns.Add("campo", "Campo", 150)
            .Columns.Add("valore", "Valore", 150)
        End With
    End Sub

    Private Sub ImpostaGrid(ByRef dgv As DataGridView)
        With dgv
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .Font = New System.Drawing.Font("Tahoma", 9)
        End With
        Utx.NetFunc.DoppioBuffer(dgv)
    End Sub

    Private Sub ImpostaNote()
        txtNote.Font = New System.Drawing.Font("Tahoma", 9)
    End Sub

    Private Sub ImpostaComboFiltro()
        With cboFiltro
            .Items.Add("1. Tutte le quietanza del periodo")
            .Items.Add("2. Contraente selezionato")
            .Items.Add("3. Quietanze in malus")
            .Items.Add("4. Quietanze con Unibox")
            .Items.Add("5. Quietanze con Flex")
            .Items.Add("6. Quietanze Incassate")
            .Items.Add("7. Quietanze non Incassate")
            .Items.Add("8. Quietanze con Variazione")
            .Items.Add("9. Polizze Sostituite")
            .Items.Add("10. Polizze Disdette")
            .Items.Add("11. Quietanze senza flag")
            .Items.Add("12. Quietanze con modifica Altre Garanzie")
            .Items.Add("13. Quietanze con modifica Massimali")
            .Items.Add("14. Polizze in convenzione")

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub LeggiTab()
        Cursor.Current = Cursors.WaitCursor

        Try
            cn.ConnectionString = Utx.Globale.CnDbLink
            cn.Open()

            dt = New DataTable
            da = New OleDbDataAdapter
            da.SelectCommand = New OleDbCommand(Sql, cn)
            da.Fill(dt)

            bs.DataSource = dt

            dgv1.DataSource = bs

            FormattaColonne(dgv1)
            AggiornaDettaglio() 'per impostare correttamente le descrizioni del dettaglio
            InizializzaBinding()

            ImpostaTab(dgv1.Rows.Count)

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            cn.Close()
        End Try

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub dgv1_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgv1.CellBeginEdit
        If e.ColumnIndex > 4 Then e.Cancel = True
    End Sub

    Private Sub dgv1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        On Error Resume Next

        Select Case e.ColumnIndex
            Case dgv1.Columns("PercDiffArdRata").Index, dgv1.Columns("PercDiffTotRata").Index
                If e.Value > 0 Then
                    e.CellStyle.Font = New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)
                    e.CellStyle.BackColor = Color.LightSalmon
                Else
                    e.CellStyle.Font = New System.Drawing.Font("Tahoma", 9)
                End If
            Case dgv1.Columns("Flex").Index
                If e.Value = True Then e.CellStyle.BackColor = Color.Gold
            Case dgv1.Columns("Fatto").Index
                If e.Value = True Then e.CellStyle.BackColor = Color.GreenYellow
            Case dgv1.Columns("Variata").Index
                If e.Value = True Then e.CellStyle.BackColor = Color.OrangeRed
            Case dgv1.Columns("Sostituita").Index
                If e.Value = True Then e.CellStyle.BackColor = Color.LightGray
            Case dgv1.Columns("Disdetta").Index
                If e.Value = True Then e.CellStyle.BackColor = Color.Brown
            Case dgv1.Columns("UBox").Index
                If e.Value = "S" Then e.CellStyle.BackColor = Color.Gold
        End Select
    End Sub

    Private Sub dgv1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgv1.CurrentCellDirtyStateChanged
        If dgv1.IsCurrentCellDirty Then

            dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit)

            If dgv1.CurrentCell.Value = True Then
                Select Case dgv1.CurrentCell.ColumnIndex
                    Case 0 'flex
                        dgv1.CurrentRow.Cells("Fatto").Value = False
                        dgv1.CurrentRow.Cells("Disdetta").Value = False
                    Case 1 'fatto
                        dgv1.CurrentRow.Cells("Flex").Value = False
                        dgv1.CurrentRow.Cells("Disdetta").Value = False
                    Case 2 'disdetta
                        dgv1.CurrentRow.Cells("Flex").Value = False
                        dgv1.CurrentRow.Cells("Fatto").Value = False
                End Select

                dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If

            da.UpdateCommand = cmdUpdateCheck(dgv1.CurrentRow.Cells("Polizza").Value,
                                              dgv1.CurrentRow.Cells("Effetto").Value.ToString)

            bs.EndEdit()
            da.Update(dt)

            TotaleFlex()
        End If
    End Sub

    Private Sub dgv1_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgv1.SelectionChanged
        If GrigliaFormattata Then AggiornaDettaglio()

        'intestazione dettaglio
        Try
            gbDettaglio.Text = String.Format("Quietanza: {0} del {1}",
                                             dgv1.CurrentRow.Cells("Contraente").Value,
                                             dgv1.CurrentRow.Cells("Effetto").Value)

            lbTipoQT.Text = TipoQuietanza(dgv1.CurrentRow)

            'avviso frazionamento
            If dgv1.CurrentRow.Cells("CambioFraz").Value = "S" Then
                lbMessaggio.Text = "Attenzione: cambio frazionamento"
            Else
                lbMessaggio.Text = ""
            End If

            'differenza tasse federalismo fiscale
            Dim CoeffFraz As Double = CoefficienteFraz(dgv1.CurrentRow.Cells("FrazNew").Value)
            Dim TasseNewPerc As Double = dgv1.CurrentRow.Cells("AliquotaRca").Value + AliquotaSSN
            Dim Netto As Double = (CDbl(txtRca.Text) / CoeffFraz) * 100 / (100 + TasseNewPerc)
            lbTasse.Text = "Diff.Tasse FF " + FormIt(Netto * (dgv1.CurrentRow.Cells("AliquotaRca").Value - 12.5) / 100)

        Catch ex As Exception
            'non fare niente
        End Try

        DefaultImportoDesiderato()

        CalcolaFlex()
        TotaleQuietanze()
    End Sub

    Private Sub AggiornaDettaglio()
        If SplitPannello.Panel2Collapsed Then Exit Sub

        Try
            lvDettaglio.SuspendLayout()
            lvDettaglio.Items.Clear()

            Dim c As IEnumerator = dgv1.SelectedCells.GetEnumerator
            Dim FontBold = New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)

            Do While c.MoveNext
                Dim Desk As String = dgv1.Columns(c.Current.ColumnIndex).HeaderText
                Dim i As ListViewItem = lvDettaglio.Items.Add(Desk)
                i.SubItems.Add(c.Current.value)

                Select Case Desk
                    Case "Contraente"
                        i.Font = FontBold
                        i.ForeColor = Color.Firebrick
                End Select
            Loop

        Catch ex As Exception
            'non fare niente
        Finally
            lvDettaglio.ResumeLayout()
        End Try
    End Sub

    Private Sub dtpInizio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpInizio.ValueChanged
        On Error Resume Next
        If dtpFine.Value < dtpInizio.Value Then dtpFine.Value = dtpInizio.Value
        ResetControlli()
    End Sub

    Private Sub dtpFine_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFine.ValueChanged
        On Error Resume Next
        If dtpFine.Value < dtpInizio.Value Then dtpInizio.Value = dtpFine.Value
        ResetControlli()
    End Sub

    Private Sub FormattaColonne(ByRef dgv As DataGridView)
        On Error Resume Next

        With dgv
            .SuspendLayout()

            'intestazioni delle colonne
            .Columns("Fatto").HeaderText = "Inc"
            .Columns("Disdetta").HeaderText = "Dis Sto"
            .Columns("Sostituita").HeaderText = "Sost"
            .Columns("Variata").HeaderText = "Var"
            .Columns("FrazNew").HeaderText = "Fraz New"
            .Columns("Produttore").HeaderText = "Prod"
            .Columns("TotDiff").HeaderText = "Diff.Totale Rata"
            .Columns("PercDiffTotRata").HeaderText = "Diff.Totale Rata %"
            .Columns("MeritoOld").HeaderText = "Cl.Merito Old"
            .Columns("MeritoNew").HeaderText = "Cl.Merito New"
            .Columns("FspOld").HeaderText = "Fsp Old"
            .Columns("FspNew").HeaderText = "Fsp New"
            .Columns("DiffClasse").HeaderText = "Diff.Classe"
            .Columns("RcaLordoRataOld").HeaderText = "RCA Old"
            .Columns("RcaLordoRataNew").HeaderText = "RCA New"
            .Columns("TotDiffRc").HeaderText = "Diff.Totale RCA"
            .Columns("PercDiffRca").HeaderText = "Diff.Totale RCA %"
            .Columns("RcaLordoForzata").HeaderText = "RCA desiderata"
            .Columns("PercFlexRca").HeaderText = "Flex RCA desiderata %"
            .Columns("ImportoFlexRca").HeaderText = "Importo Flex RCA desiderata"
            .Columns("IFLordoForzata").HeaderText = "IF desiderata"
            .Columns("PercFlexIF").HeaderText = "Flex IF desiderata %"
            .Columns("ImportoFlexIF").HeaderText = "Importo Flex IF desiderata"
            .Columns("ArdLordoRataOld").HeaderText = "Tot.ARD di Rata lordo Old"
            .Columns("ArdLordoRataNew").HeaderText = "Tot.ARD Di Rata lordo New"
            .Columns("TotDiffArd").HeaderText = "Diff.ARD di rata"
            .Columns("PercDiffArdRata").HeaderText = "Diff.ARD di rata %"
            .Columns("TipoVeicolo").HeaderText = "Tipo Veicolo"
            .Columns("TotRataLordoOld").HeaderText = "Tot.Rata Lordo Old"
            .Columns("TotRataLordoNew").HeaderText = "Tot.Rata Lordo New"
            .Columns("RcaLordoRataNew100").HeaderText = "RCA Lordo New senza sconto"
            .Columns("PercScontoConvenzione").HeaderText = "Sconto Conv. %"
            .Columns("UniboxOld").HeaderText = "Unibox Old"
            .Columns("UniboxNew").HeaderText = "Unibox New"
            .Columns("PercDiffRcaRata").HeaderText = "Diff.RCA di rata %"
            .Columns("MaxOld").HeaderText = "Max Old"
            .Columns("MaxNew").HeaderText = "Max New"
            .Columns("ValoreIF").HeaderText = "Valore IF"
            .Columns("CodiceFiscale").HeaderText = "Codice Fiscale"
            .Columns("EdTariffaOld").HeaderText = "Ed.Tariffa Old"
            .Columns("EdTariffaNew").HeaderText = "Ed.Tariffa New"
            .Columns("IFLordoOld").HeaderText = "IF rata lordo Old"
            .Columns("IFLordoNew").HeaderText = "IF rata lordo New"
            .Columns("AltroARDLordoOld").HeaderText = "Altro ARD Lordo Old"
            .Columns("AltroARDLordoNew").HeaderText = "Altro ARD Lordo New"
            .Columns("QuintaliRim").HeaderText = "Quintali Rim."
            .Columns("PostiRim").HeaderText = "Posti Rim."
            .Columns("FlexOld").HeaderText = "Flex Old"
            .Columns("PercScontoPlaf").HeaderText = "Sconto Plaf.%"

            'colori colonne
            'rca forzata
            .Columns("RcaLordoForzata").DefaultCellStyle.BackColor = Color.NavajoWhite
            .Columns("PercFlexRca").DefaultCellStyle.BackColor = Color.NavajoWhite
            .Columns("ImportoFlexRca").DefaultCellStyle.BackColor = Color.NavajoWhite
            'if forzata
            .Columns("IFLordoForzata").DefaultCellStyle.BackColor = Color.PaleGoldenrod
            .Columns("PercFlexIF").DefaultCellStyle.BackColor = Color.PaleGoldenrod
            .Columns("ImportoFlexIF").DefaultCellStyle.BackColor = Color.PaleGoldenrod

            'di default allineamento al centro
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'allineamento adestra
            Dim ColCentra As String = "Contraente;CodiceFiscale;ProprietarioCF;Proprietario;" +
                                      "FormaTariffaNew;FormulaTariffaNew;OpzioneTariffaNew;" +
                                      "FormaTariffaOld;FormulaTariffaOld;OpzioneTariffaOld"

            For Each c As String In ColCentra.Split(";")
                .Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Next
            '------------------------------------------

            'per gli importi in euro, formattazione e allineamento a destra
            Dim ColEuro As String = "TotRataLordoOld;UniboxOld;TotRataLordoNew;UniboxNew;TotDiff;" +
                                    "RcaLordoForzata;ArdLordoRataOld;ArdLordoRataNew;TotDiffArd;ValoreIF;" +
                                    "TotDiffRc;RcaLordoRataOld;RcaLordoRataNew;ImportoFlexRca;IFLordoOld;" +
                                    "IFLordoNew;AltroARDLordoOld;AltroARDLordoNew;RcaLordoRataNew100;" +
                                    "IFLordoForzata;ImportoFlexIF;KASLordoOld;KASLordoNew"

            For Each c As String In ColEuro.Split(";")
                .Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(c).DefaultCellStyle.Format = "###,##0.00"
            Next
            '----------------------------------

            'colonne altra ard
            For k As Int16 = 98 To 146
                If .Columns(k).ValueType.Name <> "String" Then
                    .Columns(k).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(k).DefaultCellStyle.Format = "###,##0.00"
                End If
            Next
            '-------------------------------------

            'formattazione per le percentuali
            Dim ColPerc As String = "PercDiffTotRata;PercDiffRca;PercDiffArdRata;PercFlexRca;FlexOld;" +
                                    "PercScontoPlaf;PercScontoConvenzione;PercDiffRcaRata;PercFlexIF"

            For Each c As String In ColPerc.Split(";")
                .Columns(c).DefaultCellStyle.Format = "##0.00"
            Next
            '-------------------------------------

            .Columns("DiffClasse").DefaultCellStyle = csClasse
            .Columns("TotDiff").DefaultCellStyle = csTotali

            NascondiScopriColonne()

            .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
            .Columns("Annotazioni").AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            'blocca l'ordinamento (possibile solo da codice)
            For Each c As DataGridViewColumn In dgv1.Columns
                c.SortMode = DataGridViewColumnSortMode.Programmatic
            Next

            'blocca colonne a sinistra
            For k As Int16 = 0 To 8
                .Columns.Item(k).Frozen = chkBloccaColonne.Checked
            Next

            .ResumeLayout()
        End With

        GrigliaFormattata = True
    End Sub

    Private Sub btnEsci_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Private Sub linklabelpannello_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelPannello.LinkClicked
        SplitPannello.Panel2Collapsed = Not SplitPannello.Panel2Collapsed
        LinkLabelPannello.Text = IIf(SplitPannello.Panel2Collapsed, "<< Mostra pannello", "Nascondi pannello >>")
        AllineaLinkLabel()
        AggiornaDettaglio()
    End Sub

    Private Sub SplitPannello_SplitterMoved(sender As Object, e As System.Windows.Forms.SplitterEventArgs) Handles SplitPannello.SplitterMoved
        On Error Resume Next

        AllineaLinkLabel()
        RidimensionaColonneDettaglio()
    End Sub

    Private Sub RidimensionaColonneDettaglio()
        On Error Resume Next

        If dgv1.RowCount = 0 Then Exit Sub

        With lvDettaglio
            .SuspendLayout()
            .Columns("campo").Width = .Width / 2 - 3
            .Columns("valore").Width = .Width / 2 - 3
            .ResumeLayout()
        End With
    End Sub

    Private Sub btnFiltro_Click(sender As System.Object, e As System.EventArgs)
        On Error Resume Next

        txtCerca.Text = dgv1.SelectedRows(0).Cells(dgv1.Columns("Contraente").Index).Value

        If txtCerca.Text.Trim <> String.Empty Then
            Dim eArgs As New System.EventArgs
            btnVisualizzaQT_Click(Me, eArgs)
            txtCerca.Text = ""
        End If

    End Sub

    Private Sub AllineaLinkLabel()
        On Error Resume Next
        LinkLabelPannello.Location = New Point(TabQuietanze.Left + TabQuietanze.Width - LinkLabelPannello.Width,
                                               SplitMain.Top)
        LinkLabelDettaglio.Location = New Point(LinkLabelPannello.Left - LinkLabelDettaglio.Width - 10,
                                                LinkLabelPannello.Top)
    End Sub

    Private Sub LinkLabelDettaglio_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelDettaglio.LinkClicked
        SplitMain.Panel2Collapsed = Not SplitMain.Panel2Collapsed
        LinkLabelDettaglio.Text = IIf(SplitMain.Panel2Collapsed, "Mostra dettaglio premi", "Nascondi dettaglio premi")
        AllineaLinkLabel()
    End Sub

    Private Sub InizializzaBinding()
        'tipo in alto a sinistra
        With lbConvenzione
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "Convenzione")
        End With
        'quietanza old
        With txtRcaOld
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "RcaLordoRataOld", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtIFOld
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "IFLordoOld", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtKaskoOld
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "KASLordoOld", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtArdOld
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "AltroARDLordoOld", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtUniboxOld
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "UniboxOld", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtFlexOld
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "FlexOld", True,
                              DataSourceUpdateMode.Never, "", "##0.00")
        End With
        With txtBonus
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "BonusFedelta", True,
                              DataSourceUpdateMode.Never, "", "Bonus ##0")
        End With
        'quietanza new
        With txtRca
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "RcaLordoRataNew", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtIF
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "IFLordoNew", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtKasko
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "KASLordoNew", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtArd
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "AltroARDLordoNew", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtUnibox
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "UniboxNew", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        'modifica qt
        With txtRca2
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "RcaLordoForzata", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtIF2
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "IFLordoForzata", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtKasko2
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "KaskoLordoForzata", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtArd2
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "AltroARDLordoNew", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtUnibox2
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "UniboxNew", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtFlexRcaPerc
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "PercFlexRca", True,
                              DataSourceUpdateMode.Never, "", "##0.00")
        End With
        With txtFlexRcaImporto
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "ImportoFlexRca", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtFlexIFPerc
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "PercFlexIF", True,
                              DataSourceUpdateMode.Never, "", "##0.00")
        End With
        With txtFlexIFImporto
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "ImportoFlexIF", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtFlexKaskoPerc
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "PercFlexKasko", True,
                              DataSourceUpdateMode.Never, "", "##0.00")
        End With
        With txtFlexKaskoImporto
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "ImportoFlexKasko", True,
                              DataSourceUpdateMode.Never, "", "##,##0.00")
        End With
        With txtFraz
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "FrazNew", True,
                              DataSourceUpdateMode.Never, "", "#")
        End With
        With txtFSP
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "FspNew", True,
                              DataSourceUpdateMode.Never, "", "!")
        End With
        With lbTipoVeicolo
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "TipoVeicolo", True,
                              DataSourceUpdateMode.Never, "", "!")
        End With
        'note
        With txtNote
            .DataBindings.Clear()
            .DataBindings.Add("Text", bs, "Annotazioni", False, DataSourceUpdateMode.Never)
        End With
    End Sub

    Private Sub btnSalva_Click(sender As System.Object, e As System.EventArgs) Handles btnSalva.Click
        If dt.Rows.Count = 0 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        CalcolaFlex()

        Try
            'scrive il valore nell'origine dati e fa l'update nel db
            'rca
            txtRca2.DataBindings("Text").WriteValue()
            txtFlexRcaPerc.DataBindings("Text").WriteValue()
            txtFlexRcaImporto.DataBindings("Text").WriteValue()
            'if
            txtIF2.DataBindings("Text").WriteValue()
            txtFlexIFPerc.DataBindings("Text").WriteValue()
            txtFlexIFImporto.DataBindings("Text").WriteValue()
            'kasko
            txtKasko2.DataBindings("Text").WriteValue()
            txtFlexKaskoPerc.DataBindings("Text").WriteValue()
            txtFlexKaskoImporto.DataBindings("Text").WriteValue()
            'note
            txtNote.DataBindings("Text").WriteValue()
            'forza il flag flex
            If dgv1.CurrentRow.Cells("Fatto").Value = True OrElse
               dgv1.CurrentRow.Cells("Sostituita").Value = True Then
                'già incassata o sostituita ma la faccio modificare
                'ma non cambio i flag
            Else
                dgv1.CurrentRow.Cells("Flex").Value = True
                dgv1.CurrentRow.Cells("Fatto").Value = False
                dgv1.CurrentRow.Cells("Disdetta").Value = False
            End If

            'assegno il comando di update al da
            da.UpdateCommand = cmdUpdate(dgv1.CurrentRow.Cells("Polizza").Value,
                                         dgv1.CurrentRow.Cells("Effetto").Value.ToString)

            bs.EndEdit()
            da.Update(dt)
        Catch ex As Exception
            Log.Errore(ex)
        End Try

        AggiornaDettaglio()
        TotaleFlex()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AggiornaFlag()
        Try
            Cursor.Current = Cursors.WaitCursor

            cn.ConnectionString = Utx.Globale.CnDbLink
            cn.Open()

            Using cmd As New OleDbCommand
                'aggiornamento aliquote rca-------------------------------------------------------------------
                With cmd
                    .Connection = cn
                    .CommandType = CommandType.Text

                    'aggiorno dalla tabella province
                    Log.Info("Aggiornamento aliquote rca")
                    .CommandText = "UPDATE (((MonitorQT AS M " +
                                             "INNER JOIN Clienti AS C ON C.CodiceFiscale = M.ProprietarioCF) " +
                                             "INNER JOIN Province AS PR ON C.Provincia = PR.Sigla) " +
                                             "INNER JOIN Polizze AS PO ON M.Polizza = PO.Polizza) " +
                                   "SET M.AliquotaRca = PR.AliquotaRca " +
                                   "WHERE (M.Effetto >= PR.EffettoAliquotaRca) AND (PO.ClasseRca NOT IN ('30','92'))"
                    Log.Info(String.Format("aliquote aggiornate: {0}", .ExecuteNonQuery))

                    'metto al 12.5 quello che non è stato impostato (trovato)
                    .CommandText = "UPDATE MonitorQT SET AliquotaRca = 12.5 WHERE AliquotaRca IS NULL"
                    .ExecuteNonQuery()

                    'aggiornamento flag
                    'aggiorna incassate
                    Log.Info("Aggiornamento flag incassate")
                    .CommandText = "UPDATE MonitorQt AS M " +
                                   "INNER JOIN Incassi AS I ON (I.Polizza = M.Polizza) AND (I.DataEffettoTitolo = M.Effetto) " +
                                   "SET Fatto = True, Flex = False, Disdetta = False " +
                                   "WHERE (M.Fatto = False) AND (I.Ramo = 30)"
                    Log.Info(String.Format("Flag aggiornati: {0}", .ExecuteNonQuery))

                    'aggiorna sostituite (negli ultimi 60 gg). se incassata non può essere stata sostituita
                    Log.Info("Aggiornamento flag sostituite")
                    .CommandText = "UPDATE MonitorQt AS M " +
                                   "INNER JOIN PolizzeSostituite AS P ON P.Polizza = M.Polizza AND P.ScadenzaPolizza = M.Effetto " +
                                   "SET Fatto = False, Flex = False, Disdetta = False, Sostituita = True " +
                                   "WHERE (Fatto = False) AND (P.Ramo = 30) AND (P.TipoVar = 'SS') AND (M.Effetto - P.DataVar <= 60)"
                    Log.Info(String.Format("Flag aggiornati: {0}", .ExecuteNonQuery))

                    'aggiorna variate. se sostituita non può essere stata variata
                    Log.Info("Aggiornamento flag variate")
                    .CommandText = "UPDATE MonitorQt AS M " +
                                   "INNER JOIN PolizzeSostituite AS P ON P.Polizza = M.Polizza AND P.ScadenzaPolizza = M.Effetto " +
                                   "SET Variata = True " +
                                   "WHERE (Sostituita = False) AND (P.Ramo = 30) AND (P.TipoVar = 'VR') AND (M.Effetto - P.DataVar <= 60)"
                    Log.Info(String.Format("Flag variate: {0}", .ExecuteNonQuery))

                    'aggiorna disdette/stornate per automatismi (dopo 2 mesi)
                    Dim DataStorno As Date = DataFineMese(DateAdd(DateInterval.Month, -2, Today))

                    Log.Info("Aggiornamento flag disdette")
                    .CommandText = "UPDATE MonitorQt " +
                                   "SET Flex = False, Disdetta = True " +
                                   "WHERE (Effetto <= ?) AND (Fatto = False) AND (Sostituita = False)"
                    .Parameters.AddWithValue("data", DataStorno)
                    Log.Info(String.Format("Flag disdette/stornate: {0}", .ExecuteNonQuery))
                End With
            End Using

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            cn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Function Sql() As String

        ImpostaWhere()

        Dim CoeffFraz As String = "IIf(FrazNew = 1, 1, " +
                                  "IIf(FrazNew = 2, 0.515, " +
                                  "IIf(FrazNew = 3, 0.3466, 0.2625)))"

        Sql = "SELECT Flex,Fatto,Variata,Sostituita,Disdetta," +
                     "Polizza," +
                     "FrazNew," +
                     "Sub," +
                     "Produttore," +
                     "Effetto," +
                     "Contraente," +
                     "((TotRataLordoNew + UniboxNew) - (TotRataLordoOld + UniboxOld)) as TotDiff," +
                     "PercDiffTotRata," +
                     "Iif(UniboxNew > 0,'S','N') as UBox," +
                     "MeritoOld," +
                     "FspOld," +
                     "MeritoNew," +
                     "FspNew," +
                     "(MeritoNew - MeritoOld) as DiffClasse," +
                     "Convenzione," +
                     "RcaLordoRataOld," +
                     "RcaLordoRataNew," +
                     "(RcaLordoRataNew - RcaLordoRataOld) as TotDiffRc," +
                     "((RcaLordoRataNew / RcaLordoRataOld - 1) * 100) as PercDiffRca," +
                     "RcaLordoForzata," +
                     "PercFlexRca," +
                     "ImportoFlexRca," +
                     "IFLordoForzata," +
                     "PercFlexIF," +
                     "ImportoFlexIF," +
                     "KaskoLordoForzata," +
                     "PercFlexKasko," +
                     "ImportoFlexKasko," +
                     "ArdLordoRataOld," +
                     "ArdLordoRataNew," +
                     "(ArdLordoRataNew - ArdLordoRataOld) as TotDiffArd," +
                     "PercDiffArdRata," +
                     "(INCNettoOld + FURNettoOld) * 1.135 * " + CoeffFraz + " as IFLordoOld," +
                     "(INCNettoNew + FURNettoNew) * 1.135 * " + CoeffFraz + " as IFLordoNew," +
                     "(KASNettoOld + COLNettoOld)  * 1.135 * " + CoeffFraz + " as KASLordoOld," +
                     "(KASNettoNew + COLNettoNew)  * 1.135 * " + CoeffFraz + " as KASLordoNew," +
                     "(ArdLordoRataOld - (INCNettoOld + FURNettoOld) * 1.135 * " + CoeffFraz + " - KASLordoOld) as AltroARDLordoOld," +
                     "(ArdLordoRataNew - (INCNettoNew + FURNettoNew) * 1.135 * " + CoeffFraz + " - KASLordoNew) as AltroARDLordoNew," +
                     "Targa," +
                     "TipoVeicolo," +
                     "Hp, Cc, Quintali, QuintaliRim, Posti, PostiRim, Tsl," +
                     "EdTariffaOld, EdTariffaNew," +
                     "* " +
              "FROM MonitorQT " +
              "WHERE " + WhereContraente + " And " +
                         WhereDate + " And " +
                         WhereSub + " And " +
                         WhereProduttore + " And " +
                         WhereFiltro + " And " +
                         WhereSaturazione +
              "ORDER BY (TotRataLordoNew + UniboxNew - TotRataLordoOld - UniboxOld) DESC"

    End Function

    Private Sub ImpostaWhere()
        Try
            txtCerca.Text = txtCerca.Text.Trim()
            txtSub.Text = txtSub.Text.Trim()
            txtProduttore.Text = txtProduttore.Text.Trim()

            WhereContraente = " (Contraente Like '" + txtCerca.Text + "%') "
            WhereDate = " (Effetto BETWEEN " + DataUSA(dtpInizio.Value) + " AND " +
                                               DataUSA(dtpFine.Value) + ") "
            WhereSub = " (True) "
            If txtSub.Text <> String.Empty Then WhereSub = " (Sub = " + txtSub.Text + ") "

            WhereProduttore = " (True) "
            If txtProduttore.Text <> String.Empty Then _
                WhereProduttore = " (Produttore = " + txtProduttore.Text + ") "

            WhereFiltro = " (True) "
            Select Case Val(cboFiltro.Text)
                Case 1
                    'non fare niente: tutte le quietanze senza filtro
                Case 2
                    Try
                        WhereContraente = " (Contraente Like '" +
                                          dgv1.SelectedRows(0).Cells(dgv1.Columns("Contraente").Index).Value +
                                          "') "
                    Catch ex As Exception
                        'niente
                    End Try
                    cboFiltro.SelectedIndex = 0
                Case 3
                    WhereFiltro = " (InMalus = 'S') "
                Case 4
                    WhereFiltro = " (UniboxNew > 0) "
                Case 5
                    WhereFiltro = " (Flex = True) "
                Case 6 'incassate
                    WhereFiltro = " (Fatto = True) "
                Case 7 'non incassate
                    WhereFiltro = " (Fatto = False AND Disdetta = False AND Sostituita = False) "
                Case 8
                    WhereFiltro = " (Variata = True) "
                Case 9
                    WhereFiltro = " (Sostituita = True) "
                Case 10
                    WhereFiltro = " (Disdetta = True) "
                Case 11
                    WhereFiltro = " (Flex = False AND Fatto = False AND Disdetta = False AND " +
                                  "Sostituita = False AND Variata = False) "
                Case 12
                    WhereFiltro = " (AGOld <> AGNew) "
                Case 13
                    WhereFiltro = " (MaxOld <> MaxNew) "
                Case 14
                    WhereFiltro = " (Convenzione > 0) "
            End Select

            'saturazione
            WhereSaturazione = " (True) "
            Select Case cboSaturazione.SelectedIndex
                Case 1
                    WhereSaturazione = " (SatRca <> 'S' AND SatCVT <> 'S') "
                Case 2
                    WhereSaturazione = " (SatRca = 'S' Or SatCVT = 'S') "
                Case 3
                    WhereSaturazione = " (SatRca = 'S') "
                Case 4
                    WhereSaturazione = " (SatCVT = 'S') "
                Case 5
                    WhereSaturazione = " (SaturazioneMax = 'S') "
                Case 6
                    WhereSaturazione = " (GASaturazione = 'S') "
                Case 7
                    WhereSaturazione = " (TUTSaturazione = 'S') "
                Case 8
                    WhereSaturazione = " (ASSSaturazione = 'S') "
                Case 9
                    WhereSaturazione = " (UNISALSaturazione = 'S') "
                Case 10
                    WhereSaturazione = " (INFSaturazione = 'S') "
            End Select

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub NascondiScopriColonne()
        If dgv1.RowCount = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        dgv1.SuspendLayout()

        Dim Colonne() As String = {"FrazNew", "DiffClasse"}
        Try
            If chkNascondiColonne.Checked Then
                For Each c As String In Colonne
                    dgv1.Columns(c).Visible = False
                Next
                'nascondi le colonne da un certo indice in poi
                For Each c As DataGridViewColumn In dgv1.Columns
                    If c.Index > 48 Then c.Visible = False
                Next

                'l'ultima colonna sono le note e la scopro sempre
                dgv1.Columns(dgv1.Columns.Count - 1).Visible = True
            Else
                'scopri tutto
                For Each c As DataGridViewColumn In dgv1.Columns
                    c.Visible = True
                Next
            End If

        Catch ex As Exception
            'niente
        End Try

        dgv1.ResumeLayout()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub chkNascondiColonne_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkNascondiColonne.CheckedChanged
        NascondiScopriColonne()
    End Sub

    Private Sub TotaleQuietanze()
        Try
            'old
            txtSubTotaleRataOld.Text = FormIt(CDbl(txtRcaOld.Text) +
                                              CDbl(txtIFOld.Text) +
                                              CDbl(txtKaskoOld.Text) +
                                              CDbl(txtArdOld.Text))
            txtTotaleRataOld.Text = FormIt(CDbl(txtSubTotaleRataOld.Text) +
                                           CDbl(txtUniboxOld.Text))
            'new
            txtSubTotaleRata.Text = FormIt(CDbl(txtRca.Text) +
                                           CDbl(txtIF.Text) +
                                           CDbl(txtKasko.Text) +
                                           CDbl(txtArd.Text))
            txtTotaleRata.Text = FormIt(CDbl(txtSubTotaleRata.Text) +
                                        CDbl(txtUnibox.Text))
        Catch ex As Exception
            'niente
        End Try
    End Sub

    Private Sub TotaleModifica()
        Try
            'modifica
            txtSubTotaleRata2.Text = FormIt(CDbl(txtRca2.Text) +
                                            CDbl(txtIF2.Text) +
                                            CDbl(txtKasko2.Text) +
                                            CDbl(txtArd2.Text))
            txtTotaleRata2.Text = FormIt(CDbl(txtSubTotaleRata2.Text) +
                                         CDbl(txtUnibox2.Text))
        Catch ex As Exception
            'niente
        End Try
    End Sub

    Private Sub btnCalcola_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcola.Click
        CalcolaFlex()
    End Sub

    Private Sub txtRca2_Validated(sender As Object, e As System.EventArgs) Handles txtRca2.Validated
        Try
            txtRca2.Text = txtRca2.Text.Replace(".", ",")

            If txtRca.Text = String.Empty Then txtRca.Text = 0
            If txtRca2.Text = String.Empty Then txtRca2.Text = 0

            If CDbl(txtRca2.Text) < 0 Then txtRca2.Text = 0
            If CDbl(txtRca2.Text) > CDbl(txtRca.Text) Then txtRca2.Text = txtRca.Text

            txtRca2.Text = FormIt(CDbl(txtRca2.Text))
        Catch ex As Exception
            'niente
        End Try
    End Sub

    Private Function cmdUpdate(Polizza As Long, Effetto As String) As OleDbCommand
        cmdUpdate = New OleDbCommand
        With cmdUpdate
            .CommandText = "UPDATE MonitorQT " +
                           "SET RcaLordoForzata = ?," +
                               "ImportoFlexRca = ?," +
                               "PercFlexRca = ?," +
                               "IFLordoForzata = ?," +
                               "ImportoFlexIF = ?," +
                               "PercFlexIF = ?," +
                               "KaskoLordoForzata = ?," +
                               "ImportoFlexKasko = ?," +
                               "PercFlexKasko = ?," +
                               "Annotazioni = ?," +
                               "Flex = ? " +
                           "WHERE Polizza = " + Polizza.ToString + " And " +
                                 "Effetto = " + DataUSA(Effetto)
            .Connection = cn
        End With
        'imposto i parametri rca
        With cmdUpdate.Parameters.Add("@p1", OleDbType.Double)
            .SourceColumn = "RcaLordoForzata"
            .SourceVersion = DataRowVersion.Current
        End With
        With cmdUpdate.Parameters.Add("@p2", OleDbType.Double)
            .SourceColumn = "ImportoFlexRca"
            .SourceVersion = DataRowVersion.Current
        End With
        With cmdUpdate.Parameters.Add("@p3", OleDbType.Single)
            .SourceColumn = "PercFlexRca"
            .SourceVersion = DataRowVersion.Current
        End With
        'if
        With cmdUpdate.Parameters.Add("@p4", OleDbType.Double)
            .SourceColumn = "IFLordoForzata"
            .SourceVersion = DataRowVersion.Current
        End With
        With cmdUpdate.Parameters.Add("@p5", OleDbType.Double)
            .SourceColumn = "ImportoFlexIF"
            .SourceVersion = DataRowVersion.Current
        End With
        With cmdUpdate.Parameters.Add("@p6", OleDbType.Single)
            .SourceColumn = "PercFlexIF"
            .SourceVersion = DataRowVersion.Current
        End With
        'kasko
        With cmdUpdate.Parameters.Add("@p7", OleDbType.Double)
            .SourceColumn = "KaskoLordoForzata"
            .SourceVersion = DataRowVersion.Current
        End With
        With cmdUpdate.Parameters.Add("@p8", OleDbType.Double)
            .SourceColumn = "ImportoFlexKasko"
            .SourceVersion = DataRowVersion.Current
        End With
        With cmdUpdate.Parameters.Add("@p9", OleDbType.Single)
            .SourceColumn = "PercFlexKasko"
            .SourceVersion = DataRowVersion.Current
        End With
        'note
        With cmdUpdate.Parameters.Add("@p10", OleDbType.LongVarChar)
            .SourceColumn = "Annotazioni"
            .SourceVersion = DataRowVersion.Current
        End With
        'flex
        With cmdUpdate.Parameters.Add("@p11", OleDbType.Double)
            .SourceColumn = "Flex"
            .SourceVersion = DataRowVersion.Current
        End With
    End Function

    Private Function cmdUpdateCheck(Polizza As Long, Effetto As String) As OleDbCommand
        cmdUpdateCheck = New OleDbCommand
        With cmdUpdateCheck
            .CommandText = String.Format("UPDATE MonitorQT " +
                                         "SET Flex = ?, Fatto = ?, Disdetta = ? " +
                                         "WHERE Polizza = {0} AND Effetto = {1}", Polizza, DataUSA(Effetto))
            .Connection = cn
        End With
        'imposto i parametri
        With cmdUpdateCheck.Parameters.Add("@p1", OleDbType.Double)
            .SourceColumn = "Flex"
            .SourceVersion = DataRowVersion.Current
        End With
        With cmdUpdateCheck.Parameters.Add("@p2", OleDbType.Double)
            .SourceColumn = "Fatto"
            .SourceVersion = DataRowVersion.Current
        End With
        With cmdUpdateCheck.Parameters.Add("@p3", OleDbType.Double)
            .SourceColumn = "Disdetta"
            .SourceVersion = DataRowVersion.Current
        End With
    End Function

    Private Sub CalcolaFlex()
        If dt.Rows.Count = 0 Then Exit Sub

        Try
            If txtRca2.Text = String.Empty Then txtRca2.Text = Zero()
            If txtIF2.Text = String.Empty Then txtIF2.Text = Zero()
            If txtKasko2.Text = String.Empty Then txtKasko2.Text = Zero()
            If txtSubTotaleRata2.Text = String.Empty Then txtSubTotaleRata2.Text = Zero()

            If txtRca2.Text = 0 Then txtRca2.Text = txtRca.Text
            If txtIF2.Text = 0 Then txtIF2.Text = txtIF.Text
            If txtKasko2.Text = 0 Then txtKasko2.Text = txtKasko.Text
            If txtSubTotaleRata2.Text = 0 Then txtSubTotaleRata2.Text = txtSubTotaleRata.Text

            Dim Fraz As Int16 = dgv1.CurrentRow.Cells("FrazNew").Value
            Dim CoeffFraz As Double = CoefficienteFraz(Fraz)
            'calcolo aliquota applicata
            Dim Tasse As Double = dgv1.CurrentRow.Cells("AliquotaRca").Value + AliquotaSSN
            Tasse = (Tasse / 100 + 1) * 100

            'Rca
            txtFlexRcaPerc.Text = Format(((1 - CDbl(txtRca2.Text) / CDbl(txtRca.Text)) * 100), "##0.00")
            txtFlexRcaImporto.Text = FormIt(CDbl(txtRca.Text) * CDbl(txtFlexRcaPerc.Text) / (Tasse * CoeffFraz))
            'IF
            If txtIF.Text > 0 Then
                txtFlexIFPerc.Text = Format(((1 - CDbl(txtIF2.Text) / CDbl(txtIF.Text)) * 100), "##0.00")
                txtFlexIFImporto.Text = FormIt(CDbl(txtIF.Text) * CDbl(txtFlexIFPerc.Text) / (113.5 * CoeffFraz))
            Else
                txtFlexIFPerc.Text = Zero()
                txtIF2.Text = Zero()
            End If
            'kasko
            If txtKasko.Text > 0 Then
                txtFlexKaskoPerc.Text = Format(((1 - CDbl(txtKasko2.Text) / CDbl(txtKasko.Text)) * 100), "##0.00")
                txtFlexKaskoImporto.Text = FormIt(CDbl(txtKasko.Text) * CDbl(txtFlexKaskoPerc.Text) / (113.5 * CoeffFraz))
            Else
                txtFlexKaskoPerc.Text = Zero()
                txtKasko2.Text = Zero()
            End If

            'Totali
            TotaleModifica()

        Catch ex As Exception
            'niente
        End Try
    End Sub

    Private Sub CalcolaImportoFlex()
        If dt.Rows.Count = 0 Then Exit Sub

        Try
            If txtRca2.Text = String.Empty Then txtRca2.Text = 0
            If txtIF2.Text = String.Empty Then txtIF2.Text = 0
            If txtKasko2.Text = String.Empty Then txtKasko2.Text = 0
            If txtSubTotaleRata2.Text = String.Empty Then txtSubTotaleRata2.Text = 0

            If txtRca2.Text = 0 Then txtRca2.Text = txtRca.Text
            If txtIF2.Text = 0 Then txtIF2.Text = txtIF.Text
            If txtKasko2.Text = 0 Then txtKasko2.Text = txtKasko.Text
            If txtSubTotaleRata2.Text = 0 Then txtSubTotaleRata2.Text = txtSubTotaleRata.Text

            Dim Fraz As Int16 = dgv1.CurrentRow.Cells("FrazNew").Value
            Dim CoeffFraz As Double = CoefficienteFraz(Fraz)
            'calcolo aliquota applicata
            'calcolo aliquota applicata
            Dim Tasse As Double = dgv1.CurrentRow.Cells("AliquotaRca").Value + AliquotaSSN
            Tasse = (Tasse / 100 + 1) * 100

            'Rca
            txtFlexRcaPerc.Text = Format(CDbl(txtFlexRcaPerc.Text), "##0.00")
            txtRca2.Text = FormIt(CDbl(txtRca.Text) * (1 - CDbl(txtFlexRcaPerc.Text) / 100))
            txtFlexRcaImporto.Text = FormIt(CDbl(txtRca.Text) * CDbl(txtFlexRcaPerc.Text) / (Tasse * CoeffFraz))
            'IF
            If txtIF.Text > 0 Then
                txtFlexIFPerc.Text = Format(CDbl(txtFlexIFPerc.Text), "##0.00")
                txtIF2.Text = FormIt(CDbl(txtIF.Text) * (1 - CDbl(txtFlexIFPerc.Text) / 100))
                txtFlexIFImporto.Text = FormIt(CDbl(txtIF.Text) * CDbl(txtFlexIFPerc.Text) / (113.5 * CoeffFraz))
            Else
                txtFlexIFPerc.Text = Zero()
                txtIF2.Text = Zero()
            End If
            'kasko
            If txtKasko.Text > 0 Then
                txtFlexKaskoPerc.Text = Format(CDbl(txtFlexKaskoPerc.Text), "##0.00")
                txtKasko2.Text = FormIt(CDbl(txtKasko.Text) * (1 - CDbl(txtFlexKaskoPerc.Text) / 100))
                txtFlexKaskoImporto.Text = FormIt(CDbl(txtKasko.Text) * CDbl(txtFlexKaskoPerc.Text) / (113.5 * CoeffFraz))
            Else
                txtFlexKaskoPerc.Text = Zero()
                txtKasko2.Text = Zero()
            End If

            'Totali
            TotaleModifica()

        Catch ex As Exception
            'niente
        End Try
    End Sub

    Private Sub TotaleFlex()
        Try
            LabelPeriodo()

            Dim WhereData As String = " Effetto Between " + DataUSA(dtpInizio.Value.ToString) + " And " +
                                                            DataUSA(dtpFine.Value.ToString)
            Dim WhereSub As String = " True "
            If txtSub.Text.Trim.Length > 0 Then WhereSub = " Sub = " + txtSub.Text.Trim

            Dim WhereProd As String = " True "
            If txtProduttore.Text.Trim.Length > 0 Then WhereProd = " Produttore = " + txtProduttore.Text.Trim

            cn.Open()

            cmdTotali.Connection = cn
            cmdTotali.CommandType = CommandType.Text

            'flex impegnata con campo Flex fleggato
            Try
                cmdTotali.CommandText = "SELECT Sum(ImportoFlexRca * FrazNew) " +
                                        "FROM MonitorQT " +
                                        "WHERE Flex = -1 And " +
                                        WhereData + " And " +
                                        WhereSub + " And " +
                                        WhereProd
                txtFlexImpRca.Text = FormIt(cmdTotali.ExecuteScalar())
            Catch ex As Exception
                txtFlexImpRca.Text = Zero()
            End Try
            Try
                cmdTotali.CommandText = "SELECT Sum((ImportoFlexIF + ImportoFlexKasko) * FrazNew) " +
                                        "FROM MonitorQT " +
                                        "WHERE Flex = -1 And " +
                                        WhereData + " And " +
                                        WhereSub + " And " +
                                        WhereProd
                txtFlexImpIF.Text = FormIt(cmdTotali.ExecuteScalar())
            Catch ex As Exception
                txtFlexImpIF.Text = Zero()
            End Try

            'flex utilizzata con campo Fatto fleggato
            Try
                cmdTotali.CommandText = "SELECT Sum(ImportoFlexRca * FrazNew) " +
                                        "FROM MonitorQT " +
                                        "WHERE Fatto = -1 And " +
                                        WhereData + " And " +
                                        WhereSub + " And " +
                                        WhereProd
                txtFlexUtiRca.Text = FormIt(cmdTotali.ExecuteScalar())
            Catch ex As Exception
                txtFlexUtiRca.Text = Zero()
            End Try
            Try
                cmdTotali.CommandText = "SELECT Sum((ImportoFlexIF + ImportoFlexKasko) * FrazNew) " +
                                        "FROM MonitorQT " +
                                        "WHERE Fatto = -1 And " +
                                        WhereData + " And " +
                                        WhereSub + " And " +
                                        WhereProd
                txtFlexUtiIF.Text = FormIt(cmdTotali.ExecuteScalar())
            Catch ex As Exception
                txtFlexUtiIF.Text = Zero()
            End Try

            'totali
            txtFlexRcaTotale.Text = FormIt(CDbl(txtFlexImpRca.Text) + CDbl(txtFlexUtiRca.Text))
            txtFlexIFTotale.Text = FormIt(CDbl(txtFlexImpIF.Text) + CDbl(txtFlexUtiIF.Text))

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub LabelPeriodo()
        lbPeriodo.Text = "Periodo " + Format(dtpInizio.Value, "dd/MM") +
                         " - " + Format(dtpFine.Value, "dd/MM") +
                         " (" + txtSub.Text + "-" + txtProduttore.Text + ")"
    End Sub

    Private Sub ResetControlli()
        dgv1.DataSource = Nothing
        LabelPeriodo()
        ImpostaTab(0)
    End Sub

    Private Function EsisteTabellaQt(NomeTabella As String) As Boolean
        cn.ConnectionString = Utx.Globale.CnDbLink
        cn.Open()

        Dim cmd As New OleDbCommand

        Try
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT count(*) FROM " + NomeTabella
            cmd.ExecuteScalar()

            Return True
        Catch ex As Exception
            Return False
        Finally
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Private Sub chkBloccaColonne_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBloccaColonne.CheckedChanged
        On Error Resume Next

        If dgv1.RowCount = 0 Then Exit Sub

        For k As Int16 = 0 To 8
            dgv1.Columns.Item(k).Frozen = chkBloccaColonne.Checked
        Next
    End Sub

    Private Sub AutoSizeColonne()
        If dgv1.RowCount = 0 Then Exit Sub

        Try
            dgv1.SuspendLayout()

            'auto size delle colonne
            For Each col As DataGridViewColumn In dgv1.Columns
                If chkAutoSize.Checked Then
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Else
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                End If
            Next

            dgv1.ResumeLayout()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkAutoSize_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAutoSize.CheckedChanged
        AutoSizeColonne()
    End Sub

    Private Sub ResetTxtTotali()
        txtTotaleRataOld.Text = 0
        txtTotaleRata.Text = 0
        txtTotaleRata2.Text = 0
    End Sub

    Private Sub txtIF2_Validated(sender As Object, e As System.EventArgs) Handles txtIF2.Validated
        Try
            txtIF2.Text = txtIF2.Text.Replace(".", ",")

            If txtIF.Text = String.Empty Then txtIF.Text = 0
            If txtIF2.Text = String.Empty Then txtIF2.Text = 0

            If CDbl(txtIF2.Text) < 0 Then txtIF2.Text = 0
            If CDbl(txtIF2.Text) > CDbl(txtIF.Text) Then txtIF2.Text = txtIF.Text

            txtIF2.Text = FormIt(CDbl(txtIF2.Text))
        Catch ex As Exception
            'niente
        End Try
    End Sub

    Private Sub Statistiche_Enter(sender As Object, e As System.EventArgs) Handles Statistiche.Enter
        ChiudiDettaglioPremi()
        dgvStat.AutoResizeColumns()
        txtCerca.Enabled = False
        cboFiltro.SelectedIndex = 0
        cboFiltro.Enabled = False
        LinkLabelDettaglio.Enabled = False
        LinkLabelPannello.Enabled = False
    End Sub

    Private Sub btnHelp_Click(sender As System.Object, e As System.EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Path.Combine(Utx.Globale.Paths.CartellaApp, "Unitools.chm"), "monitoraggio_quietanzamento_rca.htm")
    End Sub

    Private Sub Elenco_Enter(sender As Object, e As System.EventArgs) Handles Elenco.Enter
        txtCerca.Enabled = True
        cboFiltro.Enabled = True
        LinkLabelDettaglio.Enabled = True
        LinkLabelPannello.Enabled = True
        ApriDettaglioPremi()
    End Sub

    Private Sub ChiudiDettaglioPremi()
        SplitMain.Panel2Collapsed = True
        LinkLabelDettaglio.Text = "Mostra dettaglio premi"
        AllineaLinkLabel()
    End Sub

    Private Sub ApriDettaglioPremi()
        SplitMain.Panel2Collapsed = False
        LinkLabelDettaglio.Text = "Nascondi dettaglio premi"
        AllineaLinkLabel()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        CalcolaImportoFlex()
    End Sub

    Private Sub DefaultImportoDesiderato()
        If txtRca2.Text = String.Empty OrElse txtRca2.Text = 0 Then txtRca2.Text = txtRca.Text
        If txtArd2.Text = String.Empty OrElse txtArd2.Text = 0 Then txtArd2.Text = txtArd.Text
    End Sub

    Private Sub CalcolaStatistiche()
        Cursor.Current = Cursors.WaitCursor

        Dim MdbVuoto As String = ""
        Dim MdbStat As String = ""
        Dim cmd As New OleDbCommand
        Try
            cboFiltro.SelectedIndex = 0

            ImpostaWhere()

            'crea l'mdb temporaneo in locale per l'analisi
            MdbVuoto = Path.Combine(Utx.Globale.Paths.CartellaModelli, "Vuoto.mdb")
            MdbStat = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Stat.mdb")

            If File.Exists(MdbStat) Then File.Delete(MdbStat)
            File.Copy(MdbVuoto, MdbStat)

            cn.ConnectionString = Utx.Globale.MDBDriver + MdbStat
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text

            'porto in locale la tabella monitor e quella incassi con i limiti imposti
            cmd.CommandText = "SELECT * " +
                              "INTO MonitorQT " +
                              "FROM MonitorQT In '" + Utx.Globale.Paths.DbLink + "' " +
                              "WHERE " + WhereDate + " AND " +
                                         WhereSub + " AND " +
                                         WhereProduttore
            cmd.ExecuteNonQuery()

            cmd.CommandText = "SELECT * " + _
                              "INTO Incassi " + _
                              "FROM Incassi In '" + Utx.Globale.Paths.DbLink + "' " + _
                              "WHERE DataEffettoTitolo BETWEEN " + DataUSA(dtpInizio.Value) + " AND " + _
                                                                   DataUSA(dtpFine.Value)
            cmd.ExecuteNonQuery()
            '----------------------------------

            CalcolaStatisticheIncassato(cmd)
            CalcolaStatisticheDisdette(cmd)

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            cn.Close()
            cn.Dispose()
            cmd.Dispose()
        End Try

        dgvStat.AutoResizeColumns()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CalcolaStatisticheIncassato(ByRef cmd As OleDbCommand)
        Try
            With dgvStat
                cmd.Connection = cn
                cmd.CommandType = CommandType.Text

                'incassi previsti
                Try
                    cmd.CommandText = CommandStat(Query.QTPreviste)
                    .Rows(0).Cells("QtNr").Value = cmd.ExecuteScalar
                    .Rows(0).Cells("QtPerc").Value = 1
                    .Rows(12).Cells("QtNr").Value = .Rows(0).Cells("QtNr").Value
                Catch ex As Exception
                    .Rows(0).Cells("QtNr").Value = 0
                    .Rows(0).Cells("QtPerc").Value = 0
                    .Rows(12).Cells("QtNr").Value = 0
                End Try
                Try
                    cmd.CommandText = CommandStat(Query.IncassiPrevisti)
                    .Rows(0).Cells("Importi").Value = cmd.ExecuteScalar
                Catch ex As Exception
                    .Rows(0).Cells("Importi").Value = 0
                End Try

                If .Rows(0).Cells("QtNr").Value = 0 Then
                    .Rows(1).Cells("QtNr").Value = 0
                    .Rows(2).Cells("QtNr").Value = 0
                    .Rows(3).Cells("QtNr").Value = 0
                    .Rows(1).Cells("QtPerc").Value = "-"
                    .Rows(2).Cells("QtPerc").Value = "-"
                    .Rows(3).Cells("QtPerc").Value = "-"
                    .Rows(1).Cells("Importi").Value = 0
                    .Rows(2).Cells("Importi").Value = 0
                    .Rows(3).Cells("Importi").Value = 0
                    .Rows(1).Cells("ImportiPerc").Value = "-"
                    .Rows(2).Cells("ImportiPerc").Value = "-"
                    .Rows(3).Cells("ImportiPerc").Value = "-"

                    Exit Try
                End If

                'quietanze incassate senza variazioni
                Try
                    cmd.CommandText = CommandStat(Query.QTNoVar)
                    .Rows(1).Cells("QtNr").Value = cmd.ExecuteScalar
                    .Rows(1).Cells("QtPerc").Value = .Rows(1).Cells("QtNr").Value / _
                                                         .Rows(0).Cells("QtNr").Value
                Catch ex As Exception
                    .Rows(1).Cells("QtNr").Value = 0
                    .Rows(1).Cells("QtPerc").Value = 0
                End Try
                Try
                    cmd.CommandText = CommandStat(Query.IncassiNoVar)
                    .Rows(1).Cells("Importi").Value = cmd.ExecuteScalar
                    .Rows(1).Cells("ImportiPerc").Value = .Rows(1).Cells("Importi").Value / _
                                                          .Rows(0).Cells("Importi").Value
                Catch ex As Exception
                    .Rows(1).Cells("Importi").Value = 0
                    .Rows(1).Cells("Importi").Value = 0
                End Try

                'quietanze incassate con variazioni
                Try
                    cmd.CommandText = CommandStat(Query.QTVar)
                    .Rows(2).Cells("QtNr").Value = cmd.ExecuteScalar
                    .Rows(2).Cells("QtPerc").Value = .Rows(2).Cells("QtNr").Value / _
                                                     .Rows(0).Cells("QtNr").Value
                Catch ex As Exception
                    .Rows(2).Cells("QtNr").Value = 0
                    .Rows(2).Cells("QtPerc").Value = 0
                End Try

                Try
                    cmd.CommandText = CommandStat(Query.IncassiVar)
                    .Rows(2).Cells("Importi").Value = cmd.ExecuteScalar
                    .Rows(2).Cells("ImportiPerc").Value = .Rows(2).Cells("Importi").Value / _
                                                          .Rows(0).Cells("Importi").Value
                Catch ex As Exception
                    .Rows(2).Cells("Importi").Value = 0
                    .Rows(2).Cells("Importi").Value = 0
                End Try

                'differenza incassato su variazioni
                Try
                    cmd.CommandText = CommandStat(Query.IncassiDiffVar)
                    .Rows(3).Cells("Importi").Value = cmd.ExecuteScalar
                Catch ex As Exception
                    .Rows(3).Cells("Importi").Value = 0
                End Try

                Try
                    .Rows(3).Cells("ImportiPerc").Value = .Rows(3).Cells("Importi").Value / _
                                                          (Math.Abs(.Rows(3).Cells("Importi").Value) + _
                                                          .Rows(2).Cells("Importi").Value)
                Catch ex As Exception
                    .Rows(3).Cells("ImportiPerc").Value = 0
                End Try

                'differenza incassato su variazioni ABC
                cmd.CommandText = CommandStat(Query.IncassiDiffVarA)
                Try
                    .Rows(4).Cells("Importi").Value = cmd.ExecuteScalar
                Catch ex As Exception
                    .Rows(4).Cells("Importi").Value = 0
                End Try
                Try
                    .Rows(4).Cells("ImportiPerc").Value = .Rows(4).Cells("Importi").Value / _
                                                          .Rows(3).Cells("Importi").Value
                Catch ex As Exception
                    .Rows(4).Cells("ImportiPerc").Value = 0
                End Try
                'D-J
                Try
                    cmd.CommandText = CommandStat(Query.IncassiDiffVarD)
                    .Rows(5).Cells("Importi").Value = cmd.ExecuteScalar
                Catch ex As Exception
                    .Rows(5).Cells("Importi").Value = 0
                End Try
                Try
                    .Rows(5).Cells("ImportiPerc").Value = .Rows(5).Cells("Importi").Value / _
                                                          .Rows(3).Cells("Importi").Value
                Catch ex As Exception
                    dgvStat.Rows(5).Cells("ImportiPerc").Value = 0
                End Try
                'X
                cmd.CommandText = CommandStat(Query.IncassiDiffVarX)
                Try
                    .Rows(6).Cells("Importi").Value = cmd.ExecuteScalar
                Catch ex As Exception
                    .Rows(6).Cells("Importi").Value = 0
                End Try
                Try
                    .Rows(6).Cells("ImportiPerc").Value = .Rows(6).Cells("Importi").Value / _
                                                          .Rows(3).Cells("Importi").Value
                Catch ex As Exception
                    .Rows(6).Cells("ImportiPerc").Value = 0
                End Try
                'da incassare attuale e precedente
                cmd.CommandText = CommandStat(Query.IncassiAnnoPrecedente)
                .Rows(12).Cells("Importi").Value = cmd.ExecuteScalar
                .Rows(13).Cells("Importi").Value = .Rows(0).Cells("Importi").Value - _
                                                   .Rows(12).Cells("Importi").Value
                Try
                    .Rows(13).Cells("ImportiPerc").Value = .Rows(13).Cells("Importi").Value / _
                                                          .Rows(12).Cells("Importi").Value
                Catch ex As Exception
                    .Rows(13).Cells("ImportiPerc").Value = 0
                End Try

            End With
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub CalcolaStatisticheDisdette(ByRef cmd As OleDbCommand)
        Try
            With dgvStat
                'stornate/disdette
                Try
                    cmd.CommandText = CommandStat(Query.QTDisdette)
                    .Rows(7).Cells("QtNr").Value = cmd.ExecuteScalar
                Catch ex As Exception
                    .Rows(7).Cells("QtNr").Value = 0
                End Try

                If .Rows(7).Cells("QtNr").Value = 0 Then

                    .Rows(7).Cells("QtPerc").Value = "-"
                    .Rows(8).Cells("QtNr").Value = 0
                    .Rows(9).Cells("QtNr").Value = 0
                    .Rows(10).Cells("QtNr").Value = 0
                    .Rows(8).Cells("QtPerc").Value = "-"
                    .Rows(9).Cells("QtPerc").Value = "-"
                    .Rows(10).Cells("QtPerc").Value = "-"

                    .Rows(7).Cells("Importi").Value = 0
                    .Rows(8).Cells("Importi").Value = 0
                    .Rows(9).Cells("Importi").Value = 0
                    .Rows(10).Cells("Importi").Value = 0
                    .Rows(7).Cells("ImportiPerc").Value = "-"
                    .Rows(8).Cells("ImportiPerc").Value = "-"
                    .Rows(9).Cells("ImportiPerc").Value = "-"
                    .Rows(10).Cells("ImportiPerc").Value = "-"

                    Exit Try
                Else
                    .Rows(7).Cells("QtPerc").Value = .Rows(7).Cells("QtNr").Value / _
                                                     .Rows(0).Cells("QtNr").Value
                End If

                Try
                    cmd.CommandText = CommandStat(Query.IncassiDisdette)
                    .Rows(7).Cells("Importi").Value = cmd.ExecuteScalar
                    .Rows(7).Cells("ImportiPerc").Value = .Rows(7).Cells("Importi").Value / _
                                                          .Rows(0).Cells("Importi").Value
                Catch ex As Exception
                    .Rows(7).Cells("Importi").Value = 0
                    .Rows(7).Cells("ImportiPerc").Value = 0
                End Try

                'differenza su disdette ABC
                Try
                    cmd.CommandText = CommandStat(Query.QTDisdetteVarA)
                    .Rows(8).Cells("QtNr").Value = cmd.ExecuteScalar
                    .Rows(8).Cells("QtPerc").Value = .Rows(8).Cells("QtNr").Value / _
                                                     .Rows(7).Cells("QtNr").Value
                Catch ex As Exception
                    .Rows(8).Cells("QtNr").Value = 0
                    .Rows(8).Cells("QtPerc").Value = 0
                End Try
                Try
                    cmd.CommandText = CommandStat(Query.IncassiDisdetteA)
                    .Rows(8).Cells("Importi").Value = cmd.ExecuteScalar
                    .Rows(8).Cells("ImportiPerc").Value = .Rows(8).Cells("Importi").Value / _
                                                          .Rows(7).Cells("Importi").Value
                Catch ex As Exception
                    .Rows(8).Cells("Importi").Value = 0
                    .Rows(8).Cells("ImportiPerc").Value = 0
                End Try
                'D-J
                Try
                    cmd.CommandText = CommandStat(Query.QTDisdetteVarD)
                    .Rows(9).Cells("QtNr").Value = cmd.ExecuteScalar
                    .Rows(9).Cells("QtPerc").Value = .Rows(9).Cells("QtNr").Value / _
                                                       .Rows(7).Cells("QtNr").Value
                Catch ex As Exception
                    .Rows(9).Cells("QtNr").Value = 0
                    .Rows(9).Cells("QtPerc").Value = 0
                End Try
                Try
                    cmd.CommandText = CommandStat(Query.IncassiDisdetteD)
                    .Rows(9).Cells("Importi").Value = cmd.ExecuteScalar
                    .Rows(9).Cells("ImportiPerc").Value = .Rows(9).Cells("Importi").Value / _
                                                          .Rows(7).Cells("Importi").Value
                Catch ex As Exception
                    .Rows(9).Cells("Importi").Value = 0
                    .Rows(9).Cells("ImportiPerc").Value = 0
                End Try
                'X
                Try
                    cmd.CommandText = CommandStat(Query.QTDisdetteVarX)
                    .Rows(10).Cells("QtNr").Value = cmd.ExecuteScalar
                    .Rows(10).Cells("QtPerc").Value = .Rows(10).Cells("QtNr").Value / _
                                                        .Rows(7).Cells("QtNr").Value
                Catch ex As Exception
                    .Rows(10).Cells("QtNr").Value = 0
                    .Rows(10).Cells("QtPerc").Value = 0
                End Try
                Try
                    cmd.CommandText = CommandStat(Query.IncassiDisdetteX)
                    .Rows(10).Cells("Importi").Value = cmd.ExecuteScalar
                    .Rows(10).Cells("ImportiPerc").Value = .Rows(10).Cells("Importi").Value / _
                                                           .Rows(7).Cells("Importi").Value
                Catch ex As Exception
                    .Rows(10).Cells("Importi").Value = 0
                    .Rows(10).Cells("ImportiPerc").Value = 0
                End Try

            End With

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Function CommandStat(Tipo As Query) As String
        Select Case Tipo
            Case Query.QTPreviste
                CommandStat = "SELECT Count(*) " + _
                              "FROM MonitorQT"
            Case Query.IncassiPrevisti
                CommandStat = "SELECT Sum(TotRataLordoNew) " + _
                              "FROM MonitorQT"
            Case Query.QTNoVar
                CommandStat = "SELECT Count(*) " + _
                              "FROM Incassi i " + _
                              "INNER JOIN MonitorQT m ON i.Polizza = m.Polizza And " + _
                                                        "i.DataEffettoTitolo = m.Effetto " + _
                              "WHERE i.Ramo = 30 And m.Variata = False"
            Case Query.IncassiNoVar
                CommandStat = "SELECT Sum(i.TotaleTitolo) " + _
                              "FROM Incassi i " + _
                              "INNER JOIN MonitorQT m ON i.Polizza = m.Polizza And " + _
                                                        "i.DataEffettoTitolo = m.Effetto " + _
                              "WHERE i.Ramo = 30 And m.Variata = False"
            Case Query.QTVar
                CommandStat = "SELECT Count(*) " + _
                              "FROM Incassi i " + _
                              "INNER JOIN MonitorQT m ON i.Polizza = m.Polizza And " + _
                                                        "i.DataEffettoTitolo = m.Effetto " + _
                              "WHERE i.Ramo = 30 And m.Variata = True"
            Case Query.IncassiVar
                CommandStat = "SELECT Sum(i.TotaleTitolo) " + _
                              "FROM Incassi i " + _
                              "INNER JOIN MonitorQT m ON i.Polizza = m.Polizza And " + _
                                                        "i.DataEffettoTitolo = m.Effetto " + _
                              "WHERE i.Ramo = 30 And m.Variata = True"
            Case Query.IncassiDiffVar
                CommandStat = "SELECT Sum(i.TotaleTitolo) - Sum(m.TotRataLordoNew) " + _
                              "FROM Incassi i " + _
                              "INNER JOIN MonitorQT m ON i.Polizza = m.Polizza And " + _
                                                        "i.DataEffettoTitolo = m.Effetto " + _
                              "WHERE i.Ramo = 30 And m.Variata = True And m.Fatto = True"
            Case Query.IncassiDiffVarA
                CommandStat = "SELECT Sum(i.TotaleTitolo) - Sum(m.TotRataLordoNew) " + _
                              "FROM Incassi i " + _
                              "INNER JOIN MonitorQT m ON i.Polizza = m.Polizza And " + _
                                                        "i.DataEffettoTitolo = m.Effetto " + _
                              "WHERE i.Ramo = 30 And m.Variata = True And m.Fatto = True And " + _
                                    "FspNew In ('A','B','C')"
            Case Query.IncassiDiffVarD
                CommandStat = "SELECT Sum(i.TotaleTitolo) - Sum(m.TotRataLordoNew) " + _
                              "FROM Incassi i " + _
                              "INNER JOIN MonitorQT m ON i.Polizza = m.Polizza And " + _
                                                        "i.DataEffettoTitolo = m.Effetto " + _
                              "WHERE i.Ramo = 30 And m.Variata = True And m.Fatto = True And " + _
                                    "FspNew >= 'D'"
            Case Query.IncassiDiffVarX
                CommandStat = "SELECT Sum(i.TotaleTitolo) - Sum(m.TotRataLordoNew) " + _
                              "FROM Incassi i " + _
                              "INNER JOIN MonitorQT m ON i.Polizza = m.Polizza And " + _
                                                        "i.DataEffettoTitolo = m.Effetto " + _
                              "WHERE i.Ramo = 30 And m.Variata = True And m.Fatto = True And " + _
                                    "Trim(FspNew) = ''"
            Case Query.QTDisdette
                CommandStat = "SELECT Count(*) " + _
                              "FROM MonitorQT " + _
                              "WHERE Disdetta = True"
            Case Query.IncassiDisdette
                CommandStat = "SELECT Sum(TotRataLordoNew) " + _
                              "FROM MonitorQT " + _
                              "WHERE Disdetta = True"
            Case Query.QTDisdetteVarA
                CommandStat = "SELECT Count(*) " + _
                              "FROM MonitorQT " + _
                              "WHERE Disdetta = True And " + _
                                    "FspNew In ('A','B','C')"
            Case Query.QTDisdetteVarD
                CommandStat = "SELECT Count(*) " + _
                              "FROM MonitorQT " + _
                              "WHERE Disdetta = True And " + _
                                    "FspNew >= 'D'"
            Case Query.QTDisdetteVarX
                CommandStat = "SELECT Count(*) " + _
                              "FROM MonitorQT " + _
                              "WHERE Disdetta = True And " + _
                                    "Trim(FspNew) = ''"
            Case Query.IncassiDisdetteA
                CommandStat = "SELECT Sum(TotRataLordoNew) " + _
                              "FROM MonitorQT " + _
                              "WHERE Disdetta = True And " + _
                                    "FspNew In ('A','B','C')"
            Case Query.IncassiDisdetteD
                CommandStat = "SELECT Sum(TotRataLordoNew) " + _
                              "FROM MonitorQT " + _
                              "WHERE Disdetta = True And " + _
                                    "FspNew >= 'D'"
            Case Query.IncassiDisdetteX
                CommandStat = "SELECT Sum(TotRataLordoNew) " + _
                              "FROM MonitorQT " + _
                              "WHERE Disdetta = True And " + _
                                    "Trim(FspNew) = ''"
            Case Query.IncassiAnnoPrecedente
                CommandStat = "SELECT Sum(TotRataLordoOld) " + _
                              "FROM MonitorQT"
            Case Else
                CommandStat = ""
        End Select
    End Function

    Private Function CommandStat2(Tipo As Query, _
                                  Fascia As String) As String

        Dim WhereFascia As String
        Select Case Fascia
            Case "X" 'tutte le fasce
                WhereFascia = " (True) "
            Case "AC"
                WhereFascia = " (FspNew Between 'A' And 'C') "
            Case "DJ"
                WhereFascia = " (FspNew Between 'D' And 'J') "
            Case Else
                WhereFascia = " (FspNew = '" + Fascia + "') "
        End Select

        Select Case Tipo
            Case Query.QTSost
                CommandStat2 = "SELECT Count(*) " + _
                               "FROM MonitorQT " + _
                               "WHERE Sostituita = True And " + _
                                      WhereFascia
            Case Query.QTNoVar
                CommandStat2 = "SELECT Count(*) " + _
                               "FROM Incassi i " + _
                               "INNER JOIN MonitorQT m ON i.Polizza = m.Polizza And " + _
                                                         "i.DataEffettoTitolo = m.Effetto " + _
                               "WHERE i.Ramo = 30 And m.Variata = False And " + _
                                      WhereFascia
            Case Query.QTVar
                CommandStat2 = "SELECT Count(*) " + _
                               "FROM Incassi i " + _
                               "INNER JOIN MonitorQT m ON i.Polizza = m.Polizza And " + _
                                                         "i.DataEffettoTitolo = m.Effetto " + _
                               "WHERE i.Ramo = 30 And m.Variata = True And " + _
                                      WhereFascia
            Case Query.IncassiDiffVar
                CommandStat2 = "SELECT Sum(i.TotaleTitolo) - Sum(m.TotRataLordoNew) " + _
                               "FROM Incassi i " + _
                               "INNER JOIN MonitorQT m ON i.Polizza = m.Polizza And " + _
                                                         "i.DataEffettoTitolo = m.Effetto " + _
                               "WHERE i.Ramo = 30 And m.Variata = True And m.Fatto = True"
            Case Query.IncassiDiffVarFascia
                CommandStat2 = "SELECT Sum(i.TotaleTitolo) - Sum(m.TotRataLordoNew) " + _
                               "FROM Incassi i " + _
                               "INNER JOIN MonitorQT m ON i.Polizza = m.Polizza And " + _
                                                         "i.DataEffettoTitolo = m.Effetto " + _
                               "WHERE i.Ramo = 30 And m.Variata = True And m.Fatto = True And " + _
                                      WhereFascia
            Case Query.QTDisdette
                CommandStat2 = "SELECT Count(*) " + _
                               "FROM MonitorQT " + _
                               "WHERE Disdetta = True And " + _
                                      WhereFascia
            Case Query.QTUbox
                CommandStat2 = "SELECT Count(*)  " + _
                               "FROM MonitorQT " + _
                               "WHERE UniboxNew > 0 And " + _
                                      WhereFascia
            Case Query.QTConv
                CommandStat2 = "SELECT Count(*)  " + _
                               "FROM MonitorQT " + _
                               "WHERE Convenzione > 0 And " + _
                                      WhereFascia
            Case Else
                CommandStat2 = ""
        End Select
    End Function

    Private Sub ImpostaGrigliaStat()
        With dgvStat
            .Font = New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns.Add("Desk", "Descrizione")

            .Columns.Add("QtNr", "QT Nr")
            With .Columns("QtNr").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            .Columns.Add("QtPerc", "QT %")
            With .Columns("QtPerc").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Format = "##0.0%"
            End With

            .Columns.Add("Importi", "Importi")
            With .Columns("Importi").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "#,###,##0.00"
            End With

            .Columns.Add("ImportiPerc", "%")
            With .Columns("ImportiPerc").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Format = "##0.00%"
            End With

            .Rows.Add(14)

            .Rows(0).Cells("Desk").Value = "Quietanze in scadenza"
            .Rows(1).Cells("Desk").Value = "QT incassate senza variazioni"
            .Rows(2).Cells("Desk").Value = "QT incassate con variazione"
            .Rows(3).Cells("Desk").Value = "Differenza a seguito delle variazioni"
            .Rows(4).Cells("Desk").Value = "di cui Fsp A-C"
            .Rows(5).Cells("Desk").Value = "di cui Fsp D-J"
            .Rows(6).Cells("Desk").Value = "di cui senza Fsp"
            .Rows(7).Cells("Desk").Value = "QT Disdette/Stornate"
            .Rows(8).Cells("Desk").Value = "di cui Fsp A-C"
            .Rows(9).Cells("Desk").Value = "di cui Fsp D-J"
            .Rows(10).Cells("Desk").Value = "di cui senza Fsp"
            .Rows(12).Cells("Desk").Value = "Totale incassato anno precedente"
            .Rows(13).Cells("Desk").Value = "Differenza (attuale-precedente)"

            .Rows(4).Cells("Desk").Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Rows(5).Cells("Desk").Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Rows(6).Cells("Desk").Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Rows(8).Cells("Desk").Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Rows(9).Cells("Desk").Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Rows(10).Cells("Desk").Style.Alignment = DataGridViewContentAlignment.MiddleRight

            .Rows(4).DefaultCellStyle.BackColor = Color.GreenYellow
            .Rows(5).DefaultCellStyle.BackColor = Color.Gold
            .Rows(6).DefaultCellStyle.BackColor = Color.LightGray
            .Rows(8).DefaultCellStyle.BackColor = Color.GreenYellow
            .Rows(9).DefaultCellStyle.BackColor = Color.Gold
            .Rows(10).DefaultCellStyle.BackColor = Color.LightGray
            .Rows(12).DefaultCellStyle.BackColor = Color.LightYellow
            .Rows(13).DefaultCellStyle.BackColor = Color.LightYellow

            Dim f2 As Font = New System.Drawing.Font("Tahoma", 9, FontStyle.Regular)
            .Rows(4).DefaultCellStyle.Font = f2
            .Rows(5).DefaultCellStyle.Font = f2
            .Rows(6).DefaultCellStyle.Font = f2
            .Rows(8).DefaultCellStyle.Font = f2
            .Rows(9).DefaultCellStyle.Font = f2
            .Rows(10).DefaultCellStyle.Font = f2
        End With
    End Sub

    Private Sub ImpostaGrigliaStat2()
        With dgvStat2
            .Font = New System.Drawing.Font("Tahoma", 9, FontStyle.Regular)
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    Private Sub CalcolaStatistiche2()

        Dim MdbVuoto As String = ""
        Dim MdbStat As String = ""
        Dim cmd As New OleDbCommand
        Try
            With dgvStat2
                .SuspendLayout()
                .Columns.Clear()
                .DataSource = Nothing
                .Refresh()
            End With

            'crea l'mdb temporaneo in locale per l'analisi
            MdbVuoto = Path.Combine(Utx.Globale.Paths.CartellaModelli, "Vuoto.mdb")
            MdbStat = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Stat.mdb")

            If File.Exists(MdbStat) Then File.Delete(MdbStat)
            File.Copy(MdbVuoto, MdbStat)

            cn.ConnectionString = Utx.Globale.MDBDriver + MdbStat
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text

            'porto in locale la tabella monitor e quella incassi con i limiti imposti
            cmd.CommandText = "SELECT * " + _
                              "INTO MonitorQT " + _
                              "FROM MonitorQT In '" + Utx.Globale.Paths.DbLink + "' " + _
                              "WHERE " + WhereDate + " AND " + _
                                         WhereSub + " AND " + _
                                         WhereProduttore
            cmd.ExecuteNonQuery()

            cmd.CommandText = "SELECT * " + _
                              "INTO Incassi " + _
                              "FROM Incassi IN '" + Utx.Globale.Paths.DbLink + "' " + _
                              "WHERE DataEffettoTitolo BETWEEN " + DataUSA(dtpInizio.Value) + " AND " + _
                                                                   DataUSA(dtpFine.Value)
            cmd.ExecuteNonQuery()
            '----------------------------------

            Dim dt As New DataTable
            Dim da As New OleDbDataAdapter
            da.SelectCommand = New OleDbCommand("SELECT FspNew," + _
                                                       "Count(*) as Nr," + _
                                                       "0.001 as NrPerc," + _
                                                       "0 as NrUb," + _
                                                       "0 as NrConv," + _
                                                       "Sum(RcaLordoRataNew) as Rca," + _
                                                       "Sum(ArdLordoRataNew) as Ard," + _
                                                       "Sum(UniboxNew) as Canone," + _
                                                       "Sum(TotRataLordoNew + UniboxNew) as TotGen," + _
                                                       "Avg(RcaLordoRataNew) as MediaRca," + _
                                                       "Avg(TotRataLordoNew + UniboxNew) as MediaTot," + _
                                                       "0.001 as QTSenzaVR," + _
                                                       "0.001 as QTSenzaVRPerc," + _
                                                       "0.001 as QTConVR," + _
                                                       "0.001 as QTConVRPerc," + _
                                                       "0.001 as QTConSS," + _
                                                       "0.001 as QTConSSPerc," + _
                                                       "0.001 as QTDisdette," + _
                                                       "0.001 as QTDisdettePerc," + _
                                                       "0.001 as QTDiffVR," + _
                                                       "0.001 as QTDiffVRPerc " + _
                                                "FROM MonitorQT " + _
                                                "GROUP BY FspNew", cn)
            da.Fill(dt)

            'controllo se dt è vuoto
            If dt.Rows.Count = 0 Then
                MsgBox("Non ci sono dati da visualizzare.")
                cmd.Dispose()
                cn.Close()
                cn.Dispose()
                Exit Sub
            End If

            Dim TotDiffVR As Double
            cmd.CommandText = CommandStat2(Query.IncassiDiffVar, "")
            Try
                TotDiffVR = cmd.ExecuteScalar
            Catch ex As Exception
                TotDiffVR = 0
            End Try

            ToolStripPbStat.Visible = True
            ToolStripPbStat.Value = 0
            ToolStripPbStat.Maximum = dt.Rows.Count

            For Each r As DataRow In dt.Rows
                ToolStripPbStat.Value += 1

                cmd.CommandText = CommandStat2(Query.QTUbox, r.Item("FspNew"))
                r.Item("NrUb") = cmd.ExecuteScalar

                cmd.CommandText = CommandStat2(Query.QTConv, r.Item("FspNew"))
                r.Item("NrConv") = cmd.ExecuteScalar

                cmd.CommandText = CommandStat2(Query.QTNoVar, r.Item("FspNew"))
                r.Item("QTSenzaVR") = cmd.ExecuteScalar
                r.Item("QTSenzaVRPerc") = r.Item("QTSenzaVR") / r.Item("Nr")

                cmd.CommandText = CommandStat2(Query.QTVar, r.Item("FspNew"))
                r.Item("QTConVR") = cmd.ExecuteScalar
                r.Item("QTConVRPerc") = r.Item("QTConVR") / r.Item("Nr")

                cmd.CommandText = CommandStat2(Query.QTSost, r.Item("FspNew"))
                r.Item("QTConSS") = cmd.ExecuteScalar
                r.Item("QTConSSPerc") = r.Item("QTConSS") / r.Item("Nr")

                cmd.CommandText = CommandStat2(Query.QTDisdette, r.Item("FspNew"))
                r.Item("QTDisdette") = cmd.ExecuteScalar
                r.Item("QTDisdettePerc") = r.Item("QTDisdette") / r.Item("Nr")

                Try
                    cmd.CommandText = CommandStat2(Query.IncassiDiffVarFascia, r.Item("FspNew"))
                    r.Item("QTDiffVR") = cmd.ExecuteScalar
                    r.Item("QTDiffVRPerc") = r.Item("QTDiffVR") / TotDiffVR
                Catch ex As Exception
                    r.Item("QTDiffVR") = 0
                    r.Item("QTDiffVRPerc") = 0
                End Try
            Next

            'se ci sono qt senza fsp sono (per l'ordinamento della query) alla riga 0
            Dim RigaSenzaFsp As Int16 = -1
            If dt.Rows(0).Item("FspNew").ToString = String.Empty Then
                dt.Rows(0).Item("FspNew") = "Senza"
                RigaSenzaFsp = 0
            End If

            'totali
            dt.Rows.Add()
            dt.Rows.Add("Totali")
            dt.Rows.Add("di cui senza")
            dt.Rows.Add("di cui A-C")
            dt.Rows.Add("di cui D-J")

            Dim RigaTot As Int16 = dt.Rows.Count - 4
            Dim RigaSenzaTot As Int16 = dt.Rows.Count - 3
            Dim Riga1 As Int16 = dt.Rows.Count - 2
            Dim Riga2 As Int16 = dt.Rows.Count - 1
            Dim MaxCol As Int16 = dt.Columns.Count - 1
            Dim MaxRow As Int16 = dt.Rows.Count - 6

            For nCol As Int16 = 1 To MaxCol

                'copia riga senza
                If RigaSenzaFsp = 0 Then
                    dt.Rows(RigaSenzaTot).Item(nCol) = dt.Rows(RigaSenzaFsp).Item(nCol)
                Else
                    dt.Rows(RigaSenzaTot).Item(nCol) = 0
                End If

                Dim TotAC As Double = 0
                Dim TotDJ As Double = 0

                For nRow As Int16 = 0 To MaxRow
                    Select Case dt.Rows(nRow).Item("FspNew")
                        Case "Senza"
                            'non fare niente
                        Case "A", "B", "C"
                            TotAC += dt.Rows(nRow).Item(nCol)
                        Case Is >= "D"
                            TotDJ += dt.Rows(nRow).Item(nCol)
                    End Select
                Next

                dt.Rows(Riga1).Item(nCol) = TotAC
                dt.Rows(Riga2).Item(nCol) = TotDJ
                'sommo i due sub totali (AC e DJ) e la riga senza nei totali
                dt.Rows(RigaTot).Item(nCol) = TotAC + TotDJ + dt.Rows(RigaSenzaTot).Item(nCol)
            Next

            For k As Int16 = 0 To dt.Rows.Count - 1
                Try
                    dt.Rows(k).Item(2) = dt.Rows(k).Item(1) / dt.Rows(RigaTot).Item(1)
                Catch ex As Exception
                End Try
            Next
            'percentuali nelle 3 righe di totali
            For k As Int16 = RigaTot To Riga2
                With dt.Rows(k)
                    If .Item("Nr") > 0 Then
                        .Item("QTSenzaVRPerc") = .Item("QTSenzaVR") / .Item("Nr")
                        .Item("QTConVRPerc") = .Item("QTConVR") / .Item("Nr")
                        .Item("QTConSSPerc") = .Item("QTConSS") / .Item("Nr")
                        .Item("QTDisdettePerc") = .Item("QTDisdette") / .Item("Nr")
                    Else
                        .Item("QTSenzaVRPerc") = 0
                        .Item("QTConVRPerc") = 0
                        .Item("QTConSSPerc") = 0
                        .Item("QTDisdettePerc") = 0
                    End If

                    If dt.Rows(RigaTot).Item("QTDiffVR") <> 0 Then
                        .Item("QTDiffVRPerc") = .Item("QTDiffVR") / dt.Rows(RigaTot).Item("QTDiffVR")
                    Else
                        .Item("QTDiffVRPerc") = 0
                    End If
                End With
            Next

            dgvStat2.DataSource = dt

            FormattaColonneStat2()

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            ToolStripPbStat.Visible = False

            cmd.Dispose()
            cn.Close()
            cn.Dispose()

            If File.Exists(MdbStat) Then File.Delete(MdbStat)
        End Try

        dgvStat2.ResumeLayout()
    End Sub

    Private Sub FormattaColonneStat2()
        On Error Resume Next

        With dgvStat2
            .Rows(.Rows.Count - 5).DefaultCellStyle.BackColor = Color.LightGray
            .Rows(.Rows.Count - 4).DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)
            .Rows(.Rows.Count - 4).Cells(0).Style.BackColor = Color.GreenYellow
            .Rows(.Rows.Count - 4).DefaultCellStyle.SelectionBackColor = Color.DarkOrange
            .Rows(.Rows.Count - 3).Cells(0).Style.BackColor = Color.GreenYellow
            .Rows(.Rows.Count - 2).Cells(0).Style.BackColor = Color.GreenYellow
            .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = Color.GreenYellow

            'intestazioni delle colonne
            .Columns("FspNew").HeaderText = "Fsp"
            .Columns("NrPerc").HeaderText = "Nr %"
            .Columns("NrUb").HeaderText = "Ubox"
            .Columns("NrConv").HeaderText = "Conv"
            .Columns("TotGen").HeaderText = "Totale"
            .Columns("MediaRca").HeaderText = "Media Rca"
            .Columns("MediaTot").HeaderText = "Media Totale"
            .Columns("QTSenzaVR").HeaderText = "QT inc senza VR"
            .Columns("QTSenzaVRPerc").HeaderText = "QT inc senza VR %"
            .Columns("QTConVR").HeaderText = "QT inc con VR"
            .Columns("QTConVRPerc").HeaderText = "QT inc con VR %"
            .Columns("QTConSS").HeaderText = "QT sost"
            .Columns("QTConSSPerc").HeaderText = "QT sost %"
            .Columns("QTDisdette").HeaderText = "QT disdette"
            .Columns("QTDisdettePerc").HeaderText = "QT disdette %"
            .Columns("QTDiffVR").HeaderText = "Diff da VR"
            .Columns("QTDiffVRPerc").HeaderText = "Diff da VR %"

            'colonne da non nascondere hanno il tag = x
            Dim ColHide As String = "/NrPerc/FspNew/Nr/TotGen/MediaTot/QTDiffVR/QTDiffVRPerc/"
            For Each c As DataGridViewColumn In dgvStat2.Columns
                If ColHide.Contains("/" + c.Name + "/") Then c.Tag = "x"
            Next

            'allineamento al centro
            Dim ColCentra As String = "FspNew;Nr;NrPerc;NrUb;NrConv;QTSenzaVR;QTConVR;QTConSS;QTDisdette"
            For Each c As String In ColCentra.Split(";")
                .Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            'per gli importi in euro, formattazione e allineamento a destra
            Dim ColEuro As String = "Rca;Ard;Canone;TotGen;MediaRca;MediaTot;QTDiffVR"
            For Each c As String In ColEuro.Split(";")
                .Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(c).DefaultCellStyle.Format = "###,##0.00"
            Next

            .Columns("FspNew").DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)
            .Columns("FspNew").DefaultCellStyle.BackColor = Color.LightYellow
            .Columns("Nr").DefaultCellStyle.BackColor = Color.Gold
            .Columns("TotGen").DefaultCellStyle.BackColor = Color.Gold
            .Columns("MediaTot").DefaultCellStyle.BackColor = Color.Gold
            .Columns("QTDiffVR").DefaultCellStyle.BackColor = Color.Lavender
            .Columns("QTDiffVRPerc").DefaultCellStyle.BackColor = Color.LavenderBlush

            'per le percentuali, formattazione e allineamento al centro
            Dim ColPerc As String = "NrPerc;QTSenzaVRPerc;QTConVRPerc;QTConSSPerc;QTDisdettePerc;QTDiffVRPerc"

            For Each c As String In ColPerc.Split(";")
                .Columns(c).DefaultCellStyle.Format = "##0.00%"
                .Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            For k As Int16 = 0 To 7
                .Columns.Item(k).Frozen = chkBloccaColonne.Checked
            Next

            dgvStat2.AutoResizeColumns()
        End With

        GrigliaFormattata = True
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Cursor.Current = Cursors.WaitCursor

        Try
            cboFiltro.SelectedIndex = 0

            ImpostaWhere()

            If TabStat.SelectedIndex = 0 Then
                CalcolaStatistiche()
            Else
                CalcolaStatistiche2()
            End If

        Catch ex As Exception
            Log.Errore(ex)
        End Try

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        On Error Resume Next
        If dgvStat2.Rows.Count = 0 Then Exit Sub

        ToolStripButton1.Tag = Not ToolStripButton1.Tag

        For Each col As DataGridViewColumn In dgvStat2.Columns
            If col.Tag <> "x" Then
                col.Visible = ToolStripButton1.Tag
            End If
        Next

        If ToolStripButton1.Tag = True Then
            ToolStripButton2.Text = "Nascondi colonne"
        Else
            ToolStripButton2.Text = "Scopri colonne"
        End If
    End Sub

    Private Sub btnVisualizzaQT_Click(sender As System.Object, e As System.EventArgs) Handles btnVisualizzaQT.Click
        TabQuietanze.SelectTab(0)
        TabQuietanze.Refresh()

        If (txtSub.Text.Trim <> String.Empty And (Not IsNumeric(txtSub.Text))) Or _
           (txtProduttore.Text.Trim <> String.Empty And (Not IsNumeric(txtProduttore.Text))) Then

            MsgBox("Codice Sub e/o produttore errati.", MsgBoxStyle.Exclamation, "Unitools")
            Exit Sub
        End If

        ResetTxtTotali()
        GrigliaFormattata = False
        LeggiTab()

        Dim ea As New System.EventArgs
        dgv1_SelectionChanged(Me, ea)

        TotaleFlex()

        dgv1.Focus()
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click

        If dgv1.RowCount = 0 Then
            Exit Sub
        End If

        Dim NomeFile As String = String.Format("Monitor Qt al {0}", Format(Now, "dd-MM-yyyy"))

        Utx.NetFunc.Esporta2Excel({dgv1}, {"Quietanze"}, NomeFile, Color.Khaki)
    End Sub

    Private Sub cboFiltro_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboFiltro.SelectedIndexChanged
        ResetElenco()
    End Sub

    Private Sub txtCerca_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCerca.TextChanged
        ResetElenco()
    End Sub

    Private Sub cboSaturazione_TextChanged(sender As System.Object, e As System.EventArgs) Handles cboSaturazione.SelectedIndexChanged
        ResetElenco()
    End Sub

    Private Sub txtSub_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSub.TextChanged
        ResetElenco()
    End Sub

    Private Sub txtProduttore_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProduttore.TextChanged
        ResetElenco()
    End Sub

    Private Sub ResetElenco()
        dgv1.DataSource = Nothing
        Elenco.Text = "Elenco quietanze (" + dgv1.RowCount.ToString + ")"
    End Sub

    Private Sub btnAnnullaFiltri_Click(sender As System.Object, e As System.EventArgs) Handles btnAnnullaFiltri.Click
        txtCerca.Text = ""
        txtSub.Text = ""
        txtProduttore.Text = ""
        cboFiltro.SelectedIndex = 0
    End Sub

    Private Sub wbLegenda_DocumentCompleted(sender As Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles wbLegenda.DocumentCompleted
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub TabStat1_Enter(sender As Object, e As System.EventArgs) Handles TabStat1.Enter
        ToolStripButton2.Visible = False
    End Sub

    Private Sub TabStat2_Enter(sender As Object, e As System.EventArgs) Handles TabStat2.Enter
        ToolStripButton2.Visible = True
    End Sub

    Private Sub btnDettaglioRca_Click(sender As System.Object, e As System.EventArgs) Handles btnDettaglioRca.Click
        ApriDettaglio("TabRca")
    End Sub

    Private Sub btnDettaglioIF_Click(sender As System.Object, e As System.EventArgs) Handles btnDettaglioIF.Click
        ApriDettaglio("TabIF")
    End Sub

    Private Sub btnDettaglioKasko_Click(sender As System.Object, e As System.EventArgs) Handles btnDettaglioKasko.Click
        ApriDettaglio("TabIF")
    End Sub
    Private Sub btnDettaglioArd_Click(sender As System.Object, e As System.EventArgs) Handles btnDettaglioArd.Click
        ApriDettaglio("TabArd")
    End Sub

    Private Sub btnDettaglioUnibox_Click(sender As System.Object, e As System.EventArgs) Handles btnDettaglioUnibox.Click
        ApriDettaglio("TabUnibox")
    End Sub

    Private Sub ApriDettaglio(TabDefault As String)
        If dgv1.RowCount = 0 Then Exit Sub

        Using DettaglioArd As New FormArd()

            With DettaglioArd
                .Text = dgv1.CurrentRow.Cells("Contraente").Value
                .Main = Me
                .TabDefault = TabDefault
                .ShowDialog()
            End With
        End Using
    End Sub

    Private Sub Legenda_Enter(sender As Object, e As System.EventArgs) Handles Legenda.Enter
        Cursor.Current = Cursors.WaitCursor
        ChiudiDettaglioPremi()
        LinkLabelDettaglio.Enabled = False
        LinkLabelPannello.Enabled = False
        If wbLegenda.Url = Nothing Then wbLegenda.Navigate(LinkDoc)
    End Sub

    Private Sub btnIndice_Click(sender As System.Object, e As System.EventArgs) Handles btnIndice.Click
        wbLegenda.Navigate(LinkDoc)
    End Sub

    Private Sub lbMessaggio_TextChanged(sender As Object, e As System.EventArgs) Handles lbMessaggio.TextChanged
        Try
            If dgv1.CurrentRow.Cells("CambioFraz").Value = "S" Then
                With lbMessaggio
                    .BackColor = Color.Gold
                    .BorderStyle = BorderStyle.Fixed3D
                End With
            Else
                With lbMessaggio
                    .BackColor = Color.Transparent
                    .BorderStyle = BorderStyle.None
                End With
            End If
        Catch ex As Exception
            '
        End Try
    End Sub

    'Private Sub btnIama_Click(sender As System.Object, e As System.EventArgs) Handles btnIama.Click

    '    Dim Parametri As String

    '    If dgv1.CurrentRow Is Nothing Then
    '        Parametri = " 5" 'in caso di riga non selezionata o griglia vuota
    '    Else
    '        Dim CF As String = dgv1.CurrentRow.Cells("CodiceFiscale").Value
    '        Dim Polizza As String = "30/" + dgv1.CurrentRow.Cells("Polizza").Value.ToString

    '        Parametri = " 5=" + CF + "=" + Polizza
    '    End If

    '    Shell("C:\ApplicazioniDirezione\Unitools\ProDoc.exe " + Parametri, AppWinStyle.NormalFocus, False)
    'End Sub

    Private Sub btnStampaTutto_Click(sender As Object, e As EventArgs) Handles btnStampaTutto.Click

        Try
            Using Pd As New PrintDialog

                If Pd.ShowDialog = Windows.Forms.DialogResult.OK Then

                    For k As Integer = 0 To dgv1.Rows.Count - 1

                        If dgv1.Rows(k).Visible Then

                            'seleziona la riga della griglia
                            dgv1.CurrentCell = dgv1.Rows(k).Cells(0)
                            dgv1_SelectionChanged(Me, New EventArgs)

                            Using f As New FormArd
                                f.Main = Me
                                f.TabDefault = "TabRca"
                                f.StampaAutomatica = True
                                f.SettingStampante = Pd.PrinterSettings
                                f.ShowDialog()
                            End Using
                        End If
                    Next
                End If
            End Using

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub dgv1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv1.ColumnHeaderMouseClick

        Try
            'cartella per salvataggio filtro
            FormFiltro.AppName = "MonitorQT"
            FormFiltro.FilterFolder = Utx.Globale.Paths.CartellaSettingRete

            'visualizzo la finestra del filtro
            FormFiltro.Visualizza(dgv1.Columns(e.ColumnIndex))

            'conto le righe visibili
            Dim Righe As Integer = 0

            For k As Integer = 0 To dgv1.Rows.Count - 1
                If dgv1.Rows(k).Visible Then
                    Righe += 1
                End If
            Next

            ImpostaTab(Righe)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub btnAnagCliente_Click(sender As Object, e As EventArgs) Handles btnAnagCliente.Click
        Try
            If dgv1.CurrentRow IsNot Nothing Then
                Using FormAnagrafiche As New Anag.FormAnagrafiche
                    FormAnagrafiche.SelezionaClientePerCodiceFiscale(dgv1.CurrentRow.Cells("CodiceFiscale").Value)
                    FormAnagrafiche.ShowDialog()
                End Using
            Else
                MsgBox("Selezionare prima un cliente", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
