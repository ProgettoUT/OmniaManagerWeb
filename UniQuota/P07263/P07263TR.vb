Namespace P07263
    Public Class P07263TR
        Inherits P00000TR

        Sub New()
            MyBase.New("P07263TR", 1000000)
        End Sub

        Public Function getTassoTerremotoContenuto(ByVal codiceIstat As Integer, ByVal limite As Decimal, ByVal antisismico As AntisismicoEnum, ByVal TipologiaCostruzione As TipologiaCostruzioneEnum) As Single
            Return getTassoTerremoto(codiceIstat, limite, antisismico, TipologiaCostruzione, False)
        End Function
        Public Function getTassoTerremotoFabbricato(ByVal codiceIstat As Integer, ByVal limite As Decimal, ByVal antisismico As AntisismicoEnum, ByVal TipologiaCostruzione As TipologiaCostruzioneEnum) As Single
            Return getTassoTerremoto(codiceIstat, limite, antisismico, TipologiaCostruzione, True)
        End Function

        Private Function getTassoTerremoto(ByVal codiceIstat As Integer, ByVal limite As Decimal, ByVal antisismico As AntisismicoEnum, ByVal TipologiaCostruzione As TipologiaCostruzioneEnum, ByVal fabbricato As Boolean) As Single

            Dim indice As Integer = 0

            If antisismico = AntisismicoEnum.SI Then
                indice = 2
            ElseIf TipologiaCostruzione = TipologiaCostruzioneEnum.Muratura Then
                indice = 0
            ElseIf TipologiaCostruzione = TipologiaCostruzioneEnum.CementoArmato Then
                indice = 1
            ElseIf TipologiaCostruzione = TipologiaCostruzioneEnum.Bioedilizia Then
                indice = 3
            ElseIf TipologiaCostruzione = TipologiaCostruzioneEnum.Legno Then
                indice = 3
            End If

            If fabbricato Then
                indice *= 2
                If limite = 100 Then
                    indice += 1
                End If
            Else
                indice += 8
            End If

            Return getTasso(CStr(codiceIstat), indice)
        End Function
    End Class
End Namespace
