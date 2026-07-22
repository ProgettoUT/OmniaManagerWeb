Namespace PSMART
    <Serializable()> Public Class smart
        Inherits Prodotto

        Public ClasseTerritorialeFurto As ClasseTerritorialeFurtoEnum
        Public CasaScelta As CasaSceltaEnum
        Public CasaDurataPoliennale As CasaDurataPoliennaleEnum
        Public InfortuniScelta As InfortuniSceltaEnum
        Public InfortuniDurataPoliennale As InfortuniDurataPoliennaleEnum
        Public AttivitaTipo As AttivitaTipoEnum
        Public AttivitaScelta As AttivitaSceltaEnum
        Public AttivitaDurataPoliennale As AttivitaDurataPoliennaleEnum
        Public Provincia As ProvinciaEnum

        'aliquote

        'sezioni
        Public SezioneCasaIncendio As New Sezione(Me, TipoSezione.CasaIncendio)
        Public SezioneCasaFurto As New Sezione(Me, TipoSezione.CasaFurto)
        Public SezioneCasaRC As New Sezione(Me, TipoSezione.CasaRC)
        Public SezioneCasaAssistenza As New Sezione(Me, TipoSezione.CasaAssistenza)
        Public SezioneInfortuni As New Sezione(Me, TipoSezione.Infortuni)
        Public SezioneAttivitaRC As New Sezione(Me, TipoSezione.AttivitaRC)
        Public SezioneAttivitaIncendio As New Sezione(Me, TipoSezione.AttivitaIncendio)

        'CasaIncendio
        Public CoperturaCasaIncendio As New CoperturaComposta()
        Public PartitaCasaIncendioBase As New Partita(TipoPartita.CasaIncendio)
        Public CoperturaCasaIncendioBase As New CoperturaSingola(PartitaCasaIncendioBase, New Garanzia(TipoGaranzia.CasaIncendioBase))
        Public PartitaCasaPoliennale As New Partita(TipoPartita.CasaIncendio)
        Public CoperturaCasaPoliennale As New CoperturaSingola(PartitaCasaPoliennale, New Garanzia(TipoGaranzia.CasaPoliennale))

        'CasaFurto
        Public PartitaCasaFurtoBase As New Partita(TipoPartita.CasaFurto)
        Public CoperturaCasaFurtoBase As New CoperturaSingola(PartitaCasaFurtoBase, New Garanzia(TipoGaranzia.CasaFurtoBase))

        'CasaRC
        Public PartitaCasaRCBase As New Partita(TipoPartita.CasaRC)
        Public CoperturaCasaRCBase As New CoperturaSingola(PartitaCasaRCBase, New Garanzia(TipoGaranzia.CasaRCBase))

        'CasaAssistenza
        Public PartitaCasaAssistenzaBase As New Partita(TipoPartita.CasaAssistenza)
        Public CoperturaCasaAssistenzaBase As New CoperturaSingola(PartitaCasaAssistenzaBase, New Garanzia(TipoGaranzia.CasaAssistenzaBase))

        'Infortuni
        'Public PartitaInfortuniBase As New Partita(TipoPartita.Infortuni)
        'Public CoperturaInfortuniBase As New CoperturaSingola(PartitaInfortuniBase, New Garanzia(TipoGaranzia.InfortuniBase))
        Public CoperturaInfortuniBase As New CoperturaComposta()
        Public PartitaInfortuniMorte As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniMorte As New CoperturaSingola(PartitaInfortuniMorte, New Garanzia(TipoGaranzia.InfortuniMorte))
        Public PartitaInfortuniIP As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniIP As New CoperturaSingola(PartitaInfortuniIP, New Garanzia(TipoGaranzia.InfortuniIP))
        Public PartitaInfortuniSpeseMediche As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniSpeseMediche As New CoperturaSingola(PartitaInfortuniSpeseMediche, New Garanzia(TipoGaranzia.InfortuniSpeseMediche))
        Public PartitaInfortuniDiarieDegenza As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniDiarieDegenza As New CoperturaSingola(PartitaInfortuniDiarieDegenza, New Garanzia(TipoGaranzia.InfortuniDiarieDegenza))
        Public PartitaInfortuniDiarieDayHospital As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniDiarieDayHospital As New CoperturaSingola(PartitaInfortuniDiarieDayHospital, New Garanzia(TipoGaranzia.InfortuniDiarieDayHospital))
        Public PartitaInfortuniDiarieImmobilizzazione As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniDiarieImmobilizzazione As New CoperturaSingola(PartitaInfortuniDiarieImmobilizzazione, New Garanzia(TipoGaranzia.InfortuniDiarieImmobilizzazione))
        Public PartitaInfortuniFamiglia As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniFamiglia As New CoperturaSingola(PartitaInfortuniFamiglia, New Garanzia(TipoGaranzia.InfortuniFamiglia))
        Public PartitaInfortuniFranchigia As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniFranchigia As New CoperturaSingola(PartitaInfortuniFranchigia, New Garanzia(TipoGaranzia.InfortuniFranchigia))
        Public PartitaInfortuniPoliennale As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniPoliennale As New CoperturaSingola(PartitaInfortuniPoliennale, New Garanzia(TipoGaranzia.InfortuniPoliennale))

        'AttivitaRC
        'Public PartitaAttivitaRCBase As New Partita(TipoPartita.AttivitaRC)
        'Public CoperturaAttivitaRCBase As New CoperturaSingola(PartitaAttivitaRCBase, New Garanzia(TipoGaranzia.AttivitaRCBase))
        Public CoperturaAttivitaRCBase As New CoperturaComposta()
        Public PartitaAttivitaRCT As New Partita(TipoPartita.AttivitaRC)
        Public CoperturaAttivitaRCT As New CoperturaSingola(PartitaAttivitaRCT, New Garanzia(TipoGaranzia.AttivitaRCT))
        Public PartitaAttivitaRCL As New Partita(TipoPartita.AttivitaRC)
        Public CoperturaAttivitaRCL As New CoperturaSingola(PartitaAttivitaRCL, New Garanzia(TipoGaranzia.AttivitaRCL))

        'AttivitaIncendio
        'Public PartitaAttivitaIncendioBase As New Partita(TipoPartita.AttivitaIncendio)
        'Public CoperturaAttivitaIncendioBase As New CoperturaSingola(PartitaAttivitaIncendioBase, New Garanzia(TipoGaranzia.AttivitaIncendioBase))
        Public CoperturaAttivitaIncendioBase As New CoperturaComposta()
        Public PartitaAttivitaIncendioFC As New Partita(TipoPartita.AttivitaIncendio)
        Public CoperturaAttivitaIncendioFC As New CoperturaSingola(PartitaAttivitaIncendioFC, New Garanzia(TipoGaranzia.AttivitaIncendioFC))
        Public PartitaAttivitaAttiVandalici As New Partita(TipoPartita.AttivitaIncendio)
        Public CoperturaAttivitaAttiVandalici As New CoperturaSingola(PartitaAttivitaAttiVandalici, New Garanzia(TipoGaranzia.AttivitaAttiVandalici))
        Public PartitaAttivitaPoliennale As New Partita(TipoPartita.AttivitaIncendio)
        Public CoperturaAttivitaPoliennale As New CoperturaSingola(PartitaAttivitaPoliennale, New Garanzia(TipoGaranzia.AttivitaPoliennale))


        ' richiamato anche in apertura di un file
        Public Overrides Sub New2()
            'Caratteristiche
            CodiceRamoPolizza = 148
            CodiceProdotto = TipoProdotto.Smart
            DescrizioneProdotto = "UnipolSai smart"
            Edizione = "01.07.2014"
            DataEntrataVigore = "01/02/2014"

            DurataContrattualeMinimaInAnni = 1
            DurataContrattualeMassimaInAnni = 5
            PeriodoMoraInGiorni = 15
            EmissioneAppendici = False
            TacitoRinnovo = True

            ContraenzaPersonaGiuridica = False
            ContraenzaPersonaFisica = True
            PremioMinimoPrimaRata = 0
            PremioMinimoRataSuccessiva = 0
            GiorniValiditaPreventivo = 30

            'aliquote
            SezioneCasaIncendio.AliquotaImposta = AliquotaImpostaIncendio
            SezioneCasaFurto.AliquotaImposta = AliquotaImpostaFurto
            SezioneCasaRC.AliquotaImposta = AliquotaImpostaResponsabilitaCivile
            SezioneCasaAssistenza.AliquotaImposta = AliquotaImpostaAssistenza
            SezioneInfortuni.AliquotaImposta = AliquotaImpostaInfortuni
            SezioneAttivitaRC.AliquotaImposta = AliquotaImpostaResponsabilitaCivile
            SezioneAttivitaIncendio.AliquotaImposta = AliquotaImpostaIncendio

            'I tassi e i premi della presente tariffa sono comprensivi di imposte e oneri parafiscali.
            BaseTasse = UniQuota.BaseTasse.BaseLorda

            '22/10/15: la flexi nei prodotti smart non è ammessa
            EscludiFlex = True
        End Sub

        Public Sub New()
            New2()

            'sezioni
            Sezioni.Add(SezioneCasaIncendio)
            Sezioni.Add(SezioneCasaFurto)
            Sezioni.Add(SezioneCasaRC)
            Sezioni.Add(SezioneCasaAssistenza)
            Sezioni.Add(SezioneInfortuni)
            Sezioni.Add(SezioneAttivitaRC)
            Sezioni.Add(SezioneAttivitaIncendio)


            'sezione - coperture

            SezioneCasaIncendio.AddCopertura(CoperturaCasaIncendio)
            CoperturaCasaIncendio.AddCopertura(CoperturaCasaIncendioBase)
            CoperturaCasaIncendio.AddCopertura(CoperturaCasaPoliennale)
            SezioneCasaFurto.AddCopertura(CoperturaCasaFurtoBase)
            SezioneCasaRC.AddCopertura(CoperturaCasaRCBase)
            SezioneCasaAssistenza.AddCopertura(CoperturaCasaAssistenzaBase)

            SezioneInfortuni.AddCopertura(CoperturaInfortuniBase)
            CoperturaInfortuniBase.AddCopertura(CoperturaInfortuniMorte)
            CoperturaInfortuniBase.AddCopertura(CoperturaInfortuniIP)
            CoperturaInfortuniBase.AddCopertura(CoperturaInfortuniSpeseMediche)
            CoperturaInfortuniBase.AddCopertura(CoperturaInfortuniDiarieDegenza)
            CoperturaInfortuniBase.AddCopertura(CoperturaInfortuniDiarieDayHospital)
            CoperturaInfortuniBase.AddCopertura(CoperturaInfortuniDiarieImmobilizzazione)
            CoperturaInfortuniBase.AddCopertura(CoperturaInfortuniFamiglia)
            CoperturaInfortuniBase.AddCopertura(CoperturaInfortuniFranchigia)
            CoperturaInfortuniBase.AddCopertura(CoperturaInfortuniPoliennale)

            SezioneAttivitaRC.AddCopertura(CoperturaAttivitaRCBase)
            CoperturaAttivitaRCBase.AddCopertura(CoperturaAttivitaRCT)
            CoperturaAttivitaRCBase.AddCopertura(CoperturaAttivitaRCL)
            SezioneAttivitaIncendio.AddCopertura(CoperturaAttivitaIncendioBase)
            CoperturaAttivitaIncendioBase.AddCopertura(CoperturaAttivitaIncendioFC)
            CoperturaAttivitaIncendioBase.AddCopertura(CoperturaAttivitaAttiVandalici)
            SezioneAttivitaRC.AddCopertura(CoperturaAttivitaPoliennale)
        End Sub

        Public Overrides Sub Valida()
            ValidaCondizioniGenerali()
            ValidaSconti()
            ValidaSezioneCasa()
            ValidaSezioneInfortuni()
            ValidaSezioneAttivita()
        End Sub

        Public Overrides Function IdProdottoPerLog() As String
            Return MyBase.IdProdottoPerLog() _
                & IIf(SezioneCasaIncendio.PremioLordo + SezioneCasaFurto.PremioLordo + SezioneCasaRC.PremioLordo + SezioneCasaAssistenza.PremioLordo = 0D, "0", "1") _
                & IIf(SezioneInfortuni.PremioLordo = 0D, "0", "1") _
                & IIf(SezioneAttivitaRC.PremioLordo + SezioneAttivitaIncendio.PremioLordo = 0D, "0", "1")
        End Function

        Public Sub ValidaCondizioniGenerali()
            If Provincia = ProvinciaEnum.SiglaXX Then
                Provincia = Luogo.GetProvinciaBySigla(Me.Cliente.Provincia)
                If Provincia = ProvinciaEnum.SiglaXX Then Provincia = ProvinciaEnum.SiglaAG
            End If

            If CoperturaAttivitaRCBase.IsAttivo And Not IsOneOf(Frazionamento, FrazionamentiEnum.Annuale, FrazionamentiEnum.Semestrale, FrazionamentiEnum.Mensile) Then
                Frazionamento = FrazionamentiEnum.Mensile
            End If

            If CoperturaInfortuniBase.IsAttivo And Not IsOneOf(Frazionamento, FrazionamentiEnum.Annuale, FrazionamentiEnum.Semestrale, FrazionamentiEnum.Mensile) Then
                Frazionamento = FrazionamentiEnum.Mensile
            End If

            If CoperturaCasaIncendio.IsAttivo And Not IsOneOf(Frazionamento, FrazionamentiEnum.Annuale, FrazionamentiEnum.Semestrale, FrazionamentiEnum.Mensile) Then
                Frazionamento = FrazionamentiEnum.Mensile
            End If
        End Sub

        Public Sub ValidaSconti()
        End Sub

        Public Sub ValidaSezioneCasa()
            If CasaScelta = 0 Then CasaScelta = CasaSceltaEnum.SceltaA

            Dim ClasseTerritorialeFurto = CType(Decode, PSMARTDE).DecodeProvinciaToClasseTerritorialeFurto(Provincia)

            CoperturaCasaIncendio.DipendeDa(True)
            SezioneCasaIncendio.Stato = CoperturaCasaIncendio.Stato

            CoperturaCasaIncendioBase.ObbligatoriaDa(CoperturaCasaIncendio.IsAttivo)
            CoperturaCasaFurtoBase.ObbligatoriaDa(CoperturaCasaIncendio.IsAttivo And CasaScelta <> CasaSceltaEnum.SceltaA And CasaScelta <> CasaSceltaEnum.SceltaC)
            SezioneCasaFurto.Stato = CoperturaCasaFurtoBase.Stato

            CoperturaCasaRCBase.ObbligatoriaDa(CoperturaCasaIncendio.IsAttivo)
            SezioneCasaRC.Stato = CoperturaCasaRCBase.Stato

            CoperturaCasaAssistenzaBase.ObbligatoriaDa(CoperturaCasaIncendio.IsAttivo)
            SezioneCasaAssistenza.Stato = CoperturaCasaAssistenzaBase.Stato

            CoperturaCasaPoliennale.DipendeDa(CoperturaCasaIncendio.IsAttivo)

            With CoperturaCasaIncendioBase
                .Tariffa.Base = Choose(CasaScelta, 56.91D, 60.55D, 176.85D, 186.49)
            End With

            With CoperturaCasaFurtoBase
                If CasaScelta = CasaSceltaEnum.SceltaA Or CasaScelta = CasaSceltaEnum.SceltaC Then
                    .Tariffa.Base = 0D
                Else
                    .Tariffa.Base = Choose(ClasseTerritorialeFurto, 53.98D, 41.97D, 29.98D)
                End If
            End With

            With CoperturaCasaRCBase
                .Tariffa.Base = Choose(CasaScelta, 51.05D, 59.4D, 51.05D, 59.4D)
            End With


            With CoperturaCasaAssistenzaBase
                .Tariffa.Base = 6.07D
            End With

            With CoperturaCasaPoliennale
                If Durata >= 2 And Durata <= 5 And Not .IsAttivo() Then
                    CasaDurataPoliennale = Durata
                ElseIf CasaDurataPoliennale = 0 Then
                    CasaDurataPoliennale = CasaDurataPoliennaleEnum.Anni2
                End If

                .Tariffa.Base = -(CasaDurataPoliennale - 1) * Choose(CasaScelta, 3D, 3D, 6D, 6D)
            End With

            '22-12-14: aggiornato a edizione 01.07.2014
            SezioneCasaIncendio.PercentualeScontoTecnico = 0D
            'If Frazionamento = UniQuota.FrazionamentiEnum.Annuale Then
            '    SezioneCasaIncendio.PercentualeScontoTecnico = 1D / 12D
            'ElseIf Frazionamento = UniQuota.FrazionamentiEnum.Semestrale Then
            '    SezioneCasaIncendio.PercentualeScontoTecnico = 1D / 48D
            'Else
            '    SezioneCasaIncendio.PercentualeScontoTecnico = 0D
            'End If

            SezioneCasaFurto.PercentualeScontoTecnico = SezioneCasaIncendio.PercentualeScontoTecnico
            SezioneCasaRC.PercentualeScontoTecnico = SezioneCasaIncendio.PercentualeScontoTecnico
            SezioneCasaAssistenza.PercentualeScontoTecnico = SezioneCasaIncendio.PercentualeScontoTecnico
        End Sub



        Public Sub ValidaSezioneInfortuni()
            CoperturaInfortuniBase.DipendeDa(True)
            SezioneInfortuni.Stato = CoperturaInfortuniBase.Stato

            If InfortuniScelta = 0 Then InfortuniScelta = InfortuniSceltaEnum.SceltaA

            CoperturaInfortuniMorte.ObbligatoriaDa(CoperturaInfortuniBase.IsAttivo And InfortuniScelta <> InfortuniSceltaEnum.SceltaD)
            CoperturaInfortuniIP.ObbligatoriaDa(CoperturaInfortuniBase.IsAttivo)

            CoperturaInfortuniSpeseMediche.DipendeDa(CoperturaInfortuniBase.IsAttivo)
            CoperturaInfortuniDiarieDegenza.DipendeDa(CoperturaInfortuniBase.IsAttivo)
            CoperturaInfortuniDiarieDayHospital.ObbligatoriaDa(CoperturaInfortuniDiarieDegenza.IsAttivo)
            CoperturaInfortuniDiarieImmobilizzazione.ObbligatoriaDa(CoperturaInfortuniDiarieDegenza.IsAttivo)

            CoperturaInfortuniFamiglia.DipendeDa(CoperturaInfortuniBase.IsAttivo)
            CoperturaInfortuniFranchigia.DipendeDa(CoperturaInfortuniBase.IsAttivo And CoperturaInfortuniFamiglia.IsNotAttivo)
            CoperturaInfortuniPoliennale.DipendeDa(CoperturaInfortuniBase.IsAttivo)

            With CoperturaInfortuniMorte
                .Partita.SommaAssicurata = Choose(InfortuniScelta, 30D, 50D, 100D, 0D) * 1000
                .Tariffa.Base = Choose(InfortuniScelta, 14.4D, 24D, 48D, 0D)
            End With

            With CoperturaInfortuniIP
                .Partita.SommaAssicurata = Choose(InfortuniScelta, 50D, 100D, 200D, 200D) * 1000
                .Tariffa.Base = Choose(InfortuniScelta, 87.6D, 168D, 318D, 288D)
            End With

            With CoperturaInfortuniSpeseMediche
                .Partita.SommaAssicurata = Choose(InfortuniScelta, 1D, 2D, 4D, 4D) * 1000
                .Tariffa.Base = Choose(InfortuniScelta, 18D, 24D, 30D, 30D)
            End With

            With CoperturaInfortuniDiarieDegenza
                .Partita.SommaAssicurata = 40
                .Tariffa.Base = 4.3D
            End With

            With CoperturaInfortuniDiarieDayHospital
                .Partita.SommaAssicurata = 20
                .Tariffa.Base = 3.7D
            End With

            With CoperturaInfortuniDiarieImmobilizzazione
                .Partita.SommaAssicurata = 20
                .Tariffa.Base = 16D
            End With

            With CoperturaInfortuniFranchigia
                .Tariffa.Base = Choose(InfortuniScelta, 21D, 42D, 81D, 72D)
            End With

            With CoperturaInfortuniPoliennale
                If Durata >= 2 And Durata <= 5 And Not .IsAttivo() Then
                    InfortuniDurataPoliennale = Durata
                ElseIf InfortuniDurataPoliennale = 0 Then
                    InfortuniDurataPoliennale = InfortuniDurataPoliennaleEnum.Anni2
                End If

                If CoperturaInfortuniFranchigia.IsAttivo Then
                    .Tariffa.Base = -(InfortuniDurataPoliennale - 1) * Choose(InfortuniScelta, 3D, 6D, 15D, 15D)
                    If InfortuniScelta = InfortuniSceltaEnum.SceltaB Then
                        If InfortuniDurataPoliennale > InfortuniDurataPoliennaleEnum.Anni2 Then .Tariffa.Base -= 3D
                        If InfortuniDurataPoliennale > InfortuniDurataPoliennaleEnum.Anni4 Then .Tariffa.Base -= 3D
                    End If
                Else
                    .Tariffa.Base = -(InfortuniDurataPoliennale - 1) * Choose(InfortuniScelta, 3D, 6D, 12D, 12D)
                End If
            End With

            With CoperturaInfortuniFamiglia
                .Partita.SommaAssicurata = CoperturaInfortuniMorte.PremioAttivoCrudo _
                                         + CoperturaInfortuniIP.PremioAttivoCrudo _
                                         + CoperturaInfortuniSpeseMediche.PremioAttivoCrudo _
                                         + CoperturaInfortuniDiarieDegenza.PremioAttivoCrudo _
                                         + CoperturaInfortuniDiarieDayHospital.PremioAttivoCrudo _
                                         + CoperturaInfortuniDiarieImmobilizzazione.PremioAttivoCrudo _
                                         + CoperturaInfortuniPoliennale.PremioAttivoCrudo
                .Tariffa.Tasso = 0.25D
            End With

            '22-12-14: aggiornato a edizione 01.07.2014
            SezioneInfortuni.PercentualeScontoTecnico = 0D
            'If Frazionamento = UniQuota.FrazionamentiEnum.Annuale Then
            '    SezioneInfortuni.PercentualeScontoTecnico = 1D / 12D
            'ElseIf Frazionamento = UniQuota.FrazionamentiEnum.Semestrale Then
            '    SezioneInfortuni.PercentualeScontoTecnico = 1D / 48D
            'Else
            '    SezioneInfortuni.PercentualeScontoTecnico = 0D
            'End If

        End Sub

        Public Sub ValidaSezioneAttivita()
            If AttivitaTipo = 0 Then AttivitaTipo = AttivitaTipoEnum.Commerciali
            If AttivitaScelta = 0 Then AttivitaScelta = AttivitaSceltaEnum.SceltaA

            CoperturaAttivitaRCBase.DipendeDa(True)
            SezioneAttivitaRC.Stato = CoperturaAttivitaRCBase.Stato

            CoperturaAttivitaRCT.ObbligatoriaDa(CoperturaAttivitaRCBase.IsAttivo)
            CoperturaAttivitaRCL.DipendeDa(CoperturaAttivitaRCBase.IsAttivo)


            CoperturaAttivitaIncendioBase.ObbligatoriaDa(CoperturaAttivitaRCBase.IsAttivo And AttivitaScelta <> AttivitaSceltaEnum.SceltaA)
            SezioneAttivitaIncendio.Stato = CoperturaAttivitaIncendioBase.Stato

            CoperturaAttivitaIncendioFC.ObbligatoriaDa(CoperturaAttivitaIncendioBase.IsAttivo)
            CoperturaAttivitaAttiVandalici.ObbligatoriaDa(CoperturaAttivitaRCBase.IsAttivo And AttivitaScelta = AttivitaSceltaEnum.SceltaC)

            CoperturaAttivitaPoliennale.DipendeDa(CoperturaAttivitaRCBase.IsAttivo)


            With CoperturaAttivitaRCT
                .Tariffa.Base = Choose(AttivitaTipo, 192D, 444D)
                .Partita.SommaAssicurata = 500000
            End With

            With CoperturaAttivitaRCL
                .Tariffa.Base = Choose(AttivitaTipo, 36D, 180D)
                .Partita.SommaAssicurata = 500000
            End With


            With CoperturaAttivitaIncendioFC
                .Tariffa.Base = Choose(AttivitaTipo, 360D, 288D)
            End With

            With CoperturaAttivitaAttiVandalici
                .Tariffa.Base = Choose(AttivitaTipo, 168D, 84D)
            End With

            With CoperturaAttivitaPoliennale
                If Durata >= 2 And Durata <= 5 And Not .IsAttivo() Then
                    AttivitaDurataPoliennale = Durata
                ElseIf AttivitaDurataPoliennale = 0 Then
                    AttivitaDurataPoliennale = AttivitaDurataPoliennaleEnum.Anni2
                End If

                If AttivitaTipo = AttivitaTipoEnum.Commerciali Then
                    .Tariffa.Base = -(AttivitaDurataPoliennale - 1) * Choose(AttivitaScelta, 6D, 12D, 18D)
                Else
                    .Tariffa.Base = -(AttivitaDurataPoliennale - 1) * Choose(AttivitaScelta, 12D, 18D, 18D)
                End If
            End With

            '22-12-14: aggiornato a edizione 01.07.2014
            SezioneAttivitaRC.PercentualeScontoTecnico = 0D
            'If Frazionamento = UniQuota.FrazionamentiEnum.Annuale Then
            '    SezioneAttivitaRC.PercentualeScontoTecnico = 1D / 12D
            'ElseIf Frazionamento = UniQuota.FrazionamentiEnum.Semestrale Then
            '    SezioneAttivitaRC.PercentualeScontoTecnico = 1D / 48D
            'Else
            '    SezioneAttivitaRC.PercentualeScontoTecnico = 0D
            'End If

            SezioneAttivitaIncendio.PercentualeScontoTecnico = SezioneAttivitaRC.PercentualeScontoTecnico

        End Sub




        Public Overrides Sub CalcolaFrazionamento()
            Interessi = 0D
            If Frazionamento = FrazionamentiEnum.Mensile Then
                Dim meseInfo = SezioneInfortuni.PremioLordo / 12D
                Dim meseCasa = (SezioneCasaIncendio.PremioLordo + SezioneCasaFurto.PremioLordo + SezioneCasaRC.PremioLordo + SezioneCasaAssistenza.PremioLordo) / 12D
                Dim meseAtti = (SezioneAttivitaIncendio.PremioLordo + SezioneAttivitaRC.PremioLordo) / 12D
                PremioRata = (meseInfo + meseCasa + meseAtti)
                PremioPrimaRata = 3 * PremioRata
                PremioRataSuccessiva = 0D
            Else
                If Frazionamento = FrazionamentiEnum.Semestrale Then
                    PremioRata = Math.Round(PremioLordo / 2, 2, MidpointRounding.AwayFromZero)
                ElseIf Frazionamento = FrazionamentiEnum.Quadrimestrale Then
                    PremioRata = Math.Round(PremioLordo / 3, 2, MidpointRounding.AwayFromZero)
                ElseIf Frazionamento = FrazionamentiEnum.Trimestrale Then
                    PremioRata = Math.Round(PremioLordo / 4, 2, MidpointRounding.AwayFromZero)
                ElseIf Frazionamento = FrazionamentiEnum.Bimestrale Then
                    PremioRata = Math.Round(PremioLordo / 6, 2, MidpointRounding.AwayFromZero)
                Else
                    PremioRata = PremioLordo
                End If
                PremioRataSuccessiva = PremioRata
                PremioPrimaRata = PremioRata
            End If

            PremioAnnuo = PremioLordo
        End Sub

        Public Overrides Sub Stampa(ByVal options As StampaOptions)
            Dim s As New PSMARTST
            Stampato = True
            s.StampaMostraEtInvia(Me, options)
        End Sub


        'proprietà uso essig

        Public Overrides Function HasEssig() As Boolean
            Return True
        End Function

        Public Overrides Function GetNewPES() As P00000ES
            Return New PSMARTES(Me)
        End Function

        Public ReadOnly Property EssigScadenzaPolizza() As String
            Get
                If CoperturaInfortuniPoliennale.IsAttivo Then
                    Return Today.AddYears(InfortuniDurataPoliennale).ToString("dd/MM/yyyy")
                Else
                    Return Today.AddYears(1).ToString("dd/MM/yyyy")
                End If
            End Get
        End Property

        Public EssigAssicuratoNominativo As String
        Public EssigAssicuratoCodiceFiscale As String
        Public EssigAssicuratoProfessione As String
        Public EssigAssicuratoTipoOccupazione As String
        Public EssigAssicuratoClasseProfessionale As String

    End Class
End Namespace
