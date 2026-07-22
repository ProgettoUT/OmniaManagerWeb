Namespace P07261
    Public Enum TipoSezione
        Incendio
        Terremoto
        Furto
        ResponsabilitaCivile
        SalvaBenessere
        TutelaLegale
        Assistenza
    End Enum

    Public Enum TipoPartita
        Incendio
        Terremoto
        Furto
        ResponsabilitaCivile
        SalvaBenessere
        TutelaLegale
        Assistenza
    End Enum

    Public Enum TipoGaranzia
        IncendioBase
        IncendioAbitazione
        IncendioContenuto
        IncendioLocazione
        IncendioAcquaCondotta
        IncendioFenomeniElettrici
        IncendioFenomeniAtmosferici
        IncendioFenomeniAtmosfericiLarge
        IncendioRicorsoTerzi
        IncendioDemolizione
        IncendioGelo
        IncendioRicercaGuasto
        IncendioAcquaOcclusione
        IncendioPannelliSolari
        IncendioRiduzioneFranchigiaFenomeniElettrici
        TerremotoBase
        TerremotoFabbricato
        TerremotoContenuto
        FurtoBase
        FurtoContenuto
        FurtoEsterno
        FurtoEsternoPlatino
        FurtoInCassaforte
        FurtoPreziosiValori
        FurtoValoriDimoraAbituale
        FurtoValoriDimoraSaltuaria
        FurtoPannelliSolari
        FurtoMezziChiusura
        FurtoImpiantoAllarme
        FurtoFranchigia
        ResponsabilitaCivileBase
        RCVitaPrivata
        RCFabbricati
        RCVitaPrivataFabbricati
        SalvaBenessereBase
        TutelaLegaleBase
        AssistenzaBase
        IncendioEstensioneGaranziaBase
        IncendioPannelliSolariEstensioneFenomenoElettrico
        IncendioPannelliSolariEstensioneFenomenoAtmosferici
        IncendioPerditeOcculteAcqua
        FurtoEstensioneGaranziaBase
        RCEstensioneGaranziaBase
    End Enum

    Public Enum TipoContraenzaEnum
        PersonaFisica = 1
        PersonaGiudirica = 2
    End Enum

    Public Enum FormaAssicurazioneEnum
        ValoreInteroNuovo = 1
        ValoreInteroCommerciale = 2
        valorePrimoRischioNuovo = 3
        valorePrimoRischioCommerciale = 4
    End Enum

    Public Enum TipoAbitazioneEnum
        NonSelected = 0
        Appartamento = 1
        VillaSingola = 2
        VillaSchiera = 3
        DimoraSaltuaria = 4
    End Enum

    Public Enum TipoDimoraEnum
        NonSelected = 0
        DimoraAbituale = 1
        DimoraSaltuaria = 2
    End Enum

    Public Enum PianoAbitazioneEnum
        NonSelected = 0
        Sotterraneo = 1
        Interrato = 2
        PianoTerra = 3
        PianoRialzato = 4
        PianoAlto = 5
        InteroFabbricato = 6
    End Enum

    Public Enum ClasseTerritorialeFurtoEnum
        Classe1 = 1
        Classe2 = 2
        Classe3 = 3
        Classe4 = 4
    End Enum

    Public Enum ZonaTerritorialeEventiAtmosfericiEnum
        ZonaA = 1
        ZonaB = 2
        ZonaC = 3
    End Enum

    Public Enum ZonaTerritorialeSalvaBenessereEnum
        Zona1 = 1
        Zona2 = 2
        Zona3 = 3
    End Enum

    Public Enum IncendioChiaveEnum
        ChiaveARGENTO = 1
        ChiaveORO = 2
        ChiavePLATINO = 3
    End Enum

    Public Enum IncendioAbitazioneFormAssEnum
        ValoreInteroNuovo = 1
        ValoreInteroCommerciale = 2
    End Enum

    Public Enum IncendioContenutoFormAssEnum
        ValoreInteroNuovo = 1
        ValoreInteroCommerciale = 2
        ValorePrimoRischioNuovo = 3
        ValorePrimoRischioCommerciale = 4
    End Enum

    Public Enum IncendioLocazioneFormAssEnum
        ValoreInteroNuovo = 1
        ValoreInteroCommerciale = 2
        ValorePrimoRischioNuovo = 3
        valorePrimoRischioCommerciale = 4
    End Enum

    Public Enum CaratteristicaCostruttivaEnum
        NonSelected = 0
        Antisismica = 1
        Tradizionale = 2
        Muratura = 3
    End Enum

    Public Enum FurtoChiaveEnum
        ChiaveORO = 2
        ChiavePLATINO = 3
    End Enum

    Public Enum FurtoContenutoFormAssEnum
        ValoreInteroNuovo = 1
        ValoreInteroCommerciale = 2
        ValorePrimoRischioNuovo = 3
        ValorePrimoRischioCommerciale = 4
    End Enum

    Public Enum FurtoEsternoSceltaEnum
        SceltaMEDIUM = 1
        SceltaLARGE = 2
    End Enum

    Public Enum FurtoEsternoPlatinoSceltaEnum
        SceltaA = 1
        SceltaB = 2
    End Enum

    Public Enum FurtoInCassaforteSceltaEnum
        SceltaA = 1
        SceltaB = 2
    End Enum

    Public Enum FurtoPreziosiValoriSceltaEnum
        SceltaA = 1
        SceltaB = 2
    End Enum

    Public Enum FurtoValoriDimoraAbitualeDenaroEnum
        Scelta05 = 05
        Scelta10 = 10
    End Enum

    Public Enum FurtoValoriDimoraAbitualeValoriEnum
        Scelta40 = 40
        Scelta50 = 50
    End Enum

    Public Enum RCChiaveEnum
        ChiaveARGENTO = 1
        ChiaveORO = 2
        ChiavePLATINO = 3
    End Enum

    Public Enum SalvaBenessereEtaEnum
        Fascia0024 = 24
        Fascia2534 = 2534
        Fascia3545 = 3545
        Fascia4660 = 4660
        Fascia6165 = 6165
        Fascia6669 = 6669
        Fascia7000 = 7000
    End Enum

    Public Enum TutelaLegaleChiaveEnum
        ChiaveARGENTO = 1
        ChiaveORO = 2
        ChiavePLATINO = 3
    End Enum
End Namespace
