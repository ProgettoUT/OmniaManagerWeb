Imports System.IO
Imports System.Data.OleDb
Imports System.Drawing

Module Main

    Private Notifica As New Utx.FormNotifica

#If DEBUG Then
    Public x As New CDebug
#End If

    Sub Main()
        'per inizializzare i paths
        If Utx.Globale.IdAppOk = False Then
            Utx.Globale.IdApp(System.Text.Encoding.UTF8.GetString(New Byte() {57, 60, 88, 93, 65, 58, 71}))
            Utx.Globale.Init()

            Dim Bag As Utx.Bag = Utx.NetFunc.CryptoDeserialize(Of Utx.Bag)(IO.Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Utx.Bag"), "guido&st")
            Utx.Globale.SessioneCorrente = New Utx.Sessione

            With Bag
                Utx.Globale.Paths = .Paths
                Utx.Globale.ProfiloEnteGestore = .Ente
                Utx.Globale.UtenteCorrente = .Utente
                Utx.Globale.AgenziaRichiesta = .AgenziaRichiesta
            End With
            Utx.Globale.SettingUtente = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.UTENTE)
        End If
        'init log
        Globale.Log = New Utx.ApplicationLog("BackupArchivi.log")

        Utx.Globale.Paths.NomeDbLink = "BackupArchivi"
        'Utx.Globale.Paths.CreaDbLinkSupporto()

        CancellaFileCorrotto()

        Globale.ImpostaParametri()

        If SessioneRDP() Then
            'in caso di sessione RDP consente sessioni multiple solo per modalità "R"
            If Globale.Modo = "B" OrElse Globale.Modo = "T" Then
                If Utx.NetFunc.AltraIstanza("BackupArchivi", ProcessoAvviato:=True) = True Then
                    Globale.Log.Info("Esco. Altra istanza in esecuzione")
                    Exit Sub
                End If
            End If

            'se esiste il flag wip esce
            If EsisteFlagWip(5) Then Exit Sub

            'altrimenti crea il flag
            If SessioneRDP() Then CreaFlag()
        Else
            If Utx.NetFunc.AltraIstanza("BackupArchivi", ProcessoAvviato:=True) = True Then
                Globale.Log.Info("Esco. Altra istanza in esecuzione")
                Exit Sub
            End If
        End If

        If Globale.ImpostaDatiGlobali() = False Then Exit Sub

        Try
            Globale.Log.Info("Backup archivi: " + Application.ProductVersion)
            Globale.Log.Info("Utente: " + Environment.UserName)
            Globale.Log.Info(Utx.FunzioniRete.ReteAttiva)

            Select Case Globale.Modo
                Case "B" 'backup
                    Globale.Log.Info("Avvio backup Pc " + Environment.MachineName)
                    Threading.Thread.CurrentThread.Priority = Threading.ThreadPriority.BelowNormal
                    Dim Bak As New BackupEx
                    Bak.Backup()
                Case "R" 'form ripristino
                    Globale.Log.Info("Avvio ripristino manuale Pc " + Environment.MachineName)
                    Ripristina()
                Case "T" 'recupero tabelle
                    Globale.Log.Info("Avvio recupero automatico Pc " + Environment.MachineName)
                    AvviaRecuperoAutomatico(Globale.Agenzia, False)
            End Select

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

        If SessioneRDP() Then CancellaFlag()
    End Sub

    Private Sub Backup()
        Try
            Threading.Thread.CurrentThread.Priority = Threading.ThreadPriority.BelowNormal

            With Notifica
                .Text = ""
                .ColoreSfondo = Color.LightSlateGray
                .ColoreTesto = Color.White
                .Opacity = 0.8
            End With

            If Globale.VisualizzaNotifica = True Then
                Notifica.Show()
                Notifica.Messaggio = "Backup archivi..."
            End If

#If DEBUG Then
            ''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each Age As String In Utx.EnteGestore.CodiciGestiti
                Dim Dest As String = Path.Combine(IdDirBak(Age), String.Format("Temp_{0:ddMMyyyy}", Today))
                Directory.CreateDirectory(Dest)

                Dim PathDatiAgenzia As String = Path.Combine(Utx.Globale.Paths.CartellaDati, Age)
                For Each db As String In Directory.GetFiles(PathDatiAgenzia, "*.mdb")
                    File.Copy(db, Path.Combine(Dest, Path.GetFileName(db)), True)
                Next

                For Each Dir As String In Directory.GetDirectories(IdDirBak(Age), "Temp_*")

                Next
            Next

            Exit Sub
