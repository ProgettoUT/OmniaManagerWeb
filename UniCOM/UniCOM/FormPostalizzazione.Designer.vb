<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPostalizzazione
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
        Me.TabMain = New Utx.UtTabControl()
        Me.TabPageConfig = New System.Windows.Forms.TabPage()
        Me.tlpConfig = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelAgenziaConfig = New System.Windows.Forms.Label()
        Me.ComboBoxAgenziaConfig = New System.Windows.Forms.ComboBox()
        Me.LabelMessaggioConfig = New System.Windows.Forms.Label()
        Me.ButtonAggiornaCip = New System.Windows.Forms.Button()
        Me.TabPageConfigUT = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelCodiciAbilitati = New System.Windows.Forms.Label()
        Me.CheckedListBoxAgenzieAbilitate = New System.Windows.Forms.CheckedListBox()
        Me.ButtonSalvaConfigUT = New System.Windows.Forms.Button()
        Me.LabelConfigUT = New System.Windows.Forms.Label()
        Me.LabelNotifica = New System.Windows.Forms.Label()
        Me.TextBoxMailNotifica = New System.Windows.Forms.TextBox()
        Me.LabelUtentiAbilitati = New System.Windows.Forms.Label()
        Me.TextBoxUtentiAbilitati = New System.Windows.Forms.TextBox()
        Me.CheckBoxRID = New System.Windows.Forms.CheckBox()
        Me.CheckBoxDomicilio = New System.Windows.Forms.CheckBox()
        Me.LabelInfoCoass = New System.Windows.Forms.Label()
        Me.TabPageAvvisi = New System.Windows.Forms.TabPage()
        Me.tlpAvvisi = New System.Windows.Forms.TableLayoutPanel()
        Me.ComboBoxAgenzia = New System.Windows.Forms.ComboBox()
        Me.ButtonVisualizza = New System.Windows.Forms.Button()
        Me.ButtonInvia = New System.Windows.Forms.Button()
        Me.LabelMese = New System.Windows.Forms.Label()
        Me.LabelNumeroAvvisi = New System.Windows.Forms.Label()
        Me.CheckBoxAggiornaDati = New System.Windows.Forms.CheckBox()
        Me.LabelAgenzia = New System.Windows.Forms.Label()
        Me.ButtonEsporta = New System.Windows.Forms.Button()
        Me.ButtonDeseleziona = New System.Windows.Forms.Button()
        Me.ButtonSeleziona = New System.Windows.Forms.Button()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvAvvisi = New System.Windows.Forms.DataGridView()
        Me.LabelInfoCliente = New System.Windows.Forms.Label()
        Me.CheckBoxDettaglioCliente = New System.Windows.Forms.CheckBox()
        Me.LabelNumeroCoass = New System.Windows.Forms.Label()
        Me.LabelInfoCoass2 = New System.Windows.Forms.Label()
        Me.ButtonAggiungi = New System.Windows.Forms.Button()
        Me.ButtonElimina = New System.Windows.Forms.Button()
        Me.TabPageTracking = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ComboBoxAgenziaTrack = New System.Windows.Forms.ComboBox()
        Me.LabelTrack = New System.Windows.Forms.Label()
        Me.TabPageAttivazione = New System.Windows.Forms.TabPage()
        Me.wbAttivazione = New System.Windows.Forms.WebBrowser()
        Me.TabPageGuida = New System.Windows.Forms.TabPage()
        Me.wbGuida = New System.Windows.Forms.WebBrowser()
        Me.TabPageReport = New System.Windows.Forms.TabPage()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.wbConfig = New System.Windows.Forms.WebBrowser()
        Me.wbTrack = New System.Windows.Forms.WebBrowser()
        Me.TabMain.SuspendLayout()
        Me.TabPageConfig.SuspendLayout()
        Me.tlpConfig.SuspendLayout()
        Me.TabPageConfigUT.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabPageAvvisi.SuspendLayout()
        Me.tlpAvvisi.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvAvvisi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageTracking.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TabPageAttivazione.SuspendLayout()
        Me.TabPageGuida.SuspendLayout()
        Me.TabPageReport.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
        Me.TabMain.Controls.Add(Me.TabPageConfig)
        Me.TabMain.Controls.Add(Me.TabPageConfigUT)
        Me.TabMain.Controls.Add(Me.TabPageAvvisi)
        Me.TabMain.Controls.Add(Me.TabPageTracking)
        Me.TabMain.Controls.Add(Me.TabPageAttivazione)
        Me.TabMain.Controls.Add(Me.TabPageGuida)
        Me.TabMain.Controls.Add(Me.TabPageReport)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Multiline = True
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(994, 589)
        Me.TabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabMain.TabIndex = 1
        Me.TabMain.Visible = False
        '
        'TabPageConfig
        '
        Me.TabPageConfig.Controls.Add(Me.tlpConfig)
        Me.TabPageConfig.Location = New System.Drawing.Point(4, 57)
        Me.TabPageConfig.Name = "TabPageConfig"
        Me.TabPageConfig.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageConfig.Size = New System.Drawing.Size(986, 528)
        Me.TabPageConfig.TabIndex = 0
        Me.TabPageConfig.Text = "Configurazione portale"
        Me.TabPageConfig.UseVisualStyleBackColor = True
        '
        'tlpConfig
        '
        Me.tlpConfig.ColumnCount = 4
        Me.tlpConfig.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpConfig.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpConfig.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpConfig.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpConfig.Controls.Add(Me.LabelAgenziaConfig, 0, 0)
        Me.tlpConfig.Controls.Add(Me.ComboBoxAgenziaConfig, 1, 0)
        Me.tlpConfig.Controls.Add(Me.LabelMessaggioConfig, 2, 0)
        Me.tlpConfig.Controls.Add(Me.ButtonAggiornaCip, 3, 0)
        Me.tlpConfig.Controls.Add(Me.wbConfig, 0, 1)
        Me.tlpConfig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpConfig.Location = New System.Drawing.Point(3, 3)
        Me.tlpConfig.Name = "tlpConfig"
        Me.tlpConfig.RowCount = 2
        Me.tlpConfig.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpConfig.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpConfig.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpConfig.Size = New System.Drawing.Size(980, 522)
        Me.tlpConfig.TabIndex = 1
        '
        'LabelAgenziaConfig
        '
        Me.LabelAgenziaConfig.AutoSize = True
        Me.LabelAgenziaConfig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelAgenziaConfig.Location = New System.Drawing.Point(0, 0)
        Me.LabelAgenziaConfig.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelAgenziaConfig.Name = "LabelAgenziaConfig"
        Me.LabelAgenziaConfig.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LabelAgenziaConfig.Size = New System.Drawing.Size(98, 25)
        Me.LabelAgenziaConfig.TabIndex = 0
        Me.LabelAgenziaConfig.Text = "Label1"
        Me.LabelAgenziaConfig.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxAgenziaConfig
        '
        Me.ComboBoxAgenziaConfig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxAgenziaConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxAgenziaConfig.FormattingEnabled = True
        Me.ComboBoxAgenziaConfig.Location = New System.Drawing.Point(98, 0)
        Me.ComboBoxAgenziaConfig.Margin = New System.Windows.Forms.Padding(0)
        Me.ComboBoxAgenziaConfig.Name = "ComboBoxAgenziaConfig"
        Me.ComboBoxAgenziaConfig.Size = New System.Drawing.Size(196, 21)
        Me.ComboBoxAgenziaConfig.TabIndex = 1
        '
        'LabelMessaggioConfig
        '
        Me.LabelMessaggioConfig.AutoSize = True
        Me.LabelMessaggioConfig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMessaggioConfig.Location = New System.Drawing.Point(294, 0)
        Me.LabelMessaggioConfig.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelMessaggioConfig.Name = "LabelMessaggioConfig"
        Me.LabelMessaggioConfig.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LabelMessaggioConfig.Size = New System.Drawing.Size(490, 25)
        Me.LabelMessaggioConfig.TabIndex = 2
        Me.LabelMessaggioConfig.Text = "Label1"
        Me.LabelMessaggioConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonAggiornaCip
        '
        Me.ButtonAggiornaCip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiornaCip.Location = New System.Drawing.Point(787, 3)
        Me.ButtonAggiornaCip.Name = "ButtonAggiornaCip"
        Me.ButtonAggiornaCip.Size = New System.Drawing.Size(190, 19)
        Me.ButtonAggiornaCip.TabIndex = 3
        Me.ButtonAggiornaCip.Text = "Button1"
        Me.ButtonAggiornaCip.UseVisualStyleBackColor = True
        '
        'TabPageConfigUT
        '
        Me.TabPageConfigUT.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPageConfigUT.Location = New System.Drawing.Point(4, 57)
        Me.TabPageConfigUT.Name = "TabPageConfigUT"
        Me.TabPageConfigUT.Size = New System.Drawing.Size(986, 528)
        Me.TabPageConfigUT.TabIndex = 3
        Me.TabPageConfigUT.Text = "Configurazione Unitools"
        Me.TabPageConfigUT.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelCodiciAbilitati, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckedListBoxAgenzieAbilitate, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSalvaConfigUT, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelConfigUT, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelNotifica, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxMailNotifica, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelUtentiAbilitati, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxUtentiAbilitati, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxRID, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxDomicilio, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelInfoCoass, 1, 7)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(986, 528)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'LabelCodiciAbilitati
        '
        Me.LabelCodiciAbilitati.AutoSize = True
        Me.LabelCodiciAbilitati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCodiciAbilitati.Location = New System.Drawing.Point(3, 60)
        Me.LabelCodiciAbilitati.Name = "LabelCodiciAbilitati"
        Me.LabelCodiciAbilitati.Size = New System.Drawing.Size(487, 30)
        Me.LabelCodiciAbilitati.TabIndex = 2
        Me.LabelCodiciAbilitati.Text = "Label1"
        Me.LabelCodiciAbilitati.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'CheckedListBoxAgenzieAbilitate
        '
        Me.CheckedListBoxAgenzieAbilitate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxAgenzieAbilitate.FormattingEnabled = True
        Me.CheckedListBoxAgenzieAbilitate.IntegralHeight = False
        Me.CheckedListBoxAgenzieAbilitate.Location = New System.Drawing.Point(3, 93)
        Me.CheckedListBoxAgenzieAbilitate.Name = "CheckedListBoxAgenzieAbilitate"
        Me.TableLayoutPanel1.SetRowSpan(Me.CheckedListBoxAgenzieAbilitate, 7)
        Me.CheckedListBoxAgenzieAbilitate.Size = New System.Drawing.Size(487, 382)
        Me.CheckedListBoxAgenzieAbilitate.TabIndex = 3
        '
        'ButtonSalvaConfigUT
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonSalvaConfigUT, 2)
        Me.ButtonSalvaConfigUT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSalvaConfigUT.Location = New System.Drawing.Point(3, 481)
        Me.ButtonSalvaConfigUT.Name = "ButtonSalvaConfigUT"
        Me.ButtonSalvaConfigUT.Size = New System.Drawing.Size(980, 44)
        Me.ButtonSalvaConfigUT.TabIndex = 4
        Me.ButtonSalvaConfigUT.Text = "Salva"
        Me.ButtonSalvaConfigUT.UseVisualStyleBackColor = True
        '
        'LabelConfigUT
        '
        Me.LabelConfigUT.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelConfigUT, 2)
        Me.LabelConfigUT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelConfigUT.Location = New System.Drawing.Point(3, 0)
        Me.LabelConfigUT.Name = "LabelConfigUT"
        Me.LabelConfigUT.Size = New System.Drawing.Size(980, 60)
        Me.LabelConfigUT.TabIndex = 5
        Me.LabelConfigUT.Text = "Label1"
        '
        'LabelNotifica
        '
        Me.LabelNotifica.AutoSize = True
        Me.LabelNotifica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNotifica.Location = New System.Drawing.Point(496, 60)
        Me.LabelNotifica.Name = "LabelNotifica"
        Me.LabelNotifica.Size = New System.Drawing.Size(487, 30)
        Me.LabelNotifica.TabIndex = 7
        Me.LabelNotifica.Text = "Label1"
        Me.LabelNotifica.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TextBoxMailNotifica
        '
        Me.TextBoxMailNotifica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxMailNotifica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxMailNotifica.Location = New System.Drawing.Point(496, 93)
        Me.TextBoxMailNotifica.Name = "TextBoxMailNotifica"
        Me.TextBoxMailNotifica.Size = New System.Drawing.Size(487, 20)
        Me.TextBoxMailNotifica.TabIndex = 6
        '
        'LabelUtentiAbilitati
        '
        Me.LabelUtentiAbilitati.AutoSize = True
        Me.LabelUtentiAbilitati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelUtentiAbilitati.Location = New System.Drawing.Point(496, 120)
        Me.LabelUtentiAbilitati.Name = "LabelUtentiAbilitati"
        Me.LabelUtentiAbilitati.Size = New System.Drawing.Size(487, 30)
        Me.LabelUtentiAbilitati.TabIndex = 8
        Me.LabelUtentiAbilitati.Text = "Label1"
        Me.LabelUtentiAbilitati.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TextBoxUtentiAbilitati
        '
        Me.TextBoxUtentiAbilitati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxUtentiAbilitati.Location = New System.Drawing.Point(496, 153)
        Me.TextBoxUtentiAbilitati.Name = "TextBoxUtentiAbilitati"
        Me.TextBoxUtentiAbilitati.Size = New System.Drawing.Size(487, 20)
        Me.TextBoxUtentiAbilitati.TabIndex = 9
        '
        'CheckBoxRID
        '
        Me.CheckBoxRID.AutoSize = True
        Me.CheckBoxRID.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CheckBoxRID.Location = New System.Drawing.Point(496, 200)
        Me.CheckBoxRID.Name = "CheckBoxRID"
        Me.CheckBoxRID.Size = New System.Drawing.Size(487, 17)
        Me.CheckBoxRID.TabIndex = 10
        Me.CheckBoxRID.Text = "CheckBox1"
        Me.CheckBoxRID.UseVisualStyleBackColor = True
        '
        'CheckBoxDomicilio
        '
        Me.CheckBoxDomicilio.AutoSize = True
        Me.CheckBoxDomicilio.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CheckBoxDomicilio.Location = New System.Drawing.Point(496, 240)
        Me.CheckBoxDomicilio.Name = "CheckBoxDomicilio"
        Me.CheckBoxDomicilio.Size = New System.Drawing.Size(487, 17)
        Me.CheckBoxDomicilio.TabIndex = 11
        Me.CheckBoxDomicilio.Text = "CheckBox1"
        Me.CheckBoxDomicilio.UseVisualStyleBackColor = True
        '
        'LabelInfoCoass
        '
        Me.LabelInfoCoass.AutoSize = True
        Me.LabelInfoCoass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfoCoass.Location = New System.Drawing.Point(496, 260)
        Me.LabelInfoCoass.Name = "LabelInfoCoass"
        Me.LabelInfoCoass.Size = New System.Drawing.Size(487, 40)
        Me.LabelInfoCoass.TabIndex = 12
        Me.LabelInfoCoass.Text = "Label1"
        Me.LabelInfoCoass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPageAvvisi
        '
        Me.TabPageAvvisi.Controls.Add(Me.tlpAvvisi)
        Me.TabPageAvvisi.Location = New System.Drawing.Point(4, 57)
        Me.TabPageAvvisi.Name = "TabPageAvvisi"
        Me.TabPageAvvisi.Size = New System.Drawing.Size(986, 528)
        Me.TabPageAvvisi.TabIndex = 2
        Me.TabPageAvvisi.Text = "Invio avvisi"
        Me.TabPageAvvisi.UseVisualStyleBackColor = True
        '
        'tlpAvvisi
        '
        Me.tlpAvvisi.ColumnCount = 7
        Me.tlpAvvisi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpAvvisi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpAvvisi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpAvvisi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpAvvisi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlpAvvisi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpAvvisi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.tlpAvvisi.Controls.Add(Me.ComboBoxAgenzia, 3, 0)
        Me.tlpAvvisi.Controls.Add(Me.ButtonVisualizza, 1, 1)
        Me.tlpAvvisi.Controls.Add(Me.ButtonInvia, 4, 1)
        Me.tlpAvvisi.Controls.Add(Me.LabelMese, 0, 0)
        Me.tlpAvvisi.Controls.Add(Me.LabelNumeroAvvisi, 6, 1)
        Me.tlpAvvisi.Controls.Add(Me.CheckBoxAggiornaDati, 4, 0)
        Me.tlpAvvisi.Controls.Add(Me.LabelAgenzia, 2, 0)
        Me.tlpAvvisi.Controls.Add(Me.ButtonEsporta, 5, 1)
        Me.tlpAvvisi.Controls.Add(Me.ButtonDeseleziona, 0, 1)
        Me.tlpAvvisi.Controls.Add(Me.ButtonSeleziona, 0, 2)
        Me.tlpAvvisi.Controls.Add(Me.LabelInfo, 0, 4)
        Me.tlpAvvisi.Controls.Add(Me.SplitContainer1, 0, 3)
        Me.tlpAvvisi.Controls.Add(Me.CheckBoxDettaglioCliente, 5, 0)
        Me.tlpAvvisi.Controls.Add(Me.LabelNumeroCoass, 6, 2)
        Me.tlpAvvisi.Controls.Add(Me.LabelInfoCoass2, 4, 4)
        Me.tlpAvvisi.Controls.Add(Me.ButtonAggiungi, 3, 1)
        Me.tlpAvvisi.Controls.Add(Me.ButtonElimina, 3, 2)
        Me.tlpAvvisi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpAvvisi.Location = New System.Drawing.Point(0, 0)
        Me.tlpAvvisi.Name = "tlpAvvisi"
        Me.tlpAvvisi.RowCount = 5
        Me.tlpAvvisi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpAvvisi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpAvvisi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpAvvisi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAvvisi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpAvvisi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpAvvisi.Size = New System.Drawing.Size(986, 528)
        Me.tlpAvvisi.TabIndex = 0
        '
        'ComboBoxAgenzia
        '
        Me.ComboBoxAgenzia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxAgenzia.FormattingEnabled = True
        Me.ComboBoxAgenzia.Location = New System.Drawing.Point(355, 3)
        Me.ComboBoxAgenzia.Name = "ComboBoxAgenzia"
        Me.ComboBoxAgenzia.Size = New System.Drawing.Size(82, 21)
        Me.ComboBoxAgenzia.TabIndex = 2
        '
        'ButtonVisualizza
        '
        Me.tlpAvvisi.SetColumnSpan(Me.ButtonVisualizza, 2)
        Me.ButtonVisualizza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonVisualizza.Location = New System.Drawing.Point(91, 33)
        Me.ButtonVisualizza.Name = "ButtonVisualizza"
        Me.tlpAvvisi.SetRowSpan(Me.ButtonVisualizza, 2)
        Me.ButtonVisualizza.Size = New System.Drawing.Size(258, 44)
        Me.ButtonVisualizza.TabIndex = 3
        Me.ButtonVisualizza.Text = "Button1"
        Me.ButtonVisualizza.UseVisualStyleBackColor = True
        '
        'ButtonInvia
        '
        Me.ButtonInvia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonInvia.Location = New System.Drawing.Point(443, 33)
        Me.ButtonInvia.Name = "ButtonInvia"
        Me.tlpAvvisi.SetRowSpan(Me.ButtonInvia, 2)
        Me.ButtonInvia.Size = New System.Drawing.Size(346, 44)
        Me.ButtonInvia.TabIndex = 4
        Me.ButtonInvia.Text = "Button2"
        Me.ButtonInvia.UseVisualStyleBackColor = True
        '
        'LabelMese
        '
        Me.LabelMese.AutoSize = True
        Me.tlpAvvisi.SetColumnSpan(Me.LabelMese, 2)
        Me.LabelMese.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMese.Location = New System.Drawing.Point(3, 0)
        Me.LabelMese.Name = "LabelMese"
        Me.LabelMese.Size = New System.Drawing.Size(258, 30)
        Me.LabelMese.TabIndex = 5
        Me.LabelMese.Text = "Label1"
        Me.LabelMese.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelNumeroAvvisi
        '
        Me.LabelNumeroAvvisi.AutoSize = True
        Me.LabelNumeroAvvisi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNumeroAvvisi.Location = New System.Drawing.Point(883, 30)
        Me.LabelNumeroAvvisi.Name = "LabelNumeroAvvisi"
        Me.LabelNumeroAvvisi.Size = New System.Drawing.Size(100, 25)
        Me.LabelNumeroAvvisi.TabIndex = 6
        Me.LabelNumeroAvvisi.Text = "Label1"
        Me.LabelNumeroAvvisi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBoxAggiornaDati
        '
        Me.CheckBoxAggiornaDati.AutoSize = True
        Me.CheckBoxAggiornaDati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxAggiornaDati.Location = New System.Drawing.Point(443, 3)
        Me.CheckBoxAggiornaDati.Name = "CheckBoxAggiornaDati"
        Me.CheckBoxAggiornaDati.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.CheckBoxAggiornaDati.Size = New System.Drawing.Size(346, 24)
        Me.CheckBoxAggiornaDati.TabIndex = 7
        Me.CheckBoxAggiornaDati.Text = "Aggiorna avvisi in scadenza da Essig"
        Me.CheckBoxAggiornaDati.UseVisualStyleBackColor = True
        '
        'LabelAgenzia
        '
        Me.LabelAgenzia.AutoSize = True
        Me.LabelAgenzia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelAgenzia.Location = New System.Drawing.Point(267, 0)
        Me.LabelAgenzia.Name = "LabelAgenzia"
        Me.LabelAgenzia.Size = New System.Drawing.Size(82, 30)
        Me.LabelAgenzia.TabIndex = 8
        Me.LabelAgenzia.Text = "Label1"
        '
        'ButtonEsporta
        '
        Me.ButtonEsporta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsporta.Location = New System.Drawing.Point(795, 33)
        Me.ButtonEsporta.Name = "ButtonEsporta"
        Me.tlpAvvisi.SetRowSpan(Me.ButtonEsporta, 2)
        Me.ButtonEsporta.Size = New System.Drawing.Size(82, 44)
        Me.ButtonEsporta.TabIndex = 9
        Me.ButtonEsporta.Text = "Button1"
        Me.ButtonEsporta.UseVisualStyleBackColor = True
        '
        'ButtonDeseleziona
        '
        Me.ButtonDeseleziona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonDeseleziona.Location = New System.Drawing.Point(3, 33)
        Me.ButtonDeseleziona.Name = "ButtonDeseleziona"
        Me.ButtonDeseleziona.Size = New System.Drawing.Size(82, 19)
        Me.ButtonDeseleziona.TabIndex = 10
        Me.ButtonDeseleziona.Text = "Button1"
        Me.ButtonDeseleziona.UseVisualStyleBackColor = True
        '
        'ButtonSeleziona
        '
        Me.ButtonSeleziona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSeleziona.Location = New System.Drawing.Point(3, 58)
        Me.ButtonSeleziona.Name = "ButtonSeleziona"
        Me.ButtonSeleziona.Size = New System.Drawing.Size(82, 19)
        Me.ButtonSeleziona.TabIndex = 11
        Me.ButtonSeleziona.Text = "Button2"
        Me.ButtonSeleziona.UseVisualStyleBackColor = True
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.tlpAvvisi.SetColumnSpan(Me.LabelInfo, 4)
        Me.LabelInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfo.Location = New System.Drawing.Point(3, 488)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(434, 40)
        Me.LabelInfo.TabIndex = 12
        Me.LabelInfo.Text = "Label1"
        Me.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainer1
        '
        Me.tlpAvvisi.SetColumnSpan(Me.SplitContainer1, 7)
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 83)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvAvvisi)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.LabelInfoCliente)
        Me.SplitContainer1.Size = New System.Drawing.Size(980, 402)
        Me.SplitContainer1.SplitterDistance = 576
        Me.SplitContainer1.TabIndex = 13
        '
        'dgvAvvisi
        '
        Me.dgvAvvisi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAvvisi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAvvisi.Location = New System.Drawing.Point(0, 0)
        Me.dgvAvvisi.Name = "dgvAvvisi"
        Me.dgvAvvisi.Size = New System.Drawing.Size(576, 402)
        Me.dgvAvvisi.TabIndex = 0
        '
        'LabelInfoCliente
        '
        Me.LabelInfoCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelInfoCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfoCliente.Location = New System.Drawing.Point(0, 0)
        Me.LabelInfoCliente.Name = "LabelInfoCliente"
        Me.LabelInfoCliente.Size = New System.Drawing.Size(400, 402)
        Me.LabelInfoCliente.TabIndex = 0
        Me.LabelInfoCliente.Text = "Label1"
        '
        'CheckBoxDettaglioCliente
        '
        Me.CheckBoxDettaglioCliente.AutoSize = True
        Me.tlpAvvisi.SetColumnSpan(Me.CheckBoxDettaglioCliente, 2)
        Me.CheckBoxDettaglioCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxDettaglioCliente.Location = New System.Drawing.Point(795, 3)
        Me.CheckBoxDettaglioCliente.Name = "CheckBoxDettaglioCliente"
        Me.CheckBoxDettaglioCliente.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.CheckBoxDettaglioCliente.Size = New System.Drawing.Size(188, 24)
        Me.CheckBoxDettaglioCliente.TabIndex = 14
        Me.CheckBoxDettaglioCliente.Text = "Dettaglio cliente"
        Me.CheckBoxDettaglioCliente.UseVisualStyleBackColor = True
        '
        'LabelNumeroCoass
        '
        Me.LabelNumeroCoass.AutoSize = True
        Me.LabelNumeroCoass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNumeroCoass.Location = New System.Drawing.Point(883, 55)
        Me.LabelNumeroCoass.Name = "LabelNumeroCoass"
        Me.LabelNumeroCoass.Size = New System.Drawing.Size(100, 25)
        Me.LabelNumeroCoass.TabIndex = 15
        Me.LabelNumeroCoass.Text = "Label1"
        Me.LabelNumeroCoass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelInfoCoass2
        '
        Me.LabelInfoCoass2.AutoSize = True
        Me.tlpAvvisi.SetColumnSpan(Me.LabelInfoCoass2, 3)
        Me.LabelInfoCoass2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfoCoass2.Location = New System.Drawing.Point(443, 488)
        Me.LabelInfoCoass2.Name = "LabelInfoCoass2"
        Me.LabelInfoCoass2.Size = New System.Drawing.Size(540, 40)
        Me.LabelInfoCoass2.TabIndex = 16
        Me.LabelInfoCoass2.Text = "Label1"
        '
        'ButtonAggiungi
        '
        Me.ButtonAggiungi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiungi.Location = New System.Drawing.Point(355, 33)
        Me.ButtonAggiungi.Name = "ButtonAggiungi"
        Me.ButtonAggiungi.Size = New System.Drawing.Size(82, 19)
        Me.ButtonAggiungi.TabIndex = 17
        Me.ButtonAggiungi.Text = "Aggiungi"
        Me.ButtonAggiungi.UseVisualStyleBackColor = True
        '
        'ButtonElimina
        '
        Me.ButtonElimina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonElimina.Location = New System.Drawing.Point(355, 58)
        Me.ButtonElimina.Name = "ButtonElimina"
        Me.ButtonElimina.Size = New System.Drawing.Size(82, 19)
        Me.ButtonElimina.TabIndex = 18
        Me.ButtonElimina.Text = "Elimina"
        Me.ButtonElimina.UseVisualStyleBackColor = True
        '
        'TabPageTracking
        '
        Me.TabPageTracking.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPageTracking.Location = New System.Drawing.Point(4, 57)
        Me.TabPageTracking.Name = "TabPageTracking"
        Me.TabPageTracking.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageTracking.Size = New System.Drawing.Size(986, 528)
        Me.TabPageTracking.TabIndex = 1
        Me.TabPageTracking.Text = "Traccia le comunicazioni"
        Me.TabPageTracking.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBoxAgenziaTrack, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelTrack, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.wbTrack, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(980, 522)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'ComboBoxAgenziaTrack
        '
        Me.ComboBoxAgenziaTrack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxAgenziaTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxAgenziaTrack.FormattingEnabled = True
        Me.ComboBoxAgenziaTrack.Location = New System.Drawing.Point(784, 0)
        Me.ComboBoxAgenziaTrack.Margin = New System.Windows.Forms.Padding(0)
        Me.ComboBoxAgenziaTrack.Name = "ComboBoxAgenziaTrack"
        Me.ComboBoxAgenziaTrack.Size = New System.Drawing.Size(196, 21)
        Me.ComboBoxAgenziaTrack.TabIndex = 1
        '
        'LabelTrack
        '
        Me.LabelTrack.AutoSize = True
        Me.LabelTrack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTrack.Location = New System.Drawing.Point(0, 0)
        Me.LabelTrack.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelTrack.Name = "LabelTrack"
        Me.LabelTrack.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.LabelTrack.Size = New System.Drawing.Size(784, 25)
        Me.LabelTrack.TabIndex = 2
        Me.LabelTrack.Text = "Traccia i messaggi del codice"
        Me.LabelTrack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPageAttivazione
        '
        Me.TabPageAttivazione.Controls.Add(Me.wbAttivazione)
        Me.TabPageAttivazione.Location = New System.Drawing.Point(4, 57)
        Me.TabPageAttivazione.Name = "TabPageAttivazione"
        Me.TabPageAttivazione.Size = New System.Drawing.Size(986, 528)
        Me.TabPageAttivazione.TabIndex = 4
        Me.TabPageAttivazione.Text = "Attivazione servizio"
        Me.TabPageAttivazione.UseVisualStyleBackColor = True
        '
        'wbAttivazione
        '
        Me.wbAttivazione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbAttivazione.Location = New System.Drawing.Point(0, 0)
        Me.wbAttivazione.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbAttivazione.Name = "wbAttivazione"
        Me.wbAttivazione.Size = New System.Drawing.Size(986, 528)
        Me.wbAttivazione.TabIndex = 0
        '
        'TabPageGuida
        '
        Me.TabPageGuida.Controls.Add(Me.wbGuida)
        Me.TabPageGuida.Location = New System.Drawing.Point(4, 57)
        Me.TabPageGuida.Name = "TabPageGuida"
        Me.TabPageGuida.Size = New System.Drawing.Size(986, 528)
        Me.TabPageGuida.TabIndex = 5
        Me.TabPageGuida.Text = "Guida"
        Me.TabPageGuida.UseVisualStyleBackColor = True
        '
        'wbGuida
        '
        Me.wbGuida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbGuida.Location = New System.Drawing.Point(0, 0)
        Me.wbGuida.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbGuida.Name = "wbGuida"
        Me.wbGuida.Size = New System.Drawing.Size(986, 528)
        Me.wbGuida.TabIndex = 0
        '
        'TabPageReport
        '
        Me.TabPageReport.Controls.Add(Me.dgvReport)
        Me.TabPageReport.Location = New System.Drawing.Point(4, 57)
        Me.TabPageReport.Name = "TabPageReport"
        Me.TabPageReport.Size = New System.Drawing.Size(986, 528)
        Me.TabPageReport.TabIndex = 6
        Me.TabPageReport.Text = "Report invio dati"
        Me.TabPageReport.UseVisualStyleBackColor = True
        '
        'dgvReport
        '
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReport.Location = New System.Drawing.Point(0, 0)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.Size = New System.Drawing.Size(986, 528)
        Me.dgvReport.TabIndex = 0
        '
        'wbConfig
        '
        Me.tlpConfig.SetColumnSpan(Me.wbConfig, 4)
        Me.wbConfig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbConfig.Location = New System.Drawing.Point(3, 28)
        Me.wbConfig.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbConfig.Name = "wbConfig"
        Me.wbConfig.Size = New System.Drawing.Size(974, 491)
        Me.wbConfig.TabIndex = 4
        '
        'wbTrack
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.wbTrack, 2)
        Me.wbTrack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbTrack.Location = New System.Drawing.Point(3, 28)
        Me.wbTrack.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbTrack.Name = "wbTrack"
        Me.wbTrack.Size = New System.Drawing.Size(974, 491)
        Me.wbTrack.TabIndex = 3
        '
        'FormPostalizzazione
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 589)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "FormPostalizzazione"
        Me.Text = "FormPostalizzazione"
        Me.TabMain.ResumeLayout(False)
        Me.TabPageConfig.ResumeLayout(False)
        Me.tlpConfig.ResumeLayout(False)
        Me.tlpConfig.PerformLayout()
        Me.TabPageConfigUT.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabPageAvvisi.ResumeLayout(False)
        Me.tlpAvvisi.ResumeLayout(False)
        Me.tlpAvvisi.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvAvvisi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageTracking.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TabPageAttivazione.ResumeLayout(False)
        Me.TabPageGuida.ResumeLayout(False)
        Me.TabPageReport.ResumeLayout(False)
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As Utx.UtTabControl
    Friend WithEvents TabPageConfig As System.Windows.Forms.TabPage
    Friend WithEvents TabPageTracking As System.Windows.Forms.TabPage
    Friend WithEvents TabPageAvvisi As System.Windows.Forms.TabPage
    Friend WithEvents tlpAvvisi As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvAvvisi As System.Windows.Forms.DataGridView
    Friend WithEvents TabPageConfigUT As System.Windows.Forms.TabPage
    Friend WithEvents ComboBoxAgenzia As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonVisualizza As System.Windows.Forms.Button
    Friend WithEvents ButtonInvia As System.Windows.Forms.Button
    Friend WithEvents LabelMese As System.Windows.Forms.Label
    Friend WithEvents LabelNumeroAvvisi As System.Windows.Forms.Label
    Friend WithEvents CheckBoxAggiornaDati As System.Windows.Forms.CheckBox
    Friend WithEvents LabelAgenzia As System.Windows.Forms.Label
    Friend WithEvents TabPageAttivazione As System.Windows.Forms.TabPage
    Friend WithEvents wbAttivazione As System.Windows.Forms.WebBrowser
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelAgenziaConfig As System.Windows.Forms.Label
    Friend WithEvents ComboBoxAgenziaConfig As System.Windows.Forms.ComboBox
    Friend WithEvents LabelCodiciAbilitati As System.Windows.Forms.Label
    Friend WithEvents CheckedListBoxAgenzieAbilitate As System.Windows.Forms.CheckedListBox
    Friend WithEvents ButtonSalvaConfigUT As System.Windows.Forms.Button
    Friend WithEvents tlpConfig As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelMessaggioConfig As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ComboBoxAgenziaTrack As System.Windows.Forms.ComboBox
    Friend WithEvents LabelTrack As System.Windows.Forms.Label
    Friend WithEvents LabelConfigUT As System.Windows.Forms.Label
    Friend WithEvents ButtonAggiornaCip As System.Windows.Forms.Button
    Friend WithEvents TabPageGuida As System.Windows.Forms.TabPage
    Friend WithEvents wbGuida As System.Windows.Forms.WebBrowser
    Friend WithEvents TextBoxMailNotifica As System.Windows.Forms.TextBox
    Friend WithEvents LabelNotifica As System.Windows.Forms.Label
    Friend WithEvents TabPageReport As System.Windows.Forms.TabPage
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonEsporta As System.Windows.Forms.Button
    Friend WithEvents ButtonDeseleziona As System.Windows.Forms.Button
    Friend WithEvents ButtonSeleziona As System.Windows.Forms.Button
    Friend WithEvents LabelUtentiAbilitati As System.Windows.Forms.Label
    Friend WithEvents TextBoxUtentiAbilitati As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxRID As System.Windows.Forms.CheckBox
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents LabelInfoCliente As System.Windows.Forms.Label
    Friend WithEvents CheckBoxDettaglioCliente As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxDomicilio As System.Windows.Forms.CheckBox
    Friend WithEvents LabelInfoCoass As System.Windows.Forms.Label
    Friend WithEvents LabelNumeroCoass As System.Windows.Forms.Label
    Friend WithEvents LabelInfoCoass2 As System.Windows.Forms.Label
    Friend WithEvents ButtonAggiungi As Button
    Friend WithEvents ButtonElimina As Button
    Friend WithEvents wbConfig As WebBrowser
    Friend WithEvents wbTrack As WebBrowser
End Class
