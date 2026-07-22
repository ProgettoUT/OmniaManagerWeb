Namespace P01204
    <Serializable()> Public Class InfortuniPremium
        Inherits Prodotto
        Public assicurati As New List(Of assicurato)

        Public RischioProfessionale As RischioProfessionaleEnum

        'aliquote

        'sezioni
        Public SezioneInfortuni As New Sezione(Me, TipoSezione.Infortuni)
        Public SezioneMalattia As New Sezione(Me, TipoSezione.Malattia)
        Public SezioneSalvaPremio As New Sezione(Me, TipoSezione.SalvaPremio)
        Public SezioneAssistenza As New Sezione(Me, TipoSezione.Assistenza)

        'Infortuni
        Public CoperturaInfortuni As New CoperturaComposta()

        'Malattia
        Public CoperturaMalattia As New CoperturaComposta()

        'SalvaPremio
        Public CoperturaSalvaPremio As New CoperturaComposta()

        'Assistenza
        Public CoperturaAssistenza As New CoperturaComposta()

        'Sconti
        Public ScontoPerNumeroAssicurati As New Sconto("Sconto per numero assicurati")
        Public ScontoPerPoliannualita As New Sconto("Sconto per annualità")

        Public Sub New()
            'Caratteristiche
            CodiceRamoPolizza = 77
            CodiceProdotto = TipoProdotto.InfortuniPremium
            DescrizioneProdotto = "UnipolSai Infortuni Premium"
            Edizione = "01.09.2015"
            DataEntrataVigore = "01/09/2015"

            DurataContrattualeMinimaInAnni = 1
            DurataContrattualeMassimaInAnni = 5
            PeriodoMoraInGiorni = 15
            EmissioneAppendici = false
            TacitoRinnovo = true

            ContraenzaPersonaGiuridica = true
            ContraenzaPersonaFisica = true
            PremioMinimoPrimaRata = 0D
            PremioMinimoRataSuccessiva = 0D
            premioMinimoAnnuoNetto = 100
            PremioMinimoAnnuoLordo = 0D

            FrazionamentoInteressiSemestrale = 0D
            FrazionamentoInteressiMensile = 0D
            FrazionamentoFrazionePersonalizzato = 12
            FrazionamentoInteressiPersonalizzato = 0D

            'I tassi e i premi della presente tariffa sono comprensivi di imposte e oneri parafiscali.
            BaseTasse = UniQuota.BaseTasse.BaseLorda

            'sezioni
            Sezioni.Add(SezioneInfortuni)
            Sezioni.Add(SezioneMalattia)
            Sezioni.Add(SezioneSalvaPremio)
            Sezioni.Add(SezioneAssistenza)

            'aliquote
            SezioneInfortuni.AliquotaImposta = AliquotaImpostaInfortuni
            SezioneMalattia.AliquotaImposta = AliquotaImpostaInfortuni
            SezioneSalvaPremio.AliquotaImposta = AliquotaImpostaTutelaLegale
            SezioneAssistenza.AliquotaImposta = AliquotaImpostaAssistenza

            'sezione - coperture
            SezioneInfortuni.AddCopertura(CoperturaInfortuni)
            SezioneMalattia.AddCopertura(CoperturaMalattia)
            SezioneSalvaPremio.AddCopertura(CoperturaSalvaPremio)
            SezioneAssistenza.AddCopertura(CoperturaAssistenza)

            'Sconti
            Sconti = New Sconti
            Sconti.Add(ScontoPerNumeroAssicurati)
            Sconti.Add(ScontoPerPoliannualita)

            CoperturaInfortuni.Stato = StatoCopertura.attiva
            CoperturaMalattia.Stato = StatoCopertura.attiva
            CoperturaSalvaPremio.Stato = StatoCopertura.attiva
            CoperturaAssistenza.Stato = StatoCopertura.attiva
            Frazionamento = FrazionamentiEnum.Personalizzato
        End Sub

        Public Overrides Sub New2()
            For Each assicurato As assicurato In assicurati
                assicurato.New2()
            Next
        End Sub

        Public Overrides Sub Valida()
            ValidaAssicurato()
            ValidaSezioneInfortuni()
            ValidaSezioneMalattia()
            ValidaSezioneSalvaPremio()
            ValidaSezioneAssistenza()
        End Sub

        Public Sub ValidaAssicurato()
            For Each assicurato As assicurato In assicurati
                assicurato.ValidaAssicurato()
            Next
        End Sub

        Public Sub ValidaSezioneInfortuni()
            SezioneInfortuni.Stato = StatoCopertura.esclusa
            For Each assicurato As assicurato In assicurati
                assicurato.ValidaSezioneInfortuni()
                If assicurato.CoperturaInfortuniMorte.PremioAttivoCrudo > 0D Or
                    assicurato.CoperturaInfortuniIP.PremioAttivoCrudo > 0D Then
                    SezioneInfortuni.Stato = StatoCopertura.attiva
                End If
            Next
        End Sub

        Public Sub ValidaSezioneMalattia()
            SezioneMalattia.Stato = StatoCopertura.esclusa
            For Each assicurato As assicurato In assicurati
                assicurato.ValidaSezioneMalattia()
                If assicurato.CoperturaMalattiaRicoveroConvalescenza.PremioAttivoCrudo > 0D Then
                    SezioneMalattia.Stato = StatoCopertura.attiva
                End If
            Next
        End Sub

        Public Sub ValidaSezioneSalvaPremio()
            SezioneSalvaPremio.Stato = StatoCopertura.esclusa
            For Each assicurato As assicurato In assicurati
                assicurato.ValidaSezioneSalvaPremio()
                If assicurato.CoperturaSalvaPremioBase.PremioAttivoCrudo > 0D Then
                    SezioneSalvaPremio.Stato = StatoCopertura.attiva
                End If
            Next
        End Sub

        Public Sub ValidaSezioneAssistenza()
            SezioneAssistenza.Stato = StatoCopertura.esclusa
            For Each assicurato As assicurato In assicurati
                assicurato.ValidaSezioneAssistenza()
                If assicurato.CoperturaAssistenzaBase.PremioAttivoCrudo > 0D Then
                    SezioneAssistenza.Stato = StatoCopertura.attiva
                End If
            Next
        End Sub

        Public Overrides Sub CalcolaSconti()
            Dim lordo As Decimal = SezioneInfortuni.PremioLordo + SezioneMalattia.PremioLordo + SezioneSalvaPremio.PremioLordo
            Dim netto As Decimal = SezioneInfortuni.PremioNetto + SezioneMalattia.PremioNetto + SezioneSalvaPremio.PremioNetto

            For Each assicurato In assicurati
                lordo -= assicurato.CoperturaInfortuniIPRenditaVitalizia.PremioAttivoLordo
                netto -= assicurato.CoperturaInfortuniIPRenditaVitalizia.PremioAttivoNetto
            Next

            ScontoPerPoliannualita.LordoDaScontare = lordo
            ScontoPerPoliannualita.NettoDaScontare = netto
            If Frazionamento <> FrazionamentiEnum.Temporaneo Then
                ScontoPerPoliannualita.PecentualeSconto = Scegli(Durata, 0D, 0.02D, 0.04D, 0.06D, 0.08D)
            Else
                ScontoPerPoliannualita.PecentualeSconto = 0D
            End If
            ScontoPerPoliannualita.calcola()

            ScontoPerNumeroAssicurati.LordoDaScontare = lordo
            ScontoPerNumeroAssicurati.NettoDaScontare = netto
            If assicurati.Count < 3 Then
                ScontoPerNumeroAssicurati.PecentualeSconto = 0D
            ElseIf assicurati.Count < 6 Then
                ScontoPerNumeroAssicurati.PecentualeSconto = 0.05D
            Else
                ScontoPerNumeroAssicurati.PecentualeSconto = 0.1D
            End If
            ScontoPerNumeroAssicurati.calcola()
        End Sub

        Public Sub Aggiungiassicurato(ByRef assicurato As assicurato)
            assicurati.Add(assicurato)
            CoperturaInfortuni.Coperture.Add(assicurato.CoperturaInfortuni)
            CoperturaMalattia.Coperture.Add(assicurato.CoperturaMalattia)
            CoperturaSalvaPremio.Coperture.Add(assicurato.CoperturaSalvaPremio)
            CoperturaAssistenza.Coperture.Add(assicurato.CoperturaAssistenza)
        End Sub

        Public Sub Rimuoviassicurato(ByRef assicurato As assicurato)
            assicurati.Remove(assicurato)
            CoperturaInfortuni.Coperture.Remove(assicurato.CoperturaInfortuni)
            CoperturaMalattia.Coperture.Remove(assicurato.CoperturaMalattia)
            CoperturaSalvaPremio.Coperture.Remove(assicurato.CoperturaSalvaPremio)
            CoperturaAssistenza.Coperture.Remove(assicurato.CoperturaAssistenza)
        End Sub

        Public Overrides Sub Stampa(ByVal options As StampaOptions)
            Dim s As New P01204ST
            Stampato = True
            s.StampaMostraEtInvia(Me, options)
        End Sub

    End Class
End Namespace
