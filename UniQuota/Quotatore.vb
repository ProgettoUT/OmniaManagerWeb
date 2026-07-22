Imports UniQuota.Prodotto

Public Class Quotatore
    Private ClienteDataNascita As Date

    Private Sub Quotatore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

#If Not Debug Then 'HIDE_ESSIG
        ButtonSalvaInEssig.Visible = False

        essigCmbSubagenzia.Visible = False
        essigCmbIntermediario.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        GroupBox1.Height = 170

        optEssig.Visible = False
#End If

        Dim host As New ToolStripControlHost(tlpStampaDati)
        toolBar.Items.Insert(10, host)

        TableLayoutPanel8.Size = New Size(TableLayoutPanel8.Size.Width, My.Settings("SplitterDistance2"))
        Button1.Visible = True
        TableLayoutPanel8.Visible = False

        TabAgenzia.Controls.Remove(Panel2)
        TabAgenzia.Controls.Add(lblCaricamento)
        My.Application.DoEvents()

        Dim p As Control = cmbDominio.Parent
        PanelTemp.Controls.Add(cmbDominio)
        AttachCombo(cmbDominio, Dominio.Divisioni)
        QuotatoreLoad()
        p.Controls.Add(cmbDominio)
        My.Application.DoEvents()

        If Me.TabProdotti.Controls.Contains(TabCliente) Then
            Me.TabProdotti.SelectedTab = TabCliente
        End If

        My.Application.DoEvents()
        TabAgenzia.Controls.Remove(lblCaricamento)
        TabAgenzia.Controls.Add(Panel2)
        My.Application.DoEvents()
    End Sub

    Private Sub QuotatoreLoad()

        If Globale.licenza.IsAttiva Then
            cmbDominio.Enabled = False
            txtAttAgenzia.Enabled = False
            cmdAttiva.Text = "Disattiva"
            cmbDominio.SelectedValue = Globale.licenza.CodiceCompagnia
            txtAttAgenzia.Text = Globale.licenza.CodiceAgenzia

            AddOrRemove(True, TabCliente)
            AddOrRemove(Globale.licenza.ProdottoIsAttivo("P07261"), Me.TabP07261) ' casa
            AddOrRemove(Globale.licenza.ProdottoIsAttivo("P07263"), Me.TabP07263) ' casa & servizi
            AddOrRemove(Globale.licenza.ProdottoIsAttivo("P01201"), Me.TabP01201) ' Infortuni
            AddOrRemove(Globale.licenza.ProdottoIsAttivo("P04226"), Me.TabP04226) ' commercio
            AddOrRemove(Globale.licenza.ProdottoIsAttivo("P07260"), Me.TabP07260) ' Condominio
            AddOrRemove(Globale.licenza.ProdottoIsAttivo("PSMART"), Me.TabPSMART) ' prodotti smart
            AddOrRemove(Globale.licenza.ProdottoIsAttivo("P02229"), Me.TabP02229) ' IngegnereArchitetto
            AddOrRemove(Globale.licenza.ProdottoIsAttivo("P01203"), Me.TabP01203) ' Circolazione
            AddOrRemove(Globale.licenza.ProdottoIsAttivo("P01204"), Me.TabP01204) ' UnipolSai infortuni premium
            AddOrRemove(Globale.licenza.ProdottoIsAttivo("P01261"), Me.TabP01261) ' UnipolSai Salute invalidità
            AddOrRemove(Globale.licenza.ProdottoIsAttivo("P01262"), Me.TabP01262) ' UnipolSai Salute spese mediche
            AddOrRemove(Globale.licenza.ProdottoIsAttivo("P01263"), Me.TabP01263) ' UnipolSai Salute ricovero
        Else
            Do Until TabProdotti.Controls.Count = 1
                TabProdotti.Controls.RemoveAt(1)
            Loop

            cmdAttiva.Text = "Attiva"

            If CaricaCompagniaAgenzia() Then
                cmbDominio.Enabled = False
                txtAttAgenzia.Enabled = False
            Else
                cmbDominio.Enabled = True
                txtAttAgenzia.Enabled = True
            End If

            MsgBox("Per attivare il quotatore è necessario disporre di una connessione ad internet. Selezionare la Compagnia ed inserire il codice di agenzia a 5 cifre e premere il bottone Attiva", MsgBoxStyle.Information)
        End If

        ToolStripButton3.Enabled = (EMAIL_SMTP IsNot Nothing)

        CaricaDatiAgenzia()
        CaricaDatiCliente()
        FascicoloCarica()

        AgganciaHelp(Me, AddressOf MouseClickedHelp)
    End Sub

    Private Sub AddOrRemove(ByVal aggiungi As Boolean, ByVal tab As TabPage)
        With Me.TabProdotti.Controls
            If aggiungi Then
                If Not .Contains(tab) Then .Add(tab)
            Else
                If .Contains(tab) Then .Remove(tab)
            End If
        End With

    End Sub

    Private Sub Quotatore_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            With My.Computer.FileSystem
                If .FileExists("C:\ApplicazioniDirezione\Unitools\UtLoader.new") Then
                    If .FileExists("C:\ApplicazioniDirezione\Unitools\UtLoader.exe") Then
                        .DeleteFile("C:\ApplicazioniDirezione\Unitools\UtLoader.exe")
                    End If
                    .RenameFile("C:\ApplicazioniDirezione\Unitools\UtLoader.new", "UtLoader.exe")
                End If
            End With
        Catch ex As Exception
        End Try

        My.Settings("SplitterDistance2") = TableLayoutPanel8.Size.Height
        My.Settings.Save()
    End Sub

    Private Sub ControlsToPreventivo(ByVal preventivo As Prodotto, ByVal diretto As Boolean)
        If diretto Then
            With preventivo.Agenzia
                '.Codice = txtAgenziaCodice.Text
                '.Denominazione = txtAgenziaDescrizione.Text
                '.Indirizzo = txtAgenziaIndirizzo.Text
                '.Cap = txtAgenziaCap.Text
                '.Localita = txtAgenziaLocalita.Text
                '.Provincia = txtAgenziaProvincia.Text
                '.Telefono = txtAgenziaTelefono.Text
                '.Fax = txtAgenziaFax.Text
                '.Email = txtAgenziaEmail.Text
                '.NumeroIscrizioneIsvap = txtAgenziaNII.Text
                .Divisione = Dominio.Divisioni.Item(Globale.licenza.CodiceCompagnia).Denominazione
                .Compagnia = Globale.licenza.CodiceCompagniaEssig
                .Codice = Globale.licenza.CodiceAgenzia
                .Denominazione = Globale.licenza.Descrizione
                .Indirizzo = Globale.licenza.Indirizzo
                .Cap = Globale.licenza.Cap
                .Localita = Globale.licenza.Localita
                .Provincia = Globale.licenza.Provincia
                .Telefono = Globale.licenza.Telefono
                .Fax = Globale.licenza.Fax
                .Email = Globale.licenza.Email
                .NumeroIscrizioneIsvap = Globale.licenza.IscrizioneRui
            End With
            'With preventivo.Intermediario
            '    .Cognome = txtAgenteCognome.Text
            '    .Nome = txtAgenteNome.Text
            '    .NumeroIscrizioneIsvap = txtAgenteNII.Text
            'End With
            With preventivo.Cliente
                .CodiceFiscale = txtClienteCodiceFiscale.Text
                .Indirizzo = txtClienteIndirizzo.Text
                .Cognome = txtClienteCognome.Text
                .Nome = txtClienteNome.Text
                .Cap = txtClienteCap.Text
                .Localita = txtClienteLocalita.Text
                .Provincia = txtClienteProvincia.Text
                .Telefono = txtClienteTelefono.Text
                .Email = txtClienteEmail.Text
                .Convivente = IIf(txtClienteConvivente.Text = txtClienteConvivente.Tag, "", txtClienteConvivente.Text)
                .DataNascita = ClienteDataNascita
            End With

            CaricaSubangenzieEtIntermediari()
