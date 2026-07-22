Namespace P01262
    Public Class P01262ST
        Inherits P00000ST

        Public Overrides Sub Stampa(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
            VerticaleUno = 95
            tab(1) = VerticaleUno

            With CType(preventivo, SpeseMediche)
                Dim decode As P01262DE = CType(preventivo.Decode, P01262DE)

                StampaInizio(preventivo, options)

                Dim n As Integer = 0
                For Each assicurato As assicurato In .assicurati
                    n += 1
                    If n Mod 2 = 1 Then
                        StampaIntestazionePagina(preventivo, options)
                        StampaDettaglioInizio(preventivo, options)
                    End If
                    StampaCoperture(New CoperturaStampa(assicurato.CoperturaMalattia + assicurato.CoperturaAssistenza),
                                    Trim(assicurato.Nominativo & " (" & assicurato.Eta & " anni)"), options)
                    StampaDettaglioFine(preventivo, options)
                Next

                StampaDettaglioFine(preventivo, options)

                StampaRiepilogoPremi(preventivo, options)

                StampaFine(preventivo, options)
            End With
        End Sub
    End Class
End Namespace
