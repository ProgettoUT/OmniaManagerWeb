Imports System.IO

Public Class Pratiche

    Public Enum TipoPratica
        CLIENTE = 0
        POLIZZA = 1
        SINISTRO = 2
        DOCUMENTI_AGENZIA = 3
        ND = 4
    End Enum

    Public Sub New(ByRef Cliente As Clienti, Optional Storico As Boolean = False)
        Try
            mCliente = Cliente
            mTipo = TipoPratica.CLIENTE
            mIdPratica = Cliente.CodiceFiscale

            'nel caso viene richiesto lo storico il path pratica e il path storico sono uguali
            'le pratiche di livello inferiore che vengono create a partire dal cliente, se il cliente
            'è storico anche le sotto-cartelle saranno nello storico
            If Storico = False Then
                mFullPathPratica = Cliente.FullPathCliente
            Else
                mFullPathPratica = Cliente.FullPathStorico
            End If

            mFullPathStorico = Cliente.FullPathStorico

            My.Computer.FileSystem.CreateDirectory(mFullPathPratica)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub New(ByRef Cliente As Clienti, IdPratica As String)
        Try
            mCliente = Cliente
            mIdPratica = IdPratica
            mTipo = Tipologia()
            NormalizzaIdPratica()
            'aggiungo l'id
            mFullPathPratica = Path.Combine(Cliente.FullPathCliente, mIdPratica)
            mFullPathStorico = Path.Combine(Cliente.FullPathStorico, mIdPratica)

            My.Computer.FileSystem.CreateDirectory(mFullPathPratica)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub New(ByRef Padre As Pratiche, IdPratica As String)
        Try
            mCliente = Padre.Cliente
            mIdPratica = IdPratica
            mTipo = Tipologia()
            NormalizzaIdPratica()
            'aggiungo l'id
            mFullPathPratica = Path.Combine(Padre.FullPathPratica, mIdPratica)
            mFullPathStorico = Path.Combine(Padre.FullPathStorico, mIdPratica)

            My.Computer.FileSystem.CreateDirectory(mFullPathPratica)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function Tipologia() As TipoPratica
        Try
            If mIdPratica.StartsWith("Sinistro", StringComparison.InvariantCultureIgnoreCase) Then
                Return TipoPratica.SINISTRO
            ElseIf mIdPratica.StartsWith("Polizza", StringComparison.InvariantCultureIgnoreCase) Then
                Return TipoPratica.POLIZZA
            Else
                Return TipoPratica.ND
            End If

        Catch ex As Exception
            Return TipoPratica.ND
        End Try
    End Function

    Private mCliente As Clienti
    Public ReadOnly Property Cliente() As Clienti
        Get
            Return mCliente
        End Get
    End Property

    Private mFullPathPratica As String
    Public ReadOnly Property FullPathPratica() As String
        Get
            Return mFullPathPratica.Trim
        End Get
    End Property

    Private mFullPathStorico As String
    Public ReadOnly Property FullPathStorico() As String
        Get
            Return mFullPathStorico.Trim
        End Get
    End Property

    Private mIdPratica As String
    Public ReadOnly Property IdPratica() As String
        Get
            Return mIdPratica
        End Get
    End Property

    Public ReadOnly Property Id() As String
        Get
            'tolgo i prefissi
            Id = Replace(mIdPratica, "Sinistro", "", , , CompareMethod.Text)
            Id = Replace(Id, "Polizza", "", , , CompareMethod.Text)

            Return Id.Trim
        End Get
    End Property

    Public ReadOnly Property Descrizione() As String
        Get
            If Me.mTipo = TipoPratica.CLIENTE Then
                Return mCliente.NomeCliente
            Else
                Return mIdPratica
            End If
        End Get
    End Property

    Private mTipo As TipoPratica
    Public ReadOnly Property Tipo() As TipoPratica
        Get
            Return mTipo
        End Get
    End Property

    Public Sub ArchiviaNelloStorico()
        My.Computer.FileSystem.MoveDirectory(mFullPathPratica, mFullPathStorico)
    End Sub

    Public Function EsisteSottocartellaPratica(Cartella As String) As Boolean
        Try
            Cartella = Cartella.Trim.ToUpper

            For Each c As String In Directory.GetDirectories(mFullPathPratica)
                If New DirectoryInfo(c).Name.Trim.ToUpper = Cartella Then Return True
            Next

            Return False

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Sub AutoClean()
        Try
            For Each c As String In Directory.GetDirectories(mFullPathPratica)
                Me.AutoCleanCartella(c)
            Next

            If NumeroOggettiCartella(mFullPathPratica) = 0 Then
                My.Computer.FileSystem.DeleteDirectory(mFullPathPratica,
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

    Private Sub NormalizzaIdPratica()
        Try
            Dim SezioniNome(), SezioniId() As String

            If mTipo = TipoPratica.SINISTRO AndAlso mIdPratica.Length < 26 Then

                SezioniNome = mIdPratica.Split(Space(1))

                If SezioniNome.GetUpperBound(0) = 1 Then

                    SezioniId = SezioniNome(1).Split(".")

                    If SezioniId.GetUpperBound(0) = 2 Then

                        mIdPratica = String.Format("{0} {1}.{2}.{3}",
                                                   "Sinistro",
                                                   SezioniId(0).PadLeft(4, "0"),
                                                   SezioniId(1).PadLeft(4, "0"),
                                                   SezioniId(2).PadLeft(7, "0"))
                    End If
                End If

            ElseIf mTipo = TipoPratica.POLIZZA AndAlso mIdPratica.Length < 21 Then

                SezioniNome = mIdPratica.Split(Space(1))

                If SezioniNome.GetUpperBound(0) = 1 Then

                    SezioniId = SezioniNome(1).Split(".")

                    If SezioniId.GetUpperBound(0) = 1 Then

                        mIdPratica = String.Format("{0} {1}.{2}",
                                                   "Polizza",
                                                   SezioniId(0).PadLeft(3, "0"),
                                                   SezioniId(1).PadLeft(9, "0"))
                    End If
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
