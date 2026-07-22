<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProgessBar
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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LabelMessaggio = New System.Windows.Forms.Label()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.LabelPerc = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 32)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(363, 29)
        Me.ProgressBar1.TabIndex = 0
        '
        'LabelMessaggio
        '
        Me.LabelMessaggio.AutoSize = True
        Me.LabelMessaggio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMessaggio.Location = New System.Drawing.Point(12, 15)
        Me.LabelMessaggio.Name = "LabelMessaggio"
        Me.LabelMessaggio.Size = New System.Drawing.Size(42, 14)
        Me.LabelMessaggio.TabIndex = 1
        Me.LabelMessaggio.Text = "Label1"
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Location = New System.Drawing.Point(300, 67)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAnnulla.TabIndex = 2
        Me.ButtonAnnulla.Text = "Annulla"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'LabelPerc
        '
        Me.LabelPerc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPerc.Location = New System.Drawing.Point(330, 16)
        Me.LabelPerc.Name = "LabelPerc"
        Me.LabelPerc.Size = New System.Drawing.Size(44, 12)
        Me.LabelPerc.TabIndex = 3
        Me.LabelPerc.Text = "Label1"
        Me.LabelPerc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormProgessBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(387, 102)
        Me.Controls.Add(Me.LabelPerc)
        Me.Controls.Add(Me.ButtonAnnulla)
        Me.Controls.Add(Me.LabelMessaggio)
        Me.Controls.Add(Me.ProgressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormProgessBar"
        Me.Opacity = 0.9R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormProgessBar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelMessaggio As System.Windows.Forms.Label
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
    Friend WithEvents LabelPerc As System.Windows.Forms.Label
End Class
