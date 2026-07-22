Imports System.IO

Public Class FormProfiloEnte

    Public Profilo As Utx.EnteGestore

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal
        Me.Text = "Registrazione profilo agenzia"
        Me.Icon = Risorse.Immagini.Icon("aua")

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()

        With PictureBoxLogo
            .Margin = New Padding(0)
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.White
            .Image = Risorse.Immagini.Image("logo_splash")
            .SizeMode = PictureBoxSizeMode.CenterImage
        End With

        With ComboBoxCompagnia
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Items.Add("UnipolSai")
            .SelectedIndex = 0
        End With

        If Utx.FunzioniRete.ReteAttiva = True Then
            TextBoxCodiceAgenzia.ReadOnly = True
            TextBoxCodiceAgenzia.Text = Utx.FunzioniAmbiente.PcToAgenzia
            TextBoxCodiceSede.Text = Utx.FunzioniAmbiente.PcToSede
        Else
            TextBoxCodiceAgenzia.Text = ""
            TextBoxCodiceSede.Text = "00"
        End If

        'blocco il codice sede sempre
        TextBoxCodiceSede.ReadOnly = True

        TextBoxLocalita.Text = ""
        TextBoxIndirizzo.Text = ""
        TextBoxCap.Text = ""

        'combo capoluogo
        With ComboBoxCapoluogo
            .DropDownStyle = ComboBoxStyle.DropDownList

            .Items.Add("scegli...")
            .Items.Add("Capoluogo di prov.")
            .Items.Add("Non capoluogo")

            .SelectedIndex = 0
        End With

        'riempi combo provincie
        ImpostaComboProvince()

        With ButtonSalva
            .Padding = New Padding(20, 0, 20, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gray
            .Image = Risorse.Immagini.Bitmap("salva")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Salva profilo e avvia Unitools"
            .TextAlign = ContentAlignment.MiddleRight
        End With

        With LabelGuida
            .ForeColor = Color.DimGray
            .Text = "1. Accettare il contratto di licenza in basso a destra" + Environment.NewLine +
                    "2. Compilare tutti i campi richiesti" + Environment.NewLine +
                    "3. Salvare i dati per avviare Unitools"
        End With

        wbLicenza.Navigate("http://www.utools.it/Unitools/Doc/LicenzaUT.htm")

        With CheckBoxAccettaLicenza
            .Font = Utx.AppFont.Bold
            .Text = "Accetto il contratto di licenza"
            .Checked = False
        End With

        tlpDati.Enabled = False
    End Sub

    Private Sub ImpostaComboProvince()
        Try
            Dim Query As String = "SELECT Provincia,Sigla,Regione FROM DB00000.dbo.Province ORDER BY Provincia"
            Dim Province As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            'aggiungo la prima riga
            Dim p As DataRow = Province.NewRow
            p("Provincia") = "Provincia..."
            p("Sigla") = "NN"
            p("Regione") = 0

            Province.Rows.InsertAt(p, 0)

            With ComboBoxProvincia
                .DropDownStyle = ComboBoxStyle.DropDownList
                .DataSource = Province
                .DisplayMember = "Provincia"
                .SelectedIndex = 0
            End With

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CheckBoxAccettaLicenza_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAccettaLicenza.CheckedChanged
        tlpDati.Enabled = CheckBoxAccettaLicenza.Checked
        TextBoxCodiceAgenzia.Focus()
    End Sub

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click
        Try
            If ControlloDati() = False Then
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            ButtonSalva.Enabled = False

            Dim Md5 As String = Utx.NetFunc.StringToMD5(String.Format("Utx.{0}-{1}.UT",
                                                                               Profilo.AgenziaMadre,
                                                                               Profilo.CodiceSede))

            With Profilo
                .Compagnia = ComboBoxCompagnia.SelectedIndex + 1
                .AgenziaMadre = TextBoxCodiceAgenzia.Text.PadLeft(5, "0")
                .CodiceSede = TextBoxCodiceSede.Text
                .Localita = TextBoxLocalita.Text
                .Indirizzo = TextBoxIndirizzo.Text
                .Cap = TextBoxCap.Text
                .Provincia = ComboBoxProvincia.SelectedItem("Sigla")
                .Capoluogo = IIf(ComboBoxCapoluogo.SelectedIndex = 1, "S", "N")
                .Regione = ComboBoxProvincia.SelectedItem("Regione")
                .NumeroSerie = Microsoft.VisualBasic.Left(Md5, 12)
                .CodiceUtente = Microsoft.VisualBasic.Right(Md5, 10)

                .SalvaProfiloUtente()
            End With

            If Profilo.Esiste = True Then

                'registra l'accettazione della licenza nel db sul server utools.it
                'frmMain.Inet1.OpenURL(StringFormat("www.utools.it/asp/Licenze/RegistraLicenza.asp?" + _
                '                                    "Agenzia={0}&Sede={1}&Citta={2}&Pc={3}&User={4}", _
                '                                    Array(Utente.CodAgenzia, Utente.Sede, Left$(Utente.Citta, 40), _
                '                                          RilevaNomePC, RilevaUserName)))

                'controllo agenzia bloccata
                'Abilitazioni Utente.CodAgenzia

                'solo per i PC propri perchè su quelli di direzione il controllo viene fatto
                'prima e il programma non arriva qui ma viene chiuso prima
                'If Glo.Abilitazioni.Unitools = False Then
                '    MsgBox("Agenzia non abilitata all'uso del programma Unitools." + vbNewLine + _
                '           "Per informazioni contattare il Consorzio Uniarea.", vbInformation)

                '    End
                'End If

                Me.Close()
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            ButtonSalva.Enabled = True
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Function ControlloDati() As Boolean

        Try
            ControlloDati = True

            If TextBoxCodiceAgenzia.Text.Trim.Length = 0 OrElse
               TextBoxCodiceSede.Text.Trim.Length = 0 OrElse
               TextBoxLocalita.Text.Trim.Length = 0 OrElse
               TextBoxCap.Text.Trim.Length <> 5 OrElse
               TextBoxIndirizzo.Text.Trim.Length = 0 Then

                ControlloDati = False
            End If

            If ComboBoxProvincia.SelectedIndex = 0 Then
                ControlloDati = False
            End If
            If ComboBoxCapoluogo.SelectedIndex = 0 Then
                ControlloDati = False
            End If

            If ControlloDati = False Then
                MsgBox("E' necessario inserire correttamente tutti i dati prima di continuare.",
                       MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try

    End Function

    Private Sub FormProfiloEnte_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.TopMost = True
    End Sub
End Class