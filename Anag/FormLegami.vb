Imports System.Windows.Forms
Imports System.Drawing

Public Class FormLegami

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.Size = New Size(750, 350)
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("legami")
        Me.Text = "Legami capofamiglia-ente"
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

    Private mCapofamigliaCF As String
    Public ReadOnly Property CapofamigliaCF() As String
        Get
            Return mCapofamigliaCF
        End Get
    End Property

    Private mEnteCF As String
    Public ReadOnly Property EnteCF() As String
        Get
            Return mEnteCF
        End Get
    End Property

    Private Sub ImpostaControlli()
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
        With ButtonElimina
            .Margin = New Padding(0)
            .Padding = New Padding(10, 0, 10, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Elimina legami"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ButtonCapofamiglia
            .Margin = New Padding(0)
            .Padding = New Padding(20, 0, 20, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("cliente")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = String.Format("Imposta come{0}capofamiglia", Environment.NewLine)
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ButtonEnte
            .Margin = New Padding(0)
            .Padding = New Padding(20, 0, 20, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("agenzia")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = String.Format("Imposta come{0}ente di appartenenza", Environment.NewLine)
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ButtonEsci
            .Margin = New Padding(0)
            .Padding = New Padding(10, 0, 10, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Esci"
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
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub FormLegami_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LabelCliente.Text = "Legami di " + mNomeCompleto
        TextBoxCerca.Focus()
    End Sub

    Private Sub CercaCliente()
        Try
            If TextBoxCerca.Text.Length > 0 Then
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

                Dim Query As String = String.Format("SELECT Cognome,Nome,Indirizzo,Localita,DataNascita AS [Nato il],CodiceFiscale AS CF 
                    FROM Clienti WHERE {0}", Clausola)

                Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(Query)
                If Risposta IsNot Nothing Then
                    dgvClienti.DataSource = Risposta.DataTable
                    dgvClienti.AutoResizeColumns()
                End If
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonCerca_Click(sender As Object, e As EventArgs) Handles ButtonCerca.Click
        CercaCliente()
    End Sub

    Private Sub ButtonElimina_Click(sender As Object, e As EventArgs) Handles ButtonElimina.Click
        DialogResult = Windows.Forms.DialogResult.Retry
    End Sub

    Private Sub ButtonCapofamiglia_Click(sender As Object, e As EventArgs) Handles ButtonCapofamiglia.Click
        If dgvClienti.CurrentRow Is Nothing Then
            MsgBox("Seleziona prima un cliente.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        Else
            mCapofamigliaCF = dgvClienti.CurrentRow.Cells("CF").Value
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub ButtonEnte_Click(sender As Object, e As EventArgs) Handles ButtonEnte.Click
        If dgvClienti.CurrentRow Is Nothing Then
            MsgBox("Seleziona prima un cliente.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        Else
            mEnteCF = dgvClienti.CurrentRow.Cells("CF").Value
            DialogResult = Windows.Forms.DialogResult.Yes
        End If
    End Sub
End Class
