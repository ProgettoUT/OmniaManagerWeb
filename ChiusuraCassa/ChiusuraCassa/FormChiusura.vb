Imports Microsoft.Office.Interop
Imports System.Text

Public Class FormChiusura

#Region "Dichiarazioni"
    Dim Importa As ExportLib.Export

    Friend WithEvents dgvElenco As New DgvExt
    Friend WithEvents dgvQuadrature As New DgvExt
    Friend WithEvents dgvRecuperi As New DgvExt
    Friend WithEvents dgvTotali As New DgvExt
    Friend WithEvents dgvDettaglio As New DgvExt
    Friend WithEvents dgvTipoPagamento As New DgvExt
    Friend WithEvents dgvStat As New DgvExt

    Dim WithEvents dtpGiorno As New DateTimePicker
    Dim WithEvents cboTipoMovimento As New ComboBox
    Dim WithEvents cboPuntoVendita As New ComboBox
    Dim WithEvents cboCassa As New ComboBox
    Dim WithEvents cboSezione As New ComboBox
    Dim WithEvents btnChiudi As New Button
    Dim WithEvents btnSezioneBD As New Button
    Dim WithEvents cm As New ContextMenuStrip
    Dim WithEvents txtTrova As New TextBox
    Dim tslCassa As New ToolStripLabel
    Dim Login As Utx.AutenticazioneEssig

    Dim Notifica As New Utx.FormNotifica

    Private dtElenco As DataTable
    Private dtStampati As DataTable
    Private cQuantita As New Collection
    Private cTotali As New Collection
    Private ToolTip1 As New ToolTip
    Private Entrate, Uscite As Double

    Private Structure Colori
        Shared Uscite As Color = Color.SandyBrown
        Shared Cassetto As Color = Color.GreenYellow
        Shared Banca As Color = Color.Khaki
        Shared CO As Color = Color.Orange
        Shared Scoperti As Color = Color.LightSalmon
        Shared Direzione As Color = Color.LightBlue
        Shared EsitoIC As Color = Color.Bisque
        Shared EsitoIS As Color = Color.GreenYellow
        Shared RP As Color = Color.Lavender
        Shared PR As Color = Color.Khaki
        Shared VE As Color = Color.Aquamarine
        Shared FEA As Color = Color.Gainsboro
        Shared OK As Color = Color.Gold
    End Structure
#End Region

    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Font = Utx.AppFont.Normal
    End Sub

    'Private Sub FormChiusura_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    Globale.cn.Dispose()
    'End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.SuspendLayout()
        Me.Text = "Chiusura cassa"
        Me.Icon = My.Resources.monete

        ImpostaToolStrip()

        With btnAggiornaAssegni
            .Font = New Font("Tahoma", 12, FontStyle.Bold)
            .Text = "+"
        End With
        With btnCancellaAssegni
            .Padding = New Padding(10, 0, 10, 0)
            .Text = "Cancella"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.Annulla.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With btnSalvaQuadratura
            .Padding = New Padding(10, 0, 10, 0)
            .Text = "Seleziona un punto vendita per la quadratura"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.save.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With btnConsolida
            .Padding = New Padding(10, 0, 10, 0)
            .Text = "Consolida e chiudi la giornata"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.consolida.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        btnAggiorna.Image = My.Resources.aggiorna.ToBitmap
        btnExcel.Image = My.Resources.Excel.ToBitmap
        btnScan.Visible = False

        ProgressBar1.Visible = False
        lbProgress.Text = ""

        ToolTip1.SetToolTip(btnAggiornaAssegni, "Aggiungi al totale assegni")
        ToolTip1.SetToolTip(txtAssegno, "Importo singolo assegno")
        ToolTip1.SetToolTip(btnCancellaAssegni, "Cancella uno/tutti")

        lbPv.Text = "Tutti i punti vendita"
        lbDettaglio.Text = ""

        'cboPuntoVendita.Font = Globale.Glo.MainFont
        'cboCassa.Font = Globale.Glo.MainFont

        TabCassa.HotTrack = True
        ToolStrip1.BackColor = Color.Orange

        TabElenco.Text = "Movimenti"
        TabTotali.Text = "Totali"
        TabQuadrature.Text = "Quadrature cassetto"
        TabCO.Text = "CO/SC da recuperare"
        TabStat.Text = "Statistiche"
        TabHelp.Text = "Guida on-line"

        txtTotaleCassetto.ReadOnly = True
        txtTotaleTitoli.ReadOnly = True
        txtAbbuoni.ReadOnly = True
        txtQuadratura.ReadOnly = True

        'ImpostaToolStrip()
        ImpostaGriglie()
        ImpostaCollezioni()

        'immagini
        PictureBoxMonete.Image = My.Resources.monete.ToBitmap
        PictureBox5.Image = My.Resources.B5
        PictureBox10.Image = My.Resources.B10
        PictureBox20.Image = My.Resources.B20
        PictureBox50.Image = My.Resources.B50
        PictureBox100.Image = My.Resources.B100
        PictureBox200.Image = My.Resources.B200
        PictureBox500.Image = My.Resources.B500

        'imposta menù contestuale
        cm.Items.Add("Cambia punto vendita", My.Resources.aggiorna.ToBitmap).Name = "PuntoVendita"
        cm.Items.Add("Ripartisci movimento misto", My.Resources.dividi.ToBitmap).Name = "Misto"
        cm.Items.Add("Cancella movimento", My.Resources.Annulla.ToBitmap).Name = "Cancella"
        dgvElenco.ContextMenuStrip = cm

        SplitContainer1.SplitterDistance = SplitContainer1.Width * 0.5
        SplitContainer1.IsSplitterFixed = True

        AddHandler dtpGiorno.ValueChanged, AddressOf dtpGiorno_ValueChanged
        AddHandler cboTipoMovimento.SelectedIndexChanged, AddressOf dtpGiorno_ValueChanged
        AddHandler cboPuntoVendita.SelectedIndexChanged, AddressOf dtpGiorno_ValueChanged
        AddHandler cboCassa.SelectedIndexChanged, AddressOf dtpGiorno_ValueChanged
        AddHandler cboSezione.SelectedIndexChanged, AddressOf dtpGiorno_ValueChanged
        AddHandler txtTotaleTitoli.TextChanged, AddressOf txtTotaleCassetto_TextChanged

        Me.ResumeLayout()
    End Sub

    Private Sub FormChiusura_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        If ControlloPuntiVendita() = True Then
            AbbinamentoPuntiVendita()
        End If
        LeggiElenco()
    End Sub

    Private Sub ImpostaGriglie()

        For Each t As TabPage In TabCassa.TabPages
            t.Padding = New Padding(0)
        Next

        TabElenco.Controls.Add(dgvElenco)
        With dgvElenco
            .Dock = DockStyle.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
        End With

        TableLayoutPanel1.Controls.Add(dgvTotali, 0, 1)
        With dgvTotali
            .Dock = DockStyle.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .BackgroundColor = Color.Khaki
        End With

        TableLayoutPanel1.Controls.Add(dgvDettaglio, 1, 1)
        With dgvDettaglio
            .Dock = DockStyle.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
        End With

        TableLayoutPanel1.Controls.Add(dgvTipoPagamento, 0, 3)
        TableLayoutPanel1.SetColumnSpan(dgvTipoPagamento, 2)
        With dgvTipoPagamento
            .Dock = DockStyle.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
        End With

        SplitContainer1.Panel2.Controls.Add(dgvQuadrature)
        With dgvQuadrature
            .Dock = DockStyle.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
        End With

        TabStat.Controls.Add(dgvStat)
        With dgvStat
            .Dock = DockStyle.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
        End With

        TabCO.Controls.Add(dgvRecuperi)
        With dgvRecuperi
            .Dock = DockStyle.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
        End With
    End Sub

    Private Sub ImpostaToolStrip()

        With tsMain
            .Visible = False
            .SuspendLayout()
            .GripStyle = ToolStripGripStyle.Hidden
            .RenderMode = ToolStripRenderMode.ManagerRenderMode
            .AutoSize = False
        End With

        With ToolStrip1
            .Visible = False
            .SuspendLayout()
            .GripStyle = ToolStripGripStyle.Hidden
            .RenderMode = ToolStripRenderMode.ManagerRenderMode
            .Items.Clear()
        End With

        Dim ttch As ToolStripControlHost

        ToolStrip1.Items.Add(New ToolStripLabel(" Giorno:"))
        With dtpGiorno
            .Format = DateTimePickerFormat.Short
            .Width = 100

            If Now.Hour < 13 Then
                .Value = Now.AddDays(-1)
            Else
                .Value = Now
            End If
#If DEBUG Then
            dtpGiorno.Value = Now
#End If
        End With
        ttch = New ToolStripControlHost(dtpGiorno)
        ToolStrip1.Items.Add(ttch)

        ToolStrip1.Items.Add(New ToolStripLabel(" Movimenti:"))
        With cboTipoMovimento
            .AutoSize = False
            .Width = 100
            .DropDownStyle = ComboBoxStyle.DropDownList

            ImpostaTipoMovimento(cboTipoMovimento)
        End With
        ttch = New ToolStripControlHost(cboTipoMovimento)
        ToolStrip1.Items.Add(ttch)

        ToolStrip1.Items.Add(New ToolStripLabel(" Punto vendita:"))
        With cboPuntoVendita
            .AutoSize = False
            .Width = 120
            .DropDownStyle = ComboBoxStyle.DropDownList
            .BackColor = Color.Yellow
        End With
        ttch = New ToolStripControlHost(cboPuntoVendita)
        ToolStrip1.Items.Add(ttch)

        ImpostaPuntoVendita(cboPuntoVendita, "Tutti")

        ToolStrip1.Items.Add(New ToolStripLabel(" Cassa:"))
        With cboCassa
            .AutoSize = False
            .Width = 80
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With
        ttch = New ToolStripControlHost(cboCassa)
        ToolStrip1.Items.Add(ttch)

        ImpostaCassa(cboCassa, "Tutte")

        ToolStrip1.Items.Add(New ToolStripLabel(" Sezione:"))
        With cboSezione
            .AutoSize = False
            .Width = 100
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With
        ttch = New ToolStripControlHost(cboSezione)
        ToolStrip1.Items.Add(ttch)

        ImpostaSezione(cboSezione, "Tutte")

        ToolStrip1.Items.Add(New ToolStripLabel(Space(1)))

        With btnSezioneBD
            .Text = "Decade sezione BD"
            .BackColor = Color.Gainsboro
        End With
        ttch = New ToolStripControlHost(btnSezioneBD) With {.AutoSize = True}
        ToolStrip1.Items.Add(ttch)

        With btnChiudi
            .Text = "Chiudi"
            .BackColor = Color.Gold
        End With
        ttch = New ToolStripControlHost(btnChiudi) With {.AutoSize = False}
        ToolStrip1.Items.Add(ttch)

        tsMain.Items.Add(New ToolStripLabel(" Cerca:"))
        With txtTrova
            .Width = 150
        End With
        ttch = New ToolStripControlHost(txtTrova) With {.AutoSize = False}
        tsMain.Items.Add(ttch)

        With ToolStrip1
            .Visible = True
            .ResumeLayout()
            .Refresh()
        End With
        With tsMain
            .Visible = True
            .ResumeLayout()
            .Refresh()
        End With

    End Sub

