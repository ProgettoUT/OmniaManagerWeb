Namespace P01261
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class assicuratoFE
        Inherits System.Windows.Forms.UserControl

        'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.cmdRemove = New System.Windows.Forms.Button()
            Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtEta = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtNominativo = New System.Windows.Forms.TextBox()
            Me.cmbCriterioLiquidazioneIPM = New System.Windows.Forms.ComboBox()
            Me.lblMalattiaBase = New System.Windows.Forms.Label()
            Me.chkMalattiaBase = New System.Windows.Forms.CheckBox()
            Me.desMalattiaIPM = New System.Windows.Forms.Label()
            Me.lblMalattiaIPM = New System.Windows.Forms.Label()
            Me.chkMalattiaIPM = New System.Windows.Forms.CheckBox()
            Me.cmbMalattiaIPMmassimale = New System.Windows.Forms.ComboBox()
            Me.desMalattiaVisiteTrattamenti = New System.Windows.Forms.Label()
            Me.lblMalattiaVisiteTrattamenti = New System.Windows.Forms.Label()
            Me.chkMalattiaVisiteTrattamenti = New System.Windows.Forms.CheckBox()
            Me.txtMalattiaVisiteTrattamentimassimale = New System.Windows.Forms.TextBox()
            Me.desMalattiaConvalescenza = New System.Windows.Forms.Label()
            Me.lblMalattiaConvalescenza = New System.Windows.Forms.Label()
            Me.chkMalattiaConvalescenza = New System.Windows.Forms.CheckBox()
            Me.txtMalattiaConvalescenzamassimale = New System.Windows.Forms.TextBox()
            Me.desMalattiaPrevenzioneSindromeMetabolica = New System.Windows.Forms.Label()
            Me.lblMalattiaPrevenzioneSindromeMetabolica = New System.Windows.Forms.Label()
            Me.chkMalattiaPrevenzioneSindromeMetabolica = New System.Windows.Forms.CheckBox()
            Me.desMalattiaSecondOpinion = New System.Windows.Forms.Label()
            Me.lblMalattiaSecondOpinion = New System.Windows.Forms.Label()
            Me.chkMalattiaSecondOpinion = New System.Windows.Forms.CheckBox()
            Me.lblAssistenzaBase = New System.Windows.Forms.Label()
            Me.chkAssistenzaBase = New System.Windows.Forms.CheckBox()
            Me.lblA1 = New System.Windows.Forms.Label()
            Me.lblB1 = New System.Windows.Forms.Label()
            Me.lblC1 = New System.Windows.Forms.Label()
            Me.lblD1 = New System.Windows.Forms.Label()
            Me.GroupBox1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.FlowLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
            Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
            Me.GroupBox1.Margin = New System.Windows.Forms.Padding(0)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
            Me.GroupBox1.Size = New System.Drawing.Size(1026, 575)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 5
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.cmdRemove, 4, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cmbCriterioLiquidazioneIPM, 2, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblMalattiaBase, 4, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.chkMalattiaBase, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.desMalattiaIPM, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblMalattiaIPM, 4, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.chkMalattiaIPM, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.cmbMalattiaIPMmassimale, 2, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.desMalattiaVisiteTrattamenti, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.lblMalattiaVisiteTrattamenti, 4, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.chkMalattiaVisiteTrattamenti, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.txtMalattiaVisiteTrattamentimassimale, 2, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.desMalattiaConvalescenza, 1, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.lblMalattiaConvalescenza, 4, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.chkMalattiaConvalescenza, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.txtMalattiaConvalescenzamassimale, 2, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.desMalattiaPrevenzioneSindromeMetabolica, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.lblMalattiaPrevenzioneSindromeMetabolica, 4, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.chkMalattiaPrevenzioneSindromeMetabolica, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.desMalattiaSecondOpinion, 1, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.lblMalattiaSecondOpinion, 4, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.chkMalattiaSecondOpinion, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.lblAssistenzaBase, 4, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.chkAssistenzaBase, 0, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.lblA1, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblB1, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblC1, 4, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblD1, 0, 1)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 13)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 11
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(1020, 559)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'cmdRemove
            '
            Me.cmdRemove.BackColor = System.Drawing.Color.Transparent
            Me.cmdRemove.Cursor = System.Windows.Forms.Cursors.Hand
            Me.cmdRemove.Dock = System.Windows.Forms.DockStyle.Right
            Me.cmdRemove.FlatAppearance.BorderColor = System.Drawing.Color.Black
            Me.cmdRemove.FlatAppearance.BorderSize = 0
            Me.cmdRemove.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
            Me.cmdRemove.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
            Me.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cmdRemove.Image = Global.UniQuota.My.Resources.Resources.Remove
            Me.cmdRemove.Location = New System.Drawing.Point(967, 0)
            Me.cmdRemove.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
            Me.cmdRemove.Name = "cmdRemove"
            Me.cmdRemove.Size = New System.Drawing.Size(50, 30)
            Me.cmdRemove.TabIndex = 76
            Me.cmdRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            Me.cmdRemove.UseVisualStyleBackColor = False
            '
            'FlowLayoutPanel1
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel1, 4)
            Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
            Me.FlowLayoutPanel1.Controls.Add(Me.txtEta)
            Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
            Me.FlowLayoutPanel1.Controls.Add(Me.txtNominativo)
            Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(915, 30)
            Me.FlowLayoutPanel1.TabIndex = 75
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.Label2.Location = New System.Drawing.Point(3, 0)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(23, 26)
            Me.Label2.TabIndex = 6
            Me.Label2.Tag = "102"
            Me.Label2.Text = "Età"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtEta
            '
            Me.txtEta.Location = New System.Drawing.Point(32, 3)
            Me.txtEta.Name = "txtEta"
            Me.txtEta.Size = New System.Drawing.Size(66, 20)
            Me.txtEta.TabIndex = 1
            Me.txtEta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.Label1.Location = New System.Drawing.Point(104, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(111, 26)
            Me.Label1.TabIndex = 5
            Me.Label1.Tag = "102"
            Me.Label1.Text = "Nominativo assicurato"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtNominativo
            '
            Me.txtNominativo.Location = New System.Drawing.Point(221, 3)
            Me.txtNominativo.Name = "txtNominativo"
            Me.txtNominativo.Size = New System.Drawing.Size(471, 20)
            Me.txtNominativo.TabIndex = 0
            '
            'cmbCriterioLiquidazioneIPM
            '
            Me.cmbCriterioLiquidazioneIPM.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbCriterioLiquidazioneIPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCriterioLiquidazioneIPM.FormattingEnabled = True
            Me.cmbCriterioLiquidazioneIPM.Location = New System.Drawing.Point(402, 73)
            Me.cmbCriterioLiquidazioneIPM.Name = "cmbCriterioLiquidazioneIPM"
            Me.cmbCriterioLiquidazioneIPM.Size = New System.Drawing.Size(252, 21)
            Me.cmbCriterioLiquidazioneIPM.TabIndex = 0
            '
            'lblMalattiaBase
            '
            Me.lblMalattiaBase.AutoSize = True
            Me.lblMalattiaBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblMalattiaBase.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMalattiaBase.Location = New System.Drawing.Point(918, 70)
            Me.lblMalattiaBase.Name = "lblMalattiaBase"
            Me.lblMalattiaBase.Size = New System.Drawing.Size(99, 25)
            Me.lblMalattiaBase.TabIndex = 3
            Me.lblMalattiaBase.Text = "0,00"
            Me.lblMalattiaBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkMalattiaBase
            '
            Me.chkMalattiaBase.AutoSize = True
            Me.TableLayoutPanel1.SetColumnSpan(Me.chkMalattiaBase, 2)
            Me.chkMalattiaBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkMalattiaBase.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMalattiaBase.Location = New System.Drawing.Point(0, 70)
            Me.chkMalattiaBase.Margin = New System.Windows.Forms.Padding(0)
            Me.chkMalattiaBase.Name = "chkMalattiaBase"
            Me.chkMalattiaBase.Size = New System.Drawing.Size(399, 25)
            Me.chkMalattiaBase.TabIndex = 4
            Me.chkMalattiaBase.Text = "MALATTIA E INFORTUNI"
            Me.chkMalattiaBase.UseVisualStyleBackColor = True
            '
            'desMalattiaIPM
            '
            Me.desMalattiaIPM.AutoSize = True
            Me.desMalattiaIPM.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desMalattiaIPM.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desMalattiaIPM.Location = New System.Drawing.Point(58, 95)
            Me.desMalattiaIPM.Name = "desMalattiaIPM"
            Me.desMalattiaIPM.Size = New System.Drawing.Size(338, 25)
            Me.desMalattiaIPM.TabIndex = 5
            Me.desMalattiaIPM.Tag = "102"
            Me.desMalattiaIPM.Text = "Invalidità Permanente da Malattia"
            Me.desMalattiaIPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMalattiaIPM
            '
            Me.lblMalattiaIPM.AutoSize = True
            Me.lblMalattiaIPM.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblMalattiaIPM.Location = New System.Drawing.Point(918, 95)
            Me.lblMalattiaIPM.Name = "lblMalattiaIPM"
            Me.lblMalattiaIPM.Size = New System.Drawing.Size(99, 25)
            Me.lblMalattiaIPM.TabIndex = 6
            Me.lblMalattiaIPM.Text = "0,00"
            Me.lblMalattiaIPM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkMalattiaIPM
            '
            Me.chkMalattiaIPM.AutoSize = True
            Me.chkMalattiaIPM.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkMalattiaIPM.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkMalattiaIPM.Location = New System.Drawing.Point(0, 95)
            Me.chkMalattiaIPM.Margin = New System.Windows.Forms.Padding(0)
            Me.chkMalattiaIPM.Name = "chkMalattiaIPM"
            Me.chkMalattiaIPM.Size = New System.Drawing.Size(55, 25)
            Me.chkMalattiaIPM.TabIndex = 7
            Me.chkMalattiaIPM.UseVisualStyleBackColor = True
            '
            'cmbMalattiaIPMmassimale
            '
            Me.cmbMalattiaIPMmassimale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbMalattiaIPMmassimale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbMalattiaIPMmassimale.FormattingEnabled = True
            Me.cmbMalattiaIPMmassimale.Location = New System.Drawing.Point(402, 98)
            Me.cmbMalattiaIPMmassimale.Name = "cmbMalattiaIPMmassimale"
            Me.cmbMalattiaIPMmassimale.Size = New System.Drawing.Size(252, 21)
            Me.cmbMalattiaIPMmassimale.TabIndex = 8
            '
            'desMalattiaVisiteTrattamenti
            '
            Me.desMalattiaVisiteTrattamenti.AutoSize = True
            Me.desMalattiaVisiteTrattamenti.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desMalattiaVisiteTrattamenti.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desMalattiaVisiteTrattamenti.Location = New System.Drawing.Point(58, 120)
            Me.desMalattiaVisiteTrattamenti.Name = "desMalattiaVisiteTrattamenti"
            Me.desMalattiaVisiteTrattamenti.Size = New System.Drawing.Size(338, 25)
            Me.desMalattiaVisiteTrattamenti.TabIndex = 9
            Me.desMalattiaVisiteTrattamenti.Tag = "103"
            Me.desMalattiaVisiteTrattamenti.Text = "Visite Specialistiche e Trattamenti"
            Me.desMalattiaVisiteTrattamenti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMalattiaVisiteTrattamenti
            '
            Me.lblMalattiaVisiteTrattamenti.AutoSize = True
            Me.lblMalattiaVisiteTrattamenti.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblMalattiaVisiteTrattamenti.Location = New System.Drawing.Point(918, 120)
            Me.lblMalattiaVisiteTrattamenti.Name = "lblMalattiaVisiteTrattamenti"
            Me.lblMalattiaVisiteTrattamenti.Size = New System.Drawing.Size(99, 25)
            Me.lblMalattiaVisiteTrattamenti.TabIndex = 10
            Me.lblMalattiaVisiteTrattamenti.Text = "0,00"
            Me.lblMalattiaVisiteTrattamenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkMalattiaVisiteTrattamenti
            '
            Me.chkMalattiaVisiteTrattamenti.AutoSize = True
            Me.chkMalattiaVisiteTrattamenti.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkMalattiaVisiteTrattamenti.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkMalattiaVisiteTrattamenti.Location = New System.Drawing.Point(0, 120)
            Me.chkMalattiaVisiteTrattamenti.Margin = New System.Windows.Forms.Padding(0)
            Me.chkMalattiaVisiteTrattamenti.Name = "chkMalattiaVisiteTrattamenti"
            Me.chkMalattiaVisiteTrattamenti.Size = New System.Drawing.Size(55, 25)
            Me.chkMalattiaVisiteTrattamenti.TabIndex = 11
            Me.chkMalattiaVisiteTrattamenti.UseVisualStyleBackColor = True
            '
            'txtMalattiaVisiteTrattamentimassimale
            '
            Me.txtMalattiaVisiteTrattamentimassimale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtMalattiaVisiteTrattamentimassimale.Enabled = False
            Me.txtMalattiaVisiteTrattamentimassimale.Location = New System.Drawing.Point(402, 123)
            Me.txtMalattiaVisiteTrattamentimassimale.Name = "txtMalattiaVisiteTrattamentimassimale"
            Me.txtMalattiaVisiteTrattamentimassimale.Size = New System.Drawing.Size(252, 20)
            Me.txtMalattiaVisiteTrattamentimassimale.TabIndex = 12
            '
            'desMalattiaConvalescenza
            '
            Me.desMalattiaConvalescenza.AutoSize = True
            Me.desMalattiaConvalescenza.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desMalattiaConvalescenza.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desMalattiaConvalescenza.Location = New System.Drawing.Point(58, 145)
            Me.desMalattiaConvalescenza.Name = "desMalattiaConvalescenza"
            Me.desMalattiaConvalescenza.Size = New System.Drawing.Size(338, 25)
            Me.desMalattiaConvalescenza.TabIndex = 13
            Me.desMalattiaConvalescenza.Tag = "104"
            Me.desMalattiaConvalescenza.Text = "Indennita' giornaliera per convalescenza"
            Me.desMalattiaConvalescenza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMalattiaConvalescenza
            '
            Me.lblMalattiaConvalescenza.AutoSize = True
            Me.lblMalattiaConvalescenza.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblMalattiaConvalescenza.Location = New System.Drawing.Point(918, 145)
            Me.lblMalattiaConvalescenza.Name = "lblMalattiaConvalescenza"
            Me.lblMalattiaConvalescenza.Size = New System.Drawing.Size(99, 25)
            Me.lblMalattiaConvalescenza.TabIndex = 14
            Me.lblMalattiaConvalescenza.Text = "0,00"
            Me.lblMalattiaConvalescenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkMalattiaConvalescenza
            '
            Me.chkMalattiaConvalescenza.AutoSize = True
            Me.chkMalattiaConvalescenza.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkMalattiaConvalescenza.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkMalattiaConvalescenza.Location = New System.Drawing.Point(0, 145)
            Me.chkMalattiaConvalescenza.Margin = New System.Windows.Forms.Padding(0)
            Me.chkMalattiaConvalescenza.Name = "chkMalattiaConvalescenza"
            Me.chkMalattiaConvalescenza.Size = New System.Drawing.Size(55, 25)
            Me.chkMalattiaConvalescenza.TabIndex = 15
            Me.chkMalattiaConvalescenza.UseVisualStyleBackColor = True
            '
            'txtMalattiaConvalescenzamassimale
            '
            Me.txtMalattiaConvalescenzamassimale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtMalattiaConvalescenzamassimale.Enabled = False
            Me.txtMalattiaConvalescenzamassimale.Location = New System.Drawing.Point(402, 148)
            Me.txtMalattiaConvalescenzamassimale.Name = "txtMalattiaConvalescenzamassimale"
            Me.txtMalattiaConvalescenzamassimale.Size = New System.Drawing.Size(252, 20)
            Me.txtMalattiaConvalescenzamassimale.TabIndex = 16
            '
            'desMalattiaPrevenzioneSindromeMetabolica
            '
            Me.desMalattiaPrevenzioneSindromeMetabolica.AutoSize = True
            Me.desMalattiaPrevenzioneSindromeMetabolica.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desMalattiaPrevenzioneSindromeMetabolica.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desMalattiaPrevenzioneSindromeMetabolica.Location = New System.Drawing.Point(58, 170)
            Me.desMalattiaPrevenzioneSindromeMetabolica.Name = "desMalattiaPrevenzioneSindromeMetabolica"
            Me.desMalattiaPrevenzioneSindromeMetabolica.Size = New System.Drawing.Size(338, 25)
            Me.desMalattiaPrevenzioneSindromeMetabolica.TabIndex = 17
            Me.desMalattiaPrevenzioneSindromeMetabolica.Tag = "105"
            Me.desMalattiaPrevenzioneSindromeMetabolica.Text = "Prevenzione Sindrome Metabolica"
            Me.desMalattiaPrevenzioneSindromeMetabolica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMalattiaPrevenzioneSindromeMetabolica
            '
            Me.lblMalattiaPrevenzioneSindromeMetabolica.AutoSize = True
            Me.lblMalattiaPrevenzioneSindromeMetabolica.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblMalattiaPrevenzioneSindromeMetabolica.Location = New System.Drawing.Point(918, 170)
            Me.lblMalattiaPrevenzioneSindromeMetabolica.Name = "lblMalattiaPrevenzioneSindromeMetabolica"
            Me.lblMalattiaPrevenzioneSindromeMetabolica.Size = New System.Drawing.Size(99, 25)
            Me.lblMalattiaPrevenzioneSindromeMetabolica.TabIndex = 18
            Me.lblMalattiaPrevenzioneSindromeMetabolica.Text = "0,00"
            Me.lblMalattiaPrevenzioneSindromeMetabolica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkMalattiaPrevenzioneSindromeMetabolica
            '
            Me.chkMalattiaPrevenzioneSindromeMetabolica.AutoSize = True
            Me.chkMalattiaPrevenzioneSindromeMetabolica.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkMalattiaPrevenzioneSindromeMetabolica.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkMalattiaPrevenzioneSindromeMetabolica.Location = New System.Drawing.Point(0, 170)
            Me.chkMalattiaPrevenzioneSindromeMetabolica.Margin = New System.Windows.Forms.Padding(0)
            Me.chkMalattiaPrevenzioneSindromeMetabolica.Name = "chkMalattiaPrevenzioneSindromeMetabolica"
            Me.chkMalattiaPrevenzioneSindromeMetabolica.Size = New System.Drawing.Size(55, 25)
            Me.chkMalattiaPrevenzioneSindromeMetabolica.TabIndex = 19
            Me.chkMalattiaPrevenzioneSindromeMetabolica.UseVisualStyleBackColor = True
            '
            'desMalattiaSecondOpinion
            '
            Me.desMalattiaSecondOpinion.AutoSize = True
            Me.desMalattiaSecondOpinion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desMalattiaSecondOpinion.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desMalattiaSecondOpinion.Location = New System.Drawing.Point(58, 195)
            Me.desMalattiaSecondOpinion.Name = "desMalattiaSecondOpinion"
            Me.desMalattiaSecondOpinion.Size = New System.Drawing.Size(338, 25)
            Me.desMalattiaSecondOpinion.TabIndex = 20
            Me.desMalattiaSecondOpinion.Tag = "106"
            Me.desMalattiaSecondOpinion.Text = "Second Opinion"
            Me.desMalattiaSecondOpinion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMalattiaSecondOpinion
            '
            Me.lblMalattiaSecondOpinion.AutoSize = True
            Me.lblMalattiaSecondOpinion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblMalattiaSecondOpinion.Location = New System.Drawing.Point(918, 195)
            Me.lblMalattiaSecondOpinion.Name = "lblMalattiaSecondOpinion"
            Me.lblMalattiaSecondOpinion.Size = New System.Drawing.Size(99, 25)
            Me.lblMalattiaSecondOpinion.TabIndex = 21
            Me.lblMalattiaSecondOpinion.Text = "0,00"
            Me.lblMalattiaSecondOpinion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkMalattiaSecondOpinion
            '
            Me.chkMalattiaSecondOpinion.AutoSize = True
            Me.chkMalattiaSecondOpinion.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkMalattiaSecondOpinion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkMalattiaSecondOpinion.Location = New System.Drawing.Point(0, 195)
            Me.chkMalattiaSecondOpinion.Margin = New System.Windows.Forms.Padding(0)
            Me.chkMalattiaSecondOpinion.Name = "chkMalattiaSecondOpinion"
            Me.chkMalattiaSecondOpinion.Size = New System.Drawing.Size(55, 25)
            Me.chkMalattiaSecondOpinion.TabIndex = 22
            Me.chkMalattiaSecondOpinion.UseVisualStyleBackColor = True
            '
            'lblAssistenzaBase
            '
            Me.lblAssistenzaBase.AutoSize = True
            Me.lblAssistenzaBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblAssistenzaBase.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAssistenzaBase.Location = New System.Drawing.Point(918, 245)
            Me.lblAssistenzaBase.Name = "lblAssistenzaBase"
            Me.lblAssistenzaBase.Size = New System.Drawing.Size(99, 25)
            Me.lblAssistenzaBase.TabIndex = 23
            Me.lblAssistenzaBase.Text = "0,00"
            Me.lblAssistenzaBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkAssistenzaBase
            '
            Me.chkAssistenzaBase.AutoSize = True
            Me.TableLayoutPanel1.SetColumnSpan(Me.chkAssistenzaBase, 2)
            Me.chkAssistenzaBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkAssistenzaBase.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkAssistenzaBase.Location = New System.Drawing.Point(0, 245)
            Me.chkAssistenzaBase.Margin = New System.Windows.Forms.Padding(0)
            Me.chkAssistenzaBase.Name = "chkAssistenzaBase"
            Me.chkAssistenzaBase.Size = New System.Drawing.Size(399, 25)
            Me.chkAssistenzaBase.TabIndex = 24
            Me.chkAssistenzaBase.Text = "ASSISTENZA"
            Me.chkAssistenzaBase.UseVisualStyleBackColor = True
            '
            'lblA1
            '
            Me.lblA1.AutoSize = True
            Me.lblA1.BackColor = System.Drawing.Color.Khaki
            Me.lblA1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblA1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblA1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblA1.Location = New System.Drawing.Point(58, 30)
            Me.lblA1.Name = "lblA1"
            Me.lblA1.Size = New System.Drawing.Size(338, 40)
            Me.lblA1.TabIndex = 25
            Me.lblA1.Text = "Partita / Garanzia"
            Me.lblA1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblB1
            '
            Me.lblB1.AutoSize = True
            Me.lblB1.BackColor = System.Drawing.Color.Khaki
            Me.lblB1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblB1, 2)
            Me.lblB1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblB1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblB1.Location = New System.Drawing.Point(402, 30)
            Me.lblB1.Name = "lblB1"
            Me.lblB1.Size = New System.Drawing.Size(510, 40)
            Me.lblB1.TabIndex = 26
            Me.lblB1.Text = "Parametri/Condizioni"
            Me.lblB1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblC1
            '
            Me.lblC1.AutoSize = True
            Me.lblC1.BackColor = System.Drawing.Color.Khaki
            Me.lblC1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblC1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblC1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblC1.Location = New System.Drawing.Point(918, 30)
            Me.lblC1.Name = "lblC1"
            Me.lblC1.Size = New System.Drawing.Size(99, 40)
            Me.lblC1.TabIndex = 27
            Me.lblC1.Text = "Premio"
            Me.lblC1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblD1
            '
            Me.lblD1.AutoSize = True
            Me.lblD1.BackColor = System.Drawing.Color.Khaki
            Me.lblD1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblD1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblD1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblD1.Location = New System.Drawing.Point(3, 30)
            Me.lblD1.Name = "lblD1"
            Me.lblD1.Size = New System.Drawing.Size(49, 40)
            Me.lblD1.TabIndex = 28
            Me.lblD1.Text = "Scelto"
            Me.lblD1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'assicuratoFE
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.GroupBox1)
            Me.Name = "assicuratoFE"
            Me.Size = New System.Drawing.Size(1026, 575)
            Me.GroupBox1.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.FlowLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents cmbCriterioLiquidazioneIPM As System.Windows.Forms.ComboBox
        Friend WithEvents lblA1 As System.Windows.Forms.Label
        Friend WithEvents lblB1 As System.Windows.Forms.Label
        Friend WithEvents lblC1 As System.Windows.Forms.Label
        Friend WithEvents lblD1 As System.Windows.Forms.Label
        Friend WithEvents lblMalattiaBase As System.Windows.Forms.Label
        Friend WithEvents chkMalattiaBase As System.Windows.Forms.CheckBox
        Friend WithEvents desMalattiaIPM As System.Windows.Forms.Label
        Friend WithEvents lblMalattiaIPM As System.Windows.Forms.Label
        Friend WithEvents chkMalattiaIPM As System.Windows.Forms.CheckBox
        Friend WithEvents desMalattiaVisiteTrattamenti As System.Windows.Forms.Label
        Friend WithEvents lblMalattiaVisiteTrattamenti As System.Windows.Forms.Label
        Friend WithEvents chkMalattiaVisiteTrattamenti As System.Windows.Forms.CheckBox
        Friend WithEvents desMalattiaConvalescenza As System.Windows.Forms.Label
        Friend WithEvents lblMalattiaConvalescenza As System.Windows.Forms.Label
        Friend WithEvents chkMalattiaConvalescenza As System.Windows.Forms.CheckBox
        Friend WithEvents desMalattiaPrevenzioneSindromeMetabolica As System.Windows.Forms.Label
        Friend WithEvents lblMalattiaPrevenzioneSindromeMetabolica As System.Windows.Forms.Label
        Friend WithEvents chkMalattiaPrevenzioneSindromeMetabolica As System.Windows.Forms.CheckBox
        Friend WithEvents desMalattiaSecondOpinion As System.Windows.Forms.Label
        Friend WithEvents lblMalattiaSecondOpinion As System.Windows.Forms.Label
        Friend WithEvents chkMalattiaSecondOpinion As System.Windows.Forms.CheckBox
        Friend WithEvents lblAssistenzaBase As System.Windows.Forms.Label
        Friend WithEvents chkAssistenzaBase As System.Windows.Forms.CheckBox
        Friend WithEvents cmbMalattiaIPMmassimale As System.Windows.Forms.ComboBox
        Friend WithEvents txtMalattiaVisiteTrattamentimassimale As System.Windows.Forms.TextBox
        Friend WithEvents txtMalattiaConvalescenzamassimale As System.Windows.Forms.TextBox
        Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtEta As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtNominativo As System.Windows.Forms.TextBox
        Friend WithEvents cmdRemove As System.Windows.Forms.Button
    End Class

End Namespace
