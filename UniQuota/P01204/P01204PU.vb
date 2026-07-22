Namespace P01204
    <Serializable()> Public Class assicurato

        Public Eta As Integer
        Public Nominativo As String
        Public Descrizione As String
        Public TipoContraente As TipoContraenteEnum
        Public FormaCopertura As FormaCoperturaEnum
        Public TipoRapporto As TipoRapportoEnum
        Public CodiceAttivita As Integer

        Public InfortuniPremium As InfortuniPremium
        Public InfortuniIPScelta As InfortuniIPSceltaEnum
        Public InfortuniRicoveroConvalescenzaScelta As RicoveroConvalescenzaSceltaEnum
        Public MalattiaRicoveroConvalescenzaScelta As RicoveroConvalescenzaSceltaEnum
        Public InfortuniITScelta As InfortuniITScetaEnum
        Public SportClasseRischio As SportClasseRischioEnum
        Public SportAgonisticoRicoveroConvalescenzaScelta As RicoveroConvalescenzaSceltaEnum
        Public SportAltoRischioRicoveroConvalescenzaScelta As RicoveroConvalescenzaSceltaEnum
        Public SportMotoRicoveroConvalescenzaScelta As RicoveroConvalescenzaSceltaEnum
        Public SportAereiRicoveroConvalescenzaScelta As RicoveroConvalescenzaSceltaEnum

        'Infortuni
        Public CoperturaInfortuni As New CoperturaComposta()
        Public PartitaInfortuniMorte As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniMorte As New CoperturaSingola(PartitaInfortuniMorte, New Garanzia(TipoGaranzia.InfortuniMorte), True)
        Public PartitaInfortuniIP As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniIP As New CoperturaSingola(PartitaInfortuniIP, New Garanzia(TipoGaranzia.InfortuniIP), True)
        'Public PartitaInfortuniIPRenditaVitalizia As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniIPRenditaVitalizia As New CoperturaSingola(New Garanzia(TipoGaranzia.InfortuniIPRenditaVitalizia))
        'Public PartitaInfortuniSpeseMediche As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniSpeseMediche As New CoperturaSingola(New Garanzia(TipoGaranzia.InfortuniSpeseMediche))
        Public PartitaInfortuniRicoveroConvalescenza As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniRicoveroConvalescenza As New CoperturaSingola(PartitaInfortuniRicoveroConvalescenza, New Garanzia(TipoGaranzia.InfortuniRicoveroConvalescenza), True)
        Public PartitaInfortuniImmobilizzazione As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniImmobilizzazione As New CoperturaSingola(PartitaInfortuniImmobilizzazione, New Garanzia(TipoGaranzia.InfortuniImmobilizzazione), True)
        Public PartitaInfortuniIT As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniIT As New CoperturaSingola(PartitaInfortuniIT, New Garanzia(TipoGaranzia.InfortuniIT), True)

        Public PartitaInfortuniIPPremioAttivo As New Partita(TipoPartita.Infortuni)

        'Public PartitaInfortuniTabellaINAIL As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniTabellaINAIL As New CoperturaSingola(PartitaInfortuniIPPremioAttivo, New Garanzia(TipoGaranzia.InfortuniTabellaINAIL))
        'Public PartitaInfortuniFranchigia3 As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniFranchigia3 As New CoperturaSingola(PartitaInfortuniIPPremioAttivo, New Garanzia(TipoGaranzia.InfortuniFranchigia3))
        'Public PartitaInfortuniFranchigia0 As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniFranchigia0 As New CoperturaSingola(PartitaInfortuniIPPremioAttivo, New Garanzia(TipoGaranzia.InfortuniFranchigia0))
        'Public PartitaInfortuniFranchigiaPlus As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniFranchigiaPlus As New CoperturaSingola(PartitaInfortuniIPPremioAttivo, New Garanzia(TipoGaranzia.InfortuniFranchigiaPlus))
        'Public PartitaInfortuniFranchigiaDiff As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniFranchigiaDiff As New CoperturaSingola(PartitaInfortuniIPPremioAttivo, New Garanzia(TipoGaranzia.InfortuniFranchigiaDiff))
        'Public PartitaInfortuniSVPartiAnatomiche As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniSVPartiAnatomiche As New CoperturaSingola(PartitaInfortuniIPPremioAttivo, New Garanzia(TipoGaranzia.InfortuniSVPartiAnatomiche))
        'Public PartitaInfortuniSVIP As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniSVIP As New CoperturaSingola(PartitaInfortuniIPPremioAttivo, New Garanzia(TipoGaranzia.InfortuniSVIP))
        'Public PartitaInfortuniForfaitFrattura As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniForfaitFrattura As New CoperturaSingola(New Garanzia(TipoGaranzia.InfortuniForfaitFrattura))
        'Public PartitaInfortuniForfaitRicovero As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniForfaitRicovero As New CoperturaSingola(New Garanzia(TipoGaranzia.InfortuniForfaitRicovero))
        Public CoperturaMalattiaForfaitRicovero As New CoperturaSingola(New Garanzia(TipoGaranzia.MalattiaForfaitRicovero))
        Public PartitaInfortuniGlobaleImmobilizzazione As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniGlobaleImmobilizzazione As New CoperturaSingola(PartitaInfortuniGlobaleImmobilizzazione, New Garanzia(TipoGaranzia.InfortuniGlobaleImmobilizzazione))
        Public PartitaInfortuniDannoEstetico As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniDannoEstetico As New CoperturaSingola(PartitaInfortuniDannoEstetico, New Garanzia(TipoGaranzia.InfortuniDannoEstetico))
        'Public PartitaInfortuniMorteCircolazione As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniMorteCircolazione As New CoperturaSingola(New Garanzia(TipoGaranzia.InfortuniMorteCircolazione))
        Public PartitaInfortuniNucleoFamiliare As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniNucleoFamiliare As New CoperturaSingola(PartitaInfortuniNucleoFamiliare, New Garanzia(TipoGaranzia.InfortuniNucleoFamiliare))


        Public PartitaSportAgonisticoMorte As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportAgonisticoMorte As New CoperturaSingola(PartitaSportAgonisticoMorte, New Garanzia(TipoGaranzia.SportAgonisticoMorte), True)
        Public PartitaSportAgonisticoIP As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportAgonisticoIP As New CoperturaSingola(PartitaSportAgonisticoIP, New Garanzia(TipoGaranzia.SportAgonisticoIP), True)
        'Public PartitaSportAgonisticoSpeseMediche As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportAgonisticoSpeseMediche As New CoperturaSingola(New Garanzia(TipoGaranzia.SportAgonisticoSpeseMediche))
        Public PartitaSportAgonisticoRicoveroConvalescenza As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportAgonisticoRicoveroConvalescenza As New CoperturaSingola(PartitaSportAgonisticoRicoveroConvalescenza, New Garanzia(TipoGaranzia.SportAgonisticoRicoveroConvalescenza), True)
        Public CoperturaSportAgonistico As New CoperturaComposta(CoperturaSportAgonisticoMorte + CoperturaSportAgonisticoIP + CoperturaSportAgonisticoSpeseMediche + CoperturaSportAgonisticoRicoveroConvalescenza)

        Public PartitaSportAltoRischioMorte As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportAltoRischioMorte As New CoperturaSingola(PartitaSportAltoRischioMorte, New Garanzia(TipoGaranzia.SportAltoRischioMorte), True)
        Public PartitaSportAltoRischioIP As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportAltoRischioIP As New CoperturaSingola(PartitaSportAltoRischioIP, New Garanzia(TipoGaranzia.SportAltoRischioIP), True)
        'Public PartitaSportAltoRischioSpeseMediche As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportAltoRischioSpeseMediche As New CoperturaSingola(New Garanzia(TipoGaranzia.SportAltoRischioSpeseMediche))
        Public PartitaSportAltoRischioRicoveroConvalescenza As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportAltoRischioRicoveroConvalescenza As New CoperturaSingola(PartitaSportAltoRischioRicoveroConvalescenza, New Garanzia(TipoGaranzia.SportAltoRischioRicoveroConvalescenza), True)
        Public CoperturaSportAltoRischio As New CoperturaComposta(CoperturaSportAltoRischioMorte + CoperturaSportAltoRischioIP + CoperturaSportAltoRischioSpeseMediche + CoperturaSportAltoRischioRicoveroConvalescenza)

        Public PartitaSportMotoMorte As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportMotoMorte As New CoperturaSingola(PartitaSportMotoMorte, New Garanzia(TipoGaranzia.SportMotoMorte), True)
        Public PartitaSportMotoIP As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportMotoIP As New CoperturaSingola(PartitaSportMotoIP, New Garanzia(TipoGaranzia.SportMotoIP), True)
        'Public PartitaSportMotoSpeseMediche As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportMotoSpeseMediche As New CoperturaSingola(New Garanzia(TipoGaranzia.SportMotoSpeseMediche))
        Public PartitaSportMotoRicoveroConvalescenza As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportMotoRicoveroConvalescenza As New CoperturaSingola(PartitaSportMotoRicoveroConvalescenza, New Garanzia(TipoGaranzia.SportMotoRicoveroConvalescenza), True)
        Public CoperturaSportMoto As New CoperturaComposta(CoperturaSportMotoMorte + CoperturaSportMotoIP + CoperturaSportMotoSpeseMediche + CoperturaSportMotoRicoveroConvalescenza)

        Public PartitaSportAereiMorte As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportAereiMorte As New CoperturaSingola(PartitaSportAereiMorte, New Garanzia(TipoGaranzia.SportAereiMorte), True)
        Public PartitaSportAereiIP As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportAereiIP As New CoperturaSingola(PartitaSportAereiIP, New Garanzia(TipoGaranzia.SportAereiIP), True)
        'Public PartitaSportAereiSpeseMediche As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportAereiSpeseMediche As New CoperturaSingola(New Garanzia(TipoGaranzia.SportAereiSpeseMediche))
        Public PartitaSportAereiRicoveroConvalescenza As New Partita(TipoPartita.Infortuni)
        Public CoperturaSportAereiRicoveroConvalescenza As New CoperturaSingola(PartitaSportAereiRicoveroConvalescenza, New Garanzia(TipoGaranzia.SportAereiRicoveroConvalescenza), True)
        Public CoperturaSportAerei As New CoperturaComposta(CoperturaSportAereiMorte + CoperturaSportAereiIP + CoperturaSportAereiSpeseMediche + CoperturaSportAereiRicoveroConvalescenza)

        'Malattia
        Public CoperturaMalattia As New CoperturaComposta()
        'Public PartitaMalattiaBase As New Partita(TipoPartita.Malattia)
        'Public CoperturaMalattiaBase As New CoperturaSingola(PartitaMalattiaBase, New Garanzia(TipoGaranzia.MalattiaBase))
        Public PartitaMalattiaRicoveroConvalescenza As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaRicoveroConvalescenza As New CoperturaSingola(PartitaMalattiaRicoveroConvalescenza, New Garanzia(TipoGaranzia.MalattiaRicoveroConvalescenza), True)

        'SalvaPremio
        Public CoperturaSalvaPremio As New CoperturaComposta()
        Public PartitaSalvaPremioBase As New Partita(TipoPartita.SalvaPremio)
        Public CoperturaSalvaPremioBase As New CoperturaSingola(PartitaSalvaPremioBase, New Garanzia(TipoGaranzia.SalvaPremioBase))

        'Assistenza
        Public CoperturaAssistenza As New CoperturaComposta()
        Public PartitaAssistenzaBase As New Partita(TipoPartita.Assistenza)
        Public CoperturaAssistenzaBase As New CoperturaSingola(PartitaAssistenzaBase, New Garanzia(TipoGaranzia.AssistenzaBase))

        <NonSerialized()> Private AssicuratoValidato As Boolean

        <NonSerialized()> Public CoperturaInfortuniIPClassic As CoperturaSingola
        <NonSerialized()> Public CoperturaInfortuniIPTopTarget As CoperturaSingola

        Public Sub New2()
            CoperturaInfortuniIPClassic = New CoperturaSingola(PartitaInfortuniIP, New Garanzia(TipoGaranzia.InfortuniIP))
            CoperturaInfortuniIPTopTarget = New CoperturaSingola(PartitaInfortuniIP, New Garanzia(TipoGaranzia.InfortuniIP))
        End Sub

        Public Sub New(ByVal InfortuniPremium As InfortuniPremium)
            New2()
            Me.InfortuniPremium = InfortuniPremium

            With CoperturaInfortuni
                .Sezione = InfortuniPremium.SezioneInfortuni
                .AddCopertura(CoperturaInfortuniMorte)
                .AddCopertura(CoperturaInfortuniIP)
                .AddCopertura(CoperturaInfortuniIPRenditaVitalizia)
                .AddCopertura(CoperturaInfortuniSpeseMediche)
                .AddCopertura(CoperturaInfortuniRicoveroConvalescenza)
                .AddCopertura(CoperturaInfortuniImmobilizzazione)
                .AddCopertura(CoperturaInfortuniIT)
                .AddCopertura(CoperturaInfortuniTabellaINAIL)
                .AddCopertura(CoperturaInfortuniFranchigia3)
                .AddCopertura(CoperturaInfortuniFranchigia0)
                .AddCopertura(CoperturaInfortuniFranchigiaPlus)
                .AddCopertura(CoperturaInfortuniFranchigiaDiff)
                .AddCopertura(CoperturaInfortuniSVPartiAnatomiche)
                .AddCopertura(CoperturaInfortuniSVIP)
                .AddCopertura(CoperturaInfortuniForfaitFrattura)
                .AddCopertura(CoperturaInfortuniForfaitRicovero)
                .AddCopertura(CoperturaInfortuniGlobaleImmobilizzazione)
                .AddCopertura(CoperturaInfortuniDannoEstetico)
                .AddCopertura(CoperturaInfortuniMorteCircolazione)
                .AddCopertura(CoperturaInfortuniNucleoFamiliare)
                .AddCopertura(CoperturaSportAgonistico)
                '.AddCopertura(CoperturaSportAgonisticoMorte)
                '.AddCopertura(CoperturaSportAgonisticoIP)
                '.AddCopertura(CoperturaSportAgonisticoSpeseMediche)
                '.AddCopertura(CoperturaSportAgonisticoRicoveroConvalescenza)
                .AddCopertura(CoperturaSportAltoRischio)
                '.AddCopertura(CoperturaSportAltoRischioMorte)
                '.AddCopertura(CoperturaSportAltoRischioIP)
                '.AddCopertura(CoperturaSportAltoRischioSpeseMediche)
                '.AddCopertura(CoperturaSportAltoRischioRicoveroConvalescenza)
                .AddCopertura(CoperturaSportMoto)
                '.AddCopertura(CoperturaSportMotoMorte)
                '.AddCopertura(CoperturaSportMotoIP)
                '.AddCopertura(CoperturaSportMotoSpeseMediche)
                '.AddCopertura(CoperturaSportMotoRicoveroConvalescenza)
                .AddCopertura(CoperturaSportAerei)
                '.AddCopertura(CoperturaSportAereiMorte)
                '.AddCopertura(CoperturaSportAereiIP)
                '.AddCopertura(CoperturaSportAereiSpeseMediche)
                '.AddCopertura(CoperturaSportAereiRicoveroConvalescenza)
            End With

            With CoperturaMalattia
                .Sezione = InfortuniPremium.SezioneMalattia
                .AddCopertura(CoperturaMalattiaRicoveroConvalescenza)
                .AddCopertura(CoperturaMalattiaForfaitRicovero)
            End With

            With CoperturaSalvaPremio
                .Sezione = InfortuniPremium.SezioneSalvaPremio
                .AddCopertura(CoperturaSalvaPremioBase)
            End With

            With CoperturaAssistenza
                .Sezione = InfortuniPremium.SezioneAssistenza
                .AddCopertura(CoperturaAssistenzaBase)
            End With
        End Sub

        Public Sub ValidaAssicurato()
            AssicuratoValidato = False

            If TipoContraente = 0 Then
                InfortuniPremium.SetNonDisponibile("Selezionare il tipo soggetto persona fisica o giudirica")
            ElseIf FormaCopertura = 0 Then
                InfortuniPremium.SetNonDisponibile("Sceglere la forma di copertura")
            ElseIf TipoRapporto = 0 Then
                InfortuniPremium.SetNonDisponibile("Selezionare il tipo di rapporto lavorativo dell'assicurato")
            ElseIf CodiceAttivita <= 0 Then
                InfortuniPremium.SetNonDisponibile("Selezionare l'attività dell'assicurato")
            ElseIf Eta <= 0 Then
                InfortuniPremium.SetNonDisponibile("Indicare l'età dell'assicurato")
            Else
                AssicuratoValidato = True
            End If

        End Sub

        Public Sub ValidaSezioneInfortuni()

            'REGOLE DI COMPATIBILITA'
            CoperturaInfortuni.DipendeDa(AssicuratoValidato)

            CoperturaInfortuniMorte.DipendeDa(CoperturaInfortuni.IsAttivo)
            CoperturaInfortuniIP.DipendeDa(CoperturaInfortuni.IsAttivo)
            CoperturaInfortuniIPRenditaVitalizia.DipendeDa(CoperturaInfortuni.IsAttivo And (CoperturaInfortuniIP.IsNotAttivo Or InfortuniIPScelta = InfortuniIPSceltaEnum.Classic))

            Dim IPclassicIsAttivo = CoperturaInfortuniIP.IsAttivo And InfortuniIPScelta = InfortuniIPSceltaEnum.Classic
            Dim MorteOrIPAttivo = CoperturaInfortuniIP.IsAttivo Or CoperturaInfortuniMorte.IsAttivo

            CoperturaInfortuniSpeseMediche.DipendeDa(MorteOrIPAttivo)

            CoperturaInfortuniRicoveroConvalescenza.DipendeDa(MorteOrIPAttivo)
            CoperturaInfortuniImmobilizzazione.DipendeDa(CoperturaInfortuniRicoveroConvalescenza.IsAttivo)
            CoperturaInfortuniIT.DipendeDa(MorteOrIPAttivo And FormaCopertura = FormaCoperturaEnum.TempoLiberoLavoro And TipoRapporto = TipoRapportoEnum.LiberoProfessionista)
            CoperturaInfortuniTabellaINAIL.DipendeDa(CoperturaInfortuniIP.IsAttivo)
            CoperturaInfortuniFranchigia3.DipendeDa(IPclassicIsAttivo And CoperturaInfortuniFranchigia0.IsNotAttivo And CoperturaInfortuniFranchigiaDiff.IsNotAttivo And CoperturaInfortuniFranchigiaPlus.IsNotAttivo)
            CoperturaInfortuniFranchigia0.DipendeDa(IPclassicIsAttivo And CoperturaInfortuniFranchigia3.IsNotAttivo And CoperturaInfortuniFranchigiaDiff.IsNotAttivo And CoperturaInfortuniFranchigiaPlus.IsNotAttivo)
            CoperturaInfortuniFranchigiaPlus.DipendeDa(IPclassicIsAttivo And CoperturaInfortuniFranchigia3.IsNotAttivo And CoperturaInfortuniFranchigiaDiff.IsNotAttivo And CoperturaInfortuniFranchigia0.IsNotAttivo)
            CoperturaInfortuniFranchigiaDiff.DipendeDa(IPclassicIsAttivo And CoperturaInfortuniFranchigia3.IsNotAttivo And CoperturaInfortuniFranchigia0.IsNotAttivo And CoperturaInfortuniFranchigiaPlus.IsNotAttivo)
            CoperturaInfortuniSVPartiAnatomiche.DipendeDa(IPclassicIsAttivo And FormaCopertura = FormaCoperturaEnum.TempoLiberoLavoro And IsOneOf(CodiceAttivita, 126, 142, 153, 212, 214, 225, 229, 231, 232, 255, 266, 299, 324))
            CoperturaInfortuniSVIP.DipendeDa(IPclassicIsAttivo)
            CoperturaInfortuniForfaitFrattura.DipendeDa(IPclassicIsAttivo)
            CoperturaInfortuniForfaitRicovero.DipendeDa(IPclassicIsAttivo)
            CoperturaInfortuniGlobaleImmobilizzazione.DipendeDa(IPclassicIsAttivo)
            CoperturaInfortuniDannoEstetico.DipendeDa(IPclassicIsAttivo)
            CoperturaInfortuniMorteCircolazione.DipendeDa(CoperturaInfortuniMorte.IsAttivo)

            CoperturaInfortuniNucleoFamiliare.DipendeDa(MorteOrIPAttivo And CoperturaInfortuniIPRenditaVitalizia.IsNotAttivo And CoperturaInfortuniIT.IsNotAttivo And TipoContraente = TipoContraenteEnum.PersonaFisica)

            CoperturaSportAgonistico.DipendeDa(MorteOrIPAttivo)
            CoperturaSportAgonisticoMorte.DipendeDa(CoperturaSportAgonistico.IsAttivo And CoperturaInfortuniMorte.IsAttivo)
            CoperturaSportAgonisticoIP.DipendeDa(CoperturaSportAgonistico.IsAttivo And CoperturaInfortuniIP.IsAttivo)
            CoperturaSportAgonisticoSpeseMediche.DipendeDa(CoperturaSportAgonistico.IsAttivo And CoperturaInfortuniSpeseMediche.IsAttivo)
            CoperturaSportAgonisticoRicoveroConvalescenza.DipendeDa(CoperturaSportAgonistico.IsAttivo And CoperturaInfortuniRicoveroConvalescenza.IsAttivo)
            SportAgonisticoRicoveroConvalescenzaScelta = InfortuniRicoveroConvalescenzaScelta

            CoperturaSportAltoRischio.DipendeDa(MorteOrIPAttivo)
            CoperturaSportAltoRischioMorte.DipendeDa(CoperturaSportAltoRischio.IsAttivo And CoperturaInfortuniMorte.IsAttivo)
            CoperturaSportAltoRischioIP.DipendeDa(CoperturaSportAltoRischio.IsAttivo And CoperturaInfortuniIP.IsAttivo)
            CoperturaSportAltoRischioSpeseMediche.DipendeDa(CoperturaSportAltoRischio.IsAttivo And CoperturaInfortuniSpeseMediche.IsAttivo)
            CoperturaSportAltoRischioRicoveroConvalescenza.DipendeDa(CoperturaSportAltoRischio.IsAttivo And CoperturaInfortuniRicoveroConvalescenza.IsAttivo)
            SportAltoRischioRicoveroConvalescenzaScelta = InfortuniRicoveroConvalescenzaScelta

            CoperturaSportMoto.DipendeDa(MorteOrIPAttivo)
            CoperturaSportMotoMorte.DipendeDa(CoperturaSportMoto.IsAttivo And CoperturaInfortuniMorte.IsAttivo)
            CoperturaSportMotoIP.DipendeDa(CoperturaSportMoto.IsAttivo And CoperturaInfortuniIP.IsAttivo)
            CoperturaSportMotoSpeseMediche.DipendeDa(CoperturaSportMoto.IsAttivo And CoperturaInfortuniSpeseMediche.IsAttivo)
            CoperturaSportMotoRicoveroConvalescenza.DipendeDa(CoperturaSportMoto.IsAttivo And CoperturaInfortuniRicoveroConvalescenza.IsAttivo)
            SportMotoRicoveroConvalescenzaScelta = InfortuniRicoveroConvalescenzaScelta

            CoperturaSportAerei.DipendeDa(MorteOrIPAttivo)
            CoperturaSportAereiMorte.DipendeDa(CoperturaSportAerei.IsAttivo And CoperturaInfortuniMorte.IsAttivo)
            CoperturaSportAereiIP.DipendeDa(CoperturaSportAerei.IsAttivo And CoperturaInfortuniIP.IsAttivo)
            CoperturaSportAereiSpeseMediche.DipendeDa(CoperturaSportAerei.IsAttivo And CoperturaInfortuniSpeseMediche.IsAttivo)
            CoperturaSportAereiRicoveroConvalescenza.DipendeDa(CoperturaSportAerei.IsAttivo And CoperturaInfortuniRicoveroConvalescenza.IsAttivo)
            SportAereiRicoveroConvalescenzaScelta = InfortuniRicoveroConvalescenzaScelta

            If AssicuratoValidato = False Then Return

            'LIMITI ASSUNTIVI
            If CoperturaInfortuniIP.IsAttivo And InfortuniIPScelta = InfortuniIPSceltaEnum.TopTarget Then
                PartitaInfortuniMorte.LimiteAssuntivoMassimo(2000000D)
            Else
                PartitaInfortuniMorte.LimiteAssuntivoMassimo(1500000D)
            End If

            If InfortuniIPScelta = InfortuniIPSceltaEnum.TopTarget Then
                PartitaInfortuniIP.LimiteAssuntivoMassimo(2000000D)
            ElseIf CoperturaInfortuniFranchigia0.IsAttivo Then
                PartitaInfortuniIP.LimiteAssuntivoMassimo(200000D)
            ElseIf CoperturaInfortuniFranchigiaDiff.IsAttivo Then
                PartitaInfortuniIP.LimiteAssuntivoMassimo(600000D)
            ElseIf CoperturaInfortuniSVPartiAnatomiche.IsAttivo Then
                PartitaInfortuniIP.LimiteAssuntivoMassimo(400000D)
            ElseIf CoperturaInfortuniSVIP.IsAttivo Then
                PartitaInfortuniIP.LimiteAssuntivoMassimo(400000D)
            Else
                PartitaInfortuniIP.LimiteAssuntivoMassimo(750000D)
            End If

            If CoperturaInfortuniIPRenditaVitalizia.MassimaleAttivo = 60000D Then
                PartitaInfortuniIP.LimiteAssuntivoMassimo(500000D)
            ElseIf CoperturaInfortuniIPRenditaVitalizia.MassimaleAttivo = 90000D Then
                If Eta > 50 Then
                    PartitaInfortuniIP.LimiteAssuntivoMassimo(250000D)
                Else
                    CoperturaInfortuniIP.SetNonDisponibile("Rendita vitalizia non concedibile con l'invalidita permanente")
                End If
            End If

            Dim sommaAssicurataAttiva = CoperturaInfortuniMorte.SommaAssicurataAttiva + CoperturaInfortuniIP.SommaAssicurataAttiva
            'PartitaInfortuniSpeseMediche.LimiteAssuntivoMassimo(0.1D * sommaAssicurataAttiva, 20000D)
            'PartitaInfortuniSpeseMediche.LimiteAssuntivoMinimo(2500D)
            PartitaInfortuniRicoveroConvalescenza.LimiteAssuntivoMassimo(0.0005D * sommaAssicurataAttiva, 250D)
            PartitaInfortuniImmobilizzazione.LimiteAssuntivoMassimo(0.0003D * sommaAssicurataAttiva, 150D)

            If InfortuniITScelta = InfortuniITScetaEnum.InfortuniITIntegrale Then
                PartitaInfortuniIT.LimiteAssuntivoMassimo(0.0002D * sommaAssicurataAttiva, 70D)
            ElseIf InfortuniITScelta = InfortuniITScetaEnum.InfortuniITParziale Then
                PartitaInfortuniIT.LimiteAssuntivoMassimo(0.00025D * sommaAssicurataAttiva, 120D)
            ElseIf InfortuniITScelta = InfortuniITScetaEnum.InfortuniITTotale Then
                PartitaInfortuniIT.LimiteAssuntivoMassimo(0.00025D * sommaAssicurataAttiva, 150D)
            End If

            If CoperturaInfortuniRicoveroConvalescenza.SommaAssicurataAttiva + CoperturaInfortuniIT.SommaAssicurataAttiva + CoperturaInfortuniImmobilizzazione.SommaAssicurataAttiva > 250D Then
                CoperturaInfortuni.SetNonDisponibile("Cumulo indennità ricovero e convalescenza, IT e immobilizazione > €250,00")
            End If

            PartitaSportAgonisticoMorte.LimiteAssuntivoMassimo(PartitaInfortuniMorte.SommaAssicurata, 250000D)
            PartitaSportAgonisticoIP.LimiteAssuntivoMassimo(PartitaInfortuniIP.SommaAssicurata, 250000D)
            'PartitaSportAgonisticoSpeseMediche.LimiteAssuntivoMassimo(PartitaInfortuniSpeseMediche.SommaAssicurata, 10000D)
            PartitaSportAgonisticoRicoveroConvalescenza.LimiteAssuntivoMassimo(PartitaInfortuniRicoveroConvalescenza.SommaAssicurata, 100D)

            PartitaSportAltoRischioMorte.LimiteAssuntivoMassimo(PartitaInfortuniMorte.SommaAssicurata, 250000D)
            PartitaSportAltoRischioIP.LimiteAssuntivoMassimo(PartitaInfortuniIP.SommaAssicurata, 250000D)
            'PartitaSportAltoRischioSpeseMediche.LimiteAssuntivoMassimo(PartitaInfortuniSpeseMediche.SommaAssicurata, 10000D)
            PartitaSportAltoRischioRicoveroConvalescenza.LimiteAssuntivoMassimo(PartitaInfortuniRicoveroConvalescenza.SommaAssicurata, 100D)

            PartitaSportMotoMorte.LimiteAssuntivoMassimo(PartitaInfortuniMorte.SommaAssicurata, 250000D)
            PartitaSportMotoIP.LimiteAssuntivoMassimo(PartitaInfortuniIP.SommaAssicurata, 250000D)
            'PartitaSportMotoSpeseMediche.LimiteAssuntivoMassimo(PartitaInfortuniSpeseMediche.SommaAssicurata, 10000D)
            PartitaSportMotoRicoveroConvalescenza.LimiteAssuntivoMassimo(PartitaInfortuniRicoveroConvalescenza.SommaAssicurata, 100D)

            PartitaSportAereiMorte.LimiteAssuntivoMassimo(PartitaInfortuniMorte.SommaAssicurata, 250000D)
            PartitaSportAereiIP.LimiteAssuntivoMassimo(PartitaInfortuniIP.SommaAssicurata, 250000D)
            'PartitaSportAereiSpeseMediche.LimiteAssuntivoMassimo(PartitaInfortuniSpeseMediche.SommaAssicurata, 10000D)
            PartitaSportAereiRicoveroConvalescenza.LimiteAssuntivoMassimo(PartitaInfortuniRicoveroConvalescenza.SommaAssicurata, 100D)



            'TARIFFA
            Dim indiceTax As Integer = 9
            If FormaCopertura = FormaCoperturaEnum.TempoLiberoLavoro Then
                indiceTax = P01204TG.GetAttivita().Item(CodiceAttivita).ClasseRischio
            ElseIf FormaCopertura = FormaCoperturaEnum.Lavoro Then
                indiceTax = 4 + P01204TG.GetAttivita().Item(CodiceAttivita).ClasseRischio
            End If

            With CoperturaInfortuniMorte
                .Tariffa.TassoX1000 = Scegli(indiceTax, 0.55D, 0.68D, 0.76D, 0.93D, 0.33D, 0.41D, 0.45D, 0.56D, 0.48D)
            End With

            With CoperturaInfortuniIP
                If InfortuniIPScelta = 0 Then InfortuniIPScelta = InfortuniIPSceltaEnum.Classic
                If InfortuniIPScelta = InfortuniIPSceltaEnum.Classic Then
                    .Tariffa.TassoX1000 = Scegli(indiceTax, 0.75D, 0.92D, 1.03D, 1.26D, 0.45D, 0.55D, 0.62D, 0.76D, 0.65D)
                ElseIf InfortuniIPScelta = InfortuniIPSceltaEnum.TopTarget Then
                    .Tariffa.TassoX1000 = Scegli(indiceTax, 0.42D, 0.52D, 0.58D, 0.71D, 0.25D, 0.31D, 0.35D, 0.43D, 0.37D)
                End If
            End With
            CoperturaInfortuniIPClassic.Tariffa.TassoX1000 = Scegli(indiceTax, 0.75D, 0.92D, 1.03D, 1.26D, 0.45D, 0.55D, 0.62D, 0.76D, 0.65D)
            CoperturaInfortuniIPTopTarget.Tariffa.TassoX1000 = Scegli(indiceTax, 0.42D, 0.52D, 0.58D, 0.71D, 0.25D, 0.31D, 0.35D, 0.43D, 0.37D)



            Dim indiceEta As Integer = 0
            If Eta >= 32 And Eta <= 70 Then
                indiceEta = (Eta - 26) \ 5 - 1

                With CoperturaInfortuniIPRenditaVitalizia
                    If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 30000
                    If .Garanzia.Massimale = 30000 Then
                        .Tariffa.Base = Scegli(9 * indiceEta + indiceTax, 412, 510, 567, 697, 247, 306, 340, 418, 359,
                                                                          385, 477, 530, 652, 231, 286, 318, 391, 336,
                                                                          345, 428, 475, 584, 207, 257, 285, 350, 301,
                                                                          312, 386, 429, 528, 187, 232, 258, 317, 272,
                                                                          273, 337, 375, 461, 164, 202, 225, 277, 238,
                                                                          240, 297, 330, 406, 144, 178, 198, 244, 209,
                                                                          202, 249, 277, 341, 121, 150, 166, 204, 176,
                                                                          170, 210, 234, 287, 102, 126, 140, 172, 148)

                    ElseIf .Garanzia.Massimale = 60000 Then
                        .Tariffa.Base = Scegli(9 * indiceEta + indiceTax, 824, 1020, 1134, 1394, 494, 612, 680, 836, 718,
                                                                          770, 954, 1060, 1304, 462, 572, 636, 782, 672,
                                                                          690, 856, 950, 1168, 414, 514, 570, 700, 602,
                                                                          624, 772, 858, 1056, 374, 464, 516, 634, 545,
                                                                          546, 674, 750, 922, 328, 404, 450, 554, 475,
                                                                          480, 594, 660, 812, 288, 356, 396, 488, 418,
                                                                          404, 498, 554, 682, 242, 300, 332, 408, 351,
                                                                          340, 420, 468, 574, 204, 252, 280, 344, 296)

                    ElseIf .Garanzia.Massimale = 90000 Then
                        .Tariffa.Base = Scegli(9 * indiceEta + indiceTax, 1236, 1530, 1701, 2091, 741, 918, 1020, 1254, 1077,
                                                                          1155, 1431, 1590, 1956, 693, 858, 954, 1173, 1007,
                                                                          1035, 1284, 1425, 1752, 621, 771, 855, 1050, 903,
                                                                          936, 1158, 1287, 1584, 561, 696, 774, 951, 817,
                                                                          819, 1011, 1125, 1383, 492, 606, 675, 831, 713,
                                                                          720, 891, 990, 1218, 432, 534, 594, 732, 627,
                                                                          606, 747, 831, 1023, 363, 450, 498, 612, 527,
                                                                          510, 630, 702, 861, 306, 378, 420, 516, 444)

                    End If
                End With
            End If

            With CoperturaInfortuniSpeseMediche
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 2500

                If .Garanzia.Massimale > 0.1D * sommaAssicurataAttiva Then
                    .Garanzia.Massimale = MinimoPiuVicino(0.1D * sommaAssicurataAttiva, 2500, 3000, 3500, 4000, 4500, 5000, 6000, 7000, 8000, 9000, 10000, 15000, 20000)
                End If

                '.Partita.SommaAssicurata = .Garanzia.Massimale
                If .Garanzia.Massimale <= 10000D Then
                    .Tariffa.Base = 0D
                    .Tariffa.TassoX1000 = Scegli(indiceTax, 15.93D, 19.71D, 21.91D, 26.92D, 9.56D, 11.83D, 13.14D, 16.15D, 13.87D)
                ElseIf .Garanzia.Massimale > 10000 Then
                    .Tariffa.Base = 10D * (Scegli(indiceTax, 15.93D, 19.71D, 21.91D, 26.92D, 9.56D, 11.83D, 13.14D, 16.15D, 13.87D) -
                                           Scegli(indiceTax, 8.76D, 10.84D, 12.05D, 14.81D, 5.26D, 6.5D, 7.23D, 8.88D, 7.63D))
                    .Tariffa.TassoX1000 = Scegli(indiceTax, 8.76D, 10.84D, 12.05D, 14.81D, 5.26D, 6.5D, 7.23D, 8.88D, 7.63D)
                Else
                    .Tariffa.Base = 0D
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaInfortuniRicoveroConvalescenza
                If InfortuniRicoveroConvalescenzaScelta = 0 Then InfortuniRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.SoloRicovero
                If InfortuniRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.SoloRicovero Then
                    .Tariffa.Tasso = Scegli(indiceTax, 0.39D, 0.49D, 0.54D, 0.66D, 0.24D, 0.29D, 0.32D, 0.4D, 0.34D)
                ElseIf InfortuniRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.RicoveroConvalescenza Then
                    .Tariffa.Tasso = Scegli(indiceTax, 0.44D, 0.54D, 0.6D, 0.74D, 0.26D, 0.32D, 0.36D, 0.44D, 0.38D)
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaInfortuniImmobilizzazione
                .Tariffa.Tasso = Scegli(indiceTax, 0.91D, 1.13D, 1.25D, 1.54D, 0.55D, 0.68D, 0.75D, 0.92D, 0.79D)
            End With

            With CoperturaInfortuniIT
                If InfortuniITScelta = 0 Then InfortuniITScelta = InfortuniITScetaEnum.InfortuniITIntegrale
                If InfortuniITScelta = InfortuniITScetaEnum.InfortuniITIntegrale Then
                    .Tariffa.Tasso = Scegli(indiceTax, 9.29D, 11.5D, 12.78D, 15.71D, 5.58D, 6.9D, 7.67D, 9.43D, 8.1D)
                ElseIf InfortuniITScelta = InfortuniITScetaEnum.InfortuniITParziale Then
                    .Tariffa.Tasso = Scegli(indiceTax, 6.88D, 8.52D, 9.47D, 11.64D, 4.13D, 5.11D, 5.68D, 6.98D, 6D)
                ElseIf InfortuniITScelta = InfortuniITScetaEnum.InfortuniITTotale Then
                    .Tariffa.Tasso = Scegli(indiceTax, 4.47D, 5.54D, 6.16D, 7.56D, 2.68D, 3.32D, 3.69D, 4.54D, 3.9D)
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            'PartitaInfortuniIPPremioAttivo.SommaAssicurata = CoperturaInfortuniIP.PremioAttivoCrudo
            PartitaInfortuniIPPremioAttivo.SommaAssicurata = CoperturaInfortuniIPClassic.PremioCrudo

            With CoperturaInfortuniTabellaINAIL
                .Tariffa.Tasso = 0.3D
            End With

            With CoperturaInfortuniFranchigia3
                .Tariffa.Tasso = 0.6D
            End With

            With CoperturaInfortuniFranchigia0
                .Tariffa.Tasso = 2D
            End With

            With CoperturaInfortuniFranchigiaPlus
                .Tariffa.Tasso = 0.8D
            End With

            With CoperturaInfortuniFranchigiaDiff
                .Tariffa.Tasso = 0.9D
            End With

            With CoperturaInfortuniSVPartiAnatomiche
                .Tariffa.Tasso = 0.35D
            End With

            With CoperturaInfortuniSVIP
                .Tariffa.Tasso = 0.25D
            End With

            With CoperturaInfortuniForfaitFrattura
                .Garanzia.Massimale = 200D
                .Tariffa.Base = 6D
            End With

            With CoperturaInfortuniForfaitRicovero
                .Garanzia.Massimale = 3000D
                .Tariffa.Base = 8D
            End With

            With CoperturaInfortuniGlobaleImmobilizzazione
                .Partita.SommaAssicurata = CoperturaInfortuniImmobilizzazione.PremioAttivoCrudo
                .Tariffa.Tasso = 0.4D
            End With

            With CoperturaInfortuniDannoEstetico
                .Tariffa.Tasso = 0.18D
                .Partita.SommaAssicurata = CoperturaInfortuniIP.PremioAttivoCrudo +
                                           CoperturaInfortuniTabellaINAIL.PremioAttivoCrudo +
                                           CoperturaInfortuniFranchigia3.PremioAttivoCrudo +
                                           CoperturaInfortuniFranchigia0.PremioAttivoCrudo +
                                           CoperturaInfortuniFranchigiaPlus.PremioAttivoCrudo +
                                           CoperturaInfortuniFranchigiaDiff.PremioAttivoCrudo +
                                           CoperturaInfortuniSVPartiAnatomiche.PremioAttivoCrudo +
                                           CoperturaInfortuniSVIP.PremioAttivoCrudo
            End With

            With CoperturaInfortuniMorteCircolazione
                .Garanzia.Massimale = 50000D
                .Tariffa.Base = 30D
            End With

            With CoperturaInfortuniNucleoFamiliare
                .Tariffa.Tasso = 0.25D
                .Partita.SommaAssicurata = CoperturaInfortuniMorte.PremioAttivoCrudo +
                                           CoperturaInfortuniIP.PremioAttivoCrudo +
                                           CoperturaInfortuniIPRenditaVitalizia.PremioAttivoCrudo +
                                           CoperturaInfortuniSpeseMediche.PremioAttivoCrudo +
                                           CoperturaInfortuniRicoveroConvalescenza.PremioAttivoCrudo +
                                           CoperturaInfortuniImmobilizzazione.PremioAttivoCrudo +
                                           CoperturaInfortuniIT.PremioAttivoCrudo +
                                           CoperturaInfortuniTabellaINAIL.PremioAttivoCrudo +
                                           CoperturaInfortuniFranchigia3.PremioAttivoCrudo +
                                           CoperturaInfortuniFranchigia0.PremioAttivoCrudo +
                                           CoperturaInfortuniFranchigiaPlus.PremioAttivoCrudo +
                                           CoperturaInfortuniFranchigiaDiff.PremioAttivoCrudo +
                                           CoperturaInfortuniSVPartiAnatomiche.PremioAttivoCrudo +
                                           CoperturaInfortuniSVIP.PremioAttivoCrudo +
                                           CoperturaInfortuniForfaitFrattura.PremioAttivoCrudo +
                                           CoperturaInfortuniForfaitRicovero.PremioAttivoCrudo +
                                           CoperturaInfortuniGlobaleImmobilizzazione.PremioAttivoCrudo +
                                           CoperturaInfortuniDannoEstetico.PremioAttivoCrudo +
                                           CoperturaInfortuniMorteCircolazione.PremioAttivoCrudo
            End With

            Dim PercentualeIncremento As Decimal
            If SportClasseRischio = 0 Then SportClasseRischio = SportClasseRischioEnum.Classe1

            PercentualeIncremento = Scegli(SportClasseRischio, 0.3D, 1.25D, 1.5D, 1.8D, 2D)

            'Dim coefficienteInvaliditaPermanente As Decimal = 1D +
            '                                                  CoperturaInfortuniTabellaINAIL.TassoAttivo +
            '                                                  CoperturaInfortuniFranchigia3.TassoAttivo +
            '                                                  CoperturaInfortuniFranchigia0.TassoAttivo +
            '                                                  CoperturaInfortuniFranchigiaPlus.TassoAttivo +
            '                                                  CoperturaInfortuniFranchigiaDiff.TassoAttivo +
            '                                                  CoperturaInfortuniSVPartiAnatomiche.TassoAttivo +
            '                                                  CoperturaInfortuniSVIP.TassoAttivo

            Dim coefficienteInvaliditaPermanente As Decimal = 1D

            With CoperturaSportAgonisticoMorte
                .Tariffa.TassoX1000 = PercentualeIncremento * 0.48D
            End With

            With CoperturaSportAgonisticoIP
                If InfortuniIPScelta = InfortuniIPSceltaEnum.Classic Then
                    .Tariffa.TassoX1000 = coefficienteInvaliditaPermanente * PercentualeIncremento * 0.65D
                ElseIf InfortuniIPScelta = InfortuniIPSceltaEnum.TopTarget Then
                    .Tariffa.TassoX1000 = coefficienteInvaliditaPermanente * PercentualeIncremento * 0.37D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaSportAgonisticoSpeseMediche
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 2500
                If .Garanzia.Massimale > 0.1D * (CoperturaSportAgonisticoMorte.SommaAssicurataAttiva + CoperturaSportAgonisticoIP.SommaAssicurataAttiva) Then
                    .Garanzia.Massimale = MinimoPiuVicino(0.1D * (CoperturaSportAgonisticoMorte.SommaAssicurataAttiva + CoperturaSportAgonisticoIP.SommaAssicurataAttiva), 2500, 3000, 3500, 4000, 4500, 5000, 6000, 7000, 8000, 9000, 10000)
                End If

                .Tariffa.TassoX1000 = PercentualeIncremento * 13.87D
            End With

            With CoperturaSportAgonisticoRicoveroConvalescenza
                If SportAgonisticoRicoveroConvalescenzaScelta = 0 Then SportAgonisticoRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.SoloRicovero
                If SportAgonisticoRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.SoloRicovero Then
                    .Tariffa.Tasso = PercentualeIncremento * 0.34D
                ElseIf SportAgonisticoRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.RicoveroConvalescenza Then
                    .Tariffa.Tasso = PercentualeIncremento * 0.38D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            PercentualeIncremento = 2D
            With CoperturaSportAltoRischioMorte
                .Tariffa.TassoX1000 = PercentualeIncremento * 0.48D
            End With

            With CoperturaSportAltoRischioIP
                If InfortuniIPScelta = InfortuniIPSceltaEnum.Classic Then
                    .Tariffa.TassoX1000 = coefficienteInvaliditaPermanente * PercentualeIncremento * 0.65D
                ElseIf InfortuniIPScelta = InfortuniIPSceltaEnum.TopTarget Then
                    .Tariffa.TassoX1000 = coefficienteInvaliditaPermanente * PercentualeIncremento * 0.37D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaSportAltoRischioSpeseMediche
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 2500
                If .Garanzia.Massimale > 0.1D * (CoperturaSportAltoRischioMorte.SommaAssicurataAttiva + CoperturaSportAltoRischioIP.SommaAssicurataAttiva) Then
                    .Garanzia.Massimale = MinimoPiuVicino(0.1D * (CoperturaSportAltoRischioMorte.SommaAssicurataAttiva + CoperturaSportAltoRischioIP.SommaAssicurataAttiva), 2500, 3000, 3500, 4000, 4500, 5000, 6000, 7000, 8000, 9000, 10000)
                End If
                .Tariffa.TassoX1000 = PercentualeIncremento * 13.87D
            End With

            With CoperturaSportAltoRischioRicoveroConvalescenza
                If SportAltoRischioRicoveroConvalescenzaScelta = 0 Then SportAltoRischioRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.SoloRicovero

                If SportAltoRischioRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.SoloRicovero Then
                    .Tariffa.Tasso = PercentualeIncremento * 0.34D
                ElseIf SportAltoRischioRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.RicoveroConvalescenza Then
                    .Tariffa.Tasso = PercentualeIncremento * 0.38D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            PercentualeIncremento = 6D
            With CoperturaSportMotoMorte
                .Tariffa.TassoX1000 = PercentualeIncremento * 0.48D
            End With

            With CoperturaSportMotoIP
                If InfortuniIPScelta = InfortuniIPSceltaEnum.Classic Then
                    .Tariffa.TassoX1000 = coefficienteInvaliditaPermanente * PercentualeIncremento * 0.65D
                ElseIf InfortuniIPScelta = InfortuniIPSceltaEnum.TopTarget Then
                    .Tariffa.TassoX1000 = coefficienteInvaliditaPermanente * PercentualeIncremento * 0.37D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaSportMotoSpeseMediche
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 2500
                If .Garanzia.Massimale > 0.1D * (CoperturaSportMotoMorte.SommaAssicurataAttiva + CoperturaSportMotoIP.SommaAssicurataAttiva) Then
                    .Garanzia.Massimale = MinimoPiuVicino(0.1D * (CoperturaSportMotoMorte.SommaAssicurataAttiva + CoperturaSportMotoIP.SommaAssicurataAttiva), 2500, 3000, 3500, 4000, 4500, 5000, 6000, 7000, 8000, 9000, 10000)
                End If
                .Tariffa.TassoX1000 = PercentualeIncremento * 13.87D
            End With

            With CoperturaSportMotoRicoveroConvalescenza
                If SportMotoRicoveroConvalescenzaScelta = 0 Then SportMotoRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.SoloRicovero
                If SportMotoRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.SoloRicovero Then
                    .Tariffa.Tasso = PercentualeIncremento * 0.34D
                ElseIf SportMotoRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.RicoveroConvalescenza Then
                    .Tariffa.Tasso = PercentualeIncremento * 0.38D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            PercentualeIncremento = 5D
            With CoperturaSportAereiMorte
                .Tariffa.TassoX1000 = PercentualeIncremento * 0.48D
            End With

            With CoperturaSportAereiIP
                If InfortuniIPScelta = InfortuniIPSceltaEnum.Classic Then
                    .Tariffa.TassoX1000 = coefficienteInvaliditaPermanente * PercentualeIncremento * 0.65D
                ElseIf InfortuniIPScelta = InfortuniIPSceltaEnum.TopTarget Then
                    .Tariffa.TassoX1000 = coefficienteInvaliditaPermanente * PercentualeIncremento * 0.37D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaSportAereiSpeseMediche
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 2500
                If .Garanzia.Massimale > 0.1D * (CoperturaSportAereiMorte.SommaAssicurataAttiva + CoperturaSportAereiIP.SommaAssicurataAttiva) Then
                    .Garanzia.Massimale = MinimoPiuVicino(0.1D * (CoperturaSportAereiMorte.SommaAssicurataAttiva + CoperturaSportAereiIP.SommaAssicurataAttiva), 2500, 3000, 3500, 4000, 4500, 5000, 6000, 7000, 8000, 9000, 10000)
                End If
                .Tariffa.TassoX1000 = PercentualeIncremento * 13.87D
            End With

            With CoperturaSportAereiRicoveroConvalescenza
                If SportAereiRicoveroConvalescenzaScelta = 0 Then SportAereiRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.SoloRicovero
                If SportAereiRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.SoloRicovero Then
                    .Tariffa.Tasso = PercentualeIncremento * 0.34D
                ElseIf SportAereiRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.RicoveroConvalescenza Then
                    .Tariffa.Tasso = PercentualeIncremento * 0.38D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With


        End Sub

        Public Sub ValidaSezioneMalattia()
            'REGOLE DI COMPATIBILITA'
            CoperturaMalattia.DipendeDa(CoperturaInfortuniRicoveroConvalescenza.IsAttivo Or CoperturaInfortuniForfaitRicovero.IsAttivo)
            CoperturaMalattiaRicoveroConvalescenza.DipendeDa(CoperturaMalattia.IsAttivo And CoperturaInfortuniRicoveroConvalescenza.IsAttivo)
            CoperturaMalattiaForfaitRicovero.DipendeDa(CoperturaMalattia.IsAttivo And CoperturaInfortuniForfaitRicovero.IsAttivo)

            If AssicuratoValidato = False Then Return

            'LIMITI ASSUNTIVI
            'PartitaMalattiaRicoveroConvalescenza.LimiteAssuntivoMassimo(PartitaInfortuniRicoveroConvalescenza.SommaAssicurata, 250D)

            Dim indiceEta As Integer = 0
            If Eta < 18 Then
                indiceEta = 1
            ElseIf Eta < 45 Then
                indiceEta = 2
            ElseIf Eta < 61 Then
                indiceEta = 3
            ElseIf Eta < 66 Then
                indiceEta = 4
            ElseIf Eta < 71 Then
                indiceEta = 5
            ElseIf Eta < 76 Then
                indiceEta = 6
            End If

            '30-11-2015: Da Gilberto ricovero malattia = ricovero infortuni
            PartitaMalattiaRicoveroConvalescenza.SommaAssicurata = PartitaInfortuniRicoveroConvalescenza.SommaAssicurata
            MalattiaRicoveroConvalescenzaScelta = InfortuniRicoveroConvalescenzaScelta

            'TARIFFA
            With CoperturaMalattiaRicoveroConvalescenza
                'If MalattiaRicoveroConvalescenzaScelta = 0 Then MalattiaRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.SoloRicovero
                If MalattiaRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.SoloRicovero Then
                    .Tariffa.Tasso = Scegli(indiceEta, 0.85D, 1.7D, 2.8D, 3.8D, 4.6D, 6D)
                ElseIf MalattiaRicoveroConvalescenzaScelta = RicoveroConvalescenzaSceltaEnum.RicoveroConvalescenza Then
                    .Tariffa.Tasso = Scegli(indiceEta, 1.45D, 2.9D, 4.75D, 6.5D, 7.8D, 10.2D)
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaMalattiaForfaitRicovero
                .Garanzia.Massimale = 3000D
                .Tariffa.Base = 17D
            End With

        End Sub

        Public Sub ValidaSezioneSalvaPremio()
            CoperturaSalvaPremio.Stato = StatoCopertura.attiva
            CoperturaSalvaPremioBase.DipendeDa((CoperturaInfortuniMorte.IsAttivo Or CoperturaInfortuniIP.IsAttivo Or CoperturaInfortuniIPRenditaVitalizia.IsAttivo) And TipoContraente = TipoContraenteEnum.PersonaFisica)
            If AssicuratoValidato = False Then Return


            With CoperturaSalvaPremioBase
                .Tariffa.Tasso = 0.04D
                .Partita.SommaAssicurata = CoperturaInfortuniMorte.PremioAttivoCrudo +
                                           CoperturaInfortuniIP.PremioAttivoCrudo +
                                           CoperturaInfortuniSpeseMediche.PremioAttivoCrudo +
                                           CoperturaInfortuniRicoveroConvalescenza.PremioAttivoCrudo +
                                           CoperturaInfortuniImmobilizzazione.PremioAttivoCrudo +
                                           CoperturaInfortuniIT.PremioAttivoCrudo +
                                           CoperturaInfortuniTabellaINAIL.PremioAttivoCrudo +
                                           CoperturaInfortuniFranchigia3.PremioAttivoCrudo +
                                           CoperturaInfortuniFranchigia0.PremioAttivoCrudo +
                                           CoperturaInfortuniFranchigiaPlus.PremioAttivoCrudo +
                                           CoperturaInfortuniFranchigiaDiff.PremioAttivoCrudo +
                                           CoperturaInfortuniSVPartiAnatomiche.PremioAttivoCrudo +
                                           CoperturaInfortuniSVIP.PremioAttivoCrudo +
                                           CoperturaInfortuniForfaitFrattura.PremioAttivoCrudo +
                                           CoperturaInfortuniForfaitRicovero.PremioAttivoCrudo +
                                           CoperturaMalattiaForfaitRicovero.PremioAttivoCrudo +
                                           CoperturaInfortuniGlobaleImmobilizzazione.PremioAttivoCrudo +
                                           CoperturaInfortuniDannoEstetico.PremioAttivoCrudo +
                                           CoperturaInfortuniMorteCircolazione.PremioAttivoCrudo +
                                           CoperturaSportAgonisticoMorte.PremioAttivoCrudo +
                                           CoperturaSportAgonisticoIP.PremioAttivoCrudo +
                                           CoperturaSportAgonisticoSpeseMediche.PremioAttivoCrudo +
                                           CoperturaSportAgonisticoRicoveroConvalescenza.PremioAttivoCrudo +
                                           CoperturaSportAltoRischioMorte.PremioAttivoCrudo +
                                           CoperturaSportAltoRischioIP.PremioAttivoCrudo +
                                           CoperturaSportAltoRischioSpeseMediche.PremioAttivoCrudo +
                                           CoperturaSportAltoRischioRicoveroConvalescenza.PremioAttivoCrudo +
                                           CoperturaSportMotoMorte.PremioAttivoCrudo +
                                           CoperturaSportMotoIP.PremioAttivoCrudo +
                                           CoperturaSportMotoSpeseMediche.PremioAttivoCrudo +
                                           CoperturaSportMotoRicoveroConvalescenza.PremioAttivoCrudo +
                                           CoperturaSportAereiMorte.PremioAttivoCrudo +
                                           CoperturaSportAereiIP.PremioAttivoCrudo +
                                           CoperturaSportAereiSpeseMediche.PremioAttivoCrudo +
                                           CoperturaSportAereiRicoveroConvalescenza.PremioAttivoCrudo +
                                           CoperturaMalattiaRicoveroConvalescenza.PremioAttivoCrudo +
                                           CoperturaMalattiaForfaitRicovero.PremioAttivoCrudo
                If .Partita.SommaAssicurata < 375D Then
                    .Partita.SommaAssicurata = 375D
                End If
            End With


        End Sub

        Public Sub ValidaSezioneAssistenza()
            CoperturaAssistenza.Stato = StatoCopertura.attiva
            CoperturaAssistenzaBase.DipendeDa(CoperturaInfortuniMorte.IsAttivo Or CoperturaInfortuniIP.IsAttivo Or CoperturaInfortuniIPRenditaVitalizia.IsAttivo)
            If AssicuratoValidato = False Then Return

            With CoperturaAssistenzaBase
                If CoperturaInfortuniNucleoFamiliare.IsAttivo Then
                    .Tariffa.Base = 12.5D
                Else
                    .Tariffa.Base = 10D
                End If
            End With
        End Sub
    End Class
End Namespace
