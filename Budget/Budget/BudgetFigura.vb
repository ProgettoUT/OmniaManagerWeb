
Public Class BudgetFigura

    Private ReadOnly mFigura As Integer
    Private ReadOnly mAnno As Integer
    Private ReadOnly mBudget As New DataTable

    Sub New(Figura As Integer, Anno As Integer)
        Try
            mFigura = Figura
            mAnno = Anno

            Dim Query As String = String.Format("SELECT * FROM BudgetAnnuo WHERE Anno = {0} AND CodiceFigura = {1}", mAnno, mFigura)
            mBudget = Utx.WsCommand.ExecuteNonQuery(Query).DataTable
            'assegno una chiave per la ricerca
            mBudget.PrimaryKey = {mBudget.Columns("RamoGestione")}
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public ReadOnly Property Anno() As Integer
        Get
            Return mAnno
        End Get
    End Property

    Public ReadOnly Property Figura() As Integer
        Get
            Return mFigura
        End Get
    End Property

    Public Property BudgetRamo(RamoGestione As Integer) As Double
        Get
            Dim dr As DataRow = mBudget.Rows.Find({RamoGestione})

            If dr IsNot Nothing Then
                Return dr("Importo")
            Else
                Return 0
            End If
        End Get
        Set(value As Double)

            Dim dr As DataRow = mBudget.Rows.Find({RamoGestione})

            If dr IsNot Nothing Then
                dr("Importo") = value
            End If
        End Set
    End Property

    Public ReadOnly Property TotaleComparto(Comparto As Utx.Enumerazioni.Comparti) As Double
        Get
            TotaleComparto = 0

            For Each row As DataRow In Globale.RgToComparto.Rows
                If row("Comparto") = Comparto Then
                    TotaleComparto += Me.BudgetRamo(row("RamoGestione"))
                End If
            Next
        End Get
    End Property

    Public ReadOnly Property TotaleSettore(Settore As Utx.Enumerazioni.Settori) As Double
        Get
            Select Case Settore
                Case Utx.Enumerazioni.Settori.AUTO
                    TotaleSettore = Me.TotaleComparto(Utx.Enumerazioni.Comparti.AUTO)

                Case Utx.Enumerazioni.Settori.RE
                    TotaleSettore = Me.TotaleComparto(Utx.Enumerazioni.Comparti.RP) +
                                    Me.TotaleComparto(Utx.Enumerazioni.Comparti.SALUTE) +
                                    Me.TotaleComparto(Utx.Enumerazioni.Comparti.AZIENDE) +
                                    Me.TotaleComparto(Utx.Enumerazioni.Comparti.RCG) +
                                    Me.TotaleComparto(Utx.Enumerazioni.Comparti.ALTRIRAMI)

                Case Utx.Enumerazioni.Settori.VITA
                    TotaleSettore = Me.TotaleComparto(Utx.Enumerazioni.Comparti.VITA)
            End Select
        End Get
    End Property

    Public ReadOnly Property TotaleAggregato(Aggregato As Utx.Enumerazioni.Aggregati) As Double
        Get
            Select Case Aggregato
                Case Utx.Enumerazioni.Aggregati.DANNI
                    TotaleAggregato = Me.TotaleSettore(Utx.Enumerazioni.Settori.AUTO) +
                                      Me.TotaleSettore(Utx.Enumerazioni.Settori.RE)

                Case Utx.Enumerazioni.Aggregati.VITA
                    TotaleAggregato = Me.TotaleSettore(Utx.Enumerazioni.Settori.VITA)
            End Select
        End Get
    End Property

    Public ReadOnly Property TotaleGenerale() As Double
        Get
            Return Me.TotaleAggregato(Utx.Enumerazioni.Aggregati.DANNI) +
                   Me.TotaleAggregato(Utx.Enumerazioni.Aggregati.VITA)
        End Get
    End Property

    Public Sub SalvaBudget()
        Try
            Dim Query As String

            If mBudget.Rows.Count = 0 Then
                Query = "UPDATE BudgetAnnuo 
                SET Importo = 0
                WHERE Anno = {0} AND CodiceFigura = {1}"

                Query = String.Format(Query, mAnno, mFigura)
            Else
                Query = "UPDATE BudgetAnnuo 
                SET Importo =
                CASE
                {0}
                END
                WHERE Anno = {1} AND CodiceFigura = {2}"

                Dim ClausolaWhen As String = ""
                For Each row As DataRow In mBudget.Rows
                    ClausolaWhen &= String.Format("WHEN RamoGestione = {0} THEN {1}",
                                              row("RamoGestione"), Utx.FunzioniDb.TO_NUMBER(row("Importo"))) & Environment.NewLine
                Next
                Query = String.Format(Query, ClausolaWhen, mAnno, mFigura)
            End If
            Utx.WsCommand.ExecuteNonQuery(Query)
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
