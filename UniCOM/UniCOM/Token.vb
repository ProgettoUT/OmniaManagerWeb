Public Class Token

    'lista dei token utilizzati in unitools
    Public Const ListaTokenUnitools As String = "#cognome#;#nome#;#scadenza#;#targa#;#modello#;#infopolizza#"

    Sub New(Key As String,
            Valore As Object)
        Try
            _Key = Key

            If IsDate(Valore) Then
                _Valore = Valore
            Else
                'il valore può essere null (esempio: campo scadenza)
                If Valore Is DBNull.Value Then
                    _Valore = ""
                Else
                    _Valore = Valore
                End If
            End If

        Catch ex As Exception
            _Valore = ""
        End Try
    End Sub

    Private _Key As String
    Public Property Key() As String
        Get
            Return _Key
        End Get
        Set(ByVal value As String)
            _Key = value.ToLower
        End Set
    End Property

    Private _Valore As String
    Public Property Valore() As String
        Get
            Return _Valore
        End Get
        Set(ByVal value As String)
            _Valore = value
        End Set
    End Property
End Class
