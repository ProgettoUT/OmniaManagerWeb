<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EssigForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdChiudi = New System.Windows.Forms.Button()
        Me.essigLblQuota = New System.Windows.Forms.Label()
        Me.essigLbl0 = New System.Windows.Forms.Label()
        Me.essigLblScarto = New System.Windows.Forms.Label()
        Me.essigLbl2 = New System.Windows.Forms.Label()
        Me.essigLbl1 = New System.Windows.Forms.Label()
        Me.essigLblPremio = New System.Windows.Forms.Label()
        Me.lblTesto = New System.Windows.Forms.Label()
        Me.WaitProgressBar = New System.Windows.Forms.ProgressBar()
        Me.lblMessaggi = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdChiudi
        '
        Me.cmdChiudi.Location = New System.Drawing.Point(203, 218)
        Me.cmdChiudi.Name = "cmdChiudi"
        Me.cmdChiudi.Size = New System.Drawing.Size(148, 35)
        Me.cmdChiudi.TabIndex = 0
        Me.cmdChiudi.Text = "Chiudi"
        Me.cmdChiudi.UseVisualStyleBackColor = True
        '
        'essigLblQuota
        '
        Me.essigLblQuota.BackColor = System.Drawing.Color.Transparent
        Me.essigLblQuota.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.essigLblQuota.ForeColor = System.Drawing.SystemColors.ControlText
        Me.essigLblQuota.Location = New System.Drawing.Point(307, 117)
        Me.essigLblQuota.Name = "essigLblQuota"
        Me.essigLblQuota.Size = New System.Drawing.Size(200, 30)
        Me.essigLblQuota.TabIndex = 74
        Me.essigLblQuota.Text = " 0,00"
        Me.essigLblQuota.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.essigLblQuota.Visible = False
        '
        'essigLbl0
        '
        Me.essigLbl0.BackColor = System.Drawing.Color.Transparent
        Me.essigLbl0.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.essigLbl0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.essigLbl0.Location = New System.Drawing.Point(47, 117)
        Me.essigLbl0.Margin = New System.Windows.Forms.Padding(0)
        Me.essigLbl0.Name = "essigLbl0"
        Me.essigLbl0.Size = New System.Drawing.Size(248, 30)
        Me.essigLbl0.TabIndex = 73
        Me.essigLbl0.Text = "Premio Quotatore"
        Me.essigLbl0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.essigLbl0.Visible = False
        '
        'essigLblScarto
        '
        Me.essigLblScarto.BackColor = System.Drawing.Color.Transparent
        Me.essigLblScarto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.essigLblScarto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.essigLblScarto.Location = New System.Drawing.Point(307, 177)
        Me.essigLblScarto.Name = "essigLblScarto"
        Me.essigLblScarto.Size = New System.Drawing.Size(200, 30)
        Me.essigLblScarto.TabIndex = 71
        Me.essigLblScarto.Text = "0,00"
        Me.essigLblScarto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.essigLblScarto.Visible = False
        '
        'essigLbl2
        '
        Me.essigLbl2.BackColor = System.Drawing.Color.Transparent
        Me.essigLbl2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.essigLbl2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.essigLbl2.Location = New System.Drawing.Point(47, 177)
        Me.essigLbl2.Margin = New System.Windows.Forms.Padding(0)
        Me.essigLbl2.Name = "essigLbl2"
        Me.essigLbl2.Size = New System.Drawing.Size(248, 30)
        Me.essigLbl2.TabIndex = 72
        Me.essigLbl2.Text = "Differenza (Quotatore/Essig)"
        Me.essigLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.essigLbl2.Visible = False
        '
        'essigLbl1
        '
        Me.essigLbl1.BackColor = System.Drawing.Color.Transparent
        Me.essigLbl1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.essigLbl1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.essigLbl1.Location = New System.Drawing.Point(47, 147)
        Me.essigLbl1.Margin = New System.Windows.Forms.Padding(0)
        Me.essigLbl1.Name = "essigLbl1"
        Me.essigLbl1.Size = New System.Drawing.Size(248, 30)
        Me.essigLbl1.TabIndex = 70
        Me.essigLbl1.Text = "Premio Essig"
        Me.essigLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.essigLbl1.Visible = False
        '
        'essigLblPremio
        '
        Me.essigLblPremio.BackColor = System.Drawing.Color.Transparent
        Me.essigLblPremio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.essigLblPremio.ForeColor = System.Drawing.SystemColors.ControlText
        Me.essigLblPremio.Location = New System.Drawing.Point(307, 147)
        Me.essigLblPremio.Name = "essigLblPremio"
        Me.essigLblPremio.Size = New System.Drawing.Size(200, 30)
        Me.essigLblPremio.TabIndex = 69
        Me.essigLblPremio.Text = " 0,00"
        Me.essigLblPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.essigLblPremio.Visible = False
        '
        'lblTesto
        '
        Me.lblTesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTesto.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblTesto.Location = New System.Drawing.Point(13, 102)
        Me.lblTesto.Name = "lblTesto"
        Me.lblTesto.Size = New System.Drawing.Size(529, 21)
        Me.lblTesto.TabIndex = 77
        Me.lblTesto.Text = "connessione"
        Me.lblTesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTesto.UseWaitCursor = True
        '
        'WaitProgressBar
        '
        Me.WaitProgressBar.Location = New System.Drawing.Point(13, 74)
        Me.WaitProgressBar.Name = "WaitProgressBar"
        Me.WaitProgressBar.Size = New System.Drawing.Size(529, 25)
        Me.WaitProgressBar.Step = 1
        Me.WaitProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.WaitProgressBar.TabIndex = 76
        Me.WaitProgressBar.UseWaitCursor = True
        '
        'lblMessaggi
        '
        Me.lblMessaggi.AutoEllipsis = True
        Me.lblMessaggi.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessaggi.Location = New System.Drawing.Point(11, -1)
        Me.lblMessaggi.Name = "lblMessaggi"
        Me.lblMessaggi.Size = New System.Drawing.Size(531, 72)
        Me.lblMessaggi.TabIndex = 75
        Me.lblMessaggi.Text = "Sto salvando il preventivo in Essig ..."
        Me.lblMessaggi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMessaggi.UseWaitCursor = True
        '
        'EssigForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 260)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTesto)
        Me.Controls.Add(Me.WaitProgressBar)
        Me.Controls.Add(Me.lblMessaggi)
        Me.Controls.Add(Me.essigLblQuota)
        Me.Controls.Add(Me.essigLbl0)
        Me.Controls.Add(Me.cmdChiudi)
        Me.Controls.Add(Me.essigLblPremio)
        Me.Controls.Add(Me.essigLbl2)
        Me.Controls.Add(Me.essigLbl1)
        Me.Controls.Add(Me.essigLblScarto)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EssigForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Salva in Essig"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdChiudi As System.Windows.Forms.Button
    Friend WithEvents essigLblQuota As System.Windows.Forms.Label
    Friend WithEvents essigLbl0 As System.Windows.Forms.Label
    Friend WithEvents essigLblScarto As System.Windows.Forms.Label
    Friend WithEvents essigLbl2 As System.Windows.Forms.Label
    Friend WithEvents essigLbl1 As System.Windows.Forms.Label
    Friend WithEvents essigLblPremio As System.Windows.Forms.Label
    Friend WithEvents lblTesto As System.Windows.Forms.Label
    Friend WithEvents WaitProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblMessaggi As System.Windows.Forms.Label
End Class
