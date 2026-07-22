Public Class Incasso

    Sub New()
    End Sub

    Public Sub New(ByVal Ramo As String,
                   ByVal Polizza As String,
                   ByVal Importo As Double,
                   ByVal Nome As String)
        mRamo = Ramo
        mPolizza = Polizza
        mImporto = Importo
        mNome = Nome
    End Sub

    Public ReadOnly Property DeskIncasso() As String
        Get
            Return String.Format("{0}/{1} - {2}: {3:F2}", mRamo, mPolizza, Left(mNome, 30), mImporto)
        End Get
    End Property

    Private mRamo As String
    Public Property Ramo() As String
        Get
            Return mRamo
        End Get
        Set(ByVal value As String)
            mRamo = value
        End Set
    End Property

    Private mPolizza As String
    Public Property Polizza() As String
        Get
            Return mPolizza
        End Get
        Set(ByVal value As String)
            mPolizza = value
        End Set
    End Property

    Private mNome As String
    Public Property Nome() As String
        Get
            Return mNome
        End Get
        Set(ByVal value As String)
            mNome = value
        End Set
    End Property

    Private mImporto As Double
    Public Property Importo() As Double
        Get
            Return mImporto
        End Get
        Set(ByVal value As Double)
            mImporto = value
        End Set
    End Property

End Class
