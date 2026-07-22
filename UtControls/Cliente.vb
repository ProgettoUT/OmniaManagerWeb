Public Class Cliente

    Sub New(CodiceFiscale As String)
        Try
            Dim Sql As String = String.Format("SELECT * FROM Clienti WHERE CodiceFiscale = '{0}'", CodiceFiscale)

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Sql).DataTable

            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)

                mNome = dr("Nome").ToString.Trim
                mCognome = dr("Cognome").ToString.Trim
                mIndirizzo = dr("Indirizzo")
                mCap = dr("CAP")
                mCitta = dr("Localita")
                mProvincia = dr("Provincia")
                mCF = dr("CodiceFiscale")
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private mNome As String
    Public ReadOnly Property Nome() As String
        Get
            Return mNome
        End Get
    End Property

    Private mCognome As String
    Public ReadOnly Property Cognome() As String
        Get
            Return mCognome
        End Get
    End Property

    Public ReadOnly Property NomeCompleto() As String
        Get
            Return String.Format("{0} {1}", mCognome, mNome)
        End Get
    End Property

    Private mIndirizzo As String
    Public ReadOnly Property Indirizzo() As String
        Get
            Return mIndirizzo
        End Get
    End Property

    Private mCap As String
    Public ReadOnly Property Cap() As String
        Get
            Return mCap
        End Get
    End Property

    Private mCitta As String
    Public ReadOnly Property Citta() As String
        Get
            Return mCitta
        End Get
    End Property

    Private mProvincia As String
    Public ReadOnly Property Provincia() As String
        Get
            Return mProvincia
        End Get
    End Property

    Private mCF As String
    Public ReadOnly Property CF() As String
        Get
            Return mCF
        End Get
    End Property

    Private mTelefoni As Utx.Recapiti = Nothing
    Public ReadOnly Property Telefoni() As Utx.Recapiti
        Get
            If mTelefoni Is Nothing Then
                mTelefoni = Utx.Recapiti.GetRecapitiCliente(mCF).Filtra(Utx.TipoRecapitoEnum.Telefono)
            End If
            Return mTelefoni
        End Get
    End Property

    Private mCellulari As Utx.Recapiti = Nothing
    Public ReadOnly Property Cellulari() As Utx.Recapiti
        Get
            If mCellulari Is Nothing Then
                mCellulari = Utx.Recapiti.GetRecapitiCliente(mCF).Filtra(Utx.TipoRecapitoEnum.Cellulare)
            End If
            Return mCellulari
        End Get
    End Property

    Private mEmail As Utx.Recapiti = Nothing
    Public ReadOnly Property Email() As Utx.Recapiti
        Get
            If mEmail Is Nothing Then
                mEmail = Utx.Recapiti.GetRecapitiCliente(mCF).Filtra(Utx.TipoRecapitoEnum.Email)
            End If
            Return mEmail
        End Get
    End Property

    Public Function IndirizzoCompleto() As String
        Return String.Format("{1}{0}{2}{0}{3} {4} {5}", Environment.NewLine, mNome, mIndirizzo, mCap, mCitta, mProvincia)
    End Function
End Class
