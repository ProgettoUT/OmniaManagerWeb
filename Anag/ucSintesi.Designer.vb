<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSintesi
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing Then
                SalvaSettings()
                If components IsNot Nothing Then
                    components.Dispose()
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LabelPolizzeAutoCliente = New System.Windows.Forms.Label()
        Me.LabelNumeroFamiliari = New System.Windows.Forms.Label()
        Me.LabelPolizzeAutoFamiliari = New System.Windows.Forms.Label()
        Me.LabelPolizzeRECliente = New System.Windows.Forms.Label()
        Me.LabelPolizzeVitaCliente = New System.Windows.Forms.Label()
        Me.LabelArretratiCliente = New System.Windows.Forms.Label()
        Me.LabelPolizzeREFamiliari = New System.Windows.Forms.Label()
        Me.LabelPolizzeVitaFamiliari = New System.Windows.Forms.Label()
        Me.LabelIncassiFamiliari = New System.Windows.Forms.Label()
        Me.LabelArretratiFamiliari = New System.Windows.Forms.Label()
        Me.CheckBoxRiepilogoDatiAnagrafici = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRiepilogoArretrati = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRiepilogoIncassi = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRiepilogoPolizzeVita = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRiepilogoPolizzeRE = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRiepilogoPolizzeAuto = New System.Windows.Forms.CheckBox()
        Me.LabelIncassiCliente = New System.Windows.Forms.Label()
        Me.cmbSinistri = New System.Windows.Forms.ComboBox()
        Me.cmbIncassi = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ButtonStampaCopertina = New System.Windows.Forms.Button()
        Me.ButtonStampaScheda = New System.Windows.Forms.Button()
        Me.CheckBoxRiepilogoSinistri = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LabelSinistriCliente = New System.Windows.Forms.Label()
        Me.LabelSinistriFamiliari = New System.Windows.Forms.Label()
        Me.CheckBoxRiepilogoAvvisi = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LabelAvvisiNumero = New System.Windows.Forms.Label()
        Me.CheckBoxRiepilogoSelezionaTutto = New System.Windows.Forms.CheckBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LabelPolizzeAutoEnti = New System.Windows.Forms.Label()
        Me.LabelPolizzeREEnti = New System.Windows.Forms.Label()
        Me.LabelPolizzeVitaEnti = New System.Windows.Forms.Label()
        Me.LabelIncassiEnti = New System.Windows.Forms.Label()
        Me.LabelArretratiEnti = New System.Windows.Forms.Label()
        Me.LabelSinistriEnti = New System.Windows.Forms.Label()
        Me.LabelNumeroEnti = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CheckBoxCopertinaCliente = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCopertinaSituazione = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCopertinaNote = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCopertinaFasiVendita = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCopertinaAnalisiRca = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCopertinaA3 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCopertinaTutto = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ButtonEstrattoConto = New System.Windows.Forms.Button()
        Me.dgvTelefonate = New System.Windows.Forms.DataGridView()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvTelefonate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.9802!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.91023!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.01483!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.01483!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.01483!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.06509!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 1, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelPolizzeAutoCliente, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelNumeroFamiliari, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelPolizzeAutoFamiliari, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelPolizzeRECliente, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelPolizzeVitaCliente, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelArretratiCliente, 3, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelPolizzeREFamiliari, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelPolizzeVitaFamiliari, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelIncassiFamiliari, 4, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelArretratiFamiliari, 4, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxRiepilogoDatiAnagrafici, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxRiepilogoArretrati, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxRiepilogoIncassi, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxRiepilogoPolizzeVita, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxRiepilogoPolizzeRE, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxRiepilogoPolizzeAuto, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelIncassiCliente, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSinistri, 2, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbIncassi, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonStampaCopertina, 6, 15)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonStampaScheda, 0, 15)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxRiepilogoSinistri, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelSinistriCliente, 3, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelSinistriFamiliari, 4, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxRiepilogoAvvisi, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelAvvisiNumero, 3, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxRiepilogoSelezionaTutto, 0, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.Label29, 1, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelPolizzeAutoEnti, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelPolizzeREEnti, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelPolizzeVitaEnti, 5, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelIncassiEnti, 5, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelArretratiEnti, 5, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelSinistriEnti, 5, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelNumeroEnti, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxCopertinaCliente, 6, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxCopertinaSituazione, 6, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxCopertinaNote, 6, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxCopertinaFasiVendita, 6, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxCopertinaAnalisiRca, 6, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxCopertinaA3, 6, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxCopertinaTutto, 6, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label17, 4, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label18, 5, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEstrattoConto, 4, 15)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvTelefonate, 0, 13)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 16
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1036, 547)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(797, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(239, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Copertina"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 3)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(317, 22)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Riepilogo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label3, 2)
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(40, 25)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(277, 28)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Numero Componenti Familiari ed enti di appartenenza"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label4, 2)
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(40, 53)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(277, 28)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Polizze Auto (premi tassabili)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label5, 2)
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(40, 81)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(277, 28)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Polizze R.E. (premi tassabili)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label6, 2)
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(40, 109)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(277, 28)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Polizze Vita (premi tassabili)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(40, 137)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 28)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Incassi (premi lordi)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Location = New System.Drawing.Point(40, 165)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 28)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Arretrati (premi lordi)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelPolizzeAutoCliente
        '
        Me.LabelPolizzeAutoCliente.AutoSize = True
        Me.LabelPolizzeAutoCliente.BackColor = System.Drawing.Color.Moccasin
        Me.LabelPolizzeAutoCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPolizzeAutoCliente.Location = New System.Drawing.Point(320, 53)
        Me.LabelPolizzeAutoCliente.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelPolizzeAutoCliente.Name = "LabelPolizzeAutoCliente"
        Me.LabelPolizzeAutoCliente.Size = New System.Drawing.Size(156, 28)
        Me.LabelPolizzeAutoCliente.TabIndex = 6
        Me.LabelPolizzeAutoCliente.Text = "0"
        Me.LabelPolizzeAutoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelNumeroFamiliari
        '
        Me.LabelNumeroFamiliari.AutoSize = True
        Me.LabelNumeroFamiliari.BackColor = System.Drawing.Color.Azure
        Me.LabelNumeroFamiliari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNumeroFamiliari.Location = New System.Drawing.Point(479, 25)
        Me.LabelNumeroFamiliari.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelNumeroFamiliari.Name = "LabelNumeroFamiliari"
        Me.LabelNumeroFamiliari.Size = New System.Drawing.Size(156, 28)
        Me.LabelNumeroFamiliari.TabIndex = 6
        Me.LabelNumeroFamiliari.Text = "0"
        Me.LabelNumeroFamiliari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelPolizzeAutoFamiliari
        '
        Me.LabelPolizzeAutoFamiliari.AutoSize = True
        Me.LabelPolizzeAutoFamiliari.BackColor = System.Drawing.Color.Azure
        Me.LabelPolizzeAutoFamiliari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPolizzeAutoFamiliari.Location = New System.Drawing.Point(479, 53)
        Me.LabelPolizzeAutoFamiliari.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelPolizzeAutoFamiliari.Name = "LabelPolizzeAutoFamiliari"
        Me.LabelPolizzeAutoFamiliari.Size = New System.Drawing.Size(156, 28)
        Me.LabelPolizzeAutoFamiliari.TabIndex = 6
        Me.LabelPolizzeAutoFamiliari.Text = "0,00"
        Me.LabelPolizzeAutoFamiliari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelPolizzeRECliente
        '
        Me.LabelPolizzeRECliente.AutoSize = True
        Me.LabelPolizzeRECliente.BackColor = System.Drawing.Color.Moccasin
        Me.LabelPolizzeRECliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPolizzeRECliente.Location = New System.Drawing.Point(320, 81)
        Me.LabelPolizzeRECliente.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelPolizzeRECliente.Name = "LabelPolizzeRECliente"
        Me.LabelPolizzeRECliente.Size = New System.Drawing.Size(156, 28)
        Me.LabelPolizzeRECliente.TabIndex = 6
        Me.LabelPolizzeRECliente.Text = "0"
        Me.LabelPolizzeRECliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelPolizzeVitaCliente
        '
        Me.LabelPolizzeVitaCliente.AutoSize = True
        Me.LabelPolizzeVitaCliente.BackColor = System.Drawing.Color.Moccasin
        Me.LabelPolizzeVitaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPolizzeVitaCliente.Location = New System.Drawing.Point(320, 109)
        Me.LabelPolizzeVitaCliente.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelPolizzeVitaCliente.Name = "LabelPolizzeVitaCliente"
        Me.LabelPolizzeVitaCliente.Size = New System.Drawing.Size(156, 28)
        Me.LabelPolizzeVitaCliente.TabIndex = 6
        Me.LabelPolizzeVitaCliente.Text = "0"
        Me.LabelPolizzeVitaCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelArretratiCliente
        '
        Me.LabelArretratiCliente.AutoSize = True
        Me.LabelArretratiCliente.BackColor = System.Drawing.Color.Moccasin
        Me.LabelArretratiCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelArretratiCliente.Location = New System.Drawing.Point(320, 165)
        Me.LabelArretratiCliente.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelArretratiCliente.Name = "LabelArretratiCliente"
        Me.LabelArretratiCliente.Size = New System.Drawing.Size(156, 28)
        Me.LabelArretratiCliente.TabIndex = 6
        Me.LabelArretratiCliente.Text = "0"
        Me.LabelArretratiCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelPolizzeREFamiliari
        '
        Me.LabelPolizzeREFamiliari.AutoSize = True
        Me.LabelPolizzeREFamiliari.BackColor = System.Drawing.Color.Azure
        Me.LabelPolizzeREFamiliari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPolizzeREFamiliari.Location = New System.Drawing.Point(479, 81)
        Me.LabelPolizzeREFamiliari.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelPolizzeREFamiliari.Name = "LabelPolizzeREFamiliari"
        Me.LabelPolizzeREFamiliari.Size = New System.Drawing.Size(156, 28)
        Me.LabelPolizzeREFamiliari.TabIndex = 6
        Me.LabelPolizzeREFamiliari.Text = "0,00"
        Me.LabelPolizzeREFamiliari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelPolizzeVitaFamiliari
        '
        Me.LabelPolizzeVitaFamiliari.AutoSize = True
        Me.LabelPolizzeVitaFamiliari.BackColor = System.Drawing.Color.Azure
        Me.LabelPolizzeVitaFamiliari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPolizzeVitaFamiliari.Location = New System.Drawing.Point(479, 109)
        Me.LabelPolizzeVitaFamiliari.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelPolizzeVitaFamiliari.Name = "LabelPolizzeVitaFamiliari"
        Me.LabelPolizzeVitaFamiliari.Size = New System.Drawing.Size(156, 28)
        Me.LabelPolizzeVitaFamiliari.TabIndex = 6
        Me.LabelPolizzeVitaFamiliari.Text = "0,00"
        Me.LabelPolizzeVitaFamiliari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelIncassiFamiliari
        '
        Me.LabelIncassiFamiliari.AutoSize = True
        Me.LabelIncassiFamiliari.BackColor = System.Drawing.Color.Azure
        Me.LabelIncassiFamiliari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelIncassiFamiliari.Location = New System.Drawing.Point(479, 137)
        Me.LabelIncassiFamiliari.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelIncassiFamiliari.Name = "LabelIncassiFamiliari"
        Me.LabelIncassiFamiliari.Size = New System.Drawing.Size(156, 28)
        Me.LabelIncassiFamiliari.TabIndex = 6
        Me.LabelIncassiFamiliari.Text = "0,00"
        Me.LabelIncassiFamiliari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelArretratiFamiliari
        '
        Me.LabelArretratiFamiliari.AutoSize = True
        Me.LabelArretratiFamiliari.BackColor = System.Drawing.Color.Azure
        Me.LabelArretratiFamiliari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelArretratiFamiliari.Location = New System.Drawing.Point(479, 165)
        Me.LabelArretratiFamiliari.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelArretratiFamiliari.Name = "LabelArretratiFamiliari"
        Me.LabelArretratiFamiliari.Size = New System.Drawing.Size(156, 28)
        Me.LabelArretratiFamiliari.TabIndex = 6
        Me.LabelArretratiFamiliari.Text = "0,00"
        Me.LabelArretratiFamiliari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxRiepilogoDatiAnagrafici
        '
        Me.CheckBoxRiepilogoDatiAnagrafici.AutoSize = True
        Me.CheckBoxRiepilogoDatiAnagrafici.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxRiepilogoDatiAnagrafici.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxRiepilogoDatiAnagrafici.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CheckBoxRiepilogoDatiAnagrafici.Location = New System.Drawing.Point(3, 28)
        Me.CheckBoxRiepilogoDatiAnagrafici.Name = "CheckBoxRiepilogoDatiAnagrafici"
        Me.CheckBoxRiepilogoDatiAnagrafici.Padding = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.CheckBoxRiepilogoDatiAnagrafici.Size = New System.Drawing.Size(34, 22)
        Me.CheckBoxRiepilogoDatiAnagrafici.TabIndex = 1
        Me.CheckBoxRiepilogoDatiAnagrafici.UseVisualStyleBackColor = True
        '
        'CheckBoxRiepilogoArretrati
        '
        Me.CheckBoxRiepilogoArretrati.AutoSize = True
        Me.CheckBoxRiepilogoArretrati.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxRiepilogoArretrati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxRiepilogoArretrati.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CheckBoxRiepilogoArretrati.Location = New System.Drawing.Point(3, 168)
        Me.CheckBoxRiepilogoArretrati.Name = "CheckBoxRiepilogoArretrati"
        Me.CheckBoxRiepilogoArretrati.Padding = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.CheckBoxRiepilogoArretrati.Size = New System.Drawing.Size(34, 22)
        Me.CheckBoxRiepilogoArretrati.TabIndex = 1
        Me.CheckBoxRiepilogoArretrati.UseVisualStyleBackColor = True
        '
        'CheckBoxRiepilogoIncassi
        '
        Me.CheckBoxRiepilogoIncassi.AutoSize = True
        Me.CheckBoxRiepilogoIncassi.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxRiepilogoIncassi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxRiepilogoIncassi.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CheckBoxRiepilogoIncassi.Location = New System.Drawing.Point(3, 140)
        Me.CheckBoxRiepilogoIncassi.Name = "CheckBoxRiepilogoIncassi"
        Me.CheckBoxRiepilogoIncassi.Padding = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.CheckBoxRiepilogoIncassi.Size = New System.Drawing.Size(34, 22)
        Me.CheckBoxRiepilogoIncassi.TabIndex = 1
        Me.CheckBoxRiepilogoIncassi.UseVisualStyleBackColor = True
        '
        'CheckBoxRiepilogoPolizzeVita
        '
        Me.CheckBoxRiepilogoPolizzeVita.AutoSize = True
        Me.CheckBoxRiepilogoPolizzeVita.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxRiepilogoPolizzeVita.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxRiepilogoPolizzeVita.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CheckBoxRiepilogoPolizzeVita.Location = New System.Drawing.Point(3, 112)
        Me.CheckBoxRiepilogoPolizzeVita.Name = "CheckBoxRiepilogoPolizzeVita"
        Me.CheckBoxRiepilogoPolizzeVita.Padding = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.CheckBoxRiepilogoPolizzeVita.Size = New System.Drawing.Size(34, 22)
        Me.CheckBoxRiepilogoPolizzeVita.TabIndex = 1
        Me.CheckBoxRiepilogoPolizzeVita.UseVisualStyleBackColor = True
        '
        'CheckBoxRiepilogoPolizzeRE
        '
        Me.CheckBoxRiepilogoPolizzeRE.AutoSize = True
        Me.CheckBoxRiepilogoPolizzeRE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxRiepilogoPolizzeRE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxRiepilogoPolizzeRE.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CheckBoxRiepilogoPolizzeRE.Location = New System.Drawing.Point(3, 84)
        Me.CheckBoxRiepilogoPolizzeRE.Name = "CheckBoxRiepilogoPolizzeRE"
        Me.CheckBoxRiepilogoPolizzeRE.Padding = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.CheckBoxRiepilogoPolizzeRE.Size = New System.Drawing.Size(34, 22)
        Me.CheckBoxRiepilogoPolizzeRE.TabIndex = 1
        Me.CheckBoxRiepilogoPolizzeRE.UseVisualStyleBackColor = True
        '
        'CheckBoxRiepilogoPolizzeAuto
        '
        Me.CheckBoxRiepilogoPolizzeAuto.AutoSize = True
        Me.CheckBoxRiepilogoPolizzeAuto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxRiepilogoPolizzeAuto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxRiepilogoPolizzeAuto.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CheckBoxRiepilogoPolizzeAuto.Location = New System.Drawing.Point(3, 56)
        Me.CheckBoxRiepilogoPolizzeAuto.Name = "CheckBoxRiepilogoPolizzeAuto"
        Me.CheckBoxRiepilogoPolizzeAuto.Padding = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.CheckBoxRiepilogoPolizzeAuto.Size = New System.Drawing.Size(34, 22)
        Me.CheckBoxRiepilogoPolizzeAuto.TabIndex = 1
        Me.CheckBoxRiepilogoPolizzeAuto.UseVisualStyleBackColor = True
        '
        'LabelIncassiCliente
        '
        Me.LabelIncassiCliente.AutoSize = True
        Me.LabelIncassiCliente.BackColor = System.Drawing.Color.Moccasin
        Me.LabelIncassiCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelIncassiCliente.Location = New System.Drawing.Point(320, 137)
        Me.LabelIncassiCliente.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelIncassiCliente.Name = "LabelIncassiCliente"
        Me.LabelIncassiCliente.Size = New System.Drawing.Size(156, 28)
        Me.LabelIncassiCliente.TabIndex = 6
        Me.LabelIncassiCliente.Text = "0"
        Me.LabelIncassiCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSinistri
        '
        Me.cmbSinistri.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmbSinistri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSinistri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSinistri.FormattingEnabled = True
        Me.cmbSinistri.Location = New System.Drawing.Point(172, 196)
        Me.cmbSinistri.Name = "cmbSinistri"
        Me.cmbSinistri.Size = New System.Drawing.Size(142, 21)
        Me.cmbSinistri.TabIndex = 2
        '
        'cmbIncassi
        '
        Me.cmbIncassi.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmbIncassi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIncassi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbIncassi.FormattingEnabled = True
        Me.cmbIncassi.Location = New System.Drawing.Point(172, 140)
        Me.cmbIncassi.Name = "cmbIncassi"
        Me.cmbIncassi.Size = New System.Drawing.Size(142, 21)
        Me.cmbIncassi.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Moccasin
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(320, 0)
        Me.Label13.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(156, 22)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Cliente"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Azure
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(479, 0)
        Me.Label14.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(156, 22)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Familiari"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonStampaCopertina
        '
        Me.ButtonStampaCopertina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonStampaCopertina.Location = New System.Drawing.Point(797, 514)
        Me.ButtonStampaCopertina.Name = "ButtonStampaCopertina"
        Me.ButtonStampaCopertina.Size = New System.Drawing.Size(236, 30)
        Me.ButtonStampaCopertina.TabIndex = 5
        Me.ButtonStampaCopertina.Text = "Stampa copertina"
        Me.ButtonStampaCopertina.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ButtonStampaCopertina.UseVisualStyleBackColor = True
        '
        'ButtonStampaScheda
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonStampaScheda, 4)
        Me.ButtonStampaScheda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonStampaScheda.Location = New System.Drawing.Point(3, 514)
        Me.ButtonStampaScheda.Name = "ButtonStampaScheda"
        Me.ButtonStampaScheda.Size = New System.Drawing.Size(470, 30)
        Me.ButtonStampaScheda.TabIndex = 5
        Me.ButtonStampaScheda.Text = "Stampa riepilogo"
        Me.ButtonStampaScheda.UseVisualStyleBackColor = True
        '
        'CheckBoxRiepilogoSinistri
        '
        Me.CheckBoxRiepilogoSinistri.AutoSize = True
        Me.CheckBoxRiepilogoSinistri.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxRiepilogoSinistri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxRiepilogoSinistri.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CheckBoxRiepilogoSinistri.Location = New System.Drawing.Point(3, 196)
        Me.CheckBoxRiepilogoSinistri.Name = "CheckBoxRiepilogoSinistri"
        Me.CheckBoxRiepilogoSinistri.Padding = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.CheckBoxRiepilogoSinistri.Size = New System.Drawing.Size(34, 22)
        Me.CheckBoxRiepilogoSinistri.TabIndex = 1
        Me.CheckBoxRiepilogoSinistri.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(40, 193)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 28)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Sinistri"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelSinistriCliente
        '
        Me.LabelSinistriCliente.AutoSize = True
        Me.LabelSinistriCliente.BackColor = System.Drawing.Color.Moccasin
        Me.LabelSinistriCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSinistriCliente.Location = New System.Drawing.Point(320, 193)
        Me.LabelSinistriCliente.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelSinistriCliente.Name = "LabelSinistriCliente"
        Me.LabelSinistriCliente.Size = New System.Drawing.Size(156, 28)
        Me.LabelSinistriCliente.TabIndex = 6
        Me.LabelSinistriCliente.Text = "0"
        Me.LabelSinistriCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelSinistriFamiliari
        '
        Me.LabelSinistriFamiliari.AutoSize = True
        Me.LabelSinistriFamiliari.BackColor = System.Drawing.Color.Azure
        Me.LabelSinistriFamiliari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSinistriFamiliari.Location = New System.Drawing.Point(479, 193)
        Me.LabelSinistriFamiliari.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelSinistriFamiliari.Name = "LabelSinistriFamiliari"
        Me.LabelSinistriFamiliari.Size = New System.Drawing.Size(156, 28)
        Me.LabelSinistriFamiliari.TabIndex = 6
        Me.LabelSinistriFamiliari.Text = "0,00"
        Me.LabelSinistriFamiliari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxRiepilogoAvvisi
        '
        Me.CheckBoxRiepilogoAvvisi.AutoSize = True
        Me.CheckBoxRiepilogoAvvisi.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxRiepilogoAvvisi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxRiepilogoAvvisi.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CheckBoxRiepilogoAvvisi.Location = New System.Drawing.Point(3, 224)
        Me.CheckBoxRiepilogoAvvisi.Name = "CheckBoxRiepilogoAvvisi"
        Me.CheckBoxRiepilogoAvvisi.Padding = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.CheckBoxRiepilogoAvvisi.Size = New System.Drawing.Size(34, 22)
        Me.CheckBoxRiepilogoAvvisi.TabIndex = 1
        Me.CheckBoxRiepilogoAvvisi.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label11, 2)
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Location = New System.Drawing.Point(40, 221)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(277, 28)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Numero Notifiche"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelAvvisiNumero
        '
        Me.LabelAvvisiNumero.AutoSize = True
        Me.LabelAvvisiNumero.BackColor = System.Drawing.Color.Moccasin
        Me.LabelAvvisiNumero.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelAvvisiNumero.Location = New System.Drawing.Point(320, 221)
        Me.LabelAvvisiNumero.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelAvvisiNumero.Name = "LabelAvvisiNumero"
        Me.LabelAvvisiNumero.Size = New System.Drawing.Size(156, 28)
        Me.LabelAvvisiNumero.TabIndex = 6
        Me.LabelAvvisiNumero.Text = "0"
        Me.LabelAvvisiNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxRiepilogoSelezionaTutto
        '
        Me.CheckBoxRiepilogoSelezionaTutto.AutoSize = True
        Me.CheckBoxRiepilogoSelezionaTutto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxRiepilogoSelezionaTutto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxRiepilogoSelezionaTutto.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CheckBoxRiepilogoSelezionaTutto.Location = New System.Drawing.Point(3, 280)
        Me.CheckBoxRiepilogoSelezionaTutto.Name = "CheckBoxRiepilogoSelezionaTutto"
        Me.CheckBoxRiepilogoSelezionaTutto.Padding = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.CheckBoxRiepilogoSelezionaTutto.Size = New System.Drawing.Size(34, 22)
        Me.CheckBoxRiepilogoSelezionaTutto.TabIndex = 1
        Me.CheckBoxRiepilogoSelezionaTutto.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label29, 2)
        Me.Label29.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label29.Location = New System.Drawing.Point(40, 277)
        Me.Label29.Margin = New System.Windows.Forms.Padding(0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(277, 28)
        Me.Label29.TabIndex = 6
        Me.Label29.Text = "Seleziona / Deseleziona tutti"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.AliceBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(638, 0)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(156, 22)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Enti"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelPolizzeAutoEnti
        '
        Me.LabelPolizzeAutoEnti.AutoSize = True
        Me.LabelPolizzeAutoEnti.BackColor = System.Drawing.Color.AliceBlue
        Me.LabelPolizzeAutoEnti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPolizzeAutoEnti.Location = New System.Drawing.Point(638, 53)
        Me.LabelPolizzeAutoEnti.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelPolizzeAutoEnti.Name = "LabelPolizzeAutoEnti"
        Me.LabelPolizzeAutoEnti.Size = New System.Drawing.Size(156, 28)
        Me.LabelPolizzeAutoEnti.TabIndex = 6
        Me.LabelPolizzeAutoEnti.Text = "0,00"
        Me.LabelPolizzeAutoEnti.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelPolizzeREEnti
        '
        Me.LabelPolizzeREEnti.AutoSize = True
        Me.LabelPolizzeREEnti.BackColor = System.Drawing.Color.AliceBlue
        Me.LabelPolizzeREEnti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPolizzeREEnti.Location = New System.Drawing.Point(638, 81)
        Me.LabelPolizzeREEnti.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelPolizzeREEnti.Name = "LabelPolizzeREEnti"
        Me.LabelPolizzeREEnti.Size = New System.Drawing.Size(156, 28)
        Me.LabelPolizzeREEnti.TabIndex = 6
        Me.LabelPolizzeREEnti.Text = "0,00"
        Me.LabelPolizzeREEnti.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelPolizzeVitaEnti
        '
        Me.LabelPolizzeVitaEnti.AutoSize = True
        Me.LabelPolizzeVitaEnti.BackColor = System.Drawing.Color.AliceBlue
        Me.LabelPolizzeVitaEnti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPolizzeVitaEnti.Location = New System.Drawing.Point(638, 109)
        Me.LabelPolizzeVitaEnti.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelPolizzeVitaEnti.Name = "LabelPolizzeVitaEnti"
        Me.LabelPolizzeVitaEnti.Size = New System.Drawing.Size(156, 28)
        Me.LabelPolizzeVitaEnti.TabIndex = 6
        Me.LabelPolizzeVitaEnti.Text = "0,00"
        Me.LabelPolizzeVitaEnti.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelIncassiEnti
        '
        Me.LabelIncassiEnti.AutoSize = True
        Me.LabelIncassiEnti.BackColor = System.Drawing.Color.AliceBlue
        Me.LabelIncassiEnti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelIncassiEnti.Location = New System.Drawing.Point(638, 137)
        Me.LabelIncassiEnti.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelIncassiEnti.Name = "LabelIncassiEnti"
        Me.LabelIncassiEnti.Size = New System.Drawing.Size(156, 28)
        Me.LabelIncassiEnti.TabIndex = 6
        Me.LabelIncassiEnti.Text = "0,00"
        Me.LabelIncassiEnti.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelArretratiEnti
        '
        Me.LabelArretratiEnti.AutoSize = True
        Me.LabelArretratiEnti.BackColor = System.Drawing.Color.AliceBlue
        Me.LabelArretratiEnti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelArretratiEnti.Location = New System.Drawing.Point(638, 165)
        Me.LabelArretratiEnti.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelArretratiEnti.Name = "LabelArretratiEnti"
        Me.LabelArretratiEnti.Size = New System.Drawing.Size(156, 28)
        Me.LabelArretratiEnti.TabIndex = 6
        Me.LabelArretratiEnti.Text = "0,00"
        Me.LabelArretratiEnti.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelSinistriEnti
        '
        Me.LabelSinistriEnti.AutoSize = True
        Me.LabelSinistriEnti.BackColor = System.Drawing.Color.AliceBlue
        Me.LabelSinistriEnti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSinistriEnti.Location = New System.Drawing.Point(638, 193)
        Me.LabelSinistriEnti.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelSinistriEnti.Name = "LabelSinistriEnti"
        Me.LabelSinistriEnti.Size = New System.Drawing.Size(156, 28)
        Me.LabelSinistriEnti.TabIndex = 6
        Me.LabelSinistriEnti.Text = "0,00"
        Me.LabelSinistriEnti.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelNumeroEnti
        '
        Me.LabelNumeroEnti.AutoSize = True
        Me.LabelNumeroEnti.BackColor = System.Drawing.Color.AliceBlue
        Me.LabelNumeroEnti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNumeroEnti.Location = New System.Drawing.Point(638, 25)
        Me.LabelNumeroEnti.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LabelNumeroEnti.Name = "LabelNumeroEnti"
        Me.LabelNumeroEnti.Size = New System.Drawing.Size(156, 28)
        Me.LabelNumeroEnti.TabIndex = 6
        Me.LabelNumeroEnti.Text = "0"
        Me.LabelNumeroEnti.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(876, 28)
        Me.Label15.Margin = New System.Windows.Forms.Padding(3, 3, 30, 3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(130, 22)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Elementi da Stampare"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxCopertinaCliente
        '
        Me.CheckBoxCopertinaCliente.AutoSize = True
        Me.CheckBoxCopertinaCliente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxCopertinaCliente.Checked = True
        Me.CheckBoxCopertinaCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCopertinaCliente.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckBoxCopertinaCliente.Location = New System.Drawing.Point(948, 56)
        Me.CheckBoxCopertinaCliente.Margin = New System.Windows.Forms.Padding(3, 3, 30, 3)
        Me.CheckBoxCopertinaCliente.Name = "CheckBoxCopertinaCliente"
        Me.CheckBoxCopertinaCliente.Size = New System.Drawing.Size(58, 22)
        Me.CheckBoxCopertinaCliente.TabIndex = 8
        Me.CheckBoxCopertinaCliente.Text = "Cliente"
        Me.CheckBoxCopertinaCliente.UseVisualStyleBackColor = True
        '
        'CheckBoxCopertinaSituazione
        '
        Me.CheckBoxCopertinaSituazione.AutoSize = True
        Me.CheckBoxCopertinaSituazione.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxCopertinaSituazione.Checked = True
        Me.CheckBoxCopertinaSituazione.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCopertinaSituazione.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckBoxCopertinaSituazione.Location = New System.Drawing.Point(931, 84)
        Me.CheckBoxCopertinaSituazione.Margin = New System.Windows.Forms.Padding(3, 3, 30, 3)
        Me.CheckBoxCopertinaSituazione.Name = "CheckBoxCopertinaSituazione"
        Me.CheckBoxCopertinaSituazione.Size = New System.Drawing.Size(75, 22)
        Me.CheckBoxCopertinaSituazione.TabIndex = 9
        Me.CheckBoxCopertinaSituazione.Text = "Situazione"
        Me.CheckBoxCopertinaSituazione.UseVisualStyleBackColor = True
        '
        'CheckBoxCopertinaNote
        '
        Me.CheckBoxCopertinaNote.AutoSize = True
        Me.CheckBoxCopertinaNote.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxCopertinaNote.Checked = True
        Me.CheckBoxCopertinaNote.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCopertinaNote.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckBoxCopertinaNote.Location = New System.Drawing.Point(957, 112)
        Me.CheckBoxCopertinaNote.Margin = New System.Windows.Forms.Padding(3, 3, 30, 3)
        Me.CheckBoxCopertinaNote.Name = "CheckBoxCopertinaNote"
        Me.CheckBoxCopertinaNote.Size = New System.Drawing.Size(49, 22)
        Me.CheckBoxCopertinaNote.TabIndex = 10
        Me.CheckBoxCopertinaNote.Text = "Note"
        Me.CheckBoxCopertinaNote.UseVisualStyleBackColor = True
        '
        'CheckBoxCopertinaFasiVendita
        '
        Me.CheckBoxCopertinaFasiVendita.AutoSize = True
        Me.CheckBoxCopertinaFasiVendita.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxCopertinaFasiVendita.Checked = True
        Me.CheckBoxCopertinaFasiVendita.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCopertinaFasiVendita.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckBoxCopertinaFasiVendita.Location = New System.Drawing.Point(911, 140)
        Me.CheckBoxCopertinaFasiVendita.Margin = New System.Windows.Forms.Padding(3, 3, 30, 3)
        Me.CheckBoxCopertinaFasiVendita.Name = "CheckBoxCopertinaFasiVendita"
        Me.CheckBoxCopertinaFasiVendita.Size = New System.Drawing.Size(95, 22)
        Me.CheckBoxCopertinaFasiVendita.TabIndex = 11
        Me.CheckBoxCopertinaFasiVendita.Text = "Fasi di Vendita"
        Me.CheckBoxCopertinaFasiVendita.UseVisualStyleBackColor = True
        '
        'CheckBoxCopertinaAnalisiRca
        '
        Me.CheckBoxCopertinaAnalisiRca.AutoSize = True
        Me.CheckBoxCopertinaAnalisiRca.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxCopertinaAnalisiRca.Checked = True
        Me.CheckBoxCopertinaAnalisiRca.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCopertinaAnalisiRca.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckBoxCopertinaAnalisiRca.Location = New System.Drawing.Point(927, 168)
        Me.CheckBoxCopertinaAnalisiRca.Margin = New System.Windows.Forms.Padding(3, 3, 30, 3)
        Me.CheckBoxCopertinaAnalisiRca.Name = "CheckBoxCopertinaAnalisiRca"
        Me.CheckBoxCopertinaAnalisiRca.Size = New System.Drawing.Size(79, 22)
        Me.CheckBoxCopertinaAnalisiRca.TabIndex = 12
        Me.CheckBoxCopertinaAnalisiRca.Text = "Analisi Rca"
        Me.CheckBoxCopertinaAnalisiRca.UseVisualStyleBackColor = True
        '
        'CheckBoxCopertinaA3
        '
        Me.CheckBoxCopertinaA3.AutoSize = True
        Me.CheckBoxCopertinaA3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxCopertinaA3.Checked = True
        Me.CheckBoxCopertinaA3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCopertinaA3.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckBoxCopertinaA3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxCopertinaA3.Location = New System.Drawing.Point(859, 224)
        Me.CheckBoxCopertinaA3.Margin = New System.Windows.Forms.Padding(3, 3, 30, 3)
        Me.CheckBoxCopertinaA3.Name = "CheckBoxCopertinaA3"
        Me.CheckBoxCopertinaA3.Size = New System.Drawing.Size(147, 22)
        Me.CheckBoxCopertinaA3.TabIndex = 7
        Me.CheckBoxCopertinaA3.Text = "Stampa in formato A3"
        Me.CheckBoxCopertinaA3.UseVisualStyleBackColor = True
        '
        'CheckBoxCopertinaTutto
        '
        Me.CheckBoxCopertinaTutto.AutoSize = True
        Me.CheckBoxCopertinaTutto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxCopertinaTutto.Checked = True
        Me.CheckBoxCopertinaTutto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCopertinaTutto.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckBoxCopertinaTutto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBoxCopertinaTutto.Location = New System.Drawing.Point(845, 280)
        Me.CheckBoxCopertinaTutto.Margin = New System.Windows.Forms.Padding(3, 3, 30, 3)
        Me.CheckBoxCopertinaTutto.Name = "CheckBoxCopertinaTutto"
        Me.CheckBoxCopertinaTutto.Size = New System.Drawing.Size(161, 22)
        Me.CheckBoxCopertinaTutto.TabIndex = 1
        Me.CheckBoxCopertinaTutto.Text = "Seleziona / Deseleziona tutti"
        Me.CheckBoxCopertinaTutto.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Moccasin
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.Location = New System.Drawing.Point(320, 25)
        Me.Label16.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(156, 28)
        Me.Label16.TabIndex = 6
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Azure
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label17.Location = New System.Drawing.Point(479, 221)
        Me.Label17.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(156, 28)
        Me.Label17.TabIndex = 6
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.AliceBlue
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label18.Location = New System.Drawing.Point(638, 221)
        Me.Label18.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(156, 28)
        Me.Label18.TabIndex = 6
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonEstrattoConto
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonEstrattoConto, 2)
        Me.ButtonEstrattoConto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEstrattoConto.Location = New System.Drawing.Point(479, 514)
        Me.ButtonEstrattoConto.Name = "ButtonEstrattoConto"
        Me.ButtonEstrattoConto.Size = New System.Drawing.Size(312, 30)
        Me.ButtonEstrattoConto.TabIndex = 13
        Me.ButtonEstrattoConto.Text = "Stampa premi pagati"
        Me.ButtonEstrattoConto.UseVisualStyleBackColor = True
        '
        'dgvTelefonate
        '
        Me.dgvTelefonate.AllowUserToAddRows = False
        Me.dgvTelefonate.AllowUserToDeleteRows = False
        Me.dgvTelefonate.AllowUserToResizeRows = False
        Me.dgvTelefonate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvTelefonate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvTelefonate, 7)
        Me.dgvTelefonate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTelefonate.Location = New System.Drawing.Point(3, 336)
        Me.dgvTelefonate.Name = "dgvTelefonate"
        Me.dgvTelefonate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTelefonate.Size = New System.Drawing.Size(1030, 119)
        Me.dgvTelefonate.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label12, 2)
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Location = New System.Drawing.Point(40, 305)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(277, 28)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Telefonate registrate"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ucSintesi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleGreen
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ucSintesi"
        Me.Size = New System.Drawing.Size(1036, 547)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvTelefonate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxRiepilogoDatiAnagrafici As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRiepilogoPolizzeAuto As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRiepilogoPolizzeRE As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRiepilogoSinistri As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRiepilogoIncassi As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRiepilogoArretrati As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRiepilogoAvvisi As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbSinistri As System.Windows.Forms.ComboBox
    Friend WithEvents cmbIncassi As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonStampaScheda As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxRiepilogoPolizzeVita As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxRiepilogoSelezionaTutto As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LabelPolizzeAutoCliente As System.Windows.Forms.Label
    Friend WithEvents LabelNumeroFamiliari As System.Windows.Forms.Label
    Friend WithEvents LabelPolizzeAutoFamiliari As System.Windows.Forms.Label
    Friend WithEvents LabelPolizzeRECliente As System.Windows.Forms.Label
    Friend WithEvents LabelPolizzeVitaCliente As System.Windows.Forms.Label
    Friend WithEvents LabelArretratiCliente As System.Windows.Forms.Label
    Friend WithEvents LabelSinistriCliente As System.Windows.Forms.Label
    Friend WithEvents LabelAvvisiNumero As System.Windows.Forms.Label
    Friend WithEvents LabelPolizzeREFamiliari As System.Windows.Forms.Label
    Friend WithEvents LabelPolizzeVitaFamiliari As System.Windows.Forms.Label
    Friend WithEvents LabelIncassiFamiliari As System.Windows.Forms.Label
    Friend WithEvents LabelArretratiFamiliari As System.Windows.Forms.Label
    Friend WithEvents LabelSinistriFamiliari As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents LabelIncassiCliente As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonStampaCopertina As System.Windows.Forms.Button
    Friend WithEvents CheckBoxCopertinaA3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCopertinaCliente As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCopertinaSituazione As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCopertinaNote As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCopertinaFasiVendita As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCopertinaAnalisiRca As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCopertinaTutto As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LabelPolizzeAutoEnti As System.Windows.Forms.Label
    Friend WithEvents LabelPolizzeREEnti As System.Windows.Forms.Label
    Friend WithEvents LabelPolizzeVitaEnti As System.Windows.Forms.Label
    Friend WithEvents LabelIncassiEnti As System.Windows.Forms.Label
    Friend WithEvents LabelArretratiEnti As System.Windows.Forms.Label
    Friend WithEvents LabelSinistriEnti As System.Windows.Forms.Label
    Friend WithEvents LabelNumeroEnti As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ButtonEstrattoConto As System.Windows.Forms.Button
    Friend WithEvents dgvTelefonate As Windows.Forms.DataGridView
    Friend WithEvents Label12 As Windows.Forms.Label
End Class
