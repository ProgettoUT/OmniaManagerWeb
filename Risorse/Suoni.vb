Public Class Suoni

    Public Enum SuoniUt
        OK
        BOING
        CASH
        CONNECT
        BUSY
    End Enum

    Public Shared Sub Suona(Key As SuoniUt)
        On Error Resume Next
        My.Computer.Audio.Play(Suono(Key), AudioPlayMode.Background)
    End Sub

    Private Shared Function Suono(Key As SuoniUt) As IO.Stream
        Return My.Resources.ResourceManager.GetObject(Key.ToString.ToLower, My.Resources.Culture())
    End Function
End Class
