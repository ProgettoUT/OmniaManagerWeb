Imports System.IO

Public Class ManagementFee

    Private ReadOnly mAgenziaFiglia As Utx.AgenziaFigliaOmnia
    Private ReadOnly mRecordConfig As Utx.RecordConfigOmnia
    Private FileMFee As FileCasellario

    Sub New(ByRef AgenziaFiglia As Utx.AgenziaFigliaOmnia,
            ByRef RecordConfig As Utx.RecordConfigOmnia)
        mAgenziaFiglia = AgenziaFiglia
        mRecordConfig = RecordConfig
    End Sub

    Public Sub ImportaMFee()
        Try
            FileMFee = New FileCasellario With {
                .AgenziaFiglia = mAgenziaFiglia,
                .RecordConfig = mRecordConfig,
                .TipoFile = Utx.Enumerazioni.TipoFileMagia.MFee,
                .ImportazioneDB = False}
            FileMFee.PrimoAggiornamento()

            Do While FileMFee.DataRiferimento < FileMFee.MaxDataDownload

                If FileMFee.DataRiferimento <= #12/31/2015# Then
                    FileMFee.NomeFile = String.Format("{0}_Management_Fee_{1}.ZIP",
                                                      mRecordConfig.AgenziaCollegata,
                                                      Format(FileMFee.DataRiferimento, "yyyyMM"))
                Else
                    FileMFee.NomeFile = String.Format("{0}_Management_Fee_{1}.ZIP",
                                                      mRecordConfig.AgenziaCollegata,
                                                      Format(FileMFee.DataRiferimento, "MMyyyy"))
                End If

                FileMFee.Init()
                FileMFee.ScaricaFile()
                If FileMFee.ErroreCritico = True Then Exit Do

                'avanza di un mese e ripete il loop
                FileMFee.ProssimoAggiornamento()
            Loop
            'invio a SIA
            'InviaFileMFeeToSia()

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        Finally
            Globale.Log.Info()
        End Try
    End Sub

    'Public Sub InviaFileMFeeToSia()
    '    If Utx.Tester.TestSiaMA(mAgenziaFiglia.CodiceAgenziaFiglia) Then
    '        Globale.Log.Info("Invio file MFee a SIA")
    '        Globale.Log.Info("Carica lista archivi inviati")
    '        Dim CartellaInviati As String = Path.Combine(mAgenziaFiglia.Cartelle.ArchivioFileInviati, "MFee")
    '        Directory.CreateDirectory(CartellaInviati)

    '        'pulizia
    '        For Each f As String In Directory.GetFiles(CartellaInviati)
    '            If Path.GetFileName(f).Substring(23, 2) < 20 Then
    '                File.Delete(f)
    '            End If
    '        Next
    '        'carico inviati
    '        Dim fileInviati As New List(Of String)
    '        For Each f As String In Directory.GetFiles(CartellaInviati)
    '            fileInviati.Add(Path.GetFileNameWithoutExtension(Path.GetFileName(f)))
    '        Next

    '        Dim Archivio As String = Path.Combine(mAgenziaFiglia.Cartelle.ArchivioDati, "MFee")

    '        For Each f As String In Directory.GetFiles(Archivio, "*_fee_*.zip", SearchOption.AllDirectories)
    '            Dim NomeNormalizzato As String = Path.GetFileNameWithoutExtension(f)
    '            'vecchia nomenclatura da cambiare yyyyMM >> MMyyyy
    '            If NomeNormalizzato.Substring(23, 2) < 20 Then
    '                NomeNormalizzato = NomeNormalizzato.Substring(0, 21) & NomeNormalizzato.Substring(25, 2) & NomeNormalizzato.Substring(21, 4) & ".zip"
    '            End If

    '            If Not fileInviati.Contains(NomeNormalizzato) Then
    '                'cambio il file perché è un exe autoestraente e lo trasformo in zip vero (per problemi di sicurezza)
    '                Dim FileCsv As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente,
    '                                                     Utx.LibreriaZip.SevenZip.UnZipFile(f, Utx.Globale.Paths.CartellaTempUtente)(0))

    '                NomeNormalizzato = Path.ChangeExtension(NomeNormalizzato, "csv") 'da zip a csv

    '                If Path.GetFileName(FileCsv) <> NomeNormalizzato Then
    '                    My.Computer.FileSystem.RenameFile(FileCsv, NomeNormalizzato)
    '                    FileCsv = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, NomeNormalizzato)
    '                End If

    '                Dim FileZip As String = Path.ChangeExtension(FileCsv, "zip")
    '                Utx.LibreriaZip.SevenZip.ZipFile(FileCsv, FileZip)

    '                Globale.Log.Info("Invio file: " & Path.GetFileName(FileZip))
    '                If Utx.SIA.InviaFileMFee(FileZip) = True Then
    '                    Globale.Log.Info("Invio completato correttamente")
    '                    'scrivo il file flag nella cartella degli inviati
    '                    My.Computer.FileSystem.WriteAllText(Path.Combine(CartellaInviati, Path.GetFileName(FileZip)), Now.ToString, False)
    '                Else
    '                    Globale.Log.Info("Invio file '{0}' non riuscito", {FileZip})
    '                End If
    '                File.Delete(FileCsv)
    '                File.Delete(FileZip)
    '            End If
    '        Next
    '    End If
    'End Sub
End Class
