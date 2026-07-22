Imports System.IO
Imports System.Windows.Forms
Imports WinSCP

Public Class SIA40

    Public Class FTPUpload

        Private WithEvents Notifica As New Utx.FormNotifica
        Private WithEvents Session As New WinSCP.Session
        Private ReadOnly SessionOptions As New WinSCP.SessionOptions
        Private Progressivo As Integer
        Private DocumentiTrasferiti As Integer
        Private FileInUpload As String = ""
        Private FileTotali As Integer
        Private FileTotaliLettera As Integer
        Private LetteraInUpload As String
        Private Shared ReadOnly Log As New Utx.ApplicationLog("FtpTransfer.log", LogCondiviso:=True)
        Private BloccoDoc As Utx.Sessione.Blocco
        Dim transferOptions As New TransferOptions With {.TransferMode = TransferMode.Binary}

        Sub New(Agenzia As String)
            Try
                Me.Agenzia = Agenzia
#If DEBUG Then
                'Me.Agenzia = "99999"
#End If

                Log.Info("Apertura sessione FTP")
                ' Setup session options
                Dim sessionOptions As New WinSCP.SessionOptions
                With sessionOptions
                    .Protocol = WinSCP.Protocol.Sftp
                    .HostName = "preprodsftp.siaspa.com"
                    .PortNumber = 2089
                    .UserName = "AUA_Unitools"
                    .SshHostKeyPolicy = SshHostKeyPolicy.GiveUpSecurityAndAcceptAny
                    .SshPrivateKey = "PuTTY-User-Key-File-3: ssh-rsa
