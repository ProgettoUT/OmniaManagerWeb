<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnteprima
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
        Me.ButtonApri = New System.Windows.Forms.Button()
        Me.wbAnteprima = New System.Windows.Forms.WebBrowser()
        Me.ButtonStampa = New System.Windows.Forms.Button()
        Me.ButtonCreaPDF = New System.Windows.Forms.Button()
        Me.ButtonInvia = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.ButtonConvertiWord = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonApri, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.wbAnteprima, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonStampa, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCreaPDF, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonInvia, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonConvertiWord, 3, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(629, 366)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ButtonApri
        '
        Me.ButtonApri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonApri.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonApri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonApri.Location = New System.Drawing.Point(116, 319)
        Me.ButtonApri.Name = "ButtonApri"
        Me.ButtonApri.Size = New System.Drawing.Size(107, 44)
        Me.ButtonApri.TabIndex = 5
        Me.ButtonApri.Text = "Button2"
        Me.ButtonApri.UseVisualStyleBackColor = True
        '
        'wbAnteprima
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.wbAnteprima, 6)
        Me.wbAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbAnteprima.Location = New System.Drawing.Point(3, 3)
        Me.wbAnteprima.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbAnteprima.Name = "wbAnteprima"
        Me.wbAnteprima.Size = New System.Drawing.Size(623, 310)
        Me.wbAnteprima.TabIndex = 0
        '
        'ButtonStampa
        '
        Me.ButtonStampa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonStampa.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonStampa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStampa.Location = New System.Drawing.Point(3, 319)
        Me.ButtonStampa.Name = "ButtonStampa"
        Me.ButtonStampa.Size = New System.Drawing.Size(107, 44)
        Me.ButtonStampa.TabIndex = 1
        Me.ButtonStampa.Text = "Button1"
        Me.ButtonStampa.UseVisualStyleBackColor = True
        '
        'ButtonCreaPDF
        '
        Me.ButtonCreaPDF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCreaPDF.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonCreaPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCreaPDF.Location = New System.Drawing.Point(229, 319)
        Me.ButtonCreaPDF.Name = "ButtonCreaPDF"
        Me.ButtonCreaPDF.Size = New System.Drawing.Size(107, 44)
        Me.ButtonCreaPDF.TabIndex = 2
        Me.ButtonCreaPDF.Text = "Button2"
        Me.ButtonCreaPDF.UseVisualStyleBackColor = True
        '
        'ButtonInvia
        '
        Me.ButtonInvia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonInvia.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonInvia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonInvia.Location = New System.Drawing.Point(455, 319)
        Me.ButtonInvia.Name = "ButtonInvia"
        Me.ButtonInvia.Size = New System.Drawing.Size(107, 44)
        Me.ButtonInvia.TabIndex = 3
        Me.ButtonInvia.Text = "Button3"
        Me.ButtonInvia.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsci.Location = New System.Drawing.Point(568, 319)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(58, 44)
        Me.ButtonEsci.TabIndex = 4
        Me.ButtonEsci.Text = "Button4"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'ButtonConvertiWord
        '
        Me.ButtonConvertiWord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonConvertiWord.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonConvertiWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonConvertiWord.Location = New System.Drawing.Point(342, 319)
        Me.ButtonConvertiWord.Name = "ButtonConvertiWord"
        Me.ButtonConvertiWord.Size = New System.Drawing.Size(107, 44)
        Me.ButtonConvertiWord.TabIndex = 6
        Me.ButtonConvertiWord.Text = "Button1"
        Me.ButtonConvertiWord.UseVisualStyleBackColor = True
        '
        'FormAnteprima
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 366)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormAnteprima"
        Me.Text = "FormAnteprima"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents wbAnteprima As System.Windows.Forms.WebBrowser
    Friend WithEvents ButtonStampa As System.Windows.Forms.Button
    Friend WithEvents ButtonCreaPDF As System.Windows.Forms.Button
    Friend WithEvents ButtonInvia As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents ButtonApri As System.Windows.Forms.Button
    Friend WithEvents ButtonConvertiWord As System.Windows.Forms.Button
End Class
