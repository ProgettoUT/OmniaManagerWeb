Public Class FormGestioneRete

    Public Enum Sezione
        PUNTI_VENDITA
        SOGGETTI
        UTENZE
        CIP
    End Enum

    Private Event SalvaSelezioni()

    Private Tabella As Sezione
    Friend WithEvents FormFiltro As New Utx.FormGestioneFiltro(1000)

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.Size = New Drawing.Size(800, 500)
        Me.WindowState = Windows.Forms.FormWindowState.Maximized
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("clienti")
        Me.Text = "Gestione rete"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With rbPuntiVendita
            .FlatStyle = Windows.Forms.FlatStyle.Flat
            .FlatAppearance.CheckedBackColor = Color.PaleGreen
            .FlatAppearance.BorderColor = Color.Silver
        End With
        With rbSoggetti
            .FlatStyle = Windows.Forms.FlatStyle.Flat
            .FlatAppearance.CheckedBackColor = Color.PaleGreen
            .FlatAppearance.BorderColor = Color.Silver
        End With
        With rbUtenze
            .FlatStyle = Windows.Forms.FlatStyle.Flat
            .FlatAppearance.CheckedBackColor = Color.PaleGreen
            .FlatAppearance.BorderColor = Color.Silver
        End With
        With rbCip
            .FlatStyle = Windows.Forms.FlatStyle.Flat
            .FlatAppearance.CheckedBackColor = Color.PaleGreen
            .FlatAppearance.BorderColor = Color.Silver
        End With
        With ButtonAggiornaListe
            .Padding = Utx.AppFont.ButtonPadding
            .Text = "Aggiorna liste da Essig"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("aggiorna")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonEsci
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = ContentAlignment.MiddleCenter
            .Text = ""
        End With
        With dgvDati
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .EditMode = Windows.Forms.DataGridViewEditMode.EditProgrammatically
            .SelectionMode = Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        End With
        Utx.NetFunc.DoppioBuffer(dgvDati)
    End Sub

    Private Sub rbPuntiVendita_CheckedChanged(sender As Object, e As EventArgs) Handles rbPuntiVendita.CheckedChanged
        If rbPuntiVendita.Checked = True Then
            Tabella = Sezione.PUNTI_VENDITA
            LeggiLista()
        Else
            RaiseEvent SalvaSelezioni()
        End If
    End Sub

    Private Sub rbSoggetti_CheckedChanged(sender As Object, e As EventArgs) Handles rbSoggetti.CheckedChanged
        If rbSoggetti.Checked = True Then
            Tabella = Sezione.SOGGETTI
            LeggiLista()
        Else
            RaiseEvent SalvaSelezioni()
        End If
    End Sub

    Private Sub rbUtenze_CheckedChanged(sender As Object, e As EventArgs) Handles rbUtenze.CheckedChanged
        If rbUtenze.Checked = True Then
            Tabella = Sezione.UTENZE
            LeggiLista()
        Else
            RaiseEvent SalvaSelezioni()
        End If
    End Sub

    Private Sub rbCip_CheckedChanged(sender As Object, e As EventArgs) Handles rbCip.CheckedChanged
        If rbCip.Checked = True Then
            Tabella = Sezione.CIP
            LeggiLista()
        Else
            RaiseEvent SalvaSelezioni()
        End If
    End Sub

    Private Sub dgvDati_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvDati.DataSourceChanged
        dgvDati.Refresh()
    End Sub

    Private Sub LeggiLista()
        Try
            Cursor = Cursors.WaitCursor
            dgvDati.DataSource = Nothing

            Dim sql As String = ""
            Select Case Tabella
                Case Sezione.PUNTI_VENDITA : sql = "SELECT * FROM Punti_Vendita ORDER BY PuntoVenditaAgenzia"
                Case Sezione.SOGGETTI : sql = "SELECT * FROM Soggetti ORDER BY CognomeSoggetto,NomeSoggetto"
                Case Sezione.UTENZE : sql = "SELECT * FROM Utenze ORDER BY Utenza"
                Case Sezione.CIP : sql = "SELECT * FROM Cip ORDER BY Cip"
            End Select

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(sql)
            If Risposta IsNot Nothing Then
                dgvDati.DataSource = Risposta.DataTable
                dgvDati.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
                Utx.NetFunc.BloccaOrdinamento(dgvDati)
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub SalvaFlag()
        Select Case Tabella
            Case Sezione.PUNTI_VENDITA : SalvaFlagPuntiVendita()
            Case Sezione.SOGGETTI : SalvaFlagSoggetti()
            Case Sezione.UTENZE : SalvaFlagUtenze()
            Case Sezione.CIP : SalvaFlagCip()
        End Select
    End Sub

    Private Sub FormGestioneRete_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        RaiseEvent SalvaSelezioni()
    End Sub

    Private Sub dgvDati_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDati.CellClick
        Try
            If (e.RowIndex >= 0) AndAlso (e.ColumnIndex >= 0) AndAlso (dgvDati.Columns(e.ColumnIndex).Name = "Selezionato") Then
                dgvDati.CurrentCell.Value = Not dgvDati.CurrentCell.Value
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

