Imports Microsoft.Web.Services3.Security.Tokens
Imports System.Windows.Forms
Imports System.Drawing
Imports UnitoolsDocumenti.LiquidoSinistro

Public Class FormImportaSinistri

    Public Event RichiestaCambioAgenzia(Codice As String)

    Private dt As DataTable

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        'Me.AutoScaleMode = AutoScaleMode.Dpi
        'Me.AutoSize = True
        'Me.AutoScaleDimensions = New SizeF(200, 200)
        'Me.AutoScaleMode = AutoScaleMode.Font
        'Me.AutoScaleDimensions = New SizeF(6.0F, 13.0F)

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Size = New Size(600, 450)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.MaximizeBox = False
        Me.Text = String.Format("Sinistri aperti da {0} - {1}", Utx.Globale.UtenteCorrente.UniageUser.ToUpper, Utx.Globale.UtenteCorrente.NomeUtente)
        Me.Font = Utx.AppFont.Normal

        ImpostaControlli()

        'Utx.Globale.ScalaControlli(Me)
        'Utx.Globale.ScalaFont(Me.ListBoxSinistri)
    End Sub

    Private Sub ImpostaControlli()
        With dtpDal
            .Dock = DockStyle.Fill
            .Value = Today
            .MaxDate = Today
        End With
        With dtpAl
            .Dock = DockStyle.Fill
            .Value = Today
            .MaxDate = Today
        End With
        With ListBoxSinistri
            .Margin = New Padding(1)
            .Dock = Windows.Forms.DockStyle.Fill
            .IntegralHeight = False
            .Font = Utx.AppFont.Extra(12, Drawing.FontStyle.Regular)
        End With
        With LabelStato
            .Margin = New Padding(1)
            .BackColor = Color.PaleGreen
            .Text = "Lettura sinistri..."
            .TextAlign = Drawing.ContentAlignment.MiddleLeft
        End With
        With LabelSinistro
            .Margin = New Padding(1)
            .BackColor = Color.Gainsboro
            .Text = ""
            .TextAlign = Drawing.ContentAlignment.MiddleCenter
        End With
        With ButtonAggiorna
            .Margin = New Padding(1, 2, 1, 2)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Importa i sinistri per utente e data apertura"
        End With
        With ButtonSeleziona
            .Margin = New Padding(1)
            .Padding = Utx.AppFont.ButtonPadding
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Image = Risorse.Immagini.Bitmap("ok32")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Vai al sinistro selezionato"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonEsci
            .Margin = New Padding(1)
            .Padding = Utx.AppFont.ButtonPadding
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Vai al sinistro selezionato"
            .TextAlign = ContentAlignment.MiddleRight
            .Text = "Esci"
        End With
        With ButtonCatturaEvento
            .Margin = New Padding(1)
            .Padding = Utx.AppFont.ButtonPadding
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Cattura il sinistro da EVENTO (utilizza vecchio metodo)"
        End With
        TextBoxUtente.Text = Utx.Globale.UtenteCorrente.UniageUser
        TextBoxPw.Text = Utx.Globale.UtenteCorrente.UniagePw
    End Sub

    Private mSinistroselezionato As String
    Public ReadOnly Property SinistroSelezionato() As String
        Get
            Return mSinistroselezionato
        End Get
    End Property

    Private Sub ImportaSinistri()
        Try
            Globale.Log.Info("Importazione sinistri - versione proxy server AUA")

            ButtonAggiorna.Enabled = False
            ButtonSeleziona.Enabled = False
            ButtonEsci.Enabled = False
            ListBoxSinistri.Items.Clear()
            ListBoxSinistri.Refresh()

            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            LabelStato.Text = "Sinistri: 0 - In archivio: 0 - Importati: 0"

            Dim Aggiunti As Integer = 0
            Dim InArchivio As Integer = 0

            Using setting As New Utx.SettingAgenzia.ConfiguraSede
                LabelSinistro.Text = "Lettura sinistri..."

                'chiamo il servizio per avere la lista dei sinistri aperti dall'utente nel periodo
                Dim Risposta As Utx.ImportaSinistriOMW.EsitoChiamata
                Using s As New Utx.ImportaSinistriOMW.Direzione
                    s.Proxy = Utx.Globale.UniProxy.Proxy
                    Risposta = s.ListaSinistri_2024(TextBoxUtente.Text,
                                                    TextBoxPw.Text,
                                                    dtpDal.Value,
                                                    dtpAl.Value,
                                                    Utx.Globale.Token)
                End Using

                If Risposta.Esito = False Then
                    If Risposta.Errore.ToLower.Contains("timeout") Then
                        MsgBox("I server di Liquido non hanno risposto. Riprovare...", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    Else
                        Globale.Log.Errore(Risposta.Errore)
                    End If
                    Exit Try
                End If

                Dim Totali As Integer = Risposta.ListaInfoSinistri.Length

                If Totali > 0 Then
                    LabelSinistro.Text = ""

                    LabelStato.Text = String.Format("Sinistri: {0} - In archivio: {1} - Importati: {2}", Totali, InArchivio, Aggiunti)

                    For Each Agenzia As String In Utx.EnteGestore.CodiciGestiti
                        Globale.Log.Info("importo agenzia {0}", {Agenzia})

                        Dim CodiciIncorporati As String = setting.CodiciIncorporati(1, Agenzia, Utx.Globale.ProfiloEnteGestore.CodiceSede)

                        For Each Incorporata As String In CodiciIncorporati.Split("/")
                            Globale.Log.Info("codice incorporato: {0}", {Incorporata})

                            'analisi dei singoli sinistri trovati
                            For Each Sinistro In Risposta.ListaInfoSinistri
                                Globale.Log.Info("agenzia {0} - sinistro {1}", {Sinistro.CodiceAgenzia, Sinistro.NumeroSinistro})
                                'se il sinistro corrisponde al codice analizzato
                                If Val(Incorporata) = Val(Sinistro.CodiceAgenzia) Then
                                    Dim sin() As String = Sinistro.NumeroSinistro.Split("-")
                                    'controllo se il sinistro non esiste
                                    If EsisteSinistro(sin(0), sin(1), sin(2), sin(3),
                                                      QuerySinistri.TipoTabella.SINISTRI_DELEGA_PROPRIA) = False Then
                                        'non esiste e lo aggiungo
                                        If AddSinistro(Sinistro, dt) = True Then
                                            Aggiunti += 1
                                            'aggiorno stato
                                            LabelStato.Text = String.Format("Sinistri: {0} - In archivio: {1} - Importati: {2}",
                                                                                Totali, InArchivio, Aggiunti)
                                            'visualizzo sinistro
                                            ListBoxSinistri.Items.Add(String.Format("{0:dd/MM}: {1} ({2}) > {3} {4} - Importato",
                                                                                        Sinistro.DataAperturaSinistro,
                                                                                        Agenzia,
                                                                                        Incorporata,
                                                                                        Sinistro.NumeroSinistro,
                                                                                        Sinistro.NomeContraente))
                                        Else
                                            ListBoxSinistri.Items.Add(String.Format("{0:dd/MM}: {1} ({2}) > {3} {4} - ERRORE",
                                                                                        Sinistro.DataAperturaSinistro,
                                                                                        Agenzia,
                                                                                        Incorporata,
                                                                                        Sinistro.NumeroSinistro,
                                                                                        Sinistro.NomeContraente))
                                        End If
                                        ListBoxSinistri.Refresh()
                                    Else
                                        AddUtenteSinistro(Sinistro)

                                        InArchivio += 1
                                        LabelStato.Text = String.Format("Sinistri: {0} - In archivio: {1} - Importati: {2}",
                                                                                Totali, InArchivio, Aggiunti)

                                        ListBoxSinistri.Items.Add(String.Format("{0:dd/MM}: {1} ({2}) > {3} {4}",
                                                                                    Sinistro.DataAperturaSinistro,
                                                                                    Agenzia,
                                                                                    Incorporata,
                                                                                    Sinistro.NumeroSinistro,
                                                                                    Sinistro.NomeContraente))
                                        ListBoxSinistri.Refresh()
                                        Globale.Log.Info("Sinistro già in archivio")
                                    End If
                                Else
                                    Globale.Log.Trace("*** codice relativo ad altra agenzia")
                                End If
                            Next
                        Next
                    Next
                End If

                'aggiorno il db
                If dt.Rows.Count > 0 Then
                    Dim ds As New DataSet
                    ds.Tables.Add(dt)
                    dt.TableName = Utx.ServiziOMW.TipoEvento.IMPORTA_SINISTRI_WS.ToString
                    Utx.OmWeb.InviaDataSet(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, ds, AttendiFine:=True)
                    dt.Clear()
                End If

                LabelSinistro.Text = "Fatto!"
            End Using

            If ListBoxSinistri.Items.Count > 0 Then
                ListBoxSinistri.SelectedIndex = 0
                ButtonSeleziona.Enabled = True
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
            ButtonAggiorna.Enabled = True
            ButtonEsci.Enabled = True
        End Try
    End Sub

    Private Function AddSinistro(Dettaglio As Utx.ImportaSinistriOMW.DettaglioSinistro, ByRef dt As DataTable) As Boolean
        Try
            Globale.Log.Info("* AGGIUNGO il sinistro")
            'lo aggiungo
            Dim Sin() As String = Dettaglio.NumeroSinistro.Split("-")
            Dim DataLocale As Date
            With Dettaglio
                Dim dr As DataRow = dt.NewRow
                dr("AnnoMeseCompetenza") = Today
                dr("Compagnia") = Sin(0)
                dr("AgenziaSinistro") = Sin(1)
                dr("EsercizioSinistro") = Sin(2)
                dr("NumeroSinistro") = Sin(3)
                dr("Ispettorato") = .CodiceClg
                dr("AgenziaPolizza") = .CodiceAgenzia
                dr("TargaAssicurato") = Microsoft.VisualBasic.Left(.TargaAssicurato, 9)
                dr("RamoPolizza") = .RamoPolizza
                dr("Polizza") = .NumeroPolizza
                dr("CodiceSubAgenteSima") = .CodiceSubAgenzia
                dr("CodiceProdotto") = .Prodotto.Split("-")(0).Trim
                dr("Convenzione") = Utx.FunzioniDb.NullToString(.Convenzione)

                DataLocale = .DataDenuncia
                dr("DataDenuncia") = Format(DataLocale.ToLocalTime, "dd/MM/yyyy")

                DataLocale = .DataAccadimento
                dr("DataSinistro") = Format(DataLocale.ToLocalTime, "dd/MM/yyyy")

                DataLocale = .DataAperturaSinistro
                dr("DataApertura") = Format(DataLocale.ToLocalTime, "dd/MM/yyyy")
                dr("DataProtocollo") = Utx.FunzioniData.FineMese(dr("DataApertura"))

                'assicurato
                dr("CODICEFISCCONTRPOL") = .CodiceFiscaleContraente.Trim
                Dim Assicurato As String = ""
                If (IsNumeric(.CodiceFiscaleContraente) = False) AndAlso (.NomeContraente.Split(" ").Length = 2) Then
                    'persona fisica con nome di soli 2 token
                    Assicurato = .NomeContraente.Split(" ")(1).Trim & " " & .NomeContraente.Split(" ")(0)
                Else
                    Assicurato = .NomeContraente
                End If
                dr("CognomeAssicurato") = Microsoft.VisualBasic.Left(Assicurato, 20)
                dr("NomeAssicurato") = Microsoft.VisualBasic.Mid(Assicurato, 20, 10)
                'controparte
                dr("CognomeDanneggiato") = Microsoft.VisualBasic.Left(Utx.FunzioniDb.NullToString(.NomeControparte), 20)
                dr("TargaDanneggiato") = Microsoft.VisualBasic.Left(Utx.FunzioniDb.NullToString(.TargaControparte), 9)
                dr("TipoChiusura") = ".."
                dr("StatoTecnico") = ".."
                dr("StatoBilancistico") = ".."
                dr("Riserva") = Val(.RiservaTecnica)
                dr("Lira") = "N"
                If IsDate(.DataInterventoLegale) Then dr("LegaleData") = Format(.DataInterventoLegale, "dd/MM/yyyy")
                dr("FlagLegale") = Utx.FunzioniDb.NullToString(.FlagLegale) '1/2/3
                dr("NostraQuota") = Val(.NostraQuota)
                dr("NrPosizioni") = .NumeroPosizioni
                If String.IsNullOrEmpty(.CodicePerito) = False Then
                    dr("CodicePerito") = Utx.FunzioniDb.NullToString(.CodicePerito.Split(";")(0))
                End If
                '+non gestito il flag cose/persone e profilo sinistro
                dr("RamoSinistro") = .RamoSinistro
                dr("CodiceLiquidatore") = Utx.FunzioniDb.NullToString(.LiquidatoreAssegnatario)
                dr("IdGestione") = Utx.Globale.UtenteCorrente.UniageUser.Substring(6).ToUpper

                If IsNumeric(dr("RamoPolizza")) Then
                    dr("RamoGestione") = Utx.FunzioniDb.RamoPolizza2RamoGestione(dr("RamoPolizza"))
                End If

                dt.Rows.Add(dr)
                Return True
            End With
        Catch ex As Exception
            Globale.Log.Info(ex)
            Return False
        End Try
    End Function

    Private Function AddUtenteSinistro(Dettaglio As Utx.ImportaSinistriOMW.DettaglioSinistro) As Boolean
        Try
            Globale.Log.Info("* AGGIUNGO l'utente sinistro")
            Dim Sin() As String = Dettaglio.NumeroSinistro.Split("-")

            Dim Query As String = String.Format("UPDATE SinistriDP 
                SET IdGestione = '{0}' 
                WHERE Compagnia = {1} AND AgenziaSinistro = {2} AND EsercizioSinistro = {3} AND NumeroSinistro = {4} AND 
                LEN(TRIM(IdGestione)) = 0", Utx.Globale.UtenteCorrente.UniageUser.Substring(6).ToUpper, Sin(0), Sin(1), Sin(2), Sin(3))
            Return Utx.WsCommand.ExecuteNonQueryRecord(Query) = 1
        Catch ex As Exception
            Globale.Log.Info(ex)
            Return False
        End Try
    End Function

    Private Sub FormImportaSinistri_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Refresh()
        dt = Utx.WsCommand.ExecuteNonQuery("SELECT * FROM SinistriDP WHERE 1=0").DataTable
        ButtonAggiorna.PerformClick()
    End Sub

    Private Sub ListBoxSinistri_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles ListBoxSinistri.MouseDoubleClick
        'seleziona sinistro
        ButtonSeleziona.PerformClick()
    End Sub

    Private Sub LabelStato_TextChanged(sender As Object, e As EventArgs) Handles LabelStato.TextChanged
        LabelStato.Refresh()
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ButtonSeleziona_Click(sender As Object, e As EventArgs) Handles ButtonSeleziona.Click
        If ListBoxSinistri.SelectedIndex >= 0 Then
            Dim Codice As String = ListBoxSinistri.SelectedItem.ToString.Split(":")(1).Trim.Split(" ")(0)
            Dim Sinistro As String = ListBoxSinistri.SelectedItem.ToString.Split(":")(1).Trim.Split(" ")(3).Trim

            If Utx.Globale.AgenziaRichiesta.CodiceAgenzia = Codice Then
                mSinistroselezionato = Sinistro
            Else
                mSinistroselezionato = Sinistro
                RaiseEvent RichiestaCambioAgenzia(Codice)
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("Selezionare prima un sinistro", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        End If
    End Sub

    Private Sub ButtonAggiorna_Click(sender As Object, e As EventArgs) Handles ButtonAggiorna.Click
        'controlli date
        If dtpAl.Value < dtpDal.Value Then
            MsgBox("Intervallo date errato.", MsgBoxStyle.Critical, Utx.Globale.TitoloApp)
            Exit Sub
        End If
        If DateDiff(DateInterval.Day, dtpDal.Value, dtpAl.Value) > 7 Then
            MsgBox("l'intervallo non può superare i sette giorni.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            Exit Sub
        End If

        ButtonAggiorna.Enabled = False
        ButtonSeleziona.Enabled = False
        ButtonEsci.Enabled = False
        ListBoxSinistri.Items.Clear()
        ListBoxSinistri.Refresh()

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        ImportaSinistri()

        If ListBoxSinistri.Items.Count > 0 Then
            ListBoxSinistri.SelectedIndex = 0
            ButtonSeleziona.Enabled = True
        End If

        Me.Cursor = Windows.Forms.Cursors.Default
        ButtonAggiorna.Enabled = True
        ButtonEsci.Enabled = True
    End Sub

    Private Sub ButtonCatturaEvento_Click(sender As Object, e As EventArgs) Handles ButtonCatturaEvento.Click
        DialogResult = Windows.Forms.DialogResult.Retry
    End Sub

    Private Sub LabelSinistro_TextChanged(sender As Object, e As EventArgs) Handles LabelSinistro.TextChanged
        LabelSinistro.Refresh()
    End Sub

    Public Class InfoSinistriRisposta
        Public Property Esito As Boolean = True
        Public Property Errore As String = ""
        Public InfoSinistri As New List(Of test.DettaglioSinistro)
    End Class
End Class
