Namespace P01262
    <Serializable()> Public Class SpeseMediche
        Inherits Prodotto
        Public assicurati As New List(Of assicurato)
        Public ZonaTerritoriale As ZonaTerritorialeEnum

        'sezioni
        Public SezioneMalattia As New Sezione(Me, TipoSezione.Malattia)
        Public SezioneAssistenza As New Sezione(Me, TipoSezione.Assistenza)

        'Malattia
        Public CoperturaMalattia As New CoperturaComposta()
        'Assistenza
        Public CoperturaAssistenza As New CoperturaComposta()

        <NonSerialized()> Public Tabella As P01262TR

        Public Overrides Sub New2()
            Tabella = New P01262TR
        End Sub

        Public Sub New()
            New2()
            'Caratteristiche
            CodiceRamoPolizza = 80
            CodiceProdotto = TipoProdotto.SpeseMediche
            DescrizioneProdotto = "UnipolSai Salute Spese Mediche"
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
            If assicurati.Count > 0 AndAlso (assicurati(0).CoperturaMalattiaFormaNucleoFamiliare.IsAttivo) Then
                SezioneMalattia.PercentualeScontoTecnico = 0D
            Else
                Select Case assicurati.Count
                    Case 0 : SezioneMalattia.PercentualeScontoTecnico = 0D
                    Case 1 : SezioneMalattia.PercentualeScontoTecnico = 0D
                    Case 2 : SezioneMalattia.PercentualeScontoTecnico = 0.05D
                    Case 3 : SezioneMalattia.PercentualeScontoTecnico = 0.1D
                    Case 4 : SezioneMalattia.PercentualeScontoTecnico = 0.1D
                    Case Else : SezioneMalattia.PercentualeScontoTecnico = 0.15D
                End Select
            End If
        End Sub

        Public Sub ValidaSezioneMalattiaAssistenza()
            For Each assicurato As assicurato In assicurati
                assicurato.PrimoAssicurato = assicurato.Equals(assicurati(0))
                assicurato.ValidaAssicurato()
                assicurato.ValidaSezioneMalattiaAssistenza()
            Next
            If assicurati.Count > 0 AndAlso (assicurati(0).CoperturaMalattiaRicovero.IsAttivo Or assicurati(0).CoperturaMalattiaGicGem.IsAttivo) Then
                SezioneMalattia.Stato = StatoCopertura.attiva
                SezioneAssistenza.Stato = StatoCopertura.attiva
            Else
                SezioneMalattia.Stato = StatoCopertura.Inapplicabile
                SezioneAssistenza.Stato = StatoCopertura.Inapplicabile
            End If
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
            Dim s As New P01262ST
            Stampato = True
            s.StampaMostraEtInvia(Me, options)
        End Sub

    End Class
End Namespace
