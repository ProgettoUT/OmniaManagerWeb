Imports System.IO
Imports System.Net

Public Class SIA

    Private Shared FileBlocco As String = Path.Combine(Utx.Globale.Paths.CartellaSetting, "BloccoInvioMA.flag")

    Public Shared ReadOnly Property EsisteBloccoInvio() As Boolean
        Get
            Return File.Exists(FileBlocco)
        End Get
    End Property

    Public Shared Function InizioInvioMA(Agenzia As String) As Date
        Try
            Using s As New SettingAgenzia.ConfiguraSede
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Dim Risposta As Object = s.InviaMA2OmniaManager(Agenzia)
                If IsDate(Risposta) Then
                    Return Risposta
                Else
                    Utx.Globale.Log.Info(Risposta)
                    Return CDate("31/12/2100")
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return CDate("31/12/2100")
        End Try
    End Function

    Public Shared Function InizioInvioEssigReti(Agenzia As String) As Date
        Try
            Using s As New SettingAgenzia.ConfiguraSede
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Dim Risposta As Object = s.InviaEssigReti2OmniaManager(Agenzia)
                If IsDate(Risposta) Then
                    Return Risposta
                Else
                    Utx.Globale.Log.Info(Risposta)
                    Return CDate("31/12/2100")
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return CDate("31/12/2100")
        End Try
    End Function

    Public Shared Function RegistraSwitchMA(Agenzia As String, Inizio As Date) As Boolean
        Try
            If EsisteBloccoInvio = True Then Return True

            Using s As New SettingAgenzia.ConfiguraSede
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Return s.RegistraDataSwitchMA(Agenzia, Inizio)
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Function InizioInvioMA(ListaFileInviati As String()) As Date
        Try
            Dim DataInizio As Date = New DateTime(ListaFileInviati(0).Substring(8, 2), ListaFileInviati(0).Substring(10, 2), ListaFileInviati(0).Substring(12, 2))
            Return DataInizio.AddDays(-7)
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            Return Today.AddMonths(-1)
        End Try
    End Function

    ''' <summary>
    ''' Invio file prima nota a SIA
    ''' </summary>
    ''' <param name="NomeFile">path completo del file da inviare</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InviaFilePN(NomeFile As String) As String
        Try
            If EsisteBloccoInvio = True Then Return "OK"

            Using Sia As New Utx.UploadSia.FileUploader
                'configuro il servizio
                With Sia
                    .Url = "https://omaportal.siaspa.com/WS_UGF/FileUploader.asmx"
                    .Timeout = 15000 '15 secondi per il timeout
                    .Proxy = Utx.Globale.UniProxy.Proxy
                End With

                Dim sFile As FileInfo = New FileInfo(NomeFile)

                Dim objFileStream As FileStream = New FileStream(sFile.FullName, FileMode.Open, FileAccess.Read)
                Dim StreamLen As Integer = Convert.ToInt32(objFileStream.Length)
                Dim f As Object = New Byte(StreamLen) {}

                objFileStream.Read(f, 0, StreamLen)
                objFileStream.Close()

                'invio il file e ricevo la risposta
                Globale.Log.Trace("Invio file '{0}' di prima nota a SIA", {sFile.Name})
#If DEBUG Then
                Dim Risposta As String = "OK"
#Else
                Dim Risposta As String = Sia.UploadFile(f, sFile.Name)
