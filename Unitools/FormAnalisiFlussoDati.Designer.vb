<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnalisiFlussoDati
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
        Me.dgvAnalisi = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelStato = New System.Windows.Forms.Label()
        Me.ButtonFileServer = New System.Windows.Forms.Button()
        Me.ButtonFileImportati = New System.Windows.Forms.Button()
        Me.ButtonDownload = New System.Windows.Forms.Button()
        Me.CheckBox3Mesi = New System.Windows.Forms.CheckBox()
        Me.ButtonCasellaK = New System.Windows.Forms.Button()
        CType(Me.dgvAnalisi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvAnalisi
        '
        Me.dgvAnalisi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvAnalisi, 6)
        Me.dgvAnalisi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAnalisi.Location = New System.Drawing.Point(3, 28)
        Me.dgvAnalisi.Name = "dgvAnalisi"
        Me.dgvAnalisi.Size = New System.Drawing.Size(901, 432)
        Me.dgvAnalisi.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCasellaK, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvAnalisi, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelStato, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonFileServer, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonFileImportati, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonDownload, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBox3Mesi, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(907, 463)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'LabelStato
        '
        Me.LabelStato.AutoSize = True
        Me.LabelStato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelStato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelStato.Location = New System.Drawing.Point(3, 0)
        Me.LabelStato.Name = "LabelStato"
        Me.LabelStato.Size = New System.Drawing.Size(220, 25)
        Me.LabelStato.TabIndex = 1
        Me.LabelStato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonFileServer
        '
        Me.ButtonFileServer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonFileServer.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonFileServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFileServer.Location = New System.Drawing.Point(499, 0)
        Me.ButtonFileServer.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.ButtonFileServer.Name = "ButtonFileServer"
        Me.ButtonFileServer.Size = New System.Drawing.Size(134, 25)
        Me.ButtonFileServer.TabIndex = 2
        Me.ButtonFileServer.Text = "File sul server"
        Me.ButtonFileServer.UseVisualStyleBackColor = True
        '
        'ButtonFileImportati
        '
        Me.ButtonFileImportati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonFileImportati.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonFileImportati.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFileImportati.Location = New System.Drawing.Point(363, 0)
        Me.ButtonFileImportati.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.ButtonFileImportati.Name = "ButtonFileImportati"
        Me.ButtonFileImportati.Size = New System.Drawing.Size(134, 25)
        Me.ButtonFileImportati.TabIndex = 3
        Me.ButtonFileImportati.Text = "File importati"
        Me.ButtonFileImportati.UseVisualStyleBackColor = True
        '
        'ButtonDownload
        '
        Me.ButtonDownload.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonDownload.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDownload.Location = New System.Drawing.Point(634, 0)
        Me.ButtonDownload.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonDownload.Name = "ButtonDownload"
        Me.ButtonDownload.Size = New System.Drawing.Size(136, 25)
        Me.ButtonDownload.TabIndex = 4
        Me.ButtonDownload.Text = "Download file"
        Me.ButtonDownload.UseVisualStyleBackColor = True
        '
        'CheckBox3Mesi
        '
        Me.CheckBox3Mesi.AutoSize = True
        Me.CheckBox3Mesi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox3Mesi.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CheckBox3Mesi.Location = New System.Drawing.Point(227, 0)
        Me.CheckBox3Mesi.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.CheckBox3Mesi.Name = "CheckBox3Mesi"
        Me.CheckBox3Mesi.Size = New System.Drawing.Size(134, 25)
        Me.CheckBox3Mesi.TabIndex = 5
        Me.CheckBox3Mesi.Text = "Importazione ultimi 3 mesi"
        Me.CheckBox3Mesi.UseVisualStyleBackColor = True
        '
        'ButtonCasellaK
        '
        Me.ButtonCasellaK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCasellaK.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonCasellaK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCasellaK.Location = New System.Drawing.Point(770, 0)
        Me.ButtonCasellaK.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCasellaK.Name = "ButtonCasellaK"
        Me.ButtonCasellaK.Size = New System.Drawing.Size(137, 25)
        Me.ButtonCasellaK.TabIndex = 6
        Me.ButtonCasellaK.Text = "Recupera file K"
        Me.ButtonCasellaK.UseVisualStyleBackColor = True
        '
        'FormAnalisiFlussoDati
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 463)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormAnalisiFlussoDati"
        Me.Text = "FormAnalisiFlussoDati"
        CType(Me.dgvAnalisi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvAnalisi As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelStato As System.Windows.Forms.Label
    Friend WithEvents ButtonFileServer As System.Windows.Forms.Button
    Friend WithEvents ButtonFileImportati As System.Windows.Forms.Button
    Friend WithEvents ButtonDownload As System.Windows.Forms.Button
    Friend WithEvents CheckBox3Mesi As CheckBox
    Friend WithEvents ButtonCasellaK As Button
End Class
