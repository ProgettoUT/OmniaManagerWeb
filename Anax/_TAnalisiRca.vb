Imports Utx.FunzioniDb.Funzioni


Public Class _TAnalisiRca
    Inherits TBase
    Private Const sMODULENAME = "AnalisiRca"
    Private Const ANA_ANALISIRCA = "[Ana_analisirca]"

    'Campi della tabella
    Private mCodiceFiscale As String
    Private mIdPolizza As Integer
    Private mPolizza As String
    Private mConvenzione As String
    Private mDataScadenza As DateTime
    Private mTipoVeicolo As String
    Private mMarca As String
    Private mModello As String
    Private mTarga As String
    Private mPremioOld As Decimal
    Private mPremioNew As Decimal
    Private mUnibox As String
    Private mGuidaEsperta As String
    Private mFinanziamento As String
    Private mRiparazione As String
    Private mFlexIncendioFurto As Integer
    Private mSinistroData As DateTime
    Private mSinistroMalus As String
    Private mSinistroSoN As String

    'Campi che possono essere aggiornati
    Private mChangedPolizza As Boolean
    Private mChangedConvenzione As Boolean
    Private mChangedDataScadenza As Boolean
    Private mChangedTipoVeicolo As Boolean
    Private mChangedMarca As Boolean
    Private mChangedModello As Boolean
    Private mChangedTarga As Boolean
    Private mChangedPremioOld As Boolean
    Private mChangedPremioNew As Boolean
    Private mChangedUnibox As Boolean
    Private mChangedGuidaEsperta As Boolean
    Private mChangedFinanziamento As Boolean
    Private mChangedRiparazione As Boolean
    Private mChangedFlexIncendioFurto As Boolean
    Private mChangedSinistroData As Boolean
    Private mChangedSinistroMalus As Boolean
    Private mChangedSinistroSoN As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ANA_ANALISIRCA
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

    Public Property IdPolizza() As Integer
        Get
            Return mIdPolizza
        End Get
        Set(value As Integer)
            mIdPolizza = value
        End Set
    End Property

    Public Property Polizza() As String
        Get
            Return mPolizza
        End Get
        Set(value As String)
            If mPolizza <> value Then
                mPolizza = value
                mChangedPolizza = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Convenzione() As String
        Get
            Return mConvenzione
        End Get
        Set(value As String)
            If mConvenzione <> value Then
                mConvenzione = value
                mChangedConvenzione = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DataScadenza() As DateTime
        Get
            Return mDataScadenza
        End Get
        Set(value As DateTime)
            If mDataScadenza <> value Then
                mDataScadenza = value
                mChangedDataScadenza = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TipoVeicolo() As String
        Get
            Return mTipoVeicolo
        End Get
        Set(value As String)
            If mTipoVeicolo <> value Then
                mTipoVeicolo = value
                mChangedTipoVeicolo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Marca() As String
        Get
            Return mMarca
        End Get
        Set(value As String)
            If mMarca <> value Then
                mMarca = value
                mChangedMarca = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Modello() As String
        Get
            Return mModello
        End Get
        Set(value As String)
            If mModello <> value Then
                mModello = value
                mChangedModello = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Targa() As String
        Get
            Return mTarga
        End Get
        Set(value As String)
            If mTarga <> value Then
                mTarga = value
                mChangedTarga = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property PremioOld() As Decimal
        Get
            Return mPremioOld
        End Get
        Set(value As Decimal)
            If mPremioOld <> value Then
                mPremioOld = value
                mChangedPremioOld = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property PremioNew() As Decimal
        Get
            Return mPremioNew
        End Get
        Set(value As Decimal)
            If mPremioNew <> value Then
                mPremioNew = value
                mChangedPremioNew = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Unibox() As String
        Get
            Return mUnibox
        End Get
        Set(value As String)
            If mUnibox <> value Then
                mUnibox = value
                mChangedUnibox = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property GuidaEsperta() As String
        Get
            Return mGuidaEsperta
        End Get
        Set(value As String)
            If mGuidaEsperta <> value Then
                mGuidaEsperta = value
                mChangedGuidaEsperta = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Finanziamento() As String
        Get
            Return mFinanziamento
        End Get
        Set(value As String)
            If mFinanziamento <> value Then
                mFinanziamento = value
                mChangedFinanziamento = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Riparazione() As String
        Get
            Return mRiparazione
        End Get
        Set(value As String)
            If mRiparazione <> value Then
                mRiparazione = value
                mChangedRiparazione = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property FlexIncendioFurto() As Integer
        Get
            Return mFlexIncendioFurto
        End Get
        Set(value As Integer)
            If mFlexIncendioFurto <> value Then
                mFlexIncendioFurto = value
                mChangedFlexIncendioFurto = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property SinistroData() As DateTime
        Get
            Return mSinistroData
        End Get
        Set(value As DateTime)
            If mSinistroData <> value Then
                mSinistroData = value
                mChangedSinistroData = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property SinistroMalus() As String
        Get
            Return mSinistroMalus
        End Get
        Set(value As String)
            If mSinistroMalus <> value Then
                mSinistroMalus = value
                mChangedSinistroMalus = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property SinistroSoN() As String
        Get
            Return mSinistroSoN
        End Get
        Set(value As String)
            If mSinistroSoN <> value Then
                mSinistroSoN = value
                mChangedSinistroSoN = True
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
            Key &= DELIMITER & mIdPolizza
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mCodiceFiscale = keys(0)
            mIdPolizza = keys(1)
        End Set
    End Property

    Public Function LoadByKey( _
                 CodiceFiscale As String _
                 , IdPolizza As Integer _
                ) As Boolean

        mCodiceFiscale = CodiceFiscale
        mIdPolizza = IdPolizza

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_ANALISIRCA
        End If

        With sql
            .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Where("IdPolizza", TipoEnum.TIPO_NUMERO) = mIdPolizza
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = ANA_ANALISIRCA
                .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
                mIdPolizza = .GetNextPrg("IdPolizza")
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_ANALISIRCA
        End If


        With sql
            .Field("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Field("IdPolizza", TipoEnum.TIPO_NUMERO) = mIdPolizza
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
                columnIndex = .GetOrdinal("IdPolizza")
                If Not .IsDBNull(columnIndex) Then
                    mIdPolizza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Polizza")
                If Not .IsDBNull(columnIndex) Then
                    mPolizza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Convenzione")
                If Not .IsDBNull(columnIndex) Then
                    mConvenzione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataScadenza")
                If Not .IsDBNull(columnIndex) Then
                    mDataScadenza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TipoVeicolo")
                If Not .IsDBNull(columnIndex) Then
                    mTipoVeicolo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Marca")
                If Not .IsDBNull(columnIndex) Then
                    mMarca = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Modello")
                If Not .IsDBNull(columnIndex) Then
                    mModello = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Targa")
                If Not .IsDBNull(columnIndex) Then
                    mTarga = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("PremioOld")
                If Not .IsDBNull(columnIndex) Then
                    mPremioOld = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("PremioNew")
                If Not .IsDBNull(columnIndex) Then
                    mPremioNew = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Unibox")
                If Not .IsDBNull(columnIndex) Then
                    mUnibox = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("GuidaEsperta")
                If Not .IsDBNull(columnIndex) Then
                    mGuidaEsperta = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Finanziamento")
                If Not .IsDBNull(columnIndex) Then
                    mFinanziamento = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Riparazione")
                If Not .IsDBNull(columnIndex) Then
                    mRiparazione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("FlexIncendioFurto")
                If Not .IsDBNull(columnIndex) Then
                    mFlexIncendioFurto = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SinistroData")
                If Not .IsDBNull(columnIndex) Then
                    mSinistroData = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SinistroMalus")
                If Not .IsDBNull(columnIndex) Then
                    mSinistroMalus = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SinistroSoN")
                If Not .IsDBNull(columnIndex) Then
                    mSinistroSoN = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedPolizza Then
                .Field("Polizza", TipoEnum.TIPO_STRINGA) = mPolizza
            End If
            If mChangedConvenzione Then
                .Field("Convenzione", TipoEnum.TIPO_STRINGA) = mConvenzione
            End If
            If mChangedDataScadenza Then
                .Field("DataScadenza", TipoEnum.TIPO_DATA) = mDataScadenza
            End If
            If mChangedTipoVeicolo Then
                .Field("TipoVeicolo", TipoEnum.TIPO_STRINGA) = mTipoVeicolo
            End If
            If mChangedMarca Then
                .Field("Marca", TipoEnum.TIPO_STRINGA) = mMarca
            End If
            If mChangedModello Then
                .Field("Modello", TipoEnum.TIPO_STRINGA) = mModello
            End If
            If mChangedTarga Then
                .Field("Targa", TipoEnum.TIPO_STRINGA) = mTarga
            End If
            If mChangedPremioOld Then
                .Field("PremioOld", TipoEnum.TIPO_VALUTA) = mPremioOld
            End If
            If mChangedPremioNew Then
                .Field("PremioNew", TipoEnum.TIPO_VALUTA) = mPremioNew
            End If
            If mChangedUnibox Then
                .Field("Unibox", TipoEnum.TIPO_STRINGA) = mUnibox
            End If
            If mChangedGuidaEsperta Then
                .Field("GuidaEsperta", TipoEnum.TIPO_STRINGA) = mGuidaEsperta
            End If
            If mChangedFinanziamento Then
                .Field("Finanziamento", TipoEnum.TIPO_STRINGA) = mFinanziamento
            End If
            If mChangedRiparazione Then
                .Field("Riparazione", TipoEnum.TIPO_STRINGA) = mRiparazione
            End If
            If mChangedFlexIncendioFurto Then
                .Field("FlexIncendioFurto", TipoEnum.TIPO_NUMERO) = mFlexIncendioFurto
            End If
            If mChangedSinistroData Then
                .Field("SinistroData", TipoEnum.TIPO_DATA) = mSinistroData
            End If
            If mChangedSinistroMalus Then
                .Field("SinistroMalus", TipoEnum.TIPO_STRINGA) = mSinistroMalus
            End If
            If mChangedSinistroSoN Then
                .Field("SinistroSoN", TipoEnum.TIPO_STRINGA) = mSinistroSoN
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedPolizza = False
        mChangedConvenzione = False
        mChangedDataScadenza = False
        mChangedTipoVeicolo = False
        mChangedMarca = False
        mChangedModello = False
        mChangedTarga = False
        mChangedPremioOld = False
        mChangedPremioNew = False
        mChangedUnibox = False
        mChangedGuidaEsperta = False
        mChangedFinanziamento = False
        mChangedRiparazione = False
        mChangedFlexIncendioFurto = False
        mChangedSinistroData = False
        mChangedSinistroMalus = False
        mChangedSinistroSoN = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mCodiceFiscale.Length = 0 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False
        If mPolizza.Length > 50 Then Ris = False
        If mConvenzione.Length > 255 Then Ris = False
        If mTipoVeicolo.Length > 20 Then Ris = False
        If mMarca.Length > 25 Then Ris = False
        If mModello.Length > 25 Then Ris = False
        If mTarga.Length > 25 Then Ris = False
        If mUnibox.Length > 1 Then Ris = False
        If mGuidaEsperta.Length > 1 Then Ris = False
        If mFinanziamento.Length > 1 Then Ris = False
        If mRiparazione.Length > 1 Then Ris = False
        If mSinistroMalus.Length > 1 Then Ris = False
        If mSinistroSoN.Length > 1 Then Ris = False

        Return Ris
    End Function


End Class
