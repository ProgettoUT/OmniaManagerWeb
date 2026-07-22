Imports System.IO

Public Class Upload

    Friend WithEvents IconaNotifica As New NotifyIcon
    Private mAgenzia As String

    Sub New(Agenzia As String, DataApertura As Date)
        mAgenzia = Agenzia
        mDataApertura = DataApertura
    End Sub

    Private mDataApertura As Date
    Public Property DataApertura() As Date
        Get
            Return mDataApertura
        End Get
        Set(value As Date)
            mDataApertura = value
        End Set
    End Property

    Public Sub AvviaUpload()
        Try
            'controllo chiamata
            'nella chiamata passo Guid;agenzia
            If Utx.Globale.IdAppOk = False Then
                Application.Exit()
            End If

            With IconaNotifica
                .Text = "Unitools: invio dati a Unigest"
                .Icon = Risorse.Immagini.Icon("upload")
                .Visible = True
            End With

            Globale.Log.Info(String.Format("UnigestUp: {0}", FileVersionInfo.GetVersionInfo(Path.Combine(Utx.Globale.Paths.CartellaApp, "UnigestUp.dll")).ProductVersion))
            Globale.Log.Info(String.Format("Invio file agenzia {0} data di apertura da config {1}", mAgenzia, Me.DataApertura))

            Globale.s.Url = "http://unigest.uniarea.it/UniDataExchange/UniDataExchange.dll/soap/IcoUniDataExchange"

#If Not Debug Then
            'assegno il timeout, il proxy e le credenziali
            With Globale.s
                .Timeout = 60000
                .Proxy = Utx.Globale.UniProxy.Proxy
            End With
