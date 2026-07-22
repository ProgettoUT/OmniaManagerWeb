Namespace P07263
    <Serializable()> Public Class UnipolSaiCasaServizi
        Inherits Prodotto
        Public Abitazioni As New List(Of Abitazione)
        <NonSerialized()> Public TariffaTerremoto As P07263TR
        <NonSerialized()> Public TariffaAlluvione As P07263TA

        Public TipoContraenza As TipoContraenzaEnum
        Public FormaAssicurazione As FormaAssicurazioneEnum
        Public DanniTerziNumeroUbicazioni As Integer
        Public incrementoPerNumeroUbicazioni As Decimal
        Public ProvinciaRCT As ProvinciaEnum = ProvinciaEnum.SiglaXX
        Public ClasseTerritorialeRCT As ClasseTerritorialeRCTEnum
        Public VincoloBancario As Boolean

        'aliquote
        Public PercentualeScontoPluralitaSezioni As Decimal = 0D

        'Sezioni
        Public SezioneDanniBeni As New Sezione(Me, TipoSezione.DanniBeni)
        Public SezioneFurto As New Sezione(Me, TipoSezione.Furto)
        Public SezioneCatastrofali As New Sezione(Me, TipoSezione.Catastrofali)
        Public SezioneAssistenzaPlus As New Sezione(Me, TipoSezione.AssistenzaPlus)
        Public SezioneProtezioneEmergenza As New Sezione(Me, TipoSezione.ProtezioneEmergenza)
        Public SezioneDanniTerzi As New Sezione(Me, TipoSezione.DanniTerzi)
        Public SezioneTutelaLegale As New Sezione(Me, TipoSezione.TutelaLegale)
        Public SezioneAssistenza As New Sezione(Me, TipoSezione.Assistenza)
        Public SezioneProtezioneDigitale As New Sezione(Me, TipoSezione.ProtezioneDigitale)
        Public SezioneProtezioneBenessere As New Sezione(Me, TipoSezione.ProtezioneBenessere)
        Public SezioneProtezioneFamiglia As New Sezione(Me, TipoSezione.ProtezioneFamiglia)

        'DanniBeni
        Public CoperturaDanniBeni As New CoperturaComposta()

        'Furto
        Public CoperturaFurto As New CoperturaComposta()

        'Catastrofali
        Public CoperturaCatastrofali As New CoperturaComposta()

        'AssistenzaPlus
        Public CoperturaAssistenzaPlus As New CoperturaComposta()

        'ProtezioneEmergenza
        Public CoperturaProtezioneEmergenza As New CoperturaComposta()

        'DanniTerzi
        Public PartitaDanniTerziBase As New Partita(TipoPartita.DanniTerzi)
        Public CoperturaDanniTerziBase As New CoperturaSingola(PartitaDanniTerziBase, New Garanzia(TipoGaranzia.DanniTerziBase))
        Public PartitaDanniTerziIncendio As New Partita(TipoPartita.DanniTerzi)
        Public CoperturaDanniTerziIncendio As New CoperturaSingola(PartitaDanniTerziIncendio, New Garanzia(TipoGaranzia.DanniTerziIncendio), True)
        Public PartitaDanniTerziVitaPrivata As New Partita(TipoPartita.DanniTerzi)
        Public CoperturaDanniTerziVitaPrivata As New CoperturaSingola(PartitaDanniTerziVitaPrivata, New Garanzia(TipoGaranzia.DanniTerziVitaPrivata))
        Public PartitaDanniTerziProprieta As New Partita(TipoPartita.DanniTerzi)
        Public CoperturaDanniTerziProprieta As New CoperturaSingola(PartitaDanniTerziProprieta, New Garanzia(TipoGaranzia.DanniTerziProprieta))
        Public PartitaDanniTerziPlus As New Partita(TipoPartita.DanniTerzi)
        Public CoperturaDanniTerziPlus As New CoperturaSingola(PartitaDanniTerziPlus, New Garanzia(TipoGaranzia.DanniTerziPlus))
        Public PartitaDanniTerziLavoro As New Partita(TipoPartita.DanniTerzi)
        Public CoperturaDanniTerziLavoro As New CoperturaSingola(PartitaDanniTerziLavoro, New Garanzia(TipoGaranzia.DanniTerziLavoro))
        Public PartitaDanniTerziBeB As New Partita(TipoPartita.DanniTerzi)
        Public CoperturaDanniTerziBeB As New CoperturaSingola(PartitaDanniTerziBeB, New Garanzia(TipoGaranzia.DanniTerziBeB))
        Public PartitaDanniTerziLocazione As New Partita(TipoPartita.DanniTerzi)
        Public CoperturaDanniTerziLocazione As New CoperturaSingola(PartitaDanniTerziLocazione, New Garanzia(TipoGaranzia.DanniTerziLocazione))
        Public PartitaDanniTerziStage As New Partita(TipoPartita.DanniTerzi)
        Public CoperturaDanniTerziStage As New CoperturaSingola(PartitaDanniTerziStage, New Garanzia(TipoGaranzia.DanniTerziStage))

        'TutelaLegale
        Public PartitaTutelaLegaleBase As New Partita(TipoPartita.TutelaLegale)
        Public CoperturaTutelaLegaleBase As New CoperturaSingola(PartitaTutelaLegaleBase, New Garanzia(TipoGaranzia.TutelaLegaleBase))
        Public PartitaTutelaLegaleDivorzio As New Partita(TipoPartita.TutelaLegale)
        Public CoperturaTutelaLegaleDivorzio As New CoperturaSingola(PartitaTutelaLegaleDivorzio, New Garanzia(TipoGaranzia.TutelaLegaleDivorzio))

        'Assistenza
        Public PartitaAssistenzaBase As New Partita(TipoPartita.Assistenza)
        Public CoperturaAssistenzaBase As New CoperturaSingola(PartitaAssistenzaBase, New Garanzia(TipoGaranzia.AssistenzaBase))

        'ProtezioneDigitale
        Public PartitaProtezioneDigitaleBase As New Partita(TipoPartita.ProtezioneDigitale)
        Public CoperturaProtezioneDigitaleBase As New CoperturaSingola(PartitaProtezioneDigitaleBase, _
                                                                        New Garanzia(TipoGaranzia.ProtezioneDigitaleBase, _
                                                                        New Garanzia(TipoGaranzia.ProtezioneDigitaleAssistenzaMalware) + _
                                                                        New Garanzia(TipoGaranzia.ProtezioneDigitaleCyberBullismo) + _
                                                                        New Garanzia(TipoGaranzia.ProtezioneDigitaleLesioneReputazione) + _
                                                                        New Garanzia(TipoGaranzia.ProtezioneDigitaleProtezioneLegale)))

        'ProtezioneBenessere
        Public PartitaProtezioneBenessereBase As New Partita(TipoPartita.ProtezioneBenessere)
        Public CoperturaProtezioneBenessereBase As New CoperturaSingola(PartitaProtezioneBenessereBase, _
                                                                        New Garanzia(TipoGaranzia.ProtezioneBenessereBase, _
                                                                        New Garanzia(TipoGaranzia.ProtezioneBenessere45gg) + _
                                                                        New Garanzia(TipoGaranzia.ProtezioneBenesserePerditaImpiego)))

        'ProtezioneFamiglia
        Public PartitaProtezioneFamigliaBase As New Partita(TipoPartita.ProtezioneFamiglia)
        Public CoperturaProtezioneFamigliaBase As New CoperturaSingola(PartitaProtezioneFamigliaBase, _
                                                                        New Garanzia(TipoGaranzia.ProtezioneFamigliaBase, _
                                                                        New Garanzia(TipoGaranzia.ProtezioneFamigliaSostegnoFigli) + _
                                                                        New Garanzia(TipoGaranzia.ProtezioneFamigliaSostegnoEducazione) + _
                                                                        New Garanzia(TipoGaranzia.ProtezioneSostegnoDisabilita) + _
                                                                        New Garanzia(TipoGaranzia.ProtezioneFamigliaSostegnoDomestico)))

        Public Overrides Sub New2()
            If DataEntrataVigore = "15/03/2015" Then
                DataEntrataVigore = "15/03/2017"
            End If

            For Each Abitazione In Abitazioni
                If Abitazione.CoperturaAssistenzaPlus Is Nothing Then
                    Abitazione.CoperturaAssistenzaPlus = New CoperturaComposta()
                    With Abitazione.CoperturaAssistenzaPlus
                        .Sezione = SezioneAssistenzaPlus
                        .AddCopertura(Abitazione.CoperturaAssistenzaPlusBase)
                    End With
                End If
                If Abitazione.CoperturaProtezioneEmergenza Is Nothing Then
                    Abitazione.CoperturaProtezioneEmergenza = New CoperturaComposta()
                    With Abitazione.CoperturaProtezioneEmergenza
                        .Sezione = SezioneProtezioneEmergenza
                        .AddCopertura(Abitazione.CoperturaProtezioneEmergenzaBase)
                    End With
                End If
            Next
        End Sub

        Public Sub New()
            New2()
            'Caratteristiche
            CodiceRamoPolizza = 148
            CodiceProdotto = TipoProdotto.UnipolSaiCasaServizi
            DescrizioneProdotto = "UnipolSai Casa & Servizi"
            Edizione = "15.03.2017"
            DataEntrataVigore = "15/03/2017"

            DurataContrattualeMinimaInAnni = 1
            DurataContrattualeMassimaInAnni = 5
            PeriodoMoraInGiorni = 15
            EmissioneAppendici = False
            TacitoRinnovo = True

            ContraenzaPersonaGiuridica = True
            ContraenzaPersonaFisica = True
            PremioMinimoPrimaRata = 0D
            PremioMinimoRataSuccessiva = 0D
            premioMinimoAnnuoNetto = 0D
            premioMinimoAnnuoLordo = 50

            FrazionamentoInteressiSemestrale = 0D
            FrazionamentoInteressiQuadrimestrale = 0D
            FrazionamentoInteressiTrimestrale = 0D
            FrazionamentoInteressiBimestrale = 0D
            FrazionamentoInteressiMensile = 0D
            FrazionamentoMinimoMesi = 0D
            FrazionamentoFrazionePersonalizzato = 0
            FrazionamentoInteressiPersonalizzato = 0D

            'I tassi e i premi della presente tariffa sono comprensivi di imposte e oneri parafiscali.
            BaseTasse = UniQuota.BaseTasse.BaseLorda

            'sezioni
            Sezioni.Add(SezioneDanniBeni)
            Sezioni.Add(SezioneFurto)
            Sezioni.Add(SezioneCatastrofali)
            Sezioni.Add(SezioneAssistenzaPlus)
            Sezioni.Add(SezioneDanniTerzi)
            Sezioni.Add(SezioneTutelaLegale)
            Sezioni.Add(SezioneAssistenza)
            Sezioni.Add(SezioneProtezioneEmergenza)
            Sezioni.Add(SezioneProtezioneDigitale)
            Sezioni.Add(SezioneProtezioneBenessere)
            Sezioni.Add(SezioneProtezioneFamiglia)

            'aliquote
            SezioneDanniBeni.AliquotaImposta = AliquotaImpostaIncendio
            SezioneFurto.AliquotaImposta = AliquotaImpostaFurto
            SezioneCatastrofali.AliquotaImposta = AliquotaImpostaIncendio
            SezioneAssistenzaPlus.AliquotaImposta = AliquotaImpostaAssistenza
            SezioneProtezioneEmergenza.AliquotaImposta = 0.2225
            SezioneDanniTerzi.AliquotaImposta = 0.2225
            SezioneTutelaLegale.AliquotaImposta = AliquotaImpostaTutelaLegale
            SezioneAssistenza.AliquotaImposta = AliquotaImpostaAssistenza
            SezioneProtezioneDigitale.AliquotaImposta = 0.14 '84 / 73.66 - 1 ' media pesata tra diverse garanzie
            SezioneProtezioneBenessere.AliquotaImposta = 0.111 '60 / 54.01 - 1 ' media pesata tra diverse garanzie
            SezioneProtezioneFamiglia.AliquotaImposta = AliquotaImpostaInfortuni

            'sezione - coperture
            SezioneDanniBeni.AddCopertura(CoperturaDanniBeni)
            SezioneFurto.AddCopertura(CoperturaFurto)
            SezioneCatastrofali.AddCopertura(CoperturaCatastrofali)
            SezioneAssistenzaPlus.AddCopertura(CoperturaAssistenzaPlus)
            SezioneProtezioneEmergenza.AddCopertura(CoperturaProtezioneEmergenza)
            SezioneDanniTerzi.AddCopertura(CoperturaDanniTerziBase)
            SezioneDanniTerzi.AddCopertura(CoperturaDanniTerziIncendio)
            SezioneDanniTerzi.AddCopertura(CoperturaDanniTerziVitaPrivata)
            SezioneDanniTerzi.AddCopertura(CoperturaDanniTerziProprieta)
            SezioneDanniTerzi.AddCopertura(CoperturaDanniTerziPlus)
            SezioneDanniTerzi.AddCopertura(CoperturaDanniTerziLavoro)
            SezioneDanniTerzi.AddCopertura(CoperturaDanniTerziBeB)
            SezioneDanniTerzi.AddCopertura(CoperturaDanniTerziLocazione)
            SezioneDanniTerzi.AddCopertura(CoperturaDanniTerziStage)
            SezioneTutelaLegale.AddCopertura(CoperturaTutelaLegaleBase)
            SezioneTutelaLegale.AddCopertura(CoperturaTutelaLegaleDivorzio)
            SezioneAssistenza.AddCopertura(CoperturaAssistenzaBase)
            SezioneProtezioneDigitale.AddCopertura(CoperturaProtezioneDigitaleBase)
            SezioneProtezioneBenessere.AddCopertura(CoperturaProtezioneBenessereBase)
            SezioneProtezioneFamiglia.AddCopertura(CoperturaProtezioneFamigliaBase)

            CoperturaDanniBeni.Stato = StatoCopertura.attiva
            CoperturaFurto.Stato = StatoCopertura.attiva
            CoperturaCatastrofali.Stato = StatoCopertura.attiva
            CoperturaAssistenzaPlus.Stato = StatoCopertura.attiva
            CoperturaProtezioneEmergenza.Stato = StatoCopertura.attiva

            CoperturaDanniTerziBase.NonStampare = True
        End Sub

        Public Overrides Sub Inizializza()
            MyBase.Inizializza()
            TariffaTerremoto = New P07263TR()
            TariffaAlluvione = New P07263TA()
        End Sub

        Public Overrides Sub Valida()
            ValidaCondizioniGenerali()
            ValidaSconti()
            ValidaSezioneDanniTerzi()
            ValidaSezioneDanniBeni()
            ValidaSezioneFurto()
            ValidaSezioneCatastrofali()
            ValidaSezioneAssistenza()
            ValidaSezioneAssistenzaPlus()
            ValidaSezioneTutelaLegale()
            ValidaSezioneProtezioneDigitale()
            ValidaSezioneProtezioneBenessere()
            ValidaSezioneProtezioneFamiglia()
            ValidaSezioneProtezioneEmergenza()
        End Sub

        Public Sub ValidaCondizioniGenerali()
            If Cliente.CodiceFiscale.Length >= 11 Then
                If Cliente.IsPersonaFisica Then
                    TipoContraenza = TipoContraenzaEnum.PersonaFisica
                Else
                    TipoContraenza = TipoContraenzaEnum.PersonaGiudirica
                End If
            End If

            If DanniTerziNumeroUbicazioni < 1 Then DanniTerziNumeroUbicazioni = 1

            If ContraenzaPersonaGiuridica = True Then
                If DanniTerziNumeroUbicazioni > 5 Then DanniTerziNumeroUbicazioni = 5
            End If

            incrementoPerNumeroUbicazioni = IIf(DanniTerziNumeroUbicazioni > 3, 1.5D, 1D)

            For Each Abitazione As Abitazione In Abitazioni
                Abitazione.ValidaGenerale()
            Next
        End Sub

        Public Sub ValidaSconti()
            Dim PercentualeScontoPoliennalita As Decimal = 0D
            Dim PercentualeProprietaPiuVitaPrivata As Decimal = 0D
            Dim PercentualeScontoRiparazioneDiretta As Decimal = 0D
            Dim PercentualeScontoPremioUnicoAnticipato As Decimal = 0D

            Dim numeroAnni As Integer = 1
            Dim numeroSezioniObbligatorie As Integer = -(SezioneDanniBeni.IsAttivo) _
                                                       - (SezioneDanniTerzi.IsAttivo) _
                                                       - (SezioneFurto.IsAttivo)

            If numeroSezioniObbligatorie = 2 Then
                PercentualeScontoPluralitaSezioni = 5D
            ElseIf numeroSezioniObbligatorie = 3 Then
                PercentualeScontoPluralitaSezioni = 10D
            Else
                PercentualeScontoPluralitaSezioni = 0D
            End If

            If numeroAnni = 2 Then
                PercentualeScontoPremioUnicoAnticipato = 2D
            ElseIf numeroAnni = 3 Then
                PercentualeScontoPremioUnicoAnticipato = 4D
            ElseIf numeroAnni = 4 Then
                PercentualeScontoPremioUnicoAnticipato = 6D
            ElseIf numeroAnni = 5 Then
                PercentualeScontoPremioUnicoAnticipato = 8D
            Else
                PercentualeScontoPremioUnicoAnticipato = 0D
            End If

            For Each Abitazione In Abitazioni
                If Abitazione.CoperturaAssistenzaPlus.IsAttivo Then
                    Abitazione.CoperturaDanniBeni.PercentualeScontoTecnico = 0.05D
                    If Abitazione.CoperturaDanniFurtoImpiantoAllarme.IsNotAttivo Then
                        Abitazione.CoperturaFurto.PercentualeScontoTecnico = 0.05D
                    End If
                Else
                    Abitazione.CoperturaDanniBeni.PercentualeScontoTecnico = 0D
                    Abitazione.CoperturaFurto.PercentualeScontoTecnico = 0D
                End If


                Abitazione.CoperturaDanniBeniAbitazione.PercentualeScontoTecnico = Abitazione.CoperturaDanniBeni.PercentualeScontoTecnico
                Abitazione.CoperturaDanniBeniContenuto.PercentualeScontoTecnico = Abitazione.CoperturaDanniBeni.PercentualeScontoTecnico
                Abitazione.CoperturaDanniBeniGaranziaPlus.PercentualeScontoTecnico = Abitazione.CoperturaDanniBeni.PercentualeScontoTecnico
                Abitazione.CoperturaDanniBeniFenomeniElettrici.PercentualeScontoTecnico = Abitazione.CoperturaDanniBeni.PercentualeScontoTecnico
                Abitazione.CoperturaDanniBeniFenomeniElettriciPannelliSolari.PercentualeScontoTecnico = Abitazione.CoperturaDanniBeni.PercentualeScontoTecnico
                Abitazione.CoperturaDanniBeniRicercaGuasto.PercentualeScontoTecnico = Abitazione.CoperturaDanniBeni.PercentualeScontoTecnico
                Abitazione.CoperturaDanniBeniPerditeOcculte.PercentualeScontoTecnico = Abitazione.CoperturaDanniBeni.PercentualeScontoTecnico

                If Abitazione.Riparazionediretta = RiparazionedirettaEnum.SI Then
                    Abitazione.CoperturaDanniBeni.PercentualeScontoTecnico = 1 - (1 - Abitazione.CoperturaDanniBeni.PercentualeScontoTecnico) * (1 - 0.02)
                End If

                ' 10/07/2017: attenzione questo sconto non è ereditato dalle coperture figlie
                '             riferire alle singole coperture (CoperturaSingola)

                Abitazione.CoperturaDanniBeniFenomeniAtmosferici.PercentualeScontoTecnico = Abitazione.CoperturaDanniBeni.PercentualeScontoTecnico
                Abitazione.CoperturaDanniBeniDanniDaAcqua.PercentualeScontoTecnico = Abitazione.CoperturaDanniBeni.PercentualeScontoTecnico
                Abitazione.CoperturaDanniBeniVetriCristalli.PercentualeScontoTecnico = Abitazione.CoperturaDanniBeni.PercentualeScontoTecnico

                Abitazione.CoperturaDanniFurtoContenuto.PercentualeScontoTecnico = Abitazione.CoperturaFurto.PercentualeScontoTecnico
                Abitazione.CoperturaDanniFurtoGaranziaPlus.PercentualeScontoTecnico = Abitazione.CoperturaFurto.PercentualeScontoTecnico
                Abitazione.CoperturaDanniFurtoValoriCustoditi.PercentualeScontoTecnico = Abitazione.CoperturaFurto.PercentualeScontoTecnico
                Abitazione.CoperturaDanniFurtoValoriNonCustoditi.PercentualeScontoTecnico = Abitazione.CoperturaFurto.PercentualeScontoTecnico
                Abitazione.CoperturaDanniFurtoSocioPolitico.PercentualeScontoTecnico = Abitazione.CoperturaFurto.PercentualeScontoTecnico
                Abitazione.CoperturaDanniFurtoPannelli.PercentualeScontoTecnico = Abitazione.CoperturaFurto.PercentualeScontoTecnico
                'Abitazione.CoperturaDanniFurtoEsterno.PercentualeScontoTecnico = Abitazione.CoperturaFurto.PercentualeScontoTecnico
            Next

            If numeroAnni > 1 Then
                PercentualeScontoPoliennalita = numeroAnni
                If PercentualeScontoPoliennalita > 10 Then PercentualeScontoPoliennalita = 10
            Else
                PercentualeScontoPremioUnicoAnticipato = 0D
            End If
            ' s = 1 - (1-s1)(1-s2)= s1 + s2 - s1*s2

            SezioneDanniBeni.PercentualeScontoTecnico = 1 - (1 - PercentualeScontoPoliennalita / 100) * (1 - PercentualeScontoPluralitaSezioni / 100) * (1 - PercentualeScontoPremioUnicoAnticipato / 100)
            SezioneFurto.PercentualeScontoTecnico = SezioneDanniBeni.PercentualeScontoTecnico
            SezioneProtezioneEmergenza.PercentualeScontoTecnico = SezioneDanniBeni.PercentualeScontoTecnico
            SezioneDanniTerzi.PercentualeScontoTecnico = SezioneDanniBeni.PercentualeScontoTecnico
            SezioneProtezioneBenessere.PercentualeScontoTecnico = SezioneDanniBeni.PercentualeScontoTecnico
            SezioneProtezioneFamiglia.PercentualeScontoTecnico = SezioneDanniBeni.PercentualeScontoTecnico

            SezioneAssistenza.PercentualeScontoTecnico = 1 - (1 - PercentualeScontoPoliennalita / 100) * (1 - PercentualeScontoPremioUnicoAnticipato / 100)
            SezioneAssistenzaPlus.PercentualeScontoTecnico = SezioneAssistenza.PercentualeScontoTecnico

            SezioneCatastrofali.PercentualeScontoTecnico = 0
            SezioneTutelaLegale.PercentualeScontoTecnico = 0
            SezioneProtezioneDigitale.PercentualeScontoTecnico = 0
        End Sub

        Public Sub ValidaSezioneDanniBeni()
            SezioneDanniBeni.Stato = StatoCopertura.esclusa
            For Each Abitazione As Abitazione In Abitazioni
                Abitazione.ValidaSezioneDanniBeni()
            Next
        End Sub

        Public Sub ValidaSezioneFurto()
            SezioneFurto.Stato = StatoCopertura.esclusa
            For Each Abitazione As Abitazione In Abitazioni
                Abitazione.ValidaSezioneFurto()
            Next
        End Sub

        Public Sub ValidaSezioneCatastrofali()
            SezioneCatastrofali.Stato = StatoCopertura.esclusa
            For Each Abitazione As Abitazione In Abitazioni
                Abitazione.ValidaSezioneCatastrofali()
            Next
        End Sub

        Public Sub ValidaSezioneAssistenzaPlus()
            SezioneAssistenzaPlus.Stato = StatoCopertura.esclusa
            For Each Abitazione As Abitazione In Abitazioni
                Abitazione.ValidaSezioneAssistenzaPlus()
            Next
        End Sub

        Public Sub ValidaSezioneProtezioneEmergenza()
            SezioneProtezioneEmergenza.Stato = StatoCopertura.esclusa
            For Each Abitazione As Abitazione In Abitazioni
                Abitazione.ValidaSezioneProtezioneEmergenza()
            Next
        End Sub


        Public Sub ValidaSezioneDanniTerzi()
            CoperturaDanniTerziBase.DipendeDa(True)
            SezioneDanniTerzi.Stato = CoperturaDanniTerziBase.Stato

            CoperturaDanniTerziIncendio.DipendeDa(CoperturaDanniTerziBase.IsAttivo)
            CoperturaDanniTerziVitaPrivata.DipendeDa(CoperturaDanniTerziIncendio.IsAttivo)
            CoperturaDanniTerziProprieta.DipendeDa(CoperturaDanniTerziIncendio.IsAttivo)

            CoperturaDanniTerziPlus.DipendeDa(CoperturaDanniTerziIncendio.IsAttivo)
            CoperturaDanniTerziLavoro.DipendeDa(CoperturaDanniTerziIncendio.IsAttivo)
            CoperturaDanniTerziBeB.DipendeDa(CoperturaDanniTerziIncendio.IsAttivo)
            CoperturaDanniTerziLocazione.DipendeDa(CoperturaDanniTerziIncendio.IsAttivo)
            CoperturaDanniTerziStage.DipendeDa(CoperturaDanniTerziIncendio.IsAttivo)

            PartitaDanniTerziIncendio.LimiteAssuntivoMassimo(1000000D)

            CoperturaDanniTerziPlus.Garanzia.Massimale = CoperturaDanniTerziVitaPrivata.Garanzia.Massimale
            CoperturaDanniTerziLavoro.Garanzia.Massimale = CoperturaDanniTerziVitaPrivata.Garanzia.Massimale
            CoperturaDanniTerziBeB.Garanzia.Massimale = CoperturaDanniTerziVitaPrivata.Garanzia.Massimale
            CoperturaDanniTerziStage.Garanzia.Massimale = CoperturaDanniTerziVitaPrivata.Garanzia.Massimale
            CoperturaDanniTerziLocazione.Garanzia.Massimale = CoperturaDanniTerziProprieta.Garanzia.Massimale

            'todo: If Abitazione non è locata Then
            ' CoperturaDanniTerziLocazione.Garanzia.Massimale  = 0
            'end if


            With CoperturaDanniTerziIncendio
                .Tariffa.Tasso = 0.15D / 1000D
            End With

            With CoperturaDanniTerziVitaPrivata
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 500000
            End With
            With CoperturaDanniTerziProprieta
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 500000
            End With

            If CoperturaDanniTerziProprieta.IsAttivo > CoperturaDanniTerziVitaPrivata.IsAttivo Then
                CoperturaDanniTerziProprieta.Garanzia.Massimale = CoperturaDanniTerziVitaPrivata.Garanzia.Massimale
            End If

            Dim indiceMassimale As Integer = IndexOf(CoperturaDanniTerziVitaPrivata.Garanzia.Massimale, {500000, 1000000, 3000000, 4000000})

            If CoperturaDanniTerziBase.IsAttivo Then
                If ProvinciaRCT <> ProvinciaEnum.SiglaXX Then
                ElseIf Not String.IsNullOrEmpty(Cliente.Provincia) Then
                    ProvinciaRCT = Luogo.GetProvinciaBySigla(Cliente.Provincia)
                Else
                    SetRischioDirezione("Indicare la provincia del contraente")
                End If
            End If

            With CType(Decode, P07263DE)
                ClasseTerritorialeRCT = .DecodeProvinciaToClasseTerritorialeRCT(ProvinciaRCT)
            End With

            Dim indiceClasseMassimale As Integer = 4 * (ClasseTerritorialeRCT - 1) + indiceMassimale
            If indiceClasseMassimale < 1 Then indiceClasseMassimale = 1

            If CoperturaDanniTerziVitaPrivata.IsAttivo And CoperturaDanniTerziProprieta.IsAttivo Then
                Dim finale As Decimal = Choose(indiceClasseMassimale, 87D, 109D, 128D, 141D, 61D, 76D, 89D, 97D, 57D, 71D, 83D, 92D)
                'CoperturaDanniTerziVitaPrivata.Tariffa.Base = Choose(indiceClasseMassimale, 0D, 0D, 0D, 0D, 42.7D, 0D, 0D, 0D, 0D, 0D, 0D, 0D)
                'CoperturaDanniTerziProprieta.Tariffa.Base = Choose(indiceClasseMassimale, 0D, 0D, 0D, 0D, 18.3D, 0D, 0D, 0D, 0D, 0D, 0D, 0D)
                CoperturaDanniTerziVitaPrivata.Tariffa.Base = Choose(indiceClasseMassimale, 62D, 78D, 92D, 101D, 44D, 54D, 64D, 69D, 41D, 51D, 59D, 66D)
                CoperturaDanniTerziProprieta.Tariffa.Base = Choose(indiceClasseMassimale, 25D, 31D, 36D, 40D, 17D, 22D, 25D, 28D, 16D, 20D, 24D, 26D)
                CoperturaDanniTerziVitaPrivata.Tariffa.Base = finale * 0.7D
                CoperturaDanniTerziProprieta.Tariffa.Base = finale * 0.3D
            Else
                CoperturaDanniTerziVitaPrivata.Tariffa.Base = Choose(indiceClasseMassimale, 69D, 86D, 101D, 111D, 48D, 60D, 70D, 77D, 45D, 56D, 66D, 72D)
                CoperturaDanniTerziProprieta.Tariffa.Base = Choose(indiceClasseMassimale, 27D, 34D, 40D, 44D, 19D, 24D, 28D, 30D, 18D, 22D, 26D, 29D)
            End If
            CoperturaDanniTerziProprieta.Tariffa.Base *= incrementoPerNumeroUbicazioni

            CoperturaDanniTerziLocazione.Tariffa.Base = Choose(indiceClasseMassimale, 34D, 43D, 50D, 55D, 24D, 30D, 35D, 38D, 22D, 28D, 33D, 36D)
            CoperturaDanniTerziPlus.Tariffa.Base = Choose(indiceMassimale, 9D, 11D, 13D, 14D)
            CoperturaDanniTerziLavoro.Tariffa.Base = Choose(indiceMassimale, 8D, 10D, 12D, 13D)
            CoperturaDanniTerziBeB.Tariffa.Base = Choose(indiceMassimale, 10D, 12D, 18D, 25D)
            CoperturaDanniTerziStage.Tariffa.Base = Choose(indiceMassimale, 20D, 22D, 28D, 37D)

            '            If CoperturaDanniTerziVitaPrivata.IsAttivo And CoperturaDanniTerziProprieta.IsAttivo Then
            '                Dim finale As Decimal = Choose(indiceClasseMassimale, 87D, 109D, 128D, 141D, 61D, 76D, 89D, 97D, 57D, 71D, 83D, 92D)
            '                Dim primo As Decimal = CoperturaDanniTerziVitaPrivata.Tariffa.Base + CoperturaDanniTerziProprieta.Tariffa.Base

            '                Dim delta = (primo - finale)
            '                Dim alfa = (primo - finale) / finale

            '#If DEBUG Then
            '                CoperturaDanniTerziVitaPrivata.Tariffa.Base -= delta * (1 - alfa) '0.883
            '                CoperturaDanniTerziProprieta.Tariffa.Base -= delta * alfa ' 0.117
            '                CoperturaDanniTerziProprieta.Tariffa.Base *= incrementoPerNumeroUbicazioni
            '#Else
            '                ScontoPerProprietaPiuVitaPrivata.LordoDaScontare = primo
            '                ScontoPerProprietaPiuVitaPrivata.PecentualeSconto = 1 - coefficiente
            '                ScontoPerProprietaPiuVitaPrivata.NettoDaScontare = primo * (1 - AliquotaImpostaResponsabilitaCivile)
            '                ScontoPerProprietaPiuVitaPrivata.Calcola()
            '#End If

            '            Else
            '                ScontoPerProprietaPiuVitaPrivata.Imposta(0D, 0D)
            '            End If

        End Sub

        Public Sub ValidaSezioneTutelaLegale()
            CoperturaTutelaLegaleBase.DipendeDa(SezioneDanniBeni.IsAttivo)
            SezioneTutelaLegale.Stato = CoperturaTutelaLegaleBase.Stato

            CoperturaTutelaLegaleDivorzio.DipendeDa(CoperturaTutelaLegaleBase.IsAttivo)

            With CoperturaTutelaLegaleBase
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 10000
                If .Garanzia.Massimale = 10000 Then
                    .Tariffa.Base = 55D
                ElseIf .Garanzia.Massimale = 20000 Then
                    .Tariffa.Base = 89D
                Else
                    .Tariffa.Base = 0D
                End If
                .Tariffa.Base *= incrementoPerNumeroUbicazioni
            End With

            With CoperturaTutelaLegaleDivorzio
                .Garanzia.Massimale = CoperturaTutelaLegaleBase.Garanzia.Massimale
                If .Garanzia.Massimale = 10000 Then
                    .Tariffa.Base = 15D
                ElseIf .Garanzia.Massimale = 20000 Then
                    .Tariffa.Base = 25D
                Else
                    .Tariffa.Base = 0D
                End If
                .Tariffa.Base *= incrementoPerNumeroUbicazioni
            End With
        End Sub

        Public Sub ValidaSezioneAssistenza()
            If TipoContraenza = TipoContraenzaEnum.PersonaGiudirica Then
                CoperturaAssistenzaBase.Stato = StatoCopertura.Inapplicabile
            ElseIf SezioneDanniBeni.IsAttivo And Not VincoloBancario Then
                CoperturaAssistenzaBase.Stato = StatoCopertura.attiva
            Else
                CoperturaAssistenzaBase.DipendeDa(SezioneDanniBeni.IsAttivo Or SezioneDanniTerzi.IsAttivo Or SezioneFurto.IsAttivo)
            End If

            SezioneAssistenza.Stato = CoperturaAssistenzaBase.Stato
            CoperturaAssistenzaBase.Tariffa.Base = 8D
        End Sub

        Public Sub ValidaSezioneProtezioneDigitale()
            CoperturaProtezioneDigitaleBase.DipendeDa(TipoContraenza = TipoContraenzaEnum.PersonaFisica)
            SezioneProtezioneDigitale.Stato = CoperturaProtezioneDigitaleBase.Stato

            If CoperturaProtezioneDigitaleBase.IsAttivo And Not SezioneDanniBeni.IsAttivo And Not SezioneDanniTerzi.IsAttivo Then
                CoperturaProtezioneDigitaleBase.SetNonDisponibile("Protezione Benessere è acquistabile in abbinamento alla Sezione Danni ai beni e/o Danni a terzi.")
            End If

            CoperturaProtezioneDigitaleBase.Tariffa.Base = 84D
        End Sub

        Public Sub ValidaSezioneProtezioneBenessere()
            With CoperturaProtezioneBenessereBase
                .DipendeDa(TipoContraenza = TipoContraenzaEnum.PersonaFisica)

                If .IsAttivo And Not SezioneDanniBeni.IsAttivo And Not SezioneDanniTerzi.IsAttivo Then
                    .SetNonDisponibile("Protezione Benessere è acquistabile in abbinamento alla Sezione Danni ai beni e/o Danni a terzi.")
                End If

                SezioneProtezioneBenessere.Stato = .Stato
                If .Garanzia.Combinazione = 0 Then
                    .Garanzia.Combinazione = 1500
                End If

                .Garanzia.Massimale = .Garanzia.Combinazione

                If .Garanzia.Combinazione = 1500 Then
                    .Tariffa.Base = 30D
                Else
                    .Tariffa.Base = 60D
                End If

            End With
        End Sub

        Public Sub ValidaSezioneProtezioneFamiglia()
            CoperturaProtezioneFamigliaBase.DipendeDa(TipoContraenza = TipoContraenzaEnum.PersonaFisica)
            If CoperturaProtezioneFamigliaBase.IsAttivo And Not SezioneDanniBeni.IsAttivo And Not SezioneDanniTerzi.IsAttivo Then
                CoperturaProtezioneFamigliaBase.SetNonDisponibile("Protezione Benessere è acquistabile in abbinamento alla Sezione Danni ai beni e/o Danni a terzi.")
            End If

            SezioneProtezioneFamiglia.Stato = CoperturaProtezioneFamigliaBase.Stato
            CoperturaProtezioneFamigliaBase.Tariffa.Base = 22
        End Sub

        Public Sub AggiungiAbitazione(ByRef Abitazione As Abitazione)
            Abitazioni.Add(Abitazione)
            CoperturaDanniBeni.Coperture.Add(Abitazione.CoperturaDanniBeni)
            CoperturaFurto.Coperture.Add(Abitazione.CoperturaFurto)
            CoperturaCatastrofali.Coperture.Add(Abitazione.CoperturaCatastrofali)
            CoperturaAssistenzaPlus.Coperture.Add(Abitazione.CoperturaAssistenzaPlus)
            CoperturaProtezioneEmergenza.Coperture.Add(Abitazione.CoperturaProtezioneEmergenza)
        End Sub

        Public Sub RimuoviAbitazione(ByRef Abitazione As Abitazione)
            Abitazioni.Remove(Abitazione)
            CoperturaDanniBeni.Coperture.Remove(Abitazione.CoperturaDanniBeni)
            CoperturaFurto.Coperture.Remove(Abitazione.CoperturaFurto)
            CoperturaCatastrofali.Coperture.Remove(Abitazione.CoperturaCatastrofali)
            CoperturaAssistenzaPlus.Coperture.Remove(Abitazione.CoperturaAssistenzaPlus)
            CoperturaProtezioneEmergenza.Coperture.Remove(Abitazione.CoperturaProtezioneEmergenza)
        End Sub

        Public Overrides Sub Stampa(ByVal options As StampaOptions)
            Dim s As New P07263ST()
            Stampato = True
            s.StampaMostraEtInvia(Me, options)
        End Sub

        'ESTENSIONE PER ESSIG
        Public Overrides Function HasEssig() As Boolean
            Return True
        End Function

        Public Overrides Function GetNewPES() As P00000ES
            Return New P07263ES(Me)
        End Function

        Public Overrides Function PrintEssigLog(ByRef params As Dictionary(Of String, Decimal), ByVal ShowAll As Boolean) As String
            Dim logCalcolo As String = vbNewLine
            logCalcolo &= LSet("garanzia", 50) & RSet("essig", 15) & RSet("uniquota", 15) & vbNewLine

            logCalcolo &= PrintRowLog(params, "stadio0.pagina10.assistenzaPremioAnnuale.value", "ASSISTENZA - Assistenza", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.abitazionePremioAnnuale.value", "DANNI AI BENI - Abitazione", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio0.pagina10.danniTerziIncendioPremioAnnuale.value", "DANNI A TERZI - Danni a Terzi da Incendio", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio0.pagina10.garanziaPlusPremioAnnuale.value", "DANNI A TERZI - Garanzie Plus", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio0.pagina10.lavoriMalattiePremioAnnuale.value", "DANNI A TERZI - Lavoratori domestici e malattie professionali", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio0.pagina10.proprietaAbitazionePremioAnnuale.value", "DANNI A TERZI - Proprietà dell'Abitazione", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.vetriPremioAnnuale.value", "DANNI AI BENI - Vetri e cristalli", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.contenutoPremioAnnuale.value", "DANNI AI BENI - Contenuto", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.danniAcquaAbitazionePremioAnnuale.value+stadio1.pagina10.danniAcquaContenutoPremioAnnuale.value", "DANNI AI BENI - Danni da acqua", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.eventiAtmosfericiAbitazionePremioAnnuale.value+stadio1.pagina10.eventiAtmosfericiContenutoPremioAnnuale.value", "DANNI AI BENI - Fenomeni Atmosferici", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.fenomeniElettriciAbitazionePremioAnnuale.value+stadio1.pagina10.fenomeniElettriciContenutoPremioAnnuale.value", "DANNI AI BENI - Fenomeni elettrici", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.fenomeniElettriciPannelliPremioAnnuale.value", "DANNI AI BENI - Fenomeni Elettrici su pannelli solari e fotovoltaici", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.garanziaPlusAbitazionePremioAnnuale.value+stadio1.pagina10.garanziaPlusContenutoPremioAnnuale.value", "DANNI AI BENI - Garanzia Plus", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.perditeAcquaPremioAnnuale.value", "DANNI AI BENI - Perdite occulte d'acqua", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.ricercaGuastoPremioAnnuale.value", "DANNI AI BENI - Ricerca Guasto", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.terremotoAbitazionePremioAnnuale.value", "EVENTI CATASTROFALI - Terremoto Abitazione", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.terremotoContenutoPremioAnnuale.value", "EVENTI CATASTROFALI - Terremoto Contenuto", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.alluvioneAbitazionePremioAnnuale.value", "EVENTI CATASTROFALI - Alluvione Abitazione", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.alluvioneContenutoPremioAnnuale.value", "EVENTI CATASTROFALI - Alluvione Contenuto", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio0.pagina10.protezioneBenesserePremioAnnuale.value", "PACK PROTEZIONE BENESSERE - Pack Protezione Benessere", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio0.pagina10.protezioneDigitalePremioAnnuale.value+stadio0.pagina10.protezioneLegalePremioAnnuale.value", "PACK PROTEZIONE DIGITALE - Pack Protezione digitale", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio0.pagina10.protezioneFamigliaPremioAnnuale.value", "PACK PROTEZIONE FAMIGLIA - Pack Protezione Famiglia", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.protezioneEmergenzaPremioAnnuale.value", "PACK EMERGENZA - Pack Emergenza", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio0.pagina10.stagePremioAnnuale.value", "DANNI A TERZI - Stage e tirocini", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio0.pagina10.vitaPrivataPremioAnnuale.value", "DANNI A TERZI - Vita privata", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.contenutoFurtoPremioAnnuale.value", "FURTO E RAPINA - Contenuto", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.furtoEsternoPremioAnnuale.value", "FURTO E RAPINA - Furto, Scippo e Rapina all' esterno dell'abitazione", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.furtoPannelliPremioAnnuale.value", "FURTO E RAPINA - Furto e Rapina Pannelli solari e fotovoltaici", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.furtoSociopoliticoPremioAnnuale.value", "FURTO E RAPINA - Furto e Rapina causati da eventi sociopolitici", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.garanziaPlusPremioAnnuale.value", "FURTO E RAPINA - Garanzia Plus", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.valoriCustoditiPremioAnnuale.value", "FURTO E RAPINA - Preziosi e Valori nei mezzi di custodia", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio1.pagina10.valoriNonCustoditiPremioAnnuale.value", "FURTO E RAPINA - Preziosi e Valori ovunque posti", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio0.pagina10.tutelaLegalePremioAnnuale.value", "TUTELA LEGALE - Garanzia base", ShowAll)
            logCalcolo &= PrintRowLog(params, "stadio0.pagina10.divorzioPremioAnnuale.value", "TUTELA LEGALE - Separazione e Divorzio", ShowAll)

            Return logCalcolo
        End Function
    End Class
End Namespace
