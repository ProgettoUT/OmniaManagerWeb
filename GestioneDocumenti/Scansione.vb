Public Class Scansione

    Public Enum TipoScansione
        Nuovo = 0
        Accoda = 1
    End Enum

    Public Enum StatoScansione
        InCorso = 0
        InPausa = 1
        Finita = 2
        Annulla = 3
    End Enum

    Dim mStato As StatoScansione
    Dim mTipo As TipoScansione

    Sub New(Tipo As TipoScansione)
        mTipo = Tipo
        mStato = StatoScansione.InCorso
    End Sub

    Public Property Stato() As StatoScansione
        Get
            Return mStato
        End Get
        Set(value As StatoScansione)
            mStato = value
        End Set
    End Property

    Public ReadOnly Property Tipo() As TipoScansione
        Get
            Return mTipo
        End Get
    End Property

End Class
