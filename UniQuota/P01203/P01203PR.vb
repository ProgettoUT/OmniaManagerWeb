Namespace P01203
    <Serializable()> Public Class Circolazione
        Inherits Prodotto

        <NonSerialized()> Public Tabelle As P01203TR

        Public TipologiaVeicolo As TipologiaVeicoloEnum
        Public InfortuniScelta As InfortuniSceltaEnum
        Public InfortuniForma As InfortuniFormaEnum
        Public ScontoPoliennale As ScontoPoliennaleEnum
        Public TipoSoggetto As TipoSoggettoEnum

        'aliquote

        'sezioni
        Public SezioneInfortuni As New Sezione(Me, TipoSezione.Infortuni)
        Public SezioneSalvaCircolazione As New Sezione(Me, TipoSezione.SalvaCircolazione)
        Public SezioneAssistenza As New Sezione(Me, TipoSezione.Assistenza)
        Public SezioneSconti As New Sezione(Me, TipoSezione.Sconti)

        'Infortuni
        Public PartitaInfortuniBase As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniBase As New CoperturaSingola(PartitaInfortuniBase, New Garanzia(TipoGaranzia.InfortuniBase))
        Public PartitaInfortuniMorte As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniMorte As New CoperturaSingola(PartitaInfortuniMorte, New Garanzia(TipoGaranzia.InfortuniMorte), True)
        Public PartitaInfortuniIP As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniIP As New CoperturaSingola(PartitaInfortuniIP, New Garanzia(TipoGaranzia.InfortuniIP), True)
        Public PartitaInfortuniComa As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniComa As New CoperturaSingola(PartitaInfortuniComa, New Garanzia(TipoGaranzia.InfortuniComa), True)

        Public PartitaInfortuniSpeseMediche As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniSpeseMediche As New CoperturaSingola(PartitaInfortuniSpeseMediche, New Garanzia(TipoGaranzia.InfortuniSpeseMediche), True)
        Public PartitaInfortuniRicoveroConvalescenza As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniRicovero As New CoperturaSingola(PartitaInfortuniRicoveroConvalescenza, New Garanzia(TipoGaranzia.InfortuniRicovero), True)
        Public CoperturaInfortuniConvalescenza As New CoperturaSingola(PartitaInfortuniRicoveroConvalescenza, New Garanzia(TipoGaranzia.InfortuniConvalescenza), True)
        Public PartitaInfortuniImmobilizzazione As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniImmobilizzazione As New CoperturaSingola(PartitaInfortuniImmobilizzazione, New Garanzia(TipoGaranzia.InfortuniImmobilizzazione), True)

        Public PartitaInfortuniTariffaIP As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniTabellaINAIL As New CoperturaSingola(PartitaInfortuniTariffaIP, New Garanzia(TipoGaranzia.InfortuniTabellaINAIL))
        Public CoperturaInfortuniFranchigia3 As New CoperturaSingola(PartitaInfortuniTariffaIP, New Garanzia(TipoGaranzia.InfortuniFranchigia3))
        Public CoperturaInfortuniSuperValutazione As New CoperturaSingola(PartitaInfortuniTariffaIP, New Garanzia(TipoGaranzia.InfortuniSuperValutazione))

        'SalvaCircolazione
        Public PartitaSalvaCircolazioneBase As New Partita(TipoPartita.SalvaCircolazione)
        Public CoperturaSalvaCircolazioneBase As New CoperturaSingola(PartitaSalvaCircolazioneBase, New Garanzia(TipoGaranzia.SalvaCircolazioneBase))

        'Assistenza
        Public PartitaAssistenzaBase As New Partita(TipoPartita.Assistenza)
        Public CoperturaAssistenzaBase As New CoperturaSingola(PartitaAssistenzaBase, New Garanzia(TipoGaranzia.AssistenzaBase))

        'Sconti
        Public PartitaScontiBase As New Partita(TipoPartita.Sconti)
        Public CoperturaScontiBase As New CoperturaSingola(PartitaScontiBase, New Garanzia(TipoGaranzia.ScontiBase))

        Public Sub New()
            'Caratteristiche
            CodiceRamoPolizza = 77
            CodiceProdotto = TipoProdotto.Circolazione
            DescrizioneProdotto = "UnipolSai Infortuni Circolazione"
            Edizione = "15.03.2015"
            DataEntrataVigore = "15/03/2015"

            DurataContrattualeMinimaInAnni = 1
            DurataContrattualeMassimaInAnni = 10
            PeriodoMoraInGiorni = 15
            EmissioneAppendici = False
            TacitoRinnovo = True

            ContraenzaPersonaGiuridica = True
            ContraenzaPersonaFisica = True
            PremioMinimoAnnuoNetto = 48

            FrazionamentoInteressiSemestrale = 0D
            FrazionamentoInteressiMensile = 0D

            'I tassi e i premi della presente tariffa sono comprensivi di imposte e oneri parafiscali.
            BaseTasse = UniQuota.BaseTasse.BaseLorda

            'sezioni
            Sezioni.Add(SezioneInfortuni)
            Sezioni.Add(SezioneSalvaCircolazione)
            Sezioni.Add(SezioneAssistenza)
            Sezioni.Add(SezioneSconti)

            'aliquote
            SezioneInfortuni.AliquotaImposta = 0.025D
            SezioneSalvaCircolazione.AliquotaImposta = 0.2225D
            SezioneAssistenza.AliquotaImposta = 0.1D
            SezioneSconti.AliquotaImposta = 0.025D

            'sezione - coperture
            SezioneInfortuni.AddCopertura(CoperturaInfortuniBase)
            SezioneInfortuni.AddCopertura(CoperturaInfortuniMorte)
            SezioneInfortuni.AddCopertura(CoperturaInfortuniIP)
            SezioneInfortuni.AddCopertura(CoperturaInfortuniComa)
            SezioneInfortuni.AddCopertura(CoperturaInfortuniSpeseMediche)
            SezioneInfortuni.AddCopertura(CoperturaInfortuniRicovero)
            SezioneInfortuni.AddCopertura(CoperturaInfortuniConvalescenza)
            SezioneInfortuni.AddCopertura(CoperturaInfortuniImmobilizzazione)
            SezioneInfortuni.AddCopertura(CoperturaInfortuniTabellaINAIL)
            SezioneInfortuni.AddCopertura(CoperturaInfortuniFranchigia3)
            SezioneInfortuni.AddCopertura(CoperturaInfortuniSuperValutazione)

            SezioneSalvaCircolazione.AddCopertura(CoperturaSalvaCircolazioneBase)
            SezioneAssistenza.AddCopertura(CoperturaAssistenzaBase)
            SezioneSconti.AddCopertura(CoperturaScontiBase)
        End Sub

        Public Overrides Sub Inizializza()
            MyBase.Inizializza()
            Tabelle = New P01203TR()
        End Sub

        Public Overrides Sub Valida()
            ValidaSezioneInfortuni()
            ValidaSezioneSalvaCircolazione()
            ValidaSezioneAssistenza()
            ValidaSezioneSconti()
        End Sub


        Public Sub ValidaSezioneInfortuni()
            Dim isCapitaliLiberi As Boolean = (InfortuniForma = InfortuniFormaEnum.CapitaliLiberi)

            CoperturaInfortuniBase.DipendeDa(True)
            SezioneInfortuni.Stato = CoperturaInfortuniBase.Stato

            If TipoSoggetto = 0 Then TipoSoggetto = TipoSoggettoEnum.PersonaFisica
            If TipoSoggetto = TipoSoggettoEnum.PersonaGiuridica And InfortuniScelta = InfortuniSceltaEnum.SceltaFamiglia Then
                InfortuniScelta = InfortuniSceltaEnum.SceltaPersona
            End If

            SezioneInfortuni.EscludiFlex = Not isCapitaliLiberi

            If isCapitaliLiberi Then
                CoperturaInfortuniMorte.DipendeDa(CoperturaInfortuniBase.IsAttivo)
                CoperturaInfortuniIP.DipendeDa(CoperturaInfortuniBase.IsAttivo)
                CoperturaInfortuniRicovero.DipendeDa(CoperturaInfortuniIP.IsAttivo)
                CoperturaInfortuniConvalescenza.DipendeDa(CoperturaInfortuniRicovero.IsAttivo)
                CoperturaInfortuniImmobilizzazione.DipendeDa(CoperturaInfortuniIP.IsAttivo)
                CoperturaInfortuniSpeseMediche.DipendeDa(CoperturaInfortuniIP.IsAttivo)
            Else
                CoperturaInfortuniMorte.ObbligatoriaDa(CoperturaInfortuniBase.IsAttivo) ' 
                CoperturaInfortuniIP.ObbligatoriaDa(CoperturaInfortuniBase.IsAttivo)
                CoperturaInfortuniRicovero.ObbligatoriaDa(CoperturaInfortuniBase.IsAttivo And Choose(InfortuniForma, 0, 0, 0, 1, 0, 1, 0, 1))
                CoperturaInfortuniConvalescenza.ObbligatoriaDa(CoperturaInfortuniRicovero.IsAttivo)
                CoperturaInfortuniImmobilizzazione.ObbligatoriaDa(CoperturaInfortuniRicovero.IsAttivo)
                CoperturaInfortuniSpeseMediche.ObbligatoriaDa(CoperturaInfortuniRicovero.IsAttivo)

                CoperturaInfortuniMorte.Partita.SommaAssicurata = 1000D * Choose(InfortuniForma, 30D, 50D, 50D, 50D, 50D, 50D, 100D, 150D)
                CoperturaInfortuniIP.Partita.SommaAssicurata = 1000D * Choose(InfortuniForma, 50D, 50D, 75D, 75D, 100D, 100D, 100D, 250D)
                CoperturaInfortuniRicovero.Partita.SommaAssicurata = Choose(InfortuniForma, 0D, 0D, 0D, 40D, 0D, 40D, 0D, 80D)
                CoperturaInfortuniConvalescenza.Partita.SommaAssicurata = Choose(InfortuniForma, 0D, 0D, 0D, 40D, 0D, 40D, 0D, 80D)
                CoperturaInfortuniImmobilizzazione.Partita.SommaAssicurata = Choose(InfortuniForma, 0D, 0D, 0D, 20D, 0D, 20D, 0D, 40D)
                CoperturaInfortuniSpeseMediche.Partita.SommaAssicurata = 100D * Choose(InfortuniForma, 0D, 0D, 0D, 25D, 0D, 25D, 0D, 50D)
            End If

            CoperturaInfortuniComa.ObbligatoriaDa(CoperturaInfortuniMorte.IsAttivo Or CoperturaInfortuniIP.IsAttivo)

            CoperturaInfortuniTabellaINAIL.DipendeDa(CoperturaInfortuniIP.IsAttivo And isCapitaliLiberi)
            CoperturaInfortuniFranchigia3.DipendeDa(CoperturaInfortuniIP.IsAttivo And isCapitaliLiberi)
            CoperturaInfortuniSuperValutazione.DipendeDa(CoperturaInfortuniIP.IsAttivo And isCapitaliLiberi)

            CoperturaInfortuniComa.Partita.SommaAssicurata = 10000D

            If isCapitaliLiberi Then
                If InfortuniScelta = InfortuniSceltaEnum.SceltaVeicolo And _
                    IsOneOf(TipologiaVeicolo, TipologiaVeicoloEnum.Motocicli, TipologiaVeicoloEnum.Ciclomotori) Then
                    PartitaInfortuniMorte.LimiteAssuntivoMassimo(250000D)
                    PartitaInfortuniIP.LimiteAssuntivoMassimo(250000D)

                    PartitaInfortuniRicoveroConvalescenza.LimiteAssuntivoMassimo(150D)
                    PartitaInfortuniRicoveroConvalescenza.LimiteAssuntivoMassimo(0.0004 * (CoperturaInfortuniMorte.SommaAssicurataAttiva + CoperturaInfortuniIP.SommaAssicurataAttiva))

                    PartitaInfortuniImmobilizzazione.LimiteAssuntivoMassimo(100D)
                    PartitaInfortuniImmobilizzazione.LimiteAssuntivoMassimo(0.0002 * (CoperturaInfortuniMorte.SommaAssicurataAttiva + CoperturaInfortuniIP.SommaAssicurataAttiva))
                    PartitaInfortuniImmobilizzazione.LimiteAssuntivoMassimo(200D - CoperturaInfortuniRicovero.SommaAssicurataAttiva)

                    PartitaInfortuniSpeseMediche.LimiteAssuntivoMassimo(0.04 * (CoperturaInfortuniMorte.SommaAssicurataAttiva + CoperturaInfortuniIP.SommaAssicurataAttiva))
                    PartitaInfortuniSpeseMediche.LimitiAssuntivi(2500D, 10000D)
                Else
                    PartitaInfortuniMorte.LimiteAssuntivoMassimo(400000D)
                    PartitaInfortuniIP.LimiteAssuntivoMassimo(300000D)

                    PartitaInfortuniRicoveroConvalescenza.LimiteAssuntivoMassimo(200D)
                    PartitaInfortuniRicoveroConvalescenza.LimiteAssuntivoMassimo(0.0004 * (CoperturaInfortuniMorte.SommaAssicurataAttiva + CoperturaInfortuniIP.SommaAssicurataAttiva))

                    PartitaInfortuniImmobilizzazione.LimiteAssuntivoMassimo(150D)
                    PartitaInfortuniImmobilizzazione.LimiteAssuntivoMassimo(0.0002 * (CoperturaInfortuniMorte.SommaAssicurataAttiva + CoperturaInfortuniIP.SommaAssicurataAttiva))
                    PartitaInfortuniImmobilizzazione.LimiteAssuntivoMassimo(200D - CoperturaInfortuniRicovero.SommaAssicurataAttiva)

                    PartitaInfortuniSpeseMediche.LimiteAssuntivoMassimo(0.04 * (CoperturaInfortuniMorte.SommaAssicurataAttiva + CoperturaInfortuniIP.SommaAssicurataAttiva))
                    PartitaInfortuniSpeseMediche.LimitiAssuntivi(2500D, 20000D)
                End If
            End If

            With CoperturaInfortuniBase
                .AzzeraTariffa()

                If TipologiaVeicolo = 0 Then TipologiaVeicolo = TipologiaVeicoloEnum.Autovettura
                If InfortuniScelta = 0 Then InfortuniScelta = InfortuniSceltaEnum.SceltaPersona
                Dim CategoriaVeicolo As Integer = (TipologiaVeicolo \ 10)


                If CategoriaVeicolo = ClasseRischioVeicoloEnum.ClasseD _
                Or CategoriaVeicolo = ClasseRischioVeicoloEnum.ClasseC Then
                    If isCapitaliLiberi = False Or InfortuniScelta = InfortuniSceltaEnum.SceltaVeicolo Then
                        TipologiaVeicolo = TipologiaVeicoloEnum.Autovettura
                        CategoriaVeicolo = ClasseRischioVeicoloEnum.ClasseA
                    End If
                End If


                CoperturaInfortuniMorte.AzzeraTariffa()
                CoperturaInfortuniIP.AzzeraTariffa()
                CoperturaInfortuniRicovero.AzzeraTariffa()
                CoperturaInfortuniConvalescenza.AzzeraTariffa()
                CoperturaInfortuniImmobilizzazione.AzzeraTariffa()
                CoperturaInfortuniSpeseMediche.AzzeraTariffa()

                If isCapitaliLiberi Then
                    If PartitaInfortuniSpeseMediche.SommaAssicurata < 5000D Then
                        PartitaInfortuniSpeseMediche.SommaAssicurata = (PartitaInfortuniSpeseMediche.SommaAssicurata \ 100) * 100
                    Else
                        PartitaInfortuniSpeseMediche.SommaAssicurata = (PartitaInfortuniSpeseMediche.SommaAssicurata \ 200) * 200
                    End If


                    If InfortuniScelta = InfortuniSceltaEnum.SceltaPersona Then
                        CoperturaInfortuniMorte.Tariffa.Tasso = 0.6D / 1000D
                        CoperturaInfortuniIP.Tariffa.Tasso = 0.75D / 1000D
                        CoperturaInfortuniRicovero.Tariffa.Tasso = 0.25D
                        CoperturaInfortuniConvalescenza.Tariffa.Tasso = 0.25D
                        CoperturaInfortuniImmobilizzazione.Tariffa.Tasso = 0.55D
                        CoperturaInfortuniSpeseMediche.Tariffa.Tasso = IIf(PartitaInfortuniSpeseMediche.SommaAssicurata <= 5000D, 3.9D, 2.75D) / 1000D
                    ElseIf InfortuniScelta = InfortuniSceltaEnum.SceltaFamiglia Then
                        CoperturaInfortuniMorte.Tariffa.Tasso = 1.05D / 1000D
                        CoperturaInfortuniIP.Tariffa.Tasso = 1.35D / 1000D
                        CoperturaInfortuniRicovero.Tariffa.Tasso = 0.45D
                        CoperturaInfortuniConvalescenza.Tariffa.Tasso = 0.45D
                        CoperturaInfortuniImmobilizzazione.Tariffa.Tasso = 1D
                        CoperturaInfortuniSpeseMediche.Tariffa.Tasso = IIf(PartitaInfortuniSpeseMediche.SommaAssicurata <= 5000D, 6.85D, 4.85D) / 1000D
                    ElseIf CategoriaVeicolo = ClasseRischioVeicoloEnum.ClasseA Then
                        CoperturaInfortuniMorte.Tariffa.Tasso = 0.4D / 1000D
                        CoperturaInfortuniIP.Tariffa.Tasso = 0.5D / 1000D
                        CoperturaInfortuniRicovero.Tariffa.Tasso = 0.15D
                        CoperturaInfortuniConvalescenza.Tariffa.Tasso = 0.15D
                        CoperturaInfortuniImmobilizzazione.Tariffa.Tasso = 0.4D
                        CoperturaInfortuniSpeseMediche.Tariffa.Tasso = IIf(PartitaInfortuniSpeseMediche.SommaAssicurata <= 5000D, 2.55D, 1.85D) / 1000D
                    ElseIf CategoriaVeicolo = ClasseRischioVeicoloEnum.ClasseB Then
                        CoperturaInfortuniMorte.Tariffa.Tasso = 0.6D / 1000D
                        CoperturaInfortuniIP.Tariffa.Tasso = 0.75D / 1000D
                        CoperturaInfortuniRicovero.Tariffa.Tasso = 0.2D
                        CoperturaInfortuniConvalescenza.Tariffa.Tasso = 0.3D
                        CoperturaInfortuniImmobilizzazione.Tariffa.Tasso = 0.5D
                        CoperturaInfortuniSpeseMediche.Tariffa.Tasso = IIf(PartitaInfortuniSpeseMediche.SommaAssicurata <= 5000D, 4.05D, 2.55D) / 1000D
                    ElseIf CategoriaVeicolo = ClasseRischioVeicoloEnum.ClasseD Then
                        CoperturaInfortuniMorte.Tariffa.Tasso = 0.9D / 1000D
                        CoperturaInfortuniIP.Tariffa.Tasso = 1.15D / 1000D
                        CoperturaInfortuniRicovero.Tariffa.Tasso = 0.35D
                        CoperturaInfortuniConvalescenza.Tariffa.Tasso = 0.35D
                        CoperturaInfortuniImmobilizzazione.Tariffa.Tasso = 0.9D
                        CoperturaInfortuniSpeseMediche.Tariffa.Tasso = IIf(PartitaInfortuniSpeseMediche.SommaAssicurata <= 5000D, 5.8D, 4.2D) / 1000D
                    ElseIf CategoriaVeicolo = ClasseRischioVeicoloEnum.ClasseC Then
                        CoperturaInfortuniMorte.Tariffa.Tasso = 0.7D / 1000D
                        CoperturaInfortuniIP.Tariffa.Tasso = 0.85D / 1000D
                        CoperturaInfortuniRicovero.Tariffa.Tasso = 0.25D
                        CoperturaInfortuniConvalescenza.Tariffa.Tasso = 0.25D
                        CoperturaInfortuniImmobilizzazione.Tariffa.Tasso = 0.7D
                        CoperturaInfortuniSpeseMediche.Tariffa.Tasso = IIf(PartitaInfortuniSpeseMediche.SommaAssicurata <= 5000D, 4.35D, 3.15D) / 1000D
                    End If
                Else
                    .Tariffa.Base = Tabelle.getPremio(InfortuniScelta, FrazionamentiEnum.Annuale, InfortuniForma, 0)
                End If
            End With
            PartitaInfortuniTariffaIP.SommaAssicurata = CoperturaInfortuniIP.PremioAttivoCrudo
            CoperturaInfortuniTabellaINAIL.Tariffa.Tasso = 0.25D
            CoperturaInfortuniFranchigia3.Tariffa.Tasso = -0.2D
            CoperturaInfortuniSuperValutazione.Tariffa.Tasso = 0.15D

        End Sub

        Public Sub ValidaSezioneSalvaCircolazione()
            CoperturaSalvaCircolazioneBase.DipendeDa(CoperturaInfortuniMorte.IsAttivo Or CoperturaInfortuniIP.IsAttivo)
            SezioneSalvaCircolazione.Stato = CoperturaSalvaCircolazioneBase.Stato

            With CoperturaSalvaCircolazioneBase
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 500
                If .Garanzia.Massimale = 500 Then
                    .Tariffa.Base = 5.5D
                ElseIf .Garanzia.Massimale = 1000 Then
                    .Tariffa.Base = 11D
                ElseIf .Garanzia.Massimale = 2000 Then
                    .Tariffa.Base = 20.5D
                End If
            End With
        End Sub

        Public Sub ValidaSezioneAssistenza()
            CoperturaAssistenzaBase.ObbligatoriaDa(CoperturaInfortuniMorte.IsAttivo Or CoperturaInfortuniIP.IsAttivo)
            SezioneAssistenza.Stato = CoperturaAssistenzaBase.Stato
            CoperturaAssistenzaBase.Tariffa.Base = IIf(InfortuniScelta = InfortuniSceltaEnum.SceltaFamiglia, 8.75D, 5D)
        End Sub

        Public Sub ValidaSezioneSconti()
            CoperturaScontiBase.DipendeDa(CoperturaInfortuniMorte.IsAttivo Or CoperturaInfortuniIP.IsAttivo)
            SezioneSconti.Stato = CoperturaScontiBase.Stato

            With CoperturaScontiBase
                If ScontoPoliennale = 0 Then ScontoPoliennale = ScontoPoliennaleEnum.Anni2
                If InfortuniForma = InfortuniFormaEnum.CapitaliLiberi Then
                    .Tariffa.Base = (1 - ScontoPoliennale) * 0.02D * (CoperturaInfortuniMorte.PremioAttivoCrudo _
                                                                      + CoperturaInfortuniIP.PremioAttivoCrudo _
                                                                      + CoperturaInfortuniRicovero.PremioAttivoCrudo _
                                                                      + CoperturaInfortuniConvalescenza.PremioAttivoCrudo _
                                                                      + CoperturaInfortuniImmobilizzazione.PremioAttivoCrudo _
                                                                      + CoperturaInfortuniSpeseMediche.PremioAttivoCrudo _
                                                                      + CoperturaInfortuniTabellaINAIL.PremioAttivoCrudo _
                                                                      + CoperturaInfortuniFranchigia3.PremioAttivoCrudo _
                                                                      + CoperturaInfortuniSuperValutazione.PremioAttivoCrudo _
                                                                      + CoperturaSalvaCircolazioneBase.PremioAttivoCrudo)
                Else
                    CoperturaScontiBase.Tariffa.Base = Tabelle.getPremio(InfortuniScelta, FrazionamentiEnum.Annuale, InfortuniForma, ScontoPoliennale - 1) _
                                                     - CoperturaInfortuniBase.Tariffa.Base _
                                                     + (1 - ScontoPoliennale) * 0.02D * CoperturaSalvaCircolazioneBase.PremioAttivoCrudo
                End If
            End With
        End Sub

        Public Overrides Sub ControlloPremioMinimo()
            If InfortuniForma = InfortuniFormaEnum.CapitaliLiberi Then
                If PremioMinimoAnnuoNetto > 0 And PremioNetto > 0 And PremioNetto < PremioMinimoAnnuoNetto Then
                    SetNonDisponibile(String.Format("Premio minimo annuo imponibile {0} minore di {1}", FormatEuro(PremioNetto), FormatEuro(PremioMinimoAnnuoNetto)))
                End If
            End If
        End Sub

        Public Overrides Sub Stampa(ByVal options As StampaOptions)
            Dim s As New P01203ST
            Stampato = True
            s.StampaMostraEtInvia(Me, options)
        End Sub

    End Class
End Namespace
