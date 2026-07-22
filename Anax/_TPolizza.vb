Imports Utx.FunzioniDb.Funzioni


Public Class _TPolizza
    Inherits TBase
    Private Const sMODULENAME = "Polizza"
    Private Const ANA_POLIZZA = "[Ana_polizza]"

    'Campi della tabella
    Private mCodiceFiscale As String
    Private mIdPolizza As Integer
    Private mSezione As String
    Private mPolizza As String
    Private mCompagnia As String
    Private mTarga As String
    Private mMarca As String
    Private mModello As String
    Private mDoc As String
    Private mDataScadenza As DateTime
    Private mDataDisdetta As DateTime
    Private mDataPreventivo As DateTime
    Private mDataPromemoria As DateTime

    'Campi che possono essere aggiornati
    Private mChangedSezione As Boolean
    Private mChangedPolizza As Boolean
    Private mChangedCompagnia As Boolean
    Private mChangedTarga As Boolean
    Private mChangedMarca As Boolean
    Private mChangedModello As Boolean
    Private mChangedDoc As Boolean
    Private mChangedDataScadenza As Boolean
    Private mChangedDataDisdetta As Boolean
    Private mChangedDataPreventivo As Boolean
    Private mChangedDataPromemoria As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ANA_POLIZZA
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

    Public Property Sezione() As String
        Get
            Return mSezione
        End Get
        Set(value As String)
            If mSezione <> value Then
                mSezione = value
                mChangedSezione = True
                SetModifiedState()
            End If
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

    Public Property Compagnia() As String
        Get
            Return mCompagnia
        End Get
        Set(value As String)
            If mCompagnia <> value Then
                mCompagnia = value
                mChangedCompagnia = True
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

    Public Property Doc() As String
        Get
            Return mDoc
        End Get
        Set(value As String)
            If mDoc <> value Then
                mDoc = value
                mChangedDoc = True
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

    Public Property DataDisdetta() As DateTime
        Get
            Return mDataDisdetta
        End Get
        Set(value As DateTime)
            If mDataDisdetta <> value Then
                mDataDisdetta = value
                mChangedDataDisdetta = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DataPreventivo() As DateTime
        Get
            Return mDataPreventivo
        End Get
        Set(value As DateTime)
            If mDataPreventivo <> value Then
                mDataPreventivo = value
                mChangedDataPreventivo = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property DataPromemoria() As DateTime
        Get
            Return mDataPromemoria
        End Get
        Set(value As DateTime)
            If mDataPromemoria <> value Then
                mDataPromemoria = value
                mChangedDataPromemoria = True
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
            sql.Tabella = ANA_POLIZZA
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
                .Tabella = ANA_POLIZZA
                .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
                mIdPolizza = .GetNextPrg("IdPolizza")
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_POLIZZA
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
                columnIndex = .GetOrdinal("Sezione")
                If Not .IsDBNull(columnIndex) Then
                    mSezione = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Polizza")
                If Not .IsDBNull(columnIndex) Then
                    mPolizza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Compagnia")
                If Not .IsDBNull(columnIndex) Then
                    mCompagnia = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Targa")
                If Not .IsDBNull(columnIndex) Then
                    mTarga = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Marca")
                If Not .IsDBNull(columnIndex) Then
                    mMarca = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Modello")
                If Not .IsDBNull(columnIndex) Then
                    mModello = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Doc")
                If Not .IsDBNull(columnIndex) Then
                    mDoc = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataScadenza")
                If Not .IsDBNull(columnIndex) Then
                    mDataScadenza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataDisdetta")
                If Not .IsDBNull(columnIndex) Then
                    mDataDisdetta = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataPreventivo")
                If Not .IsDBNull(columnIndex) Then
                    mDataPreventivo = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DataPromemoria")
                If Not .IsDBNull(columnIndex) Then
                    mDataPromemoria = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedSezione Then
                .Field("Sezione", TipoEnum.TIPO_STRINGA) = mSezione
            End If
            If mChangedPolizza Then
                .Field("Polizza", TipoEnum.TIPO_STRINGA) = mPolizza
            End If
            If mChangedCompagnia Then
                .Field("Compagnia", TipoEnum.TIPO_STRINGA) = mCompagnia
            End If
            If mChangedTarga Then
                .Field("Targa", TipoEnum.TIPO_STRINGA) = mTarga
            End If
            If mChangedMarca Then
                .Field("Marca", TipoEnum.TIPO_STRINGA) = mMarca
            End If
            If mChangedModello Then
                .Field("Modello", TipoEnum.TIPO_STRINGA) = mModello
            End If
            If mChangedDoc Then
                .Field("Doc", TipoEnum.TIPO_STRINGA) = mDoc
            End If
            If mChangedDataScadenza Then
                .Field("DataScadenza", TipoEnum.TIPO_DATA) = mDataScadenza
            End If
            If mChangedDataDisdetta Then
                .Field("DataDisdetta", TipoEnum.TIPO_DATA) = mDataDisdetta
            End If
            If mChangedDataPreventivo Then
                .Field("DataPreventivo", TipoEnum.TIPO_DATA) = mDataPreventivo
            End If
            If mChangedDataPromemoria Then
                .Field("DataPromemoria", TipoEnum.TIPO_DATA) = mDataPromemoria
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedSezione = False
        mChangedPolizza = False
        mChangedCompagnia = False
        mChangedTarga = False
        mChangedMarca = False
        mChangedModello = False
        mChangedDoc = False
        mChangedDataScadenza = False
        mChangedDataDisdetta = False
        mChangedDataPreventivo = False
        mChangedDataPromemoria = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mCodiceFiscale.Length = 0 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False
        If mSezione.Length > 1 Then Ris = False
        If mPolizza.Length > 50 Then Ris = False
        If mCompagnia.Length > 100 Then Ris = False
        If mTarga.Length > 25 Then Ris = False
        If mMarca.Length > 25 Then Ris = False
        If mModello.Length > 25 Then Ris = False
        If mDoc.Length > 255 Then Ris = False

        Return Ris
    End Function


End Class
