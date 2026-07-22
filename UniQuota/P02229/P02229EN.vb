Namespace P02229
    Public Enum TipoSezione
        ResponsabilitaCivile
        Incendio
        TutelaLegale
        InterruzioneProfessione
        ScontoSostituzionePolizza
    End Enum
    Public Enum TipoPartita
        ResponsabilitaCivile
        Incendio
        TutelaLegale
        InterruzioneProfessione
        ScontoSostituzionePolizza
    End Enum
    Public Enum TipoGaranzia
        ResponsabilitaCivileBase
        ResponsabilitaCivileMancataRispondenza
        ResponsabilitaCivileFaldaFreatica
        ResponsabilitaCivileDLgs81_2008
        ResponsabilitaCivileFranchigia
        ResponsabilitaCivileScontoDiff
        IncendioBase
        TutelaLegaleBase
        InterruzioneProfessioneBase
        ScontoSostituzionePolizza
    End Enum

    Public Enum AttivitaProfessionaleEnum
        ingegnere = 30320
        ingegnereProgettista = 30329
        architetto = 30323
        architettoProgettista = 30331
        studioAssociato = 30325
        studioAssociatoAttivitaPrivata = 30326
    End Enum

    Public Enum FasceIntroitiEnum
        TariffaGiovani = 1
        Fino025000 = 2
        Fino050000 = 3
        Fino125000 = 4
        Fino150000 = 5
        Fino200000 = 6
        Fino250000 = 7
        Fino375000 = 8
        Fino500000 = 9
    End Enum

    Public Enum IncendioContenutoEnum
        M12500D = 1
        M25000D = 2
    End Enum

    Public Enum IncendioRicorsoTerziEnum
        M150000D = 1
        M250000D = 2
    End Enum
End Namespace
