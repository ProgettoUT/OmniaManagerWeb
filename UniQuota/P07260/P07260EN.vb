Namespace P07260
    Public Enum TipoSezione
        Incendio
        ResponsabilitaCivile
        DanniAcqua
        Infortuni
        TutelaLegale
        Terremoto
    End Enum

    Public Enum TipoPartita
        Generale = 0
        Incendio
        ResponsabilitaCivile
        DanniAcqua
        Infortuni
        TutelaLegale
        Terremoto
    End Enum

    Public Enum TipoGaranzia
        IncendioBase
        IncendioFenomeniAtmosfericiBasic
        IncendioFenomeniAtmosfericiMedium
        IncendioAttiVandaliciDolosi
        IncendioAttiTerrorismo
        IncendioDanniImpiantiElettrici
        IncendioCristalli
        IncendioOnorariPeriti
        IncendioEnergy
        IncendioEnergy1
        IncendioEnergy2
        IncendioExtra
        IncendioExtra1
        IncendioExtra2
        IncendioExtra3
        IncendioDemolizioneSgombero

        ResponsabilitaCivileBase
        ResponsabilitaCivilePrestatoriLavoro
        ResponsabilitaCivileCommittenzaLavori
        ResponsabilitaCivileConduzioneUnitaImmobiliari
        ResponsabilitaCivileAmministratore
        ResponsabilitaCivileEnergy
        ResponsabilitaCivileEnergy1
        ResponsabilitaCivileEnergy2
        ResponsabilitaCivileEnergy3

        DanniAcquaBase
        DanniAcquaFuoriUscitaOcclusione
        DanniAcquaSpeseRicercaRiparazione
        DanniAcquaEnergy
        DanniAcquaEnergy1
        DanniAcquaEnergy2

        InfortuniBase
        InfortuniIP
        InfortuniRicovero
        InfortuniSpeseMediche

        TutelaLegaleBase
        TutelaLegaleDLgs8108
        TutelaLegaleDLgs19603
        TutelaLegaleDelibereAssemlea

        TerremotoBase

        IncendioEstensioneGaranziaBase
        DanniAcquaPerditeOcculte
    End Enum

    Public Enum TipologiaFabbricatoEnum
        FabbricatoIntero = 1
        FabbricatoPorzione = 2
    End Enum

    Public Enum ZonaTerritorialeEventiAtmosfericiEnum
        ClasseA = 1
        ClasseB = 2
        ClasseC = 3
    End Enum

    Public Enum CaratteristicaCostruttivaEnum
        Antisismica = 1
        NonAntisismica = 2
    End Enum

    Public Enum DanniAcquaFormaVenditaEnum
        EccedenzeConsumo = 1
        PerditeOcculte = 2
    End Enum
End Namespace
