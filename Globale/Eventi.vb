Public Class Eventi

    Public Shared Event ApriStrumenti()

    Public Shared Sub Strumenti()
        RaiseEvent ApriStrumenti()
    End Sub
End Class
