<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLegami
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
        Me.ButtonCerca = New System.Windows.Forms.Button()
        Me.TextBoxCerca = New System.Windows.Forms.TextBox()
        Me.ButtonElimina = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.dgvClienti = New System.Windows.Forms.DataGridView()
        Me.ButtonCapofamiglia = New System.Windows.Forms.Button()
        Me.ButtonEnte = New System.Windows.Forms.Button()
        Me.LabelCliente = New System.Windows.Forms.Label()
        Me.tlpMain.SuspendLayout()
        CType(Me.dgvClienti, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 4
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpMain.Controls.Add(Me.ButtonCerca, 3, 1)
        Me.tlpMain.Controls.Add(Me.TextBoxCerca, 0, 1)
        Me.tlpMain.Controls.Add(Me.ButtonElimina, 0, 3)
        Me.tlpMain.Controls.Add(Me.ButtonEsci, 3, 3)
        Me.tlpMain.Controls.Add(Me.dgvClienti, 0, 2)
        Me.tlpMain.Controls.Add(Me.ButtonCapofamiglia, 1, 3)
        Me.tlpMain.Controls.Add(Me.ButtonEnte, 2, 3)
        Me.tlpMain.Controls.Add(Me.LabelCliente, 0, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 4
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMain.Size = New System.Drawing.Size(730, 306)
        Me.tlpMain.TabIndex = 0
        '
        'ButtonCerca
        '
        Me.ButtonCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCerca.Location = New System.Drawing.Point(587, 31)
        Me.ButtonCerca.Name = "ButtonCerca"
        Me.ButtonCerca.Size = New System.Drawing.Size(140, 22)
        Me.ButtonCerca.TabIndex = 1
        Me.ButtonCerca.Text = "Button1"
        Me.ButtonCerca.UseVisualStyleBackColor = True
        '
        'TextBoxCerca
        '
        Me.tlpMain.SetColumnSpan(Me.TextBoxCerca, 3)
        Me.TextBoxCerca.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextBoxCerca.Location = New System.Drawing.Point(3, 33)
        Me.TextBoxCerca.Name = "TextBoxCerca"
        Me.TextBoxCerca.Size = New System.Drawing.Size(578, 20)
        Me.TextBoxCerca.TabIndex = 0
        '
        'ButtonElimina
        '
        Me.ButtonElimina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonElimina.Location = New System.Drawing.Point(3, 269)
        Me.ButtonElimina.Name = "ButtonElimina"
        Me.ButtonElimina.Size = New System.Drawing.Size(140, 34)
        Me.ButtonElimina.TabIndex = 3
        Me.ButtonElimina.Text = "Button2"
        Me.ButtonElimina.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.Location = New System.Drawing.Point(587, 269)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(140, 34)
        Me.ButtonEsci.TabIndex = 4
        Me.ButtonEsci.Text = "Button3"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'dgvClienti
        '
        Me.dgvClienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpMain.SetColumnSpan(Me.dgvClienti, 4)
        Me.dgvClienti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClienti.Location = New System.Drawing.Point(3, 59)
        Me.dgvClienti.Name = "dgvClienti"
        Me.dgvClienti.Size = New System.Drawing.Size(724, 204)
        Me.dgvClienti.TabIndex = 2
        '
        'ButtonCapofamiglia
        '
        Me.ButtonCapofamiglia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCapofamiglia.Location = New System.Drawing.Point(149, 269)
        Me.ButtonCapofamiglia.Name = "ButtonCapofamiglia"
        Me.ButtonCapofamiglia.Size = New System.Drawing.Size(213, 34)
        Me.ButtonCapofamiglia.TabIndex = 5
        Me.ButtonCapofamiglia.Text = "Button1"
        Me.ButtonCapofamiglia.UseVisualStyleBackColor = True
        '
        'ButtonEnte
        '
        Me.ButtonEnte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEnte.Location = New System.Drawing.Point(368, 269)
        Me.ButtonEnte.Name = "ButtonEnte"
        Me.ButtonEnte.Size = New System.Drawing.Size(213, 34)
        Me.ButtonEnte.TabIndex = 6
        Me.ButtonEnte.Text = "Button2"
        Me.ButtonEnte.UseVisualStyleBackColor = True
        '
        'LabelCliente
        '
        Me.LabelCliente.AutoSize = True
        Me.tlpMain.SetColumnSpan(Me.LabelCliente, 4)
        Me.LabelCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCliente.Location = New System.Drawing.Point(3, 0)
        Me.LabelCliente.Name = "LabelCliente"
        Me.LabelCliente.Size = New System.Drawing.Size(724, 28)
        Me.LabelCliente.TabIndex = 7
        Me.LabelCliente.Text = "Label1"
        Me.LabelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormLegami
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 306)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormLegami"
        Me.Text = "FormLegami"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        CType(Me.dgvClienti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonCerca As System.Windows.Forms.Button
    Friend WithEvents TextBoxCerca As System.Windows.Forms.TextBox
    Friend WithEvents ButtonElimina As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents dgvClienti As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonCapofamiglia As System.Windows.Forms.Button
    Friend WithEvents ButtonEnte As System.Windows.Forms.Button
    Friend WithEvents LabelCliente As System.Windows.Forms.Label
End Class
