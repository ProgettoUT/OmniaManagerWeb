Public Class TFinanzaCose
    Inherits _TFinanzaCose

    Public Property DesServizio As String


    Public Overrides Function GetFields(rs As System.Data.DataTableReader) As Boolean
        Dim columnIndex As Integer = 0
        With rs
            If .HasRows Then
                columnIndex = .GetOrdinal("DesServizio")
                If Not .IsDBNull(columnIndex) Then
                    DesServizio = .GetValue(columnIndex)
                End If
            End If
        End With

        Return MyBase.GetFields(rs)
    End Function

End Class
