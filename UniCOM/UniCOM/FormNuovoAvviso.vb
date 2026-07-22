Public Class FormNuovoAvviso

    Private Enum Selezione
        CLIENTE
        POLIZZA
    End Enum

    Public Property RecordAggiunti As Integer = 0

    Private _TipoSelezione As Selezione = Selezione.CLIENTE
    Private _CodiceAgenzia
    Private _Sesso
    Private _Rg

    Sub New(CodiceAgenzia As String)

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("aua")
        Me.Text = "Aggiungi scadenza " + CodiceAgenzia
        Me.BackgroundImageLayout = ImageLayout.Center

        _CodiceAgenzia = CodiceAgenzia

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        TextBoxTotale.Text = 0
        TextBoxCF.Enabled = False
        TextBoxCF.Font = Utx.AppFont.Bold
        TextBoxContraente.Enabled = False
        TextBoxContraente.Font = Utx.AppFont.Bold
        TextBoxCerca.BackColor = Color.LightYellow
        dtpEffetto.Value = Koine.Avvisi.InizioPeriodo
        LabelMessaggi.Font = Utx.AppFont.Bold
        LabelMessaggi.Text = "..."

        ButtonSeleziona.Image = Risorse.Immagini.Bitmap("ok32")

        With dtpEffetto
            .MinDate = Koine.Avvisi.InizioPeriodo
            .MaxDate = Koine.Avvisi.FinePeriodo
        End With
        With dgvDati
            .AllowUserToAddRows = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    Private Sub ButtonCerca_Click(sender As Object, e As EventArgs) Handles ButtonCerca.Click
        Try
            If TextBoxCerca.Text.Length > 0 Then

                Cursor = Cursors.WaitCursor
                ButtonSeleziona.Enabled = False

                dgvDati.DataSource = Nothing
                dgvDati.Refresh()

                Dim Sql As String = "SELECT Cognome,Nome,Indirizzo,Localita,DataNascita AS [Nato il],Subagenzia AS Sub,CodiceFiscale AS CF,
                                     Sesso
                                     FROM Clienti WHERE {0}"
                'creo i tag
                Dim Tag As String = " ((Cognome + ' ' + Nome) LIKE '%{0}%') "
                Dim Tags() As String = TextBoxCerca.Text.Split(Space(1))

                For k As Integer = 0 To Tags.GetUpperBound(0)
                    Tags(k) = String.Format(Tag, Tags(k).Replace("'", "").Replace("""", ""))
                Next
                'creo la clausola
                Dim Clausola As String = Tags(0)
                For k As Integer = 1 To Tags.GetUpperBound(0)
                    Clausola += " AND " + Tags(k)
                Next
                'completo la query
                Sql = String.Format(Sql, Clausola)

                dgvDati.DataSource = Utx.WsCommand.ExecuteNonQuery(Sql).DataTable
                dgvDati.AutoResizeColumns()

                _TipoSelezione = Selezione.CLIENTE

                If dgvDati.Rows.Count > 0 Then
                    ButtonSeleziona.Text = "Seleziona cliente"
                    ButtonSeleziona.Enabled = True
                Else
                    ButtonSeleziona.Text = "Seleziona"
                    ButtonSeleziona.Enabled = False
                End If

                dgvDati.Focus()
                Me.AcceptButton = Nothing
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.Close()
    End Sub

    Private Sub FormNuovoAvviso_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ButtonSeleziona.Enabled = False
        TextBoxCerca.Focus()
    End Sub

    Private Sub ButtonSeleziona_Click(sender As Object, e As EventArgs) Handles ButtonSeleziona.Click
        Try
            If _TipoSelezione = Selezione.CLIENTE Then
                TextBoxCF.Text = dgvDati.CurrentRow.Cells("CF").Value
                TextBoxContraente.Text = dgvDati.CurrentRow.Cells("Cognome").Value + " " + dgvDati.CurrentRow.Cells("Nome").Value
                TextBoxSub.Text = dgvDati.CurrentRow.Cells("Sub").Value
                TextBoxRamo.Text = ""
                TextBoxPolizza.Text = ""
                TextBoxTotale.Text = 0
                _Sesso = dgvDati.CurrentRow.Cells("Sesso").Value

                Dim Query As String = String.Format("SELECT Ramo,Polizza,DataEffetto AS Effetto,CodiceSubAgente AS Sub,Targa,Convenzione 
                FROM Polizze 
                WHERE CodiceFiscale = '{0}'", dgvDati.CurrentRow.Cells("CF").Value)
                dgvDati.DataSource = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

                _TipoSelezione = Selezione.POLIZZA

                If dgvDati.Rows.Count > 0 Then
                    ButtonSeleziona.Text = "Seleziona polizza"
                    ButtonSeleziona.Enabled = True
                Else
                    ButtonSeleziona.Text = "Seleziona"
                    ButtonSeleziona.Enabled = False
                End If
            Else
                TextBoxRamo.Text = dgvDati.CurrentRow.Cells("Ramo").Value
                TextBoxPolizza.Text = dgvDati.CurrentRow.Cells("Polizza").Value
                TextBoxSub.Text = dgvDati.CurrentRow.Cells("Sub").Value
                dtpEffetto.Value = New Date(Koine.Avvisi.InizioPeriodo.Year, Koine.Avvisi.InizioPeriodo.Month, dgvDati.CurrentRow.Cells("Effetto").Value.Day)
                TextBoxTarga.Text = Utx.FunzioniDb.NullToString(dgvDati.CurrentRow.Cells("Targa").Value)
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub TextBoxCerca_GotFocus(sender As Object, e As EventArgs) Handles TextBoxCerca.GotFocus
        Me.AcceptButton = ButtonCerca
    End Sub

    Private Sub dgvDati_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDati.CellDoubleClick
        ButtonSeleziona.PerformClick()
    End Sub

    Private Sub ButtonAggiungiAvviso_Click(sender As Object, e As EventArgs) Handles ButtonAggiungiAvviso.Click
        Try
            LabelMessaggi.Text = "..."

            If ControllaDati() = True Then
                Dim Sql As String = String.Format("SELECT RamoGestione FROM DB00000.dbo.RPolToRGest WHERE RamoPolizza = {0}", TextBoxRamo.Text)
                _Rg = Utx.WsCommand.ExecuteScalar(Sql).Valore

                Sql = String.Format("INSERT INTO Postalizzazione (Selezionato,SenzaPremio,Agenzia,Subagenzia,Ramo,Polizza,
                    EffettoTitolo,TipoCarico,CodiceFiscale,TotaleTitolo,Frazionamento,Targa,Prodotto,Convenzione,RamoGestione,
                    ScadenzaPolizza,Tipo,Contraente,Sesso,RataIntermedia,RID,Delegataria,Quota,ImportoQuota)
                    VALUES (CAST(1 AS bit),CAST(0 AS bit),{0},{1},{2},{3},'{4:dd/MM/yyyy}',4,'{5}',{6},1,'{7}','XXXXX',0,{8},'1/1/1900',
                    '','{9}','{10}','N','N',0,0,0)",
                    _CodiceAgenzia,
                    TextBoxSub.Text,
                    TextBoxRamo.Text,
                    TextBoxPolizza.Text,
                    dtpEffetto.Text,
                    TextBoxCF.Text,
                    TextBoxTotale.Text.Replace(",", "."),
                    TextBoxTarga.Text,
                    _Rg,
                    TextBoxContraente.Text,
                    _Sesso)

                Dim Risposta As Integer = Utx.WsCommand.ExecuteNonQueryRecord(Sql, _CodiceAgenzia)

                If Risposta > 0 Then
                    RecordAggiunti += 1
                    LabelMessaggi.Text = String.Format("Scadenza aggiunta correttamente - (Totale {0})", RecordAggiunti)
                Else
                    LabelMessaggi.Text = "Scadenza non aggiunta"
                End If
            Else
                LabelMessaggi.Text = "Scadenza non aggiunta"
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function ControllaDati() As Boolean
        Try
            If TextBoxCF.Text.Trim.Length = 0 Then
                MsgBox("Codice fiscale obbligatorio", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                TextBoxCerca.Focus()
                Return False
            End If
            If TextBoxContraente.Text.Trim.Length = 0 Then
                MsgBox("Contraente obbligatorio", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                TextBoxCerca.Focus()
                Return False
            End If
            If TextBoxRamo.Text.Trim.Length = 0 OrElse TextBoxPolizza.Text.Trim.Length = 0 Then
                MsgBox("Ramo e polizza obbligatori", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                TextBoxRamo.Focus()
                Return False
            End If
            If IsNumeric(TextBoxRamo.Text) = False OrElse IsNumeric(TextBoxPolizza.Text) = False Then
                MsgBox("Formato ramo e/o polizza errato", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                TextBoxRamo.Focus()
                Return False
            End If
            If dtpEffetto.Value.Month <> Koine.Avvisi.InizioPeriodo.Month Then
                MsgBox("Data effetto titolo non valida", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                dtpEffetto.Focus()
                Return False
            End If
            If EsisteQuietanza() = True Then
                Return False
            End If
            If TextBoxTotale.Text = 0 Then
                MsgBox("Il totale titolo non può essere uguale a zero.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                TextBoxTotale.Focus()
                Return False
            End If
            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Function EsisteQuietanza() As Boolean
        Try
            Dim Sql As String = String.Format("SELECT COUNT(*)
                FROM Postalizzazione
                WHERE Ramo = {0} AND Polizza = {1} AND EffettoTitolo = '{2:dd/MM/yyyy}'",
                TextBoxRamo.Text,
                TextBoxPolizza.Text,
                dtpEffetto.Text)

            If Utx.WsCommand.ExecuteScalar(Sql, _CodiceAgenzia).Valore = 0 Then
                Return False
            Else
                MsgBox("Esiste già un avviso per questa polizza e questa scadenza", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Return True
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Function

    Private Sub LabelMessaggi_TextChanged(sender As Object, e As EventArgs) Handles LabelMessaggi.TextChanged
        LabelMessaggi.Refresh()
    End Sub
End Class