#Region "SalvaFlag"
    Private Sub SalvaFlagPuntiVendita()
        Try
            Using s As New Utx.Rete.GestioneRete
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.SalvaFlagPuntiVendita(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, dgvDati.DataSource, Utx.Globale.Token)
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub SalvaFlagSoggetti()
        Try
            Using s As New Utx.Rete.GestioneRete
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.SalvaFlagSoggetti(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, dgvDati.DataSource, Utx.Globale.Token)
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub SalvaFlagUtenze()
        Try
            Using s As New Utx.Rete.GestioneRete
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.SalvaFlagUtenze(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, dgvDati.DataSource, Utx.Globale.Token)
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub SalvaFlagCip()
        Try
            Using s As New Utx.Rete.GestioneRete
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.SalvaFlagCip(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, dgvDati.DataSource, Utx.Globale.Token)
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
#End Region

    Private Sub ButtonAggiornaListe_Click(sender As Object, e As EventArgs) Handles ButtonAggiornaListe.Click
        Try
            Me.Enabled = False
            rbPuntiVendita.Checked = False
            rbSoggetti.Checked = False
            rbUtenze.Checked = False
            rbCip.Checked = False
            'rileggo i dati da essig
            Utx.Globale.SettingInterop.Rimuovi(Utx.GestioneFlag.TipoFlag.AUTO_LISTE_UTENTI)
            Utx.Globale.SettingInterop.Rimuovi(Utx.GestioneFlag.TipoFlag.BLOCCO_LISTE_RETE)
            TimerUnitools.ImportazioneListeRete(True)
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.Enabled = True
            Me.TopMost = True
            rbPuntiVendita.Checked = True
            'LeggiLista()
        End Try
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub dgvDati_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDati.ColumnHeaderMouseClick
        VisualizzaFiltro(e.ColumnIndex)
    End Sub

    Public Sub VisualizzaFiltro(IndiceColonna As Integer, Optional Centra As Boolean = False)
        Try
            If (dgvDati.DataSource IsNot Nothing) Then
                'cartella per salvataggio filtro
                With FormFiltro
                    .AppName = "GestioneRete"
                    .FilterFolder = Utx.Globale.Paths.CartellaSettingRete
                    .TabVisibili(True, False)

                    'visualizzo la finestra del filtro
                    .Visualizza(dgvDati.Columns(IndiceColonna), Centra)
                End With
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormGestioneRete_SalvaSelezioni() Handles Me.SalvaSelezioni
        Try
            If (dgvDati.DataSource IsNot Nothing) AndAlso (dgvDati.CurrentCell IsNot Nothing) Then
                FormFiltro.CancellaFiltri()
                'cambio riga altrimenti potrebbe non salvare la modifica appena fatta ???
                If dgvDati.CurrentRow.Index < dgvDati.Rows.Count - 1 Then
                    'non è l'ultima riga
                    dgvDati.CurrentCell = dgvDati(0, dgvDati.CurrentRow.Index + 1)
                Else
                    'se è l'ultima riga e le righe sono più di una vado in su
                    If dgvDati.CurrentRow.Index - 1 >= 0 Then
                        dgvDati.CurrentCell = dgvDati(0, dgvDati.CurrentRow.Index - 1)
                    End If
                End If
                SalvaFlag()
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormFiltro_ModificatoFiltro() Handles FormFiltro.ModificatoFiltro
        dgvDati.Refresh()
    End Sub
End Class