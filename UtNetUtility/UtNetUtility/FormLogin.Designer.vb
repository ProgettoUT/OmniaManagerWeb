<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogin
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
        Me.btnAnnulla = New System.Windows.Forms.Button()
        Me.btnVediPw = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.txtPw = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelDominio = New System.Windows.Forms.Label()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAnnulla
        '
        Me.btnAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnAnnulla.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnulla.Location = New System.Drawing.Point(232, 132)
        Me.btnAnnulla.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAnnulla.Name = "btnAnnulla"
        Me.btnAnnulla.Size = New System.Drawing.Size(98, 21)
        Me.btnAnnulla.TabIndex = 12
        Me.btnAnnulla.Text = "Annulla"
        Me.btnAnnulla.UseVisualStyleBackColor = True
        '
        'btnVediPw
        '
        Me.btnVediPw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVediPw.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnVediPw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVediPw.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVediPw.Location = New System.Drawing.Point(199, 132)
        Me.btnVediPw.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVediPw.Name = "btnVediPw"
        Me.btnVediPw.Size = New System.Drawing.Size(31, 21)
        Me.btnVediPw.TabIndex = 15
        Me.btnVediPw.TabStop = False
        Me.btnVediPw.Text = "A"
        Me.btnVediPw.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 23)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Password"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 23)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Utente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOk
        '
        Me.btnOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Location = New System.Drawing.Point(232, 86)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(1)
        Me.btnOk.Name = "btnOk"
        Me.TableLayoutPanel1.SetRowSpan(Me.btnOk, 2)
        Me.btnOk.Size = New System.Drawing.Size(98, 44)
        Me.btnOk.TabIndex = 11
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'txtPw
        '
        Me.txtPw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPw.Location = New System.Drawing.Point(67, 132)
        Me.txtPw.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPw.Multiline = True
        Me.txtPw.Name = "txtPw"
        Me.txtPw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPw.Size = New System.Drawing.Size(130, 21)
        Me.txtPw.TabIndex = 10
        '
        'txtUser
        '
        Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtUser, 2)
        Me.txtUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUser.Location = New System.Drawing.Point(67, 109)
        Me.txtUser.Margin = New System.Windows.Forms.Padding(1)
        Me.txtUser.Multiline = True
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(163, 21)
        Me.txtUser.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 23)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Dominio"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAnnulla, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnOk, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPw, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnVediPw, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUser, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelDominio, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelInfo, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(331, 154)
        Me.TableLayoutPanel1.TabIndex = 17
        '
        'LabelDominio
        '
        Me.LabelDominio.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelDominio, 2)
        Me.LabelDominio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelDominio.ForeColor = System.Drawing.Color.DimGray
        Me.LabelDominio.Location = New System.Drawing.Point(69, 85)
        Me.LabelDominio.Name = "LabelDominio"
        Me.LabelDominio.Size = New System.Drawing.Size(159, 23)
        Me.LabelDominio.TabIndex = 17
        Me.LabelDominio.Text = "uniage"
        Me.LabelDominio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelInfo, 3)
        Me.LabelInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfo.Location = New System.Drawing.Point(69, 0)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(259, 85)
        Me.LabelInfo.TabIndex = 18
        Me.LabelInfo.Text = "Label4"
        Me.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 154)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FormLogin"
        Me.Text = "Login"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAnnulla As System.Windows.Forms.Button
    Friend WithEvents btnVediPw As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents txtPw As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LabelDominio As System.Windows.Forms.Label
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
End Class
