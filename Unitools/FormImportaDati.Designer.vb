<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImportaDati
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
        Me.TabMain = New Utx.UtTabControl()
        Me.TabPageImporta = New System.Windows.Forms.TabPage()
        Me.tlpImporta = New System.Windows.Forms.TableLayoutPanel()
        Me.ListViewCalendario = New System.Windows.Forms.ListView()
        Me.LabelInfoDL = New System.Windows.Forms.Label()
        Me.LabelMessaggio = New System.Windows.Forms.Label()
        Me.LabelInfoOmnia = New System.Windows.Forms.Label()
        Me.TabPageOMNIA = New System.Windows.Forms.TabPage()
        Me.tlpOmnia = New System.Windows.Forms.TableLayoutPanel()
        Me.ComboBoxAgenziaCumulo = New System.Windows.Forms.ComboBox()
        Me.ButtonImportaCumulo = New System.Windows.Forms.Button()
        Me.ButtonCumulo = New System.Windows.Forms.Button()
        Me.LabelForzaturaOmnia = New System.Windows.Forms.Label()
        Me.dtpForzaturaOmniaDal = New System.Windows.Forms.DateTimePicker()
        Me.ButtonForzaturaOmnia = New System.Windows.Forms.Button()
        Me.LabelForzaturaDbUno = New System.Windows.Forms.Label()
        Me.ComboBoxArchivioOmnia = New System.Windows.Forms.ComboBox()
        Me.ButtonForzaturaDbuno = New System.Windows.Forms.Button()
        Me.dtpDataDaDbuno = New System.Windows.Forms.DateTimePicker()
        Me.dtpForzaturaOmniaAl = New System.Windows.Forms.DateTimePicker()
        Me.ComboBoxTipoRecord = New System.Windows.Forms.ComboBox()
        Me.ComboBoxAgenzia = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelCumulo = New System.Windows.Forms.Label()
        Me.ComboBoxTipoCumulo = New System.Windows.Forms.ComboBox()
        Me.LabelImportaCumulo = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabPageDL = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelForzaturaDL = New System.Windows.Forms.Label()
        Me.dtpForzaturaDL = New System.Windows.Forms.DateTimePicker()
        Me.LabelDataForzaturaDL = New System.Windows.Forms.Label()
        Me.ComboBoxArchivioDL = New System.Windows.Forms.ComboBox()
        Me.ButtonForzaturaDL = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.ButtonAggiornaCalendario = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.TabPageImporta.SuspendLayout()
        Me.tlpImporta.SuspendLayout()
        Me.TabPageOMNIA.SuspendLayout()
        Me.tlpOmnia.SuspendLayout()
        Me.TabPageDL.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TabMain, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAggiornaCalendario, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(600, 362)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TabMain
        '
        Me.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
        Me.TableLayoutPanel1.SetColumnSpan(Me.TabMain, 2)
        Me.TabMain.Controls.Add(Me.TabPageImporta)
        Me.TabMain.Controls.Add(Me.TabPageOMNIA)
        Me.TabMain.Controls.Add(Me.TabPageDL)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(600, 332)
        Me.TabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabMain.TabIndex = 1
        Me.TabMain.Visible = False
        '
        'TabPageImporta
        '
        Me.TabPageImporta.Controls.Add(Me.tlpImporta)
        Me.TabPageImporta.Location = New System.Drawing.Point(4, 29)
        Me.TabPageImporta.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPageImporta.Name = "TabPageImporta"
        Me.TabPageImporta.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageImporta.Size = New System.Drawing.Size(592, 299)
        Me.TabPageImporta.TabIndex = 0
        Me.TabPageImporta.Text = "Importa archivi"
        Me.TabPageImporta.UseVisualStyleBackColor = True
        '
        'tlpImporta
        '
        Me.tlpImporta.ColumnCount = 2
        Me.tlpImporta.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.8556!))
        Me.tlpImporta.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.1444!))
        Me.tlpImporta.Controls.Add(Me.ListViewCalendario, 0, 3)
        Me.tlpImporta.Controls.Add(Me.LabelInfoDL, 0, 1)
        Me.tlpImporta.Controls.Add(Me.LabelMessaggio, 0, 2)
        Me.tlpImporta.Controls.Add(Me.LabelInfoOmnia, 0, 0)
        Me.tlpImporta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpImporta.Location = New System.Drawing.Point(3, 3)
        Me.tlpImporta.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpImporta.Name = "tlpImporta"
        Me.tlpImporta.RowCount = 4
        Me.tlpImporta.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpImporta.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpImporta.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpImporta.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpImporta.Size = New System.Drawing.Size(586, 293)
        Me.tlpImporta.TabIndex = 0
        '
        'ListViewCalendario
        '
        Me.tlpImporta.SetColumnSpan(Me.ListViewCalendario, 2)
        Me.ListViewCalendario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewCalendario.HideSelection = False
        Me.ListViewCalendario.Location = New System.Drawing.Point(0, 75)
        Me.ListViewCalendario.Margin = New System.Windows.Forms.Padding(0)
        Me.ListViewCalendario.Name = "ListViewCalendario"
        Me.ListViewCalendario.Size = New System.Drawing.Size(586, 218)
        Me.ListViewCalendario.TabIndex = 1
        Me.ListViewCalendario.UseCompatibleStateImageBehavior = False
        '
        'LabelInfoDL
        '
        Me.LabelInfoDL.AutoSize = True
        Me.tlpImporta.SetColumnSpan(Me.LabelInfoDL, 2)
        Me.LabelInfoDL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfoDL.Location = New System.Drawing.Point(3, 25)
        Me.LabelInfoDL.Name = "LabelInfoDL"
        Me.LabelInfoDL.Size = New System.Drawing.Size(580, 25)
        Me.LabelInfoDL.TabIndex = 2
        Me.LabelInfoDL.Text = "Label1"
        Me.LabelInfoDL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelMessaggio
        '
        Me.LabelMessaggio.AutoSize = True
        Me.tlpImporta.SetColumnSpan(Me.LabelMessaggio, 2)
        Me.LabelMessaggio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMessaggio.Location = New System.Drawing.Point(0, 51)
        Me.LabelMessaggio.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.LabelMessaggio.Name = "LabelMessaggio"
        Me.LabelMessaggio.Size = New System.Drawing.Size(586, 23)
        Me.LabelMessaggio.TabIndex = 4
        Me.LabelMessaggio.Text = "Label1"
        Me.LabelMessaggio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelInfoOmnia
        '
        Me.LabelInfoOmnia.AutoSize = True
        Me.tlpImporta.SetColumnSpan(Me.LabelInfoOmnia, 2)
        Me.LabelInfoOmnia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfoOmnia.Location = New System.Drawing.Point(3, 0)
        Me.LabelInfoOmnia.Name = "LabelInfoOmnia"
        Me.LabelInfoOmnia.Size = New System.Drawing.Size(580, 25)
        Me.LabelInfoOmnia.TabIndex = 5
        Me.LabelInfoOmnia.Text = "Label1"
        Me.LabelInfoOmnia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPageOMNIA
        '
        Me.TabPageOMNIA.Controls.Add(Me.tlpOmnia)
        Me.TabPageOMNIA.Location = New System.Drawing.Point(4, 29)
        Me.TabPageOMNIA.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPageOMNIA.Name = "TabPageOMNIA"
        Me.TabPageOMNIA.Size = New System.Drawing.Size(592, 299)
        Me.TabPageOMNIA.TabIndex = 1
        Me.TabPageOMNIA.Text = "Forzature flusso giornaliero"
        Me.TabPageOMNIA.UseVisualStyleBackColor = True
        '
        'tlpOmnia
        '
        Me.tlpOmnia.ColumnCount = 4
        Me.tlpOmnia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlpOmnia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpOmnia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpOmnia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpOmnia.Controls.Add(Me.ComboBoxAgenziaCumulo, 1, 7)
        Me.tlpOmnia.Controls.Add(Me.ButtonImportaCumulo, 3, 8)
        Me.tlpOmnia.Controls.Add(Me.ButtonCumulo, 3, 7)
        Me.tlpOmnia.Controls.Add(Me.LabelForzaturaOmnia, 0, 0)
        Me.tlpOmnia.Controls.Add(Me.dtpForzaturaOmniaDal, 2, 0)
        Me.tlpOmnia.Controls.Add(Me.ButtonForzaturaOmnia, 3, 3)
        Me.tlpOmnia.Controls.Add(Me.LabelForzaturaDbUno, 0, 5)
        Me.tlpOmnia.Controls.Add(Me.ComboBoxArchivioOmnia, 2, 5)
        Me.tlpOmnia.Controls.Add(Me.ButtonForzaturaDbuno, 3, 5)
        Me.tlpOmnia.Controls.Add(Me.dtpDataDaDbuno, 1, 5)
        Me.tlpOmnia.Controls.Add(Me.dtpForzaturaOmniaAl, 2, 1)
        Me.tlpOmnia.Controls.Add(Me.ComboBoxTipoRecord, 2, 2)
        Me.tlpOmnia.Controls.Add(Me.ComboBoxAgenzia, 2, 3)
        Me.tlpOmnia.Controls.Add(Me.Label1, 1, 0)
        Me.tlpOmnia.Controls.Add(Me.Label2, 1, 1)
        Me.tlpOmnia.Controls.Add(Me.Label3, 1, 2)
        Me.tlpOmnia.Controls.Add(Me.Label4, 1, 3)
        Me.tlpOmnia.Controls.Add(Me.LabelCumulo, 0, 7)
        Me.tlpOmnia.Controls.Add(Me.ComboBoxTipoCumulo, 2, 7)
        Me.tlpOmnia.Controls.Add(Me.LabelImportaCumulo, 0, 8)
        Me.tlpOmnia.Controls.Add(Me.Label6, 1, 8)
        Me.tlpOmnia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpOmnia.Location = New System.Drawing.Point(0, 0)
        Me.tlpOmnia.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpOmnia.Name = "tlpOmnia"
        Me.tlpOmnia.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.tlpOmnia.RowCount = 10
        Me.tlpOmnia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpOmnia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpOmnia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpOmnia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpOmnia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpOmnia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpOmnia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpOmnia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpOmnia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpOmnia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpOmnia.Size = New System.Drawing.Size(592, 299)
        Me.tlpOmnia.TabIndex = 0
        '
        'ComboBoxAgenziaCumulo
        '
        Me.ComboBoxAgenziaCumulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxAgenziaCumulo.FormattingEnabled = True
        Me.ComboBoxAgenziaCumulo.Location = New System.Drawing.Point(239, 184)
        Me.ComboBoxAgenziaCumulo.Name = "ComboBoxAgenziaCumulo"
        Me.ComboBoxAgenziaCumulo.Size = New System.Drawing.Size(112, 21)
        Me.ComboBoxAgenziaCumulo.TabIndex = 21
        '
        'ButtonImportaCumulo
        '
        Me.ButtonImportaCumulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonImportaCumulo.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonImportaCumulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonImportaCumulo.Location = New System.Drawing.Point(472, 209)
        Me.ButtonImportaCumulo.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.ButtonImportaCumulo.Name = "ButtonImportaCumulo"
        Me.ButtonImportaCumulo.Size = New System.Drawing.Size(120, 22)
        Me.ButtonImportaCumulo.TabIndex = 19
        Me.ButtonImportaCumulo.Text = "Importa"
        Me.ButtonImportaCumulo.UseVisualStyleBackColor = True
        '
        'ButtonCumulo
        '
        Me.ButtonCumulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCumulo.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonCumulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCumulo.Location = New System.Drawing.Point(472, 183)
        Me.ButtonCumulo.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.ButtonCumulo.Name = "ButtonCumulo"
        Me.ButtonCumulo.Size = New System.Drawing.Size(120, 22)
        Me.ButtonCumulo.TabIndex = 15
        Me.ButtonCumulo.Text = "Avvia"
        Me.ButtonCumulo.UseVisualStyleBackColor = True
        '
        'LabelForzaturaOmnia
        '
        Me.LabelForzaturaOmnia.AutoSize = True
        Me.LabelForzaturaOmnia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelForzaturaOmnia.Location = New System.Drawing.Point(3, 5)
        Me.LabelForzaturaOmnia.Name = "LabelForzaturaOmnia"
        Me.LabelForzaturaOmnia.Size = New System.Drawing.Size(230, 26)
        Me.LabelForzaturaOmnia.TabIndex = 0
        Me.LabelForzaturaOmnia.Text = "Label1"
        Me.LabelForzaturaOmnia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpForzaturaOmniaDal
        '
        Me.dtpForzaturaOmniaDal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpForzaturaOmniaDal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpForzaturaOmniaDal.Location = New System.Drawing.Point(357, 8)
        Me.dtpForzaturaOmniaDal.Name = "dtpForzaturaOmniaDal"
        Me.dtpForzaturaOmniaDal.Size = New System.Drawing.Size(112, 20)
        Me.dtpForzaturaOmniaDal.TabIndex = 1
        '
        'ButtonForzaturaOmnia
        '
        Me.ButtonForzaturaOmnia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonForzaturaOmnia.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonForzaturaOmnia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonForzaturaOmnia.Location = New System.Drawing.Point(472, 85)
        Me.ButtonForzaturaOmnia.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.ButtonForzaturaOmnia.Name = "ButtonForzaturaOmnia"
        Me.ButtonForzaturaOmnia.Size = New System.Drawing.Size(120, 22)
        Me.ButtonForzaturaOmnia.TabIndex = 2
        Me.ButtonForzaturaOmnia.Text = "Button1"
        Me.ButtonForzaturaOmnia.UseVisualStyleBackColor = True
        '
        'LabelForzaturaDbUno
        '
        Me.LabelForzaturaDbUno.AutoSize = True
        Me.LabelForzaturaDbUno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelForzaturaDbUno.Location = New System.Drawing.Point(3, 129)
        Me.LabelForzaturaDbUno.Name = "LabelForzaturaDbUno"
        Me.LabelForzaturaDbUno.Size = New System.Drawing.Size(230, 26)
        Me.LabelForzaturaDbUno.TabIndex = 3
        Me.LabelForzaturaDbUno.Text = "Label1"
        Me.LabelForzaturaDbUno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBoxArchivioOmnia
        '
        Me.ComboBoxArchivioOmnia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxArchivioOmnia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxArchivioOmnia.FormattingEnabled = True
        Me.ComboBoxArchivioOmnia.Location = New System.Drawing.Point(357, 132)
        Me.ComboBoxArchivioOmnia.Name = "ComboBoxArchivioOmnia"
        Me.ComboBoxArchivioOmnia.Size = New System.Drawing.Size(112, 21)
        Me.ComboBoxArchivioOmnia.TabIndex = 4
        '
        'ButtonForzaturaDbuno
        '
        Me.ButtonForzaturaDbuno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonForzaturaDbuno.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonForzaturaDbuno.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonForzaturaDbuno.Location = New System.Drawing.Point(472, 131)
        Me.ButtonForzaturaDbuno.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.ButtonForzaturaDbuno.Name = "ButtonForzaturaDbuno"
        Me.ButtonForzaturaDbuno.Size = New System.Drawing.Size(120, 22)
        Me.ButtonForzaturaDbuno.TabIndex = 5
        Me.ButtonForzaturaDbuno.Text = "Button1"
        Me.ButtonForzaturaDbuno.UseVisualStyleBackColor = True
        '
        'dtpDataDaDbuno
        '
        Me.dtpDataDaDbuno.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataDaDbuno.Location = New System.Drawing.Point(239, 132)
        Me.dtpDataDaDbuno.Name = "dtpDataDaDbuno"
        Me.dtpDataDaDbuno.Size = New System.Drawing.Size(112, 20)
        Me.dtpDataDaDbuno.TabIndex = 6
        '
        'dtpForzaturaOmniaAl
        '
        Me.dtpForzaturaOmniaAl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpForzaturaOmniaAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpForzaturaOmniaAl.Location = New System.Drawing.Point(357, 34)
        Me.dtpForzaturaOmniaAl.Name = "dtpForzaturaOmniaAl"
        Me.dtpForzaturaOmniaAl.Size = New System.Drawing.Size(112, 20)
        Me.dtpForzaturaOmniaAl.TabIndex = 7
        '
        'ComboBoxTipoRecord
        '
        Me.ComboBoxTipoRecord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxTipoRecord.FormattingEnabled = True
        Me.ComboBoxTipoRecord.Location = New System.Drawing.Point(357, 60)
        Me.ComboBoxTipoRecord.Name = "ComboBoxTipoRecord"
        Me.ComboBoxTipoRecord.Size = New System.Drawing.Size(112, 21)
        Me.ComboBoxTipoRecord.TabIndex = 8
        '
        'ComboBoxAgenzia
        '
        Me.ComboBoxAgenzia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxAgenzia.FormattingEnabled = True
        Me.ComboBoxAgenzia.Location = New System.Drawing.Point(357, 86)
        Me.ComboBoxAgenzia.Name = "ComboBoxAgenzia"
        Me.ComboBoxAgenzia.Size = New System.Drawing.Size(112, 21)
        Me.ComboBoxAgenzia.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(239, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 26)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "dal"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(239, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 26)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "al"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(239, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 26)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "tipo record"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(239, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 26)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "codice"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelCumulo
        '
        Me.LabelCumulo.AutoSize = True
        Me.LabelCumulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCumulo.Location = New System.Drawing.Point(3, 181)
        Me.LabelCumulo.Name = "LabelCumulo"
        Me.LabelCumulo.Size = New System.Drawing.Size(230, 26)
        Me.LabelCumulo.TabIndex = 14
        Me.LabelCumulo.Text = "Label5"
        Me.LabelCumulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBoxTipoCumulo
        '
        Me.ComboBoxTipoCumulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxTipoCumulo.FormattingEnabled = True
        Me.ComboBoxTipoCumulo.Location = New System.Drawing.Point(357, 184)
        Me.ComboBoxTipoCumulo.Name = "ComboBoxTipoCumulo"
        Me.ComboBoxTipoCumulo.Size = New System.Drawing.Size(112, 21)
        Me.ComboBoxTipoCumulo.TabIndex = 16
        '
        'LabelImportaCumulo
        '
        Me.LabelImportaCumulo.AutoSize = True
        Me.LabelImportaCumulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelImportaCumulo.Location = New System.Drawing.Point(3, 207)
        Me.LabelImportaCumulo.Name = "LabelImportaCumulo"
        Me.LabelImportaCumulo.Size = New System.Drawing.Size(230, 26)
        Me.LabelImportaCumulo.TabIndex = 18
        Me.LabelImportaCumulo.Text = "Label6"
        Me.LabelImportaCumulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.tlpOmnia.SetColumnSpan(Me.Label6, 2)
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(239, 207)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(230, 26)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "^^^ scegli il codice e il tipo ^^^"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPageDL
        '
        Me.TabPageDL.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPageDL.Location = New System.Drawing.Point(4, 29)
        Me.TabPageDL.Name = "TabPageDL"
        Me.TabPageDL.Size = New System.Drawing.Size(592, 299)
        Me.TabPageDL.TabIndex = 2
        Me.TabPageDL.Text = "Forzature download agenzie"
        Me.TabPageDL.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.LabelForzaturaDL, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dtpForzaturaDL, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelDataForzaturaDL, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBoxArchivioDL, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonForzaturaDL, 2, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(592, 299)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'LabelForzaturaDL
        '
        Me.LabelForzaturaDL.AutoSize = True
        Me.LabelForzaturaDL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelForzaturaDL.Location = New System.Drawing.Point(3, 5)
        Me.LabelForzaturaDL.Name = "LabelForzaturaDL"
        Me.LabelForzaturaDL.Size = New System.Drawing.Size(290, 26)
        Me.LabelForzaturaDL.TabIndex = 0
        Me.LabelForzaturaDL.Text = "Label1"
        Me.LabelForzaturaDL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpForzaturaDL
        '
        Me.dtpForzaturaDL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpForzaturaDL.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpForzaturaDL.Location = New System.Drawing.Point(299, 44)
        Me.dtpForzaturaDL.Name = "dtpForzaturaDL"
        Me.dtpForzaturaDL.Size = New System.Drawing.Size(171, 20)
        Me.dtpForzaturaDL.TabIndex = 1
        '
        'LabelDataForzaturaDL
        '
        Me.LabelDataForzaturaDL.AutoSize = True
        Me.LabelDataForzaturaDL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelDataForzaturaDL.Location = New System.Drawing.Point(3, 41)
        Me.LabelDataForzaturaDL.Name = "LabelDataForzaturaDL"
        Me.LabelDataForzaturaDL.Size = New System.Drawing.Size(290, 26)
        Me.LabelDataForzaturaDL.TabIndex = 3
        Me.LabelDataForzaturaDL.Text = "Label1"
        Me.LabelDataForzaturaDL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBoxArchivioDL
        '
        Me.ComboBoxArchivioDL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxArchivioDL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxArchivioDL.FormattingEnabled = True
        Me.ComboBoxArchivioDL.Location = New System.Drawing.Point(299, 8)
        Me.ComboBoxArchivioDL.Name = "ComboBoxArchivioDL"
        Me.ComboBoxArchivioDL.Size = New System.Drawing.Size(171, 21)
        Me.ComboBoxArchivioDL.TabIndex = 4
        '
        'ButtonForzaturaDL
        '
        Me.ButtonForzaturaDL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonForzaturaDL.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonForzaturaDL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonForzaturaDL.Location = New System.Drawing.Point(473, 41)
        Me.ButtonForzaturaDL.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonForzaturaDL.Name = "ButtonForzaturaDL"
        Me.ButtonForzaturaDL.Size = New System.Drawing.Size(119, 26)
        Me.ButtonForzaturaDL.TabIndex = 5
        Me.ButtonForzaturaDL.Text = "Button1"
        Me.ButtonForzaturaDL.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsci.Location = New System.Drawing.Point(420, 332)
        Me.ButtonEsci.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(180, 30)
        Me.ButtonEsci.TabIndex = 2
        Me.ButtonEsci.Text = "Esci"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'ButtonAggiornaCalendario
        '
        Me.ButtonAggiornaCalendario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiornaCalendario.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAggiornaCalendario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAggiornaCalendario.Location = New System.Drawing.Point(0, 332)
        Me.ButtonAggiornaCalendario.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAggiornaCalendario.Name = "ButtonAggiornaCalendario"
        Me.ButtonAggiornaCalendario.Size = New System.Drawing.Size(420, 30)
        Me.ButtonAggiornaCalendario.TabIndex = 3
        Me.ButtonAggiornaCalendario.Text = "calendario"
        Me.ButtonAggiornaCalendario.UseVisualStyleBackColor = True
        '
        'FormImportaDati
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 366)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormImportaDati"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Text = "ImportaDati"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.TabPageImporta.ResumeLayout(False)
        Me.tlpImporta.ResumeLayout(False)
        Me.tlpImporta.PerformLayout()
        Me.TabPageOMNIA.ResumeLayout(False)
        Me.tlpOmnia.ResumeLayout(False)
        Me.tlpOmnia.PerformLayout()
        Me.TabPageDL.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpImporta As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ListViewCalendario As System.Windows.Forms.ListView
    Friend WithEvents LabelInfoDL As System.Windows.Forms.Label
    Friend WithEvents LabelMessaggio As System.Windows.Forms.Label
    Friend WithEvents TabMain As Utx.UtTabControl
    Friend WithEvents TabPageImporta As System.Windows.Forms.TabPage
    Friend WithEvents LabelInfoOmnia As System.Windows.Forms.Label
    Friend WithEvents TabPageOMNIA As System.Windows.Forms.TabPage
    Friend WithEvents TabPageDL As System.Windows.Forms.TabPage
    Friend WithEvents tlpOmnia As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelForzaturaOmnia As System.Windows.Forms.Label
    Friend WithEvents dtpForzaturaOmniaDal As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonForzaturaOmnia As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents LabelForzaturaDbUno As System.Windows.Forms.Label
    Friend WithEvents ComboBoxArchivioOmnia As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonForzaturaDbuno As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelForzaturaDL As System.Windows.Forms.Label
    Friend WithEvents dtpForzaturaDL As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelDataForzaturaDL As System.Windows.Forms.Label
    Friend WithEvents ComboBoxArchivioDL As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonForzaturaDL As System.Windows.Forms.Button
    Friend WithEvents ButtonAggiornaCalendario As System.Windows.Forms.Button
    Friend WithEvents dtpDataDaDbuno As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpForzaturaOmniaAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBoxTipoRecord As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxAgenzia As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LabelCumulo As Label
    Friend WithEvents ButtonCumulo As Button
    Friend WithEvents ComboBoxTipoCumulo As ComboBox
    Friend WithEvents LabelImportaCumulo As Label
    Friend WithEvents ButtonImportaCumulo As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBoxAgenziaCumulo As ComboBox
End Class
