<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormContatti
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
        Me.ButtonOk = New Utx.MyFlatButton()
        Me.ButtonAnnulla = New Utx.MyFlatButton()
        Me.RadioButtonEmail = New System.Windows.Forms.RadioButton()
        Me.RadioButtonSms = New System.Windows.Forms.RadioButton()
        Me.tvContatti = New System.Windows.Forms.TreeView()
        Me.RadioButtonTelefoni = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonOk, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnnulla, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.RadioButtonEmail, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RadioButtonSms, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tvContatti, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.RadioButtonTelefoni, 4, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(364, 353)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'ButtonOk
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonOk, 4)
        Me.ButtonOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOk.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOk.Location = New System.Drawing.Point(0, 313)
        Me.ButtonOk.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(240, 40)
        Me.ButtonOk.TabIndex = 4
        Me.ButtonOk.Text = "MyFlatButton1"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonAnnulla, 2)
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnnulla.Location = New System.Drawing.Point(240, 313)
        Me.ButtonAnnulla.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(124, 40)
        Me.ButtonAnnulla.TabIndex = 5
        Me.ButtonAnnulla.Text = "MyFlatButton2"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'RadioButtonEmail
        '
        Me.RadioButtonEmail.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButtonEmail.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.RadioButtonEmail, 2)
        Me.RadioButtonEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonEmail.Location = New System.Drawing.Point(3, 3)
        Me.RadioButtonEmail.Name = "RadioButtonEmail"
        Me.RadioButtonEmail.Size = New System.Drawing.Size(114, 34)
        Me.RadioButtonEmail.TabIndex = 6
        Me.RadioButtonEmail.Text = "RadioButton1"
        Me.RadioButtonEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButtonEmail.UseVisualStyleBackColor = True
        '
        'RadioButtonSms
        '
        Me.RadioButtonSms.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButtonSms.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.RadioButtonSms, 2)
        Me.RadioButtonSms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonSms.Location = New System.Drawing.Point(123, 3)
        Me.RadioButtonSms.Name = "RadioButtonSms"
        Me.RadioButtonSms.Size = New System.Drawing.Size(114, 34)
        Me.RadioButtonSms.TabIndex = 7
        Me.RadioButtonSms.Text = "RadioButton2"
        Me.RadioButtonSms.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButtonSms.UseVisualStyleBackColor = True
        '
        'tvContatti
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.tvContatti, 6)
        Me.tvContatti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvContatti.Location = New System.Drawing.Point(0, 40)
        Me.tvContatti.Margin = New System.Windows.Forms.Padding(0)
        Me.tvContatti.Name = "tvContatti"
        Me.tvContatti.Size = New System.Drawing.Size(364, 273)
        Me.tvContatti.TabIndex = 8
        '
        'RadioButtonTelefoni
        '
        Me.RadioButtonTelefoni.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButtonTelefoni.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.RadioButtonTelefoni, 2)
        Me.RadioButtonTelefoni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonTelefoni.Location = New System.Drawing.Point(243, 3)
        Me.RadioButtonTelefoni.Name = "RadioButtonTelefoni"
        Me.RadioButtonTelefoni.Size = New System.Drawing.Size(118, 34)
        Me.RadioButtonTelefoni.TabIndex = 9
        Me.RadioButtonTelefoni.Text = "RadioButton1"
        Me.RadioButtonTelefoni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButtonTelefoni.UseVisualStyleBackColor = True
        '
        'FormContatti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 353)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormContatti"
        Me.Text = "FormContatti"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonOk As Utx.MyFlatButton
    Friend WithEvents ButtonAnnulla As Utx.MyFlatButton
    Friend WithEvents RadioButtonEmail As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonSms As System.Windows.Forms.RadioButton
    Friend WithEvents tvContatti As System.Windows.Forms.TreeView
    Friend WithEvents RadioButtonTelefoni As System.Windows.Forms.RadioButton
End Class
