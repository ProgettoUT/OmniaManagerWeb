Class Campi
    Inherits Dictionary(Of String, Campo)

    Public Function Clone() As Campi
        Dim oCampi As New Campi

        For Each oCampo In Me.Values
            oCampi.Add(oCampo.Nome, oCampo.Clone)
        Next
        Return oCampi
    End Function


    Public Sub WriteValore()
        For Each c In Me.Values
            c.WriteValore()
        Next
    End Sub
End Class
