Imports System.IO

Public Class FormBDAMain

    Private Const LinkDoc As String = "http://www.utools.it/Unitools/Doc/BDA/IndexDoc.htm"

    Private Const EstrazioneStornate As String = "Polizze stornate ramo 30 - netto targhe"
    Private Const EstrazioneArretrati As String = "Titoli Arretrati auto"

    Private Importa As ExportLib.Export
    Private WithEvents Notifica As Utx.FormNotifica
    Private FormFiltro As New Utx.FormGestioneFiltro(1000)
    Private WithEvents ButtonBDA As New Button
    Private WithEvents ButtonAggiorna As New Button
    Private WithEvents ButtonStornate As New Button
    Private WithEvents ButtonArretrati As New Button
    Private WithEvents ButtonUtente As New Button
    Private WithEvents ButtonTutto As New Button
    Private WithEvents ButtonExcel As New Button
    Private WithEvents ButtonCsv As New Button
    Private WithEvents ButtonEsci As New Button
    Private WithEvents CheckBoxFiltri As New CheckBox
    Private LabelConteggio As New Label

    Private WithEvents dv As New DataView

    Private Enum TipoQuery
        TUTTO = 0
        CLIENTIARCHIVIO = 1
    End Enum

    Private Enum ProvenienzaTarga
        TUTTO = 0
        STORNATE = 1
        ARRETRATI = 2
        UTENTE = 3
    End Enum

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
#If DEBUG Then
        'Globale.ImpostaVariabiliDebug()
