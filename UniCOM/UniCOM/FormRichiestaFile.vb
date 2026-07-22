Imports System.Text
Imports System.IO

Public Class FormRichiestaFile

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Size = New Size(490, 300)
        Me.Padding = New Padding(3)
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("comunica")
        Me.Text = "Richiesta file utente per invio comunicazioni"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        Dim sb As New StringBuilder
        sb.AppendLine("Per inviare sms a una lista di distribuzione utilizzare l'estrattore dati e il pulsante 'Comunica'.")
        sb.AppendLine("Se l'utente ha una propria lista di destinatari utilizzare questa procedura.")
        sb.AppendLine()
        sb.AppendLine("Per utilizzare questa procedura occorre fornire un file csv con i seguenti campi:")
        sb.AppendLine("1. Cognome (facoltativo)")
        sb.AppendLine("2. Nome (facoltativo)")
        sb.AppendLine("3. Telefono (obbligatorio)")
        sb.AppendLine("4. Scadenza (facoltativo)")
        sb.AppendLine("5. Targa (facoltativo)")
        sb.AppendLine()
        sb.AppendLine("E' possibile generare un file modello con l'apposito pulsante.")

        With LabelInfo
            .Margin = New Padding(1, 1, 1, 3)
            .Padding = New Padding(10)
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Gainsboro
            .Text = sb.ToString
        End With

        With ButtonModello
            .Margin = New Padding(1)
            .FlatAppearance.MouseOverBackColor = Color.PaleGreen
            .Text = "Crea un file modello"
        End With
        With ButtonSfoglia
            .Margin = New Padding(1)
            .FlatAppearance.MouseOverBackColor = Color.PaleGreen
            .Text = "Seleziona il file per l'invio"
        End With
        With ButtonEsci
            .Margin = New Padding(1)
            .FlatAppearance.MouseOverBackColor = Color.LightSalmon
            .Text = "Esci"
        End With
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ButtonModello_Click(sender As Object, e As EventArgs) Handles ButtonModello.Click
        Dim NomeFile As String = Path.Combine(Utx.Globale.UtenteCorrente.Desktop, "Modello invio sms.csv")

        If File.Exists(NomeFile) Then
            If MsgBox("Il file esiste già. Volete sovrascriverlo?",
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        File.WriteAllText(NomeFile, "CodiceFiscale;Cognome;Nome;Telefono;Email;Scadenza;Targa;Modello;InfoPolizza;Ramo;Polizza")
        MsgBox(String.Format("Il modello è stato creato sul desktop con il nome{0}'Modello invio sms.csv'",
                             Environment.NewLine), MsgBoxStyle.Information, Utx.Globale.TitoloApp)
    End Sub

    Private Sub ButtonSfoglia_Click(sender As Object, e As EventArgs) Handles ButtonSfoglia.Click
        Try
            Using cd As New OpenFileDialog
                cd.InitialDirectory = Utx.Globale.UtenteCorrente.Desktop
                cd.Filter = "File csv|*.csv"

                If cd.ShowDialog = Windows.Forms.DialogResult.OK Then

                    Using sr As New StreamReader(cd.FileName)
                        'controllo intestazione
                        If sr.ReadLine.ToLower.StartsWith("codicefiscale") Then

                            Dim dt As New DataTable
                            With dt.Columns
                                .Add("CodiceFiscale", Type.GetType("System.String"))
                                .Add("Cognome", Type.GetType("System.String"))
                                .Add("Nome", Type.GetType("System.String"))
                                .Add("Telefono", Type.GetType("System.String"))
                                .Add("Email", Type.GetType("System.String"))
                                .Add("Scadenza", Type.GetType("System.DateTime"))
                                .Add("Targa", Type.GetType("System.String"))
                                .Add("Modello", Type.GetType("System.String"))
                                .Add("InfoPolizza", Type.GetType("System.String"))
                                .Add("Ramo", Type.GetType("System.String"))
                                .Add("Polizza", Type.GetType("System.String"))
                            End With

                            Do While sr.EndOfStream = False
                                Dim Riga As String = sr.ReadLine

                                If String.IsNullOrEmpty(Riga.Split(";")(2)) = False Then
                                    Dim dr As DataRow = dt.NewRow()
                                    dr("CodiceFiscale") = Utx.FunzioniDb.NullToString(Riga.Split(";")(0))
                                    dr("Cognome") = Utx.FunzioniDb.NullToString(Riga.Split(";")(1))
                                    dr("Nome") = Utx.FunzioniDb.NullToString(Riga.Split(";")(2))
                                    dr("Telefono") = Utx.FunzioniDb.NullToString(Riga.Split(";")(3))
                                    dr("Email") = Utx.FunzioniDb.NullToString(Riga.Split(";")(4))
                                    If IsDate(Riga.Split(";")(5)) Then
                                        dr("Scadenza") = CDate(Riga.Split(";")(5))
                                    Else
                                        dr("Scadenza") = #1/1/1900#
                                    End If
                                    dr("Targa") = Utx.FunzioniDb.NullToString(Riga.Split(";")(6))
                                    dr("Modello") = Utx.FunzioniDb.NullToString(Riga.Split(";")(7))
                                    dr("InfoPolizza") = Utx.FunzioniDb.NullToString(Riga.Split(";")(8))
                                    dr("Ramo") = Utx.FunzioniDb.NullToString(Riga.Split(";")(9))
                                    dr("Polizza") = Utx.FunzioniDb.NullToString(Riga.Split(";")(10))

                                    dt.Rows.Add(dr)
                                End If
                            Loop
#If DEBUG Then
                            Dim deb As New Utx.FormDebug(dt)
                            deb.ShowDialog()
#End If
                            If dt.Rows.Count = 0 Then
                                MsgBox("Nessun destinatario inserito", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                            Else
                                Using f As New FormComunicazioni
                                    f.Destinatari = dt
                                    f.ShowDialog()
                                End Using
                            End If

                            DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()
                        Else
                            MsgBox("Il file non è nel formato previsto", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                        End If
                    End Using
                End If
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormRichiestaFile_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.AcceptButton = Nothing
        ButtonSfoglia.Focus()
    End Sub
End Class