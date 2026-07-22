Imports Anax

Public Class ucSintesi
    Private mCodiceFiscale As String
    Private mSql As Sql
    Private Const SelectZero As String = "NO_CF"

    Sub New()
        InitializeComponent()
        InizializzaControllo({Label1, Label2, Label9, Label13, Label14})
        InizializzaControllo({Label15}, Utx.AppFont.Bold)
        InizializzaControllo({CheckBoxRiepilogoArretrati, CheckBoxRiepilogoAvvisi, CheckBoxRiepilogoDatiAnagrafici, CheckBoxRiepilogoIncassi, CheckBoxRiepilogoPolizzeAuto, CheckBoxRiepilogoPolizzeRE, CheckBoxRiepilogoPolizzeVita,
                              CheckBoxRiepilogoSinistri, CheckBoxRiepilogoSelezionaTutto, CheckBoxCopertinaA3}, Utx.AppFont.Bold)
        InizializzaControllo({CheckBoxCopertinaCliente, CheckBoxCopertinaSituazione, CheckBoxCopertinaNote,
                              CheckBoxCopertinaFasiVendita, CheckBoxCopertinaAnalisiRca, CheckBoxCopertinaTutto})

        InizializzaControllo({cmbIncassi, cmbSinistri})
        InizializzaControllo({ButtonStampaScheda, ButtonEstrattoConto, ButtonStampaCopertina}, Utx.AppFont.Bold)
        ButtonStampaCopertina.Image = Risorse.Immagini.Image("pdf")

        LeggiSettings()

        cmbIncassi.Items.Add("TUTTI")
        cmbSinistri.Items.Add("TUTTI")
        For i As Integer = Today.Year To Today.Year - 5 Step -1
            cmbIncassi.Items.Add(i)
            cmbSinistri.Items.Add(i)
        Next
        cmbIncassi.SelectedIndex = 1
        cmbSinistri.SelectedIndex = 1

        Utx.NetFunc.DoppioBuffer(dgvTelefonate)

        AddHandler cmbIncassi.SelectedIndexChanged, AddressOf cmbIncassi_SelectedIndexChanged
        AddHandler cmbSinistri.SelectedIndexChanged, AddressOf cmbSinistri_SelectedIndexChanged
    End Sub

    Private Sub CheckBoxRiepilogoSelezionaTutto_CheckedChanged(sender As Object, e As EventArgs)
        CheckBoxRiepilogoArretrati.Checked = CheckBoxRiepilogoSelezionaTutto.Checked
        CheckBoxRiepilogoAvvisi.Checked = CheckBoxRiepilogoSelezionaTutto.Checked
        CheckBoxRiepilogoDatiAnagrafici.Checked = CheckBoxRiepilogoSelezionaTutto.Checked
        CheckBoxRiepilogoIncassi.Checked = CheckBoxRiepilogoSelezionaTutto.Checked
        CheckBoxRiepilogoPolizzeAuto.Checked = CheckBoxRiepilogoSelezionaTutto.Checked
        CheckBoxRiepilogoPolizzeRE.Checked = CheckBoxRiepilogoSelezionaTutto.Checked
        CheckBoxRiepilogoPolizzeVita.Checked = CheckBoxRiepilogoSelezionaTutto.Checked
        CheckBoxRiepilogoSinistri.Checked = CheckBoxRiepilogoSelezionaTutto.Checked
    End Sub

    Private Sub CheckBoxCopertinaSelezionaTutto_CheckedChanged(sender As Object, e As EventArgs)
        CheckBoxCopertinaA3.Checked = CheckBoxCopertinaTutto.Checked
        CheckBoxCopertinaCliente.Checked = CheckBoxCopertinaTutto.Checked
        CheckBoxCopertinaSituazione.Checked = CheckBoxCopertinaTutto.Checked
        CheckBoxCopertinaNote.Checked = CheckBoxCopertinaTutto.Checked
        CheckBoxCopertinaFasiVendita.Checked = CheckBoxCopertinaTutto.Checked
        CheckBoxCopertinaAnalisiRca.Checked = CheckBoxCopertinaTutto.Checked
    End Sub

    Public Sub CaricaValori(CodiceFiscale As String)
        Try
            mCodiceFiscale = CodiceFiscale

            'Dim th As New Threading.Thread(AddressOf CaricaTelefonate)
            'th.Start()

            mSql = New Sql(CodiceFiscale)
            With mSql
                SqlToValue(.NumeroFamiliari, LabelNumeroFamiliari)
                SqlToValue(.NumeroEntiAppartenenza, LabelNumeroEnti)

                SqlToLabel(.PolizzeAutoCliente, LabelPolizzeAutoCliente)
                SqlToLabel(.PolizzeAutoFamiliari, LabelPolizzeAutoFamiliari)
                SqlToLabel(.PolizzeAutoEnti, LabelPolizzeAutoEnti)

                SqlToLabel(.PolizzeRECliente, LabelPolizzeRECliente)
                SqlToLabel(.PolizzeREFamiliari, LabelPolizzeREFamiliari)
                SqlToLabel(.PolizzeREEnti, LabelPolizzeREEnti)

                SqlToLabel(.PolizzeVitaCliente, LabelPolizzeVitaCliente)
                SqlToLabel(.PolizzeVitaFamiliari, LabelPolizzeVitaFamiliari)
                SqlToLabel(.PolizzeVitaEnti, LabelPolizzeVitaEnti)

                SqlToLabel(.IncassiCliente(AnnoDaCombo(cmbIncassi)), LabelIncassiCliente)
                SqlToLabel(.IncassiFamiliari(AnnoDaCombo(cmbIncassi)), LabelIncassiFamiliari)
                SqlToLabel(.IncassiEnti(AnnoDaCombo(cmbIncassi)), LabelIncassiEnti)

                SqlToLabel(.ArretratiCliente, LabelArretratiCliente)
                SqlToLabel(.ArretratiFamiliari, LabelArretratiFamiliari)
                SqlToLabel(.ArretratiEnti, LabelArretratiEnti)

                SqlToLabel(.SinistriCliente(AnnoDaCombo(cmbSinistri)), LabelSinistriCliente)
                SqlToLabel(.SinistriFamiliari(AnnoDaCombo(cmbSinistri)), LabelSinistriFamiliari)
                SqlToLabel(.SinistriEnti(AnnoDaCombo(cmbSinistri)), LabelSinistriEnti)
            End With
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CaricaTelefonate()
        Try
            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy

                Dim ds As DataSet = s.TelefonateCF(Utx.EnteGestore.StringaCodiciGestiti, mCodiceFiscale)

                If ds IsNot Nothing Then
                    dgvTelefonate.DataSource = ds.Tables(0)
                    dgvTelefonate.Refresh()
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub

    Private Function AnnoDaCombo(combo As System.Windows.Forms.ComboBox) As Integer
        If combo.SelectedIndex > 0 Then
            Return combo.SelectedItem
        Else
            Return 0
        End If
    End Function


    Private Sub cmbIncassi_SelectedIndexChanged(sender As Object, e As EventArgs)
        cmbIncassi.Refresh()
        Dim anno As Integer = AnnoDaCombo(cmbIncassi)

        With mSql
            SqlToLabel(.IncassiCliente(anno), LabelIncassiCliente)
            SqlToLabel(.IncassiFamiliari(anno), LabelIncassiFamiliari)
            SqlToLabel(.IncassiEnti(anno), LabelIncassiEnti)
        End With
    End Sub

    Private Sub cmbSinistri_SelectedIndexChanged(sender As Object, e As EventArgs)
        cmbSinistri.Refresh()
        Dim anno As Integer = AnnoDaCombo(cmbSinistri)

        With mSql
            SqlToLabel(.SinistriCliente(anno), LabelSinistriCliente)
            SqlToLabel(.SinistriFamiliari(anno), LabelSinistriFamiliari)
            SqlToLabel(.SinistriEnti(anno), LabelSinistriEnti)
        End With
    End Sub

    Private Sub SqlToValue(sql As String, label As Windows.Forms.Label)
        label.Text = "... calcolo ..."
        label.Refresh()

        Dim testo As String = ""
        With Utx.FunzioniDb.CreaDataRow(sql)
            testo = .Item(0)
        End With

        label.Text = testo
        label.Refresh()
    End Sub

    Private Sub SqlToLabel(sql As String, label As Windows.Forms.Label)
        label.Text = "... calcolo ..."
        label.Font = Utx.AppFont.Bold
        label.Refresh()

        Dim testo As String = ""

        If sql = SelectZero Then
            testo = "0,00 (0)"
        Else
            With Utx.FunzioniDb.CreaDataRow(sql).ItemArray
                If IsDBNull(.GetValue(0)) Then
                    testo &= "0,00"
                Else
                    testo &= Utx.FunzioniFormato.FormatoEuro(.GetValue(0))
                End If

                testo &= " (" & .GetValue(1) & ")"
            End With
        End If

        label.Text = testo
        label.Font = Utx.AppFont.Normal
        label.Refresh()
    End Sub

    Private Class Sql
        Private ReadOnly mCodiceFiscale As String
        Private ReadOnly mAltriFamiliari As String()
        Private ReadOnly mAltriEnti As String()

        Sub New(codiceFiscale As String)
            Try
                mCodiceFiscale = codiceFiscale

                Dim AltriList As New List(Of String) 'From {"ABCDEFGHILMNPQRSTUVZ"}

                With Utx.FunzioniDb.CreaDataTableReader(AltriFamiliari)
                    While .Read
                        AltriList.Add(.Item(0))
                    End While
                    .Close()
                End With

                mAltriFamiliari = AltriList.ToArray()

                AltriList = New List(Of String) 'From {"ABCDEFGHILMNPQRSTUVZ"}

                With Utx.FunzioniDb.CreaDataTableReader(AltriEnti)
                    While .Read
                        AltriList.Add(.Item(0))
                    End While
                    .Close()
                End With

                mAltriEnti = AltriList.ToArray()
            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try
        End Sub

        Function AltriFamiliari() As String
            Return String.Format("SELECT C1.CodiceFiscale 
                FROM Clienti as C1 
                INNER JOIN Clienti as C2
                ON C1.CodiceFiscaleCF = C2.CodiceFiscaleCF
                WHERE C2.CodiceFiscale = '{0}'
                AND C1.CodiceFiscale <> C2.CodiceFiscale
                AND LEN(TRIM(C1.CodiceFiscaleCF)) > 0
                AND LEN(TRIM(C2.CodiceFiscaleCF)) > 0", mCodiceFiscale)
        End Function

        Function AltriEnti() As String
            Return String.Format("SELECT C1.CodiceFiscale 
                FROM Clienti as C1 
                INNER JOIN Clienti as C2
                ON C1.CodiceFiscaleEA = C2.CodiceFiscaleEA
                WHERE C2.CodiceFiscale = '{0}'
                AND C1.CodiceFiscale <> C2.CodiceFiscale
                AND LEN(TRIM(C1.CodiceFiscaleEA)) > 0
                AND LEN(TRIM(C2.CodiceFiscaleEA)) > 0", mCodiceFiscale)
        End Function

        Function NumeroFamiliari() As String
            Return String.Format("SELECT Count(*) 
                FROM Clienti as C1 
                INNER JOIN Clienti as C2
                ON C1.CodiceFiscaleCF = C2.CodiceFiscaleCF
                WHERE C2.CodiceFiscale = '{0}'
                AND LEN(TRIM(C1.CodiceFiscaleCF)) > 0
                AND LEN(TRIM(C2.CodiceFiscaleCF)) > 0", mCodiceFiscale)
        End Function

        Function NumeroEntiAppartenenza() As String
            Return String.Format("SELECT Count(*) 
                FROM Clienti as C1 
                INNER JOIN Clienti as C2
                ON C1.CodiceFiscaleEA = C2.CodiceFiscaleEA
                WHERE C2.CodiceFiscale = '{0}'
                AND LEN(TRIM(C1.CodiceFiscaleEA)) > 0
                AND LEN(TRIM(C2.CodiceFiscaleEA)) > 0", mCodiceFiscale)
        End Function

        Function PolizzeAutoCliente() As String
            Return PolizzeAuto({mCodiceFiscale})
        End Function

        Function PolizzeAutoFamiliari() As String
            Return PolizzeAuto(mAltriFamiliari)
        End Function

        Function PolizzeAutoEnti() As String
            Return PolizzeAuto(mAltriEnti)
        End Function

        Private Function PolizzeAuto(codicifiscali As String()) As String
            If codicifiscali.Length > 0 Then
                Return "SELECT SUM(TotalePremioAnnuo), Count(*) 
                    FROM Polizze
                    WHERE RamoGestione in (1, 2) AND CodiceFiscale IN (" & Utx.FunzioniDb.TO_STRING(codicifiscali) & ")"
            Else
                Return SelectZero
            End If
        End Function

        Function PolizzeRECliente() As String
            Return PolizzeRE({mCodiceFiscale})
        End Function

        Function PolizzeREFamiliari() As String
            Return PolizzeRE(mAltriFamiliari)
        End Function

        Function PolizzeREEnti() As String
            Return PolizzeRE(mAltriEnti)
        End Function

        Private Function PolizzeRE(codicifiscali As String()) As String
            If codicifiscali.Length > 0 Then
                Return "SELECT SUM(TotalePremioAnnuo), Count(*) FROM Polizze" &
                   " WHERE NOT RamoGestione IN (1, 2, 18, 19, 20)" &
                   "   AND CodiceFiscale IN (" & Utx.FunzioniDb.TO_STRING(codicifiscali) & ")"
            Else
                Return SelectZero
            End If
        End Function

        Function PolizzeVitaCliente() As String
            Return PolizzeVita({mCodiceFiscale})
        End Function

        Function PolizzeVitaFamiliari() As String
            Return PolizzeVita(mAltriFamiliari)
        End Function

        Function PolizzeVitaEnti() As String
            Return PolizzeVita(mAltriEnti)
        End Function

        Private Function PolizzeVita(codicifiscali As String()) As String
            If codicifiscali.Length > 0 Then
                Return "SELECT SUM(TotalePremioAnnuo), Count(*) FROM Polizze" &
                   " WHERE RamoGestione IN (18, 19, 20)" &
                   "   AND CodiceFiscale IN (" & Utx.FunzioniDb.TO_STRING(codicifiscali) & ")"
            Else
                Return SelectZero
            End If
        End Function

        Function IncassiCliente(anno As Integer) As String
            Return Incassi(anno, {mCodiceFiscale})
        End Function

        Function IncassiFamiliari(anno As Integer) As String
            Return Incassi(anno, mAltriFamiliari)
        End Function

        Function IncassiEnti(anno As Integer) As String
            Return Incassi(anno, mAltriEnti)
        End Function

        Private Function Incassi(anno As Integer, codicifiscali As String()) As String
            If codicifiscali.Length > 0 Then
                Dim sql As String =
                   "SELECT SUM(TotaleTitolo), Count(*) FROM Incassi" &
                   " WHERE CodiceFiscInc IN (" & Utx.FunzioniDb.TO_STRING(codicifiscali) & ")"
                If anno > 0 Then
                    sql &= " AND Year(DataFoglioCassa) = " & anno
                End If
                Return sql
            Else
                Return SelectZero
            End If
        End Function

        Function ArretratiCliente() As String
            Return Arretrati({mCodiceFiscale})
        End Function

        Function ArretratiFamiliari() As String
            Return Arretrati(mAltriFamiliari)
        End Function

        Function ArretratiEnti() As String
            Return Arretrati(mAltriEnti)
        End Function

        Private Function Arretrati(codicifiscali As String()) As String
            If codicifiscali.Length > 0 Then
                Return "SELECT SUM(TotaleTitolo), Count(*) FROM Arretrati" &
                   " WHERE CodiceFiscale IN (" & Utx.FunzioniDb.TO_STRING(codicifiscali) & ")"
            Else
                Return SelectZero
            End If
        End Function

        Function SinistriCliente(anno As Integer) As String
            Return Sinistri(anno, {mCodiceFiscale})
        End Function

        Function SinistriFamiliari(anno As Integer) As String
            Return Sinistri(anno, mAltriFamiliari)
        End Function

        Function SinistriEnti(anno As Integer) As String
            Return Sinistri(anno, mAltriEnti)
        End Function

        Private Function Sinistri(anno As Integer, codicifiscali As String()) As String
            If codicifiscali.Length > 0 Then
                Dim sql As String = "SELECT SUM(PagatoAl), COUNT(*) FROM SinistriDP
                WHERE CodiceFiscContrPol IN (" & Utx.FunzioniDb.TO_STRING(codicifiscali) & ")"
                If anno > 0 Then
                    sql &= " AND EsercizioSinistro = " & anno
                End If
                Return sql
            Else
                Return SelectZero
            End If
        End Function
    End Class

    Private Sub ButtonStampaCopertina_Click(sender As Object, e As EventArgs) Handles ButtonStampaCopertina.Click
        Dim Options As StampaOptions = StampaOptions.MostraAnteprima _
                                           - CheckBoxCopertinaA3.Checked * StampaOptions.StampaA3 _
                                           - CheckBoxCopertinaCliente.Checked * StampaOptions.StampaCliente _
                                           - CheckBoxCopertinaSituazione.Checked * StampaOptions.StampaSituazione _
                                           - CheckBoxCopertinaNote.Checked * StampaOptions.StampaNote _
                                           - CheckBoxCopertinaFasiVendita.Checked * StampaOptions.StampaFasiVendita _
                                           - CheckBoxCopertinaAnalisiRca.Checked * StampaOptions.StampaAnalisiRca

        Dim anagrafica As New Anagrafica
        anagrafica.Load(mCodiceFiscale)

        Dim stampa As New Copertina
        stampa.StampaMostraEtInvia(anagrafica, Options)
    End Sub

    Protected Sub LeggiSettings()
        RemoveHandler CheckBoxCopertinaTutto.CheckedChanged, AddressOf CheckBoxCopertinaSelezionaTutto_CheckedChanged

        CheckBoxCopertinaA3.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CopertinaA3, "1")
        CheckBoxCopertinaCliente.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CopertinaCliente, "1")
        CheckBoxCopertinaSituazione.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CopertinaSituazione, "1")
        CheckBoxCopertinaNote.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CopertinaNote, "1")
        CheckBoxCopertinaFasiVendita.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CopertinaFasiVendita, "1")
        CheckBoxCopertinaAnalisiRca.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CopertinaAnalisiRca, "1")
        CheckBoxCopertinaTutto.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CopertinaSelezionaTutto, "1")

        CheckBoxRiepilogoArretrati.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.RiepilogoArretrati, "1")
        CheckBoxRiepilogoAvvisi.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.RiepilogoAvvisi, "1")
        CheckBoxRiepilogoDatiAnagrafici.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.RiepilogoDatiAnagrafici, "1")
        CheckBoxRiepilogoIncassi.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.RiepilogoIncassi, "1")
        CheckBoxRiepilogoPolizzeAuto.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.RiepilogoPolizzeAuto, "1")
        CheckBoxRiepilogoPolizzeRE.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.RiepilogoPolizzeRE, "1")
        CheckBoxRiepilogoPolizzeVita.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.RiepilogoPolizzeVita, "1")
        CheckBoxRiepilogoSinistri.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.RiepilogoSinistri, "1")
        CheckBoxRiepilogoSelezionaTutto.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.RiepilogoSelezionaTutto, "1")

        AddHandler CheckBoxCopertinaTutto.CheckedChanged, AddressOf CheckBoxCopertinaSelezionaTutto_CheckedChanged
        AddHandler CheckBoxRiepilogoSelezionaTutto.CheckedChanged, AddressOf CheckBoxRiepilogoSelezionaTutto_CheckedChanged
    End Sub

    Protected Sub SalvaSettings()
        AggiungiModifica("CopertinaA3", CheckBoxCopertinaA3.Checked)
        AggiungiModifica("CopertinaCliente", CheckBoxCopertinaCliente.Checked)
        AggiungiModifica("CopertinaSituazione", CheckBoxCopertinaSituazione.Checked)
        AggiungiModifica("CopertinaNote", CheckBoxCopertinaNote.Checked)
        AggiungiModifica("CopertinaFasiVendita", CheckBoxCopertinaFasiVendita.Checked)
        AggiungiModifica("CopertinaAnalisiRca", CheckBoxCopertinaAnalisiRca.Checked)
        AggiungiModifica("CopertinaSelezionaTutto", CheckBoxCopertinaTutto.Checked)

        AggiungiModifica("RiepilogoArretrati", CheckBoxRiepilogoArretrati.Checked)
        AggiungiModifica("RiepilogoAvvisi", CheckBoxRiepilogoAvvisi.Checked)
        AggiungiModifica("RiepilogoDatiAnagrafici", CheckBoxRiepilogoDatiAnagrafici.Checked)
        AggiungiModifica("RiepilogoIncassi", CheckBoxRiepilogoIncassi.Checked)
        AggiungiModifica("RiepilogoPolizzeAuto", CheckBoxRiepilogoPolizzeAuto.Checked)
        AggiungiModifica("RiepilogoPolizzeRE", CheckBoxRiepilogoPolizzeRE.Checked)
        AggiungiModifica("RiepilogoPolizzeVita", CheckBoxRiepilogoPolizzeVita.Checked)
        AggiungiModifica("RiepilogoSinistri", CheckBoxRiepilogoSinistri.Checked)
        AggiungiModifica("RiepilogoSelezionaTutto", CheckBoxRiepilogoSelezionaTutto.Checked)
    End Sub

    Private Sub AggiungiModifica(Chiave As String, Valore As Boolean)
        Utx.Globale.SettingUtente.AggiungiModifica(Chiave, IIf(Valore, "1", "0"))
    End Sub

    Private Sub ButtonStampaScheda_Click(sender As Object, e As EventArgs) Handles ButtonStampaScheda.Click
        Try
            Dim Options As EstrattoConto.sezioniEnum =
                            -CheckBoxRiepilogoDatiAnagrafici.Checked * EstrattoConto.sezioniEnum.SezioneDatiAnagrafici _
                            - CheckBoxRiepilogoPolizzeAuto.Checked * EstrattoConto.sezioniEnum.SezionePolizzeAuto _
                            - CheckBoxRiepilogoPolizzeRE.Checked * EstrattoConto.sezioniEnum.SezionePolizzeRe _
                            - CheckBoxRiepilogoPolizzeVita.Checked * EstrattoConto.sezioniEnum.SezionePolizzeVita _
                            - CheckBoxRiepilogoIncassi.Checked * EstrattoConto.sezioniEnum.SezioneIncassi _
                            - CheckBoxRiepilogoArretrati.Checked * EstrattoConto.sezioniEnum.SezioneArretrati _
                            - CheckBoxRiepilogoSinistri.Checked * EstrattoConto.sezioniEnum.SezioneSinistri _
                            - CheckBoxRiepilogoAvvisi.Checked * EstrattoConto.sezioniEnum.SezioneAvvisi

            Using Anteprima As New UtControls.FormAnteprima
                Dim estrattoConto = New EstrattoConto(mCodiceFiscale)
                Dim filehtml = estrattoConto.StampaSintesi(Options, AnnoDaCombo(cmbIncassi), AnnoDaCombo(cmbSinistri))

                Anteprima.NomeFile = filehtml
                Anteprima.ShowDialog()

                'cancello il file di anteprima
                IO.File.Delete(Anteprima.NomeFile)
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonEstrattoConto_Click(sender As Object, e As EventArgs) Handles ButtonEstrattoConto.Click
        Try
            Dim AnnoIncassi As Integer = AnnoDaCombo(cmbIncassi)

            Dim Query As String = String.Format("SELECT C.CodiceFiscale,TRIM(C.Cognome) + ' ' + TRIM(C.Nome) AS Cliente,C.Indirizzo,C.Localita,
                C.Cap,C.Provincia,Format(I.Ramo,'000') + '/' + FORMAT(I.Polizza,'000000000')  AS NumeroPolizza,
                IIF(TRIM(I.Targa) > '', I.Targa, LOWER(TR.Ramo)) AS TipoPolizza,I.Frazionamento,I.DataEffettoTitolo,I.DataFoglioCassa,
                I.DataScadenzaTitolo,I.ImportoIncassato + I.CanoneBox AS Pagato,I.SSN
                FROM Incassi AS I
                LEFT JOIN Clienti AS C 
                ON I.CodiceFiscInc = C.CodiceFiscale
                LEFT JOIN [TipoRami] AS TR 
                ON I.Ramo = TR.CodiceRamo
                WHERE (I.ImportoIncassato + I.CanoneBox <> 0) AND CodiceFiscInc = '{0}'", mCodiceFiscale.Trim)
            If annoIncassi > 0 Then
                Query &= " AND Year(I.DataFoglioCassa) = " & AnnoIncassi
            End If
            Query &= " ORDER BY DataFoglioCassa"

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            If dt.Rows.Count > 0 Then
                Dim Report As New Utx.PaginaHtml(String.Format("Incassi_{0}_{1}", mCodiceFiscale.Trim, cmbIncassi.Text))
                Dim ColoreSfondo As String = "#EEEEEE"
                With Report
                    .Titolo = "Premi pagati"
                    .Size = Utx.PaginaHtml.TextSize.x_large
                    .AddHtml("<div style=""font-family:Calibri;font-size: medium"">")
                    .AddHtml("<table>")
                    .AddHtml("<tr><td colspan=7 style=""text-align: left""><p>&nbsp</p></td></tr>", 3)

                    'cliente
                    .AddHtml("<tr style=""font-weight: bold"">")
                    .AddHtml("<td>&nbsp</td>", 4)
                    .AddHtml(String.Format("<td colspan=4 style=""text-align: left""><p>{0}<br>{1}<br>{2} {3} {4}</p></td>",
                                           dt.Rows(0).Item("Cliente").ToString.Trim,
                                           dt.Rows(0).Item("Indirizzo").ToString.Trim,
                                           dt.Rows(0).Item("Cap"),
                                           dt.Rows(0).Item("Localita").ToString.Trim,
                                           dt.Rows(0).Item("Provincia")))
                    .AddHtml("</tr>")
                    .AddHtml("<tr><td colspan=8 style=""text-align: left""><p>&nbsp</p></td></tr>", 4)

                    'oggetto
                    .AddHtml("<tr style=""font-weight: bold"">")
                    .AddHtml(String.Format("<td colspan=8 style=""text-align: left""><p>Oggetto: Polizze pagate nel periodo {0} - CF: {1}</p></td>", cmbIncassi.Text, dt.Rows(0).Item("CodiceFiscale").ToString.Trim))
                    .AddHtml("</tr>")
                    .AddHtml("<tr><td colspan=8 style=""text-align: left""><p>&nbsp</p></td></tr>")
                    .AddHtml("<tr><td colspan=8 style=""text-align: left""><p>Gentile cliente,</p></td></tr>")
                    .AddHtml(String.Format("<tr><td colspan=8 style=""text-align: left""><p>come da sua cortese richiesta, le inviamo la presente quale certificazione " &
                                           "dei pagamenti da lei effettuati presso questa agenzia nel corso dell’anno {0} a saldo delle seguenti scadenze di premio:<br><br></p></td></tr>", cmbIncassi.Text))

                    'riga intestazione
                    .AddHtml("<tr bgcolor=""#sfondo#"" style=""font-weight: bold"">")
                    .AddHtml("<td style=""text-align: left""><p>Data pagamento</p></td>")
                    .AddHtml("<td style=""text-align: center""><p>Data effetto</p></td>")
                    .AddHtml("<td style=""text-align: center""><p>Data scadenza</p></td>")
                    .AddHtml("<td style=""text-align: center""><p>Polizza</p></td>")
                    .AddHtml("<td style=""text-align: center""><p>Fraz</p></td>")
                    .AddHtml("<td style=""text-align: center""><p>Importo pagato</p></td>")
                    .AddHtml("<td style=""text-align: center""><p>di cui SSN</p></td>")
                    .AddHtml("<td style=""text-align: left""><p>Tipo polizza</p></td>")
                    .AddHtml("</tr>")
                    '.AddHtml("<tr><td colspan=8><hr style=""height: 1px;"" /></td></tr>")

                    Dim ImportoTotale As Double = 0
                    Dim SsnTotale As Double = 0
                    For Each r As DataRow In dt.Rows
                        .AddHtml("<tr>")
                        .AddHtml(String.Format("<td style=""text-align: left""><p>{0:d}</p></td>", r("DataFoglioCassa")))
                        .AddHtml(String.Format("<td style=""text-align: center""><p>{0:d}</p></td>", r("DataEffettoTitolo")))
                        .AddHtml(String.Format("<td style=""text-align: center""><p>{0:d}</p></td>", r("DataScadenzaTitolo")))
                        .AddHtml(String.Format("<td style=""text-align: center""><p>{0}</p></td>", r("NumeroPolizza")))
                        .AddHtml(String.Format("<td style=""text-align: center""><p>{0}</p></td>", r("Frazionamento")))
                        .AddHtml(String.Format("<td style=""text-align: right; font-weight: bold""><p>{0}</p></td>", Format(r("Pagato"), "###,##0.00")))
                        If r("SSN") = 0 Then
                            .AddHtml("<td style=""text-align: center; font-weight: bold""><p>-</p></td>")
                        Else
                            .AddHtml(String.Format("<td style=""text-align: right; font-weight: bold""><p>{0}</p></td>", Format(r("SSN"), "###,##0.00")))
                        End If
                        .AddHtml(String.Format("<td style=""text-align: left""><p>{0}</p></td>", r("TipoPolizza").ToString.ToUpper))
                        .AddHtml("</tr>")

                        ImportoTotale += r("Pagato")
                        SsnTotale += r("SSN")
                    Next
                    '.AddHtml("<tr><td colspan=8><hr style=""height: 1px;"" /></td></tr>")

                    'totali
                    .AddHtml("<tr bgcolor=""#sfondo#"" style=""font-weight: bold"">")
                    .AddHtml("<td colspan=5 style=""text-align: right""><p>Totale nel periodo</p></td>")
                    .AddHtml(String.Format("<td bgcolor=""#sfondo#"" style=""text-align: right""><p>{0}</p></td>", Format(ImportoTotale, "###,##0.00")))
                    .AddHtml(String.Format("<td bgcolor=""#sfondo#"" style=""text-align: right""><p>{0}</p></td>", Format(SsnTotale, "###,##0.00")))
                    .AddHtml("<td></td>")
                    .AddHtml("</tr>")
                    'saluti
                    .AddHtml("<tr><td colspan=7 style=""text-align: left""><p>Ringraziandola per la preferenza accordataci rimaniamo a sua disposizione per qualunque chiarimento.<br>Cordiali saluti.</p></td></tr>")

                    'data
                    .AddHtml(String.Format("<tr><td colspan=7 style=""text-align: left""><p><i><br>Stampato il {0:d}</i></p></td></tr>", Today))

                    .AddHtml("</table>")
                    .AddHtml("</div>")

                    .Sostituisci("#sfondo#", ColoreSfondo)

                    .CreaFileHtml()
                End With

                Using Anteprima As New UtControls.FormAnteprima
                    Anteprima.ControlloBottoni()
                    Anteprima.NomeFile = Report.NomeFile
                    Anteprima.ShowDialog()
                    'cancello il file di anteprima
                    IO.File.Delete(Anteprima.NomeFile)
                End Using
            Else
                MsgBox("Non risultano incassi nel periodo richiesto.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
