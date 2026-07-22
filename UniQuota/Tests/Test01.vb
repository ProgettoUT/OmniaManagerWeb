#If DEBUG Then
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization

<TestClass>
Public Class Test01

    Public TestContext As TestContext

    Sub TabellaRegioneProvinciaComune()
        For Each Comune In Luogo.Comuni
            Dim S As String = Comune.Regione.Nome & Comune.Provincia.Nome & Comune.Nome
            Debug.Print(S.Replace(" ", "").ToUpper & vbTab & Comune.CodiceIstat)
        Next
    End Sub


    <TestMethod>
    Sub ConverFile()
        Dim preventivo As Object

        Dim fs As FileStream = File.Open("C:\ApplicazioniDirezione\UT\Preventivi\DACATALOGARE\TUTTE LE GARANZIE_7263_636346885452255024.up", FileMode.Open)
        Dim bf As New BinaryFormatter()
        preventivo = bf.Deserialize(fs)
        fs.Close()


        fs = File.Open("C:\ApplicazioniDirezione\UT\Preventivi\DACATALOGARE\TUTTE LE GARANZIE_7263_636346885452255024.xml", FileMode.Create)
        Dim x As New XmlSerializer(preventivo.GetType)
        x.Serialize(fs, preventivo)
        fs.Close()

        Assert.IsTrue(True)
    End Sub


    '<TestMethod>
    Sub esportaCasaSmart()
        '02/07/2015: Da Umberto Troiani
        'Provvede a creare una estrazione tariffaria per scelta e provincia
        Dim p As New PSMART.smart
        Dim d As New PSMART.PSMARTDE

        p.Decode = d

        p.CoperturaCasaIncendio.Stato = StatoCopertura.attiva
        p.CoperturaCasaPoliennale.Stato = StatoCopertura.attiva
        p.CasaDurataPoliennale = PSMART.CasaDurataPoliennaleEnum.Anni3
        p.Frazionamento = FrazionamentiEnum.Mensile

        For Provincia As ProvinciaEnum = ProvinciaEnum.SiglaAG To ProvinciaEnum.SiglaVV
            System.Console.Write(Luogo.Province(Provincia).Sigla & ";" & Luogo.Province(Provincia).Nome & ";")
            p.Provincia = Provincia
            For CasaScelta As PSMART.CasaSceltaEnum = PSMART.CasaSceltaEnum.SceltaA To PSMART.CasaSceltaEnum.SceltaD
                p.CasaScelta = CasaScelta
                p.ValidaECalcola()

                System.Console.Write(FormatEuro(p.PremioPrimaRata) & ";")
            Next
            For CasaScelta As PSMART.CasaSceltaEnum = PSMART.CasaSceltaEnum.SceltaA To PSMART.CasaSceltaEnum.SceltaD
                p.CasaScelta = CasaScelta
                p.ValidaECalcola()

                System.Console.Write(FormatEuro(p.PremioLordo) & ";")
            Next
            System.Console.WriteLine()
        Next

        Assert.IsTrue(True)
    End Sub


    '<TestMethod>
    Sub infortuniSmart()

        Dim p As New PSMART.smart
        Dim d As New PSMART.PSMARTDE

        p.Decode = d

        p.CoperturaInfortuniBase.Stato = StatoCopertura.attiva


        '1)
        For Each frazionamento In {FrazionamentiEnum.Mensile, FrazionamentiEnum.Semestrale, FrazionamentiEnum.Annuale}
            p.Frazionamento = frazionamento

            For anno As Integer = 1 To 5
                p.CoperturaInfortuniPoliennale.Stato = IIf(anno = 1, StatoCopertura.esclusa, StatoCopertura.attiva)
                p.InfortuniDurataPoliennale = anno

                For InfortuniScelta As PSMART.InfortuniSceltaEnum = PSMART.InfortuniSceltaEnum.SceltaA To PSMART.InfortuniSceltaEnum.SceltaD
                    p.InfortuniScelta = InfortuniScelta
                    For statoFranchigia As StatoCopertura = StatoCopertura.esclusa To StatoCopertura.attiva Step -1
                        p.CoperturaInfortuniFranchigia.Stato = statoFranchigia
                        p.ValidaECalcola()
                        System.Console.Write(FormatEuro(p.PremioRata) & vbTab)
                    Next
                Next
                System.Console.WriteLine()
            Next
            System.Console.WriteLine()
        Next


        '1)
        For InfortuniScelta As PSMART.InfortuniSceltaEnum = PSMART.InfortuniSceltaEnum.SceltaA To PSMART.InfortuniSceltaEnum.SceltaD
            p.InfortuniScelta = InfortuniScelta
            System.Console.WriteLine(InfortuniScelta)

            For Each frazionamento In {FrazionamentiEnum.Mensile, FrazionamentiEnum.Semestrale, FrazionamentiEnum.Annuale}
                p.Frazionamento = frazionamento

                For anno As Integer = 1 To 5
                    p.CoperturaInfortuniPoliennale.Stato = IIf(anno = 1, StatoCopertura.esclusa, StatoCopertura.attiva)
                    p.InfortuniDurataPoliennale = anno

                    For statoFranchigia As StatoCopertura = StatoCopertura.esclusa To StatoCopertura.attiva Step -1
                        p.CoperturaInfortuniFranchigia.Stato = statoFranchigia
                        For i As Integer = 1 To 3
                            p.CoperturaInfortuniSpeseMediche.Stato = IIf(i = 2, StatoCopertura.esclusa, StatoCopertura.attiva)
                            p.CoperturaInfortuniDiarieDegenza.Stato = IIf(i = 1, StatoCopertura.esclusa, StatoCopertura.attiva)

                            p.ValidaECalcola()
                            System.Console.Write(FormatEuro(p.PremioRata) & vbTab)
                        Next
                    Next
                    System.Console.WriteLine()
                Next
            Next

            System.Console.WriteLine()
        Next

        Assert.IsTrue(True)

    End Sub
End Class
#End If
