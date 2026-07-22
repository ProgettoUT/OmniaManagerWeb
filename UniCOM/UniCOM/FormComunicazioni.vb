Imports System.IO

Public Class FormComunicazioni

    Private Notifica As Utx.FormNotifica
    Private ReadOnly Tip As New ToolTip
    Private ReadOnly Sms As New UniCom.Sms
    Public MessaggiInviati As Boolean = False

    Private Enum Campi
        Cognome
        Nome
        Scadenza
        Targa
        Modello
        InfoPolizza
        Ramo
        Polizza
    End Enum

    Public Enum TipoChiamata
        ESTRATTORE = 0
        EVIDENZE = 1
    End Enum

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Font = Utx.AppFont.Normal
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(750, 450)
        Me.MinimumSize = New Size(750, 300)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.ShowInTaskbar = True
        Me.Icon = Risorse.Immagini.Icon("comunica")
        Me.Text = "Invia comunicazioni"
    End Sub

    Private mChiamata As TipoChiamata = TipoChiamata.ESTRATTORE
    Public Property Chiamata() As TipoChiamata
        Get
            Return mChiamata
        End Get
        Set(value As TipoChiamata)
            mChiamata = value
        End Set
    End Property

    Private mDestinatari As DataTable
    Public Property Destinatari() As DataTable
        Get
            Return mDestinatari
        End Get
        Set(value As DataTable)
            mDestinatari = value
        End Set
    End Property

    Private Sub ImpostaControlli()
        With ComboBoxCampi
            .DropDownStyle = ComboBoxStyle.DropDownList

            If Chiamata = TipoChiamata.ESTRATTORE Then
                For Each c As String In System.Enum.GetNames(GetType(Campi))
                    .Items.Add(c)
                Next
            Else
                For Each col As DataColumn In mDestinatari.Columns
                    .Items.Add(col.ColumnName)
                Next
            End If
            .SelectedIndex = 0
        End With
        With TextBoxMittente
            .BackColor = Color.DodgerBlue
            .ForeColor = Color.White
            .Font = Utx.AppFont.Extra(11, FontStyle.Bold)
            .TextAlign = HorizontalAlignment.Center
            .Text = Sms.AutoSender()
        End With
        With TextBoxMessaggio
            .MaxLength = 160
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
        End With
        ButtonApri.Text = "Apri"
        ButtonSalva.Text = "Salva"
        ButtonInvia.Text = "Invia gli SMS"
        With ButtonEsci
            .Image = Risorse.Immagini.Bitmap("esci")
            .Text = ""
        End With
        LabelCaratteriUtilizzati.Text = 0
        LabelCaratteriResidui.Text = 160
        LabelNumeroSms.Text = 0
        Tip.SetToolTip(LabelCaratteriUtilizzati, "caratteri utilizzati")
        Tip.SetToolTip(LabelCaratteriResidui, "caratteri residui")
        Tip.SetToolTip(LabelNumeroSms, "numero sms")
    End Sub

    Private Sub FormSms_Load(sender As Object, e As EventArgs) Handles Me.Load
        ImpostaControlli()
#If DEBUG Then
        ConfiguraSessioneDebug()
