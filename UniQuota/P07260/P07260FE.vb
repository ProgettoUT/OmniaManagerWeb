Namespace P07260
    Public Class P07260FE
        Protected Overrides Sub AttachEvents()
            AddHandler txtNumeroFabbricati.Leave, AddressOf ValuesChanged
            AddHandler txtNumeroFabbricati.KeyPress, AddressOf TextBoxKeyPress
            AddHandler txtlNumeroUnitaImmobiliari.Leave, AddressOf ValuesChanged
            AddHandler txtlNumeroUnitaImmobiliari.KeyPress, AddressOf TextBoxKeyPress
            AddHandler txtNumeroUnitaAbitative.Leave, AddressOf ValuesChanged
            AddHandler txtNumeroUnitaAbitative.KeyPress, AddressOf TextBoxKeyPress
            AddHandler txtAnnoCostruzione.Leave, AddressOf ValuesChanged
            AddHandler txtAnnoCostruzione.KeyPress, AddressOf TextBoxKeyPress
            'AddHandler cmbProvinciaFabbricato.SelectedIndexChanged, AddressOf cmbProvincia_SelectedIndexChanged
            AddHandler cmbComune.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler cmbTipologiaFabbricato.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkCiSonoEserciziComerciali.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRifacimentoIdrotermosanitari.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkAdeguamentoFacoltativo.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkIncendio1.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioAttiTerrorismo.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioAttiVandalici.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioCristalli.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioOnorariPeriti.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioDanniImpianti.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioBasic.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioMedium.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioEnergy.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioExtra.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioIncendioDemolizioneSgombero.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRC.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCCL.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCCui.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCEnergy.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCPL.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCAmministratore.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDABase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDAEnergy.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDAFuo.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDASrr.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkTlBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkTlDa.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkTl19603.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkTl8108.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkTerremotoBase.CheckedChanged, AddressOf ValuesChanged

            AddHandler txtPartitaIncendio.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendio.KeyPress, AddressOf TextBoxKeyPress
            AddHandler cmbIncendioFABLimite.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioFABFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioFAMMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioFAMFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioAttiVandaliciDolosiFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioAttiTerrorismoLimite.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioAttiTerrorismoFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioDanniImpiantiElettriciMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioDanniImpiantiElettriciFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioCristalliMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioEnergyMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioExtraMassimale1.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioExtraFranchigia1.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioExtraMassimale2.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioExtraFranchigia2.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioDemolizioneSgomberoMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioOnorariPeritiMassimale.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler cmbResponsabilitaCivileBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbResponsabilitaPrestatoriLavoroMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbResponsabilitaCommittenzaLavoriMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbResponsabilitaConduzioneUnitaImmobiliariMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbResponsabilitaAmministratoreMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbResponsabilitaEnergyMassimale.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler cmbDanniAcquaBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbDanniAcquaBaseFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbDanniAcquaFuoriUscitaOcclusioneFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbDanniAcquaSpeseRicercaRiparazioneMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbDanniAcquaSpeseRicercaRiparazioneFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbDanniAcquaEnergyFranchigia.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler cmbInfortuniBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbTutelaLegaleBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler cmbCaratteristicaCostruttiva.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbTerremotoFabbricatoLimite.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler cmbDanniAcquaFormaVendita.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkIncendioEstensioneGaranziaBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniAcquaPerditeOcculte.CheckedChanged, AddressOf ValuesChanged

            AddHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            AddHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
        End Sub

        Protected Overrides Sub DetachEvents()
            RemoveHandler txtNumeroFabbricati.Leave, AddressOf ValuesChanged
            RemoveHandler txtNumeroFabbricati.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler txtlNumeroUnitaImmobiliari.Leave, AddressOf ValuesChanged
            RemoveHandler txtlNumeroUnitaImmobiliari.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler txtNumeroUnitaAbitative.Leave, AddressOf ValuesChanged
            RemoveHandler txtNumeroUnitaAbitative.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler txtAnnoCostruzione.Leave, AddressOf ValuesChanged
            RemoveHandler txtAnnoCostruzione.KeyPress, AddressOf TextBoxKeyPress
            'RemoveHandler cmbProvinciaFabbricato.SelectedIndexChanged, AddressOf cmbProvincia_SelectedIndexChanged
            RemoveHandler cmbComune.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbTipologiaFabbricato.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkCiSonoEserciziComerciali.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRifacimentoIdrotermosanitari.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkAdeguamentoFacoltativo.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkIncendio1.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkIncendioBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkIncendioAttiTerrorismo.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkIncendioAttiVandalici.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkIncendioCristalli.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkIncendioOnorariPeriti.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkIncendioDanniImpianti.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkIncendioBasic.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkIncendioMedium.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkIncendioEnergy.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkIncendioExtra.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkIncendioIncendioDemolizioneSgombero.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRC.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCCL.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCCui.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCEnergy.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCPL.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCAmministratore.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkDABase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkDAEnergy.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkDAFuo.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkDASrr.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkInfortuniBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkTlBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkTlDa.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkTl19603.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkTl8108.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkTerremotoBase.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler txtPartitaIncendio.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaIncendio.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler cmbIncendioFABLimite.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioFABFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioFAMMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioFAMFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioAttiVandaliciDolosiFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioAttiTerrorismoLimite.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioAttiTerrorismoFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioDanniImpiantiElettriciMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioDanniImpiantiElettriciFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioCristalliMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioEnergyMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioExtraMassimale1.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioExtraFranchigia1.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioExtraMassimale2.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioExtraFranchigia2.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioDemolizioneSgomberoMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioOnorariPeritiMassimale.SelectedIndexChanged, AddressOf ValuesChanged

            RemoveHandler cmbResponsabilitaCivileBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbResponsabilitaPrestatoriLavoroMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbResponsabilitaCommittenzaLavoriMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbResponsabilitaConduzioneUnitaImmobiliariMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbResponsabilitaAmministratoreMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbResponsabilitaEnergyMassimale.SelectedIndexChanged, AddressOf ValuesChanged

            RemoveHandler cmbDanniAcquaBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbDanniAcquaBaseFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbDanniAcquaFuoriUscitaOcclusioneFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbDanniAcquaSpeseRicercaRiparazioneMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbDanniAcquaSpeseRicercaRiparazioneFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbDanniAcquaEnergyFranchigia.SelectedIndexChanged, AddressOf ValuesChanged

            RemoveHandler cmbInfortuniBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbTutelaLegaleBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged

            RemoveHandler cmbCaratteristicaCostruttiva.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbTerremotoFabbricatoLimite.SelectedIndexChanged, AddressOf ValuesChanged

            RemoveHandler cmbDanniAcquaFormaVendita.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkIncendioEstensioneGaranziaBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkDanniAcquaPerditeOcculte.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            RemoveHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
        End Sub

        Public Sub New()
            InitializeComponent2()
            Me.TabControl1.Controls.Add(Me.docTab)
            Me.QuotatorePremio.Image = Global.UniQuota.My.Resources.Resources.P07260
            Me.docBrowser.Tag = "http://www.utools.it/Unitools/Doc/Prodotti/P07260/IndexDoc.htm"
            Me.docBrowser.Url = New System.Uri(Me.docBrowser.Tag, System.UriKind.Absolute)

            'preventivo = New SicuirezzaStabile
            'modello = New P07260ST()

            Dim decode As New P07260DE
            'preventivo.Decode = decode
            Me.decode = decode

            helpChm.CodiceProdotto = "P07260"
            If helpChm.FileExists Then
                AgganciaHelp(Me, AddressOf MouseClickedHelp)
            End If


            With QuotatorePremio.cmbFrazionamento
                .DataSource = New BindingSource(decode.DecodeFrazionamenti, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            With cmbTipologiaFabbricato
                .DataSource = New BindingSource(decode.DecodeTipologiaFabbricato, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            AttachCombo(cmbProvinciaFabbricato, Luogo.Province)

            With cmbIncendioFABLimite
                .DataSource = New BindingSource(decode.DecodeIncendioFABLimite, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            With cmbIncendioFABFranchigia
                .DataSource = New BindingSource(decode.DecodeIncendioFABFranchigia, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            With cmbIncendioFAMMassimale
                .DataSource = New BindingSource(decode.DecodeIncendioFAMMassimale, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            With cmbIncendioFAMFranchigia
                .DataSource = New BindingSource(decode.DecodeIncendioFAMFranchigia, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            With cmbIncendioAttiVandaliciDolosiFranchigia
                .DataSource = New BindingSource(decode.DecodeIncendioAttiVandaliciDolosiFranchigia, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            With cmbIncendioAttiTerrorismoLimite
                .DataSource = New BindingSource(decode.DecodeIncendioAttiTerrorismoLimite, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            With cmbIncendioAttiTerrorismoFranchigia
                .DataSource = New BindingSource(decode.DecodeIncendioAttiTerrorismoFranchigia, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            With cmbIncendioDanniImpiantiElettriciMassimale
                .DataSource = New BindingSource(decode.DecodeIncendioDanniImpiantiElettriciMassimale, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            With cmbIncendioDanniImpiantiElettriciFranchigia
                .DataSource = New BindingSource(decode.DecodeIncendioDanniImpiantiElettriciFranchigia, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            With cmbIncendioCristalliMassimale
                .DataSource = New BindingSource(decode.DecodeIncendioCristalliMassimale, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            With cmbIncendioEnergyMassimale
                .DataSource = New BindingSource(decode.DecodeIncendioEnergyMassimale, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            With cmbIncendioExtraMassimale1
                .DataSource = New BindingSource(decode.DecodeIncendioExtraMassimale1, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With
            With cmbIncendioExtraFranchigia1
                .DataSource = New BindingSource(decode.DecodeIncendioExtraFranchigia1, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            With cmbIncendioExtraMassimale2
                .DataSource = New BindingSource(decode.DecodeIncendioExtraMassimale2, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With
            With cmbIncendioExtraFranchigia2
                .DataSource = New BindingSource(decode.DecodeIncendioExtraFranchigia2, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            With cmbIncendioDemolizioneSgomberoMassimale
                .DataSource = New BindingSource(decode.DecodeIncendioDemolizioneSgomberoMassimale, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With
            With cmbIncendioOnorariPeritiMassimale
                .DataSource = New BindingSource(decode.DecodeIncendioOnorariPeritiMassimale, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            AttachCombo(cmbResponsabilitaAmministratoreMassimale, decode.DecodeResponsabilitaAmministratoreMassimale)
            AttachCombo(cmbResponsabilitaCivileBaseMassimale, decode.DecodeResponsabilitaCivileBaseMassimale)
            AttachCombo(cmbResponsabilitaCommittenzaLavoriMassimale, decode.DecodeResponsabilitaCommittenzaLavoriMassimale)
            AttachCombo(cmbResponsabilitaConduzioneUnitaImmobiliariMassimale, decode.DecodeResponsabilitaConduzioneUnitaImmobiliariMassimale)
            AttachCombo(cmbResponsabilitaEnergyMassimale, decode.DecodeResponsabilitaEnergyMassimale)
            AttachCombo(cmbResponsabilitaPrestatoriLavoroMassimale, decode.DecodeResponsabilitaPrestatoriLavoroMassimale)

            AttachCombo(cmbDanniAcquaBaseMassimale, decode.DecodeDanniAcquaBaseMassimale)
            AttachCombo(cmbDanniAcquaBaseFranchigia, decode.DecodeDanniAcquaBaseFranchigia)
            AttachCombo(cmbDanniAcquaFuoriUscitaOcclusioneFranchigia, decode.DecodeDanniAcquaFuoriUscitaOcclusioneFranchigia)
            AttachCombo(cmbDanniAcquaSpeseRicercaRiparazioneMassimale, decode.DecodeDanniAcquaSpeseRicercaRiparazioneMassimale)
            AttachCombo(cmbDanniAcquaSpeseRicercaRiparazioneFranchigia, decode.DecodeDanniAcquaSpeseRicercaRiparazioneFranchigia)
            AttachCombo(cmbDanniAcquaEnergyFranchigia, decode.DecodeDanniAcquaEnergyFranchigia)

            AttachCombo(cmbInfortuniBaseMassimale, decode.DecodeInfortuniBaseMassimale)
            AttachCombo(cmbTutelaLegaleBaseMassimale, decode.DecodeTutelaLegaleBaseMassimale)

            AttachCombo(cmbCaratteristicaCostruttiva, decode.DecodeCaratteristicaCostruttiva)
            AttachCombo(cmbTerremotoFabbricatoLimite, decode.DecodeTerremotoFabbricatoLimite)

            AttachCombo(cmbDanniAcquaFormaVendita, decode.DecodeDanniAcquaFormaVendita)
            'preventivo.Inizializza()
            'preventivo.ValidaECalcola()
            'PreventivoToControls()
            Panels = {TableLayoutPanel2, TableLayoutPanel3, TableLayoutPanel4, TableLayoutPanel7}
        End Sub

        Protected Overrides Sub ControlsToPreventivo(ByVal diretto As Boolean)
            With TryCast(preventivo, YouCondominio)

                If diretto Then
                    'GLOBALI
                    .NumeroFabbricati = IntegerBox(txtNumeroFabbricati)
                    .NumeroUnitaImmobiliari = IntegerBox(txtlNumeroUnitaImmobiliari)
                    .NumeroUnitaAbitative = IntegerBox(txtNumeroUnitaAbitative)
                    .CiSonoEserciziComerciali = chkCiSonoEserciziComerciali.Checked
                    .AnnoCostruzione = IntegerBox(txtAnnoCostruzione)
                    .RifacimentoIdrotermosanitari = chkRifacimentoIdrotermosanitari.Checked
                    .TipologiaFabbricato = cmbTipologiaFabbricato.SelectedValue
                    .AdeguamentoFacoltativo = chkAdeguamentoFacoltativo.Checked
                    .Provincia = cmbProvinciaFabbricato.SelectedValue
                    .Comune = cmbComune.SelectedValue

                    'INCENDIO
                    .CoperturaIncendio.Stato = EnabledAndChecked(chkIncendio1)
                    .CoperturaIncendioBase.Stato = EnabledAndChecked(chkIncendioBase)
                    .CoperturaIncendioAttiTerrorismo.Stato = EnabledAndChecked(chkIncendioAttiTerrorismo)
                    .CoperturaIncendioAttiVandaliciDolosi.Stato = EnabledAndChecked(chkIncendioAttiVandalici)
                    .CoperturaIncendioCristalli.Stato = EnabledAndChecked(chkIncendioCristalli)
                    .CoperturaIncendioOnorariPeriti.Stato = EnabledAndChecked(chkIncendioOnorariPeriti)
                    .CoperturaIncendioDanniImpiantiElettrici.Stato = EnabledAndChecked(chkIncendioDanniImpianti)
                    .CoperturaIncendioFenomeniAtmosfericiBasic.Stato = EnabledAndChecked(chkIncendioBasic)
                    .CoperturaIncendioFenomeniAtmosfericiMediuum.Stato = EnabledAndChecked(chkIncendioMedium)
                    .CoperturaIncendioEnergy.Stato = EnabledAndChecked(chkIncendioEnergy)
                    .CoperturaIncendioExtra.Stato = EnabledAndChecked(chkIncendioExtra)
                    .CoperturaIncendioDemolizioneSgombero.Stato = EnabledAndChecked(chkIncendioIncendioDemolizioneSgombero)

                    .PartitaIncendio.SommaAssicurata = CurrencyBox(txtPartitaIncendio)
                    .CoperturaIncendioFenomeniAtmosfericiBasic.Garanzia.Limite = cmbIncendioFABLimite.SelectedValue
                    .CoperturaIncendioFenomeniAtmosfericiBasic.Garanzia.Franchigia = cmbIncendioFABFranchigia.SelectedValue
                    .CoperturaIncendioFenomeniAtmosfericiMediuum.Garanzia.Massimale = cmbIncendioFAMMassimale.SelectedValue
                    .CoperturaIncendioFenomeniAtmosfericiMediuum.Garanzia.Franchigia = cmbIncendioFAMFranchigia.SelectedValue
                    .CoperturaIncendioAttiVandaliciDolosi.Garanzia.Franchigia = cmbIncendioAttiVandaliciDolosiFranchigia.SelectedValue
                    .CoperturaIncendioAttiTerrorismo.Garanzia.Limite = cmbIncendioAttiTerrorismoLimite.SelectedValue
                    .CoperturaIncendioAttiTerrorismo.Garanzia.Franchigia = cmbIncendioAttiTerrorismoFranchigia.SelectedValue
                    .CoperturaIncendioDanniImpiantiElettrici.Garanzia.Massimale = cmbIncendioDanniImpiantiElettriciMassimale.SelectedValue
                    .CoperturaIncendioDanniImpiantiElettrici.Garanzia.Franchigia = cmbIncendioDanniImpiantiElettriciFranchigia.SelectedValue
                    .CoperturaIncendioCristalli.Garanzia.Massimale = cmbIncendioCristalliMassimale.SelectedValue
                    .CoperturaIncendioEnergy.Garanzia.Massimale = cmbIncendioEnergyMassimale.SelectedValue
                    With .CoperturaIncendioExtra.Garanzia
                        .Garanzie(0).Massimale = cmbIncendioExtraMassimale1.SelectedValue
                        .Garanzie(0).Franchigia = cmbIncendioExtraFranchigia1.SelectedValue
                        .Garanzie(1).Massimale = cmbIncendioExtraMassimale2.SelectedValue
                        .Garanzie(1).Franchigia = cmbIncendioExtraFranchigia2.SelectedValue
                    End With
                    .CoperturaIncendioDemolizioneSgombero.Garanzia.Massimale = cmbIncendioDemolizioneSgomberoMassimale.SelectedValue
                    .CoperturaIncendioOnorariPeriti.Garanzia.Massimale = cmbIncendioOnorariPeritiMassimale.SelectedValue

                    'RC
                    .CoperturaResponsabilitaCivile.Stato = EnabledAndChecked(chkRC)
                    .CoperturaResponsabilitaCivileBase.Stato = EnabledAndChecked(chkRCBase)
                    .CoperturaResponsabilitaCommittenzaLavori.Stato = EnabledAndChecked(chkRCCL)
                    .CoperturaResponsabilitaConduzioneUnitaImmobiliari.Stato = EnabledAndChecked(chkRCCui)
                    .CoperturaResponsabilitaEnergy.Stato = EnabledAndChecked(chkRCEnergy)
                    .CoperturaResponsabilitaPrestatoriLavoro.Stato = EnabledAndChecked(chkRCPL)
                    .CoperturaResponsabilitaAmministratore.Stato = EnabledAndChecked(chkRCAmministratore)

                    .CoperturaResponsabilitaCivileBase.Garanzia.Massimale = cmbResponsabilitaCivileBaseMassimale.SelectedValue
                    .CoperturaResponsabilitaPrestatoriLavoro.Garanzia.Massimale = cmbResponsabilitaPrestatoriLavoroMassimale.SelectedValue
                    .CoperturaResponsabilitaCommittenzaLavori.Garanzia.Massimale = cmbResponsabilitaCommittenzaLavoriMassimale.SelectedValue
                    .CoperturaResponsabilitaConduzioneUnitaImmobiliari.Garanzia.Massimale = cmbResponsabilitaConduzioneUnitaImmobiliariMassimale.SelectedValue
                    .CoperturaResponsabilitaAmministratore.Garanzia.Massimale = cmbResponsabilitaAmministratoreMassimale.SelectedValue
                    .CoperturaResponsabilitaEnergy.Garanzia.Massimale = cmbResponsabilitaEnergyMassimale.SelectedValue

                    'DANNI ACQUA
                    .CoperturaDanniAcquaBase.Stato = EnabledAndChecked(chkDABase)
                    .CoperturaDanniAcquaEnergy.Stato = EnabledAndChecked(chkDAEnergy)
                    .CoperturaDanniAcquaFuoriUscitaOcclusione.Stato = EnabledAndChecked(chkDAFuo)
                    .CoperturaDanniAcquaSpeseRicercaRiparazione.Stato = EnabledAndChecked(chkDASrr)
                    .CoperturaDanniAcquaBase.Garanzia.Massimale = cmbDanniAcquaBaseMassimale.SelectedValue
                    .CoperturaDanniAcquaBase.Garanzia.Franchigia = cmbDanniAcquaBaseFranchigia.SelectedValue
                    .CoperturaDanniAcquaFuoriUscitaOcclusione.Garanzia.Franchigia = cmbDanniAcquaFuoriUscitaOcclusioneFranchigia.SelectedValue
                    .CoperturaDanniAcquaSpeseRicercaRiparazione.Garanzia.MassimalePerAnno = cmbDanniAcquaSpeseRicercaRiparazioneMassimale.SelectedValue
                    .CoperturaDanniAcquaSpeseRicercaRiparazione.Garanzia.Franchigia = cmbDanniAcquaSpeseRicercaRiparazioneFranchigia.SelectedValue
                    .CoperturaDanniAcquaEnergy.Garanzia.Franchigia = cmbDanniAcquaEnergyFranchigia.SelectedValue

                    'INFORTUNI
                    .CoperturaInfortuniBase.Stato = EnabledAndChecked(chkInfortuniBase)
                    .CoperturaInfortuniBase.Garanzia.Garanzie(0).Massimale = cmbInfortuniBaseMassimale.SelectedValue

                    'TUTELA LEGALE
                    .CoperturaTutelaLegaleBase.Stato = EnabledAndChecked(chkTlBase)
                    .CoperturaTutelaLegaleDelibereAssemlea.Stato = EnabledAndChecked(chkTlDa)
                    .CoperturaTutelaLegaleDlgs19603.Stato = EnabledAndChecked(chkTl19603)
                    .CoperturaTutelaLegaleDlgs8108.Stato = EnabledAndChecked(chkTl8108)

                    .CoperturaTutelaLegaleBase.Garanzia.Massimale = cmbTutelaLegaleBaseMassimale.SelectedValue

                    'TERREMOTO
                    .CoperturaTerremotoBase.Stato = EnabledAndChecked(chkTerremotoBase)
                    .CaratteristicaCostruttiva = CInt(cmbCaratteristicaCostruttiva.SelectedValue)
                    .CoperturaTerremotoBase.Garanzia.Limite = cmbTerremotoFabbricatoLimite.SelectedValue

                    'ESTENSIONI
                    .CoperturaIncendioEstensioneGaranziaBase.Stato = EnabledAndChecked(chkIncendioEstensioneGaranziaBase)
                    .CoperturaDanniAcquaPerditeOcculte.Stato = EnabledAndChecked(chkDanniAcquaPerditeOcculte)
                    .DanniAcquaFormaVendita = CInt(cmbDanniAcquaFormaVendita.SelectedValue)
                Else
                    IntegerBox(txtNumeroFabbricati) = .NumeroFabbricati
                    txtNumeroFabbricati.Enabled = (.TipologiaFabbricato = TipologiaFabbricatoEnum.FabbricatoIntero)
                    IntegerBox(txtlNumeroUnitaImmobiliari) = .NumeroUnitaImmobiliari
                    txtlNumeroUnitaImmobiliari.Enabled = (.TipologiaFabbricato = TipologiaFabbricatoEnum.FabbricatoIntero)
                    IntegerBox(txtNumeroUnitaAbitative) = .NumeroUnitaAbitative
                    txtNumeroUnitaAbitative.Enabled = (.TipologiaFabbricato = TipologiaFabbricatoEnum.FabbricatoIntero)
                    chkCiSonoEserciziComerciali.Checked = .CiSonoEserciziComerciali
                    chkCiSonoEserciziComerciali.Enabled = (.TipologiaFabbricato = TipologiaFabbricatoEnum.FabbricatoIntero)

                    IntegerBox(txtAnnoCostruzione) = .AnnoCostruzione
                    txtAnnoCostruzione.Enabled = True
                    chkRifacimentoIdrotermosanitari.Checked = .RifacimentoIdrotermosanitari
                    chkRifacimentoIdrotermosanitari.Enabled = True
                    chkAdeguamentoFacoltativo.Checked = .AdeguamentoFacoltativo
                    chkAdeguamentoFacoltativo.Enabled = True

                    cmbTipologiaFabbricato.SelectedValue = .TipologiaFabbricato
                    cmbTipologiaFabbricato.Enabled = True
                    cmbProvinciaFabbricato.SelectedValue = .Provincia
                    cmbProvinciaFabbricato.Enabled = True
                    cmbComune.SelectedValue = .Comune
                    cmbComune.Enabled = True

                    'INCENDIO
                    EnabledAndChecked(chkIncendio1) = .CoperturaIncendio.Stato
                    EnabledAndChecked(chkIncendioBase) = .CoperturaIncendioBase.Stato
                    EnabledAndChecked(chkIncendioIncendioDemolizioneSgombero) = .CoperturaIncendioDemolizioneSgombero.Stato
                    EnabledAndChecked(chkIncendioAttiTerrorismo) = .CoperturaIncendioAttiTerrorismo.Stato
                    EnabledAndChecked(chkIncendioAttiVandalici) = .CoperturaIncendioAttiVandaliciDolosi.Stato
                    EnabledAndChecked(chkIncendioCristalli) = .CoperturaIncendioCristalli.Stato
                    EnabledAndChecked(chkIncendioOnorariPeriti) = .CoperturaIncendioOnorariPeriti.Stato
                    EnabledAndChecked(chkIncendioDanniImpianti) = .CoperturaIncendioDanniImpiantiElettrici.Stato
                    EnabledAndChecked(chkIncendioBasic) = .CoperturaIncendioFenomeniAtmosfericiBasic.Stato
                    EnabledAndChecked(chkIncendioMedium) = .CoperturaIncendioFenomeniAtmosfericiMediuum.Stato
                    EnabledAndChecked(chkIncendioEnergy) = .CoperturaIncendioEnergy.Stato
                    EnabledAndChecked(chkIncendioExtra) = .CoperturaIncendioExtra.Stato

                    CurrencyBox(txtPartitaIncendio) = .PartitaIncendio.SommaAssicurata
                    txtPartitaIncendio.Enabled = Enable(.CoperturaIncendioBase.Stato)
                    cmbIncendioFABLimite.Enabled = Enable(.CoperturaIncendioFenomeniAtmosfericiBasic.Stato)
                    cmbIncendioFABLimite.SelectedValue = .CoperturaIncendioFenomeniAtmosfericiBasic.Garanzia.Limite
                    cmbIncendioFABFranchigia.Enabled = Enable(.CoperturaIncendioFenomeniAtmosfericiBasic.Stato)
                    cmbIncendioFABFranchigia.SelectedValue = .CoperturaIncendioFenomeniAtmosfericiBasic.Garanzia.Franchigia

                    cmbIncendioFAMMassimale.Enabled = Enable(.CoperturaIncendioFenomeniAtmosfericiMediuum.Stato)
                    cmbIncendioFAMMassimale.SelectedValue = .CoperturaIncendioFenomeniAtmosfericiMediuum.Garanzia.Massimale
                    cmbIncendioFAMFranchigia.Enabled = Enable(.CoperturaIncendioFenomeniAtmosfericiMediuum.Stato)
                    cmbIncendioFAMFranchigia.SelectedValue = .CoperturaIncendioFenomeniAtmosfericiMediuum.Garanzia.Franchigia
                    cmbIncendioAttiVandaliciDolosiFranchigia.Enabled = Enable(.CoperturaIncendioAttiVandaliciDolosi.Stato)
                    cmbIncendioAttiVandaliciDolosiFranchigia.SelectedValue = .CoperturaIncendioAttiVandaliciDolosi.Garanzia.Franchigia
                    cmbIncendioAttiTerrorismoLimite.Enabled = Enable(.CoperturaIncendioAttiTerrorismo.Stato)
                    cmbIncendioAttiTerrorismoLimite.SelectedValue = .CoperturaIncendioAttiTerrorismo.Garanzia.Limite
                    cmbIncendioAttiTerrorismoFranchigia.Enabled = Enable(.CoperturaIncendioAttiTerrorismo.Stato)
                    cmbIncendioAttiTerrorismoFranchigia.SelectedValue = .CoperturaIncendioAttiTerrorismo.Garanzia.Franchigia

                    cmbIncendioDanniImpiantiElettriciMassimale.Enabled = Enable(.CoperturaIncendioDanniImpiantiElettrici.Stato)
                    cmbIncendioDanniImpiantiElettriciMassimale.SelectedValue = .CoperturaIncendioDanniImpiantiElettrici.Garanzia.Massimale
                    cmbIncendioDanniImpiantiElettriciFranchigia.Enabled = Enable(.CoperturaIncendioDanniImpiantiElettrici.Stato)
                    cmbIncendioDanniImpiantiElettriciFranchigia.SelectedValue = .CoperturaIncendioDanniImpiantiElettrici.Garanzia.Franchigia
                    cmbIncendioCristalliMassimale.Enabled = Enable(.CoperturaIncendioCristalli.Stato)
                    cmbIncendioCristalliMassimale.SelectedValue = .CoperturaIncendioCristalli.Garanzia.Massimale
                    cmbIncendioEnergyMassimale.Enabled = Enable(.CoperturaIncendioEnergy.Stato)
                    cmbIncendioEnergyMassimale.SelectedValue = .CoperturaIncendioEnergy.Garanzia.Massimale

                    cmbIncendioExtraMassimale1.Enabled = Enable(.CoperturaIncendioExtra.Stato)
                    cmbIncendioExtraFranchigia1.Enabled = Enable(.CoperturaIncendioExtra.Stato)
                    cmbIncendioExtraMassimale2.Enabled = Enable(.CoperturaIncendioExtra.Stato)
                    cmbIncendioExtraFranchigia2.Enabled = Enable(.CoperturaIncendioExtra.Stato)
                    With .CoperturaIncendioExtra.Garanzia
                        cmbIncendioExtraMassimale1.SelectedValue = .Garanzie(0).Massimale
                        cmbIncendioExtraFranchigia1.SelectedValue = .Garanzie(0).Franchigia
                        cmbIncendioExtraMassimale2.SelectedValue = .Garanzie(1).Massimale
                        cmbIncendioExtraFranchigia2.SelectedValue = .Garanzie(1).Franchigia
                    End With

                    cmbIncendioDemolizioneSgomberoMassimale.Enabled = Enable(.CoperturaIncendioDemolizioneSgombero.Stato)
                    cmbIncendioDemolizioneSgomberoMassimale.SelectedValue = .CoperturaIncendioDemolizioneSgombero.Garanzia.Massimale
                    cmbIncendioOnorariPeritiMassimale.Enabled = Enable(.CoperturaIncendioOnorariPeriti.Stato)
                    cmbIncendioOnorariPeritiMassimale.SelectedValue = .CoperturaIncendioOnorariPeriti.Garanzia.Massimale

                    'TERREMOTO
                    EnabledAndChecked(chkTerremotoBase) = .CoperturaTerremotoBase.Stato

                    cmbCaratteristicaCostruttiva.SelectedValue = CInt(.CaratteristicaCostruttiva)
                    cmbCaratteristicaCostruttiva.Enabled = chkTerremotoBase.Enabled
                    cmbTerremotoFabbricatoLimite.SelectedValue = .CoperturaTerremotoBase.Garanzia.Limite
                    cmbTerremotoFabbricatoLimite.Enabled = chkTerremotoBase.Enabled
                    lblTerremotoAll.Text = FormatCurrency(.CoperturaTerremotoBase.PremioLabel)

                    'totali
                    lblIncendioAll.Text = FormatCurrency(.CoperturaIncendio.PremioLabel)
                    lblIncendioAttiTerrorismo.Text = FormatCurrency(.CoperturaIncendioAttiTerrorismo.PremioLabel)
                    lblIncendioAttiVandalici.Text = FormatCurrency(.CoperturaIncendioAttiVandaliciDolosi.PremioLabel)
                    lblIncendioBase.Text = FormatCurrency(.CoperturaIncendioBase.PremioLabel)
                    lblIncendioBasic.Text = FormatCurrency(.CoperturaIncendioFenomeniAtmosfericiBasic.PremioLabel)
                    lblIncendioCristalli.Text = FormatCurrency(.CoperturaIncendioCristalli.PremioLabel)
                    lblIncendioDanniImpianti.Text = FormatCurrency(.CoperturaIncendioDanniImpiantiElettrici.PremioLabel)
                    lblIncendioEnergy.Text = FormatCurrency(.CoperturaIncendioEnergy.PremioLabel)
                    lblIncendioExtra.Text = FormatCurrency(.CoperturaIncendioExtra.PremioLabel)
                    lblIncendioMedium.Text = FormatCurrency(.CoperturaIncendioFenomeniAtmosfericiMediuum.PremioLabel)
                    lblIncendioDemolizioneSgombero.Text = FormatCurrency(.CoperturaIncendioDemolizioneSgombero.PremioLabel)
                    lblIncendioOnorariPeriti.Text = FormatCurrency(.CoperturaIncendioOnorariPeriti.PremioLabel)

                    'RC
                    EnabledAndChecked(chkRC) = .CoperturaResponsabilitaCivile.Stato
                    EnabledAndChecked(chkRCBase) = .CoperturaResponsabilitaCivileBase.Stato
                    EnabledAndChecked(chkRCCL) = .CoperturaResponsabilitaCommittenzaLavori.Stato
                    EnabledAndChecked(chkRCCui) = .CoperturaResponsabilitaConduzioneUnitaImmobiliari.Stato
                    EnabledAndChecked(chkRCEnergy) = .CoperturaResponsabilitaEnergy.Stato
                    EnabledAndChecked(chkRCPL) = .CoperturaResponsabilitaPrestatoriLavoro.Stato
                    EnabledAndChecked(chkRCAmministratore) = .CoperturaResponsabilitaAmministratore.Stato

                    cmbResponsabilitaCivileBaseMassimale.Enabled = Enable(.CoperturaResponsabilitaCivileBase.Stato)
                    cmbResponsabilitaCivileBaseMassimale.SelectedValue = .CoperturaResponsabilitaCivileBase.Garanzia.Massimale
                    cmbResponsabilitaPrestatoriLavoroMassimale.Enabled = Enable(.CoperturaResponsabilitaPrestatoriLavoro.Stato)
                    cmbResponsabilitaPrestatoriLavoroMassimale.SelectedValue = .CoperturaResponsabilitaPrestatoriLavoro.Garanzia.Massimale
                    cmbResponsabilitaCommittenzaLavoriMassimale.Enabled = Enable(.CoperturaResponsabilitaCommittenzaLavori.Stato)
                    cmbResponsabilitaCommittenzaLavoriMassimale.SelectedValue = .CoperturaResponsabilitaCommittenzaLavori.Garanzia.Massimale
                    cmbResponsabilitaConduzioneUnitaImmobiliariMassimale.Enabled = Enable(.CoperturaResponsabilitaConduzioneUnitaImmobiliari.Stato)
                    cmbResponsabilitaConduzioneUnitaImmobiliariMassimale.SelectedValue = .CoperturaResponsabilitaConduzioneUnitaImmobiliari.Garanzia.Massimale
                    cmbResponsabilitaAmministratoreMassimale.Enabled = Enable(.CoperturaResponsabilitaAmministratore.Stato)
                    cmbResponsabilitaAmministratoreMassimale.SelectedValue = .CoperturaResponsabilitaAmministratore.Garanzia.Massimale
                    cmbResponsabilitaEnergyMassimale.Enabled = Enable(.CoperturaResponsabilitaEnergy.Stato)
                    cmbResponsabilitaEnergyMassimale.SelectedValue = .CoperturaResponsabilitaEnergy.Garanzia.Massimale


                    lblRC.Text = FormatCurrency(.CoperturaResponsabilitaCivile.PremioLabel)
                    lblRCAmministratore.Text = FormatCurrency(.CoperturaResponsabilitaAmministratore.PremioLabel)
                    lblRCBase.Text = FormatCurrency(.CoperturaResponsabilitaCivileBase.PremioLabel)
                    lblRCCL.Text = FormatCurrency(.CoperturaResponsabilitaCommittenzaLavori.PremioLabel)
                    lblRCCui.Text = FormatCurrency(.CoperturaResponsabilitaConduzioneUnitaImmobiliari.PremioLabel)
                    lblRCEnergy.Text = FormatCurrency(.CoperturaResponsabilitaEnergy.PremioLabel)
                    lblRCPL.Text = FormatCurrency(.CoperturaResponsabilitaPrestatoriLavoro.PremioLabel)

                    'DANNI ACQUA
                    EnabledAndChecked(chkDABase) = .CoperturaDanniAcquaBase.Stato
                    EnabledAndChecked(chkDAEnergy) = .CoperturaDanniAcquaEnergy.Stato
                    EnabledAndChecked(chkDAFuo) = .CoperturaDanniAcquaFuoriUscitaOcclusione.Stato
                    EnabledAndChecked(chkDASrr) = .CoperturaDanniAcquaSpeseRicercaRiparazione.Stato

                    cmbDanniAcquaBaseMassimale.Enabled = .CoperturaDanniAcquaBase.IsAttivo
                    cmbDanniAcquaBaseMassimale.SelectedValue = .CoperturaDanniAcquaBase.Garanzia.Massimale
                    cmbDanniAcquaBaseFranchigia.Enabled = .CoperturaDanniAcquaBase.IsAttivo
                    cmbDanniAcquaBaseFranchigia.SelectedValue = .CoperturaDanniAcquaBase.Garanzia.Franchigia
                    cmbDanniAcquaFuoriUscitaOcclusioneFranchigia.Enabled = Enable(.CoperturaDanniAcquaFuoriUscitaOcclusione.Stato)
                    cmbDanniAcquaFuoriUscitaOcclusioneFranchigia.SelectedValue = .CoperturaDanniAcquaFuoriUscitaOcclusione.Garanzia.Franchigia
                    cmbDanniAcquaSpeseRicercaRiparazioneMassimale.Enabled = Enable(.CoperturaDanniAcquaSpeseRicercaRiparazione.Stato)
                    cmbDanniAcquaSpeseRicercaRiparazioneMassimale.SelectedValue = .CoperturaDanniAcquaSpeseRicercaRiparazione.Garanzia.MassimalePerAnno
                    cmbDanniAcquaSpeseRicercaRiparazioneFranchigia.Enabled = Enable(.CoperturaDanniAcquaSpeseRicercaRiparazione.Stato)
                    cmbDanniAcquaSpeseRicercaRiparazioneFranchigia.SelectedValue = .CoperturaDanniAcquaSpeseRicercaRiparazione.Garanzia.Franchigia
                    cmbDanniAcquaEnergyFranchigia.Enabled = Enable(.CoperturaDanniAcquaEnergy.Stato)
                    cmbDanniAcquaEnergyFranchigia.SelectedValue = .CoperturaDanniAcquaEnergy.Garanzia.Franchigia

                    lblDABase.Text = FormatCurrency(.CoperturaDanniAcquaBase.PremioLabel)
                    lblDAEnergy.Text = FormatCurrency(.CoperturaDanniAcquaEnergy.PremioLabel)
                    lblDAFuo.Text = FormatCurrency(.CoperturaDanniAcquaFuoriUscitaOcclusione.PremioLabel)
                    lblDASrr.Text = FormatCurrency(.CoperturaDanniAcquaSpeseRicercaRiparazione.PremioLabel)

                    'INFORTUNI
                    EnabledAndChecked(chkInfortuniBase) = .CoperturaInfortuniBase.Stato
                    lblInfortuniBase.Text = FormatCurrency(.CoperturaInfortuniBase.PremioLabel)
                    cmbInfortuniBaseMassimale.Enabled = .CoperturaInfortuniBase.IsAttivo
                    cmbInfortuniBaseMassimale.SelectedValue = .CoperturaInfortuniBase.Garanzia.Garanzie(0).Massimale

                    'TUTELA LEGALE
                    EnabledAndChecked(chkTlBase) = .CoperturaTutelaLegaleBase.Stato
                    EnabledAndChecked(chkTlDa) = .CoperturaTutelaLegaleDelibereAssemlea.Stato
                    EnabledAndChecked(chkTl19603) = .CoperturaTutelaLegaleDlgs19603.Stato
                    EnabledAndChecked(chkTl8108) = .CoperturaTutelaLegaleDlgs8108.Stato

                    cmbTutelaLegaleBaseMassimale.Enabled = .CoperturaTutelaLegaleBase.IsAttivo
                    cmbTutelaLegaleBaseMassimale.SelectedValue = .CoperturaTutelaLegaleBase.Garanzia.Massimale

                    lblTl19603.Text = FormatCurrency(.CoperturaTutelaLegaleDlgs19603.PremioLabel)
                    lblTl8108.Text = FormatCurrency(.CoperturaTutelaLegaleDlgs8108.PremioLabel)
                    lblTlBase.Text = FormatCurrency(.CoperturaTutelaLegaleBase.PremioLabel)
                    lblTlDa.Text = FormatCurrency(.CoperturaTutelaLegaleDelibereAssemlea.PremioLabel)

                    'ESTENSIONI
                    EnabledAndChecked(chkIncendioEstensioneGaranziaBase) = .CoperturaIncendioEstensioneGaranziaBase.Stato
                    lblIncendioEstensioneGaranziaBase.Text = FormatCurrency(.CoperturaIncendioEstensioneGaranziaBase.PremioLabel)
                    EnabledAndChecked(chkDanniAcquaPerditeOcculte) = .CoperturaDanniAcquaPerditeOcculte.Stato
                    lblDanniAcquaPerditeOcculte.Text = FormatCurrency(.CoperturaDanniAcquaPerditeOcculte.PremioLabel)
                    cmbDanniAcquaFormaVendita.Enabled = Enable(.CoperturaDanniAcquaPerditeOcculte.Stato)
                    cmbDanniAcquaFormaVendita.SelectedValue = CInt(.DanniAcquaFormaVendita)
                End If


                'RIEPILOGO GARANZIE
                If diretto = False Then

                    lblPremioIncendio.Text = FormatEuro(.SezioneIncendio.PremioLabel)
                    chkIncendio.Checked = .SezioneIncendio.IsAttivo
                    chkIncendio.Enabled = False

                    lblPremioRC.Text = FormatEuro(.SezioneResponsabilitaCivile.PremioLabel)
                    chkPremioRC.Checked = .SezioneResponsabilitaCivile.IsAttivo
                    chkPremioRC.Enabled = False

                    lblPremioDanniAcqua.Text = FormatEuro(.SezioneDanniAcqua.PremioLabel)
                    chkPremioDanniAcqua.Checked = .SezioneDanniAcqua.IsAttivo
                    chkPremioDanniAcqua.Enabled = False

                    lblPremioInfortuni.Text = FormatEuro(.SezioneInfortuni.PremioLabel)
                    chkPremioInfortuni.Checked = .SezioneInfortuni.IsAttivo
                    chkPremioInfortuni.Enabled = False

                    lblPremioTutelaLegale.Text = FormatEuro(.SezioneTutelaLegale.PremioLabel)
                    chkPremioTutelaLegale.Checked = .SezioneTutelaLegale.IsAttivo
                    chkPremioTutelaLegale.Enabled = False

                    lblPremioTerremoto.Text = FormatEuro(.SezioneTerremoto.PremioLabel)
                    chkPremioTerremoto.Checked = .SezioneTerremoto.IsAttivo
                    chkPremioTerremoto.Enabled = False


                    lblPremioTotale.Text = FormatEuro(.PremioLabel)
                End If
            End With
        End Sub

        Private Sub cmbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvinciaFabbricato.SelectedIndexChanged
            cmbProvinciaSelectedIndexChanged(cmbProvinciaFabbricato, cmbComune)
        End Sub

    End Class
End Namespace
