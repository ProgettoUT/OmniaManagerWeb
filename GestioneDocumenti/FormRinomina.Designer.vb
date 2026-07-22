<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRinomina
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
        Me.ComboBoxNomi = New System.Windows.Forms.ComboBox()
        Me.btnElimina = New System.Windows.Forms.Button()
        Me.btnAggiungi = New System.Windows.Forms.Button()
        Me.btnRinomina = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDataDoc = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBoxNomi
        '
        Me.ComboBoxNomi.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBoxNomi.FormattingEnabled = True
        Me.ComboBoxNomi.Location = New System.Drawing.Point(153, 6)
        Me.ComboBoxNomi.Name = "ComboBoxNomi"
        Me.ComboBoxNomi.Size = New System.Drawing.Size(190, 22)
        Me.ComboBoxNomi.TabIndex = 0
        '
        'btnElimina
        '
        Me.btnElimina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnElimina.Location = New System.Drawing.Point(6, 68)
        Me.btnElimina.Name = "btnElimina"
        Me.btnElimina.Size = New System.Drawing.Size(141, 27)
        Me.btnElimina.TabIndex = 2
        Me.btnElimina.Text = "Elimina dai predefiniti"
        Me.btnElimina.UseVisualStyleBackColor = True
        '
        'btnAggiungi
        '
        Me.btnAggiungi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAggiungi.Location = New System.Drawing.Point(6, 37)
        Me.btnAggiungi.Name = "btnAggiungi"
        Me.btnAggiungi.Size = New System.Drawing.Size(141, 25)
        Me.btnAggiungi.TabIndex = 3
        Me.btnAggiungi.Text = "Aggiungi ai predefiniti"
        Me.btnAggiungi.UseVisualStyleBackColor = True
        '
        'btnRinomina
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnRinomina, 2)
        Me.btnRinomina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRinomina.Location = New System.Drawing.Point(153, 37)
        Me.btnRinomina.Name = "btnRinomina"
        Me.TableLayoutPanel1.SetRowSpan(Me.btnRinomina, 2)
        Me.btnRinomina.Size = New System.Drawing.Size(314, 58)
        Me.btnRinomina.TabIndex = 4
        Me.btnRinomina.Text = "Rinomina il documento"
        Me.btnRinomina.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.57895!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.10526!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579!))
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxNomi, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAggiungi, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnElimina, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnRinomina, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDataDoc, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(3)
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(473, 101)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 31)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nuovo nome"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpDataDoc
        '
        Me.dtpDataDoc.Checked = False
        Me.dtpDataDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDataDoc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataDoc.Location = New System.Drawing.Point(349, 6)
        Me.dtpDataDoc.Name = "dtpDataDoc"
        Me.dtpDataDoc.ShowCheckBox = True
        Me.dtpDataDoc.Size = New System.Drawing.Size(118, 22)
        Me.dtpDataDoc.TabIndex = 6
        '
        'FormRinomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 101)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormRinomina"
        Me.Text = "FormRinomina"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBoxNomi As System.Windows.Forms.ComboBox
    Friend WithEvents btnElimina As System.Windows.Forms.Button
    Friend WithEvents btnAggiungi As System.Windows.Forms.Button
    Friend WithEvents btnRinomina As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDataDoc As System.Windows.Forms.DateTimePicker
End Class
