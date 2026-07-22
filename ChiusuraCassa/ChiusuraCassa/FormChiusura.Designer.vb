<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormChiusura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormChiusura))
        Me.TabCassa = New System.Windows.Forms.TabControl()
        Me.TabElenco = New System.Windows.Forms.TabPage()
        Me.TabTotali = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbTipoPagamento = New System.Windows.Forms.Label()
        Me.lbTotali = New System.Windows.Forms.Label()
        Me.lbDettaglio = New System.Windows.Forms.Label()
        Me.TabQuadrature = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.txtTotaleTitoli = New System.Windows.Forms.TextBox()
        Me.txtQuadratura = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbPv = New System.Windows.Forms.Label()
        Me.btnAmmanco = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSalvaQuadratura = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnConsolida = New System.Windows.Forms.Button()
        Me.btnAbbuono = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAbbuoni = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.PictureBox500 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox200 = New System.Windows.Forms.PictureBox()
        Me.PictureBox100 = New System.Windows.Forms.PictureBox()
        Me.PictureBox50 = New System.Windows.Forms.PictureBox()
        Me.PictureBox20 = New System.Windows.Forms.PictureBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.PictureBoxMonete = New System.Windows.Forms.PictureBox()
        Me.TabCO = New System.Windows.Forms.TabPage()
        Me.TabStat = New System.Windows.Forms.TabPage()
        Me.TabHelp = New System.Windows.Forms.TabPage()
        Me.wbHelp = New System.Windows.Forms.WebBrowser()
        Me.tsMain = New System.Windows.Forms.ToolStrip()
        Me.btnGestioneCodici = New System.Windows.Forms.ToolStripButton()
        Me.btnVersamento = New System.Windows.Forms.ToolStripSplitButton()
        Me.VersamentoInBancaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VersamentoDaSubagenziaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.InserimentoRiportoManualeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovimentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnScan = New System.Windows.Forms.ToolStripSplitButton()
        Me.VisualizzaAssegniDelGiornoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.btnAggiorna = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lbSelezionati = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbSomma = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbMedia = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.lbProgress = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbEntrate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbUscite = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbSaldo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabCassa.SuspendLayout()
        Me.TabTotali.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabQuadrature.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PictureBox500, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox200, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox100, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxMonete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabHelp.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabCassa
        '
        Me.TabCassa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabCassa.Controls.Add(Me.TabElenco)
        Me.TabCassa.Controls.Add(Me.TabTotali)
        Me.TabCassa.Controls.Add(Me.TabQuadrature)
        Me.TabCassa.Controls.Add(Me.TabCO)
        Me.TabCassa.Controls.Add(Me.TabStat)
        Me.TabCassa.Controls.Add(Me.TabHelp)
        Me.TabCassa.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabCassa.Location = New System.Drawing.Point(0, 53)
        Me.TabCassa.Name = "TabCassa"
        Me.TabCassa.SelectedIndex = 0
        Me.TabCassa.Size = New System.Drawing.Size(1123, 626)
        Me.TabCassa.TabIndex = 0
        '
        'TabElenco
        '
        Me.TabElenco.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabElenco.Location = New System.Drawing.Point(4, 25)
        Me.TabElenco.Name = "TabElenco"
        Me.TabElenco.Padding = New System.Windows.Forms.Padding(3)
        Me.TabElenco.Size = New System.Drawing.Size(1115, 597)
        Me.TabElenco.TabIndex = 0
        Me.TabElenco.Text = "TabElenco"
        Me.TabElenco.UseVisualStyleBackColor = True
        '
        'TabTotali
        '
        Me.TabTotali.Controls.Add(Me.TableLayoutPanel1)
        Me.TabTotali.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabTotali.Location = New System.Drawing.Point(4, 25)
        Me.TabTotali.Name = "TabTotali"
        Me.TabTotali.Padding = New System.Windows.Forms.Padding(3)
        Me.TabTotali.Size = New System.Drawing.Size(1115, 597)
        Me.TabTotali.TabIndex = 1
        Me.TabTotali.Text = "TabTotali"
        Me.TabTotali.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbTipoPagamento, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbTotali, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbDettaglio, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.5858!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.4142!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1109, 591)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'lbTipoPagamento
        '
        Me.lbTipoPagamento.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbTipoPagamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbTipoPagamento, 2)
        Me.lbTipoPagamento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbTipoPagamento.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipoPagamento.ForeColor = System.Drawing.Color.Firebrick
        Me.lbTipoPagamento.Location = New System.Drawing.Point(3, 185)
        Me.lbTipoPagamento.Name = "lbTipoPagamento"
        Me.lbTipoPagamento.Size = New System.Drawing.Size(1103, 25)
        Me.lbTipoPagamento.TabIndex = 5
        Me.lbTipoPagamento.Text = "Dettaglio per tipo pagamento"
        Me.lbTipoPagamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTotali
        '
        Me.lbTotali.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbTotali.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbTotali.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbTotali.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotali.ForeColor = System.Drawing.Color.Firebrick
        Me.lbTotali.Location = New System.Drawing.Point(3, 0)
        Me.lbTotali.Name = "lbTotali"
        Me.lbTotali.Size = New System.Drawing.Size(548, 25)
        Me.lbTotali.TabIndex = 3
        Me.lbTotali.Text = "A. Totali per sezione"
        Me.lbTotali.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbDettaglio
        '
        Me.lbDettaglio.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbDettaglio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbDettaglio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbDettaglio.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDettaglio.ForeColor = System.Drawing.Color.Firebrick
        Me.lbDettaglio.Location = New System.Drawing.Point(557, 0)
        Me.lbDettaglio.Name = "lbDettaglio"
        Me.lbDettaglio.Size = New System.Drawing.Size(549, 25)
        Me.lbDettaglio.TabIndex = 2
        Me.lbDettaglio.Text = "Label13"
        Me.lbDettaglio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabQuadrature
        '
        Me.TabQuadrature.Controls.Add(Me.SplitContainer1)
        Me.TabQuadrature.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabQuadrature.Location = New System.Drawing.Point(4, 25)
        Me.TabQuadrature.Name = "TabQuadrature"
        Me.TabQuadrature.Padding = New System.Windows.Forms.Padding(3)
        Me.TabQuadrature.Size = New System.Drawing.Size(1115, 597)
        Me.TabQuadrature.TabIndex = 2
        Me.TabQuadrature.Text = "TabQuadrature"
        Me.TabQuadrature.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1109, 591)
        Me.SplitContainer1.SplitterDistance = 458
        Me.SplitContainer1.TabIndex = 2
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Silver
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.10044!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.388646!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.90599!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.56072!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.768559!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.89083!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 17)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnCancellaAssegni, 5, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label14, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label15, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label16, 2, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label17, 2, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Label18, 2, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Label19, 2, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.Label20, 2, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.txt500Tot, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label21, 2, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.Label22, 2, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.Label23, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label24, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txt500, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txt200, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txt100, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAggiornaAssegni, 1, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.txt200Tot, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txt100Tot, 3, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTotaleCassetto, 3, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 2, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.txt50, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.txt20, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.txt10, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.txt5, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.txtAssegno, 0, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.txt50Tot, 3, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.txt20Tot, 3, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.txt10Tot, 3, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.txt5Tot, 3, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.txtMonetaTot, 3, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.txtNumeroAssegni, 4, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.cboAssegnoTot, 3, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTotaleTitoli, 3, 12)
        Me.TableLayoutPanel2.Controls.Add(Me.txtQuadratura, 3, 14)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 2, 12)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 2, 14)
        Me.TableLayoutPanel2.Controls.Add(Me.lbPv, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAmmanco, 5, 14)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 13)
        Me.TableLayoutPanel2.Controls.Add(Me.btnSalvaQuadratura, 2, 15)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 15)
        Me.TableLayoutPanel2.Controls.Add(Me.btnConsolida, 2, 17)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAbbuono, 5, 13)
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 2, 13)
        Me.TableLayoutPanel2.Controls.Add(Me.txtAbbuoni, 3, 13)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 4, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 4, 12)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 4, 13)
        Me.TableLayoutPanel2.Controls.Add(Me.Label25, 4, 14)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox500, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox5, 1, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox200, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox100, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox50, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox20, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox10, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBoxMonete, 1, 9)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 19
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(458, 591)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Gold
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label7, 2)
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(3, 527)
        Me.Label7.Name = "Label7"
        Me.TableLayoutPanel2.SetRowSpan(Me.Label7, 2)
        Me.Label7.Size = New System.Drawing.Size(97, 64)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "4"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.GreenYellow
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label8, 2)
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(106, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(202, 31)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Conta il cassetto"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancellaAssegni
        '
        Me.btnCancellaAssegni.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancellaAssegni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancellaAssegni.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancellaAssegni.Location = New System.Drawing.Point(345, 313)
        Me.btnCancellaAssegni.Name = "btnCancellaAssegni"
        Me.btnCancellaAssegni.Size = New System.Drawing.Size(110, 25)
        Me.btnCancellaAssegni.TabIndex = 0
        Me.btnCancellaAssegni.Text = "Cancella"
        Me.btnCancellaAssegni.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Violet
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(106, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(126, 31)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "x 500 €"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(106, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(126, 31)
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
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(106, 93)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(126, 31)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "x 200 €"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.YellowGreen
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(106, 124)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(126, 31)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "x 100 €"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Gold
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(106, 155)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(126, 31)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "x 50 €"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.SkyBlue
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(106, 186)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(126, 31)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "x 20 €"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.LightSalmon
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(106, 217)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(126, 31)
        Me.Label19.TabIndex = 9
        Me.Label19.Text = "x 10 €"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Lavender
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(106, 248)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(126, 31)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "x 5 €"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt500Tot
        '
        Me.txt500Tot.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt500Tot.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt500Tot.Location = New System.Drawing.Point(238, 65)
        Me.txt500Tot.Name = "txt500Tot"
        Me.txt500Tot.Size = New System.Drawing.Size(70, 22)
        Me.txt500Tot.TabIndex = 11
        Me.txt500Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.LightGray
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(106, 279)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(126, 31)
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
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(106, 310)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(126, 31)
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
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(238, 31)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(70, 31)
        Me.Label23.TabIndex = 16
        Me.Label23.Text = "Totale"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label24, 2)
        Me.Label24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(3, 31)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(97, 31)
        Me.Label24.TabIndex = 15
        Me.Label24.Text = "Quantità"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt500
        '
        Me.txt500.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt500.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt500.Location = New System.Drawing.Point(3, 65)
        Me.txt500.Name = "txt500"
        Me.txt500.Size = New System.Drawing.Size(54, 22)
        Me.txt500.TabIndex = 0
        Me.txt500.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt200
        '
        Me.txt200.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt200.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt200.Location = New System.Drawing.Point(3, 96)
        Me.txt200.Name = "txt200"
        Me.txt200.Size = New System.Drawing.Size(54, 22)
        Me.txt200.TabIndex = 1
        Me.txt200.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt100
        '
        Me.txt100.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt100.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt100.Location = New System.Drawing.Point(3, 127)
        Me.txt100.Name = "txt100"
        Me.txt100.Size = New System.Drawing.Size(54, 22)
        Me.txt100.TabIndex = 2
        Me.txt100.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAggiornaAssegni
        '
        Me.btnAggiornaAssegni.BackColor = System.Drawing.SystemColors.Control
        Me.btnAggiornaAssegni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAggiornaAssegni.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAggiornaAssegni.Location = New System.Drawing.Point(63, 313)
        Me.btnAggiornaAssegni.Name = "btnAggiornaAssegni"
        Me.btnAggiornaAssegni.Size = New System.Drawing.Size(37, 25)
        Me.btnAggiornaAssegni.TabIndex = 9
        Me.btnAggiornaAssegni.Text = "Aggiorna"
        Me.btnAggiornaAssegni.UseVisualStyleBackColor = False
        '
        'txt200Tot
        '
        Me.txt200Tot.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt200Tot.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt200Tot.Location = New System.Drawing.Point(238, 96)
        Me.txt200Tot.Name = "txt200Tot"
        Me.txt200Tot.Size = New System.Drawing.Size(70, 22)
        Me.txt200Tot.TabIndex = 18
        Me.txt200Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt100Tot
        '
        Me.txt100Tot.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt100Tot.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt100Tot.Location = New System.Drawing.Point(238, 127)
        Me.txt100Tot.Name = "txt100Tot"
        Me.txt100Tot.Size = New System.Drawing.Size(70, 22)
        Me.txt100Tot.TabIndex = 19
        Me.txt100Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotaleCassetto
        '
        Me.txtTotaleCassetto.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotaleCassetto.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtTotaleCassetto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotaleCassetto.Location = New System.Drawing.Point(238, 344)
        Me.txtTotaleCassetto.Name = "txtTotaleCassetto"
        Me.txtTotaleCassetto.Size = New System.Drawing.Size(70, 22)
        Me.txtTotaleCassetto.TabIndex = 20
        Me.txtTotaleCassetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Firebrick
        Me.Label1.Location = New System.Drawing.Point(106, 341)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 31)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Totale cassetto"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt50
        '
        Me.txt50.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt50.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt50.Location = New System.Drawing.Point(3, 158)
        Me.txt50.Name = "txt50"
        Me.txt50.Size = New System.Drawing.Size(54, 22)
        Me.txt50.TabIndex = 3
        Me.txt50.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt20
        '
        Me.txt20.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt20.Location = New System.Drawing.Point(3, 189)
        Me.txt20.Name = "txt20"
        Me.txt20.Size = New System.Drawing.Size(54, 22)
        Me.txt20.TabIndex = 4
        Me.txt20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt10
        '
        Me.txt10.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt10.Location = New System.Drawing.Point(3, 220)
        Me.txt10.Name = "txt10"
        Me.txt10.Size = New System.Drawing.Size(54, 22)
        Me.txt10.TabIndex = 5
        Me.txt10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt5
        '
        Me.txt5.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt5.Location = New System.Drawing.Point(3, 251)
        Me.txt5.Name = "txt5"
        Me.txt5.Size = New System.Drawing.Size(54, 22)
        Me.txt5.TabIndex = 6
        Me.txt5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAssegno
        '
        Me.txtAssegno.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtAssegno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssegno.Location = New System.Drawing.Point(3, 313)
        Me.txtAssegno.Name = "txtAssegno"
        Me.txtAssegno.Size = New System.Drawing.Size(54, 22)
        Me.txtAssegno.TabIndex = 8
        Me.txtAssegno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt50Tot
        '
        Me.txt50Tot.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt50Tot.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt50Tot.Location = New System.Drawing.Point(238, 158)
        Me.txt50Tot.Name = "txt50Tot"
        Me.txt50Tot.Size = New System.Drawing.Size(70, 22)
        Me.txt50Tot.TabIndex = 27
        Me.txt50Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt20Tot
        '
        Me.txt20Tot.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt20Tot.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt20Tot.Location = New System.Drawing.Point(238, 189)
        Me.txt20Tot.Name = "txt20Tot"
        Me.txt20Tot.Size = New System.Drawing.Size(70, 22)
        Me.txt20Tot.TabIndex = 28
        Me.txt20Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt10Tot
        '
        Me.txt10Tot.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt10Tot.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt10Tot.Location = New System.Drawing.Point(238, 220)
        Me.txt10Tot.Name = "txt10Tot"
        Me.txt10Tot.Size = New System.Drawing.Size(70, 22)
        Me.txt10Tot.TabIndex = 29
        Me.txt10Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt5Tot
        '
        Me.txt5Tot.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt5Tot.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt5Tot.Location = New System.Drawing.Point(238, 251)
        Me.txt5Tot.Name = "txt5Tot"
        Me.txt5Tot.Size = New System.Drawing.Size(70, 22)
        Me.txt5Tot.TabIndex = 30
        Me.txt5Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMonetaTot
        '
        Me.txtMonetaTot.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtMonetaTot.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonetaTot.Location = New System.Drawing.Point(238, 282)
        Me.txtMonetaTot.Name = "txtMonetaTot"
        Me.txtMonetaTot.Size = New System.Drawing.Size(70, 22)
        Me.txtMonetaTot.TabIndex = 7
        Me.txtMonetaTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumeroAssegni
        '
        Me.txtNumeroAssegni.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtNumeroAssegni.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroAssegni.Location = New System.Drawing.Point(314, 313)
        Me.txtNumeroAssegni.Name = "txtNumeroAssegni"
        Me.txtNumeroAssegni.Size = New System.Drawing.Size(25, 22)
        Me.txtNumeroAssegni.TabIndex = 33
        Me.txtNumeroAssegni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboAssegnoTot
        '
        Me.cboAssegnoTot.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboAssegnoTot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAssegnoTot.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAssegnoTot.FormattingEnabled = True
        Me.cboAssegnoTot.Location = New System.Drawing.Point(238, 313)
        Me.cboAssegnoTot.Name = "cboAssegnoTot"
        Me.cboAssegnoTot.Size = New System.Drawing.Size(70, 22)
        Me.cboAssegnoTot.TabIndex = 34
        '
        'txtTotaleTitoli
        '
        Me.txtTotaleTitoli.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtTotaleTitoli.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotaleTitoli.Location = New System.Drawing.Point(238, 375)
        Me.txtTotaleTitoli.Name = "txtTotaleTitoli"
        Me.txtTotaleTitoli.Size = New System.Drawing.Size(70, 22)
        Me.txtTotaleTitoli.TabIndex = 39
        Me.txtTotaleTitoli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuadratura
        '
        Me.txtQuadratura.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtQuadratura.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuadratura.ForeColor = System.Drawing.Color.Firebrick
        Me.txtQuadratura.Location = New System.Drawing.Point(238, 437)
        Me.txtQuadratura.Name = "txtQuadratura"
        Me.txtQuadratura.Size = New System.Drawing.Size(70, 22)
        Me.txtQuadratura.TabIndex = 40
        Me.txtQuadratura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(106, 372)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 31)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Totale titoli"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(106, 434)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 31)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Differenza = A+C-B"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbPv
        '
        Me.lbPv.AutoSize = True
        Me.lbPv.BackColor = System.Drawing.Color.Khaki
        Me.lbPv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel2.SetColumnSpan(Me.lbPv, 2)
        Me.lbPv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbPv.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPv.Location = New System.Drawing.Point(314, 0)
        Me.lbPv.Name = "lbPv"
        Me.lbPv.Size = New System.Drawing.Size(141, 31)
        Me.lbPv.TabIndex = 44
        Me.lbPv.Text = "lbPv"
        Me.lbPv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAmmanco
        '
        Me.btnAmmanco.BackColor = System.Drawing.SystemColors.Control
        Me.btnAmmanco.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAmmanco.Location = New System.Drawing.Point(345, 437)
        Me.btnAmmanco.Name = "btnAmmanco"
        Me.btnAmmanco.Size = New System.Drawing.Size(110, 25)
        Me.btnAmmanco.TabIndex = 46
        Me.btnAmmanco.Text = "Salva ammanco"
        Me.btnAmmanco.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Gold
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label4, 2)
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 31)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "1"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Gold
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label5, 2)
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 403)
        Me.Label5.Name = "Label5"
        Me.TableLayoutPanel2.SetRowSpan(Me.Label5, 2)
        Me.Label5.Size = New System.Drawing.Size(97, 62)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "2"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSalvaQuadratura
        '
        Me.btnSalvaQuadratura.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel2.SetColumnSpan(Me.btnSalvaQuadratura, 4)
        Me.btnSalvaQuadratura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSalvaQuadratura.Location = New System.Drawing.Point(106, 468)
        Me.btnSalvaQuadratura.Name = "btnSalvaQuadratura"
        Me.TableLayoutPanel2.SetRowSpan(Me.btnSalvaQuadratura, 2)
        Me.btnSalvaQuadratura.Size = New System.Drawing.Size(349, 56)
        Me.btnSalvaQuadratura.TabIndex = 10
        Me.btnSalvaQuadratura.Text = "Button1"
        Me.btnSalvaQuadratura.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Gold
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label6, 2)
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label6.Location = New System.Drawing.Point(3, 465)
        Me.Label6.Name = "Label6"
        Me.TableLayoutPanel2.SetRowSpan(Me.Label6, 2)
        Me.Label6.Size = New System.Drawing.Size(97, 62)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "3"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnConsolida
        '
        Me.btnConsolida.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel2.SetColumnSpan(Me.btnConsolida, 4)
        Me.btnConsolida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnConsolida.Location = New System.Drawing.Point(106, 530)
        Me.btnConsolida.Name = "btnConsolida"
        Me.TableLayoutPanel2.SetRowSpan(Me.btnConsolida, 2)
        Me.btnConsolida.Size = New System.Drawing.Size(349, 58)
        Me.btnConsolida.TabIndex = 51
        Me.btnConsolida.Text = "Button1"
        Me.btnConsolida.UseVisualStyleBackColor = False
        '
        'btnAbbuono
        '
        Me.btnAbbuono.BackColor = System.Drawing.SystemColors.Control
        Me.btnAbbuono.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAbbuono.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAbbuono.Location = New System.Drawing.Point(345, 406)
        Me.btnAbbuono.Name = "btnAbbuono"
        Me.btnAbbuono.Size = New System.Drawing.Size(110, 25)
        Me.btnAbbuono.TabIndex = 45
        Me.btnAbbuono.Text = "Salva abbuono"
        Me.btnAbbuono.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.NavajoWhite
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(106, 403)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 31)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Abbuoni registrati"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAbbuoni
        '
        Me.txtAbbuoni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAbbuoni.Location = New System.Drawing.Point(238, 406)
        Me.txtAbbuoni.Name = "txtAbbuoni"
        Me.txtAbbuoni.ReadOnly = True
        Me.txtAbbuoni.Size = New System.Drawing.Size(70, 22)
        Me.txtAbbuoni.TabIndex = 54
        Me.txtAbbuoni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.DarkGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(314, 341)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 31)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "A"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.DarkGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(314, 372)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(25, 31)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "B"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.DarkGray
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(314, 403)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 31)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "C"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.DarkGray
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(314, 434)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(25, 31)
        Me.Label25.TabIndex = 58
        Me.Label25.Text = "="
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox500
        '
        Me.PictureBox500.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox500.Location = New System.Drawing.Point(63, 65)
        Me.PictureBox500.Name = "PictureBox500"
        Me.PictureBox500.Size = New System.Drawing.Size(37, 25)
        Me.PictureBox500.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox500.TabIndex = 59
        Me.PictureBox500.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox5.Location = New System.Drawing.Point(63, 251)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(37, 25)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 60
        Me.PictureBox5.TabStop = False
        '
        'PictureBox200
        '
        Me.PictureBox200.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox200.Location = New System.Drawing.Point(63, 96)
        Me.PictureBox200.Name = "PictureBox200"
        Me.PictureBox200.Size = New System.Drawing.Size(37, 25)
        Me.PictureBox200.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox200.TabIndex = 61
        Me.PictureBox200.TabStop = False
        '
        'PictureBox100
        '
        Me.PictureBox100.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox100.Location = New System.Drawing.Point(63, 127)
        Me.PictureBox100.Name = "PictureBox100"
        Me.PictureBox100.Size = New System.Drawing.Size(37, 25)
        Me.PictureBox100.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox100.TabIndex = 62
        Me.PictureBox100.TabStop = False
        '
        'PictureBox50
        '
        Me.PictureBox50.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox50.Location = New System.Drawing.Point(63, 158)
        Me.PictureBox50.Name = "PictureBox50"
        Me.PictureBox50.Size = New System.Drawing.Size(37, 25)
        Me.PictureBox50.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox50.TabIndex = 63
        Me.PictureBox50.TabStop = False
        '
        'PictureBox20
        '
        Me.PictureBox20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox20.Location = New System.Drawing.Point(63, 189)
        Me.PictureBox20.Name = "PictureBox20"
        Me.PictureBox20.Size = New System.Drawing.Size(37, 25)
        Me.PictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox20.TabIndex = 64
        Me.PictureBox20.TabStop = False
        '
        'PictureBox10
        '
        Me.PictureBox10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox10.Location = New System.Drawing.Point(63, 220)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(37, 25)
        Me.PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox10.TabIndex = 65
        Me.PictureBox10.TabStop = False
        '
        'PictureBoxMonete
        '
        Me.PictureBoxMonete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxMonete.Location = New System.Drawing.Point(63, 282)
        Me.PictureBoxMonete.Name = "PictureBoxMonete"
        Me.PictureBoxMonete.Size = New System.Drawing.Size(37, 25)
        Me.PictureBoxMonete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBoxMonete.TabIndex = 66
        Me.PictureBoxMonete.TabStop = False
        '
        'TabCO
        '
        Me.TabCO.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabCO.Location = New System.Drawing.Point(4, 25)
        Me.TabCO.Name = "TabCO"
        Me.TabCO.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCO.Size = New System.Drawing.Size(1115, 597)
        Me.TabCO.TabIndex = 4
        Me.TabCO.Text = "TabCO"
        Me.TabCO.UseVisualStyleBackColor = True
        '
        'TabStat
        '
        Me.TabStat.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabStat.Location = New System.Drawing.Point(4, 25)
        Me.TabStat.Name = "TabStat"
        Me.TabStat.Padding = New System.Windows.Forms.Padding(3)
        Me.TabStat.Size = New System.Drawing.Size(1115, 597)
        Me.TabStat.TabIndex = 3
        Me.TabStat.Text = "TabStat"
        Me.TabStat.UseVisualStyleBackColor = True
        '
        'TabHelp
        '
        Me.TabHelp.Controls.Add(Me.wbHelp)
        Me.TabHelp.Location = New System.Drawing.Point(4, 25)
        Me.TabHelp.Name = "TabHelp"
        Me.TabHelp.Size = New System.Drawing.Size(1115, 597)
        Me.TabHelp.TabIndex = 6
        Me.TabHelp.Text = "TabHelp"
        Me.TabHelp.UseVisualStyleBackColor = True
        '
        'wbHelp
        '
        Me.wbHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbHelp.Location = New System.Drawing.Point(0, 0)
        Me.wbHelp.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbHelp.Name = "wbHelp"
        Me.wbHelp.Size = New System.Drawing.Size(1115, 597)
        Me.wbHelp.TabIndex = 0
        '
        'tsMain
        '
        Me.tsMain.BackColor = System.Drawing.Color.Gainsboro
        Me.tsMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tsMain.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGestioneCodici, Me.btnVersamento, Me.btnScan, Me.btnExcel, Me.btnAggiorna})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(1123, 25)
        Me.tsMain.TabIndex = 2
        Me.tsMain.Text = "ToolStrip2"
        '
        'btnGestioneCodici
        '
        Me.btnGestioneCodici.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnGestioneCodici.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGestioneCodici.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGestioneCodici.Image = CType(resources.GetObject("btnGestioneCodici.Image"), System.Drawing.Image)
        Me.btnGestioneCodici.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGestioneCodici.Name = "btnGestioneCodici"
        Me.btnGestioneCodici.Size = New System.Drawing.Size(138, 22)
        Me.btnGestioneCodici.Text = "Gestione punti vendita"
        '
        'btnVersamento
        '
        Me.btnVersamento.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnVersamento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnVersamento.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VersamentoInBancaToolStripMenuItem, Me.VersamentoDaSubagenziaToolStripMenuItem, Me.ToolStripSeparator3, Me.InserimentoRiportoManualeToolStripMenuItem, Me.MovimentoToolStripMenuItem})
        Me.btnVersamento.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVersamento.Image = CType(resources.GetObject("btnVersamento.Image"), System.Drawing.Image)
        Me.btnVersamento.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVersamento.Name = "btnVersamento"
        Me.btnVersamento.Size = New System.Drawing.Size(145, 22)
        Me.btnVersamento.Text = "Versamento in banca"
        '
        'VersamentoInBancaToolStripMenuItem
        '
        Me.VersamentoInBancaToolStripMenuItem.Name = "VersamentoInBancaToolStripMenuItem"
        Me.VersamentoInBancaToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.VersamentoInBancaToolStripMenuItem.Text = "Versamento in banca"
        '
        'VersamentoDaSubagenziaToolStripMenuItem
        '
        Me.VersamentoDaSubagenziaToolStripMenuItem.Name = "VersamentoDaSubagenziaToolStripMenuItem"
        Me.VersamentoDaSubagenziaToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.VersamentoDaSubagenziaToolStripMenuItem.Text = "Versamento da subagenzia"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(306, 6)
        '
        'InserimentoRiportoManualeToolStripMenuItem
        '
        Me.InserimentoRiportoManualeToolStripMenuItem.Name = "InserimentoRiportoManualeToolStripMenuItem"
        Me.InserimentoRiportoManualeToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.InserimentoRiportoManualeToolStripMenuItem.Text = "Versamento, Riporto, Incasso conto terzi"
        '
        'MovimentoToolStripMenuItem
        '
        Me.MovimentoToolStripMenuItem.Name = "MovimentoToolStripMenuItem"
        Me.MovimentoToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.MovimentoToolStripMenuItem.Text = "Movimento"
        '
        'btnScan
        '
        Me.btnScan.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnScan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VisualizzaAssegniDelGiornoToolStripMenuItem})
        Me.btnScan.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScan.Image = CType(resources.GetObject("btnScan.Image"), System.Drawing.Image)
        Me.btnScan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(145, 22)
        Me.btnScan.Text = "Scansione assegni"
        '
        'VisualizzaAssegniDelGiornoToolStripMenuItem
        '
        Me.VisualizzaAssegniDelGiornoToolStripMenuItem.Name = "VisualizzaAssegniDelGiornoToolStripMenuItem"
        Me.VisualizzaAssegniDelGiornoToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.VisualizzaAssegniDelGiornoToolStripMenuItem.Text = "Visualizza assegni del giorno"
        '
        'btnExcel
        '
        Me.btnExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(71, 22)
        Me.btnExcel.Text = "Esporta"
        '
        'btnAggiorna
        '
        Me.btnAggiorna.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnAggiorna.Image = CType(resources.GetObject("btnAggiorna.Image"), System.Drawing.Image)
        Me.btnAggiorna.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(155, 22)
        Me.btnAggiorna.Text = "Aggiorna dati da Essig"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Orange
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1123, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbSelezionati, Me.lbSomma, Me.lbMedia, Me.lbEntrate, Me.lbUscite, Me.lbSaldo, Me.ProgressBar1, Me.lbProgress})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 678)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1123, 26)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbSelezionati
        '
        Me.lbSelezionati.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.lbSelezionati.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lbSelezionati.Name = "lbSelezionati"
        Me.lbSelezionati.Size = New System.Drawing.Size(0, 21)
        '
        'lbSomma
        '
        Me.lbSomma.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.lbSomma.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lbSomma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbSomma.Name = "lbSomma"
        Me.lbSomma.Size = New System.Drawing.Size(0, 21)
        '
        'lbMedia
        '
        Me.lbMedia.Name = "lbMedia"
        Me.lbMedia.Size = New System.Drawing.Size(0, 21)
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Padding = New System.Windows.Forms.Padding(2)
        Me.ProgressBar1.Size = New System.Drawing.Size(104, 20)
        '
        'lbProgress
        '
        Me.lbProgress.Name = "lbProgress"
        Me.lbProgress.Size = New System.Drawing.Size(0, 21)
        '
        'lbEntrate
        '
        Me.lbEntrate.Name = "lbEntrate"
        Me.lbEntrate.Size = New System.Drawing.Size(0, 21)
        '
        'lbUscite
        '
        Me.lbUscite.Name = "lbUscite"
        Me.lbUscite.Size = New System.Drawing.Size(0, 21)
        '
        'lbSaldo
        '
        Me.lbSaldo.Name = "lbSaldo"
        Me.lbSaldo.Size = New System.Drawing.Size(0, 21)
        '
        'FormChiusura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1123, 704)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tsMain)
        Me.Controls.Add(Me.TabCassa)
        Me.Name = "FormChiusura"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabCassa.ResumeLayout(False)
        Me.TabTotali.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabQuadrature.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.PictureBox500, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox200, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox100, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxMonete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabHelp.ResumeLayout(False)
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabCassa As System.Windows.Forms.TabControl
    Friend WithEvents TabElenco As System.Windows.Forms.TabPage
    Friend WithEvents TabTotali As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lbDettaglio As System.Windows.Forms.Label
    Friend WithEvents lbTotali As System.Windows.Forms.Label
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnVersamento As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents VersamentoDaSubagenziaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InserimentoRiportoManualeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnScan As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents VisualizzaAssegniDelGiornoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabQuadrature As System.Windows.Forms.TabPage
    Friend WithEvents TabStat As System.Windows.Forms.TabPage
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbSomma As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnGestioneCodici As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAggiorna As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbSelezionati As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lbProgress As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MovimentoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabCO As System.Windows.Forms.TabPage
    Friend WithEvents lbMedia As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbTipoPagamento As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
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
    Friend WithEvents txtTotaleTitoli As System.Windows.Forms.TextBox
    Friend WithEvents txtQuadratura As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbPv As System.Windows.Forms.Label
    Friend WithEvents btnAbbuono As System.Windows.Forms.Button
    Friend WithEvents btnAmmanco As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSalvaQuadratura As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnConsolida As System.Windows.Forms.Button
    Friend WithEvents VersamentoInBancaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabHelp As System.Windows.Forms.TabPage
    Friend WithEvents wbHelp As System.Windows.Forms.WebBrowser
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAbbuoni As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents PictureBox500 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox200 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox100 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox50 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox20 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxMonete As System.Windows.Forms.PictureBox
    Friend WithEvents lbEntrate As ToolStripStatusLabel
    Friend WithEvents lbUscite As ToolStripStatusLabel
    Friend WithEvents lbSaldo As ToolStripStatusLabel
End Class
