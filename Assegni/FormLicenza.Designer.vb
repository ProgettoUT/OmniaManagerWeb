<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLicenza
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RadioButtonFino20 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonOltre20 = New System.Windows.Forms.RadioButton()
        Me.LabelCodiceAgenzia = New System.Windows.Forms.Label()
        Me.LabelUtente = New System.Windows.Forms.Label()
        Me.TextBoxRagioneSociale = New System.Windows.Forms.TextBox()
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.LabelDesk = New System.Windows.Forms.Label()
        Me.ButtonInviaRichiesta = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.RadioButtonFino20, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.RadioButtonOltre20, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelCodiceAgenzia, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelUtente, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxRagioneSociale, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxEmail, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelDesk, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonInviaRichiesta, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnnulla, 2, 6)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(556, 248)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codice agenzia"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Utente"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 30)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tipologia"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 30)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Ragione sociale"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 30)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "E-mail agenzia"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RadioButtonFino20
        '
        Me.RadioButtonFino20.AutoSize = True
        Me.RadioButtonFino20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonFino20.Location = New System.Drawing.Point(114, 111)
        Me.RadioButtonFino20.Name = "RadioButtonFino20"
        Me.RadioButtonFino20.Size = New System.Drawing.Size(216, 24)
        Me.RadioButtonFino20.TabIndex = 5
        Me.RadioButtonFino20.TabStop = True
        Me.RadioButtonFino20.Text = "Agenzia fino a 10 postazioni"
        Me.RadioButtonFino20.UseVisualStyleBackColor = True
        '
        'RadioButtonOltre20
        '
        Me.RadioButtonOltre20.AutoSize = True
        Me.RadioButtonOltre20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonOltre20.Location = New System.Drawing.Point(336, 111)
        Me.RadioButtonOltre20.Name = "RadioButtonOltre20"
        Me.RadioButtonOltre20.Size = New System.Drawing.Size(217, 24)
        Me.RadioButtonOltre20.TabIndex = 6
        Me.RadioButtonOltre20.TabStop = True
        Me.RadioButtonOltre20.Text = "Agenzia con più di 10 postazioni"
        Me.RadioButtonOltre20.UseVisualStyleBackColor = True
        '
        'LabelCodiceAgenzia
        '
        Me.LabelCodiceAgenzia.AutoSize = True
        Me.LabelCodiceAgenzia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCodiceAgenzia.Location = New System.Drawing.Point(114, 48)
        Me.LabelCodiceAgenzia.Name = "LabelCodiceAgenzia"
        Me.LabelCodiceAgenzia.Size = New System.Drawing.Size(216, 30)
        Me.LabelCodiceAgenzia.TabIndex = 7
        Me.LabelCodiceAgenzia.Text = "Label6"
        Me.LabelCodiceAgenzia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelUtente
        '
        Me.LabelUtente.AutoSize = True
        Me.LabelUtente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelUtente.Location = New System.Drawing.Point(114, 78)
        Me.LabelUtente.Name = "LabelUtente"
        Me.LabelUtente.Size = New System.Drawing.Size(216, 30)
        Me.LabelUtente.TabIndex = 8
        Me.LabelUtente.Text = "Label7"
        Me.LabelUtente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBoxRagioneSociale
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxRagioneSociale, 2)
        Me.TextBoxRagioneSociale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxRagioneSociale.Location = New System.Drawing.Point(114, 141)
        Me.TextBoxRagioneSociale.Name = "TextBoxRagioneSociale"
        Me.TextBoxRagioneSociale.Size = New System.Drawing.Size(439, 22)
        Me.TextBoxRagioneSociale.TabIndex = 9
        '
        'TextBoxEmail
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxEmail, 2)
        Me.TextBoxEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxEmail.Location = New System.Drawing.Point(114, 171)
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(439, 22)
        Me.TextBoxEmail.TabIndex = 10
        '
        'LabelDesk
        '
        Me.LabelDesk.AutoSize = True
        Me.LabelDesk.BackColor = System.Drawing.Color.Moccasin
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelDesk, 3)
        Me.LabelDesk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelDesk.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDesk.Location = New System.Drawing.Point(3, 0)
        Me.LabelDesk.Name = "LabelDesk"
        Me.LabelDesk.Size = New System.Drawing.Size(550, 48)
        Me.LabelDesk.TabIndex = 11
        Me.LabelDesk.Text = "Label8"
        Me.LabelDesk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonInviaRichiesta
        '
        Me.ButtonInviaRichiesta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonInviaRichiesta.Location = New System.Drawing.Point(114, 201)
        Me.ButtonInviaRichiesta.Name = "ButtonInviaRichiesta"
        Me.ButtonInviaRichiesta.Size = New System.Drawing.Size(216, 44)
        Me.ButtonInviaRichiesta.TabIndex = 12
        Me.ButtonInviaRichiesta.Text = "Button1"
        Me.ButtonInviaRichiesta.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.Location = New System.Drawing.Point(336, 201)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(217, 44)
        Me.ButtonAnnulla.TabIndex = 13
        Me.ButtonAnnulla.Text = "Button2"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'FormLicenza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Moccasin
        Me.ClientSize = New System.Drawing.Size(556, 248)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormLicenza"
        Me.Text = "FormLicenza"
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
    Friend WithEvents RadioButtonFino20 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonOltre20 As System.Windows.Forms.RadioButton
    Friend WithEvents LabelCodiceAgenzia As System.Windows.Forms.Label
    Friend WithEvents LabelUtente As System.Windows.Forms.Label
    Friend WithEvents TextBoxRagioneSociale As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxEmail As System.Windows.Forms.TextBox
    Friend WithEvents LabelDesk As System.Windows.Forms.Label
    Friend WithEvents ButtonInviaRichiesta As System.Windows.Forms.Button
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
End Class
