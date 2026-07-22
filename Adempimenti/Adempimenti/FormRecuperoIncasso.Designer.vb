<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRecuperoIncasso
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
        Me.dgvIncassi = New System.Windows.Forms.DataGridView()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.TextBoxRamo = New System.Windows.Forms.TextBox()
        Me.TextBoxPolizza = New System.Windows.Forms.TextBox()
        Me.ButtonCerca = New System.Windows.Forms.Button()
        Me.LabelPolizza = New System.Windows.Forms.Label()
        Me.ButtonRecupera = New System.Windows.Forms.Button()
        Me.tlpMain.SuspendLayout()
        CType(Me.dgvIncassi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 4
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.Controls.Add(Me.dgvIncassi, 0, 1)
        Me.tlpMain.Controls.Add(Me.ButtonEsci, 3, 2)
        Me.tlpMain.Controls.Add(Me.TextBoxRamo, 1, 0)
        Me.tlpMain.Controls.Add(Me.TextBoxPolizza, 2, 0)
        Me.tlpMain.Controls.Add(Me.ButtonCerca, 3, 0)
        Me.tlpMain.Controls.Add(Me.LabelPolizza, 0, 0)
        Me.tlpMain.Controls.Add(Me.ButtonRecupera, 2, 2)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 3
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.46154!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.53846!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMain.Size = New System.Drawing.Size(433, 294)
        Me.tlpMain.TabIndex = 0
        '
        'dgvIncassi
        '
        Me.dgvIncassi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpMain.SetColumnSpan(Me.dgvIncassi, 4)
        Me.dgvIncassi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIncassi.Location = New System.Drawing.Point(3, 37)
        Me.dgvIncassi.Name = "dgvIncassi"
        Me.dgvIncassi.Size = New System.Drawing.Size(427, 213)
        Me.dgvIncassi.TabIndex = 3
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Location = New System.Drawing.Point(327, 256)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(85, 35)
        Me.ButtonEsci.TabIndex = 5
        Me.ButtonEsci.Text = "Button2"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'TextBoxRamo
        '
        Me.TextBoxRamo.Location = New System.Drawing.Point(111, 3)
        Me.TextBoxRamo.Name = "TextBoxRamo"
        Me.TextBoxRamo.Size = New System.Drawing.Size(67, 20)
        Me.TextBoxRamo.TabIndex = 0
        '
        'TextBoxPolizza
        '
        Me.TextBoxPolizza.Location = New System.Drawing.Point(219, 3)
        Me.TextBoxPolizza.Name = "TextBoxPolizza"
        Me.TextBoxPolizza.Size = New System.Drawing.Size(86, 20)
        Me.TextBoxPolizza.TabIndex = 1
        '
        'ButtonCerca
        '
        Me.ButtonCerca.Location = New System.Drawing.Point(327, 3)
        Me.ButtonCerca.Name = "ButtonCerca"
        Me.ButtonCerca.Size = New System.Drawing.Size(103, 28)
        Me.ButtonCerca.TabIndex = 2
        Me.ButtonCerca.Text = "Button3"
        Me.ButtonCerca.UseVisualStyleBackColor = True
        '
        'LabelPolizza
        '
        Me.LabelPolizza.AutoSize = True
        Me.LabelPolizza.Location = New System.Drawing.Point(3, 0)
        Me.LabelPolizza.Name = "LabelPolizza"
        Me.LabelPolizza.Size = New System.Drawing.Size(39, 13)
        Me.LabelPolizza.TabIndex = 6
        Me.LabelPolizza.Text = "Label1"
        '
        'ButtonRecupera
        '
        Me.ButtonRecupera.Location = New System.Drawing.Point(219, 256)
        Me.ButtonRecupera.Name = "ButtonRecupera"
        Me.ButtonRecupera.Size = New System.Drawing.Size(102, 35)
        Me.ButtonRecupera.TabIndex = 4
        Me.ButtonRecupera.Text = "Button1"
        Me.ButtonRecupera.UseVisualStyleBackColor = True
        '
        'FormRecuperoIncasso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 294)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormRecuperoIncasso"
        Me.Text = "FormRecuperoIncasso"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        CType(Me.dgvIncassi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvIncassi As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonRecupera As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents TextBoxRamo As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPolizza As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCerca As System.Windows.Forms.Button
    Friend WithEvents LabelPolizza As System.Windows.Forms.Label
End Class
