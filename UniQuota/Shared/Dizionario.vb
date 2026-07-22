Public Class Dizionario(Of TKey, TValue)
    Inherits Dictionary(Of TKey, TValue)

    Default Public Overloads Property Item(ByVal key As TKey) As TValue
        Get
            Try
                Return MyBase.Item(key)
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(ByVal value As TValue)
            MyBase.Item(key) = value
        End Set
    End Property

End Class

