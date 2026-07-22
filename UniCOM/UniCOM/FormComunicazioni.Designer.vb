<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormComunicazioni
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
        Me.ButtonApri = New System.Windows.Forms.Button()
        Me.ButtonInvia = New System.Windows.Forms.Button()
        Me.TextBoxMittente = New System.Windows.Forms.TextBox()
        Me.LabelMittente = New System.Windows.Forms.Label()
        Me.CheckBoxAnteprima = New System.Windows.Forms.CheckBox()
        Me.LabelNumeroSms = New System.Windows.Forms.Label()
        Me.CheckBoxConcatenati = New System.Windows.Forms.CheckBox()
        Me.LabelCaratteriResidui = New System.Windows.Forms.Label()
        Me.LabelCaratteriUtilizzati = New System.Windows.Forms.Label()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.TabPageSms = New System.Windows.Forms.TabPage()
        Me.LabelNumeroDestinatari = New System.Windows.Forms.Label()
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
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSalva, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxMessaggio, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 8, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxCampi, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonInserisciCampo, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonApri, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonInvia, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxMittente, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelMittente, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxAnteprima, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelNumeroSms, 8, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxConcatenati, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelCaratteriResidui, 7, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelCaratteriUtilizzati, 6, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelNumeroDestinatari, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(720, 329)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'ButtonSalva
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonSalva, 2)
        Me.ButtonSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSalva.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSalva.Location = New System.Drawing.Point(158, 279)
        Me.ButtonSalva.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonSalva.Name = "ButtonSalva"
        Me.ButtonSalva.Size = New System.Drawing.Size(158, 50)
        Me.ButtonSalva.TabIndex = 7
        Me.ButtonSalva.Text = "Button2"
        Me.ButtonSalva.UseVisualStyleBackColor = True
        '
        'TextBoxMessaggio
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxMessaggio, 9)
        Me.TextBoxMessaggio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxMessaggio.Location = New System.Drawing.Point(3, 55)
        Me.TextBoxMessaggio.Multiline = True
        Me.TextBoxMessaggio.Name = "TextBoxMessaggio"
        Me.TextBoxMessaggio.Size = New System.Drawing.Size(714, 196)
        Me.TextBoxMessaggio.TabIndex = 4
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsci.Location = New System.Drawing.Point(632, 279)
        Me.ButtonEsci.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(88, 50)
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
        Me.ComboBoxCampi.Location = New System.Drawing.Point(3, 3)
        Me.ComboBoxCampi.Name = "ComboBoxCampi"
        Me.ComboBoxCampi.Size = New System.Drawing.Size(152, 21)
        Me.ComboBoxCampi.TabIndex = 0
        '
        'ButtonInserisciCampo
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonInserisciCampo, 2)
        Me.ButtonInserisciCampo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonInserisciCampo.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonInserisciCampo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonInserisciCampo.Location = New System.Drawing.Point(158, 0)
        Me.ButtonInserisciCampo.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonInserisciCampo.Name = "ButtonInserisciCampo"
        Me.ButtonInserisciCampo.Size = New System.Drawing.Size(158, 27)
        Me.ButtonInserisciCampo.TabIndex = 1
        Me.ButtonInserisciCampo.Text = "Inserisci campo"
        Me.ButtonInserisciCampo.UseVisualStyleBackColor = True
        '
        'ButtonApri
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonApri, 2)
        Me.ButtonApri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonApri.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonApri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonApri.Location = New System.Drawing.Point(0, 279)
        Me.ButtonApri.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonApri.Name = "ButtonApri"
        Me.ButtonApri.Size = New System.Drawing.Size(158, 50)
        Me.ButtonApri.TabIndex = 6
        Me.ButtonApri.Text = "Button1"
        Me.ButtonApri.UseVisualStyleBackColor = True
        '
        'ButtonInvia
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonInvia, 4)
        Me.ButtonInvia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonInvia.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonInvia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonInvia.Location = New System.Drawing.Point(316, 279)
        Me.ButtonInvia.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonInvia.Name = "ButtonInvia"
        Me.ButtonInvia.Size = New System.Drawing.Size(316, 50)
        Me.ButtonInvia.TabIndex = 8
        Me.ButtonInvia.Text = "Button4"
        Me.ButtonInvia.UseVisualStyleBackColor = True
        '
        'TextBoxMittente
        '
        Me.TextBoxMittente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxMittente, 2)
        Me.TextBoxMittente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxMittente.Location = New System.Drawing.Point(556, 3)
        Me.TextBoxMittente.Multiline = True
        Me.TextBoxMittente.Name = "TextBoxMittente"
        Me.TextBoxMittente.Size = New System.Drawing.Size(161, 21)
        Me.TextBoxMittente.TabIndex = 3
        '
        'LabelMittente
        '
        Me.LabelMittente.AutoSize = True
        Me.LabelMittente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMittente.Location = New System.Drawing.Point(477, 0)
        Me.LabelMittente.Name = "LabelMittente"
        Me.LabelMittente.Size = New System.Drawing.Size(73, 27)
        Me.LabelMittente.TabIndex = 12
        Me.LabelMittente.Text = "Mittente"
        Me.LabelMittente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxAnteprima
        '
        Me.CheckBoxAnteprima.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxAnteprima.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.CheckBoxAnteprima, 2)
        Me.CheckBoxAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxAnteprima.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.CheckBoxAnteprima.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxAnteprima.Location = New System.Drawing.Point(316, 0)
        Me.CheckBoxAnteprima.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBoxAnteprima.Name = "CheckBoxAnteprima"
        Me.CheckBoxAnteprima.Size = New System.Drawing.Size(158, 27)
        Me.CheckBoxAnteprima.TabIndex = 2
        Me.CheckBoxAnteprima.Text = "Anteprima"
        Me.CheckBoxAnteprima.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxAnteprima.UseVisualStyleBackColor = True
        '
        'LabelNumeroSms
        '
        Me.LabelNumeroSms.AutoSize = True
        Me.LabelNumeroSms.BackColor = System.Drawing.Color.Gold
        Me.LabelNumeroSms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelNumeroSms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNumeroSms.Location = New System.Drawing.Point(635, 254)
        Me.LabelNumeroSms.Name = "LabelNumeroSms"
        Me.LabelNumeroSms.Size = New System.Drawing.Size(82, 25)
        Me.LabelNumeroSms.TabIndex = 15
        Me.LabelNumeroSms.Text = "Label3"
        Me.LabelNumeroSms.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBoxConcatenati
        '
        Me.CheckBoxConcatenati.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.CheckBoxConcatenati, 4)
        Me.CheckBoxConcatenati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxConcatenati.Location = New System.Drawing.Point(3, 257)
        Me.CheckBoxConcatenati.Name = "CheckBoxConcatenati"
        Me.CheckBoxConcatenati.Size = New System.Drawing.Size(310, 19)
        Me.CheckBoxConcatenati.TabIndex = 5
        Me.CheckBoxConcatenati.Text = "Usa SMS concatenati oltre i 160 caratteri"
        Me.CheckBoxConcatenati.UseVisualStyleBackColor = True
        '
        'LabelCaratteriResidui
        '
        Me.LabelCaratteriResidui.AutoSize = True
        Me.LabelCaratteriResidui.BackColor = System.Drawing.Color.PaleGreen
        Me.LabelCaratteriResidui.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelCaratteriResidui.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCaratteriResidui.Location = New System.Drawing.Point(556, 254)
        Me.LabelCaratteriResidui.Name = "LabelCaratteriResidui"
        Me.LabelCaratteriResidui.Size = New System.Drawing.Size(73, 25)
        Me.LabelCaratteriResidui.TabIndex = 14
        Me.LabelCaratteriResidui.Text = "Label2"
        Me.LabelCaratteriResidui.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelCaratteriUtilizzati
        '
        Me.LabelCaratteriUtilizzati.AutoSize = True
        Me.LabelCaratteriUtilizzati.BackColor = System.Drawing.Color.Moccasin
        Me.LabelCaratteriUtilizzati.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelCaratteriUtilizzati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCaratteriUtilizzati.Location = New System.Drawing.Point(477, 254)
        Me.LabelCaratteriUtilizzati.Name = "LabelCaratteriUtilizzati"
        Me.LabelCaratteriUtilizzati.Size = New System.Drawing.Size(73, 25)
        Me.LabelCaratteriUtilizzati.TabIndex = 13
        Me.LabelCaratteriUtilizzati.Text = "Label1"
        Me.LabelCaratteriUtilizzati.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.TabPageSms)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(734, 361)
        Me.TabMain.TabIndex = 11
        Me.TabMain.TabStop = False
        '
        'TabPageSms
        '
        Me.TabPageSms.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPageSms.Location = New System.Drawing.Point(4, 22)
        Me.TabPageSms.Name = "TabPageSms"
        Me.TabPageSms.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageSms.Size = New System.Drawing.Size(726, 335)
        Me.TabPageSms.TabIndex = 0
        Me.TabPageSms.Text = "Invia sms"
        Me.TabPageSms.UseVisualStyleBackColor = True
        '
        'LabelNumeroDestinatari
        '
        Me.LabelNumeroDestinatari.AutoSize = True
        Me.LabelNumeroDestinatari.BackColor = System.Drawing.Color.Gainsboro
        Me.LabelNumeroDestinatari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelNumeroDestinatari, 9)
        Me.LabelNumeroDestinatari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNumeroDestinatari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelNumeroDestinatari.Location = New System.Drawing.Point(3, 30)
        Me.LabelNumeroDestinatari.Margin = New System.Windows.Forms.Padding(3)
        Me.LabelNumeroDestinatari.Name = "LabelNumeroDestinatari"
        Me.LabelNumeroDestinatari.Size = New System.Drawing.Size(714, 19)
        Me.LabelNumeroDestinatari.TabIndex = 16
        Me.LabelNumeroDestinatari.Text = "..."
        Me.LabelNumeroDestinatari.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormComunicazioni
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 361)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "FormComunicazioni"
        Me.Text = "FormSms"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.TabPageSms.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPageSms As System.Windows.Forms.TabPage
    Friend WithEvents ButtonApri As System.Windows.Forms.Button
    Friend WithEvents ButtonSalva As System.Windows.Forms.Button
    Friend WithEvents ButtonInvia As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents ButtonInserisciCampo As System.Windows.Forms.Button
    Friend WithEvents TextBoxMessaggio As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxMittente As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxCampi As System.Windows.Forms.ComboBox
    Friend WithEvents LabelMittente As System.Windows.Forms.Label
    Friend WithEvents CheckBoxAnteprima As System.Windows.Forms.CheckBox
    Friend WithEvents LabelNumeroSms As System.Windows.Forms.Label
    Friend WithEvents CheckBoxConcatenati As System.Windows.Forms.CheckBox
    Friend WithEvents LabelCaratteriResidui As System.Windows.Forms.Label
    Friend WithEvents LabelCaratteriUtilizzati As System.Windows.Forms.Label
    Friend WithEvents LabelNumeroDestinatari As System.Windows.Forms.Label
End Class
