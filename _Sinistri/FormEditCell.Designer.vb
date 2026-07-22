<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditCell
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelCampo = New System.Windows.Forms.Label()
        Me.TextBoxValore = New System.Windows.Forms.TextBox()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelCampo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxValore, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonOk, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnnulla, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(411, 55)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'LabelCampo
        '
        Me.LabelCampo.AutoSize = True
        Me.LabelCampo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCampo.Location = New System.Drawing.Point(3, 0)
        Me.LabelCampo.Name = "LabelCampo"
        Me.LabelCampo.Size = New System.Drawing.Size(245, 28)
        Me.LabelCampo.TabIndex = 2
        Me.LabelCampo.Text = "Label1"
        Me.LabelCampo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TextBoxValore
        '
        Me.TextBoxValore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxValore.Location = New System.Drawing.Point(3, 31)
        Me.TextBoxValore.Name = "TextBoxValore"
        Me.TextBoxValore.Size = New System.Drawing.Size(245, 20)
        Me.TextBoxValore.TabIndex = 1
        '
        'ButtonOk
        '
        Me.ButtonOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOk.Location = New System.Drawing.Point(254, 3)
        Me.ButtonOk.Name = "ButtonOk"
        Me.TableLayoutPanel1.SetRowSpan(Me.ButtonOk, 2)
        Me.ButtonOk.Size = New System.Drawing.Size(74, 49)
        Me.ButtonOk.TabIndex = 0
        Me.ButtonOk.Text = "Button1"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.Location = New System.Drawing.Point(334, 3)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.TableLayoutPanel1.SetRowSpan(Me.ButtonAnnulla, 2)
        Me.ButtonAnnulla.Size = New System.Drawing.Size(74, 49)
        Me.ButtonAnnulla.TabIndex = 3
        Me.ButtonAnnulla.Text = "Button1"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'FormEditCell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 55)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FormEditCell"
        Me.Text = "FormEditCell"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents TextBoxValore As System.Windows.Forms.TextBox
    Friend WithEvents LabelCampo As System.Windows.Forms.Label
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
End Class
