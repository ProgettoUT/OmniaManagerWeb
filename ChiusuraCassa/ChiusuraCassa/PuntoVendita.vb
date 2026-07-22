Public Class PuntoVendita

    Public mCodice As Integer
    Public mDescrizione As String
    Public mCodiceEssig As Integer

    Sub New()
    End Sub

    Sub New(Codice As Integer,
            Descrizione As String,
            CodiceEssig As Integer)

        mCodice = Codice
        mDescrizione = Descrizione
        mCodiceEssig = CodiceEssig
    End Sub

    Property Descrizione() As String
        Get
            Descrizione = mDescrizione
        End Get
        Set(Value As String)
            mDescrizione = Value
        End Set
    End Property

    ReadOnly Property DescrizioneEx() As String
        Get
            DescrizioneEx = String.Format("{0}. {1}", mCodice.ToString.PadLeft(2, "0"), mDescrizione)
        End Get
    End Property

    Property Codice() As Integer
        Get
            Codice = mCodice
        End Get
        Set(Value As Integer)
            mCodice = Value
        End Set
    End Property

    Property CodiceEssig() As Integer
        Get
            CodiceEssig = mCodiceEssig
        End Get
        Set(Value As Integer)
            mCodiceEssig = Value
        End Set
    End Property

End Class
