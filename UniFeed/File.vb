Class File
    Public ReadOnly Tracciati As New Tracciati
    Public FilePatterns As String
    Public mSelectCase As String
    Public SelectCaseStart As Integer
    Public SelectCaseLength As Integer
    Public TipoFile As TipoFileEnum

    Private mUseSelectCase As Boolean
    Private mUseLengthCase As Boolean

    Public Enum TipoFileEnum
        TipoFileTesto = 0
        TipoFileExcel = 1
    End Enum

    Public Property SelectCase() As String
        Get
            Return mSelectCase
        End Get
        Set(value As String)
            mSelectCase = value

            If mSelectCase <> vbNullString Then
                Dim s() As String
                s = Split(mSelectCase, ",")
                SelectCaseStart = CInt(s(0))
                If UBound(s) = 1 Then
                    SelectCaseLength = CInt(s(1))
                End If
            End If
            mUseSelectCase = True
        End Set
    End Property

    Public Function GetTracciatoByInput(sRow As String) As Tracciato
        Dim sKeyTracciato As String
        Dim tracciato As Tracciato = Nothing

        If mUseSelectCase Then
            sKeyTracciato = "/" & Mid(sRow, SelectCaseStart, SelectCaseLength) & "/L" & Len(sRow)
            If Tracciati.ContainsKey(sKeyTracciato) Then
                tracciato = Tracciati(sKeyTracciato)
            End If

            If tracciato Is Nothing Then
                sKeyTracciato = "/" & Mid(sRow, SelectCaseStart, SelectCaseLength)
                If Tracciati.ContainsKey(sKeyTracciato) Then
                    tracciato = Tracciati(sKeyTracciato)
                End If
            End If
        Else
            sKeyTracciato = "/L" & Len(sRow)
            If tracciato Is Nothing And Tracciati.Count = 1 Then
                tracciato = Tracciati(1)
            End If
        End If

        Return tracciato
    End Function

    Public Function GetTipoRecord(sRow As String) As String

        If mUseSelectCase Then
            Return Mid(sRow, SelectCaseStart, SelectCaseLength)
        Else
            Return "/L" & Len(sRow)
        End If

    End Function
End Class
