<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAzioni
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
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvAzioni = New System.Windows.Forms.DataGridView()
        Me.ButtonSalva = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.LabelAzione = New System.Windows.Forms.Label()
        Me.dtpAzione = New System.Windows.Forms.DateTimePicker()
        Me.CheckBoxNascondi = New System.Windows.Forms.CheckBox()
        Me.ButtonReset = New System.Windows.Forms.Button()
        Me.tlpMain.SuspendLayout()
        CType(Me.dgvAzioni, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 4
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlpMain.Controls.Add(Me.dgvAzioni, 0, 0)
        Me.tlpMain.Controls.Add(Me.ButtonSalva, 2, 1)
        Me.tlpMain.Controls.Add(Me.ButtonEsci, 1, 2)
        Me.tlpMain.Controls.Add(Me.LabelAzione, 0, 1)
        Me.tlpMain.Controls.Add(Me.dtpAzione, 1, 1)
        Me.tlpMain.Controls.Add(Me.CheckBoxNascondi, 0, 2)
        Me.tlpMain.Controls.Add(Me.ButtonReset, 3, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 3
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpMain.Size = New System.Drawing.Size(474, 479)
        Me.tlpMain.TabIndex = 0
        '
        'dgvAzioni
        '
        Me.dgvAzioni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpMain.SetColumnSpan(Me.dgvAzioni, 4)
        Me.dgvAzioni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAzioni.Location = New System.Drawing.Point(3, 3)
        Me.dgvAzioni.Name = "dgvAzioni"
        Me.dgvAzioni.Size = New System.Drawing.Size(468, 398)
        Me.dgvAzioni.TabIndex = 0
        '
        'ButtonSalva
        '
        Me.ButtonSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSalva.Location = New System.Drawing.Point(360, 407)
        Me.ButtonSalva.Name = "ButtonSalva"
        Me.ButtonSalva.Size = New System.Drawing.Size(83, 19)
        Me.ButtonSalva.TabIndex = 1
        Me.ButtonSalva.Text = "Button1"
        Me.ButtonSalva.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.tlpMain.SetColumnSpan(Me.ButtonEsci, 3)
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.Location = New System.Drawing.Point(271, 432)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(200, 44)
        Me.ButtonEsci.TabIndex = 2
        Me.ButtonEsci.Text = "Button2"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'LabelAzione
        '
        Me.LabelAzione.AutoSize = True
        Me.LabelAzione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelAzione.Location = New System.Drawing.Point(3, 404)
        Me.LabelAzione.Name = "LabelAzione"
        Me.LabelAzione.Size = New System.Drawing.Size(262, 25)
        Me.LabelAzione.TabIndex = 3
        Me.LabelAzione.Text = "Label1"
        Me.LabelAzione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpAzione
        '
        Me.dtpAzione.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAzione.Location = New System.Drawing.Point(271, 407)
        Me.dtpAzione.Name = "dtpAzione"
        Me.dtpAzione.Size = New System.Drawing.Size(83, 20)
        Me.dtpAzione.TabIndex = 4
        '
        'CheckBoxNascondi
        '
        Me.CheckBoxNascondi.AutoSize = True
        Me.CheckBoxNascondi.Dock = System.Windows.Forms.DockStyle.Left
        Me.CheckBoxNascondi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxNascondi.Location = New System.Drawing.Point(3, 432)
        Me.CheckBoxNascondi.Name = "CheckBoxNascondi"
        Me.CheckBoxNascondi.Size = New System.Drawing.Size(103, 44)
        Me.CheckBoxNascondi.TabIndex = 5
        Me.CheckBoxNascondi.Text = "Non mostrare più"
        Me.CheckBoxNascondi.UseVisualStyleBackColor = True
        '
        'ButtonReset
        '
        Me.ButtonReset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonReset.Location = New System.Drawing.Point(449, 407)
        Me.ButtonReset.Name = "ButtonReset"
        Me.ButtonReset.Size = New System.Drawing.Size(22, 19)
        Me.ButtonReset.TabIndex = 6
        Me.ButtonReset.Text = "Button1"
        Me.ButtonReset.UseVisualStyleBackColor = True
        '
        'FormAzioni
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 479)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormAzioni"
        Me.Text = "FormAzioni"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        CType(Me.dgvAzioni, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvAzioni As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonSalva As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents LabelAzione As System.Windows.Forms.Label
    Friend WithEvents dtpAzione As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBoxNascondi As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonReset As System.Windows.Forms.Button
End Class
