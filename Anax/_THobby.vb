Imports Utx.FunzioniDb.Funzioni


Public Class _THobby
    Inherits TBase
    Private Const sMODULENAME = "Hobby"
    Private Const ANA_HOBBY = "[Ana_hobby]"

    'Campi della tabella
    Private mCodiceFiscale As String
    Private mIdHobby As Integer
    Private mDesHobby As String
    Private mFrequenza As String
    Private mPericoloInfortuni As Boolean
    Private mPericoloMorte As Boolean
    Private mCoperturaHobby As Boolean

    'Campi che possono essere aggiornati
    Private mChangedDesHobby As Boolean
    Private mChangedFrequenza As Boolean
    Private mChangedPericoloInfortuni As Boolean
    Private mChangedPericoloMorte As Boolean
    Private mChangedCoperturaHobby As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ANA_HOBBY
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

    Public Property IdHobby() As Integer
        Get
            Return mIdHobby
        End Get
        Set(value As Integer)
            mIdHobby = value
        End Set
    End Property

    Public Property DesHobby() As String
        Get
            Return mDesHobby
        End Get
        Set(value As String)
            If mDesHobby <> value Then
                mDesHobby = value
                mChangedDesHobby = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Frequenza() As String
        Get
            Return mFrequenza
        End Get
        Set(value As String)
            If mFrequenza <> value Then
                mFrequenza = value
                mChangedFrequenza = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property PericoloInfortuni() As Boolean
        Get
            Return mPericoloInfortuni
        End Get
        Set(value As Boolean)
            If mPericoloInfortuni <> value Then
                mPericoloInfortuni = value
                mChangedPericoloInfortuni = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property PericoloMorte() As Boolean
        Get
            Return mPericoloMorte
        End Get
        Set(value As Boolean)
            If mPericoloMorte <> value Then
                mPericoloMorte = value
                mChangedPericoloMorte = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property CoperturaHobby() As Boolean
        Get
            Return mCoperturaHobby
        End Get
        Set(value As Boolean)
            If mCoperturaHobby <> value Then
                mCoperturaHobby = value
                mChangedCoperturaHobby = True
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
            Key &= DELIMITER & mIdHobby
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mCodiceFiscale = keys(0)
            mIdHobby = keys(1)
        End Set
    End Property

    Public Function LoadByKey( _
                 CodiceFiscale As String _
                 , IdHobby As Integer _
                ) As Boolean

        mCodiceFiscale = CodiceFiscale
        mIdHobby = IdHobby

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_HOBBY
        End If

        With sql
            .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Where("IdHobby", TipoEnum.TIPO_NUMERO) = mIdHobby
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = ANA_HOBBY
                .Where("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
                mIdHobby = .GetNextPrg("IdHobby")
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_HOBBY
        End If


        With sql
            .Field("CodiceFiscale", TipoEnum.TIPO_STRINGA) = mCodiceFiscale
            .Field("IdHobby", TipoEnum.TIPO_NUMERO) = mIdHobby
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
                columnIndex = .GetOrdinal("IdHobby")
                If Not .IsDBNull(columnIndex) Then
                    mIdHobby = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("DesHobby")
                If Not .IsDBNull(columnIndex) Then
                    mDesHobby = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Frequenza")
                If Not .IsDBNull(columnIndex) Then
                    mFrequenza = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("PericoloInfortuni")
                If Not .IsDBNull(columnIndex) Then
                    mPericoloInfortuni = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("PericoloMorte")
                If Not .IsDBNull(columnIndex) Then
                    mPericoloMorte = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("CoperturaHobby")
                If Not .IsDBNull(columnIndex) Then
                    mCoperturaHobby = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedDesHobby Then
                .Field("DesHobby", TipoEnum.TIPO_STRINGA) = mDesHobby
            End If
            If mChangedFrequenza Then
                .Field("Frequenza", TipoEnum.TIPO_STRINGA) = mFrequenza
            End If
            If mChangedPericoloInfortuni Then
                .Field("PericoloInfortuni", TipoEnum.TIPO_BOOLEAN) = mPericoloInfortuni
            End If
            If mChangedPericoloMorte Then
                .Field("PericoloMorte", TipoEnum.TIPO_BOOLEAN) = mPericoloMorte
            End If
            If mChangedCoperturaHobby Then
                .Field("CoperturaHobby", TipoEnum.TIPO_BOOLEAN) = mCoperturaHobby
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedDesHobby = False
        mChangedFrequenza = False
        mChangedPericoloInfortuni = False
        mChangedPericoloMorte = False
        mChangedCoperturaHobby = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mCodiceFiscale.Length = 0 Then Ris = False
        If mCodiceFiscale.Length > 16 Then Ris = False
        If mDesHobby.Length > 100 Then Ris = False
        If mFrequenza.Length > 25 Then Ris = False

        Return Ris
    End Function


End Class
