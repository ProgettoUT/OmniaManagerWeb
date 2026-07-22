<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMail))
        Me.btnCancellaLista = New System.Windows.Forms.Button()
        Me.btnCancella = New System.Windows.Forms.Button()
        Me.btnAggiungi = New System.Windows.Forms.Button()
        Me.cboMittente = New System.Windows.Forms.ComboBox()
        Me.cboDestinatario = New System.Windows.Forms.ComboBox()
        Me.ListAllegati = New System.Windows.Forms.ListBox()
        Me.tsAllegati = New System.Windows.Forms.ToolStrip()
        Me.tsbAggiungiAllegato = New System.Windows.Forms.ToolStripButton()
        Me.tsbAggiungiDocumento = New System.Windows.Forms.ToolStripButton()
        Me.tsComprimi = New System.Windows.Forms.ToolStripButton()
        Me.tsbElimina = New System.Windows.Forms.ToolStripButton()
        Me.lbDimensioneAllegati = New System.Windows.Forms.Label()
        Me.txtOggetto = New System.Windows.Forms.TextBox()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbInvia = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbEsci = New System.Windows.Forms.ToolStripButton()
        Me.tsbRubrica = New System.Windows.Forms.ToolStripButton()
        Me.tsbFirma = New System.Windows.Forms.ToolStripSplitButton()
        Me.ModificaFirmaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbSalva = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lbStato = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbInvio = New System.Windows.Forms.ToolStripProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtNumeroSms = New System.Windows.Forms.TextBox()
        Me.txtTesto = New System.Windows.Forms.TextBox()
        Me.txtCarDisponibili = New System.Windows.Forms.TextBox()
        Me.lvDestinatari = New System.Windows.Forms.ListView()
        Me.txtCarUtilizzati = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelTipoMessaggio = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.rbMail = New System.Windows.Forms.RadioButton()
        Me.rbSms = New System.Windows.Forms.RadioButton()
        Me.cboTipoDestinatario = New System.Windows.Forms.ComboBox()
        Me.lbOggetto = New System.Windows.Forms.Label()
        Me.cboSmsPredefiniti = New System.Windows.Forms.ComboBox()
        Me.PanelAllegati = New System.Windows.Forms.Panel()
        Me.TextBoxNomeMittente = New System.Windows.Forms.TextBox()
        Me.tsAllegati.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PanelTipoMessaggio.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.PanelAllegati.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancellaLista
        '
        Me.btnCancellaLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancellaLista.Location = New System.Drawing.Point(607, 71)
        Me.btnCancellaLista.Name = "btnCancellaLista"
        Me.btnCancellaLista.Size = New System.Drawing.Size(54, 22)
        Me.btnCancellaLista.TabIndex = 7
        Me.btnCancellaLista.Text = "CancellaTutto"
        Me.btnCancellaLista.UseVisualStyleBackColor = True
        '
        'btnCancella
        '
        Me.btnCancella.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancella.Location = New System.Drawing.Point(547, 71)
        Me.btnCancella.Name = "btnCancella"
        Me.btnCancella.Size = New System.Drawing.Size(54, 22)
        Me.btnCancella.TabIndex = 6
        Me.btnCancella.Text = "Cancella"
        Me.btnCancella.UseVisualStyleBackColor = True
        '
        'btnAggiungi
        '
        Me.btnAggiungi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAggiungi.Location = New System.Drawing.Point(487, 71)
        Me.btnAggiungi.Name = "btnAggiungi"
        Me.btnAggiungi.Size = New System.Drawing.Size(54, 22)
        Me.btnAggiungi.TabIndex = 5
        Me.btnAggiungi.Text = "Aggiungi"
        Me.btnAggiungi.UseVisualStyleBackColor = True
        '
        'cboMittente
        '
        Me.cboMittente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMittente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMittente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMittente.FormattingEnabled = True
        Me.cboMittente.Location = New System.Drawing.Point(83, 43)
        Me.cboMittente.Name = "cboMittente"
        Me.cboMittente.Size = New System.Drawing.Size(398, 22)
        Me.cboMittente.TabIndex = 2
        '
        'cboDestinatario
        '
        Me.cboDestinatario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDestinatario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboDestinatario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDestinatario.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDestinatario.FormattingEnabled = True
        Me.cboDestinatario.Location = New System.Drawing.Point(83, 71)
        Me.cboDestinatario.Name = "cboDestinatario"
        Me.cboDestinatario.Size = New System.Drawing.Size(398, 22)
        Me.cboDestinatario.Sorted = True
        Me.cboDestinatario.TabIndex = 4
        '
        'ListAllegati
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ListAllegati, 3)
        Me.ListAllegati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListAllegati.FormattingEnabled = True
        Me.ListAllegati.IntegralHeight = False
        Me.ListAllegati.ItemHeight = 14
        Me.ListAllegati.Location = New System.Drawing.Point(667, 3)
        Me.ListAllegati.Name = "ListAllegati"
        Me.TableLayoutPanel1.SetRowSpan(Me.ListAllegati, 6)
        Me.ListAllegati.Size = New System.Drawing.Size(295, 174)
        Me.ListAllegati.TabIndex = 15
        Me.ListAllegati.TabStop = False
        '
        'tsAllegati
        '
        Me.tsAllegati.BackColor = System.Drawing.Color.Gold
        Me.tsAllegati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tsAllegati.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsAllegati.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsAllegati.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAggiungiAllegato, Me.tsbAggiungiDocumento, Me.tsComprimi, Me.tsbElimina})
        Me.tsAllegati.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.tsAllegati.Location = New System.Drawing.Point(0, 0)
        Me.tsAllegati.Name = "tsAllegati"
        Me.tsAllegati.Size = New System.Drawing.Size(293, 27)
        Me.tsAllegati.Stretch = True
        Me.tsAllegati.TabIndex = 0
        Me.tsAllegati.Text = "ToolStrip1"
        '
        'tsbAggiungiAllegato
        '
        Me.tsbAggiungiAllegato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbAggiungiAllegato.Image = CType(resources.GetObject("tsbAggiungiAllegato.Image"), System.Drawing.Image)
        Me.tsbAggiungiAllegato.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAggiungiAllegato.Name = "tsbAggiungiAllegato"
        Me.tsbAggiungiAllegato.Size = New System.Drawing.Size(55, 24)
        Me.tsbAggiungiAllegato.Text = "Allegato"
        Me.tsbAggiungiAllegato.ToolTipText = "Aggiungi allegato"
        '
        'tsbAggiungiDocumento
        '
        Me.tsbAggiungiDocumento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbAggiungiDocumento.Image = CType(resources.GetObject("tsbAggiungiDocumento.Image"), System.Drawing.Image)
        Me.tsbAggiungiDocumento.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAggiungiDocumento.Name = "tsbAggiungiDocumento"
        Me.tsbAggiungiDocumento.Size = New System.Drawing.Size(75, 24)
        Me.tsbAggiungiDocumento.Text = "Documento"
        Me.tsbAggiungiDocumento.ToolTipText = "Aggiungi documento"
        '
        'tsComprimi
        '
        Me.tsComprimi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsComprimi.Image = CType(resources.GetObject("tsComprimi.Image"), System.Drawing.Image)
        Me.tsComprimi.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsComprimi.Name = "tsComprimi"
        Me.tsComprimi.Size = New System.Drawing.Size(60, 24)
        Me.tsComprimi.Text = "Comprimi"
        Me.tsComprimi.ToolTipText = "Comprimi allegati"
        '
        'tsbElimina
        '
        Me.tsbElimina.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbElimina.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbElimina.Image = CType(resources.GetObject("tsbElimina.Image"), System.Drawing.Image)
        Me.tsbElimina.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbElimina.Name = "tsbElimina"
        Me.tsbElimina.Size = New System.Drawing.Size(47, 24)
        Me.tsbElimina.Text = "Elimina"
        Me.tsbElimina.ToolTipText = "Elimina allegato selezionato"
        '
        'lbDimensioneAllegati
        '
        Me.lbDimensioneAllegati.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbDimensioneAllegati, 3)
        Me.lbDimensioneAllegati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbDimensioneAllegati.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbDimensioneAllegati.Location = New System.Drawing.Point(667, 180)
        Me.lbDimensioneAllegati.Name = "lbDimensioneAllegati"
        Me.lbDimensioneAllegati.Size = New System.Drawing.Size(295, 30)
        Me.lbDimensioneAllegati.TabIndex = 2
        Me.lbDimensioneAllegati.Text = "Label1"
        '
        'txtOggetto
        '
        Me.txtOggetto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOggetto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOggetto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOggetto.Location = New System.Drawing.Point(83, 248)
        Me.txtOggetto.Name = "txtOggetto"
        Me.txtOggetto.Size = New System.Drawing.Size(398, 23)
        Me.txtOggetto.TabIndex = 9
        '
        'tsMenu
        '
        Me.tsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbInvia, Me.ToolStripSeparator1, Me.tsbEsci, Me.tsbRubrica, Me.tsbFirma, Me.tsbSalva})
        Me.tsMenu.Location = New System.Drawing.Point(2, 2)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tsMenu.Size = New System.Drawing.Size(965, 39)
        Me.tsMenu.TabIndex = 0
        Me.tsMenu.TabStop = True
        Me.tsMenu.Text = "ToolStrip1"
        '
        'tsbInvia
        '
        Me.tsbInvia.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbInvia.Image = CType(resources.GetObject("tsbInvia.Image"), System.Drawing.Image)
        Me.tsbInvia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbInvia.Name = "tsbInvia"
        Me.tsbInvia.Size = New System.Drawing.Size(81, 36)
        Me.tsbInvia.Text = "Invia"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'tsbEsci
        '
        Me.tsbEsci.Image = CType(resources.GetObject("tsbEsci.Image"), System.Drawing.Image)
        Me.tsbEsci.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEsci.Name = "tsbEsci"
        Me.tsbEsci.Size = New System.Drawing.Size(63, 36)
        Me.tsbEsci.Text = "Esci"
        '
        'tsbRubrica
        '
        Me.tsbRubrica.Image = CType(resources.GetObject("tsbRubrica.Image"), System.Drawing.Image)
        Me.tsbRubrica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRubrica.Name = "tsbRubrica"
        Me.tsbRubrica.Size = New System.Drawing.Size(83, 36)
        Me.tsbRubrica.Text = "Rubrica"
        '
        'tsbFirma
        '
        Me.tsbFirma.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificaFirmaToolStripMenuItem})
        Me.tsbFirma.Image = CType(resources.GetObject("tsbFirma.Image"), System.Drawing.Image)
        Me.tsbFirma.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFirma.Name = "tsbFirma"
        Me.tsbFirma.Size = New System.Drawing.Size(128, 36)
        Me.tsbFirma.Text = "Inserisci firma"
        '
        'ModificaFirmaToolStripMenuItem
        '
        Me.ModificaFirmaToolStripMenuItem.Name = "ModificaFirmaToolStripMenuItem"
        Me.ModificaFirmaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ModificaFirmaToolStripMenuItem.Text = "Modifica firma"
        '
        'tsbSalva
        '
        Me.tsbSalva.Image = CType(resources.GetObject("tsbSalva.Image"), System.Drawing.Image)
        Me.tsbSalva.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalva.Name = "tsbSalva"
        Me.tsbSalva.Size = New System.Drawing.Size(143, 36)
        Me.tsbSalva.Text = "Salva modello SMS"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbStato, Me.pbInvio})
        Me.StatusStrip1.Location = New System.Drawing.Point(2, 553)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(965, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbStato
        '
        Me.lbStato.Name = "lbStato"
        Me.lbStato.Size = New System.Drawing.Size(44, 17)
        Me.lbStato.Text = "lbStato"
        '
        'pbInvio
        '
        Me.pbInvio.Name = "pbInvio"
        Me.pbInvio.Size = New System.Drawing.Size(100, 16)
        '
        'BackgroundWorker1
        '
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.36349!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.21217!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.21217!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.21217!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtNumeroSms, 7, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTesto, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCarDisponibili, 6, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.lvDestinatari, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCarUtilizzati, 5, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancellaLista, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancella, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ListAllegati, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAggiungi, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDestinatario, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboMittente, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbDimensioneAllegati, 5, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.PanelTipoMessaggio, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTipoDestinatario, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbOggetto, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.txtOggetto, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.cboSmsPredefiniti, 2, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.PanelAllegati, 5, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxNomeMittente, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 41)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(965, 512)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'txtNumeroSms
        '
        Me.txtNumeroSms.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtNumeroSms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroSms.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtNumeroSms.Location = New System.Drawing.Point(867, 248)
        Me.txtNumeroSms.Name = "txtNumeroSms"
        Me.txtNumeroSms.Size = New System.Drawing.Size(95, 22)
        Me.txtNumeroSms.TabIndex = 13
        Me.txtNumeroSms.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTesto
        '
        Me.txtTesto.AcceptsReturn = True
        Me.txtTesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtTesto, 8)
        Me.txtTesto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTesto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTesto.Location = New System.Drawing.Point(3, 276)
        Me.txtTesto.Multiline = True
        Me.txtTesto.Name = "txtTesto"
        Me.txtTesto.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTesto.Size = New System.Drawing.Size(959, 233)
        Me.txtTesto.TabIndex = 14
        '
        'txtCarDisponibili
        '
        Me.txtCarDisponibili.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCarDisponibili.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCarDisponibili.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtCarDisponibili.Location = New System.Drawing.Point(767, 248)
        Me.txtCarDisponibili.Name = "txtCarDisponibili"
        Me.txtCarDisponibili.Size = New System.Drawing.Size(94, 22)
        Me.txtCarDisponibili.TabIndex = 12
        Me.txtCarDisponibili.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lvDestinatari
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lvDestinatari, 5)
        Me.lvDestinatari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvDestinatari.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDestinatari.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lvDestinatari.HideSelection = False
        Me.lvDestinatari.Location = New System.Drawing.Point(3, 99)
        Me.lvDestinatari.Name = "lvDestinatari"
        Me.TableLayoutPanel1.SetRowSpan(Me.lvDestinatari, 5)
        Me.lvDestinatari.Size = New System.Drawing.Size(658, 143)
        Me.lvDestinatari.TabIndex = 8
        Me.lvDestinatari.TabStop = False
        Me.lvDestinatari.UseCompatibleStateImageBehavior = False
        Me.lvDestinatari.View = System.Windows.Forms.View.Details
        '
        'txtCarUtilizzati
        '
        Me.txtCarUtilizzati.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtCarUtilizzati.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCarUtilizzati.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtCarUtilizzati.Location = New System.Drawing.Point(667, 248)
        Me.txtCarUtilizzati.Name = "txtCarUtilizzati"
        Me.txtCarUtilizzati.Size = New System.Drawing.Size(94, 22)
        Me.txtCarUtilizzati.TabIndex = 11
        Me.txtCarUtilizzati.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 28)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Da"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelTipoMessaggio
        '
        Me.PanelTipoMessaggio.BackColor = System.Drawing.SystemColors.Control
        Me.PanelTipoMessaggio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.PanelTipoMessaggio, 5)
        Me.PanelTipoMessaggio.Controls.Add(Me.TableLayoutPanel2)
        Me.PanelTipoMessaggio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTipoMessaggio.Location = New System.Drawing.Point(3, 3)
        Me.PanelTipoMessaggio.Name = "PanelTipoMessaggio"
        Me.PanelTipoMessaggio.Size = New System.Drawing.Size(658, 34)
        Me.PanelTipoMessaggio.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.rbMail, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rbSms, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(656, 32)
        Me.TableLayoutPanel2.TabIndex = 6
        '
        'rbMail
        '
        Me.rbMail.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.rbMail, 2)
        Me.rbMail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbMail.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMail.Location = New System.Drawing.Point(3, 3)
        Me.rbMail.Name = "rbMail"
        Me.rbMail.Size = New System.Drawing.Size(322, 26)
        Me.rbMail.TabIndex = 0
        Me.rbMail.TabStop = True
        Me.rbMail.Text = "Invia una E-mail"
        Me.rbMail.UseVisualStyleBackColor = True
        '
        'rbSms
        '
        Me.rbSms.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.rbSms, 2)
        Me.rbSms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbSms.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSms.Location = New System.Drawing.Point(331, 3)
        Me.rbSms.Name = "rbSms"
        Me.rbSms.Size = New System.Drawing.Size(322, 26)
        Me.rbSms.TabIndex = 1
        Me.rbSms.TabStop = True
        Me.rbSms.Text = "Invia un SMS"
        Me.rbSms.UseVisualStyleBackColor = True
        '
        'cboTipoDestinatario
        '
        Me.cboTipoDestinatario.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboTipoDestinatario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDestinatario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipoDestinatario.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDestinatario.FormattingEnabled = True
        Me.cboTipoDestinatario.Location = New System.Drawing.Point(3, 71)
        Me.cboTipoDestinatario.Name = "cboTipoDestinatario"
        Me.cboTipoDestinatario.Size = New System.Drawing.Size(74, 22)
        Me.cboTipoDestinatario.TabIndex = 3
        '
        'lbOggetto
        '
        Me.lbOggetto.AutoSize = True
        Me.lbOggetto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbOggetto.Location = New System.Drawing.Point(3, 245)
        Me.lbOggetto.Name = "lbOggetto"
        Me.lbOggetto.Size = New System.Drawing.Size(74, 28)
        Me.lbOggetto.TabIndex = 8
        Me.lbOggetto.Text = "Oggetto"
        Me.lbOggetto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboSmsPredefiniti
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboSmsPredefiniti, 3)
        Me.cboSmsPredefiniti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboSmsPredefiniti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSmsPredefiniti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSmsPredefiniti.FormattingEnabled = True
        Me.cboSmsPredefiniti.Location = New System.Drawing.Point(487, 248)
        Me.cboSmsPredefiniti.Name = "cboSmsPredefiniti"
        Me.cboSmsPredefiniti.Size = New System.Drawing.Size(174, 22)
        Me.cboSmsPredefiniti.TabIndex = 10
        '
        'PanelAllegati
        '
        Me.PanelAllegati.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.PanelAllegati, 3)
        Me.PanelAllegati.Controls.Add(Me.tsAllegati)
        Me.PanelAllegati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAllegati.Location = New System.Drawing.Point(667, 213)
        Me.PanelAllegati.Name = "PanelAllegati"
        Me.PanelAllegati.Size = New System.Drawing.Size(295, 29)
        Me.PanelAllegati.TabIndex = 9
        '
        'TextBoxNomeMittente
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxNomeMittente, 3)
        Me.TextBoxNomeMittente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxNomeMittente.Location = New System.Drawing.Point(487, 43)
        Me.TextBoxNomeMittente.Name = "TextBoxNomeMittente"
        Me.TextBoxNomeMittente.Size = New System.Drawing.Size(174, 22)
        Me.TextBoxNomeMittente.TabIndex = 16
        '
        'FormMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 577)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tsMenu)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormMail"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.tsAllegati.ResumeLayout(False)
        Me.tsAllegati.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.PanelTipoMessaggio.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.PanelAllegati.ResumeLayout(False)
        Me.PanelAllegati.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboMittente As System.Windows.Forms.ComboBox
    Friend WithEvents cboDestinatario As System.Windows.Forms.ComboBox
    Friend WithEvents txtOggetto As System.Windows.Forms.TextBox
    Friend WithEvents btnAggiungi As System.Windows.Forms.Button
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbInvia As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRubrica As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEsci As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListAllegati As System.Windows.Forms.ListBox
    Friend WithEvents tsAllegati As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAggiungiAllegato As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAggiungiDocumento As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbElimina As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsComprimi As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbDimensioneAllegati As System.Windows.Forms.Label
    Friend WithEvents btnCancellaLista As System.Windows.Forms.Button
    Friend WithEvents btnCancella As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbStato As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pbInvio As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtNumeroSms As System.Windows.Forms.TextBox
    Friend WithEvents txtCarDisponibili As System.Windows.Forms.TextBox
    Friend WithEvents txtCarUtilizzati As System.Windows.Forms.TextBox
    Friend WithEvents cboSmsPredefiniti As System.Windows.Forms.ComboBox
    Friend WithEvents txtTesto As System.Windows.Forms.TextBox
    Friend WithEvents lvDestinatari As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelTipoMessaggio As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbMail As System.Windows.Forms.RadioButton
    Friend WithEvents rbSms As System.Windows.Forms.RadioButton
    Friend WithEvents cboTipoDestinatario As System.Windows.Forms.ComboBox
    Friend WithEvents lbOggetto As System.Windows.Forms.Label
    Friend WithEvents PanelAllegati As System.Windows.Forms.Panel
    Friend WithEvents tsbFirma As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ModificaFirmaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSalva As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBoxNomeMittente As TextBox
End Class
