Namespace Essig
    Public Class Lista
        Inherits List(Of Elemento)

        Public Shared Function From(ByVal array(,) As String) As Lista
            Dim lista As New Lista

            If array.GetLength(1) = 2 Then
                For i As Integer = 0 To array.GetLength(0) - 1
                    lista.Add(New Elemento(array(i, 0), array(i, 1)))
                Next
            End If
            Return lista
        End Function

        Public Shared Function From(ByVal table As String) As Lista
            Dim lista As New Lista

            For Each row As String() In P00000TG.getTable(table)
                lista.Add(New Elemento(row))
            Next

            Return lista
        End Function
    End Class
End Namespace
