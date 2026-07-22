Imports System.IO
Imports System.Environment
Imports System.Data
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.OleDb
Imports Microsoft.Web.Services3
Imports Microsoft.Web.Services3.Security.Tokens

Public Class FormDownloadSertel

    'Web-service UPLOAD DOCUMENTI:
    'http://uploaderunitools.servizi.gr-u.it/UploaderUnitools.dll/wsdl/IUploaderUnitools
    'Web-service RICERCA DOCUMENTI:
    'CERTIFICAZIONE:
    'http://webx5prod.servizi.gr-u.it/essigSXCC/ws/it/unipol/sx/webservice/unitools/DocumentiAgenziaAPI?wsdl
    'PRODUZIONE:
    'http://webnssprod.servizi.gr-u.it/essigSXCC/ws/it/unipol/sx/webservice/unitools/DocumentiAgenziaAPI?wsdl

    Public Log As New UtNetUtility.ApplicationLog("UploadSertel.log")

    Public Enum TipoOperazione
        UPLOAD = 1
        VISUALIZZA = 2
        SALVA = 3
        LISTA = 4
    End Enum

    Public Structure TipoChiamata
        Public Sinistro As String
        Public CartellaLocaleSinistro As String
        Public Operazione As String
        Friend FileToUpload As Documenti
        Friend CodiceDocumento As Integer
        Friend DataArrivoDoc As String
        Friend Rinomina As Boolean
        Friend NuovoNome As String
    End Structure
    Public ChiamataUpload As TipoChiamata

    Friend AmbienteSertel As String = "TEST"
    Friend FlagWip As Boolean

    Private ServizioUpload As New LiquidoUpload.IUploaderUnitoolsservice
    Private ServizioDocumenti As New LiquidoDocumenti.DocumentiAgenziaAPIWse

    Private Const mAutore = "Unitools"
    Private Const mProvenienza = "WEBUNITOOLS"
    Private SinistroCorrente As Sinistri

    Private Function UserToken() As UsernameToken
        Return New UsernameToken("batchuser", "batchuser", PasswordOption.SendPlainText)
    End Function

    Private Sub frmUpload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Text = "Documenti Sertel"

        lbNumeroSinistro.BackColor = Color.Khaki

        With btnVisualizza
            .Padding = New Padding(10)
            .Image = My.Resources.view.ToBitmap
            .ImageAlign = ContentAlignment.MiddleRight
            .Text = "Vedi documento"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With btnSalvaFile
            .Padding = New Padding(10)
            .Image = My.Resources.disk.ToBitmap
            .ImageAlign = ContentAlignment.MiddleRight
            .Text = "Copia documento da Sertel a M:"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With btnEsci
            .Padding = New Padding(10)
            .Image = My.Resources.Esci.ToBitmap
            .ImageAlign = ContentAlignment.MiddleRight
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleLeft
        End With

        lbStato.Text = ""

        'nasconde immagine upload
        PictureBox1.Image = My.Resources.upload.ToBitmap
        PictureBox1.Visible = False

        'normalizzo formato sinistro con - come separatori
        ChiamataUpload.Sinistro = ChiamataUpload.Sinistro.Replace(".", "-")

        'configuro il servizi
        ServizioUpload = New LiquidoUpload.IUploaderUnitoolsservice
        ServizioUpload.Timeout = 120000
        ServizioUpload.Credentials = CredenzialiUtente()

        Log.AddLog("Versione upload: " + Application.ProductVersion)
        Log.AddLog("Utente: " + Environment.UserName)

    End Sub

    Private Sub frmUpload_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        SinistroCorrente = New Sinistri(ChiamataUpload.Sinistro)

        lbNumeroSinistro.Text = "Sinistro " + SinistroCorrente.IdSinistroNormalizzato

        With pbInvio
            .Style = ProgressBarStyle.Marquee
            .Enabled = True
        End With

        With ListBoxDocumenti
            .Items.Clear()
            .Refresh()
            .Enabled = False
        End With

        FlagWip = True

        Dim Arg As New SertelEventArgs

        If ChiamataUpload.Operazione = TipoOperazione.UPLOAD Then

            lbStato.Text = "Invio del file in corso..."

            'blocca controlli
            btnVisualizza.Enabled = False
            btnSalvaFile.Enabled = False
            btnEsci.Enabled = False

            PictureBox1.Visible = True

            'avvia l'upload
            Arg.Operazione = TipoOperazione.UPLOAD

            BackgroundWorker1.RunWorkerAsync(Arg)

        Else 'visualizzazione documenti

            lbStato.Text = "Lettura lista documenti..."

            'blocca controlli
            btnVisualizza.Enabled = False
            btnSalvaFile.Enabled = False

            Arg.Operazione = TipoOperazione.LISTA

            BackgroundWorker1.RunWorkerAsync(Arg)
        End If

        Me.Refresh()

    End Sub

    Private Sub frmUpload_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        On Error Resume Next

        e.Cancel = FlagWip

        ServizioDocumenti.Dispose()
        ServizioUpload.Dispose()
    End Sub

    Private Function ListaDoc() As EsitoBackgroundWorker

        'creo lo usertoken per la chiamata
        Dim requestContext As SoapContext = ServizioDocumenti.RequestSoapContext

        With requestContext.Security
            .Timestamp.TtlInSeconds = 60
            .Tokens.Add(UserToken)
        End With

        Dim Esito As New EsitoBackgroundWorker

        Try
            Esito.ListaDocumenti = ServizioDocumenti.getDocumentoInfoList(SinistroCorrente.IdSinistroNormalizzato, Agenzia)
            Esito.TipoRisposta = "OK"

        Catch ex As Net.WebException
            Esito.Risposta = "KO|Errore nel dialogo con il server"
            Esito.ExMessage = ex.Message
        Catch ex As UnauthorizedAccessException
            Esito.Risposta = "KO|Autorizzazione negata: controllare user/password"
            Esito.ExMessage = ex.Message
        Catch ex As Exception
            Esito.Risposta = "KO|" + ex.Message
            Esito.ExMessage = ex.Message
        End Try

        Return Esito

    End Function

    Private Function InviaFile() As EsitoBackgroundWorker

        Log.AddLog(">>>Entro in InviaFile")

        Dim Esito As New EsitoBackgroundWorker

        Try
            Dim fs As FileStream = New FileStream(ChiamataUpload.FileToUpload.FullPathDoc,
                                                  FileMode.Open, FileAccess.Read)
            Dim StreamLen As Integer = Convert.ToInt32(fs.Length)
            Dim o As Object = New Byte(StreamLen) {}

            fs.Read(o, 0, StreamLen)
            fs.Close()

            Dim NomeDoc As String = String.Format("{0}.{1}",
                                                  ChiamataUpload.NuovoNome,
                                                  ChiamataUpload.FileToUpload.Formato)

            Esito.Risposta = ServizioUpload.UniUpLoadToSertel(AmbienteSertel,
                                                              SinistroCorrente.IdSinistroNormalizzato,
                                                              ChiamataUpload.CodiceDocumento,
                                                              NomeDoc,
                                                              MittenteDocumento(),
                                                              mAutore,
                                                              ChiamataUpload.DataArrivoDoc,
                                                              mProvenienza,
                                                              o)

        Catch ex As Net.WebException
            Esito.Risposta = "KO|Errore nel dialogo con il server"
            Esito.ExMessage = ex.Message
        Catch ex As UnauthorizedAccessException
            Esito.Risposta = "KO|Autorizzazione negata: controllare user/password"
            Esito.ExMessage = ex.Message
        Catch ex As Exception
            Esito.Risposta = "KO|" + ex.Message
            Esito.ExMessage = ex.Message
        End Try

        Return Esito

    End Function

    Private Function ScaricaFile(ByRef Doc As LiquidoDocumenti.DocumentoInfo,
                                 ByVal FileDest As String) As EsitoBackgroundWorker

        Dim Esito As New EsitoBackgroundWorker

        Try
            Dim o As Object = New Byte() {}

            Esito.Risposta = ServizioUpload.UniDownLoadFromFileNet(AmbienteSertel, Doc.DocUID, o)

            Dim fs As FileStream = New FileStream(FileDest, FileMode.Create, FileAccess.Write)
            fs.Write(o, 0, Convert.ToInt32(o.Length))
            fs.Close()

            Return Esito

        Catch ex As Net.WebException
            Esito.Risposta = "KO|Errore nel dialogo con il server"
            Esito.ExMessage = ex.Message
        Catch ex As UnauthorizedAccessException
            Esito.Risposta = "KO|Autorizzazione negata: controllare user/password"
            Esito.ExMessage = ex.Message
        Catch ex As Exception
            Esito.Risposta = "KO|" + ex.Message
            Esito.ExMessage = ex.Message
        End Try

        Return Esito

    End Function

    Private Function CredenzialiUtente() As System.Net.NetworkCredential

        If Globale.Ambiente = GestioneDocumenti.TipoAmbiente.DIR Then
            Return Net.CredentialCache.DefaultCredentials
        Else
            'dichiaro le credenziali
            Return New System.Net.NetworkCredential(Globale.UtenteUniage,
                                                    Globale.PwUniage,
                                                    Globale.Dominio)
        End If

    End Function

    Private Function MittenteDocumento() As String

        Try
            Return Globale.UtenteUniage

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return ""
        End Try

    End Function

    Private Sub ListBoxDocumenti_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxDocumenti.SelectedIndexChanged

        Try
            If ListBoxDocumenti.SelectedItem Is Nothing Then ListBoxDocumenti.SelectedIndex = 0
            If ListBoxDocumenti.SelectedIndex < 0 Then Exit Sub

            Dim d As LiquidoDocumenti.DocumentoInfo = ListBoxDocumenti.SelectedItem

            If d.IdFile.Length > 0 Then
                lbStato.Text = String.Format("inviato il {0:G} da {1}", d.DataInvio, d.Mittente)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Log.AddLog(ex.Message)
        End Try

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object,
                                         ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        'attraverso e vengono passati i dati per il BackgroundWorker
        'le funzioni invocate restituiscono una struttura esito contenente una risposta
        'e il tipo di chiamata effettuata
        Dim Esito As New EsitoBackgroundWorker

        Select Case e.Argument.Operazione

            Case TipoOperazione.UPLOAD
                Esito = InviaFile()

            Case TipoOperazione.VISUALIZZA
                Esito = ScaricaFile(e.Argument.DocInfo,
                                    e.Argument.FullPathFileDest)

            Case TipoOperazione.SALVA
                Esito = ScaricaFile(e.Argument.DocInfo,
                                    e.Argument.FullPathFileDest)

            Case TipoOperazione.LISTA
                Esito = ListaDoc()
        End Select

        'nella struttura esito riporto anche l'operazione fatta per considerazioni a posteriori
        'sulla risposta
        Esito.ArgChiamata = e.Argument

        'restituisco la struttura esito come risultato dell'elaborazione
        e.Result = Esito
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object,
                                                     ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        'fermo la progress bar al max
        With pbInvio
            .Style = ProgressBarStyle.Blocks
            .Value = pbInvio.Maximum
            .Refresh()
        End With

        'analisi dell'esito dell'operazione. e.result contiene la struttura esito
        Try
            Dim Esito As EsitoBackgroundWorker = e.Result

            Esito.ElaboraRisposta(Esito, Log)

            Select Case Esito.ArgChiamata.Operazione

                Case TipoOperazione.UPLOAD

                    PictureBox1.Visible = False

                    If Esito.TipoRisposta = "OK" Then
                        lbStato.Text = "Invio concluso correttamente."

                        'rinomina il file se richisto
                        If ChiamataUpload.Rinomina = True Then
                            ChiamataUpload.FileToUpload.AggiungiProtocollo()
                            ChiamataUpload.FileToUpload.RinominaDocumento(ChiamataUpload.NuovoNome)
                        End If

                        'scrivere la nota relativa all'invio
                        InserisciNota()
                    Else
                        'visualizza l'errore all'utente e aspetta 3 secondi
                        'perché la successiva rilettura della lista doc lo cancella ma resta nel log
                        lbStato.Text = Esito.Risposta
                        Log.AddLog(Esito.Risposta)
                        'aspetta 3 secondi
                        Threading.Thread.Sleep(3000)
                    End If

                    'finito l'upload aggiorna la lista documenti
                    'Dim Arg As New SertelEventArgs
                    'Arg.Operazione = TipoOperazione.LISTA
                    'BackgroundWorker1.RunWorkerAsync(Arg)

                Case TipoOperazione.VISUALIZZA

                    If Esito.TipoRisposta = "OK" Then
                        lbStato.Text = "Documento scaricato correttamente"

                        'visualizza il documento aprendo l'applicazione predefinita
                        Process.Start(Esito.ArgChiamata.FullPathFiledest)
                    Else
                        lbStato.Text = Esito.Risposta
                    End If

                Case TipoOperazione.SALVA

                    If Esito.TipoRisposta = "OK" Then
                        lbStato.Text = "Documento salvato"
                    Else
                        lbStato.Text = Esito.Risposta
                    End If

                Case TipoOperazione.LISTA

                    ListBoxDocumenti.Items.Clear()
                    ListBoxDocumenti.DisplayMember = "Nome"

                    If Esito.TipoRisposta = "OK" Then

                        If Esito.ListaDocumenti Is Nothing Then
                            lbStato.Text = "Non sono stati trovati documenti"
                        Else
                            For k As Integer = 0 To Esito.ListaDocumenti.DocumentoInfoList.GetUpperBound(0)
                                ListBoxDocumenti.Items.Add(Esito.ListaDocumenti.DocumentoInfoList(k))
                            Next

                            lbStato.Text = String.Format("documenti trovati: {0}",
                                                         Esito.ListaDocumenti.DocumentoInfoList.GetUpperBound(0) + 1)
                        End If

                    ElseIf Esito.TipoRisposta = "KO" Then
                        'si è verificato un'errore
                        lbStato.Text = Esito.Risposta
                    End If

                    btnVisualizza.Enabled = (Esito.TipoRisposta = "OK")
                    btnSalvaFile.Enabled = (Esito.TipoRisposta = "OK")
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ListBoxDocumenti.Enabled = True

        FlagWip = False
        btnEsci.Enabled = True

    End Sub

    Private Sub btnEsci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Private Sub btnVisualizza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizza.Click

        Try
            If ListBoxDocumenti.SelectedIndex < 0 Then
                MsgBox("Selezionare il documento da visualizzare", MsgBoxStyle.Information, TitoloApp)
                Exit Sub
            End If

            Dim d As LiquidoDocumenti.DocumentoInfo = ListBoxDocumenti.SelectedItem

            If d.IdFile.Length = 0 Then Exit Sub

            With pbInvio
                .Style = ProgressBarStyle.Marquee
                .Enabled = True
            End With

            'Dim FileDest As String = Path.Combine(Globale.UTCartellaTempDoc, d.Descrizione + "." + d.FileExt)
            Dim FileDest As String = Path.Combine(Globale.UTCartellaTempDoc, d.Nome + d.FileExt)

            'scarica il file selezionato
            Dim Arg As New SertelEventArgs
            Arg.Operazione = TipoOperazione.VISUALIZZA
            Arg.DocInfo = d
            Arg.FullPathFiledest = FileDest

            BackgroundWorker1.RunWorkerAsync(Arg)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnSalvaFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvaFile.Click

        Try
            If ListBoxDocumenti.SelectedIndex < 0 Then
                MsgBox("Selezionate prima il documento da salvare", MsgBoxStyle.Exclamation, TitoloApp)
                Exit Sub
            End If

            Dim d As LiquidoDocumenti.DocumentoInfo = ListBoxDocumenti.SelectedItem

            If d.IdFile.Length = 0 Then Exit Sub

            If Not Directory.Exists(ChiamataUpload.CartellaLocaleSinistro) Then
                Directory.CreateDirectory(ChiamataUpload.CartellaLocaleSinistro)
            End If

            Dim FileDest As String = Path.Combine(ChiamataUpload.CartellaLocaleSinistro, d.Nome + d.FileExt)

            'controlla se il file già esiste
            If File.Exists(FileDest) Then
                MsgBox("Nella cartella esiste già un file con lo stesso nome.", MsgBoxStyle.Exclamation, TitoloApp)
                Exit Sub
            End If

            With pbInvio
                .Style = ProgressBarStyle.Marquee
                .Enabled = True
            End With

            'scarica il file selezionato
            Dim Arg As New SertelEventArgs
            Arg.Operazione = TipoOperazione.SALVA
            Arg.DocInfo = d
            Arg.FullPathFiledest = FileDest

            BackgroundWorker1.RunWorkerAsync(Arg)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ControlloCartellaSinistro(ByVal CartellaSinistro As String)
        If Not Directory.Exists(CartellaSinistro) Then Directory.CreateDirectory(CartellaSinistro)
    End Sub

    Private Sub lbStato_TextChanged(sender As Object, e As System.EventArgs) Handles lbStato.TextChanged
        lbStato.Refresh()
    End Sub

    Private Sub btnLog_Click(sender As System.Object, e As System.EventArgs) Handles btnLog.Click
        Log.ApriLog()
    End Sub

    Private Sub InserisciNota()

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand

        Try
            cn.ConnectionString = Globale.ConnDbLink
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "INSERT INTO SinistriMemo (Utente,DataModifica,AgenziaSinistro,EsercizioSinistro," +
                                                        "NumeroSinistro,[Memo],Allarme,Giorni,Ricorda) " +
                              "VALUES (?,?,?,?,?,?,?,?,?)"

            With cmd.Parameters
                .AddWithValue("Utente", Globale.UtenteUniage)
                .AddWithValue("Data", Format(Now, "dd/MM/yyyy hh:mm:ss"))
                .AddWithValue("Agenzia", SinistroCorrente.AgenziaSinistro)
                .AddWithValue("Esercizio", SinistroCorrente.EsercizioSinistro)
                .AddWithValue("Numero", SinistroCorrente.NumeroSinistro)
                .AddWithValue("Nota", "Inviato a Sertel il documento: " +
                              Path.GetFileName(ChiamataUpload.FileToUpload.FullPathDoc))
                .AddWithValue("Allarme", DBNull.Value)
                .AddWithValue("Giorni", 2)
                .AddWithValue("Ricorda", 0)
            End With

            cmd.ExecuteNonQuery()

            'file per restituire la data della nota
            File.AppendAllText(Path.Combine(Globale.UTCartellaTempCom, "SERTEL_DATA_NOTA.OK"),
                               Format(Today, "dd/MM/yyyy"))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, TitoloApp)
            MsgBox("Impossibile aggiungere la nota di invio documento", MsgBoxStyle.Exclamation, TitoloApp)
        Finally
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End Try

    End Sub