#End If
                Globale.Log.Trace("Risposta del servizio: {0}", {Risposta})

                If Risposta.ToUpper = "OK" Then
                    Return String.Format("+OK: invio file '{0}' completato correttamente", sFile.Name)
                Else
                    Return String.Format("-ERR: invio file '{0}' non riuscito: {1}", sFile.Name, Risposta)
                End If
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex)
            Return String.Format("-ERR: invio file non riuscito: {0}", ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Invio file MA a SIA
    ''' </summary>
    ''' <param name="NomeFile">path completo del file da inviare</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InviaFileMA(Agenzia As String,
                                       NomeFile As String,
                                       Optional InviaComunque As Boolean = False) As String
        Try
            Using Sia As New Utx.UploadSiaMA.WsUploader
                'configuro il servizio
                With Sia
                    .Url = "https://omaportal.siaspa.com/SIA.FTA.Portal/WsUploader.asmx"
                    .Timeout = 300000 '5 minuti
                    .Proxy = Utx.Globale.UniProxy.Proxy
                End With

                Dim sFile As New FileInfo(NomeFile)
                Dim NomeInvio As String = sFile.Name

                If (InviaComunque = True) OrElse (Sia.ExistsFileNameUnipol(Agenzia, NomeInvio) = False) Then
                    'invio il file e ricevo la risposta
                    Globale.Log.Trace("Procedo con l'invio di {0}", {NomeInvio})
                    Dim Risposta As String = Sia.UploadFileUNIPOL(File.ReadAllBytes(NomeFile), NomeInvio)
                    Globale.Log.Trace(String.Format("Risposta del servizio: {0}", Risposta))
                    Globale.Log.Trace(">>> Invio file '{0}' ({1}): {2}", {sFile.Name, NomeInvio, Risposta})

                    Return Risposta
                Else
                    Globale.Log.Trace("OK - File già trasmesso")
                    Return "OK - File già trasmesso"
                End If
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex)
            Return ex.Message
        End Try
    End Function

    Public Shared Function InviaFileMFee(NomeFile As String) As Boolean
        Try
#If Not debug Then
            If EsisteBloccoInvio = True Then Return True
#End If
            Using Sia As New Utx.UploadSiaMA.WsUploader
                'configuro il servizio
                With Sia
                    .Url = "https://omaportal.siaspa.com/SIA.FTA.Portal/WsUploader.asmx"
                    .Timeout = 300000 '5 minuti
                    .Proxy = Utx.Globale.UniProxy.Proxy
                End With

                Dim sFile As New FileInfo(NomeFile)

                'invio il file e ricevo la risposta
                Globale.Log.Trace("Procedo con l'invio di {0}", {sFile.Name})
#If DEBUG Then
                Dim Risposta As String = "OK - DEBUG"
#Else
                Dim Risposta As String = Sia.UploadFileUNIPOL(File.ReadAllBytes(NomeFile), sFile.Name)
#End If
                Globale.Log.Trace(String.Format("Risposta del servizio: {0}", Risposta))

                If Risposta.StartsWith("OK") Then
                    Globale.Log.Info(">>> Invio file '{0}': {1}", {sFile.Name, Risposta})
                    Return True
                Else
                    Globale.Log.Info(">>> Invio file '{0}' non riuscito: {1}", {sFile.Name, Risposta})
                    Return False
                End If
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Invio file zip essig reti a SIA
    ''' </summary>
    ''' <param name="NomeFile">path completo del file da inviare</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InviaPacchettoEssigReti(NomeFile As String) As Boolean
        Try
#If Not debug Then
            If EsisteBloccoInvio = True Then Return True
#End If
            Using Sia As New Utx.UploadSiaMA.WsUploader
                'configuro il servizio
                With Sia
                    .Url = "https://omaportal.siaspa.com/SIA.FTA.Portal/WsUploader.asmx"
                    .Timeout = 300000 '5 minuti
                    .Proxy = Utx.Globale.UniProxy.Proxy
                End With

                Dim sFile As New FileInfo(NomeFile)

                'invio il file e ricevo la risposta
                Globale.Log.Trace("Procedo con l'invio di {0}", {sFile.Name})
#If DEBUG Then
                Dim Risposta As String = "OK - DEBUG"
#Else
                Dim Risposta As String = Sia.UploadFileUNIPOL(File.ReadAllBytes(NomeFile), sFile.Name)
