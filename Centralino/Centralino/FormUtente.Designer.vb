<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUtente
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxInterno = New System.Windows.Forms.TextBox()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.TextBoxMacAddress = New System.Windows.Forms.TextBox()
        Me.TextBoxIP = New System.Windows.Forms.TextBox()
        Me.ButtonSalva = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.TextBoxNome = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxUtente = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxInterno, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxPassword, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxMacAddress, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxIP, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSalva, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnnulla, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxNome, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxUtente, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(446, 193)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Utente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(217, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Numero interno"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(217, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Password telefono"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(217, 25)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "MAC address telefono (facoltativo)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(217, 25)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "IP telefono"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxInterno
        '
        Me.TextBoxInterno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxInterno.Location = New System.Drawing.Point(226, 53)
        Me.TextBoxInterno.Name = "TextBoxInterno"
        Me.TextBoxInterno.Size = New System.Drawing.Size(217, 20)
        Me.TextBoxInterno.TabIndex = 2
        Me.TextBoxInterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxPassword.Location = New System.Drawing.Point(226, 78)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.Size = New System.Drawing.Size(217, 20)
        Me.TextBoxPassword.TabIndex = 3
        Me.TextBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxMacAddress
        '
        Me.TextBoxMacAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxMacAddress.Location = New System.Drawing.Point(226, 103)
        Me.TextBoxMacAddress.Name = "TextBoxMacAddress"
        Me.TextBoxMacAddress.Size = New System.Drawing.Size(217, 20)
        Me.TextBoxMacAddress.TabIndex = 4
        Me.TextBoxMacAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxIP
        '
        Me.TextBoxIP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxIP.Location = New System.Drawing.Point(226, 128)
        Me.TextBoxIP.Name = "TextBoxIP"
        Me.TextBoxIP.Size = New System.Drawing.Size(217, 20)
        Me.TextBoxIP.TabIndex = 5
        Me.TextBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonSalva
        '
        Me.ButtonSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSalva.Location = New System.Drawing.Point(226, 153)
        Me.ButtonSalva.Name = "ButtonSalva"
        Me.ButtonSalva.Size = New System.Drawing.Size(217, 37)
        Me.ButtonSalva.TabIndex = 6
        Me.ButtonSalva.Text = "Salva"
        Me.ButtonSalva.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.Location = New System.Drawing.Point(3, 153)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(217, 37)
        Me.ButtonAnnulla.TabIndex = 7
        Me.ButtonAnnulla.Text = "Annulla"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'TextBoxNome
        '
        Me.TextBoxNome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxNome.Location = New System.Drawing.Point(226, 28)
        Me.TextBoxNome.Name = "TextBoxNome"
        Me.TextBoxNome.Size = New System.Drawing.Size(217, 20)
        Me.TextBoxNome.TabIndex = 1
        Me.TextBoxNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(3, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(217, 25)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Nome"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxUtente
        '
        Me.ComboBoxUtente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxUtente.FormattingEnabled = True
        Me.ComboBoxUtente.Location = New System.Drawing.Point(226, 3)
        Me.ComboBoxUtente.Name = "ComboBoxUtente"
        Me.ComboBoxUtente.Size = New System.Drawing.Size(217, 21)
        Me.ComboBoxUtente.TabIndex = 9
        '
        'FormUtente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(446, 193)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormUtente"
        Me.Text = "FormUtente"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxInterno As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxMacAddress As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxIP As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSalva As System.Windows.Forms.Button
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
    Friend WithEvents TextBoxNome As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxUtente As System.Windows.Forms.ComboBox
End Class
