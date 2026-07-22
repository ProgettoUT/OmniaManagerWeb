<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametri
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametri))
        Me.txtPdfColore = New System.Windows.Forms.CheckBox()
        Me.txtAnnoPrecedente = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDataMax = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDataMin = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtProdotti = New System.Windows.Forms.TextBox()
        Me.txtConvenzioni = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSubAgenti = New System.Windows.Forms.CheckedListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEscludiSostituzioniAuto = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtProdottiIncludi = New System.Windows.Forms.RadioButton()
        Me.txtProdottiEscludi = New System.Windows.Forms.RadioButton()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtConvenzioniIncludi = New System.Windows.Forms.RadioButton()
        Me.txtConvenzioniEscludi = New System.Windows.Forms.RadioButton()
        Me.txtRamiGestione = New System.Windows.Forms.CheckedListBox()
        Me.comboBoxMacroRami = New System.Windows.Forms.ComboBox()
        Me.txtIncludiRegolazioni = New System.Windows.Forms.CheckBox()
        Me.cmdExcell = New System.Windows.Forms.Button()
        Me.cmdPdf = New System.Windows.Forms.Button()
        Me.cmdAnnulla = New System.Windows.Forms.Button()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxGruppi = New System.Windows.Forms.ComboBox()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPdfColore
        '
        Me.txtPdfColore.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPdfColore, 2)
        Me.txtPdfColore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPdfColore.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPdfColore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPdfColore.Location = New System.Drawing.Point(291, 433)
        Me.txtPdfColore.Name = "txtPdfColore"
        Me.txtPdfColore.Size = New System.Drawing.Size(284, 19)
        Me.txtPdfColore.TabIndex = 1
        Me.txtPdfColore.Text = "Report a colori"
        Me.txtPdfColore.UseVisualStyleBackColor = True
        '
        'txtAnnoPrecedente
        '
        Me.txtAnnoPrecedente.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtAnnoPrecedente, 2)
        Me.txtAnnoPrecedente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAnnoPrecedente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnnoPrecedente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAnnoPrecedente.Location = New System.Drawing.Point(3, 433)
        Me.txtAnnoPrecedente.Name = "txtAnnoPrecedente"
        Me.txtAnnoPrecedente.Size = New System.Drawing.Size(282, 19)
        Me.txtAnnoPrecedente.TabIndex = 0
        Me.txtAnnoPrecedente.Text = "Confronto anno precedente"
        Me.txtAnnoPrecedente.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 2)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(291, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(284, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "al"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtDataMax
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtDataMax, 2)
        Me.txtDataMax.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDataMax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataMax.Location = New System.Drawing.Point(291, 43)
        Me.txtDataMax.Name = "txtDataMax"
        Me.txtDataMax.Size = New System.Drawing.Size(284, 21)
        Me.txtDataMax.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label7, 4)
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(572, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Prodotti"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtDataMin
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtDataMin, 2)
        Me.txtDataMin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDataMin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataMin.Location = New System.Drawing.Point(3, 43)
        Me.txtDataMin.Name = "txtDataMin"
        Me.txtDataMin.Size = New System.Drawing.Size(282, 21)
        Me.txtDataMin.TabIndex = 0
        Me.txtDataMin.Value = New Date(2012, 4, 10, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label8, 4)
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(572, 20)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Convenzioni"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtProdotti
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtProdotti, 2)
        Me.txtProdotti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProdotti.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProdotti.Location = New System.Drawing.Point(3, 88)
        Me.txtProdotti.Name = "txtProdotti"
        Me.txtProdotti.Size = New System.Drawing.Size(282, 21)
        Me.txtProdotti.TabIndex = 2
        Me.txtProdotti.Tag = "TUTTI   (oppure indicare: 9050, 3019, ...)"
        '
        'txtConvenzioni
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtConvenzioni, 2)
        Me.txtConvenzioni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConvenzioni.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConvenzioni.Location = New System.Drawing.Point(3, 133)
        Me.txtConvenzioni.Name = "txtConvenzioni"
        Me.txtConvenzioni.Size = New System.Drawing.Size(282, 21)
        Me.txtConvenzioni.TabIndex = 3
        Me.txtConvenzioni.Tag = "TUTTI   (oppure indicare: 9036, 1706, ...)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(282, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Foglio cassa dal"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label5, 2)
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(282, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Subagenti"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtSubAgenti
        '
        Me.txtSubAgenti.CheckOnClick = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtSubAgenti, 2)
        Me.txtSubAgenti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSubAgenti.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubAgenti.FormattingEnabled = True
        Me.txtSubAgenti.IntegralHeight = False
        Me.txtSubAgenti.Location = New System.Drawing.Point(3, 203)
        Me.txtSubAgenti.Name = "txtSubAgenti"
        Me.txtSubAgenti.Size = New System.Drawing.Size(282, 179)
        Me.txtSubAgenti.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label6, 2)
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(291, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(284, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Rami gestione"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtEscludiSostituzioniAuto
        '
        Me.txtEscludiSostituzioniAuto.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtEscludiSostituzioniAuto, 2)
        Me.txtEscludiSostituzioniAuto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEscludiSostituzioniAuto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEscludiSostituzioniAuto.Location = New System.Drawing.Point(3, 158)
        Me.txtEscludiSostituzioniAuto.Name = "txtEscludiSostituzioniAuto"
        Me.txtEscludiSostituzioniAuto.Size = New System.Drawing.Size(282, 19)
        Me.txtEscludiSostituzioniAuto.TabIndex = 6
        Me.txtEscludiSostituzioniAuto.Text = "Escludi sostituzioni auto"
        Me.txtEscludiSostituzioniAuto.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel1, 2)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtProdottiIncludi)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtProdottiEscludi)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(291, 88)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(284, 19)
        Me.FlowLayoutPanel1.TabIndex = 7
        '
        'txtProdottiIncludi
        '
        Me.txtProdottiIncludi.AutoSize = True
        Me.txtProdottiIncludi.Checked = True
        Me.txtProdottiIncludi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProdottiIncludi.Enabled = False
        Me.txtProdottiIncludi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProdottiIncludi.Location = New System.Drawing.Point(3, 3)
        Me.txtProdottiIncludi.Name = "txtProdottiIncludi"
        Me.txtProdottiIncludi.Size = New System.Drawing.Size(70, 17)
        Me.txtProdottiIncludi.TabIndex = 0
        Me.txtProdottiIncludi.TabStop = True
        Me.txtProdottiIncludi.Text = "Seleziona"
        Me.txtProdottiIncludi.UseVisualStyleBackColor = True
        '
        'txtProdottiEscludi
        '
        Me.txtProdottiEscludi.AutoSize = True
        Me.txtProdottiEscludi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProdottiEscludi.Enabled = False
        Me.txtProdottiEscludi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProdottiEscludi.Location = New System.Drawing.Point(79, 3)
        Me.txtProdottiEscludi.Name = "txtProdottiEscludi"
        Me.txtProdottiEscludi.Size = New System.Drawing.Size(57, 17)
        Me.txtProdottiEscludi.TabIndex = 1
        Me.txtProdottiEscludi.Text = "Escludi"
        Me.txtProdottiEscludi.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel2, 2)
        Me.FlowLayoutPanel2.Controls.Add(Me.txtConvenzioniIncludi)
        Me.FlowLayoutPanel2.Controls.Add(Me.txtConvenzioniEscludi)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(291, 133)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(284, 19)
        Me.FlowLayoutPanel2.TabIndex = 8
        '
        'txtConvenzioniIncludi
        '
        Me.txtConvenzioniIncludi.AutoSize = True
        Me.txtConvenzioniIncludi.Checked = True
        Me.txtConvenzioniIncludi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConvenzioniIncludi.Enabled = False
        Me.txtConvenzioniIncludi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConvenzioniIncludi.Location = New System.Drawing.Point(3, 3)
        Me.txtConvenzioniIncludi.Name = "txtConvenzioniIncludi"
        Me.txtConvenzioniIncludi.Size = New System.Drawing.Size(70, 17)
        Me.txtConvenzioniIncludi.TabIndex = 0
        Me.txtConvenzioniIncludi.TabStop = True
        Me.txtConvenzioniIncludi.Text = "Seleziona"
        Me.txtConvenzioniIncludi.UseVisualStyleBackColor = True
        '
        'txtConvenzioniEscludi
        '
        Me.txtConvenzioniEscludi.AutoSize = True
        Me.txtConvenzioniEscludi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConvenzioniEscludi.Enabled = False
        Me.txtConvenzioniEscludi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConvenzioniEscludi.Location = New System.Drawing.Point(79, 3)
        Me.txtConvenzioniEscludi.Name = "txtConvenzioniEscludi"
        Me.txtConvenzioniEscludi.Size = New System.Drawing.Size(57, 17)
        Me.txtConvenzioniEscludi.TabIndex = 1
        Me.txtConvenzioniEscludi.Text = "Escludi"
        Me.txtConvenzioniEscludi.UseVisualStyleBackColor = True
        '
        'txtRamiGestione
        '
        Me.txtRamiGestione.CheckOnClick = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtRamiGestione, 2)
        Me.txtRamiGestione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRamiGestione.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRamiGestione.FormattingEnabled = True
        Me.txtRamiGestione.IntegralHeight = False
        Me.txtRamiGestione.Location = New System.Drawing.Point(291, 203)
        Me.txtRamiGestione.Name = "txtRamiGestione"
        Me.txtRamiGestione.Size = New System.Drawing.Size(284, 179)
        Me.txtRamiGestione.TabIndex = 5
        '
        'comboBoxMacroRami
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.comboBoxMacroRami, 2)
        Me.comboBoxMacroRami.Dock = System.Windows.Forms.DockStyle.Fill
        Me.comboBoxMacroRami.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxMacroRami.FormattingEnabled = True
        Me.comboBoxMacroRami.Location = New System.Drawing.Point(291, 388)
        Me.comboBoxMacroRami.Name = "comboBoxMacroRami"
        Me.comboBoxMacroRami.Size = New System.Drawing.Size(284, 21)
        Me.comboBoxMacroRami.TabIndex = 7
        '
        'txtIncludiRegolazioni
        '
        Me.txtIncludiRegolazioni.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtIncludiRegolazioni, 2)
        Me.txtIncludiRegolazioni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIncludiRegolazioni.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncludiRegolazioni.Location = New System.Drawing.Point(291, 158)
        Me.txtIncludiRegolazioni.Name = "txtIncludiRegolazioni"
        Me.txtIncludiRegolazioni.Size = New System.Drawing.Size(284, 19)
        Me.txtIncludiRegolazioni.TabIndex = 6
        Me.txtIncludiRegolazioni.Text = "Includi le Regolazioni Premio"
        Me.txtIncludiRegolazioni.UseVisualStyleBackColor = True
        '
        'cmdExcell
        '
        Me.cmdExcell.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdExcell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExcell.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdExcell.Location = New System.Drawing.Point(115, 465)
        Me.cmdExcell.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdExcell.Name = "cmdExcell"
        Me.cmdExcell.Padding = New System.Windows.Forms.Padding(40, 0, 40, 0)
        Me.cmdExcell.Size = New System.Drawing.Size(173, 50)
        Me.cmdExcell.TabIndex = 0
        Me.cmdExcell.Text = "Estrai Dettaglio"
        Me.cmdExcell.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExcell.UseVisualStyleBackColor = True
        '
        'cmdPdf
        '
        Me.cmdPdf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdPdf.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPdf.Location = New System.Drawing.Point(288, 465)
        Me.cmdPdf.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdPdf.Name = "cmdPdf"
        Me.cmdPdf.Padding = New System.Windows.Forms.Padding(40, 0, 40, 0)
        Me.cmdPdf.Size = New System.Drawing.Size(173, 50)
        Me.cmdPdf.TabIndex = 1
        Me.cmdPdf.Text = "Genera Report"
        Me.cmdPdf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPdf.UseVisualStyleBackColor = True
        '
        'cmdAnnulla
        '
        Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdAnnulla.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAnnulla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAnnulla.Location = New System.Drawing.Point(461, 465)
        Me.cmdAnnulla.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdAnnulla.Name = "cmdAnnulla"
        Me.cmdAnnulla.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.cmdAnnulla.Size = New System.Drawing.Size(117, 50)
        Me.cmdAnnulla.TabIndex = 2
        Me.cmdAnnulla.Text = "Esci"
        Me.cmdAnnulla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAnnulla.UseVisualStyleBackColor = True
        '
        'cmdHelp
        '
        Me.cmdHelp.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdHelp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdHelp.Location = New System.Drawing.Point(0, 465)
        Me.cmdHelp.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.cmdHelp.Size = New System.Drawing.Size(115, 50)
        Me.cmdHelp.TabIndex = 2
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtPdfColore, 2, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSubAgenti, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAnnoPrecedente, 0, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRamiGestione, 2, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 2, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.comboBoxMacroRami, 2, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.txtConvenzioni, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtEscludiSostituzioniAuto, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtProdotti, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtIncludiRegolazioni, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDataMax, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdHelp, 0, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDataMin, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdAnnulla, 3, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdPdf, 2, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdExcell, 1, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxGruppi, 0, 10)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(5, 5)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 15
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(578, 515)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label3, 4)
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(3, 410)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(572, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Parametri report"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label4, 4)
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(572, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Parametri produzione"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBoxGruppi
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ComboBoxGruppi, 2)
        Me.ComboBoxGruppi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxGruppi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxGruppi.FormattingEnabled = True
        Me.ComboBoxGruppi.Location = New System.Drawing.Point(3, 388)
        Me.ComboBoxGruppi.Name = "ComboBoxGruppi"
        Me.ComboBoxGruppi.Size = New System.Drawing.Size(282, 21)
        Me.ComboBoxGruppi.TabIndex = 7
        '
        'frmParametri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdAnnulla
        Me.ClientSize = New System.Drawing.Size(588, 525)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParametri"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produzione"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtPdfColore As System.Windows.Forms.CheckBox
    Friend WithEvents txtAnnoPrecedente As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDataMax As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDataMin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtProdotti As System.Windows.Forms.TextBox
    Friend WithEvents txtConvenzioni As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSubAgenti As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEscludiSostituzioniAuto As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtProdottiIncludi As System.Windows.Forms.RadioButton
    Friend WithEvents txtProdottiEscludi As System.Windows.Forms.RadioButton
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtConvenzioniIncludi As System.Windows.Forms.RadioButton
    Friend WithEvents txtConvenzioniEscludi As System.Windows.Forms.RadioButton
    Friend WithEvents cmdExcell As System.Windows.Forms.Button
    Friend WithEvents cmdPdf As System.Windows.Forms.Button
    Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
    Friend WithEvents txtRamiGestione As System.Windows.Forms.CheckedListBox
    Friend WithEvents comboBoxMacroRami As System.Windows.Forms.ComboBox
    Friend WithEvents txtIncludiRegolazioni As System.Windows.Forms.CheckBox
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxGruppi As System.Windows.Forms.ComboBox

End Class
