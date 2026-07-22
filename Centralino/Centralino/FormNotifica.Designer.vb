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
        Me.LabelNome = New System.Windows.Forms.Label()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonSinistri = New System.Windows.Forms.Button()
        Me.ButtonAnag = New System.Windows.Forms.Button()
        Me.LabelTelefono = New System.Windows.Forms.Label()
        Me.LabelAgenzia = New System.Windows.Forms.Label()
        Me.LabelAltriDati = New System.Windows.Forms.Label()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelNome
        '
        Me.tlpMain.SetColumnSpan(Me.LabelNome, 3)
        Me.LabelNome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNome.Location = New System.Drawing.Point(0, 27)
        Me.LabelNome.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelNome.Name = "LabelNome"
        Me.LabelNome.Size = New System.Drawing.Size(373, 43)
        Me.LabelNome.TabIndex = 0
        Me.LabelNome.Text = "Label1"
        Me.LabelNome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 3
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.Controls.Add(Me.LabelNome, 0, 1)
        Me.tlpMain.Controls.Add(Me.ButtonSinistri, 1, 3)
        Me.tlpMain.Controls.Add(Me.ButtonAnag, 0, 3)
        Me.tlpMain.Controls.Add(Me.LabelTelefono, 0, 0)
        Me.tlpMain.Controls.Add(Me.LabelAgenzia, 2, 0)
        Me.tlpMain.Controls.Add(Me.LabelAltriDati, 0, 2)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 4
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMain.Size = New System.Drawing.Size(373, 153)
        Me.tlpMain.TabIndex = 1
        '
        'ButtonSinistri
        '
        Me.tlpMain.SetColumnSpan(Me.ButtonSinistri, 2)
        Me.ButtonSinistri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSinistri.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.ButtonSinistri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSinistri.Location = New System.Drawing.Point(187, 114)
        Me.ButtonSinistri.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonSinistri.Name = "ButtonSinistri"
        Me.ButtonSinistri.Size = New System.Drawing.Size(185, 38)
        Me.ButtonSinistri.TabIndex = 1
        Me.ButtonSinistri.Text = "Button1"
        Me.ButtonSinistri.UseVisualStyleBackColor = True
        '
        'ButtonAnag
        '
        Me.ButtonAnag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnag.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.ButtonAnag.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnag.Location = New System.Drawing.Point(1, 114)
        Me.ButtonAnag.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonAnag.Name = "ButtonAnag"
        Me.ButtonAnag.Size = New System.Drawing.Size(184, 38)
        Me.ButtonAnag.TabIndex = 2
        Me.ButtonAnag.Text = "Button2"
        Me.ButtonAnag.UseVisualStyleBackColor = True
        '
        'LabelTelefono
        '
        Me.LabelTelefono.AutoSize = True
        Me.tlpMain.SetColumnSpan(Me.LabelTelefono, 2)
        Me.LabelTelefono.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTelefono.Location = New System.Drawing.Point(0, 0)
        Me.LabelTelefono.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelTelefono.Name = "LabelTelefono"
        Me.LabelTelefono.Size = New System.Drawing.Size(279, 27)
        Me.LabelTelefono.TabIndex = 3
        Me.LabelTelefono.Text = "Label1"
        '
        'LabelAgenzia
        '
        Me.LabelAgenzia.AutoSize = True
        Me.LabelAgenzia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelAgenzia.Location = New System.Drawing.Point(279, 0)
        Me.LabelAgenzia.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelAgenzia.Name = "LabelAgenzia"
        Me.LabelAgenzia.Size = New System.Drawing.Size(94, 27)
        Me.LabelAgenzia.TabIndex = 4
        Me.LabelAgenzia.Text = "Label1"
        '
        'LabelAltriDati
        '
        Me.LabelAltriDati.AutoSize = True
        Me.tlpMain.SetColumnSpan(Me.LabelAltriDati, 3)
        Me.LabelAltriDati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelAltriDati.Location = New System.Drawing.Point(3, 70)
        Me.LabelAltriDati.Name = "LabelAltriDati"
        Me.LabelAltriDati.Size = New System.Drawing.Size(367, 43)
        Me.LabelAltriDati.TabIndex = 5
        Me.LabelAltriDati.Text = "LabelAltriDati"
        Me.LabelAltriDati.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormNotifica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 153)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormNotifica"
        Me.Text = "Form1"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelNome As System.Windows.Forms.Label
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonSinistri As System.Windows.Forms.Button
    Friend WithEvents ButtonAnag As System.Windows.Forms.Button
    Friend WithEvents LabelTelefono As System.Windows.Forms.Label
    Friend WithEvents LabelAgenzia As System.Windows.Forms.Label
    Friend WithEvents LabelAltriDati As System.Windows.Forms.Label

End Class
