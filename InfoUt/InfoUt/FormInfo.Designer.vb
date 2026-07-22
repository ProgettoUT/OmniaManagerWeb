<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInfo
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
        Me.pbUnitools = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.TabControl1 = New Utx.UtTabControl()
        Me.TabUniarea = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pbUniarea = New System.Windows.Forms.PictureBox()
        Me.LabelUniarea = New System.Windows.Forms.Label()
        Me.TabAAU = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.pbAAU = New System.Windows.Forms.PictureBox()
        Me.LabelAAU = New System.Windows.Forms.Label()
        Me.TabLicenza = New System.Windows.Forms.TabPage()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TabUtente = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnResetUtente = New System.Windows.Forms.Button()
        Me.LabelUtente = New System.Windows.Forms.Label()
        Me.btnAutoSpegnimento = New System.Windows.Forms.Button()
        Me.TabVersioni = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.TextBoxFiltro = New System.Windows.Forms.TextBox()
        Me.ButtonFiltro = New System.Windows.Forms.Button()
        Me.TabConfigura = New System.Windows.Forms.TabPage()
        Me.dgvConfig = New System.Windows.Forms.DataGridView()
        CType(Me.pbUnitools, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabUniarea.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.pbUniarea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabAAU.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.pbAAU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabLicenza.SuspendLayout()
        Me.TabUtente.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TabVersioni.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TabConfigura.SuspendLayout()
        CType(Me.dgvConfig, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbUnitools
        '
        Me.pbUnitools.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbUnitools.Location = New System.Drawing.Point(4, 3)
        Me.pbUnitools.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pbUnitools.Name = "pbUnitools"
        Me.pbUnitools.Size = New System.Drawing.Size(428, 88)
        Me.pbUnitools.TabIndex = 0
        Me.pbUnitools.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.24268!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.75732!))
        Me.TableLayoutPanel1.Controls.Add(Me.pbUnitools, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEsci, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 2)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.62745!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.37255!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(558, 510)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btnEsci
        '
        Me.btnEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsci.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEsci.Location = New System.Drawing.Point(440, 3)
        Me.btnEsci.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(114, 88)
        Me.btnEsci.TabIndex = 1
        Me.btnEsci.Text = "Ok"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControl1.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
        Me.TableLayoutPanel1.SetColumnSpan(Me.TabControl1, 2)
        Me.TabControl1.Controls.Add(Me.TabUniarea)
        Me.TabControl1.Controls.Add(Me.TabAAU)
        Me.TabControl1.Controls.Add(Me.TabLicenza)
        Me.TabControl1.Controls.Add(Me.TabUtente)
        Me.TabControl1.Controls.Add(Me.TabConfigura)
        Me.TabControl1.Controls.Add(Me.TabVersioni)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.HotTrack = True
        Me.TabControl1.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabControl1.Location = New System.Drawing.Point(4, 97)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(550, 410)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 2
        Me.TabControl1.Visible = False
        '
        'TabUniarea
        '
        Me.TabUniarea.Controls.Add(Me.TableLayoutPanel2)
        Me.TabUniarea.Location = New System.Drawing.Point(4, 29)
        Me.TabUniarea.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabUniarea.Name = "TabUniarea"
        Me.TabUniarea.Size = New System.Drawing.Size(542, 377)
        Me.TabUniarea.TabIndex = 0
        Me.TabUniarea.Text = "AUA"
        Me.TabUniarea.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.pbUniarea, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelUniarea, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.46032!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.53968!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(542, 377)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'pbUniarea
        '
        Me.pbUniarea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbUniarea.Location = New System.Drawing.Point(3, 3)
        Me.pbUniarea.Name = "pbUniarea"
        Me.pbUniarea.Size = New System.Drawing.Size(536, 135)
        Me.pbUniarea.TabIndex = 0
        Me.pbUniarea.TabStop = False
        '
        'LabelUniarea
        '
        Me.LabelUniarea.BackColor = System.Drawing.Color.White
        Me.LabelUniarea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelUniarea.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUniarea.Location = New System.Drawing.Point(3, 141)
        Me.LabelUniarea.Name = "LabelUniarea"
        Me.LabelUniarea.Size = New System.Drawing.Size(536, 236)
        Me.LabelUniarea.TabIndex = 1
        Me.LabelUniarea.Text = "Label1"
        '
        'TabAAU
        '
        Me.TabAAU.Controls.Add(Me.TableLayoutPanel3)
        Me.TabAAU.Location = New System.Drawing.Point(4, 29)
        Me.TabAAU.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabAAU.Name = "TabAAU"
        Me.TabAAU.Size = New System.Drawing.Size(542, 377)
        Me.TabAAU.TabIndex = 1
        Me.TabAAU.Text = "AAU"
        Me.TabAAU.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.pbAAU, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.LabelAAU, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.46032!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.53968!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(542, 377)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'pbAAU
        '
        Me.pbAAU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbAAU.Location = New System.Drawing.Point(3, 3)
        Me.pbAAU.Name = "pbAAU"
        Me.pbAAU.Size = New System.Drawing.Size(536, 135)
        Me.pbAAU.TabIndex = 0
        Me.pbAAU.TabStop = False
        '
        'LabelAAU
        '
        Me.LabelAAU.BackColor = System.Drawing.Color.White
        Me.LabelAAU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelAAU.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAAU.Location = New System.Drawing.Point(3, 141)
        Me.LabelAAU.Name = "LabelAAU"
        Me.LabelAAU.Size = New System.Drawing.Size(536, 236)
        Me.LabelAAU.TabIndex = 1
        Me.LabelAAU.Text = "Label1"
        '
        'TabLicenza
        '
        Me.TabLicenza.Controls.Add(Me.WebBrowser1)
        Me.TabLicenza.Location = New System.Drawing.Point(4, 29)
        Me.TabLicenza.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabLicenza.Name = "TabLicenza"
        Me.TabLicenza.Size = New System.Drawing.Size(542, 377)
        Me.TabLicenza.TabIndex = 2
        Me.TabLicenza.Text = "Licenza"
        Me.TabLicenza.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(542, 377)
        Me.WebBrowser1.TabIndex = 1
        '
        'TabUtente
        '
        Me.TabUtente.Controls.Add(Me.TableLayoutPanel5)
        Me.TabUtente.Location = New System.Drawing.Point(4, 29)
        Me.TabUtente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabUtente.Name = "TabUtente"
        Me.TabUtente.Size = New System.Drawing.Size(542, 377)
        Me.TabUtente.TabIndex = 3
        Me.TabUtente.Text = "Utente"
        Me.TabUtente.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.btnResetUtente, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.LabelUtente, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.btnAutoSpegnimento, 1, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(542, 377)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'btnResetUtente
        '
        Me.btnResetUtente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnResetUtente.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnResetUtente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetUtente.Location = New System.Drawing.Point(3, 330)
        Me.btnResetUtente.Name = "btnResetUtente"
        Me.btnResetUtente.Size = New System.Drawing.Size(427, 44)
        Me.btnResetUtente.TabIndex = 1
        Me.btnResetUtente.Text = "Modifica i dati utente"
        Me.btnResetUtente.UseVisualStyleBackColor = True
        '
        'LabelUtente
        '
        Me.LabelUtente.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel5.SetColumnSpan(Me.LabelUtente, 2)
        Me.LabelUtente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelUtente.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUtente.Location = New System.Drawing.Point(3, 0)
        Me.LabelUtente.Name = "LabelUtente"
        Me.LabelUtente.Padding = New System.Windows.Forms.Padding(4)
        Me.LabelUtente.Size = New System.Drawing.Size(536, 327)
        Me.LabelUtente.TabIndex = 2
        Me.LabelUtente.Text = "Label1"
        '
        'btnAutoSpegnimento
        '
        Me.btnAutoSpegnimento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAutoSpegnimento.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnAutoSpegnimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoSpegnimento.Location = New System.Drawing.Point(436, 330)
        Me.btnAutoSpegnimento.Name = "btnAutoSpegnimento"
        Me.btnAutoSpegnimento.Size = New System.Drawing.Size(103, 44)
        Me.btnAutoSpegnimento.TabIndex = 3
        Me.btnAutoSpegnimento.Text = "Riservato assistenza"
        Me.btnAutoSpegnimento.UseVisualStyleBackColor = True
        '
        'TabVersioni
        '
        Me.TabVersioni.Controls.Add(Me.TableLayoutPanel6)
        Me.TabVersioni.Location = New System.Drawing.Point(4, 29)
        Me.TabVersioni.Name = "TabVersioni"
        Me.TabVersioni.Size = New System.Drawing.Size(542, 377)
        Me.TabVersioni.TabIndex = 4
        Me.TabVersioni.Text = "Info versioni"
        Me.TabVersioni.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.ListView1, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.TextBoxFiltro, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.ButtonFiltro, 1, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(542, 377)
        Me.TableLayoutPanel6.TabIndex = 1
        '
        'ListView1
        '
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel6.SetColumnSpan(Me.ListView1, 2)
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(3, 28)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(536, 346)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'TextBoxFiltro
        '
        Me.TextBoxFiltro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxFiltro.Location = New System.Drawing.Point(3, 3)
        Me.TextBoxFiltro.Name = "TextBoxFiltro"
        Me.TextBoxFiltro.Size = New System.Drawing.Size(265, 23)
        Me.TextBoxFiltro.TabIndex = 1
        '
        'ButtonFiltro
        '
        Me.ButtonFiltro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonFiltro.Location = New System.Drawing.Point(274, 3)
        Me.ButtonFiltro.Name = "ButtonFiltro"
        Me.ButtonFiltro.Size = New System.Drawing.Size(265, 19)
        Me.ButtonFiltro.TabIndex = 2
        Me.ButtonFiltro.Text = "Button1"
        Me.ButtonFiltro.UseVisualStyleBackColor = True
        '
        'TabConfigura
        '
        Me.TabConfigura.Controls.Add(Me.dgvConfig)
        Me.TabConfigura.Location = New System.Drawing.Point(4, 29)
        Me.TabConfigura.Name = "TabConfigura"
        Me.TabConfigura.Size = New System.Drawing.Size(542, 377)
        Me.TabConfigura.TabIndex = 6
        Me.TabConfigura.Text = "Configurazione"
        Me.TabConfigura.UseVisualStyleBackColor = True
        '
        'dgvConfig
        '
        Me.dgvConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConfig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConfig.Location = New System.Drawing.Point(0, 0)
        Me.dgvConfig.Name = "dgvConfig"
        Me.dgvConfig.Size = New System.Drawing.Size(542, 377)
        Me.dgvConfig.TabIndex = 0
        '
        'FormInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 514)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FormInfo"
        Me.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.pbUnitools, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabUniarea.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.pbUniarea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabAAU.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.pbAAU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabLicenza.ResumeLayout(False)
        Me.TabUtente.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TabVersioni.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TabConfigura.ResumeLayout(False)
        CType(Me.dgvConfig, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbUnitools As System.Windows.Forms.PictureBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As Utx.UtTabControl
    Friend WithEvents TabUniarea As System.Windows.Forms.TabPage
    Friend WithEvents TabAAU As System.Windows.Forms.TabPage
    Friend WithEvents TabLicenza As System.Windows.Forms.TabPage
    Friend WithEvents TabUtente As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pbUniarea As System.Windows.Forms.PictureBox
    Friend WithEvents LabelUniarea As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pbAAU As System.Windows.Forms.PictureBox
    Friend WithEvents LabelAAU As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnResetUtente As System.Windows.Forms.Button
    Friend WithEvents LabelUtente As System.Windows.Forms.Label
    Friend WithEvents TabVersioni As System.Windows.Forms.TabPage
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents btnAutoSpegnimento As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxFiltro As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFiltro As System.Windows.Forms.Button
    Friend WithEvents TabConfigura As Windows.Forms.TabPage
    Friend WithEvents dgvConfig As Windows.Forms.DataGridView
End Class
