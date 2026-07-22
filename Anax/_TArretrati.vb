Imports Utx.FunzioniDb.Funzioni


Public Class _TArretrati
    Inherits TBase
    Private Const sMODULENAME = "Arretrati"
    Private Const ARRETRATI = "[Arretrati]"

    'Campi della tabella
    Private mAgenzia As Integer
    Private mRamo As Integer
    Private mPolizza As Integer
    Private mEffettoAppendice As DateTime
    Private mNumeroAppendice As Integer
    Private mEffettoTitolo As DateTime
    Private mTipoCarico As String
    Private mCodiceFiscale As String
    Private mCognome As String
    Private mNome As String
    Private mSesso As String
    Private mTassabile As Double
    Private mTotaleTitolo As Double
    Private mProdotto As String
    Private mDelegataria As String
    Private mSubAgenzia As Integer
    Private mConvenzione As Integer
    Private mTarga As String
    Private mModello As String
    Private mRamoGestione As Integer
    Private mComparto As Integer
    Private mIncassabile As Boolean

    'Campi che possono essere aggiornati
    Private mChangedRamo As Boolean
    Private mChangedPolizza As Boolean
    Private mChangedEffettoAppendice As Boolean
    Private mChangedNumeroAppendice As Boolean
    Private mChangedEffettoTitolo As Boolean
    Private mChangedTipoCarico As Boolean
    Private mChangedCodiceFiscale As Boolean
    Private mChangedCognome As Boolean
    Private mChangedNome As Boolean
    Private mChangedSesso As Boolean
    Private mChangedTassabile As Boolean
    Private mChangedTotaleTitolo As Boolean
    Private mChangedProdotto As Boolean
    Private mChangedDelegataria As Boolean
    Private mChangedSubAgenzia As Boolean
    Private mChangedConvenzione As Boolean
    Private mChangedTarga As Boolean
    Private mChangedModello As Boolean
    Private mChangedRamoGestione As Boolean
    Private mChangedComparto As Boolean
    Private mChangedIncassabile As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ARRETRATI
        End Get
    End Property

    '**************************************************************************
    ' Proprietà dell'oggetto
    '**************************************************************************
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
            If mRamo <> value Then
                mRamo = value
                mChangedRamo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Polizza() As Integer
        Get
            Return mPolizza
        End Get
        Set(value As Integer)
            If mPolizza <> value Then
                mPolizza = value
                mChangedPolizza = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property EffettoAppendice() As DateTime
        Get
            Return mEffettoAppendice
        End Get
        Set(value As DateTime)
            If mEffettoAppendice <> value Then
                mEffettoAppendice = value
                mChangedEffettoAppendice = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property NumeroAppendice() As Integer
        Get
            Return mNumeroAppendice
        End Get
        Set(value As Integer)
            If mNumeroAppendice <> value Then
                mNumeroAppendice = value
                mChangedNumeroAppendice = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property EffettoTitolo() As DateTime
        Get
            Return mEffettoTitolo
        End Get
        Set(value As DateTime)
            If mEffettoTitolo <> value Then
                mEffettoTitolo = value
                mChangedEffettoTitolo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TipoCarico() As String
        Get
            Return mTipoCarico
        End Get
        Set(value As String)
            If mTipoCarico <> value Then
                mTipoCarico = value
                mChangedTipoCarico = True
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

    Public Property Tassabile() As Double
        Get
            Return mTassabile
        End Get
        Set(value As Double)
            If mTassabile <> value Then
                mTassabile = value
                mChangedTassabile = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property TotaleTitolo() As Double
        Get
            Return mTotaleTitolo
        End Get
        Set(value As Double)
            If mTotaleTitolo <> value Then
                mTotaleTitolo = value
                mChangedTotaleTitolo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Prodotto() As String
        Get
            Return mProdotto
        End Get
        Set(value As String)
            If mProdotto <> value Then
                mProdotto = value
                mChangedProdotto = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Delegataria() As String
        Get
            Return mDelegataria
        End Get
        Set(value As String)
            If mDelegataria <> value Then
                mDelegataria = value
                mChangedDelegataria = True
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

    Public Property Comparto() As Integer
        Get
            Return mComparto
        End Get
        Set(value As Integer)
            If mComparto <> value Then
                mComparto = value
                mChangedComparto = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Incassabile() As Boolean
        Get
            Return mIncassabile
        End Get
        Set(value As Boolean)
            If mIncassabile <> value Then
                mIncassabile = value
                mChangedIncassabile = True
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
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mAgenzia = keys(0)
        End Set
    End Property

    Public Function LoadByKey( _
                 Agenzia As Integer _
                ) As Boolean

        mAgenzia = Agenzia

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ARRETRATI
        End If

        With sql
            .Where("Agenzia", TipoEnum.TIPO_NUMERO) = mAgenzia
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = ARRETRATI
                mAgenzia = .GetNextPrg("Agenzia")
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ARRETRATI
        End If


        With sql
            .Field("Agenzia", TipoEnum.TIPO_NUMERO) = mAgenzia
        End With

        PutSqlKey = sql
    End Function

    Public Overrides Function GetFields(rs As DataTableReader) As Boolean
        Dim columnIndex As Integer = 0
        With rs
            If .HasRows Then
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
                columnIndex = .GetOrdinal("EffettoAppendice")
                If Not .IsDBNull(columnIndex) Then
                    mEffettoAppendice = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("NumeroAppendice")
                If Not .IsDBNull(columnIndex) Then
                    mNumeroAppendice = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("EffettoTitolo")
                If Not .IsDBNull(columnIndex) Then
                    mEffettoTitolo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TipoCarico")
                If Not .IsDBNull(columnIndex) Then
                    mTipoCarico = .GetValue(columnIndex)
                End If
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
                columnIndex = .GetOrdinal("Sesso")
                If Not .IsDBNull(columnIndex) Then
                    mSesso = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Tassabile")
                If Not .IsDBNull(columnIndex) Then
                    mTassabile = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TotaleTitolo")
                If Not .IsDBNull(columnIndex) Then
                    mTotaleTitolo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Prodotto")
                If Not .IsDBNull(columnIndex) Then
                    mProdotto = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Delegataria")
                If Not .IsDBNull(columnIndex) Then
                    mDelegataria = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SubAgenzia")
                If Not .IsDBNull(columnIndex) Then
                    mSubAgenzia = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Convenzione")
                If Not .IsDBNull(columnIndex) Then
                    mConvenzione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Targa")
                If Not .IsDBNull(columnIndex) Then
                    mTarga = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Modello")
                If Not .IsDBNull(columnIndex) Then
                    mModello = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("RamoGestione")
                If Not .IsDBNull(columnIndex) Then
                    mRamoGestione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Comparto")
                If Not .IsDBNull(columnIndex) Then
                    mComparto = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Incassabile")
                If Not .IsDBNull(columnIndex) Then
                    mIncassabile = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedRamo Then
                .Field("Ramo", TipoEnum.TIPO_NUMERO) = mRamo
            End If
            If mChangedPolizza Then
                .Field("Polizza", TipoEnum.TIPO_NUMERO) = mPolizza
            End If
            If mChangedEffettoAppendice Then
                .Field("EffettoAppendice", TipoEnum.TIPO_DATA) = mEffettoAppendice
            End If
            If mChangedNumeroAppendice Then
                .Field("NumeroAppendice", TipoEnum.TIPO_NUMERO) = mNumeroAppendice
            End If
            If mChangedEffettoTitolo Then
                .Field("EffettoTitolo", TipoEnum.TIPO_DATA) = mEffettoTitolo
            End If
            If mChangedTipoCarico Then
                .Field("TipoCarico", TipoEnum.TIPO_STRINGA) = mTipoCarico
            End If
            If mChangedCodiceFiscale Then
                .Field("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            End If
            If mChangedCognome Then
                .Field("Cognome", TipoEnum.TIPO_STRINGA) = mCognome
            End If
            If mChangedNome Then
                .Field("Nome", TipoEnum.TIPO_STRINGA) = mNome
            End If
            If mChangedSesso Then
                .Field("Sesso", TipoEnum.TIPO_STRINGA) = mSesso
            End If
            If mChangedTassabile Then
                .Field("Tassabile", TipoEnum.TIPO_NUMERO) = mTassabile
            End If
            If mChangedTotaleTitolo Then
                .Field("TotaleTitolo", TipoEnum.TIPO_NUMERO) = mTotaleTitolo
            End If
            If mChangedProdotto Then
                .Field("Prodotto", TipoEnum.TIPO_STRINGA) = mProdotto
            End If
            If mChangedDelegataria Then
                .Field("Delegataria", TipoEnum.TIPO_STRINGA) = mDelegataria
            End If
            If mChangedSubAgenzia Then
                .Field("SubAgenzia", TipoEnum.TIPO_NUMERO) = mSubAgenzia
            End If
            If mChangedConvenzione Then
                .Field("Convenzione", TipoEnum.TIPO_NUMERO) = mConvenzione
            End If
            If mChangedTarga Then
                .Field("Targa", TipoEnum.TIPO_STRINGA) = mTarga
            End If
            If mChangedModello Then
                .Field("Modello", TipoEnum.TIPO_STRINGA) = mModello
            End If
            If mChangedRamoGestione Then
                .Field("RamoGestione", TipoEnum.TIPO_NUMERO) = mRamoGestione
            End If
            If mChangedComparto Then
                .Field("Comparto", TipoEnum.TIPO_NUMERO) = mComparto
            End If
            If mChangedIncassabile Then
                .Field("Incassabile", TipoEnum.TIPO_BOOLEAN) = mIncassabile
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedRamo = False
        mChangedPolizza = False
        mChangedEffettoAppendice = False
        mChangedNumeroAppendice = False
        mChangedEffettoTitolo = False
        mChangedTipoCarico = False
        mChangedCodiceFiscale = False
        mChangedCognome = False
        mChangedNome = False
        mChangedSesso = False
        mChangedTassabile = False
        mChangedTotaleTitolo = False
        mChangedProdotto = False
        mChangedDelegataria = False
        mChangedSubAgenzia = False
        mChangedConvenzione = False
        mChangedTarga = False
        mChangedModello = False
        mChangedRamoGestione = False
        mChangedComparto = False
        mChangedIncassabile = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mTipoCarico.Length > 1 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False
        If mCognome.Length > 40 Then Ris = False
        If mNome.Length > 25 Then Ris = False
        If mSesso.Length > 1 Then Ris = False
        If mProdotto.Length > 5 Then Ris = False
        If mDelegataria.Length > 3 Then Ris = False
        If mTarga.Length > 20 Then Ris = False
        If mModello.Length > 40 Then Ris = False

        Return Ris
    End Function


End Class
