<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUtenti
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
        Me.ButtonDeseleziona = New System.Windows.Forms.Button()
        Me.ButtonSeleziona = New System.Windows.Forms.Button()
        Me.ButtonSalva = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.CheckedListBoxUtenze = New System.Windows.Forms.CheckedListBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonDeseleziona, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSeleziona, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSalva, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnnulla, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckedListBoxUtenze, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(384, 465)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ButtonDeseleziona
        '
        Me.ButtonDeseleziona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonDeseleziona.Location = New System.Drawing.Point(195, 3)
        Me.ButtonDeseleziona.Name = "ButtonDeseleziona"
        Me.ButtonDeseleziona.Size = New System.Drawing.Size(186, 19)
        Me.ButtonDeseleziona.TabIndex = 13
        Me.ButtonDeseleziona.Text = "Button1"
        Me.ButtonDeseleziona.UseVisualStyleBackColor = True
        '
        'ButtonSeleziona
        '
        Me.ButtonSeleziona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSeleziona.Location = New System.Drawing.Point(3, 3)
        Me.ButtonSeleziona.Name = "ButtonSeleziona"
        Me.ButtonSeleziona.Size = New System.Drawing.Size(186, 19)
        Me.ButtonSeleziona.TabIndex = 12
        Me.ButtonSeleziona.Text = "Button2"
        Me.ButtonSeleziona.UseVisualStyleBackColor = True
        '
        'ButtonSalva
        '
        Me.ButtonSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSalva.Location = New System.Drawing.Point(195, 428)
        Me.ButtonSalva.Name = "ButtonSalva"
        Me.ButtonSalva.Size = New System.Drawing.Size(186, 34)
        Me.ButtonSalva.TabIndex = 2
        Me.ButtonSalva.Text = "Button1"
        Me.ButtonSalva.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.Location = New System.Drawing.Point(3, 428)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(186, 34)
        Me.ButtonAnnulla.TabIndex = 3
        Me.ButtonAnnulla.Text = "Button2"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'CheckedListBoxUtenze
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.CheckedListBoxUtenze, 2)
        Me.CheckedListBoxUtenze.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxUtenze.FormattingEnabled = True
        Me.CheckedListBoxUtenze.Location = New System.Drawing.Point(3, 28)
        Me.CheckedListBoxUtenze.Name = "CheckedListBoxUtenze"
        Me.CheckedListBoxUtenze.Size = New System.Drawing.Size(378, 394)
        Me.CheckedListBoxUtenze.TabIndex = 4
        '
        'FormUtenti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 465)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormUtenti"
        Me.Text = "FormUtenti"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonSalva As System.Windows.Forms.Button
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
    Friend WithEvents CheckedListBoxUtenze As System.Windows.Forms.CheckedListBox
    Friend WithEvents ButtonSeleziona As System.Windows.Forms.Button
    Friend WithEvents ButtonDeseleziona As System.Windows.Forms.Button
End Class
