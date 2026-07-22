<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMainKMS
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.Elenco = New System.Windows.Forms.TabPage()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.SplitMain = New System.Windows.Forms.SplitContainer()
        Me.SplitPannello = New System.Windows.Forms.SplitContainer()
        Me.TabQuietanze = New Utx.UtTabControl()
        Me.Statistiche = New System.Windows.Forms.TabPage()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripPbStat = New System.Windows.Forms.ToolStripProgressBar()
        Me.TabStat = New Utx.UtTabControl()
        Me.TabStat1 = New System.Windows.Forms.TabPage()
        Me.dgvStat = New System.Windows.Forms.DataGridView()
        Me.lbDeskStatistiche = New System.Windows.Forms.Label()
        Me.TabStat2 = New System.Windows.Forms.TabPage()
        Me.dgvStat2 = New System.Windows.Forms.DataGridView()
        Me.Legenda = New System.Windows.Forms.TabPage()
        Me.btnIndice = New System.Windows.Forms.Button()
        Me.wbLegenda = New System.Windows.Forms.WebBrowser()
        Me.lvDettaglio = New System.Windows.Forms.ListView()
        Me.gbDettaglio = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbTasse = New System.Windows.Forms.Label()
        Me.lbConvenzione = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtTotaleRata = New System.Windows.Forms.TextBox()
        Me.txtUnibox = New System.Windows.Forms.TextBox()
        Me.txtArd = New System.Windows.Forms.TextBox()
        Me.txtRca = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRca2 = New System.Windows.Forms.TextBox()
        Me.txtArd2 = New System.Windows.Forms.TextBox()
        Me.txtUnibox2 = New System.Windows.Forms.TextBox()
        Me.txtTotaleRata2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtRcaOld = New System.Windows.Forms.TextBox()
        Me.txtArdOld = New System.Windows.Forms.TextBox()
        Me.txtUniboxOld = New System.Windows.Forms.TextBox()
        Me.txtTotaleRataOld = New System.Windows.Forms.TextBox()
        Me.txtFlexOld = New System.Windows.Forms.TextBox()
        Me.txtIFOld = New System.Windows.Forms.TextBox()
        Me.txtIF = New System.Windows.Forms.TextBox()
        Me.txtIF2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtFlexRcaPerc = New System.Windows.Forms.TextBox()
        Me.txtFlexRcaImporto = New System.Windows.Forms.TextBox()
        Me.txtFlexIFPerc = New System.Windows.Forms.TextBox()
        Me.txtFlexIFImporto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnCalcola = New System.Windows.Forms.Button()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtFraz = New System.Windows.Forms.TextBox()
        Me.btnDettaglioArd = New System.Windows.Forms.Button()
        Me.txtSubTotaleRataOld = New System.Windows.Forms.TextBox()
        Me.txtSubTotaleRata = New System.Windows.Forms.TextBox()
        Me.txtSubTotaleRata2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnDettaglioRca = New System.Windows.Forms.Button()
        Me.btnDettaglioIF = New System.Windows.Forms.Button()
        Me.btnDettaglioUnibox = New System.Windows.Forms.Button()
        Me.lbTipoQT = New System.Windows.Forms.Label()
        Me.txtKaskoOld = New System.Windows.Forms.TextBox()
        Me.txtKasko = New System.Windows.Forms.TextBox()
        Me.txtFlexKaskoImporto = New System.Windows.Forms.TextBox()
        Me.txtFSP = New System.Windows.Forms.TextBox()
        Me.txtKasko2 = New System.Windows.Forms.TextBox()
        Me.txtFlexKaskoPerc = New System.Windows.Forms.TextBox()
        Me.btnDettaglioKasko = New System.Windows.Forms.Button()
        Me.lbMessaggio = New System.Windows.Forms.Label()
        Me.lbTipoVeicolo = New System.Windows.Forms.Label()
        Me.txtBonus = New System.Windows.Forms.TextBox()
        Me.gbGenerale = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbPeriodo = New System.Windows.Forms.Label()
        Me.txtFlexUtiRca = New System.Windows.Forms.TextBox()
        Me.txtFlexImpIF = New System.Windows.Forms.TextBox()
        Me.txtFlexUtiIF = New System.Windows.Forms.TextBox()
        Me.txtFlexImpRca = New System.Windows.Forms.TextBox()
        Me.lbFlexTotaleIF = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lbFlexTotaleRca = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtFlexRcaTotale = New System.Windows.Forms.TextBox()
        Me.txtFlexIFTotale = New System.Windows.Forms.TextBox()
        Me.txtCerca = New System.Windows.Forms.TextBox()
        Me.dtpInizio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFine = New System.Windows.Forms.DateTimePicker()
        Me.txtSub = New System.Windows.Forms.TextBox()
        Me.txtProduttore = New System.Windows.Forms.TextBox()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.LinkLabelPannello = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelDettaglio = New System.Windows.Forms.LinkLabel()
        Me.chkNascondiColonne = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboFiltro = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnAnnullaFiltri = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkAutoSize = New System.Windows.Forms.CheckBox()
        Me.chkBloccaColonne = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Elenco.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitMain.Panel1.SuspendLayout()
        Me.SplitMain.Panel2.SuspendLayout()
        Me.SplitMain.SuspendLayout()
        Me.SplitPannello.Panel1.SuspendLayout()
        Me.SplitPannello.Panel2.SuspendLayout()
        Me.SplitPannello.SuspendLayout()
        Me.TabQuietanze.SuspendLayout()
        Me.Statistiche.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabStat.SuspendLayout()
        Me.TabStat1.SuspendLayout()
        CType(Me.dgvStat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabStat2.SuspendLayout()
        CType(Me.dgvStat2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Legenda.SuspendLayout()
        Me.gbDettaglio.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gbGenerale.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Elenco
        '
        Me.Elenco.Controls.Add(Me.ToolStripMain)
        Me.Elenco.Controls.Add(Me.dgv1)
        Me.Elenco.Location = New System.Drawing.Point(4, 29)
        Me.Elenco.Name = "Elenco"
        Me.Elenco.Padding = New System.Windows.Forms.Padding(3)
        Me.Elenco.Size = New System.Drawing.Size(914, 243)
        Me.Elenco.TabIndex = 0
        Me.Elenco.Text = "Elenco"
        Me.Elenco.UseVisualStyleBackColor = True
        '
        'ToolStripMain
        '
        Me.ToolStripMain.BackColor = System.Drawing.Color.Lavender
        Me.ToolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 3)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(908, 25)
        Me.ToolStripMain.TabIndex = 1
        Me.ToolStripMain.Text = "ToolStrip2"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(3, 31)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(908, 209)
        Me.dgv1.TabIndex = 0
        Me.dgv1.TabStop = False
        '
        'SplitMain
        '
        Me.SplitMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitMain.Location = New System.Drawing.Point(12, 109)
        Me.SplitMain.Name = "SplitMain"
        Me.SplitMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitMain.Panel1
        '
        Me.SplitMain.Panel1.Controls.Add(Me.SplitPannello)
        '
        'SplitMain.Panel2
        '
        Me.SplitMain.Panel2.Controls.Add(Me.gbDettaglio)
        Me.SplitMain.Panel2.Controls.Add(Me.gbGenerale)
        Me.SplitMain.Size = New System.Drawing.Size(1313, 620)
        Me.SplitMain.SplitterDistance = 276
        Me.SplitMain.TabIndex = 2
        '
        'SplitPannello
        '
        Me.SplitPannello.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitPannello.Location = New System.Drawing.Point(0, 0)
        Me.SplitPannello.Name = "SplitPannello"
        '
        'SplitPannello.Panel1
        '
        Me.SplitPannello.Panel1.Controls.Add(Me.TabQuietanze)
        '
        'SplitPannello.Panel2
        '
        Me.SplitPannello.Panel2.Controls.Add(Me.lvDettaglio)
        Me.SplitPannello.Size = New System.Drawing.Size(1313, 276)
        Me.SplitPannello.SplitterDistance = 922
        Me.SplitPannello.TabIndex = 0
        '
        'TabQuietanze
        '
        Me.TabQuietanze.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabQuietanze.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
        Me.TabQuietanze.Controls.Add(Me.Elenco)
        Me.TabQuietanze.Controls.Add(Me.Statistiche)
        Me.TabQuietanze.Controls.Add(Me.Legenda)
        Me.TabQuietanze.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabQuietanze.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabQuietanze.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabQuietanze.Location = New System.Drawing.Point(0, 0)
        Me.TabQuietanze.Name = "TabQuietanze"
        Me.TabQuietanze.SelectedIndex = 0
        Me.TabQuietanze.Size = New System.Drawing.Size(922, 276)
        Me.TabQuietanze.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabQuietanze.TabIndex = 13
        Me.TabQuietanze.TabStop = False
        Me.TabQuietanze.Visible = False
        '
        'Statistiche
        '
        Me.Statistiche.BackColor = System.Drawing.Color.Transparent
        Me.Statistiche.Controls.Add(Me.ToolStrip1)
        Me.Statistiche.Controls.Add(Me.TabStat)
        Me.Statistiche.Location = New System.Drawing.Point(4, 29)
        Me.Statistiche.Name = "Statistiche"
        Me.Statistiche.Padding = New System.Windows.Forms.Padding(3)
        Me.Statistiche.Size = New System.Drawing.Size(914, 243)
        Me.Statistiche.TabIndex = 2
        Me.Statistiche.Text = "Statistiche"
        Me.Statistiche.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Orange
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripPbStat})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(908, 25)
        Me.ToolStrip1.TabIndex = 14
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(122, 22)
        Me.ToolStripButton1.Text = "Calcola statistiche"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(107, 22)
        Me.ToolStripButton2.Text = "Nascondi colonne"
        '
        'ToolStripPbStat
        '
        Me.ToolStripPbStat.Name = "ToolStripPbStat"
        Me.ToolStripPbStat.Size = New System.Drawing.Size(100, 22)
        '
        'TabStat
        '
        Me.TabStat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabStat.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabStat.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
        Me.TabStat.Controls.Add(Me.TabStat1)
        Me.TabStat.Controls.Add(Me.TabStat2)
        Me.TabStat.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabStat.Location = New System.Drawing.Point(3, 31)
        Me.TabStat.Name = "TabStat"
        Me.TabStat.SelectedIndex = 0
        Me.TabStat.Size = New System.Drawing.Size(908, 209)
        Me.TabStat.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabStat.TabIndex = 13
        Me.TabStat.Visible = False
        '
        'TabStat1
        '
        Me.TabStat1.Controls.Add(Me.dgvStat)
        Me.TabStat1.Controls.Add(Me.lbDeskStatistiche)
        Me.TabStat1.Location = New System.Drawing.Point(4, 29)
        Me.TabStat1.Name = "TabStat1"
        Me.TabStat1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabStat1.Size = New System.Drawing.Size(900, 176)
        Me.TabStat1.TabIndex = 0
        Me.TabStat1.Text = "Generale"
        Me.TabStat1.UseVisualStyleBackColor = True
        '
        'dgvStat
        '
        Me.dgvStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStat.Location = New System.Drawing.Point(3, 3)
        Me.dgvStat.Name = "dgvStat"
        Me.dgvStat.Size = New System.Drawing.Size(894, 118)
        Me.dgvStat.TabIndex = 1
        '
        'lbDeskStatistiche
        '
        Me.lbDeskStatistiche.BackColor = System.Drawing.Color.Khaki
        Me.lbDeskStatistiche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbDeskStatistiche.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbDeskStatistiche.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDeskStatistiche.Location = New System.Drawing.Point(3, 121)
        Me.lbDeskStatistiche.Name = "lbDeskStatistiche"
        Me.lbDeskStatistiche.Size = New System.Drawing.Size(894, 52)
        Me.lbDeskStatistiche.TabIndex = 12
        Me.lbDeskStatistiche.Text = "Label28"
        Me.lbDeskStatistiche.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabStat2
        '
        Me.TabStat2.Controls.Add(Me.dgvStat2)
        Me.TabStat2.Location = New System.Drawing.Point(4, 29)
        Me.TabStat2.Name = "TabStat2"
        Me.TabStat2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabStat2.Size = New System.Drawing.Size(782, 176)
        Me.TabStat2.TabIndex = 1
        Me.TabStat2.Text = "Dattaglio Fsp"
        Me.TabStat2.UseVisualStyleBackColor = True
        '
        'dgvStat2
        '
        Me.dgvStat2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStat2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStat2.Location = New System.Drawing.Point(3, 3)
        Me.dgvStat2.Name = "dgvStat2"
        Me.dgvStat2.Size = New System.Drawing.Size(776, 170)
        Me.dgvStat2.TabIndex = 2
        '
        'Legenda
        '
        Me.Legenda.Controls.Add(Me.btnIndice)
        Me.Legenda.Controls.Add(Me.wbLegenda)
        Me.Legenda.Location = New System.Drawing.Point(4, 29)
        Me.Legenda.Name = "Legenda"
        Me.Legenda.Size = New System.Drawing.Size(796, 243)
        Me.Legenda.TabIndex = 1
        Me.Legenda.Text = "Documentazione"
        Me.Legenda.UseVisualStyleBackColor = True
        '
        'btnIndice
        '
        Me.btnIndice.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnIndice.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIndice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnIndice.Location = New System.Drawing.Point(0, 0)
        Me.btnIndice.Name = "btnIndice"
        Me.btnIndice.Size = New System.Drawing.Size(796, 23)
        Me.btnIndice.TabIndex = 1
        Me.btnIndice.Text = "Indice"
        Me.btnIndice.UseVisualStyleBackColor = True
        '
        'wbLegenda
        '
        Me.wbLegenda.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wbLegenda.Location = New System.Drawing.Point(0, 29)
        Me.wbLegenda.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbLegenda.Name = "wbLegenda"
        Me.wbLegenda.Size = New System.Drawing.Size(796, 214)
        Me.wbLegenda.TabIndex = 0
        '
        'lvDettaglio
        '
        Me.lvDettaglio.BackColor = System.Drawing.Color.White
        Me.lvDettaglio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvDettaglio.GridLines = True
        Me.lvDettaglio.Location = New System.Drawing.Point(0, 0)
        Me.lvDettaglio.Name = "lvDettaglio"
        Me.lvDettaglio.Size = New System.Drawing.Size(387, 276)
        Me.lvDettaglio.TabIndex = 1
        Me.lvDettaglio.TabStop = False
        Me.lvDettaglio.UseCompatibleStateImageBehavior = False
        Me.lvDettaglio.View = System.Windows.Forms.View.List
        '
        'gbDettaglio
        '
        Me.gbDettaglio.Controls.Add(Me.TableLayoutPanel1)
        Me.gbDettaglio.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbDettaglio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDettaglio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.gbDettaglio.Location = New System.Drawing.Point(0, 0)
        Me.gbDettaglio.Name = "gbDettaglio"
        Me.gbDettaglio.Size = New System.Drawing.Size(804, 340)
        Me.gbDettaglio.TabIndex = 10
        Me.gbDettaglio.TabStop = False
        Me.gbDettaglio.Text = "Quietanza"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 9
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbTasse, 7, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lbConvenzione, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 5, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label20, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTotaleRata, 2, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUnibox, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtArd, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRca, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRca2, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtArd2, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUnibox2, 3, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTotaleRata2, 3, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRcaOld, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtArdOld, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUniboxOld, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTotaleRataOld, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFlexOld, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.txtIFOld, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtIF, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtIF2, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNote, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFlexRcaPerc, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFlexRcaImporto, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFlexIFPerc, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFlexIFImporto, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCalcola, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSalva, 5, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label25, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFraz, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnDettaglioArd, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSubTotaleRataOld, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSubTotaleRata, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSubTotaleRata2, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label28, 6, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnDettaglioRca, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnDettaglioIF, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnDettaglioUnibox, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lbTipoQT, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtKaskoOld, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtKasko, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFlexKaskoImporto, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFSP, 6, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtKasko2, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFlexKaskoPerc, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnDettaglioKasko, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lbMessaggio, 3, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lbTipoVeicolo, 7, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBonus, 2, 9)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(798, 319)
        Me.TableLayoutPanel1.TabIndex = 12
        '
        'lbTasse
        '
        Me.lbTasse.AutoSize = True
        Me.lbTasse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbTasse, 2)
        Me.lbTasse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbTasse.Location = New System.Drawing.Point(620, 279)
        Me.lbTasse.Name = "lbTasse"
        Me.lbTasse.Size = New System.Drawing.Size(175, 40)
        Me.lbTasse.TabIndex = 66
        Me.lbTasse.Text = "Tasse"
        Me.lbTasse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbConvenzione
        '
        Me.lbConvenzione.AutoSize = True
        Me.lbConvenzione.BackColor = System.Drawing.Color.Moccasin
        Me.lbConvenzione.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbConvenzione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbConvenzione.ForeColor = System.Drawing.Color.DimGray
        Me.lbConvenzione.Location = New System.Drawing.Point(3, 31)
        Me.lbConvenzione.Name = "lbConvenzione"
        Me.lbConvenzione.Size = New System.Drawing.Size(113, 31)
        Me.lbConvenzione.TabIndex = 57
        Me.lbConvenzione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(486, 158)
        Me.Button1.Name = "Button1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Button1, 2)
        Me.Button1.Size = New System.Drawing.Size(85, 56)
        Me.Button1.TabIndex = 41
        Me.Button1.TabStop = False
        Me.Button1.Text = "Calcola importo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Gainsboro
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label20, 2)
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(122, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(176, 31)
        Me.Label20.TabIndex = 40
        Me.Label20.Text = "Quietanze emesse"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotaleRata
        '
        Me.txtTotaleRata.BackColor = System.Drawing.Color.Cornsilk
        Me.txtTotaleRata.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTotaleRata.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotaleRata.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotaleRata.Location = New System.Drawing.Point(213, 251)
        Me.txtTotaleRata.Name = "txtTotaleRata"
        Me.txtTotaleRata.ReadOnly = True
        Me.txtTotaleRata.Size = New System.Drawing.Size(85, 22)
        Me.txtTotaleRata.TabIndex = 11
        Me.txtTotaleRata.TabStop = False
        Me.txtTotaleRata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUnibox
        '
        Me.txtUnibox.BackColor = System.Drawing.Color.Cornsilk
        Me.txtUnibox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUnibox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnibox.Location = New System.Drawing.Point(213, 220)
        Me.txtUnibox.Name = "txtUnibox"
        Me.txtUnibox.ReadOnly = True
        Me.txtUnibox.Size = New System.Drawing.Size(85, 22)
        Me.txtUnibox.TabIndex = 10
        Me.txtUnibox.TabStop = False
        Me.txtUnibox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtArd
        '
        Me.txtArd.BackColor = System.Drawing.Color.Cornsilk
        Me.txtArd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtArd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArd.Location = New System.Drawing.Point(213, 158)
        Me.txtArd.Name = "txtArd"
        Me.txtArd.ReadOnly = True
        Me.txtArd.Size = New System.Drawing.Size(85, 22)
        Me.txtArd.TabIndex = 9
        Me.txtArd.TabStop = False
        Me.txtArd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRca
        '
        Me.txtRca.BackColor = System.Drawing.Color.Cornsilk
        Me.txtRca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRca.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRca.Location = New System.Drawing.Point(213, 65)
        Me.txtRca.Name = "txtRca"
        Me.txtRca.ReadOnly = True
        Me.txtRca.Size = New System.Drawing.Size(85, 22)
        Me.txtRca.TabIndex = 8
        Me.txtRca.TabStop = False
        Me.txtRca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(213, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 31)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Attuale"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(3, 248)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 26)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Totale con Ub"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRca2
        '
        Me.txtRca2.BackColor = System.Drawing.SystemColors.Window
        Me.txtRca2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRca2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRca2.Location = New System.Drawing.Point(304, 65)
        Me.txtRca2.Name = "txtRca2"
        Me.txtRca2.Size = New System.Drawing.Size(85, 22)
        Me.txtRca2.TabIndex = 18
        Me.txtRca2.TabStop = False
        Me.txtRca2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtArd2
        '
        Me.txtArd2.BackColor = System.Drawing.Color.Cornsilk
        Me.txtArd2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtArd2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArd2.Location = New System.Drawing.Point(304, 158)
        Me.txtArd2.Name = "txtArd2"
        Me.txtArd2.ReadOnly = True
        Me.txtArd2.Size = New System.Drawing.Size(85, 22)
        Me.txtArd2.TabIndex = 19
        Me.txtArd2.TabStop = False
        Me.txtArd2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUnibox2
        '
        Me.txtUnibox2.BackColor = System.Drawing.Color.Cornsilk
        Me.txtUnibox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUnibox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnibox2.Location = New System.Drawing.Point(304, 220)
        Me.txtUnibox2.Name = "txtUnibox2"
        Me.txtUnibox2.ReadOnly = True
        Me.txtUnibox2.Size = New System.Drawing.Size(85, 22)
        Me.txtUnibox2.TabIndex = 20
        Me.txtUnibox2.TabStop = False
        Me.txtUnibox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotaleRata2
        '
        Me.txtTotaleRata2.BackColor = System.Drawing.Color.Cornsilk
        Me.txtTotaleRata2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTotaleRata2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotaleRata2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotaleRata2.Location = New System.Drawing.Point(304, 251)
        Me.txtTotaleRata2.Name = "txtTotaleRata2"
        Me.txtTotaleRata2.ReadOnly = True
        Me.txtTotaleRata2.Size = New System.Drawing.Size(85, 22)
        Me.txtTotaleRata2.TabIndex = 21
        Me.txtTotaleRata2.TabStop = False
        Me.txtTotaleRata2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(3, 279)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 26)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Flex %"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(122, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 31)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Precedente"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRcaOld
        '
        Me.txtRcaOld.BackColor = System.Drawing.Color.Cornsilk
        Me.txtRcaOld.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRcaOld.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRcaOld.Location = New System.Drawing.Point(122, 65)
        Me.txtRcaOld.Name = "txtRcaOld"
        Me.txtRcaOld.ReadOnly = True
        Me.txtRcaOld.Size = New System.Drawing.Size(85, 22)
        Me.txtRcaOld.TabIndex = 26
        Me.txtRcaOld.TabStop = False
        Me.txtRcaOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtArdOld
        '
        Me.txtArdOld.BackColor = System.Drawing.Color.Cornsilk
        Me.txtArdOld.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtArdOld.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArdOld.Location = New System.Drawing.Point(122, 158)
        Me.txtArdOld.Name = "txtArdOld"
        Me.txtArdOld.ReadOnly = True
        Me.txtArdOld.Size = New System.Drawing.Size(85, 22)
        Me.txtArdOld.TabIndex = 27
        Me.txtArdOld.TabStop = False
        Me.txtArdOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUniboxOld
        '
        Me.txtUniboxOld.BackColor = System.Drawing.Color.Cornsilk
        Me.txtUniboxOld.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUniboxOld.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUniboxOld.Location = New System.Drawing.Point(122, 220)
        Me.txtUniboxOld.Name = "txtUniboxOld"
        Me.txtUniboxOld.ReadOnly = True
        Me.txtUniboxOld.Size = New System.Drawing.Size(85, 22)
        Me.txtUniboxOld.TabIndex = 28
        Me.txtUniboxOld.TabStop = False
        Me.txtUniboxOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotaleRataOld
        '
        Me.txtTotaleRataOld.BackColor = System.Drawing.Color.Cornsilk
        Me.txtTotaleRataOld.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTotaleRataOld.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotaleRataOld.Location = New System.Drawing.Point(122, 251)
        Me.txtTotaleRataOld.Name = "txtTotaleRataOld"
        Me.txtTotaleRataOld.ReadOnly = True
        Me.txtTotaleRataOld.Size = New System.Drawing.Size(85, 22)
        Me.txtTotaleRataOld.TabIndex = 29
        Me.txtTotaleRataOld.TabStop = False
        Me.txtTotaleRataOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFlexOld
        '
        Me.txtFlexOld.BackColor = System.Drawing.Color.Cornsilk
        Me.txtFlexOld.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFlexOld.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFlexOld.Location = New System.Drawing.Point(122, 282)
        Me.txtFlexOld.Name = "txtFlexOld"
        Me.txtFlexOld.ReadOnly = True
        Me.txtFlexOld.Size = New System.Drawing.Size(85, 22)
        Me.txtFlexOld.TabIndex = 30
        Me.txtFlexOld.TabStop = False
        Me.txtFlexOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIFOld
        '
        Me.txtIFOld.BackColor = System.Drawing.Color.Cornsilk
        Me.txtIFOld.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIFOld.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIFOld.Location = New System.Drawing.Point(122, 96)
        Me.txtIFOld.Name = "txtIFOld"
        Me.txtIFOld.ReadOnly = True
        Me.txtIFOld.Size = New System.Drawing.Size(85, 22)
        Me.txtIFOld.TabIndex = 32
        Me.txtIFOld.TabStop = False
        Me.txtIFOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIF
        '
        Me.txtIF.BackColor = System.Drawing.Color.Cornsilk
        Me.txtIF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIF.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIF.Location = New System.Drawing.Point(213, 96)
        Me.txtIF.Name = "txtIF"
        Me.txtIF.ReadOnly = True
        Me.txtIF.Size = New System.Drawing.Size(85, 22)
        Me.txtIF.TabIndex = 33
        Me.txtIF.TabStop = False
        Me.txtIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIF2
        '
        Me.txtIF2.BackColor = System.Drawing.SystemColors.Window
        Me.txtIF2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIF2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIF2.Location = New System.Drawing.Point(304, 96)
        Me.txtIF2.Name = "txtIF2"
        Me.txtIF2.Size = New System.Drawing.Size(85, 22)
        Me.txtIF2.TabIndex = 34
        Me.txtIF2.TabStop = False
        Me.txtIF2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label12, 2)
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(620, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(175, 31)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Note"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNote
        '
        Me.txtNote.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtNote, 2)
        Me.txtNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(620, 34)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.TableLayoutPanel1.SetRowSpan(Me.txtNote, 7)
        Me.txtNote.Size = New System.Drawing.Size(175, 211)
        Me.txtNote.TabIndex = 2
        Me.txtNote.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(395, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 31)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Flex %"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(486, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 31)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Importo Flex di rata"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFlexRcaPerc
        '
        Me.txtFlexRcaPerc.BackColor = System.Drawing.SystemColors.Window
        Me.txtFlexRcaPerc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFlexRcaPerc.Location = New System.Drawing.Point(395, 65)
        Me.txtFlexRcaPerc.Name = "txtFlexRcaPerc"
        Me.txtFlexRcaPerc.Size = New System.Drawing.Size(85, 22)
        Me.txtFlexRcaPerc.TabIndex = 14
        Me.txtFlexRcaPerc.TabStop = False
        Me.txtFlexRcaPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFlexRcaImporto
        '
        Me.txtFlexRcaImporto.BackColor = System.Drawing.Color.Cornsilk
        Me.txtFlexRcaImporto.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtFlexRcaImporto.Location = New System.Drawing.Point(486, 65)
        Me.txtFlexRcaImporto.Name = "txtFlexRcaImporto"
        Me.txtFlexRcaImporto.ReadOnly = True
        Me.txtFlexRcaImporto.Size = New System.Drawing.Size(85, 22)
        Me.txtFlexRcaImporto.TabIndex = 15
        Me.txtFlexRcaImporto.TabStop = False
        Me.txtFlexRcaImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFlexIFPerc
        '
        Me.txtFlexIFPerc.BackColor = System.Drawing.SystemColors.Window
        Me.txtFlexIFPerc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFlexIFPerc.Location = New System.Drawing.Point(395, 96)
        Me.txtFlexIFPerc.Name = "txtFlexIFPerc"
        Me.txtFlexIFPerc.Size = New System.Drawing.Size(85, 22)
        Me.txtFlexIFPerc.TabIndex = 37
        Me.txtFlexIFPerc.TabStop = False
        Me.txtFlexIFPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFlexIFImporto
        '
        Me.txtFlexIFImporto.BackColor = System.Drawing.Color.Cornsilk
        Me.txtFlexIFImporto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFlexIFImporto.Location = New System.Drawing.Point(486, 96)
        Me.txtFlexIFImporto.Name = "txtFlexIFImporto"
        Me.txtFlexIFImporto.ReadOnly = True
        Me.txtFlexIFImporto.Size = New System.Drawing.Size(85, 22)
        Me.txtFlexIFImporto.TabIndex = 38
        Me.txtFlexIFImporto.TabStop = False
        Me.txtFlexIFImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.GreenYellow
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label3, 4)
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(304, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(310, 31)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Modifica alla quietanza"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(304, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 31)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Importo desiderato"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCalcola
        '
        Me.btnCalcola.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCalcola.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalcola.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCalcola.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCalcola.Location = New System.Drawing.Point(395, 158)
        Me.btnCalcola.Name = "btnCalcola"
        Me.TableLayoutPanel1.SetRowSpan(Me.btnCalcola, 2)
        Me.btnCalcola.Size = New System.Drawing.Size(85, 56)
        Me.btnCalcola.TabIndex = 13
        Me.btnCalcola.TabStop = False
        Me.btnCalcola.Text = "Calcola % flex"
        Me.btnCalcola.UseVisualStyleBackColor = True
        '
        'btnSalva
        '
        Me.btnSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSalva.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalva.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSalva.Image = CType(resources.GetObject("btnSalva.Image"), System.Drawing.Image)
        Me.btnSalva.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalva.Location = New System.Drawing.Point(486, 220)
        Me.btnSalva.Name = "btnSalva"
        Me.TableLayoutPanel1.SetRowSpan(Me.btnSalva, 2)
        Me.btnSalva.Size = New System.Drawing.Size(85, 56)
        Me.btnSalva.TabIndex = 7
        Me.btnSalva.TabStop = False
        Me.btnSalva.Text = "Salva"
        Me.btnSalva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(577, 31)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(37, 31)
        Me.Label25.TabIndex = 45
        Me.Label25.Text = "Fr"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFraz
        '
        Me.txtFraz.BackColor = System.Drawing.Color.Cornsilk
        Me.txtFraz.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtFraz.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFraz.Location = New System.Drawing.Point(577, 65)
        Me.txtFraz.Name = "txtFraz"
        Me.txtFraz.ReadOnly = True
        Me.txtFraz.Size = New System.Drawing.Size(37, 21)
        Me.txtFraz.TabIndex = 42
        Me.txtFraz.TabStop = False
        Me.txtFraz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnDettaglioArd
        '
        Me.btnDettaglioArd.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDettaglioArd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDettaglioArd.Location = New System.Drawing.Point(3, 158)
        Me.btnDettaglioArd.Name = "btnDettaglioArd"
        Me.btnDettaglioArd.Size = New System.Drawing.Size(113, 22)
        Me.btnDettaglioArd.TabIndex = 46
        Me.btnDettaglioArd.Text = "Altra ARD"
        Me.btnDettaglioArd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnDettaglioArd, "Dettaglio ARD")
        Me.btnDettaglioArd.UseVisualStyleBackColor = True
        '
        'txtSubTotaleRataOld
        '
        Me.txtSubTotaleRataOld.BackColor = System.Drawing.Color.Cornsilk
        Me.txtSubTotaleRataOld.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSubTotaleRataOld.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotaleRataOld.Location = New System.Drawing.Point(122, 189)
        Me.txtSubTotaleRataOld.Name = "txtSubTotaleRataOld"
        Me.txtSubTotaleRataOld.ReadOnly = True
        Me.txtSubTotaleRataOld.Size = New System.Drawing.Size(85, 22)
        Me.txtSubTotaleRataOld.TabIndex = 47
        Me.txtSubTotaleRataOld.TabStop = False
        Me.txtSubTotaleRataOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotaleRata
        '
        Me.txtSubTotaleRata.BackColor = System.Drawing.Color.Cornsilk
        Me.txtSubTotaleRata.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSubTotaleRata.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotaleRata.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtSubTotaleRata.Location = New System.Drawing.Point(213, 189)
        Me.txtSubTotaleRata.Name = "txtSubTotaleRata"
        Me.txtSubTotaleRata.ReadOnly = True
        Me.txtSubTotaleRata.Size = New System.Drawing.Size(85, 22)
        Me.txtSubTotaleRata.TabIndex = 48
        Me.txtSubTotaleRata.TabStop = False
        Me.txtSubTotaleRata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotaleRata2
        '
        Me.txtSubTotaleRata2.BackColor = System.Drawing.Color.Cornsilk
        Me.txtSubTotaleRata2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSubTotaleRata2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotaleRata2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtSubTotaleRata2.Location = New System.Drawing.Point(304, 189)
        Me.txtSubTotaleRata2.Name = "txtSubTotaleRata2"
        Me.txtSubTotaleRata2.ReadOnly = True
        Me.txtSubTotaleRata2.Size = New System.Drawing.Size(85, 22)
        Me.txtSubTotaleRata2.TabIndex = 49
        Me.txtSubTotaleRata2.TabStop = False
        Me.txtSubTotaleRata2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(3, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 26)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Totale Rata"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label28.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(577, 93)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(37, 31)
        Me.Label28.TabIndex = 52
        Me.Label28.Text = "Fsp"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDettaglioRca
        '
        Me.btnDettaglioRca.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDettaglioRca.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDettaglioRca.Location = New System.Drawing.Point(3, 65)
        Me.btnDettaglioRca.Name = "btnDettaglioRca"
        Me.btnDettaglioRca.Size = New System.Drawing.Size(113, 22)
        Me.btnDettaglioRca.TabIndex = 53
        Me.btnDettaglioRca.Text = "Rca"
        Me.btnDettaglioRca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnDettaglioRca, "Dettaglio ARD")
        Me.btnDettaglioRca.UseVisualStyleBackColor = True
        '
        'btnDettaglioIF
        '
        Me.btnDettaglioIF.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDettaglioIF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDettaglioIF.Location = New System.Drawing.Point(3, 96)
        Me.btnDettaglioIF.Name = "btnDettaglioIF"
        Me.btnDettaglioIF.Size = New System.Drawing.Size(113, 22)
        Me.btnDettaglioIF.TabIndex = 54
        Me.btnDettaglioIF.Text = "Inc.e Furto"
        Me.btnDettaglioIF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnDettaglioIF, "Dettaglio ARD")
        Me.btnDettaglioIF.UseVisualStyleBackColor = True
        '
        'btnDettaglioUnibox
        '
        Me.btnDettaglioUnibox.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDettaglioUnibox.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDettaglioUnibox.Location = New System.Drawing.Point(3, 220)
        Me.btnDettaglioUnibox.Name = "btnDettaglioUnibox"
        Me.btnDettaglioUnibox.Size = New System.Drawing.Size(113, 22)
        Me.btnDettaglioUnibox.TabIndex = 55
        Me.btnDettaglioUnibox.Text = "Canone Unibox"
        Me.btnDettaglioUnibox.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnDettaglioUnibox, "Dettaglio ARD")
        Me.btnDettaglioUnibox.UseVisualStyleBackColor = True
        '
        'lbTipoQT
        '
        Me.lbTipoQT.AutoSize = True
        Me.lbTipoQT.BackColor = System.Drawing.Color.Khaki
        Me.lbTipoQT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbTipoQT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbTipoQT.ForeColor = System.Drawing.Color.DimGray
        Me.lbTipoQT.Location = New System.Drawing.Point(3, 0)
        Me.lbTipoQT.Name = "lbTipoQT"
        Me.lbTipoQT.Size = New System.Drawing.Size(113, 31)
        Me.lbTipoQT.TabIndex = 56
        Me.lbTipoQT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtKaskoOld
        '
        Me.txtKaskoOld.BackColor = System.Drawing.Color.Cornsilk
        Me.txtKaskoOld.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtKaskoOld.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKaskoOld.Location = New System.Drawing.Point(122, 127)
        Me.txtKaskoOld.Name = "txtKaskoOld"
        Me.txtKaskoOld.ReadOnly = True
        Me.txtKaskoOld.Size = New System.Drawing.Size(85, 22)
        Me.txtKaskoOld.TabIndex = 58
        Me.txtKaskoOld.TabStop = False
        Me.txtKaskoOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtKasko
        '
        Me.txtKasko.BackColor = System.Drawing.Color.Cornsilk
        Me.txtKasko.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtKasko.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKasko.Location = New System.Drawing.Point(213, 127)
        Me.txtKasko.Name = "txtKasko"
        Me.txtKasko.ReadOnly = True
        Me.txtKasko.Size = New System.Drawing.Size(85, 22)
        Me.txtKasko.TabIndex = 59
        Me.txtKasko.TabStop = False
        Me.txtKasko.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFlexKaskoImporto
        '
        Me.txtFlexKaskoImporto.BackColor = System.Drawing.Color.Cornsilk
        Me.txtFlexKaskoImporto.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtFlexKaskoImporto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFlexKaskoImporto.Location = New System.Drawing.Point(486, 127)
        Me.txtFlexKaskoImporto.Name = "txtFlexKaskoImporto"
        Me.txtFlexKaskoImporto.ReadOnly = True
        Me.txtFlexKaskoImporto.Size = New System.Drawing.Size(85, 22)
        Me.txtFlexKaskoImporto.TabIndex = 60
        Me.txtFlexKaskoImporto.TabStop = False
        Me.txtFlexKaskoImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFSP
        '
        Me.txtFSP.BackColor = System.Drawing.Color.Gold
        Me.txtFSP.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtFSP.Location = New System.Drawing.Point(577, 127)
        Me.txtFSP.Name = "txtFSP"
        Me.txtFSP.ReadOnly = True
        Me.txtFSP.Size = New System.Drawing.Size(37, 22)
        Me.txtFSP.TabIndex = 51
        Me.txtFSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtKasko2
        '
        Me.txtKasko2.BackColor = System.Drawing.SystemColors.Window
        Me.txtKasko2.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtKasko2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKasko2.Location = New System.Drawing.Point(304, 127)
        Me.txtKasko2.Name = "txtKasko2"
        Me.txtKasko2.Size = New System.Drawing.Size(85, 22)
        Me.txtKasko2.TabIndex = 61
        Me.txtKasko2.TabStop = False
        Me.txtKasko2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFlexKaskoPerc
        '
        Me.txtFlexKaskoPerc.BackColor = System.Drawing.SystemColors.Window
        Me.txtFlexKaskoPerc.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtFlexKaskoPerc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFlexKaskoPerc.Location = New System.Drawing.Point(395, 127)
        Me.txtFlexKaskoPerc.Name = "txtFlexKaskoPerc"
        Me.txtFlexKaskoPerc.Size = New System.Drawing.Size(85, 22)
        Me.txtFlexKaskoPerc.TabIndex = 62
        Me.txtFlexKaskoPerc.TabStop = False
        Me.txtFlexKaskoPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDettaglioKasko
        '
        Me.btnDettaglioKasko.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDettaglioKasko.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDettaglioKasko.Location = New System.Drawing.Point(3, 127)
        Me.btnDettaglioKasko.Name = "btnDettaglioKasko"
        Me.btnDettaglioKasko.Size = New System.Drawing.Size(113, 22)
        Me.btnDettaglioKasko.TabIndex = 63
        Me.btnDettaglioKasko.Text = "Kasko"
        Me.btnDettaglioKasko.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnDettaglioKasko, "Dettaglio ARD")
        Me.btnDettaglioKasko.UseVisualStyleBackColor = True
        '
        'lbMessaggio
        '
        Me.lbMessaggio.AutoSize = True
        Me.lbMessaggio.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbMessaggio, 4)
        Me.lbMessaggio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbMessaggio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMessaggio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbMessaggio.Location = New System.Drawing.Point(304, 279)
        Me.lbMessaggio.Name = "lbMessaggio"
        Me.lbMessaggio.Size = New System.Drawing.Size(310, 40)
        Me.lbMessaggio.TabIndex = 64
        Me.lbMessaggio.Text = "Messaggio"
        Me.lbMessaggio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTipoVeicolo
        '
        Me.lbTipoVeicolo.AutoSize = True
        Me.lbTipoVeicolo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbTipoVeicolo, 2)
        Me.lbTipoVeicolo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbTipoVeicolo.Location = New System.Drawing.Point(620, 248)
        Me.lbTipoVeicolo.Name = "lbTipoVeicolo"
        Me.lbTipoVeicolo.Size = New System.Drawing.Size(175, 31)
        Me.lbTipoVeicolo.TabIndex = 65
        Me.lbTipoVeicolo.Text = "Tipo veicolo"
        Me.lbTipoVeicolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBonus
        '
        Me.txtBonus.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBonus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBonus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBonus.ForeColor = System.Drawing.Color.GreenYellow
        Me.txtBonus.Location = New System.Drawing.Point(213, 282)
        Me.txtBonus.Name = "txtBonus"
        Me.txtBonus.ReadOnly = True
        Me.txtBonus.Size = New System.Drawing.Size(85, 22)
        Me.txtBonus.TabIndex = 67
        Me.txtBonus.TabStop = False
        Me.txtBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbGenerale
        '
        Me.gbGenerale.Controls.Add(Me.TableLayoutPanel3)
        Me.gbGenerale.Dock = System.Windows.Forms.DockStyle.Right
        Me.gbGenerale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGenerale.Location = New System.Drawing.Point(982, 0)
        Me.gbGenerale.Name = "gbGenerale"
        Me.gbGenerale.Size = New System.Drawing.Size(331, 340)
        Me.gbGenerale.TabIndex = 9
        Me.gbGenerale.TabStop = False
        Me.gbGenerale.Text = "Totali Qt selezionate"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.lbPeriodo, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtFlexUtiRca, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.txtFlexImpIF, 2, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.txtFlexUtiIF, 2, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.txtFlexImpRca, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lbFlexTotaleIF, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label22, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.lbFlexTotaleRca, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label21, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label23, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label24, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label26, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label27, 1, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.txtFlexRcaTotale, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.txtFlexIFTotale, 2, 6)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 10
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(325, 319)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'lbPeriodo
        '
        Me.lbPeriodo.BackColor = System.Drawing.Color.Gainsboro
        Me.lbPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel3.SetColumnSpan(Me.lbPeriodo, 3)
        Me.lbPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbPeriodo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbPeriodo.Location = New System.Drawing.Point(3, 0)
        Me.lbPeriodo.Name = "lbPeriodo"
        Me.lbPeriodo.Size = New System.Drawing.Size(319, 31)
        Me.lbPeriodo.TabIndex = 2
        Me.lbPeriodo.Text = "periodo"
        Me.lbPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFlexUtiRca
        '
        Me.txtFlexUtiRca.BackColor = System.Drawing.Color.Cornsilk
        Me.txtFlexUtiRca.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtFlexUtiRca.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFlexUtiRca.Location = New System.Drawing.Point(198, 65)
        Me.txtFlexUtiRca.Name = "txtFlexUtiRca"
        Me.txtFlexUtiRca.Size = New System.Drawing.Size(124, 22)
        Me.txtFlexUtiRca.TabIndex = 8
        Me.txtFlexUtiRca.TabStop = False
        Me.txtFlexUtiRca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFlexImpIF
        '
        Me.txtFlexImpIF.BackColor = System.Drawing.Color.Cornsilk
        Me.txtFlexImpIF.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtFlexImpIF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFlexImpIF.Location = New System.Drawing.Point(198, 127)
        Me.txtFlexImpIF.Name = "txtFlexImpIF"
        Me.txtFlexImpIF.Size = New System.Drawing.Size(124, 22)
        Me.txtFlexImpIF.TabIndex = 4
        Me.txtFlexImpIF.TabStop = False
        Me.txtFlexImpIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFlexUtiIF
        '
        Me.txtFlexUtiIF.BackColor = System.Drawing.Color.Cornsilk
        Me.txtFlexUtiIF.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtFlexUtiIF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFlexUtiIF.Location = New System.Drawing.Point(198, 158)
        Me.txtFlexUtiIF.Name = "txtFlexUtiIF"
        Me.txtFlexUtiIF.Size = New System.Drawing.Size(124, 22)
        Me.txtFlexUtiIF.TabIndex = 7
        Me.txtFlexUtiIF.TabStop = False
        Me.txtFlexUtiIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFlexImpRca
        '
        Me.txtFlexImpRca.BackColor = System.Drawing.Color.Cornsilk
        Me.txtFlexImpRca.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtFlexImpRca.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFlexImpRca.Location = New System.Drawing.Point(198, 34)
        Me.txtFlexImpRca.Name = "txtFlexImpRca"
        Me.txtFlexImpRca.Size = New System.Drawing.Size(124, 22)
        Me.txtFlexImpRca.TabIndex = 1
        Me.txtFlexImpRca.TabStop = False
        Me.txtFlexImpRca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbFlexTotaleIF
        '
        Me.lbFlexTotaleIF.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbFlexTotaleIF.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFlexTotaleIF.Location = New System.Drawing.Point(68, 124)
        Me.lbFlexTotaleIF.Name = "lbFlexTotaleIF"
        Me.lbFlexTotaleIF.Size = New System.Drawing.Size(124, 25)
        Me.lbFlexTotaleIF.TabIndex = 3
        Me.lbFlexTotaleIF.Text = "Flex impegnata"
        Me.lbFlexTotaleIF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(68, 155)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(124, 25)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "Flex utilizzata"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbFlexTotaleRca
        '
        Me.lbFlexTotaleRca.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbFlexTotaleRca.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFlexTotaleRca.Location = New System.Drawing.Point(68, 31)
        Me.lbFlexTotaleRca.Name = "lbFlexTotaleRca"
        Me.lbFlexTotaleRca.Size = New System.Drawing.Size(124, 25)
        Me.lbFlexTotaleRca.TabIndex = 0
        Me.lbFlexTotaleRca.Text = "Flex impegnata"
        Me.lbFlexTotaleRca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(68, 62)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(124, 25)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Flex utilizzata"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(3, 31)
        Me.Label23.Name = "Label23"
        Me.TableLayoutPanel3.SetRowSpan(Me.Label23, 3)
        Me.Label23.Size = New System.Drawing.Size(59, 93)
        Me.Label23.TabIndex = 9
        Me.Label23.Text = "RCA"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(3, 124)
        Me.Label24.Name = "Label24"
        Me.TableLayoutPanel3.SetRowSpan(Me.Label24, 3)
        Me.Label24.Size = New System.Drawing.Size(59, 93)
        Me.Label24.TabIndex = 10
        Me.Label24.Text = "IF"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(68, 93)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(124, 31)
        Me.Label26.TabIndex = 11
        Me.Label26.Text = "Totale"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(68, 186)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(124, 31)
        Me.Label27.TabIndex = 12
        Me.Label27.Text = "Totale"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFlexRcaTotale
        '
        Me.txtFlexRcaTotale.BackColor = System.Drawing.Color.Cornsilk
        Me.txtFlexRcaTotale.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtFlexRcaTotale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFlexRcaTotale.Location = New System.Drawing.Point(198, 96)
        Me.txtFlexRcaTotale.Name = "txtFlexRcaTotale"
        Me.txtFlexRcaTotale.Size = New System.Drawing.Size(124, 22)
        Me.txtFlexRcaTotale.TabIndex = 13
        Me.txtFlexRcaTotale.TabStop = False
        Me.txtFlexRcaTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFlexIFTotale
        '
        Me.txtFlexIFTotale.BackColor = System.Drawing.Color.Cornsilk
        Me.txtFlexIFTotale.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtFlexIFTotale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFlexIFTotale.Location = New System.Drawing.Point(198, 189)
        Me.txtFlexIFTotale.Name = "txtFlexIFTotale"
        Me.txtFlexIFTotale.Size = New System.Drawing.Size(124, 22)
        Me.txtFlexIFTotale.TabIndex = 14
        Me.txtFlexIFTotale.TabStop = False
        Me.txtFlexIFTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCerca
        '
        Me.txtCerca.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCerca.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCerca.Location = New System.Drawing.Point(75, 25)
        Me.txtCerca.Name = "txtCerca"
        Me.txtCerca.Size = New System.Drawing.Size(91, 22)
        Me.txtCerca.TabIndex = 0
        '
        'dtpInizio
        '
        Me.dtpInizio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInizio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInizio.Location = New System.Drawing.Point(82, 25)
        Me.dtpInizio.Name = "dtpInizio"
        Me.dtpInizio.Size = New System.Drawing.Size(106, 22)
        Me.dtpInizio.TabIndex = 0
        '
        'dtpFine
        '
        Me.dtpFine.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFine.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFine.Location = New System.Drawing.Point(82, 52)
        Me.dtpFine.Name = "dtpFine"
        Me.dtpFine.Size = New System.Drawing.Size(106, 22)
        Me.dtpFine.TabIndex = 1
        '
        'txtSub
        '
        Me.txtSub.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSub.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSub.Location = New System.Drawing.Point(204, 25)
        Me.txtSub.Name = "txtSub"
        Me.txtSub.Size = New System.Drawing.Size(52, 22)
        Me.txtSub.TabIndex = 1
        Me.txtSub.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtProduttore
        '
        Me.txtProduttore.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProduttore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProduttore.Location = New System.Drawing.Point(297, 25)
        Me.txtProduttore.Name = "txtProduttore"
        Me.txtProduttore.Size = New System.Drawing.Size(52, 22)
        Me.txtProduttore.TabIndex = 2
        Me.txtProduttore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnEsci
        '
        Me.btnEsci.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEsci.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEsci.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEsci.Location = New System.Drawing.Point(6, 51)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(137, 40)
        Me.btnEsci.TabIndex = 0
        Me.btnEsci.Text = "Esci"
        Me.btnEsci.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'LinkLabelPannello
        '
        Me.LinkLabelPannello.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelPannello.AutoSize = True
        Me.LinkLabelPannello.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabelPannello.Location = New System.Drawing.Point(986, 58)
        Me.LinkLabelPannello.Name = "LinkLabelPannello"
        Me.LinkLabelPannello.Size = New System.Drawing.Size(108, 13)
        Me.LinkLabelPannello.TabIndex = 11
        Me.LinkLabelPannello.TabStop = True
        Me.LinkLabelPannello.Text = "LinkLabelPannello"
        '
        'LinkLabelDettaglio
        '
        Me.LinkLabelDettaglio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelDettaglio.AutoSize = True
        Me.LinkLabelDettaglio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabelDettaglio.Location = New System.Drawing.Point(986, 81)
        Me.LinkLabelDettaglio.Name = "LinkLabelDettaglio"
        Me.LinkLabelDettaglio.Size = New System.Drawing.Size(112, 13)
        Me.LinkLabelDettaglio.TabIndex = 13
        Me.LinkLabelDettaglio.TabStop = True
        Me.LinkLabelDettaglio.Text = "LinkLabelDettaglio"
        '
        'chkNascondiColonne
        '
        Me.chkNascondiColonne.AutoSize = True
        Me.chkNascondiColonne.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNascondiColonne.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkNascondiColonne.Location = New System.Drawing.Point(6, 45)
        Me.chkNascondiColonne.Name = "chkNascondiColonne"
        Me.chkNascondiColonne.Size = New System.Drawing.Size(138, 17)
        Me.chkNascondiColonne.TabIndex = 2
        Me.chkNascondiColonne.Text = "Nascondi colonne extra"
        Me.chkNascondiColonne.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(16, 30)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 13)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Periodo dal"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(61, 57)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "al"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(10, 30)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Contraente"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(172, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(26, 13)
        Me.Label17.TabIndex = 20
        Me.Label17.Text = "Sub"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(262, 30)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(29, 13)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Prod"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFine)
        Me.GroupBox1.Controls.Add(Me.dtpInizio)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(202, 95)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(16, 57)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 13)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "Visualizza"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFiltro
        '
        Me.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFiltro.DropDownWidth = 300
        Me.cboFiltro.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFiltro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboFiltro.FormattingEnabled = True
        Me.cboFiltro.Location = New System.Drawing.Point(75, 52)
        Me.cboFiltro.MaxDropDownItems = 10
        Me.cboFiltro.Name = "cboFiltro"
        Me.cboFiltro.Size = New System.Drawing.Size(216, 22)
        Me.cboFiltro.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnHelp)
        Me.GroupBox2.Controls.Add(Me.btnEsci)
        Me.GroupBox2.Location = New System.Drawing.Point(1176, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(149, 95)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        '
        'btnHelp
        '
        Me.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHelp.Location = New System.Drawing.Point(6, 10)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(137, 40)
        Me.btnHelp.TabIndex = 2
        Me.btnHelp.Text = "Guida"
        Me.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnAnnullaFiltri)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txtCerca)
        Me.GroupBox3.Controls.Add(Me.cboFiltro)
        Me.GroupBox3.Controls.Add(Me.txtSub)
        Me.GroupBox3.Controls.Add(Me.txtProduttore)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox3.Location = New System.Drawing.Point(220, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(360, 95)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filtri"
        '
        'btnAnnullaFiltri
        '
        Me.btnAnnullaFiltri.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnAnnullaFiltri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnullaFiltri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnnullaFiltri.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAnnullaFiltri.Location = New System.Drawing.Point(297, 53)
        Me.btnAnnullaFiltri.Name = "btnAnnullaFiltri"
        Me.btnAnnullaFiltri.Size = New System.Drawing.Size(52, 22)
        Me.btnAnnullaFiltri.TabIndex = 25
        Me.ToolTip1.SetToolTip(Me.btnAnnullaFiltri, "Annulla filtri")
        Me.btnAnnullaFiltri.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkAutoSize)
        Me.GroupBox5.Controls.Add(Me.chkBloccaColonne)
        Me.GroupBox5.Controls.Add(Me.chkNascondiColonne)
        Me.GroupBox5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox5.Location = New System.Drawing.Point(586, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(157, 95)
        Me.GroupBox5.TabIndex = 26
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Aspetto"
        '
        'chkAutoSize
        '
        Me.chkAutoSize.AutoSize = True
        Me.chkAutoSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAutoSize.Location = New System.Drawing.Point(6, 68)
        Me.chkAutoSize.Name = "chkAutoSize"
        Me.chkAutoSize.Size = New System.Drawing.Size(130, 17)
        Me.chkAutoSize.TabIndex = 4
        Me.chkAutoSize.Text = "Ridimensiona colonne"
        Me.chkAutoSize.UseVisualStyleBackColor = True
        '
        'chkBloccaColonne
        '
        Me.chkBloccaColonne.AutoSize = True
        Me.chkBloccaColonne.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBloccaColonne.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBloccaColonne.Location = New System.Drawing.Point(6, 22)
        Me.chkBloccaColonne.Name = "chkBloccaColonne"
        Me.chkBloccaColonne.Size = New System.Drawing.Size(144, 17)
        Me.chkBloccaColonne.TabIndex = 3
        Me.chkBloccaColonne.Text = "Blocca colonne a sinistra"
        Me.chkBloccaColonne.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.UseAnimation = False
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1337, 741)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LinkLabelDettaglio)
        Me.Controls.Add(Me.LinkLabelPannello)
        Me.Controls.Add(Me.SplitMain)
        Me.Name = "FormMain"
        Me.Text = "Monitoraggio quietanzamento Rca"
        Me.Elenco.ResumeLayout(False)
        Me.Elenco.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitMain.Panel1.ResumeLayout(False)
        Me.SplitMain.Panel2.ResumeLayout(False)
        Me.SplitMain.ResumeLayout(False)
        Me.SplitPannello.Panel1.ResumeLayout(False)
        Me.SplitPannello.Panel2.ResumeLayout(False)
        Me.SplitPannello.ResumeLayout(False)
        Me.TabQuietanze.ResumeLayout(False)
        Me.Statistiche.ResumeLayout(False)
        Me.Statistiche.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabStat.ResumeLayout(False)
        Me.TabStat1.ResumeLayout(False)
        CType(Me.dgvStat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabStat2.ResumeLayout(False)
        CType(Me.dgvStat2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Legenda.ResumeLayout(False)
        Me.gbDettaglio.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.gbGenerale.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitMain As System.Windows.Forms.SplitContainer
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents lvDettaglio As System.Windows.Forms.ListView
    Friend WithEvents txtCerca As System.Windows.Forms.TextBox
    Friend WithEvents dtpInizio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFine As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents txtSub As System.Windows.Forms.TextBox
    Friend WithEvents txtProduttore As System.Windows.Forms.TextBox
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents LinkLabelPannello As System.Windows.Forms.LinkLabel
    Friend WithEvents TabQuietanze As Utx.UtTabControl
    Friend WithEvents SplitPannello As System.Windows.Forms.SplitContainer
    Friend WithEvents LinkLabelDettaglio As System.Windows.Forms.LinkLabel
    Friend WithEvents btnSalva As System.Windows.Forms.Button
    Friend WithEvents chkNascondiColonne As System.Windows.Forms.CheckBox
    Friend WithEvents gbGenerale As System.Windows.Forms.GroupBox
    Friend WithEvents gbDettaglio As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotaleRata As System.Windows.Forms.TextBox
    Friend WithEvents txtUnibox As System.Windows.Forms.TextBox
    Friend WithEvents txtArd As System.Windows.Forms.TextBox
    Friend WithEvents txtRca As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRca2 As System.Windows.Forms.TextBox
    Friend WithEvents txtArd2 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnibox2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTotaleRata2 As System.Windows.Forms.TextBox
    Friend WithEvents btnCalcola As System.Windows.Forms.Button
    Friend WithEvents txtFlexRcaImporto As System.Windows.Forms.TextBox
    Friend WithEvents txtFlexRcaPerc As System.Windows.Forms.TextBox
    Friend WithEvents lbFlexTotaleRca As System.Windows.Forms.Label
    Friend WithEvents txtFlexImpRca As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtRcaOld As System.Windows.Forms.TextBox
    Friend WithEvents txtArdOld As System.Windows.Forms.TextBox
    Friend WithEvents txtUniboxOld As System.Windows.Forms.TextBox
    Friend WithEvents txtTotaleRataOld As System.Windows.Forms.TextBox
    Friend WithEvents txtFlexOld As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbPeriodo As System.Windows.Forms.Label
    Friend WithEvents txtIFOld As System.Windows.Forms.TextBox
    Friend WithEvents txtIF As System.Windows.Forms.TextBox
    Friend WithEvents txtIF2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFlexIFPerc As System.Windows.Forms.TextBox
    Friend WithEvents txtFlexIFImporto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbFlexTotaleIF As System.Windows.Forms.Label
    Friend WithEvents txtFlexImpIF As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkBloccaColonne As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoSize As System.Windows.Forms.CheckBox
    Friend WithEvents Legenda As System.Windows.Forms.TabPage
    Friend WithEvents wbLegenda As System.Windows.Forms.WebBrowser
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents Elenco As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtFlexUtiIF As System.Windows.Forms.TextBox
    Friend WithEvents txtFlexUtiRca As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtFraz As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtFlexRcaTotale As System.Windows.Forms.TextBox
    Friend WithEvents txtFlexIFTotale As System.Windows.Forms.TextBox
    Friend WithEvents btnDettaglioArd As System.Windows.Forms.Button
    Friend WithEvents txtSubTotaleRataOld As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTotaleRata As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTotaleRata2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Statistiche As System.Windows.Forms.TabPage
    Friend WithEvents txtFSP As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents dgvStat As System.Windows.Forms.DataGridView
    Friend WithEvents lbDeskStatistiche As System.Windows.Forms.Label
    Friend WithEvents TabStat As Utx.UtTabControl
    Friend WithEvents TabStat1 As System.Windows.Forms.TabPage
    Friend WithEvents TabStat2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvStat2 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAnnullaFiltri As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripPbStat As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents btnDettaglioRca As System.Windows.Forms.Button
    Friend WithEvents btnDettaglioIF As System.Windows.Forms.Button
    Friend WithEvents btnDettaglioUnibox As System.Windows.Forms.Button
    Friend WithEvents lbConvenzione As System.Windows.Forms.Label
    Friend WithEvents lbTipoQT As System.Windows.Forms.Label
    Friend WithEvents txtKaskoOld As System.Windows.Forms.TextBox
    Friend WithEvents txtKasko As System.Windows.Forms.TextBox
    Friend WithEvents txtFlexKaskoImporto As System.Windows.Forms.TextBox
    Friend WithEvents txtKasko2 As System.Windows.Forms.TextBox
    Friend WithEvents txtFlexKaskoPerc As System.Windows.Forms.TextBox
    Friend WithEvents btnDettaglioKasko As System.Windows.Forms.Button
    Friend WithEvents btnIndice As System.Windows.Forms.Button
    Friend WithEvents lbMessaggio As System.Windows.Forms.Label
    Friend WithEvents lbTasse As System.Windows.Forms.Label
    Friend WithEvents lbTipoVeicolo As System.Windows.Forms.Label
    Friend WithEvents txtBonus As System.Windows.Forms.TextBox

End Class
