<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProprieta
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
        Me.cmdChiudi = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.table = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTitolo = New System.Windows.Forms.Label()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.lblProperties = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.TxtNote = New System.Windows.Forms.TextBox()
        Me.CmbCategory = New System.Windows.Forms.ComboBox()
        Me.CmbStatus = New System.Windows.Forms.ComboBox()
        Me.DTStatus = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CmbDomain = New System.Windows.Forms.ComboBox()
        Me.CmbOwner = New System.Windows.Forms.ComboBox()
        Me.CmbType = New System.Windows.Forms.ComboBox()
        Me.TxtVersion = New System.Windows.Forms.TextBox()
        Me.DTLastUpdate = New System.Windows.Forms.TextBox()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lstProtezione = New System.Windows.Forms.ListView()
        Me.chProfilo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chConsenti = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNega = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.txtParametri = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.table.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdChiudi
        '
        Me.cmdChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdChiudi.Location = New System.Drawing.Point(228, 340)
        Me.cmdChiudi.Name = "cmdChiudi"
        Me.cmdChiudi.Size = New System.Drawing.Size(75, 23)
        Me.cmdChiudi.TabIndex = 0
        Me.cmdChiudi.Text = "&Chiudi"
        Me.cmdChiudi.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(506, 322)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.table)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(498, 295)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Descrizione"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'table
        '
        Me.table.BackColor = System.Drawing.Color.White
        Me.table.ColumnCount = 1
        Me.table.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.table.Controls.Add(Me.lblTitolo, 0, 0)
        Me.table.Controls.Add(Me.lblDesc, 0, 1)
        Me.table.Controls.Add(Me.lblProperties, 0, 2)
        Me.table.Dock = System.Windows.Forms.DockStyle.Fill
        Me.table.Location = New System.Drawing.Point(3, 3)
        Me.table.Name = "table"
        Me.table.RowCount = 3
        Me.table.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.table.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.table.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 144.0!))
        Me.table.Size = New System.Drawing.Size(492, 289)
        Me.table.TabIndex = 0
        '
        'lblTitolo
        '
        Me.lblTitolo.AutoSize = True
        Me.lblTitolo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitolo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitolo.ForeColor = System.Drawing.Color.Red
        Me.lblTitolo.Location = New System.Drawing.Point(3, 0)
        Me.lblTitolo.Name = "lblTitolo"
        Me.lblTitolo.Size = New System.Drawing.Size(486, 50)
        Me.lblTitolo.TabIndex = 0
        Me.lblTitolo.Text = "titolo"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDesc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesc.Location = New System.Drawing.Point(3, 50)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(486, 50)
        Me.lblDesc.TabIndex = 1
        Me.lblDesc.Text = "descrizione"
        '
        'lblProperties
        '
        Me.lblProperties.AutoSize = True
        Me.lblProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblProperties.Location = New System.Drawing.Point(3, 100)
        Me.lblProperties.Name = "lblProperties"
        Me.lblProperties.Size = New System.Drawing.Size(486, 189)
        Me.lblProperties.TabIndex = 2
        Me.lblProperties.Text = "proprietà"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(498, 295)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Generale"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.45811!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.54189!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNome, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDescription, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtNote, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CmbCategory, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CmbStatus, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.DTStatus, 1, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(492, 289)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Descrizione"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 14)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Note"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 14)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Categoria"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 220)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 14)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Stato"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 250)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 14)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Data Convalida"
        '
        'txtNome
        '
        Me.txtNome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNome.Location = New System.Drawing.Point(152, 3)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(337, 22)
        Me.txtNome.TabIndex = 1
        '
        'txtDescription
        '
        Me.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescription.Location = New System.Drawing.Point(152, 33)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(337, 74)
        Me.txtDescription.TabIndex = 1
        '
        'TxtNote
        '
        Me.TxtNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtNote.Location = New System.Drawing.Point(152, 113)
        Me.TxtNote.Multiline = True
        Me.TxtNote.Name = "TxtNote"
        Me.TxtNote.Size = New System.Drawing.Size(337, 74)
        Me.TxtNote.TabIndex = 1
        '
        'CmbCategory
        '
        Me.CmbCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CmbCategory.FormattingEnabled = True
        Me.CmbCategory.Location = New System.Drawing.Point(152, 193)
        Me.CmbCategory.Name = "CmbCategory"
        Me.CmbCategory.Size = New System.Drawing.Size(337, 22)
        Me.CmbCategory.TabIndex = 2
        '
        'CmbStatus
        '
        Me.CmbStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CmbStatus.FormattingEnabled = True
        Me.CmbStatus.Location = New System.Drawing.Point(152, 223)
        Me.CmbStatus.Name = "CmbStatus"
        Me.CmbStatus.Size = New System.Drawing.Size(337, 22)
        Me.CmbStatus.TabIndex = 2
        '
        'DTStatus
        '
        Me.DTStatus.Dock = System.Windows.Forms.DockStyle.Left
        Me.DTStatus.Location = New System.Drawing.Point(152, 253)
        Me.DTStatus.Name = "DTStatus"
        Me.DTStatus.Size = New System.Drawing.Size(134, 22)
        Me.DTStatus.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(498, 295)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Avanzate"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbDomain, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbOwner, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbType, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtVersion, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.DTLastUpdate, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.chkHidden, 1, 7)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 9
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(498, 295)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 14)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Dominio"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 14)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Proprietario"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 14)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Tipo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 14)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Versione"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 150)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 14)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Ultima modifica"
        '
        'CmbDomain
        '
        Me.CmbDomain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CmbDomain.FormattingEnabled = True
        Me.CmbDomain.Location = New System.Drawing.Point(189, 3)
        Me.CmbDomain.Name = "CmbDomain"
        Me.CmbDomain.Size = New System.Drawing.Size(306, 22)
        Me.CmbDomain.TabIndex = 1
        '
        'CmbOwner
        '
        Me.CmbOwner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CmbOwner.FormattingEnabled = True
        Me.CmbOwner.Location = New System.Drawing.Point(189, 35)
        Me.CmbOwner.Name = "CmbOwner"
        Me.CmbOwner.Size = New System.Drawing.Size(306, 22)
        Me.CmbOwner.TabIndex = 1
        '
        'CmbType
        '
        Me.CmbType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CmbType.FormattingEnabled = True
        Me.CmbType.Location = New System.Drawing.Point(189, 63)
        Me.CmbType.Name = "CmbType"
        Me.CmbType.Size = New System.Drawing.Size(306, 22)
        Me.CmbType.TabIndex = 1
        '
        'TxtVersion
        '
        Me.TxtVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtVersion.Location = New System.Drawing.Point(189, 123)
        Me.TxtVersion.Name = "TxtVersion"
        Me.TxtVersion.Size = New System.Drawing.Size(306, 22)
        Me.TxtVersion.TabIndex = 2
        '
        'DTLastUpdate
        '
        Me.DTLastUpdate.Dock = System.Windows.Forms.DockStyle.Left
        Me.DTLastUpdate.Location = New System.Drawing.Point(189, 153)
        Me.DTLastUpdate.Name = "DTLastUpdate"
        Me.DTLastUpdate.Size = New System.Drawing.Size(100, 22)
        Me.DTLastUpdate.TabIndex = 2
        '
        'chkHidden
        '
        Me.chkHidden.AutoSize = True
        Me.chkHidden.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkHidden.Location = New System.Drawing.Point(189, 213)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(75, 24)
        Me.chkHidden.TabIndex = 3
        Me.chkHidden.Text = "Nascosto"
        Me.chkHidden.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.lstProtezione)
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(498, 295)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Protezione"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'lstProtezione
        '
        Me.lstProtezione.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chProfilo, Me.chConsenti, Me.chNega})
        Me.lstProtezione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstProtezione.Location = New System.Drawing.Point(0, 0)
        Me.lstProtezione.Name = "lstProtezione"
        Me.lstProtezione.Size = New System.Drawing.Size(498, 295)
        Me.lstProtezione.TabIndex = 0
        Me.lstProtezione.UseCompatibleStateImageBehavior = False
        Me.lstProtezione.View = System.Windows.Forms.View.Details
        '
        'chProfilo
        '
        Me.chProfilo.Text = "Profilo"
        Me.chProfilo.Width = 309
        '
        'chConsenti
        '
        Me.chConsenti.Text = "Consenti"
        Me.chConsenti.Width = 90
        '
        'chNega
        '
        Me.chNega.Text = "Nega"
        Me.chNega.Width = 90
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.txtParametri)
        Me.TabPage5.Location = New System.Drawing.Point(4, 23)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(498, 295)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Parametri"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'txtParametri
        '
        Me.txtParametri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtParametri.Location = New System.Drawing.Point(0, 0)
        Me.txtParametri.Multiline = True
        Me.txtParametri.Name = "txtParametri"
        Me.txtParametri.Size = New System.Drawing.Size(498, 295)
        Me.txtParametri.TabIndex = 0
        '
        'frmProprieta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdChiudi
        Me.ClientSize = New System.Drawing.Size(530, 375)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmdChiudi)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimizeBox = False
        Me.Name = "frmProprieta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagine proprietà"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.table.ResumeLayout(False)
        Me.table.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdChiudi As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents TxtNote As System.Windows.Forms.TextBox
    Friend WithEvents CmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents CmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents DTStatus As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CmbDomain As System.Windows.Forms.ComboBox
    Friend WithEvents CmbOwner As System.Windows.Forms.ComboBox
    Friend WithEvents CmbType As System.Windows.Forms.ComboBox
    Friend WithEvents TxtVersion As System.Windows.Forms.TextBox
    Friend WithEvents DTLastUpdate As System.Windows.Forms.TextBox
    Friend WithEvents chkHidden As System.Windows.Forms.CheckBox
    Friend WithEvents txtParametri As System.Windows.Forms.TextBox
    Friend WithEvents lstProtezione As System.Windows.Forms.ListView
    Friend WithEvents chProfilo As System.Windows.Forms.ColumnHeader
    Friend WithEvents chConsenti As System.Windows.Forms.ColumnHeader
    Friend WithEvents chNega As System.Windows.Forms.ColumnHeader
    Friend WithEvents table As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTitolo As System.Windows.Forms.Label
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents lblProperties As System.Windows.Forms.Label
End Class
