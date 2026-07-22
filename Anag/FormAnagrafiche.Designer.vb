Imports System.Windows.Forms
Imports System.Drawing

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnagrafiche
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlpClienti = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelCerca = New System.Windows.Forms.Label()
        Me.ComboBoxCercaIn = New System.Windows.Forms.ComboBox()
        Me.TabClienti = New Utx.UtTabControl()
        Me.TabPageElenco = New System.Windows.Forms.TabPage()
        Me.ElencoClienti = New Anag.ucClienti()
        Me.TabPageDettaglio = New System.Windows.Forms.TabPage()
        Me.DettaglioCliente = New Anag.ucDettaglio()
        Me.TabPagePolizzeIncassi = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GrigliaPolizze = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelStorico = New System.Windows.Forms.Label()
        Me.labelIncassi = New System.Windows.Forms.Label()
        Me.LabelTitoloPolizze = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvDocumenti = New System.Windows.Forms.DataGridView()
        Me.LabelTitoloIncassi = New System.Windows.Forms.Label()
        Me.GrigliaIncassi = New System.Windows.Forms.DataGridView()
        Me.GrigliaArretrati = New System.Windows.Forms.DataGridView()
        Me.LabelTitoloArretrati = New System.Windows.Forms.Label()
        Me.buttonVaiAIncasso = New UtControls.UtFlatButton()
        Me.TabPageNote = New System.Windows.Forms.TabPage()
        Me.TabPageSintesi = New System.Windows.Forms.TabPage()
        Me.NavBar = New UtControls.ucNavigationBar()
        Me.CheckBoxEsatto = New System.Windows.Forms.CheckBox()
        Me.LabelNumeroClienti = New System.Windows.Forms.Label()
        Me.LabelSemaforoRicerca = New System.Windows.Forms.Label()
        Me.LabelSemaforoSelezione = New System.Windows.Forms.Label()
        Me.LabelNominativo = New System.Windows.Forms.Label()
        Me.LabelIndirizzo = New System.Windows.Forms.Label()
        Me.buttonCercaInEssig = New UtControls.UtFlatButton()
        Me.buttonCercaInCrm = New UtControls.UtFlatButton()
        Me.CheckBoxTutti = New System.Windows.Forms.CheckBox()
        Me.ComboBoxStatoCliente = New System.Windows.Forms.ComboBox()
        Me.ComboBoxLayout = New System.Windows.Forms.ComboBox()
        Me.ButtonPulisciCasellaCerca = New System.Windows.Forms.Button()
        Me.ButtonReset = New UtControls.UtFlatButton()
        Me.StatusStripClienti = New System.Windows.Forms.StatusStrip()
        Me.tssMessaggio = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsMainMenu = New System.Windows.Forms.ToolStrip()
        Me.ButtonDocumenti = New UtControls.UtFlatButton()
        Me.ButtonEsci = New UtControls.UtFlatButton()
        Me.ButtonCai = New UtControls.UtFlatButton()
        Me.ButtonSinistri = New UtControls.UtFlatButton()
        Me.ButtonSinistriCliente = New UtControls.UtFlatButton()
        Me.ButtonEvidenza = New UtControls.UtFlatButton()
        Me.ButtonEvidenzeCliente = New UtControls.UtFlatButton()
        Me.tlpClienti.SuspendLayout()
        Me.TabClienti.SuspendLayout()
        Me.TabPageElenco.SuspendLayout()
        Me.TabPageDettaglio.SuspendLayout()
        Me.TabPagePolizzeIncassi.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.GrigliaPolizze, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvDocumenti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrigliaIncassi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrigliaArretrati, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStripClienti.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpClienti
        '
        Me.tlpClienti.ColumnCount = 10
        Me.tlpClienti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.tlpClienti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlpClienti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.04712!))
        Me.tlpClienti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpClienti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.32548!))
        Me.tlpClienti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.32548!))
        Me.tlpClienti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.32548!))
        Me.tlpClienti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.32548!))
        Me.tlpClienti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.32548!))
        Me.tlpClienti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.32548!))
        Me.tlpClienti.Controls.Add(Me.LabelCerca, 1, 2)
        Me.tlpClienti.Controls.Add(Me.ComboBoxCercaIn, 2, 2)
        Me.tlpClienti.Controls.Add(Me.TabClienti, 0, 5)
        Me.tlpClienti.Controls.Add(Me.NavBar, 1, 4)
        Me.tlpClienti.Controls.Add(Me.CheckBoxEsatto, 4, 2)
        Me.tlpClienti.Controls.Add(Me.LabelNumeroClienti, 9, 2)
        Me.tlpClienti.Controls.Add(Me.LabelSemaforoRicerca, 0, 2)
        Me.tlpClienti.Controls.Add(Me.LabelSemaforoSelezione, 0, 4)
        Me.tlpClienti.Controls.Add(Me.LabelNominativo, 4, 4)
        Me.tlpClienti.Controls.Add(Me.LabelIndirizzo, 6, 4)
        Me.tlpClienti.Controls.Add(Me.buttonCercaInEssig, 8, 4)
        Me.tlpClienti.Controls.Add(Me.buttonCercaInCrm, 9, 4)
        Me.tlpClienti.Controls.Add(Me.CheckBoxTutti, 5, 2)
        Me.tlpClienti.Controls.Add(Me.ComboBoxStatoCliente, 6, 2)
        Me.tlpClienti.Controls.Add(Me.ComboBoxLayout, 7, 0)
        Me.tlpClienti.Controls.Add(Me.ButtonPulisciCasellaCerca, 3, 2)
        Me.tlpClienti.Controls.Add(Me.ButtonReset, 8, 2)
        Me.tlpClienti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpClienti.Location = New System.Drawing.Point(3, 3)
        Me.tlpClienti.Name = "tlpClienti"
        Me.tlpClienti.RowCount = 6
        Me.tlpClienti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpClienti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.tlpClienti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpClienti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.tlpClienti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpClienti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpClienti.Size = New System.Drawing.Size(1242, 604)
        Me.tlpClienti.TabIndex = 2
        '
        'LabelCerca
        '
        Me.LabelCerca.AutoSize = True
        Me.LabelCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCerca.Location = New System.Drawing.Point(15, 45)
        Me.LabelCerca.Name = "LabelCerca"
        Me.LabelCerca.Size = New System.Drawing.Size(84, 25)
        Me.LabelCerca.TabIndex = 17
        Me.LabelCerca.Text = "Label1"
        Me.LabelCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxCercaIn
        '
        Me.ComboBoxCercaIn.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBoxCercaIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxCercaIn.Location = New System.Drawing.Point(102, 45)
        Me.ComboBoxCercaIn.Margin = New System.Windows.Forms.Padding(0)
        Me.ComboBoxCercaIn.Name = "ComboBoxCercaIn"
        Me.ComboBoxCercaIn.Size = New System.Drawing.Size(223, 22)
        Me.ComboBoxCercaIn.TabIndex = 11
        '
        'TabClienti
        '
        Me.TabClienti.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabClienti.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
        Me.tlpClienti.SetColumnSpan(Me.TabClienti, 10)
        Me.TabClienti.Controls.Add(Me.TabPageElenco)
        Me.TabClienti.Controls.Add(Me.TabPageDettaglio)
        Me.TabClienti.Controls.Add(Me.TabPagePolizzeIncassi)
        Me.TabClienti.Controls.Add(Me.TabPageNote)
        Me.TabClienti.Controls.Add(Me.TabPageSintesi)
        Me.TabClienti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabClienti.ItemSize = New System.Drawing.Size(1000, 25)
        Me.TabClienti.Location = New System.Drawing.Point(3, 103)
        Me.TabClienti.Name = "TabClienti"
        Me.TabClienti.SelectedIndex = 0
        Me.TabClienti.Size = New System.Drawing.Size(1236, 498)
        Me.TabClienti.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabClienti.TabIndex = 0
        Me.TabClienti.Visible = False
        '
        'TabPageElenco
        '
        Me.TabPageElenco.Controls.Add(Me.ElencoClienti)
        Me.TabPageElenco.Location = New System.Drawing.Point(4, 29)
        Me.TabPageElenco.Name = "TabPageElenco"
        Me.TabPageElenco.Size = New System.Drawing.Size(1228, 465)
        Me.TabPageElenco.TabIndex = 0
        Me.TabPageElenco.Text = "Elenco clienti"
        '
        'ElencoClienti
        '
        Me.ElencoClienti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ElencoClienti.Location = New System.Drawing.Point(0, 0)
        Me.ElencoClienti.Name = "ElencoClienti"
        Me.ElencoClienti.Size = New System.Drawing.Size(1228, 465)
        Me.ElencoClienti.TabIndex = 0
        '
        'TabPageDettaglio
        '
        Me.TabPageDettaglio.Controls.Add(Me.DettaglioCliente)
        Me.TabPageDettaglio.Location = New System.Drawing.Point(4, 29)
        Me.TabPageDettaglio.Name = "TabPageDettaglio"
        Me.TabPageDettaglio.Size = New System.Drawing.Size(1228, 465)
        Me.TabPageDettaglio.TabIndex = 1
        Me.TabPageDettaglio.Text = "Anagrafica"
        '
        'DettaglioCliente
        '
        Me.DettaglioCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DettaglioCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DettaglioCliente.Location = New System.Drawing.Point(0, 0)
        Me.DettaglioCliente.Name = "DettaglioCliente"
        Me.DettaglioCliente.Size = New System.Drawing.Size(1228, 465)
        Me.DettaglioCliente.TabIndex = 0
        '
        'TabPagePolizzeIncassi
        '
        Me.TabPagePolizzeIncassi.Controls.Add(Me.SplitContainer1)
        Me.TabPagePolizzeIncassi.Location = New System.Drawing.Point(4, 29)
        Me.TabPagePolizzeIncassi.Name = "TabPagePolizzeIncassi"
        Me.TabPagePolizzeIncassi.Size = New System.Drawing.Size(1228, 465)
        Me.TabPagePolizzeIncassi.TabIndex = 2
        Me.TabPagePolizzeIncassi.Text = "Polizze e Incassi"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1228, 465)
        Me.SplitContainer1.SplitterDistance = 829
        Me.SplitContainer1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GrigliaPolizze, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(829, 465)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'GrigliaPolizze
        '
        Me.GrigliaPolizze.AllowUserToAddRows = False
        Me.GrigliaPolizze.AllowUserToDeleteRows = False
        Me.GrigliaPolizze.AllowUserToResizeColumns = False
        Me.GrigliaPolizze.AllowUserToResizeRows = False
        Me.GrigliaPolizze.ColumnHeadersHeight = 40
        Me.GrigliaPolizze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GrigliaPolizze.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrigliaPolizze.Location = New System.Drawing.Point(0, 28)
        Me.GrigliaPolizze.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.GrigliaPolizze.MultiSelect = False
        Me.GrigliaPolizze.Name = "GrigliaPolizze"
        Me.GrigliaPolizze.ReadOnly = True
        Me.GrigliaPolizze.RowHeadersVisible = False
        Me.GrigliaPolizze.RowHeadersWidth = 40
        Me.GrigliaPolizze.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GrigliaPolizze.RowTemplate.Height = 35
        Me.GrigliaPolizze.RowTemplate.ReadOnly = True
        Me.GrigliaPolizze.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrigliaPolizze.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrigliaPolizze.Size = New System.Drawing.Size(829, 437)
        Me.GrigliaPolizze.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightYellow
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LabelStorico)
        Me.Panel1.Controls.Add(Me.labelIncassi)
        Me.Panel1.Controls.Add(Me.LabelTitoloPolizze)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(829, 25)
        Me.Panel1.TabIndex = 3
        '
        'LabelStorico
        '
        Me.LabelStorico.BackColor = System.Drawing.Color.Transparent
        Me.LabelStorico.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelStorico.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelStorico.Font = New System.Drawing.Font("Tahoma", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStorico.ForeColor = System.Drawing.Color.Blue
        Me.LabelStorico.Location = New System.Drawing.Point(0, 0)
        Me.LabelStorico.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelStorico.Name = "LabelStorico"
        Me.LabelStorico.Size = New System.Drawing.Size(114, 23)
        Me.LabelStorico.TabIndex = 2
        Me.LabelStorico.Text = "passa a storico"
        Me.LabelStorico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelIncassi
        '
        Me.labelIncassi.BackColor = System.Drawing.Color.Transparent
        Me.labelIncassi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.labelIncassi.Dock = System.Windows.Forms.DockStyle.Right
        Me.labelIncassi.Font = New System.Drawing.Font("Tahoma", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelIncassi.ForeColor = System.Drawing.Color.Blue
        Me.labelIncassi.Location = New System.Drawing.Point(713, 0)
        Me.labelIncassi.Margin = New System.Windows.Forms.Padding(0)
        Me.labelIncassi.Name = "labelIncassi"
        Me.labelIncassi.Size = New System.Drawing.Size(114, 23)
        Me.labelIncassi.TabIndex = 1
        Me.labelIncassi.Text = "chiudi incassi >>"
        Me.labelIncassi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelTitoloPolizze
        '
        Me.LabelTitoloPolizze.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitoloPolizze.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTitoloPolizze.Location = New System.Drawing.Point(0, 0)
        Me.LabelTitoloPolizze.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelTitoloPolizze.Name = "LabelTitoloPolizze"
        Me.LabelTitoloPolizze.Size = New System.Drawing.Size(827, 23)
        Me.LabelTitoloPolizze.TabIndex = 1
        Me.LabelTitoloPolizze.Text = "Polizze in vigore"
        Me.LabelTitoloPolizze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvDocumenti, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelTitoloIncassi, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GrigliaIncassi, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GrigliaArretrati, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelTitoloArretrati, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.buttonVaiAIncasso, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(395, 465)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'dgvDocumenti
        '
        Me.dgvDocumenti.AllowUserToAddRows = False
        Me.dgvDocumenti.AllowUserToDeleteRows = False
        Me.dgvDocumenti.AllowUserToOrderColumns = True
        Me.dgvDocumenti.AllowUserToResizeColumns = False
        Me.dgvDocumenti.AllowUserToResizeRows = False
        Me.dgvDocumenti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDocumenti.BackgroundColor = System.Drawing.Color.PaleGreen
        Me.dgvDocumenti.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvDocumenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleGreen
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.GreenYellow
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDocumenti.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDocumenti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDocumenti.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvDocumenti.Location = New System.Drawing.Point(0, 344)
        Me.dgvDocumenti.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.dgvDocumenti.MultiSelect = False
        Me.dgvDocumenti.Name = "dgvDocumenti"
        Me.dgvDocumenti.ReadOnly = True
        Me.dgvDocumenti.RowHeadersVisible = False
        Me.dgvDocumenti.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDocumenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDocumenti.Size = New System.Drawing.Size(395, 121)
        Me.dgvDocumenti.TabIndex = 4
        '
        'LabelTitoloIncassi
        '
        Me.LabelTitoloIncassi.BackColor = System.Drawing.Color.SkyBlue
        Me.LabelTitoloIncassi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelTitoloIncassi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTitoloIncassi.Location = New System.Drawing.Point(0, 0)
        Me.LabelTitoloIncassi.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelTitoloIncassi.Name = "LabelTitoloIncassi"
        Me.LabelTitoloIncassi.Size = New System.Drawing.Size(395, 25)
        Me.LabelTitoloIncassi.TabIndex = 2
        Me.LabelTitoloIncassi.Text = "Incassi"
        Me.LabelTitoloIncassi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GrigliaIncassi
        '
        Me.GrigliaIncassi.AllowUserToAddRows = False
        Me.GrigliaIncassi.AllowUserToDeleteRows = False
        Me.GrigliaIncassi.AllowUserToResizeColumns = False
        Me.GrigliaIncassi.AllowUserToResizeRows = False
        Me.GrigliaIncassi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GrigliaIncassi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrigliaIncassi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrigliaIncassi.Location = New System.Drawing.Point(0, 28)
        Me.GrigliaIncassi.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.GrigliaIncassi.MultiSelect = False
        Me.GrigliaIncassi.Name = "GrigliaIncassi"
        Me.GrigliaIncassi.ReadOnly = True
        Me.GrigliaIncassi.RowHeadersVisible = False
        Me.GrigliaIncassi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrigliaIncassi.Size = New System.Drawing.Size(395, 197)
        Me.GrigliaIncassi.TabIndex = 0
        '
        'GrigliaArretrati
        '
        Me.GrigliaArretrati.AllowUserToAddRows = False
        Me.GrigliaArretrati.AllowUserToDeleteRows = False
        Me.GrigliaArretrati.AllowUserToResizeColumns = False
        Me.GrigliaArretrati.AllowUserToResizeRows = False
        Me.GrigliaArretrati.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GrigliaArretrati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrigliaArretrati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrigliaArretrati.Location = New System.Drawing.Point(0, 253)
        Me.GrigliaArretrati.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.GrigliaArretrati.MultiSelect = False
        Me.GrigliaArretrati.Name = "GrigliaArretrati"
        Me.GrigliaArretrati.ReadOnly = True
        Me.GrigliaArretrati.RowHeadersVisible = False
        Me.GrigliaArretrati.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrigliaArretrati.Size = New System.Drawing.Size(395, 63)
        Me.GrigliaArretrati.TabIndex = 0
        '
        'LabelTitoloArretrati
        '
        Me.LabelTitoloArretrati.BackColor = System.Drawing.Color.SkyBlue
        Me.LabelTitoloArretrati.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelTitoloArretrati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTitoloArretrati.Location = New System.Drawing.Point(0, 228)
        Me.LabelTitoloArretrati.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.LabelTitoloArretrati.Name = "LabelTitoloArretrati"
        Me.LabelTitoloArretrati.Size = New System.Drawing.Size(395, 22)
        Me.LabelTitoloArretrati.TabIndex = 2
        Me.LabelTitoloArretrati.Text = "Arretrati"
        Me.LabelTitoloArretrati.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'buttonVaiAIncasso
        '
        Me.buttonVaiAIncasso.BackColor = System.Drawing.Color.Lavender
        Me.buttonVaiAIncasso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttonVaiAIncasso.DefaultBorderSize = 1
        Me.buttonVaiAIncasso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonVaiAIncasso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonVaiAIncasso.Location = New System.Drawing.Point(0, 316)
        Me.buttonVaiAIncasso.Margin = New System.Windows.Forms.Padding(0)
        Me.buttonVaiAIncasso.Name = "buttonVaiAIncasso"
        Me.buttonVaiAIncasso.Size = New System.Drawing.Size(395, 25)
        Me.buttonVaiAIncasso.TabIndex = 9
        Me.buttonVaiAIncasso.Text = "Vai a incasso titoli"
        Me.buttonVaiAIncasso.UseVisualStyleBackColor = False
        '
        'TabPageNote
        '
        Me.TabPageNote.Location = New System.Drawing.Point(4, 29)
        Me.TabPageNote.Name = "TabPageNote"
        Me.TabPageNote.Size = New System.Drawing.Size(1228, 465)
        Me.TabPageNote.TabIndex = 5
        Me.TabPageNote.Text = "Note Cliente"
        Me.TabPageNote.UseVisualStyleBackColor = True
        '
        'TabPageSintesi
        '
        Me.TabPageSintesi.Location = New System.Drawing.Point(4, 29)
        Me.TabPageSintesi.Name = "TabPageSintesi"
        Me.TabPageSintesi.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageSintesi.Size = New System.Drawing.Size(1228, 465)
        Me.TabPageSintesi.TabIndex = 6
        Me.TabPageSintesi.Text = "Scheda Cliente"
        Me.TabPageSintesi.UseVisualStyleBackColor = True
        '
        'NavBar
        '
        Me.NavBar.AbilitaZoom = True
        Me.tlpClienti.SetColumnSpan(Me.NavBar, 3)
        Me.NavBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavBar.Location = New System.Drawing.Point(12, 75)
        Me.NavBar.Margin = New System.Windows.Forms.Padding(0)
        Me.NavBar.Name = "NavBar"
        Me.NavBar.Size = New System.Drawing.Size(338, 25)
        Me.NavBar.TabIndex = 1
        '
        'CheckBoxEsatto
        '
        Me.CheckBoxEsatto.Checked = True
        Me.CheckBoxEsatto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxEsatto.Location = New System.Drawing.Point(351, 46)
        Me.CheckBoxEsatto.Margin = New System.Windows.Forms.Padding(1)
        Me.CheckBoxEsatto.Name = "CheckBoxEsatto"
        Me.CheckBoxEsatto.Size = New System.Drawing.Size(146, 23)
        Me.CheckBoxEsatto.TabIndex = 3
        Me.CheckBoxEsatto.Text = "Corrispondenza esatta"
        Me.CheckBoxEsatto.UseVisualStyleBackColor = True
        '
        'LabelNumeroClienti
        '
        Me.LabelNumeroClienti.AutoSize = True
        Me.LabelNumeroClienti.BackColor = System.Drawing.Color.Gold
        Me.LabelNumeroClienti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelNumeroClienti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNumeroClienti.Location = New System.Drawing.Point(1091, 46)
        Me.LabelNumeroClienti.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelNumeroClienti.Name = "LabelNumeroClienti"
        Me.LabelNumeroClienti.Size = New System.Drawing.Size(150, 23)
        Me.LabelNumeroClienti.TabIndex = 4
        Me.LabelNumeroClienti.Text = "..."
        Me.LabelNumeroClienti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelSemaforoRicerca
        '
        Me.LabelSemaforoRicerca.BackColor = System.Drawing.Color.DodgerBlue
        Me.LabelSemaforoRicerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSemaforoRicerca.Location = New System.Drawing.Point(3, 45)
        Me.LabelSemaforoRicerca.Name = "LabelSemaforoRicerca"
        Me.LabelSemaforoRicerca.Size = New System.Drawing.Size(6, 25)
        Me.LabelSemaforoRicerca.TabIndex = 7
        '
        'LabelSemaforoSelezione
        '
        Me.LabelSemaforoSelezione.BackColor = System.Drawing.Color.Orange
        Me.LabelSemaforoSelezione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSemaforoSelezione.Location = New System.Drawing.Point(3, 75)
        Me.LabelSemaforoSelezione.Name = "LabelSemaforoSelezione"
        Me.LabelSemaforoSelezione.Size = New System.Drawing.Size(6, 25)
        Me.LabelSemaforoSelezione.TabIndex = 8
        '
        'LabelNominativo
        '
        Me.LabelNominativo.AutoEllipsis = True
        Me.LabelNominativo.AutoSize = True
        Me.LabelNominativo.BackColor = System.Drawing.Color.GreenYellow
        Me.LabelNominativo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpClienti.SetColumnSpan(Me.LabelNominativo, 2)
        Me.LabelNominativo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNominativo.Location = New System.Drawing.Point(351, 76)
        Me.LabelNominativo.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelNominativo.Name = "LabelNominativo"
        Me.LabelNominativo.Size = New System.Drawing.Size(294, 23)
        Me.LabelNominativo.TabIndex = 10
        Me.LabelNominativo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelIndirizzo
        '
        Me.LabelIndirizzo.AutoEllipsis = True
        Me.LabelIndirizzo.AutoSize = True
        Me.LabelIndirizzo.BackColor = System.Drawing.Color.LightYellow
        Me.LabelIndirizzo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpClienti.SetColumnSpan(Me.LabelIndirizzo, 2)
        Me.LabelIndirizzo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelIndirizzo.Location = New System.Drawing.Point(647, 76)
        Me.LabelIndirizzo.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelIndirizzo.Name = "LabelIndirizzo"
        Me.LabelIndirizzo.Size = New System.Drawing.Size(294, 23)
        Me.LabelIndirizzo.TabIndex = 10
        Me.LabelIndirizzo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'buttonCercaInEssig
        '
        Me.buttonCercaInEssig.BackColor = System.Drawing.Color.Lavender
        Me.buttonCercaInEssig.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttonCercaInEssig.DefaultBorderSize = 1
        Me.buttonCercaInEssig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonCercaInEssig.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.buttonCercaInEssig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonCercaInEssig.Location = New System.Drawing.Point(942, 75)
        Me.buttonCercaInEssig.Margin = New System.Windows.Forms.Padding(0)
        Me.buttonCercaInEssig.Name = "buttonCercaInEssig"
        Me.buttonCercaInEssig.Size = New System.Drawing.Size(148, 25)
        Me.buttonCercaInEssig.TabIndex = 9
        Me.buttonCercaInEssig.Text = "Cercalo in Essig"
        Me.buttonCercaInEssig.UseVisualStyleBackColor = True
        '
        'buttonCercaInCrm
        '
        Me.buttonCercaInCrm.BackColor = System.Drawing.Color.LightPink
        Me.buttonCercaInCrm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttonCercaInCrm.DefaultBorderSize = 1
        Me.buttonCercaInCrm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonCercaInCrm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonCercaInCrm.Location = New System.Drawing.Point(1090, 75)
        Me.buttonCercaInCrm.Margin = New System.Windows.Forms.Padding(0)
        Me.buttonCercaInCrm.Name = "buttonCercaInCrm"
        Me.buttonCercaInCrm.Size = New System.Drawing.Size(152, 25)
        Me.buttonCercaInCrm.TabIndex = 9
        Me.buttonCercaInCrm.Text = "Cercalo in CRM"
        Me.buttonCercaInCrm.UseVisualStyleBackColor = True
        '
        'CheckBoxTutti
        '
        Me.CheckBoxTutti.Location = New System.Drawing.Point(499, 46)
        Me.CheckBoxTutti.Margin = New System.Windows.Forms.Padding(1)
        Me.CheckBoxTutti.Name = "CheckBoxTutti"
        Me.CheckBoxTutti.Size = New System.Drawing.Size(146, 23)
        Me.CheckBoxTutti.TabIndex = 3
        Me.CheckBoxTutti.Text = "Mostra tutti i clienti"
        Me.CheckBoxTutti.UseVisualStyleBackColor = True
        '
        'ComboBoxStatoCliente
        '
        Me.tlpClienti.SetColumnSpan(Me.ComboBoxStatoCliente, 2)
        Me.ComboBoxStatoCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxStatoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxStatoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxStatoCliente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.ComboBoxStatoCliente.FormattingEnabled = True
        Me.ComboBoxStatoCliente.Location = New System.Drawing.Point(647, 46)
        Me.ComboBoxStatoCliente.Margin = New System.Windows.Forms.Padding(1)
        Me.ComboBoxStatoCliente.Name = "ComboBoxStatoCliente"
        Me.ComboBoxStatoCliente.Size = New System.Drawing.Size(294, 22)
        Me.ComboBoxStatoCliente.TabIndex = 5
        '
        'ComboBoxLayout
        '
        Me.ComboBoxLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxLayout.ForeColor = System.Drawing.Color.DodgerBlue
        Me.ComboBoxLayout.FormattingEnabled = True
        Me.ComboBoxLayout.Location = New System.Drawing.Point(795, 1)
        Me.ComboBoxLayout.Margin = New System.Windows.Forms.Padding(1)
        Me.ComboBoxLayout.Name = "ComboBoxLayout"
        Me.ComboBoxLayout.Size = New System.Drawing.Size(144, 22)
        Me.ComboBoxLayout.TabIndex = 5
        '
        'ButtonPulisciCasellaCerca
        '
        Me.ButtonPulisciCasellaCerca.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonPulisciCasellaCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonPulisciCasellaCerca.FlatAppearance.BorderSize = 0
        Me.ButtonPulisciCasellaCerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPulisciCasellaCerca.Location = New System.Drawing.Point(325, 45)
        Me.ButtonPulisciCasellaCerca.Margin = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.ButtonPulisciCasellaCerca.Name = "ButtonPulisciCasellaCerca"
        Me.ButtonPulisciCasellaCerca.Size = New System.Drawing.Size(25, 22)
        Me.ButtonPulisciCasellaCerca.TabIndex = 18
        Me.ButtonPulisciCasellaCerca.UseVisualStyleBackColor = True
        '
        'ButtonReset
        '
        Me.ButtonReset.BackColor = System.Drawing.Color.Moccasin
        Me.ButtonReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonReset.DefaultBorderSize = 1
        Me.ButtonReset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonReset.FlatAppearance.BorderColor = System.Drawing.Color.Salmon
        Me.ButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonReset.Location = New System.Drawing.Point(942, 45)
        Me.ButtonReset.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonReset.Name = "ButtonReset"
        Me.ButtonReset.Size = New System.Drawing.Size(148, 25)
        Me.ButtonReset.TabIndex = 9
        Me.ButtonReset.Text = "Reset"
        Me.ButtonReset.UseVisualStyleBackColor = False
        '
        'StatusStripClienti
        '
        Me.StatusStripClienti.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssMessaggio})
        Me.StatusStripClienti.Location = New System.Drawing.Point(3, 607)
        Me.StatusStripClienti.Name = "StatusStripClienti"
        Me.StatusStripClienti.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStripClienti.Size = New System.Drawing.Size(1242, 22)
        Me.StatusStripClienti.TabIndex = 3
        Me.StatusStripClienti.Text = "StatusStrip1"
        '
        'tssMessaggio
        '
        Me.tssMessaggio.Name = "tssMessaggio"
        Me.tssMessaggio.Size = New System.Drawing.Size(0, 17)
        '
        'tsMainMenu
        '
        Me.tsMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMainMenu.Name = "tsMainMenu"
        Me.tsMainMenu.Size = New System.Drawing.Size(100, 25)
        Me.tsMainMenu.TabIndex = 0
        '
        'ButtonDocumenti
        '
        Me.ButtonDocumenti.DefaultBorderSize = 0
        Me.ButtonDocumenti.FlatAppearance.BorderSize = 0
        Me.ButtonDocumenti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDocumenti.Location = New System.Drawing.Point(0, 0)
        Me.ButtonDocumenti.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonDocumenti.Name = "ButtonDocumenti"
        Me.ButtonDocumenti.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDocumenti.TabIndex = 0
        '
        'ButtonEsci
        '
        Me.ButtonEsci.DefaultBorderSize = 0
        Me.ButtonEsci.FlatAppearance.BorderSize = 0
        Me.ButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsci.Location = New System.Drawing.Point(0, 0)
        Me.ButtonEsci.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEsci.TabIndex = 0
        '
        'ButtonCai
        '
        Me.ButtonCai.DefaultBorderSize = 0
        Me.ButtonCai.FlatAppearance.BorderSize = 0
        Me.ButtonCai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCai.Location = New System.Drawing.Point(0, 0)
        Me.ButtonCai.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCai.Name = "ButtonCai"
        Me.ButtonCai.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCai.TabIndex = 0
        '
        'ButtonSinistri
        '
        Me.ButtonSinistri.DefaultBorderSize = 0
        Me.ButtonSinistri.FlatAppearance.BorderSize = 0
        Me.ButtonSinistri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSinistri.Location = New System.Drawing.Point(0, 0)
        Me.ButtonSinistri.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonSinistri.Name = "ButtonSinistri"
        Me.ButtonSinistri.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSinistri.TabIndex = 0
        '
        'ButtonSinistriCliente
        '
        Me.ButtonSinistriCliente.DefaultBorderSize = 0
        Me.ButtonSinistriCliente.FlatAppearance.BorderSize = 0
        Me.ButtonSinistriCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSinistriCliente.Location = New System.Drawing.Point(0, 0)
        Me.ButtonSinistriCliente.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonSinistriCliente.Name = "ButtonSinistriCliente"
        Me.ButtonSinistriCliente.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSinistriCliente.TabIndex = 0
        '
        'ButtonEvidenza
        '
        Me.ButtonEvidenza.DefaultBorderSize = 0
        Me.ButtonEvidenza.FlatAppearance.BorderSize = 0
        Me.ButtonEvidenza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEvidenza.Location = New System.Drawing.Point(0, 0)
        Me.ButtonEvidenza.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEvidenza.Name = "ButtonEvidenza"
        Me.ButtonEvidenza.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEvidenza.TabIndex = 0
        '
        'ButtonEvidenzeCliente
        '
        Me.ButtonEvidenzeCliente.DefaultBorderSize = 0
        Me.ButtonEvidenzeCliente.FlatAppearance.BorderSize = 0
        Me.ButtonEvidenzeCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEvidenzeCliente.Location = New System.Drawing.Point(0, 0)
        Me.ButtonEvidenzeCliente.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEvidenzeCliente.Name = "ButtonEvidenzeCliente"
        Me.ButtonEvidenzeCliente.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEvidenzeCliente.TabIndex = 0
        '
        'FormAnagrafiche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1248, 632)
        Me.Controls.Add(Me.tlpClienti)
        Me.Controls.Add(Me.StatusStripClienti)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Name = "FormAnagrafiche"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.Text = "Clienti"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tlpClienti.ResumeLayout(False)
        Me.tlpClienti.PerformLayout()
        Me.TabClienti.ResumeLayout(False)
        Me.TabPageElenco.ResumeLayout(False)
        Me.TabPageDettaglio.ResumeLayout(False)
        Me.TabPagePolizzeIncassi.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.GrigliaPolizze, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgvDocumenti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrigliaIncassi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrigliaArretrati, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStripClienti.ResumeLayout(False)
        Me.StatusStripClienti.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tlpClienti As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents StatusStripClienti As System.Windows.Forms.StatusStrip
    Friend WithEvents tssMessaggio As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabClienti As Utx.UtTabControl
    Friend WithEvents TabPageElenco As TabPage
    Friend WithEvents TabPageDettaglio As TabPage
    Friend WithEvents TabPagePolizzeIncassi As TabPage
    Friend WithEvents ElencoClienti As ucClienti
    Friend WithEvents DettaglioCliente As ucDettaglio
    Friend WithEvents tsMainMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents LabelNumeroClienti As System.Windows.Forms.Label
    Friend WithEvents CheckBoxEsatto As System.Windows.Forms.CheckBox
    Friend WithEvents LabelSemaforoRicerca As System.Windows.Forms.Label
    Friend WithEvents LabelSemaforoSelezione As System.Windows.Forms.Label
    Friend WithEvents ComboBoxLayout As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonDocumenti As UtControls.UtFlatButton
    Friend WithEvents ButtonEsci As UtControls.UtFlatButton
    Friend WithEvents ButtonEvidenza As UtControls.UtFlatButton
    Friend WithEvents ButtonEvidenzeCliente As UtControls.UtFlatButton
    Friend WithEvents ButtonCai As UtControls.UtFlatButton
    Friend WithEvents ButtonUeba As New UtControls.UtFlatButton
    Friend WithEvents ButtonOWA As New UtControls.UtFlatButton
    Friend WithEvents ButtonQuota As New UtControls.UtFlatButton
    Friend WithEvents ButtonSinistri As New UtControls.UtFlatButton
    Friend WithEvents ButtonSinistriCliente As New UtControls.UtFlatButton
    Friend WithEvents ButtonAssegni As New UtControls.UtFlatButton
    Friend WithEvents ButtonCopia As New UtControls.UtFlatButton
    Friend WithEvents ButtonLegami As New UtControls.UtFlatButton
    Friend WithEvents buttonComunica As New UtControls.UtFlatButton
    Friend WithEvents NavBar As UtControls.ucNavigationBar
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GrigliaIncassi As System.Windows.Forms.DataGridView
    Friend WithEvents buttonCercaInEssig As UtControls.UtFlatButton
    Friend WithEvents LabelNominativo As System.Windows.Forms.Label
    Friend WithEvents LabelIndirizzo As System.Windows.Forms.Label
    Friend WithEvents GrigliaPolizze As System.Windows.Forms.DataGridView
    Friend WithEvents LabelTitoloPolizze As System.Windows.Forms.Label
    Friend WithEvents LabelTitoloIncassi As System.Windows.Forms.Label
    Friend WithEvents buttonCercaInCrm As UtControls.UtFlatButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvDocumenti As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents labelIncassi As System.Windows.Forms.Label
    Friend WithEvents TabPageNote As System.Windows.Forms.TabPage
    Friend WithEvents TabPageSintesi As System.Windows.Forms.TabPage
    Friend WithEvents CheckBoxTutti As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxStatoCliente As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxCercaIn As System.Windows.Forms.ComboBox
    Friend WithEvents LabelCerca As System.Windows.Forms.Label
    Friend WithEvents ButtonPulisciCasellaCerca As System.Windows.Forms.Button
    Friend WithEvents ButtonReset As UtControls.UtFlatButton
    Friend WithEvents GrigliaArretrati As System.Windows.Forms.DataGridView
    Friend WithEvents LabelTitoloArretrati As System.Windows.Forms.Label
    Friend WithEvents buttonVaiAIncasso As UtControls.UtFlatButton
    Friend WithEvents LabelStorico As System.Windows.Forms.Label

End Class
