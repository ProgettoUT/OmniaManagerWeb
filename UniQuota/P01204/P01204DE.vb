Namespace P01204
    Public Class P01204DE
        Inherits P00000DE

        Public DecodeRischioProfessionale As New Dizionario(Of Integer, String)
        Public DecodeTipoContraente As New Dizionario(Of Integer, String)
        Public DecodeFormaCopertura As New Dizionario(Of Integer, String)
        Public DecodeTipoRapporto As New Dizionario(Of Integer, String)
        Public DecodeInfortuniIPScelta As New Dizionario(Of Integer, String)
        Public DecodeRicoveroConvalescenzaScelta As New Dizionario(Of Integer, String)
        Public DecodeInfortuniITScelta As New Dizionario(Of Integer, String)
        Public DecodeSportClasseRischio As New Dizionario(Of Integer, String)
        Public DecodeInfortuniIPRenditaVitaliziaMassimale As New Dizionario(Of Decimal, String)
        Public DecodeInfortuniSpeseMedicheMassimale As New Dizionario(Of Decimal, String)
        Public DecodeSportSpeseMedicheMassimale As New Dizionario(Of Decimal, String)

        Sub New()
            With DecodeSezione
                .Add(TipoSezione.Infortuni, "Infortuni")
                .Add(TipoSezione.Malattia, "Malattia")
                .Add(TipoSezione.SalvaPremio, "Salva Premio")
                .Add(TipoSezione.Assistenza, "Assistenza")
            End With

            With DecodePartita
                .Add(TipoPartita.Infortuni, "Infortuni")
                .Add(TipoPartita.Malattia, "Malattia")
                .Add(TipoPartita.SalvaPremio, "Salva Premio")
                .Add(TipoPartita.Assistenza, "Assistenza")
            End With

            With DecodeGaranzia
                .Add(TipoGaranzia.InfortuniBase, "Garanzia base")
                .Add(TipoGaranzia.InfortuniMorte, "Morte")
                .Add(TipoGaranzia.InfortuniIP, "Invalidità Permanente")
                .Add(TipoGaranzia.InfortuniIPRenditaVitalizia, "Invalidità Permanente Rendita Vitalizia")
                .Add(TipoGaranzia.InfortuniSpeseMediche, "Rimborso Spese Mediche")
                .Add(TipoGaranzia.InfortuniRicoveroConvalescenza, "Indennita per ricovero e convalescenza")
                .Add(TipoGaranzia.InfortuniImmobilizzazione, "Indennita per immobilizzazione")
                .Add(TipoGaranzia.InfortuniIT, "Inabilita Temporanea")
                .Add(TipoGaranzia.InfortuniTabellaINAIL, "Invalidita Permanente Tabella INAIL")
                .Add(TipoGaranzia.InfortuniFranchigia3, "Invalidità Permanente con franchigia 3%")
                .Add(TipoGaranzia.InfortuniFranchigia0, "Invalidità Permanente senza franchigia")
                .Add(TipoGaranzia.InfortuniFranchigiaPlus, "Invalidità Permanente con franchigia UnipolSai Plus")
                .Add(TipoGaranzia.InfortuniFranchigiaDiff, "Invalidità Permanente con franchigie differenziate")
                .Add(TipoGaranzia.InfortuniSVPartiAnatomiche, "Super valutazione per parti anatomiche")
                .Add(TipoGaranzia.InfortuniSVIP, "Super valutazione per invalidità Permanente")
                .Add(TipoGaranzia.InfortuniForfaitFrattura, "Indennità forfettaria per frattura")
                .Add(TipoGaranzia.InfortuniForfaitRicovero, "Indennità forfettaria per gravi ricoveri a seguito di infortunio")
                .Add(TipoGaranzia.InfortuniGlobaleImmobilizzazione, "Indennità globale per immobilizzazione")
                .Add(TipoGaranzia.InfortuniDannoEstetico, "Invalidità permanente da danno estetico")
                .Add(TipoGaranzia.InfortuniMorteCircolazione, "Indennizzo aggiuntivo per morte da circolazione")
                .Add(TipoGaranzia.InfortuniNucleoFamiliare, "Copertura Nucleo Familiare")
                .Add(TipoGaranzia.SportAgonistico, "Sport agonistici")
                .Add(TipoGaranzia.SportAgonisticoMorte, "Sport agonistici: Morte")
                .Add(TipoGaranzia.SportAgonisticoIP, "    Invalidità Permanente")
                .Add(TipoGaranzia.SportAgonisticoSpeseMediche, "    Rimborso Spese Mediche")
                .Add(TipoGaranzia.SportAgonisticoRicoveroConvalescenza, "    Indennita per ricovero e convalescenza")
                .Add(TipoGaranzia.SportAltoRischio, "Sport ad alto rischio")
                .Add(TipoGaranzia.SportAltoRischioMorte, "Sport ad alto rischio: Morte")
                .Add(TipoGaranzia.SportAltoRischioIP, "    Invalidità Permanente")
                .Add(TipoGaranzia.SportAltoRischioSpeseMediche, "    Rimborso Spese Mediche")
                .Add(TipoGaranzia.SportAltoRischioRicoveroConvalescenza, "    Indennita per ricovero e convalescenza")
                .Add(TipoGaranzia.SportMoto, "Sport motoristici e motonautici")
                .Add(TipoGaranzia.SportMotoMorte, "Sport motoristici e motonautici: Morte")
                .Add(TipoGaranzia.SportMotoIP, "    Invalidità Permanente")
                .Add(TipoGaranzia.SportMotoSpeseMediche, "    Rimborso Spese Mediche")
                .Add(TipoGaranzia.SportMotoRicoveroConvalescenza, "    Indennita per ricovero e convalescenza")
                .Add(TipoGaranzia.SportAerei, "Sport aerei")
                .Add(TipoGaranzia.SportAereiMorte, "Sport aerei: Morte")
                .Add(TipoGaranzia.SportAereiIP, "    Invalidità Permanente")
                .Add(TipoGaranzia.SportAereiSpeseMediche, "    Rimborso Spese Mediche")
                .Add(TipoGaranzia.SportAereiRicoveroConvalescenza, "    Indennita per ricovero e convalescenza")
                .Add(TipoGaranzia.MalattiaBase, "MalattiaBase")
                .Add(TipoGaranzia.MalattiaRicoveroConvalescenza, "Indennita per ricovero e Convalescenza per malattia")
                .Add(TipoGaranzia.MalattiaForfaitRicovero, "Indennità forfettaria per gravi ricoveri a seguito di malattia")
                .Add(TipoGaranzia.SalvaPremioBase, "Salva premio")
                .Add(TipoGaranzia.AssistenzaBase, "Assistenza")
            End With

            With DecodeFrazionamenti
                .Add(FrazionamentiEnum.temporaneo, "temporaneo")
                .Add(FrazionamentiEnum.annuale, "annuale")
                .Add(FrazionamentiEnum.semestrale, "semestrale")
                .Add(FrazionamentiEnum.UnicoAnticipato, "Premio unico anticipato")
                .Add(FrazionamentiEnum.Personalizzato, "Mensile SEPA")
            End With

            With DecodeRischioProfessionale
                .Add(RischioProfessionaleEnum.ClasseA, "Classe A")
                .Add(RischioProfessionaleEnum.ClasseB, "Classe B")
                .Add(RischioProfessionaleEnum.ClasseC, "Classe C")
                .Add(RischioProfessionaleEnum.ClasseD, "Classe D")
            End With

            With DecodeTipoContraente
                .Add(TipoContraenteEnum.PersonaFisica, "Persona fisica")
                .Add(TipoContraenteEnum.PersonaGiuridica, "Persona giudirica")
            End With

            With DecodeFormaCopertura
                .Add(FormaCoperturaEnum.TempoLiberoLavoro, "Tempo libero e lavoro")
                .Add(FormaCoperturaEnum.Lavoro, "Lavoro")
                .Add(FormaCoperturaEnum.TempoLibero, "Tempo libero")
            End With

            With DecodeTipoRapporto
                .Add(TipoRapportoEnum.Dipendente, "Dipendente")
                .Add(TipoRapportoEnum.LiberoProfessionista, "Libero Professionista")
                .Add(TipoRapportoEnum.NonLavoratore, "Non lavoratori")
            End With

            With DecodeInfortuniIPScelta
                .Add(InfortuniIPSceltaEnum.Classic, "Classic")
                .Add(InfortuniIPSceltaEnum.TopTarget, "Top Target 30%")
            End With

            With DecodeRicoveroConvalescenzaScelta
                .Add(RicoveroConvalescenzaSceltaEnum.SoloRicovero, "Solo ricovero")
                .Add(RicoveroConvalescenzaSceltaEnum.RicoveroConvalescenza, "Ricovero e convalescenza")
            End With

            With DecodeInfortuniITScelta
                .Add(InfortuniITScetaEnum.InfortuniITIntegrale, "Integrale")
                .Add(InfortuniITScetaEnum.InfortuniITParziale, "Parziale")
                .Add(InfortuniITScetaEnum.InfortuniITTotale, "Totale")
            End With

            With DecodeSportClasseRischio
                .Add(SportClasseRischioEnum.Classe1, "Classe 1")
                .Add(SportClasseRischioEnum.Classe2, "Classe 2")
                .Add(SportClasseRischioEnum.Classe3, "Classe 3")
                .Add(SportClasseRischioEnum.Classe4, "Classe 4")
                .Add(SportClasseRischioEnum.Classe5, "Classe 5")
            End With

            With DecodeInfortuniIPRenditaVitaliziaMassimale
                .Add(30000, "30.000,00")
                .Add(60000, "60.000,00")
                .Add(90000, "90.000,00")
            End With
            With DecodeInfortuniSpeseMedicheMassimale
                .Add(2500, "2.500,00")
                .Add(3000, "3.000,00")
                .Add(3500, "3.500,00")
                .Add(4000, "4.000,00")
                .Add(4500, "4.500,00")
                .Add(5000, "5.000,00")
                .Add(6000, "6.000,00")
                .Add(7000, "7.000,00")
                .Add(8000, "8.000,00")
                .Add(9000, "9.000,00")
                .Add(10000, "10.000,00")
                .Add(15000, "15.000,00")
                .Add(20000, "20.000,00")
            End With

            With DecodeSportSpeseMedicheMassimale
                .Add(2500, "2.500,00")
                .Add(3000, "3.000,00")
                .Add(3500, "3.500,00")
                .Add(4000, "4.000,00")
                .Add(4500, "4.500,00")
                .Add(5000, "5.000,00")
                .Add(6000, "6.000,00")
                .Add(7000, "7.000,00")
                .Add(8000, "8.000,00")
                .Add(9000, "9.000,00")
                .Add(10000, "10.000,00")
            End With
        End Sub
    End Class
End Namespace
