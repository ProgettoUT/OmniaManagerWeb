Namespace P01261
    Public Class P01261DE
        Inherits P00000DE

        Public DecodeCriterioLiquidazioneIPM  As New Dizionario(Of Integer, String)
        Public DecodeMalattiaIPMmassimale As New Dizionario(Of Decimal, String)

        Sub New()
            With DecodeSezione
                .Add(TipoSezione.Malattia, "Malattia e infortuni")
                .Add(TipoSezione.Assistenza, "Assistenza")
            End With

            With DecodePartita
                .Add(TipoPartita.Malattia, "Malattia e infortuni")
                .Add(TipoPartita.Assistenza, "Assistenza")
            End With

            With DecodeGaranzia
                .Add(TipoGaranzia.MalattiaBase, "Assicurato")
                .Add(TipoGaranzia.MalattiaIPM, "Invalidità Permanente da Malattia")
                .Add(TipoGaranzia.MalattiaVisiteTrattamenti, "Visite Specialistiche e Trattamenti")
                .Add(TipoGaranzia.MalattiaConvalescenza, "Indennita' giornaliera per convalescenza")
                .Add(TipoGaranzia.MalattiaPrevenzioneSindromeMetabolica, "Prevenzione Sindrome Metabolica")
                .Add(TipoGaranzia.MalattiaSecondOpinion, "Second Opinion")
                .Add(TipoGaranzia.AssistenzaBase, "Assistenza")
            End With

            With DecodeFrazionamenti
                .Add(FrazionamentiEnum.annuale, "annuale")
                .Add(FrazionamentiEnum.semestrale, "semestrale")
                .Add(FrazionamentiEnum.quadrimestrale, "quadrimestrale")
                .Add(FrazionamentiEnum.trimestrale, "trimestrale")
                .Add(FrazionamentiEnum.Personalizzato, "Mensile Finitalia")
            End With

            With DecodeCriterioLiquidazioneIPM 
                .Add(CriterioLiquidazioneIPMEnum.Tabella1, "Tabella 1 liquidazione IPM")
                .Add(CriterioLiquidazioneIPMEnum.Tabella2, "Tabella 2 liquidazione IPM")
            End With
            With DecodeMalattiaIPMmassimale
                .Add(50000, "50.000,00 Euro")
                .Add(75000, "75.000,00 Euro")
                .Add(100000, "100.000,00 Euro")
                .Add(150000, "150.000,00 Euro")
                .Add(200000, "200.000,00 Euro")
                .Add(250000, "250.000,00 Euro")
                .Add(300000, "300.000,00 Euro")
            End With
        End Sub
    End Class
End Namespace
