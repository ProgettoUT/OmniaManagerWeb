Namespace P07263
    Public Class P07263TA
        Inherits P00000TR

        Sub New()
            MyBase.New("P07263TA", 100000)
        End Sub

        Public Function getTassoAlluvione(ByVal provincia As String, ByVal TipoAbitazione As TipoAbitazioneEnum, ByVal gruppo As Integer) As Single

            Dim indice As Integer = gruppo - 1

            If TipoAbitazione = TipoAbitazioneEnum.Appartamento Then
                indice += 4
            End If

            Return getTasso(provincia, indice)
        End Function
    End Class
End Namespace
