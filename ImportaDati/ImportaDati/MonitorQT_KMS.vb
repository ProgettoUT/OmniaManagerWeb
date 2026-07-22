Imports System.IO
Imports System.Data.OleDb

Public Class MonitorQT_KMS

    Private ReadOnly mAgenziaFiglia As Utx.AgenziaFigliaOmnia
    Private ReadOnly mRecordConfig As Utx.RecordConfigOmnia
    Private FileQT As FileCasellario

    Sub New(ByRef AgenziaFiglia As Utx.AgenziaFigliaOmnia,
            ByRef RecordConfig As Utx.RecordConfigOmnia)
        mAgenziaFiglia = AgenziaFiglia
        mRecordConfig = RecordConfig
    End Sub

    Public Sub ImportaMonitorQT_KMS()
        Try
            If PreparaTabella() = False Then
                Globale.Log.Info("Errore nella preparazione della tabella MonitorQT_KMS")
                Exit Try
            End If

            FileQT = New FileCasellario() With {
                .AgenziaFiglia = mAgenziaFiglia,
                .RecordConfig = mRecordConfig,
                .TipoFile = Utx.Enumerazioni.TipoFileMagia.MonitorQT_KMS,
                .ImportazioneDB = True}
            FileQT.PrimoAggiornamento()

            Do While FileQT.DataRiferimento.AddDays(-45) <= FileQT.MaxDataDownload
                FileQT.NomeFile = String.Format("{0}_RCA_MONQT_KMS_DEL_{1}.ZIP", mRecordConfig.AgenziaCollegata, Format(FileQT.DataRiferimento, "MMyyyy"))
                FileQT.Init()
                FileQT.ScaricaFile()
                If FileQT.ErroreCritico = True Then Exit Try

                If mAgenziaFiglia.SoloScaricoFile = False Then
                    'se non siamo in modalità creazione archivio e il file è disponibile importo
                    If FileQT.FileDisponibile = True Then
                        Importa()
                    End If
                End If

                'importante per tenere la cartella vuota
                SvuotaCartella(mAgenziaFiglia.Cartelle.CartellaArriviLocaleTempDL)
                'avanza la data di 1 mese e ripete il loop
                FileQT.ProssimoAggiornamento()
            Loop

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        Finally
            Globale.Log.Info()
        End Try
    End Sub

    Private Function PreparaTabella() As Boolean
        Try
            Globale.Log.Info(">>> Prepara tabella")

            Using cnArrivi As New OleDbConnection(mAgenziaFiglia.ConnectionStringArrivi)
                cnArrivi.Open()

                'aggiungo una chiave alla tabella monitorQT
                Utx.FunzioniDb.CancellaChiaveDb(cnArrivi, "MonitorQT_KMS", "pk_MonQT_KMS")
                Utx.FunzioniDb.CreaChiaveDb(cnArrivi, "MonitorQT_KMS", "pk_MonQT_KMS", {"Polizza", "Effetto"})

                Using cmd As New OleDbCommand
                    cmd.Connection = cnArrivi

                    Using da As New OleDbDataAdapter("SELECT * FROM MonitorQT_KMS", cnArrivi)

                        Using cmdBuilder As New OleDbCommandBuilder(da)
                            With cmd
                                .CommandType = CommandType.Text
                                Try
                                    'creo la stored procedure di insert
                                    .CommandText = "Create Procedure InsQT_KMS AS " + cmdBuilder.GetInsertCommand.CommandText
                                    .ExecuteNonQuery()
                                Catch ex As Exception
                                    'esiste già
                                End Try
                                Try
                                    'creo la stored procedure di delete
                                    .CommandText = "Create Procedure DelQT_KMS AS " +
                                                   "DELETE FROM MonitorQT WHERE Polizza = ? AND Effetto = ?"
                                    .ExecuteNonQuery()
                                Catch ex As Exception
                                    'esiste già
                                End Try
                            End With
                        End Using
                    End Using
                End Using
            End Using

            Return True

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
            FileQT.SvuotaTabella()
            Return False
        End Try
    End Function

    Private Sub Importa()
        Try
            Globale.IconaNotifica.Text = String.Format("Unitools: importa monitor QT KMS...")
            Globale.Log.Info(">>> ImportaMonitorQT_KMS")

            Dim Mese As Integer = Val(Left(Right(FileQT.FileScaricato, 10), 2))
            Dim Anno As Integer = Val(Left(Right(FileQT.FileScaricato, 8), 4))

            Dim DataFile As Date = New Date(Anno, Mese, 1)

            Select Case DataFile
                Case Is >= #1/1/2018# 'prima di questa data non abbiamo gestito i file
                    If EstraiCampi2018_01(FileQT.FileScaricato) = False Then
                        Throw New System.Exception("Errore nell'importazione Monitor QT KMS")
                    End If
            End Select

            'aggiorno il calendario
            Dim DataInizio As Date = New DateTime(Anno, Mese, 1).Date
            Dim DataFine As Date = Utx.FunzioniData.FineMese(DataInizio)

            FileQT.AggiornaCalendarioUt(Utx.FunzioniData.InizioMese(FileQT.DataRiferimento),
                                        Utx.FunzioniData.FineMese(FileQT.DataRiferimento))

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
            FileQT.SvuotaTabella()
        End Try
    End Sub

    Private Function EstraiCampi2018_01(FileDati As String) As Boolean

        Dim Campi As New ArrayList
        Dim dt As New DataTable
        Dim NumeroRecord As Integer = 0

        Try
            'creo la tabella
            Using da As New OleDbDataAdapter("SELECT * FROM MonitorQT_KMS WHERE False", mAgenziaFiglia.ConnectionStringArrivi)

                Using cmdBuilder As New OleDbCommandBuilder(da)
                    cmdBuilder.QuotePrefix = "[" 'altrimenti i server di SDM non vanno (imposatazioni internazionali?)
                    cmdBuilder.QuoteSuffix = "]"

                    da.InsertCommand = cmdBuilder.GetInsertCommand
                    da.Fill(dt)

                    'assegno una chiave per la ricerca
                    dt.PrimaryKey = {dt.Columns("Polizza"), dt.Columns("Effetto")}

                    'apro lo stream
                    Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                        'leggo la prima riga con il nome dei campi
                        If sr.ReadLine.Split(";").Length < 198 Then
                            Globale.Log.Info("File NON importato: tracciato non gestito.")
                        Else
                            Do While Not sr.EndOfStream
                                Campi.Clear()
                                NumeroRecord += 1

                                Campi.InsertRange(0, Replace(sr.ReadLine, Chr(34), "", , , CompareMethod.Text).Split({";"c}))
                                'la riga termina con un ; generando un campo vuoto fasullo (198)
                                Campi.RemoveAt(198)

                                TrimArray(Campi)

                                'valuta i codici sub e prod se impostati
                                If mRecordConfig.ConsensoImportazione(Campi(2), Campi(3)) = True Then
                                    'cancella un record con la stessa chiave (polizza/effetto) per evitare errori
                                    'se il record già esiste dovrebbe essere comunque più vecchio (di un file precedente)
                                    Dim r As DataRow = dt.Rows.Find({Campi(1), Campi(4)})
                                    If r IsNot Nothing Then r.Delete()

                                    'aggiusto alcuni campi
                                    'il campo sub/produttore (2/3) può contenere schifezze
                                    If (String.IsNullOrEmpty(Campi(2).Trim)) OrElse (Campi(2) > 9999) Then Campi(2) = "0"
                                    If (String.IsNullOrEmpty(Campi(3).Trim)) OrElse (Campi(3) > 9999) Then Campi(3) = "0"
                                    Campi(12) = IIf(Campi(12).Length = 0, 0, Campi(12)) 'KmPercorsi
                                    If Campi(43).ToString.StartsWith("=") Then Campi(43) = Campi(43).ToString.Substring(1) 'piva
                                    Campi(44) = Left(Campi(44), 40) 'Contraente
                                    If Campi(45).ToString.StartsWith("=") Then Campi(45) = Campi(45).ToString.Substring(1) 'piva
                                    Campi(46) = Left(Campi(46), 40) 'Proprietario
                                    Campi(191) = Campi(191).ToString.Replace(" ", "") 'max
                                    Campi(192) = Campi(192).ToString.Replace(" ", "") 'max

                                    Dim dr As DataRow = dt.NewRow

                                    For k As Integer = 0 To 197
                                        If dt.Columns(k).DataType Is System.Type.GetType("System.Double") Then
                                            dr(k) = CDbl(Campi(k)) 'per convertire correttamente la notazione italiana
                                        ElseIf dt.Columns(k).DataType Is System.Type.GetType("System.Single") Then
                                            dr(k) = CSng(Campi(k)) 'per convertire correttamente la notazione italiana
                                        ElseIf dt.Columns(k).DataType Is System.Type.GetType("System.DateTime") Then
                                            dr(k) = Utx.FunzioniDb.Str2Data(Campi(k))
                                        Else
                                            dr(k) = Campi(k)
                                        End If
                                    Next
                                    dt.Rows.Add(dr)
                                End If
                            Loop
                        End If
                    End Using

                    da.Update(dt)
                    Globale.Log.Info(String.Format("Importati {0} record su {1}", dt.Rows.Count, NumeroRecord))
                End Using
            End Using

            Return True

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
            Globale.Log.LogDataTable(dt, Campi)
            TrovaErrore(dt, Campi)
            Return False
        Finally
            Campi = Nothing
            dt.Dispose()
        End Try
    End Function

    Public Sub TrovaErrore(dt As DataTable, Campi As ArrayList)
        Try
            Using c As New OleDbConnection(mAgenziaFiglia.ConnectionStringArrivi)
                c.Open()
                Utx.FunzioniDb.CancellaChiaveDb(c, "MonitorQT_KMS")

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    For k As Integer = 1 To dt.Columns.Count - 1
                        cmd.CommandText = String.Format("INSERT INTO MonitorQT_KMS ({0}) VALUES(?)", dt.Columns(k).ColumnName)
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("1", Campi(k))

                        Try
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            Globale.LogErrori.Info(String.Format("campo: {1}{0}nome: {2}{0}valore: {3}", Environment.NewLine, k, dt.Columns(k).ColumnName, Campi(k)))
                        End Try
                    Next
                End Using
            End Using

        Catch ex As Exception
            Globale.LogErrori.Errore(ex)
        End Try
    End Sub
End Class
