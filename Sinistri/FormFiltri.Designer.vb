<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFiltri
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
        Me.ComboBoxColonne = New System.Windows.Forms.ComboBox()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.ButtonFiltra = New System.Windows.Forms.Button()
        Me.ButtonDettaglio = New System.Windows.Forms.Button()
        Me.ButtonCancellaFiltri = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxColonne, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelInfo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonFiltra, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonDettaglio, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCancellaFiltri, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(476, 234)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'ComboBoxColonne
        '
        Me.ComboBoxColonne.FormattingEnabled = True
        Me.ComboBoxColonne.Location = New System.Drawing.Point(3, 120)
        Me.ComboBoxColonne.Name = "ComboBoxColonne"
        Me.ComboBoxColonne.Size = New System.Drawing.Size(232, 21)
        Me.ComboBoxColonne.TabIndex = 0
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelInfo, 2)
        Me.LabelInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfo.Location = New System.Drawing.Point(3, 0)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(470, 107)
        Me.LabelInfo.TabIndex = 2
        Me.LabelInfo.Text = "Label1"
        '
        'ButtonFiltra
        '
        Me.ButtonFiltra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonFiltra.Location = New System.Drawing.Point(238, 117)
        Me.ButtonFiltra.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonFiltra.Name = "ButtonFiltra"
        Me.ButtonFiltra.Size = New System.Drawing.Size(238, 27)
        Me.ButtonFiltra.TabIndex = 3
        Me.ButtonFiltra.Text = "Button1"
        Me.ButtonFiltra.UseVisualStyleBackColor = True
        '
        'ButtonDettaglio
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonDettaglio, 2)
        Me.ButtonDettaglio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonDettaglio.Location = New System.Drawing.Point(0, 194)
        Me.ButtonDettaglio.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonDettaglio.Name = "ButtonDettaglio"
        Me.ButtonDettaglio.Size = New System.Drawing.Size(476, 40)
        Me.ButtonDettaglio.TabIndex = 4
        Me.ButtonDettaglio.Text = "Button1"
        Me.ButtonDettaglio.UseVisualStyleBackColor = True
        '
        'ButtonCancellaFiltri
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonCancellaFiltri, 2)
        Me.ButtonCancellaFiltri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCancellaFiltri.Location = New System.Drawing.Point(0, 154)
        Me.ButtonCancellaFiltri.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCancellaFiltri.Name = "ButtonCancellaFiltri"
        Me.ButtonCancellaFiltri.Size = New System.Drawing.Size(476, 40)
        Me.ButtonCancellaFiltri.TabIndex = 5
        Me.ButtonCancellaFiltri.Text = "Button1"
        Me.ButtonCancellaFiltri.UseVisualStyleBackColor = True
        '
        'FormFiltri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 234)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormFiltri"
        Me.Text = "FormFiltri"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ComboBoxColonne As System.Windows.Forms.ComboBox
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents ButtonFiltra As System.Windows.Forms.Button
    Friend WithEvents ButtonDettaglio As System.Windows.Forms.Button
    Friend WithEvents ButtonCancellaFiltri As System.Windows.Forms.Button
End Class
