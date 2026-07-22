Imports System.IO
Imports System.Data.OleDb

Public Class BusteDecadi

    Private ReadOnly mAgenziaFiglia As Utx.AgenziaFigliaOmnia
    Private ReadOnly mRecordConfig As Utx.RecordConfigOmnia
    Private FileBusta As DocCasellario

    Sub New(ByRef AgenziaFiglia As Utx.AgenziaFigliaOmnia,
            ByRef RecordConfig As Utx.RecordConfigOmnia)
        mAgenziaFiglia = AgenziaFiglia
        mRecordConfig = RecordConfig
    End Sub

    Friend Sub ImportaBuste()
        Try
            'per ciascuna tipologia di doc nella tabella liste
            For Each dr As DataRow In mAgenziaFiglia.TabellaListe.Rows

                'se è una busta
                If dr("TipoDoc") = Utx.Enumerazioni.TipoFileDoc.BUSTE Then

                    FileBusta = New DocCasellario With {
                        .AgenziaFiglia = mAgenziaFiglia,
                        .RecordConfig = mRecordConfig,
                        .TipoFile = Utx.Enumerazioni.TipoFileDoc.BUSTE,
                        .CodiceDoc = dr("CodiceDoc"),
                        .ImportazioneDB = True}
                    FileBusta.PrimoAggiornamento()

                    Do While FileBusta.DataRiferimento <= FileBusta.MaxDataDownload
                        'nome del file da scaricare: tipo 02379_RCA_SINGOLE_DECADE_D2_05_2015
                        FileBusta.NomeFile = String.Format("{0}{1}{2}_{3}.ZIP",
                                                           mRecordConfig.AgenziaCollegata,
                                                           dr("NomeBase"),
                                                           Utx.FunzioniData.DataToDecade(FileBusta.DataRiferimento),
                                                           Format(Utx.FunzioniData.InizioDecade(FileBusta.DataRiferimento), "MM_yyyy"))
                        FileBusta.Init()
                        FileBusta.ScaricaFile()
                        If FileBusta.ErroreCritico = True Then Exit Try

                        If mAgenziaFiglia.SoloScaricoFile = False Then
                            'se non siamo in modalità creazione archivio e il file è disponibile importo
                            If FileBusta.FileDisponibile = True Then
                                If Importa(dr("CodiceDoc")) = True Then
                                    'se importazione ok aggiorno calendario doc in arrivi
                                    FileBusta.AggiornaCalendarioDocArrivi(Utx.FunzioniData.InizioDecade(FileBusta.DataRiferimento),
                                                                          Utx.FunzioniData.FineDecade(FileBusta.DataRiferimento))
                                End If
                            End If
                        End If
                        'avanza alla decade successiva e ripete il loop
                        FileBusta.ProssimoAggiornamento()
                    Loop
                    Globale.Log.Info()
                End If
            Next

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        Finally
            Globale.Log.Info()
        End Try
    End Sub

    Private Function Importa(CodiceBusta As Integer) As Boolean
        Try
            Globale.Log.Info(">>> Importa busta")

            Dim TipoBusta As String = ""
            Select Case CodiceBusta
                Case 1 : TipoBusta = "RcaSing"
                Case 2 : TipoBusta = "RcaCum"
                Case 3 : TipoBusta = "RamiEle"
                Case 4 : TipoBusta = "Cauzioni"
                Case 5 : TipoBusta = "RiAssi"
            End Select

            Using sr As New StreamReader(FileBusta.FileScaricato, System.Text.Encoding.Default)

                Dim da As New OleDbDataAdapter("SELECT * FROM Buste WHERE False", mAgenziaFiglia.Connessione)
                Dim cmdBuilder As New OleDbCommandBuilder(da)
                da.InsertCommand = cmdBuilder.GetInsertCommand

                Dim dt As New DataTable
                da.Fill(dt)

                'leggo intestazione
                sr.ReadLine()

                Do While Not sr.EndOfStream

                    Dim Riga As String = sr.ReadLine

                    'nel caso ci sia un'ultima riga vuota
                    If Riga.Trim.Length = 0 Then
                        Exit Do
                    End If

                    Dim Campi() As String = Riga.Split(";")
                    TrimArray(Campi)

                    If mRecordConfig.ConsensoImportazione(Campi(13)) = True Then

                        Dim dr As DataRow = dt.NewRow

                        dr("Inviato") = False
                        dr("DataBusta") = DBNull.Value
                        dr("TipoBusta") = TipoBusta
                        dr("Agenzia") = Campi(0)
                        dr("Ramo") = Campi(2)
                        dr("Polizza") = Campi(3)
                        dr("CodiceFiscale") = Campi(4)
                        dr("Contraente") = Left(Campi(5), 40)
                        dr("Appendice") = Campi(6)
                        dr("EffettoAppendice") = Campi(7).Replace(".", "/")
                        dr("EffettoTitolo") = Campi(8).Replace(".", "/")
                        dr("TipoCarico") = Campi(9)
                        dr("DataFoglioCassa") = Campi(10).Replace(".", "/")
                        dr("Esito") = ""
                        dr("TotaleTitolo") = 0
                        dr("Archivio") = Campi(11)
                        dr("Prodotto") = Campi(12)
                        dr("SubAgenzia") = Campi(13)
                        dr("Stampato") = Campi(14)
                        dr("Targa") = Right(Campi(15), 9)
                        dr("RamoGestione") = 0
                        dr("Nota") = ""

                        dt.Rows.Add(dr)
                    End If
                Loop

                da.Update(dt)

                Globale.Log.Info(String.Format("Record importati: {0}", dt.Rows.Count))

                dt.Dispose()
                cmdBuilder.Dispose()
                da.Dispose()
            End Using

            Return True

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
            Return False
        End Try
    End Function
End Class
