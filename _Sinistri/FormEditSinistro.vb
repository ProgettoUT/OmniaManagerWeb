Imports System.Windows.Forms
Imports System.Drawing

Public Class FormEditSinistro

    Public Evento As New EventoLiquido

    Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.Size = New Size(580, 450)
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal
        Me.Text = "Aggiungi sinistro"
        Me.Icon = Risorse.Immagini.Icon("addsinistro")

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With tlpMain
            With .RowStyles.Item(0)
                .SizeType = SizeType.Absolute
                .Height = 50
            End With
            With .RowStyles.Item(1)
                .SizeType = SizeType.Absolute
                .Height = 20
            End With
            With .RowStyles.Item(2)
                .SizeType = SizeType.Percent
                .Height = 45
            End With
            With .RowStyles.Item(3)
                .SizeType = SizeType.Absolute
                .Height = 20
            End With
            With .RowStyles.Item(4)
                .SizeType = SizeType.Percent
                .Height = 55
            End With
            With .RowStyles.Item(5)
                .SizeType = SizeType.Absolute
                .Height = 50
            End With
        End With

        With rbSinistriPropri
            .Margin = New Padding(0)
            .Dock = DockStyle.Fill
            .Appearance = Appearance.Button
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .FlatAppearance.CheckedBackColor = Drawing.Color.PaleGreen
            .Text = "Gestito da UnipolSai"
            .TextAlign = Drawing.ContentAlignment.MiddleCenter
            .Checked = True
        End With
        With rbAltraCompagnia
            .Margin = New Padding(0)
            .Dock = DockStyle.Fill
            .Appearance = Appearance.Button
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .FlatAppearance.CheckedBackColor = Drawing.Color.PaleGreen
            .Text = String.Format("Gestito da altra compagnia{0}Sinistri cautelativi", Environment.NewLine)
            .TextAlign = Drawing.ContentAlignment.MiddleCenter
        End With
        With LabelPolizza
            .Margin = New Padding(0)
            .BorderStyle = BorderStyle.None
            .AutoSize = True
            .Dock = DockStyle.Fill
            .BackColor = Drawing.Color.Moccasin
            .Text = "Polizza"
            .TextAlign = Drawing.ContentAlignment.MiddleLeft
        End With
        With LabelSinistro
            .Margin = New Padding(0)
            .BorderStyle = BorderStyle.None
            .AutoSize = True
            .Dock = DockStyle.Fill
            .BackColor = Drawing.Color.Moccasin
            .Text = "Sinistro"
            .TextAlign = Drawing.ContentAlignment.MiddleLeft
        End With
        With ButtonOk
            .Margin = New Padding(0)
            .Padding = New Padding(20, 0, 20, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("addsinistro")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Aggiungi sinistro"
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
        With ButtonCompletaDati
            .Margin = New Padding(0)
            .Padding = New Padding(10, 0, 10, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .Dock = DockStyle.Fill
            .BackColor = Color.Gainsboro
            .Image = Risorse.Immagini.Bitmap("ok16")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Completa i dati partendo da targa o polizza"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ButtonCercaCliente
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
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub FormEditSinistro_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitSinistro()
    End Sub

    Private Sub FormEditSinistro_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TextBoxRamo.Focus()
    End Sub

    Private Sub InitSinistro()
        Try
            'carico i dati catturati da liquido nei textbox
            If Evento.LetturaEventoEffettuata = True Then

                With Evento
                    TextBoxRamo.Text = .Ramo
                    TextBoxPolizza.Text = .Polizza
                    TextBoxSub.Text = .SubAgenzia
                    TextBoxTarga.Text = .Targa
                    TextBoxCF.Text = .CF
                    TextBoxContraente.Text = .Contraente
                    TextBoxAgenziaSinistro.Text = .AgenziaSinistro
                    TextBoxEsercizio.Text = .EsercizioSinistro
                    TextBoxNumero.Text = .NumeroSinistro
                    TextBoxCLG.Text = .Ufficio
                    TextBoxCodiceLiquidatore.Text = .CodiceLiquidatore
                    TextBoxLiquidatore.Text = .Liquidatore
                    TextBoxEvento.Text = .Evento
                    TextBoxRamoSinistro.Text = .RamoSinistro
                    TextBoxDataSinistro.Text = .DataSinistro
                    TextBoxDataDenuncia.Text = .DataDenuncia
                    TextBoxDataApertura.Text = .DataApertura
                End With
            End If

        Catch ex As Exception
            '
        End Try
    End Sub

    Private Sub ButtonCompletaDati_Click(sender As Object, e As EventArgs) Handles ButtonCompletaDati.Click
        Try
            If String.IsNullOrEmpty(TextBoxTarga.Text) AndAlso
               (String.IsNullOrEmpty(TextBoxRamo.Text) OrElse String.IsNullOrEmpty(TextBoxPolizza.Text)) Then

                MsgBox("Inserire la targa o ramo e polizza", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                TextBoxTarga.Focus()
                Exit Sub
            End If

            Dim Sql As String
            If TextBoxTarga.Text.Trim.Length > 0 Then
                'ricerca per targa
                Sql = String.Format("SELECT TOP 1 P.*, C.Cognome, C.Nome 
                    FROM Polizze AS P 
                    INNER JOIN Clienti AS C ON C.CodiceFiscale = P.CodiceFiscale 
                    WHERE p.Targa = '{0}'", TextBoxTarga.Text.Replace(Space(1), ""))
            Else
                'ricerca per ramo/polizza
                Sql = String.Format("SELECT TOP 1 P.*, C.Cognome, C.Nome
                    FROM Polizze AS P 
                    INNER JOIN Clienti AS C ON C.CodiceFiscale = P.CodiceFiscale 
                    WHERE P.Ramo = {0} AND p.Polizza = {1}", TextBoxRamo.Text, TextBoxPolizza.Text)
            End If

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Sql).DataTable

            Try
                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow = dt.Rows(0)
                    TextBoxTarga.Text = Utx.FunzioniDb.NullToString(dr("Targa"))
                    TextBoxRamo.Text = Utx.FunzioniDb.NullToString(dr("Ramo"))
                    TextBoxPolizza.Text = Utx.FunzioniDb.NullToString(dr("Polizza"))
                    TextBoxCF.Text = Utx.FunzioniDb.NullToString(dr("CodiceFiscale"))
                    TextBoxContraente.Text = String.Format("{0} {1}",
                                                                   Utx.FunzioniDb.NullToString(dr("Cognome")).Trim,
                                                                   Utx.FunzioniDb.NullToString(dr("Nome")).Trim)
                    TextBoxSub.Text = Utx.FunzioniDb.NullToString(dr("CodiceSubAgente"))
                    TextBoxAgenziaSinistro.Focus()
                Else
                    TextBoxCF.Text = ""
                    TextBoxContraente.Text = ""
                    TextBoxSub.Text = ""

                    MsgBox("Dati non trovati", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                End If

            Catch ex As Exception
                'per dati farlocchi (null) non fare niente
            End Try

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub rbAltraCompagnia_Click(sender As Object, e As EventArgs) Handles rbAltraCompagnia.Click
        'procede con la numerazione automatica per altra compagnia/cautelative
        Try
            TextBoxEsercizio.Text = Today.Year
            TextBoxAgenziaSinistro.Text = 0

            Dim Sql As String = String.Format("SELECT MAX(NumeroSinistro) AS Numero 
                FROM SinistriAC 
                WHERE EsercizioSinistro = {0} AND AgenziaSinistro < 10", TextBoxEsercizio.Text)
            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteScalar(Sql)
            TextBoxNumero.Text = Utx.FunzioniDb.NullToNumber(Val(Risposta.Valore)) + 1
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function ControlloDati() As Boolean
        Try
            Dim Messaggio As String = ""

            If rbSinistriPropri.Checked = True Then
                If String.IsNullOrEmpty(TextBoxRamo.Text) Then
                    TextBoxRamo.Focus()
                    GoTo Errore
                End If
                If String.IsNullOrEmpty(TextBoxPolizza.Text) Then
                    TextBoxPolizza.Focus()
                    GoTo Errore
                End If
                If String.IsNullOrEmpty(TextBoxCF.Text) Then
                    TextBoxCF.Focus()
                    GoTo Errore
                End If

                'controllo lunghezza CF PIVA solo per sinistri unipol
                If IsNumeric(TextBoxCF.Text) And TextBoxCF.Text.Trim.Length <> 11 Then
                    TextBoxCF.Focus()
                    GoTo Errore
                End If
                If (IsNumeric(TextBoxCF.Text) = False) And TextBoxCF.Text.Trim.Length <> 16 Then
                    TextBoxCF.Focus()
                    GoTo Errore
                End If
            Else
                'altra compagnia
                If (IsNumeric(TextBoxAgenziaSinistro.Text) = False) OrElse (TextBoxAgenziaSinistro.Text >= 10) Then
                    TextBoxAgenziaSinistro.Focus()
                    Messaggio = "Per l'agenzia sinistro inserire un valore fra 0 e 9."
                    GoTo Errore
                End If
            End If

            If String.IsNullOrEmpty(TextBoxContraente.Text) Then
                TextBoxContraente.Focus()
                GoTo Errore
            End If
            If String.IsNullOrEmpty(TextBoxAgenziaSinistro.Text) Then
                TextBoxAgenziaSinistro.Focus()
                GoTo Errore
            End If
            If String.IsNullOrEmpty(TextBoxEsercizio.Text) Then
                TextBoxEsercizio.Focus()
                GoTo Errore
            End If
            If String.IsNullOrEmpty(TextBoxNumero.Text) Then
                TextBoxNumero.Focus()
                GoTo Errore
            End If

            If IsDate(TextBoxDataSinistro.Text) = False Then
                TextBoxDataSinistro.Text = Today
            End If
            If IsDate(TextBoxDataDenuncia.Text) = False Then
                TextBoxDataDenuncia.Text = Today
            End If
            If IsDate(TextBoxDataApertura.Text) = False Then
                TextBoxDataApertura.Text = Today
            End If

            'controllo codice del legale
            If String.IsNullOrEmpty(TextBoxCodiceLegale.Text) OrElse (Not IsNumeric(TextBoxCodiceLegale.Text)) Then
                TextBoxCodiceLegale.Text = 0
            End If
            If TextBoxCodiceLegale.Text < 0 Then
                TextBoxCodiceLegale.Text = 0
            End If
            TextBoxCodiceLegale.Text = Int(TextBoxCodiceLegale.Text)

            Return True

            Exit Try

Errore:
            If String.IsNullOrEmpty(Messaggio) Then
                Messaggio = "Prima di aggiungere il sinistro completare i dati."
            End If
            MsgBox(Messaggio, MsgBoxStyle.Exclamation)
            Return False

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        Try
            If ControlloDati() = True Then

                With Evento
                    If rbSinistriPropri.Checked = True Then
                        .Tipo = QuerySinistri.TipoTabella.SINISTRI_DELEGA_PROPRIA
                    Else
                        .Tipo = QuerySinistri.TipoTabella.SINISTRI_ALTRA_COMPAGNIA
                    End If

                    'controllo se il sinistro esiste già
                    If EsisteSinistro(1, TextBoxAgenziaSinistro.Text, TextBoxEsercizio.Text, TextBoxNumero.Text, .Tipo) = True Then
                        MsgBox(String.Format("Nell'archivio '{0}' esiste già un sinistro con questo numero.",
                                             .DescrizioneTipo.ToUpper), MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                        Exit Try
                    End If

                    .EsercizioSinistro = TextBoxEsercizio.Text
                    .AgenziaSinistro = TextBoxAgenziaSinistro.Text
                    .NumeroSinistro = TextBoxNumero.Text
                    .Targa = Utx.FunzioniDb.NullToString(TextBoxTarga.Text)
                    .Ramo = IIf(TextBoxRamo.Text.Length = 0, 0, TextBoxRamo.Text)
                    .Polizza = IIf(TextBoxPolizza.Text.Length = 0, 0, TextBoxPolizza.Text)
                    .DataSinistro = TextBoxDataSinistro.Text
                    .DataDenuncia = TextBoxDataDenuncia.Text
                    .DataApertura = IIf(IsDate(TextBoxDataApertura.Text), TextBoxDataApertura.Text, DBNull.Value)
                    .CF = Utx.FunzioniDb.NullToString(TextBoxCF.Text.ToUpper)
                    .Contraente = Utx.FunzioniDb.NullToString(Microsoft.VisualBasic.Left(TextBoxContraente.Text.ToUpper, 20))
                    .Gestore = Utx.FunzioniDb.NullToString(TextBoxGestione.Text.ToUpper)
                    .CodiceLiquidatore = IIf(IsNumeric(TextBoxCodiceLiquidatore.Text), TextBoxCodiceLiquidatore.Text, 0)
                    .Liquidatore = Utx.FunzioniDb.NullToString(TextBoxLiquidatore.Text.ToUpper)
                    .Ufficio = Utx.FunzioniDb.Str2Num(TextBoxCLG.Text)

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End With
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonCercaCliente_Click(sender As Object, e As EventArgs) Handles ButtonCercaCliente.Click
        Using f As New UtControls.FormCercaCliente
            f.NomeCompleto = TextBoxContraente.Text
            f.ShowDialog()

            If f.DialogResult = Windows.Forms.DialogResult.OK Then

                TextBoxContraente.Text = f.NomeCompleto
                TextBoxCF.Text = f.CodiceFiscale
            End If
        End Using
    End Sub

End Class