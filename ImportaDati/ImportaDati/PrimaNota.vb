Imports System.IO
Imports System.Data.OleDb

Public Class PrimaNota

    Private ReadOnly mAgenziaFiglia As Utx.AgenziaFigliaOmnia
    Private ReadOnly mRecordConfig As Utx.RecordConfigOmnia
    Private WithEvents FilePN As FileCasellario

    Sub New(ByRef AgenziaFiglia As Utx.AgenziaFigliaOmnia,
            ByRef RecordConfig As Utx.RecordConfigOmnia)
        mAgenziaFiglia = AgenziaFiglia
        mRecordConfig = RecordConfig
    End Sub

    Public Sub ImportaPrimaNota()
        Try
            FilePN = New FileCasellario With {
                .AgenziaFiglia = mAgenziaFiglia,
                .RecordConfig = mRecordConfig,
                .TipoFile = Utx.Enumerazioni.TipoFileMagia.PrimaNota,
                .ImportazioneDB = False}
            FilePN.PrimoAggiornamento()

            'per l'aggiornamento del calendario
            Dim AggiornoCalendario As Boolean = False
            Dim DataCalendario As Date
            Dim FileCalendario As String = ""

            Do While FilePN.DataRiferimento <= FilePN.MaxDataDownload
                FilePN.NomeFile = String.Format("{0}_PNOTA_{1}.ZIP",
                                                mRecordConfig.AgenziaCollegata,
                                                Format(FilePN.DataRiferimento, "yyyyMMdd"))
                FilePN.Init()
                FilePN.ScaricaFile()
                If FilePN.ErroreCritico = True Then Exit Try

                If mAgenziaFiglia.SoloScaricoFile = False Then
                    'se non siamo in modalità creazione archivio e il file è disponibile importo
                    If FilePN.FileDisponibile = True Then
                        'conservo nel calendario solo il riferimento all'ultimo scaricato
                        AggiornoCalendario = True
                        DataCalendario = FilePN.DataRiferimento
                        FileCalendario = FilePN.NomeFile
                    End If
                End If
                'importante per tenere la cartella vuota
                SvuotaCartella(mAgenziaFiglia.Cartelle.CartellaArriviLocaleTempDL)
                'avanzo di un giorno e ripeto
                FilePN.ProssimoAggiornamento()
            Loop

            'invio file a SIA - 15 giorni per trasmettere l'ultima prima nota
            'If Today < FilePN.MaxDataDownload.AddDays(15) Then
            '    If mAgenziaFiglia.ConfigUnicont.AbilitazioneSIA = True Then
            '        Dim NumeroMA As Integer = Utx.SIA.ListaFileInviati(mAgenziaFiglia.CodiceAgenziaFiglia, Today.AddMonths(-1), Today, Utx.SIA.TipoFiltro.INIZIA, "MA").Length
            '        If NumeroMA = 0 Then
            '            InviaFile2Sia()
            '        Else
            '            Globale.Log.Info("Agenzia passata a MA " & NumeroMA.ToString)
            '        End If
            '    Else
            '        Globale.Log.Info("Agenzia non abilitata a UNICONT")
            '    End If
            'End If

            ''invio a TTY - bloccato il 7/2/2018
            'If mAgenziaFiglia.CodiceAgenziaFiglia = "00000" Then
            '    InviaPNotaTTYCreo()
            '    InviaPNotaEssigTTYCreo()
            'End If

            'aggiorno calendario
            If AggiornoCalendario = True Then
                FilePN.AggiornaCalendarioUtInfo(DataCalendario,
                                                DataCalendario,
                                                SoloUltimoAggiornamento:=True)
            End If

            Globale.Log.Info()

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Invia i file di prima nota a Unicont
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InviaFile2Sia()
#If DEBUG Then
        'Exit Sub
#End If
        Try
            'la data di invio a cui si fa riferimento è sempre quella della figlia e non delle collegate alla figlia
            Globale.Log.Info("Invio file di prima nota a UNICONT")
            Globale.Log.Info(String.Format("Data ultima prima nota inviata ({0}): {1:d}",
                                           mAgenziaFiglia.CodiceAgenziaFiglia,
                                           mAgenziaFiglia.ConfigUnicont.DataUltimoInvioSia))

            'data inizio e fine dell'invio a SIA
            Dim DataInizio As Date = Utx.FunzioniData.MaxDate(mAgenziaFiglia.ConfigUnicont.DataInizio,
                                                              mAgenziaFiglia.ConfigUnicont.DataUltimoInvioSia).AddDays(1)
            Dim DataFine As Date = Utx.FunzioniData.MinDate(Utx.FunzioniData.Ieri, mAgenziaFiglia.ConfigUnicont.DataFine)
#If DEBUG Then
            'DataInizio = #12/30/2018#
