<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnalisiDb
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
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonMdb = New UtControls.UtFlatButton()
        Me.ButtonCorreggi = New UtControls.UtFlatButton()
        Me.ButtonEsci = New UtControls.UtFlatButton()
        Me.ButtonAggiorna = New UtControls.UtFlatButton()
        Me.LabelMessaggio = New System.Windows.Forms.Label()
        Me.ButtonCorreggiTutto = New UtControls.UtFlatButton()
        Me.ButtonLog = New UtControls.UtFlatButton()
        Me.ButtonCsv = New UtControls.UtFlatButton()
        Me.ButtonDbUno = New UtControls.UtFlatButton()
        CType(Me.dgvAnalisi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvAnalisi
        '
        Me.dgvAnalisi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpMain.SetColumnSpan(Me.dgvAnalisi, 6)
        Me.dgvAnalisi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAnalisi.Location = New System.Drawing.Point(3, 3)
        Me.dgvAnalisi.Name = "dgvAnalisi"
        Me.dgvAnalisi.Size = New System.Drawing.Size(690, 432)
        Me.dgvAnalisi.TabIndex = 0
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 6
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpMain.Controls.Add(Me.ButtonMdb, 4, 1)
        Me.tlpMain.Controls.Add(Me.dgvAnalisi, 0, 0)
        Me.tlpMain.Controls.Add(Me.ButtonCorreggi, 0, 2)
        Me.tlpMain.Controls.Add(Me.ButtonEsci, 5, 2)
        Me.tlpMain.Controls.Add(Me.ButtonAggiorna, 2, 2)
        Me.tlpMain.Controls.Add(Me.LabelMessaggio, 0, 1)
        Me.tlpMain.Controls.Add(Me.ButtonCorreggiTutto, 1, 2)
        Me.tlpMain.Controls.Add(Me.ButtonLog, 5, 1)
        Me.tlpMain.Controls.Add(Me.ButtonCsv, 4, 2)
        Me.tlpMain.Controls.Add(Me.ButtonDbUno, 3, 2)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 3
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.Size = New System.Drawing.Size(696, 513)
        Me.tlpMain.TabIndex = 1
        '
        'ButtonMdb
        '
        Me.ButtonMdb.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ButtonMdb.DefaultBorderSize = 0
        Me.ButtonMdb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonMdb.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonMdb.FlatAppearance.BorderSize = 0
        Me.ButtonMdb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonMdb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonMdb.Location = New System.Drawing.Point(460, 438)
        Me.ButtonMdb.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonMdb.Name = "ButtonMdb"
        Me.ButtonMdb.Size = New System.Drawing.Size(115, 25)
        Me.ButtonMdb.TabIndex = 9
        Me.ButtonMdb.Text = "UtFlatButton2"
        Me.ButtonMdb.UseVisualStyleBackColor = False
        '
        'ButtonCorreggi
        '
        Me.ButtonCorreggi.DefaultBorderSize = 0
        Me.ButtonCorreggi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCorreggi.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonCorreggi.FlatAppearance.BorderSize = 0
        Me.ButtonCorreggi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonCorreggi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCorreggi.Location = New System.Drawing.Point(0, 463)
        Me.ButtonCorreggi.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCorreggi.Name = "ButtonCorreggi"
        Me.ButtonCorreggi.Size = New System.Drawing.Size(115, 50)
        Me.ButtonCorreggi.TabIndex = 1
        Me.ButtonCorreggi.Text = "UtFlatButton1"
        Me.ButtonCorreggi.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.DefaultBorderSize = 0
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonEsci.FlatAppearance.BorderSize = 0
        Me.ButtonEsci.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsci.Location = New System.Drawing.Point(575, 463)
        Me.ButtonEsci.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(121, 50)
        Me.ButtonEsci.TabIndex = 2
        Me.ButtonEsci.Text = "UtFlatButton2"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'ButtonAggiorna
        '
        Me.ButtonAggiorna.DefaultBorderSize = 0
        Me.ButtonAggiorna.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiorna.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonAggiorna.FlatAppearance.BorderSize = 0
        Me.ButtonAggiorna.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonAggiorna.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAggiorna.Location = New System.Drawing.Point(230, 463)
        Me.ButtonAggiorna.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAggiorna.Name = "ButtonAggiorna"
        Me.ButtonAggiorna.Size = New System.Drawing.Size(115, 50)
        Me.ButtonAggiorna.TabIndex = 3
        Me.ButtonAggiorna.Text = "UtFlatButton1"
        Me.ButtonAggiorna.UseVisualStyleBackColor = True
        '
        'LabelMessaggio
        '
        Me.LabelMessaggio.AutoSize = True
        Me.tlpMain.SetColumnSpan(Me.LabelMessaggio, 4)
        Me.LabelMessaggio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMessaggio.Location = New System.Drawing.Point(3, 438)
        Me.LabelMessaggio.Name = "LabelMessaggio"
        Me.LabelMessaggio.Size = New System.Drawing.Size(454, 25)
        Me.LabelMessaggio.TabIndex = 4
        Me.LabelMessaggio.Text = "Label1"
        Me.LabelMessaggio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonCorreggiTutto
        '
        Me.ButtonCorreggiTutto.DefaultBorderSize = 0
        Me.ButtonCorreggiTutto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCorreggiTutto.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonCorreggiTutto.FlatAppearance.BorderSize = 0
        Me.ButtonCorreggiTutto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonCorreggiTutto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCorreggiTutto.Location = New System.Drawing.Point(115, 463)
        Me.ButtonCorreggiTutto.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCorreggiTutto.Name = "ButtonCorreggiTutto"
        Me.ButtonCorreggiTutto.Size = New System.Drawing.Size(115, 50)
        Me.ButtonCorreggiTutto.TabIndex = 5
        Me.ButtonCorreggiTutto.Text = "UtFlatButton1"
        Me.ButtonCorreggiTutto.UseVisualStyleBackColor = True
        '
        'ButtonLog
        '
        Me.ButtonLog.DefaultBorderSize = 0
        Me.ButtonLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonLog.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonLog.FlatAppearance.BorderSize = 0
        Me.ButtonLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLog.Location = New System.Drawing.Point(575, 438)
        Me.ButtonLog.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonLog.Name = "ButtonLog"
        Me.ButtonLog.Size = New System.Drawing.Size(121, 25)
        Me.ButtonLog.TabIndex = 6
        Me.ButtonLog.Text = "UtFlatButton2"
        Me.ButtonLog.UseVisualStyleBackColor = True
        '
        'ButtonCsv
        '
        Me.ButtonCsv.DefaultBorderSize = 0
        Me.ButtonCsv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCsv.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonCsv.FlatAppearance.BorderSize = 0
        Me.ButtonCsv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCsv.Location = New System.Drawing.Point(460, 463)
        Me.ButtonCsv.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCsv.Name = "ButtonCsv"
        Me.ButtonCsv.Size = New System.Drawing.Size(115, 50)
        Me.ButtonCsv.TabIndex = 7
        Me.ButtonCsv.Text = "UtFlatButton1"
        Me.ButtonCsv.UseVisualStyleBackColor = True
        '
        'ButtonDbUno
        '
        Me.ButtonDbUno.DefaultBorderSize = 0
        Me.ButtonDbUno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonDbUno.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonDbUno.FlatAppearance.BorderSize = 0
        Me.ButtonDbUno.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonDbUno.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDbUno.Location = New System.Drawing.Point(345, 463)
        Me.ButtonDbUno.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonDbUno.Name = "ButtonDbUno"
        Me.ButtonDbUno.Size = New System.Drawing.Size(115, 50)
        Me.ButtonDbUno.TabIndex = 8
        Me.ButtonDbUno.Text = "UtFlatButton1"
        Me.ButtonDbUno.UseVisualStyleBackColor = True
        '
        'FormAnalisiDb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 513)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormAnalisiDb"
        Me.Text = "FormAnalisiDb"
        CType(Me.dgvAnalisi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvAnalisi As System.Windows.Forms.DataGridView
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonCorreggi As UtControls.UtFlatButton
    Friend WithEvents ButtonEsci As UtControls.UtFlatButton
    Friend WithEvents ButtonAggiorna As UtControls.UtFlatButton
    Friend WithEvents LabelMessaggio As System.Windows.Forms.Label
    Friend WithEvents ButtonCorreggiTutto As UtControls.UtFlatButton
    Friend WithEvents ButtonLog As UtControls.UtFlatButton
    Friend WithEvents ButtonCsv As UtControls.UtFlatButton
    Friend WithEvents ButtonDbUno As UtControls.UtFlatButton
    Friend WithEvents ButtonMdb As UtControls.UtFlatButton
End Class
