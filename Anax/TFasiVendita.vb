Public Class TFasiVendita
    Inherits _TFasiVendita

    Public Property Idioma As String

    Public Overrides Function GetFields(rs As System.Data.DataTableReader) As Boolean
        Dim columnIndex As Integer = 0
        With rs
            If .HasRows Then
                columnIndex = .GetOrdinal("Idioma")
                If Not .IsDBNull(columnIndex) Then
                    Idioma = .GetValue(columnIndex)
                End If
            End If
        End With

        If MyBase.GetFields(rs) Then
            If Data = Date.MinValue AndAlso Utente = Nothing Then
                SetStateEmpty()
            End If
            Return True
        Else
            Return False
        End If
    End Function

End Class
