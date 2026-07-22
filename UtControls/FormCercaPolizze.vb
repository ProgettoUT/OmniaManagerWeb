Imports System.Drawing
Imports System.Windows.Forms

Public Class FormCercaPolizze

    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.Size = New Size(600, 400)
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("cerca16")
        Me.Text = "Cerca polizza"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With ButtonOk
            .Margin = New Padding(0)
            .Padding = New Padding(20, 0, 20, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("ok32")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Seleziona polizza"
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
        With dgvPolizze
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

    Private _CodiceFiscale As String
    Public Property CodiceFiscale() As String
        Get
            Return _CodiceFiscale
        End Get
        Set(value As String)
            _CodiceFiscale = value
        End Set
    End Property

    Private _Ramo As String
    Public ReadOnly Property Ramo() As String
        Get
            Return _Ramo
        End Get
    End Property

    Private _Polizza As String
    Public ReadOnly Property Polizza() As String
        Get
            Return _Polizza
        End Get
    End Property

    Private _SubAgenzia As String
    Public ReadOnly Property SubAgenzia() As String
        Get
            Return _SubAgenzia
        End Get
    End Property

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        If dgvPolizze.CurrentRow IsNot Nothing Then
            _Ramo = dgvPolizze.CurrentRow.Cells("Ramo").Value
            _Polizza = dgvPolizze.CurrentRow.Cells("Polizza").Value
            _SubAgenzia = dgvPolizze.CurrentRow.Cells("Sub").Value
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub LeggiPolizze()
        Try
            Dim Query As String = String.Format("SELECT Ramo,Polizza,DataEffetto AS Effetto,CodiceSubAgente AS Sub,Targa,Convenzione 
                FROM Polizze 
                WHERE CodiceFiscale = '{0}'", _CodiceFiscale)
            dgvPolizze.DataSource = Utx.WsCommand.ExecuteNonQuery(Query).DataTable
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormCercaPolizze_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LeggiPolizze()
    End Sub

    Private Sub dgvPolizze_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvPolizze.CellMouseDoubleClick
        ButtonOk.PerformClick()
    End Sub
End Class