<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fotocopia
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanelScan = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBoxScanner = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanelScanner = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelColore = New System.Windows.Forms.Label()
        Me.LabelGrigi = New System.Windows.Forms.Label()
        Me.LabelNero = New System.Windows.Forms.Label()
        Me.LabelBianco = New System.Windows.Forms.Label()
        Me.tbChiaroScuro = New System.Windows.Forms.TrackBar()
        Me.btnSelezionaScanner = New System.Windows.Forms.Button()
        Me.ComboBoxRisoluzione = New System.Windows.Forms.ComboBox()
        Me.ComboBoxFormato = New System.Windows.Forms.ComboBox()
        Me.chkDuplex = New System.Windows.Forms.CheckBox()
        Me.LabelChiaroScuro = New System.Windows.Forms.Label()
        Me.rbBianoNero = New System.Windows.Forms.RadioButton()
        Me.rbColori = New System.Windows.Forms.RadioButton()
        Me.rbScalaGrigi = New System.Windows.Forms.RadioButton()
        Me.txtChiaroScuro = New System.Windows.Forms.TextBox()
        Me.ComboBoxSource = New System.Windows.Forms.ComboBox()
        Me.btnScanNuovo = New System.Windows.Forms.Button()
        Me.btnFineDoc = New System.Windows.Forms.Button()
        Me.LabelStato = New System.Windows.Forms.Label()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.btnStampa = New System.Windows.Forms.Button()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.Twain = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain()
        Me.LinkLabelPDF = New System.Windows.Forms.LinkLabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanelScan.SuspendLayout()
        Me.GroupBoxScanner.SuspendLayout()
        Me.TableLayoutPanelScanner.SuspendLayout()
        CType(Me.tbChiaroScuro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanelScan, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Twain, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(614, 533)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanelScan
        '
        Me.TableLayoutPanelScan.ColumnCount = 4
        Me.TableLayoutPanelScan.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelScan.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelScan.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelScan.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelScan.Controls.Add(Me.LinkLabelPDF, 0, 11)
        Me.TableLayoutPanelScan.Controls.Add(Me.GroupBoxScanner, 0, 0)
        Me.TableLayoutPanelScan.Controls.Add(Me.btnScanNuovo, 0, 12)
        Me.TableLayoutPanelScan.Controls.Add(Me.btnFineDoc, 0, 15)
        Me.TableLayoutPanelScan.Controls.Add(Me.LabelStato, 0, 14)
        Me.TableLayoutPanelScan.Controls.Add(Me.btnEsci, 0, 18)
        Me.TableLayoutPanelScan.Controls.Add(Me.btnStampa, 2, 17)
        Me.TableLayoutPanelScan.Controls.Add(Me.btnSalva, 0, 17)
        Me.TableLayoutPanelScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelScan.Location = New System.Drawing.Point(387, 3)
        Me.TableLayoutPanelScan.Name = "TableLayoutPanelScan"
        Me.TableLayoutPanelScan.RowCount = 20
        Me.TableLayoutPanel1.SetRowSpan(Me.TableLayoutPanelScan, 2)
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.114625!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.766798!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelScan.Size = New System.Drawing.Size(224, 527)
        Me.TableLayoutPanelScan.TabIndex = 6
        '
        'GroupBoxScanner
        '
        Me.GroupBoxScanner.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanelScan.SetColumnSpan(Me.GroupBoxScanner, 4)
        Me.GroupBoxScanner.Controls.Add(Me.TableLayoutPanelScanner)
        Me.GroupBoxScanner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxScanner.ForeColor = System.Drawing.Color.DarkRed
        Me.GroupBoxScanner.Location = New System.Drawing.Point(3, 3)
        Me.GroupBoxScanner.Name = "GroupBoxScanner"
        Me.TableLayoutPanelScan.SetRowSpan(Me.GroupBoxScanner, 11)
        Me.GroupBoxScanner.Size = New System.Drawing.Size(218, 280)
        Me.GroupBoxScanner.TabIndex = 2
        Me.GroupBoxScanner.TabStop = False
        Me.GroupBoxScanner.Text = "Opzioni scansione"
        '
        'TableLayoutPanelScanner
        '
        Me.TableLayoutPanelScanner.ColumnCount = 3
        Me.TableLayoutPanelScanner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanelScanner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelScanner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelScanner.Controls.Add(Me.LabelColore, 1, 5)
        Me.TableLayoutPanelScanner.Controls.Add(Me.LabelGrigi, 1, 4)
        Me.TableLayoutPanelScanner.Controls.Add(Me.LabelNero, 2, 3)
        Me.TableLayoutPanelScanner.Controls.Add(Me.LabelBianco, 0, 3)
        Me.TableLayoutPanelScanner.Controls.Add(Me.tbChiaroScuro, 0, 8)
        Me.TableLayoutPanelScanner.Controls.Add(Me.btnSelezionaScanner, 1, 0)
        Me.TableLayoutPanelScanner.Controls.Add(Me.ComboBoxRisoluzione, 0, 1)
        Me.TableLayoutPanelScanner.Controls.Add(Me.ComboBoxFormato, 0, 2)
        Me.TableLayoutPanelScanner.Controls.Add(Me.chkDuplex, 0, 6)
        Me.TableLayoutPanelScanner.Controls.Add(Me.LabelChiaroScuro, 0, 7)
        Me.TableLayoutPanelScanner.Controls.Add(Me.rbBianoNero, 0, 3)
        Me.TableLayoutPanelScanner.Controls.Add(Me.rbColori, 0, 5)
        Me.TableLayoutPanelScanner.Controls.Add(Me.rbScalaGrigi, 0, 4)
        Me.TableLayoutPanelScanner.Controls.Add(Me.txtChiaroScuro, 1, 8)
        Me.TableLayoutPanelScanner.Controls.Add(Me.ComboBoxSource, 0, 0)
        Me.TableLayoutPanelScanner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelScanner.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanelScanner.Name = "TableLayoutPanelScanner"
        Me.TableLayoutPanelScanner.RowCount = 9
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.93957!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.93957!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.93957!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.93957!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.93957!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.93957!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.93957!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.32201!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.10102!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelScanner.Size = New System.Drawing.Size(212, 261)
        Me.TableLayoutPanelScanner.TabIndex = 24
        '
        'LabelColore
        '
        Me.LabelColore.AutoSize = True
        Me.LabelColore.BackColor = System.Drawing.Color.LightSeaGreen
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.LabelColore, 2)
        Me.LabelColore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelColore.Location = New System.Drawing.Point(169, 152)
        Me.LabelColore.Margin = New System.Windows.Forms.Padding(0, 12, 1, 12)
        Me.LabelColore.Name = "LabelColore"
        Me.LabelColore.Size = New System.Drawing.Size(42, 4)
        Me.LabelColore.TabIndex = 20
        '
        'LabelGrigi
        '
        Me.LabelGrigi.AutoSize = True
        Me.LabelGrigi.BackColor = System.Drawing.Color.LightGray
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.LabelGrigi, 2)
        Me.LabelGrigi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelGrigi.Location = New System.Drawing.Point(169, 124)
        Me.LabelGrigi.Margin = New System.Windows.Forms.Padding(0, 12, 1, 12)
        Me.LabelGrigi.Name = "LabelGrigi"
        Me.LabelGrigi.Size = New System.Drawing.Size(42, 4)
        Me.LabelGrigi.TabIndex = 19
        '
        'LabelNero
        '
        Me.LabelNero.AutoSize = True
        Me.LabelNero.BackColor = System.Drawing.Color.Black
        Me.LabelNero.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelNero.Location = New System.Drawing.Point(190, 96)
        Me.LabelNero.Margin = New System.Windows.Forms.Padding(0, 12, 1, 12)
        Me.LabelNero.Name = "LabelNero"
        Me.LabelNero.Size = New System.Drawing.Size(21, 4)
        Me.LabelNero.TabIndex = 18
        '
        'LabelBianco
        '
        Me.LabelBianco.AutoSize = True
        Me.LabelBianco.BackColor = System.Drawing.Color.White
        Me.LabelBianco.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelBianco.Location = New System.Drawing.Point(169, 96)
        Me.LabelBianco.Margin = New System.Windows.Forms.Padding(0, 12, 0, 12)
        Me.LabelBianco.Name = "LabelBianco"
        Me.LabelBianco.Size = New System.Drawing.Size(21, 4)
        Me.LabelBianco.TabIndex = 12
        '
        'tbChiaroScuro
        '
        Me.tbChiaroScuro.BackColor = System.Drawing.Color.Gainsboro
        Me.tbChiaroScuro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbChiaroScuro.Location = New System.Drawing.Point(3, 225)
        Me.tbChiaroScuro.Name = "tbChiaroScuro"
        Me.tbChiaroScuro.Size = New System.Drawing.Size(163, 33)
        Me.tbChiaroScuro.TabIndex = 9
        '
        'btnSelezionaScanner
        '
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.btnSelezionaScanner, 2)
        Me.btnSelezionaScanner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSelezionaScanner.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelezionaScanner.Location = New System.Drawing.Point(172, 3)
        Me.btnSelezionaScanner.Name = "btnSelezionaScanner"
        Me.btnSelezionaScanner.Size = New System.Drawing.Size(37, 22)
        Me.btnSelezionaScanner.TabIndex = 1
        Me.btnSelezionaScanner.Text = "..."
        Me.btnSelezionaScanner.UseVisualStyleBackColor = True
        '
        'ComboBoxRisoluzione
        '
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.ComboBoxRisoluzione, 3)
        Me.ComboBoxRisoluzione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxRisoluzione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxRisoluzione.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxRisoluzione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxRisoluzione.FormattingEnabled = True
        Me.ComboBoxRisoluzione.Location = New System.Drawing.Point(3, 31)
        Me.ComboBoxRisoluzione.Name = "ComboBoxRisoluzione"
        Me.ComboBoxRisoluzione.Size = New System.Drawing.Size(206, 22)
        Me.ComboBoxRisoluzione.TabIndex = 2
        '
        'ComboBoxFormato
        '
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.ComboBoxFormato, 3)
        Me.ComboBoxFormato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxFormato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxFormato.FormattingEnabled = True
        Me.ComboBoxFormato.Location = New System.Drawing.Point(3, 59)
        Me.ComboBoxFormato.Name = "ComboBoxFormato"
        Me.ComboBoxFormato.Size = New System.Drawing.Size(206, 22)
        Me.ComboBoxFormato.TabIndex = 3
        '
        'chkDuplex
        '
        Me.chkDuplex.AutoSize = True
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.chkDuplex, 3)
        Me.chkDuplex.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkDuplex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkDuplex.Location = New System.Drawing.Point(3, 171)
        Me.chkDuplex.Name = "chkDuplex"
        Me.chkDuplex.Size = New System.Drawing.Size(206, 22)
        Me.chkDuplex.TabIndex = 7
        Me.chkDuplex.Text = "Fronte/Retro"
        Me.chkDuplex.UseVisualStyleBackColor = True
        '
        'LabelChiaroScuro
        '
        Me.LabelChiaroScuro.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.LabelChiaroScuro, 3)
        Me.LabelChiaroScuro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelChiaroScuro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelChiaroScuro.Location = New System.Drawing.Point(3, 196)
        Me.LabelChiaroScuro.Name = "LabelChiaroScuro"
        Me.LabelChiaroScuro.Size = New System.Drawing.Size(206, 26)
        Me.LabelChiaroScuro.TabIndex = 8
        Me.LabelChiaroScuro.Text = "Chiaro - Scuro"
        Me.LabelChiaroScuro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'rbBianoNero
        '
        Me.rbBianoNero.AutoSize = True
        Me.rbBianoNero.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbBianoNero.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbBianoNero.Location = New System.Drawing.Point(3, 87)
        Me.rbBianoNero.Name = "rbBianoNero"
        Me.rbBianoNero.Size = New System.Drawing.Size(163, 22)
        Me.rbBianoNero.TabIndex = 4
        Me.rbBianoNero.TabStop = True
        Me.rbBianoNero.Text = "Scansione in Bianco e Nero"
        Me.rbBianoNero.UseVisualStyleBackColor = True
        '
        'rbColori
        '
        Me.rbColori.AutoSize = True
        Me.rbColori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbColori.ForeColor = System.Drawing.Color.DodgerBlue
        Me.rbColori.Location = New System.Drawing.Point(3, 143)
        Me.rbColori.Name = "rbColori"
        Me.rbColori.Size = New System.Drawing.Size(163, 22)
        Me.rbColori.TabIndex = 6
        Me.rbColori.TabStop = True
        Me.rbColori.Text = "Scansione a colori"
        Me.rbColori.UseVisualStyleBackColor = True
        '
        'rbScalaGrigi
        '
        Me.rbScalaGrigi.AutoSize = True
        Me.rbScalaGrigi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbScalaGrigi.ForeColor = System.Drawing.Color.DimGray
        Me.rbScalaGrigi.Location = New System.Drawing.Point(3, 115)
        Me.rbScalaGrigi.Name = "rbScalaGrigi"
        Me.rbScalaGrigi.Size = New System.Drawing.Size(163, 22)
        Me.rbScalaGrigi.TabIndex = 5
        Me.rbScalaGrigi.TabStop = True
        Me.rbScalaGrigi.Text = "Scansione in scala di grigi"
        Me.rbScalaGrigi.UseVisualStyleBackColor = True
        '
        'txtChiaroScuro
        '
        Me.txtChiaroScuro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.txtChiaroScuro, 2)
        Me.txtChiaroScuro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChiaroScuro.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiaroScuro.Location = New System.Drawing.Point(172, 225)
        Me.txtChiaroScuro.MaxLength = 3
        Me.txtChiaroScuro.Name = "txtChiaroScuro"
        Me.txtChiaroScuro.Size = New System.Drawing.Size(37, 30)
        Me.txtChiaroScuro.TabIndex = 10
        Me.txtChiaroScuro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboBoxSource
        '
        Me.ComboBoxSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxSource.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxSource.FormattingEnabled = True
        Me.ComboBoxSource.Location = New System.Drawing.Point(3, 3)
        Me.ComboBoxSource.Name = "ComboBoxSource"
        Me.ComboBoxSource.Size = New System.Drawing.Size(163, 22)
        Me.ComboBoxSource.TabIndex = 0
        '
        'btnScanNuovo
        '
        Me.TableLayoutPanelScan.SetColumnSpan(Me.btnScanNuovo, 4)
        Me.btnScanNuovo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnScanNuovo.Location = New System.Drawing.Point(3, 315)
        Me.btnScanNuovo.Name = "btnScanNuovo"
        Me.TableLayoutPanelScan.SetRowSpan(Me.btnScanNuovo, 2)
        Me.btnScanNuovo.Size = New System.Drawing.Size(218, 46)
        Me.btnScanNuovo.TabIndex = 0
        Me.btnScanNuovo.Text = "Acquisisci nuovo documento"
        Me.btnScanNuovo.UseVisualStyleBackColor = True
        '
        'btnFineDoc
        '
        Me.TableLayoutPanelScan.SetColumnSpan(Me.btnFineDoc, 4)
        Me.btnFineDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnFineDoc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFineDoc.Location = New System.Drawing.Point(3, 393)
        Me.btnFineDoc.Name = "btnFineDoc"
        Me.TableLayoutPanelScan.SetRowSpan(Me.btnFineDoc, 2)
        Me.btnFineDoc.Size = New System.Drawing.Size(218, 46)
        Me.btnFineDoc.TabIndex = 4
        Me.btnFineDoc.Text = "Fine documento"
        Me.btnFineDoc.UseVisualStyleBackColor = True
        '
        'LabelStato
        '
        Me.LabelStato.BackColor = System.Drawing.SystemColors.Control
        Me.LabelStato.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanelScan.SetColumnSpan(Me.LabelStato, 4)
        Me.LabelStato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelStato.Location = New System.Drawing.Point(3, 364)
        Me.LabelStato.Name = "LabelStato"
        Me.LabelStato.Size = New System.Drawing.Size(218, 26)
        Me.LabelStato.TabIndex = 5
        Me.LabelStato.Text = "LabelStato"
        Me.LabelStato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnEsci
        '
        Me.TableLayoutPanelScan.SetColumnSpan(Me.btnEsci, 4)
        Me.btnEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsci.Location = New System.Drawing.Point(3, 482)
        Me.btnEsci.Name = "btnEsci"
        Me.TableLayoutPanelScan.SetRowSpan(Me.btnEsci, 2)
        Me.btnEsci.Size = New System.Drawing.Size(218, 42)
        Me.btnEsci.TabIndex = 6
        Me.btnEsci.Text = "Button1"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'btnStampa
        '
        Me.TableLayoutPanelScan.SetColumnSpan(Me.btnStampa, 2)
        Me.btnStampa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnStampa.Location = New System.Drawing.Point(115, 445)
        Me.btnStampa.Name = "btnStampa"
        Me.btnStampa.Size = New System.Drawing.Size(106, 31)
        Me.btnStampa.TabIndex = 7
        Me.btnStampa.Text = "Stampa"
        Me.btnStampa.UseVisualStyleBackColor = True
        '
        'btnSalva
        '
        Me.TableLayoutPanelScan.SetColumnSpan(Me.btnSalva, 2)
        Me.btnSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSalva.Location = New System.Drawing.Point(3, 445)
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(106, 31)
        Me.btnSalva.TabIndex = 8
        Me.btnSalva.Text = "Salva"
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'Twain
        '
        Me.Twain.AnnotationFillColor = System.Drawing.Color.White
        Me.Twain.AnnotationPen = Nothing
        Me.Twain.AnnotationTextColor = System.Drawing.Color.Black
        Me.Twain.AnnotationTextFont = Nothing
        Me.Twain.BorderStyle = Dynamsoft.DotNet.TWAIN.Enums.DWTWndBorderStyle.SingleFlat
        Me.Twain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Twain.IfShowCancelDialogWhenImageTransfer = False
        Me.Twain.IfShowPrintUI = False
        Me.Twain.IfThrowException = False
        Me.Twain.Location = New System.Drawing.Point(3, 3)
        Me.Twain.LogLevel = CType(0, Short)
        Me.Twain.Name = "Twain"
        Me.Twain.PDFMarginBottom = CType(0UI, UInteger)
        Me.Twain.PDFMarginLeft = CType(0UI, UInteger)
        Me.Twain.PDFMarginRight = CType(0UI, UInteger)
        Me.Twain.PDFMarginTop = CType(0UI, UInteger)
        Me.Twain.PDFXConformance = CType(0UI, UInteger)
        Me.Twain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TableLayoutPanel1.SetRowSpan(Me.Twain, 2)
        Me.Twain.Size = New System.Drawing.Size(378, 527)
        Me.Twain.TabIndex = 7
        '
        'LinkLabelPDF
        '
        Me.LinkLabelPDF.AutoSize = True
        Me.TableLayoutPanelScan.SetColumnSpan(Me.LinkLabelPDF, 4)
        Me.LinkLabelPDF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LinkLabelPDF.Location = New System.Drawing.Point(3, 286)
        Me.LinkLabelPDF.Name = "LinkLabelPDF"
        Me.LinkLabelPDF.Size = New System.Drawing.Size(218, 26)
        Me.LinkLabelPDF.TabIndex = 26
        Me.LinkLabelPDF.TabStop = True
        Me.LinkLabelPDF.Text = "Utilità gestione PDF"
        Me.LinkLabelPDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Fotocopia
        '
        Me.AcceptButton = Me.btnScanNuovo
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 533)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Fotocopia"
        Me.Text = "Fotocopia"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanelScan.ResumeLayout(False)
        Me.TableLayoutPanelScan.PerformLayout()
        Me.GroupBoxScanner.ResumeLayout(False)
        Me.TableLayoutPanelScanner.ResumeLayout(False)
        Me.TableLayoutPanelScanner.PerformLayout()
        CType(Me.tbChiaroScuro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanelScan As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBoxScanner As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanelScanner As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbChiaroScuro As System.Windows.Forms.TrackBar
    Friend WithEvents btnSelezionaScanner As System.Windows.Forms.Button
    Friend WithEvents ComboBoxRisoluzione As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxFormato As System.Windows.Forms.ComboBox
    Friend WithEvents chkDuplex As System.Windows.Forms.CheckBox
    Friend WithEvents LabelChiaroScuro As System.Windows.Forms.Label
    Friend WithEvents rbBianoNero As System.Windows.Forms.RadioButton
    Friend WithEvents rbColori As System.Windows.Forms.RadioButton
    Friend WithEvents rbScalaGrigi As System.Windows.Forms.RadioButton
    Friend WithEvents txtChiaroScuro As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxSource As System.Windows.Forms.ComboBox
    Friend WithEvents btnScanNuovo As System.Windows.Forms.Button
    Friend WithEvents btnFineDoc As System.Windows.Forms.Button
    Friend WithEvents LabelStato As System.Windows.Forms.Label
    Friend WithEvents Twain As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents btnStampa As System.Windows.Forms.Button
    Friend WithEvents btnSalva As System.Windows.Forms.Button
    Friend WithEvents LabelBianco As System.Windows.Forms.Label
    Friend WithEvents LabelNero As System.Windows.Forms.Label
    Friend WithEvents LabelGrigi As System.Windows.Forms.Label
    Friend WithEvents LabelColore As System.Windows.Forms.Label
    Friend WithEvents LinkLabelPDF As Windows.Forms.LinkLabel
End Class
