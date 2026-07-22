<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAssistenza
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
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnChat = New System.Windows.Forms.Button()
        Me.ButtonARemota = New System.Windows.Forms.Button()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.ButtonRipristino = New System.Windows.Forms.Button()
        Me.TextBoxUtente = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.WebBrowser1, 4)
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(3, 3)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(855, 456)
        Me.WebBrowser1.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.WebBrowser1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnChat, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonARemota, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEsci, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonRipristino, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxUtente, 3, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(861, 562)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'btnChat
        '
        Me.btnChat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnChat.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnChat.FlatAppearance.BorderSize = 0
        Me.btnChat.Location = New System.Drawing.Point(0, 502)
        Me.btnChat.Margin = New System.Windows.Forms.Padding(0)
        Me.btnChat.Name = "btnChat"
        Me.btnChat.Size = New System.Drawing.Size(292, 60)
        Me.btnChat.TabIndex = 2
        Me.btnChat.Text = "Button1"
        Me.btnChat.UseVisualStyleBackColor = True
        '
        'ButtonARemota
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonARemota, 2)
        Me.ButtonARemota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonARemota.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ButtonARemota.FlatAppearance.BorderSize = 0
        Me.ButtonARemota.Location = New System.Drawing.Point(292, 502)
        Me.ButtonARemota.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonARemota.Name = "ButtonARemota"
        Me.ButtonARemota.Size = New System.Drawing.Size(438, 60)
        Me.ButtonARemota.TabIndex = 3
        Me.ButtonARemota.Text = "Button2"
        Me.ButtonARemota.UseVisualStyleBackColor = True
        '
        'btnEsci
        '
        Me.btnEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsci.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnEsci.FlatAppearance.BorderSize = 0
        Me.btnEsci.Location = New System.Drawing.Point(730, 502)
        Me.btnEsci.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(131, 60)
        Me.btnEsci.TabIndex = 5
        Me.btnEsci.Text = "Button4"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'ButtonRipristino
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonRipristino, 3)
        Me.ButtonRipristino.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonRipristino.Location = New System.Drawing.Point(3, 465)
        Me.ButtonRipristino.Name = "ButtonRipristino"
        Me.ButtonRipristino.Size = New System.Drawing.Size(724, 34)
        Me.ButtonRipristino.TabIndex = 6
        Me.ButtonRipristino.Text = "Button1"
        Me.ButtonRipristino.UseVisualStyleBackColor = True
        '
        'TextBoxUtente
        '
        Me.TextBoxUtente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxUtente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxUtente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxUtente.Location = New System.Drawing.Point(733, 468)
        Me.TextBoxUtente.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.TextBoxUtente.MaxLength = 8
        Me.TextBoxUtente.Name = "TextBoxUtente"
        Me.TextBoxUtente.Size = New System.Drawing.Size(125, 26)
        Me.TextBoxUtente.TabIndex = 7
        Me.TextBoxUtente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FormAssistenza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 562)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormAssistenza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormAvvio"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnChat As System.Windows.Forms.Button
    Friend WithEvents ButtonARemota As System.Windows.Forms.Button
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents ButtonRipristino As System.Windows.Forms.Button
    Friend WithEvents TextBoxUtente As TextBox
End Class