#End If

            'inizializzo la sessione
            Dim Sessione As String = Globale.s.OpenSession("UniDataExchange", "Un1DataX", mAgenzia)

            'se la sessione è stata aperta correttamente
            If Globale.ErroreOpenSession(Sessione) = False Then

                'invio i file in upload
                InviaFileIncassi(Sessione)
                InviaPTFCanc(Sessione)
                InviaPTFcancV2(Sessione)
                InviaFileMFee(Sessione)
                InviaFileUBox(Sessione)
                InviaFileAnag(Sessione)

                'chiudo la sessione
                Globale.s.CloseSession(Sessione)
            End If

        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try

        Globale.Log.Info("Attività invio file per Unigest conclusa")
        Globale.Log.Info()

        IconaNotifica.Dispose()
    End Sub

    Private Sub InviaFileIncassi(Sessione As String)

        Dim FileInviati As Integer = 0

        Try
            Dim DataInizio As Date = Globale.s.GetMaxDate(Sessione, "INCASSI")
            DataInizio = Utx.FunzioniData.MaxDate(#12/31/2012#, DataInizio)
            DataInizio = Utx.FunzioniData.MaxDate(DataInizio, mDataApertura)

            Globale.Log.Info(String.Format("Ultimo file ESITATI già inviato: {0}", DataInizio.ToShortDateString))

            'cartella in cui si trovano i file esitati da inviare
            Dim ArchivioIncassi As String = String.Format("{0}\{1}\Incassi",
                                                          Utx.Globale.Paths.CartellaArchivioDati,
                                                          mAgenzia)

            'se la cartella non esiste esce
            If Not Directory.Exists(ArchivioIncassi) Then
                Globale.Log.Info("Archivio dati incassi inesistente.")
                Exit Try
            End If

            'template nome file incassi e cartella contenente il file
            Dim NomeFileBase As String = "{0}_INCASSI_{1}.zip"
            Dim PathFileBase As String = Utx.Globale.Paths.CartellaArchivioDati + "\{0}\Incassi\{1}\{2}"
            Dim PathCartella, NomeFile, PathFile As String

            Dim DataFile As Date = DataInizio.AddDays(1)

            Do While DataFile < Today
                'creo il path della cartella che contiene il file
                PathCartella = String.Format(PathFileBase, mAgenzia, DataFile.Year, Format(DataFile, "MM"))
                'creo il nome del file
                NomeFile = String.Format(NomeFileBase, mAgenzia, Format(DataFile, "yyyyMMdd"))
                'creo il path completo
                PathFile = Path.Combine(PathCartella, NomeFile)

                'i file devono essere in sequenza e senza "buchi"
                If Not File.Exists(PathFile) Then Exit Do

                'invio il file in upload
                'se si verifica un errore nell'invio esco dal ciclo e interrompo tutto
                If Globale.UploadFile(Sessione,
                                      PathFile,
                                      "INCASSI",
                                      DataFile,
                                      DataFile) = False Then
                    Exit Do
                End If

                FileInviati += 1

                Globale.Log.Info("File inviato: " + New FileInfo(NomeFile).Name)

                'avanzo di un giorno
                DataFile = DataFile.AddDays(1)
            Loop

        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try

        Globale.Log.Info(String.Format("Invio ESITATI concluso: inviati {0} file", FileInviati))
        Globale.Log.Info()
    End Sub

    Private Sub InviaPTFCanc(Sessione As String)

        Dim FileInviati As Integer = 0

        Try
            Dim DataInizio As Date = Globale.s.GetMaxDate(Sessione, "PTFCANC")
            'in data 10/2013 c'è stato un nuovo setup e il file 10/2013 contiene lo storico
            DataInizio = Utx.FunzioniData.MaxDate(#9/1/2013#, DataInizio)
            DataInizio = Utx.FunzioniData.MaxDate(DataInizio, mDataApertura)

            Globale.Log.Info(String.Format("Ultimo file PTFCANC già inviato: {0}", DataInizio.ToShortDateString))

            'cartella in cui si trovano i file esitati da inviare
            Dim ArchivioPTFCanc As String = String.Format("{0}\{1}\MovimentiPTF",
                                                          Utx.Globale.Paths.CartellaArchivioDati,
                                                          mAgenzia)

            'se la cartella non esiste esce
            If Not Directory.Exists(ArchivioPTFCanc) Then
                Globale.Log.Info("Archivio dati PTFCANC inesistente.")
                Exit Try
            End If

            'template nome file PTFCANC
            Dim NomeFileBase As String = "{0}_PTFCAN_{1}.zip"

            Dim DataFile As Date = DataInizio.AddMonths(1)

            Do While DataFile < Now.Date

                'aggiungo l'anno al path della cartella
                Dim PathCartella As String = Path.Combine(ArchivioPTFCanc, DataFile.Year)
                'creo il nome del file
                Dim NomeFile As String = String.Format(NomeFileBase, mAgenzia, Format(DataFile, "MMyyyy"))
                'path completo del file da inviare
                Dim PathFile As String = Path.Combine(PathCartella, NomeFile)

                ' file devono essere in sequenza e senza "buchi"
                If Not File.Exists(PathFile) Then Exit Do

                'invio il file in upload
                'se si verifica un errore nell'invio esco dal ciclo e interrompo tutto
                If Globale.UploadFile(Sessione,
                                      PathFile,
                                      "PTFCANC",
                                      Utx.FunzioniData.InizioMese(DataFile),
                                      Utx.FunzioniData.FineMese(DataFile)) = False Then
                    Exit Do
                End If

                FileInviati += 1

                Globale.Log.Info("File inviato: " + New FileInfo(NomeFile).Name)

                DataFile = DataFile.AddMonths(1)
            Loop

        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try

        Globale.Log.Info(String.Format("Invio PTFCANC concluso: inviati {0} file", FileInviati))
        Globale.Log.Info()
    End Sub

    Private Sub InviaPTFcancV2(Sessione As String)

        Dim FileInviati As Integer = 0

        Try
            Dim DataInizio As Date = Globale.s.GetMaxDate(Sessione, "PTFCANCv2")
            'in data 10/2013 c'è stato un nuovo setup e il file 10/2013 contiene lo storico
            DataInizio = Utx.FunzioniData.MaxDate(#8/31/2016#, DataInizio)
            DataInizio = Utx.FunzioniData.MaxDate(DataInizio, mDataApertura)

            Globale.Log.Info(String.Format("Ultimo file PTFCANCv2 già inviato: {0}", DataInizio.ToShortDateString))

            'cartella in cui si trovano i file esitati da inviare
            Dim ArchivioPTFCanc As String = String.Format("{0}\{1}\MovimentiPTF",
                                                          Utx.Globale.Paths.CartellaArchivioDati,
                                                          mAgenzia)

            'se la cartella non esiste esce
            If Not Directory.Exists(ArchivioPTFCanc) Then
                Globale.Log.Info("Archivio dati PTFCANC inesistente.")
                Exit Try
            End If

            Dim DataFile As Date = Utx.FunzioniData.InizioProssimaDecade(DataInizio)
            Globale.Log.Info(String.Format("Prossimo file: {0}", DataFile))

            Do While DataFile < Today

                'aggiungo l'anno al path della cartella
                Dim PathCartella As String = Path.Combine(ArchivioPTFCanc, DataFile.Year)
                'creo il nome del file
                Dim NomeFile As String = String.Format("{0}_PTFCAN_{1}_D{2}.zip",
                                                       mAgenzia,
                                                       Format(DataFile, "MMyyyy"),
                                                       Utx.FunzioniData.DataToDecade(DataFile))
                'path completo del file da inviare
                Dim PathFile As String = Path.Combine(PathCartella, NomeFile)
                Globale.Log.Info(String.Format("Path file: {0}", PathFile))

                ' file devono essere in sequenza e senza "buchi"
                If Not File.Exists(PathFile) Then Exit Do

                'invio il file in upload
                'se si verifica un errore nell'invio esco dal ciclo e interrompo tutto
                If Globale.UploadFile(Sessione,
                                      PathFile,
                                      "PTFCANCv2",
                                      Utx.FunzioniData.InizioDecade(DataFile),
                                      Utx.FunzioniData.FineDecade(DataFile)) = False Then
                    Exit Do
                End If

                FileInviati += 1

                Globale.Log.Info("File inviato: " + New FileInfo(NomeFile).Name)

                'avanzo di una decade
                DataFile = Utx.FunzioniData.InizioProssimaDecade(DataFile)
            Loop

        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try

        Globale.Log.Info(String.Format("Invio PTFCANCv2 concluso: inviati {0} file", FileInviati))
        Globale.Log.Info()
    End Sub

    Private Sub InviaFileMFee(Sessione As String)

        Dim FileInviati As Integer = 0

        Try
            Dim DataInizio As Date = Globale.s.GetMaxDate(Sessione, "MFEE")
            DataInizio = Utx.FunzioniData.MaxDate(#8/1/2014#, DataInizio)
            DataInizio = Utx.FunzioniData.MaxDate(DataInizio, mDataApertura)

            Globale.Log.Info(String.Format("Ultimo file MFee già inviato: {0:d}", DataInizio))

            'cartella in cui si trovano i file esitati da inviare
            Dim ArchivioMFee As String = String.Format("{0}\{1}\MFee",
                                                       Utx.Globale.Paths.CartellaArchivioDati,
                                                       mAgenzia)

            'se la cartella non esiste esce
            If Not Directory.Exists(ArchivioMFee) Then
                Globale.Log.Info("Archivio dati MFee inesistente.")
                Exit Try
            End If

            Dim DataFile As Date = Utx.FunzioniData.InizioMese(DataInizio.AddMonths(1))

            Do While DataFile <= Today
                'aggiungo l'anno al path della cartella
                Dim PathCartella As String = Path.Combine(ArchivioMFee, DataFile.Year)
                'creo il nome del file
                Dim NomeFile As String

                If DataFile <= #12/31/2015# Then
                    NomeFile = String.Format("{0}_Management_Fee_{1}.zip", mAgenzia, Format(DataFile, "yyyyMM"))
                Else
                    NomeFile = String.Format("{0}_Management_Fee_{1}.zip", mAgenzia, Format(DataFile, "MMyyyy"))
                End If
                'path completo del file da inviare
                Dim PathFile As String = Path.Combine(PathCartella, NomeFile)

                'se il file esiste (non devono esserci necessariamente tutti i mesi)
                If File.Exists(PathFile) = True Then
                    'invio il file in upload
                    If Globale.UploadFile(Sessione, PathFile, "MFEE", Utx.FunzioniData.InizioMese(DataFile), Utx.FunzioniData.FineMese(DataFile)) = True Then
                        FileInviati += 1
                        Globale.Log.Info("File inviato: " + Path.GetFileName(NomeFile))
                    Else
                        Globale.Log.Info("Errore nell'invio del file " + Path.GetFileName(NomeFile))
                    End If
                End If
                'avanzo di un mese
                DataFile = DataFile.AddMonths(1)
            Loop

        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try

        Globale.Log.Info(String.Format("Invio MFee concluso: inviati {0} file", FileInviati))
        Globale.Log.Info()
    End Sub

    Private Sub InviaFileUBox(Sessione As String)

        Dim FileInviati As Integer = 0

        Try
            Dim DataInizio As Date = Globale.s.GetMaxDate(Sessione, "UBOX")
            DataInizio = Utx.FunzioniData.MaxDate(#7/1/2015#, DataInizio)
            DataInizio = Utx.FunzioniData.MaxDate(DataInizio, mDataApertura)

            Globale.Log.Info(String.Format("Ultimo file UBox già inviato: {0:d}", DataInizio))

            'cartella in cui si trovano i file esitati da inviare
            Dim ArchivioMFee As String = String.Format("{0}\{1}\UBox",
                                                       Utx.Globale.Paths.CartellaArchivioDati,
                                                       mAgenzia)

            'se la cartella non esiste esce
            If Not Directory.Exists(ArchivioMFee) Then
                Globale.Log.Info("Archivio dati UBox inesistente.")
                Exit Try
            End If

            Dim DataFile As Date = Utx.FunzioniData.InizioMese(DataInizio.AddMonths(1))

            Do While DataFile <= Today
                'aggiungo l'anno al path della cartella
                Dim PathCartella As String = Path.Combine(ArchivioMFee, DataFile.Year)
                'creo il nome del file
                Dim NomeFile As String

                If DataFile <= #9/30/2017# Then
                    NomeFile = String.Format("{0}_COMPENSI_UNIBOX_MESE{1}.zip", mAgenzia, Format(DataFile, "MMyyyy"))
                Else
                    NomeFile = String.Format("{0}_COMPENSI_UNIBOX_{1}.zip", mAgenzia, Format(DataFile, "yyyyMM"))
                End If

                'path completo del file da inviare
                Dim PathFile As String = Path.Combine(PathCartella, NomeFile)

                'se il file esiste (non devono esserci necessariamente tutti i mesi)
                If File.Exists(PathFile) = True Then
                    'invio il file in upload
                    If Globale.UploadFile(Sessione, PathFile, "UBOX", Utx.FunzioniData.InizioMese(DataFile), Utx.FunzioniData.FineMese(DataFile)) = True Then
                        FileInviati += 1
                        Globale.Log.Info("File inviato: " + Path.GetFileName(NomeFile))
                    Else
                        Globale.Log.Info("Errore nell'invio del file " + Path.GetFileName(NomeFile))
                    End If
                End If
                'avanzo di un mese
                DataFile = DataFile.AddMonths(1)
            Loop

        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try

        Globale.Log.Info(String.Format("Invio UBox concluso: inviati {0} file", FileInviati))
        Globale.Log.Info()
    End Sub

    Private Sub InviaFileAnag(Sessione As String)

        Dim FileInviati As Integer = 0

        Try
            Dim DataInizio As Date = Globale.s.GetMaxDate(Sessione, "SIMA")
            DataInizio = Utx.FunzioniData.MaxDate(#8/1/2014#, DataInizio)
            DataInizio = Utx.FunzioniData.MaxDate(DataInizio, mDataApertura)

            Globale.Log.Info(String.Format("Ultimo file SIMA già inviato: {0}", DataInizio.ToShortDateString))

            'cartella in cui si trovano i file esitati da inviare
            Dim ArchivioPTFCanc As String = String.Format("{0}\{1}\Anag",
                                                          Utx.Globale.Paths.CartellaArchivioDati,
                                                          mAgenzia)

            'se la cartella non esiste esce
            If Not Directory.Exists(ArchivioPTFCanc) Then
                Globale.Log.Info("Archivio dati SIMA inesistente.")
                Exit Try
            End If

            'template nome file PTFCANC
            Dim NomeFileBase As String = "{0}_sima_{1}_{2}.zip"
            '02379_sima_novembre_2013.zip

            Dim DataFile As Date = DataInizio.AddMonths(1)

            Do While DataFile < Now.Date

                'aggiungo l'anno al path della cartella
                Dim PathCartella As String = Path.Combine(ArchivioPTFCanc, DataFile.Year)
                'creo il nome del file
                Dim NomeFile As String = String.Format(NomeFileBase,
                                                       mAgenzia,
                                                       MonthName(DataFile.Month),
                                                       DataFile.Year)
                'path completo del file da inviare
                Dim PathFile As String = Path.Combine(PathCartella, NomeFile)

                ' file devono essere in sequenza e senza "buchi"
                If Not File.Exists(PathFile) Then Exit Do

                'invio il file in upload
                'se si verifica un errore nell'invio esco dal ciclo e interrompo tutto
                If Globale.UploadFile(Sessione,
                                      PathFile,
                                      "SIMA",
                                      Utx.FunzioniData.InizioMese(DataFile),
                                      Utx.FunzioniData.FineMese(DataFile)) = False Then
                    Exit Do
                End If

                FileInviati += 1

                Globale.Log.Info("File inviato: " + New FileInfo(NomeFile).Name)

                DataFile = DataFile.AddMonths(1)
            Loop

        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try

        Globale.Log.Info(String.Format("Invio SIMA concluso: inviati {0} file", FileInviati))
        Globale.Log.Info()
    End Sub
End Class
