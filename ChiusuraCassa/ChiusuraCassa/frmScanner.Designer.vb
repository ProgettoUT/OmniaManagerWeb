<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScanner
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
        Me.txtPeriferica = New System.Windows.Forms.TextBox
        Me.btnSelezionaPeriferica = New System.Windows.Forms.Button
        Me.cboRisoluzione = New System.Windows.Forms.ComboBox
        Me.cboTipoScans = New System.Windows.Forms.ComboBox
        Me.chkDuplex = New System.Windows.Forms.CheckBox
        Me.chkCrop = New System.Windows.Forms.CheckBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lbStato = New System.Windows.Forms.ToolStripStatusLabel
        Me.tbChiaroScuro = New System.Windows.Forms.TrackBar
        Me.txtChiaroScuro = New System.Windows.Forms.TextBox
        Me.btnScan = New System.Windows.Forms.Button
        Me.btnSalvaImpo = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.StatusStrip1.SuspendLayout()
        CType(Me.tbChiaroScuro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPeriferica
        '
        Me.txtPeriferica.Location = New System.Drawing.Point(120, 11)
        Me.txtPeriferica.Name = "txtPeriferica"
        Me.txtPeriferica.Size = New System.Drawing.Size(180, 22)
        Me.txtPeriferica.TabIndex = 0
        '
        'btnSelezionaPeriferica
        '
        Me.btnSelezionaPeriferica.Location = New System.Drawing.Point(306, 11)
        Me.btnSelezionaPeriferica.Name = "btnSelezionaPeriferica"
        Me.btnSelezionaPeriferica.Size = New System.Drawing.Size(107, 22)
        Me.btnSelezionaPeriferica.TabIndex = 1
        Me.btnSelezionaPeriferica.Text = "Seleziona"
        Me.btnSelezionaPeriferica.UseVisualStyleBackColor = True
        '
        'cboRisoluzione
        '
        Me.cboRisoluzione.FormattingEnabled = True
        Me.cboRisoluzione.Location = New System.Drawing.Point(120, 67)
        Me.cboRisoluzione.Name = "cboRisoluzione"
        Me.cboRisoluzione.Size = New System.Drawing.Size(293, 22)
        Me.cboRisoluzione.TabIndex = 2
        '
        'cboTipoScans
        '
        Me.cboTipoScans.FormattingEnabled = True
        Me.cboTipoScans.Location = New System.Drawing.Point(120, 39)
        Me.cboTipoScans.Name = "cboTipoScans"
        Me.cboTipoScans.Size = New System.Drawing.Size(293, 22)
        Me.cboTipoScans.TabIndex = 3
        '
        'chkDuplex
        '
        Me.chkDuplex.AutoSize = True
        Me.chkDuplex.Location = New System.Drawing.Point(120, 95)
        Me.chkDuplex.Name = "chkDuplex"
        Me.chkDuplex.Size = New System.Drawing.Size(106, 18)
        Me.chkDuplex.TabIndex = 4
        Me.chkDuplex.Text = "Fronte/Retro"
        Me.chkDuplex.UseVisualStyleBackColor = True
        '
        'chkCrop
        '
        Me.chkCrop.AutoSize = True
        Me.chkCrop.Location = New System.Drawing.Point(120, 119)
        Me.chkCrop.Name = "chkCrop"
        Me.chkCrop.Size = New System.Drawing.Size(137, 18)
        Me.chkCrop.TabIndex = 5
        Me.chkCrop.Text = "Taglio automatico"
        Me.chkCrop.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbStato})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 188)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(582, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbStato
        '
        Me.lbStato.Name = "lbStato"
        Me.lbStato.Size = New System.Drawing.Size(153, 17)
        Me.lbStato.Text = "ToolStripStatusLabel1"
        '
        'tbChiaroScuro
        '
        Me.tbChiaroScuro.Location = New System.Drawing.Point(111, 142)
        Me.tbChiaroScuro.Name = "tbChiaroScuro"
        Me.tbChiaroScuro.Size = New System.Drawing.Size(255, 45)
        Me.tbChiaroScuro.TabIndex = 7
        '
        'txtChiaroScuro
        '
        Me.txtChiaroScuro.Location = New System.Drawing.Point(372, 142)
        Me.txtChiaroScuro.Name = "txtChiaroScuro"
        Me.txtChiaroScuro.Size = New System.Drawing.Size(41, 22)
        Me.txtChiaroScuro.TabIndex = 8
        '
        'btnScan
        '
        Me.btnScan.Location = New System.Drawing.Point(419, 11)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(155, 50)
        Me.btnScan.TabIndex = 9
        Me.btnScan.Text = "Acquisisci"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'btnSalvaImpo
        '
        Me.btnSalvaImpo.Location = New System.Drawing.Point(419, 142)
        Me.btnSalvaImpo.Name = "btnSalvaImpo"
        Me.btnSalvaImpo.Size = New System.Drawing.Size(155, 22)
        Me.btnSalvaImpo.TabIndex = 10
        Me.btnSalvaImpo.Text = "Salva impostazioni"
        Me.btnSalvaImpo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 14)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Periferica"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 14)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Tipo scansione"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 14)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Risoluzione"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 14)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Chiaro/Scuro"
        '
        'frmScanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 210)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSalvaImpo)
        Me.Controls.Add(Me.btnScan)
        Me.Controls.Add(Me.txtChiaroScuro)
        Me.Controls.Add(Me.tbChiaroScuro)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.chkCrop)
        Me.Controls.Add(Me.chkDuplex)
        Me.Controls.Add(Me.cboTipoScans)
        Me.Controls.Add(Me.cboRisoluzione)
        Me.Controls.Add(Me.btnSelezionaPeriferica)
        Me.Controls.Add(Me.txtPeriferica)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frmScanner"
        Me.Text = "Scanner"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.tbChiaroScuro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPeriferica As System.Windows.Forms.TextBox
    Friend WithEvents btnSelezionaPeriferica As System.Windows.Forms.Button
    Friend WithEvents cboRisoluzione As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoScans As System.Windows.Forms.ComboBox
    Friend WithEvents chkDuplex As System.Windows.Forms.CheckBox
    Friend WithEvents chkCrop As System.Windows.Forms.CheckBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbStato As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tbChiaroScuro As System.Windows.Forms.TrackBar
    Friend WithEvents txtChiaroScuro As System.Windows.Forms.TextBox
    Friend WithEvents btnScan As System.Windows.Forms.Button
    Friend WithEvents btnSalvaImpo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
