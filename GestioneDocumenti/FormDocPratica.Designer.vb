<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDocPratica
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
        Me.ListBoxDocumenti = New System.Windows.Forms.ListBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbHelp = New System.Windows.Forms.Label()
        Me.CheckBoxTopMost = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBoxDocumenti
        '
        Me.ListBoxDocumenti.AllowDrop = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.ListBoxDocumenti, 2)
        Me.ListBoxDocumenti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxDocumenti.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxDocumenti.FormattingEnabled = True
        Me.ListBoxDocumenti.IntegralHeight = False
        Me.ListBoxDocumenti.ItemHeight = 16
        Me.ListBoxDocumenti.Location = New System.Drawing.Point(3, 4)
        Me.ListBoxDocumenti.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListBoxDocumenti.Name = "ListBoxDocumenti"
        Me.ListBoxDocumenti.Size = New System.Drawing.Size(378, 234)
        Me.ListBoxDocumenti.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ListBoxDocumenti, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbHelp, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxTopMost, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.53755!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.46245!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(384, 274)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lbHelp
        '
        Me.lbHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbHelp.Location = New System.Drawing.Point(3, 242)
        Me.lbHelp.Name = "lbHelp"
        Me.lbHelp.Size = New System.Drawing.Size(331, 32)
        Me.lbHelp.TabIndex = 1
        Me.lbHelp.Text = "Trascinate nella finestra i file da copiare"
        Me.lbHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBoxTopMost
        '
        Me.CheckBoxTopMost.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxTopMost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxTopMost.Location = New System.Drawing.Point(340, 245)
        Me.CheckBoxTopMost.Name = "CheckBoxTopMost"
        Me.CheckBoxTopMost.Size = New System.Drawing.Size(41, 26)
        Me.CheckBoxTopMost.TabIndex = 2
        Me.CheckBoxTopMost.UseVisualStyleBackColor = True
        '
        'FormDocPratica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 274)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FormDocPratica"
        Me.Text = "FormDocPratica"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBoxDocumenti As System.Windows.Forms.ListBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbHelp As System.Windows.Forms.Label
    Friend WithEvents CheckBoxTopMost As System.Windows.Forms.CheckBox
End Class
