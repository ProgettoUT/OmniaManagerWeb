<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGestioneFiltro
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
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.LabelCampo = New System.Windows.Forms.Label()
        Me.tlpFiltri = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonDiverso = New System.Windows.Forms.Button()
        Me.TextBoxValore2 = New System.Windows.Forms.TextBox()
        Me.ButtonCancellaFiltri = New System.Windows.Forms.Button()
        Me.CheckedListBoxValori = New System.Windows.Forms.CheckedListBox()
        Me.ButtonOrdinaCrescente = New System.Windows.Forms.Button()
        Me.ButtonOrdinaDescrescente = New System.Windows.Forms.Button()
        Me.ComboBoxOperatori = New System.Windows.Forms.ComboBox()
        Me.TextBoxValore = New System.Windows.Forms.TextBox()
        Me.ButtonCancellaTuttiFiltri = New System.Windows.Forms.Button()
        Me.TextBoxCerca = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonMostraTutto = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonSelezione = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.TabPageFiltri = New System.Windows.Forms.TabPage()
        Me.TabPageLayout = New System.Windows.Forms.TabPage()
        Me.tlpLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonColoreSfondo = New System.Windows.Forms.Button()
        Me.ButtonResetLayout = New System.Windows.Forms.Button()
        Me.LabelLayout = New System.Windows.Forms.Label()
        Me.CheckedListBoxColonne = New System.Windows.Forms.CheckedListBox()
        Me.ButtonSu = New System.Windows.Forms.Button()
        Me.ButtonGiu = New System.Windows.Forms.Button()
        Me.ButtonSpostaColonnaIn = New System.Windows.Forms.Button()
        Me.ButtonColoreTesto = New System.Windows.Forms.Button()
        Me.ButtonDettaglio = New System.Windows.Forms.Button()
        Me.tlpFiltri.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
        Me.TabPageFiltri.SuspendLayout()
        Me.TabPageLayout.SuspendLayout()
        Me.tlpLayout.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonOk
        '
        Me.ButtonOk.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOk.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonOk.FlatAppearance.BorderSize = 0
        Me.ButtonOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen
        Me.ButtonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOk.Location = New System.Drawing.Point(0, 347)
        Me.ButtonOk.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(150, 27)
        Me.ButtonOk.TabIndex = 16
        Me.ButtonOk.Text = "Ok"
        Me.ButtonOk.UseVisualStyleBackColor = False
        '
        'LabelCampo
        '
        Me.LabelCampo.BackColor = System.Drawing.Color.Gainsboro
        Me.tlpFiltri.SetColumnSpan(Me.LabelCampo, 5)
        Me.LabelCampo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCampo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCampo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.LabelCampo.Location = New System.Drawing.Point(0, 0)
        Me.LabelCampo.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelCampo.Name = "LabelCampo"
        Me.LabelCampo.Size = New System.Drawing.Size(266, 18)
        Me.LabelCampo.TabIndex = 19
        Me.LabelCampo.Text = "LabelCampo"
        Me.LabelCampo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tlpFiltri
        '
        Me.tlpFiltri.ColumnCount = 5
        Me.tlpFiltri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.tlpFiltri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.tlpFiltri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpFiltri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpFiltri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpFiltri.Controls.Add(Me.ButtonDiverso, 3, 4)
        Me.tlpFiltri.Controls.Add(Me.TextBoxValore2, 3, 5)
        Me.tlpFiltri.Controls.Add(Me.ButtonCancellaFiltri, 0, 3)
        Me.tlpFiltri.Controls.Add(Me.LabelCampo, 0, 0)
        Me.tlpFiltri.Controls.Add(Me.CheckedListBoxValori, 0, 7)
        Me.tlpFiltri.Controls.Add(Me.ButtonOrdinaCrescente, 0, 1)
        Me.tlpFiltri.Controls.Add(Me.ButtonOrdinaDescrescente, 0, 2)
        Me.tlpFiltri.Controls.Add(Me.ComboBoxOperatori, 0, 5)
        Me.tlpFiltri.Controls.Add(Me.TextBoxValore, 1, 5)
        Me.tlpFiltri.Controls.Add(Me.ButtonCancellaTuttiFiltri, 2, 3)
        Me.tlpFiltri.Controls.Add(Me.TextBoxCerca, 1, 6)
        Me.tlpFiltri.Controls.Add(Me.Label1, 0, 6)
        Me.tlpFiltri.Controls.Add(Me.ButtonMostraTutto, 4, 6)
        Me.tlpFiltri.Controls.Add(Me.Label2, 2, 5)
        Me.tlpFiltri.Controls.Add(Me.ButtonSelezione, 0, 4)
        Me.tlpFiltri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFiltri.Location = New System.Drawing.Point(0, 0)
        Me.tlpFiltri.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpFiltri.Name = "tlpFiltri"
        Me.tlpFiltri.RowCount = 8
        Me.tlpFiltri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpFiltri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFiltri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFiltri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFiltri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpFiltri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpFiltri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpFiltri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFiltri.Size = New System.Drawing.Size(266, 321)
        Me.tlpFiltri.TabIndex = 21
        '
        'ButtonDiverso
        '
        Me.tlpFiltri.SetColumnSpan(Me.ButtonDiverso, 2)
        Me.ButtonDiverso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonDiverso.FlatAppearance.BorderSize = 0
        Me.ButtonDiverso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonDiverso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDiverso.Location = New System.Drawing.Point(189, 93)
        Me.ButtonDiverso.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.ButtonDiverso.Name = "ButtonDiverso"
        Me.ButtonDiverso.Size = New System.Drawing.Size(77, 23)
        Me.ButtonDiverso.TabIndex = 28
        Me.ButtonDiverso.Text = "diverso da..."
        Me.ButtonDiverso.UseVisualStyleBackColor = True
        '
        'TextBoxValore2
        '
        Me.tlpFiltri.SetColumnSpan(Me.TextBoxValore2, 2)
        Me.TextBoxValore2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxValore2.Location = New System.Drawing.Point(189, 118)
        Me.TextBoxValore2.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxValore2.Name = "TextBoxValore2"
        Me.TextBoxValore2.Size = New System.Drawing.Size(77, 21)
        Me.TextBoxValore2.TabIndex = 6
        Me.TextBoxValore2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonCancellaFiltri
        '
        Me.tlpFiltri.SetColumnSpan(Me.ButtonCancellaFiltri, 2)
        Me.ButtonCancellaFiltri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCancellaFiltri.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonCancellaFiltri.FlatAppearance.BorderSize = 0
        Me.ButtonCancellaFiltri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Moccasin
        Me.ButtonCancellaFiltri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancellaFiltri.Location = New System.Drawing.Point(0, 68)
        Me.ButtonCancellaFiltri.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCancellaFiltri.Name = "ButtonCancellaFiltri"
        Me.ButtonCancellaFiltri.Size = New System.Drawing.Size(174, 25)
        Me.ButtonCancellaFiltri.TabIndex = 2
        Me.ButtonCancellaFiltri.Text = "Cancella filtro"
        Me.ButtonCancellaFiltri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCancellaFiltri.UseVisualStyleBackColor = True
        '
        'CheckedListBoxValori
        '
        Me.tlpFiltri.SetColumnSpan(Me.CheckedListBoxValori, 5)
        Me.CheckedListBoxValori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxValori.FormattingEnabled = True
        Me.CheckedListBoxValori.IntegralHeight = False
        Me.CheckedListBoxValori.Location = New System.Drawing.Point(0, 162)
        Me.CheckedListBoxValori.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckedListBoxValori.Name = "CheckedListBoxValori"
        Me.CheckedListBoxValori.Size = New System.Drawing.Size(266, 159)
        Me.CheckedListBoxValori.TabIndex = 9
        '
        'ButtonOrdinaCrescente
        '
        Me.tlpFiltri.SetColumnSpan(Me.ButtonOrdinaCrescente, 5)
        Me.ButtonOrdinaCrescente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOrdinaCrescente.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonOrdinaCrescente.FlatAppearance.BorderSize = 0
        Me.ButtonOrdinaCrescente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Moccasin
        Me.ButtonOrdinaCrescente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOrdinaCrescente.Location = New System.Drawing.Point(0, 18)
        Me.ButtonOrdinaCrescente.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonOrdinaCrescente.Name = "ButtonOrdinaCrescente"
        Me.ButtonOrdinaCrescente.Size = New System.Drawing.Size(266, 25)
        Me.ButtonOrdinaCrescente.TabIndex = 0
        Me.ButtonOrdinaCrescente.Text = "Ordina dalla A alla Z"
        Me.ButtonOrdinaCrescente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonOrdinaCrescente.UseVisualStyleBackColor = True
        '
        'ButtonOrdinaDescrescente
        '
        Me.tlpFiltri.SetColumnSpan(Me.ButtonOrdinaDescrescente, 5)
        Me.ButtonOrdinaDescrescente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOrdinaDescrescente.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonOrdinaDescrescente.FlatAppearance.BorderSize = 0
        Me.ButtonOrdinaDescrescente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Moccasin
        Me.ButtonOrdinaDescrescente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOrdinaDescrescente.Location = New System.Drawing.Point(0, 43)
        Me.ButtonOrdinaDescrescente.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonOrdinaDescrescente.Name = "ButtonOrdinaDescrescente"
        Me.ButtonOrdinaDescrescente.Size = New System.Drawing.Size(266, 25)
        Me.ButtonOrdinaDescrescente.TabIndex = 1
        Me.ButtonOrdinaDescrescente.Text = "Ordina dalla Z alla A"
        Me.ButtonOrdinaDescrescente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonOrdinaDescrescente.UseVisualStyleBackColor = True
        '
        'ComboBoxOperatori
        '
        Me.ComboBoxOperatori.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxOperatori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxOperatori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxOperatori.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxOperatori.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxOperatori.FormattingEnabled = True
        Me.ComboBoxOperatori.Location = New System.Drawing.Point(0, 118)
        Me.ComboBoxOperatori.Margin = New System.Windows.Forms.Padding(0)
        Me.ComboBoxOperatori.Name = "ComboBoxOperatori"
        Me.ComboBoxOperatori.Size = New System.Drawing.Size(87, 21)
        Me.ComboBoxOperatori.TabIndex = 4
        '
        'TextBoxValore
        '
        Me.TextBoxValore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxValore.Location = New System.Drawing.Point(87, 118)
        Me.TextBoxValore.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxValore.Name = "TextBoxValore"
        Me.TextBoxValore.Size = New System.Drawing.Size(87, 21)
        Me.TextBoxValore.TabIndex = 5
        Me.TextBoxValore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonCancellaTuttiFiltri
        '
        Me.tlpFiltri.SetColumnSpan(Me.ButtonCancellaTuttiFiltri, 3)
        Me.ButtonCancellaTuttiFiltri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCancellaTuttiFiltri.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonCancellaTuttiFiltri.FlatAppearance.BorderSize = 0
        Me.ButtonCancellaTuttiFiltri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown
        Me.ButtonCancellaTuttiFiltri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancellaTuttiFiltri.Location = New System.Drawing.Point(174, 68)
        Me.ButtonCancellaTuttiFiltri.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCancellaTuttiFiltri.Name = "ButtonCancellaTuttiFiltri"
        Me.ButtonCancellaTuttiFiltri.Size = New System.Drawing.Size(92, 25)
        Me.ButtonCancellaTuttiFiltri.TabIndex = 3
        Me.ButtonCancellaTuttiFiltri.Text = "Button1"
        Me.ButtonCancellaTuttiFiltri.UseVisualStyleBackColor = True
        '
        'TextBoxCerca
        '
        Me.tlpFiltri.SetColumnSpan(Me.TextBoxCerca, 3)
        Me.TextBoxCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCerca.Location = New System.Drawing.Point(87, 140)
        Me.TextBoxCerca.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxCerca.Name = "TextBoxCerca"
        Me.TextBoxCerca.Size = New System.Drawing.Size(152, 21)
        Me.TextBoxCerca.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(0, 140)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 22)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Cerca"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonMostraTutto
        '
        Me.ButtonMostraTutto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonMostraTutto.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonMostraTutto.FlatAppearance.BorderSize = 0
        Me.ButtonMostraTutto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonMostraTutto.Location = New System.Drawing.Point(239, 140)
        Me.ButtonMostraTutto.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonMostraTutto.Name = "ButtonMostraTutto"
        Me.ButtonMostraTutto.Size = New System.Drawing.Size(27, 22)
        Me.ButtonMostraTutto.TabIndex = 8
        Me.ButtonMostraTutto.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(177, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(9, 22)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "e"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonSelezione
        '
        Me.tlpFiltri.SetColumnSpan(Me.ButtonSelezione, 3)
        Me.ButtonSelezione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSelezione.FlatAppearance.BorderSize = 0
        Me.ButtonSelezione.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonSelezione.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSelezione.Location = New System.Drawing.Point(0, 93)
        Me.ButtonSelezione.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.ButtonSelezione.Name = "ButtonSelezione"
        Me.ButtonSelezione.Size = New System.Drawing.Size(189, 23)
        Me.ButtonSelezione.TabIndex = 27
        Me.ButtonSelezione.Text = "Uguale al valore selezionato"
        Me.ButtonSelezione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSelezione.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAnnulla.FlatAppearance.BorderSize = 0
        Me.ButtonAnnulla.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown
        Me.ButtonAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnnulla.Location = New System.Drawing.Point(150, 347)
        Me.ButtonAnnulla.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(82, 27)
        Me.ButtonAnnulla.TabIndex = 17
        Me.ButtonAnnulla.Text = "Annulla"
        Me.ButtonAnnulla.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.tlpMain)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel1.Size = New System.Drawing.Size(280, 380)
        Me.Panel1.TabIndex = 22
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 3
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlpMain.Controls.Add(Me.ButtonAnnulla, 1, 1)
        Me.tlpMain.Controls.Add(Me.TabControlMain, 0, 0)
        Me.tlpMain.Controls.Add(Me.ButtonOk, 0, 1)
        Me.tlpMain.Controls.Add(Me.ButtonDettaglio, 2, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(2, 2)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlpMain.Size = New System.Drawing.Size(274, 374)
        Me.tlpMain.TabIndex = 25
        '
        'TabControlMain
        '
        Me.tlpMain.SetColumnSpan(Me.TabControlMain, 3)
        Me.TabControlMain.Controls.Add(Me.TabPageFiltri)
        Me.TabControlMain.Controls.Add(Me.TabPageLayout)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.HotTrack = True
        Me.TabControlMain.ItemSize = New System.Drawing.Size(130, 18)
        Me.TabControlMain.Location = New System.Drawing.Point(0, 0)
        Me.TabControlMain.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(274, 347)
        Me.TabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControlMain.TabIndex = 23
        Me.TabControlMain.TabStop = False
        '
        'TabPageFiltri
        '
        Me.TabPageFiltri.Controls.Add(Me.tlpFiltri)
        Me.TabPageFiltri.Location = New System.Drawing.Point(4, 22)
        Me.TabPageFiltri.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPageFiltri.Name = "TabPageFiltri"
        Me.TabPageFiltri.Size = New System.Drawing.Size(266, 321)
        Me.TabPageFiltri.TabIndex = 0
        Me.TabPageFiltri.Text = "Filtri"
        Me.TabPageFiltri.UseVisualStyleBackColor = True
        '
        'TabPageLayout
        '
        Me.TabPageLayout.Controls.Add(Me.tlpLayout)
        Me.TabPageLayout.Location = New System.Drawing.Point(4, 22)
        Me.TabPageLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPageLayout.Name = "TabPageLayout"
        Me.TabPageLayout.Size = New System.Drawing.Size(266, 321)
        Me.TabPageLayout.TabIndex = 1
        Me.TabPageLayout.Text = "Layout"
        Me.TabPageLayout.UseVisualStyleBackColor = True
        '
        'tlpLayout
        '
        Me.tlpLayout.ColumnCount = 3
        Me.tlpLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpLayout.Controls.Add(Me.ButtonColoreSfondo, 0, 1)
        Me.tlpLayout.Controls.Add(Me.ButtonResetLayout, 0, 2)
        Me.tlpLayout.Controls.Add(Me.LabelLayout, 0, 0)
        Me.tlpLayout.Controls.Add(Me.CheckedListBoxColonne, 0, 3)
        Me.tlpLayout.Controls.Add(Me.ButtonSu, 2, 3)
        Me.tlpLayout.Controls.Add(Me.ButtonGiu, 2, 4)
        Me.tlpLayout.Controls.Add(Me.ButtonSpostaColonnaIn, 2, 5)
        Me.tlpLayout.Controls.Add(Me.ButtonColoreTesto, 1, 1)
        Me.tlpLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpLayout.Location = New System.Drawing.Point(0, 0)
        Me.tlpLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpLayout.Name = "tlpLayout"
        Me.tlpLayout.RowCount = 6
        Me.tlpLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpLayout.Size = New System.Drawing.Size(266, 321)
        Me.tlpLayout.TabIndex = 24
        '
        'ButtonColoreSfondo
        '
        Me.ButtonColoreSfondo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonColoreSfondo.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonColoreSfondo.FlatAppearance.BorderSize = 0
        Me.ButtonColoreSfondo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Moccasin
        Me.ButtonColoreSfondo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonColoreSfondo.Location = New System.Drawing.Point(0, 20)
        Me.ButtonColoreSfondo.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonColoreSfondo.Name = "ButtonColoreSfondo"
        Me.ButtonColoreSfondo.Size = New System.Drawing.Size(120, 25)
        Me.ButtonColoreSfondo.TabIndex = 11
        Me.ButtonColoreSfondo.Text = "Colore sfondo"
        Me.ButtonColoreSfondo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonColoreSfondo.UseVisualStyleBackColor = True
        '
        'ButtonResetLayout
        '
        Me.tlpLayout.SetColumnSpan(Me.ButtonResetLayout, 3)
        Me.ButtonResetLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonResetLayout.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonResetLayout.FlatAppearance.BorderSize = 0
        Me.ButtonResetLayout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Moccasin
        Me.ButtonResetLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonResetLayout.Location = New System.Drawing.Point(0, 45)
        Me.ButtonResetLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonResetLayout.Name = "ButtonResetLayout"
        Me.ButtonResetLayout.Size = New System.Drawing.Size(266, 25)
        Me.ButtonResetLayout.TabIndex = 12
        Me.ButtonResetLayout.Text = "Elimina layout"
        Me.ButtonResetLayout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonResetLayout.UseVisualStyleBackColor = True
        '
        'LabelLayout
        '
        Me.LabelLayout.BackColor = System.Drawing.Color.Gainsboro
        Me.tlpLayout.SetColumnSpan(Me.LabelLayout, 3)
        Me.LabelLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelLayout.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLayout.ForeColor = System.Drawing.Color.DodgerBlue
        Me.LabelLayout.Location = New System.Drawing.Point(0, 0)
        Me.LabelLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelLayout.Name = "LabelLayout"
        Me.LabelLayout.Size = New System.Drawing.Size(266, 20)
        Me.LabelLayout.TabIndex = 20
        Me.LabelLayout.Text = "Layout colonne"
        Me.LabelLayout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckedListBoxColonne
        '
        Me.CheckedListBoxColonne.CheckOnClick = True
        Me.tlpLayout.SetColumnSpan(Me.CheckedListBoxColonne, 2)
        Me.CheckedListBoxColonne.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxColonne.FormattingEnabled = True
        Me.CheckedListBoxColonne.IntegralHeight = False
        Me.CheckedListBoxColonne.Location = New System.Drawing.Point(0, 70)
        Me.CheckedListBoxColonne.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckedListBoxColonne.Name = "CheckedListBoxColonne"
        Me.tlpLayout.SetRowSpan(Me.CheckedListBoxColonne, 3)
        Me.CheckedListBoxColonne.Size = New System.Drawing.Size(240, 251)
        Me.CheckedListBoxColonne.TabIndex = 13
        '
        'ButtonSu
        '
        Me.ButtonSu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSu.Location = New System.Drawing.Point(243, 73)
        Me.ButtonSu.Name = "ButtonSu"
        Me.ButtonSu.Size = New System.Drawing.Size(20, 107)
        Me.ButtonSu.TabIndex = 14
        Me.ButtonSu.Text = "Button1"
        Me.ButtonSu.UseVisualStyleBackColor = True
        '
        'ButtonGiu
        '
        Me.ButtonGiu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonGiu.Location = New System.Drawing.Point(243, 186)
        Me.ButtonGiu.Name = "ButtonGiu"
        Me.ButtonGiu.Size = New System.Drawing.Size(20, 107)
        Me.ButtonGiu.TabIndex = 15
        Me.ButtonGiu.Text = "Button2"
        Me.ButtonGiu.UseVisualStyleBackColor = True
        '
        'ButtonSpostaColonnaIn
        '
        Me.ButtonSpostaColonnaIn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSpostaColonnaIn.Location = New System.Drawing.Point(243, 299)
        Me.ButtonSpostaColonnaIn.Name = "ButtonSpostaColonnaIn"
        Me.ButtonSpostaColonnaIn.Size = New System.Drawing.Size(20, 19)
        Me.ButtonSpostaColonnaIn.TabIndex = 21
        Me.ButtonSpostaColonnaIn.Text = "Button1"
        Me.ButtonSpostaColonnaIn.UseVisualStyleBackColor = True
        '
        'ButtonColoreTesto
        '
        Me.tlpLayout.SetColumnSpan(Me.ButtonColoreTesto, 2)
        Me.ButtonColoreTesto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonColoreTesto.FlatAppearance.BorderSize = 0
        Me.ButtonColoreTesto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Moccasin
        Me.ButtonColoreTesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonColoreTesto.Location = New System.Drawing.Point(120, 20)
        Me.ButtonColoreTesto.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonColoreTesto.Name = "ButtonColoreTesto"
        Me.ButtonColoreTesto.Size = New System.Drawing.Size(146, 25)
        Me.ButtonColoreTesto.TabIndex = 22
        Me.ButtonColoreTesto.Text = "Button1"
        Me.ButtonColoreTesto.UseVisualStyleBackColor = True
        '
        'ButtonDettaglio
        '
        Me.ButtonDettaglio.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonDettaglio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonDettaglio.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonDettaglio.FlatAppearance.BorderSize = 0
        Me.ButtonDettaglio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.ButtonDettaglio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDettaglio.Location = New System.Drawing.Point(232, 347)
        Me.ButtonDettaglio.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonDettaglio.Name = "ButtonDettaglio"
        Me.ButtonDettaglio.Size = New System.Drawing.Size(42, 27)
        Me.ButtonDettaglio.TabIndex = 10
        Me.ButtonDettaglio.Text = "Dettaglio"
        Me.ButtonDettaglio.UseVisualStyleBackColor = False
        '
        'FormGestioneFiltro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(280, 380)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormGestioneFiltro"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "FormFiltro"
        Me.tlpFiltri.ResumeLayout(False)
        Me.tlpFiltri.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.tlpMain.ResumeLayout(False)
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPageFiltri.ResumeLayout(False)
        Me.TabPageLayout.ResumeLayout(False)
        Me.tlpLayout.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents LabelCampo As System.Windows.Forms.Label
    Friend WithEvents tlpFiltri As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
    Friend WithEvents CheckedListBoxValori As System.Windows.Forms.CheckedListBox
    Friend WithEvents ButtonOrdinaCrescente As System.Windows.Forms.Button
    Friend WithEvents ButtonOrdinaDescrescente As System.Windows.Forms.Button
    Friend WithEvents ComboBoxOperatori As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxValore As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCancellaFiltri As System.Windows.Forms.Button
    Friend WithEvents ButtonCancellaTuttiFiltri As System.Windows.Forms.Button
    Friend WithEvents TabControlMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPageFiltri As System.Windows.Forms.TabPage
    Friend WithEvents TabPageLayout As System.Windows.Forms.TabPage
    Friend WithEvents tlpLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonResetLayout As System.Windows.Forms.Button
    Friend WithEvents LabelLayout As System.Windows.Forms.Label
    Friend WithEvents CheckedListBoxColonne As System.Windows.Forms.CheckedListBox
    Friend WithEvents ButtonColoreSfondo As System.Windows.Forms.Button
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxCerca As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonMostraTutto As System.Windows.Forms.Button
    Friend WithEvents ButtonDettaglio As System.Windows.Forms.Button
    Friend WithEvents ButtonSu As System.Windows.Forms.Button
    Friend WithEvents ButtonGiu As System.Windows.Forms.Button
    Friend WithEvents TextBoxValore2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonSpostaColonnaIn As System.Windows.Forms.Button
    Friend WithEvents ButtonColoreTesto As System.Windows.Forms.Button
    Friend WithEvents ButtonSelezione As Windows.Forms.Button
    Friend WithEvents ButtonDiverso As Windows.Forms.Button
End Class
