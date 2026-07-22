Namespace P01201
    Public Class P01201FE

        Protected Overrides Sub AttachEvents()
            AddHandler cmbAttivitaProfessionale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbPersonaSceltaForma.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbPersonaITForma.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbPersonaRicoveroForma.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbPersonaImmobilizzazioneForma.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFamigliaSceltaForma.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbVeicoloSceltaForma.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbTipologiaVeicolo.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbVeicoloRicoveroForma.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbMalattiaITSceltaForma.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbMalattiaRicoveroSceltaForma.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbAssistenzaPacchetto.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbTipoAttivita.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler txtAssicuratoEta.Leave, AddressOf ValuesChanged
            AddHandler txtAssicuratoEta.KeyPress, AddressOf TextBoxKeyPress

            AddHandler chkPersonaBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkPersonaMorte.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaMorte.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaMorte.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkPersonaIP.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaIP.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaIP.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkPersonaIT.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaIT.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaIT.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkPersonaRicovero.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaRicovero.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaRicovero.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkPersonaImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaImmobilizzazione.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaImmobilizzazione.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkPersonaSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSpeseMediche.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSpeseMediche.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkPersonaRenditaVitalizia.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbPersonaRenditaVitaliziaMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkPersonaFranchigiaRelativa.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbPersonaFranchigiaRelativaFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkPersonaFranchigia5.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkPersonaFranchigia3.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkPersonaFranchigiaDifferenziata.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkPersonaIndennizzoVariabile.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkPersonaSpecifica.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkPersonaMaggiorazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkPersonaTabellaINAIL.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkPersonaTabellaUGFPLUS.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkPersonaRischiDomestivi.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkPersonaSportsAltoRischioMorte.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsAltoRischioMorte.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsAltoRischioMorte.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkPersonaSportsAltoRischioIP.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsAltoRischioIP.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsAltoRischioIP.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkPersonaSportsAltoRischioRicovero.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsAltoRischioRicovero.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsAltoRischioRicovero.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkPersonaSportsAltoRischioSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsAltoRischioSpeseMediche.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsAltoRischioSpeseMediche.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkPersonaSportsMotoristiciMorte.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsMotoristiciMorte.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsMotoristiciMorte.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkPersonaSportsMotoristiciIP.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsMotoristiciIP.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsMotoristiciIP.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkPersonaSportsAereiMorte.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsAereiMorte.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsAereiMorte.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkPersonaSportsAereiIP.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsAereiIP.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaPersonaSportsAereiIP.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkPersonaEsclusioneGuidaMotoveicoli.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkPersonaEsclusioneSports.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkFamigliaBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFamigliaMorte.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFamigliaMorte.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFamigliaMorte.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFamigliaIP.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFamigliaIP.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFamigliaIP.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFamigliaRicoveroConvalescenza.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFamigliaRicoveroConvalescenza.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFamigliaRicoveroConvalescenza.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFamigliaImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFamigliaImmobilizzazione.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFamigliaImmobilizzazione.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFamigliaSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFamigliaSpeseMediche.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFamigliaSpeseMediche.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFamigliaTabellaINAIL.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFamigliaFranchigiaDifferenziata.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFamigliaRischiDomestivi.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkVeicoloBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkVeicoloMorte.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaVeicoloMorte.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaVeicoloMorte.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkVeicoloIP.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaVeicoloIP.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaVeicoloIP.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkVeicoloRicovero.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaVeicoloRicovero.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaVeicoloRicovero.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkVeicoloImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaVeicoloImmobilizzazione.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaVeicoloImmobilizzazione.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkVeicoloSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaVeicoloSpeseMediche.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaVeicoloSpeseMediche.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkVeicoloTabellaINAIL.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkVeicoloFranchigiaDifferenziata.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkVeicoloFranchigia5.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkVeicoloFranchigiaAssoluta.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkMalattiaBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaInvaliditaPermanente.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaMalattiaInvaliditaPermanente.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaMalattiaInvaliditaPermanente.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkMalattiaInabilitaTemporanea.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaMalattiaInabilitaTemporanea.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaMalattiaInabilitaTemporanea.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkMalattiaRicovero.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaMalattiaRicovero.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaMalattiaRicovero.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkMalattiaImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaMalattiaImmobilizzazione.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaMalattiaImmobilizzazione.KeyPress, AddressOf TextBoxKeyPress

            AddHandler chkAssistenzaBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            AddHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
        End Sub

        Protected Overrides Sub DetachEvents()
            RemoveHandler cmbAttivitaProfessionale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbPersonaSceltaForma.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbPersonaITForma.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbPersonaRicoveroForma.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbPersonaImmobilizzazioneForma.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbFamigliaSceltaForma.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbVeicoloSceltaForma.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbTipologiaVeicolo.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbVeicoloRicoveroForma.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbMalattiaITSceltaForma.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbMalattiaRicoveroSceltaForma.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbAssistenzaPacchetto.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbTipoAttivita.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler txtAssicuratoEta.Leave, AddressOf ValuesChanged
            RemoveHandler txtAssicuratoEta.KeyPress, AddressOf TextBoxKeyPress

            RemoveHandler chkPersonaBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkPersonaMorte.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaMorte.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaMorte.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkPersonaIP.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaIP.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaIP.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkPersonaIT.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaIT.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaIT.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkPersonaRicovero.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaRicovero.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaRicovero.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkPersonaImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaImmobilizzazione.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaImmobilizzazione.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkPersonaSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSpeseMediche.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSpeseMediche.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkPersonaRenditaVitalizia.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbPersonaRenditaVitaliziaMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkPersonaFranchigiaRelativa.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbPersonaFranchigiaRelativaFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkPersonaFranchigia5.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkPersonaFranchigia3.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkPersonaFranchigiaDifferenziata.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkPersonaIndennizzoVariabile.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkPersonaSpecifica.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkPersonaMaggiorazione.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkPersonaTabellaINAIL.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkPersonaTabellaUGFPLUS.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkPersonaRischiDomestivi.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkPersonaSportsAltoRischioMorte.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsAltoRischioMorte.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsAltoRischioMorte.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkPersonaSportsAltoRischioIP.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsAltoRischioIP.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsAltoRischioIP.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkPersonaSportsAltoRischioRicovero.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsAltoRischioRicovero.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsAltoRischioRicovero.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkPersonaSportsAltoRischioSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsAltoRischioSpeseMediche.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsAltoRischioSpeseMediche.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkPersonaSportsMotoristiciMorte.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsMotoristiciMorte.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsMotoristiciMorte.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkPersonaSportsMotoristiciIP.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsMotoristiciIP.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsMotoristiciIP.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkPersonaSportsAereiMorte.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsAereiMorte.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsAereiMorte.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkPersonaSportsAereiIP.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsAereiIP.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaPersonaSportsAereiIP.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkPersonaEsclusioneGuidaMotoveicoli.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkPersonaEsclusioneSports.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkFamigliaBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkFamigliaMorte.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaFamigliaMorte.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaFamigliaMorte.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkFamigliaIP.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaFamigliaIP.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaFamigliaIP.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkFamigliaRicoveroConvalescenza.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaFamigliaRicoveroConvalescenza.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaFamigliaRicoveroConvalescenza.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkFamigliaImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaFamigliaImmobilizzazione.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaFamigliaImmobilizzazione.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkFamigliaSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaFamigliaSpeseMediche.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaFamigliaSpeseMediche.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkFamigliaTabellaINAIL.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkFamigliaFranchigiaDifferenziata.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkFamigliaRischiDomestivi.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkVeicoloBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkVeicoloMorte.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaVeicoloMorte.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaVeicoloMorte.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkVeicoloIP.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaVeicoloIP.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaVeicoloIP.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkVeicoloRicovero.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaVeicoloRicovero.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaVeicoloRicovero.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkVeicoloImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaVeicoloImmobilizzazione.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaVeicoloImmobilizzazione.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkVeicoloSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaVeicoloSpeseMediche.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaVeicoloSpeseMediche.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkVeicoloTabellaINAIL.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkVeicoloFranchigiaDifferenziata.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkVeicoloFranchigia5.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkVeicoloFranchigiaAssoluta.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkMalattiaBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkMalattiaInvaliditaPermanente.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaMalattiaInvaliditaPermanente.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaMalattiaInvaliditaPermanente.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkMalattiaInabilitaTemporanea.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaMalattiaInabilitaTemporanea.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaMalattiaInabilitaTemporanea.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkMalattiaRicovero.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaMalattiaRicovero.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaMalattiaRicovero.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkMalattiaImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaMalattiaImmobilizzazione.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaMalattiaImmobilizzazione.KeyPress, AddressOf TextBoxKeyPress

            RemoveHandler chkAssistenzaBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            RemoveHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
        End Sub

        Public Sub New()
            InitializeComponent2()
            Me.TabControl1.Controls.Add(Me.docTab)
            Me.QuotatorePremio.Image = Global.UniQuota.My.Resources.Resources.P01201
            Me.docBrowser.Tag = "http://www.utools.it/Unitools/Doc/Prodotti/P01201/IndexDoc.htm"
            Me.docBrowser.Url = New System.Uri(Me.docBrowser.Tag, System.UriKind.Absolute)

            'preventivo = New PiuSereni
            'modello = New P01201ST

            Dim decode As New P01201DE
            'preventivo.Decode = decode
            Me.decode = decode

            helpChm.CodiceProdotto = "P01201"
            If helpChm.FileExists Then
                AgganciaHelp(Me, AddressOf MouseClickedHelp)
            End If

            AttachCombo(QuotatorePremio.cmbFrazionamento, decode.DecodeFrazionamenti)
            AttachCombo(cmbAttivitaProfessionale, decode.DecodeAttivitaProfessionale)
            AttachCombo(cmbPersonaSceltaForma, decode.DecodePersonaSceltaForma)
            AttachCombo(cmbPersonaITForma, decode.DecodePersonaITForma)
            AttachCombo(cmbPersonaRicoveroForma, decode.DecodePersonaRicoveroForma)
            AttachCombo(cmbPersonaImmobilizzazioneForma, decode.DecodePersonaImmobilizzazioneForma)
            AttachCombo(cmbFamigliaSceltaForma, decode.DecodeFamigliaSceltaForma)
            AttachCombo(cmbVeicoloSceltaForma, decode.DecodeVeicoloSceltaForma)
            AttachCombo(cmbTipologiaVeicolo, decode.DecodeTipologiaVeicolo)
            AttachCombo(cmbVeicoloRicoveroForma, decode.DecodeVeicoloRicoveroForma)
            AttachCombo(cmbMalattiaITSceltaForma, decode.DecodeMalattiaITSceltaForma)
            AttachCombo(cmbMalattiaRicoveroSceltaForma, decode.DecodeMalattiaRicoveroSceltaForma)
            AttachCombo(cmbAssistenzaPacchetto, decode.DecodeAssistenzaPacchetto)
            AttachCombo(cmbTipoAttivita, decode.DecodeTipoAttivita)
            AttachCombo(cmbPersonaRenditaVitaliziaMassimale, decode.DecodePersonaRenditaVitaliziaMassimale)
            AttachCombo(cmbPersonaFranchigiaRelativaFranchigia, decode.DecodePersonaFranchigiaRelativaFranchigia)

            'preventivo.Inizializza()
            'preventivo.ValidaECalcola()
            'PreventivoToControls()
            panels = {TableLayoutPanel2, TableLayoutPanel3, TableLayoutPanel4, TableLayoutPanel5, TableLayoutPanel6, TableLayoutPanel7}
        End Sub

        Protected Overrides Sub ControlsToPreventivo(ByVal diretto As Boolean)
            With TryCast(preventivo, YouInfortuni)

                If diretto Then
                    .AttivitaProfessionale = cmbAttivitaProfessionale.SelectedValue
                    .TipoAttivita = cmbTipoAttivita.SelectedValue
                    .AssicuratoEta = IntegerBox(txtAssicuratoEta)

                    'Persona
                    .CoperturaPersonaBase.Stato = EnabledAndChecked(chkPersonaBase)
                    .PersonaSceltaForma = cmbPersonaSceltaForma.SelectedValue
                    .CoperturaPersonaMorte.Stato = EnabledAndChecked(chkPersonaMorte)
                    .PartitaPersonaMorte.SommaAssicurata = CurrencyBox(txtPartitaPersonaMorte)
                    .CoperturaPersonaIP.Stato = EnabledAndChecked(chkPersonaIP)
                    .PartitaPersonaIP.SommaAssicurata = CurrencyBox(txtPartitaPersonaIP)
                    .CoperturaPersonaIT.Stato = EnabledAndChecked(chkPersonaIT)
                    .PartitaPersonaIT.SommaAssicurata = CurrencyBox(txtPartitaPersonaIT)
                    .PersonaITForma = cmbPersonaITForma.SelectedValue
                    .CoperturaPersonaRicovero.Stato = EnabledAndChecked(chkPersonaRicovero)
                    .PartitaPersonaRicovero.SommaAssicurata = CurrencyBox(txtPartitaPersonaRicovero)
                    .PersonaRicoveroForma = cmbPersonaRicoveroForma.SelectedValue
                    .CoperturaPersonaImmobilizzazione.Stato = EnabledAndChecked(chkPersonaImmobilizzazione)
                    .PartitaPersonaImmobilizzazione.SommaAssicurata = CurrencyBox(txtPartitaPersonaImmobilizzazione)
                    .PersonaImmobilizzazioneForma = cmbPersonaImmobilizzazioneForma.SelectedValue
                    .CoperturaPersonaSpeseMediche.Stato = EnabledAndChecked(chkPersonaSpeseMediche)
                    .PartitaPersonaSpeseMediche.SommaAssicurata = CurrencyBox(txtPartitaPersonaSpeseMediche)
                    .CoperturaPersonaRenditaVitalizia.Stato = EnabledAndChecked(chkPersonaRenditaVitalizia)
                    .CoperturaPersonaRenditaVitalizia.Garanzia.Massimale = cmbPersonaRenditaVitaliziaMassimale.SelectedValue
                    .CoperturaPersonaFranchigiaRelativa.Stato = EnabledAndChecked(chkPersonaFranchigiaRelativa)
                    .CoperturaPersonaFranchigiaRelativa.Garanzia.Franchigia = cmbPersonaFranchigiaRelativaFranchigia.SelectedValue
                    .CoperturaPersonaFranchigia5.Stato = EnabledAndChecked(chkPersonaFranchigia5)
                    .CoperturaPersonaFranchigia3.Stato = EnabledAndChecked(chkPersonaFranchigia3)
                    .CoperturaPersonaFranchigiaDifferenziata.Stato = EnabledAndChecked(chkPersonaFranchigiaDifferenziata)
                    .CoperturaPersonaIndennizzoVariabile.Stato = EnabledAndChecked(chkPersonaIndennizzoVariabile)
                    .CoperturaPersonaSpecifica.Stato = EnabledAndChecked(chkPersonaSpecifica)
                    .CoperturaPersonaMaggiorazione.Stato = EnabledAndChecked(chkPersonaMaggiorazione)
                    .CoperturaPersonaTabellaINAIL.Stato = EnabledAndChecked(chkPersonaTabellaINAIL)
                    .CoperturaPersonaTabellaUGFPLUS.Stato = EnabledAndChecked(chkPersonaTabellaUGFPLUS)
                    .CoperturaPersonaRischiDomestivi.Stato = EnabledAndChecked(chkPersonaRischiDomestivi)
                    .CoperturaPersonaSportsAltoRischioMorte.Stato = EnabledAndChecked(chkPersonaSportsAltoRischioMorte)
                    .PartitaPersonaSportsAltoRischioMorte.SommaAssicurata = CurrencyBox(txtPartitaPersonaSportsAltoRischioMorte)
                    .CoperturaPersonaSportsAltoRischioIP.Stato = EnabledAndChecked(chkPersonaSportsAltoRischioIP)
                    .PartitaPersonaSportsAltoRischioIP.SommaAssicurata = CurrencyBox(txtPartitaPersonaSportsAltoRischioIP)
                    .CoperturaPersonaSportsAltoRischioRicovero.Stato = EnabledAndChecked(chkPersonaSportsAltoRischioRicovero)
                    .PartitaPersonaSportsAltoRischioRicovero.SommaAssicurata = CurrencyBox(txtPartitaPersonaSportsAltoRischioRicovero)
                    .CoperturaPersonaSportsAltoRischioSpeseMediche.Stato = EnabledAndChecked(chkPersonaSportsAltoRischioSpeseMediche)
                    .PartitaPersonaSportsAltoRischioSpeseMediche.SommaAssicurata = CurrencyBox(txtPartitaPersonaSportsAltoRischioSpeseMediche)
                    .CoperturaPersonaSportsMotoristiciMorte.Stato = EnabledAndChecked(chkPersonaSportsMotoristiciMorte)
                    .PartitaPersonaSportsMotoristiciMorte.SommaAssicurata = CurrencyBox(txtPartitaPersonaSportsMotoristiciMorte)
                    .CoperturaPersonaSportsMotoristiciIP.Stato = EnabledAndChecked(chkPersonaSportsMotoristiciIP)
                    .PartitaPersonaSportsMotoristiciIP.SommaAssicurata = CurrencyBox(txtPartitaPersonaSportsMotoristiciIP)
                    .CoperturaPersonaSportsAereiMorte.Stato = EnabledAndChecked(chkPersonaSportsAereiMorte)
                    .PartitaPersonaSportsAereiMorte.SommaAssicurata = CurrencyBox(txtPartitaPersonaSportsAereiMorte)
                    .CoperturaPersonaSportsAereiIP.Stato = EnabledAndChecked(chkPersonaSportsAereiIP)
                    .PartitaPersonaSportsAereiIP.SommaAssicurata = CurrencyBox(txtPartitaPersonaSportsAereiIP)
                    .CoperturaPersonaEsclusioneGuidaMotoveicoli.Stato = EnabledAndChecked(chkPersonaEsclusioneGuidaMotoveicoli)
                    .CoperturaPersonaEsclusioneSports.Stato = EnabledAndChecked(chkPersonaEsclusioneSports)

                    'Famiglia
                    .CoperturaFamigliaBase.Stato = EnabledAndChecked(chkFamigliaBase)
                    .FamigliaSceltaForma = cmbFamigliaSceltaForma.SelectedValue
                    .CoperturaFamigliaMorte.Stato = EnabledAndChecked(chkFamigliaMorte)
                    .PartitaFamigliaMorte.SommaAssicurata = CurrencyBox(txtPartitaFamigliaMorte)
                    .CoperturaFamigliaIP.Stato = EnabledAndChecked(chkFamigliaIP)
                    .PartitaFamigliaIP.SommaAssicurata = CurrencyBox(txtPartitaFamigliaIP)
                    .CoperturaFamigliaRicoveroConvalescenza.Stato = EnabledAndChecked(chkFamigliaRicoveroConvalescenza)
                    .PartitaFamigliaRicoveroConvalescenza.SommaAssicurata = CurrencyBox(txtPartitaFamigliaRicoveroConvalescenza)
                    .CoperturaFamigliaImmobilizzazione.Stato = EnabledAndChecked(chkFamigliaImmobilizzazione)
                    .PartitaFamigliaImmobilizzazione.SommaAssicurata = CurrencyBox(txtPartitaFamigliaImmobilizzazione)
                    .CoperturaFamigliaSpeseMediche.Stato = EnabledAndChecked(chkFamigliaSpeseMediche)
                    .PartitaFamigliaSpeseMediche.SommaAssicurata = CurrencyBox(txtPartitaFamigliaSpeseMediche)
                    .CoperturaFamigliaTabellaINAIL.Stato = EnabledAndChecked(chkFamigliaTabellaINAIL)
                    .CoperturaFamigliaFranchigiaDifferenziata.Stato = EnabledAndChecked(chkFamigliaFranchigiaDifferenziata)
                    .CoperturaFamigliaRischiDomestivi.Stato = EnabledAndChecked(chkFamigliaRischiDomestivi)

                    'Veicolo
                    .CoperturaVeicoloBase.Stato = EnabledAndChecked(chkVeicoloBase)
                    .VeicoloSceltaForma = cmbVeicoloSceltaForma.SelectedValue
                    .TipologiaVeicolo = cmbTipologiaVeicolo.SelectedValue
                    .CoperturaVeicoloMorte.Stato = EnabledAndChecked(chkVeicoloMorte)
                    .PartitaVeicoloMorte.SommaAssicurata = CurrencyBox(txtPartitaVeicoloMorte)
                    .CoperturaVeicoloIP.Stato = EnabledAndChecked(chkVeicoloIP)
                    .PartitaVeicoloIP.SommaAssicurata = CurrencyBox(txtPartitaVeicoloIP)
                    .CoperturaVeicoloRicovero.Stato = EnabledAndChecked(chkVeicoloRicovero)
                    .PartitaVeicoloRicovero.SommaAssicurata = CurrencyBox(txtPartitaVeicoloRicovero)
                    .VeicoloRicoveroForma = cmbVeicoloRicoveroForma.SelectedValue
                    .CoperturaVeicoloImmobilizzazione.Stato = EnabledAndChecked(chkVeicoloImmobilizzazione)
                    .PartitaVeicoloImmobilizzazione.SommaAssicurata = CurrencyBox(txtPartitaVeicoloImmobilizzazione)
                    .CoperturaVeicoloSpeseMediche.Stato = EnabledAndChecked(chkVeicoloSpeseMediche)
                    .PartitaVeicoloSpeseMediche.SommaAssicurata = CurrencyBox(txtPartitaVeicoloSpeseMediche)
                    .CoperturaVeicoloTabellaINAIL.Stato = EnabledAndChecked(chkVeicoloTabellaINAIL)
                    .CoperturaVeicoloFranchigiaDifferenziata.Stato = EnabledAndChecked(chkVeicoloFranchigiaDifferenziata)
                    .CoperturaVeicoloFranchigia5.Stato = EnabledAndChecked(chkVeicoloFranchigia5)
                    .CoperturaVeicoloFranchigiaAssoluta.Stato = EnabledAndChecked(chkVeicoloFranchigiaAssoluta)

                    'Malattia
                    .CoperturaMalattiaBase.Stato = EnabledAndChecked(chkMalattiaBase)
                    .CoperturaMalattiaInvaliditaPermanente.Stato = EnabledAndChecked(chkMalattiaInvaliditaPermanente)
                    .PartitaMalattiaInvaliditaPermanente.SommaAssicurata = CurrencyBox(txtPartitaMalattiaInvaliditaPermanente)
                    .CoperturaMalattiaInabilitaTemporanea.Stato = EnabledAndChecked(chkMalattiaInabilitaTemporanea)
                    .PartitaMalattiaInabilitaTemporanea.SommaAssicurata = CurrencyBox(txtPartitaMalattiaInabilitaTemporanea)
                    .MalattiaITSceltaForma = cmbMalattiaITSceltaForma.SelectedValue
                    .CoperturaMalattiaRicovero.Stato = EnabledAndChecked(chkMalattiaRicovero)
                    .PartitaMalattiaRicovero.SommaAssicurata = CurrencyBox(txtPartitaMalattiaRicovero)
                    .MalattiaRicoveroSceltaForma = cmbMalattiaRicoveroSceltaForma.SelectedValue
                    .CoperturaMalattiaImmobilizzazione.Stato = EnabledAndChecked(chkMalattiaImmobilizzazione)
                    .PartitaMalattiaImmobilizzazione.SommaAssicurata = CurrencyBox(txtPartitaMalattiaImmobilizzazione)

                    'Assistenza
                    .CoperturaAssistenzaBase.Stato = EnabledAndChecked(chkAssistenzaBase)
                    .AssistenzaPacchetto = cmbAssistenzaPacchetto.SelectedValue
                Else
                    cmbAttivitaProfessionale.SelectedValue = CInt(.AttivitaProfessionale)
                    cmbAttivitaProfessionale.Enabled = True
                    cmbTipoAttivita.SelectedValue = CInt(.TipoAttivita)
                    cmbTipoAttivita.Enabled = True
                    IntegerBox(txtAssicuratoEta) = .AssicuratoEta
                    txtAssicuratoEta.Enabled = True

                    'Persona
                    EnabledAndChecked(chkPersonaBase) = .CoperturaPersonaBase.Stato
                    cmbPersonaSceltaForma.Enabled = .CoperturaPersonaBase.IsAttivo
                    cmbPersonaSceltaForma.SelectedValue = CInt(.PersonaSceltaForma)
                    EnabledAndChecked(chkPersonaMorte) = .CoperturaPersonaMorte.Stato
                    CurrencyBox(txtPartitaPersonaMorte) = .PartitaPersonaMorte.SommaAssicurata
                    txtPartitaPersonaMorte.Enabled = Enable(.CoperturaPersonaMorte.Stato)
                    FormatEuro(lblPersonaMorte, .CoperturaPersonaMorte)
                    EnabledAndChecked(chkPersonaIP) = .CoperturaPersonaIP.Stato
                    CurrencyBox(txtPartitaPersonaIP) = .PartitaPersonaIP.SommaAssicurata
                    txtPartitaPersonaIP.Enabled = Enable(.CoperturaPersonaIP.Stato)
                    FormatEuro(lblPersonaIP, .CoperturaPersonaIP)
                    EnabledAndChecked(chkPersonaIT) = .CoperturaPersonaIT.Stato
                    CurrencyBox(txtPartitaPersonaIT) = .PartitaPersonaIT.SommaAssicurata
                    txtPartitaPersonaIT.Enabled = Enable(.CoperturaPersonaIT.Stato)
                    FormatEuro(lblPersonaIT, .CoperturaPersonaIT)
                    cmbPersonaITForma.Enabled = Enable(.CoperturaPersonaIT.Stato)
                    cmbPersonaITForma.SelectedValue = CInt(.PersonaITForma)
                    EnabledAndChecked(chkPersonaRicovero) = .CoperturaPersonaRicovero.Stato
                    CurrencyBox(txtPartitaPersonaRicovero) = .PartitaPersonaRicovero.SommaAssicurata
                    txtPartitaPersonaRicovero.Enabled = Enable(.CoperturaPersonaRicovero.Stato)
                    FormatEuro(lblPersonaRicovero, .CoperturaPersonaRicovero)
                    cmbPersonaRicoveroForma.Enabled = Enable(.CoperturaPersonaRicovero.Stato)
                    cmbPersonaRicoveroForma.SelectedValue = CInt(.PersonaRicoveroForma)
                    EnabledAndChecked(chkPersonaImmobilizzazione) = .CoperturaPersonaImmobilizzazione.Stato
                    CurrencyBox(txtPartitaPersonaImmobilizzazione) = .PartitaPersonaImmobilizzazione.SommaAssicurata
                    txtPartitaPersonaImmobilizzazione.Enabled = Enable(.CoperturaPersonaImmobilizzazione.Stato)
                    FormatEuro(lblPersonaImmobilizzazione, .CoperturaPersonaImmobilizzazione)
                    cmbPersonaImmobilizzazioneForma.Enabled = Enable(.CoperturaPersonaImmobilizzazione.Stato)
                    cmbPersonaImmobilizzazioneForma.SelectedValue = CInt(.PersonaImmobilizzazioneForma)
                    EnabledAndChecked(chkPersonaSpeseMediche) = .CoperturaPersonaSpeseMediche.Stato
                    CurrencyBox(txtPartitaPersonaSpeseMediche) = .PartitaPersonaSpeseMediche.SommaAssicurata
                    txtPartitaPersonaSpeseMediche.Enabled = Enable(.CoperturaPersonaSpeseMediche.Stato)
                    FormatEuro(lblPersonaSpeseMediche, .CoperturaPersonaSpeseMediche)
                    EnabledAndChecked(chkPersonaRenditaVitalizia) = .CoperturaPersonaRenditaVitalizia.Stato
                    FormatEuro(lblPersonaRenditaVitalizia, .CoperturaPersonaRenditaVitalizia)
                    cmbPersonaRenditaVitaliziaMassimale.Enabled = Enable(.CoperturaPersonaRenditaVitalizia.Stato)
                    cmbPersonaRenditaVitaliziaMassimale.SelectedValue = .CoperturaPersonaRenditaVitalizia.Garanzia.Massimale
                    EnabledAndChecked(chkPersonaFranchigiaRelativa) = .CoperturaPersonaFranchigiaRelativa.Stato
                    FormatEuro(lblPersonaFranchigiaRelativa, .CoperturaPersonaFranchigiaRelativa)
                    cmbPersonaFranchigiaRelativaFranchigia.Enabled = Enable(.CoperturaPersonaFranchigiaRelativa.Stato)
                    cmbPersonaFranchigiaRelativaFranchigia.SelectedValue = .CoperturaPersonaFranchigiaRelativa.Garanzia.Franchigia
                    EnabledAndChecked(chkPersonaFranchigia5) = .CoperturaPersonaFranchigia5.Stato
                    FormatEuro(lblPersonaFranchigia5, .CoperturaPersonaFranchigia5)
                    EnabledAndChecked(chkPersonaFranchigia3) = .CoperturaPersonaFranchigia3.Stato
                    FormatEuro(lblPersonaFranchigia3, .CoperturaPersonaFranchigia3)
                    EnabledAndChecked(chkPersonaFranchigiaDifferenziata) = .CoperturaPersonaFranchigiaDifferenziata.Stato
                    FormatEuro(lblPersonaFranchigiaDifferenziata, .CoperturaPersonaFranchigiaDifferenziata)
                    EnabledAndChecked(chkPersonaIndennizzoVariabile) = .CoperturaPersonaIndennizzoVariabile.Stato
                    FormatEuro(lblPersonaIndennizzoVariabile, .CoperturaPersonaIndennizzoVariabile)
                    EnabledAndChecked(chkPersonaSpecifica) = .CoperturaPersonaSpecifica.Stato
                    FormatEuro(lblPersonaSpecifica, .CoperturaPersonaSpecifica)
                    EnabledAndChecked(chkPersonaMaggiorazione) = .CoperturaPersonaMaggiorazione.Stato
                    FormatEuro(lblPersonaMaggiorazione, .CoperturaPersonaMaggiorazione)
                    EnabledAndChecked(chkPersonaTabellaINAIL) = .CoperturaPersonaTabellaINAIL.Stato
                    FormatEuro(lblPersonaTabellaINAIL, .CoperturaPersonaTabellaINAIL)
                    EnabledAndChecked(chkPersonaTabellaUGFPLUS) = .CoperturaPersonaTabellaUGFPLUS.Stato
                    FormatEuro(lblPersonaTabellaUGFPLUS, .CoperturaPersonaTabellaUGFPLUS)
                    EnabledAndChecked(chkPersonaRischiDomestivi) = .CoperturaPersonaRischiDomestivi.Stato
                    FormatEuro(lblPersonaRischiDomestivi, .CoperturaPersonaRischiDomestivi)
                    EnabledAndChecked(chkPersonaSportsAltoRischioMorte) = .CoperturaPersonaSportsAltoRischioMorte.Stato
                    CurrencyBox(txtPartitaPersonaSportsAltoRischioMorte) = .PartitaPersonaSportsAltoRischioMorte.SommaAssicurata
                    txtPartitaPersonaSportsAltoRischioMorte.Enabled = Enable(.CoperturaPersonaSportsAltoRischioMorte.Stato)
                    FormatEuro(lblPersonaSportsAltoRischioMorte, .CoperturaPersonaSportsAltoRischioMorte)
                    EnabledAndChecked(chkPersonaSportsAltoRischioIP) = .CoperturaPersonaSportsAltoRischioIP.Stato
                    CurrencyBox(txtPartitaPersonaSportsAltoRischioIP) = .PartitaPersonaSportsAltoRischioIP.SommaAssicurata
                    txtPartitaPersonaSportsAltoRischioIP.Enabled = Enable(.CoperturaPersonaSportsAltoRischioIP.Stato)
                    FormatEuro(lblPersonaSportsAltoRischioIP, .CoperturaPersonaSportsAltoRischioIP)
                    EnabledAndChecked(chkPersonaSportsAltoRischioRicovero) = .CoperturaPersonaSportsAltoRischioRicovero.Stato
                    CurrencyBox(txtPartitaPersonaSportsAltoRischioRicovero) = .PartitaPersonaSportsAltoRischioRicovero.SommaAssicurata
                    txtPartitaPersonaSportsAltoRischioRicovero.Enabled = Enable(.CoperturaPersonaSportsAltoRischioRicovero.Stato)
                    FormatEuro(lblPersonaSportsAltoRischioRicovero, .CoperturaPersonaSportsAltoRischioRicovero)
                    EnabledAndChecked(chkPersonaSportsAltoRischioSpeseMediche) = .CoperturaPersonaSportsAltoRischioSpeseMediche.Stato
                    CurrencyBox(txtPartitaPersonaSportsAltoRischioSpeseMediche) = .PartitaPersonaSportsAltoRischioSpeseMediche.SommaAssicurata
                    txtPartitaPersonaSportsAltoRischioSpeseMediche.Enabled = Enable(.CoperturaPersonaSportsAltoRischioSpeseMediche.Stato)
                    FormatEuro(lblPersonaSportsAltoRischioSpeseMediche, .CoperturaPersonaSportsAltoRischioSpeseMediche)
                    EnabledAndChecked(chkPersonaSportsMotoristiciMorte) = .CoperturaPersonaSportsMotoristiciMorte.Stato
                    CurrencyBox(txtPartitaPersonaSportsMotoristiciMorte) = .PartitaPersonaSportsMotoristiciMorte.SommaAssicurata
                    txtPartitaPersonaSportsMotoristiciMorte.Enabled = Enable(.CoperturaPersonaSportsMotoristiciMorte.Stato)
                    FormatEuro(lblPersonaSportsMotoristiciMorte, .CoperturaPersonaSportsMotoristiciMorte)
                    EnabledAndChecked(chkPersonaSportsMotoristiciIP) = .CoperturaPersonaSportsMotoristiciIP.Stato
                    CurrencyBox(txtPartitaPersonaSportsMotoristiciIP) = .PartitaPersonaSportsMotoristiciIP.SommaAssicurata
                    txtPartitaPersonaSportsMotoristiciIP.Enabled = Enable(.CoperturaPersonaSportsMotoristiciIP.Stato)
                    FormatEuro(lblPersonaSportsMotoristiciIP, .CoperturaPersonaSportsMotoristiciIP)
                    EnabledAndChecked(chkPersonaSportsAereiMorte) = .CoperturaPersonaSportsAereiMorte.Stato
                    CurrencyBox(txtPartitaPersonaSportsAereiMorte) = .PartitaPersonaSportsAereiMorte.SommaAssicurata
                    txtPartitaPersonaSportsAereiMorte.Enabled = Enable(.CoperturaPersonaSportsAereiMorte.Stato)
                    FormatEuro(lblPersonaSportsAereiMorte, .CoperturaPersonaSportsAereiMorte)
                    EnabledAndChecked(chkPersonaSportsAereiIP) = .CoperturaPersonaSportsAereiIP.Stato
                    CurrencyBox(txtPartitaPersonaSportsAereiIP) = .PartitaPersonaSportsAereiIP.SommaAssicurata
                    txtPartitaPersonaSportsAereiIP.Enabled = Enable(.CoperturaPersonaSportsAereiIP.Stato)
                    FormatEuro(lblPersonaSportsAereiIP, .CoperturaPersonaSportsAereiIP)
                    EnabledAndChecked(chkPersonaEsclusioneGuidaMotoveicoli) = .CoperturaPersonaEsclusioneGuidaMotoveicoli.Stato
                    FormatEuro(lblPersonaEsclusioneGuidaMotoveicoli, .CoperturaPersonaEsclusioneGuidaMotoveicoli)
                    EnabledAndChecked(chkPersonaEsclusioneSports) = .CoperturaPersonaEsclusioneSports.Stato
                    FormatEuro(lblPersonaEsclusioneSports, .CoperturaPersonaEsclusioneSports)
                    FormatEuro(lblPersonaPremio, .SezionePersona)

                    'Famiglia
                    EnabledAndChecked(chkFamigliaBase) = .CoperturaFamigliaBase.Stato
                    cmbFamigliaSceltaForma.Enabled = .CoperturaFamigliaBase.IsAttivo
                    cmbFamigliaSceltaForma.SelectedValue = CInt(.FamigliaSceltaForma)
                    EnabledAndChecked(chkFamigliaMorte) = .CoperturaFamigliaMorte.Stato
                    CurrencyBox(txtPartitaFamigliaMorte) = .PartitaFamigliaMorte.SommaAssicurata
                    txtPartitaFamigliaMorte.Enabled = Enable(.CoperturaFamigliaMorte.Stato)
                    FormatEuro(lblFamigliaMorte, .CoperturaFamigliaMorte)
                    EnabledAndChecked(chkFamigliaIP) = .CoperturaFamigliaIP.Stato
                    CurrencyBox(txtPartitaFamigliaIP) = .PartitaFamigliaIP.SommaAssicurata
                    txtPartitaFamigliaIP.Enabled = Enable(.CoperturaFamigliaIP.Stato)
                    FormatEuro(lblFamigliaIP, .CoperturaFamigliaIP)
                    EnabledAndChecked(chkFamigliaRicoveroConvalescenza) = .CoperturaFamigliaRicoveroConvalescenza.Stato
                    CurrencyBox(txtPartitaFamigliaRicoveroConvalescenza) = .PartitaFamigliaRicoveroConvalescenza.SommaAssicurata
                    txtPartitaFamigliaRicoveroConvalescenza.Enabled = Enable(.CoperturaFamigliaRicoveroConvalescenza.Stato)
                    FormatEuro(lblFamigliaRicoveroConvalescenza, .CoperturaFamigliaRicoveroConvalescenza)
                    EnabledAndChecked(chkFamigliaImmobilizzazione) = .CoperturaFamigliaImmobilizzazione.Stato
                    CurrencyBox(txtPartitaFamigliaImmobilizzazione) = .PartitaFamigliaImmobilizzazione.SommaAssicurata
                    txtPartitaFamigliaImmobilizzazione.Enabled = Enable(.CoperturaFamigliaImmobilizzazione.Stato)
                    FormatEuro(lblFamigliaImmobilizzazione, .CoperturaFamigliaImmobilizzazione)
                    EnabledAndChecked(chkFamigliaSpeseMediche) = .CoperturaFamigliaSpeseMediche.Stato
                    CurrencyBox(txtPartitaFamigliaSpeseMediche) = .PartitaFamigliaSpeseMediche.SommaAssicurata
                    txtPartitaFamigliaSpeseMediche.Enabled = Enable(.CoperturaFamigliaSpeseMediche.Stato)
                    FormatEuro(lblFamigliaSpeseMediche, .CoperturaFamigliaSpeseMediche)
                    EnabledAndChecked(chkFamigliaTabellaINAIL) = .CoperturaFamigliaTabellaINAIL.Stato
                    FormatEuro(lblFamigliaTabellaINAIL, .CoperturaFamigliaTabellaINAIL)
                    EnabledAndChecked(chkFamigliaFranchigiaDifferenziata) = .CoperturaFamigliaFranchigiaDifferenziata.Stato
                    FormatEuro(lblFamigliaFranchigiaDifferenziata, .CoperturaFamigliaFranchigiaDifferenziata)
                    EnabledAndChecked(chkFamigliaRischiDomestivi) = .CoperturaFamigliaRischiDomestivi.Stato
                    FormatEuro(lblFamigliaRischiDomestivi, .CoperturaFamigliaRischiDomestivi)
                    FormatEuro(lblFamigliaPremio, .SezioneFamiglia)

                    'Veicolo
                    EnabledAndChecked(chkVeicoloBase) = .CoperturaVeicoloBase.Stato
                    cmbVeicoloSceltaForma.Enabled = .CoperturaVeicoloBase.IsAttivo
                    cmbVeicoloSceltaForma.SelectedValue = CInt(.VeicoloSceltaForma)
                    cmbTipologiaVeicolo.Enabled = .CoperturaVeicoloBase.IsAttivo
                    cmbTipologiaVeicolo.SelectedValue = CInt(.TipologiaVeicolo)
                    EnabledAndChecked(chkVeicoloMorte) = .CoperturaVeicoloMorte.Stato
                    CurrencyBox(txtPartitaVeicoloMorte) = .PartitaVeicoloMorte.SommaAssicurata
                    txtPartitaVeicoloMorte.Enabled = Enable(.CoperturaVeicoloMorte.Stato)
                    FormatEuro(lblVeicoloMorte, .CoperturaVeicoloMorte)
                    EnabledAndChecked(chkVeicoloIP) = .CoperturaVeicoloIP.Stato
                    CurrencyBox(txtPartitaVeicoloIP) = .PartitaVeicoloIP.SommaAssicurata
                    txtPartitaVeicoloIP.Enabled = Enable(.CoperturaVeicoloIP.Stato)
                    FormatEuro(lblVeicoloIP, .CoperturaVeicoloIP)
                    EnabledAndChecked(chkVeicoloRicovero) = .CoperturaVeicoloRicovero.Stato
                    CurrencyBox(txtPartitaVeicoloRicovero) = .PartitaVeicoloRicovero.SommaAssicurata
                    txtPartitaVeicoloRicovero.Enabled = Enable(.CoperturaVeicoloRicovero.Stato)
                    FormatEuro(lblVeicoloRicovero, .CoperturaVeicoloRicovero)
                    cmbVeicoloRicoveroForma.Enabled = Enable(.CoperturaVeicoloRicovero.Stato)
                    cmbVeicoloRicoveroForma.SelectedValue = CInt(.VeicoloRicoveroForma)

                    EnabledAndChecked(chkVeicoloImmobilizzazione) = .CoperturaVeicoloImmobilizzazione.Stato
                    CurrencyBox(txtPartitaVeicoloImmobilizzazione) = .PartitaVeicoloImmobilizzazione.SommaAssicurata
                    txtPartitaVeicoloImmobilizzazione.Enabled = Enable(.CoperturaVeicoloImmobilizzazione.Stato)
                    FormatEuro(lblVeicoloImmobilizzazione, .CoperturaVeicoloImmobilizzazione)
                    EnabledAndChecked(chkVeicoloSpeseMediche) = .CoperturaVeicoloSpeseMediche.Stato
                    CurrencyBox(txtPartitaVeicoloSpeseMediche) = .PartitaVeicoloSpeseMediche.SommaAssicurata
                    txtPartitaVeicoloSpeseMediche.Enabled = Enable(.CoperturaVeicoloSpeseMediche.Stato)
                    FormatEuro(lblVeicoloSpeseMediche, .CoperturaVeicoloSpeseMediche)
                    EnabledAndChecked(chkVeicoloTabellaINAIL) = .CoperturaVeicoloTabellaINAIL.Stato
                    FormatEuro(lblVeicoloTabellaINAIL, .CoperturaVeicoloTabellaINAIL)
                    EnabledAndChecked(chkVeicoloFranchigiaDifferenziata) = .CoperturaVeicoloFranchigiaDifferenziata.Stato
                    FormatEuro(lblVeicoloFranchigiaDifferenziata, .CoperturaVeicoloFranchigiaDifferenziata)
                    EnabledAndChecked(chkVeicoloFranchigia5) = .CoperturaVeicoloFranchigia5.Stato
                    FormatEuro(lblVeicoloFranchigia5, .CoperturaVeicoloFranchigia5)
                    EnabledAndChecked(chkVeicoloFranchigiaAssoluta) = .CoperturaVeicoloFranchigiaAssoluta.Stato
                    FormatEuro(lblVeicoloFranchigiaAssoluta, .CoperturaVeicoloFranchigiaAssoluta)
                    FormatEuro(lblVeicoloPremio, .SezioneVeicolo)

                    'Malattia
                    EnabledAndChecked(chkMalattiaBase) = .CoperturaMalattiaBase.Stato
                    EnabledAndChecked(chkMalattiaInvaliditaPermanente) = .CoperturaMalattiaInvaliditaPermanente.Stato
                    CurrencyBox(txtPartitaMalattiaInvaliditaPermanente) = .PartitaMalattiaInvaliditaPermanente.SommaAssicurata
                    txtPartitaMalattiaInvaliditaPermanente.Enabled = Enable(.CoperturaMalattiaInvaliditaPermanente.Stato)
                    FormatEuro(lblMalattiaInvaliditaPermanente, .CoperturaMalattiaInvaliditaPermanente)
                    EnabledAndChecked(chkMalattiaInabilitaTemporanea) = .CoperturaMalattiaInabilitaTemporanea.Stato
                    CurrencyBox(txtPartitaMalattiaInabilitaTemporanea) = .PartitaMalattiaInabilitaTemporanea.SommaAssicurata
                    txtPartitaMalattiaInabilitaTemporanea.Enabled = Enable(.CoperturaMalattiaInabilitaTemporanea.Stato)
                    FormatEuro(lblMalattiaInabilitaTemporanea, .CoperturaMalattiaInabilitaTemporanea)
                    cmbMalattiaITSceltaForma.Enabled = Enable(.CoperturaMalattiaInabilitaTemporanea.Stato)
                    cmbMalattiaITSceltaForma.SelectedValue = CInt(.MalattiaITSceltaForma)
                    EnabledAndChecked(chkMalattiaRicovero) = .CoperturaMalattiaRicovero.Stato
                    CurrencyBox(txtPartitaMalattiaRicovero) = .PartitaMalattiaRicovero.SommaAssicurata
                    txtPartitaMalattiaRicovero.Enabled = Enable(.CoperturaMalattiaRicovero.Stato)
                    FormatEuro(lblMalattiaRicovero, .CoperturaMalattiaRicovero)
                    cmbMalattiaRicoveroSceltaForma.Enabled = Enable(.CoperturaMalattiaRicovero.Stato)
                    cmbMalattiaRicoveroSceltaForma.SelectedValue = CInt(.MalattiaRicoveroSceltaForma)
                    EnabledAndChecked(chkMalattiaImmobilizzazione) = .CoperturaMalattiaImmobilizzazione.Stato
                    CurrencyBox(txtPartitaMalattiaImmobilizzazione) = .PartitaMalattiaImmobilizzazione.SommaAssicurata
                    txtPartitaMalattiaImmobilizzazione.Enabled = Enable(.CoperturaMalattiaImmobilizzazione.Stato)
                    FormatEuro(lblMalattiaImmobilizzazione, .CoperturaMalattiaImmobilizzazione)
                    FormatEuro(lblMalattiaPremio, .SezioneMalattia)

                    'Assistenza
                    EnabledAndChecked(chkAssistenzaBase) = .CoperturaAssistenzaBase.Stato
                    FormatEuro(lblAssistenzaBase, .CoperturaAssistenzaBase)
                    cmbAssistenzaPacchetto.Enabled = Enable(.CoperturaAssistenzaBase.Stato)
                    cmbAssistenzaPacchetto.SelectedValue = CInt(.AssistenzaPacchetto)
                    FormatEuro(lblAssistenzaPremio, .SezioneAssistenza)
                End If


                'RIEPILOGO GARANZIE
                If diretto = False Then

                    lblSezionePersonaPremio.Text = FormatEuro(.SezionePersona.PremioLabel)
                    chkSezionePersona.Checked = .SezionePersona.IsAttivo
                    chkSezionePersona.Enabled = False

                    lblSezioneFamigliaPremio.Text = FormatEuro(.SezioneFamiglia.PremioLabel)
                    chkSezioneFamiglia.Checked = .SezioneFamiglia.IsAttivo
                    chkSezioneFamiglia.Enabled = False

                    lblSezioneVeicoloPremio.Text = FormatEuro(.SezioneVeicolo.PremioLabel)
                    chkSezioneVeicolo.Checked = .SezioneVeicolo.IsAttivo
                    chkSezioneVeicolo.Enabled = False

                    lblSezioneMalattiaPremio.Text = FormatEuro(.SezioneMalattia.PremioLabel)
                    chkSezioneMalattia.Checked = .SezioneMalattia.IsAttivo
                    chkSezioneMalattia.Enabled = False

                    lblSezioneAssistenzaPremio.Text = FormatEuro(.SezioneAssistenza.PremioLabel)
                    chkSezioneAssistenza.Checked = .SezioneAssistenza.IsAttivo
                    chkSezioneAssistenza.Enabled = False

                    lblSezioneTotalePremio.Text = FormatEuro(.PremioLabel)
                End If
            End With
        End Sub


    End Class
End Namespace
