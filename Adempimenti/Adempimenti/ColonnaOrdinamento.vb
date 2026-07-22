<Serializable> Public Class ColonnaOrdinamento

    Public Enum TipoOrdinamento
        CRESCENTE = 0
        DECRESCENTE = 1
    End Enum

    Sub New()
    End Sub

    Sub New(ByRef Colonna As DataGridViewColumn,
            Tipo As TipoOrdinamento)

        mNome = Colonna.Name
        mTitolo = Colonna.HeaderText
        mOrdinamento = Tipo
    End Sub

    Sub New(NomeColonna As String,
            TitoloColonna As String,
            Tipo As TipoOrdinamento)

        mNome = NomeColonna
        mTitolo = TitoloColonna
        mOrdinamento = Tipo
    End Sub

    Private mOrdinamento As TipoOrdinamento
    Public Property Ordinamento() As TipoOrdinamento
        Get
            Return mOrdinamento
        End Get
        Set(value As TipoOrdinamento)
            mOrdinamento = value
        End Set
    End Property

    Private mNome As String
    Public Property Nome() As String
        Get
            Return mNome
        End Get
        Set(value As String)
            mNome = value
        End Set
    End Property

    Private mTitolo As String
    Public Property Titolo() As String
        Get
            Return mTitolo
        End Get
        Set(value As String)
            mTitolo = value
        End Set
    End Property

    Public ReadOnly Property Descrizione() As String
        Get
            Return String.Format("{0} ({1})", mTitolo, mOrdinamento.ToString)
        End Get
    End Property

    Private Shared Function SqlTypeOrder(Tipo As TipoOrdinamento) As String

        If Tipo = TipoOrdinamento.DECRESCENTE Then
            Return "DESC"
        Else
            Return "ASC"
        End If
    End Function

    Private Function SQL(Tipo As TipoOrdinamento) As String
        Return String.Format("{0} {1}", Nome, SqlTypeOrder(Tipo))
    End Function

    Public Shared Function ClausolaOrder(ByRef ListaColonne As List(Of ColonnaOrdinamento)) As String

        ClausolaOrder = ""

        For Each c As ColonnaOrdinamento In ListaColonne
            ClausolaOrder = String.Format("{0}, {1} {2}", ClausolaOrder, c.Nome, SqlTypeOrder(c.Ordinamento))
        Next

        'tolgo la virgola nella posizione 0 e aggiungo uno spazio alla fine
        Return ClausolaOrder.Substring(1) + Space(1)
    End Function
End Class
