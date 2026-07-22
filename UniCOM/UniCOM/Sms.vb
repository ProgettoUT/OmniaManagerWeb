Imports System.IO
Imports Newtonsoft.Json

Public Class Sms

    Public Const CaratteriValidi As String = " abcdefghilmnopqrstuvzwyjkx1234567890!""€£$%&/()=?'ìé*§ç;:_è+ùòà,.-@#><üñöä¿ÜÑÖÄ¡ÉßæÆÅøØ¥|^][~}{"

    Public Event Stato(Stato As StatoServizio)
    Public Esito As New EsitoServizio

    Private _Mittente As String
    Private _ListaSms As New List(Of Destinatario)

    Friend Enum SmsStatus
        NONCONSEGNATI = 0
        CONSEGNATI = 1
        ESITATI = 2
        INATTESA = 3
    End Enum

    Sub New()
        _ListaSms.Capacity = 100
        'valori di default
        _Compagnia = Utx.Globale.ProfiloEnteGestore.Compagnia
        _Agenzia = Utx.Globale.ProfiloEnteGestore.AgenziaMadre
        _Sede = Utx.Globale.ProfiloEnteGestore.CodiceSede
        LeggiAccount()
    End Sub

    Private _Compagnia As Integer
    Public Property Compagnia() As Integer
        Get
            Return _Compagnia
        End Get
        Set(CodiceCompagnia As Integer)
            _Compagnia = CodiceCompagnia
        End Set
    End Property

    Private _Gateway As Integer
    Public ReadOnly Property Gateway() As Integer
        Get
            Return _Gateway
        End Get
    End Property

    Private _Agenzia As String
    Public Property Agenzia() As String
        Get
            Return _Agenzia
        End Get
        Set(value As String)
            _Agenzia = value
        End Set
    End Property

    Private _Sede As String
    Public Property Sede() As String
        Get
            Return _Sede
        End Get
        Set(value As String)
            _Sede = value
        End Set
    End Property

    Private _CodiceUtente As String
    Public Property CodiceUtente() As String
        Get
            Return _CodiceUtente
        End Get
        Set(value As String)
            _CodiceUtente = value
        End Set
    End Property

    Private _UtenteUniage As String
    Public WriteOnly Property UtenteUniage() As String
        Set(Utente As String)
            _UtenteUniage = Utente
        End Set
    End Property

    Private _PwUtenteUniage As String
    Public WriteOnly Property PwUniage() As String
        Set(Pw As String)
            _PwUtenteUniage = Pw
        End Set
    End Property

    Private _Messaggio As MessaggioSms
    Public Property Messaggio() As MessaggioSms
        Get
            Return _Messaggio
        End Get
        Set(value As MessaggioSms)
            _Messaggio = value
        End Set
    End Property

    Public ReadOnly Property NumeroDestinatari() As String
        Get
            Return _ListaSms.Count
        End Get
    End Property

    Public Sub ResetDestinatari()
        _ListaSms.Clear()
    End Sub

    Public Sub Reset()
        _Mittente = ""
        _ListaSms.Clear()
        _Messaggio.Reset()
    End Sub

    Public Sub AddDestinatario(Destinatario As Destinatario)
        Try
            Dim d As New Destinatario
            Destinatario.Telefono = Utx.FunzioniFormato.NormalizzaCellulare(Destinatario.Telefono)
            _ListaSms.Add(Destinatario)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Function CreaStringaToken(Tokens As ArrayList) As String
    '    Try
    '        CreaStringaToken = ""

    '        'scorro tutti i token
    '        For Each e As Token In Tokens

    '            'se la chiave è contenuta nel messaggio
    '            If _Messaggio.EsisteToken(e.Token.Key) Then
    '                CreaStringaToken += e.StringaToken
    '            End If
    '        Next

    '        'tolgo il carattere & iniziale
    '        If CreaStringaToken.StartsWith("&") Then
    '            CreaStringaToken = CreaStringaToken.Substring(1)
    '        End If

    '    Catch ex As Exception
    '        Globale.Log.Errore(ex)
    '        Return ""
    '    End Try
    'End Function

    Friend Shared Function EliminaPrefissoItalia(Telefono As String) As String
        If Telefono.StartsWith("+39") AndAlso Telefono.Length >= 4 Then
            Telefono = Telefono.Substring(3)
        End If
        Return Telefono
    End Function

    Friend Shared Function NormalizzaMittenteNumerico(Telefono As String) As String
        'normalizza il mittente con il prefisso dell'italia 0039 (+39 nel mittente non funziona)
        If Telefono.StartsWith("+39") Then
            Return Telefono.Replace("+39", "0039")

        ElseIf Telefono.StartsWith("0039") Then
            Return Telefono
        Else
            Return "0039" + Telefono
        End If
    End Function

    Private _UtenteSubaccount As String
    Public Property UtenteSubaccount() As String
        Get
            Return _UtenteSubaccount
        End Get
        Set(UtenteSubaccount As String)
            _UtenteSubaccount = UtenteSubaccount
            VerificaAccount()
        End Set
    End Property

    Private _PwUtenteSubaccount As String
    Public WriteOnly Property PwUtenteSubaccount() As String
        Set(PwUtenteSubaccount As String)
            _PwUtenteSubaccount = PwUtenteSubaccount
        End Set
    End Property

    Public ReadOnly Property NormeSms() As String
        Get
            Return "http://www.utools.it/unitools/Sms/NormeSms.html"
        End Get
    End Property

    Private _UsaAccountServizio As Boolean
    Public Property UsaAccountServizio() As Boolean
        Get
            Return _UsaAccountServizio
        End Get
        Set(UsaAccountServizio As Boolean)
            _UsaAccountServizio = UsaAccountServizio
            If _UsaAccountServizio Then
                _UtenteSubaccount = Convert.ToBase64String(New Byte() {186, 120, 173, 162, 137, 108}) '("unitools")
                _PwUtenteSubaccount = Convert.ToBase64String(New Byte() {103, 117, 105, 100, 111}) '("Z3VpZG8=" - guido in base64)
            End If
        End Set
    End Property

    Private _UsaAccountTest As Boolean
    Public Property UsaAccountTest(Optional Invia As Boolean = False) As Boolean
        Get
            Return _UsaAccountTest
        End Get
        Set(UsaAccountTest As Boolean)
            _UsaAccountTest = UsaAccountTest
            _UtenteSubaccount = "Testguido"
            _PwUtenteSubaccount = "Lampo123"

            If Invia = True Then
                _Gateway = 0 'invia veramente
            Else
                _Gateway = 2 'quello che non invia
            End If
        End Set
    End Property

    Private Function CalcolaAccount(Compagnia As String,
                                    CodiceAgenzia As String,
                                    Sede As String) As String

        'per tenere conto delle sedi delle sub che possono essere anche di 5 caratteri (esempio 84152)
        'prendo i 4 caratteri più a destra
        Return String.Format("{0}-AG{1}-{2}",
                             Compagnia,
                             CodiceAgenzia.PadLeft(5, "0"),
                             Right(Sede, 4).PadLeft(4, "0"))
    End Function

    Private Function CalcolaPassword(CodiceUtente As String) As String
        Return "Pw_AUAsms@" 'pw fissa uguale per tutti
    End Function

    Public Function AutoSender(Optional Mittente As String = "",
                               Optional Demo As Boolean = False) As String

        'mittenti numerici gateway 4
        'mittenti alfanumerici gateway 5
        If Demo Then
            _Mittente = "Unitools"
            _Gateway = 5
        Else
            If IsNumeric(Mittente) Then
                _Mittente = NormalizzaMittenteNumerico(Mittente)
                _Gateway = 4
            Else
                Using s As New Utx.SettingAgenzia.ConfiguraSede
                    s.Proxy = Utx.Globale.UniProxy.Proxy
                    Dim MittenteWeb As String = s.MittenteSms(Utx.Globale.AgenziaRichiesta.CodiceAgenzia)

                    If String.IsNullOrEmpty(MittenteWeb) Then
                        'standard
                        _Mittente = String.Format("Unipol{0}", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)
                    Else
                        _Mittente = MittenteWeb
                    End If
                End Using
                _Gateway = 5
            End If
        End If
        Return _Mittente
    End Function

    Public Function ContaMessaggi() As Integer
        Try
            Dim Testo As String = ConvertToUTF8(_Messaggio.Testo)

            Dim NumeroMessaggi As Integer = 0

            For Each d As Destinatario In _ListaSms
                Dim Msg As String = MessaggioSms.CreaTestoSms(Testo, d.Tokens)
                NumeroMessaggi += Math.Ceiling(Msg.Length / MessaggioSms.DimSingoloSms)
            Next
            Return NumeroMessaggi

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return -1
        End Try
    End Function

    Public Sub Invia()
        Try
            If Not ControlloDatiInvio() Then
                Esito.EsitoChiamata = False
                Esito.MessaggioErrore = "Dati invio non corretti"
                Exit Try
            End If

            Globale.Log.Info("configuro il provider dei servizi")
            Dim Netfun As New CNetFun With {.UtenteSubaccount = _UtenteSubaccount, .PwUtenteSubaccount = _PwUtenteSubaccount, .Gateway = _Gateway}

            Globale.Log.Info("{0} invia messaggio a {1} destinatari", {_Mittente, _ListaSms.Count})
            Dim SendingID As String = Netfun.InviaSms(ConvertToUTF8(_Messaggio.Testo), _Mittente, _ListaSms, Today)

            'se l'invio è ok
            If Netfun.Esito.EsitoChiamata = True Then

                Esito.EsitoChiamata = True

                'archivio l'invio nel db
                ArchiviaSmsNelDb(ConvertToUTF8(_Messaggio.Testo),
                                 _Mittente,
                                 _ListaSms,
                                 "",
                                 SendingID)
            Else
                Esito.EsitoChiamata = False
                Esito.MessaggioErrore = Netfun.Esito.MessaggioErrore
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
        Finally
            Me.ResetDestinatari()
        End Try

    End Sub

    Private Function ControlloDatiInvio() As Boolean
        Try
            Dim Messaggio As String = ""

            If String.IsNullOrEmpty(_Compagnia) Then
                'controllo compagnia
                Messaggio = "Impostare il codice della compagnia."
            ElseIf String.IsNullOrEmpty(Utx.Setting.Ambiente) Then
                'controllo ambiente
                Messaggio = "Impostare l'ambiente di lavoro (DIR/PP/PP2DIR)."
            ElseIf String.IsNullOrEmpty(_UtenteSubaccount) Or String.IsNullOrEmpty(_PwUtenteSubaccount) Then
                'controllo user e pw netfun
                Messaggio = "Impostare l'utente e la password del servizio."
            ElseIf String.IsNullOrEmpty(_Mittente) Then
                'mittente
                Messaggio = "Impostare il mittente del messaggio."
            ElseIf String.IsNullOrEmpty(_Messaggio.Testo.Trim) Then
                'testo
                Messaggio = "Testo del messaggio non impostato."
            End If

            'se il messaggio d'errore è stato impostato lo visualizzo
            If Messaggio.Length > 0 Then
                MsgBox(Messaggio, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Return False
            ElseIf ControllaCaratteriValidi(_Messaggio.Testo) = False Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
    End Function

    Public Function ControllaCaratteriValidi(Messaggio As String,
                                             Optional Avviso As Boolean = True,
                                             Optional ByRef Scarto As String = "") As Boolean
        Try
            Globale.Log.Info("controllo caratteri validi")
            For Each c As Char In Messaggio
                If Not CarattereValido(c) Then Scarto += c
            Next

            If Scarto.Length = 0 Then
                Return True
            Else
                If Avviso Then
                    Dim Notifica As New Utx.FormNotifica
                    With Notifica
                        .Stile = Utx.FormNotifica.Style.ROSA_CHIARO
                        .Messaggio = "..."
                        .Show()
                        .Messaggio = String.Format("Nel messaggio sono presenti i caratteri non ammessi:{0}{0}{1}", Environment.NewLine, Scarto)
                        .Chiudi(3)
                    End With
                End If
                Return False
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Function CarattereValido(Carattere As String) As Boolean
        'caratteri ammessi:
        'abcdefghilmnopqrstuvzwyjkx1234567890!"£$%&/()=?'ìé*§ç;:_è+ùòà,.-@#><üñöä¿ÜÑÖÄ¡ÉßæÆÅøØ¥|^][~}{€
        '3 e 8 sono ctrl C e ctrl V
        Try
            Select Case Asc(Carattere)
                Case 3, 8, 10, 13, 22, 32
                    Return True
                Case Else
                    Return CaratteriValidi.IndexOf(Carattere, StringComparison.InvariantCultureIgnoreCase) >= 0
            End Select
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return True 'per non bloccare
        End Try
    End Function

    Private Sub LeggiAccount()
        Try
            'disabilita l'account di servizio
#If DEBUG Then
            If MsgBox("Usare l'account di servizio?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1) = MsgBoxResult.Yes Then
                Me.UsaAccountServizio = True
            Else
                Me.UsaAccountServizio = False
                Dim Query As String = "SELECT IDUtente FROM Utente"
                Dim IdUtente As String = DeCriptaWin(Utx.WsCommand.ExecuteScalar(Query, Utx.Globale.ProfiloEnteGestore.AgenziaMadre).Valore)

                If String.IsNullOrEmpty(IdUtente) Then
                    _UtenteSubaccount = ""
                    _PwUtenteSubaccount = ""
                Else
                    _UtenteSubaccount = IdUtente.Split(";")(0)
                    _PwUtenteSubaccount = IdUtente.Split(";")(1)
                End If
            End If
#Else
            Me.UsaAccountServizio = False
            Dim Query As String = "SELECT IDUtente FROM Utente"
            Dim IdUtente As String = DeCriptaWin(Utx.WsCommand.ExecuteScalar(Query, Utx.Globale.ProfiloEnteGestore.AgenziaMadre).Valore)

            If String.IsNullOrEmpty(IdUtente) Then
                _UtenteSubaccount = ""
                _PwUtenteSubaccount = ""
            Else
                _UtenteSubaccount = IdUtente.Split(";")(0)
                _PwUtenteSubaccount = IdUtente.Split(";")(1)
            End If
#End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            _UtenteSubaccount = ""
            _PwUtenteSubaccount = ""
        End Try

        VerificaAccount()
    End Sub

    Public Sub VerificaAccount()
        'account di servizio
        If _UtenteSubaccount.ToLower = "unitools" Then Exit Sub

        Try
            If String.IsNullOrEmpty(_UtenteSubaccount) = False Then
                'se l'account non è vuoto
                If _UtenteSubaccount.Contains(Utx.Globale.ProfiloEnteGestore.AgenziaMadre) = False Then
                    'se non contiene il codice agenzia madre procedo con l'aggiornamento
                    Dim NuovoNomeAccount As String = CalcolaAccount(_Compagnia, _Agenzia, _Sede)

                    Globale.Log.Info("Modifica account sms da {0} a {1}", {_UtenteSubaccount, NuovoNomeAccount})

                    Dim Netfun As New CNetFun With {.UtenteSubaccount = _UtenteSubaccount, .PwUtenteSubaccount = _PwUtenteSubaccount}
                    If Netfun.UpdateSubaccount(NuovoNomeAccount) = True Then
                        _UtenteSubaccount = NuovoNomeAccount
                        SalvaAccount()
                    End If
                End If
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub SalvaAccount()
        'inizializza e salva un nuovo account
        Try
            'l'account deve essere uno solo
            Dim Query As String = "DELETE FROM Utente"
            Utx.WsCommand.ExecuteNonQuery(Query, Utx.Globale.ProfiloEnteGestore.AgenziaMadre)
            'salvo il nuovo account
            Query = String.Format("INSERT INTO Utente VALUES('{0}')", CriptaWin(_UtenteSubaccount + ";" + _PwUtenteSubaccount))
            Utx.WsCommand.ExecuteNonQuery(Query, Utx.Globale.ProfiloEnteGestore.AgenziaMadre)
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CancellaAccount()
        Try
            Dim Query As String = "DELETE FROM Utente"
            Utx.WsCommand.ExecuteNonQuery(Query, Utx.Globale.ProfiloEnteGestore.AgenziaMadre)
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Function CercaNotifiche() As Integer
        Try
            'imposta servizio
            Dim Netfun As New CNetFun
            Dim Stato As New StatoServizio

            Netfun.UtenteSubaccount = _UtenteSubaccount
            Netfun.PwUtenteSubaccount = _PwUtenteSubaccount

            'prima di iniziare marco le notifiche non più recuperabili
            Dim QueryId As String = "UPDATE Storico 
                SET Stato = '*' 
                WHERE (Stato = '?') AND (DATEDIFF(DAY,DataInvio,GETDATE()) > 30);
                --poi estraggo ora gli id di gruppo con sospesi
                SELECT IDT AS IdGruppo 
                FROM Storico 
                WHERE ((Stato = '?') OR (Stato IS NULL)) AND LEN(TRIM(IDT)) = 17
                GROUP BY IDT"
            Dim QuerySms As String = "SELECT *
                FROM Storico 
                WHERE ((Stato = '?') OR (Stato IS NULL)) AND LEN(TRIM(IDT)) = 17"

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery({QueryId, QuerySms}, {"SendingId", "Sms"}, Utx.Globale.ProfiloEnteGestore.AgenziaMadre)
            Dim SendingId As DataTable = Risposta.DataSet.Tables("SendingId")
            Dim Sms As DataTable = Risposta.DataSet.Tables("Sms")

            'se ci sono id di gruppo con sospesi
            If SendingId.Rows.Count > 0 Then
                'per ogni Id cerco le notifiche
                For Each dr As DataRow In SendingId.Rows
                    'cerco le notifiche
                    Dim Notifiche As ListaNotifiche = Netfun.CercaNotifica(dr("IdGruppo"), delivery.Status.DELIVERED)

                    'elaboro la risposta del servizio
                    RispostaServizio2Esito(Netfun.Esito)

                    'se la ricerca è ok registro nel db
                    If Esito.EsitoChiamata = True Then
                        For Each row As DataRow In Sms.Select(String.Format("IDT = '{0}'", dr("IdGruppo")))
                            For Each d As delivery In Notifiche.deliveries
                                If row("Numero") = d.receiver Then
                                    Select Case d.delivery_status
                                        Case delivery.Status.DELIVERED.ToString
                                            row("Stato") = "S"
                                            row("DataConsegna") = CDate(d.delivery_date).Date
                                            row("OraConsegna") = Format(CDate(d.delivery_date), "HH:mm:ss")
                                        Case delivery.Status.NOT_DELIVERED.ToString
                                            row("Stato") = "N"
                                            row("DataConsegna") = CDate(d.delivery_date).Date
                                            row("OraConsegna") = Format(CDate(d.delivery_date), "HH:mm:ss")
                                        Case Else
                                            'non fare niente
                                    End Select
                                    Exit For
                                End If
                            Next
                        Next
                    Else
                        'in caso di errore interrompo il processo
                        Exit For
                    End If

                    Stato.Contatore += Notifiche.deliveries.Count
                    RaiseEvent Stato(Stato)
                Next

                'per debug
                'Dim f As New Utx.FormDebug(Sms)
                'f.ShowDialog()

                'salva i dati registrati nel datatable
                If Stato.Contatore > 0 Then
                    'invio la tabella al server
                    Sms.TableName = Utx.ServiziOMW.TipoEvento.SMS_NOTIFICHE.ToString 'nome dell'evento sul server
                    Dim ds As New DataSet
                    ds.Tables.Add(Sms.Copy)
                    Utx.OmWeb.InviaDataSet(Utx.Globale.ProfiloEnteGestore.AgenziaMadre, ds)
                End If
            End If

            Stato.Messaggio = "Recupero notifiche completato"
            Return Stato.Contatore

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Errore2Esito(ex)
            Return 0
        End Try
    End Function

    Private Function RegistraNotifiche(SendingID As String, Notifiche As ListaNotifiche) As DataTable
        Try
            'costruisco il select command per il da
            Dim Query As String = String.Format("SELECT IDT,Stato,DataConsegna,OraConsegna,Numero 
                FROM Storico 
                WHERE IDT = '{0}' AND (Stato = '?')", SendingID)

            'riempio la datatable con i messaggi in attesa di delivery - il DB è sempre quello dell'agenzia madre
            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query, Utx.Globale.ProfiloEnteGestore.AgenziaMadre).DataTable

            If dt IsNot Nothing Then
                'divido il csv in righe
                For Each d As delivery In Notifiche.deliveries
                    'cerco il record con quello specifico IDT nel dt
                    For Each dr As DataRow In dt.Rows
                        'se lo trovo aggiorno i dati
                        If dr("IDT") = SendingID AndAlso dr("Numero") = d.receiver Then
                            'dr("Stato") = IIf(Notifica.delivery_status = delivery.Status.DELIVERED.ToString, "S", "N")
                            dr("DataConsegna") = d.delivery_date.Split(" ")(0).Trim
                            dr("OraConsegna") = d.delivery_date.Split(" ")(1).Trim
                            Exit For
                        End If
                    Next
                Next
            End If
            Return dt

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Friend Shared Function CercaNotifiche(Telefoni As List(Of String)) As DataTable
        Try
            If IsNothing(Telefoni) OrElse (Telefoni.Count = 0) Then
                Return New DataTable
            Else
                'crea lista telefoni per la query
                Dim ListaTelefoni As String = "("
                For Each telefono As String In Telefoni
                    ListaTelefoni += String.Format("'{0}',", Utx.FunzioniFormato.NormalizzaCellulare(telefono))
                Next
                'tolgo l'ultima virgola
                ListaTelefoni = ListaTelefoni.Substring(0, ListaTelefoni.Length - 1)
                'chiudo la parentesi
                ListaTelefoni += ")"

                Dim Query As String = String.Format("SELECT Numero AS Telefono,DataInvio,OraInvio,Stato,DataConsegna,OraConsegna,Testo 
                    FROM Storico 
                    WHERE Numero IN {0} 
                    ORDER BY DataInvio DESC,OraInvio DESC", ListaTelefoni)

                Return Utx.WsCommand.ExecuteNonQuery(Query, Utx.Globale.ProfiloEnteGestore.AgenziaMadre).DataTable
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return New DataTable
        End Try
    End Function

    Friend Shared Function CercaNotifiche(Stato As SmsStatus) As DataTable
        Try
            Dim Query As String = "SELECT Nome,Numero AS Telefono,DataInvio,OraInvio,Stato,DataConsegna,OraConsegna,Testo 
                FROM Storico 
                WHERE Stato {0} AND DATEDIFF(DAY,DataInvio,GETDATE()) < 90
                ORDER BY DataInvio DESC,OraInvio DESC"

            Select Case Stato
                Case SmsStatus.CONSEGNATI
                    Query = String.Format(Query, "= 'S'")
                Case SmsStatus.NONCONSEGNATI
                    Query = String.Format(Query, "= 'N'")
                Case SmsStatus.INATTESA
                    Query = String.Format(Query, "NOT IN ('S','N')")
            End Select

            Return Utx.WsCommand.ExecuteNonQuery(Query, Utx.Globale.ProfiloEnteGestore.AgenziaMadre).DataTable

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return New DataTable
        End Try
    End Function

    Public Function RicaricaSubaccount(QuantitaSms As Integer,
                                       CostoPacchetto As Double,
                                       Optional DeskRicarica As String = "") As Integer
        Try
            Dim Netfun As New CNetFun With {.UtenteSubaccount = _UtenteSubaccount}

            Dim NuovoCredito As Integer = Netfun.AddCredito(QuantitaSms, TransazioneCredito.TipoTransazione.ADD)

            If NuovoCredito > 0 Then
#If Not DEBUG Then
                'registro la ricarica nel db su utools.it
                Dim RispostaWsUnico As String = RegistraRicarica(QuantitaSms, CostoPacchetto)
#Else
                Dim RispostaWsUnico As String = "+OK - DEBUG"
#End If

                'invio mail di notifica
                Dim Postino As New Postino
                With Postino
                    .Mittente = "unitools@unipolsai.it"
#If Not DEBUG Then
                    .InviaA.Add("gestione@auaonline.it")
#End If
                    .InviaCc.Add("guidolampo@tiscali.it")
                    .Oggetto = $"Ricarica SMS: agenzia {_Agenzia} - {QuantitaSms}"
                    .Testo = String.Format("Agenzia: {1} - {2}{0}" +
                                           "Operatore: {3}{0}" +
                                           "Account: {4}{0}{0}" +
                                           "Ricarica richiesta: {5:N0} SMS{0}" +
                                           "Costo da addebitare: {6:#0.00} euro{0}" +
                                           "Registrazione sul server: {7}",
                                           Environment.NewLine,
                                           _Agenzia,
                                           Utx.Globale.ProfiloEnteGestore.Localita,
                                           Utx.Globale.UtenteCorrente.UniageUser,
                                           _UtenteSubaccount,
                                           QuantitaSms,
                                           CostoPacchetto,
                                           RispostaWsUnico)
                    .InviaMail()
                End With

                Return NuovoCredito
            Else
                Esito.EsitoChiamata = False
                Esito.MessaggioErrore = Netfun.Esito.MessaggioErrore
                Return 0
            End If

        Catch ex As Exception
            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
            Return 0
        End Try
    End Function

    Private Function RegistraRicarica(QuantitaSms As Integer,
                                      CostoPacchetto As Double) As String
        Try
            Using s As New Utx.ServiziUniarea.accessoCasa
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Return s.RegistrazioneRicaricaW(_UtenteSubaccount, QuantitaSms, CostoPacchetto, 0, Utx.NetFunc.TokenAccessoCasa)
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return "-ERR|" + ex.Message
        End Try
    End Function

    Public Sub CreaSubAccount()
        Dim Netfun As New CNetFun
        Try
#If DEBUG Then
            'per ricreare l'account di servizio
            _UtenteSubaccount = Convert.ToBase64String(New Byte() {186, 120, 173, 162, 137, 108}) '("unitools")
            _PwUtenteSubaccount = Convert.ToBase64String(New Byte() {103, 117, 105, 100, 111}) '("Z3VpZG8=" - guido in base64)
#Else
            _UtenteSubaccount = CalcolaAccount(_Compagnia, _Agenzia, _Sede)
            _PwUtenteSubaccount = CalcolaPassword(_CodiceUtente)
#End If

            Netfun.UtenteSubaccount = _UtenteSubaccount
            Netfun.PwUtenteSubaccount = _PwUtenteSubaccount

            Netfun.AddSubaccount()

            RispostaServizio2Esito(Netfun.Esito)

            If Esito.EsitoChiamata Then
                SalvaAccount()
            Else
                If Esito.CodiceErrore = 512 Then
                    'account già esistente lo salvo nuovamente
                    SalvaAccount()
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Errore2Esito(ex)
        End Try
    End Sub

    Public Function CreditoSubaccount() As Integer
        Try
            Dim Netfun As New CNetFun With {.UtenteSubaccount = _UtenteSubaccount, .PwUtenteSubaccount = _PwUtenteSubaccount}

            Dim Credito As Integer = Netfun.CreditoSubaccount()

            If Credito > 0 Then
                Esito.EsitoChiamata = True
                Return Credito
            Else
                Esito.EsitoChiamata = False
                Return 0
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' archivia un sms inviato nel db
    ''' </summary>
    ''' <param name="Testo">testo base</param>
    ''' <param name="Mittente">mittente</param>
    ''' <param name="ListaSms">lista dati di invio</param>
    ''' <param name="DataInvio">data di invio</param>
    ''' <param name="SendingID">IDT di gruppo</param>
    ''' <remarks></remarks>
    Private Sub ArchiviaSmsNelDb(Testo As String,
                                 Mittente As String,
                                 ListaSms As List(Of Destinatario),
                                 DataInvio As String,
                                 SendingID As String)
        Dim dt As DataTable
        Try
            'creo un datatable disconnesso
            dt = Utx.WsCommand.ExecuteNonQuery("SELECT * FROM Storico WHERE 1=0",
                                               Utx.Globale.ProfiloEnteGestore.AgenziaMadre).DataTable

            'il formato datainvio deve essere "dd/MM/yyyy HH:mm:ss"
            Dim Data As Date, Ora As String

            'se data invio vuota si è chiesto l'invio immediato
            If DataInvio = "" Then
                Data = Today
                Ora = Format(Now, "HH:mm")
            Else
                Data = CDate(DataInvio.Substring(0, 10))
                Ora = DataInvio.Substring(11, 5)
            End If

            'aggiungo i messaggi al dt
            For Each d As Destinatario In ListaSms
                Dim dr As DataRow = dt.NewRow

                dr("DataInvio") = Data
                dr("OraInvio") = Ora
                dr("Numero") = Right(d.Telefono, 15)
                dr("Stato") = "?"
                dr("Testo") = MessaggioSms.CreaTestoSms(Testo, d.Tokens)
                dr("Mittente") = Mittente
                dr("IDT") = SendingID
                dr("Nome") = Left(d.NomeCompleto, 25)

                dt.Rows.Add(dr)
            Next
            'invio la tabella al server
            dt.TableName = Utx.ServiziOMW.TipoEvento.SMS_REGISTRA.ToString 'nome dell'evento sul server
            Dim ds As New DataSet
            ds.Tables.Add(dt)
            Utx.OmWeb.InviaDataSet(Utx.Globale.ProfiloEnteGestore.AgenziaMadre, ds)

        Catch ex As Exception
            Utx.NetFunc.DataTable2Csv(dt, Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Errore_invio_sms.csv"), True)
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Function FlagDelivery() As String
        On Error Resume Next
        Return Path.Combine(Utx.Globale.Paths.CartellaSms, "Delivery." & Format(Today, "ddMMyyyy"))
    End Function

    Public Shared Sub CancellaFlagDelivery()
        Try
            For Each f As String In Directory.GetFiles(Utx.Globale.Paths.CartellaSms, "Delivery.*")
                File.Delete(f)
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Sub CreaFlagDelivery(NotificheRecuperate As Integer)
        Try
            Using sw As New StreamWriter(FlagDelivery)
                sw.WriteLine(String.Format("{0:G}: {1} notifiche recuperate", Now, NotificheRecuperate))
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub RispostaServizio2Esito(EsitoNetFun As EsitoServizio,
                                       Optional ByRef ValoreRestituito As Object = Nothing)
        Try
            If EsitoNetFun.EsitoChiamata = True Then
                Esito.EsitoChiamata = True
                Esito.CodiceErrore = "0"
            Else
                Esito.EsitoChiamata = False
                Esito.CodiceErrore = EsitoNetFun.CodiceErrore
                Esito.MessaggioErrore = EsitoNetFun.MessaggioErrore
                Esito.ValoreRestituiro = ValoreRestituito
            End If

        Catch ex As Exception
            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
        End Try
    End Sub

    Private Sub Errore2Esito(ex As Exception)
        Esito.EsitoChiamata = False
        Esito.MessaggioErrore = ex.Message
    End Sub

End Class

Public Class StatoServizio
    Public Contatore As Integer
    Public Messaggio As String
End Class
