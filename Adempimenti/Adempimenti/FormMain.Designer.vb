<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAdempimenti
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
        Me.tsMainMenu = New System.Windows.Forms.ToolStrip()
        Me.TabControlMain = New Utx.UtTabControl()
        Me.TabPageBuste = New System.Windows.Forms.TabPage()
        Me.tlpElenco = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonSalvaNota = New System.Windows.Forms.Button()
        Me.dgvBuste = New System.Windows.Forms.DataGridView()
        Me.LabelNumeroRighe = New System.Windows.Forms.Label()
        Me.TextBoxNota = New System.Windows.Forms.TextBox()
        Me.CheckBoxMostraQuietanze = New System.Windows.Forms.CheckBox()
        Me.ButtonOrdinamento = New System.Windows.Forms.Button()
        Me.ButtonRecuperaIncasso = New System.Windows.Forms.Button()
        Me.ButtonRicarica = New System.Windows.Forms.Button()
        Me.LabelPeriodoInizio = New System.Windows.Forms.Label()
        Me.LabelPeriodoFine = New System.Windows.Forms.Label()
        Me.dtpInizio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFine = New System.Windows.Forms.DateTimePicker()
        Me.TabPageArchivio = New System.Windows.Forms.TabPage()
        Me.tlpArchivio = New System.Windows.Forms.TableLayoutPanel()
        Me.tsMenuArchivio = New System.Windows.Forms.ToolStrip()
        Me.dgvArchivio = New System.Windows.Forms.DataGridView()
        Me.TabPageStornate = New System.Windows.Forms.TabPage()
        Me.TabPageDoc = New System.Windows.Forms.TabPage()
        Me.wbDocumentazione = New System.Windows.Forms.WebBrowser()
        Me.ButtonIndice = New System.Windows.Forms.Button()
        Me.btnIndice = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ttsStato = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlpMain.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
        Me.TabPageBuste.SuspendLayout()
        Me.tlpElenco.SuspendLayout()
        CType(Me.dgvBuste, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageArchivio.SuspendLayout()
        Me.tlpArchivio.SuspendLayout()
        CType(Me.dgvArchivio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageDoc.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.Controls.Add(Me.tsMainMenu, 0, 0)
        Me.tlpMain.Controls.Add(Me.TabControlMain, 0, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.267241!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.73276!))
        Me.tlpMain.Size = New System.Drawing.Size(1019, 522)
        Me.tlpMain.TabIndex = 0
        '
        'tsMainMenu
        '
        Me.tsMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMainMenu.Name = "tsMainMenu"
        Me.tsMainMenu.Size = New System.Drawing.Size(1019, 25)
        Me.tsMainMenu.TabIndex = 0
        Me.tsMainMenu.Text = "ToolStrip1"
        '
        'TabControlMain
        '
        Me.TabControlMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControlMain.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
        Me.TabControlMain.Controls.Add(Me.TabPageBuste)
        Me.TabControlMain.Controls.Add(Me.TabPageArchivio)
        Me.TabControlMain.Controls.Add(Me.TabPageStornate)
        Me.TabControlMain.Controls.Add(Me.TabPageDoc)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.HotTrack = True
        Me.TabControlMain.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabControlMain.Location = New System.Drawing.Point(3, 51)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(1013, 468)
        Me.TabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControlMain.TabIndex = 1
        Me.TabControlMain.Visible = False
        '
        'TabPageBuste
        '
        Me.TabPageBuste.Controls.Add(Me.tlpElenco)
        Me.TabPageBuste.Location = New System.Drawing.Point(4, 29)
        Me.TabPageBuste.Name = "TabPageBuste"
        Me.TabPageBuste.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageBuste.Size = New System.Drawing.Size(1005, 435)
        Me.TabPageBuste.TabIndex = 0
        Me.TabPageBuste.Text = "Gestione buste"
        Me.TabPageBuste.UseVisualStyleBackColor = True
        '
        'tlpElenco
        '
        Me.tlpElenco.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpElenco.ColumnCount = 9
        Me.tlpElenco.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.14286!))
        Me.tlpElenco.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.tlpElenco.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142858!))
        Me.tlpElenco.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpElenco.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142858!))
        Me.tlpElenco.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.14286!))
        Me.tlpElenco.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.14286!))
        Me.tlpElenco.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.14286!))
        Me.tlpElenco.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.14286!))
        Me.tlpElenco.Controls.Add(Me.ButtonSalvaNota, 7, 2)
        Me.tlpElenco.Controls.Add(Me.dgvBuste, 0, 1)
        Me.tlpElenco.Controls.Add(Me.LabelNumeroRighe, 8, 2)
        Me.tlpElenco.Controls.Add(Me.TextBoxNota, 0, 2)
        Me.tlpElenco.Controls.Add(Me.CheckBoxMostraQuietanze, 0, 0)
        Me.tlpElenco.Controls.Add(Me.ButtonOrdinamento, 7, 0)
        Me.tlpElenco.Controls.Add(Me.ButtonRecuperaIncasso, 6, 0)
        Me.tlpElenco.Controls.Add(Me.ButtonRicarica, 5, 0)
        Me.tlpElenco.Controls.Add(Me.LabelPeriodoInizio, 1, 0)
        Me.tlpElenco.Controls.Add(Me.LabelPeriodoFine, 3, 0)
        Me.tlpElenco.Controls.Add(Me.dtpInizio, 2, 0)
        Me.tlpElenco.Controls.Add(Me.dtpFine, 4, 0)
        Me.tlpElenco.Location = New System.Drawing.Point(3, 3)
        Me.tlpElenco.Name = "tlpElenco"
        Me.tlpElenco.RowCount = 3
        Me.tlpElenco.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.42857!))
        Me.tlpElenco.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.79221!))
        Me.tlpElenco.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.77922!))
        Me.tlpElenco.Size = New System.Drawing.Size(999, 414)
        Me.tlpElenco.TabIndex = 2
        '
        'ButtonSalvaNota
        '
        Me.ButtonSalvaNota.Location = New System.Drawing.Point(693, 330)
        Me.ButtonSalvaNota.Name = "ButtonSalvaNota"
        Me.ButtonSalvaNota.Size = New System.Drawing.Size(107, 73)
        Me.ButtonSalvaNota.TabIndex = 1
        Me.ButtonSalvaNota.Text = "Button1"
        Me.ButtonSalvaNota.UseVisualStyleBackColor = True
        '
        'dgvBuste
        '
        Me.dgvBuste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpElenco.SetColumnSpan(Me.dgvBuste, 9)
        Me.dgvBuste.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBuste.Location = New System.Drawing.Point(3, 50)
        Me.dgvBuste.Name = "dgvBuste"
        Me.dgvBuste.Size = New System.Drawing.Size(993, 274)
        Me.dgvBuste.TabIndex = 0
        '
        'LabelNumeroRighe
        '
        Me.LabelNumeroRighe.AutoSize = True
        Me.LabelNumeroRighe.Location = New System.Drawing.Point(847, 327)
        Me.LabelNumeroRighe.Name = "LabelNumeroRighe"
        Me.LabelNumeroRighe.Size = New System.Drawing.Size(39, 13)
        Me.LabelNumeroRighe.TabIndex = 2
        Me.LabelNumeroRighe.Text = "Label1"
        '
        'TextBoxNota
        '
        Me.tlpElenco.SetColumnSpan(Me.TextBoxNota, 7)
        Me.TextBoxNota.Location = New System.Drawing.Point(3, 330)
        Me.TextBoxNota.Multiline = True
        Me.TextBoxNota.Name = "TextBoxNota"
        Me.TextBoxNota.Size = New System.Drawing.Size(92, 73)
        Me.TextBoxNota.TabIndex = 3
        '
        'CheckBoxMostraQuietanze
        '
        Me.CheckBoxMostraQuietanze.AutoSize = True
        Me.CheckBoxMostraQuietanze.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxMostraQuietanze.Location = New System.Drawing.Point(3, 3)
        Me.CheckBoxMostraQuietanze.Name = "CheckBoxMostraQuietanze"
        Me.CheckBoxMostraQuietanze.Size = New System.Drawing.Size(148, 41)
        Me.CheckBoxMostraQuietanze.TabIndex = 4
        Me.CheckBoxMostraQuietanze.Text = "CheckBox1"
        Me.CheckBoxMostraQuietanze.UseVisualStyleBackColor = True
        '
        'ButtonOrdinamento
        '
        Me.tlpElenco.SetColumnSpan(Me.ButtonOrdinamento, 2)
        Me.ButtonOrdinamento.Location = New System.Drawing.Point(693, 3)
        Me.ButtonOrdinamento.Name = "ButtonOrdinamento"
        Me.ButtonOrdinamento.Size = New System.Drawing.Size(82, 27)
        Me.ButtonOrdinamento.TabIndex = 5
        Me.ButtonOrdinamento.Text = "Button1"
        Me.ButtonOrdinamento.UseVisualStyleBackColor = True
        '
        'ButtonRecuperaIncasso
        '
        Me.ButtonRecuperaIncasso.Location = New System.Drawing.Point(539, 3)
        Me.ButtonRecuperaIncasso.Name = "ButtonRecuperaIncasso"
        Me.ButtonRecuperaIncasso.Size = New System.Drawing.Size(53, 28)
        Me.ButtonRecuperaIncasso.TabIndex = 6
        Me.ButtonRecuperaIncasso.Text = "Button1"
        Me.ButtonRecuperaIncasso.UseVisualStyleBackColor = True
        '
        'ButtonRicarica
        '
        Me.ButtonRicarica.Location = New System.Drawing.Point(385, 3)
        Me.ButtonRicarica.Name = "ButtonRicarica"
        Me.ButtonRicarica.Size = New System.Drawing.Size(107, 28)
        Me.ButtonRicarica.TabIndex = 7
        Me.ButtonRicarica.Text = "Button1"
        Me.ButtonRicarica.UseVisualStyleBackColor = True
        '
        'LabelPeriodoInizio
        '
        Me.LabelPeriodoInizio.AutoSize = True
        Me.LabelPeriodoInizio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPeriodoInizio.Location = New System.Drawing.Point(157, 0)
        Me.LabelPeriodoInizio.Name = "LabelPeriodoInizio"
        Me.LabelPeriodoInizio.Size = New System.Drawing.Size(64, 47)
        Me.LabelPeriodoInizio.TabIndex = 8
        Me.LabelPeriodoInizio.Text = "Periodo dal"
        Me.LabelPeriodoInizio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelPeriodoFine
        '
        Me.LabelPeriodoFine.AutoSize = True
        Me.LabelPeriodoFine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPeriodoFine.Location = New System.Drawing.Point(291, 0)
        Me.LabelPeriodoFine.Name = "LabelPeriodoFine"
        Me.LabelPeriodoFine.Size = New System.Drawing.Size(24, 47)
        Me.LabelPeriodoFine.TabIndex = 9
        Me.LabelPeriodoFine.Text = "al"
        Me.LabelPeriodoFine.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpInizio
        '
        Me.dtpInizio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpInizio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInizio.Location = New System.Drawing.Point(227, 3)
        Me.dtpInizio.Name = "dtpInizio"
        Me.dtpInizio.Size = New System.Drawing.Size(58, 20)
        Me.dtpInizio.TabIndex = 10
        '
        'dtpFine
        '
        Me.dtpFine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpFine.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFine.Location = New System.Drawing.Point(321, 3)
        Me.dtpFine.Name = "dtpFine"
        Me.dtpFine.Size = New System.Drawing.Size(58, 20)
        Me.dtpFine.TabIndex = 11
        '
        'TabPageArchivio
        '
        Me.TabPageArchivio.Controls.Add(Me.tlpArchivio)
        Me.TabPageArchivio.Location = New System.Drawing.Point(4, 29)
        Me.TabPageArchivio.Name = "TabPageArchivio"
        Me.TabPageArchivio.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageArchivio.Size = New System.Drawing.Size(1005, 435)
        Me.TabPageArchivio.TabIndex = 1
        Me.TabPageArchivio.Text = "Archivio buste"
        Me.TabPageArchivio.UseVisualStyleBackColor = True
        '
        'tlpArchivio
        '
        Me.tlpArchivio.ColumnCount = 1
        Me.tlpArchivio.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpArchivio.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpArchivio.Controls.Add(Me.tsMenuArchivio, 0, 0)
        Me.tlpArchivio.Controls.Add(Me.dgvArchivio, 0, 1)
        Me.tlpArchivio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpArchivio.Location = New System.Drawing.Point(3, 3)
        Me.tlpArchivio.Name = "tlpArchivio"
        Me.tlpArchivio.RowCount = 2
        Me.tlpArchivio.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.70833!))
        Me.tlpArchivio.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.29166!))
        Me.tlpArchivio.Size = New System.Drawing.Size(999, 429)
        Me.tlpArchivio.TabIndex = 3
        '
        'tsMenuArchivio
        '
        Me.tsMenuArchivio.Location = New System.Drawing.Point(0, 0)
        Me.tsMenuArchivio.Name = "tsMenuArchivio"
        Me.tsMenuArchivio.Size = New System.Drawing.Size(999, 25)
        Me.tsMenuArchivio.TabIndex = 3
        Me.tsMenuArchivio.Text = "ToolStrip1"
        '
        'dgvArchivio
        '
        Me.dgvArchivio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvArchivio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArchivio.Location = New System.Drawing.Point(0, 78)
        Me.dgvArchivio.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.dgvArchivio.Name = "dgvArchivio"
        Me.dgvArchivio.Size = New System.Drawing.Size(999, 351)
        Me.dgvArchivio.TabIndex = 1
        '
        'TabPageStornate
        '
        Me.TabPageStornate.Location = New System.Drawing.Point(4, 29)
        Me.TabPageStornate.Name = "TabPageStornate"
        Me.TabPageStornate.Size = New System.Drawing.Size(1005, 435)
        Me.TabPageStornate.TabIndex = 2
        Me.TabPageStornate.Text = "Stornate"
        Me.TabPageStornate.UseVisualStyleBackColor = True
        '
        'TabPageDoc
        '
        Me.TabPageDoc.Controls.Add(Me.wbDocumentazione)
        Me.TabPageDoc.Controls.Add(Me.ButtonIndice)
        Me.TabPageDoc.Location = New System.Drawing.Point(4, 29)
        Me.TabPageDoc.Name = "TabPageDoc"
        Me.TabPageDoc.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDoc.Size = New System.Drawing.Size(1005, 435)
        Me.TabPageDoc.TabIndex = 3
        Me.TabPageDoc.Text = "Documentazione"
        Me.TabPageDoc.UseVisualStyleBackColor = True
        '
        'wbDocumentazione
        '
        Me.wbDocumentazione.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wbDocumentazione.Location = New System.Drawing.Point(3, 32)
        Me.wbDocumentazione.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbDocumentazione.Name = "wbDocumentazione"
        Me.wbDocumentazione.Size = New System.Drawing.Size(758, 356)
        Me.wbDocumentazione.TabIndex = 3
        '
        'ButtonIndice
        '
        Me.ButtonIndice.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonIndice.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonIndice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonIndice.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonIndice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonIndice.Location = New System.Drawing.Point(3, 3)
        Me.ButtonIndice.Name = "ButtonIndice"
        Me.ButtonIndice.Size = New System.Drawing.Size(999, 23)
        Me.ButtonIndice.TabIndex = 2
        Me.ButtonIndice.Text = "Indice"
        Me.ButtonIndice.UseVisualStyleBackColor = True
        '
        'btnIndice
        '
        Me.btnIndice.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnIndice.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnIndice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIndice.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIndice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnIndice.Location = New System.Drawing.Point(3, 3)
        Me.btnIndice.Name = "btnIndice"
        Me.btnIndice.Size = New System.Drawing.Size(758, 23)
        Me.btnIndice.TabIndex = 2
        Me.btnIndice.Text = "Indice"
        Me.btnIndice.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ttsStato})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 500)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1019, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ttsStato
        '
        Me.ttsStato.Name = "ttsStato"
        Me.ttsStato.Size = New System.Drawing.Size(120, 17)
        Me.ttsStato.Text = "ToolStripStatusLabel1"
        '
        'FormAdempimenti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 522)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormAdempimenti"
        Me.Text = "Form1"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPageBuste.ResumeLayout(False)
        Me.tlpElenco.ResumeLayout(False)
        Me.tlpElenco.PerformLayout()
        CType(Me.dgvBuste, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageArchivio.ResumeLayout(False)
        Me.tlpArchivio.ResumeLayout(False)
        Me.tlpArchivio.PerformLayout()
        CType(Me.dgvArchivio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageDoc.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tsMainMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents TabControlMain As Utx.UtTabControl
    Friend WithEvents TabPageBuste As System.Windows.Forms.TabPage
    Friend WithEvents TabPageArchivio As System.Windows.Forms.TabPage
    Friend WithEvents TabPageStornate As System.Windows.Forms.TabPage
    Friend WithEvents dgvBuste As System.Windows.Forms.DataGridView
    Friend WithEvents dgvArchivio As System.Windows.Forms.DataGridView
    Friend WithEvents TabPageDoc As System.Windows.Forms.TabPage
    Friend WithEvents wbDocumentazione As System.Windows.Forms.WebBrowser
    Friend WithEvents ButtonIndice As System.Windows.Forms.Button
    Friend WithEvents btnIndice As System.Windows.Forms.Button
    Friend WithEvents tlpArchivio As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tsMenuArchivio As System.Windows.Forms.ToolStrip
    Friend WithEvents tlpElenco As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonSalvaNota As System.Windows.Forms.Button
    Friend WithEvents LabelNumeroRighe As System.Windows.Forms.Label
    Friend WithEvents TextBoxNota As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxMostraQuietanze As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonOrdinamento As System.Windows.Forms.Button
    Friend WithEvents ButtonRecuperaIncasso As System.Windows.Forms.Button
    Friend WithEvents ButtonRicarica As System.Windows.Forms.Button
    Friend WithEvents LabelPeriodoInizio As System.Windows.Forms.Label
    Friend WithEvents LabelPeriodoFine As System.Windows.Forms.Label
    Friend WithEvents dtpInizio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFine As System.Windows.Forms.DateTimePicker
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ttsStato As System.Windows.Forms.ToolStripStatusLabel

End Class
