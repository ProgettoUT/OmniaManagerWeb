Public Class TPolizza
    Inherits _TPolizza

    Public ReadOnly Property PromemoriaLink() As String
        Get
            If DataScadenza = Date.MinValue And DataDisdetta = Date.MinValue Then
                Return ""
            ElseIf DataPromemoria = Date.MinValue Then
                Return "Ricordamelo"
            Else
                Return DataPromemoria
            End If
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return MyBase.Polizza
    End Function
End Class
