Imports System.IO
Imports System.Data.OleDb

Public Class FormSincroDati

    Private Log As New Utx.ApplicationLog("SincroDati")
    Private WithEvents Timer1 As New Timer
    Private DocCopiati As Double
    Private ErroreSincro As Boolean = False

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Font = Utx.AppFont.Normal
        Me.Size = New Size(500, 400)
        Me.MinimumSize = Me.Size
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Normal
        Me.MinimizeBox = False
        Me.Text = "Sincronizzazione dati"
        Me.Icon = Risorse.Immagini.Icon("sincro")

        ImpostaControlli()
    End Sub

    Private Sub FormSincroDati_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Timer1.Dispose()
    End Sub

    Private Sub FormSincroDati_Load(sender As Object, e As EventArgs) Handles Me.Load
        ListBoxStato.Items.Add("In attesa...")
        Timer1.Interval = 3000
        Timer1.Enabled = False
    End Sub

    Private Sub FormSincroDati_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = (ButtonEsci.Enabled = False)
    End Sub

    Private Sub ImpostaControlli()
        With ButtonSincroDb
            .Text = "Sincronizza database"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("sincro")
            .ImageAlign = ContentAlignment.MiddleLeft
            .FlatAppearance.MouseOverBackColor = Color.PaleGreen
        End With
        With ButtonSincroDocMU
            .Text = "Copia documenti dalla rete in locale"
            .FlatAppearance.MouseOverBackColor = Color.PaleGreen
        End With
        With ButtonSincroDocUM
            .Text = "Copia documenti locali in rete"
            .FlatAppearance.MouseOverBackColor = Color.PaleGreen
        End With
        With ButtonEsci
            .FlatAppearance.MouseOverBackColor = Color.LightSalmon
            .Text = "Esci"
        End With
    End Sub

    Private Sub SincronizzaDati()
        Try
            ListBoxStato.Items.Clear()
            Me.Refresh()

            StatoSincro(String.Format("Sincronizzazione database del {0}", Now))

            'sincronizzo utente sms
            SincroSms()

            'sincronizzazione dati-------------------------------------
            StatoSincro("Sincronizzazione database:")

            Dim CartellaDest As String = String.Format("{0}\Dati\{1}", Utx.Globale.Paths.CartellaApp, Utx.Globale.AgenziaRichiesta.CodiceAgenzia)

            'cartella agenzia
            For Each f As String In Directory.GetFiles(Utx.Globale.AgenziaRichiesta.CartellaDati)
                StatoSincro(String.Format("{0}", Path.GetFileName(f)))

                If Path.GetExtension(f).ToLower = ".mdb" Then
                    'le note vengono sincronizzate dopo
                    If Path.GetFileName(f).ToLower <> "note.mdb" Then
                        File.Copy(f, Path.Combine(CartellaDest, Path.GetFileName(f)), True)
                        StatoSincro("> copia dati ok")
                        StatoSincro("> compattazione")
                        Utx.FunzioniDb.CompattaMdb(Path.Combine(CartellaDest, Path.GetFileName(f)), False)
                    End If
                End If
            Next

            'sincronizzo supporto
            File.Copy(Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.SUPPORTO),
                      Utx.ConnessioniDb.PathMdbLocale(Utx.ConnessioniDb.Db.SUPPORTO), True)
            Utx.FunzioniDb.CompattaMdb(Utx.ConnessioniDb.PathMdbLocale(Utx.ConnessioniDb.Db.SUPPORTO), False)

            'sincronizzazione M>U e U>M
            CopiaNote()

        Catch ex As Exception
            ErroreSincro = True
            Log.Errore(ex)
        End Try

        If ErroreSincro = False Then
            StatoSincro("Sincronizzazione dati completata correttamente.")
            ListBoxStato.ForeColor = Color.Green
        Else
            StatoSincro("Sincronizzazione dati completata con errori.")
            ListBoxStato.ForeColor = Color.Red
        End If
    End Sub

    Private Sub SincroSms()
        Try
            StatoSincro("Sincronizzazione utenti sms:")

            'NON sincronizzo gli sms così ognuno si tiene i suoi
            'copio solo la tabella utenti per replicare l'account
            'mi connetto al DB nuovo copiato in locale
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbLocale(Utx.ConnessioniDb.Db.SMS))
                c.Open()

                Utx.FunzioniDb.CancellaTabella(c, "Utente")

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("SELECT * INTO Utente FROM Utente IN '{0}'",
                                                    Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.SMS))
                    cmd.ExecuteNonQuery()
                    StatoSincro("> copia dati ok")
                End Using
            End Using

        Catch ex As Exception
            ErroreSincro = True
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub CopiaNote()
        'da questo momento faccio la sincronizzazione delle note
        'ATTENZIONE: una query UNION non può essere usata perchè taglia i campi memo a 255 caratteri

        'il db origine è quello su M:
        Dim DbRete As String = Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.NOTE)
        'il db destinazione è quello su U:
        Dim DbLocale As String = Utx.ConnessioniDb.PathMdbLocale(Utx.ConnessioniDb.Db.NOTE)

        Try
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + DbLocale)
                c.Open()

                'sincronizzazione da M a U--------------------------------------------------
                'copia la tabella note dalla rete in locale con nome NewSinistriMemo
                Utx.FunzioniDb.CancellaTabella(c, "NewSinistriMemo")

                Using cmd As New OleDbCommand
                    StatoSincro("Sincronizzo le note dei sinistri in locale:...")
                    StatoSincro(String.Format("> Record locali prima della sincronizzazione: {0}", Utx.FunzioniDb.NumeroRecord(c, "SinistriMemo")))

                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("SELECT * INTO NewSinistriMemo FROM SinistriMemo IN '{0}'", DbRete)
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "INSERT INTO SinistriMemo " +
                                      "SELECT n.Utente,n.DataModifica,n.Allarme,n.Tipo,n.IdNota,n.CodiceFiscale,n.Memo " +
                                      "FROM NewSinistriMemo AS n " +
                                      "LEFT JOIN SinistriMemo AS o ON (n.Utente = o.Utente) AND (n.DataModifica = o.DataModifica) " +
                                      "WHERE o.Utente IS NULL"
                    cmd.ExecuteNonQuery()

                    StatoSincro(String.Format("> Record locali dopo la sincronizzazione: {0}", Utx.FunzioniDb.NumeroRecord(c, "SinistriMemo")))
                    Utx.FunzioniDb.CancellaTabella(c, "NewSinistriMemo")
                End Using
            End Using

            Utx.FunzioniDb.CompattaMdb(DbLocale, False)

        Catch ex As Exception
            StatoSincro("Impossibile sincronizzare i sinistri in locale")
            StatoSincro(ex.Message)
            ErroreSincro = True
            Exit Sub
        End Try

        'sincronizzazione da U a M
        Try
            StatoSincro("Sincronizzo le note dei sinistri in rete:...")
            'mi connetto al DB origine (di rete) su M:
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + DbRete) 'nuova stringa verso db su M
                c.Open()

                StatoSincro(String.Format("> Record in rete prima della sincronizzazione: {0}", Utx.FunzioniDb.NumeroRecord(c, "SinistriMemo")))

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'cancello i record in M:
                    cmd.CommandText = "DELETE * FROM SinistriMemo"
                    cmd.ExecuteNonQuery()
                    'copio la tabella aggiornata con tutte le note, che ora si trova in locale in U:, sul DB in M:
                    cmd.CommandText = "INSERT INTO SinistriMemo " +
                                      "SELECT Utente,DataModifica,Allarme,Tipo,IdNota,CodiceFiscale,Memo " +
                                      "FROM SinistriMemo IN '{0}'"
                    cmd.CommandText = String.Format(cmd.CommandText, DbLocale)
                    cmd.ExecuteNonQuery()
                End Using

                StatoSincro(String.Format("> Record in rete dopo la sincronizzazione: {0}", Utx.FunzioniDb.NumeroRecord(c, "SinistriMemo")))
            End Using

        Catch ex As Exception
            StatoSincro("Impossibile aggiornare le note su M:")
            StatoSincro("Chiudere i sinistri sugli altri Pc in rete e riprovare.")
            MsgBox(String.Format("Impossibile aggiornare le note su M:{0}Chiudere i sinistri sugli altri Pc in rete e riprovare.",
                                 Environment.NewLine), MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            ErroreSincro = True
        End Try
    End Sub

    Private Sub ButtonSincroDb_Click(sender As Object, e As EventArgs) Handles ButtonSincroDb.Click
        'sincronizzazione database
        Try
            If MsgBox(String.Format("Sincronizzare i dati locali con quelli di rete?{0}I dati archiviati in locale verranno sovrascritti.",
                                    Environment.NewLine), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2,
                                Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then

                Application.DoEvents()

                Cursor = Cursors.WaitCursor
                AbilitaButton(False)

                SincronizzaDati()
            End If

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            AbilitaButton(True)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub StatoSincro(Messaggio As String)
        On Error Resume Next

        ListBoxStato.Items.Add(String.Format("[{0}]: {1}", Format(Now, "HH:mm:ss"), Messaggio))
        ListBoxStato.SelectedIndex = ListBoxStato.Items.Count - 1
        'aggiorno il log
        Log.Info(Messaggio)
    End Sub

    Private Sub AbilitaButton(Attiva As Boolean)
        On Error Resume Next
        ButtonSincroDb.Enabled = Attiva
        ButtonSincroDocUM.Enabled = Attiva
        ButtonSincroDocMU.Enabled = Attiva
        ButtonEsci.Enabled = Attiva
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        StatoSincro("> ..." & DocCopiati)
    End Sub

    Private Sub SincroDocU2M()
        'sincronizzazione documenti da U a M
        Try
            If MsgBox("Copiare i documenti archiviati in locale sul disco di rete?",
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then

                Cursor = Cursors.WaitCursor

                StatoSincro("Sincronizzazione dei documenti in corso. Attendere...")
                AbilitaButton(False)

                Dim DocDiscoLocale As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "Documenti")
                Directory.CreateDirectory(DocDiscoLocale)

                Timer1.Enabled = True

                DocCopiati = 0
                StatoSincro("Copia dei documenti locali al disco di rete...")
                Utx.NetFunc.SincronizzaFolder(DocDiscoLocale, Utx.Globale.Paths.CartellaDocumenti, DocCopiati, True)

                Timer1.Enabled = False

                StatoSincro("Documenti copiati: " & DocCopiati)
                StatoSincro("Sincronizzazione documenti locali >> rete conclusa.")
                StatoSincro("In attesa...")
            End If

        Catch ex As Exception
            ErroreSincro = True
            Log.Errore(ex)
        Finally
            StatoSincro("In attesa...")
            AbilitaButton(True)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub SincroDocM2U()
        'sincronizzazione documenti da U a M
        Try
            If MsgBox("Copiare i documenti archiviati sul disco di rete in questo Pc?",
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then

                Cursor = Cursors.WaitCursor

                StatoSincro("Sincronizzazione dei documenti in corso. Attendere...")
                AbilitaButton(False)

                Dim DocDiscoLocale As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "Documenti")
                Directory.CreateDirectory(DocDiscoLocale)

                Timer1.Interval = 3000
                Timer1.Enabled = True

                DocCopiati = 0
                StatoSincro("Copia dei documenti di rete in locale...")
                Utx.NetFunc.SincronizzaFolder(Utx.Globale.Paths.CartellaDocumenti, DocDiscoLocale, DocCopiati, True)

                Timer1.Interval = 0
                Timer1.Enabled = False

                StatoSincro("Documenti copiati: " & DocCopiati)
                StatoSincro("Sincronizzazione documenti rete >> locale conclusa.")
                StatoSincro("In attesa...")
            End If

        Catch ex As Exception
            ErroreSincro = True
            Log.Errore(ex)
        Finally
            StatoSincro("In attesa...")
            AbilitaButton(True)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonSincroDocMU_Click(sender As Object, e As EventArgs) Handles ButtonSincroDocMU.Click
        SincroDocM2U()
    End Sub

    Private Sub ButtonSincroDocUM_Click(sender As Object, e As EventArgs) Handles ButtonSincroDocUM.Click
        SincroDocU2M()
    End Sub
End Class