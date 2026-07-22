<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConfigura
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
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.ButtonSalva = New System.Windows.Forms.Button()
        Me.TabMain = New Utx.UtTabControl()
        Me.TabPageContatti = New System.Windows.Forms.TabPage()
        Me.tlpContatti = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonPredefinita = New System.Windows.Forms.Button()
        Me.ListBoxMail = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxMail = New System.Windows.Forms.TextBox()
        Me.ButtonAggiungi = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxSmtp = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxSmtpUtente = New System.Windows.Forms.TextBox()
        Me.TextBoxSmtpPw = New System.Windows.Forms.TextBox()
        Me.TextBoxSmtpPorta = New System.Windows.Forms.TextBox()
        Me.CheckBoxSSL = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSmtpAUA = New System.Windows.Forms.CheckBox()
        Me.TabPageArchivi = New System.Windows.Forms.TabPage()
        Me.tlpArchivi = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelIP = New System.Windows.Forms.Label()
        Me.LabelSincro = New System.Windows.Forms.Label()
        Me.TextBoxIP = New System.Windows.Forms.TextBox()
        Me.CheckBoxSincro = New System.Windows.Forms.CheckBox()
        Me.LabelInfoEmme = New System.Windows.Forms.Label()
        Me.RadioButtonU = New System.Windows.Forms.RadioButton()
        Me.RadioButtonM = New System.Windows.Forms.RadioButton()
        Me.TabPageInterfaccia = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxRitardo = New System.Windows.Forms.ComboBox()
        Me.TabPageUtenti = New System.Windows.Forms.TabPage()
        Me.tlpMain.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.TabPageContatti.SuspendLayout()
        Me.tlpContatti.SuspendLayout()
        Me.TabPageArchivi.SuspendLayout()
        Me.tlpArchivi.SuspendLayout()
        Me.TabPageInterfaccia.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.Controls.Add(Me.ButtonAnnulla, 0, 1)
        Me.tlpMain.Controls.Add(Me.ButtonSalva, 1, 1)
        Me.tlpMain.Controls.Add(Me.TabMain, 0, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMain.Size = New System.Drawing.Size(670, 361)
        Me.tlpMain.TabIndex = 10
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnnulla.Location = New System.Drawing.Point(1, 322)
        Me.ButtonAnnulla.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(333, 38)
        Me.ButtonAnnulla.TabIndex = 6
        Me.ButtonAnnulla.Text = "annulla"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'ButtonSalva
        '
        Me.ButtonSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSalva.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSalva.Location = New System.Drawing.Point(336, 322)
        Me.ButtonSalva.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonSalva.Name = "ButtonSalva"
        Me.ButtonSalva.Size = New System.Drawing.Size(333, 38)
        Me.ButtonSalva.TabIndex = 7
        Me.ButtonSalva.Text = "salva"
        Me.ButtonSalva.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.AZZURRO
        Me.tlpMain.SetColumnSpan(Me.TabMain, 2)
        Me.TabMain.Controls.Add(Me.TabPageContatti)
        Me.TabMain.Controls.Add(Me.TabPageArchivi)
        Me.TabMain.Controls.Add(Me.TabPageInterfaccia)
        Me.TabMain.Controls.Add(Me.TabPageUtenti)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabMain.Location = New System.Drawing.Point(3, 3)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(664, 315)
        Me.TabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabMain.TabIndex = 8
        Me.TabMain.Visible = False
        '
        'TabPageContatti
        '
        Me.TabPageContatti.Controls.Add(Me.tlpContatti)
        Me.TabPageContatti.Location = New System.Drawing.Point(4, 29)
        Me.TabPageContatti.Name = "TabPageContatti"
        Me.TabPageContatti.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageContatti.Size = New System.Drawing.Size(656, 282)
        Me.TabPageContatti.TabIndex = 0
        Me.TabPageContatti.Text = "Contatti"
        Me.TabPageContatti.UseVisualStyleBackColor = True
        '
        'tlpContatti
        '
        Me.tlpContatti.ColumnCount = 5
        Me.tlpContatti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpContatti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpContatti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpContatti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpContatti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpContatti.Controls.Add(Me.ButtonPredefinita, 2, 5)
        Me.tlpContatti.Controls.Add(Me.ListBoxMail, 0, 4)
        Me.tlpContatti.Controls.Add(Me.Label1, 0, 3)
        Me.tlpContatti.Controls.Add(Me.TextBoxMail, 1, 3)
        Me.tlpContatti.Controls.Add(Me.ButtonAggiungi, 3, 3)
        Me.tlpContatti.Controls.Add(Me.Label2, 0, 0)
        Me.tlpContatti.Controls.Add(Me.TextBoxSmtp, 1, 0)
        Me.tlpContatti.Controls.Add(Me.Button1, 0, 5)
        Me.tlpContatti.Controls.Add(Me.Label5, 3, 0)
        Me.tlpContatti.Controls.Add(Me.Label6, 0, 1)
        Me.tlpContatti.Controls.Add(Me.Label7, 3, 1)
        Me.tlpContatti.Controls.Add(Me.TextBoxSmtpUtente, 1, 1)
        Me.tlpContatti.Controls.Add(Me.TextBoxSmtpPw, 4, 1)
        Me.tlpContatti.Controls.Add(Me.TextBoxSmtpPorta, 4, 0)
        Me.tlpContatti.Controls.Add(Me.CheckBoxSSL, 4, 2)
        Me.tlpContatti.Controls.Add(Me.CheckBoxSmtpAUA, 1, 2)
        Me.tlpContatti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpContatti.Location = New System.Drawing.Point(3, 3)
        Me.tlpContatti.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpContatti.Name = "tlpContatti"
        Me.tlpContatti.RowCount = 6
        Me.tlpContatti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpContatti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpContatti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpContatti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpContatti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpContatti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpContatti.Size = New System.Drawing.Size(650, 276)
        Me.tlpContatti.TabIndex = 8
        '
        'ButtonPredefinita
        '
        Me.ButtonPredefinita.BackColor = System.Drawing.SystemColors.Control
        Me.tlpContatti.SetColumnSpan(Me.ButtonPredefinita, 3)
        Me.ButtonPredefinita.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonPredefinita.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonPredefinita.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPredefinita.Location = New System.Drawing.Point(261, 251)
        Me.ButtonPredefinita.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonPredefinita.Name = "ButtonPredefinita"
        Me.ButtonPredefinita.Size = New System.Drawing.Size(388, 24)
        Me.ButtonPredefinita.TabIndex = 8
        Me.ButtonPredefinita.Text = "Rendi predefinita l'e-mail selezionata nella lista"
        Me.ButtonPredefinita.UseVisualStyleBackColor = False
        '
        'ListBoxMail
        '
        Me.ListBoxMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpContatti.SetColumnSpan(Me.ListBoxMail, 5)
        Me.ListBoxMail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxMail.FormattingEnabled = True
        Me.ListBoxMail.IntegralHeight = False
        Me.ListBoxMail.Location = New System.Drawing.Point(0, 107)
        Me.ListBoxMail.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.ListBoxMail.Name = "ListBoxMail"
        Me.ListBoxMail.Size = New System.Drawing.Size(650, 140)
        Me.ListBoxMail.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 26)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "E-mail mittente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxMail
        '
        Me.TextBoxMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpContatti.SetColumnSpan(Me.TextBoxMail, 2)
        Me.TextBoxMail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxMail.Location = New System.Drawing.Point(131, 79)
        Me.TextBoxMail.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxMail.Name = "TextBoxMail"
        Me.TextBoxMail.Size = New System.Drawing.Size(258, 20)
        Me.TextBoxMail.TabIndex = 4
        Me.TextBoxMail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonAggiungi
        '
        Me.ButtonAggiungi.BackColor = System.Drawing.SystemColors.Control
        Me.tlpContatti.SetColumnSpan(Me.ButtonAggiungi, 2)
        Me.ButtonAggiungi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiungi.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAggiungi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAggiungi.Location = New System.Drawing.Point(391, 79)
        Me.ButtonAggiungi.Margin = New System.Windows.Forms.Padding(1)
        Me.ButtonAggiungi.Name = "ButtonAggiungi"
        Me.ButtonAggiungi.Size = New System.Drawing.Size(258, 24)
        Me.ButtonAggiungi.TabIndex = 5
        Me.ButtonAggiungi.Text = "Aggiungi alla lista e-mail"
        Me.ButtonAggiungi.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 26)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "SMTP posta in uscita"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxSmtp
        '
        Me.TextBoxSmtp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpContatti.SetColumnSpan(Me.TextBoxSmtp, 2)
        Me.TextBoxSmtp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxSmtp.Location = New System.Drawing.Point(131, 1)
        Me.TextBoxSmtp.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxSmtp.Name = "TextBoxSmtp"
        Me.TextBoxSmtp.Size = New System.Drawing.Size(258, 20)
        Me.TextBoxSmtp.TabIndex = 0
        Me.TextBoxSmtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.tlpContatti.SetColumnSpan(Me.Button1, 2)
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(0, 251)
        Me.Button1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(260, 24)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Elimina e-mail selezionata"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(393, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 26)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Porta"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(3, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 26)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Utente SMTP"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(393, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 26)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Password SMTP"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxSmtpUtente
        '
        Me.TextBoxSmtpUtente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpContatti.SetColumnSpan(Me.TextBoxSmtpUtente, 2)
        Me.TextBoxSmtpUtente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxSmtpUtente.Location = New System.Drawing.Point(131, 27)
        Me.TextBoxSmtpUtente.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxSmtpUtente.Name = "TextBoxSmtpUtente"
        Me.TextBoxSmtpUtente.Size = New System.Drawing.Size(258, 20)
        Me.TextBoxSmtpUtente.TabIndex = 2
        Me.TextBoxSmtpUtente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxSmtpPw
        '
        Me.TextBoxSmtpPw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxSmtpPw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxSmtpPw.Location = New System.Drawing.Point(521, 27)
        Me.TextBoxSmtpPw.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxSmtpPw.Name = "TextBoxSmtpPw"
        Me.TextBoxSmtpPw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxSmtpPw.Size = New System.Drawing.Size(128, 20)
        Me.TextBoxSmtpPw.TabIndex = 3
        Me.TextBoxSmtpPw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxSmtpPorta
        '
        Me.TextBoxSmtpPorta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxSmtpPorta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxSmtpPorta.Location = New System.Drawing.Point(521, 1)
        Me.TextBoxSmtpPorta.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxSmtpPorta.Name = "TextBoxSmtpPorta"
        Me.TextBoxSmtpPorta.Size = New System.Drawing.Size(128, 20)
        Me.TextBoxSmtpPorta.TabIndex = 1
        Me.TextBoxSmtpPorta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBoxSSL
        '
        Me.CheckBoxSSL.AutoSize = True
        Me.CheckBoxSSL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxSSL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxSSL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxSSL.Location = New System.Drawing.Point(523, 55)
        Me.CheckBoxSSL.Name = "CheckBoxSSL"
        Me.CheckBoxSSL.Size = New System.Drawing.Size(124, 20)
        Me.CheckBoxSSL.TabIndex = 17
        Me.CheckBoxSSL.Text = "Abilita SSL"
        Me.CheckBoxSSL.UseVisualStyleBackColor = True
        '
        'CheckBoxSmtpAUA
        '
        Me.CheckBoxSmtpAUA.AutoSize = True
        Me.tlpContatti.SetColumnSpan(Me.CheckBoxSmtpAUA, 2)
        Me.CheckBoxSmtpAUA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxSmtpAUA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxSmtpAUA.Location = New System.Drawing.Point(133, 55)
        Me.CheckBoxSmtpAUA.Name = "CheckBoxSmtpAUA"
        Me.CheckBoxSmtpAUA.Size = New System.Drawing.Size(254, 20)
        Me.CheckBoxSmtpAUA.TabIndex = 18
        Me.CheckBoxSmtpAUA.Text = "Usa sempre SMTP AUA"
        Me.CheckBoxSmtpAUA.UseVisualStyleBackColor = True
        '
        'TabPageArchivi
        '
        Me.TabPageArchivi.Controls.Add(Me.tlpArchivi)
        Me.TabPageArchivi.Location = New System.Drawing.Point(4, 29)
        Me.TabPageArchivi.Name = "TabPageArchivi"
        Me.TabPageArchivi.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageArchivi.Size = New System.Drawing.Size(656, 282)
        Me.TabPageArchivi.TabIndex = 1
        Me.TabPageArchivi.Text = "Archivi"
        Me.TabPageArchivi.UseVisualStyleBackColor = True
        '
        'tlpArchivi
        '
        Me.tlpArchivi.ColumnCount = 2
        Me.tlpArchivi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.tlpArchivi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpArchivi.Controls.Add(Me.LabelIP, 0, 1)
        Me.tlpArchivi.Controls.Add(Me.LabelSincro, 0, 2)
        Me.tlpArchivi.Controls.Add(Me.TextBoxIP, 1, 1)
        Me.tlpArchivi.Controls.Add(Me.CheckBoxSincro, 1, 2)
        Me.tlpArchivi.Controls.Add(Me.LabelInfoEmme, 0, 4)
        Me.tlpArchivi.Controls.Add(Me.RadioButtonU, 1, 4)
        Me.tlpArchivi.Controls.Add(Me.RadioButtonM, 1, 5)
        Me.tlpArchivi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpArchivi.Location = New System.Drawing.Point(3, 3)
        Me.tlpArchivi.Name = "tlpArchivi"
        Me.tlpArchivi.RowCount = 8
        Me.tlpArchivi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpArchivi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpArchivi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpArchivi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpArchivi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpArchivi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpArchivi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpArchivi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpArchivi.Size = New System.Drawing.Size(650, 276)
        Me.tlpArchivi.TabIndex = 0
        '
        'LabelIP
        '
        Me.LabelIP.AutoSize = True
        Me.LabelIP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelIP.Location = New System.Drawing.Point(3, 20)
        Me.LabelIP.Name = "LabelIP"
        Me.LabelIP.Size = New System.Drawing.Size(449, 26)
        Me.LabelIP.TabIndex = 0
        Me.LabelIP.Text = "Nome/IP del server che ospita i dati"
        Me.LabelIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelSincro
        '
        Me.LabelSincro.AutoSize = True
        Me.LabelSincro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSincro.Location = New System.Drawing.Point(3, 46)
        Me.LabelSincro.Name = "LabelSincro"
        Me.LabelSincro.Size = New System.Drawing.Size(449, 26)
        Me.LabelSincro.TabIndex = 1
        Me.LabelSincro.Text = "Ricordami di sincronizzare i dati quando mi disconnetto"
        Me.LabelSincro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxIP
        '
        Me.TextBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxIP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxIP.Location = New System.Drawing.Point(458, 23)
        Me.TextBoxIP.Name = "TextBoxIP"
        Me.TextBoxIP.Size = New System.Drawing.Size(189, 20)
        Me.TextBoxIP.TabIndex = 2
        '
        'CheckBoxSincro
        '
        Me.CheckBoxSincro.AutoSize = True
        Me.CheckBoxSincro.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxSincro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxSincro.Location = New System.Drawing.Point(458, 49)
        Me.CheckBoxSincro.Name = "CheckBoxSincro"
        Me.CheckBoxSincro.Size = New System.Drawing.Size(189, 20)
        Me.CheckBoxSincro.TabIndex = 3
        Me.CheckBoxSincro.UseVisualStyleBackColor = True
        '
        'LabelInfoEmme
        '
        Me.LabelInfoEmme.AutoSize = True
        Me.LabelInfoEmme.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfoEmme.Location = New System.Drawing.Point(3, 112)
        Me.LabelInfoEmme.Name = "LabelInfoEmme"
        Me.LabelInfoEmme.Size = New System.Drawing.Size(449, 25)
        Me.LabelInfoEmme.TabIndex = 4
        Me.LabelInfoEmme.Text = "Label3"
        Me.LabelInfoEmme.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadioButtonU
        '
        Me.RadioButtonU.AutoSize = True
        Me.RadioButtonU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonU.Location = New System.Drawing.Point(458, 115)
        Me.RadioButtonU.Name = "RadioButtonU"
        Me.RadioButtonU.Size = New System.Drawing.Size(189, 19)
        Me.RadioButtonU.TabIndex = 5
        Me.RadioButtonU.TabStop = True
        Me.RadioButtonU.Text = "RadioButton1"
        Me.RadioButtonU.UseVisualStyleBackColor = True
        '
        'RadioButtonM
        '
        Me.RadioButtonM.AutoSize = True
        Me.RadioButtonM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButtonM.Location = New System.Drawing.Point(458, 140)
        Me.RadioButtonM.Name = "RadioButtonM"
        Me.RadioButtonM.Size = New System.Drawing.Size(189, 19)
        Me.RadioButtonM.TabIndex = 6
        Me.RadioButtonM.TabStop = True
        Me.RadioButtonM.Text = "RadioButton2"
        Me.RadioButtonM.UseVisualStyleBackColor = True
        '
        'TabPageInterfaccia
        '
        Me.TabPageInterfaccia.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPageInterfaccia.Location = New System.Drawing.Point(4, 29)
        Me.TabPageInterfaccia.Name = "TabPageInterfaccia"
        Me.TabPageInterfaccia.Size = New System.Drawing.Size(656, 282)
        Me.TabPageInterfaccia.TabIndex = 2
        Me.TabPageInterfaccia.Text = "Interfaccia"
        Me.TabPageInterfaccia.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxRitardo, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(656, 282)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(322, 27)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Avviare ricerca automatica dopo"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxRitardo
        '
        Me.ComboBoxRitardo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxRitardo.FormattingEnabled = True
        Me.ComboBoxRitardo.Location = New System.Drawing.Point(331, 3)
        Me.ComboBoxRitardo.Name = "ComboBoxRitardo"
        Me.ComboBoxRitardo.Size = New System.Drawing.Size(322, 21)
        Me.ComboBoxRitardo.TabIndex = 1
        '
        'TabPageUtenti
        '
        Me.TabPageUtenti.Location = New System.Drawing.Point(4, 29)
        Me.TabPageUtenti.Name = "TabPageUtenti"
        Me.TabPageUtenti.Size = New System.Drawing.Size(656, 282)
        Me.TabPageUtenti.TabIndex = 3
        Me.TabPageUtenti.Text = "Abilitazione utenti"
        Me.TabPageUtenti.UseVisualStyleBackColor = True
        '
        'FormConfigura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 361)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormConfigura"
        Me.Text = "FormConfigura"
        Me.tlpMain.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.TabPageContatti.ResumeLayout(False)
        Me.tlpContatti.ResumeLayout(False)
        Me.tlpContatti.PerformLayout()
        Me.TabPageArchivi.ResumeLayout(False)
        Me.tlpArchivi.ResumeLayout(False)
        Me.tlpArchivi.PerformLayout()
        Me.TabPageInterfaccia.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpContatti As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ListBoxMail As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxMail As System.Windows.Forms.TextBox
    Friend WithEvents ButtonAggiungi As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSmtp As System.Windows.Forms.TextBox
    Friend WithEvents ButtonPredefinita As System.Windows.Forms.Button
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
    Friend WithEvents ButtonSalva As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabMain As Utx.UtTabControl
    Friend WithEvents TabPageContatti As System.Windows.Forms.TabPage
    Friend WithEvents TabPageArchivi As System.Windows.Forms.TabPage
    Friend WithEvents tlpArchivi As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelIP As System.Windows.Forms.Label
    Friend WithEvents LabelSincro As System.Windows.Forms.Label
    Friend WithEvents TextBoxIP As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxSincro As System.Windows.Forms.CheckBox
    Friend WithEvents TabPageInterfaccia As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxRitardo As System.Windows.Forms.ComboBox
    Friend WithEvents TabPageUtenti As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSmtpUtente As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSmtpPw As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSmtpPorta As System.Windows.Forms.TextBox
    Friend WithEvents LabelInfoEmme As System.Windows.Forms.Label
    Friend WithEvents RadioButtonU As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonM As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBoxSSL As Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSmtpAUA As Windows.Forms.CheckBox
End Class
