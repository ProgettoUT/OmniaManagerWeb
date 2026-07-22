Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Xml
Imports System.IO

Public Class FormDettagioFiltro

    Public Enum Modalita
        FILTRO
        LAYOUT
    End Enum

    Public Event SalvatoLayout(NomeLayout As String)
    Public Event EliminatoLayout(NomeLayout As String)
    Friend Event CaricatoFiltro(FiltroCaricato As List(Of FiltroColonna))

    Friend AppName As String
    ''' <summary>
    ''' cartella dove sono salvati i file xml del filtro e del layout
    ''' </summary>
    ''' <remarks></remarks>
    Friend FilterFolder As String
    Friend FiltroCorrente As List(Of FiltroColonna)
    Friend FiltroCaricato As List(Of FiltroColonna)
    Friend GestoreLayout As Layout

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Icon = Risorse.Immagini.Icon("load16")
        Me.BackColor = Color.Orange
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.MinimumSize = New Size(650, 350)
        Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width * 0.5,
                           Screen.PrimaryScreen.WorkingArea.Height * 0.7)
    End Sub

#Region "Proprietà"
    Private mModo As Modalita
    ''' <summary>
    ''' Seleziona modalità di funzionamento filtro/layout
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Modo() As Modalita
        Get
            Return mModo
        End Get
        Set(value As Modalita)
            mModo = value
        End Set
    End Property

    Public ReadOnly Property DeskModo() As String
        Get
            Return mModo.ToString
        End Get
    End Property
