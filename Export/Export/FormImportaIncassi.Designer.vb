<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImportaIncassi
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
        Me.ButtonImporta = New System.Windows.Forms.Button()
        Me.dtpInizioPeriodo = New System.Windows.Forms.DateTimePicker()
        Me.RadioButtonLeggi = New System.Windows.Forms.RadioButton()
        Me.RadioButtonScaricaFile = New System.Windows.Forms.RadioButton()
        Me.GroupBoxDate = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadioButtonData = New System.Windows.Forms.RadioButton()
        Me.RadioButtonAutoData = New System.Windows.Forms.RadioButton()
        Me.GroupBoxTipoLettura = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadioButtonAuto = New System.Windows.Forms.RadioButton()
        Me.RadioButtonOpzioni = New System.Windows.Forms.RadioButton()
        Me.GroupBoxAgenzie = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.ComboBoxAgenzie = New System.Windows.Forms.ComboBox()
        Me.LabelUltimoAggiornamento = New System.Windows.Forms.Label()
        Me.GroupBoxDate.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBoxTipoLettura.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.GroupBoxAgenzie.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonImporta
        '
        Me.ButtonImporta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonImporta.FlatAppearance.BorderSize = 0
        Me.ButtonImporta.Location = New System.Drawing.Point(3, 298)
        Me.ButtonImporta.Name = "ButtonImporta"
        Me.ButtonImporta.Size = New System.Drawing.Size(288, 45)
        Me.ButtonImporta.TabIndex = 0
        Me.ButtonImporta.Text = "Avvia l'importazione degli incassi"
        Me.ButtonImporta.UseVisualStyleBackColor = True
        '
        'dtpInizioPeriodo
        '
        Me.dtpInizioPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpInizioPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInizioPeriodo.Location = New System.Drawing.Point(207, 33)
        Me.dtpInizioPeriodo.Name = "dtpInizioPeriodo"
        Me.dtpInizioPeriodo.Size = New System.Drawing.Size(198, 22)
        Me.dtpInizioPeriodo.TabIndex = 1
        '
        'RadioButtonLeggi
        '
        Me.RadioButtonLeggi.AutoSize = True
        Me.RadioButtonLeggi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonLeggi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButtonLeggi.Location = New System.Drawing.Point(3, 3)
        Me.RadioButtonLeggi.Name = "RadioButtonLeggi"
        Me.RadioButtonLeggi.Size = New System.Drawing.Size(402, 24)
        Me.RadioButtonLeggi.TabIndex = 2
        Me.RadioButtonLeggi.TabStop = True
        Me.RadioButtonLeggi.Text = "Leggi dai file archiviati quando possibile"
        Me.RadioButtonLeggi.UseVisualStyleBackColor = True
        '
        'RadioButtonScaricaFile
        '
        Me.RadioButtonScaricaFile.AutoSize = True
        Me.RadioButtonScaricaFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonScaricaFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButtonScaricaFile.Location = New System.Drawing.Point(3, 33)
        Me.RadioButtonScaricaFile.Name = "RadioButtonScaricaFile"
        Me.RadioButtonScaricaFile.Size = New System.Drawing.Size(402, 25)
        Me.RadioButtonScaricaFile.TabIndex = 3
        Me.RadioButtonScaricaFile.TabStop = True
        Me.RadioButtonScaricaFile.Text = "Scarica di nuovo tutti i dati da Essig"
        Me.RadioButtonScaricaFile.UseVisualStyleBackColor = True
        '
        'GroupBoxDate
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBoxDate, 2)
        Me.GroupBoxDate.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBoxDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBoxDate.Location = New System.Drawing.Point(3, 68)
        Me.GroupBoxDate.Name = "GroupBoxDate"
        Me.GroupBoxDate.Size = New System.Drawing.Size(414, 82)
        Me.GroupBoxDate.TabIndex = 4
        Me.GroupBoxDate.TabStop = False
        Me.GroupBoxDate.Text = "Data inizio importazione"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.dtpInizioPeriodo, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.RadioButtonData, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.RadioButtonAutoData, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(408, 61)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'RadioButtonData
        '
        Me.RadioButtonData.AutoSize = True
        Me.RadioButtonData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButtonData.Location = New System.Drawing.Point(3, 33)
        Me.RadioButtonData.Name = "RadioButtonData"
        Me.RadioButtonData.Size = New System.Drawing.Size(198, 25)
        Me.RadioButtonData.TabIndex = 2
        Me.RadioButtonData.TabStop = True
        Me.RadioButtonData.Text = "Importa da questa data"
        Me.RadioButtonData.UseVisualStyleBackColor = True
        '
        'RadioButtonAutoData
        '
        Me.RadioButtonAutoData.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.RadioButtonAutoData, 2)
        Me.RadioButtonAutoData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonAutoData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButtonAutoData.Location = New System.Drawing.Point(3, 3)
        Me.RadioButtonAutoData.Name = "RadioButtonAutoData"
        Me.RadioButtonAutoData.Size = New System.Drawing.Size(402, 24)
        Me.RadioButtonAutoData.TabIndex = 3
        Me.RadioButtonAutoData.TabStop = True
        Me.RadioButtonAutoData.Text = "Seleziona la data automaticamente"
        Me.RadioButtonAutoData.UseVisualStyleBackColor = True
        '
        'GroupBoxTipoLettura
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBoxTipoLettura, 2)
        Me.GroupBoxTipoLettura.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBoxTipoLettura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxTipoLettura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBoxTipoLettura.Location = New System.Drawing.Point(3, 156)
        Me.GroupBoxTipoLettura.Name = "GroupBoxTipoLettura"
        Me.GroupBoxTipoLettura.Size = New System.Drawing.Size(414, 82)
        Me.GroupBoxTipoLettura.TabIndex = 5
        Me.GroupBoxTipoLettura.TabStop = False
        Me.GroupBoxTipoLettura.Text = "Tipo di lettura incassi"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.RadioButtonLeggi, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.RadioButtonScaricaFile, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(408, 61)
        Me.TableLayoutPanel3.TabIndex = 4
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.23809!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.76191!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBoxDate, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBoxTipoLettura, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonImporta, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnnulla, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBoxAgenzie, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelUltimoAggiornamento, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.09524!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.09524!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(420, 346)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.Location = New System.Drawing.Point(297, 298)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(120, 45)
        Me.ButtonAnnulla.TabIndex = 6
        Me.ButtonAnnulla.Text = "Annulla"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(414, 34)
        Me.Panel1.TabIndex = 7
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.RadioButtonAuto, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.RadioButtonOpzioni, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(412, 32)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'RadioButtonAuto
        '
        Me.RadioButtonAuto.AutoSize = True
        Me.RadioButtonAuto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonAuto.Location = New System.Drawing.Point(3, 3)
        Me.RadioButtonAuto.Name = "RadioButtonAuto"
        Me.RadioButtonAuto.Size = New System.Drawing.Size(200, 26)
        Me.RadioButtonAuto.TabIndex = 0
        Me.RadioButtonAuto.TabStop = True
        Me.RadioButtonAuto.Text = "Importazione automatica"
        Me.RadioButtonAuto.UseVisualStyleBackColor = True
        '
        'RadioButtonOpzioni
        '
        Me.RadioButtonOpzioni.AutoSize = True
        Me.RadioButtonOpzioni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonOpzioni.Location = New System.Drawing.Point(209, 3)
        Me.RadioButtonOpzioni.Name = "RadioButtonOpzioni"
        Me.RadioButtonOpzioni.Size = New System.Drawing.Size(200, 26)
        Me.RadioButtonOpzioni.TabIndex = 1
        Me.RadioButtonOpzioni.TabStop = True
        Me.RadioButtonOpzioni.Text = "Seleziona opzioni"
        Me.RadioButtonOpzioni.UseVisualStyleBackColor = True
        '
        'GroupBoxAgenzie
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBoxAgenzie, 2)
        Me.GroupBoxAgenzie.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupBoxAgenzie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxAgenzie.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBoxAgenzie.Location = New System.Drawing.Point(3, 244)
        Me.GroupBoxAgenzie.Name = "GroupBoxAgenzie"
        Me.GroupBoxAgenzie.Size = New System.Drawing.Size(414, 48)
        Me.GroupBoxAgenzie.TabIndex = 8
        Me.GroupBoxAgenzie.TabStop = False
        Me.GroupBoxAgenzie.Text = "Codici da aggiornare"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.ComboBoxAgenzie, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(408, 27)
        Me.TableLayoutPanel5.TabIndex = 1
        '
        'ComboBoxAgenzie
        '
        Me.ComboBoxAgenzie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxAgenzie.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxAgenzie.FormattingEnabled = True
        Me.ComboBoxAgenzie.Location = New System.Drawing.Point(3, 3)
        Me.ComboBoxAgenzie.Name = "ComboBoxAgenzie"
        Me.ComboBoxAgenzie.Size = New System.Drawing.Size(402, 22)
        Me.ComboBoxAgenzie.TabIndex = 0
        '
        'LabelUltimoAggiornamento
        '
        Me.LabelUltimoAggiornamento.AutoSize = True
        Me.LabelUltimoAggiornamento.BackColor = System.Drawing.Color.Gainsboro
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelUltimoAggiornamento, 2)
        Me.LabelUltimoAggiornamento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelUltimoAggiornamento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelUltimoAggiornamento.Location = New System.Drawing.Point(3, 0)
        Me.LabelUltimoAggiornamento.Name = "LabelUltimoAggiornamento"
        Me.LabelUltimoAggiornamento.Size = New System.Drawing.Size(414, 25)
        Me.LabelUltimoAggiornamento.TabIndex = 9
        Me.LabelUltimoAggiornamento.Text = "LabelUltimoAggiornamento"
        Me.LabelUltimoAggiornamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormImportaIncassi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 346)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormImportaIncassi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormImportaIncassi"
        Me.GroupBoxDate.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.GroupBoxTipoLettura.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.GroupBoxAgenzie.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonImporta As System.Windows.Forms.Button
    Friend WithEvents dtpInizioPeriodo As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadioButtonLeggi As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonScaricaFile As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBoxDate As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxTipoLettura As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RadioButtonData As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonAutoData As System.Windows.Forms.RadioButton
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RadioButtonAuto As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonOpzioni As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBoxAgenzie As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBoxAgenzie As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelUltimoAggiornamento As System.Windows.Forms.Label
End Class
