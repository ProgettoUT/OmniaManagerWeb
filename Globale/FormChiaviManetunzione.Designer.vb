<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormChiaviManetunzione
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
        Me.ListViewChiavi = New System.Windows.Forms.ListView()
        Me.ButtonEsegui = New System.Windows.Forms.Button()
        Me.ButtonCartellaFlag = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ListViewChiavi, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsegui, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCartellaFlag, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(486, 461)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ListViewChiavi
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ListViewChiavi, 3)
        Me.ListViewChiavi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewChiavi.Location = New System.Drawing.Point(3, 3)
        Me.ListViewChiavi.Name = "ListViewChiavi"
        Me.ListViewChiavi.Size = New System.Drawing.Size(480, 415)
        Me.ListViewChiavi.TabIndex = 0
        Me.ListViewChiavi.UseCompatibleStateImageBehavior = False
        '
        'ButtonEsegui
        '
        Me.ButtonEsegui.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsegui.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonEsegui.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsegui.Location = New System.Drawing.Point(0, 421)
        Me.ButtonEsegui.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEsegui.Name = "ButtonEsegui"
        Me.ButtonEsegui.Size = New System.Drawing.Size(291, 40)
        Me.ButtonEsegui.TabIndex = 1
        Me.ButtonEsegui.Text = "Esegui manutenzione selezionata"
        Me.ButtonEsegui.UseVisualStyleBackColor = True
        '
        'ButtonCartellaFlag
        '
        Me.ButtonCartellaFlag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCartellaFlag.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonCartellaFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCartellaFlag.Location = New System.Drawing.Point(291, 421)
        Me.ButtonCartellaFlag.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCartellaFlag.Name = "ButtonCartellaFlag"
        Me.ButtonCartellaFlag.Size = New System.Drawing.Size(97, 40)
        Me.ButtonCartellaFlag.TabIndex = 2
        Me.ButtonCartellaFlag.Text = "Cartella flag"
        Me.ButtonCartellaFlag.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsci.Location = New System.Drawing.Point(388, 421)
        Me.ButtonEsci.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(98, 40)
        Me.ButtonEsci.TabIndex = 3
        Me.ButtonEsci.Text = "Esci"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'FormChiaviManetunzione
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormChiaviManetunzione"
        Me.Text = "FormChiaviManetunzione"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ListBoxChiavi As System.Windows.Forms.ListBox
    Friend WithEvents ListViewChiavi As System.Windows.Forms.ListView
    Friend WithEvents ButtonEsegui As System.Windows.Forms.Button
    Friend WithEvents ButtonCartellaFlag As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
End Class
