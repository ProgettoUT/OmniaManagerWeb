Imports System.Text

Public Class QueryClienti
    Public Property IDStatoCliente As String
    Public Property TipoFiltro As String
    Public Property ValoreFiltro As String
    Public Property CorrispondenzaEsatta As Boolean
    Public Property EstraiTutti As Boolean

    Public Function CommandText() As String
        Try
            Return QueryBaseCompleta()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
        End Try

        Return ""
    End Function

    Private Function QueryBaseCompleta() As String

        If EstraiTutti = False And ValoreFiltro = "" Then
            Return ""
        End If

        Dim NomeCliente As String = "RTrim(RTrim(Cognome) + Space(1) + IIf(Len(Nome) > 0, RTrim(Nome), Space(0)))"

        Dim sb As New StringBuilder
        With sb
            .Append("SELECT DISTINCT CodiceFiscale,CodiceFiscaleCF,CodiceFiscaleEA, {0} AS Cliente,")
            .Append("Indirizzo,CAP,Localita,Provincia,DataNascita,Sesso,IDStatoCliente,")
            .Append("SubAgenzia,Produttore,ConsensoPrivacy,TipoCliente,")
            .Append("TELEFONO1,TELEFONO2,EMAIL,CELLULARE,CodAvvisoScadenza,")
            .Append("Iif(Len(RTrim(CELLULARE)) > 0,CELLULARE,RisCellulare) As Mobile,")
            .Append("FLAG1,FLAG2,FLAG3,")
            .Append("LiquidatoTotale,PremiTotale,RisTelefono,RisCellulare,RisMail,")
            .Append("RisTelefonoNota,RisCellulareNota,RisMailNota,ClienteTop,DataInserimento,AutorizzazioneFEA ")
            .Append("FROM Clienti ")
            .Append("WHERE 1 = 1 ")

            If IDStatoCliente <> "TT" Then
                .AppendFormat(" AND IDStatoCliente = {0}", Utx.FunzioniDb.TO_STRING(IDStatoCliente))
            End If

            If EstraiTutti = False Then
                If String.IsNullOrEmpty(ValoreFiltro) = False Then
                    ValoreFiltro = ValoreFiltro.Replace("""", "").Replace("'", "''").Trim()
                    Dim Operatore As String = IIf(CorrispondenzaEsatta, "", "%")
                    If TipoFiltro = "A" Then 'ricerca per assicurato
                        .AppendFormat(" AND ({0} LIKE '{1}{2}%')", NomeCliente, Operatore, ValoreFiltro)
                    ElseIf TipoFiltro = "T" Then ' ricerca per targa
                        .AppendFormat(" AND CodiceFiscale IN (SELECT CodiceFiscale FROM Polizze WHERE Targa LIKE '{0}{1}%')", Operatore, ValoreFiltro.Replace(" ", ""))
                    ElseIf TipoFiltro = "C" Then ' ricerca per codice fiscale
                        If ValoreFiltro.Length = 16 Or ValoreFiltro.Length = 11 Then
                            .AppendFormat(" AND CodiceFiscale = {0}", Utx.FunzioniDb.TO_STRING(ValoreFiltro))
                        Else
                            .AppendFormat(" AND CodiceFiscale LIKE '{0}{1}%'", Operatore, ValoreFiltro)
                        End If
                    ElseIf TipoFiltro = "N" Then ' ricerca per note
                        Dim ClausolaWhere As String = ""
                        For Each p As String In Split(ValoreFiltro.Replace("""", "").Replace("'", ""), Space(1))
                            ClausolaWhere &= String.Format(" AND (Memo LIKE '%{0}%')", p.Trim)
                        Next
                        .AppendFormat(" AND CodiceFiscale IN (SELECT CodiceFiscale FROM SinistriMemo WHERE IdNota = CodiceFiscale {0})", ClausolaWhere)
                    ElseIf TipoFiltro = "R" Then ' ricerca per note redattore
                        Dim ClausolaWhere As String = ""
                        For Each p As String In Split(ValoreFiltro.Replace("""", "").Replace("'", ""), Space(1))
                            ClausolaWhere &= String.Format(" AND (Utente LIKE '%{0}%')", p.Trim)
                        Next
                        .AppendFormat(" AND CodiceFiscale IN (SELECT CodiceFiscale FROM SinistriMemo WHERE IdNota = CodiceFiscale {0})", ClausolaWhere)
                    ElseIf TipoFiltro = "V" Then ' ricerca per attività
                        .AppendFormat(" AND CodiceFiscale IN (SELECT DISTINCT CodiceFiscale FROM SinistriMemo WHERE Tipo = 'A' AND IdNota = CodiceFiscale AND Allarme BETWEEN {0})", ValoreFiltro)
                    End If
                End If
            End If

            .Append(" ORDER BY 4")
        End With

        QueryBaseCompleta = String.Format(sb.ToString, NomeCliente)
    End Function

    Public Shared Function QueryBaseCompletaAttivita(Inizio As Date, Fine As Date) As String
        Try
            Dim CF As String = "'X'"
            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy
                CF = s.ElencoNoteClienti(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Inizio, Fine, Utx.Globale.Token)
            End Using

            Dim NomeCliente As String = "RTrim(RTrim(Cognome) + Space(1) + IIf(Len(Nome) > 0, RTrim(Nome), Space(0)))"

            Dim sb As New StringBuilder
            With sb
                .Append("SELECT DISTINCT CodiceFiscale,CodiceFiscaleCF,CodiceFiscaleEA, {0} AS Cliente,")
                .Append("Indirizzo,CAP,Localita,Provincia,DataNascita,Sesso,IDStatoCliente,")
                .Append("SubAgenzia,Produttore,ConsensoPrivacy,TipoCliente,")
                .Append("TELEFONO1,TELEFONO2,EMAIL,CELLULARE,CodAvvisoScadenza,")
                .Append("Iif(Len(RTrim(CELLULARE)) > 0,CELLULARE,RisCellulare) As Mobile,")
                .Append("FLAG1,FLAG2,FLAG3,")
                .Append("LiquidatoTotale,PremiTotale,RisTelefono,RisCellulare,RisMail,")
                .Append("RisTelefonoNota,RisCellulareNota,RisMailNota,ClienteTop,DataInserimento ")
                .Append("FROM Clienti ")
                .Append("WHERE CodiceFiscale IN ({1}) ")
                .Append("ORDER BY 4")
            End With

            Return String.Format(sb.ToString, NomeCliente, CF)

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function
End Class
