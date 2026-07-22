Module mgrFile
    Public CARTELLA_TEMP As String

    Public Function ReadFileAsString(Filename As String) As String
        Return My.Computer.FileSystem.ReadAllText(Filename)
    End Function

    Public Function WriteStringAsFile(Filename As String, file As String) As Boolean
        My.Computer.FileSystem.WriteAllText(Filename, file, False)
        Return True
    End Function

    Public Function maCreateTempFile(sPrefix As String, sSuffix As String) As String
        Dim temp As String = System.IO.Path.GetTempFileName()
        Dim originalFile As String = CARTELLA_TEMP + sPrefix + System.IO.Path.GetFileName(temp)
        Dim newFile As String = System.IO.Path.ChangeExtension(originalFile, sSuffix)
        Return newFile
    End Function

    Public Function RC43(inp() As Byte, Job As Boolean) As String
        Dim i As Integer
        Dim j As Integer
        Dim temp As Byte
        Dim Y As Integer
        Dim t As Integer
        Dim Outp As String = ""
        Dim TempOutPut As Integer

        Const Key As String = "unitools"
        Const Length As Integer = 256

        Static ss(Length - 1) As Byte
        Static k(Length - 1) As Byte
        Static inizializzato As Boolean

        If Not inizializzato Then
            For i = 0 To (Length - 1)
                ss(i) = i
            Next
            inizializzato = True

            j = 1
            For i = 0 To (Length - 1)
                If j > Len(Key) Then j = 1
                k(i) = Asc(Mid(Key, j, 1))
                j += 1
            Next i

            j = 0
            For i = 0 To (Length - 1)
                j = (j + ss(i) + k(i)) Mod (Length)
                temp = ss(i)
                ss(i) = ss(j)
                ss(j) = temp
            Next i
        End If

        Dim s(Length - 1) As Byte
        For i = 0 To (Length - 1)
            s(i) = ss(i)
        Next

        i = 0
        j = 0
        For X As Integer = 4 To inp.Length - 1  'Len(inp)
            i = (i + 1) Mod (Length)
            j = (j + s(i)) Mod (Length)
            temp = s(i)
            s(i) = s(j)
            s(j) = temp
            t = (0 + s(i) + s(j)) Mod (Length)
            Y = s(t)

            TempOutPut = inp(X) ' (Asc(Mid(inp, X, 1)))

            If Job = True Then
                Outp &= Chr((TempOutPut + Y) Mod Length)
            ElseIf TempOutPut < Y Then
                Outp &= Chr(Length + TempOutPut - Y)
            Else
                Outp &= Chr(TempOutPut - Y)
            End If

        Next
        RC43 = Outp
    End Function
End Module