#If Debug Then 'HIDE_ESSIG
            With preventivo
                .Subagenzia = essigCmbSubagenzia.SelectedItem
                .Intermediario = essigCmbIntermediario.SelectedItem
            End With
#End If
        Else
            'With preventivo.Agenzia
            '    txtAgenziaCodice.Text = .Codice
            '    txtAgenziaDescrizione.Text = .Denominazione
            '    txtAgenziaIndirizzo.Text = .Indirizzo
            '    txtAgenziaCap.Text = .Cap
            '    txtAgenziaLocalita.Text = .Localita
            '    txtAgenziaProvincia.Text = .Provincia
            '    txtAgenziaTelefono.Text = .Telefono
            '    txtAgenziaFax.Text = .Fax
            '    txtAgenziaEmail.Text = .Email
            '    txtAgenziaNII.Text = .NumeroIscrizioneIsvap
            'End With
            'With preventivo.Intermediario
            '    txtAgenteCognome.Text = .Cognome
            '    txtAgenteNome.Text = .Nome
            '    txtAgenteNII.Text = .NumeroIscrizioneIsvap
            'End With
            With preventivo.Cliente
                If .CodiceFiscale <> vbNullString Then
                    txtClienteCodiceFiscale.Text = .CodiceFiscale
                    txtClienteCognome.Text = .Cognome
                    txtClienteNome.Text = .Nome
                    txtClienteIndirizzo.Text = .Indirizzo
                    txtClienteCap.Text = .Cap
                    txtClienteLocalita.Text = .Localita
                    txtClienteProvincia.Text = .Provincia
                    txtClienteTelefono.Text = .Telefono
                    txtClienteEmail.Text = .Email
                    txtClienteConvivente.Text = IIf(.Convivente <> "", .Convivente, txtClienteConvivente.Tag)
                    ClienteDataNascita = .DataNascita
                End If
            End With
        End If
    End Sub

    Private Sub MostraDettaglioCalcolo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If TypeOf TabProdotti.SelectedTab.Controls(0) Is P00000FE Then
            CType(TabProdotti.SelectedTab.Controls(0), P00000FE).preventivo.CalcolaLog()
            Dettaglio.txtDettaglio.Text = logCalcolo
            Dettaglio.txtDettaglio.Select(0, 0)
            Dettaglio.ShowDialog()
        Else
            MsgBox("Nessun prodotto selezionato", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Stampa(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click, ToolStripButton3.Click
        Try
            Dim options As StampaOptions = StampaOptions.StampaProdotto
            options += StampaOptions.StampaAgenzia
            'If chkStampaDatiAgenzia.Checked Then options += StampaOptions.StampaAgenzia
            If chkStampaDatiCliente.Checked Then options += StampaOptions.StampaCliente

            If sender.Equals(ToolStripButton4) Then
                options += StampaOptions.MostraAnteprima
            Else
                options += StampaOptions.InviaEmail
            End If

            If (options And StampaOptions.InviaEmail) = StampaOptions.InviaEmail Then
                If Trim(txtClienteEmail.Text) = "" Then
                    MsgBox("Inserire l'email nella scheda cliente", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If Not ValidaEmail(txtClienteEmail.Text) Then
                    MsgBox("Sintassi email errata. controllare l'email nella scheda cliente", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            If TypeOf TabProdotti.SelectedTab.Controls(0) Is P00000FE Then
                With CType(TabProdotti.SelectedTab.Controls(0), P00000FE)
                    If .preventivo.ListinoLordo = 0.0# Then
                        MsgBox("Nessun preventivo da stampare.", MsgBoxStyle.Information)
                    Else
#If Not Debug Then
                        MsgBox("Prima di consegnare il preventivo al cliente, si ricorda di ottemperare agli adempimenti del Regolamento ISVAP n. 5 del 2006.", MsgBoxStyle.Information)
#End If
                        Globale.LogNet.Add(.preventivo.IdProdottoPerLog, "S")
                        .preventivo.Stampa(options)
                    End If
                End With
            ElseIf TabProdotti.SelectedTab Is TabFascicolo Then
                Dim fascicolo As Fascicolo = FascicoloGet()
                If fascicolo.ListinoLordo = 0.0# Then
                    MsgBox("Nessun preventivo da stampare.", MsgBoxStyle.Information)
                Else
#If Not Debug Then
                        MsgBox("Prima di consegnare il preventivo al cliente, si ricorda di ottemperare agli adempimenti del Regolamento ISVAP n. 5 del 2006.", MsgBoxStyle.Information)
#End If
                    For Each preventivo As Prodotto In fascicolo.Prodotti
                        Globale.LogNet.Add(preventivo.IdProdottoPerLog, "S")
                    Next
                    fascicolo.Stampa(options)
                End If
            Else
                MsgBox("Nessun prodotto selezionato", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("Errore nella creazione del pdf.", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub Chiudi(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub PreventivoSalva(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        If TypeOf TabProdotti.SelectedTab.Controls(0) Is P00000FE Then
            With CType(TabProdotti.SelectedTab.Controls(0), P00000FE)
                If .preventivo.ListinoLordo = 0.0# Then
                    MsgBox("Nessun preventivo da salvare.", MsgBoxStyle.Information)
                Else
                    .Salva()
                End If

            End With
        ElseIf TabProdotti.SelectedTab.Controls(0) Is grdFascicolo Then
            Dim Fascicolo As Fascicolo = FascicoloGet()
            If Fascicolo.ListinoLordo = 0.0# Then
                MsgBox("Nessun preventivo da salvare.", MsgBoxStyle.Information)
            Else
                DataManager.SalvaPreventivo(Fascicolo)
            End If
        Else
            MsgBox("Nessun prodotto selezionato", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub PreventivoRicalcola(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        If TypeOf TabProdotti.SelectedTab.Controls(0) Is P00000FE Then
            CType(TabProdotti.SelectedTab.Controls(0), P00000FE).ValuesChanged(sender, e)
        Else
            MsgBox("Nessun prodotto selezionato", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub PreventivoApri(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        PreventivoApri(DataManager.LoadPreventivo())
    End Sub

    Private Sub grdPreventiviApri(ByVal rowIndex As Integer)
        Dim filename As String = grdPreventivi.Rows(rowIndex).Tag
        PreventivoApri(DataManager.LoadPreventivo(filename))
    End Sub

    Private Sub PreventivoNuovo()
        TabProdotti.SelectedTab.Controls.Add(lblCaricamento)
        My.Application.DoEvents()

        If TabProdotti.SelectedTab.Equals(TabP04226) Then
            PreventivoNuovo(TabP04226, New P04226.YouCommercio, New P04226.P04226FE)
        ElseIf TabProdotti.SelectedTab.Equals(TabP07260) Then
            PreventivoNuovo(TabP07260, New P07260.YouCondominio, New P07260.P07260FE)
        ElseIf TabProdotti.SelectedTab.Equals(TabP07261) Then
            PreventivoNuovo(TabP07261, New P07261.youCasa, New P07261.P07261FE)
        ElseIf TabProdotti.SelectedTab.Equals(TabP07263) Then
            PreventivoNuovo(TabP07263, New P07263.UnipolSaiCasaServizi, New P07263.P07263FE)
        ElseIf TabProdotti.SelectedTab.Equals(TabP01201) Then
            PreventivoNuovo(TabP01201, New P01201.YouInfortuni, New P01201.P01201FE)
        ElseIf TabProdotti.SelectedTab.Equals(TabP01203) Then
            PreventivoNuovo(TabP01203, New P01203.Circolazione, New P01203.P01203FE)
        ElseIf TabProdotti.SelectedTab.Equals(TabP01204) Then
            PreventivoNuovo(TabP01204, New P01204.InfortuniPremium, New P01204.P01204FE)
        ElseIf TabProdotti.SelectedTab.Equals(TabP01261) Then
            PreventivoNuovo(TabP01261, New P01261.Invalidita, New P01261.P01261FE)
        ElseIf TabProdotti.SelectedTab.Equals(TabP01262) Then
            PreventivoNuovo(TabP01262, New P01262.SpeseMediche, New P01262.P01262FE)
        ElseIf TabProdotti.SelectedTab.Equals(TabP01263) Then
            PreventivoNuovo(TabP01263, New P01263.Ricovero, New P01263.P01263FE)
        ElseIf TabProdotti.SelectedTab.Equals(TabP02229) Then
            PreventivoNuovo(TabP02229, New P02229.YouIngegnereArchitetto, New P02229.P02229FE)
        ElseIf TabProdotti.SelectedTab.Equals(TabPSMART) Then
            PreventivoNuovo(TabPSMART, New PSMART.smart, New PSMART.PSMARTFE)
        End If

        My.Application.DoEvents()
        TabProdotti.SelectedTab.Controls.Remove(lblCaricamento)
        My.Application.DoEvents()
    End Sub

    Private Sub PreventivoNuovo(ByVal tab As TabPage, ByVal preventivo As Prodotto, ByVal frontend As P00000FE)
        With tab
            ControlsToPreventivo(preventivo, True)
            frontend.Apri(preventivo)

            AddHandler frontend.ControlsToPreventivoEvent, AddressOf ControlsToPreventivo
            AddHandler frontend.ClickedHelp, AddressOf MouseClickedHelp
            frontend.Dock = DockStyle.Fill
            .Controls.Add(frontend)
        End With
    End Sub

    Private Sub PreventivoApri(ByVal p As Prodotto)
        If p IsNot Nothing Then
            If TypeOf p Is P04226.YouCommercio Then
                PreventivoApri(p, TabP04226, GetType(P04226.P04226FE))
            ElseIf TypeOf p Is P07260.YouCondominio Then
                PreventivoApri(p, TabP07260, GetType(P07260.P07260FE))
            ElseIf TypeOf p Is P07261.youCasa Then
                PreventivoApri(p, TabP07261, GetType(P07261.P07261FE))
            ElseIf TypeOf p Is P07263.UnipolSaiCasaServizi Then
                PreventivoApri(p, TabP07263, GetType(P07263.P07263FE))
            ElseIf TypeOf p Is P01201.YouInfortuni Then
                PreventivoApri(p, TabP01201, GetType(P01201.P01201FE))
            ElseIf TypeOf p Is P01203.Circolazione Then
                PreventivoApri(p, TabP01203, GetType(P01203.P01203FE))
            ElseIf TypeOf p Is P01204.InfortuniPremium Then
                PreventivoApri(p, TabP01204, GetType(P01204.P01204FE))
            ElseIf TypeOf p Is P01261.Invalidita Then
                PreventivoApri(p, TabP01261, GetType(P01261.P01261FE))
            ElseIf TypeOf p Is P01262.SpeseMediche Then
                PreventivoApri(p, TabP01262, GetType(P01262.P01262FE))
            ElseIf TypeOf p Is P01263.Ricovero Then
                PreventivoApri(p, TabP01263, GetType(P01263.P01263FE))
            ElseIf TypeOf p Is P02229.YouIngegnereArchitetto Then
                PreventivoApri(p, TabP02229, GetType(P02229.P02229FE))
            ElseIf TypeOf p Is PSMART.smart Then
                PreventivoApri(p, TabPSMART, GetType(PSMART.PSMARTFE))
            ElseIf TypeOf p Is Fascicolo Then
                TabProdotti.SelectedTab = TabFascicolo

                For Each tab As TabPage In TabProdotti.TabPages
                    If tab.Name.Substring(3, 1) = "P" Then
                        If tab.HasChildren Then
                            Dim frontend As P00000FE = CType(tab.Controls(0), P00000FE)
                            tab.Controls.Remove(frontend)
                            frontend.Dispose()
                            frontend = Nothing
                        End If
                    End If
                Next

                For Each Prodotto As Prodotto In CType(p, Fascicolo).Prodotti
                    If Globale.licenza.ProdottoIsAttivo(Prodotto.CodiceProdotto) Then
                        Prodotto.New2()
                        PreventivoApri(Prodotto)
                    End If
                Next
                FascicoloAggiorna()
            End If
        End If
    End Sub

    Private Sub PreventivoApri(ByVal p As Prodotto, ByVal tab As TabPage, ByVal fet As System.Type)
        Dim frontend As P00000FE

        If tab.HasChildren Then
            frontend = CType(tab.Controls(0), P00000FE)
            tab.Controls.Remove(frontend)
            frontend.Dispose()
            frontend = Nothing
        End If

        My.Application.DoEvents()
        tab.Controls.Add(lblCaricamento)
        My.Application.DoEvents()
        If TabProdotti.SelectedTab IsNot TabFascicolo Then
            TabProdotti.SelectedTab = tab
        End If
        My.Application.DoEvents()

        If frontend Is Nothing Then
            frontend = GetNewInstance(fet)
            AddHandler frontend.ControlsToPreventivoEvent, AddressOf ControlsToPreventivo
            AddHandler frontend.ClickedHelp, AddressOf MouseClickedHelp
            frontend.Dock = DockStyle.Fill
        End If

        'aggiungo il frontend ad un controllo temporaneo per permettere
        'a vb di aggiungere delle schede (vedi abitazione del prodotto casa)
        'è un comportamento che non capisco, ma il fine giustifica i mezzi!!!
        PanelTemp.Controls.Add(frontend)
        frontend.Apri(p)
        My.Application.DoEvents()

        tab.Controls.Add(frontend)
        tab.Controls.Remove(lblCaricamento)
        PanelTemp.Controls.Remove(frontend)
        My.Application.DoEvents()
    End Sub

    Public Function CaricaCompagniaAgenzia() As Boolean
        Dim isUnipol As Boolean = False
        Try
            With CreaRecordset("SELECT * FROM ProfiloUtente")
                If .Read Then
                    txtAttAgenzia.Text = .Item("Agenzia").ToString.Trim()
                    'txtAgenziaCodice.Text = .Item("Agenzia").ToString.Trim()
                    'txtAgenziaDescrizione.Text = .Item("Localita").ToString.Trim()
                    'txtAgenziaIndirizzo.Text = .Item("Indirizzo").ToString.Trim()
                    'txtAgenziaCap.Text = .Item("Cap").ToString.Trim()
                    'txtAgenziaLocalita.Text = .Item("Localita").ToString.Trim()
                    'txtAgenziaProvincia.Text = .Item("Provincia").ToString
                    'txtAgenziaEmail.Text = .Item("Email").ToString.Trim()
                    'txtAgenziaTelefono.Text = .Item("Telefono").ToString.Trim()

                    isUnipol = True
                End If
                .Close()
            End With
        Catch
        End Try

        If isUnipol Then
            cmbDominio.SelectedValue = "082" '.SelectedItem = Dominio.Divisioni("082")
        Else
            cmbDominio.SelectedValue = "034" '.SelectedItem = Dominio.Divisioni("034")
        End If
        Return isUnipol
    End Function


    Public Function CaricaDatiAgenzia() As Boolean
        Try
            With Globale.licenza
                txtAgenziaCodice.Text = .CodiceAgenzia
                txtAgenziaDescrizione.Text = .Descrizione
                txtAgenziaIndirizzo.Text = .Indirizzo
                txtAgenziaCap.Text = .Cap
                txtAgenziaLocalita.Text = .Localita
                txtAgenziaProvincia.Text = .Provincia
                txtAgenziaTelefono.Text = .Telefono
                txtAgenziaFax.Text = .Fax
                txtAgenziaEmail.Text = .Email
                txtAgenziaNII.Text = .IscrizioneRui
            End With
        Catch
        End Try

        Return True
    End Function

    Public Function CaricaDatiCliente() As Boolean
        Try
            If IsNullOrWhiteSpace(CLIENTE_CODICEFISCALE) Then
                txtClienteCodiceFiscale.ReadOnly = False
                txtClienteCognome.ReadOnly = False
                txtClienteNome.ReadOnly = False
                txtClienteIndirizzo.ReadOnly = False
                txtClienteCap.ReadOnly = False
                txtClienteLocalita.ReadOnly = False
                txtClienteProvincia.ReadOnly = False
                txtClienteEmail.ReadOnly = False
                txtClienteTelefono.ReadOnly = False
                txtClienteConvivente.ReadOnly = False
            Else
                txtClienteCodiceFiscale.Text = CLIENTE_CODICEFISCALE
                With (CreaRecordset("SELECT * FROM CLIENTI WHERE CodiceFiscale = " & TO_STRING(CLIENTE_CODICEFISCALE)))

                    If .Read Then
                        txtClienteCognome.Text = .Item("Cognome").ToString.Trim()
                        txtClienteNome.Text = .Item("Nome").ToString.Trim()
                        txtClienteIndirizzo.Text = .Item("Indirizzo").ToString.Trim()
                        txtClienteCap.Text = .Item("Cap").ToString.Trim()
                        txtClienteLocalita.Text = .Item("Localita").ToString.Trim()
                        txtClienteProvincia.Text = .Item("Provincia").ToString.Trim()
                        txtClienteEmail.Text = .Item("Email").ToString.Trim()
                        txtClienteTelefono.Text = .Item("Cellulare").ToString.Trim()
                        txtClienteConvivente.Text = txtClienteConvivente.Tag
                        ClienteDataNascita = .Item("DataNascita")
                    Else
                        log.Debug("NON TROVATO CODICEFISCALE = " & CLIENTE_CODICEFISCALE)
                    End If
                    .Close()
                End With
            End If
        Catch ex As Exception
            log.Debug("ERRORE SU CODICEFISCALE = " & CLIENTE_CODICEFISCALE)
            log.Debug(ex.Message)
        End Try

        Return True
    End Function

    Private Sub MouseClickedHelp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        TableLayoutPanel8.Visible = True
    End Sub
    Private Sub HelpCollapse(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        TableLayoutPanel8.Visible = False
    End Sub
    Private Sub Button1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            TableLayoutPanel8.Size = Size.Subtract(TableLayoutPanel8.Size, New Size(0, e.Location.Y))
        End If
    End Sub

    Private Sub TabProdotti_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabProdotti.SelectedIndexChanged
        If TabProdotti.SelectedTab Is Nothing Then Return

        If TabProdotti.SelectedTab.Equals(TabAgenzia) Then
            CaricaSubangenzieEtIntermediari()
        ElseIf TabProdotti.SelectedTab.Equals(TabFascicolo) Then
            FascicoloAggiorna()
        ElseIf TabProdotti.SelectedTab.Equals(TabCliente) Then
            TabProdotti.SelectedTab.Controls.Remove(TableLayoutPanel9)
            TabProdotti.SelectedTab.Controls.Add(lblCaricamento)
            My.Application.DoEvents()


            If Trim(txtClienteCodiceFiscale.Text) = vbNullString Then
                optCliente.Enabled = False
                optGenerico.Checked = True
            Else
                optCliente.Enabled = True
                optCliente.Checked = True
            End If

            LeggiPreventivi(txtClienteCodiceFiscale.Text)

            My.Application.DoEvents()
            TabProdotti.SelectedTab.Controls.Remove(lblCaricamento)
            TabProdotti.SelectedTab.Controls.Add(TableLayoutPanel9)
            My.Application.DoEvents()
        ElseIf TabProdotti.SelectedTab.HasChildren = False Then
            PreventivoNuovo()
        End If

    End Sub

    Private Sub LeggiPreventivi(ByRef ClienteCodiceFiscale As String)
        Dim P00000DE As New P00000DE
        If Not System.IO.Directory.Exists(DataManager.CartellaPreventivo(ClienteCodiceFiscale)) Then
            grdPreventivi.Rows.Clear()
            Exit Sub
        End If

        Dim preventivi As String() = System.IO.Directory.GetFiles(DataManager.CartellaPreventivo(ClienteCodiceFiscale), "*.up")
        With grdPreventivi
            .SuspendLayout()
            .Rows.Clear()
            Application.DoEvents()
            For Each preventivo As String In preventivi
                Try
                    Dim preventivoIsOk As Boolean = True
                    Dim row As Object() = {Nothing _
                                           , "" _
                                           , IO.File.GetCreationTime(preventivo) _
                                           , "" _
                                           , "" _
                                           , "Apri" _
                                           , "Elimina"}

                    'IO.File.GetLastWriteTime(preventivo) _

                    Try
                        Dim preventivoSalvato As Prodotto = DataManager.CheckPreventivo(preventivo)
                        row(3) = preventivoSalvato.EmailTo
                    Catch ex As Exception
                        preventivoIsOk = False
                    End Try


                    Dim s() = preventivo.Split("_")
                    If s.Length > 1 Then
                        row(4) = s(0).Substring(s(0).LastIndexOf("\") + 1)

                        If IsNumeric(s(1)) Then
                            Dim codiceProdotto As Integer = CInt(s(1))
                            If Globale.licenza.ProdottoIsAttivo(codiceProdotto) Or codiceProdotto = TipoProdotto.Fascicolo Then

                                If preventivoIsOk = False Then
                                    row(0) = My.Resources.Remove
                                    row(4) &= " (Preventivo non più utilizzabile. Da eliminare.)"
                                    row(5) = ""
                                Else
                                    row(0) = GetIcon(codiceProdotto)
                                End If
                                row(1) = P00000DE.DecodeProdotto(codiceProdotto)
                                .Rows.Add(row)
                                .Rows(.Rows.Count - 1).Tag = preventivo
                                If preventivoIsOk = False Then
                                    .Rows(.Rows.Count - 1).DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlLight
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
            .ResumeLayout()
            Application.DoEvents()
        End With
    End Sub

    Private Sub LeggiCruscotto(ByRef ClienteCodiceFiscale As String)
        With grdPreventivi
            .SuspendLayout()
            .Rows.Clear()
            Application.DoEvents()

            If Essig.WebEngine.IsLogged() Then

                Dim array As String(,) = Essig.Cruscotto.GetAsList("1", Globale.licenza.CodiceAgenzia, ClienteCodiceFiscale)

                If array IsNot Nothing Then
                    For i As Integer = 0 To array.GetLength(0) - 1
                        Dim row As Object() = {Nothing _
                                               , "" _
                                               , "" _
                                               , "" _
                                               , "" _
                                               , "Apri" _
                                               , "Elimina"}

                        Dim codiceProdotto As Integer = CInt(array(i, 8))
                        row(0) = GetIcon(codiceProdotto)
                        row(1) = P00000DE.DecodeProdotto(codiceProdotto)

                        If row(1) Is Nothing Then row(1) = codiceProdotto

                        row(2) = array(i, 15)
                        row(4) = String.Format("Preventivo n. {0}/{1} ({2})", array(i, 0), array(i, 1), IIf(array(i, 6) = "B", "Bozza", "Preventivo"))

                        .Rows.Add(row)
                        .Rows(.Rows.Count - 1).Tag = String.Format("{0};{1}", array(i, 24), array(i, 25))
                    Next

                End If
            End If
            .ResumeLayout()
            Application.DoEvents()
        End With
    End Sub

    Private Function GetIcon(ByVal codiceProdotto As Integer) As System.Drawing.Icon
        Select Case codiceProdotto
            Case TipoProdotto.YouCondominio
                Return New System.Drawing.Icon(My.Resources.P0726032, 16, 16)
            Case TipoProdotto.YouCommercio
                Return New System.Drawing.Icon(My.Resources.P0422632, 16, 16)
            Case TipoProdotto.YouCasa
                Return My.Resources.P0726132
            Case TipoProdotto.UnipolSaiCasaServizi
                Return My.Resources.P0726132
            Case TipoProdotto.YouInfortuni
                Return New System.Drawing.Icon(My.Resources.P0120132, 16, 16)
            Case TipoProdotto.Circolazione
                Return New System.Drawing.Icon(My.Resources.P0120332, 16, 16)
            Case TipoProdotto.InfortuniPremium
                Return New System.Drawing.Icon(My.Resources.P0120132, 16, 16)
            Case TipoProdotto.Invalidita
                Return New System.Drawing.Icon(My.Resources.P0126132, 16, 16)
            Case TipoProdotto.SpeseMediche
                Return New System.Drawing.Icon(My.Resources.P0126232, 16, 16)
            Case TipoProdotto.Ricovero
                Return New System.Drawing.Icon(My.Resources.P0126332, 16, 16)
            Case TipoProdotto.YouIngegnereArchitetto
                Return New System.Drawing.Icon(My.Resources.P0222932, 16, 16)
            Case TipoProdotto.Smart, 1202
                Return New System.Drawing.Icon(My.Resources.PSMART32, 16, 16)
            Case TipoProdotto.Fascicolo
                Return System.Drawing.Icon.FromHandle(CType(ImageList1.Images(TabFascicolo.ImageIndex).GetThumbnailImage(16, 16, Nothing, IntPtr.Zero), Bitmap).GetHicon())
        End Select

    End Function

    Private Sub grdPreventivi_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPreventivi.CellContentClick
        If optEssig.Checked = True Then
            Dim a As String() = grdPreventivi.Rows(e.RowIndex).Tag.ToString.Split(";")

            Try
                Dim posizione As Integer = Integer.Parse(a(0))
                Dim progressivo As Integer = Integer.Parse(a(1))

                If e.ColumnIndex = 5 Then
                    Essig.Cruscotto.Ripartenza(posizione, progressivo)
                ElseIf e.ColumnIndex = 6 Then
                    If MsgBox("Vuoi eliminare il preventivo selezionato?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Application.DoEvents()
                        If Essig.Cruscotto.Annulla(posizione, progressivo) Then
                            grdPreventivi.Rows.RemoveAt(e.RowIndex)
                        Else
                            MsgBox("Emiminazione non riuscita", MsgBoxStyle.Exclamation)
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
        Else
            If e.ColumnIndex = 5 Then
                grdPreventiviApri(e.RowIndex)
            ElseIf e.ColumnIndex = 6 Then
                If MsgBox("Vuoi eliminare il preventivo selezionato?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If DataManager.DeletePreventivo(grdPreventivi.Rows(e.RowIndex).Tag) Then
                        grdPreventivi.Rows.RemoveAt(e.RowIndex)
                    Else
                        MsgBox("Emiminazione non riuscita", MsgBoxStyle.Exclamation)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub optCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCliente.CheckedChanged, optGenerico.CheckedChanged, optEssig.CheckedChanged
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        If sender.Equals(optCliente) And optCliente.Checked = True Then
            LeggiPreventivi(txtClienteCodiceFiscale.Text)
        ElseIf sender.Equals(optGenerico) And optGenerico.Checked = True Then
            LeggiPreventivi(vbNullString)
        ElseIf sender.Equals(optEssig) And optEssig.Checked = True Then
            LeggiCruscotto(txtClienteCodiceFiscale.Text)
        End If
        Cursor = Cursors.Default
        Application.DoEvents()
    End Sub

    Private Sub txtClienteCodiceFiscale_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClienteCodiceFiscale.TextChanged
        If Trim(txtClienteCodiceFiscale.Text) = vbNullString Then
            optCliente.Enabled = False
            optGenerico.Checked = True
        Else
            optCliente.Enabled = True
            'optCliente.Checked = True
        End If
    End Sub

    Private Sub grdPreventivi_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPreventivi.CellDoubleClick
        grdPreventiviApri(e.RowIndex)
    End Sub

    Private Function ValidaEmail(ByVal indirizzo As String) As Boolean

        Dim espressioneRegolare As String
        espressioneRegolare = "^([\w-\.]+)@" & _
                              "((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|" & _
                              "(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
        Return System.Text.RegularExpressions.Regex.IsMatch(indirizzo, espressioneRegolare)

    End Function

    Private Sub cmdAttiva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAttiva.Click
        If cmbDominio.SelectedItem Is Nothing Then
            MsgBox("selezionare la compagnia")
            Return
        End If

        If IsNullOrWhiteSpace(txtAttAgenzia.Text) _
        OrElse IsNumeric(txtAttAgenzia.Text) = False Then
            MsgBox("digitare il codice agenzia in formato numerico di 5 cifre")
            Return
        End If

        txtAttAgenzia.Text = CInt(txtAttAgenzia.Text).ToString("00000")

        If cmdAttiva.Text = "Attiva" Then
            If Globale.licenza.Verifica(cmbDominio.SelectedValue, txtAttAgenzia.Text) = True Then
                QuotatoreLoad()
                MsgBox("Attivazione completata", vbInformation)
            End If
        Else
            If MsgBox("Sei sicuro di disattivare il quotatore? Dopo la disattivazione, il programma si bloccherà sino a successiva attivazione", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Globale.licenza.Disattiva()
                QuotatoreLoad()
            End If
        End If
    End Sub

    Public Function GetNewInstance(ByVal t As System.Type) As P00000FE
        Return t.GetConstructor(System.Type.EmptyTypes).Invoke(Nothing)
    End Function


    '***********GESTIONE FASCICOLO**************
    Private Sub FascicoloCarica()
        With grdFascicolo
            .SuspendLayout()
            .Rows.Clear()

            For Each tab As TabPage In TabProdotti.TabPages
                If tab.Name.Substring(3, 1) = "P" Then
                    .Rows.Add({False, ImageList1.Images(tab.ImageIndex), tab.Text, "", "Nuovo"})
                    .Rows(.Rows.Count - 1).Tag = tab
                End If
            Next

            .Rows.Add({False, ImageList1.Images(TabFascicolo.ImageIndex), "TOTALE", "", ""})
            .Rows(.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightYellow
            .ResumeLayout()
        End With
    End Sub

    Private Sub FascicoloAggiorna()
        Dim totale As Decimal
        For i As Integer = 0 To grdFascicolo.RowCount - 2
            Dim tab As TabPage = CType(grdFascicolo.Rows(i).Tag, TabPage)
            If tab.Controls.Count = 0 Then
                With CType(grdFascicolo.Rows(i).Cells(0), DataGridViewCheckBoxCell)
                    .Value = False
                    grdFascicolo.Rows(i).Cells(3).Value = Nothing
                    grdFascicolo.Rows(i).Cells(4).Value = "Nuovo"
                End With
            Else
                Dim premio As Decimal = CType(tab.Controls(0), P00000FE).preventivo.PremioLabel

                With CType(grdFascicolo.Rows(i).Cells(0), DataGridViewCheckBoxCell)
                    If grdFascicolo.Rows(i).Cells(3).Value = Nothing Then
                        .Value = True
                    End If
                    If .Value = True Then
                        totale += premio
                    End If
                End With
                grdFascicolo.Rows(i).Cells(3).Value = FormatEuro(premio)
                grdFascicolo.Rows(i).Cells(4).Value = "Apri"
            End If
        Next
        With grdFascicolo.Rows(grdFascicolo.Rows.Count - 1)
            .Cells(3).Value = FormatEuro(totale)
        End With
    End Sub

    Private Sub FascicoloCellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdFascicolo.CellDoubleClick
        If grdFascicolo.Rows(e.RowIndex).Tag IsNot Nothing Then
            TabProdotti.SelectedTab = grdFascicolo.Rows(e.RowIndex).Tag
        End If
    End Sub

    Private Sub FascicoloCellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles grdFascicolo.CellPainting
        If e.ColumnIndex = 0 Then
            If e.RowIndex = grdFascicolo.Rows.Count - 1 Then
                Using Brush As Brush = New SolidBrush(e.CellStyle.BackColor)
                    e.Graphics.FillRectangle(Brush, e.CellBounds)
                    e.Paint(e.ClipBounds, DataGridViewPaintParts.Border)
                    e.Handled = True
                End Using
            End If
        End If
    End Sub

    Private Sub FascicoloCellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFascicolo.CellContentClick
        If e.ColumnIndex = 0 Then
            With CType(grdFascicolo.Rows(e.RowIndex).Cells(0), DataGridViewCheckBoxCell)
                .Value = Not .Value
                FascicoloAggiorna()
            End With
        ElseIf e.ColumnIndex = 4 Then
            TabProdotti.SelectedTab = grdFascicolo.Rows(e.RowIndex).Tag
        End If
    End Sub

    Private Function FascicoloGet() As Fascicolo
        Dim fascicolo As New Fascicolo

        For i As Integer = 0 To grdFascicolo.RowCount - 2
            Dim tab As TabPage = CType(grdFascicolo.Rows(i).Tag, TabPage)
            If tab.Controls.Count > 0 Then
                With CType(grdFascicolo.Rows(i).Cells(0), DataGridViewCheckBoxCell)
                    If .Value = True Then
                        fascicolo.Add(CType(tab.Controls(0), P00000FE).preventivo)
                    End If
                End With
            End If
        Next

        fascicolo.Calcola()

        Return fascicolo
    End Function

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ButtonSalvaInEssig.Click
        If TypeOf TabProdotti.SelectedTab.Controls(0) Is P00000FE Then
            With CType(TabProdotti.SelectedTab.Controls(0), P00000FE)
                If .preventivo.HasEssig = False Then
                    MsgBox("Salvataggio in Essig non implementato per il prodotto selezionato", vbInformation)
                ElseIf .preventivo.ListinoLordo = 0.0# Then
                    MsgBox("Nessun preventivo da salvare.", MsgBoxStyle.Information)
                Else
                    Dim w As New EssigForm
                    w.preventivo = .preventivo
                    w.ShowDialog(Me)
                End If

            End With
        Else
            MsgBox("Nessun prodotto selezionato", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub CaricaSubangenzieEtIntermediari()
#If Debug Then 'HIDE_ESSIG

        Try

            If essigCmbSubagenzia.DataSource Is Nothing Then
                essigCmbSubagenzia.DataSource = Essig.Elenco.Subagenzie(Globale.licenza.CodiceCompagniaEssig, Globale.licenza.CodiceAgenzia)
            End If
            If essigCmbIntermediario.DataSource Is Nothing Then
                essigCmbIntermediario.DataSource = Essig.Elenco.Intermediari(Globale.licenza.CodiceCompagniaEssig, Globale.licenza.CodiceAgenzia)
            End If
        Catch ex As Exception
        End Try
#End If
    End Sub
End Class


