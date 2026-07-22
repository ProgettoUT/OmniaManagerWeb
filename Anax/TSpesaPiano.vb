Public Class TSpesaPiano
    Inherits _TSpesaPiano

    Public Property Descrizione As String
    Public Property Dettaglio As String

    Public Overrides Function GetFields(rs As System.Data.DataTableReader) As Boolean
        Dim columnIndex As Integer = 0
        With rs
            If .HasRows Then
                columnIndex = .GetOrdinal("Descrizione")
                If Not .IsDBNull(columnIndex) Then
                    Descrizione = .GetValue(columnIndex)
                End If

                columnIndex = .GetOrdinal("Dettaglio")
                If Not .IsDBNull(columnIndex) Then
                    Dettaglio = .GetValue(columnIndex)
                End If
            End If
        End With

        Return MyBase.GetFields(rs)
    End Function

End Class
