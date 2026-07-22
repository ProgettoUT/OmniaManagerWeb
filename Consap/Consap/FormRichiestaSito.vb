Public Class FormRichiestaSito

    Private Const Url As String = "http://rimborsodelsinistro.consap.it/"

    Friend Cliente As UtControls.Cliente
    Friend Sinistro As DatiSinistro

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(Utx.InfoSistema.Desktop.Larghezza * 0.7, Utx.InfoSistema.Desktop.Altezza * 0.9)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("consap")
        Me.Text = "Richiesta Consap on-line"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With SplitContainer1
            .SplitterDistance = SplitContainer1.Width * 0.7
            .BackColor = Color.Gray
        End With
        With ListBoxDati
            .Padding = New Padding(2)
            .Margin = New Padding(0)
            .IntegralHeight = False
            .Font = Utx.AppFont.Extra(14, FontStyle.Regular)
            .BackColor = Color.LightBlue
        End With
        With LabelMessaggio
            .Margin = New Padding(0)
            .BackColor = Color.Gainsboro
            .Font = Utx.AppFont.Bold
            .BackColor = Color.DodgerBlue
            .ForeColor = Color.White
            .Text = "Selezionare una riga per copiarla negli appunti"
        End With
        wbConsap.ScriptErrorsSuppressed = True
    End Sub

    Private mDelega As Boolean
    Public Property Delega() As Boolean
        Get
            Return mDelega
        End Get
        Set(value As Boolean)
            mDelega = value
        End Set
    End Property

    Private Sub FormRichiestaSito_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        wbConsap.Navigate(Url)
    End Sub

    Private Sub FormRichiestaSito_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim Rientro As Integer = 3
            With ListBoxDati.Items
                .Add("Controparte ".PadRight(50, "="))
                .Add(Space(Rientro) + Sinistro.CompagniaControparte)
                .Add(Space(Rientro) + Sinistro.TargaControparte)
                .Add("")
                .Add("")
                .Add("Assicurato ".PadRight(50, "="))
                .Add(Space(Rientro) + Cliente.CF)
                .Add(Space(Rientro) + Cliente.Nome)
                .Add(Space(Rientro) + Cliente.Cognome)
                .Add(Space(Rientro) + Cliente.Citta)
                .Add(Space(Rientro) + Cliente.Provincia)
                .Add(Space(Rientro) + Cliente.Indirizzo)
                .Add(Space(Rientro) + Cliente.Cap)
                .Add("")
                If Cliente.Cellulari.Count > 0 Then .Add(Space(Rientro) + Cliente.Cellulari.Item(0).Contatto.Replace("+39", ""))
                If Cliente.Email.Count > 0 Then .Add(Space(Rientro) + Cliente.Email.Item(0).Contatto)
                .Add("")
                .Add(Space(Rientro) + Sinistro.Compagnia)
                .Add(Space(Rientro) + Sinistro.TargaResponsabile)
                .Add("")
                .Add("")
                .Add("Data sinistro ".PadRight(50, "="))
                .Add(Space(Rientro) + Sinistro.DataSinistro)
                .Add("")
                .Add("")
                .Add("Delega ".PadRight(50, "="))
                .Add(Space(Rientro) + Globale.Delegato.RagioneSociale)
                .Add(Space(Rientro) + Globale.Delegato.Email)
                .Add(Space(Rientro) + Globale.Delegato.CF)
                .Add(Space(Rientro) + Globale.Delegato.Citta)
            End With
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ListBoxDati_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxDati.SelectedIndexChanged
        Try
            If ListBoxDati.SelectedItem IsNot Nothing Then
                If ListBoxDati.SelectedItem.ToString.EndsWith("=") = False Then
                    If String.IsNullOrEmpty(ListBoxDati.SelectedItem) = False Then
                        Clipboard.Clear()
                        'pare che possa evitare l'errore 521
                        Threading.Thread.Sleep(100)
                        'copio la riga
                        Clipboard.SetText(ListBoxDati.SelectedItem.ToString.Trim)
                        LabelMessaggio.Text = ListBoxDati.SelectedItem
                    End If
                End If
            End If

        Catch cb As System.Runtime.InteropServices.ExternalException
            MsgBox("Impossibile accedere ora agli appunti. Riprovate.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub wbConsap_GotFocus(sender As Object, e As EventArgs) Handles wbConsap.GotFocus
        My.Computer.Keyboard.SendKeys(Clipboard.GetText())
        Clipboard.Clear()
        LabelMessaggio.Text = ""
    End Sub

    'Private Sub wbConsap_DocumentComplete(sender As Object, e As AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent) Handles wbConsap.DocumentCompleted

    '    Dim doc As IHTMLDocument3 = wbConsap.Document
    '    Dim el As IHTMLElement = doc.getElementById(Id.DataSinistro)
    '    Dim Nome As IHTMLElement = doc.getElementById(Id.Nome)

    '    If Nome IsNot Nothing Then
    '        'compila seconda sezione
    '        If mDelega = True Then
    '            'con delega
    '            doc.getElementById(Id.Delega).setAttribute("checked", "checked")
    '            doc.getElementById(Id.LabelDelega).innerText += " (da stampare)"
    '            doc.getElementById(Id.Presso).innerText = String.Format("C/O {0}", Globale.Delegato.RagioneSociale.ToUpper)
    '            'doc.getElementById(Id.Cognome).innerText = Globale.Delegato.RagioneSociale.ToUpper
    '            Nome.innerText = Cliente.Nome
    '            doc.getElementById(Id.Cognome).innerText = Cliente.Cognome
    '            doc.getElementById(Id.Indirizzo).innerText = Globale.Delegato.Indirizzo.ToUpper
    '            doc.getElementById(Id.Cap).innerText = Globale.Delegato.Cap
    '            doc.getElementById(Id.Localita).innerText = Globale.Delegato.Citta.ToUpper
    '            doc.getElementById(Id.Telefono).innerText = Globale.Delegato.Telefono
    '            doc.getElementById(Id.Email).innerText = Globale.Delegato.Email
    '            'asterischi
    '            doc.getElementById(Id.AsteriscoNazione).innerText = "* selezionare ITALIA ->"
    '            doc.getElementById(Id.AsteriscoProvincia).innerText = String.Format("* selezionare {0} ->", Globale.Delegato.Provincia)
    '            doc.getElementById(Id.AsteriscoComune).innerText = String.Format("* selezionare {0} ->", Globale.Delegato.Citta)
    '        Else
    '            'senza delega
    '            Nome.innerText = Cliente.Nome
    '            doc.getElementById(Id.Cognome).innerText = Cliente.Cognome
    '            doc.getElementById(Id.Indirizzo).innerText = Cliente.Indirizzo
    '            doc.getElementById(Id.Cap).innerText = Cliente.Cap
    '            doc.getElementById(Id.Localita).innerText = Cliente.Citta
    '            'contatti
    '            If Cliente.Cellulari.Item(0).IsOk Then
    '                doc.getElementById(Id.Telefono).innerText = Cliente.Cellulari.Item(0).Contatto
    '            ElseIf Cliente.Telefoni.Item(0).IsOk Then
    '                doc.getElementById(Id.Telefono).innerText = Cliente.Telefoni.Item(0).Contatto
    '            End If
    '            If Cliente.Email.Item(0).IsOk Then
    '                doc.getElementById(Id.Email).innerText = Cliente.Email.Item(0).Contatto
    '            End If
    '            'asterischi
    '            doc.getElementById(Id.AsteriscoNazione).innerText = "* selezionare ITALIA ->"
    '            doc.getElementById(Id.AsteriscoProvincia).innerText = String.Format("* selezionare {0} ->", Cliente.Provincia)
    '            doc.getElementById(Id.AsteriscoComune).innerText = String.Format("* selezionare {0} ->", Cliente.Citta)
    '            'intestazione con dati del nostro assicurato
    '            doc.getElementById(Id.TitoloPagina).innerText += String.Format("{0}{0}Nostro assicurato: {1} - {2} - {3} {4} {5}",
    '                                                                           Environment.NewLine,
    '                                                                           Cliente.NomeCompleto,
    '                                                                           Cliente.Indirizzo,
    '                                                                           Cliente.Cap, Cliente.Citta, Cliente.Provincia)
    '        End If

    '    ElseIf el IsNot Nothing Then
    '        'compila prima sezione
    '        el.innerText = Sinistro.DataSinistro
    '        doc.getElementById(Id.TargaAssicurato).innerText = Sinistro.TargaResponsabile
    '        doc.getElementById(Id.TargaDanneggiato).innerText = Sinistro.TargaControparte
    '        doc.getElementById(Id.CompagniaControparte).setAttribute("value", Sinistro.CodiceCompagniaControparte.ToString.PadLeft(3, "0"))
    '        doc.getElementById(Id.CompagniaAssicurato).setAttribute("value", Sinistro.CodiceCompagnia.ToString.PadLeft(3, "0"))
    '    End If
    'End Sub
End Class