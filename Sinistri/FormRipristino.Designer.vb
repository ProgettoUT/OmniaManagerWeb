<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRipristino
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
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonRipristina = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.TextBoxCF = New System.Windows.Forms.TextBox()
        Me.TextBoxNumeroSinistro = New System.Windows.Forms.TextBox()
        Me.TextBoxAnno = New System.Windows.Forms.TextBox()
        Me.CheckBoxDP = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonRipristina, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxCF, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxNumeroSinistro, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxAnno, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxDP, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(484, 146)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codice fiscale"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Numero sinistro"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Esercizio"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Location = New System.Drawing.Point(338, 3)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(3)
        Me.TableLayoutPanel1.SetRowSpan(Me.Label4, 3)
        Me.Label4.Size = New System.Drawing.Size(146, 69)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "scegliere il tipo di recupero: per codice fiscale, numero o esercizio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonRipristina
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonRipristina, 2)
        Me.ButtonRipristina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonRipristina.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonRipristina.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRipristina.Location = New System.Drawing.Point(0, 105)
        Me.ButtonRipristina.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonRipristina.Name = "ButtonRipristina"
        Me.ButtonRipristina.Size = New System.Drawing.Size(338, 41)
        Me.ButtonRipristina.TabIndex = 6
        Me.ButtonRipristina.Text = "Button1"
        Me.ButtonRipristina.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsci.Location = New System.Drawing.Point(338, 105)
        Me.ButtonEsci.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(146, 41)
        Me.ButtonEsci.TabIndex = 7
        Me.ButtonEsci.Text = "Button2"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'TextBoxCF
        '
        Me.TextBoxCF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCF.Location = New System.Drawing.Point(148, 3)
        Me.TextBoxCF.MaxLength = 16
        Me.TextBoxCF.Name = "TextBoxCF"
        Me.TextBoxCF.Size = New System.Drawing.Size(187, 20)
        Me.TextBoxCF.TabIndex = 8
        Me.TextBoxCF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxNumeroSinistro
        '
        Me.TextBoxNumeroSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxNumeroSinistro.Location = New System.Drawing.Point(148, 28)
        Me.TextBoxNumeroSinistro.MaxLength = 19
        Me.TextBoxNumeroSinistro.Name = "TextBoxNumeroSinistro"
        Me.TextBoxNumeroSinistro.Size = New System.Drawing.Size(187, 20)
        Me.TextBoxNumeroSinistro.TabIndex = 9
        Me.TextBoxNumeroSinistro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxAnno
        '
        Me.TextBoxAnno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxAnno.Location = New System.Drawing.Point(148, 53)
        Me.TextBoxAnno.MaxLength = 4
        Me.TextBoxAnno.Name = "TextBoxAnno"
        Me.TextBoxAnno.Size = New System.Drawing.Size(187, 20)
        Me.TextBoxAnno.TabIndex = 10
        Me.TextBoxAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBoxDP
        '
        Me.CheckBoxDP.AutoSize = True
        Me.CheckBoxDP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxDP.Checked = True
        Me.CheckBoxDP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TableLayoutPanel1.SetColumnSpan(Me.CheckBoxDP, 2)
        Me.CheckBoxDP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxDP.Location = New System.Drawing.Point(3, 78)
        Me.CheckBoxDP.Name = "CheckBoxDP"
        Me.CheckBoxDP.Size = New System.Drawing.Size(332, 24)
        Me.CheckBoxDP.TabIndex = 11
        Me.CheckBoxDP.Text = "Ripristina solo i sinistri in delega propria"
        Me.CheckBoxDP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxDP.UseVisualStyleBackColor = True
        '
        'FormRipristino
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 152)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormRipristino"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.Text = "FormRipristino"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents ButtonRipristina As Windows.Forms.Button
    Friend WithEvents ButtonEsci As Windows.Forms.Button
    Friend WithEvents TextBoxCF As Windows.Forms.TextBox
    Friend WithEvents TextBoxNumeroSinistro As Windows.Forms.TextBox
    Friend WithEvents TextBoxAnno As Windows.Forms.TextBox
    Friend WithEvents CheckBoxDP As Windows.Forms.CheckBox
End Class
