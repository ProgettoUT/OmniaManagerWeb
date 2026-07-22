Namespace P07261
    <Serializable()> Public Class youCasa
        Inherits Prodotto
        'Globali
        'Public AdeguamentoFacoltativo As Boolean = True

        Public AbitazioneX As New List(Of Abitazione)

        <NonSerialized()> Public Tabelle As P07261TR

        Public FormaAssicurazione As FormaAssicurazioneEnum
        Public ZonaTerritorialeSalvaBenessere As ZonaTerritorialeSalvaBenessereEnum
        Public RCChiave As RCChiaveEnum
        Public SalvaBenessereEta As SalvaBenessereEtaEnum
        Public TutelaLegaleChiave As TutelaLegaleChiaveEnum
        Public Regione As RegioneEnum
        Public IncendioChiave As IncendioChiaveEnum
        Public FurtoChiave As FurtoChiaveEnum

        'aliquote
        Public AliquotaImpostaTerremoto As Decimal = 0.2225D
        Public AliquotaImpostaSalvaBenessere As Decimal = 0.1375D ' 40% * 2,5% + 60% * 21,25%

        'sezioni
        Public SezioneIncendio As New Sezione(Me, TipoSezione.Incendio)
        Public SezioneTerremoto As New Sezione(Me, TipoSezione.Terremoto)
        Public SezioneFurto As New Sezione(Me, TipoSezione.Furto)
        Public SezioneResponsabilitaCivile As New Sezione(Me, TipoSezione.ResponsabilitaCivile)
        Public SezioneSalvaBenessere As New Sezione(Me, TipoSezione.SalvaBenessere)
        Public SezioneTutelaLegale As New Sezione(Me, TipoSezione.TutelaLegale)
        Public SezioneAssistenza As New Sezione(Me, TipoSezione.Assistenza)

        'Incendio
        Public CoperturaIncendio As New CoperturaComposta()

        'Terremoto
        Public CoperturaTerremoto As New CoperturaComposta()

        'Furto
        Public CoperturaFurto As New CoperturaComposta()

        'ResponsabilitaCivile
        Public PartitaResponsabilitaCivileBase As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaResponsabilitaCivileBase As New CoperturaSingola(PartitaResponsabilitaCivileBase, New Garanzia(TipoGaranzia.ResponsabilitaCivileBase))
        Public PartitaRCVitaPrivata As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCVitaPrivata As New CoperturaSingola(PartitaRCVitaPrivata, New Garanzia(TipoGaranzia.RCVitaPrivata))
        Public PartitaRCFabbricati As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCFabbricati As New CoperturaSingola(PartitaRCFabbricati, New Garanzia(TipoGaranzia.RCFabbricati))
        Public PartitaRCVitaPrivataFabbricati As New Partita(TipoPartita.ResponsabilitaCivile)
        Public CoperturaRCVitaPrivataFabbricati As New CoperturaSingola(PartitaRCVitaPrivataFabbricati, New Garanzia(TipoGaranzia.RCVitaPrivataFabbricati))

        'SalvaBenessere
        Public PartitaSalvaBenessereBase As New Partita(TipoPartita.SalvaBenessere)
        Public CoperturaSalvaBenessereBase As New CoperturaSingola(PartitaSalvaBenessereBase, New Garanzia(TipoGaranzia.SalvaBenessereBase))

        'TutelaLegale
        Public PartitaTutelaLegaleBase As New Partita(TipoPartita.TutelaLegale)
        Public CoperturaTutelaLegaleBase As New CoperturaSingola(PartitaTutelaLegaleBase, New Garanzia(TipoGaranzia.TutelaLegaleBase))

        'Assistenza
        Public PartitaAssistenzaBase As New Partita(TipoPartita.Assistenza)
        Public CoperturaAssistenzaBase As New CoperturaSingola(PartitaAssistenzaBase, New Garanzia(TipoGaranzia.AssistenzaBase))

        'integrazione 12/02/2015
        Public CoperturaRCEstensioneGaranziaBase As New CoperturaSingola(PartitaRCVitaPrivataFabbricati, New Garanzia(TipoGaranzia.RCEstensioneGaranziaBase))


        Public ReadOnly Property TipoContraenza As TipoContraenzaEnum
            Get
                If IsNumeric(Cliente.CodiceFiscale) Then
                    Return TipoContraenzaEnum.PersonaGiudirica
                Else
                    Return TipoContraenzaEnum.PersonaFisica
                End If
            End Get
        End Property

        Public Function HaCoperturaFurtoContenutoDimoraAbituale() As Boolean
            For Each Abitazione As Abitazione In AbitazioneX
                If Abitazione.CoperturaFurtoContenuto.IsAttivo Then
                    If Abitazione.IsDimoraAbituale() Then
                        Return True
                    End If
                End If
            Next
            Return False
        End Function

        Public Overrides Sub New2()
            'Caratteristiche
            CodiceRamoPolizza = "148"
            CodiceProdotto = CStr(TipoProdotto.YouCasa)
            DescrizioneProdotto = P00000DE.DecodeProdotto(TipoProdotto.YouCasa)
            Edizione = "01.03.2014"
            DataEntrataVigore = "01/03/2014"

            DurataContrattualeMinimaInAnni = 1
            DurataContrattualeMassimaInAnni = 10
            PeriodoMoraInGiorni = 15
            EmissioneAppendici = False
            TacitoRinnovo = True

            ContraenzaPersonaGiuridica = True
            ContraenzaPersonaFisica = True
            PremioMinimoPrimaRata = 50D
            PremioMinimoRataSuccessiva = 50D

            'I tassi e i premi della presente tariffa sono comprensivi di imposte e oneri parafiscali.
            BaseTasse = UniQuota.BaseTasse.BaseLorda

            SezioneTerremoto.EscludiFlex = True

            If IncendioChiave = 0 Then IncendioChiave = IncendioChiaveEnum.ChiaveARGENTO
            If FurtoChiave = 0 Then FurtoChiave = FurtoChiaveEnum.ChiaveORO

            If CoperturaRCEstensioneGaranziaBase Is Nothing Then
                CoperturaRCEstensioneGaranziaBase = New CoperturaSingola(PartitaRCVitaPrivataFabbricati, New Garanzia(TipoGaranzia.RCEstensioneGaranziaBase))
                SezioneResponsabilitaCivile.AddCopertura(CoperturaRCEstensioneGaranziaBase)
            End If
            For Each abitazione As Abitazione In AbitazioneX
                abitazione.LoadForOldVersions()
            Next
        End Sub

        Public Sub New()
            New2()

            'sezioni
            Sezioni.Add(SezioneIncendio)
            Sezioni.Add(SezioneTerremoto)
            Sezioni.Add(SezioneFurto)
            Sezioni.Add(SezioneResponsabilitaCivile)
            Sezioni.Add(SezioneSalvaBenessere)
            Sezioni.Add(SezioneTutelaLegale)
            Sezioni.Add(SezioneAssistenza)

            'aliquote
            SezioneIncendio.AliquotaImposta = AliquotaImpostaIncendio
            SezioneTerremoto.AliquotaImposta = AliquotaImpostaTerremoto
            SezioneFurto.AliquotaImposta = AliquotaImpostaFurto
            SezioneResponsabilitaCivile.AliquotaImposta = AliquotaImpostaResponsabilitaCivile
            SezioneSalvaBenessere.AliquotaImposta = AliquotaImpostaSalvaBenessere
            SezioneTutelaLegale.AliquotaImposta = AliquotaImpostaTutelaLegale
            SezioneAssistenza.AliquotaImposta = AliquotaImpostaAssistenza

            'sezione - coperture
            SezioneIncendio.AddCopertura(CoperturaIncendio)
            SezioneTerremoto.AddCopertura(CoperturaTerremoto)
            SezioneFurto.AddCopertura(CoperturaFurto)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaResponsabilitaCivileBase)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCVitaPrivata)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCFabbricati)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCVitaPrivataFabbricati)
            SezioneResponsabilitaCivile.AddCopertura(CoperturaRCEstensioneGaranziaBase)
            SezioneSalvaBenessere.AddCopertura(CoperturaSalvaBenessereBase)
            SezioneTutelaLegale.AddCopertura(CoperturaTutelaLegaleBase)
            SezioneAssistenza.AddCopertura(CoperturaAssistenzaBase)

            CoperturaIncendio.Stato = StatoCopertura.attiva
            CoperturaTerremoto.Stato = StatoCopertura.attiva
            CoperturaFurto.Stato = StatoCopertura.attiva

            'per la stampa
            'CoperturaResponsabilitaCivileBase.NonStampare = True

        End Sub

        Public Overrides Sub Inizializza()
            MyBase.Inizializza()
            Tabelle = New P07261TR()
        End Sub

        Public Overrides Sub Valida()
            ValidaCondizioniGenerali()
            ValidaSconti()
            ValidaSezioneIncendio()
            ValidaSezioneTerremoto()
            ValidaSezioneFurto()
            ValidaSezioneResponsabilitaCivile()
            ValidaSezioneSalvaBenessere()
            ValidaSezioneTutelaLegale()
            ValidaSezioneAssistenza()
        End Sub

        Public Sub ValidaCondizioniGenerali()
            'È obbligatoria almeno una delle seguenti sezioni:
            '- Incendio;
            '- Furto;
            '- Responsabilità Civile.
            SezioneResponsabilitaCivile.Stato = CoperturaResponsabilitaCivileBase.Stato
            SezioneSalvaBenessere.Stato = CoperturaSalvaBenessereBase.Stato
            SezioneAssistenza.Stato = CoperturaAssistenzaBase.Stato
            SezioneTutelaLegale.Stato = CoperturaTutelaLegaleBase.Stato

            SezioneIncendio.Stato = StatoCopertura.esclusa
            SezioneFurto.Stato = StatoCopertura.esclusa


            For Each abitazione As Abitazione In AbitazioneX
                With abitazione
                    .ValidaGenerale()

                    If .CoperturaIncendioAbitazione.IsAttivo _
                        Or .CoperturaIncendioContenuto.IsAttivo Then
                        SezioneIncendio.Stato = StatoCopertura.attiva
                    End If
                    If .CoperturaTerremotoFabbricato.IsAttivo Then
                        SezioneTerremoto.Stato = StatoCopertura.attiva
                    End If
                    If .CoperturaFurtoContenuto.IsAttivo _
                        Or .CoperturaFurtoEsternoOro.IsAttivo Then
                        SezioneFurto.Stato = StatoCopertura.attiva
                    End If
                End With
            Next

        End Sub

        Public Sub ValidaSconti()
            Dim PercentualeScontoTecnico As Decimal = 0D
            Dim PercentualeScontoAdeguamento As Decimal = 0D
            Dim PercentualeScontoTotale As Decimal = 0D
            Dim numeroSezioniObbligatorie As Integer = -(SezioneIncendio.IsAttivo) _
                                                       - (SezioneFurto.IsAttivo) _
                                                       - (SezioneResponsabilitaCivile.IsAttivo)

            'Sconti(tariffari)
            '- Il prodotto prevede l’applicazione di uno
            'sconto tecnico per pluralità di garanzie,
            'legato alla presenza in polizza delle sezioni
            'obbligatorie Incendio, Furto, Responsabilità Civile:
            '- n° 2 sezioni sconto 5%
            '- n° 3 sezioni sconto 10%
            'Gli sconti di tariffa si applicano a tutte le sezioni
            'richiamate ad eccezione delle sezioni
            '“Rischio Terremoto” e “Salvabenessere”.

            If numeroSezioniObbligatorie = 2 Then
                PercentualeScontoTecnico = 0.05D
            ElseIf numeroSezioniObbligatorie = 3 Then
                PercentualeScontoTecnico = 0.1D
            Else
                PercentualeScontoTecnico = 0D
            End If

            'In caso di operatività dell’art 1.12 “Adeguamento
            'delle somme assicurate e del corrispettivo
            'Premio(" è previsto l’applicazione")
            'di uno sconto del 5% su tutte le sezioni di
            'polizza con esclusione della sezione Rischio Terremoto ed Assistenza.

            If Indicizzazione = StatoCopertura.attiva Then 'AdeguamentoFacoltativo 
                PercentualeScontoAdeguamento = 0.05D
            End If
            ' s = 1 - (1-s1)(1-s2)= s1 + s2 - s1*s2
            PercentualeScontoTotale = PercentualeScontoTecnico + PercentualeScontoAdeguamento - PercentualeScontoTecnico * PercentualeScontoAdeguamento

            SezioneTerremoto.PercentualeScontoTecnico = 0D
            SezioneSalvaBenessere.PercentualeScontoTecnico = PercentualeScontoAdeguamento
            SezioneAssistenza.PercentualeScontoTecnico = PercentualeScontoTecnico
            SezioneIncendio.PercentualeScontoTecnico = PercentualeScontoTotale
            SezioneFurto.PercentualeScontoTecnico = PercentualeScontoTotale
            SezioneResponsabilitaCivile.PercentualeScontoTecnico = PercentualeScontoTotale
            SezioneTutelaLegale.PercentualeScontoTecnico = PercentualeScontoTotale
        End Sub

        Public Sub ValidaSezioneIncendio()
            For Each Abitazione As Abitazione In AbitazioneX
                Abitazione.ValidaSezioneIncendio()
            Next
        End Sub

        Public Sub ValidaSezioneTerremoto()
            For Each Abitazione As Abitazione In AbitazioneX
                Abitazione.ValidaSezioneTerremoto()
            Next
        End Sub

        Public Sub ValidaSezioneFurto()
            For Each Abitazione As Abitazione In AbitazioneX
                Abitazione.ValidaSezioneFurto()
            Next
        End Sub

        Public Sub ValidaSezioneResponsabilitaCivile()
            CoperturaResponsabilitaCivileBase.DipendeDa(True)
            SezioneResponsabilitaCivile.Stato = CoperturaResponsabilitaCivileBase.Stato
            If CoperturaRCVitaPrivata.IsAttivo And CoperturaRCFabbricati.IsAttivo Then
                CoperturaRCVitaPrivataFabbricati.Stato = StatoCopertura.attiva
            End If
            CoperturaRCVitaPrivataFabbricati.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo)
            CoperturaRCVitaPrivata.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo And RCChiave <> RCChiaveEnum.ChiavePLATINO And Not CoperturaRCVitaPrivataFabbricati.IsAttivo)
            CoperturaRCFabbricati.DipendeDa(CoperturaResponsabilitaCivileBase.IsAttivo And RCChiave <> RCChiaveEnum.ChiavePLATINO And Not CoperturaRCVitaPrivataFabbricati.IsAttivo)
            CoperturaRCEstensioneGaranziaBase.DipendeDa(CoperturaRCVitaPrivataFabbricati.IsAttivo And RCChiave <> RCChiaveEnum.ChiaveARGENTO)

            With CoperturaResponsabilitaCivileBase
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 250000D
                If RCChiave = 0 Then RCChiave = RCChiaveEnum.ChiaveARGENTO
                .Tariffa.Base = 0D

                If .Garanzia.Massimale = 250000D Then
                    CoperturaRCVitaPrivata.Tariffa.Base = Choose(RCChiave, 17D, 0D, 0D)
                    CoperturaRCFabbricati.Tariffa.Base = Choose(RCChiave, 7D, 0D, 0D)
                    CoperturaRCVitaPrivataFabbricati.Tariffa.Base = Choose(RCChiave, 23D, 0D, 0D)
                ElseIf .Garanzia.Massimale = 500000D Then
                    CoperturaRCVitaPrivata.Tariffa.Base = Choose(RCChiave, 21D, 73D, 0D)
                    CoperturaRCFabbricati.Tariffa.Base = Choose(RCChiave, 8D, 20D, 0D)
                    CoperturaRCVitaPrivataFabbricati.Tariffa.Base = Choose(RCChiave, 28D, 86D, 150D)
                ElseIf .Garanzia.Massimale = 1000000D Then
                    CoperturaRCVitaPrivata.Tariffa.Base = Choose(RCChiave, 26D, 87D, 0D)
                    CoperturaRCFabbricati.Tariffa.Base = Choose(RCChiave, 10D, 24D, 0D)
                    CoperturaRCVitaPrivataFabbricati.Tariffa.Base = Choose(RCChiave, 34D, 103D, 171D)
                ElseIf .Garanzia.Massimale = 1500000D Then
                    CoperturaRCVitaPrivata.Tariffa.Base = Choose(RCChiave, 0D, 96D, 0D)
                    CoperturaRCFabbricati.Tariffa.Base = Choose(RCChiave, 0D, 26D, 0D)
                    CoperturaRCVitaPrivataFabbricati.Tariffa.Base = Choose(RCChiave, 0D, 112D, 185D)
                ElseIf .Garanzia.Massimale = 2000000D Then
                    CoperturaRCVitaPrivata.Tariffa.Base = Choose(RCChiave, 0D, 101D, 0D)
                    CoperturaRCFabbricati.Tariffa.Base = Choose(RCChiave, 0D, 27D, 0D)
                    CoperturaRCVitaPrivataFabbricati.Tariffa.Base = Choose(RCChiave, 0D, 119D, 192D)
                ElseIf .Garanzia.Massimale = 2500000D Then
                    CoperturaRCVitaPrivata.Tariffa.Base = Choose(RCChiave, 0D, 106D, 0D)
                    CoperturaRCFabbricati.Tariffa.Base = Choose(RCChiave, 0D, 29D, 0D)
                    CoperturaRCVitaPrivataFabbricati.Tariffa.Base = Choose(RCChiave, 0D, 125D, 200D)
                End If

                CoperturaRCEstensioneGaranziaBase.Tariffa.Base = Choose(RCChiave, 0D, 0.05D, 0.02D) * CoperturaRCVitaPrivataFabbricati.Tariffa.Base

                If RCChiave = RCChiaveEnum.ChiaveARGENTO Then
                    If .Garanzia.Massimale > 1000000D Then
                        .SetRischioDirezione("Massimale Riservato Direzione per chiave Argento")
                    End If
                ElseIf .Garanzia.Massimale = 250000D Then
                    .SetRischioDirezione("Massimale Riservato Direzione per chiave Oro e Platino")
                End If
                If .RischioDirezione > 0 Then
                    CoperturaRCVitaPrivata.SetRischioDirezione(.DescrizioneRD)
                    CoperturaRCFabbricati.SetRischioDirezione(.DescrizioneRD)
                    CoperturaRCVitaPrivataFabbricati.SetRischioDirezione(.DescrizioneRD)
                End If
            End With
        End Sub

        Public Sub ValidaSezioneSalvaBenessere()
            CoperturaSalvaBenessereBase.DipendeDa((SezioneResponsabilitaCivile.IsAttivo Or SezioneIncendio.IsAttivo Or SezioneFurto.IsAttivo) _
                                                  And TipoContraenza = TipoContraenzaEnum.PersonaFisica)
            SezioneSalvaBenessere.Stato = CoperturaSalvaBenessereBase.Stato


            With CoperturaSalvaBenessereBase
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 1200D
                If SalvaBenessereEta = 0 Then
                    Dim eta As Integer = DateDiff(DateInterval.Month, Cliente.GetDataDiNascita, Now) \ 12 'Now.Year - Cliente.GetDataDiNascita.Year

                    If eta < 25 Then
                        SalvaBenessereEta = SalvaBenessereEtaEnum.Fascia0024
                    ElseIf eta < 35 Then
                        SalvaBenessereEta = SalvaBenessereEtaEnum.Fascia2534
                    ElseIf eta < 46 Then
                        SalvaBenessereEta = SalvaBenessereEtaEnum.Fascia3545
                    ElseIf eta < 61 Then
                        SalvaBenessereEta = SalvaBenessereEtaEnum.Fascia4660
                    ElseIf eta < 66 Then
                        SalvaBenessereEta = SalvaBenessereEtaEnum.Fascia6165
                    ElseIf eta < 70 Then
                        SalvaBenessereEta = SalvaBenessereEtaEnum.Fascia6669
                    Else
                        SalvaBenessereEta = SalvaBenessereEtaEnum.Fascia7000
                    End If
                End If
                If SalvaBenessereEta = 0 Then SalvaBenessereEta = SalvaBenessereEtaEnum.Fascia2534

                If Regione = RegioneEnum.REGIONE Then
                    Dim siglaProvincia As String = Cliente.Provincia
                    If String.IsNullOrEmpty(siglaProvincia) Then
                        siglaProvincia = Agenzia.Provincia
                    End If

                    Regione = Luogo.Province(Luogo.GetProvinciaBySigla(siglaProvincia)).Regione.IdRegione

                    If Regione = RegioneEnum.REGIONE Then
                        Regione = RegioneEnum.ABRUZZO
                    End If
                End If

                ZonaTerritorialeSalvaBenessere = CType(Decode, P07261DE).DecodeRegioneToZonaTerritorialeSalvaBenessere(Regione)

                .Partita.SommaAssicurata = .Garanzia.Massimale

                If SalvaBenessereEta = SalvaBenessereEtaEnum.Fascia2534 Then
                    .Tariffa.Tasso = Choose(ZonaTerritorialeSalvaBenessere, 3.36D, 4.84D, 8.93D) / 100D
                ElseIf SalvaBenessereEta = SalvaBenessereEtaEnum.Fascia3545 Then
                    .Tariffa.Tasso = Choose(ZonaTerritorialeSalvaBenessere, 2.15D, 2.96D, 5.22D) / 100D
                ElseIf SalvaBenessereEta = SalvaBenessereEtaEnum.Fascia4660 Then
                    .Tariffa.Tasso = Choose(ZonaTerritorialeSalvaBenessere, 2.26D, 3.08D, 5.44D) / 100D
                ElseIf SalvaBenessereEta = SalvaBenessereEtaEnum.Fascia6165 Then
                    .Tariffa.Tasso = Choose(ZonaTerritorialeSalvaBenessere, 2.31D, 3.16D, 5.58D) / 100D
                ElseIf SalvaBenessereEta = SalvaBenessereEtaEnum.Fascia6669 Then
                    .Tariffa.Tasso = Choose(ZonaTerritorialeSalvaBenessere, 2.34D, 3.21D, 5.66D) / 100D
                Else
                    .Tariffa.Tasso = 0D
                    .SetNonDisponibile("Fascia di età non ammessa per Salva Benessere")
                End If

                If TipoContraenza = TipoContraenzaEnum.PersonaGiudirica Then
                    .SetNonDisponibile("Sezione non ammessa per contraenza ""Persona Giudirica""")
                End If
            End With
        End Sub

        Public Sub ValidaSezioneTutelaLegale()
            CoperturaTutelaLegaleBase.DipendeDa((CoperturaRCFabbricati.IsAttivo Or CoperturaRCVitaPrivata.IsAttivo Or CoperturaRCVitaPrivataFabbricati.IsAttivo) _
                                                And TipoContraenza = TipoContraenzaEnum.PersonaFisica)
            SezioneTutelaLegale.Stato = CoperturaTutelaLegaleBase.Stato


            With CoperturaTutelaLegaleBase
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 10000D
                If TutelaLegaleChiave = 0 Then TutelaLegaleChiave = TutelaLegaleChiaveEnum.ChiaveARGENTO
                .Tariffa.Base = 0D
                If TutelaLegaleChiave = TutelaLegaleChiaveEnum.ChiaveARGENTO Then
                    If .Garanzia.Massimale = 10000D Then
                        .Tariffa.Base = 20D
                    ElseIf .Garanzia.Massimale = 20000D Then
                        .Tariffa.Base = 25D
                    ElseIf .Garanzia.Massimale = 30000D Then
                        .Tariffa.Base = 30D
                    End If
                ElseIf TutelaLegaleChiave = TutelaLegaleChiaveEnum.ChiaveORO Then
                    If .Garanzia.Massimale = 10000D Then
                        .Tariffa.Base = 52D
                    ElseIf .Garanzia.Massimale = 20000D Then
                        .Tariffa.Base = 70D
                    ElseIf .Garanzia.Massimale = 30000D Then
                        .Tariffa.Base = 85D
                    End If
                ElseIf TutelaLegaleChiave = TutelaLegaleChiaveEnum.ChiavePLATINO Then
                    If .Garanzia.Massimale = 10000D Then
                        .Tariffa.Base = 65D
                    ElseIf .Garanzia.Massimale = 20000D Then
                        .Tariffa.Base = 85D
                    ElseIf .Garanzia.Massimale = 30000D Then
                        .Tariffa.Base = 110D
                    End If
                End If
                If TipoContraenza = TipoContraenzaEnum.PersonaGiudirica Then
                    .SetNonDisponibile("Sezione non ammessa per contraenza ""Persona Giudirica""")
                End If
            End With

        End Sub

        Public Sub ValidaSezioneAssistenza()
            CoperturaAssistenzaBase.DipendeDa((SezioneResponsabilitaCivile.IsAttivo Or SezioneIncendio.IsAttivo Or SezioneFurto.IsAttivo) _
                                              And TipoContraenza = TipoContraenzaEnum.PersonaFisica)
            SezioneAssistenza.Stato = CoperturaAssistenzaBase.Stato

            With CoperturaAssistenzaBase
                .Tariffa.Base = 17D
                If TipoContraenza = TipoContraenzaEnum.PersonaGiudirica Then
                    .SetNonDisponibile("Sezione non ammessa per contraenza ""Persona Giudirica""")
                End If
            End With
        End Sub

        Public Overrides Sub CalcolaFrazionamento()
            If Frazionamento = FrazionamentiEnum.Semestrale Then
                Interessi = Math.Round(PremioLordo * 0.03D, 2, MidpointRounding.AwayFromZero)
                PremioPrimaRata = Math.Round((PremioLordo + Interessi) / 2, 2, MidpointRounding.AwayFromZero)
            ElseIf Frazionamento = FrazionamentiEnum.Quadrimestrale Then
                Interessi = Math.Round(PremioLordo * 0.04D, 2, MidpointRounding.AwayFromZero)
                PremioPrimaRata = Math.Round((PremioLordo + Interessi) / 3, 2, MidpointRounding.AwayFromZero)
            ElseIf Frazionamento = FrazionamentiEnum.Trimestrale Then
                Interessi = Math.Round(PremioLordo * 0.05D, 2, MidpointRounding.AwayFromZero)
                PremioPrimaRata = Math.Round((PremioLordo + Interessi) / 4, 2, MidpointRounding.AwayFromZero)
            ElseIf Frazionamento = FrazionamentiEnum.Mensile Then
                Interessi = Math.Round(PremioLordo * 0.06D, 2, MidpointRounding.AwayFromZero)
                PremioPrimaRata = Math.Round((PremioLordo + Interessi) / 12, 2, MidpointRounding.AwayFromZero)
            ElseIf Frazionamento = FrazionamentiEnum.Temporaneo Then
                Interessi = 0D
                If Periodo = PeriodoEnum.Mesi Then
                    PremioPrimaRata = Math.Round((PremioLordo) * (3 + Durata) / 12, 2, MidpointRounding.AwayFromZero)
                ElseIf Periodo = PeriodoEnum.Giorni Then
                    PremioPrimaRata = Math.Round((PremioLordo) * (90 + Durata) / 360, 2, MidpointRounding.AwayFromZero)
                End If
            ElseIf Frazionamento = FrazionamentiEnum.UnicoAnticipato Then
                Interessi = 0D
                PremioPrimaRata = Math.Round((PremioLordo) * Durata, 2, MidpointRounding.AwayFromZero)
            Else
                Interessi = 0D
                PremioPrimaRata = PremioLordo
            End If

            If Frazionamento <> FrazionamentiEnum.UnicoAnticipato _
            And Frazionamento <> FrazionamentiEnum.Temporaneo Then
                PremioRataSuccessiva = PremioPrimaRata
            Else
                PremioRataSuccessiva = 0D
            End If

            PremioAnnuo = PremioLordo + Interessi

            If PremioMinimoPrimaRata > 0 And PremioPrimaRata > 0 And PremioPrimaRata < PremioMinimoPrimaRata Then
                PremioPrimaRata = PremioMinimoPrimaRata
            End If
            If PremioMinimoRataSuccessiva > 0 And PremioRataSuccessiva > 0 And PremioRataSuccessiva < PremioMinimoRataSuccessiva Then
                PremioRataSuccessiva = PremioMinimoRataSuccessiva
            End If

            If Frazionamento = FrazionamentiEnum.UnicoAnticipato Then
                Indicizzazione = StatoCopertura.Inapplicabile
            ElseIf Indicizzazione = StatoCopertura.Inapplicabile Then
                Indicizzazione = StatoCopertura.attiva
            End If

        End Sub

        Public Sub AggiungiAbitazione(ByRef Abitazione As Abitazione)
            AbitazioneX.Add(Abitazione)
            CoperturaIncendio.Coperture.Add(Abitazione.CoperturaIncendio)
            CoperturaTerremoto.Coperture.Add(Abitazione.CoperturaTerremoto)
            CoperturaFurto.Coperture.Add(Abitazione.CoperturaFurto)
        End Sub

        Public Sub RimuoviAbitazione(ByRef Abitazione As Abitazione)
            AbitazioneX.Remove(Abitazione)
            CoperturaIncendio.Coperture.Remove(Abitazione.CoperturaIncendio)
            CoperturaTerremoto.Coperture.Remove(Abitazione.CoperturaTerremoto)
            CoperturaFurto.Coperture.Remove(Abitazione.CoperturaFurto)
        End Sub

        Public Overrides Sub Stampa(ByVal options As StampaOptions)
            Dim s As New P07261ST
            Stampato = True
            s.StampaMostraEtInvia(Me, options)
        End Sub

        'ESTENSIONE PER ESSIG
        Public Overrides Function HasEssig() As Boolean
            Return True
        End Function

        Public Overrides Function GetNewPES() As P00000ES
            Return New P07261ES(Me)
        End Function
    End Class
End Namespace
