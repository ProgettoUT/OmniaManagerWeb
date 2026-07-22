Namespace P02229
    Public Class P02229DE
        Inherits P00000DE

        Public DecodeAttivitaProfessionale As New Dizionario(Of Integer, String)
        Public DecodeFasceIntroiti As New Dizionario(Of Integer, String)
        Public DecodeIncendioContenuto As New Dizionario(Of Integer, String)
        Public DecodeIncendioRicorsoTerzi As New Dizionario(Of Integer, String)
        Public DecodeResponsabilitaCivileBaseMassimale As New Dizionario(Of Decimal, String)
        Public DecodeResponsabilitaCivileFranchigiaFranchigia As New Dizionario(Of Decimal, String)
        Public DecodeTutelaLegaleBaseMassimale As New Dizionario(Of Decimal, String)

        Sub New()
            With DecodeSezione
                .Add(TipoSezione.ResponsabilitaCivile, "Responsabilità Civile professionale")
                .Add(TipoSezione.Incendio, "Incendio")
                .Add(TipoSezione.TutelaLegale, "Tutela legale")
                .Add(TipoSezione.InterruzioneProfessione, "Interruzione Dell’attività Professionale")
                .Add(TipoSezione.ScontoSostituzionePolizza, "Sconto per sostituzione polizza")
            End With

            With DecodePartita
                .Add(TipoPartita.ResponsabilitaCivile, "Responsabilità Civile professionale")
                .Add(TipoPartita.Incendio, "Incendio")
                .Add(TipoPartita.TutelaLegale, "Tutela legale")
                .Add(TipoPartita.InterruzioneProfessione, "Interruzione Dell’attività Professionale")
                .Add(TipoPartita.ScontoSostituzionePolizza, "Sconto per sostituzione polizza")
            End With

            With DecodeGaranzia
                .Add(TipoGaranzia.ResponsabilitaCivileBase, "Garanzia base")
                .Add(TipoGaranzia.ResponsabilitaCivileMancataRispondenza, "Esclusione mancata rispondenza")
                .Add(TipoGaranzia.ResponsabilitaCivileFaldaFreatica, "Esclusione falda freatica")
                .Add(TipoGaranzia.ResponsabilitaCivileDLgs81_2008, "Esclusione D.Lgs. 81/2008")
                .Add(TipoGaranzia.ResponsabilitaCivileFranchigia, "Franchigia")
                .Add(TipoGaranzia.ResponsabilitaCivileScontoDiff, "Correttivo per cumulo sconti")
                .Add(TipoGaranzia.IncendioBase, "Garanzia base")
                .Add(TipoGaranzia.TutelaLegaleBase, "Garanzia base")
                .Add(TipoGaranzia.InterruzioneProfessioneBase, "Garanzia base")
                .Add(TipoGaranzia.ScontoSostituzionePolizza, "Sconto sostituzione polizza")
            End With

            With DecodeFrazionamenti
                .Add(FrazionamentiEnum.annuale, "annuale")
                .Add(FrazionamentiEnum.semestrale, "semestrale")
            End With

            With DecodeAttivitaProfessionale
                .Add(AttivitaProfessionaleEnum.ingegnere, "(30320) Ingegnere Progettista e Direttore dei lavori")
                .Add(AttivitaProfessionaleEnum.ingegnereProgettista, "(30329) Ingegnere solo Progettista")
                .Add(AttivitaProfessionaleEnum.architetto, "(30323) Architetto Progettista e Direttore dei lavori")
                .Add(AttivitaProfessionaleEnum.architettoProgettista, "(30331) Architetto solo Progettista")
                .Add(AttivitaProfessionaleEnum.studioAssociato, "(30325) studi associati - società professionali/ingegneria")
                .Add(AttivitaProfessionaleEnum.studioAssociatoAttivitaPrivata, "(30326) studi associati - società professionali/ingegneria + Attività privata")
            End With

            With DecodeFasceIntroiti
                .Add(FasceIntroitiEnum.TariffaGiovani, "Tariffa giovani")
                .Add(FasceIntroitiEnum.Fino025000, "Da 0,00 a € 25.000,00")
                .Add(FasceIntroitiEnum.Fino050000, "Da € 25.000,00 a € 50.000,00")
                .Add(FasceIntroitiEnum.Fino125000, "Da € 50.000,00 a € 125.000,00")
                .Add(FasceIntroitiEnum.Fino150000, "Da € 125.000,00 a € 150.000,00")
                .Add(FasceIntroitiEnum.Fino200000, "Da € 150.000,00 a € 200.000,00")
                .Add(FasceIntroitiEnum.Fino250000, "Da € 200.000,00 a € 250.000,00")
                .Add(FasceIntroitiEnum.Fino375000, "Da € 250.000,00 a € 375.000,00")
                .Add(FasceIntroitiEnum.Fino500000, "Da € 375.000,00 a € 500.000,00")
            End With

            With DecodeIncendioContenuto
                .Add(IncendioContenutoEnum.M12500D, "Contenuto € 12.500,00")
                .Add(IncendioContenutoEnum.M25000D, "Contenuto € 25.000,00")
            End With

            With DecodeIncendioRicorsoTerzi
                .Add(IncendioRicorsoTerziEnum.M150000D, "Ricorso Terzi € 150.000,00")
                .Add(IncendioRicorsoTerziEnum.M250000D, "Ricorso Terzi € 250.000,00")
            End With
            With DecodeResponsabilitaCivileBaseMassimale
                .Add(1000000D, "Massimale € 1.000.000")
                .Add(2000000D, "Massimale € 2.000.000")
                .Add(3000000D, "Massimale € 3.000.000")
                .Add(5000000D, "Massimale € 5.000.000")
            End With
            With DecodeResponsabilitaCivileFranchigiaFranchigia
                .Add(10000D, "Franchigia € 10.000,00")
                .Add(15000D, "Franchigia € 15.000,00")
                .Add(20000D, "Franchigia € 20.000,00")
            End With
            With DecodeTutelaLegaleBaseMassimale
                .Add(10000D, "Massimale € 10.000,00")
                .Add(20000D, "Massimale € 20.000,00")
                .Add(30000D, "Massimale € 30.000,00")
            End With
        End Sub
    End Class
End Namespace
