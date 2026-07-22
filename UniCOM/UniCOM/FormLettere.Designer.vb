<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLettere
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
        Me.ButtonSalva = New System.Windows.Forms.Button()
        Me.TextBoxMessaggio = New System.Windows.Forms.TextBox()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.ComboBoxCampi = New System.Windows.Forms.ComboBox()
        Me.ButtonInserisciCampo = New System.Windows.Forms.Button()
        Me.ButtonCreaLettere = New System.Windows.Forms.Button()
        Me.ComboBoxModelli = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonElimina = New System.Windows.Forms.Button()
        Me.ButtonAnteprima = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.TabPageSms = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.TabPageSms.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 9
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSalva, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxMessaggio, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 8, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxCampi, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonInserisciCampo, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCreaLettere, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxModelli, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonElimina, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnteprima, 7, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(921, 480)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'ButtonSalva
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonSalva, 2)
        Me.ButtonSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSalva.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSalva.Location = New System.Drawing.Point(204, 430)
        Me.ButtonSalva.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonSalva.Name = "ButtonSalva"
        Me.ButtonSalva.Size = New System.Drawing.Size(204, 50)
        Me.ButtonSalva.TabIndex = 7
        Me.ButtonSalva.Text = "Button2"
        Me.ButtonSalva.UseVisualStyleBackColor = True
        '
        'TextBoxMessaggio
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxMessaggio, 9)
        Me.TextBoxMessaggio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxMessaggio.Location = New System.Drawing.Point(3, 30)
        Me.TextBoxMessaggio.Multiline = True
        Me.TextBoxMessaggio.Name = "TextBoxMessaggio"
        Me.TextBoxMessaggio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxMessaggio.Size = New System.Drawing.Size(915, 397)
        Me.TextBoxMessaggio.TabIndex = 4
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsci.Location = New System.Drawing.Point(816, 430)
        Me.ButtonEsci.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(105, 50)
        Me.ButtonEsci.TabIndex = 9
        Me.ButtonEsci.Text = "Button5"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'ComboBoxCampi
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ComboBoxCampi, 2)
        Me.ComboBoxCampi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxCampi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxCampi.FormattingEnabled = True
        Me.ComboBoxCampi.Location = New System.Drawing.Point(513, 3)
        Me.ComboBoxCampi.Name = "ComboBoxCampi"
        Me.ComboBoxCampi.Size = New System.Drawing.Size(198, 21)
        Me.ComboBoxCampi.TabIndex = 0
        '
        'ButtonInserisciCampo
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonInserisciCampo, 2)
        Me.ButtonInserisciCampo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonInserisciCampo.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonInserisciCampo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonInserisciCampo.Location = New System.Drawing.Point(306, 0)
        Me.ButtonInserisciCampo.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonInserisciCampo.Name = "ButtonInserisciCampo"
        Me.ButtonInserisciCampo.Size = New System.Drawing.Size(204, 27)
        Me.ButtonInserisciCampo.TabIndex = 1
        Me.ButtonInserisciCampo.Text = "Inserisci campo"
        Me.ButtonInserisciCampo.UseVisualStyleBackColor = True
        '
        'ButtonCreaLettere
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonCreaLettere, 3)
        Me.ButtonCreaLettere.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCreaLettere.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonCreaLettere.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCreaLettere.Location = New System.Drawing.Point(510, 430)
        Me.ButtonCreaLettere.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCreaLettere.Name = "ButtonCreaLettere"
        Me.ButtonCreaLettere.Size = New System.Drawing.Size(306, 50)
        Me.ButtonCreaLettere.TabIndex = 8
        Me.ButtonCreaLettere.Text = "Button4"
        Me.ButtonCreaLettere.UseVisualStyleBackColor = True
        '
        'ComboBoxModelli
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ComboBoxModelli, 2)
        Me.ComboBoxModelli.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxModelli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxModelli.FormattingEnabled = True
        Me.ComboBoxModelli.Location = New System.Drawing.Point(105, 3)
        Me.ComboBoxModelli.Name = "ComboBoxModelli"
        Me.ComboBoxModelli.Size = New System.Drawing.Size(198, 21)
        Me.ComboBoxModelli.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 27)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Modello"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonElimina
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonElimina, 2)
        Me.ButtonElimina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonElimina.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonElimina.Location = New System.Drawing.Point(0, 430)
        Me.ButtonElimina.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonElimina.Name = "ButtonElimina"
        Me.ButtonElimina.Size = New System.Drawing.Size(204, 50)
        Me.ButtonElimina.TabIndex = 18
        Me.ButtonElimina.Text = "Button1"
        Me.ButtonElimina.UseVisualStyleBackColor = True
        '
        'ButtonAnteprima
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonAnteprima, 2)
        Me.ButtonAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnteprima.Location = New System.Drawing.Point(717, 3)
        Me.ButtonAnteprima.Name = "ButtonAnteprima"
        Me.ButtonAnteprima.Size = New System.Drawing.Size(201, 21)
        Me.ButtonAnteprima.TabIndex = 19
        Me.ButtonAnteprima.Text = "Button1"
        Me.ButtonAnteprima.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.TabPageSms)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(935, 512)
        Me.TabMain.TabIndex = 11
        Me.TabMain.TabStop = False
        '
        'TabPageSms
        '
        Me.TabPageSms.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPageSms.Location = New System.Drawing.Point(4, 22)
        Me.TabPageSms.Name = "TabPageSms"
        Me.TabPageSms.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageSms.Size = New System.Drawing.Size(927, 486)
        Me.TabPageSms.TabIndex = 0
        Me.TabPageSms.Text = "Invia lettere"
        Me.TabPageSms.UseVisualStyleBackColor = True
        '
        'FormLettere
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 512)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "FormLettere"
        Me.Text = "FormLettere"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.TabPageSms.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPageSms As System.Windows.Forms.TabPage
    Friend WithEvents ButtonSalva As System.Windows.Forms.Button
    Friend WithEvents ButtonCreaLettere As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents ButtonInserisciCampo As System.Windows.Forms.Button
    Friend WithEvents TextBoxMessaggio As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxCampi As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxModelli As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonElimina As System.Windows.Forms.Button
    Friend WithEvents ButtonAnteprima As System.Windows.Forms.Button
End Class
