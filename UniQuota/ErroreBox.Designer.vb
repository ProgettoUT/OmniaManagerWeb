<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErroreBox
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.grdMessaggi = New System.Windows.Forms.DataGridView
        Me.colIcona = New System.Windows.Forms.DataGridViewImageColumn
        Me.colMessaggio = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.grdMessaggi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdMessaggi
        '
        Me.grdMessaggi.AllowUserToAddRows = False
        Me.grdMessaggi.AllowUserToDeleteRows = False
        Me.grdMessaggi.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grdMessaggi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdMessaggi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIcona, Me.colMessaggio})
        Me.grdMessaggi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMessaggi.Location = New System.Drawing.Point(0, 0)
        Me.grdMessaggi.Name = "grdMessaggi"
        Me.grdMessaggi.ReadOnly = True
        Me.grdMessaggi.Size = New System.Drawing.Size(639, 104)
        Me.grdMessaggi.TabIndex = 0
        '
        'colIcona
        '
        Me.colIcona.HeaderText = ""
        Me.colIcona.Name = "colIcona"
        Me.colIcona.ReadOnly = True
        Me.colIcona.Width = 25
        '
        'colMessaggio
        '
        Me.colMessaggio.HeaderText = "Descrizione"
        Me.colMessaggio.MinimumWidth = 1000
        Me.colMessaggio.Name = "colMessaggio"
        Me.colMessaggio.ReadOnly = True
        Me.colMessaggio.Width = 1000
        '
        'ErroreBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grdMessaggi)
        Me.Name = "ErroreBox"
        Me.Size = New System.Drawing.Size(639, 104)
        CType(Me.grdMessaggi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdMessaggi As System.Windows.Forms.DataGridView
    Friend WithEvents colIcona As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colMessaggio As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
