<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFirma
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
        Me.TextBoxFirma = New System.Windows.Forms.TextBox()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.ButtonSalva = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxFirma, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnnulla, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSalva, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(356, 232)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TextBoxFirma
        '
        Me.TextBoxFirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxFirma, 2)
        Me.TextBoxFirma.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxFirma.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxFirma.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxFirma.Multiline = True
        Me.TextBoxFirma.Name = "TextBoxFirma"
        Me.TextBoxFirma.Size = New System.Drawing.Size(356, 192)
        Me.TextBoxFirma.TabIndex = 1
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnnulla.Location = New System.Drawing.Point(179, 193)
        Me.ButtonAnnulla.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(176, 38)
        Me.ButtonAnnulla.TabIndex = 3
        Me.ButtonAnnulla.Text = "Button1"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'ButtonSalva
        '
        Me.ButtonSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSalva.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSalva.Location = New System.Drawing.Point(1, 193)
        Me.ButtonSalva.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonSalva.Name = "ButtonSalva"
        Me.ButtonSalva.Size = New System.Drawing.Size(176, 38)
        Me.ButtonSalva.TabIndex = 2
        Me.ButtonSalva.Text = "Button2"
        Me.ButtonSalva.UseVisualStyleBackColor = True
        '
        'FormFirma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 232)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormFirma"
        Me.Text = "FormFirma"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxFirma As System.Windows.Forms.TextBox
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
    Friend WithEvents ButtonSalva As System.Windows.Forms.Button
End Class
