<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNotifica
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
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxTopMost = New System.Windows.Forms.CheckBox()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.LabelTestata = New System.Windows.Forms.Label()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.ButtonVediTutti = New System.Windows.Forms.Button()
        Me.TextBoxTag = New System.Windows.Forms.TextBox()
        Me.ButtonCerca = New System.Windows.Forms.Button()
        Me.LabelTitolo = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.92308!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.07692!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxTopMost, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelTestata, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.WebBrowser1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonVediTutti, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxTag, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCerca, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelTitolo, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(414, 400)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'CheckBoxTopMost
        '
        Me.CheckBoxTopMost.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxTopMost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxTopMost.FlatAppearance.BorderSize = 0
        Me.CheckBoxTopMost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxTopMost.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxTopMost.Location = New System.Drawing.Point(351, 360)
        Me.CheckBoxTopMost.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBoxTopMost.Name = "CheckBoxTopMost"
        Me.CheckBoxTopMost.Size = New System.Drawing.Size(63, 40)
        Me.CheckBoxTopMost.TabIndex = 5
        Me.CheckBoxTopMost.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.FlatAppearance.BorderSize = 0
        Me.ButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsci.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonEsci.Location = New System.Drawing.Point(270, 360)
        Me.ButtonEsci.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(81, 40)
        Me.ButtonEsci.TabIndex = 1
        Me.ButtonEsci.Text = "Button1"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'LabelTestata
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelTestata, 3)
        Me.LabelTestata.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTestata.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelTestata.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTestata.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelTestata.Location = New System.Drawing.Point(0, 0)
        Me.LabelTestata.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelTestata.Name = "LabelTestata"
        Me.LabelTestata.Size = New System.Drawing.Size(414, 25)
        Me.LabelTestata.TabIndex = 3
        Me.LabelTestata.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'WebBrowser1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.WebBrowser1, 3)
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(3, 48)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(408, 287)
        Me.WebBrowser1.TabIndex = 4
        '
        'ButtonVediTutti
        '
        Me.ButtonVediTutti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonVediTutti.FlatAppearance.BorderSize = 0
        Me.ButtonVediTutti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonVediTutti.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonVediTutti.Location = New System.Drawing.Point(0, 360)
        Me.ButtonVediTutti.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonVediTutti.Name = "ButtonVediTutti"
        Me.ButtonVediTutti.Size = New System.Drawing.Size(270, 40)
        Me.ButtonVediTutti.TabIndex = 6
        Me.ButtonVediTutti.Text = "Vedi tutti i twitt"
        Me.ButtonVediTutti.UseVisualStyleBackColor = True
        '
        'TextBoxTag
        '
        Me.TextBoxTag.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxTag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxTag.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTag.Location = New System.Drawing.Point(0, 338)
        Me.TextBoxTag.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxTag.Name = "TextBoxTag"
        Me.TextBoxTag.Size = New System.Drawing.Size(270, 15)
        Me.TextBoxTag.TabIndex = 7
        '
        'ButtonCerca
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonCerca, 2)
        Me.ButtonCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCerca.FlatAppearance.BorderSize = 0
        Me.ButtonCerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCerca.Location = New System.Drawing.Point(270, 338)
        Me.ButtonCerca.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCerca.Name = "ButtonCerca"
        Me.ButtonCerca.Size = New System.Drawing.Size(144, 22)
        Me.ButtonCerca.TabIndex = 8
        Me.ButtonCerca.Text = "Button1"
        Me.ButtonCerca.UseVisualStyleBackColor = True
        '
        'LabelTitolo
        '
        Me.LabelTitolo.AutoSize = True
        Me.LabelTitolo.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelTitolo, 3)
        Me.LabelTitolo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTitolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelTitolo.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitolo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelTitolo.Location = New System.Drawing.Point(0, 25)
        Me.LabelTitolo.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelTitolo.Name = "LabelTitolo"
        Me.LabelTitolo.Size = New System.Drawing.Size(414, 20)
        Me.LabelTitolo.TabIndex = 9
        Me.LabelTitolo.Text = "Notizie"
        Me.LabelTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(416, 402)
        Me.Panel1.TabIndex = 2
        '
        'FormNotifica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 402)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormNotifica"
        Me.Text = "FormNotifica"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents LabelTestata As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents CheckBoxTopMost As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonVediTutti As System.Windows.Forms.Button
    Friend WithEvents TextBoxTag As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCerca As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelTitolo As System.Windows.Forms.Label
End Class
