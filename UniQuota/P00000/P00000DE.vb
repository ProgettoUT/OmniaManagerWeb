Public Class P00000DE
    Public Shared DecodeProdotto As New Dizionario(Of TipoProdotto, String)
    Public Shared DecodePeriodo As New Dizionario(Of Integer, String)

    Public DecodeSezione As New Dizionario(Of Integer, String)
    Public DecodePartita As New Dizionario(Of Integer, String)
    Public DecodeGaranzia As New Dizionario(Of Integer, String)
    Public DecodeFrazionamenti As New Dizionario(Of Integer, String)

    Shared Sub New()
        With DecodeProdotto
            .Add(TipoProdotto.Sconosciuto, "Sconosciuto")
            .Add(TipoProdotto.Protetto, "Protetto")
            .Add(TipoProdotto.Impresa100, "100% Impresa")
            .Add(TipoProdotto.YouCondominio, "Condominio")
            .Add(TipoProdotto.YouCommercio, "Commercio")
            .Add(TipoProdotto.YouCasa, "Casa")
            .Add(TipoProdotto.UnipolSaiCasaServizi, "UnipolSai Casa & Servizi")
            .Add(TipoProdotto.YouInfortuni, "Infortuni")
            .Add(TipoProdotto.YouIngegnereArchitetto, "Ingegnere & Architetto")
            .Add(TipoProdotto.Smart, "Smart")
            .Add(TipoProdotto.Circolazione, "Circolazione")
            .Add(TipoProdotto.InfortuniPremium, "Infortuni Premium UnipolSai")
            .Add(TipoProdotto.Invalidita, "Invalidità")
            .Add(TipoProdotto.SpeseMediche, "Spese mediche")
            .Add(TipoProdotto.Ricovero, "Ricovero")
            .Add(TipoProdotto.Fascicolo, "Fascicolo")
        End With

        With DecodePeriodo
            .Add(PeriodoEnum.Anni, "Anni")
            .Add(PeriodoEnum.Mesi, "Mesi")
            .Add(PeriodoEnum.Giorni, "Giorni")
        End With
    End Sub
End Class

