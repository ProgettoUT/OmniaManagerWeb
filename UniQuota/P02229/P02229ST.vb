Namespace P02229
    Public Class P02229ST
        Inherits P00000ST

        Public Overrides Sub Stampa(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
            VerticaleUno = 125
            tab(1) = VerticaleUno

            With CType(preventivo, YouIngegnereArchitetto)
                Dim decode As P02229DE = CType(preventivo.Decode, P02229DE)

                .CoperturaResponsabilitaCivileBase.Parametro1 = "Franchigia base € " & FormatEuro(5000D)
                .CoperturaResponsabilitaCivileScontoDiff.Parametro1 = "sconto max € " & FormatEuro(.ResponsabilitaCivileScontoMax)

                StampaInizio(preventivo, options)

                StampaIntestazionePagina(preventivo, options)
                StampaSezioneCliente(preventivo, options)
                StampaParametri(decode.DecodeAttivitaProfessionale(.AttivitaProfessionale), "", "Fasce introiti", decode.DecodeFasceIntroiti(.FasceIntroiti))
                StampaDettaglioInizio(preventivo, options)
                StampaSezione(.SezioneResponsabilitaCivile, options)
                StampaSezione(.SezioneIncendio, options)
                StampaSezione(.SezioneTutelaLegale, options)
                StampaSezione(.SezioneInterruzioneProfessione, options)
                StampaSezione(.SezioneSconto, options)
                StampaDettaglioFine(preventivo, options)

                StampaRiepilogoPremi(preventivo, options)

                StampaFine(preventivo, options)
            End With
        End Sub
    End Class
End Namespace
