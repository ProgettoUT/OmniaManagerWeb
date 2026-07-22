
Module Funzioni

    Public Function EsisteSinistro(Compagnia As Integer,
                                   Ente As Integer,
                                   Esercizio As Integer,
                                   Numero As Long,
                                   Tipo As QuerySinistri.TipoTabella) As Boolean
        Try
            Dim Query As String = "SELECT COUNT(*) FROM {0} 
                WHERE Compagnia = {1} AND AgenziaSinistro = {2} AND EsercizioSinistro = {3} AND NumeroSinistro = {4}"

            If Tipo = QuerySinistri.TipoTabella.SINISTRI_DELEGA_PROPRIA Then
                Query = String.Format(Query, "SinistriDP", Compagnia, Ente, Esercizio, Numero)
            Else
                Query = String.Format(Query, "SinistriAC", Compagnia, Ente, Esercizio, Numero)
            End If
            Return Utx.WsCommand.ExecuteScalar(Query).Valore > 0
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

#Region "statistiche"
    Public Function CalcolaMixCP(Optional Descrizione As Windows.Forms.Label = Nothing) As DataTable
        Try
            Dim Fine As Date = Utx.WsCommand.ExecuteScalar("SELECT Max(DataProtocollo) FROM SinistriDP WHERE FlagCosePersone In ('C','P')").Valore
            Dim Inizio As New DateTime(Fine.Year, 1, 1)

            If Descrizione IsNot Nothing Then
                Descrizione.Text = String.Format("Mix Cose/Persone dal {0:d} al {1:d}", Inizio, Fine)
            End If

            'anno corrente
            Dim mcp As New MixCosePersone With {.Inizio = Inizio, .Fine = Fine}
            Dim dt As DataTable = mcp.CreaDataTable

            For k As Integer = 0 To dt.Rows.Count - 2
                Dim Ramo As Integer = dt.Rows(k).Item("Ramo")
                'riga
                dt.Rows(k).Item("Cose") = mcp.Calcola(MixCosePersone.TipoDanno.COSE, MixCosePersone.TipoMix.NORMALE, Ramo)
                dt.Rows(k).Item("Persone") = mcp.Calcola(MixCosePersone.TipoDanno.PERSONE, MixCosePersone.TipoMix.NORMALE, Ramo)
                dt.Rows(k).Item("GCose") = mcp.Calcola(MixCosePersone.TipoDanno.COSE, MixCosePersone.TipoMix.GESTIONARIO, Ramo)
                dt.Rows(k).Item("GPersone") = mcp.Calcola(MixCosePersone.TipoDanno.PERSONE, MixCosePersone.TipoMix.GESTIONARIO, Ramo)
                'totali
                dt.Rows(dt.Rows.Count - 1).Item("Cose") += dt.Rows(k).Item("Cose")
                dt.Rows(dt.Rows.Count - 1).Item("Persone") += dt.Rows(k).Item("Persone")
                dt.Rows(dt.Rows.Count - 1).Item("GCose") += dt.Rows(k).Item("GCose")
                dt.Rows(dt.Rows.Count - 1).Item("GPersone") += dt.Rows(k).Item("GPersone")
            Next
            'scrivo le percentuali
            For Each dr As DataRow In dt.Rows
                If dr("Cose") + dr("Persone") > 0 Then
                    dr("Mix") = dr("Persone") / (dr("Cose") + dr("Persone")) * 100
                End If
                If dr("GCose") + dr("GPersone") > 0 Then
                    dr("MixGest") = dr("GPersone") / (dr("GCose") + dr("GPersone")) * 100
                End If
            Next
            'anno precedente (per calcolare le differenze)
            mcp.Inizio = Inizio.AddYears(-1)
            mcp.Fine = Fine.AddYears(-1)

            Dim OldMix As Single, Old30Mix As Single, Old130Mix As Single, Old230Mix As Single

            'normale
            Dim Old30Cose As Long = mcp.Calcola(MixCosePersone.TipoDanno.COSE, MixCosePersone.TipoMix.NORMALE, 30)
            Dim Old130Cose As Long = mcp.Calcola(MixCosePersone.TipoDanno.COSE, MixCosePersone.TipoMix.NORMALE, 130)
            Dim Old230Cose As Long = mcp.Calcola(MixCosePersone.TipoDanno.COSE, MixCosePersone.TipoMix.NORMALE, 230)
            Dim Old30Persone As Long = mcp.Calcola(MixCosePersone.TipoDanno.PERSONE, MixCosePersone.TipoMix.NORMALE, 30)
            Dim Old130Persone As Long = mcp.Calcola(MixCosePersone.TipoDanno.PERSONE, MixCosePersone.TipoMix.NORMALE, 130)
            Dim Old230Persone As Long = mcp.Calcola(MixCosePersone.TipoDanno.PERSONE, MixCosePersone.TipoMix.NORMALE, 230)

            If Old30Cose + Old30Persone > 0 Then
                Old30Mix = Old30Persone / (Old30Cose + Old30Persone) * 100
            End If
            If Old130Cose + Old130Persone > 0 Then
                Old130Mix = Old130Persone / (Old130Cose + Old130Persone) * 100
            End If
            If Old230Cose + Old230Persone > 0 Then
                Old230Mix = Old230Persone / (Old230Cose + Old230Persone) * 100
            End If
            If Old30Cose + Old30Persone + Old130Cose + Old130Persone + Old230Cose + Old230Persone > 0 Then
                OldMix = (Old30Persone + Old130Persone + Old230Persone) / (Old30Cose + Old30Persone + Old130Cose + Old130Persone + Old230Cose + Old230Persone) * 100
            End If
            'scrivo le differenze
            For k As Integer = 0 To dt.Rows.Count - 1
                Select Case dt.Rows(k).Item("Ramo").ToString.Trim
                    Case "30" : dt.Rows(k).Item("Diff") = dt.Rows(k).Item("Mix") - Old30Mix
                    Case "130" : dt.Rows(k).Item("Diff") = dt.Rows(k).Item("Mix") - Old130Mix
                    Case "230" : dt.Rows(k).Item("Diff") = dt.Rows(k).Item("Mix") - Old230Mix
                    Case "Totali" : dt.Rows(k).Item("Diff") = dt.Rows(k).Item("Mix") - OldMix
                End Select
            Next
            'gestionario
            Old30Cose = mcp.Calcola(MixCosePersone.TipoDanno.COSE, MixCosePersone.TipoMix.GESTIONARIO, 30)
            Old130Cose = mcp.Calcola(MixCosePersone.TipoDanno.COSE, MixCosePersone.TipoMix.GESTIONARIO, 130)
            Old230Cose = mcp.Calcola(MixCosePersone.TipoDanno.COSE, MixCosePersone.TipoMix.GESTIONARIO, 230)
            Old30Persone = mcp.Calcola(MixCosePersone.TipoDanno.PERSONE, MixCosePersone.TipoMix.GESTIONARIO, 30)
            Old130Persone = mcp.Calcola(MixCosePersone.TipoDanno.PERSONE, MixCosePersone.TipoMix.GESTIONARIO, 130)
            Old230Persone = mcp.Calcola(MixCosePersone.TipoDanno.PERSONE, MixCosePersone.TipoMix.GESTIONARIO, 230)

            If Old30Cose + Old30Persone > 0 Then
                Old30Mix = Old30Persone / (Old30Cose + Old30Persone) * 100
            End If
            If Old130Cose + Old130Persone > 0 Then
                Old130Mix = Old130Persone / (Old130Cose + Old130Persone) * 100
            End If
            If Old230Cose + Old230Persone > 0 Then
                Old230Mix = Old230Persone / (Old230Cose + Old230Persone) * 100
            End If
            If Old30Cose + Old30Persone + Old130Cose + Old130Persone + Old230Cose + Old230Persone > 0 Then
                OldMix = (Old30Persone + Old130Persone + Old230Persone) / (Old30Cose + Old30Persone + Old130Cose + Old130Persone + Old230Cose + Old230Persone) * 100
            End If
            'scrivo le differenze
            For k As Integer = 0 To dt.Rows.Count - 1
                Select Case dt.Rows(k).Item("Ramo").ToString.Trim
                    Case "30" : dt.Rows(k).Item("DiffGest") = dt.Rows(k).Item("MixGest") - Old30Mix
                    Case "130" : dt.Rows(k).Item("DiffGest") = dt.Rows(k).Item("MixGest") - Old130Mix
                    Case "230" : dt.Rows(k).Item("DiffGest") = dt.Rows(k).Item("MixGest") - Old230Mix
                    Case "Totali" : dt.Rows(k).Item("DiffGest") = dt.Rows(k).Item("MixGest") - OldMix
                End Select
            Next
            Return dt

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Function FrequenzaPerCip(Optional Descrizione As Windows.Forms.Label = Nothing) As DataTable
        Try
            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteScalar("SELECT Max(UltimoAggiornamento) FROM CalendarioOmnia WHERE TipoFile = '05'")

            If IsDate(Risposta.Valore) = False Then
                MsgBox("Dati richiesti non presenti", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Return Nothing
            End If
            Dim Fine As Date = Risposta.Valore
            Dim Inizio As Date = Fine.AddYears(-1).AddDays(1)

            If Descrizione IsNot Nothing Then
                Descrizione.Text = String.Format("Frequenza auto dal {0:d} al {1:d}", Inizio, Fine)
            End If

            Dim Q1 As String = "SELECT STR(CodiceSubAgenteSima) AS Codice,RamoSinistro,
                COUNT(RamoSinistro) AS NumeroSinistri,P.NumeroPolizze,0.01 As Frequenza 
                FROM SinistriDP AS S 
                INNER JOIN (SELECT CodiceSubAgente,COUNT(*) AS NumeroPolizze 
                            FROM Polizze WHERE Ramo = 30 GROUP BY CodiceSubAgente) AS P 
                ON S.CodiceSubAgenteSima = P.CodiceSubAgente 
                WHERE (RamoSinistro = 30) AND 
                      (RamoPolizza = 30) AND 
                      (AgenziaSinistro > 0) AND 
                      (TipoCid IN (' ','','6','7')) AND 
                      (TipoDelega <> '2') AND 
                      (StatoBilancistico <> 'SS') AND 
                      (DataDenuncia BETWEEN '{0:dd/MM/yyyy}' AND '{1:dd/MM/yyyy}') 
                GROUP BY RamoSinistro, CodiceSubAgenteSima, NumeroPolizze"
            Q1 = String.Format(Q1, Inizio, Fine)

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Q1).DataTable
            dt.Rows.Add({"Totali", 30, 0, 0, 0})

            For k As Integer = 0 To dt.Rows.Count - 2
                If dt.Rows(k).Item("NumeroPolizze") > 0 Then
                    dt.Rows(k).Item("Frequenza") = dt.Rows(k).Item("NumeroSinistri") / dt.Rows(k).Item("NumeroPolizze") * 100
                Else
                    dt.Rows(k).Item("Frequenza") = 0
                End If
                'totali
                dt.Rows(dt.Rows.Count - 1).Item("NumeroPolizze") += dt.Rows(k).Item("NumeroPolizze")
                dt.Rows(dt.Rows.Count - 1).Item("NumeroSinistri") += dt.Rows(k).Item("NumeroSinistri")
            Next
            'frequenza totale
            If dt.Rows(dt.Rows.Count - 1).Item("NumeroPolizze") > 0 Then
                dt.Rows(dt.Rows.Count - 1).Item("Frequenza") = dt.Rows(dt.Rows.Count - 1).Item("NumeroSinistri") / dt.Rows(dt.Rows.Count - 1).Item("NumeroPolizze") * 100
            End If

            Return dt

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Function FrequenzaPerRamoProdotto(Optional Descrizione As Windows.Forms.Label = Nothing) As DataTable
        Try
            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteScalar("SELECT Max(UltimoAggiornamento) FROM CalendarioOmnia WHERE TipoFile = '21'")

            If IsDate(Risposta.Valore) = False Then
                MsgBox("Dati richiesti non presenti", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Return Nothing
            End If
            Dim Fine As Date = Risposta.Valore
            Dim Inizio As Date = Fine.AddYears(-1).AddDays(1)

            If Descrizione IsNot Nothing Then
                Descrizione.Text = String.Format("Frequenza per ramo e prodotto dal {0:d} al {1:d}", Inizio, Fine)
            End If

            Dim Q1 As String = "SELECT STR(RamoPolizza) AS Ramo,S.CodiceProdotto,
                COUNT(RamoSinistro) AS NumeroSinistri,P.NumeroPolizze,0.01 As Frequenza 
                FROM SinistriDP S 
                INNER JOIN (SELECT Ramo,CodiceProdotto,Count(*) AS NumeroPolizze 
                            FROM Polizze 
                            WHERE LEN(TRIM(IdStorno)) = 0 AND Ramo NOT IN (130,131,230,231) 
                            GROUP BY Ramo,CodiceProdotto) AS P 
                ON S.RamoPolizza = P.Ramo AND TRIM(S.CodiceProdotto) = TRIM(P.CodiceProdotto) 
                WHERE (AgenziaSinistro > 0) AND 
                       (TipoDelega <> '2') AND 
                       (StatoBilancistico <> 'SS') AND 
                       (DataDenuncia BETWEEN '{0:dd/MM/yyyy}' AND '{1:dd/MM/yyyy}') 
                GROUP BY RamoPolizza, S.CodiceProdotto,NumeroPolizze
                ORDER BY S.CodiceProdotto"
            Q1 = String.Format(Q1, Inizio, Fine)

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Q1).DataTable

            Dim Totali = dt.NewRow
            Totali.ItemArray = {"Totali", "-", 0, 0, 0}
            dt.Rows.InsertAt(Totali, 0)

            For k As Integer = 1 To dt.Rows.Count - 1
                If dt.Rows(k).Item("NumeroPolizze") > 0 Then
                    dt.Rows(k).Item("Frequenza") = dt.Rows(k).Item("NumeroSinistri") / dt.Rows(k).Item("NumeroPolizze") * 100
                Else
                    dt.Rows(k).Item("Frequenza") = 0
                End If
                'totali
                dt.Rows(0).Item("NumeroPolizze") += dt.Rows(k).Item("NumeroPolizze")
                dt.Rows(0).Item("NumeroSinistri") += dt.Rows(k).Item("NumeroSinistri")
            Next
            'frequenza totale
            If dt.Rows(0).Item("NumeroPolizze") > 0 Then
                dt.Rows(0).Item("Frequenza") = dt.Rows(0).Item("NumeroSinistri") / dt.Rows(0).Item("NumeroPolizze") * 100
            End If

            Return dt

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Function FrequenzaAutoPerConvenzioni(Optional Descrizione As Windows.Forms.Label = Nothing) As DataTable
        Try
            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteScalar("SELECT Max(UltimoAggiornamento) FROM CalendarioOmnia WHERE TipoFile = '05'")

            If IsDate(Risposta.Valore) = False Then
                MsgBox("Dati richiesti non presenti", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Return Nothing
            End If
            Dim Fine As Date = Risposta.Valore
            Dim Inizio As Date = Fine.AddYears(-1).AddDays(1)

            If Descrizione IsNot Nothing Then
                Descrizione.Text = String.Format("Frequenza auto per convenzione dal {0:d} al {1:d}", Inizio, Fine)
            End If

            Dim Q1 As String = "SELECT S.Convenzione,RamoSinistro,
                COUNT(RamoSinistro) AS NumeroSinistri,P.NumeroPolizze,0.01 As Frequenza 
                FROM SinistriDP AS S 
                INNER JOIN (SELECT Format(Convenzione,'00000') AS Convenzione,COUNT(*) AS NumeroPolizze 
                            FROM Polizze 
                            WHERE LEN(TRIM(IdStorno)) = 0 AND Ramo = 30 
                            GROUP BY Convenzione) AS P 
                ON S.Convenzione = P.Convenzione 
                WHERE (RamoSinistro = 30) AND 
                        (AgenziaSinistro > 0) AND 
                        (TipoDelega <> '2') AND 
                        (TipoCid In (' ','','6','7')) AND 
                        (StatoBilancistico <> 'SS') AND 
                        (S.Convenzione <> '00000') AND 
                        (DataDenuncia BETWEEN '{0:dd/MM/yyyy}' AND '{1:dd/MM/yyyy}') 
                GROUP BY RamoSinistro,S.Convenzione,NumeroPolizze
                ORDER BY S.Convenzione"
            Q1 = String.Format(Q1, Inizio, Fine)

            'per sicurezza
            Utx.WsCommand.ExecuteNonQueryRecord("UPDATE SinistriDP SET Convenzione = '' WHERE Convenzione IS NULL")

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Q1).DataTable
            dt.Rows.Add({"Totali", 30, 0, 0, 0})

            For k As Integer = 0 To dt.Rows.Count - 2
                If dt.Rows(k).Item("NumeroPolizze") > 0 Then
                    dt.Rows(k).Item("Frequenza") = dt.Rows(k).Item("NumeroSinistri") / dt.Rows(k).Item("NumeroPolizze") * 100
                Else
                    dt.Rows(k).Item("Frequenza") = 0
                End If
                'totali
                dt.Rows(dt.Rows.Count - 1).Item("NumeroPolizze") += dt.Rows(k).Item("NumeroPolizze")
                dt.Rows(dt.Rows.Count - 1).Item("NumeroSinistri") += dt.Rows(k).Item("NumeroSinistri")
            Next
            'frequenza totale
            If dt.Rows(dt.Rows.Count - 1).Item("NumeroPolizze") > 0 Then
                dt.Rows(dt.Rows.Count - 1).Item("Frequenza") = dt.Rows(dt.Rows.Count - 1).Item("NumeroSinistri") / dt.Rows(dt.Rows.Count - 1).Item("NumeroPolizze") * 100
            End If

            Return dt

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Function StatisticheLiquidato() As DataTable
        Try
            Dim sql As String = $"SELECT FORMAT(S.RamoSinistro,'00') + '.' + TR.DesRamoSinistro AS RamoSinistro,EsercizioSinistro,
                CASE
                WHEN Trim(S.TipoCid) = '' THEN ''
                ELSE TRIM(S.TipoCid + '.' + TC.Desk)
                END AS TipoCid,
                StatoBilancistico,SUM(PagatoAl) As Totale,COUNT(EsercizioSinistro) As NumeroSinistri,
                CASE
                WHEN COUNT(EsercizioSinistro) > 0 THEN SUM(PagatoAl) / COUNT(EsercizioSinistro)
                ELSE 0
                END AS Media
                FROM SinistriDP AS S 
                LEFT JOIN TipoRamiSinistro TR ON S.RamoSinistro = TR.RamoSinistro
                LEFT JOIN TipoCid TC ON S.TipoCid = TC.TipoCid 
                WHERE(S.TipoCid LIKE '[ 12345678]') AND (S.StatoBilancistico = 'LT') AND (EsercizioSinistro >= {Today.Year - 5}) 
                GROUP BY S.RamoSinistro, EsercizioSinistro,FORMAT(S.RamoSinistro,'00') + '.' + TR.DesRamoSinistro,
                            CASE
                            WHEN Trim(S.TipoCid) = '' THEN ''
                            ELSE TRIM(S.TipoCid + '.' + TC.Desk)
                            END,
                            S.StatoBilancistico 
                ORDER BY S.RamoSinistro, EsercizioSinistro DESC"

            Return Utx.WsCommand.ExecuteNonQuery(sql).DataTable

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Function StatisticheLiquidatoComparto() As DataTable
        Try
            Dim sql As String = $"SELECT FORMAT(S.Comparto,'00') + '.' + C.Descrizione AS Comparto,EsercizioSinistro,
                StatoBilancistico,SUM(PagatoAl) AS Totale,COUNT(EsercizioSinistro) As NumeroSinistri,
				CASE
                WHEN COUNT(EsercizioSinistro) > 0 THEN SUM(PagatoAl) / COUNT(EsercizioSinistro)
                ELSE 0
                END AS Media
                FROM SinistriDP AS S 
                LEFT JOIN Comparto AS C ON S.Comparto = C.Codice
				WHERE (S.StatoBilancistico = 'LT') AND (EsercizioSinistro >= {Today.Year - 5}) 
                GROUP BY S.Comparto, C.Descrizione, EsercizioSinistro, S.StatoBilancistico 
                ORDER BY comparto,EsercizioSinistro DESC"

            Return Utx.WsCommand.ExecuteNonQuery(sql).DataTable

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function
#End Region
End Module
