Namespace P07261
    Public Class P07261DE
        Inherits P00000DE

        Public DecodeTipoContraenza As New Dizionario(Of Integer, String)
        Public DecodeFormaAssicurazione As New Dizionario(Of Integer, String)
        Public DecodeTipoAbitazione As New Dizionario(Of Integer, String)
        Public DecodeTipoDimora As New Dizionario(Of Integer, String)
        Public DecodePianoAbitazione As New Dizionario(Of Integer, String)
        Public DecodeClasseTerritorialeFurto As New Dizionario(Of Integer, String)
        Public DecodeZonaTerritorialeEventiAtmosferici As New Dizionario(Of Integer, String)
        Public DecodeZonaTerritorialeSalvaBenessere As New Dizionario(Of Integer, String)
        Public DecodeIncendioChiave As New Dizionario(Of Integer, String)
        Public DecodeIncendioAbitazioneFormAss As New Dizionario(Of Integer, String)
        Public DecodeIncendioContenutoFormAss As New Dizionario(Of Integer, String)
        Public DecodeIncendioLocazioneFormAss As New Dizionario(Of Integer, String)
        Public DecodeCaratteristicaCostruttiva As New Dizionario(Of Integer, String)
        Public DecodeFurtoChiave As New Dizionario(Of Integer, String)
        Public DecodeFurtoContenutoFormAss As New Dizionario(Of Integer, String)
        Public DecodeFurtoEsternoScelta As New Dizionario(Of Integer, String)
        Public DecodeFurtoEsternoPlatinoScelta As New Dizionario(Of Integer, String)
        Public DecodeFurtoInCassaforteScelta As New Dizionario(Of Integer, String)
        Public DecodeFurtoPreziosiValoriScelta As New Dizionario(Of Integer, String)
        Public DecodeFurtoValoriDimoraAbitualeDenaro As New Dizionario(Of Integer, String)
        Public DecodeFurtoValoriDimoraAbitualeValori As New Dizionario(Of Integer, String)
        Public DecodeRCChiave As New Dizionario(Of Integer, String)
        Public DecodeSalvaBenessereEta As New Dizionario(Of Integer, String)
        Public DecodeTutelaLegaleChiave As New Dizionario(Of Integer, String)
        Public DecodeProvincia As New Dizionario(Of ProvinciaEnum, String)
        Public DecodeRegione As New Dizionario(Of RegioneEnum, String)
        Public DecodeIncendioConduttureFranchigia As New Dizionario(Of Decimal, String)
        Public DecodeIncendioFenomeniElettriciFranchigia As New Dizionario(Of Decimal, String)
        Public DecodeIncendioFenomeniAtmosfericiLimite As New Dizionario(Of Decimal, String)
        Public DecodeIncendioFenomeniAtmosfericiCombinazione As New Dizionario(Of Decimal, String)
        Public DecodeIncendioFenomeniAtmosfericiLargeCombinazione As New Dizionario(Of Decimal, String)
        Public DecodeIncendioFenomeniAtmosfericiLargeMassimale As New Dizionario(Of Decimal, String)
        Public DecodeIncendioDemolizioneMassimale As New Dizionario(Of Decimal, String)
        Public DecodeIncendioGeloMassimale As New Dizionario(Of Decimal, String)
        Public DecodeIncendioGeloFranchigia As New Dizionario(Of Decimal, String)
        Public DecodeIncendioRicercaGuastoMassimale As New Dizionario(Of Decimal, String)
        Public DecodeIncendioRicercaGuastoFranchigia As New Dizionario(Of Decimal, String)
        Public DecodeIncendioAcquaOcclusioneMassimale As New Dizionario(Of Decimal, String)
        Public DecodeIncendioAcquaOcclusioneFranchigia As New Dizionario(Of Decimal, String)
        Public DecodeIncendioPannelliSolariMassimale As New Dizionario(Of Decimal, String)
        Public DecodeIncendioPannelliSolariFranchigia As New Dizionario(Of Decimal, String)
        Public DecodeTerremotoFabbricatoLimite As New Dizionario(Of Decimal, String)
        Public DecodeFurtoEsternoLimite As New Dizionario(Of Decimal, String)
        Public DecodeFurtoEsternoMassimale As New Dizionario(Of Decimal, String)
        Public DecodeFurtoPannelliSolariMassimale As New Dizionario(Of Decimal, String)
        Public DecodeFurtoFranchigiaFranchigia As New Dizionario(Of Decimal, String)
        Public DecodeResponsabilitaCivileBaseMassimale As New Dizionario(Of Decimal, String)
        Public DecodeSalvaBenessereBaseMassimale As New Dizionario(Of Decimal, String)
        Public DecodeTutelaLegaleBaseMassimale As New Dizionario(Of Decimal, String)
        Public DecodeRegioneToZonaTerritorialeSalvaBenessere As New Dizionario(Of Integer, Integer)
        Public DecodeProvinciaToClasseTerritorialeFurto As New Dizionario(Of Integer, Integer)
        Public DecodeProvinciaToEventiAtmosferici As New Dizionario(Of Integer, Integer)

        Sub New()
            With DecodeSezione
                .Add(TipoSezione.Incendio, "Incendio")
                .Add(TipoSezione.Terremoto, "Rischio Terremoto")
                .Add(TipoSezione.Furto, "Furto e rapina")
                .Add(TipoSezione.ResponsabilitaCivile, "Responsabilità Civile")
                .Add(TipoSezione.SalvaBenessere, "Salva Benessere")
                .Add(TipoSezione.TutelaLegale, "Tutela Legale")
                .Add(TipoSezione.Assistenza, "Assistenza")
            End With

            With DecodePartita
                .Add(TipoPartita.Incendio, "Incendio")
                .Add(TipoPartita.Terremoto, "Rischio Terremoto")
                .Add(TipoPartita.Furto, "Furto e rapina")
                .Add(TipoPartita.ResponsabilitaCivile, "Responsabilità Civile")
                .Add(TipoPartita.SalvaBenessere, "Salva Benessere")
                .Add(TipoPartita.TutelaLegale, "Tutela Legale")
                .Add(TipoPartita.Assistenza, "Assistenza")
            End With

            With DecodeGaranzia
                .Add(TipoGaranzia.IncendioBase, "Garanzia base")
                .Add(TipoGaranzia.IncendioAbitazione, "Abitazione")
                .Add(TipoGaranzia.IncendioContenuto, "Contenuto")
                .Add(TipoGaranzia.IncendioLocazione, "Rischio locativo")
                .Add(TipoGaranzia.IncendioAcquaCondotta, "Acqua condotta")
                .Add(TipoGaranzia.IncendioFenomeniElettrici, "Fenomeni elettrici")
                .Add(TipoGaranzia.IncendioFenomeniAtmosferici, "Fenomeni Atmosferici")
                .Add(TipoGaranzia.IncendioFenomeniAtmosfericiLarge, "Fenomeni Atmosferici LARGE")
                .Add(TipoGaranzia.IncendioRicorsoTerzi, "Ricorso terzi")
                .Add(TipoGaranzia.IncendioDemolizione, "Spese di demolizione, sgombero, trasporto, ecc.") 'rimozione e ricollocamento
                .Add(TipoGaranzia.IncendioGelo, "Gelo")
                .Add(TipoGaranzia.IncendioRicercaGuasto, "Ricerca Guasto")
                .Add(TipoGaranzia.IncendioAcquaOcclusione, "Acqua piovana")
                .Add(TipoGaranzia.IncendioPannelliSolari, "Pannelli fotovoltaici")
                .Add(TipoGaranzia.IncendioRiduzioneFranchigiaFenomeniElettrici, "Riduzione Franchigia Fenomeni Elettrici")
                .Add(TipoGaranzia.TerremotoBase, "Garanzia base")
                .Add(TipoGaranzia.TerremotoFabbricato, "Terremoto fabbricato")
                .Add(TipoGaranzia.TerremotoContenuto, "Terremoto contenuto")
                .Add(TipoGaranzia.FurtoBase, "Garanzia base")
                .Add(TipoGaranzia.FurtoContenuto, "Contenuto")
                .Add(TipoGaranzia.FurtoEsterno, "Rischi esterni all’abitazione - Oro")
                .Add(TipoGaranzia.FurtoEsternoPlatino, "Rischi esterni all’abitazione - Platino")
                .Add(TipoGaranzia.FurtoInCassaforte, "Preziosi e valori in cassaforte")
                .Add(TipoGaranzia.FurtoPreziosiValori, "Preziosi e valori ovunque riposti")
                .Add(TipoGaranzia.FurtoValoriDimoraAbituale, "Preziosi e valori Dimora abituale")
                .Add(TipoGaranzia.FurtoValoriDimoraSaltuaria, "Preziosi e valori Dimora saltuaria")
                .Add(TipoGaranzia.FurtoPannelliSolari, "Pannelli solari")
                .Add(TipoGaranzia.FurtoMezziChiusura, "Mezzi di Chiusura Particolari")
                .Add(TipoGaranzia.FurtoImpiantoAllarme, "Impianto di allarme")
                .Add(TipoGaranzia.FurtoFranchigia, "Franchigia")
                .Add(TipoGaranzia.ResponsabilitaCivileBase, "Responsabilita Civile")
                .Add(TipoGaranzia.RCVitaPrivata, "Vita Privata")
                .Add(TipoGaranzia.RCFabbricati, "Fabbricati")
                .Add(TipoGaranzia.RCVitaPrivataFabbricati, "VitaPrivata + Fabbricati")
                .Add(TipoGaranzia.SalvaBenessereBase, "Salva Benessere")
                .Add(TipoGaranzia.TutelaLegaleBase, "Tutela Legale")
                .Add(TipoGaranzia.AssistenzaBase, "Assistenza")
                .Add(TipoGaranzia.IncendioEstensioneGaranziaBase, "Estensione Garanzia Base Incendio")
                .Add(TipoGaranzia.IncendioPannelliSolariEstensioneFenomenoElettrico, "Estensione fenomeni elettrici su impianti solari")
                .Add(TipoGaranzia.IncendioPannelliSolariEstensioneFenomenoAtmosferici, "Estensione fenomeni atmosferici su impianti solari")
                .Add(TipoGaranzia.IncendioPerditeOcculteAcqua, "Perdite occulte d'acqua")
                .Add(TipoGaranzia.FurtoEstensioneGaranziaBase, "Estensione Garanzia Base Furto")
                .Add(TipoGaranzia.RCEstensioneGaranziaBase, "Estensione Responsabilità Civile verso Terzi")
            End With

            With DecodeFrazionamenti
                .Add(FrazionamentiEnum.Temporaneo, "temporaneo")
                .Add(FrazionamentiEnum.Annuale, "annuale")
                .Add(FrazionamentiEnum.Semestrale, "semestrale")
                .Add(FrazionamentiEnum.Quadrimestrale, "quadrimestrale")
                .Add(FrazionamentiEnum.Trimestrale, "trimestrale")
                .Add(FrazionamentiEnum.Mensile, "mensile")
                .Add(FrazionamentiEnum.UnicoAnticipato, "unico anticipato")
            End With

            With DecodeTipoContraenza
                .Add(TipoContraenzaEnum.PersonaFisica, "Persona fisica")
                .Add(TipoContraenzaEnum.PersonaGiudirica, "Persona giudirica")
            End With

            With DecodeFormaAssicurazione
                .Add(FormaAssicurazioneEnum.ValoreInteroNuovo, "Valore intero e a nuovo")
                .Add(FormaAssicurazioneEnum.ValoreInteroCommerciale, "Valore intero e commerciale")
                .Add(FormaAssicurazioneEnum.valorePrimoRischioNuovo, "Valore primo rischio e a nuovo")
                .Add(FormaAssicurazioneEnum.valorePrimoRischioCommerciale, "Valore primo rischio e commerciale")
            End With

            With DecodeTipoAbitazione
                .Add(TipoAbitazioneEnum.Appartamento, "Appartamento")
                .Add(TipoAbitazioneEnum.VillaSingola, "Villa singola")
                .Add(TipoAbitazioneEnum.VillaSchiera, "Villa a schiera")
                '.Add(TipoAbitazioneEnum.DimoraSaltuaria, "Dimora saltuaria")
            End With

            With DecodePianoAbitazione
                .Add(PianoAbitazioneEnum.Sotterraneo, "Sotterraneo")
                .Add(PianoAbitazioneEnum.Interrato, "Interrato")
                .Add(PianoAbitazioneEnum.PianoTerra, "Piano terra")
                .Add(PianoAbitazioneEnum.PianoRialzato, "Piano rialzato")
                .Add(PianoAbitazioneEnum.PianoAlto, "Primo piano e altri")
                .Add(PianoAbitazioneEnum.InteroFabbricato, "Intero fabbricato")
            End With

            With DecodeTipoDimora
                .Add(TipoDimoraEnum.DimoraAbituale, "Abituale")
                .Add(TipoDimoraEnum.DimoraSaltuaria, "Saltuaria")
            End With

            With DecodeClasseTerritorialeFurto
                .Add(ClasseTerritorialeFurtoEnum.Classe1, "1")
                .Add(ClasseTerritorialeFurtoEnum.Classe2, "2")
                .Add(ClasseTerritorialeFurtoEnum.Classe3, "3")
                .Add(ClasseTerritorialeFurtoEnum.Classe4, "4")
            End With

            With DecodeZonaTerritorialeEventiAtmosferici
                .Add(ZonaTerritorialeEventiAtmosfericiEnum.ZonaA, "Zona A")
                .Add(ZonaTerritorialeEventiAtmosfericiEnum.ZonaB, "Zona B")
                .Add(ZonaTerritorialeEventiAtmosfericiEnum.ZonaC, "Zona C")
            End With

            With DecodeZonaTerritorialeSalvaBenessere
                .Add(ZonaTerritorialeSalvaBenessereEnum.Zona1, "Zona1")
                .Add(ZonaTerritorialeSalvaBenessereEnum.Zona2, "Zona2")
                .Add(ZonaTerritorialeSalvaBenessereEnum.Zona3, "Zona3")
            End With

            With DecodeIncendioChiave
                .Add(IncendioChiaveEnum.ChiaveARGENTO, "Chiave ARGENTO")
                .Add(IncendioChiaveEnum.ChiaveORO, "Chiave ORO")
                .Add(IncendioChiaveEnum.ChiavePLATINO, "Chiave PLATINO")
            End With

            With DecodeIncendioAbitazioneFormAss
                .Add(IncendioAbitazioneFormAssEnum.ValoreInteroNuovo, "Valore intero e a nuovo")
                .Add(IncendioAbitazioneFormAssEnum.ValoreInteroCommerciale, "Valore intero e commerciale")
            End With

            With DecodeIncendioContenutoFormAss
                .Add(IncendioContenutoFormAssEnum.ValoreInteroNuovo, "Valore intero e a nuovo")
                .Add(IncendioContenutoFormAssEnum.ValoreInteroCommerciale, "Valore intero e commerciale")
                .Add(IncendioContenutoFormAssEnum.ValorePrimoRischioNuovo, "Valore primo rischio e a nuovo")
                .Add(IncendioContenutoFormAssEnum.ValorePrimoRischioCommerciale, "Valore primo rischio e commerciale")
            End With

            With DecodeIncendioLocazioneFormAss
                .Add(IncendioLocazioneFormAssEnum.ValoreInteroNuovo, "Valore intero e a nuovo")
                .Add(IncendioLocazioneFormAssEnum.ValoreInteroCommerciale, "Valore intero e commerciale")
                .Add(IncendioLocazioneFormAssEnum.ValorePrimoRischioNuovo, "Valore primo rischio e a nuovo")
                .Add(IncendioLocazioneFormAssEnum.valorePrimoRischioCommerciale, "Valore primo rischio e commerciale")
            End With

            With DecodeCaratteristicaCostruttiva
                .Add(CaratteristicaCostruttivaEnum.Muratura, "Muratura")
                .Add(CaratteristicaCostruttivaEnum.Tradizionale, "Tradizionale")
                .Add(CaratteristicaCostruttivaEnum.Antisismica, "Antisismica")
            End With

            With DecodeFurtoChiave
                .Add(FurtoChiaveEnum.ChiaveORO, "Chiave ORO")
                .Add(FurtoChiaveEnum.ChiavePLATINO, "Chiave PLATINO")
            End With

            With DecodeFurtoContenutoFormAss
                .Add(IncendioContenutoFormAssEnum.ValorePrimoRischioNuovo, "Valore primo rischio e a nuovo")
                .Add(IncendioContenutoFormAssEnum.ValorePrimoRischioCommerciale, "Valore primo rischio e commerciale")
            End With

            With DecodeFurtoEsternoScelta
                .Add(FurtoEsternoSceltaEnum.SceltaMEDIUM, "Scelta MEDIUM")
                .Add(FurtoEsternoSceltaEnum.SceltaLARGE, "Scelta LARGE")
            End With

            With DecodeFurtoEsternoPlatinoScelta
                .Add(FurtoEsternoPlatinoSceltaEnum.SceltaA, "SCELTA A")
                .Add(FurtoEsternoPlatinoSceltaEnum.SceltaB, "SCELTA B")
            End With

            With DecodeFurtoInCassaforteScelta
                .Add(FurtoInCassaforteSceltaEnum.SceltaA, "SCELTA A")
                .Add(FurtoInCassaforteSceltaEnum.SceltaB, "SCELTA B")
            End With

            With DecodeFurtoPreziosiValoriScelta
                .Add(FurtoPreziosiValoriSceltaEnum.SceltaA, "SCELTA A")
                .Add(FurtoPreziosiValoriSceltaEnum.SceltaB, "SCELTA B")
            End With

            With DecodeFurtoValoriDimoraAbitualeDenaro
                .Add(FurtoValoriDimoraAbitualeDenaroEnum.Scelta05, "Denaro 5% della s.a.")
                .Add(FurtoValoriDimoraAbitualeDenaroEnum.Scelta10, "Denaro 10% della s.a.")
            End With

            With DecodeFurtoValoriDimoraAbitualeValori
                .Add(FurtoValoriDimoraAbitualeValoriEnum.Scelta40, "Preziosi e valori 40% della s.a.")
                .Add(FurtoValoriDimoraAbitualeValoriEnum.Scelta50, "Preziosi e valori 50% della s.a.")
            End With

            With DecodeRCChiave
                .Add(RCChiaveEnum.ChiaveARGENTO, "Chiave ARGENTO")
                .Add(RCChiaveEnum.ChiaveORO, "Chiave ORO")
                .Add(RCChiaveEnum.ChiavePLATINO, "Chiave PLATINO")
            End With

            With DecodeSalvaBenessereEta
                .Add(SalvaBenessereEtaEnum.Fascia0024, "Età fino a 24")
                .Add(SalvaBenessereEtaEnum.Fascia2534, "Età 25 - 34")
                .Add(SalvaBenessereEtaEnum.Fascia3545, "Età 35 - 45")
                .Add(SalvaBenessereEtaEnum.Fascia4660, "Età 46 - 60")
                .Add(SalvaBenessereEtaEnum.Fascia6165, "Età 61 - 65")
                .Add(SalvaBenessereEtaEnum.Fascia6669, "Età 66 - 69")
                .Add(SalvaBenessereEtaEnum.Fascia7000, "Età oltre 70")
            End With

            With DecodeTutelaLegaleChiave
                .Add(TutelaLegaleChiaveEnum.ChiaveARGENTO, "Chiave ARGENTO")
                .Add(TutelaLegaleChiaveEnum.ChiaveORO, "Chiave ORO")
                .Add(TutelaLegaleChiaveEnum.ChiavePLATINO, "Chiave PLATINO")
            End With
            With DecodeIncendioConduttureFranchigia
                .Add(150, "Franchigia € 150,00")
                .Add(200, "Franchigia € 200,00")
                .Add(300, "Franchigia € 300,00")
            End With
            With DecodeIncendioFenomeniElettriciFranchigia
                .Add(150, "Franchigia € 150,00")
                .Add(200, "Franchigia € 200,00")
                .Add(300, "Franchigia € 300,00")
            End With
            With DecodeIncendioFenomeniAtmosfericiLimite
                .Add(50, "Limite 50%")
                .Add(75, "Limite 75%")
            End With
            With DecodeIncendioFenomeniAtmosfericiCombinazione
                .Add(25000, "Scoperto 0% - Franchigia € 250,00")
                .Add(50000, "Scoperto 0% - Franchigia € 500,00")
                .Add(25010, "Scoperto 10% - Franchigia € 250,00")
            End With
            With DecodeIncendioFenomeniAtmosfericiLargeCombinazione
                .Add(25000, "Scoperto 0% - Franchigia € 250,00")
                .Add(50000, "Scoperto 0% - Franchigia € 500,00")
                .Add(25010, "Scoperto 10% - Minimo € 250,00")
            End With
            With DecodeIncendioFenomeniAtmosfericiLargeMassimale
                .Add(20000D, "Massimale € 20.000,00")
                .Add(30000D, "Massimale € 30.000,00")
            End With
            With DecodeIncendioDemolizioneMassimale
                .Add(30000D, "Massimale € 30.000,00")
                .Add(60000D, "Massimale € 60.000,00")
                .Add(999999D, "Massimale illimitato")
            End With
            With DecodeIncendioGeloMassimale
                .Add(5000D, "Massimale € 5.000,00")
                .Add(7500D, "Massimale € 7.500,00")
            End With
            With DecodeIncendioGeloFranchigia
                .Add(250, "Franchigia € 250,00")
                .Add(400, "Franchigia € 400,00")
            End With
            With DecodeIncendioRicercaGuastoMassimale
                .Add(2500D, "Massimale € 2.500,00")
                .Add(5000D, "Massimale € 5.000,00")
            End With
            With DecodeIncendioRicercaGuastoFranchigia
                .Add(150, "Franchigia € 150,00")
                .Add(300, "Franchigia € 300,00")
            End With
            With DecodeIncendioAcquaOcclusioneMassimale
                .Add(10000D, "Massimale € 10.000,00")
                .Add(15000D, "Massimale € 15.000,00")
            End With
            With DecodeIncendioAcquaOcclusioneFranchigia
                .Add(150, "Franchigia € 150,00")
                .Add(250, "Franchigia € 250,00")
            End With
            With DecodeIncendioPannelliSolariMassimale
                .Add(20000D, "Massimale € 20.000,00")
                .Add(30000D, "Massimale € 30.000,00")
            End With
            With DecodeIncendioPannelliSolariFranchigia
                .Add(250D, "Franchigia € 250,00")
                .Add(500D, "Franchigia € 500,00")
            End With
            With DecodeTerremotoFabbricatoLimite
                .Add(50, "Limite 50%")
                .Add(70, "Limite 70%")
            End With
            With DecodeFurtoEsternoLimite
                .Add(15, "Limite 15%")
                .Add(20, "Limite 20%")
            End With
            With DecodeFurtoEsternoMassimale
                .Add(300D, "15% SA - Max € 300,00 x oggetto")
                .Add(500D, "25% SA - Max € 500,00 x oggetto")
            End With
            With DecodeFurtoPannelliSolariMassimale
                .Add(5000D, "Massimale € 5.000,00")
                .Add(10000D, "Massimale € 10.000,00")
                .Add(15000D, "Massimale € 15.000,00")
            End With
            With DecodeFurtoFranchigiaFranchigia
                .Add(500D, "Franchigia € 500,00")
                .Add(750D, "Franchigia € 750,00")
            End With
            With DecodeResponsabilitaCivileBaseMassimale
                .Add(250000D, "Massimale € 250.000,00")
                .Add(500000D, "Massimale € 500.000,00")
                .Add(1000000D, "Massimale € 1.000.000,00")
                .Add(1500000D, "Massimale € 1.500.000,00")
                .Add(2000000D, "Massimale € 2.000.000,00")
                .Add(2500000D, "Massimale € 2.500.000,00")
            End With
            With DecodeSalvaBenessereBaseMassimale
                .Add(1200D, "Massimale € 1.200,00")
                .Add(1800D, "Massimale € 1.800,00")
                .Add(2400D, "Massimale € 2.400,00")
                .Add(3000D, "Massimale € 3.000,00")
            End With
            With DecodeTutelaLegaleBaseMassimale
                .Add(10000D, "Massimale € 10.000,00")
                .Add(20000D, "Massimale € 20.000,00")
                .Add(30000D, "Massimale € 30.000,00")
            End With
            With DecodeProvincia
                .Add(0, "Provincia")
            End With
            With DecodeRegione
                .Add(0, "Regione")
            End With
            With DecodeRegioneToZonaTerritorialeSalvaBenessere
                .Add(RegioneEnum.ABRUZZO, ZonaTerritorialeSalvaBenessereEnum.Zona2)
                .Add(RegioneEnum.BASILICATA, ZonaTerritorialeSalvaBenessereEnum.Zona3)
                .Add(RegioneEnum.CALABRIA, ZonaTerritorialeSalvaBenessereEnum.Zona3)
                .Add(RegioneEnum.CAMPANIA, ZonaTerritorialeSalvaBenessereEnum.Zona3)
                .Add(RegioneEnum.EMILIAROMAGNA, ZonaTerritorialeSalvaBenessereEnum.Zona1)
                .Add(RegioneEnum.FRIULIVENEZIAGIULIA, ZonaTerritorialeSalvaBenessereEnum.Zona1)
                .Add(RegioneEnum.LAZIO, ZonaTerritorialeSalvaBenessereEnum.Zona2)
                .Add(RegioneEnum.LIGURIA, ZonaTerritorialeSalvaBenessereEnum.Zona2)
                .Add(RegioneEnum.LOMBARDIA, ZonaTerritorialeSalvaBenessereEnum.Zona1)
                .Add(RegioneEnum.MARCHE, ZonaTerritorialeSalvaBenessereEnum.Zona2)
                .Add(RegioneEnum.MOLISE, ZonaTerritorialeSalvaBenessereEnum.Zona2)
                .Add(RegioneEnum.PIEMONTE, ZonaTerritorialeSalvaBenessereEnum.Zona2)
                .Add(RegioneEnum.PUGLIA, ZonaTerritorialeSalvaBenessereEnum.Zona3)
                .Add(RegioneEnum.SARDEGNA, ZonaTerritorialeSalvaBenessereEnum.Zona3)
                .Add(RegioneEnum.SICILIA, ZonaTerritorialeSalvaBenessereEnum.Zona3)
                .Add(RegioneEnum.TOSCANA, ZonaTerritorialeSalvaBenessereEnum.Zona2)
                .Add(RegioneEnum.TRENTINOALTOADIGE, ZonaTerritorialeSalvaBenessereEnum.Zona1)
                .Add(RegioneEnum.UMBRIA, ZonaTerritorialeSalvaBenessereEnum.Zona2)
                .Add(RegioneEnum.VALDAOSTA, ZonaTerritorialeSalvaBenessereEnum.Zona1)
                .Add(RegioneEnum.VENETO, ZonaTerritorialeSalvaBenessereEnum.Zona1)
            End With
            With DecodeProvinciaToClasseTerritorialeFurto
                .Add(ProvinciaEnum.SiglaXX, ClasseTerritorialeFurtoEnum.Classe1)
                .Add(ProvinciaEnum.SiglaAG, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaAL, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaAN, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaAO, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaAP, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaAQ, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaAR, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaAT, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaAV, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaBA, ClasseTerritorialeFurtoEnum.Classe1)
                .Add(ProvinciaEnum.SiglaBG, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaBI, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaBL, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaBN, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaBO, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaBR, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaBS, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaBT, ClasseTerritorialeFurtoEnum.Classe1)
                .Add(ProvinciaEnum.SiglaBZ, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaCA, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaCB, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaCE, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaCH, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaCI, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaCL, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaCN, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaCO, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaCR, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaCS, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaCT, ClasseTerritorialeFurtoEnum.Classe1)
                .Add(ProvinciaEnum.SiglaCZ, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaEN, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaFC, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaFE, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaFG, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaFI, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaFM, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaFR, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaGE, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaGO, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaGR, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaIM, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaIS, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaKR, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaLC, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaLE, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaLI, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaLO, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaLT, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaLU, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaMB, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaMC, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaME, ClasseTerritorialeFurtoEnum.Classe1)
                .Add(ProvinciaEnum.SiglaMI, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaMN, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaMO, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaMS, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaMT, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaNA, ClasseTerritorialeFurtoEnum.Classe1)
                .Add(ProvinciaEnum.SiglaNO, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaNU, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaOG, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaOR, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaOT, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaPA, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaPC, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaPD, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaPE, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaPG, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaPI, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaPN, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaPO, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaPR, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaPT, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaPU, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaPV, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaPZ, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaRA, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaRC, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaRE, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaRG, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaRI, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaRM, ClasseTerritorialeFurtoEnum.Classe1)
                .Add(ProvinciaEnum.SiglaRN, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaRO, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaRSM, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaSA, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaSI, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaSO, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaSP, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaSR, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaSS, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaSV, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaTA, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaTE, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaTN, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaTO, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaTP, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaTR, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaTS, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaTV, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaUD, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaVA, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaVB, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaVC, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaVE, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaVI, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaVR, ClasseTerritorialeFurtoEnum.Classe2)
                .Add(ProvinciaEnum.SiglaVS, ClasseTerritorialeFurtoEnum.Classe4)
                .Add(ProvinciaEnum.SiglaVT, ClasseTerritorialeFurtoEnum.Classe3)
                .Add(ProvinciaEnum.SiglaVV, ClasseTerritorialeFurtoEnum.Classe4)
            End With
            With DecodeProvinciaToEventiAtmosferici
                .Add(ProvinciaEnum.SiglaAG, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaAL, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaAN, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaAO, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaAP, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaAQ, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaAR, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaAT, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaAV, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaBA, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaBG, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaBI, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaBL, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaBN, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaBO, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaBR, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaBS, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaBT, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaBZ, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaCA, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaCB, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaCE, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaCH, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaCI, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaCL, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaCN, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaCO, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaCR, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaCS, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaCT, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaCZ, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaEN, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaFC, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaFE, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaFG, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaFI, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaFM, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaFR, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaGE, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaGO, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaGR, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaIM, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaIS, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaKR, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaLC, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaLE, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaLI, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaLO, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaLT, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaLU, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaMB, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaMC, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaME, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaMI, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaMN, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaMO, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaMS, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaMT, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaNA, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaNO, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaNU, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaOG, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaOR, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaOT, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaPA, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaPC, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaPD, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaPE, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaPG, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaPI, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaPN, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaPO, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaPR, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaPT, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaPU, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaPV, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaPZ, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaRA, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaRC, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaRE, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaRG, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaRI, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaRM, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaRN, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaRO, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaRSM, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaSA, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaSI, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaSO, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaSP, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaSR, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaSS, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaSV, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaTA, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaTE, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaTN, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaTO, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaTP, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaTR, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaTS, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaTV, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaUD, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaVA, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaVB, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaVC, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaVE, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaVI, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaVR, ZonaTerritorialeEventiAtmosfericiEnum.ZonaA)
                .Add(ProvinciaEnum.SiglaVS, ZonaTerritorialeEventiAtmosfericiEnum.ZonaC)
                .Add(ProvinciaEnum.SiglaVT, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
                .Add(ProvinciaEnum.SiglaVV, ZonaTerritorialeEventiAtmosfericiEnum.ZonaB)
            End With

        End Sub
    End Class
End Namespace
