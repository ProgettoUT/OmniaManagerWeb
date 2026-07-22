Imports System.Environment
Imports System.IO
Imports System.Windows.Forms

Module UniAggio
    Public FILETOCHECK As String = "CatalogoOMW"

    Dim IconaNotifica As New NotifyIcon

    Function Aggiorna(forzaAggiornamento As Boolean) As Boolean
        Dim logger As New Utx.ApplicationLog("Uniaggio.log")
        Try
            Dim ultimoAccesso As String = Path.Combine(CARTELLA_SETTING, "UltimoAccesso" & fileToCheck)

            If forzaAggiornamento = False Then
                If IO.File.Exists(ultimoAccesso) Then
                    If IO.File.GetLastWriteTime(ultimoAccesso) >= Today Then
                        Return False
                    End If
                End If
            End If

            Dim uniwebEsplo As New UnicoServices.UniwebEsplo
            logger.Info()
            logger.Info("*** NUOVO CONTROLLO ***")
            logger.Info("Classe UniwebEsplo instanziata: OK")

            With uniwebEsplo
                .Timeout = 15000 '15 secondi
                .Proxy = Utx.Globale.UniProxy.Proxy
            End With

            ' Controllo la versione del file sul server
            logger.Info("verifico versione server di " & fileToCheck)
            Dim versioneServer As Long = uniwebEsplo.GetVersione("Oggetti") '(fileToCheck)
            logger.Info("versione server: " & versioneServer)

            'scrive file ultimo accesso
            logger.Info("aggiorno file ultimo accesso")
            File.WriteAllText(ultimoAccesso, Today)
            logger.Info("file ultimo accesso OK")


            Dim versioneLocale As Long = 0
            Dim sFiles As String() = Directory.GetFiles(CARTELLA_SETTING, "VersioneFile" & fileToCheck & ".*.txt")

            Dim fileVersione As String = Nothing
            If sFiles.Length > 0 Then
                fileVersione = Path.Combine(CARTELLA_SETTING, sFiles(sFiles.GetUpperBound(0)))
                versioneLocale = File.ReadAllText(fileVersione)
            End If

            logger.Info("versione locale: " & versioneLocale)

            ' se le versioni sono uguali, esce
            If forzaAggiornamento = False Then
                If versioneLocale = versioneServer Then
                    logger.Info("versione server = versione locale: nessun aggiornamento")
                    Return False
                End If
            End If

            'Notifica aggiornamento in corso
            With IconaNotifica
                .Icon = System.Drawing.SystemIcons.Information
                .Visible = True
                .ShowBalloonTip(10000,
                                "Aggiornamenti Unitools.",
                                "Aggiornamento catalogo estrazioni in corso ...",
                                ToolTipIcon.Info)
            End With

            'scarica l'oggetto
            logger.Info("scarico " & fileToCheck)
            Dim fileOggetti As Byte() = uniwebEsplo.GetFile(fileToCheck)

            ' e scrive il file nel disco
            Dim fileName As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "catalogo.zip")
            File.WriteAllBytes(fileName, fileOggetti)
            logger.Info(fileToCheck & " scaricati OK")

            'DECOMPRIMO IL FILE ZIP
            Dim pathDest As String = Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, "Oggetti\Queries\")
            logger.Info("decomprimo " & FILETOCHECK & " in " & pathDest)
            Utx.LibreriaZip.UnZipFileEx(fileName, pathDest)
            logger.Info("decompressione ok")

            'scrive file versione
            logger.Info("aggiorno file versione...")
            If fileVersione IsNot Nothing Then File.Delete(fileVersione)
            File.WriteAllText(Path.Combine(CARTELLA_SETTING, "VersioneFile" & fileToCheck & "." & versioneServer & ".txt"), versioneServer)
            logger.Info("file versione OK")

            'libera spazio nella temp
            If File.Exists(fileName) Then File.Delete(fileName)

            With IconaNotifica
                .Icon = System.Drawing.SystemIcons.Information
                .Visible = True
                .ShowBalloonTip(10000,
                                "Aggiornamenti Unitools.",
                                "E' stato aggiornato il catalogo delle estrazioni.",
                                ToolTipIcon.Info)
            End With
            Return True
        Catch ex As Exception
            logger.Info(ex.Source & " " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return False
    End Function
End Module
