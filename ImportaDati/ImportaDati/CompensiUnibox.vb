Public Class CompensiUnibox

    Private ReadOnly mAgenziaFiglia As Utx.AgenziaFigliaOmnia
    Private ReadOnly mRecordConfig As Utx.RecordConfigOmnia
    Private FileUBox As FileCasellario

    Sub New(ByRef AgenziaFiglia As Utx.AgenziaFigliaOmnia,
            ByRef RecordConfig As Utx.RecordConfigOmnia)
        mAgenziaFiglia = AgenziaFiglia
        mRecordConfig = RecordConfig
    End Sub

    Public Sub ImportaUBox()
        Try
            FileUBox = New FileCasellario With {
                .AgenziaFiglia = mAgenziaFiglia,
                .RecordConfig = mRecordConfig,
                .TipoFile = Utx.Enumerazioni.TipoFileMagia.UBox,
                .ImportazioneDB = False}
            FileUBox.PrimoAggiornamento()

            Do While FileUBox.DataRiferimento < FileUBox.MaxDataDownload

                If FileUBox.DataRiferimento <= #9/30/2017# Then
                    FileUBox.NomeFile = String.Format("{0}_COMPENSI_UNIBOX_MESE{1}.ZIP", mRecordConfig.AgenziaCollegata, Format(FileUBox.DataRiferimento, "MMyyyy"))
                Else
                    FileUBox.NomeFile = String.Format("{0}_COMPENSI_UNIBOX_{1}.ZIP", mRecordConfig.AgenziaCollegata, Format(FileUBox.DataRiferimento, "yyyyMM"))
                End If

                FileUBox.Init()
                FileUBox.ScaricaFile() 'solo scarico file
                If FileUBox.ErroreCritico = True Then Exit Do

                'avanza di un mese e ripete il loop
                FileUBox.ProssimoAggiornamento()
            Loop

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        Finally
            Globale.Log.Info()
        End Try
    End Sub
End Class
