Imports Utx.FunzioniDb.Funzioni


Public Class _TNucleoFamiliare
    Inherits TBase
    Private Const sMODULENAME = "NucleoFamiliare"
    Private Const ANA_NUCLEOFAMILIARE = "[Ana_nucleofamiliare]"

    'Campi della tabella
    Private mCodiceFiscale As String
    Private mIdFamiliare As Integer
    Private mCodiceFiscaleFamiliare As String
    Private mCodRelazione As String
    Private mNome As String
    Private mEta As Integer
    Private mConvivente As Boolean
    Private mAttivitaSvolta As String
    Private mAttivitaLuogo As String
    Private mAttivitaInizio As DateTime
    Private mRedditoAnnuo As Decimal

    'Campi che possono essere aggiornati
    Private mChangedCodiceFiscaleFamiliare As Boolean
    Private mChangedCodRelazione As Boolean
    Private mChangedNome As Boolean
    Private mChangedEta As Boolean
    Private mChangedConvivente As Boolean
    Private mChangedAttivitaSvolta As Boolean
    Private mChangedAttivitaLuogo As Boolean
    Private mChangedAttivitaInizio As Boolean
    Private mChangedRedditoAnnuo As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ANA_NUCLEOFAMILIARE
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

    Public Property IdFamiliare() As Integer
        Get
            Return mIdFamiliare
        End Get
        Set(value As Integer)
            mIdFamiliare = value
        End Set
    End Property

    Public Property CodiceFiscaleFamiliare() As String
        Get
            Return mCodiceFiscaleFamiliare
        End Get
        Set(value As String)
            If mCodiceFiscaleFamiliare <> value Then
                mCodiceFiscaleFamiliare = value
                mChangedCodiceFiscaleFamiliare = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodRelazione() As String
        Get
            Return mCodRelazione
        End Get
        Set(value As String)
            If mCodRelazione <> value Then
                mCodRelazione = value
                mChangedCodRelazione = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return mNome
        End Get
        Set(value As String)
            If mNome <> value Then
                mNome = value
                mChangedNome = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Eta() As Integer
        Get
            Return mEta
        End Get
        Set(value As Integer)
            If mEta <> value Then
                mEta = value
                mChangedEta = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Convivente() As Boolean
        Get
            Return mConvivente
        End Get
        Set(value As Boolean)
            If mConvivente <> value Then
                mConvivente = value
                mChangedConvivente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AttivitaSvolta() As String
        Get
            Return mAttivitaSvolta
        End Get
        Set(value As String)
            If mAttivitaSvolta <> value Then
                mAttivitaSvolta = value
                mChangedAttivitaSvolta = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AttivitaLuogo() As String
        Get
            Return mAttivitaLuogo
        End Get
        Set(value As String)
            If mAttivitaLuogo <> value Then
                mAttivitaLuogo = value
                mChangedAttivitaLuogo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AttivitaInizio() As DateTime
        Get
            Return mAttivitaInizio
        End Get
        Set(value As DateTime)
            If mAttivitaInizio <> value Then
                mAttivitaInizio = value
                mChangedAttivitaInizio = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property RedditoAnnuo() As Decimal
        Get
            Return mRedditoAnnuo
        End Get
        Set(value As Decimal)
            If mRedditoAnnuo <> value Then
                mRedditoAnnuo = value
                mChangedRedditoAnnuo = True
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
            Key &= DELIMITER & mIdFamiliare
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mCodiceFiscale = keys(0)
            mIdFamiliare = keys(1)
        End Set
    End Property

    Public Function LoadByKey( _
                 CodiceFiscale As String _
                 , IdFamiliare As Integer _
                ) As Boolean

        mCodiceFiscale = CodiceFiscale
        mIdFamiliare = IdFamiliare

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_NUCLEOFAMILIARE
        End If

        With sql
            .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Where("IdFamiliare", TipoEnum.TIPO_NUMERO) = mIdFamiliare
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = ANA_NUCLEOFAMILIARE
                .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
                mIdFamiliare = .GetNextPrg("IdFamiliare")
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_NUCLEOFAMILIARE
        End If


        With sql
            .Field("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Field("IdFamiliare", TipoEnum.TIPO_NUMERO) = mIdFamiliare
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
                columnIndex = .GetOrdinal("IdFamiliare")
                If Not .IsDBNull(columnIndex) Then
                    mIdFamiliare = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceFiscaleFamiliare")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceFiscaleFamiliare = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodRelazione")
                If Not .IsDBNull(columnIndex) Then
                    mCodRelazione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Nome")
                If Not .IsDBNull(columnIndex) Then
                    mNome = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Eta")
                If Not .IsDBNull(columnIndex) Then
                    mEta = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Convivente")
                If Not .IsDBNull(columnIndex) Then
                    mConvivente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AttivitaSvolta")
                If Not .IsDBNull(columnIndex) Then
                    mAttivitaSvolta = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AttivitaLuogo")
                If Not .IsDBNull(columnIndex) Then
                    mAttivitaLuogo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AttivitaInizio")
                If Not .IsDBNull(columnIndex) Then
                    mAttivitaInizio = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("RedditoAnnuo")
                If Not .IsDBNull(columnIndex) Then
                    mRedditoAnnuo = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedCodiceFiscaleFamiliare Then
                .Field("CodiceFiscaleFamiliare", TipoEnum.TIPO_STRINGA) = mCodiceFiscaleFamiliare
            End If
            If mChangedCodRelazione Then
                .Field("CodRelazione", TipoEnum.TIPO_STRINGA) = mCodRelazione
            End If
            If mChangedNome Then
                .Field("Nome", TipoEnum.TIPO_STRINGA) = mNome
            End If
            If mChangedEta Then
                .Field("Eta", TipoEnum.TIPO_NUMERO) = mEta
            End If
            If mChangedConvivente Then
                .Field("Convivente", TipoEnum.TIPO_BOOLEAN) = mConvivente
            End If
            If mChangedAttivitaSvolta Then
                .Field("AttivitaSvolta", TipoEnum.TIPO_STRINGA) = mAttivitaSvolta
            End If
            If mChangedAttivitaLuogo Then
                .Field("AttivitaLuogo", TipoEnum.TIPO_STRINGA) = mAttivitaLuogo
            End If
            If mChangedAttivitaInizio Then
                .Field("AttivitaInizio", TipoEnum.TIPO_DATA) = mAttivitaInizio
            End If
            If mChangedRedditoAnnuo Then
                .Field("RedditoAnnuo", TipoEnum.TIPO_VALUTA) = mRedditoAnnuo
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedCodiceFiscaleFamiliare = False
        mChangedCodRelazione = False
        mChangedNome = False
        mChangedEta = False
        mChangedConvivente = False
        mChangedAttivitaSvolta = False
        mChangedAttivitaLuogo = False
        mChangedAttivitaInizio = False
        mChangedRedditoAnnuo = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mCodiceFiscale.Length = 0 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False
        If mCodiceFiscaleFamiliare.Length > 16 Then Ris = False
        If mCodRelazione.Length > 1 Then Ris = False
        If mNome.Length > 255 Then Ris = False
        If mAttivitaSvolta.Length > 255 Then Ris = False
        If mAttivitaLuogo.Length > 255 Then Ris = False

        Return Ris
    End Function


End Class
