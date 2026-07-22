<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImportaSinistri
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
        Me.ListBoxSinistri = New System.Windows.Forms.ListBox()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelStato = New System.Windows.Forms.Label()
        Me.ButtonSeleziona = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.dtpDal = New System.Windows.Forms.DateTimePicker()
        Me.ButtonAggiorna = New System.Windows.Forms.Button()
        Me.ButtonCatturaEvento = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpAl = New System.Windows.Forms.DateTimePicker()
        Me.LabelSinistro = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxUtente = New System.Windows.Forms.TextBox()
        Me.TextBoxPw = New System.Windows.Forms.TextBox()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBoxSinistri
        '
        Me.tlpMain.SetColumnSpan(Me.ListBoxSinistri, 6)
        Me.ListBoxSinistri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxSinistri.FormattingEnabled = True
        Me.ListBoxSinistri.Location = New System.Drawing.Point(3, 53)
        Me.ListBoxSinistri.Name = "ListBoxSinistri"
        Me.ListBoxSinistri.Size = New System.Drawing.Size(578, 240)
        Me.ListBoxSinistri.TabIndex = 0
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 5
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlpMain.Controls.Add(Me.ListBoxSinistri, 0, 2)
        Me.tlpMain.Controls.Add(Me.LabelStato, 0, 3)
        Me.tlpMain.Controls.Add(Me.ButtonSeleziona, 2, 4)
        Me.tlpMain.Controls.Add(Me.ButtonEsci, 0, 4)
        Me.tlpMain.Controls.Add(Me.dtpDal, 1, 1)
        Me.tlpMain.Controls.Add(Me.ButtonAggiorna, 4, 0)
        Me.tlpMain.Controls.Add(Me.ButtonCatturaEvento, 0, 5)
        Me.tlpMain.Controls.Add(Me.Label1, 0, 1)
        Me.tlpMain.Controls.Add(Me.Label2, 2, 1)
        Me.tlpMain.Controls.Add(Me.dtpAl, 3, 1)
        Me.tlpMain.Controls.Add(Me.LabelSinistro, 4, 3)
        Me.tlpMain.Controls.Add(Me.Label3, 0, 0)
        Me.tlpMain.Controls.Add(Me.Label4, 2, 0)
        Me.tlpMain.Controls.Add(Me.TextBoxUtente, 1, 0)
        Me.tlpMain.Controls.Add(Me.TextBoxPw, 3, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 6
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMain.Size = New System.Drawing.Size(584, 411)
        Me.tlpMain.TabIndex = 1
        '
        'LabelStato
        '
        Me.LabelStato.AutoSize = True
        Me.tlpMain.SetColumnSpan(Me.LabelStato, 4)
        Me.LabelStato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelStato.Location = New System.Drawing.Point(3, 296)
        Me.LabelStato.Name = "LabelStato"
        Me.LabelStato.Size = New System.Drawing.Size(408, 25)
        Me.LabelStato.TabIndex = 1
        Me.LabelStato.Text = "Label1"
        '
        'ButtonSeleziona
        '
        Me.tlpMain.SetColumnSpan(Me.ButtonSeleziona, 3)
        Me.ButtonSeleziona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSeleziona.Location = New System.Drawing.Point(210, 324)
        Me.ButtonSeleziona.Name = "ButtonSeleziona"
        Me.ButtonSeleziona.Size = New System.Drawing.Size(371, 44)
        Me.ButtonSeleziona.TabIndex = 2
        Me.ButtonSeleziona.Text = "Button1"
        Me.ButtonSeleziona.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.tlpMain.SetColumnSpan(Me.ButtonEsci, 2)
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.Location = New System.Drawing.Point(3, 324)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(201, 44)
        Me.ButtonEsci.TabIndex = 3
        Me.ButtonEsci.Text = "Button2"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'dtpDal
        '
        Me.dtpDal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDal.Location = New System.Drawing.Point(83, 28)
        Me.dtpDal.Name = "dtpDal"
        Me.dtpDal.Size = New System.Drawing.Size(121, 20)
        Me.dtpDal.TabIndex = 4
        '
        'ButtonAggiorna
        '
        Me.ButtonAggiorna.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiorna.Location = New System.Drawing.Point(417, 3)
        Me.ButtonAggiorna.Name = "ButtonAggiorna"
        Me.tlpMain.SetRowSpan(Me.ButtonAggiorna, 2)
        Me.ButtonAggiorna.Size = New System.Drawing.Size(164, 44)
        Me.ButtonAggiorna.TabIndex = 5
        Me.ButtonAggiorna.Text = "Button1"
        Me.ButtonAggiorna.UseVisualStyleBackColor = True
        '
        'ButtonCatturaEvento
        '
        Me.tlpMain.SetColumnSpan(Me.ButtonCatturaEvento, 6)
        Me.ButtonCatturaEvento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCatturaEvento.Location = New System.Drawing.Point(3, 374)
        Me.ButtonCatturaEvento.Name = "ButtonCatturaEvento"
        Me.ButtonCatturaEvento.Size = New System.Drawing.Size(578, 34)
        Me.ButtonCatturaEvento.TabIndex = 6
        Me.ButtonCatturaEvento.Text = "Button1"
        Me.ButtonCatturaEvento.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Dal"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(210, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 25)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Al"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpAl
        '
        Me.dtpAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAl.Location = New System.Drawing.Point(290, 28)
        Me.dtpAl.Name = "dtpAl"
        Me.dtpAl.Size = New System.Drawing.Size(121, 20)
        Me.dtpAl.TabIndex = 9
        '
        'LabelSinistro
        '
        Me.LabelSinistro.AutoSize = True
        Me.LabelSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSinistro.Location = New System.Drawing.Point(417, 296)
        Me.LabelSinistro.Name = "LabelSinistro"
        Me.LabelSinistro.Size = New System.Drawing.Size(164, 25)
        Me.LabelSinistro.TabIndex = 10
        Me.LabelSinistro.Text = "Label3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 25)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Utente"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(210, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 25)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Password"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxUtente
        '
        Me.TextBoxUtente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxUtente.Location = New System.Drawing.Point(83, 3)
        Me.TextBoxUtente.Name = "TextBoxUtente"
        Me.TextBoxUtente.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxUtente.TabIndex = 13
        '
        'TextBoxPw
        '
        Me.TextBoxPw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxPw.Location = New System.Drawing.Point(290, 3)
        Me.TextBoxPw.Name = "TextBoxPw"
        Me.TextBoxPw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPw.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxPw.TabIndex = 14
        '
        'FormImportaSinistri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 411)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormImportaSinistri"
        Me.Text = "FormImportaSinistri"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBoxSinistri As System.Windows.Forms.ListBox
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelStato As System.Windows.Forms.Label
    Friend WithEvents ButtonSeleziona As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents dtpDal As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonAggiorna As System.Windows.Forms.Button
    Friend WithEvents ButtonCatturaEvento As System.Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents dtpAl As Windows.Forms.DateTimePicker
    Friend WithEvents LabelSinistro As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents TextBoxUtente As Windows.Forms.TextBox
    Friend WithEvents TextBoxPw As Windows.Forms.TextBox
End Class
