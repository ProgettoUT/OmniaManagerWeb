<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGrid
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGrid))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnRiesegui = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFileCsv = New System.Windows.Forms.ToolStripButton()
        Me.btnProprieta = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnComunica = New System.Windows.Forms.ToolStripButton()
        Me.btnStampaCopertinaA3 = New System.Windows.Forms.ToolStripButton()
        Me.btnGestioneBda = New System.Windows.Forms.ToolStripButton()
        Me.btnEsci = New System.Windows.Forms.ToolStripButton()
        Me.SeparatoreNota = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonNota = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAnagCliente = New System.Windows.Forms.ToolStripButton()
        Me.LabelCaption = New System.Windows.Forms.ToolStripLabel()
        Me.frmRicerca = New System.Windows.Forms.GroupBox()
        Me.lblGridMsg = New System.Windows.Forms.Label()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.grdResult = New System.Windows.Forms.DataGridView()
        Me.tlpGrid = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelStampa = New System.Windows.Forms.Panel()
        Me.ComboBoxEstrazioni = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonSelezioneEtStampa = New UtControls.UtFlatButton()
        Me.ToolStrip1.SuspendLayout()
        Me.frmRicerca.SuspendLayout()
        CType(Me.grdResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpGrid.SuspendLayout()
        Me.PanelStampa.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRiesegui, Me.ToolStripSeparator1, Me.btnFileCsv, Me.btnProprieta, Me.ToolStripSeparator2, Me.btnComunica, Me.btnStampaCopertinaA3, Me.btnGestioneBda, Me.btnEsci, Me.SeparatoreNota, Me.ButtonNota, Me.ToolStripSeparator4, Me.btnAnagCliente, Me.LabelCaption})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(994, 55)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnRiesegui
        '
        Me.btnRiesegui.AutoSize = False
        Me.btnRiesegui.Image = CType(resources.GetObject("btnRiesegui.Image"), System.Drawing.Image)
        Me.btnRiesegui.ImageTransparentColor = System.Drawing.Color.White
        Me.btnRiesegui.Name = "btnRiesegui"
        Me.btnRiesegui.Size = New System.Drawing.Size(60, 49)
        Me.btnRiesegui.Text = "esegui"
        Me.btnRiesegui.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'btnFileCsv
        '
        Me.btnFileCsv.AutoSize = False
        Me.btnFileCsv.Image = CType(resources.GetObject("btnFileCsv.Image"), System.Drawing.Image)
        Me.btnFileCsv.ImageTransparentColor = System.Drawing.Color.White
        Me.btnFileCsv.Name = "btnFileCsv"
        Me.btnFileCsv.Size = New System.Drawing.Size(60, 49)
        Me.btnFileCsv.Text = "file csv"
        Me.btnFileCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnProprieta
        '
        Me.btnProprieta.AutoSize = False
        Me.btnProprieta.Image = CType(resources.GetObject("btnProprieta.Image"), System.Drawing.Image)
        Me.btnProprieta.ImageTransparentColor = System.Drawing.Color.White
        Me.btnProprieta.Name = "btnProprieta"
        Me.btnProprieta.Size = New System.Drawing.Size(60, 49)
        Me.btnProprieta.Text = "proprietà"
        Me.btnProprieta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 55)
        '
        'btnComunica
        '
        Me.btnComunica.AutoSize = False
        Me.btnComunica.Image = CType(resources.GetObject("btnComunica.Image"), System.Drawing.Image)
        Me.btnComunica.ImageTransparentColor = System.Drawing.Color.White
        Me.btnComunica.Name = "btnComunica"
        Me.btnComunica.Size = New System.Drawing.Size(60, 49)
        Me.btnComunica.Text = "comunica"
        Me.btnComunica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnStampaCopertinaA3
        '
        Me.btnStampaCopertinaA3.Image = CType(resources.GetObject("btnStampaCopertinaA3.Image"), System.Drawing.Image)
        Me.btnStampaCopertinaA3.ImageTransparentColor = System.Drawing.Color.White
        Me.btnStampaCopertinaA3.Name = "btnStampaCopertinaA3"
        Me.btnStampaCopertinaA3.Size = New System.Drawing.Size(61, 52)
        Me.btnStampaCopertinaA3.Text = "copertina"
        Me.btnStampaCopertinaA3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGestioneBda
        '
        Me.btnGestioneBda.AutoSize = False
        Me.btnGestioneBda.ImageTransparentColor = System.Drawing.Color.White
        Me.btnGestioneBda.Name = "btnGestioneBda"
        Me.btnGestioneBda.Size = New System.Drawing.Size(60, 52)
        Me.btnGestioneBda.Text = "bda"
        Me.btnGestioneBda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnGestioneBda.ToolTipText = "Interrogazione bda"
        '
        'btnEsci
        '
        Me.btnEsci.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnEsci.AutoSize = False
        Me.btnEsci.Image = CType(resources.GetObject("btnEsci.Image"), System.Drawing.Image)
        Me.btnEsci.ImageTransparentColor = System.Drawing.Color.White
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(60, 49)
        Me.btnEsci.Text = "chiudi"
        Me.btnEsci.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnEsci.ToolTipText = "chiudi scheda estrattore dati"
        '
        'SeparatoreNota
        '
        Me.SeparatoreNota.Name = "SeparatoreNota"
        Me.SeparatoreNota.Size = New System.Drawing.Size(6, 55)
        '
        'ButtonNota
        '
        Me.ButtonNota.Image = CType(resources.GetObject("ButtonNota.Image"), System.Drawing.Image)
        Me.ButtonNota.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNota.Name = "ButtonNota"
        Me.ButtonNota.Size = New System.Drawing.Size(37, 52)
        Me.ButtonNota.Text = "Nota"
        Me.ButtonNota.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 55)
        '
        'btnAnagCliente
        '
        Me.btnAnagCliente.AutoSize = False
        Me.btnAnagCliente.ImageTransparentColor = System.Drawing.Color.White
        Me.btnAnagCliente.Name = "btnAnagCliente"
        Me.btnAnagCliente.Size = New System.Drawing.Size(60, 52)
        Me.btnAnagCliente.Text = "cliente"
        Me.btnAnagCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'LabelCaption
        '
        Me.LabelCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LabelCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabelCaption.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelCaption.Name = "LabelCaption"
        Me.LabelCaption.Padding = New System.Windows.Forms.Padding(20)
        Me.LabelCaption.Size = New System.Drawing.Size(136, 55)
        Me.LabelCaption.Text = "Nome estrazione"
        '
        'frmRicerca
        '
        Me.frmRicerca.Controls.Add(Me.lblGridMsg)
        Me.frmRicerca.Controls.Add(Me.lblHelp)
        Me.frmRicerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmRicerca.Location = New System.Drawing.Point(5, 101)
        Me.frmRicerca.Margin = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.frmRicerca.Name = "frmRicerca"
        Me.frmRicerca.Padding = New System.Windows.Forms.Padding(0)
        Me.frmRicerca.Size = New System.Drawing.Size(984, 22)
        Me.frmRicerca.TabIndex = 3
        Me.frmRicerca.TabStop = False
        Me.frmRicerca.Visible = False
        '
        'lblGridMsg
        '
        Me.lblGridMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGridMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGridMsg.ForeColor = System.Drawing.Color.Blue
        Me.lblGridMsg.Location = New System.Drawing.Point(459, 4)
        Me.lblGridMsg.Name = "lblGridMsg"
        Me.lblGridMsg.Size = New System.Drawing.Size(520, 14)
        Me.lblGridMsg.TabIndex = 2
        Me.lblGridMsg.Text = "lblGridMsg"
        Me.lblGridMsg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHelp
        '
        Me.lblHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblHelp.AutoSize = True
        Me.lblHelp.BackColor = System.Drawing.Color.Transparent
        Me.lblHelp.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelp.ForeColor = System.Drawing.Color.Blue
        Me.lblHelp.Location = New System.Drawing.Point(7, 4)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(307, 14)
        Me.lblHelp.TabIndex = 1
        Me.lblHelp.Text = "Per eseguire l'estrazione premi il pulsante ESEGUI"
        '
        'grdResult
        '
        Me.grdResult.AllowUserToAddRows = False
        Me.grdResult.AllowUserToDeleteRows = False
        Me.grdResult.AllowUserToOrderColumns = True
        Me.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdResult.Location = New System.Drawing.Point(3, 131)
        Me.grdResult.MultiSelect = False
        Me.grdResult.Name = "grdResult"
        Me.grdResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdResult.Size = New System.Drawing.Size(988, 311)
        Me.grdResult.TabIndex = 4
        '
        'tlpGrid
        '
        Me.tlpGrid.ColumnCount = 1
        Me.tlpGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpGrid.Controls.Add(Me.ToolStrip1, 0, 0)
        Me.tlpGrid.Controls.Add(Me.grdResult, 0, 3)
        Me.tlpGrid.Controls.Add(Me.frmRicerca, 0, 2)
        Me.tlpGrid.Controls.Add(Me.PanelStampa, 0, 1)
        Me.tlpGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpGrid.Location = New System.Drawing.Point(0, 0)
        Me.tlpGrid.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpGrid.Name = "tlpGrid"
        Me.tlpGrid.RowCount = 4
        Me.tlpGrid.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGrid.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGrid.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGrid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpGrid.Size = New System.Drawing.Size(994, 445)
        Me.tlpGrid.TabIndex = 6
        '
        'PanelStampa
        '
        Me.PanelStampa.Controls.Add(Me.ButtonSelezioneEtStampa)
        Me.PanelStampa.Controls.Add(Me.ComboBoxEstrazioni)
        Me.PanelStampa.Controls.Add(Me.Label1)
        Me.PanelStampa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelStampa.Location = New System.Drawing.Point(3, 58)
        Me.PanelStampa.Name = "PanelStampa"
        Me.PanelStampa.Size = New System.Drawing.Size(988, 40)
        Me.PanelStampa.TabIndex = 5
        '
        'ComboBoxEstrazioni
        '
        Me.ComboBoxEstrazioni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEstrazioni.FormattingEnabled = True
        Me.ComboBoxEstrazioni.Location = New System.Drawing.Point(145, 10)
        Me.ComboBoxEstrazioni.Name = "ComboBoxEstrazioni"
        Me.ComboBoxEstrazioni.Size = New System.Drawing.Size(278, 22)
        Me.ComboBoxEstrazioni.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Estrazione da eseguire"
        '
        'ButtonSelezioneEtStampa
        '
        Me.ButtonSelezioneEtStampa.BackColor = System.Drawing.Color.Moccasin
        Me.ButtonSelezioneEtStampa.DefaultBorderSize = 1
        Me.ButtonSelezioneEtStampa.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.ButtonSelezioneEtStampa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ButtonSelezioneEtStampa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ButtonSelezioneEtStampa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSelezioneEtStampa.Location = New System.Drawing.Point(470, 0)
        Me.ButtonSelezioneEtStampa.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonSelezioneEtStampa.Name = "ButtonSelezioneEtStampa"
        Me.ButtonSelezioneEtStampa.Size = New System.Drawing.Size(264, 40)
        Me.ButtonSelezioneEtStampa.TabIndex = 4
        Me.ButtonSelezioneEtStampa.Text = "Seleziona modello e Stampa"
        Me.ButtonSelezioneEtStampa.UseVisualStyleBackColor = False
        '
        'frmGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 445)
        Me.Controls.Add(Me.tlpGrid)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGrid"
        Me.Text = "Risultato"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.frmRicerca.ResumeLayout(False)
        Me.frmRicerca.PerformLayout()
        CType(Me.grdResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpGrid.ResumeLayout(False)
        Me.tlpGrid.PerformLayout()
        Me.PanelStampa.ResumeLayout(False)
        Me.PanelStampa.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents frmRicerca As System.Windows.Forms.GroupBox
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents grdResult As System.Windows.Forms.DataGridView
    Friend WithEvents lblGridMsg As System.Windows.Forms.Label
    Friend WithEvents btnRiesegui As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnFileCsv As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnProprieta As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEsci As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlpGrid As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnComunica As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnStampaCopertinaA3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelStampa As System.Windows.Forms.Panel
    Friend WithEvents ComboBoxEstrazioni As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonSelezioneEtStampa As UtControls.UtFlatButton
    Friend WithEvents LabelCaption As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SeparatoreNota As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAnagCliente As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGestioneBda As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonNota As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As Windows.Forms.ToolStripSeparator
End Class
