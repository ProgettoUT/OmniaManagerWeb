Namespace P04226
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FabbricatoFE
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FabbricatoFE))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel0 = New System.Windows.Forms.TableLayoutPanel()
            Me.cmbFabbricatoClasse = New System.Windows.Forms.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.chkExt1 = New System.Windows.Forms.CheckBox()
            Me.cmdRemove = New System.Windows.Forms.Button()
            Me.lblA1 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblFabbricatoDestinazione = New System.Windows.Forms.Label()
            Me.Note = New UniQuota.NoteBox()
            Me.txtDescrizione = New System.Windows.Forms.TextBox()
            Me.cmbFabbricatoDestinazione = New System.Windows.Forms.ComboBox()
            Me.lblProvincia = New System.Windows.Forms.Label()
            Me.cmbProvincia = New System.Windows.Forms.ComboBox()
            Me.chkExt3 = New System.Windows.Forms.CheckBox()
            Me.chkExt2 = New System.Windows.Forms.CheckBox()
            Me.chkExt4 = New System.Windows.Forms.CheckBox()
            Me.chkcomuneMinorRischioSismico = New System.Windows.Forms.CheckBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cmbComune = New System.Windows.Forms.ComboBox()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtIncendioAumentoMerciMesi = New System.Windows.Forms.TextBox()
            Me.lblIncendioPremio = New System.Windows.Forms.Label()
            Me.chkIncendioBase = New System.Windows.Forms.CheckBox()
            Me.cmbIncendioScelta = New System.Windows.Forms.ComboBox()
            Me.desIncendioFabbricato = New System.Windows.Forms.Label()
            Me.lblIncendioFabbricato = New System.Windows.Forms.Label()
            Me.chkIncendioFabbricato = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioFabbricato = New System.Windows.Forms.TextBox()
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
            Me.cmbIncendioConduttureMassimale = New System.Windows.Forms.ComboBox()
            Me.desIncendioDemolizione = New System.Windows.Forms.Label()
            Me.lblIncendioDemolizione = New System.Windows.Forms.Label()
            Me.chkIncendioDemolizione = New System.Windows.Forms.CheckBox()
            Me.cmbIncendioDemolizioneMassimale = New System.Windows.Forms.ComboBox()
            Me.desIncendioEventiAtmosferici = New System.Windows.Forms.Label()
            Me.lblIncendioEventiAtmosferici = New System.Windows.Forms.Label()
            Me.chkIncendioEventiAtmosferici = New System.Windows.Forms.CheckBox()
            Me.cmbIncendioEventiAtmosfericiScelta = New System.Windows.Forms.ComboBox()
            Me.desIncendioDanniElettrici = New System.Windows.Forms.Label()
            Me.lblIncendioDanniElettrici = New System.Windows.Forms.Label()
            Me.chkIncendioDanniElettrici = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioDanniElettrici = New System.Windows.Forms.TextBox()
            Me.cmbIncendioDanniElettriciScelta = New System.Windows.Forms.ComboBox()
            Me.desIncendioDanniIndirettiA = New System.Windows.Forms.Label()
            Me.lblIncendioDanniIndirettiA = New System.Windows.Forms.Label()
            Me.chkIncendioDanniIndirettiA = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioDanniIndirettiA = New System.Windows.Forms.TextBox()
            Me.cmbIncendioDanniIndirettiScelta = New System.Windows.Forms.ComboBox()
            Me.desIncendioRicorsoTerzi = New System.Windows.Forms.Label()
            Me.lblIncendioRicorsoTerzi = New System.Windows.Forms.Label()
            Me.chkIncendioRicorsoTerzi = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioRicorsoTerzi = New System.Windows.Forms.TextBox()
            Me.desIncendioAumentoMerci = New System.Windows.Forms.Label()
            Me.lblIncendioAumentoMerci = New System.Windows.Forms.Label()
            Me.chkIncendioAumentoMerci = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioAumentoMerci = New System.Windows.Forms.TextBox()
            Me.desIncendioCoseTrasportate = New System.Windows.Forms.Label()
            Me.lblIncendioCoseTrasportate = New System.Windows.Forms.Label()
            Me.chkIncendioCoseTrasportate = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioCoseTrasportate = New System.Windows.Forms.TextBox()
            Me.desIncendioRefrigerati1 = New System.Windows.Forms.Label()
            Me.lblIncendioRefrigerati1 = New System.Windows.Forms.Label()
            Me.chkIncendioRefrigerati1 = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioRefrigerati1 = New System.Windows.Forms.TextBox()
            Me.desIncendioRefrigerati2 = New System.Windows.Forms.Label()
            Me.lblIncendioRefrigerati2 = New System.Windows.Forms.Label()
            Me.chkIncendioRefrigerati2 = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioRefrigerati2 = New System.Windows.Forms.TextBox()
            Me.lblA2 = New System.Windows.Forms.Label()
            Me.lblB2 = New System.Windows.Forms.Label()
            Me.lblC2 = New System.Windows.Forms.Label()
            Me.lblD2 = New System.Windows.Forms.Label()
            Me.cmbIncendioFormaFabbricato = New System.Windows.Forms.ComboBox()
            Me.cmbIncendioFormaContenuto = New System.Windows.Forms.ComboBox()
            Me.cmbIncendioFormaLocazione = New System.Windows.Forms.ComboBox()
            Me.desIncendioDanniIndirettiB = New System.Windows.Forms.Label()
            Me.txtPartitaIncendioDanniIndirettiB = New System.Windows.Forms.TextBox()
            Me.lblIncendioDanniIndirettiB = New System.Windows.Forms.Label()
            Me.chkIncendioDanniIndirettiB = New System.Windows.Forms.CheckBox()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
            Me.desIncendioLastre = New System.Windows.Forms.Label()
            Me.lblIncendioLastre = New System.Windows.Forms.Label()
            Me.chkIncendioLastre = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioLastre = New System.Windows.Forms.TextBox()
            Me.desIncendioPannelliSolari = New System.Windows.Forms.Label()
            Me.lblIncendioPannelliSolari = New System.Windows.Forms.Label()
            Me.chkIncendioPannelliSolari = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioPannelliSolari = New System.Windows.Forms.TextBox()
            Me.desIncendioRicetteMediche = New System.Windows.Forms.Label()
            Me.lblIncendioRicetteMediche = New System.Windows.Forms.Label()
            Me.chkIncendioRicetteMediche = New System.Windows.Forms.CheckBox()
            Me.txtPartitaIncendioRicetteMediche = New System.Windows.Forms.TextBox()
            Me.desIncendioSpeseAccessorie = New System.Windows.Forms.Label()
            Me.lblIncendioSpeseAccessorie = New System.Windows.Forms.Label()
            Me.chkIncendioSpeseAccessorie = New System.Windows.Forms.CheckBox()
            Me.desIncendioGrandineFragili = New System.Windows.Forms.Label()
            Me.lblIncendioGrandineFragili = New System.Windows.Forms.Label()
            Me.chkIncendioGrandineFragili = New System.Windows.Forms.CheckBox()
            Me.desIncendioAttiVandaliciDolosi = New System.Windows.Forms.Label()
            Me.lblIncendioAttiVandaliciDolosi = New System.Windows.Forms.Label()
            Me.chkIncendioAttiVandaliciDolosi = New System.Windows.Forms.CheckBox()
            Me.desIncendioFabbricatiAperti1 = New System.Windows.Forms.Label()
            Me.lblIncendioFabbricatiAperti1 = New System.Windows.Forms.Label()
            Me.chkIncendioFabbricatiAperti1 = New System.Windows.Forms.CheckBox()
            Me.desIncendioFabbricatiAperti2 = New System.Windows.Forms.Label()
            Me.lblIncendioFabbricatiAperti2 = New System.Windows.Forms.Label()
            Me.chkIncendioFabbricatiAperti2 = New System.Windows.Forms.CheckBox()
            Me.desIncendioPreziosi = New System.Windows.Forms.Label()
            Me.lblIncendioPreziosi = New System.Windows.Forms.Label()
            Me.chkIncendioPreziosi = New System.Windows.Forms.CheckBox()
            Me.desIncendioSistemiProtezione = New System.Windows.Forms.Label()
            Me.lblIncendioSistemiProtezione = New System.Windows.Forms.Label()
            Me.chkIncendioSistemiProtezione = New System.Windows.Forms.CheckBox()
            Me.desIncendioCommercioAmbulante = New System.Windows.Forms.Label()
            Me.lblIncendioCommercioAmbulante = New System.Windows.Forms.Label()
            Me.chkIncendioCommercioAmbulante = New System.Windows.Forms.CheckBox()
            Me.desIncendioFranchigia = New System.Windows.Forms.Label()
            Me.lblIncendioFranchigia = New System.Windows.Forms.Label()
            Me.chkIncendioFranchigia = New System.Windows.Forms.CheckBox()
            Me.cmbIncendioFranchigiaFranchigia = New System.Windows.Forms.ComboBox()
            Me.lblA3 = New System.Windows.Forms.Label()
            Me.lblB3 = New System.Windows.Forms.Label()
            Me.lblC3 = New System.Windows.Forms.Label()
            Me.lblD3 = New System.Windows.Forms.Label()
            Me.TabPage4 = New System.Windows.Forms.TabPage()
            Me.GroupBox4 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtFurtoAumentoMerciMesi = New System.Windows.Forms.TextBox()
            Me.lblFurtoPremio = New System.Windows.Forms.Label()
            Me.chkFurtoBase = New System.Windows.Forms.CheckBox()
            Me.desFurtoContenuto = New System.Windows.Forms.Label()
            Me.lblFurtoContenuto = New System.Windows.Forms.Label()
            Me.chkFurtoContenuto = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoContenuto = New System.Windows.Forms.TextBox()
            Me.desFurtoFissi = New System.Windows.Forms.Label()
            Me.lblFurtoFissi = New System.Windows.Forms.Label()
            Me.chkFurtoFissi = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoFissi = New System.Windows.Forms.TextBox()
            Me.cmbFurtoFissiScelta = New System.Windows.Forms.ComboBox()
            Me.desFurtoValori = New System.Windows.Forms.Label()
            Me.lblFurtoValori = New System.Windows.Forms.Label()
            Me.chkFurtoValori = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoValori = New System.Windows.Forms.TextBox()
            Me.cmbFurtoValoriScelta = New System.Windows.Forms.ComboBox()
            Me.desFurtoVetrinette = New System.Windows.Forms.Label()
            Me.lblFurtoVetrinette = New System.Windows.Forms.Label()
            Me.chkFurtoVetrinette = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoVetrinette = New System.Windows.Forms.TextBox()
            Me.desFurtoPortavalori = New System.Windows.Forms.Label()
            Me.lblFurtoPortavalori = New System.Windows.Forms.Label()
            Me.chkFurtoPortavalori = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoPortavalori = New System.Windows.Forms.TextBox()
            Me.desFurtoAumentoMerci = New System.Windows.Forms.Label()
            Me.lblFurtoAumentoMerci = New System.Windows.Forms.Label()
            Me.chkFurtoAumentoMerci = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoAumentoMerci = New System.Windows.Forms.TextBox()
            Me.desFurtoMerciTrasportate = New System.Windows.Forms.Label()
            Me.lblFurtoMerciTrasportate = New System.Windows.Forms.Label()
            Me.chkFurtoMerciTrasportate = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoMerciTrasportate = New System.Windows.Forms.TextBox()
            Me.desFurtoMerciAperto = New System.Windows.Forms.Label()
            Me.lblFurtoMerciAperto = New System.Windows.Forms.Label()
            Me.chkFurtoMerciAperto = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoMerciAperto = New System.Windows.Forms.TextBox()
            Me.desFurtoDistributoriEsterni = New System.Windows.Forms.Label()
            Me.lblFurtoDistributoriEsterni = New System.Windows.Forms.Label()
            Me.chkFurtoDistributoriEsterni = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoDistributoriEsterni = New System.Windows.Forms.TextBox()
            Me.desFurtoDistributoriCarburante = New System.Windows.Forms.Label()
            Me.lblFurtoDistributoriCarburante = New System.Windows.Forms.Label()
            Me.chkFurtoDistributoriCarburante = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoDistributoriCarburante = New System.Windows.Forms.TextBox()
            Me.desFurtoRicetteMediche = New System.Windows.Forms.Label()
            Me.lblFurtoRicetteMediche = New System.Windows.Forms.Label()
            Me.chkFurtoRicetteMediche = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoRicetteMediche = New System.Windows.Forms.TextBox()
            Me.desFurtoDipendenti = New System.Windows.Forms.Label()
            Me.lblFurtoDipendenti = New System.Windows.Forms.Label()
            Me.chkFurtoDipendenti = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoDipendenti = New System.Windows.Forms.TextBox()
            Me.lblA4 = New System.Windows.Forms.Label()
            Me.lblB4 = New System.Windows.Forms.Label()
            Me.lblC4 = New System.Windows.Forms.Label()
            Me.lblD4 = New System.Windows.Forms.Label()
            Me.desFurtoRapina = New System.Windows.Forms.Label()
            Me.txtPartitaFurtoRapina = New System.Windows.Forms.TextBox()
            Me.cmbFurtoRapinaScelta = New System.Windows.Forms.ComboBox()
            Me.lblFurtoRapina = New System.Windows.Forms.Label()
            Me.chkFurtoRapina = New System.Windows.Forms.CheckBox()
            Me.TabPage5 = New System.Windows.Forms.TabPage()
            Me.GroupBox5 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
            Me.desFurtoSpeseAccessorie = New System.Windows.Forms.Label()
            Me.lblFurtoSpeseAccessorie = New System.Windows.Forms.Label()
            Me.chkFurtoSpeseAccessorie = New System.Windows.Forms.CheckBox()
            Me.desFurtoSpeseMiglioramento = New System.Windows.Forms.Label()
            Me.lblFurtoSpeseMiglioramento = New System.Windows.Forms.Label()
            Me.chkFurtoSpeseMiglioramento = New System.Windows.Forms.CheckBox()
            Me.desFurtoSlotMachine = New System.Windows.Forms.Label()
            Me.lblFurtoSlotMachine = New System.Windows.Forms.Label()
            Me.chkFurtoSlotMachine = New System.Windows.Forms.CheckBox()
            Me.txtPartitaFurtoSlotMachine = New System.Windows.Forms.TextBox()
            Me.desFurtoReintegroAutomatico = New System.Windows.Forms.Label()
            Me.lblFurtoReintegroAutomatico = New System.Windows.Forms.Label()
            Me.chkFurtoReintegroAutomatico = New System.Windows.Forms.CheckBox()
            Me.desFurtoCommercioAmbulante = New System.Windows.Forms.Label()
            Me.lblFurtoCommercioAmbulante = New System.Windows.Forms.Label()
            Me.chkFurtoCommercioAmbulante = New System.Windows.Forms.CheckBox()
            Me.desFurtoDepositoRiserva = New System.Windows.Forms.Label()
            Me.lblFurtoDepositoRiserva = New System.Windows.Forms.Label()
            Me.chkFurtoDepositoRiserva = New System.Windows.Forms.CheckBox()
            Me.desFurtoDerogaCostruttive = New System.Windows.Forms.Label()
            Me.lblFurtoDerogaCostruttive = New System.Windows.Forms.Label()
            Me.chkFurtoDerogaCostruttive = New System.Windows.Forms.CheckBox()
            Me.desFurtoMezziChiusura = New System.Windows.Forms.Label()
            Me.lblFurtoMezziChiusura = New System.Windows.Forms.Label()
            Me.chkFurtoMezziChiusura = New System.Windows.Forms.CheckBox()
            Me.desFurtoImpiantoAllarme = New System.Windows.Forms.Label()
            Me.lblFurtoImpiantoAllarme = New System.Windows.Forms.Label()
            Me.chkFurtoImpiantoAllarme = New System.Windows.Forms.CheckBox()
            Me.desFurtoAllarmeDistanza = New System.Windows.Forms.Label()
            Me.lblFurtoAllarmeDistanza = New System.Windows.Forms.Label()
            Me.chkFurtoAllarmeDistanza = New System.Windows.Forms.CheckBox()
            Me.desFurtoAllarmeDoppio = New System.Windows.Forms.Label()
            Me.lblFurtoAllarmeDoppio = New System.Windows.Forms.Label()
            Me.chkFurtoAllarmeDoppio = New System.Windows.Forms.CheckBox()
            Me.desFurtoVideoSorveglianza = New System.Windows.Forms.Label()
            Me.lblFurtoVideoSorveglianza = New System.Windows.Forms.Label()
            Me.chkFurtoVideoSorveglianza = New System.Windows.Forms.CheckBox()
            Me.desFurtoScopertoMerciA = New System.Windows.Forms.Label()
            Me.lblFurtoScopertoMerciA = New System.Windows.Forms.Label()
            Me.chkFurtoScopertoMerciA = New System.Windows.Forms.CheckBox()
            Me.desFurtoScopertoMerciB = New System.Windows.Forms.Label()
            Me.lblFurtoScopertoMerciB = New System.Windows.Forms.Label()
            Me.chkFurtoScopertoMerciB = New System.Windows.Forms.CheckBox()
            Me.desFurtoPiuEsercizi = New System.Windows.Forms.Label()
            Me.lblFurtoPiuEsercizi = New System.Windows.Forms.Label()
            Me.chkFurtoPiuEsercizi = New System.Windows.Forms.CheckBox()
            Me.lblA5 = New System.Windows.Forms.Label()
            Me.lblB5 = New System.Windows.Forms.Label()
            Me.lblC5 = New System.Windows.Forms.Label()
            Me.lblD5 = New System.Windows.Forms.Label()
            Me.txtPartitaFurtoPiuEsercizi = New System.Windows.Forms.TextBox()
            Me.TabPage8 = New System.Windows.Forms.TabPage()
            Me.GroupBox8 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblTerremotoPremio = New System.Windows.Forms.Label()
            Me.cmbCaratteristicaCostruttiva = New System.Windows.Forms.ComboBox()
            Me.desTerremotoFabbricato = New System.Windows.Forms.Label()
            Me.lblTerremotoFabbricato = New System.Windows.Forms.Label()
            Me.chkTerremotoFabbricato = New System.Windows.Forms.CheckBox()
            Me.txtPartitaTerremotoFabbricato = New System.Windows.Forms.TextBox()
            Me.desTerremotoContenuto = New System.Windows.Forms.Label()
            Me.lblTerremotoContenuto = New System.Windows.Forms.Label()
            Me.chkTerremotoContenuto = New System.Windows.Forms.CheckBox()
            Me.txtPartitaTerremotoContenuto = New System.Windows.Forms.TextBox()
            Me.desTerremotoDemolizione = New System.Windows.Forms.Label()
            Me.lblTerremotoDemolizione = New System.Windows.Forms.Label()
            Me.chkTerremotoDemolizione = New System.Windows.Forms.CheckBox()
            Me.cmbTerremotoDemolizioneMassimale = New System.Windows.Forms.ComboBox()
            Me.desTerremotoAumentoMerci = New System.Windows.Forms.Label()
            Me.lblTerremotoAumentoMerci = New System.Windows.Forms.Label()
            Me.chkTerremotoAumentoMerci = New System.Windows.Forms.CheckBox()
            Me.desTerremotoRicetteMediche = New System.Windows.Forms.Label()
            Me.lblTerremotoRicetteMediche = New System.Windows.Forms.Label()
            Me.chkTerremotoRicetteMediche = New System.Windows.Forms.CheckBox()
            Me.txtPartitaTerremotoRicetteMediche = New System.Windows.Forms.TextBox()
            Me.lblA8 = New System.Windows.Forms.Label()
            Me.lblB8 = New System.Windows.Forms.Label()
            Me.lblC8 = New System.Windows.Forms.Label()
            Me.lblD8 = New System.Windows.Forms.Label()
            Me.chkTerremotoBase = New System.Windows.Forms.CheckBox()
            Me.txtTerremotoAumentoMerciMesi = New System.Windows.Forms.TextBox()
            Me.txtPartitaTerremotoAumentoMerci = New System.Windows.Forms.TextBox()
            Me.cmbTerremotoFabbricatoLimite = New System.Windows.Forms.ComboBox()
            Me.cmbTipologiaFabbricato = New System.Windows.Forms.ComboBox()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.TableLayoutPanel0.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.TabPage3.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.TableLayoutPanel3.SuspendLayout()
            Me.TabPage4.SuspendLayout()
            Me.GroupBox4.SuspendLayout()
            Me.TableLayoutPanel4.SuspendLayout()
            Me.TabPage5.SuspendLayout()
            Me.GroupBox5.SuspendLayout()
            Me.TableLayoutPanel5.SuspendLayout()
            Me.TabPage8.SuspendLayout()
            Me.GroupBox8.SuspendLayout()
            Me.TableLayoutPanel8.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Controls.Add(Me.TabPage3)
            Me.TabControl1.Controls.Add(Me.TabPage4)
            Me.TabControl1.Controls.Add(Me.TabPage5)
            Me.TabControl1.Controls.Add(Me.TabPage8)
            Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControl1.HotTrack = True
            Me.TabControl1.ItemSize = New System.Drawing.Size(180, 25)
            Me.TabControl1.Location = New System.Drawing.Point(0, 0)
            Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.Padding = New System.Drawing.Point(0, 0)
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(1088, 646)
            Me.TabControl1.TabIndex = 29
            Me.TabControl1.Tag = ""
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.GroupBox1)
            Me.TabPage1.Location = New System.Drawing.Point(4, 29)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(1080, 613)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Tag = ""
            Me.TabPage1.Text = "Fabbricato"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.TableLayoutPanel0)
            Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
            Me.GroupBox1.Margin = New System.Windows.Forms.Padding(0)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
            Me.GroupBox1.Size = New System.Drawing.Size(1080, 613)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            '
            'TableLayoutPanel0
            '
            Me.TableLayoutPanel0.ColumnCount = 5
            Me.TableLayoutPanel0.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel0.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel0.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel0.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel0.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
            Me.TableLayoutPanel0.Controls.Add(Me.cmbFabbricatoClasse, 1, 3)
            Me.TableLayoutPanel0.Controls.Add(Me.Label2, 0, 3)
            Me.TableLayoutPanel0.Controls.Add(Me.chkExt1, 0, 6)
            Me.TableLayoutPanel0.Controls.Add(Me.cmdRemove, 4, 0)
            Me.TableLayoutPanel0.Controls.Add(Me.lblA1, 0, 0)
            Me.TableLayoutPanel0.Controls.Add(Me.Label1, 0, 1)
            Me.TableLayoutPanel0.Controls.Add(Me.lblFabbricatoDestinazione, 0, 2)
            Me.TableLayoutPanel0.Controls.Add(Me.Note, 0, 11)
            Me.TableLayoutPanel0.Controls.Add(Me.txtDescrizione, 1, 1)
            Me.TableLayoutPanel0.Controls.Add(Me.cmbFabbricatoDestinazione, 1, 2)
            Me.TableLayoutPanel0.Controls.Add(Me.lblProvincia, 0, 4)
            Me.TableLayoutPanel0.Controls.Add(Me.cmbProvincia, 1, 4)
            Me.TableLayoutPanel0.Controls.Add(Me.chkExt3, 0, 8)
            Me.TableLayoutPanel0.Controls.Add(Me.chkExt2, 0, 7)
            Me.TableLayoutPanel0.Controls.Add(Me.chkExt4, 0, 9)
            Me.TableLayoutPanel0.Controls.Add(Me.chkcomuneMinorRischioSismico, 0, 10)
            Me.TableLayoutPanel0.Controls.Add(Me.Label3, 0, 5)
            Me.TableLayoutPanel0.Controls.Add(Me.cmbComune, 1, 5)
            Me.TableLayoutPanel0.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel0.Location = New System.Drawing.Point(3, 13)
            Me.TableLayoutPanel0.Name = "TableLayoutPanel0"
            Me.TableLayoutPanel0.RowCount = 13
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel0.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel0.Size = New System.Drawing.Size(1074, 597)
            Me.TableLayoutPanel0.TabIndex = 0
            '
            'cmbFabbricatoClasse
            '
            Me.cmbFabbricatoClasse.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFabbricatoClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFabbricatoClasse.FormattingEnabled = True
            Me.cmbFabbricatoClasse.Location = New System.Drawing.Point(265, 103)
            Me.cmbFabbricatoClasse.Name = "cmbFabbricatoClasse"
            Me.cmbFabbricatoClasse.Size = New System.Drawing.Size(256, 21)
            Me.cmbFabbricatoClasse.TabIndex = 32
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(3, 100)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(256, 30)
            Me.Label2.TabIndex = 31
            Me.Label2.Tag = ""
            Me.Label2.Text = "Classe Fabbricato"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'chkExt1
            '
            Me.chkExt1.AutoSize = True
            Me.TableLayoutPanel0.SetColumnSpan(Me.chkExt1, 2)
            Me.chkExt1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkExt1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkExt1.Location = New System.Drawing.Point(8, 190)
            Me.chkExt1.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
            Me.chkExt1.Name = "chkExt1"
            Me.chkExt1.Size = New System.Drawing.Size(516, 30)
            Me.chkExt1.TabIndex = 3
            Me.chkExt1.Text = "Le garanzie Incendio, Furto e Responsabilità Civile, sono estese al deposito di r" & _
                "iserva"
            Me.chkExt1.UseVisualStyleBackColor = True
            '
            'cmdRemove
            '
            Me.cmdRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmdRemove.BackColor = System.Drawing.Color.Transparent
            Me.cmdRemove.Cursor = System.Windows.Forms.Cursors.Hand
            Me.cmdRemove.FlatAppearance.BorderColor = System.Drawing.Color.Black
            Me.cmdRemove.FlatAppearance.BorderSize = 0
            Me.cmdRemove.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
            Me.cmdRemove.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
            Me.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cmdRemove.Image = CType(resources.GetObject("cmdRemove.Image"), System.Drawing.Image)
            Me.cmdRemove.Location = New System.Drawing.Point(1048, 3)
            Me.cmdRemove.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
            Me.cmdRemove.Name = "cmdRemove"
            Me.cmdRemove.Size = New System.Drawing.Size(23, 22)
            Me.cmdRemove.TabIndex = 5
            Me.cmdRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            Me.cmdRemove.UseVisualStyleBackColor = False
            '
            'lblA1
            '
            Me.lblA1.AutoSize = True
            Me.lblA1.BackColor = System.Drawing.Color.Khaki
            Me.lblA1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.TableLayoutPanel0.SetColumnSpan(Me.lblA1, 4)
            Me.lblA1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblA1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblA1.Location = New System.Drawing.Point(3, 0)
            Me.lblA1.Name = "lblA1"
            Me.lblA1.Size = New System.Drawing.Size(1042, 40)
            Me.lblA1.TabIndex = 18
            Me.lblA1.Text = "Parametri generali"
            Me.lblA1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(3, 40)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(256, 30)
            Me.Label1.TabIndex = 6
            Me.Label1.Tag = ""
            Me.Label1.Text = "Descrizione"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFabbricatoDestinazione
            '
            Me.lblFabbricatoDestinazione.AutoSize = True
            Me.lblFabbricatoDestinazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFabbricatoDestinazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFabbricatoDestinazione.Location = New System.Drawing.Point(3, 70)
            Me.lblFabbricatoDestinazione.Name = "lblFabbricatoDestinazione"
            Me.lblFabbricatoDestinazione.Size = New System.Drawing.Size(256, 30)
            Me.lblFabbricatoDestinazione.TabIndex = 0
            Me.lblFabbricatoDestinazione.Tag = ""
            Me.lblFabbricatoDestinazione.Text = "Destinazione"
            Me.lblFabbricatoDestinazione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Note
            '
            Me.Note.Caption = "Note"
            Me.Note.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Note.Location = New System.Drawing.Point(0, 343)
            Me.Note.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
            Me.Note.Name = "Note"
            Me.Note.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.Note.Size = New System.Drawing.Size(262, 24)
            Me.Note.TabIndex = 28
            Me.Note.TextNote = Nothing
            '
            'txtDescrizione
            '
            Me.txtDescrizione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtDescrizione.Location = New System.Drawing.Point(262, 43)
            Me.txtDescrizione.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
            Me.txtDescrizione.Name = "txtDescrizione"
            Me.txtDescrizione.Size = New System.Drawing.Size(262, 20)
            Me.txtDescrizione.TabIndex = 0
            Me.txtDescrizione.Tag = "Descrizione dell'abitazione"
            '
            'cmbFabbricatoDestinazione
            '
            Me.cmbFabbricatoDestinazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFabbricatoDestinazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFabbricatoDestinazione.FormattingEnabled = True
            Me.cmbFabbricatoDestinazione.Location = New System.Drawing.Point(265, 73)
            Me.cmbFabbricatoDestinazione.Name = "cmbFabbricatoDestinazione"
            Me.cmbFabbricatoDestinazione.Size = New System.Drawing.Size(256, 21)
            Me.cmbFabbricatoDestinazione.TabIndex = 1
            '
            'lblProvincia
            '
            Me.lblProvincia.AutoSize = True
            Me.lblProvincia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblProvincia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProvincia.Location = New System.Drawing.Point(3, 130)
            Me.lblProvincia.Name = "lblProvincia"
            Me.lblProvincia.Size = New System.Drawing.Size(256, 30)
            Me.lblProvincia.TabIndex = 4
            Me.lblProvincia.Text = "Provincia"
            Me.lblProvincia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmbProvincia
            '
            Me.cmbProvincia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbProvincia.FormattingEnabled = True
            Me.cmbProvincia.Location = New System.Drawing.Point(265, 133)
            Me.cmbProvincia.Name = "cmbProvincia"
            Me.cmbProvincia.Size = New System.Drawing.Size(256, 21)
            Me.cmbProvincia.TabIndex = 2
            '
            'chkExt3
            '
            Me.chkExt3.AutoSize = True
            Me.TableLayoutPanel0.SetColumnSpan(Me.chkExt3, 2)
            Me.chkExt3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkExt3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkExt3.Location = New System.Drawing.Point(8, 250)
            Me.chkExt3.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
            Me.chkExt3.Name = "chkExt3"
            Me.chkExt3.Size = New System.Drawing.Size(516, 30)
            Me.chkExt3.TabIndex = 5
            Me.chkExt3.Text = "La partita Contenuto comprende il Contenuto dell’abitazione comunicante"
            Me.chkExt3.UseVisualStyleBackColor = True
            '
            'chkExt2
            '
            Me.chkExt2.AutoSize = True
            Me.TableLayoutPanel0.SetColumnSpan(Me.chkExt2, 2)
            Me.chkExt2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkExt2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkExt2.Location = New System.Drawing.Point(8, 220)
            Me.chkExt2.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
            Me.chkExt2.Name = "chkExt2"
            Me.chkExt2.Size = New System.Drawing.Size(516, 30)
            Me.chkExt2.TabIndex = 4
            Me.chkExt2.Text = "Le partite Locali in Locazione/Rischio Locativo comprendono i locali dell’abitazi" & _
                "one comunicante"
            Me.chkExt2.UseVisualStyleBackColor = True
            '
            'chkExt4
            '
            Me.chkExt4.AutoSize = True
            Me.TableLayoutPanel0.SetColumnSpan(Me.chkExt4, 2)
            Me.chkExt4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkExt4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkExt4.Location = New System.Drawing.Point(8, 280)
            Me.chkExt4.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
            Me.chkExt4.Name = "chkExt4"
            Me.chkExt4.Size = New System.Drawing.Size(516, 30)
            Me.chkExt4.TabIndex = 6
            Me.chkExt4.Text = "La garanzia comprende macchinari e attrezzature in leasing"
            Me.chkExt4.UseVisualStyleBackColor = True
            '
            'chkcomuneMinorRischioSismico
            '
            Me.chkcomuneMinorRischioSismico.AutoSize = True
            Me.TableLayoutPanel0.SetColumnSpan(Me.chkcomuneMinorRischioSismico, 2)
            Me.chkcomuneMinorRischioSismico.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkcomuneMinorRischioSismico.Font = New System.Drawing.Font("Tahoma", 9.0!)
            Me.chkcomuneMinorRischioSismico.Location = New System.Drawing.Point(8, 310)
            Me.chkcomuneMinorRischioSismico.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
            Me.chkcomuneMinorRischioSismico.Name = "chkcomuneMinorRischioSismico"
            Me.chkcomuneMinorRischioSismico.Size = New System.Drawing.Size(516, 30)
            Me.chkcomuneMinorRischioSismico.TabIndex = 30
            Me.chkcomuneMinorRischioSismico.Text = "Comune di minor rischio sismico"
            Me.chkcomuneMinorRischioSismico.UseVisualStyleBackColor = True
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(3, 160)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(256, 30)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Comune"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmbComune
            '
            Me.cmbComune.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbComune.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbComune.FormattingEnabled = True
            Me.cmbComune.Location = New System.Drawing.Point(265, 163)
            Me.cmbComune.Name = "cmbComune"
            Me.cmbComune.Size = New System.Drawing.Size(256, 21)
            Me.cmbComune.TabIndex = 2
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.GroupBox2)
            Me.TabPage2.Location = New System.Drawing.Point(4, 29)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Size = New System.Drawing.Size(1080, 613)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Tag = ""
            Me.TabPage2.Text = "Incendio 1"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.TableLayoutPanel2)
            Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
            Me.GroupBox2.Margin = New System.Windows.Forms.Padding(0)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
            Me.GroupBox2.Size = New System.Drawing.Size(1080, 613)
            Me.GroupBox2.TabIndex = 0
            Me.GroupBox2.TabStop = False
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.ColumnCount = 5
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
            Me.TableLayoutPanel2.Controls.Add(Me.txtIncendioAumentoMerciMesi, 3, 12)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioPremio, 4, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioBase, 0, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.cmbIncendioScelta, 2, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.desIncendioFabbricato, 1, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioFabbricato, 4, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioFabbricato, 0, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.txtPartitaIncendioFabbricato, 2, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.desIncendioContenuto, 1, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioContenuto, 4, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioContenuto, 0, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.txtPartitaIncendioContenuto, 2, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.desIncendioLocazione, 1, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioLocazione, 4, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioLocazione, 0, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.txtPartitaIncendioLocazione, 2, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.desIncendioCondutture, 1, 5)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioCondutture, 4, 5)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioCondutture, 0, 5)
            Me.TableLayoutPanel2.Controls.Add(Me.cmbIncendioConduttureMassimale, 2, 5)
            Me.TableLayoutPanel2.Controls.Add(Me.desIncendioDemolizione, 1, 6)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioDemolizione, 4, 6)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioDemolizione, 0, 6)
            Me.TableLayoutPanel2.Controls.Add(Me.cmbIncendioDemolizioneMassimale, 2, 6)
            Me.TableLayoutPanel2.Controls.Add(Me.desIncendioEventiAtmosferici, 1, 7)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioEventiAtmosferici, 4, 7)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioEventiAtmosferici, 0, 7)
            Me.TableLayoutPanel2.Controls.Add(Me.cmbIncendioEventiAtmosfericiScelta, 2, 7)
            Me.TableLayoutPanel2.Controls.Add(Me.desIncendioDanniElettrici, 1, 8)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioDanniElettrici, 4, 8)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioDanniElettrici, 0, 8)
            Me.TableLayoutPanel2.Controls.Add(Me.txtPartitaIncendioDanniElettrici, 2, 8)
            Me.TableLayoutPanel2.Controls.Add(Me.cmbIncendioDanniElettriciScelta, 3, 8)
            Me.TableLayoutPanel2.Controls.Add(Me.desIncendioDanniIndirettiA, 1, 9)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioDanniIndirettiA, 4, 9)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioDanniIndirettiA, 0, 9)
            Me.TableLayoutPanel2.Controls.Add(Me.txtPartitaIncendioDanniIndirettiA, 2, 9)
            Me.TableLayoutPanel2.Controls.Add(Me.cmbIncendioDanniIndirettiScelta, 3, 9)
            Me.TableLayoutPanel2.Controls.Add(Me.desIncendioRicorsoTerzi, 1, 11)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioRicorsoTerzi, 4, 11)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioRicorsoTerzi, 0, 11)
            Me.TableLayoutPanel2.Controls.Add(Me.txtPartitaIncendioRicorsoTerzi, 2, 11)
            Me.TableLayoutPanel2.Controls.Add(Me.desIncendioAumentoMerci, 1, 12)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioAumentoMerci, 4, 12)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioAumentoMerci, 0, 12)
            Me.TableLayoutPanel2.Controls.Add(Me.txtPartitaIncendioAumentoMerci, 2, 12)
            Me.TableLayoutPanel2.Controls.Add(Me.desIncendioCoseTrasportate, 1, 13)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioCoseTrasportate, 4, 13)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioCoseTrasportate, 0, 13)
            Me.TableLayoutPanel2.Controls.Add(Me.txtPartitaIncendioCoseTrasportate, 2, 13)
            Me.TableLayoutPanel2.Controls.Add(Me.desIncendioRefrigerati1, 1, 14)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioRefrigerati1, 4, 14)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioRefrigerati1, 0, 14)
            Me.TableLayoutPanel2.Controls.Add(Me.txtPartitaIncendioRefrigerati1, 2, 14)
            Me.TableLayoutPanel2.Controls.Add(Me.desIncendioRefrigerati2, 1, 15)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioRefrigerati2, 4, 15)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioRefrigerati2, 0, 15)
            Me.TableLayoutPanel2.Controls.Add(Me.txtPartitaIncendioRefrigerati2, 2, 15)
            Me.TableLayoutPanel2.Controls.Add(Me.lblA2, 1, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.lblB2, 2, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.lblC2, 4, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.lblD2, 0, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.cmbIncendioFormaFabbricato, 3, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.cmbIncendioFormaContenuto, 3, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.cmbIncendioFormaLocazione, 3, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.desIncendioDanniIndirettiB, 1, 10)
            Me.TableLayoutPanel2.Controls.Add(Me.txtPartitaIncendioDanniIndirettiB, 2, 10)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIncendioDanniIndirettiB, 4, 10)
            Me.TableLayoutPanel2.Controls.Add(Me.chkIncendioDanniIndirettiB, 0, 10)
            Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 13)
            Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 17
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(1074, 597)
            Me.TableLayoutPanel2.TabIndex = 0
            '
            'txtIncendioAumentoMerciMesi
            '
            Me.txtIncendioAumentoMerciMesi.Dock = System.Windows.Forms.DockStyle.Left
            Me.txtIncendioAumentoMerciMesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtIncendioAumentoMerciMesi.Location = New System.Drawing.Point(697, 373)
            Me.txtIncendioAumentoMerciMesi.Name = "txtIncendioAumentoMerciMesi"
            Me.txtIncendioAumentoMerciMesi.Size = New System.Drawing.Size(66, 22)
            Me.txtIncendioAumentoMerciMesi.TabIndex = 27
            Me.txtIncendioAumentoMerciMesi.TabStop = False
            Me.txtIncendioAumentoMerciMesi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblIncendioPremio
            '
            Me.lblIncendioPremio.AutoSize = True
            Me.lblIncendioPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioPremio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblIncendioPremio.Location = New System.Drawing.Point(971, 40)
            Me.lblIncendioPremio.Name = "lblIncendioPremio"
            Me.lblIncendioPremio.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioPremio.TabIndex = 2
            Me.lblIncendioPremio.Text = "0,00"
            Me.lblIncendioPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioBase
            '
            Me.chkIncendioBase.AutoSize = True
            Me.TableLayoutPanel2.SetColumnSpan(Me.chkIncendioBase, 2)
            Me.chkIncendioBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioBase.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkIncendioBase.Location = New System.Drawing.Point(8, 40)
            Me.chkIncendioBase.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
            Me.chkIncendioBase.Name = "chkIncendioBase"
            Me.chkIncendioBase.Size = New System.Drawing.Size(412, 30)
            Me.chkIncendioBase.TabIndex = 0
            Me.chkIncendioBase.Text = "INCENDIO"
            Me.chkIncendioBase.UseVisualStyleBackColor = True
            '
            'cmbIncendioScelta
            '
            Me.cmbIncendioScelta.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioScelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioScelta.FormattingEnabled = True
            Me.cmbIncendioScelta.Location = New System.Drawing.Point(423, 43)
            Me.cmbIncendioScelta.Name = "cmbIncendioScelta"
            Me.cmbIncendioScelta.Size = New System.Drawing.Size(268, 21)
            Me.cmbIncendioScelta.TabIndex = 0
            '
            'desIncendioFabbricato
            '
            Me.desIncendioFabbricato.AutoSize = True
            Me.desIncendioFabbricato.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioFabbricato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioFabbricato.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioFabbricato.Location = New System.Drawing.Point(58, 70)
            Me.desIncendioFabbricato.Name = "desIncendioFabbricato"
            Me.desIncendioFabbricato.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioFabbricato.TabIndex = 7
            Me.desIncendioFabbricato.Tag = "102"
            Me.desIncendioFabbricato.Text = "Fabbricato"
            Me.desIncendioFabbricato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioFabbricato
            '
            Me.lblIncendioFabbricato.AutoSize = True
            Me.lblIncendioFabbricato.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioFabbricato.Location = New System.Drawing.Point(971, 70)
            Me.lblIncendioFabbricato.Name = "lblIncendioFabbricato"
            Me.lblIncendioFabbricato.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioFabbricato.TabIndex = 8
            Me.lblIncendioFabbricato.Text = "0,00"
            Me.lblIncendioFabbricato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioFabbricato
            '
            Me.chkIncendioFabbricato.AutoSize = True
            Me.chkIncendioFabbricato.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioFabbricato.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioFabbricato.Location = New System.Drawing.Point(0, 70)
            Me.chkIncendioFabbricato.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioFabbricato.Name = "chkIncendioFabbricato"
            Me.chkIncendioFabbricato.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioFabbricato.TabIndex = 3
            Me.chkIncendioFabbricato.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioFabbricato
            '
            Me.txtPartitaIncendioFabbricato.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioFabbricato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioFabbricato.Location = New System.Drawing.Point(423, 73)
            Me.txtPartitaIncendioFabbricato.Name = "txtPartitaIncendioFabbricato"
            Me.txtPartitaIncendioFabbricato.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaIncendioFabbricato.TabIndex = 1
            Me.txtPartitaIncendioFabbricato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desIncendioContenuto
            '
            Me.desIncendioContenuto.AutoSize = True
            Me.desIncendioContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioContenuto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioContenuto.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioContenuto.Location = New System.Drawing.Point(58, 100)
            Me.desIncendioContenuto.Name = "desIncendioContenuto"
            Me.desIncendioContenuto.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioContenuto.TabIndex = 11
            Me.desIncendioContenuto.Tag = "103"
            Me.desIncendioContenuto.Text = "Contenuto"
            Me.desIncendioContenuto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioContenuto
            '
            Me.lblIncendioContenuto.AutoSize = True
            Me.lblIncendioContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioContenuto.Location = New System.Drawing.Point(971, 100)
            Me.lblIncendioContenuto.Name = "lblIncendioContenuto"
            Me.lblIncendioContenuto.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioContenuto.TabIndex = 12
            Me.lblIncendioContenuto.Text = "0,00"
            Me.lblIncendioContenuto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioContenuto
            '
            Me.chkIncendioContenuto.AutoSize = True
            Me.chkIncendioContenuto.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioContenuto.Location = New System.Drawing.Point(0, 100)
            Me.chkIncendioContenuto.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioContenuto.Name = "chkIncendioContenuto"
            Me.chkIncendioContenuto.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioContenuto.TabIndex = 6
            Me.chkIncendioContenuto.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioContenuto
            '
            Me.txtPartitaIncendioContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioContenuto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioContenuto.Location = New System.Drawing.Point(423, 103)
            Me.txtPartitaIncendioContenuto.Name = "txtPartitaIncendioContenuto"
            Me.txtPartitaIncendioContenuto.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaIncendioContenuto.TabIndex = 4
            Me.txtPartitaIncendioContenuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desIncendioLocazione
            '
            Me.desIncendioLocazione.AutoSize = True
            Me.desIncendioLocazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioLocazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioLocazione.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioLocazione.Location = New System.Drawing.Point(58, 130)
            Me.desIncendioLocazione.Name = "desIncendioLocazione"
            Me.desIncendioLocazione.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioLocazione.TabIndex = 15
            Me.desIncendioLocazione.Tag = "104"
            Me.desIncendioLocazione.Text = "Locali in locazione"
            Me.desIncendioLocazione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioLocazione
            '
            Me.lblIncendioLocazione.AutoSize = True
            Me.lblIncendioLocazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioLocazione.Location = New System.Drawing.Point(971, 130)
            Me.lblIncendioLocazione.Name = "lblIncendioLocazione"
            Me.lblIncendioLocazione.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioLocazione.TabIndex = 16
            Me.lblIncendioLocazione.Text = "0,00"
            Me.lblIncendioLocazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioLocazione
            '
            Me.chkIncendioLocazione.AutoSize = True
            Me.chkIncendioLocazione.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioLocazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioLocazione.Location = New System.Drawing.Point(0, 130)
            Me.chkIncendioLocazione.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioLocazione.Name = "chkIncendioLocazione"
            Me.chkIncendioLocazione.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioLocazione.TabIndex = 9
            Me.chkIncendioLocazione.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioLocazione
            '
            Me.txtPartitaIncendioLocazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioLocazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioLocazione.Location = New System.Drawing.Point(423, 133)
            Me.txtPartitaIncendioLocazione.Name = "txtPartitaIncendioLocazione"
            Me.txtPartitaIncendioLocazione.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaIncendioLocazione.TabIndex = 7
            Me.txtPartitaIncendioLocazione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desIncendioCondutture
            '
            Me.desIncendioCondutture.AutoSize = True
            Me.desIncendioCondutture.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioCondutture.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioCondutture.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioCondutture.Location = New System.Drawing.Point(58, 160)
            Me.desIncendioCondutture.Name = "desIncendioCondutture"
            Me.desIncendioCondutture.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioCondutture.TabIndex = 19
            Me.desIncendioCondutture.Tag = "105"
            Me.desIncendioCondutture.Text = "Spese di ricerca rottura e riparazione di condutture di acqua"
            Me.desIncendioCondutture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioCondutture
            '
            Me.lblIncendioCondutture.AutoSize = True
            Me.lblIncendioCondutture.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioCondutture.Location = New System.Drawing.Point(971, 160)
            Me.lblIncendioCondutture.Name = "lblIncendioCondutture"
            Me.lblIncendioCondutture.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioCondutture.TabIndex = 20
            Me.lblIncendioCondutture.Text = "0,00"
            Me.lblIncendioCondutture.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioCondutture
            '
            Me.chkIncendioCondutture.AutoSize = True
            Me.chkIncendioCondutture.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioCondutture.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioCondutture.Location = New System.Drawing.Point(0, 160)
            Me.chkIncendioCondutture.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioCondutture.Name = "chkIncendioCondutture"
            Me.chkIncendioCondutture.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioCondutture.TabIndex = 11
            Me.chkIncendioCondutture.UseVisualStyleBackColor = True
            '
            'cmbIncendioConduttureMassimale
            '
            Me.cmbIncendioConduttureMassimale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioConduttureMassimale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioConduttureMassimale.FormattingEnabled = True
            Me.cmbIncendioConduttureMassimale.Location = New System.Drawing.Point(423, 163)
            Me.cmbIncendioConduttureMassimale.Name = "cmbIncendioConduttureMassimale"
            Me.cmbIncendioConduttureMassimale.Size = New System.Drawing.Size(268, 21)
            Me.cmbIncendioConduttureMassimale.TabIndex = 10
            '
            'desIncendioDemolizione
            '
            Me.desIncendioDemolizione.AutoSize = True
            Me.desIncendioDemolizione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioDemolizione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioDemolizione.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioDemolizione.Location = New System.Drawing.Point(58, 190)
            Me.desIncendioDemolizione.Name = "desIncendioDemolizione"
            Me.desIncendioDemolizione.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioDemolizione.TabIndex = 23
            Me.desIncendioDemolizione.Tag = "106"
            Me.desIncendioDemolizione.Text = "Spese di demolizione, sgombero, ..."
            Me.desIncendioDemolizione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioDemolizione
            '
            Me.lblIncendioDemolizione.AutoSize = True
            Me.lblIncendioDemolizione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioDemolizione.Location = New System.Drawing.Point(971, 190)
            Me.lblIncendioDemolizione.Name = "lblIncendioDemolizione"
            Me.lblIncendioDemolizione.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioDemolizione.TabIndex = 24
            Me.lblIncendioDemolizione.Text = "0,00"
            Me.lblIncendioDemolizione.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioDemolizione
            '
            Me.chkIncendioDemolizione.AutoSize = True
            Me.chkIncendioDemolizione.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioDemolizione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioDemolizione.Location = New System.Drawing.Point(0, 190)
            Me.chkIncendioDemolizione.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioDemolizione.Name = "chkIncendioDemolizione"
            Me.chkIncendioDemolizione.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioDemolizione.TabIndex = 13
            Me.chkIncendioDemolizione.UseVisualStyleBackColor = True
            '
            'cmbIncendioDemolizioneMassimale
            '
            Me.cmbIncendioDemolizioneMassimale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioDemolizioneMassimale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioDemolizioneMassimale.FormattingEnabled = True
            Me.cmbIncendioDemolizioneMassimale.Location = New System.Drawing.Point(423, 193)
            Me.cmbIncendioDemolizioneMassimale.Name = "cmbIncendioDemolizioneMassimale"
            Me.cmbIncendioDemolizioneMassimale.Size = New System.Drawing.Size(268, 21)
            Me.cmbIncendioDemolizioneMassimale.TabIndex = 12
            '
            'desIncendioEventiAtmosferici
            '
            Me.desIncendioEventiAtmosferici.AutoSize = True
            Me.desIncendioEventiAtmosferici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioEventiAtmosferici.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioEventiAtmosferici.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioEventiAtmosferici.Location = New System.Drawing.Point(58, 220)
            Me.desIncendioEventiAtmosferici.Name = "desIncendioEventiAtmosferici"
            Me.desIncendioEventiAtmosferici.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioEventiAtmosferici.TabIndex = 27
            Me.desIncendioEventiAtmosferici.Tag = "107"
            Me.desIncendioEventiAtmosferici.Text = "Eventi Atmosferici"
            Me.desIncendioEventiAtmosferici.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioEventiAtmosferici
            '
            Me.lblIncendioEventiAtmosferici.AutoSize = True
            Me.lblIncendioEventiAtmosferici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioEventiAtmosferici.Location = New System.Drawing.Point(971, 220)
            Me.lblIncendioEventiAtmosferici.Name = "lblIncendioEventiAtmosferici"
            Me.lblIncendioEventiAtmosferici.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioEventiAtmosferici.TabIndex = 28
            Me.lblIncendioEventiAtmosferici.Text = "0,00"
            Me.lblIncendioEventiAtmosferici.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioEventiAtmosferici
            '
            Me.chkIncendioEventiAtmosferici.AutoSize = True
            Me.chkIncendioEventiAtmosferici.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioEventiAtmosferici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioEventiAtmosferici.Location = New System.Drawing.Point(0, 220)
            Me.chkIncendioEventiAtmosferici.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioEventiAtmosferici.Name = "chkIncendioEventiAtmosferici"
            Me.chkIncendioEventiAtmosferici.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioEventiAtmosferici.TabIndex = 15
            Me.chkIncendioEventiAtmosferici.UseVisualStyleBackColor = True
            '
            'cmbIncendioEventiAtmosfericiScelta
            '
            Me.cmbIncendioEventiAtmosfericiScelta.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioEventiAtmosfericiScelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioEventiAtmosfericiScelta.FormattingEnabled = True
            Me.cmbIncendioEventiAtmosfericiScelta.Location = New System.Drawing.Point(423, 223)
            Me.cmbIncendioEventiAtmosfericiScelta.Name = "cmbIncendioEventiAtmosfericiScelta"
            Me.cmbIncendioEventiAtmosfericiScelta.Size = New System.Drawing.Size(268, 21)
            Me.cmbIncendioEventiAtmosfericiScelta.TabIndex = 14
            '
            'desIncendioDanniElettrici
            '
            Me.desIncendioDanniElettrici.AutoSize = True
            Me.desIncendioDanniElettrici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioDanniElettrici.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioDanniElettrici.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioDanniElettrici.Location = New System.Drawing.Point(58, 250)
            Me.desIncendioDanniElettrici.Name = "desIncendioDanniElettrici"
            Me.desIncendioDanniElettrici.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioDanniElettrici.TabIndex = 31
            Me.desIncendioDanniElettrici.Tag = "108"
            Me.desIncendioDanniElettrici.Text = "Danni Elettrici"
            Me.desIncendioDanniElettrici.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioDanniElettrici
            '
            Me.lblIncendioDanniElettrici.AutoSize = True
            Me.lblIncendioDanniElettrici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioDanniElettrici.Location = New System.Drawing.Point(971, 250)
            Me.lblIncendioDanniElettrici.Name = "lblIncendioDanniElettrici"
            Me.lblIncendioDanniElettrici.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioDanniElettrici.TabIndex = 32
            Me.lblIncendioDanniElettrici.Text = "0,00"
            Me.lblIncendioDanniElettrici.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioDanniElettrici
            '
            Me.chkIncendioDanniElettrici.AutoSize = True
            Me.chkIncendioDanniElettrici.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioDanniElettrici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioDanniElettrici.Location = New System.Drawing.Point(0, 250)
            Me.chkIncendioDanniElettrici.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioDanniElettrici.Name = "chkIncendioDanniElettrici"
            Me.chkIncendioDanniElettrici.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioDanniElettrici.TabIndex = 18
            Me.chkIncendioDanniElettrici.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioDanniElettrici
            '
            Me.txtPartitaIncendioDanniElettrici.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioDanniElettrici.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioDanniElettrici.Location = New System.Drawing.Point(423, 253)
            Me.txtPartitaIncendioDanniElettrici.Name = "txtPartitaIncendioDanniElettrici"
            Me.txtPartitaIncendioDanniElettrici.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaIncendioDanniElettrici.TabIndex = 16
            Me.txtPartitaIncendioDanniElettrici.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'cmbIncendioDanniElettriciScelta
            '
            Me.cmbIncendioDanniElettriciScelta.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioDanniElettriciScelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioDanniElettriciScelta.FormattingEnabled = True
            Me.cmbIncendioDanniElettriciScelta.Location = New System.Drawing.Point(697, 253)
            Me.cmbIncendioDanniElettriciScelta.Name = "cmbIncendioDanniElettriciScelta"
            Me.cmbIncendioDanniElettriciScelta.Size = New System.Drawing.Size(268, 21)
            Me.cmbIncendioDanniElettriciScelta.TabIndex = 17
            '
            'desIncendioDanniIndirettiA
            '
            Me.desIncendioDanniIndirettiA.AutoSize = True
            Me.desIncendioDanniIndirettiA.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioDanniIndirettiA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioDanniIndirettiA.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioDanniIndirettiA.Location = New System.Drawing.Point(58, 280)
            Me.desIncendioDanniIndirettiA.Name = "desIncendioDanniIndirettiA"
            Me.desIncendioDanniIndirettiA.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioDanniIndirettiA.TabIndex = 36
            Me.desIncendioDanniIndirettiA.Tag = "109"
            Me.desIncendioDanniIndirettiA.Text = "Danni Indiretti basic"
            Me.desIncendioDanniIndirettiA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioDanniIndirettiA
            '
            Me.lblIncendioDanniIndirettiA.AutoSize = True
            Me.lblIncendioDanniIndirettiA.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioDanniIndirettiA.Location = New System.Drawing.Point(971, 280)
            Me.lblIncendioDanniIndirettiA.Name = "lblIncendioDanniIndirettiA"
            Me.lblIncendioDanniIndirettiA.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioDanniIndirettiA.TabIndex = 37
            Me.lblIncendioDanniIndirettiA.Text = "0,00"
            Me.lblIncendioDanniIndirettiA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioDanniIndirettiA
            '
            Me.chkIncendioDanniIndirettiA.AutoSize = True
            Me.chkIncendioDanniIndirettiA.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioDanniIndirettiA.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioDanniIndirettiA.Location = New System.Drawing.Point(0, 280)
            Me.chkIncendioDanniIndirettiA.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioDanniIndirettiA.Name = "chkIncendioDanniIndirettiA"
            Me.chkIncendioDanniIndirettiA.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioDanniIndirettiA.TabIndex = 21
            Me.chkIncendioDanniIndirettiA.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioDanniIndirettiA
            '
            Me.txtPartitaIncendioDanniIndirettiA.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioDanniIndirettiA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioDanniIndirettiA.Location = New System.Drawing.Point(423, 283)
            Me.txtPartitaIncendioDanniIndirettiA.Name = "txtPartitaIncendioDanniIndirettiA"
            Me.txtPartitaIncendioDanniIndirettiA.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaIncendioDanniIndirettiA.TabIndex = 19
            Me.txtPartitaIncendioDanniIndirettiA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'cmbIncendioDanniIndirettiScelta
            '
            Me.cmbIncendioDanniIndirettiScelta.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioDanniIndirettiScelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioDanniIndirettiScelta.FormattingEnabled = True
            Me.cmbIncendioDanniIndirettiScelta.Location = New System.Drawing.Point(697, 283)
            Me.cmbIncendioDanniIndirettiScelta.Name = "cmbIncendioDanniIndirettiScelta"
            Me.cmbIncendioDanniIndirettiScelta.Size = New System.Drawing.Size(268, 21)
            Me.cmbIncendioDanniIndirettiScelta.TabIndex = 20
            '
            'desIncendioRicorsoTerzi
            '
            Me.desIncendioRicorsoTerzi.AutoSize = True
            Me.desIncendioRicorsoTerzi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioRicorsoTerzi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioRicorsoTerzi.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioRicorsoTerzi.Location = New System.Drawing.Point(58, 340)
            Me.desIncendioRicorsoTerzi.Name = "desIncendioRicorsoTerzi"
            Me.desIncendioRicorsoTerzi.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioRicorsoTerzi.TabIndex = 41
            Me.desIncendioRicorsoTerzi.Tag = "110"
            Me.desIncendioRicorsoTerzi.Text = "Ricorso terzi"
            Me.desIncendioRicorsoTerzi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioRicorsoTerzi
            '
            Me.lblIncendioRicorsoTerzi.AutoSize = True
            Me.lblIncendioRicorsoTerzi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioRicorsoTerzi.Location = New System.Drawing.Point(971, 340)
            Me.lblIncendioRicorsoTerzi.Name = "lblIncendioRicorsoTerzi"
            Me.lblIncendioRicorsoTerzi.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioRicorsoTerzi.TabIndex = 42
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
            Me.chkIncendioRicorsoTerzi.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioRicorsoTerzi.TabIndex = 25
            Me.chkIncendioRicorsoTerzi.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioRicorsoTerzi
            '
            Me.txtPartitaIncendioRicorsoTerzi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioRicorsoTerzi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioRicorsoTerzi.Location = New System.Drawing.Point(423, 343)
            Me.txtPartitaIncendioRicorsoTerzi.Name = "txtPartitaIncendioRicorsoTerzi"
            Me.txtPartitaIncendioRicorsoTerzi.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaIncendioRicorsoTerzi.TabIndex = 24
            Me.txtPartitaIncendioRicorsoTerzi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desIncendioAumentoMerci
            '
            Me.desIncendioAumentoMerci.AutoSize = True
            Me.desIncendioAumentoMerci.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioAumentoMerci.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioAumentoMerci.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioAumentoMerci.Location = New System.Drawing.Point(58, 370)
            Me.desIncendioAumentoMerci.Name = "desIncendioAumentoMerci"
            Me.desIncendioAumentoMerci.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioAumentoMerci.TabIndex = 45
            Me.desIncendioAumentoMerci.Tag = "111"
            Me.desIncendioAumentoMerci.Text = "Aumento periodico merci assicurate"
            Me.desIncendioAumentoMerci.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioAumentoMerci
            '
            Me.lblIncendioAumentoMerci.AutoSize = True
            Me.lblIncendioAumentoMerci.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioAumentoMerci.Location = New System.Drawing.Point(971, 370)
            Me.lblIncendioAumentoMerci.Name = "lblIncendioAumentoMerci"
            Me.lblIncendioAumentoMerci.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioAumentoMerci.TabIndex = 46
            Me.lblIncendioAumentoMerci.Text = "0,00"
            Me.lblIncendioAumentoMerci.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioAumentoMerci
            '
            Me.chkIncendioAumentoMerci.AutoSize = True
            Me.chkIncendioAumentoMerci.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioAumentoMerci.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioAumentoMerci.Location = New System.Drawing.Point(0, 370)
            Me.chkIncendioAumentoMerci.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioAumentoMerci.Name = "chkIncendioAumentoMerci"
            Me.chkIncendioAumentoMerci.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioAumentoMerci.TabIndex = 28
            Me.chkIncendioAumentoMerci.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioAumentoMerci
            '
            Me.txtPartitaIncendioAumentoMerci.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioAumentoMerci.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioAumentoMerci.Location = New System.Drawing.Point(423, 373)
            Me.txtPartitaIncendioAumentoMerci.Name = "txtPartitaIncendioAumentoMerci"
            Me.txtPartitaIncendioAumentoMerci.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaIncendioAumentoMerci.TabIndex = 26
            Me.txtPartitaIncendioAumentoMerci.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desIncendioCoseTrasportate
            '
            Me.desIncendioCoseTrasportate.AutoSize = True
            Me.desIncendioCoseTrasportate.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioCoseTrasportate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioCoseTrasportate.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioCoseTrasportate.Location = New System.Drawing.Point(58, 400)
            Me.desIncendioCoseTrasportate.Name = "desIncendioCoseTrasportate"
            Me.desIncendioCoseTrasportate.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioCoseTrasportate.TabIndex = 49
            Me.desIncendioCoseTrasportate.Tag = "112"
            Me.desIncendioCoseTrasportate.Text = "Merci ed Attrezzature trasportate"
            Me.desIncendioCoseTrasportate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioCoseTrasportate
            '
            Me.lblIncendioCoseTrasportate.AutoSize = True
            Me.lblIncendioCoseTrasportate.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioCoseTrasportate.Location = New System.Drawing.Point(971, 400)
            Me.lblIncendioCoseTrasportate.Name = "lblIncendioCoseTrasportate"
            Me.lblIncendioCoseTrasportate.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioCoseTrasportate.TabIndex = 50
            Me.lblIncendioCoseTrasportate.Text = "0,00"
            Me.lblIncendioCoseTrasportate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioCoseTrasportate
            '
            Me.chkIncendioCoseTrasportate.AutoSize = True
            Me.chkIncendioCoseTrasportate.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioCoseTrasportate.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioCoseTrasportate.Location = New System.Drawing.Point(0, 400)
            Me.chkIncendioCoseTrasportate.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioCoseTrasportate.Name = "chkIncendioCoseTrasportate"
            Me.chkIncendioCoseTrasportate.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioCoseTrasportate.TabIndex = 30
            Me.chkIncendioCoseTrasportate.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioCoseTrasportate
            '
            Me.txtPartitaIncendioCoseTrasportate.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioCoseTrasportate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioCoseTrasportate.Location = New System.Drawing.Point(423, 403)
            Me.txtPartitaIncendioCoseTrasportate.Name = "txtPartitaIncendioCoseTrasportate"
            Me.txtPartitaIncendioCoseTrasportate.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaIncendioCoseTrasportate.TabIndex = 29
            Me.txtPartitaIncendioCoseTrasportate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desIncendioRefrigerati1
            '
            Me.desIncendioRefrigerati1.AutoSize = True
            Me.desIncendioRefrigerati1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioRefrigerati1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioRefrigerati1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioRefrigerati1.Location = New System.Drawing.Point(58, 430)
            Me.desIncendioRefrigerati1.Name = "desIncendioRefrigerati1"
            Me.desIncendioRefrigerati1.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioRefrigerati1.TabIndex = 53
            Me.desIncendioRefrigerati1.Tag = "113"
            Me.desIncendioRefrigerati1.Text = "Danni a merci in refrigerazione"
            Me.desIncendioRefrigerati1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioRefrigerati1
            '
            Me.lblIncendioRefrigerati1.AutoSize = True
            Me.lblIncendioRefrigerati1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioRefrigerati1.Location = New System.Drawing.Point(971, 430)
            Me.lblIncendioRefrigerati1.Name = "lblIncendioRefrigerati1"
            Me.lblIncendioRefrigerati1.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioRefrigerati1.TabIndex = 54
            Me.lblIncendioRefrigerati1.Text = "0,00"
            Me.lblIncendioRefrigerati1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioRefrigerati1
            '
            Me.chkIncendioRefrigerati1.AutoSize = True
            Me.chkIncendioRefrigerati1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioRefrigerati1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioRefrigerati1.Location = New System.Drawing.Point(0, 430)
            Me.chkIncendioRefrigerati1.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioRefrigerati1.Name = "chkIncendioRefrigerati1"
            Me.chkIncendioRefrigerati1.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioRefrigerati1.TabIndex = 32
            Me.chkIncendioRefrigerati1.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioRefrigerati1
            '
            Me.txtPartitaIncendioRefrigerati1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioRefrigerati1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioRefrigerati1.Location = New System.Drawing.Point(423, 433)
            Me.txtPartitaIncendioRefrigerati1.Name = "txtPartitaIncendioRefrigerati1"
            Me.txtPartitaIncendioRefrigerati1.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaIncendioRefrigerati1.TabIndex = 31
            Me.txtPartitaIncendioRefrigerati1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desIncendioRefrigerati2
            '
            Me.desIncendioRefrigerati2.AutoSize = True
            Me.desIncendioRefrigerati2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioRefrigerati2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioRefrigerati2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioRefrigerati2.Location = New System.Drawing.Point(58, 460)
            Me.desIncendioRefrigerati2.Name = "desIncendioRefrigerati2"
            Me.desIncendioRefrigerati2.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioRefrigerati2.TabIndex = 57
            Me.desIncendioRefrigerati2.Tag = "114"
            Me.desIncendioRefrigerati2.Text = "Danni a merci in refrigerazione (con impianto di allarme)"
            Me.desIncendioRefrigerati2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioRefrigerati2
            '
            Me.lblIncendioRefrigerati2.AutoSize = True
            Me.lblIncendioRefrigerati2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioRefrigerati2.Location = New System.Drawing.Point(971, 460)
            Me.lblIncendioRefrigerati2.Name = "lblIncendioRefrigerati2"
            Me.lblIncendioRefrigerati2.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioRefrigerati2.TabIndex = 58
            Me.lblIncendioRefrigerati2.Text = "0,00"
            Me.lblIncendioRefrigerati2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioRefrigerati2
            '
            Me.chkIncendioRefrigerati2.AutoSize = True
            Me.chkIncendioRefrigerati2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioRefrigerati2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioRefrigerati2.Location = New System.Drawing.Point(0, 460)
            Me.chkIncendioRefrigerati2.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioRefrigerati2.Name = "chkIncendioRefrigerati2"
            Me.chkIncendioRefrigerati2.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioRefrigerati2.TabIndex = 34
            Me.chkIncendioRefrigerati2.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioRefrigerati2
            '
            Me.txtPartitaIncendioRefrigerati2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioRefrigerati2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioRefrigerati2.Location = New System.Drawing.Point(423, 463)
            Me.txtPartitaIncendioRefrigerati2.Name = "txtPartitaIncendioRefrigerati2"
            Me.txtPartitaIncendioRefrigerati2.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaIncendioRefrigerati2.TabIndex = 33
            Me.txtPartitaIncendioRefrigerati2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblA2
            '
            Me.lblA2.AutoSize = True
            Me.lblA2.BackColor = System.Drawing.Color.Khaki
            Me.lblA2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblA2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblA2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblA2.Location = New System.Drawing.Point(58, 0)
            Me.lblA2.Name = "lblA2"
            Me.lblA2.Size = New System.Drawing.Size(359, 40)
            Me.lblA2.TabIndex = 61
            Me.lblA2.Text = "Partita / Garanzia"
            Me.lblA2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblB2
            '
            Me.lblB2.AutoSize = True
            Me.lblB2.BackColor = System.Drawing.Color.Khaki
            Me.lblB2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.TableLayoutPanel2.SetColumnSpan(Me.lblB2, 2)
            Me.lblB2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblB2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblB2.Location = New System.Drawing.Point(423, 0)
            Me.lblB2.Name = "lblB2"
            Me.lblB2.Size = New System.Drawing.Size(542, 40)
            Me.lblB2.TabIndex = 62
            Me.lblB2.Text = "Parametri/Condizioni"
            Me.lblB2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblC2
            '
            Me.lblC2.AutoSize = True
            Me.lblC2.BackColor = System.Drawing.Color.Khaki
            Me.lblC2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblC2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblC2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblC2.Location = New System.Drawing.Point(971, 0)
            Me.lblC2.Name = "lblC2"
            Me.lblC2.Size = New System.Drawing.Size(100, 40)
            Me.lblC2.TabIndex = 63
            Me.lblC2.Text = "Premio"
            Me.lblC2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblD2
            '
            Me.lblD2.AutoSize = True
            Me.lblD2.BackColor = System.Drawing.Color.Khaki
            Me.lblD2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblD2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblD2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblD2.Location = New System.Drawing.Point(3, 0)
            Me.lblD2.Name = "lblD2"
            Me.lblD2.Size = New System.Drawing.Size(49, 40)
            Me.lblD2.TabIndex = 64
            Me.lblD2.Text = "Scelto"
            Me.lblD2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cmbIncendioFormaFabbricato
            '
            Me.cmbIncendioFormaFabbricato.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioFormaFabbricato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioFormaFabbricato.FormattingEnabled = True
            Me.cmbIncendioFormaFabbricato.Location = New System.Drawing.Point(697, 73)
            Me.cmbIncendioFormaFabbricato.Name = "cmbIncendioFormaFabbricato"
            Me.cmbIncendioFormaFabbricato.Size = New System.Drawing.Size(268, 21)
            Me.cmbIncendioFormaFabbricato.TabIndex = 2
            '
            'cmbIncendioFormaContenuto
            '
            Me.cmbIncendioFormaContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioFormaContenuto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioFormaContenuto.FormattingEnabled = True
            Me.cmbIncendioFormaContenuto.Location = New System.Drawing.Point(697, 103)
            Me.cmbIncendioFormaContenuto.Name = "cmbIncendioFormaContenuto"
            Me.cmbIncendioFormaContenuto.Size = New System.Drawing.Size(268, 21)
            Me.cmbIncendioFormaContenuto.TabIndex = 5
            '
            'cmbIncendioFormaLocazione
            '
            Me.cmbIncendioFormaLocazione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioFormaLocazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioFormaLocazione.FormattingEnabled = True
            Me.cmbIncendioFormaLocazione.Location = New System.Drawing.Point(697, 133)
            Me.cmbIncendioFormaLocazione.Name = "cmbIncendioFormaLocazione"
            Me.cmbIncendioFormaLocazione.Size = New System.Drawing.Size(268, 21)
            Me.cmbIncendioFormaLocazione.TabIndex = 8
            '
            'desIncendioDanniIndirettiB
            '
            Me.desIncendioDanniIndirettiB.AutoSize = True
            Me.desIncendioDanniIndirettiB.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioDanniIndirettiB.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioDanniIndirettiB.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioDanniIndirettiB.Location = New System.Drawing.Point(58, 310)
            Me.desIncendioDanniIndirettiB.Name = "desIncendioDanniIndirettiB"
            Me.desIncendioDanniIndirettiB.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioDanniIndirettiB.TabIndex = 36
            Me.desIncendioDanniIndirettiB.Tag = "109"
            Me.desIncendioDanniIndirettiB.Text = "Danni Indiretti - maggiori costi"
            Me.desIncendioDanniIndirettiB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPartitaIncendioDanniIndirettiB
            '
            Me.txtPartitaIncendioDanniIndirettiB.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioDanniIndirettiB.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioDanniIndirettiB.Location = New System.Drawing.Point(423, 313)
            Me.txtPartitaIncendioDanniIndirettiB.Name = "txtPartitaIncendioDanniIndirettiB"
            Me.txtPartitaIncendioDanniIndirettiB.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaIncendioDanniIndirettiB.TabIndex = 22
            Me.txtPartitaIncendioDanniIndirettiB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblIncendioDanniIndirettiB
            '
            Me.lblIncendioDanniIndirettiB.AutoSize = True
            Me.lblIncendioDanniIndirettiB.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioDanniIndirettiB.Location = New System.Drawing.Point(971, 310)
            Me.lblIncendioDanniIndirettiB.Name = "lblIncendioDanniIndirettiB"
            Me.lblIncendioDanniIndirettiB.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioDanniIndirettiB.TabIndex = 37
            Me.lblIncendioDanniIndirettiB.Text = "0,00"
            Me.lblIncendioDanniIndirettiB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioDanniIndirettiB
            '
            Me.chkIncendioDanniIndirettiB.AutoSize = True
            Me.chkIncendioDanniIndirettiB.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioDanniIndirettiB.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioDanniIndirettiB.Location = New System.Drawing.Point(0, 310)
            Me.chkIncendioDanniIndirettiB.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioDanniIndirettiB.Name = "chkIncendioDanniIndirettiB"
            Me.chkIncendioDanniIndirettiB.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioDanniIndirettiB.TabIndex = 23
            Me.chkIncendioDanniIndirettiB.UseVisualStyleBackColor = True
            '
            'TabPage3
            '
            Me.TabPage3.Controls.Add(Me.GroupBox3)
            Me.TabPage3.Location = New System.Drawing.Point(4, 29)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Size = New System.Drawing.Size(1080, 613)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Tag = ""
            Me.TabPage3.Text = "Incendio 2"
            Me.TabPage3.UseVisualStyleBackColor = True
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.TableLayoutPanel3)
            Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
            Me.GroupBox3.Margin = New System.Windows.Forms.Padding(0)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
            Me.GroupBox3.Size = New System.Drawing.Size(1080, 613)
            Me.GroupBox3.TabIndex = 0
            Me.GroupBox3.TabStop = False
            '
            'TableLayoutPanel3
            '
            Me.TableLayoutPanel3.ColumnCount = 5
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
            Me.TableLayoutPanel3.Controls.Add(Me.desIncendioLastre, 1, 1)
            Me.TableLayoutPanel3.Controls.Add(Me.lblIncendioLastre, 4, 1)
            Me.TableLayoutPanel3.Controls.Add(Me.chkIncendioLastre, 0, 1)
            Me.TableLayoutPanel3.Controls.Add(Me.txtPartitaIncendioLastre, 2, 1)
            Me.TableLayoutPanel3.Controls.Add(Me.desIncendioPannelliSolari, 1, 2)
            Me.TableLayoutPanel3.Controls.Add(Me.lblIncendioPannelliSolari, 4, 2)
            Me.TableLayoutPanel3.Controls.Add(Me.chkIncendioPannelliSolari, 0, 2)
            Me.TableLayoutPanel3.Controls.Add(Me.txtPartitaIncendioPannelliSolari, 2, 2)
            Me.TableLayoutPanel3.Controls.Add(Me.desIncendioRicetteMediche, 1, 3)
            Me.TableLayoutPanel3.Controls.Add(Me.lblIncendioRicetteMediche, 4, 3)
            Me.TableLayoutPanel3.Controls.Add(Me.chkIncendioRicetteMediche, 0, 3)
            Me.TableLayoutPanel3.Controls.Add(Me.txtPartitaIncendioRicetteMediche, 2, 3)
            Me.TableLayoutPanel3.Controls.Add(Me.desIncendioSpeseAccessorie, 1, 4)
            Me.TableLayoutPanel3.Controls.Add(Me.lblIncendioSpeseAccessorie, 4, 4)
            Me.TableLayoutPanel3.Controls.Add(Me.chkIncendioSpeseAccessorie, 0, 4)
            Me.TableLayoutPanel3.Controls.Add(Me.desIncendioGrandineFragili, 1, 5)
            Me.TableLayoutPanel3.Controls.Add(Me.lblIncendioGrandineFragili, 4, 5)
            Me.TableLayoutPanel3.Controls.Add(Me.chkIncendioGrandineFragili, 0, 5)
            Me.TableLayoutPanel3.Controls.Add(Me.desIncendioAttiVandaliciDolosi, 1, 6)
            Me.TableLayoutPanel3.Controls.Add(Me.lblIncendioAttiVandaliciDolosi, 4, 6)
            Me.TableLayoutPanel3.Controls.Add(Me.chkIncendioAttiVandaliciDolosi, 0, 6)
            Me.TableLayoutPanel3.Controls.Add(Me.desIncendioFabbricatiAperti1, 1, 7)
            Me.TableLayoutPanel3.Controls.Add(Me.lblIncendioFabbricatiAperti1, 4, 7)
            Me.TableLayoutPanel3.Controls.Add(Me.chkIncendioFabbricatiAperti1, 0, 7)
            Me.TableLayoutPanel3.Controls.Add(Me.desIncendioFabbricatiAperti2, 1, 8)
            Me.TableLayoutPanel3.Controls.Add(Me.lblIncendioFabbricatiAperti2, 4, 8)
            Me.TableLayoutPanel3.Controls.Add(Me.chkIncendioFabbricatiAperti2, 0, 8)
            Me.TableLayoutPanel3.Controls.Add(Me.desIncendioPreziosi, 1, 9)
            Me.TableLayoutPanel3.Controls.Add(Me.lblIncendioPreziosi, 4, 9)
            Me.TableLayoutPanel3.Controls.Add(Me.chkIncendioPreziosi, 0, 9)
            Me.TableLayoutPanel3.Controls.Add(Me.desIncendioSistemiProtezione, 1, 10)
            Me.TableLayoutPanel3.Controls.Add(Me.lblIncendioSistemiProtezione, 4, 10)
            Me.TableLayoutPanel3.Controls.Add(Me.chkIncendioSistemiProtezione, 0, 10)
            Me.TableLayoutPanel3.Controls.Add(Me.desIncendioCommercioAmbulante, 1, 11)
            Me.TableLayoutPanel3.Controls.Add(Me.lblIncendioCommercioAmbulante, 4, 11)
            Me.TableLayoutPanel3.Controls.Add(Me.chkIncendioCommercioAmbulante, 0, 11)
            Me.TableLayoutPanel3.Controls.Add(Me.desIncendioFranchigia, 1, 12)
            Me.TableLayoutPanel3.Controls.Add(Me.lblIncendioFranchigia, 4, 12)
            Me.TableLayoutPanel3.Controls.Add(Me.chkIncendioFranchigia, 0, 12)
            Me.TableLayoutPanel3.Controls.Add(Me.cmbIncendioFranchigiaFranchigia, 2, 12)
            Me.TableLayoutPanel3.Controls.Add(Me.lblA3, 1, 0)
            Me.TableLayoutPanel3.Controls.Add(Me.lblB3, 2, 0)
            Me.TableLayoutPanel3.Controls.Add(Me.lblC3, 4, 0)
            Me.TableLayoutPanel3.Controls.Add(Me.lblD3, 0, 0)
            Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 13)
            Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
            Me.TableLayoutPanel3.RowCount = 14
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel3.Size = New System.Drawing.Size(1074, 597)
            Me.TableLayoutPanel3.TabIndex = 0
            '
            'desIncendioLastre
            '
            Me.desIncendioLastre.AutoSize = True
            Me.desIncendioLastre.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioLastre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioLastre.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioLastre.Location = New System.Drawing.Point(58, 40)
            Me.desIncendioLastre.Name = "desIncendioLastre"
            Me.desIncendioLastre.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioLastre.TabIndex = 0
            Me.desIncendioLastre.Tag = "115"
            Me.desIncendioLastre.Text = "Lastre"
            Me.desIncendioLastre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioLastre
            '
            Me.lblIncendioLastre.AutoSize = True
            Me.lblIncendioLastre.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioLastre.Location = New System.Drawing.Point(971, 40)
            Me.lblIncendioLastre.Name = "lblIncendioLastre"
            Me.lblIncendioLastre.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioLastre.TabIndex = 1
            Me.lblIncendioLastre.Text = "0,00"
            Me.lblIncendioLastre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioLastre
            '
            Me.chkIncendioLastre.AutoSize = True
            Me.chkIncendioLastre.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioLastre.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioLastre.Location = New System.Drawing.Point(0, 40)
            Me.chkIncendioLastre.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioLastre.Name = "chkIncendioLastre"
            Me.chkIncendioLastre.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioLastre.TabIndex = 1
            Me.chkIncendioLastre.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioLastre
            '
            Me.txtPartitaIncendioLastre.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioLastre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioLastre.Location = New System.Drawing.Point(423, 43)
            Me.txtPartitaIncendioLastre.Name = "txtPartitaIncendioLastre"
            Me.txtPartitaIncendioLastre.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaIncendioLastre.TabIndex = 0
            Me.txtPartitaIncendioLastre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desIncendioPannelliSolari
            '
            Me.desIncendioPannelliSolari.AutoSize = True
            Me.desIncendioPannelliSolari.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioPannelliSolari.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioPannelliSolari.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioPannelliSolari.Location = New System.Drawing.Point(58, 70)
            Me.desIncendioPannelliSolari.Name = "desIncendioPannelliSolari"
            Me.desIncendioPannelliSolari.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioPannelliSolari.TabIndex = 4
            Me.desIncendioPannelliSolari.Tag = "116"
            Me.desIncendioPannelliSolari.Text = "Pannelli fotovoltaici e solari termici"
            Me.desIncendioPannelliSolari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioPannelliSolari
            '
            Me.lblIncendioPannelliSolari.AutoSize = True
            Me.lblIncendioPannelliSolari.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioPannelliSolari.Location = New System.Drawing.Point(971, 70)
            Me.lblIncendioPannelliSolari.Name = "lblIncendioPannelliSolari"
            Me.lblIncendioPannelliSolari.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioPannelliSolari.TabIndex = 5
            Me.lblIncendioPannelliSolari.Text = "0,00"
            Me.lblIncendioPannelliSolari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioPannelliSolari
            '
            Me.chkIncendioPannelliSolari.AutoSize = True
            Me.chkIncendioPannelliSolari.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioPannelliSolari.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioPannelliSolari.Location = New System.Drawing.Point(0, 70)
            Me.chkIncendioPannelliSolari.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioPannelliSolari.Name = "chkIncendioPannelliSolari"
            Me.chkIncendioPannelliSolari.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioPannelliSolari.TabIndex = 3
            Me.chkIncendioPannelliSolari.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioPannelliSolari
            '
            Me.txtPartitaIncendioPannelliSolari.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioPannelliSolari.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioPannelliSolari.Location = New System.Drawing.Point(423, 73)
            Me.txtPartitaIncendioPannelliSolari.Name = "txtPartitaIncendioPannelliSolari"
            Me.txtPartitaIncendioPannelliSolari.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaIncendioPannelliSolari.TabIndex = 2
            Me.txtPartitaIncendioPannelliSolari.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desIncendioRicetteMediche
            '
            Me.desIncendioRicetteMediche.AutoSize = True
            Me.desIncendioRicetteMediche.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioRicetteMediche.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioRicetteMediche.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioRicetteMediche.Location = New System.Drawing.Point(58, 100)
            Me.desIncendioRicetteMediche.Name = "desIncendioRicetteMediche"
            Me.desIncendioRicetteMediche.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioRicetteMediche.TabIndex = 8
            Me.desIncendioRicetteMediche.Tag = "117"
            Me.desIncendioRicetteMediche.Text = "Ricette mediche"
            Me.desIncendioRicetteMediche.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioRicetteMediche
            '
            Me.lblIncendioRicetteMediche.AutoSize = True
            Me.lblIncendioRicetteMediche.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioRicetteMediche.Location = New System.Drawing.Point(971, 100)
            Me.lblIncendioRicetteMediche.Name = "lblIncendioRicetteMediche"
            Me.lblIncendioRicetteMediche.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioRicetteMediche.TabIndex = 9
            Me.lblIncendioRicetteMediche.Text = "0,00"
            Me.lblIncendioRicetteMediche.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioRicetteMediche
            '
            Me.chkIncendioRicetteMediche.AutoSize = True
            Me.chkIncendioRicetteMediche.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioRicetteMediche.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioRicetteMediche.Location = New System.Drawing.Point(0, 100)
            Me.chkIncendioRicetteMediche.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioRicetteMediche.Name = "chkIncendioRicetteMediche"
            Me.chkIncendioRicetteMediche.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioRicetteMediche.TabIndex = 5
            Me.chkIncendioRicetteMediche.UseVisualStyleBackColor = True
            '
            'txtPartitaIncendioRicetteMediche
            '
            Me.txtPartitaIncendioRicetteMediche.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaIncendioRicetteMediche.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaIncendioRicetteMediche.Location = New System.Drawing.Point(423, 103)
            Me.txtPartitaIncendioRicetteMediche.Name = "txtPartitaIncendioRicetteMediche"
            Me.txtPartitaIncendioRicetteMediche.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaIncendioRicetteMediche.TabIndex = 4
            Me.txtPartitaIncendioRicetteMediche.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desIncendioSpeseAccessorie
            '
            Me.desIncendioSpeseAccessorie.AutoSize = True
            Me.desIncendioSpeseAccessorie.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioSpeseAccessorie.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioSpeseAccessorie.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioSpeseAccessorie.Location = New System.Drawing.Point(58, 130)
            Me.desIncendioSpeseAccessorie.Name = "desIncendioSpeseAccessorie"
            Me.desIncendioSpeseAccessorie.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioSpeseAccessorie.TabIndex = 12
            Me.desIncendioSpeseAccessorie.Tag = "118"
            Me.desIncendioSpeseAccessorie.Text = "Spese accessorie"
            Me.desIncendioSpeseAccessorie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioSpeseAccessorie
            '
            Me.lblIncendioSpeseAccessorie.AutoSize = True
            Me.lblIncendioSpeseAccessorie.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioSpeseAccessorie.Location = New System.Drawing.Point(971, 130)
            Me.lblIncendioSpeseAccessorie.Name = "lblIncendioSpeseAccessorie"
            Me.lblIncendioSpeseAccessorie.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioSpeseAccessorie.TabIndex = 13
            Me.lblIncendioSpeseAccessorie.Text = "0,00"
            Me.lblIncendioSpeseAccessorie.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioSpeseAccessorie
            '
            Me.chkIncendioSpeseAccessorie.AutoSize = True
            Me.chkIncendioSpeseAccessorie.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioSpeseAccessorie.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioSpeseAccessorie.Location = New System.Drawing.Point(0, 130)
            Me.chkIncendioSpeseAccessorie.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioSpeseAccessorie.Name = "chkIncendioSpeseAccessorie"
            Me.chkIncendioSpeseAccessorie.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioSpeseAccessorie.TabIndex = 6
            Me.chkIncendioSpeseAccessorie.UseVisualStyleBackColor = True
            '
            'desIncendioGrandineFragili
            '
            Me.desIncendioGrandineFragili.AutoSize = True
            Me.desIncendioGrandineFragili.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioGrandineFragili.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioGrandineFragili.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioGrandineFragili.Location = New System.Drawing.Point(58, 160)
            Me.desIncendioGrandineFragili.Name = "desIncendioGrandineFragili"
            Me.desIncendioGrandineFragili.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioGrandineFragili.TabIndex = 15
            Me.desIncendioGrandineFragili.Tag = "119"
            Me.desIncendioGrandineFragili.Text = "Grandine su fragili"
            Me.desIncendioGrandineFragili.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioGrandineFragili
            '
            Me.lblIncendioGrandineFragili.AutoSize = True
            Me.lblIncendioGrandineFragili.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioGrandineFragili.Location = New System.Drawing.Point(971, 160)
            Me.lblIncendioGrandineFragili.Name = "lblIncendioGrandineFragili"
            Me.lblIncendioGrandineFragili.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioGrandineFragili.TabIndex = 16
            Me.lblIncendioGrandineFragili.Text = "0,00"
            Me.lblIncendioGrandineFragili.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioGrandineFragili
            '
            Me.chkIncendioGrandineFragili.AutoSize = True
            Me.chkIncendioGrandineFragili.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioGrandineFragili.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioGrandineFragili.Location = New System.Drawing.Point(0, 160)
            Me.chkIncendioGrandineFragili.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioGrandineFragili.Name = "chkIncendioGrandineFragili"
            Me.chkIncendioGrandineFragili.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioGrandineFragili.TabIndex = 7
            Me.chkIncendioGrandineFragili.UseVisualStyleBackColor = True
            '
            'desIncendioAttiVandaliciDolosi
            '
            Me.desIncendioAttiVandaliciDolosi.AutoSize = True
            Me.desIncendioAttiVandaliciDolosi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioAttiVandaliciDolosi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioAttiVandaliciDolosi.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioAttiVandaliciDolosi.Location = New System.Drawing.Point(58, 190)
            Me.desIncendioAttiVandaliciDolosi.Name = "desIncendioAttiVandaliciDolosi"
            Me.desIncendioAttiVandaliciDolosi.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioAttiVandaliciDolosi.TabIndex = 18
            Me.desIncendioAttiVandaliciDolosi.Tag = "120"
            Me.desIncendioAttiVandaliciDolosi.Text = "Atti vandalici e dolosi"
            Me.desIncendioAttiVandaliciDolosi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioAttiVandaliciDolosi
            '
            Me.lblIncendioAttiVandaliciDolosi.AutoSize = True
            Me.lblIncendioAttiVandaliciDolosi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioAttiVandaliciDolosi.Location = New System.Drawing.Point(971, 190)
            Me.lblIncendioAttiVandaliciDolosi.Name = "lblIncendioAttiVandaliciDolosi"
            Me.lblIncendioAttiVandaliciDolosi.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioAttiVandaliciDolosi.TabIndex = 19
            Me.lblIncendioAttiVandaliciDolosi.Text = "0,00"
            Me.lblIncendioAttiVandaliciDolosi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioAttiVandaliciDolosi
            '
            Me.chkIncendioAttiVandaliciDolosi.AutoSize = True
            Me.chkIncendioAttiVandaliciDolosi.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioAttiVandaliciDolosi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioAttiVandaliciDolosi.Location = New System.Drawing.Point(0, 190)
            Me.chkIncendioAttiVandaliciDolosi.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioAttiVandaliciDolosi.Name = "chkIncendioAttiVandaliciDolosi"
            Me.chkIncendioAttiVandaliciDolosi.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioAttiVandaliciDolosi.TabIndex = 8
            Me.chkIncendioAttiVandaliciDolosi.UseVisualStyleBackColor = True
            '
            'desIncendioFabbricatiAperti1
            '
            Me.desIncendioFabbricatiAperti1.AutoSize = True
            Me.desIncendioFabbricatiAperti1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioFabbricatiAperti1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioFabbricatiAperti1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioFabbricatiAperti1.Location = New System.Drawing.Point(58, 220)
            Me.desIncendioFabbricatiAperti1.Name = "desIncendioFabbricatiAperti1"
            Me.desIncendioFabbricatiAperti1.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioFabbricatiAperti1.TabIndex = 21
            Me.desIncendioFabbricatiAperti1.Tag = "121"
            Me.desIncendioFabbricatiAperti1.Text = "Fabbricati aperti e enti all’aperto (esclusi veicoli)"
            Me.desIncendioFabbricatiAperti1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioFabbricatiAperti1
            '
            Me.lblIncendioFabbricatiAperti1.AutoSize = True
            Me.lblIncendioFabbricatiAperti1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioFabbricatiAperti1.Location = New System.Drawing.Point(971, 220)
            Me.lblIncendioFabbricatiAperti1.Name = "lblIncendioFabbricatiAperti1"
            Me.lblIncendioFabbricatiAperti1.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioFabbricatiAperti1.TabIndex = 22
            Me.lblIncendioFabbricatiAperti1.Text = "0,00"
            Me.lblIncendioFabbricatiAperti1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioFabbricatiAperti1
            '
            Me.chkIncendioFabbricatiAperti1.AutoSize = True
            Me.chkIncendioFabbricatiAperti1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioFabbricatiAperti1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioFabbricatiAperti1.Location = New System.Drawing.Point(0, 220)
            Me.chkIncendioFabbricatiAperti1.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioFabbricatiAperti1.Name = "chkIncendioFabbricatiAperti1"
            Me.chkIncendioFabbricatiAperti1.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioFabbricatiAperti1.TabIndex = 9
            Me.chkIncendioFabbricatiAperti1.UseVisualStyleBackColor = True
            '
            'desIncendioFabbricatiAperti2
            '
            Me.desIncendioFabbricatiAperti2.AutoSize = True
            Me.desIncendioFabbricatiAperti2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioFabbricatiAperti2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioFabbricatiAperti2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioFabbricatiAperti2.Location = New System.Drawing.Point(58, 250)
            Me.desIncendioFabbricatiAperti2.Name = "desIncendioFabbricatiAperti2"
            Me.desIncendioFabbricatiAperti2.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioFabbricatiAperti2.TabIndex = 24
            Me.desIncendioFabbricatiAperti2.Tag = "122"
            Me.desIncendioFabbricatiAperti2.Text = "Fabbricati aperti e enti all’aperto (compresi veicoli)"
            Me.desIncendioFabbricatiAperti2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioFabbricatiAperti2
            '
            Me.lblIncendioFabbricatiAperti2.AutoSize = True
            Me.lblIncendioFabbricatiAperti2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioFabbricatiAperti2.Location = New System.Drawing.Point(971, 250)
            Me.lblIncendioFabbricatiAperti2.Name = "lblIncendioFabbricatiAperti2"
            Me.lblIncendioFabbricatiAperti2.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioFabbricatiAperti2.TabIndex = 25
            Me.lblIncendioFabbricatiAperti2.Text = "0,00"
            Me.lblIncendioFabbricatiAperti2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioFabbricatiAperti2
            '
            Me.chkIncendioFabbricatiAperti2.AutoSize = True
            Me.chkIncendioFabbricatiAperti2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioFabbricatiAperti2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioFabbricatiAperti2.Location = New System.Drawing.Point(0, 250)
            Me.chkIncendioFabbricatiAperti2.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioFabbricatiAperti2.Name = "chkIncendioFabbricatiAperti2"
            Me.chkIncendioFabbricatiAperti2.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioFabbricatiAperti2.TabIndex = 10
            Me.chkIncendioFabbricatiAperti2.UseVisualStyleBackColor = True
            '
            'desIncendioPreziosi
            '
            Me.desIncendioPreziosi.AutoSize = True
            Me.desIncendioPreziosi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioPreziosi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioPreziosi.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioPreziosi.Location = New System.Drawing.Point(58, 280)
            Me.desIncendioPreziosi.Name = "desIncendioPreziosi"
            Me.desIncendioPreziosi.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioPreziosi.TabIndex = 27
            Me.desIncendioPreziosi.Tag = "123"
            Me.desIncendioPreziosi.Text = "Valori, Preziosi e Oggetti d’arte"
            Me.desIncendioPreziosi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioPreziosi
            '
            Me.lblIncendioPreziosi.AutoSize = True
            Me.lblIncendioPreziosi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioPreziosi.Location = New System.Drawing.Point(971, 280)
            Me.lblIncendioPreziosi.Name = "lblIncendioPreziosi"
            Me.lblIncendioPreziosi.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioPreziosi.TabIndex = 28
            Me.lblIncendioPreziosi.Text = "0,00"
            Me.lblIncendioPreziosi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioPreziosi
            '
            Me.chkIncendioPreziosi.AutoSize = True
            Me.chkIncendioPreziosi.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioPreziosi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioPreziosi.Location = New System.Drawing.Point(0, 280)
            Me.chkIncendioPreziosi.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioPreziosi.Name = "chkIncendioPreziosi"
            Me.chkIncendioPreziosi.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioPreziosi.TabIndex = 11
            Me.chkIncendioPreziosi.UseVisualStyleBackColor = True
            '
            'desIncendioSistemiProtezione
            '
            Me.desIncendioSistemiProtezione.AutoSize = True
            Me.desIncendioSistemiProtezione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioSistemiProtezione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioSistemiProtezione.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioSistemiProtezione.Location = New System.Drawing.Point(58, 310)
            Me.desIncendioSistemiProtezione.Name = "desIncendioSistemiProtezione"
            Me.desIncendioSistemiProtezione.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioSistemiProtezione.TabIndex = 30
            Me.desIncendioSistemiProtezione.Tag = "124"
            Me.desIncendioSistemiProtezione.Text = "Danni Elettrici - Sistemi di protezione"
            Me.desIncendioSistemiProtezione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioSistemiProtezione
            '
            Me.lblIncendioSistemiProtezione.AutoSize = True
            Me.lblIncendioSistemiProtezione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioSistemiProtezione.Location = New System.Drawing.Point(971, 310)
            Me.lblIncendioSistemiProtezione.Name = "lblIncendioSistemiProtezione"
            Me.lblIncendioSistemiProtezione.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioSistemiProtezione.TabIndex = 31
            Me.lblIncendioSistemiProtezione.Text = "0,00"
            Me.lblIncendioSistemiProtezione.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioSistemiProtezione
            '
            Me.chkIncendioSistemiProtezione.AutoSize = True
            Me.chkIncendioSistemiProtezione.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioSistemiProtezione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioSistemiProtezione.Location = New System.Drawing.Point(0, 310)
            Me.chkIncendioSistemiProtezione.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioSistemiProtezione.Name = "chkIncendioSistemiProtezione"
            Me.chkIncendioSistemiProtezione.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioSistemiProtezione.TabIndex = 12
            Me.chkIncendioSistemiProtezione.UseVisualStyleBackColor = True
            '
            'desIncendioCommercioAmbulante
            '
            Me.desIncendioCommercioAmbulante.AutoSize = True
            Me.desIncendioCommercioAmbulante.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioCommercioAmbulante.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioCommercioAmbulante.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioCommercioAmbulante.Location = New System.Drawing.Point(58, 340)
            Me.desIncendioCommercioAmbulante.Name = "desIncendioCommercioAmbulante"
            Me.desIncendioCommercioAmbulante.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioCommercioAmbulante.TabIndex = 33
            Me.desIncendioCommercioAmbulante.Tag = "125"
            Me.desIncendioCommercioAmbulante.Text = "Commercio Ambulante"
            Me.desIncendioCommercioAmbulante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioCommercioAmbulante
            '
            Me.lblIncendioCommercioAmbulante.AutoSize = True
            Me.lblIncendioCommercioAmbulante.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioCommercioAmbulante.Location = New System.Drawing.Point(971, 340)
            Me.lblIncendioCommercioAmbulante.Name = "lblIncendioCommercioAmbulante"
            Me.lblIncendioCommercioAmbulante.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioCommercioAmbulante.TabIndex = 34
            Me.lblIncendioCommercioAmbulante.Text = "0,00"
            Me.lblIncendioCommercioAmbulante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioCommercioAmbulante
            '
            Me.chkIncendioCommercioAmbulante.AutoSize = True
            Me.chkIncendioCommercioAmbulante.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioCommercioAmbulante.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioCommercioAmbulante.Location = New System.Drawing.Point(0, 340)
            Me.chkIncendioCommercioAmbulante.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioCommercioAmbulante.Name = "chkIncendioCommercioAmbulante"
            Me.chkIncendioCommercioAmbulante.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioCommercioAmbulante.TabIndex = 13
            Me.chkIncendioCommercioAmbulante.UseVisualStyleBackColor = True
            '
            'desIncendioFranchigia
            '
            Me.desIncendioFranchigia.AutoSize = True
            Me.desIncendioFranchigia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desIncendioFranchigia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desIncendioFranchigia.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desIncendioFranchigia.Location = New System.Drawing.Point(58, 370)
            Me.desIncendioFranchigia.Name = "desIncendioFranchigia"
            Me.desIncendioFranchigia.Size = New System.Drawing.Size(359, 30)
            Me.desIncendioFranchigia.TabIndex = 36
            Me.desIncendioFranchigia.Tag = "126"
            Me.desIncendioFranchigia.Text = "Franchigia assoluta"
            Me.desIncendioFranchigia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncendioFranchigia
            '
            Me.lblIncendioFranchigia.AutoSize = True
            Me.lblIncendioFranchigia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIncendioFranchigia.Location = New System.Drawing.Point(971, 370)
            Me.lblIncendioFranchigia.Name = "lblIncendioFranchigia"
            Me.lblIncendioFranchigia.Size = New System.Drawing.Size(100, 30)
            Me.lblIncendioFranchigia.TabIndex = 37
            Me.lblIncendioFranchigia.Text = "0,00"
            Me.lblIncendioFranchigia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncendioFranchigia
            '
            Me.chkIncendioFranchigia.AutoSize = True
            Me.chkIncendioFranchigia.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkIncendioFranchigia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkIncendioFranchigia.Location = New System.Drawing.Point(0, 370)
            Me.chkIncendioFranchigia.Margin = New System.Windows.Forms.Padding(0)
            Me.chkIncendioFranchigia.Name = "chkIncendioFranchigia"
            Me.chkIncendioFranchigia.Size = New System.Drawing.Size(55, 30)
            Me.chkIncendioFranchigia.TabIndex = 15
            Me.chkIncendioFranchigia.UseVisualStyleBackColor = True
            '
            'cmbIncendioFranchigiaFranchigia
            '
            Me.cmbIncendioFranchigiaFranchigia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbIncendioFranchigiaFranchigia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbIncendioFranchigiaFranchigia.FormattingEnabled = True
            Me.cmbIncendioFranchigiaFranchigia.Location = New System.Drawing.Point(423, 373)
            Me.cmbIncendioFranchigiaFranchigia.Name = "cmbIncendioFranchigiaFranchigia"
            Me.cmbIncendioFranchigiaFranchigia.Size = New System.Drawing.Size(268, 21)
            Me.cmbIncendioFranchigiaFranchigia.TabIndex = 14
            '
            'lblA3
            '
            Me.lblA3.AutoSize = True
            Me.lblA3.BackColor = System.Drawing.Color.Khaki
            Me.lblA3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblA3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblA3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblA3.Location = New System.Drawing.Point(58, 0)
            Me.lblA3.Name = "lblA3"
            Me.lblA3.Size = New System.Drawing.Size(359, 40)
            Me.lblA3.TabIndex = 40
            Me.lblA3.Text = "Partita / Garanzia"
            Me.lblA3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblB3
            '
            Me.lblB3.AutoSize = True
            Me.lblB3.BackColor = System.Drawing.Color.Khaki
            Me.lblB3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.TableLayoutPanel3.SetColumnSpan(Me.lblB3, 2)
            Me.lblB3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblB3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblB3.Location = New System.Drawing.Point(423, 0)
            Me.lblB3.Name = "lblB3"
            Me.lblB3.Size = New System.Drawing.Size(542, 40)
            Me.lblB3.TabIndex = 41
            Me.lblB3.Text = "Parametri/Condizioni"
            Me.lblB3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblC3
            '
            Me.lblC3.AutoSize = True
            Me.lblC3.BackColor = System.Drawing.Color.Khaki
            Me.lblC3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblC3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblC3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblC3.Location = New System.Drawing.Point(971, 0)
            Me.lblC3.Name = "lblC3"
            Me.lblC3.Size = New System.Drawing.Size(100, 40)
            Me.lblC3.TabIndex = 42
            Me.lblC3.Text = "Premio"
            Me.lblC3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblD3
            '
            Me.lblD3.AutoSize = True
            Me.lblD3.BackColor = System.Drawing.Color.Khaki
            Me.lblD3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblD3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblD3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblD3.Location = New System.Drawing.Point(3, 0)
            Me.lblD3.Name = "lblD3"
            Me.lblD3.Size = New System.Drawing.Size(49, 40)
            Me.lblD3.TabIndex = 43
            Me.lblD3.Text = "Scelto"
            Me.lblD3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'TabPage4
            '
            Me.TabPage4.Controls.Add(Me.GroupBox4)
            Me.TabPage4.Location = New System.Drawing.Point(4, 29)
            Me.TabPage4.Name = "TabPage4"
            Me.TabPage4.Size = New System.Drawing.Size(1080, 613)
            Me.TabPage4.TabIndex = 3
            Me.TabPage4.Tag = ""
            Me.TabPage4.Text = "Furto 1"
            Me.TabPage4.UseVisualStyleBackColor = True
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.Add(Me.TableLayoutPanel4)
            Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
            Me.GroupBox4.Margin = New System.Windows.Forms.Padding(0)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
            Me.GroupBox4.Size = New System.Drawing.Size(1080, 613)
            Me.GroupBox4.TabIndex = 0
            Me.GroupBox4.TabStop = False
            '
            'TableLayoutPanel4
            '
            Me.TableLayoutPanel4.ColumnCount = 5
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
            Me.TableLayoutPanel4.Controls.Add(Me.txtFurtoAumentoMerciMesi, 3, 8)
            Me.TableLayoutPanel4.Controls.Add(Me.lblFurtoPremio, 4, 1)
            Me.TableLayoutPanel4.Controls.Add(Me.chkFurtoBase, 0, 1)
            Me.TableLayoutPanel4.Controls.Add(Me.desFurtoContenuto, 1, 2)
            Me.TableLayoutPanel4.Controls.Add(Me.lblFurtoContenuto, 4, 2)
            Me.TableLayoutPanel4.Controls.Add(Me.chkFurtoContenuto, 0, 2)
            Me.TableLayoutPanel4.Controls.Add(Me.txtPartitaFurtoContenuto, 2, 2)
            Me.TableLayoutPanel4.Controls.Add(Me.desFurtoFissi, 1, 3)
            Me.TableLayoutPanel4.Controls.Add(Me.lblFurtoFissi, 4, 3)
            Me.TableLayoutPanel4.Controls.Add(Me.chkFurtoFissi, 0, 3)
            Me.TableLayoutPanel4.Controls.Add(Me.txtPartitaFurtoFissi, 2, 3)
            Me.TableLayoutPanel4.Controls.Add(Me.cmbFurtoFissiScelta, 3, 3)
            Me.TableLayoutPanel4.Controls.Add(Me.desFurtoValori, 1, 4)
            Me.TableLayoutPanel4.Controls.Add(Me.lblFurtoValori, 4, 4)
            Me.TableLayoutPanel4.Controls.Add(Me.chkFurtoValori, 0, 4)
            Me.TableLayoutPanel4.Controls.Add(Me.txtPartitaFurtoValori, 2, 4)
            Me.TableLayoutPanel4.Controls.Add(Me.cmbFurtoValoriScelta, 3, 4)
            Me.TableLayoutPanel4.Controls.Add(Me.desFurtoVetrinette, 1, 6)
            Me.TableLayoutPanel4.Controls.Add(Me.lblFurtoVetrinette, 4, 6)
            Me.TableLayoutPanel4.Controls.Add(Me.chkFurtoVetrinette, 0, 6)
            Me.TableLayoutPanel4.Controls.Add(Me.txtPartitaFurtoVetrinette, 2, 6)
            Me.TableLayoutPanel4.Controls.Add(Me.desFurtoPortavalori, 1, 7)
            Me.TableLayoutPanel4.Controls.Add(Me.lblFurtoPortavalori, 4, 7)
            Me.TableLayoutPanel4.Controls.Add(Me.chkFurtoPortavalori, 0, 7)
            Me.TableLayoutPanel4.Controls.Add(Me.txtPartitaFurtoPortavalori, 2, 7)
            Me.TableLayoutPanel4.Controls.Add(Me.desFurtoAumentoMerci, 1, 8)
            Me.TableLayoutPanel4.Controls.Add(Me.lblFurtoAumentoMerci, 4, 8)
            Me.TableLayoutPanel4.Controls.Add(Me.chkFurtoAumentoMerci, 0, 8)
            Me.TableLayoutPanel4.Controls.Add(Me.txtPartitaFurtoAumentoMerci, 2, 8)
            Me.TableLayoutPanel4.Controls.Add(Me.desFurtoMerciTrasportate, 1, 9)
            Me.TableLayoutPanel4.Controls.Add(Me.lblFurtoMerciTrasportate, 4, 9)
            Me.TableLayoutPanel4.Controls.Add(Me.chkFurtoMerciTrasportate, 0, 9)
            Me.TableLayoutPanel4.Controls.Add(Me.txtPartitaFurtoMerciTrasportate, 2, 9)
            Me.TableLayoutPanel4.Controls.Add(Me.desFurtoMerciAperto, 1, 10)
            Me.TableLayoutPanel4.Controls.Add(Me.lblFurtoMerciAperto, 4, 10)
            Me.TableLayoutPanel4.Controls.Add(Me.chkFurtoMerciAperto, 0, 10)
            Me.TableLayoutPanel4.Controls.Add(Me.txtPartitaFurtoMerciAperto, 2, 10)
            Me.TableLayoutPanel4.Controls.Add(Me.desFurtoDistributoriEsterni, 1, 11)
            Me.TableLayoutPanel4.Controls.Add(Me.lblFurtoDistributoriEsterni, 4, 11)
            Me.TableLayoutPanel4.Controls.Add(Me.chkFurtoDistributoriEsterni, 0, 11)
            Me.TableLayoutPanel4.Controls.Add(Me.txtPartitaFurtoDistributoriEsterni, 2, 11)
            Me.TableLayoutPanel4.Controls.Add(Me.desFurtoDistributoriCarburante, 1, 12)
            Me.TableLayoutPanel4.Controls.Add(Me.lblFurtoDistributoriCarburante, 4, 12)
            Me.TableLayoutPanel4.Controls.Add(Me.chkFurtoDistributoriCarburante, 0, 12)
            Me.TableLayoutPanel4.Controls.Add(Me.txtPartitaFurtoDistributoriCarburante, 2, 12)
            Me.TableLayoutPanel4.Controls.Add(Me.desFurtoRicetteMediche, 1, 13)
            Me.TableLayoutPanel4.Controls.Add(Me.lblFurtoRicetteMediche, 4, 13)
            Me.TableLayoutPanel4.Controls.Add(Me.chkFurtoRicetteMediche, 0, 13)
            Me.TableLayoutPanel4.Controls.Add(Me.txtPartitaFurtoRicetteMediche, 2, 13)
            Me.TableLayoutPanel4.Controls.Add(Me.desFurtoDipendenti, 1, 14)
            Me.TableLayoutPanel4.Controls.Add(Me.lblFurtoDipendenti, 4, 14)
            Me.TableLayoutPanel4.Controls.Add(Me.chkFurtoDipendenti, 0, 14)
            Me.TableLayoutPanel4.Controls.Add(Me.txtPartitaFurtoDipendenti, 2, 14)
            Me.TableLayoutPanel4.Controls.Add(Me.lblA4, 1, 0)
            Me.TableLayoutPanel4.Controls.Add(Me.lblB4, 2, 0)
            Me.TableLayoutPanel4.Controls.Add(Me.lblC4, 4, 0)
            Me.TableLayoutPanel4.Controls.Add(Me.lblD4, 0, 0)
            Me.TableLayoutPanel4.Controls.Add(Me.desFurtoRapina, 1, 5)
            Me.TableLayoutPanel4.Controls.Add(Me.txtPartitaFurtoRapina, 2, 5)
            Me.TableLayoutPanel4.Controls.Add(Me.cmbFurtoRapinaScelta, 3, 5)
            Me.TableLayoutPanel4.Controls.Add(Me.lblFurtoRapina, 4, 5)
            Me.TableLayoutPanel4.Controls.Add(Me.chkFurtoRapina, 0, 5)
            Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 13)
            Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
            Me.TableLayoutPanel4.RowCount = 16
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.Size = New System.Drawing.Size(1074, 597)
            Me.TableLayoutPanel4.TabIndex = 0
            '
            'txtFurtoAumentoMerciMesi
            '
            Me.txtFurtoAumentoMerciMesi.Dock = System.Windows.Forms.DockStyle.Left
            Me.txtFurtoAumentoMerciMesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtFurtoAumentoMerciMesi.Location = New System.Drawing.Point(697, 253)
            Me.txtFurtoAumentoMerciMesi.Name = "txtFurtoAumentoMerciMesi"
            Me.txtFurtoAumentoMerciMesi.Size = New System.Drawing.Size(66, 22)
            Me.txtFurtoAumentoMerciMesi.TabIndex = 17
            Me.txtFurtoAumentoMerciMesi.TabStop = False
            Me.txtFurtoAumentoMerciMesi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblFurtoPremio
            '
            Me.lblFurtoPremio.AutoSize = True
            Me.lblFurtoPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoPremio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFurtoPremio.Location = New System.Drawing.Point(971, 40)
            Me.lblFurtoPremio.Name = "lblFurtoPremio"
            Me.lblFurtoPremio.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoPremio.TabIndex = 2
            Me.lblFurtoPremio.Text = "0,00"
            Me.lblFurtoPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoBase
            '
            Me.chkFurtoBase.AutoSize = True
            Me.TableLayoutPanel4.SetColumnSpan(Me.chkFurtoBase, 2)
            Me.chkFurtoBase.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoBase.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.chkFurtoBase.Location = New System.Drawing.Point(8, 40)
            Me.chkFurtoBase.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
            Me.chkFurtoBase.Name = "chkFurtoBase"
            Me.chkFurtoBase.Size = New System.Drawing.Size(412, 30)
            Me.chkFurtoBase.TabIndex = 0
            Me.chkFurtoBase.Text = "FURTO"
            Me.chkFurtoBase.UseVisualStyleBackColor = True
            '
            'desFurtoContenuto
            '
            Me.desFurtoContenuto.AutoSize = True
            Me.desFurtoContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoContenuto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoContenuto.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoContenuto.Location = New System.Drawing.Point(58, 70)
            Me.desFurtoContenuto.Name = "desFurtoContenuto"
            Me.desFurtoContenuto.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoContenuto.TabIndex = 7
            Me.desFurtoContenuto.Tag = "228"
            Me.desFurtoContenuto.Text = "Furto contenuto"
            Me.desFurtoContenuto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoContenuto
            '
            Me.lblFurtoContenuto.AutoSize = True
            Me.lblFurtoContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoContenuto.Location = New System.Drawing.Point(971, 70)
            Me.lblFurtoContenuto.Name = "lblFurtoContenuto"
            Me.lblFurtoContenuto.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoContenuto.TabIndex = 8
            Me.lblFurtoContenuto.Text = "0,00"
            Me.lblFurtoContenuto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoContenuto
            '
            Me.chkFurtoContenuto.AutoSize = True
            Me.chkFurtoContenuto.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoContenuto.Location = New System.Drawing.Point(0, 70)
            Me.chkFurtoContenuto.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoContenuto.Name = "chkFurtoContenuto"
            Me.chkFurtoContenuto.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoContenuto.TabIndex = 2
            Me.chkFurtoContenuto.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoContenuto
            '
            Me.txtPartitaFurtoContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoContenuto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoContenuto.Location = New System.Drawing.Point(423, 73)
            Me.txtPartitaFurtoContenuto.Name = "txtPartitaFurtoContenuto"
            Me.txtPartitaFurtoContenuto.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoContenuto.TabIndex = 1
            Me.txtPartitaFurtoContenuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desFurtoFissi
            '
            Me.desFurtoFissi.AutoSize = True
            Me.desFurtoFissi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoFissi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoFissi.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoFissi.Location = New System.Drawing.Point(58, 100)
            Me.desFurtoFissi.Name = "desFurtoFissi"
            Me.desFurtoFissi.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoFissi.TabIndex = 11
            Me.desFurtoFissi.Tag = "229"
            Me.desFurtoFissi.Text = "Furto di fissi e infissi"
            Me.desFurtoFissi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoFissi
            '
            Me.lblFurtoFissi.AutoSize = True
            Me.lblFurtoFissi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoFissi.Location = New System.Drawing.Point(971, 100)
            Me.lblFurtoFissi.Name = "lblFurtoFissi"
            Me.lblFurtoFissi.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoFissi.TabIndex = 12
            Me.lblFurtoFissi.Text = "0,00"
            Me.lblFurtoFissi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoFissi
            '
            Me.chkFurtoFissi.AutoSize = True
            Me.chkFurtoFissi.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoFissi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoFissi.Location = New System.Drawing.Point(0, 100)
            Me.chkFurtoFissi.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoFissi.Name = "chkFurtoFissi"
            Me.chkFurtoFissi.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoFissi.TabIndex = 5
            Me.chkFurtoFissi.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoFissi
            '
            Me.txtPartitaFurtoFissi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoFissi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoFissi.Location = New System.Drawing.Point(423, 103)
            Me.txtPartitaFurtoFissi.Name = "txtPartitaFurtoFissi"
            Me.txtPartitaFurtoFissi.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoFissi.TabIndex = 3
            Me.txtPartitaFurtoFissi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'cmbFurtoFissiScelta
            '
            Me.cmbFurtoFissiScelta.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoFissiScelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoFissiScelta.FormattingEnabled = True
            Me.cmbFurtoFissiScelta.Location = New System.Drawing.Point(697, 103)
            Me.cmbFurtoFissiScelta.Name = "cmbFurtoFissiScelta"
            Me.cmbFurtoFissiScelta.Size = New System.Drawing.Size(268, 21)
            Me.cmbFurtoFissiScelta.TabIndex = 4
            '
            'desFurtoValori
            '
            Me.desFurtoValori.AutoSize = True
            Me.desFurtoValori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoValori.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoValori.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoValori.Location = New System.Drawing.Point(58, 130)
            Me.desFurtoValori.Name = "desFurtoValori"
            Me.desFurtoValori.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoValori.TabIndex = 16
            Me.desFurtoValori.Tag = "230"
            Me.desFurtoValori.Text = "Furto Valori"
            Me.desFurtoValori.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoValori
            '
            Me.lblFurtoValori.AutoSize = True
            Me.lblFurtoValori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoValori.Location = New System.Drawing.Point(971, 130)
            Me.lblFurtoValori.Name = "lblFurtoValori"
            Me.lblFurtoValori.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoValori.TabIndex = 17
            Me.lblFurtoValori.Text = "0,00"
            Me.lblFurtoValori.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoValori
            '
            Me.chkFurtoValori.AutoSize = True
            Me.chkFurtoValori.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoValori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoValori.Location = New System.Drawing.Point(0, 130)
            Me.chkFurtoValori.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoValori.Name = "chkFurtoValori"
            Me.chkFurtoValori.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoValori.TabIndex = 8
            Me.chkFurtoValori.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoValori
            '
            Me.txtPartitaFurtoValori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoValori.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoValori.Location = New System.Drawing.Point(423, 133)
            Me.txtPartitaFurtoValori.Name = "txtPartitaFurtoValori"
            Me.txtPartitaFurtoValori.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoValori.TabIndex = 6
            Me.txtPartitaFurtoValori.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'cmbFurtoValoriScelta
            '
            Me.cmbFurtoValoriScelta.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoValoriScelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoValoriScelta.FormattingEnabled = True
            Me.cmbFurtoValoriScelta.Location = New System.Drawing.Point(697, 133)
            Me.cmbFurtoValoriScelta.Name = "cmbFurtoValoriScelta"
            Me.cmbFurtoValoriScelta.Size = New System.Drawing.Size(268, 21)
            Me.cmbFurtoValoriScelta.TabIndex = 7
            '
            'desFurtoVetrinette
            '
            Me.desFurtoVetrinette.AutoSize = True
            Me.desFurtoVetrinette.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoVetrinette.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoVetrinette.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoVetrinette.Location = New System.Drawing.Point(58, 190)
            Me.desFurtoVetrinette.Name = "desFurtoVetrinette"
            Me.desFurtoVetrinette.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoVetrinette.TabIndex = 21
            Me.desFurtoVetrinette.Tag = "231"
            Me.desFurtoVetrinette.Text = "Furto Vetrinette esterne"
            Me.desFurtoVetrinette.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoVetrinette
            '
            Me.lblFurtoVetrinette.AutoSize = True
            Me.lblFurtoVetrinette.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoVetrinette.Location = New System.Drawing.Point(971, 190)
            Me.lblFurtoVetrinette.Name = "lblFurtoVetrinette"
            Me.lblFurtoVetrinette.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoVetrinette.TabIndex = 22
            Me.lblFurtoVetrinette.Text = "0,00"
            Me.lblFurtoVetrinette.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoVetrinette
            '
            Me.chkFurtoVetrinette.AutoSize = True
            Me.chkFurtoVetrinette.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoVetrinette.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoVetrinette.Location = New System.Drawing.Point(0, 190)
            Me.chkFurtoVetrinette.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoVetrinette.Name = "chkFurtoVetrinette"
            Me.chkFurtoVetrinette.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoVetrinette.TabIndex = 13
            Me.chkFurtoVetrinette.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoVetrinette
            '
            Me.txtPartitaFurtoVetrinette.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoVetrinette.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoVetrinette.Location = New System.Drawing.Point(423, 193)
            Me.txtPartitaFurtoVetrinette.Name = "txtPartitaFurtoVetrinette"
            Me.txtPartitaFurtoVetrinette.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoVetrinette.TabIndex = 12
            Me.txtPartitaFurtoVetrinette.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desFurtoPortavalori
            '
            Me.desFurtoPortavalori.AutoSize = True
            Me.desFurtoPortavalori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoPortavalori.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoPortavalori.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoPortavalori.Location = New System.Drawing.Point(58, 220)
            Me.desFurtoPortavalori.Name = "desFurtoPortavalori"
            Me.desFurtoPortavalori.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoPortavalori.TabIndex = 25
            Me.desFurtoPortavalori.Tag = "232"
            Me.desFurtoPortavalori.Text = "Furto Portavalori"
            Me.desFurtoPortavalori.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoPortavalori
            '
            Me.lblFurtoPortavalori.AutoSize = True
            Me.lblFurtoPortavalori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoPortavalori.Location = New System.Drawing.Point(971, 220)
            Me.lblFurtoPortavalori.Name = "lblFurtoPortavalori"
            Me.lblFurtoPortavalori.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoPortavalori.TabIndex = 26
            Me.lblFurtoPortavalori.Text = "0,00"
            Me.lblFurtoPortavalori.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoPortavalori
            '
            Me.chkFurtoPortavalori.AutoSize = True
            Me.chkFurtoPortavalori.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoPortavalori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoPortavalori.Location = New System.Drawing.Point(0, 220)
            Me.chkFurtoPortavalori.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoPortavalori.Name = "chkFurtoPortavalori"
            Me.chkFurtoPortavalori.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoPortavalori.TabIndex = 15
            Me.chkFurtoPortavalori.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoPortavalori
            '
            Me.txtPartitaFurtoPortavalori.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoPortavalori.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoPortavalori.Location = New System.Drawing.Point(423, 223)
            Me.txtPartitaFurtoPortavalori.Name = "txtPartitaFurtoPortavalori"
            Me.txtPartitaFurtoPortavalori.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoPortavalori.TabIndex = 14
            Me.txtPartitaFurtoPortavalori.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desFurtoAumentoMerci
            '
            Me.desFurtoAumentoMerci.AutoSize = True
            Me.desFurtoAumentoMerci.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoAumentoMerci.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoAumentoMerci.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoAumentoMerci.Location = New System.Drawing.Point(58, 250)
            Me.desFurtoAumentoMerci.Name = "desFurtoAumentoMerci"
            Me.desFurtoAumentoMerci.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoAumentoMerci.TabIndex = 29
            Me.desFurtoAumentoMerci.Tag = "233"
            Me.desFurtoAumentoMerci.Text = "Aumento periodico Merci assicurate"
            Me.desFurtoAumentoMerci.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoAumentoMerci
            '
            Me.lblFurtoAumentoMerci.AutoSize = True
            Me.lblFurtoAumentoMerci.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoAumentoMerci.Location = New System.Drawing.Point(971, 250)
            Me.lblFurtoAumentoMerci.Name = "lblFurtoAumentoMerci"
            Me.lblFurtoAumentoMerci.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoAumentoMerci.TabIndex = 30
            Me.lblFurtoAumentoMerci.Text = "0,00"
            Me.lblFurtoAumentoMerci.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoAumentoMerci
            '
            Me.chkFurtoAumentoMerci.AutoSize = True
            Me.chkFurtoAumentoMerci.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoAumentoMerci.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoAumentoMerci.Location = New System.Drawing.Point(0, 250)
            Me.chkFurtoAumentoMerci.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoAumentoMerci.Name = "chkFurtoAumentoMerci"
            Me.chkFurtoAumentoMerci.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoAumentoMerci.TabIndex = 18
            Me.chkFurtoAumentoMerci.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoAumentoMerci
            '
            Me.txtPartitaFurtoAumentoMerci.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoAumentoMerci.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoAumentoMerci.Location = New System.Drawing.Point(423, 253)
            Me.txtPartitaFurtoAumentoMerci.Name = "txtPartitaFurtoAumentoMerci"
            Me.txtPartitaFurtoAumentoMerci.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoAumentoMerci.TabIndex = 16
            Me.txtPartitaFurtoAumentoMerci.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desFurtoMerciTrasportate
            '
            Me.desFurtoMerciTrasportate.AutoSize = True
            Me.desFurtoMerciTrasportate.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoMerciTrasportate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoMerciTrasportate.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoMerciTrasportate.Location = New System.Drawing.Point(58, 280)
            Me.desFurtoMerciTrasportate.Name = "desFurtoMerciTrasportate"
            Me.desFurtoMerciTrasportate.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoMerciTrasportate.TabIndex = 33
            Me.desFurtoMerciTrasportate.Tag = "234"
            Me.desFurtoMerciTrasportate.Text = "Furto di Merci trasportate"
            Me.desFurtoMerciTrasportate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoMerciTrasportate
            '
            Me.lblFurtoMerciTrasportate.AutoSize = True
            Me.lblFurtoMerciTrasportate.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoMerciTrasportate.Location = New System.Drawing.Point(971, 280)
            Me.lblFurtoMerciTrasportate.Name = "lblFurtoMerciTrasportate"
            Me.lblFurtoMerciTrasportate.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoMerciTrasportate.TabIndex = 34
            Me.lblFurtoMerciTrasportate.Text = "0,00"
            Me.lblFurtoMerciTrasportate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoMerciTrasportate
            '
            Me.chkFurtoMerciTrasportate.AutoSize = True
            Me.chkFurtoMerciTrasportate.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoMerciTrasportate.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoMerciTrasportate.Location = New System.Drawing.Point(0, 280)
            Me.chkFurtoMerciTrasportate.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoMerciTrasportate.Name = "chkFurtoMerciTrasportate"
            Me.chkFurtoMerciTrasportate.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoMerciTrasportate.TabIndex = 20
            Me.chkFurtoMerciTrasportate.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoMerciTrasportate
            '
            Me.txtPartitaFurtoMerciTrasportate.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoMerciTrasportate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoMerciTrasportate.Location = New System.Drawing.Point(423, 283)
            Me.txtPartitaFurtoMerciTrasportate.Name = "txtPartitaFurtoMerciTrasportate"
            Me.txtPartitaFurtoMerciTrasportate.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoMerciTrasportate.TabIndex = 19
            Me.txtPartitaFurtoMerciTrasportate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desFurtoMerciAperto
            '
            Me.desFurtoMerciAperto.AutoSize = True
            Me.desFurtoMerciAperto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoMerciAperto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoMerciAperto.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoMerciAperto.Location = New System.Drawing.Point(58, 310)
            Me.desFurtoMerciAperto.Name = "desFurtoMerciAperto"
            Me.desFurtoMerciAperto.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoMerciAperto.TabIndex = 37
            Me.desFurtoMerciAperto.Tag = "235"
            Me.desFurtoMerciAperto.Text = "Furto di Merci all’aperto"
            Me.desFurtoMerciAperto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoMerciAperto
            '
            Me.lblFurtoMerciAperto.AutoSize = True
            Me.lblFurtoMerciAperto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoMerciAperto.Location = New System.Drawing.Point(971, 310)
            Me.lblFurtoMerciAperto.Name = "lblFurtoMerciAperto"
            Me.lblFurtoMerciAperto.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoMerciAperto.TabIndex = 38
            Me.lblFurtoMerciAperto.Text = "0,00"
            Me.lblFurtoMerciAperto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoMerciAperto
            '
            Me.chkFurtoMerciAperto.AutoSize = True
            Me.chkFurtoMerciAperto.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoMerciAperto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoMerciAperto.Location = New System.Drawing.Point(0, 310)
            Me.chkFurtoMerciAperto.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoMerciAperto.Name = "chkFurtoMerciAperto"
            Me.chkFurtoMerciAperto.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoMerciAperto.TabIndex = 22
            Me.chkFurtoMerciAperto.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoMerciAperto
            '
            Me.txtPartitaFurtoMerciAperto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoMerciAperto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoMerciAperto.Location = New System.Drawing.Point(423, 313)
            Me.txtPartitaFurtoMerciAperto.Name = "txtPartitaFurtoMerciAperto"
            Me.txtPartitaFurtoMerciAperto.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoMerciAperto.TabIndex = 21
            Me.txtPartitaFurtoMerciAperto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desFurtoDistributoriEsterni
            '
            Me.desFurtoDistributoriEsterni.AutoSize = True
            Me.desFurtoDistributoriEsterni.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoDistributoriEsterni.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoDistributoriEsterni.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoDistributoriEsterni.Location = New System.Drawing.Point(58, 340)
            Me.desFurtoDistributoriEsterni.Name = "desFurtoDistributoriEsterni"
            Me.desFurtoDistributoriEsterni.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoDistributoriEsterni.TabIndex = 41
            Me.desFurtoDistributoriEsterni.Tag = "236"
            Me.desFurtoDistributoriEsterni.Text = "Distributori esterni di Merci inerenti l’attività esercitata"
            Me.desFurtoDistributoriEsterni.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoDistributoriEsterni
            '
            Me.lblFurtoDistributoriEsterni.AutoSize = True
            Me.lblFurtoDistributoriEsterni.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoDistributoriEsterni.Location = New System.Drawing.Point(971, 340)
            Me.lblFurtoDistributoriEsterni.Name = "lblFurtoDistributoriEsterni"
            Me.lblFurtoDistributoriEsterni.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoDistributoriEsterni.TabIndex = 42
            Me.lblFurtoDistributoriEsterni.Text = "0,00"
            Me.lblFurtoDistributoriEsterni.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoDistributoriEsterni
            '
            Me.chkFurtoDistributoriEsterni.AutoSize = True
            Me.chkFurtoDistributoriEsterni.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoDistributoriEsterni.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoDistributoriEsterni.Location = New System.Drawing.Point(0, 340)
            Me.chkFurtoDistributoriEsterni.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoDistributoriEsterni.Name = "chkFurtoDistributoriEsterni"
            Me.chkFurtoDistributoriEsterni.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoDistributoriEsterni.TabIndex = 24
            Me.chkFurtoDistributoriEsterni.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoDistributoriEsterni
            '
            Me.txtPartitaFurtoDistributoriEsterni.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoDistributoriEsterni.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoDistributoriEsterni.Location = New System.Drawing.Point(423, 343)
            Me.txtPartitaFurtoDistributoriEsterni.Name = "txtPartitaFurtoDistributoriEsterni"
            Me.txtPartitaFurtoDistributoriEsterni.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoDistributoriEsterni.TabIndex = 23
            Me.txtPartitaFurtoDistributoriEsterni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desFurtoDistributoriCarburante
            '
            Me.desFurtoDistributoriCarburante.AutoSize = True
            Me.desFurtoDistributoriCarburante.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoDistributoriCarburante.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoDistributoriCarburante.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoDistributoriCarburante.Location = New System.Drawing.Point(58, 370)
            Me.desFurtoDistributoriCarburante.Name = "desFurtoDistributoriCarburante"
            Me.desFurtoDistributoriCarburante.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoDistributoriCarburante.TabIndex = 45
            Me.desFurtoDistributoriCarburante.Tag = "237"
            Me.desFurtoDistributoriCarburante.Text = "Distributori di carburante (Furto Valori)"
            Me.desFurtoDistributoriCarburante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoDistributoriCarburante
            '
            Me.lblFurtoDistributoriCarburante.AutoSize = True
            Me.lblFurtoDistributoriCarburante.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoDistributoriCarburante.Location = New System.Drawing.Point(971, 370)
            Me.lblFurtoDistributoriCarburante.Name = "lblFurtoDistributoriCarburante"
            Me.lblFurtoDistributoriCarburante.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoDistributoriCarburante.TabIndex = 46
            Me.lblFurtoDistributoriCarburante.Text = "0,00"
            Me.lblFurtoDistributoriCarburante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoDistributoriCarburante
            '
            Me.chkFurtoDistributoriCarburante.AutoSize = True
            Me.chkFurtoDistributoriCarburante.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoDistributoriCarburante.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoDistributoriCarburante.Location = New System.Drawing.Point(0, 370)
            Me.chkFurtoDistributoriCarburante.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoDistributoriCarburante.Name = "chkFurtoDistributoriCarburante"
            Me.chkFurtoDistributoriCarburante.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoDistributoriCarburante.TabIndex = 26
            Me.chkFurtoDistributoriCarburante.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoDistributoriCarburante
            '
            Me.txtPartitaFurtoDistributoriCarburante.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoDistributoriCarburante.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoDistributoriCarburante.Location = New System.Drawing.Point(423, 373)
            Me.txtPartitaFurtoDistributoriCarburante.Name = "txtPartitaFurtoDistributoriCarburante"
            Me.txtPartitaFurtoDistributoriCarburante.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoDistributoriCarburante.TabIndex = 25
            Me.txtPartitaFurtoDistributoriCarburante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desFurtoRicetteMediche
            '
            Me.desFurtoRicetteMediche.AutoSize = True
            Me.desFurtoRicetteMediche.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoRicetteMediche.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoRicetteMediche.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoRicetteMediche.Location = New System.Drawing.Point(58, 400)
            Me.desFurtoRicetteMediche.Name = "desFurtoRicetteMediche"
            Me.desFurtoRicetteMediche.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoRicetteMediche.TabIndex = 49
            Me.desFurtoRicetteMediche.Tag = "238"
            Me.desFurtoRicetteMediche.Text = "Ricette mediche"
            Me.desFurtoRicetteMediche.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoRicetteMediche
            '
            Me.lblFurtoRicetteMediche.AutoSize = True
            Me.lblFurtoRicetteMediche.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoRicetteMediche.Location = New System.Drawing.Point(971, 400)
            Me.lblFurtoRicetteMediche.Name = "lblFurtoRicetteMediche"
            Me.lblFurtoRicetteMediche.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoRicetteMediche.TabIndex = 50
            Me.lblFurtoRicetteMediche.Text = "0,00"
            Me.lblFurtoRicetteMediche.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoRicetteMediche
            '
            Me.chkFurtoRicetteMediche.AutoSize = True
            Me.chkFurtoRicetteMediche.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoRicetteMediche.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoRicetteMediche.Location = New System.Drawing.Point(0, 400)
            Me.chkFurtoRicetteMediche.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoRicetteMediche.Name = "chkFurtoRicetteMediche"
            Me.chkFurtoRicetteMediche.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoRicetteMediche.TabIndex = 28
            Me.chkFurtoRicetteMediche.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoRicetteMediche
            '
            Me.txtPartitaFurtoRicetteMediche.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoRicetteMediche.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoRicetteMediche.Location = New System.Drawing.Point(423, 403)
            Me.txtPartitaFurtoRicetteMediche.Name = "txtPartitaFurtoRicetteMediche"
            Me.txtPartitaFurtoRicetteMediche.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoRicetteMediche.TabIndex = 27
            Me.txtPartitaFurtoRicetteMediche.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desFurtoDipendenti
            '
            Me.desFurtoDipendenti.AutoSize = True
            Me.desFurtoDipendenti.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoDipendenti.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoDipendenti.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoDipendenti.Location = New System.Drawing.Point(58, 430)
            Me.desFurtoDipendenti.Name = "desFurtoDipendenti"
            Me.desFurtoDipendenti.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoDipendenti.TabIndex = 53
            Me.desFurtoDipendenti.Tag = "239"
            Me.desFurtoDipendenti.Text = "Infedeltà dei dipendenti"
            Me.desFurtoDipendenti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoDipendenti
            '
            Me.lblFurtoDipendenti.AutoSize = True
            Me.lblFurtoDipendenti.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoDipendenti.Location = New System.Drawing.Point(971, 430)
            Me.lblFurtoDipendenti.Name = "lblFurtoDipendenti"
            Me.lblFurtoDipendenti.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoDipendenti.TabIndex = 54
            Me.lblFurtoDipendenti.Text = "0,00"
            Me.lblFurtoDipendenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoDipendenti
            '
            Me.chkFurtoDipendenti.AutoSize = True
            Me.chkFurtoDipendenti.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoDipendenti.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoDipendenti.Location = New System.Drawing.Point(0, 430)
            Me.chkFurtoDipendenti.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoDipendenti.Name = "chkFurtoDipendenti"
            Me.chkFurtoDipendenti.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoDipendenti.TabIndex = 30
            Me.chkFurtoDipendenti.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoDipendenti
            '
            Me.txtPartitaFurtoDipendenti.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoDipendenti.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoDipendenti.Location = New System.Drawing.Point(423, 433)
            Me.txtPartitaFurtoDipendenti.Name = "txtPartitaFurtoDipendenti"
            Me.txtPartitaFurtoDipendenti.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoDipendenti.TabIndex = 29
            Me.txtPartitaFurtoDipendenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblA4
            '
            Me.lblA4.AutoSize = True
            Me.lblA4.BackColor = System.Drawing.Color.Khaki
            Me.lblA4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblA4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblA4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblA4.Location = New System.Drawing.Point(58, 0)
            Me.lblA4.Name = "lblA4"
            Me.lblA4.Size = New System.Drawing.Size(359, 40)
            Me.lblA4.TabIndex = 57
            Me.lblA4.Text = "Partita / Garanzia"
            Me.lblA4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblB4
            '
            Me.lblB4.AutoSize = True
            Me.lblB4.BackColor = System.Drawing.Color.Khaki
            Me.lblB4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.TableLayoutPanel4.SetColumnSpan(Me.lblB4, 2)
            Me.lblB4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblB4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblB4.Location = New System.Drawing.Point(423, 0)
            Me.lblB4.Name = "lblB4"
            Me.lblB4.Size = New System.Drawing.Size(542, 40)
            Me.lblB4.TabIndex = 58
            Me.lblB4.Text = "Parametri/Condizioni"
            Me.lblB4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblC4
            '
            Me.lblC4.AutoSize = True
            Me.lblC4.BackColor = System.Drawing.Color.Khaki
            Me.lblC4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblC4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblC4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblC4.Location = New System.Drawing.Point(971, 0)
            Me.lblC4.Name = "lblC4"
            Me.lblC4.Size = New System.Drawing.Size(100, 40)
            Me.lblC4.TabIndex = 59
            Me.lblC4.Text = "Premio"
            Me.lblC4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblD4
            '
            Me.lblD4.AutoSize = True
            Me.lblD4.BackColor = System.Drawing.Color.Khaki
            Me.lblD4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblD4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblD4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblD4.Location = New System.Drawing.Point(3, 0)
            Me.lblD4.Name = "lblD4"
            Me.lblD4.Size = New System.Drawing.Size(49, 40)
            Me.lblD4.TabIndex = 60
            Me.lblD4.Text = "Scelto"
            Me.lblD4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'desFurtoRapina
            '
            Me.desFurtoRapina.AutoSize = True
            Me.desFurtoRapina.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoRapina.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoRapina.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoRapina.Location = New System.Drawing.Point(58, 160)
            Me.desFurtoRapina.Name = "desFurtoRapina"
            Me.desFurtoRapina.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoRapina.TabIndex = 16
            Me.desFurtoRapina.Tag = "230"
            Me.desFurtoRapina.Text = "Rapina Valori allinterno dei locali"
            Me.desFurtoRapina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPartitaFurtoRapina
            '
            Me.txtPartitaFurtoRapina.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoRapina.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoRapina.Location = New System.Drawing.Point(423, 163)
            Me.txtPartitaFurtoRapina.Name = "txtPartitaFurtoRapina"
            Me.txtPartitaFurtoRapina.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoRapina.TabIndex = 9
            Me.txtPartitaFurtoRapina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'cmbFurtoRapinaScelta
            '
            Me.cmbFurtoRapinaScelta.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbFurtoRapinaScelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFurtoRapinaScelta.FormattingEnabled = True
            Me.cmbFurtoRapinaScelta.Location = New System.Drawing.Point(697, 163)
            Me.cmbFurtoRapinaScelta.Name = "cmbFurtoRapinaScelta"
            Me.cmbFurtoRapinaScelta.Size = New System.Drawing.Size(268, 21)
            Me.cmbFurtoRapinaScelta.TabIndex = 10
            '
            'lblFurtoRapina
            '
            Me.lblFurtoRapina.AutoSize = True
            Me.lblFurtoRapina.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoRapina.Location = New System.Drawing.Point(971, 160)
            Me.lblFurtoRapina.Name = "lblFurtoRapina"
            Me.lblFurtoRapina.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoRapina.TabIndex = 17
            Me.lblFurtoRapina.Text = "0,00"
            Me.lblFurtoRapina.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoRapina
            '
            Me.chkFurtoRapina.AutoSize = True
            Me.chkFurtoRapina.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoRapina.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoRapina.Location = New System.Drawing.Point(0, 160)
            Me.chkFurtoRapina.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoRapina.Name = "chkFurtoRapina"
            Me.chkFurtoRapina.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoRapina.TabIndex = 11
            Me.chkFurtoRapina.UseVisualStyleBackColor = True
            '
            'TabPage5
            '
            Me.TabPage5.Controls.Add(Me.GroupBox5)
            Me.TabPage5.Location = New System.Drawing.Point(4, 29)
            Me.TabPage5.Name = "TabPage5"
            Me.TabPage5.Size = New System.Drawing.Size(1080, 613)
            Me.TabPage5.TabIndex = 4
            Me.TabPage5.Tag = ""
            Me.TabPage5.Text = "Furto 2"
            Me.TabPage5.UseVisualStyleBackColor = True
            '
            'GroupBox5
            '
            Me.GroupBox5.Controls.Add(Me.TableLayoutPanel5)
            Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
            Me.GroupBox5.Margin = New System.Windows.Forms.Padding(0)
            Me.GroupBox5.Name = "GroupBox5"
            Me.GroupBox5.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
            Me.GroupBox5.Size = New System.Drawing.Size(1080, 613)
            Me.GroupBox5.TabIndex = 0
            Me.GroupBox5.TabStop = False
            '
            'TableLayoutPanel5
            '
            Me.TableLayoutPanel5.ColumnCount = 5
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoSpeseAccessorie, 1, 1)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoSpeseAccessorie, 4, 1)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoSpeseAccessorie, 0, 1)
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoSpeseMiglioramento, 1, 2)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoSpeseMiglioramento, 4, 2)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoSpeseMiglioramento, 0, 2)
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoSlotMachine, 1, 3)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoSlotMachine, 4, 3)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoSlotMachine, 0, 3)
            Me.TableLayoutPanel5.Controls.Add(Me.txtPartitaFurtoSlotMachine, 2, 3)
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoReintegroAutomatico, 1, 4)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoReintegroAutomatico, 4, 4)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoReintegroAutomatico, 0, 4)
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoCommercioAmbulante, 1, 5)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoCommercioAmbulante, 4, 5)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoCommercioAmbulante, 0, 5)
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoDepositoRiserva, 1, 6)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoDepositoRiserva, 4, 6)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoDepositoRiserva, 0, 6)
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoDerogaCostruttive, 1, 7)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoDerogaCostruttive, 4, 7)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoDerogaCostruttive, 0, 7)
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoMezziChiusura, 1, 8)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoMezziChiusura, 4, 8)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoMezziChiusura, 0, 8)
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoImpiantoAllarme, 1, 9)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoImpiantoAllarme, 4, 9)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoImpiantoAllarme, 0, 9)
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoAllarmeDistanza, 1, 10)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoAllarmeDistanza, 4, 10)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoAllarmeDistanza, 0, 10)
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoAllarmeDoppio, 1, 11)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoAllarmeDoppio, 4, 11)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoAllarmeDoppio, 0, 11)
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoVideoSorveglianza, 1, 12)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoVideoSorveglianza, 4, 12)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoVideoSorveglianza, 0, 12)
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoScopertoMerciA, 1, 13)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoScopertoMerciA, 4, 13)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoScopertoMerciA, 0, 13)
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoScopertoMerciB, 1, 14)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoScopertoMerciB, 4, 14)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoScopertoMerciB, 0, 14)
            Me.TableLayoutPanel5.Controls.Add(Me.desFurtoPiuEsercizi, 1, 15)
            Me.TableLayoutPanel5.Controls.Add(Me.lblFurtoPiuEsercizi, 4, 15)
            Me.TableLayoutPanel5.Controls.Add(Me.chkFurtoPiuEsercizi, 0, 15)
            Me.TableLayoutPanel5.Controls.Add(Me.lblA5, 1, 0)
            Me.TableLayoutPanel5.Controls.Add(Me.lblB5, 2, 0)
            Me.TableLayoutPanel5.Controls.Add(Me.lblC5, 4, 0)
            Me.TableLayoutPanel5.Controls.Add(Me.lblD5, 0, 0)
            Me.TableLayoutPanel5.Controls.Add(Me.txtPartitaFurtoPiuEsercizi, 2, 15)
            Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 13)
            Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
            Me.TableLayoutPanel5.RowCount = 17
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel5.Size = New System.Drawing.Size(1074, 597)
            Me.TableLayoutPanel5.TabIndex = 0
            '
            'desFurtoSpeseAccessorie
            '
            Me.desFurtoSpeseAccessorie.AutoSize = True
            Me.desFurtoSpeseAccessorie.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoSpeseAccessorie.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoSpeseAccessorie.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoSpeseAccessorie.Location = New System.Drawing.Point(58, 40)
            Me.desFurtoSpeseAccessorie.Name = "desFurtoSpeseAccessorie"
            Me.desFurtoSpeseAccessorie.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoSpeseAccessorie.TabIndex = 0
            Me.desFurtoSpeseAccessorie.Tag = "240"
            Me.desFurtoSpeseAccessorie.Text = "Spese accessorie"
            Me.desFurtoSpeseAccessorie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoSpeseAccessorie
            '
            Me.lblFurtoSpeseAccessorie.AutoSize = True
            Me.lblFurtoSpeseAccessorie.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoSpeseAccessorie.Location = New System.Drawing.Point(971, 40)
            Me.lblFurtoSpeseAccessorie.Name = "lblFurtoSpeseAccessorie"
            Me.lblFurtoSpeseAccessorie.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoSpeseAccessorie.TabIndex = 1
            Me.lblFurtoSpeseAccessorie.Text = "0,00"
            Me.lblFurtoSpeseAccessorie.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoSpeseAccessorie
            '
            Me.chkFurtoSpeseAccessorie.AutoSize = True
            Me.chkFurtoSpeseAccessorie.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoSpeseAccessorie.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoSpeseAccessorie.Location = New System.Drawing.Point(0, 40)
            Me.chkFurtoSpeseAccessorie.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoSpeseAccessorie.Name = "chkFurtoSpeseAccessorie"
            Me.chkFurtoSpeseAccessorie.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoSpeseAccessorie.TabIndex = 0
            Me.chkFurtoSpeseAccessorie.UseVisualStyleBackColor = True
            '
            'desFurtoSpeseMiglioramento
            '
            Me.desFurtoSpeseMiglioramento.AutoSize = True
            Me.desFurtoSpeseMiglioramento.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoSpeseMiglioramento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoSpeseMiglioramento.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoSpeseMiglioramento.Location = New System.Drawing.Point(58, 70)
            Me.desFurtoSpeseMiglioramento.Name = "desFurtoSpeseMiglioramento"
            Me.desFurtoSpeseMiglioramento.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoSpeseMiglioramento.TabIndex = 3
            Me.desFurtoSpeseMiglioramento.Tag = "241"
            Me.desFurtoSpeseMiglioramento.Text = "Miglioramento dei sistemi di prevenzione e/o protezione"
            Me.desFurtoSpeseMiglioramento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoSpeseMiglioramento
            '
            Me.lblFurtoSpeseMiglioramento.AutoSize = True
            Me.lblFurtoSpeseMiglioramento.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoSpeseMiglioramento.Location = New System.Drawing.Point(971, 70)
            Me.lblFurtoSpeseMiglioramento.Name = "lblFurtoSpeseMiglioramento"
            Me.lblFurtoSpeseMiglioramento.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoSpeseMiglioramento.TabIndex = 4
            Me.lblFurtoSpeseMiglioramento.Text = "0,00"
            Me.lblFurtoSpeseMiglioramento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoSpeseMiglioramento
            '
            Me.chkFurtoSpeseMiglioramento.AutoSize = True
            Me.chkFurtoSpeseMiglioramento.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoSpeseMiglioramento.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoSpeseMiglioramento.Location = New System.Drawing.Point(0, 70)
            Me.chkFurtoSpeseMiglioramento.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoSpeseMiglioramento.Name = "chkFurtoSpeseMiglioramento"
            Me.chkFurtoSpeseMiglioramento.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoSpeseMiglioramento.TabIndex = 1
            Me.chkFurtoSpeseMiglioramento.UseVisualStyleBackColor = True
            '
            'desFurtoSlotMachine
            '
            Me.desFurtoSlotMachine.AutoSize = True
            Me.desFurtoSlotMachine.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoSlotMachine.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoSlotMachine.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoSlotMachine.Location = New System.Drawing.Point(58, 100)
            Me.desFurtoSlotMachine.Name = "desFurtoSlotMachine"
            Me.desFurtoSlotMachine.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoSlotMachine.TabIndex = 6
            Me.desFurtoSlotMachine.Tag = "242"
            Me.desFurtoSlotMachine.Text = "Slot machine, gettoniere, cambiamonete e relativi contenuti"
            Me.desFurtoSlotMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoSlotMachine
            '
            Me.lblFurtoSlotMachine.AutoSize = True
            Me.lblFurtoSlotMachine.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoSlotMachine.Location = New System.Drawing.Point(971, 100)
            Me.lblFurtoSlotMachine.Name = "lblFurtoSlotMachine"
            Me.lblFurtoSlotMachine.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoSlotMachine.TabIndex = 7
            Me.lblFurtoSlotMachine.Text = "0,00"
            Me.lblFurtoSlotMachine.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoSlotMachine
            '
            Me.chkFurtoSlotMachine.AutoSize = True
            Me.chkFurtoSlotMachine.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoSlotMachine.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoSlotMachine.Location = New System.Drawing.Point(0, 100)
            Me.chkFurtoSlotMachine.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoSlotMachine.Name = "chkFurtoSlotMachine"
            Me.chkFurtoSlotMachine.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoSlotMachine.TabIndex = 3
            Me.chkFurtoSlotMachine.UseVisualStyleBackColor = True
            '
            'txtPartitaFurtoSlotMachine
            '
            Me.txtPartitaFurtoSlotMachine.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoSlotMachine.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoSlotMachine.Location = New System.Drawing.Point(423, 103)
            Me.txtPartitaFurtoSlotMachine.Name = "txtPartitaFurtoSlotMachine"
            Me.txtPartitaFurtoSlotMachine.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoSlotMachine.TabIndex = 2
            Me.txtPartitaFurtoSlotMachine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desFurtoReintegroAutomatico
            '
            Me.desFurtoReintegroAutomatico.AutoSize = True
            Me.desFurtoReintegroAutomatico.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoReintegroAutomatico.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoReintegroAutomatico.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoReintegroAutomatico.Location = New System.Drawing.Point(58, 130)
            Me.desFurtoReintegroAutomatico.Name = "desFurtoReintegroAutomatico"
            Me.desFurtoReintegroAutomatico.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoReintegroAutomatico.TabIndex = 10
            Me.desFurtoReintegroAutomatico.Tag = "243"
            Me.desFurtoReintegroAutomatico.Text = "Reintegro automatico"
            Me.desFurtoReintegroAutomatico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoReintegroAutomatico
            '
            Me.lblFurtoReintegroAutomatico.AutoSize = True
            Me.lblFurtoReintegroAutomatico.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoReintegroAutomatico.Location = New System.Drawing.Point(971, 130)
            Me.lblFurtoReintegroAutomatico.Name = "lblFurtoReintegroAutomatico"
            Me.lblFurtoReintegroAutomatico.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoReintegroAutomatico.TabIndex = 11
            Me.lblFurtoReintegroAutomatico.Text = "0,00"
            Me.lblFurtoReintegroAutomatico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoReintegroAutomatico
            '
            Me.chkFurtoReintegroAutomatico.AutoSize = True
            Me.chkFurtoReintegroAutomatico.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoReintegroAutomatico.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoReintegroAutomatico.Location = New System.Drawing.Point(0, 130)
            Me.chkFurtoReintegroAutomatico.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoReintegroAutomatico.Name = "chkFurtoReintegroAutomatico"
            Me.chkFurtoReintegroAutomatico.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoReintegroAutomatico.TabIndex = 4
            Me.chkFurtoReintegroAutomatico.UseVisualStyleBackColor = True
            '
            'desFurtoCommercioAmbulante
            '
            Me.desFurtoCommercioAmbulante.AutoSize = True
            Me.desFurtoCommercioAmbulante.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoCommercioAmbulante.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoCommercioAmbulante.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoCommercioAmbulante.Location = New System.Drawing.Point(58, 160)
            Me.desFurtoCommercioAmbulante.Name = "desFurtoCommercioAmbulante"
            Me.desFurtoCommercioAmbulante.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoCommercioAmbulante.TabIndex = 13
            Me.desFurtoCommercioAmbulante.Tag = "244"
            Me.desFurtoCommercioAmbulante.Text = "Commercio ambulante"
            Me.desFurtoCommercioAmbulante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoCommercioAmbulante
            '
            Me.lblFurtoCommercioAmbulante.AutoSize = True
            Me.lblFurtoCommercioAmbulante.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoCommercioAmbulante.Location = New System.Drawing.Point(971, 160)
            Me.lblFurtoCommercioAmbulante.Name = "lblFurtoCommercioAmbulante"
            Me.lblFurtoCommercioAmbulante.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoCommercioAmbulante.TabIndex = 14
            Me.lblFurtoCommercioAmbulante.Text = "0,00"
            Me.lblFurtoCommercioAmbulante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoCommercioAmbulante
            '
            Me.chkFurtoCommercioAmbulante.AutoSize = True
            Me.chkFurtoCommercioAmbulante.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoCommercioAmbulante.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoCommercioAmbulante.Location = New System.Drawing.Point(0, 160)
            Me.chkFurtoCommercioAmbulante.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoCommercioAmbulante.Name = "chkFurtoCommercioAmbulante"
            Me.chkFurtoCommercioAmbulante.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoCommercioAmbulante.TabIndex = 5
            Me.chkFurtoCommercioAmbulante.UseVisualStyleBackColor = True
            '
            'desFurtoDepositoRiserva
            '
            Me.desFurtoDepositoRiserva.AutoSize = True
            Me.desFurtoDepositoRiserva.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoDepositoRiserva.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoDepositoRiserva.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoDepositoRiserva.Location = New System.Drawing.Point(58, 190)
            Me.desFurtoDepositoRiserva.Name = "desFurtoDepositoRiserva"
            Me.desFurtoDepositoRiserva.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoDepositoRiserva.TabIndex = 16
            Me.desFurtoDepositoRiserva.Tag = "245"
            Me.desFurtoDepositoRiserva.Text = "Deposito di riserva"
            Me.desFurtoDepositoRiserva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoDepositoRiserva
            '
            Me.lblFurtoDepositoRiserva.AutoSize = True
            Me.lblFurtoDepositoRiserva.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoDepositoRiserva.Location = New System.Drawing.Point(971, 190)
            Me.lblFurtoDepositoRiserva.Name = "lblFurtoDepositoRiserva"
            Me.lblFurtoDepositoRiserva.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoDepositoRiserva.TabIndex = 17
            Me.lblFurtoDepositoRiserva.Text = "0,00"
            Me.lblFurtoDepositoRiserva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoDepositoRiserva
            '
            Me.chkFurtoDepositoRiserva.AutoSize = True
            Me.chkFurtoDepositoRiserva.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoDepositoRiserva.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoDepositoRiserva.Location = New System.Drawing.Point(0, 190)
            Me.chkFurtoDepositoRiserva.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoDepositoRiserva.Name = "chkFurtoDepositoRiserva"
            Me.chkFurtoDepositoRiserva.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoDepositoRiserva.TabIndex = 6
            Me.chkFurtoDepositoRiserva.UseVisualStyleBackColor = True
            '
            'desFurtoDerogaCostruttive
            '
            Me.desFurtoDerogaCostruttive.AutoSize = True
            Me.desFurtoDerogaCostruttive.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoDerogaCostruttive.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoDerogaCostruttive.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoDerogaCostruttive.Location = New System.Drawing.Point(58, 220)
            Me.desFurtoDerogaCostruttive.Name = "desFurtoDerogaCostruttive"
            Me.desFurtoDerogaCostruttive.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoDerogaCostruttive.TabIndex = 19
            Me.desFurtoDerogaCostruttive.Tag = "246"
            Me.desFurtoDerogaCostruttive.Text = "Deroga alle caratteristiche costruttive"
            Me.desFurtoDerogaCostruttive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoDerogaCostruttive
            '
            Me.lblFurtoDerogaCostruttive.AutoSize = True
            Me.lblFurtoDerogaCostruttive.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoDerogaCostruttive.Location = New System.Drawing.Point(971, 220)
            Me.lblFurtoDerogaCostruttive.Name = "lblFurtoDerogaCostruttive"
            Me.lblFurtoDerogaCostruttive.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoDerogaCostruttive.TabIndex = 20
            Me.lblFurtoDerogaCostruttive.Text = "0,00"
            Me.lblFurtoDerogaCostruttive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoDerogaCostruttive
            '
            Me.chkFurtoDerogaCostruttive.AutoSize = True
            Me.chkFurtoDerogaCostruttive.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoDerogaCostruttive.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoDerogaCostruttive.Location = New System.Drawing.Point(0, 220)
            Me.chkFurtoDerogaCostruttive.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoDerogaCostruttive.Name = "chkFurtoDerogaCostruttive"
            Me.chkFurtoDerogaCostruttive.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoDerogaCostruttive.TabIndex = 7
            Me.chkFurtoDerogaCostruttive.UseVisualStyleBackColor = True
            '
            'desFurtoMezziChiusura
            '
            Me.desFurtoMezziChiusura.AutoSize = True
            Me.desFurtoMezziChiusura.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoMezziChiusura.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoMezziChiusura.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoMezziChiusura.Location = New System.Drawing.Point(58, 250)
            Me.desFurtoMezziChiusura.Name = "desFurtoMezziChiusura"
            Me.desFurtoMezziChiusura.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoMezziChiusura.TabIndex = 22
            Me.desFurtoMezziChiusura.Tag = "247"
            Me.desFurtoMezziChiusura.Text = "Mezzi di Chiusura Particolari"
            Me.desFurtoMezziChiusura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoMezziChiusura
            '
            Me.lblFurtoMezziChiusura.AutoSize = True
            Me.lblFurtoMezziChiusura.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoMezziChiusura.Location = New System.Drawing.Point(971, 250)
            Me.lblFurtoMezziChiusura.Name = "lblFurtoMezziChiusura"
            Me.lblFurtoMezziChiusura.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoMezziChiusura.TabIndex = 23
            Me.lblFurtoMezziChiusura.Text = "0,00"
            Me.lblFurtoMezziChiusura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoMezziChiusura
            '
            Me.chkFurtoMezziChiusura.AutoSize = True
            Me.chkFurtoMezziChiusura.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoMezziChiusura.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoMezziChiusura.Location = New System.Drawing.Point(0, 250)
            Me.chkFurtoMezziChiusura.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoMezziChiusura.Name = "chkFurtoMezziChiusura"
            Me.chkFurtoMezziChiusura.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoMezziChiusura.TabIndex = 8
            Me.chkFurtoMezziChiusura.UseVisualStyleBackColor = True
            '
            'desFurtoImpiantoAllarme
            '
            Me.desFurtoImpiantoAllarme.AutoSize = True
            Me.desFurtoImpiantoAllarme.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoImpiantoAllarme.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoImpiantoAllarme.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoImpiantoAllarme.Location = New System.Drawing.Point(58, 280)
            Me.desFurtoImpiantoAllarme.Name = "desFurtoImpiantoAllarme"
            Me.desFurtoImpiantoAllarme.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoImpiantoAllarme.TabIndex = 25
            Me.desFurtoImpiantoAllarme.Tag = "248"
            Me.desFurtoImpiantoAllarme.Text = "Impianto di allarme"
            Me.desFurtoImpiantoAllarme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoImpiantoAllarme
            '
            Me.lblFurtoImpiantoAllarme.AutoSize = True
            Me.lblFurtoImpiantoAllarme.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoImpiantoAllarme.Location = New System.Drawing.Point(971, 280)
            Me.lblFurtoImpiantoAllarme.Name = "lblFurtoImpiantoAllarme"
            Me.lblFurtoImpiantoAllarme.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoImpiantoAllarme.TabIndex = 26
            Me.lblFurtoImpiantoAllarme.Text = "0,00"
            Me.lblFurtoImpiantoAllarme.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoImpiantoAllarme
            '
            Me.chkFurtoImpiantoAllarme.AutoSize = True
            Me.chkFurtoImpiantoAllarme.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoImpiantoAllarme.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoImpiantoAllarme.Location = New System.Drawing.Point(0, 280)
            Me.chkFurtoImpiantoAllarme.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoImpiantoAllarme.Name = "chkFurtoImpiantoAllarme"
            Me.chkFurtoImpiantoAllarme.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoImpiantoAllarme.TabIndex = 9
            Me.chkFurtoImpiantoAllarme.UseVisualStyleBackColor = True
            '
            'desFurtoAllarmeDistanza
            '
            Me.desFurtoAllarmeDistanza.AutoSize = True
            Me.desFurtoAllarmeDistanza.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoAllarmeDistanza.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoAllarmeDistanza.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoAllarmeDistanza.Location = New System.Drawing.Point(58, 310)
            Me.desFurtoAllarmeDistanza.Name = "desFurtoAllarmeDistanza"
            Me.desFurtoAllarmeDistanza.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoAllarmeDistanza.TabIndex = 28
            Me.desFurtoAllarmeDistanza.Tag = "249"
            Me.desFurtoAllarmeDistanza.Text = "Antifurto con registratore e trasmissione a distanza"
            Me.desFurtoAllarmeDistanza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoAllarmeDistanza
            '
            Me.lblFurtoAllarmeDistanza.AutoSize = True
            Me.lblFurtoAllarmeDistanza.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoAllarmeDistanza.Location = New System.Drawing.Point(971, 310)
            Me.lblFurtoAllarmeDistanza.Name = "lblFurtoAllarmeDistanza"
            Me.lblFurtoAllarmeDistanza.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoAllarmeDistanza.TabIndex = 29
            Me.lblFurtoAllarmeDistanza.Text = "0,00"
            Me.lblFurtoAllarmeDistanza.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoAllarmeDistanza
            '
            Me.chkFurtoAllarmeDistanza.AutoSize = True
            Me.chkFurtoAllarmeDistanza.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoAllarmeDistanza.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoAllarmeDistanza.Location = New System.Drawing.Point(0, 310)
            Me.chkFurtoAllarmeDistanza.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoAllarmeDistanza.Name = "chkFurtoAllarmeDistanza"
            Me.chkFurtoAllarmeDistanza.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoAllarmeDistanza.TabIndex = 10
            Me.chkFurtoAllarmeDistanza.UseVisualStyleBackColor = True
            '
            'desFurtoAllarmeDoppio
            '
            Me.desFurtoAllarmeDoppio.AutoSize = True
            Me.desFurtoAllarmeDoppio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoAllarmeDoppio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoAllarmeDoppio.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoAllarmeDoppio.Location = New System.Drawing.Point(58, 340)
            Me.desFurtoAllarmeDoppio.Name = "desFurtoAllarmeDoppio"
            Me.desFurtoAllarmeDoppio.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoAllarmeDoppio.TabIndex = 31
            Me.desFurtoAllarmeDoppio.Tag = "250"
            Me.desFurtoAllarmeDoppio.Text = "Impianto d’allarme antifurto con doppio livello di protezione"
            Me.desFurtoAllarmeDoppio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoAllarmeDoppio
            '
            Me.lblFurtoAllarmeDoppio.AutoSize = True
            Me.lblFurtoAllarmeDoppio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoAllarmeDoppio.Location = New System.Drawing.Point(971, 340)
            Me.lblFurtoAllarmeDoppio.Name = "lblFurtoAllarmeDoppio"
            Me.lblFurtoAllarmeDoppio.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoAllarmeDoppio.TabIndex = 32
            Me.lblFurtoAllarmeDoppio.Text = "0,00"
            Me.lblFurtoAllarmeDoppio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoAllarmeDoppio
            '
            Me.chkFurtoAllarmeDoppio.AutoSize = True
            Me.chkFurtoAllarmeDoppio.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoAllarmeDoppio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoAllarmeDoppio.Location = New System.Drawing.Point(0, 340)
            Me.chkFurtoAllarmeDoppio.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoAllarmeDoppio.Name = "chkFurtoAllarmeDoppio"
            Me.chkFurtoAllarmeDoppio.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoAllarmeDoppio.TabIndex = 11
            Me.chkFurtoAllarmeDoppio.UseVisualStyleBackColor = True
            '
            'desFurtoVideoSorveglianza
            '
            Me.desFurtoVideoSorveglianza.AutoSize = True
            Me.desFurtoVideoSorveglianza.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoVideoSorveglianza.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoVideoSorveglianza.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoVideoSorveglianza.Location = New System.Drawing.Point(58, 370)
            Me.desFurtoVideoSorveglianza.Name = "desFurtoVideoSorveglianza"
            Me.desFurtoVideoSorveglianza.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoVideoSorveglianza.TabIndex = 34
            Me.desFurtoVideoSorveglianza.Tag = "251"
            Me.desFurtoVideoSorveglianza.Text = "Impianto d’allarme antifurto con video-sorveglianza"
            Me.desFurtoVideoSorveglianza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoVideoSorveglianza
            '
            Me.lblFurtoVideoSorveglianza.AutoSize = True
            Me.lblFurtoVideoSorveglianza.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoVideoSorveglianza.Location = New System.Drawing.Point(971, 370)
            Me.lblFurtoVideoSorveglianza.Name = "lblFurtoVideoSorveglianza"
            Me.lblFurtoVideoSorveglianza.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoVideoSorveglianza.TabIndex = 35
            Me.lblFurtoVideoSorveglianza.Text = "0,00"
            Me.lblFurtoVideoSorveglianza.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoVideoSorveglianza
            '
            Me.chkFurtoVideoSorveglianza.AutoSize = True
            Me.chkFurtoVideoSorveglianza.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoVideoSorveglianza.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoVideoSorveglianza.Location = New System.Drawing.Point(0, 370)
            Me.chkFurtoVideoSorveglianza.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoVideoSorveglianza.Name = "chkFurtoVideoSorveglianza"
            Me.chkFurtoVideoSorveglianza.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoVideoSorveglianza.TabIndex = 12
            Me.chkFurtoVideoSorveglianza.UseVisualStyleBackColor = True
            '
            'desFurtoScopertoMerciA
            '
            Me.desFurtoScopertoMerciA.AutoSize = True
            Me.desFurtoScopertoMerciA.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoScopertoMerciA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoScopertoMerciA.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoScopertoMerciA.Location = New System.Drawing.Point(58, 400)
            Me.desFurtoScopertoMerciA.Name = "desFurtoScopertoMerciA"
            Me.desFurtoScopertoMerciA.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoScopertoMerciA.TabIndex = 37
            Me.desFurtoScopertoMerciA.Tag = "252"
            Me.desFurtoScopertoMerciA.Text = "Abrogazione dello Scoperto per Merci di classe A1 e A2"
            Me.desFurtoScopertoMerciA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoScopertoMerciA
            '
            Me.lblFurtoScopertoMerciA.AutoSize = True
            Me.lblFurtoScopertoMerciA.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoScopertoMerciA.Location = New System.Drawing.Point(971, 400)
            Me.lblFurtoScopertoMerciA.Name = "lblFurtoScopertoMerciA"
            Me.lblFurtoScopertoMerciA.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoScopertoMerciA.TabIndex = 38
            Me.lblFurtoScopertoMerciA.Text = "0,00"
            Me.lblFurtoScopertoMerciA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoScopertoMerciA
            '
            Me.chkFurtoScopertoMerciA.AutoSize = True
            Me.chkFurtoScopertoMerciA.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoScopertoMerciA.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoScopertoMerciA.Location = New System.Drawing.Point(0, 400)
            Me.chkFurtoScopertoMerciA.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoScopertoMerciA.Name = "chkFurtoScopertoMerciA"
            Me.chkFurtoScopertoMerciA.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoScopertoMerciA.TabIndex = 13
            Me.chkFurtoScopertoMerciA.UseVisualStyleBackColor = True
            '
            'desFurtoScopertoMerciB
            '
            Me.desFurtoScopertoMerciB.AutoSize = True
            Me.desFurtoScopertoMerciB.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoScopertoMerciB.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoScopertoMerciB.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoScopertoMerciB.Location = New System.Drawing.Point(58, 430)
            Me.desFurtoScopertoMerciB.Name = "desFurtoScopertoMerciB"
            Me.desFurtoScopertoMerciB.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoScopertoMerciB.TabIndex = 40
            Me.desFurtoScopertoMerciB.Tag = "253"
            Me.desFurtoScopertoMerciB.Text = "Scoperto per Merci di classe B1-B2-C1-C2-D1-D2"
            Me.desFurtoScopertoMerciB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoScopertoMerciB
            '
            Me.lblFurtoScopertoMerciB.AutoSize = True
            Me.lblFurtoScopertoMerciB.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoScopertoMerciB.Location = New System.Drawing.Point(971, 430)
            Me.lblFurtoScopertoMerciB.Name = "lblFurtoScopertoMerciB"
            Me.lblFurtoScopertoMerciB.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoScopertoMerciB.TabIndex = 41
            Me.lblFurtoScopertoMerciB.Text = "0,00"
            Me.lblFurtoScopertoMerciB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoScopertoMerciB
            '
            Me.chkFurtoScopertoMerciB.AutoSize = True
            Me.chkFurtoScopertoMerciB.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoScopertoMerciB.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoScopertoMerciB.Location = New System.Drawing.Point(0, 430)
            Me.chkFurtoScopertoMerciB.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoScopertoMerciB.Name = "chkFurtoScopertoMerciB"
            Me.chkFurtoScopertoMerciB.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoScopertoMerciB.TabIndex = 14
            Me.chkFurtoScopertoMerciB.UseVisualStyleBackColor = True
            '
            'desFurtoPiuEsercizi
            '
            Me.desFurtoPiuEsercizi.AutoSize = True
            Me.desFurtoPiuEsercizi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desFurtoPiuEsercizi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desFurtoPiuEsercizi.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desFurtoPiuEsercizi.Location = New System.Drawing.Point(58, 460)
            Me.desFurtoPiuEsercizi.Name = "desFurtoPiuEsercizi"
            Me.desFurtoPiuEsercizi.Size = New System.Drawing.Size(359, 30)
            Me.desFurtoPiuEsercizi.TabIndex = 43
            Me.desFurtoPiuEsercizi.Tag = "254"
            Me.desFurtoPiuEsercizi.Text = "Pluralità Esercizi assicurati"
            Me.desFurtoPiuEsercizi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFurtoPiuEsercizi
            '
            Me.lblFurtoPiuEsercizi.AutoSize = True
            Me.lblFurtoPiuEsercizi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblFurtoPiuEsercizi.Location = New System.Drawing.Point(971, 460)
            Me.lblFurtoPiuEsercizi.Name = "lblFurtoPiuEsercizi"
            Me.lblFurtoPiuEsercizi.Size = New System.Drawing.Size(100, 30)
            Me.lblFurtoPiuEsercizi.TabIndex = 44
            Me.lblFurtoPiuEsercizi.Text = "0,00"
            Me.lblFurtoPiuEsercizi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkFurtoPiuEsercizi
            '
            Me.chkFurtoPiuEsercizi.AutoSize = True
            Me.chkFurtoPiuEsercizi.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkFurtoPiuEsercizi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkFurtoPiuEsercizi.Location = New System.Drawing.Point(0, 460)
            Me.chkFurtoPiuEsercizi.Margin = New System.Windows.Forms.Padding(0)
            Me.chkFurtoPiuEsercizi.Name = "chkFurtoPiuEsercizi"
            Me.chkFurtoPiuEsercizi.Size = New System.Drawing.Size(55, 30)
            Me.chkFurtoPiuEsercizi.TabIndex = 16
            Me.chkFurtoPiuEsercizi.UseVisualStyleBackColor = True
            '
            'lblA5
            '
            Me.lblA5.AutoSize = True
            Me.lblA5.BackColor = System.Drawing.Color.Khaki
            Me.lblA5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblA5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblA5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblA5.Location = New System.Drawing.Point(58, 0)
            Me.lblA5.Name = "lblA5"
            Me.lblA5.Size = New System.Drawing.Size(359, 40)
            Me.lblA5.TabIndex = 46
            Me.lblA5.Text = "Partita / Garanzia"
            Me.lblA5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblB5
            '
            Me.lblB5.AutoSize = True
            Me.lblB5.BackColor = System.Drawing.Color.Khaki
            Me.lblB5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.TableLayoutPanel5.SetColumnSpan(Me.lblB5, 2)
            Me.lblB5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblB5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblB5.Location = New System.Drawing.Point(423, 0)
            Me.lblB5.Name = "lblB5"
            Me.lblB5.Size = New System.Drawing.Size(542, 40)
            Me.lblB5.TabIndex = 47
            Me.lblB5.Text = "Parametri/Condizioni"
            Me.lblB5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblC5
            '
            Me.lblC5.AutoSize = True
            Me.lblC5.BackColor = System.Drawing.Color.Khaki
            Me.lblC5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblC5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblC5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblC5.Location = New System.Drawing.Point(971, 0)
            Me.lblC5.Name = "lblC5"
            Me.lblC5.Size = New System.Drawing.Size(100, 40)
            Me.lblC5.TabIndex = 48
            Me.lblC5.Text = "Premio"
            Me.lblC5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblD5
            '
            Me.lblD5.AutoSize = True
            Me.lblD5.BackColor = System.Drawing.Color.Khaki
            Me.lblD5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblD5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblD5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblD5.Location = New System.Drawing.Point(3, 0)
            Me.lblD5.Name = "lblD5"
            Me.lblD5.Size = New System.Drawing.Size(49, 40)
            Me.lblD5.TabIndex = 49
            Me.lblD5.Text = "Scelto"
            Me.lblD5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtPartitaFurtoPiuEsercizi
            '
            Me.txtPartitaFurtoPiuEsercizi.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaFurtoPiuEsercizi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaFurtoPiuEsercizi.Location = New System.Drawing.Point(423, 463)
            Me.txtPartitaFurtoPiuEsercizi.Name = "txtPartitaFurtoPiuEsercizi"
            Me.txtPartitaFurtoPiuEsercizi.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaFurtoPiuEsercizi.TabIndex = 15
            Me.txtPartitaFurtoPiuEsercizi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'TabPage8
            '
            Me.TabPage8.Controls.Add(Me.GroupBox8)
            Me.TabPage8.Location = New System.Drawing.Point(4, 29)
            Me.TabPage8.Name = "TabPage8"
            Me.TabPage8.Size = New System.Drawing.Size(1080, 613)
            Me.TabPage8.TabIndex = 6
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
            Me.GroupBox8.Size = New System.Drawing.Size(1080, 613)
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
            Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
            Me.TableLayoutPanel8.Controls.Add(Me.lblTerremotoPremio, 4, 1)
            Me.TableLayoutPanel8.Controls.Add(Me.cmbCaratteristicaCostruttiva, 3, 1)
            Me.TableLayoutPanel8.Controls.Add(Me.desTerremotoFabbricato, 1, 2)
            Me.TableLayoutPanel8.Controls.Add(Me.lblTerremotoFabbricato, 4, 2)
            Me.TableLayoutPanel8.Controls.Add(Me.chkTerremotoFabbricato, 0, 2)
            Me.TableLayoutPanel8.Controls.Add(Me.txtPartitaTerremotoFabbricato, 2, 2)
            Me.TableLayoutPanel8.Controls.Add(Me.desTerremotoContenuto, 1, 3)
            Me.TableLayoutPanel8.Controls.Add(Me.lblTerremotoContenuto, 4, 3)
            Me.TableLayoutPanel8.Controls.Add(Me.chkTerremotoContenuto, 0, 3)
            Me.TableLayoutPanel8.Controls.Add(Me.txtPartitaTerremotoContenuto, 2, 3)
            Me.TableLayoutPanel8.Controls.Add(Me.desTerremotoDemolizione, 1, 4)
            Me.TableLayoutPanel8.Controls.Add(Me.lblTerremotoDemolizione, 4, 4)
            Me.TableLayoutPanel8.Controls.Add(Me.chkTerremotoDemolizione, 0, 4)
            Me.TableLayoutPanel8.Controls.Add(Me.cmbTerremotoDemolizioneMassimale, 2, 4)
            Me.TableLayoutPanel8.Controls.Add(Me.desTerremotoAumentoMerci, 1, 5)
            Me.TableLayoutPanel8.Controls.Add(Me.lblTerremotoAumentoMerci, 4, 5)
            Me.TableLayoutPanel8.Controls.Add(Me.chkTerremotoAumentoMerci, 0, 5)
            Me.TableLayoutPanel8.Controls.Add(Me.desTerremotoRicetteMediche, 1, 6)
            Me.TableLayoutPanel8.Controls.Add(Me.lblTerremotoRicetteMediche, 4, 6)
            Me.TableLayoutPanel8.Controls.Add(Me.chkTerremotoRicetteMediche, 0, 6)
            Me.TableLayoutPanel8.Controls.Add(Me.txtPartitaTerremotoRicetteMediche, 2, 6)
            Me.TableLayoutPanel8.Controls.Add(Me.lblA8, 1, 0)
            Me.TableLayoutPanel8.Controls.Add(Me.lblB8, 2, 0)
            Me.TableLayoutPanel8.Controls.Add(Me.lblC8, 4, 0)
            Me.TableLayoutPanel8.Controls.Add(Me.lblD8, 0, 0)
            Me.TableLayoutPanel8.Controls.Add(Me.chkTerremotoBase, 0, 1)
            Me.TableLayoutPanel8.Controls.Add(Me.txtTerremotoAumentoMerciMesi, 3, 5)
            Me.TableLayoutPanel8.Controls.Add(Me.txtPartitaTerremotoAumentoMerci, 2, 5)
            Me.TableLayoutPanel8.Controls.Add(Me.cmbTerremotoFabbricatoLimite, 3, 2)
            Me.TableLayoutPanel8.Controls.Add(Me.cmbTipologiaFabbricato, 2, 1)
            Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 13)
            Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
            Me.TableLayoutPanel8.RowCount = 9
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel8.Size = New System.Drawing.Size(1074, 597)
            Me.TableLayoutPanel8.TabIndex = 0
            '
            'lblTerremotoPremio
            '
            Me.lblTerremotoPremio.AutoSize = True
            Me.lblTerremotoPremio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTerremotoPremio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTerremotoPremio.Location = New System.Drawing.Point(971, 40)
            Me.lblTerremotoPremio.Name = "lblTerremotoPremio"
            Me.lblTerremotoPremio.Size = New System.Drawing.Size(100, 25)
            Me.lblTerremotoPremio.TabIndex = 2
            Me.lblTerremotoPremio.Text = "0,00"
            Me.lblTerremotoPremio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbCaratteristicaCostruttiva
            '
            Me.cmbCaratteristicaCostruttiva.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbCaratteristicaCostruttiva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCaratteristicaCostruttiva.FormattingEnabled = True
            Me.cmbCaratteristicaCostruttiva.Location = New System.Drawing.Point(697, 43)
            Me.cmbCaratteristicaCostruttiva.Name = "cmbCaratteristicaCostruttiva"
            Me.cmbCaratteristicaCostruttiva.Size = New System.Drawing.Size(268, 21)
            Me.cmbCaratteristicaCostruttiva.TabIndex = 7
            '
            'desTerremotoFabbricato
            '
            Me.desTerremotoFabbricato.AutoSize = True
            Me.desTerremotoFabbricato.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desTerremotoFabbricato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desTerremotoFabbricato.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desTerremotoFabbricato.Location = New System.Drawing.Point(58, 65)
            Me.desTerremotoFabbricato.Name = "desTerremotoFabbricato"
            Me.desTerremotoFabbricato.Size = New System.Drawing.Size(359, 25)
            Me.desTerremotoFabbricato.TabIndex = 8
            Me.desTerremotoFabbricato.Tag = "102"
            Me.desTerremotoFabbricato.Text = "Fabbricato"
            Me.desTerremotoFabbricato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblTerremotoFabbricato
            '
            Me.lblTerremotoFabbricato.AutoSize = True
            Me.lblTerremotoFabbricato.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTerremotoFabbricato.Location = New System.Drawing.Point(971, 65)
            Me.lblTerremotoFabbricato.Name = "lblTerremotoFabbricato"
            Me.lblTerremotoFabbricato.Size = New System.Drawing.Size(100, 25)
            Me.lblTerremotoFabbricato.TabIndex = 9
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
            Me.chkTerremotoFabbricato.TabIndex = 10
            Me.chkTerremotoFabbricato.UseVisualStyleBackColor = True
            '
            'txtPartitaTerremotoFabbricato
            '
            Me.txtPartitaTerremotoFabbricato.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaTerremotoFabbricato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaTerremotoFabbricato.Location = New System.Drawing.Point(423, 68)
            Me.txtPartitaTerremotoFabbricato.Name = "txtPartitaTerremotoFabbricato"
            Me.txtPartitaTerremotoFabbricato.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaTerremotoFabbricato.TabIndex = 11
            Me.txtPartitaTerremotoFabbricato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desTerremotoContenuto
            '
            Me.desTerremotoContenuto.AutoSize = True
            Me.desTerremotoContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desTerremotoContenuto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desTerremotoContenuto.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desTerremotoContenuto.Location = New System.Drawing.Point(58, 90)
            Me.desTerremotoContenuto.Name = "desTerremotoContenuto"
            Me.desTerremotoContenuto.Size = New System.Drawing.Size(359, 25)
            Me.desTerremotoContenuto.TabIndex = 12
            Me.desTerremotoContenuto.Tag = "103"
            Me.desTerremotoContenuto.Text = "Contenuto"
            Me.desTerremotoContenuto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblTerremotoContenuto
            '
            Me.lblTerremotoContenuto.AutoSize = True
            Me.lblTerremotoContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTerremotoContenuto.Location = New System.Drawing.Point(971, 90)
            Me.lblTerremotoContenuto.Name = "lblTerremotoContenuto"
            Me.lblTerremotoContenuto.Size = New System.Drawing.Size(100, 25)
            Me.lblTerremotoContenuto.TabIndex = 13
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
            Me.chkTerremotoContenuto.TabIndex = 14
            Me.chkTerremotoContenuto.UseVisualStyleBackColor = True
            '
            'txtPartitaTerremotoContenuto
            '
            Me.txtPartitaTerremotoContenuto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaTerremotoContenuto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaTerremotoContenuto.Location = New System.Drawing.Point(423, 93)
            Me.txtPartitaTerremotoContenuto.Name = "txtPartitaTerremotoContenuto"
            Me.txtPartitaTerremotoContenuto.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaTerremotoContenuto.TabIndex = 15
            Me.txtPartitaTerremotoContenuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'desTerremotoDemolizione
            '
            Me.desTerremotoDemolizione.AutoSize = True
            Me.desTerremotoDemolizione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desTerremotoDemolizione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desTerremotoDemolizione.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desTerremotoDemolizione.Location = New System.Drawing.Point(58, 115)
            Me.desTerremotoDemolizione.Name = "desTerremotoDemolizione"
            Me.desTerremotoDemolizione.Size = New System.Drawing.Size(359, 25)
            Me.desTerremotoDemolizione.TabIndex = 16
            Me.desTerremotoDemolizione.Tag = "104"
            Me.desTerremotoDemolizione.Text = "Spese di demolizione, sgombero, ..."
            Me.desTerremotoDemolizione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblTerremotoDemolizione
            '
            Me.lblTerremotoDemolizione.AutoSize = True
            Me.lblTerremotoDemolizione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTerremotoDemolizione.Location = New System.Drawing.Point(971, 115)
            Me.lblTerremotoDemolizione.Name = "lblTerremotoDemolizione"
            Me.lblTerremotoDemolizione.Size = New System.Drawing.Size(100, 25)
            Me.lblTerremotoDemolizione.TabIndex = 17
            Me.lblTerremotoDemolizione.Text = "0,00"
            Me.lblTerremotoDemolizione.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkTerremotoDemolizione
            '
            Me.chkTerremotoDemolizione.AutoSize = True
            Me.chkTerremotoDemolizione.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkTerremotoDemolizione.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkTerremotoDemolizione.Location = New System.Drawing.Point(0, 115)
            Me.chkTerremotoDemolizione.Margin = New System.Windows.Forms.Padding(0)
            Me.chkTerremotoDemolizione.Name = "chkTerremotoDemolizione"
            Me.chkTerremotoDemolizione.Size = New System.Drawing.Size(55, 25)
            Me.chkTerremotoDemolizione.TabIndex = 18
            Me.chkTerremotoDemolizione.UseVisualStyleBackColor = True
            '
            'cmbTerremotoDemolizioneMassimale
            '
            Me.cmbTerremotoDemolizioneMassimale.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cmbTerremotoDemolizioneMassimale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTerremotoDemolizioneMassimale.FormattingEnabled = True
            Me.cmbTerremotoDemolizioneMassimale.Location = New System.Drawing.Point(423, 118)
            Me.cmbTerremotoDemolizioneMassimale.Name = "cmbTerremotoDemolizioneMassimale"
            Me.cmbTerremotoDemolizioneMassimale.Size = New System.Drawing.Size(268, 21)
            Me.cmbTerremotoDemolizioneMassimale.TabIndex = 20
            '
            'desTerremotoAumentoMerci
            '
            Me.desTerremotoAumentoMerci.AutoSize = True
            Me.desTerremotoAumentoMerci.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desTerremotoAumentoMerci.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desTerremotoAumentoMerci.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desTerremotoAumentoMerci.Location = New System.Drawing.Point(58, 140)
            Me.desTerremotoAumentoMerci.Name = "desTerremotoAumentoMerci"
            Me.desTerremotoAumentoMerci.Size = New System.Drawing.Size(359, 25)
            Me.desTerremotoAumentoMerci.TabIndex = 21
            Me.desTerremotoAumentoMerci.Tag = "105"
            Me.desTerremotoAumentoMerci.Text = "Aumento periodico merci assicurate (n° mesi)"
            Me.desTerremotoAumentoMerci.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblTerremotoAumentoMerci
            '
            Me.lblTerremotoAumentoMerci.AutoSize = True
            Me.lblTerremotoAumentoMerci.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTerremotoAumentoMerci.Location = New System.Drawing.Point(971, 140)
            Me.lblTerremotoAumentoMerci.Name = "lblTerremotoAumentoMerci"
            Me.lblTerremotoAumentoMerci.Size = New System.Drawing.Size(100, 25)
            Me.lblTerremotoAumentoMerci.TabIndex = 22
            Me.lblTerremotoAumentoMerci.Text = "0,00"
            Me.lblTerremotoAumentoMerci.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkTerremotoAumentoMerci
            '
            Me.chkTerremotoAumentoMerci.AutoSize = True
            Me.chkTerremotoAumentoMerci.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkTerremotoAumentoMerci.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkTerremotoAumentoMerci.Location = New System.Drawing.Point(0, 140)
            Me.chkTerremotoAumentoMerci.Margin = New System.Windows.Forms.Padding(0)
            Me.chkTerremotoAumentoMerci.Name = "chkTerremotoAumentoMerci"
            Me.chkTerremotoAumentoMerci.Size = New System.Drawing.Size(55, 25)
            Me.chkTerremotoAumentoMerci.TabIndex = 23
            Me.chkTerremotoAumentoMerci.UseVisualStyleBackColor = True
            '
            'desTerremotoRicetteMediche
            '
            Me.desTerremotoRicetteMediche.AutoSize = True
            Me.desTerremotoRicetteMediche.Dock = System.Windows.Forms.DockStyle.Fill
            Me.desTerremotoRicetteMediche.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.desTerremotoRicetteMediche.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.desTerremotoRicetteMediche.Location = New System.Drawing.Point(58, 165)
            Me.desTerremotoRicetteMediche.Name = "desTerremotoRicetteMediche"
            Me.desTerremotoRicetteMediche.Size = New System.Drawing.Size(359, 25)
            Me.desTerremotoRicetteMediche.TabIndex = 24
            Me.desTerremotoRicetteMediche.Tag = "106"
            Me.desTerremotoRicetteMediche.Text = "Ricette mediche"
            Me.desTerremotoRicetteMediche.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblTerremotoRicetteMediche
            '
            Me.lblTerremotoRicetteMediche.AutoSize = True
            Me.lblTerremotoRicetteMediche.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTerremotoRicetteMediche.Location = New System.Drawing.Point(971, 165)
            Me.lblTerremotoRicetteMediche.Name = "lblTerremotoRicetteMediche"
            Me.lblTerremotoRicetteMediche.Size = New System.Drawing.Size(100, 25)
            Me.lblTerremotoRicetteMediche.TabIndex = 25
            Me.lblTerremotoRicetteMediche.Text = "0,00"
            Me.lblTerremotoRicetteMediche.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkTerremotoRicetteMediche
            '
            Me.chkTerremotoRicetteMediche.AutoSize = True
            Me.chkTerremotoRicetteMediche.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkTerremotoRicetteMediche.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chkTerremotoRicetteMediche.Location = New System.Drawing.Point(0, 165)
            Me.chkTerremotoRicetteMediche.Margin = New System.Windows.Forms.Padding(0)
            Me.chkTerremotoRicetteMediche.Name = "chkTerremotoRicetteMediche"
            Me.chkTerremotoRicetteMediche.Size = New System.Drawing.Size(55, 25)
            Me.chkTerremotoRicetteMediche.TabIndex = 26
            Me.chkTerremotoRicetteMediche.UseVisualStyleBackColor = True
            '
            'txtPartitaTerremotoRicetteMediche
            '
            Me.txtPartitaTerremotoRicetteMediche.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaTerremotoRicetteMediche.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaTerremotoRicetteMediche.Location = New System.Drawing.Point(423, 168)
            Me.txtPartitaTerremotoRicetteMediche.Name = "txtPartitaTerremotoRicetteMediche"
            Me.txtPartitaTerremotoRicetteMediche.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaTerremotoRicetteMediche.TabIndex = 27
            Me.txtPartitaTerremotoRicetteMediche.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
            Me.lblA8.Size = New System.Drawing.Size(359, 40)
            Me.lblA8.TabIndex = 28
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
            Me.lblB8.Location = New System.Drawing.Point(423, 0)
            Me.lblB8.Name = "lblB8"
            Me.lblB8.Size = New System.Drawing.Size(542, 40)
            Me.lblB8.TabIndex = 29
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
            Me.lblC8.Location = New System.Drawing.Point(971, 0)
            Me.lblC8.Name = "lblC8"
            Me.lblC8.Size = New System.Drawing.Size(100, 40)
            Me.lblC8.TabIndex = 30
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
            Me.lblD8.TabIndex = 31
            Me.lblD8.Text = "Scelto"
            Me.lblD8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
            Me.chkTerremotoBase.Size = New System.Drawing.Size(412, 25)
            Me.chkTerremotoBase.TabIndex = 5
            Me.chkTerremotoBase.Text = "TERREMOTO"
            Me.chkTerremotoBase.UseVisualStyleBackColor = True
            '
            'txtTerremotoAumentoMerciMesi
            '
            Me.txtTerremotoAumentoMerciMesi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTerremotoAumentoMerciMesi.Location = New System.Drawing.Point(697, 143)
            Me.txtTerremotoAumentoMerciMesi.Name = "txtTerremotoAumentoMerciMesi"
            Me.txtTerremotoAumentoMerciMesi.Size = New System.Drawing.Size(66, 22)
            Me.txtTerremotoAumentoMerciMesi.TabIndex = 0
            Me.txtTerremotoAumentoMerciMesi.TabStop = False
            Me.txtTerremotoAumentoMerciMesi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtPartitaTerremotoAumentoMerci
            '
            Me.txtPartitaTerremotoAumentoMerci.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPartitaTerremotoAumentoMerci.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartitaTerremotoAumentoMerci.Location = New System.Drawing.Point(423, 143)
            Me.txtPartitaTerremotoAumentoMerci.Name = "txtPartitaTerremotoAumentoMerci"
            Me.txtPartitaTerremotoAumentoMerci.Size = New System.Drawing.Size(268, 22)
            Me.txtPartitaTerremotoAumentoMerci.TabIndex = 0
            Me.txtPartitaTerremotoAumentoMerci.TabStop = False
            Me.txtPartitaTerremotoAumentoMerci.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'cmbTerremotoFabbricatoLimite
            '
            Me.cmbTerremotoFabbricatoLimite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTerremotoFabbricatoLimite.FormattingEnabled = True
            Me.cmbTerremotoFabbricatoLimite.Location = New System.Drawing.Point(697, 68)
            Me.cmbTerremotoFabbricatoLimite.Name = "cmbTerremotoFabbricatoLimite"
            Me.cmbTerremotoFabbricatoLimite.Size = New System.Drawing.Size(251, 21)
            Me.cmbTerremotoFabbricatoLimite.TabIndex = 6
            '
            'cmbTipologiaFabbricato
            '
            Me.cmbTipologiaFabbricato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTipologiaFabbricato.FormattingEnabled = True
            Me.cmbTipologiaFabbricato.Location = New System.Drawing.Point(423, 43)
            Me.cmbTipologiaFabbricato.Name = "cmbTipologiaFabbricato"
            Me.cmbTipologiaFabbricato.Size = New System.Drawing.Size(251, 21)
            Me.cmbTipologiaFabbricato.TabIndex = 6
            '
            'FabbricatoFE
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControl1)
            Me.Name = "FabbricatoFE"
            Me.Size = New System.Drawing.Size(1088, 646)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.TableLayoutPanel0.ResumeLayout(False)
            Me.TableLayoutPanel0.PerformLayout()
            Me.TabPage2.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel2.PerformLayout()
            Me.TabPage3.ResumeLayout(False)
            Me.GroupBox3.ResumeLayout(False)
            Me.TableLayoutPanel3.ResumeLayout(False)
            Me.TableLayoutPanel3.PerformLayout()
            Me.TabPage4.ResumeLayout(False)
            Me.GroupBox4.ResumeLayout(False)
            Me.TableLayoutPanel4.ResumeLayout(False)
            Me.TableLayoutPanel4.PerformLayout()
            Me.TabPage5.ResumeLayout(False)
            Me.GroupBox5.ResumeLayout(False)
            Me.TableLayoutPanel5.ResumeLayout(False)
            Me.TableLayoutPanel5.PerformLayout()
            Me.TabPage8.ResumeLayout(False)
            Me.GroupBox8.ResumeLayout(False)
            Me.TableLayoutPanel8.ResumeLayout(False)
            Me.TableLayoutPanel8.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents txtDescrizione As System.Windows.Forms.TextBox
        Friend WithEvents cmdRemove As System.Windows.Forms.Button
        Friend WithEvents Note As UniQuota.NoteBox
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents TableLayoutPanel0 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents lblFabbricatoDestinazione As System.Windows.Forms.Label
        Friend WithEvents cmbFabbricatoDestinazione As System.Windows.Forms.ComboBox
        Friend WithEvents lblProvincia As System.Windows.Forms.Label
        Friend WithEvents cmbProvincia As System.Windows.Forms.ComboBox
        Friend WithEvents lblA1 As System.Windows.Forms.Label
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents txtIncendioAumentoMerciMesi As System.Windows.Forms.TextBox
        Friend WithEvents lblIncendioPremio As System.Windows.Forms.Label
        Friend WithEvents chkIncendioBase As System.Windows.Forms.CheckBox
        Friend WithEvents cmbIncendioScelta As System.Windows.Forms.ComboBox
        Friend WithEvents desIncendioFabbricato As System.Windows.Forms.Label
        Friend WithEvents lblIncendioFabbricato As System.Windows.Forms.Label
        Friend WithEvents chkIncendioFabbricato As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioFabbricato As System.Windows.Forms.TextBox
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
        Friend WithEvents cmbIncendioConduttureMassimale As System.Windows.Forms.ComboBox
        Friend WithEvents desIncendioDemolizione As System.Windows.Forms.Label
        Friend WithEvents lblIncendioDemolizione As System.Windows.Forms.Label
        Friend WithEvents chkIncendioDemolizione As System.Windows.Forms.CheckBox
        Friend WithEvents cmbIncendioDemolizioneMassimale As System.Windows.Forms.ComboBox
        Friend WithEvents desIncendioEventiAtmosferici As System.Windows.Forms.Label
        Friend WithEvents lblIncendioEventiAtmosferici As System.Windows.Forms.Label
        Friend WithEvents chkIncendioEventiAtmosferici As System.Windows.Forms.CheckBox
        Friend WithEvents cmbIncendioEventiAtmosfericiScelta As System.Windows.Forms.ComboBox
        Friend WithEvents desIncendioDanniElettrici As System.Windows.Forms.Label
        Friend WithEvents lblIncendioDanniElettrici As System.Windows.Forms.Label
        Friend WithEvents chkIncendioDanniElettrici As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioDanniElettrici As System.Windows.Forms.TextBox
        Friend WithEvents cmbIncendioDanniElettriciScelta As System.Windows.Forms.ComboBox
        Friend WithEvents desIncendioDanniIndirettiA As System.Windows.Forms.Label
        Friend WithEvents lblIncendioDanniIndirettiA As System.Windows.Forms.Label
        Friend WithEvents chkIncendioDanniIndirettiA As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioDanniIndirettiA As System.Windows.Forms.TextBox
        Friend WithEvents cmbIncendioDanniIndirettiScelta As System.Windows.Forms.ComboBox
        Friend WithEvents desIncendioRicorsoTerzi As System.Windows.Forms.Label
        Friend WithEvents lblIncendioRicorsoTerzi As System.Windows.Forms.Label
        Friend WithEvents chkIncendioRicorsoTerzi As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioRicorsoTerzi As System.Windows.Forms.TextBox
        Friend WithEvents desIncendioAumentoMerci As System.Windows.Forms.Label
        Friend WithEvents lblIncendioAumentoMerci As System.Windows.Forms.Label
        Friend WithEvents chkIncendioAumentoMerci As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioAumentoMerci As System.Windows.Forms.TextBox
        Friend WithEvents desIncendioCoseTrasportate As System.Windows.Forms.Label
        Friend WithEvents lblIncendioCoseTrasportate As System.Windows.Forms.Label
        Friend WithEvents chkIncendioCoseTrasportate As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioCoseTrasportate As System.Windows.Forms.TextBox
        Friend WithEvents desIncendioRefrigerati1 As System.Windows.Forms.Label
        Friend WithEvents lblIncendioRefrigerati1 As System.Windows.Forms.Label
        Friend WithEvents chkIncendioRefrigerati1 As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioRefrigerati1 As System.Windows.Forms.TextBox
        Friend WithEvents desIncendioRefrigerati2 As System.Windows.Forms.Label
        Friend WithEvents lblIncendioRefrigerati2 As System.Windows.Forms.Label
        Friend WithEvents chkIncendioRefrigerati2 As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioRefrigerati2 As System.Windows.Forms.TextBox
        Friend WithEvents lblA2 As System.Windows.Forms.Label
        Friend WithEvents lblB2 As System.Windows.Forms.Label
        Friend WithEvents lblC2 As System.Windows.Forms.Label
        Friend WithEvents lblD2 As System.Windows.Forms.Label
        Friend WithEvents cmbIncendioFormaFabbricato As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioFormaContenuto As System.Windows.Forms.ComboBox
        Friend WithEvents cmbIncendioFormaLocazione As System.Windows.Forms.ComboBox
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents desIncendioLastre As System.Windows.Forms.Label
        Friend WithEvents lblIncendioLastre As System.Windows.Forms.Label
        Friend WithEvents chkIncendioLastre As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioLastre As System.Windows.Forms.TextBox
        Friend WithEvents desIncendioPannelliSolari As System.Windows.Forms.Label
        Friend WithEvents lblIncendioPannelliSolari As System.Windows.Forms.Label
        Friend WithEvents chkIncendioPannelliSolari As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioPannelliSolari As System.Windows.Forms.TextBox
        Friend WithEvents desIncendioRicetteMediche As System.Windows.Forms.Label
        Friend WithEvents lblIncendioRicetteMediche As System.Windows.Forms.Label
        Friend WithEvents chkIncendioRicetteMediche As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaIncendioRicetteMediche As System.Windows.Forms.TextBox
        Friend WithEvents desIncendioSpeseAccessorie As System.Windows.Forms.Label
        Friend WithEvents lblIncendioSpeseAccessorie As System.Windows.Forms.Label
        Friend WithEvents chkIncendioSpeseAccessorie As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioGrandineFragili As System.Windows.Forms.Label
        Friend WithEvents lblIncendioGrandineFragili As System.Windows.Forms.Label
        Friend WithEvents chkIncendioGrandineFragili As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioAttiVandaliciDolosi As System.Windows.Forms.Label
        Friend WithEvents lblIncendioAttiVandaliciDolosi As System.Windows.Forms.Label
        Friend WithEvents chkIncendioAttiVandaliciDolosi As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioFabbricatiAperti1 As System.Windows.Forms.Label
        Friend WithEvents lblIncendioFabbricatiAperti1 As System.Windows.Forms.Label
        Friend WithEvents chkIncendioFabbricatiAperti1 As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioFabbricatiAperti2 As System.Windows.Forms.Label
        Friend WithEvents lblIncendioFabbricatiAperti2 As System.Windows.Forms.Label
        Friend WithEvents chkIncendioFabbricatiAperti2 As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioPreziosi As System.Windows.Forms.Label
        Friend WithEvents lblIncendioPreziosi As System.Windows.Forms.Label
        Friend WithEvents chkIncendioPreziosi As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioSistemiProtezione As System.Windows.Forms.Label
        Friend WithEvents lblIncendioSistemiProtezione As System.Windows.Forms.Label
        Friend WithEvents chkIncendioSistemiProtezione As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioCommercioAmbulante As System.Windows.Forms.Label
        Friend WithEvents lblIncendioCommercioAmbulante As System.Windows.Forms.Label
        Friend WithEvents chkIncendioCommercioAmbulante As System.Windows.Forms.CheckBox
        Friend WithEvents desIncendioFranchigia As System.Windows.Forms.Label
        Friend WithEvents lblIncendioFranchigia As System.Windows.Forms.Label
        Friend WithEvents chkIncendioFranchigia As System.Windows.Forms.CheckBox
        Friend WithEvents cmbIncendioFranchigiaFranchigia As System.Windows.Forms.ComboBox
        Friend WithEvents lblA3 As System.Windows.Forms.Label
        Friend WithEvents lblB3 As System.Windows.Forms.Label
        Friend WithEvents lblC3 As System.Windows.Forms.Label
        Friend WithEvents lblD3 As System.Windows.Forms.Label
        Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
        Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
        Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents txtFurtoAumentoMerciMesi As System.Windows.Forms.TextBox
        Friend WithEvents lblFurtoPremio As System.Windows.Forms.Label
        Friend WithEvents chkFurtoBase As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoContenuto As System.Windows.Forms.Label
        Friend WithEvents lblFurtoContenuto As System.Windows.Forms.Label
        Friend WithEvents chkFurtoContenuto As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoContenuto As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoFissi As System.Windows.Forms.Label
        Friend WithEvents lblFurtoFissi As System.Windows.Forms.Label
        Friend WithEvents chkFurtoFissi As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoFissi As System.Windows.Forms.TextBox
        Friend WithEvents cmbFurtoFissiScelta As System.Windows.Forms.ComboBox
        Friend WithEvents desFurtoValori As System.Windows.Forms.Label
        Friend WithEvents lblFurtoValori As System.Windows.Forms.Label
        Friend WithEvents chkFurtoValori As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoValori As System.Windows.Forms.TextBox
        Friend WithEvents cmbFurtoValoriScelta As System.Windows.Forms.ComboBox
        Friend WithEvents desFurtoVetrinette As System.Windows.Forms.Label
        Friend WithEvents lblFurtoVetrinette As System.Windows.Forms.Label
        Friend WithEvents chkFurtoVetrinette As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoVetrinette As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoPortavalori As System.Windows.Forms.Label
        Friend WithEvents lblFurtoPortavalori As System.Windows.Forms.Label
        Friend WithEvents chkFurtoPortavalori As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoPortavalori As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoAumentoMerci As System.Windows.Forms.Label
        Friend WithEvents lblFurtoAumentoMerci As System.Windows.Forms.Label
        Friend WithEvents chkFurtoAumentoMerci As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoAumentoMerci As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoMerciTrasportate As System.Windows.Forms.Label
        Friend WithEvents lblFurtoMerciTrasportate As System.Windows.Forms.Label
        Friend WithEvents chkFurtoMerciTrasportate As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoMerciTrasportate As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoMerciAperto As System.Windows.Forms.Label
        Friend WithEvents lblFurtoMerciAperto As System.Windows.Forms.Label
        Friend WithEvents chkFurtoMerciAperto As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoMerciAperto As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoDistributoriEsterni As System.Windows.Forms.Label
        Friend WithEvents lblFurtoDistributoriEsterni As System.Windows.Forms.Label
        Friend WithEvents chkFurtoDistributoriEsterni As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoDistributoriEsterni As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoDistributoriCarburante As System.Windows.Forms.Label
        Friend WithEvents lblFurtoDistributoriCarburante As System.Windows.Forms.Label
        Friend WithEvents chkFurtoDistributoriCarburante As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoDistributoriCarburante As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoRicetteMediche As System.Windows.Forms.Label
        Friend WithEvents lblFurtoRicetteMediche As System.Windows.Forms.Label
        Friend WithEvents chkFurtoRicetteMediche As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoRicetteMediche As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoDipendenti As System.Windows.Forms.Label
        Friend WithEvents lblFurtoDipendenti As System.Windows.Forms.Label
        Friend WithEvents chkFurtoDipendenti As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoDipendenti As System.Windows.Forms.TextBox
        Friend WithEvents lblA4 As System.Windows.Forms.Label
        Friend WithEvents lblB4 As System.Windows.Forms.Label
        Friend WithEvents lblC4 As System.Windows.Forms.Label
        Friend WithEvents lblD4 As System.Windows.Forms.Label
        Friend WithEvents desFurtoRapina As System.Windows.Forms.Label
        Friend WithEvents txtPartitaFurtoRapina As System.Windows.Forms.TextBox
        Friend WithEvents cmbFurtoRapinaScelta As System.Windows.Forms.ComboBox
        Friend WithEvents lblFurtoRapina As System.Windows.Forms.Label
        Friend WithEvents chkFurtoRapina As System.Windows.Forms.CheckBox
        Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
        Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
        Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents desFurtoSpeseAccessorie As System.Windows.Forms.Label
        Friend WithEvents lblFurtoSpeseAccessorie As System.Windows.Forms.Label
        Friend WithEvents chkFurtoSpeseAccessorie As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoSpeseMiglioramento As System.Windows.Forms.Label
        Friend WithEvents lblFurtoSpeseMiglioramento As System.Windows.Forms.Label
        Friend WithEvents chkFurtoSpeseMiglioramento As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoSlotMachine As System.Windows.Forms.Label
        Friend WithEvents lblFurtoSlotMachine As System.Windows.Forms.Label
        Friend WithEvents chkFurtoSlotMachine As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoSlotMachine As System.Windows.Forms.TextBox
        Friend WithEvents desFurtoReintegroAutomatico As System.Windows.Forms.Label
        Friend WithEvents lblFurtoReintegroAutomatico As System.Windows.Forms.Label
        Friend WithEvents chkFurtoReintegroAutomatico As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoCommercioAmbulante As System.Windows.Forms.Label
        Friend WithEvents lblFurtoCommercioAmbulante As System.Windows.Forms.Label
        Friend WithEvents chkFurtoCommercioAmbulante As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoDepositoRiserva As System.Windows.Forms.Label
        Friend WithEvents lblFurtoDepositoRiserva As System.Windows.Forms.Label
        Friend WithEvents chkFurtoDepositoRiserva As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoDerogaCostruttive As System.Windows.Forms.Label
        Friend WithEvents lblFurtoDerogaCostruttive As System.Windows.Forms.Label
        Friend WithEvents chkFurtoDerogaCostruttive As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoMezziChiusura As System.Windows.Forms.Label
        Friend WithEvents lblFurtoMezziChiusura As System.Windows.Forms.Label
        Friend WithEvents chkFurtoMezziChiusura As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoImpiantoAllarme As System.Windows.Forms.Label
        Friend WithEvents lblFurtoImpiantoAllarme As System.Windows.Forms.Label
        Friend WithEvents chkFurtoImpiantoAllarme As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoAllarmeDistanza As System.Windows.Forms.Label
        Friend WithEvents lblFurtoAllarmeDistanza As System.Windows.Forms.Label
        Friend WithEvents chkFurtoAllarmeDistanza As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoAllarmeDoppio As System.Windows.Forms.Label
        Friend WithEvents lblFurtoAllarmeDoppio As System.Windows.Forms.Label
        Friend WithEvents chkFurtoAllarmeDoppio As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoVideoSorveglianza As System.Windows.Forms.Label
        Friend WithEvents lblFurtoVideoSorveglianza As System.Windows.Forms.Label
        Friend WithEvents chkFurtoVideoSorveglianza As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoScopertoMerciA As System.Windows.Forms.Label
        Friend WithEvents lblFurtoScopertoMerciA As System.Windows.Forms.Label
        Friend WithEvents chkFurtoScopertoMerciA As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoScopertoMerciB As System.Windows.Forms.Label
        Friend WithEvents lblFurtoScopertoMerciB As System.Windows.Forms.Label
        Friend WithEvents chkFurtoScopertoMerciB As System.Windows.Forms.CheckBox
        Friend WithEvents desFurtoPiuEsercizi As System.Windows.Forms.Label
        Friend WithEvents lblFurtoPiuEsercizi As System.Windows.Forms.Label
        Friend WithEvents chkFurtoPiuEsercizi As System.Windows.Forms.CheckBox
        Friend WithEvents lblA5 As System.Windows.Forms.Label
        Friend WithEvents lblB5 As System.Windows.Forms.Label
        Friend WithEvents lblC5 As System.Windows.Forms.Label
        Friend WithEvents lblD5 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents chkExt1 As System.Windows.Forms.CheckBox
        Friend WithEvents chkExt3 As System.Windows.Forms.CheckBox
        Friend WithEvents chkExt2 As System.Windows.Forms.CheckBox
        Friend WithEvents chkExt4 As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaFurtoPiuEsercizi As System.Windows.Forms.TextBox
        Friend WithEvents desIncendioDanniIndirettiB As System.Windows.Forms.Label
        Friend WithEvents txtPartitaIncendioDanniIndirettiB As System.Windows.Forms.TextBox
        Friend WithEvents lblIncendioDanniIndirettiB As System.Windows.Forms.Label
        Friend WithEvents chkIncendioDanniIndirettiB As System.Windows.Forms.CheckBox

        Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
        Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
        Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents txtTerremotoAumentoMerciMesi As System.Windows.Forms.TextBox
        Friend WithEvents lblA8 As System.Windows.Forms.Label
        Friend WithEvents lblB8 As System.Windows.Forms.Label
        Friend WithEvents lblC8 As System.Windows.Forms.Label
        Friend WithEvents lblD8 As System.Windows.Forms.Label
        Friend WithEvents lblTerremotoPremio As System.Windows.Forms.Label
        Friend WithEvents chkTerremotoBase As System.Windows.Forms.CheckBox
        Friend WithEvents desTerremotoFabbricato As System.Windows.Forms.Label
        Friend WithEvents lblTerremotoFabbricato As System.Windows.Forms.Label
        Friend WithEvents chkTerremotoFabbricato As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaTerremotoFabbricato As System.Windows.Forms.TextBox
        Friend WithEvents desTerremotoContenuto As System.Windows.Forms.Label
        Friend WithEvents lblTerremotoContenuto As System.Windows.Forms.Label
        Friend WithEvents chkTerremotoContenuto As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaTerremotoContenuto As System.Windows.Forms.TextBox
        Friend WithEvents desTerremotoDemolizione As System.Windows.Forms.Label
        Friend WithEvents lblTerremotoDemolizione As System.Windows.Forms.Label
        Friend WithEvents chkTerremotoDemolizione As System.Windows.Forms.CheckBox
        Friend WithEvents desTerremotoAumentoMerci As System.Windows.Forms.Label
        Friend WithEvents lblTerremotoAumentoMerci As System.Windows.Forms.Label
        Friend WithEvents chkTerremotoAumentoMerci As System.Windows.Forms.CheckBox
        Friend WithEvents desTerremotoRicetteMediche As System.Windows.Forms.Label
        Friend WithEvents lblTerremotoRicetteMediche As System.Windows.Forms.Label
        Friend WithEvents chkTerremotoRicetteMediche As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaTerremotoRicetteMediche As System.Windows.Forms.TextBox
        Friend WithEvents cmbTerremotoFabbricatoLimite As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCaratteristicaCostruttiva As System.Windows.Forms.ComboBox
        Friend WithEvents cmbTerremotoDemolizioneMassimale As System.Windows.Forms.ComboBox
        Friend WithEvents chkcomuneMinorRischioSismico As System.Windows.Forms.CheckBox
        Friend WithEvents txtPartitaTerremotoAumentoMerci As System.Windows.Forms.TextBox
        Friend WithEvents cmbTipologiaFabbricato As System.Windows.Forms.ComboBox
        Friend WithEvents cmbFabbricatoClasse As System.Windows.Forms.ComboBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cmbComune As System.Windows.Forms.ComboBox
    End Class
End Namespace
