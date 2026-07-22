'Gli importi sono riferiti all'importo lordo

<Serializable()> Public Class Sconto
    Public Descrizione As String
    <NonSerialized()> Public PecentualeSconto As Decimal
    <NonSerialized()> Public LordoDaScontare As Decimal
    <NonSerialized()> Public NettoDaScontare As Decimal

    <NonSerialized()> Private mLordoSconto As Decimal
    <NonSerialized()> Private mNettoSconto As Decimal
    <NonSerialized()> Private mTasseSconto As Decimal

    Public Sub New(Descrizione As String)
        Me.Descrizione = Descrizione
    End Sub

    Public ReadOnly Property LordoSconto() As Decimal
        Get
            Return mLordoSconto
        End Get
    End Property

    Public ReadOnly Property NettoSconto() As Decimal
        Get
            Return mNettoSconto
        End Get
    End Property

    Public ReadOnly Property TasseSconto() As Decimal
        Get
            Return mTasseSconto
        End Get
    End Property

    Public Sub Calcola()
        mLordoSconto = PecentualeSconto * LordoDaScontare
        mNettoSconto = PecentualeSconto * NettoDaScontare
        mTasseSconto = mLordoSconto - mNettoSconto
    End Sub

    Public Sub Imposta(LordoSconto As Decimal, NettoSconto As Decimal)
        mLordoSconto = LordoSconto
        mNettoSconto = NettoSconto
        mTasseSconto = mLordoSconto - mNettoSconto
    End Sub
End Class
