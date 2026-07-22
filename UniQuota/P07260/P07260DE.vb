Namespace P07260
    Public Class P07260DE
        Inherits P00000DE

        Public ConvertRegioneToEventiAtmosferici As New Dictionary(Of Integer, ZonaTerritorialeEventiAtmosfericiEnum)
        Public DecodeTipologiaFabbricato As New Dictionary(Of TipologiaFabbricatoEnum, String)

        Public DecodeIncendioFABLimite As New Dictionary(Of Decimal, String)
        Public DecodeIncendioFABFranchigia As New Dictionary(Of Decimal, String)
        Public DecodeIncendioFAMMassimale As New Dictionary(Of Decimal, String)
        Public DecodeIncendioFAMFranchigia As New Dictionary(Of Decimal, String)
        Public DecodeIncendioAttiVandaliciDolosiFranchigia As New Dictionary(Of Decimal, String)

        Public DecodeIncendioAttiTerrorismoLimite As New Dictionary(Of Decimal, String)
        Public DecodeIncendioAttiTerrorismoFranchigia As New Dictionary(Of Decimal, String)

        Public DecodeIncendioDanniImpiantiElettriciMassimale As New Dictionary(Of Decimal, String)
        Public DecodeIncendioDanniImpiantiElettriciFranchigia As New Dictionary(Of Decimal, String)
        Public DecodeIncendioCristalliMassimale As New Dictionary(Of Decimal, String)
        Public DecodeIncendioEnergyMassimale As New Dictionary(Of Decimal, String)

        Public DecodeIncendioExtraMassimale1 As New Dictionary(Of Decimal, String)
        Public DecodeIncendioExtraFranchigia1 As New Dictionary(Of Decimal, String)
        Public DecodeIncendioExtraMassimale2 As New Dictionary(Of Decimal, String)
        Public DecodeIncendioExtraFranchigia2 As New Dictionary(Of Decimal, String)

        Public DecodeIncendioDemolizioneSgomberoMassimale As New Dictionary(Of Decimal, String)
        Public DecodeIncendioOnorariPeritiMassimale As New Dictionary(Of Decimal, String)

        Public DecodeResponsabilitaCivileBaseMassimale As New Dictionary(Of Decimal, String)
        Public DecodeResponsabilitaPrestatoriLavoroMassimale As New Dictionary(Of Decimal, String)
        Public DecodeResponsabilitaCommittenzaLavoriMassimale As New Dictionary(Of Decimal, String)
        Public DecodeResponsabilitaConduzioneUnitaImmobiliariMassimale As New Dictionary(Of Decimal, String)
        Public DecodeResponsabilitaAmministratoreMassimale As New Dictionary(Of Decimal, String)
        Public DecodeResponsabilitaEnergyMassimale As New Dictionary(Of Decimal, String)

        Public DecodeDanniAcquaBaseMassimale As New Dictionary(Of Decimal, String)
        Public DecodeDanniAcquaBaseFranchigia As New Dictionary(Of Decimal, String)
        Public DecodeDanniAcquaFuoriUscitaOcclusioneFranchigia As New Dictionary(Of Decimal, String)
        Public DecodeDanniAcquaSpeseRicercaRiparazioneMassimale As New Dictionary(Of Decimal, String)
        Public DecodeDanniAcquaSpeseRicercaRiparazioneFranchigia As New Dictionary(Of Decimal, String)
        Public DecodeDanniAcquaEnergyFranchigia As New Dictionary(Of Decimal, String)

        Public DecodeInfortuniBaseMassimale As New Dictionary(Of Decimal, String)
        Public DecodeTutelaLegaleBaseMassimale As New Dictionary(Of Decimal, String)

        Public DecodeTerremotoFabbricatoLimite As New Dizionario(Of Decimal, String)
        Public DecodeCaratteristicaCostruttiva As New Dizionario(Of Integer, String)

        Public DecodeDanniAcquaFormaVendita As New Dizionario(Of Integer, String)

        Sub New()
            With DecodeSezione
                .Add(TipoSezione.Incendio, "Incendio")
                .Add(TipoSezione.DanniAcqua, "Danni acqua")
                .Add(TipoSezione.Infortuni, "Infortuni")
                .Add(TipoSezione.TutelaLegale, "Tutela legale")
                .Add(TipoSezione.ResponsabilitaCivile, "Responsabilita civile")
                .Add(TipoSezione.Terremoto, "Terremoto")
            End With

            With DecodePartita
                .Add(TipoPartita.Generale, "")
                .Add(TipoPartita.Incendio, "Abitazione")
                .Add(TipoPartita.Infortuni, "Infortuni")
                .Add(TipoPartita.DanniAcqua, "Danni acqua")
                .Add(TipoPartita.ResponsabilitaCivile, "Responsabilita civile")
                .Add(TipoPartita.TutelaLegale, "Tutela Legale")
                .Add(TipoPartita.Terremoto, "Terremoto")
            End With

            With DecodeGaranzia
                .Add(TipoGaranzia.DanniAcquaBase, "Garanzia Base")
                .Add(TipoGaranzia.DanniAcquaFuoriUscitaOcclusione, "Fuoriuscita di liquidi, Acqua piovana, Occlusione")
                .Add(TipoGaranzia.DanniAcquaSpeseRicercaRiparazione, "Spese di ricerca e di riparazione")
                .Add(TipoGaranzia.DanniAcquaEnergy, "A - Energy")
                .Add(TipoGaranzia.DanniAcquaEnergy1, "R.C. spargimento acqua da conduzione U.M.")
                .Add(TipoGaranzia.DanniAcquaEnergy2, "Limiti per danni a cose in locali interrati ...") 'o seminterrati e/o adibiti ad attività industriali, artigianali, commerciali o di servizi")

                .Add(TipoGaranzia.IncendioAttiTerrorismo, "Atti di terrorismo")
                .Add(TipoGaranzia.IncendioAttiVandaliciDolosi, "Atti vandalici e dolosi")
                .Add(TipoGaranzia.IncendioBase, "Garanzia Base")
                .Add(TipoGaranzia.IncendioCristalli, "Cristalli")
                .Add(TipoGaranzia.IncendioOnorariPeriti, "Onorari dei periti")
                .Add(TipoGaranzia.IncendioDanniImpiantiElettrici, "Danni elettrici ed elettronici ad impianti")
                .Add(TipoGaranzia.IncendioEnergy, "A-Energy")
                .Add(TipoGaranzia.IncendioEnergy1, "Riprogettazione del fabbricato")
                .Add(TipoGaranzia.IncendioEnergy2, "Costi e oneri Spese")
                .Add(TipoGaranzia.IncendioExtra, "B-Extra")
                .Add(TipoGaranzia.IncendioExtra1, "Rimborso chiavi e/o serrature a seguito di furto")
                .Add(TipoGaranzia.IncendioExtra2, "Furto e guasti di fissi/infissi/pluviali/grondaie")
                .Add(TipoGaranzia.IncendioExtra3, "Caduta di antenne o parabola")

                .Add(TipoGaranzia.IncendioFenomeniAtmosfericiBasic, "Fenomeni atmosferici – SCELTA BASIC")
                .Add(TipoGaranzia.IncendioFenomeniAtmosfericiMedium, "Fenomeni atmosferici – SCELTA MEDIUM")
                .Add(TipoGaranzia.IncendioDemolizioneSgombero, "Demolizione, Sgombero e smaltimento")
                .Add(TipoGaranzia.InfortuniBase, "Garanzia Base")
                .Add(TipoGaranzia.InfortuniIP, "Invalidità permanente")
                .Add(TipoGaranzia.InfortuniRicovero, "Indennità ricovero")
                .Add(TipoGaranzia.InfortuniSpeseMediche, "Spese mediche")
                .Add(TipoGaranzia.ResponsabilitaCivileAmministratore, "Responsabilità civile dell’Amministratore")
                .Add(TipoGaranzia.ResponsabilitaCivileBase, "Garanzia Base")
                .Add(TipoGaranzia.ResponsabilitaCivileCommittenzaLavori, "Responsabilità civile per la committenza dei lavori")
                .Add(TipoGaranzia.ResponsabilitaCivileConduzioneUnitaImmobiliari, "R.C. Conduzione delle unità immobiliari")
                .Add(TipoGaranzia.ResponsabilitaCivileEnergy, "A - Energy")
                .Add(TipoGaranzia.ResponsabilitaCivileEnergy1, "Interruzione o sospensione attività industriali")
                .Add(TipoGaranzia.ResponsabilitaCivileEnergy2, "Inquinamento dell'aria")
                .Add(TipoGaranzia.ResponsabilitaCivileEnergy3, "Danni alle merci")
                .Add(TipoGaranzia.ResponsabilitaCivilePrestatoriLavoro, "Responsabilità Civile verso Prestatori di lavoro")
                .Add(TipoGaranzia.TutelaLegaleBase, "Garanzia Base")
                .Add(TipoGaranzia.TutelaLegaleDelibereAssemlea, "Impugnazione delle delibere assembleari")
                .Add(TipoGaranzia.TutelaLegaleDLgs19603, "D.Lgs. 196/03 Tutela della Privacy")
                .Add(TipoGaranzia.TutelaLegaleDLgs8108, "D.Lgs. 81/2008 Tutela della salute e della sicurezza")

                .Add(TipoGaranzia.TerremotoBase, "Terremoto Base")

                .Add(TipoGaranzia.IncendioEstensioneGaranziaBase, "Estensione Garanzia Base Incendio")
                .Add(TipoGaranzia.DanniAcquaPerditeOcculte, "Perdite occulte d’acqua")
            End With

            With DecodeFrazionamenti
                .Add(FrazionamentiEnum.Annuale, "Annuale")
                .Add(FrazionamentiEnum.Semestrale, "Semestrale")
                .Add(FrazionamentiEnum.Quadrimestrale, "Quadrimestrale")
                .Add(FrazionamentiEnum.Trimestrale, "Trimestrale")
                .Add(FrazionamentiEnum.UnicoAnticipato, "Unico Anticipato")
                .Add(FrazionamentiEnum.Temporaneo, "Temporaneo")
            End With

            With DecodeTipologiaFabbricato
                .Add(TipologiaFabbricatoEnum.FabbricatoIntero, "Fabbricato intero")
                .Add(TipologiaFabbricatoEnum.FabbricatoPorzione, "Porzione di fabbricato o villa")
            End With

            With ConvertRegioneToEventiAtmosferici
                .Add(RegioneEnum.REGIONE, ZonaTerritorialeEventiAtmosfericiEnum.ClasseA)
                .Add(RegioneEnum.ABRUZZO, ZonaTerritorialeEventiAtmosfericiEnum.ClasseB)
                .Add(RegioneEnum.BASILICATA, ZonaTerritorialeEventiAtmosfericiEnum.ClasseB)
                .Add(RegioneEnum.CALABRIA, ZonaTerritorialeEventiAtmosfericiEnum.ClasseB)
                .Add(RegioneEnum.CAMPANIA, ZonaTerritorialeEventiAtmosfericiEnum.ClasseC)
                .Add(RegioneEnum.EMILIAROMAGNA, ZonaTerritorialeEventiAtmosfericiEnum.ClasseB)
                .Add(RegioneEnum.FRIULIVENEZIAGIULIA, ZonaTerritorialeEventiAtmosfericiEnum.ClasseA)
                .Add(RegioneEnum.LAZIO, ZonaTerritorialeEventiAtmosfericiEnum.ClasseB)
                .Add(RegioneEnum.LIGURIA, ZonaTerritorialeEventiAtmosfericiEnum.ClasseA)
                .Add(RegioneEnum.LOMBARDIA, ZonaTerritorialeEventiAtmosfericiEnum.ClasseA)
                .Add(RegioneEnum.MARCHE, ZonaTerritorialeEventiAtmosfericiEnum.ClasseB)
                .Add(RegioneEnum.MOLISE, ZonaTerritorialeEventiAtmosfericiEnum.ClasseC)
                .Add(RegioneEnum.PIEMONTE, ZonaTerritorialeEventiAtmosfericiEnum.ClasseA)
                .Add(RegioneEnum.PUGLIA, ZonaTerritorialeEventiAtmosfericiEnum.ClasseC)
                .Add(RegioneEnum.SARDEGNA, ZonaTerritorialeEventiAtmosfericiEnum.ClasseC)
                .Add(RegioneEnum.SICILIA, ZonaTerritorialeEventiAtmosfericiEnum.ClasseB)
                .Add(RegioneEnum.TOSCANA, ZonaTerritorialeEventiAtmosfericiEnum.ClasseB)
                .Add(RegioneEnum.TRENTINOALTOADIGE, ZonaTerritorialeEventiAtmosfericiEnum.ClasseB)
                .Add(RegioneEnum.UMBRIA, ZonaTerritorialeEventiAtmosfericiEnum.ClasseB)
                .Add(RegioneEnum.VALDAOSTA, ZonaTerritorialeEventiAtmosfericiEnum.ClasseB)
                .Add(RegioneEnum.VENETO, ZonaTerritorialeEventiAtmosfericiEnum.ClasseA)
            End With

            DecodeIncendioFABLimite.Add(75D, "Limite 75%")
            DecodeIncendioFABLimite.Add(50D, "Limite 50%")

            DecodeIncendioFABFranchigia.Add(300D, "scoperto 10% minimo € 300,00")
            DecodeIncendioFABFranchigia.Add(500D, "scoperto 10% minimo € 500,00")

            DecodeIncendioFAMMassimale.Add(20000D, "Limite € 20.000,00")
            DecodeIncendioFAMMassimale.Add(30000D, "Limite € 30.000,00")

            DecodeIncendioFAMFranchigia.Add(300D, "scoperto 10% minimo € 300,00")
            DecodeIncendioFAMFranchigia.Add(500D, "scoperto 10% minimo € 500,00")

            DecodeIncendioAttiVandaliciDolosiFranchigia.Add(0D, "Estensione copertura")
            DecodeIncendioAttiVandaliciDolosiFranchigia.Add(100D, "Franchigia € 100,00")
            DecodeIncendioAttiVandaliciDolosiFranchigia.Add(200D, "scoperto 10% minimo € 200,00")

            DecodeIncendioAttiTerrorismoLimite.Add(25D, "Limite 25%")
            DecodeIncendioAttiTerrorismoLimite.Add(50D, "Limite 50%")

            DecodeIncendioAttiTerrorismoFranchigia.Add(500D, "scoperto 10% minimo € 500,00")
            DecodeIncendioAttiTerrorismoFranchigia.Add(1000D, "scoperto 10% minimo € 1.000,00")


            DecodeIncendioDanniImpiantiElettriciMassimale.Add(2500D, "Limite € 2.500,00")
            DecodeIncendioDanniImpiantiElettriciMassimale.Add(5000D, "Limite € 5.000,00")
            DecodeIncendioDanniImpiantiElettriciMassimale.Add(7500D, "Limite € 7.500,00")
            DecodeIncendioDanniImpiantiElettriciMassimale.Add(10D, "Limite 10% S.A. Fabbricato")

            DecodeIncendioDanniImpiantiElettriciFranchigia.Add(150D, "franchigia € 150,00")
            DecodeIncendioDanniImpiantiElettriciFranchigia.Add(250D, "franchigia € 250,00")

            DecodeIncendioCristalliMassimale.Add(1500D, "Limite € 1.500,00")
            DecodeIncendioCristalliMassimale.Add(2500D, "Limite € 2.500,00")
            DecodeIncendioCristalliMassimale.Add(5000D, "Limite € 5.000,00")
            DecodeIncendioCristalliMassimale.Add(10000D, "Limite € 10.000,00")

            DecodeIncendioEnergyMassimale.Add(5000D, "Limite 5% massimo € 5.000,00")
            DecodeIncendioEnergyMassimale.Add(10000D, "Limite 5% massimo € 10.000,00")

            DecodeIncendioExtraMassimale1.Add(500D, "Limite € 200,00 x sinistro - € 500,00 x anno")
            DecodeIncendioExtraMassimale1.Add(1000D, "Limite € 200,00 x sinistro - € 1.000,00 x anno")
            DecodeIncendioExtraFranchigia1.Add(0D, "senza franchigia")

            DecodeIncendioExtraMassimale2.Add(1500D, "Limite € 500,00 x sinistro - € 1.500,00 x anno")
            DecodeIncendioExtraMassimale2.Add(3000D, "Limite € 1.000,00 x sinistro - € 3.000,00 x anno")
            DecodeIncendioExtraMassimale2.Add(4500D, "Limite € 1.500,00 x sinistro - € 4.500,00 x anno")

            DecodeIncendioExtraFranchigia2.Add(0D, "senza franchigia")
            DecodeIncendioExtraFranchigia2.Add(150D, "franchigia € 150,00")
            DecodeIncendioExtraFranchigia2.Add(250D, "franchigia € 250,00")

            DecodeIncendioDemolizioneSgomberoMassimale.Add(30000D, "Limite 10% massimo € 30.000,00")
            DecodeIncendioDemolizioneSgomberoMassimale.Add(50000D, "Limite 10% massimo € 50.000,00")
            DecodeIncendioDemolizioneSgomberoMassimale.Add(80000D, "Limite 10% massimo € 80.000,00")
            DecodeIncendioDemolizioneSgomberoMassimale.Add(100000D, "Limite 10% massimo € 100.000,00")
            DecodeIncendioDemolizioneSgomberoMassimale.Add(130000D, "Limite 10% massimo € 130.000,00")
            DecodeIncendioDemolizioneSgomberoMassimale.Add(20D, "Limite 20% massimo illimitato")

            DecodeIncendioOnorariPeritiMassimale.Add(2000D, "Limite 5% massimo € 2.000,00")
            DecodeIncendioOnorariPeritiMassimale.Add(3000D, "Limite 10% massimo € 3.000,00")
            DecodeIncendioOnorariPeritiMassimale.Add(5000D, "Limite 10% massimo € 5.000,00")

            With DecodeResponsabilitaCivileBaseMassimale
                .Add(500000D, "Massimale € 500.000,00")
                .Add(1000000D, "Massimale € 1.000.000,00")
                .Add(1500000D, "Massimale € 1.500.000,00")
                .Add(2000000D, "Massimale € 2.000.000,00")
                .Add(2500000D, "Massimale € 2.500.000,00")
                .Add(3000000D, "Massimale € 3.000.000,00")
                .Add(5000000D, "Massimale € 5.000.000,00")
            End With

            With DecodeResponsabilitaPrestatoriLavoroMassimale
                .Add(500000D, "Massimale € 500.000,00")
                .Add(1000000D, "Massimale € 1.000.000,00")
                .Add(1500000D, "Massimale € 1.500.000,00")
                .Add(2000000D, "Massimale € 2.000.000,00")
                .Add(2500000D, "Massimale € 2.500.000,00")
                .Add(3000000D, "Massimale € 3.000.000,00")
                .Add(5000000D, "Massimale € 5.000.000,00")
            End With

            With DecodeResponsabilitaCommittenzaLavoriMassimale
                .Add(500000D, "Massimale € 500.000,00")
                .Add(1000000D, "Massimale € 1.000.000,00")
                .Add(1500000D, "Massimale € 1.500.000,00")
            End With

            With DecodeResponsabilitaConduzioneUnitaImmobiliariMassimale
                .Add(500000D, "Massimale € 500.000,00")
                .Add(1000000D, "Massimale € 1.000.000,00")
                .Add(1500000D, "Massimale € 1.500.000,00")
                .Add(2000000D, "Massimale € 2.000.000,00")
                .Add(2500000D, "Massimale € 2.500.000,00")
                .Add(3000000D, "Massimale € 3.000.000,00")
                .Add(5000000D, "Massimale € 5.000.000,00")
            End With

            With DecodeResponsabilitaAmministratoreMassimale
                .Add(25000D, "Massimale € 25.000,00")
                .Add(50000D, "Massimale € 50.000,00")
                .Add(500000D, "Massimale € 500.000,00")
            End With

            With DecodeResponsabilitaEnergyMassimale
                .Add(50000D, "Massimale € 50.000,00")
                .Add(100000D, "Massimale € 100.000,00")
                .Add(150000D, "Massimale € 150.000,00")
            End With


            With DecodeDanniAcquaBaseMassimale
                .Add(500000D, "Massimale € 500.000,00")
                .Add(1000000D, "Massimale € 1.000.000,00")
                .Add(1500000D, "Massimale € 1.500.000,00")
                .Add(2000000D, "Massimale € 2.000.000,00")
                .Add(2500000D, "Massimale € 2.500.000,00")
                .Add(3000000D, "Massimale € 3.000.000,00")
                .Add(5000000D, "Massimale € 5.000.000,00")
            End With

            With DecodeDanniAcquaBaseFranchigia
                .Add(0D, "No Franchigia")
                .Add(150D, "Franchigia € 150,00")
                .Add(250D, "Franchigia € 250,00")
                .Add(500D, "Franchigia € 500,00")
                .Add(750D, "Franchigia € 750,00")
                .Add(1000D, "Franchigia € 1.000,00")
            End With

            With DecodeDanniAcquaFuoriUscitaOcclusioneFranchigia
                .Add(150D, "Franchigia € 150,00")
                .Add(250D, "Franchigia € 250,00")
                .Add(500D, "Franchigia € 500,00")
            End With

            With DecodeDanniAcquaSpeseRicercaRiparazioneMassimale
                .Add(7500D, "Massimale x anno € 7.500,00")
                .Add(10000D, "Massimale x anno € 10.000,00")
                .Add(50000D, "Massimale x anno € 50.000,00")
            End With

            With DecodeDanniAcquaSpeseRicercaRiparazioneFranchigia
                .Add(150D, "Franchigia € 150,00")
                .Add(250D, "Franchigia € 250,00")
                .Add(500D, "Franchigia € 500,00")
            End With

            With DecodeDanniAcquaEnergyFranchigia
                .Add(0D, "No Franchigia")
                .Add(150D, "Franchigia € 150,00")
                .Add(250D, "Franchigia € 250,00")
                .Add(500D, "Franchigia € 500,00")
            End With

            With DecodeInfortuniBaseMassimale
                .Add(60000D, "Invalidità permanente € 60.000,00 - Indennità ricovero € 30,00 - Rimborso spese mediche € 3.000,00")
                .Add(120000D, "Invalidità permanente € 120.000,00 - Indennità ricovero € 60,00 - Rimborso spese mediche € 5.100,00")
                .Add(180000D, "Invalidità permanente € 180.000,00 - Indennità ricovero € 90,00 - Rimborso spese mediche € 7.800,00")
                .Add(240000D, "Invalidità permanente € 240.000,00 - Indennità ricovero € 120,00 - Rimborso spese mediche € 10.000,00")
            End With

            With DecodeTutelaLegaleBaseMassimale
                .Add(10000D, "Massimale € 10.000,00")
                .Add(20000D, "Massimale € 20.000,00")
                .Add(30000D, "Massimale € 30.000,00")
            End With

            With DecodeTerremotoFabbricatoLimite
                .Add(30, "Limite 30%")
                .Add(50, "Limite 50%")
            End With

            With DecodeCaratteristicaCostruttiva
                .Add(CaratteristicaCostruttivaEnum.Antisismica, "Antisismica")
                .Add(CaratteristicaCostruttivaEnum.NonAntisismica, "Non antisismica")
            End With

            With DecodeDanniAcquaFormaVendita
                .Add(DanniAcquaFormaVenditaEnum.EccedenzeConsumo, "Eccedenze consumo acqua fino a € 5.000")
                .Add(DanniAcquaFormaVenditaEnum.PerditeOcculte, "Perdite occulte d’acqua fino a € 12.000")
            End With
        End Sub
    End Class
End Namespace