#End Region

    Private Sub FormDettagioFiltro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Panel1.BackColor = Drawing.SystemColors.Control
        Label1.BackColor = Drawing.SystemColors.Control

        Me.Text = String.Format("Dettaglio {0}", DeskModo)
        With TextBoxDettaglio
            .Font = New Font("Courier new", 10)
            .BackColor = Color.LightYellow
            .ReadOnly = True
        End With
        With ButtonSalva
            .Padding = New Padding(10, 0, 10, 0)
            .BackColor = Drawing.SystemColors.Control
            .Text = String.Format("Salva il {0}", DeskModo)
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("salva")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonCarica
            .Padding = New Padding(10, 0, 10, 0)
            .BackColor = Drawing.SystemColors.Control
            .Text = String.Format("Carica il {0}", DeskModo)
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("load")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonCancella
            .Padding = New Padding(10, 0, 10, 0)
            .BackColor = Drawing.SystemColors.Control
            .Text = String.Format("Elimina il {0}", DeskModo)
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonEsci
            .Padding = New Padding(10, 0, 10, 0)
            .BackColor = Drawing.SystemColors.Control
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With

        If mModo = Modalita.FILTRO Then
            InitComboBoxFiltri()
        Else
            InitComboBoxLayout()
        End If
    End Sub

    Private Sub InitComboBoxFiltri()

        ComboBoxFiltri.Items.Clear()

        For Each s As String In ListaFiltri()
            ComboBoxFiltri.Items.Add(s)
        Next

        ComboBoxFiltri.Text = ""
        TextBoxDettaglio.Text = ""
    End Sub

    Private Sub InitComboBoxLayout()

        ComboBoxFiltri.Items.Clear()
        ComboBoxFiltri.DataSource = GestoreLayout.ListaLayout

        ComboBoxFiltri.Text = ""
    End Sub

    Private Sub FormDettagioFiltro_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If mModo = Modalita.FILTRO Then
            DettaglioFiltro(FiltroCorrente, "Filtro corrente")
        Else
            DettaglioLayout()
        End If
        ComboBoxFiltri.Focus()
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub DettaglioFiltro(ByRef Filtro As List(Of FiltroColonna),
                                Desk As String)
        Try
            If Filtro.Count > 0 Then
                Dim sb As New System.Text.StringBuilder

                sb.AppendLine(String.Format("Dettaglio filtro: {0}", Desk))
                sb.AppendLine()

                For Each f As FiltroColonna In Filtro

                    sb.AppendLine(String.Format("Tipo filtro: {0}", f.TipoFiltro))
                    sb.AppendLine(String.Format(Space(5) + "Campo: {0}", f.Campo))
                    sb.AppendLine(String.Format(Space(5) + "Tipo campo: {0}", f.TipoCampo.Name))

                    If f.TipoFiltro = FiltroColonna.TipologiaFiltri.CHECK Then
                        sb.AppendLine(String.Format(Space(5) + "Tipo selezione: {0}", f.Elementi))

                        For Each i As ItemColonna In f.Items
                            sb.AppendLine(String.Format(Space(10) + "Valore: {0}", i.Valore))
                        Next
                    Else
                        sb.AppendLine(String.Format(Space(5) + "Operatore: {0}", f.Operatore.Descrizione))
                        sb.AppendLine(String.Format(Space(5) + "Chiave: {0}", f.Chiave))
                    End If

                    sb.AppendLine()
                Next

                TextBoxDettaglio.Text = sb.ToString
                TextBoxDettaglio.SelectionStart = 0
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub DettaglioLayout()
        TextBoxDettaglio.Text = String.Format("{0}{0}Layout attualmente salvati {1}:{0}{0}", Environment.NewLine, ComboBoxFiltri.Items.Count)
        For Each l As String In ComboBoxFiltri.DataSource
            TextBoxDettaglio.Text += String.Format("- {1}{0}", Environment.NewLine, l)
        Next
    End Sub

    Public Sub SalvaFiltro()
        Try
            If FiltroCorrente.Count = 0 Then
                MsgBox("Nessun filtro da salvare.", MsgBoxStyle.Information, "Unitools")
                Exit Sub
            End If
            If String.IsNullOrEmpty(ComboBoxFiltri.Text) Then
                MsgBox("Indicare il nome da assegnare al filtro.", MsgBoxStyle.Information, "Unitools")
                ComboBoxFiltri.Focus()
                Exit Sub
            End If

            If EsisteFiltro(ComboBoxFiltri.Text) Then
                If MsgBox(String.Format("Il filtro '{0}' esiste già. Volete sovrascriverlo?", ComboBoxFiltri.Text),
                          MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Unitools") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            Dim NomeFile As String = FileXml()

            If NomeFile.Length > 0 Then

                Dim xmlDoc As New XmlDocument
                Dim xmlAppNode, xmlFiltroNode As XmlElement

                'se il file contenente i filtri esiste lo carico
                If File.Exists(NomeFile) Then
                    xmlDoc.Load(NomeFile)
                End If

                'cerco il nodo app
                xmlAppNode = xmlDoc.SelectSingleNode(String.Format("//app[@name='{0}']", AppName))

                'se non esiste lo creo
                If xmlAppNode Is Nothing Then

                    xmlAppNode = xmlDoc.CreateElement("app")
                    xmlAppNode.SetAttribute("name", AppName)
                    xmlDoc.AppendChild(xmlAppNode)
                End If

                'cerco il nodo del filtro
                xmlFiltroNode = xmlDoc.SelectSingleNode(String.Format("//app[@name='{0}']/filter[@name='{1}']",
                                                                      AppName, ComboBoxFiltri.Text))

                'se esiste lo cancello
                If xmlFiltroNode IsNot Nothing Then
                    xmlAppNode.RemoveChild(xmlFiltroNode)
                End If

                'ora creo il nodo
                xmlFiltroNode = xmlDoc.CreateElement("filter")
                xmlFiltroNode.SetAttribute("name", ComboBoxFiltri.Text)
                xmlAppNode.AppendChild(xmlFiltroNode)

                'aggiungo gli elementi del filtro
                For Each s As FiltroColonna In FiltroCorrente

                    Dim xmlSezioneNode As XmlElement = xmlDoc.CreateElement("column")
                    xmlFiltroNode.AppendChild(xmlSezioneNode)

                    With xmlSezioneNode
                        .SetAttribute("campo", s.Campo)
                        .SetAttribute("tipocampo", s.TipoCampo.ToString)
                        .SetAttribute("tipofiltro", s.TipoFiltro)
                        .SetAttribute("tiposelezione", s.Elementi)
                        .SetAttribute("operatore", s.Operatore.Codice)
                        .SetAttribute("chiave", s.Chiave)
                    End With

                    Dim e As XmlElement

                    Dim xmlValoriNode As XmlElement = xmlDoc.CreateElement("valori")
                    xmlSezioneNode.AppendChild(xmlValoriNode)

                    For Each i As ItemColonna In s.Items

                        e = xmlDoc.CreateElement("valore")
                        e.InnerText = i.Valore
                        xmlValoriNode.AppendChild(e)
                    Next
                Next

                'salvo
                xmlDoc.Save(NomeFile)

                MsgBox("Filtro salvato correttamente.", MsgBoxStyle.Information)
                InitComboBoxFiltri()
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function LeggiFiltroDaFile() As List(Of FiltroColonna)
        Try
            'se non è stato selezionato alcun filtro
            If ComboBoxFiltri.Text.Trim.Length = 0 Then
                Return Nothing
            End If

            Dim NomeFile As String = FileXml()

            If NomeFile.Length = 0 Then
                Return Nothing
            Else
                Dim xmlDoc As New XmlDocument
                Dim xmlFiltroNode As XmlElement

                'se il file esiste lo carico
                If File.Exists(NomeFile) = False Then
                    Return Nothing
                Else
                    xmlDoc.Load(NomeFile)

                    'cerco il nodo del filtro
                    xmlFiltroNode = xmlDoc.SelectSingleNode(String.Format("//app[@name='{0}']/filter[@name='{1}']",
                                                                          AppName, ComboBoxFiltri.Text))

                    'se esiste lo leggo
                    If xmlFiltroNode Is Nothing Then
                        MsgBox("Il filtro '{0}' non esiste. Scegliere un filtro dalla lista.", MsgBoxStyle.Exclamation)
                        Return Nothing
                    Else
                        Dim FiltroLetto As New List(Of FiltroColonna)

                        'per tutti i nodi figli del filtro (column)
                        For Each n As XmlElement In xmlFiltroNode.ChildNodes

                            Dim Filtro As New FiltroColonna
                            With Filtro
                                .Campo = n.GetAttribute("campo")
                                .TipoCampo = Type.GetType((n.GetAttribute("tipocampo")))
                                .TipoFiltro = n.GetAttribute("tipofiltro")
                                .Elementi = n.GetAttribute("tiposelezione")
                                .Chiave = n.GetAttribute("chiave")
                                'operatore
                                .Operatore = New Operatori(.TipoCampo).Operatore(n.GetAttribute("operatore"))

                                'aggiungo i valori
                                For Each Valori As XmlElement In n.ChildNodes
                                    'per ogni Valore in Valori
                                    For Each Valore As XmlElement In Valori.ChildNodes
                                        .Add(New ItemColonna(Valore.InnerText, .TipoCampo, .Elementi))
                                    Next
                                Next
                            End With

                            FiltroLetto.Add(Filtro)
                        Next

                        Return FiltroLetto
                    End If
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Private Sub CancellaFiltro()

        Try
            'controlli
            If ComboBoxFiltri.Text.Trim.Length = 0 Then
                Exit Sub
            End If

            Dim NomeFile As String = FileXml()

            If NomeFile.Length > 0 Then

                Dim xmlDoc As New XmlDocument
                Dim xmlAppNode, xmlFiltroNode As XmlElement

                'se il file esiste lo carico
                If File.Exists(NomeFile) Then

                    If MsgBox(String.Format("Cancellare il filtro '{0}'?", ComboBoxFiltri.Text),
                              MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2,
                              "Unitools") = MsgBoxResult.No Then

                        Exit Try
                    End If

                    xmlDoc.Load(NomeFile)

                    'cerco il nodo app
                    xmlAppNode = xmlDoc.SelectSingleNode(String.Format("//app[@name='{0}']", AppName))

                    'se esiste il nodo app
                    If xmlAppNode IsNot Nothing Then

                        'cerco il nodo del filtro
                        xmlFiltroNode = xmlDoc.SelectSingleNode(String.Format("//app[@name='{0}']/filter[@name='{1}']",
                                                                              AppName, ComboBoxFiltri.Text))

                        'se il nodo del filtro esiste
                        If xmlFiltroNode IsNot Nothing Then
                            'lo cancello
                            xmlAppNode.RemoveChild(xmlFiltroNode)
                            'salvo dopo la cancellazione
                            xmlDoc.Save(NomeFile)
                        Else
                            MsgBox(String.Format("Il filtro '{0}' non è stato trovato.", ComboBoxFiltri.Text),
                                   MsgBoxStyle.Exclamation, "Unitools")

                            Exit Try
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Function ListaFiltri() As List(Of String)

        ListaFiltri = New List(Of String)

        Try
            Dim NomeFile As String = FileXml()

            If NomeFile.Length > 0 Then

                Dim xmlDoc As New XmlDocument
                Dim xmlAppNode As XmlElement

                If File.Exists(NomeFile) Then
                    xmlDoc.Load(NomeFile)

                    xmlAppNode = xmlDoc.SelectSingleNode(String.Format("//app[@name='{0}']", AppName))

                    If xmlAppNode IsNot Nothing Then

                        Dim Filtri As XmlNodeList = xmlDoc.SelectNodes(String.Format("//app[@name='{0}']/filter", AppName))

                        For Each n As XmlElement In Filtri
                            ListaFiltri.Add(n.GetAttribute("name"))
                        Next
                    End If

                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Function

    Private Function FileXml() As String

        Try
            'creo la cartella se non esiste
            Directory.CreateDirectory(FilterFolder)

            If Directory.Exists(FilterFolder) Then
                Return Path.Combine(FilterFolder, String.Format("{0}.Filter.xml", AppName))
            Else
                MsgBox("Parametri errati per il salvataggio dei filtri", MsgBoxStyle.Exclamation)
                Return ""
            End If

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            MsgBox("Parametri errati per il salvataggio dei filtri", MsgBoxStyle.Exclamation)
            Return ""
        End Try

    End Function

    Private Function EsisteFiltro(NomeFiltro As String) As Boolean

        EsisteFiltro = False

        For Each s As String In ListaFiltri()

            If s = NomeFiltro Then
                EsisteFiltro = True
                Exit For
            End If
        Next
    End Function

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click
        If mModo = Modalita.FILTRO Then
            SalvaFiltro()
        Else
            'layout
            If String.IsNullOrEmpty(ComboBoxFiltri.Text) Then
                MsgBox("Indicare il nome da assegnare al layout.", MsgBoxStyle.Information, "Unitools")
                ComboBoxFiltri.Focus()
                Exit Sub
            End If

            'controllo se è modificabile
            If GestoreLayout.EditLayout(ComboBoxFiltri.Text.ToUpper) = False Then
                MsgBox("I layout predefiniti non possono essere modificati. Assegnare un nuovo nome al layout.",
                       MsgBoxStyle.Information, Globale.TitoloApp)
            Else
                'controllo se esiste già
                If GestoreLayout.ListaLayout.Contains(ComboBoxFiltri.Text.ToUpper) Then
                    If MsgBox("Un layout con questo nome già esiste. Volete sovrascriverlo?",
                              MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question,
                              Globale.TitoloApp) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
                'salvo
                GestoreLayout.SalvaLayout(ComboBoxFiltri.Text.ToUpper)
                RaiseEvent SalvatoLayout(ComboBoxFiltri.Text.ToUpper)
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        End If
    End Sub

    Private Sub ButtonCarica_Click(sender As Object, e As EventArgs) Handles ButtonCarica.Click
        'è possibile caricare solo i filtri e non i layout
        FiltroCaricato = LeggiFiltroDaFile()

        If FiltroCaricato IsNot Nothing Then
            RaiseEvent CaricatoFiltro(FiltroCaricato)
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub ComboBoxFiltri_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFiltri.SelectedIndexChanged
        If mModo = Modalita.FILTRO Then
            DettaglioFiltro(LeggiFiltroDaFile(), ComboBoxFiltri.Text)
        End If
    End Sub

    Private Sub ButtonCancella_Click(sender As Object, e As EventArgs) Handles ButtonCancella.Click
        If mModo = Modalita.FILTRO Then
            CancellaFiltro()
            InitComboBoxFiltri()
        Else
            'controllo se è modificabile
            If GestoreLayout.EditLayout(ComboBoxFiltri.Text.ToUpper) = False Then
                MsgBox("I layout predefiniti non possono essere eliminati.",
                       MsgBoxStyle.Information, Globale.TitoloApp)
                Exit Sub
            End If
            'elimino il layout
            If MsgBox(String.Format("Cancellare il layout '{0}'?", ComboBoxFiltri.Text),
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Unitools") = MsgBoxResult.Yes Then

                GestoreLayout.EliminaLayout(ComboBoxFiltri.Text.ToUpper)

                RaiseEvent EliminatoLayout(ComboBoxFiltri.Text.ToUpper)
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        End If
    End Sub
End Class