#Region "Impostazione Clausole"

    Private Function ImpostaClausolaWhere() As String
        Try
            Dim sb As New StringBuilder
            With sb
                .Append($" DataEsito = '{dtpGiorno.Value:dd/MM/yyyy}'")

                If cboTipoMovimento.SelectedIndex = 0 Then
                    .Append(" AND TipoRecord < 100 ") 'movimenti assicurativi
                Else
                    .Append(" AND TipoRecord >= 100 ") 'movimenti extra
                End If

                If cboPuntoVendita.SelectedIndex > 0 Then .Append(" AND " + ClausolaLegamiPuntiVendita(CodicePvSelezionato(cboPuntoVendita)))
                If cboCassa.SelectedIndex > 0 Then .Append($" AND CodiceCassa = '{cboCassa.Text}'")
                If cboSezione.SelectedIndex > 0 Then .Append($" AND Sezione = '{cboSezione.Items(cboSezione.SelectedIndex).Codice}'")
                If txtTrova.Text.Length > 0 Then .Append($" AND Contraente LIKE '%{txtTrova.Text.Trim}%'")
            End With

            Return sb.ToString

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Function ImpostaClausolaWhereCassa() As String
        Try
            'tipo record
            If cboTipoMovimento.SelectedIndex = 0 Then
                ImpostaClausolaWhereCassa = " TipoRecord < 100 "
            Else
                ImpostaClausolaWhereCassa = " TipoRecord >= 100 "
            End If

            'sezione e data
            ImpostaClausolaWhereCassa += $" AND Sezione = 'CA' AND DataEsito = '{dtpGiorno.Value:dd/MM/yyyy}'"

            'punto vendita
            If cboPuntoVendita.SelectedIndex > 0 Then
                ImpostaClausolaWhereCassa += " AND " + ClausolaLegamiPuntiVendita(CodicePvSelezionato(cboPuntoVendita))
            End If

            'cassa
            If cboCassa.SelectedIndex > 0 Then
                ImpostaClausolaWhereCassa += $" AND CodiceCassa = '{cboCassa.Text}'"
            End If

        Catch ex As Exception
            ImpostaClausolaWhereCassa = ""
            Globale.Log.Errore(ex)
        End Try
    End Function

    Private Function ImpostaClausolaWhereAbbuoni(PuntoVendita As Integer) As String
        Try
            'tipo movimento
            ImpostaClausolaWhereAbbuoni = " LEN(TRIM(TipoMovimento)) = 0 "

            'tipo record solo assicurativi
            ImpostaClausolaWhereAbbuoni += " AND TipoRecord < 100 "

            'sezione e data
            ImpostaClausolaWhereAbbuoni += $" AND Sezione = 'CA' AND DataEsito = '{dtpGiorno.Value:dd/MM/yyyy}'"

            'punto vendita
            If cboPuntoVendita.SelectedIndex > 0 Then
                ImpostaClausolaWhereAbbuoni += " AND PuntoVendita = " + PuntoVendita.ToString
            End If

            'tutte le casse

        Catch ex As Exception
            ImpostaClausolaWhereAbbuoni = ""
            Globale.Log.Errore(ex)
        End Try
    End Function

    Private Function ClausolaLegamiPuntiVendita(PuntoVendita As Integer) As String
        Return $" (PuntoVendita = {PuntoVendita}) "
    End Function

    Private Function ClausolaEsistenzaStampati() As String
        'i documenti vengono visualizzati fino a 5 giorni dopo la fine della decade
        ClausolaEsistenzaStampati = " ((DecadeDoc IS NULL) OR ((DecadeDoc + 5) >= GETDATE())) AND 
            (TipoCarico IN ('1','2','3','6','9')) AND 
            (Esito Not IN ('IC','IS')) AND 
            (TipoRecord = 0) AND 
            (LEN(TRIM(TipoMovimento)) = 0) "
    End Function

