Imports System.IO

Public Class ArchivioDati

    'archivio solamente su M:
    Private mArchivio As String

    Private mArchivioAgenzia As String
    Private mAgenzia As String

    Sub New(Agenzia As String)
        mAgenzia = Agenzia
        mArchivio = Utx.Globale.Paths.CartellaArchivioDati
        mArchivioAgenzia = Path.Combine(mArchivio, Agenzia)

#If DEBUG Then
        mArchiviazioneAbilitata = Directory.Exists(mArchivio)
#Else
        If Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP Then
            If New DriveInfo("M").IsReady Then
                mArchiviazioneAbilitata = Directory.Exists(mArchivio)
            Else
                mArchiviazioneAbilitata = False
            End If
        Else
                mArchiviazioneAbilitata = Directory.Exists(mArchivio)
        End If
#End If
    End Sub

    Public ReadOnly Property Disponibile() As Boolean
        Get
            Return Directory.Exists(mArchivio)
        End Get
    End Property

    Private mArchiviazioneAbilitata As Boolean
    Public Property ArchiviazioneAbilitata() As Boolean
        Get
            Return mArchiviazioneAbilitata
        End Get
        Set(value As Boolean)
            mArchiviazioneAbilitata = value
        End Set
    End Property

    Friend Function PathArchivioAnno(Anno As Integer,
                                     TipoFile As Utx.Enumerazioni.TipoFileMagia) As String

        Try
            'al path archivio agenzia aggiungo il tipo file (descrizione)
            PathArchivioAnno = Path.Combine(mArchivioAgenzia, TipoFile.ToString)
            'poi aggiungo l'anno
            PathArchivioAnno = Path.Combine(PathArchivioAnno, Anno)

            'se la cartella di archiviazione non esiste la creo
            If TipoFile <> Utx.Enumerazioni.TipoFileMagia.NonCatalogato Then
                Directory.CreateDirectory(PathArchivioAnno)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try

    End Function

    Friend Function PathArchivioAnnoMese(Anno As Integer,
                                         Mese As Integer,
                                         TipoFile As Utx.Enumerazioni.TipoFileMagia) As String
        Try
            'al path archivio agenzia aggiungo il tipo file (descrizione)
            PathArchivioAnnoMese = Path.Combine(Me.PathArchivioAnno(Anno, TipoFile), Mese.ToString.PadLeft(2, "0"))

            'se la cartella di archiviazione non esiste la creo
            If TipoFile <> Utx.Enumerazioni.TipoFileMagia.NonCatalogato Then
                Directory.CreateDirectory(PathArchivioAnnoMese)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Friend Function PathArchivioAnnoMese(DataRiferimento As Date,
                                         TipoFile As Utx.Enumerazioni.TipoFileMagia) As String

        Try
            'al path archivio agenzia aggiungo il tipo file (descrizione)
            PathArchivioAnnoMese = Path.Combine(Me.PathArchivioAnno(DataRiferimento.Year, TipoFile),
                                                DataRiferimento.Month.ToString.PadLeft(2, "0"))

            'se la cartella di archiviazione non esiste la creo
            If TipoFile <> Utx.Enumerazioni.TipoFileMagia.NonCatalogato Then
                Directory.CreateDirectory(PathArchivioAnnoMese)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try

    End Function

    Friend Sub CancellaFileIncassiMese(Anno As Integer, Mese As Integer)
        Try
            Directory.Delete(Me.PathArchivioAnnoMese(Anno, Mese, Utx.Enumerazioni.TipoFileMagia.Incassi), True)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Sub CancellaFileIncassi(InizioPeriodo As Date,
                                   FinePeriodo As Date)
        Try
            Dim Giorno As Date = InizioPeriodo

            Do While Giorno <= FinePeriodo
                File.Delete(FileIncassiArchiviato(Giorno))
                Giorno = Giorno.AddDays(1)
            Loop

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Sub CancellaFileIncassi(Giorno As Date)
        Try
            File.Delete(FileIncassiArchiviato(Giorno))
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Sub ArchiviaFileEsitati(FileTemp As String,
                                   NomeFileCsv As String,
                                   Giorno As Date,
                                   Optional Sovrascrivi As Boolean = False)
        Try
            'file di destinazione zippato
            Dim FileDest As String = Path.Combine(PathArchivioAnnoMese(Giorno.Year, Giorno.Month, Utx.Enumerazioni.TipoFileMagia.Incassi), NomeFileCsv)
            FileDest = Path.ChangeExtension(FileDest, "zip")

            If Sovrascrivi = True Then
                'cancello per sovrascrivere
                File.Delete(FileDest)
            End If

            'rinomino il file e ottengo il nuovo path
            File.Delete(Path.Combine(Directory.GetParent(FileTemp).FullName, NomeFileCsv))
            Dim FileOrigine As String = RinominaFile(FileTemp, NomeFileCsv)

            '+il file del giorno corrente NON deve essere salvato
            If Giorno < Today Then
                'se il file non esiste ancora in archivio
                If File.Exists(FileDest) = False Then
                    'zippo e archivio
                    Utx.LibreriaZip.ZipFile(FileOrigine, FileDest)
                End If
            End If

            'cancello il file csv
            File.Delete(FileOrigine)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Function FileIncassiArchiviato(Giorno As Date) As String
        Return Path.Combine(PathArchivioAnnoMese(Giorno.Year, Giorno.Month,
                                                 Utx.Enumerazioni.TipoFileMagia.Incassi),
                                                 Incassi.NomeFileEsitati(mAgenzia, Giorno, "zip"))
    End Function

    Friend Function RecuperaFileEsitati(Giorno As Date) As String
        Try
            If mArchiviazioneAbilitata = True Then

                'nome e path del file da recuperare
                Dim FileRecuperato As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente,
                                                            Incassi.NomeFileEsitati(mAgenzia, Giorno, "csv"))
                'cancello il file per sicurezza
                File.Delete(FileRecuperato)

                If File.Exists(FileIncassiArchiviato(Giorno)) Then
                    'se esiste il file origine unzippo il file nella cartella temp
                    Utx.LibreriaZip.UnZipFile(FileIncassiArchiviato(Giorno), Utx.Globale.Paths.CartellaTempUtente)
                End If

                If File.Exists(FileRecuperato) Then
                    Return FileRecuperato
                Else
                    Return ""
                End If
            Else
                Return ""
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Friend Function EsisteFileEsitati(Giorno As Date) As Boolean
        Try
            If Me.Disponibile Then
                Return File.Exists(FileIncassiArchiviato(Giorno))
            Else
                Return False
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function


    Public Sub ControlloCompagnia(Compagnia As RichiesteEssig.TipoCompagnia,
                                  Agenzia As String,
                                  ByRef OpzioniScarico As ExportLib.ConfigScaricoIncassi,
                                  e As ExportEventArgs)
        'la sub serve per controllare che non ci siano file con record errati
        'compagnia 4 in unipol e compagnia 1 in unisalute
        Try
            Globale.Log.Info($"Controllo congruità esitati compagnia {Compagnia}")

            Dim UltimoControllo As Date

            Dim Id As String 'la chiave deve contenere il codice agenzia perché su ogni codice va fatto il controllo
            If Compagnia = RichiesteEssig.TipoCompagnia.UNIPOL Then
                Id = Utx.GestioneFlag.TipoFlag.CONTROLLO_COMPAGNIA_UNIPOL.ToString + "_" + Agenzia
            Else
                Id = Utx.GestioneFlag.TipoFlag.CONTROLLO_COMPAGNIA_UNISALUTE.ToString + "_" + Agenzia
            End If

            Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.INTEROP,
                                              Id,
                                              $"{New Date(Today.Year - 1, 1, 1):dd/MM/yyyy}", 'default inizio anno precedente
                                              Utx.SettingOMW.TipoOperazione.LETTURA)

            UltimoControllo = Chiave.ItemResult.Valore

            Dim InizioControllo As Date = Utx.FunzioniData.MinDate(UltimoControllo, OpzioniScarico.InizioPeriodo)
            Dim ProssimoControllo As Date = Today

            Dim Essig As New RichiesteEssig(RichiesteEssig.TipoRichiesta.ESITATI, Compagnia)

            Dim Giorno As Date = InizioControllo
            Dim Progressivo As Integer = 0

            Do While Giorno <= Today
                Dim FileZip As String = FileIncassiArchiviato(Giorno)
                Dim FileDati As String = ""

                Try
                    If File.Exists(FileZip) Then
                        'unzippo il file nella cartella temp
                        FileDati = Path.Combine(Utx.Globale.Paths.CartellaTempUtente,
                                                Utx.LibreriaZip.SevenZip.UnZipFile(FileZip, Utx.Globale.Paths.CartellaTempUtente)(0))

                        Dim Errore As Boolean = False

                        Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                            sr.ReadLine() 'intestazione

                            Do While Not sr.EndOfStream
                                Dim Riga As String = sr.ReadLine

                                If Riga.Split(";")(1) <> Essig.Compagnia Then
                                    Errore = True

                                    If Giorno < ProssimoControllo Then
                                        ProssimoControllo = Giorno
                                    End If

                                    Exit Do
                                End If
                            Loop
                        End Using

                        If Errore = True Then
                            File.Delete(FileZip)
                            Progressivo += 1
                            Globale.Log.Info($"riscontrato errore nel file {FileZip}: ELIMINATO")
                        End If

                        File.Delete(FileDati) 'cancello il file nella cartella temp
                    End If
                Catch ex As Exception
                    Globale.Log.Info(ex.Message)
                    File.Delete(FileZip)
                End Try

                Giorno = Giorno.AddDays(1)
                e.Messaggio = $"Controllo file {Compagnia}: {Giorno:MM/yyyy}"
            Loop

            'modifico le opzioni scarico. inizio eventualmente a scaricare/importare dal primo primo problema trovato
            OpzioniScarico.InizioPeriodo = Utx.FunzioniData.MinDate(ProssimoControllo, OpzioniScarico.InizioPeriodo)
            'elimino la vecchia chiave
            Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Id, "", Utx.SettingOMW.TipoOperazione.CANCELLAZIONE)
            'scrivo la nuova chiave
            Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP,
                           Id,
                           $"{ProssimoControllo:dd/MM/yyyy}",
                           Utx.SettingOMW.TipoOperazione.SCRITTURA_CON_VALORE)

            Globale.Log.Info($"ELIMINATI per la compagnia {Compagnia} {Progressivo} file")
            Globale.Log.Info($"prossimo controllo file per la compagnia {Compagnia} il {ProssimoControllo:dd/MM/yyyy}")

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
