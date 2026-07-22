<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCercaPolizze
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
        Me.dgvPolizze = New System.Windows.Forms.DataGridView()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.tlpMain.SuspendLayout()
        CType(Me.dgvPolizze, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpMain.Controls.Add(Me.ButtonAnnulla, 1, 1)
        Me.tlpMain.Controls.Add(Me.ButtonOk, 0, 1)
        Me.tlpMain.Controls.Add(Me.dgvPolizze, 0, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMain.Size = New System.Drawing.Size(718, 464)
        Me.tlpMain.TabIndex = 0
        '
        'dgvPolizze
        '
        Me.dgvPolizze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpMain.SetColumnSpan(Me.dgvPolizze, 2)
        Me.dgvPolizze.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPolizze.Location = New System.Drawing.Point(3, 3)
        Me.dgvPolizze.Name = "dgvPolizze"
        Me.dgvPolizze.Size = New System.Drawing.Size(712, 418)
        Me.dgvPolizze.TabIndex = 0
        '
        'ButtonOk
        '
        Me.ButtonOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOk.Location = New System.Drawing.Point(3, 427)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(496, 34)
        Me.ButtonOk.TabIndex = 4
        Me.ButtonOk.Text = "Button2"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.Location = New System.Drawing.Point(505, 427)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(210, 34)
        Me.ButtonAnnulla.TabIndex = 5
        Me.ButtonAnnulla.Text = "Button3"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'FormCercaPolizze
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 464)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormCercaPolizze"
        Me.Text = "FormCercaPolizze"
        Me.tlpMain.ResumeLayout(False)
        CType(Me.dgvPolizze, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpMain As Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvPolizze As Windows.Forms.DataGridView
    Friend WithEvents ButtonOk As Windows.Forms.Button
    Friend WithEvents ButtonAnnulla As Windows.Forms.Button
End Class
