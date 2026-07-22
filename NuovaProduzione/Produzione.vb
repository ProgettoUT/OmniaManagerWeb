Imports NuovaProduzione.Pdf

Module Produzione

    Private Function GeneraReportProduzione(dataDal As Date,
                                            dataAl As Date,
                                            precedenteDal As Date,
                                            precedenteAl As Date,
                                            confrontaAnnoPrecedente As Boolean,
                                            subagenti() As String,
                                            produttori() As String,
                                            ramiGestione() As String,
                                            escludiSostituzioniAuto As Boolean,
                                            includiRegolazione As Boolean,
                                            prodotti() As String,
                                            escludiProdotti As Boolean,
                                            convenzioni() As String,
                                            escludiConvenzioni As Boolean) As String

        Dim Query As New Utx.NetFunc.StringFormatter
        Query.Template = "SELECT 
            GR.Settore AS L1,
            CHOOSE(GR.Settore,'Rami Auto','Rami Elementari','Rami Vita') AS D1,
            GR.Comparto AS L2,
            CM.Descrizione AS D2,
            FORMAT(IC.RamoGestione,'00') AS [L3],
            RG.DescRamoGest AS [D3],
            SUM(IIF(IC.DataFoglioCassa = MinDataFoglioCassa AND IC.Polizza = MinPolizza AND C.DataInserimento BETWEEN @inizio AND @fine,1,0)) AS CC,
            SUM(IIF(IC.TipoCarico IN ('0','1','5') AND IC.DataFoglioCassa BETWEEN @inizio AND @fine,1,0)) AS PC,
            SUM(IIF((IC.TipoCarico = '2' OR IC.TipoCarico = '3' OR IC.TipoCarico = '6') AND IC.DataFoglioCassa BETWEEN @inizio AND @fine,1,0)) AS SC,
            SUM(IIF(IC.TipoCarico='9' AND IC.DataFoglioCassa BETWEEN @inizio AND @fine,1,0)) AS AC,
            SUM(IIF(IC.DataFoglioCassa BETWEEN @inizio AND @fine,1,0)) AS TC,
            SUM(IIF(IC.DataFoglioCassa BETWEEN @inizio AND @fine,1,0) * IncrProduzione) AS IC,
            SUM(IIF(IC.DataFoglioCassa = MinDataFoglioCassa AND IC.Polizza = MinPolizza AND C.DataInserimento BETWEEN @precinizio AND @precfine,1,0)) AS CP,
            SUM(IIF(IC.TipoCarico IN ('0','1','5') AND IC.DataFoglioCassa BETWEEN @precinizio AND @precfine,1,0)) AS PP,
            SUM(IIF((IC.TipoCarico = '2' OR IC.TipoCarico = '3' OR IC.TipoCarico = '6') AND IC.DataFoglioCassa BETWEEN @precinizio AND @precfine,1,0)) AS SP,
            SUM(IIF(IC.TipoCarico='9' AND IC.DataFoglioCassa BETWEEN @precinizio AND @precfine,1,0)) AS AP,
            SUM(IIF(IC.DataFoglioCassa BETWEEN @precinizio AND @precfine,1,0)) AS TP,
            SUM(IIF(IC.DataFoglioCassa BETWEEN @precinizio AND @precfine,1,0) * IC.IncrProduzione) AS IP
            FROM [Incassi] AS IC
            LEFT JOIN [RgToComparto] AS GR ON IC.RamoGestione = GR.RamoGestione
            LEFT JOIN [Comparto] AS CM ON GR.Comparto = CM.Codice
            LEFT JOIN [Clienti] AS C ON IC.CodiceFiscInc = C.CodiceFiscale
            LEFT JOIN (SELECT CodiceFiscInc, min(Polizza) AS MinPolizza, Min(DataFoglioCassa) AS MinDataFoglioCassa
                        FROM Incassi
                        GROUP BY CodiceFiscInc) AS I0 ON IC.CodiceFiscInc = I0.CodiceFiscInc
            LEFT JOIN [MovPolizze] AS MP ON IC.Agenzia = MP.AgenziaSost AND IC.Polizza = MP.PolizzaSost AND IC.Ramo = MP.RamoSost AND IC.DataEffettoTitolo = MP.DataStorno
            LEFT JOIN  [MovPolizze] AS MP2 ON IC.Agenzia = MP2.Agenzia AND IC.Polizza = MP2.Polizza AND IC.Ramo = MP2.Ramo
            LEFT JOIN [RamoGest] AS RG ON IC.RamoGestione = RG.RamoGestione
            WHERE (
                (IC.TipoCarico = '0' AND IC.RamoGestione IN (18, 19, 20)) OR
                (IC.TipoCarico = '1' AND IC.RamoGestione IN (1, 2) AND (IC.Targa is null OR trim(IC.Targa) = '' OR 
                    (SELECT COUNT(*) FROM Incassi AS I WHERE I.Targa = IC.Targa AND I.DataFoglioCassa < IC.DataFoglioCassa) = 0)) OR
                (IC.TipoCarico = '1' AND IC.RamoGestione NOT IN (1, 2)) OR 
                (IC.TipoCarico = '2') OR 
                (IC.TipoCarico = '3' AND IC.RamoGestione NOT IN (8, 13, 14, 15) AND IC.Tassabile <> 0 ) OR 
                (IC.TipoCarico = '5') OR 
                (IC.TipoCarico = '9' AND (MP.IDStorno IS NULL OR MP.IDStorno NOT IN ('AG','AH', 'AO', 'A1', 'A7', 'A8', 'M', 'O'))))"
        If includiRegolazione Then
            Query.AddToTemplate(" OR (IC.TipoCarico = '6')")
        End If
        ' filtro Periodo
        If confrontaAnnoPrecedente = False Then
            Query.AddToTemplate(" AND IC.DataFoglioCassa BETWEEN @inizio AND @fine
                AND (IC.RamoGestione NOT IN (18, 19, 20) OR (IC.DataEffettoTitolo BETWEEN @inizio AND @fine
                AND IC.DataEffettoAppendice BETWEEN @inizio AND @fine))")
        Else
            Query.AddToTemplate(" AND ((IC.DataFoglioCassa BETWEEN @inizio AND @fine
                AND (IC.RamoGestione NOT IN (18, 19, 20) OR (IC.DataEffettoTitolo BETWEEN @inizio AND @fine
                AND IC.DataEffettoAppendice BETWEEN @inizio AND @fine))) OR 
                (IC.DataFoglioCassa BETWEEN @precinizio AND @precfine AND 
                (IC.RamoGestione NOT IN (18, 19, 20) OR (IC.DataEffettoTitolo BETWEEN @precinizio AND @precfine
                AND IC.DataEffettoAppendice BETWEEN @precinizio AND @precfine))))")
        End If

        Dim sSql As String
        If IsNotEmpty(subagenti) Or IsNotEmpty(produttori) Then
            ' filtro subagenti

            sSql = " AND ("
            If IsNotEmpty(subagenti) Then
                sSql &= "IC.CodiceSubAgente IN (" & subagenti(0)
                For i = 1 To UBound(subagenti)
                    sSql &= "," & subagenti(i)
                Next
                sSql &= ")"
            End If

            If IsNotEmpty(subagenti) And IsNotEmpty(produttori) Then
                sSql &= " OR "
            End If

            ' filtro produttori
            If IsNotEmpty(produttori) Then
                sSql &= "IC.CodiceProduttore IN (" & produttori(0)
                For i = 1 To UBound(produttori)
                    sSql &= "," & produttori(i)
                Next
                sSql &= ")"
            End If
            sSql &= ")"
            Query.AddToTemplate(sSql)
        End If

        ' filtro ramo Gestione
        If IsNotEmpty(ramiGestione) Then
            sSql = " AND IC.RamoGestione IN (" & ramiGestione(0)
            For i = 1 To UBound(ramiGestione)
                sSql &= "," & ramiGestione(i)
            Next
            sSql &= ")"
            Query.AddToTemplate(sSql)
        End If

        ' filtro Prodotti
        If IsNotEmpty(prodotti) Then
            sSql = " AND CAST(IC.CodiceProdotto AS int) " & IIf(escludiProdotti, "NOT ", "") & "IN (" & prodotti(0).Trim
            For i = 1 To UBound(prodotti)
                sSql &= ", " & prodotti(i).Trim
            Next
            sSql &= ")"
            Query.AddToTemplate(sSql)
        End If

        ' filtro Convenzioni escludiConvenzioni
        If IsNotEmpty(convenzioni) Then
            sSql = " AND CAST(IC.Convenzione AS int) " & IIf(escludiConvenzioni, "NOT ", "") & "IN (" & convenzioni(0).Trim
            For i = 1 To UBound(convenzioni)
                sSql &= "," & convenzioni(i).Trim
            Next
            sSql &= ")"
            Query.AddToTemplate(sSql)
        End If

        ' filtro Sostituzioni
        If escludiSostituzioniAuto = True Then
            sSql = " AND NOT(IC.RamoGestione IN (1, 2) AND IC.TipoCarico IN('2', '3'))"
            Query.AddToTemplate(sSql)
        End If
        sSql = " GROUP BY
            GR.Settore, CHOOSE(GR.Settore, 'Rami Auto', 'Rami Elementari', 'Rami Vita'), GR.Comparto, CM.Descrizione, FORMAT(IC.RamoGestione,  '00'), RG.DescRamoGest
            ORDER BY 1, 3, 5"
        Query.AddToTemplate(sSql)
        'parametri
        With Query
            .Parametro("@inizio", Format(dataDal, "dd/MM/yyyy"), True)
            .Parametro("@fine", Format(dataAl, "dd/MM/yyyy"), True)
            .Parametro("@precinizio", Format(precedenteDal, "dd/MM/yyyy"), True)
            .Parametro("@precfine", Format(precedenteAl, "dd/MM/yyyy"), True)
        End With

        Return Query.StringaFormattata
    End Function


    Public Function GeneraDettaglioProduzione(dataDal As Date,
                                              dataAl As Date,
                                              subagenti() As String,
                                              produttori() As String,
                                              ramiGestione() As String,
                                              escludiSostituzioniAuto As Boolean,
                                              includiRegolazione As Boolean,
                                              prodotti() As String,
                                              escludiProdotti As Boolean,
                                              convenzioni() As String,
                                              escludiConvenzioni As Boolean) As String

        Dim Query As New Utx.NetFunc.StringFormatter
        Query.Template = "SELECT 
            IC.Agenzia                        AS [Agenzia],
            IC.CodiceFiscInc                  AS [Codice fiscale],
            Trim(IC.Contraente)               AS [Nominativo],
            IIF((IC.DataFoglioCassa = MinDataFoglioCassa AND IC.Polizza = MinPolizza AND C.DataInserimento BETWEEN @inizio AND @fine),'S', 'N') AS [Nuovo Cliente],
            C.DataInserimento                 AS [Cliente dal],
            IC.CodiceSubAgente                AS [Sub agente],
            IC.CodiceProduttore               AS [Produttore],
            IC.Polizza                        AS [Polizza],
            IC.Frazionamento                  AS [Fraz],
            IC.DataFoglioCassa                AS [Foglio cassa],
            IC.DataEffettoTitolo              AS [Effetto titolo],
            IC.DataScadenzaTitolo             AS [Scadenza titolo],
            FORMAT(CAST(IC.Convenzione as int),'00000') AS [Convenzione],
            FORMAT(CAST(IC.Ramo as int),'000') AS [Ramo],
            TR1.Ramo                          AS [Ramo des],
            FORMAT(CAST(IC.CodiceProdotto as int),'00000') AS [Prodotto],
            PR2.Prodotto                      AS [Prodotto des],
            FORMAT(CAST(IC.RamoGestione as int), '00') AS [Ramo Gestione],
            RG.DescRamoGest                   AS [Ramo Gestione Des],
            IIF(IC.TipoCarico='9',MP2.IDStorno,MP.IDStorno) AS [Cod storno],
            IIF(IC.TipoCarico='9',TS2.Storno,TS.Storno) AS [Storno],
            IIF(IC.TipoCarico='9',MP2.DataStorno,MP.DataStorno) AS [Data Storno],
            MP.Agenzia                        AS [Agenzia old],
            FORMAT(CAST(MP.Ramo as int), '000') AS [Ramo old],
            TR.Ramo                           AS [Ramo Des old],
            MP.Polizza                        AS [Polizza old],
            Format(cast(MP.CodiceProdotto as int),'00000') AS [Prodotto old],
            PR1.Prodotto                      AS [Prodotto des old],
            IC.TipoCarico                     AS [Carico incassi],
            CASE
			    WHEN IC.TipoCarico='0' THEN 'Emissione copertura provvisoria'
                WHEN IC.TipoCarico='1' THEN 'Nuova emissione'
                WHEN IC.TipoCarico='2' THEN 'Sostituzione'
                WHEN IC.TipoCarico='3' THEN 'Variazione'
                WHEN IC.TipoCarico='4' THEN 'Quietanza'
                WHEN IC.TipoCarico='5' THEN 'Premio unico'
                WHEN IC.TipoCarico='6' THEN 'Regolazione premio'
                WHEN IC.TipoCarico='8' THEN 'Incasso di Penale'
                WHEN IC.TipoCarico='9' THEN 'Rimborso di premio e/o provvigioni'
			END 
			AS [Carico incassi des],
            IC.Tassabile AS [Imponibile (I)],
            IIF(MP.TotalePremioAnnuo IS NOT NULL,MP.TotalePremioAnnuo,MP2.TotalePremioAnnuo) AS [Premio annuo old (MP)],
            IncrProduzione AS Produzione
            FROM Incassi AS IC
            LEFT JOIN [Clienti] AS C ON IC.CodiceFiscInc = C.CodiceFiscale
            LEFT JOIN (SELECT CodiceFiscInc, MIN(Polizza) AS MinPolizza, Min(DataFoglioCassa) AS MinDataFoglioCassa
                        FROM Incassi
                        GROUP BY CodiceFiscInc) AS I0 ON IC.CodiceFiscInc = I0.CodiceFiscInc
            LEFT JOIN [MovPolizze] AS MP ON IC.Agenzia = MP.AgenziaSost
                                         AND IC.Polizza = MP.PolizzaSost
                                         AND IC.Ramo    = MP.RamoSost
                                         AND IC.DataEffettoTitolo=MP.DataStorno
            LEFT JOIN  [MovPolizze] AS MP2 ON IC.Agenzia = MP2.Agenzia
                                         AND IC.Polizza = MP2.Polizza
                                         AND IC.Ramo    = MP2.Ramo
            LEFT JOIN [TipoStorni] AS TS ON MP.IDStorno = TS.IDStorno
            LEFT JOIN [TipoStorni] AS TS2 ON MP2.IDStorno = TS2.IDStorno
            LEFT JOIN [TipoRami] AS TR ON MP.Ramo = TR.CodiceRamo
            LEFT JOIN [TipoRami] AS TR1 ON IC.Ramo = TR1.CodiceRamo
            LEFT JOIN [RamoGest] AS RG ON IC.RamoGestione = RG.RamoGestione
            LEFT JOIN [Prodotti] AS PR1 ON MP.CodiceProdotto = PR1.CodiceProdotto
            LEFT JOIN [Prodotti] AS PR2 ON IC.CodiceProdotto = PR2.CodiceProdotto
            WHERE (
                (IC.TipoCarico = '0' AND IC.RamoGestione IN (18, 19, 20)) OR
                (IC.TipoCarico = '1' AND IC.RamoGestione IN (1, 2) AND (IC.Targa IS NULL OR TRIM(IC.Targa)='' OR 
                    (SELECT COUNT(*) FROM Incassi AS I WHERE I.Targa = IC.Targa AND I.DataFoglioCassa < IC.DataFoglioCassa) = 0)) OR
                (IC.TipoCarico = '1' AND IC.RamoGestione NOT IN (1, 2)) OR
                (IC.TipoCarico = '2') OR
                (IC.TipoCarico = '3' AND IC.RamoGestione NOT IN (8, 13, 14, 15) AND IC.Tassabile <> 0 ) OR
                (IC.TipoCarico = '5') OR 
                (IC.TipoCarico = '9' AND (MP.IDStorno IS NULL OR MP.IDStorno NOT IN ('AG','AH', 'AO', 'A1', 'A7', 'A8', 'M', 'O')))"
        If includiRegolazione Then
            Query.AddToTemplate("   OR (IC.TipoCarico = '6')")
        End If
        Query.AddToTemplate(")")

        ' filtro Periodo
        Query.AddToTemplate(" AND IC.DataFoglioCassa BETWEEN @inizio AND @fine AND 
            (IC.RamoGestione NOT IN (18, 19, 20) OR (IC.DataEffettoTitolo BETWEEN @inizio AND @fine AND 
            IC.DataEffettoAppendice BETWEEN @inizio AND @fine))")

        Dim sSql As String

        If IsNotEmpty(subagenti) Or IsNotEmpty(produttori) Then
            sSql = " AND ("
            ' filtro subagenti
            If IsNotEmpty(subagenti) Then
                sSql &= "IC.CodiceSubAgente IN (" & subagenti(0)
                For i = 1 To UBound(subagenti)
                    sSql &= "," & subagenti(i)
                Next
                sSql &= ")"
            End If

            If IsNotEmpty(subagenti) And IsNotEmpty(produttori) Then
                sSql &= " OR "
            End If

            ' filtro produttori
            If IsNotEmpty(produttori) Then
                sSql &= "IC.CodiceProduttore IN (" & produttori(0)
                For i = 1 To UBound(produttori)
                    sSql &= "," & produttori(i)
                Next
                sSql &= ")"
            End If
            sSql &= ")"
            Query.AddToTemplate(sSql)
        End If

        ' filtro ramo Gestione
        If IsNotEmpty(ramiGestione) Then
            sSql = " AND IC.RamoGestione IN (" & ramiGestione(0)
            For i = 1 To UBound(ramiGestione)
                sSql &= "," & ramiGestione(i)
            Next
            sSql &= ")"
            Query.AddToTemplate(sSql)
        End If

        ' filtro Prodotti
        If IsNotEmpty(prodotti) Then
            sSql = " AND CAST(IC.CodiceProdotto AS BIGINT) " & IIf(escludiProdotti, "NOT ", "") & "IN (" & prodotti(0).Trim
            For i = 1 To UBound(prodotti)
                sSql &= ", " & prodotti(i).Trim
            Next
            sSql &= ")"
            Query.AddToTemplate(sSql)
        End If

        ' filtro Convenzioni escludiConvenzioni
        If IsNotEmpty(convenzioni) Then
            sSql = " AND CAST(IC.Convenzione AS BIGINT) " & IIf(escludiConvenzioni, "NOT ", "") & "IN (" & convenzioni(0).Trim
            For i = 1 To UBound(convenzioni)
                sSql &= "," & convenzioni(i).Trim
            Next
            sSql &= ")"
            Query.AddToTemplate(sSql)
        End If

        ' filtro Sostituzioni
        If escludiSostituzioniAuto = True Then
            sSql = " AND NOT(IC.RamoGestione IN (1, 2) AND IC.TipoCarico IN('2', '3'))"
            Query.AddToTemplate(sSql)
        End If

        Query.AddToTemplate(" ORDER BY 6")

        'parametri
        With Query
            .Parametro("@inizio", Format(dataDal, "dd/MM/yyyy"), True)
            .Parametro("@fine", Format(dataAl, "dd/MM/yyyy"), True)
        End With

        Return Query.StringaFormattata
    End Function

    Public Function CreaReport(dataDal As Date,
                               dataAl As Date,
                               confrontaAnnoPrecedente As Boolean,
                               subagenti() As String,
                               produttori() As String,
                               ramiGestione() As String,
                               escludiSostituzioniAuto As Boolean,
                               includiRegolazione As Boolean,
                               prodotti() As String,
                               escludiProdotti As Boolean,
                               convenzioni() As String,
                               escludiConvenzioni As Boolean,
                               WithBackColor As Boolean) As String

        Dim precedenteDal As Date
        Dim precedenteAl As Date
        precedenteDal = DateAdd("M", -12, dataDal)
        precedenteAl = DateAdd("M", -12, dataAl)

        Dim rs As DataTableReader
        Dim clPDF As New Pdf
        Dim strFile As String

        'Const Fnt1 = "Fnt1"
        Const Fnt2 = "Fnt2"
        Const Fnt3 = "Fnt3"
        'Const Fh10 = 10

        Dim ColTab(17) As Single
        ColTab(0) = IIf(confrontaAnnoPrecedente, 90, 260)
        ColTab(1) = 120
        ColTab(6) = 50
        ColTab(11) = 50
        ColTab(14) = 50

        Dim RowTab(100) As Single
        RowTab(0) = 535 '595.2
        RowTab(1) = 30
        RowTab(2) = 30

        'riga inizio tabella
        Const Row0 = 3

        ' Imposta il file di output
        If System.IO.Directory.Exists(Utx.Globale.Paths.CartellaTempUtente) Then
            strFile = System.IO.Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "report." & Now.Ticks & ".pdf")
        Else
            strFile = System.IO.Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "report." & Now.Ticks & ".pdf")
        End If

        CreaReport = strFile

        If Dir(strFile) <> vbNullString Then
            Kill(strFile)
        End If

        With clPDF
            .SetRowTab(RowTab)
            .SetColTab(ColTab)

            .Title = "Produzione"               ' Titolo
            .ScaleMode = Pdf.pdfScaleMode.pdf72PxInch            ' Unità di misura
            .PaperSize = Pdf.pdfPaperSize.pdfA4                  ' Formato pagina
            .Margin = 0                         ' Margine
            '.Orientation = pdfLandscape         ' Orientamento
            .Orientation = Pdf.pdfPageOrientation.pdfPortrait          ' Orientamento

            .EncodeASCII85 = True

            .InitPDFFile(strFile)                ' inizializza il file

            ' Definisce le risorse relative ai font
            .LoadFont("Fnt1", "Arial", pdfFontStyle.pdfNormal)
            .LoadFont("Fnt2", "Arial", pdfFontStyle.pdfBoldItalic)
            .LoadFont("Fnt3", "Arial", pdfFontStyle.pdfBold)
            '.LoadFontStandard "Fnt1", "Helvetica", pdfNormal
            '.LoadFont "Fnt1", "Times New Roman"
            '.LoadFont "Fnt2", "Arial", pdfItalic
            '.LoadFont "Fnt3", "Courier New"
            '.LoadFontStandard "Fnt4", "Courier New", pdfBoldItalic    ' Tipo Type1


            .WithBackColor = WithBackColor

            '     Inizializza la prima pagina
            .BeginPage()
            '.SetColorStroke rgb(0, 0, 0)
            .SetColorStroke(&H20202)

            'testata
            rs = Utx.FunzioniDb.CreaDataTableReader("SELECT * From ProfiloUtente")
            If rs.Read Then
                .SetColorFill(0)
                .DrawText(30, 595.5 - 30, UCase("Agenzia " & rs("Agenzia") & " - " & rs("Localita")), Fnt2, 8)
            End If
            rs.Close()
            .DrawText(842 - 30, 565, Now.ToString("dddd, d MMMM yyyy - ore HH:mm"), Fnt2, 8, pdfTextAlign.pdfAlignRight)

            .DrawCell(1, 1, IIf(confrontaAnnoPrecedente, 15, 6), 1, "PRODUZIONE DAL " & dataDal & " AL " & dataAl, , pdfTextAlign.pdfCenter, Fnt3, 12)

            .DrawCell(2, Row0, 6, Row0, "PERIODO DAL " & dataDal & " AL " & dataAl, ReportColor.gHead, pdfTextAlign.pdfCenter, Fnt3)
            If confrontaAnnoPrecedente Then
                .DrawCell(7, Row0, 12, Row0, "PERIODO DAL " & precedenteDal & " AL " & precedenteAl, ReportColor.rHead, pdfTextAlign.pdfCenter, Fnt3)
            End If

            .DrawCell(1, Row0 + 1, 1, Row0 + 2, "", ReportColor.sHead, pdfTextAlign.pdfCenter, Fnt3)
            .DrawCell(2, Row0 + 1, "CLIENTI", ReportColor.gHead, pdfTextAlign.pdfCenter, Fnt3)
            .DrawCell(2, Row0 + 2, "Nuovi", ReportColor.gHead, pdfTextAlign.pdfCenter, Fnt3)

            .DrawCell(3, Row0 + 1, 6, Row0 + 1, "POLIZZE", ReportColor.gHead, pdfTextAlign.pdfCenter, Fnt3)
            .DrawCell(3, Row0 + 2, "Nuove", ReportColor.gHead, pdfTextAlign.pdfCenter, Fnt3)
            .DrawCell(4, Row0 + 2, "Variate", ReportColor.gHead, pdfTextAlign.pdfCenter, Fnt3)
            .DrawCell(5, Row0 + 2, "Ann.te", ReportColor.gHead, pdfTextAlign.pdfCenter, Fnt3)
            '.DrawCell(6, Row0 + 2, "Totale", ReportColor.gHead, pdfTextAlign.pdfCenter, Fnt3)
            .DrawCell(6, Row0 + 2, "Produzione", ReportColor.gHead, pdfTextAlign.pdfAlignRight, Fnt3)

            If confrontaAnnoPrecedente Then
                .DrawCell(7, Row0 + 1, "CLIENTI", ReportColor.rHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(7, Row0 + 2, "Nuovi", ReportColor.rHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(8, Row0 + 1, 11, Row0 + 1, "POLIZZE", ReportColor.rHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(8, Row0 + 2, "Nuove", ReportColor.rHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(9, Row0 + 2, "Variate", ReportColor.rHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(10, Row0 + 2, "Ann.te", ReportColor.rHead, pdfTextAlign.pdfCenter, Fnt3)
                '.DrawCell(12, Row0 + 2, "Totale", ReportColor.rHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(11, Row0 + 2, "Produzione", ReportColor.rHead, pdfTextAlign.pdfAlignRight, Fnt3)

                .DrawCell(12, Row0 + 1, 15, Row0 + 1, "INCREMENTO", ReportColor.bHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(12, Row0 + 2, 13, Row0 + 2, "Polizze", ReportColor.bHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(14, Row0 + 2, 15, Row0 + 2, "Premi", ReportColor.bHead, pdfTextAlign.pdfCenter, Fnt3)
            End If

            Dim row As Integer
            Dim l1, l2 As Integer
            Dim d1 As String = ""
            Dim d2 As String = ""

            Dim cc0, pc0, sc0, ac0, tc0 As Integer
            Dim cc1, pc1, sc1, ac1, tc1 As Integer
            Dim cc2, pc2, sc2, ac2, tc2 As Integer
            Dim cc3, pc3, sc3, ac3, tc3 As Integer
            Dim ic0, ic1, ic2, ic3 As Double

            Dim cp0, pp0, sp0, ap0, tp0 As Integer
            Dim cp1, pp1, sp1, ap1, tp1 As Integer
            Dim cp2, pp2, sp2, ap2, tp2 As Integer
            Dim cp3, pp3, sp3, ap3, tp3 As Integer
            Dim ip0, ip1, ip2, ip3 As Double

            row = Row0 + 3

            rs = Utx.FunzioniDb.CreaDataTableReader(GeneraReportProduzione(dataDal, dataAl, precedenteDal, precedenteAl, confrontaAnnoPrecedente,
                                                                           subagenti, produttori, ramiGestione, escludiSostituzioniAuto, includiRegolazione,
                                                                           prodotti, escludiProdotti, convenzioni, escludiConvenzioni))
            If rs Is Nothing Then Return vbNullString

            Do While rs.Read
                cc3 = IIf(IsDBNull(rs("CC")), 0, rs("CC"))
                pc3 = IIf(IsDBNull(rs("PC")), 0, rs("PC"))
                sc3 = IIf(IsDBNull(rs("SC")), 0, rs("SC"))
                ac3 = IIf(IsDBNull(rs("AC")), 0, rs("AC"))
                tc3 = IIf(IsDBNull(rs("TC")), 0, rs("TC"))
                ic3 = IIf(IsDBNull(rs("IC")), 0D, rs("IC"))

                cp3 = IIf(IsDBNull(rs("CP")), 0, rs("CP"))
                pp3 = IIf(IsDBNull(rs("PP")), 0, rs("PP"))
                sp3 = IIf(IsDBNull(rs("SP")), 0, rs("SP"))
                ap3 = IIf(IsDBNull(rs("AP")), 0, rs("AP"))
                tp3 = IIf(IsDBNull(rs("TP")), 0, rs("TP"))
                ip3 = IIf(IsDBNull(rs("IP")), 0D, rs("IP"))

                If l2 <> rs("l2") Then
                    If l2 > 0 And l1 = 2 Then
                        .DrawCell(1, row, "  " & d2, ReportColor.sMed, pdfTextAlign.pdfAlignLeft, Fnt2)
                        .DrawCell(2, row, "" & cc2, ReportColor.gMed, pdfTextAlign.pdfCenter, Fnt2)
                        .DrawCell(3, row, "" & pc2, ReportColor.gMed, pdfTextAlign.pdfCenter, Fnt2)
                        .DrawCell(4, row, "" & sc2, ReportColor.gMed, pdfTextAlign.pdfCenter, Fnt2)
                        .DrawCell(5, row, "" & ac2, ReportColor.gMed, pdfTextAlign.pdfCenter, Fnt2)
                        '.DrawCell(6, row, "" & tc2, ReportColor.gMed, pdfTextAlign.pdfCenter, Fnt2)
                        .DrawCell(6, row, Importo(ic2), ReportColor.gMed, pdfTextAlign.pdfAlignRight, Fnt2)

                        If confrontaAnnoPrecedente Then
                            .DrawCell(7, row, "" & cp2, ReportColor.rMed, pdfTextAlign.pdfCenter, Fnt2)
                            .DrawCell(8, row, "" & pp2, ReportColor.rMed, pdfTextAlign.pdfCenter, Fnt2)
                            .DrawCell(9, row, "" & sp2, ReportColor.rMed, pdfTextAlign.pdfCenter, Fnt2)
                            .DrawCell(10, row, "" & ap2, ReportColor.rMed, pdfTextAlign.pdfCenter, Fnt2)
                            '.DrawCell(12, row, "" & tp2, ReportColor.rMed, pdfTextAlign.pdfCenter, Fnt2)
                            .DrawCell(11, row, Importo(ip2), ReportColor.rMed, pdfTextAlign.pdfAlignRight, Fnt2)

                            .DrawCell(12, row, "" & (tc2 - tp2), ReportColor.bMed, pdfTextAlign.pdfCenter, Fnt2)
                            .DrawCell(13, row, IncrementoPercentuale(tc2, tp2), ReportColor.bMed, pdfTextAlign.pdfCenter, Fnt2)
                            .DrawCell(14, row, Importo(ic2 - ip2), ReportColor.bMed, pdfTextAlign.pdfCenter, Fnt2)
                            .DrawCell(15, row, IncrementoPercentuale(ic2, ip2), ReportColor.bMed, pdfTextAlign.pdfCenter, Fnt2)
                        End If
                        cc2 = 0 : pc2 = 0 : sc2 = 0 : ac2 = 0 : tc2 = 0 : ic2 = 0.0#
                        cp2 = 0 : pp2 = 0 : sp2 = 0 : ap2 = 0 : tp2 = 0 : ip2 = 0.0#
                        row += 1
                    End If
                    l2 = rs("L2")
                    d2 = IIf(IsDBNull(rs("D2")), "**" & l2 & "**", rs("D2"))
                End If

                If l1 <> rs("L1") Then
                    If l1 > 0 Then
                        .DrawCell(1, row, "" & d1, ReportColor.sDark, pdfTextAlign.pdfAlignLeft, Fnt3)
                        .DrawCell(2, row, "" & cc1, ReportColor.gDark, pdfTextAlign.pdfCenter, Fnt3)
                        .DrawCell(3, row, "" & pc1, ReportColor.gDark, pdfTextAlign.pdfCenter, Fnt3)
                        .DrawCell(4, row, "" & sc1, ReportColor.gDark, pdfTextAlign.pdfCenter, Fnt3)
                        .DrawCell(5, row, "" & ac1, ReportColor.gDark, pdfTextAlign.pdfCenter, Fnt3)
                        '.DrawCell(6, row, "" & tc1, ReportColor.gDark, pdfTextAlign.pdfCenter, Fnt3)
                        .DrawCell(6, row, Importo(ic1), ReportColor.gDark, pdfTextAlign.pdfAlignRight, Fnt3)
                        .SetLineWidth(1.0#)
                        .DrawBorder(1, Row0 + 1, 6, row)

                        If confrontaAnnoPrecedente Then
                            .DrawCell(7, row, "" & cp1, ReportColor.rDark, pdfTextAlign.pdfCenter, Fnt3)
                            .DrawCell(8, row, "" & pp1, ReportColor.rDark, pdfTextAlign.pdfCenter, Fnt3)
                            .DrawCell(9, row, "" & sp1, ReportColor.rDark, pdfTextAlign.pdfCenter, Fnt3)
                            .DrawCell(10, row, "" & ap1, ReportColor.rDark, pdfTextAlign.pdfCenter, Fnt3)
                            '.DrawCell(12, row, "" & tp1, ReportColor.rDark, pdfTextAlign.pdfCenter, Fnt3)
                            .DrawCell(11, row, Importo(ip1), ReportColor.rDark, pdfTextAlign.pdfAlignRight, Fnt3)

                            .DrawCell(12, row, "" & (tc1 - tp1), ReportColor.bDark, pdfTextAlign.pdfCenter, Fnt3)
                            .DrawCell(13, row, IncrementoPercentuale(tc1, tp1), ReportColor.bDark, pdfTextAlign.pdfCenter, Fnt3)
                            .DrawCell(14, row, Importo(ic1 - ip1), ReportColor.bDark, pdfTextAlign.pdfCenter, Fnt3)
                            .DrawCell(15, row, IncrementoPercentuale(ic1, ip1), ReportColor.bDark, pdfTextAlign.pdfCenter, Fnt3)
                            .SetLineWidth(1.0#)
                            .DrawBorder(7, Row0 + 1, 15, row)
                        End If

                        cc1 = 0 : pc1 = 0 : sc1 = 0 : ac1 = 0 : tc1 = 0 : ic1 = 0.0#
                        cc2 = 0 : pc2 = 0 : sc2 = 0 : ac2 = 0 : tc2 = 0 : ic2 = 0.0#
                        cp1 = 0 : pp1 = 0 : sp1 = 0 : ap1 = 0 : tp1 = 0 : ip1 = 0.0#
                        cp2 = 0 : pp2 = 0 : sp2 = 0 : ap2 = 0 : tp2 = 0 : ip2 = 0.0#
                        row += 1
                    End If
                    l1 = rs("L1")
                    d1 = IIf(IsDBNull(rs("D1")), "**" & l1 & "**", rs("D1"))
                End If

                .DrawCell(1, row, "    " & rs("L3") & "-" & LCase(rs("D3")), ReportColor.sLight, pdfTextAlign.pdfAlignLeft)
                .DrawCell(2, row, "" & cc3, ReportColor.gLight, pdfTextAlign.pdfCenter)
                .DrawCell(3, row, "" & pc3, ReportColor.gLight, pdfTextAlign.pdfCenter)
                .DrawCell(4, row, "" & sc3, ReportColor.gLight, pdfTextAlign.pdfCenter)
                .DrawCell(5, row, "" & ac3, ReportColor.gLight, pdfTextAlign.pdfCenter)
                '.DrawCell(6, row, "" & tc3, ReportColor.gLight, pdfTextAlign.pdfCenter)
                .DrawCell(6, row, Importo(ic3), ReportColor.gLight, pdfTextAlign.pdfAlignRight)

                If confrontaAnnoPrecedente Then
                    .DrawCell(7, row, "" & cp3, ReportColor.rLight, pdfTextAlign.pdfCenter)
                    .DrawCell(8, row, "" & pp3, ReportColor.rLight, pdfTextAlign.pdfCenter)
                    .DrawCell(9, row, "" & sp3, ReportColor.rLight, pdfTextAlign.pdfCenter)
                    .DrawCell(10, row, "" & ap3, ReportColor.rLight, pdfTextAlign.pdfCenter)
                    '.DrawCell(11, row, "" & tp3, ReportColor.rLight, pdfTextAlign.pdfCenter)
                    .DrawCell(11, row, Importo(ip3), ReportColor.rLight, pdfTextAlign.pdfAlignRight)

                    .DrawCell(12, row, "" & (tc3 - tp3), ReportColor.bLight, pdfTextAlign.pdfCenter)
                    .DrawCell(13, row, IncrementoPercentuale(tc3, tp3), ReportColor.bLight, pdfTextAlign.pdfCenter)
                    .DrawCell(14, row, Importo(ic3 - ip3), ReportColor.bLight, pdfTextAlign.pdfCenter)
                    .DrawCell(15, row, IncrementoPercentuale(ic3, ip3), ReportColor.bLight, pdfTextAlign.pdfCenter)
                End If

                cc0 += cc3 : pc0 += pc3 : sc0 += sc3 : ac0 += ac3 : tc0 += tc3 : ic0 += ic3
                cc1 += cc3 : pc1 += pc3 : sc1 += sc3 : ac1 += ac3 : tc1 += tc3 : ic1 += ic3
                cc2 += cc3 : pc2 += pc3 : sc2 += sc3 : ac2 += ac3 : tc2 += tc3 : ic2 += ic3
                cp0 += cp3 : pp0 += pp3 : sp0 += sp3 : ap0 += ap3 : tp0 += tp3 : ip0 += ip3
                cp1 += cp3 : pp1 += pp3 : sp1 += sp3 : ap1 += ap3 : tp1 += tp3 : ip1 += ip3
                cp2 += cp3 : pp2 += pp3 : sp2 += sp3 : ap2 += ap3 : tp2 += tp3 : ip2 += ip3

                row += 1
            Loop

            .DrawCell(1, row, "" & d1, ReportColor.sDark, pdfTextAlign.pdfAlignLeft, Fnt3)
            .DrawCell(2, row, "" & cc1, ReportColor.gDark, pdfTextAlign.pdfCenter, Fnt3)
            .DrawCell(3, row, "" & pc1, ReportColor.gDark, pdfTextAlign.pdfCenter, Fnt3)
            .DrawCell(4, row, "" & sc1, ReportColor.gDark, pdfTextAlign.pdfCenter, Fnt3)
            .DrawCell(5, row, "" & ac1, ReportColor.gDark, pdfTextAlign.pdfCenter, Fnt3)
            '.DrawCell(6, row, "" & tc1, ReportColor.gDark, pdfTextAlign.pdfCenter, Fnt3)
            .DrawCell(6, row, Importo(ic1), ReportColor.gDark, pdfTextAlign.pdfAlignRight, Fnt3)

            If confrontaAnnoPrecedente Then
                .DrawCell(7, row, "" & cp1, ReportColor.rDark, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(8, row, "" & pp1, ReportColor.rDark, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(9, row, "" & sp1, ReportColor.rDark, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(10, row, "" & ap1, ReportColor.rDark, pdfTextAlign.pdfCenter, Fnt3)
                '.DrawCell(12, row, "" & tp1, ReportColor.rDark, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(11, row, Importo(ip1), ReportColor.rDark, pdfTextAlign.pdfAlignRight, Fnt3)

                .DrawCell(12, row, "" & (tc1 - tp1), ReportColor.bDark, pdfTextAlign.pdfCenter, Fnt2)
                .DrawCell(13, row, IncrementoPercentuale(tc1, tp1), ReportColor.bDark, pdfTextAlign.pdfCenter, Fnt2)
                .DrawCell(14, row, Importo(ic1 - ip1), ReportColor.bDark, pdfTextAlign.pdfCenter, Fnt2)
                .DrawCell(15, row, IncrementoPercentuale(ic1, ip1), ReportColor.bDark, pdfTextAlign.pdfCenter, Fnt2)
            End If

            .SetLineWidth(1.0#)
            .DrawBorder(1, Row0 + 1, 6, row)
            If confrontaAnnoPrecedente Then
                .DrawBorder(7, Row0 + 1, 15, row)
            End If
            row = row + 1

            .DrawCell(1, row, "TOTALE", ReportColor.sHead, pdfTextAlign.pdfAlignLeft, Fnt3)
            .DrawCell(2, row, "" & cc0, ReportColor.gHead, pdfTextAlign.pdfCenter, Fnt3)
            .DrawCell(3, row, "" & pc0, ReportColor.gHead, pdfTextAlign.pdfCenter, Fnt3)
            .DrawCell(4, row, "" & sc0, ReportColor.gHead, pdfTextAlign.pdfCenter, Fnt3)
            .DrawCell(5, row, "" & ac0, ReportColor.gHead, pdfTextAlign.pdfCenter, Fnt3)
            '.DrawCell(6, row, "" & tc0, ReportColor.gHead, pdfTextAlign.pdfCenter, Fnt3)
            .DrawCell(6, row, Importo(ic0), ReportColor.gHead, pdfTextAlign.pdfAlignRight, Fnt3)

            If confrontaAnnoPrecedente Then
                .DrawCell(7, row, "" & cp0, ReportColor.rHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(8, row, "" & pp0, ReportColor.rHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(9, row, "" & sp0, ReportColor.rHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(10, row, "" & ap0, ReportColor.rHead, pdfTextAlign.pdfCenter, Fnt3)
                '.DrawCell(12, row, "" & tp0, ReportColor.rHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(11, row, Importo(ip0), ReportColor.rHead, pdfTextAlign.pdfAlignRight, Fnt3)

                .DrawCell(12, row, "" & (tc0 - tp0), ReportColor.bHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(13, row, IncrementoPercentuale(tc0, tp0), ReportColor.bHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(14, row, Importo(ic0 - ip0), ReportColor.bHead, pdfTextAlign.pdfCenter, Fnt3)
                .DrawCell(15, row, IncrementoPercentuale(ic0, ip0), ReportColor.bHead, pdfTextAlign.pdfCenter, Fnt3)
            End If

            .SetLineWidth(0.1)
            .DrawBorder(1, Row0 + 1, 1, Row0 + 2)

            .DrawBorder(2, Row0 + 2, 6, Row0 + 2)
            .DrawBorder(2, Row0 + 1, 2, row)
            .DrawBorder(4, Row0 + 2, 4, row)
            .DrawBorder(6, Row0 + 2, 6, row)

            If confrontaAnnoPrecedente Then
                .DrawBorder(7, Row0 + 2, 11, Row0 + 2)
                .DrawBorder(7, Row0 + 1, 7, row)
                .DrawBorder(8, Row0 + 2, 8, row)
                .DrawBorder(10, Row0 + 2, 10, row)

                .DrawBorder(12, Row0 + 2, 13, Row0 + 2)
                .DrawBorder(12, Row0 + 2, 13, row)
                .DrawBorder(13, Row0 + 3, 14, row)
            End If

            .SetLineWidth(1)
            .DrawBorder(2, Row0, 6, row)
            .DrawBorder(1, Row0 + 1, 6, row)

            If confrontaAnnoPrecedente Then
                .DrawBorder(7, Row0, 11, row)
                .DrawBorder(7, Row0 + 1, 15, row)
            End If

            row += 1
            .DrawCell(1, row, IIf(confrontaAnnoPrecedente, 15, 6), row, "Importi espressi in euro", , pdfTextAlign.pdfAlignRight, Fnt2)

            row += 1
            .DrawCell(1, row, 15, row, "Subagenzia: " & ArrayToString(subagenti), , , Fnt3, 9)
            row += 1
            .DrawCell(1, row, 15, row, "Produttore: " & ArrayToString(produttori), , , Fnt3, 9)

            'row = row + 1
            '.DrawCellUnion 1, row, 15, row, "Rami gestione: " & ArrayToString(subAgenti)

            row += 1
            If escludiProdotti Then
                .DrawCell(1, row, 15, row, "Prodotti esclusi: " & ArrayToString(prodotti), , , Fnt3, 9)
            Else
                .DrawCell(1, row, 15, row, "Prodotto: " & ArrayToString(prodotti), , , Fnt3, 9)
            End If

            row += 1
            If escludiConvenzioni Then
                .DrawCell(1, row, 15, row, "Convenzioni escluse: " & ArrayToString(convenzioni), , , Fnt3, 9)
            Else
                .DrawCell(1, row, 15, row, "Convenzione: " & ArrayToString(convenzioni), , , Fnt3, 9)
            End If


            row += 1
            If escludiSostituzioniAuto = True Then
                .DrawCell(1, row, 15, row, "Escluse le sostituzioni auto", , , Fnt3, 9)
            Else
                .DrawCell(1, row, 15, row, "Incluse le sostituzioni auto", , , Fnt3, 9)
            End If

            row += 1
            If includiRegolazione = True Then
                .DrawCell(1, row, 15, row, "Incluse le regolazioni premio", , , Fnt3, 9)
            Else
                .DrawCell(1, row, 15, row, "Escluse le regolazioni premio", , , Fnt3, 9)
            End If

            ' Chiude la seconda pagina
            .EndPage()

            ' Chiude il documento
            .ClosePDFFile()
        End With
    End Function

    Private Function Importo(i As Double) As String
        Importo = Format(i, "#,##0.00")
    End Function

    Private Function IncrementoPercentuale(ic As Double, ip As Double) As String
        If ip = 0 Then
            IncrementoPercentuale = "-"
        Else
            IncrementoPercentuale = Format(100 * (ic - ip) / ip, "0") & "%"
        End If
    End Function


    Private Function IsNotEmpty(arr() As String) As Boolean
        If arr Is Nothing Then
            Return False
        ElseIf arr.Length = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function ArrayToString(arr() As String) As String
        Dim i As Integer
        Dim s As String = ""

        If IsNotEmpty(arr) Then
            For i = 0 To UBound(arr)
                If i = 0 Then
                    s = arr(i)
                Else
                    s = s & ", " & arr(i)
                End If
            Next
        Else
            s = "Tutti"
        End If

        Return s
    End Function
End Module
