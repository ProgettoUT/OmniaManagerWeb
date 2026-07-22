Imports System.Net.Sockets
Imports System.Reflection

Public Class ListenerFile
    ' il nome del file del messaggio è:
    ' - portaDestinazione_portaOrifine_timestamp se si aspetta una risposta di ritorno
    ' - portaDestinazione_timestamp se l'eventuale risposta non è considerata dal chiamante

    Public ReadOnly Address As String
    Public ReadOnly Port As Integer 'indica l'id unico del ricevente, che coincide con l'interno

    Public Shared ExeName As String = Process.GetCurrentProcess().MainModule.ModuleName
    Public Shared Instance As ListenerTcp
    Public StopListener As Boolean = False

    Public Shared CartellaScambioCentralino As String = Utx.Globale.Paths.CartellaCentralinoRete
    Public Shared CartellaElaborati As String = IO.Path.Combine(Utx.Globale.Paths.CartellaCentralinoRete, "Elaborati")

    Public Sub New(port As Integer)
        Me.Address = My.Computer.Name
        Me.Port = port
        IO.Directory.CreateDirectory(CartellaElaborati)
    End Sub

    Public Sub StartListenAsync()
        Dim newThread As New Threading.Thread(AddressOf StartListen)
        newThread.Start()
    End Sub

    Public Sub StartListen()
        Try
            ListenerTcp.Log.Info(String.Format("{0} - Inizio ascolto [via FILE] cartella {1}, porta {2}", ExeName, CartellaScambioCentralino, Port))

            ' do the listening loop.
            Do
                'ListenerTcp.Log.Debug(String.Format("{0} - Pronto e in attesa di messaggi [via FILE] alla porta {1}", ExeName, Port))
                Dim fileRichiesta As String = AcceptMsgClient()

                If fileRichiesta IsNot Nothing Then
                    If fileRichiesta.Contains(Port.ToString & "_richiesta_") Then
                        ListenerTcp.Log.Debug(String.Format("{0} - Connessione [via FILE] accettata!", ExeName))

                        'Chiamata asincrona per la elaborazione della richiesta
                        Dim newThread As New Threading.Thread(AddressOf Me.Perform)
                        'newThread.ApartmentState = Threading.ApartmentState.STA
                        newThread.Start(fileRichiesta)
                        'ElseIf Not fileRichiesta.Contains("_richiesta_") Then
                        '    'momentaneamente le risposte non sono importanti
                        '    My.Computer.FileSystem.DeleteFile(fileRichiesta)
                    End If
                End If
            Loop Until StopListener
        Catch ex As Exception
            ListenerTcp.Log.Info(ex)
        Finally
            StopListener = True
        End Try
    End Sub

    Public Function AcceptMsgClient() As String
        Do
            Try
                'una verifica ogni secondo se sono presenti dei file
                Threading.Thread.Sleep(1000)

                Dim files As String() = IO.Directory.GetFiles(CartellaScambioCentralino, Port & "*")
                If files.Length > 0 Then
                    Return files(0)
                End If
            Catch ex As Exception
                ListenerTcp.Log.Info(ex)
            End Try
        Loop Until StopListener

        Return Nothing
    End Function

    Public Sub Perform(data As Object)
        Try

            Dim fileRichiesta As String = CType(data, String)
            Dim richiesta As New Richiesta(IO.File.ReadAllText(fileRichiesta))
#If DEBUG Then
            My.Computer.FileSystem.MoveFile(fileRichiesta, IO.Path.Combine(CartellaElaborati, IO.Path.GetFileName(fileRichiesta)))
#Else
        My.Computer.FileSystem.MoveFile(fileRichiesta, IO.Path.Combine(CartellaElaborati, IO.Path.GetFileName(fileRichiesta)))
        'My.Computer.FileSystem.DeleteFile(fileRichiesta)
#End If

            ListenerTcp.Log.Debug(String.Format("{0} - Elaboro richiesta [via FILE]: {1}{2}", ExeName, vbNewLine, richiesta.RawData))

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
            ListenerTcp.Log.Debug(String.Format("{0} - risposta [via FILE]: {1}{2}", ExeName, vbNewLine, risposta.RawData))

            'momentaneamente non invio risposta via file
            'Dim origine As Integer = getOrigine(IO.Path.GetFileName(fileRichiesta))
            'If origine > 0 Then
            '    IO.File.WriteAllText(getFilename(False, origine, Me.Port), risposta.RawData)
            'End If

            If StopListener = True Then
                ListenerTcp.Log.Debug(String.Format("{0} - Eseguo stop di UtListener[FILE]", ExeName))
            End If
        Catch ex As Exception
            ListenerTcp.Log.Info(ex)
        End Try
    End Sub

    Public Shared Function getFilename(destinazione As String, ambito As String) As String
        Return IO.Path.Combine(CartellaScambioCentralino, destinazione & "_richiesta_" & ambito & "_" & Now.Ticks)
    End Function

    Public Shared Sub Invia(url As String)
        Try
            'http://INDIP_BASE:PORTA_BASE/ambito
            'tolgo il protocollo e l'hostname
            url = url.Substring(7)
            url = url.Substring(1 + url.IndexOf(":"))
            Dim i As Integer = url.IndexOf("/")
            Dim destinationPort As String = url.Substring(0, i)
            url = url.Substring(i)
            Dim ambito As String = url.Substring(1)
            If ambito.IndexOf("?") > 0 Then
                ambito = ambito.Substring(0, ambito.IndexOf("?"))
            End If

            Dim filename1 As String = getFilename("_" & destinationPort, ambito)
            Dim filename2 As String = getFilename(destinationPort, ambito)
            IO.File.WriteAllText(filename1, "GET " & url & " HTTP/1.1")
            My.Computer.FileSystem.RenameFile(filename1, IO.Path.GetFileName(filename2))
        Catch ex As Exception
            ListenerTcp.Log.Info(ex)
        End Try
    End Sub

    Public Shared Sub SvuotaCartellaMessagi()
        Utx.NetFunc.SvuotaCartella(CartellaScambioCentralino)
    End Sub
End Class
