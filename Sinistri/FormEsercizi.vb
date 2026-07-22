Imports System.Windows.Forms
Imports System.Drawing

Public Class FormEsercizi

    Sub New(Posizione As Point)
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Padding = New Padding(3)
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Drawing.Point(Posizione)
        Me.Font = Utx.AppFont.Normal
        Me.Size = New Size(330, 300)

        ImpostaControlli()
    End Sub

    Private mEsercizi As List(Of Integer)
    Public Property Esercizi() As List(Of Integer)
        Get
            Return mEsercizi
        End Get
        Set(value As List(Of Integer))
            mEsercizi = value
        End Set
    End Property

    Private mMesi As List(Of Integer)
    Public Property Mesi() As List(Of Integer)
        Get
            Return mMesi
        End Get
        Set(value As List(Of Integer))
            mMesi = value
        End Set
    End Property

    Private Sub ImpostaControlli()
        CheckedListBoxEsercizi.CheckOnClick = True
        CheckedListBoxMesi.CheckOnClick = True

        With ButtonOk
            .BackColor = SystemColors.Control
            .Text = "Ok"
        End With
        With ButtonAnnulla
            .Text = "Annulla"
            .BackColor = SystemColors.Control
        End With
    End Sub

    Private Sub FormEsercizi_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Refresh()
        LeggiEsercizi() 'leggi gli esercizi dai dal db
        InitMesi()
        AddHandler CheckedListBoxEsercizi.ItemCheck, AddressOf CheckedListBoxEsercizi_ItemCheck
        AddHandler CheckedListBoxMesi.ItemCheck, AddressOf CheckedListBoxMesi_ItemCheck
    End Sub

    Private Sub LeggiEsercizi()
        Try
            Cursor = Cursors.WaitCursor

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery("SELECT DISTINCT EsercizioSinistro 
                FROM SinistriDP ORDER BY EsercizioSinistro DESC").DataTable

            CheckedListBoxEsercizi.Items.Clear()

            If mEsercizi.Count = 0 Then
                'se la selezione è tutti gli esercizi
                CheckedListBoxEsercizi.Items.Add(New Esercizio(0), True) 'item TUTTI
                For Each dr As DataRow In dt.Rows
                    CheckedListBoxEsercizi.Items.Add(New Esercizio(dr("EsercizioSinistro")), True)
                Next
            Else
                'se sono selezionati solo alcuni esercizi
                CheckedListBoxEsercizi.Items.Add(New Esercizio(0), False) 'item TUTTI
                For Each dr As DataRow In dt.Rows
                    CheckedListBoxEsercizi.Items.Add(New Esercizio(dr("EsercizioSinistro")),
                                                     mEsercizi.Contains(dr("EsercizioSinistro")))
                Next
            End If
            CheckedListBoxEsercizi.DisplayMember = "Descrizione"

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub InitMesi()
        If mMesi.Count = 0 Then
            CheckedListBoxMesi.Items.Add(New Mese(0), True)
            For k As Integer = 1 To 12
                CheckedListBoxMesi.Items.Add(New Mese(k), True)
            Next
        Else
            CheckedListBoxMesi.Items.Add(New Mese(0), False)
            For k As Integer = 1 To 12
                CheckedListBoxMesi.Items.Add(New Mese(k), mMesi.Contains(k))
            Next
        End If
        CheckedListBoxMesi.DisplayMember = "Descrizione"
    End Sub

    Private Sub CheckedListBoxEsercizi_ItemCheck(sender As Object, e As ItemCheckEventArgs)
        RemoveHandler CheckedListBoxEsercizi.ItemCheck, AddressOf CheckedListBoxEsercizi_ItemCheck

        If e.Index = 0 Then
            'seleziona/deseleziona tutti
            For k As Integer = 1 To CheckedListBoxEsercizi.Items.Count - 1
                CheckedListBoxEsercizi.SetItemChecked(k, e.NewValue)
            Next
        Else
            If e.NewValue = CheckState.Unchecked Then
                CheckedListBoxEsercizi.SetItemChecked(0, e.NewValue)
            Else
                'se gli elementi deselezionati prima della modifica erano solo 2
                If CheckedListBoxEsercizi.CheckedItems.Count = CheckedListBoxEsercizi.Items.Count - 2 Then
                    'allora selezionare (seleziona tutti)
                    CheckedListBoxEsercizi.SetItemChecked(0, True)
                End If
            End If
        End If

        AddHandler CheckedListBoxEsercizi.ItemCheck, AddressOf CheckedListBoxEsercizi_ItemCheck
    End Sub

    Private Sub CheckedListBoxMesi_ItemCheck(sender As Object, e As ItemCheckEventArgs)
        RemoveHandler CheckedListBoxMesi.ItemCheck, AddressOf CheckedListBoxMesi_ItemCheck

        If e.Index = 0 Then
            'seleziona/deseleziona tutti
            For k As Integer = 1 To 12
                CheckedListBoxMesi.SetItemChecked(k, e.NewValue)
            Next
        Else
            If e.NewValue = CheckState.Unchecked Then
                CheckedListBoxMesi.SetItemChecked(0, e.NewValue)
            Else
                'se gli elementi deselezionati prima della modifica erano solo 2
                If CheckedListBoxMesi.CheckedItems.Count = CheckedListBoxMesi.Items.Count - 2 Then
                    'allora selezionare (seleziona tutti)
                    CheckedListBoxMesi.SetItemChecked(0, True)
                End If
            End If
        End If

        AddHandler CheckedListBoxMesi.ItemCheck, AddressOf CheckedListBoxMesi_ItemCheck
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        If CheckedListBoxEsercizi.CheckedItems.Count = 0 Then
            MsgBox("E' necessario selezionare almeno un esercizio.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        ElseIf CheckedListBoxMesi.CheckedItems.Count = 0 Then
            MsgBox("E' necessario selezionare almeno un mese.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        Else
            'esercizi
            mEsercizi.Clear()
            If CheckedListBoxEsercizi.GetItemChecked(0) = True Then
                'seleziona tutti lascio la lista vuota
            Else
                For k As Integer = 1 To CheckedListBoxEsercizi.Items.Count - 1
                    If CheckedListBoxEsercizi.GetItemChecked(k) = True Then
                        mEsercizi.Add(CheckedListBoxEsercizi.Items(k).Anno)
                    End If
                Next
            End If
            'mesi
            mMesi.Clear()
            If CheckedListBoxMesi.GetItemChecked(0) = True Then
                'seleziona tutti lascio la lista vuota
            Else
                For k As Integer = 1 To 12
                    If CheckedListBoxMesi.GetItemChecked(k) = True Then
                        mMesi.Add(CheckedListBoxMesi.Items(k).Mese)
                    End If
                Next
            End If

            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Class Esercizio

        Sub New(Anno As Integer)
            mAnno = Anno
        End Sub

        Private mAnno As Integer
        Public ReadOnly Property Anno() As Integer
            Get
                Return mAnno
            End Get
        End Property

        Public ReadOnly Property Descrizione() As String
            Get
                If mAnno = 0 Then
                    Return "Tutti gli esercizi"
                Else
                    Return String.Format("Esercizio {0}", mAnno)
                End If
            End Get
        End Property
    End Class

    Private Class Mese

        Sub New(Mese As Integer)
            mMese = Mese
        End Sub

        Private mMese As Integer
        Public ReadOnly Property Mese() As Integer
            Get
                Return mMese
            End Get
        End Property

        Public ReadOnly Property Descrizione() As String
            Get
                If mMese = 0 Then
                    Return "Tutti i mesi"
                Else
                    Return String.Format("{0:00} {1}", mMese, MonthName(mMese))
                End If
            End Get
        End Property
    End Class
End Class