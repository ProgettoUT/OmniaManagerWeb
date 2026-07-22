<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNuovoAvviso
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
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvDati = New System.Windows.Forms.DataGridView()
        Me.ButtonSeleziona = New System.Windows.Forms.Button()
        Me.ButtonAggiungiAvviso = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxCerca = New System.Windows.Forms.TextBox()
        Me.ButtonCerca = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxCF = New System.Windows.Forms.TextBox()
        Me.TextBoxContraente = New System.Windows.Forms.TextBox()
        Me.TextBoxSub = New System.Windows.Forms.TextBox()
        Me.TextBoxRamo = New System.Windows.Forms.TextBox()
        Me.TextBoxPolizza = New System.Windows.Forms.TextBox()
        Me.TextBoxTotale = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxTarga = New System.Windows.Forms.TextBox()
        Me.dtpEffetto = New System.Windows.Forms.DateTimePicker()
        Me.LabelMessaggi = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvDati, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvDati, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSeleziona, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAggiungiAvviso, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnnulla, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxCerca, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCerca, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 530)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'dgvDati
        '
        Me.dgvDati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvDati, 3)
        Me.dgvDati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDati.Location = New System.Drawing.Point(3, 27)
        Me.dgvDati.Name = "dgvDati"
        Me.dgvDati.Size = New System.Drawing.Size(594, 227)
        Me.dgvDati.TabIndex = 0
        '
        'ButtonSeleziona
        '
        Me.ButtonSeleziona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSeleziona.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonSeleziona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSeleziona.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonSeleziona.Location = New System.Drawing.Point(603, 27)
        Me.ButtonSeleziona.Name = "ButtonSeleziona"
        Me.ButtonSeleziona.Padding = New System.Windows.Forms.Padding(0, 40, 0, 40)
        Me.ButtonSeleziona.Size = New System.Drawing.Size(194, 227)
        Me.ButtonSeleziona.TabIndex = 2
        Me.ButtonSeleziona.Text = "Seleziona"
        Me.ButtonSeleziona.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonSeleziona.UseVisualStyleBackColor = True
        '
        'ButtonAggiungiAvviso
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonAggiungiAvviso, 3)
        Me.ButtonAggiungiAvviso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiungiAvviso.Location = New System.Drawing.Point(3, 493)
        Me.ButtonAggiungiAvviso.Name = "ButtonAggiungiAvviso"
        Me.ButtonAggiungiAvviso.Size = New System.Drawing.Size(594, 34)
        Me.ButtonAggiungiAvviso.TabIndex = 3
        Me.ButtonAggiungiAvviso.Text = "Aggiungi avviso di scadenza"
        Me.ButtonAggiungiAvviso.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.Location = New System.Drawing.Point(603, 493)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(194, 34)
        Me.ButtonAnnulla.TabIndex = 4
        Me.ButtonAnnulla.Text = "Annulla"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Contraente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxCerca
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxCerca, 2)
        Me.TextBoxCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCerca.Location = New System.Drawing.Point(203, 3)
        Me.TextBoxCerca.Name = "TextBoxCerca"
        Me.TextBoxCerca.Size = New System.Drawing.Size(394, 20)
        Me.TextBoxCerca.TabIndex = 6
        '
        'ButtonCerca
        '
        Me.ButtonCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCerca.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonCerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCerca.Location = New System.Drawing.Point(603, 3)
        Me.ButtonCerca.Name = "ButtonCerca"
        Me.ButtonCerca.Size = New System.Drawing.Size(194, 18)
        Me.ButtonCerca.TabIndex = 7
        Me.ButtonCerca.Text = "Cerca cliente"
        Me.ButtonCerca.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 4)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxCF, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxContraente, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxSub, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxRamo, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxPolizza, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxTotale, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxTarga, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.dtpEffetto, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelMessaggi, 0, 8)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 260)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 9
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(794, 227)
        Me.TableLayoutPanel2.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Codice fiscale"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(192, 24)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Contraente"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(192, 24)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Subagenzia"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(192, 24)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Ramo"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(3, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(192, 24)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Polizza"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(3, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(192, 24)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Effetto titolo"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(3, 168)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(192, 24)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Totale titolo"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxCF
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.TextBoxCF, 2)
        Me.TextBoxCF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBoxCF.Location = New System.Drawing.Point(201, 3)
        Me.TextBoxCF.Name = "TextBoxCF"
        Me.TextBoxCF.Size = New System.Drawing.Size(390, 20)
        Me.TextBoxCF.TabIndex = 7
        '
        'TextBoxContraente
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.TextBoxContraente, 2)
        Me.TextBoxContraente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxContraente.Location = New System.Drawing.Point(201, 27)
        Me.TextBoxContraente.Name = "TextBoxContraente"
        Me.TextBoxContraente.Size = New System.Drawing.Size(390, 20)
        Me.TextBoxContraente.TabIndex = 8
        '
        'TextBoxSub
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.TextBoxSub, 2)
        Me.TextBoxSub.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxSub.Location = New System.Drawing.Point(201, 51)
        Me.TextBoxSub.Name = "TextBoxSub"
        Me.TextBoxSub.Size = New System.Drawing.Size(390, 20)
        Me.TextBoxSub.TabIndex = 9
        '
        'TextBoxRamo
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.TextBoxRamo, 2)
        Me.TextBoxRamo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxRamo.Location = New System.Drawing.Point(201, 75)
        Me.TextBoxRamo.Name = "TextBoxRamo"
        Me.TextBoxRamo.Size = New System.Drawing.Size(390, 20)
        Me.TextBoxRamo.TabIndex = 10
        '
        'TextBoxPolizza
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.TextBoxPolizza, 2)
        Me.TextBoxPolizza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxPolizza.Location = New System.Drawing.Point(201, 99)
        Me.TextBoxPolizza.Name = "TextBoxPolizza"
        Me.TextBoxPolizza.Size = New System.Drawing.Size(390, 20)
        Me.TextBoxPolizza.TabIndex = 11
        '
        'TextBoxTotale
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.TextBoxTotale, 2)
        Me.TextBoxTotale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxTotale.Location = New System.Drawing.Point(201, 171)
        Me.TextBoxTotale.Name = "TextBoxTotale"
        Me.TextBoxTotale.Size = New System.Drawing.Size(390, 20)
        Me.TextBoxTotale.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(3, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(192, 24)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Targa"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxTarga
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.TextBoxTarga, 2)
        Me.TextBoxTarga.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxTarga.Location = New System.Drawing.Point(201, 147)
        Me.TextBoxTarga.Name = "TextBoxTarga"
        Me.TextBoxTarga.Size = New System.Drawing.Size(390, 20)
        Me.TextBoxTarga.TabIndex = 15
        '
        'dtpEffetto
        '
        Me.dtpEffetto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEffetto.Location = New System.Drawing.Point(201, 123)
        Me.dtpEffetto.Name = "dtpEffetto"
        Me.dtpEffetto.Size = New System.Drawing.Size(192, 20)
        Me.dtpEffetto.TabIndex = 16
        '
        'LabelMessaggi
        '
        Me.LabelMessaggi.AutoSize = True
        Me.LabelMessaggi.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel2.SetColumnSpan(Me.LabelMessaggi, 4)
        Me.LabelMessaggi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMessaggi.ForeColor = System.Drawing.Color.IndianRed
        Me.LabelMessaggi.Location = New System.Drawing.Point(3, 192)
        Me.LabelMessaggi.Margin = New System.Windows.Forms.Padding(3, 0, 3, 5)
        Me.LabelMessaggi.Name = "LabelMessaggi"
        Me.LabelMessaggi.Size = New System.Drawing.Size(788, 30)
        Me.LabelMessaggi.TabIndex = 17
        Me.LabelMessaggi.Text = "Label10"
        Me.LabelMessaggi.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'FormNuovoAvviso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 530)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormNuovoAvviso"
        Me.Text = "FormNuovoAvviso"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvDati, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents dgvDati As DataGridView
    Friend WithEvents ButtonSeleziona As Button
    Friend WithEvents ButtonAggiungiAvviso As Button
    Friend WithEvents ButtonAnnulla As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxCerca As TextBox
    Friend WithEvents ButtonCerca As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBoxCF As TextBox
    Friend WithEvents TextBoxContraente As TextBox
    Friend WithEvents TextBoxSub As TextBox
    Friend WithEvents TextBoxRamo As TextBox
    Friend WithEvents TextBoxPolizza As TextBox
    Friend WithEvents TextBoxTotale As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBoxTarga As TextBox
    Friend WithEvents dtpEffetto As DateTimePicker
    Friend WithEvents LabelMessaggi As Label
End Class
