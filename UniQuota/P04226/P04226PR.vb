Namespace P04226
    <Serializable()> Public Class YouCommercio
        Inherits Prodotto
        Public Fabbricati As New List(Of Fabbricato)

        <NonSerialized()> Public Tabelle As P04226TR

        Public CodiceAttivita1 As Integer
        Public CodiceAttivita2 As Integer
        Public CodiceAttivita3 As Integer
        Public TestoAttivita1 As String
        Public TestoAttivita2 As String
        Public TestoAttivita3 As String

        Public ClasseRischioAttivitaIncendio As ClasseRischioAttivitaIncendioEnum
        Public ClasseRischioAttivitaFurto As ClasseRischioAttivitaFurtoEnum
        Public ClasseRischioAttivitaRc As ClasseRischioAttivitaRcEnum
        Public ClasseRischioAttivitaTerremoto As ClasseRischioAttivitaTerremotoEnum
        Public NumeroAddetti As Integer
        Public SoloProprieta As Boolean

        Public IncendioScelta As IncendioSceltaEnum

        'todo: cumulativo?
        Public ClasseFabbricato As ClasseFabbricatoEnum
        Public FabbricatoDestinazione As FabbricatoDestinazioneEnum

        Public SezioneIncendio As New Sezione(Me, TipoSezione.Incendio)
        Public SezioneFurto As New Sezione(Me, TipoSezione.Furto)
        Public SezioneResponsabilitaCivile As New Sezione(Me, TipoSezione.ResponsabilitaCivile)
        Public SezioneTutelaLegale As New Sezione(Me, TipoSezione.TutelaLegale)
        Public SezioneAssistenza As New Sezione(Me, TipoSezione.Assistenza)
        Public SezioneTerremoto As New Sezione(Me, TipoSezione.Terremoto)

        ' Incendio e Furto
        Public PartitaFurtoPiuEsercizi As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoPiuEsercizi As New CoperturaSingola(PartitaFurtoPiuEsercizi, New Garanzia(TipoGaranzia.FurtoPiuEsercizi))
        Public CoperturaIncendio As New CoperturaComposta()
        Public CoperturaFurto As New CoperturaComposta()
        Public CoperturaTerremoto As New CoperturaComposta()

        'ResponsabilitaCivile
        Public PartitaResponsabilitaCivileBase As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaResponsabilitaCivileBase As New CoperturaSingola(PartitaResponsabilitaCivileBase, New Garanzia(TipoGaranzia.ResponsabilitaCivileBase))
        Public PartitaResponsabilitaCivileRct As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaResponsabilitaCivileRct As New CoperturaSingola(PartitaResponsabilitaCivileRct, New Garanzia(TipoGaranzia.ResponsabilitaCivileRct))
        Public PartitaResponsabilitaCivileRco As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaResponsabilitaCivileRco As New CoperturaSingola(PartitaResponsabilitaCivileRco, New Garanzia(TipoGaranzia.ResponsabilitaCivileRco))
        Public PartitaRCLavoratoriProgetto As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCLavoratoriProgetto As New CoperturaSingola(PartitaRCLavoratoriProgetto, New Garanzia(TipoGaranzia.RCLavoratoriProgetto))
        'Public PartitaRCRicorsoTerzi As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCRicorsoTerzi As New CoperturaSingola(PartitaResponsabilitaCivileRct, New Garanzia(TipoGaranzia.RCRicorsoTerzi))
        Public PartitaRCDanniCoseClienti As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCDanniCoseClienti As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCDanniCoseClienti))
        'Public PartitaRCDanniVeicoliTerzi As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCDanniVeicoliTerzi As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCDanniVeicoliTerzi))
        'Public PartitaRCDanniFurto As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCDanniFurto As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCDanniFurto))
        'Public PartitaRCDanniCoseLavorate As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCDanniCoseLavorate As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCDanniCoseLavorate))
        'Public PartitaRCDanniCoseMovimentate As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCDanniCoseMovimentate As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCDanniCoseMovimentate))
        Public PartitaRCMalattieProfessionali As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCMalattieProfessionali As New CoperturaSingola(PartitaRCMalattieProfessionali, New Garanzia(TipoGaranzia.RCMalattieProfessionali))
        'Public PartitaRCInquinamento As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCInquinamento As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCInquinamento))
        'Public PartitaRCFornitura As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCFornitura As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCFornitura))
        'Public PartitaRCDistributori1 As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCDistributori1 As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCDistributori1))
        'Public PartitaRCDistributori2 As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCDistributori2 As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCDistributori2))
        'Public PartitaRCCatering As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCCatering As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCCatering))
        'Public PartitaRCInstallazioni As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCInstallazioni As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCInstallazioni))
        'Public PartitaRCLavanderie As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCLavanderie As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCLavanderie))
        'Public PartitaRCParrucchieri As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCParrucchieri As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCParrucchieri))
        Public PartitaRCSoloProprieta As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCSoloProprieta As New CoperturaSingola(PartitaRCSoloProprieta, New Garanzia(TipoGaranzia.RCSoloProprieta))
        'Public PartitaRCAmbulante As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCAmbulante As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCAmbulante))
        'Public PartitaRCFranchigia As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCFranchigia As New CoperturaSingola(PartitaRCLavoratoriProgetto, New Garanzia(TipoGaranzia.RCFranchigia))
        Public CoperturaRCCarrelli As New CoperturaSingola(PartitaRCDanniCoseClienti, New Garanzia(TipoGaranzia.RCCarrelli))

        'TutelaLegale
        Public PartitaTutelaLegaleBase As New Partita(TipoPartita.TutelaLegale)
        Public CoperturaTutelaLegaleBase As New CoperturaSingola(PartitaTutelaLegaleBase, New Garanzia(TipoGaranzia.TutelaLegaleBase))
        Public PartitaTutelaLegaleDlgs07193 As New Partita(TipoPartita.TutelaLegale)
        Public CoperturaTutelaLegaleDlgs07193 As New CoperturaSingola(PartitaTutelaLegaleDlgs07193, New Garanzia(TipoGaranzia.TutelaLegaleDlgs07193))
        Public PartitaTutelaLegaleDlgs01231 As New Partita(TipoPartita.TutelaLegale)
        Public CoperturaTutelaLegaleDlgs01231 As New CoperturaSingola(PartitaTutelaLegaleDlgs01231, New Garanzia(TipoGaranzia.TutelaLegaleDlgs01231))
        Public PartitaTutelaLegaleDlgs97472 As New Partita(TipoPartita.TutelaLegale)
        Public CoperturaTutelaLegaleDlgs97472 As New CoperturaSingola(PartitaTutelaLegaleDlgs97472, New Garanzia(TipoGaranzia.TutelaLegaleDlgs97472))

        'Assistenza
        Public PartitaAssistenzaBase As New Partita(TipoPartita.Assistenza)
        Public CoperturaAssistenzaBase As New CoperturaSingola(PartitaAssistenzaBase, New Garanzia(TipoGaranzia.AssistenzaBase))

        Public Sub New()
            'Caratteristiche
            CodiceRamoPolizza = 87
            CodiceProdotto = TipoProdotto.YouCommercio
            DescrizioneProdotto = P00000DE.DecodeProdotto(CodiceProdotto)
            Edizione = "201305"
            DataEntrataVigore = "15/05/2013"

            DurataContrattualeMinimaInAnni = 1
            DurataContrattualeMassimaInAnni = 99
            PeriodoMoraInGiorni = 15
            EmissioneAppendici = False
            TacitoRinnovo = True

            ContraenzaPersonaGiuridica = True
            ContraenzaPersonaFisica = True
            PremioMinimoPrimaRata = 150.0

            'I tassi e i premi della presente tariffa sono comprensivi di imposte e oneri parafiscali.
            BaseTasse = UniQuota.BaseTasse.BaseLorda

            SezioneTerremoto.EscludiFlex = True

            'sezioni
            Sezioni.Add(SezioneIncendio)
            Sezioni.Add(SezioneFurto)
            Sezioni.Add(SezioneTerremoto)
            Sezioni.Add(SezioneResponsabilitaCivile)
            Sezioni.Add(SezioneTutelaLegale)
            Sezioni.Add(SezioneAssistenza)

            'aliquote
            SezioneIncendio.AliquotaImposta = AliquotaImpostaIncendio
            SezioneFurto.AliquotaImposta = AliquotaImpostaFurto
            SezioneTerremoto.AliquotaImposta = AliquotaImpostaIncendio
            SezioneResponsabilitaCivile.AliquotaImposta = AliquotaImpostaResponsabilitaCivile
            SezioneTutelaLegale.AliquotaImposta = AliquotaImpostaTutelaLegale
            SezioneAssistenza.AliquotaImposta = AliquotaImpostaAssistenza

            'sezione - coperture
            SezioneIncendio.AddCopertura(CoperturaIncendio)
            SezioneFurto.AddCopertura(CoperturaFurto)
            SezioneTerremoto.AddCopertura(CoperturaTerremoto)

            SezioneResponsabilitaCivile.AddCopertura(CoperturaResponsabilitaCivileBase)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaResponsabilitaCivileRct)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaResponsabilitaCivileRco)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCLavoratoriProgetto)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCRicorsoTerzi)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCDanniCoseClienti)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCDanniVeicoliTerzi)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCDanniFurto)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCDanniCoseLavorate)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCDanniCoseMovimentate)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCMalattieProfessionali)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCInquinamento)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCFornitura)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCDistributori1)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCDistributori2)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCCatering)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCInstallazioni)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCLavanderie)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCParrucchieri)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCSoloProprieta)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCAmbulante)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCFranchigia)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCCarrelli)
            SezioneTutelaLegale.AddCopertura(CoperturaTutelaLegaleBase)
            SezioneTutelaLegale.AddCopertura(CoperturaTutelaLegaleDlgs07193)
            SezioneTutelaLegale.AddCopertura(CoperturaTutelaLegaleDlgs01231)
            SezioneTutelaLegale.AddCopertura(CoperturaTutelaLegaleDlgs97472)
            SezioneAssistenza.AddCopertura(CoperturaAssistenzaBase)
        End Sub

        Public Overrides Sub Inizializza()
            MyBase.Inizializza()
            Tabelle = New P04226TR()
        End Sub

        Public Overrides Sub ImpostaSconto()
            Dim numeroSezioniObbligatorie As Integer = -(SezioneIncendio.ListinoLordo > 250D) _
                                                       - (SezioneFurto.ListinoLordo > 250D) _
                                                       - (SezioneResponsabilitaCivile.ListinoLordo > 200D)

            SezioneIncendio.PercentualeScontoTecnico = 0D
            SezioneFurto.PercentualeScontoTecnico = 0D
            SezioneResponsabilitaCivile.PercentualeScontoTecnico = 0D
            SezioneTerremoto.PercentualeScontoTecnico = 0D
            SezioneTutelaLegale.PercentualeScontoTecnico = 0D
            SezioneAssistenza.PercentualeScontoTecnico = 0D

            If numeroSezioniObbligatorie = 2 Then
                If SezioneIncendio.ListinoLordo > 250D Then SezioneIncendio.PercentualeScontoTecnico = 0.05D
                If SezioneFurto.ListinoLordo > 250D Then SezioneFurto.PercentualeScontoTecnico = 0.05D
                If SezioneResponsabilitaCivile.ListinoLordo > 200D Then SezioneResponsabilitaCivile.PercentualeScontoTecnico = 0.05D
            ElseIf numeroSezioniObbligatorie = 3 Then
                SezioneIncendio.PercentualeScontoTecnico = 0.1D
                SezioneFurto.PercentualeScontoTecnico = 0.1D
                SezioneResponsabilitaCivile.PercentualeScontoTecnico = 0.1D
            End If

            'sT = s1 * (1  - s2) + s2
            If Indicizzazione = StatoCopertura.attiva Then
                SezioneIncendio.PercentualeScontoTecnico = SezioneIncendio.PercentualeScontoTecnico * (1 - 0.05D) + 0.05D
                SezioneFurto.PercentualeScontoTecnico = SezioneFurto.PercentualeScontoTecnico * (1 - 0.05D) + 0.05D
                SezioneTerremoto.PercentualeScontoTecnico = 0.05D
                SezioneResponsabilitaCivile.PercentualeScontoTecnico = SezioneResponsabilitaCivile.PercentualeScontoTecnico * (1 - 0.05D) + 0.05D
            End If

        End Sub

        Public Overrides Sub Valida()
            ValidaCondizioniGenerali()
            ValidaSezioneIncendio()
            ValidaSezioneFurto()
            ValidaSezioneTerremoto()
            ValidaSezioneResponsabilitaCivile()
            ValidaSezioneTutelaLegale()
            ValidaSezioneAssistenza()
        End Sub

        Public Function ValidaCondizioniGenerali() As Boolean
            If NumeroAddetti < 0 Then NumeroAddetti = 0
            If CodiceAttivita1 < 100 Then CodiceAttivita1 = 0
            If CodiceAttivita2 < 100 Then CodiceAttivita2 = 0
            If CodiceAttivita3 < 100 Then CodiceAttivita3 = 0
            FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio
            ClasseFabbricato = ClasseFabbricatoEnum.Classe1

            If ClasseRischioAttivitaRc = 0 Then ClasseRischioAttivitaRc = ClasseRischioAttivitaRcEnum.Classe1
            If ClasseRischioAttivitaIncendio = 0 Then ClasseRischioAttivitaIncendio = ClasseRischioAttivitaIncendioEnum.Classe1
            If ClasseRischioAttivitaFurto = 0 Then ClasseRischioAttivitaFurto = ClasseRischioAttivitaFurtoEnum.A2
            If ClasseRischioAttivitaTerremoto = 0 Then ClasseRischioAttivitaTerremoto = ClasseRischioAttivitaTerremotoEnum.Classe1

            With CType(Decode, P04226DE)
                ClasseRischioAttivitaRc = .DecodeAttivitaToClasseRischioAttivitaRc(CodiceAttivita1)
                If CodiceAttivita2 > 0 AndAlso ClasseRischioAttivitaRc > .DecodeAttivitaToClasseRischioAttivitaRc(CodiceAttivita2) Then
                    ClasseRischioAttivitaRc = .DecodeAttivitaToClasseRischioAttivitaRc(CodiceAttivita2)
                End If
                If CodiceAttivita3 > 0 AndAlso ClasseRischioAttivitaRc > .DecodeAttivitaToClasseRischioAttivitaRc(CodiceAttivita3) Then
                    ClasseRischioAttivitaRc = .DecodeAttivitaToClasseRischioAttivitaRc(CodiceAttivita3)
                End If

                ClasseRischioAttivitaIncendio = .DecodeAttivitaToClasseRischioAttivitaIncendio(CodiceAttivita1)
                If CodiceAttivita2 > 0 AndAlso ClasseRischioAttivitaIncendio > .DecodeAttivitaToClasseRischioAttivitaIncendio(CodiceAttivita2) Then
                    ClasseRischioAttivitaIncendio = .DecodeAttivitaToClasseRischioAttivitaIncendio(CodiceAttivita2)
                End If
                If CodiceAttivita3 > 0 AndAlso ClasseRischioAttivitaIncendio > .DecodeAttivitaToClasseRischioAttivitaIncendio(CodiceAttivita3) Then
                    ClasseRischioAttivitaIncendio = .DecodeAttivitaToClasseRischioAttivitaIncendio(CodiceAttivita3)
                End If

                ClasseRischioAttivitaFurto = .DecodeAttivitaToClasseRischioAttivitaFurto(CodiceAttivita1)
                If CodiceAttivita2 > 0 AndAlso ClasseRischioAttivitaFurto > .DecodeAttivitaToClasseRischioAttivitaFurto(CodiceAttivita2) Then
                    ClasseRischioAttivitaFurto = .DecodeAttivitaToClasseRischioAttivitaFurto(CodiceAttivita2)
                End If
                If CodiceAttivita3 > 0 AndAlso ClasseRischioAttivitaFurto > .DecodeAttivitaToClasseRischioAttivitaFurto(CodiceAttivita3) Then
                    ClasseRischioAttivitaFurto = .DecodeAttivitaToClasseRischioAttivitaFurto(CodiceAttivita3)
                End If

                ClasseRischioAttivitaTerremoto = .DecodeAttivitaToClasseRischioAttivitaTerremoto(CodiceAttivita1)
                If CodiceAttivita2 > 0 AndAlso ClasseRischioAttivitaTerremoto > .DecodeAttivitaToClasseRischioAttivitaTerremoto(CodiceAttivita2) Then
                    ClasseRischioAttivitaTerremoto = .DecodeAttivitaToClasseRischioAttivitaTerremoto(CodiceAttivita2)
                End If
                If CodiceAttivita3 > 0 AndAlso ClasseRischioAttivitaTerremoto > .DecodeAttivitaToClasseRischioAttivitaTerremoto(CodiceAttivita3) Then
                    ClasseRischioAttivitaTerremoto = .DecodeAttivitaToClasseRischioAttivitaTerremoto(CodiceAttivita3)
                End If
            End With

            For Each fabbricato As Fabbricato In Fabbricati
                With fabbricato
                    .PrimoFabbricato = .Equals(Fabbricati(0))
                    If .ClasseFabbricato = 0 Then .ClasseFabbricato = ClasseFabbricatoEnum.Classe1
                    If .FabbricatoDestinazione = 0 Then .FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio
                    If .Provincia = ProvinciaEnum.SiglaXX And Agenzia.Provincia <> vbNullString Then .Provincia = Luogo.GetProvinciaBySigla(Agenzia.Provincia)
                    If .Provincia = ProvinciaEnum.SiglaXX Then .Provincia = ProvinciaEnum.SiglaAG

                    .ZonaTerritorialeFurto = CType(Decode, P04226DE).DecodeProvinciaToZonaTerritorialeFurto(.Provincia)
                    .ZonaTerritorialeEventiAtmosferici = CType(Decode, P04226DE).DecodeProvinciaToEventiAtmosferici(.Provincia)
                    If .ZonaTerritorialeFurto = 0 Then .ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona12
                    If .FurtoFissiScelta = 0 Then .FurtoFissiScelta = FurtoFissiSceltaEnum.SceltaA
                    If .FurtoValoriScelta = 0 Then .FurtoValoriScelta = FurtoValoriSceltaEnum.SceltaA
                    If .FurtoRapinaScelta = 0 Then .FurtoRapinaScelta = FurtoRapinaSceltaEnum.SceltaA

                    If .IncendioAumentoMerciMesi <> 0 Then
                        .FurtoAumentoMerciMesi = .IncendioAumentoMerciMesi
                    End If
                    If .PartitaIncendioCoseTrasportate.SommaAssicurata <> 0D Then
                        .PartitaFurtoMerciTrasportate.SommaAssicurata = .PartitaIncendioCoseTrasportate.SommaAssicurata
                    End If

                    ' per rc si considera Ingrosso se Almeno un negozio è all’ingrosso o dettaglio/ingrosso
                    If .FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                    Or .FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                        FabbricatoDestinazione = .FabbricatoDestinazione
                    End If

                    If .ClasseFabbricato = ClasseFabbricatoEnum.Classe2 Then
                        ClasseFabbricato = .ClasseFabbricato
                    End If
                End With
            Next

            If Fabbricati.Count > 5 Then
                CoperturaResponsabilitaCivileBase.Stato = StatoCopertura.Inapplicabile
            Else
                CoperturaResponsabilitaCivileBase.DipendeDa(True)
            End If
            If Fabbricati.Count > 1 Then
                SoloProprieta = False
            End If

            'È obbligatorio assicurare almeno una
            'delle seguenti Sezioni: Incendio Rischi
            'Nominati, Incendio All Risk, Furto,
            'RCT.
            CoperturaIncendio.Stato = StatoCopertura.esclusa
            CoperturaFurto.Stato = StatoCopertura.esclusa
            CoperturaTerremoto.Stato = StatoCopertura.esclusa

            For Each fabbricato As Fabbricato In Fabbricati
                With fabbricato
                    If .CoperturaIncendio.IsAttivo Then
                        CoperturaIncendio.Stato = StatoCopertura.attiva
                    End If
                    If .CoperturaFurto.IsAttivo Then
                        CoperturaFurto.Stato = StatoCopertura.attiva
                    End If
                    If .CoperturaTerremoto.IsAttivo Then
                        CoperturaTerremoto.Stato = StatoCopertura.attiva
                    End If
                End With
            Next

            SezioneIncendio.Stato = CoperturaIncendio.Stato
            SezioneFurto.Stato = CoperturaFurto.Stato
            SezioneTerremoto.Stato = CoperturaTerremoto.Stato

            'La Sezione Assistenza deve essere sempre attivata.
            If CoperturaIncendio.IsAttivo _
            Or CoperturaFurto.IsAttivo _
            Or CoperturaResponsabilitaCivileBase.IsAttivo Then
                'CoperturaTutelaLegaleBase.EscludiIfInapplicabile()
                CoperturaTutelaLegaleBase.DipendeDa(Not SoloProprieta)
                CoperturaAssistenzaBase.Stato = StatoCopertura.attiva
            Else
                CoperturaTutelaLegaleBase.Stato = StatoCopertura.Inapplicabile
                CoperturaAssistenzaBase.Stato = StatoCopertura.Inapplicabile
            End If


            'La Garanzia Incendio è proposta nelle
            'due versioni Incendio Rischi Nominati e Incendio All Risk. 
            'La scelta fatta per una delle località è vincolante anche per le altre.
            '- La Sezione Incendio All Risk è alternativa alla Sezione Incendio Rischi Nominati.

            'sconti
            Dim numeroUbicazioni As Integer = 0
            Dim sommaAssicurate As Decimal = 0D

            'If CoperturaFurtoPiuEsercizi.IsAttivo() Then
            For Each fabbricato As Fabbricato In Fabbricati
                With fabbricato
                    If .CoperturaFurtoContenuto.IsAttivo _
                    And Not .CoperturaFurtoReintegroAutomatico.IsAttivo _
                    And Not .CoperturaFurtoAumentoMerci.IsAttivo Then
                        numeroUbicazioni += 1
                        sommaAssicurate += .PartitaFurtoContenuto.SommaAssicurata
                    End If
                End With
            Next
            'End If

            If sommaAssicurate > 0D And numeroUbicazioni >= 3 Then
                CoperturaFurtoPiuEsercizi.Tariffa.Tasso = PartitaFurtoPiuEsercizi.SommaAssicurata / sommaAssicurate - 0.8D
                If CoperturaFurtoPiuEsercizi.Tariffa.Tasso > -0.1D Then
                    CoperturaFurtoPiuEsercizi.Tariffa.Tasso = -0.1D
                    PartitaFurtoPiuEsercizi.SommaAssicurata = 0.7D * sommaAssicurate
                ElseIf CoperturaFurtoPiuEsercizi.Tariffa.Tasso < -0.5D Then
                    CoperturaFurtoPiuEsercizi.Tariffa.Tasso = -0.5D
                    PartitaFurtoPiuEsercizi.SommaAssicurata = 0.3D * sommaAssicurate
                End If
            End If

            If Frazionamento = FrazionamentiEnum.Temporaneo Then
                RischioDirezione = True
                DescrizioneRD = "Il frazionamento temporaneo (cod. 0) è Riservato Direzione"
            ElseIf Frazionamento = FrazionamentiEnum.UnicoAnticipato Then
                RischioDirezione = True
                DescrizioneRD = "Il premio unico anticipato (cod. 8) è Riservato Direzione"
            End If

            If CodiceAttivita1 = 0 And CodiceAttivita2 = 0 And CodiceAttivita3 = 0 Then
                RischioDirezione = True
                DescrizioneRD = "Nessuna Attività' selezionata"
            ElseIf (CodiceAttivita1 > 0 And CodiceAttivita1 Mod 100 = 0) _
                Or (CodiceAttivita2 > 0 And CodiceAttivita2 Mod 100 = 0) _
                Or (CodiceAttivita3 > 0 And CodiceAttivita3 Mod 100 = 0) Then
                RischioDirezione = True
                DescrizioneRD = "Il codice generico 'Altra Attività' è Riservato Direzione"
            End If
            Return True
        End Function

        Public Function ValidaSezioneIncendio() As Boolean
            For Each fabbricato As Fabbricato In Fabbricati
                fabbricato.ValidaSezioneIncendio()
            Next
            Return True
        End Function

        Public Function ValidaSezioneFurto() As Boolean
            Dim furtoContenutoPerPiuEsercizi As Integer = 0

            For Each fabbricato As Fabbricato In Fabbricati
                If fabbricato.CoperturaFurtoContenuto.IsAttivo _
                And Not fabbricato.CoperturaFurtoReintegroAutomatico.IsAttivo _
                And Not fabbricato.CoperturaFurtoAumentoMerci.IsAttivo Then
                    furtoContenutoPerPiuEsercizi += 1
                End If
            Next

            CoperturaFurtoPiuEsercizi.DipendeDa(furtoContenutoPerPiuEsercizi > 2)

            For Each fabbricato As Fabbricato In Fabbricati
                fabbricato.ValidaSezioneFurto()
            Next
            Return True
        End Function

        Public Function ValidaSezioneTerremoto() As Boolean
            For Each fabbricato As Fabbricato In Fabbricati
                fabbricato.ValidaSezioneTerremoto()
            Next
            Return True
        End Function

        Public Function ValidaSezioneResponsabilitaCivile() As Boolean
            SezioneResponsabilitaCivile.Stato = CoperturaResponsabilitaCivileBase.Stato
            'Garanzia Base
            CoperturaRCSoloProprieta.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo And SoloProprieta)
            CoperturaResponsabilitaCivileRct.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo And Not SoloProprieta)
            'Garanzie supplementari opzionali
            CoperturaResponsabilitaCivileRco.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo)
            CoperturaRCLavoratoriProgetto.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo Or CoperturaResponsabilitaCivileRco.IsAttivo)
            CoperturaRCRicorsoTerzi.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo)
            CoperturaRCDanniCoseClienti.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo)
            CoperturaRCDanniVeicoliTerzi.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo And CodiceAttivita1 <> 921)
            CoperturaRCDanniFurto.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo)
            CoperturaRCDanniCoseLavorate.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo)
            CoperturaRCDanniCoseMovimentate.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo)
            CoperturaRCMalattieProfessionali.DipendeDa(CoperturaResponsabilitaCivileRco.IsAttivo)
            CoperturaRCInquinamento.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo)
            CoperturaRCFornitura.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo)
            CoperturaRCDistributori1.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo And CodiceAttivita1 = 941)
            CoperturaRCDistributori2.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo And CodiceAttivita1 = 942)
            CoperturaRCCatering.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo And IsOneOf(CodiceAttivita1, 181, 182, 183, 184, 185))
            CoperturaRCInstallazioni.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo And IsOneOf(CodiceAttivita1, 200, 222, 226, 232, 235, 237, 241, 261, 263, 344, 553, 687))
            CoperturaRCLavanderie.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo And IsOneOf(CodiceAttivita1, 663, 669))
            CoperturaRCParrucchieri.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo And IsOneOf(CodiceAttivita1, 752, 755, 756))
            CoperturaRCCarrelli.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo)
            'Condizioni Specifiche
            CoperturaRCAmbulante.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo)
            CoperturaRCFranchigia.DipendeDa(CoperturaResponsabilitaCivileRct.IsAttivo Or CoperturaRCSoloProprieta.IsAttivo)

            With CoperturaResponsabilitaCivileRct

                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 250000D
                .Tariffa.Base = 0D

                .Partita.SommaAssicurata = .Garanzia.Massimale

                If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                    If NumeroAddetti <= 3 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 145D, 113D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 185D, 144D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 217D, 170D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 245D, 192D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 290D, 226D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 330D, 253D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 362D, 282D)
                        End If
                    ElseIf NumeroAddetti <= 5 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 168D, 131D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 215D, 167D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 252D, 198D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 284D, 223D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 337D, 262D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 383D, 294D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 420D, 328D)
                        End If
                    ElseIf NumeroAddetti <= 10 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 212D, 164D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 270D, 210D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 317D, 248D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 358D, 281D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 424D, 329D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 482D, 370D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 529D, 412D)
                        End If
                    ElseIf NumeroAddetti <= 18 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 300D, 234D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 383D, 298D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 450D, 353D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 506D, 397D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 601D, 467D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 683D, 524D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 750D, 583D)
                        End If
                    Else 'If NumeroAddetti <= 30 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 427D, 331D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 544D, 424D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 638D, 500D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 720D, 564D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 853D, 664D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 971D, 744D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 1066D, 829D)
                        End If
                    End If
                ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio _
                    Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici Then
                    If NumeroAddetti <= 3 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 121D, 94D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 154D, 120D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 181D, 142D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 204D, 160D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 242D, 188D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 275D, 211D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 302D, 235D)
                        End If
                    ElseIf NumeroAddetti <= 5 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 140D, 109D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 179D, 139D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 210D, 165D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 237D, 186D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 281D, 218D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 319D, 245D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 350D, 273D)
                        End If
                    ElseIf NumeroAddetti <= 10 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 177D, 137D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 225D, 175D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 264D, 207D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 298D, 234D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 353D, 374D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 402D, 308D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 441D, 343D)
                        End If
                    ElseIf NumeroAddetti <= 18 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 250D, 195D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 319D, 248D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 375D, 294D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 422D, 331D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 501D, 389D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 569D, 437D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 625D, 486D)
                        End If
                    Else 'If NumeroAddetti <= 30 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 356D, 276D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 453D, 353D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 532D, 417D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 600D, 470D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 711D, 553D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 809D, 620D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 888D, 691D)
                        End If
                    End If
                End If
                If NumeroAddetti >= 31 Then
                    .Tariffa.Base *= 1D + (NumeroAddetti - 30) * 0.1D
                    SetRischioDirezione("Numero addetti maggiore di 30")
                ElseIf NumeroAddetti > 18 And Fabbricati.Count <= 1 Then
                    .SetRischioDirezione("Numero addetti maggiore di 18 con una ubicazione")
                ElseIf NumeroAddetti = 0 Then
                    .SetNonDisponibile("Numero addetti dev'essere maggiore di zero")
                End If
            End With

            With CoperturaResponsabilitaCivileRco

                .Garanzia.Massimale = CoperturaResponsabilitaCivileRct.Garanzia.Massimale
                If ClasseFabbricato = 0 Then ClasseFabbricato = ClasseFabbricatoEnum.Classe1
                .Tariffa.Base = 0D

                If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                    If NumeroAddetti <= 3 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 41D, 32D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 48D, 38D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 59D, 47D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 68D, 58D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 84D, 67D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 100D, 80D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 121D, 97D)
                        End If
                    ElseIf NumeroAddetti <= 5 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 47D, 37D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 55D, 44D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 68D, 54D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 79D, 67D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 97D, 78D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 115D, 94D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 140D, 113D)
                        End If
                    ElseIf NumeroAddetti <= 10 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 60D, 47D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 70D, 56D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 86D, 68D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 100D, 84D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 122D, 98D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 145D, 118D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 176D, 142D)
                        End If
                    ElseIf NumeroAddetti <= 18 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 84D, 67D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 100D, 79D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 121D, 97D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 142D, 119D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 174D, 139D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 206D, 167D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 251D, 202D)
                        End If
                    Else 'If NumeroAddetti <= 30 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 120D, 95D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 142D, 113D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 173D, 138D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 202D, 169D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 247D, 198D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 293D, 236D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 356D, 286D)
                        End If
                    End If
                ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio _
                    Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici Then
                    If NumeroAddetti <= 3 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 34D, 27D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 40D, 32D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 49D, 39D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 57D, 48D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 70D, 56D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 83D, 67D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 101D, 81D)
                        End If
                    ElseIf NumeroAddetti <= 5 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 39D, 31D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 46D, 37D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 57D, 45D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 66D, 56D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 81D, 65D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 96D, 78D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 117D, 94D)
                        End If
                    ElseIf NumeroAddetti <= 10 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 50D, 39D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 58D, 47D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 72D, 57D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 83D, 70D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 102D, 82D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 121D, 98D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 147D, 118D)
                        End If
                    ElseIf NumeroAddetti <= 18 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 70D, 56D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 83D, 66D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 101D, 81D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 118D, 99D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 145D, 116D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 172D, 139D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 209D, 168D)
                        End If
                    Else 'If NumeroAddetti <= 30 Then
                        If .Garanzia.Massimale = 250000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 100D, 79D)
                        ElseIf .Garanzia.Massimale = 500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 118D, 94D)
                        ElseIf .Garanzia.Massimale = 1000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 144D, 115D)
                        ElseIf .Garanzia.Massimale = 1500000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 168D, 141D)
                        ElseIf .Garanzia.Massimale = 3000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 206D, 165D)
                        ElseIf .Garanzia.Massimale = 4000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 244D, 197D)
                        ElseIf .Garanzia.Massimale = 5000000D Then
                            .Tariffa.Base = Choose(ClasseFabbricato, 297D, 238D)
                        End If
                    End If
                End If
                If NumeroAddetti >= 31 Then
                    .Tariffa.Base *= 1D + (NumeroAddetti - 30D) * 0.1D
                End If
            End With

            With CoperturaRCSoloProprieta
                If SoloProprieta And Fabbricati.Count = 1 Then
                    .Partita.SommaAssicurata = Fabbricati(0).PartitaIncendioFabbricato.SommaAssicurata
                Else
                    .Partita.SommaAssicurata = 0D
                End If
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 500000D
                If .Garanzia.Massimale = 500000D Then
                    .Tariffa.Tasso = 0.25D / 1000D
                ElseIf .Garanzia.Massimale = 1000000D Then
                    .Tariffa.Tasso = 0.35D / 1000D
                ElseIf .Garanzia.Massimale = 1500000D Then
                    .Tariffa.Tasso = 0.5D / 1000D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            Dim ncp As Integer = 1
            Dim bonus As Decimal = 0D

            ncp = -CoperturaRCDanniCoseClienti.IsAttivo _
                  - CoperturaRCDanniVeicoliTerzi.IsAttivo _
                  - CoperturaRCDanniFurto.IsAttivo _
                  - CoperturaRCDanniCoseLavorate.IsAttivo _
                  - CoperturaRCDanniCoseMovimentate.IsAttivo _
                  - CoperturaRCInquinamento.IsAttivo _
                  - CoperturaRCFornitura.IsAttivo _
                  - CoperturaRCDistributori1.IsAttivo _
                  - CoperturaRCDistributori2.IsAttivo _
                  - CoperturaRCCatering.IsAttivo _
                  - CoperturaRCInstallazioni.IsAttivo _
                  - CoperturaRCLavanderie.IsAttivo _
                  - CoperturaRCParrucchieri.IsAttivo _
                  - CoperturaRCCarrelli.IsAttivo

            If ncp = 2 Then
                bonus = 0.1D
            ElseIf ncp = 3 Then
                bonus = 0.15D
            ElseIf ncp = 4 Then
                bonus = 0.2D
            ElseIf ncp = 5 Then
                bonus = 0.3D
            ElseIf ncp > 5 Then
                bonus = 0.4D
            End If
            CoperturaResponsabilitaCivileRct.PercentualeScontoTecnico = bonus

            With CoperturaRCLavoratoriProgetto
                .Partita.SommaAssicurata = CoperturaResponsabilitaCivileRct.PremioAttivoCrudo + CoperturaResponsabilitaCivileRco.PremioAttivoCrudo
                .Tariffa.Tasso = 0.2D
            End With

            With CoperturaRCRicorsoTerzi
                .Tariffa.Base = 30D
            End With

            With CoperturaRCDanniCoseClienti
                .Partita.SommaAssicurata = CoperturaResponsabilitaCivileRct.PremioAttivoCrudo
                .Tariffa.Tasso = 0.15D
            End With

            With CoperturaRCDanniVeicoliTerzi
                .Tariffa.Tasso = 0.25D
            End With

            With CoperturaRCDanniFurto
                .Tariffa.Tasso = 0.15D
            End With

            With CoperturaRCDanniCoseLavorate
                .Tariffa.Tasso = 0.15D
            End With

            With CoperturaRCDanniCoseMovimentate
                .Tariffa.Tasso = 0.4D
            End With

            With CoperturaRCMalattieProfessionali
                .Partita.SommaAssicurata = CoperturaResponsabilitaCivileRco.PremioAttivoCrudo
                .Tariffa.Tasso = 0.2D
            End With

            With CoperturaRCInquinamento
                .Tariffa.Tasso = 0.25D
            End With

            With CoperturaRCFornitura
                .Tariffa.Tasso = 0.25D
            End With

            With CoperturaRCAmbulante
                .Tariffa.Tasso = 0.3D
            End With

            With CoperturaRCDistributori1
                .Tariffa.Tasso = 0.3D
            End With

            With CoperturaRCDistributori2
                .Tariffa.Tasso = 0.4D
            End With

            With CoperturaRCCatering
                .Tariffa.Tasso = 0.3D
            End With

            With CoperturaRCInstallazioni
                .Tariffa.Tasso = 0.35D
            End With

            With CoperturaRCLavanderie
                .Tariffa.Tasso = 0.25D
            End With

            With CoperturaRCParrucchieri
                .Tariffa.Tasso = 0.6D
            End With

            With CoperturaRCCarrelli
                .Tariffa.Tasso = 0.5D
            End With

            With CoperturaRCFranchigia
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 1500D
                If .Garanzia.Franchigia = 1500D Then
                    .Tariffa.Base = -0.25D * (CoperturaResponsabilitaCivileRct.PremioAttivoCrudo)
                ElseIf .Garanzia.Franchigia = 2500D Then
                    .Tariffa.Base = -0.35D * (CoperturaResponsabilitaCivileRct.PremioAttivoCrudo + CoperturaResponsabilitaCivileRco.PremioAttivoCrudo)
                ElseIf .Garanzia.Franchigia = 20000D Then
                    .Tariffa.Base = -0.55D * (CoperturaResponsabilitaCivileRct.PremioAttivoCrudo + CoperturaResponsabilitaCivileRco.PremioAttivoCrudo)
                Else
                    .Tariffa.Base = 0D
                End If
            End With

            With SezioneResponsabilitaCivile
                If ClasseRischioAttivitaRc = ClasseRischioAttivitaRcEnum.ClasseRD Then
                    .RischioDirezione = True
                    .DescrizioneRD = "per l'attività selezionata la garanzia è Riservato Direzione"
                End If

                If Fabbricati.Count > 1 And NumeroAddetti > 30 Then
                    .RischioDirezione = True
                    .DescrizioneRD = "Oltre 30 addetti la garanzia è Riservato Direzione"
                ElseIf Fabbricati.Count <= 1 And NumeroAddetti > 18 Then
                    .RischioDirezione = True
                    .DescrizioneRD = "Oltre 18 addetti la garanzia è Riservato Direzione"
                End If
            End With

            Return True
        End Function

        Public Function ValidaSezioneTutelaLegale() As Boolean
            SezioneTutelaLegale.Stato = CoperturaTutelaLegaleBase.Stato

            CoperturaTutelaLegaleDlgs07193.DipendeDa(CoperturaTutelaLegaleBase.IsAttivo)
            CoperturaTutelaLegaleDlgs01231.DipendeDa(CoperturaTutelaLegaleBase.IsAttivo)
            CoperturaTutelaLegaleDlgs97472.DipendeDa(CoperturaTutelaLegaleBase.IsAttivo)

            With CoperturaTutelaLegaleBase
                .Tariffa.Base = 0D
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 10000D
                If .Garanzia.Massimale = 10000D Then
                    If NumeroAddetti <= 3 Then
                        .Tariffa.Base = 190D
                    ElseIf NumeroAddetti <= 5 Then
                        .Tariffa.Base = 220D
                    ElseIf NumeroAddetti <= 10 Then
                        .Tariffa.Base = 280D
                    ElseIf NumeroAddetti <= 18 Then
                        .Tariffa.Base = 500D
                    ElseIf NumeroAddetti <= 30 Then
                        .Tariffa.Base = 1300D
                    End If
                ElseIf .Garanzia.Massimale = 20000D Then
                    If NumeroAddetti <= 3 Then
                        .Tariffa.Base = 220D
                    ElseIf NumeroAddetti <= 5 Then
                        .Tariffa.Base = 255D
                    ElseIf NumeroAddetti <= 10 Then
                        .Tariffa.Base = 320D
                    ElseIf NumeroAddetti <= 18 Then
                        .Tariffa.Base = 575D
                    ElseIf NumeroAddetti <= 30 Then
                        .Tariffa.Base = 1495D
                    End If
                ElseIf .Garanzia.Massimale = 30000D Then
                    If NumeroAddetti <= 3 Then
                        .Tariffa.Base = 265D
                    ElseIf NumeroAddetti <= 5 Then
                        .Tariffa.Base = 310D
                    ElseIf NumeroAddetti <= 10 Then
                        .Tariffa.Base = 390D
                    ElseIf NumeroAddetti <= 18 Then
                        .Tariffa.Base = 700D
                    ElseIf NumeroAddetti <= 30 Then
                        .Tariffa.Base = 1815D
                    End If
                End If

                If Fabbricati.Count > 1 And NumeroAddetti > 30 Then
                    .RischioDirezione = True
                    .DescrizioneRD = "Oltre 30 addetti la garanzia è Riservato Direzione"
                ElseIf Fabbricati.Count <= 1 And NumeroAddetti > 18 Then
                    .RischioDirezione = True
                    .DescrizioneRD = "Oltre 18 addetti la garanzia è Riservato Direzione"
                End If
            End With

            CoperturaTutelaLegaleDlgs07193.Tariffa.Base = 0.1D * CoperturaTutelaLegaleBase.Tariffa.Base
            CoperturaTutelaLegaleDlgs01231.Tariffa.Base = 0.1D * CoperturaTutelaLegaleBase.Tariffa.Base
            CoperturaTutelaLegaleDlgs97472.Tariffa.Base = 0.2D * CoperturaTutelaLegaleBase.Tariffa.Base

            Return True
        End Function

        Public Function ValidaSezioneAssistenza() As Boolean
            SezioneAssistenza.Stato = CoperturaAssistenzaBase.Stato
            CoperturaAssistenzaBase.Tariffa.Base = 11D

            Return True
        End Function

        Public Overrides Sub CalcolaTotaliPre()
            'correggo le sezioni
            With SezioneIncendio
                If .PremioLordo > 0D And .PremioLordo < 60D Then
                    .PremioLordo = 60D
                    .PremioNetto = Arrotonda(.PremioLordo / (1 + .AliquotaImposta))
                    .PremioTasse = .PremioLordo - .PremioNetto
                    If ModalitaVisualizzazione = ModalitaVisualizzazionePremi.PremioLordo Then
                        .PremioLabel = .PremioLordo
                    Else
                        .PremioLabel = .PremioNetto
                    End If
                End If
            End With
        End Sub

        Public Sub AggiungiFabbricato(ByRef fabbricato As Fabbricato)
            Fabbricati.Add(fabbricato)
            CoperturaIncendio.Coperture.Add(fabbricato.CoperturaIncendio)
            CoperturaFurto.Coperture.Add(fabbricato.CoperturaFurto)
            CoperturaTerremoto.Coperture.Add(fabbricato.CoperturaTerremoto)
        End Sub

        Public Sub RimuoviFabbricato(ByRef fabbricato As Fabbricato)
            Fabbricati.Remove(fabbricato)
            CoperturaIncendio.Coperture.Remove(fabbricato.CoperturaIncendio)
            CoperturaFurto.Coperture.Remove(fabbricato.CoperturaFurto)
            CoperturaTerremoto.Coperture.Remove(fabbricato.CoperturaTerremoto)
        End Sub

        Public Overrides Sub Stampa(ByVal options As StampaOptions)
            Dim s As New P04226ST
            Stampato = True
            s.StampaMostraEtInvia(Me, options)
        End Sub

    End Class

End Namespace

