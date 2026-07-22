
Public Class frmInserimento

    Public Agenzia As String
    Public FigureProduttive As List(Of FiguraProduttiva)
    Public Property DataAnalisi

    Friend FigureModificate As New ArrayList

    Private BudgetAgenzia As BudgetFigura
    Private BudgetCodice As BudgetFigura
    Private Rami As New InsiemeRamiGestione
    Private Comparti As New InsiemeComparti
    Private cPerc As New Collection
    Private Const Formato As String = "###,###,##0.00"

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Size = New Size(930, 720)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        tlpBudget.Font = Me.Font

        btnEsci.Image = Risorse.Immagini.Bitmap("esci")
        btnAnnulla.Image = Risorse.Immagini.Bitmap("esci")

        ImpostaRG()
        ImpostaComparti()
        ImpostaPercentuali()
        ImpostaAnni()

        With LabelHelp
            .Margin = New Padding(3)
            .Padding = New Padding(10)
            .BackColor = Color.Gainsboro
            .BorderStyle = BorderStyle.Fixed3D
            .Text = String.Format("Si può inserire il budget per singolo ramo gestione oppure per comparto.{0}{0}" +
                                  "Per inserire il budget per comparto, sovrascrivere l'importo visualizzato e tale importo verrà proporzionalmente suddiviso per ogni singolo ramo gestione.{0}{0}" +
                                  "E' comunque sempre possibile effettuare correzioni manuali per ogni singolo ramo gestione.",
                                  Environment.NewLine)
            .TextAlign = ContentAlignment.MiddleLeft
        End With
    End Sub

    Private Sub frmInserimento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = String.Format("Inserimento budget incassi - Codice {0}", Agenzia)
        ImpostaFigure()
        gbImporti.Enabled = False
    End Sub

    Private Sub LeggiBudget()
        Try
            Me.Cursor = Cursors.WaitCursor

            SganciaEventiRG()
            SganciaEventiCom()

            'leggo il budget totale dell'agenzia. figura=0
            If BudgetAgenzia Is Nothing OrElse BudgetAgenzia.Anno <> cboAnno.Text Then
                BudgetAgenzia = New BudgetFigura(0, cboAnno.Text)
            End If

            'e ora il budget della figura selezionata
            If FiguraSelezionata() = 0 Then
                BudgetCodice = BudgetAgenzia
            Else
                BudgetCodice = New BudgetFigura(FiguraSelezionata(), cboAnno.Text)
            End If

            For Each rg As Integer In Globale.ElencoRamiGestione
                Rami.Controllo(rg).Importo = BudgetCodice.BudgetRamo(rg)
            Next

            AgganciaEventiRG()
            AgganciaEventiCom()

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnModifica_Click(sender As System.Object, e As System.EventArgs) Handles btnModifica.Click

        LeggiBudget()
        CalcolaTotali()

        gbImporti.Enabled = True
        gbFigura.Enabled = False
        btnEsci.Enabled = False

        'cambio la descrizione al bottone di calcolo
        If FiguraSelezionata() = 0 Then
            btnCalcolaBudget.Text = String.Format("Riporto saldo{0}anno precedente", Environment.NewLine)
        Else
            btnCalcolaBudget.Text = "Calcola budget"
        End If

        TextBoxRG1.Focus()
    End Sub

    Private Sub gbImporti_Leave(sender As Object, e As System.EventArgs) Handles gbImporti.Leave
        gbFigura.Enabled = True
        btnEsci.Enabled = True
    End Sub

    Private Sub btnSalva_Click(sender As System.Object, e As System.EventArgs) Handles btnSalva.Click

        SganciaEventiRG()
        SganciaEventiCom()

        'scrivo i dati della figura modificata/anno
        FigureModificate.Add({FiguraSelezionata(), cboAnno.Text})
        'salva i dati
        BudgetCodice.SalvaBudget()

        BudgetCodice = Nothing

        gbFigura.Enabled = True
        gbImporti.Enabled = False
        cboAnno.Focus()
    End Sub

    Private Sub btnEsci_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Private Sub CalcolaTotali()

        SganciaEventiCom()

        Try
            'calcola percentuale
            For Each rg As Integer In Globale.ElencoRamiGestione

                If cPerc.Contains(rg.ToString) Then

                    Dim br As Double = BudgetAgenzia.BudgetRamo(rg)
                    Dim bc As Double = BudgetCodice.BudgetRamo(rg)

                    If br > 0 Then
                        cPerc.Item(rg.ToString).Text = Format((bc / br) * 100, "##0.0")
                    Else
                        cPerc.Item(rg.ToString).Text = 0
                    End If
                End If
            Next

        Catch ex As Exception
            Log.Errore(ex)
        End Try

        Try
            'comparti
            TextBoxComparto1.Importo = BudgetCodice.TotaleComparto(Utx.Enumerazioni.Comparti.AUTO)
            TextBoxComparto2.Importo = BudgetCodice.TotaleComparto(Utx.Enumerazioni.Comparti.RP)
            TextBoxComparto3.Importo = BudgetCodice.TotaleComparto(Utx.Enumerazioni.Comparti.SALUTE)
            TextBoxComparto4.Importo = BudgetCodice.TotaleComparto(Utx.Enumerazioni.Comparti.AZIENDE)
            TextBoxComparto5.Importo = BudgetCodice.TotaleComparto(Utx.Enumerazioni.Comparti.RCG)
            TextBoxComparto6.Importo = BudgetCodice.TotaleComparto(Utx.Enumerazioni.Comparti.ALTRIRAMI)
            TextBoxComparto7.Importo = BudgetCodice.TotaleComparto(Utx.Enumerazioni.Comparti.VITA)
            'settori
            txtSet1.Text = Format(BudgetCodice.TotaleSettore(Utx.Enumerazioni.Settori.AUTO), Formato)
            txtSet2.Text = Format(BudgetCodice.TotaleSettore(Utx.Enumerazioni.Settori.RE), Formato)
            txtSet3.Text = Format(BudgetCodice.TotaleSettore(Utx.Enumerazioni.Settori.VITA), Formato)
            'aggregati
            txtAgg1.Text = Format(BudgetCodice.TotaleAggregato(Utx.Enumerazioni.Aggregati.DANNI), Formato)
            txtAgg2.Text = Format(BudgetCodice.TotaleAggregato(Utx.Enumerazioni.Aggregati.VITA), Formato)
            'generale
            txtGenerale.Text = Format(BudgetCodice.TotaleGenerale, Formato)

        Catch ex As Exception
            Log.Errore(ex)
        End Try

        AgganciaEventiCom()
    End Sub

    Private Sub ImpostaFigure()
        Try
            With cboFigura
                .DataSource = FigureProduttive
                .DisplayMember = "DescrizioneEstesa"
                .SelectedIndex = 0
            End With

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub ImpostaAnni()
        Try
            'riempie il combo con gli anni
            cboAnno.Items.Clear()

            For k As Integer = AnnoInizioIncassi() To Year(Now)
                cboAnno.Items.Add(k)
            Next

            cboAnno.SelectedIndex = cboAnno.Items.Count - 1

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub ImpostaRG()
        Rami.Add(1, TextBoxRG1)
        Rami.Add(2, TextBoxRG2)
        Rami.Add(3, TextBoxRG3)
        Rami.Add(4, TextBoxRG4)
        Rami.Add(5, TextBoxRG5)
        Rami.Add(6, TextBoxRG6)
        Rami.Add(7, TextBoxRG7)
        Rami.Add(8, TextBoxRG8)
        Rami.Add(9, TextBoxRG9)
        Rami.Add(10, TextBoxRG10)
        Rami.Add(11, TextBoxRG11)
        Rami.Add(12, TextBoxRG12)
        Rami.Add(13, TextBoxRG13)
        Rami.Add(14, TextBoxRG14)
        Rami.Add(16, TextBoxRG16)
        Rami.Add(17, TextBoxRG17)
        Rami.Add(18, TextBoxRG18)
        Rami.Add(19, TextBoxRG19)
        Rami.Add(20, TextBoxRG20)
        Rami.Add(21, TextBoxRG21)
        Rami.Add(22, TextBoxRG22)
        Rami.Add(23, TextBoxRG23)
    End Sub

    Private Sub ImpostaPercentuali()
        'viene utilizzata una key poichè non tutti i rg fra 1 e 23 sono presenti
        Try
            For Each t As Object In tlpBudget.Controls

                If TypeOf (t) Is TextBox Then

                    If t.Name.StartsWith("txtPerc", StringComparison.InvariantCultureIgnoreCase) Then
                        'le percentuali
                        cPerc.Add(t, t.Name.Substring(7))
                        t.Tag = CInt(t.Name.Substring(7))
                    End If
                End If
            Next

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub ImpostaComparti()
        With Comparti
            .Add(1, TextBoxComparto1)
            .Add(2, TextBoxComparto2)
            .Add(3, TextBoxComparto3)
            .Add(4, TextBoxComparto4)
            .Add(5, TextBoxComparto5)
            .Add(6, TextBoxComparto6)
            .Add(7, TextBoxComparto7)
        End With
    End Sub

    Private Sub btnCalcolaBudget_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcolaBudget.Click
        If FiguraSelezionata() = 0 Then
            If MsgBox(String.Format("Poiché avete selezionato il budget totale d'agenzia (codice 0),{0}" +
                                    "il calcolo riporterà come budget il totale incassato l'anno precedente.{0}" +
                                    "In questo modo il saldo incassi dell'anno precedente costituisce la base{0}" +
                                    "per la definizione del budget dell'anno selezionato.{0}{0}" +
                                    "I valori già presenti verranno sostituiti. Continuare?",
                                    Environment.NewLine), MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                RiportoIncassiAnnoPrecedente()
            End If
        Else
            CalcolaBudgetFigura()
        End If
    End Sub

    Private Sub RiportoIncassiAnnoPrecedente()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim Sfondo As Color

            For Each rg As Integer In Globale.ElencoRamiGestione

                Sfondo = Rami.Controllo(rg).BackColor

                Rami.Controllo(rg).BackColor = Color.NavajoWhite
                Rami.Controllo(rg).Refresh()

                'calcolo totali anno precedente x il ramo gestione
                Dim TotaleRgAgenzia As Double = Math.Round(IncassiAgenzia(cboAnno.Text - 1, rg), 2)

                BudgetCodice.BudgetRamo(rg) = TotaleRgAgenzia
                BudgetAgenzia.BudgetRamo(rg) = TotaleRgAgenzia

                Rami.Controllo(rg).Importo = TotaleRgAgenzia
                Rami.Controllo(rg).Refresh()

                'le percentuali
                cPerc.Item(rg.ToString).Text = Format(100, "##0.0")
                cPerc.Item(rg.ToString).Refresh()

                Rami.Controllo(rg).BackColor = Sfondo
                Rami.Controllo(rg).Refresh()
            Next

            CalcolaTotali()

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub CalcolaBudgetFigura()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim Figura As Integer = FiguraSelezionata()
            Dim Sfondo As Color

            For Each rg As Integer In Globale.ElencoRamiGestione

                If BudgetAgenzia.BudgetRamo(rg) > 0 Then

                    Sfondo = Rami.Controllo(rg).BackColor

                    Rami.Controllo(rg).BackColor = Color.NavajoWhite
                    Rami.Controllo(rg).Refresh()

                    'calcolo totali anno precedente x ramo gestione
                    Dim TotaleRgFigura As Double = IncassiFigura(Figura, cboAnno.Text - 1, rg)
                    Dim TotaleRgAgenzia As Double = IncassiAgenzia(cboAnno.Text - 1, rg)

                    If TotaleRgAgenzia > 0 Then
                        Dim PercentualeFigura As Double = TotaleRgFigura / TotaleRgAgenzia

                        Dim BudgetRgFigura As Double = Math.Round(BudgetAgenzia.BudgetRamo(rg) *
                                                                  PercentualeFigura, 2)

                        BudgetCodice.BudgetRamo(rg) = BudgetRgFigura

                        Rami.Controllo(rg).Importo = BudgetRgFigura
                        Rami.Controllo(rg).Refresh()

                        'le percentuali
                        cPerc.Item(rg.ToString).Text = Format(PercentualeFigura * 100, "##0.0")
                        cPerc.Item(rg.ToString).Refresh()
                    Else
                        cPerc.Item(rg.ToString).Text = Format(0, "##0.0")
                    End If
                Else
                    cPerc.Item(rg.ToString).Text = Format(0, "##0.0")
                End If

                Rami.Controllo(rg).BackColor = Sfondo
                Rami.Controllo(rg).Refresh()
            Next

            CalcolaTotali()

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub btnAnnulla_Click_1(sender As System.Object, e As System.EventArgs) Handles btnAnnulla.Click
        SganciaEventiCom()
        'azzero i campi rg e comparto
        For Each rg As Integer In Globale.ElencoRamiGestione
            Rami.Controllo(rg).Importo = 0
        Next

        BudgetAgenzia = Nothing
        BudgetCodice = Nothing

        gbFigura.Enabled = True
        gbImporti.Enabled = False
        cboFigura.Focus()
    End Sub

    Private Sub btnStampa_Click(sender As System.Object, e As System.EventArgs) Handles btnStampa.Click
        Try
            Cursor = Cursors.WaitCursor

            Call New Utx.NotificaRapida().Visualizza("Attendere...", 3)

            Dim Report As New Utx.PaginaHtml(String.Format("Budget_{0}_{1}", cboAnno.Text, cboFigura.Text.Split(" ")(0)))
            With Report
                .Titolo = String.Format("Budget anno {0} codice {1}", cboAnno.Text, cboFigura.Text)
                .Size = Utx.PaginaHtml.TextSize.x_large
                .AddHtml("<div style=""font-family:Calibri;font-size: medium"">")
                .AddHtml("<table>")

                'intestazione
                .AddHtml("<tr style=""font-weight: bold"">")
                .AddHtml(String.Format("<tr style=""font-weight: bold""><td colspan=6 style=""text-align: left""><p>Figura: {0}</p></td></tr>", cboFigura.Text))
                .AddHtml(String.Format("<tr style=""font-weight: bold""><td colspan=6 style=""text-align: left""><p>Anno: {0}</p></td></tr>", cboAnno.Text))
                .AddHtml(String.Format("<tr><td colspan=6 style=""text-align: left""><p>Stampa del: {0}</p></td></tr>", Now))

                'riga intestazione
                .AddHtml("<tr bgcolor=""CCCCCC"" style=""font-weight: bold"">")
                .AddHtml(String.Format("<td bgcolor=""EEEEEE"" style=""text-align: center""><p>Incassato per ramo gestione</br>al {0:dd-MM-yyyy}</p></td>", DataAnalisi))
                .AddHtml("<td bgcolor=""EEEEEE"" style=""text-align: center""><p>Avanzamento</br>%</p></td>")
                .AddHtml("<td style=""text-align: center""><p>Rami</br>gestione</p></td>")
                .AddHtml("<td style=""text-align: center""><p>Budget</br>ramo</p></td>")
                .AddHtml("<td style=""text-align: center""><p>Budget</br>comparto</p></td>")
                .AddHtml("<td style=""text-align: center""><p>Budget</br>settore</p></td>")
                .AddHtml("<td style=""text-align: center""><p>Budget</br>aggregato</p></td>")
                .AddHtml("<td style=""text-align: center""><p>Budget</br>generale</p></td>")
                .AddHtml("</tr>")
                'rg1
                Dim IncassoRg As Double = IncassiFigura(FiguraSelezionata, cboAnno.Text, 1)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(1))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG1.Text))
                .AddHtml(HtmlDescrizione("1: Rca"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG1.Text))
                .AddHtml("</tr>")
                'rg2
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 2)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(2))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG2.Text))
                .AddHtml(HtmlDescrizione("2: Ard"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG2.Text))
                .AddHtml(HtmlCompartoFigura(TextBoxComparto1.Text))
                .AddHtml(String.Format("<td bgcolor=""#colore3#"" style=""text-align: right""><p>{0}</p></td>", txtSet1.Text))
                .AddHtml("</tr>")
                'rg3
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 3)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(3))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG3.Text))
                .AddHtml(HtmlDescrizione("3: Infortuni"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG3.Text))
                .AddHtml("</tr>")
                'rg5
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 5)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(5))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG5.Text))
                .AddHtml(HtmlDescrizione("5: Rischi Diversi Persone"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG5.Text))
                .AddHtml(HtmlCompartoFigura(TextBoxComparto2.Text))
                .AddHtml("</tr>")
                'rg4
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 4)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(4))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG4.Text))
                .AddHtml(HtmlDescrizione("4: Malattia"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG4.Text))
                .AddHtml(HtmlCompartoFigura(TextBoxComparto3.Text))
                .AddHtml("</tr>")
                'rg6
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 6)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(6))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG6.Text))
                .AddHtml(HtmlDescrizione("6: Incendio Rischi Ordinari"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG6.Text))
                .AddHtml("</tr>")
                'rg7
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 7)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(7))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG7.Text))
                .AddHtml(HtmlDescrizione("7: Incendio Rischi Industriali"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG7.Text))
                .AddHtml("</tr>")
                'rg8
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 8)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(8))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG8.Text))
                .AddHtml(HtmlDescrizione("8: Rischi Tecnologici"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG8.Text))
                .AddHtml("</tr>")
                'rg9
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 9)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(9))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG9.Text))
                .AddHtml(HtmlDescrizione("9: Furto"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG9.Text))
                .AddHtml("</tr>")
                'rg21
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 21)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(21))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG21.Text))
                .AddHtml(HtmlDescrizione("21: Tutela legale"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG21.Text))
                .AddHtml("</tr>")
                'rg22
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 22)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(22))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG22.Text))
                .AddHtml(HtmlDescrizione("22: Assistenza"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG22.Text))
                .AddHtml("</tr>")
                'rg23
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 23)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(23))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG23.Text))
                .AddHtml(HtmlDescrizione("23: Turismo"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG23.Text))
                .AddHtml(HtmlCompartoFigura(TextBoxComparto4.Text))
                .AddHtml("</tr>")
                'rg10
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 10)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(10))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG10.Text))
                .AddHtml(HtmlDescrizione("9: RCG"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG10.Text))
                .AddHtml(HtmlCompartoFigura(TextBoxComparto5.Text))
                .AddHtml("</tr>")
                'rg11
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 11)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(11))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG11.Text))
                .AddHtml(HtmlDescrizione("11: Trasporti"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG11.Text))
                .AddHtml("</tr>")
                'rg12
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 12)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(12))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG12.Text))
                .AddHtml(HtmlDescrizione("12: Aeronautica"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG12.Text))
                .AddHtml("</tr>")
                'rg13
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 13)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(13))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG13.Text))
                .AddHtml(HtmlDescrizione("13: Cauzioni"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG13.Text))
                .AddHtml("</tr>")
                'rg14
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 14)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(14))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG14.Text))
                .AddHtml(HtmlDescrizione("14: Credito"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG14.Text))
                .AddHtml("</tr>")
                'rg16
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 16)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(16))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG16.Text))
                .AddHtml(HtmlDescrizione("16: Grandine"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG16.Text))
                .AddHtml("</tr>")
                'rg17
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 17)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(17))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG17.Text))
                .AddHtml(HtmlDescrizione("17: Bestiame"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG17.Text))
                .AddHtml(HtmlCompartoFigura(TextBoxComparto6.Text))
                .AddHtml(String.Format("<td bgcolor=""#colore3#"" style=""text-align: right""><p>{0}</p></td>", txtSet2.Text))
                .AddHtml(String.Format("<td bgcolor=""#colore4#"" style=""text-align: right""><p>{0}</p></td>", txtAgg1.Text))
                .AddHtml("</tr>")
                'rg18
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 18)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(18))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG18.Text))
                .AddHtml(HtmlDescrizione("18: Vita individuali"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG18.Text))
                .AddHtml("</tr>")
                'rg19
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 19)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(19))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG19.Text))
                .AddHtml(HtmlDescrizione("19: Vita collettive"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG19.Text))
                .AddHtml("</tr>")
                'rg20
                IncassoRg = IncassiFigura(FiguraSelezionata, cboAnno.Text, 20)
                .AddHtml("<tr>")
                .AddHtml(HtmlIncassiFigura(20))
                .AddHtml(HtmlPercFigura(IncassoRg, TextBoxRG20.Text))
                .AddHtml(HtmlDescrizione("20: Vita fondi pensione"))
                .AddHtml(HtmlBudgetFigura(TextBoxRG20.Text))
                .AddHtml(HtmlCompartoFigura(TextBoxComparto7.Text))
                .AddHtml(String.Format("<td bgcolor=""#colore3#"" style=""text-align: right""><p>{0}</p></td>", txtSet3.Text))
                .AddHtml(String.Format("<td bgcolor=""#colore4#"" style=""text-align: right""><p>{0}</p></td>", txtAgg2.Text))
                .AddHtml(String.Format("<td bgcolor=""#colore5#"" style=""text-align: right""><p>{0}</p></td>", txtGenerale.Text))
                .AddHtml("</tr>")

                .AddHtml("</table>")
                .AddHtml("</div>")

                .Sostituisci("#colore1#", "FFFF99")
                .Sostituisci("#colore2#", "99FF99")
                .Sostituisci("#colore3#", "FFCC66")
                .Sostituisci("#colore4#", "FFC0CB")
                .Sostituisci("#colore5#", "CCCCFF")

                .CreaFileHtml()
            End With
            'visualizzo anteprima
            Using Anteprima As New UtControls.FormAnteprima
                Anteprima.ControlloBottoni()
                Anteprima.NomeFile = Report.NomeFile
                Anteprima.ShowDialog()
                'cancello il file di anteprima
                IO.File.Delete(Anteprima.NomeFile)
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function HtmlDescrizione(Descrizione As String) As String
        Return String.Format("<td style=""text-align: left""><p><b>{0}</b></p></td>", Descrizione)
    End Function

    Private Function HtmlIncassiFigura(Ramogestione As Integer) As String
        Return String.Format("<td bgcolor=""EEEEEE"" style=""text-align: center""><p>{0:##,###,##0.00}</p></td>", IncassiFigura(FiguraSelezionata, cboAnno.Text, Ramogestione))
    End Function

    Private Function HtmlBudgetFigura(Budget As String) As String
        Return String.Format("<td bgcolor=""#colore1#"" style=""text-align: right""><p>{0}</p></td>", Budget)
    End Function

    Private Function HtmlCompartoFigura(Budget As String) As String
        Return String.Format("<td bgcolor=""#colore2#"" style=""text-align: right""><p>{0}</p></td>", Budget)
    End Function

    Private Function HtmlPercFigura(Incasso As Double, Budget As Double) As String
        Return String.Format("<td bgcolor=""EEEEEE"" style=""text-align: center""><p>{0:#,##0.00%}</p></td>", IIf(Budget > 0, Incasso / Budget, "="))
    End Function

    Private Sub AgganciaEventiRG()
        For Each rg As Integer In Globale.ElencoRamiGestione
            AddHandler Rami.Controllo(rg).ModificaImportoRamo, AddressOf ModificaImportoRamo
        Next
    End Sub

    Private Sub SganciaEventiRG()
        For Each rg As Integer In Globale.ElencoRamiGestione
            RemoveHandler Rami.Controllo(rg).ModificaImportoRamo, AddressOf ModificaImportoRamo
        Next
    End Sub

    Private Sub AgganciaEventiCom()
        For Each com As Integer In Globale.ElencoComparti
            AddHandler Comparti.Controllo(com).ModificaImportoComparto, AddressOf ModificaImportoComparto
        Next
    End Sub

    Private Sub SganciaEventiCom()
        For Each com As Integer In Globale.ElencoComparti
            RemoveHandler Comparti.Controllo(com).ModificaImportoComparto, AddressOf ModificaImportoComparto
        Next
    End Sub

    Private Sub AgganciaTotali()
        For Each rg As Integer In Globale.ElencoRamiGestione
            Rami.Controllo(rg).CalcoloTotali = True
        Next
    End Sub

    Private Sub SganciaTotali()
        For Each rg As Integer In Globale.ElencoRamiGestione
            Rami.Controllo(rg).CalcoloTotali = False
        Next
    End Sub

    Private Function FiguraSelezionata() As String
        Return cboFigura.SelectedItem.Codice
    End Function

    Private Sub ModificaImportoRamo(ByRef Controllo As TextBoxRG)
        BudgetCodice.BudgetRamo(Controllo.RamoGestione) = Controllo.Importo
        If Controllo.CalcoloTotali = True Then CalcolaTotali()
    End Sub

    Private Sub ModificaImportoComparto(ByRef Controllo As TextBoxComparto)

        If String.IsNullOrEmpty(txtGenerale.Text) OrElse CDbl(txtGenerale.Text) = 0 Then
            MsgBox("Prima di modificare gli importi di comparto è necessario avere un budget base effettuando il calcolo, per le sub, o il riporto dall'anno precedente per l'agenzia",
                   MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            Exit Sub
        End If

        SganciaEventiCom()
        SganciaTotali()

        Dim Incremento As Single = Controllo.Importo / BudgetCodice.TotaleComparto(Controllo.Comparto)

        For Each rg As Integer In Comparto.RamiGestione(Controllo.Comparto)
            Rami.Controllo(rg).Importo = Math.Round(Rami.Controllo(rg).Importo * Incremento, 2, MidpointRounding.AwayFromZero)
        Next

        CalcolaTotali()

        AgganciaTotali()
        AgganciaEventiCom()
    End Sub

    Private Sub cboFigura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFigura.SelectedIndexChanged
        Dim Figura As FiguraProduttiva = cboFigura.SelectedItem
        If Figura.Tipo <> FiguraProduttiva.TipoFigura.CIP Then
            MsgBox("E' possibile inserire il budget solo per figure singole e non per gruppi.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            cboFigura.SelectedIndex = 0
        End If
    End Sub

#Region "paint label"
    Private Sub Label33_Paint(sender As Object, e As PaintEventArgs) Handles Label33.Paint
        With e.Graphics
            .TranslateTransform(2, Label33.Height - 10)
            .RotateTransform(270)
            .DrawString("RCA", Utx.AppFont.Extra(9, FontStyle.Bold), Brushes.Black, 0, 1)
        End With
    End Sub
    Private Sub Label31_Paint(sender As Object, e As PaintEventArgs) Handles Label31.Paint
        With e.Graphics
            .TranslateTransform(2, Label31.Height - 10)
            .RotateTransform(270)
            .DrawString("RDP", Utx.AppFont.Extra(9, FontStyle.Bold), Brushes.White, 0, 1)
        End With
    End Sub
    Private Sub Label32_Paint(sender As Object, e As PaintEventArgs) Handles Label32.Paint
        With e.Graphics
            .TranslateTransform(2, Label32.Height - 10)
            .RotateTransform(270)
            .DrawString("Aziende", Utx.AppFont.Extra(9, FontStyle.Bold), Brushes.Black, 0, 1)
        End With
    End Sub
    Private Sub Label40_Paint(sender As Object, e As PaintEventArgs) Handles Label40.Paint
        With e.Graphics
            .TranslateTransform(4, Label40.Height - 2)
            .RotateTransform(270)
            .DrawString("RCG", Utx.AppFont.Extra(7, FontStyle.Bold), Brushes.Black, 0, 1)
        End With
    End Sub
    Private Sub Label34_Paint(sender As Object, e As PaintEventArgs) Handles Label34.Paint
        With e.Graphics
            .TranslateTransform(2, Label34.Height - 10)
            .RotateTransform(270)
            .DrawString("Altri Rami", Utx.AppFont.Extra(9, FontStyle.Bold), Brushes.Black, 0, 1)
        End With
    End Sub
    Private Sub Label35_Paint(sender As Object, e As PaintEventArgs) Handles Label35.Paint
        With e.Graphics
            .TranslateTransform(2, Label35.Height - 10)
            .RotateTransform(270)
            .DrawString("Vita", Utx.AppFont.Extra(9, FontStyle.Bold), Brushes.Black, 0, 1)
        End With
    End Sub
    Private Sub Label46_Paint(sender As Object, e As PaintEventArgs) Handles Label46.Paint
        With e.Graphics
            .TranslateTransform(4, Label46.Height - 2)
            .RotateTransform(270)
            .DrawString("SAL", Utx.AppFont.Extra(7, FontStyle.Bold), Brushes.Black, 0, 1)
        End With
    End Sub
#End Region
End Class