Imports System.Xml

Public Class CXml
    Private m_domd As New XmlDocument

    Public ReadOnly Property Document() As XmlDocument
        Get
            Return m_domd
        End Get
    End Property

    Public Function ParseXML(sXmlSource As String) As Boolean
        m_domd.LoadXml(sXmlSource)
        Return True
    End Function

    Public Function LoadXML(NomeFile As String) As Boolean
        If My.Computer.FileSystem.FileExists(NomeFile) = False Then
            MsgBox("Impossibile trovare il file " & NomeFile & ".")
        End If

        m_domd.Load(NomeFile)

        Return True
    End Function

    Public Function LoadEncriptedXML(NomeFile As String) As Boolean
        Dim sFileCopy() As Byte = My.Computer.FileSystem.ReadAllBytes(NomeFile)
        LoadEncriptedXML = ParseXML(RC43(sFileCopy, False))
    End Function

    Public Function SaveXML(NomeFile As String) As Boolean
        If NomeFile = "" Then Return False
        m_domd.Save(NomeFile)
        Return True
    End Function

    Public Function GetNodeText(ByRef nodeName As String, Optional nodo As XmlNode = Nothing) As String
        Dim n As XmlNode

        If nodo Is Nothing Then
            n = m_domd.SelectSingleNode(nodeName)
        Else
            n = nodo.SelectSingleNode(nodeName)
        End If

        If Not n Is Nothing Then
            Return n.InnerText
        End If

        Return ""
    End Function

    Public Function GetNodeBool(ByRef nodeName As String, Optional nodo As XmlNode = Nothing) As Boolean
        GetNodeBool = StringToBool(GetNodeText(nodeName, nodo))
    End Function

    Public Function GetNode(ByRef nodeName As String) As XmlNode
        Return m_domd.SelectSingleNode(nodeName)
    End Function

    Public Function GetNodes(ByRef nodeName As String) As XmlNodeList
        GetNodes = m_domd.SelectNodes(nodeName)
    End Function

    Public Function CreateNode(ByRef nodeName As String) As XmlNode
        CreateNode = m_domd.CreateNode(XmlNodeType.Element, nodeName, "")
    End Function

    Public Function CreateAttibute(ByRef nodeName As String, ByRef nodeValue As String) As XmlNode
        CreateAttibute = m_domd.CreateAttribute(nodeName)
        CreateAttibute.Value = nodeValue
    End Function

    Public Function CreateNodeText(ByRef nodeName As String, ByRef nodeText As String) As XmlNode
        CreateNodeText = m_domd.CreateNode(XmlNodeType.Element, nodeName, "")
        CreateNodeText.AppendChild(m_domd.CreateTextNode(nodeText))
    End Function

    Public Function GetAttributeText(ByRef Node As XmlNode, sName As String) As String
        If Not Node Is Nothing Then
            If Node.Attributes.Count > 0 Then
                Dim n As XmlNode
                n = Node.Attributes.GetNamedItem(sName)
                If Not n Is Nothing Then
                    Return n.Value
                End If
            End If
        End If
        Return vbNullString
    End Function

    Public Function GetAttributeBool(ByRef Node As XmlNode, sName As String) As Boolean
        GetAttributeBool = StringToBool(GetAttributeText(Node, sName))
    End Function

    Public Function GetAttributeLong(ByRef Node As XmlNode, sName As String) As Long
        GetAttributeLong = GetAttributeText(Node, sName)
    End Function

    Public Function GetXmlset(sXPath As String) As Collection
        Dim row As XmlNode
        Dim col As XmlNode
        Dim riga As Collection

        GetXmlset = New Collection

        For Each row In m_domd.SelectNodes(sXPath)
            riga = New Collection
            GetXmlset.Add(riga)

            For Each col In row.Attributes
                riga.Add(col.Value, col.Name)
            Next
        Next
    End Function

End Class