End Class

Public Class EsitoBackgroundWorker

    Public ArgChiamata As SertelEventArgs
    Public TipoRisposta As String
    Public Risposta As String = ""
    Public ExMessage As String = ""
    Public ListaDocumenti As LiquidoDocumenti.DocumentiAgenziaResult

    Public Sub ElaboraRisposta(ByRef Esito As EsitoBackgroundWorker,
                               ByRef Log As UtNetUtility.ApplicationLog)

        Try
            If Esito.ArgChiamata.Operazione = FormDownloadSertel.TipoOperazione.LISTA Then
                'non fare niente
            Else
                If Esito.Risposta.Trim.Length = 0 Then

                    Esito.TipoRisposta = "KO"
                    Esito.Risposta = "Errore nel dialogo con il server"

                ElseIf Esito.Risposta.Split("|")(0) = "OK" Then

                    Esito.TipoRisposta = Esito.Risposta.Split("|")(0)
                    Esito.Risposta = Esito.Risposta.Substring(3)

                ElseIf Esito.Risposta.Split("|")(0) = "KO" Then

                    Esito.TipoRisposta = Esito.Risposta.Split("|")(0)
                    Esito.Risposta = Esito.Risposta.Split("|")(1)
                Else
                    Esito.TipoRisposta = "KO"
                    'lascio la risposta così come arrivata dal server per valutarla
                End If
            End If

            If Esito.ExMessage.Length > 0 Then
                'elimina un eventuale riferimento al link del servizio nella risposta del server
                Esito.ExMessage = Replace(Esito.ExMessage, ": 'uploaderunitoolshis.servizi.gr-u.it'", "", , , CompareMethod.Text)
                'aggiunge il messaggio dell'eccezione al log
                Log.AddLog(Esito.ExMessage)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, TitoloApp)
        End Try

    End Sub

End Class

Public Class SertelEventArgs

    Inherits EventArgs

    Public Operazione As FormDownloadSertel.TipoOperazione
    Public DocInfo As LiquidoDocumenti.DocumentoInfo
    'Public IdCartella As String
    'Public IdFile As String
    'Public FileExt As String
    Public FullPathFiledest As String
End Class