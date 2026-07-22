<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVisure
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
        Me.wbVisura = New System.Windows.Forms.WebBrowser()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lbStato = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControlMain = New Utx.UtTabControl()
        Me.Visura = New System.Windows.Forms.TabPage()
        Me.ToolStripVisura = New System.Windows.Forms.ToolStrip()
        Me.Statistiche = New System.Windows.Forms.TabPage()
        Me.ToolStripStat = New System.Windows.Forms.ToolStrip()
        Me.dgvStat = New System.Windows.Forms.DataGridView()
        Me.Condizioni = New System.Windows.Forms.TabPage()
        Me.WebViewCosti = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
        Me.Visura.SuspendLayout()
        Me.Statistiche.SuspendLayout()
        CType(Me.dgvStat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Condizioni.SuspendLayout()
        CType(Me.WebViewCosti, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wbVisura
        '
        Me.wbVisura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wbVisura.Location = New System.Drawing.Point(4, 33)
        Me.wbVisura.Margin = New System.Windows.Forms.Padding(4)
        Me.wbVisura.MinimumSize = New System.Drawing.Size(27, 22)
        Me.wbVisura.Name = "wbVisura"
        Me.wbVisura.Size = New System.Drawing.Size(701, 562)
        Me.wbVisura.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbStato})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 626)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(717, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbStato
        '
        Me.lbStato.Name = "lbStato"
        Me.lbStato.Size = New System.Drawing.Size(144, 17)
        Me.lbStato.Text = "ToolStripStatusLabel1"
        '
        'TabControlMain
        '
        Me.TabControlMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControlMain.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
        Me.TabControlMain.Controls.Add(Me.Visura)
        Me.TabControlMain.Controls.Add(Me.Statistiche)
        Me.TabControlMain.Controls.Add(Me.Condizioni)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlMain.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabControlMain.Location = New System.Drawing.Point(0, 0)
        Me.TabControlMain.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(717, 626)
        Me.TabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControlMain.TabIndex = 9
        Me.TabControlMain.Visible = False
        '
        'Visura
        '
        Me.Visura.Controls.Add(Me.ToolStripVisura)
        Me.Visura.Controls.Add(Me.wbVisura)
        Me.Visura.Location = New System.Drawing.Point(4, 29)
        Me.Visura.Margin = New System.Windows.Forms.Padding(4)
        Me.Visura.Name = "Visura"
        Me.Visura.Padding = New System.Windows.Forms.Padding(4)
        Me.Visura.Size = New System.Drawing.Size(709, 593)
        Me.Visura.TabIndex = 0
        Me.Visura.Text = "Visura"
        Me.Visura.UseVisualStyleBackColor = True
        '
        'ToolStripVisura
        '
        Me.ToolStripVisura.Location = New System.Drawing.Point(4, 4)
        Me.ToolStripVisura.Name = "ToolStripVisura"
        Me.ToolStripVisura.Size = New System.Drawing.Size(701, 25)
        Me.ToolStripVisura.TabIndex = 2
        Me.ToolStripVisura.Text = "ToolStrip2"
        '
        'Statistiche
        '
        Me.Statistiche.Controls.Add(Me.ToolStripStat)
        Me.Statistiche.Controls.Add(Me.dgvStat)
        Me.Statistiche.Location = New System.Drawing.Point(4, 29)
        Me.Statistiche.Margin = New System.Windows.Forms.Padding(4)
        Me.Statistiche.Name = "Statistiche"
        Me.Statistiche.Padding = New System.Windows.Forms.Padding(4)
        Me.Statistiche.Size = New System.Drawing.Size(709, 593)
        Me.Statistiche.TabIndex = 1
        Me.Statistiche.Text = "Statistiche"
        Me.Statistiche.UseVisualStyleBackColor = True
        '
        'ToolStripStat
        '
        Me.ToolStripStat.Location = New System.Drawing.Point(4, 4)
        Me.ToolStripStat.Name = "ToolStripStat"
        Me.ToolStripStat.Size = New System.Drawing.Size(701, 25)
        Me.ToolStripStat.TabIndex = 1
        Me.ToolStripStat.Text = "ToolStrip1"
        '
        'dgvStat
        '
        Me.dgvStat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStat.Location = New System.Drawing.Point(4, 32)
        Me.dgvStat.Name = "dgvStat"
        Me.dgvStat.Size = New System.Drawing.Size(702, 564)
        Me.dgvStat.TabIndex = 0
        '
        'Condizioni
        '
        Me.Condizioni.Controls.Add(Me.WebViewCosti)
        Me.Condizioni.Location = New System.Drawing.Point(4, 29)
        Me.Condizioni.Name = "Condizioni"
        Me.Condizioni.Size = New System.Drawing.Size(709, 593)
        Me.Condizioni.TabIndex = 2
        Me.Condizioni.Text = "Condizioni e costi"
        Me.Condizioni.UseVisualStyleBackColor = True
        '
        'WebViewCosti
        '
        Me.WebViewCosti.AllowExternalDrop = True
        Me.WebViewCosti.CreationProperties = Nothing
        Me.WebViewCosti.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WebViewCosti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebViewCosti.Location = New System.Drawing.Point(0, 0)
        Me.WebViewCosti.Name = "WebViewCosti"
        Me.WebViewCosti.Size = New System.Drawing.Size(709, 593)
        Me.WebViewCosti.TabIndex = 0
        Me.WebViewCosti.ZoomFactor = 1.0R
        '
        'FormVisure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 648)
        Me.Controls.Add(Me.TabControlMain)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormVisure"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControlMain.ResumeLayout(False)
        Me.Visura.ResumeLayout(False)
        Me.Visura.PerformLayout()
        Me.Statistiche.ResumeLayout(False)
        Me.Statistiche.PerformLayout()
        CType(Me.dgvStat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Condizioni.ResumeLayout(False)
        CType(Me.WebViewCosti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents wbVisura As System.Windows.Forms.WebBrowser
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbStato As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabControlMain As Utx.UtTabControl
    Friend WithEvents Visura As System.Windows.Forms.TabPage
    Friend WithEvents Statistiche As System.Windows.Forms.TabPage
    Friend WithEvents dgvStat As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripStat As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripVisura As System.Windows.Forms.ToolStrip
    Friend WithEvents Condizioni As System.Windows.Forms.TabPage
    Friend WithEvents WebViewCosti As Microsoft.Web.WebView2.WinForms.WebView2
End Class
