<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormArretrati
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonAggiorna = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpInizioPeriodo = New System.Windows.Forms.DateTimePicker()
        Me.LabelUltimoAggiornamento = New System.Windows.Forms.Label()
        Me.dtpFinePeriodo = New System.Windows.Forms.DateTimePicker()
        Me.CheckBoxCodiceCorrente = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Aggiorna arretrati dal"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAggiorna, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpInizioPeriodo, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelUltimoAggiornamento, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpFinePeriodo, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxCodiceCorrente, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(359, 126)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'ButtonAggiorna
        '
        Me.ButtonAggiorna.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiorna.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAggiorna.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonAggiorna.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAggiorna.Location = New System.Drawing.Point(250, 41)
        Me.ButtonAggiorna.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAggiorna.Name = "ButtonAggiorna"
        Me.TableLayoutPanel1.SetRowSpan(Me.ButtonAggiorna, 2)
        Me.ButtonAggiorna.Size = New System.Drawing.Size(109, 60)
        Me.ButtonAggiorna.TabIndex = 2
        Me.ButtonAggiorna.Text = "Aggiorna"
        Me.ButtonAggiorna.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 30)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "al"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpInizioPeriodo
        '
        Me.dtpInizioPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpInizioPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInizioPeriodo.Location = New System.Drawing.Point(146, 44)
        Me.dtpInizioPeriodo.Name = "dtpInizioPeriodo"
        Me.dtpInizioPeriodo.Size = New System.Drawing.Size(101, 22)
        Me.dtpInizioPeriodo.TabIndex = 4
        '
        'LabelUltimoAggiornamento
        '
        Me.LabelUltimoAggiornamento.AutoSize = True
        Me.LabelUltimoAggiornamento.BackColor = System.Drawing.Color.Gainsboro
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelUltimoAggiornamento, 3)
        Me.LabelUltimoAggiornamento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelUltimoAggiornamento.Location = New System.Drawing.Point(0, 0)
        Me.LabelUltimoAggiornamento.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.LabelUltimoAggiornamento.Name = "LabelUltimoAggiornamento"
        Me.LabelUltimoAggiornamento.Size = New System.Drawing.Size(359, 40)
        Me.LabelUltimoAggiornamento.TabIndex = 5
        Me.LabelUltimoAggiornamento.Text = "Label3"
        Me.LabelUltimoAggiornamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFinePeriodo
        '
        Me.dtpFinePeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpFinePeriodo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinePeriodo.Location = New System.Drawing.Point(146, 74)
        Me.dtpFinePeriodo.Name = "dtpFinePeriodo"
        Me.dtpFinePeriodo.Size = New System.Drawing.Size(101, 22)
        Me.dtpFinePeriodo.TabIndex = 6
        '
        'CheckBoxCodiceCorrente
        '
        Me.CheckBoxCodiceCorrente.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.CheckBoxCodiceCorrente, 3)
        Me.CheckBoxCodiceCorrente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxCodiceCorrente.Location = New System.Drawing.Point(3, 104)
        Me.CheckBoxCodiceCorrente.Name = "CheckBoxCodiceCorrente"
        Me.CheckBoxCodiceCorrente.Size = New System.Drawing.Size(353, 19)
        Me.CheckBoxCodiceCorrente.TabIndex = 7
        Me.CheckBoxCodiceCorrente.Text = "Aggiorna solo il codice agenzia selezionato"
        Me.CheckBoxCodiceCorrente.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.CheckBoxCodiceCorrente.UseVisualStyleBackColor = True
        '
        'FormArretrati
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 126)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormArretrati"
        Me.Text = "FormArretrati"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonAggiorna As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpInizioPeriodo As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelUltimoAggiornamento As System.Windows.Forms.Label
    Friend WithEvents dtpFinePeriodo As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBoxCodiceCorrente As System.Windows.Forms.CheckBox
End Class
