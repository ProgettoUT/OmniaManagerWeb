<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNotifiche
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
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.TabPageNumero = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvNumero = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnVisualizzaNotifiche = New System.Windows.Forms.Button()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.btnCercaNotifiche = New System.Windows.Forms.Button()
        Me.btnStampa = New System.Windows.Forms.Button()
        Me.ComboBoxTelefoni = New System.Windows.Forms.ComboBox()
        Me.TabPageConsegnati = New System.Windows.Forms.TabPage()
        Me.dgvConsegnati = New System.Windows.Forms.DataGridView()
        Me.TabPageNonConsegnati = New System.Windows.Forms.TabPage()
        Me.dgvNonConsegnati = New System.Windows.Forms.DataGridView()
        Me.TabPageNonEsitati = New System.Windows.Forms.TabPage()
        Me.dgvNonEsitati = New System.Windows.Forms.DataGridView()
        Me.LabelTesto = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelNumeroSms = New System.Windows.Forms.Label()
        Me.TabControlMain.SuspendLayout()
        Me.TabPageNumero.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageConsegnati.SuspendLayout()
        CType(Me.dgvConsegnati, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageNonConsegnati.SuspendLayout()
        CType(Me.dgvNonConsegnati, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageNonEsitati.SuspendLayout()
        CType(Me.dgvNonEsitati, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlMain
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.TabControlMain, 2)
        Me.TabControlMain.Controls.Add(Me.TabPageNumero)
        Me.TabControlMain.Controls.Add(Me.TabPageConsegnati)
        Me.TabControlMain.Controls.Add(Me.TabPageNonConsegnati)
        Me.TabControlMain.Controls.Add(Me.TabPageNonEsitati)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.Location = New System.Drawing.Point(0, 0)
        Me.TabControlMain.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(919, 404)
        Me.TabControlMain.TabIndex = 0
        '
        'TabPageNumero
        '
        Me.TabPageNumero.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPageNumero.Location = New System.Drawing.Point(4, 23)
        Me.TabPageNumero.Name = "TabPageNumero"
        Me.TabPageNumero.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageNumero.Size = New System.Drawing.Size(911, 377)
        Me.TabPageNumero.TabIndex = 0
        Me.TabPageNumero.Text = "TabPageNumero"
        Me.TabPageNumero.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvNumero, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnVisualizzaNotifiche, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelInfo, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCercaNotifiche, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnStampa, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxTelefoni, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(905, 371)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'dgvNumero
        '
        Me.dgvNumero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvNumero, 6)
        Me.dgvNumero.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNumero.Location = New System.Drawing.Point(3, 31)
        Me.dgvNumero.Name = "dgvNumero"
        Me.dgvNumero.Size = New System.Drawing.Size(899, 337)
        Me.dgvNumero.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 28)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Lista telefoni"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnVisualizzaNotifiche
        '
        Me.btnVisualizzaNotifiche.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVisualizzaNotifiche.Location = New System.Drawing.Point(253, 3)
        Me.btnVisualizzaNotifiche.Name = "btnVisualizzaNotifiche"
        Me.btnVisualizzaNotifiche.Size = New System.Drawing.Size(144, 22)
        Me.btnVisualizzaNotifiche.TabIndex = 3
        Me.btnVisualizzaNotifiche.Text = "Visualizza notifiche"
        Me.btnVisualizzaNotifiche.UseVisualStyleBackColor = True
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.LabelInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelInfo.Location = New System.Drawing.Point(403, 0)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(249, 28)
        Me.LabelInfo.TabIndex = 4
        Me.LabelInfo.Text = "Label2"
        Me.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCercaNotifiche
        '
        Me.btnCercaNotifiche.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCercaNotifiche.Location = New System.Drawing.Point(758, 3)
        Me.btnCercaNotifiche.Name = "btnCercaNotifiche"
        Me.btnCercaNotifiche.Size = New System.Drawing.Size(144, 22)
        Me.btnCercaNotifiche.TabIndex = 5
        Me.btnCercaNotifiche.Text = "Cerca notifiche"
        Me.btnCercaNotifiche.UseVisualStyleBackColor = True
        '
        'btnStampa
        '
        Me.btnStampa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnStampa.Location = New System.Drawing.Point(658, 3)
        Me.btnStampa.Name = "btnStampa"
        Me.btnStampa.Size = New System.Drawing.Size(94, 22)
        Me.btnStampa.TabIndex = 6
        Me.btnStampa.Text = "Stampa"
        Me.btnStampa.UseVisualStyleBackColor = True
        '
        'ComboBoxTelefoni
        '
        Me.ComboBoxTelefoni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxTelefoni.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxTelefoni.FormattingEnabled = True
        Me.ComboBoxTelefoni.Location = New System.Drawing.Point(103, 3)
        Me.ComboBoxTelefoni.Name = "ComboBoxTelefoni"
        Me.ComboBoxTelefoni.Size = New System.Drawing.Size(144, 22)
        Me.ComboBoxTelefoni.TabIndex = 7
        '
        'TabPageConsegnati
        '
        Me.TabPageConsegnati.Controls.Add(Me.dgvConsegnati)
        Me.TabPageConsegnati.Location = New System.Drawing.Point(4, 23)
        Me.TabPageConsegnati.Name = "TabPageConsegnati"
        Me.TabPageConsegnati.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageConsegnati.Size = New System.Drawing.Size(911, 347)
        Me.TabPageConsegnati.TabIndex = 1
        Me.TabPageConsegnati.Text = "TabPageConsegnati"
        Me.TabPageConsegnati.UseVisualStyleBackColor = True
        '
        'dgvConsegnati
        '
        Me.dgvConsegnati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConsegnati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsegnati.Location = New System.Drawing.Point(3, 3)
        Me.dgvConsegnati.Name = "dgvConsegnati"
        Me.dgvConsegnati.Size = New System.Drawing.Size(905, 341)
        Me.dgvConsegnati.TabIndex = 0
        '
        'TabPageNonConsegnati
        '
        Me.TabPageNonConsegnati.Controls.Add(Me.dgvNonConsegnati)
        Me.TabPageNonConsegnati.Location = New System.Drawing.Point(4, 23)
        Me.TabPageNonConsegnati.Name = "TabPageNonConsegnati"
        Me.TabPageNonConsegnati.Size = New System.Drawing.Size(911, 347)
        Me.TabPageNonConsegnati.TabIndex = 2
        Me.TabPageNonConsegnati.Text = "TabPageNonConsegnati"
        Me.TabPageNonConsegnati.UseVisualStyleBackColor = True
        '
        'dgvNonConsegnati
        '
        Me.dgvNonConsegnati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNonConsegnati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNonConsegnati.Location = New System.Drawing.Point(0, 0)
        Me.dgvNonConsegnati.Name = "dgvNonConsegnati"
        Me.dgvNonConsegnati.Size = New System.Drawing.Size(911, 347)
        Me.dgvNonConsegnati.TabIndex = 0
        '
        'TabPageNonEsitati
        '
        Me.TabPageNonEsitati.Controls.Add(Me.dgvNonEsitati)
        Me.TabPageNonEsitati.Location = New System.Drawing.Point(4, 23)
        Me.TabPageNonEsitati.Name = "TabPageNonEsitati"
        Me.TabPageNonEsitati.Size = New System.Drawing.Size(911, 347)
        Me.TabPageNonEsitati.TabIndex = 3
        Me.TabPageNonEsitati.Text = "TabPageNonEsitati"
        Me.TabPageNonEsitati.UseVisualStyleBackColor = True
        '
        'dgvNonEsitati
        '
        Me.dgvNonEsitati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNonEsitati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNonEsitati.Location = New System.Drawing.Point(0, 0)
        Me.dgvNonEsitati.Name = "dgvNonEsitati"
        Me.dgvNonEsitati.Size = New System.Drawing.Size(911, 347)
        Me.dgvNonEsitati.TabIndex = 1
        '
        'LabelTesto
        '
        Me.LabelTesto.BackColor = System.Drawing.Color.NavajoWhite
        Me.LabelTesto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelTesto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTesto.Location = New System.Drawing.Point(3, 407)
        Me.LabelTesto.Margin = New System.Windows.Forms.Padding(3)
        Me.LabelTesto.Name = "LabelTesto"
        Me.LabelTesto.Size = New System.Drawing.Size(833, 64)
        Me.LabelTesto.TabIndex = 1
        Me.LabelTesto.Text = "Label1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TabControlMain, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelTesto, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelNumeroSms, 1, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(919, 474)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'LabelNumeroSms
        '
        Me.LabelNumeroSms.AutoSize = True
        Me.LabelNumeroSms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelNumeroSms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNumeroSms.Location = New System.Drawing.Point(842, 407)
        Me.LabelNumeroSms.Margin = New System.Windows.Forms.Padding(3)
        Me.LabelNumeroSms.Name = "LabelNumeroSms"
        Me.LabelNumeroSms.Size = New System.Drawing.Size(74, 64)
        Me.LabelNumeroSms.TabIndex = 2
        Me.LabelNumeroSms.Text = "Label2"
        '
        'FormNotifiche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 474)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormNotifiche"
        Me.Text = "FormNotifiche"
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPageNumero.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvNumero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageConsegnati.ResumeLayout(False)
        CType(Me.dgvConsegnati, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageNonConsegnati.ResumeLayout(False)
        CType(Me.dgvNonConsegnati, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageNonEsitati.ResumeLayout(False)
        CType(Me.dgvNonEsitati, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControlMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPageNumero As System.Windows.Forms.TabPage
    Friend WithEvents TabPageConsegnati As System.Windows.Forms.TabPage
    Friend WithEvents dgvNumero As System.Windows.Forms.DataGridView
    Friend WithEvents dgvConsegnati As System.Windows.Forms.DataGridView
    Friend WithEvents TabPageNonConsegnati As System.Windows.Forms.TabPage
    Friend WithEvents dgvNonConsegnati As System.Windows.Forms.DataGridView
    Friend WithEvents LabelTesto As System.Windows.Forms.Label
    Friend WithEvents TabPageNonEsitati As System.Windows.Forms.TabPage
    Friend WithEvents dgvNonEsitati As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnVisualizzaNotifiche As System.Windows.Forms.Button
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents btnCercaNotifiche As System.Windows.Forms.Button
    Friend WithEvents btnStampa As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents ComboBoxTelefoni As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelNumeroSms As System.Windows.Forms.Label
End Class