#End If
    End Sub

    Private Sub FormSms_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LabelNumeroDestinatari.Text = String.Format("Questo messaggio verrà inviato a {0} destinatari", DestinatariSmsCount())
        Me.TopMost = True
        Me.Refresh()
        TextBoxMessaggio.Focus()
    End Sub

    Private Function DestinatariSms() As DataRow()
        Return Destinatari.Select("Trim(Telefono) <> ''")
    End Function

    Private Function DestinatariEmail() As DataRow()
        Return Destinatari.Select("Trim(Email) <> ''")
    End Function

    Private Function DestinatariSmsCount() As Integer
        Return Me.DestinatariSms.Length
    End Function

    Private Function DestinatariEmailCount() As Integer
        Return Me.DestinatariEmail.Length
    End Function

    Private Sub InviaSmsLista()
        Try
            Globale.Log.Info("Inizio procedura di invio SMS a lista di distribuzione")

            Notifica = New Utx.FormNotifica()
            With Notifica
                .Opacity = 0.9
                .ColoreSfondo = Color.PaleGreen

                .Show()

                .Messaggio = "Invio sms in corso..."
            End With

            'imposta il messaggio e il testo del messaggio
            Globale.Log.Info("Imposto il messaggio")

            Dim Msg As New UniCom.MessaggioSms With {.Testo = TextBoxMessaggio.Text}

            'imposto i token e invio
            Globale.Log.Info("Imposto la lista dei destinatari")

            'se la lista dei destinatari non è vuota
            If Me.DestinatariSmsCount > 0 Then
                Sms.Compagnia = Utx.Globale.ProfiloEnteGestore.Compagnia
                Sms.Messaggio = Msg

                Dim TokenUtilizzati As List(Of String) = TagUtilizzati()

                For Each dr As DataRow In DestinatariSms()
                    Dim Destinatario As New UniCom.Destinatario(dr("Cognome"), dr("Nome"), dr("Telefono"))
                    'passo le corrispondenze dei token
                    Destinatario.AddTokens(dr, TokenUtilizzati)

                    Sms.AddDestinatario(Destinatario)
                Next

                Notifica.Messaggio = "Verifico la disponibilità di credito"
                Globale.Log.Info("Verifico la disponibilità di credito")

                Dim Credito As String = Sms.CreditoSubaccount()
#If DEBUG Then
                Sms.Esito.EsitoChiamata = True 'per test
#End If

                If Sms.Esito.EsitoChiamata = True Then
                    'conto i messaggi sostituendo i token
                    Dim NumeroMessaggi As Integer = Sms.ContaMessaggi

                    'se ho credito sufficiente procedo con l'invio
                    If NumeroMessaggi <= Credito Then
                        'imposto il mittente
                        Sms.AutoSender(TextBoxMittente.Text)

#If DEBUG Then
                        Sms.AutoSender(Demo:=True)
                        'Sms.UsaAccountTest = True
