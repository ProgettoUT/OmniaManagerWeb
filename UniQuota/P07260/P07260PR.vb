Namespace P07260
    <Serializable()> Public Class YouCondominio
        Inherits Prodotto

        <NonSerialized()> Public Tabelle As P07260TR

        'Dati obbligatori primitivi
        Public NumeroFabbricati As Integer
        Public NumeroUnitaImmobiliari As Integer
        Public NumeroUnitaAbitative As Integer
        Public CiSonoEserciziComerciali As Boolean
        Public AnnoCostruzione As Integer
        Public RifacimentoIdrotermosanitari As Boolean
        Public TipologiaFabbricato As TipologiaFabbricatoEnum
        Public ClasseRegionaleFenomeniAtmosferici As ZonaTerritorialeEventiAtmosfericiEnum
        Public Provincia As ProvinciaEnum
        Public Comune As Integer
        Public CaratteristicaCostruttiva As CaratteristicaCostruttivaEnum

        Public AdeguamentoFacoltativo As Boolean

        'Dati derivati
        Public EtaFabbricato As Integer
        Public CoefficienteDiVetusta As Decimal
        Public CoefficienteDiAdeguamento As Decimal

        'I tassi e i premi della presente Tariffa sono annui e imponibili; per il calcolo
        'del premio lordo vanno aggiunti l’eventuale aumento per frazionamento e le imposte.

        Public SezioneIncendio As New Sezione(Me, TipoSezione.Incendio)
        Public SezioneResponsabilitaCivile As New Sezione(Me, TipoSezione.ResponsabilitaCivile)
        Public SezioneDanniAcqua As New Sezione(Me, TipoSezione.DanniAcqua)
        Public SezioneInfortuni As New Sezione(Me, TipoSezione.Infortuni)
        Public SezioneTutelaLegale As New Sezione(Me, TipoSezione.TutelaLegale)
        Public SezioneTerremoto As New Sezione(Me, TipoSezione.Terremoto)

        'Incendio
        Public PartitaIncendio As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioBase As New CoperturaSingola(PartitaIncendio, New Garanzia(TipoGaranzia.IncendioBase), True)
        Public CoperturaIncendioDemolizioneSgombero As New CoperturaSingola(PartitaIncendio, New Garanzia(TipoGaranzia.IncendioDemolizioneSgombero))
        Public CoperturaIncendioFenomeniAtmosfericiBasic As New CoperturaSingola(PartitaIncendio, New Garanzia(TipoGaranzia.IncendioFenomeniAtmosfericiBasic))
        Public CoperturaIncendioFenomeniAtmosfericiMediuum As New CoperturaSingola(PartitaIncendio, New Garanzia(TipoGaranzia.IncendioFenomeniAtmosfericiMedium))
        Public CoperturaIncendioAttiVandaliciDolosi As New CoperturaSingola(PartitaIncendio, New Garanzia(TipoGaranzia.IncendioAttiVandaliciDolosi))
        Public CoperturaIncendioAttiTerrorismo As New CoperturaSingola(PartitaIncendio, New Garanzia(TipoGaranzia.IncendioAttiTerrorismo))
        Public CoperturaIncendioDanniImpiantiElettrici As New CoperturaSingola(PartitaIncendio, New Garanzia(TipoGaranzia.IncendioDanniImpiantiElettrici))
        Public CoperturaIncendioCristalli As New CoperturaSingola(PartitaIncendio, New Garanzia(TipoGaranzia.IncendioCristalli))
        Public CoperturaIncendioOnorariPeriti As New CoperturaSingola(PartitaIncendio, New Garanzia(TipoGaranzia.IncendioOnorariPeriti))
        Public CoperturaIncendioEnergy As New CoperturaSingola(PartitaIncendio, _
                                                               New Garanzia(TipoGaranzia.IncendioEnergy, _
                                                               New Garanzia(TipoGaranzia.IncendioEnergy1) + _
                                                               New Garanzia(TipoGaranzia.IncendioEnergy2)))
        Public CoperturaIncendioExtra As New CoperturaSingola(PartitaIncendio, _
                                                               New Garanzia(TipoGaranzia.IncendioExtra, _
                                                               New Garanzia(TipoGaranzia.IncendioExtra1) + _
                                                               New Garanzia(TipoGaranzia.IncendioExtra2) + _
                                                               New Garanzia(TipoGaranzia.IncendioExtra3)))

        Public CoperturaIncendioEstensioneGaranziaBase As New CoperturaSingola(PartitaIncendio, New Garanzia(TipoGaranzia.IncendioEstensioneGaranziaBase))

        Public CoperturaIncendio As New CoperturaComposta(CoperturaIncendioBase + CoperturaIncendioDemolizioneSgombero _
                                                           + CoperturaIncendioFenomeniAtmosfericiBasic + CoperturaIncendioFenomeniAtmosfericiMediuum _
                                                           + CoperturaIncendioAttiVandaliciDolosi + CoperturaIncendioAttiTerrorismo _
                                                           + CoperturaIncendioDanniImpiantiElettrici + CoperturaIncendioCristalli _
                                                           + CoperturaIncendioOnorariPeriti _
                                                           + CoperturaIncendioEstensioneGaranziaBase _
                                                           + CoperturaIncendioEnergy + CoperturaIncendioExtra)
        'Responsabilita' civile
        Public PartitaResponsabilitaCivile As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaResponsabilitaCivileBase As New CoperturaSingola(PartitaResponsabilitaCivile, New Garanzia(TipoGaranzia.ResponsabilitaCivileBase))
        Public CoperturaResponsabilitaPrestatoriLavoro As New CoperturaSingola(PartitaResponsabilitaCivile, New Garanzia(TipoGaranzia.ResponsabilitaCivilePrestatoriLavoro))
        Public CoperturaResponsabilitaCommittenzaLavori As New CoperturaSingola(PartitaResponsabilitaCivile, New Garanzia(TipoGaranzia.ResponsabilitaCivileCommittenzaLavori))
        Public CoperturaResponsabilitaConduzioneUnitaImmobiliari As New CoperturaSingola(PartitaResponsabilitaCivile, New Garanzia(TipoGaranzia.ResponsabilitaCivileConduzioneUnitaImmobiliari))
        Public CoperturaResponsabilitaAmministratore As New CoperturaSingola(PartitaResponsabilitaCivile, New Garanzia(TipoGaranzia.ResponsabilitaCivileAmministratore))
        Public CoperturaResponsabilitaEnergy As New CoperturaSingola(PartitaResponsabilitaCivile, _
                                                               New Garanzia(TipoGaranzia.ResponsabilitaCivileEnergy, _
                                                               New Garanzia(TipoGaranzia.IncendioEnergy1) + _
                                                               New Garanzia(TipoGaranzia.IncendioEnergy2)))
        Public CoperturaResponsabilitaCivile As New CoperturaComposta(CoperturaResponsabilitaCivileBase + CoperturaResponsabilitaPrestatoriLavoro _
                                                                      + CoperturaResponsabilitaCommittenzaLavori + CoperturaResponsabilitaConduzioneUnitaImmobiliari _
                                                                      + CoperturaResponsabilitaAmministratore + CoperturaResponsabilitaEnergy)


        'Danni acqua e altri liquidi
        Public PartitaDanniAcqua As New Partita(TipoPartita.DanniAcqua)
        Public CoperturaDanniAcquaBase As New CoperturaSingola(PartitaDanniAcqua, New Garanzia(TipoGaranzia.DanniAcquaBase))
        Public CoperturaDanniAcquaFuoriUscitaOcclusione As New CoperturaSingola(PartitaDanniAcqua, New Garanzia(TipoGaranzia.DanniAcquaFuoriUscitaOcclusione))
        Public CoperturaDanniAcquaSpeseRicercaRiparazione As New CoperturaSingola(PartitaDanniAcqua, New Garanzia(TipoGaranzia.DanniAcquaSpeseRicercaRiparazione))
        Public CoperturaDanniAcquaPerditeOcculte As New CoperturaSingola(PartitaDanniAcqua, New Garanzia(TipoGaranzia.DanniAcquaPerditeOcculte))
        Public CoperturaDanniAcquaEnergy As New CoperturaSingola(PartitaDanniAcqua, _
                                                               New Garanzia(TipoGaranzia.DanniAcquaEnergy, _
                                                                   New Garanzia(TipoGaranzia.DanniAcquaEnergy1) + _
                                                                   New Garanzia(TipoGaranzia.DanniAcquaEnergy2)))
        Public CoperturaDanniAcqua As New CoperturaComposta(CoperturaDanniAcquaBase + CoperturaDanniAcquaFuoriUscitaOcclusione + CoperturaDanniAcquaPerditeOcculte _
                                                            + CoperturaDanniAcquaSpeseRicercaRiparazione + CoperturaDanniAcquaEnergy)

        'Infortuni
        Public PartitaInfortuni As New Partita(TipoPartita.Infortuni)
        Public CoperturaInfortuniBase As New CoperturaSingola(PartitaInfortuni, _
                                                              New Garanzia(TipoGaranzia.InfortuniBase, _
                                                                  New Garanzia(TipoGaranzia.InfortuniIP) + _
                                                                  New Garanzia(TipoGaranzia.InfortuniRicovero) + _
                                                                  New Garanzia(TipoGaranzia.InfortuniSpeseMediche)))
        Public CoperturaInfortuni As New CoperturaComposta(CoperturaInfortuniBase)

        'Tutela Legale
        Public PartitaTutelaLegale As New Partita(TipoPartita.TutelaLegale)
        Public CoperturaTutelaLegaleBase As New CoperturaSingola(PartitaTutelaLegale, New Garanzia(TipoGaranzia.TutelaLegaleBase))
        Public CoperturaTutelaLegaleDlgs8108 As New CoperturaSingola(PartitaTutelaLegale, New Garanzia(TipoGaranzia.TutelaLegaleDLgs8108))
        Public CoperturaTutelaLegaleDlgs19603 As New CoperturaSingola(PartitaTutelaLegale, New Garanzia(TipoGaranzia.TutelaLegaleDLgs19603))
        Public CoperturaTutelaLegaleDelibereAssemlea As New CoperturaSingola(PartitaTutelaLegale, New Garanzia(TipoGaranzia.TutelaLegaleDelibereAssemlea))
        Public CoperturaTutelaLegale As New CoperturaComposta(CoperturaTutelaLegaleBase + CoperturaTutelaLegaleDlgs8108 _
                                                              + CoperturaTutelaLegaleDlgs19603 + CoperturaTutelaLegaleDelibereAssemlea)


        'Terremoto
        Public CoperturaTerremotoBase As New CoperturaSingola(PartitaIncendio, New Garanzia(TipoGaranzia.TerremotoBase))
        Public DanniAcquaFormaVendita As DanniAcquaFormaVenditaEnum

        ' richiamato anche in apertura di un file
        Public Overrides Sub New2()
            'Caratteristiche
            CodiceRamoPolizza = "48"
            CodiceProdotto = TipoProdotto.YouCondominio
            DescrizioneProdotto = P00000DE.DecodeProdotto(CodiceProdotto)
            Edizione = "201303"
            DataEntrataVigore = "15/03/2013"
            DurataContrattualeMinimaInAnni = 1
            DurataContrattualeMassimaInAnni = 10
            PeriodoMoraInGiorni = 15
            EmissioneAppendici = False
            TacitoRinnovo = True

            AdeguamentoFacoltativo = True
            ContraenzaPersonaGiuridica = True
            ContraenzaPersonaFisica = True
            'È stabilito un premio minimo di € 70,00 comprensivo delle imposte.
            PremioMinimoPrimaRata = 70D

            TipologiaFabbricato = TipologiaFabbricatoEnum.FabbricatoIntero
            BaseTasse = UniQuota.BaseTasse.BaseLorda

            SezioneInfortuni.EscludiFlex = True
            SezioneTerremoto.EscludiFlex = True

            ' gestione nuovi garanzie
            If CoperturaIncendioEstensioneGaranziaBase Is Nothing Then
                CoperturaIncendioEstensioneGaranziaBase = New CoperturaSingola(PartitaIncendio, New Garanzia(TipoGaranzia.IncendioEstensioneGaranziaBase))
                CoperturaDanniAcquaPerditeOcculte = New CoperturaSingola(PartitaIncendio, New Garanzia(TipoGaranzia.DanniAcquaPerditeOcculte))

                CoperturaIncendio.AddCopertura(CoperturaIncendioEstensioneGaranziaBase)
                CoperturaDanniAcqua.AddCopertura(CoperturaDanniAcquaPerditeOcculte)
            End If
        End Sub

        Public Sub New()
            New2()
            'sezioni
            Sezioni.Add(SezioneIncendio)
            Sezioni.Add(SezioneResponsabilitaCivile)
            Sezioni.Add(SezioneDanniAcqua)
            Sezioni.Add(SezioneInfortuni)
            Sezioni.Add(SezioneTutelaLegale)
            Sezioni.Add(SezioneTerremoto)

            'I tassi e i premi della presente tariffa sono comprensivi di imposte e oneri parafiscali.
            'aliquote
            SezioneIncendio.AliquotaImposta = AliquotaImpostaIncendio
            SezioneResponsabilitaCivile.AliquotaImposta = AliquotaImpostaResponsabilitaCivile
            SezioneDanniAcqua.AliquotaImposta = AliquotaImpostaDanniAcqua
            SezioneTutelaLegale.AliquotaImposta = AliquotaImpostaTutelaLegale
            SezioneInfortuni.AliquotaImposta = AliquotaImpostaInfortuni
            SezioneTerremoto.AliquotaImposta = AliquotaImpostaIncendio

            SezioneIncendio.AddCopertura(CoperturaIncendio)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaResponsabilitaCivile)
            SezioneDanniAcqua.AddCopertura(CoperturaDanniAcqua)
            SezioneTutelaLegale.AddCopertura(CoperturaTutelaLegale)
            SezioneInfortuni.AddCopertura(CoperturaInfortuni)
            SezioneTerremoto.AddCopertura(CoperturaTerremotoBase)
        End Sub

        Public Overrides Sub Inizializza()
            MyBase.Inizializza()
            Tabelle = New P07260TR()
        End Sub

        Public Overrides Sub Valida()
            ValidaCondizioniGenerali()
            ValidaSezioneIncendio()
            ValidaSezioneTerremoto()
            ValidaSezioneResponsabilitaCivile()
            ValidaSezioneDanniAcqua()
            ValidaSezioneTutelaLegale()
            ValidaSezioneInfortuni()
            ValidaSconti()
        End Sub

        ''' <summary>
        ''' Valida le condizioni generali della polizza,
        ''' che interessano le influenze reciproche di
        ''' delle sezioni.
        ''' </summary>
        ''' <remarks>Eventuali oincongruenze sono comunquer risolte</remarks>
        Public Sub ValidaCondizioniGenerali()
            If TipologiaFabbricato = TipologiaFabbricatoEnum.FabbricatoPorzione Then
                NumeroFabbricati = 1
                NumeroUnitaImmobiliari = 1
                NumeroUnitaAbitative = 1
                CiSonoEserciziComerciali = False
            Else
                If NumeroFabbricati < 1 Then NumeroFabbricati = 1
                If NumeroUnitaImmobiliari < NumeroFabbricati Then NumeroUnitaImmobiliari = NumeroFabbricati
                If NumeroUnitaAbitative < 1 Then NumeroUnitaAbitative = 1
                If NumeroUnitaAbitative > NumeroUnitaImmobiliari Then NumeroUnitaAbitative = NumeroUnitaImmobiliari
                If NumeroUnitaAbitative = NumeroUnitaImmobiliari Then CiSonoEserciziComerciali = False
            End If

            If AnnoCostruzione <= 0 Then
                AnnoCostruzione = 1900
            ElseIf AnnoCostruzione > Year(Now) Then
                AnnoCostruzione = Year(Now)
            End If

            EtaFabbricato = Year(Now) - AnnoCostruzione

            If EtaFabbricato <= 20 Then
                CoefficienteDiVetusta = 0.97D
            ElseIf EtaFabbricato <= 60 Then
                CoefficienteDiVetusta = 0.97D
                For i As Integer = 21 To EtaFabbricato
                    CoefficienteDiVetusta = Math.Round(CoefficienteDiVetusta * 1.02D, 6, MidpointRounding.AwayFromZero)
                Next
            Else
                CoefficienteDiVetusta = 2.141799D
            End If

            'Qualora nella scheda di polizza del contratto venga evidenziata nella restante
            'porzione del 35% del fabbricato, l’esistenza di cinematografi, teatri,
            'industrie, grandi empori, supermercati, è tollerata con un adeguamento automatico
            'del premio pari al 25%;
            'Sono in ogni caso escluse discoteche e/o locali notturni;

            If CiSonoEserciziComerciali = True Then
                CoefficienteDiAdeguamento = 1.25D
            Else
                CoefficienteDiAdeguamento = 1D
            End If

            If Frazionamento = FrazionamentiEnum.UnicoAnticipato Then
                AdeguamentoFacoltativo = False
            End If

            If Provincia <= ProvinciaEnum.SiglaXX Then
                Dim siglaProvincia As String = Cliente.Provincia
                If String.IsNullOrEmpty(siglaProvincia) Then
                    siglaProvincia = Agenzia.Provincia
                End If

                Provincia = Luogo.Province(Luogo.GetProvinciaBySigla(siglaProvincia)).IdProvincia

                If Provincia <= ProvinciaEnum.SiglaXX Then
                    Provincia = ProvinciaEnum.SiglaAG
                End If
            End If

            ClasseRegionaleFenomeniAtmosferici = CType(Decode, P07260DE).ConvertRegioneToEventiAtmosferici(Luogo.Province(Provincia).Regione.IdRegione)
        End Sub

        Public Sub ValidaSconti()
            SezioneIncendio.PercentualeScontoTecnico = 0
            SezioneDanniAcqua.PercentualeScontoTecnico = 0
            SezioneResponsabilitaCivile.PercentualeScontoTecnico = 0
            SezioneTutelaLegale.PercentualeScontoTecnico = 0
            SezioneInfortuni.PercentualeScontoTecnico = 0
        End Sub

        Public Sub ValidaSezioneIncendio()

            CoperturaIncendio.DipendeDa(True)
            SezioneIncendio.Stato = CoperturaIncendio.Stato
            CoperturaIncendioBase.DipendeDa(CoperturaIncendio.IsAttivo)
            If CoperturaIncendioBase.IsAttivo Then
                CoperturaIncendioDemolizioneSgombero.Stato = CoperturaIncendioBase.Stato
            Else
                CoperturaIncendioDemolizioneSgombero.Stato = StatoCopertura.Inapplicabile
            End If
            CoperturaIncendioFenomeniAtmosfericiBasic.DipendeDa(CoperturaIncendioBase.IsAttivo)
            CoperturaIncendioFenomeniAtmosfericiMediuum.DipendeDa(CoperturaIncendioFenomeniAtmosfericiBasic.IsAttivo)
            CoperturaIncendioAttiVandaliciDolosi.DipendeDa(CoperturaIncendioBase.IsAttivo)
            CoperturaIncendioAttiTerrorismo.DipendeDa(CoperturaIncendioBase.IsAttivo)
            CoperturaIncendioDanniImpiantiElettrici.DipendeDa(CoperturaIncendioBase.IsAttivo)
            CoperturaIncendioCristalli.DipendeDa(CoperturaIncendioBase.IsAttivo)
            CoperturaIncendioOnorariPeriti.DipendeDa(CoperturaIncendioBase.IsAttivo)
            CoperturaIncendioEnergy.DipendeDa(CoperturaIncendioBase.IsAttivo)
            CoperturaIncendioExtra.DipendeDa(CoperturaIncendioBase.IsAttivo)

            '09/02/2015
            CoperturaIncendioEstensioneGaranziaBase.DipendeDa(CoperturaIncendioBase.IsAttivo)

            If PartitaIncendio.SommaAssicurata < 50000D Then
                PartitaIncendio.SommaAssicurata = 50000D
            End If

            If TipologiaFabbricato = TipologiaFabbricatoEnum.FabbricatoIntero _
            And PartitaIncendio.SommaAssicurata > 12000000 Then
                PartitaIncendio.SommaAssicurata = 12000000
            ElseIf TipologiaFabbricato = TipologiaFabbricatoEnum.FabbricatoPorzione _
            And PartitaIncendio.SommaAssicurata > 2000000 Then
                PartitaIncendio.SommaAssicurata = 2000000
            End If

            CoperturaIncendioBase.Tariffa.Tasso = 0.052D / 1000D
            CoperturaIncendioBase.Tariffa.Tasso *= CoefficienteDiAdeguamento * CoefficienteDiVetusta
            CoperturaIncendioEstensioneGaranziaBase.Tariffa.Tasso = 0.058D * CoefficienteDiAdeguamento * CoefficienteDiVetusta / 100000D

            With CoperturaIncendioDemolizioneSgombero
                If CoperturaIncendioEstensioneGaranziaBase.IsAttivo Then
                    .Garanzia.Massimale = 20
                ElseIf .Garanzia.Massimale = 20 Then
                    .Garanzia.Massimale = 0
                End If
                .Garanzia.Limite = 10
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 30000

                .Tariffa.Base = 0D
                If .Garanzia.Massimale = 30000D Then
                    .Tariffa.Base = 13.8D
                ElseIf .Garanzia.Massimale = 50000D Then
                    .Tariffa.Base = 22D
                ElseIf .Garanzia.Massimale = 80000D Then
                    .Tariffa.Base = 33.6D
                ElseIf .Garanzia.Massimale = 100000D Then
                    .Tariffa.Base = 41D
                ElseIf .Garanzia.Massimale = 130000D Then
                    .Tariffa.Base = 52D
                ElseIf .Garanzia.Massimale = 20D Then
                    .Tariffa.Base = 60D
                End If
            End With

            With CoperturaIncendioFenomeniAtmosfericiBasic
                .Garanzia.Scoperto = 10
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 300
                If .Garanzia.Limite = 0 Then .Garanzia.Limite = 75

                .Tariffa.Tasso = 0
                Select Case ClasseRegionaleFenomeniAtmosferici
                    Case ZonaTerritorialeEventiAtmosfericiEnum.ClasseA
                        If .Garanzia.Limite = 75 Then
                            If .Garanzia.Franchigia = 300 Then
                                .Tariffa.Tasso = 0.133D / 1000
                            ElseIf .Garanzia.Franchigia = 500 Then
                                .Tariffa.Tasso = 0.121D / 1000
                            End If
                        ElseIf .Garanzia.Limite = 50 Then
                            If .Garanzia.Franchigia = 300 Then
                                .Tariffa.Tasso = 0.116D / 1000
                            ElseIf .Garanzia.Franchigia = 500 Then
                                .Tariffa.Tasso = 0.105D / 1000
                            End If
                        End If
                    Case ZonaTerritorialeEventiAtmosfericiEnum.ClasseB
                        If .Garanzia.Limite = 75 Then
                            If .Garanzia.Franchigia = 300 Then
                                .Tariffa.Tasso = 0.111D / 1000
                            ElseIf .Garanzia.Franchigia = 500 Then
                                .Tariffa.Tasso = 0.1D / 1000
                            End If
                        ElseIf .Garanzia.Limite = 50 Then
                            If .Garanzia.Franchigia = 300 Then
                                .Tariffa.Tasso = 0.097D / 1000
                            ElseIf .Garanzia.Franchigia = 500 Then
                                .Tariffa.Tasso = 0.088D / 1000
                            End If
                        End If
                    Case ZonaTerritorialeEventiAtmosfericiEnum.ClasseC
                        If .Garanzia.Limite = 75 Then
                            If .Garanzia.Franchigia = 300 Then
                                .Tariffa.Tasso = 0.104D / 1000
                            ElseIf .Garanzia.Franchigia = 500 Then
                                .Tariffa.Tasso = 0.094D / 1000
                            End If
                        ElseIf .Garanzia.Limite = 50 Then
                            If .Garanzia.Franchigia = 300 Then
                                .Tariffa.Tasso = 0.09D / 1000
                            ElseIf .Garanzia.Franchigia = 500 Then
                                .Tariffa.Tasso = 0.082D / 1000
                            End If
                        End If
                End Select
                .Tariffa.Tasso *= CoefficienteDiAdeguamento * CoefficienteDiVetusta
            End With


            With CoperturaIncendioFenomeniAtmosfericiMediuum
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 20000
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 300
                .Garanzia.Scoperto = 10

                .Tariffa.Base = 0
                Select Case ClasseRegionaleFenomeniAtmosferici
                    Case ZonaTerritorialeEventiAtmosfericiEnum.ClasseA
                        If .Garanzia.Massimale = 20000 Then
                            If .Garanzia.Franchigia = 300 Then
                                .Tariffa.Base = 17.32D
                            ElseIf .Garanzia.Franchigia = 500 Then
                                .Tariffa.Base = 15.74D
                            End If
                        ElseIf .Garanzia.Massimale = 30000 Then
                            If .Garanzia.Franchigia = 300 Then
                                .Tariffa.Base = 25.98D
                            ElseIf .Garanzia.Franchigia = 500 Then
                                .Tariffa.Base = 23.61D
                            End If
                        End If
                    Case ZonaTerritorialeEventiAtmosfericiEnum.ClasseB
                        If .Garanzia.Massimale = 20000 Then
                            If .Garanzia.Franchigia = 300 Then
                                .Tariffa.Base = 14.36D
                            ElseIf .Garanzia.Franchigia = 500 Then
                                .Tariffa.Base = 13.06D
                            End If
                        ElseIf .Garanzia.Massimale = 30000 Then
                            If .Garanzia.Franchigia = 300 Then
                                .Tariffa.Base = 21.54D
                            ElseIf .Garanzia.Franchigia = 500 Then
                                .Tariffa.Base = 19.59D
                            End If
                        End If
                    Case ZonaTerritorialeEventiAtmosfericiEnum.ClasseC
                        If .Garanzia.Massimale = 20000 Then
                            If .Garanzia.Franchigia = 300 Then
                                .Tariffa.Base = 13.38D
                            ElseIf .Garanzia.Franchigia = 500 Then
                                .Tariffa.Base = 12.18D
                            End If
                        ElseIf .Garanzia.Massimale = 30000 Then
                            If .Garanzia.Franchigia = 300 Then
                                .Tariffa.Base = 20.07D
                            ElseIf .Garanzia.Franchigia = 500 Then
                                .Tariffa.Base = 18.27D
                            End If
                        End If
                End Select
                .Tariffa.Base *= CoefficienteDiAdeguamento * CoefficienteDiVetusta
            End With


            With CoperturaIncendioAttiVandaliciDolosi
                If CoperturaIncendioEstensioneGaranziaBase.IsAttivo Then
                    .Garanzia.Franchigia = 0
                Else
                    If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 100
                End If

                .Tariffa.Tasso = 0
                If .Garanzia.Franchigia = 0 Then
                    .Tariffa.Tasso = 0.04D / 1000
                    .Garanzia.Scoperto = 0
                ElseIf .Garanzia.Franchigia = 100 Then
                    .Tariffa.Tasso = 0.023D / 1000
                    .Garanzia.Scoperto = 0
                ElseIf .Garanzia.Franchigia = 200 Then
                    .Tariffa.Tasso = 0.021D / 1000
                    .Garanzia.Scoperto = 10
                End If
                .Tariffa.Tasso *= CoefficienteDiAdeguamento
            End With

            With CoperturaIncendioAttiTerrorismo
                If .Garanzia.Limite = 0 Then .Garanzia.Limite = 25
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 500
                .Garanzia.Scoperto = 10

                .Tariffa.Tasso = 0
                If .Garanzia.Limite = 25 Then
                    If .Garanzia.Franchigia = 500 Then
                        .Tariffa.Tasso = 0.017D / 1000
                    ElseIf .Garanzia.Franchigia = 1000 Then
                        .Tariffa.Tasso = 0.015D / 1000
                    End If
                ElseIf .Garanzia.Limite = 50 Then
                    If .Garanzia.Franchigia = 500 Then
                        .Tariffa.Tasso = 0.021D / 1000
                    ElseIf .Garanzia.Franchigia = 1000 Then
                        .Tariffa.Tasso = 0.017D / 1000
                    End If
                End If
                .Tariffa.Tasso *= CoefficienteDiAdeguamento
            End With

            With CoperturaIncendioDanniImpiantiElettrici
                If CoperturaIncendioEstensioneGaranziaBase.IsNotAttivo And .Garanzia.Massimale = 10 Then
                    .Garanzia.Massimale = 0
                End If
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 2500
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 150

                .Tariffa.Base = 0
                If .Garanzia.Massimale = 2500 Then
                    If .Garanzia.Franchigia = 150 Then
                        .Tariffa.Base = 20.87D
                    ElseIf .Garanzia.Franchigia = 250 Then
                        .Tariffa.Base = 19D
                    End If
                ElseIf .Garanzia.Massimale = 5000 Then
                    If .Garanzia.Franchigia = 150 Then
                        .Tariffa.Base = 40D
                    ElseIf .Garanzia.Franchigia = 250 Then
                        .Tariffa.Base = 36.25D
                    End If
                ElseIf .Garanzia.Massimale = 7500 Then
                    If .Garanzia.Franchigia = 150 Then
                        .Tariffa.Base = 57D
                    ElseIf .Garanzia.Franchigia = 250 Then
                        .Tariffa.Base = 51.75D
                    End If
                ElseIf .Garanzia.Massimale = 10 Then
                    If .Garanzia.Franchigia = 150 Then
                        .Tariffa.Base = 61.5D
                    ElseIf .Garanzia.Franchigia = 250 Then
                        .Tariffa.Base = 56D
                    End If
                End If
                .Tariffa.Base *= CoefficienteDiAdeguamento * CoefficienteDiVetusta
            End With


            With CoperturaIncendioCristalli
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 1500

                .Tariffa.Base = 0
                If .Garanzia.Massimale = 1500 Then
                    .Tariffa.Base = 41.25D
                ElseIf .Garanzia.Massimale = 2500 Then
                    .Tariffa.Base = 66.25D
                ElseIf .Garanzia.Massimale = 5000 Then
                    .Tariffa.Base = 125D
                ElseIf .Garanzia.Massimale = 10000 Then
                    .Tariffa.Base = 240D
                End If
                .Tariffa.Base *= CoefficienteDiAdeguamento
            End With

            With CoperturaIncendioOnorariPeriti
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 2000

                .Tariffa.Base = 0
                If .Garanzia.Massimale = 2000 Then
                    .Tariffa.Base = 3D
                    .Garanzia.Limite = 5
                ElseIf .Garanzia.Massimale = 3000 Then
                    .Tariffa.Base = 8D
                    .Garanzia.Limite = 10
                ElseIf .Garanzia.Massimale = 5000 Then
                    .Tariffa.Base = 11D
                    .Garanzia.Limite = 10
                End If
                .Tariffa.Base *= CoefficienteDiAdeguamento
            End With

            With CoperturaIncendioEnergy
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 5000
                .Garanzia.Limite = 5

                .Tariffa.Base = 0D
                If .Garanzia.Massimale = 5000 Then
                    .Tariffa.Base = 5D
                ElseIf .Garanzia.Massimale = 10000 Then
                    .Tariffa.Base = 8D
                End If
            End With

            With CoperturaIncendioExtra.Garanzia
                If .Garanzie(0).Massimale = 0 Then .Garanzie(0).Massimale = 500
                If .Garanzie(1).Massimale = 0 Then .Garanzie(1).Massimale = 1500

                CoperturaIncendioExtra.Tariffa.Base = 0D
                If .Garanzie(0).Massimale = 500 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 1500 And .Garanzie(1).Franchigia = 0 Then
                    CoperturaIncendioExtra.Tariffa.Base = 31D
                ElseIf .Garanzie(0).Massimale = 500 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 1500 And .Garanzie(1).Franchigia = 150 Then
                    CoperturaIncendioExtra.Tariffa.Base = 28D
                ElseIf .Garanzie(0).Massimale = 500 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 1500 And .Garanzie(1).Franchigia = 250 Then
                    CoperturaIncendioExtra.Tariffa.Base = 25D

                ElseIf .Garanzie(0).Massimale = 500 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 3000 And .Garanzie(1).Franchigia = 0 Then
                    CoperturaIncendioExtra.Tariffa.Base = 39D
                ElseIf .Garanzie(0).Massimale = 500 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 3000 And .Garanzie(1).Franchigia = 150 Then
                    CoperturaIncendioExtra.Tariffa.Base = 35D
                ElseIf .Garanzie(0).Massimale = 500 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 3000 And .Garanzie(1).Franchigia = 250 Then
                    CoperturaIncendioExtra.Tariffa.Base = 32D

                ElseIf .Garanzie(0).Massimale = 500 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 4500 And .Garanzie(1).Franchigia = 0 Then
                    CoperturaIncendioExtra.Tariffa.Base = 43D
                ElseIf .Garanzie(0).Massimale = 500 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 4500 And .Garanzie(1).Franchigia = 150 Then
                    CoperturaIncendioExtra.Tariffa.Base = 39D
                ElseIf .Garanzie(0).Massimale = 500 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 4500 And .Garanzie(1).Franchigia = 250 Then
                    CoperturaIncendioExtra.Tariffa.Base = 35D

                ElseIf .Garanzie(0).Massimale = 1000 And .Garanzie(0).Franchigia = 0 _
                    And .Garanzie(1).Massimale = 1500 And .Garanzie(1).Franchigia = 0 Then
                    CoperturaIncendioExtra.Tariffa.Base = 37D
                ElseIf .Garanzie(0).Massimale = 1000 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 1500 And .Garanzie(1).Franchigia = 150 Then
                    CoperturaIncendioExtra.Tariffa.Base = 34D
                ElseIf .Garanzie(0).Massimale = 1000 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 1500 And .Garanzie(1).Franchigia = 250 Then
                    CoperturaIncendioExtra.Tariffa.Base = 30D

                ElseIf .Garanzie(0).Massimale = 1000 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 3000 And .Garanzie(1).Franchigia = 0 Then
                    CoperturaIncendioExtra.Tariffa.Base = 46D
                ElseIf .Garanzie(0).Massimale = 1000 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 3000 And .Garanzie(1).Franchigia = 150 Then
                    CoperturaIncendioExtra.Tariffa.Base = 42D
                ElseIf .Garanzie(0).Massimale = 1000 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 3000 And .Garanzie(1).Franchigia = 250 Then
                    CoperturaIncendioExtra.Tariffa.Base = 39D

                ElseIf .Garanzie(0).Massimale = 1000 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 4500 And .Garanzie(1).Franchigia = 0 Then
                    CoperturaIncendioExtra.Tariffa.Base = 51D
                ElseIf .Garanzie(0).Massimale = 1000 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 4500 And .Garanzie(1).Franchigia = 150 Then
                    CoperturaIncendioExtra.Tariffa.Base = 47D
                ElseIf .Garanzie(0).Massimale = 1000 And .Garanzie(0).Franchigia = 0 _
                And .Garanzie(1).Massimale = 4500 And .Garanzie(1).Franchigia = 250 Then
                    CoperturaIncendioExtra.Tariffa.Base = 43D
                End If
            End With

        End Sub

        Public Sub ValidaSezioneResponsabilitaCivile()
            PartitaResponsabilitaCivile.SommaAssicurata = PartitaIncendio.SommaAssicurata

            CoperturaResponsabilitaCivile.DipendeDa(True)
            SezioneResponsabilitaCivile.Stato = CoperturaResponsabilitaCivile.Stato
            CoperturaResponsabilitaCivileBase.DipendeDa(CoperturaResponsabilitaCivile.IsAttivo)

            CoperturaResponsabilitaPrestatoriLavoro.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo)
            CoperturaResponsabilitaCommittenzaLavori.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo)
            CoperturaResponsabilitaConduzioneUnitaImmobiliari.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo)
            CoperturaResponsabilitaAmministratore.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo)
            CoperturaResponsabilitaEnergy.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo)

            'Tariffa
            'Tassi o premi annui lordi comprensivi di imposte e riferiti a fabbricati con vetustà
            'pari a 0 (zero) anni da applicare al valore del fabbricato.
            'Responsabilità


            '1. Il massimale si deve intendere unico, pertanto rappresenta la massima esposizione
            'della Società in caso di sinistro, che riguardi le garanzie assicurate.
            'Il massimale delle Garanzie Aggiuntive (Responsabilità civile verso prestatori
            'di lavoro R.C.O. e Responsabilità derivante dalla conduzione delle unità immobiliari)
            'deve essere uguale od inferiore al massimale della Garanzia Base.

            If CoperturaResponsabilitaPrestatoriLavoro.Garanzia.Massimale _
             > CoperturaResponsabilitaCivileBase.Garanzia.Massimale Then
                CoperturaResponsabilitaPrestatoriLavoro.Garanzia.Massimale _
                = CoperturaResponsabilitaCivileBase.Garanzia.Massimale
            End If

            If CoperturaResponsabilitaConduzioneUnitaImmobiliari.Garanzia.Massimale _
             > CoperturaResponsabilitaCivileBase.Garanzia.Massimale Then
                CoperturaResponsabilitaConduzioneUnitaImmobiliari.Garanzia.Massimale _
                = CoperturaResponsabilitaCivileBase.Garanzia.Massimale
            End If

            With CoperturaResponsabilitaCivileBase
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 500000

                .Tariffa.Tasso = 0
                If .Garanzia.Massimale = 500000 Then
                    .Tariffa.Tasso = 0.071D / 1000
                ElseIf .Garanzia.Massimale = 1000000 Then
                    .Tariffa.Tasso = 0.082D / 1000
                ElseIf .Garanzia.Massimale = 1500000 Then
                    .Tariffa.Tasso = 0.093D / 1000
                ElseIf .Garanzia.Massimale = 2000000 Then
                    .Tariffa.Tasso = 0.106D / 1000
                ElseIf .Garanzia.Massimale = 2500000 Then
                    .Tariffa.Tasso = 0.117D / 1000
                ElseIf .Garanzia.Massimale = 3000000 Then
                    .Tariffa.Tasso = 0.123D / 1000
                ElseIf .Garanzia.Massimale = 5000000 Then
                    .Tariffa.Tasso = 0.131D / 1000
                End If
                .Tariffa.Tasso *= CoefficienteDiAdeguamento * CoefficienteDiVetusta
            End With

            With CoperturaResponsabilitaPrestatoriLavoro
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 500000

                .Tariffa.Tasso = 0
                If .Garanzia.Massimale = 500000 Then
                    .Tariffa.Tasso = 0.017D / 1000
                ElseIf .Garanzia.Massimale = 1000000 Then
                    .Tariffa.Tasso = 0.026D / 1000
                ElseIf .Garanzia.Massimale = 1500000 Then
                    .Tariffa.Tasso = 0.039D / 1000
                ElseIf .Garanzia.Massimale = 2000000 Then
                    .Tariffa.Tasso = 0.048D / 1000
                ElseIf .Garanzia.Massimale = 2500000 Then
                    .Tariffa.Tasso = 0.057D / 1000
                ElseIf .Garanzia.Massimale = 3000000 Then
                    .Tariffa.Tasso = 0.065D / 1000
                ElseIf .Garanzia.Massimale = 5000000 Then
                    .Tariffa.Tasso = 0.07D / 1000
                End If
                .Tariffa.Tasso *= CoefficienteDiAdeguamento
            End With

            With CoperturaResponsabilitaCommittenzaLavori
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 500000

                .Tariffa.Tasso = 0
                If .Garanzia.Massimale = 500000 Then
                    .Tariffa.Tasso = 0.015D / 1000
                ElseIf .Garanzia.Massimale = 1000000 Then
                    .Tariffa.Tasso = 0.016D / 1000
                ElseIf .Garanzia.Massimale = 1500000 Then
                    .Tariffa.Tasso = 0.018D / 1000
                End If
                .Tariffa.Tasso *= CoefficienteDiAdeguamento * CoefficienteDiVetusta
            End With

            With CoperturaResponsabilitaConduzioneUnitaImmobiliari
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 500000

                .Tariffa.Base = 0

                'Dim NumeroUnitaImmobiliariOltre6 As Integer = NumeroUnitaImmobiliari - 6
                Dim NumeroUnitaImmobiliariOltre6 As Integer = NumeroUnitaAbitative - 6
                If NumeroUnitaImmobiliariOltre6 < 0 Then NumeroUnitaImmobiliariOltre6 = 0

                If .Garanzia.Massimale = 500000 Then
                    .Tariffa.Base = 40.65D + NumeroUnitaImmobiliariOltre6 * 5.25D
                ElseIf .Garanzia.Massimale = 1000000 Then
                    .Tariffa.Base = 46.75D + NumeroUnitaImmobiliariOltre6 * 6
                ElseIf .Garanzia.Massimale = 1500000 Then
                    .Tariffa.Base = 52.85D + NumeroUnitaImmobiliariOltre6 * 6.8D
                ElseIf .Garanzia.Massimale = 2000000 Then
                    .Tariffa.Base = 61D + NumeroUnitaImmobiliariOltre6 * 7.85D
                ElseIf .Garanzia.Massimale = 2500000 Then
                    .Tariffa.Base = 67.05D + NumeroUnitaImmobiliariOltre6 * 8.6D
                ElseIf .Garanzia.Massimale = 3000000 Then
                    .Tariffa.Base = 71.15D + NumeroUnitaImmobiliariOltre6 * 9.15D
                ElseIf .Garanzia.Massimale = 5000000 Then
                    .Tariffa.Base = 75.2D + NumeroUnitaImmobiliariOltre6 * 9.65D
                End If
                .Tariffa.Base *= CoefficienteDiAdeguamento
            End With

            With CoperturaResponsabilitaAmministratore
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 25000

                .Tariffa.Base = 0
                If .Garanzia.Massimale = 25000 Then
                    .Tariffa.Base = 29D
                ElseIf .Garanzia.Massimale = 50000 Then
                    .Tariffa.Base = 52.5D
                ElseIf .Garanzia.Massimale = 500000D Then
                    .Tariffa.Base = 70D
                End If
                .Tariffa.Base *= CoefficienteDiAdeguamento
            End With

            With CoperturaResponsabilitaEnergy
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 50000

                .Tariffa.Base = 0
                If .Garanzia.Massimale = 50000 Then
                    .Tariffa.Base = 15D
                ElseIf .Garanzia.Massimale = 100000 Then
                    .Tariffa.Base = 28D
                ElseIf .Garanzia.Massimale = 150000 Then
                    .Tariffa.Base = 39D
                End If
                .Tariffa.Base *= CoefficienteDiAdeguamento
            End With


        End Sub


        Public Sub ValidaSezioneDanniAcqua()
            PartitaDanniAcqua.SommaAssicurata = PartitaIncendio.SommaAssicurata
            CoperturaDanniAcquaBase.Garanzia.Massimale = CoperturaResponsabilitaCivileBase.Garanzia.Massimale
            CoperturaDanniAcquaEnergy.Garanzia.Massimale = CoperturaResponsabilitaCivileBase.Garanzia.Massimale
            'Avvertenze
            '1) La Garanzia aggiuntiva “Spese di ricerca e riparazione”, è prestata solo in
            'presenza della “Garanzia Base”;
            '2) La Garanzia aggiuntiva “Fuoriuscita di liquidi, Acqua piovana, Occlusione
            'condutture”. è prestata solo in presenza della “Garanzia Base”;
            '3) Le Garanzie aggiuntive Multiple “A-Scelta Energy”, sono prestate solo in presenza
            'della “Garanzia Base”;

            'La sezione danni acqua è facoltativa e sempre in abbinamento ad altre sezioni
            CoperturaDanniAcquaBase.DipendeDa(SezioneIncendio.IsAttivo Or SezioneResponsabilitaCivile.IsAttivo)
            CoperturaDanniAcqua.Stato = CoperturaDanniAcquaBase.Stato
            SezioneDanniAcqua.Stato = CoperturaDanniAcqua.Stato

            CoperturaDanniAcquaFuoriUscitaOcclusione.DipendeDa(CoperturaDanniAcquaBase.IsAttivo)
            CoperturaDanniAcquaSpeseRicercaRiparazione.DipendeDa(CoperturaDanniAcquaBase.IsAttivo)
            CoperturaDanniAcquaEnergy.DipendeDa(CoperturaDanniAcquaBase.IsAttivo)
            CoperturaDanniAcquaPerditeOcculte.DipendeDa(CoperturaDanniAcquaBase.IsAttivo)

            Dim CoefficienteDiVetusta As Decimal = Me.CoefficienteDiVetusta

            If EtaFabbricato > 60 Then
                CoefficienteDiVetusta = 1D
            End If

            'Tariffa
            'Tassi o premi annui lordi comprensivi di imposte e riferiti a fabbricati con vetustà
            'pari a 0 (zero) anni da applicare al valore del fabbricato.

            'Garanzia(BASE)
            'MASSIMALI IN EURO X 1000
            'Franch.  500    1000   1500   2000   2500   3000   5000
            '€ 0.00   0.202‰ 0.242‰ 0.271‰ 0.302‰ 0.312‰ 0.322‰ 0.333‰
            '€ 150.00 0.192‰ 0.230‰ 0.259‰ 0.287‰ 0.297‰ 0.307‰ 0.317‰
            '€ 250.00 0.182‰ 0.219‰ 0.247‰ 0.274‰ 0.282‰ 0.292‰ 0.301‰
            '€ 500.00 0.175‰ 0.209‰ 0.235‰ 0.262‰ 0.270‰ 0.279‰ 0.287‰
            '€ 750.00 0.166‰ 0.200‰ 0.225‰ 0.249‰ 0.258‰ 0.267‰ 0.275‰
            '€ 1000   0.160‰ 0.192‰ 0.215‰ 0.240‰ 0.248‰ 0.256‰ 0.264‰

            With CoperturaDanniAcquaBase
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 500000
                If .Garanzia.Franchigia = 0 Then
                    If EtaFabbricato > 5 Or TipologiaFabbricato = TipologiaFabbricatoEnum.FabbricatoIntero Then
                        .Garanzia.Franchigia = 150
                    End If
                End If

                .Tariffa.Tasso = 0
                If .Garanzia.Franchigia = 0 Then
                    If .Garanzia.Massimale = 500000 Then
                        .Tariffa.Tasso = 0.202D / 1000
                    ElseIf .Garanzia.Massimale = 1000000 Then
                        .Tariffa.Tasso = 0.242D / 1000
                    ElseIf .Garanzia.Massimale = 1500000 Then
                        .Tariffa.Tasso = 0.271D / 1000
                    ElseIf .Garanzia.Massimale = 2000000 Then
                        .Tariffa.Tasso = 0.302D / 1000
                    ElseIf .Garanzia.Massimale = 2500000 Then
                        .Tariffa.Tasso = 0.312D / 1000
                    ElseIf .Garanzia.Massimale = 3000000 Then
                        .Tariffa.Tasso = 0.322D / 1000
                    ElseIf .Garanzia.Massimale = 5000000 Then
                        .Tariffa.Tasso = 0.333D / 1000
                    End If
                ElseIf .Garanzia.Franchigia = 150 Then
                    If .Garanzia.Massimale = 500000 Then
                        .Tariffa.Tasso = 0.192D / 1000
                    ElseIf .Garanzia.Massimale = 1000000 Then
                        .Tariffa.Tasso = 0.23D / 1000
                    ElseIf .Garanzia.Massimale = 1500000 Then
                        .Tariffa.Tasso = 0.259D / 1000
                    ElseIf .Garanzia.Massimale = 2000000 Then
                        .Tariffa.Tasso = 0.287D / 1000
                    ElseIf .Garanzia.Massimale = 2500000 Then
                        .Tariffa.Tasso = 0.297D / 1000
                    ElseIf .Garanzia.Massimale = 3000000 Then
                        .Tariffa.Tasso = 0.307D / 1000
                    ElseIf .Garanzia.Massimale = 5000000 Then
                        .Tariffa.Tasso = 0.317D / 1000
                    End If
                ElseIf .Garanzia.Franchigia = 250 Then
                    If .Garanzia.Massimale = 500000 Then
                        .Tariffa.Tasso = 0.182D / 1000
                    ElseIf .Garanzia.Massimale = 1000000 Then
                        .Tariffa.Tasso = 0.219D / 1000
                    ElseIf .Garanzia.Massimale = 1500000 Then
                        .Tariffa.Tasso = 0.247D / 1000
                    ElseIf .Garanzia.Massimale = 2000000 Then
                        .Tariffa.Tasso = 0.274D / 1000
                    ElseIf .Garanzia.Massimale = 2500000 Then
                        .Tariffa.Tasso = 0.282D / 1000
                    ElseIf .Garanzia.Massimale = 3000000 Then
                        .Tariffa.Tasso = 0.292D / 1000
                    ElseIf .Garanzia.Massimale = 5000000 Then
                        .Tariffa.Tasso = 0.301D / 1000
                    End If
                ElseIf .Garanzia.Franchigia = 500 Then
                    If .Garanzia.Massimale = 500000 Then
                        .Tariffa.Tasso = 0.175D / 1000
                    ElseIf .Garanzia.Massimale = 1000000 Then
                        .Tariffa.Tasso = 0.209D / 1000
                    ElseIf .Garanzia.Massimale = 1500000 Then
                        .Tariffa.Tasso = 0.235D / 1000
                    ElseIf .Garanzia.Massimale = 2000000 Then
                        .Tariffa.Tasso = 0.262D / 1000
                    ElseIf .Garanzia.Massimale = 2500000 Then
                        .Tariffa.Tasso = 0.27D / 1000
                    ElseIf .Garanzia.Massimale = 3000000 Then
                        .Tariffa.Tasso = 0.279D / 1000
                    ElseIf .Garanzia.Massimale = 5000000 Then
                        .Tariffa.Tasso = 0.287D / 1000
                    End If
                ElseIf .Garanzia.Franchigia = 750 Then
                    If .Garanzia.Massimale = 500000 Then
                        .Tariffa.Tasso = 0.166D / 1000
                    ElseIf .Garanzia.Massimale = 1000000 Then
                        .Tariffa.Tasso = 0.2D / 1000
                    ElseIf .Garanzia.Massimale = 1500000 Then
                        .Tariffa.Tasso = 0.225D / 1000
                    ElseIf .Garanzia.Massimale = 2000000 Then
                        .Tariffa.Tasso = 0.249D / 1000
                    ElseIf .Garanzia.Massimale = 2500000 Then
                        .Tariffa.Tasso = 0.258D / 1000
                    ElseIf .Garanzia.Massimale = 3000000 Then
                        .Tariffa.Tasso = 0.267D / 1000
                    ElseIf .Garanzia.Massimale = 5000000 Then
                        .Tariffa.Tasso = 0.275D / 1000
                    End If
                ElseIf .Garanzia.Franchigia = 1000 Then
                    If .Garanzia.Massimale = 500000 Then
                        .Tariffa.Tasso = 0.16D / 1000
                    ElseIf .Garanzia.Massimale = 1000000 Then
                        .Tariffa.Tasso = 0.192D / 1000
                    ElseIf .Garanzia.Massimale = 1500000 Then
                        .Tariffa.Tasso = 0.215D / 1000
                    ElseIf .Garanzia.Massimale = 2000000 Then
                        .Tariffa.Tasso = 0.24D / 1000
                    ElseIf .Garanzia.Massimale = 2500000 Then
                        .Tariffa.Tasso = 0.248D / 1000
                    ElseIf .Garanzia.Massimale = 3000000 Then
                        .Tariffa.Tasso = 0.256D / 1000
                    ElseIf .Garanzia.Massimale = 5000000 Then
                        .Tariffa.Tasso = 0.264D / 1000
                    End If

                End If

                .Tariffa.Tasso *= CoefficienteDiVetusta
            End With

            With CoperturaDanniAcquaFuoriUscitaOcclusione
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 10000
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 150

                .Tariffa.Tasso = 0
                If .Garanzia.Massimale = 10000 Then
                    If .Garanzia.Franchigia = 150 Then
                        .Tariffa.Tasso = 0.134D / 1000
                    ElseIf .Garanzia.Franchigia = 250 Then
                        .Tariffa.Tasso = 0.128D / 1000
                    ElseIf .Garanzia.Franchigia = 500 Then
                        .Tariffa.Tasso = 0.122D / 1000
                    End If
                End If
                .Tariffa.Tasso *= CoefficienteDiVetusta
            End With

            With CoperturaDanniAcquaSpeseRicercaRiparazione
                If .Garanzia.MassimalePerAnno = 0 Then .Garanzia.MassimalePerAnno = 7500
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 150

                .Tariffa.Tasso = 0
                If .Garanzia.MassimalePerAnno = 7500 Then
                    If .Garanzia.Franchigia = 150 Then
                        .Tariffa.Tasso = 0.171D / 1000
                    ElseIf .Garanzia.Franchigia = 250 Then
                        .Tariffa.Tasso = 0.163D / 1000
                    ElseIf .Garanzia.Franchigia = 500 Then
                        .Tariffa.Tasso = 0.155D / 1000
                    End If
                ElseIf .Garanzia.MassimalePerAnno = 10000 Then
                    If .Garanzia.Franchigia = 150 Then
                        .Tariffa.Tasso = 0.196D / 1000
                    ElseIf .Garanzia.Franchigia = 250 Then
                        .Tariffa.Tasso = 0.187D / 1000
                    ElseIf .Garanzia.Franchigia = 500 Then
                        .Tariffa.Tasso = 0.178D / 1000
                    End If
                ElseIf .Garanzia.MassimalePerAnno = 50000D Then
                    If .Garanzia.Franchigia = 150 Then
                        .Tariffa.Tasso = 0.205D / 1000
                    ElseIf .Garanzia.Franchigia = 250 Then
                        .Tariffa.Tasso = 0.195D / 1000
                    ElseIf .Garanzia.Franchigia = 500 Then
                        .Tariffa.Tasso = 0.185D / 1000
                    End If
                End If
                .Tariffa.Tasso *= CoefficienteDiVetusta
            End With

            'Franch                 500  1000  1500  2000  2500  3000  5000
            '€   0.00 fino 6 app  33.00 38.00 43.50 49.50 54.50 57.70 61.00
            '€ 150.00 fino 6 app  26.00 30.00 34.30 39.00 42.90 45.50 48.10
            '€ 250.00 fino 6 app  22.00 25.30 29.00 33.00 36.30 38.50 40.70
            '€ 500.00 fino 6 app  16.00 18.40 21.10 24.00 26.40 28.00 29.60
            '€   0.00 oltre 6      4.70  5.40  6.20  7.00  7.75  8.25  8.70
            '€ 150.00 oltre 6      4.00  4.60  5.30  6.00  6.60  7.00  7.40
            '€ 250.00 oltre 6      3.40  3.90  4.50  5.10  5.60  5.95  6.30
            '€ 500.00 oltre 6      2.50  2.90  3.30  3.75  4.15  4.40  4.65
            With CoperturaDanniAcquaEnergy
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 500000

                .Tariffa.Base = 0

                Dim NumeroUnitaImmobiliariOltre6 As Integer = NumeroUnitaImmobiliari - 6
                If NumeroUnitaImmobiliariOltre6 < 0 Then NumeroUnitaImmobiliariOltre6 = 0

                If .Garanzia.Franchigia = 0 Then
                    If .Garanzia.Massimale = 500000 Then
                        .Tariffa.Base = 33D + NumeroUnitaImmobiliariOltre6 * 4.7D
                    ElseIf .Garanzia.Massimale = 1000000 Then
                        .Tariffa.Base = 38D + NumeroUnitaImmobiliariOltre6 * 5.4D
                    ElseIf .Garanzia.Massimale = 1500000 Then
                        .Tariffa.Base = 43.5D + NumeroUnitaImmobiliariOltre6 * 6.2D
                    ElseIf .Garanzia.Massimale = 2000000 Then
                        .Tariffa.Base = 49.5D + NumeroUnitaImmobiliariOltre6 * 7D
                    ElseIf .Garanzia.Massimale = 2500000 Then
                        .Tariffa.Base = 54.5D + NumeroUnitaImmobiliariOltre6 * 7.75D
                    ElseIf .Garanzia.Massimale = 3000000 Then
                        .Tariffa.Base = 57.7D + NumeroUnitaImmobiliariOltre6 * 8.25D
                    ElseIf .Garanzia.Massimale = 5000000 Then
                        .Tariffa.Base = 61D + NumeroUnitaImmobiliariOltre6 * 8.7D
                    End If
                ElseIf .Garanzia.Franchigia = 150.0 Then
                    If .Garanzia.Massimale = 500000 Then
                        .Tariffa.Base = 26D + NumeroUnitaImmobiliariOltre6 * 4D
                    ElseIf .Garanzia.Massimale = 1000000 Then
                        .Tariffa.Base = 30D + NumeroUnitaImmobiliariOltre6 * 4.6D
                    ElseIf .Garanzia.Massimale = 1500000 Then
                        .Tariffa.Base = 34.3D + NumeroUnitaImmobiliariOltre6 * 5.3D
                    ElseIf .Garanzia.Massimale = 2000000 Then
                        .Tariffa.Base = 39D + NumeroUnitaImmobiliariOltre6 * 6D
                    ElseIf .Garanzia.Massimale = 2500000 Then
                        .Tariffa.Base = 42.9D + NumeroUnitaImmobiliariOltre6 * 6.6D
                    ElseIf .Garanzia.Massimale = 3000000 Then
                        .Tariffa.Base = 45.5D + NumeroUnitaImmobiliariOltre6 * 7D
                    ElseIf .Garanzia.Massimale = 5000000 Then
                        .Tariffa.Base = 48.1D + NumeroUnitaImmobiliariOltre6 * 7.4D
                    End If
                ElseIf .Garanzia.Franchigia = 250.0 Then
                    If .Garanzia.Massimale = 500000 Then
                        .Tariffa.Base = 22D + NumeroUnitaImmobiliariOltre6 * 3.4D
                    ElseIf .Garanzia.Massimale = 1000000 Then
                        .Tariffa.Base = 25.3D + NumeroUnitaImmobiliariOltre6 * 3.9D
                    ElseIf .Garanzia.Massimale = 1500000 Then
                        .Tariffa.Base = 29D + NumeroUnitaImmobiliariOltre6 * 4.5D
                    ElseIf .Garanzia.Massimale = 2000000 Then
                        .Tariffa.Base = 33D + NumeroUnitaImmobiliariOltre6 * 5.1D
                    ElseIf .Garanzia.Massimale = 2500000 Then
                        .Tariffa.Base = 36.3D + NumeroUnitaImmobiliariOltre6 * 5.6D
                    ElseIf .Garanzia.Massimale = 3000000 Then
                        .Tariffa.Base = 38.5D + NumeroUnitaImmobiliariOltre6 * 5.95D
                    ElseIf .Garanzia.Massimale = 5000000 Then
                        .Tariffa.Base = 40.7D + NumeroUnitaImmobiliariOltre6 * 6.3D
                    End If
                ElseIf .Garanzia.Franchigia = 500.0 Then
                    If .Garanzia.Massimale = 500000 Then
                        .Tariffa.Base = 16D + NumeroUnitaImmobiliariOltre6 * 2.5D
                    ElseIf .Garanzia.Massimale = 1000000 Then
                        .Tariffa.Base = 18.4D + NumeroUnitaImmobiliariOltre6 * 2.9D
                    ElseIf .Garanzia.Massimale = 1500000 Then
                        .Tariffa.Base = 21.1D + NumeroUnitaImmobiliariOltre6 * 3.3D
                    ElseIf .Garanzia.Massimale = 2000000 Then
                        .Tariffa.Base = 24D + NumeroUnitaImmobiliariOltre6 * 3.75D
                    ElseIf .Garanzia.Massimale = 2500000 Then
                        .Tariffa.Base = 26.4D + NumeroUnitaImmobiliariOltre6 * 4.15D
                    ElseIf .Garanzia.Massimale = 3000000 Then
                        .Tariffa.Base = 28D + NumeroUnitaImmobiliariOltre6 * 4.4D
                    ElseIf .Garanzia.Massimale = 5000000 Then
                        .Tariffa.Base = 29.6D + NumeroUnitaImmobiliariOltre6 * 4.65D
                    End If
                End If
                .Tariffa.Base *= CoefficienteDiVetusta
            End With

            With CoperturaDanniAcquaPerditeOcculte
                If DanniAcquaFormaVendita = 0 Then DanniAcquaFormaVendita = DanniAcquaFormaVenditaEnum.EccedenzeConsumo
                .Tariffa.Tasso = 0D
                .Tariffa.Base = 0D
                If DanniAcquaFormaVendita = DanniAcquaFormaVenditaEnum.EccedenzeConsumo Then
                    .Tariffa.Tasso = 1.2225D * 0.007D / 1000D
                ElseIf DanniAcquaFormaVendita = DanniAcquaFormaVenditaEnum.PerditeOcculte Then
                    .Tariffa.Base = 95D
                End If
            End With

        End Sub

        Public Sub ValidaSezioneInfortuni()
            'La sezione Tutela Legale è facoltativa e sempre in abbinamento ad altre sezioni
            CoperturaInfortuniBase.DipendeDa((TipologiaFabbricato = TipologiaFabbricatoEnum.FabbricatoIntero) _
                                         And (NumeroUnitaAbitative > 0) _
                                         And (SezioneIncendio.IsAttivo Or SezioneResponsabilitaCivile.IsAttivo))
            CoperturaInfortuni.Stato = CoperturaInfortuniBase.Stato
            SezioneInfortuni.Stato = CoperturaInfortuni.Stato

            'Tariffa
            'I premi indicati sono annui comprensivi d’imposte da applicare per singola unità
            'abitativa adibita a civile abitazione.

            With CoperturaInfortuniBase
                If .Garanzia.Garanzie(0).Massimale = 0 Then .Garanzia.Garanzie(0).Massimale = 60000

                .Tariffa.Base = 0
                If .Garanzia.Garanzie(0).Massimale = 60000 Then
                    .Tariffa.Base = 11D * NumeroUnitaAbitative
                    .Garanzia.Garanzie(1).Massimale = 30
                    .Garanzia.Garanzie(2).Massimale = 3000
                ElseIf .Garanzia.Garanzie(0).Massimale = 120000 Then
                    .Tariffa.Base = 21D * NumeroUnitaAbitative
                    .Garanzia.Garanzie(1).Massimale = 60
                    .Garanzia.Garanzie(2).Massimale = 5100
                ElseIf .Garanzia.Garanzie(0).Massimale = 180000 Then
                    .Tariffa.Base = 31D * NumeroUnitaAbitative
                    .Garanzia.Garanzie(1).Massimale = 90
                    .Garanzia.Garanzie(2).Massimale = 7800
                ElseIf .Garanzia.Garanzie(0).Massimale = 240000 Then
                    .Tariffa.Base = 41D * NumeroUnitaAbitative
                    .Garanzia.Garanzie(1).Massimale = 120
                    .Garanzia.Garanzie(2).Massimale = 10000
                End If
            End With
        End Sub



        Public Sub ValidaSezioneTutelaLegale()
            'La sezione Tutela Legale può essere venduta solo per i condomini; non può essere
            'venduta per porzioni di condomini o villette.

            CoperturaTutelaLegaleBase.DipendeDa((TipologiaFabbricato = TipologiaFabbricatoEnum.FabbricatoIntero) _
                                            And (SezioneIncendio.IsAttivo Or SezioneResponsabilitaCivile.IsAttivo))

            CoperturaTutelaLegaleDelibereAssemlea.DipendeDa(CoperturaTutelaLegaleBase.IsAttivo)
            CoperturaTutelaLegaleDlgs19603.DipendeDa(CoperturaTutelaLegaleBase.IsAttivo)
            CoperturaTutelaLegaleDlgs8108.DipendeDa(CoperturaTutelaLegaleBase.IsAttivo)

            CoperturaTutelaLegale.Stato = CoperturaTutelaLegaleBase.Stato
            SezioneTutelaLegale.Stato = CoperturaTutelaLegale.Stato

            Dim NumeroUnitaImmobiliariOltre6 As Integer = NumeroUnitaImmobiliari - 6
            If NumeroUnitaImmobiliariOltre6 < 0 Then NumeroUnitaImmobiliariOltre6 = 0

            With CoperturaTutelaLegaleBase
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 10000

                .Tariffa.Base = 0
                If .Garanzia.Massimale = 10000 Then
                    .Tariffa.Base = 115D + NumeroUnitaImmobiliariOltre6 * 20D
                ElseIf .Garanzia.Massimale = 20000 Then
                    .Tariffa.Base = 145D + NumeroUnitaImmobiliariOltre6 * 25D
                ElseIf .Garanzia.Massimale = 30000 Then
                    .Tariffa.Base = 180D + NumeroUnitaImmobiliariOltre6 * 32D
                End If
            End With

            CoperturaTutelaLegaleDlgs8108.Tariffa.Base = 0.2D * CoperturaTutelaLegaleBase.Tariffa.Base
            CoperturaTutelaLegaleDlgs19603.Tariffa.Base = 0.1D * CoperturaTutelaLegaleBase.Tariffa.Base
            CoperturaTutelaLegaleDelibereAssemlea.Tariffa.Base = 0.3D * CoperturaTutelaLegaleBase.Tariffa.Base

        End Sub

        Public Sub ValidaSezioneTerremoto()
            CoperturaTerremotoBase.DipendeDa(CoperturaIncendioBase.IsAttivo _
                                             And CoperturaResponsabilitaCivileBase.IsAttivo _
                                             And PartitaIncendio.SommaAssicurata >= 100000D _
                                             And TipologiaFabbricato = TipologiaFabbricatoEnum.FabbricatoIntero _
                                             And Frazionamento <> FrazionamentiEnum.UnicoAnticipato)
            SezioneTerremoto.Stato = CoperturaTerremotoBase.Stato

            With CoperturaTerremotoBase
                If CaratteristicaCostruttiva = 0 Then CaratteristicaCostruttiva = CaratteristicaCostruttivaEnum.NonAntisismica
                If .Garanzia.Limite = 0 Then .Garanzia.Limite = 30

                '0=Antisismico: Sc. 5% SA min. 15.000 max 30.000, NonAntisism: Sc. 10% SA min. 25.000 max 50.000
                '1=Antisismico: Sc. 3% SA, NonAntisism: Sc. 5% SA
                '2=Antisismico: Franchigia 150.000, NonAntisism: Franchigia 250.000

                Dim combinazione As Integer = 0
                If .Partita.SommaAssicurata > 5000000 Then
                    combinazione = 2
                ElseIf .Partita.SommaAssicurata > 1000000 Then
                    combinazione = 1
                End If

                .Tariffa.Tasso = CDec(Tabelle.getTassoTerremoto(Comune, combinazione, .Garanzia.Limite, CaratteristicaCostruttiva))
            End With
        End Sub

        Public Overrides Sub Stampa(ByVal options As StampaOptions)
            Dim s As New P07260ST
            Stampato = True
            s.StampaMostraEtInvia(Me, options)
        End Sub


    End Class
End Namespace
