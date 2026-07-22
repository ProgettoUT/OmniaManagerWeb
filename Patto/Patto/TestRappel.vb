#If DEBUG Then
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization

<TestClass>
Public Class TestRappel
    Public TestContext As TestContext

    <TestMethod>
    Public Sub FormRappel()
        Dim f As New FormRappel
        f.ShowDialog()
    End Sub


    <TestMethod>
    Public Sub TestRecuperoRappel()
        Dim RealizzazioneBudget As Decimal
        Dim RapportoSP As Decimal
        RapportoSP = 0.9
        RealizzazioneBudget = 0.9
        RecuperoRappel(RapportoSP, RealizzazioneBudget)
        Assert.IsTrue(RapportoSP = 0.9 And RealizzazioneBudget = 0.9)

        RapportoSP = 0.626
        RealizzazioneBudget = 1.026
        RecuperoRappel(RapportoSP, RealizzazioneBudget)
        Assert.IsTrue(RapportoSP = 0.6 And RealizzazioneBudget = 1)

        RapportoSP = 0.626
        RealizzazioneBudget = 1.126
        RecuperoRappel(RapportoSP, RealizzazioneBudget)
        Assert.IsTrue(RapportoSP = 0.6 And RealizzazioneBudget = 1.1)


        Assert.AreEqual(BudgetRimodulato(IncassoAnnoPrecedente:=100000, Budget:=110000, vitaOk:=False), 110000D)
        Assert.AreEqual(BudgetRimodulato(IncassoAnnoPrecedente:=100000, Budget:=110000, vitaOk:=True), 107000D)


        '•	Realizzazione del Budget assegnato in misura non inferiore al 95%
        '•	S/P pari o inferiore al 60% (al netto delle eccedenze sinistri) 

        Assert.AreEqual(MoltiplicatoreIncassiPrincipale(0.75), 0D)

        Assert.AreEqual(MoltiplicatoreIncassiPrincipale(0.8), 0D)

        Assert.AreEqual(MoltiplicatoreIncassiPrincipale(0.9), 0D)

        Assert.AreEqual(MoltiplicatoreIncassiPrincipale(0.95), 1D)

        Assert.AreEqual(MoltiplicatoreIncassiPrincipale(0.95), 1D)
        Assert.AreEqual(MoltiplicatoreIncassiPrincipale(0.96), 1D)
        Assert.AreEqual(MoltiplicatoreIncassiPrincipale(0.97), 1D)
        Assert.AreEqual(MoltiplicatoreIncassiPrincipale(0.98), 1D)
        Assert.AreEqual(MoltiplicatoreIncassiPrincipale(0.99), 1.1D)
        Assert.AreEqual(MoltiplicatoreIncassiPrincipale(1.01), 1.45D)

        Assert.AreEqual(AliquotaRappelPrincipale(0.7D), 0D)
        Assert.AreEqual(AliquotaRappelPrincipale(0.6D), 0.01D)
        Assert.AreEqual(AliquotaRappelPrincipale(0.5D), 0.0175D)
        Assert.AreEqual(AliquotaRappelPrincipale(0.4D), 0.0275D)
        Assert.AreEqual(AliquotaRappelPrincipale(0.3D), 0.04D)
        Assert.AreEqual(AliquotaRappelPrincipale(0.2D), 0.0525D)
        Assert.AreEqual(AliquotaRappelPrincipale(0.1D), 0.0525D)


        '•	Realizzazione del Budget assegnato in misura ≥80% e <95%
        '•	S/P Pari o inferiore al 50% (al netto delle eccedenze)

        Assert.AreEqual(MoltiplicatoreIncassiRedditivita(0.75), 0D)
        Assert.AreEqual(MoltiplicatoreIncassiRedditivita(0.8), 0.4D)
        Assert.AreEqual(MoltiplicatoreIncassiRedditivita(0.9), 0.4D)
        Assert.AreEqual(MoltiplicatoreIncassiRedditivita(0.94), 0.4D)
        Assert.AreEqual(MoltiplicatoreIncassiRedditivita(0.95), 0D)
        Assert.AreEqual(MoltiplicatoreIncassiRedditivita(0.96), 0D)
        Assert.AreEqual(MoltiplicatoreIncassiRedditivita(1.01), 0D)

        Assert.AreEqual(AliquotaRappelRedditivita(0.7D), 0D)
        Assert.AreEqual(AliquotaRappelRedditivita(0.6D), 0D)
        Assert.AreEqual(AliquotaRappelRedditivita(0.5D), 0.0175D)
        Assert.AreEqual(AliquotaRappelRedditivita(0.4D), 0.0275D)
        Assert.AreEqual(AliquotaRappelRedditivita(0.3D), 0.04D)
        Assert.AreEqual(AliquotaRappelRedditivita(0.2D), 0.0525D)
        Assert.AreEqual(AliquotaRappelRedditivita(0.1D), 0.0525D)

        Assert.AreEqual(RappelPrincipale(0.6D, 454369, 471926, 453755, False), 4537.55D)
        Assert.AreEqual(RappelPrincipale(0.6D, 454369, 471926, 453755, True), 4537.55D)
        Assert.AreEqual(RappelPrincipale(0.3D, 454369, 471926, 453755, True), 18150.2D)
        Assert.AreEqual(RappelPrincipale(0.3D, 454369, 471926, 483755, False), 33888.15D, 0.01)
        Assert.AreEqual(RappelPrincipale(0.3D, 454369, 471926, 483755, True), 38365.68D, 0.01)

        Assert.AreEqual(RappelPrincipale(0.63D, 454369, 471926, 483755, True), 6729.59D, 0.01)
        Assert.AreEqual(RappelPrincipale(0.64D, 454369, 471926, 483755, True), 0D, 0.01)


        Assert.AreEqual(RappelRCG(0.34D, 174404), 7848.18D, 0.01)
        Assert.AreEqual(RappelRCG(0.5D, 174404), 6104.14D, 0.01)
        Assert.AreEqual(RappelRCG(0.56D, 174404), 3488.08D, 0.01)
        Assert.AreEqual(RappelRCG(0.6D, 174404), 3488.08D, 0.01)
        Assert.AreEqual(RappelRCG(0.61D, 174404), 0D, 0.01)


        'Assert.AreEqual(RappelNazionaleRamiPersona(0.45D, 453755, 2017), 10890.12D, 0.01)
        'Assert.AreEqual(RappelNazionaleRamiPersona(0.5D, 453755, 2017), 8167.59D, 0.01)
        'Assert.AreEqual(RappelNazionaleRamiPersona(0.5D, 453755, 2019), 9075.1D, 0.01)
        'Assert.AreEqual(RappelNazionaleRamiPersona(0.57D, 453755, 2019), 0D, 0.01)

        'Assert.AreEqual(RappelNazionaleRamiAziende(0.58D, 92513, 2017), 2220.31D, 0.01)
        'Assert.AreEqual(RappelNazionaleRamiAziende(0.66D, 92513, 2017), 832.62D, 0.01)
        'Assert.AreEqual(RappelNazionaleRamiAziende(0.66D, 92513, 2020), 1480.21D, 0.01)
    End Sub



End Class
#End If
