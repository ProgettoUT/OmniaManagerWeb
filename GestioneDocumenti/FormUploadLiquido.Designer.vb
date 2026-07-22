<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUploadLiquido
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
        Me.pbInvio = New System.Windows.Forms.ProgressBar()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.lbNumeroSinistro = New System.Windows.Forms.Label()
        Me.CheckedListBoxPosizioni = New System.Windows.Forms.CheckedListBox()
        Me.btnInvia = New System.Windows.Forms.Button()
        Me.LabelAbbinamento = New System.Windows.Forms.Label()
        Me.txtStato = New System.Windows.Forms.TextBox()
        Me.TextBoxNote = New System.Windows.Forms.TextBox()
        Me.LabelNote = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.pbInvio, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEsci, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lbNumeroSinistro, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckedListBoxPosizioni, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnInvia, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelAbbinamento, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtStato, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxNote, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelNote, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(434, 332)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'pbInvio
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.pbInvio, 3)
        Me.pbInvio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbInvio.Location = New System.Drawing.Point(1, 271)
        Me.pbInvio.Margin = New System.Windows.Forms.Padding(1)
        Me.pbInvio.Name = "pbInvio"
        Me.pbInvio.Size = New System.Drawing.Size(432, 18)
        Me.pbInvio.TabIndex = 16
        '
        'btnEsci
        '
        Me.btnEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsci.Location = New System.Drawing.Point(304, 291)
        Me.btnEsci.Margin = New System.Windows.Forms.Padding(1)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(129, 40)
        Me.btnEsci.TabIndex = 17
        Me.btnEsci.Text = "Button1"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'lbNumeroSinistro
        '
        Me.lbNumeroSinistro.AutoSize = True
        Me.lbNumeroSinistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbNumeroSinistro, 3)
        Me.lbNumeroSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbNumeroSinistro.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumeroSinistro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbNumeroSinistro.Location = New System.Drawing.Point(1, 1)
        Me.lbNumeroSinistro.Margin = New System.Windows.Forms.Padding(1)
        Me.lbNumeroSinistro.Name = "lbNumeroSinistro"
        Me.lbNumeroSinistro.Size = New System.Drawing.Size(432, 23)
        Me.lbNumeroSinistro.TabIndex = 21
        Me.lbNumeroSinistro.Text = "Label1"
        Me.lbNumeroSinistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckedListBoxPosizioni
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.CheckedListBoxPosizioni, 3)
        Me.CheckedListBoxPosizioni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxPosizioni.FormattingEnabled = True
        Me.CheckedListBoxPosizioni.IntegralHeight = False
        Me.CheckedListBoxPosizioni.Location = New System.Drawing.Point(1, 26)
        Me.CheckedListBoxPosizioni.Margin = New System.Windows.Forms.Padding(1)
        Me.CheckedListBoxPosizioni.Name = "CheckedListBoxPosizioni"
        Me.CheckedListBoxPosizioni.Size = New System.Drawing.Size(432, 101)
        Me.CheckedListBoxPosizioni.TabIndex = 22
        '
        'btnInvia
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnInvia, 2)
        Me.btnInvia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnInvia.Location = New System.Drawing.Point(1, 291)
        Me.btnInvia.Margin = New System.Windows.Forms.Padding(1)
        Me.btnInvia.Name = "btnInvia"
        Me.btnInvia.Size = New System.Drawing.Size(301, 40)
        Me.btnInvia.TabIndex = 23
        Me.btnInvia.Text = "Button1"
        Me.btnInvia.UseVisualStyleBackColor = True
        '
        'LabelAbbinamento
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelAbbinamento, 3)
        Me.LabelAbbinamento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelAbbinamento.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAbbinamento.Location = New System.Drawing.Point(0, 199)
        Me.LabelAbbinamento.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelAbbinamento.Name = "LabelAbbinamento"
        Me.LabelAbbinamento.Size = New System.Drawing.Size(434, 20)
        Me.LabelAbbinamento.TabIndex = 25
        Me.LabelAbbinamento.Text = "Label2"
        Me.LabelAbbinamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtStato
        '
        Me.txtStato.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtStato, 3)
        Me.txtStato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStato.Location = New System.Drawing.Point(1, 220)
        Me.txtStato.Margin = New System.Windows.Forms.Padding(1)
        Me.txtStato.Multiline = True
        Me.txtStato.Name = "txtStato"
        Me.txtStato.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStato.Size = New System.Drawing.Size(432, 49)
        Me.txtStato.TabIndex = 26
        '
        'TextBoxNote
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxNote, 3)
        Me.TextBoxNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxNote.Location = New System.Drawing.Point(1, 149)
        Me.TextBoxNote.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxNote.Multiline = True
        Me.TextBoxNote.Name = "TextBoxNote"
        Me.TextBoxNote.Size = New System.Drawing.Size(432, 49)
        Me.TextBoxNote.TabIndex = 27
        '
        'LabelNote
        '
        Me.LabelNote.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelNote, 3)
        Me.LabelNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNote.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelNote.Location = New System.Drawing.Point(3, 128)
        Me.LabelNote.Name = "LabelNote"
        Me.LabelNote.Size = New System.Drawing.Size(428, 20)
        Me.LabelNote.TabIndex = 28
        Me.LabelNote.Text = "Note utente da trasmettere a Liquido (max 250 car.)"
        Me.LabelNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BackgroundWorker1
        '
        '
        'FormUploadLiquido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 332)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FormUploadLiquido"
        Me.Text = "FormUploadLiquido"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pbInvio As System.Windows.Forms.ProgressBar
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents lbNumeroSinistro As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents CheckedListBoxPosizioni As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnInvia As System.Windows.Forms.Button
    Friend WithEvents LabelAbbinamento As System.Windows.Forms.Label
    Friend WithEvents txtStato As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNote As System.Windows.Forms.TextBox
    Friend WithEvents LabelNote As System.Windows.Forms.Label
End Class
