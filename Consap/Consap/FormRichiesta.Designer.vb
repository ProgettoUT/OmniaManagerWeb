<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRichiesta
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
        Me.GroupBoxSinistro = New System.Windows.Forms.GroupBox()
        Me.tlpSinistro = New System.Windows.Forms.TableLayoutPanel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTargaResponsabile = New System.Windows.Forms.TextBox()
        Me.txtDataSinistro = New System.Windows.Forms.TextBox()
        Me.txtTargaControparte = New System.Windows.Forms.TextBox()
        Me.txtCompagnia = New System.Windows.Forms.TextBox()
        Me.txtCompControparte = New System.Windows.Forms.TextBox()
        Me.GroupBoxDelega = New System.Windows.Forms.GroupBox()
        Me.tlpDelega = New System.Windows.Forms.TableLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDRagioneSociale = New System.Windows.Forms.TextBox()
        Me.txtDIndirizzo = New System.Windows.Forms.TextBox()
        Me.txtDCap = New System.Windows.Forms.TextBox()
        Me.txtDCitta = New System.Windows.Forms.TextBox()
        Me.txtDProvincia = New System.Windows.Forms.TextBox()
        Me.txtDCF = New System.Windows.Forms.TextBox()
        Me.txtDTelefono = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtDEmail = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.ButtonSalvaDelegato = New System.Windows.Forms.Button()
        Me.GroupBoxTipo = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.rbNormale = New System.Windows.Forms.RadioButton()
        Me.rbDelega = New System.Windows.Forms.RadioButton()
        Me.GroupBoxCliente = New System.Windows.Forms.GroupBox()
        Me.tlpCliente = New System.Windows.Forms.TableLayoutPanel()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.txtIndirizzo = New System.Windows.Forms.TextBox()
        Me.txtCAP = New System.Windows.Forms.TextBox()
        Me.txtCitta = New System.Windows.Forms.TextBox()
        Me.txtProvincia = New System.Windows.Forms.TextBox()
        Me.txtTipoDoc = New System.Windows.Forms.TextBox()
        Me.txtNumeroDoc = New System.Windows.Forms.TextBox()
        Me.txtRilascioDoc = New System.Windows.Forms.TextBox()
        Me.txtScadenzaDoc = New System.Windows.Forms.TextBox()
        Me.txtCF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ButtonStampa = New System.Windows.Forms.Button()
        Me.ButtonRichiestaSito = New System.Windows.Forms.Button()
        Me.tlpMain.SuspendLayout()
        Me.GroupBoxSinistro.SuspendLayout()
        Me.tlpSinistro.SuspendLayout()
        Me.GroupBoxDelega.SuspendLayout()
        Me.tlpDelega.SuspendLayout()
        Me.GroupBoxTipo.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBoxCliente.SuspendLayout()
        Me.tlpCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.Controls.Add(Me.GroupBoxSinistro, 0, 3)
        Me.tlpMain.Controls.Add(Me.GroupBoxDelega, 0, 2)
        Me.tlpMain.Controls.Add(Me.GroupBoxTipo, 0, 0)
        Me.tlpMain.Controls.Add(Me.GroupBoxCliente, 0, 1)
        Me.tlpMain.Controls.Add(Me.ButtonStampa, 0, 4)
        Me.tlpMain.Controls.Add(Me.ButtonRichiestaSito, 1, 4)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 5
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(714, 522)
        Me.tlpMain.TabIndex = 0
        '
        'GroupBoxSinistro
        '
        Me.tlpMain.SetColumnSpan(Me.GroupBoxSinistro, 2)
        Me.GroupBoxSinistro.Controls.Add(Me.tlpSinistro)
        Me.GroupBoxSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxSinistro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBoxSinistro.Location = New System.Drawing.Point(3, 373)
        Me.GroupBoxSinistro.Name = "GroupBoxSinistro"
        Me.GroupBoxSinistro.Size = New System.Drawing.Size(708, 99)
        Me.GroupBoxSinistro.TabIndex = 3
        Me.GroupBoxSinistro.TabStop = False
        Me.GroupBoxSinistro.Text = "Dati sinistro"
        '
        'tlpSinistro
        '
        Me.tlpSinistro.ColumnCount = 4
        Me.tlpSinistro.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpSinistro.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpSinistro.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpSinistro.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpSinistro.Controls.Add(Me.Label17, 0, 0)
        Me.tlpSinistro.Controls.Add(Me.Label18, 0, 1)
        Me.tlpSinistro.Controls.Add(Me.Label19, 0, 2)
        Me.tlpSinistro.Controls.Add(Me.Label20, 2, 0)
        Me.tlpSinistro.Controls.Add(Me.Label21, 2, 1)
        Me.tlpSinistro.Controls.Add(Me.Label22, 2, 2)
        Me.tlpSinistro.Controls.Add(Me.txtTargaResponsabile, 1, 1)
        Me.tlpSinistro.Controls.Add(Me.txtDataSinistro, 1, 0)
        Me.tlpSinistro.Controls.Add(Me.txtTargaControparte, 1, 2)
        Me.tlpSinistro.Controls.Add(Me.txtCompagnia, 3, 0)
        Me.tlpSinistro.Controls.Add(Me.txtCompControparte, 3, 1)
        Me.tlpSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpSinistro.Location = New System.Drawing.Point(3, 18)
        Me.tlpSinistro.Name = "tlpSinistro"
        Me.tlpSinistro.RowCount = 3
        Me.tlpSinistro.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpSinistro.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpSinistro.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpSinistro.Size = New System.Drawing.Size(702, 78)
        Me.tlpSinistro.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label17.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label17.Location = New System.Drawing.Point(3, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(169, 26)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Data sinistro"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label18.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label18.Location = New System.Drawing.Point(3, 26)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(169, 26)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Targa del responsabile"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label19.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label19.Location = New System.Drawing.Point(3, 52)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(169, 26)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "Targa del danneggiato"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label20.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label20.Location = New System.Drawing.Point(353, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(169, 26)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Compagnia del responsabile"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label21.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label21.Location = New System.Drawing.Point(353, 26)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(169, 26)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Compagnia del danneggiato"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label22.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label22.Location = New System.Drawing.Point(353, 52)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(169, 26)
        Me.Label22.TabIndex = 5
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTargaResponsabile
        '
        Me.txtTargaResponsabile.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTargaResponsabile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTargaResponsabile.Location = New System.Drawing.Point(178, 29)
        Me.txtTargaResponsabile.Name = "txtTargaResponsabile"
        Me.txtTargaResponsabile.Size = New System.Drawing.Size(169, 22)
        Me.txtTargaResponsabile.TabIndex = 6
        '
        'txtDataSinistro
        '
        Me.txtDataSinistro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDataSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDataSinistro.Location = New System.Drawing.Point(178, 3)
        Me.txtDataSinistro.Name = "txtDataSinistro"
        Me.txtDataSinistro.Size = New System.Drawing.Size(169, 22)
        Me.txtDataSinistro.TabIndex = 7
        '
        'txtTargaControparte
        '
        Me.txtTargaControparte.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTargaControparte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTargaControparte.Location = New System.Drawing.Point(178, 55)
        Me.txtTargaControparte.Name = "txtTargaControparte"
        Me.txtTargaControparte.Size = New System.Drawing.Size(169, 22)
        Me.txtTargaControparte.TabIndex = 8
        '
        'txtCompagnia
        '
        Me.txtCompagnia.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCompagnia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCompagnia.Location = New System.Drawing.Point(528, 3)
        Me.txtCompagnia.Name = "txtCompagnia"
        Me.txtCompagnia.Size = New System.Drawing.Size(171, 22)
        Me.txtCompagnia.TabIndex = 9
        '
        'txtCompControparte
        '
        Me.txtCompControparte.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCompControparte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCompControparte.Location = New System.Drawing.Point(528, 29)
        Me.txtCompControparte.Name = "txtCompControparte"
        Me.txtCompControparte.Size = New System.Drawing.Size(171, 22)
        Me.txtCompControparte.TabIndex = 10
        '
        'GroupBoxDelega
        '
        Me.tlpMain.SetColumnSpan(Me.GroupBoxDelega, 2)
        Me.GroupBoxDelega.Controls.Add(Me.tlpDelega)
        Me.GroupBoxDelega.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxDelega.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBoxDelega.Location = New System.Drawing.Point(3, 213)
        Me.GroupBoxDelega.Name = "GroupBoxDelega"
        Me.GroupBoxDelega.Size = New System.Drawing.Size(708, 154)
        Me.GroupBoxDelega.TabIndex = 2
        Me.GroupBoxDelega.TabStop = False
        Me.GroupBoxDelega.Text = "Dati del delegato"
        '
        'tlpDelega
        '
        Me.tlpDelega.ColumnCount = 4
        Me.tlpDelega.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpDelega.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpDelega.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpDelega.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpDelega.Controls.Add(Me.Label11, 0, 0)
        Me.tlpDelega.Controls.Add(Me.Label12, 0, 1)
        Me.tlpDelega.Controls.Add(Me.Label13, 0, 2)
        Me.tlpDelega.Controls.Add(Me.Label14, 0, 3)
        Me.tlpDelega.Controls.Add(Me.Label15, 0, 4)
        Me.tlpDelega.Controls.Add(Me.Label16, 2, 0)
        Me.tlpDelega.Controls.Add(Me.txtDRagioneSociale, 1, 0)
        Me.tlpDelega.Controls.Add(Me.txtDIndirizzo, 1, 1)
        Me.tlpDelega.Controls.Add(Me.txtDCap, 1, 2)
        Me.tlpDelega.Controls.Add(Me.txtDCitta, 1, 3)
        Me.tlpDelega.Controls.Add(Me.txtDProvincia, 1, 4)
        Me.tlpDelega.Controls.Add(Me.txtDCF, 3, 0)
        Me.tlpDelega.Controls.Add(Me.txtDTelefono, 3, 1)
        Me.tlpDelega.Controls.Add(Me.Label23, 2, 1)
        Me.tlpDelega.Controls.Add(Me.txtDEmail, 3, 2)
        Me.tlpDelega.Controls.Add(Me.Label24, 2, 2)
        Me.tlpDelega.Controls.Add(Me.ButtonSalvaDelegato, 3, 3)
        Me.tlpDelega.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDelega.Location = New System.Drawing.Point(3, 18)
        Me.tlpDelega.Name = "tlpDelega"
        Me.tlpDelega.RowCount = 5
        Me.tlpDelega.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpDelega.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpDelega.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpDelega.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpDelega.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpDelega.Size = New System.Drawing.Size(702, 133)
        Me.tlpDelega.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label11.Location = New System.Drawing.Point(3, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 26)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Ragione sociale"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label12.Location = New System.Drawing.Point(3, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(134, 26)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Indirizzo"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label13.Location = New System.Drawing.Point(3, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(134, 26)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "CAP"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label14.Location = New System.Drawing.Point(3, 78)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(134, 26)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Città"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label15.Location = New System.Drawing.Point(3, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(134, 29)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Provincia"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label16.Location = New System.Drawing.Point(353, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(134, 26)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "Codice fiscale"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDRagioneSociale
        '
        Me.txtDRagioneSociale.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDRagioneSociale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDRagioneSociale.Location = New System.Drawing.Point(143, 3)
        Me.txtDRagioneSociale.Name = "txtDRagioneSociale"
        Me.txtDRagioneSociale.Size = New System.Drawing.Size(204, 22)
        Me.txtDRagioneSociale.TabIndex = 6
        '
        'txtDIndirizzo
        '
        Me.txtDIndirizzo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDIndirizzo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDIndirizzo.Location = New System.Drawing.Point(143, 29)
        Me.txtDIndirizzo.Name = "txtDIndirizzo"
        Me.txtDIndirizzo.Size = New System.Drawing.Size(204, 22)
        Me.txtDIndirizzo.TabIndex = 7
        '
        'txtDCap
        '
        Me.txtDCap.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDCap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDCap.Location = New System.Drawing.Point(143, 55)
        Me.txtDCap.Name = "txtDCap"
        Me.txtDCap.Size = New System.Drawing.Size(204, 22)
        Me.txtDCap.TabIndex = 8
        '
        'txtDCitta
        '
        Me.txtDCitta.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDCitta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDCitta.Location = New System.Drawing.Point(143, 81)
        Me.txtDCitta.Name = "txtDCitta"
        Me.txtDCitta.Size = New System.Drawing.Size(204, 22)
        Me.txtDCitta.TabIndex = 9
        '
        'txtDProvincia
        '
        Me.txtDProvincia.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDProvincia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDProvincia.Location = New System.Drawing.Point(143, 107)
        Me.txtDProvincia.Name = "txtDProvincia"
        Me.txtDProvincia.Size = New System.Drawing.Size(204, 22)
        Me.txtDProvincia.TabIndex = 10
        '
        'txtDCF
        '
        Me.txtDCF.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDCF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDCF.Location = New System.Drawing.Point(493, 3)
        Me.txtDCF.Name = "txtDCF"
        Me.txtDCF.Size = New System.Drawing.Size(206, 22)
        Me.txtDCF.TabIndex = 11
        '
        'txtDTelefono
        '
        Me.txtDTelefono.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDTelefono.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDTelefono.Location = New System.Drawing.Point(493, 29)
        Me.txtDTelefono.Name = "txtDTelefono"
        Me.txtDTelefono.Size = New System.Drawing.Size(206, 22)
        Me.txtDTelefono.TabIndex = 12
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label23.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label23.Location = New System.Drawing.Point(353, 26)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(134, 26)
        Me.Label23.TabIndex = 13
        Me.Label23.Text = "Telefono"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDEmail
        '
        Me.txtDEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDEmail.Location = New System.Drawing.Point(493, 55)
        Me.txtDEmail.Name = "txtDEmail"
        Me.txtDEmail.Size = New System.Drawing.Size(206, 22)
        Me.txtDEmail.TabIndex = 14
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label24.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label24.Location = New System.Drawing.Point(353, 52)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(134, 26)
        Me.Label24.TabIndex = 15
        Me.Label24.Text = "E-mail"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonSalvaDelegato
        '
        Me.ButtonSalvaDelegato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSalvaDelegato.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonSalvaDelegato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSalvaDelegato.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ButtonSalvaDelegato.Location = New System.Drawing.Point(493, 81)
        Me.ButtonSalvaDelegato.Name = "ButtonSalvaDelegato"
        Me.tlpDelega.SetRowSpan(Me.ButtonSalvaDelegato, 2)
        Me.ButtonSalvaDelegato.Size = New System.Drawing.Size(206, 49)
        Me.ButtonSalvaDelegato.TabIndex = 16
        Me.ButtonSalvaDelegato.Text = "Button1"
        Me.ButtonSalvaDelegato.UseVisualStyleBackColor = True
        '
        'GroupBoxTipo
        '
        Me.tlpMain.SetColumnSpan(Me.GroupBoxTipo, 2)
        Me.GroupBoxTipo.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBoxTipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBoxTipo.Location = New System.Drawing.Point(3, 3)
        Me.GroupBoxTipo.Name = "GroupBoxTipo"
        Me.GroupBoxTipo.Size = New System.Drawing.Size(708, 44)
        Me.GroupBoxTipo.TabIndex = 0
        Me.GroupBoxTipo.TabStop = False
        Me.GroupBoxTipo.Text = "Tipo richiesta"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.rbNormale, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rbDelega, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(702, 23)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'rbNormale
        '
        Me.rbNormale.AutoSize = True
        Me.rbNormale.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbNormale.Location = New System.Drawing.Point(3, 3)
        Me.rbNormale.Name = "rbNormale"
        Me.rbNormale.Size = New System.Drawing.Size(146, 17)
        Me.rbNormale.TabIndex = 0
        Me.rbNormale.TabStop = True
        Me.rbNormale.Text = "Richiesta senza delega"
        Me.rbNormale.UseVisualStyleBackColor = True
        '
        'rbDelega
        '
        Me.rbDelega.AutoSize = True
        Me.rbDelega.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbDelega.Location = New System.Drawing.Point(354, 3)
        Me.rbDelega.Name = "rbDelega"
        Me.rbDelega.Size = New System.Drawing.Size(136, 17)
        Me.rbDelega.TabIndex = 1
        Me.rbDelega.TabStop = True
        Me.rbDelega.Text = "Richiesta con delega"
        Me.rbDelega.UseVisualStyleBackColor = True
        '
        'GroupBoxCliente
        '
        Me.tlpMain.SetColumnSpan(Me.GroupBoxCliente, 2)
        Me.GroupBoxCliente.Controls.Add(Me.tlpCliente)
        Me.GroupBoxCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBoxCliente.Location = New System.Drawing.Point(3, 53)
        Me.GroupBoxCliente.Name = "GroupBoxCliente"
        Me.GroupBoxCliente.Size = New System.Drawing.Size(708, 154)
        Me.GroupBoxCliente.TabIndex = 1
        Me.GroupBoxCliente.TabStop = False
        Me.GroupBoxCliente.Text = "Assicurato"
        '
        'tlpCliente
        '
        Me.tlpCliente.ColumnCount = 4
        Me.tlpCliente.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpCliente.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpCliente.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpCliente.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpCliente.Controls.Add(Me.txtNome, 1, 0)
        Me.tlpCliente.Controls.Add(Me.txtIndirizzo, 1, 1)
        Me.tlpCliente.Controls.Add(Me.txtCAP, 1, 2)
        Me.tlpCliente.Controls.Add(Me.txtCitta, 1, 3)
        Me.tlpCliente.Controls.Add(Me.txtProvincia, 1, 4)
        Me.tlpCliente.Controls.Add(Me.txtTipoDoc, 3, 0)
        Me.tlpCliente.Controls.Add(Me.txtNumeroDoc, 3, 1)
        Me.tlpCliente.Controls.Add(Me.txtRilascioDoc, 3, 2)
        Me.tlpCliente.Controls.Add(Me.txtScadenzaDoc, 3, 3)
        Me.tlpCliente.Controls.Add(Me.txtCF, 3, 4)
        Me.tlpCliente.Controls.Add(Me.Label1, 0, 0)
        Me.tlpCliente.Controls.Add(Me.Label2, 0, 1)
        Me.tlpCliente.Controls.Add(Me.Label3, 0, 2)
        Me.tlpCliente.Controls.Add(Me.Label4, 0, 3)
        Me.tlpCliente.Controls.Add(Me.Label5, 0, 4)
        Me.tlpCliente.Controls.Add(Me.Label6, 2, 0)
        Me.tlpCliente.Controls.Add(Me.Label7, 2, 1)
        Me.tlpCliente.Controls.Add(Me.Label8, 2, 2)
        Me.tlpCliente.Controls.Add(Me.Label9, 2, 3)
        Me.tlpCliente.Controls.Add(Me.Label10, 2, 4)
        Me.tlpCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tlpCliente.Location = New System.Drawing.Point(3, 18)
        Me.tlpCliente.Name = "tlpCliente"
        Me.tlpCliente.RowCount = 5
        Me.tlpCliente.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpCliente.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpCliente.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpCliente.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpCliente.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpCliente.Size = New System.Drawing.Size(702, 133)
        Me.tlpCliente.TabIndex = 0
        '
        'txtNome
        '
        Me.txtNome.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNome.Location = New System.Drawing.Point(143, 3)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(204, 22)
        Me.txtNome.TabIndex = 0
        '
        'txtIndirizzo
        '
        Me.txtIndirizzo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtIndirizzo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIndirizzo.Location = New System.Drawing.Point(143, 29)
        Me.txtIndirizzo.Name = "txtIndirizzo"
        Me.txtIndirizzo.Size = New System.Drawing.Size(204, 22)
        Me.txtIndirizzo.TabIndex = 1
        '
        'txtCAP
        '
        Me.txtCAP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCAP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCAP.Location = New System.Drawing.Point(143, 55)
        Me.txtCAP.Name = "txtCAP"
        Me.txtCAP.Size = New System.Drawing.Size(204, 22)
        Me.txtCAP.TabIndex = 2
        '
        'txtCitta
        '
        Me.txtCitta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCitta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCitta.Location = New System.Drawing.Point(143, 81)
        Me.txtCitta.Name = "txtCitta"
        Me.txtCitta.Size = New System.Drawing.Size(204, 22)
        Me.txtCitta.TabIndex = 3
        '
        'txtProvincia
        '
        Me.txtProvincia.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtProvincia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProvincia.Location = New System.Drawing.Point(143, 107)
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.Size = New System.Drawing.Size(204, 22)
        Me.txtProvincia.TabIndex = 4
        '
        'txtTipoDoc
        '
        Me.txtTipoDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTipoDoc.Location = New System.Drawing.Point(493, 3)
        Me.txtTipoDoc.Name = "txtTipoDoc"
        Me.txtTipoDoc.Size = New System.Drawing.Size(206, 22)
        Me.txtTipoDoc.TabIndex = 5
        '
        'txtNumeroDoc
        '
        Me.txtNumeroDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNumeroDoc.Location = New System.Drawing.Point(493, 29)
        Me.txtNumeroDoc.Name = "txtNumeroDoc"
        Me.txtNumeroDoc.Size = New System.Drawing.Size(206, 22)
        Me.txtNumeroDoc.TabIndex = 6
        '
        'txtRilascioDoc
        '
        Me.txtRilascioDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRilascioDoc.Location = New System.Drawing.Point(493, 55)
        Me.txtRilascioDoc.Name = "txtRilascioDoc"
        Me.txtRilascioDoc.Size = New System.Drawing.Size(206, 22)
        Me.txtRilascioDoc.TabIndex = 7
        '
        'txtScadenzaDoc
        '
        Me.txtScadenzaDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtScadenzaDoc.Location = New System.Drawing.Point(493, 81)
        Me.txtScadenzaDoc.Name = "txtScadenzaDoc"
        Me.txtScadenzaDoc.Size = New System.Drawing.Size(206, 22)
        Me.txtScadenzaDoc.TabIndex = 8
        '
        'txtCF
        '
        Me.txtCF.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCF.Location = New System.Drawing.Point(493, 107)
        Me.txtCF.Name = "txtCF"
        Me.txtCF.Size = New System.Drawing.Size(206, 22)
        Me.txtCF.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 26)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Cognome e Nome"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(3, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 26)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Residente in"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(3, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 26)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "CAP"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(3, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 26)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Città"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(3, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 29)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Provincia"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label6.Location = New System.Drawing.Point(353, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 26)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Tipo documento"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.Location = New System.Drawing.Point(353, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 26)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Numero documento"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label8.Location = New System.Drawing.Point(353, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(134, 26)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Rilasciato da"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label9.Location = New System.Drawing.Point(353, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 26)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Scadenza documento"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label10.Location = New System.Drawing.Point(353, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 29)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Codice fiscale"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonStampa
        '
        Me.ButtonStampa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonStampa.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonStampa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStampa.Location = New System.Drawing.Point(3, 478)
        Me.ButtonStampa.Name = "ButtonStampa"
        Me.ButtonStampa.Size = New System.Drawing.Size(351, 41)
        Me.ButtonStampa.TabIndex = 4
        Me.ButtonStampa.Text = "Stampa richiesta/delega"
        Me.ButtonStampa.UseVisualStyleBackColor = True
        '
        'ButtonRichiestaSito
        '
        Me.ButtonRichiestaSito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonRichiestaSito.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonRichiestaSito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRichiestaSito.Location = New System.Drawing.Point(360, 478)
        Me.ButtonRichiestaSito.Name = "ButtonRichiestaSito"
        Me.ButtonRichiestaSito.Size = New System.Drawing.Size(351, 41)
        Me.ButtonRichiestaSito.TabIndex = 5
        Me.ButtonRichiestaSito.Text = "Crea richiesta sul sito CONSAP"
        Me.ButtonRichiestaSito.UseVisualStyleBackColor = True
        '
        'FormRichiesta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 522)
        Me.Controls.Add(Me.tlpMain)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "FormRichiesta"
        Me.Text = "FormRichiesta"
        Me.tlpMain.ResumeLayout(False)
        Me.GroupBoxSinistro.ResumeLayout(False)
        Me.tlpSinistro.ResumeLayout(False)
        Me.tlpSinistro.PerformLayout()
        Me.GroupBoxDelega.ResumeLayout(False)
        Me.tlpDelega.ResumeLayout(False)
        Me.tlpDelega.PerformLayout()
        Me.GroupBoxTipo.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.GroupBoxCliente.ResumeLayout(False)
        Me.tlpCliente.ResumeLayout(False)
        Me.tlpCliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBoxSinistro As System.Windows.Forms.GroupBox
    Friend WithEvents tlpSinistro As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBoxDelega As System.Windows.Forms.GroupBox
    Friend WithEvents tlpDelega As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBoxTipo As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbNormale As System.Windows.Forms.RadioButton
    Friend WithEvents rbDelega As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBoxCliente As System.Windows.Forms.GroupBox
    Friend WithEvents tlpCliente As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents txtIndirizzo As System.Windows.Forms.TextBox
    Friend WithEvents txtCAP As System.Windows.Forms.TextBox
    Friend WithEvents txtCitta As System.Windows.Forms.TextBox
    Friend WithEvents txtProvincia As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtRilascioDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtScadenzaDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtCF As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ButtonStampa As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTargaResponsabile As System.Windows.Forms.TextBox
    Friend WithEvents txtDataSinistro As System.Windows.Forms.TextBox
    Friend WithEvents txtTargaControparte As System.Windows.Forms.TextBox
    Friend WithEvents txtCompagnia As System.Windows.Forms.TextBox
    Friend WithEvents txtCompControparte As System.Windows.Forms.TextBox
    Friend WithEvents txtDRagioneSociale As System.Windows.Forms.TextBox
    Friend WithEvents txtDIndirizzo As System.Windows.Forms.TextBox
    Friend WithEvents txtDCap As System.Windows.Forms.TextBox
    Friend WithEvents txtDCitta As System.Windows.Forms.TextBox
    Friend WithEvents txtDProvincia As System.Windows.Forms.TextBox
    Friend WithEvents txtDCF As System.Windows.Forms.TextBox
    Friend WithEvents ButtonRichiestaSito As System.Windows.Forms.Button
    Friend WithEvents txtDTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtDEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ButtonSalvaDelegato As System.Windows.Forms.Button
End Class
