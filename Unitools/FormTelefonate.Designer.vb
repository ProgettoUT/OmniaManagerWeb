<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTelefonate
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
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabMain = New Utx.UtTabControl()
        Me.TabPageTelefono = New System.Windows.Forms.TabPage()
        Me.TabPageDanni = New System.Windows.Forms.TabPage()
        Me.wbDanni = New System.Windows.Forms.WebBrowser()
        Me.TabPageVita = New System.Windows.Forms.TabPage()
        Me.wbVita = New System.Windows.Forms.WebBrowser()
        Me.TabPageSospese = New System.Windows.Forms.TabPage()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvTelefonate = New System.Windows.Forms.DataGridView()
        Me.ButtonSalva = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.TabPageElenco = New System.Windows.Forms.TabPage()
        Me.dgvElenco = New System.Windows.Forms.DataGridView()
        Me.ButtonCerca = New System.Windows.Forms.Button()
        Me.TabMain.SuspendLayout()
        Me.TabPageDanni.SuspendLayout()
        Me.TabPageVita.SuspendLayout()
        Me.TabPageSospese.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        CType(Me.dgvTelefonate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageElenco.SuspendLayout()
        CType(Me.dgvElenco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.VERDE
        Me.TabMain.Controls.Add(Me.TabPageTelefono)
        Me.TabMain.Controls.Add(Me.TabPageDanni)
        Me.TabMain.Controls.Add(Me.TabPageVita)
        Me.TabMain.Controls.Add(Me.TabPageSospese)
        Me.TabMain.Controls.Add(Me.TabPageElenco)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(800, 450)
        Me.TabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabMain.TabIndex = 2
        Me.TabMain.Visible = False
        '
        'TabPageTelefono
        '
        Me.TabPageTelefono.Location = New System.Drawing.Point(4, 29)
        Me.TabPageTelefono.Name = "TabPageTelefono"
        Me.TabPageTelefono.Size = New System.Drawing.Size(792, 417)
        Me.TabPageTelefono.TabIndex = 4
        Me.TabPageTelefono.Text = "Telefono"
        Me.TabPageTelefono.UseVisualStyleBackColor = True
        '
        'TabPageDanni
        '
        Me.TabPageDanni.Controls.Add(Me.wbDanni)
        Me.TabPageDanni.Location = New System.Drawing.Point(4, 29)
        Me.TabPageDanni.Name = "TabPageDanni"
        Me.TabPageDanni.Size = New System.Drawing.Size(792, 417)
        Me.TabPageDanni.TabIndex = 2
        Me.TabPageDanni.Text = "Script Danni"
        Me.TabPageDanni.UseVisualStyleBackColor = True
        '
        'wbDanni
        '
        Me.wbDanni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbDanni.Location = New System.Drawing.Point(0, 0)
        Me.wbDanni.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbDanni.Name = "wbDanni"
        Me.wbDanni.Size = New System.Drawing.Size(792, 417)
        Me.wbDanni.TabIndex = 0
        '
        'TabPageVita
        '
        Me.TabPageVita.Controls.Add(Me.wbVita)
        Me.TabPageVita.Location = New System.Drawing.Point(4, 29)
        Me.TabPageVita.Name = "TabPageVita"
        Me.TabPageVita.Size = New System.Drawing.Size(792, 417)
        Me.TabPageVita.TabIndex = 3
        Me.TabPageVita.Text = "Script Vita"
        Me.TabPageVita.UseVisualStyleBackColor = True
        '
        'wbVita
        '
        Me.wbVita.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbVita.Location = New System.Drawing.Point(0, 0)
        Me.wbVita.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbVita.Name = "wbVita"
        Me.wbVita.Size = New System.Drawing.Size(792, 417)
        Me.wbVita.TabIndex = 0
        '
        'TabPageSospese
        '
        Me.TabPageSospese.Controls.Add(Me.tlpMain)
        Me.TabPageSospese.Location = New System.Drawing.Point(4, 29)
        Me.TabPageSospese.Name = "TabPageSospese"
        Me.TabPageSospese.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageSospese.Size = New System.Drawing.Size(792, 417)
        Me.TabPageSospese.TabIndex = 0
        Me.TabPageSospese.Text = "Da completare"
        Me.TabPageSospese.UseVisualStyleBackColor = True
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 3
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpMain.Controls.Add(Me.ButtonCerca, 0, 2)
        Me.tlpMain.Controls.Add(Me.dgvTelefonate, 0, 0)
        Me.tlpMain.Controls.Add(Me.ButtonSalva, 1, 2)
        Me.tlpMain.Controls.Add(Me.ButtonAnnulla, 2, 2)
        Me.tlpMain.Controls.Add(Me.LabelInfo, 0, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(3, 3)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 3
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMain.Size = New System.Drawing.Size(786, 411)
        Me.tlpMain.TabIndex = 1
        '
        'dgvTelefonate
        '
        Me.dgvTelefonate.AllowUserToAddRows = False
        Me.dgvTelefonate.AllowUserToDeleteRows = False
        Me.dgvTelefonate.AllowUserToResizeRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvTelefonate.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTelefonate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTelefonate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpMain.SetColumnSpan(Me.dgvTelefonate, 3)
        Me.dgvTelefonate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTelefonate.Location = New System.Drawing.Point(1, 1)
        Me.dgvTelefonate.Margin = New System.Windows.Forms.Padding(1)
        Me.dgvTelefonate.Name = "dgvTelefonate"
        Me.dgvTelefonate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTelefonate.Size = New System.Drawing.Size(784, 289)
        Me.dgvTelefonate.TabIndex = 0
        '
        'ButtonCerca
        '
        Me.ButtonCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCerca.FlatAppearance.BorderSize = 1
        Me.ButtonCerca.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonCerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCerca.Location = New System.Drawing.Point(1, 372)
        Me.ButtonCerca.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonCerca.Padding = New Padding(20, 0, 20, 0)
        Me.ButtonCerca.Name = "ButtonCerca"
        Me.ButtonCerca.Size = New System.Drawing.Size(259, 38)
        Me.ButtonCerca.TabIndex = 4
        Me.ButtonCerca.Text = "Cerca cliente"
        Me.ButtonCerca.TextAlign = Drawing.ContentAlignment.MiddleRight
        Me.ButtonCerca.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCerca.UseVisualStyleBackColor = True
        '
        'ButtonSalva
        '
        Me.ButtonSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.FlatAppearance.BorderSize = 1
        Me.ButtonSalva.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSalva.Location = New System.Drawing.Point(262, 372)
        Me.ButtonSalva.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonSalva.Padding = New Padding(20, 0, 20, 0)
        Me.ButtonSalva.Name = "ButtonSalva"
        Me.ButtonSalva.Size = New System.Drawing.Size(259, 38)
        Me.ButtonSalva.TabIndex = 1
        Me.ButtonSalva.Text = "Salva"
        Me.ButtonSalva.TextAlign = Drawing.ContentAlignment.MiddleRight
        Me.ButtonSalva.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSalva.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.FlatAppearance.BorderSize = 1
        Me.ButtonAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnnulla.Location = New System.Drawing.Point(523, 372)
        Me.ButtonAnnulla.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonAnnulla.Padding = New Padding(20, 0, 20, 0)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(262, 38)
        Me.ButtonAnnulla.TabIndex = 2
        Me.ButtonAnnulla.Text = "Annulla"
        Me.ButtonAnnulla.TextAlign = Drawing.ContentAlignment.MiddleRight
        Me.ButtonAnnulla.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.tlpMain.SetColumnSpan(Me.LabelInfo, 3)
        Me.LabelInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfo.Location = New System.Drawing.Point(1, 292)
        Me.LabelInfo.Margin = New System.Windows.Forms.Padding(1)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(784, 78)
        Me.LabelInfo.TabIndex = 3
        Me.LabelInfo.Text = "Label1"
        '
        'TabPageElenco
        '
        Me.TabPageElenco.Controls.Add(Me.dgvElenco)
        Me.TabPageElenco.Location = New System.Drawing.Point(4, 29)
        Me.TabPageElenco.Name = "TabPageElenco"
        Me.TabPageElenco.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageElenco.Size = New System.Drawing.Size(792, 417)
        Me.TabPageElenco.TabIndex = 1
        Me.TabPageElenco.Text = "Elenco completo"
        Me.TabPageElenco.UseVisualStyleBackColor = True
        '
        'dgvElenco
        '
        Me.dgvElenco.AllowUserToAddRows = False
        Me.dgvElenco.AllowUserToDeleteRows = False
        Me.dgvElenco.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvElenco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvElenco.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvElenco.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvElenco.Location = New System.Drawing.Point(3, 3)
        Me.dgvElenco.Name = "dgvElenco"
        Me.dgvElenco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvElenco.Size = New System.Drawing.Size(786, 411)
        Me.dgvElenco.TabIndex = 0
        '
        'FormTelefonate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "FormTelefonate"
        Me.Text = "FormTelefonate"
        Me.TabMain.ResumeLayout(False)
        Me.TabPageDanni.ResumeLayout(False)
        Me.TabPageVita.ResumeLayout(False)
        Me.TabPageSospese.ResumeLayout(False)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        CType(Me.dgvTelefonate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageElenco.ResumeLayout(False)
        CType(Me.dgvElenco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvTelefonate As DataGridView
    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents ButtonSalva As Button
    Friend WithEvents ButtonAnnulla As Button
    Friend WithEvents LabelInfo As Label
    Friend WithEvents TabMain As Utx.UtTabControl
    Friend WithEvents TabPageSospese As TabPage
    Friend WithEvents TabPageElenco As TabPage
    Friend WithEvents dgvElenco As DataGridView
    Friend WithEvents TabPageDanni As TabPage
    Friend WithEvents wbDanni As WebBrowser
    Friend WithEvents TabPageVita As TabPage
    Friend WithEvents wbVita As WebBrowser
    Friend WithEvents TabPageTelefono As TabPage
    Friend WithEvents ButtonCerca As Button
End Class
