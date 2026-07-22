Public Class DatiSinistro

    Sub New(AgenziaSinistro As Integer,
            EsercizioSinistro As Integer,
            NumeroSinistro As Integer)

        Try
            mAgenziaSinistro = AgenziaSinistro
            mEsercizioSinistro = EsercizioSinistro
            mNumeroSinistro = NumeroSinistro

            Dim Query As String = String.Format("SELECT S.*,C.Desc_Compagnia
                FROM SinistriDP AS S 
                LEFT JOIN CompagniaANIA AS C ON C.Compagnia = S.CompControparte 
                WHERE AgenziaSinistro = {0} AND EsercizioSinistro = {1} AND NumeroSinistro = {2}", mAgenziaSinistro, mEsercizioSinistro, mNumeroSinistro)

            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query)

            If dr.HasRows Then
                dr.Read()

                mDataSinistro = Globale.NullToDate(dr("DataSinistro"))
                mTargaResponsabile = Globale.NullToString(dr("TargaAssicurato")).Trim
                mTargaControparte = Globale.NullToString(dr("TargaDanneggiato")).Trim
                mCodiceCompagnia = 82
                mCompagnia = "UNIPOL SPA"
                mCodiceCompagniaControparte = Globale.NullToString(dr("CompControparte"))
                mCompagniaControparte = Globale.NullToString(dr("Desc_Compagnia"))
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private mAgenziaSinistro As Integer
    Public ReadOnly Property AgenziaSinistro() As Integer
        Get
            Return mAgenziaSinistro
        End Get
    End Property

    Private mEsercizioSinistro As Integer
    Public ReadOnly Property EsercizioSinistro() As Integer
        Get
            Return mEsercizioSinistro
        End Get
    End Property

    Private mNumeroSinistro As Integer
    Public ReadOnly Property NumeroSinistro() As Integer
        Get
            Return mNumeroSinistro
        End Get
    End Property

    Private mDataSinistro As Date
    Public Property DataSinistro() As String
        Get
            Return mDataSinistro
        End Get
        Set(value As String)
            mDataSinistro = value
        End Set
    End Property

    Private mTargaResponsabile As String
    Public Property TargaResponsabile() As String
        Get
            Return mTargaResponsabile
        End Get
        Set(value As String)
            mTargaResponsabile = value
        End Set
    End Property

    Private mTargaControparte As String
    Public Property TargaControparte() As String
        Get
            Return mTargaControparte
        End Get
        Set(value As String)
            mTargaControparte = value
        End Set
    End Property

    Private mCodiceCompagnia As Integer
    Public Property CodiceCompagnia() As Integer
        Get
            Return mCodiceCompagnia
        End Get
        Set(value As Integer)
            mCodiceCompagnia = value
        End Set
    End Property

    Private mCompagnia As String
    Public Property Compagnia() As String
        Get
            Return mCompagnia
        End Get
        Set(value As String)
            mCompagnia = value
        End Set
    End Property

    Private mCodiceCompagniaControparte As Integer
    Public Property CodiceCompagniaControparte() As Integer
        Get
            Return mCodiceCompagniaControparte
        End Get
        Set(value As Integer)
            mCodiceCompagniaControparte = value
        End Set
    End Property

    Private mCompagniaControparte As String
    Public Property CompagniaControparte() As String
        Get
            Return mCompagniaControparte
        End Get
        Set(value As String)
            mCompagniaControparte = value
        End Set
    End Property
End Class