#End If

            Dim dinfo As DirectoryInfo
            Dim Agenzia As String

            If Globale.Agenzia = "00000" Then
                'cicla per effettuare il backup di tutte le agenzie presenti nella cartella dati
                'compresa la cartella 00000 dei dati comuni
                For Each d As String In Directory.GetDirectories(Utx.Globale.Paths.CartellaDati)

                    dinfo = New DirectoryInfo(d)

                    If dinfo.Name.Length = 5 And IsNumeric(dinfo.Name) Then
                        Agenzia = dinfo.Name

                        'in caso di problemi su un db
                        If CheckDb(Agenzia) = False Then
                            AvviaRecuperoAutomatico(Agenzia, True)
                        End If

                        AvviaBackup(Agenzia)
                        PuliziaBackupRete(Agenzia)
                        PuliziaBackupLocale(Agenzia)
                        Application.DoEvents()
                    End If
                Next
            Else
                'backup solo delle agenzie richieste
                For Each Codice As String In Globale.Agenzia.Split("/")
                    'agenzia richiesta
                    dinfo = New DirectoryInfo(Path.Combine(Utx.Globale.Paths.CartellaDati, Codice.PadLeft(5, "0")))
                    Agenzia = dinfo.Name

                    If CheckDb(Agenzia) = False Then
                        AvviaRecuperoAutomatico(Agenzia, True)
                    End If

                    AvviaBackup(Agenzia)
                    PuliziaBackupRete(Agenzia)
                    PuliziaBackupLocale(Agenzia)
                    Application.DoEvents()
                Next

                'dati comuni
                dinfo = New DirectoryInfo(Path.Combine(Utx.Globale.Paths.CartellaDati, "00000"))
                Agenzia = dinfo.Name

                'per i dati comuni non fare il check. viene fatto quando viene fatto quello di un agenzia
                If CheckDb(Agenzia) = False Then AvviaRecuperoAutomatico(Agenzia, True)

                AvviaBackup(Agenzia)
                PuliziaBackupRete(Agenzia)
            End If

            CancellaPreRollout()
            CancellaVecchiBackup()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Globale.Log.Info()
        End Try
    End Sub

    Private Sub Ripristina()
        Try
            If Directory.Exists(Utx.Globale.Paths.CartellaDati) Then
                Dim f As New frmRipristina
                f.ShowDialog()
            Else
                MsgBox("Impossibile trovare la cartella contenente i dati " + vbNewLine +
                       Utx.Globale.Paths.CartellaDati, MsgBoxStyle.Exclamation, "Ripristino")
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Avvia procedura di recupero automatico
    ''' </summary>
    ''' <param name="Agenzia">agenzia da controllare (00000 per dati comuni)</param>
    ''' <param name="ModoSoloRecupero">in modalità ModoSoloRecupero (richiamata dal backup), il check
    ''' è stato già fatto e la finestra si chiude da sola</param>
    ''' <remarks></remarks>
    Private Sub AvviaRecuperoAutomatico(ByVal Agenzia As String,
                                        ByVal ModoSoloRecupero As Boolean)

        Try
            Dim f As New frmRecuperoAutomatico
            With f
                .Text = "Recupero automatico dati"
                .Icon = My.Resources.ripristina
                .StartPosition = FormStartPosition.CenterScreen
                .FormBorderStyle = FormBorderStyle.Sizable
                .MinimizeBox = False
                .Button1.Text = "attendere..."
                .Button1.Enabled = False

                .ModoSoloRecupero = ModoSoloRecupero
                .AgenziaRichiesta = Agenzia

                .ShowDialog()
            End With

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Private Sub AvviaBackup(ByVal Agenzia As String)
        'esegue il backup dell'agenzia
        Try
            'file destinazione della compressione
            Dim ArchivioZip As String = IdFileBak(Agenzia, Now)

            'in caso di errore esce
            If ArchivioZip.StartsWith("ERR") Then Exit Try

            Notifica.Messaggio = String.Format("Aggiornamento backup {0}", Agenzia)

            'pulizia file temporanei
            PuliziaFileTemp(Agenzia)

            Globale.Log.Info("Avvio backup agenzia " + Agenzia)
            Globale.Log.Rientro += 4
            Globale.Log.Info("Destinazione: " + ArchivioZip)

            'controllo cosa escludere dal backup
            CheckInserimentoBackup()

            'aggiunge i file da aggiornare/aggiungere nel backup
            Dim DbAgenzia As List(Of Database)

            If Agenzia = "00000" Then
                DbAgenzia = Globale.DbComuni
            Else
                DbAgenzia = Globale.DbAgenzia
            End If

            Globale.Log.Info("Database aggiunti al backup:")
            Globale.Log.Rientro += 4

            Dim PathDatiAgenzia As String = Path.Combine(Utx.Globale.Paths.CartellaDati, Agenzia)
            Dim ListaFile As New List(Of String)

            'compilo la lista dei db da backupare
            For Each db As Database In DbAgenzia
                If db.Check = True Then
                    ListaFile.Add(Path.Combine(PathDatiAgenzia, db.Nome + ".mdb"))
                    Globale.Log.Info(db.Nome)
                Else
                    Globale.Log.Info("***Database escluso dal backup: " + db.Nome)
                End If
            Next

            Globale.Log.Rientro -= 4

            Dim Esito As New Utx.LibreriaZip.EsitoZip

            'se sono stati aggiunti file alla lista zippo
            If Utx.LibreriaZip.UpdateZipFile(ListaFile, ArchivioZip, Esito) = True Then
                'lista dei file modificati
                Globale.Log.Info(String.Format("File aggiunti e/o aggiornati nel backup: {0}", Esito.ListaFileZippati.Count))
                Globale.Log.AumentaRientro()
                For Each f As String In Esito.ListaFileZippati
                    Globale.Log.Info(f)
                Next
                Globale.Log.DiminuisciRientro()

                'forzo la data di aggiornamento così da aggiornarla anche se nessun file è cambiato
                AggiornaDataModifica(ArchivioZip, Now)
                'aggiorno il file di log
                AggiornaDbLog(ArchivioZip, Agenzia)

                'se la rete è attiva sincronizza backup e aggiorna log su emme
                If Utx.FunzioniRete.ReteAttiva = True Then
                    If Not File.Exists(IdFileBakLogEmme()) Then
                        File.Copy(Path.Combine(Utx.Globale.Paths.CartellaModelli, "BackupLog.mdb"), IdFileBakLogEmme())
                    End If

                    SincronizzaBackup(ArchivioZip, Agenzia)
                    AggiornaDbLogEmme(ArchivioZip, Agenzia)
                End If

                'salva, se non esiste, backup mensile
                Dim ZipFileMensile As String = IdFileBakMensile(Agenzia)
                If Not File.Exists(ZipFileMensile) Then
                    File.Copy(ArchivioZip, ZipFileMensile)
                    AggiornaDbLog(Path.GetFileName(ZipFileMensile), Agenzia)
                End If
            Else
                Globale.Log.Info(String.Format("Creazione file zip: codice esito {0}", Esito.MessaggioErrore))

                'codici di errore winzip
                '0	Normal; no errors or warnings detected.
                '2	The zipfile is either truncated or damaged in some way (e.g., bogus internal offsets) that makes it appear to be truncated.
                '3	The structure of the zipfile is invalid; for example, it may have been corrupted by a text-mode ("ASCII") transfer.
                '4	Zip was unable to allocate sufficient memory to complete the command.
                '5	Internal logic error. (This should never happen; it indicates a programming error of some sort.)
                '6	ZipSplit was unable to create an archive of the specified size because the compressed size of a single included file is larger than the requested size. (Note that Zip and ZipSplit still do not support the creation of PKWARE-style multi-part archives.)
                '7	The format of a zipfile comment was invalid.
                '8	Testing (-T option) failed due to errors in the archive, insufficient memory to spawn UnZip, or inability to find UnZip.
                '9	Zip was interrupted by user (or superuser) action.
                '10	Zip encountered an error creating or using a temporary file.
                '11	Reading or seeking (jumping) within an input file failed.
                '12	There was nothing for Zip to do (e.g., "zip foo.zip").
                '13	The zipfile was missing or empty (typically when updating or freshening).
                '14	Zip encountered an error writing to an output file (typically the archive); for example, the disk may be full.
                '15	Zip could not open an output file (typically the archive) for writing.
                '16	The command-line parameters were specified incorrectly.
                '18	Zip could not open a specified file for reading; either it doesn't exist or the user running Zip doesn't have permission to read it.

                'Select Case EsitoZip

                '    Case 0
                '        'forzo la data di aggiornamento così da aggiornarla anche se nessun
                '        'file è cambiato. In questo caso ozip non l'aggiorna
                '        AggiornaDataModifica(ArchivioZip, Now)
                '        'aggiorno il file di log
                '        AggiornaDbLog(.ZipFileName, Agenzia)

                '        'se la rete è attiva sincronizza backup e aggiorna log su emme
                '        If Globale.ReteAttiva Then
                '            If Not File.Exists(IdFileBakLogEmme()) Then
                '                File.Copy(Path.Combine(Ut.Globale.Paths.CartellaModelli, "BackupLog.mdb"),
                '                                       IdFileBakLogEmme())
                '            End If

                '            SincronizzaBackup(.ZipFileName, Agenzia)
                '            AggiornaDbLogEmme(.ZipFileName, Agenzia)
                '        End If

                '        'salva, se non esiste, backup mensile
                '        Dim ZipFileMensile As String = IdFileBakMensile(Agenzia)
                '        If Not File.Exists(ZipFileMensile) Then
                '            File.Copy(ArchivioZip, ZipFileMensile)
                '            AggiornaDbLog(Path.GetFileName(ZipFileMensile), Agenzia)
                '        End If

                '    Case 3
                '        'file corrotto/non valido. lo annoto nel setting per cancellarlo alla prossima esecuzione
                '        'ora è bloccato e non si può cancellare
                '        My.Settings.FileCorrotto = ArchivioZip
                '        My.Settings.Save()

                '    Case 18
                '        'accesso negato ad un file. Annoto il backup nel setting per cancellarlo alla prossima
                '        'esecuzione e quindi rieseguire il backup
                '        Globale.Log.Info("Accesso negato ad uno o più file: Backup annullato")
                '        My.Settings.FileCorrotto = ArchivioZip
                '        My.Settings.Save()

                '    Case Else
                '        'aggiunge al log qualsiasi altro errore
                '        Globale.Log.Errore(oZip.GetLastMessage)
                'End Select
            End If

            Globale.Log.Rientro = 0

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
    'Private Sub AvviaBackup(ByVal Agenzia As String)
    '    'esegue il backup dell'agenzia

    '    Try
    '        'file destinazione della compressione
    '        Dim ArchivioZip As String = IdFileBak(Agenzia, Now)

    '        'in caso di errore esce
    '        If ArchivioZip.StartsWith("ERR") Then Exit Try

    '        'se non sono rilevate anomalie
    '        If Globale.RilevataAnomalia = False Then

    '            'blocca il backup se non sono passati almeno 60 minuti
    '            'utilizzo ultimo accesso perchè il file potrebbe non essere stato modificato.
    '            'monitorare il comportamento
    '            If File.Exists(ArchivioZip) Then
    '                Dim UltimoAggiornamento As Date = New FileInfo(ArchivioZip).LastAccessTime

    '                If DateDiff(DateInterval.Minute, UltimoAggiornamento, Now) < 60 Then
    '                    Globale.Log.Info(String.Format("Agenzia {0}: non sono ancora passati 60 minuti. Backup non eseguito",
    '                                         Agenzia),
    '                           True)
    '                    Exit Try
    '                End If
    '            End If
    '        End If

    '        'pulizia file temporanei
    '        PuliziaFileTemp(Agenzia)

    '        Globale.Log.Info("Avvio backup agenzia " + Agenzia)
    '        Globale.Log.Rientro += 4
    '        Globale.Log.Info("Destinazione: " + ArchivioZip)

    '        Dim oZip As New CGZipLibrary.CGZipFiles
    '        With oZip
    '            .ZipFileName = ArchivioZip
    '            .UpdatingZip = File.Exists(.ZipFileName) 'se il file già esiste lo aggiorna solo
    '            .IgnorePath = True

    '            'controllo cosa escludere dal backup
    '            CheckInserimentoBackup()

    '            'aggiunge i file da aggiornare/aggiungere nel backup
    '            Dim DbAgenzia As ArrayList

    '            If Agenzia = "00000" Then
    '                DbAgenzia = Globale.DbComuni
    '            Else
    '                DbAgenzia = Globale.StrutturaDb
    '            End If

    '            Globale.Log.Info("Database aggiunti al backup:")
    '            Globale.Log.Rientro += 4

    '            Dim PathDatiAgenzia As String = Path.Combine(Ut.Globale.Paths.CartellaDati, Agenzia)

    '            For Each db As Array In DbAgenzia

    '                If db(1) = True Then
    '                    .AddFile(Path.Combine(PathDatiAgenzia, db(0) + ".mdb"))
    '                    Globale.Log.Info(db(0))
    '                Else
    '                    Globale.Log.Info("***Database escluso dal backup: " + db(0))
    '                End If
    '            Next

    '            Globale.Log.Rientro -= 4

    '            'se sono stati aggiunti file da zippare
    '            If .ZipFileCount > 0 Then

    '                'creo/aggiorno il file zip
    '                Dim EsitoZip As Integer = .MakeZipFile

    '                Globale.Log.Info(String.Format("Creazione file zip: codice esito {0}", EsitoZip))

    '                'codici di errore winzip
    '                '0	Normal; no errors or warnings detected.
    '                '2	The zipfile is either truncated or damaged in some way (e.g., bogus internal offsets) that makes it appear to be truncated.
    '                '3	The structure of the zipfile is invalid; for example, it may have been corrupted by a text-mode ("ASCII") transfer.
    '                '4	Zip was unable to allocate sufficient memory to complete the command.
    '                '5	Internal logic error. (This should never happen; it indicates a programming error of some sort.)
    '                '6	ZipSplit was unable to create an archive of the specified size because the compressed size of a single included file is larger than the requested size. (Note that Zip and ZipSplit still do not support the creation of PKWARE-style multi-part archives.)
    '                '7	The format of a zipfile comment was invalid.
    '                '8	Testing (-T option) failed due to errors in the archive, insufficient memory to spawn UnZip, or inability to find UnZip.
    '                '9	Zip was interrupted by user (or superuser) action.
    '                '10	Zip encountered an error creating or using a temporary file.
    '                '11	Reading or seeking (jumping) within an input file failed.
    '                '12	There was nothing for Zip to do (e.g., "zip foo.zip").
    '                '13	The zipfile was missing or empty (typically when updating or freshening).
    '                '14	Zip encountered an error writing to an output file (typically the archive); for example, the disk may be full.
    '                '15	Zip could not open an output file (typically the archive) for writing.
    '                '16	The command-line parameters were specified incorrectly.
    '                '18	Zip could not open a specified file for reading; either it doesn't exist or the user running Zip doesn't have permission to read it.

    '                Select Case EsitoZip

    '                    Case 0
    '                        'forzo la data di aggiornamento così da aggiornarla anche se nessun
    '                        'file è cambiato. In questo caso ozip non l'aggiorna
    '                        AggiornaDataModifica(ArchivioZip, Now)
    '                        'aggiorno il file di log
    '                        AggiornaDbLog(.ZipFileName, Agenzia)

    '                        'se la rete è attiva sincronizza backup e aggiorna log su emme
    '                        If Globale.ReteAttiva Then
    '                            If Not File.Exists(IdFileBakLogEmme()) Then
    '                                File.Copy(Path.Combine(Ut.Globale.Paths.CartellaModelli, "BackupLog.mdb"),
    '                                                       IdFileBakLogEmme())
    '                            End If

    '                            SincronizzaBackup(.ZipFileName, Agenzia)
    '                            AggiornaDbLogEmme(.ZipFileName, Agenzia)
    '                        End If

    '                        'salva, se non esiste, backup mensile
    '                        Dim ZipFileMensile As String = IdFileBakMensile(Agenzia)
    '                        If Not File.Exists(ZipFileMensile) Then
    '                            File.Copy(ArchivioZip, ZipFileMensile)
    '                            AggiornaDbLog(Path.GetFileName(ZipFileMensile), Agenzia)
    '                        End If

    '                    Case 3
    '                        'file corrotto/non valido. lo annoto nel setting per cancellarlo alla prossima esecuzione
    '                        'ora è bloccato e non si può cancellare
    '                        My.Settings.FileCorrotto = ArchivioZip
    '                        My.Settings.Save()

    '                    Case 18
    '                        'accesso negato ad un file. Annoto il backup nel setting per cancellarlo alla prossima
    '                        'esecuzione e quindi rieseguire il backup
    '                        Globale.Log.Info("Accesso negato ad uno o più file: Backup annullato")
    '                        My.Settings.FileCorrotto = ArchivioZip
    '                        My.Settings.Save()

    '                    Case Else
    '                        'aggiunge al log qualsiasi altro errore
    '                        Globale.Log.Errore(oZip.GetLastMessage)
    '                End Select
    '            End If
    '        End With

    '        Globale.Log.Rientro = 0

    '    Catch ex As Exception
    '        Globale.Log.Errore(ex)
    '    End Try

    'End Sub

    Private Sub AggiornaDbLog(ByVal FileBackup As String,
                              ByVal Agenzia As String)

        If Not File.Exists(IdFileBakLog()) Then
            File.Copy(Path.Combine(Utx.Globale.Paths.CartellaModelli, "BackupLog.mdb"), IdFileBakLog())
        End If

        Try
            'prendo solo il nome del file senza path
            FileBackup = Path.GetFileName(FileBackup)

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + IdFileBakLog())
                c.Open()

                Using cmd As New OleDbCommand
                    With cmd
                        .Connection = c
                        .CommandType = CommandType.Text
                        'cancello i dati precedenti
                        .CommandText = "DELETE FROM Log WHERE Pc = ? AND FileBackup = ? AND Agenzia = ?"

                        .Parameters.AddWithValue("Pc", Environment.MachineName)
                        .Parameters.AddWithValue("FileBackup", FileBackup)
                        .Parameters.AddWithValue("Agenzia", Agenzia)

                        .ExecuteNonQuery()

                        'e poi aggiungo
                        .CommandText = "INSERT INTO Log(Pc,FileBackup,Agenzia,NomeDb,Tabella,Aggiornamento,Record) VALUES(?,?,?,?,?,?,?)"

                        Dim DataBackup As String = Now.ToString

                        'faccio la scansione delle cartelle e aggiorno la tabella con la cronologia backup
                        For Each tbl As Tabella In Globale.StrutturaTabelle

                            If ((Agenzia <> "00000") And (Not DbComuni(tbl.Database))) OrElse
                               ((Agenzia = "00000") And (DbComuni(tbl.Database))) Then

                                With .Parameters
                                    .Clear()
                                    .AddWithValue("Pc", Environment.MachineName)
                                    .AddWithValue("FileBackup", FileBackup)
                                    .AddWithValue("Agenzia", Agenzia)
                                    .AddWithValue("Database", tbl.Database)
                                    .AddWithValue("Tabella", tbl.Nome)
                                    .AddWithValue("Aggiornamento", DataBackup)
                                    .AddWithValue("Records", tbl.Records)
                                End With

                                .ExecuteNonQuery()
                            End If
                        Next
                    End With
                End Using
            End Using

            Globale.Log.Info("Aggiornato Db log per l'agenzia " + Agenzia)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub AggiornaDbLogNew(ByVal FileBackup As String, ByVal Agenzia As String)

        If Not File.Exists(IdFileBakLog()) Then
            File.Copy(Path.Combine(Utx.Globale.Paths.CartellaModelli, "BackupLog.mdb"), IdFileBakLog())
        End If

        Try
            'prendo solo il nome del file senza path
            FileBackup = Path.GetFileName(FileBackup)

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + IdFileBakLog())
                c.Open()

                Using cmd As New OleDbCommand
                    With cmd
                        .Connection = c
                        .CommandType = CommandType.Text
                        'cancello i dati precedenti
                        .CommandText = "DELETE FROM Log WHERE Pc = ? AND FileBackup = ? AND Agenzia = ?"

                        .Parameters.AddWithValue("Pc", Environment.MachineName)
                        .Parameters.AddWithValue("FileBackup", FileBackup)
                        .Parameters.AddWithValue("Agenzia", Agenzia)

                        .ExecuteNonQuery()

                        'e poi aggiungo
                        .CommandText = "INSERT INTO Log(Pc,FileBackup,Agenzia,NomeDb,Tabella,Aggiornamento,Record) VALUES(?,?,?,?,?,?,?)"

                        Dim DataBackup As String = Now.ToString

                        'faccio la scansione delle cartelle e aggiorno la tabella con la cronologia backup
                        For Each tbl As Tabella In Globale.StrutturaTabelle

                            If ((Agenzia <> "00000") And (Not DbComuni(tbl.Database))) OrElse
                               ((Agenzia = "00000") And (DbComuni(tbl.Database))) Then

                                With .Parameters
                                    .Clear()
                                    .AddWithValue("Pc", Environment.MachineName)
                                    .AddWithValue("FileBackup", FileBackup)
                                    .AddWithValue("Agenzia", Agenzia)
                                    .AddWithValue("Database", tbl.Database)
                                    .AddWithValue("Tabella", tbl.Nome)
                                    .AddWithValue("Aggiornamento", DataBackup)
                                    .AddWithValue("Records", tbl.Records)
                                End With

                                .ExecuteNonQuery()
                            End If
                        Next
                    End With
                End Using
            End Using

            Globale.Log.Info("Aggiornato Db log per l'agenzia " + Agenzia)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub AggiornaDbLogEmme(ByVal FileBackup As String,
                                  ByVal Agenzia As String)
        Try
            'prendo solo il nome del file senza path
            FileBackup = Path.GetFileName(FileBackup)

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + IdFileBakLogEmme())
                c.Open()

                Using cmd As New OleDbCommand
                    With cmd
                        .Connection = c
                        .CommandType = CommandType.Text

                        'cancello i dati precedenti
                        .CommandText = "DELETE " +
                                       "FROM Log " +
                                       "WHERE Pc = ? And FileBackup = ? And Agenzia = ?"

                        .Parameters.AddWithValue("Pc", Environment.MachineName)
                        .Parameters.AddWithValue("FileBackup", FileBackup)
                        .Parameters.AddWithValue("Agenzia", Agenzia)

                        .ExecuteNonQuery()

                        'copio i dati dal lo backup locale al log in emme
                        .CommandText = "INSERT INTO Log " +
                                       "SELECT * FROM Log IN '" + IdFileBakLog() + "' " +
                                       "WHERE Pc = ? And FileBackup = ? And Agenzia = ?"

                        .ExecuteNonQuery()
                    End With
                End Using
            End Using

            Globale.Log.Info("Aggiornato Db log su M: per l'agenzia " + Agenzia)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub SincronizzaBackup(ByVal FileBackup As String,
                                  ByVal Agenzia As String)
        Try
            Dim DestinazioneEmme As String = Path.Combine(Utx.Globale.Paths.CartellaBackupRete, Environment.MachineName)
            Dim DestEmmeAgenzia As String = Path.Combine(DestinazioneEmme, Agenzia)

            Directory.CreateDirectory(DestEmmeAgenzia)

            Dim fi As New FileInfo(FileBackup)
            Dim PathDestinazione As String = Path.Combine(DestEmmeAgenzia, fi.Name)

            If Utx.NetFunc.FileToMD5(PathDestinazione) <> Utx.NetFunc.FileToMD5(fi.FullName) Then
                File.Copy(fi.FullName, PathDestinazione, True)
            End If

            'sincronizzo le date dei due file
            AggiornaDataModifica(PathDestinazione, fi.LastWriteTime)

            Globale.Log.Info("Sincronizzato backup su M: per l'agenzia " + Agenzia)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PuliziaBackupRete(ByVal Agenzia As String)
        Dim DestinazioneAgenzia As String = Path.Combine(Utx.Globale.Paths.CartellaBackupRete, Agenzia)
        CancellaBackup(Agenzia, DestinazioneAgenzia)
    End Sub

    Private Sub PuliziaBackupLocale(ByVal Agenzia As String)
        Dim DestinazioneAgenzia As String = Path.Combine(Utx.Globale.Paths.CartellaBackup, Agenzia)
        CancellaBackup(Agenzia, DestinazioneAgenzia)
    End Sub

    Private Sub CancellaPreRollout()
        Try
            If Not Directory.Exists(Utx.Globale.Paths.CartellaBackupRete) Then Exit Sub

            Dim DestinazioneEmme As String = Path.Combine(Utx.Globale.Paths.CartellaBackupRete, "PreRollout")

            If Directory.Exists(DestinazioneEmme) Then
                'cancella tutta la cartella con il contenuto
                My.Computer.FileSystem.DeleteDirectory(DestinazioneEmme, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CancellaVecchiBackup()
        'cancella vecchi backup pre-server da M:
        Try
            If Not Directory.Exists(Utx.Globale.Paths.CartellaBackupRete) Then Exit Sub

            For Each d As String In Directory.GetDirectories(Utx.Globale.Paths.CartellaBackupRete, "U?????-??-??")
                If New DirectoryInfo(d).LastWriteTime < #1/1/2017# Then
                    My.Computer.FileSystem.DeleteDirectory(d, FileIO.DeleteDirectoryOption.DeleteAllContents)
                End If
            Next

        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try
        'cancella vecchi backup pre-server da C:
        Try
            If Not Directory.Exists(Utx.Globale.Paths.CartellaBackup) Then Exit Sub

            For Each d As String In Directory.GetDirectories(Utx.Globale.Paths.CartellaBackup, "U?????-??-??")
                If New DirectoryInfo(d).LastWriteTime < #1/1/2017# Then
                    My.Computer.FileSystem.DeleteDirectory(d, FileIO.DeleteDirectoryOption.DeleteAllContents)
                End If
            Next

        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try
    End Sub

    ''' <summary>
    ''' cancella i file temporanei creati per costruire lo zip e residuati da problemi nel processo
    ''' </summary>
    ''' <param name="Agenzia"></param>
    ''' <remarks></remarks>
    Private Sub PuliziaFileTemp(ByVal Agenzia As String)
        Try
            Dim FileCancellati As Integer = 0

            'il punto nel pattern mi serve per dire che sono file senza estensione (zia12345/zib12345)
            For Each f As String In Directory.GetFiles(IdDirBak(Agenzia), "zi?*.", SearchOption.TopDirectoryOnly)
                File.Delete(f)
                Globale.Log.Info(String.Format("Cancellato file temp {0}", f))
                FileCancellati += 1
            Next

            Globale.Log.Info(String.Format("Cancellati {0} file temp per l'agenzia {1}",
                                 FileCancellati, Agenzia))

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CancellaBackup(Agenzia As String,
                               Cartella As String,
                               Optional DataInizio As Date = #1/1/1900#)
        Try
            If Directory.Exists(Cartella) = False Then Exit Sub

            'rimuovo i file più vecchi di DataInizio dalla cartella 
            'permanenza di default nel backup di 1 mese
            If DataInizio = #1/1/1900# Then
                DataInizio = Now.AddMonths(-1).Date
            End If

            Globale.Log.Info()

            'cancello i giornalieri
            Dim FileCancellati As Integer = 0

            For Each f As String In Directory.GetFiles(Cartella, "Giorno*.zip", SearchOption.TopDirectoryOnly)
                If New FileInfo(f).LastWriteTime < DataInizio Then
                    File.Delete(f)
                    FileCancellati += 1
                End If
            Next
            Globale.Log.Info(String.Format("Cancellati {0} file tipo backup giornaliero in {1} precedenti al {2:d}", FileCancellati, Cartella, DataInizio))

            'cancello i vecchi file mensili
            FileCancellati = 0
            DataInizio = New DateTime(Today.Year - 1, 1, 1)
            For Each f As String In Directory.GetFiles(Cartella, "??-????.zip", SearchOption.TopDirectoryOnly)
                If New FileInfo(f).LastWriteTime < DataInizio Then
                    File.Delete(f)
                    FileCancellati += 1
                End If
            Next

            Globale.Log.Info(String.Format("Cancellati {0} file tipo backup mensile in {1} precedenti al {2:d}", FileCancellati, Cartella, DataInizio))

            'cancello le note
            FileCancellati = 0

            For Each f As String In Directory.GetFiles(Cartella, "Note.*.zip", SearchOption.TopDirectoryOnly)
                If New FileInfo(f).LastWriteTime < DataInizio Then
                    File.Delete(f)
                    FileCancellati += 1
                End If
            Next

            Globale.Log.Info(String.Format("Cancellati {0} file tipo backup note in {1} precedenti al {2:d}", FileCancellati, Cartella, DataInizio))

            'ora aggiorno il db di log in rete eliminando i riferimenti più vecchi di 7 giorni
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + IdFileBakLogEmme())
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    'cancello i dati precedenti
                    cmd.CommandText = "DELETE FROM Log WHERE (Pc = ?) AND (LEFT(Filebackup,6) = 'Giorno') AND (Agenzia = ?) AND (Aggiornamento < ?)"

                    cmd.Parameters.AddWithValue("Pc", Environment.MachineName)
                    cmd.Parameters.AddWithValue("Agenzia", Agenzia)
                    cmd.Parameters.AddWithValue("Data", DataInizio)

                    Globale.Log.Info(String.Format("Cancellati {0} record backup tipo giornaliero precedenti al {2:d}", cmd.ExecuteNonQuery, Cartella, DataInizio))

                    cmd.CommandText = "DELETE FROM Log WHERE (Pc = ?) AND (LEFT(Filebackup,4) = 'Note') AND (Agenzia = ?) AND (Aggiornamento < ?)"
                    Globale.Log.Info(String.Format("Cancellati {0} record backup tipo note precedenti al {2:d}", cmd.ExecuteNonQuery, Cartella, DataInizio))
                End Using
            End Using
            Globale.Log.Info()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Module

