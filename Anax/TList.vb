Public Class TList(Of T As TBase)
    Inherits List(Of T)

    Public Function IsNew() As Boolean
        For Each o As T In Me
            If Not o.IsNew Then Return False
        Next
        Return True
    End Function

    Public Function IsModifiedState() As Boolean
        For Each o As T In Me
            If o.IsModifiedState Then Return True
        Next
        Return False
    End Function

    Public Function Save() As Boolean
        For Each o As T In Me
            o.Save()
        Next
        Return True
    End Function

    Public Function IsValid() As Boolean
        For Each o As T In Me
            If Not o.IsValid Then Return False
        Next
        Return True
    End Function
End Class
