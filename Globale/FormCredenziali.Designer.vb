<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCredenziali
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.ButtonVediPw = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.TextBoxPw = New System.Windows.Forms.TextBox()
        Me.TextBoxUser = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LabelStato = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LabelCapsLock = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelIcona = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBoxSalvaPw = New System.Windows.Forms.CheckBox()
        Me.dtpScadenzaPw = New System.Windows.Forms.DateTimePicker()
        Me.StatusStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonAnnulla.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnnulla.Location = New System.Drawing.Point(244, 128)
        Me.ButtonAnnulla.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(80, 21)
        Me.ButtonAnnulla.TabIndex = 5
        Me.ButtonAnnulla.Text = "Annulla"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'ButtonVediPw
        '
        Me.ButtonVediPw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonVediPw.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonVediPw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonVediPw.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonVediPw.Location = New System.Drawing.Point(204, 105)
        Me.ButtonVediPw.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonVediPw.Name = "ButtonVediPw"
        Me.ButtonVediPw.Size = New System.Drawing.Size(38, 21)
        Me.ButtonVediPw.TabIndex = 15
        Me.ButtonVediPw.TabStop = False
        Me.ButtonVediPw.Text = "A"
        Me.ButtonVediPw.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Password"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Utente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonOk
        '
        Me.ButtonOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOk.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOk.Location = New System.Drawing.Point(244, 82)
        Me.ButtonOk.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonOk.Name = "ButtonOk"
        Me.TableLayoutPanel1.SetRowSpan(Me.ButtonOk, 2)
        Me.ButtonOk.Size = New System.Drawing.Size(80, 44)
        Me.ButtonOk.TabIndex = 4
        Me.ButtonOk.Text = "Ok"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'TextBoxPw
        '
        Me.TextBoxPw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxPw.Location = New System.Drawing.Point(81, 105)
        Me.TextBoxPw.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxPw.Multiline = True
        Me.TextBoxPw.Name = "TextBoxPw"
        Me.TextBoxPw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPw.Size = New System.Drawing.Size(121, 21)
        Me.TextBoxPw.TabIndex = 1
        '
        'TextBoxUser
        '
        Me.TextBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxUser, 2)
        Me.TextBoxUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxUser.Location = New System.Drawing.Point(81, 82)
        Me.TextBoxUser.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxUser.Multiline = True
        Me.TextBoxUser.Name = "TextBoxUser"
        Me.TextBoxUser.Size = New System.Drawing.Size(161, 21)
        Me.TextBoxUser.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelStato, Me.LabelCapsLock})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 185)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(325, 22)
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LabelStato
        '
        Me.LabelStato.Name = "LabelStato"
        Me.LabelStato.Size = New System.Drawing.Size(22, 17)
        Me.LabelStato.Text = "xxx"
        '
        'LabelCapsLock
        '
        Me.LabelCapsLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LabelCapsLock.Name = "LabelCapsLock"
        Me.LabelCapsLock.Size = New System.Drawing.Size(56, 17)
        Me.LabelCapsLock.Text = "caps lock"
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelInfo, 3)
        Me.LabelInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfo.Location = New System.Drawing.Point(83, 0)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(239, 81)
        Me.LabelInfo.TabIndex = 8
        Me.LabelInfo.Text = "Label3"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelInfo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxUser, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnnulla, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxPw, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonOk, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonVediPw, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelIcona, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSalvaPw, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpScadenzaPw, 1, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(325, 182)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'LabelIcona
        '
        Me.LabelIcona.AutoSize = True
        Me.LabelIcona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelIcona.Location = New System.Drawing.Point(3, 0)
        Me.LabelIcona.Name = "LabelIcona"
        Me.LabelIcona.Size = New System.Drawing.Size(74, 81)
        Me.LabelIcona.TabIndex = 9
        Me.LabelIcona.Text = "Label3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 23)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Scadenza"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxSalvaPw
        '
        Me.CheckBoxSalvaPw.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.CheckBoxSalvaPw, 2)
        Me.CheckBoxSalvaPw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxSalvaPw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxSalvaPw.Location = New System.Drawing.Point(83, 153)
        Me.CheckBoxSalvaPw.Name = "CheckBoxSalvaPw"
        Me.CheckBoxSalvaPw.Size = New System.Drawing.Size(157, 17)
        Me.CheckBoxSalvaPw.TabIndex = 3
        Me.CheckBoxSalvaPw.Text = "Salva le credenziali"
        Me.CheckBoxSalvaPw.UseVisualStyleBackColor = True
        '
        'dtpScadenzaPw
        '
        Me.dtpScadenzaPw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpScadenzaPw.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpScadenzaPw.Location = New System.Drawing.Point(81, 128)
        Me.dtpScadenzaPw.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpScadenzaPw.Name = "dtpScadenzaPw"
        Me.dtpScadenzaPw.Size = New System.Drawing.Size(121, 20)
        Me.dtpScadenzaPw.TabIndex = 2
        '
        'FormCredenziali
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(331, 210)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FormCredenziali"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
    Friend WithEvents ButtonVediPw As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents TextBoxPw As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxUser As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents LabelStato As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelIcona As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxSalvaPw As System.Windows.Forms.CheckBox
    Friend WithEvents dtpScadenzaPw As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelCapsLock As System.Windows.Forms.ToolStripStatusLabel
End Class
