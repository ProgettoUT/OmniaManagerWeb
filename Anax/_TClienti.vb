Imports Utx.FunzioniDb.Funzioni


Public Class _TClienti
    Inherits TBase
    Private Const sMODULENAME = "Clienti"
    Private Const CLIENTI = "[Clienti]"

    'Campi della tabella
    Private mCodiceFiscale As String
    Private mCognome As String
    Private mNome As String
    Private mDataNascita As DateTime
    Private mIndirizzo As String
    Private mCap As Integer
    Private mLocalita As String
    Private mComuneCAB As Integer
    Private mStatoCAB As Integer
    Private mProvincia As String
    Private mTelefono1 As String
    Private mTelefono2 As String
    Private mSesso As String
    Private mCapofamiglia As String
    Private mCodiceFiscaleCF As String
    Private mCodiceFiscaleEA As String
    Private mClienteTop As String
    Private mDataTop As DateTime
    Private mProduttore As Integer
    Private mStatoCivile As String
    Private mNucleoFamiliare As Integer
    Private mPrimaCasa As String
    Private mAltriImmobili As String
    Private mTitoliStato As String
    Private mFasciaReddito As String
    Private mSindacati As String
    Private mPolizzeAltreComp As String
    Private mCartaCredito As String
    Private mEsclusioneAttivita As String
    Private mEnte As String
    Private mTipoCliente As Integer
    Private mIDSegmentoCorrente As Integer
    Private mIDSegmentoPrecedente As Integer
    Private mIDStatoCliente As String
    Private mIDZona As Integer
    Private mDataInserimento As DateTime
    Private mDataCessazione As DateTime
    Private mAgenziaPrevalente As Integer
    Private mSubAgenzia As Integer
    Private mSubAgenziaSIMA As Integer
    Private mDataUltimaVisita As DateTime
    Private mDataProssimaVisita As DateTime
    Private mPolizzeVigore As Integer
    Private mPolizzeStoriche As Integer
    Private mPremiCorrente As Double
    Private mSinistriCorrente As Integer
    Private mLiquidatoCorrente As Double
    Private mPremiPrecedente As Double
    Private mSinistriPrecedente As Integer
    Private mLiquidatoPrecedente As Double
    Private mPremiTotale As Double
    Private mSinistriTotale As Integer
    Private mLiquidatoTotale As Double
    Private mConsensoPrivacy As String
    Private mRilascioPatente As String
    Private mEmail As String
    Private mFax As String
    Private mCellulare As String
    Private mTelReferente As String
    Private mNomeReferente As String
    Private mTelAziendale As String
    Private mCodAvvisoScadenza As String
    Private mAnnoMeseInizioEsclTemp As String
    Private mAnnoMeseFineEsclTemp As String
    Private mCodModalitaIncasso As String
    Private mFlag1 As Integer
    Private mFlag2 As Integer
    Private mFlag3 As Integer
    Private mRisTelefono As String
    Private mRisTelefonoNota As String
    Private mRisCellulare As String
    Private mRisCellulareNota As String
    Private mRisMail As String
    Private mRisMailNota As String

    'Campi che possono essere aggiornati
    Private mChangedCognome As Boolean
    Private mChangedNome As Boolean
    Private mChangedDataNascita As Boolean
    Private mChangedIndirizzo As Boolean
    Private mChangedCap As Boolean
    Private mChangedLocalita As Boolean
    Private mChangedComuneCAB As Boolean
    Private mChangedStatoCAB As Boolean
    Private mChangedProvincia As Boolean
    Private mChangedTelefono1 As Boolean
    Private mChangedTelefono2 As Boolean
    Private mChangedSesso As Boolean
    Private mChangedCapofamiglia As Boolean
    Private mChangedCodiceFiscaleCF As Boolean
    Private mChangedCodiceFiscaleEA As Boolean
    Private mChangedClienteTop As Boolean
    Private mChangedDataTop As Boolean
    Private mChangedProduttore As Boolean
    Private mChangedStatoCivile As Boolean
    Private mChangedNucleoFamiliare As Boolean
    Private mChangedPrimaCasa As Boolean
    Private mChangedAltriImmobili As Boolean
    Private mChangedTitoliStato As Boolean
    Private mChangedFasciaReddito As Boolean
    Private mChangedSindacati As Boolean
    Private mChangedPolizzeAltreComp As Boolean
    Private mChangedCartaCredito As Boolean
    Private mChangedEsclusioneAttivita As Boolean
    Private mChangedEnte As Boolean
    Private mChangedTipoCliente As Boolean
    Private mChangedIDSegmentoCorrente As Boolean
    Private mChangedIDSegmentoPrecedente As Boolean
    Private mChangedIDStatoCliente As Boolean
    Private mChangedIDZona As Boolean
    Private mChangedDataInserimento As Boolean
    Private mChangedDataCessazione As Boolean
    Private mChangedAgenziaPrevalente As Boolean
    Private mChangedSubAgenzia As Boolean
    Private mChangedSubAgenziaSIMA As Boolean
    Private mChangedDataUltimaVisita As Boolean
    Private mChangedDataProssimaVisita As Boolean
    Private mChangedPolizzeVigore As Boolean
    Private mChangedPolizzeStoriche As Boolean
    Private mChangedPremiCorrente As Boolean
    Private mChangedSinistriCorrente As Boolean
    Private mChangedLiquidatoCorrente As Boolean
    Private mChangedPremiPrecedente As Boolean
    Private mChangedSinistriPrecedente As Boolean
    Private mChangedLiquidatoPrecedente As Boolean
    Private mChangedPremiTotale As Boolean
    Private mChangedSinistriTotale As Boolean
    Private mChangedLiquidatoTotale As Boolean
    Private mChangedConsensoPrivacy As Boolean
    Private mChangedRilascioPatente As Boolean
    Private mChangedEmail As Boolean
    Private mChangedFax As Boolean
    Private mChangedCellulare As Boolean
    Private mChangedTelReferente As Boolean
    Private mChangedNomeReferente As Boolean
    Private mChangedTelAziendale As Boolean
    Private mChangedCodAvvisoScadenza As Boolean
    Private mChangedAnnoMeseInizioEsclTemp As Boolean
    Private mChangedAnnoMeseFineEsclTemp As Boolean
    Private mChangedCodModalitaIncasso As Boolean
    Private mChangedFlag1 As Boolean
    Private mChangedFlag2 As Boolean
    Private mChangedFlag3 As Boolean
    Private mChangedRisTelefono As Boolean
    Private mChangedRisTelefonoNota As Boolean
    Private mChangedRisCellulare As Boolean
    Private mChangedRisCellulareNota As Boolean
    Private mChangedRisMail As Boolean
    Private mChangedRisMailNota As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return CLIENTI
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

    Public Property Cognome() As String
        Get
            Return mCognome
        End Get
        Set(value As String)
            If mCognome <> value Then
                mCognome = value
                mChangedCognome = True
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

    Public Property DataNascita() As DateTime
        Get
            Return mDataNascita
        End Get
        Set(value As DateTime)
            If mDataNascita <> value Then
                mDataNascita = value
                mChangedDataNascita = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Indirizzo() As String
        Get
            Return mIndirizzo
        End Get
        Set(value As String)
            If mIndirizzo <> value Then
                mIndirizzo = value
                mChangedIndirizzo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Cap() As Integer
        Get
            Return mCap
        End Get
        Set(value As Integer)
            If mCap <> value Then
                mCap = value
                mChangedCap = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Localita() As String
        Get
            Return mLocalita
        End Get
        Set(value As String)
            If mLocalita <> value Then
                mLocalita = value
                mChangedLocalita = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ComuneCAB() As Integer
        Get
            Return mComuneCAB
        End Get
        Set(value As Integer)
            If mComuneCAB <> value Then
                mComuneCAB = value
                mChangedComuneCAB = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property StatoCAB() As Integer
        Get
            Return mStatoCAB
        End Get
        Set(value As Integer)
            If mStatoCAB <> value Then
                mStatoCAB = value
                mChangedStatoCAB = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Provincia() As String
        Get
            Return mProvincia
        End Get
        Set(value As String)
            If mProvincia <> value Then
                mProvincia = value
                mChangedProvincia = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Telefono1() As String
        Get
            Return mTelefono1
        End Get
        Set(value As String)
            If mTelefono1 <> value Then
                mTelefono1 = value
                mChangedTelefono1 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Telefono2() As String
        Get
            Return mTelefono2
        End Get
        Set(value As String)
            If mTelefono2 <> value Then
                mTelefono2 = value
                mChangedTelefono2 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Sesso() As String
        Get
            Return mSesso
        End Get
        Set(value As String)
            If mSesso <> value Then
                mSesso = value
                mChangedSesso = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Capofamiglia() As String
        Get
            Return mCapofamiglia
        End Get
        Set(value As String)
            If mCapofamiglia <> value Then
                mCapofamiglia = value
                mChangedCapofamiglia = True
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

    Public Property ClienteTop() As String
        Get
            Return mClienteTop
        End Get
        Set(value As String)
            If mClienteTop <> value Then
                mClienteTop = value
                mChangedClienteTop = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DataTop() As DateTime
        Get
            Return mDataTop
        End Get
        Set(value As DateTime)
            If mDataTop <> value Then
                mDataTop = value
                mChangedDataTop = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Produttore() As Integer
        Get
            Return mProduttore
        End Get
        Set(value As Integer)
            If mProduttore <> value Then
                mProduttore = value
                mChangedProduttore = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property StatoCivile() As String
        Get
            Return mStatoCivile
        End Get
        Set(value As String)
            If mStatoCivile <> value Then
                mStatoCivile = value
                mChangedStatoCivile = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property NucleoFamiliare() As Integer
        Get
            Return mNucleoFamiliare
        End Get
        Set(value As Integer)
            If mNucleoFamiliare <> value Then
                mNucleoFamiliare = value
                mChangedNucleoFamiliare = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property PrimaCasa() As String
        Get
            Return mPrimaCasa
        End Get
        Set(value As String)
            If mPrimaCasa <> value Then
                mPrimaCasa = value
                mChangedPrimaCasa = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AltriImmobili() As String
        Get
            Return mAltriImmobili
        End Get
        Set(value As String)
            If mAltriImmobili <> value Then
                mAltriImmobili = value
                mChangedAltriImmobili = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TitoliStato() As String
        Get
            Return mTitoliStato
        End Get
        Set(value As String)
            If mTitoliStato <> value Then
                mTitoliStato = value
                mChangedTitoliStato = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property FasciaReddito() As String
        Get
            Return mFasciaReddito
        End Get
        Set(value As String)
            If mFasciaReddito <> value Then
                mFasciaReddito = value
                mChangedFasciaReddito = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Sindacati() As String
        Get
            Return mSindacati
        End Get
        Set(value As String)
            If mSindacati <> value Then
                mSindacati = value
                mChangedSindacati = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property PolizzeAltreComp() As String
        Get
            Return mPolizzeAltreComp
        End Get
        Set(value As String)
            If mPolizzeAltreComp <> value Then
                mPolizzeAltreComp = value
                mChangedPolizzeAltreComp = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CartaCredito() As String
        Get
            Return mCartaCredito
        End Get
        Set(value As String)
            If mCartaCredito <> value Then
                mCartaCredito = value
                mChangedCartaCredito = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property EsclusioneAttivita() As String
        Get
            Return mEsclusioneAttivita
        End Get
        Set(value As String)
            If mEsclusioneAttivita <> value Then
                mEsclusioneAttivita = value
                mChangedEsclusioneAttivita = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Ente() As String
        Get
            Return mEnte
        End Get
        Set(value As String)
            If mEnte <> value Then
                mEnte = value
                mChangedEnte = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TipoCliente() As Integer
        Get
            Return mTipoCliente
        End Get
        Set(value As Integer)
            If mTipoCliente <> value Then
                mTipoCliente = value
                mChangedTipoCliente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property IDSegmentoCorrente() As Integer
        Get
            Return mIDSegmentoCorrente
        End Get
        Set(value As Integer)
            If mIDSegmentoCorrente <> value Then
                mIDSegmentoCorrente = value
                mChangedIDSegmentoCorrente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property IDSegmentoPrecedente() As Integer
        Get
            Return mIDSegmentoPrecedente
        End Get
        Set(value As Integer)
            If mIDSegmentoPrecedente <> value Then
                mIDSegmentoPrecedente = value
                mChangedIDSegmentoPrecedente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property IDStatoCliente() As String
        Get
            Return mIDStatoCliente
        End Get
        Set(value As String)
            If mIDStatoCliente <> value Then
                mIDStatoCliente = value
                mChangedIDStatoCliente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property IDZona() As Integer
        Get
            Return mIDZona
        End Get
        Set(value As Integer)
            If mIDZona <> value Then
                mIDZona = value
                mChangedIDZona = True
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

    Public Property DataCessazione() As DateTime
        Get
            Return mDataCessazione
        End Get
        Set(value As DateTime)
            If mDataCessazione <> value Then
                mDataCessazione = value
                mChangedDataCessazione = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AgenziaPrevalente() As Integer
        Get
            Return mAgenziaPrevalente
        End Get
        Set(value As Integer)
            If mAgenziaPrevalente <> value Then
                mAgenziaPrevalente = value
                mChangedAgenziaPrevalente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property SubAgenzia() As Integer
        Get
            Return mSubAgenzia
        End Get
        Set(value As Integer)
            If mSubAgenzia <> value Then
                mSubAgenzia = value
                mChangedSubAgenzia = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property SubAgenziaSIMA() As Integer
        Get
            Return mSubAgenziaSIMA
        End Get
        Set(value As Integer)
            If mSubAgenziaSIMA <> value Then
                mSubAgenziaSIMA = value
                mChangedSubAgenziaSIMA = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DataUltimaVisita() As DateTime
        Get
            Return mDataUltimaVisita
        End Get
        Set(value As DateTime)
            If mDataUltimaVisita <> value Then
                mDataUltimaVisita = value
                mChangedDataUltimaVisita = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DataProssimaVisita() As DateTime
        Get
            Return mDataProssimaVisita
        End Get
        Set(value As DateTime)
            If mDataProssimaVisita <> value Then
                mDataProssimaVisita = value
                mChangedDataProssimaVisita = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property PolizzeVigore() As Integer
        Get
            Return mPolizzeVigore
        End Get
        Set(value As Integer)
            If mPolizzeVigore <> value Then
                mPolizzeVigore = value
                mChangedPolizzeVigore = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property PolizzeStoriche() As Integer
        Get
            Return mPolizzeStoriche
        End Get
        Set(value As Integer)
            If mPolizzeStoriche <> value Then
                mPolizzeStoriche = value
                mChangedPolizzeStoriche = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property PremiCorrente() As Double
        Get
            Return mPremiCorrente
        End Get
        Set(value As Double)
            If mPremiCorrente <> value Then
                mPremiCorrente = value
                mChangedPremiCorrente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property SinistriCorrente() As Integer
        Get
            Return mSinistriCorrente
        End Get
        Set(value As Integer)
            If mSinistriCorrente <> value Then
                mSinistriCorrente = value
                mChangedSinistriCorrente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property LiquidatoCorrente() As Double
        Get
            Return mLiquidatoCorrente
        End Get
        Set(value As Double)
            If mLiquidatoCorrente <> value Then
                mLiquidatoCorrente = value
                mChangedLiquidatoCorrente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property PremiPrecedente() As Double
        Get
            Return mPremiPrecedente
        End Get
        Set(value As Double)
            If mPremiPrecedente <> value Then
                mPremiPrecedente = value
                mChangedPremiPrecedente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property SinistriPrecedente() As Integer
        Get
            Return mSinistriPrecedente
        End Get
        Set(value As Integer)
            If mSinistriPrecedente <> value Then
                mSinistriPrecedente = value
                mChangedSinistriPrecedente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property LiquidatoPrecedente() As Double
        Get
            Return mLiquidatoPrecedente
        End Get
        Set(value As Double)
            If mLiquidatoPrecedente <> value Then
                mLiquidatoPrecedente = value
                mChangedLiquidatoPrecedente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property PremiTotale() As Double
        Get
            Return mPremiTotale
        End Get
        Set(value As Double)
            If mPremiTotale <> value Then
                mPremiTotale = value
                mChangedPremiTotale = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property SinistriTotale() As Integer
        Get
            Return mSinistriTotale
        End Get
        Set(value As Integer)
            If mSinistriTotale <> value Then
                mSinistriTotale = value
                mChangedSinistriTotale = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property LiquidatoTotale() As Double
        Get
            Return mLiquidatoTotale
        End Get
        Set(value As Double)
            If mLiquidatoTotale <> value Then
                mLiquidatoTotale = value
                mChangedLiquidatoTotale = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ConsensoPrivacy() As String
        Get
            Return mConsensoPrivacy
        End Get
        Set(value As String)
            If mConsensoPrivacy <> value Then
                mConsensoPrivacy = value
                mChangedConsensoPrivacy = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property RilascioPatente() As String
        Get
            Return mRilascioPatente
        End Get
        Set(value As String)
            If mRilascioPatente <> value Then
                mRilascioPatente = value
                mChangedRilascioPatente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Email() As String
        Get
            Return mEmail
        End Get
        Set(value As String)
            If mEmail <> value Then
                mEmail = value
                mChangedEmail = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Fax() As String
        Get
            Return mFax
        End Get
        Set(value As String)
            If mFax <> value Then
                mFax = value
                mChangedFax = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Cellulare() As String
        Get
            Return mCellulare
        End Get
        Set(value As String)
            If mCellulare <> value Then
                mCellulare = value
                mChangedCellulare = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TelReferente() As String
        Get
            Return mTelReferente
        End Get
        Set(value As String)
            If mTelReferente <> value Then
                mTelReferente = value
                mChangedTelReferente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property NomeReferente() As String
        Get
            Return mNomeReferente
        End Get
        Set(value As String)
            If mNomeReferente <> value Then
                mNomeReferente = value
                mChangedNomeReferente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TelAziendale() As String
        Get
            Return mTelAziendale
        End Get
        Set(value As String)
            If mTelAziendale <> value Then
                mTelAziendale = value
                mChangedTelAziendale = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodAvvisoScadenza() As String
        Get
            Return mCodAvvisoScadenza
        End Get
        Set(value As String)
            If mCodAvvisoScadenza <> value Then
                mCodAvvisoScadenza = value
                mChangedCodAvvisoScadenza = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AnnoMeseInizioEsclTemp() As String
        Get
            Return mAnnoMeseInizioEsclTemp
        End Get
        Set(value As String)
            If mAnnoMeseInizioEsclTemp <> value Then
                mAnnoMeseInizioEsclTemp = value
                mChangedAnnoMeseInizioEsclTemp = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AnnoMeseFineEsclTemp() As String
        Get
            Return mAnnoMeseFineEsclTemp
        End Get
        Set(value As String)
            If mAnnoMeseFineEsclTemp <> value Then
                mAnnoMeseFineEsclTemp = value
                mChangedAnnoMeseFineEsclTemp = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodModalitaIncasso() As String
        Get
            Return mCodModalitaIncasso
        End Get
        Set(value As String)
            If mCodModalitaIncasso <> value Then
                mCodModalitaIncasso = value
                mChangedCodModalitaIncasso = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Flag1() As Integer
        Get
            Return mFlag1
        End Get
        Set(value As Integer)
            If mFlag1 <> value Then
                mFlag1 = value
                mChangedFlag1 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Flag2() As Integer
        Get
            Return mFlag2
        End Get
        Set(value As Integer)
            If mFlag2 <> value Then
                mFlag2 = value
                mChangedFlag2 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Flag3() As Integer
        Get
            Return mFlag3
        End Get
        Set(value As Integer)
            If mFlag3 <> value Then
                mFlag3 = value
                mChangedFlag3 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property RisTelefono() As String
        Get
            Return mRisTelefono
        End Get
        Set(value As String)
            If mRisTelefono <> value Then
                mRisTelefono = value
                mChangedRisTelefono = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property RisTelefonoNota() As String
        Get
            Return mRisTelefonoNota
        End Get
        Set(value As String)
            If mRisTelefonoNota <> value Then
                mRisTelefonoNota = value
                mChangedRisTelefonoNota = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property RisCellulare() As String
        Get
            Return mRisCellulare
        End Get
        Set(value As String)
            If mRisCellulare <> value Then
                mRisCellulare = value
                mChangedRisCellulare = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property RisCellulareNota() As String
        Get
            Return mRisCellulareNota
        End Get
        Set(value As String)
            If mRisCellulareNota <> value Then
                mRisCellulareNota = value
                mChangedRisCellulareNota = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property RisMail() As String
        Get
            Return mRisMail
        End Get
        Set(value As String)
            If mRisMail <> value Then
                mRisMail = value
                mChangedRisMail = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property RisMailNota() As String
        Get
            Return mRisMailNota
        End Get
        Set(value As String)
            If mRisMailNota <> value Then
                mRisMailNota = value
                mChangedRisMailNota = True
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
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mCodiceFiscale = keys(0)
        End Set
    End Property

    Public Function LoadByKey( _
                 CodiceFiscale As String _
                ) As Boolean

        mCodiceFiscale = CodiceFiscale

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = CLIENTI
        End If

        With sql
            .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = CLIENTI
                .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = CLIENTI
        End If


        With sql
            .Field("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
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
                columnIndex = .GetOrdinal("Cognome")
                If Not .IsDBNull(columnIndex) Then
                    mCognome = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Nome")
                If Not .IsDBNull(columnIndex) Then
                    mNome = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataNascita")
                If Not .IsDBNull(columnIndex) Then
                    mDataNascita = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Indirizzo")
                If Not .IsDBNull(columnIndex) Then
                    mIndirizzo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Cap")
                If Not .IsDBNull(columnIndex) Then
                    mCap = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Localita")
                If Not .IsDBNull(columnIndex) Then
                    mLocalita = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ComuneCAB")
                If Not .IsDBNull(columnIndex) Then
                    mComuneCAB = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("StatoCAB")
                If Not .IsDBNull(columnIndex) Then
                    mStatoCAB = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Provincia")
                If Not .IsDBNull(columnIndex) Then
                    mProvincia = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Telefono1")
                If Not .IsDBNull(columnIndex) Then
                    mTelefono1 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Telefono2")
                If Not .IsDBNull(columnIndex) Then
                    mTelefono2 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Sesso")
                If Not .IsDBNull(columnIndex) Then
                    mSesso = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Capofamiglia")
                If Not .IsDBNull(columnIndex) Then
                    mCapofamiglia = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceFiscaleCF")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceFiscaleCF = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodiceFiscaleEA")
                If Not .IsDBNull(columnIndex) Then
                    mCodiceFiscaleEA = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ClienteTop")
                If Not .IsDBNull(columnIndex) Then
                    mClienteTop = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataTop")
                If Not .IsDBNull(columnIndex) Then
                    mDataTop = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Produttore")
                If Not .IsDBNull(columnIndex) Then
                    mProduttore = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("StatoCivile")
                If Not .IsDBNull(columnIndex) Then
                    mStatoCivile = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("NucleoFamiliare")
                If Not .IsDBNull(columnIndex) Then
                    mNucleoFamiliare = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("PrimaCasa")
                If Not .IsDBNull(columnIndex) Then
                    mPrimaCasa = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AltriImmobili")
                If Not .IsDBNull(columnIndex) Then
                    mAltriImmobili = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TitoliStato")
                If Not .IsDBNull(columnIndex) Then
                    mTitoliStato = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("FasciaReddito")
                If Not .IsDBNull(columnIndex) Then
                    mFasciaReddito = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Sindacati")
                If Not .IsDBNull(columnIndex) Then
                    mSindacati = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("PolizzeAltreComp")
                If Not .IsDBNull(columnIndex) Then
                    mPolizzeAltreComp = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CartaCredito")
                If Not .IsDBNull(columnIndex) Then
                    mCartaCredito = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("EsclusioneAttivita")
                If Not .IsDBNull(columnIndex) Then
                    mEsclusioneAttivita = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Ente")
                If Not .IsDBNull(columnIndex) Then
                    mEnte = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TipoCliente")
                If Not .IsDBNull(columnIndex) Then
                    mTipoCliente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("IDSegmentoCorrente")
                If Not .IsDBNull(columnIndex) Then
                    mIDSegmentoCorrente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("IDSegmentoPrecedente")
                If Not .IsDBNull(columnIndex) Then
                    mIDSegmentoPrecedente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("IDStatoCliente")
                If Not .IsDBNull(columnIndex) Then
                    mIDStatoCliente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("IDZona")
                If Not .IsDBNull(columnIndex) Then
                    mIDZona = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataInserimento")
                If Not .IsDBNull(columnIndex) Then
                    mDataInserimento = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataCessazione")
                If Not .IsDBNull(columnIndex) Then
                    mDataCessazione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AgenziaPrevalente")
                If Not .IsDBNull(columnIndex) Then
                    mAgenziaPrevalente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SubAgenzia")
                If Not .IsDBNull(columnIndex) Then
                    mSubAgenzia = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SubAgenziaSIMA")
                If Not .IsDBNull(columnIndex) Then
                    mSubAgenziaSIMA = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataUltimaVisita")
                If Not .IsDBNull(columnIndex) Then
                    mDataUltimaVisita = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataProssimaVisita")
                If Not .IsDBNull(columnIndex) Then
                    mDataProssimaVisita = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("PolizzeVigore")
                If Not .IsDBNull(columnIndex) Then
                    mPolizzeVigore = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("PolizzeStoriche")
                If Not .IsDBNull(columnIndex) Then
                    mPolizzeStoriche = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("PremiCorrente")
                If Not .IsDBNull(columnIndex) Then
                    mPremiCorrente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SinistriCorrente")
                If Not .IsDBNull(columnIndex) Then
                    mSinistriCorrente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("LiquidatoCorrente")
                If Not .IsDBNull(columnIndex) Then
                    mLiquidatoCorrente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("PremiPrecedente")
                If Not .IsDBNull(columnIndex) Then
                    mPremiPrecedente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SinistriPrecedente")
                If Not .IsDBNull(columnIndex) Then
                    mSinistriPrecedente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("LiquidatoPrecedente")
                If Not .IsDBNull(columnIndex) Then
                    mLiquidatoPrecedente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("PremiTotale")
                If Not .IsDBNull(columnIndex) Then
                    mPremiTotale = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SinistriTotale")
                If Not .IsDBNull(columnIndex) Then
                    mSinistriTotale = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("LiquidatoTotale")
                If Not .IsDBNull(columnIndex) Then
                    mLiquidatoTotale = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ConsensoPrivacy")
                If Not .IsDBNull(columnIndex) Then
                    mConsensoPrivacy = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("RilascioPatente")
                If Not .IsDBNull(columnIndex) Then
                    mRilascioPatente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Email")
                If Not .IsDBNull(columnIndex) Then
                    mEmail = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Fax")
                If Not .IsDBNull(columnIndex) Then
                    mFax = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Cellulare")
                If Not .IsDBNull(columnIndex) Then
                    mCellulare = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TelReferente")
                If Not .IsDBNull(columnIndex) Then
                    mTelReferente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("NomeReferente")
                If Not .IsDBNull(columnIndex) Then
                    mNomeReferente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TelAziendale")
                If Not .IsDBNull(columnIndex) Then
                    mTelAziendale = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodAvvisoScadenza")
                If Not .IsDBNull(columnIndex) Then
                    mCodAvvisoScadenza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AnnoMeseInizioEsclTemp")
                If Not .IsDBNull(columnIndex) Then
                    mAnnoMeseInizioEsclTemp = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AnnoMeseFineEsclTemp")
                If Not .IsDBNull(columnIndex) Then
                    mAnnoMeseFineEsclTemp = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodModalitaIncasso")
                If Not .IsDBNull(columnIndex) Then
                    mCodModalitaIncasso = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Flag1")
                If Not .IsDBNull(columnIndex) Then
                    mFlag1 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Flag2")
                If Not .IsDBNull(columnIndex) Then
                    mFlag2 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Flag3")
                If Not .IsDBNull(columnIndex) Then
                    mFlag3 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("RisTelefono")
                If Not .IsDBNull(columnIndex) Then
                    mRisTelefono = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("RisTelefonoNota")
                If Not .IsDBNull(columnIndex) Then
                    mRisTelefonoNota = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("RisCellulare")
                If Not .IsDBNull(columnIndex) Then
                    mRisCellulare = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("RisCellulareNota")
                If Not .IsDBNull(columnIndex) Then
                    mRisCellulareNota = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("RisMail")
                If Not .IsDBNull(columnIndex) Then
                    mRisMail = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("RisMailNota")
                If Not .IsDBNull(columnIndex) Then
                    mRisMailNota = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedCognome Then
                .Field("Cognome", TipoEnum.TIPO_STRINGA) = mCognome
            End If
            If mChangedNome Then
                .Field("Nome", TipoEnum.TIPO_STRINGA) = mNome
            End If
            If mChangedDataNascita Then
                .Field("DataNascita", TipoEnum.TIPO_DATA) = mDataNascita
            End If
            If mChangedIndirizzo Then
                .Field("Indirizzo", TipoEnum.TIPO_STRINGA) = mIndirizzo
            End If
            If mChangedCap Then
                .Field("Cap", TipoEnum.TIPO_NUMERO) = mCap
            End If
            If mChangedLocalita Then
                .Field("Localita", TipoEnum.TIPO_STRINGA) = mLocalita
            End If
            If mChangedComuneCAB Then
                .Field("ComuneCAB", TipoEnum.TIPO_NUMERO) = mComuneCAB
            End If
            If mChangedStatoCAB Then
                .Field("StatoCAB", TipoEnum.TIPO_NUMERO) = mStatoCAB
            End If
            If mChangedProvincia Then
                .Field("Provincia", TipoEnum.TIPO_STRINGA) = mProvincia
            End If
            If mChangedTelefono1 Then
                .Field("Telefono1", TipoEnum.TIPO_STRINGA) = mTelefono1
            End If
            If mChangedTelefono2 Then
                .Field("Telefono2", TipoEnum.TIPO_STRINGA) = mTelefono2
            End If
            If mChangedSesso Then
                .Field("Sesso", TipoEnum.TIPO_STRINGA) = mSesso
            End If
            If mChangedCapofamiglia Then
                .Field("Capofamiglia", TipoEnum.TIPO_STRINGA) = mCapofamiglia
            End If
            If mChangedCodiceFiscaleCF Then
                .Field("CodiceFiscaleCF", TipoEnum.TIPO_STRINGA) = mCodiceFiscaleCF
            End If
            If mChangedCodiceFiscaleEA Then
                .Field("CodiceFiscaleEA", TipoEnum.TIPO_STRINGA) = mCodiceFiscaleEA
            End If
            If mChangedClienteTop Then
                .Field("ClienteTop", TipoEnum.TIPO_STRINGA) = mClienteTop
            End If
            If mChangedDataTop Then
                .Field("DataTop", TipoEnum.TIPO_DATA) = mDataTop
            End If
            If mChangedProduttore Then
                .Field("Produttore", TipoEnum.TIPO_NUMERO) = mProduttore
            End If
            If mChangedStatoCivile Then
                .Field("StatoCivile", TipoEnum.TIPO_STRINGA) = mStatoCivile
            End If
            If mChangedNucleoFamiliare Then
                .Field("NucleoFamiliare", TipoEnum.TIPO_NUMERO) = mNucleoFamiliare
            End If
            If mChangedPrimaCasa Then
                .Field("PrimaCasa", TipoEnum.TIPO_STRINGA) = mPrimaCasa
            End If
            If mChangedAltriImmobili Then
                .Field("AltriImmobili", TipoEnum.TIPO_STRINGA) = mAltriImmobili
            End If
            If mChangedTitoliStato Then
                .Field("TitoliStato", TipoEnum.TIPO_STRINGA) = mTitoliStato
            End If
            If mChangedFasciaReddito Then
                .Field("FasciaReddito", TipoEnum.TIPO_STRINGA) = mFasciaReddito
            End If
            If mChangedSindacati Then
                .Field("Sindacati", TipoEnum.TIPO_STRINGA) = mSindacati
            End If
            If mChangedPolizzeAltreComp Then
                .Field("PolizzeAltreComp", TipoEnum.TIPO_STRINGA) = mPolizzeAltreComp
            End If
            If mChangedCartaCredito Then
                .Field("CartaCredito", TipoEnum.TIPO_STRINGA) = mCartaCredito
            End If
            If mChangedEsclusioneAttivita Then
                .Field("EsclusioneAttivita", TipoEnum.TIPO_STRINGA) = mEsclusioneAttivita
            End If
            If mChangedEnte Then
                .Field("Ente", TipoEnum.TIPO_STRINGA) = mEnte
            End If
            If mChangedTipoCliente Then
                .Field("TipoCliente", TipoEnum.TIPO_NUMERO) = mTipoCliente
            End If
            If mChangedIDSegmentoCorrente Then
                .Field("IDSegmentoCorrente", TipoEnum.TIPO_NUMERO) = mIDSegmentoCorrente
            End If
            If mChangedIDSegmentoPrecedente Then
                .Field("IDSegmentoPrecedente", TipoEnum.TIPO_NUMERO) = mIDSegmentoPrecedente
            End If
            If mChangedIDStatoCliente Then
                .Field("IDStatoCliente", TipoEnum.TIPO_STRINGA) = mIDStatoCliente
            End If
            If mChangedIDZona Then
                .Field("IDZona", TipoEnum.TIPO_NUMERO) = mIDZona
            End If
            If mChangedDataInserimento Then
                .Field("DataInserimento", TipoEnum.TIPO_DATA) = mDataInserimento
            End If
            If mChangedDataCessazione Then
                .Field("DataCessazione", TipoEnum.TIPO_DATA) = mDataCessazione
            End If
            If mChangedAgenziaPrevalente Then
                .Field("AgenziaPrevalente", TipoEnum.TIPO_NUMERO) = mAgenziaPrevalente
            End If
            If mChangedSubAgenzia Then
                .Field("SubAgenzia", TipoEnum.TIPO_NUMERO) = mSubAgenzia
            End If
            If mChangedSubAgenziaSIMA Then
                .Field("SubAgenziaSIMA", TipoEnum.TIPO_NUMERO) = mSubAgenziaSIMA
            End If
            If mChangedDataUltimaVisita Then
                .Field("DataUltimaVisita", TipoEnum.TIPO_DATA) = mDataUltimaVisita
            End If
            If mChangedDataProssimaVisita Then
                .Field("DataProssimaVisita", TipoEnum.TIPO_DATA) = mDataProssimaVisita
            End If
            If mChangedPolizzeVigore Then
                .Field("PolizzeVigore", TipoEnum.TIPO_NUMERO) = mPolizzeVigore
            End If
            If mChangedPolizzeStoriche Then
                .Field("PolizzeStoriche", TipoEnum.TIPO_NUMERO) = mPolizzeStoriche
            End If
            If mChangedPremiCorrente Then
                .Field("PremiCorrente", TipoEnum.TIPO_NUMERO) = mPremiCorrente
            End If
            If mChangedSinistriCorrente Then
                .Field("SinistriCorrente", TipoEnum.TIPO_NUMERO) = mSinistriCorrente
            End If
            If mChangedLiquidatoCorrente Then
                .Field("LiquidatoCorrente", TipoEnum.TIPO_NUMERO) = mLiquidatoCorrente
            End If
            If mChangedPremiPrecedente Then
                .Field("PremiPrecedente", TipoEnum.TIPO_NUMERO) = mPremiPrecedente
            End If
            If mChangedSinistriPrecedente Then
                .Field("SinistriPrecedente", TipoEnum.TIPO_NUMERO) = mSinistriPrecedente
            End If
            If mChangedLiquidatoPrecedente Then
                .Field("LiquidatoPrecedente", TipoEnum.TIPO_NUMERO) = mLiquidatoPrecedente
            End If
            If mChangedPremiTotale Then
                .Field("PremiTotale", TipoEnum.TIPO_NUMERO) = mPremiTotale
            End If
            If mChangedSinistriTotale Then
                .Field("SinistriTotale", TipoEnum.TIPO_NUMERO) = mSinistriTotale
            End If
            If mChangedLiquidatoTotale Then
                .Field("LiquidatoTotale", TipoEnum.TIPO_NUMERO) = mLiquidatoTotale
            End If
            If mChangedConsensoPrivacy Then
                .Field("ConsensoPrivacy", TipoEnum.TIPO_STRINGA) = mConsensoPrivacy
            End If
            If mChangedRilascioPatente Then
                .Field("RilascioPatente", TipoEnum.TIPO_STRINGA) = mRilascioPatente
            End If
            If mChangedEmail Then
                .Field("Email", TipoEnum.TIPO_STRINGA) = mEmail
            End If
            If mChangedFax Then
                .Field("Fax", TipoEnum.TIPO_STRINGA) = mFax
            End If
            If mChangedCellulare Then
                .Field("Cellulare", TipoEnum.TIPO_STRINGA) = mCellulare
            End If
            If mChangedTelReferente Then
                .Field("TelReferente", TipoEnum.TIPO_STRINGA) = mTelReferente
            End If
            If mChangedNomeReferente Then
                .Field("NomeReferente", TipoEnum.TIPO_STRINGA) = mNomeReferente
            End If
            If mChangedTelAziendale Then
                .Field("TelAziendale", TipoEnum.TIPO_STRINGA) = mTelAziendale
            End If
            If mChangedCodAvvisoScadenza Then
                .Field("CodAvvisoScadenza", TipoEnum.TIPO_STRINGA) = mCodAvvisoScadenza
            End If
            If mChangedAnnoMeseInizioEsclTemp Then
                .Field("AnnoMeseInizioEsclTemp", TipoEnum.TIPO_STRINGA) = mAnnoMeseInizioEsclTemp
            End If
            If mChangedAnnoMeseFineEsclTemp Then
                .Field("AnnoMeseFineEsclTemp", TipoEnum.TIPO_STRINGA) = mAnnoMeseFineEsclTemp
            End If
            If mChangedCodModalitaIncasso Then
                .Field("CodModalitaIncasso", TipoEnum.TIPO_STRINGA) = mCodModalitaIncasso
            End If
            If mChangedFlag1 Then
                .Field("Flag1", TipoEnum.TIPO_NUMERO) = mFlag1
            End If
            If mChangedFlag2 Then
                .Field("Flag2", TipoEnum.TIPO_NUMERO) = mFlag2
            End If
            If mChangedFlag3 Then
                .Field("Flag3", TipoEnum.TIPO_NUMERO) = mFlag3
            End If
            If mChangedRisTelefono Then
                .Field("RisTelefono", TipoEnum.TIPO_STRINGA) = mRisTelefono
            End If
            If mChangedRisTelefonoNota Then
                .Field("RisTelefonoNota", TipoEnum.TIPO_STRINGA) = mRisTelefonoNota
            End If
            If mChangedRisCellulare Then
                .Field("RisCellulare", TipoEnum.TIPO_STRINGA) = mRisCellulare
            End If
            If mChangedRisCellulareNota Then
                .Field("RisCellulareNota", TipoEnum.TIPO_STRINGA) = mRisCellulareNota
            End If
            If mChangedRisMail Then
                .Field("RisMail", TipoEnum.TIPO_STRINGA) = mRisMail
            End If
            If mChangedRisMailNota Then
                .Field("RisMailNota", TipoEnum.TIPO_STRINGA) = mRisMailNota
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedCognome = False
        mChangedNome = False
        mChangedDataNascita = False
        mChangedIndirizzo = False
        mChangedCap = False
        mChangedLocalita = False
        mChangedComuneCAB = False
        mChangedStatoCAB = False
        mChangedProvincia = False
        mChangedTelefono1 = False
        mChangedTelefono2 = False
        mChangedSesso = False
        mChangedCapofamiglia = False
        mChangedCodiceFiscaleCF = False
        mChangedCodiceFiscaleEA = False
        mChangedClienteTop = False
        mChangedDataTop = False
        mChangedProduttore = False
        mChangedStatoCivile = False
        mChangedNucleoFamiliare = False
        mChangedPrimaCasa = False
        mChangedAltriImmobili = False
        mChangedTitoliStato = False
        mChangedFasciaReddito = False
        mChangedSindacati = False
        mChangedPolizzeAltreComp = False
        mChangedCartaCredito = False
        mChangedEsclusioneAttivita = False
        mChangedEnte = False
        mChangedTipoCliente = False
        mChangedIDSegmentoCorrente = False
        mChangedIDSegmentoPrecedente = False
        mChangedIDStatoCliente = False
        mChangedIDZona = False
        mChangedDataInserimento = False
        mChangedDataCessazione = False
        mChangedAgenziaPrevalente = False
        mChangedSubAgenzia = False
        mChangedSubAgenziaSIMA = False
        mChangedDataUltimaVisita = False
        mChangedDataProssimaVisita = False
        mChangedPolizzeVigore = False
        mChangedPolizzeStoriche = False
        mChangedPremiCorrente = False
        mChangedSinistriCorrente = False
        mChangedLiquidatoCorrente = False
        mChangedPremiPrecedente = False
        mChangedSinistriPrecedente = False
        mChangedLiquidatoPrecedente = False
        mChangedPremiTotale = False
        mChangedSinistriTotale = False
        mChangedLiquidatoTotale = False
        mChangedConsensoPrivacy = False
        mChangedRilascioPatente = False
        mChangedEmail = False
        mChangedFax = False
        mChangedCellulare = False
        mChangedTelReferente = False
        mChangedNomeReferente = False
        mChangedTelAziendale = False
        mChangedCodAvvisoScadenza = False
        mChangedAnnoMeseInizioEsclTemp = False
        mChangedAnnoMeseFineEsclTemp = False
        mChangedCodModalitaIncasso = False
        mChangedFlag1 = False
        mChangedFlag2 = False
        mChangedFlag3 = False
        mChangedRisTelefono = False
        mChangedRisTelefonoNota = False
        mChangedRisCellulare = False
        mChangedRisCellulareNota = False
        mChangedRisMail = False
        mChangedRisMailNota = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mCodiceFiscale.Length = 0 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False
        If mCognome.Length > 40 Then Ris = False
        If mNome.Length > 25 Then Ris = False
        If mIndirizzo.Length > 35 Then Ris = False
        If mLocalita.Length > 30 Then Ris = False
        If mProvincia.Length > 2 Then Ris = False
        If mTelefono1.Length > 14 Then Ris = False
        If mTelefono2.Length > 14 Then Ris = False
        If mSesso.Length > 1 Then Ris = False
        If mCapofamiglia.Length > 1 Then Ris = False
        If mCodiceFiscaleCF.Length > 16 Then Ris = False
        If mCodiceFiscaleEA.Length > 16 Then Ris = False
        If mClienteTop.Length > 1 Then Ris = False
        If mStatoCivile.Length > 2 Then Ris = False
        If mPrimaCasa.Length > 1 Then Ris = False
        If mAltriImmobili.Length > 1 Then Ris = False
        If mTitoliStato.Length > 1 Then Ris = False
        If mFasciaReddito.Length > 1 Then Ris = False
        If mSindacati.Length > 1 Then Ris = False
        If mPolizzeAltreComp.Length > 1 Then Ris = False
        If mCartaCredito.Length > 1 Then Ris = False
        If mEsclusioneAttivita.Length > 1 Then Ris = False
        If mEnte.Length > 1 Then Ris = False
        If mIDStatoCliente.Length > 2 Then Ris = False
        If mConsensoPrivacy.Length > 2 Then Ris = False
        If mRilascioPatente.Length > 6 Then Ris = False
        If mEmail.Length > 50 Then Ris = False
        If mFax.Length > 14 Then Ris = False
        If mCellulare.Length > 14 Then Ris = False
        If mTelReferente.Length > 14 Then Ris = False
        If mNomeReferente.Length > 40 Then Ris = False
        If mTelAziendale.Length > 14 Then Ris = False
        If mCodAvvisoScadenza.Length > 1 Then Ris = False
        If mAnnoMeseInizioEsclTemp.Length > 6 Then Ris = False
        If mAnnoMeseFineEsclTemp.Length > 6 Then Ris = False
        If mCodModalitaIncasso.Length > 1 Then Ris = False
        If mRisTelefono.Length > 14 Then Ris = False
        If mRisTelefonoNota.Length > 50 Then Ris = False
        If mRisCellulare.Length > 14 Then Ris = False
        If mRisCellulareNota.Length > 50 Then Ris = False
        If mRisMail.Length > 50 Then Ris = False
        If mRisMailNota.Length > 50 Then Ris = False

        Return Ris
    End Function


End Class
