Public Class Immagini

    Public Shared ReadOnly Property Image(Key As String) As System.Drawing.Bitmap
        Get
            Dim obj As Object = My.Resources.ResourceManager.GetObject(Key.ToLower, My.Resources.Culture())
            If obj IsNot Nothing Then
                Return obj
            Else
                Return My.Resources.ResourceManager.GetObject("logo_error", My.Resources.Culture())
            End If
        End Get
    End Property
    Public Shared ReadOnly Property Bitmap(Key As String) As System.Drawing.Bitmap
        Get
            Dim obj As Object = Icon(Key.ToLower).ToBitmap
            If obj IsNot Nothing Then
                Return obj
            Else
                Return Icon("_error").ToBitmap
            End If
        End Get
    End Property
    Public Shared ReadOnly Property Icon(Key As String) As System.Drawing.Icon
        Get
            Dim obj As Object = My.Resources.ResourceManager.GetObject(Key.ToLower, My.Resources.Culture())
            If obj IsNot Nothing Then
                Return CType(obj, System.Drawing.Icon)
            Else
                obj = My.Resources.ResourceManager.GetObject("_error", My.Resources.Culture())
                Return CType(obj, System.Drawing.Icon)
            End If
        End Get
    End Property
End Class
