Imports System.Data.OleDb
Imports System.Drawing
Imports Utx.SettingAgenzia

Public Class FormRipristino

    Public CodiceFiscale As String = ""

    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.Size = New Drawing.Size(450, 190)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Font = Utx.AppFont.Normal
        Me.Text = "Ripristino sinistri da storico"
        Me.Icon = Risorse.Immagini.Icon("sincro")

        ImpostaControlli()
    End Sub

    Private _DP As Integer
    Public ReadOnly Property DP() As Integer
        Get
            Return _DP
        End Get
    End Property

    Private _DA As Integer
    Public ReadOnly Property DA() As Integer
        Get
            Return _DA
        End Get
    End Property

    Private Sub ImpostaControlli()
        With ButtonRipristina
            .Padding = Utx.AppFont.ButtonPadding
            .Image = Risorse.Immagini.Bitmap("sincro")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Ripristina"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ButtonEsci
            .Padding = Utx.AppFont.ButtonPadding
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Esci"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        Label4.Font = Utx.AppFont.Extra(8, Drawing.FontStyle.Italic)
    End Sub

    Private Sub FormRipristino_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBoxCF.Text = CodiceFiscale
    End Sub

    Private Sub FormRipristino_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CodiceFiscale.TrimEnd.Length = 0 Then
            TextBoxCF.Focus()
        Else
            TextBoxNumeroSinistro.Focus()
        End If
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub TextBoxCF_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCF.TextChanged
        If TextBoxCF.Text.Length > 0 Then
            TextBoxNumeroSinistro.Text = ""
            TextBoxAnno.Text = ""
        End If
    End Sub

    Private Sub TextBoxNumeroSinistro_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNumeroSinistro.TextChanged
        If TextBoxNumeroSinistro.Text.Length > 0 Then
            TextBoxAnno.Text = ""
            TextBoxCF.Text = ""
        End If
    End Sub

    Private Sub TextBoxAnno_TextChanged(sender As Object, e As EventArgs) Handles TextBoxAnno.TextChanged
        If TextBoxAnno.Text.Length > 0 Then
            TextBoxNumeroSinistro.Text = ""
            TextBoxCF.Text = ""
        End If
    End Sub

    Private Function ControlloDati() As Boolean
        Try
            If String.IsNullOrEmpty(TextBoxCF.Text.Trim) And
               String.IsNullOrEmpty(TextBoxNumeroSinistro.Text.Trim) And
               String.IsNullOrEmpty(TextBoxAnno.Text.Trim) Then
                MsgBox("Impostare codice fiscale, numero sinistro o esercizio.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Return False
            ElseIf TextBoxCF.Text.Length > 0 And TextBoxCF.Text.Length <> 11 And TextBoxCF.Text.Length <> 16 Then
                MsgBox("Codice fiscale non valido", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                TextBoxCF.Focus()
                Return False
            ElseIf TextBoxNumeroSinistro.Text.Length > 0 AndAlso TextBoxNumeroSinistro.Text.Length <> 19 Then
                MsgBox("Numero sinistro deve essere in formato x-xxxx-xxxx-xxxxxxx", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                TextBoxNumeroSinistro.Focus()
                Return False
            ElseIf TextBoxNumeroSinistro.Text.Length > 0 AndAlso TextBoxNumeroSinistro.Text.Split("-").GetUpperBound(0) <> 3 Then
                MsgBox("Numero sinistro deve essere in formato x-xxxx-xxxx-xxxxxxx", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                TextBoxNumeroSinistro.Focus()
                Return False
            ElseIf TextBoxAnno.Text.Length > 0 AndAlso TextBoxAnno.Text.Length <> 4 Then
                MsgBox("Anno non valido: inserire l'anno con 4 cifre", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                TextBoxAnno.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Sub ButtonRipristina_Click(sender As Object, e As EventArgs) Handles ButtonRipristina.Click
        Try
            If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.ESECUZIONE_MERGE_DATI, 10) = False Then

                If ControlloDati() = True Then
                    Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                        c.Open()
                        If TextBoxNumeroSinistro.Text.Length = 0 AndAlso TextBoxAnno.Text.Length = 0 Then
                            RipristinaCF(c)
                        ElseIf TextBoxNumeroSinistro.Text.Length > 0 Then
                            RipristinaNumeroSinistro(c)
                        ElseIf TextBoxAnno.Text.Length > 0 Then
                            RipristinaAnno(c)
                        End If
                    End Using
                End If
            Else
                MsgBox("Consolidamento dati in corso. Attendere la fine e riprovare.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub RipristinaCF(c As OleDbConnection)
        Try
            CodiceFiscale = TextBoxCF.Text.Trim

            'sinistri
            Using cmd As New OleDbCommand
                cmd.Connection = c
                cmd.CommandType = CommandType.Text
                'DP
                If Utx.FunzioniDb.EsisteTabella(c, "SinistriDP") = False Then
                    MsgBox("Nella base dati utilizzata attualmente non esiste uno storico delega propria", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Else
                    cmd.CommandText = String.Format("INSERT INTO SinistriDP SELECT DISTINCT * FROM SinistriDP IN '{0}' WHERE CODICEFISCCONTRPOL = '{1}'",
                                                Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.UTSTORICO), CodiceFiscale)
                    _DP = cmd.ExecuteNonQuery
                    Globale.Log.Info("Ripristinati {0} sinistri DP", {DP})
                    cmd.CommandText = String.Format("DELETE * FROM SinistriDP IN '{0}' WHERE CODICEFISCCONTRPOL = '{1}'",
                                                Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.UTSTORICO), CodiceFiscale)
                    cmd.ExecuteNonQuery()
                End If
                'DA
                If CheckBoxDP.Checked = False Then
                    If Utx.FunzioniDb.EsisteTabella(c, "SinistriDA") = False Then
                        MsgBox("Nella base dati utilizzata attualmente non esiste uno storico delega altrui", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    Else
                        cmd.CommandText = String.Format("INSERT INTO SinistriDA SELECT DISTINCT * FROM SinistriDA IN '{0}' WHERE CODICEFISCCONTRPOL = '{1}'",
                                                    Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.UTSTORICO), CodiceFiscale)
                        _DA = cmd.ExecuteNonQuery
                        cmd.CommandText = String.Format("DELETE * FROM SinistriDA IN '{0}' WHERE CODICEFISCCONTRPOL = '{1}'",
                                                Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.UTSTORICO), CodiceFiscale)
                        cmd.ExecuteNonQuery()
                        Globale.Log.Info("Ripristinati {0} sinistri DA", {DA})
                    End If
                End If
            End Using
            Notifica(DP, DA)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub RipristinaNumeroSinistro(c As OleDbConnection)
        Try
            'numero sinistro
            TextBoxNumeroSinistro.Text = TextBoxNumeroSinistro.Text.Trim
            Dim Compagnia As Integer = TextBoxNumeroSinistro.Text.Split("-")(0)
            Dim Ente As Integer = TextBoxNumeroSinistro.Text.Split("-")(1)
            Dim Esercizio As Integer = TextBoxNumeroSinistro.Text.Split("-")(2)
            Dim Numero As Integer = TextBoxNumeroSinistro.Text.Split("-")(3)

            Using cmd As New OleDbCommand
                cmd.Connection = c
                cmd.CommandType = CommandType.Text
                If Utx.FunzioniDb.EsisteTabella(c, "SinistriDP") = False Then
                    MsgBox("Nella base dati utilizzata attualmente non esiste uno storico delega propria", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Else
                    'DP
                    cmd.CommandText = String.Format("INSERT INTO SinistriDP SELECT DISTINCT * FROM SinistriDP IN '{0}' " +
                                                "WHERE Compagnia = {1} AND AgenziaSinistro = {2} AND EsercizioSinistro = {3} AND NumeroSinistro = {4}",
                                                Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.UTSTORICO),
                                                Compagnia, Ente, Esercizio, Numero)
                    _DP = cmd.ExecuteNonQuery
                    Globale.Log.Info("Ripristinati {0} sinistri DP", {DP})
                    cmd.CommandText = String.Format("DELETE * FROM SinistriDP IN '{0}' " +
                                                "WHERE Compagnia = {1} AND AgenziaSinistro = {2} AND EsercizioSinistro = {3} AND NumeroSinistro = {4}",
                                                Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.UTSTORICO),
                                                Compagnia, Ente, Esercizio, Numero)
                    cmd.ExecuteNonQuery()
                End If
                'DA
                If CheckBoxDP.Checked = False Then
                    If DP = 0 Then
                        If Utx.FunzioniDb.EsisteTabella(c, "SinistriDA") = False Then
                            MsgBox("Nella base dati utilizzata attualmente non esiste uno storico delega altrui", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                        Else
                            cmd.CommandText = String.Format("INSERT INTO SinistriDA SELECT DISTINCT * FROM SinistriDA IN '{0}' " +
                                                        "WHERE Compagnia = {1} AND AgenziaSinistro = {2} AND EsercizioSinistro = {3} AND NumeroSinistro = {4}",
                                                        Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.UTSTORICO),
                                                        Compagnia, Ente, Esercizio, Numero)
                            _DA = cmd.ExecuteNonQuery
                            Globale.Log.Info("Ripristinati {0} sinistri DA", {DA})
                            cmd.CommandText = String.Format("DELETE * FROM SinistriDA IN '{0}' " +
                                                        "WHERE Compagnia = {1} AND AgenziaSinistro = {2} AND EsercizioSinistro = {3} AND NumeroSinistro = {4}",
                                                        Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.UTSTORICO),
                                                        Compagnia, Ente, Esercizio, Numero)
                            cmd.ExecuteNonQuery()
                        End If
                    End If
                End If
            End Using
            Notifica(DP, DA)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub RipristinaAnno(c As OleDbConnection)
        Try
            'sinistri
            Using cmd As New OleDbCommand
                cmd.Connection = c
                cmd.CommandType = CommandType.Text
                'DP
                If Utx.FunzioniDb.EsisteTabella(c, "SinistriDP") = False Then
                    MsgBox("Nella base dati utilizzata attualmente non esiste uno storico delega propria", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Else
                    cmd.CommandText = String.Format("INSERT INTO SinistriDP SELECT DISTINCT * FROM SinistriDP IN '{0}' WHERE EsercizioSinistro = {1}",
                                                    Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.UTSTORICO), TextBoxAnno.Text)
                    _DP = cmd.ExecuteNonQuery
                    Globale.Log.Info("Ripristinati {0} sinistri DP", {DP})
                    cmd.CommandText = String.Format("DELETE * FROM SinistriDP IN '{0}' WHERE EsercizioSinistro = {1}",
                                                    Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.UTSTORICO), TextBoxAnno.Text)
                    cmd.ExecuteNonQuery()
                End If
                'DA
                If CheckBoxDP.Checked = False Then
                    If Utx.FunzioniDb.EsisteTabella(c, "SinistriDA") = False Then
                        MsgBox("Nella base dati utilizzata attualmente non esiste uno storico delega altrui", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    Else
                        cmd.CommandText = String.Format("INSERT INTO SinistriDA SELECT DISTINCT * FROM SinistriDA IN '{0}' WHERE EsercizioSinistro = {1}",
                                                    Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.UTSTORICO), TextBoxAnno.Text)
                        _DA = cmd.ExecuteNonQuery
                        cmd.CommandText = String.Format("DELETE * FROM SinistriDA IN '{0}' WHERE EsercizioSinistro = {1}",
                                                    Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.UTSTORICO), TextBoxAnno.Text)
                        cmd.ExecuteNonQuery()
                    End If
                End If
                Globale.Log.Info("Ripristinati {0} sinistri DA", {DA})
            End Using
            Notifica(DP, DA)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub Notifica(DP As Integer, DA As Integer)
        MsgBox(String.Format("Ripristino concluso correttamente. Ripristinati:{0}{0}- {1} sinistri delega propria{0}- {2} sinistri delega altrui{0}{0}" +
                             "I sinistri saranno nuovamente archiviati nello storico al prossimo consolidamento dei dati a meno che non risultino aperti.",
                             Environment.NewLine, DP, DA), MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        If DP + DA > 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
End Class