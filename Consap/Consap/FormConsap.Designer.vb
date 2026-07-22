<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConsap
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
        Me.dgvClienti = New System.Windows.Forms.DataGridView()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.dgvSinistri = New System.Windows.Forms.DataGridView()
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.TabControlMain = New Utx.UtTabControl()
        Me.TabPageRichiesta = New System.Windows.Forms.TabPage()
        Me.TabPageDoc = New System.Windows.Forms.TabPage()
        Me.wbDocumentazione = New System.Windows.Forms.WebBrowser()
        Me.btnIndice = New System.Windows.Forms.Button()
        Me.tlpSinistri = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.dgvClienti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSinistri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
        Me.TabPageRichiesta.SuspendLayout()
        Me.TabPageDoc.SuspendLayout()
        Me.tlpSinistri.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvClienti
        '
        Me.dgvClienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClienti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClienti.Location = New System.Drawing.Point(0, 0)
        Me.dgvClienti.Name = "dgvClienti"
        Me.dgvClienti.Size = New System.Drawing.Size(848, 216)
        Me.dgvClienti.TabIndex = 0
        '
        'ToolStripMain
        '
        Me.ToolStripMain.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(848, 25)
        Me.ToolStripMain.TabIndex = 1
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'dgvSinistri
        '
        Me.dgvSinistri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSinistri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSinistri.Location = New System.Drawing.Point(3, 53)
        Me.dgvSinistri.Name = "dgvSinistri"
        Me.dgvSinistri.Size = New System.Drawing.Size(842, 178)
        Me.dgvSinistri.TabIndex = 0
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMain.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainerMain.Name = "SplitContainerMain"
        Me.SplitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerMain.Panel1
        '
        Me.SplitContainerMain.Panel1.Controls.Add(Me.dgvClienti)
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.Controls.Add(Me.tlpSinistri)
        Me.SplitContainerMain.Size = New System.Drawing.Size(848, 454)
        Me.SplitContainerMain.SplitterDistance = 216
        Me.SplitContainerMain.TabIndex = 1
        '
        'TabControlMain
        '
        Me.TabControlMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControlMain.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
        Me.TabControlMain.Controls.Add(Me.TabPageRichiesta)
        Me.TabControlMain.Controls.Add(Me.TabPageDoc)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlMain.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabControlMain.Location = New System.Drawing.Point(0, 0)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(862, 493)
        Me.TabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControlMain.TabIndex = 2
        Me.TabControlMain.Visible = False
        '
        'TabPageRichiesta
        '
        Me.TabPageRichiesta.Controls.Add(Me.SplitContainerMain)
        Me.TabPageRichiesta.Location = New System.Drawing.Point(4, 29)
        Me.TabPageRichiesta.Name = "TabPageRichiesta"
        Me.TabPageRichiesta.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageRichiesta.Size = New System.Drawing.Size(854, 460)
        Me.TabPageRichiesta.TabIndex = 0
        Me.TabPageRichiesta.Text = "Richiesta"
        Me.TabPageRichiesta.UseVisualStyleBackColor = True
        '
        'TabPageDoc
        '
        Me.TabPageDoc.Controls.Add(Me.wbDocumentazione)
        Me.TabPageDoc.Controls.Add(Me.btnIndice)
        Me.TabPageDoc.Location = New System.Drawing.Point(4, 29)
        Me.TabPageDoc.Name = "TabPageDoc"
        Me.TabPageDoc.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDoc.Size = New System.Drawing.Size(854, 460)
        Me.TabPageDoc.TabIndex = 1
        Me.TabPageDoc.Text = "Documentazione"
        Me.TabPageDoc.UseVisualStyleBackColor = True
        '
        'wbDocumentazione
        '
        Me.wbDocumentazione.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wbDocumentazione.Location = New System.Drawing.Point(3, 32)
        Me.wbDocumentazione.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbDocumentazione.Name = "wbDocumentazione"
        Me.wbDocumentazione.Size = New System.Drawing.Size(848, 432)
        Me.wbDocumentazione.TabIndex = 3
        '
        'btnIndice
        '
        Me.btnIndice.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnIndice.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIndice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnIndice.Location = New System.Drawing.Point(3, 3)
        Me.btnIndice.Name = "btnIndice"
        Me.btnIndice.Size = New System.Drawing.Size(848, 23)
        Me.btnIndice.TabIndex = 2
        Me.btnIndice.Text = "Indice"
        Me.btnIndice.UseVisualStyleBackColor = True
        '
        'tlpSinistri
        '
        Me.tlpSinistri.ColumnCount = 1
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSinistri.Controls.Add(Me.ToolStripMain, 0, 0)
        Me.tlpSinistri.Controls.Add(Me.dgvSinistri, 0, 1)
        Me.tlpSinistri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpSinistri.Location = New System.Drawing.Point(0, 0)
        Me.tlpSinistri.Name = "tlpSinistri"
        Me.tlpSinistri.RowCount = 2
        Me.tlpSinistri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpSinistri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSinistri.Size = New System.Drawing.Size(848, 234)
        Me.tlpSinistri.TabIndex = 2
        '
        'FormConsap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 493)
        Me.Controls.Add(Me.TabControlMain)
        Me.Name = "FormConsap"
        Me.Text = "Form1"
        CType(Me.dgvClienti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSinistri, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        Me.SplitContainerMain.ResumeLayout(False)
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPageRichiesta.ResumeLayout(False)
        Me.TabPageDoc.ResumeLayout(False)
        Me.tlpSinistri.ResumeLayout(False)
        Me.tlpSinistri.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvClienti As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents dgvSinistri As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControlMain As Utx.UtTabControl
    Friend WithEvents TabPageRichiesta As System.Windows.Forms.TabPage
    Friend WithEvents TabPageDoc As System.Windows.Forms.TabPage
    Friend WithEvents wbDocumentazione As System.Windows.Forms.WebBrowser
    Friend WithEvents btnIndice As System.Windows.Forms.Button
    Friend WithEvents tlpSinistri As System.Windows.Forms.TableLayoutPanel

End Class
