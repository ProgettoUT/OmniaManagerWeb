<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRilevaScanner
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
        Me.Twain = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain()
        Me.SuspendLayout()
        '
        'Twain
        '
        Me.Twain.AnnotationFillColor = System.Drawing.Color.White
        Me.Twain.AnnotationPen = Nothing
        Me.Twain.AnnotationTextColor = System.Drawing.Color.Black
        Me.Twain.AnnotationTextFont = Nothing
        Me.Twain.BorderStyle = Dynamsoft.DotNet.TWAIN.Enums.DWTWndBorderStyle.SingleFlat
        Me.Twain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Twain.IfShowCancelDialogWhenImageTransfer = False
        Me.Twain.IfShowPrintUI = False
        Me.Twain.IfThrowException = False
        Me.Twain.Location = New System.Drawing.Point(0, 0)
        Me.Twain.LogLevel = CType(0, Short)
        Me.Twain.Name = "Twain"
        Me.Twain.PDFMarginBottom = CType(0UI, UInteger)
        Me.Twain.PDFMarginLeft = CType(0UI, UInteger)
        Me.Twain.PDFMarginRight = CType(0UI, UInteger)
        Me.Twain.PDFMarginTop = CType(0UI, UInteger)
        Me.Twain.PDFXConformance = CType(0UI, UInteger)
        Me.Twain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Twain.Size = New System.Drawing.Size(325, 304)
        Me.Twain.TabIndex = 8
        '
        'FormRilevaScanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 304)
        Me.Controls.Add(Me.Twain)
        Me.Name = "FormRilevaScanner"
        Me.Text = "FormRilevaScanner"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Twain As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
End Class
