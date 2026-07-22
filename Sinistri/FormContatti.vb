Imports System.Windows.Forms
Imports System.Drawing

Public Class FormContatti

    Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.Size = New Drawing.Size(400, 400)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Font = Utx.AppFont.Extra(11, FontStyle.Regular)
        Me.Text = "Selezione destinatari"

        ImpostaControlli()
    End Sub

    Private mSinistro As Sinistro
    Public Property Sinistro() As Sinistro
        Get
            Return mSinistro
        End Get
        Set(value As Sinistro)
            mSinistro = value
        End Set
    End Property

    Private Sub ImpostaControlli()
        ButtonAnnulla.Text = "Annulla"
        ButtonOk.Text = "Procedi"

        With RadioButtonEmail
            .Margin = New Padding(0)
            .Dock = DockStyle.Fill
            .Appearance = Appearance.Button
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .FlatAppearance.CheckedBackColor = Drawing.Color.PaleGreen
            .Text = "E-mail"
            .TextAlign = Drawing.ContentAlignment.MiddleCenter
        End With
        With RadioButtonSms
            .Margin = New Padding(0)
            .Dock = DockStyle.Fill
            .Appearance = Appearance.Button
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .FlatAppearance.CheckedBackColor = Drawing.Color.PaleGreen
            .Text = "Sms"
            .TextAlign = Drawing.ContentAlignment.MiddleCenter
        End With
        With RadioButtonTelefoni
            .Margin = New Padding(0)
            .Dock = DockStyle.Fill
            .Appearance = Appearance.Button
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .FlatAppearance.CheckedBackColor = Drawing.Color.PaleGreen
            .Text = "Telefoni"
            .TextAlign = Drawing.ContentAlignment.MiddleCenter
        End With
    End Sub

    Private Sub FormContatti_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub

    Private Sub FormContatti_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        RadioButtonEmail.Checked = True
    End Sub

    Private Sub LeggiContatti()
        Try
            Cursor = Cursors.WaitCursor

            With tvContatti
                .Nodes.Clear()
                .Refresh()
            End With

            Dim TipoContatto As New Utx.TipoRecapitoEnum

            If RadioButtonEmail.Checked = True Then
                TipoContatto = Utx.TipoRecapitoEnum.Email
                tvContatti.CheckBoxes = True
            ElseIf RadioButtonSms.Checked = True Then
                TipoContatto = Utx.TipoRecapitoEnum.Cellulare
                tvContatti.CheckBoxes = True
            Else
                TipoContatto = Utx.TipoRecapitoEnum.Voce
                tvContatti.CheckBoxes = False
            End If

            'nodo base
            Dim Base As New TreeNode
            With Base
                .NodeFont = New Font(tvContatti.Font.Name, tvContatti.Font.Size, FontStyle.Bold)
                .BackColor = Color.Gold
                .Text = String.Format(Sinistro.IdSinistroDesk)
            End With
            tvContatti.Nodes.Add(Base)

            Dim contatti As New Utx.Recapiti
            'nss
            contatti = Utx.Recapiti.GetRecapitiLiquido.Filtra(TipoContatto)
            If contatti.Count > 0 Then
                With Base.Nodes.Add("Liquido")
                    For Each r In contatti
                        .Nodes.Add(r.Contatto)
                    Next
                End With
            End If

            'assicurato
            contatti = Utx.Recapiti.GetRecapitiCliente(mSinistro.CfAssicurato).Filtra(TipoContatto)
            If contatti.Count > 0 Then
                With Base.Nodes.Add("Assicurato")
                    For Each r In contatti
                        .Nodes.Add(r.Contatto)
                    Next
                End With
            End If

            'liquidatore
            contatti = Utx.Recapiti.GetRecapitiLiquidatori(mSinistro.CodiceLiquidatore).Filtra(TipoContatto)
            If contatti.Count > 0 Then
                With Base.Nodes.Add("Liquidatore: " & contatti.Item(0).Nota)
                    For Each r In contatti
                        .Nodes.Add(r.Contatto)
                    Next
                End With
            End If

            'periti
            Dim IncarichiSinistro As New Incarichi(Sinistro.Compagnia, Sinistro.Agenzia, Sinistro.Esercizio, Sinistro.Numero)

            For Each p As String In IncarichiSinistro.ListaPeriti(Utx.FunzioniDb.NullNothingToString(Sinistro.CodicePerito))

                contatti = Utx.Recapiti.GetRecapitiPeriti(p).Filtra(TipoContatto)

                If contatti.Count > 0 Then
                    With Base.Nodes.Add("Perito: " & contatti.Item(0).Nota)
                        For Each r In contatti
                            .Nodes.Add(r.Contatto)
                        Next
                    End With
                End If
            Next

            tvContatti.ExpandAll()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.Close()
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        If RadioButtonEmail.Checked = True Then
            PreparaEmail()
        ElseIf RadioButtonSms.Checked = True Then
            PreparaSms()
        Else
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub PreparaEmail()
        Try
            Dim f As New UniCom.FormMail
            'tipo messaggio
            f.Messaggio = UniCom.FormMail.TipoMessaggio.Email
            'pratica
            f.IdPratica = Sinistro.IdSinistro
            f.CodiceFiscale = Sinistro.CfAssicurato
            f.NomeCliente = Sinistro.Assicurato

            'aggiungo destinatari
            For Each n As TreeNode In tvContatti.Nodes
                For Each n1 As TreeNode In n.Nodes
                    'i contatti (email e telefoni) sono a questo livello
                    For Each n2 As TreeNode In n1.Nodes

                        If n2.Checked = True Then
                            f.AddDestinatarioEmail(UniCom.FormMail.TipoDestinatarioMail.A, n2.Text.Trim)
                        End If
                    Next
                Next
            Next

            'oggetto
            f.Oggetto = String.Format("SX: {0}", Sinistro.IdSinistro)
            'testo
            f.Testo = String.Format("{1}{0}Cartella: {2}{0}{1}{0}Sinistro: {3}{0}" +
                                    "Data sinistro: {4}{0}Polizza: {5}/{6}{0}Assicurato: {7} {0}{1}{0}",
                                    Environment.NewLine,
                                    StrDup(60, "-"),
                                    Sinistro.Cartella,
                                    Sinistro.IdSinistro,
                                    Sinistro.DataSinistro,
                                    Sinistro.RamoPolizza,
                                    Sinistro.Polizza,
                                    Sinistro.Assicurato)

            Me.Close()
            f.Show()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PreparaSms()
        Try
            Dim f As New UniCom.FormMail

            f.Messaggio = UniCom.FormMail.TipoMessaggio.Sms
            f.IdPratica = Sinistro.IdSinistro
            f.CodiceFiscale = Sinistro.CfAssicurato

            For Each n As TreeNode In tvContatti.Nodes

                For Each n1 As TreeNode In n.Nodes

                    For Each n2 As TreeNode In n1.Nodes

                        If n2.Checked = True Then
                            f.AddDestinatarioSms(n2.Text.Trim)
                        End If
                    Next
                Next
            Next

            Me.Close()

            f.Show()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub tvContatti_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tvContatti.AfterCheck
        For Each n As TreeNode In e.Node.Nodes
            n.Checked = e.Node.Checked
        Next
    End Sub

    Private Sub tvContatti_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvContatti.NodeMouseDoubleClick
        e.Node.Checked = Not e.Node.Checked
    End Sub

    Private Sub RadioButtonEmail_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonEmail.CheckedChanged
        If RadioButtonEmail.Checked = True Then LeggiContatti()
    End Sub

    Private Sub RadioButtonSms_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSms.CheckedChanged
        If RadioButtonSms.Checked = True Then LeggiContatti()
    End Sub

    Private Sub RadioButtonTelefoni_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonTelefoni.CheckedChanged
        If RadioButtonTelefoni.Checked = True Then LeggiContatti()
    End Sub
End Class