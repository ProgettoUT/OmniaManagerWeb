Namespace P01263
    <Serializable()> Public Class Ricovero
        Inherits Prodotto
        Public assicurati As New List(Of assicurato)

        'sezioni
        Public SezioneMalattia As New Sezione(Me, TipoSezione.Malattia)
        Public SezioneAssistenza As New Sezione(Me, TipoSezione.Assistenza)

        'Malattia
        Public CoperturaMalattia As New CoperturaComposta()

        'Assistenza
        Public CoperturaAssistenza As New CoperturaComposta()

        <NonSerialized()> Public Tabella As P01263TR

        Public Overrides Sub New2()
            Tabella = New P01263TR()
        End Sub

        Public Sub New()
            New2()
            'Caratteristiche
            CodiceRamoPolizza = 80
            CodiceProdotto = TipoProdotto.Ricovero
            DescrizioneProdotto = "UnipolSai Salute Ricovero"
            Edizione = "01.04.2014"
            DataEntrataVigore = "01/04/2014"

            DurataContrattualeMinimaInAnni = 1
            DurataContrattualeMassimaInAnni = 5
            PeriodoMoraInGiorni = 15
            EmissioneAppendici = False
            TacitoRinnovo = False

            ContraenzaPersonaGiuridica = False
            ContraenzaPersonaFisica = True
            PremioMinimoPrimaRata = 0D
            PremioMinimoRataSuccessiva = 0D
            PremioMinimoAnnuoNetto = 50
            PremioMinimoAnnuoLordo = 0D

            FrazionamentoInteressiSemestrale = 3D
            FrazionamentoInteressiQuadrimestrale = 4D
            FrazionamentoInteressiTrimestrale = 5D
            FrazionamentoInteressiBimestrale = 0D
            FrazionamentoInteressiMensile = 0D
            FrazionamentoMinimoMesi = 0D
            FrazionamentoFrazionePersonalizzato = 11
            FrazionamentoInteressiPersonalizzato = 0D

            'I tassi e i premi della presente tariffa sono comprensivi di imposte e oneri parafiscali.
            BaseTasse = UniQuota.BaseTasse.BaseLorda

            'sezioni
            Sezioni.Add(SezioneMalattia)
            Sezioni.Add(SezioneAssistenza)

            'aliquote
            SezioneMalattia.AliquotaImposta = 0.025D
            SezioneAssistenza.AliquotaImposta = 0.1D

            'sezione - coperture
            SezioneMalattia.AddCopertura(CoperturaMalattia)
            SezioneAssistenza.AddCopertura(CoperturaAssistenza)

            CoperturaMalattia.Stato = StatoCopertura.attiva
            CoperturaAssistenza.Stato = StatoCopertura.attiva
            Frazionamento = FrazionamentiEnum.Personalizzato
        End Sub

        Public Overrides Sub Valida()
            ValidaCondizioniGenerali()
            ValidaSconti()
            ValidaSezioneMalattiaAssistenza()
        End Sub

        Public Sub ValidaCondizioniGenerali()
        End Sub

        Public Sub ValidaSconti()
            Select Case assicurati.Count
                Case Is <= 1 : SezioneMalattia.PercentualeScontoTecnico = 0D
                Case 2 : SezioneMalattia.PercentualeScontoTecnico = 0.05D
                Case 3 To 4 : SezioneMalattia.PercentualeScontoTecnico = 0.1D
                Case Else : SetRischioDirezione("Numero assicurati maggiore di quattro soggetto a direzione")
            End Select
        End Sub

        Public Sub ValidaSezioneMalattiaAssistenza()
            For Each assicurato As assicurato In assicurati
                assicurato.ValidaSezioneMalattiaAssistenza()
            Next
        End Sub

        Public Sub Aggiungiassicurato(ByRef assicurato As assicurato)
            assicurati.Add(assicurato)
            CoperturaMalattia.Coperture.Add(assicurato.CoperturaMalattia)
            CoperturaAssistenza.Coperture.Add(assicurato.CoperturaAssistenza)
        End Sub

        Public Sub Rimuoviassicurato(ByRef assicurato As assicurato)
            assicurati.Remove(assicurato)
            CoperturaMalattia.Coperture.Remove(assicurato.CoperturaMalattia)
            CoperturaAssistenza.Coperture.Remove(assicurato.CoperturaAssistenza)
        End Sub

        Public Overrides Sub Stampa(ByVal options As StampaOptions)
            Dim s As New P01263ST
            Stampato = True
            s.StampaMostraEtInvia(Me, options)
        End Sub

    End Class
End Namespace
