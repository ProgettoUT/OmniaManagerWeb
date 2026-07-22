Namespace P01203
    Public Class P01203TR
        Inherits P00000TR

        Sub New()
            MyBase.New("P01203TR", 100) '6
        End Sub

        Public Function getPremio(ByVal InfortuniScelta As InfortuniSceltaEnum, ByVal frazionamento As Integer, ByVal combinazione As InfortuniFormaEnum, ByVal poliennale As ScontoPoliennaleEnum) As Single
            'InfortuniScelta: P-persona, F-famiglia, V-veicolo
            'frazionamento: A-annuale, S-semestrale, M-mensile
            'Combinazione: 1-8

            'poliennale 1-5

            Dim key As String = ""

            Select Case InfortuniScelta
                Case InfortuniSceltaEnum.SceltaPersona : key &= "P"
                Case InfortuniSceltaEnum.SceltaFamiglia : key &= "F"
                Case InfortuniSceltaEnum.SceltaVeicolo : key &= "V"

            End Select

            Select Case frazionamento
                Case FrazionamentiEnum.Annuale : key &= "A"
                Case FrazionamentiEnum.Semestrale : key &= "S"
                Case FrazionamentiEnum.Mensile : key &= "M"
            End Select

            key &= combinazione

            Return getTasso(key, poliennale)
        End Function
    End Class
End Namespace