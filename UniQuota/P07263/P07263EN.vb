Namespace P07263
    Public Enum TipoSezione
        DanniBeni
        Catastrofali
        AssistenzaPlus
        ProtezioneEmergenza
        Furto
        DanniTerzi
        TutelaLegale
        Assistenza
        ProtezioneDigitale
        ProtezioneBenessere
        ProtezioneFamiglia
    End Enum

    Public Enum TipoPartita
        DanniBeni
        Catastrofali
        AssistenzaPlus
        ProtezioneEmergenza
        Furto
        DanniTerzi
        TutelaLegale
        Assistenza
        ProtezioneDigitale
        ProtezioneBenessere
        ProtezioneFamiglia
    End Enum

    Public Enum TipoGaranzia
        DanniBeniBase
        DanniBeniAbitazione
        DanniBeniContenuto
        DanniBeniGaranziaPlus
        DanniBeniFenomeniElettrici
        DanniBeniFenomeniElettriciPannelliSolari
        DanniBeniFenomeniAtmosferici
        DanniBeniDanniDaAcqua
        DanniBeniRicercaGuasto
        DanniBeniPerditeOcculte
        DanniBeniVetriCristalli
        CatastrofaliBase
        CatastrofaliTerremotoAbitazione
        CatastrofaliTerremotoContenuto
        CatastrofaliAlluvioneAbitazione
        CatastrofaliAlluvioneContenuto
        AssistenzaPlusBase
        EmergenzaBase
        EmergenzaIndennitaForfettaria
        EmergenzaRiassettoAbitazione
        EmergenzaRiassettoPotenziamentoMezziChiusura
        EmergenzaRimborsoSpeseMediche
        FurtoBase
        DanniFurtoContenuto
        DanniFurtoGaranziaPlus
        DanniFurtoValoriNonCustoditi
        DanniFurtoValoriCustoditi
        DanniFurtoSocioPolitico
        DanniFurtoPannelli
        DanniFurtoEsterno
        DanniFurtoImpiantoAllarme
        DanniTerziBase
        DanniTerziIncendio
        DanniTerziVitaPrivata
        DanniTerziProprieta
        DanniTerziPlus
        DanniTerziLavoro
        DanniTerziBeB
        DanniTerziLocazione
        DanniTerziStage
        TutelaLegaleBase
        TutelaLegaleDivorzio
        AssistenzaBase
        ProtezioneDigitaleBase
        ProtezioneDigitaleAssistenzaMalware
        ProtezioneDigitaleCyberBullismo
        ProtezioneDigitaleLesioneReputazione
        ProtezioneDigitaleProtezioneLegale
        ProtezioneBenessereBase
        ProtezioneBenessere45gg
        ProtezioneBenesserePerditaImpiego
        ProtezioneFamigliaBase
        ProtezioneFamigliaSostegnoFigli
        ProtezioneFamigliaSostegnoEducazione
        ProtezioneSostegnoDisabilita
        ProtezioneFamigliaSostegnoDomestico
    End Enum

    Public Enum FrazionamentiEnum
        temporaneo = 0
        annuale = 1
        semestrale = 2
        mensile = 9
        unicoAnticipato = 8
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

    Public Enum TipoDimoraEnum
        Abituale = 1
        NonAbituale = 2
        Locata = 3
    End Enum

    Public Enum TipoAbitazioneEnum
        Appartamento = 1
        VillaSingola = 2
        VillaSchiera = 3
    End Enum

    Public Enum TipoUtilizzoEnum
        Proprietario = 1
        Affittuario = 2
    End Enum

    Public Enum TipologiaCostruzioneEnum
        CementoArmato = 1
        Muratura = 2
        Bioedilizia = 3
        Legno = 4
    End Enum

    Public Enum AntisismicoEnum
        SI = 1
        NO = 2
    End Enum

    Public Enum AlluvionatoEnum
        SI = 1
        NO = 2
    End Enum

    Public Enum PianoAssicuratoEnum
        Sotterraneo = 1
        Interrato = 2
        PianoTerra = 3
        PianoRialzato = 4
        PrimoAlto = 5
        FabbricatoIntero = 6
    End Enum

    Public Enum ClasseTerritorialeFurtoEnum
        Classe1 = 1
        Classe2 = 2
        Classe3 = 3
    End Enum

    Public Enum ClasseTerritorialeEventiAtmosfericiEnum
        Classe1 = 1
        Classe2 = 2
        Classe3 = 3
    End Enum

    Public Enum ClasseTerritorialeDanniAcquaEnum
        Classe1 = 1
        Classe2 = 2
        Classe3 = 3
    End Enum

    Public Enum ClasseTerritorialeRCTEnum
        Classe1 = 1
        Classe2 = 2
        Classe3 = 3
    End Enum

    Public Enum RiparazionedirettaEnum
        SI = 1
        NO = 2
    End Enum

    Public Enum DanniBeniAbitazioneFormaGaranziaEnum
        ValoreIntero = 1
        ValorePRA50 = 3
        ValorePRA100 = 5
    End Enum

    Public Enum DanniBeniContenutoFormaGaranziaEnum
        ValoreIntero = 1
        ValorePRA = 2
    End Enum

    Public Enum AssistenzaPlusEnum
        Easy = 1
        Full = 2
        Top = 3
    End Enum

    Public Enum AlluvioneGruppoRischioEnum
        P0 = 1
        P1 = 2
        P2 = 3
        P3 = 4
    End Enum
End Namespace
