Class Campo

    Public CampoOk As Boolean
    Public CampoChiave As Boolean
    Public NomeChiave As String
    Public Occorrenze As Integer = 1
    Public Posizione As Integer
    Public Lunghezza As Integer
    Public Scala As Integer
    Public Categoria As CategoriaDatoEnum
    Public Campi As New Campi
    Public TipoFormato As TipoFormatoEnum
    Public Storicizzare As Boolean

    Public mNome As String
    Public mNomeRif As String
    Public mTipoDato As Integer
    Public mFormato As String
    Public mValore As String
    Public mDefaultSeNullo As String
    Public HasDefault As Boolean = False

    Public Enum TipoFormatoEnum
        FORMATO_NESSUNO = 0
        FORMATO_AAAAMMGG
        FORMATO_GG_MM_AAAA
        FORMATO_DATETIME
        FORMATO_9x_9y
        FORMATO_9x_9yS
        FORMATO_S9x_9y
        FORMATO_9xV9y
        FORMATO_NOSPACES
    End Enum

    Public Enum CategoriaDatoEnum
        CategoriaNumerico
        CategoriaStringa
        CategoriaData
    End Enum

    Public ReadOnly Property ValoreIsNull() As Boolean
        Get
            Select Case Categoria
                Case CategoriaDatoEnum.CategoriaStringa
                    ValoreIsNull = False
                Case CategoriaDatoEnum.CategoriaNumerico
                    ValoreIsNull = False
                Case CategoriaDatoEnum.CategoriaData
                    If Valore = "00000000" Then
                        ValoreIsNull = True
                    ElseIf Valore Like "00.00.0000" Then
                        ValoreIsNull = True
                    ElseIf Valore Like "00/00/0000" Then
                        ValoreIsNull = True
                    ElseIf Valore Like "00-00-0000" Then
                        ValoreIsNull = True
                    ElseIf Valore Like "01/01/1900" Then
                        ValoreIsNull = True
                    ElseIf Trim(Valore) = vbNullString Then
                        ValoreIsNull = True
                    End If
                Case Else
                    If Trim(Valore) = vbNullString Then
                        ValoreIsNull = True
                    End If
            End Select

            Return ValoreIsNull
        End Get
    End Property

    Public ReadOnly Property CampoCalcolato() As Boolean
        Get
            Return (NomeChiave <> vbNullString)
        End Get
    End Property

    Public Property Nome() As String
        Get
            Return mNome
        End Get
        Set(value As String)
            mNome = value
            NomeRif = value
        End Set
    End Property

    Public Property NomeRif() As String
        Get
            Return mnomerif
        End Get
        Set(value As String)
            If value <> vbNullString Then
                mNomeRif = value
            End If
        End Set
    End Property

    Public Property DefaultSeNullo() As String
        Get
            Return mDefaultSeNullo
        End Get
        Set(value As String)
            If String.IsNullOrEmpty(value) = False Then
                mDefaultSeNullo = value
                HasDefault = True
            End If
        End Set
    End Property

    Public Property TipoDato() As Integer
        Get
            Return mTipoDato
        End Get
        Set(value As Integer)
            mTipoDato = value

            Select Case mTipoDato
                Case OleDb.OleDbType.Empty : Categoria = CategoriaDatoEnum.CategoriaStringa
                Case OleDb.OleDbType.Integer : Categoria = CategoriaDatoEnum.CategoriaNumerico
                Case OleDb.OleDbType.Currency : Categoria = CategoriaDatoEnum.CategoriaNumerico
                Case OleDb.OleDbType.Date : Categoria = CategoriaDatoEnum.CategoriaData
                Case OleDb.OleDbType.VarChar : Categoria = CategoriaDatoEnum.CategoriaStringa
                Case OleDb.OleDbType.Char : Categoria = CategoriaDatoEnum.CategoriaStringa

                Case OleDb.OleDbType.BigInt : Categoria = CategoriaDatoEnum.CategoriaNumerico
                Case OleDb.OleDbType.Boolean : Categoria = CategoriaDatoEnum.CategoriaNumerico
                Case OleDb.OleDbType.Decimal : Categoria = CategoriaDatoEnum.CategoriaNumerico
                Case OleDb.OleDbType.Double : Categoria = CategoriaDatoEnum.CategoriaNumerico
                Case OleDb.OleDbType.Numeric : Categoria = CategoriaDatoEnum.CategoriaNumerico
                Case OleDb.OleDbType.Single : Categoria = CategoriaDatoEnum.CategoriaNumerico
                Case OleDb.OleDbType.SmallInt : Categoria = CategoriaDatoEnum.CategoriaNumerico
                Case OleDb.OleDbType.TinyInt : Categoria = CategoriaDatoEnum.CategoriaNumerico
                Case OleDb.OleDbType.UnsignedBigInt : Categoria = CategoriaDatoEnum.CategoriaNumerico
                Case OleDb.OleDbType.UnsignedInt : Categoria = CategoriaDatoEnum.CategoriaNumerico
                Case OleDb.OleDbType.UnsignedSmallInt : Categoria = CategoriaDatoEnum.CategoriaNumerico
                Case OleDb.OleDbType.UnsignedTinyInt : Categoria = CategoriaDatoEnum.CategoriaNumerico
                Case OleDb.OleDbType.VarNumeric : Categoria = CategoriaDatoEnum.CategoriaNumerico

                Case OleDb.OleDbType.DBDate : Categoria = CategoriaDatoEnum.CategoriaData
                Case OleDb.OleDbType.DBTime : Categoria = CategoriaDatoEnum.CategoriaData
                Case OleDb.OleDbType.DBTimeStamp : Categoria = CategoriaDatoEnum.CategoriaData

                Case OleDb.OleDbType.BSTR : Categoria = CategoriaDatoEnum.CategoriaStringa
                Case OleDb.OleDbType.Char : Categoria = CategoriaDatoEnum.CategoriaStringa
                Case OleDb.OleDbType.LongVarChar : Categoria = CategoriaDatoEnum.CategoriaStringa
                Case OleDb.OleDbType.LongVarWChar : Categoria = CategoriaDatoEnum.CategoriaStringa
                Case OleDb.OleDbType.VarWChar : Categoria = CategoriaDatoEnum.CategoriaStringa
                Case OleDb.OleDbType.WChar : Categoria = CategoriaDatoEnum.CategoriaStringa
                Case Else
                    Throw New Exception("Campo.TipoDato " & mTipoDato & " non categorizzato")
            End Select
        End Set
    End Property

    Public Property Formato() As String
        Get
            Return mFormato
        End Get
        Set(vNewValue As String)
            If vNewValue <> vbNullString Then
                mFormato = vNewValue
                If mFormato = "NOSPACES" Then
                    TipoFormato = TipoFormatoEnum.FORMATO_NOSPACES
                ElseIf (InStr(1, mFormato, "V")) <> 0 Then
                    Scala = Len(mFormato) - InStrRev(mFormato, "V")
                    TipoFormato = TipoFormatoEnum.FORMATO_9xV9y
                ElseIf (InStr(1, mFormato, ",")) <> 0 Then
                    If Right(mFormato, 1) = "S" Then
                        TipoFormato = TipoFormatoEnum.FORMATO_9x_9yS
                    ElseIf Left(mFormato, 1) = "S" Then
                        TipoFormato = TipoFormatoEnum.FORMATO_S9x_9y
                    Else
                        TipoFormato = TipoFormatoEnum.FORMATO_9x_9y
                    End If
                ElseIf mFormato = "AAAAMMGG" Then
                    TipoFormato = TipoFormatoEnum.FORMATO_AAAAMMGG
                ElseIf mFormato = "GG.MM.AAAA" Then
                    TipoFormato = TipoFormatoEnum.FORMATO_GG_MM_AAAA
                Else
                    'Exception "formato sconosciuto"
                End If
            End If
        End Set
    End Property

    Public Function getValorePerInsert() As String
        If ValoreIsNull And Not CampoChiave Then
            getValorePerInsert = "NULL"
        Else
            Select Case Categoria
                Case CategoriaDatoEnum.CategoriaNumerico
                    getValorePerInsert = Utx.FunzioniDb.TO_NUMBER(Valore)
                Case CategoriaDatoEnum.CategoriaData
                    getValorePerInsert = Utx.FunzioniDb.TO_DATE(Valore)
                Case Else
                    getValorePerInsert = Utx.FunzioniDb.TO_STRING(Trim(Valore))
            End Select
        End If
    End Function

    Public Function ValoreOriginale() As String
        ValoreOriginale = mValore
    End Function

    Public Property Valore() As String
        Get
            Select Case TipoFormato
                Case TipoFormatoEnum.FORMATO_NESSUNO
                    Return mValore
                Case TipoFormatoEnum.FORMATO_NOSPACES
                    Return mValore.Replace(" ", "")
                Case TipoFormatoEnum.FORMATO_9x_9y
                    Return mValore
                Case TipoFormatoEnum.FORMATO_9x_9yS
                    Return Right(mValore, 1) & Left(mValore, Lunghezza - 1)
                Case TipoFormatoEnum.FORMATO_S9x_9y
                    Return mValore
                Case TipoFormatoEnum.FORMATO_9xV9y
                    Return Left(mValore, Lunghezza - Scala) & "," & Right(mValore, Scala)
                Case TipoFormatoEnum.FORMATO_AAAAMMGG
                    Return Mid(mValore, 7, 2) _
                           & "/" & Mid(mValore, 5, 2) _
                           & "/" & Mid(mValore, 1, 4)
                Case TipoFormatoEnum.FORMATO_GG_MM_AAAA
                    Return Mid(mValore, 1, 2) _
                           & "/" & Mid(mValore, 4, 2) _
                           & "/" & Mid(mValore, 7, 4)
                Case TipoFormatoEnum.FORMATO_DATETIME
                    Return mValore
                Case Else
                    Return mValore
            End Select


            'Select Case Categoria
            '    Case CategoriaDatoEnum.CategoriaNumerico
            '        Select Case TipoFormato
            '            Case TipoFormatoEnum.FORMATO_NESSUNO
            '                Valore = mValore
            '            Case TipoFormatoEnum.FORMATO_9x_9y
            '                Valore = mValore
            '            Case TipoFormatoEnum.FORMATO_9x_9yS
            '                Valore = Right(mValore, 1) & Left(mValore, Lunghezza - 1)
            '            Case TipoFormatoEnum.FORMATO_S9x_9y
            '                Valore = mValore
            '            Case TipoFormatoEnum.FORMATO_9xV9y
            '                Valore = Left(mValore, Lunghezza - Scala) & "," & Right(mValore, Scala)
            '            Case Else
            '                Valore = mValore
            '        End Select

            '    Case CategoriaDatoEnum.CategoriaData
            '        Select Case TipoFormato
            '            Case TipoFormatoEnum.FORMATO_NESSUNO
            '                Valore = mValore
            '            Case TipoFormatoEnum.FORMATO_AAAAMMGG
            '                Valore = Mid(mValore, 5, 2) _
            '                       & "/" & Mid(mValore, 7, 2) _
            '                       & "/" & Mid(mValore, 1, 4)
            '            Case TipoFormatoEnum.FORMATO_GG_MM_AAAA
            '                Valore = Mid(mValore, 4, 2) _
            '                       & "/" & Mid(mValore, 1, 2) _
            '                       & "/" & Mid(mValore, 7, 4)
            '            Case TipoFormatoEnum.FORMATO_DATETIME
            '                Valore = mValore
            '            Case Else
            '                Valore = mValore
            '        End Select
            '    Case Else
            '        Valore = mValore
            'End Select
            Return valore
        End Get
        Set(value As String)
            mValore = value
        End Set
    End Property

    Public Function HasChild() As Boolean
        Return Campi.Count > 0
    End Function

    Public Function Clone() As Campo
        Dim oCampo As New Campo
        With oCampo
            .CampoOk = CampoOk
            .CampoChiave = CampoChiave
            .Nome = mNome
            .Formato = mFormato
            .NomeRif = mNomeRif
            .Valore = mValore
            .DefaultSeNullo = mDefaultSeNullo
            .Occorrenze = Occorrenze
            .Lunghezza = Lunghezza
            .Scala = Scala
            .TipoDato = mTipoDato
            .Storicizzare = Storicizzare
            .Campi = Campi.Clone()
        End With
        Return oCampo
    End Function

    Public Sub WriteValore()
        If Campi IsNot Nothing Then
            Campi.WriteValore()
        End If
    End Sub

    Public Function DettaglioCampo4Debug() As String
        DettaglioCampo4Debug = Nome.PadRight(50) & " (" & Format(Lunghezza, "000") & ") = " & Valore
    End Function
End Class