#End If

                        Globale.Log.Info("Procedo con l'invio")

                        'memorizzo il numero destinatari perché dopo l'invio la lista viene svuotata
                        Dim NumeroDestinatari As Integer = Sms.NumeroDestinatari

                        Globale.Log.Info("destinatari {0}", {NumeroDestinatari})

                        'procedo con l'invio
                        Sms.Invia()
                        MessaggiInviati = Sms.Esito.EsitoChiamata

                        'esito invio
                        If Sms.Esito.EsitoChiamata = True Then
                            Globale.Log.Info(String.Format("Inviati {0} SMS. Invio completato con successo!",
                                                       NumeroDestinatari))

                            Notifica.Messaggio = String.Format("Inviati {1} sms.{0}Invio completato con successo!",
                                                           Environment.NewLine,
                                                           NumeroDestinatari)
                        Else
                            Globale.Log.Info(Sms.Esito.MessaggioErrore)
                            Notifica.ColoreSfondo = Color.Orange
                            Notifica.Messaggio = Sms.Esito.MessaggioErrore
                        End If
                    Else
                        Globale.Log.Info("Credito insufficiente")
                        Notifica.ColoreSfondo = Color.Orange
                        Notifica.Messaggio = String.Format("Credito insufficiente.{0}Numero destinatari: {1}{0}" +
                                                           "Numero SMS (da 160 caratteri) richiesti: {2}{0}" +
                                                           "Credito disponibile {3} SMS.",
                                                           Environment.NewLine,
                                                           Sms.NumeroDestinatari,
                                                           NumeroMessaggi,
                                                           Credito)
                        Globale.Log.Info(Notifica.Messaggio)
                    End If
                Else
                    Globale.Log.Info(Sms.Esito.MessaggioErrore)
                    Notifica.ColoreSfondo = Color.Orange
                    Notifica.Messaggio = Sms.Esito.MessaggioErrore
                End If
            Else
                Notifica.ColoreSfondo = Color.Orange
                Notifica.Messaggio = "La lista dei destinatari è vuota."
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Notifica.ColoreSfondo = Color.Orange
            Notifica.Messaggio = "Errore: invio annullato"
        Finally
            Notifica.Chiudi()
        End Try
    End Sub

    Private Function TagUtilizzati() As List(Of String)
        Dim Lista As New List(Of String)
        Try
            Dim Testo As String = TextBoxMessaggio.Text.ToLower
            For Each i As String In ComboBoxCampi.Items
                If Testo.Contains("#" & i.ToLower & "#") Then
                    Lista.Add(i.ToLower)
                End If
            Next
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
        Return Lista
    End Function

    Private Sub ConfiguraSessioneDebug()
        Try
            If Destinatari Is Nothing Then
                MsgBox("DEBUG: Non ci sono destinatari e aggiungo Guido Lampo")
                'creo la tabella con i campi che mi servono
                mDestinatari = New DataTable
                With mDestinatari.Columns
                    .Add("Cognome", Type.GetType("System.String"))
                    .Add("Nome", Type.GetType("System.String"))
                    .Add("Telefono", Type.GetType("System.String"))
                    .Add("Scadenza", Type.GetType("System.DateTime"))
                    .Add("Targa", Type.GetType("System.String"))
                    .Add("Modello", Type.GetType("System.String"))
                End With

                Dim dr As DataRow = mDestinatari.NewRow
                dr("Cognome") = "Lampo"
                dr("Nome") = "Guido"
                dr("Telefono") = "3397842745"
                dr("Scadenza") = #9/1/2016#
                dr("Targa") = "AK77005"
                dr("Modello") = "Vespa"

                mDestinatari.Rows.Add(dr)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonInvia_Click(sender As Object, e As EventArgs) Handles ButtonInvia.Click
        If TextBoxMessaggio.Text.Trim.Length = 0 Then
            MsgBox("Impostare prima il testo del messaggio", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
        Else
            If MsgBox(String.Format("Confermate l'invio dei messaggi a {0} destinatari?", DestinatariSmsCount),
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                InviaSmsLista()
            End If
        End If
    End Sub

    Private Sub CheckBoxConcatenati_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxConcatenati.CheckedChanged
        If CheckBoxConcatenati.Checked = False Then
            If TextBoxMessaggio.TextLength > 160 OrElse TagUtilizzati.Count > 0 Then
                If MsgBox("Il messaggio potrebbe essere tagliato a 160 caratteri. Continuare?",
                          MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2,
                          Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then

                    TextBoxMessaggio.Text = TextBoxMessaggio.Text.Substring(0, 160)
                    TextBoxMessaggio.MaxLength = 160
                Else
                    CheckBoxConcatenati.Checked = True
                End If
            Else
                TextBoxMessaggio.MaxLength = 160
            End If
        Else
            TextBoxMessaggio.MaxLength = 1500
        End If
        CaratteriUtilizzati()
    End Sub

    Private Sub TextBoxMessaggio_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMessaggio.TextChanged
        If CheckBoxAnteprima.Checked = False Then
            TextBoxMessaggio.Tag = TextBoxMessaggio.Text.Trim
        End If
        CaratteriUtilizzati()
    End Sub

    Private Sub CaratteriUtilizzati()
        Try
            'caratteri residui. Messaggio.MaxLength conserva il valore dei caratteri utilizzabili
            LabelCaratteriUtilizzati.Text = MessaggioSms.NumeroCaratteriUtilizzati(TextBoxMessaggio.Text)

            'If Utilizzati > Messaggio.MaxLength Then
            '    Messaggio = Left$(Messaggio, Len(Messaggio) - 1)
            '    Utilizzati = CaratteriUtilizzati(Messaggio.Text)
            'End If

            LabelCaratteriResidui.Text = TextBoxMessaggio.MaxLength - LabelCaratteriUtilizzati.Text

            'If Residui > 0 Then
            '    Residui.BackColor = Glo.VerdeChiaro
            'Else
            '    Residui.BackColor = vbRed
            'End If

            'numero messaggi utilizzati
            Select Case LabelCaratteriUtilizzati.Text
                Case 0
                    LabelNumeroSms.Text = 0
                Case Is < 161
                    LabelNumeroSms.Text = 1
                Case Else
                    LabelNumeroSms.Text = Int(LabelCaratteriUtilizzati.Text / 153 + 0.999)
            End Select

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            LabelCaratteriUtilizzati.Text = 0
            LabelCaratteriResidui.Text = 0
            LabelNumeroSms.Text = 0
        End Try
    End Sub

    Private Sub CheckBoxAnteprima_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAnteprima.CheckedChanged
        If CheckBoxAnteprima.Checked = True Then
            If Destinatari.Rows.Count = 0 Then
                MsgBox("E' necessario avere una lista di destinatari per visualizzare l'anteprima.",
                       MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                CheckBoxAnteprima.Checked = False
            Else
                CreaAnteprima()
                CheckBoxAnteprima.BackColor = Color.PaleGreen
                TextBoxMessaggio.ReadOnly = True
                TextBoxMessaggio.BackColor = Color.Gainsboro
            End If
        Else
            CheckBoxAnteprima.BackColor = Color.Transparent
            TextBoxMessaggio.ReadOnly = False
            TextBoxMessaggio.BackColor = SystemColors.Window
            TextBoxMessaggio.Text = TextBoxMessaggio.Tag
        End If
        CheckBoxConcatenati.Enabled = Not CheckBoxAnteprima.Checked
        ButtonApri.Enabled = Not CheckBoxAnteprima.Checked
        ButtonSalva.Enabled = Not CheckBoxAnteprima.Checked
        ButtonInvia.Enabled = Not CheckBoxAnteprima.Checked
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub ButtonInserisciCampo_Click(sender As Object, e As EventArgs) Handles ButtonInserisciCampo.Click
        Dim InsertPos As Integer = TextBoxMessaggio.SelectionStart
        Dim Inserttext As String = "#" + ComboBoxCampi.Text.ToLower + "#"
        TextBoxMessaggio.Text = TextBoxMessaggio.Text.Insert(InsertPos, Inserttext)
        TextBoxMessaggio.SelectionStart = InsertPos + Inserttext.Length
        CheckBoxConcatenati.Checked = True
        TextBoxMessaggio.Focus()
    End Sub

    Private Sub ComboBoxCampi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCampi.SelectedIndexChanged
        TextBoxMessaggio.Focus()
    End Sub

    Private Sub CreaAnteprima()
        Try
            Dim temp As String = TextBoxMessaggio.Tag

            Dim Colonne As New List(Of String)
            For Each col As DataColumn In Destinatari.Columns
                Colonne.Add(col.ColumnName.ToLower)
            Next

            'procede alle sostituzioni
            For Each c As String In ComboBoxCampi.Items
                If Colonne.Contains(c.ToLower) Then
                    If Destinatari.Columns(c).DataType Is System.Type.GetType("System.DateTime") Then
                        temp = Replace(temp, "#" + c.ToLower + "#", Format(Destinatari.Rows(0).Item(c), "dd-MM-yyyy"), Compare:=CompareMethod.Text)
                    Else
                        temp = Replace(temp, "#" + c.ToLower + "#", Destinatari.Rows(0).Item(c).ToString.Trim, Compare:=CompareMethod.Text)
                    End If
                End If
            Next

            TextBoxMessaggio.Text = temp

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonApri_Click(sender As Object, e As EventArgs) Handles ButtonApri.Click
        Using cd As New OpenFileDialog
            cd.InitialDirectory = Utx.Globale.Paths.CartellaSms
            cd.Filter = "File messaggio (*.msgsms)|*.msgsms"

            If cd.ShowDialog = Windows.Forms.DialogResult.OK Then
                TextBoxMessaggio.Text = File.ReadAllText(cd.FileName)
            End If
        End Using
    End Sub

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click
        Using cd As New SaveFileDialog
            cd.InitialDirectory = Utx.Globale.Paths.CartellaSms
            cd.Filter = "File messaggio (*.msgsms)|*.msgsms"
            cd.OverwritePrompt = True

            If cd.ShowDialog = Windows.Forms.DialogResult.OK Then
                File.WriteAllText(cd.FileName, TextBoxMessaggio.Text)
            End If
        End Using
    End Sub
End Class