<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametri
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
        Me.cmdAnnulla = New System.Windows.Forms.Button()
        Me.cmdConferma = New System.Windows.Forms.Button()
        Me.Frame_Ricerca = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdAnnulla
        '
        Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdAnnulla.Location = New System.Drawing.Point(94, 10)
        Me.cmdAnnulla.Name = "cmdAnnulla"
        Me.cmdAnnulla.Size = New System.Drawing.Size(75, 23)
        Me.cmdAnnulla.TabIndex = 1
        Me.cmdAnnulla.Text = "Annulla"
        Me.cmdAnnulla.UseVisualStyleBackColor = True
        '
        'cmdConferma
        '
        Me.cmdConferma.Location = New System.Drawing.Point(237, 10)
        Me.cmdConferma.Name = "cmdConferma"
        Me.cmdConferma.Size = New System.Drawing.Size(75, 23)
        Me.cmdConferma.TabIndex = 2
        Me.cmdConferma.Text = "Conferma"
        Me.cmdConferma.UseVisualStyleBackColor = True
        '
        'Frame_Ricerca
        '
        Me.Frame_Ricerca.Dock = System.Windows.Forms.DockStyle.Top
        Me.Frame_Ricerca.Location = New System.Drawing.Point(10, 10)
        Me.Frame_Ricerca.Name = "Frame_Ricerca"
        Me.Frame_Ricerca.Size = New System.Drawing.Size(401, 317)
        Me.Frame_Ricerca.TabIndex = 3
        Me.Frame_Ricerca.TabStop = False
        Me.Frame_Ricerca.Text = "Parametri"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdAnnulla)
        Me.Panel1.Controls.Add(Me.cmdConferma)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(10, 343)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(401, 40)
        Me.Panel1.TabIndex = 4
        '
        'frmParametri
        '
        Me.AcceptButton = Me.cmdConferma
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdAnnulla
        Me.ClientSize = New System.Drawing.Size(421, 393)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Frame_Ricerca)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmParametri"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inserisci i parametri"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
    Friend WithEvents cmdConferma As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Frame_Ricerca As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
