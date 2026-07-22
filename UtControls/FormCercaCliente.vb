Imports System.Windows.Forms
Imports System.Drawing

Public Class FormCercaCliente

    Public Enum TipoSelezione
        CLIENTE
        SINISTRO
    End Enum

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.Size = New Size(750, 400)
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("cerca16")
        Me.Text = "Cerca cliente"
        Me.AcceptButton = ButtonCerca

        ImpostaControlli()
    End Sub

    Private mCodiceFiscale As String
    Public Property CodiceFiscale() As String
        Get
            Return mCodiceFiscale
        End Get
        Set(value As String)
            mCodiceFiscale = value
        End Set
    End Property

    Private mNomeCompleto As String
    Public Property NomeCompleto() As String
        Get
            Return mNomeCompleto
        End Get
        Set(value As String)
            mNomeCompleto = value
        End Set
    End Property

    Private mIdSinistro As String
    Public ReadOnly Property IdSinistro() As String
        Get
            Return mIdSinistro
        End Get
    End Property

    Private mVisualizzaSinistri As Boolean
    Public Property VisualizzaSinistri() As Boolean
        Get
            Return mVisualizzaSinistri
        End Get
        Set(value As Boolean)
            mVisualizzaSinistri = value

            If mVisualizzaSinistri = True Then
                With tlpMain
                    With .RowStyles.Item(1)
                        .SizeType = SizeType.Percent
                        .Height = 50
                    End With
                    With .RowStyles.Item(2) 'griglia sinistri
                        .SizeType = SizeType.Percent
                        .Height = 50
                    End With
                End With
            Else
                With tlpMain
                    With .RowStyles.Item(1)
                        .SizeType = SizeType.Percent
                        .Height = 100
                    End With
                    With .RowStyles.Item(2)
                        .SizeType = SizeType.Percent
                        .Height = 0
                    End With
                End With
            End If
        End Set
    End Property

    Private mSelezione As TipoSelezione
    Public ReadOnly Property Selezione() As TipoSelezione
        Get
            Return mSelezione
        End Get
    End Property

    Private Sub ImpostaControlli()

        With tlpMain
            With .RowStyles.Item(0)
                .SizeType = SizeType.Absolute
                .Height = 25
            End With
            With .RowStyles.Item(1)
                .SizeType = SizeType.Percent
                .Height = 100
            End With
            With .RowStyles.Item(2)
                .SizeType = SizeType.Percent
                .Height = 0
            End With
            With .RowStyles.Item(3)
                .SizeType = SizeType.Absolute
                .Height = 50
            End With
        End With

        With ButtonCerca
            .Margin = New Padding(0)
            .Padding = New Padding(10, 0, 10, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .Dock = DockStyle.Fill
            .BackColor = Color.Gainsboro
            .Image = Risorse.Immagini.Bitmap("cerca16")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Cerca cliente"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ButtonOk
            .Margin = New Padding(0)
            .Padding = New Padding(20, 0, 20, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("ok32")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Seleziona cliente"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ButtonAnnulla
            .Margin = New Padding(0)
            .Padding = New Padding(10, 0, 10, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Annulla"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With dgvClienti
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .Margin = New Padding(1)
        End With
        With dgvSinistri
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .Margin = New Padding(1)
        End With
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub FormCercaCliente_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            TextBoxCerca.Text = mNomeCompleto.Trim
            TextBoxCerca.Focus()
            CercaCliente()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CercaCliente()
        Try
            If TextBoxCerca.Text.Length > 0 Then

                Cursor = Cursors.WaitCursor

                dgvClienti.DataSource = Nothing
                dgvClienti.Refresh()

                Dim Sql As String = "SELECT Cognome,Nome,Indirizzo,Localita,DataNascita AS [Nato il],CodiceFiscale AS CF
                                     FROM Clienti WHERE {0}"
                'creo i tag
                Dim Tag As String = " ((Cognome + ' ' + Nome) LIKE '%{0}%') "
                Dim Tags() As String = TextBoxCerca.Text.Split(Space(1))

                For k = 0 To Tags.GetUpperBound(0)
                    Tags(k) = String.Format(Tag, Tags(k).Replace("'", "").Replace("""", ""))
                Next
                'creo la clausola
                Dim Clausola As String = Tags(0)
                For k = 1 To Tags.GetUpperBound(0)
                    Clausola += " AND " + Tags(k)
                Next
                'completo la query
                Sql = String.Format(Sql, Clausola)

                dgvClienti.DataSource = Utx.WsCommand.ExecuteNonQuery(Sql).DataTable
                dgvClienti.AutoResizeColumns()

                dgvClienti_Click(Me, New EventArgs)
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CercaSinistri()
        Try
            If dgvClienti.CurrentRow IsNot Nothing Then
                Cursor = Cursors.WaitCursor

                dgvSinistri.DataSource = Nothing
                dgvSinistri.Refresh()

                Dim Sql As String = String.Format("SELECT Format(Compagnia,'0') + '-' + Format(AgenziaSinistro,'0000') + '-' + 
                    Format(EsercizioSinistro,'0000') + '-' + Format(NumeroSinistro,'0000000') AS Sinistro,
                    CognomeDanneggiato AS Controparte 
                    FROM Sinistri 
                    WHERE CodiceFiscContrPol = '{0}' 
                    ORDER BY EsercizioSinistro DESC,NumeroSinistro DESC", dgvClienti.CurrentRow.Cells("CF").Value)

                dgvSinistri.DataSource = Utx.WsCommand.ExecuteNonQuery(Sql).DataTable
                dgvSinistri.AutoResizeColumns()
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonCerca_Click(sender As Object, e As EventArgs) Handles ButtonCerca.Click
        CercaCliente()
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        Try
            If dgvClienti.CurrentRow IsNot Nothing Then

                mCodiceFiscale = dgvClienti.CurrentRow.Cells("CF").Value
                mNomeCompleto = String.Format("{0} {1}",
                                             dgvClienti.CurrentRow.Cells("Cognome").Value.ToString.Trim,
                                             dgvClienti.CurrentRow.Cells("Nome").Value.ToString.Trim)

                If dgvSinistri.CurrentRow IsNot Nothing Then
                    mIdSinistro = dgvSinistri.CurrentRow.Cells("Sinistro").Value
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If

                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub dgvClienti_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvClienti.CurrentCellChanged
        If mVisualizzaSinistri = True Then
            CercaSinistri()
        End If
    End Sub

    Private Sub dgvClienti_Click(sender As Object, e As EventArgs) Handles dgvClienti.Click
        If dgvClienti.CurrentRow IsNot Nothing Then
            With dgvSinistri.DefaultCellStyle
                .SelectionBackColor = Color.Gainsboro
                .SelectionForeColor = Color.Black
            End With
            With dgvClienti.DefaultCellStyle
                .SelectionBackColor = Color.DodgerBlue
                .SelectionForeColor = Color.White
            End With
            mSelezione = TipoSelezione.CLIENTE
            ButtonOk.Text = String.Format("Seleziona {0} {1}",
                                          dgvClienti.CurrentRow.Cells("Cognome").Value.ToString.Trim,
                                          dgvClienti.CurrentRow.Cells("Nome").Value.ToString.Trim)
        End If
    End Sub

    Private Sub dgvSinistri_Click(sender As Object, e As EventArgs) Handles dgvSinistri.Click
        If dgvSinistri.CurrentRow IsNot Nothing Then
            With dgvSinistri.DefaultCellStyle
                .SelectionBackColor = Color.DodgerBlue
                .SelectionForeColor = Color.White
            End With
            With dgvClienti.DefaultCellStyle
                .SelectionBackColor = Color.Gainsboro
                .SelectionForeColor = Color.Black
            End With
            mSelezione = TipoSelezione.SINISTRO
            ButtonOk.Text = String.Format("Seleziona sinistro {0}", dgvSinistri.CurrentRow.Cells("Sinistro").Value)
        End If
    End Sub

    Private Sub dgvClienti_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvClienti.CellMouseDoubleClick
        ButtonOk.PerformClick()
    End Sub
End Class
