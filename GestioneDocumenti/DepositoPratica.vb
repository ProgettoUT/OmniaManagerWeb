Imports System.IO

Public Class DepositoPratica

    Sub New(CodiceFiscale As String)
        'definisce la cartella dei documenti del cliente
        Try
            mCodiceFiscale = CodiceFiscale.Trim
            mIdPratica = mCodiceFiscale

            Dim UltimoCarattere As String = Right(mCodiceFiscale, 1)

            'aggiungo il carattere al path (la cartella pratica coincide con quella cliente)
            mFullPathCliente = Path.Combine(Utx.Globale.Paths.CartellaDocumenti, UltimoCarattere)
            mFullPathStorico = Path.Combine(Utx.Globale.Paths.CartellaDocumentiStorico, UltimoCarattere)

            'aggiungo il codice fiscale
            mFullPathCliente = Path.Combine(mFullPathCliente, mCodiceFiscale)
            mFullPathStorico = Path.Combine(mFullPathStorico, mCodiceFiscale)

            'la pratica coincide con il cliente
            mFullPathPratica = mFullPathCliente

            'crea la cartella se non esiste
            My.Computer.FileSystem.CreateDirectory(mFullPathCliente)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Sub New(CodiceFiscale As String, IdSinistro As String)
        'definisce la cartella dei documenti di un sinistro
        Try
            mCodiceFiscale = CodiceFiscale.Trim
            mIdPratica = String.Format("Sinistro {0}", IdSinistro)

            Dim UltimoCarattere As String = Right(mCodiceFiscale, 1)

            'aggiungo il carattere al path (la cartella pratica coincide con quella cliente)
            mFullPathCliente = Path.Combine(Utx.Globale.Paths.CartellaDocumenti, UltimoCarattere)
            mFullPathStorico = Path.Combine(Utx.Globale.Paths.CartellaDocumentiStorico, UltimoCarattere)

            'aggiungo il codice fiscale
            mFullPathCliente = Path.Combine(mFullPathCliente, mCodiceFiscale)
            mFullPathStorico = Path.Combine(mFullPathStorico, mCodiceFiscale)

            'aggiungo l'id della pratica
            mFullPathPratica = Path.Combine(mFullPathCliente, IdPratica)
            mFullPathStoricoPratica = Path.Combine(mFullPathStorico, IdPratica)

            'crea la cartella se non esiste
            My.Computer.FileSystem.CreateDirectory(mFullPathPratica)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Sub New(CodiceFiscale As String, Ramo As Integer, Polizza As Integer)
        'definisce la cartella dei documenti di una polizza
        Try
            mCodiceFiscale = CodiceFiscale.Trim
            mIdPratica = String.Format("Polizza {0:000}.{1:000000000}", Ramo, Polizza)

            Dim UltimoCarattere As String = Right(mCodiceFiscale, 1)

            'aggiungo il carattere al path (la cartella pratica coincide con quella cliente)
            mFullPathCliente = Path.Combine(Utx.Globale.Paths.CartellaDocumenti, UltimoCarattere)
            mFullPathStorico = Path.Combine(Utx.Globale.Paths.CartellaDocumentiStorico, UltimoCarattere)

            'aggiungo il codice fiscale
            mFullPathCliente = Path.Combine(mFullPathCliente, mCodiceFiscale)
            mFullPathStorico = Path.Combine(mFullPathStorico, mCodiceFiscale)

            'aggiungo l'id della pratica
            mFullPathPratica = Path.Combine(mFullPathCliente, IdPratica)

            'crea la cartella se non esiste
            My.Computer.FileSystem.CreateDirectory(mFullPathPratica)

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

    Private mFullPathCliente As String
    Public ReadOnly Property FullPathCliente() As String
        Get
            Return mFullPathCliente.Trim
        End Get
    End Property

    Private mFullPathPratica As String
    Public ReadOnly Property FullPathPratica() As String
        Get
            Return mFullPathPratica.Trim
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

    Private mFullPathStoricoPratica As String
    Public ReadOnly Property FullPathStoricoPratica() As String
        Get
            Return mFullPathStoricoPratica.Trim
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
End Class
