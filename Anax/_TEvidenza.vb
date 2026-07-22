Imports Utx.FunzioniDb.Funzioni


Public Class _TEvidenza
    Inherits TBase
    Private Const sMODULENAME = "Evidenza"
    Private Const UNIDOCS_EVIDENZA = "[Unidocs_evidenza]"

    'Campi della tabella
    Private mIdEvidenza As Integer
    Private mCodCompagnia As Integer
    Private mCodPuntoVendita As Integer
    Private mDesEvidenza As String
    Private mIdOggetto As String
    Private mDesNote As String
    Private mCodGravita As Byte
    Private mCodTipoEvidenza As Byte
    Private mCodTipoOggetto As Byte
    Private mDataApertura As DateTime
    Private mDataChiusura As DateTime
    Private mCodiceFiscale As String
    Private mCodiceSubAgente As Integer
    Private mDataRiferimento As DateTime

    'Campi che possono essere aggiornati
    Private mChangedCodCompagnia As Boolean
    Private mChangedCodPuntoVendita As Boolean
    Private mChangedDesEvidenza As Boolean
    Private mChangedIdOggetto As Boolean
    Private mChangedDesNote As Boolean
    Private mChangedCodGravita As Boolean
    Private mChangedCodTipoEvidenza As Boolean
    Private mChangedCodTipoOggetto As Boolean
    Private mChangedDataApertura As Boolean
    Private mChangedDataChiusura As Boolean
    Private mChangedCodiceFiscale As Boolean
    Private mChangedCodiceSubAgente As Boolean
    Private mChangedDataRiferimento As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return UNIDOCS_EVIDENZA
        End Get
    End Property

    '**************************************************************************
    ' Proprietà dell'oggetto
    '**************************************************************************
    Public Property IdEvidenza() As Integer
        Get
            Return mIdEvidenza
        End Get
        Set(value As Integer)
            mIdEvidenza = value
        End Set
    End Property

    Public Property CodCompagnia() As Integer
        Get
            Return mCodCompagnia
        End Get
        Set(value As Integer)
            If mCodCompagnia <> value Then
                mCodCompagnia = value
                mChangedCodCompagnia = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodPuntoVendita() As Integer
        Get
            Return mCodPuntoVendita
        End Get
        Set(value As Integer)
            If mCodPuntoVendita <> value Then
                mCodPuntoVendita = value
                mChangedCodPuntoVendita = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DesEvidenza() As String
        Get
            Return mDesEvidenza
        End Get
        Set(value As String)
            If mDesEvidenza <> value Then
                mDesEvidenza = value
                mChangedDesEvidenza = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property IdOggetto() As String
        Get
            Return mIdOggetto
        End Get
        Set(value As String)
            If mIdOggetto <> value Then
                mIdOggetto = value
                mChangedIdOggetto = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DesNote() As String
        Get
            Return mDesNote
        End Get
        Set(value As String)
            If mDesNote <> value Then
                mDesNote = value
                mChangedDesNote = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodGravita() As Byte
        Get
            Return mCodGravita
        End Get
        Set(value As Byte)
            If mCodGravita <> value Then
                mCodGravita = value
                mChangedCodGravita = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodTipoEvidenza() As Byte
        Get
            Return mCodTipoEvidenza
        End Get
        Set(value As Byte)
            If mCodTipoEvidenza <> value Then
                mCodTipoEvidenza = value
                mChangedCodTipoEvidenza = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodTipoOggetto() As Byte
        Get
            Return mCodTipoOggetto
        End Get
        Set(value As Byte)
            If mCodTipoOggetto <> value Then
                mCodTipoOggetto = value
                mChangedCodTipoOggetto = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DataApertura() As DateTime
        Get
            Return mDataApertura
        End Get
        Set(value As DateTime)
            If mDataApertura <> value Then
                mDataApertura = value
                mChangedDataApertura = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DataChiusura() As DateTime
        Get
            Return mDataChiusura
        End Get
        Set(value As DateTime)
            If mDataChiusura <> value Then
                mDataChiusura = value
                mChangedDataChiusura = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodiceFiscale() As String
        Get
            Return mCodiceFiscale
        End Get
        Set(value As String)
            If mCodiceFiscale <> value Then
                mCodiceFiscale = value
                mChangedCodiceFiscale = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodiceSubAgente() As Integer
        Get
            Return mCodiceSubAgente
        End Get
        Set(value As Integer)
            If mCodiceSubAgente <> value Then
                mCodiceSubAgente = value
                mChangedCodiceSubAgente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DataRiferimento() As DateTime
        Get
            Return mDataRiferimento
        End Get
        Set(value As DateTime)
            If mDataRiferimento <> value Then
                mDataRiferimento = value
                mChangedDataRiferimento = True
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
            Key &= DELIMITER & mIdEvidenza
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mIdEvidenza = keys(0)
        End Set
    End Property

    Public Function LoadByKey( _
                 IdEvidenza As Integer _
                ) As Boolean

        mIdEvidenza = IdEvidenza

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = UNIDOCS_EVIDENZA
        End If

        With sql
            .Where("IdEvidenza", TipoEnum.TIPO_NUMERO) = mIdEvidenza
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = UNIDOCS_EVIDENZA
                mIdEvidenza = .GetNextPrg("IdEvidenza")
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = UNIDOCS_EVIDENZA
        End If


        With sql
            .Field("IdEvidenza", TipoEnum.TIPO_NUMERO) = mIdEvidenza
        End With

        PutSqlKey = sql
    End Function

    Public Overrides Function GetFields(rs As DataTableReader) As Boolean
        Dim columnIndex As Integer = 0
        With rs
            If .HasRows Then
                columnIndex = .GetOrdinal("IdEvidenza")
                If Not .IsDBNull(columnIndex) Then
                    mIdEvidenza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodCompagnia")
                If Not .IsDBNull(columnIndex) Then
                    mCodCompagnia = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodPuntoVendita")
                If Not .IsDBNull(columnIndex) Then
                    mCodPuntoVendita = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DesEvidenza")
                If Not .IsDBNull(columnIndex) Then
                    mDesEvidenza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("IdOggetto")
                If Not .IsDBNull(columnIndex) Then
                    mIdOggetto = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DesNote")
                If Not .IsDBNull(columnIndex) Then
                    mDesNote = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodGravita")
                If Not .IsDBNull(columnIndex) Then
                    mCodGravita = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodTipoEvidenza")
                If Not .IsDBNull(columnIndex) Then
                    mCodTipoEvidenza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodTipoOggetto")
                If Not .IsDBNull(columnIndex) Then
                    mCodTipoOggetto = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataApertura")
                If Not .IsDBNull(columnIndex) Then
                    mDataApertura = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataChiusura")
                If Not .IsDBNull(columnIndex) Then
                    mDataChiusura = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceFiscale")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceFiscale = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceSubAgente")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceSubAgente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataRiferimento")
                If Not .IsDBNull(columnIndex) Then
                    mDataRiferimento = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedCodCompagnia Then
                .Field("CodCompagnia", TipoEnum.TIPO_NUMERO) = mCodCompagnia
            End If
            If mChangedCodPuntoVendita Then
                .Field("CodPuntoVendita", TipoEnum.TIPO_NUMERO) = mCodPuntoVendita
            End If
            If mChangedDesEvidenza Then
                .Field("DesEvidenza", TipoEnum.TIPO_STRINGA) = mDesEvidenza
            End If
            If mChangedIdOggetto Then
                .Field("IdOggetto", TipoEnum.TIPO_STRINGA) = mIdOggetto
            End If
            If mChangedDesNote Then
                .Field("DesNote", TipoEnum.TIPO_STRINGA) = mDesNote
            End If
            If mChangedCodGravita Then
                .Field("CodGravita", TipoEnum.TIPO_NUMERO) = mCodGravita
            End If
            If mChangedCodTipoEvidenza Then
                .Field("CodTipoEvidenza", TipoEnum.TIPO_NUMERO) = mCodTipoEvidenza
            End If
            If mChangedCodTipoOggetto Then
                .Field("CodTipoOggetto", TipoEnum.TIPO_NUMERO) = mCodTipoOggetto
            End If
            If mChangedDataApertura Then
                .Field("DataApertura", TipoEnum.TIPO_DATA) = mDataApertura
            End If
            If mChangedDataChiusura Then
                .Field("DataChiusura", TipoEnum.TIPO_DATA) = mDataChiusura
            End If
            If mChangedCodiceFiscale Then
                .Field("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            End If
            If mChangedCodiceSubAgente Then
                .Field("CodiceSubAgente", TipoEnum.TIPO_NUMERO) = mCodiceSubAgente
            End If
            If mChangedDataRiferimento Then
                .Field("DataRiferimento", TipoEnum.TIPO_DATA) = mDataRiferimento
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedCodCompagnia = False
        mChangedCodPuntoVendita = False
        mChangedDesEvidenza = False
        mChangedIdOggetto = False
        mChangedDesNote = False
        mChangedCodGravita = False
        mChangedCodTipoEvidenza = False
        mChangedCodTipoOggetto = False
        mChangedDataApertura = False
        mChangedDataChiusura = False
        mChangedCodiceFiscale = False
        mChangedCodiceSubAgente = False
        mChangedDataRiferimento = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mDesEvidenza.Length > 255 Then Ris = False
        If mIdOggetto.Length > 50 Then Ris = False
        If mDesNote.Length > 536870910 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False

        Return Ris
    End Function


End Class
