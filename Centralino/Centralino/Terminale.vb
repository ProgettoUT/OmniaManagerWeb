Imports System.Data.OleDb

Public Class Terminale

    Sub New()
    End Sub

    Sub New(Interno As Integer)
        Me.Interno = Interno
    End Sub

    Private mInterno As Integer
    Public Property Interno() As Integer
        Get
            Return mInterno
        End Get
        Set(value As Integer)
            mInterno = value
            DatiTerminale()
        End Set
    End Property

    Private mIpTelefono As String
    Public ReadOnly Property IpTelefono() As String
        Get
            Return mIpTelefono
        End Get
    End Property

    Private mMacAddress As String
    Public ReadOnly Property MacAddress() As String
        Get
            Return mMacAddress
        End Get
    End Property

    Private mPassword As String
    Public ReadOnly Property Password() As String
        Get
            Return mPassword
        End Get
    End Property

    Public ReadOnly Property Ping() As String
        Get
            Return My.Computer.Network.Ping(mIpTelefono, 1000)
        End Get
    End Property

    Private Sub DatiTerminale()
        Try
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.SMS))
                c.Open()

                Dim dr As OleDbDataReader = Utx.FunzioniDb.CreaDataReader(c, "SELECT * FROM UtentiCentralino WHERE Interno = " + mInterno.ToString)

                If dr.HasRows Then
                    dr.Read()
                    mIpTelefono = Utx.FunzioniDb.NullToString(dr("IPTelefono"))
                    mMacAddress = Utx.FunzioniDb.NullToString(dr("MacAddressTelefono"))
                    mPassword = Utx.FunzioniDb.NullToString(dr("PasswordTelefono"))
                Else
                    mIpTelefono = dr("0.0.0.0")
                    mMacAddress = dr("000000000000")
                    mPassword = dr("")
                End If
            End Using
        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try
    End Sub

    Private Shared Sub LeggiInterni()
        Try
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.SMS))
                c.Open()

                If Utx.FunzioniDb.EsisteTabella(c, "UtentiCentralino") = False Then
                    Utx.GestioneDatabase.CreaTabellaMdb(c, Utx.GestioneDatabase.TipoDatabase.COMUNE, "UtentiCentralino")
                End If

                mInterni = Utx.FunzioniDb.CreaDataTable("SELECT UCASE(Utente) AS Utente,Nome,Interno,PasswordTelefono AS [Password],MacAddressTelefono AS MacAddress,IPTelefono AS IP " +
                                                        "FROM UtentiCentralino ORDER BY Interno", c)
            End Using
        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try
    End Sub

    Public Shared Sub ResetInterni()
        mInterni = Nothing
    End Sub

    Private Shared mInterni As DataTable
    Public Shared ReadOnly Property Interni() As DataTable
        Get
            If mInterni Is Nothing Then
                LeggiInterni()
            End If
            Return mInterni
        End Get
    End Property

    Public Shared Function IsInterno(Numero As String) As Boolean
        For Each row As DataRow In mInterni.Rows
            If row.Item("Interno") = Numero Then
                Return True
            End If
        Next
        Return False
    End Function
End Class
