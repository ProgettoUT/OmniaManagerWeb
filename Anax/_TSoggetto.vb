Imports Utx.FunzioniDb.Funzioni


Public Class _TSoggetto
    Inherits TBase
    Private Const sMODULENAME = "Soggetto"
    Private Const ANA_SOGGETTO = "[Ana_soggetto]"

    'Campi della tabella
    Private mCodiceFiscale As String
    Private mAgenzia As String
    Private mSubagenzia As String
    Private mProduttore As String
    Private mVoip As String
    Private mSocialNet As String
    Private mSitoWeb As String
    Private mBancaIban As String
    Private mBancaNome As String
    Private mConvenzione As String
    Private mCasaIndirizzo As String
    Private mCasaLocalita As String
    Private mCasaCap As String
    Private mCasaProvincia As String
    Private mLavoroIndirizzo As String
    Private mLavoroLocalita As String
    Private mLavoroCap As String
    Private mLavoroProvincia As String
    Private mAgenziaPrivacy As String
    Private mReferente As String
    Private mCodStatoCivile As String
    Private mCodPagamento As String
    Private mCodProfiloRischio As String
    Private mPrivacyInizio As DateTime
    Private mPrivacyFine As DateTime
    Private mDocumentoTipo As String
    Private mDocumentoNumero As String
    Private mDocumentoAutorita As String
    Private mDocumentoLuogo As String
    Private mDocumentoRilascio As DateTime
    Private mDocumentoScadenza As DateTime
    Private mDipendenteMatricola As String
    Private mDipendenteAzienda As String
    Private mDipendenteConvenzione As String
    Private mDipendenteVariazione As String
    Private mTipoFiguraContraente As String
    Private mTipoFiguraPresentatore As String
    Private mTipoFiguraBeneficiario As String
    Private mTipoFiguraAssicurato As String
    Private mTipoFiguraPerContoDi As String
    Private mSAE As String
    Private mATECO As String
    Private mTelNumero1 As String
    Private mTelNota1 As String
    Private mTelNumero2 As String
    Private mTelNota2 As String
    Private mTelNumero3 As String
    Private mTelNota3 As String
    Private mTelNumero4 As String
    Private mTelNota4 As String
    Private mEmailIndirizzo1 As String
    Private mEmailNota1 As String
    Private mEmailIndirizzo2 As String
    Private mEmailNota2 As String
    Private mAltroIndirizzo As String
    Private mAltroLocalita As String
    Private mAltroCap As String
    Private mAltroProvincia As String
    Private mNote As String

    Private mDestinatarioQualifica As String
    Private mDestinatarioNominativo As String
    Private mDestinatarioPresso As String
    Private mDestinatarioIndirizzo As String
    Private mDestinatarioLocalita As String
    Private mDestinatarioCap As String
    Private mDestinatarioProvincia As String

    'Campi che possono essere aggiornati
    Private mChangedAgenzia As Boolean
    Private mChangedSubagenzia As Boolean
    Private mChangedProduttore As Boolean
    Private mChangedVoip As Boolean
    Private mChangedSocialNet As Boolean
    Private mChangedSitoWeb As Boolean
    Private mChangedBancaIban As Boolean
    Private mChangedBancaNome As Boolean
    Private mChangedConvenzione As Boolean
    Private mChangedCasaIndirizzo As Boolean
    Private mChangedCasaLocalita As Boolean
    Private mChangedCasaCap As Boolean
    Private mChangedCasaProvincia As Boolean
    Private mChangedLavoroIndirizzo As Boolean
    Private mChangedLavoroLocalita As Boolean
    Private mChangedLavoroCap As Boolean
    Private mChangedLavoroProvincia As Boolean
    Private mChangedAgenziaPrivacy As Boolean
    Private mChangedReferente As Boolean
    Private mChangedCodStatoCivile As Boolean
    Private mChangedCodPagamento As Boolean
    Private mChangedCodProfiloRischio As Boolean
    Private mChangedPrivacyInizio As Boolean
    Private mChangedPrivacyFine As Boolean
    Private mChangedDocumentoTipo As Boolean
    Private mChangedDocumentoNumero As Boolean
    Private mChangedDocumentoAutorita As Boolean
    Private mChangedDocumentoLuogo As Boolean
    Private mChangedDocumentoRilascio As Boolean
    Private mChangedDocumentoScadenza As Boolean
    Private mChangedDipendenteMatricola As Boolean
    Private mChangedDipendenteAzienda As Boolean
    Private mChangedDipendenteConvenzione As Boolean
    Private mChangedDipendenteVariazione As Boolean
    Private mChangedTipoFiguraContraente As Boolean
    Private mChangedTipoFiguraPresentatore As Boolean
    Private mChangedTipoFiguraBeneficiario As Boolean
    Private mChangedTipoFiguraAssicurato As Boolean
    Private mChangedTipoFiguraPerContoDi As Boolean
    Private mChangedSAE As Boolean
    Private mChangedATECO As Boolean
    Private mChangedTelNumero1 As Boolean
    Private mChangedTelNota1 As Boolean
    Private mChangedTelNumero2 As Boolean
    Private mChangedTelNota2 As Boolean
    Private mChangedTelNumero3 As Boolean
    Private mChangedTelNota3 As Boolean
    Private mChangedTelNumero4 As Boolean
    Private mChangedTelNota4 As Boolean
    Private mChangedEmailIndirizzo1 As Boolean
    Private mChangedEmailNota1 As Boolean
    Private mChangedEmailIndirizzo2 As Boolean
    Private mChangedEmailNota2 As Boolean
    Private mChangedAltroIndirizzo As Boolean
    Private mChangedAltroLocalita As Boolean
    Private mChangedAltroCap As Boolean
    Private mChangedAltroProvincia As Boolean
    Private mChangedNote As Boolean

    Private mChangedDestinatarioQualifica As Boolean
    Private mChangedDestinatarioNominativo As Boolean
    Private mChangedDestinatarioPresso As Boolean
    Private mChangedDestinatarioIndirizzo As Boolean
    Private mChangedDestinatarioLocalita As Boolean
    Private mChangedDestinatarioCap As Boolean
    Private mChangedDestinatarioProvincia As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ANA_SOGGETTO
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

    Public Property Agenzia() As String
        Get
            Return mAgenzia
        End Get
        Set(value As String)
            If mAgenzia <> value Then
                mAgenzia = value
                mChangedAgenzia = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Subagenzia() As String
        Get
            Return mSubagenzia
        End Get
        Set(value As String)
            If mSubagenzia <> value Then
                mSubagenzia = value
                mChangedSubagenzia = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Produttore() As String
        Get
            Return mProduttore
        End Get
        Set(value As String)
            If mProduttore <> value Then
                mProduttore = value
                mChangedProduttore = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Voip() As String
        Get
            Return mVoip
        End Get
        Set(value As String)
            If mVoip <> value Then
                mVoip = value
                mChangedVoip = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property SocialNet() As String
        Get
            Return mSocialNet
        End Get
        Set(value As String)
            If mSocialNet <> value Then
                mSocialNet = value
                mChangedSocialNet = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property SitoWeb() As String
        Get
            Return mSitoWeb
        End Get
        Set(value As String)
            If mSitoWeb <> value Then
                mSitoWeb = value
                mChangedSitoWeb = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property BancaIban() As String
        Get
            Return mBancaIban
        End Get
        Set(value As String)
            If mBancaIban <> value Then
                mBancaIban = value
                mChangedBancaIban = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property BancaNome() As String
        Get
            Return mBancaNome
        End Get
        Set(value As String)
            If mBancaNome <> value Then
                mBancaNome = value
                mChangedBancaNome = True
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

    Public Property CasaIndirizzo() As String
        Get
            Return mCasaIndirizzo
        End Get
        Set(value As String)
            If mCasaIndirizzo <> value Then
                mCasaIndirizzo = value
                mChangedCasaIndirizzo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CasaLocalita() As String
        Get
            Return mCasaLocalita
        End Get
        Set(value As String)
            If mCasaLocalita <> value Then
                mCasaLocalita = value
                mChangedCasaLocalita = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CasaCap() As String
        Get
            Return mCasaCap
        End Get
        Set(value As String)
            If mCasaCap <> value Then
                mCasaCap = value
                mChangedCasaCap = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CasaProvincia() As String
        Get
            Return mCasaProvincia
        End Get
        Set(value As String)
            If mCasaProvincia <> value Then
                mCasaProvincia = value
                mChangedCasaProvincia = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property LavoroIndirizzo() As String
        Get
            Return mLavoroIndirizzo
        End Get
        Set(value As String)
            If mLavoroIndirizzo <> value Then
                mLavoroIndirizzo = value
                mChangedLavoroIndirizzo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property LavoroLocalita() As String
        Get
            Return mLavoroLocalita
        End Get
        Set(value As String)
            If mLavoroLocalita <> value Then
                mLavoroLocalita = value
                mChangedLavoroLocalita = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property LavoroCap() As String
        Get
            Return mLavoroCap
        End Get
        Set(value As String)
            If mLavoroCap <> value Then
                mLavoroCap = value
                mChangedLavoroCap = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property LavoroProvincia() As String
        Get
            Return mLavoroProvincia
        End Get
        Set(value As String)
            If mLavoroProvincia <> value Then
                mLavoroProvincia = value
                mChangedLavoroProvincia = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AgenziaPrivacy() As String
        Get
            Return mAgenziaPrivacy
        End Get
        Set(value As String)
            If mAgenziaPrivacy <> value Then
                mAgenziaPrivacy = value
                mChangedAgenziaPrivacy = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Referente() As String
        Get
            Return mReferente
        End Get
        Set(value As String)
            If mReferente <> value Then
                mReferente = value
                mChangedReferente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodStatoCivile() As String
        Get
            Return mCodStatoCivile
        End Get
        Set(value As String)
            If mCodStatoCivile <> value Then
                mCodStatoCivile = value
                mChangedCodStatoCivile = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodPagamento() As String
        Get
            Return mCodPagamento
        End Get
        Set(value As String)
            If mCodPagamento <> value Then
                mCodPagamento = value
                mChangedCodPagamento = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodProfiloRischio() As String
        Get
            Return mCodProfiloRischio
        End Get
        Set(value As String)
            If mCodProfiloRischio <> value Then
                mCodProfiloRischio = value
                mChangedCodProfiloRischio = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property PrivacyInizio() As DateTime
        Get
            Return mPrivacyInizio
        End Get
        Set(value As DateTime)
            If mPrivacyInizio <> value Then
                mPrivacyInizio = value
                mChangedPrivacyInizio = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property PrivacyFine() As DateTime
        Get
            Return mPrivacyFine
        End Get
        Set(value As DateTime)
            If mPrivacyFine <> value Then
                mPrivacyFine = value
                mChangedPrivacyFine = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DocumentoTipo() As String
        Get
            Return mDocumentoTipo
        End Get
        Set(value As String)
            If mDocumentoTipo <> value Then
                mDocumentoTipo = value
                mChangedDocumentoTipo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DocumentoNumero() As String
        Get
            Return mDocumentoNumero
        End Get
        Set(value As String)
            If mDocumentoNumero <> value Then
                mDocumentoNumero = value
                mChangedDocumentoNumero = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DocumentoAutorita() As String
        Get
            Return mDocumentoAutorita
        End Get
        Set(value As String)
            If mDocumentoAutorita <> value Then
                mDocumentoAutorita = value
                mChangedDocumentoAutorita = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DocumentoLuogo() As String
        Get
            Return mDocumentoLuogo
        End Get
        Set(value As String)
            If mDocumentoLuogo <> value Then
                mDocumentoLuogo = value
                mChangedDocumentoLuogo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DocumentoRilascio() As DateTime
        Get
            Return mDocumentoRilascio
        End Get
        Set(value As DateTime)
            If mDocumentoRilascio <> value Then
                mDocumentoRilascio = value
                mChangedDocumentoRilascio = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DocumentoScadenza() As DateTime
        Get
            Return mDocumentoScadenza
        End Get
        Set(value As DateTime)
            If mDocumentoScadenza <> value Then
                mDocumentoScadenza = value
                mChangedDocumentoScadenza = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DipendenteMatricola() As String
        Get
            Return mDipendenteMatricola
        End Get
        Set(value As String)
            If mDipendenteMatricola <> value Then
                mDipendenteMatricola = value
                mChangedDipendenteMatricola = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DipendenteAzienda() As String
        Get
            Return mDipendenteAzienda
        End Get
        Set(value As String)
            If mDipendenteAzienda <> value Then
                mDipendenteAzienda = value
                mChangedDipendenteAzienda = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DipendenteConvenzione() As String
        Get
            Return mDipendenteConvenzione
        End Get
        Set(value As String)
            If mDipendenteConvenzione <> value Then
                mDipendenteConvenzione = value
                mChangedDipendenteConvenzione = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DipendenteVariazione() As String
        Get
            Return mDipendenteVariazione
        End Get
        Set(value As String)
            If mDipendenteVariazione <> value Then
                mDipendenteVariazione = value
                mChangedDipendenteVariazione = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TipoFiguraContraente() As String
        Get
            Return mTipoFiguraContraente
        End Get
        Set(value As String)
            If mTipoFiguraContraente <> value Then
                mTipoFiguraContraente = value
                mChangedTipoFiguraContraente = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TipoFiguraPresentatore() As String
        Get
            Return mTipoFiguraPresentatore
        End Get
        Set(value As String)
            If mTipoFiguraPresentatore <> value Then
                mTipoFiguraPresentatore = value
                mChangedTipoFiguraPresentatore = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TipoFiguraBeneficiario() As String
        Get
            Return mTipoFiguraBeneficiario
        End Get
        Set(value As String)
            If mTipoFiguraBeneficiario <> value Then
                mTipoFiguraBeneficiario = value
                mChangedTipoFiguraBeneficiario = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TipoFiguraAssicurato() As String
        Get
            Return mTipoFiguraAssicurato
        End Get
        Set(value As String)
            If mTipoFiguraAssicurato <> value Then
                mTipoFiguraAssicurato = value
                mChangedTipoFiguraAssicurato = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TipoFiguraPerContoDi() As String
        Get
            Return mTipoFiguraPerContoDi
        End Get
        Set(value As String)
            If mTipoFiguraPerContoDi <> value Then
                mTipoFiguraPerContoDi = value
                mChangedTipoFiguraPerContoDi = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property SAE() As String
        Get
            Return mSAE
        End Get
        Set(value As String)
            If mSAE <> value Then
                mSAE = value
                mChangedSAE = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ATECO() As String
        Get
            Return mATECO
        End Get
        Set(value As String)
            If mATECO <> value Then
                mATECO = value
                mChangedATECO = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TelNumero1() As String
        Get
            Return mTelNumero1
        End Get
        Set(value As String)
            If mTelNumero1 <> value Then
                mTelNumero1 = value
                mChangedTelNumero1 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TelNota1() As String
        Get
            Return mTelNota1
        End Get
        Set(value As String)
            If mTelNota1 <> value Then
                mTelNota1 = value
                mChangedTelNota1 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TelNumero2() As String
        Get
            Return mTelNumero2
        End Get
        Set(value As String)
            If mTelNumero2 <> value Then
                mTelNumero2 = value
                mChangedTelNumero2 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TelNota2() As String
        Get
            Return mTelNota2
        End Get
        Set(value As String)
            If mTelNota2 <> value Then
                mTelNota2 = value
                mChangedTelNota2 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TelNumero3() As String
        Get
            Return mTelNumero3
        End Get
        Set(value As String)
            If mTelNumero3 <> value Then
                mTelNumero3 = value
                mChangedTelNumero3 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TelNota3() As String
        Get
            Return mTelNota3
        End Get
        Set(value As String)
            If mTelNota3 <> value Then
                mTelNota3 = value
                mChangedTelNota3 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TelNumero4() As String
        Get
            Return mTelNumero4
        End Get
        Set(value As String)
            If mTelNumero4 <> value Then
                mTelNumero4 = value
                mChangedTelNumero4 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TelNota4() As String
        Get
            Return mTelNota4
        End Get
        Set(value As String)
            If mTelNota4 <> value Then
                mTelNota4 = value
                mChangedTelNota4 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property EmailIndirizzo1() As String
        Get
            Return mEmailIndirizzo1
        End Get
        Set(value As String)
            If mEmailIndirizzo1 <> value Then
                mEmailIndirizzo1 = value
                mChangedEmailIndirizzo1 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property EmailNota1() As String
        Get
            Return mEmailNota1
        End Get
        Set(value As String)
            If mEmailNota1 <> value Then
                mEmailNota1 = value
                mChangedEmailNota1 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property EmailIndirizzo2() As String
        Get
            Return mEmailIndirizzo2
        End Get
        Set(value As String)
            If mEmailIndirizzo2 <> value Then
                mEmailIndirizzo2 = value
                mChangedEmailIndirizzo2 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property EmailNota2() As String
        Get
            Return mEmailNota2
        End Get
        Set(value As String)
            If mEmailNota2 <> value Then
                mEmailNota2 = value
                mChangedEmailNota2 = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AltroIndirizzo() As String
        Get
            Return mAltroIndirizzo
        End Get
        Set(value As String)
            If mAltroIndirizzo <> value Then
                mAltroIndirizzo = value
                mChangedAltroIndirizzo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AltroLocalita() As String
        Get
            Return mAltroLocalita
        End Get
        Set(value As String)
            If mAltroLocalita <> value Then
                mAltroLocalita = value
                mChangedAltroLocalita = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AltroCap() As String
        Get
            Return mAltroCap
        End Get
        Set(value As String)
            If mAltroCap <> value Then
                mAltroCap = value
                mChangedAltroCap = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AltroProvincia() As String
        Get
            Return mAltroProvincia
        End Get
        Set(value As String)
            If mAltroProvincia <> value Then
                mAltroProvincia = value
                mChangedAltroProvincia = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Note() As String
        Get
            Return mNote
        End Get
        Set(value As String)
            If mNote <> value Then
                mNote = value
                mChangedNote = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DestinatarioQualifica() As String
        Get
            Return mDestinatarioQualifica
        End Get
        Set(value As String)
            If mDestinatarioQualifica <> value Then
                mDestinatarioQualifica = value
                mChangedDestinatarioQualifica = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DestinatarioNominativo() As String
        Get
            Return mDestinatarioNominativo
        End Get
        Set(value As String)
            If mDestinatarioNominativo <> value Then
                mDestinatarioNominativo = value
                mChangedDestinatarioNominativo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DestinatarioPresso() As String
        Get
            Return mDestinatarioPresso
        End Get
        Set(value As String)
            If mDestinatarioPresso <> value Then
                mDestinatarioPresso = value
                mChangedDestinatarioPresso = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DestinatarioIndirizzo() As String
        Get
            Return mDestinatarioIndirizzo
        End Get
        Set(value As String)
            If mDestinatarioIndirizzo <> value Then
                mDestinatarioIndirizzo = value
                mChangedDestinatarioIndirizzo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DestinatarioCap() As String
        Get
            Return mDestinatarioCap
        End Get
        Set(value As String)
            If mDestinatarioCap <> value Then
                mDestinatarioCap = value
                mChangedDestinatarioCap = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DestinatarioLocalita() As String
        Get
            Return mDestinatarioLocalita
        End Get
        Set(value As String)
            If mDestinatarioLocalita <> value Then
                mDestinatarioLocalita = value
                mChangedDestinatarioLocalita = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DestinatarioProvincia() As String
        Get
            Return mDestinatarioProvincia
        End Get
        Set(value As String)
            If Trim(mDestinatarioProvincia) <> Trim(value) Then
                mDestinatarioProvincia = value
                mChangedDestinatarioProvincia = True
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
            sql.Tabella = ANA_SOGGETTO
        End If

        With sql
            .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = ANA_SOGGETTO
                .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_SOGGETTO
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
                columnIndex = .GetOrdinal("Agenzia")
                If Not .IsDBNull(columnIndex) Then
                    mAgenzia = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SubAgenzia")
                If Not .IsDBNull(columnIndex) Then
                    mSubagenzia = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Produttore")
                If Not .IsDBNull(columnIndex) Then
                    mProduttore = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Voip")
                If Not .IsDBNull(columnIndex) Then
                    mVoip = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SocialNet")
                If Not .IsDBNull(columnIndex) Then
                    mSocialNet = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SitoWeb")
                If Not .IsDBNull(columnIndex) Then
                    mSitoWeb = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("BancaIban")
                If Not .IsDBNull(columnIndex) Then
                    mBancaIban = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("BancaNome")
                If Not .IsDBNull(columnIndex) Then
                    mBancaNome = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Convenzione")
                If Not .IsDBNull(columnIndex) Then
                    mConvenzione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CasaIndirizzo")
                If Not .IsDBNull(columnIndex) Then
                    mCasaIndirizzo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CasaLocalita")
                If Not .IsDBNull(columnIndex) Then
                    mCasaLocalita = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CasaCap")
                If Not .IsDBNull(columnIndex) Then
                    mCasaCap = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CasaProvincia")
                If Not .IsDBNull(columnIndex) Then
                    mCasaProvincia = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("LavoroIndirizzo")
                If Not .IsDBNull(columnIndex) Then
                    mLavoroIndirizzo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("LavoroLocalita")
                If Not .IsDBNull(columnIndex) Then
                    mLavoroLocalita = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("LavoroCap")
                If Not .IsDBNull(columnIndex) Then
                    mLavoroCap = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("LavoroProvincia")
                If Not .IsDBNull(columnIndex) Then
                    mLavoroProvincia = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AgenziaPrivacy")
                If Not .IsDBNull(columnIndex) Then
                    mAgenziaPrivacy = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Referente")
                If Not .IsDBNull(columnIndex) Then
                    mReferente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodStatoCivile")
                If Not .IsDBNull(columnIndex) Then
                    mCodStatoCivile = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodPagamento")
                If Not .IsDBNull(columnIndex) Then
                    mCodPagamento = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodProfiloRischio")
                If Not .IsDBNull(columnIndex) Then
                    mCodProfiloRischio = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("PrivacyInizio")
                If Not .IsDBNull(columnIndex) Then
                    mPrivacyInizio = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("PrivacyFine")
                If Not .IsDBNull(columnIndex) Then
                    mPrivacyFine = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DocumentoTipo")
                If Not .IsDBNull(columnIndex) Then
                    mDocumentoTipo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DocumentoNumero")
                If Not .IsDBNull(columnIndex) Then
                    mDocumentoNumero = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DocumentoAutorita")
                If Not .IsDBNull(columnIndex) Then
                    mDocumentoAutorita = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DocumentoLuogo")
                If Not .IsDBNull(columnIndex) Then
                    mDocumentoLuogo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DocumentoRilascio")
                If Not .IsDBNull(columnIndex) Then
                    mDocumentoRilascio = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DocumentoScadenza")
                If Not .IsDBNull(columnIndex) Then
                    mDocumentoScadenza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DipendenteMatricola")
                If Not .IsDBNull(columnIndex) Then
                    mDipendenteMatricola = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DipendenteAzienda")
                If Not .IsDBNull(columnIndex) Then
                    mDipendenteAzienda = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DipendenteConvenzione")
                If Not .IsDBNull(columnIndex) Then
                    mDipendenteConvenzione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DipendenteVariazione")
                If Not .IsDBNull(columnIndex) Then
                    mDipendenteVariazione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TipoFiguraContraente")
                If Not .IsDBNull(columnIndex) Then
                    mTipoFiguraContraente = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TipoFiguraPresentatore")
                If Not .IsDBNull(columnIndex) Then
                    mTipoFiguraPresentatore = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TipoFiguraBeneficiario")
                If Not .IsDBNull(columnIndex) Then
                    mTipoFiguraBeneficiario = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TipoFiguraAssicurato")
                If Not .IsDBNull(columnIndex) Then
                    mTipoFiguraAssicurato = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TipoFiguraPerContoDi")
                If Not .IsDBNull(columnIndex) Then
                    mTipoFiguraPerContoDi = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SAE")
                If Not .IsDBNull(columnIndex) Then
                    mSAE = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ATECO")
                If Not .IsDBNull(columnIndex) Then
                    mATECO = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TelNumero1")
                If Not .IsDBNull(columnIndex) Then
                    mTelNumero1 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TelNota1")
                If Not .IsDBNull(columnIndex) Then
                    mTelNota1 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TelNumero2")
                If Not .IsDBNull(columnIndex) Then
                    mTelNumero2 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TelNota2")
                If Not .IsDBNull(columnIndex) Then
                    mTelNota2 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TelNumero3")
                If Not .IsDBNull(columnIndex) Then
                    mTelNumero3 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TelNota3")
                If Not .IsDBNull(columnIndex) Then
                    mTelNota3 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TelNumero4")
                If Not .IsDBNull(columnIndex) Then
                    mTelNumero4 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TelNota4")
                If Not .IsDBNull(columnIndex) Then
                    mTelNota4 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("EmailIndirizzo1")
                If Not .IsDBNull(columnIndex) Then
                    mEmailIndirizzo1 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("EmailNota1")
                If Not .IsDBNull(columnIndex) Then
                    mEmailNota1 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("EmailIndirizzo2")
                If Not .IsDBNull(columnIndex) Then
                    mEmailIndirizzo2 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("EmailNota2")
                If Not .IsDBNull(columnIndex) Then
                    mEmailNota2 = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AltroIndirizzo")
                If Not .IsDBNull(columnIndex) Then
                    mAltroIndirizzo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AltroLocalita")
                If Not .IsDBNull(columnIndex) Then
                    mAltroLocalita = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AltroCap")
                If Not .IsDBNull(columnIndex) Then
                    mAltroCap = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AltroProvincia")
                If Not .IsDBNull(columnIndex) Then
                    mAltroProvincia = .GetValue(columnIndex)
                End If

                'columnIndex = .GetOrdinal("Note")
                'If Not .IsDBNull(columnIndex) Then
                '    mNote = .GetValue(columnIndex)
                'End If

                columnIndex = .GetOrdinal("DestinatarioQualifica")
                If Not .IsDBNull(columnIndex) Then
                    mDestinatarioQualifica = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DestinatarioNominativo")
                If Not .IsDBNull(columnIndex) Then
                    mDestinatarioNominativo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DestinatarioPresso")
                If Not .IsDBNull(columnIndex) Then
                    mDestinatarioPresso = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DestinatarioIndirizzo")
                If Not .IsDBNull(columnIndex) Then
                    mDestinatarioIndirizzo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DestinatarioCap")
                If Not .IsDBNull(columnIndex) Then
                    mDestinatarioCap = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DestinatarioLocalita")
                If Not .IsDBNull(columnIndex) Then
                    mDestinatarioLocalita = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DestinatarioProvincia")
                If Not .IsDBNull(columnIndex) Then
                    mDestinatarioProvincia = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedAgenzia Then
                .Field("Agenzia", TipoEnum.TIPO_STRINGA) = mAgenzia
            End If
            If mChangedSubagenzia Then
                .Field("Subagenzia", TipoEnum.TIPO_STRINGA) = mSubagenzia
            End If
            If mChangedProduttore Then
                .Field("Produttore", TipoEnum.TIPO_STRINGA) = mProduttore
            End If
            If mChangedVoip Then
                .Field("Voip", TipoEnum.TIPO_STRINGA) = mVoip
            End If
            If mChangedSocialNet Then
                .Field("SocialNet", TipoEnum.TIPO_STRINGA) = mSocialNet
            End If
            If mChangedSitoWeb Then
                .Field("SitoWeb", TipoEnum.TIPO_STRINGA) = mSitoWeb
            End If
            If mChangedBancaIban Then
                .Field("BancaIban", TipoEnum.TIPO_STRINGA) = mBancaIban
            End If
            If mChangedBancaNome Then
                .Field("BancaNome", TipoEnum.TIPO_STRINGA) = mBancaNome
            End If
            If mChangedConvenzione Then
                .Field("Convenzione", TipoEnum.TIPO_STRINGA) = mConvenzione
            End If
            If mChangedCasaIndirizzo Then
                .Field("CasaIndirizzo", TipoEnum.TIPO_STRINGA) = mCasaIndirizzo
            End If
            If mChangedCasaLocalita Then
                .Field("CasaLocalita", TipoEnum.TIPO_STRINGA) = mCasaLocalita
            End If
            If mChangedCasaCap Then
                .Field("CasaCap", TipoEnum.TIPO_STRINGA) = mCasaCap
            End If
            If mChangedCasaProvincia Then
                .Field("CasaProvincia", TipoEnum.TIPO_STRINGA) = mCasaProvincia
            End If
            If mChangedLavoroIndirizzo Then
                .Field("LavoroIndirizzo", TipoEnum.TIPO_STRINGA) = mLavoroIndirizzo
            End If
            If mChangedLavoroLocalita Then
                .Field("LavoroLocalita", TipoEnum.TIPO_STRINGA) = mLavoroLocalita
            End If
            If mChangedLavoroCap Then
                .Field("LavoroCap", TipoEnum.TIPO_STRINGA) = mLavoroCap
            End If
            If mChangedLavoroProvincia Then
                .Field("LavoroProvincia", TipoEnum.TIPO_STRINGA) = mLavoroProvincia
            End If
            If mChangedAgenziaPrivacy Then
                .Field("AgenziaPrivacy", TipoEnum.TIPO_STRINGA) = mAgenziaPrivacy
            End If
            If mChangedReferente Then
                .Field("Referente", TipoEnum.TIPO_STRINGA) = mReferente
            End If
            If mChangedCodStatoCivile Then
                .Field("CodStatoCivile", TipoEnum.TIPO_STRINGA) = mCodStatoCivile
            End If
            If mChangedCodPagamento Then
                .Field("CodPagamento", TipoEnum.TIPO_STRINGA) = mCodPagamento
            End If
            If mChangedCodProfiloRischio Then
                .Field("CodProfiloRischio", TipoEnum.TIPO_STRINGA) = mCodProfiloRischio
            End If
            If mChangedPrivacyInizio Then
                .Field("PrivacyInizio", TipoEnum.TIPO_DATA) = mPrivacyInizio
            End If
            If mChangedPrivacyFine Then
                .Field("PrivacyFine", TipoEnum.TIPO_DATA) = mPrivacyFine
            End If
            If mChangedDocumentoTipo Then
                .Field("DocumentoTipo", TipoEnum.TIPO_STRINGA) = mDocumentoTipo
            End If
            If mChangedDocumentoNumero Then
                .Field("DocumentoNumero", TipoEnum.TIPO_STRINGA) = mDocumentoNumero
            End If
            If mChangedDocumentoAutorita Then
                .Field("DocumentoAutorita", TipoEnum.TIPO_STRINGA) = mDocumentoAutorita
            End If
            If mChangedDocumentoLuogo Then
                .Field("DocumentoLuogo", TipoEnum.TIPO_STRINGA) = mDocumentoLuogo
            End If
            If mChangedDocumentoRilascio Then
                .Field("DocumentoRilascio", TipoEnum.TIPO_DATA) = mDocumentoRilascio
            End If
            If mChangedDocumentoScadenza Then
                .Field("DocumentoScadenza", TipoEnum.TIPO_DATA) = mDocumentoScadenza
            End If
            If mChangedDipendenteMatricola Then
                .Field("DipendenteMatricola", TipoEnum.TIPO_STRINGA) = mDipendenteMatricola
            End If
            If mChangedDipendenteAzienda Then
                .Field("DipendenteAzienda", TipoEnum.TIPO_STRINGA) = mDipendenteAzienda
            End If
            If mChangedDipendenteConvenzione Then
                .Field("DipendenteConvenzione", TipoEnum.TIPO_STRINGA) = mDipendenteConvenzione
            End If
            If mChangedDipendenteVariazione Then
                .Field("DipendenteVariazione", TipoEnum.TIPO_STRINGA) = mDipendenteVariazione
            End If
            If mChangedTipoFiguraContraente Then
                .Field("TipoFiguraContraente", TipoEnum.TIPO_STRINGA) = mTipoFiguraContraente
            End If
            If mChangedTipoFiguraPresentatore Then
                .Field("TipoFiguraPresentatore", TipoEnum.TIPO_STRINGA) = mTipoFiguraPresentatore
            End If
            If mChangedTipoFiguraBeneficiario Then
                .Field("TipoFiguraBeneficiario", TipoEnum.TIPO_STRINGA) = mTipoFiguraBeneficiario
            End If
            If mChangedTipoFiguraAssicurato Then
                .Field("TipoFiguraAssicurato", TipoEnum.TIPO_STRINGA) = mTipoFiguraAssicurato
            End If
            If mChangedTipoFiguraPerContoDi Then
                .Field("TipoFiguraPerContoDi", TipoEnum.TIPO_STRINGA) = mTipoFiguraPerContoDi
            End If
            If mChangedSAE Then
                .Field("SAE", TipoEnum.TIPO_STRINGA) = mSAE
            End If
            If mChangedATECO Then
                .Field("ATECO", TipoEnum.TIPO_STRINGA) = mATECO
            End If
            If mChangedTelNumero1 Then
                .Field("TelNumero1", TipoEnum.TIPO_STRINGA) = mTelNumero1
            End If
            If mChangedTelNota1 Then
                .Field("TelNota1", TipoEnum.TIPO_STRINGA) = mTelNota1
            End If
            If mChangedTelNumero2 Then
                .Field("TelNumero2", TipoEnum.TIPO_STRINGA) = mTelNumero2
            End If
            If mChangedTelNota2 Then
                .Field("TelNota2", TipoEnum.TIPO_STRINGA) = mTelNota2
            End If
            If mChangedTelNumero3 Then
                .Field("TelNumero3", TipoEnum.TIPO_STRINGA) = mTelNumero3
            End If
            If mChangedTelNota3 Then
                .Field("TelNota3", TipoEnum.TIPO_STRINGA) = mTelNota3
            End If
            If mChangedTelNumero4 Then
                .Field("TelNumero4", TipoEnum.TIPO_STRINGA) = mTelNumero4
            End If
            If mChangedTelNota4 Then
                .Field("TelNota4", TipoEnum.TIPO_STRINGA) = mTelNota4
            End If
            If mChangedEmailIndirizzo1 Then
                .Field("EmailIndirizzo1", TipoEnum.TIPO_STRINGA) = mEmailIndirizzo1
            End If
            If mChangedEmailNota1 Then
                .Field("EmailNota1", TipoEnum.TIPO_STRINGA) = mEmailNota1
            End If
            If mChangedEmailIndirizzo2 Then
                .Field("EmailIndirizzo2", TipoEnum.TIPO_STRINGA) = mEmailIndirizzo2
            End If
            If mChangedEmailNota2 Then
                .Field("EmailNota2", TipoEnum.TIPO_STRINGA) = mEmailNota2
            End If
            If mChangedAltroIndirizzo Then
                .Field("AltroIndirizzo", TipoEnum.TIPO_STRINGA) = mAltroIndirizzo
            End If
            If mChangedAltroLocalita Then
                .Field("AltroLocalita", TipoEnum.TIPO_STRINGA) = mAltroLocalita
            End If
            If mChangedAltroCap Then
                .Field("AltroCap", TipoEnum.TIPO_STRINGA) = mAltroCap
            End If
            If mChangedAltroProvincia Then
                .Field("AltroProvincia", TipoEnum.TIPO_STRINGA) = mAltroProvincia
            End If
            If mChangedNote Then
                .Field("Note", TipoEnum.TIPO_STRINGA) = mNote
            End If

            If mChangedDestinatarioQualifica Then
                .Field("DestinatarioQualifica", TipoEnum.TIPO_STRINGA) = mDestinatarioQualifica
            End If
            If mChangedDestinatarioNominativo Then
                .Field("DestinatarioNominativo", TipoEnum.TIPO_STRINGA) = mDestinatarioNominativo
            End If
            If mChangedDestinatarioPresso Then
                .Field("DestinatarioPresso", TipoEnum.TIPO_STRINGA) = mDestinatarioPresso
            End If
            If mChangedDestinatarioIndirizzo Then
                .Field("DestinatarioIndirizzo", TipoEnum.TIPO_STRINGA) = mDestinatarioIndirizzo
            End If
            If mChangedDestinatarioCap Then
                .Field("DestinatarioCap", TipoEnum.TIPO_STRINGA) = mDestinatarioCap
            End If
            If mChangedDestinatarioLocalita Then
                .Field("DestinatarioLocalita", TipoEnum.TIPO_STRINGA) = mDestinatarioLocalita
            End If
            If mChangedDestinatarioProvincia Then
                .Field("DestinatarioProvincia", TipoEnum.TIPO_STRINGA) = mDestinatarioProvincia
            End If

        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedAgenzia = False
        mChangedSubagenzia = False
        mChangedProduttore = False
        mChangedVoip = False
        mChangedSocialNet = False
        mChangedSitoWeb = False
        mChangedBancaIban = False
        mChangedBancaNome = False
        mChangedConvenzione = False
        mChangedCasaIndirizzo = False
        mChangedCasaLocalita = False
        mChangedCasaCap = False
        mChangedCasaProvincia = False
        mChangedLavoroIndirizzo = False
        mChangedLavoroLocalita = False
        mChangedLavoroCap = False
        mChangedLavoroProvincia = False
        mChangedAgenziaPrivacy = False
        mChangedReferente = False
        mChangedCodStatoCivile = False
        mChangedCodPagamento = False
        mChangedCodProfiloRischio = False
        mChangedPrivacyInizio = False
        mChangedPrivacyFine = False
        mChangedDocumentoTipo = False
        mChangedDocumentoNumero = False
        mChangedDocumentoAutorita = False
        mChangedDocumentoLuogo = False
        mChangedDocumentoRilascio = False
        mChangedDocumentoScadenza = False
        mChangedDipendenteMatricola = False
        mChangedDipendenteAzienda = False
        mChangedDipendenteConvenzione = False
        mChangedDipendenteVariazione = False
        mChangedTipoFiguraContraente = False
        mChangedTipoFiguraPresentatore = False
        mChangedTipoFiguraBeneficiario = False
        mChangedTipoFiguraAssicurato = False
        mChangedTipoFiguraPerContoDi = False
        mChangedSAE = False
        mChangedATECO = False
        mChangedTelNumero1 = False
        mChangedTelNota1 = False
        mChangedTelNumero2 = False
        mChangedTelNota2 = False
        mChangedTelNumero3 = False
        mChangedTelNota3 = False
        mChangedTelNumero4 = False
        mChangedTelNota4 = False
        mChangedEmailIndirizzo1 = False
        mChangedEmailNota1 = False
        mChangedEmailIndirizzo2 = False
        mChangedEmailNota2 = False
        mChangedAltroIndirizzo = False
        mChangedAltroLocalita = False
        mChangedAltroCap = False
        mChangedAltroProvincia = False
        mChangedNote = False

        mChangedDestinatarioQualifica = False
        mChangedDestinatarioNominativo = False
        mChangedDestinatarioPresso = False
        mChangedDestinatarioIndirizzo = False
        mChangedDestinatarioLocalita = False
        mChangedDestinatarioCap = False
        mChangedDestinatarioProvincia = False

    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mCodiceFiscale.Length = 0 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False
        If mAgenzia.Length > 5 Then Ris = False
        If mSubagenzia.Length > 4 Then Ris = False
        If mProduttore.Length > 3 Then Ris = False
        If mVoip.Length > 255 Then Ris = False
        If mSocialNet.Length > 255 Then Ris = False
        If mSitoWeb.Length > 255 Then Ris = False
        If mBancaIban.Length > 255 Then Ris = False
        If mBancaNome.Length > 255 Then Ris = False
        If mConvenzione.Length > 5 Then Ris = False
        If mCasaIndirizzo.Length > 50 Then Ris = False
        If mCasaLocalita.Length > 50 Then Ris = False
        If mCasaCap.Length > 5 Then Ris = False
        If mCasaProvincia.Length > 3 Then Ris = False
        If mLavoroIndirizzo.Length > 50 Then Ris = False
        If mLavoroLocalita.Length > 50 Then Ris = False
        If mLavoroCap.Length > 5 Then Ris = False
        If mLavoroProvincia.Length > 3 Then Ris = False
        If mAgenziaPrivacy.Length > 255 Then Ris = False
        If mReferente.Length > 255 Then Ris = False
        If mCodStatoCivile.Length > 1 Then Ris = False
        If mCodPagamento.Length > 1 Then Ris = False
        If mCodProfiloRischio.Length > 1 Then Ris = False
        If mDocumentoTipo.Length > 255 Then Ris = False
        If mDocumentoNumero.Length > 255 Then Ris = False
        If mDocumentoAutorita.Length > 255 Then Ris = False
        If mDocumentoLuogo.Length > 255 Then Ris = False
        If mDipendenteMatricola.Length > 255 Then Ris = False
        If mDipendenteAzienda.Length > 255 Then Ris = False
        If mDipendenteConvenzione.Length > 255 Then Ris = False
        If mDipendenteVariazione.Length > 255 Then Ris = False
        If mTipoFiguraContraente.Length > 255 Then Ris = False
        If mTipoFiguraPresentatore.Length > 255 Then Ris = False
        If mTipoFiguraBeneficiario.Length > 255 Then Ris = False
        If mTipoFiguraAssicurato.Length > 255 Then Ris = False
        If mTipoFiguraPerContoDi.Length > 255 Then Ris = False
        If mSAE.Length > 255 Then Ris = False
        If mATECO.Length > 255 Then Ris = False
        If mTelNumero1.Length > 20 Then Ris = False
        If mTelNota1.Length > 50 Then Ris = False
        If mTelNumero2.Length > 20 Then Ris = False
        If mTelNota2.Length > 50 Then Ris = False
        If mTelNumero3.Length > 20 Then Ris = False
        If mTelNota3.Length > 50 Then Ris = False
        If mTelNumero4.Length > 20 Then Ris = False
        If mTelNota4.Length > 50 Then Ris = False
        If mEmailIndirizzo1.Length > 255 Then Ris = False
        If mEmailNota1.Length > 50 Then Ris = False
        If mEmailIndirizzo2.Length > 255 Then Ris = False
        If mEmailNota2.Length > 50 Then Ris = False
        If mAltroIndirizzo.Length > 50 Then Ris = False
        If mAltroLocalita.Length > 50 Then Ris = False
        If mAltroCap.Length > 5 Then Ris = False
        If mAltroProvincia.Length > 3 Then Ris = False
        If mNote.Length > 536870910 Then Ris = False

        If mDestinatarioQualifica.Length > 50 Then Ris = False
        If mDestinatarioNominativo.Length > 50 Then Ris = False
        If mDestinatarioPresso.Length > 50 Then Ris = False
        If mDestinatarioIndirizzo.Length > 50 Then Ris = False
        If mDestinatarioLocalita.Length > 50 Then Ris = False
        If mDestinatarioCap.Length > 5 Then Ris = False
        If mDestinatarioProvincia.Length > 3 Then Ris = False

        Return Ris
    End Function


End Class
