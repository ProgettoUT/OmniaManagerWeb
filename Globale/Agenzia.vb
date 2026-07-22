Imports System.IO

<Serializable>
Public Class Agenzia

    Public Shared LinkTardivi As New List(Of String)
    Public Event CambioAgenziaRichiesta(CodiceAgenzia As String)

    Sub New(Codice As Integer)
        Me.CodiceAgenzia = Codice
        RaiseEvent CambioAgenziaRichiesta(mCodiceAgenzia)
    End Sub

    Private mCodiceAgenzia As String
    Public Property CodiceAgenzia() As String
        Get
            Return mCodiceAgenzia
        End Get
        Set(value As String)
            mCodiceAgenzia = value.Trim.PadLeft(5, "0")
            RaiseEvent CambioAgenziaRichiesta(mCodiceAgenzia)
        End Set
    End Property

    Private mCartellaDati As String
    Public Property CartellaDati() As String
        Get
            Return mCartellaDati
        End Get
        Set(value As String)
            mCartellaDati = value
        End Set
    End Property

    Private mDbStorico As String
    Public ReadOnly Property DbStorico() As String
        Get
            Return mDbStorico
        End Get
    End Property

    Public Function DbLink(Codice As Integer) As String
        Return Utx.ConnessioniDb.PathMdbAgenzia(Val(Codice).ToString.PadLeft(5, "0"), ConnessioniDb.Db.DBLINK)
    End Function

    Public Sub Init()
        'controllo esistenza db di tutti i codici
        For Each codice As String In Utx.EnteGestore.CodiciGestiti
            Directory.CreateDirectory(Path.Combine(Utx.Globale.Paths.CartellaDati, codice))
            'ControlloDatabaseAgenzia(codice)
        Next

        'per il codice corrente
        mCartellaDati = Path.Combine(Utx.Globale.Paths.CartellaDati, mCodiceAgenzia)
        'crea dblink
        'Utx.Globale.Paths.CreaDbLinkSupporto()
        'CreaDbLink()
    End Sub

    Private Shared Sub ControlloDatabaseAgenzia(CodiceAgenzia As String)
        Try
            'cartella mdb agenzia
            Dim CartellaDb As String = Path.Combine(Utx.Globale.Paths.CartellaDati, CodiceAgenzia)

            'controlla l'esistenza di tutti gli mdb per l'agenzia confrontando con il contenuto della cartella modelli
            For Each modello As String In Directory.GetFiles(Utx.Globale.Paths.CartellaModelliDatiAgenzia)
                'escludo gli UTOLD
                If Path.GetFileName(modello).ToUpper.StartsWith("UTOLD.") = False Then
                    Dim db As String = Path.Combine(CartellaDb, Path.GetFileName(modello))
                    'se non esiste lo copio dalla cartella dei modelli
                    If File.Exists(db) = False Then
                        File.Copy(modello, db)
                        Utx.Globale.Log.Info("Inizializzo db " & db)
                    End If
                End If
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
