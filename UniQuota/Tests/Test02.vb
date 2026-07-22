#If DEBUG Then
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Namespace P01262

    <TestClass>
    Public Class Test02

        Public TestContext As TestContext

        '<TestMethod>
        Sub RimborsoSpeseMediche()

            Dim p As New SpeseMediche
            p.Decode = New P01262DE
            p.Inizializza()

            Dim a As New assicurato(p)
            p.DescrizioniCoperture(a.CoperturaMalattia.CopertureSingole)
            p.Aggiungiassicurato(a)

            With a
                .CoperturaMalattia.Stato = StatoCopertura.attiva
                .CoperturaMalattiaSupplementari.Stato = StatoCopertura.esclusa
                .CoperturaMalattiaFranchigia.Stato = StatoCopertura.esclusa
                .CoperturaMalattiaFormaNucleoFamiliare.Stato = StatoCopertura.esclusa
            End With

            a.CoperturaMalattiaRicovero.Stato = StatoCopertura.attiva
            a.CoperturaMalattiaGicGem.Stato = StatoCopertura.esclusa
            p.ZonaTerritoriale = ZonaTerritorialeEnum.Zona0
            a.Eta = 44
            Verifica(a, 1, 854.4D)
            Verifica(a, 2, 1005.34D)
            Verifica(a, 3, 1105.88D)
            'Verifica(a, 4, 1327.05D - 2D)
            Verifica(a, 4, 1327.05D)

            p.ZonaTerritoriale = ZonaTerritorialeEnum.Zona1
            a.Eta = 22
            Verifica(a, 1, 0D)
            Verifica(a, 2, 677.65D)
            Verifica(a, 3, 745.42D)
            Verifica(a, 4, 894.5D)

            p.ZonaTerritoriale = ZonaTerritorialeEnum.Zona2
            a.Eta = 11
            Verifica(a, 1, 0D)
            Verifica(a, 2, 432.67D)
            Verifica(a, 3, 475.93D)
            Verifica(a, 4, 571.12D)

            a.CoperturaMalattiaSupplementari.Stato = StatoCopertura.attiva
            p.ZonaTerritoriale = ZonaTerritorialeEnum.Zona0
            a.Eta = 44
            Verifica(a, 1, 854.4D + 483.49D)
            Verifica(a, 2, 1005.34D + 483.49D)
            Verifica(a, 3, 1105.88D + 483.49D)
            Verifica(a, 4, 1327.05D + 483.49D - 1D)

            p.ZonaTerritoriale = ZonaTerritorialeEnum.Zona1
            a.Eta = 22
            Verifica(a, 1, 0D + 0D)
            Verifica(a, 2, 677.65D + 325.92D)
            Verifica(a, 3, 745.42D + 325.92D)
            Verifica(a, 4, 894.5D + 325.92D)

            p.ZonaTerritoriale = ZonaTerritorialeEnum.Zona2
            a.Eta = 11
            Verifica(a, 1, 0D + 0D)
            Verifica(a, 2, 432.67D + 208.09D)
            Verifica(a, 3, 475.93D + 208.09D)
            Verifica(a, 4, 571.12D + 208.09D)

            a.CoperturaMalattiaRicovero.Stato = StatoCopertura.esclusa
            a.CoperturaMalattiaGicGem.Stato = StatoCopertura.attiva

            p.ZonaTerritoriale = ZonaTerritorialeEnum.Zona0
            a.Eta = 18
            Verifica(a, 0, 168.11D)

            p.ZonaTerritoriale = ZonaTerritorialeEnum.Zona1
            a.Eta = 30
            Verifica(a, 0, 374.78D)

            p.ZonaTerritoriale = ZonaTerritorialeEnum.Zona2
            a.Eta = 70
            Verifica(a, 0, 1228.02D)


            a.CoperturaMalattiaRicovero.Stato = StatoCopertura.attiva
            a.CoperturaMalattiaSupplementari.Stato = StatoCopertura.esclusa
            a.CoperturaMalattiaGicGem.Stato = StatoCopertura.esclusa
            p.ZonaTerritoriale = ZonaTerritorialeEnum.Zona0
            a.Eta = 44

            'due assicurati identici
            Dim b As New assicurato(p)
            p.DescrizioniCoperture(b.CoperturaMalattia.CopertureSingole)
            p.Aggiungiassicurato(b)
            b.Eta = 44

            'Verifica(a, 1, 0.95D * 2 * 854.4D + 1D)
            Verifica(a, 1, 0.95D * 2 * 854.4D)
            Verifica(a, 2, 0.95D * 2 * 1005.34D)
            Verifica(a, 3, 0.95D * 2 * 1105.88D)
            'Verifica(a, 4, 0.95D * 2 * 1327.05D - 3D)
            Verifica(a, 4, 0.95D * 2 * 1327.05D)

        End Sub

        Private Sub Verifica(a As assicurato, combinazione As Integer, importo As Decimal)
            Static count As Integer
            Dim p As SpeseMediche = a.SpeseMediche

            count += 1
            a.CoperturaMalattiaRicovero.Garanzia.Combinazione = combinazione
            p.ValidaECalcola()
            'If count = 28 Then
            '    p.CalcolaLog()
            '    System.Console.Write(logCalcolo)
            'End If
            Assert.IsTrue(Math.Abs(p.PremioLordo - importo) < 1, "{0}) premio lordo {1} <> dal premio previsto {2}", count, p.PremioLordo, importo)
        End Sub

    End Class
End Namespace
#End If
