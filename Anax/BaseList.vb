Public Class BaseList(Of T As {TBase, New})

    Public Function GetList(campoTest As String, sWhere As String, Optional minRow As Integer = 0) As TList(Of T)
        If campoTest = vbNullString Then
            Return GetEmptyList(minRow)
        Else
            Return GetList(sWhere, minRow)
        End If
    End Function

    Public Function GetEmptyList(Optional minRow As Integer = 0) As TList(Of T)
        Dim lista As New TList(Of T)
        Dim item As New T

        Do Until lista.Count >= minRow
            item = New T()
            lista.Add(item)
        Loop

        Return lista
    End Function

    Public Function GetList(Optional minRow As Integer = 0) As TList(Of T)
        Return GetList("", minRow)
    End Function

    Public Function GetList(sWhere As String, Optional minRow As Integer = 0) As TList(Of T)
        Dim lista As New TList(Of T)
        Dim item As New T

        Dim rs As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(String.Format("SELECT * FROM {0} {1}", item.Tabella, sWhere))
        Do While rs.Read
            item = New T()
            If item.GetFields(rs) Then
                lista.Add(item)
            End If
        Loop

        Do Until lista.Count >= minRow
            item = New T()
            lista.Add(item)
        Loop

        rs.Close()
        rs = Nothing

        Return lista
    End Function
End Class
