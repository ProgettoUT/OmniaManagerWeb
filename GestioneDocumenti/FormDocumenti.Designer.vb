<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDocumenti
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDocumenti))
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanelEsploraDoc = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonRecupera = New System.Windows.Forms.Button()
        Me.ButtonSetStorico = New System.Windows.Forms.Button()
        Me.btnRinomina = New System.Windows.Forms.Button()
        Me.btnApri = New System.Windows.Forms.Button()
        Me.btnEsporta = New System.Windows.Forms.Button()
        Me.btnImporta = New System.Windows.Forms.Button()
        Me.btnPratica = New System.Windows.Forms.Button()
        Me.ListBoxDocumenti = New System.Windows.Forms.ListBox()
        Me.btnAllega = New System.Windows.Forms.Button()
        Me.tvPratiche = New System.Windows.Forms.TreeView()
        Me.btnCancella = New System.Windows.Forms.Button()
        Me.btnVisualizzaTutto = New System.Windows.Forms.Button()
        Me.btnNuovaPratica = New System.Windows.Forms.Button()
        Me.CheckBoxStorico = New System.Windows.Forms.CheckBox()
        Me.SplitContainerAnteprima = New System.Windows.Forms.SplitContainer()
        Me.ToolStripAnteprima = New System.Windows.Forms.ToolStrip()
        Me.Twain = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain()
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
        Me.PictureBoxLogo = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanelMain = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.TabPageScanner = New System.Windows.Forms.TabPage()
        Me.tlpScan = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpScanner = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonRDP = New System.Windows.Forms.Button()
        Me.ComboBoxSource = New System.Windows.Forms.ComboBox()
        Me.btnSelezionaScanner = New System.Windows.Forms.Button()
        Me.ComboBoxRisoluzione = New System.Windows.Forms.ComboBox()
        Me.ComboBoxFormato = New System.Windows.Forms.ComboBox()
        Me.rbColori = New System.Windows.Forms.RadioButton()
        Me.rbScalaGrigi = New System.Windows.Forms.RadioButton()
        Me.rbBianoNero = New System.Windows.Forms.RadioButton()
        Me.chkDuplex = New System.Windows.Forms.CheckBox()
        Me.LabelChiaroScuro = New System.Windows.Forms.Label()
        Me.tbChiaroScuro = New System.Windows.Forms.TrackBar()
        Me.btnScanNuovo = New System.Windows.Forms.Button()
        Me.btnScanAggiungi = New System.Windows.Forms.Button()
        Me.btnFineDoc = New System.Windows.Forms.Button()
        Me.LabelStato = New System.Windows.Forms.Label()
        Me.LabelBianco = New System.Windows.Forms.Label()
        Me.LabelGrigi = New System.Windows.Forms.Label()
        Me.LabelColore = New System.Windows.Forms.Label()
        Me.txtChiaroScuro = New System.Windows.Forms.TextBox()
        Me.LabelNero = New System.Windows.Forms.Label()
        Me.btnScannerRete = New System.Windows.Forms.Button()
        Me.ButtonCartellaRete = New System.Windows.Forms.Button()
        Me.LinkLabelPDF = New System.Windows.Forms.LinkLabel()
        Me.TabPageModifica = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanelModifica = New System.Windows.Forms.TableLayoutPanel()
        Me.btnEditor = New System.Windows.Forms.Button()
        Me.btnEliminaPagina = New System.Windows.Forms.Button()
        Me.btnConvertiFormato = New System.Windows.Forms.Button()
        Me.TabPageOpzioni = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanelStorico = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonCercaDocumenti = New System.Windows.Forms.Button()
        Me.GroupBoxSertel = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCercaSertel = New System.Windows.Forms.Button()
        Me.btnInviaSertel = New System.Windows.Forms.Button()
        Me.CheckBoxRinominaFile = New System.Windows.Forms.CheckBox()
        Me.ComboBoxTipoDoc = New System.Windows.Forms.ComboBox()
        Me.lbHelpSertel = New System.Windows.Forms.Label()
        Me.dtpDataArrivoDoc = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBoxEsci = New System.Windows.Forms.GroupBox()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TimerScanner = New System.Windows.Forms.Timer(Me.components)
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        Me.TableLayoutPanelEsploraDoc.SuspendLayout()
        CType(Me.SplitContainerAnteprima, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerAnteprima.Panel1.SuspendLayout()
        Me.SplitContainerAnteprima.Panel2.SuspendLayout()
        Me.SplitContainerAnteprima.SuspendLayout()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanelMain.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
        Me.TabPageScanner.SuspendLayout()
        Me.tlpScan.SuspendLayout()
        Me.tlpScanner.SuspendLayout()
        CType(Me.tbChiaroScuro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageModifica.SuspendLayout()
        Me.TableLayoutPanelModifica.SuspendLayout()
        Me.TabPageOpzioni.SuspendLayout()
        Me.TableLayoutPanelStorico.SuspendLayout()
        Me.GroupBoxSertel.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.GroupBoxEsci.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMain.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainerMain.Name = "SplitContainerMain"
        '
        'SplitContainerMain.Panel1
        '
        Me.SplitContainerMain.Panel1.Controls.Add(Me.TableLayoutPanelEsploraDoc)
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.Controls.Add(Me.SplitContainerAnteprima)
        Me.SplitContainerMain.Size = New System.Drawing.Size(765, 560)
        Me.SplitContainerMain.SplitterDistance = 235
        Me.SplitContainerMain.TabIndex = 4
        '
        'TableLayoutPanelEsploraDoc
        '
        Me.TableLayoutPanelEsploraDoc.ColumnCount = 3
        Me.TableLayoutPanelEsploraDoc.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanelEsploraDoc.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanelEsploraDoc.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanelEsploraDoc.Controls.Add(Me.ButtonRecupera, 1, 2)
        Me.TableLayoutPanelEsploraDoc.Controls.Add(Me.ButtonSetStorico, 2, 2)
        Me.TableLayoutPanelEsploraDoc.Controls.Add(Me.btnRinomina, 2, 3)
        Me.TableLayoutPanelEsploraDoc.Controls.Add(Me.btnApri, 1, 4)
        Me.TableLayoutPanelEsploraDoc.Controls.Add(Me.btnEsporta, 1, 3)
        Me.TableLayoutPanelEsploraDoc.Controls.Add(Me.btnImporta, 0, 3)
        Me.TableLayoutPanelEsploraDoc.Controls.Add(Me.btnPratica, 0, 0)
        Me.TableLayoutPanelEsploraDoc.Controls.Add(Me.ListBoxDocumenti, 0, 1)
        Me.TableLayoutPanelEsploraDoc.Controls.Add(Me.btnAllega, 0, 4)
        Me.TableLayoutPanelEsploraDoc.Controls.Add(Me.tvPratiche, 0, 5)
        Me.TableLayoutPanelEsploraDoc.Controls.Add(Me.btnCancella, 2, 4)
        Me.TableLayoutPanelEsploraDoc.Controls.Add(Me.btnVisualizzaTutto, 1, 7)
        Me.TableLayoutPanelEsploraDoc.Controls.Add(Me.btnNuovaPratica, 0, 7)
        Me.TableLayoutPanelEsploraDoc.Controls.Add(Me.CheckBoxStorico, 0, 2)
        Me.TableLayoutPanelEsploraDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelEsploraDoc.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelEsploraDoc.Name = "TableLayoutPanelEsploraDoc"
        Me.TableLayoutPanelEsploraDoc.RowCount = 8
        Me.TableLayoutPanelEsploraDoc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905!))
        Me.TableLayoutPanelEsploraDoc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.61905!))
        Me.TableLayoutPanelEsploraDoc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905!))
        Me.TableLayoutPanelEsploraDoc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905!))
        Me.TableLayoutPanelEsploraDoc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905!))
        Me.TableLayoutPanelEsploraDoc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952!))
        Me.TableLayoutPanelEsploraDoc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905!))
        Me.TableLayoutPanelEsploraDoc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905!))
        Me.TableLayoutPanelEsploraDoc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelEsploraDoc.Size = New System.Drawing.Size(235, 560)
        Me.TableLayoutPanelEsploraDoc.TabIndex = 6
        '
        'ButtonRecupera
        '
        Me.ButtonRecupera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonRecupera.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonRecupera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRecupera.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonRecupera.Location = New System.Drawing.Point(81, 295)
        Me.ButtonRecupera.Name = "ButtonRecupera"
        Me.ButtonRecupera.Size = New System.Drawing.Size(72, 20)
        Me.ButtonRecupera.TabIndex = 13
        Me.ButtonRecupera.Text = "Recupera"
        Me.ButtonRecupera.UseVisualStyleBackColor = True
        '
        'ButtonSetStorico
        '
        Me.ButtonSetStorico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSetStorico.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonSetStorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSetStorico.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSetStorico.Location = New System.Drawing.Point(159, 295)
        Me.ButtonSetStorico.Name = "ButtonSetStorico"
        Me.ButtonSetStorico.Size = New System.Drawing.Size(73, 20)
        Me.ButtonSetStorico.TabIndex = 11
        Me.ButtonSetStorico.Text = "Imposta storico"
        Me.ButtonSetStorico.UseVisualStyleBackColor = True
        '
        'btnRinomina
        '
        Me.btnRinomina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRinomina.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnRinomina.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRinomina.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRinomina.Location = New System.Drawing.Point(159, 321)
        Me.btnRinomina.Name = "btnRinomina"
        Me.btnRinomina.Size = New System.Drawing.Size(73, 20)
        Me.btnRinomina.TabIndex = 3
        Me.btnRinomina.Text = "Rinomina"
        Me.btnRinomina.UseVisualStyleBackColor = True
        '
        'btnApri
        '
        Me.btnApri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnApri.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnApri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApri.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApri.Location = New System.Drawing.Point(81, 347)
        Me.btnApri.Name = "btnApri"
        Me.btnApri.Size = New System.Drawing.Size(72, 20)
        Me.btnApri.TabIndex = 5
        Me.btnApri.Text = "Apri"
        Me.btnApri.UseVisualStyleBackColor = True
        '
        'btnEsporta
        '
        Me.btnEsporta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsporta.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnEsporta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEsporta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEsporta.Location = New System.Drawing.Point(81, 321)
        Me.btnEsporta.Name = "btnEsporta"
        Me.btnEsporta.Size = New System.Drawing.Size(72, 20)
        Me.btnEsporta.TabIndex = 2
        Me.btnEsporta.Text = "Esporta"
        Me.btnEsporta.UseVisualStyleBackColor = True
        '
        'btnImporta
        '
        Me.btnImporta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnImporta.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnImporta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImporta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImporta.Location = New System.Drawing.Point(3, 321)
        Me.btnImporta.Name = "btnImporta"
        Me.btnImporta.Size = New System.Drawing.Size(72, 20)
        Me.btnImporta.TabIndex = 1
        Me.btnImporta.Text = "Importa"
        Me.btnImporta.UseVisualStyleBackColor = True
        '
        'btnPratica
        '
        Me.btnPratica.BackColor = System.Drawing.Color.Khaki
        Me.TableLayoutPanelEsploraDoc.SetColumnSpan(Me.btnPratica, 3)
        Me.btnPratica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnPratica.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPratica.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPratica.Location = New System.Drawing.Point(3, 3)
        Me.btnPratica.Name = "btnPratica"
        Me.btnPratica.Size = New System.Drawing.Size(229, 20)
        Me.btnPratica.TabIndex = 3
        Me.btnPratica.Text = "Button1"
        Me.btnPratica.UseVisualStyleBackColor = False
        '
        'ListBoxDocumenti
        '
        Me.TableLayoutPanelEsploraDoc.SetColumnSpan(Me.ListBoxDocumenti, 3)
        Me.ListBoxDocumenti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxDocumenti.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxDocumenti.FormattingEnabled = True
        Me.ListBoxDocumenti.IntegralHeight = False
        Me.ListBoxDocumenti.ItemHeight = 16
        Me.ListBoxDocumenti.Location = New System.Drawing.Point(3, 29)
        Me.ListBoxDocumenti.Name = "ListBoxDocumenti"
        Me.ListBoxDocumenti.Size = New System.Drawing.Size(229, 260)
        Me.ListBoxDocumenti.TabIndex = 0
        '
        'btnAllega
        '
        Me.btnAllega.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAllega.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnAllega.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAllega.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllega.Location = New System.Drawing.Point(3, 347)
        Me.btnAllega.Name = "btnAllega"
        Me.btnAllega.Size = New System.Drawing.Size(72, 20)
        Me.btnAllega.TabIndex = 4
        Me.btnAllega.Text = "Allega mail"
        Me.btnAllega.UseVisualStyleBackColor = True
        '
        'tvPratiche
        '
        Me.tvPratiche.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanelEsploraDoc.SetColumnSpan(Me.tvPratiche, 3)
        Me.tvPratiche.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvPratiche.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvPratiche.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tvPratiche.Location = New System.Drawing.Point(3, 373)
        Me.tvPratiche.Name = "tvPratiche"
        Me.TableLayoutPanelEsploraDoc.SetRowSpan(Me.tvPratiche, 2)
        Me.tvPratiche.Size = New System.Drawing.Size(229, 153)
        Me.tvPratiche.TabIndex = 7
        '
        'btnCancella
        '
        Me.btnCancella.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancella.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnCancella.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancella.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancella.Location = New System.Drawing.Point(159, 347)
        Me.btnCancella.Name = "btnCancella"
        Me.btnCancella.Size = New System.Drawing.Size(73, 20)
        Me.btnCancella.TabIndex = 6
        Me.btnCancella.Text = "Elimina"
        Me.btnCancella.UseVisualStyleBackColor = True
        '
        'btnVisualizzaTutto
        '
        Me.TableLayoutPanelEsploraDoc.SetColumnSpan(Me.btnVisualizzaTutto, 2)
        Me.btnVisualizzaTutto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVisualizzaTutto.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnVisualizzaTutto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVisualizzaTutto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVisualizzaTutto.Location = New System.Drawing.Point(81, 532)
        Me.btnVisualizzaTutto.Name = "btnVisualizzaTutto"
        Me.btnVisualizzaTutto.Size = New System.Drawing.Size(151, 25)
        Me.btnVisualizzaTutto.TabIndex = 8
        Me.btnVisualizzaTutto.Text = "Tutte le pratiche"
        Me.btnVisualizzaTutto.UseVisualStyleBackColor = True
        '
        'btnNuovaPratica
        '
        Me.btnNuovaPratica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNuovaPratica.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnNuovaPratica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuovaPratica.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuovaPratica.Location = New System.Drawing.Point(3, 532)
        Me.btnNuovaPratica.Name = "btnNuovaPratica"
        Me.btnNuovaPratica.Size = New System.Drawing.Size(72, 25)
        Me.btnNuovaPratica.TabIndex = 9
        Me.btnNuovaPratica.Text = "Nuova cartella"
        Me.btnNuovaPratica.UseVisualStyleBackColor = True
        '
        'CheckBoxStorico
        '
        Me.CheckBoxStorico.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxStorico.AutoSize = True
        Me.CheckBoxStorico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxStorico.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.CheckBoxStorico.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CheckBoxStorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxStorico.Location = New System.Drawing.Point(3, 295)
        Me.CheckBoxStorico.Name = "CheckBoxStorico"
        Me.CheckBoxStorico.Size = New System.Drawing.Size(72, 20)
        Me.CheckBoxStorico.TabIndex = 12
        Me.CheckBoxStorico.Text = "Vai a storico"
        Me.CheckBoxStorico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxStorico.UseVisualStyleBackColor = True
        '
        'SplitContainerAnteprima
        '
        Me.SplitContainerAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerAnteprima.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerAnteprima.Name = "SplitContainerAnteprima"
        Me.SplitContainerAnteprima.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerAnteprima.Panel1
        '
        Me.SplitContainerAnteprima.Panel1.Controls.Add(Me.ToolStripAnteprima)
        '
        'SplitContainerAnteprima.Panel2
        '
        Me.SplitContainerAnteprima.Panel2.Controls.Add(Me.Twain)
        Me.SplitContainerAnteprima.Panel2.Controls.Add(Me.AxAcroPDF1)
        Me.SplitContainerAnteprima.Panel2.Controls.Add(Me.PictureBoxLogo)
        Me.SplitContainerAnteprima.Size = New System.Drawing.Size(526, 560)
        Me.SplitContainerAnteprima.SplitterDistance = 27
        Me.SplitContainerAnteprima.TabIndex = 0
        '
        'ToolStripAnteprima
        '
        Me.ToolStripAnteprima.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripAnteprima.Name = "ToolStripAnteprima"
        Me.ToolStripAnteprima.Size = New System.Drawing.Size(526, 25)
        Me.ToolStripAnteprima.TabIndex = 0
        Me.ToolStripAnteprima.Text = "ToolStrip1"
        '
        'Twain
        '
        Me.Twain.AnnotationFillColor = System.Drawing.Color.White
        Me.Twain.AnnotationPen = Nothing
        Me.Twain.AnnotationTextColor = System.Drawing.Color.Black
        Me.Twain.AnnotationTextFont = Nothing
        Me.Twain.IfShowPrintUI = False
        Me.Twain.IfThrowException = False
        Me.Twain.Location = New System.Drawing.Point(0, 0)
        Me.Twain.LogLevel = CType(0, Short)
        Me.Twain.Name = "Twain"
        Me.Twain.PDFMarginBottom = CType(0UI, UInteger)
        Me.Twain.PDFMarginLeft = CType(0UI, UInteger)
        Me.Twain.PDFMarginRight = CType(0UI, UInteger)
        Me.Twain.PDFMarginTop = CType(0UI, UInteger)
        Me.Twain.PDFXConformance = CType(0UI, UInteger)
        Me.Twain.ProductFamily = "Dynamic .NET TWAIN (.NET Framewor"
        Me.Twain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Twain.Size = New System.Drawing.Size(150, 150)
        Me.Twain.TabIndex = 6
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(311, 128)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(129, 151)
        Me.AxAcroPDF1.TabIndex = 5
        '
        'PictureBoxLogo
        '
        Me.PictureBoxLogo.Location = New System.Drawing.Point(29, 128)
        Me.PictureBoxLogo.Name = "PictureBoxLogo"
        Me.PictureBoxLogo.Size = New System.Drawing.Size(246, 189)
        Me.PictureBoxLogo.TabIndex = 4
        Me.PictureBoxLogo.TabStop = False
        '
        'TableLayoutPanelMain
        '
        Me.TableLayoutPanelMain.ColumnCount = 2
        Me.TableLayoutPanelMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.30222!))
        Me.TableLayoutPanelMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.69779!))
        Me.TableLayoutPanelMain.Controls.Add(Me.TabControlMain, 1, 0)
        Me.TableLayoutPanelMain.Controls.Add(Me.SplitContainerMain, 0, 0)
        Me.TableLayoutPanelMain.Controls.Add(Me.GroupBoxSertel, 0, 1)
        Me.TableLayoutPanelMain.Controls.Add(Me.GroupBoxEsci, 1, 1)
        Me.TableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelMain.Name = "TableLayoutPanelMain"
        Me.TableLayoutPanelMain.RowCount = 2
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.90936!))
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.09064!))
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelMain.Size = New System.Drawing.Size(1039, 709)
        Me.TableLayoutPanelMain.TabIndex = 5
        '
        'TabControlMain
        '
        Me.TabControlMain.Controls.Add(Me.TabPageScanner)
        Me.TabControlMain.Controls.Add(Me.TabPageModifica)
        Me.TabControlMain.Controls.Add(Me.TabPageOpzioni)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlMain.HotTrack = True
        Me.TabControlMain.Location = New System.Drawing.Point(774, 3)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.Padding = New System.Drawing.Point(0, 0)
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(262, 560)
        Me.TabControlMain.TabIndex = 3
        '
        'TabPageScanner
        '
        Me.TabPageScanner.Controls.Add(Me.tlpScan)
        Me.TabPageScanner.Location = New System.Drawing.Point(4, 25)
        Me.TabPageScanner.Name = "TabPageScanner"
        Me.TabPageScanner.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageScanner.Size = New System.Drawing.Size(254, 531)
        Me.TabPageScanner.TabIndex = 0
        Me.TabPageScanner.Text = "Scanner"
        Me.TabPageScanner.UseVisualStyleBackColor = True
        '
        'tlpScan
        '
        Me.tlpScan.BackColor = System.Drawing.Color.Transparent
        Me.tlpScan.ColumnCount = 2
        Me.tlpScan.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.tlpScan.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpScan.Controls.Add(Me.tlpScanner, 0, 0)
        Me.tlpScan.Controls.Add(Me.btnScannerRete, 0, 2)
        Me.tlpScan.Controls.Add(Me.ButtonCartellaRete, 1, 2)
        Me.tlpScan.Controls.Add(Me.LinkLabelPDF, 0, 1)
        Me.tlpScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpScan.Location = New System.Drawing.Point(3, 3)
        Me.tlpScan.Name = "tlpScan"
        Me.tlpScan.RowCount = 3
        Me.tlpScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpScan.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.tlpScan.Size = New System.Drawing.Size(248, 525)
        Me.tlpScan.TabIndex = 5
        '
        'tlpScanner
        '
        Me.tlpScanner.ColumnCount = 3
        Me.tlpScan.SetColumnSpan(Me.tlpScanner, 2)
        Me.tlpScanner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.tlpScanner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpScanner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpScanner.Controls.Add(Me.ButtonRDP, 1, 9)
        Me.tlpScanner.Controls.Add(Me.ComboBoxSource, 0, 0)
        Me.tlpScanner.Controls.Add(Me.btnSelezionaScanner, 1, 0)
        Me.tlpScanner.Controls.Add(Me.ComboBoxRisoluzione, 0, 1)
        Me.tlpScanner.Controls.Add(Me.ComboBoxFormato, 0, 2)
        Me.tlpScanner.Controls.Add(Me.rbColori, 0, 5)
        Me.tlpScanner.Controls.Add(Me.rbScalaGrigi, 0, 4)
        Me.tlpScanner.Controls.Add(Me.rbBianoNero, 0, 3)
        Me.tlpScanner.Controls.Add(Me.chkDuplex, 0, 6)
        Me.tlpScanner.Controls.Add(Me.LabelChiaroScuro, 0, 7)
        Me.tlpScanner.Controls.Add(Me.tbChiaroScuro, 0, 8)
        Me.tlpScanner.Controls.Add(Me.btnScanNuovo, 0, 9)
        Me.tlpScanner.Controls.Add(Me.btnScanAggiungi, 0, 10)
        Me.tlpScanner.Controls.Add(Me.btnFineDoc, 0, 11)
        Me.tlpScanner.Controls.Add(Me.LabelStato, 0, 12)
        Me.tlpScanner.Controls.Add(Me.LabelBianco, 1, 3)
        Me.tlpScanner.Controls.Add(Me.LabelGrigi, 1, 4)
        Me.tlpScanner.Controls.Add(Me.LabelColore, 1, 5)
        Me.tlpScanner.Controls.Add(Me.txtChiaroScuro, 1, 8)
        Me.tlpScanner.Controls.Add(Me.LabelNero, 2, 3)
        Me.tlpScanner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpScanner.Location = New System.Drawing.Point(3, 3)
        Me.tlpScanner.Name = "tlpScanner"
        Me.tlpScanner.RowCount = 13
        Me.tlpScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlpScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlpScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlpScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlpScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlpScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlpScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpScanner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpScanner.Size = New System.Drawing.Size(242, 449)
        Me.tlpScanner.TabIndex = 24
        '
        'ButtonRDP
        '
        Me.tlpScanner.SetColumnSpan(Me.ButtonRDP, 2)
        Me.ButtonRDP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonRDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRDP.Location = New System.Drawing.Point(196, 303)
        Me.ButtonRDP.Name = "ButtonRDP"
        Me.ButtonRDP.Size = New System.Drawing.Size(43, 33)
        Me.ButtonRDP.TabIndex = 18
        Me.ButtonRDP.Text = "RDP"
        Me.ButtonRDP.UseVisualStyleBackColor = True
        '
        'ComboBoxSource
        '
        Me.ComboBoxSource.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxSource.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxSource.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxSource.FormattingEnabled = True
        Me.ComboBoxSource.Location = New System.Drawing.Point(3, 5)
        Me.ComboBoxSource.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.ComboBoxSource.Name = "ComboBoxSource"
        Me.ComboBoxSource.Size = New System.Drawing.Size(187, 22)
        Me.ComboBoxSource.TabIndex = 0
        '
        'btnSelezionaScanner
        '
        Me.tlpScanner.SetColumnSpan(Me.btnSelezionaScanner, 2)
        Me.btnSelezionaScanner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSelezionaScanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelezionaScanner.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelezionaScanner.Location = New System.Drawing.Point(196, 5)
        Me.btnSelezionaScanner.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.btnSelezionaScanner.Name = "btnSelezionaScanner"
        Me.btnSelezionaScanner.Size = New System.Drawing.Size(43, 22)
        Me.btnSelezionaScanner.TabIndex = 1
        Me.btnSelezionaScanner.Text = "..."
        Me.btnSelezionaScanner.UseVisualStyleBackColor = True
        '
        'ComboBoxRisoluzione
        '
        Me.tlpScanner.SetColumnSpan(Me.ComboBoxRisoluzione, 3)
        Me.ComboBoxRisoluzione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxRisoluzione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxRisoluzione.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxRisoluzione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxRisoluzione.FormattingEnabled = True
        Me.ComboBoxRisoluzione.Location = New System.Drawing.Point(3, 35)
        Me.ComboBoxRisoluzione.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.ComboBoxRisoluzione.Name = "ComboBoxRisoluzione"
        Me.ComboBoxRisoluzione.Size = New System.Drawing.Size(236, 22)
        Me.ComboBoxRisoluzione.TabIndex = 2
        '
        'ComboBoxFormato
        '
        Me.tlpScanner.SetColumnSpan(Me.ComboBoxFormato, 3)
        Me.ComboBoxFormato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxFormato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxFormato.FormattingEnabled = True
        Me.ComboBoxFormato.Location = New System.Drawing.Point(3, 65)
        Me.ComboBoxFormato.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.ComboBoxFormato.Name = "ComboBoxFormato"
        Me.ComboBoxFormato.Size = New System.Drawing.Size(236, 22)
        Me.ComboBoxFormato.TabIndex = 3
        '
        'rbColori
        '
        Me.rbColori.AutoSize = True
        Me.rbColori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbColori.ForeColor = System.Drawing.Color.DodgerBlue
        Me.rbColori.Location = New System.Drawing.Point(3, 163)
        Me.rbColori.Name = "rbColori"
        Me.rbColori.Size = New System.Drawing.Size(187, 29)
        Me.rbColori.TabIndex = 6
        Me.rbColori.TabStop = True
        Me.rbColori.Text = "Scansione a colori"
        Me.rbColori.UseVisualStyleBackColor = True
        '
        'rbScalaGrigi
        '
        Me.rbScalaGrigi.AutoSize = True
        Me.rbScalaGrigi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbScalaGrigi.ForeColor = System.Drawing.Color.DimGray
        Me.rbScalaGrigi.Location = New System.Drawing.Point(3, 128)
        Me.rbScalaGrigi.Name = "rbScalaGrigi"
        Me.rbScalaGrigi.Size = New System.Drawing.Size(187, 29)
        Me.rbScalaGrigi.TabIndex = 5
        Me.rbScalaGrigi.TabStop = True
        Me.rbScalaGrigi.Text = "Scansione in scala di grigi"
        Me.rbScalaGrigi.UseVisualStyleBackColor = True
        '
        'rbBianoNero
        '
        Me.rbBianoNero.AutoSize = True
        Me.rbBianoNero.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbBianoNero.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbBianoNero.Location = New System.Drawing.Point(3, 93)
        Me.rbBianoNero.Name = "rbBianoNero"
        Me.rbBianoNero.Size = New System.Drawing.Size(187, 29)
        Me.rbBianoNero.TabIndex = 4
        Me.rbBianoNero.TabStop = True
        Me.rbBianoNero.Text = "Scansione in Bianco e Nero"
        Me.rbBianoNero.UseVisualStyleBackColor = True
        '
        'chkDuplex
        '
        Me.chkDuplex.AutoSize = True
        Me.tlpScanner.SetColumnSpan(Me.chkDuplex, 3)
        Me.chkDuplex.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkDuplex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkDuplex.Location = New System.Drawing.Point(3, 198)
        Me.chkDuplex.Name = "chkDuplex"
        Me.chkDuplex.Size = New System.Drawing.Size(236, 29)
        Me.chkDuplex.TabIndex = 7
        Me.chkDuplex.Text = "Fronte/Retro"
        Me.chkDuplex.UseVisualStyleBackColor = True
        '
        'LabelChiaroScuro
        '
        Me.LabelChiaroScuro.BackColor = System.Drawing.SystemColors.Control
        Me.tlpScanner.SetColumnSpan(Me.LabelChiaroScuro, 3)
        Me.LabelChiaroScuro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelChiaroScuro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelChiaroScuro.Location = New System.Drawing.Point(3, 230)
        Me.LabelChiaroScuro.Name = "LabelChiaroScuro"
        Me.LabelChiaroScuro.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.LabelChiaroScuro.Size = New System.Drawing.Size(236, 35)
        Me.LabelChiaroScuro.TabIndex = 8
        Me.LabelChiaroScuro.Text = "Regola Chiaro/Scuro"
        Me.LabelChiaroScuro.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbChiaroScuro
        '
        Me.tbChiaroScuro.BackColor = System.Drawing.Color.Gainsboro
        Me.tbChiaroScuro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbChiaroScuro.Location = New System.Drawing.Point(3, 268)
        Me.tbChiaroScuro.Name = "tbChiaroScuro"
        Me.tbChiaroScuro.Size = New System.Drawing.Size(187, 29)
        Me.tbChiaroScuro.TabIndex = 9
        '
        'btnScanNuovo
        '
        Me.btnScanNuovo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnScanNuovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScanNuovo.Location = New System.Drawing.Point(3, 303)
        Me.btnScanNuovo.Name = "btnScanNuovo"
        Me.btnScanNuovo.Size = New System.Drawing.Size(187, 33)
        Me.btnScanNuovo.TabIndex = 0
        Me.btnScanNuovo.Text = "Acquisisci nuovo documento"
        Me.btnScanNuovo.UseVisualStyleBackColor = True
        '
        'btnScanAggiungi
        '
        Me.tlpScanner.SetColumnSpan(Me.btnScanAggiungi, 3)
        Me.btnScanAggiungi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnScanAggiungi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScanAggiungi.Location = New System.Drawing.Point(3, 342)
        Me.btnScanAggiungi.Name = "btnScanAggiungi"
        Me.btnScanAggiungi.Size = New System.Drawing.Size(236, 33)
        Me.btnScanAggiungi.TabIndex = 1
        Me.btnScanAggiungi.Text = "Acquisisci e aggiungi al documento selezionato"
        Me.btnScanAggiungi.UseVisualStyleBackColor = True
        '
        'btnFineDoc
        '
        Me.tlpScanner.SetColumnSpan(Me.btnFineDoc, 3)
        Me.btnFineDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnFineDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFineDoc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFineDoc.Location = New System.Drawing.Point(3, 381)
        Me.btnFineDoc.Name = "btnFineDoc"
        Me.btnFineDoc.Size = New System.Drawing.Size(236, 33)
        Me.btnFineDoc.TabIndex = 4
        Me.btnFineDoc.Text = "Fine documento"
        Me.btnFineDoc.UseVisualStyleBackColor = True
        '
        'LabelStato
        '
        Me.LabelStato.BackColor = System.Drawing.SystemColors.Control
        Me.LabelStato.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tlpScanner.SetColumnSpan(Me.LabelStato, 3)
        Me.LabelStato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelStato.Location = New System.Drawing.Point(3, 417)
        Me.LabelStato.Name = "LabelStato"
        Me.LabelStato.Size = New System.Drawing.Size(236, 32)
        Me.LabelStato.TabIndex = 5
        Me.LabelStato.Text = "LabelStato"
        Me.LabelStato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelBianco
        '
        Me.LabelBianco.AutoSize = True
        Me.LabelBianco.BackColor = System.Drawing.Color.White
        Me.LabelBianco.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelBianco.Location = New System.Drawing.Point(193, 102)
        Me.LabelBianco.Margin = New System.Windows.Forms.Padding(0, 12, 0, 12)
        Me.LabelBianco.Name = "LabelBianco"
        Me.LabelBianco.Size = New System.Drawing.Size(24, 11)
        Me.LabelBianco.TabIndex = 11
        '
        'LabelGrigi
        '
        Me.LabelGrigi.AutoSize = True
        Me.LabelGrigi.BackColor = System.Drawing.Color.LightGray
        Me.tlpScanner.SetColumnSpan(Me.LabelGrigi, 2)
        Me.LabelGrigi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelGrigi.Location = New System.Drawing.Point(193, 137)
        Me.LabelGrigi.Margin = New System.Windows.Forms.Padding(0, 12, 1, 12)
        Me.LabelGrigi.Name = "LabelGrigi"
        Me.LabelGrigi.Size = New System.Drawing.Size(48, 11)
        Me.LabelGrigi.TabIndex = 13
        '
        'LabelColore
        '
        Me.LabelColore.AutoSize = True
        Me.LabelColore.BackColor = System.Drawing.Color.LightSeaGreen
        Me.tlpScanner.SetColumnSpan(Me.LabelColore, 2)
        Me.LabelColore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelColore.Location = New System.Drawing.Point(193, 172)
        Me.LabelColore.Margin = New System.Windows.Forms.Padding(0, 12, 1, 12)
        Me.LabelColore.Name = "LabelColore"
        Me.LabelColore.Size = New System.Drawing.Size(48, 11)
        Me.LabelColore.TabIndex = 15
        '
        'txtChiaroScuro
        '
        Me.txtChiaroScuro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpScanner.SetColumnSpan(Me.txtChiaroScuro, 2)
        Me.txtChiaroScuro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChiaroScuro.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiaroScuro.Location = New System.Drawing.Point(196, 268)
        Me.txtChiaroScuro.Name = "txtChiaroScuro"
        Me.txtChiaroScuro.Size = New System.Drawing.Size(43, 30)
        Me.txtChiaroScuro.TabIndex = 16
        Me.txtChiaroScuro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelNero
        '
        Me.LabelNero.AutoSize = True
        Me.LabelNero.BackColor = System.Drawing.Color.Black
        Me.LabelNero.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelNero.Location = New System.Drawing.Point(217, 102)
        Me.LabelNero.Margin = New System.Windows.Forms.Padding(0, 12, 1, 12)
        Me.LabelNero.Name = "LabelNero"
        Me.LabelNero.Size = New System.Drawing.Size(24, 11)
        Me.LabelNero.TabIndex = 17
        '
        'btnScannerRete
        '
        Me.btnScannerRete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnScannerRete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScannerRete.Location = New System.Drawing.Point(3, 483)
        Me.btnScannerRete.Name = "btnScannerRete"
        Me.btnScannerRete.Size = New System.Drawing.Size(180, 39)
        Me.btnScannerRete.TabIndex = 6
        Me.btnScannerRete.Text = "scanner di rete"
        Me.btnScannerRete.UseVisualStyleBackColor = True
        '
        'ButtonCartellaRete
        '
        Me.ButtonCartellaRete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCartellaRete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCartellaRete.Location = New System.Drawing.Point(189, 483)
        Me.ButtonCartellaRete.Name = "ButtonCartellaRete"
        Me.ButtonCartellaRete.Size = New System.Drawing.Size(56, 39)
        Me.ButtonCartellaRete.TabIndex = 7
        Me.ButtonCartellaRete.Text = "Button1"
        Me.ButtonCartellaRete.UseVisualStyleBackColor = True
        '
        'LinkLabelPDF
        '
        Me.LinkLabelPDF.AutoSize = True
        Me.tlpScan.SetColumnSpan(Me.LinkLabelPDF, 2)
        Me.LinkLabelPDF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LinkLabelPDF.Location = New System.Drawing.Point(3, 455)
        Me.LinkLabelPDF.Name = "LinkLabelPDF"
        Me.LinkLabelPDF.Size = New System.Drawing.Size(242, 25)
        Me.LinkLabelPDF.TabIndex = 25
        Me.LinkLabelPDF.TabStop = True
        Me.LinkLabelPDF.Text = "Utilità gestione PDF"
        Me.LinkLabelPDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPageModifica
        '
        Me.TabPageModifica.Controls.Add(Me.TableLayoutPanelModifica)
        Me.TabPageModifica.Location = New System.Drawing.Point(4, 25)
        Me.TabPageModifica.Name = "TabPageModifica"
        Me.TabPageModifica.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageModifica.Size = New System.Drawing.Size(254, 531)
        Me.TabPageModifica.TabIndex = 1
        Me.TabPageModifica.Text = "Modifica"
        Me.TabPageModifica.UseVisualStyleBackColor = True
        '
        'TableLayoutPanelModifica
        '
        Me.TableLayoutPanelModifica.ColumnCount = 4
        Me.TableLayoutPanelModifica.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelModifica.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelModifica.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelModifica.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelModifica.Controls.Add(Me.btnEditor, 0, 0)
        Me.TableLayoutPanelModifica.Controls.Add(Me.btnEliminaPagina, 0, 1)
        Me.TableLayoutPanelModifica.Controls.Add(Me.btnConvertiFormato, 0, 2)
        Me.TableLayoutPanelModifica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelModifica.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanelModifica.Name = "TableLayoutPanelModifica"
        Me.TableLayoutPanelModifica.RowCount = 10
        Me.TableLayoutPanelModifica.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelModifica.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelModifica.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelModifica.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelModifica.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelModifica.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelModifica.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelModifica.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelModifica.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelModifica.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelModifica.Size = New System.Drawing.Size(248, 525)
        Me.TableLayoutPanelModifica.TabIndex = 0
        '
        'btnEditor
        '
        Me.TableLayoutPanelModifica.SetColumnSpan(Me.btnEditor, 4)
        Me.btnEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEditor.Location = New System.Drawing.Point(3, 3)
        Me.btnEditor.Name = "btnEditor"
        Me.btnEditor.Size = New System.Drawing.Size(242, 46)
        Me.btnEditor.TabIndex = 0
        Me.btnEditor.Text = "Button1"
        Me.btnEditor.UseVisualStyleBackColor = True
        '
        'btnEliminaPagina
        '
        Me.TableLayoutPanelModifica.SetColumnSpan(Me.btnEliminaPagina, 4)
        Me.btnEliminaPagina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEliminaPagina.Location = New System.Drawing.Point(3, 55)
        Me.btnEliminaPagina.Name = "btnEliminaPagina"
        Me.btnEliminaPagina.Size = New System.Drawing.Size(242, 46)
        Me.btnEliminaPagina.TabIndex = 1
        Me.btnEliminaPagina.Text = "Button2"
        Me.btnEliminaPagina.UseVisualStyleBackColor = True
        '
        'btnConvertiFormato
        '
        Me.TableLayoutPanelModifica.SetColumnSpan(Me.btnConvertiFormato, 4)
        Me.btnConvertiFormato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnConvertiFormato.Location = New System.Drawing.Point(3, 107)
        Me.btnConvertiFormato.Name = "btnConvertiFormato"
        Me.btnConvertiFormato.Size = New System.Drawing.Size(242, 46)
        Me.btnConvertiFormato.TabIndex = 2
        Me.btnConvertiFormato.Text = "Button3"
        Me.btnConvertiFormato.UseVisualStyleBackColor = True
        '
        'TabPageOpzioni
        '
        Me.TabPageOpzioni.Controls.Add(Me.TableLayoutPanelStorico)
        Me.TabPageOpzioni.Location = New System.Drawing.Point(4, 25)
        Me.TabPageOpzioni.Name = "TabPageOpzioni"
        Me.TabPageOpzioni.Size = New System.Drawing.Size(254, 531)
        Me.TabPageOpzioni.TabIndex = 2
        Me.TabPageOpzioni.Text = "Opzioni"
        Me.TabPageOpzioni.UseVisualStyleBackColor = True
        '
        'TableLayoutPanelStorico
        '
        Me.TableLayoutPanelStorico.ColumnCount = 4
        Me.TableLayoutPanelStorico.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelStorico.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelStorico.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelStorico.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelStorico.Controls.Add(Me.ButtonCercaDocumenti, 0, 0)
        Me.TableLayoutPanelStorico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelStorico.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelStorico.Name = "TableLayoutPanelStorico"
        Me.TableLayoutPanelStorico.RowCount = 10
        Me.TableLayoutPanelStorico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelStorico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelStorico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelStorico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelStorico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelStorico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelStorico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelStorico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelStorico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelStorico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelStorico.Size = New System.Drawing.Size(254, 531)
        Me.TableLayoutPanelStorico.TabIndex = 1
        '
        'ButtonCercaDocumenti
        '
        Me.TableLayoutPanelStorico.SetColumnSpan(Me.ButtonCercaDocumenti, 4)
        Me.ButtonCercaDocumenti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCercaDocumenti.Location = New System.Drawing.Point(3, 3)
        Me.ButtonCercaDocumenti.Name = "ButtonCercaDocumenti"
        Me.ButtonCercaDocumenti.Size = New System.Drawing.Size(248, 47)
        Me.ButtonCercaDocumenti.TabIndex = 0
        Me.ButtonCercaDocumenti.Text = "Cerca documenti"
        Me.ButtonCercaDocumenti.UseVisualStyleBackColor = True
        '
        'GroupBoxSertel
        '
        Me.GroupBoxSertel.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupBoxSertel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxSertel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBoxSertel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxSertel.ForeColor = System.Drawing.Color.DarkRed
        Me.GroupBoxSertel.Location = New System.Drawing.Point(3, 569)
        Me.GroupBoxSertel.Name = "GroupBoxSertel"
        Me.GroupBoxSertel.Size = New System.Drawing.Size(765, 137)
        Me.GroupBoxSertel.TabIndex = 6
        Me.GroupBoxSertel.TabStop = False
        Me.GroupBoxSertel.Text = "Liquido - Sertel"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 5
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.99376!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.69451!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.75255!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.05735!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.50183!))
        Me.TableLayoutPanel5.Controls.Add(Me.btnCercaSertel, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.btnInviaSertel, 3, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.CheckBoxRinominaFile, 2, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.ComboBoxTipoDoc, 1, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.lbHelpSertel, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.dtpDataArrivoDoc, 1, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 19)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 4
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(759, 115)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'btnCercaSertel
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.btnCercaSertel, 2)
        Me.btnCercaSertel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCercaSertel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnCercaSertel.Location = New System.Drawing.Point(483, 3)
        Me.btnCercaSertel.Name = "btnCercaSertel"
        Me.TableLayoutPanel5.SetRowSpan(Me.btnCercaSertel, 2)
        Me.btnCercaSertel.Size = New System.Drawing.Size(273, 55)
        Me.btnCercaSertel.TabIndex = 3
        Me.btnCercaSertel.Text = "Button1"
        Me.btnCercaSertel.UseVisualStyleBackColor = True
        '
        'btnInviaSertel
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.btnInviaSertel, 2)
        Me.btnInviaSertel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnInviaSertel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnInviaSertel.Location = New System.Drawing.Point(483, 64)
        Me.btnInviaSertel.Name = "btnInviaSertel"
        Me.TableLayoutPanel5.SetRowSpan(Me.btnInviaSertel, 2)
        Me.btnInviaSertel.Size = New System.Drawing.Size(273, 48)
        Me.btnInviaSertel.TabIndex = 4
        Me.btnInviaSertel.Text = "Button2"
        Me.btnInviaSertel.UseVisualStyleBackColor = True
        '
        'CheckBoxRinominaFile
        '
        Me.CheckBoxRinominaFile.AutoSize = True
        Me.CheckBoxRinominaFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxRinominaFile.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBoxRinominaFile.Location = New System.Drawing.Point(265, 91)
        Me.CheckBoxRinominaFile.Name = "CheckBoxRinominaFile"
        Me.CheckBoxRinominaFile.Size = New System.Drawing.Size(212, 21)
        Me.CheckBoxRinominaFile.TabIndex = 2
        Me.CheckBoxRinominaFile.Text = "Rinomina il file dopo l'invio"
        Me.CheckBoxRinominaFile.UseVisualStyleBackColor = True
        '
        'ComboBoxTipoDoc
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.ComboBoxTipoDoc, 2)
        Me.ComboBoxTipoDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTipoDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxTipoDoc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxTipoDoc.FormattingEnabled = True
        Me.ComboBoxTipoDoc.Location = New System.Drawing.Point(154, 64)
        Me.ComboBoxTipoDoc.Name = "ComboBoxTipoDoc"
        Me.ComboBoxTipoDoc.Size = New System.Drawing.Size(323, 24)
        Me.ComboBoxTipoDoc.TabIndex = 0
        '
        'lbHelpSertel
        '
        Me.lbHelpSertel.AutoSize = True
        Me.lbHelpSertel.BackColor = System.Drawing.Color.PaleGreen
        Me.TableLayoutPanel5.SetColumnSpan(Me.lbHelpSertel, 3)
        Me.lbHelpSertel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbHelpSertel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHelpSertel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbHelpSertel.Location = New System.Drawing.Point(3, 0)
        Me.lbHelpSertel.Name = "lbHelpSertel"
        Me.lbHelpSertel.Size = New System.Drawing.Size(474, 20)
        Me.lbHelpSertel.TabIndex = 5
        Me.lbHelpSertel.Text = "Label2"
        Me.lbHelpSertel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpDataArrivoDoc
        '
        Me.dtpDataArrivoDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDataArrivoDoc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataArrivoDoc.Location = New System.Drawing.Point(154, 91)
        Me.dtpDataArrivoDoc.Name = "dtpDataArrivoDoc"
        Me.dtpDataArrivoDoc.Size = New System.Drawing.Size(105, 23)
        Me.dtpDataArrivoDoc.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(3, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 27)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Tipo documento"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(3, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 27)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Data arrivo"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBoxEsci
        '
        Me.GroupBoxEsci.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBoxEsci.Controls.Add(Me.btnEsci)
        Me.GroupBoxEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxEsci.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxEsci.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBoxEsci.Location = New System.Drawing.Point(774, 569)
        Me.GroupBoxEsci.Name = "GroupBoxEsci"
        Me.GroupBoxEsci.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBoxEsci.Size = New System.Drawing.Size(262, 137)
        Me.GroupBoxEsci.TabIndex = 7
        Me.GroupBoxEsci.TabStop = False
        '
        'btnEsci
        '
        Me.btnEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsci.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEsci.FlatAppearance.BorderSize = 4
        Me.btnEsci.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEsci.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEsci.Location = New System.Drawing.Point(5, 21)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(252, 111)
        Me.btnEsci.TabIndex = 3
        Me.btnEsci.Text = "Button1"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "folderchiuso.ico")
        Me.ImageList1.Images.SetKeyName(1, "folderaperto.ico")
        Me.ImageList1.Images.SetKeyName(2, "folderpolizza.ico")
        Me.ImageList1.Images.SetKeyName(3, "foldersinistro.ico")
        Me.ImageList1.Images.SetKeyName(4, "cliente.png")
        '
        'TimerScanner
        '
        '
        'FormDocumenti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 709)
        Me.Controls.Add(Me.TableLayoutPanelMain)
        Me.Name = "FormDocumenti"
        Me.Text = "FormMain"
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        Me.TableLayoutPanelEsploraDoc.ResumeLayout(False)
        Me.TableLayoutPanelEsploraDoc.PerformLayout()
        Me.SplitContainerAnteprima.Panel1.ResumeLayout(False)
        Me.SplitContainerAnteprima.Panel1.PerformLayout()
        Me.SplitContainerAnteprima.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerAnteprima, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerAnteprima.ResumeLayout(False)
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanelMain.ResumeLayout(False)
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPageScanner.ResumeLayout(False)
        Me.tlpScan.ResumeLayout(False)
        Me.tlpScan.PerformLayout()
        Me.tlpScanner.ResumeLayout(False)
        Me.tlpScanner.PerformLayout()
        CType(Me.tbChiaroScuro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageModifica.ResumeLayout(False)
        Me.TableLayoutPanelModifica.ResumeLayout(False)
        Me.TabPageOpzioni.ResumeLayout(False)
        Me.TableLayoutPanelStorico.ResumeLayout(False)
        Me.GroupBoxSertel.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.GroupBoxEsci.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents tvPratiche As System.Windows.Forms.TreeView
    Friend WithEvents ListBoxDocumenti As System.Windows.Forms.ListBox
    Friend WithEvents SplitContainerAnteprima As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripAnteprima As System.Windows.Forms.ToolStrip
    Friend WithEvents TableLayoutPanelMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpScan As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanelEsploraDoc As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnAllega As System.Windows.Forms.Button
    Friend WithEvents rbBianoNero As System.Windows.Forms.RadioButton
    Friend WithEvents rbColori As System.Windows.Forms.RadioButton
    Friend WithEvents rbScalaGrigi As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBoxFormato As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxRisoluzione As System.Windows.Forms.ComboBox
    Friend WithEvents tbChiaroScuro As System.Windows.Forms.TrackBar
    Friend WithEvents chkDuplex As System.Windows.Forms.CheckBox
    Friend WithEvents LabelChiaroScuro As System.Windows.Forms.Label
    Friend WithEvents tlpScanner As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnScanNuovo As System.Windows.Forms.Button
    Friend WithEvents btnScanAggiungi As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnPratica As System.Windows.Forms.Button
    Friend WithEvents btnEsporta As System.Windows.Forms.Button
    Friend WithEvents btnImporta As System.Windows.Forms.Button
    Friend WithEvents btnApri As System.Windows.Forms.Button
    Friend WithEvents btnCancella As System.Windows.Forms.Button
    Friend WithEvents GroupBoxSertel As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCercaSertel As System.Windows.Forms.Button
    Friend WithEvents btnInviaSertel As System.Windows.Forms.Button
    Friend WithEvents CheckBoxRinominaFile As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxTipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents lbHelpSertel As System.Windows.Forms.Label
    Friend WithEvents dtpDataArrivoDoc As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TabControlMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPageScanner As System.Windows.Forms.TabPage
    Friend WithEvents TabPageModifica As System.Windows.Forms.TabPage
    Friend WithEvents Twain As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
    Friend WithEvents btnRinomina As System.Windows.Forms.Button
    Friend WithEvents PictureBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents ComboBoxSource As System.Windows.Forms.ComboBox
    Friend WithEvents btnFineDoc As System.Windows.Forms.Button
    Friend WithEvents LabelStato As System.Windows.Forms.Label
    Friend WithEvents TimerScanner As System.Windows.Forms.Timer
    Friend WithEvents btnVisualizzaTutto As System.Windows.Forms.Button
    Friend WithEvents btnNuovaPratica As System.Windows.Forms.Button
    Friend WithEvents TabPageOpzioni As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanelModifica As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnEditor As System.Windows.Forms.Button
    Friend WithEvents btnEliminaPagina As System.Windows.Forms.Button
    Friend WithEvents btnConvertiFormato As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanelStorico As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents GroupBoxEsci As System.Windows.Forms.GroupBox
    Friend WithEvents btnScannerRete As System.Windows.Forms.Button
    Friend WithEvents ButtonCercaDocumenti As System.Windows.Forms.Button
    Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents ButtonCartellaRete As System.Windows.Forms.Button
    Friend WithEvents btnSelezionaScanner As System.Windows.Forms.Button
    Friend WithEvents LabelBianco As System.Windows.Forms.Label
    Friend WithEvents LabelGrigi As System.Windows.Forms.Label
    Friend WithEvents LabelColore As System.Windows.Forms.Label
    Friend WithEvents txtChiaroScuro As System.Windows.Forms.TextBox
    Friend WithEvents LabelNero As System.Windows.Forms.Label
    Friend WithEvents LinkLabelPDF As Windows.Forms.LinkLabel
    Friend WithEvents ButtonRDP As Windows.Forms.Button
    Friend WithEvents ButtonSetStorico As Windows.Forms.Button
    Friend WithEvents CheckBoxStorico As Windows.Forms.CheckBox
    Friend WithEvents ButtonRecupera As Windows.Forms.Button
End Class
