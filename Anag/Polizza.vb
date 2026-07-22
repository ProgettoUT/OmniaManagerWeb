Public Class Polizza

    Private mDataRowPolizza As DataRow

    Public Sub New(dataRowPolizza As DataRow)
        mDataRowPolizza = dataRowPolizza
    End Sub

    Public ReadOnly Property RamoGestione() As String
        Get
            Return GetValoreCampo("RamoGestione")
        End Get
    End Property

    Public ReadOnly Property Agenzia() As String
        Get
            Return GetValoreCampo("Agenzia")
        End Get
    End Property

    Public ReadOnly Property Ramo() As String
        Get
            Return GetValoreCampo("Ramo")
        End Get
    End Property

    Public ReadOnly Property Polizza() As String
        Get
            Return GetValoreCampo("Polizza")
        End Get
    End Property

    Public ReadOnly Property DataEffetto() As String
        Get
            Return GetValoreCampo("DataEffetto")
        End Get
    End Property

    Public ReadOnly Property DataScadenza() As String
        Get
            Return GetValoreCampo("DataScadenza")
        End Get
    End Property

    Public ReadOnly Property TotalePremioAnnuo() As String
        Get
            Return GetValoreCampo("TotalePremioAnnuo")
        End Get
    End Property

    Public ReadOnly Property Frazionamento() As String
        Get
            Return GetValoreCampo("Frazionamento")
        End Get
    End Property

    Public ReadOnly Property CodiceProdotto() As String
        Get
            Return GetValoreCampo("CodiceProdotto")
        End Get
    End Property

    Public ReadOnly Property Convenzione() As String
        Get
            Return GetValoreCampo("Convenzione")
        End Get
    End Property

    Public ReadOnly Property CodiceSubAgente() As String
        Get
            Return GetValoreCampo("CodiceSubAgente")
        End Get
    End Property

    Public Class Decodifiche

    End Class


    Public Shared Function GetSqlPolizzePerCodiceFiscale(codiceFiscale As String) As String

        Dim sql As New System.Text.StringBuilder
        sql.Append("SELECT")
        sql.Append("   CM.descrizione as Comparto")
        sql.Append(" , P.RamoGestione as [RG]")
        sql.Append(" , Agenzia")
        sql.Append(" , Ramo")
        sql.Append(" , Polizza")
        sql.Append(" , DataEffetto as [Effetto]")
        sql.Append(" , DataScadenza as [Scadenza]")
        sql.Append(" , TotalePremioAnnuo as [Tassabile]")
        sql.Append(" , Frazionamento as [FR]")
        sql.Append(" , CodiceProdotto as [Prodotto]")
        sql.Append(" , Convenzione as [Convenzione]")
        sql.Append(" , CodiceSubAgente as [Sub]")
        sql.Append(" , Targa")
        sql.Append(" , ClasseRca") 'introdotto il 30-11-16 per le visure
        sql.Append(" FROM ((Polizze P")
        sql.Append(" LEFT JOIN RgToComparto RC ON P.RamoGestione = RC.RamoGestione)")
        sql.Append(" LEFT JOIN Comparto CM ON RC.Comparto = CM.Codice)")
        sql.AppendFormat(" WHERE codicefiscale ={0}", Utx.FunzioniDb.TO_STRING(codiceFiscale))
        sql.Append(" ORDER BY 1, 2")

        Return sql.ToString
    End Function

    Public Shared Function GetSqlStoricoPolizzePerCodiceFiscale(codiceFiscale As String) As String
        Return String.Format("SELECT CM.Descrizione AS Comparto
            , P.RamoGestione as [RG]
            , Agenzia
            , Ramo
            , Polizza
            , DataEffetto AS [Effetto]
            , DataScadenza AS [Scadenza]
            , TotalePremioAnnuo AS [Tassabile]
            , Frazionamento AS [FR]
            , CodiceProdotto AS [Prodotto]
            , Convenzione AS [Convenzione]
            , CodiceSubAgente AS [Sub]
            , Targa
            , ClasseRca
            FROM ((MovPolizze P
            INNER JOIN RgToComparto RC ON P.RamoGestione = RC.RamoGestione)
            INNER JOIN Comparto CM ON RC.Comparto = CM.Codice)
            WHERE codicefiscale = '{0}'
            ORDER BY 1, 2", codiceFiscale)
    End Function

    Private Function GetValoreCampo(ByRef NomeCampo As String) As String
        Return Utx.FunzioniDb.NullToValue(mDataRowPolizza(NomeCampo))
    End Function
End Class
