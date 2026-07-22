Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.Web.Services3
Imports System.Net

Public Class FormUploadLiquido

    Private ReadOnly Log As New Utx.ApplicationLog("UploadSertel.log")

    Friend AmbienteLiquido As String = "PROD"
    Friend FlagWip As Boolean

    Private SinistroCorrente As Sinistri

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Log.Info($"Versione Unitools: {Application.ProductVersion} - Utente: {Environment.UserName}")

        'impo finestra
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(480, 430)
        Me.Icon = Risorse.Immagini.Icon("upload")
    End Sub

#Region "proprietà"
    Private mIdSinistro As String
    Public Property IdSinistro() As String
        Get
            Return mIdSinistro
        End Get
        Set(value As String)
            mIdSinistro = value
        End Set
    End Property

    Private mCartellaLocaleSinistro As String
    Public Property CartellaLocaleSinistro() As String
        Get
            Return mCartellaLocaleSinistro
        End Get
        Set(value As String)
            mCartellaLocaleSinistro = value
        End Set
    End Property

    Private mOperazione As String
    Public Property Operazione() As String
        Get
            Return mOperazione
        End Get
        Set(value As String)
            mOperazione = value
        End Set
    End Property

    Private mFileToUpload As Documenti
    Public Property FileToUpload() As Documenti
        Get
            Return mFileToUpload
        End Get
        Set(value As Documenti)
            mFileToUpload = value
        End Set
    End Property

    Private mCodiceDocumento As String
    Public Property CodiceDocumento() As String
        Get
            Return mCodiceDocumento
        End Get
        Set(value As String)
            mCodiceDocumento = value
        End Set
    End Property

    Private mAbbinamento As String
    Public Property Abbinamento() As String
        Get
            Return mAbbinamento
        End Get
        Set(value As String)
            mAbbinamento = value
        End Set
    End Property

    Private mDataArrivoDoc As Date
    Public Property DataArrivoDoc() As Date
        Get
            Return mDataArrivoDoc
        End Get
        Set(value As Date)
            mDataArrivoDoc = value
        End Set
    End Property

    Private mRinomina As Boolean
    Public Property Rinomina() As Boolean
        Get
            Return mRinomina
        End Get
        Set(value As Boolean)
            mRinomina = value
        End Set
    End Property

    Private mNuovoNome As String
    Public Property NuovoNome() As String
        Get
            Return mNuovoNome
        End Get
        Set(value As String)
            mNuovoNome = value
        End Set
    End Property

    Private mCfAssicurato As String
    Public Property CfAssicurato() As String
        Get
            Return mCfAssicurato
        End Get
        Set(value As String)
            mCfAssicurato = value
        End Set
    End Property
