<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCopiaDati
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
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxCliente = New System.Windows.Forms.CheckBox()
        Me.CheckBoxPolizze = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSinistri = New System.Windows.Forms.CheckBox()
        Me.ButtonCopia = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.CheckedListBoxDati = New System.Windows.Forms.CheckedListBox()
        Me.ButtonSelezionaTutto = New System.Windows.Forms.Button()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 3
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlpMain.Controls.Add(Me.CheckBoxCliente, 0, 0)
        Me.tlpMain.Controls.Add(Me.CheckBoxPolizze, 1, 0)
        Me.tlpMain.Controls.Add(Me.CheckBoxSinistri, 2, 0)
        Me.tlpMain.Controls.Add(Me.ButtonCopia, 0, 2)
        Me.tlpMain.Controls.Add(Me.ButtonEsci, 2, 2)
        Me.tlpMain.Controls.Add(Me.CheckedListBoxDati, 0, 1)
        Me.tlpMain.Controls.Add(Me.ButtonSelezionaTutto, 1, 2)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 3
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMain.Size = New System.Drawing.Size(413, 425)
        Me.tlpMain.TabIndex = 0
        '
        'CheckBoxCliente
        '
        Me.CheckBoxCliente.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxCliente.AutoSize = True
        Me.CheckBoxCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxCliente.Location = New System.Drawing.Point(3, 3)
        Me.CheckBoxCliente.Name = "CheckBoxCliente"
        Me.CheckBoxCliente.Size = New System.Drawing.Size(131, 24)
        Me.CheckBoxCliente.TabIndex = 0
        Me.CheckBoxCliente.Text = "Cliente"
        Me.CheckBoxCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxCliente.UseVisualStyleBackColor = True
        '
        'CheckBoxPolizze
        '
        Me.CheckBoxPolizze.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxPolizze.AutoSize = True
        Me.CheckBoxPolizze.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxPolizze.Location = New System.Drawing.Point(140, 3)
        Me.CheckBoxPolizze.Name = "CheckBoxPolizze"
        Me.CheckBoxPolizze.Size = New System.Drawing.Size(131, 24)
        Me.CheckBoxPolizze.TabIndex = 1
        Me.CheckBoxPolizze.Text = "Polizze"
        Me.CheckBoxPolizze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxPolizze.UseVisualStyleBackColor = True
        '
        'CheckBoxSinistri
        '
        Me.CheckBoxSinistri.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxSinistri.AutoSize = True
        Me.CheckBoxSinistri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxSinistri.Location = New System.Drawing.Point(277, 3)
        Me.CheckBoxSinistri.Name = "CheckBoxSinistri"
        Me.CheckBoxSinistri.Size = New System.Drawing.Size(133, 24)
        Me.CheckBoxSinistri.TabIndex = 2
        Me.CheckBoxSinistri.Text = "Sinistri"
        Me.CheckBoxSinistri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxSinistri.UseVisualStyleBackColor = True
        '
        'ButtonCopia
        '
        Me.ButtonCopia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCopia.Location = New System.Drawing.Point(3, 388)
        Me.ButtonCopia.Name = "ButtonCopia"
        Me.ButtonCopia.Size = New System.Drawing.Size(131, 34)
        Me.ButtonCopia.TabIndex = 3
        Me.ButtonCopia.Text = "Copia i dati selezionati"
        Me.ButtonCopia.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.Location = New System.Drawing.Point(277, 388)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(133, 34)
        Me.ButtonEsci.TabIndex = 4
        Me.ButtonEsci.Text = "Esci"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'CheckedListBoxDati
        '
        Me.tlpMain.SetColumnSpan(Me.CheckedListBoxDati, 3)
        Me.CheckedListBoxDati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxDati.FormattingEnabled = True
        Me.CheckedListBoxDati.Location = New System.Drawing.Point(3, 33)
        Me.CheckedListBoxDati.Name = "CheckedListBoxDati"
        Me.CheckedListBoxDati.Size = New System.Drawing.Size(407, 349)
        Me.CheckedListBoxDati.TabIndex = 5
        '
        'ButtonSelezionaTutto
        '
        Me.ButtonSelezionaTutto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSelezionaTutto.Location = New System.Drawing.Point(140, 388)
        Me.ButtonSelezionaTutto.Name = "ButtonSelezionaTutto"
        Me.ButtonSelezionaTutto.Size = New System.Drawing.Size(131, 34)
        Me.ButtonSelezionaTutto.TabIndex = 6
        Me.ButtonSelezionaTutto.Text = "Seleziona tutto"
        Me.ButtonSelezionaTutto.UseVisualStyleBackColor = True
        '
        'FormCopiaDati
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 425)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormCopiaDati"
        Me.Text = "FormCopiaDati"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxCliente As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxPolizze As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSinistri As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonCopia As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents CheckedListBoxDati As System.Windows.Forms.CheckedListBox
    Friend WithEvents ButtonSelezionaTutto As System.Windows.Forms.Button
End Class
