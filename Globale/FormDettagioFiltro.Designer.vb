<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDettagioFiltro
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
        Me.ButtonCancella = New System.Windows.Forms.Button()
        Me.ButtonCarica = New System.Windows.Forms.Button()
        Me.TextBoxDettaglio = New System.Windows.Forms.TextBox()
        Me.ButtonSalva = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxFiltri = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCancella, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCarica, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxDettaglio, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSalva, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxFiltri, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(532, 394)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ButtonCancella
        '
        Me.ButtonCancella.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCancella.FlatAppearance.BorderSize = 0
        Me.ButtonCancella.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown
        Me.ButtonCancella.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancella.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancella.Location = New System.Drawing.Point(266, 351)
        Me.ButtonCancella.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.ButtonCancella.Name = "ButtonCancella"
        Me.ButtonCancella.Size = New System.Drawing.Size(130, 40)
        Me.ButtonCancella.TabIndex = 7
        Me.ButtonCancella.Text = "Button2"
        Me.ButtonCancella.UseVisualStyleBackColor = True
        '
        'ButtonCarica
        '
        Me.ButtonCarica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCarica.FlatAppearance.BorderSize = 0
        Me.ButtonCarica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCarica.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCarica.Location = New System.Drawing.Point(133, 351)
        Me.ButtonCarica.Margin = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.ButtonCarica.Name = "ButtonCarica"
        Me.ButtonCarica.Size = New System.Drawing.Size(133, 40)
        Me.ButtonCarica.TabIndex = 3
        Me.ButtonCarica.Text = "Button1"
        Me.ButtonCarica.UseVisualStyleBackColor = True
        '
        'TextBoxDettaglio
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxDettaglio, 4)
        Me.TextBoxDettaglio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDettaglio.Location = New System.Drawing.Point(0, 30)
        Me.TextBoxDettaglio.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxDettaglio.Multiline = True
        Me.TextBoxDettaglio.Name = "TextBoxDettaglio"
        Me.TextBoxDettaglio.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDettaglio.Size = New System.Drawing.Size(532, 321)
        Me.TextBoxDettaglio.TabIndex = 0
        '
        'ButtonSalva
        '
        Me.ButtonSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSalva.FlatAppearance.BorderSize = 0
        Me.ButtonSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSalva.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSalva.Location = New System.Drawing.Point(3, 351)
        Me.ButtonSalva.Margin = New System.Windows.Forms.Padding(3, 0, 0, 3)
        Me.ButtonSalva.Name = "ButtonSalva"
        Me.ButtonSalva.Size = New System.Drawing.Size(130, 40)
        Me.ButtonSalva.TabIndex = 1
        Me.ButtonSalva.Text = "Button1"
        Me.ButtonSalva.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.FlatAppearance.BorderSize = 0
        Me.ButtonEsci.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.ButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsci.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonEsci.Location = New System.Drawing.Point(399, 351)
        Me.ButtonEsci.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(130, 40)
        Me.ButtonEsci.TabIndex = 2
        Me.ButtonEsci.Text = "Button2"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(260, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nome del filtro da caricare o salvare"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxFiltri
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ComboBoxFiltri, 2)
        Me.ComboBoxFiltri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxFiltri.FormattingEnabled = True
        Me.ComboBoxFiltri.Location = New System.Drawing.Point(269, 3)
        Me.ComboBoxFiltri.Name = "ComboBoxFiltri"
        Me.ComboBoxFiltri.Size = New System.Drawing.Size(260, 22)
        Me.ComboBoxFiltri.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(532, 394)
        Me.Panel1.TabIndex = 0
        '
        'FormDettagioFiltro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 400)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormDettagioFiltro"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.Text = "FormDettagioFiltro"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxDettaglio As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSalva As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents ButtonCarica As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ComboBoxFiltri As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonCancella As System.Windows.Forms.Button
End Class
