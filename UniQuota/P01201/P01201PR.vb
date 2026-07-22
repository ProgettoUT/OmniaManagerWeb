Namespace P01201
    <Serializable()> Public Class YouInfortuni
        Inherits Prodotto

        Public RischioProfessionale As RischioProfessionaleEnum
        Public AttivitaProfessionale As AttivitaProfessionaleEnum
        Public PersonaSceltaForma As PersonaSceltaFormaEnum
        Public PersonaITForma As PersonaITFormaEnum
        Public PersonaRicoveroForma As PersonaRicoveroFormaEnum
        Public PersonaImmobilizzazioneForma As PersonaImmobilizzazioneFormaEnum
        Public FamigliaSceltaForma As FamigliaSceltaFormaEnum
        Public VeicoloSceltaForma As VeicoloSceltaFormaEnum
        Public TipologiaVeicolo As TipologiaVeicoloEnum
        Public VeicoloRicoveroForma As VeicoloRicoveroFormaEnum
        Public MalattiaITSceltaForma As MalattiaITSceltaFormaEnum
        Public MalattiaRicoveroSceltaForma As MalattiaRicoveroSceltaFormaEnum
        Public AssistenzaPacchetto As AssistenzaPacchettoEnum
        Public TipoAttivita As TipoAttivitaEnum
        Public AssicuratoEta As Integer

        'aliquote

        'sezioni
        Public SezionePersona As New Sezione(Me, TipoSezione.Persona)
        Public SezioneFamiglia As New Sezione(Me, TipoSezione.Famiglia)
        Public SezioneVeicolo As New Sezione(Me, TipoSezione.Veicolo)
        Public SezioneMalattia As New Sezione(Me, TipoSezione.Malattia)
        Public SezioneAssistenza As New Sezione(Me, TipoSezione.Assistenza)

        'Persona
        Public PartitaPersonaBase As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaBase As New CoperturaSingola(PartitaPersonaBase, New Garanzia(TipoGaranzia.PersonaBase))
        Public PartitaPersonaMorte As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaMorte As New CoperturaSingola(PartitaPersonaMorte, New Garanzia(TipoGaranzia.PersonaMorte), True)
        Public PartitaPersonaIP As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaIP As New CoperturaSingola(PartitaPersonaIP, New Garanzia(TipoGaranzia.PersonaIP), True)
        Public PartitaPersonaIT As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaIT As New CoperturaSingola(PartitaPersonaIT, New Garanzia(TipoGaranzia.PersonaIT), True)
        'Public PartitaPersonaITILimitata As New Partita(TipoPartita.Persona)
        'Public CoperturaPersonaITILimitata As New CoperturaSingola(PartitaPersonaITILimitata, New Garanzia(TipoGaranzia.PersonaITILimitata))
        Public PartitaPersonaRicovero As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaRicovero As New CoperturaSingola(PartitaPersonaRicovero, New Garanzia(TipoGaranzia.PersonaRicovero), True)

        'Public PartitaPersonaConvalescenzaProlungata As New Partita(TipoPartita.Persona)
        'Public CoperturaPersonaConvalescenzaProlungata As New CoperturaSingola(PartitaPersonaConvalescenzaProlungata, New Garanzia(TipoGaranzia.PersonaConvalescenzaProlungata))
        Public PartitaPersonaImmobilizzazione As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaImmobilizzazione As New CoperturaSingola(PartitaPersonaImmobilizzazione, New Garanzia(TipoGaranzia.PersonaImmobilizzazione), True)
        'Public PartitaPersonaImmobilizzazioneProlungata As New Partita(TipoPartita.Persona)
        'Public CoperturaPersonaImmobilizzazioneProlungata As New CoperturaSingola(PartitaPersonaImmobilizzazioneProlungata, New Garanzia(TipoGaranzia.PersonaImmobilizzazioneProlungata))
        Public PartitaPersonaSpeseMediche As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaSpeseMediche As New CoperturaSingola(PartitaPersonaSpeseMediche, New Garanzia(TipoGaranzia.PersonaSpeseMediche), True)
        Public PartitaPersonaRenditaVitalizia As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaRenditaVitalizia As New CoperturaSingola(PartitaPersonaRenditaVitalizia, New Garanzia(TipoGaranzia.PersonaRenditaVitalizia))
        'Public PartitaPersonaITFranchigiaAssoluta As New Partita(TipoPartita.Persona)
        'Public CoperturaPersonaITFranchigiaAssoluta As New CoperturaSingola(PartitaPersonaITFranchigiaAssoluta, New Garanzia(TipoGaranzia.PersonaITFranchigiaAssoluta))
        'Public PartitaPersonaIPFranchigiaAssoluta As New Partita(TipoPartita.Persona)
        'Public CoperturaPersonaIPFranchigiaAssoluta As New CoperturaSingola(PartitaPersonaIPFranchigiaAssoluta, New Garanzia(TipoGaranzia.PersonaIPFranchigiaAssoluta))
        Public PartitaPersonaFranchigiaRelativa As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaFranchigiaRelativa As New CoperturaSingola(PartitaPersonaFranchigiaRelativa, New Garanzia(TipoGaranzia.PersonaFranchigiaRelativa))
        Public PartitaPersonaIndennizzoVariabile As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaIndennizzoVariabile As New CoperturaSingola(PartitaPersonaIndennizzoVariabile, New Garanzia(TipoGaranzia.PersonaIndennizzoVariabile))
        Public PartitaPersonaSpecifica As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaSpecifica As New CoperturaSingola(PartitaPersonaSpecifica, New Garanzia(TipoGaranzia.PersonaSpecifica))
        Public PartitaPersonaMaggiorazione As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaMaggiorazione As New CoperturaSingola(PartitaPersonaMaggiorazione, New Garanzia(TipoGaranzia.PersonaMaggiorazione))
        Public PartitaPersonaTabellaINAIL As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaTabellaINAIL As New CoperturaSingola(PartitaPersonaTabellaINAIL, New Garanzia(TipoGaranzia.PersonaTabellaINAIL))
        Public PartitaPersonaTabellaUGFPLUS As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaTabellaUGFPLUS As New CoperturaSingola(PartitaPersonaTabellaUGFPLUS, New Garanzia(TipoGaranzia.PersonaTabellaUGFPLUS))
        Public PartitaPersonaFranchigiaDifferenziata As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaFranchigiaDifferenziata As New CoperturaSingola(PartitaPersonaFranchigiaDifferenziata, New Garanzia(TipoGaranzia.PersonaFranchigiaDifferenziata))
        Public PartitaPersonaFranchigia5 As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaFranchigia5 As New CoperturaSingola(PartitaPersonaFranchigia5, New Garanzia(TipoGaranzia.PersonaFranchigia5))
        Public PartitaPersonaFranchigia3 As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaFranchigia3 As New CoperturaSingola(PartitaPersonaFranchigia3, New Garanzia(TipoGaranzia.PersonaFranchigia3))
        Public PartitaPersonaRischiDomestivi As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaRischiDomestivi As New CoperturaSingola(PartitaPersonaRischiDomestivi, New Garanzia(TipoGaranzia.PersonaRischiDomestivi))
        Public PartitaPersonaSportsAltoRischioMorte As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaSportsAltoRischioMorte As New CoperturaSingola(PartitaPersonaSportsAltoRischioMorte, New Garanzia(TipoGaranzia.PersonaSportsAltoRischioMorte), True)
        Public PartitaPersonaSportsAltoRischioIP As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaSportsAltoRischioIP As New CoperturaSingola(PartitaPersonaSportsAltoRischioIP, New Garanzia(TipoGaranzia.PersonaSportsAltoRischioIP), True)
        Public PartitaPersonaSportsAltoRischioRicovero As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaSportsAltoRischioRicovero As New CoperturaSingola(PartitaPersonaSportsAltoRischioRicovero, New Garanzia(TipoGaranzia.PersonaSportsAltoRischioRicovero), True)
        Public PartitaPersonaSportsAltoRischioSpeseMediche As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaSportsAltoRischioSpeseMediche As New CoperturaSingola(PartitaPersonaSportsAltoRischioSpeseMediche, New Garanzia(TipoGaranzia.PersonaSportsAltoRischioSpeseMediche), True)
        Public PartitaPersonaSportsMotoristiciMorte As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaSportsMotoristiciMorte As New CoperturaSingola(PartitaPersonaSportsMotoristiciMorte, New Garanzia(TipoGaranzia.PersonaSportsMotoristiciMorte), True)
        Public PartitaPersonaSportsMotoristiciIP As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaSportsMotoristiciIP As New CoperturaSingola(PartitaPersonaSportsMotoristiciIP, New Garanzia(TipoGaranzia.PersonaSportsMotoristiciIP), True)
        Public PartitaPersonaSportsAereiMorte As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaSportsAereiMorte As New CoperturaSingola(PartitaPersonaSportsAereiMorte, New Garanzia(TipoGaranzia.PersonaSportsAereiMorte), True)
        Public PartitaPersonaSportsAereiIP As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaSportsAereiIP As New CoperturaSingola(PartitaPersonaSportsAereiIP, New Garanzia(TipoGaranzia.PersonaSportsAereiIP), True)
        Public PartitaPersonaEsclusioneGuidaMotoveicoli As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaEsclusioneGuidaMotoveicoli As New CoperturaSingola(PartitaPersonaEsclusioneGuidaMotoveicoli, New Garanzia(TipoGaranzia.PersonaEsclusioneGuidaMotoveicoli))
        Public PartitaPersonaEsclusioneSports As New Partita(TipoPartita.Persona)
        Public CoperturaPersonaEsclusioneSports As New CoperturaSingola(PartitaPersonaEsclusioneSports, New Garanzia(TipoGaranzia.PersonaEsclusioneSports))

        'Famiglia
        Public PartitaFamigliaBase As New Partita(TipoPartita.Famiglia)
        Public CoperturaFamigliaBase As New CoperturaSingola(PartitaFamigliaBase, New Garanzia(TipoGaranzia.FamigliaBase))
        Public PartitaFamigliaMorte As New Partita(TipoPartita.Famiglia)
        Public CoperturaFamigliaMorte As New CoperturaSingola(PartitaFamigliaMorte, New Garanzia(TipoGaranzia.FamigliaMorte))
        Public PartitaFamigliaIP As New Partita(TipoPartita.Famiglia)
        Public CoperturaFamigliaIP As New CoperturaSingola(PartitaFamigliaIP, New Garanzia(TipoGaranzia.FamigliaIP))
        Public PartitaFamigliaRicoveroConvalescenza As New Partita(TipoPartita.Famiglia)
        Public CoperturaFamigliaRicoveroConvalescenza As New CoperturaSingola(PartitaFamigliaRicoveroConvalescenza, New Garanzia(TipoGaranzia.FamigliaRicoveroConvalescenza))
        Public PartitaFamigliaImmobilizzazione As New Partita(TipoPartita.Famiglia)
        Public CoperturaFamigliaImmobilizzazione As New CoperturaSingola(PartitaFamigliaImmobilizzazione, New Garanzia(TipoGaranzia.FamigliaImmobilizzazione))
        Public PartitaFamigliaSpeseMediche As New Partita(TipoPartita.Famiglia)
        Public CoperturaFamigliaSpeseMediche As New CoperturaSingola(PartitaFamigliaSpeseMediche, New Garanzia(TipoGaranzia.FamigliaSpeseMediche))
        Public PartitaFamigliaTabellaINAIL As New Partita(TipoPartita.Famiglia)
        Public CoperturaFamigliaTabellaINAIL As New CoperturaSingola(PartitaFamigliaTabellaINAIL, New Garanzia(TipoGaranzia.FamigliaTabellaINAIL))
        Public PartitaFamigliaFranchigiaDifferenziata As New Partita(TipoPartita.Famiglia)
        Public CoperturaFamigliaFranchigiaDifferenziata As New CoperturaSingola(PartitaFamigliaFranchigiaDifferenziata, New Garanzia(TipoGaranzia.FamigliaFranchigiaDifferenziata))
        Public PartitaFamigliaRischiDomestivi As New Partita(TipoPartita.Famiglia)
        Public CoperturaFamigliaRischiDomestivi As New CoperturaSingola(PartitaFamigliaRischiDomestivi, New Garanzia(TipoGaranzia.FamigliaRischiDomestivi))

        'Veicolo
        Public PartitaVeicoloBase As New Partita(TipoPartita.Veicolo)
        Public CoperturaVeicoloBase As New CoperturaSingola(PartitaVeicoloBase, New Garanzia(TipoGaranzia.VeicoloBase))
        Public PartitaVeicoloMorte As New Partita(TipoPartita.Veicolo)
        Public CoperturaVeicoloMorte As New CoperturaSingola(PartitaVeicoloMorte, New Garanzia(TipoGaranzia.VeicoloMorte))
        Public PartitaVeicoloIP As New Partita(TipoPartita.Veicolo)
        Public CoperturaVeicoloIP As New CoperturaSingola(PartitaVeicoloIP, New Garanzia(TipoGaranzia.VeicoloIP))
        Public PartitaVeicoloRicovero As New Partita(TipoPartita.Veicolo)
        Public CoperturaVeicoloRicovero As New CoperturaSingola(PartitaVeicoloRicovero, New Garanzia(TipoGaranzia.VeicoloRicoveroConvalescenza))
        Public PartitaVeicoloImmobilizzazione As New Partita(TipoPartita.Veicolo)
        Public CoperturaVeicoloImmobilizzazione As New CoperturaSingola(PartitaVeicoloImmobilizzazione, New Garanzia(TipoGaranzia.VeicoloImmobilizzazione))
        Public PartitaVeicoloSpeseMediche As New Partita(TipoPartita.Veicolo)
        Public CoperturaVeicoloSpeseMediche As New CoperturaSingola(PartitaVeicoloSpeseMediche, New Garanzia(TipoGaranzia.VeicoloSpeseMediche))
        Public PartitaVeicoloTabellaINAIL As New Partita(TipoPartita.Veicolo)
        Public CoperturaVeicoloTabellaINAIL As New CoperturaSingola(PartitaVeicoloTabellaINAIL, New Garanzia(TipoGaranzia.VeicoloTabellaINAIL))
        Public PartitaVeicoloFranchigiaDifferenziata As New Partita(TipoPartita.Veicolo)
        Public CoperturaVeicoloFranchigiaDifferenziata As New CoperturaSingola(PartitaVeicoloFranchigiaDifferenziata, New Garanzia(TipoGaranzia.VeicoloFranchigiaDifferenziata))
        Public PartitaVeicoloFranchigia5 As New Partita(TipoPartita.Veicolo)
        Public CoperturaVeicoloFranchigia5 As New CoperturaSingola(PartitaVeicoloFranchigia5, New Garanzia(TipoGaranzia.VeicoloFranchigia5))
        Public PartitaVeicoloFranchigiaAssoluta As New Partita(TipoPartita.Veicolo)
        Public CoperturaVeicoloFranchigiaAssoluta As New CoperturaSingola(PartitaVeicoloFranchigiaAssoluta, New Garanzia(TipoGaranzia.VeicoloFranchigiaAssoluta))

        'Malattia
        Public PartitaMalattiaBase As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaBase As New CoperturaSingola(PartitaMalattiaBase, New Garanzia(TipoGaranzia.MalattiaBase))
        Public PartitaMalattiaInvaliditaPermanente As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaInvaliditaPermanente As New CoperturaSingola(PartitaMalattiaInvaliditaPermanente, New Garanzia(TipoGaranzia.MalattiaInvaliditaPermanente))
        Public PartitaMalattiaInabilitaTemporanea As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaInabilitaTemporanea As New CoperturaSingola(PartitaMalattiaInabilitaTemporanea, New Garanzia(TipoGaranzia.MalattiaInabilitaTemporanea))
        Public PartitaMalattiaRicovero As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaRicovero As New CoperturaSingola(PartitaMalattiaRicovero, New Garanzia(TipoGaranzia.MalattiaRicovero))
        Public PartitaMalattiaImmobilizzazione As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaImmobilizzazione As New CoperturaSingola(PartitaMalattiaImmobilizzazione, New Garanzia(TipoGaranzia.MalattiaImmobilizzazione))

        'Assistenza
        Public PartitaAssistenzaBase As New Partita(TipoPartita.Assistenza)
        Public CoperturaAssistenzaBase As New CoperturaSingola(PartitaAssistenzaBase, New Garanzia(TipoGaranzia.AssistenzaBase))

        Public Sub New()
            'Caratteristiche
            CodiceRamoPolizza = 77
            CodiceProdotto = TipoProdotto.YouInfortuni
            DescrizioneProdotto = P00000DE.DecodeProdotto(CodiceProdotto)

            Edizione = "201403"
            DataEntrataVigore = "01/03/2014"

            DurataContrattualeMinimaInAnni =
            DurataContrattualeMassimaInAnni =
            PeriodoMoraInGiorni =
            EmissioneAppendici = False
            TacitoRinnovo = True

            ContraenzaPersonaGiuridica = True
            ContraenzaPersonaFisica = True
            PremioMinimoPrimaRata = 0D
            PremioMinimoRataSuccessiva = 0D

            'I tassi e i premi della presente tariffa sono comprensivi di imposte e oneri parafiscali.
            BaseTasse = UniQuota.BaseTasse.BaseNetta

            'sezioni
            Sezioni.Add(SezionePersona)
            Sezioni.Add(SezioneFamiglia)
            Sezioni.Add(SezioneVeicolo)
            Sezioni.Add(SezioneMalattia)
            Sezioni.Add(SezioneAssistenza)

            'esclusione sconti
            SezioneMalattia.EscludiFlex = True
            SezioneAssistenza.EscludiFlex = True
            CoperturaPersonaRenditaVitalizia.EscludiFlex = True
            SezioneFamiglia.EscludiFlex = True

            'aliquote
            SezionePersona.AliquotaImposta = AliquotaImpostaInfortuni
            SezioneFamiglia.AliquotaImposta = AliquotaImpostaInfortuni
            SezioneVeicolo.AliquotaImposta = AliquotaImpostaInfortuni
            SezioneMalattia.AliquotaImposta = AliquotaImpostaInfortuni
            SezioneAssistenza.AliquotaImposta = AliquotaImpostaAssistenza

            'sezione - coperture
            SezionePersona.AddCopertura(CoperturaPersonaBase)
            SezionePersona.AddCopertura(CoperturaPersonaMorte)
            SezionePersona.AddCopertura(CoperturaPersonaIP)
            SezionePersona.AddCopertura(CoperturaPersonaIT)
            SezionePersona.AddCopertura(CoperturaPersonaRicovero)
            SezionePersona.AddCopertura(CoperturaPersonaImmobilizzazione)
            SezionePersona.AddCopertura(CoperturaPersonaSpeseMediche)
            SezionePersona.AddCopertura(CoperturaPersonaRenditaVitalizia)
            'SezionePersona.AddCopertura(CoperturaPersonaITFranchigiaAssoluta)
            'SezionePersona.AddCopertura(CoperturaPersonaIPFranchigiaAssoluta)
            SezionePersona.AddCopertura(CoperturaPersonaFranchigiaRelativa)
            SezionePersona.AddCopertura(CoperturaPersonaFranchigiaDifferenziata)
            SezionePersona.AddCopertura(CoperturaPersonaFranchigia5)
            SezionePersona.AddCopertura(CoperturaPersonaFranchigia3)
            SezionePersona.AddCopertura(CoperturaPersonaIndennizzoVariabile)
            SezionePersona.AddCopertura(CoperturaPersonaTabellaINAIL)
            SezionePersona.AddCopertura(CoperturaPersonaTabellaUGFPLUS)
            SezionePersona.AddCopertura(CoperturaPersonaSpecifica)
            SezionePersona.AddCopertura(CoperturaPersonaMaggiorazione)
            SezionePersona.AddCopertura(CoperturaPersonaRischiDomestivi)
            SezionePersona.AddCopertura(CoperturaPersonaSportsAltoRischioMorte)
            SezionePersona.AddCopertura(CoperturaPersonaSportsAltoRischioIP)
            SezionePersona.AddCopertura(CoperturaPersonaSportsAltoRischioRicovero)
            SezionePersona.AddCopertura(CoperturaPersonaSportsAltoRischioSpeseMediche)
            SezionePersona.AddCopertura(CoperturaPersonaSportsMotoristiciMorte)
            SezionePersona.AddCopertura(CoperturaPersonaSportsMotoristiciIP)
            SezionePersona.AddCopertura(CoperturaPersonaSportsAereiMorte)
            SezionePersona.AddCopertura(CoperturaPersonaSportsAereiIP)
            SezionePersona.AddCopertura(CoperturaPersonaEsclusioneGuidaMotoveicoli)
            SezionePersona.AddCopertura(CoperturaPersonaEsclusioneSports)

            SezioneFamiglia.AddCopertura(CoperturaFamigliaBase)
            SezioneFamiglia.AddCopertura(CoperturaFamigliaMorte)
            SezioneFamiglia.AddCopertura(CoperturaFamigliaIP)
            SezioneFamiglia.AddCopertura(CoperturaFamigliaRicoveroConvalescenza)
            SezioneFamiglia.AddCopertura(CoperturaFamigliaImmobilizzazione)
            SezioneFamiglia.AddCopertura(CoperturaFamigliaSpeseMediche)
            SezioneFamiglia.AddCopertura(CoperturaFamigliaTabellaINAIL)
            SezioneFamiglia.AddCopertura(CoperturaFamigliaFranchigiaDifferenziata)
            SezioneFamiglia.AddCopertura(CoperturaFamigliaRischiDomestivi)
            SezioneVeicolo.AddCopertura(CoperturaVeicoloBase)
            SezioneVeicolo.AddCopertura(CoperturaVeicoloMorte)
            SezioneVeicolo.AddCopertura(CoperturaVeicoloIP)
            SezioneVeicolo.AddCopertura(CoperturaVeicoloRicovero)
            SezioneVeicolo.AddCopertura(CoperturaVeicoloImmobilizzazione)
            SezioneVeicolo.AddCopertura(CoperturaVeicoloSpeseMediche)
            SezioneVeicolo.AddCopertura(CoperturaVeicoloTabellaINAIL)
            SezioneVeicolo.AddCopertura(CoperturaVeicoloFranchigiaDifferenziata)
            SezioneVeicolo.AddCopertura(CoperturaVeicoloFranchigia5)
            SezioneVeicolo.AddCopertura(CoperturaVeicoloFranchigiaAssoluta)
            SezioneMalattia.AddCopertura(CoperturaMalattiaBase)
            SezioneMalattia.AddCopertura(CoperturaMalattiaInvaliditaPermanente)
            SezioneMalattia.AddCopertura(CoperturaMalattiaInabilitaTemporanea)
            SezioneMalattia.AddCopertura(CoperturaMalattiaRicovero)
            SezioneMalattia.AddCopertura(CoperturaMalattiaImmobilizzazione)
            SezioneAssistenza.AddCopertura(CoperturaAssistenzaBase)
        End Sub

        Public Overrides Sub Valida()
            ValidaCondizioniGenerali()
            ValidaSconti()
            ValidaSezionePersona()
            ValidaSezioneFamiglia()
            ValidaSezioneVeicolo()
            ValidaSezioneMalattia()
            ValidaSezioneAssistenza()
        End Sub

        Public Sub ValidaCondizioniGenerali()
            If AttivitaProfessionale = 0 Then AttivitaProfessionale = AttivitaProfessionaleEnum.Dipendente
            RischioProfessionale = CType(Decode, P01201DE).DecodeAttivitaToRischioProfessionale(TipoAttivita)
            If AssicuratoEta = 0 Then
                If Cliente.DataNascita.Year > 1900 Then
                    AssicuratoEta = Now.Year - Cliente.DataNascita.Year
                Else
                    AssicuratoEta = 40
                End If
            End If
        End Sub

        Public Sub ValidaSconti()
        End Sub


        Public Sub ValidaSezionePersona()
            If PersonaSceltaForma = 0 Then PersonaSceltaForma = PersonaSceltaFormaEnum.FullTimeFormulaFacile01
            Dim IsFormulaFacile = (PersonaSceltaForma >= PersonaSceltaFormaEnum.FullTimeFormulaFacile01 And PersonaSceltaForma <= PersonaSceltaFormaEnum.FullTimeFormulaFacile12)
            Dim IsCircolazione = (PersonaSceltaForma >= PersonaSceltaFormaEnum.Circolazione01 And PersonaSceltaForma <= PersonaSceltaFormaEnum.Circolazione12)
            Dim IsCombinazioni = IsFormulaFacile Or IsCircolazione

            Dim IsTempoLiberoLavoro = PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroExt _
                                   Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf _
                                   Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll _
                                   Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop

            Dim IsFullTime = PersonaSceltaForma = PersonaSceltaFormaEnum.FullTime _
                          Or PersonaSceltaForma = PersonaSceltaFormaEnum.FullTimeTop

            Dim IsTop = PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop _
                     Or PersonaSceltaForma = PersonaSceltaFormaEnum.FullTimeTop

            CoperturaPersonaBase.DipendeDa(True)
            SezionePersona.Stato = CoperturaPersonaBase.Stato

            If AttivitaProfessionale <> AttivitaProfessionaleEnum.Dipendente Then
                If PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroExt _
                Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf Then
                    PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll
                End If
            End If


            SezionePersona.EscludiFlex = IsCombinazioni

            If IsCombinazioni Then
                CoperturaPersonaMorte.ObbligatoriaDa(CoperturaPersonaBase.IsAttivo)
                CoperturaPersonaIP.ObbligatoriaDa(CoperturaPersonaBase.IsAttivo)
            Else
                CoperturaPersonaMorte.DipendeDa(CoperturaPersonaBase.IsAttivo)
                CoperturaPersonaIP.DipendeDa(CoperturaPersonaBase.IsAttivo)
            End If
            CoperturaPersonaIT.DipendeDa(CoperturaPersonaIP.IsAttivo And AttivitaProfessionale = AttivitaProfessionaleEnum.LiberoProfessionista And PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll And Cliente.IsPersonaFisica)
            'CoperturaPersonaITILimitata.DipendeDa(CoperturaPersonaIT.IsAttivo And Not IsCombinazioni)
            CoperturaPersonaRicovero.DipendeDa(CoperturaPersonaIP.IsAttivo And Not IsCombinazioni)
            'CoperturaPersonaConvalescenzaProlungata.DipendeDa(CoperturaPersonaRicovero.IsAttivo And PersonaRicoveroForma = PersonaRicoveroFormaEnum.PersonaRicoveroConvalescenza And Not IsCombinazioni)
            CoperturaPersonaImmobilizzazione.DipendeDa(CoperturaPersonaIP.IsAttivo)
            'CoperturaPersonaImmobilizzazioneProlungata.DipendeDa(CoperturaPersonaImmobilizzazione.IsAttivo And Not IsCombinazioni)
            CoperturaPersonaSpeseMediche.DipendeDa(CoperturaPersonaIP.IsAttivo)
            CoperturaPersonaRenditaVitalizia.DipendeDa((CoperturaPersonaIP.IsAttivo Or CoperturaPersonaMorte.IsAttivo) _
                                                       And (PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll _
                                                         Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop _
                                                         Or PersonaSceltaForma = PersonaSceltaFormaEnum.FullTime _
                                                         Or PersonaSceltaForma = PersonaSceltaFormaEnum.FullTimeTop))

            CoperturaPersonaFranchigiaRelativa.ObbligatoriaDa(CoperturaPersonaIP.IsAttivo And IsTop)
            CoperturaPersonaIndennizzoVariabile.DipendeDa(CoperturaPersonaIP.IsAttivo And IsFullTime And Not IsTop)
            CoperturaPersonaTabellaINAIL.DipendeDa(CoperturaPersonaIP.IsAttivo)
            'Andrea Consonni (26-11-14)
            'CoperturaPersonaFranchigiaDifferenziata.DipendeDa(CoperturaPersonaIP.IsAttivo And Not IsTop And PersonaSceltaForma <> PersonaSceltaFormaEnum.FullTime)
            CoperturaPersonaFranchigiaDifferenziata.DipendeDa(CoperturaPersonaIP.IsAttivo And Not IsTop)
            CoperturaPersonaFranchigia5.DipendeDa(CoperturaPersonaIP.IsAttivo And Not IsCombinazioni And Not IsTop)

            CoperturaPersonaSpecifica.DipendeDa(CoperturaPersonaIP.IsAttivo And (PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf _
                                                Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll))
            CoperturaPersonaMaggiorazione.DipendeDa(CoperturaPersonaIP.IsAttivo And IsTempoLiberoLavoro And Not IsTop)
            CoperturaPersonaTabellaUGFPLUS.DipendeDa(CoperturaPersonaIP.IsAttivo And IsTempoLiberoLavoro And Not IsTop)
            CoperturaPersonaFranchigia3.DipendeDa(CoperturaPersonaIP.IsAttivo And IsTempoLiberoLavoro And Not IsTop)
            CoperturaPersonaRischiDomestivi.DipendeDa(CoperturaPersonaIP.IsAttivo And IsCircolazione)

            CoperturaPersonaSportsAltoRischioMorte.DipendeDa(CoperturaPersonaIP.IsAttivo And Not IsCombinazioni And Cliente.IsPersonaFisica And PersonaSceltaForma <> PersonaSceltaFormaEnum.TempoLiberoLavoroPrf)
            CoperturaPersonaSportsAltoRischioIP.DipendeDa(CoperturaPersonaIP.IsAttivo And Not IsCombinazioni And Cliente.IsPersonaFisica And PersonaSceltaForma <> PersonaSceltaFormaEnum.TempoLiberoLavoroPrf)
            CoperturaPersonaSportsAltoRischioRicovero.DipendeDa(CoperturaPersonaIP.IsAttivo And Not IsCombinazioni And Cliente.IsPersonaFisica And PersonaSceltaForma <> PersonaSceltaFormaEnum.TempoLiberoLavoroPrf)
            CoperturaPersonaSportsAltoRischioSpeseMediche.DipendeDa(CoperturaPersonaIP.IsAttivo And Not IsCombinazioni And Cliente.IsPersonaFisica And PersonaSceltaForma <> PersonaSceltaFormaEnum.TempoLiberoLavoroPrf)
            CoperturaPersonaSportsMotoristiciMorte.DipendeDa(CoperturaPersonaIP.IsAttivo And Not IsCombinazioni And Cliente.IsPersonaFisica And PersonaSceltaForma <> PersonaSceltaFormaEnum.TempoLiberoLavoroPrf)
            CoperturaPersonaSportsMotoristiciIP.DipendeDa(CoperturaPersonaIP.IsAttivo And Not IsCombinazioni And Cliente.IsPersonaFisica And PersonaSceltaForma <> PersonaSceltaFormaEnum.TempoLiberoLavoroPrf)
            CoperturaPersonaSportsAereiMorte.DipendeDa(CoperturaPersonaIP.IsAttivo And Not IsCombinazioni And Cliente.IsPersonaFisica And PersonaSceltaForma <> PersonaSceltaFormaEnum.TempoLiberoLavoroPrf)
            CoperturaPersonaSportsAereiIP.DipendeDa(CoperturaPersonaIP.IsAttivo And Not IsCombinazioni And Cliente.IsPersonaFisica And PersonaSceltaForma <> PersonaSceltaFormaEnum.TempoLiberoLavoroPrf)

            If Not IsCombinazioni Then
                If PersonaSceltaForma <> PersonaSceltaFormaEnum.TempoLiberoLavoroAll _
                And PersonaSceltaForma <> PersonaSceltaFormaEnum.FullTime Then
                    CoperturaPersonaSportsAltoRischioMorte.SetRischioDirezione("RD")
                    CoperturaPersonaSportsAltoRischioIP.SetRischioDirezione("RD")
                    CoperturaPersonaSportsAltoRischioRicovero.SetRischioDirezione("RD")
                    CoperturaPersonaSportsAltoRischioSpeseMediche.SetRischioDirezione("RD")
                End If
                CoperturaPersonaSportsMotoristiciMorte.SetRischioDirezione("RD")
                CoperturaPersonaSportsMotoristiciIP.SetRischioDirezione("RD")
                CoperturaPersonaSportsAereiMorte.SetRischioDirezione("RD")
                CoperturaPersonaSportsAereiIP.SetRischioDirezione("RD")
            End If

            Dim CoperturaPersonaSports As Boolean = _
                CoperturaPersonaSportsAltoRischioMorte.IsAttivo _
                Or CoperturaPersonaSportsAltoRischioIP.IsAttivo _
                Or CoperturaPersonaSportsAltoRischioRicovero.IsAttivo _
                Or CoperturaPersonaSportsAltoRischioSpeseMediche.IsAttivo _
                Or CoperturaPersonaSportsMotoristiciMorte.IsAttivo _
                Or CoperturaPersonaSportsMotoristiciIP.IsAttivo _
                Or CoperturaPersonaSportsAereiMorte.IsAttivo _
                Or CoperturaPersonaSportsAereiIP.IsAttivo

            CoperturaPersonaEsclusioneGuidaMotoveicoli.DipendeDa(CoperturaPersonaIP.IsAttivo And Not IsCombinazioni And Not CoperturaPersonaSports And Not IsTop)
            CoperturaPersonaEsclusioneSports.DipendeDa(CoperturaPersonaIP.IsAttivo And Not IsCombinazioni And Not CoperturaPersonaSports And PersonaSceltaForma <> PersonaSceltaFormaEnum.TempoLiberoLavoroPrf And Not IsTop)

            If TipoAttivita = TipoAttivitaEnum.Attivita0 Then
                CoperturaPersonaBase.SetRischioDirezione("Attività non indicata")
            End If
            If RischioProfessionale = RischioProfessionaleEnum.ClasseRD Then
                CoperturaPersonaBase.SetRischioDirezione("Attività soggetta al benestare della direzione")
            End If

            If CoperturaPersonaMorte.IsAttivo Then
                If Not CoperturaPersonaRenditaVitalizia.IsAttivo _
                And Not CoperturaPersonaIP.IsAttivo Then
                    CoperturaPersonaBase.SetRischioDirezione("L'assicurazione del solo caso morte è riservata alla direzione")
                ElseIf CoperturaPersonaRenditaVitalizia.IsAttivo _
                And Not CoperturaPersonaIP.IsAttivo _
                And PartitaPersonaMorte.SommaAssicurata < 100000 Then
                    PartitaPersonaMorte.SommaAssicurata = 100000
                End If
            End If

            'If CoperturaPersonaITILimitata.IsAttivo Then
            '    CoperturaPersonaITFranchigiaAssoluta.Stato = StatoCopertura.Inapplicabile
            'ElseIf CoperturaPersonaITFranchigiaAssoluta.IsAttivo Then
            '    CoperturaPersonaITILimitata.Stato = StatoCopertura.Inapplicabile
            'End If
            If CoperturaPersonaFranchigiaDifferenziata.IsAttivo Then
                'CoperturaPersonaITFranchigiaAssoluta.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigiaRelativa.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigia5.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigia3.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaMaggiorazione.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaIndennizzoVariabile.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaTabellaUGFPLUS.Stato = StatoCopertura.Inapplicabile
            ElseIf CoperturaPersonaFranchigiaRelativa.IsAttivo Then
                'CoperturaPersonaITFranchigiaAssoluta.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigiaDifferenziata.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigia5.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigia3.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaTabellaUGFPLUS.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaIndennizzoVariabile.Stato = StatoCopertura.Inapplicabile
            ElseIf CoperturaPersonaFranchigia5.IsAttivo Then
                'CoperturaPersonaITFranchigiaAssoluta.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigiaRelativa.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigiaDifferenziata.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigia3.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaTabellaUGFPLUS.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaIndennizzoVariabile.Stato = StatoCopertura.Inapplicabile
            ElseIf CoperturaPersonaFranchigia3.IsAttivo Then
                'CoperturaPersonaITFranchigiaAssoluta.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigiaRelativa.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigiaDifferenziata.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigia5.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaTabellaUGFPLUS.Stato = StatoCopertura.Inapplicabile
            ElseIf CoperturaPersonaTabellaUGFPLUS.IsAttivo Then
                'CoperturaPersonaITFranchigiaAssoluta.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigiaRelativa.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigiaDifferenziata.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigia5.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigia3.Stato = StatoCopertura.Inapplicabile
                'CoperturaPersonaMaggiorazione.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigiaDifferenziata.Stato = StatoCopertura.Inapplicabile
            ElseIf CoperturaPersonaMaggiorazione.IsAttivo Then
                'CoperturaPersonaITFranchigiaAssoluta.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigiaRelativa.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigiaDifferenziata.Stato = StatoCopertura.Inapplicabile
            ElseIf CoperturaPersonaIndennizzoVariabile.IsAttivo Then
                CoperturaPersonaFranchigiaRelativa.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigiaDifferenziata.Stato = StatoCopertura.Inapplicabile
                CoperturaPersonaFranchigia5.Stato = StatoCopertura.Inapplicabile
            End If

            If PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf Then
                CoperturaPersonaSpecifica.SetRischioDirezione("La garanzia limitata al solo rischio professionale è riservata alla direzione")
            ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll Then
                If Not IsOneOf(TipoAttivita, 156, 199, 205, 284, 292, 295, 311, 323, 324, 328, 330, 331, 366, 378, 425, 465) Then
                    CoperturaPersonaSpecifica.SetRischioDirezione("La garanzia per la professione indicata è riservata alla direzione")
                End If
            End If

            'limiti assuntivi
            Dim coeffSoloMorte As Decimal = 1D

            If CoperturaPersonaMorte.IsAttivo And CoperturaPersonaRenditaVitalizia.IsAttivo And Not CoperturaPersonaIP.IsAttivo Then
                coeffSoloMorte = 2D
            End If

            If IsTop Then
                PartitaPersonaMorte.LimiteAssuntivoMassimo(1500000D)
            Else
                PartitaPersonaMorte.LimiteAssuntivoMassimo(1000000D)
            End If
            PartitaPersonaRicovero.LimiteAssuntivoMassimo(200D, coeffSoloMorte * 0.0005D * (CoperturaPersonaMorte.SommaAssicurataAttiva + CoperturaPersonaIP.SommaAssicurataAttiva))
            PartitaPersonaImmobilizzazione.LimiteAssuntivoMassimo(130D, coeffSoloMorte * 0.0003D * (CoperturaPersonaMorte.SommaAssicurataAttiva + CoperturaPersonaIP.SommaAssicurataAttiva))
            'PartitaPersonaRicoveroConvalescenza.LimiteAssuntivoMassimo(130D, coeffSoloMorte * 0.0003D * (CoperturaPersonaMorte.SommaAssicurataAttiva + CoperturaPersonaIP.SommaAssicurataAttiva))
            PartitaPersonaSpeseMediche.LimitiAssuntivi(5000D, Minimo(20000D, coeffSoloMorte * 0.1D * (CoperturaPersonaMorte.SommaAssicurataAttiva + CoperturaPersonaIP.SommaAssicurataAttiva)))
            PartitaPersonaSportsAltoRischioMorte.LimiteAssuntivoMassimo(250000D, 0.5D * CoperturaPersonaMorte.SommaAssicurataAttiva)
            PartitaPersonaSportsAltoRischioIP.LimiteAssuntivoMassimo(250000D, 0.5D * CoperturaPersonaIP.SommaAssicurataAttiva)
            PartitaPersonaSportsAltoRischioRicovero.LimiteAssuntivoMassimo(100D, 0.5D * CoperturaPersonaRicovero.SommaAssicurataAttiva)
            PartitaPersonaSportsAltoRischioSpeseMediche.LimiteAssuntivoMassimo(10000D, 0.5D * CoperturaPersonaSpeseMediche.SommaAssicurataAttiva)
            PartitaPersonaSportsMotoristiciMorte.LimiteAssuntivoMassimo(150000D, 0.3D * CoperturaPersonaMorte.SommaAssicurataAttiva)
            PartitaPersonaSportsMotoristiciIP.LimiteAssuntivoMassimo(150000D, 0.3D * CoperturaPersonaIP.SommaAssicurataAttiva)
            PartitaPersonaSportsAereiMorte.LimiteAssuntivoMassimo(150000D, 0.3D * CoperturaPersonaMorte.SommaAssicurataAttiva)
            PartitaPersonaSportsAereiIP.LimiteAssuntivoMassimo(150000D, 0.3D * CoperturaPersonaIP.SommaAssicurataAttiva)


            If IsTop Then
                If CoperturaPersonaRenditaVitalizia.IsAttivo Then
                    PartitaPersonaIP.LimiteAssuntivoMassimo(1000000D)
                Else
                    PartitaPersonaIP.LimiteAssuntivoMassimo(1500000D)
                End If

                'cumulativo
                If CoperturaPersonaIT.SommaAssicurataAttiva _
                 + CoperturaPersonaRicovero.SommaAssicurataAttiva _
                 + CoperturaPersonaImmobilizzazione.SommaAssicurataAttiva > 220D Then
                    CoperturaPersonaBase.SetNonDisponibile("indennità per Inabilità temporanea, ricovero e/o convalescenza, immobilizzazione > €220,00")
                End If

            ElseIf IsTempoLiberoLavoro Then
                If CoperturaPersonaSpecifica.IsAttivo Then
                    PartitaPersonaIP.LimiteAssuntivoMassimo(250000D)
                ElseIf CoperturaPersonaMaggiorazione.IsAttivo _
                And (CoperturaPersonaFranchigia3.IsAttivo _
                Or CoperturaPersonaFranchigia5.IsAttivo) Then
                    If CoperturaPersonaRenditaVitalizia.IsAttivo And AssicuratoEta < 51 Then
                        PartitaPersonaIP.LimiteAssuntivoMassimo(500000D)
                    Else
                        PartitaPersonaIP.LimiteAssuntivoMassimo(800000D)
                    End If
                ElseIf CoperturaPersonaFranchigiaDifferenziata.IsAttivo _
                Or CoperturaPersonaFranchigia3.IsAttivo _
                Or CoperturaPersonaFranchigia5.IsAttivo Then
                    If CoperturaPersonaRenditaVitalizia.IsAttivo And AssicuratoEta < 51 Then
                        PartitaPersonaIP.LimiteAssuntivoMassimo(800000D)
                    Else
                        PartitaPersonaIP.LimiteAssuntivoMassimo(1000000D)
                    End If
                ElseIf CoperturaPersonaMaggiorazione.IsAttivo Then
                    PartitaPersonaIP.LimiteAssuntivoMassimo(350000D)
                ElseIf CoperturaPersonaRenditaVitalizia.IsAttivo And AssicuratoEta < 51 Then
                    PartitaPersonaIP.LimiteAssuntivoMassimo(350000D)
                Else
                    PartitaPersonaIP.LimiteAssuntivoMassimo(500000D)
                End If


                If PersonaITForma = PersonaITFormaEnum.PersonaITParziale Then
                    PartitaPersonaIT.LimiteAssuntivoMassimo(Minimo(100D, coeffSoloMorte * 0.00025D * (CoperturaPersonaMorte.SommaAssicurataAttiva + CoperturaPersonaIP.SommaAssicurataAttiva)))
                ElseIf PersonaITForma = PersonaITFormaEnum.PersonaITIntegrale Then
                    PartitaPersonaIT.LimiteAssuntivoMassimo(Minimo(50D, coeffSoloMorte * 0.0002D * (CoperturaPersonaMorte.SommaAssicurataAttiva + CoperturaPersonaIP.SommaAssicurataAttiva)))
                ElseIf PersonaITForma = PersonaITFormaEnum.PersonaITRicovero Then
                    PartitaPersonaIT.LimiteAssuntivoMassimo(Minimo(130D, coeffSoloMorte * 0.00025D * (CoperturaPersonaMorte.SommaAssicurataAttiva + CoperturaPersonaIP.SommaAssicurataAttiva)))
                End If
                PartitaPersonaRicovero.LimiteAssuntivoMassimo(Minimo(200D, coeffSoloMorte * 0.0005D * (CoperturaPersonaMorte.SommaAssicurataAttiva + CoperturaPersonaIP.SommaAssicurataAttiva)))

                'cumulativo
                If CoperturaPersonaIT.SommaAssicurataAttiva _
                 + CoperturaPersonaRicovero.SommaAssicurataAttiva _
                 + CoperturaPersonaImmobilizzazione.SommaAssicurataAttiva > 220D Then
                    CoperturaPersonaBase.SetNonDisponibile("indennità per Inabilità temporanea, ricovero e/o convalescenza, immobilizzazione > €220,00")
                End If
            ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.FullTime Then
                'If CoperturaPersonaTabellaUGFPLUS.IsAttivo _
                'Or CoperturaPersonaFranchigiaDifferenziata.IsAttivo _
                'Or CoperturaPersonaFranchigia5.IsAttivo Then
                '    If CoperturaPersonaRenditaVitalizia.IsAttivo And AssicuratoEta < 51 Then
                '        PartitaPersonaIP.LimiteAssuntivoMassimo(800000D)
                '    Else
                '        PartitaPersonaIP.LimiteAssuntivoMassimo(1000000D)
                '    End If
                'End If

                If CoperturaPersonaIndennizzoVariabile.IsAttivo Then
                    If CoperturaPersonaRenditaVitalizia.IsAttivo And AssicuratoEta < 51 Then
                        PartitaPersonaIP.LimiteAssuntivoMassimo(350000D)
                    Else
                        PartitaPersonaIP.LimiteAssuntivoMassimo(500000D)
                    End If
                Else
                    If CoperturaPersonaRenditaVitalizia.IsAttivo And AssicuratoEta < 51 Then
                        PartitaPersonaIP.LimiteAssuntivoMassimo(800000D)
                    Else
                        PartitaPersonaIP.LimiteAssuntivoMassimo(1000000D)
                    End If
                End If
                PartitaPersonaRicovero.LimiteAssuntivoMassimo(Minimo(200D, coeffSoloMorte * 0.0005D * (CoperturaPersonaMorte.SommaAssicurataAttiva + CoperturaPersonaIP.SommaAssicurataAttiva)))

                'cumulativo
                If CoperturaPersonaRicovero.SommaAssicurataAttiva _
                 + CoperturaPersonaImmobilizzazione.SommaAssicurataAttiva > 200D Then
                    CoperturaPersonaBase.SetNonDisponibile("indennità per ricovero o per ricovero e convalescenza e per immobilizzazione > €200,00")
                End If
            End If




            If IsCombinazioni Then
                Dim scelta = 1 + PersonaSceltaForma - IIf(IsFormulaFacile, PersonaSceltaFormaEnum.FullTimeFormulaFacile01, PersonaSceltaFormaEnum.Circolazione01)
                CoperturaPersonaRicovero.ObbligatoriaDa(CoperturaPersonaBase.IsAttivo And Choose(scelta, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1))
                CoperturaPersonaImmobilizzazione.ObbligatoriaDa(CoperturaPersonaBase.IsAttivo And Choose(scelta, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1))
                CoperturaPersonaSpeseMediche.ObbligatoriaDa(CoperturaPersonaBase.IsAttivo And Choose(scelta, 0, 0, 1, 0, 0, 1, 0, 1, 1, 0, 0, 1))

                CoperturaPersonaMorte.Partita.SommaAssicurata = 1000D * Choose(scelta, 30D, 30D, 50D, 40D, 40D, 50D, 50D, 50D, 100D, 75D, 125D, 250D)
                CoperturaPersonaIP.Partita.SommaAssicurata = 1000D * Choose(scelta, 50D, 50D, 50D, 75D, 75D, 75D, 100D, 100D, 100D, 150D, 250D, 250D)
                CoperturaPersonaRicovero.Partita.SommaAssicurata = Choose(scelta, 0D, 20D, 25D, 0D, 25D, 35D, 0D, 40D, 50D, 0D, 75D, 100D)
                CoperturaPersonaImmobilizzazione.Partita.SommaAssicurata = Choose(scelta, 0D, 10D, 15D, 0D, 15D, 20D, 0D, 25D, 30D, 0D, 40D, 50D)
                CoperturaPersonaSpeseMediche.Partita.SommaAssicurata = Choose(scelta, 0D, 0D, 1500D, 0D, 0D, 2000D, 0D, 3000D, 5000D, 0D, 0D, 10000D)

                PersonaRicoveroForma = PersonaRicoveroFormaEnum.PersonaRicoveroConvalescenza
                PersonaImmobilizzazioneForma = PersonaImmobilizzazioneFormaEnum.PersonaImmobilizzazioneNormale

                If IsFormulaFacile Then
                    If CoperturaPersonaTabellaINAIL.IsAttivo And CoperturaPersonaFranchigiaDifferenziata.IsAttivo Then
                        CoperturaPersonaBase.Tariffa.Base = toBaseNetta(Choose(scelta, 126D, 149D, 191D, 183D, 214D, 259D, 239D, 330D, 403D, 356D, 679D, 895D), 2)
                    ElseIf CoperturaPersonaTabellaINAIL.IsAttivo Then
                        CoperturaPersonaBase.Tariffa.Base = toBaseNetta(Choose(scelta, 93D, 116D, 158D, 133D, 165D, 210D, 174D, 264D, 337D, 258D, 515D, 731D), 2)
                    ElseIf CoperturaPersonaFranchigiaDifferenziata.IsAttivo Then
                        CoperturaPersonaBase.Tariffa.Base = toBaseNetta(Choose(scelta, 109D, 133D, 175D, 158D, 189D, 234D, 206D, 297D, 370D, 307D, 597D, 813D), 2)
                    Else
                        CoperturaPersonaBase.Tariffa.Base = toBaseNetta(Choose(scelta, 82D, 105D, 147D, 116D, 148D, 193D, 151D, 242D, 315D, 224D, 458D, 675D), 2)
                    End If
                    CoperturaPersonaBase.Tariffa.Base -= toBaseNetta(5.5D, 2)
                    'CoperturaPersonaMorte.Tariffa.Base = Choose(scelta, 38D, 105D, 147D, 116D, 148D, 193D, 151D, 242D, 315D, 224D, 458D, 675D)
                    'CoperturaPersonaIP.Tariffa.Base = Choose(scelta, 37D, 105D, 147D, 116D, 148D, 193D, 151D, 242D, 315D, 0D, 458D, 675D)
                    'CoperturaPersonaRicoveroConvalescenza.Tariffa.Base = Choose(scelta, 0D, 105D, 147D, 0D, 148D, 193D, 0D, 242D, 315D, 0D, 458D, 675D)
                    'CoperturaPersonaImmobilizzazione.Tariffa.Base = Choose(scelta, 0D, 105D, 147D, 0D, 148D, 193D, 0D, 242D, 315D, 0D, 458D, 675D)
                    'CoperturaPersonaSpeseMediche.Tariffa.Base = Choose(scelta, 0D, 0D, 147D, 0D, 0D, 193D, 0D, 242D, 315D, 0D, 0D, 675D)
                Else
                    If CoperturaPersonaTabellaINAIL.IsAttivo And CoperturaPersonaFranchigiaDifferenziata.IsAttivo Then
                        CoperturaPersonaBase.Tariffa.Base = toBaseNetta(Choose(scelta, 62D, 80D, 105D, 90D, 115D, 139D, 118D, 174D, 219D, 177D, 366D, 495D), 2)
                    ElseIf CoperturaPersonaTabellaINAIL.IsAttivo Then
                        CoperturaPersonaBase.Tariffa.Base = toBaseNetta(Choose(scelta, 46D, 65D, 89D, 67D, 92D, 116D, 97D, 143D, 188D, 131D, 289D, 418D), 2)
                    ElseIf CoperturaPersonaFranchigiaDifferenziata.IsAttivo Then
                        CoperturaPersonaBase.Tariffa.Base = toBaseNetta(Choose(scelta, 54D, 73D, 97D, 78D, 103D, 128D, 103D, 159D, 204D, 154D, 328D, 456D), 2)
                    Else
                        CoperturaPersonaBase.Tariffa.Base = toBaseNetta(Choose(scelta, 41D, 60D, 84D, 59D, 84D, 109D, 77D, 133D, 178D, 116D, 263D, 392D), 2)
                    End If
                    CoperturaPersonaBase.Tariffa.Base -= toBaseNetta(4D, 2)
                    'CoperturaPersonaMorte.Tariffa.Base = Choose(scelta, 38D, 105D, 147D, 116D, 148D, 193D, 151D, 242D, 315D, 224D, 458D, 675D)
                    'CoperturaPersonaIP.Tariffa.Base = Choose(scelta, 37D, 105D, 147D, 116D, 148D, 193D, 151D, 242D, 315D, 0D, 458D, 675D)
                    'CoperturaPersonaRicoveroConvalescenza.Tariffa.Base = Choose(scelta, 0D, 105D, 147D, 0D, 148D, 193D, 0D, 242D, 315D, 0D, 458D, 675D)
                    'CoperturaPersonaImmobilizzazione.Tariffa.Base = Choose(scelta, 0D, 105D, 147D, 0D, 148D, 193D, 0D, 242D, 315D, 0D, 458D, 675D)
                    'CoperturaPersonaSpeseMediche.Tariffa.Base = Choose(scelta, 0D, 0D, 147D, 0D, 0D, 193D, 0D, 242D, 315D, 0D, 0D, 675D)
                    CoperturaPersonaRischiDomestivi.Tariffa.Tasso = 0.3D
                    PartitaPersonaRischiDomestivi.SommaAssicurata = CoperturaPersonaBase.PremioAttivoCrudo
                End If

                'CoperturaPersonaTabellaINAIL.Tariffa.Base = 11D
                'CoperturaPersonaFranchigiaDifferenziata.Tariffa.Base = 27D
                'CoperturaAssistenzaBase.Tariffa.Base = 7D
            Else
                With CoperturaPersonaMorte
                    If PersonaSceltaForma = PersonaSceltaFormaEnum.FullTime _
                    Or PersonaSceltaForma = PersonaSceltaFormaEnum.FullTimeTop Then
                        .Tariffa.Tasso = toBaseNetta(1.1D / 1000D)
                    ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll _
                        Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop Then
                        .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 0.9D, 1.2D, 1.85D, 2.35D) / 1000D)
                    ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf Then
                        .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 0.5D, 0.65D, 1.1D, 2.05D) / 1000D)
                    ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroExt Then
                        .Tariffa.Tasso = toBaseNetta(0.7D / 1000D)
                    End If
                    If .SommaAssicurataAttiva = CoperturaPersonaIP.SommaAssicurataAttiva Then
                        .Tariffa.Tasso *= 0.9D
                    End If
                End With

                With CoperturaPersonaIP
                    If PersonaSceltaForma = PersonaSceltaFormaEnum.FullTime Then
                        .Tariffa.Tasso = toBaseNetta(1.84D / 1000D)
                    ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.FullTimeTop Then
                        .Tariffa.Tasso = toBaseNetta(1.84D / 1000D)
                    ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll Then
                        .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 1.2D, 1.35D, 2D, 2.55D) / 1000D)
                    ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop Then
                        .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 1.2D, 1.35D, 2D, 2.55D) / 1000D)
                    ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf Then
                        .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 0.65D, 0.85D, 1.35D, 2.25D) / 1000D)
                    ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroExt Then
                        .Tariffa.Tasso = toBaseNetta(0.9D / 1000D)
                    End If
                End With


                With CoperturaPersonaIT
                    If PersonaITForma = PersonaITFormaEnum.PersonaITParziale Then
                        If PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf Then
                            .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 3.1D, 4.1D, 5.95D, 7.18D))
                        ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll _
                            Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop Then
                            .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 6.15D, 7.2D, 10.3D, 12.3D))
                        End If
                    Else
                        If PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf Then
                            .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 4.3D, 5.75D, 8.4D, 10.25D))
                        ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll _
                            Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop Then
                            .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 8.2D, 8.8D, 12.5D, 15.4D))
                        End If
                        'With CoperturaPersonaITILimitata
                        '    .Tariffa.Base = -0.5D * CoperturaPersonaIT.PremioAttivoCrudo
                        'End With
                        If PersonaITForma = PersonaITFormaEnum.PersonaITRicovero Then
                            .Tariffa.Tasso *= 0.5
                        End If
                    End If
                End With

                With CoperturaPersonaRicovero
                    If PersonaRicoveroForma = PersonaRicoveroFormaEnum.PersonaRicoveroSoloRicovero Then
                        If PersonaSceltaForma = PersonaSceltaFormaEnum.FullTime _
                        Or PersonaSceltaForma = PersonaSceltaFormaEnum.FullTimeTop Then
                            .Tariffa.Tasso = toBaseNetta(0.55D, 2)
                        ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf Then
                            .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 0.26D, 0.3D, 0.55D, 0.72D), 2)
                        ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll _
                            Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop Then
                            .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 0.45D, 0.55D, 0.8D, 1D), 2)
                        ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroExt Then
                            .Tariffa.Tasso = toBaseNetta(0.4D, 2)
                        End If
                    Else
                        If PersonaSceltaForma = PersonaSceltaFormaEnum.FullTime _
                        Or PersonaSceltaForma = PersonaSceltaFormaEnum.FullTimeTop Then
                            .Tariffa.Tasso = toBaseNetta(1.15D, 2)
                        ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf Then
                            .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 0.42D, 0.52D, 0.85D, 1.06D), 2)
                        ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll _
                            Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop Then
                            .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 0.65D, 0.8D, 1.2D, 1.45D), 2)
                        ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroExt Then
                            .Tariffa.Tasso = toBaseNetta(0.61D, 2)
                        End If

                        'With CoperturaPersonaConvalescenzaProlungata
                        '    .Tariffa.Base = 0.1D * CoperturaPersonaRicovero.PremioAttivoCrudo
                        'End With
                        If PersonaRicoveroForma = PersonaRicoveroFormaEnum.PersonaRicoveroConvalescenzaProlungata Then
                            .Tariffa.Tasso *= 1.1D
                        End If

                    End If
                End With


                With CoperturaPersonaImmobilizzazione
                    If PersonaSceltaForma = PersonaSceltaFormaEnum.FullTime _
                    Or PersonaSceltaForma = PersonaSceltaFormaEnum.FullTimeTop Then
                        .Tariffa.Tasso = toBaseNetta(1.5D, 2)
                    ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf Then
                        .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 0.75D, 1.04D, 1.42D, 1.75D), 2)
                    ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll _
                        Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop Then
                        .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 1.35D, 1.75D, 2.35D, 2.8D), 2)
                    ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroExt Then
                        .Tariffa.Tasso = toBaseNetta(1.18D, 2)
                    End If
                    'With CoperturaPersonaImmobilizzazioneProlungata
                    '    .Tariffa.Base = 0.1D * CoperturaPersonaImmobilizzazione.PremioAttivoCrudo
                    'End With
                    If PersonaImmobilizzazioneForma = PersonaImmobilizzazioneFormaEnum.PersonaImmobilizzazioneProlungata Then
                        .Tariffa.Tasso *= 1.1D
                    End If
                End With

                With CoperturaPersonaSpeseMediche
                    If .Partita.SommaAssicurata <= 10000D Then
                        If PersonaSceltaForma = PersonaSceltaFormaEnum.FullTime _
                        Or PersonaSceltaForma = PersonaSceltaFormaEnum.FullTimeTop Then
                            .Tariffa.Tasso = toBaseNetta(18.5D / 1000D)
                        ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf Then
                            .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 10D, 12.5D, 15.5D, 18.45D) / 1000D)
                        ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll _
                            Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop Then
                            .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 14D, 17D, 21.5D, 27D) / 1000D)
                        ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroExt Then
                            .Tariffa.Tasso = toBaseNetta(13.5D / 1000D)
                        End If
                    Else
                        If PersonaSceltaForma = PersonaSceltaFormaEnum.FullTime _
                        Or PersonaSceltaForma = PersonaSceltaFormaEnum.FullTimeTop Then
                            .Tariffa.Base = toBaseNetta(85D) '(18.5D - 10D) * 10000D / 1000D
                            .Tariffa.Tasso = toBaseNetta(10D / 1000D)
                        ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf Then
                            .Tariffa.Base = toBaseNetta(Choose(RischioProfessionale, 45D, 60D, 72.5D, 87.1D))
                            .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 5.5D, 6.5D, 8.25D, 9.74D) / 1000D)
                        ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll _
                            Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop Then
                            .Tariffa.Base = toBaseNetta(Choose(RischioProfessionale, 65D, 80D, 105D, 130D))
                            .Tariffa.Tasso = toBaseNetta(Choose(RischioProfessionale, 7.5D, 9D, 11D, 14D) / 1000D)
                        ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroExt Then
                            .Tariffa.Base = toBaseNetta(62.5D)
                            .Tariffa.Tasso = toBaseNetta(7.25D / 1000D)
                        End If
                    End If
                End With

                With CoperturaPersonaRenditaVitalizia
                    If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 15000D
                    If .Garanzia.Massimale = 15000D Then
                        If AssicuratoEta >= 32 And AssicuratoEta <= 35 Then
                            .Tariffa.Base = toBaseNetta(313D)
                        ElseIf AssicuratoEta >= 36 And AssicuratoEta <= 40 Then
                            .Tariffa.Base = toBaseNetta(297D)
                        ElseIf AssicuratoEta >= 41 And AssicuratoEta <= 45 Then
                            .Tariffa.Base = toBaseNetta(274D)
                        ElseIf AssicuratoEta >= 46 And AssicuratoEta <= 50 Then
                            .Tariffa.Base = toBaseNetta(250D)
                        ElseIf AssicuratoEta >= 51 And AssicuratoEta <= 55 Then
                            .Tariffa.Base = toBaseNetta(220D)
                        ElseIf AssicuratoEta >= 56 And AssicuratoEta <= 60 Then
                            .Tariffa.Base = toBaseNetta(189D)
                        ElseIf AssicuratoEta >= 61 And AssicuratoEta <= 65 Then
                            .Tariffa.Base = toBaseNetta(176D)
                        ElseIf AssicuratoEta >= 66 And AssicuratoEta <= 70 Then
                            .Tariffa.Base = toBaseNetta(152D)
                        ElseIf AssicuratoEta >= 71 And AssicuratoEta <= 72 Then
                            .Tariffa.Base = toBaseNetta(126D)
                        End If
                    ElseIf .Garanzia.Massimale = 30000D Then
                        If AssicuratoEta >= 32 And AssicuratoEta <= 35 Then
                            .Tariffa.Base = toBaseNetta(582D)
                        ElseIf AssicuratoEta >= 36 And AssicuratoEta <= 40 Then
                            .Tariffa.Base = toBaseNetta(552D)
                        ElseIf AssicuratoEta >= 41 And AssicuratoEta <= 45 Then
                            .Tariffa.Base = toBaseNetta(510D)
                        ElseIf AssicuratoEta >= 46 And AssicuratoEta <= 50 Then
                            .Tariffa.Base = toBaseNetta(466D)
                        ElseIf AssicuratoEta >= 51 And AssicuratoEta <= 55 Then
                            .Tariffa.Base = toBaseNetta(410D)
                        ElseIf AssicuratoEta >= 56 And AssicuratoEta <= 60 Then
                            .Tariffa.Base = toBaseNetta(352D)
                        ElseIf AssicuratoEta >= 61 And AssicuratoEta <= 65 Then
                            .Tariffa.Base = toBaseNetta(328D)
                        ElseIf AssicuratoEta >= 66 And AssicuratoEta <= 70 Then
                            .Tariffa.Base = toBaseNetta(282D)
                        ElseIf AssicuratoEta >= 71 And AssicuratoEta <= 72 Then
                            .Tariffa.Base = toBaseNetta(234D)
                        End If
                    End If
                End With

                'With CoperturaPersonaITFranchigiaAssoluta
                '    .SetRischioDirezione("Condizione particolare riservato direzione")
                'End With

                'With CoperturaPersonaIPFranchigiaAssoluta
                '    .SetRischioDirezione("Condizione particolare riservato direzione")
                'End With

                With CoperturaPersonaFranchigiaRelativa
                    If .Garanzia.Franchigia = 0D Then .Garanzia.Franchigia = 10D
                    .Partita.SommaAssicurata = CoperturaPersonaIP.SommaAssicurataAttiva
                    If PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop Then
                        If .Garanzia.Franchigia = 10D Then
                            .Tariffa.Tasso = -toBaseNetta(Choose(RischioProfessionale, 1.2D - 0.78D, 1.35D - 0.88D, 2D - 1.2D, 2.55D - 1.5D) / 1000D)
                        ElseIf .Garanzia.Franchigia = 30D Then
                            .Tariffa.Tasso = -toBaseNetta(Choose(RischioProfessionale, 1.2D - 0.4D, 1.35D - 0.45D, 2D - 0.55D, 2.55D - 0.7D) / 1000D)
                        End If
                    ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.FullTimeTop Then
                        If .Garanzia.Franchigia = 10D Then
                            .Tariffa.Tasso = toBaseNetta(1.1D / 1000D) - toBaseNetta(1.84D / 1000D)
                        ElseIf .Garanzia.Franchigia = 30D Then
                            .Tariffa.Tasso = toBaseNetta(0.5D / 1000D) - toBaseNetta(1.84D / 1000D)
                        End If
                    Else
                        .SetRischioDirezione("Condizione particolare riservato direzione")
                    End If
                End With

                With CoperturaPersonaIndennizzoVariabile
                    .Tariffa.Base = 0.35D * CoperturaPersonaIP.PremioAttivoCrudo
                End With

                With CoperturaPersonaFranchigiaDifferenziata
                    .Partita.SommaAssicurata = CoperturaPersonaIP.PremioAttivoCrudo
                    If PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll _
                    Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop _
                    Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf _
                    Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroExt Then
                        .Tariffa.Tasso = 0.6D
                    ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.FullTime Then
                        .Tariffa.Tasso = 0.35D
                    End If
                End With

                With CoperturaPersonaFranchigia5
                    .Partita.SommaAssicurata = CoperturaPersonaIP.PremioAttivoCrudo
                    If PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll _
                    Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf _
                    Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroExt Then
                        .Tariffa.Tasso = -0.2D
                    ElseIf PersonaSceltaForma = PersonaSceltaFormaEnum.FullTime Then
                        .Tariffa.Tasso = -0.35D
                    End If
                End With

                With CoperturaPersonaSpecifica
                    .Tariffa.Base = 0.5D * CoperturaPersonaIP.PremioAttivoCrudo
                End With

                With CoperturaPersonaMaggiorazione
                    .Tariffa.Base = 0.15D * CoperturaPersonaIP.PremioAttivoCrudo
                End With

                With CoperturaPersonaTabellaUGFPLUS
                    .Tariffa.Base = 0.25D * CoperturaPersonaIP.PremioAttivoCrudo
                End With

                With CoperturaPersonaFranchigia3
                    .Tariffa.Base = -0.1D * CoperturaPersonaIP.PremioAttivoCrudo
                End With

                With CoperturaPersonaEsclusioneGuidaMotoveicoli
                    .Tariffa.Base = -0.05D * (CoperturaPersonaMorte.PremioAttivoCrudo _
                                             + CoperturaPersonaIP.PremioAttivoCrudo _
                                             + CoperturaPersonaRicovero.PremioAttivoCrudo _
                                             + CoperturaPersonaImmobilizzazione.PremioAttivoCrudo _
                                             + CoperturaPersonaSpeseMediche.PremioAttivoCrudo _
                                             + CoperturaPersonaRenditaVitalizia.PremioAttivoCrudo)
                End With

                With CoperturaPersonaEsclusioneSports
                    .Tariffa.Base = -0.05D * (CoperturaPersonaMorte.PremioAttivoCrudo _
                                             + CoperturaPersonaIP.PremioAttivoCrudo _
                                             + CoperturaPersonaRicovero.PremioAttivoCrudo _
                                             + CoperturaPersonaImmobilizzazione.PremioAttivoCrudo _
                                             + CoperturaPersonaSpeseMediche.PremioAttivoCrudo _
                                             + CoperturaPersonaRenditaVitalizia.PremioAttivoCrudo)
                End With

                With CoperturaPersonaSportsAltoRischioMorte
                    .Tariffa.Tasso = toBaseNetta(1.1D / 1000D)
                    If .SommaAssicurataAttiva = CoperturaPersonaSportsAltoRischioIP.SommaAssicurataAttiva Then
                        .Tariffa.Tasso *= 0.9D
                    End If
                End With

                With CoperturaPersonaSportsAltoRischioIP
                    .Tariffa.Tasso = toBaseNetta(1.3D / 1000D)
                End With

                With CoperturaPersonaSportsAltoRischioRicovero
                    .Tariffa.Tasso = toBaseNetta(0.65D, 2)
                End With

                With CoperturaPersonaSportsAltoRischioSpeseMediche
                    .Tariffa.Tasso = toBaseNetta(22D / 1000D)
                End With

                With CoperturaPersonaSportsMotoristiciMorte
                    .Tariffa.Tasso = toBaseNetta(6.6D / 1000D)
                End With

                With CoperturaPersonaSportsMotoristiciIP
                    .Tariffa.Tasso = toBaseNetta(8.8D / 1000D)
                    If CoperturaPersonaSportsMotoristiciMorte.SommaAssicurataAttiva < CoperturaPersonaSportsMotoristiciIP.SommaAssicurataAttiva * 0.5D _
                        And AttivitaProfessionale <> AttivitaProfessionaleEnum.NoAttivitaProfessionale Then
                        .Tariffa.Tasso *= 1.2D
                    End If
                End With

                With CoperturaPersonaSportsAereiMorte
                    .Tariffa.Tasso = toBaseNetta(5.5D / 1000D)
                End With

                With CoperturaPersonaSportsAereiIP
                    .Tariffa.Tasso = toBaseNetta(6.6D / 1000D)
                    If CoperturaPersonaSportsAereiMorte.SommaAssicurataAttiva < CoperturaPersonaSportsAereiIP.SommaAssicurataAttiva * 0.5D _
                        And AttivitaProfessionale <> AttivitaProfessionaleEnum.NoAttivitaProfessionale Then
                        .Tariffa.Tasso *= 1.2D
                    End If
                End With


                CoperturaPersonaTabellaINAIL.Tariffa.Base = 0.25D * (CoperturaPersonaIP.PremioAttivoCrudo _
                                                                  + CoperturaPersonaSportsAltoRischioIP.PremioAttivoCrudo _
                                                                  + CoperturaPersonaSportsMotoristiciIP.PremioAttivoCrudo _
                                                                  + CoperturaPersonaSportsAereiIP.PremioAttivoCrudo _
                                                                  + CoperturaPersonaFranchigiaRelativa.PremioAttivoCrudo)

                If CoperturaPersonaMorte.SommaAssicurataAttiva < CoperturaPersonaIP.SommaAssicurataAttiva * 0.5D _
                    And AttivitaProfessionale <> AttivitaProfessionaleEnum.NoAttivitaProfessionale Then
                    CoperturaPersonaIP.Tariffa.Tasso *= 1.2D
                    CoperturaPersonaFranchigiaRelativa.Tariffa.Tasso *= 1.2D
                End If

                If CoperturaPersonaSportsAltoRischioMorte.SommaAssicurataAttiva < CoperturaPersonaSportsAltoRischioIP.SommaAssicurataAttiva * 0.5D _
                    And AttivitaProfessionale <> AttivitaProfessionaleEnum.NoAttivitaProfessionale Then
                    CoperturaPersonaSportsAltoRischioIP.Tariffa.Tasso *= 1.2D
                End If

            End If
        End Sub

        Public Sub ValidaSezioneFamiglia()
            If FamigliaSceltaForma = 0 Then FamigliaSceltaForma = FamigliaSceltaFormaEnum.FullTimeFormulaFacile11
            Dim IsFormulaFacile = (FamigliaSceltaForma >= FamigliaSceltaFormaEnum.FullTimeFormulaFacile11 And FamigliaSceltaForma <= FamigliaSceltaFormaEnum.FullTimeFormulaFacile22)
            Dim IsCircolazione = (FamigliaSceltaForma >= FamigliaSceltaFormaEnum.Circolazione01 And FamigliaSceltaForma <= FamigliaSceltaFormaEnum.Circolazione12)

            CoperturaFamigliaBase.DipendeDa(Cliente.IsPersonaFisica)
            SezioneFamiglia.Stato = CoperturaFamigliaBase.Stato

            CoperturaFamigliaMorte.ObbligatoriaDa(CoperturaFamigliaBase.IsAttivo)
            CoperturaFamigliaIP.ObbligatoriaDa(CoperturaFamigliaBase.IsAttivo)

            CoperturaFamigliaTabellaINAIL.DipendeDa(CoperturaFamigliaBase.IsAttivo)
            CoperturaFamigliaFranchigiaDifferenziata.DipendeDa(CoperturaFamigliaBase.IsAttivo)
            CoperturaFamigliaRischiDomestivi.DipendeDa(IsCircolazione And CoperturaFamigliaBase.IsAttivo)


            Dim scelta = 1 + FamigliaSceltaForma - IIf(IsFormulaFacile, FamigliaSceltaFormaEnum.FullTimeFormulaFacile11, FamigliaSceltaFormaEnum.Circolazione01)

            CoperturaFamigliaRicoveroConvalescenza.ObbligatoriaDa(CoperturaFamigliaBase.IsAttivo And Choose(scelta, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1))
            CoperturaFamigliaImmobilizzazione.ObbligatoriaDa(CoperturaFamigliaBase.IsAttivo And Choose(scelta, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1))
            CoperturaFamigliaSpeseMediche.ObbligatoriaDa(CoperturaFamigliaBase.IsAttivo And Choose(scelta, 0, 0, 1, 0, 0, 1, 0, 1, 1, 0, 0, 1))

            CoperturaFamigliaMorte.Partita.SommaAssicurata = 1000D * Choose(scelta, 30D, 30D, 50D, 40D, 40D, 50D, 50D, 50D, 100D, 75D, 125D, 250D)
            CoperturaFamigliaIP.Partita.SommaAssicurata = 1000D * Choose(scelta, 50D, 50D, 50D, 75D, 75D, 75D, 100D, 100D, 100D, 150D, 250D, 250D)
            CoperturaFamigliaRicoveroConvalescenza.Partita.SommaAssicurata = Choose(scelta, 0D, 20D, 25D, 0D, 25D, 35D, 0D, 40D, 50D, 0D, 75D, 100D)
            CoperturaFamigliaImmobilizzazione.Partita.SommaAssicurata = Choose(scelta, 0D, 10D, 15D, 0D, 15D, 20D, 0D, 25D, 30D, 0D, 40D, 50D)
            CoperturaFamigliaSpeseMediche.Partita.SommaAssicurata = Choose(scelta, 0D, 0D, 1500D, 0D, 0D, 2000D, 0D, 3000D, 5000D, 0D, 0D, 10000D)

            If IsFormulaFacile Then
                If CoperturaFamigliaTabellaINAIL.IsAttivo And CoperturaFamigliaFranchigiaDifferenziata.IsAttivo Then
                    CoperturaFamigliaBase.Tariffa.Base = toBaseNetta2(Choose(scelta, 142D, 170D, 221D, 207D, 244D, 299D, 271D, 381D, 470D, 404D, 776D, 1039D) - 5.5D)
                ElseIf CoperturaFamigliaTabellaINAIL.IsAttivo Then
                    CoperturaFamigliaBase.Tariffa.Base = toBaseNetta2(Choose(scelta, 111D, 139D, 190D, 159D, 197D, 252D, 207D, 318D, 407D, 308D, 618D, 880D) - 5.5D)
                ElseIf CoperturaFamigliaFranchigiaDifferenziata.IsAttivo Then
                    CoperturaFamigliaBase.Tariffa.Base = toBaseNetta2(Choose(scelta, 124D, 152D, 203D, 179D, 217D, 272D, 234D, 344D, 433D, 348D, 684D, 947D) - 5.5D)
                Else
                    CoperturaFamigliaBase.Tariffa.Base = toBaseNetta2(Choose(scelta, 97D, 125D, 176D, 139D, 177D, 232D, 181D, 291D, 380D, 268D, 551D, 814D) - 5.5D)
                End If
                'CoperturaFamigliaBase.Tariffa.Base -= toBaseNetta10(5.5)
            Else
                If CoperturaFamigliaTabellaINAIL.IsAttivo And CoperturaFamigliaFranchigiaDifferenziata.IsAttivo Then
                    CoperturaFamigliaBase.Tariffa.Base = toBaseNetta2(Choose(scelta, 71D, 92D, 120D, 103D, 132D, 161D, 135D, 201D, 253D, 202D, 420D, 569D) - 4D)
                ElseIf CoperturaFamigliaTabellaINAIL.IsAttivo Then
                    CoperturaFamigliaBase.Tariffa.Base = toBaseNetta2(Choose(scelta, 53D, 74D, 103D, 76D, 105D, 134D, 99D, 165D, 217D, 149D, 330D, 479D) - 4D)
                ElseIf CoperturaFamigliaFranchigiaDifferenziata.IsAttivo Then
                    CoperturaFamigliaBase.Tariffa.Base = toBaseNetta2(Choose(scelta, 62D, 83D, 112D, 90D, 119D, 148D, 118D, 183D, 236D, 176D, 376D, 526D) - 4D)
                Else
                    CoperturaFamigliaBase.Tariffa.Base = toBaseNetta2(Choose(scelta, 47D, 69D, 97D, 67D, 96D, 125D, 88D, 154D, 206D, 132D, 302D, 451D) - 4D)
                End If
                'CoperturaFamigliaBase.Tariffa.Base -= toBaseNetta10(4D)
            End If

            CoperturaFamigliaRischiDomestivi.Partita.SommaAssicurata = CoperturaFamigliaBase.PremioAttivoCrudo
            CoperturaFamigliaRischiDomestivi.Tariffa.Tasso = IIf(IsCircolazione, 0.3D, 0D)
        End Sub

        Public Sub ValidaSezioneVeicolo()
            If TipologiaVeicolo = 0 Then TipologiaVeicolo = TipologiaVeicoloEnum.Autovetture
            If Cliente.IsPersonaGiudirica Then
                VeicoloSceltaForma = VeicoloSceltaFormaEnum.CapitaliLiberi
            ElseIf VeicoloSceltaForma = 0 Then
                VeicoloSceltaForma = VeicoloSceltaFormaEnum.Circolazione01
            End If
            Dim IsCircolazione = (VeicoloSceltaForma >= VeicoloSceltaFormaEnum.Circolazione01 And VeicoloSceltaForma <= VeicoloSceltaFormaEnum.Circolazione12)

            CoperturaVeicoloBase.DipendeDa(True)
            SezioneVeicolo.Stato = CoperturaVeicoloBase.Stato

            SezioneVeicolo.EscludiFlex = IsCircolazione

            If IsCircolazione Then
                CoperturaVeicoloMorte.ObbligatoriaDa(CoperturaVeicoloBase.IsAttivo)
                CoperturaVeicoloIP.ObbligatoriaDa(CoperturaVeicoloBase.IsAttivo)
            Else
                CoperturaVeicoloMorte.DipendeDa(CoperturaVeicoloBase.IsAttivo)
                CoperturaVeicoloIP.DipendeDa(CoperturaVeicoloBase.IsAttivo)
            End If
            CoperturaVeicoloTabellaINAIL.DipendeDa(CoperturaVeicoloIP.IsAttivo)
            CoperturaVeicoloFranchigiaDifferenziata.DipendeDa(CoperturaVeicoloIP.IsAttivo And Not CoperturaVeicoloFranchigia5.IsAttivo And Not CoperturaVeicoloFranchigiaAssoluta.IsAttivo)
            CoperturaVeicoloFranchigia5.DipendeDa(CoperturaVeicoloIP.IsAttivo And Not IsCircolazione And Not CoperturaVeicoloFranchigiaDifferenziata.IsAttivo And Not CoperturaVeicoloFranchigiaAssoluta.IsAttivo)
            CoperturaVeicoloFranchigiaAssoluta.DipendeDa(CoperturaVeicoloIP.IsAttivo And Not IsCircolazione And Not CoperturaVeicoloFranchigia5.IsAttivo And Not CoperturaVeicoloFranchigiaDifferenziata.IsAttivo)

            If IsCircolazione Then
                Dim scelta = 1 + VeicoloSceltaForma - VeicoloSceltaFormaEnum.Circolazione01
                CoperturaVeicoloRicovero.ObbligatoriaDa(CoperturaVeicoloBase.IsAttivo And Choose(scelta, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1))
                CoperturaVeicoloImmobilizzazione.ObbligatoriaDa(CoperturaVeicoloBase.IsAttivo And Choose(scelta, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1))
                CoperturaVeicoloSpeseMediche.ObbligatoriaDa(CoperturaVeicoloBase.IsAttivo And Choose(scelta, 0, 0, 1, 0, 0, 1, 0, 1, 1, 0, 0, 1))

                VeicoloRicoveroForma = VeicoloRicoveroFormaEnum.VeicoloRicoveroConvalescenza

                CoperturaVeicoloMorte.Partita.SommaAssicurata = 1000D * Choose(scelta, 30D, 30D, 50D, 40D, 40D, 50D, 50D, 50D, 100D, 75D, 125D, 250D)
                CoperturaVeicoloIP.Partita.SommaAssicurata = 1000D * Choose(scelta, 50D, 50D, 50D, 75D, 75D, 75D, 100D, 100D, 100D, 150D, 250D, 250D)
                CoperturaVeicoloRicovero.Partita.SommaAssicurata = Choose(scelta, 0D, 20D, 25D, 0D, 25D, 35D, 0D, 40D, 50D, 0D, 75D, 100D)
                CoperturaVeicoloImmobilizzazione.Partita.SommaAssicurata = Choose(scelta, 0D, 10D, 15D, 0D, 15D, 20D, 0D, 25D, 30D, 0D, 40D, 50D)
                CoperturaVeicoloSpeseMediche.Partita.SommaAssicurata = Choose(scelta, 0D, 0D, 1500D, 0D, 0D, 2000D, 0D, 3000D, 5000D, 0D, 0D, 10000D)

                If CoperturaVeicoloTabellaINAIL.IsAttivo And CoperturaVeicoloFranchigiaDifferenziata.IsAttivo Then
                    CoperturaVeicoloBase.Tariffa.Base = toBaseNetta2(Choose(scelta, 62D, 80D, 105D, 90D, 115D, 139D, 118D, 174D, 219D, 177D, 366D, 495D) - 4D)
                ElseIf CoperturaVeicoloTabellaINAIL.IsAttivo Then
                    CoperturaVeicoloBase.Tariffa.Base = toBaseNetta2(Choose(scelta, 46D, 65D, 89D, 67D, 92D, 116D, 87D, 143D, 188D, 131D, 289D, 418D) - 4D)
                ElseIf CoperturaVeicoloFranchigiaDifferenziata.IsAttivo Then
                    CoperturaVeicoloBase.Tariffa.Base = toBaseNetta2(Choose(scelta, 54D, 73D, 97D, 78D, 103D, 128D, 103D, 159D, 204D, 154D, 328D, 456D) - 4D)
                Else
                    CoperturaVeicoloBase.Tariffa.Base = toBaseNetta2(Choose(scelta, 41D, 60D, 84D, 59D, 84D, 109D, 77D, 133D, 178D, 116D, 263D, 392D) - 4D)
                End If
                'CoperturaVeicoloBase.Tariffa.Base -= 4D
            Else
                CoperturaVeicoloRicovero.DipendeDa(CoperturaVeicoloIP.IsAttivo)
                CoperturaVeicoloImmobilizzazione.DipendeDa(CoperturaVeicoloIP.IsAttivo)
                CoperturaVeicoloSpeseMediche.DipendeDa(CoperturaVeicoloIP.IsAttivo)

                If TipologiaVeicolo = TipologiaVeicoloEnum.Autovetture Or TipologiaVeicolo = TipologiaVeicoloEnum.AutoMotocarri Then
                    PartitaVeicoloMorte.LimiteAssuntivoMassimo(450000D)
                    If CoperturaVeicoloFranchigia5.IsAttivo Or CoperturaVeicoloFranchigiaDifferenziata.IsAttivo Then
                        PartitaVeicoloIP.LimiteAssuntivoMassimo(450000D)
                    Else
                        PartitaVeicoloIP.LimiteAssuntivoMassimo(300000D)
                    End If
                    PartitaVeicoloRicovero.LimiteAssuntivoMassimo(200D)
                    PartitaVeicoloImmobilizzazione.LimiteAssuntivoMassimo(130D)
                    PartitaVeicoloSpeseMediche.LimitiAssuntivi(5000D, 20000D)
                Else
                    PartitaVeicoloMorte.LimiteAssuntivoMassimo(150000D)
                    PartitaVeicoloIP.LimiteAssuntivoMassimo(150000D)
                    PartitaVeicoloRicovero.LimiteAssuntivoMassimo(150D)
                    PartitaVeicoloImmobilizzazione.LimiteAssuntivoMassimo(100D)
                    PartitaVeicoloSpeseMediche.LimitiAssuntivi(5000D, 10000D)
                End If

                'cumulativo
                If CoperturaVeicoloRicovero.SommaAssicurataAttiva _
                 + CoperturaVeicoloImmobilizzazione.SommaAssicurataAttiva > 200D Then
                    CoperturaVeicoloBase.SetNonDisponibile("indennità per ricovero e/o convalescenza + immobilizzazione > €200,00")
                End If


                CoperturaVeicoloMorte.Tariffa.Tasso = toBaseNetta(IIf(TipologiaVeicolo = TipologiaVeicoloEnum.Autovetture, 0.6D, 0.85D) / 1000D)
                CoperturaVeicoloIP.Tariffa.Tasso = toBaseNetta(IIf(TipologiaVeicolo = TipologiaVeicoloEnum.Autovetture, 0.6D, 0.85D) / 1000D)
                CoperturaVeicoloImmobilizzazione.Tariffa.Tasso = toBaseNetta2(IIf(TipologiaVeicolo = TipologiaVeicoloEnum.Autovetture, 0.8D, 1.05D))

                If VeicoloRicoveroForma = VeicoloRicoveroFormaEnum.VeicoloRicoveroSoloRicovero Then
                    CoperturaVeicoloRicovero.Tariffa.Tasso = toBaseNetta2(IIf(TipologiaVeicolo = TipologiaVeicoloEnum.Autovetture, 0.3D, 0.4D))
                Else
                    CoperturaVeicoloRicovero.Tariffa.Tasso = toBaseNetta2(IIf(TipologiaVeicolo = TipologiaVeicoloEnum.Autovetture, 0.65D, 1D))
                End If

                With CoperturaVeicoloSpeseMediche
                    If .Partita.SommaAssicurata <= 10000D Then
                        .Tariffa.Tasso = toBaseNetta(IIf(TipologiaVeicolo = TipologiaVeicoloEnum.Autovetture, 5.5D, 8.8D) / 1000D)
                    ElseIf TipologiaVeicolo = TipologiaVeicoloEnum.Autovetture Then
                        .Tariffa.Base = toBaseNetta2(5.5D - 4D) * 10000D / 1000D
                        .Tariffa.Tasso = toBaseNetta(4D / 1000D)
                    Else
                        .Tariffa.Base = toBaseNetta2(8.8D - 5.5D) * 10000D / 1000D
                        .Tariffa.Tasso = toBaseNetta(5.5D / 1000D)
                    End If
                End With

                With CoperturaVeicoloTabellaINAIL
                    .Partita.SommaAssicurata = CoperturaVeicoloIP.PremioAttivoCrudo
                    .Tariffa.Tasso = 0.2D
                End With

                With CoperturaVeicoloFranchigiaDifferenziata
                    .Partita.SommaAssicurata = CoperturaVeicoloIP.PremioAttivoCrudo
                    .Tariffa.Tasso = 0.5D
                End With

                With CoperturaVeicoloFranchigia5
                    .Partita.SommaAssicurata = CoperturaVeicoloIP.PremioAttivoCrudo
                    .Tariffa.Tasso = -0.2D
                End With

                If CoperturaVeicoloMorte.SommaAssicurataAttiva = CoperturaVeicoloIP.SommaAssicurataAttiva Then
                    CoperturaVeicoloMorte.Tariffa.Tasso *= 0.9D
                ElseIf CoperturaVeicoloMorte.SommaAssicurataAttiva < CoperturaVeicoloIP.SommaAssicurataAttiva * 0.5D Then
                    CoperturaVeicoloIP.Tariffa.Tasso *= 1.2D
                End If


                With CoperturaVeicoloFranchigiaAssoluta
                    .SetRischioDirezione("Condizione soggetta al benestare della direzione")
                End With
            End If
        End Sub

        Public Sub ValidaSezioneMalattia()
            If Cliente.IsPersonaGiudirica Then
                CoperturaMalattiaBase.Stato = StatoCopertura.Inapplicabile
            Else
                CoperturaMalattiaBase.DipendeDa(PersonaSceltaForma = PersonaSceltaFormaEnum.FullTime _
                                             Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll)
            End If

            If MalattiaITSceltaForma = 0 Then MalattiaITSceltaForma = MalattiaITSceltaFormaEnum.RicoveroConvalescenza

            If PersonaRicoveroFormaEnum.PersonaRicoveroSoloRicovero Then
                MalattiaRicoveroSceltaForma = MalattiaRicoveroSceltaFormaEnum.SoloRicovero
            Else
                MalattiaRicoveroSceltaForma = MalattiaRicoveroSceltaFormaEnum.RicoveroConvalescenza
            End If

            SezioneMalattia.Stato = CoperturaMalattiaBase.Stato

            CoperturaMalattiaInvaliditaPermanente.DipendeDa(CoperturaMalattiaBase.IsAttivo And CoperturaPersonaIP.IsAttivo)
            CoperturaMalattiaInabilitaTemporanea.DipendeDa(CoperturaMalattiaBase.IsAttivo And (CoperturaPersonaIT.IsAttivo))
            CoperturaMalattiaRicovero.DipendeDa(CoperturaMalattiaBase.IsAttivo And CoperturaPersonaRicovero.IsAttivo)
            CoperturaMalattiaImmobilizzazione.DipendeDa(CoperturaMalattiaBase.IsAttivo And CoperturaPersonaImmobilizzazione.IsAttivo)

            If Not CoperturaMalattiaInvaliditaPermanente.IsAttivo Then
                CoperturaMalattiaInvaliditaPermanente.Partita.SommaAssicurata = CoperturaPersonaIP.Partita.SommaAssicurata
            End If

            PartitaMalattiaInvaliditaPermanente.LimiteAssuntivoMassimo(PartitaPersonaIP.SommaAssicurata, 250000D)
            If MalattiaITSceltaForma = MalattiaITSceltaFormaEnum.RicoveroConvalescenza Then
                PartitaMalattiaInabilitaTemporanea.LimiteAssuntivoMassimo(PartitaPersonaIT.SommaAssicurata, 130D)
            Else
                PartitaMalattiaInabilitaTemporanea.LimiteAssuntivoMassimo(PartitaPersonaIT.SommaAssicurata, 50D)
            End If

            PartitaMalattiaRicovero.LimiteAssuntivoMassimo(PartitaPersonaRicovero.SommaAssicurata, 200D)
            PartitaMalattiaImmobilizzazione.LimiteAssuntivoMassimo(PartitaPersonaImmobilizzazione.SommaAssicurata, 130D)

            'cumulativo
            If CoperturaMalattiaInabilitaTemporanea.SommaAssicurataAttiva _
             + CoperturaMalattiaImmobilizzazione.SommaAssicurataAttiva _
             + CoperturaMalattiaRicovero.SommaAssicurataAttiva > 220D Then
                CoperturaMalattiaBase.SetNonDisponibile("indennità per inabilità temporanea + ricovero e/o convalescenza + immobilizzazione > €220,00")
            End If

            With CoperturaMalattiaInvaliditaPermanente
                If AssicuratoEta >= 0 And AssicuratoEta <= 15 Then
                    .Tariffa.Tasso = toBaseNetta(0.4D / 1000D)
                ElseIf AssicuratoEta >= 16 And AssicuratoEta <= 20 Then
                    .Tariffa.Tasso = toBaseNetta(0.65D / 1000D)
                ElseIf AssicuratoEta >= 21 And AssicuratoEta <= 27 Then
                    .Tariffa.Tasso = toBaseNetta(1D / 1000D)
                ElseIf AssicuratoEta >= 28 And AssicuratoEta <= 35 Then
                    .Tariffa.Tasso = toBaseNetta(1.31D / 1000D)
                ElseIf AssicuratoEta >= 36 And AssicuratoEta <= 40 Then
                    .Tariffa.Tasso = toBaseNetta(2.15D / 1000D)
                ElseIf AssicuratoEta >= 41 And AssicuratoEta <= 45 Then
                    .Tariffa.Tasso = toBaseNetta(2.15D / 1000D)
                ElseIf AssicuratoEta >= 46 And AssicuratoEta <= 50 Then
                    .Tariffa.Tasso = toBaseNetta(3.13D / 1000D)
                ElseIf AssicuratoEta >= 51 And AssicuratoEta <= 54 Then
                    .Tariffa.Tasso = toBaseNetta(3.5D / 1000D)
                End If
            End With

            With CoperturaMalattiaInabilitaTemporanea
                If AssicuratoEta >= 18 And AssicuratoEta <= 45 Then
                    .Tariffa.Tasso = toBaseNetta2(Choose(MalattiaITSceltaForma, 8.2D, 11.7D))
                ElseIf AssicuratoEta >= 46 And AssicuratoEta <= 60 Then
                    .Tariffa.Tasso = toBaseNetta2(Choose(MalattiaITSceltaForma, 10.25D, 14.7D))
                ElseIf AssicuratoEta >= 61 And AssicuratoEta <= 65 Then
                    .Tariffa.Tasso = toBaseNetta2(Choose(MalattiaITSceltaForma, 13.5D, 19.1D))
                End If
            End With

            With CoperturaMalattiaRicovero
                If AssicuratoEta >= 0 And AssicuratoEta <= 17 Then
                    .Tariffa.Tasso = toBaseNetta2(Choose(MalattiaRicoveroSceltaForma, 0.85D, 1.45D))
                ElseIf AssicuratoEta >= 18 And AssicuratoEta <= 45 Then
                    .Tariffa.Tasso = toBaseNetta2(Choose(MalattiaRicoveroSceltaForma, 1.7D, 2.9D))
                ElseIf AssicuratoEta >= 46 And AssicuratoEta <= 60 Then
                    .Tariffa.Tasso = toBaseNetta2(Choose(MalattiaRicoveroSceltaForma, 2.8D, 4.75D))
                ElseIf AssicuratoEta >= 61 And AssicuratoEta <= 65 Then
                    .Tariffa.Tasso = toBaseNetta2(Choose(MalattiaRicoveroSceltaForma, 3.8D, 6.5D))
                ElseIf AssicuratoEta >= 66 And AssicuratoEta <= 70 Then
                    .Tariffa.Tasso = toBaseNetta2(Choose(MalattiaRicoveroSceltaForma, 4.6D, 7.8D))
                ElseIf AssicuratoEta >= 71 And AssicuratoEta <= 75 Then
                    .Tariffa.Tasso = toBaseNetta2(Choose(MalattiaRicoveroSceltaForma, 6D, 10.2D))
                End If
            End With

            With CoperturaMalattiaImmobilizzazione
                If AssicuratoEta >= 0 And AssicuratoEta <= 17 Then
                    .Tariffa.Tasso = toBaseNetta2(1.7D)
                ElseIf AssicuratoEta >= 18 And AssicuratoEta <= 45 Then
                    .Tariffa.Tasso = toBaseNetta2(3.4D)
                ElseIf AssicuratoEta >= 46 And AssicuratoEta <= 60 Then
                    .Tariffa.Tasso = toBaseNetta2(5.6D)
                ElseIf AssicuratoEta >= 61 And AssicuratoEta <= 65 Then
                    .Tariffa.Tasso = toBaseNetta2(7.6D)
                ElseIf AssicuratoEta >= 66 And AssicuratoEta <= 70 Then
                    .Tariffa.Tasso = toBaseNetta2(9.2D)
                ElseIf AssicuratoEta >= 71 And AssicuratoEta <= 75 Then
                    .Tariffa.Tasso = toBaseNetta2(12D)
                End If
            End With
        End Sub

        Public Sub ValidaSezioneAssistenza()

            If Cliente.IsPersonaGiudirica Then
                CoperturaAssistenzaBase.Stato = StatoCopertura.Inapplicabile
            Else
                '16-03-2015: preventivo sai senza assistenza
                CoperturaAssistenzaBase.DipendeDa(SezionePersona.IsAttivo _
                                                    Or SezioneFamiglia.IsAttivo _
                                                    Or SezioneVeicolo.IsAttivo)
            End If
            SezioneAssistenza.Stato = CoperturaAssistenzaBase.Stato

            If SezionePersona.IsAttivo Then
                If PersonaSceltaForma = PersonaSceltaFormaEnum.FullTime _
                Or PersonaSceltaForma = PersonaSceltaFormaEnum.FullTimeTop _
                Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroPrf _
                Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroExt _
                Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroAll _
                Or PersonaSceltaForma = PersonaSceltaFormaEnum.TempoLiberoLavoroTop Then
                    If CoperturaPersonaIT.IsAttivo _
                    Or CoperturaPersonaRicovero.IsAttivo _
                    Or CoperturaPersonaImmobilizzazione.IsAttivo _
                    Or CoperturaPersonaSpeseMediche.IsAttivo _
                    Or CoperturaPersonaRenditaVitalizia.IsAttivo _
                    Or CoperturaMalattiaImmobilizzazione.IsAttivo _
                    Or CoperturaMalattiaInabilitaTemporanea.IsAttivo _
                    Or CoperturaMalattiaInvaliditaPermanente.IsAttivo _
                    Or CoperturaMalattiaRicovero.IsAttivo _
                    Then
                        AssistenzaPacchetto = AssistenzaPacchettoEnum.PacchettoTop
                    ElseIf AssistenzaPacchetto <> AssistenzaPacchettoEnum.PacchettoTop _
                    And AssistenzaPacchetto <> AssistenzaPacchettoEnum.PacchettoCompleto Then
                        AssistenzaPacchetto = AssistenzaPacchettoEnum.PacchettoTop
                    End If
                ElseIf (PersonaSceltaForma >= PersonaSceltaFormaEnum.FullTimeFormulaFacile01 And PersonaSceltaForma <= PersonaSceltaFormaEnum.FullTimeFormulaFacile12) Then
                    AssistenzaPacchetto = AssistenzaPacchettoEnum.PacchettoComfort
                ElseIf (PersonaSceltaForma >= PersonaSceltaFormaEnum.Circolazione01 And PersonaSceltaForma <= PersonaSceltaFormaEnum.Circolazione12) Then
                    AssistenzaPacchetto = AssistenzaPacchettoEnum.PacchettoClassico
                End If
            ElseIf SezioneFamiglia.IsAttivo Then
                If FamigliaSceltaForma >= FamigliaSceltaFormaEnum.FullTimeFormulaFacile11 _
                    And FamigliaSceltaForma <= FamigliaSceltaFormaEnum.FullTimeFormulaFacile22 Then
                    AssistenzaPacchetto = AssistenzaPacchettoEnum.PacchettoComfort
                Else
                    AssistenzaPacchetto = AssistenzaPacchettoEnum.PacchettoClassico
                End If
            ElseIf SezioneVeicolo.IsAttivo Then
                AssistenzaPacchetto = AssistenzaPacchettoEnum.PacchettoClassico
            ElseIf AssistenzaPacchetto = 0 Then
                AssistenzaPacchetto = AssistenzaPacchettoEnum.PacchettoCompleto
            End If

            With CoperturaAssistenzaBase
                If AssistenzaPacchetto = AssistenzaPacchettoEnum.PacchettoCompleto Then
                    .Tariffa.Base = toBaseNetta10(7.5D)
                ElseIf AssistenzaPacchetto = AssistenzaPacchettoEnum.PacchettoTop Then
                    .Tariffa.Base = toBaseNetta10(13.5D)
                ElseIf AssistenzaPacchetto = AssistenzaPacchettoEnum.PacchettoComfort Then
                    .Tariffa.Base = toBaseNetta10(5.5D)
                ElseIf AssistenzaPacchetto = AssistenzaPacchettoEnum.PacchettoClassico Then
                    .Tariffa.Base = toBaseNetta10(4D)
                End If
            End With
        End Sub


        Public Function toBaseNetta10(ByVal valore As Decimal) As Decimal
            Return Math.Round((valore / 1.1D), 5, MidpointRounding.ToEven)
        End Function

        Public Function toBaseNetta(ByVal valore As Decimal, Optional ByVal decimali As Integer = 5) As Decimal
            Return Math.Round((valore / 1.025D), decimali, MidpointRounding.ToEven)
        End Function

        Public Function toBaseNetta2(ByVal valore As Decimal) As Decimal
            Return toBaseNetta(valore, 2)
        End Function

        Public Overrides Sub Stampa(ByVal options As StampaOptions)
            Dim s As New P01201ST
            Stampato = True
            s.StampaMostraEtInvia(Me, options)
        End Sub
    End Class
End Namespace
