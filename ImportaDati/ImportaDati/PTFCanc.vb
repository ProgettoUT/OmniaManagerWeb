Imports System.IO
Imports System.Data.OleDb

Public Class PTFCanc

    Private mAgenziaFiglia As Utx.AgenziaFigliaOmnia
    Private mRecordConfig As Utx.RecordConfigOmnia
    Private FilePTFCanc As FileCasellario

    Sub New(ByRef AgenziaFiglia As Utx.AgenziaFigliaOmnia,
            ByRef RecordConfig As Utx.RecordConfigOmnia)
        mAgenziaFiglia = AgenziaFiglia
        mRecordConfig = RecordConfig
    End Sub

    Public Sub CreaPTFCanc()
        Try
            FilePTFCanc = New FileCasellario() With {
                .AgenziaFiglia = mAgenziaFiglia,
                .RecordConfig = mRecordConfig,
                .TipoFile = Utx.Enumerazioni.TipoFileMagia.MovimentiPTF,
                .ImportazioneDB = False}
            FilePTFCanc.PrimoAggiornamento()

            'fine download è l'inizio dell'ultima decade completa
            Dim FineDownload As Date = Utx.FunzioniData.MinDate(InizioUltimaDecadeCompleta, FilePTFCanc.MaxDataDownload)

            If FineDownload < FilePTFCanc.DataRiferimento Then
                Globale.Log.Info("Nessuna nuova decade completa")
            End If

            Do While FilePTFCanc.DataRiferimento <= FineDownload

                Dim InizioDecade As Date = Utx.FunzioniData.InizioDecade(FilePTFCanc.DataRiferimento)
                Dim FineDecade As Date = Utx.FunzioniData.FineDecade(FilePTFCanc.DataRiferimento)

                FilePTFCanc.NomeFile = String.Format("{0}_PTFCAN_{1}_D{2}.zip",
                                                     mRecordConfig.AgenziaCollegata,
                                                     Format(FilePTFCanc.DataRiferimento, "MMyyyy"),
                                                     Utx.FunzioniData.DataToDecade(InizioDecade))

                Globale.Log.Info(String.Format("Creazione file '{0}' dal {1:d} al {2:d}", FilePTFCanc.NomeFile, InizioDecade, FineDecade))
                Dim FileDecade As String = CreaPTFCancDecadale(InizioDecade, FineDecade, FilePTFCanc.NomeFile)

                If FileDecade <> "" Then
                    FilePTFCanc.Init()
                    FilePTFCanc.ScaricaFile(FileDecade)
                    FilePTFCanc.AggiornaCalendarioUtInfo(InizioDecade, FineDecade)

                    File.Delete(FileDecade)
                End If

                'avanza di una decade e ripete il loop
                FilePTFCanc.ProssimoAggiornamento()
            Loop

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        Finally
            Globale.Log.Info()
        End Try
    End Sub

    Private Function CreaPTFCancDecadale(Inizio As Date,
                                         Fine As Date,
                                         NomeFileZip As String) As String
        Try
            'crea le stored in dbuno che potrebbero mancare
            Utx.FunzioniDb.CreaStoredDbUno(mAgenziaFiglia.CodiceAgenziaFiglia)

            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(mAgenziaFiglia.CodiceAgenziaFiglia, Utx.ConnessioniDb.Db.DBUNO))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT CodiceFiscale,Agenzia,Ramo,Polizza,DataEffetto,DataScadenza,Frazionamento,CodiceSubAgente," +
                                             "CodiceProdotto,TotalePremioAnnuo,Targa,Convenzione,IdStorno,DataStorno,ClasseBonusMalus," +
                                             "SettoreTariffario,RamoGestione,ImmatricVeicolo,AgenziaSost,RamoSost,PolizzaSost," +
                                             "AnnoMeseCompetenza,DataElaborazione,B.RamoGestione,ClasseRca " +
                                      "FROM vista_PTFcanc AS A " +
                                      "INNER JOIN  (SELECT * FROM RPolToRGest IN '{0}') AS B ON A.Ramo = B.RamoPolizza " +
                                      "WHERE (DataElaborazione BETWEEN ? AND ?) AND (DataStorno <> NULL)"
                    cmd.CommandText = String.Format(cmd.CommandText, Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.SUPPORTO))
                    cmd.Parameters.AddWithValue("Inizio", Inizio) 'per la data richiesta dalla vista
                    cmd.Parameters.AddWithValue("Inizio", Inizio)
                    cmd.Parameters.AddWithValue("Fine", Fine)

                    Dim dt As DataTable = Utx.FunzioniDb.CreaDataTable(cmd, c)

                    Dim FileCsv As String = String.Format("{0}\{1}.csv",
                                                          Utx.Globale.Paths.CartellaTempUtente,
                                                          Path.GetFileNameWithoutExtension(NomeFileZip))
                    File.Delete(FileCsv)

                    Using sw As New StreamWriter(FileCsv)
                        'riga intestazione compi
                        Dim Riga As String = ""
                        For Each col As DataColumn In dt.Columns
                            Riga += col.ColumnName + ";"
                        Next
                        'tolgo l'ultimo ; e scrivo la riga
                        sw.WriteLine(Riga.Substring(0, Riga.Length - 1))

                        'righe dati se ci sono
                        If dt.Rows.Count > 0 Then
                            'per ciascuna riga
                            For Each dr As DataRow In dt.Rows
                                Riga = ""
                                For k As Integer = 0 To dt.Columns.Count - 1
                                    Riga += Utx.FunzioniDb.NullToString(dr(k)).ToString + ";"
                                Next
                                sw.WriteLine(Riga.Substring(0, Riga.Length - 1))
                            Next
                        End If
                    End Using

                    'zippo il file csv
                    Dim FileZippato As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, NomeFileZip)
                    Utx.LibreriaZip.ZipFile(FileCsv, FileZippato)
                    File.Delete(FileCsv)
                    'restituisco il path
                    Return FileZippato
                End Using
            End Using
            Globale.Log.Info(String.Format("Creazione file {0} completata correttamente", FilePTFCanc.NomeFile))

        Catch ex As Exception
            Globale.Log.Info(String.Format("Errori nella creazione del file {0}", FilePTFCanc.NomeFile))
            Globale.LogErrori.Info(ex)
            Return ""
        End Try
    End Function

    Private Function InizioUltimaDecadeCompleta() As Date
        Try
            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(mAgenziaFiglia.CodiceAgenziaFiglia, Utx.ConnessioniDb.Db.DBUNO))
                c.Open()

                Dim sql As String = "SELECT Max(DataElaborazione) FROM Polizze1 WHERE DataElaborazione < Date()"

                Dim UltimoMovimento As Date = Utx.FunzioniDb.ExecuteScalar(c, sql, #1/1/2000#)
                'restituisco l'inizio della decade precedente a quella in cui cade l'ultimo movimento
                Return Utx.FunzioniData.InizioPrecedenteDecade(UltimoMovimento)
            End Using

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
            Return #1/1/2000#
        End Try
    End Function
End Class