#End Region

    Private Function QueryElenco() As String
        Try
            Return $"SELECT DecadeDoc,Spunta as Ok,PuntoVendita as Pv,SubAgenzia,Ramo,Polizza,EffettoTitolo,
                TipoCarico,Esito,TipoPagamento,DataEsito,CodiceCassa,Contraente,TotaleTitolo,TipoMovimento,TipoRecord,Protocollo,
                Id,Sezione,Iif(Segno ='E','Ent','Usc') AS Segno,Iif(DecadeDoc IS Null,cast(0 as bit),cast(1 as bit)) AS Doc,'N' AS Stampati 
                FROM ChiusuraCassa 
                WHERE {ImpostaClausolaWhere()} 
                ORDER BY Contraente,PuntoVendita"
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Function QueryElenco(Sezione As String, TipoPagamento As String) As String
        Try
            Return $"SELECT Spunta as Ok,PuntoVendita as Pv,SubAgenzia,Ramo,Polizza,EffettoTitolo,TipoCarico,Esito,
                TipoPagamento,DataEsito,CodiceCassa,Contraente,TotaleTitolo,TipoMovimento,TipoRecord,
                Protocollo,Id,Iif(Segno ='E','Ent','Usc') as Segno 
                FROM ChiusuraCassa 
                WHERE ({ImpostaClausolaWhere()}) AND (TipoPagamento = '{TipoPagamento}') AND (Sezione = '{Sezione}') 
                ORDER BY Contraente"
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Function QueryElencoDoc() As String
        Try
            Return $"SELECT DecadeDoc,IIf(Day(DataEsito) < 11,'1 DEC ',
                IIf(Day(DataEsito) < 21,'2 DEC ','3 DEC ')) + Format(DataEsito,'MM-yyyy') as Busta,PuntoVendita as Pv,SubAgenzia,
                Ramo,Polizza,EffettoTitolo,Esito,DataEsito,Contraente,TotaleTitolo,TipoRecord,Protocollo,
                Iif(DecadeDoc IS Null,cast(0 as bit),cast(1 as bit)) as Doc 
                FROM ChiusuraCassa 
                WHERE {ClausolaEsistenzaStampati()} 
                ORDER BY Esito"
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Function ControlloPuntiVendita() As Boolean
        Try
            Dim PuntiVendita As Integer = Utx.WsCommand.ExecuteScalar("SELECT Count(*) FROM PuntiVendita").Valore

            'codici sub
            If PuntiVendita = 0 Then
                MsgBox("Prima di iniziare è necessario definire i punti vendita.", MsgBoxStyle.Information)
                btnGestioneCodici_Click(Me, New System.EventArgs)
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
    End Function

    Private Sub LeggiElenco()
        Try
            Cursor.Current = Cursors.WaitCursor

            dtElenco = New DataTable
            dtElenco.Columns.Add("Doc", System.Type.GetType("System.Boolean"))

            'eseguo la query di ricerca
            dtElenco = Utx.WsCommand.ExecuteNonQuery(QueryElenco).DataTable

            TabElenco.Text = $"Movimenti ({dtElenco.Rows.Count}/{MovimentiExtra()})"

            dgvElenco.DataSource = New BindingSource(dtElenco, Nothing)

            FormattaElenco(dgvElenco)

            Dim th As New Threading.Thread(Sub()
                                               Totali(dtElenco)
                                           End Sub)
            th.Start()

            dgvElenco.Focus()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub LeggiTotali()
        Try
            Cursor.Current = Cursors.WaitCursor

            cboSezione.SelectedIndex = 0

            Dim Query As String = $"SELECT * FROM
                (SELECT SUM(C.TotaleTitolo) AS Totale,S.Codice AS Id,S.Sezione ,C.Segno
                FROM ChiusuraCassa AS C 
                INNER JOIN Sezioni AS S ON S.Codice = C.Sezione 
                WHERE {ImpostaClausolaWhere()}
                GROUP BY S.Codice,S.Sezione,C.Segno) AS A
                PIVOT (SUM(A.Totale) FOR A.Segno IN ([E],[U])) AS B"

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            AggiungiColonna(dt, "E")
            AggiungiColonna(dt, "U")
            AggiungiColonna(dt, "Saldo")

            'calcola saldi
            For Each dr As DataRow In dt.Rows
                If IsDBNull(dr("E")) Then dr("E") = 0
                If IsDBNull(dr("U")) Then dr("U") = 0
                dr("Saldo") = dr("E") + dr("U") 'le uscite hanno già il segno meno incorporato nel valore
            Next

            With dgvTotali
                .DataSource = dt
                .Focus()
            End With

            FormattaTotali()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub LeggiDettaglio()
        Try
            lbDettaglio.Text = $"B. Dettaglio {dgvTotali.CurrentRow.Cells("Sezione").Value}"

            Dim Query As String = $"SELECT * FROM
                (SELECT SUM(C.TotaleTitolo) AS Totale,C.TipoPagamento,P.Desk,C.Segno
                FROM ChiusuraCassa AS C 
                INNER JOIN Sezioni AS S ON S.Codice = C.Sezione 
                INNER JOIN DB00000.dbo.Pagamento P ON C.TipoPagamento = P.TipoPagamento
                WHERE {ImpostaClausolaWhere()} AND C.Sezione = '{dgvTotali.CurrentRow.Cells("Id").Value}' 
                GROUP BY C.TipoPagamento,P.Desk,C.Segno) AS A
                PIVOT (SUM(A.Totale) FOR A.Segno IN ([E],[U])) AS B"

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            AggiungiColonna(dt, "E")
            AggiungiColonna(dt, "U")

            With dgvDettaglio
                .DataSource = dt
                .Focus()
            End With

            FormattaDettaglio()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub LeggiDettaglioTipoPagamento()
        Try
            Dim TipoPagamento As String = dgvDettaglio.CurrentRow.Cells(0).Value

            lbTipoPagamento.Text = $"C. Dettaglio per tipo pagamento ({TipoPagamento})"

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(QueryElenco(dgvTotali.CurrentRow.Cells(0).Value.ToString.Substring(0, 2),
                                                  TipoPagamento)).DataTable
            With dgvTipoPagamento
                .DataSource = dt
                .Focus()
            End With

            FormattaElenco(dgvTipoPagamento)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub LeggiRecuperi()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim ClausolaWhere As String = " 1=1 "
            If cboPuntoVendita.SelectedIndex > 0 Then ClausolaWhere = ClausolaLegamiPuntiVendita(CodicePvSelezionato(cboPuntoVendita))

            Dim Query As String = $"SELECT Spunta as Ok,PuntoVendita as Pv,SubAgenzia,Ramo,Polizza,EffettoTitolo,
                TipoCarico,Esito,TipoPagamento,DataEsito,CodiceCassa,Contraente,TotaleTitolo,TipoMovimento,
                TipoRecord,Protocollo,Id,Iif(Segno ='E','Ent','Usc') as Segno 
                FROM ChiusuraCassa 
                WHERE (Esito In ('CO','SC')) AND (Rientro = 'N') AND {ClausolaWhere}
                ORDER BY DataEsito"

            With dgvRecuperi
                .DataSource = Utx.WsCommand.ExecuteNonQuery(Query).DataTable
                .AutoResizeColumns()
                .Focus()
            End With

            FormattaElenco(dgvRecuperi)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub AggiornaQuadrature()
        LeggiQuadrature() 'visualizzo l'elenco delle quadrature
        EstraiQuadratura() 'se esiste recupero la precedente quadratura
        txtAbbuoni.Text = Format(SaldoAbbuoni(CodicePvSelezionato(cboPuntoVendita)), Globale.FValuta) 'visualizzo abbuoni registrati in essig
        txtTotaleTitoli.Text = Format(SaldoCassa(), Globale.FValuta) 'visualizzo il totale titoli
    End Sub

    Private Sub LeggiQuadrature()
        Try
            'per visualizzare l'elenco delle quadrature
            Cursor.Current = Cursors.WaitCursor
            TableLayoutPanel2.Refresh()
            dgvQuadrature.DataSource = Nothing
            dgvQuadrature.Refresh()
            dgvQuadrature.SuspendLayout()

            Dim Query As String = "SELECT Data,PuntoVendita,
                B500*500 + B200*200 + B100*100 + B50*50 + B20*20 + B10*10 + B5*5 + Moneta + TotaleAssegni AS Totale,
                B500,B200,B100,B50,B20,B10,B5,Moneta,TotaleAssegni AS Assegni 
                FROM Quadrature
                WHERE DATEDIFF(day,Data,GETDATE()) <= 60
                ORDER BY Data DESC,PuntoVendita,CodiceCassa"

            With dgvQuadrature
                .DataSource = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                With .Columns("Totale")
                    .DefaultCellStyle.BackColor = Color.PaleGreen
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "c"
                End With
                With .Columns("Moneta")
                    .DefaultCellStyle.BackColor = Color.Moccasin
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "c"
                End With
                With .Columns("Assegni")
                    .DefaultCellStyle.BackColor = Color.Gainsboro
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "c"
                End With

                .AutoResizeColumns()
                .Refresh()
            End With

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            dgvQuadrature.ResumeLayout()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function EstraiQuadratura() As Boolean

        If cboPuntoVendita.SelectedIndex = 0 Then
            ResetQuadratura()
            EstraiQuadratura = False
            Exit Function
        End If

        Cursor.Current = Cursors.WaitCursor

        Try
            Dim Query As String = $"SELECT TOP 1 * 
                FROM Quadrature 
                WHERE Data = '{dtpGiorno.Value:dd/MM/yyyy}' AND 
                PuntoVendita = {CodicePvSelezionato(cboPuntoVendita)} AND 
                CodiceCassa = '{IIf(cboCassa.SelectedIndex = 0, "00", cboCassa.Text)}'"

            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query)

            If dr.HasRows Then
                dr.Read()

                txt500.Text = dr("B500")
                txt200.Text = dr("B200")
                txt100.Text = dr("B100")
                txt50.Text = dr("B50")
                txt20.Text = dr("B20")
                txt10.Text = dr("B10")
                txt5.Text = dr("B5")
                txtMonetaTot.Text = dr("Moneta")

                'assegni
                cboAssegnoTot.Items.Clear()
                cboAssegnoTot.Items.Add(0)
                txtAssegno.Text = dr("TotaleAssegni")
                AggiungiAssegno()

                txtNumeroAssegni.Text = dr("NumeroAssegni")

                EstraiQuadratura = True
            Else
                ResetQuadratura()
                EstraiQuadratura = False
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub ResetQuadratura()

        txt500.Text = 0
        txt200.Text = 0
        txt100.Text = 0
        txt50.Text = 0
        txt20.Text = 0
        txt10.Text = 0
        txt5.Text = 0
        txtMonetaTot.Text = 0

        'assegni
        cboAssegnoTot.Items.Clear()
        cboAssegnoTot.Items.Add(0)
        txtNumeroAssegni.Text = 0

    End Sub

    Private Function SaldoCassa() As Double
        Try
            Dim Query As String = "SELECT SUM(TotaleTitolo) AS Saldo FROM ChiusuraCassa WHERE " + ImpostaClausolaWhereCassa()
            Return Utx.WsCommand.ExecuteScalar(Query).Valore
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return 0
        End Try
    End Function

    Private Function SaldoAbbuoni(PuntoVendita As Integer) As Object
        Try
            Dim Query As String = "SELECT SUM(TotaleTitolo - ImportoIncassato) 
                FROM ChiusuraCassa 
                WHERE " + ImpostaClausolaWhereAbbuoni(PuntoVendita)

            Dim Valore As Object = Utx.WsCommand.ExecuteScalar(Query).Valore

            If IsDBNull(Valore) Then
                SaldoAbbuoni = 0
            Else
                SaldoAbbuoni = Math.Round(Utx.WsCommand.ExecuteScalar(Query).Valore, 2)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            SaldoAbbuoni = 0
        End Try
    End Function

    Private Sub AggiungiColonna(ByRef dt As DataTable, Colonna As String)
        Try
            For Each dc As DataColumn In dt.Columns
                If dc.ColumnName.ToUpper = Colonna Then Exit Try
            Next

            dt.Columns.Add(Colonna, System.Type.GetType("System.Double"))

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub dgvElenco_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvElenco.CellContentClick
        'se clicco sul check della documentazione
        If (e.ColumnIndex = dgvElenco.Columns("Doc").Index) Then

            'se il tipo riga prevede documentazione
            If dtElenco.Rows(e.RowIndex).Item("Stampati") = "S" Then

                dtElenco.Rows(e.RowIndex).Item("Doc") = Not dtElenco.Rows(e.RowIndex).Item("Doc")

                If dtElenco.Rows(e.RowIndex).Item("Doc") = True Then
                    dtElenco.Rows(e.RowIndex).Item("DecadeDoc") = DataFineDecade(Now)
                Else
                    dtElenco.Rows(e.RowIndex).Item("DecadeDoc") = System.DBNull.Value
                End If

                ModificaDecadeDocumentazione(dgvElenco.CurrentRow)
            End If
        End If
        dgvElenco.EndEdit()
    End Sub

    Private Sub dgvElenco_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvElenco.KeyDown

        If TabCassa.SelectedIndex > 0 Then Exit Sub
        If dgvElenco.Rows.Count = 0 Then Exit Sub

        Select Case e.KeyCode
            Case Keys.Return
                'metto/tolgo il segno di spunta
                ModificaSpunta()

            Case Keys.Delete
                If dgvElenco.CurrentRow.Cells("TipoRecord").Value <> Globale.TipoRecord.Essig Then 'movimenti d'agenzia
                    CancellaMovimento()
                    LeggiElenco()
                End If
        End Select
    End Sub

    Private Sub dtpGiorno_ValueChanged(sender As System.Object, e As System.EventArgs)
        TabCassa.SelectedTab = TabElenco

        If cboPuntoVendita.SelectedIndex = 0 Then
            lbPv.Text = "Tutti i punti vendita"
        Else
            lbPv.Text = cboPuntoVendita.Text
        End If

        btnConsolida.Text = "Consolida " + Format(dtpGiorno.Value, "dd-MM-yyyy")

        AggiornaTab()
    End Sub

    Private Sub AggiornaTab()

        'ripulisce le somme nella barra di stato
        lbSelezionati.Text = ""
        lbSomma.Text = ""
        lbMedia.Text = ""

        TabCassa.SelectedTab.Refresh()

        Select Case TabCassa.SelectedTab.Name
            Case "TabElenco"
                LeggiElenco()
            Case "TabTotali"
                LeggiTotali()
            Case "TabQuadrature"
                AggiornaQuadrature()
            Case "TabStat"
                Statistiche()
            Case "TabCO"
                LeggiRecuperi()
        End Select
    End Sub

    Private Sub btnChiudi_Click(sender As Object, e As System.EventArgs) Handles btnChiudi.Click
        Me.Close()
    End Sub

    Private Sub btnSezioneBD_Click(sender As Object, e As System.EventArgs) Handles btnSezioneBD.Click
        DecadeBD()
    End Sub

    Private Sub dgvTotali_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvTotali.CellFormatting

        On Error Resume Next

        Select Case dgvTotali.Columns(e.ColumnIndex).Name.ToUpper
            Case "ID"
                Select Case e.Value
                    Case "BA" : e.CellStyle.BackColor = Colori.Banca
                    Case "CA" : e.CellStyle.BackColor = Colori.Cassetto
                    Case "CO" : e.CellStyle.BackColor = Colori.CO
                    Case "SC" : e.CellStyle.BackColor = Colori.Scoperti
                    Case "DR" : e.CellStyle.BackColor = Colori.Direzione
                End Select

            Case "SEZIONE"
                Select Case e.Value
                    Case "BANCA" : e.CellStyle.BackColor = Colori.Banca
                    Case "CASSETTO" : e.CellStyle.BackColor = Colori.Cassetto
                    Case "CO" : e.CellStyle.BackColor = Colori.CO
                    Case "SCOPERTO" : e.CellStyle.BackColor = Colori.Scoperti
                    Case "DIREZIONE" : e.CellStyle.BackColor = Colori.Direzione
                End Select

            Case "E"
                e.CellStyle.BackColor = Color.LightGreen

            Case "U"
                e.CellStyle.BackColor = Colori.Uscite
        End Select
    End Sub

    Private Sub FormattaElenco(ByRef dgv As DataGridView)

        On Error Resume Next

        With dgv
            .SuspendLayout()

            'nasconde colonne
            .Columns("TipoRecord").Visible = False
            .Columns("Protocollo").Visible = False
            .Columns("Id").Visible = False
            If .Columns("Stampati") IsNot Nothing Then .Columns("Stampati").Visible = False
            If .Columns("DecadeDoc") IsNot Nothing Then .Columns("DecadeDoc").Visible = False

            'intestazioni delle colonne
            .Columns("SubAgenzia").HeaderText = "Sub"
            .Columns("TipoCarico").HeaderText = "Tipo carico"
            .Columns("TipoPagamento").HeaderText = "Pag."
            .Columns("CodiceCassa").HeaderText = "Cassa"
            .Columns("EffettoTitolo").HeaderText = "Effetto"
            .Columns("DataEsito").HeaderText = "Data esito"
            .Columns("Contraente").HeaderText = "Contraente - Descrizione"
            .Columns("TotaleTitolo").HeaderText = "Tot.titolo"
            .Columns("TipoMovimento").HeaderText = "Tipo mov."
            If .Columns("Sezione") IsNot Nothing Then .Columns("Sezione").HeaderText = "Sez"

            'formato
            .Columns("TotaleTitolo").DefaultCellStyle.Format = Globale.FValuta
            .Columns("TotaleTitolo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            '(bug) attenzione: se trova una colonna va in loop!
            For Each c As String In "Ok/Pv/SubAgenzia/Ramo/TipoCarico/TipoPagamento/CodiceCassa".Split("/")
                .Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            '------------------------------------------------

            .AutoResizeColumns()
        End With
    End Sub

    Private Sub FormattaElencoDoc(ByRef dgv As DataGridView)

        On Error Resume Next

        With dgv
            .SuspendLayout()

            'nasconde colonne
            .Columns("TipoRecord").Visible = False
            .Columns("Protocollo").Visible = False

            'intestazioni delle colonne
            .Columns("SubAgenzia").HeaderText = "Sub"
            .Columns("DecadeDoc").HeaderText = "Invio"
            .Columns("TipoCarico").HeaderText = "Tipo carico"
            .Columns("EffettoTitolo").HeaderText = "Effetto"
            .Columns("DataEsito").HeaderText = "Data esito"
            .Columns("TotaleTitolo").HeaderText = "Tot.titolo"

            '(bug) se trova una colonna va in loop
            For Each c As String In "Pv/SubAgenzia/Ramo/Esito/Busta".Split("/")
                .Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            '-------------------------------------

            .Columns("Busta").DefaultCellStyle.BackColor = Color.Khaki

            .Columns("TotaleTitolo").DefaultCellStyle.Format = Globale.FValuta
            .Columns("TotaleTitolo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .AutoResizeColumns()
        End With

    End Sub

    Private Sub FormattaTotali()

        On Error Resume Next

        With dgvTotali
            .SuspendLayout()

            'intestazioni delle colonne
            .Columns("E").HeaderText = "Entrate"
            .Columns("U").HeaderText = "Uscite"

            .Columns("E").DefaultCellStyle.Format = Globale.FValuta
            .Columns("E").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("U").DefaultCellStyle.Format = Globale.FValuta
            .Columns("U").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo").DefaultCellStyle.Format = Globale.FValuta
            .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .AutoResizeColumns()
        End With

    End Sub

    Private Sub FormattaDettaglio()

        On Error Resume Next

        With dgvDettaglio
            .SuspendLayout()

            'intestazioni delle colonne
            .Columns("E").HeaderText = "Entrate"
            .Columns("U").HeaderText = "Uscite"
            .Columns("TipoPagamento").HeaderText = "Pag"
            .Columns("Desk").HeaderText = "Descrizione"

            .Columns("TipoPagamento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("E").DefaultCellStyle.Format = Globale.FValuta
            .Columns("E").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("U").DefaultCellStyle.Format = Globale.FValuta
            .Columns("U").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .AutoResizeColumns()
        End With

    End Sub

    Private Sub dgvTotali_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvTotali.SelectionChanged
        LeggiDettaglio()
    End Sub

    Private Sub ImpostaCollezioni()
        With cQuantita
            .Add(txt500)
            .Add(txt200)
            .Add(txt100)
            .Add(txt50)
            .Add(txt20)
            .Add(txt10)
            .Add(txt5)
        End With
        With cTotali
            .Add(txt500Tot)
            .Add(txt200Tot)
            .Add(txt100Tot)
            .Add(txt50Tot)
            .Add(txt20Tot)
            .Add(txt10Tot)
            .Add(txt5Tot)
            .Add(txtNumeroAssegni)
        End With

        For Each c As TextBox In cTotali
            c.ReadOnly = True
            c.BackColor = Color.Beige
        Next

        With cboAssegnoTot
            .BackColor = Color.Beige
            .Items.Clear()
            .Items.Add("0")
            .SelectedIndex = 0
        End With

        For Each c As TextBox In cQuantita
            AddHandler c.KeyPress, AddressOf txt500_KeyPress
            AddHandler c.TextChanged, AddressOf txt500_TextChanged
        Next

        txtTotaleCassetto.BackColor = Color.Yellow

    End Sub

    Private Sub btnAggiornaAssegni_Click(sender As System.Object, e As System.EventArgs) Handles btnAggiornaAssegni.Click
        AggiungiAssegno()
    End Sub

    Private Sub AggiungiAssegno()

        If txtNumeroAssegni.Text = String.Empty Then txtNumeroAssegni.Text = 0

        If IsNumeric(txtAssegno.Text) Then

            If txtAssegno.Text = 0 Then

                txtAssegno.Text = ""

            ElseIf txtAssegno.Text > 0 Then
                cboAssegnoTot.Items.Add(Format(CDbl(txtAssegno.Text), Globale.FValuta))
                cboAssegnoTot.SelectedIndex = 0 'seleziona 0 che contiene il totale

                cboAssegnoTot.Items(0) = Format(CDbl(cboAssegnoTot.Items(0)) +
                                                CDbl(txtAssegno.Text), Globale.FValuta)

                txtNumeroAssegni.Text += 1
                txtAssegno.Text = ""
            End If
        Else
            txtAssegno.Text = ""
        End If

    End Sub

    Private Sub CalcolaSubTotali()

        Try
            Dim SubTotale As Double = 0

            For k As Integer = 1 To 7
                If IsNumeric(cQuantita(k).Text) Then
                    cTotali(k).Text = Format(cQuantita(k).Text * cQuantita(k).Name.Substring(3), Globale.FValuta)
                Else
                    cTotali(k).Text = 0
                End If
            Next

            CalcolaTotali()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Private Sub CalcolaTotali()

        Try
            txtTotaleCassetto.Text = 0

            Dim Totale As Double = 0

            For k As Integer = 1 To 7
                If IsNumeric(cTotali(k).Text) Then Totale += cTotali(k).Text
            Next

            If IsNumeric(txtMonetaTot.Text) Then Totale += txtMonetaTot.Text
            If IsNumeric(cboAssegnoTot.Items(0)) Then Totale += CDbl(cboAssegnoTot.Items(0))

            txtTotaleCassetto.Text = Format(Totale, Globale.FValuta)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Private Sub txt500_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)

        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8
                'ok
            Case Else
                e.KeyChar = ""
        End Select

    End Sub

    Private Sub txt500_TextChanged(sender As System.Object, e As System.EventArgs)
        CalcolaSubTotali()
    End Sub

    Private Sub txtMonetaTot_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMonetaTot.TextChanged
        CalcolaTotali()
    End Sub

    Private Sub txtNumeroAssegni_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroAssegni.TextChanged
        CalcolaTotali()
    End Sub

    Private Sub txtAssegno_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssegno.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 44 'numerici, backspace e virgola
                'ok
            Case 46 'punto trasformato in virgola
                e.KeyChar = ","
            Case 13
                AggiungiAssegno()
            Case Else
                e.KeyChar = ""
        End Select
    End Sub

    Private Sub txtMonetaTot_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonetaTot.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 44 'numerici, backspace e virgola
                'ok
            Case 46 'punto trasformato in virgola
                e.KeyChar = ","
            Case Else
                e.KeyChar = ""
        End Select
    End Sub

    Private Sub btnCancellaAssegni_Click(sender As System.Object, e As System.EventArgs) Handles btnCancellaAssegni.Click

        If cboAssegnoTot.SelectedIndex = 0 Then
            cboAssegnoTot.Items.Clear()
            cboAssegnoTot.Items.Add("0")
            txtNumeroAssegni.Text = 0
        Else
            cboAssegnoTot.Items(0) = Format(CDbl(cboAssegnoTot.Items(0)) -
                                            CDbl(cboAssegnoTot.Text), Globale.FValuta)

            cboAssegnoTot.Items.RemoveAt(cboAssegnoTot.SelectedIndex)
            txtNumeroAssegni.Text -= 1
        End If

        cboAssegnoTot.SelectedIndex = 0
    End Sub

    Private Sub btnConsolida_Click(sender As System.Object, e As System.EventArgs) Handles btnConsolida.Click

        If EsisteChiusura(dtpGiorno.Value) Then
            MsgBox($"Chiusura giornaliera del {dtpGiorno.Text} già effettuata.",
                   MsgBoxStyle.Information, "Cassa")
            Exit Sub
        End If

        If Not PrimoGiorno(dtpGiorno.Value) Then
            If Not EsisteChiusura(dtpGiorno.Value.AddDays(-1)) Then
                MsgBox("Chiudere prima le giornate precedenti.", MsgBoxStyle.Exclamation, "Cassa")
                Exit Sub
            End If
        End If

        If MsgBox("Confermate il consolidamento della giornata?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question,
                  "Chiusura cassa") = MsgBoxResult.No Then Exit Sub

        Try
            Dim Query As String = "SELECT PuntoVendita 
                    FROM ChiusuraCassa 
                    WHERE PuntoVendita > 0
                    GROUP BY PuntoVendita"

            Dim IdTrans As String = IDTransazione()

            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query)

            Do While dr.Read 'per tutti i PV
                AddRiporto("CA", dr("PuntoVendita"), "1.CASSA", IdTrans)
                AddRiporto("BA", dr("PuntoVendita"), "2.BANCA", IdTrans)
                AddRiporto("CO", dr("PuntoVendita"), "3.CO", IdTrans)
                AddRiporto("SC", dr("PuntoVendita"), "4.SCOPERTI", IdTrans)
                AddRiporto("BD", dr("PuntoVendita"), "4.BANCA DIR", IdTrans)
            Loop

            'visualizza la chiusura
            TabCassa.SelectedTab = TabElenco
            dtpGiorno.Value = dtpGiorno.Value.AddDays(1)

            MsgBox($"La giornata del {dtpGiorno.Value.ToShortDateString} è stata consolidata.",
                   MsgBoxStyle.Information, Globale.TitoloApp)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub AddRiporto(Sezione As String,
                           PuntoVendita As Integer,
                           Desk As String,
                           Id As String)
        Try
            Dim Riporto As Double = CalcolaRiporto(Sezione, PuntoVendita)

            If Sezione = "CA" Then
                Riporto -= SaldoAbbuoni(PuntoVendita)
            End If

            Dim Query As New Utx.NetFunc.StringFormatter("INSERT INTO ChiusuraCassa 
                (TipoRecord,Id,Sezione,Segno,PuntoVendita,Ramo,Polizza,Esito,TipoPagamento,DataEsito,CodiceCassa,
                Contraente,Subagenzia,TotaleTitolo,TipoMovimento,Spunta) 
                VALUES (@tipo,@id,@sezione,@segno,@pv,0,0,'RP','RP',@data,'00',
                        @contraente,@sub,@totale,'CHIUSURA','N')")

            With Query
                .Parametro("@tipo", Globale.TipoRecord.Chiusura)
                .Parametro("@id", Id, True)
                .Parametro("@sezione", Sezione, True)
                .Parametro("@segno", IIf(Riporto >= 0, "E", "U"), True)
                .Parametro("@pv", PuntoVendita)
                .Parametro("@data", Format(dtpGiorno.Value.AddDays(1), "dd/MM/yyyy"), True)
                .Parametro("@contraente", Microsoft.VisualBasic.Left(Desk, 40), True)
                .Parametro("@sub", 0)
                .Parametro("@totale", Riporto)
            End With
            Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function CalcolaRiporto(Sezione As String,
                                    PuntoVendita As Integer) As Double
        Try
            Dim Query As String = $"SELECT Sum(TotaleTitolo) AS Saldo 
                FROM ChiusuraCassa 
                WHERE Sezione = '{Sezione}' AND 
                DataEsito = '{dtpGiorno.Value:dd/MM/yyyy}' AND 
                PuntoVendita = {PuntoVendita}"

            CalcolaRiporto = Math.Round(Utx.WsCommand.ExecuteScalar(Query).Valore, 2)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            CalcolaRiporto = 0
        End Try
    End Function

    Private Function EsisteChiusura(Giorno As Date) As Boolean
        Try
            Dim Query As String = $"SELECT Count(*) 
                FROM ChiusuraCassa 
                WHERE TipoRecord = {Globale.TipoRecord.Chiusura.ToString("D")} AND DataEsito = '{Giorno.Date.AddDays(1):dd/MM/yyyy}'"

            Return (Utx.WsCommand.ExecuteScalar(Query).Valore > 0)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Sub CancellaDatiCassa(Giorno As Date)
        Try
            Dim Query As String = $"DELETE FROM ChiusuraCassa WHERE DataEsito <= '{Giorno.Date.AddDays(1):dd/MM/yyyy}'"
            Utx.WsCommand.ExecuteNonQueryRecord(Query)
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function PrimoGiorno(Giorno As Date) As Boolean
        Try
            Dim Query As String = "SELECT Min(DataEsito) FROM ChiusuraCassa"
            Return (Utx.WsCommand.ExecuteScalar(Query).Valore = Giorno.Date)
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Sub CancellaMovimento()
        Try
            If EsisteChiusura(dtpGiorno.Value) Then
                MsgBox("E' necessario cancellare prima la chiusura giornaliera" + vbNewLine +
                   "del " + dtpGiorno.Value.ToShortDateString + ".", MsgBoxStyle.Exclamation, "Cassa")
                Exit Sub
            End If

            If MsgBox("Confermate la cancellazione del movimento e le eventuali contropartite?",
                  MsgBoxStyle.Question +
                  MsgBoxStyle.YesNo +
                  MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim Query As String = $"DELETE
            FROM ChiusuraCassa 
            WHERE Id = '{dgvElenco.CurrentRow.Cells("Id").Value}'"
            Utx.WsCommand.ExecuteNonQueryRecord(Query)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub txtTotaleCassetto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotaleCassetto.TextChanged

        If IsNumeric(txtTotaleCassetto.Text) AndAlso IsNumeric(txtTotaleTitoli.Text) Then

            txtQuadratura.Text = Format(CDbl(txtTotaleCassetto.Text) +
                                        CDbl(txtAbbuoni.Text) -
                                        CDbl(txtTotaleTitoli.Text), Globale.FValuta)
        End If

    End Sub

    Private Sub VersamentoInBancaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VersamentoInBancaToolStripMenuItem.Click
        btnVersamento_ButtonClick(sender, e)
    End Sub

    Private Sub btnVersamento_ButtonClick(sender As System.Object, e As System.EventArgs) Handles btnVersamento.ButtonClick

        If EsisteChiusura(dtpGiorno.Value) Then
            MsgBox("Impossibile aggiungere il movimento: giornata già consolidata.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim ver As New frmVersamento
        With ver
            .Text = "Versamento"
            .StartPosition = FormStartPosition.CenterScreen
            .MinimizeBox = False
            .MaximizeBox = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            .Giorno = dtpGiorno.Value.ToShortDateString
            .ShowDialog()
        End With

        LeggiElenco()
        LeggiTotali()
    End Sub

    Private Sub VersamentoDaSubagenziaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VersamentoDaSubagenziaToolStripMenuItem.Click

        If EsisteChiusura(dtpGiorno.Value) Then
            MsgBox("Impossibile aggiungere il movimento: giornata già consolidata.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim ver As New frmVersamentoSub
        With ver
            .Text = "Versamento"
            .StartPosition = FormStartPosition.CenterScreen
            .MinimizeBox = False
            .MaximizeBox = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            .Giorno = dtpGiorno.Value.ToShortDateString
            .ShowDialog()
        End With

        LeggiElenco()
        LeggiTotali()
    End Sub

    Private Sub InserimentoRiportoManualeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InserimentoRiportoManualeToolStripMenuItem.Click

        If EsisteChiusura(dtpGiorno.Value) Then
            MsgBox("Impossibile aggiungere il movimento: giornata già consolidata.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim ver As New frmRiporto
        With ver
            .Text = "Riporto"
            .StartPosition = FormStartPosition.CenterScreen
            .MinimizeBox = False
            .MaximizeBox = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            .Giorno = dtpGiorno.Value.ToShortDateString

            .ShowDialog()
        End With

        LeggiElenco()
        LeggiTotali()
    End Sub

    'Private Sub VisualizzaAssegniDelGiornoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VisualizzaAssegniDelGiornoToolStripMenuItem.Click

    '    Dim FileAssegni As String = IdFileAssegni(dtpGiorno.Value)

    '    If File.Exists(FileAssegni) Then
    '        System.Diagnostics.Process.Start(FileAssegni)
    '    Else
    '        MsgBox("File assegni del " + dtpGiorno.Value.ToShortDateString.ToString + " non trovato.", _
    '               MsgBoxStyle.Exclamation, "Assegni")
    '    End If
    'End Sub

    Private Sub btnScan_ButtonClick(sender As System.Object, e As System.EventArgs) Handles btnScan.ButtonClick

        Dim fScanner As New frmScanner
        With fScanner
            .MaximizeBox = False
            .MinimizeBox = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.CenterScreen
            .Text = "Scansione assegni"
            .Giorno = dtpGiorno.Value
            '.FileAssegni = IdFileAssegni(dtpGiorno.Value)

            .ShowDialog()
        End With
    End Sub

    Private Sub btnSalvaQuadratura_Click(sender As System.Object, e As System.EventArgs) Handles btnSalvaQuadratura.Click

        For Each t As TextBox In cQuantita
            If t.Text.Trim = String.Empty Then t.Text = 0
        Next
        If cboAssegnoTot.Text.Trim = String.Empty Then cboAssegnoTot.Text = 0
        If txtNumeroAssegni.Text.Trim = String.Empty Then txtNumeroAssegni.Text = 0
        If txtMonetaTot.Text.Trim = String.Empty Then txtMonetaTot.Text = 0
        If txtTotaleCassetto.Text.Trim = String.Empty Then txtTotaleCassetto.Text = 0

        If txtTotaleCassetto.Text = 0 Then Exit Sub

        If txtQuadratura.Text <> 0 Then
            MsgBox("Il campo quadratura deve essere uguale a zero." + vbNewLine +
                   "Registrare prima eventuali abbuoni/ammanchi.", MsgBoxStyle.Information, Globale.TitoloApp)
            Exit Sub
        End If

        Try
            Dim CodiceCassa As String = IIf(cboCassa.SelectedIndex = 0, "00", cboCassa.Text)
            'controllo esistenza quadratura
            Dim Query As String = $"SELECT Count(*) 
                FROM Quadrature 
                WHERE Data = '{dtpGiorno.Value:dd/MM/yyyy}' AND 
                PuntoVendita = {CodicePvSelezionato(cboPuntoVendita)} AND 
                CodiceCassa = '{CodiceCassa}'"

            If Utx.WsCommand.ExecuteScalar(Query).Valore > 0 Then
                If MsgBox("La quadratura è stata già registrata: volete sostituirla?",
                          MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question,
                          "Quadratura") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            Query = $"DELETE 
                FROM Quadrature 
                WHERE Data = '{dtpGiorno.Value:dd/MM/yyyy}' AND 
                PuntoVendita = {CodicePvSelezionato(cboPuntoVendita)} AND 
                CodiceCassa = '{CodiceCassa}'"
            Utx.WsCommand.ExecuteNonQueryRecord(Query)

            'salva quadratura
            Dim QueryIns As New Utx.NetFunc.StringFormatter("INSERT INTO Quadrature 
                (Data,PuntoVendita,CodiceCassa,B500,B200,B100,B50,B20,B10,B5,Moneta,NumeroAssegni,TotaleAssegni) 
                VALUES (@data,@pv,@cassa,@500=,@200=,@100=,@50=,@20=,@10=,@5=,@moneta,@assegni,@totaleassegni)")

            With QueryIns
                .Parametro("@data", Format(dtpGiorno.Value, "dd/MM/yyyy"), True)
                .Parametro("@pv", CodicePvSelezionato(cboPuntoVendita))
                .Parametro("@cassa", IIf(cboCassa.SelectedIndex = 0, "00", cboCassa.Text), True)
                .Parametro("@500=", txt500.Text)
                .Parametro("@200=", txt200.Text)
                .Parametro("@100=", txt100.Text)
                .Parametro("@50=", txt50.Text)
                .Parametro("@20=", txt20.Text)
                .Parametro("@10=", txt10.Text)
                .Parametro("@5=", txt5.Text)
                .Parametro("@moneta", txtMonetaTot.Text)
                .Parametro("@assegni", txtNumeroAssegni.Text)
                .Parametro("@totaleassegni", cboAssegnoTot.Text)
            End With
            Utx.WsCommand.ExecuteNonQueryRecord(QueryIns.StringaFormattata)

            MsgBox($"La quadratura giornaliera del {dtpGiorno.Value:dd/MM/yyyy} è stata salvata.", MsgBoxStyle.Information, "Cassa")

            LeggiQuadrature()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub cboPuntoVendita_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPuntoVendita.SelectedIndexChanged

        Try
            If cboPuntoVendita.SelectedIndex > 0 Then
                If NumeroLegami() = 0 Then
                    MsgBox("Impostare prima i legami Punto vendita >> Codici cassa" + vbNewLine +
                           "per il codice " + cboPuntoVendita.Text, MsgBoxStyle.Exclamation)

                    btnGestioneCodici_Click(Me, New System.EventArgs)
                End If
            End If

            btnAbbuono.Enabled = (cboPuntoVendita.SelectedIndex > 0)
            btnAmmanco.Enabled = (cboPuntoVendita.SelectedIndex > 0)

            If cboPuntoVendita.SelectedIndex = 0 Then
                btnSalvaQuadratura.Text = "Seleziona un punto vendita per la quadratura"
                btnSalvaQuadratura.Enabled = False
            Else
                btnSalvaQuadratura.Text = $"Salva quadratura punto vendita {CodicePvSelezionato(cboPuntoVendita)}"
                btnSalvaQuadratura.Enabled = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function NumeroLegami() As Integer
        Try
            Dim Query As String = $"Select COUNT(*) 
                FROM Legami 
                WHERE CodicePrincipale = {CodicePvSelezionato(cboPuntoVendita)}"

            NumeroLegami = Utx.WsCommand.ExecuteScalar(Query).Valore

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Function

    Private Sub TabCassa_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TabCassa.SelectedIndexChanged
        txtTrova.Enabled = (TabCassa.SelectedIndex = 0)
        AggiornaTab()
    End Sub

    Private Sub Statistiche()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim Query As String = "SELECT C.PuntoVendita,C.TipoPagamento,P.Desk,Count(*) AS Nr,SUM(TotaleTitolo) AS Premi,0.001 AS Media 
                FROM ChiusuraCassa AS C 
                INNER JOIN DB00000.dbo.Pagamento AS P ON C.TipoPagamento = P.TipoPagamento 
                WHERE TipoRecord = 0 
                GROUP BY C.PuntoVendita,C.TipoPagamento,P.Desk 
                ORDER BY C.PuntoVendita,C.TipoPagamento"

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            For Each dr As DataRow In dt.Rows
                If dr("Nr") > 0 Then
                    dr("Media") = dr("Premi") / dr("Nr")
                Else
                    dr("Media") = 0
                End If
            Next

            With dgvStat
                .DataSource = dt
                .AutoResizeColumns()
            End With

            FormattaStat()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub FormattaStat()
        On Error Resume Next

        With dgvStat
            .SuspendLayout()

            'intestazioni delle colonne
            .Columns("PuntoVendita").HeaderText = "Pv"
            .Columns("TipoPagamento").HeaderText = "Tipo pagamento"
            .Columns("Desk").HeaderText = "Descrizione"
            .Columns("Nr").HeaderText = "Numero Operazioni"

            '.Columns("SubAgenzia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Premi").DefaultCellStyle.Format = Globale.FValuta
            .Columns("Premi").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TipoPagamento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Nr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Media").DefaultCellStyle.Format = Globale.FValuta
            .Columns("Media").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .AutoResizeColumns()
        End With
    End Sub

    Private Sub dgvStat_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvStat.CellFormatting
        If dgvStat.Rows.Count = 0 Then Exit Sub
        If e.ColumnIndex = 0 Then
            If (e.RowIndex Mod 2) = 0 Then dgvStat.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Beige
        End If
    End Sub

    Private Sub dgvElenco_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvElenco.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right And dgvElenco.Rows.Count > 0 Then

            'Recupero l'index della riga in corrispondenza della posizione del puntatore
            Dim rowindex As Integer = dgvElenco.HitTest(e.X, e.Y).RowIndex
            'seleziono la riga
            dgvElenco.Rows(rowindex).Cells(0).Selected = True

            cm.Items("PuntoVendita").Enabled = True
            cm.Items("Cancella").Enabled = True

            For Each r As DataGridViewRow In dgvElenco.SelectedRows
                cm.Items("PuntoVendita").Enabled = cm.Items("PuntoVendita").Enabled And
                                                   (r.Cells("TipoRecord").Value = Globale.TipoRecord.Essig)
                cm.Items("Cancella").Enabled = cm.Items("Cancella").Enabled And
                                               (r.Cells("TipoRecord").Value > Globale.TipoRecord.Essig)
            Next

            If cm.Items("Cancella").Enabled Then
                cm.Items("Cancella").Text = "Cancella movimento"
            Else
                cm.Items("Cancella").Text = "Cancellazione non consentita"
            End If

            'movimenti misti
            If dgvElenco.SelectedRows.Count > 1 Then
                cm.Items("Misto").Enabled = False
            Else
                cm.Items("Misto").Enabled = (dgvElenco.CurrentRow.Cells("TipoPagamento").Value = "M")
            End If
        End If

    End Sub

    Private Sub cm_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cm.ItemClicked

        cm.Close()

        Select Case e.ClickedItem.Name
            Case "PuntoVendita" : CambiaPuntoVendita()
            Case "Misto" : AggiungiMovimento(True)
            Case "Cancella"
                If cm.Items("Cancella").Enabled Then
                    CancellaMovimento()
                    LeggiElenco()
                End If
        End Select
    End Sub

    Private Sub CambiaPuntoVendita()

        If EsisteChiusura(dtpGiorno.Value) Then
            MsgBox("Impossibile modificare il movimento: giornata già consolidata.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Try
            Using f As New frmPuntoIncasso
                f.ShowDialog()

                If f.cboPuntoVendita.SelectedIndex = 0 Then Exit Sub

                For Each r As DataGridViewRow In dgvElenco.SelectedRows

                    'controllo sul tipo di riga: se da essig ok posso cambiare
                    If r.Cells("TipoRecord").Value = Globale.TipoRecord.Essig Then
                        Dim Query As String = $"UPDATE ChiusuraCassa 
                        SET PuntoVendita = {CodicePvSelezionato(f.cboPuntoVendita)} 
                        WHERE Protocollo = {r.Cells("Protocollo").Value}"

                        Utx.WsCommand.ExecuteNonQueryRecord(Query)
                    End If
                Next
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            LeggiElenco()
        End Try
    End Sub

    Private Sub dgvElenco_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvElenco.SelectionChanged
        Dim th As New Threading.Thread(Sub()
                                           SommaSelezionati(dgvElenco)
                                       End Sub)
        th.Start()
    End Sub

    Private Sub dgvRecuperi_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvRecuperi.SelectionChanged
        Dim th As New Threading.Thread(Sub()
                                           SommaSelezionati(dgvRecuperi)
                                       End Sub)
        th.Start()
    End Sub

    Private Sub btnGestioneCodici_Click(sender As System.Object, e As System.EventArgs) Handles btnGestioneCodici.Click

        Using f As New frmCodiciSub
            f.ShowDialog()
        End Using

        AbbinamentoPuntiVendita()
        ImpostaPuntoVendita(cboPuntoVendita, "Tutti")
        AggiornaTab()
    End Sub

    Private Sub btnAggiorna_Click(sender As System.Object, e As System.EventArgs) Handles btnAggiorna.Click

        dgvElenco.DataSource = Nothing

        'data inizio importazione
        Dim InizioImportazione As Date = UltimaChiusura()

        If InizioImportazione = Nothing Then

            Dim Tmp As String = InputBox("Chiusura cassa dal (gg/mm/aaaa):", Utx.Globale.TitoloApp, Now.ToShortDateString)

            'controllo la data inserita
            If String.IsNullOrEmpty(Tmp) Then Exit Sub 'nel caso premo annulla

            If IsDate(Tmp) Then
                InizioImportazione = CDate(Tmp)
            Else
                MsgBox("La data inserita è errata", MsgBoxStyle.Exclamation, Globale.TitoloApp)
                Exit Sub
            End If

            'data minima
            InizioImportazione = Today.AddDays(-1)

            If MsgBox($"Desiderate eliminare eventuali archivi precedenti e iniziare dal {InizioImportazione:dd/MM/yyyy} con la chiusura cassa?",
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Globale.TitoloApp) = MsgBoxResult.No Then
                Exit Sub
            End If

            CancellaDatiCassa(InizioImportazione.AddDays(-1))
        End If

        If InizioImportazione > Today Then
            MsgBox($"E' già presente la chiusura del {Today:dd/MM/yyyy}.", MsgBoxStyle.Information, Globale.TitoloApp)
            Exit Sub
        End If

        'verifico i codici da scaricare
        Dim CodiciSub As String = CodiciSubDaScaricare()

        If CodiciSub.StartsWith("-ERR") Then
            MsgBox("Sede non configurata per lo scarico dati.", MsgBoxStyle.Information, Globale.TitoloApp)
        Else
            Notifica = New Utx.FormNotifica()
            With Notifica
                .ColoreSfondo = Drawing.Color.Yellow
                .Opacity = 0.9
                .Text = ""
                .Show()

                .Messaggio = "Login in corso..."
            End With

            Login = New Utx.AutenticazioneEssig
            Login.LogIn()

            If Login.IsLogged Then
                Importa = New ExportLib.Export(Utx.Globale.AgenziaRichiesta.CodiceAgenzia)

                'aggancio l'evento che notifica la data attualmente in importazione
                AddHandler Importa.StatoImportazione, AddressOf CambiaStatoImportazione

                Importa.AggiornaCassa(InizioImportazione, Today, CodiciSub)
                Importa = Nothing

                Notifica.Messaggio = "Abbinamento punti vendita..."
                AbbinamentoPuntiVendita()
            End If

            Notifica.Chiudi(1)
        End If

        ImpostaCassa(cboCassa, "Tutte")
        LeggiElenco()
    End Sub

    Private Sub CambiaStatoImportazione(e As ExportLib.ExportEventArgs)
        Notifica.Messaggio = $"Agenzia {e.AgenziaFiglia}{Environment.NewLine}Importazione del {e.InizioPeriodo:dd/MM/yyyy}"
    End Sub

    Private Sub btnAbbuono_Click(sender As System.Object, e As System.EventArgs) Handles btnAbbuono.Click
        SalvaDifferenza(Globale.TipoRecord.Abbuono)
        txtTotaleTitoli.Text = Format(SaldoCassa(), Globale.FValuta)
    End Sub

    Private Sub SalvaDifferenza(Tipo As Globale.TipoRecord)

        If CDbl(txtQuadratura.Text) = 0 Then Exit Sub

        Try
            Dim Query As New Utx.NetFunc.StringFormatter("INSERT INTO ChiusuraCassa 
                (TipoRecord,Id,Sezione,Segno,Ramo,Polizza,Esito,TipoPagamento,DataEsito,CodiceCassa,
                Contraente,PuntoVendita,TotaleTitolo,TipoMovimento,Spunta) 
                VALUES (@tipo,@id,@sezione,@segno,0,0,@esito,'C',@data,'00',
                @desk,@pv,@importo,@desk,'N')")

            Dim IdTrans As String = IDTransazione()

            With Query
                .Parametro("@tipo", Tipo)
                .Parametro("@id", IdTrans, True)
                .Parametro("@sezione", "CA", True)
                .Parametro("@segno", IIf(txtQuadratura.Text >= 0, "E", "U"), True)
                .Parametro("@esito", IIf(Tipo = Globale.TipoRecord.Abbuono, "AB", "AM"), True)
                .Parametro("@data", Format(dtpGiorno.Value, "dd/MM/yyyy"), True)
                .Parametro("@desk", IIf(Tipo = Globale.TipoRecord.Abbuono, "ABBUONO", "AMMANCO"), True)
                .Parametro("@pv", CodicePvSelezionato(cboPuntoVendita))
                .Parametro("@importo", txtQuadratura.Text)
            End With
            Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub btnAmmanco_Click(sender As System.Object, e As System.EventArgs) Handles btnAmmanco.Click
        SalvaDifferenza(Globale.TipoRecord.Ammanco)
        txtTotaleTitoli.Text = Format(SaldoCassa(), Globale.FValuta)
    End Sub

    Private Sub txtTrova_TextChanged(sender As Object, e As System.EventArgs) Handles txtTrova.TextChanged
        LeggiElenco()
        txtTrova.Focus()
    End Sub

    Private Sub ModificaSpunta()
        Try
            Dim Query As String = ""

            For Each r As DataGridViewRow In dgvElenco.SelectedRows

                If r.Cells("TipoRecord").Value = Globale.TipoRecord.Essig Then

                    Select Case r.Cells("Ok").Value
                        Case "F"
                            'FEA non fare niente
                        Case "N"
                            r.Cells("Ok").Style.BackColor = Color.Gold
                            r.Cells("Ok").Value = "S"
                        Case "S"
                            r.Cells("Ok").Style.BackColor = dgvElenco.DefaultCellStyle.BackColor
                            r.Cells("Ok").Value = "N"
                    End Select

                    If r.Cells("Ok").Value <> "F" Then
                        Query &= $"UPDATE ChiusuraCassa 
                            SET Spunta = '{r.Cells("Ok").Value}' 
                            WHERE Protocollo = {r.Cells("Protocollo").Value}{Environment.NewLine}"
                    End If
                End If
            Next

            If String.IsNullOrEmpty(Query) = False Then
                Utx.WsCommand.ExecuteNonQueryRecord(Query)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ModificaDecadeDocumentazione(ByRef dr As DataGridViewRow)
        Try
            With dr
                If .Cells("TipoRecord").Value = Globale.TipoRecord.Essig Then

                    Dim Query As String = $"UPDATE ChiusuraCassa 
                        SET DecadeDoc = '{ .Cells("DecadeDoc").Value:dd/MM/yyyy}' 
                        WHERE Protocollo = { .Cells("Protocollo").Value}"

                    Utx.WsCommand.ExecuteNonQueryRecord(Query)

                    'modifica il colore della cella
                    If .Cells("DecadeDoc").Value Is DBNull.Value Then
                        .Cells("Doc").Style.BackColor = dgvElenco.DefaultCellStyle.BackColor
                    Else
                        .Cells("Doc").Style.BackColor = Color.YellowGreen
                    End If
                End If
            End With

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub Esporta2Excel(dgv As DataGridView,
                              NomeFoglio As String,
                              NomeFile As String)

        'seleziono il nome file
        Dim cd As New SaveFileDialog
        With cd
            .AddExtension = True
            .DefaultExt = "xls"
            .OverwritePrompt = False
            .Filter = "*.xls|*.xls"
            .FileName = NomeFile.Trim + "." + .DefaultExt

            If .ShowDialog(Me) = DialogResult.Cancel Then Exit Sub
        End With

        Me.Cursor = Cursors.WaitCursor

        ProgressBar1.Visible = True
        lbProgress.Text = "Esportazione in corso..."

        Application.DoEvents()

        Dim excelApp As New Excel.Application
        Dim excelBook As Excel.Workbook = excelApp.Workbooks.Add

        Try
            Dim NumFoglio As Integer = 1
            For Each w As Excel.Worksheet In excelBook.Worksheets
                w.Name = "xxx" + NumFoglio.ToString 'da cancellare dopo altrimenti va in errore
                NumFoglio += NumFoglio
            Next
        Catch ex As Exception
        End Try

        Dim ws As Excel.Worksheet = excelBook.Worksheets.Add()

        Try
            Dim StileTitoli As Excel.Style
            StileTitoli = excelBook.Styles.Add("STitoli")
            With StileTitoli
                .WrapText = True
                .Font.Bold = True
                .Orientation = Excel.XlOrientation.xlUpward
                .VerticalAlignment = Excel.XlVAlign.xlVAlignBottom
            End With

            Try
                With ws
                    .Name = NomeFoglio

                    'inserisce riga di intestazione

                    'stile intestazione
                    .Range("1:1").Style = StileTitoli

                    Dim i As Int16 = 1 'contatore di riga
                    Dim k As Int16 = 1 'contatore di colonna 
                    Dim IdCella, IdColonna, CarColonna As String

                    For Each col As DataGridViewColumn In dgv.Columns
                        If col.Visible Then
                            CarColonna = ColonnaStileExcel(k)
                            IdColonna = CarColonna + "2:" + CarColonna + "100"
                            IdCella = CarColonna + i.ToString

                            With .Range(IdCella)
                                .Value = col.HeaderText
                                .Interior.Color = Excel.XlRgbColor.rgbPaleGreen
                            End With

                            'allineamento
                            With .Range(IdColonna)
                                Select Case col.DefaultCellStyle.Alignment
                                    Case DataGridViewContentAlignment.MiddleLeft
                                        .HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                                    Case DataGridViewContentAlignment.MiddleCenter
                                        .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    Case DataGridViewContentAlignment.MiddleRight
                                        .HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                End Select
                            End With

                            k += 1
                        End If
                    Next

                    With ProgressBar1
                        .Minimum = 0
                        .Maximum = dgv.Rows.Count + 1
                        .Value = 0
                    End With

                    'inserisco i dati iterando per righe (i) e colonne (k)
                    'il contatore parte dalla seconda riga, dopo le intestazioni di colonna
                    i = 2
                    For Each r As DataGridViewRow In dgv.Rows

                        ProgressBar1.Value = i

                        k = 1

                        For Each c As DataGridViewCell In r.Cells
                            If c.Visible Then
                                IdCella = ColonnaStileExcel(k) + i.ToString

                                'formattazione celle testo------------------------
                                'If c.Value.GetType.Name = "String" Then
                                '    .Range(IdCella).NumberFormat = "@"
                                '    .Range(IdCella).Value = c.FormattedValue
                                'Else
                                '    .Range(IdCella).Value = c.FormattedValue
                                'End If
                                '-------------------------------------------------

                                If c.Value.GetType.Name = "Double" Then
                                    .Range(IdCella).NumberFormat = "###.##0,00"
                                End If

                                .Range(IdCella).Value = c.FormattedValue

                                'imposta sfondo
                                If Not c.Style.BackColor.IsEmpty Then
                                    .Range(IdCella).Interior.Color = RGB(c.Style.BackColor.R,
                                                                         c.Style.BackColor.G,
                                                                         c.Style.BackColor.B)
                                End If

                                k += 1
                            End If
                        Next

                        i += 1
                    Next

                    .Columns.EntireColumn.AutoFit() 'auto resize colonne
                End With

                Try
                    For Each w As Excel.Worksheet In excelBook.Worksheets
                        If w.Name.Substring(0, 3) = "xxx" Then w.Delete()
                    Next
                Catch ex As Exception
                End Try

                'seleziona il primo foglio come attivo
                Dim PrimoFoglio As Excel.Worksheet = excelBook.Worksheets.Item(1)
                PrimoFoglio.Select()

                'salvo il file
                excelBook.SaveAs(cd.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel7)
                'notifico il salvataggio all'utente
                If excelBook.Saved Then
                    MsgBox("Esportazione in formato excel conclusa correttamente.", MsgBoxStyle.Information)
                End If

            Catch ex As Exception
                'errore 1004 quando il file esiste e si risponde NO alla sostituzione
                If Err.Number <> 1004 Then Globale.Log.Errore(ex)
                excelBook.Saved = True
            End Try

        Catch ex As Exception
            'non fare niente
        Finally
            excelBook.Close()
            If excelApp.Ready Then excelApp.Quit()

            Me.Cursor = Cursors.Arrow
            ProgressBar1.Visible = False
            lbProgress.Text = ""

            Me.Focus()
        End Try

    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Select Case TabCassa.SelectedTab.Name
            Case "TabElenco"
                If dgvElenco.RowCount > 0 Then
                    Esporta2Excel(dgvElenco, "Movimenti", $"Movimenti (PV {cboPuntoVendita.Text}) del {Now:dd-MM-yyyy}")
                End If

            Case "TabCO"
                If dgvRecuperi.RowCount > 0 Then
                    Esporta2Excel(dgvRecuperi, "Recuperi", $"Recuperi (PV {cboPuntoVendita.Text}) del {Now:dd-MM-yyyy}")
                End If
        End Select
    End Sub

    Private Sub MovimentoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MovimentoToolStripMenuItem.Click
        AggiungiMovimento()
    End Sub

    Private Sub AggiungiMovimento(Optional Misto As Boolean = False)

        If EsisteChiusura(dtpGiorno.Value) Then
            MsgBox("Impossibile aggiungere il movimento: giornata già consolidata.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim f As New frmMovimento
        With f
            .MaximizeBox = False
            .MinimizeBox = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.CenterScreen

            .Giorno = CDate(dtpGiorno.Value)
            .Misto = Misto

            If Misto Then .dr = dgvElenco.CurrentRow

            .ShowDialog()
        End With

        AggiornaTab()
    End Sub

    Private Sub SommaSelezionati(ByRef dgv As DataGridView)
        Dim Totale As Double = 0
        Try
            For Each r As DataGridViewRow In dgv.SelectedRows
                Totale += r.Cells("TotaleTitolo").Value
            Next
        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try

        lbSelezionati.Text = $"Selezionati: {dgv.SelectedRows.Count.ToString}"
        lbSomma.Text = $"Somma: {Totale:###,###,##0.00}"

        If dgv.SelectedRows.Count > 0 Then
            lbMedia.Text = $"Media: {Totale / dgv.SelectedRows.Count:###,###,##0.00}"
        End If
    End Sub

    Private Function MovimentiExtra() As Integer
        'numero dei movimenti extra-assicurativi
        Try
            Dim Query As String = $"SELECT Count(*) 
                FROM ChiusuraCassa 
                WHERE {ImpostaClausolaWhere()} AND LEN(TRIM(TipoMovimento)) > 0"

            Return Utx.WsCommand.ExecuteScalar(Query).Valore

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Function

    Private Sub dgvDettaglio_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvDettaglio.SelectionChanged
        LeggiDettaglioTipoPagamento()
    End Sub

    Private Sub AbbinamentoPuntiVendita()
        Try
            Cursor.Current = Cursors.WaitCursor

            'codici sub
            If Utx.WsCommand.ExecuteScalar("SELECT Count(*) FROM PuntiVendita").Valore > 0 Then

                Dim DataChiusura As Date = UltimaChiusura()
                If DataChiusura = Nothing Then
                    DataChiusura = #1/1/2000#
                End If

                Dim Query As String = $"UPDATE C
                    SET PuntoVendita = l.CodicePrincipale 
                    FROM ChiusuraCassa AS C 
                    INNER JOIN Legami AS L on C.SubAgenzia = L.CodiceLegato 
                    WHERE DataEsito >= '{DataChiusura:dd/MM/yyyy}' AND 
                    (PuntoVendita < 1 OR PuntoVendita IS NULL)"
                Utx.WsCommand.ExecuteNonQueryRecord(Query)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ' Configures the autogenerated columns, replacing their header
    ' cells with AutoFilter header cells. 
    'Private Sub dgvElenco_BindingContextChanged(sender As Object, _
    '    e As EventArgs) Handles dgvElenco.BindingContextChanged

    '    ' Continue only if the data source has been set.
    '    If dgvElenco.DataSource Is Nothing Then Return

    '    ' Add the AutoFilter header cell to each column.
    '    For Each col As DataGridViewColumn In dgvElenco.Columns
    '        col.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
    '    Next

    '    ' Format the OrderTotal column as currency. 
    '    'dgvElenco.Columns("OrderTotal").DefaultCellStyle.Format = "c"

    '    ' Resize the columns to fit their contents.
    '    dgvElenco.AutoResizeColumns()

    'End Sub

    Private Function EsistonoStampati(ByRef r As DataRow) As Boolean
        Try
            'il tipo record deve stare per primo
            If r("TipoRecord") <> Globale.TipoRecord.Essig Then Return False
            If Not "1/2/3/6/9".Contains(r("TipoCarico")) Then Return False
            If "IC/IS".Contains(r("Esito")) Then Return False
            If Not String.IsNullOrEmpty(r("TipoMovimento")) Then Return False

            Return True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Globale.TitoloApp)
            Return False
        End Try
    End Function

    Private Sub dgvElenco_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvElenco.CellFormatting

        If TabCassa.SelectedTab.Name <> "TabElenco" Then Exit Sub

        Select Case dgvElenco.Columns(e.ColumnIndex).Name
            Case "Ok" 'spunta
                Select Case e.Value
                    Case "S" : e.CellStyle.BackColor = Colori.OK
                    Case "F" : e.CellStyle.BackColor = Colori.FEA
                End Select

            Case "Doc"
                If dgvElenco.Rows(e.RowIndex).Cells("Stampati").Value = "S" Then
                    If dgvElenco.Rows(e.RowIndex).Cells("DecadeDoc").Value Is DBNull.Value Then
                        e.CellStyle.BackColor = Color.Red
                    Else
                        e.CellStyle.BackColor = Color.YellowGreen
                    End If
                Else
                    e.CellStyle.BackColor = Color.Gainsboro
                End If

            Case "Esito" 'esito
                Select Case e.Value
                    Case "IC" : e.CellStyle.BackColor = Colori.EsitoIC
                    Case "IS" : e.CellStyle.BackColor = Colori.EsitoIS
                    Case "RP" : e.CellStyle.BackColor = Colori.RP
                    Case "PR" : e.CellStyle.BackColor = Colori.PR
                    Case "VE" : e.CellStyle.BackColor = Colori.VE
                End Select

            Case "TipoMovimento"
                If IsDBNull(e.Value) = False Then
                    If e.Value = "CANONE" Then e.CellStyle.BackColor = Color.Gainsboro
                End If

            Case "TotaleTitolo"
                If e.Value < 0 Then
                    e.CellStyle.BackColor = Colori.Uscite
                End If

            Case "Segno"
                If e.Value = "Usc" Then
                    e.CellStyle.BackColor = Colori.Uscite
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If

            Case "Sezione"
                If IsDBNull(e.Value) = False Then
                    Select Case e.Value
                        Case "CA" : e.CellStyle.BackColor = Colori.Cassetto
                        Case "BA" : e.CellStyle.BackColor = Colori.Banca
                        Case "CO" : e.CellStyle.BackColor = Colori.CO
                        Case "SC" : e.CellStyle.BackColor = Colori.Scoperti
                        Case "DR" : e.CellStyle.BackColor = Colori.Direzione
                    End Select
                End If
        End Select
    End Sub

    Private Sub dgvElenco_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvElenco.MouseDoubleClick
        ModificaSpunta()
    End Sub

    Private Sub TabHelp_Enter(sender As Object, e As System.EventArgs) Handles TabHelp.Enter

        Static Letto As Boolean

        If Letto = False Then
            wbHelp.Navigate("http://www.utools.it/Unitools/Help/ChiusuraCassa/Cassa.htm", False)
            Letto = True
        End If

    End Sub

    Private Sub dgvQuadrature_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvQuadrature.MouseDoubleClick

        On Error Resume Next

        dtpGiorno.Value = dgvQuadrature.CurrentRow.Cells("Data").Value

        For k As Integer = 0 To cboPuntoVendita.Items.Count - 1
            If dgvQuadrature.CurrentRow.Cells("PuntoVendita").Value = cboPuntoVendita.Items(k).Codice Then
                cboPuntoVendita.SelectedIndex = k
                Exit For
            End If
        Next

    End Sub

    Private Sub DecadeBD()
        Try
            Dim I1, F1, I2, F2 As Date 'inizio e fine decade corrente (2) e precedente (1)

            F2 = dtpGiorno.Value

            Select Case Today.Day
                Case <= 10
                    I2 = New Date(F2.Year, F2.Month, 1)
                    F1 = I2.AddDays(-1)
                    I1 = New Date(F1.Year, F1.Month, 20)
                Case <= 20
                    I2 = New Date(F2.Year, F2.Month, 11)
                    F1 = I2.AddDays(-1)
                    I1 = New Date(F1.Year, F1.Month, 1)
                Case Else
                    I2 = New Date(F2.Year, F2.Month, 21)
                    F1 = I2.AddDays(-1)
                    I1 = New Date(F1.Year, F1.Month, 11)
            End Select

            Dim Risposta As Utx.ServiziOMW.Risposta

            Dim Query As String = $"SELECT SUM(TotaleTitolo) AS TotaleDecade 
                FROM ChiusuraCassa
                WHERE DataEsito BETWEEN '{I1:dd/MM/yyyy}' AND '{F1:dd/MM/yyyy}' AND TipoPagamento = 'Y'"

            Risposta = Utx.WsCommand.ExecuteScalar(Query, ValoreDefault:=0)
            Dim TotaleDecadePrecedente As Single = 0
            If Risposta.Valore IsNot DBNull.Value Then
                TotaleDecadePrecedente = Risposta.Valore
            End If

            Query = $"SELECT SUM(TotaleTitolo) AS TotaleDecade 
                FROM ChiusuraCassa
                WHERE DataEsito BETWEEN '{I2:dd/MM/yyyy}' AND '{F2:dd/MM/yyyy}' AND TipoPagamento = 'Y'"

            Risposta = Utx.WsCommand.ExecuteScalar(Query, ValoreDefault:=0)
            Dim TotaleDecadeCorrente As Single = 0
            If Risposta.Valore IsNot DBNull.Value Then
                TotaleDecadeCorrente = Risposta.Valore
            End If

            MsgBox($"Totale sezione BD decade al {F1:dd/MM/yyyy}: {TotaleDecadePrecedente:#,###,##0.00 euro}{Environment.NewLine}" +
                   $"Totale sezione BD decade al {F2:dd/MM/yyyy}: {TotaleDecadeCorrente:#,###,##0.00} euro", MsgBoxStyle.Information, Utx.Globale.TitoloApp)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub Totali(ByRef dt As DataTable)
        Try
            Entrate = 0 : Uscite = 0
            For Each row As DataRow In dt.Rows
                If row("TotaleTitolo") >= 0 Then
                    Entrate += row("TotaleTitolo")
                Else
                    Uscite += row("TotaleTitolo")
                End If
            Next
        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            lbEntrate.Text = $"Entrate sezione: {Entrate:###,###,##0.00}"
            lbUscite.Text = $"Uscite sezione: {Uscite:###,###,##0.00}"
            lbSaldo.Text = $"Saldo sezione: {Entrate + Uscite:###,###,##0.00}"
        End Try
    End Sub
End Class
