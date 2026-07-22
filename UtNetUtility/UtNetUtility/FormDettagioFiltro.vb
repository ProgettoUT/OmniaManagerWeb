Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Xml
Imports System.IO

Public Class FormDettagioFiltro

    Friend AppName As String
    Friend FilterFolder As String
    Friend FiltroCorrente As List(Of FiltroColonna)
    Friend FiltroCaricato As List(Of FiltroColonna)

    Private Sub FormDettagioFiltro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Icon = My.Resources.load16
        Me.BackColor = Color.Orange
        Me.Text = "Dettaglio filtro"

        Panel1.BackColor = Drawing.SystemColors.Control
        Label1.BackColor = Drawing.SystemColors.Control

        With TextBoxDettaglio
            .Font = New Font("Courier new", 10)
            .BackColor = Color.LightYellow
            .ReadOnly = True
        End With
        With ButtonSalva
            .Padding = New Padding(10, 0, 10, 0)
            .BackColor = Drawing.SystemColors.Control
            .Text = "Salva il filtro"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.salva16.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonCarica
            .Padding = New Padding(10, 0, 10, 0)
            .BackColor = Drawing.SystemColors.Control
            .Text = "Carica il filtro"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.load16.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonCancella
            .Padding = New Padding(10, 0, 10, 0)
            .BackColor = Drawing.SystemColors.Control
            .Text = "Elimina il filtro"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.cancel16.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonEsci
            .Padding = New Padding(10, 0, 10, 0)
            .BackColor = Drawing.SystemColors.Control
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.Esci.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With

        InitComboBoxFiltri()
    End Sub

    Private Sub InitComboBoxFiltri()

        ComboBoxFiltri.Items.Clear()

        For Each s As String In ListaFiltri()
            ComboBoxFiltri.Items.Add(s)
        Next

        ComboBoxFiltri.Text = ""
        TextBoxDettaglio.Text = ""
    End Sub

    Private Sub FormDettagioFiltro_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        DettaglioFiltro(FiltroCorrente, "Filtro corrente")
        ComboBoxFiltri.Focus()
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub DettaglioFiltro(ByRef Filtro As List(Of FiltroColonna),
                                ByVal Desk As String)

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

                'sb.AppendLine(String.Format(Space(5) + "Query: {0}", f.Query))
                sb.AppendLine()
            Next

            TextBoxDettaglio.Text = sb.ToString
            TextBoxDettaglio.SelectionStart = 0
        End If

    End Sub

    Public Sub SalvaFiltro()

        Try
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
            End If

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
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
            Globale.Log.BoxErrore(ex)
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
            Globale.Log.BoxErrore(ex)
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
            Globale.Log.BoxErrore(ex)
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
            Globale.Log.AddLog(ex.Message)
            MsgBox("Parametri errati per il salvataggio dei filtri", MsgBoxStyle.Exclamation)
            Return ""
        End Try

    End Function

    Private Function EsisteFiltro(ByVal NomeFiltro As String) As Boolean

        EsisteFiltro = False

        For Each s As String In ListaFiltri()

            If s = NomeFiltro Then
                EsisteFiltro = True
                Exit For
            End If
        Next
    End Function

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click

        If FiltroCorrente.Count = 0 Then
            MsgBox("Nessun filtro da salvare.", MsgBoxStyle.Exclamation, "Unitools")
            Exit Sub
        ElseIf String.IsNullOrEmpty(ComboBoxFiltri.Text) Then
            MsgBox("Indicare il nome da assegnare al filtro.", MsgBoxStyle.Exclamation, "Unitools")
            ComboBoxFiltri.Focus()
        Else
            SalvaFiltro()
            InitComboBoxFiltri()
        End If
    End Sub

    Private Sub ButtonCarica_Click(sender As Object, e As EventArgs) Handles ButtonCarica.Click

        FiltroCaricato = LeggiFiltroDaFile()

        If FiltroCaricato IsNot Nothing Then
            Me.Close()
        End If
    End Sub

    Private Sub ComboBoxFiltri_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFiltri.SelectedIndexChanged
        DettaglioFiltro(LeggiFiltroDaFile(), ComboBoxFiltri.Text)
    End Sub

    Private Sub ButtonCancella_Click(sender As Object, e As EventArgs) Handles ButtonCancella.Click
        CancellaFiltro()
        InitComboBoxFiltri()
    End Sub
End Class