Module Funzioni

    'VB.NET to convert a string to a byte array
    Public Function StrToByteArray(str As String) As Byte()
        Dim encoding As New System.Text.UTF8Encoding()
        Return encoding.GetBytes(str)
    End Function 'StrToByteArray

    'VB.NET to convert a byte array to a string:
    Public Function ByteArrayToStr(dBytes As Byte()) As String
        Dim enc As New System.Text.UTF8Encoding()
        Return enc.GetString(dBytes)
    End Function

End Module
