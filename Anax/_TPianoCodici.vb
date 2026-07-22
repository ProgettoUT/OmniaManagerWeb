Imports Utx.FunzioniDb.Funzioni


Public Class _TPianoCodici
    Inherits TBase
    Private Const sMODULENAME = "PianoCodici"
    Private Const ANA_PIANOCODICI = "[Ana_pianocodici]"

    'Campi della tabella
    Private mTipologia As String
    Private mCodice As String
    Private mIdioma As String
    Private mOrdine As Integer

    'Campi che possono essere aggiornati
    Private mChangedIdioma As Boolean
    Private mChangedOrdine As Boolean

    '**************************************************************************
    ' Nome Tabella
    '**************************************************************************
    Protected Friend Overrides ReadOnly Property Tabella() As String
        Get
            Return ANA_PIANOCODICI
        End Get
    End Property

    '**************************************************************************
    ' Proprietà dell'oggetto
    '**************************************************************************
    Public Property Tipologia() As String
        Get
            Return mTipologia
        End Get
        Set(value As String)
            mTipologia = value
        End Set
    End Property

    Public Property Codice() As String
        Get
            Return mCodice
        End Get
        Set(value As String)
            mCodice = value
        End Set
    End Property

    Public Property Idioma() As String
        Get
            Return mIdioma
        End Get
        Set(value As String)
            If mIdioma <> value Then
                mIdioma = value
                mChangedIdioma = True
                SetModifiedState()
            End If
        End Set
    End Property

    Public Property Ordine() As Integer
        Get
            Return mOrdine
        End Get
        Set(value As Integer)
            If mOrdine <> value Then
                mOrdine = value
                mChangedOrdine = True
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
            Key &= DELIMITER & mTipologia
            Key &= DELIMITER & mCodice
            Return Key
        End Get
        Set(value As String)
            Dim keys() As String = Split(value, DELIMITER)
            mTipologia = keys(0)
            mCodice = keys(1)
        End Set
    End Property

    Public Function LoadByKey( _
                 Tipologia As String _
                 , Codice As String _
                ) As Boolean

        mTipologia = Tipologia
        mCodice = Codice

        LoadByKey = GetFields()
    End Function

    Protected Overrides Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_PIANOCODICI
        End If

        With sql
            .Where("Tipologia", TipoEnum.TIPO_STRINGA) = mTipologia
            .Where("Codice", TipoEnum.TIPO_STRINGA) = mCodice
        End With

        GetSqlKey = sql
    End Function

    Protected Overrides Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory

        If IsNew() Then
            With New SqlFactory
                .Tabella = ANA_PIANOCODICI
                .Where("Tipologia", TipoEnum.TIPO_STRINGA) = mTipologia
                .Where("Codice", TipoEnum.TIPO_STRINGA) = mCodice
            End With
        End If

        If sql Is Nothing Then
            sql = New SqlFactory
            sql.Tabella = ANA_PIANOCODICI
        End If


        With sql
            .Field("Tipologia", TipoEnum.TIPO_STRINGA) = mTipologia
            .Field("Codice", TipoEnum.TIPO_STRINGA) = mCodice
        End With

        PutSqlKey = sql
    End Function

    Public Overrides Function GetFields(rs As DataTableReader) As Boolean
        Dim columnIndex As Integer = 0
        With rs
            If .HasRows Then
                columnIndex = .GetOrdinal("Tipologia")
                If Not .IsDBNull(columnIndex) Then
                    mTipologia = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Codice")
                If Not .IsDBNull(columnIndex) Then
                    mCodice = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Idioma")
                If Not .IsDBNull(columnIndex) Then
                    mIdioma = .GetValue(columnIndex)
                End If
                columnIndex = .GetOrdinal("Ordine")
                If Not .IsDBNull(columnIndex) Then
                    mOrdine = .GetValue(columnIndex)
                End If
                SetUpdatedMember()
                Return True
            End If
        End With
        Return False
    End Function

    Protected Overrides Function PutSqlFields(sql As SqlFactory) As SqlFactory
        With sql
            If mChangedIdioma Then
                .Field("Idioma", TipoEnum.TIPO_STRINGA) = mIdioma
            End If
            If mChangedOrdine Then
                .Field("Ordine", TipoEnum.TIPO_NUMERO) = mOrdine
            End If
        End With

        PutSqlFields = sql
    End Function

    Protected Overrides Sub SetUnchangedMember()
        mChangedIdioma = False
        mChangedOrdine = False
    End Sub

    Public Overrides Function IsValid() As Boolean
        Dim Ris As Boolean = True
        If mTipologia.Length = 0 Then Ris = False
        If mTipologia.Length > 1 Then Ris = False
        If mCodice.Length = 0 Then Ris = False
        If mCodice.Length > 1 Then Ris = False
        If mIdioma.Length > 25 Then Ris = False

        Return Ris
    End Function


End Class
