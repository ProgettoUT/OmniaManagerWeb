Public Class Risoluzione

    Private mRisoluzione As Integer

    Sub New(Risoluzione As Integer)
        mRisoluzione = Risoluzione
    End Sub

    Public ReadOnly Property Risoluzione() As Integer
        Get
            Return mRisoluzione
        End Get
    End Property

    Public ReadOnly Property Descrizione() As String
        Get
            Return String.Format("Risoluzione {0} dpi", mRisoluzione)
        End Get
    End Property
End Class
