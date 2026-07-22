<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCancella
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.LabelTitolo = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelPiuTitoli = New System.Windows.Forms.Label()
        Me.dtpInizio = New System.Windows.Forms.DateTimePicker()
        Me.LabelDal = New System.Windows.Forms.Label()
        Me.LabelAl = New System.Windows.Forms.Label()
        Me.dtpFine = New System.Windows.Forms.DateTimePicker()
        Me.ButtonCancella = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCancella, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(5, 5)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(477, 205)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TabControl1, 2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(477, 165)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.LabelTitolo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(469, 139)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'LabelTitolo
        '
        Me.LabelTitolo.AutoSize = True
        Me.LabelTitolo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTitolo.Location = New System.Drawing.Point(3, 3)
        Me.LabelTitolo.Name = "LabelTitolo"
        Me.LabelTitolo.Size = New System.Drawing.Size(39, 13)
        Me.LabelTitolo.TabIndex = 2
        Me.LabelTitolo.Text = "Label1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(469, 139)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.dtpInizio, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelPiuTitoli, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelDal, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelAl, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.dtpFine, 1, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(463, 133)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'LabelPiuTitoli
        '
        Me.LabelPiuTitoli.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.LabelPiuTitoli, 2)
        Me.LabelPiuTitoli.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPiuTitoli.Location = New System.Drawing.Point(3, 60)
        Me.LabelPiuTitoli.Name = "LabelPiuTitoli"
        Me.LabelPiuTitoli.Size = New System.Drawing.Size(457, 73)
        Me.LabelPiuTitoli.TabIndex = 3
        Me.LabelPiuTitoli.Text = "Label2"
        '
        'dtpInizio
        '
        Me.dtpInizio.Location = New System.Drawing.Point(234, 3)
        Me.dtpInizio.Name = "dtpInizio"
        Me.dtpInizio.Size = New System.Drawing.Size(55, 20)
        Me.dtpInizio.TabIndex = 4
        '
        'LabelDal
        '
        Me.LabelDal.AutoSize = True
        Me.LabelDal.Location = New System.Drawing.Point(3, 0)
        Me.LabelDal.Name = "LabelDal"
        Me.LabelDal.Size = New System.Drawing.Size(60, 13)
        Me.LabelDal.TabIndex = 6
        Me.LabelDal.Text = "Periodo dal"
        Me.LabelDal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelAl
        '
        Me.LabelAl.AutoSize = True
        Me.LabelAl.Location = New System.Drawing.Point(3, 30)
        Me.LabelAl.Name = "LabelAl"
        Me.LabelAl.Size = New System.Drawing.Size(15, 13)
        Me.LabelAl.TabIndex = 7
        Me.LabelAl.Text = "al"
        Me.LabelAl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFine
        '
        Me.dtpFine.Location = New System.Drawing.Point(234, 33)
        Me.dtpFine.Name = "dtpFine"
        Me.dtpFine.Size = New System.Drawing.Size(115, 20)
        Me.dtpFine.TabIndex = 5
        '
        'ButtonCancella
        '
        Me.ButtonCancella.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCancella.Location = New System.Drawing.Point(3, 168)
        Me.ButtonCancella.Name = "ButtonCancella"
        Me.ButtonCancella.Size = New System.Drawing.Size(327, 34)
        Me.ButtonCancella.TabIndex = 8
        Me.ButtonCancella.Text = "Button1"
        Me.ButtonCancella.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.Location = New System.Drawing.Point(336, 168)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(138, 34)
        Me.ButtonEsci.TabIndex = 9
        Me.ButtonEsci.Text = "Button2"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'FormCancella
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 215)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormCancella"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Text = "FormCancella"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelTitolo As System.Windows.Forms.Label
    Friend WithEvents LabelPiuTitoli As System.Windows.Forms.Label
    Friend WithEvents dtpInizio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFine As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelDal As System.Windows.Forms.Label
    Friend WithEvents LabelAl As System.Windows.Forms.Label
    Friend WithEvents ButtonCancella As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
End Class
