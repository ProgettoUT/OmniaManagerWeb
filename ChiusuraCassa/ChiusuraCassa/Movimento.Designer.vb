<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimento
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipoMovimento = New System.Windows.Forms.ComboBox()
        Me.lbTestata = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtImporto = New System.Windows.Forms.TextBox()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.btnNuovo = New System.Windows.Forms.Button()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDesk = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboTipoPagamento = New System.Windows.Forms.ComboBox()
        Me.cboCassaUscita = New System.Windows.Forms.ComboBox()
        Me.cboPvUscita = New System.Windows.Forms.ComboBox()
        Me.cboSezioneUscita = New System.Windows.Forms.ComboBox()
        Me.cboCassaEntrata = New System.Windows.Forms.ComboBox()
        Me.cboPvEntrata = New System.Windows.Forms.ComboBox()
        Me.cboSezioneEntrata = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboCodice = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lbStato = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTipoMovimento, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbTestata, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.txtImporto, 1, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSalva, 0, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.btnNuovo, 0, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEsci, 2, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDesk, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTipoPagamento, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.cboCassaUscita, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.cboPvUscita, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.cboSezioneUscita, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.cboCassaEntrata, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.cboPvEntrata, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.cboSezioneEntrata, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cboCodice, 1, 4)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(14, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 16
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.467662!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.970149!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(489, 402)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(149, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "da (Uscita)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboTipoMovimento
        '
        Me.cboTipoMovimento.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboTipoMovimento, 2)
        Me.cboTipoMovimento.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboTipoMovimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMovimento.FormattingEnabled = True
        Me.cboTipoMovimento.Location = New System.Drawing.Point(149, 53)
        Me.cboTipoMovimento.Name = "cboTipoMovimento"
        Me.cboTipoMovimento.Size = New System.Drawing.Size(337, 22)
        Me.cboTipoMovimento.TabIndex = 0
        '
        'lbTestata
        '
        Me.lbTestata.AutoSize = True
        Me.lbTestata.BackColor = System.Drawing.Color.Gold
        Me.lbTestata.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbTestata, 3)
        Me.lbTestata.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbTestata.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTestata.Location = New System.Drawing.Point(3, 0)
        Me.lbTestata.Name = "lbTestata"
        Me.lbTestata.Size = New System.Drawing.Size(483, 25)
        Me.lbTestata.TabIndex = 4
        Me.lbTestata.Text = "Movimento"
        Me.lbTestata.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 25)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Movimento"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 250)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 25)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Importo"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtImporto
        '
        Me.txtImporto.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtImporto, 2)
        Me.txtImporto.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtImporto.Location = New System.Drawing.Point(149, 253)
        Me.txtImporto.Name = "txtImporto"
        Me.txtImporto.Size = New System.Drawing.Size(337, 22)
        Me.txtImporto.TabIndex = 10
        Me.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSalva
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnSalva, 3)
        Me.btnSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSalva.Location = New System.Drawing.Point(3, 303)
        Me.btnSalva.Name = "btnSalva"
        Me.TableLayoutPanel1.SetRowSpan(Me.btnSalva, 2)
        Me.btnSalva.Size = New System.Drawing.Size(483, 45)
        Me.btnSalva.TabIndex = 11
        Me.btnSalva.Text = "Button1"
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'btnNuovo
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnNuovo, 2)
        Me.btnNuovo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNuovo.Location = New System.Drawing.Point(3, 354)
        Me.btnNuovo.Name = "btnNuovo"
        Me.TableLayoutPanel1.SetRowSpan(Me.btnNuovo, 2)
        Me.btnNuovo.Size = New System.Drawing.Size(311, 45)
        Me.btnNuovo.TabIndex = 12
        Me.btnNuovo.Text = "Button1"
        Me.btnNuovo.UseVisualStyleBackColor = True
        '
        'btnEsci
        '
        Me.btnEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsci.Location = New System.Drawing.Point(320, 354)
        Me.btnEsci.Name = "btnEsci"
        Me.TableLayoutPanel1.SetRowSpan(Me.btnEsci, 2)
        Me.btnEsci.Size = New System.Drawing.Size(166, 45)
        Me.btnEsci.TabIndex = 13
        Me.btnEsci.Text = "Button2"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(320, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(166, 25)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "a (Entrata)"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(3, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 25)
        Me.Label7.TabIndex = 27
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDesk
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtDesk, 2)
        Me.txtDesk.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtDesk.Location = New System.Drawing.Point(149, 78)
        Me.txtDesk.Name = "txtDesk"
        Me.txtDesk.Size = New System.Drawing.Size(337, 22)
        Me.txtDesk.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Tipo pagamento"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Cassa"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 25)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Punto vendita"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 125)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(140, 25)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Sezione"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTipoPagamento
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboTipoPagamento, 2)
        Me.cboTipoPagamento.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboTipoPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPagamento.FormattingEnabled = True
        Me.cboTipoPagamento.Location = New System.Drawing.Point(149, 203)
        Me.cboTipoPagamento.Name = "cboTipoPagamento"
        Me.cboTipoPagamento.Size = New System.Drawing.Size(337, 22)
        Me.cboTipoPagamento.TabIndex = 7
        '
        'cboCassaUscita
        '
        Me.cboCassaUscita.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboCassaUscita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCassaUscita.FormattingEnabled = True
        Me.cboCassaUscita.Location = New System.Drawing.Point(149, 178)
        Me.cboCassaUscita.Name = "cboCassaUscita"
        Me.cboCassaUscita.Size = New System.Drawing.Size(165, 22)
        Me.cboCassaUscita.TabIndex = 5
        '
        'cboPvUscita
        '
        Me.cboPvUscita.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboPvUscita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPvUscita.FormattingEnabled = True
        Me.cboPvUscita.Location = New System.Drawing.Point(149, 153)
        Me.cboPvUscita.Name = "cboPvUscita"
        Me.cboPvUscita.Size = New System.Drawing.Size(165, 22)
        Me.cboPvUscita.TabIndex = 3
        '
        'cboSezioneUscita
        '
        Me.cboSezioneUscita.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboSezioneUscita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSezioneUscita.FormattingEnabled = True
        Me.cboSezioneUscita.Location = New System.Drawing.Point(149, 128)
        Me.cboSezioneUscita.Name = "cboSezioneUscita"
        Me.cboSezioneUscita.Size = New System.Drawing.Size(165, 22)
        Me.cboSezioneUscita.TabIndex = 1
        '
        'cboCassaEntrata
        '
        Me.cboCassaEntrata.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboCassaEntrata.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCassaEntrata.FormattingEnabled = True
        Me.cboCassaEntrata.Location = New System.Drawing.Point(320, 178)
        Me.cboCassaEntrata.Name = "cboCassaEntrata"
        Me.cboCassaEntrata.Size = New System.Drawing.Size(166, 22)
        Me.cboCassaEntrata.TabIndex = 6
        '
        'cboPvEntrata
        '
        Me.cboPvEntrata.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboPvEntrata.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPvEntrata.FormattingEnabled = True
        Me.cboPvEntrata.Location = New System.Drawing.Point(320, 153)
        Me.cboPvEntrata.Name = "cboPvEntrata"
        Me.cboPvEntrata.Size = New System.Drawing.Size(166, 22)
        Me.cboPvEntrata.TabIndex = 4
        '
        'cboSezioneEntrata
        '
        Me.cboSezioneEntrata.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboSezioneEntrata.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSezioneEntrata.FormattingEnabled = True
        Me.cboSezioneEntrata.Location = New System.Drawing.Point(320, 128)
        Me.cboSezioneEntrata.Name = "cboSezioneEntrata"
        Me.cboSezioneEntrata.Size = New System.Drawing.Size(166, 22)
        Me.cboSezioneEntrata.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 25)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Descrizione"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 25)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Codice movimento"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCodice
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboCodice, 2)
        Me.cboCodice.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboCodice.FormattingEnabled = True
        Me.cboCodice.Location = New System.Drawing.Point(149, 103)
        Me.cboCodice.Name = "cboCodice"
        Me.cboCodice.Size = New System.Drawing.Size(337, 22)
        Me.cboCodice.TabIndex = 9
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbStato})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(516, 22)
        Me.StatusStrip1.TabIndex = 1
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
        'frmMovimento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 450)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMovimento"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Movimento"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cboPvUscita As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoMovimento As System.Windows.Forms.ComboBox
    Friend WithEvents lbTestata As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboCassaUscita As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoPagamento As System.Windows.Forms.ComboBox
    Friend WithEvents cboCodice As System.Windows.Forms.ComboBox
    Friend WithEvents txtDesk As System.Windows.Forms.TextBox
    Friend WithEvents txtImporto As System.Windows.Forms.TextBox
    Friend WithEvents btnSalva As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboSezioneUscita As System.Windows.Forms.ComboBox
    Friend WithEvents btnNuovo As System.Windows.Forms.Button
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbStato As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboSezioneEntrata As System.Windows.Forms.ComboBox
    Friend WithEvents cboPvEntrata As System.Windows.Forms.ComboBox
    Friend WithEvents cboCassaEntrata As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