#End If
                Globale.Log.Trace(String.Format("Risposta del servizio: {0}", Risposta))

                If Risposta.StartsWith("OK") Then
                    Globale.Log.Info(">>> Invio file '{0}' ({1}): Ok", {sFile.Name, NomeFile})
                    Return True
                Else
                    Globale.Log.Info(">>> Invio file '{0}' non riuscito: {2}", {sFile.Name, Risposta})
                    Return False
                End If
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex)
            Return False
        End Try
    End Function

    Public Shared Function ListaFileInviati(Agenzia As String, Inizio As Date, Fine As Date) As String()
        Try
            Using Sia As New Utx.UploadSiaMA.WsUploader
                'configuro il servizio
                With Sia
                    .Url = "https://omaportal.siaspa.com/SIA.FTA.Portal/WsUploader.asmx"
                    .Timeout = 15000 '15 secondi
                    .Proxy = Utx.Globale.UniProxy.Proxy
                End With

                Return Sia.GetListFileTrasmittedUnipol(Agenzia, Inizio, Fine, "", "")
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex)
            Return Nothing
        End Try
    End Function

    Public Enum TipoFiltro
        INIZIA
        FINISCE
        CONTIENE
    End Enum

    Public Shared Function ListaFileInviati(Agenzia As String, Inizio As Date, Fine As Date, Tipo As TipoFiltro, Filtro As String) As String()
        Try
            Using Sia As New Utx.UploadSiaMA.WsUploader
                'configuro il servizio
                With Sia
                    .Url = "https://omaportal.siaspa.com/SIA.FTA.Portal/WsUploader.asmx"
                    .Timeout = 15000 '15 secondi
                    .Proxy = Utx.Globale.UniProxy.Proxy
                End With

                Dim Flag As String = ""
                Select Case Tipo
                    Case TipoFiltro.INIZIA
                        Flag = "S"
                    Case TipoFiltro.FINISCE
                        Flag = "E"
                    Case TipoFiltro.CONTIENE
                        Flag = "C"
                End Select

                Return Sia.GetListFileTrasmittedUnipol(Agenzia, Inizio, Fine, Flag, Filtro)
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex)
            Return Nothing
        End Try
    End Function

    Public Shared Function UltimoFileInviato(Agenzia As String) As String
        Try
            Using Sia As New Utx.UploadSiaMA.WsUploader
                'configuro il servizio
                With Sia
                    .Url = "https://omaportal.siaspa.com/SIA.FTA.Portal/WsUploader.asmx"
                    .Timeout = 15000 '15 secondi
                    .Proxy = Utx.Globale.UniProxy.Proxy
                End With

                Return Sia.GetLastFileUploader(Agenzia)
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex)
            Return False
        End Try
    End Function

    Public Shared Sub Login()
        Try
            'Dim request As WebRequest = HttpWebRequest.Create("https://testoweb.siaspa.com/oweb20-api/Authenticate?loginName=AA12379&loginPassword=guidolampo123")
            'Dim response As WebResponse = request.GetResponse()

            '' Get the stream containing content returned by the server.
            'Dim resStream As Stream = response.GetResponseStream()

            '' Open the stream using a StreamReader for easy access.
            'Dim reader As New StreamReader(resStream)
            '' Read the content.
            'Dim wb As New Windows.Forms.WebBrowser
            'wb.DocumentText = reader.ReadToEnd()
            ''Dim doc As mshtml.HTMLDocument = reader.ReadToEnd()


            'MsgBox(wb.Document.Body.InnerText)
            'Dim responseFromServer As String = reader.ReadToEnd()
            'Globale.Log.Info(responseFromServer)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Function DataContabile(Agenzia As String, DataUltimoInvioSia As Date) As Date
        Try
            Dim FileOrigine As String = Path.Combine(Utx.Globale.Paths.CartellaArchivioDati, Agenzia)
            FileOrigine = Path.Combine(FileOrigine, Utx.Enumerazioni.TipoFileMagia.PrimaNota.ToString)
            FileOrigine = Path.Combine(FileOrigine, Format(DataUltimoInvioSia, "yyyy"))
            FileOrigine = Path.Combine(FileOrigine, String.Format("{0}_PNOTA_{1}.zip", Agenzia, Format(DataUltimoInvioSia, "yyyyMMdd")))

            If File.Exists(FileOrigine) = True Then
                Dim FileDest As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "PNota")

                Utx.LibreriaZip.UnZipFileConNome(FileOrigine, FileDest)

                Using sr As New StreamReader(FileDest)
                    sr.ReadLine()

                    Dim MaxData As Date

                    Do While sr.EndOfStream = False
                        Dim Data As String = sr.ReadLine.Split(";")(18)
                        If Data > MaxData Then
                            MaxData = Data
                        End If
                    Loop
                    Return MaxData
                End Using
            Else
                Return CDate("31/12/2100")
            End If

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            Return CDate("31/12/2100")
        End Try
    End Function

    Public Shared Sub InviaManagementFee()
        Try
            Dim fd As New Utx.FormRichiestaDate
            With fd
                .ColoreBordo = Drawing.Color.DodgerBlue
                .FormText = "Invio MFee"
                .ButtonOkText = "Invia MFee"
                .LabelMessaggioText = "Seleziona le date del periodo desiderato e i codici agenzia per l'invio dei file di Management Fee"
                .ShowDialog()
            End With

            Dim Inizio As Integer = Format(fd.InizioPeriodo, "yyyyMM")
            Dim Fine As Integer = Format(fd.FinePeriodo, "yyyyMM")

            For Each codice As String In fd.ListaCodici
                Dim ListaFileInviati As String() = {} ' Utx.SIA.ListaFileInviati(codice, Today.AddYears(-1), Today, Utx.SIA.TipoFiltro.CONTIENE, "_Fee_")
                Globale.Log.Info("File MFee già inviati: {0}", {ListaFileInviati.Length.ToString})

                Dim AgenziaFiglia As New Utx.AgenziaFigliaOmnia(codice)
                Dim CartellaMFee As String = String.Format("{0}\MFee", AgenziaFiglia.Cartelle.ArchivioDati)

                For anno As Integer = fd.InizioPeriodo.Year To fd.FinePeriodo.Year
                    Dim CartellaAnno As String = String.Format("{0}\{1:0000}", CartellaMFee, anno)

                    For Each f As String In Directory.GetFiles(CartellaAnno, "*.zip", SearchOption.TopDirectoryOnly)

                        Dim NomeNormalizzato As String = Path.GetFileNameWithoutExtension(f)
                        'vecchia nomenclatura da cambiare yyyyMM >> MMyyyy
                        If NomeNormalizzato.Substring(23, 2) < 20 Then
                            NomeNormalizzato = NomeNormalizzato.Substring(0, 21) & NomeNormalizzato.Substring(25, 2) & NomeNormalizzato.Substring(21, 4) & ".zip"
                        End If

                        'se non è stato ancora inviato
                        If Array.IndexOf(ListaFileInviati, Path.GetFileName(f)) < 0 Then

                            'cambio il file perché è un exe autoestraente e lo trasformo in zip vero (per problemi di sicurezza)
                            Dim FileCsv As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente,
                                                         Utx.LibreriaZip.SevenZip.UnZipFile(f, Utx.Globale.Paths.CartellaTempUtente)(0))

                            NomeNormalizzato = Path.ChangeExtension(NomeNormalizzato, "csv") 'da zip a csv

                            If Path.GetFileName(FileCsv) <> NomeNormalizzato Then
                                My.Computer.FileSystem.RenameFile(FileCsv, NomeNormalizzato)
                                FileCsv = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, NomeNormalizzato)
                            End If

                            Dim FileZip As String = Path.ChangeExtension(FileCsv, "zip")
                            Utx.LibreriaZip.SevenZip.ZipFile(FileCsv, FileZip)

                            Globale.Log.Info("Invio file: " & Path.GetFileName(FileZip))
                            If Utx.SIA.InviaFileMFee(FileZip) = True Then
                                Globale.Log.Info("Invio completato correttamente")
                            Else
                                Globale.Log.Info("Invio file non riuscito")
                            End If
                            File.Delete(FileCsv)
                            File.Delete(FileZip)
                        End If
                    Next
                Next
            Next
            MsgBox("Invio management fee completato correttamente", MsgBoxStyle.Information, Utx.Globale.TitoloApp)

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub
End Class
