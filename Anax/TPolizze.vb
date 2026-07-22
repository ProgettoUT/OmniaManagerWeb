Public Class TPolizze
    Inherits _TPolizze

    Public Const FORMATO_POLIZZA As String = "000000000"
    Public Const FORMATO_RAMO As String = "000"

    Public Overrides Function ToString() As String
        Return Format(MyBase.Ramo, FORMATO_RAMO) & "-" & Format(MyBase.Polizza, FORMATO_POLIZZA)
    End Function

End Class
