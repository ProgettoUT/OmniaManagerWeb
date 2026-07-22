'Me.TableLayoutPanel7.Controls.Add(Me.desTerremotoFabbricato, 1, 16)
'Me.TableLayoutPanel7.Controls.Add(Me.cmbTerremotoFabbricatoLimite, 2, 16)
'Me.TableLayoutPanel7.Controls.Add(Me.cmbCaratteristicaCostruttiva, 3, 16)
'Me.TableLayoutPanel7.Controls.Add(Me.lblTerremotoFabbricato, 4, 16)
'Me.TableLayoutPanel7.Controls.Add(Me.chkTerremotoFabbricato, 0, 16)
'Me.TableLayoutPanel7.Controls.Add(Me.desTerremotoContenuto, 1, 17)
'Me.TableLayoutPanel7.Controls.Add(Me.lblTerremotoContenuto, 4, 17)
'Me.TableLayoutPanel7.Controls.Add(Me.chkTerremotoContenuto, 0, 17)

Namespace P07261
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AbitazioneFE
        Inherits System.Windows.Forms.UserControl

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

        'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
        'Può essere modificata in Progettazione Windows Form.  
        'Non modificarla nell'editor del codice.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.cmdRemove = New System.Windows.Forms.Button()
            Me.lblProvincia = New System.Windows.Forms.Label()
            Me.cmbProvincia = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cmbComune = New System.Windows.Forms.ComboBox()
            Me.lblTipoAbitazione = New System.Windows.Forms.Label()
            Me.cmbTipoAbitazione = New System.Windows.Forms.ComboBox()
            Me.txtDescrizione = New System.Windows.Forms.TextBox()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.NoteAbitazione = New UniQuota.NoteBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.cmbTipoDimora = New System.Windows.Forms.ComboBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.cmbPianoAbitazione = New System.Windows.Forms.ComboBox()
            Me.cmbCaratteristicaCostruttiva = New System.Windows.Forms.ComboBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtNumeroCivico = New System.Windows.Forms.TextBox()
            Me.txtIndirizzo = New System.Windows.Forms.TextBox()
            Me.TabPage7 = New System.Windows.Forms.TabPage()
            Me.GroupBox7 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
            Me.cmbIncendioChiave = New System.Windows.Forms.ComboBox()
            Me.cmbIncendioAbitazioneFormAss = New System.Windows.Forms.ComboBox()
            Me.cmbIncendioContenutoFormAss = New System.Windows.Forms.ComboBox()
            Me.cmbIncendioLocazioneFormAss = New System.Windows.Forms.ComboBox()
            Me.lblIncendioPremio = New System.Windows.Forms.Label()
            Me.chkIncendioBase = New System.Windows.Forms.CheckBox()
            Me.desIncendioAbitazione = New System.Windows.Forms.Label()
            Me.lblIncendioAbitazione = New System.Windows.Forms.Label()
            Me.chkIncendioAbitazione = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioAbitazione = New System.Windows.Forms.TextBox()
            Me.desIncendioContenuto = New System.Windows.Forms.Label()
            Me.lblIncendioContenuto = New System.Windows.Forms.Label()
            Me.chkIncendioContenuto = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioContenuto = New System.Windows.Forms.TextBox()
            Me.desIncendioLocazione = New System.Windows.Forms.Label()
            Me.lblIncendioLocazione = New System.Windows.Forms.Label()
            Me.chkIncendioLocazione = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioLocazione = New System.Windows.Forms.TextBox()
            Me.desIncendioCondutture = New System.Windows.Forms.Label()
            Me.lblIncendioCondutture = New System.Windows.Forms.Label()
            Me.chkIncendioCondutture = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioFenomeniElettrici = New System.Windows.Forms.TextBox()
            Me.cmbIncendioConduttureFranchigia = New System.Windows.Forms.ComboBox()
            Me.desIncendioFenomeniElettrici = New System.Windows.Forms.Label()
            Me.lblIncendioFenomeniElettrici = New System.Windows.Forms.Label()
            Me.chkIncendioFenomeniElettrici = New System.Windows.Forms.CheckBox()
            Me.cmbIncendioFenomeniElettriciFranchigia = New System.Windows.Forms.ComboBox()
            Me.desIncendioFenomeniAtmosferici = New System.Windows.Forms.Label()
            Me.lblIncendioFenomeniAtmosferici = New System.Windows.Forms.Label()
            Me.chkIncendioFenomeniAtmosferici = New System.Windows.Forms.CheckBox()
            Me.cmbIncendioFenomeniAtmosfericiLimite = New System.Windows.Forms.ComboBox()
            Me.cmbIncendioFenomeniAtmosfericiCombinazione = New System.Windows.Forms.ComboBox()
            Me.desIncendioFenomeniAtmosfericiLarge = New System.Windows.Forms.Label()
            Me.lblIncendioFenomeniAtmosfericiLarge = New System.Windows.Forms.Label()
            Me.chkIncendioFenomeniAtmosfericiLarge = New System.Windows.Forms.CheckBox()
            Me.cmbIncendioFenomeniAtmosfericiLargeCombinazione = New System.Windows.Forms.ComboBox()
            Me.cmbIncendioFenomeniAtmosfericiLargeMassimale = New System.Windows.Forms.ComboBox()
            Me.desIncendioRicorsoTerzi = New System.Windows.Forms.Label()
            Me.lblIncendioRicorsoTerzi = New System.Windows.Forms.Label()
            Me.chkIncendioRicorsoTerzi = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioRicorsoTerzi = New System.Windows.Forms.TextBox()
            Me.desIncendioDemolizione = New System.Windows.Forms.Label()
            Me.lblIncendioDemolizione = New System.Windows.Forms.Label()
            Me.chkIncendioDemolizione = New System.Windows.Forms.CheckBox()
            Me.cmbIncendioDemolizioneMassimale = New System.Windows.Forms.ComboBox()
            Me.desIncendioGelo = New System.Windows.Forms.Label()
            Me.lblIncendioGelo = New System.Windows.Forms.Label()
            Me.chkIncendioGelo = New System.Windows.Forms.CheckBox()
            Me.cmbIncendioGeloMassimale = New System.Windows.Forms.ComboBox()
            Me.cmbIncendioGeloFranchigia = New System.Windows.Forms.ComboBox()
            Me.desIncendioRicercaGuasto = New System.Windows.Forms.Label()
            Me.lblIncendioRicercaGuasto = New System.Windows.Forms.Label()
            Me.chkIncendioRicercaGuasto = New System.Windows.Forms.CheckBox()
            Me.cmbIncendioRicercaGuastoMassimale = New System.Windows.Forms.ComboBox()
            Me.cmbIncendioRicercaGuastoFranchigia = New System.Windows.Forms.ComboBox()
            Me.desIncendioAcquaOcclusione = New System.Windows.Forms.Label()
            Me.lblIncendioAcquaOcclusione = New System.Windows.Forms.Label()
            Me.chkIncendioAcquaOcclusione = New System.Windows.Forms.CheckBox()
            Me.cmbIncendioAcquaOcclusioneMassimale = New System.Windows.Forms.ComboBox()
            Me.cmbIncendioAcquaOcclusioneFranchigia = New System.Windows.Forms.ComboBox()
            Me.desIncendioPannelliSolari = New System.Windows.Forms.Label()
            Me.lblIncendioPannelliSolari = New System.Windows.Forms.Label()
            Me.chkIncendioPannelliSolari = New System.Windows.Forms.CheckBox()
            Me.cmbIncendioPannelliSolariMassimale = New System.Windows.Forms.ComboBox()
            Me.desIncendioRiduzioneFranchigiaFenomeniElettrici = New System.Windows.Forms.Label()
            Me.lblIncendioRiduzioneFranchigiaFenomeniElettrici = New System.Windows.Forms.Label()
            Me.chkIncendioRiduzioneFranchigiaFenomeniElettrici = New System.Windows.Forms.CheckBox()
            Me.desIncendioEstensioneGaranziaBase = New System.Windows.Forms.Label()
            Me.chkIncendioEstensioneGaranziaBase = New System.Windows.Forms.CheckBox()
            Me.lblIncendioEstensioneGaranziaBase = New System.Windows.Forms.Label()
            Me.desIncendioPannelliSolariEstensioneFenomenoElettrico = New System.Windows.Forms.Label()
            Me.chkIncendioPannelliSolariEstensioneFenomenoElettrico = New System.Windows.Forms.CheckBox()
            Me.lblIncendioPannelliSolariEstensioneFenomenoElettrico = New System.Windows.Forms.Label()
            Me.desIncendioPannelliSolariEstensioneFenomenoAtmosferici = New System.Windows.Forms.Label()
            Me.chkIncendioPannelliSolariEstensioneFenomenoAtmosferici = New System.Windows.Forms.CheckBox()
            Me.lblIncendioPannelliSolariEstensioneFenomenoAtmosferici = New System.Windows.Forms.Label()
            Me.desIncendioPerditeOcculteAcqua = New System.Windows.Forms.Label()
            Me.chkIncendioPerditeOcculteAcqua = New System.Windows.Forms.CheckBox()
            Me.lblIncendioPerditeOcculteAcqua = New System.Windows.Forms.Label()
            Me.lblA7 = New System.Windows.Forms.Label()
            Me.lblB7 = New System.Windows.Forms.Label()
            Me.lblC7 = New System.Windows.Forms.Label()
            Me.lblD7 = New System.Windows.Forms.Label()
            Me.cmbIncendioPannelliSolariFranchigia = New System.Windows.Forms.ComboBox()
            Me.TabPage8 = New System.Windows.Forms.TabPage()
            Me.GroupBox8 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblTerremotoPremio = New System.Windows.Forms.Label()
            Me.chkTerremotoBase = New System.Windows.Forms.CheckBox()
            Me.desTerremotoFabbricato = New System.Windows.Forms.Label()
            Me.lblTerremotoFabbricato = New System.Windows.Forms.Label()
            Me.chkTerremotoFabbricato = New System.Windows.Forms.CheckBox()
            Me.cmbTerremotoFabbricatoLimite = New System.Windows.Forms.ComboBox()
            Me.desTerremotoContenuto = New System.Windows.Forms.Label()
            Me.lblTerremotoContenuto = New System.Windows.Forms.Label()
            Me.chkTerremotoContenuto = New System.Windows.Forms.CheckBox()
            Me.lblA8 = New System.Windows.Forms.Label()
            Me.lblB8 = New System.Windows.Forms.Label()
            Me.lblC8 = New System.Windows.Forms.Label()
            Me.lblD8 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cmbTerremotoContenutoFormAss = New System.Windows.Forms.ComboBox()
            Me.TabPage9 = New System.Windows.Forms.TabPage()
            Me.GroupBox9 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
            Me.cmbFurtoChiave = New System.Windows.Forms.ComboBox()
            Me.cmbFurtoEsternoScelta = New System.Windows.Forms.ComboBox()
            Me.cmbFurtoEsternoPlatinoScelta = New System.Windows.Forms.ComboBox()
            Me.cmbFurtoInCassaforteScelta = New System.Windows.Forms.ComboBox()
            Me.cmbFurtoPreziosiValoriScelta = New System.Windows.Forms.ComboBox()
            Me.cmbFurtoValoriDimoraAbitualeDenaro = New System.Windows.Forms.ComboBox()
            Me.cmbFurtoValoriDimoraAbitualeValori = New System.Windows.Forms.ComboBox()
            Me.lblFurtoPremio = New System.Windows.Forms.Label()
            Me.chkFurtoBase = New System.Windows.Forms.CheckBox()
            Me.desFurtoContenuto = New System.Windows.Forms.Label()
            Me.lblFurtoContenuto = New System.Windows.Forms.Label()
            Me.chkFurtoContenuto = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoContenuto = New System.Windows.Forms.TextBox()
            Me.desFurtoEsterno = New System.Windows.Forms.Label()
            Me.lblFurtoEsterno = New System.Windows.Forms.Label()
            Me.chkFurtoEsterno = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoEsterno = New System.Windows.Forms.TextBox()
            Me.cmbFurtoEsternoLimite = New System.Windows.Forms.ComboBox()
            Me.cmbFurtoEsternoMassimale = New System.Windows.Forms.ComboBox()
            Me.desFurtoEsternoPlatino = New System.Windows.Forms.Label()
            Me.lblFurtoEsternoPlatino = New System.Windows.Forms.Label()
            Me.chkFurtoEsternoPlatino = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoEsternoPlatino = New System.Windows.Forms.TextBox()
            Me.desFurtoInCassaforte = New System.Windows.Forms.Label()
            Me.lblFurtoInCassaforte = New System.Windows.Forms.Label()
            Me.chkFurtoInCassaforte = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoInCassaforte = New System.Windows.Forms.TextBox()
            Me.desFurtoPreziosiValori = New System.Windows.Forms.Label()
            Me.lblFurtoPreziosiValori = New System.Windows.Forms.Label()
            Me.chkFurtoPreziosiValori = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoPreziosiValori = New System.Windows.Forms.TextBox()
            Me.desFurtoValoriDimoraAbituale = New System.Windows.Forms.Label()
            Me.lblFurtoValoriDimoraAbituale = New System.Windows.Forms.Label()
            Me.chkFurtoValoriDimoraAbituale = New System.Windows.Forms.CheckBox()
            Me.desFurtoValoriDimoraSaltuaria = New System.Windows.Forms.Label()
            Me.lblFurtoValoriDimoraSaltuaria = New System.Windows.Forms.Label()
            Me.chkFurtoValoriDimoraSaltuaria = New System.Windows.Forms.CheckBox()
            Me.desFurtoPannelliSolari = New System.Windows.Forms.Label()
            Me.lblFurtoPannelliSolari = New System.Windows.Forms.Label()
            Me.chkFurtoPannelliSolari = New System.Windows.Forms.CheckBox()
            Me.cmbFurtoPannelliSolariMassimale = New System.Windows.Forms.ComboBox()
            Me.desFurtoMezziChiusura = New System.Windows.Forms.Label()
            Me.lblFurtoMezziChiusura = New System.Windows.Forms.Label()
            Me.chkFurtoMezziChiusura = New System.Windows.Forms.CheckBox()
            Me.desFurtoImpiantoAllarme = New System.Windows.Forms.Label()
            Me.lblFurtoImpiantoAllarme = New System.Windows.Forms.Label()
            Me.chkFurtoImpiantoAllarme = New System.Windows.Forms.CheckBox()
            Me.desFurtoFranchigia = New System.Windows.Forms.Label()
            Me.lblFurtoFranchigia = New System.Windows.Forms.Label()
            Me.chkFurtoFranchigia = New System.Windows.Forms.CheckBox()
            Me.cmbFurtoFranchigiaFranchigia = New System.Windows.Forms.ComboBox()
            Me.desFurtoEstensioneGaranziaBase = New System.Windows.Forms.Label()
            Me.chkFurtoEstensioneGaranziaBase = New System.Windows.Forms.CheckBox()
            Me.lblFurtoEstensioneGaranziaBase = New System.Windows.Forms.Label()
            Me.lblA9 = New System.Windows.Forms.Label()
            Me.lblB9 = New System.Windows.Forms.Label()
            Me.lblC9 = New System.Windows.Forms.Label()
            Me.lblD9 = New System.Windows.Forms.Label()
            Me.cmbFurtoContenutoFormAss = New System.Windows.Forms.ComboBox()
            Me.TableLayoutPanel0 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblSezioneIncendioSintesi = New System.Windows.Forms.Label()
            Me.lblSezioneIncendioPremio = New System.Windows.Forms.Label()
            Me.chkSezioneIncendio = New System.Windows.Forms.CheckBox()
            Me.lblSezioneTerremotoSintesi = New System.Windows.Forms.Label()
            Me.lblSezioneTerremotoPremio = New System.Windows.Forms.Label()
            Me.chkSezioneTerremoto = New System.Windows.Forms.CheckBox()
            Me.lblSezioneFurtoSintesi = New System.Windows.Forms.Label()
            Me.lblSezioneFurtoPremio = New System.Windows.Forms.Label()
            Me.chkSezioneFurto = New System.Windows.Forms.CheckBox()
            Me.lblSezioneTotalePremio = New System.Windows.Forms.Label()
            Me.lblSezioneTotaleSintesi = New System.Windows.Forms.Label()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.TabPage7.SuspendLayout()
            Me.GroupBox7.SuspendLayout()
            Me.TableLayoutPanel7.SuspendLayout()
            Me.TabPage8.SuspendLayout()
            Me.GroupBox8.SuspendLayout()
            Me.TableLayoutPanel8.SuspendLayout()
            Me.TabPage9.SuspendLayout()
            Me.GroupBox9.SuspendLayout()
            Me.TableLayoutPanel9.SuspendLayout()
            Me.SuspendLayout()
            '
            'cmdRemove
            '
            Me.cmdRemove.BackColor = System.Drawing.Color.Khaki
            Me.cmdRemove.Cursor = System.Windows.Forms.Cursors.Hand
            Me.cmdRemove.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmdRemove.FlatAppearance.BorderColor = System.Drawing.Color.Black
            Me.cmdRemove.FlatAppearance.BorderSize = 0
            Me.cmdRemove.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
            Me.cmdRemove.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
            Me.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cmdRemove.Image = Global.UniQuota.My.Resources.Resources.Remove
            Me.cmdRemove.Location = New System.Drawing.Point(977, 0)
            Me.cmdRemove.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
            Me.cmdRemove.Name = "cmdRemove"
            Me.cmdRemove.Size = New System.Drawing.Size(32, 40)
            Me.cmdRemove.TabIndex = 5
            Me.cmdRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            Me.cmdRemove.UseVisualStyleBackColor = False
            '
            'lblProvincia
            '
            Me.lblProvincia.AutoSize = True
            Me.lblProvincia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblProvincia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProvincia.Location = New System.Drawing.Point(0, 40)
            Me.lblProvincia.Margin = New System.Windows.Forms.Padding(0)
            Me.lblProvincia.Name = "lblProvincia"
            Me.lblProvincia.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
            Me.lblProvincia.Size = New System.Drawing.Size(325, 30)
            Me.lblProvincia.TabIndex = 2
            Me.lblProvincia.Text = "Provincia"
            Me.lblProvincia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmbProvincia
            '
            Me.cmbProvincia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbProvincia.FormattingEnabled = True
            Me.cmbProvincia.Location = New System.Drawing.Point(328, 43)
            Me.cmbProvincia.Name = "cmbProvincia"
            Me.cmbProvincia.Size = New System.Drawing.Size(320, 21)
            Me.cmbProvincia.TabIndex = 3
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(0, 70)
            Me.Label1.Margin = New System.Windows.Forms.Padding(0)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(325, 30)
            Me.Label1.TabIndex = 29
            Me.Label1.Text = "Comune"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmbComune
            '
            Me.cmbComune.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbComune.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbComune.FormattingEnabled = True
            Me.cmbComune.Location = New System.Drawing.Point(328, 73)
            Me.cmbComune.Name = "cmbComune"
            Me.cmbComune.Size = New System.Drawing.Size(320, 21)
            Me.cmbComune.TabIndex = 30
            '
            'lblTipoAbitazione
            '
            Me.lblTipoAbitazione.AutoSize = True
            Me.lblTipoAbitazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTipoAbitazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTipoAbitazione.Location = New System.Drawing.Point(0, 100)
            Me.lblTipoAbitazione.Margin = New System.Windows.Forms.Padding(0)
            Me.lblTipoAbitazione.Name = "lblTipoAbitazione"
            Me.lblTipoAbitazione.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
            Me.lblTipoAbitazione.Size = New System.Drawing.Size(325, 30)
            Me.lblTipoAbitazione.TabIndex = 0
            Me.lblTipoAbitazione.Tag = ""
            Me.lblTipoAbitazione.Text = "Tipo Abitazione"
            Me.lblTipoAbitazione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmbTipoAbitazione
            '
            Me.cmbTipoAbitazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbTipoAbitazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTipoAbitazione.FormattingEnabled = True
            Me.cmbTipoAbitazione.Location = New System.Drawing.Point(328, 103)
            Me.cmbTipoAbitazione.Name = "cmbTipoAbitazione"
            Me.cmbTipoAbitazione.Size = New System.Drawing.Size(320, 21)
            Me.cmbTipoAbitazione.TabIndex = 1
            '
            'txtDescrizione
            '
            Me.txtDescrizione.BackColor = System.Drawing.SystemColors.Window
            Me.txtDescrizione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtDescrizione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDescrizione.Location = New System.Drawing.Point(328, 283)
            Me.txtDescrizione.Name = "txtDescrizione"
            Me.txtDescrizione.Size = New System.Drawing.Size(320, 22)
            Me.txtDescrizione.TabIndex = 5
            Me.txtDescrizione.TabStop = False
            Me.txtDescrizione.Tag = "Descrizione dell'abitazione"
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage7)
            Me.TabControl1.Controls.Add(Me.TabPage8)
            Me.TabControl1.Controls.Add(Me.TabPage9)
            Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControl1.ItemSize = New System.Drawing.Size(180, 25)
            Me.TabControl1.Location = New System.Drawing.Point(0, 0)
            Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.Padding = New System.Drawing.Point(0, 0)
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(1026, 637)
            Me.TabControl1.TabIndex = 0
            Me.TabControl1.Tag = ""
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.GroupBox1)
            Me.TabPage1.Location = New System.Drawing.Point(4, 29)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(1018, 604)
            Me.TabPage1.TabIndex = 4
            Me.TabPage1.Text = "Abitazione"
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
            Me.GroupBox1.Size = New System.Drawing.Size(1018, 604)
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.TabStop = False
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.txtDescrizione, 1, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.NoteAbitazione, 0, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.cmbTipoAbitazione, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblTipoAbitazione, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.cmbComune, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.cmbProvincia, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblProvincia, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.cmdRemove, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.cmbTipoDimora, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.cmbPianoAbitazione, 1, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.cmbCaratteristicaCostruttiva, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.txtNumeroCivico, 1, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.txtIndirizzo, 1, 7)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 13)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 12
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(1012, 588)
            Me.TableLayoutPanel1.TabIndex = 1
            '
            'NoteAbitazione
            '
            Me.NoteAbitazione.Caption = "Note"
            Me.NoteAbitazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.NoteAbitazione.Location = New System.Drawing.Point(0, 313)
            Me.NoteAbitazione.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
            Me.NoteAbitazione.Name = "NoteAbitazione"
            Me.NoteAbitazione.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
            Me.NoteAbitazione.Size = New System.Drawing.Size(325, 24)
            Me.NoteAbitazione.TabIndex = 28
            Me.NoteAbitazione.TextNote = Nothing
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.BackColor = System.Drawing.Color.Khaki
            Me.TableLayoutPanel1.SetColumnSpan(Me.Label12, 3)
            Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.Location = New System.Drawing.Point(3, 0)
            Me.Label12.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
            Me.Label12.Name = "Label12"
            Me.Label12.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
            Me.Label12.Size = New System.Drawing.Size(974, 40)
            Me.Label12.TabIndex = 17
            Me.Label12.Text = "Parametri generali"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(0, 280)
            Me.Label4.Margin = New System.Windows.Forms.Padding(0)
            Me.Label4.Name = "Label4"
            Me.Label4.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
            Me.Label4.Size = New System.Drawing.Size(325, 30)
            Me.Label4.TabIndex = 31
            Me.Label4.Tag = ""
            Me.Label4.Text = "Descrizione"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.Location = New System.Drawing.Point(0, 130)
            Me.Label5.Margin = New System.Windows.Forms.Padding(0)
            Me.Label5.Name = "Label5"
            Me.Label5.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
            Me.Label5.Size = New System.Drawing.Size(325, 30)
            Me.Label5.TabIndex = 0
            Me.Label5.Tag = ""
            Me.Label5.Text = "Tipo Dimora"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmbTipoDimora
            '
            Me.cmbTipoDimora.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbTipoDimora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTipoDimora.FormattingEnabled = True
            Me.cmbTipoDimora.Location = New System.Drawing.Point(328, 133)
            Me.cmbTipoDimora.Name = "cmbTipoDimora"
            Me.cmbTipoDimora.Size = New System.Drawing.Size(320, 21)
            Me.cmbTipoDimora.TabIndex = 1
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.Location = New System.Drawing.Point(0, 160)
            Me.Label6.Margin = New System.Windows.Forms.Padding(0)
            Me.Label6.Name = "Label6"
            Me.Label6.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
            Me.Label6.Size = New System.Drawing.Size(325, 30)
            Me.Label6.TabIndex = 0
            Me.Label6.Tag = ""
            Me.Label6.Text = "Piano Abitazione"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmbPianoAbitazione
            '
            Me.cmbPianoAbitazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbPianoAbitazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbPianoAbitazione.FormattingEnabled = True
            Me.cmbPianoAbitazione.Location = New System.Drawing.Point(328, 163)
            Me.cmbPianoAbitazione.Name = "cmbPianoAbitazione"
            Me.cmbPianoAbitazione.Size = New System.Drawing.Size(320, 21)
            Me.cmbPianoAbitazione.TabIndex = 1
            '
            'cmbCaratteristicaCostruttiva
            '
            Me.cmbCaratteristicaCostruttiva.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbCaratteristicaCostruttiva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCaratteristicaCostruttiva.FormattingEnabled = True
            Me.cmbCaratteristicaCostruttiva.Location = New System.Drawing.Point(328, 193)
            Me.cmbCaratteristicaCostruttiva.Name = "cmbCaratteristicaCostruttiva"
            Me.cmbCaratteristicaCostruttiva.Size = New System.Drawing.Size(320, 21)
            Me.cmbCaratteristicaCostruttiva.TabIndex = 32
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.Location = New System.Drawing.Point(0, 190)
            Me.Label7.Margin = New System.Windows.Forms.Padding(0)
            Me.Label7.Name = "Label7"
            Me.Label7.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
            Me.Label7.Size = New System.Drawing.Size(325, 30)
            Me.Label7.TabIndex = 0
            Me.Label7.Tag = ""
            Me.Label7.Text = "Caratteristica Costruttiva"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.Location = New System.Drawing.Point(0, 220)
            Me.Label8.Margin = New System.Windows.Forms.Padding(0)
            Me.Label8.Name = "Label8"
            Me.Label8.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
            Me.Label8.Size = New System.Drawing.Size(325, 30)
            Me.Label8.TabIndex = 31
            Me.Label8.Tag = ""
            Me.Label8.Text = "Indirizzo"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.Location = New System.Drawing.Point(0, 250)
            Me.Label9.Margin = New System.Windows.Forms.Padding(0)
            Me.Label9.Name = "Label9"
            Me.Label9.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
            Me.Label9.Size = New System.Drawing.Size(325, 30)
            Me.Label9.TabIndex = 31
            Me.Label9.Tag = ""
            Me.Label9.Text = "Numero civico"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtNumeroCivico
            '
            Me.txtNumeroCivico.BackColor = System.Drawing.SystemColors.Window
            Me.txtNumeroCivico.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtNumeroCivico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtNumeroCivico.Location = New System.Drawing.Point(328, 253)
            Me.txtNumeroCivico.Name = "txtNumeroCivico"
            Me.txtNumeroCivico.Size = New System.Drawing.Size(320, 22)
            Me.txtNumeroCivico.TabIndex = 5
            Me.txtNumeroCivico.TabStop = False
            Me.txtNumeroCivico.Tag = "Descrizione dell'abitazione"
            '
            'txtIndirizzo
            '
            Me.txtIndirizzo.BackColor = System.Drawing.SystemColors.Window
            Me.txtIndirizzo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtIndirizzo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtIndirizzo.Location = New System.Drawing.Point(328, 223)
            Me.txtIndirizzo.Name = "txtIndirizzo"
            Me.txtIndirizzo.Size = New System.Drawing.Size(320, 22)
            Me.txtIndirizzo.TabIndex = 5
            Me.txtIndirizzo.TabStop = False
            Me.txtIndirizzo.Tag = "Descrizione dell'abitazione"
            '
            'TabPage7
            '
            Me.TabPage7.Controls.Add(Me.GroupBox7)
            Me.TabPage7.Location = New System.Drawing.Point(4, 29)
            Me.TabPage7.Name = "TabPage7"
            Me.TabPage7.Size = New System.Drawing.Size(1018, 604)
            Me.TabPage7.TabIndex = 1
            Me.TabPage7.Tag = ""
            Me.TabPage7.Text = "Incendio"
            Me.TabPage7.UseVisualStyleBackColor = True
            '
            'GroupBox7
            '
            Me.GroupBox7.Controls.Add(Me.TableLayoutPanel7)
            Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox7.Location = New System.Drawing.Point(0, 0)
            Me.GroupBox7.Margin = New System.Windows.Forms.Padding(0)
            Me.GroupBox7.Name = "GroupBox7"
            Me.GroupBox7.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
            Me.GroupBox7.Size = New System.Drawing.Size(1018, 604)
            Me.GroupBox7.TabIndex = 0
            Me.GroupBox7.TabStop = False
            '
            'TableLayoutPanel7
            '
            Me.TableLayoutPanel7.ColumnCount = 5
            Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
            Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
            Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioChiave, 2, 1)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioAbitazioneFormAss, 3, 2)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioContenutoFormAss, 3, 3)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioLocazioneFormAss, 3, 4)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioPremio, 4, 1)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioBase, 0, 1)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioAbitazione, 1, 2)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioAbitazione, 4, 2)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioAbitazione, 0, 2)
            Me.TableLayoutPanel7.Controls.Add(Me.txtPartitaIncendioAbitazione, 2, 2)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioContenuto, 1, 3)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioContenuto, 4, 3)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioContenuto, 0, 3)
            Me.TableLayoutPanel7.Controls.Add(Me.txtPartitaIncendioContenuto, 2, 3)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioLocazione, 1, 4)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioLocazione, 4, 4)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioLocazione, 0, 4)
            Me.TableLayoutPanel7.Controls.Add(Me.txtPartitaIncendioLocazione, 2, 4)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioCondutture, 1, 6)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioCondutture, 4, 6)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioCondutture, 0, 6)
            Me.TableLayoutPanel7.Controls.Add(Me.txtPartitaIncendioFenomeniElettrici, 2, 8)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioConduttureFranchigia, 2, 6)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioFenomeniElettrici, 1, 8)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioFenomeniElettrici, 4, 8)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioFenomeniElettrici, 0, 8)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioFenomeniElettriciFranchigia, 3, 8)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioFenomeniAtmosferici, 1, 10)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioFenomeniAtmosferici, 4, 10)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioFenomeniAtmosferici, 0, 10)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioFenomeniAtmosfericiLimite, 2, 10)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioFenomeniAtmosfericiCombinazione, 3, 10)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioFenomeniAtmosfericiLarge, 1, 11)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioFenomeniAtmosfericiLarge, 4, 11)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioFenomeniAtmosfericiLarge, 0, 11)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioFenomeniAtmosfericiLargeCombinazione, 3, 11)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioFenomeniAtmosfericiLargeMassimale, 2, 11)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioRicorsoTerzi, 1, 13)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioRicorsoTerzi, 4, 13)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioRicorsoTerzi, 0, 13)
            Me.TableLayoutPanel7.Controls.Add(Me.txtPartitaIncendioRicorsoTerzi, 2, 13)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioDemolizione, 1, 14)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioDemolizione, 4, 14)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioDemolizione, 0, 14)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioDemolizioneMassimale, 2, 14)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioGelo, 1, 15)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioGelo, 4, 15)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioGelo, 0, 15)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioGeloMassimale, 2, 15)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioGeloFranchigia, 3, 15)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioRicercaGuasto, 1, 16)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioRicercaGuasto, 4, 16)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioRicercaGuasto, 0, 16)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioRicercaGuastoMassimale, 2, 16)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioRicercaGuastoFranchigia, 3, 16)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioAcquaOcclusione, 1, 17)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioAcquaOcclusione, 4, 17)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioAcquaOcclusione, 0, 17)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioAcquaOcclusioneMassimale, 2, 17)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioAcquaOcclusioneFranchigia, 3, 17)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioPannelliSolari, 1, 18)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioPannelliSolari, 4, 18)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioPannelliSolari, 0, 18)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioPannelliSolariMassimale, 2, 18)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioRiduzioneFranchigiaFenomeniElettrici, 1, 19)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioRiduzioneFranchigiaFenomeniElettrici, 4, 19)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioRiduzioneFranchigiaFenomeniElettrici, 0, 19)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioEstensioneGaranziaBase, 1, 5)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioEstensioneGaranziaBase, 0, 5)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioEstensioneGaranziaBase, 4, 5)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioPannelliSolariEstensioneFenomenoElettrico, 1, 9)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioPannelliSolariEstensioneFenomenoElettrico, 0, 9)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioPannelliSolariEstensioneFenomenoElettrico, 4, 9)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioPannelliSolariEstensioneFenomenoAtmosferici, 1, 12)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioPannelliSolariEstensioneFenomenoAtmosferici, 0, 12)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioPannelliSolariEstensioneFenomenoAtmosferici, 4, 12)
            Me.TableLayoutPanel7.Controls.Add(Me.desIncendioPerditeOcculteAcqua, 1, 7)
            Me.TableLayoutPanel7.Controls.Add(Me.chkIncendioPerditeOcculteAcqua, 0, 7)
            Me.TableLayoutPanel7.Controls.Add(Me.lblIncendioPerditeOcculteAcqua, 4, 7)
            Me.TableLayoutPanel7.Controls.Add(Me.lblA7, 1, 0)
            Me.TableLayoutPanel7.Controls.Add(Me.lblB7, 2, 0)
            Me.TableLayoutPanel7.Controls.Add(Me.lblC7, 4, 0)
            Me.TableLayoutPanel7.Controls.Add(Me.lblD7, 0, 0)
            Me.TableLayoutPanel7.Controls.Add(Me.cmbIncendioPannelliSolariFranchigia, 3, 18)
            Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 13)
            Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
            Me.TableLayoutPanel7.RowCount = 21
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel7.Size = New System.Drawing.Size(1012, 588)
            Me.TableLayoutPanel7.TabIndex = 0
            '
            'cmbIncendioChiave
            '
            Me.cmbIncendioChiave.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioChiave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioChiave.FormattingEnabled = True
            Me.cmbIncendioChiave.Location = New System.Drawing.Point(398, 43)
            Me.cmbIncendioChiave.Name = "cmbIncendioChiave"
            Me.cmbIncendioChiave.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioChiave.TabIndex = 0
            '
            'cmbIncendioAbitazioneFormAss
            '
            Me.cmbIncendioAbitazioneFormAss.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioAbitazioneFormAss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioAbitazioneFormAss.FormattingEnabled = True
            Me.cmbIncendioAbitazioneFormAss.Location = New System.Drawing.Point(653, 68)
            Me.cmbIncendioAbitazioneFormAss.Name = "cmbIncendioAbitazioneFormAss"
            Me.cmbIncendioAbitazioneFormAss.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioAbitazioneFormAss.TabIndex = 1
            '
            'cmbIncendioContenutoFormAss
            '
            Me.cmbIncendioContenutoFormAss.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioContenutoFormAss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioContenutoFormAss.FormattingEnabled = True
            Me.cmbIncendioContenutoFormAss.Location = New System.Drawing.Point(653, 93)
            Me.cmbIncendioContenutoFormAss.Name = "cmbIncendioContenutoFormAss"
            Me.cmbIncendioContenutoFormAss.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioContenutoFormAss.TabIndex = 2
            '
            'cmbIncendioLocazioneFormAss
            '
            Me.cmbIncendioLocazioneFormAss.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioLocazioneFormAss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioLocazioneFormAss.FormattingEnabled = True
            Me.cmbIncendioLocazioneFormAss.Location = New System.Drawing.Point(653, 118)
            Me.cmbIncendioLocazioneFormAss.Name = "cmbIncendioLocazioneFormAss"
            Me.cmbIncendioLocazioneFormAss.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioLocazioneFormAss.TabIndex = 3
            '
            'lblIncendioPremio
            '
            Me.lblIncendioPremio.AutoSize = True
            Me.lblIncendioPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioPremio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblIncendioPremio.Location = New System.Drawing.Point(908, 40)
            Me.lblIncendioPremio.Name = "lblIncendioPremio"
            Me.lblIncendioPremio.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioPremio.TabIndex = 5
            Me.lblIncendioPremio.Text = "0,00"
            Me.lblIncendioPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioBase
            '
            Me.chkIncendioBase.AutoSize = True
            Me.TableLayoutPanel7.SetColumnSpan(Me.chkIncendioBase, 2)
            Me.chkIncendioBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioBase.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.chkIncendioBase.Location = New System.Drawing.Point(8, 40)
            Me.chkIncendioBase.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
            Me.chkIncendioBase.Name = "chkIncendioBase"
            Me.chkIncendioBase.Size = New System.Drawing.Size(387, 25)
            Me.chkIncendioBase.TabIndex = 8
            Me.chkIncendioBase.Text = "INCENDIO"
            Me.chkIncendioBase.UseVisualStyleBackColor = True
            '
            'desIncendioAbitazione
            '
            Me.desIncendioAbitazione.AutoSize = True
            Me.desIncendioAbitazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioAbitazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioAbitazione.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioAbitazione.Location = New System.Drawing.Point(58, 65)
            Me.desIncendioAbitazione.Name = "desIncendioAbitazione"
            Me.desIncendioAbitazione.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioAbitazione.TabIndex = 9
            Me.desIncendioAbitazione.Tag = "102"
            Me.desIncendioAbitazione.Text = "Abitazione"
            Me.desIncendioAbitazione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioAbitazione
            '
            Me.lblIncendioAbitazione.AutoSize = True
            Me.lblIncendioAbitazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioAbitazione.Location = New System.Drawing.Point(908, 65)
            Me.lblIncendioAbitazione.Name = "lblIncendioAbitazione"
            Me.lblIncendioAbitazione.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioAbitazione.TabIndex = 10
            Me.lblIncendioAbitazione.Text = "0,00"
            Me.lblIncendioAbitazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioAbitazione
            '
            Me.chkIncendioAbitazione.AutoSize = True
            Me.chkIncendioAbitazione.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioAbitazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioAbitazione.Location = New System.Drawing.Point(0, 65)
            Me.chkIncendioAbitazione.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioAbitazione.Name = "chkIncendioAbitazione"
            Me.chkIncendioAbitazione.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioAbitazione.TabIndex = 11
            Me.chkIncendioAbitazione.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioAbitazione
            '
            Me.txtPartitaIncendioAbitazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioAbitazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioAbitazione.Location = New System.Drawing.Point(398, 68)
            Me.txtPartitaIncendioAbitazione.Name = "txtPartitaIncendioAbitazione"
            Me.txtPartitaIncendioAbitazione.Size = New System.Drawing.Size(249, 22)
            Me.txtPartitaIncendioAbitazione.TabIndex = 12
            Me.txtPartitaIncendioAbitazione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desIncendioContenuto
            '
            Me.desIncendioContenuto.AutoSize = True
            Me.desIncendioContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioContenuto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioContenuto.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioContenuto.Location = New System.Drawing.Point(58, 90)
            Me.desIncendioContenuto.Name = "desIncendioContenuto"
            Me.desIncendioContenuto.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioContenuto.TabIndex = 13
            Me.desIncendioContenuto.Tag = "103"
            Me.desIncendioContenuto.Text = "Contenuto"
            Me.desIncendioContenuto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioContenuto
            '
            Me.lblIncendioContenuto.AutoSize = True
            Me.lblIncendioContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioContenuto.Location = New System.Drawing.Point(908, 90)
            Me.lblIncendioContenuto.Name = "lblIncendioContenuto"
            Me.lblIncendioContenuto.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioContenuto.TabIndex = 14
            Me.lblIncendioContenuto.Text = "0,00"
            Me.lblIncendioContenuto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioContenuto
            '
            Me.chkIncendioContenuto.AutoSize = True
            Me.chkIncendioContenuto.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioContenuto.Location = New System.Drawing.Point(0, 90)
            Me.chkIncendioContenuto.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioContenuto.Name = "chkIncendioContenuto"
            Me.chkIncendioContenuto.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioContenuto.TabIndex = 15
            Me.chkIncendioContenuto.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioContenuto
            '
            Me.txtPartitaIncendioContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioContenuto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioContenuto.Location = New System.Drawing.Point(398, 93)
            Me.txtPartitaIncendioContenuto.Name = "txtPartitaIncendioContenuto"
            Me.txtPartitaIncendioContenuto.Size = New System.Drawing.Size(249, 22)
            Me.txtPartitaIncendioContenuto.TabIndex = 16
            Me.txtPartitaIncendioContenuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desIncendioLocazione
            '
            Me.desIncendioLocazione.AutoSize = True
            Me.desIncendioLocazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioLocazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioLocazione.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioLocazione.Location = New System.Drawing.Point(58, 115)
            Me.desIncendioLocazione.Name = "desIncendioLocazione"
            Me.desIncendioLocazione.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioLocazione.TabIndex = 17
            Me.desIncendioLocazione.Tag = "104"
            Me.desIncendioLocazione.Text = "Rischio locativo"
            Me.desIncendioLocazione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioLocazione
            '
            Me.lblIncendioLocazione.AutoSize = True
            Me.lblIncendioLocazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioLocazione.Location = New System.Drawing.Point(908, 115)
            Me.lblIncendioLocazione.Name = "lblIncendioLocazione"
            Me.lblIncendioLocazione.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioLocazione.TabIndex = 18
            Me.lblIncendioLocazione.Text = "0,00"
            Me.lblIncendioLocazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioLocazione
            '
            Me.chkIncendioLocazione.AutoSize = True
            Me.chkIncendioLocazione.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioLocazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioLocazione.Location = New System.Drawing.Point(0, 115)
            Me.chkIncendioLocazione.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioLocazione.Name = "chkIncendioLocazione"
            Me.chkIncendioLocazione.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioLocazione.TabIndex = 19
            Me.chkIncendioLocazione.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioLocazione
            '
            Me.txtPartitaIncendioLocazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioLocazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioLocazione.Location = New System.Drawing.Point(398, 118)
            Me.txtPartitaIncendioLocazione.Name = "txtPartitaIncendioLocazione"
            Me.txtPartitaIncendioLocazione.Size = New System.Drawing.Size(249, 22)
            Me.txtPartitaIncendioLocazione.TabIndex = 20
            Me.txtPartitaIncendioLocazione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desIncendioCondutture
            '
            Me.desIncendioCondutture.AutoSize = True
            Me.desIncendioCondutture.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioCondutture.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioCondutture.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioCondutture.Location = New System.Drawing.Point(58, 165)
            Me.desIncendioCondutture.Name = "desIncendioCondutture"
            Me.desIncendioCondutture.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioCondutture.TabIndex = 21
            Me.desIncendioCondutture.Tag = "105"
            Me.desIncendioCondutture.Text = "Acqua condotta"
            Me.desIncendioCondutture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioCondutture
            '
            Me.lblIncendioCondutture.AutoSize = True
            Me.lblIncendioCondutture.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioCondutture.Location = New System.Drawing.Point(908, 165)
            Me.lblIncendioCondutture.Name = "lblIncendioCondutture"
            Me.lblIncendioCondutture.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioCondutture.TabIndex = 22
            Me.lblIncendioCondutture.Text = "0,00"
            Me.lblIncendioCondutture.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioCondutture
            '
            Me.chkIncendioCondutture.AutoSize = True
            Me.chkIncendioCondutture.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioCondutture.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioCondutture.Location = New System.Drawing.Point(0, 165)
            Me.chkIncendioCondutture.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioCondutture.Name = "chkIncendioCondutture"
            Me.chkIncendioCondutture.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioCondutture.TabIndex = 23
            Me.chkIncendioCondutture.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioFenomeniElettrici
            '
            Me.txtPartitaIncendioFenomeniElettrici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioFenomeniElettrici.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioFenomeniElettrici.Location = New System.Drawing.Point(398, 218)
            Me.txtPartitaIncendioFenomeniElettrici.Name = "txtPartitaIncendioFenomeniElettrici"
            Me.txtPartitaIncendioFenomeniElettrici.Size = New System.Drawing.Size(249, 22)
            Me.txtPartitaIncendioFenomeniElettrici.TabIndex = 24
            Me.txtPartitaIncendioFenomeniElettrici.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'cmbIncendioConduttureFranchigia
            '
            Me.cmbIncendioConduttureFranchigia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioConduttureFranchigia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioConduttureFranchigia.FormattingEnabled = True
            Me.cmbIncendioConduttureFranchigia.Location = New System.Drawing.Point(398, 168)
            Me.cmbIncendioConduttureFranchigia.Name = "cmbIncendioConduttureFranchigia"
            Me.cmbIncendioConduttureFranchigia.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioConduttureFranchigia.TabIndex = 25
            '
            'desIncendioFenomeniElettrici
            '
            Me.desIncendioFenomeniElettrici.AutoSize = True
            Me.desIncendioFenomeniElettrici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioFenomeniElettrici.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioFenomeniElettrici.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioFenomeniElettrici.Location = New System.Drawing.Point(58, 215)
            Me.desIncendioFenomeniElettrici.Name = "desIncendioFenomeniElettrici"
            Me.desIncendioFenomeniElettrici.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioFenomeniElettrici.TabIndex = 26
            Me.desIncendioFenomeniElettrici.Tag = "106"
            Me.desIncendioFenomeniElettrici.Text = "Fenomeni elettrici"
            Me.desIncendioFenomeniElettrici.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioFenomeniElettrici
            '
            Me.lblIncendioFenomeniElettrici.AutoSize = True
            Me.lblIncendioFenomeniElettrici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioFenomeniElettrici.Location = New System.Drawing.Point(908, 215)
            Me.lblIncendioFenomeniElettrici.Name = "lblIncendioFenomeniElettrici"
            Me.lblIncendioFenomeniElettrici.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioFenomeniElettrici.TabIndex = 27
            Me.lblIncendioFenomeniElettrici.Text = "0,00"
            Me.lblIncendioFenomeniElettrici.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioFenomeniElettrici
            '
            Me.chkIncendioFenomeniElettrici.AutoSize = True
            Me.chkIncendioFenomeniElettrici.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioFenomeniElettrici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioFenomeniElettrici.Location = New System.Drawing.Point(0, 215)
            Me.chkIncendioFenomeniElettrici.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioFenomeniElettrici.Name = "chkIncendioFenomeniElettrici"
            Me.chkIncendioFenomeniElettrici.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioFenomeniElettrici.TabIndex = 28
            Me.chkIncendioFenomeniElettrici.UseVisualStyleBackColor = True
            '
            'cmbIncendioFenomeniElettriciFranchigia
            '
            Me.cmbIncendioFenomeniElettriciFranchigia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioFenomeniElettriciFranchigia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioFenomeniElettriciFranchigia.FormattingEnabled = True
            Me.cmbIncendioFenomeniElettriciFranchigia.Location = New System.Drawing.Point(653, 218)
            Me.cmbIncendioFenomeniElettriciFranchigia.Name = "cmbIncendioFenomeniElettriciFranchigia"
            Me.cmbIncendioFenomeniElettriciFranchigia.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioFenomeniElettriciFranchigia.TabIndex = 29
            '
            'desIncendioFenomeniAtmosferici
            '
            Me.desIncendioFenomeniAtmosferici.AutoSize = True
            Me.desIncendioFenomeniAtmosferici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioFenomeniAtmosferici.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioFenomeniAtmosferici.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioFenomeniAtmosferici.Location = New System.Drawing.Point(58, 265)
            Me.desIncendioFenomeniAtmosferici.Name = "desIncendioFenomeniAtmosferici"
            Me.desIncendioFenomeniAtmosferici.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioFenomeniAtmosferici.TabIndex = 30
            Me.desIncendioFenomeniAtmosferici.Tag = "107"
            Me.desIncendioFenomeniAtmosferici.Text = "Fenomeni Atmosferici"
            Me.desIncendioFenomeniAtmosferici.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioFenomeniAtmosferici
            '
            Me.lblIncendioFenomeniAtmosferici.AutoSize = True
            Me.lblIncendioFenomeniAtmosferici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioFenomeniAtmosferici.Location = New System.Drawing.Point(908, 265)
            Me.lblIncendioFenomeniAtmosferici.Name = "lblIncendioFenomeniAtmosferici"
            Me.lblIncendioFenomeniAtmosferici.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioFenomeniAtmosferici.TabIndex = 31
            Me.lblIncendioFenomeniAtmosferici.Text = "0,00"
            Me.lblIncendioFenomeniAtmosferici.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioFenomeniAtmosferici
            '
            Me.chkIncendioFenomeniAtmosferici.AutoSize = True
            Me.chkIncendioFenomeniAtmosferici.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioFenomeniAtmosferici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioFenomeniAtmosferici.Location = New System.Drawing.Point(0, 265)
            Me.chkIncendioFenomeniAtmosferici.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioFenomeniAtmosferici.Name = "chkIncendioFenomeniAtmosferici"
            Me.chkIncendioFenomeniAtmosferici.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioFenomeniAtmosferici.TabIndex = 32
            Me.chkIncendioFenomeniAtmosferici.UseVisualStyleBackColor = True
            '
            'cmbIncendioFenomeniAtmosfericiLimite
            '
            Me.cmbIncendioFenomeniAtmosfericiLimite.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioFenomeniAtmosfericiLimite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioFenomeniAtmosfericiLimite.FormattingEnabled = True
            Me.cmbIncendioFenomeniAtmosfericiLimite.Location = New System.Drawing.Point(398, 268)
            Me.cmbIncendioFenomeniAtmosfericiLimite.Name = "cmbIncendioFenomeniAtmosfericiLimite"
            Me.cmbIncendioFenomeniAtmosfericiLimite.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioFenomeniAtmosfericiLimite.TabIndex = 33
            '
            'cmbIncendioFenomeniAtmosfericiCombinazione
            '
            Me.cmbIncendioFenomeniAtmosfericiCombinazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioFenomeniAtmosfericiCombinazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioFenomeniAtmosfericiCombinazione.FormattingEnabled = True
            Me.cmbIncendioFenomeniAtmosfericiCombinazione.Location = New System.Drawing.Point(653, 268)
            Me.cmbIncendioFenomeniAtmosfericiCombinazione.Name = "cmbIncendioFenomeniAtmosfericiCombinazione"
            Me.cmbIncendioFenomeniAtmosfericiCombinazione.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioFenomeniAtmosfericiCombinazione.TabIndex = 34
            '
            'desIncendioFenomeniAtmosfericiLarge
            '
            Me.desIncendioFenomeniAtmosfericiLarge.AutoSize = True
            Me.desIncendioFenomeniAtmosfericiLarge.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioFenomeniAtmosfericiLarge.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioFenomeniAtmosfericiLarge.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioFenomeniAtmosfericiLarge.Location = New System.Drawing.Point(58, 290)
            Me.desIncendioFenomeniAtmosfericiLarge.Name = "desIncendioFenomeniAtmosfericiLarge"
            Me.desIncendioFenomeniAtmosfericiLarge.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioFenomeniAtmosfericiLarge.TabIndex = 35
            Me.desIncendioFenomeniAtmosfericiLarge.Tag = "108"
            Me.desIncendioFenomeniAtmosfericiLarge.Text = "Fenomeni Atmosferici LARGE"
            Me.desIncendioFenomeniAtmosfericiLarge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioFenomeniAtmosfericiLarge
            '
            Me.lblIncendioFenomeniAtmosfericiLarge.AutoSize = True
            Me.lblIncendioFenomeniAtmosfericiLarge.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioFenomeniAtmosfericiLarge.Location = New System.Drawing.Point(908, 290)
            Me.lblIncendioFenomeniAtmosfericiLarge.Name = "lblIncendioFenomeniAtmosfericiLarge"
            Me.lblIncendioFenomeniAtmosfericiLarge.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioFenomeniAtmosfericiLarge.TabIndex = 36
            Me.lblIncendioFenomeniAtmosfericiLarge.Text = "0,00"
            Me.lblIncendioFenomeniAtmosfericiLarge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioFenomeniAtmosfericiLarge
            '
            Me.chkIncendioFenomeniAtmosfericiLarge.AutoSize = True
            Me.chkIncendioFenomeniAtmosfericiLarge.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioFenomeniAtmosfericiLarge.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioFenomeniAtmosfericiLarge.Location = New System.Drawing.Point(0, 290)
            Me.chkIncendioFenomeniAtmosfericiLarge.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioFenomeniAtmosfericiLarge.Name = "chkIncendioFenomeniAtmosfericiLarge"
            Me.chkIncendioFenomeniAtmosfericiLarge.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioFenomeniAtmosfericiLarge.TabIndex = 37
            Me.chkIncendioFenomeniAtmosfericiLarge.UseVisualStyleBackColor = True
            '
            'cmbIncendioFenomeniAtmosfericiLargeCombinazione
            '
            Me.cmbIncendioFenomeniAtmosfericiLargeCombinazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioFenomeniAtmosfericiLargeCombinazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioFenomeniAtmosfericiLargeCombinazione.FormattingEnabled = True
            Me.cmbIncendioFenomeniAtmosfericiLargeCombinazione.Location = New System.Drawing.Point(653, 293)
            Me.cmbIncendioFenomeniAtmosfericiLargeCombinazione.Name = "cmbIncendioFenomeniAtmosfericiLargeCombinazione"
            Me.cmbIncendioFenomeniAtmosfericiLargeCombinazione.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioFenomeniAtmosfericiLargeCombinazione.TabIndex = 38
            '
            'cmbIncendioFenomeniAtmosfericiLargeMassimale
            '
            Me.cmbIncendioFenomeniAtmosfericiLargeMassimale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioFenomeniAtmosfericiLargeMassimale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioFenomeniAtmosfericiLargeMassimale.FormattingEnabled = True
            Me.cmbIncendioFenomeniAtmosfericiLargeMassimale.Location = New System.Drawing.Point(398, 293)
            Me.cmbIncendioFenomeniAtmosfericiLargeMassimale.Name = "cmbIncendioFenomeniAtmosfericiLargeMassimale"
            Me.cmbIncendioFenomeniAtmosfericiLargeMassimale.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioFenomeniAtmosfericiLargeMassimale.TabIndex = 39
            '
            'desIncendioRicorsoTerzi
            '
            Me.desIncendioRicorsoTerzi.AutoSize = True
            Me.desIncendioRicorsoTerzi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioRicorsoTerzi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioRicorsoTerzi.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioRicorsoTerzi.Location = New System.Drawing.Point(58, 340)
            Me.desIncendioRicorsoTerzi.Name = "desIncendioRicorsoTerzi"
            Me.desIncendioRicorsoTerzi.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioRicorsoTerzi.TabIndex = 40
            Me.desIncendioRicorsoTerzi.Tag = "109"
            Me.desIncendioRicorsoTerzi.Text = "Ricorso terzi"
            Me.desIncendioRicorsoTerzi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioRicorsoTerzi
            '
            Me.lblIncendioRicorsoTerzi.AutoSize = True
            Me.lblIncendioRicorsoTerzi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioRicorsoTerzi.Location = New System.Drawing.Point(908, 340)
            Me.lblIncendioRicorsoTerzi.Name = "lblIncendioRicorsoTerzi"
            Me.lblIncendioRicorsoTerzi.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioRicorsoTerzi.TabIndex = 41
            Me.lblIncendioRicorsoTerzi.Text = "0,00"
            Me.lblIncendioRicorsoTerzi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioRicorsoTerzi
            '
            Me.chkIncendioRicorsoTerzi.AutoSize = True
            Me.chkIncendioRicorsoTerzi.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioRicorsoTerzi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioRicorsoTerzi.Location = New System.Drawing.Point(0, 340)
            Me.chkIncendioRicorsoTerzi.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioRicorsoTerzi.Name = "chkIncendioRicorsoTerzi"
            Me.chkIncendioRicorsoTerzi.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioRicorsoTerzi.TabIndex = 42
            Me.chkIncendioRicorsoTerzi.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioRicorsoTerzi
            '
            Me.txtPartitaIncendioRicorsoTerzi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioRicorsoTerzi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioRicorsoTerzi.Location = New System.Drawing.Point(398, 343)
            Me.txtPartitaIncendioRicorsoTerzi.Name = "txtPartitaIncendioRicorsoTerzi"
            Me.txtPartitaIncendioRicorsoTerzi.Size = New System.Drawing.Size(249, 22)
            Me.txtPartitaIncendioRicorsoTerzi.TabIndex = 43
            Me.txtPartitaIncendioRicorsoTerzi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desIncendioDemolizione
            '
            Me.desIncendioDemolizione.AutoSize = True
            Me.desIncendioDemolizione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioDemolizione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioDemolizione.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioDemolizione.Location = New System.Drawing.Point(58, 365)
            Me.desIncendioDemolizione.Name = "desIncendioDemolizione"
            Me.desIncendioDemolizione.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioDemolizione.TabIndex = 44
            Me.desIncendioDemolizione.Tag = "110"
            Me.desIncendioDemolizione.Text = "Spese di demolizione, sgombero, ..."
            Me.desIncendioDemolizione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioDemolizione
            '
            Me.lblIncendioDemolizione.AutoSize = True
            Me.lblIncendioDemolizione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioDemolizione.Location = New System.Drawing.Point(908, 365)
            Me.lblIncendioDemolizione.Name = "lblIncendioDemolizione"
            Me.lblIncendioDemolizione.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioDemolizione.TabIndex = 45
            Me.lblIncendioDemolizione.Text = "0,00"
            Me.lblIncendioDemolizione.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioDemolizione
            '
            Me.chkIncendioDemolizione.AutoSize = True
            Me.chkIncendioDemolizione.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioDemolizione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioDemolizione.Location = New System.Drawing.Point(0, 365)
            Me.chkIncendioDemolizione.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioDemolizione.Name = "chkIncendioDemolizione"
            Me.chkIncendioDemolizione.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioDemolizione.TabIndex = 46
            Me.chkIncendioDemolizione.UseVisualStyleBackColor = True
            '
            'cmbIncendioDemolizioneMassimale
            '
            Me.cmbIncendioDemolizioneMassimale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioDemolizioneMassimale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioDemolizioneMassimale.FormattingEnabled = True
            Me.cmbIncendioDemolizioneMassimale.Location = New System.Drawing.Point(398, 368)
            Me.cmbIncendioDemolizioneMassimale.Name = "cmbIncendioDemolizioneMassimale"
            Me.cmbIncendioDemolizioneMassimale.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioDemolizioneMassimale.TabIndex = 47
            '
            'desIncendioGelo
            '
            Me.desIncendioGelo.AutoSize = True
            Me.desIncendioGelo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioGelo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioGelo.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioGelo.Location = New System.Drawing.Point(58, 390)
            Me.desIncendioGelo.Name = "desIncendioGelo"
            Me.desIncendioGelo.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioGelo.TabIndex = 48
            Me.desIncendioGelo.Tag = "111"
            Me.desIncendioGelo.Text = "Gelo"
            Me.desIncendioGelo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioGelo
            '
            Me.lblIncendioGelo.AutoSize = True
            Me.lblIncendioGelo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioGelo.Location = New System.Drawing.Point(908, 390)
            Me.lblIncendioGelo.Name = "lblIncendioGelo"
            Me.lblIncendioGelo.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioGelo.TabIndex = 49
            Me.lblIncendioGelo.Text = "0,00"
            Me.lblIncendioGelo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioGelo
            '
            Me.chkIncendioGelo.AutoSize = True
            Me.chkIncendioGelo.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioGelo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioGelo.Location = New System.Drawing.Point(0, 390)
            Me.chkIncendioGelo.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioGelo.Name = "chkIncendioGelo"
            Me.chkIncendioGelo.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioGelo.TabIndex = 50
            Me.chkIncendioGelo.UseVisualStyleBackColor = True
            '
            'cmbIncendioGeloMassimale
            '
            Me.cmbIncendioGeloMassimale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioGeloMassimale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioGeloMassimale.FormattingEnabled = True
            Me.cmbIncendioGeloMassimale.Location = New System.Drawing.Point(398, 393)
            Me.cmbIncendioGeloMassimale.Name = "cmbIncendioGeloMassimale"
            Me.cmbIncendioGeloMassimale.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioGeloMassimale.TabIndex = 51
            '
            'cmbIncendioGeloFranchigia
            '
            Me.cmbIncendioGeloFranchigia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioGeloFranchigia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioGeloFranchigia.FormattingEnabled = True
            Me.cmbIncendioGeloFranchigia.Location = New System.Drawing.Point(653, 393)
            Me.cmbIncendioGeloFranchigia.Name = "cmbIncendioGeloFranchigia"
            Me.cmbIncendioGeloFranchigia.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioGeloFranchigia.TabIndex = 52
            '
            'desIncendioRicercaGuasto
            '
            Me.desIncendioRicercaGuasto.AutoSize = True
            Me.desIncendioRicercaGuasto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioRicercaGuasto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioRicercaGuasto.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioRicercaGuasto.Location = New System.Drawing.Point(58, 415)
            Me.desIncendioRicercaGuasto.Name = "desIncendioRicercaGuasto"
            Me.desIncendioRicercaGuasto.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioRicercaGuasto.TabIndex = 53
            Me.desIncendioRicercaGuasto.Tag = "112"
            Me.desIncendioRicercaGuasto.Text = "Ricerca Guasto"
            Me.desIncendioRicercaGuasto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioRicercaGuasto
            '
            Me.lblIncendioRicercaGuasto.AutoSize = True
            Me.lblIncendioRicercaGuasto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioRicercaGuasto.Location = New System.Drawing.Point(908, 415)
            Me.lblIncendioRicercaGuasto.Name = "lblIncendioRicercaGuasto"
            Me.lblIncendioRicercaGuasto.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioRicercaGuasto.TabIndex = 54
            Me.lblIncendioRicercaGuasto.Text = "0,00"
            Me.lblIncendioRicercaGuasto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioRicercaGuasto
            '
            Me.chkIncendioRicercaGuasto.AutoSize = True
            Me.chkIncendioRicercaGuasto.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioRicercaGuasto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioRicercaGuasto.Location = New System.Drawing.Point(0, 415)
            Me.chkIncendioRicercaGuasto.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioRicercaGuasto.Name = "chkIncendioRicercaGuasto"
            Me.chkIncendioRicercaGuasto.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioRicercaGuasto.TabIndex = 55
            Me.chkIncendioRicercaGuasto.UseVisualStyleBackColor = True
            '
            'cmbIncendioRicercaGuastoMassimale
            '
            Me.cmbIncendioRicercaGuastoMassimale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioRicercaGuastoMassimale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioRicercaGuastoMassimale.FormattingEnabled = True
            Me.cmbIncendioRicercaGuastoMassimale.Location = New System.Drawing.Point(398, 418)
            Me.cmbIncendioRicercaGuastoMassimale.Name = "cmbIncendioRicercaGuastoMassimale"
            Me.cmbIncendioRicercaGuastoMassimale.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioRicercaGuastoMassimale.TabIndex = 56
            '
            'cmbIncendioRicercaGuastoFranchigia
            '
            Me.cmbIncendioRicercaGuastoFranchigia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioRicercaGuastoFranchigia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioRicercaGuastoFranchigia.FormattingEnabled = True
            Me.cmbIncendioRicercaGuastoFranchigia.Location = New System.Drawing.Point(653, 418)
            Me.cmbIncendioRicercaGuastoFranchigia.Name = "cmbIncendioRicercaGuastoFranchigia"
            Me.cmbIncendioRicercaGuastoFranchigia.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioRicercaGuastoFranchigia.TabIndex = 57
            '
            'desIncendioAcquaOcclusione
            '
            Me.desIncendioAcquaOcclusione.AutoSize = True
            Me.desIncendioAcquaOcclusione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioAcquaOcclusione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioAcquaOcclusione.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioAcquaOcclusione.Location = New System.Drawing.Point(58, 440)
            Me.desIncendioAcquaOcclusione.Name = "desIncendioAcquaOcclusione"
            Me.desIncendioAcquaOcclusione.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioAcquaOcclusione.TabIndex = 58
            Me.desIncendioAcquaOcclusione.Tag = "113"
            Me.desIncendioAcquaOcclusione.Text = "Acqua piovana, occlusione"
            Me.desIncendioAcquaOcclusione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioAcquaOcclusione
            '
            Me.lblIncendioAcquaOcclusione.AutoSize = True
            Me.lblIncendioAcquaOcclusione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioAcquaOcclusione.Location = New System.Drawing.Point(908, 440)
            Me.lblIncendioAcquaOcclusione.Name = "lblIncendioAcquaOcclusione"
            Me.lblIncendioAcquaOcclusione.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioAcquaOcclusione.TabIndex = 59
            Me.lblIncendioAcquaOcclusione.Text = "0,00"
            Me.lblIncendioAcquaOcclusione.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioAcquaOcclusione
            '
            Me.chkIncendioAcquaOcclusione.AutoSize = True
            Me.chkIncendioAcquaOcclusione.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioAcquaOcclusione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioAcquaOcclusione.Location = New System.Drawing.Point(0, 440)
            Me.chkIncendioAcquaOcclusione.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioAcquaOcclusione.Name = "chkIncendioAcquaOcclusione"
            Me.chkIncendioAcquaOcclusione.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioAcquaOcclusione.TabIndex = 60
            Me.chkIncendioAcquaOcclusione.UseVisualStyleBackColor = True
            '
            'cmbIncendioAcquaOcclusioneMassimale
            '
            Me.cmbIncendioAcquaOcclusioneMassimale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioAcquaOcclusioneMassimale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioAcquaOcclusioneMassimale.FormattingEnabled = True
            Me.cmbIncendioAcquaOcclusioneMassimale.Location = New System.Drawing.Point(398, 443)
            Me.cmbIncendioAcquaOcclusioneMassimale.Name = "cmbIncendioAcquaOcclusioneMassimale"
            Me.cmbIncendioAcquaOcclusioneMassimale.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioAcquaOcclusioneMassimale.TabIndex = 61
            '
            'cmbIncendioAcquaOcclusioneFranchigia
            '
            Me.cmbIncendioAcquaOcclusioneFranchigia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioAcquaOcclusioneFranchigia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioAcquaOcclusioneFranchigia.FormattingEnabled = True
            Me.cmbIncendioAcquaOcclusioneFranchigia.Location = New System.Drawing.Point(653, 443)
            Me.cmbIncendioAcquaOcclusioneFranchigia.Name = "cmbIncendioAcquaOcclusioneFranchigia"
            Me.cmbIncendioAcquaOcclusioneFranchigia.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioAcquaOcclusioneFranchigia.TabIndex = 62
            '
            'desIncendioPannelliSolari
            '
            Me.desIncendioPannelliSolari.AutoSize = True
            Me.desIncendioPannelliSolari.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioPannelliSolari.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioPannelliSolari.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioPannelliSolari.Location = New System.Drawing.Point(58, 465)
            Me.desIncendioPannelliSolari.Name = "desIncendioPannelliSolari"
            Me.desIncendioPannelliSolari.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioPannelliSolari.TabIndex = 63
            Me.desIncendioPannelliSolari.Tag = "114"
            Me.desIncendioPannelliSolari.Text = "Pannelli fotovoltaici"
            Me.desIncendioPannelliSolari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioPannelliSolari
            '
            Me.lblIncendioPannelliSolari.AutoSize = True
            Me.lblIncendioPannelliSolari.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioPannelliSolari.Location = New System.Drawing.Point(908, 465)
            Me.lblIncendioPannelliSolari.Name = "lblIncendioPannelliSolari"
            Me.lblIncendioPannelliSolari.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioPannelliSolari.TabIndex = 64
            Me.lblIncendioPannelliSolari.Text = "0,00"
            Me.lblIncendioPannelliSolari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioPannelliSolari
            '
            Me.chkIncendioPannelliSolari.AutoSize = True
            Me.chkIncendioPannelliSolari.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioPannelliSolari.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioPannelliSolari.Location = New System.Drawing.Point(0, 465)
            Me.chkIncendioPannelliSolari.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioPannelliSolari.Name = "chkIncendioPannelliSolari"
            Me.chkIncendioPannelliSolari.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioPannelliSolari.TabIndex = 65
            Me.chkIncendioPannelliSolari.UseVisualStyleBackColor = True
            '
            'cmbIncendioPannelliSolariMassimale
            '
            Me.cmbIncendioPannelliSolariMassimale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioPannelliSolariMassimale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioPannelliSolariMassimale.FormattingEnabled = True
            Me.cmbIncendioPannelliSolariMassimale.Location = New System.Drawing.Point(398, 468)
            Me.cmbIncendioPannelliSolariMassimale.Name = "cmbIncendioPannelliSolariMassimale"
            Me.cmbIncendioPannelliSolariMassimale.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioPannelliSolariMassimale.TabIndex = 67
            '
            'desIncendioRiduzioneFranchigiaFenomeniElettrici
            '
            Me.desIncendioRiduzioneFranchigiaFenomeniElettrici.AutoSize = True
            Me.desIncendioRiduzioneFranchigiaFenomeniElettrici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioRiduzioneFranchigiaFenomeniElettrici.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioRiduzioneFranchigiaFenomeniElettrici.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioRiduzioneFranchigiaFenomeniElettrici.Location = New System.Drawing.Point(58, 490)
            Me.desIncendioRiduzioneFranchigiaFenomeniElettrici.Name = "desIncendioRiduzioneFranchigiaFenomeniElettrici"
            Me.desIncendioRiduzioneFranchigiaFenomeniElettrici.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioRiduzioneFranchigiaFenomeniElettrici.TabIndex = 68
            Me.desIncendioRiduzioneFranchigiaFenomeniElettrici.Tag = "115"
            Me.desIncendioRiduzioneFranchigiaFenomeniElettrici.Text = "Riduzione Franchigia Fenomeni Elettrici"
            Me.desIncendioRiduzioneFranchigiaFenomeniElettrici.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioRiduzioneFranchigiaFenomeniElettrici
            '
            Me.lblIncendioRiduzioneFranchigiaFenomeniElettrici.AutoSize = True
            Me.lblIncendioRiduzioneFranchigiaFenomeniElettrici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioRiduzioneFranchigiaFenomeniElettrici.Location = New System.Drawing.Point(908, 490)
            Me.lblIncendioRiduzioneFranchigiaFenomeniElettrici.Name = "lblIncendioRiduzioneFranchigiaFenomeniElettrici"
            Me.lblIncendioRiduzioneFranchigiaFenomeniElettrici.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioRiduzioneFranchigiaFenomeniElettrici.TabIndex = 69
            Me.lblIncendioRiduzioneFranchigiaFenomeniElettrici.Text = "0,00"
            Me.lblIncendioRiduzioneFranchigiaFenomeniElettrici.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioRiduzioneFranchigiaFenomeniElettrici
            '
            Me.chkIncendioRiduzioneFranchigiaFenomeniElettrici.AutoSize = True
            Me.chkIncendioRiduzioneFranchigiaFenomeniElettrici.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioRiduzioneFranchigiaFenomeniElettrici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioRiduzioneFranchigiaFenomeniElettrici.Location = New System.Drawing.Point(0, 490)
            Me.chkIncendioRiduzioneFranchigiaFenomeniElettrici.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioRiduzioneFranchigiaFenomeniElettrici.Name = "chkIncendioRiduzioneFranchigiaFenomeniElettrici"
            Me.chkIncendioRiduzioneFranchigiaFenomeniElettrici.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioRiduzioneFranchigiaFenomeniElettrici.TabIndex = 70
            Me.chkIncendioRiduzioneFranchigiaFenomeniElettrici.UseVisualStyleBackColor = True
            '
            'desIncendioEstensioneGaranziaBase
            '
            Me.desIncendioEstensioneGaranziaBase.AutoSize = True
            Me.desIncendioEstensioneGaranziaBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioEstensioneGaranziaBase.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioEstensioneGaranziaBase.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioEstensioneGaranziaBase.Location = New System.Drawing.Point(58, 140)
            Me.desIncendioEstensioneGaranziaBase.Name = "desIncendioEstensioneGaranziaBase"
            Me.desIncendioEstensioneGaranziaBase.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioEstensioneGaranziaBase.TabIndex = 0
            Me.desIncendioEstensioneGaranziaBase.Tag = "116"
            Me.desIncendioEstensioneGaranziaBase.Text = "Estensione Garanzia Base Incendio"
            Me.desIncendioEstensioneGaranziaBase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'chkIncendioEstensioneGaranziaBase
            '
            Me.chkIncendioEstensioneGaranziaBase.AutoSize = True
            Me.chkIncendioEstensioneGaranziaBase.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioEstensioneGaranziaBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioEstensioneGaranziaBase.Location = New System.Drawing.Point(0, 140)
            Me.chkIncendioEstensioneGaranziaBase.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioEstensioneGaranziaBase.Name = "chkIncendioEstensioneGaranziaBase"
            Me.chkIncendioEstensioneGaranziaBase.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioEstensioneGaranziaBase.TabIndex = 0
            Me.chkIncendioEstensioneGaranziaBase.UseVisualStyleBackColor = True
            '
            'lblIncendioEstensioneGaranziaBase
            '
            Me.lblIncendioEstensioneGaranziaBase.AutoSize = True
            Me.lblIncendioEstensioneGaranziaBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioEstensioneGaranziaBase.Location = New System.Drawing.Point(908, 140)
            Me.lblIncendioEstensioneGaranziaBase.Name = "lblIncendioEstensioneGaranziaBase"
            Me.lblIncendioEstensioneGaranziaBase.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioEstensioneGaranziaBase.TabIndex = 0
            Me.lblIncendioEstensioneGaranziaBase.Text = "0,00"
            Me.lblIncendioEstensioneGaranziaBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'desIncendioPannelliSolariEstensioneFenomenoElettrico
            '
            Me.desIncendioPannelliSolariEstensioneFenomenoElettrico.AutoSize = True
            Me.desIncendioPannelliSolariEstensioneFenomenoElettrico.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioPannelliSolariEstensioneFenomenoElettrico.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioPannelliSolariEstensioneFenomenoElettrico.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioPannelliSolariEstensioneFenomenoElettrico.Location = New System.Drawing.Point(58, 240)
            Me.desIncendioPannelliSolariEstensioneFenomenoElettrico.Name = "desIncendioPannelliSolariEstensioneFenomenoElettrico"
            Me.desIncendioPannelliSolariEstensioneFenomenoElettrico.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioPannelliSolariEstensioneFenomenoElettrico.TabIndex = 0
            Me.desIncendioPannelliSolariEstensioneFenomenoElettrico.Tag = "117"
            Me.desIncendioPannelliSolariEstensioneFenomenoElettrico.Text = "Fenomeni elettrici su pannelli solari e fotovoltaici"
            Me.desIncendioPannelliSolariEstensioneFenomenoElettrico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'chkIncendioPannelliSolariEstensioneFenomenoElettrico
            '
            Me.chkIncendioPannelliSolariEstensioneFenomenoElettrico.AutoSize = True
            Me.chkIncendioPannelliSolariEstensioneFenomenoElettrico.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioPannelliSolariEstensioneFenomenoElettrico.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioPannelliSolariEstensioneFenomenoElettrico.Location = New System.Drawing.Point(0, 240)
            Me.chkIncendioPannelliSolariEstensioneFenomenoElettrico.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioPannelliSolariEstensioneFenomenoElettrico.Name = "chkIncendioPannelliSolariEstensioneFenomenoElettrico"
            Me.chkIncendioPannelliSolariEstensioneFenomenoElettrico.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioPannelliSolariEstensioneFenomenoElettrico.TabIndex = 0
            Me.chkIncendioPannelliSolariEstensioneFenomenoElettrico.UseVisualStyleBackColor = True
            '
            'lblIncendioPannelliSolariEstensioneFenomenoElettrico
            '
            Me.lblIncendioPannelliSolariEstensioneFenomenoElettrico.AutoSize = True
            Me.lblIncendioPannelliSolariEstensioneFenomenoElettrico.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioPannelliSolariEstensioneFenomenoElettrico.Location = New System.Drawing.Point(908, 240)
            Me.lblIncendioPannelliSolariEstensioneFenomenoElettrico.Name = "lblIncendioPannelliSolariEstensioneFenomenoElettrico"
            Me.lblIncendioPannelliSolariEstensioneFenomenoElettrico.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioPannelliSolariEstensioneFenomenoElettrico.TabIndex = 0
            Me.lblIncendioPannelliSolariEstensioneFenomenoElettrico.Text = "0,00"
            Me.lblIncendioPannelliSolariEstensioneFenomenoElettrico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'desIncendioPannelliSolariEstensioneFenomenoAtmosferici
            '
            Me.desIncendioPannelliSolariEstensioneFenomenoAtmosferici.AutoSize = True
            Me.desIncendioPannelliSolariEstensioneFenomenoAtmosferici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioPannelliSolariEstensioneFenomenoAtmosferici.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioPannelliSolariEstensioneFenomenoAtmosferici.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioPannelliSolariEstensioneFenomenoAtmosferici.Location = New System.Drawing.Point(58, 315)
            Me.desIncendioPannelliSolariEstensioneFenomenoAtmosferici.Name = "desIncendioPannelliSolariEstensioneFenomenoAtmosferici"
            Me.desIncendioPannelliSolariEstensioneFenomenoAtmosferici.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioPannelliSolariEstensioneFenomenoAtmosferici.TabIndex = 0
            Me.desIncendioPannelliSolariEstensioneFenomenoAtmosferici.Tag = "118"
            Me.desIncendioPannelliSolariEstensioneFenomenoAtmosferici.Text = "Fenomeni atmosferici su pannelli solari e fotovoltaici"
            Me.desIncendioPannelliSolariEstensioneFenomenoAtmosferici.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'chkIncendioPannelliSolariEstensioneFenomenoAtmosferici
            '
            Me.chkIncendioPannelliSolariEstensioneFenomenoAtmosferici.AutoSize = True
            Me.chkIncendioPannelliSolariEstensioneFenomenoAtmosferici.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioPannelliSolariEstensioneFenomenoAtmosferici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioPannelliSolariEstensioneFenomenoAtmosferici.Location = New System.Drawing.Point(0, 315)
            Me.chkIncendioPannelliSolariEstensioneFenomenoAtmosferici.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioPannelliSolariEstensioneFenomenoAtmosferici.Name = "chkIncendioPannelliSolariEstensioneFenomenoAtmosferici"
            Me.chkIncendioPannelliSolariEstensioneFenomenoAtmosferici.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioPannelliSolariEstensioneFenomenoAtmosferici.TabIndex = 0
            Me.chkIncendioPannelliSolariEstensioneFenomenoAtmosferici.UseVisualStyleBackColor = True
            '
            'lblIncendioPannelliSolariEstensioneFenomenoAtmosferici
            '
            Me.lblIncendioPannelliSolariEstensioneFenomenoAtmosferici.AutoSize = True
            Me.lblIncendioPannelliSolariEstensioneFenomenoAtmosferici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioPannelliSolariEstensioneFenomenoAtmosferici.Location = New System.Drawing.Point(908, 315)
            Me.lblIncendioPannelliSolariEstensioneFenomenoAtmosferici.Name = "lblIncendioPannelliSolariEstensioneFenomenoAtmosferici"
            Me.lblIncendioPannelliSolariEstensioneFenomenoAtmosferici.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioPannelliSolariEstensioneFenomenoAtmosferici.TabIndex = 0
            Me.lblIncendioPannelliSolariEstensioneFenomenoAtmosferici.Text = "0,00"
            Me.lblIncendioPannelliSolariEstensioneFenomenoAtmosferici.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'desIncendioPerditeOcculteAcqua
            '
            Me.desIncendioPerditeOcculteAcqua.AutoSize = True
            Me.desIncendioPerditeOcculteAcqua.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioPerditeOcculteAcqua.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioPerditeOcculteAcqua.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioPerditeOcculteAcqua.Location = New System.Drawing.Point(58, 190)
            Me.desIncendioPerditeOcculteAcqua.Name = "desIncendioPerditeOcculteAcqua"
            Me.desIncendioPerditeOcculteAcqua.Size = New System.Drawing.Size(334, 25)
            Me.desIncendioPerditeOcculteAcqua.TabIndex = 0
            Me.desIncendioPerditeOcculteAcqua.Tag = "119"
            Me.desIncendioPerditeOcculteAcqua.Text = "Perdite occulte d’acqua"
            Me.desIncendioPerditeOcculteAcqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'chkIncendioPerditeOcculteAcqua
            '
            Me.chkIncendioPerditeOcculteAcqua.AutoSize = True
            Me.chkIncendioPerditeOcculteAcqua.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioPerditeOcculteAcqua.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioPerditeOcculteAcqua.Location = New System.Drawing.Point(0, 190)
            Me.chkIncendioPerditeOcculteAcqua.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioPerditeOcculteAcqua.Name = "chkIncendioPerditeOcculteAcqua"
            Me.chkIncendioPerditeOcculteAcqua.Size = New System.Drawing.Size(55, 25)
            Me.chkIncendioPerditeOcculteAcqua.TabIndex = 0
            Me.chkIncendioPerditeOcculteAcqua.UseVisualStyleBackColor = True
            '
            'lblIncendioPerditeOcculteAcqua
            '
            Me.lblIncendioPerditeOcculteAcqua.AutoSize = True
            Me.lblIncendioPerditeOcculteAcqua.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioPerditeOcculteAcqua.Location = New System.Drawing.Point(908, 190)
            Me.lblIncendioPerditeOcculteAcqua.Name = "lblIncendioPerditeOcculteAcqua"
            Me.lblIncendioPerditeOcculteAcqua.Size = New System.Drawing.Size(101, 25)
            Me.lblIncendioPerditeOcculteAcqua.TabIndex = 0
            Me.lblIncendioPerditeOcculteAcqua.Text = "0,00"
            Me.lblIncendioPerditeOcculteAcqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblA7
            '
            Me.lblA7.AutoSize = True
            Me.lblA7.BackColor = System.Drawing.Color.Khaki
            Me.lblA7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblA7.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblA7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblA7.Location = New System.Drawing.Point(58, 0)
            Me.lblA7.Name = "lblA7"
            Me.lblA7.Size = New System.Drawing.Size(334, 40)
            Me.lblA7.TabIndex = 71
            Me.lblA7.Text = "Partita / Garanzia"
            Me.lblA7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblB7
            '
            Me.lblB7.AutoSize = True
            Me.lblB7.BackColor = System.Drawing.Color.Khaki
            Me.lblB7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.TableLayoutPanel7.SetColumnSpan(Me.lblB7, 2)
            Me.lblB7.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblB7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblB7.Location = New System.Drawing.Point(398, 0)
            Me.lblB7.Name = "lblB7"
            Me.lblB7.Size = New System.Drawing.Size(504, 40)
            Me.lblB7.TabIndex = 72
            Me.lblB7.Text = "Parametri/Condizioni"
            Me.lblB7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblC7
            '
            Me.lblC7.AutoSize = True
            Me.lblC7.BackColor = System.Drawing.Color.Khaki
            Me.lblC7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblC7.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblC7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblC7.Location = New System.Drawing.Point(908, 0)
            Me.lblC7.Name = "lblC7"
            Me.lblC7.Size = New System.Drawing.Size(101, 40)
            Me.lblC7.TabIndex = 73
            Me.lblC7.Text = "Premio"
            Me.lblC7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblD7
            '
            Me.lblD7.AutoSize = True
            Me.lblD7.BackColor = System.Drawing.Color.Khaki
            Me.lblD7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblD7.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblD7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblD7.Location = New System.Drawing.Point(3, 0)
            Me.lblD7.Name = "lblD7"
            Me.lblD7.Size = New System.Drawing.Size(49, 40)
            Me.lblD7.TabIndex = 74
            Me.lblD7.Text = "Scelto"
            Me.lblD7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cmbIncendioPannelliSolariFranchigia
            '
            Me.cmbIncendioPannelliSolariFranchigia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioPannelliSolariFranchigia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioPannelliSolariFranchigia.FormattingEnabled = True
            Me.cmbIncendioPannelliSolariFranchigia.Location = New System.Drawing.Point(653, 468)
            Me.cmbIncendioPannelliSolariFranchigia.Name = "cmbIncendioPannelliSolariFranchigia"
            Me.cmbIncendioPannelliSolariFranchigia.Size = New System.Drawing.Size(249, 21)
            Me.cmbIncendioPannelliSolariFranchigia.TabIndex = 67
            '
            'TabPage8
            '
            Me.TabPage8.Controls.Add(Me.GroupBox8)
            Me.TabPage8.Location = New System.Drawing.Point(4, 29)
            Me.TabPage8.Name = "TabPage8"
            Me.TabPage8.Size = New System.Drawing.Size(1018, 604)
            Me.TabPage8.TabIndex = 2
            Me.TabPage8.Tag = ""
            Me.TabPage8.Text = "Terremoto"
            Me.TabPage8.UseVisualStyleBackColor = True
            '
            'GroupBox8
            '
            Me.GroupBox8.Controls.Add(Me.TableLayoutPanel8)
            Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox8.Location = New System.Drawing.Point(0, 0)
            Me.GroupBox8.Margin = New System.Windows.Forms.Padding(0)
            Me.GroupBox8.Name = "GroupBox8"
            Me.GroupBox8.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
            Me.GroupBox8.Size = New System.Drawing.Size(1018, 604)
            Me.GroupBox8.TabIndex = 0
            Me.GroupBox8.TabStop = False
            '
            'TableLayoutPanel8
            '
            Me.TableLayoutPanel8.ColumnCount = 5
            Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
            Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
            Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
            Me.TableLayoutPanel8.Controls.Add(Me.lblTerremotoPremio, 4, 1)
            Me.TableLayoutPanel8.Controls.Add(Me.chkTerremotoBase, 0, 1)
            Me.TableLayoutPanel8.Controls.Add(Me.desTerremotoFabbricato, 1, 2)
            Me.TableLayoutPanel8.Controls.Add(Me.lblTerremotoFabbricato, 4, 2)
            Me.TableLayoutPanel8.Controls.Add(Me.chkTerremotoFabbricato, 0, 2)
            Me.TableLayoutPanel8.Controls.Add(Me.cmbTerremotoFabbricatoLimite, 2, 2)
            Me.TableLayoutPanel8.Controls.Add(Me.desTerremotoContenuto, 1, 3)
            Me.TableLayoutPanel8.Controls.Add(Me.lblTerremotoContenuto, 4, 3)
            Me.TableLayoutPanel8.Controls.Add(Me.chkTerremotoContenuto, 0, 3)
            Me.TableLayoutPanel8.Controls.Add(Me.lblA8, 1, 0)
            Me.TableLayoutPanel8.Controls.Add(Me.lblB8, 2, 0)
            Me.TableLayoutPanel8.Controls.Add(Me.lblC8, 4, 0)
            Me.TableLayoutPanel8.Controls.Add(Me.lblD8, 0, 0)
            Me.TableLayoutPanel8.Controls.Add(Me.Label2, 2, 1)
            Me.TableLayoutPanel8.Controls.Add(Me.Label3, 2, 4)
            Me.TableLayoutPanel8.Controls.Add(Me.cmbTerremotoContenutoFormAss, 2, 3)
            Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 13)
            Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
            Me.TableLayoutPanel8.RowCount = 28
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.Size = New System.Drawing.Size(1012, 588)
            Me.TableLayoutPanel8.TabIndex = 0
            '
            'lblTerremotoPremio
            '
            Me.lblTerremotoPremio.AutoSize = True
            Me.lblTerremotoPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTerremotoPremio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTerremotoPremio.Location = New System.Drawing.Point(908, 40)
            Me.lblTerremotoPremio.Name = "lblTerremotoPremio"
            Me.lblTerremotoPremio.Size = New System.Drawing.Size(101, 25)
            Me.lblTerremotoPremio.TabIndex = 3
            Me.lblTerremotoPremio.Text = "0,00"
            Me.lblTerremotoPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkTerremotoBase
            '
            Me.chkTerremotoBase.AutoSize = True
            Me.TableLayoutPanel8.SetColumnSpan(Me.chkTerremotoBase, 2)
            Me.chkTerremotoBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkTerremotoBase.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.chkTerremotoBase.Location = New System.Drawing.Point(8, 40)
            Me.chkTerremotoBase.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
            Me.chkTerremotoBase.Name = "chkTerremotoBase"
            Me.chkTerremotoBase.Size = New System.Drawing.Size(387, 25)
            Me.chkTerremotoBase.TabIndex = 6
            Me.chkTerremotoBase.Text = "TERREMOTO"
            Me.chkTerremotoBase.UseVisualStyleBackColor = True
            '
            'desTerremotoFabbricato
            '
            Me.desTerremotoFabbricato.AutoSize = True
            Me.desTerremotoFabbricato.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desTerremotoFabbricato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desTerremotoFabbricato.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desTerremotoFabbricato.Location = New System.Drawing.Point(58, 65)
            Me.desTerremotoFabbricato.Name = "desTerremotoFabbricato"
            Me.desTerremotoFabbricato.Size = New System.Drawing.Size(334, 25)
            Me.desTerremotoFabbricato.TabIndex = 7
            Me.desTerremotoFabbricato.Tag = "217"
            Me.desTerremotoFabbricato.Text = "Terremoto fabbricato"
            Me.desTerremotoFabbricato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblTerremotoFabbricato
            '
            Me.lblTerremotoFabbricato.AutoSize = True
            Me.lblTerremotoFabbricato.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTerremotoFabbricato.Location = New System.Drawing.Point(908, 65)
            Me.lblTerremotoFabbricato.Name = "lblTerremotoFabbricato"
            Me.lblTerremotoFabbricato.Size = New System.Drawing.Size(101, 25)
            Me.lblTerremotoFabbricato.TabIndex = 8
            Me.lblTerremotoFabbricato.Text = "0,00"
            Me.lblTerremotoFabbricato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkTerremotoFabbricato
            '
            Me.chkTerremotoFabbricato.AutoSize = True
            Me.chkTerremotoFabbricato.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkTerremotoFabbricato.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkTerremotoFabbricato.Location = New System.Drawing.Point(0, 65)
            Me.chkTerremotoFabbricato.Margin = New System.Windows.Forms.Padding(0)
            Me.chkTerremotoFabbricato.Name = "chkTerremotoFabbricato"
            Me.chkTerremotoFabbricato.Size = New System.Drawing.Size(55, 25)
            Me.chkTerremotoFabbricato.TabIndex = 9
            Me.chkTerremotoFabbricato.UseVisualStyleBackColor = True
            '
            'cmbTerremotoFabbricatoLimite
            '
            Me.cmbTerremotoFabbricatoLimite.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbTerremotoFabbricatoLimite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTerremotoFabbricatoLimite.FormattingEnabled = True
            Me.cmbTerremotoFabbricatoLimite.Location = New System.Drawing.Point(398, 68)
            Me.cmbTerremotoFabbricatoLimite.Name = "cmbTerremotoFabbricatoLimite"
            Me.cmbTerremotoFabbricatoLimite.Size = New System.Drawing.Size(249, 21)
            Me.cmbTerremotoFabbricatoLimite.TabIndex = 10
            '
            'desTerremotoContenuto
            '
            Me.desTerremotoContenuto.AutoSize = True
            Me.desTerremotoContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desTerremotoContenuto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desTerremotoContenuto.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desTerremotoContenuto.Location = New System.Drawing.Point(58, 90)
            Me.desTerremotoContenuto.Name = "desTerremotoContenuto"
            Me.desTerremotoContenuto.Size = New System.Drawing.Size(334, 25)
            Me.desTerremotoContenuto.TabIndex = 11
            Me.desTerremotoContenuto.Tag = "218"
            Me.desTerremotoContenuto.Text = "Terremoto contenuto"
            Me.desTerremotoContenuto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblTerremotoContenuto
            '
            Me.lblTerremotoContenuto.AutoSize = True
            Me.lblTerremotoContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTerremotoContenuto.Location = New System.Drawing.Point(908, 90)
            Me.lblTerremotoContenuto.Name = "lblTerremotoContenuto"
            Me.lblTerremotoContenuto.Size = New System.Drawing.Size(101, 25)
            Me.lblTerremotoContenuto.TabIndex = 12
            Me.lblTerremotoContenuto.Text = "0,00"
            Me.lblTerremotoContenuto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkTerremotoContenuto
            '
            Me.chkTerremotoContenuto.AutoSize = True
            Me.chkTerremotoContenuto.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkTerremotoContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkTerremotoContenuto.Location = New System.Drawing.Point(0, 90)
            Me.chkTerremotoContenuto.Margin = New System.Windows.Forms.Padding(0)
            Me.chkTerremotoContenuto.Name = "chkTerremotoContenuto"
            Me.chkTerremotoContenuto.Size = New System.Drawing.Size(55, 25)
            Me.chkTerremotoContenuto.TabIndex = 13
            Me.chkTerremotoContenuto.UseVisualStyleBackColor = True
            '
            'lblA8
            '
            Me.lblA8.AutoSize = True
            Me.lblA8.BackColor = System.Drawing.Color.Khaki
            Me.lblA8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblA8.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblA8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblA8.Location = New System.Drawing.Point(58, 0)
            Me.lblA8.Name = "lblA8"
            Me.lblA8.Size = New System.Drawing.Size(334, 40)
            Me.lblA8.TabIndex = 14
            Me.lblA8.Text = "Partita / Garanzia"
            Me.lblA8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblB8
            '
            Me.lblB8.AutoSize = True
            Me.lblB8.BackColor = System.Drawing.Color.Khaki
            Me.lblB8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.TableLayoutPanel8.SetColumnSpan(Me.lblB8, 2)
            Me.lblB8.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblB8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblB8.Location = New System.Drawing.Point(398, 0)
            Me.lblB8.Name = "lblB8"
            Me.lblB8.Size = New System.Drawing.Size(504, 40)
            Me.lblB8.TabIndex = 15
            Me.lblB8.Text = "Parametri/Condizioni"
            Me.lblB8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblC8
            '
            Me.lblC8.AutoSize = True
            Me.lblC8.BackColor = System.Drawing.Color.Khaki
            Me.lblC8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblC8.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblC8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblC8.Location = New System.Drawing.Point(908, 0)
            Me.lblC8.Name = "lblC8"
            Me.lblC8.Size = New System.Drawing.Size(101, 40)
            Me.lblC8.TabIndex = 16
            Me.lblC8.Text = "Premio"
            Me.lblC8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblD8
            '
            Me.lblD8.AutoSize = True
            Me.lblD8.BackColor = System.Drawing.Color.Khaki
            Me.lblD8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblD8.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblD8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblD8.Location = New System.Drawing.Point(3, 0)
            Me.lblD8.Name = "lblD8"
            Me.lblD8.Size = New System.Drawing.Size(49, 40)
            Me.lblD8.TabIndex = 17
            Me.lblD8.Text = "Scelto"
            Me.lblD8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.TableLayoutPanel8.SetColumnSpan(Me.Label2, 2)
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.Label2.Location = New System.Drawing.Point(398, 40)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(504, 25)
            Me.Label2.TabIndex = 11
            Me.Label2.Tag = ""
            Me.Label2.Text = "(attivabile se presente la sezione incendio con partita Abitazione  > 30.000,00)"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.TableLayoutPanel8.SetColumnSpan(Me.Label3, 2)
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.Label3.Location = New System.Drawing.Point(398, 115)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(365, 14)
            Me.Label3.TabIndex = 11
            Me.Label3.Tag = ""
            Me.Label3.Text = "(attivabile se presente la sezione incendio con partita Contenuto)"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmbTerremotoContenutoFormAss
            '
            Me.cmbTerremotoContenutoFormAss.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbTerremotoContenutoFormAss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTerremotoContenutoFormAss.FormattingEnabled = True
            Me.cmbTerremotoContenutoFormAss.Location = New System.Drawing.Point(398, 93)
            Me.cmbTerremotoContenutoFormAss.Name = "cmbTerremotoContenutoFormAss"
            Me.cmbTerremotoContenutoFormAss.Size = New System.Drawing.Size(249, 21)
            Me.cmbTerremotoContenutoFormAss.TabIndex = 10
            '
            'TabPage9
            '
            Me.TabPage9.Controls.Add(Me.GroupBox9)
            Me.TabPage9.Location = New System.Drawing.Point(4, 29)
            Me.TabPage9.Name = "TabPage9"
            Me.TabPage9.Size = New System.Drawing.Size(1018, 604)
            Me.TabPage9.TabIndex = 3
            Me.TabPage9.Tag = ""
            Me.TabPage9.Text = "Furto"
            Me.TabPage9.UseVisualStyleBackColor = True
            '
            'GroupBox9
            '
            Me.GroupBox9.Controls.Add(Me.TableLayoutPanel9)
            Me.GroupBox9.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox9.Location = New System.Drawing.Point(0, 0)
            Me.GroupBox9.Margin = New System.Windows.Forms.Padding(0)
            Me.GroupBox9.Name = "GroupBox9"
            Me.GroupBox9.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
            Me.GroupBox9.Size = New System.Drawing.Size(1018, 604)
            Me.GroupBox9.TabIndex = 0
            Me.GroupBox9.TabStop = False
            '
            'TableLayoutPanel9
            '
            Me.TableLayoutPanel9.ColumnCount = 5
            Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
            Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
            Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
            Me.TableLayoutPanel9.Controls.Add(Me.cmbFurtoChiave, 2, 1)
            Me.TableLayoutPanel9.Controls.Add(Me.cmbFurtoEsternoScelta, 3, 3)
            Me.TableLayoutPanel9.Controls.Add(Me.cmbFurtoEsternoPlatinoScelta, 3, 5)
            Me.TableLayoutPanel9.Controls.Add(Me.cmbFurtoInCassaforteScelta, 3, 6)
            Me.TableLayoutPanel9.Controls.Add(Me.cmbFurtoPreziosiValoriScelta, 3, 7)
            Me.TableLayoutPanel9.Controls.Add(Me.cmbFurtoValoriDimoraAbitualeDenaro, 2, 8)
            Me.TableLayoutPanel9.Controls.Add(Me.cmbFurtoValoriDimoraAbitualeValori, 3, 8)
            Me.TableLayoutPanel9.Controls.Add(Me.lblFurtoPremio, 4, 1)
            Me.TableLayoutPanel9.Controls.Add(Me.chkFurtoBase, 0, 1)
            Me.TableLayoutPanel9.Controls.Add(Me.desFurtoContenuto, 1, 2)
            Me.TableLayoutPanel9.Controls.Add(Me.lblFurtoContenuto, 4, 2)
            Me.TableLayoutPanel9.Controls.Add(Me.chkFurtoContenuto, 0, 2)
            Me.TableLayoutPanel9.Controls.Add(Me.txtPartitaFurtoContenuto, 2, 2)
            Me.TableLayoutPanel9.Controls.Add(Me.desFurtoEsterno, 1, 3)
            Me.TableLayoutPanel9.Controls.Add(Me.lblFurtoEsterno, 4, 3)
            Me.TableLayoutPanel9.Controls.Add(Me.chkFurtoEsterno, 0, 3)
            Me.TableLayoutPanel9.Controls.Add(Me.txtPartitaFurtoEsterno, 2, 3)
            Me.TableLayoutPanel9.Controls.Add(Me.cmbFurtoEsternoLimite, 3, 4)
            Me.TableLayoutPanel9.Controls.Add(Me.cmbFurtoEsternoMassimale, 2, 4)
            Me.TableLayoutPanel9.Controls.Add(Me.desFurtoEsternoPlatino, 1, 5)
            Me.TableLayoutPanel9.Controls.Add(Me.lblFurtoEsternoPlatino, 4, 5)
            Me.TableLayoutPanel9.Controls.Add(Me.chkFurtoEsternoPlatino, 0, 5)
            Me.TableLayoutPanel9.Controls.Add(Me.txtPartitaFurtoEsternoPlatino, 2, 5)
            Me.TableLayoutPanel9.Controls.Add(Me.desFurtoInCassaforte, 1, 6)
            Me.TableLayoutPanel9.Controls.Add(Me.lblFurtoInCassaforte, 4, 6)
            Me.TableLayoutPanel9.Controls.Add(Me.chkFurtoInCassaforte, 0, 6)
            Me.TableLayoutPanel9.Controls.Add(Me.txtPartitaFurtoInCassaforte, 2, 6)
            Me.TableLayoutPanel9.Controls.Add(Me.desFurtoPreziosiValori, 1, 7)
            Me.TableLayoutPanel9.Controls.Add(Me.lblFurtoPreziosiValori, 4, 7)
            Me.TableLayoutPanel9.Controls.Add(Me.chkFurtoPreziosiValori, 0, 7)
            Me.TableLayoutPanel9.Controls.Add(Me.txtPartitaFurtoPreziosiValori, 2, 7)
            Me.TableLayoutPanel9.Controls.Add(Me.desFurtoValoriDimoraAbituale, 1, 8)
            Me.TableLayoutPanel9.Controls.Add(Me.lblFurtoValoriDimoraAbituale, 4, 8)
            Me.TableLayoutPanel9.Controls.Add(Me.chkFurtoValoriDimoraAbituale, 0, 8)
            Me.TableLayoutPanel9.Controls.Add(Me.desFurtoValoriDimoraSaltuaria, 1, 9)
            Me.TableLayoutPanel9.Controls.Add(Me.lblFurtoValoriDimoraSaltuaria, 4, 9)
            Me.TableLayoutPanel9.Controls.Add(Me.chkFurtoValoriDimoraSaltuaria, 0, 9)
            Me.TableLayoutPanel9.Controls.Add(Me.desFurtoPannelliSolari, 1, 10)
            Me.TableLayoutPanel9.Controls.Add(Me.lblFurtoPannelliSolari, 4, 10)
            Me.TableLayoutPanel9.Controls.Add(Me.chkFurtoPannelliSolari, 0, 10)
            Me.TableLayoutPanel9.Controls.Add(Me.cmbFurtoPannelliSolariMassimale, 2, 10)
            Me.TableLayoutPanel9.Controls.Add(Me.desFurtoMezziChiusura, 1, 11)
            Me.TableLayoutPanel9.Controls.Add(Me.lblFurtoMezziChiusura, 4, 11)
            Me.TableLayoutPanel9.Controls.Add(Me.chkFurtoMezziChiusura, 0, 11)
            Me.TableLayoutPanel9.Controls.Add(Me.desFurtoImpiantoAllarme, 1, 12)
            Me.TableLayoutPanel9.Controls.Add(Me.lblFurtoImpiantoAllarme, 4, 12)
            Me.TableLayoutPanel9.Controls.Add(Me.chkFurtoImpiantoAllarme, 0, 12)
            Me.TableLayoutPanel9.Controls.Add(Me.desFurtoFranchigia, 1, 13)
            Me.TableLayoutPanel9.Controls.Add(Me.lblFurtoFranchigia, 4, 13)
            Me.TableLayoutPanel9.Controls.Add(Me.chkFurtoFranchigia, 0, 13)
            Me.TableLayoutPanel9.Controls.Add(Me.cmbFurtoFranchigiaFranchigia, 2, 13)
            Me.TableLayoutPanel9.Controls.Add(Me.desFurtoEstensioneGaranziaBase, 1, 14)
            Me.TableLayoutPanel9.Controls.Add(Me.chkFurtoEstensioneGaranziaBase, 0, 14)
            Me.TableLayoutPanel9.Controls.Add(Me.lblFurtoEstensioneGaranziaBase, 4, 14)
            Me.TableLayoutPanel9.Controls.Add(Me.lblA9, 1, 0)
            Me.TableLayoutPanel9.Controls.Add(Me.lblB9, 2, 0)
            Me.TableLayoutPanel9.Controls.Add(Me.lblC9, 4, 0)
            Me.TableLayoutPanel9.Controls.Add(Me.lblD9, 0, 0)
            Me.TableLayoutPanel9.Controls.Add(Me.cmbFurtoContenutoFormAss, 3, 2)
            Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel9.Location = New System.Drawing.Point(3, 13)
            Me.TableLayoutPanel9.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
            Me.TableLayoutPanel9.RowCount = 28
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel9.Size = New System.Drawing.Size(1012, 588)
            Me.TableLayoutPanel9.TabIndex = 0
            '
            'cmbFurtoChiave
            '
            Me.cmbFurtoChiave.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoChiave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoChiave.FormattingEnabled = True
            Me.cmbFurtoChiave.Location = New System.Drawing.Point(398, 43)
            Me.cmbFurtoChiave.Name = "cmbFurtoChiave"
            Me.cmbFurtoChiave.Size = New System.Drawing.Size(249, 21)
            Me.cmbFurtoChiave.TabIndex = 0
            '
            'cmbFurtoEsternoScelta
            '
            Me.cmbFurtoEsternoScelta.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoEsternoScelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoEsternoScelta.FormattingEnabled = True
            Me.cmbFurtoEsternoScelta.Location = New System.Drawing.Point(653, 93)
            Me.cmbFurtoEsternoScelta.Name = "cmbFurtoEsternoScelta"
            Me.cmbFurtoEsternoScelta.Size = New System.Drawing.Size(249, 21)
            Me.cmbFurtoEsternoScelta.TabIndex = 1
            '
            'cmbFurtoEsternoPlatinoScelta
            '
            Me.cmbFurtoEsternoPlatinoScelta.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoEsternoPlatinoScelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoEsternoPlatinoScelta.FormattingEnabled = True
            Me.cmbFurtoEsternoPlatinoScelta.Location = New System.Drawing.Point(653, 143)
            Me.cmbFurtoEsternoPlatinoScelta.Name = "cmbFurtoEsternoPlatinoScelta"
            Me.cmbFurtoEsternoPlatinoScelta.Size = New System.Drawing.Size(249, 21)
            Me.cmbFurtoEsternoPlatinoScelta.TabIndex = 2
            '
            'cmbFurtoInCassaforteScelta
            '
            Me.cmbFurtoInCassaforteScelta.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoInCassaforteScelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoInCassaforteScelta.FormattingEnabled = True
            Me.cmbFurtoInCassaforteScelta.Location = New System.Drawing.Point(653, 168)
            Me.cmbFurtoInCassaforteScelta.Name = "cmbFurtoInCassaforteScelta"
            Me.cmbFurtoInCassaforteScelta.Size = New System.Drawing.Size(249, 21)
            Me.cmbFurtoInCassaforteScelta.TabIndex = 3
            '
            'cmbFurtoPreziosiValoriScelta
            '
            Me.cmbFurtoPreziosiValoriScelta.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoPreziosiValoriScelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoPreziosiValoriScelta.FormattingEnabled = True
            Me.cmbFurtoPreziosiValoriScelta.Location = New System.Drawing.Point(653, 193)
            Me.cmbFurtoPreziosiValoriScelta.Name = "cmbFurtoPreziosiValoriScelta"
            Me.cmbFurtoPreziosiValoriScelta.Size = New System.Drawing.Size(249, 21)
            Me.cmbFurtoPreziosiValoriScelta.TabIndex = 4
            '
            'cmbFurtoValoriDimoraAbitualeDenaro
            '
            Me.cmbFurtoValoriDimoraAbitualeDenaro.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoValoriDimoraAbitualeDenaro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoValoriDimoraAbitualeDenaro.FormattingEnabled = True
            Me.cmbFurtoValoriDimoraAbitualeDenaro.Location = New System.Drawing.Point(398, 218)
            Me.cmbFurtoValoriDimoraAbitualeDenaro.Name = "cmbFurtoValoriDimoraAbitualeDenaro"
            Me.cmbFurtoValoriDimoraAbitualeDenaro.Size = New System.Drawing.Size(249, 21)
            Me.cmbFurtoValoriDimoraAbitualeDenaro.TabIndex = 5
            '
            'cmbFurtoValoriDimoraAbitualeValori
            '
            Me.cmbFurtoValoriDimoraAbitualeValori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoValoriDimoraAbitualeValori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoValoriDimoraAbitualeValori.FormattingEnabled = True
            Me.cmbFurtoValoriDimoraAbitualeValori.Location = New System.Drawing.Point(653, 218)
            Me.cmbFurtoValoriDimoraAbitualeValori.Name = "cmbFurtoValoriDimoraAbitualeValori"
            Me.cmbFurtoValoriDimoraAbitualeValori.Size = New System.Drawing.Size(249, 21)
            Me.cmbFurtoValoriDimoraAbitualeValori.TabIndex = 6
            '
            'lblFurtoPremio
            '
            Me.lblFurtoPremio.AutoSize = True
            Me.lblFurtoPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoPremio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFurtoPremio.Location = New System.Drawing.Point(908, 40)
            Me.lblFurtoPremio.Name = "lblFurtoPremio"
            Me.lblFurtoPremio.Size = New System.Drawing.Size(101, 25)
            Me.lblFurtoPremio.TabIndex = 8
            Me.lblFurtoPremio.Text = "0,00"
            Me.lblFurtoPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoBase
            '
            Me.chkFurtoBase.AutoSize = True
            Me.TableLayoutPanel9.SetColumnSpan(Me.chkFurtoBase, 2)
            Me.chkFurtoBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoBase.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.chkFurtoBase.Location = New System.Drawing.Point(8, 40)
            Me.chkFurtoBase.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
            Me.chkFurtoBase.Name = "chkFurtoBase"
            Me.chkFurtoBase.Size = New System.Drawing.Size(387, 25)
            Me.chkFurtoBase.TabIndex = 11
            Me.chkFurtoBase.Text = "FURTO E RAPINA"
            Me.chkFurtoBase.UseVisualStyleBackColor = True
            '
            'desFurtoContenuto
            '
            Me.desFurtoContenuto.AutoSize = True
            Me.desFurtoContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoContenuto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoContenuto.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoContenuto.Location = New System.Drawing.Point(58, 65)
            Me.desFurtoContenuto.Name = "desFurtoContenuto"
            Me.desFurtoContenuto.Size = New System.Drawing.Size(334, 25)
            Me.desFurtoContenuto.TabIndex = 12
            Me.desFurtoContenuto.Tag = "320"
            Me.desFurtoContenuto.Text = "Contenuto"
            Me.desFurtoContenuto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoContenuto
            '
            Me.lblFurtoContenuto.AutoSize = True
            Me.lblFurtoContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoContenuto.Location = New System.Drawing.Point(908, 65)
            Me.lblFurtoContenuto.Name = "lblFurtoContenuto"
            Me.lblFurtoContenuto.Size = New System.Drawing.Size(101, 25)
            Me.lblFurtoContenuto.TabIndex = 13
            Me.lblFurtoContenuto.Text = "0,00"
            Me.lblFurtoContenuto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoContenuto
            '
            Me.chkFurtoContenuto.AutoSize = True
            Me.chkFurtoContenuto.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoContenuto.Location = New System.Drawing.Point(0, 65)
            Me.chkFurtoContenuto.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoContenuto.Name = "chkFurtoContenuto"
            Me.chkFurtoContenuto.Size = New System.Drawing.Size(55, 25)
            Me.chkFurtoContenuto.TabIndex = 14
            Me.chkFurtoContenuto.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoContenuto
            '
            Me.txtPartitaFurtoContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoContenuto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoContenuto.Location = New System.Drawing.Point(398, 68)
            Me.txtPartitaFurtoContenuto.Name = "txtPartitaFurtoContenuto"
            Me.txtPartitaFurtoContenuto.Size = New System.Drawing.Size(249, 22)
            Me.txtPartitaFurtoContenuto.TabIndex = 15
            Me.txtPartitaFurtoContenuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desFurtoEsterno
            '
            Me.desFurtoEsterno.AutoSize = True
            Me.desFurtoEsterno.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoEsterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoEsterno.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoEsterno.Location = New System.Drawing.Point(58, 90)
            Me.desFurtoEsterno.Name = "desFurtoEsterno"
            Me.desFurtoEsterno.Size = New System.Drawing.Size(334, 25)
            Me.desFurtoEsterno.TabIndex = 16
            Me.desFurtoEsterno.Tag = "321"
            Me.desFurtoEsterno.Text = "Rischi esterni all’abitazione (ORO)"
            Me.desFurtoEsterno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoEsterno
            '
            Me.lblFurtoEsterno.AutoSize = True
            Me.lblFurtoEsterno.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoEsterno.Location = New System.Drawing.Point(908, 90)
            Me.lblFurtoEsterno.Name = "lblFurtoEsterno"
            Me.lblFurtoEsterno.Size = New System.Drawing.Size(101, 25)
            Me.lblFurtoEsterno.TabIndex = 17
            Me.lblFurtoEsterno.Text = "0,00"
            Me.lblFurtoEsterno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoEsterno
            '
            Me.chkFurtoEsterno.AutoSize = True
            Me.chkFurtoEsterno.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoEsterno.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoEsterno.Location = New System.Drawing.Point(0, 90)
            Me.chkFurtoEsterno.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoEsterno.Name = "chkFurtoEsterno"
            Me.chkFurtoEsterno.Size = New System.Drawing.Size(55, 25)
            Me.chkFurtoEsterno.TabIndex = 18
            Me.chkFurtoEsterno.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoEsterno
            '
            Me.txtPartitaFurtoEsterno.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoEsterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoEsterno.Location = New System.Drawing.Point(398, 93)
            Me.txtPartitaFurtoEsterno.Name = "txtPartitaFurtoEsterno"
            Me.txtPartitaFurtoEsterno.Size = New System.Drawing.Size(249, 22)
            Me.txtPartitaFurtoEsterno.TabIndex = 19
            Me.txtPartitaFurtoEsterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'cmbFurtoEsternoLimite
            '
            Me.cmbFurtoEsternoLimite.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoEsternoLimite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoEsternoLimite.FormattingEnabled = True
            Me.cmbFurtoEsternoLimite.Location = New System.Drawing.Point(653, 118)
            Me.cmbFurtoEsternoLimite.Name = "cmbFurtoEsternoLimite"
            Me.cmbFurtoEsternoLimite.Size = New System.Drawing.Size(249, 21)
            Me.cmbFurtoEsternoLimite.TabIndex = 20
            '
            'cmbFurtoEsternoMassimale
            '
            Me.cmbFurtoEsternoMassimale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoEsternoMassimale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoEsternoMassimale.FormattingEnabled = True
            Me.cmbFurtoEsternoMassimale.Location = New System.Drawing.Point(398, 118)
            Me.cmbFurtoEsternoMassimale.Name = "cmbFurtoEsternoMassimale"
            Me.cmbFurtoEsternoMassimale.Size = New System.Drawing.Size(249, 21)
            Me.cmbFurtoEsternoMassimale.TabIndex = 21
            '
            'desFurtoEsternoPlatino
            '
            Me.desFurtoEsternoPlatino.AutoSize = True
            Me.desFurtoEsternoPlatino.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoEsternoPlatino.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoEsternoPlatino.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoEsternoPlatino.Location = New System.Drawing.Point(58, 140)
            Me.desFurtoEsternoPlatino.Name = "desFurtoEsternoPlatino"
            Me.desFurtoEsternoPlatino.Size = New System.Drawing.Size(334, 25)
            Me.desFurtoEsternoPlatino.TabIndex = 22
            Me.desFurtoEsternoPlatino.Tag = "322"
            Me.desFurtoEsternoPlatino.Text = "Rischi esterni all’abitazione (PLATINO)"
            Me.desFurtoEsternoPlatino.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoEsternoPlatino
            '
            Me.lblFurtoEsternoPlatino.AutoSize = True
            Me.lblFurtoEsternoPlatino.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoEsternoPlatino.Location = New System.Drawing.Point(908, 140)
            Me.lblFurtoEsternoPlatino.Name = "lblFurtoEsternoPlatino"
            Me.lblFurtoEsternoPlatino.Size = New System.Drawing.Size(101, 25)
            Me.lblFurtoEsternoPlatino.TabIndex = 23
            Me.lblFurtoEsternoPlatino.Text = "0,00"
            Me.lblFurtoEsternoPlatino.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoEsternoPlatino
            '
            Me.chkFurtoEsternoPlatino.AutoSize = True
            Me.chkFurtoEsternoPlatino.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoEsternoPlatino.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoEsternoPlatino.Location = New System.Drawing.Point(0, 140)
            Me.chkFurtoEsternoPlatino.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoEsternoPlatino.Name = "chkFurtoEsternoPlatino"
            Me.chkFurtoEsternoPlatino.Size = New System.Drawing.Size(55, 25)
            Me.chkFurtoEsternoPlatino.TabIndex = 24
            Me.chkFurtoEsternoPlatino.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoEsternoPlatino
            '
            Me.txtPartitaFurtoEsternoPlatino.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoEsternoPlatino.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoEsternoPlatino.Location = New System.Drawing.Point(398, 143)
            Me.txtPartitaFurtoEsternoPlatino.Name = "txtPartitaFurtoEsternoPlatino"
            Me.txtPartitaFurtoEsternoPlatino.Size = New System.Drawing.Size(249, 22)
            Me.txtPartitaFurtoEsternoPlatino.TabIndex = 25
            Me.txtPartitaFurtoEsternoPlatino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desFurtoInCassaforte
            '
            Me.desFurtoInCassaforte.AutoSize = True
            Me.desFurtoInCassaforte.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoInCassaforte.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoInCassaforte.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoInCassaforte.Location = New System.Drawing.Point(58, 165)
            Me.desFurtoInCassaforte.Name = "desFurtoInCassaforte"
            Me.desFurtoInCassaforte.Size = New System.Drawing.Size(334, 25)
            Me.desFurtoInCassaforte.TabIndex = 26
            Me.desFurtoInCassaforte.Tag = "323"
            Me.desFurtoInCassaforte.Text = "Preziosi e valori in cassaforte"
            Me.desFurtoInCassaforte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoInCassaforte
            '
            Me.lblFurtoInCassaforte.AutoSize = True
            Me.lblFurtoInCassaforte.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoInCassaforte.Location = New System.Drawing.Point(908, 165)
            Me.lblFurtoInCassaforte.Name = "lblFurtoInCassaforte"
            Me.lblFurtoInCassaforte.Size = New System.Drawing.Size(101, 25)
            Me.lblFurtoInCassaforte.TabIndex = 27
            Me.lblFurtoInCassaforte.Text = "0,00"
            Me.lblFurtoInCassaforte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoInCassaforte
            '
            Me.chkFurtoInCassaforte.AutoSize = True
            Me.chkFurtoInCassaforte.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoInCassaforte.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoInCassaforte.Location = New System.Drawing.Point(0, 165)
            Me.chkFurtoInCassaforte.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoInCassaforte.Name = "chkFurtoInCassaforte"
            Me.chkFurtoInCassaforte.Size = New System.Drawing.Size(55, 25)
            Me.chkFurtoInCassaforte.TabIndex = 28
            Me.chkFurtoInCassaforte.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoInCassaforte
            '
            Me.txtPartitaFurtoInCassaforte.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoInCassaforte.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoInCassaforte.Location = New System.Drawing.Point(398, 168)
            Me.txtPartitaFurtoInCassaforte.Name = "txtPartitaFurtoInCassaforte"
            Me.txtPartitaFurtoInCassaforte.Size = New System.Drawing.Size(249, 22)
            Me.txtPartitaFurtoInCassaforte.TabIndex = 29
            Me.txtPartitaFurtoInCassaforte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desFurtoPreziosiValori
            '
            Me.desFurtoPreziosiValori.AutoSize = True
            Me.desFurtoPreziosiValori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoPreziosiValori.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoPreziosiValori.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoPreziosiValori.Location = New System.Drawing.Point(58, 190)
            Me.desFurtoPreziosiValori.Name = "desFurtoPreziosiValori"
            Me.desFurtoPreziosiValori.Size = New System.Drawing.Size(334, 25)
            Me.desFurtoPreziosiValori.TabIndex = 30
            Me.desFurtoPreziosiValori.Tag = "324"
            Me.desFurtoPreziosiValori.Text = "Preziosi e valori ovunque riposti"
            Me.desFurtoPreziosiValori.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoPreziosiValori
            '
            Me.lblFurtoPreziosiValori.AutoSize = True
            Me.lblFurtoPreziosiValori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoPreziosiValori.Location = New System.Drawing.Point(908, 190)
            Me.lblFurtoPreziosiValori.Name = "lblFurtoPreziosiValori"
            Me.lblFurtoPreziosiValori.Size = New System.Drawing.Size(101, 25)
            Me.lblFurtoPreziosiValori.TabIndex = 31
            Me.lblFurtoPreziosiValori.Text = "0,00"
            Me.lblFurtoPreziosiValori.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoPreziosiValori
            '
            Me.chkFurtoPreziosiValori.AutoSize = True
            Me.chkFurtoPreziosiValori.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoPreziosiValori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoPreziosiValori.Location = New System.Drawing.Point(0, 190)
            Me.chkFurtoPreziosiValori.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoPreziosiValori.Name = "chkFurtoPreziosiValori"
            Me.chkFurtoPreziosiValori.Size = New System.Drawing.Size(55, 25)
            Me.chkFurtoPreziosiValori.TabIndex = 32
            Me.chkFurtoPreziosiValori.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoPreziosiValori
            '
            Me.txtPartitaFurtoPreziosiValori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoPreziosiValori.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoPreziosiValori.Location = New System.Drawing.Point(398, 193)
            Me.txtPartitaFurtoPreziosiValori.Name = "txtPartitaFurtoPreziosiValori"
            Me.txtPartitaFurtoPreziosiValori.Size = New System.Drawing.Size(249, 22)
            Me.txtPartitaFurtoPreziosiValori.TabIndex = 33
            Me.txtPartitaFurtoPreziosiValori.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desFurtoValoriDimoraAbituale
            '
            Me.desFurtoValoriDimoraAbituale.AutoSize = True
            Me.desFurtoValoriDimoraAbituale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoValoriDimoraAbituale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoValoriDimoraAbituale.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoValoriDimoraAbituale.Location = New System.Drawing.Point(58, 215)
            Me.desFurtoValoriDimoraAbituale.Name = "desFurtoValoriDimoraAbituale"
            Me.desFurtoValoriDimoraAbituale.Size = New System.Drawing.Size(334, 25)
            Me.desFurtoValoriDimoraAbituale.TabIndex = 34
            Me.desFurtoValoriDimoraAbituale.Tag = "325"
            Me.desFurtoValoriDimoraAbituale.Text = "Preziosi e valori Dimora abituale"
            Me.desFurtoValoriDimoraAbituale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoValoriDimoraAbituale
            '
            Me.lblFurtoValoriDimoraAbituale.AutoSize = True
            Me.lblFurtoValoriDimoraAbituale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoValoriDimoraAbituale.Location = New System.Drawing.Point(908, 215)
            Me.lblFurtoValoriDimoraAbituale.Name = "lblFurtoValoriDimoraAbituale"
            Me.lblFurtoValoriDimoraAbituale.Size = New System.Drawing.Size(101, 25)
            Me.lblFurtoValoriDimoraAbituale.TabIndex = 35
            Me.lblFurtoValoriDimoraAbituale.Text = "0,00"
            Me.lblFurtoValoriDimoraAbituale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoValoriDimoraAbituale
            '
            Me.chkFurtoValoriDimoraAbituale.AutoSize = True
            Me.chkFurtoValoriDimoraAbituale.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoValoriDimoraAbituale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoValoriDimoraAbituale.Location = New System.Drawing.Point(0, 215)
            Me.chkFurtoValoriDimoraAbituale.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoValoriDimoraAbituale.Name = "chkFurtoValoriDimoraAbituale"
            Me.chkFurtoValoriDimoraAbituale.Size = New System.Drawing.Size(55, 25)
            Me.chkFurtoValoriDimoraAbituale.TabIndex = 36
            Me.chkFurtoValoriDimoraAbituale.UseVisualStyleBackColor = True
            '
            'desFurtoValoriDimoraSaltuaria
            '
            Me.desFurtoValoriDimoraSaltuaria.AutoSize = True
            Me.desFurtoValoriDimoraSaltuaria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoValoriDimoraSaltuaria.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoValoriDimoraSaltuaria.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoValoriDimoraSaltuaria.Location = New System.Drawing.Point(58, 240)
            Me.desFurtoValoriDimoraSaltuaria.Name = "desFurtoValoriDimoraSaltuaria"
            Me.desFurtoValoriDimoraSaltuaria.Size = New System.Drawing.Size(334, 25)
            Me.desFurtoValoriDimoraSaltuaria.TabIndex = 37
            Me.desFurtoValoriDimoraSaltuaria.Tag = "326"
            Me.desFurtoValoriDimoraSaltuaria.Text = "Preziosi e valori Dimora saltuaria"
            Me.desFurtoValoriDimoraSaltuaria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoValoriDimoraSaltuaria
            '
            Me.lblFurtoValoriDimoraSaltuaria.AutoSize = True
            Me.lblFurtoValoriDimoraSaltuaria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoValoriDimoraSaltuaria.Location = New System.Drawing.Point(908, 240)
            Me.lblFurtoValoriDimoraSaltuaria.Name = "lblFurtoValoriDimoraSaltuaria"
            Me.lblFurtoValoriDimoraSaltuaria.Size = New System.Drawing.Size(101, 25)
            Me.lblFurtoValoriDimoraSaltuaria.TabIndex = 38
            Me.lblFurtoValoriDimoraSaltuaria.Text = "0,00"
            Me.lblFurtoValoriDimoraSaltuaria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoValoriDimoraSaltuaria
            '
            Me.chkFurtoValoriDimoraSaltuaria.AutoSize = True
            Me.chkFurtoValoriDimoraSaltuaria.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoValoriDimoraSaltuaria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoValoriDimoraSaltuaria.Location = New System.Drawing.Point(0, 240)
            Me.chkFurtoValoriDimoraSaltuaria.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoValoriDimoraSaltuaria.Name = "chkFurtoValoriDimoraSaltuaria"
            Me.chkFurtoValoriDimoraSaltuaria.Size = New System.Drawing.Size(55, 25)
            Me.chkFurtoValoriDimoraSaltuaria.TabIndex = 39
            Me.chkFurtoValoriDimoraSaltuaria.UseVisualStyleBackColor = True
            '
            'desFurtoPannelliSolari
            '
            Me.desFurtoPannelliSolari.AutoSize = True
            Me.desFurtoPannelliSolari.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoPannelliSolari.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoPannelliSolari.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoPannelliSolari.Location = New System.Drawing.Point(58, 265)
            Me.desFurtoPannelliSolari.Name = "desFurtoPannelliSolari"
            Me.desFurtoPannelliSolari.Size = New System.Drawing.Size(334, 25)
            Me.desFurtoPannelliSolari.TabIndex = 40
            Me.desFurtoPannelliSolari.Tag = "327"
            Me.desFurtoPannelliSolari.Text = "Pannelli solari"
            Me.desFurtoPannelliSolari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoPannelliSolari
            '
            Me.lblFurtoPannelliSolari.AutoSize = True
            Me.lblFurtoPannelliSolari.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoPannelliSolari.Location = New System.Drawing.Point(908, 265)
            Me.lblFurtoPannelliSolari.Name = "lblFurtoPannelliSolari"
            Me.lblFurtoPannelliSolari.Size = New System.Drawing.Size(101, 25)
            Me.lblFurtoPannelliSolari.TabIndex = 41
            Me.lblFurtoPannelliSolari.Text = "0,00"
            Me.lblFurtoPannelliSolari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoPannelliSolari
            '
            Me.chkFurtoPannelliSolari.AutoSize = True
            Me.chkFurtoPannelliSolari.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoPannelliSolari.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoPannelliSolari.Location = New System.Drawing.Point(0, 265)
            Me.chkFurtoPannelliSolari.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoPannelliSolari.Name = "chkFurtoPannelliSolari"
            Me.chkFurtoPannelliSolari.Size = New System.Drawing.Size(55, 25)
            Me.chkFurtoPannelliSolari.TabIndex = 42
            Me.chkFurtoPannelliSolari.UseVisualStyleBackColor = True
            '
            'cmbFurtoPannelliSolariMassimale
            '
            Me.cmbFurtoPannelliSolariMassimale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoPannelliSolariMassimale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoPannelliSolariMassimale.FormattingEnabled = True
            Me.cmbFurtoPannelliSolariMassimale.Location = New System.Drawing.Point(398, 268)
            Me.cmbFurtoPannelliSolariMassimale.Name = "cmbFurtoPannelliSolariMassimale"
            Me.cmbFurtoPannelliSolariMassimale.Size = New System.Drawing.Size(249, 21)
            Me.cmbFurtoPannelliSolariMassimale.TabIndex = 43
            '
            'desFurtoMezziChiusura
            '
            Me.desFurtoMezziChiusura.AutoSize = True
            Me.desFurtoMezziChiusura.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoMezziChiusura.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoMezziChiusura.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoMezziChiusura.Location = New System.Drawing.Point(58, 290)
            Me.desFurtoMezziChiusura.Name = "desFurtoMezziChiusura"
            Me.desFurtoMezziChiusura.Size = New System.Drawing.Size(334, 25)
            Me.desFurtoMezziChiusura.TabIndex = 44
            Me.desFurtoMezziChiusura.Tag = "328"
            Me.desFurtoMezziChiusura.Text = "Mezzi di Chiusura Particolari"
            Me.desFurtoMezziChiusura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoMezziChiusura
            '
            Me.lblFurtoMezziChiusura.AutoSize = True
            Me.lblFurtoMezziChiusura.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoMezziChiusura.Location = New System.Drawing.Point(908, 290)
            Me.lblFurtoMezziChiusura.Name = "lblFurtoMezziChiusura"
            Me.lblFurtoMezziChiusura.Size = New System.Drawing.Size(101, 25)
            Me.lblFurtoMezziChiusura.TabIndex = 45
            Me.lblFurtoMezziChiusura.Text = "0,00"
            Me.lblFurtoMezziChiusura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoMezziChiusura
            '
            Me.chkFurtoMezziChiusura.AutoSize = True
            Me.chkFurtoMezziChiusura.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoMezziChiusura.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoMezziChiusura.Location = New System.Drawing.Point(0, 290)
            Me.chkFurtoMezziChiusura.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoMezziChiusura.Name = "chkFurtoMezziChiusura"
            Me.chkFurtoMezziChiusura.Size = New System.Drawing.Size(55, 25)
            Me.chkFurtoMezziChiusura.TabIndex = 46
            Me.chkFurtoMezziChiusura.UseVisualStyleBackColor = True
            '
            'desFurtoImpiantoAllarme
            '
            Me.desFurtoImpiantoAllarme.AutoSize = True
            Me.desFurtoImpiantoAllarme.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoImpiantoAllarme.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoImpiantoAllarme.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoImpiantoAllarme.Location = New System.Drawing.Point(58, 315)
            Me.desFurtoImpiantoAllarme.Name = "desFurtoImpiantoAllarme"
            Me.desFurtoImpiantoAllarme.Size = New System.Drawing.Size(334, 25)
            Me.desFurtoImpiantoAllarme.TabIndex = 47
            Me.desFurtoImpiantoAllarme.Tag = "329"
            Me.desFurtoImpiantoAllarme.Text = "Impianto di allarme"
            Me.desFurtoImpiantoAllarme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoImpiantoAllarme
            '
            Me.lblFurtoImpiantoAllarme.AutoSize = True
            Me.lblFurtoImpiantoAllarme.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoImpiantoAllarme.Location = New System.Drawing.Point(908, 315)
            Me.lblFurtoImpiantoAllarme.Name = "lblFurtoImpiantoAllarme"
            Me.lblFurtoImpiantoAllarme.Size = New System.Drawing.Size(101, 25)
            Me.lblFurtoImpiantoAllarme.TabIndex = 48
            Me.lblFurtoImpiantoAllarme.Text = "0,00"
            Me.lblFurtoImpiantoAllarme.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoImpiantoAllarme
            '
            Me.chkFurtoImpiantoAllarme.AutoSize = True
            Me.chkFurtoImpiantoAllarme.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoImpiantoAllarme.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoImpiantoAllarme.Location = New System.Drawing.Point(0, 315)
            Me.chkFurtoImpiantoAllarme.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoImpiantoAllarme.Name = "chkFurtoImpiantoAllarme"
            Me.chkFurtoImpiantoAllarme.Size = New System.Drawing.Size(55, 25)
            Me.chkFurtoImpiantoAllarme.TabIndex = 49
            Me.chkFurtoImpiantoAllarme.UseVisualStyleBackColor = True
            '
            'desFurtoFranchigia
            '
            Me.desFurtoFranchigia.AutoSize = True
            Me.desFurtoFranchigia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoFranchigia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoFranchigia.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoFranchigia.Location = New System.Drawing.Point(58, 340)
            Me.desFurtoFranchigia.Name = "desFurtoFranchigia"
            Me.desFurtoFranchigia.Size = New System.Drawing.Size(334, 25)
            Me.desFurtoFranchigia.TabIndex = 50
            Me.desFurtoFranchigia.Tag = "330"
            Me.desFurtoFranchigia.Text = "Franchigia"
            Me.desFurtoFranchigia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoFranchigia
            '
            Me.lblFurtoFranchigia.AutoSize = True
            Me.lblFurtoFranchigia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoFranchigia.Location = New System.Drawing.Point(908, 340)
            Me.lblFurtoFranchigia.Name = "lblFurtoFranchigia"
            Me.lblFurtoFranchigia.Size = New System.Drawing.Size(101, 25)
            Me.lblFurtoFranchigia.TabIndex = 51
            Me.lblFurtoFranchigia.Text = "0,00"
            Me.lblFurtoFranchigia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoFranchigia
            '
            Me.chkFurtoFranchigia.AutoSize = True
            Me.chkFurtoFranchigia.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoFranchigia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoFranchigia.Location = New System.Drawing.Point(0, 340)
            Me.chkFurtoFranchigia.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoFranchigia.Name = "chkFurtoFranchigia"
            Me.chkFurtoFranchigia.Size = New System.Drawing.Size(55, 25)
            Me.chkFurtoFranchigia.TabIndex = 52
            Me.chkFurtoFranchigia.UseVisualStyleBackColor = True
            '
            'cmbFurtoFranchigiaFranchigia
            '
            Me.cmbFurtoFranchigiaFranchigia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoFranchigiaFranchigia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoFranchigiaFranchigia.FormattingEnabled = True
            Me.cmbFurtoFranchigiaFranchigia.Location = New System.Drawing.Point(398, 343)
            Me.cmbFurtoFranchigiaFranchigia.Name = "cmbFurtoFranchigiaFranchigia"
            Me.cmbFurtoFranchigiaFranchigia.Size = New System.Drawing.Size(249, 21)
            Me.cmbFurtoFranchigiaFranchigia.TabIndex = 53
            '
            'desFurtoEstensioneGaranziaBase
            '
            Me.desFurtoEstensioneGaranziaBase.AutoSize = True
            Me.desFurtoEstensioneGaranziaBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoEstensioneGaranziaBase.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoEstensioneGaranziaBase.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoEstensioneGaranziaBase.Location = New System.Drawing.Point(58, 365)
            Me.desFurtoEstensioneGaranziaBase.Name = "desFurtoEstensioneGaranziaBase"
            Me.desFurtoEstensioneGaranziaBase.Size = New System.Drawing.Size(334, 25)
            Me.desFurtoEstensioneGaranziaBase.TabIndex = 0
            Me.desFurtoEstensioneGaranziaBase.Tag = "331"
            Me.desFurtoEstensioneGaranziaBase.Text = "Estensione Garanzia Base Furto"
            Me.desFurtoEstensioneGaranziaBase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'chkFurtoEstensioneGaranziaBase
            '
            Me.chkFurtoEstensioneGaranziaBase.AutoSize = True
            Me.chkFurtoEstensioneGaranziaBase.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoEstensioneGaranziaBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoEstensioneGaranziaBase.Location = New System.Drawing.Point(0, 365)
            Me.chkFurtoEstensioneGaranziaBase.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoEstensioneGaranziaBase.Name = "chkFurtoEstensioneGaranziaBase"
            Me.chkFurtoEstensioneGaranziaBase.Size = New System.Drawing.Size(55, 25)
            Me.chkFurtoEstensioneGaranziaBase.TabIndex = 0
            Me.chkFurtoEstensioneGaranziaBase.UseVisualStyleBackColor = True
            '
            'lblFurtoEstensioneGaranziaBase
            '
            Me.lblFurtoEstensioneGaranziaBase.AutoSize = True
            Me.lblFurtoEstensioneGaranziaBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoEstensioneGaranziaBase.Location = New System.Drawing.Point(908, 365)
            Me.lblFurtoEstensioneGaranziaBase.Name = "lblFurtoEstensioneGaranziaBase"
            Me.lblFurtoEstensioneGaranziaBase.Size = New System.Drawing.Size(101, 25)
            Me.lblFurtoEstensioneGaranziaBase.TabIndex = 0
            Me.lblFurtoEstensioneGaranziaBase.Text = "0,00"
            Me.lblFurtoEstensioneGaranziaBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblA9
            '
            Me.lblA9.AutoSize = True
            Me.lblA9.BackColor = System.Drawing.Color.Khaki
            Me.lblA9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblA9.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblA9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblA9.Location = New System.Drawing.Point(58, 0)
            Me.lblA9.Name = "lblA9"
            Me.lblA9.Size = New System.Drawing.Size(334, 40)
            Me.lblA9.TabIndex = 54
            Me.lblA9.Text = "Partita / Garanzia"
            Me.lblA9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblB9
            '
            Me.lblB9.AutoSize = True
            Me.lblB9.BackColor = System.Drawing.Color.Khaki
            Me.lblB9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.TableLayoutPanel9.SetColumnSpan(Me.lblB9, 2)
            Me.lblB9.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblB9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblB9.Location = New System.Drawing.Point(398, 0)
            Me.lblB9.Name = "lblB9"
            Me.lblB9.Size = New System.Drawing.Size(504, 40)
            Me.lblB9.TabIndex = 55
            Me.lblB9.Text = "Parametri/Condizioni"
            Me.lblB9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblC9
            '
            Me.lblC9.AutoSize = True
            Me.lblC9.BackColor = System.Drawing.Color.Khaki
            Me.lblC9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblC9.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblC9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblC9.Location = New System.Drawing.Point(908, 0)
            Me.lblC9.Name = "lblC9"
            Me.lblC9.Size = New System.Drawing.Size(101, 40)
            Me.lblC9.TabIndex = 56
            Me.lblC9.Text = "Premio"
            Me.lblC9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblD9
            '
            Me.lblD9.AutoSize = True
            Me.lblD9.BackColor = System.Drawing.Color.Khaki
            Me.lblD9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblD9.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblD9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblD9.Location = New System.Drawing.Point(3, 0)
            Me.lblD9.Name = "lblD9"
            Me.lblD9.Size = New System.Drawing.Size(49, 40)
            Me.lblD9.TabIndex = 57
            Me.lblD9.Text = "Scelto"
            Me.lblD9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cmbFurtoContenutoFormAss
            '
            Me.cmbFurtoContenutoFormAss.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoContenutoFormAss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoContenutoFormAss.FormattingEnabled = True
            Me.cmbFurtoContenutoFormAss.Location = New System.Drawing.Point(653, 68)
            Me.cmbFurtoContenutoFormAss.Name = "cmbFurtoContenutoFormAss"
            Me.cmbFurtoContenutoFormAss.Size = New System.Drawing.Size(249, 21)
            Me.cmbFurtoContenutoFormAss.TabIndex = 0
            '
            'TableLayoutPanel0
            '
            Me.TableLayoutPanel0.ColumnCount = 4
            Me.TableLayoutPanel0.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel0.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel0.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel0.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel0.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel0.Location = New System.Drawing.Point(3, 43)
            Me.TableLayoutPanel0.Name = "TableLayoutPanel0"
            Me.TableLayoutPanel0.RowCount = 4
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel0.Size = New System.Drawing.Size(796, 114)
            Me.TableLayoutPanel0.TabIndex = 0
            '
            'lblSezioneIncendioSintesi
            '
            Me.lblSezioneIncendioSintesi.AutoSize = True
            Me.lblSezioneIncendioSintesi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneIncendioSintesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneIncendioSintesi.Location = New System.Drawing.Point(3, 240)
            Me.lblSezioneIncendioSintesi.Name = "lblSezioneIncendioSintesi"
            Me.lblSezioneIncendioSintesi.Size = New System.Drawing.Size(258, 30)
            Me.lblSezioneIncendioSintesi.TabIndex = 0
            Me.lblSezioneIncendioSintesi.Text = "Incendio"
            Me.lblSezioneIncendioSintesi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSezioneIncendioPremio
            '
            Me.lblSezioneIncendioPremio.AutoSize = True
            Me.lblSezioneIncendioPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneIncendioPremio.Location = New System.Drawing.Point(667, 240)
            Me.lblSezioneIncendioPremio.Name = "lblSezioneIncendioPremio"
            Me.lblSezioneIncendioPremio.Size = New System.Drawing.Size(74, 30)
            Me.lblSezioneIncendioPremio.TabIndex = 0
            Me.lblSezioneIncendioPremio.Text = "0,00"
            Me.lblSezioneIncendioPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkSezioneIncendio
            '
            Me.chkSezioneIncendio.AutoSize = True
            Me.chkSezioneIncendio.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkSezioneIncendio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkSezioneIncendio.Enabled = False
            Me.chkSezioneIncendio.Location = New System.Drawing.Point(751, 243)
            Me.chkSezioneIncendio.Margin = New System.Windows.Forms.Padding(0)
            Me.chkSezioneIncendio.Name = "chkSezioneIncendio"
            Me.chkSezioneIncendio.Size = New System.Drawing.Size(51, 24)
            Me.chkSezioneIncendio.TabIndex = 0
            Me.chkSezioneIncendio.UseVisualStyleBackColor = True
            '
            'lblSezioneTerremotoSintesi
            '
            Me.lblSezioneTerremotoSintesi.AutoSize = True
            Me.lblSezioneTerremotoSintesi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneTerremotoSintesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneTerremotoSintesi.Location = New System.Drawing.Point(3, 240)
            Me.lblSezioneTerremotoSintesi.Name = "lblSezioneTerremotoSintesi"
            Me.lblSezioneTerremotoSintesi.Size = New System.Drawing.Size(258, 30)
            Me.lblSezioneTerremotoSintesi.TabIndex = 0
            Me.lblSezioneTerremotoSintesi.Text = "Rischio Terremoto"
            Me.lblSezioneTerremotoSintesi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSezioneTerremotoPremio
            '
            Me.lblSezioneTerremotoPremio.AutoSize = True
            Me.lblSezioneTerremotoPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneTerremotoPremio.Location = New System.Drawing.Point(667, 240)
            Me.lblSezioneTerremotoPremio.Name = "lblSezioneTerremotoPremio"
            Me.lblSezioneTerremotoPremio.Size = New System.Drawing.Size(74, 30)
            Me.lblSezioneTerremotoPremio.TabIndex = 0
            Me.lblSezioneTerremotoPremio.Text = "0,00"
            Me.lblSezioneTerremotoPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkSezioneTerremoto
            '
            Me.chkSezioneTerremoto.AutoSize = True
            Me.chkSezioneTerremoto.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkSezioneTerremoto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkSezioneTerremoto.Enabled = False
            Me.chkSezioneTerremoto.Location = New System.Drawing.Point(751, 243)
            Me.chkSezioneTerremoto.Margin = New System.Windows.Forms.Padding(0)
            Me.chkSezioneTerremoto.Name = "chkSezioneTerremoto"
            Me.chkSezioneTerremoto.Size = New System.Drawing.Size(51, 24)
            Me.chkSezioneTerremoto.TabIndex = 0
            Me.chkSezioneTerremoto.UseVisualStyleBackColor = True
            '
            'lblSezioneFurtoSintesi
            '
            Me.lblSezioneFurtoSintesi.AutoSize = True
            Me.lblSezioneFurtoSintesi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneFurtoSintesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneFurtoSintesi.Location = New System.Drawing.Point(3, 240)
            Me.lblSezioneFurtoSintesi.Name = "lblSezioneFurtoSintesi"
            Me.lblSezioneFurtoSintesi.Size = New System.Drawing.Size(258, 30)
            Me.lblSezioneFurtoSintesi.TabIndex = 0
            Me.lblSezioneFurtoSintesi.Text = "Furto e rapina"
            Me.lblSezioneFurtoSintesi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSezioneFurtoPremio
            '
            Me.lblSezioneFurtoPremio.AutoSize = True
            Me.lblSezioneFurtoPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneFurtoPremio.Location = New System.Drawing.Point(667, 240)
            Me.lblSezioneFurtoPremio.Name = "lblSezioneFurtoPremio"
            Me.lblSezioneFurtoPremio.Size = New System.Drawing.Size(74, 30)
            Me.lblSezioneFurtoPremio.TabIndex = 0
            Me.lblSezioneFurtoPremio.Text = "0,00"
            Me.lblSezioneFurtoPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkSezioneFurto
            '
            Me.chkSezioneFurto.AutoSize = True
            Me.chkSezioneFurto.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkSezioneFurto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkSezioneFurto.Enabled = False
            Me.chkSezioneFurto.Location = New System.Drawing.Point(751, 243)
            Me.chkSezioneFurto.Margin = New System.Windows.Forms.Padding(0)
            Me.chkSezioneFurto.Name = "chkSezioneFurto"
            Me.chkSezioneFurto.Size = New System.Drawing.Size(51, 24)
            Me.chkSezioneFurto.TabIndex = 0
            Me.chkSezioneFurto.UseVisualStyleBackColor = True
            '
            'lblSezioneTotalePremio
            '
            Me.lblSezioneTotalePremio.AutoSize = True
            Me.lblSezioneTotalePremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneTotalePremio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneTotalePremio.ForeColor = System.Drawing.Color.MediumBlue
            Me.lblSezioneTotalePremio.Location = New System.Drawing.Point(667, 390)
            Me.lblSezioneTotalePremio.Name = "lblSezioneTotalePremio"
            Me.lblSezioneTotalePremio.Size = New System.Drawing.Size(74, 40)
            Me.lblSezioneTotalePremio.TabIndex = 0
            Me.lblSezioneTotalePremio.Text = "0,00"
            Me.lblSezioneTotalePremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSezioneTotaleSintesi
            '
            Me.lblSezioneTotaleSintesi.AutoSize = True
            Me.lblSezioneTotaleSintesi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSezioneTotaleSintesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSezioneTotaleSintesi.ForeColor = System.Drawing.Color.MediumBlue
            Me.lblSezioneTotaleSintesi.Location = New System.Drawing.Point(3, 390)
            Me.lblSezioneTotaleSintesi.Name = "lblSezioneTotaleSintesi"
            Me.lblSezioneTotaleSintesi.Size = New System.Drawing.Size(258, 40)
            Me.lblSezioneTotaleSintesi.TabIndex = 0
            Me.lblSezioneTotaleSintesi.Text = "TOTALE"
            Me.lblSezioneTotaleSintesi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'AbitazioneFE
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControl1)
            Me.Name = "AbitazioneFE"
            Me.Size = New System.Drawing.Size(1026, 637)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.TabPage7.ResumeLayout(False)
            Me.GroupBox7.ResumeLayout(False)
            Me.TableLayoutPanel7.ResumeLayout(False)
            Me.TableLayoutPanel7.PerformLayout()
            Me.TabPage8.ResumeLayout(False)
            Me.GroupBox8.ResumeLayout(False)
            Me.TableLayoutPanel8.ResumeLayout(False)
            Me.TableLayoutPanel8.PerformLayout()
            Me.TabPage9.ResumeLayout(False)
            Me.GroupBox9.ResumeLayout(False)
            Me.TableLayoutPanel9.ResumeLayout(False)
            Me.TableLayoutPanel9.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents NoteAbitazione As UniQuota.NoteBox
        Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
        Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
        Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
        Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
        Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
        Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
        Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents TableLayoutPanel0 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents lblTipoAbitazione As System.Windows.Forms.Label
        Friend WithEvents cmbTipoAbitazione As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioChiave As System.Windows.Forms.ComboBox
        Friend WithEvents cmbFurtoChiave As System.Windows.Forms.ComboBox
        Friend WithEvents cmbFurtoEsternoScelta As System.Windows.Forms.ComboBox
        Friend WithEvents cmbFurtoEsternoPlatinoScelta As System.Windows.Forms.ComboBox
        Friend WithEvents cmbFurtoInCassaforteScelta As System.Windows.Forms.ComboBox
        Friend WithEvents cmbFurtoPreziosiValoriScelta As System.Windows.Forms.ComboBox
        Friend WithEvents cmbFurtoValoriDimoraAbitualeDenaro As System.Windows.Forms.ComboBox
        Friend WithEvents cmbFurtoValoriDimoraAbitualeValori As System.Windows.Forms.ComboBox
        Friend WithEvents lblProvincia As System.Windows.Forms.Label
        Friend WithEvents cmbProvincia As System.Windows.Forms.ComboBox
        Friend WithEvents txtDescrizione As System.Windows.Forms.TextBox
        Friend WithEvents lblA7 As System.Windows.Forms.Label
        Friend WithEvents lblB7 As System.Windows.Forms.Label
        Friend WithEvents lblC7 As System.Windows.Forms.Label
        Friend WithEvents lblD7 As System.Windows.Forms.Label
        Friend WithEvents lblA8 As System.Windows.Forms.Label
        Friend WithEvents lblB8 As System.Windows.Forms.Label
        Friend WithEvents lblC8 As System.Windows.Forms.Label
        Friend WithEvents lblD8 As System.Windows.Forms.Label
        Friend WithEvents lblA9 As System.Windows.Forms.Label
        Friend WithEvents lblB9 As System.Windows.Forms.Label
        Friend WithEvents lblC9 As System.Windows.Forms.Label
        Friend WithEvents lblD9 As System.Windows.Forms.Label
        Friend WithEvents lblIncendioPremio As System.Windows.Forms.Label
        Friend WithEvents chkIncendioBase As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioAbitazione As System.Windows.Forms.Label
        Friend WithEvents lblIncendioAbitazione As System.Windows.Forms.Label
        Friend WithEvents chkIncendioAbitazione As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioAbitazione As System.Windows.Forms.TextBox
        Friend WithEvents desIncendioContenuto As System.Windows.Forms.Label
        Friend WithEvents lblIncendioContenuto As System.Windows.Forms.Label
        Friend WithEvents chkIncendioContenuto As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioContenuto As System.Windows.Forms.TextBox
        Friend WithEvents desIncendioLocazione As System.Windows.Forms.Label
        Friend WithEvents lblIncendioLocazione As System.Windows.Forms.Label
        Friend WithEvents chkIncendioLocazione As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioLocazione As System.Windows.Forms.TextBox
        Friend WithEvents desIncendioCondutture As System.Windows.Forms.Label
        Friend WithEvents lblIncendioCondutture As System.Windows.Forms.Label
        Friend WithEvents chkIncendioCondutture As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioFenomeniElettrici As System.Windows.Forms.TextBox
        Friend WithEvents desIncendioFenomeniElettrici As System.Windows.Forms.Label
        Friend WithEvents lblIncendioFenomeniElettrici As System.Windows.Forms.Label
        Friend WithEvents chkIncendioFenomeniElettrici As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioFenomeniAtmosferici As System.Windows.Forms.Label
        Friend WithEvents lblIncendioFenomeniAtmosferici As System.Windows.Forms.Label
        Friend WithEvents chkIncendioFenomeniAtmosferici As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioFenomeniAtmosfericiLarge As System.Windows.Forms.Label
        Friend WithEvents lblIncendioFenomeniAtmosfericiLarge As System.Windows.Forms.Label
        Friend WithEvents chkIncendioFenomeniAtmosfericiLarge As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioRicorsoTerzi As System.Windows.Forms.Label
        Friend WithEvents lblIncendioRicorsoTerzi As System.Windows.Forms.Label
        Friend WithEvents chkIncendioRicorsoTerzi As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioRicorsoTerzi As System.Windows.Forms.TextBox
        Friend WithEvents desIncendioDemolizione As System.Windows.Forms.Label
        Friend WithEvents lblIncendioDemolizione As System.Windows.Forms.Label
        Friend WithEvents chkIncendioDemolizione As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioGelo As System.Windows.Forms.Label
        Friend WithEvents lblIncendioGelo As System.Windows.Forms.Label
        Friend WithEvents chkIncendioGelo As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioRicercaGuasto As System.Windows.Forms.Label
        Friend WithEvents lblIncendioRicercaGuasto As System.Windows.Forms.Label
        Friend WithEvents chkIncendioRicercaGuasto As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioAcquaOcclusione As System.Windows.Forms.Label
        Friend WithEvents lblIncendioAcquaOcclusione As System.Windows.Forms.Label
        Friend WithEvents chkIncendioAcquaOcclusione As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioPannelliSolari As System.Windows.Forms.Label
        Friend WithEvents lblIncendioPannelliSolari As System.Windows.Forms.Label
        Friend WithEvents chkIncendioPannelliSolari As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioRiduzioneFranchigiaFenomeniElettrici As System.Windows.Forms.Label
        Friend WithEvents lblIncendioRiduzioneFranchigiaFenomeniElettrici As System.Windows.Forms.Label
        Friend WithEvents chkIncendioRiduzioneFranchigiaFenomeniElettrici As System.Windows.Forms.CheckBox
        Friend WithEvents lblTerremotoPremio As System.Windows.Forms.Label
        Friend WithEvents chkTerremotoBase As System.Windows.Forms.CheckBox
        Friend WithEvents desTerremotoFabbricato As System.Windows.Forms.Label
        Friend WithEvents lblTerremotoFabbricato As System.Windows.Forms.Label
        Friend WithEvents chkTerremotoFabbricato As System.Windows.Forms.CheckBox
        Friend WithEvents desTerremotoContenuto As System.Windows.Forms.Label
        Friend WithEvents lblTerremotoContenuto As System.Windows.Forms.Label
        Friend WithEvents chkTerremotoContenuto As System.Windows.Forms.CheckBox
        Friend WithEvents lblFurtoPremio As System.Windows.Forms.Label
        Friend WithEvents chkFurtoBase As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoContenuto As System.Windows.Forms.Label
        Friend WithEvents lblFurtoContenuto As System.Windows.Forms.Label
        Friend WithEvents chkFurtoContenuto As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoContenuto As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoEsterno As System.Windows.Forms.Label
        Friend WithEvents lblFurtoEsterno As System.Windows.Forms.Label
        Friend WithEvents chkFurtoEsterno As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoEsterno As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoEsternoPlatino As System.Windows.Forms.Label
        Friend WithEvents lblFurtoEsternoPlatino As System.Windows.Forms.Label
        Friend WithEvents chkFurtoEsternoPlatino As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoEsternoPlatino As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoInCassaforte As System.Windows.Forms.Label
        Friend WithEvents lblFurtoInCassaforte As System.Windows.Forms.Label
        Friend WithEvents chkFurtoInCassaforte As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoInCassaforte As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoPreziosiValori As System.Windows.Forms.Label
        Friend WithEvents lblFurtoPreziosiValori As System.Windows.Forms.Label
        Friend WithEvents chkFurtoPreziosiValori As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoPreziosiValori As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoValoriDimoraAbituale As System.Windows.Forms.Label
        Friend WithEvents lblFurtoValoriDimoraAbituale As System.Windows.Forms.Label
        Friend WithEvents chkFurtoValoriDimoraAbituale As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoValoriDimoraSaltuaria As System.Windows.Forms.Label
        Friend WithEvents lblFurtoValoriDimoraSaltuaria As System.Windows.Forms.Label
        Friend WithEvents chkFurtoValoriDimoraSaltuaria As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoPannelliSolari As System.Windows.Forms.Label
        Friend WithEvents lblFurtoPannelliSolari As System.Windows.Forms.Label
        Friend WithEvents chkFurtoPannelliSolari As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoMezziChiusura As System.Windows.Forms.Label
        Friend WithEvents lblFurtoMezziChiusura As System.Windows.Forms.Label
        Friend WithEvents chkFurtoMezziChiusura As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoImpiantoAllarme As System.Windows.Forms.Label
        Friend WithEvents lblFurtoImpiantoAllarme As System.Windows.Forms.Label
        Friend WithEvents chkFurtoImpiantoAllarme As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoFranchigia As System.Windows.Forms.Label
        Friend WithEvents lblFurtoFranchigia As System.Windows.Forms.Label
        Friend WithEvents chkFurtoFranchigia As System.Windows.Forms.CheckBox
        Friend WithEvents cmbIncendioConduttureFranchigia As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioFenomeniAtmosfericiLimite As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioFenomeniAtmosfericiLargeMassimale As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioDemolizioneMassimale As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioGeloMassimale As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioRicercaGuastoMassimale As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioAcquaOcclusioneMassimale As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioPannelliSolariMassimale As System.Windows.Forms.ComboBox
        Friend WithEvents cmbTerremotoFabbricatoLimite As System.Windows.Forms.ComboBox
        Friend WithEvents cmbFurtoEsternoLimite As System.Windows.Forms.ComboBox
        Friend WithEvents cmbFurtoEsternoMassimale As System.Windows.Forms.ComboBox
        Friend WithEvents cmbFurtoPannelliSolariMassimale As System.Windows.Forms.ComboBox
        Friend WithEvents cmbFurtoFranchigiaFranchigia As System.Windows.Forms.ComboBox
        Friend WithEvents lblSezioneIncendioSintesi As System.Windows.Forms.Label
        Friend WithEvents lblSezioneIncendioPremio As System.Windows.Forms.Label
        Friend WithEvents chkSezioneIncendio As System.Windows.Forms.CheckBox
        Friend WithEvents lblSezioneTerremotoSintesi As System.Windows.Forms.Label
        Friend WithEvents lblSezioneTerremotoPremio As System.Windows.Forms.Label
        Friend WithEvents chkSezioneTerremoto As System.Windows.Forms.CheckBox
        Friend WithEvents lblSezioneFurtoSintesi As System.Windows.Forms.Label
        Friend WithEvents lblSezioneFurtoPremio As System.Windows.Forms.Label
        Friend WithEvents chkSezioneFurto As System.Windows.Forms.CheckBox
        Friend WithEvents lblSezioneTotalePremio As System.Windows.Forms.Label
        Friend WithEvents lblSezioneTotaleSintesi As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cmbFurtoContenutoFormAss As System.Windows.Forms.ComboBox
        Friend WithEvents cmbTerremotoContenutoFormAss As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cmbComune As System.Windows.Forms.ComboBox
        Friend WithEvents desIncendioEstensioneGaranziaBase As System.Windows.Forms.Label
        Friend WithEvents lblIncendioEstensioneGaranziaBase As System.Windows.Forms.Label
        Friend WithEvents chkIncendioEstensioneGaranziaBase As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioPannelliSolariEstensioneFenomenoElettrico As System.Windows.Forms.Label
        Friend WithEvents lblIncendioPannelliSolariEstensioneFenomenoElettrico As System.Windows.Forms.Label
        Friend WithEvents chkIncendioPannelliSolariEstensioneFenomenoElettrico As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioPannelliSolariEstensioneFenomenoAtmosferici As System.Windows.Forms.Label
        Friend WithEvents lblIncendioPannelliSolariEstensioneFenomenoAtmosferici As System.Windows.Forms.Label
        Friend WithEvents chkIncendioPannelliSolariEstensioneFenomenoAtmosferici As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioPerditeOcculteAcqua As System.Windows.Forms.Label
        Friend WithEvents lblIncendioPerditeOcculteAcqua As System.Windows.Forms.Label
        Friend WithEvents chkIncendioPerditeOcculteAcqua As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoEstensioneGaranziaBase As System.Windows.Forms.Label
        Friend WithEvents lblFurtoEstensioneGaranziaBase As System.Windows.Forms.Label
        Friend WithEvents chkFurtoEstensioneGaranziaBase As System.Windows.Forms.CheckBox
        Friend WithEvents cmbIncendioAbitazioneFormAss As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioContenutoFormAss As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioLocazioneFormAss As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioFenomeniElettriciFranchigia As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioFenomeniAtmosfericiCombinazione As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioFenomeniAtmosfericiLargeCombinazione As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioGeloFranchigia As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioRicercaGuastoFranchigia As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioAcquaOcclusioneFranchigia As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioPannelliSolariFranchigia As System.Windows.Forms.ComboBox
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cmdRemove As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cmbTipoDimora As System.Windows.Forms.ComboBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents cmbPianoAbitazione As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCaratteristicaCostruttiva As System.Windows.Forms.ComboBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtNumeroCivico As System.Windows.Forms.TextBox
        Friend WithEvents txtIndirizzo As System.Windows.Forms.TextBox
    End Class

End Namespace
