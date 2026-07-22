Public Class TEvidenza
    Inherits _TEvidenza


    Public Shadows Property DataRiferimento() As DateTime
        Get
            If MyBase.DataRiferimento = Date.MinValue Then
                Return MyBase.DataApertura
            Else
                Return MyBase.DataRiferimento
            End If
        End Get
        Set(value As DateTime)
            MyBase.DataRiferimento = value
        End Set
    End Property

End Class
