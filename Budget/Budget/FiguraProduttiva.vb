
Public Class FiguraProduttiva

    Public Enum TipoFigura
        NON_DEFINITO
        CIP
        GRUPPO
    End Enum

    Public Shared Figure As New List(Of FiguraProduttiva)

    Sub New(Codice As Integer,
            Descrizione As String,
            Tipo As TipoFigura)

        If Tipo = TipoFigura.NON_DEFINITO Then
            mCodice = "»"
        Else
            mCodice = Format(Codice, "0000")
        End If
        mDescrizione = Descrizione.Trim
        mTipo = Tipo
    End Sub

    Private mCodice As String
    Public ReadOnly Property Codice() As String
        Get
            Return mCodice
        End Get
    End Property

    Private mDescrizione As String
    Public ReadOnly Property Descrizione() As String
        Get
            Return mDescrizione
        End Get
    End Property

    Private mTipo As TipoFigura
    Public ReadOnly Property Tipo() As TipoFigura
        Get
            Return mTipo
        End Get
    End Property

    Public ReadOnly Property DescrizioneEstesa() As String
        Get
            Return String.Format("{0} {1}", mCodice, mDescrizione)
        End Get
    End Property

    Public Shared Function SelezionaFigura(Codice As String) As FiguraProduttiva
        Codice = Codice.PadLeft(4, "0")
        For Each f As FiguraProduttiva In Figure
            'Globale.Log.Info(String.Format("{0}-{1}: {2}", Codice, f.Codice, f.Codice = Codice))
            If f.Codice = Codice Then
                Return f
            End If
        Next
        Return Nothing
    End Function

    Public Shared Sub EliminaFigura(Codice As String)
        For Each f As FiguraProduttiva In Figure
            If f.Codice = Codice Then
                Figure.Remove(f)
                Exit For
            End If
        Next
    End Sub

    Public Function ClausolaIN(SubAgente As Boolean, Produttore As Boolean) As String
        If mCodice = 0 Then
            Return " (1=1) "
        Else
            Dim Codici As String = CodiciFigura()
            '+creo la stringa per la query
            If SubAgente And Produttore Then
                Return String.Format(" (CodiceSubAgente IN ({0},-1) OR CodiceProduttore IN ({1},-1)) ", Codici, Codici)
            ElseIf SubAgente Then
                Return String.Format(" (CodiceSubAgente IN ({0},-1)) ", Codici)
            ElseIf Produttore Then
                Return String.Format(" (CodiceProduttore IN ({0},-1)) ", Codici)
            Else
                Return " (1=0) "
            End If
        End If
    End Function

    Public Function ClausolaINArretrati() As String
        If mCodice = 0 Then
            Return " (1=1) "
        Else
            Dim Codici As String = CodiciFigura()
            '+creo la stringa per la query
            Return String.Format(" (A.SubAgenzia IN ({0},-1) OR A.CodiceProduttore IN ({1},-1)) ", Codici, Codici)
        End If
    End Function

    Public Function CodiciFigura() As String
        Try
            If mTipo = FiguraProduttiva.TipoFigura.CIP Then
                '+cip singolo
                Return mCodice
            Else
                '+gruppo
                Dim Query As String = String.Format("SELECT Cip FROM GruppiCip WHERE Gruppo = {0}", mCodice)
                Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query)

                CodiciFigura = ""
                Do While dr.Read
                    CodiciFigura += String.Format("{0},", dr("Cip"))
                Loop
                CodiciFigura = CodiciFigura.Substring(0, CodiciFigura.Length - 1)
                dr.Close()
            End If
            Return CodiciFigura

        Catch ex As Exception
            Log.Errore(ex)
            Return " (1=1) "
        End Try
    End Function

    Public Shared Sub CancellaBudget(CodiceFigura As Integer)
        Try
            'cancella dalla tabella BudgetAnnuo il budget della figura
            '+escludere zero perchè rappresenta tutta l'agenzia
            Dim Query As String = String.Format("DELETE FROM BudgetAnnuo WHERE CodiceFigura = {0}", CodiceFigura)
            Utx.WsCommand.ExecuteNonQuery(Query)
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub
End Class
