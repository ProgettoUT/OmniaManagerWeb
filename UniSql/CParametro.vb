Public Class CParametro

    Public Enum EParamType
        PT_INTERO
        PT_VIRGOLA
        PT_STRINGA
        PT_DATA
        PT_BOOLEAN
    End Enum

    Public Enum EEditType
        ET_EDIT
        ET_LIST
        ET_SQL
    End Enum

    Public Property Nome As String
    Public Property Etichetta As String
    Public Property ParamType As EParamType
    Public Property Valore As String
    Public Property EditType As EEditType
    Public Property Obbligatorio As Boolean
    Public Property Nascosto As Boolean
    Public Property Sinistra As Long
    Public Property Larghezza As Long
    Public Property NuovaRiga As Boolean
    Public Property Altezza As Long
    Public Property MultiValore As Boolean 'Controllo List
    Public Property EditaValore As Boolean 'Controllo combobox editabile

    Public ReadOnly Property Key() As String
        Get
            Return _Nome
        End Get
    End Property

    Public Sub ParseParamType(ByRef vNewValue As String)
        Select Case LCase(vNewValue)
            Case "string" : _ParamType = EParamType.PT_STRINGA        '1, 13 To 16
            Case "integer" : _ParamType = EParamType.PT_INTERO        '2, 3, 4, 12, 17
            Case "date" : _ParamType = EParamType.PT_DATA             '9, 10, 11
            Case "float" : _ParamType = EParamType.PT_VIRGOLA         '7
            Case "boolean" : _ParamType = EParamType.PT_BOOLEAN       '5
            Case Else : _ParamType = EParamType.PT_STRINGA
        End Select
    End Sub

    Public Function ParamTypeAsString() As String
        Select Case _paramType
            Case EParamType.PT_STRINGA : Return "string"
            Case EParamType.PT_INTERO : Return "integer"
            Case EParamType.PT_DATA : Return "date"
            Case EParamType.PT_VIRGOLA : Return "float"
            Case EParamType.PT_BOOLEAN : Return "boolean"
            Case Else : Return "string"
        End Select
    End Function

    Private _Elencovalori As String
    Public Property Elencovalori() As String
        Get
            Return _Elencovalori
        End Get
        Set(value As String)
            _Elencovalori = value

            If value = vbNullString Then
                _EditType = EEditType.ET_EDIT
            ElseIf value.ToUpper.StartsWith("SELECT ") Then
                _EditType = EEditType.ET_SQL
            Else
                _EditType = EEditType.ET_LIST
            End If
        End Set
    End Property


    Public Function CheckParam(sValue As String) As Boolean
        Select Case _ParamType
            Case EParamType.PT_STRINGA
                Return True
            Case EParamType.PT_DATA
                Return IsDate(sValue)
            Case EParamType.PT_BOOLEAN
                Return (sValue = "true") Or (sValue = "false")
            Case EParamType.PT_INTERO, EParamType.PT_VIRGOLA
                Return IsNumeric(sValue)
        End Select
        Return False
    End Function

    Public Function ReplaceParam() As String
        Dim sParVal As String = ""

        If Me.Valore = vbNullString Then
            Select Case Me.ParamType
                Case EParamType.PT_STRINGA : sParVal = Utx.FunzioniDb.TO_STRING(Me.Valore)
                Case EParamType.PT_INTERO : sParVal = Utx.FunzioniDb.TO_NUMBER(Me.Valore)
                Case EParamType.PT_DATA : sParVal = Utx.FunzioniDb.TO_DATE(Me.Valore)
                Case EParamType.PT_VIRGOLA : sParVal = Utx.FunzioniDb.TO_NUMBER(Me.Valore)
                Case EParamType.PT_BOOLEAN : sParVal = Utx.FunzioniDb.TO_NUMBER(Me.Valore)
            End Select

            Return sParVal
        Else
            ReplaceParam = ""
            For Each value As String In Split(Me.Valore, ", ")
                Select Case Me.ParamType
                    Case EParamType.PT_STRINGA : sParVal = Utx.FunzioniDb.TO_STRING(value)
                    Case EParamType.PT_INTERO : sParVal = Utx.FunzioniDb.TO_NUMBER(value)
                    Case EParamType.PT_DATA : sParVal = Utx.FunzioniDb.TO_DATE(value)
                    Case EParamType.PT_VIRGOLA : sParVal = Utx.FunzioniDb.TO_NUMBER(value)
                    Case EParamType.PT_BOOLEAN : sParVal = Utx.FunzioniDb.TO_NUMBER(value)
                End Select

                ReplaceParam &= ", " & sParVal
            Next

            Return ReplaceParam.Substring(1)
        End If

    End Function

    Public Function IsIndipendence(Optional parName As String = "") As Boolean
        If _EditType = EEditType.ET_SQL And InStr(1, _Elencovalori, "@" & parName, vbTextCompare) > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

End Class
