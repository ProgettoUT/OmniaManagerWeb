<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLog
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.UtTabMain = New Utx.UtTabControl()
        Me.TabPageLog = New System.Windows.Forms.TabPage()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonStrumenti = New System.Windows.Forms.Button()
        Me.ListBoxLog = New System.Windows.Forms.ListBox()
        Me.CheckBoxSincronizza = New System.Windows.Forms.CheckBox()
        Me.ComboBoxLogAttivi = New System.Windows.Forms.ComboBox()
        Me.ButtonApri = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonApriLogGlobale = New System.Windows.Forms.Button()
        Me.ButtonCartellaLog = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxTipiLog = New System.Windows.Forms.ComboBox()
        Me.ButtonMergeLog = New System.Windows.Forms.Button()
        Me.LabelFiltro = New System.Windows.Forms.Label()
        Me.TextBoxFiltro = New System.Windows.Forms.TextBox()
        Me.ComboBoxLivelloLog = New System.Windows.Forms.ComboBox()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.CheckBoxPrimoPiano = New System.Windows.Forms.CheckBox()
        Me.TabPageBlocchi = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ListBoxBlocchi = New System.Windows.Forms.ListBox()
        Me.ButtonInvitoChiusura = New System.Windows.Forms.Button()
        Me.ListViewSessioni = New System.Windows.Forms.ListView()
        Me.UtTabMain.SuspendLayout()
        Me.TabPageLog.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        Me.TabPageBlocchi.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UtTabMain
        '
        Me.UtTabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.UtTabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
        Me.UtTabMain.Controls.Add(Me.TabPageLog)
        Me.UtTabMain.Controls.Add(Me.TabPageBlocchi)
        Me.UtTabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UtTabMain.ItemSize = New System.Drawing.Size(150, 25)
        Me.UtTabMain.Location = New System.Drawing.Point(0, 0)
        Me.UtTabMain.Name = "UtTabMain"
        Me.UtTabMain.SelectedIndex = 0
        Me.UtTabMain.Size = New System.Drawing.Size(718, 610)
        Me.UtTabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.UtTabMain.TabIndex = 2
        Me.UtTabMain.Visible = False
        '
        'TabPageLog
        '
        Me.TabPageLog.Controls.Add(Me.tlpMain)
        Me.TabPageLog.Location = New System.Drawing.Point(4, 29)
        Me.TabPageLog.Name = "TabPageLog"
        Me.TabPageLog.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageLog.Size = New System.Drawing.Size(710, 577)
        Me.TabPageLog.TabIndex = 0
        Me.TabPageLog.Text = "Log"
        Me.TabPageLog.UseVisualStyleBackColor = True
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 4
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.Controls.Add(Me.ButtonStrumenti, 3, 2)
        Me.tlpMain.Controls.Add(Me.ListBoxLog, 0, 4)
        Me.tlpMain.Controls.Add(Me.CheckBoxSincronizza, 0, 5)
        Me.tlpMain.Controls.Add(Me.ComboBoxLogAttivi, 1, 0)
        Me.tlpMain.Controls.Add(Me.ButtonApri, 3, 0)
        Me.tlpMain.Controls.Add(Me.Label1, 0, 2)
        Me.tlpMain.Controls.Add(Me.ButtonApriLogGlobale, 2, 5)
        Me.tlpMain.Controls.Add(Me.ButtonCartellaLog, 1, 5)
        Me.tlpMain.Controls.Add(Me.Label2, 0, 0)
        Me.tlpMain.Controls.Add(Me.Label3, 0, 1)
        Me.tlpMain.Controls.Add(Me.ComboBoxTipiLog, 1, 1)
        Me.tlpMain.Controls.Add(Me.ButtonMergeLog, 3, 1)
        Me.tlpMain.Controls.Add(Me.LabelFiltro, 0, 3)
        Me.tlpMain.Controls.Add(Me.TextBoxFiltro, 1, 3)
        Me.tlpMain.Controls.Add(Me.ComboBoxLivelloLog, 1, 2)
        Me.tlpMain.Controls.Add(Me.ButtonClear, 3, 5)
        Me.tlpMain.Controls.Add(Me.CheckBoxPrimoPiano, 3, 3)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(3, 3)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 6
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.Size = New System.Drawing.Size(704, 571)
        Me.tlpMain.TabIndex = 1
        '
        'ButtonStrumenti
        '
        Me.ButtonStrumenti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonStrumenti.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonStrumenti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStrumenti.Location = New System.Drawing.Point(531, 63)
        Me.ButtonStrumenti.Name = "ButtonStrumenti"
        Me.ButtonStrumenti.Size = New System.Drawing.Size(170, 24)
        Me.ButtonStrumenti.TabIndex = 14
        Me.ButtonStrumenti.Text = "Button1"
        Me.ButtonStrumenti.UseVisualStyleBackColor = True
        '
        'ListBoxLog
        '
        Me.tlpMain.SetColumnSpan(Me.ListBoxLog, 4)
        Me.ListBoxLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxLog.FormattingEnabled = True
        Me.ListBoxLog.IntegralHeight = False
        Me.ListBoxLog.Location = New System.Drawing.Point(3, 118)
        Me.ListBoxLog.Name = "ListBoxLog"
        Me.ListBoxLog.ScrollAlwaysVisible = True
        Me.ListBoxLog.Size = New System.Drawing.Size(698, 420)
        Me.ListBoxLog.TabIndex = 0
        '
        'CheckBoxSincronizza
        '
        Me.CheckBoxSincronizza.AutoSize = True
        Me.CheckBoxSincronizza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxSincronizza.Location = New System.Drawing.Point(3, 544)
        Me.CheckBoxSincronizza.Name = "CheckBoxSincronizza"
        Me.CheckBoxSincronizza.Size = New System.Drawing.Size(170, 24)
        Me.CheckBoxSincronizza.TabIndex = 1
        Me.CheckBoxSincronizza.Text = "Segui il flusso dei log"
        Me.CheckBoxSincronizza.UseVisualStyleBackColor = True
        '
        'ComboBoxLogAttivi
        '
        Me.tlpMain.SetColumnSpan(Me.ComboBoxLogAttivi, 2)
        Me.ComboBoxLogAttivi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxLogAttivi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLogAttivi.FormattingEnabled = True
        Me.ComboBoxLogAttivi.Location = New System.Drawing.Point(179, 3)
        Me.ComboBoxLogAttivi.Name = "ComboBoxLogAttivi"
        Me.ComboBoxLogAttivi.Size = New System.Drawing.Size(346, 21)
        Me.ComboBoxLogAttivi.TabIndex = 2
        '
        'ButtonApri
        '
        Me.ButtonApri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonApri.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonApri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonApri.Location = New System.Drawing.Point(531, 3)
        Me.ButtonApri.Name = "ButtonApri"
        Me.ButtonApri.Size = New System.Drawing.Size(170, 24)
        Me.ButtonApri.TabIndex = 3
        Me.ButtonApri.Text = "Button1"
        Me.ButtonApri.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.YellowGreen
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 63)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Flusso dei log attivi"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonApriLogGlobale
        '
        Me.ButtonApriLogGlobale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonApriLogGlobale.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonApriLogGlobale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonApriLogGlobale.Location = New System.Drawing.Point(355, 544)
        Me.ButtonApriLogGlobale.Name = "ButtonApriLogGlobale"
        Me.ButtonApriLogGlobale.Size = New System.Drawing.Size(170, 24)
        Me.ButtonApriLogGlobale.TabIndex = 5
        Me.ButtonApriLogGlobale.Text = "Button1"
        Me.ButtonApriLogGlobale.UseVisualStyleBackColor = True
        '
        'ButtonCartellaLog
        '
        Me.ButtonCartellaLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCartellaLog.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonCartellaLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCartellaLog.Location = New System.Drawing.Point(179, 544)
        Me.ButtonCartellaLog.Name = "ButtonCartellaLog"
        Me.ButtonCartellaLog.Size = New System.Drawing.Size(170, 24)
        Me.ButtonCartellaLog.TabIndex = 6
        Me.ButtonCartellaLog.Text = "Button1"
        Me.ButtonCartellaLog.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 30)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Elenco dei log attivi"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 30)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Elenco dei tipi di log"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxTipiLog
        '
        Me.tlpMain.SetColumnSpan(Me.ComboBoxTipiLog, 2)
        Me.ComboBoxTipiLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxTipiLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTipiLog.FormattingEnabled = True
        Me.ComboBoxTipiLog.Location = New System.Drawing.Point(179, 33)
        Me.ComboBoxTipiLog.Name = "ComboBoxTipiLog"
        Me.ComboBoxTipiLog.Size = New System.Drawing.Size(346, 21)
        Me.ComboBoxTipiLog.TabIndex = 9
        '
        'ButtonMergeLog
        '
        Me.ButtonMergeLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonMergeLog.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonMergeLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonMergeLog.Location = New System.Drawing.Point(531, 33)
        Me.ButtonMergeLog.Name = "ButtonMergeLog"
        Me.ButtonMergeLog.Size = New System.Drawing.Size(170, 24)
        Me.ButtonMergeLog.TabIndex = 10
        Me.ButtonMergeLog.Text = "Button1"
        Me.ButtonMergeLog.UseVisualStyleBackColor = True
        '
        'LabelFiltro
        '
        Me.LabelFiltro.AutoSize = True
        Me.LabelFiltro.BackColor = System.Drawing.SystemColors.Control
        Me.LabelFiltro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelFiltro.Location = New System.Drawing.Point(3, 90)
        Me.LabelFiltro.Name = "LabelFiltro"
        Me.LabelFiltro.Size = New System.Drawing.Size(170, 25)
        Me.LabelFiltro.TabIndex = 11
        Me.LabelFiltro.Text = "Filtro"
        Me.LabelFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxFiltro
        '
        Me.TextBoxFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpMain.SetColumnSpan(Me.TextBoxFiltro, 2)
        Me.TextBoxFiltro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxFiltro.Location = New System.Drawing.Point(179, 93)
        Me.TextBoxFiltro.Name = "TextBoxFiltro"
        Me.TextBoxFiltro.Size = New System.Drawing.Size(346, 20)
        Me.TextBoxFiltro.TabIndex = 12
        '
        'ComboBoxLivelloLog
        '
        Me.tlpMain.SetColumnSpan(Me.ComboBoxLivelloLog, 2)
        Me.ComboBoxLivelloLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxLivelloLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLivelloLog.FormattingEnabled = True
        Me.ComboBoxLivelloLog.Location = New System.Drawing.Point(179, 63)
        Me.ComboBoxLivelloLog.Name = "ComboBoxLivelloLog"
        Me.ComboBoxLivelloLog.Size = New System.Drawing.Size(346, 21)
        Me.ComboBoxLivelloLog.TabIndex = 13
        '
        'ButtonClear
        '
        Me.ButtonClear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonClear.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClear.Location = New System.Drawing.Point(531, 544)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(170, 24)
        Me.ButtonClear.TabIndex = 15
        Me.ButtonClear.Text = "Button1"
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'CheckBoxPrimoPiano
        '
        Me.CheckBoxPrimoPiano.AutoSize = True
        Me.CheckBoxPrimoPiano.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxPrimoPiano.Location = New System.Drawing.Point(531, 93)
        Me.CheckBoxPrimoPiano.Name = "CheckBoxPrimoPiano"
        Me.CheckBoxPrimoPiano.Size = New System.Drawing.Size(170, 19)
        Me.CheckBoxPrimoPiano.TabIndex = 16
        Me.CheckBoxPrimoPiano.Text = "Log in primo piano"
        Me.CheckBoxPrimoPiano.UseVisualStyleBackColor = True
        '
        'TabPageBlocchi
        '
        Me.TabPageBlocchi.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPageBlocchi.Location = New System.Drawing.Point(4, 29)
        Me.TabPageBlocchi.Name = "TabPageBlocchi"
        Me.TabPageBlocchi.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageBlocchi.Size = New System.Drawing.Size(710, 577)
        Me.TabPageBlocchi.TabIndex = 1
        Me.TabPageBlocchi.Text = "Blocchi e Sessioni"
        Me.TabPageBlocchi.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ListBoxBlocchi, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonInvitoChiusura, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ListViewSessioni, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(704, 571)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'ListBoxBlocchi
        '
        Me.ListBoxBlocchi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxBlocchi.FormattingEnabled = True
        Me.ListBoxBlocchi.Location = New System.Drawing.Point(3, 3)
        Me.ListBoxBlocchi.Name = "ListBoxBlocchi"
        Me.ListBoxBlocchi.Size = New System.Drawing.Size(698, 156)
        Me.ListBoxBlocchi.TabIndex = 0
        '
        'ButtonInvitoChiusura
        '
        Me.ButtonInvitoChiusura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonInvitoChiusura.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonInvitoChiusura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonInvitoChiusura.Location = New System.Drawing.Point(3, 541)
        Me.ButtonInvitoChiusura.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
        Me.ButtonInvitoChiusura.Name = "ButtonInvitoChiusura"
        Me.ButtonInvitoChiusura.Size = New System.Drawing.Size(698, 29)
        Me.ButtonInvitoChiusura.TabIndex = 2
        Me.ButtonInvitoChiusura.Text = "Button1"
        Me.ButtonInvitoChiusura.UseVisualStyleBackColor = True
        '
        'ListViewSessioni
        '
        Me.ListViewSessioni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewSessioni.HideSelection = False
        Me.ListViewSessioni.Location = New System.Drawing.Point(3, 165)
        Me.ListViewSessioni.Name = "ListViewSessioni"
        Me.ListViewSessioni.Size = New System.Drawing.Size(698, 372)
        Me.ListViewSessioni.TabIndex = 3
        Me.ListViewSessioni.UseCompatibleStateImageBehavior = False
        '
        'FormLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 610)
        Me.Controls.Add(Me.UtTabMain)
        Me.Name = "FormLog"
        Me.Text = "FormLog"
        Me.UtTabMain.ResumeLayout(False)
        Me.TabPageLog.ResumeLayout(False)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.TabPageBlocchi.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBoxLog As System.Windows.Forms.ListBox
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxSincronizza As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxLogAttivi As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonApri As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonApriLogGlobale As System.Windows.Forms.Button
    Friend WithEvents ButtonCartellaLog As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTipiLog As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonMergeLog As System.Windows.Forms.Button
    Friend WithEvents UtTabMain As Utx.UtTabControl
    Friend WithEvents TabPageLog As System.Windows.Forms.TabPage
    Friend WithEvents TabPageBlocchi As System.Windows.Forms.TabPage
    Friend WithEvents ListBoxBlocchi As System.Windows.Forms.ListBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonInvitoChiusura As System.Windows.Forms.Button
    Friend WithEvents ListViewSessioni As System.Windows.Forms.ListView
    Friend WithEvents LabelFiltro As System.Windows.Forms.Label
    Friend WithEvents TextBoxFiltro As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxLivelloLog As Windows.Forms.ComboBox
    Friend WithEvents ButtonStrumenti As Windows.Forms.Button
    Friend WithEvents ButtonClear As Windows.Forms.Button
    Friend WithEvents CheckBoxPrimoPiano As Windows.Forms.CheckBox
End Class
