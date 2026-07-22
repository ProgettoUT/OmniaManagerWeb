<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLog
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
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstLog = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'lstLog
        '
        Me.lstLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstLog.FormattingEnabled = True
        Me.lstLog.ItemHeight = 14
        Me.lstLog.Location = New System.Drawing.Point(6, 5)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.Size = New System.Drawing.Size(438, 368)
        Me.lstLog.TabIndex = 0
        '
        'frmLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 379)
        Me.Controls.Add(Me.lstLog)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmLog"
        Me.Padding = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmLog"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstLog As System.Windows.Forms.ListBox
End Class
