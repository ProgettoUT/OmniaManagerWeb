Imports System.Windows.Forms
Imports System.Drawing

Public Class FormUtenti

    Private Shared wrapper As New Utx.Crypto("19011957")

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Size = New Size(400, 500)
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("clienti")
        Me.Text = "Abilitazione utenti"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With ButtonDeseleziona
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.White
            .Text = "Deseleziona tutti"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("uncheck16")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonSeleziona
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.White
            .Text = "Seleziona tutti"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("check16")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With CheckedListBoxUtenze
            .IntegralHeight = False
            .BorderStyle = BorderStyle.FixedSingle
            .Margin = New Padding(1)
            .Padding = New Padding(2)
        End With
        With ButtonSalva
            .Margin = New Padding(1)
            .Padding = New Padding(10, 0, 10, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Salva"
            .TextAlign = ContentAlignment.MiddleLeft
            .Image = Risorse.Immagini.Bitmap("salva")
            .ImageAlign = ContentAlignment.MiddleRight
        End With
        With ButtonAnnulla
            .Margin = New Padding(1)
            .Padding = New Padding(10, 0, 10, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Annulla"
            .TextAlign = ContentAlignment.MiddleLeft
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = ContentAlignment.MiddleRight
        End With
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.Close()
    End Sub

    Private Sub FormUtenti_Load(sender As Object, e As EventArgs) Handles Me.Load
        LeggiUtenti()
    End Sub

    Private Sub LeggiUtenti()
        Try
            CheckedListBoxUtenze.Items.Clear()

            For Each codice As String In Utx.EnteGestore.CodiciGestiti
                Dim Query As String = "SELECT Utenza + ' - ' + NomeComponente AS Utente,
                    CASE
                    WHEN S.Chiave IS NULL THEN 1
                    ELSE 0
                    END
                    AS Abilitata
                    FROM Utenze AS U
                    LEFT JOIN Setting AS S ON S.Chiave = 'UTENTE_' + U.Utenza AND (S.Valore = 'BLOCCATO')
                    WHERE (NOT Utenza IS NULL) AND (StatoUtenza = 'ATTIVATA') 
					GROUP BY Utenza,NomeComponente ,s.Chiave
                    ORDER BY Utenza + ' - ' + NomeComponente"

                Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable
                For Each row As DataRow In dt.Rows
                    CheckedListBoxUtenze.Items.Add(row("Utente"), IIf(row("Abilitata") = 1, True, False))
                Next
            Next
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonSeleziona_Click(sender As Object, e As EventArgs) Handles ButtonSeleziona.Click
        For k As Integer = 0 To CheckedListBoxUtenze.Items.Count - 1
            CheckedListBoxUtenze.SetItemChecked(k, True)
        Next
    End Sub

    Private Sub ButtonDeseleziona_Click(sender As Object, e As EventArgs) Handles ButtonDeseleziona.Click
        For k As Integer = 0 To CheckedListBoxUtenze.Items.Count - 1
            CheckedListBoxUtenze.SetItemChecked(k, False)
        Next
    End Sub

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click
        Try
            'nessuna selezione
            If CheckedListBoxUtenze.CheckedItems.Count = 0 Then
                MsgBox("E' necessario selezionare almeno un utente.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            'reset abilitazioni
            Dim Query As String = "DELETE FROM Setting WHERE Sezione = 'ESCLUSIONI' AND Chiave LIKE 'UTENTE_%' AND Valore = 'BLOCCATO'"
            Utx.WsCommand.ExecuteNonQuery(Query)

            'se non sono tutti abilitati o tutti disabilitati
            If CheckedListBoxUtenze.CheckedItems.Count < CheckedListBoxUtenze.Items.Count Then
                For k As Integer = 0 To CheckedListBoxUtenze.Items.Count - 1
                    If CheckedListBoxUtenze.GetItemCheckState(k) = CheckState.Unchecked Then
                        Dim Utente As String = CheckedListBoxUtenze.Items(k).ToString.Split("-")(0).Trim
                        'leggo chiave con ora prossimo controllo
                        Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.ESCLUSIONI,
                                              "UTENTE_" + Utente,
                                              "BLOCCATO",
                                              Utx.SettingOMW.TipoOperazione.SCRITTURA)
                    End If
                Next
            End If

            MsgBox("Utenti abilitati salvati correttamente", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            Me.Close()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Shared Function UtenteAbilitato(Utenza As String) As Boolean
        Try
            Dim Chiave As New Utx.SettingItem(Utenza.Substring(1, 5))
            Chiave.SetItem(Utx.SettingItem.Sezioni.ESCLUSIONI, "UTENTE_" + Utenza, "BLOCCATO", SettingOMW.TipoOperazione.LETTURA_CON_VALORE)
            Return Not Chiave.ItemResult.Esiste
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function
End Class