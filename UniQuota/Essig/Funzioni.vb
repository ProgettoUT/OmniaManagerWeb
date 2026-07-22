Public Class Funzioni
    Private nfi As Globalization.NumberFormatInfo = New Globalization.CultureInfo("it-IT", False).NumberFormat

    Public Function Standard(ByVal valore As Object) As String
        If valore Is Nothing Then
            Return ""
        ElseIf TypeOf valore Is Boolean Then
            If valore.Equals(True) Then
                Return "S"
            Else
                Return "N"
            End If
        ElseIf TypeOf valore Is Decimal Then
            Return CType(valore, Decimal).ToString("N", nfi)
        ElseIf TypeOf valore Is Partita Then
            Return CType(valore, Partita).SommaAssicurata.ToString("N", nfi)
        ElseIf TypeOf valore Is Copertura Then
            If CType(valore, Copertura).IsAttivo Then
                Return "1"
            Else
                Return ""
            End If
        ElseIf TypeOf valore Is [Enum] Then
            Return CStr(valore)
        Else
            Return valore.ToString
        End If
    End Function
    Public Function Oggi(ByVal valore As Object) As String
        Return Today.ToString("dd/MM/yyyy")
    End Function
    Public Function UnAnnoOggi(ByVal valore As Object) As String
        Return Today.AddYears(1).ToString("dd/MM/yyyy")
    End Function
    Public Function AlfabetaEnum(ByVal valore As Integer) As String
        '1=A, 2=B, 3=C, ...
        If valore = 0 Then
            Return ""
        Else
            Return Chr(64 + valore)
        End If
    End Function

    Public Function BoolToSiOrNo(ByVal valore As Object) As String
        If valore.Equals(True) Then
            Return "SI"
        Else
            Return "NO"
        End If
    End Function

    Public Function Frazionamento(ByVal valore As FrazionamentiEnum) As String
        Select Case valore
            Case FrazionamentiEnum.Personalizzato
                Return "R"
            Case Else
                Return CStr(valore)
        End Select
    End Function
End Class

Public Module altrefunzioni
    Public Enum ErrorCodeEnum
        NoError = 0
        NoSession = 1
        AbendError = 2
        ApplicarionError = 3
    End Enum

    Public Function NoError(html As String) As Boolean
        If ErrorCode(html) = ErrorCodeEnum.NoError Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ErrorCode(html As String) As ErrorCodeEnum
        If html Is Nothing Then
            Return ErrorCodeEnum.NoSession
        ElseIf html.IndexOf("<title>Log-in</title>") > 0 Then
            Return ErrorCodeEnum.NoSession
        ElseIf html.IndexOf("Errore non previsto") > 0 Then
            Return ErrorCodeEnum.AbendError
        ElseIf html.IndexOf("emissioneErrorView") > 0 Then
            Return ErrorCodeEnum.ApplicarionError
        Else
            Return ErrorCodeEnum.NoError
        End If
    End Function

End Module
