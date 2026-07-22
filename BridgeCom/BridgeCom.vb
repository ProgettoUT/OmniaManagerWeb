Imports System.Data.OleDb
Imports System.IO

Module BridgeCom

    Private Notifica As Utx.FormNotifica
    Private WithEvents TimerNotifica As Timer

    Sub Main()
        Try
            '(TSL 1.2) - fondamentale con il FW 2.0 - vale per tutta l'applicazione
            'è un exe a parte e quindi bisogna impostarla qui
            Net.ServicePointManager.SecurityProtocol = 3072

            'per inizializzare i paths
            If Utx.Globale.IdAppOk = False Then
                Utx.Globale.IdApp(System.Text.Encoding.UTF8.GetString(New Byte() {57, 60, 88, 93, 65, 58, 71}))
                Utx.Globale.Init()

                Dim Bag As Utx.Bag = Utx.NetFunc.CryptoDeserialize(Of Utx.Bag)(IO.Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Utx.Bag"), "guido&st")

                With Bag
                    Utx.Globale.Paths = .Paths
                    Utx.Globale.ProfiloEnteGestore = .Ente
                    Utx.Globale.UtenteCorrente = .Utente
                    Utx.Globale.AgenziaRichiesta = .AgenziaRichiesta
                End With
                Utx.Globale.SettingUtente = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.UTENTE)
            End If

            Globale.Log = New Utx.ApplicationLog("BridgeCom.log")

            If Globale.LeggiImpostazioniGlobali = True Then

                Globale.Log.Info(String.Format("Avvio BridgeCom - Funzione richiesta: {0}", Globale.FunzioneRichiesta))
                Globale.Log.Info(String.Format("Ambiente: {0}", Utx.Setting.Ambiente))

                Select Case Globale.FunzioneRichiesta
                    Case Globale.FunzioniDisponibili.InviaSmsLista
                        InviaSmsLista()
                    Case Globale.FunzioniDisponibili.InviaSmsSingolo
                        InviaSmsSingolo()
                    Case Globale.FunzioniDisponibili.InviaEmailSenzaInterfaccia
                        InviaEmailSenzaInterfaccia()
                    Case Globale.FunzioniDisponibili.InviaSmsSenzaInterfaccia
                        InviaSmsSenzaInterfaccia()
                End Select
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub InviaSmsLista()
        Globale.Log.Info("Inizio procedura di invio SMS a lista di distribuzione")

        'query per l'update delle date nello storico (testata)
        'UPDATE(Storico)
        'DataInvio = Format(CDate(DataInvio), "yyyy-MM-dd")
        'WHERE(Mid(DataInvio, 3, 1) = "/")
        '------------------------------------------------------

        Notifica = New Utx.FormNotifica()
        With Notifica
            .Opacity = 0.9
            .ColoreSfondo = Color.PaleGreen
            .Show()

            .Messaggio = "Invio sms in corso..."
        End With

        'SmsId identifica una tabella e un file con questo nome
        'la tabella è nel file sms.mdb e il file di testo nella cartella com dell'utente
        Dim SmsId As String = Utx.NetFunc.GetEnvironmentVar("UNITOOLS_COM2_ID")
        Dim Mittente As String = Utx.NetFunc.GetEnvironmentVar("UNITOOLS_COM2_MITTENTE")
        Dim FileMessaggio As String = Path.Combine(Utx.Globale.Paths.CartellaComUtente, SmsId)

        Globale.Log.Info("Imposto il messaggio")

        'imposta il messaggio e il testo del messaggio
        Dim Msg As New UniCom.MessaggioSms

        Try
            Using txt As New StreamReader(FileMessaggio, System.Text.Encoding.Default)
                Msg.Testo = txt.ReadToEnd
            End Using

        Catch ex As Exception
            'scrivo il log
            Globale.Log.Info("Errore nell'impostazione del testo del messaggio")

            MsgBox(String.Format("Errore nell'impostazione del testo del messaggio.{0}Invio annullato.",
                                 Environment.NewLine),
                   MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)

            Notifica.ColoreSfondo = Color.Orange
            Notifica.Messaggio = "Errore: invio annullato"
            Notifica.Chiudi()

            Exit Sub
        End Try

        'imposto i token e invio
        Try
            Globale.Log.Info("Imposto la lista dei destinatari")

            Using cn As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Utx.ConnessioniDb.Db.SMS))
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandText = String.Format("SELECT * FROM {0}", SmsId)

                    Dim dt As New DataTable
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    Dim Sms As New UniCom.Sms With {.Compagnia = 1, .Messaggio = Msg}

                    Dim TokenUtilizzati As List(Of String) = TagUtilizzati(Msg.Testo)

                    For Each dr As DataRow In dt.Rows
                        Dim Destinatario As New UniCom.Destinatario(dr("Cognome"), dr("Nome"), dr("Telefono"))

                        'passo le corrispondenze dei token
                        Destinatario.AddTokens(dr, TokenUtilizzati)

                        Sms.AddDestinatario(Destinatario)
                    Next

                    Globale.Log.Info("Verifico la disponibilità di credito")

                    Dim Credito As String = Sms.CreditoSubaccount()

                    If Sms.Esito.EsitoChiamata = True Then
                        'conto i messaggi sostituendo i token
                        Dim NumeroMessaggi As Integer = Sms.ContaMessaggi

                        If NumeroMessaggi > Credito Then
                            Globale.Log.Info("Credito insufficiente")

                            Notifica.ColoreSfondo = Color.Orange
                            Notifica.Messaggio = String.Format("Credito insufficiente.{0}Numero destinatari: {1}{0}" +
                                                           "Numero SMS (da 160 caratteri) richiesti: {2}{0}" +
                                                           "Credito disponibile {3} SMS.",
                                                           Environment.NewLine,
                                                           Sms.NumeroDestinatari,
                                                           NumeroMessaggi,
                                                           Credito)
                            Exit Sub
                        End If

                        Sms.AutoSender(Mittente)

