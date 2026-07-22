Namespace P01204
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class P01204FE
        Inherits P00000FE

        'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

        'NOTA: la procedura che segue Ã¨ richiesta da Progettazione Windows Form
        'PuÃ² essere modificata in Progettazione Windows Form.  
        'Non modificarla nell'editor del codice.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblSezioneInfortuniSintesi = New System.Windows.Forms.Label()
            Me.lblSezioneInfortuniPremio = New System.Windows.Forms.Label()
            Me.chkSezioneInfortuni = New System.Windows.Forms.CheckBox()
            Me.lblSezioneMalattiaSintesi = New System.Windows.Forms.Label()
            Me.lblSezioneMalattiaPremio = New System.Windows.Forms.Label()
            Me.chkSezioneMalattia = New System.Windows.Forms.CheckBox()
            Me.lblSezioneSalvaPremioSintesi = New System.Windows.Forms.Label()
            Me.lblSezioneSalvaPremioPremio = New System.Windows.Forms.Label()
            Me.chkSezioneSalvaPremio = New System.Windows.Forms.CheckBox()
            Me.lblSezioneAssistenzaSintesi = New System.Windows.Forms.Label()
            Me.lblSezioneAssistenzaPremio = New System.Windows.Forms.Label()
            Me.chkSezioneAssistenza = New System.Windows.Forms.CheckBox()
            Me.lblSezioneScontiSintesi = New System.Windows.Forms.Label()
            Me.lblSezioneScontiPremio = New System.Windows.Forms.Label()
            Me.chkSezioneSconti = New System.Windows.Forms.CheckBox()
            Me.lblSezioneTotalePremio = New System.Windows.Forms.Label()
            Me.lblSezioneTotaleSintesi = New System.Windows.Forms.Label()
            Me.lblA1 = New System.Windows.Forms.Label()
            Me.lblB1 = New System.Windows.Forms.Label()
            Me.lblC1 = New System.Windows.Forms.Label()
            Me.lblD1 = New System.Windows.Forms.Label()
            Me.TabAgg = New System.Windows.Forms.TabPage()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabAgg)
            Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabControl1.ItemSize = New System.Drawing.Size(180, 25)
            Me.TabControl1.Location = New System.Drawing.Point(0, 0)
            Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.Padding = New System.Drawing.Point(0, 0)
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(804, 553)
            Me.TabControl1.TabIndex = 0
            Me.TabControl1.Tag = ""
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.GroupBox1)
            Me.TabPage1.Location = New System.Drawing.Point(4, 29)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(796, 520)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Tag = ""
            Me.TabPage1.Text = "Generale"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
            Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
            Me.GroupBox1.Margin = New System.Windows.Forms.Padding(0)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
            Me.GroupBox1.Size = New System.Drawing.Size(796, 520)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 5
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.lblSezioneInfortuniSintesi, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSezioneInfortuniPremio, 4, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.chkSezioneInfortuni, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSezioneMalattiaSintesi, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSezioneMalattiaPremio, 4, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.chkSezioneMalattia, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSezioneSalvaPremioSintesi, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSezioneSalvaPremioPremio, 4, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.chkSezioneSalvaPremio, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSezioneAssistenzaSintesi, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSezioneAssistenzaPremio, 4, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.chkSezioneAssistenza, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSezioneScontiSintesi, 1, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSezioneScontiPremio, 4, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.chkSezioneSconti, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSezioneTotalePremio, 4, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSezioneTotaleSintesi, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.lblA1, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblB1, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblC1, 4, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblD1, 0, 0)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 15)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 8
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(790, 502)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'lblSezioneInfortuniSintesi
            '
            Me.lblSezioneInfortuniSintesi.AutoSize = True
            Me.lblSezioneInfortuniSintesi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneInfortuniSintesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneInfortuniSintesi.Location = New System.Drawing.Point(58, 40)
            Me.lblSezioneInfortuniSintesi.Name = "lblSezioneInfortuniSintesi"
            Me.lblSezioneInfortuniSintesi.Size = New System.Drawing.Size(248, 25)
            Me.lblSezioneInfortuniSintesi.TabIndex = 10
            Me.lblSezioneInfortuniSintesi.Text = "Infortuni"
            Me.lblSezioneInfortuniSintesi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSezioneInfortuniPremio
            '
            Me.lblSezioneInfortuniPremio.AutoSize = True
            Me.lblSezioneInfortuniPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneInfortuniPremio.Location = New System.Drawing.Point(692, 40)
            Me.lblSezioneInfortuniPremio.Name = "lblSezioneInfortuniPremio"
            Me.lblSezioneInfortuniPremio.Size = New System.Drawing.Size(95, 25)
            Me.lblSezioneInfortuniPremio.TabIndex = 11
            Me.lblSezioneInfortuniPremio.Text = "0,00"
            Me.lblSezioneInfortuniPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkSezioneInfortuni
            '
            Me.chkSezioneInfortuni.AutoSize = True
            Me.chkSezioneInfortuni.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkSezioneInfortuni.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkSezioneInfortuni.Enabled = False
            Me.chkSezioneInfortuni.Location = New System.Drawing.Point(0, 40)
            Me.chkSezioneInfortuni.Margin = New System.Windows.Forms.Padding(0)
            Me.chkSezioneInfortuni.Name = "chkSezioneInfortuni"
            Me.chkSezioneInfortuni.Size = New System.Drawing.Size(55, 25)
            Me.chkSezioneInfortuni.TabIndex = 12
            Me.chkSezioneInfortuni.UseVisualStyleBackColor = True
            '
            'lblSezioneMalattiaSintesi
            '
            Me.lblSezioneMalattiaSintesi.AutoSize = True
            Me.lblSezioneMalattiaSintesi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneMalattiaSintesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneMalattiaSintesi.Location = New System.Drawing.Point(58, 65)
            Me.lblSezioneMalattiaSintesi.Name = "lblSezioneMalattiaSintesi"
            Me.lblSezioneMalattiaSintesi.Size = New System.Drawing.Size(248, 25)
            Me.lblSezioneMalattiaSintesi.TabIndex = 13
            Me.lblSezioneMalattiaSintesi.Text = "Malattia"
            Me.lblSezioneMalattiaSintesi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSezioneMalattiaPremio
            '
            Me.lblSezioneMalattiaPremio.AutoSize = True
            Me.lblSezioneMalattiaPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneMalattiaPremio.Location = New System.Drawing.Point(692, 65)
            Me.lblSezioneMalattiaPremio.Name = "lblSezioneMalattiaPremio"
            Me.lblSezioneMalattiaPremio.Size = New System.Drawing.Size(95, 25)
            Me.lblSezioneMalattiaPremio.TabIndex = 14
            Me.lblSezioneMalattiaPremio.Text = "0,00"
            Me.lblSezioneMalattiaPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkSezioneMalattia
            '
            Me.chkSezioneMalattia.AutoSize = True
            Me.chkSezioneMalattia.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkSezioneMalattia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkSezioneMalattia.Enabled = False
            Me.chkSezioneMalattia.Location = New System.Drawing.Point(0, 65)
            Me.chkSezioneMalattia.Margin = New System.Windows.Forms.Padding(0)
            Me.chkSezioneMalattia.Name = "chkSezioneMalattia"
            Me.chkSezioneMalattia.Size = New System.Drawing.Size(55, 25)
            Me.chkSezioneMalattia.TabIndex = 15
            Me.chkSezioneMalattia.UseVisualStyleBackColor = True
            '
            'lblSezioneSalvaPremioSintesi
            '
            Me.lblSezioneSalvaPremioSintesi.AutoSize = True
            Me.lblSezioneSalvaPremioSintesi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneSalvaPremioSintesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneSalvaPremioSintesi.Location = New System.Drawing.Point(58, 90)
            Me.lblSezioneSalvaPremioSintesi.Name = "lblSezioneSalvaPremioSintesi"
            Me.lblSezioneSalvaPremioSintesi.Size = New System.Drawing.Size(248, 25)
            Me.lblSezioneSalvaPremioSintesi.TabIndex = 16
            Me.lblSezioneSalvaPremioSintesi.Text = "Salva Premio"
            Me.lblSezioneSalvaPremioSintesi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSezioneSalvaPremioPremio
            '
            Me.lblSezioneSalvaPremioPremio.AutoSize = True
            Me.lblSezioneSalvaPremioPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneSalvaPremioPremio.Location = New System.Drawing.Point(692, 90)
            Me.lblSezioneSalvaPremioPremio.Name = "lblSezioneSalvaPremioPremio"
            Me.lblSezioneSalvaPremioPremio.Size = New System.Drawing.Size(95, 25)
            Me.lblSezioneSalvaPremioPremio.TabIndex = 17
            Me.lblSezioneSalvaPremioPremio.Text = "0,00"
            Me.lblSezioneSalvaPremioPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkSezioneSalvaPremio
            '
            Me.chkSezioneSalvaPremio.AutoSize = True
            Me.chkSezioneSalvaPremio.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkSezioneSalvaPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkSezioneSalvaPremio.Enabled = False
            Me.chkSezioneSalvaPremio.Location = New System.Drawing.Point(0, 90)
            Me.chkSezioneSalvaPremio.Margin = New System.Windows.Forms.Padding(0)
            Me.chkSezioneSalvaPremio.Name = "chkSezioneSalvaPremio"
            Me.chkSezioneSalvaPremio.Size = New System.Drawing.Size(55, 25)
            Me.chkSezioneSalvaPremio.TabIndex = 18
            Me.chkSezioneSalvaPremio.UseVisualStyleBackColor = True
            '
            'lblSezioneAssistenzaSintesi
            '
            Me.lblSezioneAssistenzaSintesi.AutoSize = True
            Me.lblSezioneAssistenzaSintesi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneAssistenzaSintesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneAssistenzaSintesi.Location = New System.Drawing.Point(58, 115)
            Me.lblSezioneAssistenzaSintesi.Name = "lblSezioneAssistenzaSintesi"
            Me.lblSezioneAssistenzaSintesi.Size = New System.Drawing.Size(248, 25)
            Me.lblSezioneAssistenzaSintesi.TabIndex = 19
            Me.lblSezioneAssistenzaSintesi.Text = "Assistenza"
            Me.lblSezioneAssistenzaSintesi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSezioneAssistenzaPremio
            '
            Me.lblSezioneAssistenzaPremio.AutoSize = True
            Me.lblSezioneAssistenzaPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneAssistenzaPremio.Location = New System.Drawing.Point(692, 115)
            Me.lblSezioneAssistenzaPremio.Name = "lblSezioneAssistenzaPremio"
            Me.lblSezioneAssistenzaPremio.Size = New System.Drawing.Size(95, 25)
            Me.lblSezioneAssistenzaPremio.TabIndex = 20
            Me.lblSezioneAssistenzaPremio.Text = "0,00"
            Me.lblSezioneAssistenzaPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkSezioneAssistenza
            '
            Me.chkSezioneAssistenza.AutoSize = True
            Me.chkSezioneAssistenza.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkSezioneAssistenza.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkSezioneAssistenza.Enabled = False
            Me.chkSezioneAssistenza.Location = New System.Drawing.Point(0, 115)
            Me.chkSezioneAssistenza.Margin = New System.Windows.Forms.Padding(0)
            Me.chkSezioneAssistenza.Name = "chkSezioneAssistenza"
            Me.chkSezioneAssistenza.Size = New System.Drawing.Size(55, 25)
            Me.chkSezioneAssistenza.TabIndex = 21
            Me.chkSezioneAssistenza.UseVisualStyleBackColor = True
            '
            'lblSezioneScontiSintesi
            '
            Me.lblSezioneScontiSintesi.AutoSize = True
            Me.lblSezioneScontiSintesi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneScontiSintesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneScontiSintesi.Location = New System.Drawing.Point(58, 140)
            Me.lblSezioneScontiSintesi.Name = "lblSezioneScontiSintesi"
            Me.lblSezioneScontiSintesi.Size = New System.Drawing.Size(248, 25)
            Me.lblSezioneScontiSintesi.TabIndex = 22
            Me.lblSezioneScontiSintesi.Text = "Sconti"
            Me.lblSezioneScontiSintesi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSezioneScontiPremio
            '
            Me.lblSezioneScontiPremio.AutoSize = True
            Me.lblSezioneScontiPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneScontiPremio.Location = New System.Drawing.Point(692, 140)
            Me.lblSezioneScontiPremio.Name = "lblSezioneScontiPremio"
            Me.lblSezioneScontiPremio.Size = New System.Drawing.Size(95, 25)
            Me.lblSezioneScontiPremio.TabIndex = 23
            Me.lblSezioneScontiPremio.Text = "0,00"
            Me.lblSezioneScontiPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkSezioneSconti
            '
            Me.chkSezioneSconti.AutoSize = True
            Me.chkSezioneSconti.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkSezioneSconti.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkSezioneSconti.Enabled = False
            Me.chkSezioneSconti.Location = New System.Drawing.Point(0, 140)
            Me.chkSezioneSconti.Margin = New System.Windows.Forms.Padding(0)
            Me.chkSezioneSconti.Name = "chkSezioneSconti"
            Me.chkSezioneSconti.Size = New System.Drawing.Size(55, 25)
            Me.chkSezioneSconti.TabIndex = 24
            Me.chkSezioneSconti.UseVisualStyleBackColor = True
            '
            'lblSezioneTotalePremio
            '
            Me.lblSezioneTotalePremio.AutoSize = True
            Me.lblSezioneTotalePremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneTotalePremio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneTotalePremio.ForeColor = System.Drawing.Color.MediumBlue
            Me.lblSezioneTotalePremio.Location = New System.Drawing.Point(692, 165)
            Me.lblSezioneTotalePremio.Name = "lblSezioneTotalePremio"
            Me.lblSezioneTotalePremio.Size = New System.Drawing.Size(95, 25)
            Me.lblSezioneTotalePremio.TabIndex = 25
            Me.lblSezioneTotalePremio.Text = "0,00"
            Me.lblSezioneTotalePremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSezioneTotaleSintesi
            '
            Me.lblSezioneTotaleSintesi.AutoSize = True
            Me.lblSezioneTotaleSintesi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneTotaleSintesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneTotaleSintesi.ForeColor = System.Drawing.Color.MediumBlue
            Me.lblSezioneTotaleSintesi.Location = New System.Drawing.Point(58, 165)
            Me.lblSezioneTotaleSintesi.Name = "lblSezioneTotaleSintesi"
            Me.lblSezioneTotaleSintesi.Size = New System.Drawing.Size(248, 25)
            Me.lblSezioneTotaleSintesi.TabIndex = 26
            Me.lblSezioneTotaleSintesi.Text = "TOTALE"
            Me.lblSezioneTotaleSintesi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblA1
            '
            Me.lblA1.AutoSize = True
            Me.lblA1.BackColor = System.Drawing.Color.Khaki
            Me.lblA1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblA1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblA1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblA1.Location = New System.Drawing.Point(58, 0)
            Me.lblA1.Name = "lblA1"
            Me.lblA1.Size = New System.Drawing.Size(248, 40)
            Me.lblA1.TabIndex = 27
            Me.lblA1.Text = "Partita / Garanzia"
            Me.lblA1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblB1
            '
            Me.lblB1.AutoSize = True
            Me.lblB1.BackColor = System.Drawing.Color.Khaki
            Me.lblB1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblB1, 2)
            Me.lblB1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblB1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblB1.Location = New System.Drawing.Point(312, 0)
            Me.lblB1.Name = "lblB1"
            Me.lblB1.Size = New System.Drawing.Size(374, 40)
            Me.lblB1.TabIndex = 28
            Me.lblB1.Text = "Parametri/Condizioni"
            Me.lblB1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblC1
            '
            Me.lblC1.AutoSize = True
            Me.lblC1.BackColor = System.Drawing.Color.Khaki
            Me.lblC1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblC1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblC1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblC1.Location = New System.Drawing.Point(692, 0)
            Me.lblC1.Name = "lblC1"
            Me.lblC1.Size = New System.Drawing.Size(95, 40)
            Me.lblC1.TabIndex = 29
            Me.lblC1.Text = "Premio"
            Me.lblC1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblD1
            '
            Me.lblD1.AutoSize = True
            Me.lblD1.BackColor = System.Drawing.Color.Khaki
            Me.lblD1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblD1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblD1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblD1.Location = New System.Drawing.Point(3, 0)
            Me.lblD1.Name = "lblD1"
            Me.lblD1.Size = New System.Drawing.Size(49, 40)
            Me.lblD1.TabIndex = 30
            Me.lblD1.Text = "Scelto"
            Me.lblD1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'TabAgg
            '
            Me.TabAgg.Location = New System.Drawing.Point(4, 29)
            Me.TabAgg.Name = "TabAgg"
            Me.TabAgg.Size = New System.Drawing.Size(802, 542)
            Me.TabAgg.TabIndex = 1
            Me.TabAgg.Text = "Aggiungi assicurato"
            Me.TabAgg.UseVisualStyleBackColor = True
            '
            'P01204FE
            '
            Me.Name = "P01204FE"
            Me.Size = New System.Drawing.Size(1026, 575)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Private Sub InitializeComponent2()
            InitializeComponent()
            Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        End Sub
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabAgg As System.Windows.Forms.TabPage
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents lblA1 As System.Windows.Forms.Label
        Friend WithEvents lblB1 As System.Windows.Forms.Label
        Friend WithEvents lblC1 As System.Windows.Forms.Label
        Friend WithEvents lblD1 As System.Windows.Forms.Label
        Friend WithEvents lblSezioneInfortuniSintesi As System.Windows.Forms.Label
        Friend WithEvents lblSezioneInfortuniPremio As System.Windows.Forms.Label
        Friend WithEvents chkSezioneInfortuni As System.Windows.Forms.CheckBox
        Friend WithEvents lblSezioneMalattiaSintesi As System.Windows.Forms.Label
        Friend WithEvents lblSezioneMalattiaPremio As System.Windows.Forms.Label
        Friend WithEvents chkSezioneMalattia As System.Windows.Forms.CheckBox
        Friend WithEvents lblSezioneSalvaPremioSintesi As System.Windows.Forms.Label
        Friend WithEvents lblSezioneSalvaPremioPremio As System.Windows.Forms.Label
        Friend WithEvents chkSezioneSalvaPremio As System.Windows.Forms.CheckBox
        Friend WithEvents lblSezioneAssistenzaSintesi As System.Windows.Forms.Label
        Friend WithEvents lblSezioneAssistenzaPremio As System.Windows.Forms.Label
        Friend WithEvents chkSezioneAssistenza As System.Windows.Forms.CheckBox
        Friend WithEvents lblSezioneScontiSintesi As System.Windows.Forms.Label
        Friend WithEvents lblSezioneScontiPremio As System.Windows.Forms.Label
        Friend WithEvents chkSezioneSconti As System.Windows.Forms.CheckBox
        Friend WithEvents lblSezioneTotalePremio As System.Windows.Forms.Label
        Friend WithEvents lblSezioneTotaleSintesi As System.Windows.Forms.Label
    End Class
End Namespace
