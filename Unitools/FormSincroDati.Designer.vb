<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSincroDati
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
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonSincroDb = New System.Windows.Forms.Button()
        Me.ButtonSincroDocMU = New System.Windows.Forms.Button()
        Me.ButtonSincroDocUM = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.ListBoxStato = New System.Windows.Forms.ListBox()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 3
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.tlpMain.Controls.Add(Me.ButtonSincroDb, 0, 0)
        Me.tlpMain.Controls.Add(Me.ButtonSincroDocMU, 1, 0)
        Me.tlpMain.Controls.Add(Me.ButtonSincroDocUM, 1, 1)
        Me.tlpMain.Controls.Add(Me.ButtonEsci, 2, 0)
        Me.tlpMain.Controls.Add(Me.ListBoxStato, 0, 2)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.Padding = New System.Windows.Forms.Padding(1)
        Me.tlpMain.RowCount = 3
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(407, 371)
        Me.tlpMain.TabIndex = 0
        '
        'ButtonSincroDb
        '
        Me.ButtonSincroDb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSincroDb.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonSincroDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSincroDb.Location = New System.Drawing.Point(2, 2)
        Me.ButtonSincroDb.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonSincroDb.Name = "ButtonSincroDb"
        Me.tlpMain.SetRowSpan(Me.ButtonSincroDb, 2)
        Me.ButtonSincroDb.Size = New System.Drawing.Size(152, 58)
        Me.ButtonSincroDb.TabIndex = 1
        Me.ButtonSincroDb.Text = "Button1"
        Me.ButtonSincroDb.UseVisualStyleBackColor = True
        '
        'ButtonSincroDocMU
        '
        Me.ButtonSincroDocMU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSincroDocMU.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonSincroDocMU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSincroDocMU.Location = New System.Drawing.Point(156, 2)
        Me.ButtonSincroDocMU.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonSincroDocMU.Name = "ButtonSincroDocMU"
        Me.ButtonSincroDocMU.Size = New System.Drawing.Size(186, 28)
        Me.ButtonSincroDocMU.TabIndex = 2
        Me.ButtonSincroDocMU.Text = "Button2"
        Me.ButtonSincroDocMU.UseVisualStyleBackColor = True
        '
        'ButtonSincroDocUM
        '
        Me.ButtonSincroDocUM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSincroDocUM.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonSincroDocUM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSincroDocUM.Location = New System.Drawing.Point(156, 32)
        Me.ButtonSincroDocUM.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonSincroDocUM.Name = "ButtonSincroDocUM"
        Me.ButtonSincroDocUM.Size = New System.Drawing.Size(186, 28)
        Me.ButtonSincroDocUM.TabIndex = 3
        Me.ButtonSincroDocUM.Text = "Button3"
        Me.ButtonSincroDocUM.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsci.Location = New System.Drawing.Point(344, 2)
        Me.ButtonEsci.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.tlpMain.SetRowSpan(Me.ButtonEsci, 2)
        Me.ButtonEsci.Size = New System.Drawing.Size(61, 58)
        Me.ButtonEsci.TabIndex = 4
        Me.ButtonEsci.Text = "Button4"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'ListBoxStato
        '
        Me.ListBoxStato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpMain.SetColumnSpan(Me.ListBoxStato, 3)
        Me.ListBoxStato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxStato.FormattingEnabled = True
        Me.ListBoxStato.Location = New System.Drawing.Point(1, 61)
        Me.ListBoxStato.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBoxStato.Name = "ListBoxStato"
        Me.ListBoxStato.Size = New System.Drawing.Size(405, 309)
        Me.ListBoxStato.TabIndex = 5
        '
        'FormSincroDati
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 371)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormSincroDati"
        Me.Text = "FormSincroDati"
        Me.tlpMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonSincroDb As System.Windows.Forms.Button
    Friend WithEvents ButtonSincroDocMU As System.Windows.Forms.Button
    Friend WithEvents ButtonSincroDocUM As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents ListBoxStato As System.Windows.Forms.ListBox
End Class
