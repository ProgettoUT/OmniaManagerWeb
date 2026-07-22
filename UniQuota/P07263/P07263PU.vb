Namespace P07263
    <Serializable()> Public Class Abitazione

        Public UnipolSaiCasaServizi As UnipolSaiCasaServizi

        Public TipoDimora As TipoDimoraEnum
        Public TipoAbitazione As TipoAbitazioneEnum
        Public TipoUtilizzo As TipoUtilizzoEnum
        Public TipologiaCostruzione As TipologiaCostruzioneEnum
        Public Antisismico As AntisismicoEnum
        Public Alluvionato As AlluvionatoEnum
        Public PianoAssicurato As PianoAssicuratoEnum
        Public ClasseTerritorialeFurto As ClasseTerritorialeFurtoEnum
        Public ClasseTerritorialeEventiAtmosferici As ClasseTerritorialeEventiAtmosfericiEnum
        Public ClasseTerritorialeDanniAcqua As ClasseTerritorialeDanniAcquaEnum
        Public Riparazionediretta As RiparazionedirettaEnum
        Public DanniBeniAbitazioneFormaGaranzia As DanniBeniAbitazioneFormaGaranziaEnum
        Public DanniBeniContenutoFormaGaranzia As DanniBeniContenutoFormaGaranziaEnum
        Public AssistenzaPlus As AssistenzaPlusEnum
        Public Provincia As ProvinciaEnum
        Public Comune As Integer
        Public Indirizzo As String
        Public NumeroCivico As String


        'DanniBeni
        Public CoperturaDanniBeni As New CoperturaComposta()
        Public PartitaDanniBeniAbitazione As New Partita(TipoPartita.DanniBeni)
        Public CoperturaDanniBeniAbitazione As New CoperturaSingola(PartitaDanniBeniAbitazione, New Garanzia(TipoGaranzia.DanniBeniAbitazione), True)
        Public PartitaDanniBeniContenuto As New Partita(TipoPartita.DanniBeni)
        Public CoperturaDanniBeniContenuto As New CoperturaSingola(PartitaDanniBeniContenuto, New Garanzia(TipoGaranzia.DanniBeniContenuto), True)
        Public PartitaDanniBeniGaranziaPlus As New Partita(TipoPartita.DanniBeni)
        Public CoperturaDanniBeniGaranziaPlus As New CoperturaSingola(PartitaDanniBeniGaranziaPlus, New Garanzia(TipoGaranzia.DanniBeniGaranziaPlus))
        Public PartitaDanniBeniFenomeniElettrici As New Partita(TipoPartita.DanniBeni)
        Public CoperturaDanniBeniFenomeniElettrici As New CoperturaSingola(PartitaDanniBeniFenomeniElettrici, New Garanzia(TipoGaranzia.DanniBeniFenomeniElettrici))
        Public PartitaDanniBeniFenomeniElettriciPannelliSolari As New Partita(TipoPartita.DanniBeni)
        Public CoperturaDanniBeniFenomeniElettriciPannelliSolari As New CoperturaSingola(PartitaDanniBeniFenomeniElettriciPannelliSolari, New Garanzia(TipoGaranzia.DanniBeniFenomeniElettriciPannelliSolari))
        Public PartitaDanniBeniFenomeniAtmosferici As New Partita(TipoPartita.DanniBeni)
        Public CoperturaDanniBeniFenomeniAtmosferici As New CoperturaSingola(PartitaDanniBeniFenomeniAtmosferici, New Garanzia(TipoGaranzia.DanniBeniFenomeniAtmosferici))
        Public PartitaDanniBeniDanniDaAcqua As New Partita(TipoPartita.DanniBeni)
        Public CoperturaDanniBeniDanniDaAcqua As New CoperturaSingola(PartitaDanniBeniDanniDaAcqua, New Garanzia(TipoGaranzia.DanniBeniDanniDaAcqua))
        Public PartitaDanniBeniRicercaGuasto As New Partita(TipoPartita.DanniBeni)
        Public CoperturaDanniBeniRicercaGuasto As New CoperturaSingola(PartitaDanniBeniRicercaGuasto, New Garanzia(TipoGaranzia.DanniBeniRicercaGuasto))
        Public PartitaDanniBeniPerditeOcculte As New Partita(TipoPartita.DanniBeni)
        Public CoperturaDanniBeniPerditeOcculte As New CoperturaSingola(PartitaDanniBeniPerditeOcculte, New Garanzia(TipoGaranzia.DanniBeniPerditeOcculte))
        Public PartitaDanniBeniVetriCristalli As New Partita(TipoPartita.DanniBeni)
        Public CoperturaDanniBeniVetriCristalli As New CoperturaSingola(PartitaDanniBeniVetriCristalli, New Garanzia(TipoGaranzia.DanniBeniVetriCristalli))

        'Catastrofali
        Public CoperturaCatastrofali As New CoperturaComposta()
        Public CoperturaCatastrofaliTerremotoAbitazione As New CoperturaSingola(PartitaDanniBeniAbitazione, New Garanzia(TipoGaranzia.CatastrofaliTerremotoAbitazione))
        Public CoperturaCatastrofaliTerremotoContenuto As New CoperturaSingola(PartitaDanniBeniContenuto, New Garanzia(TipoGaranzia.CatastrofaliTerremotoContenuto))
        Public CoperturaCatastrofaliAlluvioneAbitazione As New CoperturaSingola(PartitaDanniBeniAbitazione, New Garanzia(TipoGaranzia.CatastrofaliAlluvioneAbitazione))
        Public CoperturaCatastrofaliAlluvioneContenuto As New CoperturaSingola(PartitaDanniBeniContenuto, New Garanzia(TipoGaranzia.CatastrofaliAlluvioneContenuto))

        'AssistenzaPlus
        Public CoperturaAssistenzaPlus As New CoperturaComposta()
        Public PartitaAssistenzaPlusBase As New Partita(TipoPartita.AssistenzaPlus)
        Public CoperturaAssistenzaPlusBase As New CoperturaSingola(PartitaAssistenzaPlusBase, New Garanzia(TipoGaranzia.AssistenzaPlusBase))

        'ProtezioneEmergenza
        Public CoperturaProtezioneEmergenza As New CoperturaComposta()
        Public PartitaEmergenzaBase As New Partita(TipoPartita.ProtezioneEmergenza)
        Public CoperturaProtezioneEmergenzaBase As New CoperturaSingola(PartitaEmergenzaBase, _
                                                                        New Garanzia(TipoGaranzia.EmergenzaBase, _
                                                                        New Garanzia(TipoGaranzia.EmergenzaIndennitaForfettaria) + _
                                                                        New Garanzia(TipoGaranzia.EmergenzaRiassettoAbitazione) + _
                                                                        New Garanzia(TipoGaranzia.EmergenzaRiassettoPotenziamentoMezziChiusura) + _
                                                                        New Garanzia(TipoGaranzia.EmergenzaRimborsoSpeseMediche)))

        'Furto
        Public CoperturaFurto As New CoperturaComposta()
        Public PartitaDanniFurtoContenuto As New Partita(TipoPartita.Furto)
        Public CoperturaDanniFurtoContenuto As New CoperturaSingola(PartitaDanniFurtoContenuto, New Garanzia(TipoGaranzia.DanniFurtoContenuto), True)
        Public CoperturaDanniFurtoGaranziaPlus As New CoperturaSingola(PartitaDanniFurtoContenuto, New Garanzia(TipoGaranzia.DanniFurtoGaranziaPlus))
        Public PartitaDanniFurtoValoriNonCustoditi As New Partita(TipoPartita.Furto)
        Public CoperturaDanniFurtoValoriNonCustoditi As New CoperturaSingola(PartitaDanniFurtoValoriNonCustoditi, New Garanzia(TipoGaranzia.DanniFurtoValoriNonCustoditi), True)
        Public PartitaDanniFurtoValoriCustoditi As New Partita(TipoPartita.Furto)
        Public CoperturaDanniFurtoValoriCustoditi As New CoperturaSingola(PartitaDanniFurtoValoriCustoditi, New Garanzia(TipoGaranzia.DanniFurtoValoriCustoditi), True)
        Public PartitaDanniFurtoSocioPolitico As New Partita(TipoPartita.Furto)
        Public CoperturaDanniFurtoSocioPolitico As New CoperturaSingola(PartitaDanniFurtoSocioPolitico, New Garanzia(TipoGaranzia.DanniFurtoSocioPolitico))
        Public PartitaDanniFurtoPannelli As New Partita(TipoPartita.Furto)
        Public CoperturaDanniFurtoPannelli As New CoperturaSingola(PartitaDanniFurtoPannelli, New Garanzia(TipoGaranzia.DanniFurtoPannelli), True)
        Public PartitaDanniFurtoEsterno As New Partita(TipoPartita.Furto)
        Public CoperturaDanniFurtoEsterno As New CoperturaSingola(PartitaDanniFurtoEsterno, New Garanzia(TipoGaranzia.DanniFurtoEsterno), True)
        Public PartitaDanniFurtoImpiantoAllarme As New Partita(TipoPartita.Furto)
        Public CoperturaDanniFurtoImpiantoAllarme As New CoperturaSingola(PartitaDanniFurtoImpiantoAllarme, New Garanzia(TipoGaranzia.DanniFurtoImpiantoAllarme))

        Public Sub New(ByVal UnipolSaiCasaServizi As UnipolSaiCasaServizi)
            Me.UnipolSaiCasaServizi = UnipolSaiCasaServizi

            With CoperturaDanniBeni
                .Sezione = UnipolSaiCasaServizi.SezioneDanniBeni
                .AddCopertura(CoperturaDanniBeniAbitazione)
                .AddCopertura(CoperturaDanniBeniContenuto)
                .AddCopertura(CoperturaDanniBeniGaranziaPlus)
                .AddCopertura(CoperturaDanniBeniFenomeniElettrici)
                .AddCopertura(CoperturaDanniBeniFenomeniElettriciPannelliSolari)
                .AddCopertura(CoperturaDanniBeniFenomeniAtmosferici)
                .AddCopertura(CoperturaDanniBeniDanniDaAcqua)
                .AddCopertura(CoperturaDanniBeniRicercaGuasto)
                .AddCopertura(CoperturaDanniBeniPerditeOcculte)
                .AddCopertura(CoperturaDanniBeniVetriCristalli)
            End With

            With CoperturaCatastrofali
                .Sezione = UnipolSaiCasaServizi.SezioneCatastrofali
                .AddCopertura(CoperturaCatastrofaliTerremotoAbitazione)
                .AddCopertura(CoperturaCatastrofaliTerremotoContenuto)
                .AddCopertura(CoperturaCatastrofaliAlluvioneAbitazione)
                .AddCopertura(CoperturaCatastrofaliAlluvioneContenuto)
            End With

            With CoperturaAssistenzaPlus
                .Sezione = UnipolSaiCasaServizi.SezioneAssistenzaPlus
                .AddCopertura(CoperturaAssistenzaPlusBase)
            End With

            With CoperturaProtezioneEmergenza
                .Sezione = UnipolSaiCasaServizi.SezioneProtezioneEmergenza
                .AddCopertura(CoperturaProtezioneEmergenzaBase)
            End With

            With CoperturaFurto
                .Sezione = UnipolSaiCasaServizi.SezioneFurto
                .AddCopertura(CoperturaDanniFurtoContenuto)
                .AddCopertura(CoperturaDanniFurtoGaranziaPlus)
                .AddCopertura(CoperturaDanniFurtoValoriNonCustoditi)
                .AddCopertura(CoperturaDanniFurtoValoriCustoditi)
                .AddCopertura(CoperturaDanniFurtoSocioPolitico)
                .AddCopertura(CoperturaDanniFurtoPannelli)
                .AddCopertura(CoperturaDanniFurtoEsterno)
                .AddCopertura(CoperturaDanniFurtoImpiantoAllarme)
            End With

