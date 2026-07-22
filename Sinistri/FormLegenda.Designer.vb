<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLegenda
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.CheckedListBoxLegenda = New System.Windows.Forms.CheckedListBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelSinistro = New System.Windows.Forms.Label()
        Me.ButtonSalva = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckedListBoxLegenda
        '
        Me.CheckedListBoxLegenda.BackColor = System.Drawing.Color.Beige
        Me.CheckedListBoxLegenda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxLegenda.FormattingEnabled = True
        Me.CheckedListBoxLegenda.IntegralHeight = False
        Me.CheckedListBoxLegenda.Location = New System.Drawing.Point(3, 43)
        Me.CheckedListBoxLegenda.Name = "CheckedListBoxLegenda"
        Me.CheckedListBoxLegenda.Size = New System.Drawing.Size(462, 364)
        Me.CheckedListBoxLegenda.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CheckedListBoxLegenda, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelSinistro, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSalva, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(468, 450)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'LabelSinistro
        '
        Me.LabelSinistro.AutoSize = True
        Me.LabelSinistro.BackColor = System.Drawing.SystemColors.Control
        Me.LabelSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSinistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelSinistro.Location = New System.Drawing.Point(0, 0)
        Me.LabelSinistro.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelSinistro.Name = "LabelSinistro"
        Me.LabelSinistro.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.LabelSinistro.Size = New System.Drawing.Size(468, 40)
        Me.LabelSinistro.TabIndex = 1
        Me.LabelSinistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonSalva
        '
        Me.ButtonSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSalva.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSalva.Location = New System.Drawing.Point(0, 410)
        Me.ButtonSalva.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ButtonSalva.Name = "ButtonSalva"
        Me.ButtonSalva.Padding = New System.Windows.Forms.Padding(20, 0, 20, 0)
        Me.ButtonSalva.Size = New System.Drawing.Size(465, 40)
        Me.ButtonSalva.TabIndex = 2
        Me.ButtonSalva.Text = "Salva"
        Me.ButtonSalva.UseVisualStyleBackColor = True
        '
        'FormLegenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FormLegenda"
        Me.Text = "FormGruppi"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CheckedListBoxLegenda As Windows.Forms.CheckedListBox
    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelSinistro As Windows.Forms.Label
    Friend WithEvents ButtonSalva As Windows.Forms.Button
End Class
