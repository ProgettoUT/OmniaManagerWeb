Namespace P01204
    Public Class P01204ST
        Inherits P00000ST

        Public Overrides Sub Stampa(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
            VerticaleUno = 125
            tab(1) = VerticaleUno

            With CType(preventivo, InfortuniPremium)
                Dim decode As P01204DE = CType(preventivo.Decode, P01204DE)

                StampaInizio(preventivo, options)

                For Each assicurato As assicurato In .assicurati
                    assicurato.CoperturaInfortuniIP.Parametro1 = decode.DecodeInfortuniIPScelta(assicurato.InfortuniIPScelta)
                    assicurato.CoperturaSportAgonistico.Parametro1 = decode.DecodeSportClasseRischio(assicurato.SportClasseRischio)
                    assicurato.CoperturaInfortuniRicoveroConvalescenza.Parametro1 = decode.DecodeRicoveroConvalescenzaScelta(assicurato.InfortuniRicoveroConvalescenzaScelta)
                    assicurato.CoperturaSportAgonisticoRicoveroConvalescenza.Parametro1 = decode.DecodeRicoveroConvalescenzaScelta(assicurato.SportAgonisticoRicoveroConvalescenzaScelta)
                    assicurato.CoperturaSportAltoRischioRicoveroConvalescenza.Parametro1 = decode.DecodeRicoveroConvalescenzaScelta(assicurato.SportAltoRischioRicoveroConvalescenzaScelta)
                    assicurato.CoperturaSportAereiRicoveroConvalescenza.Parametro1 = decode.DecodeRicoveroConvalescenzaScelta(assicurato.SportAereiRicoveroConvalescenzaScelta)
                    assicurato.CoperturaSportMotoRicoveroConvalescenza.Parametro1 = decode.DecodeRicoveroConvalescenzaScelta(assicurato.SportMotoRicoveroConvalescenzaScelta)
                    assicurato.CoperturaInfortuniIT.Parametro1 = decode.DecodeInfortuniITScelta(assicurato.InfortuniITScelta)
                    assicurato.CoperturaMalattiaRicoveroConvalescenza.Parametro1 = decode.DecodeRicoveroConvalescenzaScelta(assicurato.MalattiaRicoveroConvalescenzaScelta)

                    StampaIntestazionePagina(preventivo, options)
                    StampaParametri(
                                    "Assicurato", assicurato.Nominativo,
                                    "Età", assicurato.Eta,
                                    "Tipo contraente", decode.DecodeTipoContraente(assicurato.TipoContraente),
                                    "Forma copertura", decode.DecodeFormaCopertura(assicurato.FormaCopertura),
                                    "Tipo rapporto", decode.DecodeTipoRapporto(assicurato.TipoRapporto),
                                    "Attivita", P01204TG.GetAttivita().Item(assicurato.CodiceAttivita).Descrizione,
                                    "Descrizione", assicurato.Descrizione,
                                    "Note", preventivo.Note)

                    StampaDettaglioInizio(preventivo, options)
                    StampaCoperture(assicurato.CoperturaInfortuni, "INFORTUNI", options)

                    StampaCoperture(New CoperturaStampa(assicurato.CoperturaMalattiaRicoveroConvalescenza + assicurato.CoperturaSalvaPremioBase + assicurato.CoperturaAssistenzaBase), "MALATTIA\SALVAPREMIO\ASSISTENZA", options)
                    StampaDettaglioFine(preventivo, options)
                Next

                StampaIntestazionePagina(preventivo, options)
                StampaSezioneCliente(preventivo, options)
                StampaRiepilogoPremi(preventivo, options)

                StampaFine(preventivo, options)
            End With
        End Sub
    End Class
End Namespace