#If DEBUG Then
                        Sms.AutoSender(Mittente, True)
                        'Sms.UsaAccountTest = True
#End If

                        Globale.Log.Info("Procedo con l'invio")

                        'memorizzo il numero destinatari perché dopo l'invio la lista viene svuotata
                        Dim NumeroDestinatari As Integer = Sms.NumeroDestinatari

                        'procedo con l'invio-----------------------------
                        Sms.Invia()
                        '------------------------------------------------

                        If Sms.Esito.EsitoChiamata = True Then
                            Globale.Log.Info(String.Format("Inviati {0} SMS. Invio completato con successo!",
                                                       NumeroDestinatari))

                            Notifica.Messaggio = String.Format("Inviati {1} sms.{0}Invio completato con successo!",
                                                           Environment.NewLine,
                                                           NumeroDestinatari)
                        Else
                            Globale.Log.Info(Sms.Esito.MessaggioErrore)
                            Notifica.ColoreSfondo = Color.Orange
                            Notifica.Messaggio = Sms.Esito.MessaggioErrore
                        End If
                    End If
                End Using

                Utx.FunzioniDb.CancellaTabella(cn, SmsId)
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Notifica.ColoreSfondo = Color.Orange
            Notifica.Messaggio = "Errore: invio annullato"
        Finally
            Notifica.Chiudi()
        End Try
    End Sub

    Private Sub TimerNotifica_Tick(sender As Object, e As System.EventArgs) Handles TimerNotifica.Tick
        Notifica = Nothing
    End Sub

    Private Sub InviaSmsSingolo()
        Try
            Using f As New UniCom.FormMail
                f.Messaggio = UniCom.FormMail.TipoMessaggio.Sms
                f.CartellaDocumenti = Utx.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_DOCUMENTI")
                f.CodiceFiscale = Utx.NetFunc.GetEnvironmentVar("UNITOOLS_DOC_CF")
                f.CartellaSms = Utx.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_SMS")
                f.AddDestinatarioSms(Utx.NetFunc.GetEnvironmentVar("UNITOOLS_COM2_SMS_TELEFONO"))

                f.ShowDialog()
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub InviaEmailSenzaInterfaccia()
        Try
            Dim Id As String = Utx.NetFunc.GetEnvironmentVar("UNITOOLS_COM2_ID")
            Dim FileMessaggio As String = Path.Combine(Utx.Globale.Paths.CartellaComUtente, Id)
            Dim FileEsito As String = FileMessaggio + ".esito"

            'se non trova il file lo scrive nel log e esce
            If Not File.Exists(FileMessaggio) Then
                Globale.Log.Info("File messaggio non trovato")
                Exit Sub
            End If

            Dim sr As New StreamReader(FileMessaggio, System.Text.Encoding.Default)
            Dim sw As New StreamWriter(FileEsito)
            Dim Riga As String
            Dim MessaggioNotifica As String = ""
            Dim MessaggioErrori As String = ""
            Dim IdMsg As String = "ND"
            Dim Errori As Boolean = False

            Notifica = New Utx.FormNotifica
            With Notifica
                .Opacity = 0.9
                .Text = ""
                .Show()
            End With

            Dim p As New UniCom.Postino

            Do While Not sr.EndOfStream
                'leggo la riga
                Riga = sr.ReadLine

                'se la riga non è vuota
                If Riga.Trim.Length > 0 Then
                    'trovo la posizione di = (non uso split perchè potrebbero esserci più =)
                    Dim k As Integer = Riga.IndexOf("=", StringComparison.InvariantCultureIgnoreCase)
                    'ricavo la variabile e il relativo valore
                    Dim Variabile As String = Riga.Substring(0, k).ToUpper
                    Dim Valore As String = Riga.Substring(k + 1)

                    Select Case Variabile
                        Case "IDMSG"
                            IdMsg = Valore

                        Case "MITTENTE"
                            p.Mittente = Valore

                        Case "A"
                            For Each i As String In Valore.Split(";")
                                If Utx.NetFunc.ValidEmail(i, False, False) Then p.InviaA.Add(i)
                            Next

                        Case "CC"
                            For Each i As String In Valore.Split(";")
                                If Utx.NetFunc.ValidEmail(i, False, False) Then p.InviaCc.Add(i)
                            Next

                        Case "CCN"
                            For Each i As String In Valore.Split(";")
                                If Utx.NetFunc.ValidEmail(i, False, False) Then p.InviaCcn.Add(i)
                            Next

                        Case "OGGETTO"
                            p.Oggetto = Valore

                        Case "ALLEGATI"
                            Dim CartellaAllegati As String = Valore

                            If Directory.Exists(CartellaAllegati) Then

                                For Each fi As String In Directory.GetFiles(CartellaAllegati)
                                    p.AddAllegato(Path.GetFullPath(fi))
                                Next
                            End If

                        Case "NOTIFICA"
                            MessaggioNotifica = Valore.Trim

                        Case "TESTO"
                            p.Testo = Valore.Replace("\>", Environment.NewLine)

                        Case "INVIO"
                            If MessaggioNotifica <> "N" Then
                                'notifico l'invio in corso
                                Notifica.Messaggio = String.Format("Invio e-mail:{0}{1}",
                                                                   Environment.NewLine,
                                                                   MessaggioNotifica)
                            End If

                            p.InviaMail()

                            'scrivo l'esito
                            If p.Esito.EsitoChiamata = True Then
                                sw.WriteLine(String.Format("{0}={1}", IdMsg, "OK"))
                            Else
                                sw.WriteLine(String.Format("{0}={1}", IdMsg, "KO"))
                                Globale.Log.Info(p.Esito.MessaggioErrore)
                                Errori = True
                            End If

                            p.Reset()
                            IdMsg = "ND"
                            'ora passo a leggere il successivo messaggio
                    End Select
                End If
            Loop

            sr.Close()
            sw.Close()

            File.Delete(FileMessaggio)

            If p.Esito.EsitoChiamata = False Then

                File.AppendAllText(Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, "Errori invio e-mail.log"),
                                   p.Esito.MessaggioErrore)

                Notifica.ColoreSfondo = Color.Orange
                Notifica.Messaggio = "Invio concluso con errori. Log degli errori salvato sul desktop."
                Notifica.Chiudi(5)
            Else
                Notifica.Messaggio = "Invio concluso correttamente."
                Notifica.Chiudi(2)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub InviaSmsSenzaInterfaccia()
        Try
            Dim Id As String = Utx.NetFunc.GetEnvironmentVar("UNITOOLS_COM2_ID")
            Dim FileMessaggio As String = Path.Combine(Utx.Globale.Paths.CartellaComUtente, Id)
            Dim FileEsito As String = FileMessaggio + ".esito"

            'se non trova il file lo scrive nel log e esce
            If Not File.Exists(FileMessaggio) Then
                Globale.Log.Info("File messaggio non trovato")
                Exit Sub
            End If

            File.Delete(FileEsito)

            Dim sr As New StreamReader(FileMessaggio, System.Text.Encoding.Default)
            Dim sw As New StreamWriter(FileEsito)
            Dim Riga As String
            Dim MessaggioNotifica As String = ""
            Dim IdMsg As String = "ND"

            Dim Sms As New UniCom.Sms
            Dim Msg As New UniCom.MessaggioSms
            Dim Destinatario As New UniCom.Destinatario

            'avvio il box di notifica
            Notifica = New Utx.FormNotifica
            With Notifica
                .Opacity = 0.9
                .ColoreSfondo = Color.PaleGreen
                .Show()

                .Messaggio = "Invio sms..."
            End With

            Do While Not sr.EndOfStream
                'leggo la riga
                Riga = sr.ReadLine

                'se la riga non è vuota
                If Riga.Trim.Length > 0 Then
                    'trovo la posizione di = (non uso split perchè potrebbero esserci più =)
                    Dim k As Integer = Riga.IndexOf("=", StringComparison.InvariantCultureIgnoreCase)
                    'ricavo la variabile e il relativo valore
                    Dim Variabile As String = Riga.Substring(0, k).ToUpper
                    Dim Valore As String = Riga.Substring(k + 1)

                    Select Case Variabile
                        Case "IDMSG"
                            IdMsg = Valore

                        Case "MITTENTE"
                            Sms.AutoSender(Valore)

                        Case "TELEFONO"
                            Destinatario.Telefono = Valore

                        Case "COGNOME"
                            Destinatario.Cognome = Valore

                        Case "NOME"
                            Destinatario.Nome = Valore

                        Case "NOTIFICA"
                            MessaggioNotifica = Valore.Trim

                        Case "TESTO"
                            Msg.Testo = Valore.Replace("\>", Environment.NewLine)

                        Case "INVIO"
                            'notifico l'invio in corso
                            Notifica.Messaggio = String.Format("Invio sms:{0}{1}",
                                                               Environment.NewLine,
                                                               MessaggioNotifica)

                            Sms.AddDestinatario(Destinatario)
                            Sms.Messaggio = Msg
                            Sms.Invia()

                            'scrivo l'esito
                            If Sms.Esito.EsitoChiamata = True Then
                                sw.WriteLine(String.Format("{0}={1}", IdMsg, "OK"))
                            Else
                                sw.WriteLine(String.Format("{0}={1}", IdMsg, "KO"))
                                Globale.Log.Info(Sms.Esito.MessaggioErrore)
                            End If

                            Msg.Reset()
                            Destinatario.Reset()
                            Sms.Reset()
                            IdMsg = "ND"
                    End Select
                End If
            Loop

            sr.Close()
            sw.Close()

            File.Delete(FileMessaggio)

            'in primo piano per l'esito finale
            Notifica.TopMost = True

            If Sms.Esito.EsitoChiamata = True Then
                Notifica.Messaggio = "Invio concluso correttamente."
                Notifica.Chiudi(2)
            Else
                Notifica.ColoreSfondo = Color.Orange
                Notifica.Messaggio = Sms.Esito.MessaggioErrore
                Notifica.Chiudi(5)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function TagUtilizzati(Testo As String) As List(Of String)
        Dim Lista As New List(Of String)
        Try
            Testo = Testo.ToLower
            For Each i As String In "cognome/nome/scadenza/targa/modello".Split("/")
                If Testo.Contains("#" & i.ToLower & "#") Then
                    Lista.Add(i.ToLower)
                End If
            Next
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
        Return Lista
    End Function
End Module
