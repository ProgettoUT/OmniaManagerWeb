Imports mshtml

Public Class Cattura

    Public Event CatturatoCliente(codicefiscale As String)

    Dim th As Threading.Thread

    Public Function DaEssig(d As IHTMLDocument3) As Boolean
        Try
            Dim htmltitle As IHTMLTitleElement = d.getElementsByTagName("title").item(0)
            Dim title = htmltitle.text

            If th IsNot Nothing Then
                th.Join()
            End If

            Select Case title.ToString.Trim.ToUpper
                Case "SITUAZIONE CLIENTE - DETTAGLIO"
                    ClienteDaEssig(d)
                    'th = New Threading.Thread(AddressOf ClienteDaEssig)
                    'th.Start(d)
                Case "SITUAZIONE CLIENTE - POLIZZE"
                    th = New Threading.Thread(AddressOf PolizzeDaEssig)
                    th.Start(d)
            End Select
            Return True
        Catch ex As Exception
            ' NON FA NULLA
            Utx.Globale.Log.Info(ex)
        End Try
        Return False
    End Function

    Private Function GetValueById(d As IHTMLDocument3, ByRef tagId As String) As String
        Try
            Dim element As IHTMLInputElement = d.getElementById(tagId)
            If element IsNot Nothing Then
                Return element.value
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function isCellulare(ByRef telefono As String) As Boolean
        If Not String.IsNullOrEmpty(telefono) Then
            If telefono.StartsWith("+393") Or telefono.StartsWith("3") Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Function ClienteDaEssig(d As IHTMLDocument3) As Boolean
        Dim codiceFiscale As String = ""
        Try
            '1) leggo i dati dal documento html
            codiceFiscale = GetValueById(d, "codiceFiscale").ToString.Trim
            Dim TipoCliente As String = GetValueById(d, "tipoClientePrime3") & GetValueById(d, "tipoClienteUltime2")
            Dim Agenzia As String = GetValueById(d, "agenzia.value").PadLeft(5, "0")
            Dim SubAgenzia As String = GetValueById(d, "subagente.value")
            Dim CodAvvisoScadenza As String = GetValueById(d, "avvisoScadenza.value")
            Dim Fax As String = GetValueById(d, "fax")
            Dim Email As String = GetValueById(d, "email")
            Dim ClienteTop As String = GetValueById(d, "clienteTop")
            'Dim DataNascita As String = GetValueById(d, "")

            '2) dati che richiedono una elaborazione
            '2.1) sesso
            Dim sesso As String = ""
            If IsNumeric(codiceFiscale) Then
                sesso = "N"
            ElseIf Mid(codiceFiscale, 10, 2) > 40 Then
                sesso = "F"
            Else
                sesso = "M"
            End If

            '2.2) nominativo
            Dim nomeCompleto As String = GetValueById(d, "cognomeRagSociale").Trim

            Dim cognome As String = ""
            Dim nome As String = ""

            If sesso = "N" Then 'piva
                cognome = Left(nomeCompleto.Trim, 40).Trim
                nome = ""
            Else
                'cerco lo spazio
                Dim pos As Integer = nomeCompleto.IndexOf(" "c)
                'se lo trovo
                If pos >= 0 Then
                    cognome = Left(Left(nomeCompleto, pos).Trim, 40)
                    nome = Mid(nomeCompleto, pos + 1, 25).Trim
                End If
            End If

            '2.3) Indirizzo
            Dim indirizzoCompleto As String = GetValueById(d, "residenza")
            Dim indirizzo As String = ""
            Dim cap As String = ""
            Dim localita As String = ""
            Dim provincia As String = ""

            'tipo stringa residenza:
            'C.SO EUROPA, 16,  80027,  FRATTAMAGGIORE,  NA,  ITALIA
            'oppure:
            'C.SO EUROPA 16,  80027,  FRATTAMAGGIORE,  NA,  ITALIA
            Dim Campi() As String = indirizzoCompleto.Split(","c)

            Select Case Campi.Length
                Case 5
                    indirizzo = Campi(0).Trim
                    cap = Campi(1).Trim
                    localita = Campi(2).Trim
                    provincia = Campi(3).Trim
                Case 6
                    indirizzo = Campi(0).Trim & " " & Campi(1).Trim
                    cap = Campi(2).Trim
                    localita = Campi(3).Trim
                    provincia = Campi(4).Substring(0, 2).Trim
                Case Else
                    indirizzo = indirizzoCompleto
            End Select

            indirizzo = Left(indirizzo.Trim, 35)
            localita = Left(localita.Trim, 30)

            '2.4) Telefoni

            Dim Telefono1 As String = GetValueById(d, "telefono1")
            Dim Telefono2 As String = GetValueById(d, "telefono2")
            Dim Cellulare As String = GetValueById(d, "telefono3")

            If Not isCellulare(Cellulare) Then
                Dim c As String = Cellulare
                If isCellulare(Telefono1) Then
                    Cellulare = Telefono1
                    Telefono1 = c
                ElseIf isCellulare(Telefono2) Then
                    Cellulare = Telefono2
                    Telefono2 = c
                End If
            End If

            '2.5) Privacy
            Dim pos1 As Integer = d.body.innertext.indexof("Privacy Commerciale stato:") + 27
            Dim pos2 As Integer = d.body.innertext.indexof("Data inizio")

            Dim privacy As String = Mid(d.body.innertext, pos1, pos2 - pos1).Trim
            pos1 = privacy.IndexOf("Tipo:") + 6
            privacy = Mid(privacy, pos1)

            Dim ConsensoPrivacy As String = Utx.Essig.CodificaPrivacy(privacy)

            '3) controllo se esiste il cliente nella tabella
            Dim nuovoCliente As Boolean = False
            Dim Query As String = String.Format("SELECT COUNT(*) FROM Clienti WHERE CodiceFiscale = {1}",
                                                Utx.FunzioniDb.TO_NUMBER(Agenzia), Utx.FunzioniDb.TO_STRING(codiceFiscale))
            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteScalar(Query, Agenzia)

            If Risposta IsNot Nothing Then
                nuovoCliente = (Risposta.Valore = 0)

                Query = ""

                '4) Inserisco o aggiorno il cliente
                If nuovoCliente Then
                    Query = "INSERT INTO clienti (CodiceFiscale, Cognome, Nome, IDStatoCliente, DataInserimento, 
                    Indirizzo, Cap, Localita, Provincia, Sesso, Telefono1, Telefono2, Cellulare, Fax, Email, 
                    SubAgenzia, TipoCliente, AgenziaPrevalente, ClienteTop, ConsensoPrivacy, CodAvvisoScadenza)
                    VALUES "
                    Query &= "( " & Utx.FunzioniDb.TO_STRING(codiceFiscale)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(cognome)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(nome)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING("EF")
                    Query &= ", " & Utx.FunzioniDb.TO_DATE(Today)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(indirizzo)
                    Query &= ", " & Utx.FunzioniDb.TO_NUMBER(cap)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(localita)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(provincia)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(sesso)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(Telefono1)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(Telefono2)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(Cellulare)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(Fax)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(Email)
                    Query &= ", " & Utx.FunzioniDb.TO_NUMBER(SubAgenzia)
                    Query &= ", " & Utx.FunzioniDb.TO_NUMBER(TipoCliente)
                    Query &= ", " & Utx.FunzioniDb.TO_NUMBER(Agenzia)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(ClienteTop)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(ConsensoPrivacy)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(CodAvvisoScadenza)
                    Query &= ")"
                Else
                    Query = "UPDATE clienti SET"
                    Query &= "  Cognome = " & Utx.FunzioniDb.TO_STRING(cognome)
                    Query &= ", Nome = " & Utx.FunzioniDb.TO_STRING(nome)
                    Query &= ", Indirizzo = " & Utx.FunzioniDb.TO_STRING(indirizzo)
                    Query &= ", Cap = " & Utx.FunzioniDb.TO_NUMBER(cap)
                    Query &= ", Localita = " & Utx.FunzioniDb.TO_STRING(localita)
                    Query &= ", Provincia = " & Utx.FunzioniDb.TO_STRING(provincia)
                    Query &= ", Sesso = " & Utx.FunzioniDb.TO_STRING(sesso)
                    Query &= ", Telefono1 = " & Utx.FunzioniDb.TO_STRING(Telefono1)
                    Query &= ", Telefono2 = " & Utx.FunzioniDb.TO_STRING(Telefono2)
                    Query &= ", Cellulare = " & Utx.FunzioniDb.TO_STRING(Cellulare)
                    Query &= ", Fax = " & Utx.FunzioniDb.TO_STRING(Fax)
                    Query &= ", Email = " & Utx.FunzioniDb.TO_STRING(Email)
                    Query &= ", SubAgenzia = " & Utx.FunzioniDb.TO_NUMBER(SubAgenzia)
                    Query &= ", TipoCliente = " & Utx.FunzioniDb.TO_NUMBER(TipoCliente)
                    Query &= ", ClienteTop = " & Utx.FunzioniDb.TO_STRING(ClienteTop)
                    Query &= ", ConsensoPrivacy = " & Utx.FunzioniDb.TO_STRING(ConsensoPrivacy)
                    Query &= ", CodAvvisoScadenza = " & Utx.FunzioniDb.TO_STRING(CodAvvisoScadenza)
                    Query &= " WHERE AgenziaPrevalente = " & Utx.FunzioniDb.TO_NUMBER(Agenzia)
                    Query &= " AND CodiceFiscale = " & Utx.FunzioniDb.TO_STRING(codiceFiscale)
                End If

                Utx.WsCommand.ExecuteNonQuery(Query, Agenzia)
            End If

            '5) selezione del cliente
            RaiseEvent CatturatoCliente(codiceFiscale)
            Return True

        Catch ex As Exception
            Utx.Globale.Log.Info("Codice fiscale che ha generato l'errore: {0}", {codiceFiscale})
            Utx.Globale.Log.Info(ex)
            Return False
        End Try
    End Function

    Private Function PolizzeDaEssig(d As IHTMLDocument3) As Boolean
        '1) controllo se esiste il cliente
        '2) legge tutte le polizze elencate in elenco
        Dim codiceFiscale As String = ""
        Try
            codiceFiscale = GetValueById(d, "codiceFiscale")
            Utx.Globale.Log.Info("cattura del cliente", {codiceFiscale})

            Dim HtmlTablePolizze As IHTMLTable = d.getElementById("risultato")

            Dim elencoPolizze As String = ""
            Dim Query As String = ""

            For i = 1 To HtmlTablePolizze.rows.length - 1
                Dim HtmlRowPolizza As IHTMLTableRow = HtmlTablePolizze.rows.item(i)

                Dim Agenzia As String = Utx.FunzioniHtml.GetValueCell(HtmlRowPolizza, 1).Trim
                Dim Ramo As String = Utx.FunzioniHtml.GetValueCell(HtmlRowPolizza, 2).Trim
                Dim Polizza As String = Utx.FunzioniHtml.GetValueCell(HtmlRowPolizza, 3).Trim
                Dim CodiceProdotto As String = Utx.FunzioniHtml.GetValueCell(HtmlRowPolizza, 4)
                Dim DataEffetto As String = Utx.FunzioniHtml.GetValueCell(HtmlRowPolizza, 5)
                Dim DataPrimaQuietanza As String = Utx.FunzioniHtml.GetValueCell(HtmlRowPolizza, 6)
                Dim DataScadenza As String = Utx.FunzioniHtml.GetValueCell(HtmlRowPolizza, 6)
                Dim Frazionamento As String = Utx.FunzioniHtml.GetValueCell(HtmlRowPolizza, 7)
                Dim Premio As String = Utx.FunzioniHtml.GetValueCell(HtmlRowPolizza, 8) : If String.IsNullOrEmpty(Premio) Then Premio = 0
                Dim Targa As String = Utx.FunzioniHtml.GetValueCell(HtmlRowPolizza, 9)
                Dim RamoGestione As Integer = Utx.FunzioniDb.RamoPolizza2RamoGestione(Ramo)

                If String.IsNullOrEmpty(Frazionamento) Then Frazionamento = "0"

                If String.IsNullOrEmpty(Ramo) OrElse String.IsNullOrEmpty(Polizza) OrElse String.IsNullOrEmpty(Agenzia) Then
                    Throw New System.Exception("CATTURA POLIZZE: CAMPI VUOTI")
                End If

                elencoPolizze &= String.Format(", '{0}/{1}/{2}'", Agenzia, Ramo, Polizza)

                '3) controlla se la polizza esiste
                Dim nuovaPolizza As Boolean = False
                Query = String.Format("SELECT COUNT(*) FROM Polizze
                    WHERE Agenzia = {0} AND Ramo = {1} AND Polizza = {2}", Agenzia, Ramo, Polizza)

                Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteScalar(Query)
                If Risposta IsNot Nothing Then
                    nuovaPolizza = Risposta.Valore = 0
                End If

                Query = ""

                If nuovaPolizza = True Then
                    '4) inserisco nuova polizza
                    Query = "INSERT INTO Polizze (CodiceFiscale, CodiceFiscaleCF, Agenzia, Ramo, Polizza, CodiceProdotto, 
                        DataEffetto, DataPrimaQuietanza, DataScadenza, Frazionamento, Targa, RamoGestione, TotalePremioAnnuo, 
                        CodiceSubAgente, CodiceProduttore, CavalliFiscali, Convenzione, ClasseBonusMalus)
                        VALUES "
                    Query &= "( " & Utx.FunzioniDb.TO_STRING(codiceFiscale)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING("xxx")
                    Query &= ", " & Utx.FunzioniDb.TO_NUMBER(Agenzia)
                    Query &= ", " & Utx.FunzioniDb.TO_NUMBER(Ramo)
                    Query &= ", " & Utx.FunzioniDb.TO_NUMBER(Polizza)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(CodiceProdotto)
                    Query &= ", " & Utx.FunzioniDb.TO_DATE(DataEffetto)
                    Query &= ", " & Utx.FunzioniDb.TO_DATE(DataPrimaQuietanza)
                    Query &= ", " & Utx.FunzioniDb.TO_DATE(DataScadenza)
                    Query &= ", " & Utx.FunzioniDb.TO_NUMBER(Frazionamento)
                    Query &= ", " & Utx.FunzioniDb.TO_STRING(Targa.Replace(" ", ""))
                    Query &= ", " & RamoGestione
                    Query &= ", " & Premio
                    Query &= ",0,0,0,0,0)"
                Else
                    Query = String.Format("UPDATE Polizze
                        SET CodiceProdotto = '{0}', DataEffetto = '{1:dd/MM/yyyy}', DataScadenza = '{2:dd/MM/yyyy}', Targa = {3},
                            Frazionamento = {4}, TotalePremioAnnuo = {5}, RamoGestione = {6}
                        WHERE Ramo = {7} AND Polizza = {8}",
                          CodiceProdotto, DataEffetto, DataScadenza, Utx.FunzioniDb.TO_STRING(Targa.Replace(" ", "")),
                          Frazionamento, Premio, RamoGestione, Ramo, Polizza)
                End If
                Utx.WsCommand.ExecuteNonQuery(Query)
            Next

            If elencoPolizze.Length > 0 Then
                elencoPolizze = elencoPolizze.Substring(2) 'tolgo la virgola iniziale

                'elimino le polizze non più in vigore
                Utx.FunzioniDb.ExecuteNonQuery(String.Format("DELETE FROM Polizze WHERE CodiceFiscale = '{0}' AND (Trim(Agenzia) + '/' + Trim(Ramo) + '/' + Trim(Polizza) NOT IN ({1}))", codiceFiscale, elencoPolizze))

                'cambio lo stato del cliente in effettivo
                Utx.FunzioniDb.ExecuteNonQuery("UPDATE Clienti SET IdStatoCliente = 'EF' WHERE CodiceFiscale =" & Utx.FunzioniDb.TO_STRING(codiceFiscale))

                'aggiorno la subagenzia di polizza approssimandola a quella del cliente
                Query = "UPDATE P
                    SET P.CodiceSubAgente = C.SubAgenzia
                    FROM Polizze AS P
                    INNER JOIN Clienti C ON P.CodiceFiscale = C.CodiceFiscale
                    WHERE P.CodiceSubAgente IS NULL"
                Utx.WsCommand.ExecuteNonQuery(Query)
            End If

            '5) selezione del cliente
            RaiseEvent CatturatoCliente(codiceFiscale)
            Return True

        Catch ex As Exception
            Utx.Globale.Log.Info("Codice fiscale che ha generato l'errore: {0}", {codiceFiscale})
            Utx.Globale.Log.Errore(ex, False)
            Return False
        End Try
    End Function
End Class
