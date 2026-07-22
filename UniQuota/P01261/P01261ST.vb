Namespace P01261
    Public Class P01261ST
        Inherits P00000ST

        Public Overrides Sub Stampa(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
            VerticaleUno = 125
            tab(1) = VerticaleUno

            With CType(preventivo, Invalidita)
                Dim decode As P01261DE = CType(preventivo.Decode, P01261DE)

                StampaInizio(preventivo, options)


                Dim n As Integer = 0
                For Each assicurato As assicurato In .assicurati
                    n += 1
                    If n Mod 7 = 1 Then
                        StampaIntestazionePagina(preventivo, options)
                        StampaDettaglioInizio(preventivo, options)
                    End If


                    StampaCoperture(New CoperturaStampa(assicurato.CoperturaMalattia + assicurato.CoperturaAssistenza),
                                    Trim(assicurato.Nominativo & " (" & assicurato.Eta & " anni)"),
                                    "Formula " & decode.DecodeCriterioLiquidazioneIPM(assicurato.CriterioLiquidazioneIPM), options)
                    StampaDettaglioFine(preventivo, options)
                Next

                StampaDettaglioFine(preventivo, options)
                StampaRiepilogoPremi(preventivo, options)
                StampaFine(preventivo, options)
            End With
        End Sub
    End Class
End Namespace
