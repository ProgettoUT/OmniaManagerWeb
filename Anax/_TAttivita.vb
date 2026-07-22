Imports Utx.FunzioniDb.Funzioni


Public Class _TAttivita
    Inherits TBase
    Private Const sMODULENAME = "Attivita"
    Private Const ANA_ATTIVITA = "[Ana_attivita]"

    'Campi della tabella
    Private mCodiceFiscale As String
    Private mIdAttivita As Integer
    Private mTipoAttivita As String
    Private mImpresaPubblica As Boolean
    Private mImpresaSettore As String
    Private mImpresaDimensione As String
    Private mImpresaDenominazione As String
    Private mImpresaInizio As DateTime
    Private mAttivitaFase As String
    Private mAtivitaImporto As Decimal

    'Campi che possono essere aggiornati
    Private mChangedTipoAttivita As Boolean
    Private mChangedImpresaPubblica As Boolean
    Private mChangedImpresaSettore As Boolean
    Private mChangedImpresaDimensione As Boolean
    Private mChangedImpresaDenominazione As Boolean
    Private mChangedImpresaInizio As Boolean
    Private mChangedAttivitaFase As Boolean
    Private mChangedAtivitaImporto As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ANA_ATTIVITA
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

    Public Property IdAttivita() As Integer
        Get
            Return mIdAttivita
        End Get
        Set(value As Integer)
            mIdAttivita = value
        End Set
    End Property

    Public Property TipoAttivita() As String
        Get
            Return mTipoAttivita
        End Get
        Set(value As String)
            If mTipoAttivita <> value Then
                mTipoAttivita = value
                mChangedTipoAttivita = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ImpresaPubblica() As Boolean
        Get
            Return mImpresaPubblica
        End Get
        Set(value As Boolean)
            If mImpresaPubblica <> value Then
                mImpresaPubblica = value
                mChangedImpresaPubblica = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ImpresaSettore() As String
        Get
            Return mImpresaSettore
        End Get
        Set(value As String)
            If mImpresaSettore <> value Then
                mImpresaSettore = value
                mChangedImpresaSettore = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ImpresaDimensione() As String
        Get
            Return mImpresaDimensione
        End Get
        Set(value As String)
            If mImpresaDimensione <> value Then
                mImpresaDimensione = value
                mChangedImpresaDimensione = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ImpresaDenominazione() As String
        Get
            Return mImpresaDenominazione
        End Get
        Set(value As String)
            If mImpresaDenominazione <> value Then
                mImpresaDenominazione = value
                mChangedImpresaDenominazione = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property ImpresaInizio() As DateTime
        Get
            Return mImpresaInizio
        End Get
        Set(value As DateTime)
            If mImpresaInizio <> value Then
                mImpresaInizio = value
                mChangedImpresaInizio = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AttivitaFase() As String
        Get
            Return mAttivitaFase
        End Get
        Set(value As String)
            If mAttivitaFase <> value Then
                mAttivitaFase = value
                mChangedAttivitaFase = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property AtivitaImporto() As Decimal
        Get
            Return mAtivitaImporto
        End Get
        Set(value As Decimal)
            If mAtivitaImporto <> value Then
                mAtivitaImporto = value
                mChangedAtivitaImporto = True
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
            Key &= DELIMITER & mIdAttivita
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mCodiceFiscale = keys(0)
            mIdAttivita = keys(1)
        End Set
    End Property

    Public Function LoadByKey( _
                 CodiceFiscale As String _
                 , IdAttivita As Integer _
                ) As Boolean

        mCodiceFiscale = CodiceFiscale
        mIdAttivita = IdAttivita

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_ATTIVITA
        End If

        With sql
            .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Where("IdAttivita", TipoEnum.TIPO_NUMERO) = mIdAttivita
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = ANA_ATTIVITA
                .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
                mIdAttivita = .GetNextPrg("IdAttivita")
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_ATTIVITA
        End If


        With sql
            .Field("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Field("IdAttivita", TipoEnum.TIPO_NUMERO) = mIdAttivita
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
                columnIndex = .GetOrdinal("IdAttivita")
                If Not .IsDBNull(columnIndex) Then
                    mIdAttivita = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("TipoAttivita")
                If Not .IsDBNull(columnIndex) Then
                    mTipoAttivita = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ImpresaPubblica")
                If Not .IsDBNull(columnIndex) Then
                    mImpresaPubblica = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ImpresaSettore")
                If Not .IsDBNull(columnIndex) Then
                    mImpresaSettore = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ImpresaDimensione")
                If Not .IsDBNull(columnIndex) Then
                    mImpresaDimensione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ImpresaDenominazione")
                If Not .IsDBNull(columnIndex) Then
                    mImpresaDenominazione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("ImpresaInizio")
                If Not .IsDBNull(columnIndex) Then
                    mImpresaInizio = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AttivitaFase")
                If Not .IsDBNull(columnIndex) Then
                    mAttivitaFase = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("AtivitaImporto")
                If Not .IsDBNull(columnIndex) Then
                    mAtivitaImporto = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedTipoAttivita Then
                .Field("TipoAttivita", TipoEnum.TIPO_STRINGA) = mTipoAttivita
            End If
            If mChangedImpresaPubblica Then
                .Field("ImpresaPubblica", TipoEnum.TIPO_BOOLEAN) = mImpresaPubblica
            End If
            If mChangedImpresaSettore Then
                .Field("ImpresaSettore", TipoEnum.TIPO_STRINGA) = mImpresaSettore
            End If
            If mChangedImpresaDimensione Then
                .Field("ImpresaDimensione", TipoEnum.TIPO_STRINGA) = mImpresaDimensione
            End If
            If mChangedImpresaDenominazione Then
                .Field("ImpresaDenominazione", TipoEnum.TIPO_STRINGA) = mImpresaDenominazione
            End If
            If mChangedImpresaInizio Then
                .Field("ImpresaInizio", TipoEnum.TIPO_DATA) = mImpresaInizio
            End If
            If mChangedAttivitaFase Then
                .Field("AttivitaFase", TipoEnum.TIPO_STRINGA) = mAttivitaFase
            End If
            If mChangedAtivitaImporto Then
                .Field("AtivitaImporto", TipoEnum.TIPO_VALUTA) = mAtivitaImporto
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedTipoAttivita = False
        mChangedImpresaPubblica = False
        mChangedImpresaSettore = False
        mChangedImpresaDimensione = False
        mChangedImpresaDenominazione = False
        mChangedImpresaInizio = False
        mChangedAttivitaFase = False
        mChangedAtivitaImporto = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mCodiceFiscale.Length = 0 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False
        If mTipoAttivita.Length > 1 Then Ris = False
        If mImpresaSettore.Length > 100 Then Ris = False
        If mImpresaDimensione.Length > 1 Then Ris = False
        If mImpresaDenominazione.Length > 100 Then Ris = False
        If mAttivitaFase.Length > 1 Then Ris = False

        Return Ris
    End Function


End Class
