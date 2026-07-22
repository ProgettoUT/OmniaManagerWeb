<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGestioneAccount
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.wbCondizioni = New System.Windows.Forms.WebBrowser()
        Me.GroupBoxRicarica = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadioButton1000 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2000 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3000 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4000 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5000 = New System.Windows.Forms.RadioButton()
        Me.RadioButton10000 = New System.Windows.Forms.RadioButton()
        Me.txtCostoUnitario = New System.Windows.Forms.TextBox()
        Me.txtCostoRicarica = New System.Windows.Forms.TextBox()
        Me.LabelMessaggio = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnRicarica = New System.Windows.Forms.Button()
        Me.btnAperturaAccount = New System.Windows.Forms.Button()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.LabelCredito = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBoxRicarica.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.73781!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.26219!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBoxRicarica, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAperturaAccount, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEsci, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelCredito, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.19797!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.58376!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.49746!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.72081!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(784, 437)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.wbCondizioni)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.TableLayoutPanel1.SetRowSpan(Me.GroupBox1, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(470, 374)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Condizioni della fornitura"
        '
        'wbCondizioni
        '
        Me.wbCondizioni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbCondizioni.Location = New System.Drawing.Point(3, 18)
        Me.wbCondizioni.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbCondizioni.Name = "wbCondizioni"
        Me.wbCondizioni.Size = New System.Drawing.Size(464, 353)
        Me.wbCondizioni.TabIndex = 0
        '
        'GroupBoxRicarica
        '
        Me.GroupBoxRicarica.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBoxRicarica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxRicarica.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxRicarica.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBoxRicarica.Location = New System.Drawing.Point(479, 60)
        Me.GroupBoxRicarica.Name = "GroupBoxRicarica"
        Me.GroupBoxRicarica.Size = New System.Drawing.Size(302, 236)
        Me.GroupBoxRicarica.TabIndex = 3
        Me.GroupBoxRicarica.TabStop = False
        Me.GroupBoxRicarica.Text = "Ricarica"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.31984!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.68016!))
        Me.TableLayoutPanel2.Controls.Add(Me.RadioButton1000, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.RadioButton2000, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.RadioButton3000, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.RadioButton4000, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.RadioButton5000, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.RadioButton10000, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.txtCostoUnitario, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtCostoRicarica, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelMessaggio, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btnRicarica, 1, 4)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 7
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.10959!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.1096!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.1096!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.1096!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.1096!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.1096!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.34242!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(296, 215)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'RadioButton1000
        '
        Me.RadioButton1000.AutoSize = True
        Me.RadioButton1000.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton1000.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButton1000.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButton1000.Location = New System.Drawing.Point(3, 3)
        Me.RadioButton1000.Name = "RadioButton1000"
        Me.RadioButton1000.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.RadioButton1000.Size = New System.Drawing.Size(122, 22)
        Me.RadioButton1000.TabIndex = 0
        Me.RadioButton1000.TabStop = True
        Me.RadioButton1000.Text = "1.000 SMS"
        Me.RadioButton1000.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton1000.UseVisualStyleBackColor = False
        '
        'RadioButton2000
        '
        Me.RadioButton2000.AutoSize = True
        Me.RadioButton2000.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButton2000.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButton2000.Location = New System.Drawing.Point(3, 31)
        Me.RadioButton2000.Name = "RadioButton2000"
        Me.RadioButton2000.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.RadioButton2000.Size = New System.Drawing.Size(122, 22)
        Me.RadioButton2000.TabIndex = 1
        Me.RadioButton2000.TabStop = True
        Me.RadioButton2000.Text = "2.000 SMS"
        Me.RadioButton2000.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton2000.UseVisualStyleBackColor = True
        '
        'RadioButton3000
        '
        Me.RadioButton3000.AutoSize = True
        Me.RadioButton3000.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButton3000.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButton3000.Location = New System.Drawing.Point(3, 59)
        Me.RadioButton3000.Name = "RadioButton3000"
        Me.RadioButton3000.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.RadioButton3000.Size = New System.Drawing.Size(122, 22)
        Me.RadioButton3000.TabIndex = 2
        Me.RadioButton3000.TabStop = True
        Me.RadioButton3000.Text = "3.000 SMS"
        Me.RadioButton3000.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton3000.UseVisualStyleBackColor = True
        '
        'RadioButton4000
        '
        Me.RadioButton4000.AutoSize = True
        Me.RadioButton4000.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButton4000.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButton4000.Location = New System.Drawing.Point(3, 87)
        Me.RadioButton4000.Name = "RadioButton4000"
        Me.RadioButton4000.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.RadioButton4000.Size = New System.Drawing.Size(122, 22)
        Me.RadioButton4000.TabIndex = 3
        Me.RadioButton4000.TabStop = True
        Me.RadioButton4000.Text = "4.000 SMS"
        Me.RadioButton4000.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton4000.UseVisualStyleBackColor = True
        '
        'RadioButton5000
        '
        Me.RadioButton5000.AutoSize = True
        Me.RadioButton5000.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButton5000.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButton5000.Location = New System.Drawing.Point(3, 115)
        Me.RadioButton5000.Name = "RadioButton5000"
        Me.RadioButton5000.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.RadioButton5000.Size = New System.Drawing.Size(122, 22)
        Me.RadioButton5000.TabIndex = 4
        Me.RadioButton5000.TabStop = True
        Me.RadioButton5000.Text = "5.000 SMS"
        Me.RadioButton5000.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton5000.UseVisualStyleBackColor = True
        '
        'RadioButton10000
        '
        Me.RadioButton10000.AutoSize = True
        Me.RadioButton10000.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButton10000.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButton10000.Location = New System.Drawing.Point(3, 143)
        Me.RadioButton10000.Name = "RadioButton10000"
        Me.RadioButton10000.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.RadioButton10000.Size = New System.Drawing.Size(122, 22)
        Me.RadioButton10000.TabIndex = 5
        Me.RadioButton10000.TabStop = True
        Me.RadioButton10000.Text = "10.000 SMS"
        Me.RadioButton10000.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton10000.UseVisualStyleBackColor = True
        '
        'txtCostoUnitario
        '
        Me.txtCostoUnitario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCostoUnitario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCostoUnitario.Location = New System.Drawing.Point(131, 31)
        Me.txtCostoUnitario.Name = "txtCostoUnitario"
        Me.txtCostoUnitario.Size = New System.Drawing.Size(162, 22)
        Me.txtCostoUnitario.TabIndex = 6
        Me.txtCostoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCostoRicarica
        '
        Me.txtCostoRicarica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCostoRicarica.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCostoRicarica.Location = New System.Drawing.Point(131, 87)
        Me.txtCostoRicarica.Name = "txtCostoRicarica"
        Me.txtCostoRicarica.Size = New System.Drawing.Size(162, 22)
        Me.txtCostoRicarica.TabIndex = 7
        Me.txtCostoRicarica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelMessaggio
        '
        Me.LabelMessaggio.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.LabelMessaggio, 2)
        Me.LabelMessaggio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMessaggio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMessaggio.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelMessaggio.Location = New System.Drawing.Point(3, 168)
        Me.LabelMessaggio.Name = "LabelMessaggio"
        Me.LabelMessaggio.Size = New System.Drawing.Size(290, 47)
        Me.LabelMessaggio.TabIndex = 8
        Me.LabelMessaggio.Text = "Label2"
        Me.LabelMessaggio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(131, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 28)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Costo unitario sms"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(131, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(162, 28)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Costo totale della ricarica"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnRicarica
        '
        Me.btnRicarica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRicarica.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnRicarica.Location = New System.Drawing.Point(131, 115)
        Me.btnRicarica.Name = "btnRicarica"
        Me.TableLayoutPanel2.SetRowSpan(Me.btnRicarica, 2)
        Me.btnRicarica.Size = New System.Drawing.Size(162, 50)
        Me.btnRicarica.TabIndex = 11
        Me.btnRicarica.Text = "Effettua ricarica"
        Me.btnRicarica.UseVisualStyleBackColor = True
        '
        'btnAperturaAccount
        '
        Me.btnAperturaAccount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAperturaAccount.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAperturaAccount.Location = New System.Drawing.Point(479, 302)
        Me.btnAperturaAccount.Name = "btnAperturaAccount"
        Me.btnAperturaAccount.Size = New System.Drawing.Size(302, 66)
        Me.btnAperturaAccount.TabIndex = 4
        Me.btnAperturaAccount.Text = "Button1"
        Me.btnAperturaAccount.UseVisualStyleBackColor = True
        '
        'btnEsci
        '
        Me.btnEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsci.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEsci.Location = New System.Drawing.Point(479, 374)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(302, 60)
        Me.btnEsci.TabIndex = 5
        Me.btnEsci.Text = "Button2"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'LabelCredito
        '
        Me.LabelCredito.BackColor = System.Drawing.Color.LightSeaGreen
        Me.LabelCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelCredito, 2)
        Me.LabelCredito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelCredito.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCredito.ForeColor = System.Drawing.Color.White
        Me.LabelCredito.Location = New System.Drawing.Point(3, 0)
        Me.LabelCredito.Name = "LabelCredito"
        Me.LabelCredito.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.LabelCredito.Size = New System.Drawing.Size(778, 57)
        Me.LabelCredito.TabIndex = 2
        Me.LabelCredito.Text = "Label1"
        Me.LabelCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormGestioneAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 440)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormGestioneAccount"
        Me.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Text = "FormGestioneAccount"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBoxRicarica.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents wbCondizioni As System.Windows.Forms.WebBrowser
    Friend WithEvents LabelCredito As System.Windows.Forms.Label
    Friend WithEvents GroupBoxRicarica As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RadioButton1000 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2000 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3000 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4000 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5000 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton10000 As System.Windows.Forms.RadioButton
    Friend WithEvents txtCostoUnitario As System.Windows.Forms.TextBox
    Friend WithEvents txtCostoRicarica As System.Windows.Forms.TextBox
    Friend WithEvents LabelMessaggio As System.Windows.Forms.Label
    Friend WithEvents btnAperturaAccount As System.Windows.Forms.Button
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnRicarica As System.Windows.Forms.Button
End Class
