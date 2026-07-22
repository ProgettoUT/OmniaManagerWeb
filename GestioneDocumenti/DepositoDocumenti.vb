Imports System.IO

Friend Class DepositoDocumenti

    Public Shared Principale As String = "Unitools\Documenti"
    Public Shared Storico As String = "Unitools\DocumentiStorico"

    Public Sub New()

        Try
            'Dim Disco As New UnitaDisco(Ambiente)
            Dim Disco As New UnitaDisco()

            mFullPathDeposito = Path.Combine(Disco.Disco, Principale)
            mFullPathDepositoStorico = Path.Combine(Disco.Disco, Storico)

            'se non esiste lo crea
            My.Computer.FileSystem.CreateDirectory(mFullPathDeposito)
            My.Computer.FileSystem.CreateDirectory(mFullPathDepositoStorico)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private mFullPathDeposito As String
    Public ReadOnly Property FullPathDeposito() As String
        Get
            Return mFullPathDeposito
        End Get
    End Property

    Private mFullPathDepositoStorico As String
    Public ReadOnly Property FullPathDepositoStorico() As String
        Get
            Return mFullPathDepositoStorico
        End Get
    End Property

End Class
