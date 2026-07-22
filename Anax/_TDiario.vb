Imports Utx.FunzioniDb.Funzioni


Public Class _TDiario
    Inherits TBase
    Private Const sMODULENAME = "Diario"
    Private Const ANA_DIARIO = "[Ana_diario]"

    'Campi della tabella
    Private mCodiceFiscale As String
    Private mProgressivo As Integer
    Private mTipoLogging As Integer
    Private mDataInserimento As DateTime
    Private mUtente As String
    Private mDescrizione As String

    'Campi che possono essere aggiornati
    Private mChangedTipoLogging As Boolean
    Private mChangedDataInserimento As Boolean
    Private mChangedUtente As Boolean
    Private mChangedDescrizione As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ANA_DIARIO
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

    Public Property Progressivo() As Integer
        Get
            Return mProgressivo
        End Get
        Set(value As Integer)
            mProgressivo = value
        End Set
    End Property

    Public Property TipoLogging() As Integer
        Get
            Return mTipoLogging
        End Get
        Set(value As Integer)
            If mTipoLogging <> value Then
                mTipoLogging = value
                mChangedTipoLogging = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DataInserimento() As DateTime
        Get
            Return mDataInserimento
        End Get
        Set(value As DateTime)
            If mDataInserimento <> value Then
                mDataInserimento = value
                mChangedDataInserimento = True
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

    Public Property Descrizione() As String
        Get
            Return mDescrizione
        End Get
        Set(value As String)
            If mDescrizione <> value Then
                mDescrizione = value
                mChangedDescrizione = True
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
            Key &= DELIMITER & mProgressivo
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mCodiceFiscale = keys(0)
            mProgressivo = keys(1)
        End Set
    End Property

    Public Function LoadByKey( _
                 CodiceFiscale As String _
                 , Progressivo As Integer _
                ) As Boolean

        mCodiceFiscale = CodiceFiscale
        mProgressivo = Progressivo

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_DIARIO
        End If

        With sql
            .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Where("Progressivo", TipoEnum.TIPO_NUMERO) = mProgressivo
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = ANA_DIARIO
                .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
                mProgressivo = .GetNextPrg("Progressivo")
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_DIARIO
        End If


        With sql
            .Field("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Field("Progressivo", TipoEnum.TIPO_NUMERO) = mProgressivo
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
                columnIndex = .GetOrdinal("Progressivo")
                If Not .IsDBNull(columnIndex) Then
                    mProgressivo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TipoLogging")
                If Not .IsDBNull(columnIndex) Then
                    mTipoLogging = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataInserimento")
                If Not .IsDBNull(columnIndex) Then
                    mDataInserimento = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Utente")
                If Not .IsDBNull(columnIndex) Then
                    mUtente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Descrizione")
                If Not .IsDBNull(columnIndex) Then
                    mDescrizione = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedTipoLogging Then
                .Field("TipoLogging", TipoEnum.TIPO_NUMERO) = mTipoLogging
            End If
            If mChangedDataInserimento Then
                .Field("DataInserimento", TipoEnum.TIPO_DATA) = mDataInserimento
            End If
            If mChangedUtente Then
                .Field("Utente", TipoEnum.TIPO_STRINGA) = mUtente
            End If
            If mChangedDescrizione Then
                .Field("Descrizione", TipoEnum.TIPO_STRINGA) = mDescrizione
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedTipoLogging = False
        mChangedDataInserimento = False
        mChangedUtente = False
        mChangedDescrizione = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mCodiceFiscale.Length = 0 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False
        If mUtente.Length > 255 Then Ris = False
        If mDescrizione.Length > 536870910 Then Ris = False

        Return Ris
    End Function


End Class
