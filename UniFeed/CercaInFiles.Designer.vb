<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CercaInFiles
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.UtFlatButtonApriLog = New UtControls.UtFlatButton()
        Me.lblMessaggio3 = New System.Windows.Forms.Label()
        Me.lblMessaggio2 = New System.Windows.Forms.Label()
        Me.lblMessaggio1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DateTimePickerMax = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerMin = New System.Windows.Forms.DateTimePicker()
        Me.UtFlatButtonCerca = New UtControls.UtFlatButton()
        Me.TextBoxCampo3 = New System.Windows.Forms.TextBox()
        Me.TextBoxCampo2 = New System.Windows.Forms.TextBox()
        Me.TextBoxCampo1 = New System.Windows.Forms.TextBox()
        Me.TextBoxContiene = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxTipoRecord = New System.Windows.Forms.ComboBox()
        Me.ComboBoxCampo3 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxCampo2 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxCampo1 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.UtFlatButtonEsci = New UtControls.UtFlatButton()
        Me.CheckedListBoxAgenzie = New System.Windows.Forms.CheckedListBox()
        Me.CheckBoxAgenzie = New System.Windows.Forms.CheckBox()
        Me.UtFlatButtonAnnulla = New UtControls.UtFlatButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UtFlatButtonApriLog
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.UtFlatButtonApriLog, 3)
        Me.UtFlatButtonApriLog.DefaultBorderSize = 0
        Me.UtFlatButtonApriLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UtFlatButtonApriLog.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.UtFlatButtonApriLog.FlatAppearance.BorderSize = 0
        Me.UtFlatButtonApriLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.UtFlatButtonApriLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UtFlatButtonApriLog.Location = New System.Drawing.Point(0, 411)
        Me.UtFlatButtonApriLog.Margin = New System.Windows.Forms.Padding(0)
        Me.UtFlatButtonApriLog.Name = "UtFlatButtonApriLog"
        Me.UtFlatButtonApriLog.Size = New System.Drawing.Size(654, 40)
        Me.UtFlatButtonApriLog.TabIndex = 11
        Me.UtFlatButtonApriLog.Text = "Apri file log"
        Me.UtFlatButtonApriLog.UseVisualStyleBackColor = True
        '
        'lblMessaggio3
        '
        Me.lblMessaggio3.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblMessaggio3, 4)
        Me.lblMessaggio3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMessaggio3.Location = New System.Drawing.Point(3, 252)
        Me.lblMessaggio3.Name = "lblMessaggio3"
        Me.lblMessaggio3.Size = New System.Drawing.Size(748, 159)
        Me.lblMessaggio3.TabIndex = 6
        '
        'lblMessaggio2
        '
        Me.lblMessaggio2.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblMessaggio2, 4)
        Me.lblMessaggio2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMessaggio2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessaggio2.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblMessaggio2.Location = New System.Drawing.Point(3, 236)
        Me.lblMessaggio2.Name = "lblMessaggio2"
        Me.lblMessaggio2.Size = New System.Drawing.Size(748, 16)
        Me.lblMessaggio2.TabIndex = 6
        Me.lblMessaggio2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMessaggio1
        '
        Me.lblMessaggio1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblMessaggio1, 4)
        Me.lblMessaggio1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMessaggio1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessaggio1.ForeColor = System.Drawing.Color.Chocolate
        Me.lblMessaggio1.Location = New System.Drawing.Point(3, 220)
        Me.lblMessaggio1.Name = "lblMessaggio1"
        Me.lblMessaggio1.Size = New System.Drawing.Size(748, 16)
        Me.lblMessaggio1.TabIndex = 6
        Me.lblMessaggio1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(3, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 26)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Data dal / al"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimePickerMax
        '
        Me.DateTimePickerMax.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePickerMax.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerMax.Location = New System.Drawing.Point(380, 49)
        Me.DateTimePickerMax.Name = "DateTimePickerMax"
        Me.DateTimePickerMax.Size = New System.Drawing.Size(271, 20)
        Me.DateTimePickerMax.TabIndex = 2
        Me.DateTimePickerMax.Value = New Date(2099, 12, 31, 0, 0, 0, 0)
        '
        'DateTimePickerMin
        '
        Me.DateTimePickerMin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePickerMin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerMin.Location = New System.Drawing.Point(103, 49)
        Me.DateTimePickerMin.Name = "DateTimePickerMin"
        Me.DateTimePickerMin.Size = New System.Drawing.Size(271, 20)
        Me.DateTimePickerMin.TabIndex = 1
        Me.DateTimePickerMin.Value = New Date(2001, 1, 1, 0, 0, 0, 0)
        '
        'UtFlatButtonCerca
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.UtFlatButtonCerca, 3)
        Me.UtFlatButtonCerca.DefaultBorderSize = 0
        Me.UtFlatButtonCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UtFlatButtonCerca.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.UtFlatButtonCerca.FlatAppearance.BorderSize = 0
        Me.UtFlatButtonCerca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.UtFlatButtonCerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UtFlatButtonCerca.Location = New System.Drawing.Point(0, 180)
        Me.UtFlatButtonCerca.Margin = New System.Windows.Forms.Padding(0)
        Me.UtFlatButtonCerca.Name = "UtFlatButtonCerca"
        Me.UtFlatButtonCerca.Size = New System.Drawing.Size(654, 40)
        Me.UtFlatButtonCerca.TabIndex = 10
        Me.UtFlatButtonCerca.Text = "Cerca nei files"
        Me.UtFlatButtonCerca.UseVisualStyleBackColor = True
        '
        'TextBoxCampo3
        '
        Me.TextBoxCampo3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCampo3.Location = New System.Drawing.Point(380, 156)
        Me.TextBoxCampo3.Name = "TextBoxCampo3"
        Me.TextBoxCampo3.Size = New System.Drawing.Size(271, 20)
        Me.TextBoxCampo3.TabIndex = 9
        '
        'TextBoxCampo2
        '
        Me.TextBoxCampo2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCampo2.Location = New System.Drawing.Point(380, 129)
        Me.TextBoxCampo2.Name = "TextBoxCampo2"
        Me.TextBoxCampo2.Size = New System.Drawing.Size(271, 20)
        Me.TextBoxCampo2.TabIndex = 7
        '
        'TextBoxCampo1
        '
        Me.TextBoxCampo1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCampo1.Location = New System.Drawing.Point(380, 102)
        Me.TextBoxCampo1.Name = "TextBoxCampo1"
        Me.TextBoxCampo1.Size = New System.Drawing.Size(271, 20)
        Me.TextBoxCampo1.TabIndex = 5
        '
        'TextBoxContiene
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxContiene, 2)
        Me.TextBoxContiene.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxContiene.Location = New System.Drawing.Point(103, 23)
        Me.TextBoxContiene.Name = "TextBoxContiene"
        Me.TextBoxContiene.Size = New System.Drawing.Size(548, 20)
        Me.TextBoxContiene.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Testo da ricercare"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 27)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tipo Record"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxTipoRecord
        '
        Me.ComboBoxTipoRecord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxTipoRecord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTipoRecord.FormattingEnabled = True
        Me.ComboBoxTipoRecord.Location = New System.Drawing.Point(103, 75)
        Me.ComboBoxTipoRecord.Name = "ComboBoxTipoRecord"
        Me.ComboBoxTipoRecord.Size = New System.Drawing.Size(271, 21)
        Me.ComboBoxTipoRecord.Sorted = True
        Me.ComboBoxTipoRecord.TabIndex = 3
        '
        'ComboBoxCampo3
        '
        Me.ComboBoxCampo3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxCampo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCampo3.FormattingEnabled = True
        Me.ComboBoxCampo3.Location = New System.Drawing.Point(103, 156)
        Me.ComboBoxCampo3.Name = "ComboBoxCampo3"
        Me.ComboBoxCampo3.Size = New System.Drawing.Size(271, 21)
        Me.ComboBoxCampo3.Sorted = True
        Me.ComboBoxCampo3.TabIndex = 8
        '
        'ComboBoxCampo2
        '
        Me.ComboBoxCampo2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxCampo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCampo2.FormattingEnabled = True
        Me.ComboBoxCampo2.Location = New System.Drawing.Point(103, 129)
        Me.ComboBoxCampo2.Name = "ComboBoxCampo2"
        Me.ComboBoxCampo2.Size = New System.Drawing.Size(271, 21)
        Me.ComboBoxCampo2.Sorted = True
        Me.ComboBoxCampo2.TabIndex = 6
        '
        'ComboBoxCampo1
        '
        Me.ComboBoxCampo1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxCampo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCampo1.FormattingEnabled = True
        Me.ComboBoxCampo1.Location = New System.Drawing.Point(103, 102)
        Me.ComboBoxCampo1.Name = "ComboBoxCampo1"
        Me.ComboBoxCampo1.Size = New System.Drawing.Size(271, 21)
        Me.ComboBoxCampo1.Sorted = True
        Me.ComboBoxCampo1.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 27)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Campo / Valore"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 27)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Campo / Valore"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 27)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Campo / Valore"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.UtFlatButtonEsci, 3, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxCampo1, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxCampo2, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxCampo3, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxTipoRecord, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxContiene, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxCampo1, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxCampo2, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxCampo3, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.UtFlatButtonCerca, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePickerMin, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePickerMax, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMessaggio1, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMessaggio2, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMessaggio3, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.UtFlatButtonApriLog, 0, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckedListBoxAgenzie, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxAgenzie, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.UtFlatButtonAnnulla, 3, 7)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 12
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(754, 451)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'UtFlatButtonEsci
        '
        Me.UtFlatButtonEsci.DefaultBorderSize = 0
        Me.UtFlatButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UtFlatButtonEsci.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.UtFlatButtonEsci.FlatAppearance.BorderSize = 0
        Me.UtFlatButtonEsci.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.UtFlatButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UtFlatButtonEsci.Location = New System.Drawing.Point(654, 411)
        Me.UtFlatButtonEsci.Margin = New System.Windows.Forms.Padding(0)
        Me.UtFlatButtonEsci.Name = "UtFlatButtonEsci"
        Me.UtFlatButtonEsci.Size = New System.Drawing.Size(100, 40)
        Me.UtFlatButtonEsci.TabIndex = 15
        Me.UtFlatButtonEsci.Text = "Esci"
        Me.UtFlatButtonEsci.UseVisualStyleBackColor = True
        '
        'CheckedListBoxAgenzie
        '
        Me.CheckedListBoxAgenzie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxAgenzie.FormattingEnabled = True
        Me.CheckedListBoxAgenzie.IntegralHeight = False
        Me.CheckedListBoxAgenzie.Location = New System.Drawing.Point(657, 23)
        Me.CheckedListBoxAgenzie.Name = "CheckedListBoxAgenzie"
        Me.TableLayoutPanel1.SetRowSpan(Me.CheckedListBoxAgenzie, 6)
        Me.CheckedListBoxAgenzie.Size = New System.Drawing.Size(94, 154)
        Me.CheckedListBoxAgenzie.TabIndex = 12
        '
        'CheckBoxAgenzie
        '
        Me.CheckBoxAgenzie.AutoSize = True
        Me.CheckBoxAgenzie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxAgenzie.Location = New System.Drawing.Point(654, 0)
        Me.CheckBoxAgenzie.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBoxAgenzie.Name = "CheckBoxAgenzie"
        Me.CheckBoxAgenzie.Size = New System.Drawing.Size(100, 20)
        Me.CheckBoxAgenzie.TabIndex = 13
        Me.CheckBoxAgenzie.Text = "Codici agenzia"
        Me.CheckBoxAgenzie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxAgenzie.UseVisualStyleBackColor = True
        '
        'UtFlatButtonAnnulla
        '
        Me.UtFlatButtonAnnulla.DefaultBorderSize = 0
        Me.UtFlatButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UtFlatButtonAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.UtFlatButtonAnnulla.FlatAppearance.BorderSize = 0
        Me.UtFlatButtonAnnulla.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.UtFlatButtonAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UtFlatButtonAnnulla.Location = New System.Drawing.Point(654, 180)
        Me.UtFlatButtonAnnulla.Margin = New System.Windows.Forms.Padding(0)
        Me.UtFlatButtonAnnulla.Name = "UtFlatButtonAnnulla"
        Me.UtFlatButtonAnnulla.Size = New System.Drawing.Size(100, 40)
        Me.UtFlatButtonAnnulla.TabIndex = 14
        Me.UtFlatButtonAnnulla.Text = "Annulla"
        Me.UtFlatButtonAnnulla.UseVisualStyleBackColor = True
        '
        'CercaInFiles
        '
        Me.AcceptButton = Me.UtFlatButtonCerca
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 451)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CercaInFiles"
        Me.Text = "Cerca nei file"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UtFlatButtonApriLog As UtControls.UtFlatButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCampo1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxCampo2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxCampo3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxTipoRecord As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxContiene As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCampo1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCampo2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCampo3 As System.Windows.Forms.TextBox
    Friend WithEvents UtFlatButtonCerca As UtControls.UtFlatButton
    Friend WithEvents DateTimePickerMin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerMax As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblMessaggio1 As System.Windows.Forms.Label
    Friend WithEvents lblMessaggio2 As System.Windows.Forms.Label
    Friend WithEvents lblMessaggio3 As System.Windows.Forms.Label
    Friend WithEvents CheckedListBoxAgenzie As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckBoxAgenzie As System.Windows.Forms.CheckBox
    Friend WithEvents UtFlatButtonAnnulla As UtControls.UtFlatButton
    Friend WithEvents UtFlatButtonEsci As UtControls.UtFlatButton
End Class
