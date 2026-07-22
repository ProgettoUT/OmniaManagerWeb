Imports Utx.FunzioniDb.Funzioni


Public Class _TFasiVendita
    Inherits TBase
    Private Const sMODULENAME = "FasiVendita"
    Private Const ANA_FASIVENDITA = "[Ana_fasivendita]"

    'Campi della tabella
    Private mCodiceFiscale As String
    Private mFase As String
    Private mData As DateTime
    Private mUtente As String

    'Campi che possono essere aggiornati
    Private mChangedData As Boolean
    Private mChangedUtente As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ANA_FASIVENDITA
        End Get
    End Property

    '**************************************************************************
    ' Proprietà dell'oggetto
    '**************************************************************************
    Public Property CodiceFiscale() As String
        Get
            Return mCodiceFiscale
        End Get
        Set(value As String)
            mCodiceFiscale = value
        End Set
    End Property

    Public Property Fase() As String
        Get
            Return mFase
        End Get
        Set(value As String)
            mFase = value
        End Set
    End Property

    Public Property Data() As DateTime
        Get
            Return mData
        End Get
        Set(value As DateTime)
            If mData <> value Then
                mData = value
                mChangedData = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Utente() As String
        Get
            Return mUtente
        End Get
        Set(value As String)
            If mUtente <> value Then
                mUtente = value
                mChangedUtente = True
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
            Key &= DELIMITER & mCodiceFiscale
            Key &= DELIMITER & mFase
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mCodiceFiscale = keys(0)
            mFase = keys(1)
        End Set
    End Property

    Public Function LoadByKey( _
                 CodiceFiscale As String _
                 , Fase As String _
                ) As Boolean

        mCodiceFiscale = CodiceFiscale
        mFase = Fase

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_FASIVENDITA
        End If

        With sql
            .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Where("Fase", TipoEnum.TIPO_STRINGA) = mFase
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = ANA_FASIVENDITA
                .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
                .Where("Fase", TipoEnum.TIPO_STRINGA) = mFase
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_FASIVENDITA
        End If


        With sql
            .Field("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Field("Fase", TipoEnum.TIPO_STRINGA) = mFase
        End With

        PutSqlKey = sql
    End Function

    Public Overrides Function GetFields(rs As DataTableReader) As Boolean
        Dim columnIndex As Integer = 0
        With rs
            If .HasRows Then
                columnIndex = .GetOrdinal("CodiceFiscale")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceFiscale = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Fase")
                If Not .IsDBNull(columnIndex) Then
                    mFase = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Data")
                If Not .IsDBNull(columnIndex) Then
                    mData = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Utente")
                If Not .IsDBNull(columnIndex) Then
                    mUtente = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedData Then
                .Field("Data", TipoEnum.TIPO_DATA) = mData
            End If
            If mChangedUtente Then
                .Field("Utente", TipoEnum.TIPO_STRINGA) = mUtente
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedData = False
        mChangedUtente = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mCodiceFiscale.Length = 0 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False
        If mFase.Length = 0 Then Ris = False
        If mFase.Length > 1 Then Ris = False
        If mUtente.Length > 25 Then Ris = False

        Return Ris
    End Function


End Class
