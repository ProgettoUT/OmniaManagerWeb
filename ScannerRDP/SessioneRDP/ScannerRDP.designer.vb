<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScannerRDP
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
        Me.TableLayoutPanelMain = New System.Windows.Forms.TableLayoutPanel()
        Me.lbPratica = New System.Windows.Forms.Label()
        Me.lbInvia = New System.Windows.Forms.ListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TableLayoutPanelScan = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonSelezionaCartellaUtente = New System.Windows.Forms.Button()
        Me.ButtonCartellaUtente = New System.Windows.Forms.Button()
        Me.GroupBoxScanner = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanelScanner = New System.Windows.Forms.TableLayoutPanel()
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
        Me.btnDesktop = New System.Windows.Forms.Button()
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Twain = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanelMain.SuspendLayout
        Me.TableLayoutPanelScan.SuspendLayout
        Me.GroupBoxScanner.SuspendLayout
        Me.TableLayoutPanelScanner.SuspendLayout
        CType(Me.tbChiaroScuro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanelMain
        '
        Me.TableLayoutPanelMain.ColumnCount = 3
        Me.TableLayoutPanelMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61.0!))
        Me.TableLayoutPanelMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 215.0!))
        Me.TableLayoutPanelMain.Controls.Add(Me.lbPratica, 1, 1)
        Me.TableLayoutPanelMain.Controls.Add(Me.lbInvia, 0, 4)
        Me.TableLayoutPanelMain.Controls.Add(Me.Label8, 0, 1)
        Me.TableLayoutPanelMain.Controls.Add(Me.TableLayoutPanelScan, 2, 0)
        Me.TableLayoutPanelMain.Controls.Add(Me.lbCliente, 1, 0)
        Me.TableLayoutPanelMain.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanelMain.Controls.Add(Me.Twain, 0, 2)
        Me.TableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelMain.Name = "TableLayoutPanelMain"
        Me.TableLayoutPanelMain.RowCount = 5
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanelMain.Size = New System.Drawing.Size(585, 528)
        Me.TableLayoutPanelMain.TabIndex = 0
        '
        'lbPratica
        '
        Me.lbPratica.AutoSize = True
        Me.lbPratica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbPratica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbPratica.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPratica.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbPratica.Location = New System.Drawing.Point(64, 20)
        Me.lbPratica.Name = "lbPratica"
        Me.lbPratica.Size = New System.Drawing.Size(303, 20)
        Me.lbPratica.TabIndex = 38
        Me.lbPratica.Text = "lbPratica"
        Me.lbPratica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbInvia
        '
        Me.lbInvia.AllowDrop = True
        Me.lbInvia.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbInvia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanelMain.SetColumnSpan(Me.lbInvia, 2)
        Me.lbInvia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbInvia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbInvia.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbInvia.FormattingEnabled = True
        Me.lbInvia.IntegralHeight = False
        Me.lbInvia.Location = New System.Drawing.Point(3, 471)
        Me.lbInvia.Name = "lbInvia"
        Me.lbInvia.Size = New System.Drawing.Size(364, 54)
        Me.lbInvia.TabIndex = 39
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(3, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 20)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Cartella"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanelScan
        '
        Me.TableLayoutPanelScan.ColumnCount = 4
        Me.TableLayoutPanelScan.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelScan.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelScan.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelScan.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelScan.Controls.Add(Me.ButtonSelezionaCartellaUtente, 4, 18)
        Me.TableLayoutPanelScan.Controls.Add(Me.ButtonCartellaUtente, 0, 18)
        Me.TableLayoutPanelScan.Controls.Add(Me.GroupBoxScanner, 0, 0)
        Me.TableLayoutPanelScan.Controls.Add(Me.btnScanNuovo, 0, 12)
        Me.TableLayoutPanelScan.Controls.Add(Me.btnFineDoc, 0, 15)
        Me.TableLayoutPanelScan.Controls.Add(Me.LabelStato, 0, 14)
        Me.TableLayoutPanelScan.Controls.Add(Me.btnEsci, 0, 19)
        Me.TableLayoutPanelScan.Controls.Add(Me.btnDesktop, 0, 17)
        Me.TableLayoutPanelScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelScan.Location = New System.Drawing.Point(373, 3)
        Me.TableLayoutPanelScan.Name = "TableLayoutPanelScan"
        Me.TableLayoutPanelScan.RowCount = 20
        Me.TableLayoutPanelMain.SetRowSpan(Me.TableLayoutPanelScan, 5)
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.835973!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.929487!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.929487!))
        Me.TableLayoutPanelScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.929487!))
        Me.TableLayoutPanelScan.Size = New System.Drawing.Size(209, 522)
        Me.TableLayoutPanelScan.TabIndex = 6
        '
        'ButtonSelezionaCartellaUtente
        '
        Me.ButtonSelezionaCartellaUtente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSelezionaCartellaUtente.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonSelezionaCartellaUtente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSelezionaCartellaUtente.Location = New System.Drawing.Point(157, 456)
        Me.ButtonSelezionaCartellaUtente.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonSelezionaCartellaUtente.Name = "ButtonSelezionaCartellaUtente"
        Me.ButtonSelezionaCartellaUtente.Size = New System.Drawing.Size(51, 28)
        Me.ButtonSelezionaCartellaUtente.TabIndex = 10
        Me.ButtonSelezionaCartellaUtente.Text = "..."
        Me.ButtonSelezionaCartellaUtente.UseVisualStyleBackColor = True
        '
        'ButtonCartellaUtente
        '
        Me.TableLayoutPanelScan.SetColumnSpan(Me.ButtonCartellaUtente, 3)
        Me.ButtonCartellaUtente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCartellaUtente.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonCartellaUtente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCartellaUtente.Location = New System.Drawing.Point(1, 456)
        Me.ButtonCartellaUtente.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonCartellaUtente.Name = "ButtonCartellaUtente"
        Me.ButtonCartellaUtente.Size = New System.Drawing.Size(154, 28)
        Me.ButtonCartellaUtente.TabIndex = 9
        Me.ButtonCartellaUtente.Text = "Cartella utente"
        Me.ButtonCartellaUtente.UseVisualStyleBackColor = True
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
        Me.TableLayoutPanelScan.SetRowSpan(Me.GroupBoxScanner, 12)
        Me.GroupBoxScanner.Size = New System.Drawing.Size(203, 294)
        Me.GroupBoxScanner.TabIndex = 2
        Me.GroupBoxScanner.TabStop = False
        Me.GroupBoxScanner.Text = "Opzioni scansione"
        '
        'TableLayoutPanelScanner
        '
        Me.TableLayoutPanelScanner.ColumnCount = 2
        Me.TableLayoutPanelScanner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.35593!))
        Me.TableLayoutPanelScanner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.64407!))
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
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.48387!))
        Me.TableLayoutPanelScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.30645!))
        Me.TableLayoutPanelScanner.Size = New System.Drawing.Size(197, 275)
        Me.TableLayoutPanelScanner.TabIndex = 24
        '
        'tbChiaroScuro
        '
        Me.tbChiaroScuro.BackColor = System.Drawing.Color.Gainsboro
        Me.tbChiaroScuro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbChiaroScuro.Location = New System.Drawing.Point(3, 241)
        Me.tbChiaroScuro.Name = "tbChiaroScuro"
        Me.tbChiaroScuro.Size = New System.Drawing.Size(154, 31)
        Me.tbChiaroScuro.TabIndex = 9
        '
        'btnSelezionaScanner
        '
        Me.btnSelezionaScanner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSelezionaScanner.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelezionaScanner.Location = New System.Drawing.Point(163, 3)
        Me.btnSelezionaScanner.Name = "btnSelezionaScanner"
        Me.btnSelezionaScanner.Size = New System.Drawing.Size(31, 24)
        Me.btnSelezionaScanner.TabIndex = 1
        Me.btnSelezionaScanner.Text = "..."
        Me.btnSelezionaScanner.UseVisualStyleBackColor = True
        '
        'ComboBoxRisoluzione
        '
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.ComboBoxRisoluzione, 2)
        Me.ComboBoxRisoluzione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxRisoluzione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxRisoluzione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxRisoluzione.FormattingEnabled = True
        Me.ComboBoxRisoluzione.Location = New System.Drawing.Point(3, 33)
        Me.ComboBoxRisoluzione.Name = "ComboBoxRisoluzione"
        Me.ComboBoxRisoluzione.Size = New System.Drawing.Size(191, 22)
        Me.ComboBoxRisoluzione.TabIndex = 2
        '
        'ComboBoxFormato
        '
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.ComboBoxFormato, 2)
        Me.ComboBoxFormato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFormato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxFormato.FormattingEnabled = True
        Me.ComboBoxFormato.Location = New System.Drawing.Point(3, 63)
        Me.ComboBoxFormato.Name = "ComboBoxFormato"
        Me.ComboBoxFormato.Size = New System.Drawing.Size(191, 22)
        Me.ComboBoxFormato.TabIndex = 3
        '
        'chkDuplex
        '
        Me.chkDuplex.AutoSize = True
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.chkDuplex, 2)
        Me.chkDuplex.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkDuplex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkDuplex.Location = New System.Drawing.Point(3, 183)
        Me.chkDuplex.Name = "chkDuplex"
        Me.chkDuplex.Size = New System.Drawing.Size(191, 24)
        Me.chkDuplex.TabIndex = 7
        Me.chkDuplex.Text = "Fronte/Retro"
        Me.chkDuplex.UseVisualStyleBackColor = True
        '
        'LabelChiaroScuro
        '
        Me.LabelChiaroScuro.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.LabelChiaroScuro, 2)
        Me.LabelChiaroScuro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelChiaroScuro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelChiaroScuro.Location = New System.Drawing.Point(3, 210)
        Me.LabelChiaroScuro.Name = "LabelChiaroScuro"
        Me.LabelChiaroScuro.Size = New System.Drawing.Size(191, 28)
        Me.LabelChiaroScuro.TabIndex = 8
        Me.LabelChiaroScuro.Text = "Chiaro - Scuro"
        Me.LabelChiaroScuro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'rbBianoNero
        '
        Me.rbBianoNero.AutoSize = True
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.rbBianoNero, 2)
        Me.rbBianoNero.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbBianoNero.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbBianoNero.Location = New System.Drawing.Point(3, 93)
        Me.rbBianoNero.Name = "rbBianoNero"
        Me.rbBianoNero.Size = New System.Drawing.Size(191, 24)
        Me.rbBianoNero.TabIndex = 4
        Me.rbBianoNero.TabStop = True
        Me.rbBianoNero.Text = "Scansione in Bianco e Nero"
        Me.rbBianoNero.UseVisualStyleBackColor = True
        '
        'rbColori
        '
        Me.rbColori.AutoSize = True
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.rbColori, 2)
        Me.rbColori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbColori.ForeColor = System.Drawing.Color.DodgerBlue
        Me.rbColori.Location = New System.Drawing.Point(3, 153)
        Me.rbColori.Name = "rbColori"
        Me.rbColori.Size = New System.Drawing.Size(191, 24)
        Me.rbColori.TabIndex = 6
        Me.rbColori.TabStop = True
        Me.rbColori.Text = "Scansione a colori"
        Me.rbColori.UseVisualStyleBackColor = True
        '
        'rbScalaGrigi
        '
        Me.rbScalaGrigi.AutoSize = True
        Me.TableLayoutPanelScanner.SetColumnSpan(Me.rbScalaGrigi, 2)
        Me.rbScalaGrigi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbScalaGrigi.ForeColor = System.Drawing.Color.DimGray
        Me.rbScalaGrigi.Location = New System.Drawing.Point(3, 123)
        Me.rbScalaGrigi.Name = "rbScalaGrigi"
        Me.rbScalaGrigi.Size = New System.Drawing.Size(191, 24)
        Me.rbScalaGrigi.TabIndex = 5
        Me.rbScalaGrigi.TabStop = True
        Me.rbScalaGrigi.Text = "Scansione in scala di grigi"
        Me.rbScalaGrigi.UseVisualStyleBackColor = True
        '
        'txtChiaroScuro
        '
        Me.txtChiaroScuro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChiaroScuro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChiaroScuro.Font = New System.Drawing.Font("Tahoma", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiaroScuro.Location = New System.Drawing.Point(163, 241)
        Me.txtChiaroScuro.MaxLength = 3
        Me.txtChiaroScuro.Name = "txtChiaroScuro"
        Me.txtChiaroScuro.Size = New System.Drawing.Size(31, 28)
        Me.txtChiaroScuro.TabIndex = 10
        Me.txtChiaroScuro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboBoxSource
        '
        Me.ComboBoxSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSource.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxSource.FormattingEnabled = True
        Me.ComboBoxSource.Location = New System.Drawing.Point(3, 3)
        Me.ComboBoxSource.Name = "ComboBoxSource"
        Me.ComboBoxSource.Size = New System.Drawing.Size(154, 22)
        Me.ComboBoxSource.TabIndex = 0
        '
        'btnScanNuovo
        '
        Me.TableLayoutPanelScan.SetColumnSpan(Me.btnScanNuovo, 4)
        Me.btnScanNuovo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnScanNuovo.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnScanNuovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScanNuovo.Location = New System.Drawing.Point(1, 301)
        Me.btnScanNuovo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnScanNuovo.Name = "btnScanNuovo"
        Me.TableLayoutPanelScan.SetRowSpan(Me.btnScanNuovo, 2)
        Me.btnScanNuovo.Size = New System.Drawing.Size(207, 48)
        Me.btnScanNuovo.TabIndex = 0
        Me.btnScanNuovo.Text = "Acquisisci nuovo documento"
        Me.btnScanNuovo.UseVisualStyleBackColor = True
        '
        'btnFineDoc
        '
        Me.TableLayoutPanelScan.SetColumnSpan(Me.btnFineDoc, 4)
        Me.btnFineDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnFineDoc.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnFineDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFineDoc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFineDoc.Location = New System.Drawing.Point(1, 376)
        Me.btnFineDoc.Margin = New System.Windows.Forms.Padding(1)
        Me.btnFineDoc.Name = "btnFineDoc"
        Me.TableLayoutPanelScan.SetRowSpan(Me.btnFineDoc, 2)
        Me.btnFineDoc.Size = New System.Drawing.Size(207, 48)
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
        Me.LabelStato.Location = New System.Drawing.Point(3, 350)
        Me.LabelStato.Name = "LabelStato"
        Me.LabelStato.Size = New System.Drawing.Size(203, 25)
        Me.LabelStato.TabIndex = 5
        Me.LabelStato.Text = "LabelStato"
        Me.LabelStato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnEsci
        '
        Me.TableLayoutPanelScan.SetColumnSpan(Me.btnEsci, 4)
        Me.btnEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsci.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEsci.Location = New System.Drawing.Point(1, 486)
        Me.btnEsci.Margin = New System.Windows.Forms.Padding(1)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(207, 35)
        Me.btnEsci.TabIndex = 6
        Me.btnEsci.Text = "Button1"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'btnDesktop
        '
        Me.TableLayoutPanelScan.SetColumnSpan(Me.btnDesktop, 4)
        Me.btnDesktop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDesktop.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnDesktop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDesktop.Location = New System.Drawing.Point(1, 426)
        Me.btnDesktop.Margin = New System.Windows.Forms.Padding(1)
        Me.btnDesktop.Name = "btnDesktop"
        Me.btnDesktop.Size = New System.Drawing.Size(207, 28)
        Me.btnDesktop.TabIndex = 8
        Me.btnDesktop.Text = "Desktop locale"
        Me.btnDesktop.UseVisualStyleBackColor = True
        '
        'lbCliente
        '
        Me.lbCliente.AutoSize = True
        Me.lbCliente.BackColor = System.Drawing.Color.Lavender
        Me.lbCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCliente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbCliente.Location = New System.Drawing.Point(64, 0)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(303, 20)
        Me.lbCliente.TabIndex = 34
        Me.lbCliente.Text = "lbCliente"
        Me.lbCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 20)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Cliente"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Twain
        '
        Me.Twain.AnnotationFillColor = System.Drawing.Color.White
        Me.Twain.AnnotationPen = Nothing
        Me.Twain.AnnotationTextColor = System.Drawing.Color.Black
        Me.Twain.AnnotationTextFont = Nothing
        Me.Twain.BorderStyle = Dynamsoft.DotNet.TWAIN.Enums.DWTWndBorderStyle.SingleFlat
        Me.TableLayoutPanelMain.SetColumnSpan(Me.Twain, 2)
        Me.Twain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Twain.IfShowPrintUI = False
        Me.Twain.IfThrowException = False
        Me.Twain.Location = New System.Drawing.Point(3, 43)
        Me.Twain.LogLevel = CType(0, Short)
        Me.Twain.Name = "Twain"
        Me.Twain.PDFMarginBottom = CType(0UI, UInteger)
        Me.Twain.PDFMarginLeft = CType(0UI, UInteger)
        Me.Twain.PDFMarginRight = CType(0UI, UInteger)
        Me.Twain.PDFMarginTop = CType(0UI, UInteger)
        Me.Twain.PDFXConformance = CType(0UI, UInteger)
        Me.Twain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TableLayoutPanelMain.SetRowSpan(Me.Twain, 2)
        Me.Twain.Size = New System.Drawing.Size(364, 422)
        Me.Twain.TabIndex = 7
        '
        'Timer1
        '
        '
        'ScannerRDP
        '
        Me.AcceptButton = Me.btnScanNuovo
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 528)
        Me.Controls.Add(Me.TableLayoutPanelMain)
        Me.Name = "ScannerRDP"
        Me.Text = "Fotocopia"
        Me.TableLayoutPanelMain.ResumeLayout(False)
        Me.TableLayoutPanelMain.PerformLayout()
        Me.TableLayoutPanelScan.ResumeLayout(False)
        Me.GroupBoxScanner.ResumeLayout(False)
        Me.TableLayoutPanelScanner.ResumeLayout(False)
        Me.TableLayoutPanelScanner.PerformLayout()
        CType(Me.tbChiaroScuro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanelMain As System.Windows.Forms.TableLayoutPanel
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
    Friend WithEvents btnDesktop As System.Windows.Forms.Button
    Friend WithEvents lbCliente As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbPratica As System.Windows.Forms.Label
    Friend WithEvents lbInvia As System.Windows.Forms.ListBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ButtonCartellaUtente As Button
    Friend WithEvents ButtonSelezionaCartellaUtente As Button
    Friend WithEvents btnEsci As Button
End Class
