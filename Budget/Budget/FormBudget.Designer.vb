<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBudget
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBudget))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssStato = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssSomma = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnInserimento = New System.Windows.Forms.Button()
        Me.btnEstraiDati = New System.Windows.Forms.Button()
        Me.dtpDataAnalisi = New System.Windows.Forms.DateTimePicker()
        Me.cboAnnoInizio = New System.Windows.Forms.ComboBox()
        Me.chkAutoSize = New System.Windows.Forms.CheckBox()
        Me.btnNascondiColonna = New System.Windows.Forms.Button()
        Me.btnScopri = New System.Windows.Forms.Button()
        Me.btnNascondiMesi = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkBloccaColonne = New System.Windows.Forms.CheckBox()
        Me.udFontSize = New System.Windows.Forms.NumericUpDown()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.GroupBoxAnalisi = New System.Windows.Forms.GroupBox()
        Me.CheckBoxIndividuali = New System.Windows.Forms.CheckBox()
        Me.ComboBoxAgenzia = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDataInizioAnalisi = New System.Windows.Forms.DateTimePicker()
        Me.CheckBoxArretrati = New System.Windows.Forms.CheckBox()
        Me.ButtonAggiornaIncassi = New System.Windows.Forms.Button()
        Me.btnGestione = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboFigura = New System.Windows.Forms.ComboBox()
        Me.CheckBoxVitaOk = New System.Windows.Forms.CheckBox()
        Me.GroupBoxAspetto = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.GroupBoxDati = New System.Windows.Forms.GroupBox()
        Me.ButtonDettaglioProvvigioni = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.TabMain = New Utx.UtTabControl()
        Me.TabPageAnalisi = New System.Windows.Forms.TabPage()
        Me.TabAnalisi = New Utx.UtTabControl()
        Me.Rg = New System.Windows.Forms.TabPage()
        Me.dgvRamoGestione = New System.Windows.Forms.DataGridView()
        Me.Comparto = New System.Windows.Forms.TabPage()
        Me.dgvComparto = New System.Windows.Forms.DataGridView()
        Me.Settore = New System.Windows.Forms.TabPage()
        Me.dgvSettore = New System.Windows.Forms.DataGridView()
        Me.Aggregato = New System.Windows.Forms.TabPage()
        Me.dgvAggregato = New System.Windows.Forms.DataGridView()
        Me.Generale = New System.Windows.Forms.TabPage()
        Me.dgvGenerale = New System.Windows.Forms.DataGridView()
        Me.AnomalieAuto = New System.Windows.Forms.TabPage()
        Me.TextBoxAnomalie = New System.Windows.Forms.TextBox()
        Me.dgvAnomalie = New System.Windows.Forms.DataGridView()
        Me.Giornalieri = New System.Windows.Forms.TabPage()
        Me.tlpGiornalieri = New System.Windows.Forms.TableLayoutPanel()
        Me.ComboBoxAggregatoGiornalieri = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ButtonAnalisiDifferenze = New System.Windows.Forms.Button()
        Me.dgvGiornalieri = New System.Windows.Forms.DataGridView()
        Me.ComboBoxAnnoGiornalieri = New System.Windows.Forms.ComboBox()
        Me.ComboBoxMeseGiornalieri = New System.Windows.Forms.ComboBox()
        Me.ComboBoxRamoGestioneGiornalieri = New System.Windows.Forms.ComboBox()
        Me.ComboBoxCompartoGiornalieri = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ButtonVisualizzaGiornalieri = New System.Windows.Forms.Button()
        Me.Pezzi = New System.Windows.Forms.TabPage()
        Me.tsPezzi = New System.Windows.Forms.ToolStrip()
        Me.dgvMovimenti = New System.Windows.Forms.DataGridView()
        Me.Giornate = New System.Windows.Forms.TabPage()
        Me.dgvGiornate = New System.Windows.Forms.DataGridView()
        Me.TabPageVarie = New System.Windows.Forms.TabPage()
        Me.TabVarie = New Utx.UtTabControl()
        Me.Stornate = New System.Windows.Forms.TabPage()
        Me.dgvStornate = New System.Windows.Forms.DataGridView()
        Me.DeltaPremi = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvDelta = New System.Windows.Forms.DataGridView()
        Me.lbDeltaTotale = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBoxRgDelta = New System.Windows.Forms.ComboBox()
        Me.ButtonAggiornaDelta = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnEsportaElenco = New System.Windows.Forms.Button()
        Me.dgvDettaglioIncassi = New System.Windows.Forms.DataGridView()
        Me.btnEsportaDettaglio = New System.Windows.Forms.Button()
        Me.ButtonRichiestaCliente = New System.Windows.Forms.Button()
        Me.LabelDettaglioVariazioni = New System.Windows.Forms.Label()
        Me.LabelTotalePolizza = New System.Windows.Forms.Label()
        Me.dgvDeltaArretrati = New System.Windows.Forms.DataGridView()
        Me.LabelDeltaArretrati = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PremiUnici = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvPremiUnici = New System.Windows.Forms.DataGridView()
        Me.Arretrati = New System.Windows.Forms.TabPage()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnElencoArretrati = New System.Windows.Forms.ToolStripButton()
        Me.btnArretratiRg = New System.Windows.Forms.ToolStripButton()
        Me.btnArretratiComparto = New System.Windows.Forms.ToolStripButton()
        Me.txtCercaArretrati = New System.Windows.Forms.ToolStripTextBox()
        Me.btnCerca = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAggiornaArretrati = New System.Windows.Forms.ToolStripButton()
        Me.btnEsporta = New System.Windows.Forms.ToolStripButton()
        Me.LabelAggiornamentoArretrati = New System.Windows.Forms.ToolStripLabel()
        Me.dgvArretrati = New System.Windows.Forms.DataGridView()
        Me.Registro = New System.Windows.Forms.TabPage()
        Me.dgvRegistro = New System.Windows.Forms.DataGridView()
        Me.GroupBoxCodici = New System.Windows.Forms.GroupBox()
        Me.ButtonConfermaGruppo = New System.Windows.Forms.Button()
        Me.CheckedListBoxAgenzie = New System.Windows.Forms.CheckedListBox()
        Me.CheckBoxSub = New System.Windows.Forms.CheckBox()
        Me.CheckBoxProd = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.udFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxAnalisi.SuspendLayout()
        Me.GroupBoxAspetto.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBoxDati.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.TabPageAnalisi.SuspendLayout()
        Me.TabAnalisi.SuspendLayout()
        Me.Rg.SuspendLayout()
        CType(Me.dgvRamoGestione, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Comparto.SuspendLayout()
        CType(Me.dgvComparto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Settore.SuspendLayout()
        CType(Me.dgvSettore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Aggregato.SuspendLayout()
        CType(Me.dgvAggregato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Generale.SuspendLayout()
        CType(Me.dgvGenerale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AnomalieAuto.SuspendLayout()
        CType(Me.dgvAnomalie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Giornalieri.SuspendLayout()
        Me.tlpGiornalieri.SuspendLayout()
        CType(Me.dgvGiornalieri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pezzi.SuspendLayout()
        CType(Me.dgvMovimenti, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Giornate.SuspendLayout()
        CType(Me.dgvGiornate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageVarie.SuspendLayout()
        Me.TabVarie.SuspendLayout()
        Me.Stornate.SuspendLayout()
        CType(Me.dgvStornate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DeltaPremi.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dgvDelta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvDettaglioIncassi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDeltaArretrati, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PremiUnici.SuspendLayout()
        CType(Me.dgvPremiUnici, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Arretrati.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvArretrati, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Registro.SuspendLayout()
        CType(Me.dgvRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxCodici.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssStato, Me.tssSomma})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 640)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1523, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssStato
        '
        Me.tssStato.Name = "tssStato"
        Me.tssStato.Size = New System.Drawing.Size(0, 17)
        '
        'tssSomma
        '
        Me.tssSomma.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.tssSomma.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tssSomma.Name = "tssSomma"
        Me.tssSomma.Size = New System.Drawing.Size(0, 17)
        '
        'btnInserimento
        '
        Me.btnInserimento.BackColor = System.Drawing.SystemColors.Control
        Me.btnInserimento.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btnInserimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInserimento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInserimento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnInserimento.Location = New System.Drawing.Point(8, 16)
        Me.btnInserimento.Name = "btnInserimento"
        Me.btnInserimento.Size = New System.Drawing.Size(125, 31)
        Me.btnInserimento.TabIndex = 0
        Me.btnInserimento.Text = "Inserimento budget"
        Me.btnInserimento.UseVisualStyleBackColor = False
        '
        'btnEstraiDati
        '
        Me.btnEstraiDati.BackColor = System.Drawing.SystemColors.Control
        Me.btnEstraiDati.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btnEstraiDati.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEstraiDati.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEstraiDati.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEstraiDati.Image = CType(resources.GetObject("btnEstraiDati.Image"), System.Drawing.Image)
        Me.btnEstraiDati.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEstraiDati.Location = New System.Drawing.Point(136, 117)
        Me.btnEstraiDati.Name = "btnEstraiDati"
        Me.btnEstraiDati.Size = New System.Drawing.Size(141, 31)
        Me.btnEstraiDati.TabIndex = 7
        Me.btnEstraiDati.Text = "Analizza incassi"
        Me.btnEstraiDati.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEstraiDati.UseVisualStyleBackColor = False
        '
        'dtpDataAnalisi
        '
        Me.dtpDataAnalisi.CustomFormat = "dd-MM-yyyy"
        Me.dtpDataAnalisi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDataAnalisi.Location = New System.Drawing.Point(197, 16)
        Me.dtpDataAnalisi.Name = "dtpDataAnalisi"
        Me.dtpDataAnalisi.Size = New System.Drawing.Size(80, 20)
        Me.dtpDataAnalisi.TabIndex = 1
        '
        'cboAnnoInizio
        '
        Me.cboAnnoInizio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnnoInizio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAnnoInizio.FormattingEnabled = True
        Me.cboAnnoInizio.Location = New System.Drawing.Point(81, 42)
        Me.cboAnnoInizio.Name = "cboAnnoInizio"
        Me.cboAnnoInizio.Size = New System.Drawing.Size(61, 21)
        Me.cboAnnoInizio.TabIndex = 2
        '
        'chkAutoSize
        '
        Me.chkAutoSize.AutoSize = True
        Me.chkAutoSize.Checked = True
        Me.chkAutoSize.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAutoSize.Location = New System.Drawing.Point(184, 16)
        Me.chkAutoSize.Name = "chkAutoSize"
        Me.chkAutoSize.Size = New System.Drawing.Size(165, 17)
        Me.chkAutoSize.TabIndex = 3
        Me.chkAutoSize.Text = "Ridimenziona righe e colonne"
        Me.chkAutoSize.UseVisualStyleBackColor = True
        '
        'btnNascondiColonna
        '
        Me.btnNascondiColonna.BackColor = System.Drawing.SystemColors.Control
        Me.btnNascondiColonna.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btnNascondiColonna.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNascondiColonna.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNascondiColonna.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNascondiColonna.Location = New System.Drawing.Point(6, 55)
        Me.btnNascondiColonna.Name = "btnNascondiColonna"
        Me.btnNascondiColonna.Size = New System.Drawing.Size(161, 33)
        Me.btnNascondiColonna.TabIndex = 1
        Me.btnNascondiColonna.Text = "Nascondi colonne selezionate"
        Me.btnNascondiColonna.UseVisualStyleBackColor = False
        '
        'btnScopri
        '
        Me.btnScopri.BackColor = System.Drawing.SystemColors.Control
        Me.btnScopri.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btnScopri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScopri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScopri.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnScopri.Location = New System.Drawing.Point(6, 94)
        Me.btnScopri.Name = "btnScopri"
        Me.btnScopri.Size = New System.Drawing.Size(161, 33)
        Me.btnScopri.TabIndex = 2
        Me.btnScopri.Text = "Scopri tutte le colonne"
        Me.btnScopri.UseVisualStyleBackColor = False
        '
        'btnNascondiMesi
        '
        Me.btnNascondiMesi.BackColor = System.Drawing.SystemColors.Control
        Me.btnNascondiMesi.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btnNascondiMesi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNascondiMesi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNascondiMesi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNascondiMesi.Location = New System.Drawing.Point(6, 16)
        Me.btnNascondiMesi.Name = "btnNascondiMesi"
        Me.btnNascondiMesi.Size = New System.Drawing.Size(161, 33)
        Me.btnNascondiMesi.TabIndex = 0
        Me.btnNascondiMesi.Text = "Nascondi colonne dei mesi"
        Me.btnNascondiMesi.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(10, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Analisi dal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(10, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Raffronto su"
        '
        'chkBloccaColonne
        '
        Me.chkBloccaColonne.AutoSize = True
        Me.chkBloccaColonne.Checked = True
        Me.chkBloccaColonne.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBloccaColonne.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBloccaColonne.Location = New System.Drawing.Point(184, 55)
        Me.chkBloccaColonne.Name = "chkBloccaColonne"
        Me.chkBloccaColonne.Size = New System.Drawing.Size(100, 17)
        Me.chkBloccaColonne.TabIndex = 4
        Me.chkBloccaColonne.Text = "Blocca colonne"
        Me.chkBloccaColonne.UseVisualStyleBackColor = True
        '
        'udFontSize
        '
        Me.udFontSize.Location = New System.Drawing.Point(292, 92)
        Me.udFontSize.Name = "udFontSize"
        Me.udFontSize.Size = New System.Drawing.Size(49, 20)
        Me.udFontSize.TabIndex = 6
        Me.udFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnEsci
        '
        Me.btnEsci.BackColor = System.Drawing.SystemColors.Control
        Me.btnEsci.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btnEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEsci.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEsci.Location = New System.Drawing.Point(8, 75)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(123, 53)
        Me.btnEsci.TabIndex = 1
        Me.btnEsci.Text = "Esci"
        Me.btnEsci.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEsci.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnEsci.UseVisualStyleBackColor = False
        '
        'GroupBoxAnalisi
        '
        Me.GroupBoxAnalisi.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBoxAnalisi.Controls.Add(Me.CheckBoxProd)
        Me.GroupBoxAnalisi.Controls.Add(Me.CheckBoxSub)
        Me.GroupBoxAnalisi.Controls.Add(Me.CheckBoxIndividuali)
        Me.GroupBoxAnalisi.Controls.Add(Me.ComboBoxAgenzia)
        Me.GroupBoxAnalisi.Controls.Add(Me.Label14)
        Me.GroupBoxAnalisi.Controls.Add(Me.Label8)
        Me.GroupBoxAnalisi.Controls.Add(Me.dtpDataInizioAnalisi)
        Me.GroupBoxAnalisi.Controls.Add(Me.CheckBoxArretrati)
        Me.GroupBoxAnalisi.Controls.Add(Me.ButtonAggiornaIncassi)
        Me.GroupBoxAnalisi.Controls.Add(Me.btnGestione)
        Me.GroupBoxAnalisi.Controls.Add(Me.Label6)
        Me.GroupBoxAnalisi.Controls.Add(Me.cboFigura)
        Me.GroupBoxAnalisi.Controls.Add(Me.btnEstraiDati)
        Me.GroupBoxAnalisi.Controls.Add(Me.cboAnnoInizio)
        Me.GroupBoxAnalisi.Controls.Add(Me.CheckBoxVitaOk)
        Me.GroupBoxAnalisi.Controls.Add(Me.dtpDataAnalisi)
        Me.GroupBoxAnalisi.Controls.Add(Me.Label1)
        Me.GroupBoxAnalisi.Controls.Add(Me.Label2)
        Me.GroupBoxAnalisi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxAnalisi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBoxAnalisi.Location = New System.Drawing.Point(3, 3)
        Me.GroupBoxAnalisi.Name = "GroupBoxAnalisi"
        Me.GroupBoxAnalisi.Size = New System.Drawing.Size(479, 154)
        Me.GroupBoxAnalisi.TabIndex = 0
        Me.GroupBoxAnalisi.TabStop = False
        Me.GroupBoxAnalisi.Text = "Analisi"
        '
        'CheckBoxIndividuali
        '
        Me.CheckBoxIndividuali.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CheckBoxIndividuali.Location = New System.Drawing.Point(283, 113)
        Me.CheckBoxIndividuali.Name = "CheckBoxIndividuali"
        Me.CheckBoxIndividuali.Size = New System.Drawing.Size(95, 35)
        Me.CheckBoxIndividuali.TabIndex = 24
        Me.CheckBoxIndividuali.Text = "CheckBox1"
        Me.CheckBoxIndividuali.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CheckBoxIndividuali.UseVisualStyleBackColor = True
        '
        'ComboBoxAgenzia
        '
        Me.ComboBoxAgenzia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAgenzia.FormattingEnabled = True
        Me.ComboBoxAgenzia.Location = New System.Drawing.Point(215, 42)
        Me.ComboBoxAgenzia.Name = "ComboBoxAgenzia"
        Me.ComboBoxAgenzia.Size = New System.Drawing.Size(62, 21)
        Me.ComboBoxAgenzia.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label14.Location = New System.Drawing.Point(148, 45)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Incorporata"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(175, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "al"
        '
        'dtpDataInizioAnalisi
        '
        Me.dtpDataInizioAnalisi.CustomFormat = "dd-MM-yyyy"
        Me.dtpDataInizioAnalisi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDataInizioAnalisi.Location = New System.Drawing.Point(70, 16)
        Me.dtpDataInizioAnalisi.Name = "dtpDataInizioAnalisi"
        Me.dtpDataInizioAnalisi.Size = New System.Drawing.Size(80, 20)
        Me.dtpDataInizioAnalisi.TabIndex = 0
        '
        'CheckBoxArretrati
        '
        Me.CheckBoxArretrati.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxArretrati.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBoxArretrati.Location = New System.Drawing.Point(384, 15)
        Me.CheckBoxArretrati.Name = "CheckBoxArretrati"
        Me.CheckBoxArretrati.Size = New System.Drawing.Size(91, 133)
        Me.CheckBoxArretrati.TabIndex = 9
        Me.CheckBoxArretrati.Text = "CheckBox1"
        Me.CheckBoxArretrati.UseVisualStyleBackColor = True
        '
        'ButtonAggiornaIncassi
        '
        Me.ButtonAggiornaIncassi.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.ButtonAggiornaIncassi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAggiornaIncassi.Location = New System.Drawing.Point(10, 117)
        Me.ButtonAggiornaIncassi.Name = "ButtonAggiornaIncassi"
        Me.ButtonAggiornaIncassi.Size = New System.Drawing.Size(120, 31)
        Me.ButtonAggiornaIncassi.TabIndex = 6
        Me.ButtonAggiornaIncassi.Text = "Aggiorna incassi"
        Me.ButtonAggiornaIncassi.UseVisualStyleBackColor = True
        '
        'btnGestione
        '
        Me.btnGestione.BackColor = System.Drawing.SystemColors.Control
        Me.btnGestione.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btnGestione.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGestione.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGestione.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGestione.Location = New System.Drawing.Point(196, 69)
        Me.btnGestione.Name = "btnGestione"
        Me.btnGestione.Size = New System.Drawing.Size(81, 21)
        Me.btnGestione.TabIndex = 5
        Me.btnGestione.Text = "Gestione"
        Me.btnGestione.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(10, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Figura"
        '
        'cboFigura
        '
        Me.cboFigura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFigura.DropDownWidth = 218
        Me.cboFigura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFigura.FormattingEnabled = True
        Me.cboFigura.Location = New System.Drawing.Point(50, 69)
        Me.cboFigura.MaxDropDownItems = 15
        Me.cboFigura.Name = "cboFigura"
        Me.cboFigura.Size = New System.Drawing.Size(140, 21)
        Me.cboFigura.TabIndex = 4
        '
        'CheckBoxVitaOk
        '
        Me.CheckBoxVitaOk.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxVitaOk.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBoxVitaOk.Location = New System.Drawing.Point(283, 14)
        Me.CheckBoxVitaOk.Name = "CheckBoxVitaOk"
        Me.CheckBoxVitaOk.Size = New System.Drawing.Size(95, 95)
        Me.CheckBoxVitaOk.TabIndex = 8
        Me.CheckBoxVitaOk.Text = "CheckBox1"
        Me.CheckBoxVitaOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxVitaOk.UseVisualStyleBackColor = True
        '
        'GroupBoxAspetto
        '
        Me.GroupBoxAspetto.Controls.Add(Me.Label3)
        Me.GroupBoxAspetto.Controls.Add(Me.btnScopri)
        Me.GroupBoxAspetto.Controls.Add(Me.btnNascondiColonna)
        Me.GroupBoxAspetto.Controls.Add(Me.btnNascondiMesi)
        Me.GroupBoxAspetto.Controls.Add(Me.udFontSize)
        Me.GroupBoxAspetto.Controls.Add(Me.chkAutoSize)
        Me.GroupBoxAspetto.Controls.Add(Me.chkBloccaColonne)
        Me.GroupBoxAspetto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxAspetto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBoxAspetto.Location = New System.Drawing.Point(736, 3)
        Me.GroupBoxAspetto.Name = "GroupBoxAspetto"
        Me.GroupBoxAspetto.Size = New System.Drawing.Size(364, 154)
        Me.GroupBoxAspetto.TabIndex = 2
        Me.GroupBoxAspetto.TabStop = False
        Me.GroupBoxAspetto.Text = "Aspetto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(183, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Dimensione caratteri"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnHelp)
        Me.GroupBox3.Controls.Add(Me.btnEsci)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox3.Location = New System.Drawing.Point(1383, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(137, 154)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.SystemColors.Control
        Me.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHelp.Location = New System.Drawing.Point(7, 15)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(123, 53)
        Me.btnHelp.TabIndex = 0
        Me.btnHelp.Text = "Guida"
        Me.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'GroupBoxDati
        '
        Me.GroupBoxDati.Controls.Add(Me.ButtonDettaglioProvvigioni)
        Me.GroupBoxDati.Controls.Add(Me.btnExcel)
        Me.GroupBoxDati.Controls.Add(Me.btnInserimento)
        Me.GroupBoxDati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxDati.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBoxDati.Location = New System.Drawing.Point(586, 3)
        Me.GroupBoxDati.Name = "GroupBoxDati"
        Me.GroupBoxDati.Size = New System.Drawing.Size(144, 154)
        Me.GroupBoxDati.TabIndex = 1
        Me.GroupBoxDati.TabStop = False
        Me.GroupBoxDati.Text = "Dati"
        '
        'ButtonDettaglioProvvigioni
        '
        Me.ButtonDettaglioProvvigioni.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonDettaglioProvvigioni.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.ButtonDettaglioProvvigioni.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDettaglioProvvigioni.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonDettaglioProvvigioni.Location = New System.Drawing.Point(8, 84)
        Me.ButtonDettaglioProvvigioni.Name = "ButtonDettaglioProvvigioni"
        Me.ButtonDettaglioProvvigioni.Size = New System.Drawing.Size(125, 43)
        Me.ButtonDettaglioProvvigioni.TabIndex = 2
        Me.ButtonDettaglioProvvigioni.Text = "Dettaglio provvigioni"
        Me.ButtonDettaglioProvvigioni.UseVisualStyleBackColor = False
        '
        'btnExcel
        '
        Me.btnExcel.BackColor = System.Drawing.SystemColors.Control
        Me.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnExcel.Location = New System.Drawing.Point(8, 51)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(125, 30)
        Me.btnExcel.TabIndex = 1
        Me.btnExcel.Text = "Esporta in CSV"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 5
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 485.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 370.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.GroupBox3, 4, 0)
        Me.tlpMain.Controls.Add(Me.TabMain, 0, 1)
        Me.tlpMain.Controls.Add(Me.GroupBoxAspetto, 3, 0)
        Me.tlpMain.Controls.Add(Me.GroupBoxAnalisi, 0, 0)
        Me.tlpMain.Controls.Add(Me.GroupBoxDati, 2, 0)
        Me.tlpMain.Controls.Add(Me.GroupBoxCodici, 1, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(1523, 640)
        Me.tlpMain.TabIndex = 7
        '
        'TabMain
        '
        Me.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.CONTROL
        Me.tlpMain.SetColumnSpan(Me.TabMain, 5)
        Me.TabMain.Controls.Add(Me.TabPageAnalisi)
        Me.TabMain.Controls.Add(Me.TabPageVarie)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabMain.ItemSize = New System.Drawing.Size(81, 19)
        Me.TabMain.Location = New System.Drawing.Point(3, 163)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1517, 474)
        Me.TabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabMain.TabIndex = 0
        Me.TabMain.Visible = False
        '
        'TabPageAnalisi
        '
        Me.TabPageAnalisi.BackColor = System.Drawing.Color.Transparent
        Me.TabPageAnalisi.Controls.Add(Me.TabAnalisi)
        Me.TabPageAnalisi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TabPageAnalisi.Location = New System.Drawing.Point(4, 23)
        Me.TabPageAnalisi.Name = "TabPageAnalisi"
        Me.TabPageAnalisi.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageAnalisi.Size = New System.Drawing.Size(1509, 447)
        Me.TabPageAnalisi.TabIndex = 0
        Me.TabPageAnalisi.Text = "Analisi incassi"
        '
        'TabAnalisi
        '
        Me.TabAnalisi.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabAnalisi.ColorStyle = Utx.UtTabControl.TabColorStyle.VERDE
        Me.TabAnalisi.Controls.Add(Me.Rg)
        Me.TabAnalisi.Controls.Add(Me.Comparto)
        Me.TabAnalisi.Controls.Add(Me.Settore)
        Me.TabAnalisi.Controls.Add(Me.Aggregato)
        Me.TabAnalisi.Controls.Add(Me.Generale)
        Me.TabAnalisi.Controls.Add(Me.AnomalieAuto)
        Me.TabAnalisi.Controls.Add(Me.Giornalieri)
        Me.TabAnalisi.Controls.Add(Me.Pezzi)
        Me.TabAnalisi.Controls.Add(Me.Giornate)
        Me.TabAnalisi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabAnalisi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabAnalisi.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabAnalisi.Location = New System.Drawing.Point(3, 3)
        Me.TabAnalisi.Name = "TabAnalisi"
        Me.TabAnalisi.SelectedIndex = 0
        Me.TabAnalisi.Size = New System.Drawing.Size(1503, 441)
        Me.TabAnalisi.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabAnalisi.TabIndex = 0
        Me.TabAnalisi.Visible = False
        '
        'Rg
        '
        Me.Rg.Controls.Add(Me.dgvRamoGestione)
        Me.Rg.Location = New System.Drawing.Point(4, 29)
        Me.Rg.Name = "Rg"
        Me.Rg.Padding = New System.Windows.Forms.Padding(2)
        Me.Rg.Size = New System.Drawing.Size(1495, 408)
        Me.Rg.TabIndex = 0
        Me.Rg.Text = "Ramo gestione"
        Me.Rg.UseVisualStyleBackColor = True
        '
        'dgvRamoGestione
        '
        Me.dgvRamoGestione.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRamoGestione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRamoGestione.Location = New System.Drawing.Point(2, 2)
        Me.dgvRamoGestione.Name = "dgvRamoGestione"
        Me.dgvRamoGestione.Size = New System.Drawing.Size(1491, 404)
        Me.dgvRamoGestione.TabIndex = 0
        '
        'Comparto
        '
        Me.Comparto.Controls.Add(Me.dgvComparto)
        Me.Comparto.Location = New System.Drawing.Point(4, 29)
        Me.Comparto.Name = "Comparto"
        Me.Comparto.Padding = New System.Windows.Forms.Padding(2)
        Me.Comparto.Size = New System.Drawing.Size(1495, 428)
        Me.Comparto.TabIndex = 1
        Me.Comparto.Text = "Comparto - Budget"
        Me.Comparto.UseVisualStyleBackColor = True
        '
        'dgvComparto
        '
        Me.dgvComparto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComparto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvComparto.Location = New System.Drawing.Point(2, 2)
        Me.dgvComparto.Name = "dgvComparto"
        Me.dgvComparto.Size = New System.Drawing.Size(1491, 424)
        Me.dgvComparto.TabIndex = 2
        '
        'Settore
        '
        Me.Settore.Controls.Add(Me.dgvSettore)
        Me.Settore.Location = New System.Drawing.Point(4, 29)
        Me.Settore.Name = "Settore"
        Me.Settore.Padding = New System.Windows.Forms.Padding(2)
        Me.Settore.Size = New System.Drawing.Size(1495, 428)
        Me.Settore.TabIndex = 2
        Me.Settore.Text = "Settore"
        Me.Settore.UseVisualStyleBackColor = True
        '
        'dgvSettore
        '
        Me.dgvSettore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSettore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSettore.Location = New System.Drawing.Point(2, 2)
        Me.dgvSettore.Name = "dgvSettore"
        Me.dgvSettore.Size = New System.Drawing.Size(1491, 424)
        Me.dgvSettore.TabIndex = 2
        '
        'Aggregato
        '
        Me.Aggregato.Controls.Add(Me.dgvAggregato)
        Me.Aggregato.Location = New System.Drawing.Point(4, 29)
        Me.Aggregato.Name = "Aggregato"
        Me.Aggregato.Padding = New System.Windows.Forms.Padding(2)
        Me.Aggregato.Size = New System.Drawing.Size(1495, 428)
        Me.Aggregato.TabIndex = 3
        Me.Aggregato.Text = "Aggregato"
        Me.Aggregato.UseVisualStyleBackColor = True
        '
        'dgvAggregato
        '
        Me.dgvAggregato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAggregato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAggregato.Location = New System.Drawing.Point(2, 2)
        Me.dgvAggregato.Name = "dgvAggregato"
        Me.dgvAggregato.Size = New System.Drawing.Size(1491, 424)
        Me.dgvAggregato.TabIndex = 3
        '
        'Generale
        '
        Me.Generale.Controls.Add(Me.dgvGenerale)
        Me.Generale.Location = New System.Drawing.Point(4, 29)
        Me.Generale.Name = "Generale"
        Me.Generale.Padding = New System.Windows.Forms.Padding(2)
        Me.Generale.Size = New System.Drawing.Size(1495, 428)
        Me.Generale.TabIndex = 4
        Me.Generale.Text = "Generale"
        Me.Generale.UseVisualStyleBackColor = True
        '
        'dgvGenerale
        '
        Me.dgvGenerale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGenerale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGenerale.Location = New System.Drawing.Point(2, 2)
        Me.dgvGenerale.Name = "dgvGenerale"
        Me.dgvGenerale.Size = New System.Drawing.Size(1491, 424)
        Me.dgvGenerale.TabIndex = 3
        '
        'AnomalieAuto
        '
        Me.AnomalieAuto.BackColor = System.Drawing.Color.Transparent
        Me.AnomalieAuto.Controls.Add(Me.TextBoxAnomalie)
        Me.AnomalieAuto.Controls.Add(Me.dgvAnomalie)
        Me.AnomalieAuto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.AnomalieAuto.Location = New System.Drawing.Point(4, 29)
        Me.AnomalieAuto.Name = "AnomalieAuto"
        Me.AnomalieAuto.Padding = New System.Windows.Forms.Padding(2)
        Me.AnomalieAuto.Size = New System.Drawing.Size(1495, 428)
        Me.AnomalieAuto.TabIndex = 9
        Me.AnomalieAuto.Text = "Anomalie rami auto"
        '
        'TextBoxAnomalie
        '
        Me.TextBoxAnomalie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxAnomalie.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAnomalie.Location = New System.Drawing.Point(2, 270)
        Me.TextBoxAnomalie.Multiline = True
        Me.TextBoxAnomalie.Name = "TextBoxAnomalie"
        Me.TextBoxAnomalie.Size = New System.Drawing.Size(1491, 156)
        Me.TextBoxAnomalie.TabIndex = 3
        '
        'dgvAnomalie
        '
        Me.dgvAnomalie.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAnomalie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAnomalie.Location = New System.Drawing.Point(2, 3)
        Me.dgvAnomalie.Name = "dgvAnomalie"
        Me.dgvAnomalie.Size = New System.Drawing.Size(1491, 264)
        Me.dgvAnomalie.TabIndex = 2
        '
        'Giornalieri
        '
        Me.Giornalieri.Controls.Add(Me.tlpGiornalieri)
        Me.Giornalieri.Location = New System.Drawing.Point(4, 29)
        Me.Giornalieri.Name = "Giornalieri"
        Me.Giornalieri.Size = New System.Drawing.Size(1495, 428)
        Me.Giornalieri.TabIndex = 13
        Me.Giornalieri.Text = "Incassi giornalieri"
        Me.Giornalieri.UseVisualStyleBackColor = True
        '
        'tlpGiornalieri
        '
        Me.tlpGiornalieri.BackColor = System.Drawing.SystemColors.Control
        Me.tlpGiornalieri.ColumnCount = 12
        Me.tlpGiornalieri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.tlpGiornalieri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.tlpGiornalieri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.tlpGiornalieri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.tlpGiornalieri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.tlpGiornalieri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.tlpGiornalieri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.tlpGiornalieri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.tlpGiornalieri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.tlpGiornalieri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.tlpGiornalieri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.tlpGiornalieri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.tlpGiornalieri.Controls.Add(Me.ComboBoxAggregatoGiornalieri, 5, 0)
        Me.tlpGiornalieri.Controls.Add(Me.Label13, 4, 0)
        Me.tlpGiornalieri.Controls.Add(Me.ButtonAnalisiDifferenze, 11, 0)
        Me.tlpGiornalieri.Controls.Add(Me.dgvGiornalieri, 0, 1)
        Me.tlpGiornalieri.Controls.Add(Me.ComboBoxAnnoGiornalieri, 1, 0)
        Me.tlpGiornalieri.Controls.Add(Me.ComboBoxMeseGiornalieri, 3, 0)
        Me.tlpGiornalieri.Controls.Add(Me.ComboBoxRamoGestioneGiornalieri, 9, 0)
        Me.tlpGiornalieri.Controls.Add(Me.ComboBoxCompartoGiornalieri, 7, 0)
        Me.tlpGiornalieri.Controls.Add(Me.Label9, 0, 0)
        Me.tlpGiornalieri.Controls.Add(Me.Label10, 2, 0)
        Me.tlpGiornalieri.Controls.Add(Me.Label11, 8, 0)
        Me.tlpGiornalieri.Controls.Add(Me.Label12, 6, 0)
        Me.tlpGiornalieri.Controls.Add(Me.ButtonVisualizzaGiornalieri, 10, 0)
        Me.tlpGiornalieri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpGiornalieri.Location = New System.Drawing.Point(0, 0)
        Me.tlpGiornalieri.Name = "tlpGiornalieri"
        Me.tlpGiornalieri.RowCount = 2
        Me.tlpGiornalieri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlpGiornalieri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpGiornalieri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpGiornalieri.Size = New System.Drawing.Size(1495, 428)
        Me.tlpGiornalieri.TabIndex = 2
        '
        'ComboBoxAggregatoGiornalieri
        '
        Me.ComboBoxAggregatoGiornalieri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxAggregatoGiornalieri.FormattingEnabled = True
        Me.ComboBoxAggregatoGiornalieri.Location = New System.Drawing.Point(623, 3)
        Me.ComboBoxAggregatoGiornalieri.Name = "ComboBoxAggregatoGiornalieri"
        Me.ComboBoxAggregatoGiornalieri.Size = New System.Drawing.Size(118, 22)
        Me.ComboBoxAggregatoGiornalieri.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Teal
        Me.Label13.Location = New System.Drawing.Point(499, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(118, 27)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Aggregato"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonAnalisiDifferenze
        '
        Me.ButtonAnalisiDifferenze.BackColor = System.Drawing.Color.Orange
        Me.ButtonAnalisiDifferenze.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnalisiDifferenze.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonAnalisiDifferenze.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnalisiDifferenze.Location = New System.Drawing.Point(1367, 3)
        Me.ButtonAnalisiDifferenze.Name = "ButtonAnalisiDifferenze"
        Me.ButtonAnalisiDifferenze.Size = New System.Drawing.Size(125, 21)
        Me.ButtonAnalisiDifferenze.TabIndex = 10
        Me.ButtonAnalisiDifferenze.Text = "Variazioni"
        Me.ButtonAnalisiDifferenze.UseVisualStyleBackColor = False
        '
        'dgvGiornalieri
        '
        Me.dgvGiornalieri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpGiornalieri.SetColumnSpan(Me.dgvGiornalieri, 12)
        Me.dgvGiornalieri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGiornalieri.Location = New System.Drawing.Point(3, 30)
        Me.dgvGiornalieri.Name = "dgvGiornalieri"
        Me.dgvGiornalieri.Size = New System.Drawing.Size(1489, 395)
        Me.dgvGiornalieri.TabIndex = 0
        '
        'ComboBoxAnnoGiornalieri
        '
        Me.ComboBoxAnnoGiornalieri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxAnnoGiornalieri.FormattingEnabled = True
        Me.ComboBoxAnnoGiornalieri.Location = New System.Drawing.Point(127, 3)
        Me.ComboBoxAnnoGiornalieri.Name = "ComboBoxAnnoGiornalieri"
        Me.ComboBoxAnnoGiornalieri.Size = New System.Drawing.Size(118, 22)
        Me.ComboBoxAnnoGiornalieri.TabIndex = 1
        '
        'ComboBoxMeseGiornalieri
        '
        Me.ComboBoxMeseGiornalieri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxMeseGiornalieri.FormattingEnabled = True
        Me.ComboBoxMeseGiornalieri.Location = New System.Drawing.Point(375, 3)
        Me.ComboBoxMeseGiornalieri.Name = "ComboBoxMeseGiornalieri"
        Me.ComboBoxMeseGiornalieri.Size = New System.Drawing.Size(118, 22)
        Me.ComboBoxMeseGiornalieri.TabIndex = 2
        '
        'ComboBoxRamoGestioneGiornalieri
        '
        Me.ComboBoxRamoGestioneGiornalieri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxRamoGestioneGiornalieri.FormattingEnabled = True
        Me.ComboBoxRamoGestioneGiornalieri.Location = New System.Drawing.Point(1119, 3)
        Me.ComboBoxRamoGestioneGiornalieri.Name = "ComboBoxRamoGestioneGiornalieri"
        Me.ComboBoxRamoGestioneGiornalieri.Size = New System.Drawing.Size(118, 22)
        Me.ComboBoxRamoGestioneGiornalieri.TabIndex = 3
        '
        'ComboBoxCompartoGiornalieri
        '
        Me.ComboBoxCompartoGiornalieri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxCompartoGiornalieri.FormattingEnabled = True
        Me.ComboBoxCompartoGiornalieri.Location = New System.Drawing.Point(871, 3)
        Me.ComboBoxCompartoGiornalieri.Name = "ComboBoxCompartoGiornalieri"
        Me.ComboBoxCompartoGiornalieri.Size = New System.Drawing.Size(118, 22)
        Me.ComboBoxCompartoGiornalieri.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Teal
        Me.Label9.Location = New System.Drawing.Point(3, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(118, 27)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Anno"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Teal
        Me.Label10.Location = New System.Drawing.Point(251, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 27)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Mese"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Teal
        Me.Label11.Location = New System.Drawing.Point(995, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 27)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Ramo gestione"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Teal
        Me.Label12.Location = New System.Drawing.Point(747, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(118, 27)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Comparto"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonVisualizzaGiornalieri
        '
        Me.ButtonVisualizzaGiornalieri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonVisualizzaGiornalieri.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonVisualizzaGiornalieri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonVisualizzaGiornalieri.Location = New System.Drawing.Point(1243, 3)
        Me.ButtonVisualizzaGiornalieri.Name = "ButtonVisualizzaGiornalieri"
        Me.ButtonVisualizzaGiornalieri.Size = New System.Drawing.Size(118, 21)
        Me.ButtonVisualizzaGiornalieri.TabIndex = 9
        Me.ButtonVisualizzaGiornalieri.Text = "Visualizza"
        Me.ButtonVisualizzaGiornalieri.UseVisualStyleBackColor = True
        '
        'Pezzi
        '
        Me.Pezzi.Controls.Add(Me.tsPezzi)
        Me.Pezzi.Controls.Add(Me.dgvMovimenti)
        Me.Pezzi.Location = New System.Drawing.Point(4, 29)
        Me.Pezzi.Name = "Pezzi"
        Me.Pezzi.Size = New System.Drawing.Size(1495, 428)
        Me.Pezzi.TabIndex = 12
        Me.Pezzi.Text = "Nr.movimenti"
        Me.Pezzi.UseVisualStyleBackColor = True
        '
        'tsPezzi
        '
        Me.tsPezzi.Location = New System.Drawing.Point(0, 0)
        Me.tsPezzi.Name = "tsPezzi"
        Me.tsPezzi.Size = New System.Drawing.Size(1495, 25)
        Me.tsPezzi.TabIndex = 6
        Me.tsPezzi.Text = "ToolStrip2"
        '
        'dgvMovimenti
        '
        Me.dgvMovimenti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMovimenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovimenti.Location = New System.Drawing.Point(0, 34)
        Me.dgvMovimenti.Name = "dgvMovimenti"
        Me.dgvMovimenti.Size = New System.Drawing.Size(1495, 394)
        Me.dgvMovimenti.TabIndex = 5
        '
        'Giornate
        '
        Me.Giornate.Controls.Add(Me.dgvGiornate)
        Me.Giornate.Location = New System.Drawing.Point(4, 29)
        Me.Giornate.Name = "Giornate"
        Me.Giornate.Size = New System.Drawing.Size(1495, 428)
        Me.Giornate.TabIndex = 11
        Me.Giornate.Text = "Giornate lavorative"
        Me.Giornate.UseVisualStyleBackColor = True
        '
        'dgvGiornate
        '
        Me.dgvGiornate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGiornate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGiornate.Location = New System.Drawing.Point(0, 0)
        Me.dgvGiornate.Name = "dgvGiornate"
        Me.dgvGiornate.Size = New System.Drawing.Size(1495, 428)
        Me.dgvGiornate.TabIndex = 4
        '
        'TabPageVarie
        '
        Me.TabPageVarie.Controls.Add(Me.TabVarie)
        Me.TabPageVarie.Location = New System.Drawing.Point(4, 23)
        Me.TabPageVarie.Name = "TabPageVarie"
        Me.TabPageVarie.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageVarie.Size = New System.Drawing.Size(1509, 467)
        Me.TabPageVarie.TabIndex = 1
        Me.TabPageVarie.Text = "Analisi varie"
        Me.TabPageVarie.UseVisualStyleBackColor = True
        '
        'TabVarie
        '
        Me.TabVarie.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabVarie.ColorStyle = Utx.UtTabControl.TabColorStyle.AZZURRO
        Me.TabVarie.Controls.Add(Me.Stornate)
        Me.TabVarie.Controls.Add(Me.DeltaPremi)
        Me.TabVarie.Controls.Add(Me.PremiUnici)
        Me.TabVarie.Controls.Add(Me.Arretrati)
        Me.TabVarie.Controls.Add(Me.Registro)
        Me.TabVarie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabVarie.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabVarie.Location = New System.Drawing.Point(3, 3)
        Me.TabVarie.Name = "TabVarie"
        Me.TabVarie.SelectedIndex = 0
        Me.TabVarie.Size = New System.Drawing.Size(1503, 461)
        Me.TabVarie.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabVarie.TabIndex = 7
        Me.TabVarie.Visible = False
        '
        'Stornate
        '
        Me.Stornate.Controls.Add(Me.dgvStornate)
        Me.Stornate.Location = New System.Drawing.Point(4, 29)
        Me.Stornate.Name = "Stornate"
        Me.Stornate.Padding = New System.Windows.Forms.Padding(3)
        Me.Stornate.Size = New System.Drawing.Size(1495, 428)
        Me.Stornate.TabIndex = 0
        Me.Stornate.Text = "Polizze stornate"
        Me.Stornate.UseVisualStyleBackColor = True
        '
        'dgvStornate
        '
        Me.dgvStornate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStornate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStornate.Location = New System.Drawing.Point(3, 3)
        Me.dgvStornate.Name = "dgvStornate"
        Me.dgvStornate.Size = New System.Drawing.Size(1489, 422)
        Me.dgvStornate.TabIndex = 4
        '
        'DeltaPremi
        '
        Me.DeltaPremi.Controls.Add(Me.TableLayoutPanel3)
        Me.DeltaPremi.Location = New System.Drawing.Point(4, 29)
        Me.DeltaPremi.Name = "DeltaPremi"
        Me.DeltaPremi.Padding = New System.Windows.Forms.Padding(2)
        Me.DeltaPremi.Size = New System.Drawing.Size(1495, 428)
        Me.DeltaPremi.TabIndex = 8
        Me.DeltaPremi.Text = "Variazione premi danni"
        Me.DeltaPremi.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.SplitContainer1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1491, 424)
        Me.TableLayoutPanel3.TabIndex = 10
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1485, 378)
        Me.SplitContainer1.SplitterDistance = 720
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 9
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.dgvDelta, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lbDeltaTotale, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBoxRgDelta, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonAggiornaDelta, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(720, 378)
        Me.TableLayoutPanel2.TabIndex = 9
        '
        'dgvDelta
        '
        Me.dgvDelta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel2.SetColumnSpan(Me.dgvDelta, 3)
        Me.dgvDelta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDelta.Location = New System.Drawing.Point(3, 28)
        Me.dgvDelta.Name = "dgvDelta"
        Me.dgvDelta.Size = New System.Drawing.Size(714, 317)
        Me.dgvDelta.TabIndex = 6
        '
        'lbDeltaTotale
        '
        Me.lbDeltaTotale.AutoSize = True
        Me.lbDeltaTotale.BackColor = System.Drawing.Color.GreenYellow
        Me.lbDeltaTotale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel2.SetColumnSpan(Me.lbDeltaTotale, 3)
        Me.lbDeltaTotale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbDeltaTotale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDeltaTotale.Location = New System.Drawing.Point(3, 348)
        Me.lbDeltaTotale.Name = "lbDeltaTotale"
        Me.lbDeltaTotale.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbDeltaTotale.Size = New System.Drawing.Size(714, 30)
        Me.lbDeltaTotale.TabIndex = 8
        Me.lbDeltaTotale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(138, 25)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Ramo gestione"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBoxRgDelta
        '
        Me.ComboBoxRgDelta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxRgDelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxRgDelta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxRgDelta.FormattingEnabled = True
        Me.ComboBoxRgDelta.Location = New System.Drawing.Point(147, 3)
        Me.ComboBoxRgDelta.Name = "ComboBoxRgDelta"
        Me.ComboBoxRgDelta.Size = New System.Drawing.Size(426, 22)
        Me.ComboBoxRgDelta.TabIndex = 10
        '
        'ButtonAggiornaDelta
        '
        Me.ButtonAggiornaDelta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiornaDelta.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonAggiornaDelta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAggiornaDelta.Location = New System.Drawing.Point(576, 0)
        Me.ButtonAggiornaDelta.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAggiornaDelta.Name = "ButtonAggiornaDelta"
        Me.ButtonAggiornaDelta.Size = New System.Drawing.Size(144, 25)
        Me.ButtonAggiornaDelta.TabIndex = 11
        Me.ButtonAggiornaDelta.Text = "Aggiorna"
        Me.ButtonAggiornaDelta.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnEsportaElenco, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvDettaglioIncassi, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEsportaDettaglio, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonRichiestaCliente, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelDettaglioVariazioni, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelTotalePolizza, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvDeltaArretrati, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelDeltaArretrati, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(760, 378)
        Me.TableLayoutPanel1.TabIndex = 12
        '
        'btnEsportaElenco
        '
        Me.btnEsportaElenco.BackColor = System.Drawing.SystemColors.Control
        Me.btnEsportaElenco.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsportaElenco.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnEsportaElenco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEsportaElenco.Location = New System.Drawing.Point(3, 347)
        Me.btnEsportaElenco.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnEsportaElenco.Name = "btnEsportaElenco"
        Me.btnEsportaElenco.Size = New System.Drawing.Size(184, 31)
        Me.btnEsportaElenco.TabIndex = 13
        Me.btnEsportaElenco.Text = "Esporta elenco"
        Me.btnEsportaElenco.UseVisualStyleBackColor = False
        '
        'dgvDettaglioIncassi
        '
        Me.dgvDettaglioIncassi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvDettaglioIncassi, 3)
        Me.dgvDettaglioIncassi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDettaglioIncassi.Location = New System.Drawing.Point(3, 28)
        Me.dgvDettaglioIncassi.Name = "dgvDettaglioIncassi"
        Me.dgvDettaglioIncassi.Size = New System.Drawing.Size(754, 188)
        Me.dgvDettaglioIncassi.TabIndex = 10
        '
        'btnEsportaDettaglio
        '
        Me.btnEsportaDettaglio.BackColor = System.Drawing.SystemColors.Control
        Me.btnEsportaDettaglio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsportaDettaglio.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnEsportaDettaglio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEsportaDettaglio.Location = New System.Drawing.Point(193, 347)
        Me.btnEsportaDettaglio.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnEsportaDettaglio.Name = "btnEsportaDettaglio"
        Me.btnEsportaDettaglio.Size = New System.Drawing.Size(184, 31)
        Me.btnEsportaDettaglio.TabIndex = 11
        Me.btnEsportaDettaglio.Text = "Esporta dettaglio"
        Me.btnEsportaDettaglio.UseVisualStyleBackColor = False
        '
        'ButtonRichiestaCliente
        '
        Me.ButtonRichiestaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonRichiestaCliente.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonRichiestaCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRichiestaCliente.Location = New System.Drawing.Point(383, 347)
        Me.ButtonRichiestaCliente.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.ButtonRichiestaCliente.Name = "ButtonRichiestaCliente"
        Me.ButtonRichiestaCliente.Size = New System.Drawing.Size(374, 31)
        Me.ButtonRichiestaCliente.TabIndex = 12
        Me.ButtonRichiestaCliente.Text = "Vai alla scheda cliente"
        Me.ButtonRichiestaCliente.UseVisualStyleBackColor = True
        '
        'LabelDettaglioVariazioni
        '
        Me.LabelDettaglioVariazioni.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelDettaglioVariazioni, 3)
        Me.LabelDettaglioVariazioni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelDettaglioVariazioni.Location = New System.Drawing.Point(3, 0)
        Me.LabelDettaglioVariazioni.Name = "LabelDettaglioVariazioni"
        Me.LabelDettaglioVariazioni.Size = New System.Drawing.Size(754, 25)
        Me.LabelDettaglioVariazioni.TabIndex = 14
        Me.LabelDettaglioVariazioni.Text = "..."
        Me.LabelDettaglioVariazioni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelTotalePolizza
        '
        Me.LabelTotalePolizza.AutoSize = True
        Me.LabelTotalePolizza.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelTotalePolizza, 3)
        Me.LabelTotalePolizza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTotalePolizza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelTotalePolizza.Location = New System.Drawing.Point(3, 322)
        Me.LabelTotalePolizza.Margin = New System.Windows.Forms.Padding(3, 0, 3, 2)
        Me.LabelTotalePolizza.Name = "LabelTotalePolizza"
        Me.LabelTotalePolizza.Size = New System.Drawing.Size(754, 23)
        Me.LabelTotalePolizza.TabIndex = 15
        Me.LabelTotalePolizza.Text = "Polizza:"
        Me.LabelTotalePolizza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvDeltaArretrati
        '
        Me.dgvDeltaArretrati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvDeltaArretrati, 3)
        Me.dgvDeltaArretrati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDeltaArretrati.Location = New System.Drawing.Point(3, 242)
        Me.dgvDeltaArretrati.Name = "dgvDeltaArretrati"
        Me.dgvDeltaArretrati.Size = New System.Drawing.Size(754, 77)
        Me.dgvDeltaArretrati.TabIndex = 16
        '
        'LabelDeltaArretrati
        '
        Me.LabelDeltaArretrati.AutoSize = True
        Me.LabelDeltaArretrati.BackColor = System.Drawing.Color.LightSalmon
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelDeltaArretrati, 3)
        Me.LabelDeltaArretrati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelDeltaArretrati.Location = New System.Drawing.Point(3, 219)
        Me.LabelDeltaArretrati.Name = "LabelDeltaArretrati"
        Me.LabelDeltaArretrati.Size = New System.Drawing.Size(754, 20)
        Me.LabelDeltaArretrati.TabIndex = 17
        Me.LabelDeltaArretrati.Text = "Arretrati"
        Me.LabelDeltaArretrati.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.NavajoWhite
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 387)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.Label5.Size = New System.Drawing.Size(1485, 34)
        Me.Label5.TabIndex = 7
        '
        'PremiUnici
        '
        Me.PremiUnici.Controls.Add(Me.Label4)
        Me.PremiUnici.Controls.Add(Me.dgvPremiUnici)
        Me.PremiUnici.Location = New System.Drawing.Point(4, 29)
        Me.PremiUnici.Name = "PremiUnici"
        Me.PremiUnici.Padding = New System.Windows.Forms.Padding(3)
        Me.PremiUnici.Size = New System.Drawing.Size(1495, 428)
        Me.PremiUnici.TabIndex = 1
        Me.PremiUnici.Text = "Premi unici"
        Me.PremiUnici.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.NavajoWhite
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 390)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1489, 35)
        Me.Label4.TabIndex = 5
        '
        'dgvPremiUnici
        '
        Me.dgvPremiUnici.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPremiUnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPremiUnici.Location = New System.Drawing.Point(3, 0)
        Me.dgvPremiUnici.Name = "dgvPremiUnici"
        Me.dgvPremiUnici.Size = New System.Drawing.Size(1489, 387)
        Me.dgvPremiUnici.TabIndex = 4
        '
        'Arretrati
        '
        Me.Arretrati.Controls.Add(Me.ToolStrip1)
        Me.Arretrati.Controls.Add(Me.dgvArretrati)
        Me.Arretrati.Location = New System.Drawing.Point(4, 29)
        Me.Arretrati.Name = "Arretrati"
        Me.Arretrati.Padding = New System.Windows.Forms.Padding(2)
        Me.Arretrati.Size = New System.Drawing.Size(1495, 428)
        Me.Arretrati.TabIndex = 9
        Me.Arretrati.Text = "Arretrati"
        Me.Arretrati.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Gold
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnElencoArretrati, Me.btnArretratiRg, Me.btnArretratiComparto, Me.txtCercaArretrati, Me.btnCerca, Me.ToolStripSeparator1, Me.btnAggiornaArretrati, Me.btnEsporta, Me.LabelAggiornamentoArretrati})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(2, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(1491, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnElencoArretrati
        '
        Me.btnElencoArretrati.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnElencoArretrati.Image = CType(resources.GetObject("btnElencoArretrati.Image"), System.Drawing.Image)
        Me.btnElencoArretrati.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnElencoArretrati.Name = "btnElencoArretrati"
        Me.btnElencoArretrati.Size = New System.Drawing.Size(90, 22)
        Me.btnElencoArretrati.Text = "Elenco arretrati"
        '
        'btnArretratiRg
        '
        Me.btnArretratiRg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnArretratiRg.Image = CType(resources.GetObject("btnArretratiRg.Image"), System.Drawing.Image)
        Me.btnArretratiRg.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnArretratiRg.Name = "btnArretratiRg"
        Me.btnArretratiRg.Size = New System.Drawing.Size(139, 22)
        Me.btnArretratiRg.Text = "Totali per ramo gestione"
        '
        'btnArretratiComparto
        '
        Me.btnArretratiComparto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnArretratiComparto.Image = CType(resources.GetObject("btnArretratiComparto.Image"), System.Drawing.Image)
        Me.btnArretratiComparto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnArretratiComparto.Name = "btnArretratiComparto"
        Me.btnArretratiComparto.Size = New System.Drawing.Size(115, 22)
        Me.btnArretratiComparto.Text = "Totali per comparto"
        '
        'txtCercaArretrati
        '
        Me.txtCercaArretrati.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCercaArretrati.Name = "txtCercaArretrati"
        Me.txtCercaArretrati.Size = New System.Drawing.Size(100, 25)
        '
        'btnCerca
        '
        Me.btnCerca.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnCerca.Image = CType(resources.GetObject("btnCerca.Image"), System.Drawing.Image)
        Me.btnCerca.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerca.Name = "btnCerca"
        Me.btnCerca.Size = New System.Drawing.Size(41, 22)
        Me.btnCerca.Text = "Cerca"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnAggiornaArretrati
        '
        Me.btnAggiornaArretrati.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAggiornaArretrati.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnAggiornaArretrati.Image = CType(resources.GetObject("btnAggiornaArretrati.Image"), System.Drawing.Image)
        Me.btnAggiornaArretrati.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAggiornaArretrati.Name = "btnAggiornaArretrati"
        Me.btnAggiornaArretrati.Size = New System.Drawing.Size(104, 22)
        Me.btnAggiornaArretrati.Text = "Aggiorna arretrati"
        '
        'btnEsporta
        '
        Me.btnEsporta.BackColor = System.Drawing.Color.LightGreen
        Me.btnEsporta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnEsporta.Image = CType(resources.GetObject("btnEsporta.Image"), System.Drawing.Image)
        Me.btnEsporta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEsporta.Name = "btnEsporta"
        Me.btnEsporta.Size = New System.Drawing.Size(83, 22)
        Me.btnEsporta.Text = "Esporta in csv"
        '
        'LabelAggiornamentoArretrati
        '
        Me.LabelAggiornamentoArretrati.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LabelAggiornamentoArretrati.Name = "LabelAggiornamentoArretrati"
        Me.LabelAggiornamentoArretrati.Size = New System.Drawing.Size(0, 22)
        '
        'dgvArretrati
        '
        Me.dgvArretrati.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvArretrati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArretrati.Location = New System.Drawing.Point(2, 30)
        Me.dgvArretrati.Name = "dgvArretrati"
        Me.dgvArretrati.Size = New System.Drawing.Size(1488, 395)
        Me.dgvArretrati.TabIndex = 2
        '
        'Registro
        '
        Me.Registro.Controls.Add(Me.dgvRegistro)
        Me.Registro.Location = New System.Drawing.Point(4, 29)
        Me.Registro.Name = "Registro"
        Me.Registro.Size = New System.Drawing.Size(1495, 428)
        Me.Registro.TabIndex = 11
        Me.Registro.Text = "Registro importazioni"
        Me.Registro.UseVisualStyleBackColor = True
        '
        'dgvRegistro
        '
        Me.dgvRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRegistro.Location = New System.Drawing.Point(0, 0)
        Me.dgvRegistro.Name = "dgvRegistro"
        Me.dgvRegistro.Size = New System.Drawing.Size(1495, 428)
        Me.dgvRegistro.TabIndex = 3
        '
        'GroupBoxCodici
        '
        Me.GroupBoxCodici.Controls.Add(Me.ButtonConfermaGruppo)
        Me.GroupBoxCodici.Controls.Add(Me.CheckedListBoxAgenzie)
        Me.GroupBoxCodici.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxCodici.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBoxCodici.Location = New System.Drawing.Point(488, 3)
        Me.GroupBoxCodici.Name = "GroupBoxCodici"
        Me.GroupBoxCodici.Size = New System.Drawing.Size(92, 154)
        Me.GroupBoxCodici.TabIndex = 4
        Me.GroupBoxCodici.TabStop = False
        Me.GroupBoxCodici.Text = "Codici"
        '
        'ButtonConfermaGruppo
        '
        Me.ButtonConfermaGruppo.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.ButtonConfermaGruppo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonConfermaGruppo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonConfermaGruppo.Location = New System.Drawing.Point(6, 107)
        Me.ButtonConfermaGruppo.Name = "ButtonConfermaGruppo"
        Me.ButtonConfermaGruppo.Size = New System.Drawing.Size(80, 21)
        Me.ButtonConfermaGruppo.TabIndex = 1
        Me.ButtonConfermaGruppo.Text = "Conferma"
        Me.ButtonConfermaGruppo.UseVisualStyleBackColor = True
        '
        'CheckedListBoxAgenzie
        '
        Me.CheckedListBoxAgenzie.FormattingEnabled = True
        Me.CheckedListBoxAgenzie.IntegralHeight = False
        Me.CheckedListBoxAgenzie.Location = New System.Drawing.Point(6, 16)
        Me.CheckedListBoxAgenzie.Name = "CheckedListBoxAgenzie"
        Me.CheckedListBoxAgenzie.Size = New System.Drawing.Size(80, 87)
        Me.CheckedListBoxAgenzie.TabIndex = 0
        '
        'CheckBoxSub
        '
        Me.CheckBoxSub.AutoSize = True
        Me.CheckBoxSub.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBoxSub.Location = New System.Drawing.Point(13, 96)
        Me.CheckBoxSub.Name = "CheckBoxSub"
        Me.CheckBoxSub.Size = New System.Drawing.Size(112, 17)
        Me.CheckBoxSub.TabIndex = 25
        Me.CheckBoxSub.Text = "Analisi sub-agente"
        Me.CheckBoxSub.UseVisualStyleBackColor = True
        '
        'CheckBoxProd
        '
        Me.CheckBoxProd.AutoSize = True
        Me.CheckBoxProd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBoxProd.Location = New System.Drawing.Point(139, 96)
        Me.CheckBoxProd.Name = "CheckBoxProd"
        Me.CheckBoxProd.Size = New System.Drawing.Size(107, 17)
        Me.CheckBoxProd.TabIndex = 26
        Me.CheckBoxProd.Text = "Analisi produttore"
        Me.CheckBoxProd.UseVisualStyleBackColor = True
        '
        'FormBudget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1523, 662)
        Me.Controls.Add(Me.tlpMain)
        Me.Controls.Add(Me.StatusStrip1)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormBudget"
        Me.Text = "Analisi Incassi e Budget"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.udFontSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxAnalisi.ResumeLayout(False)
        Me.GroupBoxAnalisi.PerformLayout()
        Me.GroupBoxAspetto.ResumeLayout(False)
        Me.GroupBoxAspetto.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBoxDati.ResumeLayout(False)
        Me.tlpMain.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.TabPageAnalisi.ResumeLayout(False)
        Me.TabAnalisi.ResumeLayout(False)
        Me.Rg.ResumeLayout(False)
        CType(Me.dgvRamoGestione, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Comparto.ResumeLayout(False)
        CType(Me.dgvComparto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Settore.ResumeLayout(False)
        CType(Me.dgvSettore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Aggregato.ResumeLayout(False)
        CType(Me.dgvAggregato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Generale.ResumeLayout(False)
        CType(Me.dgvGenerale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AnomalieAuto.ResumeLayout(False)
        Me.AnomalieAuto.PerformLayout()
        CType(Me.dgvAnomalie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Giornalieri.ResumeLayout(False)
        Me.tlpGiornalieri.ResumeLayout(False)
        Me.tlpGiornalieri.PerformLayout()
        CType(Me.dgvGiornalieri, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pezzi.ResumeLayout(False)
        Me.Pezzi.PerformLayout()
        CType(Me.dgvMovimenti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Giornate.ResumeLayout(False)
        CType(Me.dgvGiornate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageVarie.ResumeLayout(False)
        Me.TabVarie.ResumeLayout(False)
        Me.Stornate.ResumeLayout(False)
        CType(Me.dgvStornate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DeltaPremi.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.dgvDelta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvDettaglioIncassi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDeltaArretrati, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PremiUnici.ResumeLayout(False)
        CType(Me.dgvPremiUnici, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Arretrati.ResumeLayout(False)
        Me.Arretrati.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvArretrati, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Registro.ResumeLayout(False)
        CType(Me.dgvRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxCodici.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tssStato As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnInserimento As System.Windows.Forms.Button
    Friend WithEvents btnEstraiDati As System.Windows.Forms.Button
    Friend WithEvents dtpDataAnalisi As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboAnnoInizio As System.Windows.Forms.ComboBox
    Friend WithEvents chkAutoSize As System.Windows.Forms.CheckBox
    Friend WithEvents btnNascondiColonna As System.Windows.Forms.Button
    Friend WithEvents btnScopri As System.Windows.Forms.Button
    Friend WithEvents btnNascondiMesi As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkBloccaColonne As System.Windows.Forms.CheckBox
    Friend WithEvents udFontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents tssSomma As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBoxAnalisi As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxAspetto As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxDati As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents ButtonDettaglioProvvigioni As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboFigura As System.Windows.Forms.ComboBox
    Friend WithEvents btnGestione As System.Windows.Forms.Button
    Friend WithEvents TabMain As Utx.UtTabControl
    Friend WithEvents TabPageAnalisi As System.Windows.Forms.TabPage
    Friend WithEvents TabPageVarie As System.Windows.Forms.TabPage
    Friend WithEvents TabAnalisi As Utx.UtTabControl
    Friend WithEvents Rg As System.Windows.Forms.TabPage
    Friend WithEvents dgvRamoGestione As System.Windows.Forms.DataGridView
    Friend WithEvents Comparto As System.Windows.Forms.TabPage
    Friend WithEvents dgvComparto As System.Windows.Forms.DataGridView
    Friend WithEvents Settore As System.Windows.Forms.TabPage
    Friend WithEvents dgvSettore As System.Windows.Forms.DataGridView
    Friend WithEvents Aggregato As System.Windows.Forms.TabPage
    Friend WithEvents dgvAggregato As System.Windows.Forms.DataGridView
    Friend WithEvents Generale As System.Windows.Forms.TabPage
    Friend WithEvents dgvGenerale As System.Windows.Forms.DataGridView
    Friend WithEvents Pezzi As System.Windows.Forms.TabPage
    Friend WithEvents dgvMovimenti As System.Windows.Forms.DataGridView
    Friend WithEvents AnomalieAuto As System.Windows.Forms.TabPage
    Friend WithEvents dgvAnomalie As System.Windows.Forms.DataGridView
    Friend WithEvents Giornate As System.Windows.Forms.TabPage
    Friend WithEvents dgvGiornate As System.Windows.Forms.DataGridView
    Friend WithEvents TabVarie As Utx.UtTabControl
    Friend WithEvents Stornate As System.Windows.Forms.TabPage
    Friend WithEvents dgvStornate As System.Windows.Forms.DataGridView
    Friend WithEvents Registro As System.Windows.Forms.TabPage
    Friend WithEvents dgvRegistro As System.Windows.Forms.DataGridView
    Friend WithEvents Arretrati As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnElencoArretrati As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnArretratiRg As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnArretratiComparto As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCercaArretrati As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnCerca As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvArretrati As System.Windows.Forms.DataGridView
    Friend WithEvents DeltaPremi As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Public WithEvents lbDeltaTotale As System.Windows.Forms.Label
    Public WithEvents dgvDelta As System.Windows.Forms.DataGridView
    Friend WithEvents btnEsportaDettaglio As System.Windows.Forms.Button
    Friend WithEvents dgvDettaglioIncassi As System.Windows.Forms.DataGridView
    Public WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PremiUnici As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvPremiUnici As System.Windows.Forms.DataGridView
    Friend WithEvents tsPezzi As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonAggiornaIncassi As System.Windows.Forms.Button
    Friend WithEvents TextBoxAnomalie As System.Windows.Forms.TextBox
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBoxCodici As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonConfermaGruppo As System.Windows.Forms.Button
    Friend WithEvents CheckedListBoxAgenzie As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckBoxVitaOk As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxArretrati As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxRgDelta As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonRichiestaCliente As System.Windows.Forms.Button
    Friend WithEvents ButtonAggiornaDelta As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEsporta As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAggiornaArretrati As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelAggiornamentoArretrati As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnEsportaElenco As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpDataInizioAnalisi As DateTimePicker
    Friend WithEvents Giornalieri As TabPage
    Friend WithEvents tlpGiornalieri As TableLayoutPanel
    Friend WithEvents dgvGiornalieri As DataGridView
    Friend WithEvents ComboBoxAnnoGiornalieri As ComboBox
    Friend WithEvents ComboBoxMeseGiornalieri As ComboBox
    Friend WithEvents ComboBoxRamoGestioneGiornalieri As ComboBox
    Friend WithEvents ComboBoxCompartoGiornalieri As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents ButtonVisualizzaGiornalieri As Button
    Friend WithEvents ButtonAnalisiDifferenze As Button
    Friend WithEvents LabelDettaglioVariazioni As Label
    Friend WithEvents ComboBoxAggregatoGiornalieri As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents ComboBoxAgenzia As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents LabelTotalePolizza As Label
    Friend WithEvents dgvDeltaArretrati As DataGridView
    Friend WithEvents LabelDeltaArretrati As Label
    Friend WithEvents CheckBoxIndividuali As CheckBox
    Friend WithEvents CheckBoxProd As CheckBox
    Friend WithEvents CheckBoxSub As CheckBox
End Class
