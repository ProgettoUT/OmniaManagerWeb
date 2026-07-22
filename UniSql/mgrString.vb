Module mgrString
    Public Function BoolToString(value As Boolean) As String
        If value Then
            BoolToString = "true"
        Else
            BoolToString = "false"
        End If
    End Function

    Public Function StringToBool(value As String) As Boolean
        If value = "true" Then
            StringToBool = True
        Else
            StringToBool = False
        End If
    End Function

    Public Function ExistsKey(coll As Collection, sKey As String) As Boolean
        Return coll.Contains(sKey)
    End Function
End Module
