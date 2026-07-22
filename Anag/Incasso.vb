Public Class Incasso
    Public Shared Function GetSqlIncassoPerPolizza(agenzia As Integer, ramo As Integer, polizza As Integer) As String

        Dim sql As New System.Text.StringBuilder
        sql.Append("SELECT")
        sql.Append("   Agenzia")
        sql.Append(" , Ramo")
        sql.Append(" , Polizza")
        sql.Append(" , DataEffettoTitolo as [Effetto]")
        sql.Append(" , Esito")
        sql.Append(" , DataFoglioCassa")
        sql.Append(" , Totaletitolo      as [Totale Titolo]")
        sql.Append(" , PrvAcq + PrvInc   as [Totale Provviggioni]")
        sql.Append(" FROM Incassi")
        sql.AppendFormat(" WHERE Agenzia = {0}", Utx.FunzioniDb.TO_NUMBER(agenzia))
        sql.AppendFormat("   AND Ramo = {0}", Utx.FunzioniDb.TO_NUMBER(ramo))
        sql.AppendFormat("   AND Polizza = {0}", Utx.FunzioniDb.TO_NUMBER(polizza))
        sql.Append(" UNION SELECT")
        sql.Append("   I.Agenzia")
        sql.Append(" , I.Ramo")
        sql.Append(" , I.Polizza")
        sql.Append(" , I.DataEffettoTitolo")
        sql.Append(" , I.Esito")
        sql.Append(" , I.DataFoglioCassa")
        sql.Append(" , I.Totaletitolo")
        sql.Append(" , I.PrvAcq + I.PrvInc")
        sql.Append(" FROM Incassi I")
        sql.Append(" INNER JOIN MOVPOLIZZE M ON I.AGENZIA = M.Agenzia AND I.Ramo = M.Ramo AND I.Polizza = M.Polizza")
        sql.AppendFormat(" WHERE M.AgenziaSost = {0}", Utx.FunzioniDb.TO_NUMBER(agenzia))
        sql.AppendFormat("   AND M.RamoSost = {0}", Utx.FunzioniDb.TO_NUMBER(ramo))
        sql.AppendFormat("   AND M.PolizzaSost = {0}", Utx.FunzioniDb.TO_NUMBER(polizza))
        sql.Append(" ORDER BY 6 DESC, 4 DESC")

        Return sql.ToString
    End Function

    Public Shared Function GetSqlIncassoPerCodiceFiscale(CodiceFiscale As String) As String

        Dim sql As New System.Text.StringBuilder
        sql.Append("SELECT")
        sql.Append("   Agenzia")
        sql.Append(" , Ramo")
        sql.Append(" , Polizza")
        sql.Append(" , DataEffettoTitolo as [Effetto]")
        sql.Append(" , Esito")
        sql.Append(" , DataFoglioCassa")
        sql.Append(" , Totaletitolo      as [Totale Titolo]")
        sql.Append(" , PrvAcq + PrvInc   as [Totale Provviggioni]")
        sql.Append(" FROM Incassi")
        sql.AppendFormat(" WHERE CodiceFiscInc = {0}", Utx.FunzioniDb.TO_STRING(CodiceFiscale))
        sql.Append(" ORDER BY DataFoglioCassa DESC")

        Return sql.ToString
    End Function
End Class
