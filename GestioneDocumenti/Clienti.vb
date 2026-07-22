Imports System.IO

Public Class Clienti

    Public Sub New(CodiceFiscale As String,
                   Optional NomeCliente As String = "")

        Try
            mCodiceFiscale = CodiceFiscale.Trim
            mNomeCliente = NomeCliente.Trim

            'inizializzo deposito del cliente
            Dim dc As New DepositoPratica(CodiceFiscale)

            mFullPathCliente = dc.FullPathCliente
            mFullPathStorico = dc.FullPathStorico

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private mCodiceFiscale As String
    Public ReadOnly Property CodiceFiscale() As String
        Get
            Return mCodiceFiscale.Trim
        End Get
    End Property

    Private mNomeCliente As String
    Public ReadOnly Property NomeCliente() As String
        Get
            Return mNomeCliente
        End Get
    End Property

    Private mFullPathCliente As String
    Public ReadOnly Property FullPathCliente() As String
        Get
            Return mFullPathCliente.Trim
        End Get
    End Property

    Private mFullPathStorico As String
    Public Property FullPathStorico() As String
        Get
            Return mFullPathStorico
        End Get
        Set(value As String)
            mFullPathStorico = value
        End Set
    End Property

    Public Function NumeroPratiche() As Integer
        Return My.Computer.FileSystem.GetDirectories(mFullPathCliente).Count
    End Function

    Public Function NumeroPraticheStorico() As Integer

        If Directory.Exists(Me.mFullPathStorico) Then
            Return My.Computer.FileSystem.GetDirectories(Me.mFullPathStorico).Count
        Else
            Return 0
        End If
    End Function

    Public Function EsisteStorico() As Boolean
        Return Directory.Exists(Me.mFullPathStorico)
    End Function

    Public Sub AutoClean()
        Try
            For Each c As String In Directory.GetDirectories(mFullPathCliente)
                Me.AutoCleanCartella(c)
            Next

            If NumeroOggettiCartella(mFullPathCliente) = 0 Then
                My.Computer.FileSystem.DeleteDirectory(mFullPathCliente,
                                                       FileIO.DeleteDirectoryOption.ThrowIfDirectoryNonEmpty)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub AutoCleanCartella(PathCartella As String)
        Try
            For Each c As String In Directory.GetDirectories(PathCartella)
                'richiamo ricorsivamente la funzione
                Me.AutoCleanCartella(c)
            Next

            'se non ci sono file cancello la cartella
            If NumeroOggettiCartella(PathCartella) = 0 Then
                My.Computer.FileSystem.DeleteDirectory(PathCartella,
                                                       FileIO.DeleteDirectoryOption.ThrowIfDirectoryNonEmpty)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Function CF2NomeCliente(CF As String) As String
        Try
            Dim Query As String = String.Format("SELECT TRIM(Cognome) + Space(1) + TRIM(Nome) 
                FROM Clienti WHERE CodiceFiscale = '{0}'", CF)

            CF2NomeCliente = Utx.WsCommand.ExecuteScalar(Query).Valore

            If CF2NomeCliente Is Nothing Then
                Return "ND"
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return "ND"
        End Try
    End Function
End Class
