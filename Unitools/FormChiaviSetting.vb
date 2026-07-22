Public Class FormChiaviSetting

    Private Log As New Utx.ApplicationLog("EsploraChiavi.log")

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Normal
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.Size = New Size(500, 500)
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("view")
        Me.Text = "Esplora chiavi setting"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With ListViewChiavi
            .BorderStyle = BorderStyle.FixedSingle
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .LabelEdit = False
            .MultiSelect = False
            .Sorting = SortOrder.Ascending
            'crea le colonne ripilogo filtro e i riferimento per il ridimensionamento
            .Columns.Add("Chiave", 150, HorizontalAlignment.Left)
            .Columns.Add("Valore", 150, HorizontalAlignment.Left)
        End With
        With LabelInfo
            .ForeColor = Utx.AppColor.RossoScuro
            .Text = "Attenzione: utilizzare questa funzione unicamente dietro indicazione dell'assistenza."
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With rbUtente
            .Margin = New Padding(0, 0, 0, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .FlatAppearance.CheckedBackColor = Color.PaleGreen
            .Text = "Utente"
        End With
        With rbInterop
            .Margin = New Padding(0, 0, 0, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .FlatAppearance.CheckedBackColor = Color.PaleGreen
            .Text = "Interop"
        End With
        With rbGlobale
            .Margin = New Padding(0, 0, 0, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .FlatAppearance.CheckedBackColor = Color.PaleGreen
            .Text = "Globale"
        End With
        With rbPostalizzazione
            .Margin = New Padding(0, 0, 0, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .FlatAppearance.CheckedBackColor = Color.PaleGreen
            .Text = "Postalizzazione"
        End With
        ButtonElimina.Text = "Elimina la chiave selezionata"
        ButtonModifica.Text = "Modifica la chiave"
    End Sub

    Private Sub FormChiaviSetting_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler rbUtente.CheckedChanged, AddressOf rbUtente_CheckedChanged
        AddHandler rbInterop.CheckedChanged, AddressOf rbUtente_CheckedChanged
        AddHandler rbGlobale.CheckedChanged, AddressOf rbUtente_CheckedChanged

        rbUtente.Checked = True
    End Sub

    Private Sub AggiornaLista()
        Dim Impostazioni As Utx.SerializableDictionary(Of String, String)

        If rbUtente.Checked = True Then
            Impostazioni = Utx.Globale.SettingUtente.Impostazioni
        ElseIf rbInterop.Checked = True Then
            Impostazioni = Utx.Globale.SettingInterop.Impostazioni
        ElseIf rbPostalizzazione.Checked = True Then
            Impostazioni = UniCom.Postalizzazione.SettingPostalizzazione.Impostazioni
        Else
            Impostazioni = Utx.Globale.SettingGlobale.Impostazioni
        End If

        ListViewChiavi.Items.Clear()

        For Each kvp As KeyValuePair(Of String, String) In Impostazioni
            With ListViewChiavi.Items.Add(kvp.Key)
                .SubItems.Add(kvp.Value)
            End With
        Next
        ListViewChiavi.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub rbUtente_CheckedChanged(sender As Object, e As EventArgs) Handles rbUtente.CheckedChanged
        AggiornaLista()
    End Sub

    Private Sub ButtonElimina_Click(sender As Object, e As EventArgs) Handles ButtonElimina.Click
        Try
            If ListViewChiavi.SelectedItems.Count = 1 Then
                If MsgBox("Attenzione: siete certi di voler cancellare la chiave selezionata?",
                          MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then

                    Log.Info(String.Format("L'utente ha cancellato la chiave {0} (valore: {1})",
                                           ListViewChiavi.SelectedItems(0).Text,
                                           ListViewChiavi.SelectedItems(0).SubItems(1).Text))

                    If rbUtente.Checked = True Then
                        Utx.Globale.SettingUtente.Rimuovi(ListViewChiavi.SelectedItems(0).Text)
                    ElseIf rbInterop.Checked = True Then
                        Utx.Globale.SettingInterop.Rimuovi(ListViewChiavi.SelectedItems(0).Text)
                    ElseIf rbPostalizzazione.Checked = True Then
                        UniCom.Postalizzazione.SettingPostalizzazione.Rimuovi(ListViewChiavi.SelectedItems(0).Text)
                    Else
                        Utx.Globale.SettingGlobale.Rimuovi(ListViewChiavi.SelectedItems(0).Text)
                    End If

                    AggiornaLista()
                End If
            End If

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonModifica_Click(sender As Object, e As EventArgs) Handles ButtonModifica.Click
        Try
            If ListViewChiavi.SelectedItems.Count = 1 Then

                Dim NuovoValore As String = InputBox("Nuovo valore", Utx.Globale.TitoloApp, ListViewChiavi.SelectedItems(0).SubItems(1).Text)

                If String.IsNullOrEmpty(NuovoValore) = False Then

                    If MsgBox("Attenzione: siete certi di voler modificare la chiave? Un valore errato potrebbe generare errori nell'applicazione!",
                              MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then

                        Log.Info(String.Format("L'utente ha modificato la chiave {0} (valore old: {1} - valore new: {2})",
                                               ListViewChiavi.SelectedItems(0).Text,
                                               ListViewChiavi.SelectedItems(0).SubItems(1).Text,
                                               NuovoValore))

                        If rbUtente.Checked = True Then
                            Utx.Globale.SettingUtente.AggiungiModifica(ListViewChiavi.SelectedItems(0).Text, NuovoValore)
                        ElseIf rbInterop.Checked = True Then
                            Utx.Globale.SettingInterop.AggiungiModifica(ListViewChiavi.SelectedItems(0).Text, NuovoValore)
                        ElseIf rbPostalizzazione.Checked = True Then
                            UniCom.Postalizzazione.SettingPostalizzazione.AggiungiModifica(ListViewChiavi.SelectedItems(0).Text, NuovoValore)
                        Else
                            Utx.Globale.SettingGlobale.AggiungiModifica(ListViewChiavi.SelectedItems(0).Text, NuovoValore)

                            If ListViewChiavi.SelectedItems(0).Text = Utx.GestioneFlag.TipoFlag.LIVELLO_LOG.ToString Then
                                'modifico il livello del log
                                Utx.ApplicationLog.LivelloLog = NuovoValore
                            End If
                        End If

                        AggiornaLista()
                    End If
                End If
            End If

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub ListViewChiavi_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListViewChiavi.ColumnClick
        If ListViewChiavi.Sorting = SortOrder.Ascending Then
            ListViewChiavi.Sorting = SortOrder.Descending
        Else
            ListViewChiavi.Sorting = SortOrder.Ascending
        End If
    End Sub
End Class