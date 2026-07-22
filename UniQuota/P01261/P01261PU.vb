Namespace P01261
    <Serializable()> Public Class assicurato

        Public Invalidita As Invalidita

        Public CriterioLiquidazioneIPM As CriterioLiquidazioneIPMEnum
        Public Nominativo As String
        Public Eta As Integer

        'Malattia
        Public CoperturaMalattia As New CoperturaComposta()
        'Public PartitaMalattiaIPM As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaIPM As New CoperturaSingola(New Garanzia(TipoGaranzia.MalattiaIPM))
        'Public PartitaMalattiaVisiteTrattamenti As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaVisiteTrattamenti As New CoperturaSingola(New Garanzia(TipoGaranzia.MalattiaVisiteTrattamenti))
        'Public PartitaMalattiaConvalescenza As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaConvalescenza As New CoperturaSingola(New Garanzia(TipoGaranzia.MalattiaConvalescenza))
        'Public PartitaMalattiaPrevenzioneSindromeMetabolica As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaPrevenzioneSindromeMetabolica As New CoperturaSingola(New Garanzia(TipoGaranzia.MalattiaPrevenzioneSindromeMetabolica))
        'Public PartitaMalattiaSecondOpinion As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaSecondOpinion As New CoperturaSingola(New Garanzia(TipoGaranzia.MalattiaSecondOpinion))

        'Assistenza
        Public CoperturaAssistenza As New CoperturaSingola(New Garanzia(TipoGaranzia.AssistenzaBase))

        Public Sub New(ByVal Invalidita As Invalidita)
            Me.Invalidita = Invalidita

            With CoperturaMalattia
                .Sezione = Invalidita.SezioneMalattia
                .AddCopertura(CoperturaMalattiaIPM)
                .AddCopertura(CoperturaMalattiaVisiteTrattamenti)
                .AddCopertura(CoperturaMalattiaConvalescenza)
                .AddCopertura(CoperturaMalattiaPrevenzioneSindromeMetabolica)
                .AddCopertura(CoperturaMalattiaSecondOpinion)
            End With

            With CoperturaAssistenza
                .Sezione = Invalidita.SezioneAssistenza
            End With
        End Sub

        Public Sub ValidaSezioni()
            If Eta < 0 Or Eta > 64 Then
                CoperturaMalattiaIPM.SetNonDisponibile("Indicare l'età dell'assicurato (da 0 a 64 anni)")
            End If

            CoperturaMalattia.DipendeDa(True)

            CoperturaMalattiaIPM.ObbligatoriaDa(CoperturaMalattia.IsAttivo)
            CoperturaMalattiaVisiteTrattamenti.ObbligatoriaDa(CoperturaMalattia.IsAttivo)
            CoperturaMalattiaConvalescenza.ObbligatoriaDa(CoperturaMalattia.IsAttivo)
            CoperturaMalattiaPrevenzioneSindromeMetabolica.ObbligatoriaDa(CoperturaMalattia.IsAttivo)
            CoperturaMalattiaSecondOpinion.ObbligatoriaDa(CoperturaMalattia.IsAttivo)
            CoperturaAssistenza.ObbligatoriaDa(CoperturaMalattia.IsAttivo)

            Dim tassobase As Decimal
            If CriterioLiquidazioneIPM = 0 Then CriterioLiquidazioneIPM = CriterioLiquidazioneIPMEnum.Tabella1

            With CoperturaMalattiaIPM
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 50000
                tassobase = Invalidita.Tabella.getPremio(Eta, CriterioLiquidazioneIPM, .MassimaleAttivo)
                .Tariffa.Tasso = 0.9496D * tassobase
            End With

            With CoperturaMalattiaVisiteTrattamenti
                .Garanzia.Massimale = 1500
                .Tariffa.Base = 0.0101D * tassobase * CoperturaMalattiaIPM.MassimaleAttivo
            End With

            With CoperturaMalattiaConvalescenza
                .Garanzia.Massimale = 50
                .Tariffa.Base = 0.0101D * tassobase * CoperturaMalattiaIPM.MassimaleAttivo
            End With

            With CoperturaMalattiaPrevenzioneSindromeMetabolica
                .Tariffa.Base = 0.0101D * tassobase * CoperturaMalattiaIPM.MassimaleAttivo
            End With

            With CoperturaMalattiaSecondOpinion
                .Tariffa.Base = 0.0101D * tassobase * CoperturaMalattiaIPM.MassimaleAttivo
            End With

            With CoperturaAssistenza
                .Tariffa.Base = 0.01D * tassobase * CoperturaMalattiaIPM.MassimaleAttivo
            End With

        End Sub

    End Class
End Namespace
