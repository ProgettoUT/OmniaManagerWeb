Imports Utx.FunzioniDb.Funzioni


Public Class _TPolizze
    Inherits TBase
    Private Const sMODULENAME = "Polizze"
    Private Const POLIZZE = "[Polizze]"

    'Campi della tabella
    Private mCodiceFiscale As String
    Private mCodiceFiscaleCF As String
    Private mCodiceFiscaleEA As String
    Private mAgenzia As Integer
    Private mRamo As Integer
    Private mPolizza As Integer
    Private mDataEffetto As DateTime
    Private mDataScadenza As DateTime
    Private mDataPrimaQuietanza As DateTime
    Private mFrazionamento As Byte
    Private mCanale As String
    Private mCodiceSubAgente As Integer
    Private mCodiceSubAgenteSIMA As Integer
    Private mCodiceProduttore As Integer
    Private mCodiceProduttoreSIMA As Integer
    Private mCodiceProdotto As String
    Private mTotalePremioAnnuo As Double
    Private mTarga As String
    Private mCavalliFiscali As Integer
    Private mConvenzione As Integer
    Private mIDStorno As String
    Private mDataStorno As DateTime
    Private mTipoCarico As Integer
    Private mClausole As String
    Private mTipoTariffa As String
    Private mClasseBonusMalus As Integer
    Private mCombinazioneMassimali As Integer
    Private mSettoreTariffario As String
    Private mValoreIncendioFurto As Double
    Private mCodiceGaranzieAccessorie As Integer
    Private mCodiceGaranziaInfortuni As Integer
    Private mDiariaRitiroPatente As Double
    Private mCodiceUtilizzoVeicolo As String
    Private mAlimentazioneVeicolo As String
    Private mProfessioneRCA As Integer
    Private mCodicePagamento As Integer
    Private mCodiceProdottoOld As String
    Private mClasseRca As String
    Private mUsoRca As String
    Private mRamoGestione As Integer
    Private mTipoPolProd As Integer
    Private mImmatricVeicolo As String

    'Campi che possono essere aggiornati
    Private mChangedCodiceFiscale As Boolean
    Private mChangedCodiceFiscaleCF As Boolean
    Private mChangedCodiceFiscaleEA As Boolean
    Private mChangedDataEffetto As Boolean
    Private mChangedDataScadenza As Boolean
    Private mChangedDataPrimaQuietanza As Boolean
    Private mChangedFrazionamento As Boolean
    Private mChangedCanale As Boolean
    Private mChangedCodiceSubAgente As Boolean
    Private mChangedCodiceSubAgenteSIMA As Boolean
    Private mChangedCodiceProduttore As Boolean
    Private mChangedCodiceProduttoreSIMA As Boolean
    Private mChangedCodiceProdotto As Boolean
    Private mChangedTotalePremioAnnuo As Boolean
    Private mChangedTarga As Boolean
    Private mChangedCavalliFiscali As Boolean
    Private mChangedConvenzione As Boolean
    Private mChangedIDStorno As Boolean
    Private mChangedDataStorno As Boolean
    Private mChangedTipoCarico As Boolean
    Private mChangedClausole As Boolean
    Private mChangedTipoTariffa As Boolean
    Private mChangedClasseBonusMalus As Boolean
    Private mChangedCombinazioneMassimali As Boolean
    Private mChangedSettoreTariffario As Boolean
    Private mChangedValoreIncendioFurto As Boolean
    Private mChangedCodiceGaranzieAccessorie As Boolean
    Private mChangedCodiceGaranziaInfortuni As Boolean
    Private mChangedDiariaRitiroPatente As Boolean
    Private mChangedCodiceUtilizzoVeicolo As Boolean
    Private mChangedAlimentazioneVeicolo As Boolean
    Private mChangedProfessioneRCA As Boolean
    Private mChangedCodicePagamento As Boolean
    Private mChangedCodiceProdottoOld As Boolean
    Private mChangedClasseRca As Boolean
    Private mChangedUsoRca As Boolean
    Private mChangedRamoGestione As Boolean
    Private mChangedTipoPolProd As Boolean
    Private mChangedImmatricVeicolo As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return POLIZZE
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
            If mCodiceFiscale <> value Then
                mCodiceFiscale = value
                mChangedCodiceFiscale = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodiceFiscaleCF() As String
        Get
            Return mCodiceFiscaleCF
        End Get
        Set(value As String)
            If mCodiceFiscaleCF <> value Then
                mCodiceFiscaleCF = value
                mChangedCodiceFiscaleCF = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodiceFiscaleEA() As String
        Get
            Return mCodiceFiscaleEA
        End Get
        Set(value As String)
            If mCodiceFiscaleEA <> value Then
                mCodiceFiscaleEA = value
                mChangedCodiceFiscaleEA = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Agenzia() As Integer
        Get
            Return mAgenzia
        End Get
        Set(value As Integer)
            mAgenzia = value
        End Set
    End Property

    Public Property Ramo() As Integer
        Get
            Return mRamo
        End Get
        Set(value As Integer)
            mRamo = value
        End Set
    End Property

    Public Property Polizza() As Integer
        Get
            Return mPolizza
        End Get
        Set(value As Integer)
            mPolizza = value
        End Set
    End Property

    Public Property DataEffetto() As DateTime
        Get
            Return mDataEffetto
        End Get
        Set(value As DateTime)
            If mDataEffetto <> value Then
                mDataEffetto = value
                mChangedDataEffetto = True
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

    Public Property DataPrimaQuietanza() As DateTime
        Get
            Return mDataPrimaQuietanza
        End Get
        Set(value As DateTime)
            If mDataPrimaQuietanza <> value Then
                mDataPrimaQuietanza = value
                mChangedDataPrimaQuietanza = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Frazionamento() As Byte
        Get
            Return mFrazionamento
        End Get
        Set(value As Byte)
            If mFrazionamento <> value Then
                mFrazionamento = value
                mChangedFrazionamento = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Canale() As String
        Get
            Return mCanale
        End Get
        Set(value As String)
            If mCanale <> value Then
                mCanale = value
                mChangedCanale = True
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

    Public Property CodiceSubAgenteSIMA() As Integer
        Get
            Return mCodiceSubAgenteSIMA
        End Get
        Set(value As Integer)
            If mCodiceSubAgenteSIMA <> value Then
                mCodiceSubAgenteSIMA = value
                mChangedCodiceSubAgenteSIMA = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodiceProduttore() As Integer
        Get
            Return mCodiceProduttore
        End Get
        Set(value As Integer)
            If mCodiceProduttore <> value Then
                mCodiceProduttore = value
                mChangedCodiceProduttore = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodiceProduttoreSIMA() As Integer
        Get
            Return mCodiceProduttoreSIMA
        End Get
        Set(value As Integer)
            If mCodiceProduttoreSIMA <> value Then
                mCodiceProduttoreSIMA = value
                mChangedCodiceProduttoreSIMA = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodiceProdotto() As String
        Get
            Return mCodiceProdotto
        End Get
        Set(value As String)
            If mCodiceProdotto <> value Then
                mCodiceProdotto = value
                mChangedCodiceProdotto = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TotalePremioAnnuo() As Double
        Get
            Return mTotalePremioAnnuo
        End Get
        Set(value As Double)
            If mTotalePremioAnnuo <> value Then
                mTotalePremioAnnuo = value
                mChangedTotalePremioAnnuo = True
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

    Public Property CavalliFiscali() As Integer
        Get
            Return mCavalliFiscali
        End Get
        Set(value As Integer)
            If mCavalliFiscali <> value Then
                mCavalliFiscali = value
                mChangedCavalliFiscali = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Convenzione() As Integer
        Get
            Return mConvenzione
        End Get
        Set(value As Integer)
            If mConvenzione <> value Then
                mConvenzione = value
                mChangedConvenzione = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property IDStorno() As String
        Get
            Return mIDStorno
        End Get
        Set(value As String)
            If mIDStorno <> value Then
                mIDStorno = value
                mChangedIDStorno = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DataStorno() As DateTime
        Get
            Return mDataStorno
        End Get
        Set(value As DateTime)
            If mDataStorno <> value Then
                mDataStorno = value
                mChangedDataStorno = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TipoCarico() As Integer
        Get
            Return mTipoCarico
        End Get
        Set(value As Integer)
            If mTipoCarico <> value Then
                mTipoCarico = value
                mChangedTipoCarico = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Clausole() As String
        Get
            Return mClausole
        End Get
        Set(value As String)
            If mClausole <> value Then
                mClausole = value
                mChangedClausole = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TipoTariffa() As String
        Get
            Return mTipoTariffa
        End Get
        Set(value As String)
            If mTipoTariffa <> value Then
                mTipoTariffa = value
                mChangedTipoTariffa = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ClasseBonusMalus() As Integer
        Get
            Return mClasseBonusMalus
        End Get
        Set(value As Integer)
            If mClasseBonusMalus <> value Then
                mClasseBonusMalus = value
                mChangedClasseBonusMalus = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CombinazioneMassimali() As Integer
        Get
            Return mCombinazioneMassimali
        End Get
        Set(value As Integer)
            If mCombinazioneMassimali <> value Then
                mCombinazioneMassimali = value
                mChangedCombinazioneMassimali = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property SettoreTariffario() As String
        Get
            Return mSettoreTariffario
        End Get
        Set(value As String)
            If mSettoreTariffario <> value Then
                mSettoreTariffario = value
                mChangedSettoreTariffario = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ValoreIncendioFurto() As Double
        Get
            Return mValoreIncendioFurto
        End Get
        Set(value As Double)
            If mValoreIncendioFurto <> value Then
                mValoreIncendioFurto = value
                mChangedValoreIncendioFurto = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodiceGaranzieAccessorie() As Integer
        Get
            Return mCodiceGaranzieAccessorie
        End Get
        Set(value As Integer)
            If mCodiceGaranzieAccessorie <> value Then
                mCodiceGaranzieAccessorie = value
                mChangedCodiceGaranzieAccessorie = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodiceGaranziaInfortuni() As Integer
        Get
            Return mCodiceGaranziaInfortuni
        End Get
        Set(value As Integer)
            If mCodiceGaranziaInfortuni <> value Then
                mCodiceGaranziaInfortuni = value
                mChangedCodiceGaranziaInfortuni = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DiariaRitiroPatente() As Double
        Get
            Return mDiariaRitiroPatente
        End Get
        Set(value As Double)
            If mDiariaRitiroPatente <> value Then
                mDiariaRitiroPatente = value
                mChangedDiariaRitiroPatente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodiceUtilizzoVeicolo() As String
        Get
            Return mCodiceUtilizzoVeicolo
        End Get
        Set(value As String)
            If mCodiceUtilizzoVeicolo <> value Then
                mCodiceUtilizzoVeicolo = value
                mChangedCodiceUtilizzoVeicolo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AlimentazioneVeicolo() As String
        Get
            Return mAlimentazioneVeicolo
        End Get
        Set(value As String)
            If mAlimentazioneVeicolo <> value Then
                mAlimentazioneVeicolo = value
                mChangedAlimentazioneVeicolo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ProfessioneRCA() As Integer
        Get
            Return mProfessioneRCA
        End Get
        Set(value As Integer)
            If mProfessioneRCA <> value Then
                mProfessioneRCA = value
                mChangedProfessioneRCA = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodicePagamento() As Integer
        Get
            Return mCodicePagamento
        End Get
        Set(value As Integer)
            If mCodicePagamento <> value Then
                mCodicePagamento = value
                mChangedCodicePagamento = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodiceProdottoOld() As String
        Get
            Return mCodiceProdottoOld
        End Get
        Set(value As String)
            If mCodiceProdottoOld <> value Then
                mCodiceProdottoOld = value
                mChangedCodiceProdottoOld = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ClasseRca() As String
        Get
            Return mClasseRca
        End Get
        Set(value As String)
            If mClasseRca <> value Then
                mClasseRca = value
                mChangedClasseRca = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property UsoRca() As String
        Get
            Return mUsoRca
        End Get
        Set(value As String)
            If mUsoRca <> value Then
                mUsoRca = value
                mChangedUsoRca = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property RamoGestione() As Integer
        Get
            Return mRamoGestione
        End Get
        Set(value As Integer)
            If mRamoGestione <> value Then
                mRamoGestione = value
                mChangedRamoGestione = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TipoPolProd() As Integer
        Get
            Return mTipoPolProd
        End Get
        Set(value As Integer)
            If mTipoPolProd <> value Then
                mTipoPolProd = value
                mChangedTipoPolProd = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ImmatricVeicolo() As String
        Get
            Return mImmatricVeicolo
        End Get
        Set(value As String)
            If mImmatricVeicolo <> value Then
                mImmatricVeicolo = value
                mChangedImmatricVeicolo = True
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
            Key &= DELIMITER & mAgenzia
            Key &= DELIMITER & mRamo
            Key &= DELIMITER & mPolizza
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mAgenzia = keys(0)
            mRamo = keys(1)
            mPolizza = keys(2)
        End Set
    End Property

    Public Function LoadByKey( _
                 Agenzia As Integer _
                 , Ramo As Integer _
                 , Polizza As Integer _
                ) As Boolean

        mAgenzia = Agenzia
        mRamo = Ramo
        mPolizza = Polizza

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = POLIZZE
        End If

        With sql
            .Where("Agenzia", TipoEnum.TIPO_NUMERO) = mAgenzia
            .Where("Ramo", TipoEnum.TIPO_NUMERO) = mRamo
            .Where("Polizza", TipoEnum.TIPO_NUMERO) = mPolizza
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = POLIZZE
                mAgenzia = .GetNextPrg("Agenzia")
                mRamo = .GetNextPrg("Ramo")
                mPolizza = .GetNextPrg("Polizza")
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = POLIZZE
        End If


        With sql
            .Field("Agenzia", TipoEnum.TIPO_NUMERO) = mAgenzia
            .Field("Ramo", TipoEnum.TIPO_NUMERO) = mRamo
            .Field("Polizza", TipoEnum.TIPO_NUMERO) = mPolizza
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
                columnIndex = .GetOrdinal("CodiceFiscaleCF")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceFiscaleCF = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceFiscaleEA")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceFiscaleEA = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Agenzia")
                If Not .IsDBNull(columnIndex) Then
                    mAgenzia = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Ramo")
                If Not .IsDBNull(columnIndex) Then
                    mRamo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Polizza")
                If Not .IsDBNull(columnIndex) Then
                    mPolizza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataEffetto")
                If Not .IsDBNull(columnIndex) Then
                    mDataEffetto = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataScadenza")
                If Not .IsDBNull(columnIndex) Then
                    mDataScadenza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataPrimaQuietanza")
                If Not .IsDBNull(columnIndex) Then
                    mDataPrimaQuietanza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Frazionamento")
                If Not .IsDBNull(columnIndex) Then
                    mFrazionamento = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Canale")
                If Not .IsDBNull(columnIndex) Then
                    mCanale = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceSubAgente")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceSubAgente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceSubAgenteSIMA")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceSubAgenteSIMA = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceProduttore")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceProduttore = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceProduttoreSIMA")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceProduttoreSIMA = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceProdotto")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceProdotto = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TotalePremioAnnuo")
                If Not .IsDBNull(columnIndex) Then
                    mTotalePremioAnnuo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Targa")
                If Not .IsDBNull(columnIndex) Then
                    mTarga = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CavalliFiscali")
                If Not .IsDBNull(columnIndex) Then
                    mCavalliFiscali = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Convenzione")
                If Not .IsDBNull(columnIndex) Then
                    mConvenzione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("IDStorno")
                If Not .IsDBNull(columnIndex) Then
                    mIDStorno = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataStorno")
                If Not .IsDBNull(columnIndex) Then
                    mDataStorno = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TipoCarico")
                If Not .IsDBNull(columnIndex) Then
                    mTipoCarico = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Clausole")
                If Not .IsDBNull(columnIndex) Then
                    mClausole = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TipoTariffa")
                If Not .IsDBNull(columnIndex) Then
                    mTipoTariffa = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ClasseBonusMalus")
                If Not .IsDBNull(columnIndex) Then
                    mClasseBonusMalus = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CombinazioneMassimali")
                If Not .IsDBNull(columnIndex) Then
                    mCombinazioneMassimali = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SettoreTariffario")
                If Not .IsDBNull(columnIndex) Then
                    mSettoreTariffario = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ValoreIncendioFurto")
                If Not .IsDBNull(columnIndex) Then
                    mValoreIncendioFurto = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceGaranzieAccessorie")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceGaranzieAccessorie = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceGaranziaInfortuni")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceGaranziaInfortuni = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DiariaRitiroPatente")
                If Not .IsDBNull(columnIndex) Then
                    mDiariaRitiroPatente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceUtilizzoVeicolo")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceUtilizzoVeicolo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AlimentazioneVeicolo")
                If Not .IsDBNull(columnIndex) Then
                    mAlimentazioneVeicolo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ProfessioneRCA")
                If Not .IsDBNull(columnIndex) Then
                    mProfessioneRCA = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodicePagamento")
                If Not .IsDBNull(columnIndex) Then
                    mCodicePagamento = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceProdottoOld")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceProdottoOld = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ClasseRca")
                If Not .IsDBNull(columnIndex) Then
                    mClasseRca = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("UsoRca")
                If Not .IsDBNull(columnIndex) Then
                    mUsoRca = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("RamoGestione")
                If Not .IsDBNull(columnIndex) Then
                    mRamoGestione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TipoPolProd")
                If Not .IsDBNull(columnIndex) Then
                    mTipoPolProd = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ImmatricVeicolo")
                If Not .IsDBNull(columnIndex) Then
                    mImmatricVeicolo = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedCodiceFiscale Then
                .Field("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            End If
            If mChangedCodiceFiscaleCF Then
                .Field("CodiceFiscaleCF", TipoEnum.TIPO_STRINGA) = mCodiceFiscaleCF
            End If
            If mChangedCodiceFiscaleEA Then
                .Field("CodiceFiscaleEA", TipoEnum.TIPO_STRINGA) = mCodiceFiscaleEA
            End If
            If mChangedDataEffetto Then
                .Field("DataEffetto", TipoEnum.TIPO_DATA) = mDataEffetto
            End If
            If mChangedDataScadenza Then
                .Field("DataScadenza", TipoEnum.TIPO_DATA) = mDataScadenza
            End If
            If mChangedDataPrimaQuietanza Then
                .Field("DataPrimaQuietanza", TipoEnum.TIPO_DATA) = mDataPrimaQuietanza
            End If
            If mChangedFrazionamento Then
                .Field("Frazionamento", TipoEnum.TIPO_NUMERO) = mFrazionamento
            End If
            If mChangedCanale Then
                .Field("Canale", TipoEnum.TIPO_STRINGA) = mCanale
            End If
            If mChangedCodiceSubAgente Then
                .Field("CodiceSubAgente", TipoEnum.TIPO_NUMERO) = mCodiceSubAgente
            End If
            If mChangedCodiceSubAgenteSIMA Then
                .Field("CodiceSubAgenteSIMA", TipoEnum.TIPO_NUMERO) = mCodiceSubAgenteSIMA
            End If
            If mChangedCodiceProduttore Then
                .Field("CodiceProduttore", TipoEnum.TIPO_NUMERO) = mCodiceProduttore
            End If
            If mChangedCodiceProduttoreSIMA Then
                .Field("CodiceProduttoreSIMA", TipoEnum.TIPO_NUMERO) = mCodiceProduttoreSIMA
            End If
            If mChangedCodiceProdotto Then
                .Field("CodiceProdotto", TipoEnum.TIPO_STRINGA) = mCodiceProdotto
            End If
            If mChangedTotalePremioAnnuo Then
                .Field("TotalePremioAnnuo", TipoEnum.TIPO_NUMERO) = mTotalePremioAnnuo
            End If
            If mChangedTarga Then
                .Field("Targa", TipoEnum.TIPO_STRINGA) = mTarga
            End If
            If mChangedCavalliFiscali Then
                .Field("CavalliFiscali", TipoEnum.TIPO_NUMERO) = mCavalliFiscali
            End If
            If mChangedConvenzione Then
                .Field("Convenzione", TipoEnum.TIPO_NUMERO) = mConvenzione
            End If
            If mChangedIDStorno Then
                .Field("IDStorno", TipoEnum.TIPO_STRINGA) = mIDStorno
            End If
            If mChangedDataStorno Then
                .Field("DataStorno", TipoEnum.TIPO_DATA) = mDataStorno
            End If
            If mChangedTipoCarico Then
                .Field("TipoCarico", TipoEnum.TIPO_NUMERO) = mTipoCarico
            End If
            If mChangedClausole Then
                .Field("Clausole", TipoEnum.TIPO_STRINGA) = mClausole
            End If
            If mChangedTipoTariffa Then
                .Field("TipoTariffa", TipoEnum.TIPO_STRINGA) = mTipoTariffa
            End If
            If mChangedClasseBonusMalus Then
                .Field("ClasseBonusMalus", TipoEnum.TIPO_NUMERO) = mClasseBonusMalus
            End If
            If mChangedCombinazioneMassimali Then
                .Field("CombinazioneMassimali", TipoEnum.TIPO_NUMERO) = mCombinazioneMassimali
            End If
            If mChangedSettoreTariffario Then
                .Field("SettoreTariffario", TipoEnum.TIPO_STRINGA) = mSettoreTariffario
            End If
            If mChangedValoreIncendioFurto Then
                .Field("ValoreIncendioFurto", TipoEnum.TIPO_NUMERO) = mValoreIncendioFurto
            End If
            If mChangedCodiceGaranzieAccessorie Then
                .Field("CodiceGaranzieAccessorie", TipoEnum.TIPO_NUMERO) = mCodiceGaranzieAccessorie
            End If
            If mChangedCodiceGaranziaInfortuni Then
                .Field("CodiceGaranziaInfortuni", TipoEnum.TIPO_NUMERO) = mCodiceGaranziaInfortuni
            End If
            If mChangedDiariaRitiroPatente Then
                .Field("DiariaRitiroPatente", TipoEnum.TIPO_NUMERO) = mDiariaRitiroPatente
            End If
            If mChangedCodiceUtilizzoVeicolo Then
                .Field("CodiceUtilizzoVeicolo", TipoEnum.TIPO_STRINGA) = mCodiceUtilizzoVeicolo
            End If
            If mChangedAlimentazioneVeicolo Then
                .Field("AlimentazioneVeicolo", TipoEnum.TIPO_STRINGA) = mAlimentazioneVeicolo
            End If
            If mChangedProfessioneRCA Then
                .Field("ProfessioneRCA", TipoEnum.TIPO_NUMERO) = mProfessioneRCA
            End If
            If mChangedCodicePagamento Then
                .Field("CodicePagamento", TipoEnum.TIPO_NUMERO) = mCodicePagamento
            End If
            If mChangedCodiceProdottoOld Then
                .Field("CodiceProdottoOld", TipoEnum.TIPO_STRINGA) = mCodiceProdottoOld
            End If
            If mChangedClasseRca Then
                .Field("ClasseRca", TipoEnum.TIPO_STRINGA) = mClasseRca
            End If
            If mChangedUsoRca Then
                .Field("UsoRca", TipoEnum.TIPO_STRINGA) = mUsoRca
            End If
            If mChangedRamoGestione Then
                .Field("RamoGestione", TipoEnum.TIPO_NUMERO) = mRamoGestione
            End If
            If mChangedTipoPolProd Then
                .Field("TipoPolProd", TipoEnum.TIPO_NUMERO) = mTipoPolProd
            End If
            If mChangedImmatricVeicolo Then
                .Field("ImmatricVeicolo", TipoEnum.TIPO_STRINGA) = mImmatricVeicolo
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedCodiceFiscale = False
        mChangedCodiceFiscaleCF = False
        mChangedCodiceFiscaleEA = False
        mChangedDataEffetto = False
        mChangedDataScadenza = False
        mChangedDataPrimaQuietanza = False
        mChangedFrazionamento = False
        mChangedCanale = False
        mChangedCodiceSubAgente = False
        mChangedCodiceSubAgenteSIMA = False
        mChangedCodiceProduttore = False
        mChangedCodiceProduttoreSIMA = False
        mChangedCodiceProdotto = False
        mChangedTotalePremioAnnuo = False
        mChangedTarga = False
        mChangedCavalliFiscali = False
        mChangedConvenzione = False
        mChangedIDStorno = False
        mChangedDataStorno = False
        mChangedTipoCarico = False
        mChangedClausole = False
        mChangedTipoTariffa = False
        mChangedClasseBonusMalus = False
        mChangedCombinazioneMassimali = False
        mChangedSettoreTariffario = False
        mChangedValoreIncendioFurto = False
        mChangedCodiceGaranzieAccessorie = False
        mChangedCodiceGaranziaInfortuni = False
        mChangedDiariaRitiroPatente = False
        mChangedCodiceUtilizzoVeicolo = False
        mChangedAlimentazioneVeicolo = False
        mChangedProfessioneRCA = False
        mChangedCodicePagamento = False
        mChangedCodiceProdottoOld = False
        mChangedClasseRca = False
        mChangedUsoRca = False
        mChangedRamoGestione = False
        mChangedTipoPolProd = False
        mChangedImmatricVeicolo = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mCodiceFiscale.Length > 16 Then Ris = False
        If mCodiceFiscaleCF.Length > 16 Then Ris = False
        If mCodiceFiscaleEA.Length > 16 Then Ris = False
        If mCanale.Length > 10 Then Ris = False
        If mCodiceProdotto.Length > 5 Then Ris = False
        If mTarga.Length > 9 Then Ris = False
        If mIDStorno.Length > 2 Then Ris = False
        If mClausole.Length > 41 Then Ris = False
        If mTipoTariffa.Length > 1 Then Ris = False
        If mSettoreTariffario.Length > 1 Then Ris = False
        If mCodiceUtilizzoVeicolo.Length > 1 Then Ris = False
        If mAlimentazioneVeicolo.Length > 1 Then Ris = False
        If mCodiceProdottoOld.Length > 5 Then Ris = False
        If mClasseRca.Length > 2 Then Ris = False
        If mUsoRca.Length > 2 Then Ris = False
        If mImmatricVeicolo.Length > 6 Then Ris = False

        Return Ris
    End Function


End Class
