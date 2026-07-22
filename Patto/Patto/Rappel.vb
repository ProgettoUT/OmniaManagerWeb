Module Rappel
    'Public Function RappelNazionaleRamiPersona(RapportoSP As Decimal, IncassoAnnoCorrente As Decimal, anno As Integer) As Decimal
    '    Dim aliquota As Decimal = AliquotaNazionaleRamiPersona(RapportoSP, anno)
    '    Dim rappel As Decimal = IncassoAnnoCorrente * aliquota
    '    Debug.WriteLine("")
    '    Debug.WriteLine("*************************************")
    '    Debug.WriteLine("RappelNazionaleRamiPersona")
    '    Debug.WriteLine("Aliquota: " & aliquota)
    '    Debug.WriteLine("Rappel Per: " & rappel)

    '    Return rappel
    'End Function

    Public Function RappelPesoIncassiRamiPersona(RapportoSP As Decimal, IncassoNazionale As Decimal, Peso As Decimal, anno As Integer) As Decimal
        Dim aliquota As Decimal = AliquotaNazionaleRamiPersona(RapportoSP, anno)
        Dim rappel As Decimal = IncassoNazionale * Peso * aliquota * 100
        FormRappel.Log.Info()
        FormRappel.Log.Info("RappelNazionaleIncassiRamiPersona")
        FormRappel.Log.Info("Aliquota: " & aliquota)
        FormRappel.Log.Info("Rappel Per: " & rappel)

        Return rappel
    End Function

    'Public Function RappelNazionaleRamiAziende(RapportoSP As Decimal, IncassoAnnoCorrente As Decimal, anno As Integer) As Decimal
    '    Dim aliquota As Decimal = AliquotaNazionaleRamiAziende(RapportoSP, anno)
    '    Dim rappel As Decimal = IncassoAnnoCorrente * aliquota
    '    Debug.WriteLine("")
    '    Debug.WriteLine("*************************************")
    '    Debug.WriteLine("AliquotaNazionaleRamiAziende")
    '    Debug.WriteLine("Aliquota: " & aliquota)
    '    Debug.WriteLine("Rappel Per: " & rappel)

    '    Return rappel
    'End Function

    Public Function RappelPesoIncassiRamiAziende(RapportoSP As Decimal, IncassoNazionale As Decimal, Peso As Decimal, anno As Integer) As Decimal
        Dim aliquota As Decimal = AliquotaNazionaleRamiAziende(RapportoSP, anno)
        Dim rappel As Decimal = IncassoNazionale * Peso * aliquota * 100
        FormRappel.Log.Info()
        FormRappel.Log.Info("AliquotaNazionaleIncassiRamiAziende")
        FormRappel.Log.Info("Aliquota: " & aliquota)
        FormRappel.Log.Info("Rappel Per: " & rappel)

        Return rappel
    End Function

    Public Function RappelRCG(RapportoSP As Decimal, IncassoAnnoCorrente As Decimal) As Decimal
        Dim aliquota As Decimal

        Select Case RapportoSP
            Case Is <= 0.4 : aliquota = 0.045D
            Case Is <= 0.45 : aliquota = 0.04D
            Case Is <= 0.5 : aliquota = 0.035D
            Case Is <= 0.55 : aliquota = 0.03D
            Case Is <= 0.6 : aliquota = 0.02D
            Case Else : aliquota = 0D
        End Select

        Dim rappel As Decimal = IncassoAnnoCorrente * aliquota
        FormRappel.Log.Info()
        FormRappel.Log.Info("RapportoSP: " & aliquota)
        FormRappel.Log.Info("IncassoAnnoCorrente: " & aliquota)
        FormRappel.Log.Info("Aliquota: " & aliquota)
        FormRappel.Log.Info("Rappel rcg: " & rappel)

        Return rappel
    End Function

    Public Function RappelPrincipale(RapportoSP As Decimal, IncassoAnnoPrecedente As Decimal, Budget As Decimal, IncassoAnnoCorrente As Decimal, vitaOk As Boolean, Optional ByRef incassoSuBadget As Decimal = 0) As Decimal
        FormRappel.Log.Info()

        'riduzione del 30% dell’incremento del Budget RE per le agenzie che raggiungono il 100% del Budget Vita Premi Annui
        Dim BudgetRimodulatoVita As Decimal = BudgetRimodulato(IncassoAnnoPrecedente, Budget, vitaOk)
        FormRappel.Log.Info("Budget     : " & Budget)
        FormRappel.Log.Info("Rimodulato : " & BudgetRimodulatoVita)

        If BudgetRimodulatoVita <> 0D Then
            incassoSuBadget = IncassoAnnoCorrente / BudgetRimodulatoVita
        Else
            incassoSuBadget = 0D
        End If

        FormRappel.Log.Info("Rapporto SP: " & RapportoSP)
        FormRappel.Log.Info("Perc budget: " & incassoSuBadget)

        'se S/P >60% e ≤65% 
        RecuperoRappel(RapportoSP, incassoSuBadget)
        FormRappel.Log.Info("Recupero")
        FormRappel.Log.Info("Rapporto SP: " & RapportoSP)
        FormRappel.Log.Info("Perc budget: " & incassoSuBadget)
        FormRappel.Log.Info("")
        FormRappel.Log.Info("Aliquota      : " & AliquotaRappelPrincipale(RapportoSP))
        FormRappel.Log.Info("Moltiplicatore: " & MoltiplicatoreIncassiPrincipale(incassoSuBadget))

        Dim rappel As Decimal = IncassoAnnoCorrente * AliquotaRappelPrincipale(RapportoSP) * MoltiplicatoreIncassiPrincipale(incassoSuBadget)
        FormRappel.Log.Info("Rappel Principale: " & rappel)
        Return rappel
    End Function

    Public Function BudgetRimodulato(IncassoAnnoPrecedente As Decimal, Budget As Decimal, vitaOk As Boolean) As Decimal
        If (vitaOk = True) And (Budget > IncassoAnnoPrecedente) Then
            Return 0.7 * Budget + 0.3 * IncassoAnnoPrecedente
        Else
            Return Budget
        End If
    End Function

    Public Function AliquotaRappelPrincipale(RapportoSP As Decimal) As Decimal
        'Per l’accesso al Rappel Principale è prevista una doppia soglia di accesso congiunta:
        '	S/P pari o inferiore al 60% (al netto delle eccedenze sinistri) 
        '	Realizzazione del Budget assegnato in misura non inferiore al 95%
        Select Case RapportoSP
            Case Is <= 0.2 : Return 0.0525D
            Case Is <= 0.3 : Return 0.04D + (0.3D - RapportoSP) * 0.125D
            Case Is <= 0.4 : Return 0.0275D + (0.4D - RapportoSP) * 0.125D
            Case Is <= 0.5 : Return 0.0175D + (0.5D - RapportoSP) * 0.1D
            Case Is <= 0.6 : Return 0.01D + (0.6D - RapportoSP) * 0.075D
            Case Else : Return 0D
        End Select
    End Function

    Public Function MoltiplicatoreIncassiPrincipale(RealizzazioneBudget As Decimal) As Decimal
        'Per l’accesso al Rappel Principale è prevista una doppia soglia di accesso congiunta:
        '	S/P pari o inferiore al 60% (al netto delle eccedenze sinistri) 
        '	Realizzazione del Budget assegnato in misura non inferiore al 95%
        Select Case RealizzazioneBudget
            Case Is > 1.05 : Return 2.3D
            Case Is > 1.04 : Return 2.05D + (RealizzazioneBudget - 1.04) * 25D
            Case Is > 1.01 : Return 1.45D + (RealizzazioneBudget - 1.01) * 20D
            Case Is > 0.99 : Return 1.1D + (RealizzazioneBudget - 0.99) * 17.5D
            Case Is > 0.98 : Return 1D + (RealizzazioneBudget - 0.98) * 10D
            Case Is >= 0.95 : Return 1D
            Case Else : Return 0D
        End Select
    End Function

    Public Function RappelRedditivita(RapportoSP As Decimal, IncassoAnnoPrecedente As Decimal, Budget As Decimal, IncassoAnnoCorrente As Decimal, vitaOk As Boolean) As Decimal
        FormRappel.Log.Info()

        'riduzione del 30% dell’incremento del Budget RE per le agenzie che raggiungono il 100% del Budget Vita Premi Annui
        Dim BudgetRimodulatoVita As Decimal = BudgetRimodulato(IncassoAnnoPrecedente, Budget, vitaOk)
        FormRappel.Log.Info("Budget     : " & Budget)
        FormRappel.Log.Info("Rimodulato : " & BudgetRimodulatoVita)

        Dim RealizzazioneBudget As Decimal = 0D
        If BudgetRimodulatoVita <> 0D Then
            RealizzazioneBudget = IncassoAnnoCorrente / BudgetRimodulatoVita
        End If

        FormRappel.Log.Info("Rapporto SP: " & RapportoSP)
        FormRappel.Log.Info("Perc budget: " & RealizzazioneBudget)

        Dim rappel As Decimal = IncassoAnnoCorrente * AliquotaRappelRedditivita(RapportoSP) * MoltiplicatoreIncassiRedditivita(RealizzazioneBudget)
        FormRappel.Log.Info("Rappel REDDITVITA: " & rappel)
        Return rappel
    End Function

    Public Function AliquotaRappelRedditivita(RapportoSP As Decimal) As Decimal
        'Per l 'accesso al Rappel REDDITVITA’ è prevista una doppia soglia di accesso:
        '	S/P Pari o inferiore al 50% (al netto delle eccedenze)
        '	Realizzazione del Budget assegnato in misura ≥80% e <95%

        Select Case RapportoSP
            Case Is <= 0.2 : Return 0.0525D
            Case Is <= 0.3 : Return 0.04D + (0.3D - RapportoSP) * 0.125D
            Case Is <= 0.4 : Return 0.0275D + (0.4D - RapportoSP) * 0.125D
            Case Is <= 0.5 : Return 0.0175D + (0.5D - RapportoSP) * 0.1D
            Case Else : Return 0D
        End Select
    End Function

    Public Function MoltiplicatoreIncassiRedditivita(RealizzazioneBudget As Decimal) As Decimal
        'Per l 'accesso al Rappel REDDITVITA’ è prevista una doppia soglia di accesso:
        '	S/P Pari o inferiore al 50% (al netto delle eccedenze)
        '	Realizzazione del Budget assegnato in misura ≥80% e <95%
        If RealizzazioneBudget >= 0.8 And RealizzazioneBudget < 0.95 Then
            Return 0.4D
        Else
            Return 0D
        End If
    End Function

    Public Sub RecuperoRappel(ByRef RapportoSP As Decimal, ByRef RealizzazioneBudget As Decimal)
        'Per le sole Agenzie con dato S/P >60% e ≤65% e con percentuale di raggiungimento 
        'del Budget superiore al 100%, il dato S/P viene corretto – in miglioramento - secondo 
        'il rapporto lineare tra il punto percentuale di S/P e il punto percentuale di realizzazione 
        'del budget, superiore al 100% (Ex: Budget conseguito 102,6%  Miglioramento S/P di 2,6%).

        If RapportoSP <= 0.6D Then Exit Sub
        If RapportoSP > 0.65D Then Exit Sub
        If RealizzazioneBudget <= 1D Then Exit Sub

        Dim miglioramentoSP As Decimal = RapportoSP - 0.6D
        Dim decrementoMaxBudget As Decimal = RealizzazioneBudget - 1D

        If miglioramentoSP > decrementoMaxBudget Then
            RapportoSP -= decrementoMaxBudget
            RealizzazioneBudget = 1D
        Else
            RapportoSP = 0.6D
            RealizzazioneBudget -= miglioramentoSP
        End If
    End Sub

    Public Function AliquotaNazionaleRamiPersona(RapportoSP As Decimal, anno As Integer) As Decimal
        Select Case anno
            Case < 2017
                Return 0
            Case 2017
                Select Case RapportoSP * 100
                    Case <= 48 : Return 0.024
                    Case <= 49 : Return 0.021
                    Case <= 50 : Return 0.018
                    Case <= 51 : Return 0.015
                    Case < 53 : Return 0.012
                    Case < 54 : Return 0.009
                    Case < 55 : Return 0.006
                    Case < 56 : Return 0.003
                    Case >= 56 : Return 0
                End Select
            Case 2018
                Select Case RapportoSP * 100
                    Case <= 47 : Return 0.026
                    Case <= 48 : Return 0.025
                    Case <= 49 : Return 0.022
                    Case <= 50 : Return 0.019
                    Case <= 51 : Return 0.016
                    Case < 53 : Return 0.013
                    Case < 54 : Return 0.01
                    Case < 55 : Return 0.007
                    Case < 56 : Return 0.004
                    Case < 57 : Return 0.001
                    Case >= 57 : Return 0
                End Select
            Case 2019
                Select Case RapportoSP * 100
                    Case <= 47 : Return 0.028
                    Case <= 48 : Return 0.026
                    Case <= 49 : Return 0.023
                    Case <= 50 : Return 0.02
                    Case <= 51 : Return 0.017
                    Case < 53 : Return 0.014
                    Case < 54 : Return 0.011
                    Case < 55 : Return 0.008
                    Case < 56 : Return 0.005
                    Case < 57 : Return 0.002
                    Case >= 57 : Return 0
                End Select
            Case >= 2020
                Select Case RapportoSP * 100
                    Case <= 45 : Return 0.038
                    Case <= 46 : Return 0.037
                    Case <= 47 : Return 0.034
                    Case <= 48 : Return 0.031
                    Case <= 49 : Return 0.028
                    Case <= 50 : Return 0.025
                    Case <= 51 : Return 0.022
                    Case < 53 : Return 0.019
                    Case < 54 : Return 0.016
                    Case < 55 : Return 0.013
                    Case < 56 : Return 0.01
                    Case < 57 : Return 0.007
                    Case < 58 : Return 0.004
                    Case < 59 : Return 0.001
                    Case >= 59 : Return 0
                End Select
        End Select
    End Function

    Public Function AliquotaNazionaleRamiAziende(RapportoSP As Decimal, anno As Integer) As Decimal
        Select Case anno
            Case < 2017
                Return 0
            Case 2017
                Select Case RapportoSP * 100
                    Case <= 61 : Return 0.024
                    Case <= 62 : Return 0.021
                    Case <= 63 : Return 0.018
                    Case <= 64 : Return 0.015
                    Case < 66 : Return 0.012
                    Case < 67 : Return 0.009
                    Case < 68 : Return 0.006
                    Case < 69 : Return 0.003
                    Case >= 69 : Return 0
                End Select
            Case 2018
                Select Case RapportoSP * 100
                    Case <= 60 : Return 0.026
                    Case <= 61 : Return 0.025
                    Case <= 62 : Return 0.022
                    Case <= 63 : Return 0.019
                    Case <= 64 : Return 0.016
                    Case < 66 : Return 0.013
                    Case < 67 : Return 0.01
                    Case < 68 : Return 0.007
                    Case < 69 : Return 0.004
                    Case < 70 : Return 0.001
                    Case >= 70 : Return 0
                End Select
            Case 2019
                Select Case RapportoSP * 100
                    Case <= 60 : Return 0.028
                    Case <= 61 : Return 0.026
                    Case <= 62 : Return 0.023
                    Case <= 63 : Return 0.02
                    Case <= 64 : Return 0.017
                    Case < 66 : Return 0.014
                    Case < 67 : Return 0.011
                    Case < 68 : Return 0.008
                    Case < 69 : Return 0.005
                    Case < 70 : Return 0.002
                    Case >= 70 : Return 0
                End Select
            Case >= 2020
                Select Case RapportoSP * 100
                    Case <= 58 : Return 0.038
                    Case <= 59 : Return 0.037
                    Case <= 60 : Return 0.034
                    Case <= 61 : Return 0.031
                    Case <= 62 : Return 0.028
                    Case <= 63 : Return 0.025
                    Case <= 64 : Return 0.022
                    Case < 66 : Return 0.019
                    Case < 67 : Return 0.016
                    Case < 68 : Return 0.013
                    Case < 69 : Return 0.01
                    Case < 70 : Return 0.007
                    Case < 71 : Return 0.004
                    Case < 72 : Return 0.001
                    Case >= 72 : Return 0
                End Select
        End Select
    End Function
End Module