Imports System.IO

Public Class FormProdotti

    Public Event RichiestaCliente(CodiceFiscale As String)

    Public Enum Vista
        DETTAGLIO
        SINTESI
        INCASSI
    End Enum

    Private FormFiltro As New Utx.FormGestioneFiltro(1000)

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(Utx.InfoSistema.Desktop.Larghezza * 0.7, Utx.InfoSistema.Desktop.Altezza * 0.7)
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("torta")
        Me.Text = "Gestione prodotti liberi"

        ImpostaControlli()
    End Sub

    Private mTipoVista As Vista
    Public Property TipoVista() As Vista
        Get
            Return mTipoVista
        End Get
        Set(value As Vista)
            mTipoVista = value

            Select Case mTipoVista
                Case Vista.DETTAGLIO, Vista.INCASSI
                    TabPageDati.Text = "Dettaglio"
                    ButtonDettaglio.Image = Risorse.Immagini.Bitmap("previous")
                    ButtonDettaglio.Text = "Torna alla sintesi"
                Case Else
                    TabPageDati.Text = "Sintesi"
                    ButtonDettaglio.Image = Risorse.Immagini.Bitmap("list32")
                    ButtonDettaglio.Text = "Visualizza il dettaglio"
            End Select
            ButtonCliente.Enabled = (mTipoVista = Vista.DETTAGLIO)
        End Set
    End Property

    Private Sub ImpostaControlli()
        With ButtonDettaglio
            .Margin = New Padding(0)
            .Padding = Utx.AppFont.ButtonPadding
            .Dock = DockStyle.Fill
            .ImageAlign = ContentAlignment.MiddleLeft
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonCliente
            .Margin = New Padding(0)
            .Padding = Utx.AppFont.ButtonPadding
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("cliente")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Vai alla scheda del cliente"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonExcel
            .Margin = New Padding(0)
            .Padding = Utx.AppFont.ButtonPadding
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("csv")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Esporta in csv"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonIncassi
            .Margin = New Padding(0)
            .Padding = Utx.AppFont.ButtonPadding
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("torta")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Incassi prodotti liberi"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonEsci
            .Margin = New Padding(0)
            .Padding = Utx.AppFont.ButtonPadding
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With dgvProdotti
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .Margin = New Padding(1)
        End With
        Utx.NetFunc.DoppioBuffer(dgvProdotti)
    End Sub

    Private Sub FormProdotti_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.ROSSO
        Me.TipoVista = Vista.SINTESI
        Sintesi()
    End Sub

    Private Sub Sintesi()
        Try
            dgvProdotti.DataSource = Nothing

            Dim Query As String = "SELECT DISTINCT 
                FORMAT(P.RamoGestione,'00') AS Ramogestione,P.Ramo,COUNT(*) AS NumeroPolizze,SUM(TotalePremioAnnuo) AS Tassabile,D.DescRamoGest
                FROM Polizze AS P 
                INNER JOIN (SELECT DISTINCT Rg,Prodotto FROM Tariffati WHERE Tipo = 'Liberi') AS T ON TRIM(T.Prodotto) = P.CodiceProdotto AND T.rg = P.RamoGestione
                LEFT JOIN RamoGest AS D ON D.RamoGestione = P.RamoGestione
                GROUP BY FORMAT(P.RamoGestione,'00'),P.Ramo,D.DescRamoGest 
                ORDER BY FORMAT(P.RamoGestione,'00'),P.Ramo"

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            Dim dr As DataRow = dt.NewRow
            dr("RamoGestione") = "Totali"
            dr("NumeroPolizze") = 0
            dr("Tassabile") = 0

            For Each r As DataRow In dt.Rows
                dr("NumeroPolizze") += r("NumeroPolizze")
                dr("Tassabile") += r("Tassabile")
            Next

            dt.Rows.Add(dr)

            dgvProdotti.DataSource = dt
            FormattaSintesi()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub Dettaglio(RamoGestione As Integer, RamoPolizza As Integer)
        Try
            dgvProdotti.DataSource = Nothing

            Dim query As String = String.Format("SELECT C.Cognome + ' ' + C.Nome AS Contraente,P.CodiceFiscale,P.RamoGestione,TRIM(D.DescRamoGest) AS DescRamoGest,
                P.Ramo,TRIM(TR.Ramo) AS DescRamo,P.CodiceProdotto,TRIM(PR.Prodotto) As DescProdotto,P.CodiceSubagente,P.Convenzione,
                P.Polizza,P.TotalePremioAnnuo,P.DataEffetto,P.DataScadenza,P.Frazionamento 
                FROM ((((Polizze AS P 
                INNER JOIN (SELECT DISTINCT Rg,Prodotto FROM Tariffati WHERE Tipo = 'Liberi') AS T 
                ON TRIM(T.Prodotto) = P.CodiceProdotto AND T.Rg = P.RamoGestione) 
                INNER JOIN (SELECT CodiceFiscale,Cognome,Nome FROM Clienti) AS C 
                ON C.CodiceFiscale = P.CodiceFiscale) 
                LEFT JOIN RamoGest AS D ON D.RamoGestione = P.RamoGestione) 
                LEFT JOIN TipoRami AS TR ON TR.CodiceRamo = P.Ramo) 
                LEFT JOIN Prodotti AS PR ON PR.CodiceProdotto = P.CodiceProdotto 
                WHERE P.Ramo = {0} AND P.RamoGestione = {1}
                ORDER BY P.Ramo,P.Polizza", RamoPolizza, RamoGestione)

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(query).DataTable

            dgvProdotti.DataSource = dt
            FormattaDettaglio()
            TabPageDati.Text = String.Format("Dettaglio ({0})", dt.Rows.Count)

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub Dettaglio()
        Try
            dgvProdotti.DataSource = Nothing

            Dim Query As String = "SELECT C.Cognome + ' ' + C.Nome AS Contraente,P.CodiceFiscale,P.RamoGestione,TRIM(D.DescRamoGest) AS DescRamoGest,
                P.Ramo,TRIM(TR.Ramo) AS DescRamo,P.CodiceProdotto,TRIM(PR.Prodotto) As DescProdotto,P.CodiceSubagente,P.Convenzione,
                P.Polizza,P.TotalePremioAnnuo,P.DataEffetto,P.DataScadenza,P.Frazionamento 
                FROM ((((Polizze AS P 
                INNER JOIN (SELECT DISTINCT Rg,Prodotto FROM Tariffati WHERE Tipo = 'Liberi') AS T 
                ON TRIM(T.Prodotto) = P.CodiceProdotto AND T.Rg = P.RamoGestione) 
                INNER JOIN (SELECT CodiceFiscale,Cognome,Nome FROM Clienti) AS C 
                ON C.CodiceFiscale = P.CodiceFiscale) 
                LEFT JOIN RamoGest AS D ON D.RamoGestione = P.RamoGestione) 
                LEFT JOIN TipoRami AS TR ON TR.CodiceRamo = P.Ramo) 
                LEFT JOIN Prodotti AS PR ON PR.CodiceProdotto = P.CodiceProdotto 
                ORDER BY P.Ramo,P.Polizza"

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            dgvProdotti.DataSource = dt
            FormattaDettaglio()
            TabPageDati.Text = String.Format("Dettaglio ({0})", dt.Rows.Count)

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormattaSintesi()
        Try
            Me.Cursor = Cursors.WaitCursor

            With dgvProdotti
                With .Columns("RamoGestione")
                    .HeaderText = "Ramo gestione"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.BackColor = Color.Moccasin
                End With
                With .Columns("Ramo")
                    .HeaderText = "Ramo polizza"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("NumeroPolizze")
                    .HeaderText = "Numero polizze"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("Tassabile")
                    .HeaderText = "Totale tassabile"
                    .DefaultCellStyle.Format = "###,###,##0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("DescRamoGest")
                    .HeaderText = "Descrizione ramo gestione"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                With .Rows(.Rows.Count - 1)
                    .DefaultCellStyle.BackColor = Color.Orange
                    .DefaultCellStyle.Font = Utx.AppFont.Bold
                End With

                For Each c As DataGridViewColumn In .Columns
                    c.SortMode = DataGridViewColumnSortMode.Programmatic
                Next

                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                .Refresh()
            End With

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormattaDettaglio()
        Try
            Me.Cursor = Cursors.WaitCursor

            With dgvProdotti
                .Columns("Contraente").DefaultCellStyle.BackColor = Color.Yellow
                .Columns("CodiceFiscale").Visible = False
                With .Columns("RamoGestione")
                    .HeaderText = "Ramo gestione"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("DescRamoGest")
                    .HeaderText = "Desc.R.Gest"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .DefaultCellStyle.BackColor = Color.GhostWhite
                End With
                With .Columns("Ramo")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                With .Columns("DescRamo")
                    .HeaderText = "Desc.Ramo"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .DefaultCellStyle.BackColor = Color.GhostWhite
                End With
                With .Columns("CodiceProdotto")
                    .HeaderText = "Prodotto"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.BackColor = Color.LightPink
                End With
                With .Columns("DescProdotto")
                    .HeaderText = "Desc.Prodotto"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .DefaultCellStyle.BackColor = Color.GhostWhite
                End With
                With .Columns("Polizza")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("DataEffetto")
                    .HeaderText = "Effetto"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("DataScadenza")
                    .HeaderText = "Scadenza"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("Frazionamento")
                    .HeaderText = "Fraz."
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("CodiceSubagente")
                    .HeaderText = "Sub"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.BackColor = Utx.AppColor.VerdeAcido
                End With
                With .Columns("TotalePremioAnnuo")
                    .HeaderText = "Premio tassabile"
                    .DefaultCellStyle.Format = "###,###,##0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("Convenzione")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With

                For Each c As DataGridViewColumn In .Columns
                    c.SortMode = DataGridViewColumnSortMode.Programmatic
                Next

                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                .Refresh()
            End With

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonDettaglio_Click(sender As Object, e As EventArgs) Handles ButtonDettaglio.Click
        If Me.TipoVista = Vista.SINTESI Then
            If dgvProdotti.CurrentRow IsNot Nothing Then
                Me.TipoVista = Vista.DETTAGLIO
                If IsNumeric(dgvProdotti.CurrentRow.Cells(0).Value) Then
                    Dettaglio(dgvProdotti.CurrentRow.Cells("RamoGestione").Value, dgvProdotti.CurrentRow.Cells("Ramo").Value)
                Else
                    'riga dei totali mostro tutto
                    Dettaglio()
                End If
            End If
        Else
            Me.TipoVista = Vista.SINTESI
            Sintesi()
        End If
    End Sub

    Private Sub ButtonCliente_Click(sender As Object, e As EventArgs) Handles ButtonCliente.Click
        RaiseEvent RichiestaCliente(dgvProdotti.CurrentRow.Cells("CodiceFiscale").Value)
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub ButtonExcel_Click(sender As Object, e As EventArgs) Handles ButtonExcel.Click
        If dgvProdotti.Rows.Count > 0 Then
            Utx.NetFunc.Esporta2Csv(dgvProdotti, Path.Combine(Utx.Globale.UtenteCorrente.Desktop, "Prodotti_Liberi"), Color.Khaki)
        End If
    End Sub

    Private Sub dgvProdotti_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvProdotti.ColumnHeaderMouseClick
        Try
            'cartella per salvataggio filtro
            FormFiltro.AppName = "PRODOTTI_LIBERI"
            FormFiltro.FilterFolder = Utx.Globale.Paths.CartellaSettingRete

            'visualizzo la finestra del filtro
            FormFiltro.Visualizza(dgvProdotti.Columns(e.ColumnIndex))
            TabPageDati.Text = String.Format("Dettaglio ({0})", dgvProdotti.Rows.Count)
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function QueryProdottiLiberi(Inizio As Integer) As String
        Return String.Format("SELECT YEAR(DataFoglioCassa) AS Anno,RamoGestione,SUM(Tassabile) AS Totale
            FROM Incassi AS I
            INNER JOIN DB00000.dbo.Liberi AS L
            ON CAST(I.CodiceProdotto AS int) = CAST(L.Prodotto AS int) AND I.RamoGestione = L.Rg
            WHERE YEAR(DataFoglioCassa) > {0}
            GROUP BY YEAR(DataFoglioCassa),RamoGestione
            ORDER BY Ramogestione,YEAR(DataFoglioCassa)", Inizio)
    End Function

    Private Function QuertIncassi(Inizio As Integer)
        Return String.Format("SELECT YEAR(DataFoglioCassa) AS Anno,I.RamoGestione,SUM(Tassabile) AS Incassato,0.001 AS IncLiberi,0.001 AS Perc,0.001 AS ValidoRappel,D.DescRamoGest,
            SUM(PrINF) AS TotaleINF,SUM(PrIF+PrKasko+PrAssistenza) AS TotaleARD
            FROM Incassi AS I
            LEFT JOIN RamoGest AS D ON D.RamoGestione = I.RamoGestione
            WHERE YEAR(DataFoglioCassa) > {0}
            GROUP BY YEAR(DataFoglioCassa),I.RamoGestione,D.DescRamoGest
            ORDER BY I.Ramogestione,YEAR(DataFoglioCassa)", Inizio)
    End Function

    Private Sub ButtonIncassi_Click(sender As Object, e As EventArgs) Handles ButtonIncassi.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            dgvProdotti.DataSource = Nothing

            TipoVista = Vista.INCASSI

            Dim Inizio As Integer = Today.Year - 3
            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(QuertIncassi(Inizio)).DataTable
            Dim dtLiberi As DataTable = Utx.WsCommand.ExecuteNonQuery(QueryProdottiLiberi(Inizio)).DataTable

            'ramogestione: 1=rca, 2=ard, 3=inf
            Dim RigaRg1, RigaRg2, RigaRg3 As Integer

            With dt
                If .Rows.Count > 0 Then
                    'per ogni anno
                    For Anno As Integer = Inizio To Today.Year

                        'recupero l'indice di riga per quell'anno dei rami gestione 1/2/3
                        For k As Integer = 0 To dt.Rows.Count - 1

                            If .Rows(k).Item("Anno") = Anno Then
                                If .Rows(k).Item("RamoGestione") = 1 Then RigaRg1 = k
                                If .Rows(k).Item("RamoGestione") = 2 Then RigaRg2 = k
                                If .Rows(k).Item("RamoGestione") = 3 Then RigaRg3 = k
                            End If
                        Next

                        'premi
                        .Rows(RigaRg1).Item("Incassato") = .Rows(RigaRg1).Item("Incassato") - .Rows(RigaRg1).Item("TotaleINF") - .Rows(RigaRg1).Item("TotaleARD")
                        .Rows(RigaRg2).Item("Incassato") = .Rows(RigaRg2).Item("Incassato") - .Rows(RigaRg2).Item("TotaleINF") + .Rows(RigaRg1).Item("TotaleARD") 'ARD proveniente dalla riga 1 (rca)
                        .Rows(RigaRg3).Item("Incassato") += .Rows(RigaRg1).Item("TotaleINF") + .Rows(RigaRg2).Item("TotaleINF") 'INF proveniente dalle righe 1 e 2 (rca e ard)
                    Next
                End If

                'cancello le colonne che non mi servono più
                .Columns.Remove("TotaleARD")
                .Columns.Remove("TotaleINF")
            End With

            Dim Perc As Double = 0

            'calcolo di incassi da prodotti liberi validi ai fini del calcolo del rappel
            For Each Row As DataRow In dt.Rows
                Row("IncLiberi") = 0
                Row("ValidoRappel") = 0
                Row("Perc") = 100

                Select Case Row("Anno")
                    Case 2023
                        Row("Perc") = 90
                    Case 2024
                        Row("Perc") = 80
                    Case >= 2025
                        Row("Perc") = 75
                End Select

                Row("ValidoRappel") = Row("Incassato")

                For Each RowLiberi As DataRow In dtLiberi.Rows
                    If RowLiberi("Anno") = Row("Anno") And RowLiberi("RamoGestione") = Row("RamoGestione") Then
                        Row("IncLiberi") = RowLiberi("Totale")
                        Row("ValidoRappel") = Row("Incassato") - Row("IncLiberi") + (Row("IncLiberi") * Row("Perc") / 100)
                    End If
                Next
            Next
            dgvProdotti.DataSource = dt

            With dgvProdotti
                With .Columns("RamoGestione")
                    .HeaderText = "Ramo gestione"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("Anno")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("DescRamoGest")
                    .HeaderText = "Descrizione ramo gestione"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .DefaultCellStyle.BackColor = Color.GhostWhite
                End With
                With .Columns("Incassato")
                    .DefaultCellStyle.Format = "###,###,##0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("IncLiberi")
                    .HeaderText = "Incassi prodotti liberi"
                    .DefaultCellStyle.Format = "###,###,##0.00"
                    .DefaultCellStyle.ForeColor = Color.IndianRed
                    .DefaultCellStyle.Font = New Font(dgvProdotti.Font, FontStyle.Bold)
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("Perc")
                    .HeaderText = "% incassi validi per il rappel"
                    .DefaultCellStyle.Format = "##.00"
                    .DefaultCellStyle.BackColor = Color.Gainsboro
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns("ValidoRappel")
                    .HeaderText = "Incassi validi per il rappel"
                    .DefaultCellStyle.Format = "###,###,##0.00"
                    .DefaultCellStyle.Font = New Font(dgvProdotti.Font, FontStyle.Bold)
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With

                For Each c As DataGridViewColumn In .Columns
                    c.SortMode = DataGridViewColumnSortMode.Programmatic
                Next

                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                .Refresh()
            End With

            For Each row As DataGridViewRow In dgvProdotti.Rows
                If row.Cells("Anno").Value = Today.Year Then
                    row.DefaultCellStyle.BackColor = Color.LightYellow
                End If
            Next

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgvProdotti_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvProdotti.DataSourceChanged
        dgvProdotti.Refresh()
    End Sub
End Class