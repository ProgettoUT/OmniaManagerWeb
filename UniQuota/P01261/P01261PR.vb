Namespace P01261
    <Serializable()> Public Class Invalidita
        Inherits Prodotto
        Public assicurati As New List(Of assicurato)


        'aliquote

        'sezioni
        Public SezioneMalattia As New Sezione(Me, TipoSezione.Malattia)
        Public SezioneAssistenza As New Sezione(Me, TipoSezione.Assistenza)

        'Malattia
        Public CoperturaMalattia As New CoperturaComposta()

        'Assistenza
        Public CoperturaAssistenza As New CoperturaComposta()

        <NonSerialized()> Public Tabella As P01261TR

        Public Overrides Sub New2()
            Tabella = New P01261TR()
        End Sub

        Public Sub New()
            New2()
            'Caratteristiche
            CodiceRamoPolizza = 80
            CodiceProdotto = TipoProdotto.Invalidita
            DescrizioneProdotto = "UnipolSai Salute Invalidità"
            Edizione = "01.04.2014"
            DataEntrataVigore = "01/04/2014"

            DurataContrattualeMinimaInAnni = 1
            DurataContrattualeMassimaInAnni = 5
            PeriodoMoraInGiorni = 15
            EmissioneAppendici = false
            TacitoRinnovo = false

            ContraenzaPersonaGiuridica = true
            ContraenzaPersonaFisica = true
            PremioMinimoPrimaRata = 0D
            PremioMinimoRataSuccessiva = 0D
            premioMinimoAnnuoNetto = 50
            premioMinimoAnnuoLordo = 0D

            FrazionamentoInteressiSemestrale = 3
            FrazionamentoInteressiQuadrimestrale = 4
            FrazionamentoInteressiTrimestrale = 5
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
            SezioneAssistenza.AliquotaImposta = 0.10D

            'sezione - coperture
            SezioneMalattia.AddCopertura(CoperturaMalattia)
            SezioneAssistenza.AddCopertura(CoperturaAssistenza)
            CoperturaMalattia.Stato = StatoCopertura.attiva
            CoperturaAssistenza.Stato = StatoCopertura.attiva
            Frazionamento = FrazionamentiEnum.Personalizzato
        End Sub

        Public Overrides Sub Valida()
            ValidaSezioni()
        End Sub

        Public Sub ValidaSezioni()
            For Each assicurato As assicurato In assicurati
                assicurato.ValidaSezioni()
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
            Dim s As New P01261ST
            Stampato = True
            s.StampaMostraEtInvia(Me, options)
        End Sub

    End Class
End Namespace
