Public Class Sezione

    Public mCodice As String
    Public mDescrizione As String

    Sub New(Codice As String,
            Descrizione As String)

        mCodice = Codice
        mDescrizione = Descrizione
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
            DescrizioneEx = String.Format("{0}. {1}", mCodice, mDescrizione)
        End Get
    End Property

    Property Codice() As String
        Get
            Codice = mCodice
        End Get
        Set(Value As String)
            mCodice = Value
        End Set
    End Property

End Class
