<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRichiestaDate
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
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpInizioPeriodo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFinePeriodo = New System.Windows.Forms.DateTimePicker()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.LabelMessaggio = New System.Windows.Forms.Label()
        Me.ComboBoxAgenzia = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tlpMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 3
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlpMain.Controls.Add(Me.Label1, 0, 1)
        Me.tlpMain.Controls.Add(Me.Label2, 0, 2)
        Me.tlpMain.Controls.Add(Me.Label3, 0, 3)
        Me.tlpMain.Controls.Add(Me.dtpInizioPeriodo, 1, 1)
        Me.tlpMain.Controls.Add(Me.dtpFinePeriodo, 1, 2)
        Me.tlpMain.Controls.Add(Me.ButtonOk, 2, 1)
        Me.tlpMain.Controls.Add(Me.ButtonAnnulla, 2, 3)
        Me.tlpMain.Controls.Add(Me.LabelMessaggio, 0, 0)
        Me.tlpMain.Controls.Add(Me.ComboBoxAgenzia, 1, 3)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 4
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlpMain.Size = New System.Drawing.Size(445, 138)
        Me.tlpMain.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Data inizio"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 27)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data fine"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 27)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Codice agenzia"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpInizioPeriodo
        '
        Me.dtpInizioPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpInizioPeriodo.Location = New System.Drawing.Point(151, 60)
        Me.dtpInizioPeriodo.Name = "dtpInizioPeriodo"
        Me.dtpInizioPeriodo.Size = New System.Drawing.Size(142, 20)
        Me.dtpInizioPeriodo.TabIndex = 3
        '
        'dtpFinePeriodo
        '
        Me.dtpFinePeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpFinePeriodo.Location = New System.Drawing.Point(151, 87)
        Me.dtpFinePeriodo.Name = "dtpFinePeriodo"
        Me.dtpFinePeriodo.Size = New System.Drawing.Size(142, 20)
        Me.dtpFinePeriodo.TabIndex = 4
        '
        'ButtonOk
        '
        Me.ButtonOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOk.Location = New System.Drawing.Point(299, 60)
        Me.ButtonOk.Name = "ButtonOk"
        Me.tlpMain.SetRowSpan(Me.ButtonOk, 2)
        Me.ButtonOk.Size = New System.Drawing.Size(143, 48)
        Me.ButtonOk.TabIndex = 5
        Me.ButtonOk.Text = "Button1"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.Location = New System.Drawing.Point(299, 114)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(143, 21)
        Me.ButtonAnnulla.TabIndex = 6
        Me.ButtonAnnulla.Text = "Button2"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'LabelMessaggio
        '
        Me.LabelMessaggio.AutoSize = True
        Me.tlpMain.SetColumnSpan(Me.LabelMessaggio, 3)
        Me.LabelMessaggio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMessaggio.Location = New System.Drawing.Point(3, 0)
        Me.LabelMessaggio.Name = "LabelMessaggio"
        Me.LabelMessaggio.Size = New System.Drawing.Size(439, 57)
        Me.LabelMessaggio.TabIndex = 7
        Me.LabelMessaggio.Text = "Label4"
        '
        'ComboBoxAgenzia
        '
        Me.ComboBoxAgenzia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxAgenzia.FormattingEnabled = True
        Me.ComboBoxAgenzia.Location = New System.Drawing.Point(151, 114)
        Me.ComboBoxAgenzia.Name = "ComboBoxAgenzia"
        Me.ComboBoxAgenzia.Size = New System.Drawing.Size(142, 21)
        Me.ComboBoxAgenzia.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tlpMain)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(445, 138)
        Me.Panel1.TabIndex = 1
        '
        'FormRichiestaDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 138)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormRichiestaDate"
        Me.Text = "FormRichiestaDate"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpMain As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents dtpInizioPeriodo As Windows.Forms.DateTimePicker
    Friend WithEvents dtpFinePeriodo As Windows.Forms.DateTimePicker
    Friend WithEvents ButtonOk As Windows.Forms.Button
    Friend WithEvents ButtonAnnulla As Windows.Forms.Button
    Friend WithEvents LabelMessaggio As Windows.Forms.Label
    Friend WithEvents ComboBoxAgenzia As Windows.Forms.ComboBox
    Friend WithEvents Panel1 As Windows.Forms.Panel
End Class
