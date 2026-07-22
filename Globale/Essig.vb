
Public Class Essig

    Public Shared Portale As AutenticazioneEssig
    Private Shared ReadOnly Campi As String() = {"cognomeRagSociale", "residenza", "telefono1", "telefono2", "telefono3", "fax", "email", "sesso", "eta",
        "descrizioneComuneNascita", "tipoClientePrime3", "tipoClienteDesc", "tipoClienteUltime2", "tipoClienteDescMercPref", "recapito",
        "nomeReferente", "telefonoReferente", "codTipoDocumento", "descDocumento", "numDocumento", "dataRilascio", "autoritaDocumento",
        "luogoDocumento", "autoritaRilascio", "subagente.value", "produttore.value", "matricolaDipendente", "codConvenzioneTrattenuta",
        "codAzienda", "modalitaIncasso.value", "avvisoScadenza.value", "dalQt", "alQt", "clienteTop", "dataTop", "agenziaPrevalente",
        "zona.value", "dataInizioConsenso", "dataRevocaConsenso", "privacy"}

    Public Shared Function LeggiDatiCliente(CodiceFiscale As String, Agenzia As String) As DataTable
        Dim dt As DataTable = Nothing
        Try
            If Portale Is Nothing Then
                Portale = New AutenticazioneEssig
                Portale.LogIn()
            End If

            If Portale.IsLogged Then
                'chiamo il menù
                Dim menu As String = Portale.CallWeb(Portale.UrlBase & "essigSC/start.do?itemId=0101000000&parametri=SC++SC")
                If menu.Contains("La sessione di lavoro deve essere interotta") Then
                    Return Nothing
                End If

                'cerco il cliente
                Dim cliente As String = Portale.CallWeb(Portale.UrlBase & "essigSC/danni/situazionecliente/pagina00.do",
                                                        "nomePaginaAlbero=&flagDatiCambiati=&agenzia.value=" & Val(Agenzia).ToString &
                                                        "&descrizioneAgenzia.value=&codiceFiscale.value=" & CodiceFiscale &
                                                        "&cognomeRagSociale.value=&ACTIONBUTTON018=Conferma")

                If cliente.IndexOf("Cliente - Dettaglio") > 0 Then
                    Dim dom As mshtml.HTMLDocument = Utx.FunzioniHtml.Html2Dom(cliente, "clienti")

                    Utx.Globale.Log.Info("catturato {0}", {CodiceFiscale})

                    dt = New DataTable()
                    For Each campo As String In Campi
                        dt.Columns.Add(New DataColumn(campo.Replace(".value", "")))
                    Next

                    Dim row As DataRow = dt.NewRow
                    For Each campo As String In Campi
                        Dim el As mshtml.IHTMLElement = dom.getElementById(campo)
                        If el Is Nothing Then
                            row.Item(campo.Replace(".value", "")) = DBNull.Value
                        Else
                            row.Item(campo.Replace(".value", "")) = Utx.FunzioniDb.NullNothingToString(el.getAttribute("value"))
                        End If
                    Next
                    'analisi privacy
                    Dim privacy As String = Mid(cliente, cliente.IndexOf("Privacy Commerciale stato:"), 1000)
                    privacy = Mid(privacy, privacy.IndexOf("colspan=""4""") + 16, 100)
                    privacy = privacy.Split("</b>")(0).Trim
                    row.Item("privacy") = CodificaPrivacy(privacy)

                    dt.Rows.Add(row)

                    '+normalizzo i dati e salvo
                    ElaboraDatiCliente(CodiceFiscale, dt, Agenzia)
                End If
            End If
            Return dt
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            Return Nothing
        End Try
    End Function

    Private Shared Sub ElaboraDatiCliente(CodiceFiscale As String, dt As DataTable, Agenzia As String)
        Try
            If (dt IsNot Nothing) AndAlso (dt.Rows.Count > 0) Then
                Dim Cliente As DataRow = dt.Rows(0)

                '2) dati che richiedono una elaborazione
                '2.1) sesso
                If IsNumeric(CodiceFiscale) Then
                    Cliente("Sesso") = "N"
                ElseIf CodiceFiscale.Trim.Length < 16 Then
                    'serve per le società estere (vedi san marino)
                    Cliente("Sesso") = "N"
                ElseIf Mid(CodiceFiscale, 10, 2) > 40 Then
                    Cliente("Sesso") = "F"
                Else
                    Cliente("Sesso") = "M"
                End If

                '2.2) nominativo
                Dim nomeCompleto As String = Cliente("cognomeRagSociale").Trim

                Dim cognome As String = Left(nomeCompleto.Trim, 40).Trim
                Dim nome As String = ""

                If Cliente("Sesso") <> "N" Then
                    'cerco lo spazio
                    Dim pos As Integer = nomeCompleto.IndexOf(" "c)
                    'se lo trovo
                    If pos >= 0 Then
                        cognome = Left(nomeCompleto, pos).Trim
                        nome = Mid(nomeCompleto, pos + 1, 25).Trim
                    End If
                End If

                '2.3) Indirizzo
                Dim indirizzoCompleto As String = Cliente("residenza")
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
                Dim Telefono1 As String = Cliente("telefono1")
                Dim Telefono2 As String = Cliente("telefono2")
                Dim Cellulare As String = Cliente("telefono3")

                If Not Utx.NetFunc.IsCellulare(Cellulare) Then
                    Dim c As String = Cellulare
                    If Utx.NetFunc.IsCellulare(Telefono1) Then
                        Cellulare = Telefono1
                        Telefono1 = c
                    ElseIf Utx.NetFunc.IsCellulare(Telefono2) Then
                        Cellulare = Telefono2
                        Telefono2 = c
                    End If
                End If
                'agenzia prevalente
                Dim AgenziaPrevalente As String
                If Cliente("AgenziaPrevalente") Is DBNull.Value Then
                    AgenziaPrevalente = Utx.Globale.AgenziaRichiesta.CodiceAgenzia
                Else
                    AgenziaPrevalente = Cliente("AgenziaPrevalente")
                End If

                'inserisco/aggiorno  cliente
                Dim sql As String = String.Format("SELECT COUNT(*) 
                    FROM Clienti 
                    WHERE AgenziaPrevalente = {0} AND CodiceFiscale = '{1}'", Agenzia, CodiceFiscale)

                If Utx.WsCommand.ExecuteScalar(sql).Valore = 0 Then
                    Utx.Globale.Log.Info("inserisco {0} - {1} {2} nel db", {CodiceFiscale, cognome, nome})
                    '+nuovo cliente
                    sql = "INSERT INTO clienti (CodiceFiscale, Cognome, Nome, IDStatoCliente, DataInserimento"
                    sql &= ", Indirizzo, Cap, Localita, Provincia, Sesso, Telefono1, Telefono2, Cellulare"
                    sql &= ", Fax, Email, SubAgenzia, TipoCliente, AgenziaPrevalente, ClienteTop, CodAvvisoScadenza, ConsensoPrivacy)"
                    sql &= " VALUES "
                    sql &= "( " & Utx.FunzioniDb.TO_STRING(CodiceFiscale)
                    sql &= ", " & Utx.FunzioniDb.TO_STRING(cognome)
                    sql &= ", " & Utx.FunzioniDb.TO_STRING(nome)
                    sql &= ", " & Utx.FunzioniDb.TO_STRING("EF")
                    sql &= ", " & Utx.FunzioniDb.TO_DATE(Today)
                    sql &= ", " & Utx.FunzioniDb.TO_STRING(indirizzo)
                    sql &= ", " & Utx.FunzioniDb.TO_NUMBER(cap)
                    sql &= ", " & Utx.FunzioniDb.TO_STRING(localita)
                    sql &= ", " & Utx.FunzioniDb.TO_STRING(provincia)
                    sql &= ", " & Utx.FunzioniDb.TO_STRING(Cliente("sesso"))
                    sql &= ", " & Utx.FunzioniDb.TO_STRING(Telefono1)
                    sql &= ", " & Utx.FunzioniDb.TO_STRING(Telefono2)
                    sql &= ", " & Utx.FunzioniDb.TO_STRING(Cellulare)
                    sql &= ", " & Utx.FunzioniDb.TO_STRING(Cliente("Fax"))
                    sql &= ", " & Utx.FunzioniDb.TO_STRING(Cliente("Email"))
                    sql &= ", " & Utx.FunzioniDb.TO_NUMBER(Cliente("SubAgente"))
                    sql &= ", " & Utx.FunzioniDb.TO_NUMBER(Cliente("TipoClientePrime3") & Cliente("TipoClienteUltime2"))
                    sql &= ", " & AgenziaPrevalente
                    sql &= ", '" & Utx.FunzioniDb.NullToString(Cliente("ClienteTop")) & "'"
                    sql &= ", '" & Utx.FunzioniDb.NullToString(Cliente("AvvisoScadenza")) & "'"
                    sql &= ", '" & Utx.FunzioniDb.NullToString(Cliente("Privacy")) & "'"
                    sql &= ")"
                Else
                    Utx.Globale.Log.Info("aggiorno {0} - {1} {2} nel db", {CodiceFiscale, cognome, nome})
                    '+aggiornamento
                    sql = "UPDATE clienti SET"
                    sql &= "  Indirizzo = " & Utx.FunzioniDb.TO_STRING(indirizzo)
                    sql &= ", Cap = " & Utx.FunzioniDb.TO_NUMBER(cap)
                    sql &= ", Localita = " & Utx.FunzioniDb.TO_STRING(localita)
                    sql &= ", Provincia = " & Utx.FunzioniDb.TO_STRING(provincia)
                    sql &= ", Sesso = " & Utx.FunzioniDb.TO_STRING(Cliente("sesso"))
                    sql &= ", Telefono1 = " & Utx.FunzioniDb.TO_STRING(Telefono1)
                    sql &= ", Telefono2 = " & Utx.FunzioniDb.TO_STRING(Telefono2)
                    sql &= ", Cellulare = " & Utx.FunzioniDb.TO_STRING(Cellulare)
                    sql &= ", Fax = " & Utx.FunzioniDb.TO_STRING(Cliente("Fax"))
                    sql &= ", Email = " & Utx.FunzioniDb.TO_STRING(Cliente("Email"))
                    sql &= ", SubAgenzia = " & Utx.FunzioniDb.TO_NUMBER(Cliente("SubAgenzia"))
                    sql &= ", TipoCliente = " & Utx.FunzioniDb.TO_NUMBER(Cliente("TipoClientePrime3") & Cliente("TipoClienteUltime2"))
                    sql &= ", ClienteTop = '" & Utx.FunzioniDb.NullToString(Cliente("ClienteTop")) & "'"
                    sql &= ", CodAvvisoScadenza = '" & Utx.FunzioniDb.NullToString(Cliente("AvvisoScadenza")) & "'"
                    sql &= ", ConsensoPrivacy = '" & Utx.FunzioniDb.NullToString(Cliente("Privacy")) & "'"
                    sql &= " WHERE AgenziaPrevalente = " & AgenziaPrevalente
                    sql &= " AND CodiceFiscale = " & Utx.FunzioniDb.TO_STRING(CodiceFiscale)
                End If
                Utx.WsCommand.ExecuteNonQuery(sql)
            End If
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub

    Public Shared Function CodificaPrivacy(Descrizione As String) As String
        Select Case Descrizione
            Case "CONSENSO MANCANTE" : Return "CM"
            Case "CONSENSO PARZIALE" : Return "CP"
            Case "CG - ANTE 2009" : Return "CG"
            Case "01 CONTATTO - FEB09" : Return "01"
            Case "01+02 CONTATTO E PROFILAZIONE - FEB09" : Return "02"
            Case "01 CONTATTO - MAG18" : Return "03"
            Case "01+02 CONTATTO E PROFILAZIONE - MAG18" : Return "04"
            Case "01+03 CONTATTO E GRUPPO - MAG18" : Return "05"
            Case "01+02+03 CONTATTO PROFILAZIONE E GRUPPO - MAG18" : Return "06"
            Case Else : Return "NN"
        End Select
    End Function

    Public Shared Function DecodificaPrivacy(Codice As String) As String
        Select Case Codice
            Case "CM" : Return "CONSENSO MANCANTE"
            Case "CP" : Return "CONSENSO PARZIALE"
            Case "CG" : Return "CG - ANTE 2009"
            Case "01" : Return "01 CONTATTO - FEB09"
            Case "02" : Return "01+02 CONTATTO E PROFILAZIONE - FEB09"
            Case "03" : Return "01 CONTATTO - MAG18"
            Case "04" : Return "01+02 CONTATTO E PROFILAZIONE - MAG18"
            Case "05" : Return "01+03 CONTATTO E GRUPPO - MAG18"
            Case "06" : Return "01+02+03 CONTATTO PROFILAZIONE E GRUPPO - MAG18"
            Case Else : Return "DATO NON DISPONIBILE"
        End Select
    End Function
End Class
