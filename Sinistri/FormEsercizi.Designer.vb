<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEsercizi
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
        Me.CheckedListBoxEsercizi = New System.Windows.Forms.CheckedListBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.CheckedListBoxMesi = New System.Windows.Forms.CheckedListBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckedListBoxEsercizi
        '
        Me.CheckedListBoxEsercizi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CheckedListBoxEsercizi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxEsercizi.FormattingEnabled = True
        Me.CheckedListBoxEsercizi.IntegralHeight = False
        Me.CheckedListBoxEsercizi.Location = New System.Drawing.Point(0, 0)
        Me.CheckedListBoxEsercizi.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckedListBoxEsercizi.Name = "CheckedListBoxEsercizi"
        Me.CheckedListBoxEsercizi.Size = New System.Drawing.Size(138, 269)
        Me.CheckedListBoxEsercizi.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CheckedListBoxMesi, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckedListBoxEsercizi, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonOk, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnnulla, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(276, 299)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'ButtonOk
        '
        Me.ButtonOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOk.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOk.Location = New System.Drawing.Point(0, 269)
        Me.ButtonOk.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(138, 30)
        Me.ButtonOk.TabIndex = 1
        Me.ButtonOk.Text = "Button1"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAnnulla.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnnulla.Location = New System.Drawing.Point(138, 269)
        Me.ButtonAnnulla.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(138, 30)
        Me.ButtonAnnulla.TabIndex = 2
        Me.ButtonAnnulla.Text = "Button2"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'CheckedListBoxMesi
        '
        Me.CheckedListBoxMesi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CheckedListBoxMesi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxMesi.FormattingEnabled = True
        Me.CheckedListBoxMesi.IntegralHeight = False
        Me.CheckedListBoxMesi.Location = New System.Drawing.Point(138, 0)
        Me.CheckedListBoxMesi.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckedListBoxMesi.Name = "CheckedListBoxMesi"
        Me.CheckedListBoxMesi.Size = New System.Drawing.Size(138, 269)
        Me.CheckedListBoxMesi.TabIndex = 3
        '
        'FormEsercizi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(276, 299)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormEsercizi"
        Me.Text = "FormEsercizi"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CheckedListBoxEsercizi As System.Windows.Forms.CheckedListBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
    Friend WithEvents CheckedListBoxMesi As System.Windows.Forms.CheckedListBox
End Class
