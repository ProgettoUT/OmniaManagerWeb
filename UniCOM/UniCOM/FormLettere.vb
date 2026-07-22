Imports System.IO
Imports System.Xml

Public Class FormLettere

    Private Notifica As Utx.FormNotifica
    Private Tip As New ToolTip

    Private WithEvents Tim As New Timers.Timer

    Public Enum Estrazioni
        INCASSATI
        ARRETRATI
    End Enum

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Font = Utx.AppFont.Normal
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width * 0.5, Screen.PrimaryScreen.WorkingArea.Height * 0.6)
        Me.MinimumSize = New Size(750, 300)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Padding = New Padding(3)
        Me.BackColor = Color.Pink
        Me.Icon = Risorse.Immagini.Icon("lettera")
        Me.Text = "Invia comunicazioni"

        ImpostaControlli()
    End Sub

    Private mEstrazione As Estrazioni
    Public Property Estrazione() As Estrazioni
        Get
            Return mEstrazione
        End Get
        Set(value As Estrazioni)
            mEstrazione = value
        End Set
    End Property

    Private mDestinatari As DataTable
    Public Property Destinatari() As DataTable
        Get
            Return mDestinatari
        End Get
        Set(value As DataTable)
            mDestinatari = value
        End Set
    End Property

    Private Sub ImpostaControlli()
        Tim.Interval = 2000
        Tim.Enabled = True
        With ComboBoxCampi
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Sorted = True
        End With
        With ComboBoxModelli
            .DropDownStyle = ComboBoxStyle.DropDownList
            .BackColor = Color.Yellow
            .Sorted = True
        End With
        With ButtonInserisciCampo
            .Text = "Inserisci il campo >"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With TextBoxMessaggio
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .Text = ""
        End With
        With ButtonAnteprima
            .Margin = New Padding(0)
            .Padding = Utx.AppFont.ButtonPadding
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Image = Risorse.Immagini.Bitmap("cerca16")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Anteprima"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonSalva
            .Margin = New Padding(0)
            .Padding = Utx.AppFont.ButtonPadding
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Image = Risorse.Immagini.Bitmap("salva")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Salva modello"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonElimina
            .Margin = New Padding(0)
            .Padding = Utx.AppFont.ButtonPadding
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Elimina modello"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonCreaLettere
            .Margin = New Padding(0)
            .Padding = Utx.AppFont.ButtonPadding
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Image = Risorse.Immagini.Bitmap("lettera")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Crea file delle lettere"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonEsci
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Image = Risorse.Immagini.Bitmap("esci")
            .Text = ""
        End With
    End Sub

    Private Sub FormLettere_Load(sender As Object, e As EventArgs) Handles Me.Load
        If LeggiListaLettere() = False Then
            MsgBox("File di configurazione delle lettere non trovato.", MsgBoxStyle.Exclamation)
            DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub FormLettere_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Refresh()
        TextBoxMessaggio.Focus()
    End Sub

    Private Function DestinatariSms() As DataRow()
        Return Destinatari.Select("Trim(Telefono) <> ''")
    End Function

    Private Function DestinatariEmail() As DataRow()
        Return Destinatari.Select("Trim(Email) <> ''")
    End Function

    Private Function DestinatariSmsCount() As Integer
        Return Me.DestinatariSms.Length
    End Function

    Private Function DestinatariEmailCount() As Integer
        Return Me.DestinatariEmail.Length
    End Function

    Private Sub ButtonCreaLettere_Click(sender As Object, e As EventArgs) Handles ButtonCreaLettere.Click
        Process.Start(Utx.RtfManager.Stampa(TextBoxMessaggio.Text, Destinatari, ComboBoxModelli.SelectedItem.Aggrega))
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Tim.Dispose()
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ButtonInserisciCampo_Click(sender As Object, e As EventArgs) Handles ButtonInserisciCampo.Click
        Dim InsertPos As Integer = TextBoxMessaggio.SelectionStart
        Dim Inserttext As String = String.Format("#{0}#", ComboBoxCampi.Text)
        TextBoxMessaggio.Text = TextBoxMessaggio.Text.Insert(InsertPos, Inserttext)
        TextBoxMessaggio.SelectionStart = InsertPos + Inserttext.Length
        TextBoxMessaggio.Focus()
    End Sub

    Public Function LeggiListaLettere() As Boolean
        'leggo la lista delle lettere disponibili
        Try
            If File.Exists(XmlLettere) = False Then
                Return False
            End If

            Dim xDoc As New XmlDocument
            Using reader As New StreamReader(XmlLettere, System.Text.Encoding.UTF8)
                xDoc.Load(reader)
            End Using

            'xDoc.Load(XmlLettere)

            Dim xnl As XmlNodeList = xDoc.SelectNodes("//lettera")

            ComboBoxModelli.Items.Clear()
            ComboBoxModelli.Items.Add(New Lettera(" Seleziona un modello", "", "", False, True, ""))

            For Each xn As XmlNode In xnl
                Dim aggrega As Boolean = True
                If xn.Attributes("aggrega") IsNot Nothing AndAlso xn.Attributes("aggrega").InnerText = "false" Then
                    aggrega = False
                End If
                ComboBoxModelli.Items.Add(New Lettera(xn.Attributes("nome").InnerText,
                                                      xn.Attributes("estrazioni").InnerText,
                                                      xn.Attributes("campi").InnerText,
                                                      xn.Attributes("edit").InnerText,
                                                      aggrega,
                                                      xn.InnerText))
            Next
            ComboBoxModelli.DisplayMember = "Nome"
            ComboBoxModelli.SelectedIndex = 0

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Function XmlLettere() As String
        Try
            Dim FileLettere As String = Path.Combine(Utx.Globale.Paths.CartellaSettingRete, String.Format("Lettere.{0}.xml", Utx.Globale.ProfiloEnteGestore.AgenziaMadre))
            'se il file agenzia non esiste lo creo
            If File.Exists(FileLettere) = False Then
                File.Copy(Path.Combine(Utx.Globale.Paths.CartellaSetting, "Lettere.xml"), FileLettere)
            End If
            Return FileLettere
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Sub ComboBoxModelli_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxModelli.SelectedIndexChanged
        'campi abbinabili al modello
        ComboBoxCampi.Items.Clear()
        For Each c As String In ComboBoxModelli.SelectedItem.Campi.ToString.Split("/")
            ComboBoxCampi.Items.Add(c)
        Next
        If ComboBoxCampi.Items.Count >= 0 Then
            ComboBoxCampi.SelectedIndex = 0
        End If
        'testo
        TextBoxMessaggio.Text = ComboBoxModelli.SelectedItem.Testo
    End Sub

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click
        If String.IsNullOrEmpty(TextBoxMessaggio.Text) Then
            MsgBox("Inserire il testo della lettera.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
        Else
            Dim NomeLettera As String = InputBox("Inserire il nome del modello", "Modifica lettere", ComboBoxModelli.Text)
            If String.IsNullOrEmpty(NomeLettera) = False Then
                SalvaModello(NomeLettera)
            End If
        End If
    End Sub

    Private Sub ButtonElimina_Click(sender As Object, e As EventArgs) Handles ButtonElimina.Click
        If MsgBox(String.Format("Confermate l'eliminazione del modello '{0}'", ComboBoxModelli.SelectedItem.Nome),
                  MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            EliminaModelloSelezionato()
        End If
    End Sub

    Private Sub SalvaModello(NomeLettera As String)
        Try
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(XmlLettere)

            'root
            Dim xLettere As XmlElement = xmlDoc.SelectSingleNode("//lettere")
            'nodo lettera
            Dim xModello As XmlElement = xmlDoc.SelectSingleNode(String.Format("//lettera[@nome='{0}']", NomeLettera))

            Dim oldEdit As String = "true"
            Dim oldAggrega As String = "true"
            Dim oldFontname As String = "Calibri"
            Dim oldFontsize As String = "11"

            If xModello IsNot Nothing Then
                'se esiste lo cancello
                If xModello.Attributes("edit") IsNot Nothing Then
                    oldEdit = xModello.Attributes("edit").InnerText
                End If

                If xModello.Attributes("aggrega") IsNot Nothing Then
                    oldAggrega = xModello.Attributes("aggrega").InnerText
                End If

                If xModello.Attributes("fontname") IsNot Nothing Then
                    oldFontname = xModello.Attributes("fontname").InnerText
                End If

                If xModello.Attributes("fontsize") IsNot Nothing Then
                    oldFontsize = xModello.Attributes("fontsize").InnerText
                End If
                xLettere.RemoveChild(xModello)
            ElseIf ComboBoxModelli.SelectedItem IsNot Nothing Then
                If ComboBoxModelli.SelectedItem.aggrega = False Then
                    oldAggrega = "false"
                End If
            End If

            'creo il nodo della lettera
            xModello = xmlDoc.CreateElement("lettera")
            With xModello
                .SetAttribute("nome", NomeLettera)
                .SetAttribute("estrazioni", ComboBoxModelli.SelectedItem.Estrazioni)
                .SetAttribute("campi", ComboBoxModelli.SelectedItem.Campi)
                .SetAttribute("edit", oldEdit)
                .SetAttribute("aggrega", oldAggrega)
                .SetAttribute("fontname", oldFontname)
                .SetAttribute("fontsize", oldFontname)
            End With

            'aggiungo il testo
            Dim xTesto As XmlElement = xModello.OwnerDocument.CreateElement("testo")
            xTesto.InnerText = TextBoxMessaggio.Text
            xModello.AppendChild(xTesto)

            'appendo la lettera alle lettere
            xLettere.AppendChild(xModello)

            'pulisco il doc e appendo il nodo principale di tutte le lettere
            xmlDoc.RemoveAll()
            xmlDoc.AppendChild(xLettere)
            'salvo
            Using writer As New StreamWriter(XmlLettere, False, System.Text.Encoding.UTF8)
                xmlDoc.Save(writer)
            End Using

            'xmlDoc.Save(XmlLettere)

            MsgBox(String.Format("Modello '{0}' salvato correttamente", NomeLettera), MsgBoxStyle.Information, Utx.Globale.TitoloApp)

            LeggiListaLettere()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub EliminaModelloSelezionato()
        Try
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(XmlLettere)

            'root
            Dim xLettere As XmlElement = xmlDoc.SelectSingleNode("//lettere")
            'nodo lettera
            Dim xModello As XmlElement = xmlDoc.SelectSingleNode(String.Format("//lettera[@nome='{0}']", ComboBoxModelli.SelectedItem.Nome))

            If xModello IsNot Nothing Then
                'se esiste lo cancello
                xLettere.RemoveChild(xModello)
            End If

            'pulisco il doc e appendo il nodo principale di tutte le lettere
            xmlDoc.RemoveAll()
            xmlDoc.AppendChild(xLettere)
            'salvo
            xmlDoc.Save(XmlLettere)

            MsgBox(String.Format("Il modello '{0}' è stato eliminato.", ComboBoxModelli.SelectedItem.Nome), MsgBoxStyle.Information, Utx.Globale.TitoloApp)

            LeggiListaLettere()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonAnteprima_Click(sender As Object, e As EventArgs) Handles ButtonAnteprima.Click
        If ComboBoxModelli.SelectedIndex > 0 Then
            'per l'anteprima passo solo la prima riga
            Dim dt As DataTable = Destinatari.Clone

            Dim CF As String = Destinatari.Rows(0).Item("DESTINATARIO_CODICEFISCALE")

            For Each r As DataRow In Destinatari.Rows
                If CF = r.Item("DESTINATARIO_CODICEFISCALE") Then
                    dt.Rows.Add(r.ItemArray)
                End If
            Next
            'genero l'anteprima
            Process.Start(Utx.RtfManager.Stampa(TextBoxMessaggio.Text, dt, ComboBoxModelli.SelectedItem.Aggrega))
        End If
    End Sub

    Private Sub Tim_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles Tim.Elapsed
        'Application.DoEvents()
    End Sub
End Class

Public Class Lettera

    Sub New(Nome As String,
            Estrazioni As String,
            Campi As String,
            Edit As Boolean,
            Aggrega As Boolean,
            Testo As String)

        mNome = Nome
        mEstrazioni = Estrazioni
        mCampi = Campi
        mTesto = Testo
        mEdit = Edit
        mAggrega = Aggrega
    End Sub

    Private mNome As String
    Public Property Nome() As String
        Get
            Return mNome
        End Get
        Set(value As String)
            mNome = value
        End Set
    End Property

    Private mEstrazioni As String
    Public Property Estrazioni() As String
        Get
            Return mEstrazioni
        End Get
        Set(value As String)
            mEstrazioni = value.ToUpper
        End Set
    End Property

    Private mCampi As String
    Public Property Campi() As String
        Get
            Return mCampi
        End Get
        Set(value As String)
            mCampi = value
        End Set
    End Property

    Private mTesto As String
    Public Property Testo() As String
        Get
            Return mTesto
        End Get
        Set(value As String)
            mTesto = value
        End Set
    End Property

    Private mEdit As Boolean
    Public Property Edit() As Boolean
        Get
            Return mEdit
        End Get
        Set(value As Boolean)
            mEdit = value
        End Set
    End Property

    Private mAggrega As Boolean
    Public Property Aggrega() As Boolean
        Get
            Return mAggrega
        End Get
        Set(value As Boolean)
            mAggrega = value
        End Set
    End Property

    Public Function ApplicabileAllaEstrazione(Estrazione As String) As Boolean
        Return mEstrazioni.Contains(Estrazione.ToUpper)
    End Function
End Class