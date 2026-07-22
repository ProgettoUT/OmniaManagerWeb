Namespace P04226
    Public Enum TipoSezione
        Incendio
        Furto
        ResponsabilitaCivile
        TutelaLegale
        Assistenza
        Terremoto
    End Enum

    Public Enum TipoPartita
        Incendio
        Furto
        ResponsabilitaCivile
        TutelaLegale
        Assistenza
        Terremoto
    End Enum

    Public Enum TipoGaranzia
        IncendioBase
        IncendioFabbricato
        IncendioContenuto
        IncendioLocazione
        IncendioCondutture
        IncendioDemolizione
        IncendioEventiAtmosferici
        IncendioDanniElettrici
        IncendioDanniIndirettiA
        IncendioDanniIndirettiB
        IncendioRicorsoTerzi
        IncendioAumentoMerci
        IncendioCoseTrasportate
        IncendioRefrigerati1
        IncendioRefrigerati2
        IncendioLastre
        IncendioPannelliSolari
        IncendioRicetteMediche
        IncendioSpeseAccessorie
        IncendioGrandineFragili
        IncendioAttiVandaliciDolosi
        IncendioFabbricatiAperti1
        IncendioFabbricatiAperti2
        IncendioPreziosi
        IncendioSistemiProtezione
        IncendioCommercioAmbulante
        IncendioFranchigia
        FurtoBase
        FurtoContenuto
        FurtoFissi
        FurtoValori
        FurtoRapina
        FurtoVetrinette
        FurtoPortavalori
        FurtoAumentoMerci
        FurtoMerciTrasportate
        FurtoMerciAperto
        FurtoDistributoriEsterni
        FurtoDistributoriCarburante
        FurtoRicetteMediche
        FurtoDipendenti
        FurtoSpeseAccessorie
        FurtoSpeseMiglioramento
        FurtoSlotMachine
        FurtoReintegroAutomatico
        FurtoCommercioAmbulante
        FurtoDepositoRiserva
        FurtoDerogaCostruttive
        FurtoMezziChiusura
        FurtoImpiantoAllarme
        FurtoAllarmeDistanza
        FurtoAllarmeDoppio
        FurtoVideoSorveglianza
        FurtoScopertoMerciA
        FurtoScopertoMerciB
        FurtoPiuEsercizi
        ResponsabilitaCivileBase
        ResponsabilitaCivileRct
        ResponsabilitaCivileRco
        RCLavoratoriProgetto
        RCRicorsoTerzi
        RCDanniCoseClienti
        RCDanniVeicoliTerzi
        RCDanniFurto
        RCDanniCoseLavorate
        RCDanniCoseMovimentate
        RCMalattieProfessionali
        RCInquinamento
        RCFornitura
        RCDistributori1
        RCDistributori2
        RCCatering
        RCInstallazioni
        RCLavanderie
        RCParrucchieri
        RCSoloProprieta
        RCAmbulante
        RCFranchigia
        RCCarrelli
        TutelaLegaleBase
        TutelaLegaleDlgs07193
        TutelaLegaleDlgs01231
        TutelaLegaleDlgs97472
        AssistenzaBase

        TerremotoBase
        TerremotoFabbricato
        TerremotoContenuto
        TerremotoDemolizione
        TerremotoAumentoMerci
        TerremotoRicetteMediche
    End Enum

    Public Enum FormaDiAssicurazione
        ValoreInteroNuovo = 1
        ValoreInteroStatoUso = 2
    End Enum

    Public Enum ClasseFabbricatoEnum
        Classe1 = 1
        Classe2 = 2
    End Enum

    Public Enum FabbricatoDestinazioneEnum
        VenditaDettaglio = 1
        VenditaIngrosso = 2
        VenditaIngrossoDettaglio = 3
        Uffici = 4
    End Enum

    Public Enum ZonaTerritorialeFurtoEnum
        Zona12 = 12
        Zona21 = 21
        Zona22 = 22
        Zona31 = 31
        Zona32 = 32
        Zona41 = 41
    End Enum

    Public Enum ZonaTerritorialeEventiAtmosfericiEnum
        ZonaA = 1
        ZonaB = 2
        ZonaC = 3
    End Enum

    Public Enum ClasseRischioAttivitaIncendioEnum
        ClasseND = -2
        ClasseRD = -1
        Classe0 = 0
        Classe1 = 1
        Classe2 = 2
        Classe3 = 3
        Classe4 = 4
    End Enum

    Public Enum ClasseRischioAttivitaRcEnum
        ClasseND = -2
        ClasseRD = -1
        Classe0 = 0
        Classe1 = 1
        Classe2 = 2
    End Enum

    Public Enum ClasseRischioAttivitaTerremotoEnum
        ClasseND = -2
        ClasseRD = -1
        Classe0 = 0
        Classe1 = 1
        Classe2 = 2
        Classe3 = 3
    End Enum

    Public Enum ClasseRischioAttivitaFurtoEnum
        ND = -2
        RD = -1
        A0 = 0
        A2 = 1
        B1 = 2
        B2 = 3
        C1 = 4
        C2 = 5
        D1 = 6
        D2 = 7
    End Enum

    Public Enum IncendioSceltaEnum
        RischiNominati = 1
        AllRisks = 2
    End Enum

    Public Enum IncendioEventiAtmosfericiSceltaEnum
        SceltaBasic = 1
        SceltaMedium = 2
        SceltaLarge = 3
    End Enum

    Public Enum IncendioDanniElettriciSceltaEnum
        SceltaBasic = 1
        SceltaMedium = 2
    End Enum

    Public Enum IncendioDanniIndirettiSceltaEnum
        SceltaBasicDiaria = 1
        SceltaBasicPercentuale = 2
    End Enum

    Public Enum FurtoFissiSceltaEnum
        SceltaA = 1
        SceltaB = 2
    End Enum

    Public Enum FurtoValoriSceltaEnum
        SceltaA = 1
        SceltaB = 2
    End Enum

    Public Enum FurtoRapinaSceltaEnum
        SceltaA = 1
        SceltaB = 2
    End Enum

    Public Enum TipologiaFabbricatoEnum
        TipologiaA = 1
        TipologiaB = 2
    End Enum

    Public Enum CaratteristicaCostruttivaEnum
        Antisismica = 1
        Tradizionale = 2
        Muratura = 3
    End Enum
End Namespace
