<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGestioneFiltro
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
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
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.TabPageFiltri = New System.Windows.Forms.TabPage()
        Me.TabPageLayout = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonResetLayout = New System.Windows.Forms.Button()
        Me.LabelLayout = New System.Windows.Forms.Label()
        Me.CheckedListBoxColonne = New System.Windows.Forms.CheckedListBox()
        Me.ButtonColori = New System.Windows.Forms.Button()
        Me.ButtonDettaglio = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
        Me.TabPageFiltri.SuspendLayout()
        Me.TabPageLayout.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
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
        Me.ButtonOk.Location = New System.Drawing.Point(0, 324)
        Me.ButtonOk.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(150, 30)
        Me.ButtonOk.TabIndex = 0
        Me.ButtonOk.Text = "Ok"
        Me.ButtonOk.UseVisualStyleBackColor = False
        '
        'LabelCampo
        '
        Me.LabelCampo.BackColor = System.Drawing.Color.Gainsboro
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelCampo, 4)
        Me.LabelCampo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCampo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCampo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.LabelCampo.Location = New System.Drawing.Point(0, 0)
        Me.LabelCampo.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelCampo.Name = "LabelCampo"
        Me.LabelCampo.Size = New System.Drawing.Size(266, 20)
        Me.LabelCampo.TabIndex = 1
        Me.LabelCampo.Text = "LabelCampo"
        Me.LabelCampo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCancellaFiltri, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelCampo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckedListBoxValori, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonOrdinaCrescente, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonOrdinaDescrescente, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxOperatori, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxValore, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCancellaTuttiFiltri, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxCerca, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonMostraTutto, 3, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(266, 298)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'ButtonCancellaFiltri
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonCancellaFiltri, 2)
        Me.ButtonCancellaFiltri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCancellaFiltri.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonCancellaFiltri.FlatAppearance.BorderSize = 0
        Me.ButtonCancellaFiltri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Moccasin
        Me.ButtonCancellaFiltri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancellaFiltri.Location = New System.Drawing.Point(0, 70)
        Me.ButtonCancellaFiltri.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCancellaFiltri.Name = "ButtonCancellaFiltri"
        Me.ButtonCancellaFiltri.Size = New System.Drawing.Size(158, 25)
        Me.ButtonCancellaFiltri.TabIndex = 8
        Me.ButtonCancellaFiltri.Text = "Cancella filtro"
        Me.ButtonCancellaFiltri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCancellaFiltri.UseVisualStyleBackColor = True
        '
        'CheckedListBoxValori
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.CheckedListBoxValori, 4)
        Me.CheckedListBoxValori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxValori.FormattingEnabled = True
        Me.CheckedListBoxValori.IntegralHeight = False
        Me.CheckedListBoxValori.Location = New System.Drawing.Point(0, 139)
        Me.CheckedListBoxValori.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckedListBoxValori.Name = "CheckedListBoxValori"
        Me.CheckedListBoxValori.Size = New System.Drawing.Size(266, 159)
        Me.CheckedListBoxValori.TabIndex = 3
        '
        'ButtonOrdinaCrescente
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonOrdinaCrescente, 4)
        Me.ButtonOrdinaCrescente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOrdinaCrescente.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonOrdinaCrescente.FlatAppearance.BorderSize = 0
        Me.ButtonOrdinaCrescente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Moccasin
        Me.ButtonOrdinaCrescente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOrdinaCrescente.Location = New System.Drawing.Point(0, 20)
        Me.ButtonOrdinaCrescente.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonOrdinaCrescente.Name = "ButtonOrdinaCrescente"
        Me.ButtonOrdinaCrescente.Size = New System.Drawing.Size(266, 25)
        Me.ButtonOrdinaCrescente.TabIndex = 4
        Me.ButtonOrdinaCrescente.Text = "Ordina dalla A alla Z"
        Me.ButtonOrdinaCrescente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonOrdinaCrescente.UseVisualStyleBackColor = True
        '
        'ButtonOrdinaDescrescente
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonOrdinaDescrescente, 4)
        Me.ButtonOrdinaDescrescente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOrdinaDescrescente.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonOrdinaDescrescente.FlatAppearance.BorderSize = 0
        Me.ButtonOrdinaDescrescente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Moccasin
        Me.ButtonOrdinaDescrescente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOrdinaDescrescente.Location = New System.Drawing.Point(0, 45)
        Me.ButtonOrdinaDescrescente.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonOrdinaDescrescente.Name = "ButtonOrdinaDescrescente"
        Me.ButtonOrdinaDescrescente.Size = New System.Drawing.Size(266, 25)
        Me.ButtonOrdinaDescrescente.TabIndex = 5
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
        Me.ComboBoxOperatori.Location = New System.Drawing.Point(0, 95)
        Me.ComboBoxOperatori.Margin = New System.Windows.Forms.Padding(0)
        Me.ComboBoxOperatori.Name = "ComboBoxOperatori"
        Me.ComboBoxOperatori.Size = New System.Drawing.Size(79, 21)
        Me.ComboBoxOperatori.TabIndex = 6
        '
        'TextBoxValore
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxValore, 3)
        Me.TextBoxValore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxValore.Location = New System.Drawing.Point(79, 95)
        Me.TextBoxValore.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxValore.Name = "TextBoxValore"
        Me.TextBoxValore.Size = New System.Drawing.Size(187, 21)
        Me.TextBoxValore.TabIndex = 7
        Me.TextBoxValore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonCancellaTuttiFiltri
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonCancellaTuttiFiltri, 2)
        Me.ButtonCancellaTuttiFiltri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCancellaTuttiFiltri.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonCancellaTuttiFiltri.FlatAppearance.BorderSize = 0
        Me.ButtonCancellaTuttiFiltri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown
        Me.ButtonCancellaTuttiFiltri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancellaTuttiFiltri.Location = New System.Drawing.Point(158, 70)
        Me.ButtonCancellaTuttiFiltri.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCancellaTuttiFiltri.Name = "ButtonCancellaTuttiFiltri"
        Me.ButtonCancellaTuttiFiltri.Size = New System.Drawing.Size(108, 25)
        Me.ButtonCancellaTuttiFiltri.TabIndex = 9
        Me.ButtonCancellaTuttiFiltri.Text = "Button1"
        Me.ButtonCancellaTuttiFiltri.UseVisualStyleBackColor = True
        '
        'TextBoxCerca
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxCerca, 2)
        Me.TextBoxCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCerca.Location = New System.Drawing.Point(79, 117)
        Me.TextBoxCerca.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxCerca.Name = "TextBoxCerca"
        Me.TextBoxCerca.Size = New System.Drawing.Size(158, 21)
        Me.TextBoxCerca.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(0, 117)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 22)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Cerca"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonMostraTutto
        '
        Me.ButtonMostraTutto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonMostraTutto.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonMostraTutto.FlatAppearance.BorderSize = 0
        Me.ButtonMostraTutto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonMostraTutto.Location = New System.Drawing.Point(237, 117)
        Me.ButtonMostraTutto.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonMostraTutto.Name = "ButtonMostraTutto"
        Me.ButtonMostraTutto.Size = New System.Drawing.Size(29, 22)
        Me.ButtonMostraTutto.TabIndex = 12
        Me.ButtonMostraTutto.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAnnulla.FlatAppearance.BorderSize = 0
        Me.ButtonAnnulla.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown
        Me.ButtonAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnnulla.Location = New System.Drawing.Point(150, 324)
        Me.ButtonAnnulla.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(82, 30)
        Me.ButtonAnnulla.TabIndex = 2
        Me.ButtonAnnulla.Text = "Annulla"
        Me.ButtonAnnulla.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel1.Size = New System.Drawing.Size(280, 360)
        Me.Panel1.TabIndex = 3
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonAnnulla, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TabControlMain, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonOk, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonDettaglio, 2, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(274, 354)
        Me.TableLayoutPanel3.TabIndex = 4
        '
        'TabControlMain
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.TabControlMain, 3)
        Me.TabControlMain.Controls.Add(Me.TabPageFiltri)
        Me.TabControlMain.Controls.Add(Me.TabPageLayout)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.HotTrack = True
        Me.TabControlMain.ItemSize = New System.Drawing.Size(130, 18)
        Me.TabControlMain.Location = New System.Drawing.Point(0, 0)
        Me.TabControlMain.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(274, 324)
        Me.TabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControlMain.TabIndex = 3
        '
        'TabPageFiltri
        '
        Me.TabPageFiltri.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPageFiltri.Location = New System.Drawing.Point(4, 22)
        Me.TabPageFiltri.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPageFiltri.Name = "TabPageFiltri"
        Me.TabPageFiltri.Size = New System.Drawing.Size(266, 298)
        Me.TabPageFiltri.TabIndex = 0
        Me.TabPageFiltri.Text = "Filtri"
        Me.TabPageFiltri.UseVisualStyleBackColor = True
        '
        'TabPageLayout
        '
        Me.TabPageLayout.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPageLayout.Location = New System.Drawing.Point(4, 22)
        Me.TabPageLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPageLayout.Name = "TabPageLayout"
        Me.TabPageLayout.Size = New System.Drawing.Size(266, 298)
        Me.TabPageLayout.TabIndex = 1
        Me.TabPageLayout.Text = "Layout"
        Me.TabPageLayout.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonResetLayout, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelLayout, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckedListBoxColonne, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonColori, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(266, 298)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'ButtonResetLayout
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.ButtonResetLayout, 3)
        Me.ButtonResetLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonResetLayout.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonResetLayout.FlatAppearance.BorderSize = 0
        Me.ButtonResetLayout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Moccasin
        Me.ButtonResetLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonResetLayout.Location = New System.Drawing.Point(0, 45)
        Me.ButtonResetLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonResetLayout.Name = "ButtonResetLayout"
        Me.ButtonResetLayout.Size = New System.Drawing.Size(266, 25)
        Me.ButtonResetLayout.TabIndex = 8
        Me.ButtonResetLayout.Text = "Elimina layout"
        Me.ButtonResetLayout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonResetLayout.UseVisualStyleBackColor = True
        '
        'LabelLayout
        '
        Me.LabelLayout.BackColor = System.Drawing.Color.Gainsboro
        Me.TableLayoutPanel2.SetColumnSpan(Me.LabelLayout, 3)
        Me.LabelLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelLayout.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLayout.ForeColor = System.Drawing.Color.DodgerBlue
        Me.LabelLayout.Location = New System.Drawing.Point(0, 0)
        Me.LabelLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelLayout.Name = "LabelLayout"
        Me.LabelLayout.Size = New System.Drawing.Size(266, 20)
        Me.LabelLayout.TabIndex = 1
        Me.LabelLayout.Text = "Layout colonne"
        Me.LabelLayout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckedListBoxColonne
        '
        Me.CheckedListBoxColonne.CheckOnClick = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.CheckedListBoxColonne, 3)
        Me.CheckedListBoxColonne.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxColonne.FormattingEnabled = True
        Me.CheckedListBoxColonne.IntegralHeight = False
        Me.CheckedListBoxColonne.Location = New System.Drawing.Point(0, 70)
        Me.CheckedListBoxColonne.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckedListBoxColonne.Name = "CheckedListBoxColonne"
        Me.CheckedListBoxColonne.Size = New System.Drawing.Size(266, 228)
        Me.CheckedListBoxColonne.TabIndex = 3
        '
        'ButtonColori
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.ButtonColori, 3)
        Me.ButtonColori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonColori.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonColori.FlatAppearance.BorderSize = 0
        Me.ButtonColori.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Moccasin
        Me.ButtonColori.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonColori.Location = New System.Drawing.Point(0, 20)
        Me.ButtonColori.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonColori.Name = "ButtonColori"
        Me.ButtonColori.Size = New System.Drawing.Size(266, 25)
        Me.ButtonColori.TabIndex = 5
        Me.ButtonColori.Text = "Colore sfondo"
        Me.ButtonColori.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonColori.UseVisualStyleBackColor = True
        '
        'ButtonDettaglio
        '
        Me.ButtonDettaglio.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonDettaglio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonDettaglio.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonDettaglio.FlatAppearance.BorderSize = 0
        Me.ButtonDettaglio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.ButtonDettaglio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDettaglio.Location = New System.Drawing.Point(232, 324)
        Me.ButtonDettaglio.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonDettaglio.Name = "ButtonDettaglio"
        Me.ButtonDettaglio.Size = New System.Drawing.Size(42, 30)
        Me.ButtonDettaglio.TabIndex = 4
        Me.ButtonDettaglio.Text = "Dettaglio"
        Me.ButtonDettaglio.UseVisualStyleBackColor = False
        '
        'FormGestioneFiltro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(280, 360)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormGestioneFiltro"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "FormFiltro"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPageFiltri.ResumeLayout(False)
        Me.TabPageLayout.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents LabelCampo As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
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
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonResetLayout As System.Windows.Forms.Button
    Friend WithEvents LabelLayout As System.Windows.Forms.Label
    Friend WithEvents CheckedListBoxColonne As System.Windows.Forms.CheckedListBox
    Friend WithEvents ButtonColori As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxCerca As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonMostraTutto As System.Windows.Forms.Button
    Friend WithEvents ButtonDettaglio As System.Windows.Forms.Button
End Class
