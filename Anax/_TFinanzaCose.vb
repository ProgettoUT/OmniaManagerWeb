Imports Utx.FunzioniDb.Funzioni


Public Class _TFinanzaCose
    Inherits TBase
    Private Const sMODULENAME = "FinanzaCose"
    Private Const ANA_FINANZACOSE = "[Ana_finanzacose]"

    'Campi della tabella
    Private mCodiceFiscale As String
    Private mCodServizio As String
    Private mCodSoddisfazione As String

    'Campi che possono essere aggiornati
    Private mChangedCodSoddisfazione As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ANA_FINANZACOSE
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

    Public Property CodServizio() As String
        Get
            Return mCodServizio
        End Get
        Set(value As String)
            mCodServizio = value
        End Set
    End Property

    Public Property CodSoddisfazione() As String
        Get
            Return mCodSoddisfazione
        End Get
        Set(value As String)
            If mCodSoddisfazione <> value Then
                mCodSoddisfazione = value
                mChangedCodSoddisfazione = True
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
            Key &= DELIMITER & mCodServizio
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mCodiceFiscale = keys(0)
            mCodServizio = keys(1)
        End Set
    End Property

    Public Function LoadByKey( _
                 CodiceFiscale As String _
                 , CodServizio As String _
                ) As Boolean

        mCodiceFiscale = CodiceFiscale
        mCodServizio = CodServizio

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_FINANZACOSE
        End If

        With sql
            .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Where("CodServizio", TipoEnum.TIPO_STRINGA) = mCodServizio
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = ANA_FINANZACOSE
                .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
                .Where("CodServizio", TipoEnum.TIPO_STRINGA) = mCodServizio
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_FINANZACOSE
        End If


        With sql
            .Field("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Field("CodServizio", TipoEnum.TIPO_STRINGA) = mCodServizio
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
                columnIndex = .GetOrdinal("CodServizio")
                If Not .IsDBNull(columnIndex) Then
                    mCodServizio = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CodSoddisfazione")
                If Not .IsDBNull(columnIndex) Then
                    mCodSoddisfazione = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedCodSoddisfazione Then
                .Field("CodSoddisfazione", TipoEnum.TIPO_STRINGA) = mCodSoddisfazione
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedCodSoddisfazione = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mCodiceFiscale.Length = 0 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False
        If mCodServizio.Length = 0 Then Ris = False
        If mCodServizio.Length > 1 Then Ris = False
        If mCodSoddisfazione.Length > 1 Then Ris = False

        Return Ris
    End Function


End Class
