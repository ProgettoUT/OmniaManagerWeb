Imports System.IO
Imports Microsoft.Office.Interop.Excel
Imports System.Data
Imports DataTable = System.Data.DataTable
Imports System.Data.OleDb
Imports OleDbConnection = System.Data.OleDb.OleDbConnection
Imports System.Runtime.Serialization.Formatters.Binary

Public Class Migrazione

    Public Shared Sub MigraNote()
        'migrazione alle note web
        If Environment.MachineName = "X390-GUIDO" OrElse Environment.MachineName = "WIN-06SA406AJ9U" Then
            Exit Sub
        End If
#If DEBUG Then
        Exit Sub
#End If
        'solo se M: è il disco dati
        If Utx.Globale.Paths.CartellaDati.ToUpper <> "M:\UNITOOLS\DATI" Then
            Exit Sub
        End If

        Dim Notifica As New Utx.FormNotifica
        With Notifica
            .Stile = Utx.FormNotifica.Style.ANTRACITE
            .Messaggio = "..."
        End With

        If Utx.Globale.SettingGlobale.EsisteChiave(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_NOTE_WEB) = False Then
            Dim MessaggioVisualizzato As Boolean = False
            Dim Messaggio As String = "ATTENZIONE:{0}{0}Verrà ora effettuata la migrazione delle note in cloud.{0}{0}" +
                "Le note saranno quindi disponibili a tutti gli utenti dell'agenzia, anche in smart working o in mobilità.{0}{0}" +
                "L'operazione durerà solo qualche minuto.{0}{0}" +
                "Aggiornare immediatamente OmniaManager per tutti gli utenti: le note scritte dagli utenti NON aggiornati NON saranno salvate."

            Dim Errore As Boolean = False

            Notifica.Show()
            Notifica.Messaggio = "Verifica migrazione note web"
            Globale.Log.Info("Verifica migrazione note web")

            For Each agenzia As String In Utx.EnteGestore.CodiciGestiti
                Try
                    Using s As New Utx.ServiziOMW.ServizioDatiOMW
                        s.Proxy = Utx.Globale.UniProxy.Proxy

                        If s.EsisteTabella(agenzia, ServiziOMW.TipoDatabase.AGENZIA, "SinistriMemo", Utx.Globale.Token) = False Then
                            Globale.Log.Info("la tabella SinistriMemo ({0}) non esiste", {agenzia})

                            If MessaggioVisualizzato = False Then
                                'visualizza messaggio generale
                                MsgBox(String.Format(Messaggio, Environment.NewLine), MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                                MessaggioVisualizzato = True
                            End If

                            Notifica.Messaggio = String.Format("Migrazione in corso codice {0}", agenzia)
                            Globale.Log.Info("Migrazione in corso codice {0}", {agenzia})

                            For Each db As String In Directory.GetFiles(Path.Combine(Utx.Globale.Paths.CartellaDati, agenzia), "Note.mdb")
                                Dim FileZip As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Db.zip")
                                File.Delete(FileZip)

                                Utx.LibreriaZip.SevenZip.ZipFile(db, FileZip)
                                Dim b As Byte() = File.ReadAllBytes(FileZip)

                                Utx.Globale.Log.Info("inizio Upload {0}", {Path.GetFileName(db)})
                                'Notifica.Messaggio = "Invio al server..."

                                If s.UploadDatabase(agenzia, b, Path.GetFileName(db), True, Utx.Globale.Token) = True Then
                                    If s.MigraDatabase(agenzia, Utx.Globale.Token) = True Then
                                        Notifica.Messaggio = "Trasferimento concluso correttamente"
                                    Else
                                        Errore = True
                                        Globale.Log.Info("Errore nella migrazione dei dati")
                                        Notifica.Messaggio = "Errore nella migrazione dei dati"
                                    End If
                                Else
                                    Errore = True
                                    Globale.Log.Info("Errore nel trasferimento del db")
                                    Notifica.Messaggio = "Errore nel trasferimento del db"
                                End If
                            Next
                        End If
                    End Using
                Catch ex As Exception
                    Globale.Log.Info(ex.Message)
                    Errore = True
                End Try
            Next

            If Errore = False Then
                Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_NOTE_WEB, Now)
            End If
        End If

        'se la migrazione delle note è stata fatta
        If Utx.Globale.SettingGlobale.EsisteChiave(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_NOTE_WEB) = True Then
            'ma lo storico non è stato ancora migrato
            If Utx.Globale.SettingGlobale.EsisteChiave(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_STORICO_NOTE_WEB) = False Then
                Notifica.Show()
                For Each agenzia As String In Utx.EnteGestore.CodiciGestiti
                    If MigraStoricoNote(agenzia, Notifica) = False Then
                        Notifica.Chiudi()
                        Exit Sub 'esco dalla sub e non scrivo la chiave
                    End If
                Next
                Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_STORICO_NOTE_WEB, Now)
            End If
        End If
        Notifica.Chiudi()
    End Sub

    Private Shared Function MigraStoricoNote(Agenzia As String, Notifica As Utx.FormNotifica) As Boolean
        Try
            Dim Errore As Boolean = False

            Notifica.Messaggio = String.Format("Migrazione storico note {0}", Agenzia)

            Dim db As String = Utx.ConnessioniDb.PathMdbAgenzia(Agenzia, "UtStorico.mdb")
            Dim FileZip As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Db.zip")
            File.Delete(FileZip)

            Utx.LibreriaZip.SevenZip.ZipFile(db, FileZip)
            Dim b As Byte() = File.ReadAllBytes(FileZip)

            Utx.Globale.Log.Info("inizio Upload {0}", {Path.GetFileName(db)})

            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy

                Notifica.Messaggio = "Trasferimento dati..."

                If s.UploadDatabase(Agenzia, b, Path.GetFileName(db), True, Utx.Globale.Token) = True Then
                    If s.MigrazioneStoricoNoteEx(Agenzia, Utx.Globale.Token) = True Then
                        Notifica.Messaggio = "Trasferimento concluso correttamente"
                        Return True
                    Else
                        Globale.Log.Info("Errore nella migrazione dei dati")
                        Notifica.Messaggio = "Errore nella migrazione dei dati"
                        Return False
                    End If
                Else
                    Globale.Log.Info("Errore nel trasferimento del db")
                    Notifica.Messaggio = "Errore nel trasferimento del db"
                    Return False
                End If
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Sub MigraTutto(CodiceAgenzia As String)
        Try
            PreparaMigrazioneCodice(CodiceAgenzia)
            MigraCodice(CodiceAgenzia)
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
        'Try
        '    For Each Agenzia In Utx.EnteGestore.CodiciGestiti
        '        PreparaMigrazioneCodice(Agenzia)
        '        MigraCodice(Agenzia)
        '    Next
        'Catch ex As Exception
        '    Utx.Globale.Log.Errore(ex)
        'End Try
    End Sub

    Public Shared Sub MigraCodice(Agenzia As String)
        Utx.Globale.Log.Info("Invio dati per la migrazione di {0}", {Agenzia})

        Using s As New Utx.ServiziOMW.ServizioDatiOMW
            s.Proxy = Utx.Globale.UniProxy.Proxy

            For Each db As String In Directory.GetFiles(Path.Combine(Utx.Globale.Paths.CartellaDati, Agenzia), "*.mdb")
                Utx.Globale.Log.Info("preparo il database {0}", {db})

                If s.EsisteMdb(Agenzia, Path.GetFileName(db), Utx.Globale.Token) = False Then
                    Dim FileZip As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Db.zip")
                    File.Delete(FileZip)

                    Utx.LibreriaZip.SevenZip.ZipFile(db, FileZip)

                    Dim CartellaUpload As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Upload")
                    Directory.CreateDirectory(CartellaUpload)

                    Dim fileName As String = FileZip
                    Dim fileSizeInMB As Integer = 20
                    Dim baseFileName As String = Path.GetFileName(fileName)
                    Dim MaxSize As Integer = fileSizeInMB * (1024 * 1024)
                    Dim fsBuffer As Byte() = New Byte(1023) {}
                    Using fileStream As New FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read)
                        Dim totalFileParts As Integer = 0
                        If fileStream.Length < MaxSize Then
                            totalFileParts = 1
                        Else
                            Dim preciseFileParts As Single = (CSng(fileStream.Length) / CSng(MaxSize))
                            totalFileParts = CInt(Math.Ceiling(preciseFileParts))
                        End If

                        Dim filePartCount As Integer = 0
                        While fileStream.Position < fileStream.Length
                            Dim filePartName As String = String.Format("{0}.part_{1}-{2}", baseFileName, (filePartCount + 1).ToString(), totalFileParts.ToString())
                            filePartName = Path.Combine(CartellaUpload, filePartName)
                            Using fsFilePart As New FileStream(filePartName, FileMode.Create)
                                Dim bytesRemaining As Integer = MaxSize
                                Dim bytesRead As Integer = 0
                                While bytesRemaining > 0
                                    bytesRead = fileStream.Read(fsBuffer, 0, Math.Min(bytesRemaining, 1024))

                                    If bytesRead = 0 Then
                                        Exit While
                                    End If

                                    fsFilePart.Write(fsBuffer, 0, bytesRead)
                                    bytesRemaining -= bytesRead
                                End While
                            End Using
                            filePartCount += 1
                        End While
                    End Using

                    For Each fileChunk In Directory.GetFiles(CartellaUpload)
                        Dim b As Byte() = File.ReadAllBytes(fileChunk)
                        If s.UploadDatabaseChunk(Agenzia, b, Path.GetFileName(fileChunk), Path.GetFileName(db), False, Utx.Globale.Token) = False Then
                            MsgBox("errore", MsgBoxStyle.Exclamation)
                        End If
                        File.Delete(fileChunk)
                    Next
                    Utx.Globale.Log.Info("inviato database {0}", {db})
                End If
            Next
            Utx.Globale.Log.Info("Migro i dati in sql server")
            s.MigraTutto(Agenzia, ServiziOMW.TipoDatabase.AGENZIA, Utx.Globale.Token)
        End Using
    End Sub

    Private Shared Sub PreparaMigrazioneCodice(Codice As String)
        Try
            Utx.Globale.Log.Info("migrazione dati {0} - preparazione dati", {Codice})
            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Codice, ConnessioniDb.Db.INFO))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    Dim sql As String = "SELECT * INTO {0} FROM {0} IN '{1}'"

                    Dim Supporto As String = Utx.ConnessioniDb.PathMdbAgenzia(Codice, Utx.ConnessioniDb.Db.SUPPORTO)
                    For Each tbl As String In "Liquidatori/ProfiloUtente/PeritoIncaricato".Split("/")
                        If Utx.FunzioniDb.EsisteTabella(c, tbl) = False Then
                            cmd.CommandText = String.Format(sql, tbl, Supporto)
                            cmd.ExecuteNonQuery()
                        End If
                    Next

                    Dim Sms As String = Utx.ConnessioniDb.PathMdbAgenzia(Codice, Utx.ConnessioniDb.Db.SMS)
                    For Each tbl As String In "Storico/Utente".Split("/")
                        If Utx.FunzioniDb.EsisteTabella(c, tbl) = False Then
                            cmd.CommandText = String.Format(sql, tbl, Sms)
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End Using
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Function MigraDbUno(Agenzia As String) As Boolean
        Try
            'migrazione dbuno
            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy
                If s.EsisteMdb(Agenzia, "DbUno.mdb", Utx.Globale.Token) = False Then
                    Utx.Globale.Log.Info("Migrazione DbUno {0}", {Agenzia})
                    Dim Db As String = Path.Combine(Utx.Globale.Paths.CartellaArchivioDati, Agenzia, "OMNIA\DbUno.mdb")

                    Using c As New OleDbConnection(Utx.Globale.MDBDriver + Db)
                        c.Open()

                        Using cmd As New OleDbCommand
                            cmd.Connection = c
                            'clienti
                            Utx.Globale.Log.Info("sistemazione tabella clienti")
                            cmd.CommandText = String.Format("DELETE FROM Clienti1 WHERE CodicePuntoVendita <> '{0}'", Agenzia)
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "DELETE FROM Clienti1 WHERE LEN(CodiceFiscale) <> 16 AND LEN(CodiceFiscale) <> 11"
                            cmd.ExecuteNonQuery()
                            'polizze
                            Utx.Globale.Log.Info("sistemazione tabelle polizze1/4")
                            For Each tbl As String In "Polizze1;Polizze2;Polizze3;Polizze4".Split(";")
                                cmd.CommandText = String.Format("DELETE FROM {0} WHERE CodicePuntoVendita <> {1}", tbl, Agenzia)
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = String.Format("DELETE DISTINCTROW A.* FROM {0} AS A
                            INNER JOIN (
                            SELECT MAX(dataelaborazione) AS Aggiornamento,ramo,polizza,COUNT(*)
                            FROM {0}
                            GROUP BY ramo,polizza
                            HAVING COUNT(*) > 1) AS B
                            ON a.ramo=b.ramo AND a.polizza=b.polizza
                            WHERE a.dataelaborazione<b.aggiornamento", tbl)
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = String.Format("DELETE DISTINCTROW A.* FROM {0} AS A
                            INNER JOIN (
                            SELECT ramo,polizza
                            FROM {0}
                            GROUP BY ramo,polizza
                            HAVING COUNT(*) > 1) AS B
                            ON a.ramo=b.ramo AND a.polizza=b.polizza", tbl)
                                cmd.ExecuteNonQuery()
                            Next
                        End Using
                    End Using

                    Dim th As New Threading.Thread(Sub()
                                                       Utx.OmWeb.InviaFile(Agenzia,
                                                   Path.Combine(Utx.Globale.Paths.CartellaArchivioDati, Agenzia, "OMNIA\DbUno.mdb"),
                                                   Utx.ServiziOMW.TipoEvento.MIGRA_DBUNO.ToString, False)
                                                   End Sub)
                    th.Start()
                    th.Join()
                Else
                    Utx.Globale.Log.Info("Migrazione DbUno {0} già effettuata", {Agenzia})
                End If
            End Using
            Return True
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function
End Class
