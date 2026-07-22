<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBanner
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
        Me.wbBanner = New System.Windows.Forms.WebBrowser()
        Me.ButtonChiudi = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'wbBanner
        '
        Me.wbBanner.Location = New System.Drawing.Point(12, 3)
        Me.wbBanner.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbBanner.Name = "wbBanner"
        Me.wbBanner.ScrollBarsEnabled = False
        Me.wbBanner.Size = New System.Drawing.Size(668, 134)
        Me.wbBanner.TabIndex = 0
        '
        'ButtonChiudi
        '
        Me.ButtonChiudi.BackColor = System.Drawing.Color.DodgerBlue
        Me.ButtonChiudi.FlatAppearance.BorderSize = 0
        Me.ButtonChiudi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonChiudi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonChiudi.Location = New System.Drawing.Point(444, 22)
        Me.ButtonChiudi.Name = "ButtonChiudi"
        Me.ButtonChiudi.Size = New System.Drawing.Size(20, 20)
        Me.ButtonChiudi.TabIndex = 1
        Me.ButtonChiudi.Text = "X"
        Me.ButtonChiudi.UseVisualStyleBackColor = False
        '
        'FormBanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 134)
        Me.Controls.Add(Me.ButtonChiudi)
        Me.Controls.Add(Me.wbBanner)
        Me.Name = "FormBanner"
        Me.Text = "FormBanner"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wbBanner As System.Windows.Forms.WebBrowser
    Friend WithEvents ButtonChiudi As System.Windows.Forms.Button
End Class
