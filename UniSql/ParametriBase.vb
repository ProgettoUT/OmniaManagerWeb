Public Class ParametriBase
    Public Shared ParametriBase As DataSet
    Public Shared ThParametri As Threading.Thread

    Public Shared Sub LeggiParametriBase()
        If ParametriBase Is Nothing Then
            ThParametri = New Threading.Thread(Sub()
                                                   Try
                                                       ParametriBase = Utx.WsCommand.ExecuteNonQuery(
            {QuerySubagente(), QueryProduttore(), QueryProdotto(), QueryConvenzione(), QueryRamo(), QueryStatoCliente(), QueryStorno(), QueryPrivacy()},
            {"subagenzia", "produttore", "prodotto", "convenzione", "ramo", "statocliente", "storno", "privacy"}).DataSet
                                                       'creo la tabella cip=sub+prod
                                                       ParametriBase.Tables.Add("cip")
                                                       ParametriBase.Tables("cip").Merge(ParametriBase.Tables("subagenzia"))
                                                       ParametriBase.Tables("cip").Merge(ParametriBase.Tables("produttore"))
                                                   Catch ex As Exception
                                                       Utx.Globale.Log.Info("Impossibile inizializzare l'estrattore dati.")
                                                   End Try
                                               End Sub)
            ThParametri.Start()
        End If
    End Sub

    Private Shared Function QuerySubagente() As String
        Return "SELECT -1, 'TUTTI' 
			UNION 
            SELECT CodiceSubAgente, format(CodiceSubAgente,'000') + ' - ' + 
			CASE WHEN F.FiguraProduttiva IS NULL THEN '' ELSE F.FiguraProduttiva END
			FROM Polizze AS P WITH (NOLOCK)
			LEFT JOIN FigureProduttive AS F WITH (NOLOCK) ON F.IDFiguraProduttiva = P.CodiceSubAgente  
		    WHERE NOT (P.CodiceSubAgente IS NULL) AND P.CodiceSubAgente < 1000
			GROUP BY P.CodiceSubAgente,F.FiguraProduttiva
			ORDER BY 1"
    End Function
    Private Shared Function QueryProduttore() As String
        Return "SELECT -1, 'TUTTI' 
			UNION 
			SELECT P.CodiceProduttore, FORMAT(P.CodiceProduttore,'0000') + ' - ' + 
    		CASE WHEN F.FiguraProduttiva IS NULL THEN '' ELSE F.FiguraProduttiva END
            FROM Polizze AS P WITH (NOLOCK)
			LEFT JOIN FigureProduttive AS F WITH (NOLOCK) ON F.IDFiguraProduttiva = P.CodiceProduttore  
		    WHERE NOT (P.CodiceProduttore IS NULL) AND P.CodiceProduttore >= 1000
			GROUP BY P.CodiceProduttore,F.FiguraProduttiva
			ORDER BY 1"
    End Function
    Private Shared Function QueryProdotto() As String
        Return "SELECT '#', 'TUTTI'
			UNION 
            SELECT A.CodiceProdotto, A.CodiceProdotto + ' - ' + 
			CASE WHEN B.Prodotto  IS NULL THEN '' ELSE B.Prodotto END
			FROM Polizze AS A WITH (NOLOCK)
			LEFT JOIN DB00000.dbo.Prodotti B ON A.CodiceProdotto = B.CodiceProdotto
			GROUP BY A.CodiceProdotto,B.Prodotto
			ORDER BY 1"
    End Function
    Private Shared Function QueryConvenzione() As String
        Return "SELECT '#', 'TUTTI' 
	    	UNION 
            SELECT FORMAT(cast(Convenzione AS int),'00000'), FORMAT(cast(Convenzione AS int),'00000') + ' - ' + ISNULL(C.Desk,'')
	    	FROM Incassi AS I WITH (NOLOCK)
			left join DB00000.dbo.Convenzioni AS C ON I.Convenzione = C.Codice
			GROUP BY Convenzione,C.Desk
	    	ORDER BY 1"
    End Function
    Private Shared Function QueryRamo() As String
        Return "SELECT -1, 'TUTTI' 
			UNION 
            SELECT I.Ramo, FORMAT(I.Ramo,'000') + ' - ' + 
			CASE WHEN TR.Ramo IS NULL THEN '' ELSE TR.Ramo
			END
			FROM Incassi I WITH (NOLOCK)
			LEFT JOIN DB00000.dbo.TipoRami AS TR ON (I.ramo=TR.CodiceRamo)
			GROUP BY I.Ramo,TR.Ramo
			ORDER BY 1"
    End Function
    Private Shared Function QueryStatoCliente() As String
        Return "SELECT '#', 'TUTTI' 
            UNION 
            SELECT IDStatoCliente, StatoCliente
            FROM DB00000.dbo.TipoStatiCliente WITH (NOLOCK)"
    End Function
    Private Shared Function QueryStorno() As String
        Return "SELECT '#', 'TUTTI I CODICI STORNO' 
			UNION 
            SELECT MP.IDStorno, MP.IDStorno + ' - ' + 
			CASE WHEN TS.Storno IS NULL THEN '' 
            ELSE TRIM(TS.Storno)
			END + 
            ' (' + 
            CASE WHEN TS.Settore = 'D' THEN 'Danni' 
            ELSE 'Vita'
			END + 
            ')'
			FROM MovPolizze AS MP WITH (NOLOCK)
			LEFT JOIN DB00000.dbo.TipoStorni AS TS WITH (NOLOCK) ON MP.IDStorno = TS.IDStorno
            WHERE LEN(TRIM(MP.IDStorno)) > 0
            GROUP BY MP.IDStorno,TS.Storno,TS.Settore
			ORDER BY 1"
    End Function

    Private Shared Function QueryPrivacy() As String
        Return "SELECT '#', 'TUTTI'
	    	UNION 
            SELECT ConsensoPrivacy, ConsensoPrivacy
	    	FROM Clienti WITH (NOLOCK)
			WHERE ConsensoPrivacy IS NOT NULL AND Trim(ConsensoPrivacy) <> ''
			GROUP BY ConsensoPrivacy
	    	ORDER BY 1"
    End Function
End Class
