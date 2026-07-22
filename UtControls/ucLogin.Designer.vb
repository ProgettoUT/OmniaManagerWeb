<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucLogin
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxUser = New System.Windows.Forms.TextBox()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.TextBoxPw = New System.Windows.Forms.TextBox()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.LabelIcona = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBoxSalvaPw = New System.Windows.Forms.CheckBox()
        Me.dtpScadenzaPw = New System.Windows.Forms.DateTimePicker()
        Me.CheckBoxPW = New System.Windows.Forms.CheckBox()
        Me.ButtonCambiaPassword = New System.Windows.Forms.Button()
        Me.CheckBoxMFA = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 4
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlpMain.Controls.Add(Me.Label1, 0, 2)
        Me.tlpMain.Controls.Add(Me.LabelInfo, 1, 0)
        Me.tlpMain.Controls.Add(Me.Label2, 0, 3)
        Me.tlpMain.Controls.Add(Me.TextBoxUser, 1, 2)
        Me.tlpMain.Controls.Add(Me.ButtonAnnulla, 3, 4)
        Me.tlpMain.Controls.Add(Me.TextBoxPw, 1, 3)
        Me.tlpMain.Controls.Add(Me.ButtonOk, 3, 2)
        Me.tlpMain.Controls.Add(Me.LabelIcona, 0, 0)
        Me.tlpMain.Controls.Add(Me.Label3, 0, 4)
        Me.tlpMain.Controls.Add(Me.CheckBoxSalvaPw, 1, 5)
        Me.tlpMain.Controls.Add(Me.dtpScadenzaPw, 1, 4)
        Me.tlpMain.Controls.Add(Me.CheckBoxPW, 2, 3)
        Me.tlpMain.Controls.Add(Me.ButtonCambiaPassword, 1, 6)
        Me.tlpMain.Controls.Add(Me.CheckBoxMFA, 1, 1)
        Me.tlpMain.Controls.Add(Me.Label4, 0, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 7
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.Size = New System.Drawing.Size(383, 237)
        Me.tlpMain.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Utente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.tlpMain.SetColumnSpan(Me.LabelInfo, 3)
        Me.LabelInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfo.Location = New System.Drawing.Point(83, 0)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(297, 94)
        Me.LabelInfo.TabIndex = 8
        Me.LabelInfo.Text = "Label3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Password"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxUser
        '
        Me.TextBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpMain.SetColumnSpan(Me.TextBoxUser, 2)
        Me.TextBoxUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxUser.Location = New System.Drawing.Point(81, 118)
        Me.TextBoxUser.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxUser.Multiline = True
        Me.TextBoxUser.Name = "TextBoxUser"
        Me.TextBoxUser.Size = New System.Drawing.Size(195, 21)
        Me.TextBoxUser.TabIndex = 0
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonAnnulla.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnnulla.Location = New System.Drawing.Point(278, 164)
        Me.ButtonAnnulla.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(104, 21)
        Me.ButtonAnnulla.TabIndex = 5
        Me.ButtonAnnulla.Text = "Annulla"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'TextBoxPw
        '
        Me.TextBoxPw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxPw.Location = New System.Drawing.Point(81, 141)
        Me.TextBoxPw.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxPw.Multiline = True
        Me.TextBoxPw.Name = "TextBoxPw"
        Me.TextBoxPw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPw.Size = New System.Drawing.Size(155, 21)
        Me.TextBoxPw.TabIndex = 1
        '
        'ButtonOk
        '
        Me.ButtonOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOk.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOk.Location = New System.Drawing.Point(278, 118)
        Me.ButtonOk.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonOk.Name = "ButtonOk"
        Me.tlpMain.SetRowSpan(Me.ButtonOk, 2)
        Me.ButtonOk.Size = New System.Drawing.Size(104, 44)
        Me.ButtonOk.TabIndex = 4
        Me.ButtonOk.Text = "Ok"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'LabelIcona
        '
        Me.LabelIcona.AutoSize = True
        Me.LabelIcona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelIcona.Location = New System.Drawing.Point(3, 0)
        Me.LabelIcona.Name = "LabelIcona"
        Me.LabelIcona.Size = New System.Drawing.Size(74, 94)
        Me.LabelIcona.TabIndex = 9
        Me.LabelIcona.Text = "Label3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 23)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Scadenza"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxSalvaPw
        '
        Me.CheckBoxSalvaPw.AutoSize = True
        Me.tlpMain.SetColumnSpan(Me.CheckBoxSalvaPw, 2)
        Me.CheckBoxSalvaPw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxSalvaPw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxSalvaPw.Location = New System.Drawing.Point(83, 189)
        Me.CheckBoxSalvaPw.Name = "CheckBoxSalvaPw"
        Me.CheckBoxSalvaPw.Size = New System.Drawing.Size(191, 17)
        Me.CheckBoxSalvaPw.TabIndex = 3
        Me.CheckBoxSalvaPw.Text = "Salva le credenziali"
        Me.CheckBoxSalvaPw.UseVisualStyleBackColor = True
        '
        'dtpScadenzaPw
        '
        Me.dtpScadenzaPw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpScadenzaPw.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpScadenzaPw.Location = New System.Drawing.Point(81, 164)
        Me.dtpScadenzaPw.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpScadenzaPw.Name = "dtpScadenzaPw"
        Me.dtpScadenzaPw.Size = New System.Drawing.Size(155, 20)
        Me.dtpScadenzaPw.TabIndex = 2
        '
        'CheckBoxPW
        '
        Me.CheckBoxPW.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxPW.AutoSize = True
        Me.CheckBoxPW.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxPW.Location = New System.Drawing.Point(237, 140)
        Me.CheckBoxPW.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBoxPW.Name = "CheckBoxPW"
        Me.CheckBoxPW.Size = New System.Drawing.Size(40, 23)
        Me.CheckBoxPW.TabIndex = 12
        Me.CheckBoxPW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxPW.UseVisualStyleBackColor = True
        '
        'ButtonCambiaPassword
        '
        Me.ButtonCambiaPassword.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tlpMain.SetColumnSpan(Me.ButtonCambiaPassword, 3)
        Me.ButtonCambiaPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCambiaPassword.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonCambiaPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCambiaPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonCambiaPassword.Location = New System.Drawing.Point(81, 210)
        Me.ButtonCambiaPassword.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonCambiaPassword.Name = "ButtonCambiaPassword"
        Me.ButtonCambiaPassword.Size = New System.Drawing.Size(301, 26)
        Me.ButtonCambiaPassword.TabIndex = 13
        Me.ButtonCambiaPassword.Text = "Cambia password Unipol o Unisalute"
        Me.ButtonCambiaPassword.UseVisualStyleBackColor = False
        '
        'CheckBoxMFA
        '
        Me.CheckBoxMFA.AutoSize = True
        Me.CheckBoxMFA.BackColor = System.Drawing.Color.Gainsboro
        Me.CheckBoxMFA.Checked = True
        Me.CheckBoxMFA.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tlpMain.SetColumnSpan(Me.CheckBoxMFA, 3)
        Me.CheckBoxMFA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxMFA.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CheckBoxMFA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxMFA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBoxMFA.Location = New System.Drawing.Point(80, 97)
        Me.CheckBoxMFA.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.CheckBoxMFA.Name = "CheckBoxMFA"
        Me.CheckBoxMFA.Padding = New System.Windows.Forms.Padding(3, 2, 0, 0)
        Me.CheckBoxMFA.Size = New System.Drawing.Size(303, 17)
        Me.CheckBoxMFA.TabIndex = 14
        Me.CheckBoxMFA.Text = "Multi Factor Authentication"
        Me.CheckBoxMFA.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(3, 97)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "MFA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucLogin"
        Me.Size = New System.Drawing.Size(383, 237)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxUser As System.Windows.Forms.TextBox
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
    Friend WithEvents TextBoxPw As System.Windows.Forms.TextBox
    Public WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents LabelIcona As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxSalvaPw As System.Windows.Forms.CheckBox
    Friend WithEvents dtpScadenzaPw As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBoxPW As Windows.Forms.CheckBox
    Friend WithEvents ButtonCambiaPassword As Windows.Forms.Button
    Friend WithEvents CheckBoxMFA As Windows.Forms.CheckBox
    Friend WithEvents Label4 As Windows.Forms.Label
End Class
