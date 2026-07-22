Class Tabella
    Public Nome As String
    Public Operazione As String
    Public Campi As New Campi
    Public TabellaIsOk As Boolean
    Public PerOccorrenzaDi As String

    Public IfNotNull As String
    Public IfTag As String

    Private mValue As String
    Private mTipoOpe As TipoOperazioneEnum

    Private Enum TipoOperazioneEnum
        ifEquals
        ifNotEquals
        ifInList
    End Enum

    Public Property NotEquals() As String
        Get
            Return mValue
        End Get
        Set(value As String)
            If value <> vbNullString Then
                mTipoOpe = TipoOperazioneEnum.ifNotEquals
                mValue = value
            End If
        End Set
    End Property

    Public Property InList() As String
        Get
            Return mValue
        End Get
        Set(value As String)
            If value <> vbNullString Then
                mTipoOpe = TipoOperazioneEnum.ifInList
                mValue = value
            End If
        End Set
    End Property

    Public Shadows Property Equals() As String
        Get
            Return mValue
        End Get
        Set(value As String)
            If value <> vbNullString Then
                mTipoOpe = TipoOperazioneEnum.ifEquals
                mValue = value
            End If

        End Set
    End Property

    Public Function ImportaIsOk() As Boolean
        Dim c As Campo
        ImportaIsOk = True

        If IfNotNull <> "" Then
            c = Campi(IfNotNull)

            If c.ValoreIsNull Then
                ImportaIsOk = False
            End If

        End If
        If IfTag <> "" Then
            c = Campi(IfTag)

            If mTipoOpe = TipoOperazioneEnum.ifNotEquals Then
                If c.Valore = mValue Then
                    ImportaIsOk = False
                End If
            ElseIf mTipoOpe = TipoOperazioneEnum.ifInList Then
                ImportaIsOk = False
                If c.Valore <> vbNullString Then
                    Dim i As Object
                    For Each i In Split(mValue, ";")
                        If c.Valore = i Then
                            ImportaIsOk = True
                            Exit For
                        End If
                    Next
                End If
            ElseIf c.Valore <> mValue Then
                ImportaIsOk = False
            End If
        End If
    End Function


End Class
