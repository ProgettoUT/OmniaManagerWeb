
Public Class SimulatoreRappel

    Private _Anno As Integer

    Public Enum TipoComparto
        RAMI_PERSONA = 2
        RAMI_AZIENDA = 3
        RCG = 4
    End Enum

    Sub New(Anno As Integer)
        _Anno = Anno
    End Sub

    Private _IncassiPersona As Double = 0
    Public Property IncassiPersona() As Double
        Get
            Return _IncassiPersona
        End Get
        Set(value As Double)
            _IncassiPersona = value
        End Set
    End Property

    Private _IncassiAziende As Double = 0
    Public Property IncassiAziende() As Double
        Get
            Return _IncassiAziende
        End Get
        Set(value As Double)
            _IncassiAziende = value
        End Set
    End Property

    Private _IncassiRcg As Double = 0
    Public Property IncassiRcg() As Double
        Get
            Return _IncassiRcg
        End Get
        Set(value As Double)
            _IncassiRcg = value
        End Set
    End Property

    Private _IncassiPersonaPrecedenti As Double = 0
    Public Property IncassiPersonaPrecedenti() As Double
        Get
            Return _IncassiPersonaPrecedenti
        End Get
        Set(value As Double)
            _IncassiPersonaPrecedenti = value
        End Set
    End Property

    Private _IncassiAziendePrecedenti As Double = 0
    Public Property IncassiAziendePrecedenti() As Double
        Get
            Return _IncassiAziendePrecedenti
        End Get
        Set(value As Double)
            _IncassiAziendePrecedenti = value
        End Set
    End Property

    Private _BudgetPersone As Double
    Public Property BudgetPersone() As Double
        Get
            Return _BudgetPersone
        End Get
        Set(value As Double)
            _BudgetPersone = value
        End Set
    End Property

    Private _BudgetAziende As Double
    Public Property BudgetAziende() As Double
        Get
            Return _BudgetAziende
        End Get
        Set(value As Double)
            _BudgetAziende = value
        End Set
    End Property

    Private _BudgetRcg As Double
    Public Property BudgetRcg() As Double
        Get
            Return _BudgetRcg
        End Get
        Set(value As Double)
            _BudgetRcg = value
        End Set
    End Property

    Private _Codici As New List(Of String)
    Public ReadOnly Property Codici() As List(Of String)
        Get
            Return _Codici
        End Get
    End Property

    Public Sub CalcolaImporti()
        Try
            Dim sqlIncassi As String = "SELECT SUM(Tassabile) 
                FROM Incassi 
                WHERE (RamoGestione IN (SELECT RamoGestione FROM DB00000.dbo.RgToComparto 
                WHERE Comparto = {0})) AND (YEAR(DataFoglioCassa) = {1})"
            Dim sqlInfortuni As String = "SELECT SUM(PrINF) 
                FROM Incassi 
                WHERE (RamoGestione = 0) AND (YEAR(DataFoglioCassa) = {0})"
            Dim sqlBudget As String = "SELECT SUM(Importo) 
                FROM BudgetAnnuo 
                WHERE (RamoGestione IN (
                SELECT RamoGestione FROM DB00000.dbo.RgToComparto WHERE Comparto = {0})) AND (Anno = {1}) AND (CodiceFigura = 0)"

            Dim Query As String
            'inserisco dati in Incassi per ogni codice selezionato
            For Each codice As String In _Codici
                'incassi anno precedente
                Query = String.Format(sqlIncassi, Val(TipoComparto.RAMI_PERSONA), _Anno - 1)
                IncassiPersonaPrecedenti += Utx.FunzioniDb.NullToNumber(Utx.WsCommand.ExecuteScalar(Query, codice).Valore)
                Query = String.Format(sqlIncassi, Val(TipoComparto.RAMI_AZIENDA), _Anno - 1)
                IncassiAziendePrecedenti += Utx.FunzioniDb.NullToNumber(Utx.WsCommand.ExecuteScalar(Query, codice).Valore)
                'infortuni da auto da sommare a RP
                Query = String.Format(sqlInfortuni, _Anno - 1)
                IncassiPersonaPrecedenti += Utx.FunzioniDb.NullToNumber(Utx.WsCommand.ExecuteScalar(Query, codice).Valore)

                'incassi anno selezionato
                Query = String.Format(sqlIncassi, Val(TipoComparto.RAMI_PERSONA), _Anno)
                IncassiPersona += Utx.FunzioniDb.NullToNumber(Utx.WsCommand.ExecuteScalar(Query, codice).Valore)
                Query = String.Format(sqlIncassi, Val(TipoComparto.RAMI_AZIENDA), _Anno)
                IncassiAziende += Utx.FunzioniDb.NullToNumber(Utx.WsCommand.ExecuteScalar(Query, codice).Valore)
                Query = String.Format(sqlIncassi, Val(TipoComparto.RCG), _Anno)
                IncassiRcg += Utx.FunzioniDb.NullToNumber(Utx.WsCommand.ExecuteScalar(Query, codice).Valore)
                'infortuni da auto da sommare a RP
                Query = String.Format(sqlInfortuni, _Anno)
                IncassiPersona += Utx.FunzioniDb.NullToNumber(Utx.WsCommand.ExecuteScalar(Query, codice).Valore)

                'budget
                Query = String.Format(sqlBudget, Val(TipoComparto.RAMI_PERSONA), _Anno)
                BudgetPersone += Utx.FunzioniDb.NullToNumber(Utx.WsCommand.ExecuteScalar(Query, codice).Valore)
                Query = String.Format(sqlBudget, Val(TipoComparto.RAMI_AZIENDA), _Anno)
                BudgetAziende += Utx.FunzioniDb.NullToNumber(Utx.WsCommand.ExecuteScalar(Query, codice).Valore)
            Next
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub
End Class
