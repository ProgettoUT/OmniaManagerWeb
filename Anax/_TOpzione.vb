Imports Utx.FunzioniDb.Funzioni


Public Class _TOpzione
    Inherits TBase
    Private Const sMODULENAME = "Opzione"
    Private Const ANA_OPZIONE = "[Ana_opzione]"

    'Campi della tabella
    Private mProgressivo As Integer
    Private mTipo As String
    Private mParametro As String
    Private mValore As String

    'Campi che possono essere aggiornati
    Private mChangedTipo As Boolean
    Private mChangedParametro As Boolean
    Private mChangedValore As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ANA_OPZIONE
        End Get
    End Property

    '**************************************************************************
    ' Proprietà dell'oggetto
    '**************************************************************************
    Public Property Progressivo() As Integer
        Get
            Return mProgressivo
        End Get
        Set(value As Integer)
            mProgressivo = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return mTipo
        End Get
        Set(value As String)
            If mTipo <> value Then
                mTipo = value
                mChangedTipo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Parametro() As String
        Get
            Return mParametro
        End Get
        Set(value As String)
            If mParametro <> value Then
                mParametro = value
                mChangedParametro = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Valore() As String
        Get
            Return mValore
        End Get
        Set(value As String)
            If mValore <> value Then
                mValore = value
                mChangedValore = True
                SetModifiedState()
            End If
        End Set
    End Property

    '**************************************************************************
    ' Fine delle proprietà dell'oggetto
    '**************************************************************************


    Public Overrides Property Key() As String
        Get
            Key = ""
            Key &= DELIMITER & mProgressivo
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mProgressivo = keys(0)
        End Set
    End Property

    Public Function LoadByKey( _
                 Progressivo As Integer _
                ) As Boolean

        mProgressivo = Progressivo

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_OPZIONE
        End If

        With sql
            .Where("Progressivo", TipoEnum.TIPO_NUMERO) = mProgressivo
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = ANA_OPZIONE
                mProgressivo = .GetNextPrg("Progressivo")
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_OPZIONE
        End If


        With sql
            .Field("Progressivo", TipoEnum.TIPO_NUMERO) = mProgressivo
        End With

        PutSqlKey = sql
    End Function

    Public Overrides Function GetFields(rs As DataTableReader) As Boolean
        Dim columnIndex As Integer = 0
        With rs
            If .HasRows Then
                columnIndex = .GetOrdinal("Progressivo")
                If Not .IsDBNull(columnIndex) Then
                    mProgressivo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Tipo")
                If Not .IsDBNull(columnIndex) Then
                    mTipo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Parametro")
                If Not .IsDBNull(columnIndex) Then
                    mParametro = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Valore")
                If Not .IsDBNull(columnIndex) Then
                    mValore = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedTipo Then
                .Field("Tipo", TipoEnum.TIPO_STRINGA) = mTipo
            End If
            If mChangedParametro Then
                .Field("Parametro", TipoEnum.TIPO_STRINGA) = mParametro
            End If
            If mChangedValore Then
                .Field("Valore", TipoEnum.TIPO_STRINGA) = mValore
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedTipo = False
        mChangedParametro = False
        mChangedValore = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mTipo.Length > 50 Then Ris = False
        If mParametro.Length > 255 Then Ris = False
        If mValore.Length > 255 Then Ris = False

        Return Ris
    End Function


End Class
