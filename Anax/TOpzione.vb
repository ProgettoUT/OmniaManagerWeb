Public Class TOpzione
    Inherits _TOpzione

    Public ReadOnly Property DoubleValore() As Double
        Get
            Return CDbl(Valore)
        End Get
    End Property

    Public ReadOnly Property IntegerValore() As Integer
        Get
            Return CInt(Valore)
        End Get
    End Property

    Public ReadOnly Property DateValore() As Date
        Get
            Return CDate(Valore)
        End Get
    End Property
End Class

