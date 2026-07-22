Namespace P01263
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class P01263FE
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
            Me.TabPage0 = New System.Windows.Forms.TabPage()
            Me.GroupBox0 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel0 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblSezioneMalattiaSintesi = New System.Windows.Forms.Label()
            Me.lblSezioneMalattiaPremio = New System.Windows.Forms.Label()
            Me.chkSezioneMalattia = New System.Windows.Forms.CheckBox()
            Me.lblSezioneAssistenzaSintesi = New System.Windows.Forms.Label()
            Me.lblSezioneAssistenzaPremio = New System.Windows.Forms.Label()
            Me.chkSezioneAssistenza = New System.Windows.Forms.CheckBox()
            Me.lblSezioneTotalePremio = New System.Windows.Forms.Label()
            Me.lblSezioneTotaleSintesi = New System.Windows.Forms.Label()
            Me.lblA0 = New System.Windows.Forms.Label()
            Me.lblB0 = New System.Windows.Forms.Label()
            Me.lblC0 = New System.Windows.Forms.Label()
            Me.lblD0 = New System.Windows.Forms.Label()
            Me.TabAgg = New System.Windows.Forms.TabPage()
            Me.TabControl1.SuspendLayout()
            Me.TabPage0.SuspendLayout()
            Me.GroupBox0.SuspendLayout()
            Me.TableLayoutPanel0.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage0)
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
            'TabPage0
            '
            Me.TabPage0.Controls.Add(Me.GroupBox0)
            Me.TabPage0.Location = New System.Drawing.Point(4, 29)
            Me.TabPage0.Name = "TabPage0"
            Me.TabPage0.Size = New System.Drawing.Size(796, 520)
            Me.TabPage0.TabIndex = 0
            Me.TabPage0.Tag = ""
            Me.TabPage0.Text = "Generale"
            Me.TabPage0.UseVisualStyleBackColor = True
            '
            'GroupBox0
            '
            Me.GroupBox0.Controls.Add(Me.TableLayoutPanel0)
            Me.GroupBox0.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox0.Location = New System.Drawing.Point(0, 0)
            Me.GroupBox0.Margin = New System.Windows.Forms.Padding(0)
            Me.GroupBox0.Name = "GroupBox0"
            Me.GroupBox0.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
            Me.GroupBox0.Size = New System.Drawing.Size(796, 520)
            Me.GroupBox0.TabIndex = 0
            Me.GroupBox0.TabStop = False
            '
            'TableLayoutPanel0
            '
            Me.TableLayoutPanel0.ColumnCount = 5
            Me.TableLayoutPanel0.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
            Me.TableLayoutPanel0.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
            Me.TableLayoutPanel0.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel0.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel0.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
            Me.TableLayoutPanel0.Controls.Add(Me.lblSezioneMalattiaSintesi, 1, 1)
            Me.TableLayoutPanel0.Controls.Add(Me.lblSezioneMalattiaPremio, 4, 1)
            Me.TableLayoutPanel0.Controls.Add(Me.chkSezioneMalattia, 0, 1)
            Me.TableLayoutPanel0.Controls.Add(Me.lblSezioneAssistenzaSintesi, 1, 2)
            Me.TableLayoutPanel0.Controls.Add(Me.lblSezioneAssistenzaPremio, 4, 2)
            Me.TableLayoutPanel0.Controls.Add(Me.chkSezioneAssistenza, 0, 2)
            Me.TableLayoutPanel0.Controls.Add(Me.lblSezioneTotalePremio, 4, 3)
            Me.TableLayoutPanel0.Controls.Add(Me.lblSezioneTotaleSintesi, 1, 3)
            Me.TableLayoutPanel0.Controls.Add(Me.lblA0, 1, 0)
            Me.TableLayoutPanel0.Controls.Add(Me.lblB0, 2, 0)
            Me.TableLayoutPanel0.Controls.Add(Me.lblC0, 4, 0)
            Me.TableLayoutPanel0.Controls.Add(Me.lblD0, 0, 0)
            Me.TableLayoutPanel0.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel0.Location = New System.Drawing.Point(3, 15)
            Me.TableLayoutPanel0.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel0.Name = "TableLayoutPanel0"
            Me.TableLayoutPanel0.RowCount = 10
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel0.Size = New System.Drawing.Size(790, 502)
            Me.TableLayoutPanel0.TabIndex = 0
            '
            'lblSezioneMalattiaSintesi
            '
            Me.lblSezioneMalattiaSintesi.AutoSize = True
            Me.lblSezioneMalattiaSintesi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneMalattiaSintesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneMalattiaSintesi.Location = New System.Drawing.Point(58, 40)
            Me.lblSezioneMalattiaSintesi.Name = "lblSezioneMalattiaSintesi"
            Me.lblSezioneMalattiaSintesi.Size = New System.Drawing.Size(248, 25)
            Me.lblSezioneMalattiaSintesi.TabIndex = 0
            Me.lblSezioneMalattiaSintesi.Text = "Malattia e infortuni"
            Me.lblSezioneMalattiaSintesi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSezioneMalattiaPremio
            '
            Me.lblSezioneMalattiaPremio.AutoSize = True
            Me.lblSezioneMalattiaPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneMalattiaPremio.Location = New System.Drawing.Point(692, 40)
            Me.lblSezioneMalattiaPremio.Name = "lblSezioneMalattiaPremio"
            Me.lblSezioneMalattiaPremio.Size = New System.Drawing.Size(95, 25)
            Me.lblSezioneMalattiaPremio.TabIndex = 1
            Me.lblSezioneMalattiaPremio.Text = "0,00"
            Me.lblSezioneMalattiaPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkSezioneMalattia
            '
            Me.chkSezioneMalattia.AutoSize = True
            Me.chkSezioneMalattia.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkSezioneMalattia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkSezioneMalattia.Enabled = False
            Me.chkSezioneMalattia.Location = New System.Drawing.Point(0, 40)
            Me.chkSezioneMalattia.Margin = New System.Windows.Forms.Padding(0)
            Me.chkSezioneMalattia.Name = "chkSezioneMalattia"
            Me.chkSezioneMalattia.Size = New System.Drawing.Size(55, 25)
            Me.chkSezioneMalattia.TabIndex = 2
            Me.chkSezioneMalattia.UseVisualStyleBackColor = True
            '
            'lblSezioneAssistenzaSintesi
            '
            Me.lblSezioneAssistenzaSintesi.AutoSize = True
            Me.lblSezioneAssistenzaSintesi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneAssistenzaSintesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneAssistenzaSintesi.Location = New System.Drawing.Point(58, 65)
            Me.lblSezioneAssistenzaSintesi.Name = "lblSezioneAssistenzaSintesi"
            Me.lblSezioneAssistenzaSintesi.Size = New System.Drawing.Size(248, 25)
            Me.lblSezioneAssistenzaSintesi.TabIndex = 3
            Me.lblSezioneAssistenzaSintesi.Text = "Assistenza"
            Me.lblSezioneAssistenzaSintesi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSezioneAssistenzaPremio
            '
            Me.lblSezioneAssistenzaPremio.AutoSize = True
            Me.lblSezioneAssistenzaPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneAssistenzaPremio.Location = New System.Drawing.Point(692, 65)
            Me.lblSezioneAssistenzaPremio.Name = "lblSezioneAssistenzaPremio"
            Me.lblSezioneAssistenzaPremio.Size = New System.Drawing.Size(95, 25)
            Me.lblSezioneAssistenzaPremio.TabIndex = 4
            Me.lblSezioneAssistenzaPremio.Text = "0,00"
            Me.lblSezioneAssistenzaPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkSezioneAssistenza
            '
            Me.chkSezioneAssistenza.AutoSize = True
            Me.chkSezioneAssistenza.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkSezioneAssistenza.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkSezioneAssistenza.Enabled = False
            Me.chkSezioneAssistenza.Location = New System.Drawing.Point(0, 65)
            Me.chkSezioneAssistenza.Margin = New System.Windows.Forms.Padding(0)
            Me.chkSezioneAssistenza.Name = "chkSezioneAssistenza"
            Me.chkSezioneAssistenza.Size = New System.Drawing.Size(55, 25)
            Me.chkSezioneAssistenza.TabIndex = 5
            Me.chkSezioneAssistenza.UseVisualStyleBackColor = True
            '
            'lblSezioneTotalePremio
            '
            Me.lblSezioneTotalePremio.AutoSize = True
            Me.lblSezioneTotalePremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneTotalePremio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneTotalePremio.ForeColor = System.Drawing.Color.MediumBlue
            Me.lblSezioneTotalePremio.Location = New System.Drawing.Point(692, 90)
            Me.lblSezioneTotalePremio.Name = "lblSezioneTotalePremio"
            Me.lblSezioneTotalePremio.Size = New System.Drawing.Size(95, 25)
            Me.lblSezioneTotalePremio.TabIndex = 6
            Me.lblSezioneTotalePremio.Text = "0,00"
            Me.lblSezioneTotalePremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSezioneTotaleSintesi
            '
            Me.lblSezioneTotaleSintesi.AutoSize = True
            Me.lblSezioneTotaleSintesi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneTotaleSintesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneTotaleSintesi.ForeColor = System.Drawing.Color.MediumBlue
            Me.lblSezioneTotaleSintesi.Location = New System.Drawing.Point(58, 90)
            Me.lblSezioneTotaleSintesi.Name = "lblSezioneTotaleSintesi"
            Me.lblSezioneTotaleSintesi.Size = New System.Drawing.Size(248, 25)
            Me.lblSezioneTotaleSintesi.TabIndex = 7
            Me.lblSezioneTotaleSintesi.Text = "TOTALE"
            Me.lblSezioneTotaleSintesi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblA0
            '
            Me.lblA0.AutoSize = True
            Me.lblA0.BackColor = System.Drawing.Color.Khaki
            Me.lblA0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblA0.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblA0.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblA0.Location = New System.Drawing.Point(58, 0)
            Me.lblA0.Name = "lblA0"
            Me.lblA0.Size = New System.Drawing.Size(248, 40)
            Me.lblA0.TabIndex = 8
            Me.lblA0.Text = "Partita / Garanzia"
            Me.lblA0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblB0
            '
            Me.lblB0.AutoSize = True
            Me.lblB0.BackColor = System.Drawing.Color.Khaki
            Me.lblB0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.TableLayoutPanel0.SetColumnSpan(Me.lblB0, 2)
            Me.lblB0.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblB0.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblB0.Location = New System.Drawing.Point(312, 0)
            Me.lblB0.Name = "lblB0"
            Me.lblB0.Size = New System.Drawing.Size(374, 40)
            Me.lblB0.TabIndex = 9
            Me.lblB0.Text = "Parametri/Condizioni"
            Me.lblB0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblC0
            '
            Me.lblC0.AutoSize = True
            Me.lblC0.BackColor = System.Drawing.Color.Khaki
            Me.lblC0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblC0.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblC0.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblC0.Location = New System.Drawing.Point(692, 0)
            Me.lblC0.Name = "lblC0"
            Me.lblC0.Size = New System.Drawing.Size(95, 40)
            Me.lblC0.TabIndex = 10
            Me.lblC0.Text = "Premio"
            Me.lblC0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblD0
            '
            Me.lblD0.AutoSize = True
            Me.lblD0.BackColor = System.Drawing.Color.Khaki
            Me.lblD0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblD0.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblD0.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblD0.Location = New System.Drawing.Point(3, 0)
            Me.lblD0.Name = "lblD0"
            Me.lblD0.Size = New System.Drawing.Size(49, 40)
            Me.lblD0.TabIndex = 11
            Me.lblD0.Text = "Scelto"
            Me.lblD0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
            'P01263FE
            '
            Me.Name = "P01263FE"
            Me.Size = New System.Drawing.Size(1026, 575)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage0.ResumeLayout(False)
            Me.GroupBox0.ResumeLayout(False)
            Me.TableLayoutPanel0.ResumeLayout(False)
            Me.TableLayoutPanel0.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Private Sub InitializeComponent2()
            InitializeComponent()
            Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        End Sub
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabAgg As System.Windows.Forms.TabPage
        Friend WithEvents TabPage0 As System.Windows.Forms.TabPage
        Friend WithEvents GroupBox0 As System.Windows.Forms.GroupBox
        Friend WithEvents TableLayoutPanel0 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents lblA0 As System.Windows.Forms.Label
        Friend WithEvents lblB0 As System.Windows.Forms.Label
        Friend WithEvents lblC0 As System.Windows.Forms.Label
        Friend WithEvents lblD0 As System.Windows.Forms.Label
        Friend WithEvents lblSezioneMalattiaSintesi As System.Windows.Forms.Label
        Friend WithEvents lblSezioneMalattiaPremio As System.Windows.Forms.Label
        Friend WithEvents chkSezioneMalattia As System.Windows.Forms.CheckBox
        Friend WithEvents lblSezioneAssistenzaSintesi As System.Windows.Forms.Label
        Friend WithEvents lblSezioneAssistenzaPremio As System.Windows.Forms.Label
        Friend WithEvents chkSezioneAssistenza As System.Windows.Forms.CheckBox
        Friend WithEvents lblSezioneTotalePremio As System.Windows.Forms.Label
        Friend WithEvents lblSezioneTotaleSintesi As System.Windows.Forms.Label
    End Class
End Namespace
