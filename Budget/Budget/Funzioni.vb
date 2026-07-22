Module Funzioni

    Friend Enum ProcEvent
        ENTRATA = 0
        USCITA = 1
    End Enum

    Public Function FirstToUpper(Stringa As String) As String
        FirstToUpper = Left(Stringa, 1).ToUpper + Stringa.Substring(1).ToLower
    End Function

    Public Function StrConPunto(Numero As Double) As String
        StrConPunto = Replace(Numero.ToString, ",", ".", , , CompareMethod.Text)
    End Function

    Public Function ASum(Matrice As Array, Inizio As Int16, Fine As Int16) As Double

        ASum = 0

        For k As Int16 = Inizio To Fine
            ASum += Matrice(k)
        Next
    End Function

    Public Function ASum(cl As Collection, Inizio As Int16, Fine As Int16) As Double

        ASum = 0

        For k As Integer = Inizio To Fine
            If cl.Contains(k.ToString) Then ASum += cl.Item(k.ToString).Tag
        Next
    End Function

    Public Function NomeFileValido(NomeFile As String) As String
        NomeFile = NomeFile.Trim

        Dim Pos As Integer = NomeFile.IndexOfAny(":*?/\|<>""")
        If Pos < 0 Then 'caratteri vietati non trovati
            NomeFileValido = NomeFile
        Else
            NomeFileValido = NomeFile.Substring(0, Pos) 'taglio al primo carattere non consentito
        End If
    End Function

    Public Function AnnoInizioIncassi() As Integer
        'calcola l'anno iniziale presente negli incassi
        Try
            Return Utx.FunzioniDb.ExecuteScalar("SELECT MIN(YEAR(DataFoglioCassa)) FROM Incassi", Today.Year)
        Catch ex As Exception
            Return Today.Year
        End Try
    End Function

    Public Function IncassiFigura(Figura As Integer,
                                  Anno As Integer,
                                  RamoGestione As Integer) As Double

        'restituisce l'incasso di una figura nell'anno
        Try
            Dim Query As String = "SELECT COALESCE({0},0) AS Totale 
                FROM Incassi 
                WHERE YEAR(DataFoglioCassa) = {1} AND {2} AND {3}"

            Dim WhereFigura As String
            If Figura = 0 Then
                'tutta l'agenzia
                WhereFigura = "1=1"
            Else
                WhereFigura = String.Format("(CodiceSubAgente = {0} OR CodiceProduttore = {0})", Figura)
            End If

            'a seconda dei rg bisogna togliere o aggiungere le garanzie RE del rg 1
            Dim Somma, Dove As String
            Select Case RamoGestione
                Case 1 : Somma = "SUM(PremioRC)" : Dove = "RamoGestione = 1"
                Case 2 : Somma = "SUM(Iif(RamoGestione = 1,PrIF + PrKasko + PrAssistenza,Tassabile))" : Dove = "RamoGestione IN (1,2)"
                Case 3 : Somma = "SUM(Iif(RamoGestione < 3,PrINF,Tassabile))" : Dove = "RamoGestione IN (1,2,3)"
                Case Else : Somma = "SUM(Tassabile)" : Dove = "RamoGestione = " + RamoGestione.ToString
            End Select
            Query = String.Format(Query, Somma, Anno, Dove, WhereFigura)

            Return Utx.WsCommand.ExecuteScalar(Query).Valore

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return 0
        End Try
    End Function

    Public Function IncassiFigure(Agenzia As String,
                                  Anno As Integer,
                                  RamoGestione As Integer) As DataTable
        '+restituisce l'incasso totale per ogni figura per un determinato ramo gestione
        Try
            Dim Query As String = "SELECT CodiceSubAgente,{0} AS Totale 
                FROM Incassi 
                WHERE (YEAR(DataFoglioCassa) = {1}) AND ({2})
                GROUP BY CodiceSubAgente"

            'a seconda dei rg bisogna togliere o aggiungere le garanzie RE del rg 1
            Dim Somma, Dove As String
            Select Case RamoGestione
                Case 1 : Somma = "SUM(PremioRC)" : Dove = "RamoGestione = 1"
                Case 2 : Somma = "SUM(Iif(RamoGestione = 1,PrIF + PrKasko + PrAssistenza,Tassabile))" : Dove = "RamoGestione IN (1,2)"
                Case 3 : Somma = "SUM(Iif(RamoGestione = 1,PrINF,Tassabile))" : Dove = "RamoGestione IN (1,3)"
                Case Else : Somma = "SUM(Tassabile)" : Dove = "RamoGestione = " + RamoGestione.ToString
            End Select
            Query = String.Format(Query, Somma, Anno, Dove)

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(Query, Agenzia)
            If Risposta Is Nothing Then
                Return New DataTable
            Else
                'calcolo il totale per l'agenzia
                Dim TotaleAgenzia As Double = 0
                For Each row As DataRow In Risposta.DataTable.Rows
                    TotaleAgenzia += row("Totale")
                Next
                Risposta.DataTable.Rows.Add({0, TotaleAgenzia})
                Return Risposta.DataTable
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return New DataTable
        End Try
    End Function

    Public Function IncassiAgenzia(Anno As Integer,
                                   RamoGestione As Integer) As Double
        'restituisce l'incasso dell'agenzia per il ramo e l'anno richiesto
        Try
            Dim Query As String = "SELECT {0} AS Totale 
                FROM LinkIncassi 
                WHERE YEAR(DataFoglioCassa) = {1} AND {2}"

            'a seconda dei rg bisogna togliere o aggiungere le garanzie RE del rg 1
            Dim Somma, Dove As String
            Select Case RamoGestione
                Case 1 : Somma = "SUM(PremioRC)" : Dove = "RamoGestione = 1"
                Case 2 : Somma = "SUM(Iif(RamoGestione = 1,PremioARD,Tassabile))" : Dove = "RamoGestione IN (1,2)"
                Case 3 : Somma = "SUM(Iif(RamoGestione = 1,PrINF,Tassabile))" : Dove = "RamoGestione IN (1,3)"
                Case Else : Somma = "SUM(Tassabile)" : Dove = "RamoGestione = " + RamoGestione.ToString
            End Select
            Query = String.Format(Query, Somma, Anno, Dove)

            Return Utx.WsCommand.ExecuteScalar(Query).Valore

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return 0
        End Try
    End Function

    Friend Function NumeroUSA(Numero As String) As String
        NumeroUSA = Replace(Numero, ",", ".")
    End Function

    Public Sub LogProc(Metodo As Reflection.MethodBase, Azione As ProcEvent)

#If DEBUG Then
        Dim Passo As Integer = 3
        Static Indent As Integer = -Passo

        If Azione = ProcEvent.ENTRATA Then
            Indent += Passo
            Log.Info(String.Format("{0}Entra: {1}", Space(Indent), Metodo.ToString))
        Else
            Indent -= Passo
            Log.Info(String.Format("{0}Esce: {1}", Space(Indent), Metodo.Name))
        End If
#End If
    End Sub
End Module
