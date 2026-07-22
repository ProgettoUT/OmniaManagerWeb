<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAvvioCentralino
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
        Me.TabPageMonitor = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelMessaggio = New System.Windows.Forms.Label()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.LabelUtente = New System.Windows.Forms.Label()
        Me.LabelInterno = New System.Windows.Forms.Label()
        Me.ComboBoxInterni = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxTelefono = New System.Windows.Forms.TextBox()
        Me.ButtonChiama = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabPageInterni = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvInterni = New System.Windows.Forms.DataGridView()
        Me.ButtonElimina = New System.Windows.Forms.Button()
        Me.ButtonAggiungi = New System.Windows.Forms.Button()
        Me.ButtonModifica = New System.Windows.Forms.Button()
        Me.ButtonCaricaCsv = New System.Windows.Forms.Button()
        Me.TabPageConfig = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxStart = New System.Windows.Forms.CheckBox()
        Me.ButtonCartella = New System.Windows.Forms.Button()
        Me.TextBoxCartella = New System.Windows.Forms.TextBox()
        Me.LabelCartella = New System.Windows.Forms.Label()
        Me.LabelEstensione = New System.Windows.Forms.Label()
        Me.TextBoxEstensione = New System.Windows.Forms.TextBox()
        Me.TextBoxSecondi = New System.Windows.Forms.TextBox()
        Me.LabelSecondi = New System.Windows.Forms.Label()
        Me.LabelComando = New System.Windows.Forms.Label()
        Me.ButtonCartellaComandi = New System.Windows.Forms.Button()
        Me.ComboBoxComandi = New System.Windows.Forms.ComboBox()
        Me.TabMain.SuspendLayout()
        Me.TabPageMonitor.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabPageInterni.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.dgvInterni, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageConfig.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
        Me.TabMain.Controls.Add(Me.TabPageMonitor)
        Me.TabMain.Controls.Add(Me.TabPageInterni)
        Me.TabMain.Controls.Add(Me.TabPageConfig)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Drawing.Point(0, 0)
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(648, 377)
        Me.TabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabMain.TabIndex = 1
        Me.TabMain.Visible = False
        '
        'TabPageMonitor
        '
        Me.TabPageMonitor.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPageMonitor.Location = New System.Drawing.Point(4, 29)
        Me.TabPageMonitor.Name = "TabPageMonitor"
        Me.TabPageMonitor.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageMonitor.Size = New System.Drawing.Size(640, 344)
        Me.TabPageMonitor.TabIndex = 0
        Me.TabPageMonitor.Text = "Monitor"
        Me.TabPageMonitor.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelMessaggio, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonOk, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 3, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelUtente, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelInterno, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxInterni, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxTelefono, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonChiama, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(634, 338)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'LabelMessaggio
        '
        Me.LabelMessaggio.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelMessaggio, 4)
        Me.LabelMessaggio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMessaggio.Location = New System.Drawing.Point(3, 111)
        Me.LabelMessaggio.Name = "LabelMessaggio"
        Me.LabelMessaggio.Size = New System.Drawing.Size(628, 187)
        Me.LabelMessaggio.TabIndex = 2
        Me.LabelMessaggio.Text = "Label2"
        Me.LabelMessaggio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonOk
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonOk, 3)
        Me.ButtonOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOk.Location = New System.Drawing.Point(3, 301)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(468, 34)
        Me.ButtonOk.TabIndex = 2
        Me.ButtonOk.Text = "Button1"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.Location = New System.Drawing.Point(477, 301)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(154, 34)
        Me.ButtonEsci.TabIndex = 3
        Me.ButtonEsci.Text = "chiudi"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'LabelUtente
        '
        Me.LabelUtente.AutoSize = True
        Me.LabelUtente.BackColor = System.Drawing.Color.Gainsboro
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelUtente, 2)
        Me.LabelUtente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelUtente.Location = New System.Drawing.Point(0, 2)
        Me.LabelUtente.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.LabelUtente.Name = "LabelUtente"
        Me.LabelUtente.Size = New System.Drawing.Size(316, 21)
        Me.LabelUtente.TabIndex = 4
        Me.LabelUtente.Text = "Label1"
        Me.LabelUtente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelInterno
        '
        Me.LabelInterno.AutoSize = True
        Me.LabelInterno.BackColor = System.Drawing.Color.Gainsboro
        Me.LabelInterno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInterno.Location = New System.Drawing.Point(316, 2)
        Me.LabelInterno.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.LabelInterno.Name = "LabelInterno"
        Me.LabelInterno.Size = New System.Drawing.Size(158, 21)
        Me.LabelInterno.TabIndex = 5
        Me.LabelInterno.Text = "all'interno"
        Me.LabelInterno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxInterni
        '
        Me.ComboBoxInterni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxInterni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxInterni.FormattingEnabled = True
        Me.ComboBoxInterni.Location = New System.Drawing.Point(477, 3)
        Me.ComboBoxInterni.Name = "ComboBoxInterni"
        Me.ComboBoxInterni.Size = New System.Drawing.Size(154, 21)
        Me.ComboBoxInterni.TabIndex = 6
        Me.ComboBoxInterni.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 40)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Numero da chiamare"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxTelefono
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxTelefono, 2)
        Me.TextBoxTelefono.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxTelefono.Location = New System.Drawing.Point(161, 51)
        Me.TextBoxTelefono.Multiline = True
        Me.TextBoxTelefono.Name = "TextBoxTelefono"
        Me.TextBoxTelefono.Size = New System.Drawing.Size(310, 34)
        Me.TextBoxTelefono.TabIndex = 0
        Me.TextBoxTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonChiama
        '
        Me.ButtonChiama.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonChiama.Location = New System.Drawing.Point(477, 51)
        Me.ButtonChiama.Name = "ButtonChiama"
        Me.ButtonChiama.Size = New System.Drawing.Size(154, 34)
        Me.ButtonChiama.TabIndex = 1
        Me.ButtonChiama.Text = "Button1"
        Me.ButtonChiama.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DodgerBlue
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 45)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(634, 3)
        Me.Panel1.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DodgerBlue
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 88)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(634, 3)
        Me.Panel2.TabIndex = 12
        '
        'TabPageInterni
        '
        Me.TabPageInterni.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPageInterni.Location = New System.Drawing.Point(4, 29)
        Me.TabPageInterni.Name = "TabPageInterni"
        Me.TabPageInterni.Size = New System.Drawing.Size(640, 344)
        Me.TabPageInterni.TabIndex = 2
        Me.TabPageInterni.Text = "Interni"
        Me.TabPageInterni.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.dgvInterni, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonElimina, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonAggiungi, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonModifica, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonCaricaCsv, 3, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(640, 344)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'dgvInterni
        '
        Me.dgvInterni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel3.SetColumnSpan(Me.dgvInterni, 4)
        Me.dgvInterni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInterni.Location = New System.Drawing.Point(3, 3)
        Me.dgvInterni.Name = "dgvInterni"
        Me.dgvInterni.Size = New System.Drawing.Size(634, 298)
        Me.dgvInterni.TabIndex = 0
        '
        'ButtonElimina
        '
        Me.ButtonElimina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonElimina.Location = New System.Drawing.Point(3, 307)
        Me.ButtonElimina.Name = "ButtonElimina"
        Me.ButtonElimina.Size = New System.Drawing.Size(154, 34)
        Me.ButtonElimina.TabIndex = 0
        Me.ButtonElimina.Text = "Elimina"
        Me.ButtonElimina.UseVisualStyleBackColor = True
        '
        'ButtonAggiungi
        '
        Me.ButtonAggiungi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiungi.Location = New System.Drawing.Point(163, 307)
        Me.ButtonAggiungi.Name = "ButtonAggiungi"
        Me.ButtonAggiungi.Size = New System.Drawing.Size(154, 34)
        Me.ButtonAggiungi.TabIndex = 1
        Me.ButtonAggiungi.Text = "Aggiungi"
        Me.ButtonAggiungi.UseVisualStyleBackColor = True
        '
        'ButtonModifica
        '
        Me.ButtonModifica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonModifica.Location = New System.Drawing.Point(323, 307)
        Me.ButtonModifica.Name = "ButtonModifica"
        Me.ButtonModifica.Size = New System.Drawing.Size(154, 34)
        Me.ButtonModifica.TabIndex = 2
        Me.ButtonModifica.Text = "Button1"
        Me.ButtonModifica.UseVisualStyleBackColor = True
        '
        'ButtonCaricaCsv
        '
        Me.ButtonCaricaCsv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCaricaCsv.Location = New System.Drawing.Point(483, 307)
        Me.ButtonCaricaCsv.Name = "ButtonCaricaCsv"
        Me.ButtonCaricaCsv.Size = New System.Drawing.Size(154, 34)
        Me.ButtonCaricaCsv.TabIndex = 3
        Me.ButtonCaricaCsv.Text = "Button2"
        Me.ButtonCaricaCsv.UseVisualStyleBackColor = True
        '
        'TabPageConfig
        '
        Me.TabPageConfig.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPageConfig.Location = New System.Drawing.Point(4, 29)
        Me.TabPageConfig.Name = "TabPageConfig"
        Me.TabPageConfig.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageConfig.Size = New System.Drawing.Size(640, 344)
        Me.TabPageConfig.TabIndex = 1
        Me.TabPageConfig.Text = "Configura"
        Me.TabPageConfig.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxStart, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonCartella, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxCartella, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelCartella, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelEstensione, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxEstensione, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxSecondi, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelSecondi, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelComando, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonCartellaComandi, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBoxComandi, 0, 6)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 8
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(634, 338)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'CheckBoxStart
        '
        Me.CheckBoxStart.AutoSize = True
        Me.CheckBoxStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TableLayoutPanel2.SetColumnSpan(Me.CheckBoxStart, 2)
        Me.CheckBoxStart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxStart.Location = New System.Drawing.Point(3, 3)
        Me.CheckBoxStart.Name = "CheckBoxStart"
        Me.CheckBoxStart.Size = New System.Drawing.Size(628, 29)
        Me.CheckBoxStart.TabIndex = 0
        Me.CheckBoxStart.Text = "CheckBox1"
        Me.CheckBoxStart.UseVisualStyleBackColor = True
        '
        'ButtonCartella
        '
        Me.ButtonCartella.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCartella.Location = New System.Drawing.Point(510, 108)
        Me.ButtonCartella.Name = "ButtonCartella"
        Me.ButtonCartella.Size = New System.Drawing.Size(121, 22)
        Me.ButtonCartella.TabIndex = 2
        Me.ButtonCartella.Text = "Button1"
        Me.ButtonCartella.UseVisualStyleBackColor = True
        '
        'TextBoxCartella
        '
        Me.TextBoxCartella.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCartella.Location = New System.Drawing.Point(3, 108)
        Me.TextBoxCartella.Name = "TextBoxCartella"
        Me.TextBoxCartella.Size = New System.Drawing.Size(501, 20)
        Me.TextBoxCartella.TabIndex = 1
        '
        'LabelCartella
        '
        Me.LabelCartella.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.LabelCartella, 2)
        Me.LabelCartella.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCartella.Location = New System.Drawing.Point(3, 70)
        Me.LabelCartella.Name = "LabelCartella"
        Me.LabelCartella.Size = New System.Drawing.Size(628, 35)
        Me.LabelCartella.TabIndex = 2
        Me.LabelCartella.Text = "Label1"
        Me.LabelCartella.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LabelEstensione
        '
        Me.LabelEstensione.AutoSize = True
        Me.LabelEstensione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelEstensione.Location = New System.Drawing.Point(3, 133)
        Me.LabelEstensione.Name = "LabelEstensione"
        Me.LabelEstensione.Size = New System.Drawing.Size(501, 35)
        Me.LabelEstensione.TabIndex = 4
        Me.LabelEstensione.Text = "Label2"
        Me.LabelEstensione.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TextBoxEstensione
        '
        Me.TextBoxEstensione.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextBoxEstensione.Location = New System.Drawing.Point(510, 145)
        Me.TextBoxEstensione.Name = "TextBoxEstensione"
        Me.TextBoxEstensione.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxEstensione.TabIndex = 3
        '
        'TextBoxSecondi
        '
        Me.TextBoxSecondi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxSecondi.Location = New System.Drawing.Point(510, 38)
        Me.TextBoxSecondi.Name = "TextBoxSecondi"
        Me.TextBoxSecondi.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxSecondi.TabIndex = 0
        '
        'LabelSecondi
        '
        Me.LabelSecondi.AutoSize = True
        Me.LabelSecondi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSecondi.Location = New System.Drawing.Point(3, 35)
        Me.LabelSecondi.Name = "LabelSecondi"
        Me.LabelSecondi.Size = New System.Drawing.Size(501, 35)
        Me.LabelSecondi.TabIndex = 7
        Me.LabelSecondi.Text = "Label3"
        Me.LabelSecondi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelComando
        '
        Me.LabelComando.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.LabelComando, 2)
        Me.LabelComando.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelComando.Location = New System.Drawing.Point(3, 168)
        Me.LabelComando.Name = "LabelComando"
        Me.LabelComando.Size = New System.Drawing.Size(628, 35)
        Me.LabelComando.TabIndex = 8
        Me.LabelComando.Text = "Label1"
        Me.LabelComando.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ButtonCartellaComandi
        '
        Me.ButtonCartellaComandi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCartellaComandi.Location = New System.Drawing.Point(510, 206)
        Me.ButtonCartellaComandi.Name = "ButtonCartellaComandi"
        Me.ButtonCartellaComandi.Size = New System.Drawing.Size(121, 22)
        Me.ButtonCartellaComandi.TabIndex = 5
        Me.ButtonCartellaComandi.Text = "Button1"
        Me.ButtonCartellaComandi.UseVisualStyleBackColor = True
        '
        'ComboBoxComandi
        '
        Me.ComboBoxComandi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxComandi.FormattingEnabled = True
        Me.ComboBoxComandi.Location = New System.Drawing.Point(3, 206)
        Me.ComboBoxComandi.Name = "ComboBoxComandi"
        Me.ComboBoxComandi.Size = New System.Drawing.Size(501, 21)
        Me.ComboBoxComandi.TabIndex = 4
        '
        'FormAvvioCentralino
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 377)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "FormAvvioCentralino"
        Me.Text = "FormAvvio"
        Me.TabMain.ResumeLayout(False)
        Me.TabPageMonitor.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabPageInterni.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.dgvInterni, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageConfig.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents LabelMessaggio As System.Windows.Forms.Label
    Friend WithEvents TabMain As Utx.UtTabControl
    Friend WithEvents TabPageMonitor As System.Windows.Forms.TabPage
    Friend WithEvents TabPageConfig As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxStart As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonCartella As System.Windows.Forms.Button
    Friend WithEvents TextBoxCartella As System.Windows.Forms.TextBox
    Friend WithEvents LabelCartella As System.Windows.Forms.Label
    Friend WithEvents LabelEstensione As System.Windows.Forms.Label
    Friend WithEvents TextBoxEstensione As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSecondi As System.Windows.Forms.TextBox
    Friend WithEvents LabelSecondi As System.Windows.Forms.Label
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents LabelComando As System.Windows.Forms.Label
    Friend WithEvents ButtonCartellaComandi As System.Windows.Forms.Button
    Friend WithEvents ComboBoxComandi As System.Windows.Forms.ComboBox
    Friend WithEvents LabelUtente As System.Windows.Forms.Label
    Friend WithEvents LabelInterno As System.Windows.Forms.Label
    Friend WithEvents ComboBoxInterni As System.Windows.Forms.ComboBox
    Friend WithEvents TabPageInterni As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvInterni As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonElimina As System.Windows.Forms.Button
    Friend WithEvents ButtonAggiungi As System.Windows.Forms.Button
    Friend WithEvents ButtonModifica As System.Windows.Forms.Button
    Friend WithEvents ButtonCaricaCsv As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTelefono As System.Windows.Forms.TextBox
    Friend WithEvents ButtonChiama As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
