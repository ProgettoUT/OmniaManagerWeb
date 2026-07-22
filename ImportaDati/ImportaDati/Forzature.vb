Public Class Forzature

    Private mAgenziaFiglia As Utx.AgenziaFigliaOmnia
    Private mRecordConfig As Utx.RecordConfigOmnia
    Private FileFZ As FileCasellario

    Sub New(ByRef AgenziaFiglia As Utx.AgenziaFigliaOmnia,
            ByRef RecordConfig As Utx.RecordConfigOmnia)
        mAgenziaFiglia = AgenziaFiglia
        mRecordConfig = RecordConfig
    End Sub

    Friend Sub ImportaForzature()
        Try
            Globale.Log.Info("Inizio forzature")
            Globale.Log.Info(String.Format("File in forzatura: {0}", mAgenziaFiglia.TabellaForzature.Rows.Count))

            FileFZ = New FileCasellario()
            FileFZ.AgenziaFiglia = mAgenziaFiglia
            FileFZ.RecordConfig = mRecordConfig

            For Each dr As DataRow In mAgenziaFiglia.TabellaForzature.Rows
                'se il tipo file è gestito
                If FileCasellario.TipoFileGestito(dr("TipoFile")) Then
                    'costruiamo il nome del file sostituendo il tag agenzia
                    Dim NomeFile As String = Replace(dr("NomeFile"), "#agenzia#", mRecordConfig.AgenziaCollegata, , , CompareMethod.Text)

                    Globale.Log.Info(String.Format("Tipo: {0} - File: {1} - Data inizio: {2:d}",
                                                     dr("TipoFile"),
                                                     NomeFile,
                                                     dr("DataInizio")))

                    'controllo le date per vedere se già ricevuto
                    Dim DataRicezione As Date = FileCasellario.DataRicezioneFile(mAgenziaFiglia.ConnectionStringDbInfo, NomeFile)

                    If DataRicezione < dr("DataInizio") Then

                        'controllo se già scaricato in questa sessione
                        If Not FileCasellario.FileGiaScaricato(NomeFile, mAgenziaFiglia.Connessione) Then

                            FileFZ.TipoFile = dr("TipoFile")
                            FileFZ.NomeFile = NomeFile
                            FileFZ.Init()
                            FileFZ.ScaricaFile()

                            If FileFZ.ErroreCritico = True Then Exit For

                            If FileFZ.FileDisponibile = True Then
                                Select Case dr("TipoFile")
                                    Case Utx.Enumerazioni.TipoFileMagia.SinistriBase
                                        SinistriAIA.ImportaSinistriBase(FileFZ.FileScaricato, dr("AnnoCompetenza"), mAgenziaFiglia.Connessione)
                                End Select
                            End If
                        End If
                    Else
                        Globale.Log.Info("File già importato il " + DataRicezione.ToShortDateString)
                    End If
                End If
            Next

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        Finally
            Globale.Log.Info()
        End Try
    End Sub
End Class
