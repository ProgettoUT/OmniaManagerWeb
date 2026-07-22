<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSinistri
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
        Me.StatusStripSinistri = New System.Windows.Forms.StatusStrip()
        Me.tssMessaggio = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbSinistri = New System.Windows.Forms.ToolStripProgressBar()
        Me.tlpSinistri = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonCercaOM = New UtControls.UtFlatButton()
        Me.LabelNumeroSinistri = New System.Windows.Forms.Label()
        Me.ComboBoxCercaIn = New System.Windows.Forms.ComboBox()
        Me.CheckBoxEsatto = New System.Windows.Forms.CheckBox()
        Me.LabelNumeroSinistro = New System.Windows.Forms.Label()
        Me.LabelSemaforoRicerca = New System.Windows.Forms.Label()
        Me.LabelSemaforoSelezione = New System.Windows.Forms.Label()
        Me.tsMainMenu = New System.Windows.Forms.ToolStrip()
        Me.LabelAssicurato = New System.Windows.Forms.Label()
        Me.ButtonSelezionaEsercizi = New Utx.MyFlatButton()
        Me.ComboBoxTipoTabella = New System.Windows.Forms.ComboBox()
        Me.LabelCerca = New System.Windows.Forms.Label()
        Me.ComboBoxChiusura = New System.Windows.Forms.ComboBox()
        Me.CheckBoxElencoCompleto = New System.Windows.Forms.CheckBox()
        Me.LabelValore = New System.Windows.Forms.Label()
        Me.ComboBoxLayout = New System.Windows.Forms.ComboBox()
        Me.LabelChiusura = New System.Windows.Forms.Label()
        Me.ButtonReset = New UtControls.UtFlatButton()
        Me.ButtonPulisciCerca = New UtControls.UtFlatButton()
        Me.ButtonCercaLiquido = New System.Windows.Forms.Button()
        Me.StatusStripSinistri.SuspendLayout()
        Me.tlpSinistri.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStripSinistri
        '
        Me.StatusStripSinistri.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssMessaggio, Me.pbSinistri})
        Me.StatusStripSinistri.Location = New System.Drawing.Point(0, 417)
        Me.StatusStripSinistri.Name = "StatusStripSinistri"
        Me.StatusStripSinistri.Size = New System.Drawing.Size(703, 22)
        Me.StatusStripSinistri.TabIndex = 0
        Me.StatusStripSinistri.Text = "StatusStrip1"
        '
        'tssMessaggio
        '
        Me.tssMessaggio.Name = "tssMessaggio"
        Me.tssMessaggio.Size = New System.Drawing.Size(78, 17)
        Me.tssMessaggio.Text = "tssMessaggio"
        '
        'pbSinistri
        '
        Me.pbSinistri.Name = "pbSinistri"
        Me.pbSinistri.Size = New System.Drawing.Size(100, 16)
        '
        'tlpSinistri
        '
        Me.tlpSinistri.ColumnCount = 18
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.tlpSinistri.Controls.Add(Me.ButtonCercaOM, 16, 4)
        Me.tlpSinistri.Controls.Add(Me.LabelNumeroSinistri, 16, 2)
        Me.tlpSinistri.Controls.Add(Me.ComboBoxCercaIn, 2, 2)
        Me.tlpSinistri.Controls.Add(Me.CheckBoxEsatto, 5, 2)
        Me.tlpSinistri.Controls.Add(Me.LabelNumeroSinistro, 6, 4)
        Me.tlpSinistri.Controls.Add(Me.LabelSemaforoRicerca, 0, 2)
        Me.tlpSinistri.Controls.Add(Me.LabelSemaforoSelezione, 0, 4)
        Me.tlpSinistri.Controls.Add(Me.tsMainMenu, 0, 0)
        Me.tlpSinistri.Controls.Add(Me.LabelAssicurato, 8, 4)
        Me.tlpSinistri.Controls.Add(Me.ButtonSelezionaEsercizi, 11, 2)
        Me.tlpSinistri.Controls.Add(Me.ComboBoxTipoTabella, 7, 2)
        Me.tlpSinistri.Controls.Add(Me.LabelCerca, 1, 2)
        Me.tlpSinistri.Controls.Add(Me.ComboBoxChiusura, 9, 2)
        Me.tlpSinistri.Controls.Add(Me.CheckBoxElencoCompleto, 13, 2)
        Me.tlpSinistri.Controls.Add(Me.LabelValore, 11, 4)
        Me.tlpSinistri.Controls.Add(Me.ComboBoxLayout, 1, 5)
        Me.tlpSinistri.Controls.Add(Me.LabelChiusura, 13, 4)
        Me.tlpSinistri.Controls.Add(Me.ButtonReset, 15, 2)
        Me.tlpSinistri.Controls.Add(Me.ButtonPulisciCerca, 4, 2)
        Me.tlpSinistri.Controls.Add(Me.ButtonCercaLiquido, 14, 4)
        Me.tlpSinistri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpSinistri.Location = New System.Drawing.Point(0, 0)
        Me.tlpSinistri.Name = "tlpSinistri"
        Me.tlpSinistri.Padding = New System.Windows.Forms.Padding(1)
        Me.tlpSinistri.RowCount = 6
        Me.tlpSinistri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpSinistri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.tlpSinistri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.tlpSinistri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.tlpSinistri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.tlpSinistri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSinistri.Size = New System.Drawing.Size(703, 417)
        Me.tlpSinistri.TabIndex = 1
        '
        'ButtonCercaOM
        '
        Me.tlpSinistri.SetColumnSpan(Me.ButtonCercaOM, 2)
        Me.ButtonCercaOM.DefaultBorderSize = 0
        Me.ButtonCercaOM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCercaOM.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonCercaOM.FlatAppearance.BorderSize = 0
        Me.ButtonCercaOM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonCercaOM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCercaOM.Location = New System.Drawing.Point(613, 84)
        Me.ButtonCercaOM.Margin = New System.Windows.Forms.Padding(3, 0, 3, 1)
        Me.ButtonCercaOM.Name = "ButtonCercaOM"
        Me.ButtonCercaOM.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.ButtonCercaOM.Size = New System.Drawing.Size(86, 22)
        Me.ButtonCercaOM.TabIndex = 28
        Me.ButtonCercaOM.Text = "UtFlatButton1"
        Me.ButtonCercaOM.UseVisualStyleBackColor = True
        '
        'LabelNumeroSinistri
        '
        Me.LabelNumeroSinistri.AutoSize = True
        Me.tlpSinistri.SetColumnSpan(Me.LabelNumeroSinistri, 2)
        Me.LabelNumeroSinistri.Location = New System.Drawing.Point(613, 56)
        Me.LabelNumeroSinistri.Margin = New System.Windows.Forms.Padding(3, 0, 3, 1)
        Me.LabelNumeroSinistri.Name = "LabelNumeroSinistri"
        Me.LabelNumeroSinistri.Size = New System.Drawing.Size(85, 22)
        Me.LabelNumeroSinistri.TabIndex = 7
        Me.LabelNumeroSinistri.Text = "LabelNumeroSinistri"
        '
        'ComboBoxCercaIn
        '
        Me.tlpSinistri.SetColumnSpan(Me.ComboBoxCercaIn, 2)
        Me.ComboBoxCercaIn.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBoxCercaIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxCercaIn.FormattingEnabled = True
        Me.ComboBoxCercaIn.Location = New System.Drawing.Point(52, 56)
        Me.ComboBoxCercaIn.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.ComboBoxCercaIn.Name = "ComboBoxCercaIn"
        Me.ComboBoxCercaIn.Size = New System.Drawing.Size(82, 21)
        Me.ComboBoxCercaIn.TabIndex = 8
        '
        'CheckBoxEsatto
        '
        Me.CheckBoxEsatto.AutoSize = True
        Me.tlpSinistri.SetColumnSpan(Me.CheckBoxEsatto, 2)
        Me.CheckBoxEsatto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxEsatto.Location = New System.Drawing.Point(162, 56)
        Me.CheckBoxEsatto.Margin = New System.Windows.Forms.Padding(3, 0, 0, 1)
        Me.CheckBoxEsatto.Name = "CheckBoxEsatto"
        Me.CheckBoxEsatto.Size = New System.Drawing.Size(79, 22)
        Me.CheckBoxEsatto.TabIndex = 9
        Me.CheckBoxEsatto.Text = "CheckBox1"
        Me.CheckBoxEsatto.UseVisualStyleBackColor = True
        '
        'LabelNumeroSinistro
        '
        Me.LabelNumeroSinistro.AutoSize = True
        Me.tlpSinistri.SetColumnSpan(Me.LabelNumeroSinistro, 2)
        Me.LabelNumeroSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNumeroSinistro.Location = New System.Drawing.Point(203, 84)
        Me.LabelNumeroSinistro.Margin = New System.Windows.Forms.Padding(3, 0, 3, 1)
        Me.LabelNumeroSinistro.Name = "LabelNumeroSinistro"
        Me.LabelNumeroSinistro.Size = New System.Drawing.Size(76, 22)
        Me.LabelNumeroSinistro.TabIndex = 3
        Me.LabelNumeroSinistro.Text = "LabelNumeroSinistro"
        '
        'LabelSemaforoRicerca
        '
        Me.LabelSemaforoRicerca.AutoSize = True
        Me.LabelSemaforoRicerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSemaforoRicerca.Location = New System.Drawing.Point(1, 56)
        Me.LabelSemaforoRicerca.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelSemaforoRicerca.Name = "LabelSemaforoRicerca"
        Me.LabelSemaforoRicerca.Size = New System.Drawing.Size(10, 23)
        Me.LabelSemaforoRicerca.TabIndex = 11
        '
        'LabelSemaforoSelezione
        '
        Me.LabelSemaforoSelezione.AutoSize = True
        Me.LabelSemaforoSelezione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSemaforoSelezione.Location = New System.Drawing.Point(1, 84)
        Me.LabelSemaforoSelezione.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelSemaforoSelezione.Name = "LabelSemaforoSelezione"
        Me.LabelSemaforoSelezione.Size = New System.Drawing.Size(10, 23)
        Me.LabelSemaforoSelezione.TabIndex = 12
        '
        'tsMainMenu
        '
        Me.tlpSinistri.SetColumnSpan(Me.tsMainMenu, 18)
        Me.tsMainMenu.Location = New System.Drawing.Point(1, 1)
        Me.tsMainMenu.Name = "tsMainMenu"
        Me.tsMainMenu.Size = New System.Drawing.Size(701, 25)
        Me.tsMainMenu.TabIndex = 13
        Me.tsMainMenu.Text = "ToolStrip1"
        '
        'LabelAssicurato
        '
        Me.tlpSinistri.SetColumnSpan(Me.LabelAssicurato, 3)
        Me.LabelAssicurato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelAssicurato.Location = New System.Drawing.Point(285, 84)
        Me.LabelAssicurato.Margin = New System.Windows.Forms.Padding(3, 0, 3, 1)
        Me.LabelAssicurato.Name = "LabelAssicurato"
        Me.LabelAssicurato.Size = New System.Drawing.Size(117, 22)
        Me.LabelAssicurato.TabIndex = 5
        Me.LabelAssicurato.Text = "LabelAssicurato"
        '
        'ButtonSelezionaEsercizi
        '
        Me.tlpSinistri.SetColumnSpan(Me.ButtonSelezionaEsercizi, 2)
        Me.ButtonSelezionaEsercizi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSelezionaEsercizi.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonSelezionaEsercizi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSelezionaEsercizi.Location = New System.Drawing.Point(405, 56)
        Me.ButtonSelezionaEsercizi.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.ButtonSelezionaEsercizi.Name = "ButtonSelezionaEsercizi"
        Me.ButtonSelezionaEsercizi.Size = New System.Drawing.Size(82, 22)
        Me.ButtonSelezionaEsercizi.TabIndex = 17
        Me.ButtonSelezionaEsercizi.Text = "Esercizi"
        Me.ButtonSelezionaEsercizi.UseVisualStyleBackColor = True
        '
        'ComboBoxTipoTabella
        '
        Me.tlpSinistri.SetColumnSpan(Me.ComboBoxTipoTabella, 2)
        Me.ComboBoxTipoTabella.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBoxTipoTabella.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxTipoTabella.FormattingEnabled = True
        Me.ComboBoxTipoTabella.Location = New System.Drawing.Point(241, 56)
        Me.ComboBoxTipoTabella.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.ComboBoxTipoTabella.Name = "ComboBoxTipoTabella"
        Me.ComboBoxTipoTabella.Size = New System.Drawing.Size(82, 21)
        Me.ComboBoxTipoTabella.TabIndex = 19
        '
        'LabelCerca
        '
        Me.LabelCerca.AutoSize = True
        Me.LabelCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCerca.Location = New System.Drawing.Point(14, 56)
        Me.LabelCerca.Margin = New System.Windows.Forms.Padding(3, 0, 3, 1)
        Me.LabelCerca.Name = "LabelCerca"
        Me.LabelCerca.Size = New System.Drawing.Size(35, 22)
        Me.LabelCerca.TabIndex = 16
        Me.LabelCerca.Text = "Label1"
        Me.LabelCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxChiusura
        '
        Me.tlpSinistri.SetColumnSpan(Me.ComboBoxChiusura, 2)
        Me.ComboBoxChiusura.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBoxChiusura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxChiusura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxChiusura.FormattingEnabled = True
        Me.ComboBoxChiusura.Location = New System.Drawing.Point(323, 56)
        Me.ComboBoxChiusura.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.ComboBoxChiusura.Name = "ComboBoxChiusura"
        Me.ComboBoxChiusura.Size = New System.Drawing.Size(82, 21)
        Me.ComboBoxChiusura.TabIndex = 20
        '
        'CheckBoxElencoCompleto
        '
        Me.CheckBoxElencoCompleto.AutoSize = True
        Me.tlpSinistri.SetColumnSpan(Me.CheckBoxElencoCompleto, 2)
        Me.CheckBoxElencoCompleto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxElencoCompleto.Location = New System.Drawing.Point(490, 56)
        Me.CheckBoxElencoCompleto.Margin = New System.Windows.Forms.Padding(3, 0, 0, 1)
        Me.CheckBoxElencoCompleto.Name = "CheckBoxElencoCompleto"
        Me.CheckBoxElencoCompleto.Size = New System.Drawing.Size(79, 22)
        Me.CheckBoxElencoCompleto.TabIndex = 21
        Me.CheckBoxElencoCompleto.Text = "Elenco completo"
        Me.CheckBoxElencoCompleto.UseVisualStyleBackColor = True
        '
        'LabelValore
        '
        Me.LabelValore.AutoSize = True
        Me.tlpSinistri.SetColumnSpan(Me.LabelValore, 2)
        Me.LabelValore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelValore.Location = New System.Drawing.Point(408, 84)
        Me.LabelValore.Margin = New System.Windows.Forms.Padding(3, 0, 3, 1)
        Me.LabelValore.Name = "LabelValore"
        Me.LabelValore.Size = New System.Drawing.Size(76, 22)
        Me.LabelValore.TabIndex = 22
        Me.LabelValore.Text = "Valore"
        '
        'ComboBoxLayout
        '
        Me.tlpSinistri.SetColumnSpan(Me.ComboBoxLayout, 2)
        Me.ComboBoxLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxLayout.FormattingEnabled = True
        Me.ComboBoxLayout.Location = New System.Drawing.Point(11, 107)
        Me.ComboBoxLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.ComboBoxLayout.Name = "ComboBoxLayout"
        Me.ComboBoxLayout.Size = New System.Drawing.Size(40, 21)
        Me.ComboBoxLayout.TabIndex = 14
        '
        'LabelChiusura
        '
        Me.LabelChiusura.AutoSize = True
        Me.LabelChiusura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelChiusura.Location = New System.Drawing.Point(490, 84)
        Me.LabelChiusura.Margin = New System.Windows.Forms.Padding(3, 0, 3, 1)
        Me.LabelChiusura.Name = "LabelChiusura"
        Me.LabelChiusura.Size = New System.Drawing.Size(35, 22)
        Me.LabelChiusura.TabIndex = 23
        Me.LabelChiusura.Text = "Label1"
        Me.LabelChiusura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonReset
        '
        Me.ButtonReset.DefaultBorderSize = 0
        Me.ButtonReset.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonReset.FlatAppearance.BorderSize = 0
        Me.ButtonReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonReset.Location = New System.Drawing.Point(569, 56)
        Me.ButtonReset.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.ButtonReset.Name = "ButtonReset"
        Me.ButtonReset.Size = New System.Drawing.Size(41, 22)
        Me.ButtonReset.TabIndex = 25
        Me.ButtonReset.Text = "UtFlatButton1"
        Me.ButtonReset.UseVisualStyleBackColor = True
        '
        'ButtonPulisciCerca
        '
        Me.ButtonPulisciCerca.DefaultBorderSize = 0
        Me.ButtonPulisciCerca.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonPulisciCerca.FlatAppearance.BorderSize = 0
        Me.ButtonPulisciCerca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonPulisciCerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPulisciCerca.Location = New System.Drawing.Point(134, 56)
        Me.ButtonPulisciCerca.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonPulisciCerca.Name = "ButtonPulisciCerca"
        Me.ButtonPulisciCerca.Size = New System.Drawing.Size(25, 23)
        Me.ButtonPulisciCerca.TabIndex = 26
        Me.ButtonPulisciCerca.Text = "UtFlatButton1"
        Me.ButtonPulisciCerca.UseVisualStyleBackColor = True
        '
        'ButtonCercaLiquido
        '
        Me.tlpSinistri.SetColumnSpan(Me.ButtonCercaLiquido, 2)
        Me.ButtonCercaLiquido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCercaLiquido.Location = New System.Drawing.Point(531, 87)
        Me.ButtonCercaLiquido.Name = "ButtonCercaLiquido"
        Me.ButtonCercaLiquido.Size = New System.Drawing.Size(76, 17)
        Me.ButtonCercaLiquido.TabIndex = 29
        Me.ButtonCercaLiquido.Text = "Button1"
        Me.ButtonCercaLiquido.UseVisualStyleBackColor = True
        '
        'FormSinistri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 439)
        Me.Controls.Add(Me.tlpSinistri)
        Me.Controls.Add(Me.StatusStripSinistri)
        Me.Name = "FormSinistri"
        Me.Text = "FormSinistri"
        Me.StatusStripSinistri.ResumeLayout(False)
        Me.StatusStripSinistri.PerformLayout()
        Me.tlpSinistri.ResumeLayout(False)
        Me.tlpSinistri.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStripSinistri As System.Windows.Forms.StatusStrip
    Friend WithEvents tssMessaggio As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tlpSinistri As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelNumeroSinistro As System.Windows.Forms.Label
    Friend WithEvents LabelAssicurato As System.Windows.Forms.Label
    Friend WithEvents LabelNumeroSinistri As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCercaIn As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxEsatto As System.Windows.Forms.CheckBox
    Friend WithEvents LabelSemaforoRicerca As System.Windows.Forms.Label
    Friend WithEvents LabelSemaforoSelezione As System.Windows.Forms.Label
    Friend WithEvents tsMainMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents ComboBoxLayout As System.Windows.Forms.ComboBox
    Friend WithEvents LabelCerca As System.Windows.Forms.Label
    Friend WithEvents ButtonSelezionaEsercizi As Utx.MyFlatButton
    Friend WithEvents ComboBoxTipoTabella As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxChiusura As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxElencoCompleto As System.Windows.Forms.CheckBox
    Friend WithEvents LabelValore As System.Windows.Forms.Label
    Friend WithEvents LabelChiusura As System.Windows.Forms.Label
    Friend WithEvents ButtonReset As UtControls.UtFlatButton
    Friend WithEvents pbSinistri As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ButtonPulisciCerca As UtControls.UtFlatButton
    Friend WithEvents ButtonCercaOM As UtControls.UtFlatButton
    Friend WithEvents ButtonCercaLiquido As Windows.Forms.Button
End Class
