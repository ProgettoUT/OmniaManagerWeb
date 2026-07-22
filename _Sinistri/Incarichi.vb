Public Class Incarichi

    Private _Incarichi As DataTable
    Private ReadOnly _Compagnia As Integer
    Private ReadOnly _AgenziaSinistro As Integer
    Private ReadOnly _EsercizioSinistro As Integer
    Private ReadOnly _NumeroSinistro As Integer

    Sub New(Compagnia As Integer, Ente As Integer, Esercizio As Integer, Numero As Integer)
        _Compagnia = Compagnia
        _AgenziaSinistro = Ente
        _EsercizioSinistro = Esercizio
        _NumeroSinistro = Numero

        LeggiIncarichi()
    End Sub

    Public ReadOnly Property ListaPeriti(CodicePeritoInSinistro As String) As List(Of String)
        Get
            Dim Lista As New List(Of String)
            'aggiungo il codice principale presente nel record sinistro
            If String.IsNullOrEmpty(CodicePeritoInSinistro.Trim) = False Then
                Lista.Add(CodicePeritoInSinistro)
            End If

            'ora i codici negli incarichi
            Dim Codice As String

            For Each dr As DataRow In _Incarichi.Rows

                Codice = dr("CodicePeritoSAP").ToString.Trim

                If String.IsNullOrEmpty(Codice) = False Then

                    If Lista.Contains(Codice) = False Then
                        Lista.Add(Codice)
                    End If
                End If
            Next

            Return Lista
        End Get
    End Property

    Public Sub LeggiIncarichi()
        Try
            Dim Query As String = String.Format("SELECT * FROM SIncarichi 
                WHERE AgenziaSinistro = {0} AND EsercizioSinistro = {1} AND NumeroSinistro = {2}",
                                                _AgenziaSinistro, _EsercizioSinistro, _NumeroSinistro)
            _Incarichi = Utx.WsCommand.ExecuteNonQuery(Query).DataTable
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
