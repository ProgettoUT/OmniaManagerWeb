<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAttesa
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
        Me.LabelMessaggio = New System.Windows.Forms.Label()
        Me.ButtonContinua = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelMessaggio, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonContinua, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnnulla, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(396, 108)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'LabelMessaggio
        '
        Me.LabelMessaggio.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelMessaggio, 2)
        Me.LabelMessaggio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMessaggio.Location = New System.Drawing.Point(3, 0)
        Me.LabelMessaggio.Name = "LabelMessaggio"
        Me.LabelMessaggio.Size = New System.Drawing.Size(390, 68)
        Me.LabelMessaggio.TabIndex = 0
        Me.LabelMessaggio.Text = "Label1"
        Me.LabelMessaggio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonContinua
        '
        Me.ButtonContinua.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonContinua.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonContinua.FlatAppearance.BorderSize = 0
        Me.ButtonContinua.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonContinua.Location = New System.Drawing.Point(0, 68)
        Me.ButtonContinua.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonContinua.Name = "ButtonContinua"
        Me.ButtonContinua.Size = New System.Drawing.Size(277, 40)
        Me.ButtonContinua.TabIndex = 1
        Me.ButtonContinua.Text = "Button1"
        Me.ButtonContinua.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAnnulla.FlatAppearance.BorderSize = 0
        Me.ButtonAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnnulla.Location = New System.Drawing.Point(277, 68)
        Me.ButtonAnnulla.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(119, 40)
        Me.ButtonAnnulla.TabIndex = 2
        Me.ButtonAnnulla.Text = "Button2"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'FormAttesa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 108)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormAttesa"
        Me.Text = "FormAttesa"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelMessaggio As System.Windows.Forms.Label
    Friend WithEvents ButtonContinua As System.Windows.Forms.Button
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
End Class
