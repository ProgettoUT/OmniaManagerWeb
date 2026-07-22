<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNota
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
        Me.TextBoxNota = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonSalva = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxNota
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxNota, 2)
        Me.TextBoxNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxNota.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxNota.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxNota.Multiline = True
        Me.TextBoxNota.Name = "TextBoxNota"
        Me.TextBoxNota.Size = New System.Drawing.Size(582, 190)
        Me.TextBoxNota.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxNota, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSalva, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(582, 220)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'ButtonSalva
        '
        Me.ButtonSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSalva.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSalva.Location = New System.Drawing.Point(0, 190)
        Me.ButtonSalva.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonSalva.Name = "ButtonSalva"
        Me.ButtonSalva.Size = New System.Drawing.Size(465, 30)
        Me.ButtonSalva.TabIndex = 1
        Me.ButtonSalva.Text = "Salva"
        Me.ButtonSalva.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsci.Location = New System.Drawing.Point(465, 190)
        Me.ButtonEsci.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(117, 30)
        Me.ButtonEsci.TabIndex = 2
        Me.ButtonEsci.Text = "Esci"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'FormNota
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 220)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormNota"
        Me.Text = "FormNota"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextBoxNota As Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonSalva As Windows.Forms.Button
    Friend WithEvents ButtonEsci As Windows.Forms.Button
End Class
