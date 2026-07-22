Public Class FormConsap

    Private Const LinkDoc As String = "http://www.utools.it/Unitools/Doc/Consap/IndexDoc.htm"

    Private WithEvents FormDocumenti As UnitoolsDocumenti.FormDocumenti
    Private WithEvents LabelCliente As New Label
    Private WithEvents ButtonDoc As New Button
    Private WithEvents ButtonRichiesta As New Button
    Private WithEvents ButtonEmail As New Button
    Private WithEvents ButtonEmailDelega As New Button
    Private WithEvents ButtonCreaAttivita As New Button
    Private WithEvents ButtonEsci As New Button
    Private WithEvents ButtonEsportaCsv As New Button
    Private Modalita As Modo

    Private Enum Modo
        MONITOR
        CLIENTE
    End Enum

    Private Enum TipoMail
        SENZA_DELEGA = 0
        CON_DELEGA = 1
    End Enum

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        If Utx.Globale.IdAppOk = False Then
            Application.Exit()
        End If

        Me.Font = Utx.AppFont.Normal
        Me.WindowState = FormWindowState.Maximized
        Me.Icon = Risorse.Immagini.Icon("consap")

        Modalita = Modo.MONITOR
    End Sub

    Private mCodiceFiscale As String = "ND"
    Public Property CodiceFiscale() As String
        Get
            Return mCodiceFiscale
        End Get
        Set(value As String)
            mCodiceFiscale = value
            Modalita = Modo.CLIENTE
        End Set
    End Property

    Private mIdSinistro As String
    Public Property IdSinistro() As String
        Get
            Return mIdSinistro
        End Get
        Set(value As String)
            mIdSinistro = value
        End Set
    End Property

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ImpostaToolStripMain()
        ImpostaControlli()
        'carico i dati del delegato
        Globale.Delegato = DatiDelega.Load
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TabControlMain.ColorStyle = Utx.UtTabControl.TabColorStyle.ROSSO
        If Modalita = Modo.CLIENTE Then
            Me.Text = "Richieste Consap - Cliente"
            Me.Refresh()
            LeggiCliente()
        Else
            Me.Text = "Richieste Consap - Monitor QT auto"
            Me.Refresh()
            LeggiMonitorQT()
        End If
    End Sub

    Private Sub ImpostaControlli()
        On Error Resume Next

        Utx.NetFunc.DoppioBuffer(dgvClienti)
        Utx.NetFunc.DoppioBuffer(dgvSinistri)

        With dgvClienti
            .SuspendLayout()
            .ReadOnly = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Padding = New Padding(0, 1, 0, 1)
            .DefaultCellStyle.Padding = New Padding(0, 1, 0, 1)
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ResumeLayout()
            .Refresh()
        End With
        With dgvSinistri
            .SuspendLayout()
            .ReadOnly = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Padding = New Padding(0, 1, 0, 1)
            .DefaultCellStyle.Padding = New Padding(0, 1, 0, 1)
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ResumeLayout()
            .Refresh()
        End With

        TabPageRichiesta.BackColor = Color.Chocolate
        TabPageRichiesta.Padding = New Padding(0)

        With SplitContainerMain
            'per colorare lo splitter
            .BackColor = Color.Red
            .Panel1.BackColor = Drawing.SystemColors.Control
            .Panel2.BackColor = Drawing.SystemColors.Control

            .Panel1.Padding = New Padding(3)
            .Panel2.Padding = New Padding(3)
            .SplitterWidth = 3
            .BorderStyle = BorderStyle.FixedSingle
            .Refresh()
        End With
    End Sub

    Private Sub ImpostaToolStripMain()
        On Error Resume Next

        With ToolStripMain
            .Margin = New Padding(3)
            .Font = Utx.AppFont.Normal
            .GripStyle = ToolStripGripStyle.Hidden
            .RenderMode = ToolStripRenderMode.ManagerRenderMode
            .BackColor = Color.Transparent
            .Items.Clear()
        End With

        Dim ttch As ToolStripControlHost

        With LabelCliente
            .Text = ""
            .TextAlign = ContentAlignment.MiddleLeft
            .AutoSize = False
            .Width = 200
            .ForeColor = Color.Red
            .BackColor = Color.LightYellow
            .Font = Utx.AppFont.Bold
            .BorderStyle = BorderStyle.FixedSingle
        End With
        ttch = New ToolStripControlHost(LabelCliente)
        ttch.AutoSize = False
        ToolStripMain.Items.Add(ttch)

        ToolStripMain.Items.Add(New ToolStripSeparator)

        With ButtonDoc
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Documenti sinistro"
            .BackColor = Color.Orange
        End With
        ttch = New ToolStripControlHost(ButtonDoc)
        ToolStripMain.Items.Add(ttch)

        ToolStripMain.Items.Add(New ToolStripSeparator)

        With ButtonRichiesta
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Crea richiesta sul sito - Stampa richiesta"
            .ForeColor = Color.White
            .BackColor = Utx.AppColor.VerdeOpaco
            .Font = Utx.AppFont.Bold
        End With
        ttch = New ToolStripControlHost(ButtonRichiesta)
        ToolStripMain.Items.Add(ttch)

        With ButtonEmail
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Invia richiesta"
            .ForeColor = Color.White
            .BackColor = Color.DodgerBlue
            .Font = Utx.AppFont.Bold
        End With
        ttch = New ToolStripControlHost(ButtonEmail)
        ToolStripMain.Items.Add(ttch)

        With ButtonEmailDelega
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Invia richiesta con delega"
            .ForeColor = Color.White
            .BackColor = Color.DodgerBlue
            .Font = Utx.AppFont.Bold
        End With
        ttch = New ToolStripControlHost(ButtonEmailDelega)
        ToolStripMain.Items.Add(ttch)

        ToolStripMain.Items.Add(New ToolStripSeparator)

        With ButtonCreaAttivita
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .BackColor = Color.LightSteelBlue
            .Text = "Crea attività Consap"
        End With
        ttch = New ToolStripControlHost(ButtonCreaAttivita)
        ToolStripMain.Items.Add(ttch)

        With ButtonEsportaCsv
            .Width = 150
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Image = Risorse.Immagini.Bitmap("csv")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Esporta in csv"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        ttch = New ToolStripControlHost(ButtonEsportaCsv)
        ToolStripMain.Items.Add(ttch)

        With ButtonEsci
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Esci"
            .BackColor = Color.Gold
            .Font = Utx.AppFont.Bold
        End With
        ttch = New ToolStripControlHost(ButtonEsci)
        ttch.Alignment = ToolStripItemAlignment.Right
        ToolStripMain.Items.Add(ttch)

        ToolStripMain.Refresh()
    End Sub

    Private Sub LeggiMonitorQT()
        Try
            Me.Cursor = Cursors.WaitCursor
            RemoveHandler dgvClienti.SelectionChanged, AddressOf dgvClienti_SelectionChanged

            'in questo modo mi dà le polizze degli ultimi 3 mesi
            Dim Query As String = "DECLARE @aggiornamento AS date = (SELECT DATEADD(MONTH,-2, MAX(Effetto)) FROM MonitorQT_KMS)
                SELECT 'KS' AS Tipo,Contraente,Polizza,Effetto,CuNew,CuOld,SinConsap,
                TotRataLordoNew,TotRataLordoOld,DiffRataLordo,FrazNew,Sub,Produttore,CodiceFiscale 
                FROM MonitorQT 
                WHERE (NOT FormaTariffaNew IN ('TARIFFA FISSA','S.A.S.','FRANCHIGIA')) AND (CuNew > CuOld) AND (Effetto >= @aggiornamento)
                UNION ALL 
                SELECT 'KMS' AS Tipo,Contraente,Polizza,Effetto,CuNew,CuOld,SinConsap,
                TotRataLordoNew,TotRataLordoOld,DiffRataLordo,FrazNew,Sub,Produttore,CFContraente AS CodiceFiscale 
                FROM MonitorQT_KMS 
                WHERE(CuNew > CuOld) And (Effetto >= @aggiornamento) 
                ORDER BY Effetto,DiffRataLordo"
            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            dgvClienti.SuspendLayout()
            dgvClienti.DataSource = dt

            FormattaColonneMonQT()
            dgvClienti.ResumeLayout()
            dgvClienti.Refresh()

            LeggiSinistri()

            AddHandler dgvClienti.SelectionChanged, AddressOf dgvClienti_SelectionChanged

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub LeggiCliente()
        Try
            Me.Cursor = Cursors.WaitCursor
            RemoveHandler dgvClienti.SelectionChanged, AddressOf dgvClienti_SelectionChanged

            Dim Query As String = String.Format("SELECT Trim(Cognome) + Space(1) + Trim(Nome) AS Contraente,Indirizzo,CAP,Localita,CodiceFiscale 
                FROM Clienti 
                WHERE CodiceFiscale = '{0}'", mCodiceFiscale)

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            dgvClienti.SuspendLayout()
            dgvClienti.DataSource = dt

            FormattaColonneClienti()
            dgvClienti.ResumeLayout()
            dgvClienti.Refresh()

            LeggiSinistro()

            AddHandler dgvClienti.SelectionChanged, AddressOf dgvClienti_SelectionChanged

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub LeggiSinistri()
        Try
            Me.Cursor = Cursors.WaitCursor

            RemoveHandler dgvSinistri.CurrentCellChanged, AddressOf dgvSinistri_CurrentCellChanged

            dgvSinistri.DataSource = Nothing
            dgvSinistri.Refresh()

            LabelCliente.Text = dgvClienti.CurrentRow.Cells("Contraente").Value
            LabelCliente.Refresh()

            Dim Query As String = String.Format("SELECT RamoSinistro,DataSinistro,AgenziaSinistro,EsercizioSinistro,NumeroSinistro,
                RamoPolizza,S.Polizza,P.DataScadenza,P.Frazionamento,P.Convenzione,TipoChiusura,
                DataUltPagam,TargaAssicurato,TargaDanneggiato,CompControparte 
                FROM SinistriDP AS S 
                LEFT JOIN Polizze AS P ON S.RamoPolizza = P.Ramo AND S.Polizza = P.Polizza 
                WHERE CODICEFISCCONTRPOL = '{0}' AND RamoSinistro = 30 
                ORDER BY EsercizioSinistro DESC", dgvClienti.CurrentRow.Cells("CodiceFiscale").Value)

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            dgvSinistri.DataSource = dt
            FormattaColonneSinistri()

            dgvSinistri_CurrentCellChanged(Me, New EventArgs)
            AddHandler dgvSinistri.CurrentCellChanged, AddressOf dgvSinistri_CurrentCellChanged

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub LeggiSinistro()
        Try
            If dgvClienti.Rows.Count = 0 Then
                MsgBox("Attenzione: anagrafica cliente non trovata.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Me.Close()
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            dgvSinistri.DataSource = Nothing
            dgvSinistri.Refresh()

            LabelCliente.AutoEllipsis = True
            LabelCliente.Text = Utx.FunzioniDb.NullToString(dgvClienti.CurrentRow.Cells("Contraente").Value)
            LabelCliente.Refresh()

            Dim Query As String = String.Format("SELECT RamoSinistro,DataSinistro,AgenziaSinistro,EsercizioSinistro,NumeroSinistro,
                RamoPolizza,Polizza,TipoChiusura,DataUltPagam,TargaAssicurato,TargaDanneggiato,CompControparte 
                FROM SinistriDP
                WHERE AgenziaSinistro = {0} AND EsercizioSinistro = {1} AND NumeroSinistro = {2}",
                                                mIdSinistro.Split("-")(1), mIdSinistro.Split("-")(2), mIdSinistro.Split("-")(3))

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            dgvSinistri.DataSource = dt
            FormattaColonneSinistri()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgvClienti_SelectionChanged(sender As Object, e As EventArgs)
        If dgvClienti.CurrentRow IsNot Nothing Then
            dgvClienti.Refresh()
            LeggiSinistri()
        End If
    End Sub

    Private Function IdSinistroDoc() As String
        Try
            Dim r As DataGridViewRow = dgvSinistri.CurrentRow

            Return String.Format("Sinistro {0}.{1}.{2}",
                                 r.Cells("AgenziaSinistro").Value,
                                 r.Cells("EsercizioSinistro").Value,
                                 r.Cells("NumeroSinistro").Value)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Sub ButtonDoc_Click(sender As Object, e As EventArgs) Handles ButtonDoc.Click
        Try
            If String.IsNullOrEmpty(mIdSinistro) = False Then
                FormDocumenti = Utx.OggettoForm.Esiste(Utx.OggettoForm.TipoForm.DOCUMENTI)

                If FormDocumenti Is Nothing Then
                    FormDocumenti = New UnitoolsDocumenti.FormDocumenti
                End If

                FormDocumenti.Reset()
                FormDocumenti.CartellaAllegati = ""

                With FormDocumenti
                    .CodiceFiscale = dgvClienti.CurrentRow.Cells("CodiceFiscale").Value
                    .NomeCliente = LabelCliente.Text
                    .IdSinistro = IdSinistro
                End With

                Utx.OggettoForm.Show(Utx.OggettoForm.TipoForm.DOCUMENTI)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ButtonRichiesta_Click(sender As Object, e As EventArgs) Handles ButtonRichiesta.Click
        Try
            If String.IsNullOrEmpty(mIdSinistro) = False Then
                Using f As New FormRichiesta
                    With f
                        .Cliente = New UtControls.Cliente(dgvClienti.CurrentRow.Cells("CodiceFiscale").Value)
                        .Sinistro = New DatiSinistro(dgvSinistri.CurrentRow.Cells("AgenziaSinistro").Value,
                                                     dgvSinistri.CurrentRow.Cells("EsercizioSinistro").Value,
                                                     dgvSinistri.CurrentRow.Cells("NumeroSinistro").Value)
                        .ShowDialog()
                    End With
                End Using
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonEmail_Click(sender As Object, e As EventArgs) Handles ButtonEmail.Click
        MsgBox("La richiesta a mezzo e-mail non è più accettata dalla CONSAP. Creare la richiesta direttamente dal sito con l'apposita funzione.", MsgBoxStyle.Information)
        ButtonRichiesta.PerformClick()
        'If dgvSinistri.CurrentRow IsNot Nothing Then
        '    InviaEmail(TipoMail.SENZA_DELEGA)
        'End If
    End Sub

    Private Sub ButtonEmailDelega_Click(sender As Object, e As EventArgs) Handles ButtonEmailDelega.Click
        MsgBox("La richiesta a mezzo e-mail non è più accettata dalla CONSAP. Creare la richiesta direttamente dal sito con l'apposita funzione.", MsgBoxStyle.Information)
        ButtonRichiesta.PerformClick()
        'If dgvSinistri.CurrentRow IsNot Nothing Then
        '    InviaEmail(TipoMail.CON_DELEGA)
        'End If
    End Sub

    Private Sub InviaEmail(Tipo As TipoMail)
        Try
            Dim f As New UniCom.FormMail
            f.Messaggio = UniCom.FormMail.TipoMessaggio.Email
            f.CartellaDocumenti = Utx.Globale.Paths.CartellaDocumenti
            f.CodiceFiscale = dgvClienti.CurrentRow.Cells("CodiceFiscale").Value
            f.NomeCliente = dgvClienti.CurrentRow.Cells("Contraente").Value
            f.CartellaSms = Utx.Globale.Paths.CartellaSms
            f.IdPratica = mIdSinistro
            f.BloccaInserimentoNota = False

            f.AddDestinatarioEmail(UniCom.FormMail.TipoDestinatarioMail.A, "rimborsistanza@consap.it")
            f.Oggetto = String.Format("Importo del sinistro CARD - Targa {0}",
                                      dgvSinistri.CurrentRow.Cells("TargaAssicurato").Value)
            f.Testo = String.Format("In relazione a quanto descritto in oggetto si allega la richiesta.{0}" +
                                    "Cordiali saluti.{0}{0}" +
                                    "Allegato: Richiesta CONSAP{0}{0}" +
                                    "Risposta da inoltrare al seguente indirizzo:{0}",
                                    Environment.NewLine)

            If Tipo = TipoMail.CON_DELEGA Then

                f.Testo += String.Format(StrDup(60, "-") +
                                         "{0}UnipolSai Assicurazioni SPA{0}{1}{0}" +
                                         StrDup(60, "-"),
                                         Environment.NewLine, Globale.Delegato.IndirizzoCompleto.ToUpper)
            Else
                Dim Cliente As New UtControls.Cliente(dgvClienti.CurrentRow.Cells("CodiceFiscale").Value)

                f.Testo += String.Format(StrDup(60, "-") +
                                         "{0}{1}{0}" +
                                         StrDup(60, "-"),
                                         Environment.NewLine, Cliente.IndirizzoCompleto.ToUpper)
            End If

            'visualizzo il form della mail
            f.ShowDialog()

            'se la chiamata è ok aggiungo attività
            If f.Esito.EsitoChiamata = True Then
                InserimentoAttivita()
            End If

            f.Dispose()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub InserimentoAttivita()
        Try
            Dim Nota As New Utx.Nota
            With Nota
                .NuovaNota = True
                .Tipo = Utx.Nota.TipoNota.ATTIVITA
                .IdNota = IdSinistro
                .CodiceFiscale = mCodiceFiscale
                .Utente = "CONSAP"
                .DataModifica = Now
                .Allarme = Today.AddDays(10)
                .Testo = "Controllare esito richiesta a CONSAP"
                .SalvaNota()
            End With

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormattaColonneMonQT()

        On Error Resume Next

        With dgvClienti
            .SuspendLayout()

            .Columns("CodiceFiscale").HeaderText = "Codice fiscale"
            .Columns("Effetto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Polizza").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            With .Columns("Contraente")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.BackColor = Color.Lavender
            End With
            With .Columns("InMalus")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Malus"
            End With
            With .Columns("CuNew")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.Coral
                .HeaderText = "CU attuale"
            End With
            With .Columns("CuOld")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.Beige
                .HeaderText = "CU precedente"
            End With
            With .Columns("SinConsap")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Sinistri CONSAP"
            End With
            With .Columns("TotRataLordoNew")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Rata attuale"
            End With
            With .Columns("TotRataLordoOld")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Rata precedente"
            End With
            With .Columns("DiffRataLordo")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .DefaultCellStyle.BackColor = Color.GreenYellow
                .HeaderText = "Differenza rata"
            End With
            With .Columns("FrazNew")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Fraz"
            End With
            .Columns("Sub").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With .Columns("Produttore")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Prod"
            End With

            .AutoResizeColumns()

            .ResumeLayout()
        End With
    End Sub

    Private Sub FormattaColonneClienti()

        On Error Resume Next

        With dgvClienti
            .SuspendLayout()

            .Columns("CodiceFiscale").HeaderText = "Codice fiscale"

            With .Columns("Contraente")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.BackColor = Color.Lavender
            End With

            .AutoResizeColumns()

            .ResumeLayout()
        End With
    End Sub

    Private Sub FormattaColonneSinistri()

        On Error Resume Next

        With dgvSinistri
            .SuspendLayout()

            With .Columns("RamoSinistro")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Ramo sinistro"
            End With
            With .Columns("DataSinistro")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Data sinistro"
            End With
            With .Columns("AgenziaSinistro")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.Coral
                .HeaderText = "Agenzia sinistro"
            End With
            With .Columns("EsercizioSinistro")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.Coral
                .HeaderText = "Esercizio sinistro"
            End With
            With .Columns("NumeroSinistro")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.Coral
                .HeaderText = "Numero sinistro"
            End With
            With .Columns("RamoPolizza")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Ramo polizza"
            End With
            With .Columns("DataScadenza")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Data scadenza"
            End With
            With .Columns("Frazionamento")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Fraz."
            End With
            With .Columns("Convenzione")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Conv."
            End With
            With .Columns("TipoChiusura")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Tipo chiusura"
            End With
            With .Columns("DataUltPagam")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Data ultimo pagamento"
            End With
            With .Columns("TargaAssicurato")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.Moccasin
                .DefaultCellStyle.BackColor = Color.SteelBlue
                .DefaultCellStyle.ForeColor = Color.White
                .HeaderText = "Targa assicurato"
            End With
            With .Columns("TargaDanneggiato")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Targa danneggiato"
            End With
            With .Columns("CompControparte")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Compagnia danneggiato"
            End With

            .AutoResizeColumns()

            .ResumeLayout()
        End With
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub btnIndice_Click(sender As System.Object, e As System.EventArgs) Handles btnIndice.Click
        wbDocumentazione.Navigate(LinkDoc)
    End Sub

    Private Sub TabPageDoc_Enter(sender As Object, e As System.EventArgs) Handles TabPageDoc.Enter
        Cursor.Current = Cursors.WaitCursor
        If wbDocumentazione.Url = Nothing Then wbDocumentazione.Navigate(LinkDoc)
    End Sub

    Private Sub wbDocumentazione_DocumentCompleted(sender As Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles wbDocumentazione.DocumentCompleted
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ButtonCreaAttivita_Click(sender As Object, e As EventArgs) Handles ButtonCreaAttivita.Click
        Try
            If dgvSinistri.CurrentRow IsNot Nothing Then
                Using f As New FormAttivita
                    f.IdSinistro = mIdSinistro
                    f.CodiceFiscale = mCodiceFiscale
                    If Modalita = Modo.MONITOR Then
                        f.Ramo = 30
                        f.Polizza = dgvClienti.CurrentRow.Cells("Polizza").Value
                    Else
                        f.Ramo = dgvSinistri.CurrentRow.Cells("RamoPolizza").Value
                        f.Polizza = dgvSinistri.CurrentRow.Cells("Polizza").Value
                    End If
                    f.ShowDialog()
                End Using
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub dgvSinistri_CurrentCellChanged(sender As Object, e As EventArgs)
        If IsNothing(dgvSinistri.CurrentRow) Then
            mIdSinistro = ""
        Else
            mIdSinistro = String.Format("1.{0:0000}.{1:0000}.{2:0000000}",
                                        dgvSinistri.CurrentRow.Cells("AgenziaSinistro").Value,
                                        dgvSinistri.CurrentRow.Cells("EsercizioSinistro").Value,
                                        dgvSinistri.CurrentRow.Cells("NumeroSinistro").Value)
        End If
    End Sub

    Private Sub ButtonEsportaCsv_Click(sender As Object, e As EventArgs) Handles ButtonEsportaCsv.Click
        If dgvClienti.RowCount > 0 Then
            Utx.NetFunc.Esporta2Csv(dgvClienti, "Clienti_CONSAP.csv", Color.Khaki)
        End If
    End Sub

    Private Sub dgvClienti_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvClienti.CurrentCellChanged
        If Modalita = Modo.MONITOR Then
            If dgvClienti.CurrentRow IsNot Nothing Then
                Me.CodiceFiscale = dgvClienti.CurrentRow.Cells("CodiceFiscale").Value
            End If
        End If
    End Sub
End Class
