<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInvio
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
        Me.ButtonStampa = New System.Windows.Forms.Button()
        Me.ButtonArchivia = New System.Windows.Forms.Button()
        Me.CheckedListBoxBuste = New System.Windows.Forms.CheckedListBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonStampa, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonArchivia, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckedListBoxBuste, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(424, 256)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ButtonStampa
        '
        Me.ButtonStampa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonStampa.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonStampa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStampa.Location = New System.Drawing.Point(0, 206)
        Me.ButtonStampa.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonStampa.Name = "ButtonStampa"
        Me.ButtonStampa.Size = New System.Drawing.Size(212, 50)
        Me.ButtonStampa.TabIndex = 0
        Me.ButtonStampa.Text = "Button1"
        Me.ButtonStampa.UseVisualStyleBackColor = True
        '
        'ButtonArchivia
        '
        Me.ButtonArchivia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonArchivia.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonArchivia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonArchivia.Location = New System.Drawing.Point(212, 206)
        Me.ButtonArchivia.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonArchivia.Name = "ButtonArchivia"
        Me.ButtonArchivia.Size = New System.Drawing.Size(212, 50)
        Me.ButtonArchivia.TabIndex = 1
        Me.ButtonArchivia.Text = "Button2"
        Me.ButtonArchivia.UseVisualStyleBackColor = True
        '
        'CheckedListBoxBuste
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.CheckedListBoxBuste, 2)
        Me.CheckedListBoxBuste.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxBuste.FormattingEnabled = True
        Me.CheckedListBoxBuste.Location = New System.Drawing.Point(3, 3)
        Me.CheckedListBoxBuste.Name = "CheckedListBoxBuste"
        Me.CheckedListBoxBuste.Size = New System.Drawing.Size(418, 200)
        Me.CheckedListBoxBuste.TabIndex = 2
        '
        'FormInvio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 256)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormInvio"
        Me.Text = "FormInvio"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonStampa As System.Windows.Forms.Button
    Friend WithEvents ButtonArchivia As System.Windows.Forms.Button
    Friend WithEvents CheckedListBoxBuste As System.Windows.Forms.CheckedListBox
End Class
