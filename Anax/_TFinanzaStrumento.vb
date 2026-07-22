Imports Utx.FunzioniDb.Funzioni


Public Class _TFinanzaStrumento
    Inherits TBase
    Private Const sMODULENAME = "FinanzaStrumento"
    Private Const ANA_FINANZASTRUMENTO = "[Ana_finanzastrumento]"

    'Campi della tabella
    Private mCodiceFiscale As String
    Private mCodStrumento As String
    Private mImporto As Decimal
    Private mBanca As String
    Private mSim As String
    Private mTipologia As String
    Private mCodEsperienza As String
    Private mCoperturaPolizza As Boolean

    'Campi che possono essere aggiornati
    Private mChangedImporto As Boolean
    Private mChangedBanca As Boolean
    Private mChangedSim As Boolean
    Private mChangedTipologia As Boolean
    Private mChangedCodEsperienza As Boolean
    Private mChangedCoperturaPolizza As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ANA_FINANZASTRUMENTO
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

    Public Property CodStrumento() As String
        Get
            Return mCodStrumento
        End Get
        Set(value As String)
            mCodStrumento = value
        End Set
    End Property

    Public Property Importo() As Decimal
        Get
            Return mImporto
        End Get
        Set(value As Decimal)
            If mImporto <> value Then
                mImporto = value
                mChangedImporto = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Banca() As String
        Get
            Return mBanca
        End Get
        Set(value As String)
            If mBanca <> value Then
                mBanca = value
                mChangedBanca = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Sim() As String
        Get
            Return mSim
        End Get
        Set(value As String)
            If mSim <> value Then
                mSim = value
                mChangedSim = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Tipologia() As String
        Get
            Return mTipologia
        End Get
        Set(value As String)
            If mTipologia <> value Then
                mTipologia = value
                mChangedTipologia = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CodEsperienza() As String
        Get
            Return mCodEsperienza
        End Get
        Set(value As String)
            If mCodEsperienza <> value Then
                mCodEsperienza = value
                mChangedCodEsperienza = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CoperturaPolizza() As Boolean
        Get
            Return mCoperturaPolizza
        End Get
        Set(value As Boolean)
            If mCoperturaPolizza <> value Then
                mCoperturaPolizza = value
                mChangedCoperturaPolizza = True
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
            Key &= DELIMITER & mCodStrumento
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mCodiceFiscale = keys(0)
            mCodStrumento = keys(1)
        End Set
    End Property

    Public Function LoadByKey( _
                 CodiceFiscale As String _
                 , CodStrumento As String _
                ) As Boolean

        mCodiceFiscale = CodiceFiscale
        mCodStrumento = CodStrumento

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_FINANZASTRUMENTO
        End If

        With sql
            .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Where("CodStrumento", TipoEnum.TIPO_STRINGA) = mCodStrumento
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = ANA_FINANZASTRUMENTO
                .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
                .Where("CodStrumento", TipoEnum.TIPO_STRINGA) = mCodStrumento
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_FINANZASTRUMENTO
        End If


        With sql
            .Field("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Field("CodStrumento", TipoEnum.TIPO_STRINGA) = mCodStrumento
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
                columnIndex = .GetOrdinal("CodStrumento")
                If Not .IsDBNull(columnIndex) Then
                    mCodStrumento = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Importo")
                If Not .IsDBNull(columnIndex) Then
                    mImporto = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Banca")
                If Not .IsDBNull(columnIndex) Then
                    mBanca = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Sim")
                If Not .IsDBNull(columnIndex) Then
                    mSim = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Tipologia")
                If Not .IsDBNull(columnIndex) Then
                    mTipologia = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodEsperienza")
                If Not .IsDBNull(columnIndex) Then
                    mCodEsperienza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CoperturaPolizza")
                If Not .IsDBNull(columnIndex) Then
                    mCoperturaPolizza = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedImporto Then
                .Field("Importo", TipoEnum.TIPO_VALUTA) = mImporto
            End If
            If mChangedBanca Then
                .Field("Banca", TipoEnum.TIPO_STRINGA) = mBanca
            End If
            If mChangedSim Then
                .Field("Sim", TipoEnum.TIPO_STRINGA) = mSim
            End If
            If mChangedTipologia Then
                .Field("Tipologia", TipoEnum.TIPO_STRINGA) = mTipologia
            End If
            If mChangedCodEsperienza Then
                .Field("CodEsperienza", TipoEnum.TIPO_STRINGA) = mCodEsperienza
            End If
            If mChangedCoperturaPolizza Then
                .Field("CoperturaPolizza", TipoEnum.TIPO_BOOLEAN) = mCoperturaPolizza
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedImporto = False
        mChangedBanca = False
        mChangedSim = False
        mChangedTipologia = False
        mChangedCodEsperienza = False
        mChangedCoperturaPolizza = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mCodiceFiscale.Length = 0 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False
        If mCodStrumento.Length = 0 Then Ris = False
        If mCodStrumento.Length > 1 Then Ris = False
        If mBanca.Length > 255 Then Ris = False
        If mSim.Length > 255 Then Ris = False
        If mTipologia.Length > 255 Then Ris = False
        If mCodEsperienza.Length > 1 Then Ris = False

        Return Ris
    End Function


End Class
