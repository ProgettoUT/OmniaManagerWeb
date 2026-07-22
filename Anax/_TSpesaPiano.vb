Imports Utx.FunzioniDb.Funzioni


Public Class _TSpesaPiano
    Inherits TBase
    Private Const sMODULENAME = "SpesaPiano"
    Private Const ANA_SPESAPIANO = "[Ana_spesapiano]"

    'Campi della tabella
    Private mCodiceFiscale As String
    Private mIdSpesa As Integer
    Private mSpesaImporto As Decimal

    'Campi che possono essere aggiornati
    Private mChangedSpesaImporto As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ANA_SPESAPIANO
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

    Public Property IdSpesa() As Integer
        Get
            Return mIdSpesa
        End Get
        Set(value As Integer)
            mIdSpesa = value
        End Set
    End Property

    Public Property SpesaImporto() As Decimal
        Get
            Return mSpesaImporto
        End Get
        Set(value As Decimal)
            If mSpesaImporto <> value Then
                mSpesaImporto = value
                mChangedSpesaImporto = True
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
            Key &= DELIMITER & mIdSpesa
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mCodiceFiscale = keys(0)
            mIdSpesa = keys(1)
        End Set
    End Property

    Public Function LoadByKey( _
                 CodiceFiscale As String _
                 , IdSpesa As Integer _
                ) As Boolean

        mCodiceFiscale = CodiceFiscale
        mIdSpesa = IdSpesa

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_SPESAPIANO
        End If

        With sql
            .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Where("IdSpesa", TipoEnum.TIPO_NUMERO) = mIdSpesa
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = ANA_SPESAPIANO
                .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
                mIdSpesa = .GetNextPrg("IdSpesa")
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_SPESAPIANO
        End If


        With sql
            .Field("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Field("IdSpesa", TipoEnum.TIPO_NUMERO) = mIdSpesa
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
                columnIndex = .GetOrdinal("IdSpesa")
                If Not .IsDBNull(columnIndex) Then
                    mIdSpesa = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("SpesaImporto")
                If Not .IsDBNull(columnIndex) Then
                    mSpesaImporto = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedSpesaImporto Then
                .Field("SpesaImporto", TipoEnum.TIPO_VALUTA) = mSpesaImporto
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedSpesaImporto = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mCodiceFiscale.Length = 0 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False

        Return Ris
    End Function


End Class
