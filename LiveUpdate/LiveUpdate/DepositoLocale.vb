Imports System.IO

Public Class DepositoLocale

    'Friend Const CartellaTemp As String = "C:\ApplicazioniDirezione\Unitools\Temp\Update"

    'Private Const mPathLocale As String = Ut.Globale.Paths.CartellaUpdateLocale '"C:\ApplicazioniDirezione\Unitools\Update\Versioni"
    'Private Const mPathRete As String = "M:\Unitools\Update\Versioni\"

    Sub New(VersioneDeposito As String)

        Try
            Select Case Globale.Ambiente.Tipo
                Case Globale.TipoAmbiente.DIR, Globale.TipoAmbiente.PP2DIR
                    mPathDeposito = Path.Combine(Utx.Globale.Paths.CartellaUpdateRete, Versione.IdVersioneCorrente)
                Case Else
                    mPathDeposito = Path.Combine(Utx.Globale.Paths.CartellaUpdateLocale, Versione.IdVersioneCorrente)
            End Select

            'la versione del deposito
            mVersioneDeposito = VersioneDeposito
            'le cartelle del deposito
            mPathDeposito = Path.Combine(mPathDeposito, mVersioneDeposito)
            mPathDepositoDIR = Path.Combine(mPathDeposito, "DIR")
            mPathDepositoPP = Path.Combine(mPathDeposito, "PP")
            mCartellaRollback = Path.Combine(mPathDeposito, "Rollback")

            'creo le cartelle se non esistono
            Directory.CreateDirectory(mPathDeposito)
            Directory.CreateDirectory(mPathDepositoDIR)
            Directory.CreateDirectory(mPathDepositoPP)
            Directory.CreateDirectory(Me.PathCorrezioni)
            Directory.CreateDirectory(mCartellaRollback)
            Directory.CreateDirectory(Path.Combine(Utx.Globale.Paths.CartellaUpdateLocale, "Versioni\Correzioni"))

        Catch ex As Exception
            Log.Info(ex.Message)
            mPathDeposito = ""
        End Try
    End Sub

    Private mPathDeposito As String
    Public ReadOnly Property PathDeposito() As String
        Get
            Return mPathDeposito
        End Get
    End Property

    Private mCartellaRollback As String
    Public ReadOnly Property CartellaRollback() As String
        Get
            Return mCartellaRollback
        End Get
    End Property

    Private mPathDepositoDIR As String
    Public ReadOnly Property PathDepositoDIR() As String
        Get
            Return mPathDepositoDIR
        End Get
    End Property

    Private mPathDepositoPP As String
    Public ReadOnly Property PathDepositoPP() As String
        Get
            Return mPathDepositoPP
        End Get
    End Property

    Private mVersioneDeposito As String
    Public Property VersioneDeposito() As String
        Get
            Return mVersioneDeposito
        End Get
        Set(value As String)
            mVersioneDeposito = value
        End Set
    End Property

    Public ReadOnly Property PathCorrezioni() As String
        Get
            Return Path.Combine(Utx.Globale.Paths.CartellaUpdateLocale, "Versioni\Correzioni")
        End Get
    End Property

    Public ReadOnly Property IsReady() As Boolean
        Get
            Return Directory.Exists(mPathDeposito)
        End Get
    End Property

    Public Function FileversioneDeposito() As String
        Return Path.Combine(mPathDeposito, mVersioneDeposito + ".cc")
    End Function

    Public Sub SvuotaRollback()
        Try
            If Directory.Exists(mCartellaRollback) Then
                For Each f As String In Directory.GetFiles(mCartellaRollback, "*.*")
                    Try
                        File.Delete(f)
                    Catch ex As Exception
                    End Try
                Next
            End If

        Catch ex As Exception
            Log.Info(ex)
        End Try
    End Sub
End Class
