Namespace P02229
    <Serializable()> Public Class YouIngegnereArchitetto
        Inherits Prodotto

        Public AttivitaProfessionale As AttivitaProfessionaleEnum
        Public FasceIntroiti As FasceIntroitiEnum
        Public IncendioContenuto As IncendioContenutoEnum
        Public IncendioRicorsoTerzi As IncendioRicorsoTerziEnum

        Public ScontoSostituzionePolizza As New CoperturaSingola(New Partita(TipoPartita.ScontoSostituzionePolizza), New Garanzia(TipoGaranzia.ScontoSostituzionePolizza))

        'aliquote

        'sezioni
        Public SezioneResponsabilitaCivile As New Sezione(Me, TipoSezione.ResponsabilitaCivile)
        Public SezioneIncendio As New Sezione(Me, TipoSezione.Incendio)
        Public SezioneTutelaLegale As New Sezione(Me, TipoSezione.TutelaLegale)
        Public SezioneInterruzioneProfessione As New Sezione(Me, TipoSezione.InterruzioneProfessione)
        Public SezioneSconto As New Sezione(Me, TipoSezione.ScontoSostituzionePolizza)

        'ResponsabilitaCivile
        Public PartitaResponsabilitaCivileBase As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaResponsabilitaCivileBase As New CoperturaSingola(PartitaResponsabilitaCivileBase, New Garanzia(TipoGaranzia.ResponsabilitaCivileBase))
        Public PartitaResponsabilitaCivileBasePremio As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaResponsabilitaCivileMancataRispondenza As New CoperturaSingola(PartitaResponsabilitaCivileBasePremio, New Garanzia(TipoGaranzia.ResponsabilitaCivileMancataRispondenza))
        Public CoperturaResponsabilitaCivileFaldaFreatica As New CoperturaSingola(PartitaResponsabilitaCivileBasePremio, New Garanzia(TipoGaranzia.ResponsabilitaCivileFaldaFreatica))
        Public CoperturaResponsabilitaCivileDLgs81_2008 As New CoperturaSingola(PartitaResponsabilitaCivileBasePremio, New Garanzia(TipoGaranzia.ResponsabilitaCivileDLgs81_2008))
        Public CoperturaResponsabilitaCivileFranchigia As New CoperturaSingola(PartitaResponsabilitaCivileBasePremio, New Garanzia(TipoGaranzia.ResponsabilitaCivileFranchigia))
        Public CoperturaResponsabilitaCivileScontoDiff As New CoperturaSingola(PartitaResponsabilitaCivileBasePremio, New Garanzia(TipoGaranzia.ResponsabilitaCivileScontoDiff))
        Public ResponsabilitaCivileScontoMax As Decimal = 0D

        'Incendio
        Public PartitaIncendioBase As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioBase As New CoperturaSingola(PartitaIncendioBase, New Garanzia(TipoGaranzia.IncendioBase))

        'TutelaLegale
        Public PartitaTutelaLegaleBase As New Partita(TipoPartita.TutelaLegale)
        Public CoperturaTutelaLegaleBase As New CoperturaSingola(PartitaTutelaLegaleBase, New Garanzia(TipoGaranzia.TutelaLegaleBase))

        'InterruzioneProfessione
        Public PartitaInterruzioneProfessioneBase As New Partita(TipoPartita.InterruzioneProfessione)
        Public CoperturaInterruzioneProfessioneBase As New CoperturaSingola(PartitaInterruzioneProfessioneBase, New Garanzia(TipoGaranzia.InterruzioneProfessioneBase))

        Public Sub New()
            'Caratteristiche
            CodiceRamoPolizza = "122"
            CodiceProdotto = TipoProdotto.YouIngegnereArchitetto
            DescrizioneProdotto = P00000DE.DecodeProdotto(CodiceProdotto)
            Edizione = "01.04.2014"
            DataEntrataVigore = "01/04/2014"

            DurataContrattualeMinimaInAnni = 1
            DurataContrattualeMassimaInAnni = 1
            PeriodoMoraInGiorni = 15
            EmissioneAppendici = False
            TacitoRinnovo = True

            ContraenzaPersonaGiuridica = True
            ContraenzaPersonaFisica = True
            PremioMinimoPrimaRata = 0D
            PremioMinimoRataSuccessiva = 0D

            'I tassi e i premi della presente tariffa sono comprensivi di imposte e oneri parafiscali.
            BaseTasse = UniQuota.BaseTasse.BaseLorda

            'sezioni
            Sezioni.Add(SezioneResponsabilitaCivile)
            Sezioni.Add(SezioneIncendio)
            Sezioni.Add(SezioneTutelaLegale)
            Sezioni.Add(SezioneInterruzioneProfessione)
            Sezioni.Add(SezioneSconto)

            'aliquote
            SezioneResponsabilitaCivile.AliquotaImposta = AliquotaImpostaResponsabilitaCivile
            SezioneIncendio.AliquotaImposta = AliquotaImpostaIncendio
            SezioneTutelaLegale.AliquotaImposta = AliquotaImpostaTutelaLegale
            SezioneInterruzioneProfessione.AliquotaImposta = AliquotaImpostaResponsabilitaCivile

            'sezione - coperture
            SezioneResponsabilitaCivile.AddCopertura(CoperturaResponsabilitaCivileBase)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaResponsabilitaCivileMancataRispondenza)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaResponsabilitaCivileFaldaFreatica)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaResponsabilitaCivileDLgs81_2008)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaResponsabilitaCivileFranchigia)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaResponsabilitaCivileScontoDiff)
            SezioneIncendio.AddCopertura(CoperturaIncendioBase)
            SezioneTutelaLegale.AddCopertura(CoperturaTutelaLegaleBase)
            SezioneInterruzioneProfessione.AddCopertura(CoperturaInterruzioneProfessioneBase)

            SezioneSconto.AddCopertura(ScontoSostituzionePolizza)
        End Sub

        Public Overrides Sub Valida()
            ValidaCondizioniGenerali()
            ValidaSconti()
            ValidaSezioneResponsabilitaCivile()
            ValidaSezioneIncendio()
            ValidaSezioneTutelaLegale()
            ValidaSezioneInterruzioneProfessione()
        End Sub

        Public Sub ValidaCondizioniGenerali()
        End Sub

        Public Sub ValidaSconti()
        End Sub

        Public Sub ValidaSezioneResponsabilitaCivile()
            CoperturaResponsabilitaCivileBase.DipendeDa(True)
            SezioneResponsabilitaCivile.Stato = CoperturaResponsabilitaCivileBase.Stato

            CoperturaResponsabilitaCivileMancataRispondenza.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo)
            CoperturaResponsabilitaCivileFaldaFreatica.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo)
            CoperturaResponsabilitaCivileDLgs81_2008.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo)
            CoperturaResponsabilitaCivileFranchigia.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo)
            ScontoSostituzionePolizza.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo)

            If AttivitaProfessionale = 0 Then
                AttivitaProfessionale = AttivitaProfessionaleEnum.architetto
            End If

            If AttivitaProfessionale = AttivitaProfessionaleEnum.studioAssociato _
            Or AttivitaProfessionale = AttivitaProfessionaleEnum.studioAssociatoAttivitaPrivata Then
                If FasceIntroiti < FasceIntroitiEnum.Fino125000 Then
                    FasceIntroiti = FasceIntroitiEnum.Fino125000
                End If
            Else
                If FasceIntroiti < FasceIntroitiEnum.TariffaGiovani Then
                    FasceIntroiti = FasceIntroitiEnum.TariffaGiovani
                End If
            End If

            With CoperturaResponsabilitaCivileBase
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 1000000D

                If AttivitaProfessionale = AttivitaProfessionaleEnum.architettoProgettista _
                Or AttivitaProfessionale = AttivitaProfessionaleEnum.ingegnereProgettista Then
                    If .Garanzia.Massimale = 1000000D Then
                        .Tariffa.Base = CDec(Choose(FasceIntroiti, 563D, 853D, 870D, 1405D, 2161D, 2268D, 2327D, 3012D, 3805D))
                    ElseIf .Garanzia.Massimale = 2000000D Then
                        .Tariffa.Base = CDec(Choose(FasceIntroiti, 675D, 1023D, 1043D, 1685D, 2592D, 2720D, 2791D, 3612D, 4564D))
                    ElseIf .Garanzia.Massimale = 3000000D Then
                        .Tariffa.Base = CDec(Choose(FasceIntroiti, 757D, 1151D, 1176D, 1896D, 2919D, 3064D, 3140D, 4066D, 5137D))
                    ElseIf .Garanzia.Massimale = 5000000D Then
                        .Tariffa.Base = CDec(Choose(FasceIntroiti, 818D, 1236D, 1259D, 2037D, 3131D, 3291D, 3376D, 4370D, 5517D))
                    End If
                Else
                    If .Garanzia.Massimale = 1000000D Then
                        .Tariffa.Base = CDec(Choose(FasceIntroiti, 662D, 1003D, 1023D, 1653D, 2542D, 2668D, 2738D, 3544D, 4477D))
                    ElseIf .Garanzia.Massimale = 2000000D Then
                        .Tariffa.Base = CDec(Choose(FasceIntroiti, 794D, 1203D, 1277D, 1983D, 3049D, 3200D, 3284D, 4250D, 5370D))
                    ElseIf .Garanzia.Massimale = 3000000D Then
                        .Tariffa.Base = CDec(Choose(FasceIntroiti, 891D, 1354D, 1383D, 2231D, 3434D, 3605D, 3694D, 4783D, 6044D))
                    ElseIf .Garanzia.Massimale = 5000000D Then
                        .Tariffa.Base = CDec(Choose(FasceIntroiti, 962D, 1454D, 1481D, 2396D, 3684D, 3872D, 3972D, 5141D, 6491D))
                    End If
                End If
            End With

            PartitaResponsabilitaCivileBasePremio.SommaAssicurata = CoperturaResponsabilitaCivileBase.PremioCrudo

            With CoperturaResponsabilitaCivileMancataRispondenza
                .Tariffa.Tasso = -25D / 100D
            End With

            With CoperturaResponsabilitaCivileFaldaFreatica
                .Tariffa.Tasso = -5D / 100D
            End With

            With CoperturaResponsabilitaCivileDLgs81_2008
                .Tariffa.Tasso = -15D / 100D
            End With

            With CoperturaResponsabilitaCivileFranchigia
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 10000D
                If .Garanzia.Franchigia = 10000D Then
                    .Tariffa.Tasso = -10D / 100D
                ElseIf .Garanzia.Franchigia = 15000D Then
                    .Tariffa.Tasso = -20D / 100D
                ElseIf .Garanzia.Franchigia = 20000D Then
                    .Tariffa.Tasso = -30D / 100D
                End If
            End With

            With CoperturaResponsabilitaCivileScontoDiff
                Dim scontoMax As Decimal = 0.55D * CoperturaResponsabilitaCivileBase.PremioCrudo
                Dim scontoSel As Decimal = -CoperturaResponsabilitaCivileMancataRispondenza.PremioAttivoCrudo _
                                         - CoperturaResponsabilitaCivileFaldaFreatica.PremioAttivoCrudo _
                                         - CoperturaResponsabilitaCivileDLgs81_2008.PremioAttivoCrudo _
                                         - CoperturaResponsabilitaCivileFranchigia.PremioAttivoCrudo

                ResponsabilitaCivileScontoMax = scontoMax
                If scontoSel > scontoMax Then
                    .Tariffa.Base = scontoSel - scontoMax
                    CoperturaResponsabilitaCivileScontoDiff.Stato = StatoCopertura.attiva
                Else
                    .Tariffa.Base = 0D
                    CoperturaResponsabilitaCivileScontoDiff.Stato = StatoCopertura.Inapplicabile
                End If
            End With
        End Sub

        Public Sub ValidaSezioneIncendio()
            CoperturaIncendioBase.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo)
            SezioneIncendio.Stato = CoperturaIncendioBase.Stato


            With CoperturaIncendioBase
                If IncendioContenuto = 0 Then IncendioContenuto = IncendioContenutoEnum.M12500D
                If IncendioRicorsoTerzi = 0 Then IncendioRicorsoTerzi = IncendioRicorsoTerziEnum.M150000D

                If IncendioContenuto = IncendioContenutoEnum.M12500D Then
                    .Tariffa.Base = 15D
                ElseIf IncendioContenuto = IncendioContenutoEnum.M25000D Then
                    .Tariffa.Base = 25D
                End If
                If IncendioRicorsoTerzi = IncendioRicorsoTerziEnum.M150000D Then
                    .Tariffa.Base += 30D
                ElseIf IncendioRicorsoTerzi = IncendioRicorsoTerziEnum.M250000D Then
                    .Tariffa.Base += 45D
                End If
            End With


        End Sub

        Public Sub ValidaSezioneTutelaLegale()
            CoperturaTutelaLegaleBase.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo)
            SezioneTutelaLegale.Stato = CoperturaTutelaLegaleBase.Stato


            With CoperturaTutelaLegaleBase
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 10000D
                If .Garanzia.Massimale = 10000D Then
                    .Tariffa.Base = 150D
                ElseIf .Garanzia.Massimale = 20000D Then
                    .Tariffa.Base = 185D
                ElseIf .Garanzia.Massimale = 30000D Then
                    .Tariffa.Base = 225D
                End If
            End With


        End Sub

        Public Sub ValidaSezioneInterruzioneProfessione()
            CoperturaInterruzioneProfessioneBase.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo)
            SezioneInterruzioneProfessione.Stato = CoperturaInterruzioneProfessioneBase.Stato
            With CoperturaInterruzioneProfessioneBase
                .Tariffa.Base = 50D
            End With
        End Sub

        Public Overrides Sub CalcolaTotaliPre()
            ScontoSostituzionePolizza.Tariffa.Tasso = -0.15D
            ScontoSostituzionePolizza.Partita.SommaAssicurata = SezioneResponsabilitaCivile.ListinoLordo _
                                                              + SezioneIncendio.ListinoLordo _
                                                              + SezioneTutelaLegale.ListinoLordo _
                                                              + SezioneInterruzioneProfessione.ListinoLordo

            SezioneSconto.CalcolaCoperture()
            SezioneSconto.CalcolaTotali()
        End Sub

        Public Overrides Sub Stampa(ByVal options As StampaOptions)
            Dim s As New P02229ST
            Stampato = True
            s.StampaMostraEtInvia(Me, options)
        End Sub

    End Class
End Namespace