#End If
            'per la notifica
            Dim NotificaPN As Boolean = False
            Dim DataNotifica As Date

            FilePN.ImportazioneDB = True 'mi serve per recuperare il file dall'archivio

            Dim Giorno As Date = DataInizio

            Do While Giorno <= DataFine
                FilePN.NomeFile = String.Format("{0}_PNOTA_{1}.zip",
                                                mRecordConfig.AgenziaCollegata,
                                                Format(Giorno, "yyyyMMdd"))
                Globale.Log.Trace(String.Format("Nome file: {0}", FilePN.NomeFile))

                'ATTENZIONE:
                'poichè il file lo devo passare a Sia in formato csv mi conviene utilizzare
                'la funzione ScaricaFile che me lo recupera da M: e lo unzippa
                FilePN.DataRiferimento = Giorno
                FilePN.Init()
                FilePN.ScaricaFile()
                Globale.Log.Trace(String.Format("File scaricato: {0}", FilePN.FileScaricato))
                Globale.Log.Trace(String.Format("File disponibile: {0}", FilePN.FileDisponibile))

                If FilePN.FileDisponibile = True Then
                    Dim Esito As String = Utx.SIA.InviaFilePN(FilePN.FileScaricato)
                    Globale.Log.Info(Esito)

                    If Esito.StartsWith("+OK") Then
                        NotificaPN = True
                        DataNotifica = Giorno
                    Else
                        'dopo l'errore interrompo il ciclo
                        Globale.LogErrori.Info("Si è verificato un errore nell'invio del file a SIA. Procedura interrotta.")
                        Globale.LogErrori.Info("Esito: {0}", {Esito})
                        Exit Do
                    End If
                End If
                'avanzo di un giorno
                Giorno = Giorno.AddDays(1)
                Globale.Log.Trace(String.Format("Avanzo di un giorno: {0}", Giorno))
            Loop

            If NotificaPN = True Then
                Globale.IconaNotifica.ShowBalloonTip(30000,
                                                     "Prima nota",
                                                     "Inviati file prima nota fino al " + Format(DataNotifica, "dd-MM-yyyy"),
                                                     ToolTipIcon.Info)
            End If

            Globale.Log.Info()

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    Private Sub InviaPNotaTTYCreo()
        Try
            'scarico e archivio i file
            Dim TTY As New Utx.TTYCreo(Utx.TTYCreo.TipoFile.PRIMA_NOTA)
            'data inizio
            Dim Inizio As Date = TTY.InizioInvioPNota

            'la data di invio a cui si fa riferimento è sempre quella della figlia e non delle collegate alla figlia
            Globale.Log.Info("Invio file di prima nota Essig a TTYCreo")
            Globale.Log.Info(String.Format("Inizio invio prima nota ({0}): {1:d}", mAgenziaFiglia.CodiceAgenziaFiglia, Inizio))

            Dim Archivio As New Utx.CartelleArchivioDati(mAgenziaFiglia.CodiceAgenziaFiglia)

            For Anno As Integer = Inizio.Year To Today.Year
                'per tutti i file dell'archivio prima nota dell'anno
                For Each f As String In Directory.GetFiles(Archivio.PrimaNota(Anno), "?????_PNOTA_????????.zip")
                    'se la data è maggiore o uguale alla data di inizio
                    If Date.ParseExact(Path.GetFileName(f).Substring(12, 8), "yyyyMMdd", Nothing) >= Inizio Then
                        'aggiungo il file alla lista di upload
                        TTY.ListaUpload.Add(f)
                    End If
                Next
            Next

            'invio i file
            TTY.Upload()

            Globale.Log.Info()

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    'Private Sub InviaPNotaEssigTTYCreo()
    '    Try
    '        Globale.Log.Info("Invio file di prima nota Essig a TTYCreo")

    '        'scarico e archivio i file
    '        Dim TTY As New Utx.TTYCreo(Utx.TTYCreo.TipoFile.PRIMA_NOTA_ESSIG)
    '        'data inizio
    '        Dim Inizio As Date = TTY.InizioInvioPNotaEssig

    '        'la data di invio a cui si fa riferimento è sempre quella della figlia e non delle collegate alla figlia
    '        Globale.Log.Info(String.Format("Inizio scarico e invio prima nota ({0}): {1:d}", mAgenziaFiglia.CodiceAgenziaFiglia, Inizio))

    '        Dim az As New ExportLib.Azioni
    '        If az.LoginSenzaNotifica = True Then
    '            Try
    '                az.AggiornaPNotaEssig(Inizio)
    '            Catch ex As Exception
    '                Utx.Globale.Log.Errore(ex)
    '            End Try
    '        End If

    '        Dim Archivio As New Utx.CartelleArchivioDati(mAgenziaFiglia.CodiceAgenziaFiglia)

    '        For Anno As Integer = Inizio.Year To Today.Year
    '            'per tutti i file dell'archivio prima nota dell'anno
    '            For Each f As String In Directory.GetFiles(Archivio.PrimaNota(Anno), "?????_PNOTA_ESSIG_????????.zip")
    '                'se la data è maggiore o uguale alla data di inizio
    '                If Date.ParseExact(Path.GetFileName(f).Substring(18, 8), "yyyyMMdd", Nothing) >= Inizio Then
    '                    'aggiungo il file alla lista di upload
    '                    TTY.ListaUpload.Add(f)
    '                End If
    '            Next
    '        Next

    '        'invio i file
    '        TTY.Upload()

    '        Globale.Log.Info()

    '    Catch ex As Exception
    '        Globale.LogErrori.Info(ex)
    '    End Try
    'End Sub
End Class
