<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLoginOWeb
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TextBoxUserOW = New System.Windows.Forms.TextBox()
        Me.TextBoxPwOW = New System.Windows.Forms.TextBox()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelMessaggio = New System.Windows.Forms.Label()
        Me.CheckBoxPW = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxUserOW
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxUserOW, 2)
        Me.TextBoxUserOW.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxUserOW.Location = New System.Drawing.Point(77, 55)
        Me.TextBoxUserOW.Name = "TextBoxUserOW"
        Me.TextBoxUserOW.Size = New System.Drawing.Size(179, 20)
        Me.TextBoxUserOW.TabIndex = 0
        '
        'TextBoxPwOW
        '
        Me.TextBoxPwOW.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxPwOW.Location = New System.Drawing.Point(77, 81)
        Me.TextBoxPwOW.Name = "TextBoxPwOW"
        Me.TextBoxPwOW.Size = New System.Drawing.Size(142, 20)
        Me.TextBoxPwOW.TabIndex = 1
        '
        'ButtonOk
        '
        Me.ButtonOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOk.Location = New System.Drawing.Point(261, 54)
        Me.ButtonOk.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOk.Name = "ButtonOk"
        Me.TableLayoutPanel1.SetRowSpan(Me.ButtonOk, 2)
        Me.ButtonOk.Size = New System.Drawing.Size(109, 48)
        Me.ButtonOk.TabIndex = 2
        Me.ButtonOk.Text = "Ok"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.Location = New System.Drawing.Point(261, 106)
        Me.ButtonAnnulla.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(109, 26)
        Me.ButtonAnnulla.TabIndex = 3
        Me.ButtonAnnulla.Text = "Annulla"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxUserOW, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnnulla, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxPwOW, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonOk, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelMessaggio, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxPW, 2, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(372, 134)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 26)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Utente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 26)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Password"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelMessaggio
        '
        Me.LabelMessaggio.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelMessaggio, 4)
        Me.LabelMessaggio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMessaggio.Location = New System.Drawing.Point(3, 0)
        Me.LabelMessaggio.Name = "LabelMessaggio"
        Me.LabelMessaggio.Size = New System.Drawing.Size(366, 52)
        Me.LabelMessaggio.TabIndex = 6
        Me.LabelMessaggio.Text = "Label3"
        '
        'CheckBoxPW
        '
        Me.CheckBoxPW.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxPW.AutoSize = True
        Me.CheckBoxPW.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxPW.Location = New System.Drawing.Point(224, 80)
        Me.CheckBoxPW.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBoxPW.Name = "CheckBoxPW"
        Me.CheckBoxPW.Size = New System.Drawing.Size(33, 22)
        Me.CheckBoxPW.TabIndex = 7
        Me.CheckBoxPW.Text = "A"
        Me.CheckBoxPW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxPW.UseVisualStyleBackColor = True
        '
        'FormLoginOWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 134)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormLoginOWeb"
        Me.Text = "FormLoginOWeb"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextBoxUserOW As Windows.Forms.TextBox
    Friend WithEvents TextBoxPwOW As Windows.Forms.TextBox
    Friend WithEvents ButtonOk As Windows.Forms.Button
    Friend WithEvents ButtonAnnulla As Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents LabelMessaggio As Windows.Forms.Label
    Friend WithEvents CheckBoxPW As Windows.Forms.CheckBox
End Class
