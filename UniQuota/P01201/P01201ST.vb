Namespace P01201
    Public Class P01201ST
        Inherits P00000ST

        Public Overrides Sub Stampa(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
            VerticaleUno = 125
            tab(1) = VerticaleUno

            With CType(preventivo, YouInfortuni)
                Dim decode As P01201DE = CType(preventivo.Decode, P01201DE)
                If .CoperturaPersonaBase.PremioCrudo > 0 Then
                    .CoperturaPersonaBase.Parametro1 = "(premio combinazione capitali fissi)"
                End If
                If .CoperturaFamigliaBase.PremioCrudo > 0 Then
                    .CoperturaFamigliaBase.Parametro1 = "(premio combinazione capitali fissi)"
                End If
                If .CoperturaVeicoloBase.PremioCrudo > 0 Then
                    .CoperturaVeicoloBase.Parametro1 = "(premio combinazione capitali fissi)"
                End If

                .CoperturaPersonaIT.Parametro1 = decode.DecodePersonaITForma(.PersonaITForma)
                .CoperturaPersonaRicovero.Parametro1 = decode.DecodePersonaRicoveroForma(.PersonaRicoveroForma)
                .CoperturaPersonaImmobilizzazione.Parametro1 = decode.DecodePersonaImmobilizzazioneForma(.PersonaImmobilizzazioneForma)
                .CoperturaVeicoloRicovero.Parametro1 = decode.DecodeVeicoloRicoveroForma(.VeicoloRicoveroForma)
                .CoperturaMalattiaInabilitaTemporanea.Parametro1 = decode.DecodeMalattiaITSceltaForma(.MalattiaITSceltaForma)
                .CoperturaMalattiaRicovero.Parametro1 = decode.DecodeMalattiaRicoveroSceltaForma(.MalattiaRicoveroSceltaForma)
                .CoperturaAssistenzaBase.Parametro1 = decode.DecodeAssistenzaPacchetto(.AssistenzaPacchetto)

                StampaInizio(preventivo, options)

                StampaIntestazionePagina(preventivo, options)
                StampaSezioneCliente(preventivo, options)
                StampaParametri(decode.DecodeAttivitaProfessionale(.AttivitaProfessionale) & " (anni " & .AssicuratoEta & ")", "", "", decode.DecodeTipoAttivita(.TipoAttivita))

                StampaDettaglioInizio(preventivo, options)
                StampaSezione(.SezionePersona, "PERSONA - " & decode.DecodePersonaSceltaForma(.PersonaSceltaForma), options)
                StampaSezione(.SezioneFamiglia, "FAMIGLIA - " & decode.DecodeFamigliaSceltaForma(.FamigliaSceltaForma), options)
                StampaSezione(.SezioneMalattia, options)
                StampaSezione(.SezioneAssistenza, options)
                StampaDettaglioFine(preventivo, options)

                StampaIntestazionePagina(preventivo, options)
                StampaSezioneCliente(preventivo, options)
                StampaParametri("Tipologia Veicolo", decode.DecodeTipologiaVeicolo(.TipologiaVeicolo))

                StampaDettaglioInizio(preventivo, options)
                StampaSezione(.SezioneVeicolo, "VEICOLO - " & decode.DecodeVeicoloSceltaForma(.VeicoloSceltaForma), options)
                StampaDettaglioFine(preventivo, options)

                StampaRiepilogoPremi(preventivo, options)

                StampaFine(preventivo, options)
            End With
        End Sub
    End Class
End Namespace
