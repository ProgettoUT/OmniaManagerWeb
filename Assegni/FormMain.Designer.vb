<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtCodeLine = New System.Windows.Forms.TextBox()
        Me.ListViewIncassi = New System.Windows.Forms.ListView()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tlpBottoni = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonCambiaUtente = New System.Windows.Forms.Button()
        Me.btnAcquisisci = New System.Windows.Forms.Button()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.btnAggiornaIncassi = New System.Windows.Forms.Button()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.LabelUtente = New System.Windows.Forms.Label()
        Me.btnLicenza = New System.Windows.Forms.Button()
        Me.dtpDataIncasso = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxAgenzia = New System.Windows.Forms.TextBox()
        Me.TextBoxSub = New System.Windows.Forms.TextBox()
        Me.btnAnnulla = New System.Windows.Forms.Button()
        Me.pbAnteprima = New System.Windows.Forms.PictureBox()
        Me.btnImportoAssegno = New System.Windows.Forms.Button()
        Me.LabelTotaleTitoli = New System.Windows.Forms.Label()
        Me.LabelLicenza = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageScan = New System.Windows.Forms.TabPage()
        Me.TabPageRicerca = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanelCerca = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAumentaCarattere = New System.Windows.Forms.Button()
        Me.PanelCerca = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCerca = New System.Windows.Forms.Button()
        Me.txtImportoAssegno = New System.Windows.Forms.TextBox()
        Me.txtContraente = New System.Windows.Forms.TextBox()
        Me.txtAbi = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAltroAssegno = New System.Windows.Forms.Button()
        Me.btnCancellaAssegno = New System.Windows.Forms.Button()
        Me.CheckBoxAnteprima = New System.Windows.Forms.CheckBox()
        Me.btnDiminuisciCarattere = New System.Windows.Forms.Button()
        Me.SplitContainerCerca = New System.Windows.Forms.SplitContainer()
        Me.dgvRicerca = New System.Windows.Forms.DataGridView()
        Me.pbAnteprimaCerca = New System.Windows.Forms.PictureBox()
        Me.TabPageDoc = New System.Windows.Forms.TabPage()
        Me.wbDocumentazione = New System.Windows.Forms.WebBrowser()
        Me.ButtonIndice = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LabelMessaggio = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tlpBottoni.SuspendLayout()
        CType(Me.pbAnteprima, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPageScan.SuspendLayout()
        Me.TabPageRicerca.SuspendLayout()
        Me.TableLayoutPanelCerca.SuspendLayout()
        Me.PanelCerca.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.SplitContainerCerca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerCerca.Panel1.SuspendLayout()
        Me.SplitContainerCerca.Panel2.SuspendLayout()
        Me.SplitContainerCerca.SuspendLayout()
        CType(Me.dgvRicerca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAnteprimaCerca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageDoc.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.75214!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.24786!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtCodeLine, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ListViewIncassi, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNote, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.pbAnteprima, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnImportoAssegno, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelTotaleTitoli, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelLicenza, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1090, 469)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'txtCodeLine
        '
        Me.txtCodeLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtCodeLine, 2)
        Me.txtCodeLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCodeLine.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodeLine.Location = New System.Drawing.Point(352, 439)
        Me.txtCodeLine.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCodeLine.Multiline = True
        Me.txtCodeLine.Name = "txtCodeLine"
        Me.txtCodeLine.Size = New System.Drawing.Size(468, 28)
        Me.txtCodeLine.TabIndex = 5
        '
        'ListViewIncassi
        '
        Me.ListViewIncassi.CheckBoxes = True
        Me.ListViewIncassi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewIncassi.HideSelection = False
        Me.ListViewIncassi.Location = New System.Drawing.Point(2, 34)
        Me.ListViewIncassi.Margin = New System.Windows.Forms.Padding(2)
        Me.ListViewIncassi.Name = "ListViewIncassi"
        Me.ListViewIncassi.Size = New System.Drawing.Size(346, 401)
        Me.ListViewIncassi.TabIndex = 2
        Me.ListViewIncassi.UseCompatibleStateImageBehavior = False
        '
        'txtNote
        '
        Me.txtNote.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNote.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(407, 2)
        Me.txtNote.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(413, 27)
        Me.txtNote.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(353, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 32)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Note"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.tlpBottoni)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(824, 34)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel1, 2)
        Me.Panel1.Size = New System.Drawing.Size(264, 433)
        Me.Panel1.TabIndex = 8
        '
        'tlpBottoni
        '
        Me.tlpBottoni.ColumnCount = 4
        Me.tlpBottoni.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.tlpBottoni.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.0!))
        Me.tlpBottoni.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpBottoni.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpBottoni.Controls.Add(Me.ButtonCambiaUtente, 3, 1)
        Me.tlpBottoni.Controls.Add(Me.btnAcquisisci, 0, 3)
        Me.tlpBottoni.Controls.Add(Me.btnSalva, 0, 4)
        Me.tlpBottoni.Controls.Add(Me.btnAggiornaIncassi, 3, 2)
        Me.tlpBottoni.Controls.Add(Me.btnEsci, 0, 6)
        Me.tlpBottoni.Controls.Add(Me.LabelUtente, 1, 1)
        Me.tlpBottoni.Controls.Add(Me.btnLicenza, 0, 5)
        Me.tlpBottoni.Controls.Add(Me.dtpDataIncasso, 0, 2)
        Me.tlpBottoni.Controls.Add(Me.Label5, 0, 0)
        Me.tlpBottoni.Controls.Add(Me.Label6, 0, 1)
        Me.tlpBottoni.Controls.Add(Me.TextBoxAgenzia, 1, 0)
        Me.tlpBottoni.Controls.Add(Me.TextBoxSub, 3, 0)
        Me.tlpBottoni.Controls.Add(Me.btnAnnulla, 3, 4)
        Me.tlpBottoni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpBottoni.Location = New System.Drawing.Point(0, 0)
        Me.tlpBottoni.Name = "tlpBottoni"
        Me.tlpBottoni.RowCount = 7
        Me.tlpBottoni.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpBottoni.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpBottoni.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpBottoni.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpBottoni.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpBottoni.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpBottoni.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpBottoni.Size = New System.Drawing.Size(262, 431)
        Me.tlpBottoni.TabIndex = 2
        '
        'ButtonCambiaUtente
        '
        Me.ButtonCambiaUtente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCambiaUtente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCambiaUtente.Location = New System.Drawing.Point(183, 29)
        Me.ButtonCambiaUtente.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonCambiaUtente.Name = "ButtonCambiaUtente"
        Me.ButtonCambiaUtente.Size = New System.Drawing.Size(78, 26)
        Me.ButtonCambiaUtente.TabIndex = 2
        Me.ButtonCambiaUtente.Text = "Cambia "
        Me.ButtonCambiaUtente.UseVisualStyleBackColor = True
        '
        'btnAcquisisci
        '
        Me.tlpBottoni.SetColumnSpan(Me.btnAcquisisci, 4)
        Me.btnAcquisisci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAcquisisci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAcquisisci.Location = New System.Drawing.Point(1, 85)
        Me.btnAcquisisci.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAcquisisci.Name = "btnAcquisisci"
        Me.btnAcquisisci.Size = New System.Drawing.Size(260, 84)
        Me.btnAcquisisci.TabIndex = 5
        Me.btnAcquisisci.Text = "Acquisisci assegno"
        Me.btnAcquisisci.UseVisualStyleBackColor = True
        '
        'btnSalva
        '
        Me.tlpBottoni.SetColumnSpan(Me.btnSalva, 3)
        Me.btnSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalva.Location = New System.Drawing.Point(1, 171)
        Me.btnSalva.Margin = New System.Windows.Forms.Padding(1)
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(180, 84)
        Me.btnSalva.TabIndex = 6
        Me.btnSalva.Text = "salva"
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'btnAggiornaIncassi
        '
        Me.btnAggiornaIncassi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAggiornaIncassi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAggiornaIncassi.Location = New System.Drawing.Point(183, 57)
        Me.btnAggiornaIncassi.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAggiornaIncassi.Name = "btnAggiornaIncassi"
        Me.btnAggiornaIncassi.Size = New System.Drawing.Size(78, 26)
        Me.btnAggiornaIncassi.TabIndex = 4
        Me.btnAggiornaIncassi.Text = "Aggiorna"
        Me.btnAggiornaIncassi.UseVisualStyleBackColor = True
        '
        'btnEsci
        '
        Me.tlpBottoni.SetColumnSpan(Me.btnEsci, 4)
        Me.btnEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEsci.Location = New System.Drawing.Point(1, 343)
        Me.btnEsci.Margin = New System.Windows.Forms.Padding(1)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(260, 87)
        Me.btnEsci.TabIndex = 7
        Me.btnEsci.Text = "Button1"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'LabelUtente
        '
        Me.LabelUtente.AutoSize = True
        Me.tlpBottoni.SetColumnSpan(Me.LabelUtente, 2)
        Me.LabelUtente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelUtente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUtente.Location = New System.Drawing.Point(89, 28)
        Me.LabelUtente.Name = "LabelUtente"
        Me.LabelUtente.Size = New System.Drawing.Size(90, 28)
        Me.LabelUtente.TabIndex = 5
        Me.LabelUtente.Text = "LabelUtente"
        Me.LabelUtente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLicenza
        '
        Me.tlpBottoni.SetColumnSpan(Me.btnLicenza, 4)
        Me.btnLicenza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLicenza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLicenza.Location = New System.Drawing.Point(1, 257)
        Me.btnLicenza.Margin = New System.Windows.Forms.Padding(1)
        Me.btnLicenza.Name = "btnLicenza"
        Me.btnLicenza.Size = New System.Drawing.Size(260, 84)
        Me.btnLicenza.TabIndex = 6
        Me.btnLicenza.Text = "Licenza"
        Me.btnLicenza.UseVisualStyleBackColor = True
        '
        'dtpDataIncasso
        '
        Me.tlpBottoni.SetColumnSpan(Me.dtpDataIncasso, 3)
        Me.dtpDataIncasso.CustomFormat = "dddd dd/MM/yyyy"
        Me.dtpDataIncasso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDataIncasso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDataIncasso.Location = New System.Drawing.Point(3, 59)
        Me.dtpDataIncasso.Margin = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.dtpDataIncasso.Name = "dtpDataIncasso"
        Me.dtpDataIncasso.Size = New System.Drawing.Size(178, 22)
        Me.dtpDataIncasso.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 28)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Agenzia-Sub"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(3, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 28)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Utente"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxAgenzia
        '
        Me.tlpBottoni.SetColumnSpan(Me.TextBoxAgenzia, 2)
        Me.TextBoxAgenzia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxAgenzia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAgenzia.Location = New System.Drawing.Point(88, 2)
        Me.TextBoxAgenzia.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxAgenzia.Name = "TextBoxAgenzia"
        Me.TextBoxAgenzia.Size = New System.Drawing.Size(92, 22)
        Me.TextBoxAgenzia.TabIndex = 0
        '
        'TextBoxSub
        '
        Me.TextBoxSub.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxSub.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSub.Location = New System.Drawing.Point(184, 2)
        Me.TextBoxSub.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxSub.Name = "TextBoxSub"
        Me.TextBoxSub.Size = New System.Drawing.Size(76, 22)
        Me.TextBoxSub.TabIndex = 1
        '
        'btnAnnulla
        '
        Me.btnAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnulla.Location = New System.Drawing.Point(183, 171)
        Me.btnAnnulla.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAnnulla.Name = "btnAnnulla"
        Me.btnAnnulla.Size = New System.Drawing.Size(78, 84)
        Me.btnAnnulla.TabIndex = 10
        Me.btnAnnulla.Text = "Annulla"
        Me.btnAnnulla.UseVisualStyleBackColor = True
        '
        'pbAnteprima
        '
        Me.pbAnteprima.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.pbAnteprima, 2)
        Me.pbAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbAnteprima.Location = New System.Drawing.Point(352, 34)
        Me.pbAnteprima.Margin = New System.Windows.Forms.Padding(2)
        Me.pbAnteprima.Name = "pbAnteprima"
        Me.pbAnteprima.Size = New System.Drawing.Size(468, 401)
        Me.pbAnteprima.TabIndex = 12
        Me.pbAnteprima.TabStop = False
        '
        'btnImportoAssegno
        '
        Me.btnImportoAssegno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnImportoAssegno.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportoAssegno.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportoAssegno.Location = New System.Drawing.Point(2, 2)
        Me.btnImportoAssegno.Margin = New System.Windows.Forms.Padding(2)
        Me.btnImportoAssegno.Name = "btnImportoAssegno"
        Me.btnImportoAssegno.Size = New System.Drawing.Size(346, 28)
        Me.btnImportoAssegno.TabIndex = 0
        Me.btnImportoAssegno.Text = "Button1"
        Me.btnImportoAssegno.UseVisualStyleBackColor = True
        '
        'LabelTotaleTitoli
        '
        Me.LabelTotaleTitoli.AutoSize = True
        Me.LabelTotaleTitoli.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTotaleTitoli.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotaleTitoli.Location = New System.Drawing.Point(2, 439)
        Me.LabelTotaleTitoli.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelTotaleTitoli.Name = "LabelTotaleTitoli"
        Me.LabelTotaleTitoli.Size = New System.Drawing.Size(346, 28)
        Me.LabelTotaleTitoli.TabIndex = 14
        Me.LabelTotaleTitoli.Text = "Label5"
        Me.LabelTotaleTitoli.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelLicenza
        '
        Me.LabelLicenza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelLicenza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelLicenza.Location = New System.Drawing.Point(824, 2)
        Me.LabelLicenza.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelLicenza.Name = "LabelLicenza"
        Me.LabelLicenza.Size = New System.Drawing.Size(264, 28)
        Me.LabelLicenza.TabIndex = 15
        Me.LabelLicenza.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageScan)
        Me.TabControl1.Controls.Add(Me.TabPageRicerca)
        Me.TabControl1.Controls.Add(Me.TabPageDoc)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.HotTrack = True
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1098, 496)
        Me.TabControl1.TabIndex = 8
        '
        'TabPageScan
        '
        Me.TabPageScan.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPageScan.Location = New System.Drawing.Point(4, 23)
        Me.TabPageScan.Name = "TabPageScan"
        Me.TabPageScan.Size = New System.Drawing.Size(1090, 469)
        Me.TabPageScan.TabIndex = 0
        Me.TabPageScan.Text = "Acquisizione"
        Me.TabPageScan.UseVisualStyleBackColor = True
        '
        'TabPageRicerca
        '
        Me.TabPageRicerca.Controls.Add(Me.TableLayoutPanelCerca)
        Me.TabPageRicerca.Location = New System.Drawing.Point(4, 23)
        Me.TabPageRicerca.Name = "TabPageRicerca"
        Me.TabPageRicerca.Size = New System.Drawing.Size(1090, 469)
        Me.TabPageRicerca.TabIndex = 1
        Me.TabPageRicerca.Text = "Ricerca assegni"
        Me.TabPageRicerca.UseVisualStyleBackColor = True
        '
        'TableLayoutPanelCerca
        '
        Me.TableLayoutPanelCerca.ColumnCount = 2
        Me.TableLayoutPanelCerca.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanelCerca.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanelCerca.Controls.Add(Me.btnAumentaCarattere, 1, 2)
        Me.TableLayoutPanelCerca.Controls.Add(Me.PanelCerca, 0, 0)
        Me.TableLayoutPanelCerca.Controls.Add(Me.btnDiminuisciCarattere, 0, 2)
        Me.TableLayoutPanelCerca.Controls.Add(Me.SplitContainerCerca, 0, 1)
        Me.TableLayoutPanelCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelCerca.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelCerca.Name = "TableLayoutPanelCerca"
        Me.TableLayoutPanelCerca.RowCount = 3
        Me.TableLayoutPanelCerca.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanelCerca.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelCerca.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanelCerca.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelCerca.Size = New System.Drawing.Size(1090, 469)
        Me.TableLayoutPanelCerca.TabIndex = 0
        '
        'btnAumentaCarattere
        '
        Me.btnAumentaCarattere.BackColor = System.Drawing.Color.Moccasin
        Me.btnAumentaCarattere.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAumentaCarattere.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAumentaCarattere.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAumentaCarattere.Location = New System.Drawing.Point(548, 442)
        Me.btnAumentaCarattere.Name = "btnAumentaCarattere"
        Me.btnAumentaCarattere.Size = New System.Drawing.Size(539, 24)
        Me.btnAumentaCarattere.TabIndex = 3
        Me.btnAumentaCarattere.Text = "(+) aumenta dimensione carattere"
        Me.btnAumentaCarattere.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAumentaCarattere.UseVisualStyleBackColor = False
        '
        'PanelCerca
        '
        Me.PanelCerca.BackColor = System.Drawing.Color.GreenYellow
        Me.PanelCerca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanelCerca.SetColumnSpan(Me.PanelCerca, 2)
        Me.PanelCerca.Controls.Add(Me.TableLayoutPanel4)
        Me.PanelCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCerca.Location = New System.Drawing.Point(3, 3)
        Me.PanelCerca.Name = "PanelCerca"
        Me.PanelCerca.Size = New System.Drawing.Size(1084, 32)
        Me.PanelCerca.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 10
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.43133!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.89217!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.89217!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.89217!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.89217!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnCerca, 6, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.txtImportoAssegno, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.txtContraente, 5, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.txtAbi, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label4, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnAltroAssegno, 8, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnCancellaAssegno, 9, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.CheckBoxAnteprima, 7, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1082, 30)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Importo assegno"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCerca
        '
        Me.btnCerca.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCerca.Location = New System.Drawing.Point(625, 3)
        Me.btnCerca.Name = "btnCerca"
        Me.btnCerca.Size = New System.Drawing.Size(108, 24)
        Me.btnCerca.TabIndex = 3
        Me.btnCerca.Text = "Cerca"
        Me.btnCerca.UseVisualStyleBackColor = False
        '
        'txtImportoAssegno
        '
        Me.txtImportoAssegno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtImportoAssegno.Location = New System.Drawing.Point(113, 3)
        Me.txtImportoAssegno.Name = "txtImportoAssegno"
        Me.txtImportoAssegno.Size = New System.Drawing.Size(94, 22)
        Me.txtImportoAssegno.TabIndex = 0
        '
        'txtContraente
        '
        Me.txtContraente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtContraente.Location = New System.Drawing.Point(443, 3)
        Me.txtContraente.Name = "txtContraente"
        Me.txtContraente.Size = New System.Drawing.Size(176, 22)
        Me.txtContraente.TabIndex = 2
        '
        'txtAbi
        '
        Me.txtAbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAbi.Location = New System.Drawing.Point(263, 3)
        Me.txtAbi.Name = "txtAbi"
        Me.txtAbi.Size = New System.Drawing.Size(94, 22)
        Me.txtAbi.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(363, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 30)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Contraente"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(213, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 30)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "ABI"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAltroAssegno
        '
        Me.btnAltroAssegno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAltroAssegno.Location = New System.Drawing.Point(853, 3)
        Me.btnAltroAssegno.Name = "btnAltroAssegno"
        Me.btnAltroAssegno.Size = New System.Drawing.Size(108, 24)
        Me.btnAltroAssegno.TabIndex = 7
        Me.btnAltroAssegno.Text = "Altro assegno"
        Me.btnAltroAssegno.UseVisualStyleBackColor = True
        '
        'btnCancellaAssegno
        '
        Me.btnCancellaAssegno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancellaAssegno.Location = New System.Drawing.Point(967, 3)
        Me.btnCancellaAssegno.Name = "btnCancellaAssegno"
        Me.btnCancellaAssegno.Size = New System.Drawing.Size(112, 24)
        Me.btnCancellaAssegno.TabIndex = 8
        Me.btnCancellaAssegno.Text = "Cancella assegno"
        Me.btnCancellaAssegno.UseVisualStyleBackColor = True
        '
        'CheckBoxAnteprima
        '
        Me.CheckBoxAnteprima.AutoSize = True
        Me.CheckBoxAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxAnteprima.Location = New System.Drawing.Point(739, 3)
        Me.CheckBoxAnteprima.Name = "CheckBoxAnteprima"
        Me.CheckBoxAnteprima.Padding = New System.Windows.Forms.Padding(3)
        Me.CheckBoxAnteprima.Size = New System.Drawing.Size(108, 24)
        Me.CheckBoxAnteprima.TabIndex = 9
        Me.CheckBoxAnteprima.Text = "Anteprima"
        Me.CheckBoxAnteprima.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxAnteprima.UseVisualStyleBackColor = True
        '
        'btnDiminuisciCarattere
        '
        Me.btnDiminuisciCarattere.BackColor = System.Drawing.Color.Moccasin
        Me.btnDiminuisciCarattere.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDiminuisciCarattere.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDiminuisciCarattere.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDiminuisciCarattere.Location = New System.Drawing.Point(3, 442)
        Me.btnDiminuisciCarattere.Name = "btnDiminuisciCarattere"
        Me.btnDiminuisciCarattere.Size = New System.Drawing.Size(539, 24)
        Me.btnDiminuisciCarattere.TabIndex = 2
        Me.btnDiminuisciCarattere.Text = "(-) diminuisci dimensione carattere"
        Me.btnDiminuisciCarattere.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDiminuisciCarattere.UseVisualStyleBackColor = False
        '
        'SplitContainerCerca
        '
        Me.TableLayoutPanelCerca.SetColumnSpan(Me.SplitContainerCerca, 2)
        Me.SplitContainerCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerCerca.Location = New System.Drawing.Point(3, 41)
        Me.SplitContainerCerca.Name = "SplitContainerCerca"
        '
        'SplitContainerCerca.Panel1
        '
        Me.SplitContainerCerca.Panel1.Controls.Add(Me.dgvRicerca)
        '
        'SplitContainerCerca.Panel2
        '
        Me.SplitContainerCerca.Panel2.Controls.Add(Me.pbAnteprimaCerca)
        Me.SplitContainerCerca.Size = New System.Drawing.Size(1084, 395)
        Me.SplitContainerCerca.SplitterDistance = 539
        Me.SplitContainerCerca.TabIndex = 4
        '
        'dgvRicerca
        '
        Me.dgvRicerca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRicerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRicerca.Location = New System.Drawing.Point(0, 0)
        Me.dgvRicerca.Name = "dgvRicerca"
        Me.dgvRicerca.Size = New System.Drawing.Size(539, 395)
        Me.dgvRicerca.TabIndex = 0
        '
        'pbAnteprimaCerca
        '
        Me.pbAnteprimaCerca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbAnteprimaCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbAnteprimaCerca.Location = New System.Drawing.Point(0, 0)
        Me.pbAnteprimaCerca.Name = "pbAnteprimaCerca"
        Me.pbAnteprimaCerca.Size = New System.Drawing.Size(541, 395)
        Me.pbAnteprimaCerca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAnteprimaCerca.TabIndex = 0
        Me.pbAnteprimaCerca.TabStop = False
        '
        'TabPageDoc
        '
        Me.TabPageDoc.Controls.Add(Me.wbDocumentazione)
        Me.TabPageDoc.Controls.Add(Me.ButtonIndice)
        Me.TabPageDoc.Location = New System.Drawing.Point(4, 23)
        Me.TabPageDoc.Name = "TabPageDoc"
        Me.TabPageDoc.Size = New System.Drawing.Size(1090, 469)
        Me.TabPageDoc.TabIndex = 2
        Me.TabPageDoc.Text = "Documentazione"
        Me.TabPageDoc.UseVisualStyleBackColor = True
        '
        'wbDocumentazione
        '
        Me.wbDocumentazione.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wbDocumentazione.Location = New System.Drawing.Point(3, 29)
        Me.wbDocumentazione.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbDocumentazione.Name = "wbDocumentazione"
        Me.wbDocumentazione.Size = New System.Drawing.Size(1069, 436)
        Me.wbDocumentazione.TabIndex = 5
        '
        'ButtonIndice
        '
        Me.ButtonIndice.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonIndice.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonIndice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonIndice.Location = New System.Drawing.Point(0, 0)
        Me.ButtonIndice.Name = "ButtonIndice"
        Me.ButtonIndice.Size = New System.Drawing.Size(1090, 23)
        Me.ButtonIndice.TabIndex = 4
        Me.ButtonIndice.Text = "Indice"
        Me.ButtonIndice.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelMessaggio})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 499)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1098, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LabelMessaggio
        '
        Me.LabelMessaggio.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMessaggio.Name = "LabelMessaggio"
        Me.LabelMessaggio.Size = New System.Drawing.Size(104, 17)
        Me.LabelMessaggio.Text = "LabelMessaggio"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 524)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormMain"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.tlpBottoni.ResumeLayout(False)
        Me.tlpBottoni.PerformLayout()
        CType(Me.pbAnteprima, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageScan.ResumeLayout(False)
        Me.TabPageRicerca.ResumeLayout(False)
        Me.TableLayoutPanelCerca.ResumeLayout(False)
        Me.PanelCerca.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.SplitContainerCerca.Panel1.ResumeLayout(False)
        Me.SplitContainerCerca.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerCerca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerCerca.ResumeLayout(False)
        CType(Me.dgvRicerca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAnteprimaCerca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageDoc.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtCodeLine As System.Windows.Forms.TextBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListViewIncassi As System.Windows.Forms.ListView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPageScan As System.Windows.Forms.TabPage
    Friend WithEvents TabPageRicerca As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanelCerca As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvRicerca As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtImportoAssegno As System.Windows.Forms.TextBox
    Friend WithEvents txtAbi As System.Windows.Forms.TextBox
    Friend WithEvents btnCerca As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtContraente As System.Windows.Forms.TextBox
    Friend WithEvents PanelCerca As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pbAnteprima As System.Windows.Forms.PictureBox
    Friend WithEvents btnAltroAssegno As System.Windows.Forms.Button
    Friend WithEvents btnCancellaAssegno As System.Windows.Forms.Button
    Friend WithEvents btnImportoAssegno As System.Windows.Forms.Button
    Friend WithEvents LabelTotaleTitoli As System.Windows.Forms.Label
    Friend WithEvents CheckBoxAnteprima As System.Windows.Forms.CheckBox
    Friend WithEvents btnAumentaCarattere As System.Windows.Forms.Button
    Friend WithEvents btnDiminuisciCarattere As System.Windows.Forms.Button
    Friend WithEvents SplitContainerCerca As System.Windows.Forms.SplitContainer
    Friend WithEvents pbAnteprimaCerca As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents LabelMessaggio As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LabelLicenza As System.Windows.Forms.Label
    Friend WithEvents TabPageDoc As System.Windows.Forms.TabPage
    Friend WithEvents wbDocumentazione As System.Windows.Forms.WebBrowser
    Friend WithEvents ButtonIndice As System.Windows.Forms.Button
    Friend WithEvents tlpBottoni As TableLayoutPanel
    Friend WithEvents ButtonCambiaUtente As Button
    Friend WithEvents btnAcquisisci As Button
    Friend WithEvents btnSalva As Button
    Friend WithEvents btnAggiornaIncassi As Button
    Friend WithEvents btnEsci As Button
    Friend WithEvents LabelUtente As Label
    Friend WithEvents btnLicenza As Button
    Friend WithEvents dtpDataIncasso As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBoxAgenzia As TextBox
    Friend WithEvents TextBoxSub As TextBox
    Friend WithEvents btnAnnulla As Button
End Class
