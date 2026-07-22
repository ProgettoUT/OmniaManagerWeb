<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRappel
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.buttonChiudi = New System.Windows.Forms.Button()
        Me.buttonGuida = New System.Windows.Forms.Button()
        Me.lblTotale = New System.Windows.Forms.Label()
        Me.lblIncassiAnnoPrecedente = New System.Windows.Forms.Label()
        Me.lblTitoloRP = New System.Windows.Forms.Label()
        Me.lblTitoloRA = New System.Windows.Forms.Label()
        Me.txtIncassiPrecedenteRP = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBudgetAnnoCorrente = New System.Windows.Forms.Label()
        Me.txtBudgetRP = New System.Windows.Forms.TextBox()
        Me.lblIncassiAnnoCorrente = New System.Windows.Forms.Label()
        Me.txtIncassiCorrenteRP = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblRappelPrincipaleRP = New System.Windows.Forms.Label()
        Me.txtIncassiCorrenteRA = New System.Windows.Forms.TextBox()
        Me.txtBudgetRA = New System.Windows.Forms.TextBox()
        Me.txtIncassiPrecedenteRA = New System.Windows.Forms.TextBox()
        Me.lblRappelPrincipaleRA = New System.Windows.Forms.Label()
        Me.lblRappelRP = New System.Windows.Forms.Label()
        Me.lblRappelRA = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTitoloRCG = New System.Windows.Forms.Label()
        Me.txtIncassiCorrenteRCG = New System.Windows.Forms.TextBox()
        Me.lblRappelPrincipaleRCG = New System.Windows.Forms.Label()
        Me.lblRappelRCG = New System.Windows.Forms.Label()
        Me.ComboBoxVita = New System.Windows.Forms.ComboBox()
        Me.ComboBoxAnno = New System.Windows.Forms.ComboBox()
        Me.lblRappel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRappelRedditivitaRA = New System.Windows.Forms.Label()
        Me.lblRappelRedditivitaRP = New System.Windows.Forms.Label()
        Me.lblPercentualeCorrenteRP = New System.Windows.Forms.Label()
        Me.lblPercentualeCorrenteRA = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxRapportoSPRP = New System.Windows.Forms.TextBox()
        Me.TextBoxRapportoSPNazionaleRP = New System.Windows.Forms.TextBox()
        Me.TextBoxRapportoSPNazionaleRA = New System.Windows.Forms.TextBox()
        Me.TextBoxRapportoSPRA = New System.Windows.Forms.TextBox()
        Me.TextBoxRapportoSPRCG = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBoxIncassiNazionaliRP = New System.Windows.Forms.TextBox()
        Me.TextBoxIncassiNazionaliRA = New System.Windows.Forms.TextBox()
        Me.TextBoxPesoAgenziaRP = New System.Windows.Forms.TextBox()
        Me.TextBoxPesoAgenziaRA = New System.Windows.Forms.TextBox()
        Me.lblRappelIncentivoNazionaleRP = New System.Windows.Forms.Label()
        Me.lblRappelIncentivoNazionaleRA = New System.Windows.Forms.Label()
        Me.CheckedListBoCodici = New System.Windows.Forms.CheckedListBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ButtonCalcola = New System.Windows.Forms.Button()
        Me.ButtonSelezionaTutti = New System.Windows.Forms.Button()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.tableLayoutPanel1.ColumnCount = 8
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.buttonChiudi, 5, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.buttonGuida, 3, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.lblTotale, 0, 18)
        Me.tableLayoutPanel1.Controls.Add(Me.lblIncassiAnnoPrecedente, 0, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.lblTitoloRP, 1, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.lblTitoloRA, 3, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.txtIncassiPrecedenteRP, 1, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.lblBudgetAnnoCorrente, 0, 6)
        Me.tableLayoutPanel1.Controls.Add(Me.txtBudgetRP, 1, 6)
        Me.tableLayoutPanel1.Controls.Add(Me.lblIncassiAnnoCorrente, 0, 7)
        Me.tableLayoutPanel1.Controls.Add(Me.txtIncassiCorrenteRP, 1, 7)
        Me.tableLayoutPanel1.Controls.Add(Me.Label7, 0, 10)
        Me.tableLayoutPanel1.Controls.Add(Me.lblRappelPrincipaleRP, 1, 10)
        Me.tableLayoutPanel1.Controls.Add(Me.txtIncassiCorrenteRA, 3, 7)
        Me.tableLayoutPanel1.Controls.Add(Me.txtBudgetRA, 3, 6)
        Me.tableLayoutPanel1.Controls.Add(Me.txtIncassiPrecedenteRA, 3, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.lblRappelPrincipaleRA, 3, 10)
        Me.tableLayoutPanel1.Controls.Add(Me.lblRappelRP, 1, 16)
        Me.tableLayoutPanel1.Controls.Add(Me.lblRappelRA, 3, 16)
        Me.tableLayoutPanel1.Controls.Add(Me.Label18, 0, 16)
        Me.tableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.lblTitoloRCG, 5, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.txtIncassiCorrenteRCG, 5, 7)
        Me.tableLayoutPanel1.Controls.Add(Me.lblRappelPrincipaleRCG, 5, 10)
        Me.tableLayoutPanel1.Controls.Add(Me.lblRappelRCG, 5, 16)
        Me.tableLayoutPanel1.Controls.Add(Me.ComboBoxVita, 1, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.ComboBoxAnno, 1, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.lblRappel, 1, 18)
        Me.tableLayoutPanel1.Controls.Add(Me.Label3, 0, 9)
        Me.tableLayoutPanel1.Controls.Add(Me.Label6, 0, 12)
        Me.tableLayoutPanel1.Controls.Add(Me.Label4, 0, 11)
        Me.tableLayoutPanel1.Controls.Add(Me.lblRappelRedditivitaRA, 3, 11)
        Me.tableLayoutPanel1.Controls.Add(Me.lblRappelRedditivitaRP, 1, 11)
        Me.tableLayoutPanel1.Controls.Add(Me.lblPercentualeCorrenteRP, 1, 8)
        Me.tableLayoutPanel1.Controls.Add(Me.lblPercentualeCorrenteRA, 3, 8)
        Me.tableLayoutPanel1.Controls.Add(Me.Label5, 0, 8)
        Me.tableLayoutPanel1.Controls.Add(Me.TextBoxRapportoSPRP, 1, 9)
        Me.tableLayoutPanel1.Controls.Add(Me.TextBoxRapportoSPNazionaleRP, 1, 12)
        Me.tableLayoutPanel1.Controls.Add(Me.TextBoxRapportoSPNazionaleRA, 3, 12)
        Me.tableLayoutPanel1.Controls.Add(Me.TextBoxRapportoSPRA, 3, 9)
        Me.tableLayoutPanel1.Controls.Add(Me.TextBoxRapportoSPRCG, 5, 9)
        Me.tableLayoutPanel1.Controls.Add(Me.Label8, 0, 13)
        Me.tableLayoutPanel1.Controls.Add(Me.Label9, 0, 14)
        Me.tableLayoutPanel1.Controls.Add(Me.Label10, 0, 15)
        Me.tableLayoutPanel1.Controls.Add(Me.TextBoxIncassiNazionaliRP, 1, 13)
        Me.tableLayoutPanel1.Controls.Add(Me.TextBoxIncassiNazionaliRA, 3, 13)
        Me.tableLayoutPanel1.Controls.Add(Me.TextBoxPesoAgenziaRP, 1, 14)
        Me.tableLayoutPanel1.Controls.Add(Me.TextBoxPesoAgenziaRA, 3, 14)
        Me.tableLayoutPanel1.Controls.Add(Me.lblRappelIncentivoNazionaleRP, 1, 15)
        Me.tableLayoutPanel1.Controls.Add(Me.lblRappelIncentivoNazionaleRA, 3, 15)
        Me.tableLayoutPanel1.Controls.Add(Me.CheckedListBoCodici, 7, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.Label11, 7, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.ButtonCalcola, 7, 18)
        Me.tableLayoutPanel1.Controls.Add(Me.ButtonSelezionaTutti, 7, 16)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.Padding = New System.Windows.Forms.Padding(10)
        Me.tableLayoutPanel1.RowCount = 20
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(921, 519)
        Me.tableLayoutPanel1.TabIndex = 0
        '
        'buttonChiudi
        '
        Me.tableLayoutPanel1.SetColumnSpan(Me.buttonChiudi, 3)
        Me.buttonChiudi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonChiudi.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.buttonChiudi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.buttonChiudi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonChiudi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonChiudi.Location = New System.Drawing.Point(598, 13)
        Me.buttonChiudi.Name = "buttonChiudi"
        Me.buttonChiudi.Padding = New System.Windows.Forms.Padding(5)
        Me.tableLayoutPanel1.SetRowSpan(Me.buttonChiudi, 3)
        Me.buttonChiudi.Size = New System.Drawing.Size(310, 69)
        Me.buttonChiudi.TabIndex = 0
        Me.buttonChiudi.Text = "Esci"
        Me.buttonChiudi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonChiudi.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.buttonChiudi.UseVisualStyleBackColor = True
        '
        'buttonGuida
        '
        Me.buttonGuida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonGuida.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.buttonGuida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.buttonGuida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonGuida.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonGuida.Location = New System.Drawing.Point(416, 13)
        Me.buttonGuida.Name = "buttonGuida"
        Me.buttonGuida.Padding = New System.Windows.Forms.Padding(5)
        Me.tableLayoutPanel1.SetRowSpan(Me.buttonGuida, 3)
        Me.buttonGuida.Size = New System.Drawing.Size(171, 69)
        Me.buttonGuida.TabIndex = 0
        Me.buttonGuida.Text = "Guida"
        Me.buttonGuida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonGuida.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.buttonGuida.UseVisualStyleBackColor = False
        '
        'lblTotale
        '
        Me.lblTotale.AutoSize = True
        Me.lblTotale.BackColor = System.Drawing.Color.Teal
        Me.lblTotale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotale.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotale.ForeColor = System.Drawing.Color.White
        Me.lblTotale.Location = New System.Drawing.Point(13, 438)
        Me.lblTotale.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTotale.Name = "lblTotale"
        Me.lblTotale.Size = New System.Drawing.Size(215, 44)
        Me.lblTotale.TabIndex = 4
        Me.lblTotale.Text = "RAPPEL"
        Me.lblTotale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIncassiAnnoPrecedente
        '
        Me.lblIncassiAnnoPrecedente.AutoSize = True
        Me.lblIncassiAnnoPrecedente.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblIncassiAnnoPrecedente.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncassiAnnoPrecedente.Location = New System.Drawing.Point(13, 128)
        Me.lblIncassiAnnoPrecedente.Margin = New System.Windows.Forms.Padding(3)
        Me.lblIncassiAnnoPrecedente.Name = "lblIncassiAnnoPrecedente"
        Me.lblIncassiAnnoPrecedente.Size = New System.Drawing.Size(215, 16)
        Me.lblIncassiAnnoPrecedente.TabIndex = 0
        Me.lblIncassiAnnoPrecedente.Text = "Incassi anno precedente"
        Me.lblIncassiAnnoPrecedente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitoloRP
        '
        Me.lblTitoloRP.AutoSize = True
        Me.lblTitoloRP.BackColor = System.Drawing.Color.PaleGreen
        Me.lblTitoloRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitoloRP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitoloRP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblTitoloRP.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitoloRP.Location = New System.Drawing.Point(234, 98)
        Me.lblTitoloRP.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTitoloRP.Name = "lblTitoloRP"
        Me.lblTitoloRP.Size = New System.Drawing.Size(171, 24)
        Me.lblTitoloRP.TabIndex = 0
        Me.lblTitoloRP.Text = "Rami Persona"
        Me.lblTitoloRP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitoloRA
        '
        Me.lblTitoloRA.AutoSize = True
        Me.lblTitoloRA.BackColor = System.Drawing.Color.NavajoWhite
        Me.lblTitoloRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitoloRA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitoloRA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblTitoloRA.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitoloRA.Location = New System.Drawing.Point(416, 98)
        Me.lblTitoloRA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTitoloRA.Name = "lblTitoloRA"
        Me.lblTitoloRA.Size = New System.Drawing.Size(171, 24)
        Me.lblTitoloRA.TabIndex = 0
        Me.lblTitoloRA.Text = "Rami Azienda"
        Me.lblTitoloRA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtIncassiPrecedenteRP
        '
        Me.txtIncassiPrecedenteRP.BackColor = System.Drawing.Color.PaleGreen
        Me.txtIncassiPrecedenteRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIncassiPrecedenteRP.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtIncassiPrecedenteRP.Location = New System.Drawing.Point(234, 128)
        Me.txtIncassiPrecedenteRP.Name = "txtIncassiPrecedenteRP"
        Me.txtIncassiPrecedenteRP.Size = New System.Drawing.Size(171, 20)
        Me.txtIncassiPrecedenteRP.TabIndex = 2
        Me.txtIncassiPrecedenteRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.SandyBrown
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 13)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Raggiungimento 100% Budget Vita P.A."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBudgetAnnoCorrente
        '
        Me.lblBudgetAnnoCorrente.AutoSize = True
        Me.lblBudgetAnnoCorrente.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblBudgetAnnoCorrente.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBudgetAnnoCorrente.Location = New System.Drawing.Point(13, 153)
        Me.lblBudgetAnnoCorrente.Margin = New System.Windows.Forms.Padding(3)
        Me.lblBudgetAnnoCorrente.Name = "lblBudgetAnnoCorrente"
        Me.lblBudgetAnnoCorrente.Size = New System.Drawing.Size(215, 16)
        Me.lblBudgetAnnoCorrente.TabIndex = 0
        Me.lblBudgetAnnoCorrente.Text = "Budget"
        Me.lblBudgetAnnoCorrente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBudgetRP
        '
        Me.txtBudgetRP.BackColor = System.Drawing.Color.PaleGreen
        Me.txtBudgetRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBudgetRP.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtBudgetRP.Location = New System.Drawing.Point(234, 153)
        Me.txtBudgetRP.Name = "txtBudgetRP"
        Me.txtBudgetRP.Size = New System.Drawing.Size(171, 20)
        Me.txtBudgetRP.TabIndex = 3
        Me.txtBudgetRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIncassiAnnoCorrente
        '
        Me.lblIncassiAnnoCorrente.AutoSize = True
        Me.lblIncassiAnnoCorrente.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblIncassiAnnoCorrente.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncassiAnnoCorrente.Location = New System.Drawing.Point(13, 178)
        Me.lblIncassiAnnoCorrente.Margin = New System.Windows.Forms.Padding(3)
        Me.lblIncassiAnnoCorrente.Name = "lblIncassiAnnoCorrente"
        Me.lblIncassiAnnoCorrente.Size = New System.Drawing.Size(215, 16)
        Me.lblIncassiAnnoCorrente.TabIndex = 0
        Me.lblIncassiAnnoCorrente.Text = "Incassi anno di riferimento"
        Me.lblIncassiAnnoCorrente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIncassiCorrenteRP
        '
        Me.txtIncassiCorrenteRP.BackColor = System.Drawing.Color.PaleGreen
        Me.txtIncassiCorrenteRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIncassiCorrenteRP.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtIncassiCorrenteRP.Location = New System.Drawing.Point(234, 178)
        Me.txtIncassiCorrenteRP.Name = "txtIncassiCorrenteRP"
        Me.txtIncassiCorrenteRP.Size = New System.Drawing.Size(171, 20)
        Me.txtIncassiCorrenteRP.TabIndex = 4
        Me.txtIncassiCorrenteRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Green
        Me.Label7.Location = New System.Drawing.Point(13, 253)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(215, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Rappel Principale"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRappelPrincipaleRP
        '
        Me.lblRappelPrincipaleRP.AutoSize = True
        Me.lblRappelPrincipaleRP.BackColor = System.Drawing.Color.White
        Me.lblRappelPrincipaleRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRappelPrincipaleRP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRappelPrincipaleRP.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRappelPrincipaleRP.ForeColor = System.Drawing.Color.Green
        Me.lblRappelPrincipaleRP.Location = New System.Drawing.Point(234, 253)
        Me.lblRappelPrincipaleRP.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRappelPrincipaleRP.Name = "lblRappelPrincipaleRP"
        Me.lblRappelPrincipaleRP.Size = New System.Drawing.Size(171, 19)
        Me.lblRappelPrincipaleRP.TabIndex = 0
        Me.lblRappelPrincipaleRP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIncassiCorrenteRA
        '
        Me.txtIncassiCorrenteRA.BackColor = System.Drawing.Color.NavajoWhite
        Me.txtIncassiCorrenteRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIncassiCorrenteRA.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtIncassiCorrenteRA.Location = New System.Drawing.Point(416, 178)
        Me.txtIncassiCorrenteRA.Name = "txtIncassiCorrenteRA"
        Me.txtIncassiCorrenteRA.Size = New System.Drawing.Size(171, 20)
        Me.txtIncassiCorrenteRA.TabIndex = 10
        Me.txtIncassiCorrenteRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBudgetRA
        '
        Me.txtBudgetRA.BackColor = System.Drawing.Color.NavajoWhite
        Me.txtBudgetRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBudgetRA.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtBudgetRA.Location = New System.Drawing.Point(416, 153)
        Me.txtBudgetRA.Name = "txtBudgetRA"
        Me.txtBudgetRA.Size = New System.Drawing.Size(171, 20)
        Me.txtBudgetRA.TabIndex = 9
        Me.txtBudgetRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIncassiPrecedenteRA
        '
        Me.txtIncassiPrecedenteRA.BackColor = System.Drawing.Color.NavajoWhite
        Me.txtIncassiPrecedenteRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIncassiPrecedenteRA.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtIncassiPrecedenteRA.Location = New System.Drawing.Point(416, 128)
        Me.txtIncassiPrecedenteRA.Name = "txtIncassiPrecedenteRA"
        Me.txtIncassiPrecedenteRA.Size = New System.Drawing.Size(171, 20)
        Me.txtIncassiPrecedenteRA.TabIndex = 8
        Me.txtIncassiPrecedenteRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRappelPrincipaleRA
        '
        Me.lblRappelPrincipaleRA.AutoSize = True
        Me.lblRappelPrincipaleRA.BackColor = System.Drawing.Color.White
        Me.lblRappelPrincipaleRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRappelPrincipaleRA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRappelPrincipaleRA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRappelPrincipaleRA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRappelPrincipaleRA.ForeColor = System.Drawing.Color.Green
        Me.lblRappelPrincipaleRA.Location = New System.Drawing.Point(416, 253)
        Me.lblRappelPrincipaleRA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRappelPrincipaleRA.Name = "lblRappelPrincipaleRA"
        Me.lblRappelPrincipaleRA.Size = New System.Drawing.Size(171, 19)
        Me.lblRappelPrincipaleRA.TabIndex = 0
        Me.lblRappelPrincipaleRA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRappelRP
        '
        Me.lblRappelRP.AutoSize = True
        Me.lblRappelRP.BackColor = System.Drawing.Color.Teal
        Me.lblRappelRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRappelRP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRappelRP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRappelRP.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRappelRP.ForeColor = System.Drawing.Color.White
        Me.lblRappelRP.Location = New System.Drawing.Point(234, 403)
        Me.lblRappelRP.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRappelRP.Name = "lblRappelRP"
        Me.lblRappelRP.Size = New System.Drawing.Size(171, 19)
        Me.lblRappelRP.TabIndex = 5
        Me.lblRappelRP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRappelRA
        '
        Me.lblRappelRA.AutoSize = True
        Me.lblRappelRA.BackColor = System.Drawing.Color.Teal
        Me.lblRappelRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRappelRA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRappelRA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRappelRA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRappelRA.ForeColor = System.Drawing.Color.White
        Me.lblRappelRA.Location = New System.Drawing.Point(416, 403)
        Me.lblRappelRA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRappelRA.Name = "lblRappelRA"
        Me.lblRappelRA.Size = New System.Drawing.Size(171, 19)
        Me.lblRappelRA.TabIndex = 11
        Me.lblRappelRA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Green
        Me.Label18.Location = New System.Drawing.Point(13, 403)
        Me.Label18.Margin = New System.Windows.Forms.Padding(3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(215, 16)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "TOTALE"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Anno di Riferimento"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitoloRCG
        '
        Me.lblTitoloRCG.AutoSize = True
        Me.lblTitoloRCG.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblTitoloRCG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitoloRCG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitoloRCG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblTitoloRCG.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitoloRCG.Location = New System.Drawing.Point(598, 98)
        Me.lblTitoloRCG.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTitoloRCG.Name = "lblTitoloRCG"
        Me.lblTitoloRCG.Size = New System.Drawing.Size(171, 24)
        Me.lblTitoloRCG.TabIndex = 0
        Me.lblTitoloRCG.Text = "RCG"
        Me.lblTitoloRCG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtIncassiCorrenteRCG
        '
        Me.txtIncassiCorrenteRCG.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txtIncassiCorrenteRCG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIncassiCorrenteRCG.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtIncassiCorrenteRCG.Location = New System.Drawing.Point(598, 178)
        Me.txtIncassiCorrenteRCG.Name = "txtIncassiCorrenteRCG"
        Me.txtIncassiCorrenteRCG.Size = New System.Drawing.Size(171, 20)
        Me.txtIncassiCorrenteRCG.TabIndex = 14
        Me.txtIncassiCorrenteRCG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRappelPrincipaleRCG
        '
        Me.lblRappelPrincipaleRCG.AutoSize = True
        Me.lblRappelPrincipaleRCG.BackColor = System.Drawing.Color.White
        Me.lblRappelPrincipaleRCG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRappelPrincipaleRCG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRappelPrincipaleRCG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRappelPrincipaleRCG.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRappelPrincipaleRCG.ForeColor = System.Drawing.Color.Green
        Me.lblRappelPrincipaleRCG.Location = New System.Drawing.Point(598, 253)
        Me.lblRappelPrincipaleRCG.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRappelPrincipaleRCG.Name = "lblRappelPrincipaleRCG"
        Me.lblRappelPrincipaleRCG.Size = New System.Drawing.Size(171, 19)
        Me.lblRappelPrincipaleRCG.TabIndex = 0
        Me.lblRappelPrincipaleRCG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRappelRCG
        '
        Me.lblRappelRCG.AutoSize = True
        Me.lblRappelRCG.BackColor = System.Drawing.Color.Teal
        Me.lblRappelRCG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRappelRCG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRappelRCG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRappelRCG.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRappelRCG.ForeColor = System.Drawing.Color.White
        Me.lblRappelRCG.Location = New System.Drawing.Point(598, 403)
        Me.lblRappelRCG.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRappelRCG.Name = "lblRappelRCG"
        Me.lblRappelRCG.Size = New System.Drawing.Size(171, 19)
        Me.lblRappelRCG.TabIndex = 14
        Me.lblRappelRCG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBoxVita
        '
        Me.ComboBoxVita.BackColor = System.Drawing.Color.SandyBrown
        Me.ComboBoxVita.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBoxVita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxVita.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxVita.FormattingEnabled = True
        Me.ComboBoxVita.Location = New System.Drawing.Point(234, 13)
        Me.ComboBoxVita.Name = "ComboBoxVita"
        Me.ComboBoxVita.Size = New System.Drawing.Size(171, 21)
        Me.ComboBoxVita.TabIndex = 0
        '
        'ComboBoxAnno
        '
        Me.ComboBoxAnno.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBoxAnno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAnno.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxAnno.FormattingEnabled = True
        Me.ComboBoxAnno.Location = New System.Drawing.Point(234, 38)
        Me.ComboBoxAnno.Name = "ComboBoxAnno"
        Me.ComboBoxAnno.Size = New System.Drawing.Size(171, 21)
        Me.ComboBoxAnno.TabIndex = 1
        '
        'lblRappel
        '
        Me.lblRappel.AutoSize = True
        Me.lblRappel.BackColor = System.Drawing.Color.Teal
        Me.lblRappel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tableLayoutPanel1.SetColumnSpan(Me.lblRappel, 5)
        Me.lblRappel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRappel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRappel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRappel.ForeColor = System.Drawing.Color.White
        Me.lblRappel.Location = New System.Drawing.Point(234, 438)
        Me.lblRappel.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRappel.Name = "lblRappel"
        Me.lblRappel.Size = New System.Drawing.Size(535, 44)
        Me.lblRappel.TabIndex = 3
        Me.lblRappel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 228)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(215, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Rapporto S/P di Agenzia %"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 303)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(215, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Rapporto S/P Nazionale biennio %"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(13, 278)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Rappel Redditività"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRappelRedditivitaRA
        '
        Me.lblRappelRedditivitaRA.AutoSize = True
        Me.lblRappelRedditivitaRA.BackColor = System.Drawing.Color.White
        Me.lblRappelRedditivitaRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRappelRedditivitaRA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRappelRedditivitaRA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRappelRedditivitaRA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRappelRedditivitaRA.ForeColor = System.Drawing.Color.Green
        Me.lblRappelRedditivitaRA.Location = New System.Drawing.Point(416, 278)
        Me.lblRappelRedditivitaRA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRappelRedditivitaRA.Name = "lblRappelRedditivitaRA"
        Me.lblRappelRedditivitaRA.Size = New System.Drawing.Size(171, 19)
        Me.lblRappelRedditivitaRA.TabIndex = 0
        Me.lblRappelRedditivitaRA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRappelRedditivitaRP
        '
        Me.lblRappelRedditivitaRP.AutoSize = True
        Me.lblRappelRedditivitaRP.BackColor = System.Drawing.Color.White
        Me.lblRappelRedditivitaRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRappelRedditivitaRP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRappelRedditivitaRP.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRappelRedditivitaRP.ForeColor = System.Drawing.Color.Green
        Me.lblRappelRedditivitaRP.Location = New System.Drawing.Point(234, 278)
        Me.lblRappelRedditivitaRP.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRappelRedditivitaRP.Name = "lblRappelRedditivitaRP"
        Me.lblRappelRedditivitaRP.Size = New System.Drawing.Size(171, 19)
        Me.lblRappelRedditivitaRP.TabIndex = 1
        Me.lblRappelRedditivitaRP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPercentualeCorrenteRP
        '
        Me.lblPercentualeCorrenteRP.BackColor = System.Drawing.Color.White
        Me.lblPercentualeCorrenteRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPercentualeCorrenteRP.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPercentualeCorrenteRP.Location = New System.Drawing.Point(234, 203)
        Me.lblPercentualeCorrenteRP.Margin = New System.Windows.Forms.Padding(3)
        Me.lblPercentualeCorrenteRP.Name = "lblPercentualeCorrenteRP"
        Me.lblPercentualeCorrenteRP.Size = New System.Drawing.Size(171, 19)
        Me.lblPercentualeCorrenteRP.TabIndex = 5
        Me.lblPercentualeCorrenteRP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPercentualeCorrenteRA
        '
        Me.lblPercentualeCorrenteRA.BackColor = System.Drawing.Color.White
        Me.lblPercentualeCorrenteRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPercentualeCorrenteRA.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPercentualeCorrenteRA.Location = New System.Drawing.Point(416, 203)
        Me.lblPercentualeCorrenteRA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblPercentualeCorrenteRA.Name = "lblPercentualeCorrenteRA"
        Me.lblPercentualeCorrenteRA.Size = New System.Drawing.Size(171, 19)
        Me.lblPercentualeCorrenteRA.TabIndex = 10
        Me.lblPercentualeCorrenteRA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 203)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(215, 19)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Percentuale corretta incassi su budget"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBoxRapportoSPRP
        '
        Me.TextBoxRapportoSPRP.BackColor = System.Drawing.Color.Yellow
        Me.TextBoxRapportoSPRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxRapportoSPRP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxRapportoSPRP.Location = New System.Drawing.Point(234, 228)
        Me.TextBoxRapportoSPRP.Name = "TextBoxRapportoSPRP"
        Me.TextBoxRapportoSPRP.Size = New System.Drawing.Size(171, 20)
        Me.TextBoxRapportoSPRP.TabIndex = 5
        Me.TextBoxRapportoSPRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxRapportoSPNazionaleRP
        '
        Me.TextBoxRapportoSPNazionaleRP.BackColor = System.Drawing.Color.Yellow
        Me.TextBoxRapportoSPNazionaleRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxRapportoSPNazionaleRP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxRapportoSPNazionaleRP.Location = New System.Drawing.Point(234, 303)
        Me.TextBoxRapportoSPNazionaleRP.Name = "TextBoxRapportoSPNazionaleRP"
        Me.TextBoxRapportoSPNazionaleRP.Size = New System.Drawing.Size(171, 20)
        Me.TextBoxRapportoSPNazionaleRP.TabIndex = 6
        Me.TextBoxRapportoSPNazionaleRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxRapportoSPNazionaleRA
        '
        Me.TextBoxRapportoSPNazionaleRA.BackColor = System.Drawing.Color.Yellow
        Me.TextBoxRapportoSPNazionaleRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxRapportoSPNazionaleRA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxRapportoSPNazionaleRA.Location = New System.Drawing.Point(416, 303)
        Me.TextBoxRapportoSPNazionaleRA.Name = "TextBoxRapportoSPNazionaleRA"
        Me.TextBoxRapportoSPNazionaleRA.Size = New System.Drawing.Size(171, 20)
        Me.TextBoxRapportoSPNazionaleRA.TabIndex = 12
        Me.TextBoxRapportoSPNazionaleRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxRapportoSPRA
        '
        Me.TextBoxRapportoSPRA.BackColor = System.Drawing.Color.Yellow
        Me.TextBoxRapportoSPRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxRapportoSPRA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxRapportoSPRA.Location = New System.Drawing.Point(416, 228)
        Me.TextBoxRapportoSPRA.Name = "TextBoxRapportoSPRA"
        Me.TextBoxRapportoSPRA.Size = New System.Drawing.Size(171, 20)
        Me.TextBoxRapportoSPRA.TabIndex = 11
        Me.TextBoxRapportoSPRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxRapportoSPRCG
        '
        Me.TextBoxRapportoSPRCG.BackColor = System.Drawing.Color.Yellow
        Me.TextBoxRapportoSPRCG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxRapportoSPRCG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxRapportoSPRCG.Location = New System.Drawing.Point(598, 228)
        Me.TextBoxRapportoSPRCG.Name = "TextBoxRapportoSPRCG"
        Me.TextBoxRapportoSPRCG.Size = New System.Drawing.Size(171, 20)
        Me.TextBoxRapportoSPRCG.TabIndex = 15
        Me.TextBoxRapportoSPRCG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 325)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(215, 25)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Incassi nazionali"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 350)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(215, 25)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Peso incassi agenzia %"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Green
        Me.Label10.Location = New System.Drawing.Point(13, 375)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(215, 25)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Incentivo nazionale incassi"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBoxIncassiNazionaliRP
        '
        Me.TextBoxIncassiNazionaliRP.BackColor = System.Drawing.Color.PaleGreen
        Me.TextBoxIncassiNazionaliRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxIncassiNazionaliRP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxIncassiNazionaliRP.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxIncassiNazionaliRP.Location = New System.Drawing.Point(234, 328)
        Me.TextBoxIncassiNazionaliRP.Name = "TextBoxIncassiNazionaliRP"
        Me.TextBoxIncassiNazionaliRP.Size = New System.Drawing.Size(171, 23)
        Me.TextBoxIncassiNazionaliRP.TabIndex = 23
        Me.TextBoxIncassiNazionaliRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxIncassiNazionaliRA
        '
        Me.TextBoxIncassiNazionaliRA.BackColor = System.Drawing.Color.NavajoWhite
        Me.TextBoxIncassiNazionaliRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxIncassiNazionaliRA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxIncassiNazionaliRA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxIncassiNazionaliRA.Location = New System.Drawing.Point(416, 328)
        Me.TextBoxIncassiNazionaliRA.Name = "TextBoxIncassiNazionaliRA"
        Me.TextBoxIncassiNazionaliRA.Size = New System.Drawing.Size(171, 23)
        Me.TextBoxIncassiNazionaliRA.TabIndex = 24
        Me.TextBoxIncassiNazionaliRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxPesoAgenziaRP
        '
        Me.TextBoxPesoAgenziaRP.BackColor = System.Drawing.Color.Yellow
        Me.TextBoxPesoAgenziaRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPesoAgenziaRP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxPesoAgenziaRP.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPesoAgenziaRP.Location = New System.Drawing.Point(234, 353)
        Me.TextBoxPesoAgenziaRP.Name = "TextBoxPesoAgenziaRP"
        Me.TextBoxPesoAgenziaRP.Size = New System.Drawing.Size(171, 23)
        Me.TextBoxPesoAgenziaRP.TabIndex = 7
        Me.TextBoxPesoAgenziaRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxPesoAgenziaRA
        '
        Me.TextBoxPesoAgenziaRA.BackColor = System.Drawing.Color.Yellow
        Me.TextBoxPesoAgenziaRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPesoAgenziaRA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxPesoAgenziaRA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPesoAgenziaRA.Location = New System.Drawing.Point(416, 353)
        Me.TextBoxPesoAgenziaRA.Name = "TextBoxPesoAgenziaRA"
        Me.TextBoxPesoAgenziaRA.Size = New System.Drawing.Size(171, 23)
        Me.TextBoxPesoAgenziaRA.TabIndex = 13
        Me.TextBoxPesoAgenziaRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblRappelIncentivoNazionaleRP
        '
        Me.lblRappelIncentivoNazionaleRP.AutoSize = True
        Me.lblRappelIncentivoNazionaleRP.BackColor = System.Drawing.Color.White
        Me.lblRappelIncentivoNazionaleRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRappelIncentivoNazionaleRP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRappelIncentivoNazionaleRP.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRappelIncentivoNazionaleRP.ForeColor = System.Drawing.Color.Green
        Me.lblRappelIncentivoNazionaleRP.Location = New System.Drawing.Point(234, 378)
        Me.lblRappelIncentivoNazionaleRP.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRappelIncentivoNazionaleRP.Name = "lblRappelIncentivoNazionaleRP"
        Me.lblRappelIncentivoNazionaleRP.Size = New System.Drawing.Size(171, 19)
        Me.lblRappelIncentivoNazionaleRP.TabIndex = 27
        Me.lblRappelIncentivoNazionaleRP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRappelIncentivoNazionaleRA
        '
        Me.lblRappelIncentivoNazionaleRA.AutoSize = True
        Me.lblRappelIncentivoNazionaleRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRappelIncentivoNazionaleRA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRappelIncentivoNazionaleRA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRappelIncentivoNazionaleRA.ForeColor = System.Drawing.Color.Green
        Me.lblRappelIncentivoNazionaleRA.Location = New System.Drawing.Point(416, 378)
        Me.lblRappelIncentivoNazionaleRA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRappelIncentivoNazionaleRA.Name = "lblRappelIncentivoNazionaleRA"
        Me.lblRappelIncentivoNazionaleRA.Size = New System.Drawing.Size(171, 19)
        Me.lblRappelIncentivoNazionaleRA.TabIndex = 28
        Me.lblRappelIncentivoNazionaleRA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckedListBoCodici
        '
        Me.CheckedListBoCodici.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoCodici.FormattingEnabled = True
        Me.CheckedListBoCodici.IntegralHeight = False
        Me.CheckedListBoCodici.Location = New System.Drawing.Point(780, 128)
        Me.CheckedListBoCodici.Name = "CheckedListBoCodici"
        Me.tableLayoutPanel1.SetRowSpan(Me.CheckedListBoCodici, 11)
        Me.CheckedListBoCodici.Size = New System.Drawing.Size(128, 269)
        Me.CheckedListBoCodici.TabIndex = 30
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Location = New System.Drawing.Point(780, 98)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 24)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Codici gestiti"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonCalcola
        '
        Me.ButtonCalcola.BackColor = System.Drawing.Color.Orange
        Me.ButtonCalcola.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCalcola.FlatAppearance.BorderColor = System.Drawing.Color.Teal
        Me.ButtonCalcola.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCalcola.Location = New System.Drawing.Point(780, 438)
        Me.ButtonCalcola.Name = "ButtonCalcola"
        Me.ButtonCalcola.Size = New System.Drawing.Size(128, 44)
        Me.ButtonCalcola.TabIndex = 32
        Me.ButtonCalcola.Text = "Calcola"
        Me.ButtonCalcola.UseVisualStyleBackColor = False
        '
        'ButtonSelezionaTutti
        '
        Me.ButtonSelezionaTutti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSelezionaTutti.FlatAppearance.BorderColor = System.Drawing.Color.Teal
        Me.ButtonSelezionaTutti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSelezionaTutti.Location = New System.Drawing.Point(780, 403)
        Me.ButtonSelezionaTutti.Name = "ButtonSelezionaTutti"
        Me.ButtonSelezionaTutti.Size = New System.Drawing.Size(128, 19)
        Me.ButtonSelezionaTutti.TabIndex = 33
        Me.ButtonSelezionaTutti.Text = "Seleziona tutti"
        Me.ButtonSelezionaTutti.UseVisualStyleBackColor = True
        '
        'FormRappel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 519)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRappel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Simulatore Rappel"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblIncassiAnnoPrecedente As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBudgetAnnoCorrente As System.Windows.Forms.Label
    Friend WithEvents lblIncassiAnnoCorrente As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblRappelPrincipaleRP As System.Windows.Forms.Label
    Friend WithEvents lblTitoloRP As System.Windows.Forms.Label
    Friend WithEvents lblTitoloRA As System.Windows.Forms.Label
    Friend WithEvents txtIncassiPrecedenteRP As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBudgetRP As System.Windows.Forms.TextBox
    Friend WithEvents txtIncassiCorrenteRP As System.Windows.Forms.TextBox
    Friend WithEvents txtIncassiCorrenteRCG As System.Windows.Forms.TextBox
    Friend WithEvents txtIncassiCorrenteRA As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetRA As System.Windows.Forms.TextBox
    Friend WithEvents txtIncassiPrecedenteRA As System.Windows.Forms.TextBox
    Friend WithEvents lblRappelPrincipaleRA As System.Windows.Forms.Label
    Friend WithEvents lblRappelPrincipaleRCG As System.Windows.Forms.Label
    Friend WithEvents lblRappelRP As System.Windows.Forms.Label
    Friend WithEvents lblRappelRA As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblTitoloRCG As System.Windows.Forms.Label
    Friend WithEvents lblRappelRCG As System.Windows.Forms.Label
    Friend WithEvents ComboBoxVita As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxAnno As System.Windows.Forms.ComboBox
    Friend WithEvents lblRappel As System.Windows.Forms.Label
    Friend WithEvents lblTotale As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRappelRedditivitaRA As System.Windows.Forms.Label
    Friend WithEvents lblRappelRedditivitaRP As System.Windows.Forms.Label
    Friend WithEvents lblPercentualeCorrenteRP As System.Windows.Forms.Label
    Friend WithEvents lblPercentualeCorrenteRA As System.Windows.Forms.Label
    Friend WithEvents buttonGuida As System.Windows.Forms.Button
    Friend WithEvents buttonChiudi As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRapportoSPRP As TextBox
    Friend WithEvents TextBoxRapportoSPNazionaleRP As TextBox
    Friend WithEvents TextBoxRapportoSPNazionaleRA As TextBox
    Friend WithEvents TextBoxRapportoSPRA As TextBox
    Friend WithEvents TextBoxRapportoSPRCG As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBoxIncassiNazionaliRP As TextBox
    Friend WithEvents TextBoxIncassiNazionaliRA As TextBox
    Friend WithEvents TextBoxPesoAgenziaRP As TextBox
    Friend WithEvents TextBoxPesoAgenziaRA As TextBox
    Friend WithEvents lblRappelIncentivoNazionaleRP As Label
    Friend WithEvents lblRappelIncentivoNazionaleRA As Label
    Friend WithEvents CheckedListBoCodici As CheckedListBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ButtonCalcola As Button
    Friend WithEvents ButtonSelezionaTutti As Button
End Class
