<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNote
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadioButtonNote = New System.Windows.Forms.RadioButton()
        Me.RadioButtonAttivita = New System.Windows.Forms.RadioButton()
        Me.dgvNote = New System.Windows.Forms.DataGridView()
        Me.dgvDocumenti = New System.Windows.Forms.DataGridView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TextBoxNota = New System.Windows.Forms.TextBox()
        Me.tlpNote = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBoxScadenzaAttivita = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.dtpAttivita = New System.Windows.Forms.DateTimePicker()
        Me.CheckBoxAggiornaData = New System.Windows.Forms.CheckBox()
        Me.ButtonRipristinoBackup = New UtControls.UtFlatButton()
        Me.ButtonStampaDettaglioNote = New Utx.MyFlatButton()
        Me.ButtonStampaDettaglio = New Utx.MyFlatButton()
        Me.ButtonConsap = New Utx.MyFlatButton()
        Me.ButtonNuovaNota = New Utx.MyFlatButton()
        Me.ButtonCopiaNota = New Utx.MyFlatButton()
        Me.ButtonSalvaNota = New Utx.MyFlatButton()
        Me.ButtonCancellaNota = New Utx.MyFlatButton()
        Me.ButtonStampaNota = New Utx.MyFlatButton()
        Me.ButtonAttivitaCompletata = New Utx.MyFlatButton()
        Me.ButtonNotifiche = New Utx.MyFlatButton()
        Me.ButtonRipristinoNote = New UtControls.UtFlatButton()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDocumenti, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.tlpNote.SuspendLayout()
        Me.GroupBoxScadenzaAttivita.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1104, 592)
        Me.SplitContainer1.SplitterDistance = 365
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer3.Panel1.Controls.Add(Me.dgvNote)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.dgvDocumenti)
        Me.SplitContainer3.Size = New System.Drawing.Size(365, 592)
        Me.SplitContainer3.SplitterDistance = 400
        Me.SplitContainer3.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(365, 30)
        Me.Panel1.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.RadioButtonNote, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RadioButtonAttivita, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(363, 28)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'RadioButtonNote
        '
        Me.RadioButtonNote.AutoSize = True
        Me.RadioButtonNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonNote.Location = New System.Drawing.Point(10, 3)
        Me.RadioButtonNote.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.RadioButtonNote.Name = "RadioButtonNote"
        Me.RadioButtonNote.Size = New System.Drawing.Size(168, 22)
        Me.RadioButtonNote.TabIndex = 0
        Me.RadioButtonNote.TabStop = True
        Me.RadioButtonNote.Text = "Note"
        Me.RadioButtonNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButtonNote.UseVisualStyleBackColor = True
        '
        'RadioButtonAttivita
        '
        Me.RadioButtonAttivita.AutoSize = True
        Me.RadioButtonAttivita.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonAttivita.Location = New System.Drawing.Point(191, 3)
        Me.RadioButtonAttivita.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.RadioButtonAttivita.Name = "RadioButtonAttivita"
        Me.RadioButtonAttivita.Size = New System.Drawing.Size(169, 22)
        Me.RadioButtonAttivita.TabIndex = 1
        Me.RadioButtonAttivita.TabStop = True
        Me.RadioButtonAttivita.Text = "Attività"
        Me.RadioButtonAttivita.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButtonAttivita.UseVisualStyleBackColor = True
        '
        'dgvNote
        '
        Me.dgvNote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNote.Location = New System.Drawing.Point(0, 36)
        Me.dgvNote.Name = "dgvNote"
        Me.dgvNote.Size = New System.Drawing.Size(365, 364)
        Me.dgvNote.TabIndex = 0
        '
        'dgvDocumenti
        '
        Me.dgvDocumenti.AllowUserToAddRows = False
        Me.dgvDocumenti.AllowUserToDeleteRows = False
        Me.dgvDocumenti.AllowUserToOrderColumns = True
        Me.dgvDocumenti.AllowUserToResizeColumns = False
        Me.dgvDocumenti.AllowUserToResizeRows = False
        Me.dgvDocumenti.BackgroundColor = System.Drawing.Color.White
        Me.dgvDocumenti.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvDocumenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDocumenti.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDocumenti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDocumenti.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvDocumenti.Location = New System.Drawing.Point(0, 0)
        Me.dgvDocumenti.Name = "dgvDocumenti"
        Me.dgvDocumenti.RowHeadersVisible = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvDocumenti.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDocumenti.Size = New System.Drawing.Size(365, 188)
        Me.dgvDocumenti.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TextBoxNota)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.tlpNote)
        Me.SplitContainer2.Size = New System.Drawing.Size(735, 592)
        Me.SplitContainer2.SplitterDistance = 431
        Me.SplitContainer2.TabIndex = 0
        '
        'TextBoxNota
        '
        Me.TextBoxNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxNota.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxNota.Multiline = True
        Me.TextBoxNota.Name = "TextBoxNota"
        Me.TextBoxNota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxNota.Size = New System.Drawing.Size(735, 431)
        Me.TextBoxNota.TabIndex = 0
        '
        'tlpNote
        '
        Me.tlpNote.BackColor = System.Drawing.SystemColors.Control
        Me.tlpNote.ColumnCount = 7
        Me.tlpNote.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlpNote.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlpNote.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlpNote.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlpNote.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlpNote.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpNote.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlpNote.Controls.Add(Me.ButtonRipristinoBackup, 6, 2)
        Me.tlpNote.Controls.Add(Me.ButtonStampaDettaglioNote, 4, 0)
        Me.tlpNote.Controls.Add(Me.ButtonStampaDettaglio, 3, 0)
        Me.tlpNote.Controls.Add(Me.ButtonConsap, 4, 2)
        Me.tlpNote.Controls.Add(Me.ButtonNuovaNota, 0, 0)
        Me.tlpNote.Controls.Add(Me.ButtonCopiaNota, 1, 0)
        Me.tlpNote.Controls.Add(Me.ButtonSalvaNota, 0, 2)
        Me.tlpNote.Controls.Add(Me.ButtonCancellaNota, 1, 2)
        Me.tlpNote.Controls.Add(Me.ButtonStampaNota, 2, 0)
        Me.tlpNote.Controls.Add(Me.GroupBoxScadenzaAttivita, 2, 2)
        Me.tlpNote.Controls.Add(Me.ButtonNotifiche, 3, 2)
        Me.tlpNote.Controls.Add(Me.CheckBoxAggiornaData, 7, 0)
        Me.tlpNote.Controls.Add(Me.ButtonRipristinoNote, 6, 3)
        Me.tlpNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpNote.Location = New System.Drawing.Point(0, 0)
        Me.tlpNote.Name = "tlpNote"
        Me.tlpNote.RowCount = 4
        Me.tlpNote.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpNote.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpNote.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpNote.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpNote.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpNote.Size = New System.Drawing.Size(735, 157)
        Me.tlpNote.TabIndex = 0
        '
        'GroupBoxScadenzaAttivita
        '
        Me.GroupBoxScadenzaAttivita.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBoxScadenzaAttivita.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxScadenzaAttivita.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBoxScadenzaAttivita.Location = New System.Drawing.Point(200, 78)
        Me.GroupBoxScadenzaAttivita.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBoxScadenzaAttivita.Name = "GroupBoxScadenzaAttivita"
        Me.tlpNote.SetRowSpan(Me.GroupBoxScadenzaAttivita, 2)
        Me.GroupBoxScadenzaAttivita.Size = New System.Drawing.Size(120, 79)
        Me.GroupBoxScadenzaAttivita.TabIndex = 7
        Me.GroupBoxScadenzaAttivita.TabStop = False
        Me.GroupBoxScadenzaAttivita.Text = "Attività"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.dtpAttivita, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonAttivitaCompletata, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(114, 60)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'dtpAttivita
        '
        Me.dtpAttivita.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtpAttivita.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAttivita.Location = New System.Drawing.Point(3, 3)
        Me.dtpAttivita.Name = "dtpAttivita"
        Me.dtpAttivita.ShowCheckBox = True
        Me.dtpAttivita.Size = New System.Drawing.Size(108, 20)
        Me.dtpAttivita.TabIndex = 4
        '
        'CheckBoxAggiornaData
        '
        Me.CheckBoxAggiornaData.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxAggiornaData.AutoSize = True
        Me.CheckBoxAggiornaData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxAggiornaData.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.CheckBoxAggiornaData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxAggiornaData.Location = New System.Drawing.Point(615, 0)
        Me.CheckBoxAggiornaData.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBoxAggiornaData.Name = "CheckBoxAggiornaData"
        Me.tlpNote.SetRowSpan(Me.CheckBoxAggiornaData, 2)
        Me.CheckBoxAggiornaData.Size = New System.Drawing.Size(120, 78)
        Me.CheckBoxAggiornaData.TabIndex = 11
        Me.CheckBoxAggiornaData.Text = "Aggiorna data se modifico la nota"
        Me.CheckBoxAggiornaData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxAggiornaData.UseVisualStyleBackColor = True
        '
        'ButtonRipristinoBackup
        '
        Me.ButtonRipristinoBackup.DefaultBorderSize = 0
        Me.ButtonRipristinoBackup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonRipristinoBackup.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonRipristinoBackup.FlatAppearance.BorderSize = 0
        Me.ButtonRipristinoBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonRipristinoBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRipristinoBackup.Location = New System.Drawing.Point(615, 78)
        Me.ButtonRipristinoBackup.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonRipristinoBackup.Name = "ButtonRipristinoBackup"
        Me.ButtonRipristinoBackup.Size = New System.Drawing.Size(120, 39)
        Me.ButtonRipristinoBackup.TabIndex = 16
        Me.ButtonRipristinoBackup.Text = "UtFlatButton1"
        Me.ButtonRipristinoBackup.UseVisualStyleBackColor = True
        '
        'ButtonStampaDettaglioNote
        '
        Me.ButtonStampaDettaglioNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonStampaDettaglioNote.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonStampaDettaglioNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStampaDettaglioNote.Location = New System.Drawing.Point(420, 0)
        Me.ButtonStampaDettaglioNote.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonStampaDettaglioNote.Name = "ButtonStampaDettaglioNote"
        Me.tlpNote.SetRowSpan(Me.ButtonStampaDettaglioNote, 2)
        Me.ButtonStampaDettaglioNote.Size = New System.Drawing.Size(100, 78)
        Me.ButtonStampaDettaglioNote.TabIndex = 15
        Me.ButtonStampaDettaglioNote.Text = "stampa dettaglio note"
        Me.ButtonStampaDettaglioNote.UseVisualStyleBackColor = True
        '
        'ButtonStampaDettaglio
        '
        Me.ButtonStampaDettaglio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonStampaDettaglio.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonStampaDettaglio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStampaDettaglio.Location = New System.Drawing.Point(320, 0)
        Me.ButtonStampaDettaglio.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonStampaDettaglio.Name = "ButtonStampaDettaglio"
        Me.tlpNote.SetRowSpan(Me.ButtonStampaDettaglio, 2)
        Me.ButtonStampaDettaglio.Size = New System.Drawing.Size(100, 78)
        Me.ButtonStampaDettaglio.TabIndex = 14
        Me.ButtonStampaDettaglio.Text = "stampa dettaglio"
        Me.ButtonStampaDettaglio.UseVisualStyleBackColor = True
        '
        'ButtonConsap
        '
        Me.ButtonConsap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonConsap.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonConsap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonConsap.Location = New System.Drawing.Point(420, 78)
        Me.ButtonConsap.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonConsap.Name = "ButtonConsap"
        Me.ButtonConsap.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tlpNote.SetRowSpan(Me.ButtonConsap, 2)
        Me.ButtonConsap.Size = New System.Drawing.Size(100, 79)
        Me.ButtonConsap.TabIndex = 13
        Me.ButtonConsap.Text = "Consap"
        Me.ButtonConsap.UseVisualStyleBackColor = True
        '
        'ButtonNuovaNota
        '
        Me.ButtonNuovaNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonNuovaNota.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonNuovaNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonNuovaNota.Location = New System.Drawing.Point(0, 0)
        Me.ButtonNuovaNota.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonNuovaNota.Name = "ButtonNuovaNota"
        Me.tlpNote.SetRowSpan(Me.ButtonNuovaNota, 2)
        Me.ButtonNuovaNota.Size = New System.Drawing.Size(100, 78)
        Me.ButtonNuovaNota.TabIndex = 0
        Me.ButtonNuovaNota.Text = "Nuova nota"
        Me.ButtonNuovaNota.UseVisualStyleBackColor = True
        '
        'ButtonCopiaNota
        '
        Me.ButtonCopiaNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCopiaNota.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonCopiaNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCopiaNota.Location = New System.Drawing.Point(100, 0)
        Me.ButtonCopiaNota.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCopiaNota.Name = "ButtonCopiaNota"
        Me.tlpNote.SetRowSpan(Me.ButtonCopiaNota, 2)
        Me.ButtonCopiaNota.Size = New System.Drawing.Size(100, 78)
        Me.ButtonCopiaNota.TabIndex = 1
        Me.ButtonCopiaNota.Text = "copia"
        Me.ButtonCopiaNota.UseVisualStyleBackColor = True
        '
        'ButtonSalvaNota
        '
        Me.ButtonSalvaNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSalvaNota.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonSalvaNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSalvaNota.Location = New System.Drawing.Point(0, 78)
        Me.ButtonSalvaNota.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonSalvaNota.Name = "ButtonSalvaNota"
        Me.tlpNote.SetRowSpan(Me.ButtonSalvaNota, 2)
        Me.ButtonSalvaNota.Size = New System.Drawing.Size(100, 79)
        Me.ButtonSalvaNota.TabIndex = 2
        Me.ButtonSalvaNota.Text = "salva"
        Me.ButtonSalvaNota.UseVisualStyleBackColor = True
        '
        'ButtonCancellaNota
        '
        Me.ButtonCancellaNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCancellaNota.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonCancellaNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancellaNota.Location = New System.Drawing.Point(100, 78)
        Me.ButtonCancellaNota.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCancellaNota.Name = "ButtonCancellaNota"
        Me.tlpNote.SetRowSpan(Me.ButtonCancellaNota, 2)
        Me.ButtonCancellaNota.Size = New System.Drawing.Size(100, 79)
        Me.ButtonCancellaNota.TabIndex = 3
        Me.ButtonCancellaNota.Text = "cancella"
        Me.ButtonCancellaNota.UseVisualStyleBackColor = True
        '
        'ButtonStampaNota
        '
        Me.ButtonStampaNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonStampaNota.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonStampaNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStampaNota.Location = New System.Drawing.Point(200, 0)
        Me.ButtonStampaNota.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonStampaNota.Name = "ButtonStampaNota"
        Me.tlpNote.SetRowSpan(Me.ButtonStampaNota, 2)
        Me.ButtonStampaNota.Size = New System.Drawing.Size(120, 78)
        Me.ButtonStampaNota.TabIndex = 5
        Me.ButtonStampaNota.Text = "stampa"
        Me.ButtonStampaNota.UseVisualStyleBackColor = True
        '
        'ButtonAttivitaCompletata
        '
        Me.ButtonAttivitaCompletata.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAttivitaCompletata.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAttivitaCompletata.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAttivitaCompletata.Location = New System.Drawing.Point(0, 30)
        Me.ButtonAttivitaCompletata.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAttivitaCompletata.Name = "ButtonAttivitaCompletata"
        Me.ButtonAttivitaCompletata.Size = New System.Drawing.Size(114, 30)
        Me.ButtonAttivitaCompletata.TabIndex = 6
        Me.ButtonAttivitaCompletata.Text = "Completata"
        Me.ButtonAttivitaCompletata.UseVisualStyleBackColor = True
        '
        'ButtonNotifiche
        '
        Me.ButtonNotifiche.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonNotifiche.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonNotifiche.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonNotifiche.Location = New System.Drawing.Point(320, 78)
        Me.ButtonNotifiche.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonNotifiche.Name = "ButtonNotifiche"
        Me.tlpNote.SetRowSpan(Me.ButtonNotifiche, 2)
        Me.ButtonNotifiche.Size = New System.Drawing.Size(100, 79)
        Me.ButtonNotifiche.TabIndex = 8
        Me.ButtonNotifiche.Text = "Notifiche sms"
        Me.ButtonNotifiche.UseVisualStyleBackColor = True
        '
        'ButtonRipristinoNote
        '
        Me.ButtonRipristinoNote.DefaultBorderSize = 0
        Me.ButtonRipristinoNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonRipristinoNote.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonRipristinoNote.FlatAppearance.BorderSize = 0
        Me.ButtonRipristinoNote.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonRipristinoNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRipristinoNote.Location = New System.Drawing.Point(615, 117)
        Me.ButtonRipristinoNote.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonRipristinoNote.Name = "ButtonRipristinoNote"
        Me.ButtonRipristinoNote.Size = New System.Drawing.Size(120, 40)
        Me.ButtonRipristinoNote.TabIndex = 12
        Me.ButtonRipristinoNote.Text = "UtFlatButton1"
        Me.ButtonRipristinoNote.UseVisualStyleBackColor = True
        '
        'ucNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ucNote"
        Me.Size = New System.Drawing.Size(1104, 592)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDocumenti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.tlpNote.ResumeLayout(False)
        Me.tlpNote.PerformLayout()
        Me.GroupBoxScadenzaAttivita.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents TextBoxNota As System.Windows.Forms.TextBox
    Friend WithEvents dgvNote As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RadioButtonNote As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonAttivita As System.Windows.Forms.RadioButton
    Friend WithEvents tlpNote As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonNuovaNota As Utx.MyFlatButton
    Friend WithEvents ButtonCopiaNota As Utx.MyFlatButton
    Friend WithEvents ButtonSalvaNota As Utx.MyFlatButton
    Friend WithEvents ButtonCancellaNota As Utx.MyFlatButton
    Friend WithEvents dtpAttivita As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonStampaNota As Utx.MyFlatButton
    Friend WithEvents ButtonAttivitaCompletata As Utx.MyFlatButton
    Friend WithEvents GroupBoxScadenzaAttivita As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonNotifiche As Utx.MyFlatButton
    Friend WithEvents CheckBoxAggiornaData As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonRipristinoNote As UtControls.UtFlatButton
    Friend WithEvents ButtonConsap As Utx.MyFlatButton
    Friend WithEvents ButtonStampaDettaglioNote As Utx.MyFlatButton
    Friend WithEvents ButtonStampaDettaglio As Utx.MyFlatButton
    Friend WithEvents dgvDocumenti As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonRipristinoBackup As UtControls.UtFlatButton

End Class
