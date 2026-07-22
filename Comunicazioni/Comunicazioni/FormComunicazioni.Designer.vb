<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormComunicazioni
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormComunicazioni))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lbDataDoc = New System.Windows.Forms.Label()
        Me.dgvIndice = New System.Windows.Forms.DataGridView()
        Me.wbDoc = New System.Windows.Forms.WebBrowser()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvIndice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbDataDoc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvIndice)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.wbDoc)
        Me.SplitContainer1.Size = New System.Drawing.Size(895, 615)
        Me.SplitContainer1.SplitterDistance = 224
        Me.SplitContainer1.TabIndex = 0
        '
        'lbDataDoc
        '
        Me.lbDataDoc.BackColor = System.Drawing.Color.White
        Me.lbDataDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbDataDoc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbDataDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbDataDoc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDataDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbDataDoc.Location = New System.Drawing.Point(0, 592)
        Me.lbDataDoc.Name = "lbDataDoc"
        Me.lbDataDoc.Size = New System.Drawing.Size(224, 23)
        Me.lbDataDoc.TabIndex = 1
        Me.lbDataDoc.Text = "Label1"
        Me.lbDataDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvIndice
        '
        Me.dgvIndice.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvIndice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIndice.Location = New System.Drawing.Point(0, 0)
        Me.dgvIndice.Name = "dgvIndice"
        Me.dgvIndice.ReadOnly = True
        Me.dgvIndice.Size = New System.Drawing.Size(224, 589)
        Me.dgvIndice.TabIndex = 0
        '
        'wbDoc
        '
        Me.wbDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbDoc.Location = New System.Drawing.Point(0, 0)
        Me.wbDoc.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbDoc.Name = "wbDoc"
        Me.wbDoc.Size = New System.Drawing.Size(667, 615)
        Me.wbDoc.TabIndex = 0
        '
        'tsMenu
        '
        Me.tsMenu.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tsMenu.Location = New System.Drawing.Point(0, 627)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(895, 25)
        Me.tsMenu.TabIndex = 3
        Me.tsMenu.Text = "ToolStrip1"
        '
        'FormComunicazioni
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 652)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormComunicazioni"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvIndice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvIndice As System.Windows.Forms.DataGridView
    Friend WithEvents wbDoc As System.Windows.Forms.WebBrowser
    Friend WithEvents lbDataDoc As System.Windows.Forms.Label
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip

End Class