Encryption: none
Comment: rsa-key-20241108
Public-Lines: 6
AAAAB3NzaC1yc2EAAAADAQABAAABAQCBxjufVPWprmJ5IcQr7SQbyVHgpgmyd57n
PE/nqMc1AryjkiE6muRd+d2+gHlfnwjEVHFgk4nqVAuuTn5IDh0f8mQl7NtbEiT2
EBl6qPjKDSFMOyWsQ5OH5ieePXpyycFi1JLns9e4TzAEsJZzvpAg9wesV8BfaWRK
fRfXCclfJBYI/bFoEeGPHKt40TAURyYvEwrEiOsHCTSq8tI4ilY4xBOoXSduCI7/
2M8vahu3CXs02V4lee6W2fIZgAcnRSL4g6aJHQTEGv92WrR4g1B9zpScRx42iwtc
c1CwUhR9JqqMsV/hFgwth+cYQm5iiFRXjlfxGihaahss4rMgFnVt
Private-Lines: 14
AAABACQeR/nQa48OOdn8y9xt497X6THdBFXndRJmdtbC4q6eVGIyCY2GDokZQd4D
Y8R5PrdlyShX58qQGbApqHvlcbWygK0Nfv+ZzS+uy2iYHqYdgWb2D0YiiK0KIXyp
H6tS+7/F6h0SsLdbUsH7Y+RS5UpHdptA0Qm9C2yv5DK1RpZzzfR895U1gKs/fOsW
PwSwAkobAeYMdspr/G3eZUiB7FPzSPjdopSqo9lJNn8QCkAVb7WV3nFf8+qo2K+m
NYeHlQX8MvXY6oDqKoaGQ3ufMpd0WVo5a2UoUHtXpjiole0zj76y86fUyZc5kAVH
Zs1Fqj3FAfscTI4sNAqAXeZ+OwEAAACBANVv84PUeZqpGt9K8fmuyn7z01sMi2iq
B4ujuExYwqWaAhppsm4Dn8aSKUatryU2mnYZN1AKi6UwWeRJiVV/fW72+uIBEvZ/
zTT1VMvWn0W6iMvXFt1Rf48YcFKqricmmB2Ck9hEkBhsi4iDcy0b5LUrZk/znPpN
vWBdJfuudvZ/AAAAgQCbp0ImIq5tEDjs0RVqHd2Q25+hVPtO15P6Z9zWK5SliMGR
U67UjidQ6BzlzuNA1GyNfJC1E8RxrCjgjmg/1aGTeo5BlViltTFV8mpfLKHSTfRB
1DH4mxyyjuas83e1V1JpTXIoBX/eefrrn0KCjsXfzEd5Kt/hGkACzTSDsszWEwAA
AIEArppB0Y1PrLUNtOwsISg+iPkhfwBhc6fW8OXgthKH0MQU+TiGFWPQuwBh9tH9
q9ZrCauE3It8m22GaDTiOH+BRTuF1UoDItPGc9R2hsJnmHrAVfl6enzWcmjCf3rE
Jz/Fl1V1M2WmBi5DAZn9wHptS13Phjw0G5BdAu2/LtkT4Go=
Private-MAC: 0c62d8dfec08c2eb2406e8cf6b0f072678222177887c11ec6d03947c3e8d5221"
                    '.SshHostKeyFingerprint = "ssh-rsa 2048 SHA256:oRjxXtk3jmCTv+YDhq0OQ3Kb6O0GKucuc9df3mHZIJA"
                End With
                'Dim sessionOptions As New WinSCP.SessionOptions
                'With sessionOptions
                '    .Protocol = WinSCP.Protocol.Sftp
                '    .HostName = "services.siaspa.com"
                '    .UserName = "uniarea"
                '    .Password = "QZSWwh8HDA9W"
                '    '.SshHostKeyFingerprint = "ecdsa-sha2-nistp256 256 YnxvWYAmoD3pj2iwojYDMEgHeRivoitURpe81RnrZIc="
                '    .GiveUpSecurityAndAcceptAnySshHostKey = True

                '    ''impostazioni proxy documentazione >> https://winscp.net/eng/docs/rawsettings
                '    'If Utx.Globale.UniProxy.Proxy IsNot Nothing Then
                '    '    .AddRawSettings("FSProtocol", "2")
                '    '    .AddRawSettings("ProxyMethod", "3")
                '    '    .AddRawSettings("ProxyHost", Utx.Globale.UniProxy.UrlProxy)
                '    '    .AddRawSettings("ProxyUsername", Utx.Globale.UtenteCorrente.UniageUser)
                '    '    .AddRawSettings("ProxyPassword", Utx.Globale.UtenteCorrente.UniagePw)
                '    'End If
                'End With

                Session = New WinSCP.Session

                ' Connect
                Session.Open(sessionOptions)


                'TagSessione = String.Format("Esportati_{0:ddMMyyyy}_{0:HHmmss}", Now)
                TagSessione = "Esportati"
                DataInvio = Format(Now, "yyyyMMdd HH:mm")

                Log.Info(TagSessione)

                'se non esiste creo la cartella dell'agenzia
                If Session.FileExists(Me.CartellaAgenzia) = False Then
                    Session.CreateDirectory(Me.CartellaAgenzia)
                End If
                'se non esiste creo la cartella di sessione
                If Session.FileExists(Me.CartellaSessione) = False Then
                    Session.CreateDirectory(Me.CartellaSessione)
                End If

            Catch ex As Exception
                Log.Errore(ex)
            End Try
        End Sub

        Sub New()
        End Sub

        Public ReadOnly Property Sessione() As WinSCP.Session
            Get
                Return Session
            End Get
        End Property

        Private _DataInvio As String
        Public Property DataInvio() As String
            Get
                Return _DataInvio
            End Get
            Set(value As String)
                _DataInvio = value
            End Set
        End Property

        Private _TagSessione As String
        Public Property TagSessione() As String
            Get
                Return _TagSessione
            End Get
            Set(value As String)
                _TagSessione = value
            End Set
        End Property

        Private _Agenzia As String
        Public Property Agenzia() As String
            Get
                Return _Agenzia
            End Get
            Set(value As String)
                _Agenzia = value
            End Set
        End Property

        Public ReadOnly Property CartellaRemota() As String
            Get
                Return "/doc_transfer/download/"
            End Get
        End Property

        Public ReadOnly Property CartellaAgenzia() As String
            Get
                Return CartellaRemota & _Agenzia & "/"
            End Get
        End Property

        Public ReadOnly Property CartellaSessione() As String
            Get
                Return CartellaAgenzia & TagSessione & "/"
            End Get
        End Property

        Private _CodiceFiscale As String
        Public Property CodiceFiscale() As String
            Get
                Return _CodiceFiscale
            End Get
            Set(value As String)
                _CodiceFiscale = value
            End Set
        End Property

        Public ReadOnly Property CartellaLettera() As String
            Get
                Return CartellaSessione & Right(CodiceFiscale, 1) & "/"
            End Get
        End Property

        Public ReadOnly Property CartellaCliente() As String
            Get
                Return CartellaLettera & CodiceFiscale & "/"
            End Get
        End Property

        Public Sub ChiudiSessioneFTP()
            On Error Resume Next
            If Session.Opened Then
                Session.Close()
                Log.Info("Chiusura sessione FTP")
            End If
        End Sub

        Public Function UploadFileCliente(NomeFile As String) As Boolean
            Try
                'se non esiste creo la cartella lettera
                If Session.FileExists(Me.CartellaLettera) = False Then
                    Session.CreateDirectory(Me.CartellaLettera)
                End If
                'se non esiste creo la cartella di cliente
                If Session.FileExists(Me.CartellaCliente) = False Then
                    Session.CreateDirectory(Me.CartellaCliente)
                End If

                Dim transferResult As TransferOperationResult = Session.PutFiles(NomeFile, Me.CartellaCliente, False, transferOptions)
                Return transferResult.IsSuccess

            Catch ex As Exception
                Log.Errore(ex)
                Notifica.Messaggio = "Invio completato con errori"
                Return False
            End Try
        End Function

        Public Function DownloadIndice(NomeIndice As String, NomeIndiceStorico As String) As Integer
            Try
                Dim PathIndice As String = Path.Combine(CartellaSessione, NomeIndice)
                Dim PathIndiceStorico As String = Path.Combine(CartellaSessione, NomeIndiceStorico)

                'cancello eventuali file indice presenti
                File.Delete(Path.Combine(Utx.Globale.Paths.CartellaTempUtente, NomeIndiceStorico))
                File.Delete(Path.Combine(Utx.Globale.Paths.CartellaTempUtente, NomeIndice))

                If Session.FileExists(PathIndiceStorico) Then
                    'scarico lo storico precedente con il cumulo di tutte i trasferimenti precedenti
                    Dim o = Session.GetFileToDirectory(PathIndiceStorico, Utx.Globale.Paths.CartellaTempUtente)
                    Return File.ReadAllLines(o.Destination).Length - 1 'tolgo l'intestazione
                Else
                    Return 0
                End If

            Catch ex As Exception
                Log.Errore(ex)
                Notifica.Messaggio = "Download indice non riuscito"
                Return 0
            End Try
        End Function

        Public Function UploadIndice(Indice As String, IndiceStorico As String) As Boolean
            Try
                Dim transferResult As TransferOperationResult = Session.PutFiles(Indice, Me.CartellaSessione, False, transferOptions)
                Dim Esito As Boolean = transferResult.IsSuccess

                'creo lo storico totale: corrente + storico precedente
                If File.Exists(IndiceStorico) Then
                    Using sw As New StreamWriter(IndiceStorico, append:=True)
                        Using sr As New StreamReader(Indice)
                            sr.ReadLine() 'intestazione
                            Do While sr.EndOfStream = False
                                sw.WriteLine(sr.ReadLine)
                            Loop
                        End Using
                    End Using
                Else
                    'copio il corrente anche come storico
                    File.Copy(Indice, IndiceStorico)
                End If
                'e lo invio
                transferResult = Session.PutFiles(IndiceStorico, Me.CartellaSessione, False, transferOptions)
                Esito = Esito And transferResult.IsSuccess
                Return Esito

            Catch ex As Exception
                Log.Errore(ex)
                Notifica.Messaggio = "Invio completato con errori"
                Return False
            End Try
        End Function

        Public Shared Function SelezionaCartellaDocumenti() As String
            Try
                Do While True
                    Using fb As New FolderBrowserDialog
                        fb.SelectedPath = Utx.Globale.Paths.CartellaDocumenti
                        fb.ShowNewFolderButton = False
                        Dim result As DialogResult
                        result = fb.ShowDialog()

                        If result = DialogResult.Cancel Then
                            Exit Do
                        ElseIf (Directory.GetParent(fb.SelectedPath).FullName.ToLower = Utx.Globale.Paths.CartellaDocumenti.ToLower) AndAlso
                           (Path.GetFileName(fb.SelectedPath.ToLower) Like "esportati_*_*") Then
                            Return fb.SelectedPath
                            Exit Do
                        Else
                            MsgBox("Non si tratta di una cartella di esportazione documenti.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                            Exit Do
                        End If
                    End Using
                Loop
                Return Nothing
            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
                Return Nothing
            End Try
        End Function

        Public Sub SincronizzaCartelle(Agenzia As String, CartellaLocale As String)
#If DEBUG Then
            Agenzia = "99999"
#End If
            Dim Inizio As Date = Now
            Dim Fine As Date
            Dim MessaggioMail As String
            Dim synchronizationResult As WinSCP.SynchronizationResult = Nothing
            Try
                BloccoDoc = Utx.Globale.SessioneCorrente.AggiungiBlocco(Utx.Sessione.TipoBlocco.INVIO_DOC, "Invio documenti con FTP")

                With Notifica
                    .Stile = Utx.FormNotifica.Style.ANTRACITE
                    .LabelMessaggio.AutoEllipsis = True
                    .AnnullaOperazione = True
                    .Show()
                    .Messaggio = "Invio documenti..."
                    System.Windows.Forms.Application.DoEvents()
                End With

                Dim CartellaRemota As String = "/doc_transfer/download/"

                ' Setup session options
                Dim sessionOptions As New WinSCP.SessionOptions
                With sessionOptions
                    .Protocol = WinSCP.Protocol.Sftp
                    .HostName = "services.siaspa.com"
                    .UserName = "uniarea"
                    .Password = "QZSWwh8HDA9W"
                    '.SshHostKeyFingerprint = "ecdsa-sha2-nistp256 256 YnxvWYAmoD3pj2iwojYDMEgHeRivoitURpe81RnrZIc="
                    .GiveUpSecurityAndAcceptAnySshHostKey = True

                    ''impostazioni proxy documentazione >> https://winscp.net/eng/docs/rawsettings
                    'If Utx.Globale.UniProxy.Proxy IsNot Nothing Then
                    '    .AddRawSettings("FSProtocol", "2")
                    '    .AddRawSettings("ProxyMethod", "3")
                    '    .AddRawSettings("ProxyHost", Utx.Globale.UniProxy.UrlProxy)
                    '    .AddRawSettings("ProxyUsername", Utx.Globale.UtenteCorrente.UniageUser)
                    '    .AddRawSettings("ProxyPassword", Utx.Globale.UtenteCorrente.UniagePw)
                    'End If
                End With

                FileTotali = Directory.GetFiles(CartellaLocale, "*.*", SearchOption.AllDirectories).Count 'in locale
                DocumentiTrasferiti = 0

                Log.Info("Invio documenti via FTP: inizio")

                session = New WinSCP.Session

                ' Connect
                session.Open(sessionOptions)

                'creo cartella agenzia in remoto
                Dim CartellaAgenzia As String = CartellaRemota & Agenzia
                If session.FileExists(CartellaAgenzia) = False Then
                    session.CreateDirectory(CartellaAgenzia)
                End If

                'creo cartella documenti
                Dim CartellaDocumenti As String = String.Format("{0}/{1}", CartellaAgenzia, Path.GetFileName(CartellaLocale))
                If session.FileExists(CartellaDocumenti) = False Then
                    session.CreateDirectory(CartellaDocumenti)
                End If
                'copio i file nella cartella root (indice lettoweb)
                For Each f As String In Directory.GetFiles(CartellaLocale, "*.*", SearchOption.TopDirectoryOnly)
                    Dim IndiceRemoto As String = String.Format("{0}/{1}", CartellaDocumenti, Path.GetFileName(f))
                    If session.FileExists(IndiceRemoto) = False Then
                        Dim tor As TransferOperationResult = session.PutFiles(f, IndiceRemoto)
                    End If
                Next
                'sincronizzo le lettere
                For Each Lettera As String In Directory.GetDirectories(CartellaLocale)
                    LetteraInUpload = Path.GetFileName(Lettera)
                    FileTotaliLettera = Directory.GetFiles(Lettera, "*.*", SearchOption.AllDirectories).Count
                    Progressivo = 0

                    Notifica.Messaggio = String.Format("Invio di {1} documenti{0}{0}Lettera {2}: {3} su {4} - ...",
                                                       Environment.NewLine, FileTotali, LetteraInUpload, Progressivo, FileTotaliLettera)

                    'creo cartella documenti
                    Dim CartellaLettera As String = String.Format("{0}/{1}", CartellaDocumenti, Path.GetFileName(Lettera))
                    If Session.FileExists(CartellaLettera) = False Then
                        Session.CreateDirectory(CartellaLettera)
                    End If
                    ' Synchronize files
                    synchronizationResult = Session.SynchronizeDirectories(WinSCP.SynchronizationMode.Remote, Lettera, CartellaLettera, False)

                    'esito
                    synchronizationResult.Check()
                    Utx.Globale.Log.Info("Documenti inviati: {0}", {synchronizationResult.Uploads.Count})
                Next

                Notifica.Messaggio = "Invio completato correttamente"
                MessaggioMail = "Invio completato correttamente"

            Catch wex As WinSCP.SessionLocalException
                Notifica.Messaggio = String.Format("Invio documenti interrotto ({0})", wex.Message)
            Catch ex As Exception
                Log.Errore(ex)
                Notifica.Messaggio = "Invio completato con errori"
            Finally
                MessaggioMail = Notifica.Messaggio
                Fine = Now
                InviaEmailNotifica(Agenzia, Inizio, Fine, MessaggioMail, DocumentiTrasferiti)
                Notifica.Chiudi()
                Log.Info("Invio documenti via FTP: fine")
                Utx.Globale.SessioneCorrente.RimuoviBlocco(BloccoDoc)
            End Try
        End Sub

        Private Sub Session_FileTransferred(sender As Object, e As WinSCP.TransferEventArgs) Handles Session.FileTransferred
            If e.FileName <> FileInUpload Then
                FileInUpload = e.FileName
                Progressivo += 1
                DocumentiTrasferiti += 1
                Notifica.Messaggio = String.Format("Invio di {1} documenti{0}{0}Lettera {2}: {3} su {4} - {5:##0%}",
                                                   Environment.NewLine, FileTotali, LetteraInUpload, Progressivo, FileTotaliLettera, Progressivo / FileTotaliLettera)
                Log.Info("Trasferito: {0}", {FileInUpload})
            End If
        End Sub

        Private Sub Notifica_Annulla() Handles Notifica.Annulla
            Session.Abort()
        End Sub

        Public Sub InviaEmailNotifica(Agenzia As String, Inizio As Date, Fine As Date, Messaggio As String, NumeroDocumenti As Integer)
            Dim Blocco As Utx.Sessione.Blocco = Utx.Globale.SessioneCorrente.AggiungiBlocco(Utx.Sessione.TipoBlocco.TIMER_UNITOOLS, "Invio mail")
            Try
                Dim p As New UniCom.Postino
                With p
                    .EmailAutomatica = True
                    .Mittente = "info@omniamanager.it"
                    .InviaA.Add("guido.lampo@auaonline.it")
#If Not DEBUG Then
                    .InviaA.Add("SIA_omniamanager@siaspa.com")
                    '.InviaCc.Add("raffaele.bonghi@auaonline.it")
#End If
                    .Oggetto = String.Format("Trasferimento documenti via FTP: agenzia {0}", Agenzia)
                    .Testo = String.Format("Trasferimento documenti via FTP{0}{0}", Environment.NewLine)
                    .Testo &= String.Format("Agenzia: {1}{0}", Environment.NewLine, Agenzia)
                    .Testo &= String.Format("Inizio: {1}{0}", Environment.NewLine, Inizio.ToString)
                    .Testo &= String.Format("Fine: {1}{0}", Environment.NewLine, Fine.ToString)
                    .Testo &= String.Format("Documenti trasferiti (indice compreso): {1}{0}", Environment.NewLine, NumeroDocumenti)
                    .Testo &= String.Format("Note: {1}{0}{0}", Environment.NewLine, Messaggio)

                    'scrivo nel log
                    Log.Info("Notifica:")
                    Log.Info(.Oggetto)
                    Log.Info(.Testo)

                    .Testo &= "Non rispondere a questa e-mail. E-mail generata automaticamente."
                    .InviaMail()
                End With
            Catch ex As Exception
                Log.Info(ex)
            End Try
            Utx.Globale.SessioneCorrente.RimuoviBlocco(Blocco)
        End Sub

        Private Sub Session_Failed(sender As Object, e As FailedEventArgs) Handles Session.Failed
            Log.Info("failed:" & e.Error.Message)
        End Sub

        Private Sub Session_OutputDataReceived(sender As Object, e As OutputDataReceivedEventArgs) Handles Session.OutputDataReceived
            Log.Trace(e.Data)
        End Sub
    End Class
End Class
