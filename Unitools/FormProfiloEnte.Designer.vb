<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProfiloEnte
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
        Me.CheckBoxAccettaLicenza = New System.Windows.Forms.CheckBox()
        Me.tlpDati = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelGuida = New System.Windows.Forms.Label()
        Me.ComboBoxCompagnia = New System.Windows.Forms.ComboBox()
        Me.ButtonSalva = New System.Windows.Forms.Button()
        Me.ComboBoxProvincia = New System.Windows.Forms.ComboBox()
        Me.TextBoxCodiceAgenzia = New System.Windows.Forms.TextBox()
        Me.TextBoxCodiceSede = New System.Windows.Forms.TextBox()
        Me.TextBoxLocalita = New System.Windows.Forms.TextBox()
        Me.TextBoxIndirizzo = New System.Windows.Forms.TextBox()
        Me.TextBoxCap = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBoxCapoluogo = New System.Windows.Forms.ComboBox()
        Me.PictureBoxLogo = New System.Windows.Forms.PictureBox()
        Me.wbLicenza = New System.Windows.Forms.WebBrowser()
        Me.tlpMain.SuspendLayout()
        Me.tlpDati.SuspendLayout()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.tlpMain.Controls.Add(Me.CheckBoxAccettaLicenza, 1, 1)
        Me.tlpMain.Controls.Add(Me.tlpDati, 0, 0)
        Me.tlpMain.Controls.Add(Me.wbLicenza, 1, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpMain.Size = New System.Drawing.Size(701, 409)
        Me.tlpMain.TabIndex = 0
        '
        'CheckBoxAccettaLicenza
        '
        Me.CheckBoxAccettaLicenza.AutoSize = True
        Me.CheckBoxAccettaLicenza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxAccettaLicenza.Location = New System.Drawing.Point(388, 382)
        Me.CheckBoxAccettaLicenza.Name = "CheckBoxAccettaLicenza"
        Me.CheckBoxAccettaLicenza.Size = New System.Drawing.Size(310, 24)
        Me.CheckBoxAccettaLicenza.TabIndex = 1
        Me.CheckBoxAccettaLicenza.Text = "CheckBox1"
        Me.CheckBoxAccettaLicenza.UseVisualStyleBackColor = True
        '
        'tlpDati
        '
        Me.tlpDati.ColumnCount = 4
        Me.tlpDati.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.98694!))
        Me.tlpDati.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.68145!))
        Me.tlpDati.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.56418!))
        Me.tlpDati.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.76744!))
        Me.tlpDati.Controls.Add(Me.LabelGuida, 0, 1)
        Me.tlpDati.Controls.Add(Me.ComboBoxCompagnia, 1, 2)
        Me.tlpDati.Controls.Add(Me.ButtonSalva, 0, 8)
        Me.tlpDati.Controls.Add(Me.ComboBoxProvincia, 1, 7)
        Me.tlpDati.Controls.Add(Me.TextBoxCodiceAgenzia, 1, 3)
        Me.tlpDati.Controls.Add(Me.TextBoxCodiceSede, 2, 3)
        Me.tlpDati.Controls.Add(Me.TextBoxLocalita, 1, 4)
        Me.tlpDati.Controls.Add(Me.TextBoxIndirizzo, 1, 5)
        Me.tlpDati.Controls.Add(Me.TextBoxCap, 1, 6)
        Me.tlpDati.Controls.Add(Me.Label2, 0, 2)
        Me.tlpDati.Controls.Add(Me.Label3, 0, 3)
        Me.tlpDati.Controls.Add(Me.Label4, 0, 4)
        Me.tlpDati.Controls.Add(Me.Label5, 0, 5)
        Me.tlpDati.Controls.Add(Me.Label6, 0, 6)
        Me.tlpDati.Controls.Add(Me.Label7, 0, 7)
        Me.tlpDati.Controls.Add(Me.ComboBoxCapoluogo, 2, 4)
        Me.tlpDati.Controls.Add(Me.PictureBoxLogo, 0, 0)
        Me.tlpDati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDati.Location = New System.Drawing.Point(3, 3)
        Me.tlpDati.Name = "tlpDati"
        Me.tlpDati.RowCount = 9
        Me.tlpMain.SetRowSpan(Me.tlpDati, 2)
        Me.tlpDati.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.tlpDati.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDati.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpDati.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpDati.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpDati.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpDati.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpDati.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpDati.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpDati.Size = New System.Drawing.Size(379, 403)
        Me.tlpDati.TabIndex = 2
        '
        'LabelGuida
        '
        Me.LabelGuida.AutoSize = True
        Me.tlpDati.SetColumnSpan(Me.LabelGuida, 4)
        Me.LabelGuida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelGuida.Location = New System.Drawing.Point(3, 85)
        Me.LabelGuida.Name = "LabelGuida"
        Me.LabelGuida.Size = New System.Drawing.Size(373, 88)
        Me.LabelGuida.TabIndex = 0
        Me.LabelGuida.Text = "Label1"
        Me.LabelGuida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBoxCompagnia
        '
        Me.ComboBoxCompagnia.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBoxCompagnia.FormattingEnabled = True
        Me.ComboBoxCompagnia.Location = New System.Drawing.Point(120, 176)
        Me.ComboBoxCompagnia.Name = "ComboBoxCompagnia"
        Me.ComboBoxCompagnia.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxCompagnia.TabIndex = 0
        '
        'ButtonSalva
        '
        Me.tlpDati.SetColumnSpan(Me.ButtonSalva, 4)
        Me.ButtonSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSalva.Location = New System.Drawing.Point(3, 356)
        Me.ButtonSalva.Name = "ButtonSalva"
        Me.ButtonSalva.Size = New System.Drawing.Size(373, 44)
        Me.ButtonSalva.TabIndex = 7
        Me.ButtonSalva.Text = "Button1"
        Me.ButtonSalva.UseVisualStyleBackColor = True
        '
        'ComboBoxProvincia
        '
        Me.ComboBoxProvincia.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBoxProvincia.FormattingEnabled = True
        Me.ComboBoxProvincia.Location = New System.Drawing.Point(120, 326)
        Me.ComboBoxProvincia.Name = "ComboBoxProvincia"
        Me.ComboBoxProvincia.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxProvincia.TabIndex = 6
        '
        'TextBoxCodiceAgenzia
        '
        Me.TextBoxCodiceAgenzia.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBoxCodiceAgenzia.Location = New System.Drawing.Point(120, 206)
        Me.TextBoxCodiceAgenzia.Name = "TextBoxCodiceAgenzia"
        Me.TextBoxCodiceAgenzia.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxCodiceAgenzia.TabIndex = 1
        Me.TextBoxCodiceAgenzia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxCodiceSede
        '
        Me.tlpDati.SetColumnSpan(Me.TextBoxCodiceSede, 2)
        Me.TextBoxCodiceSede.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBoxCodiceSede.Location = New System.Drawing.Point(247, 206)
        Me.TextBoxCodiceSede.Name = "TextBoxCodiceSede"
        Me.TextBoxCodiceSede.Size = New System.Drawing.Size(129, 20)
        Me.TextBoxCodiceSede.TabIndex = 6
        Me.TextBoxCodiceSede.TabStop = False
        Me.TextBoxCodiceSede.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxLocalita
        '
        Me.TextBoxLocalita.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBoxLocalita.Location = New System.Drawing.Point(120, 236)
        Me.TextBoxLocalita.Name = "TextBoxLocalita"
        Me.TextBoxLocalita.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxLocalita.TabIndex = 2
        '
        'TextBoxIndirizzo
        '
        Me.tlpDati.SetColumnSpan(Me.TextBoxIndirizzo, 3)
        Me.TextBoxIndirizzo.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBoxIndirizzo.Location = New System.Drawing.Point(120, 266)
        Me.TextBoxIndirizzo.Name = "TextBoxIndirizzo"
        Me.TextBoxIndirizzo.Size = New System.Drawing.Size(256, 20)
        Me.TextBoxIndirizzo.TabIndex = 4
        '
        'TextBoxCap
        '
        Me.TextBoxCap.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBoxCap.Location = New System.Drawing.Point(120, 296)
        Me.TextBoxCap.Name = "TextBoxCap"
        Me.TextBoxCap.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxCap.TabIndex = 5
        Me.TextBoxCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 30)
        Me.Label2.TabIndex = 10
        Me.Label2.Tag = ""
        Me.Label2.Text = "Compagnia"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 203)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 30)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Codice agenzia-Sede"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 30)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Agenzia di"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 263)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 30)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Indirizzo"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(3, 293)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 30)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Cap"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(3, 323)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 30)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Provincia"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxCapoluogo
        '
        Me.tlpDati.SetColumnSpan(Me.ComboBoxCapoluogo, 2)
        Me.ComboBoxCapoluogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBoxCapoluogo.FormattingEnabled = True
        Me.ComboBoxCapoluogo.Location = New System.Drawing.Point(247, 236)
        Me.ComboBoxCapoluogo.Name = "ComboBoxCapoluogo"
        Me.ComboBoxCapoluogo.Size = New System.Drawing.Size(129, 21)
        Me.ComboBoxCapoluogo.TabIndex = 3
        '
        'PictureBoxLogo
        '
        Me.tlpDati.SetColumnSpan(Me.PictureBoxLogo, 4)
        Me.PictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxLogo.Location = New System.Drawing.Point(3, 3)
        Me.PictureBoxLogo.Name = "PictureBoxLogo"
        Me.PictureBoxLogo.Size = New System.Drawing.Size(373, 79)
        Me.PictureBoxLogo.TabIndex = 16
        Me.PictureBoxLogo.TabStop = False
        '
        'wbLicenza
        '
        Me.wbLicenza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbLicenza.Location = New System.Drawing.Point(388, 3)
        Me.wbLicenza.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbLicenza.Name = "wbLicenza"
        Me.wbLicenza.Size = New System.Drawing.Size(310, 373)
        Me.wbLicenza.TabIndex = 3
        '
        'FormProfiloEnte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 409)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormProfiloEnte"
        Me.Text = "FormProfiloEnte"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.tlpDati.ResumeLayout(False)
        Me.tlpDati.PerformLayout()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxAccettaLicenza As System.Windows.Forms.CheckBox
    Friend WithEvents tlpDati As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelGuida As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCompagnia As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonSalva As System.Windows.Forms.Button
    Friend WithEvents ComboBoxCapoluogo As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxCodiceAgenzia As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCodiceSede As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxLocalita As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxIndirizzo As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCap As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents wbLicenza As System.Windows.Forms.WebBrowser
End Class
