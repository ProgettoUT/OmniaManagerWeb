<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRipristina
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.cboOrigine = New System.Windows.Forms.ComboBox()
        Me.cboAgenzia = New System.Windows.Forms.ComboBox()
        Me.btnSelezionaTutti = New System.Windows.Forms.Button()
        Me.btnDeselezionaTutti = New System.Windows.Forms.Button()
        Me.btnRipristina = New System.Windows.Forms.Button()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageTabelle = New System.Windows.Forms.TabPage()
        Me.btnRecuperoAutomatico = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboDatabase = New System.Windows.Forms.ComboBox()
        Me.TabPageAnalisi = New System.Windows.Forms.TabPage()
        Me.btnAnalisi = New System.Windows.Forms.Button()
        Me.lbAnalisi = New System.Windows.Forms.ListBox()
        Me.TabPageStorico = New System.Windows.Forms.TabPage()
        Me.dgvStoricoTabella = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTabella = New System.Windows.Forms.ComboBox()
        Me.TabPageLog = New System.Windows.Forms.TabPage()
        Me.lbLog = New System.Windows.Forms.ListBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioButtonRete = New System.Windows.Forms.RadioButton()
        Me.RadioButtonLocale = New System.Windows.Forms.RadioButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lbStato = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbDettaglio = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1.SuspendLayout()
        Me.TabPageTabelle.SuspendLayout()
        Me.TabPageAnalisi.SuspendLayout()
        Me.TabPageStorico.SuspendLayout()
        CType(Me.dgvStoricoTabella, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageLog.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboOrigine
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboOrigine, 3)
        Me.cboOrigine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboOrigine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigine.FormattingEnabled = True
        Me.cboOrigine.Location = New System.Drawing.Point(113, 31)
        Me.cboOrigine.Name = "cboOrigine"
        Me.cboOrigine.Size = New System.Drawing.Size(324, 22)
        Me.cboOrigine.TabIndex = 0
        '
        'cboAgenzia
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboAgenzia, 3)
        Me.cboAgenzia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboAgenzia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgenzia.FormattingEnabled = True
        Me.cboAgenzia.Location = New System.Drawing.Point(113, 3)
        Me.cboAgenzia.Name = "cboAgenzia"
        Me.cboAgenzia.Size = New System.Drawing.Size(324, 22)
        Me.cboAgenzia.TabIndex = 1
        '
        'btnSelezionaTutti
        '
        Me.btnSelezionaTutti.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnSelezionaTutti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelezionaTutti.Location = New System.Drawing.Point(6, 369)
        Me.btnSelezionaTutti.Name = "btnSelezionaTutti"
        Me.btnSelezionaTutti.Size = New System.Drawing.Size(336, 37)
        Me.btnSelezionaTutti.TabIndex = 4
        Me.btnSelezionaTutti.Text = "Seleziona tutti"
        Me.btnSelezionaTutti.UseVisualStyleBackColor = True
        '
        'btnDeselezionaTutti
        '
        Me.btnDeselezionaTutti.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnDeselezionaTutti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeselezionaTutti.Location = New System.Drawing.Point(348, 369)
        Me.btnDeselezionaTutti.Name = "btnDeselezionaTutti"
        Me.btnDeselezionaTutti.Size = New System.Drawing.Size(333, 37)
        Me.btnDeselezionaTutti.TabIndex = 5
        Me.btnDeselezionaTutti.Text = "Deseleziona tutti"
        Me.btnDeselezionaTutti.UseVisualStyleBackColor = True
        '
        'btnRipristina
        '
        Me.btnRipristina.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnRipristina.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRipristina.Location = New System.Drawing.Point(6, 412)
        Me.btnRipristina.Name = "btnRipristina"
        Me.btnRipristina.Size = New System.Drawing.Size(336, 52)
        Me.btnRipristina.TabIndex = 7
        Me.btnRipristina.Text = "Ripristina le tabelle selezionate"
        Me.btnRipristina.UseVisualStyleBackColor = True
        '
        'btnEsci
        '
        Me.btnEsci.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEsci.Location = New System.Drawing.Point(523, 15)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(182, 57)
        Me.btnEsci.TabIndex = 8
        Me.btnEsci.Text = "Esci"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPageTabelle)
        Me.TabControl1.Controls.Add(Me.TabPageAnalisi)
        Me.TabControl1.Controls.Add(Me.TabPageStorico)
        Me.TabControl1.Controls.Add(Me.TabPageLog)
        Me.TabControl1.Location = New System.Drawing.Point(8, 78)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(697, 499)
        Me.TabControl1.TabIndex = 9
        '
        'TabPageTabelle
        '
        Me.TabPageTabelle.Controls.Add(Me.btnRecuperoAutomatico)
        Me.TabPageTabelle.Controls.Add(Me.ListView1)
        Me.TabPageTabelle.Controls.Add(Me.Label3)
        Me.TabPageTabelle.Controls.Add(Me.cboDatabase)
        Me.TabPageTabelle.Controls.Add(Me.btnDeselezionaTutti)
        Me.TabPageTabelle.Controls.Add(Me.btnRipristina)
        Me.TabPageTabelle.Controls.Add(Me.btnSelezionaTutti)
        Me.TabPageTabelle.Location = New System.Drawing.Point(4, 23)
        Me.TabPageTabelle.Name = "TabPageTabelle"
        Me.TabPageTabelle.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPageTabelle.Size = New System.Drawing.Size(689, 472)
        Me.TabPageTabelle.TabIndex = 0
        Me.TabPageTabelle.Text = "TabPage1"
        Me.TabPageTabelle.UseVisualStyleBackColor = True
        '
        'btnRecuperoAutomatico
        '
        Me.btnRecuperoAutomatico.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnRecuperoAutomatico.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecuperoAutomatico.Location = New System.Drawing.Point(348, 412)
        Me.btnRecuperoAutomatico.Name = "btnRecuperoAutomatico"
        Me.btnRecuperoAutomatico.Size = New System.Drawing.Size(333, 52)
        Me.btnRecuperoAutomatico.TabIndex = 11
        Me.btnRecuperoAutomatico.Text = "Recupero automatico"
        Me.btnRecuperoAutomatico.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Location = New System.Drawing.Point(8, 36)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(673, 327)
        Me.ListView1.TabIndex = 10
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 14)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Tabelle visualizzate"
        '
        'cboDatabase
        '
        Me.cboDatabase.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDatabase.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cboDatabase.FormattingEnabled = True
        Me.cboDatabase.Location = New System.Drawing.Point(122, 8)
        Me.cboDatabase.MaxDropDownItems = 15
        Me.cboDatabase.Name = "cboDatabase"
        Me.cboDatabase.Size = New System.Drawing.Size(559, 22)
        Me.cboDatabase.TabIndex = 8
        '
        'TabPageAnalisi
        '
        Me.TabPageAnalisi.Controls.Add(Me.btnAnalisi)
        Me.TabPageAnalisi.Controls.Add(Me.lbAnalisi)
        Me.TabPageAnalisi.Location = New System.Drawing.Point(4, 23)
        Me.TabPageAnalisi.Name = "TabPageAnalisi"
        Me.TabPageAnalisi.Size = New System.Drawing.Size(689, 472)
        Me.TabPageAnalisi.TabIndex = 2
        Me.TabPageAnalisi.Text = "TabPage2"
        Me.TabPageAnalisi.UseVisualStyleBackColor = True
        '
        'btnAnalisi
        '
        Me.btnAnalisi.Location = New System.Drawing.Point(3, 419)
        Me.btnAnalisi.Name = "btnAnalisi"
        Me.btnAnalisi.Size = New System.Drawing.Size(683, 50)
        Me.btnAnalisi.TabIndex = 1
        Me.btnAnalisi.Text = "Button1"
        Me.btnAnalisi.UseVisualStyleBackColor = True
        '
        'lbAnalisi
        '
        Me.lbAnalisi.FormattingEnabled = True
        Me.lbAnalisi.ItemHeight = 14
        Me.lbAnalisi.Location = New System.Drawing.Point(3, 3)
        Me.lbAnalisi.Name = "lbAnalisi"
        Me.lbAnalisi.Size = New System.Drawing.Size(683, 410)
        Me.lbAnalisi.TabIndex = 0
        '
        'TabPageStorico
        '
        Me.TabPageStorico.Controls.Add(Me.dgvStoricoTabella)
        Me.TabPageStorico.Controls.Add(Me.Label4)
        Me.TabPageStorico.Controls.Add(Me.cboTabella)
        Me.TabPageStorico.Location = New System.Drawing.Point(4, 23)
        Me.TabPageStorico.Name = "TabPageStorico"
        Me.TabPageStorico.Size = New System.Drawing.Size(689, 472)
        Me.TabPageStorico.TabIndex = 4
        Me.TabPageStorico.Text = "TabPage1"
        Me.TabPageStorico.UseVisualStyleBackColor = True
        '
        'dgvStoricoTabella
        '
        Me.dgvStoricoTabella.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStoricoTabella.Location = New System.Drawing.Point(3, 42)
        Me.dgvStoricoTabella.Name = "dgvStoricoTabella"
        Me.dgvStoricoTabella.Size = New System.Drawing.Size(678, 427)
        Me.dgvStoricoTabella.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 14)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Tabella"
        '
        'cboTabella
        '
        Me.cboTabella.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTabella.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTabella.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cboTabella.FormattingEnabled = True
        Me.cboTabella.Location = New System.Drawing.Point(59, 14)
        Me.cboTabella.MaxDropDownItems = 15
        Me.cboTabella.Name = "cboTabella"
        Me.cboTabella.Size = New System.Drawing.Size(622, 22)
        Me.cboTabella.TabIndex = 10
        '
        'TabPageLog
        '
        Me.TabPageLog.Controls.Add(Me.lbLog)
        Me.TabPageLog.Location = New System.Drawing.Point(4, 23)
        Me.TabPageLog.Name = "TabPageLog"
        Me.TabPageLog.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageLog.Size = New System.Drawing.Size(689, 472)
        Me.TabPageLog.TabIndex = 3
        Me.TabPageLog.Text = "TabPage4"
        Me.TabPageLog.UseVisualStyleBackColor = True
        '
        'lbLog
        '
        Me.lbLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbLog.FormattingEnabled = True
        Me.lbLog.ItemHeight = 14
        Me.lbLog.Location = New System.Drawing.Point(3, 3)
        Me.lbLog.Name = "lbLog"
        Me.lbLog.Size = New System.Drawing.Size(683, 466)
        Me.lbLog.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboAgenzia, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboOrigine, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.RadioButtonRete, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RadioButtonLocale, 4, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(8, 15)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(509, 57)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 29)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Backup del"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 28)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Agenzia"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadioButtonRete
        '
        Me.RadioButtonRete.AutoSize = True
        Me.RadioButtonRete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonRete.Location = New System.Drawing.Point(443, 3)
        Me.RadioButtonRete.Name = "RadioButtonRete"
        Me.RadioButtonRete.Size = New System.Drawing.Size(63, 22)
        Me.RadioButtonRete.TabIndex = 13
        Me.RadioButtonRete.TabStop = True
        Me.RadioButtonRete.Text = "su M:"
        Me.RadioButtonRete.UseVisualStyleBackColor = True
        '
        'RadioButtonLocale
        '
        Me.RadioButtonLocale.AutoSize = True
        Me.RadioButtonLocale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonLocale.Location = New System.Drawing.Point(443, 31)
        Me.RadioButtonLocale.Name = "RadioButtonLocale"
        Me.RadioButtonLocale.Size = New System.Drawing.Size(63, 23)
        Me.RadioButtonLocale.TabIndex = 14
        Me.RadioButtonLocale.TabStop = True
        Me.RadioButtonLocale.Text = "su C:"
        Me.RadioButtonLocale.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 581)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(712, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbStato
        '
        Me.lbStato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lbStato.Name = "lbStato"
        Me.lbStato.Size = New System.Drawing.Size(44, 17)
        Me.lbStato.Text = "lbStato"
        Me.lbStato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbDettaglio
        '
        Me.lbDettaglio.Name = "lbDettaglio"
        Me.lbDettaglio.Size = New System.Drawing.Size(65, 17)
        Me.lbDettaglio.Text = "lbDettaglio"
        '
        'frmRipristina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 603)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnEsci)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmRipristina"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "frmRipristina"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageTabelle.ResumeLayout(False)
        Me.TabPageTabelle.PerformLayout()
        Me.TabPageAnalisi.ResumeLayout(False)
        Me.TabPageStorico.ResumeLayout(False)
        Me.TabPageStorico.PerformLayout()
        CType(Me.dgvStoricoTabella, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageLog.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboOrigine As System.Windows.Forms.ComboBox
    Friend WithEvents cboAgenzia As System.Windows.Forms.ComboBox
    Friend WithEvents btnSelezionaTutti As System.Windows.Forms.Button
    Friend WithEvents btnDeselezionaTutti As System.Windows.Forms.Button
    Friend WithEvents btnRipristina As System.Windows.Forms.Button
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPageTabelle As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbStato As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboDatabase As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPageAnalisi As System.Windows.Forms.TabPage
    Friend WithEvents lbAnalisi As System.Windows.Forms.ListBox
    Friend WithEvents btnAnalisi As System.Windows.Forms.Button
    Friend WithEvents lbDettaglio As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents btnRecuperoAutomatico As System.Windows.Forms.Button
    Friend WithEvents TabPageLog As System.Windows.Forms.TabPage
    Friend WithEvents lbLog As System.Windows.Forms.ListBox
    Friend WithEvents RadioButtonRete As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonLocale As System.Windows.Forms.RadioButton
    Friend WithEvents TabPageStorico As System.Windows.Forms.TabPage
    Friend WithEvents dgvStoricoTabella As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTabella As System.Windows.Forms.ComboBox
End Class
