<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Notifica
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Notifica))
        Me.lbMessaggio = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnAnnulla = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbMessaggio
        '
        Me.lbMessaggio.BackColor = System.Drawing.Color.Lavender
        Me.lbMessaggio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbMessaggio.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbMessaggio.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMessaggio.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.lbMessaggio.Location = New System.Drawing.Point(0, 0)
        Me.lbMessaggio.Name = "lbMessaggio"
        Me.lbMessaggio.Size = New System.Drawing.Size(360, 70)
        Me.lbMessaggio.TabIndex = 0
        Me.lbMessaggio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        '
        'btnAnnulla
        '
        Me.btnAnnulla.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnAnnulla.Image = CType(resources.GetObject("btnAnnulla.Image"), System.Drawing.Image)
        Me.btnAnnulla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnnulla.Location = New System.Drawing.Point(0, 70)
        Me.btnAnnulla.Name = "btnAnnulla"
        Me.btnAnnulla.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.btnAnnulla.Size = New System.Drawing.Size(360, 28)
        Me.btnAnnulla.TabIndex = 1
        Me.btnAnnulla.Text = "Annulla"
        Me.btnAnnulla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnnulla.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(360, 98)
        Me.Controls.Add(Me.lbMessaggio)
        Me.Controls.Add(Me.btnAnnulla)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbMessaggio As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnAnnulla As System.Windows.Forms.Button
End Class
