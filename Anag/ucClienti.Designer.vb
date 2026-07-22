<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucClienti
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.dgvClienti = New System.Windows.Forms.DataGridView()
        CType(Me.dgvClienti, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvClienti
        '
        Me.dgvClienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClienti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClienti.Location = New System.Drawing.Point(0, 0)
        Me.dgvClienti.Name = "dgvClienti"
        Me.dgvClienti.Size = New System.Drawing.Size(428, 236)
        Me.dgvClienti.TabIndex = 0
        '
        'ucClienti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgvClienti)
        Me.Name = "ucClienti"
        Me.Size = New System.Drawing.Size(428, 236)
        CType(Me.dgvClienti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvClienti As System.Windows.Forms.DataGridView

End Class
