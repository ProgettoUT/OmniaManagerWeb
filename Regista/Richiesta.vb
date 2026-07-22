Public Class Richiesta
    Public Ambito As String
    Public RawData As String
    Private mParametri As New Dictionary(Of String, String)

    Public ReadOnly Property Parametri(nome As String) As String
        Get
            If mParametri.ContainsKey(nome) Then
                Return mParametri(nome)
            Else
                Return ""
            End If
        End Get
    End Property

    Public Shared ReadOnly Property Valore(Parametri As Dictionary(Of String, String), Key As String) As String
        Get
            If Parametri.ContainsKey(Key) Then
                Return Parametri(Key)
            Else
                Return ""
            End If
        End Get
    End Property

    Public ReadOnly Property Parametri() As Dictionary(Of String, String)
        Get
            Return mParametri
        End Get
    End Property

    Public Sub New(RawData As String)
        If RawData Is Nothing Then
            RawData = "GET /Strano HTTP/1.1"
        End If
        Me.RawData = RawData

        'tolgo il protocollo (GET, POST, ECC)
        RawData = RawData.Substring(1 + RawData.IndexOf(" "))
        'e la versione (HTTP/1.1)
        RawData = RawData.Substring(0, RawData.IndexOf(" HTTP/1.1"))
        If RawData.StartsWith("/") Then
            RawData = RawData.Substring(1)
        End If

        Dim ambito As String = Nothing
        Dim querystring As String = Nothing

        Dim i As Integer = RawData.IndexOf("?")
        If i < 0 Then
            ambito = RawData
        Else
            ambito = RawData.Substring(0, i)
            querystring = RawData.Substring(1 + i)
        End If
        Me.Ambito = ambito

        If querystring IsNot Nothing Then
            For Each coppia In querystring.Split("&"c)
                Dim chiavevalore As String() = coppia.Split("="c)
                If chiavevalore.Length = 2 Then
                    If Not mParametri.ContainsKey(chiavevalore(0)) Then
                        mParametri.Add(chiavevalore(0), chiavevalore(1))
                    End If
                End If
            Next
        End If
    End Sub

    Public ReadOnly Property getQuerystring() As String
        Get
            Dim url As String = ""
            If mParametri.Count > 0 Then
                url &= "?"
            End If

            For Each par In mParametri
                If Not url.EndsWith("?") Then
                    url &= "&"
                End If
                url &= par.Key & "=" & par.Value
            Next

            Return url
        End Get
    End Property

End Class