#End Region

    Private Sub FormUploadLiquido_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        Try
            If ImpostaControlli() = False Then
                Me.Close()
            End If

            Me.Text = "Upload documenti Liquido-Sertel"
            Me.Icon = Risorse.Immagini.Icon("upload")

            'tipo di abbinamento consentito
            Select Case mAbbinamento
                Case "S"
                    LabelAbbinamento.Text = "Abbinamento consentito: al sinistro"
                    CheckedListBoxPosizioni.Enabled = False
                Case "P"
                    LabelAbbinamento.Text = "Abbinamento consentito: alle posizioni"
                    CheckedListBoxPosizioni.Enabled = True
                Case "E" 'entrambi
                    LabelAbbinamento.Text = "Abbinamento consentito: sinistro o posizioni"
                    CheckedListBoxPosizioni.Enabled = True
            End Select

            'Attenzione: normalizzo formato sinistro con - come separatori perchè in UT è usato il punto
            'ChiamataUpload.Sinistro = ChiamataUpload.Sinistro.Replace(".", "-")
            '-------------------------------------------------------------------------------------------

            SinistroCorrente = New Sinistri(mIdSinistro)
            lbNumeroSinistro.Text = "Sinistro " + SinistroCorrente.IdSinistroNormalizzato

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Function ImpostaControlli() As Boolean
        Try
            lbNumeroSinistro.BackColor = Color.Khaki

            LabelNote.Text = "Note utente da trasmettere a Liquido (max 250 car.)"
            TextBoxNote.MaxLength = 250
            With btnInvia
                .Padding = New Padding(5, 0, 5, 0)
                .Image = Risorse.Immagini.Bitmap("upload")
                .ImageAlign = ContentAlignment.MiddleRight
                .Text = "Invia il documento"
                .TextAlign = ContentAlignment.MiddleLeft
                .Enabled = False
            End With
            With btnEsci
                .Padding = New Padding(5, 0, 5, 0)
                .Image = Risorse.Immagini.Bitmap("esci")
                .ImageAlign = ContentAlignment.MiddleRight
                .Text = "Esci"
                .TextAlign = ContentAlignment.MiddleLeft
            End With
            With LabelAbbinamento
                .BackColor = Color.DodgerBlue
                .ForeColor = Color.White
                .Text = ""
                .TextAlign = ContentAlignment.MiddleCenter
            End With

            CheckedListBoxPosizioni.CheckOnClick = True

            txtStato.BackColor = Color.Gainsboro
            txtStato.Text = ""

            Return True

        Catch ex As Exception
            Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Sub frmUpload_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.Refresh()
        LeggiPosizioni()
    End Sub

    Private Sub frmUpload_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next

        If FlagWip = False Then
            If BackgroundWorker1 IsNot Nothing Then
                Do While BackgroundWorker1.IsBusy : Application.DoEvents() : Loop
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub LeggiPosizioni()

        With pbInvio
            .Style = ProgressBarStyle.Blocks
            .Refresh()
        End With

        txtStato.Text = "Lettura posizioni..."

        CheckedListBoxPosizioni.Items.Clear()

        Try
            Dim Esito As New Utx.ImportaSinistriOMW.EsitoChiamata

            Using s As New Utx.ImportaSinistriOMW.Direzione
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Esito = s.LeggiPosizioniSinistro(SinistroCorrente.IdSinistroNormalizzato,
                                                 Utx.Globale.UtenteCorrente.UniageUser,
                                                 Utx.Globale.UtenteCorrente.UniagePw,
                                                 Utx.Globale.Token)

                If Esito Is Nothing OrElse Esito.Posizioni Is Nothing Then
                    txtStato.Text += $"{Environment.NewLine}{Esito.Errore}"
                    Log.Info(Esito.Errore)
                    Exit Try
                End If

                Dim Dettaglio As Utx.ImportaSinistriOMW.SinistriAgenziaResult = Esito.Posizioni

                Select Case Dettaglio.errorCode
                    Case 0, Nothing
                        'visualizzo le posizioni
                        For k As Integer = 0 To Dettaglio.SinistroDettaglio.ElencoPosizioni.GetUpperBound(0)

                            Dim Posizione As New PosizioneSinistro(Dettaglio.SinistroDettaglio.ElencoPosizioni(k).progrPosizione,
                                                                   Dettaglio.SinistroDettaglio.ElencoPosizioni(k).nomePosizione)

                            CheckedListBoxPosizioni.Items.Add(Posizione)
                        Next

                        CheckedListBoxPosizioni.DisplayMember = "IdPosizione"

                        txtStato.Text = ""
                        btnInvia.Enabled = True

                    Case 1
                        'result.errorCode = 1 - result.ErrorDescription = "Numero sinistro in input vuoto"
                        'non può verificarsi
                        btnInvia.Enabled = False

                    Case 2
                        'result.errorCode = 2 - result.ErrorDescription = "Sinistro non trovato"
                        'potrebbe non essere migrato
                        'txtStato.Text = String.Format("Sinistro non trovato.{0}Verificare il numero sinistro e riprovare.",
                        '                              Environment.NewLine)

                        CheckedListBoxPosizioni.Items.Add("Posizioni sinistro non disponibili")

                        'blocco l'abbinamento al solo sinistro
                        mAbbinamento = "S"
                        LabelAbbinamento.Text = "Abbinamento consentito: al sinistro"
                        CheckedListBoxPosizioni.Enabled = False

                        If SinistroCorrente.AgenziaSinistro.Substring(0, 1) = "8" Then
                            txtStato.Text = String.Format("Numero sinistro Liquido errato.{0}Impossibile inviare il documento", Environment.NewLine)
                            btnInvia.Enabled = False
                        Else
                            txtStato.Text = String.Format("Sinistro probabilmente non ancora migrato.{0}Verificare il numero del sinistro prima dell'invio.", Environment.NewLine)
                            btnInvia.Enabled = True
                        End If

                    Case 3
                        'result.errorCode = 3 - result.ErrorDescription = "Impossibile recuperare il sinistro passato"
                        txtStato.Text = String.Format("Impossibile procedere ora.{0}Riprovate fra qualche minuto.",
                                                      Environment.NewLine)
                        btnInvia.Enabled = False
                End Select
            End Using

            ''creo lo usertoken per la chiamata
            'Using Servizio As New LiquidoSinistro.SinistriAgenziaAPI
            '    'assegno lo user token utente
            '    Servizio.RequestSoapContext.Security.Tokens.Add(Globale.UserToken(Globale.TipoUserToken.UTENTE))

            '    'leggo le posizioni
            '    Dim Dettaglio As LiquidoSinistro.SinistriAgenziaResult = Servizio.getSinistroDettaglio(SinistroCorrente.IdSinistroNormalizzato)

            '    Select Case Dettaglio.errorCode
            '        Case 0, Nothing
            '            'visualizzo le posizioni
            '            For k As Integer = 0 To Dettaglio.SinistroDettaglio.ElencoPosizioni.GetUpperBound(0)

            '                Dim Posizione As New PosizioneSinistro(Dettaglio.SinistroDettaglio.ElencoPosizioni(k).progrPosizione,
            '                                                       Dettaglio.SinistroDettaglio.ElencoPosizioni(k).nomePosizione)

            '                CheckedListBoxPosizioni.Items.Add(Posizione)
            '            Next

            '            CheckedListBoxPosizioni.DisplayMember = "IdPosizione"

            '            txtStato.Text = ""
            '            btnInvia.Enabled = True

            '        Case 1
            '            'result.errorCode = 1 - result.ErrorDescription = "Numero sinistro in input vuoto"
            '            'non può verificarsi
            '            btnInvia.Enabled = False

            '        Case 2
            '            'result.errorCode = 2 - result.ErrorDescription = "Sinistro non trovato"
            '            'potrebbe non essere migrato
            '            'txtStato.Text = String.Format("Sinistro non trovato.{0}Verificare il numero sinistro e riprovare.",
            '            '                              Environment.NewLine)

            '            CheckedListBoxPosizioni.Items.Add("Posizioni sinistro non disponibili")

            '            'blocco l'abbinamento al solo sinistro
            '            mAbbinamento = "S"
            '            LabelAbbinamento.Text = "Abbinamento consentito: al sinistro"
            '            CheckedListBoxPosizioni.Enabled = False

            '            If SinistroCorrente.AgenziaSinistro.Substring(0, 1) = "8" Then
            '                txtStato.Text = String.Format("Numero sinistro Liquido errato.{0}Impossibile inviare il documento", Environment.NewLine)
            '                btnInvia.Enabled = False
            '            Else
            '                txtStato.Text = String.Format("Sinistro probabilmente non ancora migrato.{0}Verificare il numero del sinistro prima dell'invio.", Environment.NewLine)
            '                btnInvia.Enabled = True
            '            End If

            '        Case 3
            '            'result.errorCode = 3 - result.ErrorDescription = "Impossibile recuperare il sinistro passato"
            '            txtStato.Text = String.Format("Impossibile procedere ora.{0}Riprovate fra qualche minuto.",
            '                                          Environment.NewLine)
            '            btnInvia.Enabled = False
            '    End Select
            'End Using

        Catch ex As Exception
            txtStato.Text += $"{Environment.NewLine}{ex.Message}"
            Log.Info(ex)
        Finally
            pbInvio.Style = ProgressBarStyle.Blocks
            pbInvio.Value = pbInvio.Minimum
            pbInvio.Refresh()
        End Try
    End Sub

    Private Sub btnInvia_Click(sender As Object, e As EventArgs) Handles btnInvia.Click

        If mAbbinamento = "P" AndAlso CheckedListBoxPosizioni.CheckedIndices.Count = 0 Then
            MsgBox("Selezionare prima le posizioni a cui abbinare il documento",
                   MsgBoxStyle.Information, "Upload documenti")
            Exit Sub
        End If

        Try
            btnInvia.Enabled = False
            btnEsci.Enabled = False

            With pbInvio
                .Style = ProgressBarStyle.Marquee
                .Enabled = True
            End With

            FlagWip = True

            Dim Arg As New SertelEventArgs

            'blocca controlli
            btnEsci.Enabled = False

            Dim Help As String = ""

            Select Case mAbbinamento
                Case "S" : Help = "{0}: invio al sinistro in corso..."
                Case "P" : Help = "{0}: invio alle posizioni in corso..."
                Case "E"
                    If CheckedListBoxPosizioni.CheckedItems.Count = 0 Then
                        Help = "{0}: invio al sinistro in corso..."
                    Else
                        Help = "{0}: invio alle posizioni in corso..."
                    End If
            End Select

            txtStato.Text = String.Format(Help, NomeDocumentoPerLiquido)

            'avvia l'upload
            Arg.Operazione = Globale.TipoOperazioneLiquido.UPLOAD

            BackgroundWorker1.RunWorkerAsync(Arg)

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Function InviaDocumento() As EsitoBackgroundWorker

        Dim Esito As New EsitoBackgroundWorker

        Try
            Dim IdSinistro As String = SinistroCorrente.IdSinistroNormalizzato
            Dim NomeDocumento As String = NomeDocumentoPerLiquido()
            Dim Doc() As Byte = File.ReadAllBytes(mFileToUpload.FullPathDoc)

            Dim Posizione() As String = Nothing
            If CheckedListBoxPosizioni.CheckedItems.Count > 0 Then
                Log.Info("Invio a posizione")
                Dim i As Integer = 0
                ReDim Posizione(CheckedListBoxPosizioni.CheckedItems.Count - 1)
                For Each p As PosizioneSinistro In CheckedListBoxPosizioni.CheckedItems
                    Posizione(i) = p.Numero
                Next
            Else
                Log.Info("Invio a sinistro")
            End If

            Dim Documento As New Utx.ImportaSinistriOMW.DocumentoLiquido
            With Documento
                .IdSinistro = SinistroCorrente.IdSinistroNormalizzato
                .CodiceDocumento = mCodiceDocumento
                .EstensioneFile = Path.GetExtension(mFileToUpload.FullPathDoc).Replace(".", "")
                .NomeDocumento = NomeDocumentoPerLiquido()
                .Mittente = Utx.Globale.UtenteCorrente.UniageUser
                .DataArrivoDocumento = Format(mDataArrivoDoc, "yyyy-MM-ddTHH:mm:ssZ")
                .DataDocSpecificata = True
                .Documento = File.ReadAllBytes(mFileToUpload.FullPathDoc)
                .Posizione = Posizione
                .Note = TextBoxNote.Text.Trim
            End With

            With Log 'per debug
                .AumentaRientro()
                .Info("Pc in dominio: {0}", {Utx.FunzioniRete.PcInDominio.ToString})
                .Info("Mittente: {0}", {Documento.Mittente})
                .Info("Sinistro: {0}", {Documento.IdSinistro})
                .Info("Documento: {0}", {Documento.NomeDocumento})
                .Info("Codice documento: {0}", {Documento.CodiceDocumento})
                .Info("Estensione: {0}", {Documento.EstensioneFile})
                .Info("Data documento: {0}", {Format(Documento.DataArrivoDocumento, "yyyy-MM-ddTHH:mm:ssZ")})
                If Posizione IsNot Nothing Then
                    .Info("Inviato a {0} posizione", {Documento.Posizione.Length})
                End If
                .Info("Note: {0}", {Documento.Note})
            End With

            Using s As New Utx.ImportaSinistriOMW.Direzione
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.Timeout = 30000
                Esito.EsitoChiamata = s.InviaDocumento(Documento,
                                                       Utx.Globale.UtenteCorrente.UniageUser,
                                                       Utx.Globale.UtenteCorrente.UniagePw,
                                                       Utx.Globale.Token)
            End Using

            If Esito.EsitoChiamata.Esito = True Then
                Esito.Risposta = "OK"
                Esito.ExMessage = ""
            Else
                Esito.Risposta = "KO"
                Esito.ExMessage = Esito.EsitoChiamata.Errore
            End If

        Catch ex As Exception
            Esito.Risposta = "KO"
            Esito.ExMessage = ex.Message
            Log.Info(ex.Message)
        Finally
            Log.Info(Esito.Risposta)
            Log.DiminuisciRientro()
            Log.Info()
        End Try

        Return Esito
    End Function

    Private Function MittenteDocumento() As String
        Try
            Return String.Format("ut:{0}-{1}-{2}-{3}",
                                 SinistroCorrente.CompagniaSinistro,
                                 SinistroCorrente.AgenziaPolizza,
                                 SinistroCorrente.SubAgenziaSinistro,
                                 Utx.Globale.UtenteCorrente.UniageUser)
        Catch ex As Exception
            Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Sub BackgroundWorker1_DoWork(sender As System.Object,
                                         e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        'attraverso "e" vengono passati i dati per il BackgroundWorker
        'le funzioni invocate restituiscono una struttura esito contenente una risposta
        'e il tipo di chiamata effettuata
        Dim Esito As EsitoBackgroundWorker = InviaDocumento()

        'nella struttura esito riporto anche l'operazione fatta per considerazioni a posteriori
        'sulla risposta
        Esito.ArgChiamata = e.Argument

        'restituisco la struttura esito come risultato dell'elaborazione
        e.Result = Esito
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object,
                                                     e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        'fermo la progress bar al max
        With pbInvio
            .Style = ProgressBarStyle.Blocks
            .Value = pbInvio.Maximum
            .Refresh()
        End With

        'analisi dell'esito dell'operazione. e.result contiene la struttura esito
        Try
            Dim Esito As EsitoBackgroundWorker = e.Result

            If Esito.Risposta = "OK" Then
                txtStato.Text += Environment.NewLine + "Invio concluso correttamente."
                txtStato.BackColor = Color.PaleGreen

                'rinomina il file se richisto
                If mRinomina = True Then
                    mFileToUpload.AggiungiProtocollo()
                    mFileToUpload.RinominaDocumento(mNuovoNome)
                End If

                'scrivere la nota relativa all'invio
                InserisciNota()
            Else
                txtStato.BackColor = Color.LightSalmon
                'visualizza l'errore all'utente e lo aggiunge nel log
                txtStato.Text += Environment.NewLine + Esito.ExMessage
                Log.Info(Esito.ExMessage)
            End If

        Catch ex As Exception
            Log.Errore(ex)
        End Try

        FlagWip = False

        btnEsci.Enabled = True
    End Sub

    Private Sub btnEsci_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Private Sub ControlloCartellaSinistro(CartellaSinistro As String)
        If Not Directory.Exists(CartellaSinistro) Then Directory.CreateDirectory(CartellaSinistro)
    End Sub

    Private Sub lbStato_DoubleClick(sender As Object, e As EventArgs)
        Log.ApriLog()
    End Sub

    Private Sub lbStato_TextChanged(sender As Object, e As System.EventArgs)
        txtStato.Refresh()
    End Sub

    Private Sub InserisciNota()
        Try
            Dim Nota As New Utx.Nota
            With Nota
                .NuovaNota = True
                .Tipo = Utx.Nota.TipoNota.NOTA
                .IdNota = SinistroCorrente.IdSinistroNormalizzato
                .CodiceFiscale = mCfAssicurato
                .Utente = Utx.Globale.UtenteCorrente.UniageUser
                .DataModifica = Now
                .Allarme = DBNull.Value
                .Testo = String.Format("Inviato a Sertel il documento: {1}{0}{2}",
                                       Environment.NewLine,
                                       Path.GetFileName(mFileToUpload.FullPathDoc),
                                       TextBoxNote.Text.Trim)
                .SalvaNota()
            End With

        Catch ex As Exception
            Log.Errore(ex)
            MsgBox("Impossibile aggiungere la nota di invio documento", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
        End Try
    End Sub

    Private Function NomeDocumentoPerLiquido() As String
        Try
            NomeDocumentoPerLiquido = mNuovoNome

            Dim NonConsentiti As String = "ˆ~""#%&*:<>?/\{|}"
            For k As Integer = 0 To NonConsentiti.Length - 1
                NomeDocumentoPerLiquido = NomeDocumentoPerLiquido.Replace(NonConsentiti(k), "_")
            Next

            Dim Accentate As String = "àèéìòù"
            Dim Sostitute As String = "aeeiou"

            For k As Integer = 0 To Accentate.Length - 1
                NomeDocumentoPerLiquido = NomeDocumentoPerLiquido.Replace(Accentate(k), Sostitute(k))
            Next

            'devo mettere l'estensione altrimenti l'upload non funziona
            NomeDocumentoPerLiquido = Microsoft.VisualBasic.Left(NomeDocumentoPerLiquido, 60) + Path.GetExtension(mFileToUpload.FullPathDoc)

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Function

    Private Sub txtStato_TextChanged(sender As Object, e As EventArgs) Handles txtStato.TextChanged
        txtStato.Refresh()
    End Sub
End Class

Friend Class PosizioneSinistro

    Sub New(Numero As Integer, Nome As String)
        mNumero = Numero
        mNome = Nome
    End Sub

    Private mNumero As Integer
    Public ReadOnly Property Numero() As String
        Get
            Return Str(mNumero).Trim
        End Get
    End Property

    Private mNome As String
    Public ReadOnly Property Nome() As String
        Get
            Return mNome
        End Get
    End Property

    Public ReadOnly Property IdPosizione() As String
        Get
            Return String.Format("Pos.{0} - {1}", mNumero, mNome)
        End Get
    End Property
End Class