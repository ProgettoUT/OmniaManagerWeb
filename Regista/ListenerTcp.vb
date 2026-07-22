Imports System.Net
Imports System.Net.Sockets
Imports System.Reflection
Imports System.IO

Public Class ListenerTcp
    Private LocalIP As String = "0.0.0.0"
    Private NetIP As String
    Private NetPort As Integer = 0
    Private Listener As TcpListener

    Public StopListener As Boolean = False
    Public Const INDIP_BASE As String = "127.0.0.1"
    Public Const PORTA_BASE As Integer = 10000

    Public Shared Log As New Utx.ApplicationLog("Regista.log", LogCondiviso:=True)
    Public Shared ExeName As String = Process.GetCurrentProcess().MainModule.ModuleName
    Public Shared Instance As ListenerTcp


    Sub New()
        Listener = New TcpListener(IPAddress.Loopback, 0)
        Listener.Start()
        NetPort = CType(Listener.LocalEndpoint, IPEndPoint).Port
        NetIP = CType(Listener.LocalEndpoint, IPEndPoint).Address.ToString
        Listener.Stop()
        Listener = Nothing
        Instance = Me
    End Sub

    Sub New(localPort As Integer)
        Listener = New TcpListener(IPAddress.Loopback, localPort)
        Listener.Start()
        NetPort = CType(Listener.LocalEndpoint, IPEndPoint).Port
        NetIP = CType(Listener.LocalEndpoint, IPEndPoint).Address.ToString
        Listener.Stop()
        Listener = Nothing
        Instance = Me
    End Sub

    Public Sub StartListenAsync()
        Dim newThread As New Threading.Thread(AddressOf StartListen)
        newThread.Start()
    End Sub

    Public Sub StartListen()
        Try
            Log.Info(String.Format("{0} - Inizio ascolto [via TCP] {1}:{2}", ExeName, LocalIP, NetPort))

            Listener = New TcpListener(IPAddress.Parse(LocalIP), NetPort)
            Listener.Start()

            ' do the listening loop.
            Do
                'Log.Debug(String.Format("{0} - Pronto e in attesa di connessioni [via TCP] alla porta {1}", ExeName, NetPort))
                Dim client As TcpClient = Listener.AcceptTcpClient()
                Log.Debug(String.Format("{0} - Connessione [via TCP] accettata!", ExeName))

                'Chiamata asincrona per la elaborazione della richiesta
                Dim newThread As New Threading.Thread(AddressOf Me.Perform)
                'newThread.ApartmentState = Threading.ApartmentState.STA
                newThread.Start(client)


            Loop Until StopListener
        Catch e As SocketException
            If e.SocketErrorCode <> SocketError.Interrupted Then
                Log.Debug(String.Format("SocketException {0}:", e))
            End If
        Catch ex As Exception
            Log.Debug(ex.Message)
        Finally
            Listener.Stop()
        End Try
    End Sub

    Public Sub Perform(data As Object)
        Dim bytes(8024) As Byte
        Dim client As TcpClient = CType(data, TcpClient)
        Dim stream As NetworkStream = client.GetStream()
        Dim i As Int32 = stream.Read(bytes, 0, bytes.Length)
        Dim richiesta As New Richiesta(System.Text.Encoding.ASCII.GetString(bytes, 0, i))

        Log.Debug(String.Format("{0} - Elaboro richiesta [via TCP]: {1}{2}", ExeName, vbNewLine, richiesta.RawData))

        Dim risposta As Risposta = New Risposta()

        Dim assem As Assembly = GetType(Main).Assembly

        Dim t As Type = assem.GetType("Regista." & richiesta.Ambito)
        If t IsNot Nothing Then
            Dim s As Servlet = CType(t.InvokeMember("GetInstance", BindingFlags.Public Or BindingFlags.Static Or BindingFlags.GetProperty, Nothing, Nothing, New Object() {}), Servlet)
            If s Is Nothing Then s = CType(Activator.CreateInstance(t), Servlet)
            s.performRequest(richiesta, risposta)
        Else
            risposta.RispondiOK()
        End If

        Dim msg As Byte() = System.Text.Encoding.ASCII.GetBytes(risposta.RawData)
        Log.Debug(String.Format("{0} - risposta [via TCP]: {1}{2}", ExeName, vbNewLine, risposta.RawData))

        stream.Write(msg, 0, msg.Length)
        stream.Close()
        client.Close()

        If StopListener = True Then
            Log.Debug(String.Format("{0} - Eseguo stop del Listener[TCP]", ExeName))
            Listener.Stop()
            Log.Debug(String.Format("{0} - Listener[TCP] stopped", ExeName))
        End If
    End Sub

    Public ReadOnly Property IP As String
        Get
            Return NetIP
        End Get
    End Property

    Public ReadOnly Property Port As Integer
        Get
            Return NetPort
        End Get
    End Property

    Public Shared Function GetUrlBase(ambito As String) As String
        Return "http://" & INDIP_BASE & ":" & PORTA_BASE & "/" & ambito
    End Function

    Public Sub StopListen()

        If Listener.Pending Then
            Log.Debug(String.Format("{0} - stopping Listener[TCP]", ExeName))
            StopListener = True
        Else
            Listener.Stop()
            Log.Debug(String.Format("{0} - Listener[TCP] stopped", ExeName))
        End If
    End Sub

    Public Shared Function CallWeb(url As String) As String
        Try
            Log.Debug(Process.GetCurrentProcess().MainModule.ModuleName & " - " & url)
            Dim request As WebRequest = HttpWebRequest.Create(url)
            request.Timeout = 30000 '10 secondi

            ' Get the response.
            Dim response As WebResponse = request.GetResponse()

            ' Get the stream containing content returned by the server.
            Dim resStream As Stream = response.GetResponseStream()

            ' Open the stream using a StreamReader for easy access.
            Dim reader As New StreamReader(resStream)

            ' Read the content.
            Dim responseFromServer As String = reader.ReadToEnd()

            ' Clean up the streams.
            reader.Close()
            resStream.Close()
            response.Close()

            Log.Debug(Process.GetCurrentProcess().MainModule.ModuleName & " - " & responseFromServer)
            Return responseFromServer

        Catch ex As Exception
            Log.Debug(Process.GetCurrentProcess().MainModule.ModuleName & " - " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Sub CallWebAsync(url As String)
        Dim wc As New WebClient
        AddHandler wc.DownloadStringCompleted, AddressOf DownloadCompletedHander
        wc.DownloadStringAsync(New Uri(url))
    End Sub

    Public Shared Sub DownloadCompletedHander(sender As Object, e As DownloadStringCompletedEventArgs)
        If e.Cancelled = False AndAlso e.Error Is Nothing Then
            Dim myString As String = CStr(e.Result)
        End If
    End Sub

    Public Shared Function getMyIp() As IPAddress
        Dim s As IPAddress = Nothing

        For Each x In Dns.GetHostEntry(Dns.GetHostName()).AddressList
            Debug.Print(x.ToString)
            If Not x.IsIPv6LinkLocal And Not x.IsIPv6Multicast And Not x.IsIPv6SiteLocal Then
                Return x
            End If
        Next
        Return Nothing
    End Function

End Class
