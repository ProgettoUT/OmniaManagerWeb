#If DEBUG Then
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization

<TestClass>
Public Class EssigUtil

    Public TestContext As TestContext

    '<TestMethod>
    Sub creaxml()
        Dim p As New EPagina

        Dim objStream As New StreamWriter("c:\temp\epagina.xml")
        Dim x As New System.Xml.Serialization.XmlSerializer(p.GetType)
        x.Serialize(objStream, p)
        objStream.Close()
        Assert.IsTrue(True)
    End Sub

    <Serializable()> Public Class EPagina
        Public Url As String
        Public AttivoSe As String
        Public Parametri As New List(Of EParametro)

        Public Sub New()
            Parametri.Add(New EParametro("nome1", "valore1", "funzione1"))
            Parametri.Add(New EParametro("nome2", "valore2", "funzione2"))
            Parametri.Add(New EParametro("nome3", "valore3", "funzione3"))
            Parametri.Add(New EParametro("nome4", "valore4", "funzione4"))
        End Sub
    End Class

    <Serializable()> Public Class EParametro
        <XmlAttribute>
        Public Nome As String
        <XmlAttribute>
        Public Valore As String
        <XmlAttribute>
        Public Funzione As String

        Public Sub New()
        End Sub

        Public Sub New(nome As String, valore As String, funzione As String)
            Me.Nome = nome
            Me.Valore = valore
            Me.Funzione = funzione
        End Sub
    End Class


    '<TestMethod>
    Sub ConverFile()
        Dim linee As New List(Of String)

        Dim fileIn() As String = File.ReadAllLines("c:\users\pecoraro\desktop\essigIN.txt")

        For Each linea In fileIn
            linea = linea.Trim
            If linea = "Key	Value" Or linea = "" Then
                ' non fa nulla
            ElseIf linea.IndexOf("HTTP/1.1") >= 0 Then
                linea = linea.Substring(0, linea.IndexOf("HTTP/1.1"))
                linea = linea.Substring(1 + linea.LastIndexOf("/"), linea.LastIndexOf(".do") - linea.LastIndexOf("/"))

                linee.Add("")
                linee.Add("        <!-- -->")
                linee.Add("        <Pagina>")
                linee.Add("          <Url>Danni/essigRE/danni/emissione/" & linea & "do</Url>")
            Else
                Dim pars As String() = linea.Split("&"c)

                linee.Add("          <Parametri>")
                For Each par In pars
                    Dim uguale As Integer = par.IndexOf("=")
                    Dim nome As String = par.Substring(0, uguale)
                    Dim valore As String = par.Substring(1 + uguale)

                    If nome.EndsWith(".checkbox") Then
                    ElseIf nome.EndsWith("PremioAnnuo.value") Then
                    ElseIf nome.EndsWith("PremioTariffa.value") Then
                    Else
                        linee.Add("            <Parametro>")
                        linee.Add("              <Nome>" & nome & "</Nome>")
                        If valore <> "" Then
                            linee.Add("              <Valore>=" & URLDecode(valore) & "</Valore>")
                        End If
                        linee.Add("            </Parametro>")
                    End If
                Next
                linee.Add("          </Parametri>")
                linee.Add("        </Pagina>")
            End If
        Next


        'For Each linea In fileIn
        '    linea = linea.Trim
        '    If linea = "Key	Value" Then
        '        startpage = True
        '        linee.Add("")
        '        linee.Add("        <!-- -->")
        '        linee.Add("        <Pagina>")
        '        parametri = False
        '    ElseIf linea = "" And startpage = True Then
        '        linee.Add("          </Parametri>")
        '        linee.Add("        </Pagina>")
        '        startpage = False
        '    ElseIf linea.IndexOf(".do") >= 0 Then
        '        Dim pagina As String = linea.Substring(1 + linea.LastIndexOf("/"), linea.LastIndexOf(".do") - linea.LastIndexOf("/"))
        '        linee.Add("          <Url>Danni/essigRE/danni/emissione/" & pagina & "do</Url>")
        '        If linea.IndexOf("HTTP/1.1") >= 0 Then
        '            parametri = True
        '            linee.Add("          <Parametri>")
        '        End If
        '    ElseIf linea.IndexOf("HTTP/1.1") >= 0 Then
        '        parametri = True
        '        linee.Add("          <Parametri>")
        '    ElseIf linea <> "" And parametri = True Then
        '        Dim uguale As Integer = linea.IndexOf("=")
        '        Dim nome As String = linea.Substring(0, uguale)
        '        Dim valore As String = linea.Substring(1 + uguale)

        '        If nome.EndsWith(".checkbox") = False Then
        '            linee.Add("            <Parametro>")
        '            linee.Add("              <Nome>" & nome & "</Nome>")
        '            If valore <> "" Then
        '                linee.Add("              <Valore>=" & URLDecode(valore) & "</Valore>")
        '            End If
        '            linee.Add("            </Parametro>")
        '        End If
        '    End If
        'Next

        File.WriteAllLines("c:\users\pecoraro\desktop\essigOUT.txt", linee.ToArray)
        Assert.IsTrue(True)
    End Sub

    Private Function URLDecode(ByVal Source As String) As String
        Dim x As Integer = 0
        Dim CharVal As Byte = 0
        Dim sb As New System.Text.StringBuilder()

        For x = 0 To (Source.Length - 1)
            Dim c As Char = Source(x)
            'Check for space
            If (c = "+") Then
                sb.Append(" ")
            ElseIf c <> "%" Then
                'Not hex value so add the chars to string builder.
                sb.Append(c)
            Else
                'Convert hex value to char value.
                CharVal = Int("&H" & Source(x + 1) & Source(x + 2))
                'Add the chars to string builder.
                sb.Append(Chr(CharVal))
                'INC by 2
                x += 2
            End If
        Next

        'Return the string.
        Return sb.ToString()

    End Function
End Class
#End If
