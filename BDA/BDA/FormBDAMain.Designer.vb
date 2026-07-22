<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBDAMain
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
        Me.dgvBDA = New System.Windows.Forms.DataGridView()
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.TabPageBDA = New System.Windows.Forms.TabPage()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.TabPageDoc = New System.Windows.Forms.TabPage()
        Me.btnIndice = New System.Windows.Forms.Button()
        Me.wbDocumentazione = New System.Windows.Forms.WebBrowser()
        CType(Me.dgvBDA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlMain.SuspendLayout()
        Me.TabPageBDA.SuspendLayout()
        Me.TabPageDoc.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvBDA
        '
        Me.dgvBDA.AllowUserToAddRows = False
        Me.dgvBDA.AllowUserToDeleteRows = False
        Me.dgvBDA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBDA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBDA.Location = New System.Drawing.Point(0, 35)
        Me.dgvBDA.Name = "dgvBDA"
        Me.dgvBDA.ReadOnly = True
        Me.dgvBDA.Size = New System.Drawing.Size(596, 284)
        Me.dgvBDA.TabIndex = 0
        '
        'TabControlMain
        '
        Me.TabControlMain.Controls.Add(Me.TabPageBDA)
        Me.TabControlMain.Controls.Add(Me.TabPageDoc)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlMain.Location = New System.Drawing.Point(5, 5)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(604, 346)
        Me.TabControlMain.TabIndex = 2
        '
        'TabPageBDA
        '
        Me.TabPageBDA.BackColor = System.Drawing.Color.Transparent
        Me.TabPageBDA.Controls.Add(Me.ToolStripMain)
        Me.TabPageBDA.Controls.Add(Me.dgvBDA)
        Me.TabPageBDA.Location = New System.Drawing.Point(4, 23)
        Me.TabPageBDA.Name = "TabPageBDA"
        Me.TabPageBDA.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageBDA.Size = New System.Drawing.Size(596, 319)
        Me.TabPageBDA.TabIndex = 0
        Me.TabPageBDA.Text = "Gestione BDA"
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Location = New System.Drawing.Point(3, 3)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(590, 25)
        Me.ToolStripMain.TabIndex = 2
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'TabPageDoc
        '
        Me.TabPageDoc.Controls.Add(Me.btnIndice)
        Me.TabPageDoc.Controls.Add(Me.wbDocumentazione)
        Me.TabPageDoc.Location = New System.Drawing.Point(4, 23)
        Me.TabPageDoc.Name = "TabPageDoc"
        Me.TabPageDoc.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDoc.Size = New System.Drawing.Size(596, 319)
        Me.TabPageDoc.TabIndex = 1
        Me.TabPageDoc.Text = "Documentazione e guida"
        Me.TabPageDoc.UseVisualStyleBackColor = True
        '
        'btnIndice
        '
        Me.btnIndice.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnIndice.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIndice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnIndice.Location = New System.Drawing.Point(3, 3)
        Me.btnIndice.Name = "btnIndice"
        Me.btnIndice.Size = New System.Drawing.Size(590, 23)
        Me.btnIndice.TabIndex = 5
        Me.btnIndice.Text = "Indice"
        Me.btnIndice.UseVisualStyleBackColor = True
        '
        'wbDocumentazione
        '
        Me.wbDocumentazione.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wbDocumentazione.Location = New System.Drawing.Point(6, 32)
        Me.wbDocumentazione.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbDocumentazione.Name = "wbDocumentazione"
        Me.wbDocumentazione.Size = New System.Drawing.Size(583, 281)
        Me.wbDocumentazione.TabIndex = 4
        '
        'FormBDAMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 356)
        Me.Controls.Add(Me.TabControlMain)
        Me.Name = "FormBDAMain"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Text = "Form1"
        CType(Me.dgvBDA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPageBDA.ResumeLayout(False)
        Me.TabPageBDA.PerformLayout()
        Me.TabPageDoc.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvBDA As System.Windows.Forms.DataGridView
    Friend WithEvents TabControlMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPageBDA As System.Windows.Forms.TabPage
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents TabPageDoc As System.Windows.Forms.TabPage
    Friend WithEvents btnIndice As System.Windows.Forms.Button
    Friend WithEvents wbDocumentazione As System.Windows.Forms.WebBrowser

End Class
