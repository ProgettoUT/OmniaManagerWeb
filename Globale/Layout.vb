Imports System.IO
Imports System.Xml
Imports System.Windows.Forms
Imports System.Drawing
Imports ADOX
Imports Microsoft.Office.Interop.Excel

Public Class Layout

    Private mLayoutFile As String
    Private mFilterFile As String

    Sub New()
    End Sub

    Private mXmlSetting As String
    ''' <summary>
    ''' nome principale per i file di layout e di filtro
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property XmlSetting() As String
        Get
            Return mXmlSetting
        End Get
        Set(value As String)
            mXmlSetting = value
            'imposta il file layout e il file per i filtri
            mLayoutFile = Path.Combine(Utx.Globale.Paths.CartellaSettingRete, mXmlSetting + ".layout.xml")
            mFilterFile = Path.Combine(Utx.Globale.Paths.CartellaSettingRete, mXmlSetting + ".Filter.xml")
            'se il layout non esiste lo copio dall'installazione
            If File.Exists(mLayoutFile) = False Then
                Dim Modello As String = Path.Combine(Utx.Globale.Paths.CartellaSetting, mXmlSetting + ".layout.xml")
                'se esiste il modello
                If File.Exists(Modello) Then
                    File.Copy(Modello, mLayoutFile)
                Else
                    MsgBox(String.Format("Attenzione: non è stato trovato alcun layout disponibile del tipo {0}.layout.xml", mXmlSetting),
                           MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                End If
            End If
            'Leggi la lista dei layout
            LeggiListaLayout()
        End Set
    End Property

    Private mListaLayout As New List(Of String)
    Public Property ListaLayout() As List(Of String)
        Get
            Return mListaLayout
        End Get
        Set(value As List(Of String))
            mListaLayout = value
        End Set
    End Property

    Private mGestoreLayout As Utx.FormGestioneFiltro
    Public Property GestoreLayout() As Utx.FormGestioneFiltro
        Get
            Return mGestoreLayout
        End Get
        Set(value As Utx.FormGestioneFiltro)
            mGestoreLayout = value
        End Set
    End Property

    Private mGriglia As DataGridView
    Public Property Griglia() As DataGridView
        Get
            Return mGriglia
        End Get
        Set(value As DataGridView)
            mGriglia = value
        End Set
    End Property

    Private mLayoutCorrente As String
    Public Property LayoutCorrente() As String
        Get
            Return mLayoutCorrente
        End Get
        Set(value As String)
            mLayoutCorrente = value
            CaricaLayoutGriglia(mLayoutCorrente)
        End Set
    End Property

    Public Sub LeggiListaLayout()
        'leggo i layout disponibili e li metto nella lista
        Try
            If File.Exists(mLayoutFile) = False Then
                Exit Sub
            End If

            Dim xDoc As New XmlDocument
            xDoc.Load(mLayoutFile)

            mListaLayout.Clear()

            Dim xnl As XmlNodeList = xDoc.SelectNodes("//grid")

            For Each xn As XmlNode In xnl
                mListaLayout.Add(xn.Attributes("name").InnerText)
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub CaricaLayoutGriglia(NomeLayout As String)
        Try
            Griglia.Visible = False
            Griglia.SuspendLayout()
            'font
            Griglia.Font = Utx.FormGestioneFiltro.LeggiFontDaXml(mLayoutFile, NomeLayout)

            'inizializza la struttura layout delle colonne
            'legge il layout dal file xml
            GestoreLayout.LeggiLayoutDaXml(mLayoutFile, NomeLayout)

            Dim col As DataGridViewTextBoxColumn

            Griglia.Columns.Clear()
            Griglia.AutoGenerateColumns = False

            For Each l As Utx.LayoutColonna In GestoreLayout.LayoutColonne

                col = New DataGridViewTextBoxColumn

                With col
                    .HeaderText = l.Titolo
                    .Name = l.Campo
                    .DataPropertyName = l.Campo
                    .SortMode = DataGridViewColumnSortMode.Programmatic
                    .Width = l.Larghezza
                    .Tag = l.Nascosta
                    .Visible = l.Visibile
                    .DefaultCellStyle.Alignment = l.Allineamento
                    .DefaultCellStyle.Format = l.Formato

                    If l.ColoreTesto < 0 Then
                        .DefaultCellStyle.ForeColor = Color.FromArgb(l.ColoreTesto)
                    End If
                    If l.ColoreSfondo < 0 Then
                        .DefaultCellStyle.BackColor = Color.FromArgb(l.ColoreSfondo)
                    End If

                    If l.DisplayIndex < 0 Then
                        .DisplayIndex = Griglia.Columns.Count
                    Else
                        .DisplayIndex = l.DisplayIndex
                    End If
                End With

                Griglia.Columns.Add(col)
            Next

        Catch ex As System.Exception
            Globale.Log.Errore(ex)
        Finally
            Griglia.Visible = True
            Griglia.ResumeLayout()
        End Try
    End Sub

    Public Function EditLayout(NomeLayout As String) As Boolean
        Return GestoreLayout.EditLayout(mLayoutFile, NomeLayout)
    End Function

    Public Sub SalvaLayout(Optional NomeLayout As String = "")
        'se non viene passato il nome salvo il layout corrente
        If NomeLayout.Trim.Length = 0 Then
            NomeLayout = mLayoutCorrente
        End If

        If GestoreLayout.EditLayout(mLayoutFile, NomeLayout) = True Then
            SalvaLayoutConNome(NomeLayout)
        End If
    End Sub

    Private Sub SalvaLayoutConNome(NomeLayout As String)
        Try
            If Griglia.Columns.Count = 0 Then
                Exit Sub
            End If

            Dim Edit As Boolean = GestoreLayout.EditLayout(mLayoutFile, NomeLayout)

            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(mLayoutFile)

            'nodo layout
            Dim xl As XmlElement = xmlDoc.SelectSingleNode("//layout")
            'nodo griglia
            Dim xgn As XmlElement = xmlDoc.SelectSingleNode(String.Format("//grid[@name='{0}']", NomeLayout))

            If xgn IsNot Nothing Then
                'se esiste lo cancello
                xl.RemoveChild(xgn)
            End If

            'creo il nodo della griglia
            xgn = xmlDoc.CreateElement("grid")
            xgn.SetAttribute("name", NomeLayout)

            'aggiungo il font
            xgn.AppendChild(mGestoreLayout.CreaElementoFont(xgn))
            'aggiungo property
            xgn.AppendChild(mGestoreLayout.CreaElementoProperty(xgn, Edit))

            'ordino il layout per display index per facilità di lettura dell'xml
            mGestoreLayout.SortLayout()

            'aggiungo il layout delle colonne
            For Each l As Utx.LayoutColonna In mGestoreLayout.LayoutColonne
                xgn.AppendChild(mGestoreLayout.CreaElementoColonna(xgn, l))
            Next

            'il nodo corrente viene aggiunto per primo così diventa il predefinito
            xl.PrependChild(xgn)

            'pulisco il doc e appendo il nodo principale xl
            xmlDoc.RemoveAll()
            xmlDoc.AppendChild(xl)
            'salvo
            xmlDoc.Save(mLayoutFile)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub ImpostaLayoutPredefinito(NomeLayout As String)
        Try
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(mLayoutFile)

            'nodo layout
            Dim xl As XmlElement = xmlDoc.SelectSingleNode(String.Format("//layout", NomeLayout))

            'se il predefinito è diverso da quello attuale
            If xl.FirstChild.Attributes("name").Value.ToUpper <> NomeLayout.ToUpper Then

                'recupero il nuovo predefinito
                Dim xPredefinito As XmlElement = xmlDoc.SelectSingleNode(String.Format("//grid[@name='{0}']", NomeLayout))

                If xPredefinito IsNot Nothing Then
                    'se esiste la cancello dall'attuale posizione
                    xl.RemoveChild(xPredefinito)
                    'e lo salvo come primo nodo
                    xl.PrependChild(xPredefinito)
                    'pulisco il doc e appendo il nodo principale (xl) dei layout
                    xmlDoc.RemoveAll()
                    xmlDoc.AppendChild(xl)
                    'salvo il file
                    xmlDoc.Save(mLayoutFile)
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub EliminaLayout(NomeLayout As String)
        Try
            Dim Edit As Boolean = GestoreLayout.EditLayout(mLayoutFile, NomeLayout)

            Dim xmlDoc, xmlClone As New XmlDocument
            xmlDoc.Load(mLayoutFile)
            xmlClone = xmlDoc.Clone

            'nodo layout
            Dim xl As XmlElement = xmlDoc.SelectSingleNode("//layout")
            'nodo griglia
            Dim xgn As XmlElement = xmlDoc.SelectSingleNode(String.Format("//grid[@name='{0}']", NomeLayout))

            'se la griglia non esiste la creo
            If xgn Is Nothing Then
                Exit Sub
            Else
                xl.RemoveChild(xgn)
            End If

            'pulisco il doc e appendo il nodo principale xs
            xmlDoc.RemoveAll()
            xmlDoc.AppendChild(xl)
            'salvo
            xmlDoc.Save(mLayoutFile)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Sub AggiungiColonna(LayoutFile As String,
                                      Name As String,
                                      Text As String,
                                      Hide As Boolean,
                                      Visible As Boolean,
                                      Width As String,
                                      Argbforecolor As String,
                                      Argbbackcolor As String,
                                      Alignment As String,
                                      Format As String,
                                      Optional Prima As String = "", Optional Dopo As String = "")
        'leggo i layout disponibili e li metto nella lista
        Try
            If File.Exists(LayoutFile) = False Then
                Exit Sub
            End If

            'se l'elemento esiste lo rimuovo, in tutti i layout, per poterlo modificare
            CancellaColonna(LayoutFile, Name)

            Dim xDoc As New XmlDocument
            xDoc.Load(LayoutFile)

            'per ogni griglia contenuta nel layout
            For Each Griglia As XmlElement In xDoc.SelectSingleNode("//layout")
                'per la griglia completa forzo edit = false
                If Griglia.GetAttribute("name") = "COMPLETO" Then
                    Dim el As XmlElement = Griglia.SelectSingleNode("property")
                    If el IsNot Nothing Then
                        el.SetAttribute("edit", False)
                    End If
                End If

                'creo il nuovo elemento con un displayindex fittizio
                Dim e As XmlElement = Griglia.OwnerDocument.CreateElement("column")
                With e
                    .SetAttribute("name", Name)
                    .SetAttribute("text", Text)
                    .SetAttribute("hide", Hide)
                    .SetAttribute("visible", Visible)
                    .SetAttribute("width", Width)
                    .SetAttribute("argbforecolor", Argbforecolor)
                    .SetAttribute("argbbackcolor", Argbbackcolor)
                    .SetAttribute("displayindex", "0")
                    .SetAttribute("alignment", Alignment)
                    .SetAttribute("format", Format)
                End With

                'cerco il nodo riferimento e aggiungo prima o dopo. se non esiste aggiungo alla fine
                Dim Ref As XmlElement
                If String.IsNullOrEmpty(Prima) = False Then
                    Ref = Griglia.SelectSingleNode(String.Format("column[@name='{0}']", Prima))
                    If Ref IsNot Nothing Then
                        Griglia.InsertBefore(e, Ref)
                    Else
                        Griglia.AppendChild(e) 'se non lo trovo aggiungo alla fine
                    End If
                ElseIf String.IsNullOrEmpty(Dopo) = False Then
                    Ref = Griglia.SelectSingleNode(String.Format("column[@name='{0}']", Dopo))
                    If Ref IsNot Nothing Then
                        Griglia.InsertAfter(e, Ref)
                    Else
                        Griglia.AppendChild(e)
                    End If
                Else
                    Griglia.AppendChild(e)
                End If

                'riordino l'indice di visualizzazione
                Dim Index As Integer = 0
                For Each el As XmlElement In Griglia.SelectNodes("column")
                    el.SetAttribute("displayindex", Index)
                    Index += 1
                Next
            Next

            'salvo
            xDoc.Save(LayoutFile)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Sub CancellaColonna(LayoutFile As String, Name As String)
        'leggo i layout disponibili e li metto nella lista
        Try
            If File.Exists(LayoutFile) = False Then
                Exit Sub
            End If

            Dim xDoc As New XmlDocument
            xDoc.Load(LayoutFile)

            'per ogni griglia contenuta nel layout
            For Each Griglia As XmlElement In xDoc.SelectSingleNode("//layout")
                'se l'elemento esiste lo rimuovo anche se è più di uno
                Dim OldNode As XmlNodeList = Griglia.SelectNodes(String.Format("column[@name='{0}']", Name))
                For Each n As XmlNode In OldNode
                    Griglia.RemoveChild(n)
                Next
            Next

            'salvo
            xDoc.Save(LayoutFile)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
