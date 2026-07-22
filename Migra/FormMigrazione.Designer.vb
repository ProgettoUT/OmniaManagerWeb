<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMigrazione
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
        Me.buttonMigra = New UtControls.UtFlatButton()
        Me.lblMessaggio = New System.Windows.Forms.Label()
        Me.ButtonLog = New UtControls.UtFlatButton()
        Me.SuspendLayout()
        '
        'buttonMigra
        '
        Me.buttonMigra.DefaultBorderSize = 0
        Me.buttonMigra.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.buttonMigra.FlatAppearance.BorderSize = 0
        Me.buttonMigra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.buttonMigra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonMigra.Location = New System.Drawing.Point(88, 67)
        Me.buttonMigra.Margin = New System.Windows.Forms.Padding(0)
        Me.buttonMigra.Name = "buttonMigra"
        Me.buttonMigra.Size = New System.Drawing.Size(239, 105)
        Me.buttonMigra.TabIndex = 0
        Me.buttonMigra.Text = "Aggiorna unitools a SqlServer"
        Me.buttonMigra.UseVisualStyleBackColor = True
        '
        'lblMessaggio
        '
        Me.lblMessaggio.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMessaggio.Location = New System.Drawing.Point(0, 266)
        Me.lblMessaggio.Name = "lblMessaggio"
        Me.lblMessaggio.Size = New System.Drawing.Size(423, 29)
        Me.lblMessaggio.TabIndex = 1
        Me.lblMessaggio.Text = "descrizione operazione"
        Me.lblMessaggio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonLog
        '
        Me.ButtonLog.DefaultBorderSize = 0
        Me.ButtonLog.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonLog.FlatAppearance.BorderSize = 0
        Me.ButtonLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLog.Location = New System.Drawing.Point(88, 188)
        Me.ButtonLog.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonLog.Name = "ButtonLog"
        Me.ButtonLog.Size = New System.Drawing.Size(239, 40)
        Me.ButtonLog.TabIndex = 2
        Me.ButtonLog.Text = "Visualizza log"
        Me.ButtonLog.UseVisualStyleBackColor = True
        '
        'FormMigrazione
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 295)
        Me.Controls.Add(Me.ButtonLog)
        Me.Controls.Add(Me.lblMessaggio)
        Me.Controls.Add(Me.buttonMigra)
        Me.Name = "FormMigrazione"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sql Server"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents buttonMigra As UtControls.UtFlatButton
    Friend WithEvents lblMessaggio As System.Windows.Forms.Label
    Friend WithEvents ButtonLog As UtControls.UtFlatButton

End Class
