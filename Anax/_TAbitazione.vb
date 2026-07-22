Imports Utx.FunzioniDb.Funzioni


Public Class _TAbitazione
    Inherits TBase
    Private Const sMODULENAME = "Abitazione"
    Private Const ANA_ABITAZIONE = "[Ana_abitazione]"

    'Campi della tabella
    Private mCodiceFiscale As String
    Private mIdAbitazione As Integer
    Private mCodAbitazione As String
    Private mmq As Integer
    Private mValoreCommerciale As Decimal
    Private mProprietario As Boolean
    Private mMutuo As Boolean
    Private mImportoAnnuale As Decimal

    'Campi che possono essere aggiornati
    Private mChangedCodAbitazione As Boolean
    Private mChangedmq As Boolean
    Private mChangedValoreCommerciale As Boolean
    Private mChangedProprietario As Boolean
    Private mChangedMutuo As Boolean
    Private mChangedImportoAnnuale As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ANA_ABITAZIONE
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

    Public Property IdAbitazione() As Integer
        Get
            Return mIdAbitazione
        End Get
        Set(value As Integer)
            mIdAbitazione = value
        End Set
    End Property

    Public Property CodAbitazione() As String
        Get
            Return mCodAbitazione
        End Get
        Set(value As String)
            If mCodAbitazione <> value Then
                mCodAbitazione = value
                mChangedCodAbitazione = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property mq() As Integer
        Get
            Return mmq
        End Get
        Set(value As Integer)
            If mmq <> value Then
                mmq = value
                mChangedmq = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ValoreCommerciale() As Decimal
        Get
            Return mValoreCommerciale
        End Get
        Set(value As Decimal)
            If mValoreCommerciale <> value Then
                mValoreCommerciale = value
                mChangedValoreCommerciale = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Proprietario() As Boolean
        Get
            Return mProprietario
        End Get
        Set(value As Boolean)
            If mProprietario <> value Then
                mProprietario = value
                mChangedProprietario = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Mutuo() As Boolean
        Get
            Return mMutuo
        End Get
        Set(value As Boolean)
            If mMutuo <> value Then
                mMutuo = value
                mChangedMutuo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ImportoAnnuale() As Decimal
        Get
            Return mImportoAnnuale
        End Get
        Set(value As Decimal)
            If mImportoAnnuale <> value Then
                mImportoAnnuale = value
                mChangedImportoAnnuale = True
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
            Key &= DELIMITER & mIdAbitazione
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mCodiceFiscale = keys(0)
            mIdAbitazione = keys(1)
        End Set
    End Property

    Public Function LoadByKey( _
                 CodiceFiscale As String _
                 , IdAbitazione As Integer _
                ) As Boolean

        mCodiceFiscale = CodiceFiscale
        mIdAbitazione = IdAbitazione

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_ABITAZIONE
        End If

        With sql
            .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Where("IdAbitazione", TipoEnum.TIPO_NUMERO) = mIdAbitazione
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = ANA_ABITAZIONE
                .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
                mIdAbitazione = .GetNextPrg("IdAbitazione")
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_ABITAZIONE
        End If


        With sql
            .Field("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Field("IdAbitazione", TipoEnum.TIPO_NUMERO) = mIdAbitazione
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
                columnIndex = .GetOrdinal("IdAbitazione")
                If Not .IsDBNull(columnIndex) Then
                    mIdAbitazione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodAbitazione")
                If Not .IsDBNull(columnIndex) Then
                    mCodAbitazione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("mq")
                If Not .IsDBNull(columnIndex) Then
                    mmq = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ValoreCommerciale")
                If Not .IsDBNull(columnIndex) Then
                    mValoreCommerciale = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Proprietario")
                If Not .IsDBNull(columnIndex) Then
                    mProprietario = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Mutuo")
                If Not .IsDBNull(columnIndex) Then
                    mMutuo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ImportoAnnuale")
                If Not .IsDBNull(columnIndex) Then
                    mImportoAnnuale = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedCodAbitazione Then
                .Field("CodAbitazione", TipoEnum.TIPO_STRINGA) = mCodAbitazione
            End If
            If mChangedmq Then
                .Field("mq", TipoEnum.TIPO_NUMERO) = mmq
            End If
            If mChangedValoreCommerciale Then
                .Field("ValoreCommerciale", TipoEnum.TIPO_VALUTA) = mValoreCommerciale
            End If
            If mChangedProprietario Then
                .Field("Proprietario", TipoEnum.TIPO_BOOLEAN) = mProprietario
            End If
            If mChangedMutuo Then
                .Field("Mutuo", TipoEnum.TIPO_BOOLEAN) = mMutuo
            End If
            If mChangedImportoAnnuale Then
                .Field("ImportoAnnuale", TipoEnum.TIPO_VALUTA) = mImportoAnnuale
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedCodAbitazione = False
        mChangedmq = False
        mChangedValoreCommerciale = False
        mChangedProprietario = False
        mChangedMutuo = False
        mChangedImportoAnnuale = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mCodiceFiscale.Length = 0 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False
        If mCodAbitazione.Length > 1 Then Ris = False

        Return Ris
    End Function


End Class
