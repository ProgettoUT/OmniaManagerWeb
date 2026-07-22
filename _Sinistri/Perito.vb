Public Class Perito

    Sub New()
    End Sub

    Private mCodice As Integer
    Public Property Codice() As String
        Get
            Return mCodice
        End Get
        Set(value As String)
            mCodice = value
        End Set
    End Property

    Private mNome As String
    Public Property Nome() As String
        Get
            Return mNome
        End Get
        Set(value As String)
            mNome = value
        End Set
    End Property

    Private mTelefono As String
    Public Property Telefono() As String
        Get
            Return mTelefono
        End Get
        Set(value As String)
            mTelefono = value
        End Set
    End Property

    Private mCellulare As String
    Public Property Cellulare() As String
        Get
            Return mCellulare
        End Get
        Set(value As String)
            mCellulare = value
        End Set
    End Property

    Private mEmail As String
    Public Property Email() As String
        Get
            Return mEmail
        End Get
        Set(value As String)
            mEmail = value
        End Set
    End Property

End Class
