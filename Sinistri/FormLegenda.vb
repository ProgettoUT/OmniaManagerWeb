Imports System.Drawing

Public Class FormLegenda

    Public Property SinistroCorrente As Sinistro
    Public Property Posizione As New Drawing.Point(150, 150)
    Public Property Legenda As DataTable
    Private _Vista As TipoVista = TipoVista.INSERIMENTO 'default

    Public Enum TipoVista
        INSERIMENTO = 0
        FILTRO = 1
    End Enum

    Sub New(Vista As TipoVista)

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        _Vista = Vista
        If _Vista = TipoVista.INSERIMENTO Then
            Me.Size = New Drawing.Size(400, 480)
        Else
            Me.Size = New Drawing.Size(500, 480)
        End If
        Me.ShowInTaskbar = False
        Me.StartPosition = Windows.Forms.FormStartPosition.Manual
        Me.Location = Posizione
        Me.Font = Utx.AppFont.Normal
        Me.Text = "Legenda tag sinistro"
    End Sub

    Private Sub FormLegenda_Load(sender As Object, e As EventArgs) Handles Me.Load
        With CheckedListBoxLegenda
            .Font = Utx.AppFont.Extra(10, Drawing.FontStyle.Regular)
            .CheckOnClick = True
        End With

        If _Vista = TipoVista.INSERIMENTO Then
            With CheckedListBoxLegenda
                .DataSource = Legenda
                .DisplayMember = "Descrizione"
            End With
            With ButtonSalva
                .Image = Risorse.Immagini.Icon("salva").ToBitmap
                .ImageAlign = Drawing.ContentAlignment.MiddleLeft
                .Text = "Salva"
                .TextAlign = Drawing.ContentAlignment.MiddleRight
            End With
            With LabelSinistro
                .Font = Utx.AppFont.Extra(10, Drawing.FontStyle.Bold)
                .Text = String.Format("{1}{0}{2}", Environment.NewLine, SinistroCorrente.Assicurato.Trim, SinistroCorrente.IdSinistro)
            End With
            LeggiFlag()
        Else
            With CheckedListBoxLegenda
                .DataSource = LeggiTotali()
                .DisplayMember = "Descrizione"
            End With
            With ButtonSalva
                .Image = Risorse.Immagini.Icon("estrai").ToBitmap
                .ImageAlign = Drawing.ContentAlignment.MiddleLeft
                .Text = "Estrai elenco sinistri con i tag selezionati"
                .TextAlign = Drawing.ContentAlignment.MiddleRight
            End With
            With LabelSinistro
                .Font = Utx.AppFont.Extra(10, Drawing.FontStyle.Bold)
                .Text = "Selezionare uno o più tag per applicare il filtro"
            End With
        End If
    End Sub

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click
        'salvare flag
        Try
            If _Vista = TipoVista.INSERIMENTO Then
#If DEBUG Then
                Exit Sub
#End If
                Dim Query As String = String.Format("DELETE 
                    FROM FlagSinistri
                    WHERE Compagnia = {0} AND AgenziaSinistro = {1} AND EsercizioSinistro = {2} AND NumeroSinistro = {3}",
                SinistroCorrente.Compagnia, SinistroCorrente.Agenzia, SinistroCorrente.Esercizio, SinistroCorrente.Numero)

                If CheckedListBoxLegenda.CheckedItems.Count > 0 Then
                    Dim Valori As String = ""
                    For Each Flag In CheckedListBoxLegenda.CheckedItems 'flag è un datarow
                        Valori += String.Format(" ,({0},{1},{2},{3},'{4}')",
                                    SinistroCorrente.Compagnia, SinistroCorrente.Agenzia, SinistroCorrente.Esercizio, SinistroCorrente.Numero, Flag("Codice"))
                    Next
                    Query += String.Format(" INSERT INTO FlagSinistri (Compagnia,AgenziaSinistro,EsercizioSinistro,NumeroSinistro,Flag) VALUES {0}", Valori.Substring(2))
                End If

                Utx.WsCommand.ExecuteNonQuery(Query)
            Else
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Close()
        End Try
    End Sub

    Private Sub FormLegenda_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub LeggiFlag()
        Try
            Dim Query As String = String.Format("SELECT Flag
            FROM FlagSinistri
            WHERE Compagnia = {0} AND AgenziaSinistro = {1} AND EsercizioSinistro = {2} AND NumeroSinistro = {3}",
            SinistroCorrente.Compagnia, SinistroCorrente.Agenzia, SinistroCorrente.Esercizio, SinistroCorrente.Numero)

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            For Each row In dt.Rows
                For k As Integer = 0 To CheckedListBoxLegenda.Items.Count - 1
                    If CheckedListBoxLegenda.Items(k)("Codice") = row("Flag") Then
                        CheckedListBoxLegenda.SetItemChecked(k, True)
                        Exit For
                    End If
                Next
            Next
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function LeggiTotali() As DataTable
        Try
            Dim Query As String = String.Format("SELECT Descrizione + ' (' + FORMAT(f.Occorrenze,'###0') + ' x ' + FORMAT(L.Contributo,'##0.00') + 
                ' = ' + FORMAT(F.Occorrenze * L.Contributo,'#####0.00') + ' euro)' AS Descrizione
                FROM DB00000.dbo.LegendaSinistro AS L
                INNER JOIN (SELECT Flag,COUNT(*) AS Occorrenze FROM DB{0}.dbo.FlagSinistri GROUP BY Flag) AS F
                ON L.Codice = F.Flag
                ORDER BY Descrizione", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)

            Return Utx.WsCommand.ExecuteNonQuery(Query).DataTable
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function
End Class