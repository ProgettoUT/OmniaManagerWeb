<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVersamento
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
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCancellaAssegni = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt500Tot = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txt500 = New System.Windows.Forms.TextBox()
        Me.txt200 = New System.Windows.Forms.TextBox()
        Me.txt100 = New System.Windows.Forms.TextBox()
        Me.btnAggiornaAssegni = New System.Windows.Forms.Button()
        Me.txt200Tot = New System.Windows.Forms.TextBox()
        Me.txt100Tot = New System.Windows.Forms.TextBox()
        Me.txtTotaleCassetto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt50 = New System.Windows.Forms.TextBox()
        Me.txt20 = New System.Windows.Forms.TextBox()
        Me.txt10 = New System.Windows.Forms.TextBox()
        Me.txt5 = New System.Windows.Forms.TextBox()
        Me.txtAssegno = New System.Windows.Forms.TextBox()
        Me.txt50Tot = New System.Windows.Forms.TextBox()
        Me.txt20Tot = New System.Windows.Forms.TextBox()
        Me.txt10Tot = New System.Windows.Forms.TextBox()
        Me.txt5Tot = New System.Windows.Forms.TextBox()
        Me.txtMonetaTot = New System.Windows.Forms.TextBox()
        Me.txtNumeroAssegni = New System.Windows.Forms.TextBox()
        Me.cboAssegnoTot = New System.Windows.Forms.ComboBox()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDeskMovimento = New System.Windows.Forms.TextBox()
        Me.btnStampa = New System.Windows.Forms.Button()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.cboDeskBanca = New System.Windows.Forms.ComboBox()
        Me.cboConto = New System.Windows.Forms.ComboBox()
        Me.cboPuntoVendita = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnCancellaAssegni, 5, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label14, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label15, 2, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label16, 2, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Label17, 2, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Label18, 2, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.Label19, 2, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.Label20, 2, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.txt500Tot, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label21, 2, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.Label22, 2, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.Label23, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label24, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txt500, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txt200, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.txt100, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAggiornaAssegni, 1, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.txt200Tot, 3, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.txt100Tot, 3, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTotaleCassetto, 3, 12)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 2, 12)
        Me.TableLayoutPanel2.Controls.Add(Me.txt50, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.txt20, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.txt10, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.txt5, 0, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.txtAssegno, 0, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.txt50Tot, 3, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.txt20Tot, 3, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.txt10Tot, 3, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.txt5Tot, 3, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.txtMonetaTot, 3, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.txtNumeroAssegni, 4, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.cboAssegnoTot, 3, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.btnSalva, 4, 14)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 14)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDeskMovimento, 0, 15)
        Me.TableLayoutPanel2.Controls.Add(Me.btnStampa, 0, 16)
        Me.TableLayoutPanel2.Controls.Add(Me.btnEsci, 4, 16)
        Me.TableLayoutPanel2.Controls.Add(Me.cboDeskBanca, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cboConto, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cboPuntoVendita, 0, 1)
        Me.TableLayoutPanel2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 18
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.732484!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.307856!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(537, 471)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Gold
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label8, 6)
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(531, 26)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Versamento in banca"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancellaAssegni
        '
        Me.btnCancellaAssegni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancellaAssegni.Location = New System.Drawing.Point(442, 289)
        Me.btnCancellaAssegni.Name = "btnCancellaAssegni"
        Me.btnCancellaAssegni.Size = New System.Drawing.Size(92, 20)
        Me.btnCancellaAssegni.TabIndex = 0
        Me.btnCancellaAssegni.TabStop = False
        Me.btnCancellaAssegni.Text = "Cancella"
        Me.btnCancellaAssegni.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Violet
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(134, 78)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(132, 26)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "x 500"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(134, 52)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(132, 26)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Taglio banconote"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(134, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(132, 26)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "x 200"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.YellowGreen
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(134, 130)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(132, 26)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "x 100"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Gold
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(134, 156)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(132, 26)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "x 50"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.SkyBlue
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(134, 182)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(132, 26)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "x 20"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.LightSalmon
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(134, 208)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(132, 26)
        Me.Label19.TabIndex = 9
        Me.Label19.Text = "x 10"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Lavender
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(134, 234)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(132, 26)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "x 5"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt500Tot
        '
        Me.txt500Tot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt500Tot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt500Tot.Location = New System.Drawing.Point(272, 81)
        Me.txt500Tot.Name = "txt500Tot"
        Me.txt500Tot.Size = New System.Drawing.Size(104, 22)
        Me.txt500Tot.TabIndex = 5
        Me.txt500Tot.TabStop = False
        Me.txt500Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.LightGray
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(134, 260)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(132, 26)
        Me.Label21.TabIndex = 12
        Me.Label21.Text = "Moneta"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Khaki
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(134, 286)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(132, 26)
        Me.Label22.TabIndex = 13
        Me.Label22.Text = "Assegni"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label23.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(272, 52)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(104, 26)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Importo totale"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label24, 2)
        Me.Label24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(3, 52)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(125, 26)
        Me.Label24.TabIndex = 15
        Me.Label24.Text = "Quantità"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt500
        '
        Me.txt500.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt500.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt500.Location = New System.Drawing.Point(3, 81)
        Me.txt500.Name = "txt500"
        Me.txt500.Size = New System.Drawing.Size(76, 22)
        Me.txt500.TabIndex = 3
        Me.txt500.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt200
        '
        Me.txt200.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt200.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt200.Location = New System.Drawing.Point(3, 107)
        Me.txt200.Name = "txt200"
        Me.txt200.Size = New System.Drawing.Size(76, 22)
        Me.txt200.TabIndex = 4
        Me.txt200.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt100
        '
        Me.txt100.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt100.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt100.Location = New System.Drawing.Point(3, 133)
        Me.txt100.Name = "txt100"
        Me.txt100.Size = New System.Drawing.Size(76, 22)
        Me.txt100.TabIndex = 5
        Me.txt100.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAggiornaAssegni
        '
        Me.btnAggiornaAssegni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAggiornaAssegni.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAggiornaAssegni.Location = New System.Drawing.Point(85, 289)
        Me.btnAggiornaAssegni.Name = "btnAggiornaAssegni"
        Me.btnAggiornaAssegni.Size = New System.Drawing.Size(43, 20)
        Me.btnAggiornaAssegni.TabIndex = 17
        Me.btnAggiornaAssegni.TabStop = False
        Me.btnAggiornaAssegni.Text = "+"
        Me.btnAggiornaAssegni.UseVisualStyleBackColor = True
        '
        'txt200Tot
        '
        Me.txt200Tot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt200Tot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt200Tot.Location = New System.Drawing.Point(272, 107)
        Me.txt200Tot.Name = "txt200Tot"
        Me.txt200Tot.Size = New System.Drawing.Size(104, 22)
        Me.txt200Tot.TabIndex = 18
        Me.txt200Tot.TabStop = False
        Me.txt200Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt100Tot
        '
        Me.txt100Tot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt100Tot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt100Tot.Location = New System.Drawing.Point(272, 133)
        Me.txt100Tot.Name = "txt100Tot"
        Me.txt100Tot.Size = New System.Drawing.Size(104, 22)
        Me.txt100Tot.TabIndex = 19
        Me.txt100Tot.TabStop = False
        Me.txt100Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotaleCassetto
        '
        Me.txtTotaleCassetto.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotaleCassetto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTotaleCassetto.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotaleCassetto.Location = New System.Drawing.Point(272, 315)
        Me.txtTotaleCassetto.Name = "txtTotaleCassetto"
        Me.txtTotaleCassetto.Size = New System.Drawing.Size(104, 22)
        Me.txtTotaleCassetto.TabIndex = 20
        Me.txtTotaleCassetto.TabStop = False
        Me.txtTotaleCassetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Firebrick
        Me.Label1.Location = New System.Drawing.Point(134, 312)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 26)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Totale versamento"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt50
        '
        Me.txt50.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt50.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt50.Location = New System.Drawing.Point(3, 159)
        Me.txt50.Name = "txt50"
        Me.txt50.Size = New System.Drawing.Size(76, 22)
        Me.txt50.TabIndex = 6
        Me.txt50.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt20
        '
        Me.txt20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt20.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt20.Location = New System.Drawing.Point(3, 185)
        Me.txt20.Name = "txt20"
        Me.txt20.Size = New System.Drawing.Size(76, 22)
        Me.txt20.TabIndex = 7
        Me.txt20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt10
        '
        Me.txt10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt10.Location = New System.Drawing.Point(3, 211)
        Me.txt10.Name = "txt10"
        Me.txt10.Size = New System.Drawing.Size(76, 22)
        Me.txt10.TabIndex = 8
        Me.txt10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt5
        '
        Me.txt5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt5.Location = New System.Drawing.Point(3, 237)
        Me.txt5.Name = "txt5"
        Me.txt5.Size = New System.Drawing.Size(76, 22)
        Me.txt5.TabIndex = 9
        Me.txt5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAssegno
        '
        Me.txtAssegno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAssegno.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssegno.Location = New System.Drawing.Point(3, 289)
        Me.txtAssegno.Name = "txtAssegno"
        Me.txtAssegno.Size = New System.Drawing.Size(76, 22)
        Me.txtAssegno.TabIndex = 11
        Me.txtAssegno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt50Tot
        '
        Me.txt50Tot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt50Tot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt50Tot.Location = New System.Drawing.Point(272, 159)
        Me.txt50Tot.Name = "txt50Tot"
        Me.txt50Tot.Size = New System.Drawing.Size(104, 22)
        Me.txt50Tot.TabIndex = 27
        Me.txt50Tot.TabStop = False
        Me.txt50Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt20Tot
        '
        Me.txt20Tot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt20Tot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt20Tot.Location = New System.Drawing.Point(272, 185)
        Me.txt20Tot.Name = "txt20Tot"
        Me.txt20Tot.Size = New System.Drawing.Size(104, 22)
        Me.txt20Tot.TabIndex = 28
        Me.txt20Tot.TabStop = False
        Me.txt20Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt10Tot
        '
        Me.txt10Tot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt10Tot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt10Tot.Location = New System.Drawing.Point(272, 211)
        Me.txt10Tot.Name = "txt10Tot"
        Me.txt10Tot.Size = New System.Drawing.Size(104, 22)
        Me.txt10Tot.TabIndex = 29
        Me.txt10Tot.TabStop = False
        Me.txt10Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt5Tot
        '
        Me.txt5Tot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt5Tot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt5Tot.Location = New System.Drawing.Point(272, 237)
        Me.txt5Tot.Name = "txt5Tot"
        Me.txt5Tot.Size = New System.Drawing.Size(104, 22)
        Me.txt5Tot.TabIndex = 30
        Me.txt5Tot.TabStop = False
        Me.txt5Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMonetaTot
        '
        Me.txtMonetaTot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMonetaTot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonetaTot.Location = New System.Drawing.Point(272, 263)
        Me.txtMonetaTot.Name = "txtMonetaTot"
        Me.txtMonetaTot.Size = New System.Drawing.Size(104, 22)
        Me.txtMonetaTot.TabIndex = 10
        Me.txtMonetaTot.TabStop = False
        Me.txtMonetaTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumeroAssegni
        '
        Me.txtNumeroAssegni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNumeroAssegni.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroAssegni.Location = New System.Drawing.Point(382, 289)
        Me.txtNumeroAssegni.Name = "txtNumeroAssegni"
        Me.txtNumeroAssegni.Size = New System.Drawing.Size(54, 22)
        Me.txtNumeroAssegni.TabIndex = 33
        Me.txtNumeroAssegni.TabStop = False
        Me.txtNumeroAssegni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboAssegnoTot
        '
        Me.cboAssegnoTot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboAssegnoTot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAssegnoTot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAssegnoTot.FormattingEnabled = True
        Me.cboAssegnoTot.Location = New System.Drawing.Point(272, 289)
        Me.cboAssegnoTot.Name = "cboAssegnoTot"
        Me.cboAssegnoTot.Size = New System.Drawing.Size(104, 22)
        Me.cboAssegnoTot.TabIndex = 34
        Me.cboAssegnoTot.TabStop = False
        '
        'btnSalva
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.btnSalva, 2)
        Me.btnSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSalva.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalva.Location = New System.Drawing.Point(382, 367)
        Me.btnSalva.Name = "btnSalva"
        Me.TableLayoutPanel2.SetRowSpan(Me.btnSalva, 2)
        Me.btnSalva.Size = New System.Drawing.Size(152, 47)
        Me.btnSalva.TabIndex = 14
        Me.btnSalva.Text = "Salva"
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label7, 4)
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 364)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(373, 26)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Eventuale descrizione (max 40 caratteri)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDeskMovimento
        '
        Me.txtDeskMovimento.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtDeskMovimento, 4)
        Me.txtDeskMovimento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDeskMovimento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeskMovimento.Location = New System.Drawing.Point(3, 393)
        Me.txtDeskMovimento.MaxLength = 40
        Me.txtDeskMovimento.Name = "txtDeskMovimento"
        Me.txtDeskMovimento.Size = New System.Drawing.Size(373, 22)
        Me.txtDeskMovimento.TabIndex = 12
        '
        'btnStampa
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.btnStampa, 4)
        Me.btnStampa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnStampa.Location = New System.Drawing.Point(3, 420)
        Me.btnStampa.Name = "btnStampa"
        Me.TableLayoutPanel2.SetRowSpan(Me.btnStampa, 2)
        Me.btnStampa.Size = New System.Drawing.Size(373, 48)
        Me.btnStampa.TabIndex = 13
        Me.btnStampa.Text = "Stampa la distinta di versamento"
        Me.btnStampa.UseVisualStyleBackColor = True
        '
        'btnEsci
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.btnEsci, 2)
        Me.btnEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsci.Location = New System.Drawing.Point(382, 420)
        Me.btnEsci.Name = "btnEsci"
        Me.TableLayoutPanel2.SetRowSpan(Me.btnEsci, 2)
        Me.btnEsci.Size = New System.Drawing.Size(152, 48)
        Me.btnEsci.TabIndex = 15
        Me.btnEsci.Text = "Esci"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'cboDeskBanca
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.cboDeskBanca, 2)
        Me.cboDeskBanca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDeskBanca.FormattingEnabled = True
        Me.cboDeskBanca.Location = New System.Drawing.Point(134, 29)
        Me.cboDeskBanca.Name = "cboDeskBanca"
        Me.cboDeskBanca.Size = New System.Drawing.Size(242, 22)
        Me.cboDeskBanca.TabIndex = 1
        '
        'cboConto
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.cboConto, 2)
        Me.cboConto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboConto.FormattingEnabled = True
        Me.cboConto.Location = New System.Drawing.Point(382, 29)
        Me.cboConto.Name = "cboConto"
        Me.cboConto.Size = New System.Drawing.Size(152, 22)
        Me.cboConto.TabIndex = 2
        '
        'cboPuntoVendita
        '
        Me.cboPuntoVendita.BackColor = System.Drawing.Color.Yellow
        Me.TableLayoutPanel2.SetColumnSpan(Me.cboPuntoVendita, 2)
        Me.cboPuntoVendita.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPuntoVendita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPuntoVendita.FormattingEnabled = True
        Me.cboPuntoVendita.Location = New System.Drawing.Point(3, 29)
        Me.cboPuntoVendita.Name = "cboPuntoVendita"
        Me.cboPuntoVendita.Size = New System.Drawing.Size(125, 22)
        Me.cboPuntoVendita.TabIndex = 0
        '
        'frmVersamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 495)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "frmVersamento"
        Me.Text = "frmVersamento"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCancellaAssegni As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt500Tot As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt500 As System.Windows.Forms.TextBox
    Friend WithEvents txt200 As System.Windows.Forms.TextBox
    Friend WithEvents txt100 As System.Windows.Forms.TextBox
    Friend WithEvents btnAggiornaAssegni As System.Windows.Forms.Button
    Friend WithEvents txt200Tot As System.Windows.Forms.TextBox
    Friend WithEvents txt100Tot As System.Windows.Forms.TextBox
    Friend WithEvents txtTotaleCassetto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt50 As System.Windows.Forms.TextBox
    Friend WithEvents txt20 As System.Windows.Forms.TextBox
    Friend WithEvents txt10 As System.Windows.Forms.TextBox
    Friend WithEvents txt5 As System.Windows.Forms.TextBox
    Friend WithEvents txtAssegno As System.Windows.Forms.TextBox
    Friend WithEvents txt50Tot As System.Windows.Forms.TextBox
    Friend WithEvents txt20Tot As System.Windows.Forms.TextBox
    Friend WithEvents txt10Tot As System.Windows.Forms.TextBox
    Friend WithEvents txt5Tot As System.Windows.Forms.TextBox
    Friend WithEvents txtMonetaTot As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroAssegni As System.Windows.Forms.TextBox
    Friend WithEvents cboAssegnoTot As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDeskMovimento As System.Windows.Forms.TextBox
    Friend WithEvents btnSalva As System.Windows.Forms.Button
    Friend WithEvents btnStampa As System.Windows.Forms.Button
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents cboConto As System.Windows.Forms.ComboBox
    Friend WithEvents cboDeskBanca As System.Windows.Forms.ComboBox
    Friend WithEvents cboPuntoVendita As System.Windows.Forms.ComboBox
End Class
