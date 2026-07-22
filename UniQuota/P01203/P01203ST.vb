Namespace P01203
    Public Class P01203ST
        Inherits P00000ST

        Public Overrides Sub Stampa(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
            VerticaleUno = 125
            tab(1) = VerticaleUno

            With CType(preventivo, Circolazione)
                Dim decode As P01203DE = CType(preventivo.Decode, P01203DE)

                StampaInizio(preventivo, options)

                StampaIntestazionePagina(preventivo, options)
                StampaSezioneCliente(preventivo, options)

                StampaParametri("Tipo soggetto", decode.DecodeTipoSoggetto(.TipoSoggetto), _
                                "Modalità", decode.DecodeInfortuniScelta(.InfortuniScelta), _
                                "Tipologia veicolo", decode.DecodeTipologiaVeicolo(.TipologiaVeicolo), _
                                "Forma", decode.DecodeInfortuniForma(.InfortuniForma))

                .CoperturaScontiBase.Parametro0 = decode.DecodeScontoPoliennale(.ScontoPoliennale)

                StampaDettaglioInizio(preventivo, options)

                Dim coperture As New CoperturaStampa(.SezioneInfortuni.Coperture + .CoperturaSalvaCircolazioneBase + .CoperturaAssistenzaBase + .CoperturaScontiBase)
                StampaCoperture(coperture, .SezioneInfortuni.Descrizione, options)

                StampaDettaglioFine(preventivo, options)
                StampaRiepilogoPremi(preventivo, options)
                StampaFine(preventivo, options)
            End With
        End Sub
    End Class
End Namespace
