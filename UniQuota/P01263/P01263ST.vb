Namespace P01263
    Public Class P01263ST
        Inherits P00000ST

        Public Overrides Sub Stampa(ByVal preventivo As Prodotto, ByVal options As StampaOptions)

            VerticaleUno = 95
            tab(1) = VerticaleUno


            With CType(preventivo, Ricovero)
                Dim decode As P01263DE = CType(preventivo.Decode, P01263DE)

                StampaInizio(preventivo, options)

                Dim n As Integer = 0
                For Each assicurato As assicurato In .assicurati
                    n += 1
                    If n Mod 4 = 1 Then
                        StampaIntestazionePagina(preventivo, options)
                        StampaDettaglioInizio(preventivo, options)
                    End If


                    StampaCoperture(New CoperturaStampa(assicurato.CoperturaMalattia + assicurato.CoperturaAssistenza),
                                    Trim(assicurato.Nominativo & " (" & assicurato.Eta & " anni)"),
                                    "Formula " & decode.DecodeFormulaSezione(assicurato.FormulaSezione), options)
                    StampaDettaglioFine(preventivo, options)
                Next

                StampaDettaglioFine(preventivo, options)

                StampaRiepilogoPremi(preventivo, options)

                StampaFine(preventivo, options)
            End With
        End Sub
    End Class
End Namespace
