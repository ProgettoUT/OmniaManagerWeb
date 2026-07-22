<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPattoRca
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
        Me.TabControl1 = New Utx.UtTabControl()
        Me.tpDocumenti = New System.Windows.Forms.TabPage()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.wbDoc = New System.Windows.Forms.WebBrowser()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvElencoSinistri = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbIstruzioni = New System.Windows.Forms.Label()
        Me.ButtonRichiestaSinistro = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TabControl1.SuspendLayout()
        Me.tpDocumenti.SuspendLayout()
        Me.tpMain.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvElencoSinistri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControl1.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
        Me.TabControl1.Controls.Add(Me.tpDocumenti)
        Me.TabControl1.Controls.Add(Me.tpMain)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1157, 584)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 8
        Me.TabControl1.Visible = False
        '
        'tpDocumenti
        '
        Me.tpDocumenti.Controls.Add(Me.ToolStrip2)
        Me.tpDocumenti.Controls.Add(Me.wbDoc)
        Me.tpDocumenti.Location = New System.Drawing.Point(4, 29)
        Me.tpDocumenti.Name = "tpDocumenti"
        Me.tpDocumenti.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDocumenti.Size = New System.Drawing.Size(1149, 551)
        Me.tpDocumenti.TabIndex = 1
        Me.tpDocumenti.Text = "TabPage2"
        Me.tpDocumenti.UseVisualStyleBackColor = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1143, 25)
        Me.ToolStrip2.TabIndex = 2
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'wbDoc
        '
        Me.wbDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wbDoc.Location = New System.Drawing.Point(3, 31)
        Me.wbDoc.MinimumSize = New System.Drawing.Size(23, 22)
        Me.wbDoc.Name = "wbDoc"
        Me.wbDoc.Size = New System.Drawing.Size(1143, 524)
        Me.wbDoc.TabIndex = 1
        '
        'tpMain
        '
        Me.tpMain.Controls.Add(Me.ToolStrip1)
        Me.tpMain.Controls.Add(Me.SplitContainer1)
        Me.tpMain.Location = New System.Drawing.Point(4, 29)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(1149, 551)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "TabPage1"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 31)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvElencoSinistri)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1143, 517)
        Me.SplitContainer1.SplitterDistance = 408
        Me.SplitContainer1.TabIndex = 3
        '
        'dgvElencoSinistri
        '
        Me.dgvElencoSinistri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvElencoSinistri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvElencoSinistri.Location = New System.Drawing.Point(0, 0)
        Me.dgvElencoSinistri.Name = "dgvElencoSinistri"
        Me.dgvElencoSinistri.Size = New System.Drawing.Size(1143, 408)
        Me.dgvElencoSinistri.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbIstruzioni, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonRichiestaSinistro, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1143, 105)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'lbIstruzioni
        '
        Me.lbIstruzioni.BackColor = System.Drawing.Color.Khaki
        Me.lbIstruzioni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbIstruzioni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbIstruzioni.Location = New System.Drawing.Point(3, 0)
        Me.lbIstruzioni.Name = "lbIstruzioni"
        Me.lbIstruzioni.Size = New System.Drawing.Size(908, 105)
        Me.lbIstruzioni.TabIndex = 2
        Me.lbIstruzioni.Text = "Label1"
        '
        'ButtonRichiestaSinistro
        '
        Me.ButtonRichiestaSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonRichiestaSinistro.Location = New System.Drawing.Point(914, 0)
        Me.ButtonRichiestaSinistro.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonRichiestaSinistro.Name = "ButtonRichiestaSinistro"
        Me.ButtonRichiestaSinistro.Size = New System.Drawing.Size(229, 105)
        Me.ButtonRichiestaSinistro.TabIndex = 3
        Me.ButtonRichiestaSinistro.Text = "Button1"
        Me.ButtonRichiestaSinistro.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1143, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'FormPattoRca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1157, 584)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormPattoRca"
        Me.Text = "Form1"
        Me.TabControl1.ResumeLayout(False)
        Me.tpDocumenti.ResumeLayout(False)
        Me.tpDocumenti.PerformLayout()
        Me.tpMain.ResumeLayout(False)
        Me.tpMain.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvElencoSinistri, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As Utx.UtTabControl
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents dgvElencoSinistri As System.Windows.Forms.DataGridView
    Friend WithEvents tpDocumenti As System.Windows.Forms.TabPage
    Friend WithEvents wbDoc As System.Windows.Forms.WebBrowser
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lbIstruzioni As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonRichiestaSinistro As System.Windows.Forms.Button

End Class
