<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRubrica
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonAggiungi = New System.Windows.Forms.Button()
        Me.ButtonElimina = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.ListBoxEmail = New System.Windows.Forms.ListBox()
        Me.ButtonSeleziona = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 3)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(515, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Digitare l'indirizzo da cercare o modificare"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonAggiungi
        '
        Me.ButtonAggiungi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiungi.Location = New System.Drawing.Point(419, 28)
        Me.ButtonAggiungi.Name = "ButtonAggiungi"
        Me.ButtonAggiungi.Size = New System.Drawing.Size(99, 19)
        Me.ButtonAggiungi.TabIndex = 3
        Me.ButtonAggiungi.Text = "Aggiungi"
        Me.ButtonAggiungi.UseVisualStyleBackColor = True
        '
        'ButtonElimina
        '
        Me.ButtonElimina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonElimina.Location = New System.Drawing.Point(211, 328)
        Me.ButtonElimina.Name = "ButtonElimina"
        Me.ButtonElimina.Size = New System.Drawing.Size(202, 29)
        Me.ButtonElimina.TabIndex = 4
        Me.ButtonElimina.Text = "Elimina"
        Me.ButtonElimina.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonElimina, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAggiungi, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxEmail, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ListBoxEmail, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSeleziona, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(521, 360)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.Location = New System.Drawing.Point(419, 328)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(99, 29)
        Me.ButtonEsci.TabIndex = 6
        Me.ButtonEsci.Text = "Button1"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'TextBoxEmail
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxEmail, 2)
        Me.TextBoxEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxEmail.Location = New System.Drawing.Point(3, 28)
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(410, 22)
        Me.TextBoxEmail.TabIndex = 7
        '
        'ListBoxEmail
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ListBoxEmail, 3)
        Me.ListBoxEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxEmail.FormattingEnabled = True
        Me.ListBoxEmail.ItemHeight = 14
        Me.ListBoxEmail.Location = New System.Drawing.Point(3, 53)
        Me.ListBoxEmail.Name = "ListBoxEmail"
        Me.ListBoxEmail.Size = New System.Drawing.Size(515, 269)
        Me.ListBoxEmail.TabIndex = 8
        '
        'ButtonSeleziona
        '
        Me.ButtonSeleziona.Location = New System.Drawing.Point(3, 328)
        Me.ButtonSeleziona.Name = "ButtonSeleziona"
        Me.ButtonSeleziona.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSeleziona.TabIndex = 9
        Me.ButtonSeleziona.Text = "Button1"
        Me.ButtonSeleziona.UseVisualStyleBackColor = True
        '
        'FormRubrica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 366)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRubrica"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmRubrica"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonAggiungi As System.Windows.Forms.Button
    Friend WithEvents ButtonElimina As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents TextBoxEmail As System.Windows.Forms.TextBox
    Friend WithEvents ListBoxEmail As System.Windows.Forms.ListBox
    Friend WithEvents ButtonSeleziona As System.Windows.Forms.Button
End Class
