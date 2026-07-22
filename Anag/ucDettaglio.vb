Imports System.Windows.Forms
Imports Utx.FunzioniDb
Imports iTextSharp.text.pdf
Imports System.IO

Public Class ucDettaglio
    'controlo contenente s/p e altri parametri
    'Me.tlpBase.Controls.Add(Me.GroupBox8, 2, 2)
    Private CodiceFiscale As String
    Private DepositoFullPathCliente As String

    Public Event ClienteChanged(nome As String, indirizzo As String)
    Public Event CodiceFiscaleChanged(CodiceFiscale As String)
    Public Event RichiestaMappa()
    Public Event RichiestaScansione()

    Public Sub New()
        InitializeComponent()
        impostaControlli()
    End Sub

    Private Sub impostaControlli()
        Me.Dock = Windows.Forms.DockStyle.Fill

        'groupbox
        InizializzaControllo({labelGroup1, labelGroup2, labelGroup3, labelGroup4, labelGroup5, labelGroup7, labelGroup8, labelGroup9})

        'dati generali
        InizializzaControllo({labelNominativo, labelIndirizzo, labelCapLocalita, labelCodiceFiscale, labelStatoCliente, labelDataNascita, labelComuneNascita, labelSesso})
        InizializzaControllo(cmdMappa)

        'contatti essig
        InizializzaControllo({labelTelefono1, labelTelefono2, labelCellulare, labelEmail})
        InizializzaControllo(buttonCellulare, , "invia sms")
        InizializzaControllo(cmdEmail, , "invia e-mail")
        ButtonScan.Image = Risorse.Immagini.Bitmap("scandoc")
        'Rapporto sinistri/premi
        'InizializzaControllo({labelLiquidatoTotale, labelPremiTotali, labelRapportoSP})

        'Dati assicurativi
        InizializzaControllo({labelDataInserimento, labelSubagenziaProduttore, labelClienteTop, labelAvvisoScadenza, labelProfessione, labelMercato, LabelPrivacy})
        'nascondo S/P
        GroupBox8.Visible = False
    End Sub

    Public Sub SelezionaCliente(CodiceFiscale As String)
        Try
            If Me.CodiceFiscale = CodiceFiscale Then Exit Sub

            Me.CodiceFiscale = CodiceFiscale
            Dim deposito As New UnitoolsDocumenti.DepositoPratica(CodiceFiscale)
            DepositoFullPathCliente = deposito.FullPathCliente

            Dim CodiceFiscaleCF As String = Nothing
            Dim CodiceFiscaleEA As String = Nothing

            If CodiceFiscale.Length > 0 Then
                Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(ClienteSql(CodiceFiscale))

                If Risposta.DataTable.Rows.Count > 0 Then
                    Dim dr As DataRow = Risposta.DataTable.Rows(0) 'c'è solo una riga
                    'DATI GENERALI
                    labelNominativo.Text = NullToValue(dr("Nominativo"))
                    labelIndirizzo.Text = NullToValue(dr("Indirizzo"))
                    labelCapLocalita.Text = New Anax.Indirizzo(Nothing, NullToValue(dr("Cap")), NullToValue(dr("Localita")), NullToValue(dr("Provincia"))).ToString
                    labelCodiceFiscale.Text = NullToValue(dr("CodiceFiscale"))
                    labelStatoCliente.Text = NullToValue(dr("StatoCliente"))
                    labelDataNascita.Text = NullToValue(dr("DataNascita"))
                    labelComuneNascita.Text = NullToValue(dr("IDComuneNascita")) &
                        IIf(NullToValue(dr("ComuneNascita")) IsNot Nothing, " - " & dr("ComuneNascita"), "") &
                        IIf(NullToValue(dr("ProvinciaNascita")) IsNot Nothing, " (" & dr("ProvinciaNascita") & ")", "")
                    labelSesso.Text = NullToValue(dr("Sesso"))

                    'contatti essig
                    labelTelefono1.Text = NullToValue(dr("Telefono1"))
                    labelTelefono2.Text = NullToValue(dr("Telefono2"))

                    labelCellulare.Text = NullToValue(dr("Cellulare"))
                    labelCellulare.Tag = labelCellulare.Text
                    buttonCellulare.Tag = labelCellulare.Text
                    buttonCellulare.Enabled = (labelCellulare.Text.Length > 0)

                    labelEmail.Text = NullToValue(dr("Email"))
                    labelEmail.Tag = labelEmail.Text
                    cmdEmail.Tag = labelEmail.Text
                    cmdEmail.Enabled = (labelEmail.Text.Length > 0)

                    labelDataInserimento.Text = NullToValue(dr("DataInserimento"))
                    labelSubagenziaProduttore.Text = NullToValue(dr("Subagenzia")) & "-" & NullToValue(dr("Produttore"))
                    labelClienteTop.Text = NullToValue(dr("ClienteTop"))
                    labelAvvisoScadenza.Text = NullToValue(dr("AvvisoScadenza"))
                    labelProfessione.Text = NullToValue(dr("Professione"))
                    labelMercato.Text = NullToValue(dr("Mercato"))
                    LabelPrivacy.Text = Utx.Essig.DecodificaPrivacy(NullToValue(dr("ConsensoPrivacy")))
                    LabelDataFEA.Text = NullToValue(dr("DataAutorizzazioneFEA"))

                    CodiceFiscaleCF = NullToValue(dr("CodiceFiscaleCF"))
                    CodiceFiscaleEA = NullToValue(dr("CodiceFiscaleEA"))

                    RaiseEvent ClienteChanged(NullToValue(dr("Nominativo")), New Anax.Indirizzo(NullToValue(dr("Indirizzo")), NullToValue(dr("Cap")), NullToValue(dr("Localita")), NullToValue(dr("Provincia"))).ToString)
                End If
            End If

            'FAMILIARI
            If CodiceFiscaleCF Is Nothing OrElse CodiceFiscaleCF = "" Then
                dgvFamiglia.DataSource = Nothing
            Else
                dgvFamiglia.DataSource = Utx.WsCommand.ExecuteNonQuery(NucleoFamiliareSql(CodiceFiscaleCF)).DataTable
                dgvFamiglia.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
            dgvFamiglia.Refresh()

            'ENTI DI APPARTENENZA
            If CodiceFiscaleEA Is Nothing OrElse CodiceFiscaleEA = "" Then
                dgvEnte.DataSource = Nothing
            Else
                dgvEnte.DataSource = Utx.WsCommand.ExecuteNonQuery(EnteAppartenenzaSql(CodiceFiscaleEA)).DataTable
                dgvEnte.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
            dgvEnte.Refresh()

            'DOCUMENTI
            ImpostaDocumenti()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Function ClienteSql(CodiceFiscale As String) As String
        Dim sql As New System.Text.StringBuilder
        sql.Append("SELECT")
        sql.Append(" TRIM(C.Cognome) + ' ' + TRIM(C.Nome) AS Nominativo")
        sql.Append(" , C.indirizzo")
        sql.Append(" , C.Cap")
        sql.Append(" , C.Localita")
        sql.Append(" , C.Provincia")
        sql.Append(" , C.CodiceFiscale")
        sql.Append(" , C.IDStatoCliente + IIF(TSC.StatoCliente IS NULL,'', ' - ' + TSC.StatoCliente) AS StatoCliente")
        sql.Append(" , C.DataNascita")
        sql.Append(" , C.Sesso")
        sql.Append(" , SUBSTRING(C.CodiceFiscale, 12, 4) AS IDComuneNascita")
        sql.Append(" , L.Comune AS ComuneNascita")
        sql.Append(" , L.Provincia AS ProvinciaNascita")
        sql.Append(" , C.Telefono1")
        sql.Append(" , C.Telefono2")
        sql.Append(" , C.Cellulare")
        sql.Append(" , C.Email")
        sql.Append(" , C.LiquidatoTotale")
        sql.Append(" , C.PremiTotale")
        sql.Append(" , C.AutorizzazioneFEA")
        sql.Append(" , C.DataAutorizzazioneFEA")

        sql.Append(" , C.DataInserimento")
        sql.Append(" , C.Subagenzia")
        sql.Append(" , C.Produttore")
        sql.Append(" , C.ClienteTop")
        sql.Append(" , C.CodAvvisoScadenza AS AvvisoScadenza")
        sql.Append(" , STR(C.TipoCliente/100) + ' - ' + P.Professione AS Professione")
        sql.Append(" , STR(C.TipoCliente % 100) + ' - ' + MP.SegmentoMercato AS mercato")
        sql.Append(" , C.ConsensoPrivacy")

        sql.Append(" , C.RisTelefono")
        sql.Append(" , C.RisTelefonoNota")
        sql.Append(" , C.RisCellulare")
        sql.Append(" , C.RisCellulareNota")
        sql.Append(" , C.RisMail")
        sql.Append(" , C.RisMailNota")

        sql.Append(" , C.CodiceFiscaleCF")
        sql.Append(" , C.CodiceFiscaleEA")

        sql.Append(" FROM Clienti AS C")
        sql.Append(" LEFT JOIN DB00000.dbo.Comuni AS L ON SUBSTRING(C.CodiceFiscale, 12, 4) = L.IDComune")
        sql.Append(" LEFT JOIN DB00000.dbo.TipoStatiCliente AS TSC ON C.IDStatoCliente = TSC.IDStatoCliente")
        sql.Append(" LEFT JOIN DB00000.dbo.Professioni AS P ON (C.TipoCliente/100) = P.IdProfessione")
        sql.Append(" LEFT JOIN DB00000.dbo.MercatoPreferenziale AS MP ON (C.TipoCliente % 100) = MP.Codice")
        sql.AppendFormat(" WHERE CodiceFiscale ={0}", TO_STRING(CodiceFiscale))

        Return sql.ToString
    End Function

    Public Function NucleoFamiliareSql(CodiceFiscaleCF As String) As String
        Return String.Format("SELECT
            CodiceFiscale as [Codice fiscale], TRIM(Cognome) + ' ' + TRIM(Nome) AS Nome, IIF(Capofamiglia='S', 'Si', '') AS CF, 
            DataNascita AS [Nato il]
            FROM Clienti
            WHERE CodiceFiscaleCF ='{0}'
            ORDER BY 3 DESC,  DataNascita DESC", CodiceFiscaleCF)
    End Function

    Public Function EnteAppartenenzaSql(CodiceFiscaleEA As String) As String
        Return String.Format("SELECT CodiceFiscale AS [Codice fiscale], TRIM(Cognome) + ' ' + TRIM(Nome) AS Nome, 
            IIF(CodiceFiscaleEA = CodiceFiscale, 'Si', '') AS Ente, DataNascita AS [Nato il]
            FROM Clienti
            WHERE CodiceFiscaleEA = '{0}'
            ORDER BY 3 DESC, Cognome,Nome DESC", CodiceFiscaleEA)
    End Function

    Private Sub labelCellulare_Click(sender As Object, e As EventArgs) Handles labelCellulare.LinkClicked,
                                                                               labelTelefono1.LinkClicked,
                                                                               labelTelefono2.LinkClicked
        chiamaConCentralino(sender.Text)
    End Sub

    Private Sub cmdCellulare_Click(sender As Object, e As EventArgs) Handles buttonCellulare.Click
        InviaMessaggio(labelCellulare.Text, UniCom.FormMail.TipoMessaggio.Sms)
    End Sub

    Private Sub cmdEmail_Click(sender As Object, e As EventArgs) Handles cmdEmail.Click, labelEmail.LinkClicked
        InviaMessaggio(labelEmail.Text, UniCom.FormMail.TipoMessaggio.Email)
    End Sub

    Private Sub dgvNucleoFamiliare_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFamiglia.CellDoubleClick, dgvEnte.CellDoubleClick
        'SelezionaCliente(CType(sender, DataGridView).Rows(e.RowIndex).Cells(0).Value)
        RaiseEvent CodiceFiscaleChanged(CType(sender, DataGridView).Rows(e.RowIndex).Cells(0).Value)
    End Sub


    Private Sub ButtonAltriContatti_Click(sender As Object, e As EventArgs) Handles ButtonAltriContatti.Click, ButtonAltriDati.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New Anax.frmAnag
        f.SelezionaCliente(CodiceFiscale)
        Me.Cursor = Cursors.Default

        f.ShowDialog(Me)
    End Sub

    Private Sub dgvDocumenti_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocumenti.CellDoubleClick
        Process.Start(IO.Path.Combine(DepositoFullPathCliente, dgvDocumenti.Rows(e.RowIndex).Cells(e.ColumnIndex).Value))
    End Sub

    Friend Sub InviaMessaggio(Destinatario As String,
                              TipoMessaggio As UniCom.FormMail.TipoMessaggio)
        Try
            Dim f As New UniCom.FormMail
            'tipo messaggio
            f.Messaggio = TipoMessaggio
            'pratica
            f.IdPratica = CodiceFiscale
            f.CodiceFiscale = CodiceFiscale
            f.NomeCliente = labelNominativo.Text
            'aggiungo destinatario
            Select Case TipoMessaggio
                Case UniCom.FormMail.TipoMessaggio.Email
                    f.AddDestinatarioEmail(UniCom.FormMail.TipoDestinatarioMail.A, Destinatario)
                Case UniCom.FormMail.TipoMessaggio.Sms
                    f.AddDestinatarioSms(Destinatario)
            End Select

            f.Show()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Sub chiamaConCentralino(numero As String)
        Centralino.Servizi.Chiama(numero)
    End Sub

    Private Sub cmdMappa_Click(sender As Object, e As EventArgs) Handles cmdMappa.Click
        RaiseEvent RichiestaMappa()
    End Sub

    Private Sub lblPrivacyCompagnia_Click(sender As Object, e As EventArgs) Handles lblPrivacyCompagnia.Click
        If String.IsNullOrEmpty(sender.tag) = False Then
            Process.Start(sender.tag)
        End If
    End Sub

    Private Sub ucDettaglio_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler lblPrivacyAgenzia.Click, AddressOf lblPrivacyCompagnia_Click
        AddHandler lblPrivacyEUAgenzia.Click, AddressOf lblPrivacyCompagnia_Click
        AddHandler lblPrivacyEUCompagnia.Click, AddressOf lblPrivacyCompagnia_Click
    End Sub

    Private Function CreaPrivacyPdf() As String
        '1) controllo se esiste il modello
        If Not IO.File.Exists(ModelloPrivacyPath) Then
            '2) se non esiste, apro la finestra di selezione del file
            Dim f As New ModelloPrivacy
            f.ShowDialog(Me)
            If Not IO.File.Exists(ModelloPrivacyPath) Then
                Return Nothing
            End If
        End If
        '3) se esiste, creo la copia personalizzata (21 marzo 18: commentato perchè non piace a guido)
        'Dim FilesInFolder As Integer = Directory.GetFiles(Utx.Globale.Paths.CartellaTempUtente, CodiceFiscale & ".privacy.*.pdf").GetLength(0)
        'Dim newFile As String = IO.Path.Combine(Utx.Globale.Paths.CartellaTempUtente, CodiceFiscale & ".privacy." & FilesInFolder & ".pdf")

        Dim newFile As String = IO.Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "privacy.pdf")
        Dim reader As New PdfReader(ModelloPrivacyPath)
        Dim size = reader.GetPageSizeWithRotation(1)
        Dim document = New iTextSharp.text.Document(size)

        Dim fs = New FileStream(newFile, FileMode.Create, FileAccess.Write)
        Dim writer = PdfWriter.GetInstance(document, fs)
        document.Open()

        Dim cb As PdfContentByte = writer.DirectContent

        'select the font properties
        Dim bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
        'cb.SetColorFill(BaseColor.DARK_GRAY)
        cb.SetFontAndSize(bf, 11)

        ' write the text in the pdf content
        cb.BeginText()
        cb.ShowTextAligned(0, labelNominativo.Text, 65, 755, 0)
        cb.EndText()
        cb.BeginText()
        cb.ShowTextAligned(0, CodiceFiscale, 400, 755, 0)
        cb.EndText()
        cb.BeginText()
        cb.ShowTextAligned(0, String.Format("nato il {0}", labelDataNascita.Text), 65, 738, 0)
        cb.EndText()
        cb.AddTemplate(writer.GetImportedPage(reader, 1), 0, 0)

        '// create the new page and add it to the pdf
        For i As Integer = 2 To reader.NumberOfPages
            document.NewPage()
            cb.AddTemplate(writer.GetImportedPage(reader, i), 0, 0)
        Next

        ' close the streams and voilá the file should be changed :)
        document.Close()
        fs.Close()
        writer.Close()
        reader.Close()

        '4) invio il pdf alla stampa, o in anteprima
        Return newFile
    End Function

    Private Sub ButtonSelezionaModelloPrivacy_Click(sender As Object, e As EventArgs) Handles ButtonSelezionaModelloPrivacy.Click
        Try
            Dim Doc As String = CreaPrivacyPdf()
            If Doc IsNot Nothing Then
                'visualizzo il pdf
                Process.Start(Doc)
            End If
        Catch exx As IOException
            'precedente privacy ancora aperta
            MsgBox("E' probabilmente aperto il documento privacy di un altro cliente. Chiudere il file precedente e riprovare.", MsgBoxStyle.Information)
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonModello_Click(sender As Object, e As EventArgs) Handles ButtonModello.Click
        Dim f As New ModelloPrivacy
        f.ShowDialog(Me)
    End Sub

    Private Sub ButtonScan_Click(sender As Object, e As EventArgs) Handles ButtonScan.Click
        RaiseEvent RichiestaScansione()
    End Sub

    Public Sub ImpostaDocumenti()
        Try
            lblPrivacyAgenzia.Tag = ""
            lblPrivacyCompagnia.Tag = ""
            lblPrivacyEUAgenzia.Tag = ""
            lblPrivacyEUCompagnia.Tag = ""

            If IO.Directory.Exists(DepositoFullPathCliente) Then
                Dim files() As String = IO.Directory.GetFiles(DepositoFullPathCliente)
                If files.Length = 0 Then
                    dgvDocumenti.DataSource = Nothing
                Else
                    Dim dt As New DataTable()
                    dt.Columns.Add(New DataColumn("Documento"))
                    For Each file In files
                        Dim filename As String = IO.Path.GetFileName(file)
                        dt.Rows.Add(filename)

                        'tag privacy
                        If filename.StartsWith("Privacy Agenzia EU") Then
                            lblPrivacyEUAgenzia.Tag = file
                            lblPrivacyEUAgenzia.Text = String.Format("Europea {0}", Path.GetFileNameWithoutExtension(file).Substring(19, 1))
                        ElseIf filename.StartsWith("Privacy Agenzia") Then
                            lblPrivacyAgenzia.Tag = file
                            lblPrivacyAgenzia.Text = "Standard"
                        ElseIf filename.StartsWith("Privacy Compagnia Omnibus") Then
                            lblPrivacyEUCompagnia.Tag = file
                            lblPrivacyEUCompagnia.Text = "Omnibus"
                        ElseIf filename.StartsWith("Privacy Compagnia EU 1-2") Then
                            lblPrivacyEUCompagnia.Tag = file
                            lblPrivacyEUCompagnia.Text = "Europea 1-2"
                        ElseIf filename.StartsWith("Privacy Compagnia") Then
                            lblPrivacyCompagnia.Tag = file
                            lblPrivacyCompagnia.Text = "Standard"
                        End If
                    Next
                    dgvDocumenti.DataSource = dt
                    dgvDocumenti.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            End If

            If String.IsNullOrEmpty(lblPrivacyCompagnia.Tag) Then
                lblPrivacyCompagnia.Image = Risorse.Immagini.Bitmap("cancel16_2")
            Else
                lblPrivacyCompagnia.Image = Risorse.Immagini.Bitmap("ok16")
            End If
            If String.IsNullOrEmpty(lblPrivacyAgenzia.Tag) Then
                lblPrivacyAgenzia.Image = Risorse.Immagini.Bitmap("cancel16_2")
            Else
                lblPrivacyAgenzia.Image = Risorse.Immagini.Bitmap("ok16")
            End If
            If String.IsNullOrEmpty(lblPrivacyEUAgenzia.Tag) Then
                lblPrivacyEUAgenzia.Image = Risorse.Immagini.Bitmap("cancel16_2")
            Else
                lblPrivacyEUAgenzia.Image = Risorse.Immagini.Bitmap("ok16")
            End If
            If String.IsNullOrEmpty(lblPrivacyEUCompagnia.Tag) Then
                lblPrivacyEUCompagnia.Image = Risorse.Immagini.Bitmap("cancel16_2")
            Else
                lblPrivacyEUCompagnia.Image = Risorse.Immagini.Bitmap("ok16")
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonStampa_Click(sender As Object, e As EventArgs) Handles ButtonStampa.Click
        Try
            Dim Doc As String = CreaPrivacyPdf()
            If Doc IsNot Nothing Then
                'stampo il pdf
                Using p As New Process
                    p.StartInfo.Verb = "print"
                    p.StartInfo.FileName = Doc
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    p.StartInfo.UseShellExecute = True
                    p.Start()
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
