Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing

Public Class FormChiaviManetunzione

    Private FlagComparer As ListViewItemComparer

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Size = New Size(650, 500)
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = Windows.Forms.FormWindowState.Normal
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Icon = Risorse.Immagini.Icon("strumenti")
        Me.Font = Utx.AppFont.Normal
        Me.Text = "Chiavi manutenzione"

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
            .Sorting = SortOrder.None
            'crea le colonne ripilogo filtro e i riferimento per il ridimensionamento
            .Columns.Add("Chiave", 150, HorizontalAlignment.Left)
            .Columns.Add("Descrizione", 150, HorizontalAlignment.Left)
            .Columns.Add("Eseguita il", 150, HorizontalAlignment.Left)
            .Columns.Add("Categoria", 150, HorizontalAlignment.Left)
            .Columns.Add("Scadenza", 150, HorizontalAlignment.Left)
            .Columns.Add("Periodo", 150, HorizontalAlignment.Left)
        End With
        With ButtonEsegui
            .FlatAppearance.BorderColor = Color.Silver
            .FlatAppearance.MouseOverBackColor = Color.PaleGreen
        End With
        With ButtonEsci
            .FlatAppearance.BorderColor = Color.Silver
            .FlatAppearance.MouseOverBackColor = Color.LightSalmon
        End With
    End Sub

    Private Sub FormChiaviManetunzione_Load(sender As Object, e As EventArgs) Handles Me.Load
        CaricaListaChiavi()
    End Sub

    Private Sub CaricaListaChiavi()
        Try
            Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.LIVE_CHANGE)
            Utx.GestioneFileFlag.InitFlag()

            ListViewChiavi.Items.Clear()
            'ListViewChiavi.Sorting = SortOrder.None
            ListViewChiavi.ListViewItemSorter = Nothing

            For Each ChiaveManutenzione As FileFlag In Utx.GestioneFileFlag.Flag
                With ListViewChiavi.Items.Add(ChiaveManutenzione.Key)
                    .SubItems.Add(ChiaveManutenzione.Descrizione)
                    .SubItems.Add(ChiaveManutenzione.Eseguito)
                    .SubItems.Add(ChiaveManutenzione.CategoriaFlag.ToString)
                    .SubItems.Add(ChiaveManutenzione.Scadenza)
                    .SubItems.Add(ChiaveManutenzione.PeriodoGiorni)
                End With
            Next
            ListViewChiavi.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            'Sort
            FlagComparer = New ListViewItemComparer(2) With {.Order = SortOrder.Descending}
            ListViewChiavi.ListViewItemSorter = FlagComparer
            ListViewChiavi.Sort()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Class ListViewItemComparer
        Implements IComparer

        Public Sub New(column As Integer)
            mColumn = column
        End Sub

        Private mColumn As Integer
        Public Property Column() As Integer
            Get
                Return mColumn
            End Get
            Set(value As Integer)
                mColumn = value
            End Set
        End Property

        Private mOrder As SortOrder
        Public Property Order() As SortOrder
            Get
                Return mOrder
            End Get
            Set(value As SortOrder)
                mOrder = value
            End Set
        End Property

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Dim result As Integer
            Select Case mColumn
                Case 0, 1, 3
                    result = [String].Compare(CType(x, ListViewItem).SubItems(mColumn).Text, CType(y, ListViewItem).SubItems(mColumn).Text)
                Case 2, 4
                    result = [Date].Compare(CType(x, ListViewItem).SubItems(mColumn).Text, CType(y, ListViewItem).SubItems(mColumn).Text)
                Case 5
                    result = Int(CType(x, ListViewItem).SubItems(mColumn).Text).CompareTo(Int(CType(y, ListViewItem).SubItems(mColumn).Text))
            End Select
            If mOrder = SortOrder.Descending Then
                Return -result
            Else
                Return result
            End If
        End Function
    End Class

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub ButtonCartellaFlag_Click(sender As Object, e As EventArgs) Handles ButtonCartellaFlag.Click
        Process.Start(Utx.Globale.Paths.CartellaFlag)
    End Sub

    Private Sub ButtonEsegui_Click(sender As Object, e As EventArgs) Handles ButtonEsegui.Click
        If ListViewChiavi.SelectedItems.Count > 0 Then
            Me.Enabled = False
            'cancello il file chiave ed eseguo la manutenzione
            Dim Flag As New FileFlag(ListViewChiavi.SelectedItems(0).Text, FileFlag.Tipo.LIVE_CHANGE)
            Flag.CancellaFlag()
            'Manutenzione.LiveChangeTardivo()
            Manutenzione.LiveChange()
            CaricaListaChiavi()
            Me.Enabled = True
        End If
    End Sub

    Private Sub ListViewChiavi_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListViewChiavi.ColumnClick
        If e.Column = FlagComparer.Column Then
            If FlagComparer.Order = SortOrder.Ascending Then
                FlagComparer.Order = SortOrder.Descending
            Else
                FlagComparer.Order = SortOrder.Ascending
            End If
        Else
            FlagComparer.Column = e.Column
            FlagComparer.Order = SortOrder.Ascending
        End If
        ListViewChiavi.Sort()
    End Sub

    Private Sub FormChiaviManetunzione_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Utx.GestioneFileFlag.DisposeFlag()
    End Sub
End Class