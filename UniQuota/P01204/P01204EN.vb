Namespace P01204
    Public Enum TipoSezione
        Infortuni
        Malattia
        SalvaPremio
        Assistenza
    End Enum
    Public Enum TipoPartita
        Infortuni
        Malattia
        SalvaPremio
        Assistenza
    End Enum
    Public Enum TipoGaranzia
        InfortuniBase
        InfortuniMorte
        InfortuniIP
        InfortuniIPRenditaVitalizia
        InfortuniSpeseMediche
        InfortuniRicoveroConvalescenza
        InfortuniImmobilizzazione
        InfortuniIT
        InfortuniTabellaINAIL
        InfortuniFranchigia3
        InfortuniFranchigia0
        InfortuniFranchigiaPlus
        InfortuniFranchigiaDiff
        InfortuniSVPartiAnatomiche
        InfortuniSVIP
        InfortuniForfaitFrattura
        InfortuniForfaitRicovero
        InfortuniGlobaleImmobilizzazione
        InfortuniDannoEstetico
        InfortuniMorteCircolazione
        InfortuniNucleoFamiliare
        SportAgonistico
        SportAgonisticoMorte
        SportAgonisticoIP
        SportAgonisticoSpeseMediche
        SportAgonisticoRicoveroConvalescenza
        SportAltoRischio
        SportAltoRischioMorte
        SportAltoRischioIP
        SportAltoRischioSpeseMediche
        SportAltoRischioRicoveroConvalescenza
        SportMoto
        SportMotoMorte
        SportMotoIP
        SportMotoSpeseMediche
        SportMotoRicoveroConvalescenza
        SportAerei
        SportAereiMorte
        SportAereiIP
        SportAereiSpeseMediche
        SportAereiRicoveroConvalescenza
        MalattiaBase
        MalattiaRicoveroConvalescenza
        MalattiaForfaitRicovero
        SalvaPremioBase
        AssistenzaBase
    End Enum

    Public Enum RischioProfessionaleEnum
        ClasseA = 1
        ClasseB = 2
        ClasseC = 3
        ClasseD = 4
    End Enum

    Public Enum TipoContraenteEnum
        PersonaFisica = 1
        PersonaGiuridica = 2
    End Enum

    Public Enum FormaCoperturaEnum
        TempoLiberoLavoro = 1
        Lavoro = 2
        TempoLibero = 3
    End Enum

    Public Enum TipoRapportoEnum
        Dipendente = 1
        LiberoProfessionista = 2
        NonLavoratore = 3
    End Enum

    Public Enum InfortuniIPSceltaEnum
        Classic = 1
        TopTarget = 2
    End Enum

    Public Enum RicoveroConvalescenzaSceltaEnum
        SoloRicovero = 1
        RicoveroConvalescenza = 2
    End Enum

    Public Enum InfortuniITScetaEnum
        InfortuniITIntegrale = 1
        InfortuniITParziale = 2
        InfortuniITTotale = 3
    End Enum

    Public Enum SportClasseRischioEnum
        Classe1 = 1
        Classe2 = 2
        Classe3 = 3
        Classe4 = 4
        Classe5 = 5
    End Enum
End Namespace
