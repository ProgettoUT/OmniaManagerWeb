<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAttivita
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpInizio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFine = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxPeriodo = New System.Windows.Forms.ComboBox()
        Me.ButtonElenco = New System.Windows.Forms.Button()
        Me.ButtonStampa = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.TextBoxUtente = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpInizio, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpFine, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxPeriodo, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonElenco, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonStampa, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnnulla, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxUtente, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(439, 161)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 26)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Utente"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpInizio
        '
        Me.dtpInizio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpInizio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInizio.Location = New System.Drawing.Point(149, 29)
        Me.dtpInizio.Name = "dtpInizio"
        Me.dtpInizio.Size = New System.Drawing.Size(140, 20)
        Me.dtpInizio.TabIndex = 0
        '
        'dtpFine
        '
        Me.dtpFine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpFine.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFine.Location = New System.Drawing.Point(149, 55)
        Me.dtpFine.Name = "dtpFine"
        Me.dtpFine.Size = New System.Drawing.Size(140, 20)
        Me.dtpFine.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 26)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Periodo dal"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 26)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "al"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 26)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Periodi"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxPeriodo
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ComboBoxPeriodo, 2)
        Me.ComboBoxPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxPeriodo.FormattingEnabled = True
        Me.ComboBoxPeriodo.Location = New System.Drawing.Point(149, 81)
        Me.ComboBoxPeriodo.Name = "ComboBoxPeriodo"
        Me.ComboBoxPeriodo.Size = New System.Drawing.Size(287, 21)
        Me.ComboBoxPeriodo.TabIndex = 5
        '
        'ButtonElenco
        '
        Me.ButtonElenco.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonElenco.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonElenco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonElenco.Location = New System.Drawing.Point(146, 114)
        Me.ButtonElenco.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonElenco.Name = "ButtonElenco"
        Me.ButtonElenco.Size = New System.Drawing.Size(146, 47)
        Me.ButtonElenco.TabIndex = 6
        Me.ButtonElenco.Text = "Button1"
        Me.ButtonElenco.UseVisualStyleBackColor = True
        '
        'ButtonStampa
        '
        Me.ButtonStampa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonStampa.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonStampa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStampa.Location = New System.Drawing.Point(0, 114)
        Me.ButtonStampa.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonStampa.Name = "ButtonStampa"
        Me.ButtonStampa.Size = New System.Drawing.Size(146, 47)
        Me.ButtonStampa.TabIndex = 7
        Me.ButtonStampa.Text = "Button2"
        Me.ButtonStampa.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnnulla.Location = New System.Drawing.Point(292, 114)
        Me.ButtonAnnulla.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(147, 47)
        Me.ButtonAnnulla.TabIndex = 8
        Me.ButtonAnnulla.Text = "Button3"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'TextBoxUtente
        '
        Me.TextBoxUtente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxUtente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxUtente.Location = New System.Drawing.Point(149, 3)
        Me.TextBoxUtente.Name = "TextBoxUtente"
        Me.TextBoxUtente.Size = New System.Drawing.Size(140, 20)
        Me.TextBoxUtente.TabIndex = 9
        '
        'FormAttivita
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 161)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormAttivita"
        Me.Text = "FormAttivita"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dtpInizio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFine As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonElenco As System.Windows.Forms.Button
    Friend WithEvents ButtonStampa As System.Windows.Forms.Button
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents TextBoxUtente As Windows.Forms.TextBox
End Class
