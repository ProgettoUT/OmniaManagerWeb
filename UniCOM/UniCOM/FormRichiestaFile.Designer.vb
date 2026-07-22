<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRichiestaFile
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
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.ButtonModello = New System.Windows.Forms.Button()
        Me.ButtonSfoglia = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelInfo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonModello, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSfoglia, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(480, 252)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelInfo, 2)
        Me.LabelInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfo.Location = New System.Drawing.Point(3, 0)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(474, 172)
        Me.LabelInfo.TabIndex = 0
        Me.LabelInfo.Text = "Label1"
        '
        'ButtonModello
        '
        Me.ButtonModello.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonModello.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonModello.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonModello.Location = New System.Drawing.Point(0, 172)
        Me.ButtonModello.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonModello.Name = "ButtonModello"
        Me.ButtonModello.Size = New System.Drawing.Size(240, 40)
        Me.ButtonModello.TabIndex = 1
        Me.ButtonModello.Text = "Button1"
        Me.ButtonModello.UseVisualStyleBackColor = True
        '
        'ButtonSfoglia
        '
        Me.ButtonSfoglia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSfoglia.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonSfoglia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSfoglia.Location = New System.Drawing.Point(240, 172)
        Me.ButtonSfoglia.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonSfoglia.Name = "ButtonSfoglia"
        Me.ButtonSfoglia.Size = New System.Drawing.Size(240, 40)
        Me.ButtonSfoglia.TabIndex = 2
        Me.ButtonSfoglia.Text = "Button2"
        Me.ButtonSfoglia.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonEsci, 2)
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsci.Location = New System.Drawing.Point(0, 212)
        Me.ButtonEsci.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(480, 40)
        Me.ButtonEsci.TabIndex = 3
        Me.ButtonEsci.Text = "Button3"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'FormRichiestaFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 252)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormRichiestaFile"
        Me.Text = "FormRichiestaFile"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents ButtonModello As System.Windows.Forms.Button
    Friend WithEvents ButtonSfoglia As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
End Class
