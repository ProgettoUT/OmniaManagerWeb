Public Class FormLicenza

    Friend EsitoRichiesta As RichiestaEmmedi
    Friend StatoUniarea As AbilitazioneAgenzia

    Friend Enum RichiestaEmmedi
        OK = 0
        ANNULLATA = 1
        ERRORE = 2
    End Enum

    Private Sub FormLicenza_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Me.Text = "Richiesta licenza"

            With LabelDesk
                .Image = My.Resources.licence
                .ImageAlign = ContentAlignment.MiddleRight
                .Text = "Con questa procedura è possibile attivare la licenza per l'uso del programma di scansione e abbinamento degli assegni agli incassi"
                .TextAlign = ContentAlignment.MiddleLeft
            End With

            LabelCodiceAgenzia.Text = StatoUniarea.Agenzia
            LabelUtente.Text = Utx.Globale.UtenteCorrente.UniageUser
            TextBoxRagioneSociale.Text = StatoUniarea.Esito.RagioneSociale
            TextBoxEmail.Text = StatoUniarea.Esito.Email

            RadioButtonFino20.Checked = True

            With ButtonInviaRichiesta
                .Padding = New Padding(10, 0, 10, 0)
                .Text = "Invia richiesta"
                .TextAlign = ContentAlignment.MiddleRight
                .Image = My.Resources.upload.ToBitmap
                .ImageAlign = ContentAlignment.MiddleLeft
            End With
            With ButtonAnnulla
                .Padding = New Padding(10, 0, 10, 0)
                .Text = "Annulla"
                .TextAlign = ContentAlignment.MiddleRight
                .Image = My.Resources.Esci.ToBitmap
                .ImageAlign = ContentAlignment.MiddleLeft
            End With

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Globale.Log.Info("Richiesta licenza annullata dall'utente")
        EsitoRichiesta = RichiestaEmmedi.ANNULLATA
        Me.Close()
    End Sub

    Private Sub ButtonInviaRichiesta_Click(sender As Object, e As EventArgs) Handles ButtonInviaRichiesta.Click
        Try
            If TextBoxRagioneSociale.Text.Trim.Length = 0 Then
                MsgBox("Inserire la ragione sociale del titolare del mandato", MsgBoxStyle.Exclamation)
                TextBoxRagioneSociale.Focus()
                Exit Sub
            End If
            If ValidEmail(TextBoxEmail.Text, False, True) = False Then
                TextBoxEmail.Focus()
                Exit Sub
            End If

            Dim TipoAgenzia As String

            If RadioButtonFino20.Checked = True Then
                TipoAgenzia = "UNIARE20"
            Else
                TipoAgenzia = "UNIAREFU"
            End If

            Using Licenza As New LicenzeEmmedi.Ws4ChequeRequestWebService

                Licenza.Proxy = Utx.Globale.UniProxy.Proxy
                Licenza.Timeout = 10000

                Dim Esito As Integer = Licenza.RequestLicense(LabelCodiceAgenzia.Text,
                                                              TipoAgenzia,
                                                              "0",
                                                              (Today.Day + Today.Month + Today.Year).ToString,
                                                              LabelCodiceAgenzia.Text,
                                                              TextBoxRagioneSociale.Text,
                                                              LabelUtente.Text,
                                                              "0", "0", "0", "0",
                                                              TextBoxEmail.Text)

                Select Case Esito
                    Case 1
                        Globale.Log.Info("Licenza Emmedi attivata correttamente")
                        EsitoRichiesta = RichiestaEmmedi.OK

                    Case Else
                        Globale.Log.Info(String.Format("Errore licenza Emmedi. Esito richiesta {0}", Esito))
                        EsitoRichiesta = RichiestaEmmedi.ERRORE
                End Select
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            EsitoRichiesta = RichiestaEmmedi.ERRORE
        End Try

        Me.Close()
    End Sub

    Private Function ValidEmail(ByVal Indirizzo As String,
                                ByVal ValidaVuota As Boolean,
                                ByVal VisualizzaMessaggio As Boolean) As Boolean
        ValidEmail = False

        'controllo validità e-mail
        Try
            Indirizzo = Indirizzo.Trim

            'controllo se stringa vuota
            If (String.IsNullOrEmpty(Indirizzo)) AndAlso (ValidaVuota = False) Then Return False

            'posizione del carattere '@'
            Dim i As Integer = Indirizzo.IndexOf("@")

            'almeno 1 carattere PRIMA di '@'
            If i <= 1 Then Return False

            'testo che precede '@'
            Dim Prima As String = Indirizzo.Substring(0, i)
            'testo che segue '@'
            Dim Dopo As String = Indirizzo.Substring(i + 1)

            'posizione dell'ultimo carattere '.'
            i = Dopo.LastIndexOf(".")

            'punto necessario
            If i < 0 Then Return False

            'e almeno 1 carattere DOPO '@' e PRIMA dell'ultimo '.'
            If Dopo.Substring(0, i).Length < 1 Then Return False

            'suffisso finale è lungo da 2 a 4 caratteri
            If Dopo.Substring(i + 1).Length < 2 OrElse Dopo.Substring(i + 1).Length > 4 Then Return False

            'Controlla i caratteri escluso '@' i caratteri leciti sono [a-zA-Z0-9_.-']
            Dim exp As New System.Text.RegularExpressions.Regex("[a-zA-Z0-9_.-]")

            Dim Tutto As String = Prima + Dopo

            For k As Integer = 0 To Tutto.Length - 1
                'indirizzo non valido se un carattere NON viene trovato fra i leciti
                If Not exp.IsMatch(Tutto.Substring(k, 1)) Then Return False
            Next

            ValidEmail = True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False

        Finally
            If ValidEmail = False AndAlso VisualizzaMessaggio = True Then
                MsgBox(String.Format("L'indirizzo e-mail '{0}' non è un indirizzo valido.",
                                     Indirizzo), MsgBoxStyle.Exclamation, "Richiesta licenza")
            End If
        End Try

    End Function

End Class