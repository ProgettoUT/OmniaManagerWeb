<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDownloadSertel
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.pbInvio = New System.Windows.Forms.ProgressBar()
        Me.lbNumeroSinistro = New System.Windows.Forms.Label()
        Me.ListBoxDocumenti = New System.Windows.Forms.ListBox()
        Me.btnSalvaFile = New System.Windows.Forms.Button()
        Me.btnVisualizza = New System.Windows.Forms.Button()
        Me.lbStato = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.btnLog = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(426, 209)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(56, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'btnEsci
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnEsci, 2)
        Me.btnEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsci.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEsci.Location = New System.Drawing.Point(368, 286)
        Me.btnEsci.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(124, 66)
        Me.btnEsci.TabIndex = 16
        Me.btnEsci.Text = "Esci"
        Me.btnEsci.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'pbInvio
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.pbInvio, 4)
        Me.pbInvio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbInvio.Location = New System.Drawing.Point(3, 259)
        Me.pbInvio.Name = "pbInvio"
        Me.pbInvio.Size = New System.Drawing.Size(489, 20)
        Me.pbInvio.TabIndex = 15
        '
        'lbNumeroSinistro
        '
        Me.lbNumeroSinistro.BackColor = System.Drawing.Color.White
        Me.lbNumeroSinistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbNumeroSinistro, 4)
        Me.lbNumeroSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbNumeroSinistro.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumeroSinistro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbNumeroSinistro.Location = New System.Drawing.Point(3, 0)
        Me.lbNumeroSinistro.Name = "lbNumeroSinistro"
        Me.lbNumeroSinistro.Size = New System.Drawing.Size(489, 27)
        Me.lbNumeroSinistro.TabIndex = 14
        Me.lbNumeroSinistro.Text = "lbNumeroSinistro"
        Me.lbNumeroSinistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ListBoxDocumenti
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ListBoxDocumenti, 4)
        Me.ListBoxDocumenti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxDocumenti.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxDocumenti.FormattingEnabled = True
        Me.ListBoxDocumenti.IntegralHeight = False
        Me.ListBoxDocumenti.ItemHeight = 16
        Me.ListBoxDocumenti.Location = New System.Drawing.Point(3, 31)
        Me.ListBoxDocumenti.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListBoxDocumenti.Name = "ListBoxDocumenti"
        Me.ListBoxDocumenti.Size = New System.Drawing.Size(489, 190)
        Me.ListBoxDocumenti.TabIndex = 13
        '
        'btnSalvaFile
        '
        Me.btnSalvaFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSalvaFile.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalvaFile.Location = New System.Drawing.Point(156, 286)
        Me.btnSalvaFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSalvaFile.Name = "btnSalvaFile"
        Me.btnSalvaFile.Size = New System.Drawing.Size(206, 66)
        Me.btnSalvaFile.TabIndex = 12
        Me.btnSalvaFile.Text = "btnSalvaFile"
        Me.btnSalvaFile.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnSalvaFile.UseVisualStyleBackColor = True
        '
        'btnVisualizza
        '
        Me.btnVisualizza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVisualizza.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVisualizza.Location = New System.Drawing.Point(3, 286)
        Me.btnVisualizza.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnVisualizza.Name = "btnVisualizza"
        Me.btnVisualizza.Size = New System.Drawing.Size(147, 66)
        Me.btnVisualizza.TabIndex = 11
        Me.btnVisualizza.Text = "btnVisualizza"
        Me.btnVisualizza.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnVisualizza.UseVisualStyleBackColor = True
        '
        'lbStato
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbStato, 3)
        Me.lbStato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbStato.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStato.Location = New System.Drawing.Point(3, 225)
        Me.lbStato.Name = "lbStato"
        Me.lbStato.Size = New System.Drawing.Size(455, 31)
        Me.lbStato.TabIndex = 18
        Me.lbStato.Text = "Label1"
        Me.lbStato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BackgroundWorker1
        '
        '
        'btnLog
        '
        Me.btnLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLog.FlatAppearance.BorderSize = 0
        Me.btnLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold
        Me.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLog.Location = New System.Drawing.Point(464, 228)
        Me.btnLog.Name = "btnLog"
        Me.btnLog.Size = New System.Drawing.Size(28, 25)
        Me.btnLog.TabIndex = 19
        Me.btnLog.Text = "Log"
        Me.btnLog.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.98698!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.8243!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbNumeroSinistro, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ListBoxDocumenti, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbStato, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEsci, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSalvaFile, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.pbInvio, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnVisualizza, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnLog, 3, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(521, 22)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.751938!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.75432!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.944544!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.453786!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.09541!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(495, 356)
        Me.TableLayoutPanel1.TabIndex = 20
        '
        'FormUploadSertel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1233, 390)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormUploadSertel"
        Me.Text = "FormUploadSertel"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents pbInvio As System.Windows.Forms.ProgressBar
    Friend WithEvents lbNumeroSinistro As System.Windows.Forms.Label
    Friend WithEvents ListBoxDocumenti As System.Windows.Forms.ListBox
    Friend WithEvents btnSalvaFile As System.Windows.Forms.Button
    Friend WithEvents btnVisualizza As System.Windows.Forms.Button
    Friend WithEvents lbStato As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnLog As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
