Public Class Destinatario

    Sub New()
        _Cognome = ""
        _Nome = ""
        _Telefono = ""
    End Sub

    Sub New(Cognome As String,
            Nome As String,
            Telefono As String)

        _Cognome = Cognome
        _Nome = Nome
        _Telefono = Telefono
    End Sub

    Private _Cognome As String
    Public Property Cognome() As String
        Get
            Return _Cognome
        End Get
        Set(value As String)
            _Cognome = value
        End Set
    End Property

    Private _Nome As String
    Public Property Nome() As String
        Get
            Return _Nome
        End Get
        Set(value As String)
            _Nome = value
        End Set
    End Property

    Private _Telefono As String
    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(value As String)
            _Telefono = value
        End Set
    End Property

    Public ReadOnly Property NomeCompleto() As String
        Get
            Return String.Format("{0} {1}", _Cognome.Trim, _Nome.Trim)
        End Get
    End Property

    Private _Tokens As New List(Of Token)
    Public ReadOnly Property Tokens() As List(Of Token)
        Get
            Return _Tokens
        End Get
    End Property

    'Public Sub AddToken(Token As Token)
    '    _Tokens.Add(Token)
    'End Sub

    Public Sub AddTokens(Dati As DataRow, TokenUtilizzati As List(Of String))
        For Each t As String In TokenUtilizzati
            _Tokens.Add(New Token("#" + t + "#", Dati(t)))
        Next
    End Sub

    Public Sub Reset()
        _Cognome = ""
        _Nome = ""
        _Telefono = ""
        _Tokens.Clear()
    End Sub
End Class
