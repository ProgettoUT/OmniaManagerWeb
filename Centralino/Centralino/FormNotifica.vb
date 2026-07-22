Imports System.Data.OleDb
Imports System.IO
Imports System.Runtime.InteropServices

Public Class FormNotifica

    Public Event EliminaNotifica(ByRef ChiamataDaEliminare As Chiamata)
    Public Event RichiestaAnagrafica(CodiceFiscale As String)
    Public Event RichiestaSinistri(CodiceFiscale As String)

    Private WithEvents TimerVisualizzazione As New Timer

    Sub New(ByRef ChiamataPrecedente As Chiamata)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.Manual
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Font = Utx.AppFont.Normal
        Me.Size = New Size(350, 180)
        Me.Icon = Risorse.Immagini.Icon("telefono")
        Me.Text = "Chiamata in ingresso"
        Me.Name = "Notifica"

        'calcolo la posizione della finestra
        Dim x As Integer = Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 10
        Dim y As Integer = Screen.PrimaryScreen.WorkingArea.Height - Me.Height - 10

        'se c'è una chiamata precedente
        If ChiamataPrecedente IsNot Nothing Then
            For Each n As Object In Application.OpenForms
                If (n.Name = "Notifica") AndAlso (n.Chiamata.Telefono = ChiamataPrecedente.Telefono) Then
                    y = n.Top - Me.Height
                End If
            Next
        End If

        Me.Location = New Point(x, y)

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With LabelTelefono
            .Font = Utx.AppFont.Extra(10, FontStyle.Regular)
            .Padding = New Padding(5)
            .BackColor = Color.Silver
            .Text = ""
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With LabelAgenzia
            .Font = Utx.AppFont.Extra(10, FontStyle.Regular)
            .Padding = New Padding(5)
            .ForeColor = Color.DodgerBlue
            .BackColor = Color.Silver
            .Text = ""
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With LabelNome
            .Font = Utx.AppFont.Extra(11, FontStyle.Bold)
            .Padding = New Padding(5)
            .BackColor = Color.Gainsboro
            .Text = ""
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With LabelAltriDati
            .Font = Utx.AppFont.Extra(9, FontStyle.Regular)
            .Padding = New Padding(5)
            .BackColor = Color.Gainsboro
            .Text = ""
            .TextAlign = ContentAlignment.MiddleRight
        End With
        ImpostaBottoni(2)
    End Sub

    Private mSecondi As Integer
    Public Property Secondi() As Integer
        Get
            Return mSecondi
        End Get
        Set(value As Integer)
            mSecondi = value
        End Set
    End Property

    Private mChiamata As Chiamata
    Public Property Chiamata() As Chiamata
        Get
            Return mChiamata
        End Get
        Set(value As Chiamata)
            mChiamata = value
        End Set
    End Property

    Private mListaAgenzie As List(Of String)
    Public Property ListaAgenzie() As List(Of String)
        Get
            Return mListaAgenzie
        End Get
        Set(value As List(Of String))
            mListaAgenzie = value
        End Set
    End Property

    Private Sub FormNotifica_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        TimerVisualizzazione.Dispose()
        RaiseEvent EliminaNotifica(mChiamata)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        LabelTelefono.Text = String.Format("Telefono {0}", mChiamata.Telefono)
        TimerVisualizzazione.Interval = mSecondi * 1000
        TimerVisualizzazione.Enabled = True
    End Sub

    Private Sub TimerVisualizzazione_Tick(sender As Object, e As EventArgs) Handles TimerVisualizzazione.Tick
        Me.Close()
    End Sub

    Private Sub FormNotifica_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FormAvvioCentralino.ElencoNotifiche.Add(Me)

        Utx.NetFunc.FinestraOnTop(Me.Handle, True)
        Utx.NetFunc.FinestraOnTop(Me.Handle, False)

        LabelNome.Refresh()

        LeggiCliente()
    End Sub

    Private Sub LeggiCliente()
        Try
            'ricerca per tutte le agenzie gestite
            For Each agenzia As String In ListaAgenzie

                Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(agenzia, Utx.ConnessioniDb.Db.CLIENTI))
                    c.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "SELECT TOP 1 CodiceFiscale,Cognome,Nome,SubAgenzia,Localita,DataNascita " +
                                          "FROM Clienti " +
                                          "WHERE (Trim(Telefono1) = ?) OR (Trim(Telefono2) = ?) OR (Trim(Cellulare) = ?) OR " +
                                                "(Trim(TelReferente) = ?) OR (Trim(TelAziendale) = ?)"

                        cmd.Parameters.AddWithValue("Tel1", mChiamata.Telefono)
                        cmd.Parameters.AddWithValue("Tel2", mChiamata.Telefono)
                        cmd.Parameters.AddWithValue("Tel3", mChiamata.Telefono)
                        cmd.Parameters.AddWithValue("Tel4", mChiamata.Telefono)
                        cmd.Parameters.AddWithValue("Tel5", mChiamata.Telefono)

                        Dim dr As OleDbDataReader = cmd.ExecuteReader

                        If dr.HasRows Then
                            dr.Read()

                            mChiamata.Agenzia = agenzia
                            mChiamata.CodiceFiscale = dr("CodiceFiscale")
                            mChiamata.Nome = String.Format("{0} {1}", Trim(dr("Nome")), Trim(dr("Cognome")))

                            LabelAgenzia.Text = String.Format("{0}-{1}", agenzia, dr("SubAgenzia"))
                            LabelNome.Text = mChiamata.Nome
                            LabelAltriDati.Text = String.Format("Località: {1}{0}Data di nascita: {2:dd-MM-yyyy}", Environment.NewLine, dr("Localita").ToString.Trim, dr("DataNascita"))

                            Exit For
                        Else
                            ImpostaBottoni(1)
                        End If
                    End Using
                End Using
            Next

            If String.IsNullOrEmpty(LabelNome.Text) Then
                LabelNome.Text = "Anagrafica non disponibile..."
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ImpostaBottoni(Modo As Integer)
        'modo=1 (bottone) o 2 (bottoni)
        If Modo = 1 Then
            ButtonSinistri.Visible = False
            ButtonAnag.Text = "Apri blocco appunti"
            tlpMain.SetColumnSpan(ButtonAnag, 3)
        Else
            tlpMain.SetColumnSpan(ButtonAnag, 1)
            ButtonAnag.Text = "Anagrafica"
            ButtonSinistri.Text = "Sinistri"
            ButtonAnag.Visible = True
            ButtonSinistri.Visible = True
        End If
    End Sub

    Private Sub LabelNotifica_TextChanged(sender As Object, e As EventArgs) Handles LabelNome.TextChanged
        LabelNome.Refresh()
    End Sub

    Private Sub ButtonAnag_Click(sender As Object, e As EventArgs) Handles ButtonAnag.Click
        Try
            If mChiamata.Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia Then
                RaiseEvent RichiestaAnagrafica(mChiamata.CodiceFiscale)
            Else
                'se l'agenzia di appartenenza del cliente è diversa da quella attualmente selezionata
                Dim f As New FormNote(mChiamata)
                f.Show()
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonSinistri_Click(sender As Object, e As EventArgs) Handles ButtonSinistri.Click
        Try
            If mChiamata.Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia Then
                RaiseEvent RichiestaSinistri(mChiamata.CodiceFiscale)
            Else
                'se l'agenzia di appartenenza del cliente è diversa da quella attualmente selezionata
                Dim f As New FormNote(mChiamata)
                f.Show()
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
