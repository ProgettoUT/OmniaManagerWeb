<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSinistri
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.dgvSinistri = New System.Windows.Forms.DataGridView()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvTotali = New System.Windows.Forms.DataGridView()
        Me.tlpMenuViste = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonPerizie = New System.Windows.Forms.Button()
        Me.ButtonSopravvenienze = New System.Windows.Forms.Button()
        Me.ButtonEsciViste = New System.Windows.Forms.Button()
        Me.ButtonIndicatoreCliente = New System.Windows.Forms.Button()
        Me.ButtonControparte = New System.Windows.Forms.Button()
        Me.ButtonVariazioniMeseAnno = New System.Windows.Forms.Button()
        Me.LabelDesk = New System.Windows.Forms.Label()
        CType(Me.dgvSinistri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpMain.SuspendLayout()
        CType(Me.dgvTotali, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpMenuViste.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvSinistri
        '
        Me.dgvSinistri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSinistri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSinistri.Location = New System.Drawing.Point(3, 96)
        Me.dgvSinistri.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.dgvSinistri.Name = "dgvSinistri"
        Me.dgvSinistri.Size = New System.Drawing.Size(1012, 328)
        Me.dgvSinistri.TabIndex = 0
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.dgvSinistri, 0, 2)
        Me.tlpMain.Controls.Add(Me.dgvTotali, 0, 3)
        Me.tlpMain.Controls.Add(Me.tlpMenuViste, 0, 0)
        Me.tlpMain.Controls.Add(Me.LabelDesk, 0, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 4
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlpMain.Size = New System.Drawing.Size(1018, 452)
        Me.tlpMain.TabIndex = 1
        '
        'dgvTotali
        '
        Me.dgvTotali.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTotali.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTotali.Location = New System.Drawing.Point(3, 426)
        Me.dgvTotali.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.dgvTotali.Name = "dgvTotali"
        Me.dgvTotali.Size = New System.Drawing.Size(1012, 23)
        Me.dgvTotali.TabIndex = 1
        '
        'tlpMenuViste
        '
        Me.tlpMenuViste.ColumnCount = 6
        Me.tlpMenuViste.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpMenuViste.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpMenuViste.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpMenuViste.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpMenuViste.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpMenuViste.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.tlpMenuViste.Controls.Add(Me.ButtonPerizie, 2, 0)
        Me.tlpMenuViste.Controls.Add(Me.ButtonSopravvenienze, 0, 0)
        Me.tlpMenuViste.Controls.Add(Me.ButtonEsciViste, 5, 0)
        Me.tlpMenuViste.Controls.Add(Me.ButtonIndicatoreCliente, 3, 0)
        Me.tlpMenuViste.Controls.Add(Me.ButtonControparte, 4, 0)
        Me.tlpMenuViste.Controls.Add(Me.ButtonVariazioniMeseAnno, 1, 0)
        Me.tlpMenuViste.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMenuViste.Location = New System.Drawing.Point(3, 3)
        Me.tlpMenuViste.Name = "tlpMenuViste"
        Me.tlpMenuViste.RowCount = 1
        Me.tlpMenuViste.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMenuViste.Size = New System.Drawing.Size(1012, 62)
        Me.tlpMenuViste.TabIndex = 2
        '
        'ButtonPerizie
        '
        Me.ButtonPerizie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonPerizie.Location = New System.Drawing.Point(381, 3)
        Me.ButtonPerizie.Name = "ButtonPerizie"
        Me.ButtonPerizie.Size = New System.Drawing.Size(183, 56)
        Me.ButtonPerizie.TabIndex = 2
        Me.ButtonPerizie.Text = "Button1"
        Me.ButtonPerizie.UseVisualStyleBackColor = True
        '
        'ButtonSopravvenienze
        '
        Me.ButtonSopravvenienze.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSopravvenienze.Location = New System.Drawing.Point(3, 3)
        Me.ButtonSopravvenienze.Name = "ButtonSopravvenienze"
        Me.ButtonSopravvenienze.Size = New System.Drawing.Size(183, 56)
        Me.ButtonSopravvenienze.TabIndex = 0
        Me.ButtonSopravvenienze.Text = "Button1"
        Me.ButtonSopravvenienze.UseVisualStyleBackColor = True
        '
        'ButtonEsciViste
        '
        Me.ButtonEsciViste.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsciViste.Location = New System.Drawing.Point(948, 3)
        Me.ButtonEsciViste.Name = "ButtonEsciViste"
        Me.ButtonEsciViste.Size = New System.Drawing.Size(61, 56)
        Me.ButtonEsciViste.TabIndex = 1
        Me.ButtonEsciViste.Text = "Button1"
        Me.ButtonEsciViste.UseVisualStyleBackColor = True
        '
        'ButtonIndicatoreCliente
        '
        Me.ButtonIndicatoreCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonIndicatoreCliente.Location = New System.Drawing.Point(570, 3)
        Me.ButtonIndicatoreCliente.Name = "ButtonIndicatoreCliente"
        Me.ButtonIndicatoreCliente.Size = New System.Drawing.Size(183, 56)
        Me.ButtonIndicatoreCliente.TabIndex = 3
        Me.ButtonIndicatoreCliente.Text = "Button1"
        Me.ButtonIndicatoreCliente.UseVisualStyleBackColor = True
        '
        'ButtonControparte
        '
        Me.ButtonControparte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonControparte.Location = New System.Drawing.Point(759, 3)
        Me.ButtonControparte.Name = "ButtonControparte"
        Me.ButtonControparte.Size = New System.Drawing.Size(183, 56)
        Me.ButtonControparte.TabIndex = 4
        Me.ButtonControparte.Text = "Button1"
        Me.ButtonControparte.UseVisualStyleBackColor = True
        '
        'ButtonVariazioniMeseAnno
        '
        Me.ButtonVariazioniMeseAnno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonVariazioniMeseAnno.Location = New System.Drawing.Point(192, 3)
        Me.ButtonVariazioniMeseAnno.Name = "ButtonVariazioniMeseAnno"
        Me.ButtonVariazioniMeseAnno.Size = New System.Drawing.Size(183, 56)
        Me.ButtonVariazioniMeseAnno.TabIndex = 5
        Me.ButtonVariazioniMeseAnno.Text = "Button1"
        Me.ButtonVariazioniMeseAnno.UseVisualStyleBackColor = True
        '
        'LabelDesk
        '
        Me.LabelDesk.AutoSize = True
        Me.LabelDesk.BackColor = System.Drawing.Color.Transparent
        Me.LabelDesk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelDesk.Location = New System.Drawing.Point(1, 68)
        Me.LabelDesk.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.LabelDesk.Name = "LabelDesk"
        Me.LabelDesk.Size = New System.Drawing.Size(1016, 25)
        Me.LabelDesk.TabIndex = 3
        Me.LabelDesk.Text = "Label1"
        Me.LabelDesk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ucSinistri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucSinistri"
        Me.Size = New System.Drawing.Size(1018, 452)
        CType(Me.dgvSinistri, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        CType(Me.dgvTotali, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMenuViste.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvSinistri As System.Windows.Forms.DataGridView
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvTotali As System.Windows.Forms.DataGridView
    Friend WithEvents tlpMenuViste As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonSopravvenienze As System.Windows.Forms.Button
    Friend WithEvents ButtonEsciViste As System.Windows.Forms.Button
    Friend WithEvents LabelDesk As System.Windows.Forms.Label
    Friend WithEvents ButtonPerizie As System.Windows.Forms.Button
    Friend WithEvents ButtonIndicatoreCliente As System.Windows.Forms.Button
    Friend WithEvents ButtonControparte As System.Windows.Forms.Button
    Friend WithEvents ButtonVariazioniMeseAnno As System.Windows.Forms.Button

End Class