#If DEBUG Then
            '23/06/15: su indicazione di Giorgio, le opzioni vanno selezionate
            'Provincia = Luogo.GetProvinciaBySigla(UnipolSaiCasaServizi.Cliente.Provincia)
            Provincia = ProvinciaEnum.SiglaBS
            Comune = 54660
            Indirizzo = "VIA BARCUZZI"
            NumeroCivico = "27/N"

            TipoDimora = TipoDimoraEnum.Abituale
            TipoAbitazione = TipoAbitazioneEnum.VillaSchiera
            TipoUtilizzo = TipoUtilizzoEnum.Proprietario
            TipologiaCostruzione = TipologiaCostruzioneEnum.Muratura
            Antisismico = AntisismicoEnum.SI
            Alluvionato = AlluvionatoEnum.NO
            PianoAssicurato = PianoAssicuratoEnum.FabbricatoIntero
#End If
        End Sub

        Public Sub ValidaGenerale()

            If Provincia = ProvinciaEnum.SiglaXX Then
                Comune = 0
            End If
            'If Comune = 0 Then
            '    TipoAbitazione = 0
            'End If
            'If TipoAbitazione = 0 Then
            '    TipoDimora = 0
            'End If
            'If TipoDimora = 0 Then
            '    PianoAssicurato = 0
            'End If
            'If PianoAssicurato = 0 Then
            '    TipologiaCostruzione = 0
            'End If

            If Provincia = ProvinciaEnum.SiglaXX Then
                CoperturaDanniBeni.SetRischioDirezione("Selezionare la provincia dell'abitazione")
            ElseIf Comune = 0 Then
                CoperturaDanniBeni.SetRischioDirezione("Selezionare il comune dell'abitazione")
            ElseIf TipoAbitazione = 0 Then
                CoperturaDanniBeni.SetRischioDirezione("Selezionare il tipo di abitazione")
            ElseIf TipoDimora = 0 Then
                CoperturaDanniBeni.SetRischioDirezione("Selezionare il tipo di dimora")
            ElseIf TipoUtilizzo = 0 Then
                CoperturaDanniBeni.SetRischioDirezione("Selezionare il tipo di utilizzo")
            ElseIf PianoAssicurato = 0 Then
                CoperturaDanniBeni.SetRischioDirezione("Selezionare il piano dell'abitazione")
            ElseIf TipologiaCostruzione = 0 Then
                CoperturaDanniBeni.SetRischioDirezione("Selezionare la caratteristica costruttiva")
            End If

            If Riparazionediretta = 0 Then Riparazionediretta = RiparazionedirettaEnum.SI

            ClasseTerritorialeEventiAtmosferici = Decode.DecodeProvinciaToClasseTerritorialeEventiAtmosferici(Provincia)
            ClasseTerritorialeDanniAcqua = Decode.DecodeProvinciaToClasseTerritorialeDanniAcqua(Provincia)
            ClasseTerritorialeFurto = Decode.DecodeProvinciaToClasseTerritorialeFurto(Provincia)
        End Sub

        Public Function IsParamsCompleted() As Boolean
            Return TipologiaCostruzione <> 0
        End Function

        Public Sub ValidaSezioneDanniBeni()
            CoperturaDanniBeni.DipendeDa(IsParamsCompleted())
            If Not CoperturaDanniBeni.Sezione.IsAttivo Then
                CoperturaDanniBeni.Sezione.Stato = CoperturaDanniBeni.Stato
            End If

            CoperturaDanniBeniAbitazione.DipendeDa(CoperturaDanniBeni.IsAttivo)
            CoperturaDanniBeniContenuto.DipendeDa(CoperturaDanniBeni.IsAttivo)
            CoperturaDanniBeniGaranziaPlus.DipendeDa(CoperturaDanniBeni.IsAttivo)
            CoperturaDanniBeniFenomeniElettrici.DipendeDa(CoperturaDanniBeni.IsAttivo)
            CoperturaDanniBeniFenomeniElettriciPannelliSolari.DipendeDa(CoperturaDanniBeni.IsAttivo)
            CoperturaDanniBeniFenomeniAtmosferici.DipendeDa(CoperturaDanniBeni.IsAttivo)
            CoperturaDanniBeniDanniDaAcqua.DipendeDa(CoperturaDanniBeni.IsAttivo)
            CoperturaDanniBeniRicercaGuasto.DipendeDa(CoperturaDanniBeni.IsAttivo)
            CoperturaDanniBeniPerditeOcculte.DipendeDa(CoperturaDanniBeni.IsAttivo)
            CoperturaDanniBeniVetriCristalli.DipendeDa(CoperturaDanniBeni.IsAttivo)

            If DanniBeniAbitazioneFormaGaranzia = 0 Then DanniBeniAbitazioneFormaGaranzia = DanniBeniAbitazioneFormaGaranziaEnum.ValoreIntero
            If DanniBeniContenutoFormaGaranzia = 0 Then DanniBeniContenutoFormaGaranzia = DanniBeniContenutoFormaGaranziaEnum.ValoreIntero

            If DanniBeniAbitazioneFormaGaranzia = DanniBeniAbitazioneFormaGaranziaEnum.ValorePRA50 Then
                PartitaDanniBeniAbitazione.SommaAssicurata = 50000D
            ElseIf DanniBeniAbitazioneFormaGaranzia = DanniBeniAbitazioneFormaGaranziaEnum.ValorePRA100 Then
                PartitaDanniBeniAbitazione.SommaAssicurata = 100000D
            ElseIf TipologiaCostruzione = TipologiaCostruzioneEnum.Legno Then
                PartitaDanniBeniAbitazione.LimiteAssuntivoMassimo(250000D)
            Else
                PartitaDanniBeniAbitazione.LimiteAssuntivoMassimo(5000000D)
            End If

            If DanniBeniContenutoFormaGaranzia = DanniBeniContenutoFormaGaranziaEnum.ValoreIntero Then
                If TipologiaCostruzione = TipologiaCostruzioneEnum.Legno Then
                    PartitaDanniBeniAbitazione.LimiteAssuntivoMassimo(30000D)
                Else
                    PartitaDanniBeniAbitazione.LimiteAssuntivoMassimo(1000000D)
                End If
            Else
                If TipologiaCostruzione = TipologiaCostruzioneEnum.Legno Then
                    PartitaDanniBeniAbitazione.LimiteAssuntivoMassimo(15000D)
                Else
                    PartitaDanniBeniAbitazione.LimiteAssuntivoMassimo(500000D)
                End If
            End If

            With CoperturaDanniBeniAbitazione
                If DanniBeniAbitazioneFormaGaranzia = DanniBeniAbitazioneFormaGaranziaEnum.ValoreIntero Then
                    If .Partita.SommaAssicurata > 500000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 42.0, 62.0, 52.0) + Choose(TipoAbitazione, 0.059, 0.087, 0.073) * (.Partita.SommaAssicurata - 500000D) / 1000D
                    ElseIf .Partita.SommaAssicurata > 450000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 39.0, 57.5, 48.5) + Choose(TipoAbitazione, 0.06, 0.089, 0.075) * (.Partita.SommaAssicurata - 450000D) / 1000D
                    ElseIf .Partita.SommaAssicurata > 400000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 36.0, 53.0, 44.5) + Choose(TipoAbitazione, 0.063, 0.092, 0.077) * (.Partita.SommaAssicurata - 400000D) / 1000D
                    ElseIf .Partita.SommaAssicurata > 350000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 32.5, 48.5, 40.5) + Choose(TipoAbitazione, 0.065, 0.096, 0.08) * (.Partita.SommaAssicurata - 350000D) / 1000D
                    ElseIf .Partita.SommaAssicurata > 300000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 29.5, 43.5, 36.5) + Choose(TipoAbitazione, 0.068, 0.1, 0.084) * (.Partita.SommaAssicurata - 300000D) / 1000D
                    ElseIf .Partita.SommaAssicurata > 250000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 26.0, 38.0, 32.0) + Choose(TipoAbitazione, 0.071, 0.105, 0.088) * (.Partita.SommaAssicurata - 250000D) / 1000D
                    ElseIf .Partita.SommaAssicurata > 200000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 22.0, 32.5, 27.5) + Choose(TipoAbitazione, 0.075, 0.111, 0.093) * (.Partita.SommaAssicurata - 200000D) / 1000D
                    ElseIf .Partita.SommaAssicurata > 150000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 18.0, 26.5, 22.0) + Choose(TipoAbitazione, 0.081, 0.12, 0.1) * (.Partita.SommaAssicurata - 150000D) / 1000D
                    ElseIf .Partita.SommaAssicurata > 100000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 13.5, 20.0, 16.5) + Choose(TipoAbitazione, 0.09, 0.132, 0.111) * (.Partita.SommaAssicurata - 100000D) / 1000D
                    ElseIf .Partita.SommaAssicurata > 50000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 8.5, 12.0, 10.0) + Choose(TipoAbitazione, 0.105, 0.154, 0.129) * (.Partita.SommaAssicurata - 50000D) / 1000D
                    Else
                        .Tariffa.Base = Choose(TipoAbitazione, 0.165, 0.244, 0.205) * (.Partita.SommaAssicurata) / 1000D
                    End If
                ElseIf DanniBeniAbitazioneFormaGaranzia = DanniBeniAbitazioneFormaGaranziaEnum.ValorePRA50 Then
                    .Tariffa.Base = Choose(TipoAbitazione, 28.5, 42.0, 35.5)
                ElseIf DanniBeniAbitazioneFormaGaranzia = DanniBeniAbitazioneFormaGaranziaEnum.ValorePRA100 Then
                    .Tariffa.Base = Choose(TipoAbitazione, 36.5, 54.0, 45.5)
                End If
                If TipologiaCostruzione = TipologiaCostruzioneEnum.Legno Then
                    .Tariffa.Base *= 2
                End If
            End With

            With CoperturaDanniBeniContenuto
                If DanniBeniContenutoFormaGaranzia = DanniBeniContenutoFormaGaranziaEnum.ValoreIntero Then
                    If .Partita.SommaAssicurata > 100000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 10.95, 11.95, 11.45) + Choose(TipoAbitazione, 0.065, 0.07, 0.067) * (.Partita.SommaAssicurata - 100000D) / 1000D
                    ElseIf .Partita.SommaAssicurata > 60000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 6.75, 7.35, 7.05) + Choose(TipoAbitazione, 0.085, 0.092, 0.088) * (.Partita.SommaAssicurata - 60000D) / 1000D
                    ElseIf .Partita.SommaAssicurata > 50000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 5.7, 6.2, 5.95) + Choose(TipoAbitazione, 0.021, 0.023, 0.022) * (.Partita.SommaAssicurata - 50000D) / 1000D
                    ElseIf .Partita.SommaAssicurata > 30000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 5.4, 5.9, 5.65) + Choose(TipoAbitazione, 0.026, 0.029, 0.027) * (.Partita.SommaAssicurata - 30000D) / 1000D
                    ElseIf .Partita.SommaAssicurata > 20000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 5.05, 5.55, 5.3) + Choose(TipoAbitazione, 0.035, 0.038, 0.036) * (.Partita.SommaAssicurata - 20000D) / 1000D
                    ElseIf .Partita.SommaAssicurata > 10000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 4.55, 4.95, 4.75) + Choose(TipoAbitazione, 0.055, 0.059, 0.057) * (.Partita.SommaAssicurata - 10000D) / 1000D
                    Else
                        .Tariffa.Base = Choose(TipoAbitazione, 0.453, 0.494, 0.473) * .Partita.SommaAssicurata / 1000D
                    End If
                ElseIf DanniBeniContenutoFormaGaranzia = DanniBeniContenutoFormaGaranziaEnum.ValorePRA Then
                    If .Partita.SommaAssicurata > 100000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 19.6, 21.4, 20.5)
                    ElseIf .Partita.SommaAssicurata > 60000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 13.15, 14.35, 13.75)
                    ElseIf .Partita.SommaAssicurata > 50000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 8.1, 8.8, 8.45)
                    ElseIf .Partita.SommaAssicurata > 30000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 6.8, 7.45, 7.15)
                    ElseIf .Partita.SommaAssicurata > 20000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 6.5, 7.1, 6.8)
                    ElseIf .Partita.SommaAssicurata > 10000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 6.1, 6.65, 6.35)
                    Else
                        .Tariffa.Base = Choose(TipoAbitazione, 5.45, 5.9, 5.7)
                    End If
                End If
                If TipologiaCostruzione = TipologiaCostruzioneEnum.Legno Then
                    .Tariffa.Base *= 2
                End If
            End With

            With CoperturaDanniBeniGaranziaPlus
                .Tariffa.Base = 0
                'ABITAZIONE
                If DanniBeniAbitazioneFormaGaranzia = DanniBeniAbitazioneFormaGaranziaEnum.ValoreIntero Then
                    If CoperturaDanniBeniAbitazione.SommaAssicurataAttiva > 500000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 8.0, 12.0, 10.0) + Choose(TipoAbitazione, 0.011, 0.017, 0.014) * (CoperturaDanniBeniAbitazione.SommaAssicurataAttiva - 500000D) / 1000D
                    ElseIf CoperturaDanniBeniAbitazione.SommaAssicurataAttiva > 450000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 7.5, 11.0, 9.5) + Choose(TipoAbitazione, 0.012, 0.017, 0.015) * (CoperturaDanniBeniAbitazione.SommaAssicurataAttiva - 450000D) / 1000D
                    ElseIf CoperturaDanniBeniAbitazione.SommaAssicurataAttiva > 400000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 7.0, 10.5, 8.5) + Choose(TipoAbitazione, 0.012, 0.018, 0.015) * (CoperturaDanniBeniAbitazione.SommaAssicurataAttiva - 400000D) / 1000D
                    ElseIf CoperturaDanniBeniAbitazione.SommaAssicurataAttiva > 350000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 6.5, 9.5, 8.0) + Choose(TipoAbitazione, 0.013, 0.019, 0.016) * (CoperturaDanniBeniAbitazione.SommaAssicurataAttiva - 350000D) / 1000D
                    ElseIf CoperturaDanniBeniAbitazione.SommaAssicurataAttiva > 300000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 5.5, 8.5, 7.0) + Choose(TipoAbitazione, 0.013, 0.019, 0.016) * (CoperturaDanniBeniAbitazione.SommaAssicurataAttiva - 300000D) / 1000D
                    ElseIf CoperturaDanniBeniAbitazione.SommaAssicurataAttiva > 250000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 5.0, 7.5, 6.0) + Choose(TipoAbitazione, 0.014, 0.02, 0.017) * (CoperturaDanniBeniAbitazione.SommaAssicurataAttiva - 250000D) / 1000D
                    ElseIf CoperturaDanniBeniAbitazione.SommaAssicurataAttiva > 200000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 4.5, 6.5, 5.5) + Choose(TipoAbitazione, 0.015, 0.022, 0.018) * (CoperturaDanniBeniAbitazione.SommaAssicurataAttiva - 200000D) / 1000D
                    ElseIf CoperturaDanniBeniAbitazione.SommaAssicurataAttiva > 150000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 3.5, 5.0, 4.5) + Choose(TipoAbitazione, 0.016, 0.023, 0.019) * (CoperturaDanniBeniAbitazione.SommaAssicurataAttiva - 150000D) / 1000D
                    ElseIf CoperturaDanniBeniAbitazione.SommaAssicurataAttiva > 100000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 2.5, 4.0, 3.0) + Choose(TipoAbitazione, 0.017, 0.026, 0.022) * (CoperturaDanniBeniAbitazione.SommaAssicurataAttiva - 100000D) / 1000D
                    ElseIf CoperturaDanniBeniAbitazione.SommaAssicurataAttiva > 50000D Then
                        .Tariffa.Base = Choose(TipoAbitazione, 1.5, 2.5, 2.0) + Choose(TipoAbitazione, 0.02, 0.03, 0.025) * (CoperturaDanniBeniAbitazione.SommaAssicurataAttiva - 50000D) / 1000D
                    Else
                        .Tariffa.Base = Choose(TipoAbitazione, 0.032, 0.047, 0.04) * CoperturaDanniBeniAbitazione.SommaAssicurataAttiva / 1000D
                    End If
                ElseIf DanniBeniAbitazioneFormaGaranzia = DanniBeniAbitazioneFormaGaranziaEnum.ValorePRA50 Then
                    .Tariffa.Base = Choose(TipoAbitazione, 5.55, 8.15, 6.85)
                ElseIf DanniBeniAbitazioneFormaGaranzia = DanniBeniAbitazioneFormaGaranziaEnum.ValorePRA100 Then
                    .Tariffa.Base = Choose(TipoAbitazione, 7.1, 10.45, 8.8)
                End If

                'CONTENUTO
                If DanniBeniContenutoFormaGaranzia = DanniBeniContenutoFormaGaranziaEnum.ValoreIntero Then
                    If CoperturaDanniBeniContenuto.SommaAssicurataAttiva > 100000D Then
                        .Tariffa.Base += Choose(TipoAbitazione, 2.15, 2.3, 2.25) + Choose(TipoAbitazione, 0.013, 0.014, 0.013) * (CoperturaDanniBeniContenuto.SommaAssicurataAttiva - 100000D) / 1000D
                    ElseIf CoperturaDanniBeniContenuto.SommaAssicurataAttiva > 60000D Then
                        .Tariffa.Base += Choose(TipoAbitazione, 1.3, 1.45, 1.35) + Choose(TipoAbitazione, 0.016, 0.018, 0.017) * (CoperturaDanniBeniContenuto.SommaAssicurataAttiva - 60000D) / 1000D
                    ElseIf CoperturaDanniBeniContenuto.SommaAssicurataAttiva > 50000D Then
                        .Tariffa.Base += Choose(TipoAbitazione, 1.1, 1.2, 1.15) + Choose(TipoAbitazione, 0.004, 0.004, 0.004) * (CoperturaDanniBeniContenuto.SommaAssicurataAttiva - 50000D) / 1000D
                    ElseIf CoperturaDanniBeniContenuto.SommaAssicurataAttiva > 30000D Then
                        .Tariffa.Base += Choose(TipoAbitazione, 1.05, 1.15, 1.1) + Choose(TipoAbitazione, 0.005, 0.006, 0.005) * (CoperturaDanniBeniContenuto.SommaAssicurataAttiva - 30000D) / 1000D
                    ElseIf CoperturaDanniBeniContenuto.SommaAssicurataAttiva > 20000D Then
                        .Tariffa.Base += Choose(TipoAbitazione, 1.0, 1.05, 1.05) + Choose(TipoAbitazione, 0.007, 0.007, 0.007) * (CoperturaDanniBeniContenuto.SommaAssicurataAttiva - 20000D) / 1000D
                    ElseIf CoperturaDanniBeniContenuto.SommaAssicurataAttiva > 10000D Then
                        .Tariffa.Base += Choose(TipoAbitazione, 0.9, 0.95, 0.92) + Choose(TipoAbitazione, 0.011, 0.012, 0.011) * (CoperturaDanniBeniContenuto.SommaAssicurataAttiva - 10000D) / 1000D
                    Else
                        .Tariffa.Base += Choose(TipoAbitazione, 0.088, 0.096, 0.092) * CoperturaDanniBeniContenuto.SommaAssicurataAttiva / 1000D
                    End If
                ElseIf DanniBeniContenutoFormaGaranzia = DanniBeniContenutoFormaGaranziaEnum.ValorePRA Then
                    If CoperturaDanniBeniContenuto.SommaAssicurataAttiva > 100000D Then
                        .Tariffa.Base += Choose(TipoAbitazione, 3.8, 4.15, 4.0)
                    ElseIf CoperturaDanniBeniContenuto.SommaAssicurataAttiva > 60000D Then
                        .Tariffa.Base += Choose(TipoAbitazione, 2.55, 2.8, 2.65)
                    ElseIf CoperturaDanniBeniContenuto.SommaAssicurataAttiva > 50000D Then
                        .Tariffa.Base += Choose(TipoAbitazione, 1.55, 1.7, 1.65)
                    ElseIf CoperturaDanniBeniContenuto.SommaAssicurataAttiva > 30000D Then
                        .Tariffa.Base += Choose(TipoAbitazione, 1.3, 1.45, 1.4)
                    ElseIf CoperturaDanniBeniContenuto.SommaAssicurataAttiva > 20000D Then
                        .Tariffa.Base += Choose(TipoAbitazione, 1.25, 1.4, 1.3)
                    ElseIf CoperturaDanniBeniContenuto.SommaAssicurataAttiva > 10000D Then
                        .Tariffa.Base += Choose(TipoAbitazione, 1.2, 1.3, 1.25)
                    Else
                        .Tariffa.Base += Choose(TipoAbitazione, 1.05, 1.15, 1.1)
                    End If
                End If

                If TipologiaCostruzione = TipologiaCostruzioneEnum.Legno Then
                    .Tariffa.Base *= 2
                End If
            End With

            With CoperturaDanniBeniFenomeniElettrici
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 250
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 500

                Dim index As Integer = 3 * (TipoAbitazione - 1)
                If CoperturaDanniBeniAbitazione.IsAttivo And CoperturaDanniBeniContenuto.IsAttivo Then
                    index += 3
                ElseIf CoperturaDanniBeniContenuto.IsAttivo Then
                    index += 2
                ElseIf CoperturaDanniBeniAbitazione.IsAttivo Then
                    index += 1
                End If

                If .Garanzia.Massimale = 500 Then
                    .Tariffa.Base = Choose(index, 9, 15, 21, 13, 22, 31, 11, 18, 26)
                ElseIf .Garanzia.Massimale = 1000 Then
                    .Tariffa.Base = Choose(index, 13, 22, 31, 19, 32, 46, 16, 27, 38)
                ElseIf .Garanzia.Massimale = 2000 Then
                    .Tariffa.Base = Choose(index, 18, 32, 45, 27, 47, 67, 23, 40, 56)
                ElseIf .Garanzia.Massimale = 5000 Then
                    .Tariffa.Base = Choose(index, 27, 47, 67, 40, 69, 98, 34, 58, 83)
                ElseIf .Garanzia.Massimale = 10000 Then
                    .Tariffa.Base = Choose(index, 40, 69, 98, 59, 102, 145, 49, 85, 121)
                ElseIf .Garanzia.Massimale = 20000 Then
                    .Tariffa.Base = Choose(index, 58, 101, 143, 86, 149, 212, 72, 125, 178)
                End If
                If .Garanzia.Franchigia = 150 Then
                    .Tariffa.Base *= 1.08
                End If
            End With

            With CoperturaDanniBeniFenomeniElettriciPannelliSolari
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 150
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 10000

                If .Garanzia.Massimale = 10000 Then
                    .Tariffa.Base = 70D
                ElseIf .Garanzia.Massimale = 20000 Then
                    .SetRischioDirezione()
                End If
            End With

            With CoperturaDanniBeniFenomeniAtmosferici
                .Garanzia.Franchigia = 250
                If ClasseTerritorialeEventiAtmosferici = ClasseTerritorialeEventiAtmosfericiEnum.Classe1 Then
                    .Tariffa.Base =
                        CoperturaDanniBeniAbitazione.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.597, 0.782, 0.69) / 1000D +
                        CoperturaDanniBeniContenuto.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.355, 0.46, 0.408) / 1000D
                ElseIf ClasseTerritorialeEventiAtmosferici = ClasseTerritorialeEventiAtmosfericiEnum.Classe2 Then
                    .Tariffa.Base =
                        CoperturaDanniBeniAbitazione.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.332, 0.43, 0.381) / 1000D +
                        CoperturaDanniBeniContenuto.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.204, 0.259, 0.232) / 1000D
                ElseIf ClasseTerritorialeEventiAtmosferici = ClasseTerritorialeEventiAtmosfericiEnum.Classe3 Then
                    .Tariffa.Base =
                        CoperturaDanniBeniAbitazione.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.294, 0.379, 0.337) / 1000D +
                        CoperturaDanniBeniContenuto.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.182, 0.231, 0.206) / 1000D
                End If
            End With

            With CoperturaDanniBeniDanniDaAcqua
                .Garanzia.Franchigia = 250
                If ClasseTerritorialeDanniAcqua = ClasseTerritorialeDanniAcquaEnum.Classe1 Then
                    .Tariffa.Base =
                        CoperturaDanniBeniAbitazione.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.268, 0.238, 0.253) / 1000D +
                        CoperturaDanniBeniContenuto.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.32, 0.284, 0.302) / 1000D
                ElseIf ClasseTerritorialeDanniAcqua = ClasseTerritorialeDanniAcquaEnum.Classe2 Then
                    .Tariffa.Base =
                        CoperturaDanniBeniAbitazione.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.137, 0.121, 0.129) / 1000D +
                        CoperturaDanniBeniContenuto.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.163, 0.145, 0.154) / 1000D
                ElseIf ClasseTerritorialeDanniAcqua = ClasseTerritorialeDanniAcquaEnum.Classe3 Then
                    .Tariffa.Base =
                        CoperturaDanniBeniAbitazione.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.098, 0.087, 0.092) / 1000D +
                        CoperturaDanniBeniContenuto.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.117, 0.103, 0.11) / 1000D
                End If
            End With

            With CoperturaDanniBeniRicercaGuasto
                If ClasseTerritorialeDanniAcqua = ClasseTerritorialeDanniAcquaEnum.Classe1 Then
                    .Tariffa.Base =
                        CoperturaDanniBeniAbitazione.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.196, 0.165, 0.18) / 1000D
                ElseIf ClasseTerritorialeDanniAcqua = ClasseTerritorialeDanniAcquaEnum.Classe2 Then
                    .Tariffa.Base =
                        CoperturaDanniBeniAbitazione.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.139, 0.119, 0.129) / 1000D
                ElseIf ClasseTerritorialeDanniAcqua = ClasseTerritorialeDanniAcquaEnum.Classe3 Then
                    .Tariffa.Base =
                        CoperturaDanniBeniAbitazione.SommaAssicurataAttiva * Choose(TipoAbitazione, 0.102, 0.087, 0.095) / 1000D
                End If
            End With

            With CoperturaDanniBeniPerditeOcculte
                .Tariffa.Base = 30D
            End With

            With CoperturaDanniBeniVetriCristalli
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 500
                If .Garanzia.Massimale = 500 Then
                    .Tariffa.Base = Choose(TipoAbitazione, 4, 6, 5)
                ElseIf .Garanzia.Massimale = 1000 Then
                    .Tariffa.Base = Choose(TipoAbitazione, 7, 10, 9)
                ElseIf .Garanzia.Massimale = 2000 Then
                    .Tariffa.Base = Choose(TipoAbitazione, 12, 17, 14)
                ElseIf .Garanzia.Massimale = 5000 Then
                    .Tariffa.Base = Choose(TipoAbitazione, 20, 27, 23)
                ElseIf .Garanzia.Massimale = 10000 Then
                    .Tariffa.Base = Choose(TipoAbitazione, 32, 45, 39)
                End If
            End With


        End Sub

        Public Sub ValidaSezioneCatastrofali()
            CoperturaCatastrofali.DipendeDa(CoperturaDanniBeni.IsAttivo)
            If Not CoperturaCatastrofali.Sezione.IsAttivo Then
                CoperturaCatastrofali.Sezione.Stato = CoperturaCatastrofali.Stato
            End If

            CoperturaCatastrofaliTerremotoAbitazione.DipendeDa(CoperturaCatastrofali.IsAttivo And CoperturaDanniBeniAbitazione.IsAttivo)
            CoperturaCatastrofaliTerremotoContenuto.DipendeDa(CoperturaCatastrofaliTerremotoAbitazione.IsAttivo And CoperturaDanniBeniContenuto.IsAttivo)

            CoperturaCatastrofaliAlluvioneAbitazione.DipendeDa(CoperturaCatastrofali.IsAttivo And CoperturaDanniBeniAbitazione.IsAttivo)
            CoperturaCatastrofaliAlluvioneContenuto.DipendeDa(CoperturaCatastrofaliAlluvioneAbitazione.IsAttivo And CoperturaDanniBeniContenuto.IsAttivo)

            With CoperturaCatastrofaliTerremotoAbitazione
                If .Garanzia.Combinazione = 0 Then .Garanzia.Combinazione = 70
                .Garanzia.CombinazioneStampa = Decode.DecodeCatastrofaliTerremotoAbitazionecombinazione(.Garanzia.Combinazione)

                If TipologiaCostruzione = TipologiaCostruzioneEnum.Legno Then
                    .SetRischioDirezione()
                Else
                    .Tariffa.Base = 0
                    .Tariffa.Tasso = UnipolSaiCasaServizi.TariffaTerremoto.getTassoTerremotoFabbricato(Comune, .Garanzia.Combinazione, Antisismico, TipologiaCostruzione)
                End If
                If DanniBeniAbitazioneFormaGaranzia <> DanniBeniAbitazioneFormaGaranziaEnum.ValoreIntero Then
                    .Tariffa.Tasso *= 1.8
                End If
                If .PremioCrudo < 20 Then
                    .Tariffa.Base = 20
                    .Tariffa.Tasso = 0
                End If

            End With

            With CoperturaCatastrofaliTerremotoContenuto
                If TipologiaCostruzione = TipologiaCostruzioneEnum.Legno Then
                    .SetRischioDirezione()
                Else
                    '.Garanzia.CombinazioneStampa = Decode.DecodeCatastrofaliTerremotoAbitazionecombinazione(.Garanzia.Combinazione)
                    .Tariffa.Base = 0
                    .Tariffa.Tasso = UnipolSaiCasaServizi.TariffaTerremoto.getTassoTerremotoContenuto(Comune, .Garanzia.Combinazione, Antisismico, TipologiaCostruzione)
                End If
                If DanniBeniContenutoFormaGaranzia = DanniBeniContenutoFormaGaranziaEnum.ValorePRA Then
                    .Tariffa.Tasso *= 1.8
                End If
                If .PremioCrudo < 10 Then
                    .Tariffa.Base = 10
                    .Tariffa.Tasso = 0
                End If
            End With

            With CoperturaCatastrofaliAlluvioneAbitazione
                If .Garanzia.Combinazione = 0 Then .Garanzia.Combinazione = 4
                .Tariffa.Tasso = UnipolSaiCasaServizi.TariffaAlluvione.getTassoAlluvione(Luogo.Province(Provincia).Sigla, TipoAbitazione, .Garanzia.Combinazione)
                '18/04/17: contrariamente al tariffino, per essig la tariffa per primo rischio assoluto non cambia
                'If DanniBeniAbitazioneFormaGaranzia <> DanniBeniAbitazioneFormaGaranziaEnum.ValoreIntero Then
                '    .Tariffa.Tasso *= 1.8
                'End If
            End With

            With CoperturaCatastrofaliAlluvioneContenuto
                .Tariffa.Tasso = CoperturaCatastrofaliAlluvioneAbitazione.Tariffa.Tasso
                'If DanniBeniContenutoFormaGaranzia = DanniBeniContenutoFormaGaranziaEnum.ValorePRA Then
                '    .Tariffa.Tasso *= 1.8
                'End If
            End With

        End Sub

        Public Sub ValidaSezioneAssistenzaPlus()
            CoperturaAssistenzaPlus.DipendeDa(CoperturaDanniBeni.IsAttivo)
            If Not CoperturaAssistenzaPlus.Sezione.IsAttivo Then
                CoperturaAssistenzaPlus.Sezione.Stato = CoperturaAssistenzaPlus.Stato
            End If

            CoperturaAssistenzaPlusBase.Stato = CoperturaAssistenzaPlus.Stato

            If CoperturaAssistenzaPlusBase.IsAttivo Then
                If UnipolSaiCasaServizi.CoperturaDanniTerziBeB.IsAttivo Then
                    CoperturaAssistenzaPlusBase.SetNonDisponibile("Garanzia Bed&breakfast e affittacamere non compatibile con assistenza plus")
                ElseIf UnipolSaiCasaServizi.CoperturaDanniTerziLocazione.IsAttivo Then
                    CoperturaAssistenzaPlusBase.SetNonDisponibile("Garanzia Abitazione locata a terzi non compatibile con assistenza plus")
                End If
            End If

            With CoperturaAssistenzaPlusBase
                If AssistenzaPlus = 0 Then
                    AssistenzaPlus = AssistenzaPlusEnum.Easy
                End If

                If AssistenzaPlus = AssistenzaPlusEnum.Easy Then
                    .Tariffa.Base = 96D
                ElseIf AssistenzaPlus = AssistenzaPlusEnum.Full Then
                    .Tariffa.Base = 144D
                ElseIf AssistenzaPlus = AssistenzaPlusEnum.Top Then
                    .Tariffa.Base = 192D
                End If
            End With
        End Sub

        Public Sub ValidaSezioneProtezioneEmergenza()
            CoperturaProtezioneEmergenza.DipendeDa(CoperturaDanniBeni.IsAttivo And CoperturaCatastrofali.IsAttivo And UnipolSaiCasaServizi.TipoContraenza = TipoContraenzaEnum.PersonaFisica)

            If Not CoperturaProtezioneEmergenza.Sezione.IsAttivo Then
                CoperturaProtezioneEmergenza.Sezione.Stato = CoperturaProtezioneEmergenza.Stato
            End If

            CoperturaProtezioneEmergenzaBase.Stato = CoperturaProtezioneEmergenza.Stato

            With CoperturaProtezioneEmergenzaBase
                .Tariffa.Base = 21D
            End With
        End Sub


        Public Sub ValidaSezioneFurto()
            CoperturaFurto.DipendeDa(IsParamsCompleted())
            If Not CoperturaFurto.Sezione.IsAttivo Then
                CoperturaFurto.Sezione.Stato = CoperturaFurto.Stato
            End If

            CoperturaDanniFurtoContenuto.DipendeDa(CoperturaFurto.IsAttivo)
            CoperturaDanniFurtoGaranziaPlus.DipendeDa(CoperturaDanniFurtoContenuto.IsAttivo)
            CoperturaDanniFurtoValoriNonCustoditi.DipendeDa(CoperturaDanniFurtoContenuto.IsAttivo)
            CoperturaDanniFurtoValoriCustoditi.DipendeDa(CoperturaDanniFurtoContenuto.IsAttivo)
            CoperturaDanniFurtoSocioPolitico.DipendeDa(CoperturaDanniFurtoContenuto.IsAttivo)
            CoperturaDanniFurtoPannelli.DipendeDa(CoperturaDanniFurtoContenuto.IsAttivo And CoperturaDanniBeniAbitazione.IsAttivo)
            CoperturaDanniFurtoEsterno.DipendeDa(CoperturaDanniFurtoContenuto.IsAttivo)
            CoperturaDanniFurtoImpiantoAllarme.DipendeDa(CoperturaDanniFurtoContenuto.IsAttivo)

            PartitaDanniFurtoContenuto.LimiteAssuntivoMinimo(3000)
            If TipologiaCostruzione = TipologiaCostruzioneEnum.Legno Then
                PartitaDanniFurtoContenuto.LimiteAssuntivoMassimo(Choose(TipoDimora, 25000D, 10000D, 10000D))
            Else
                PartitaDanniFurtoContenuto.LimiteAssuntivoMassimo(Choose(TipoDimora, 100000D, 25000D, 25000D))
            End If
            PartitaDanniFurtoEsterno.LimiteAssuntivoMassimo(20000D)

            If TipologiaCostruzione = TipologiaCostruzioneEnum.Legno Then
                PartitaDanniFurtoValoriNonCustoditi.LimiteAssuntivoMassimo(5000D)
                PartitaDanniFurtoValoriCustoditi.LimiteAssuntivoMassimo(5000D)
            ElseIf TipoDimora = TipoDimoraEnum.Abituale Then
                PartitaDanniFurtoValoriNonCustoditi.LimiteAssuntivoMassimo(50000D)
                PartitaDanniFurtoValoriCustoditi.LimiteAssuntivoMassimo(60000D)
            ElseIf TipoDimora = TipoDimoraEnum.NonAbituale Then
                PartitaDanniFurtoValoriNonCustoditi.LimiteAssuntivoMassimo(10000D)
                PartitaDanniFurtoValoriCustoditi.LimiteAssuntivoMassimo(40000D)
            End If
            PartitaDanniFurtoPannelli.SommaAssicurata = 15000D

            PartitaDanniFurtoSocioPolitico.LimiteAssuntivoMassimo(0D)

            Dim indice As Integer = IIf(TipoDimora = TipoDimoraEnum.Abituale, 0, 3) + TipoAbitazione



            With CoperturaDanniFurtoContenuto
                If ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe1 Then
                    .Tariffa.TassoX1000 = Choose(indice, 17.703, 26.001, 21.852, 18.803, 27.617, 23.21)
                ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe2 Then
                    .Tariffa.TassoX1000 = Choose(indice, 12.912, 18.964, 15.938, 13.715, 20.143, 16.929)
                ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe3 Then
                    .Tariffa.TassoX1000 = Choose(indice, 9.421, 13.837, 11.629, 10.006, 14.697, 12.352)
                End If
                If TipologiaCostruzione = TipologiaCostruzioneEnum.Legno Then
                    .Tariffa.Tasso *= 2
                End If

            End With

            With CoperturaDanniFurtoGaranziaPlus
                If ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe1 Then
                    .Tariffa.TassoX1000 = Choose(indice, 1.13, 1.66, 1.395, 1.2, 1.763, 1.482)
                ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe2 Then
                    .Tariffa.TassoX1000 = Choose(indice, 0.824, 1.21, 1.017, 0.875, 1.286, 1.081)
                ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe3 Then
                    .Tariffa.TassoX1000 = Choose(indice, 0.601, 0.883, 0.742, 0.639, 0.938, 0.788)
                End If
                If TipologiaCostruzione = TipologiaCostruzioneEnum.Legno Then
                    .Tariffa.Tasso *= 2
                End If
            End With

            With CoperturaDanniFurtoValoriNonCustoditi
                If ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe1 Then
                    .Tariffa.TassoX1000 = Choose(24.836, 44.873, 34.854, 26.38, 47.663, 37.021)
                ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe2 Then
                    .Tariffa.TassoX1000 = Choose(indice, 14.657, 26.483, 20.57, 15.569, 28.13, 21.849)
                ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe3 Then
                    .Tariffa.TassoX1000 = Choose(indice, 11.345, 20.498, 15.921, 12.05, 21.772, 16.911)
                End If
            End With

            With CoperturaDanniFurtoValoriCustoditi
                .Tariffa.TassoX1000 = Choose(indice, 7.255, 11.923, 9.589, 7.706, 12.664, 10.185)
            End With

            With CoperturaDanniFurtoSocioPolitico
                .Tariffa.Base = 25D
            End With

            With CoperturaDanniFurtoPannelli
                .Tariffa.Base = 64D
            End With

            With CoperturaDanniFurtoEsterno
                If ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe1 Then
                    .Tariffa.TassoX1000 = 21.773
                ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe2 Then
                    .Tariffa.TassoX1000 = 15.88
                ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe3 Then
                    .Tariffa.TassoX1000 = 11.587
                End If
            End With

            With CoperturaDanniFurtoImpiantoAllarme
                .Tariffa.Tasso = -0.1D
                .Partita.SommaAssicurata = CoperturaDanniFurtoContenuto.PremioAttivoCrudo _
                                         + CoperturaDanniFurtoGaranziaPlus.PremioAttivoCrudo _
                                         + CoperturaDanniFurtoValoriCustoditi.PremioAttivoCrudo _
                                         + CoperturaDanniFurtoValoriNonCustoditi.PremioAttivoCrudo _
                                         + CoperturaDanniFurtoSocioPolitico.PremioAttivoCrudo _
                                         + CoperturaDanniFurtoPannelli.PremioAttivoCrudo
            End With


        End Sub

        Public Function Decode() As P07263DE
            Return CType(UnipolSaiCasaServizi.Decode, P07263DE)
        End Function

        'ESSIG
        Public Function GetComune() As Comune
            Return Luogo.Comuni.Find(Function(c As Comune) c.CodiceIstat = Comune)
        End Function

        Public Function NumeroBene() As Integer
            Return 1 + UnipolSaiCasaServizi.Abitazioni.IndexOf(Me)
        End Function

        Public Function HiddenNumeroOggetto() As Integer
            Return 1 + NumeroBene()
        End Function

        Public Function garanziaPlusAbitazioneCheck() As String
            If CoperturaDanniBeniGaranziaPlus.IsAttivo And CoperturaDanniBeniAbitazione.IsAttivo Then
                Return "1"
            Else
                Return "0"
            End If
        End Function
        Public Function garanziaPlusContenutoCheck() As String
            If CoperturaDanniBeniGaranziaPlus.IsAttivo And CoperturaDanniBeniContenuto.IsAttivo Then
                Return "1"
            Else
                Return "0"
            End If
        End Function
        Public Function AssistenzaPlus_value() As String
            If CoperturaAssistenzaPlus.IsAttivo Then
                Return AssistenzaPlus
            Else
                Return ""
            End If
        End Function
    End Class
End Namespace