#End If

        Me.Text = "Gestione interrogazioni BDA"
        Me.Icon = My.Resources.ania
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.Pink

        ImpostaToolStrip()
        ImpostaGriglie()

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Refresh()
    End Sub

    Private Sub ImpostaToolStrip()

        On Error Resume Next

        With ToolStripMain
            .Font = New Font("Verdana", 9)
            .GripStyle = ToolStripGripStyle.Hidden
            .RenderMode = ToolStripRenderMode.ManagerRenderMode
            .BackColor = Color.Transparent
            .Items.Clear()
        End With

        Dim tt As New ToolTip
        Dim ttch As ToolStripControlHost

        With ButtonBDA
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Estrai targhe"
            .BackColor = Color.GreenYellow
        End With
        tt.SetToolTip(ButtonBDA, "Estrai targhe per interrogare la banca dati ANIA")
        ttch = New ToolStripControlHost(ButtonBDA)
        ToolStripMain.Items.Add(ttch)

        With ButtonAggiorna
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Aggiorna dati"
            .BackColor = Color.Moccasin
        End With
        tt.SetToolTip(ButtonAggiorna, "Aggiorna stornate con copertura scaduta")
        ttch = New ToolStripControlHost(ButtonAggiorna)
        ToolStripMain.Items.Add(ttch)

        ToolStripMain.Items.Add(New ToolStripSeparator)
        With ButtonStornate
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Stornate"
            .BackColor = Color.Orange
        End With
        tt.SetToolTip(ButtonStornate, "Visualizza esito BDA da polizze stornate")
        ttch = New ToolStripControlHost(ButtonStornate)
        ToolStripMain.Items.Add(ttch)

        With ButtonArretrati
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Arretrati"
            .BackColor = Color.Orange
        End With
        tt.SetToolTip(ButtonArretrati, "Visualizza esito BDA da arretrati")
        ttch = New ToolStripControlHost(ButtonArretrati)
        ToolStripMain.Items.Add(ttch)

        With ButtonUtente
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Utente"
            .BackColor = Color.Orange
        End With
        tt.SetToolTip(ButtonUtente, "Visualizza esito BDA da file utente")
        ttch = New ToolStripControlHost(ButtonUtente)
        ToolStripMain.Items.Add(ttch)

        With ButtonTutto
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Tutto"
            .BackColor = Color.Orange
        End With
        tt.SetToolTip(ButtonTutto, "Visualizza tutto l'archivio BDA")
        ttch = New ToolStripControlHost(ButtonTutto)
        ToolStripMain.Items.Add(ttch)

        ToolStripMain.Items.Add(New ToolStripSeparator)
        With ButtonExcel
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Esporta in excel"
            .BackColor = Color.Moccasin
        End With
        ttch = New ToolStripControlHost(ButtonExcel)
        ToolStripMain.Items.Add(ttch)
        With ButtonCsv
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Esporta in csv"
            .BackColor = Color.Moccasin
        End With
        ttch = New ToolStripControlHost(ButtonCsv)
        ToolStripMain.Items.Add(ttch)

        ToolStripMain.Items.Add(New ToolStripSeparator)
        With CheckBoxFiltri
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Appearance = Appearance.Button
            .BackColor = Drawing.SystemColors.Control
            .Text = "Nessun filtro"
            .TextAlign = ContentAlignment.MiddleCenter
            .Checked = False
            .AutoSize = True
        End With
        ttch = New ToolStripControlHost(CheckBoxFiltri)
        ttch.AutoSize = False
        ttch.Enabled = False
        ToolStripMain.Items.Add(ttch)

        With ButtonEsci
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Esci"
            .BackColor = Color.Gold
            .Font = Utx.AppFont.Bold
        End With
        ttch = New ToolStripControlHost(ButtonEsci)
        ttch.Alignment = ToolStripItemAlignment.Right
        ToolStripMain.Items.Add(ttch)

        Dim Sep As New Label
        With Sep
            .Margin = New Padding(0)
            .Padding = New Padding(0)
            .Text = Space(1)
        End With
        ttch = New ToolStripControlHost(Sep)
        ttch.Alignment = ToolStripItemAlignment.Right
        ToolStripMain.Items.Add(ttch)

        With LabelConteggio
            .FlatStyle = FlatStyle.Flat
            .Width = 60
            .BorderStyle = BorderStyle.FixedSingle
            .Text = "0"
            .TextAlign = ContentAlignment.MiddleCenter
            .BackColor = Drawing.SystemColors.Window
        End With
        ttch = New ToolStripControlHost(LabelConteggio)
        ttch.Alignment = ToolStripItemAlignment.Right
        ttch.AutoSize = False
        ToolStripMain.Items.Add(ttch)

    End Sub

    Private Sub ImpostaGriglie()
        On Error Resume Next

        With dgvBDA
            .SuspendLayout()
            '.ReadOnly = True
            .EditMode = DataGridViewEditMode.EditOnEnter
            .Font = Utx.AppFont.Normal
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Padding = New Padding(0, 1, 0, 1)
            .DefaultCellStyle.Padding = New Padding(0, 1, 0, 1)
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .ResumeLayout()
        End With

        For Each c As DataGridViewColumn In dgvBDA.Columns
            c.SortMode = DataGridViewColumnSortMode.Programmatic
        Next

        Utx.NetFunc.DoppioBuffer(dgvBDA)
    End Sub

    Private Sub ButtonBDA_Click(sender As Object, e As EventArgs) Handles ButtonBDA.Click
        InterrogaBDA()
    End Sub

    Private Sub InterrogaBDA()

        Dim OpzioniDBA As New ExportLib.BancaDatiAnia.Opzioni

        'seleziona origine
        Try
            Using f As New FormBDAOpzioni

                f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
                f.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
                f.Icon = My.Resources.opzioni
                f.ShowInTaskbar = True
                f.MaximizeBox = False
                f.MinimizeBox = False
                f.Text = "Interrogazione BDA"

                f.ShowDialog()

                If f.DialogResult <> Windows.Forms.DialogResult.OK Then
                    Exit Sub
                End If

                OpzioniDBA = f.Opzioni
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

        'se necessario eseguo l'estrazione con l'estrattore dati
        Dim Annulla As Boolean

        Select Case OpzioniDBA.TipoFile
            Case ExportLib.BancaDatiAnia.TipoFile.STORNATE
                OpzioniDBA.Dati = BDAEstrazione(EstrazioneStornate, Annulla)

                If (Annulla = True) OrElse (OpzioniDBA.Dati Is Nothing) OrElse (OpzioniDBA.Dati.Rows.Count = 0) Then
                    Exit Sub
                End If
                NormalizzaTarghe(OpzioniDBA.Dati)
                'dalla tabella che mi restituisce l'estrattore elimino le targhe bloccate
                EliminaTargheBloccate(OpzioniDBA.Dati)

            Case ExportLib.BancaDatiAnia.TipoFile.ARRETRATI
                OpzioniDBA.Dati = BDAEstrazione(EstrazioneArretrati, Annulla)

                If (Annulla = True) OrElse (OpzioniDBA.Dati Is Nothing) OrElse (OpzioniDBA.Dati.Rows.Count = 0) Then
                    Exit Sub
                End If
                NormalizzaTarghe(OpzioniDBA.Dati)
                'dalla tabella che mi restituisce l'estrattore elimino le targhe bloccate
                EliminaTargheBloccate(OpzioniDBA.Dati)

            Case Else
                'non fare niente
        End Select

        'ora interrogo BDA
        Dim az As New ExportLib.Azioni
        az.InterrogaBDA(OpzioniDBA)

        'aggiorno visualizzazione
        Select Case OpzioniDBA.TipoFile
            Case ExportLib.BancaDatiAnia.TipoFile.STORNATE
                ButtonStornate.PerformClick()
            Case ExportLib.BancaDatiAnia.TipoFile.ARRETRATI
                ButtonArretrati.PerformClick()
            Case ExportLib.BancaDatiAnia.TipoFile.UTENTE
                ButtonUtente.PerformClick()
            Case Else
                ButtonStornate.PerformClick()
        End Select
    End Sub

    Private Function BDAEstrazione(NomeEstrazione As String,
                                   ByRef Annulla As Boolean) As DataTable

        Dim Estrattore As New UniSql.UniSql()
        Dim Estrazione As UniSql.CManifestoSql = Estrattore.GetSqlAsObject(NomeEstrazione)

        If Estrazione IsNot Nothing Then
            'controllo la date dell'estrazione altrimenti aggiorno il catalogo
            Select Case NomeEstrazione
                Case EstrazioneStornate
                    If CDate(Estrazione.UltAgg) < #4/10/2015# Then
                        Estrattore.AggiornaCatalogoEstrazioni(True)
                    End If
                Case EstrazioneArretrati
                    If CDate(Estrazione.UltAgg) < #4/10/2015# Then
                        Estrattore.AggiornaCatalogoEstrazioni(True)
                    End If
            End Select

            Return Estrattore.ShowGridAndGetDataTable(NomeEstrazione,
                                                      Annulla,
                                                      "Interroga BDA",
                                                      "Interroga la Banca dati ANIA",
                                                      My.Resources.ania.ToBitmap)
        Else
            Annulla = True
            Return Nothing
        End If
    End Function

    Private Sub CambiaStatoLogin(e As Utx.LoginEventArgs)
        Notifica.Messaggio = e.Stato
        Notifica.TopMost = True
    End Sub

    Private Sub AnnullaImportazione() Handles Notifica.Annulla
        If Importa IsNot Nothing Then
            Notifica.Messaggio = "Annullamento in corso..."
            Importa.Annulla = True
        End If
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        If dgvBDA.ColumnCount > 0 Then
            FormFiltro.SalvaLayoutGriglia(Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "BDA.layout.xml"), "COMPLETO")
        End If
        Me.Close()
    End Sub

    Private Sub LeggiBDA(Tipo As TipoQuery, Provenienza As ProvenienzaTarga)
        Try
            Cursor = Cursors.WaitCursor

            LabelConteggio.Text = "..."
            LabelConteggio.Refresh()

            dgvBDA.DataSource = Nothing
            dgvBDA.Refresh()

            dv.Table = Utx.WsCommand.ExecuteNonQuery(QueryBDA(Tipo, Provenienza)).DataTable
            dgvBDA.DataSource = dv

            FormattaGrigliaBDA()

            'se esiste legge il layout dal file xml
            FormFiltro.LeggiLayoutDaXml(Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "BDA.layout.xml"), "COMPLETO")

            If FormFiltro.EsisteLayoutGriglia = True Then
                FormFiltro.ApplicaLayoutGriglia(dgvBDA)
            Else
                'salvo il layout se non già presente
                FormFiltro.LeggiLayoutDaGriglia(dgvBDA)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function QueryBDA(Tipo As TipoQuery, Provenienza As ProvenienzaTarga) As String
        Dim Query As String = "SELECT B.BloccoTarga,B.Aggiornato,B.ProvenienzaTarga,B.CodiceFiscaleStorno,
            CL.Cognome + ' ' + CL.Nome AS Cliente,CL.IDStatoCliente,Iif(B.CodiceFiscaleStorno = B.CodiceFiscale,'','S') AS CambioCF,
            B.Targa,B.ClasseRca,B.CartaCircolazione,B.MotivoEmissioneCarta,B.Immatricolazione,B.Modello,B.Cilindrata,B.HP,B.KW,
            B.Alimentazione,(Format(B.CodiceCompagnia,'000 - ') + A.Desc_Compagnia) AS Compagnia,B.Effetto,B.ScadenzaCopertura,
            B.ScadenzaContratto,B.Tariffa,B.ClasseTariffa,B.DataSinistro,B.Prodotto,B.Ramo,B.Polizza,B.DataEffetto,B.DataScadenza,
            B.Frazionamento,B.Convenzione,(B.IdStorno + ' - ' + S.Storno) AS Storno,B.DataStorno,B.UltimoPremio,B.IncendioFurto,
            B.CodiceFiscale,(Year(GETDATE()) - Year(C.DataNascita)) AS Eta,C.Cognome + ' ' + C.Nome AS Assicurato,C.IDStatoCliente,
            C.Sesso,C.DataNascita,Format(C.SubAgenzia,'000 - ') + F.FiguraProduttiva AS Sub,C.Localita,C.Sindacati,C.TipoCliente,
            C.DataInserimento,C.DataCessazione,C.PolizzeVigore,C.PolizzeStoriche,C.PremiCorrente,C.PremiPrecedente,C.PremiTotale,
            C.SinistriCorrente,C.SinistriPrecedente,C.LiquidatoCorrente,C.LiquidatoPrecedente,C.SinistriTotale,C.LiquidatoTotale,
            C.ConsensoPrivacy,C.Indirizzo,C.Cap,C.Provincia,C.Telefono1,C.Telefono2,C.Cellulare,C.Email 
            FROM BDA AS B 
            LEFT JOIN DB00000.dbo.CompagniaANIA AS A ON B.CodiceCompagnia = A.Compagnia
            LEFT JOIN Clienti AS C ON B.CodiceFiscale = C.CodiceFiscale
            LEFT JOIN Clienti AS CL ON B.CodiceFiscaleStorno = CL.CodiceFiscale
            LEFT JOIN FigureProduttive AS F ON C.SubAgenzia = F.IdFiguraProduttiva
            LEFT JOIN DB00000.dbo.TipoStorni AS S ON (B.IdStorno = S.IdStorno AND S.Settore = 'D')"

        If Tipo = TipoQuery.CLIENTIARCHIVIO Then
            Select Case Provenienza
                Case ProvenienzaTargA.STORNATE
                    Query &= " WHERE ProvenienzaTarga = 'ST'"
                Case ProvenienzaTargA.ARRETRATI
                    Query &= " WHERE ProvenienzaTarga = 'AR'"
                Case ProvenienzaTarga.UTENTE
                    Query &= " WHERE ProvenienzaTarga = 'UT'"
            End Select
        End If

        Return Query
    End Function

    Private Sub FormattaGrigliaBDA()

        On Error Resume Next

        With dgvBDA
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize

            With .Columns("BloccoTarga")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Non interrogare BDA"
            End With
            With .Columns("PremiTotale")
                .DefaultCellStyle.Format = "###,##0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .HeaderText = "Totale premi"
            End With
            With .Columns("CodiceFiscaleStorno")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .HeaderText = "CF Stornata"
            End With
            With .Columns("CambioCF")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "CF cambiato"
            End With
            With .Columns("ClasseRca")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Classe RCA (BDA)"
            End With
            With .Columns("cl.IdStatoCliente")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Stato cliente"
            End With
            With .Columns("ProvenienzaTarga")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Provenienza targa"
            End With
            With .Columns("CartaCircolazione")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Carta di circolazione (BDA)"
            End With
            With .Columns("MotivoEmissioneCarta")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .HeaderText = "Motivo emissione carta (BDA)"
            End With
            With .Columns("Immatricolazione")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Immatricolazione (BDA)"
            End With
            With .Columns("Cilindrata")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Cilindrata (BDA)"
            End With
            With .Columns("Hp")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Hp (BDA)"
            End With
            With .Columns("Kw")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Kw (BDA)"
            End With
            With .Columns("Alimentazione")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Alim. (BDA)"
            End With
            With .Columns("Effetto")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Effetto (BDA)"
            End With
            With .Columns("ScadenzaCopertura")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Scadenza copertura (BDA)"
            End With
            With .Columns("ScadenzaContratto")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Scadenza contratto (BDA)"
            End With
            .Columns("Prodotto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Ramo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With .Columns("DataEffetto")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Effetto stornata"
            End With
            With .Columns("DataScadenza")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Scadenza stornata"
            End With
            With .Columns("Frazionamento")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Fraz"
            End With
            .Columns("Convenzione").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With .Columns("DataStorno")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Data storno"
            End With
            With .Columns("UltimoPremio")
                .DefaultCellStyle.Format = "###,##0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .HeaderText = "Ultimo premio"
            End With
            With .Columns("IncendioFurto")
                .DefaultCellStyle.Format = "###,##0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .HeaderText = "Incendio e furto"
            End With
            With .Columns("Eta")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Età"
            End With
            With .Columns("c.IdStatoCliente")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Stato cliente"
            End With
            With .Columns("CodiceFiscale")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .HeaderText = "CF attuale del veicolo (BDA)"
            End With
            .Columns("Sesso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With .Columns("DataNascita")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Data di nascita"
            End With
            .Columns("Sindacati").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With .Columns("TipoCliente")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Tipo cliente"
            End With
            With .Columns("DataInserimento")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Data inserimento"
            End With
            With .Columns("DataCessazione")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Data cessazione"
            End With
            With .Columns("PolizzeVigore")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Polizze vigore"
            End With
            With .Columns("PolizzeStoriche")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Polizze storiche"
            End With
            With .Columns("PremiCorrente")
                .DefaultCellStyle.Format = "###,##0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .HeaderText = "Premi correnti"
            End With
            With .Columns("PremiPrecedente")
                .DefaultCellStyle.Format = "###,##0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .HeaderText = "Premi precedenti"
            End With
            With .Columns("SinistriCorrente")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Sinistri correnti"
            End With
            With .Columns("SinistriPrecedente")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Sinistri precedente"
            End With
            With .Columns("LiquidatoCorrente")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,##0"
                .HeaderText = "Liquidato corrente"
            End With
            With .Columns("LiquidatoPrecedente")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,##0"
                .HeaderText = "Liquidato precedente"
            End With
            With .Columns("SinistriTotale")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Sinistri totali"
            End With
            With .Columns("LiquidatoTotale")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,##0"
                .HeaderText = "Liquidato totale"
            End With
            With .Columns("ConsensoPrivacy")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Privacy"
            End With

            .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

            'blocca l'ordinamento (possibile solo da codice)
            For Each c As DataGridViewColumn In dgvBDA.Columns
                c.SortMode = DataGridViewColumnSortMode.Programmatic
            Next
        End With
    End Sub

    Private Sub ButtonExcel_Click(sender As Object, e As EventArgs) Handles ButtonExcel.Click

        If dgvBDA.Rows.Count > 0 Then

            Utx.NetFunc.Esporta2Excel({dgvBDA},
                                     {"Interrogazione BDA"},
                                     String.Format("BDA ({0} ore {1})", Format(Today, "dd-MM-yyyy"), Format(Now, "HH_mm")),
                                     Color.Khaki)
        End If
    End Sub

    Private Sub ButtonCsv_Click(sender As Object, e As EventArgs) Handles ButtonCsv.Click
        If dgvBDA.Rows.Count > 0 Then
            Utx.NetFunc.Esporta2Csv(dgvBDA, "Interrogazione BDA", Color.Khaki)
        End If
    End Sub

    Private Sub dgvBDA_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBDA.CellClick

        If dgvBDA.Columns(e.ColumnIndex).Name = "BloccoTarga" Then

            dgvBDA.CurrentCell.Value = Not dgvBDA.CurrentCell.Value
            'salvo nel db
            ModificaBloccoTarga(dgvBDA.CurrentRow.Cells("Targa").Value, dgvBDA.CurrentCell.Value)
        End If

    End Sub

    Private Sub dgvBDA_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvBDA.CellFormatting

        If e.ColumnIndex = 0 Then

            If dgvBDA.Rows(e.RowIndex).Cells("BloccoTarga").Value = True Then
                dgvBDA.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gainsboro
            Else
                dgvBDA.Rows(e.RowIndex).DefaultCellStyle.BackColor = dgvBDA.DefaultCellStyle.BackColor
            End If
        End If

    End Sub

    Private Sub ModificaBloccoTarga(Targa As String,
                                    Blocco As Boolean)
        Try
            Cursor = Cursors.WaitCursor

            Dim Query As String = String.Format("UPDATE Bda 
                SET BloccoTarga = cast({0} as bit) 
                WHERE Targa = '{1}'", IIf(Blocco = False, 0, 1), Targa)

            Utx.WsCommand.ExecuteNonQueryRecord(Query)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgvBDA_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvBDA.ColumnHeaderMouseClick
        Try
            'cartella per salvataggio filtro
            FormFiltro.AppName = "BDA"
            FormFiltro.FilterFolder = Utx.Globale.Paths.CartellaSettingRete

            'visualizzo la finestra del filtro
            FormFiltro.Visualizza(dgvBDA.Columns(e.ColumnIndex))
            Debug.Print(String.Format("{0}: {1}", Now, FormFiltro.Query))

            AttivaDisattivaFiltri()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub AttivaDisattivaFiltri()
        If dv.RowFilter.Trim.Length > 0 Then 'se il filtro è applicato
            CheckBoxFiltri.Text = "Disattiva filtri"
            CheckBoxFiltri.Checked = True
            CheckBoxFiltri.BackColor = Color.Salmon
        Else 'se non è applicato
            If FormFiltro.EsisteFiltro Then
                CheckBoxFiltri.Text = "Attiva filtri"
            Else
                CheckBoxFiltri.Text = "Nessun filtro"
            End If

            CheckBoxFiltri.Checked = False
            CheckBoxFiltri.BackColor = Color.PaleGreen
        End If

        'rende il bottone visibile se esiste un filtro
        CheckBoxFiltri.Enabled = FormFiltro.EsisteFiltro
    End Sub

    Private Sub CheckBoxFiltri_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxFiltri.CheckedChanged

        If CheckBoxFiltri.Checked = False Then
            dv.RowFilter = ""
        Else
            dv.RowFilter = FormFiltro.Query
        End If

        AttivaDisattivaFiltri()
    End Sub

    Private Sub dv_ListChanged(sender As Object, e As System.ComponentModel.ListChangedEventArgs) Handles dv.ListChanged
        LabelConteggio.Text = dv.Count
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

    Private Sub dgvBDA_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dgvBDA.ColumnWidthChanged
        FormFiltro.ModificaLarghezzaColonna(e.Column)
    End Sub

    Private Sub ButtonStornate_Click(sender As Object, e As EventArgs) Handles ButtonStornate.Click
        TabPageBDA.Text = "Gestione BDA - Stornate"
        LeggiBDA(TipoQuery.CLIENTIARCHIVIO, ProvenienzaTarga.STORNATE)
    End Sub

    Private Sub ButtonArretrati_Click(sender As Object, e As EventArgs) Handles ButtonArretrati.Click
        TabPageBDA.Text = "Gestione BDA - Arretrati"
        LeggiBDA(TipoQuery.CLIENTIARCHIVIO, ProvenienzaTarga.ARRETRATI)
    End Sub

    Private Sub ButtonUtente_Click(sender As Object, e As EventArgs) Handles ButtonUtente.Click
        TabPageBDA.Text = "Gestione BDA - Utente"
        LeggiBDA(TipoQuery.CLIENTIARCHIVIO, ProvenienzaTarga.UTENTE)
    End Sub

    Private Sub ButtonTutto_Click(sender As Object, e As EventArgs) Handles ButtonTutto.Click
        TabPageBDA.Text = "Gestione BDA - Tutto"
        LeggiBDA(TipoQuery.TUTTO, ProvenienzaTarga.TUTTO)
    End Sub

    Private Sub dgvBDA_DoubleClick(sender As Object, e As EventArgs) Handles dgvBDA.DoubleClick

        If IsDate(dgvBDA.CurrentRow.Cells("ScadenzaContratto").Value) AndAlso
            dgvBDA.CurrentRow.Cells("ScadenzaContratto").Value > Today Then

            MsgBox(String.Format("Il contratto per la targa {0} scadrà il {1:d}",
                                 dgvBDA.CurrentRow.Cells("Targa").Value,
                                 dgvBDA.CurrentRow.Cells("ScadenzaContratto").Value),
                MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        Else
            If MsgBox(String.Format("Aggiornare i dati per la targa {0}", dgvBDA.CurrentRow.Cells("Targa").Value),
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                AggiornaTarga(dgvBDA.CurrentRow.Cells("Targa").Value)
            End If
        End If

    End Sub

    Private Sub AggiornaTarga(Targa As String)
        If Directory.Exists(Utx.Globale.Paths.CartellaDati) = False Then
            MsgBox("Cartella dati non disponibile", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            Exit Sub
        End If

        'interrogo BDA per la targa
        Try
            Dim OpzioniDBA As New ExportLib.BancaDatiAnia.Opzioni
            With OpzioniDBA
                .TipoFile = ExportLib.BancaDatiAnia.TipoFile.TARGASINGOLA
                .TargaSingola = Targa
                .SoloAutovetture = False
            End With

            Dim az As New ExportLib.Azioni
            az.InterrogaBDA(OpzioniDBA)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

        'aggiorno visualizzazione
        ButtonStornate_Click(Me, New EventArgs)
    End Sub

    Private Sub NormalizzaTarghe(ByRef Dati As DataTable)
        Try
            For Each r As DataRow In Dati.Rows
                If IsDBNull(r("Targa")) Then
                    r("Targa") = ""
                Else
                    r("Targa") = r("Targa").ToString.Trim.ToUpper
                End If
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub EliminaTargheBloccate(ByRef Dati As DataTable)
        'elimino dalla tabella le targhe bloccate e che non bisogna interrogare
        Try
            Dim Bloccate As DataTableReader = Utx.FunzioniDb.CreaDataTableReader("SELECT Targa FROM Bda WHERE BloccoTarga = 1")

            If Bloccate.HasRows Then
                Globale.Log.Info("Elimino le targhe bloccate")
                Dim TargheBloccate As Integer = 0
                'per ogni targa bloccata
                Do While Bloccate.Read
                    Dim Row() As DataRow = Dati.Select(String.Format("Targa = '{0}'", Bloccate("Targa").ToString.Trim.ToUpper))

                    If Row.Length > 0 Then
                        'la cancello
                        Row(0)("Targa") = ""
                        TargheBloccate += 1
                        Globale.Log.Trace(String.Format("Elimino dai dati la targa bloccata {0}", Bloccate("Targa")))
                    End If
                Loop
                Globale.Log.Info(String.Format("Targhe bloccate {0}", TargheBloccate))
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonAggiorna_Click(sender As Object, e As EventArgs) Handles ButtonAggiorna.Click
        Try
            Dim OpzioniDBA As New ExportLib.BancaDatiAnia.Opzioni
            With OpzioniDBA
                .TipoFile = ExportLib.BancaDatiAnia.TipoFile.STORNATE
                .SoloAutovetture = False
            End With

            Dim az As New ExportLib.Azioni
            az.AggiornaBDA(OpzioniDBA)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

        'aggiorno visualizzazione
        ButtonStornate.PerformClick()
    End Sub
End Class
