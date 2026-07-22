Imports System.IO
Imports System.Data.OleDb
Imports System.Globalization

Module Clienti

#Region "Dichiarazioni"
    Dim LunCampo() As Integer = {21, 16, 1, 16, 16, 40, 25, 10, 35, 5, 30, 5, 5, _
                                 21, 2, 14, 14, 1, 1, 10, 5, 2, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, _
                                 3, 3, 2, 3, 10, 10, 5, 5, 5, 10, 10, 4, 4, 8, 4, 8, 8, 4, 8, 8, _
                                 4, 8, 2, 6, 50, 14, 14, 14, 40, 14, 1, 6, 6, 1}
    Private ListaCF As New ArrayList
#End Region

    Private Function EstraiCampi(ByVal Riga1 As String,
                                 ByVal Riga2 As String,
                                 ByRef cmd As OleDbCommand) As Boolean

        Dim Campo(LunCampo.Length) As String
        Dim Riga As String = ""

        Try
            Riga = Riga1.Substring(0, 225) + Riga2

            'sostituisco le virgolette con uno spazio perchè danno fastidio nelle query
            'uso lo spazio per non alterare la posizione dei campi
            Riga = Replace(Riga, Chr(34), Chr(32), , , CompareMethod.Text)

            'estrae le sottostringhe trimmandole e mettendole nella matrice
            SplitTesto(Riga, 0, LunCampo, Campo)

            'controllo se il cf è vuoto
            If Campo(1).Trim = "" Then Return True

            'controllo se il cf è già stato importato
            If ListaCF.Contains(Campo(1)) = True Then Return True

            'produttore e sub sono di 5 caratteri così tolgo il primo
            Campo(40) = Campo(40).Substring(1)
            Campo(20) = Campo(20).Substring(1)

            'valuta i codici sub, prod e prevalente se impostati
            If FiguraRichiesta(Campo(40), Campo(20), Campo(39)) = False Then Return True

            With cmd.Parameters
                .Clear()

                'il campo 0 è l'intestazione (a sinistra) della prima riga
                .AddWithValue("CodiceFiscale", Campo(1))
                .AddWithValue("Cognome", Campo(5))
                .AddWithValue("Nome", Campo(6))
                .AddWithValue("DataNascita", DataITA(Campo(7)))
                .AddWithValue("Indirizzo", Campo(8))
                .AddWithValue("Cap", CInt(Campo(9)))
                .AddWithValue("Localita", Campo(10))
                .AddWithValue("ComuneCAB", CInt(Campo(11)))
                .AddWithValue("StatoCab", Campo(12))
                'il campo 13 è l'intestazione (a sinistra) della seconda riga
                .AddWithValue("Provincia", Campo(14))
                .AddWithValue("Telefono1", Campo(15))
                .AddWithValue("Telefono2", Campo(16))
                .AddWithValue("Sesso", Campo(17))
                .AddWithValue("Capofamiglia", Campo(2))
                .AddWithValue("CodiceFiscaleCF", Campo(3)) 'capofamiglia
                .AddWithValue("CodiceFiscaleEA", Campo(4)) 'ente di appartenenza
                .AddWithValue("ClienteTop", Campo(18))
                .AddWithValue("DataTop", DataITA(Campo(19)))
                .AddWithValue("Produttore", CInt(Campo(20)))
                .AddWithValue("StatoCivile", Campo(21))
                .AddWithValue("NucleoFamiliare", Campo(22))
                .AddWithValue("PrimaCasa", Campo(23))
                .AddWithValue("AltriImmobili", Campo(24))
                .AddWithValue("TitoliStato", Campo(25))
                .AddWithValue("FasciaReddito", Campo(26))
                .AddWithValue("Sindacati", Campo(27))
                .AddWithValue("PolizzeAltreComp", Campo(28))
                .AddWithValue("CartaCredito", Campo(29))
                .AddWithValue("EsclusioneAttivita", Campo(30))
                .AddWithValue("Ente", Campo(31))
                .AddWithValue("TipoCliente", CInt(Campo(32)))
                .AddWithValue("IDSegmentoCorrente", Campo(33))
                .AddWithValue("IDSegmentoPrecedente", CInt(Campo(34)))
                .AddWithValue("IDStatoCliente", Campo(35))
                .AddWithValue("IDZona", CInt(Campo(36)))
                .AddWithValue("DataInserimento", DataITA(Campo(37)))
                .AddWithValue("DataCessazione", DataITA(Campo(38)))
                .AddWithValue("AgenziaPrevalente", CInt(Campo(39)))
                .AddWithValue("SubAgenzia", CInt(Campo(40)))
                .AddWithValue("SubAgenziaSIMA", CInt(Campo(41)))
                .AddWithValue("DataUltimaVisita", DataITA(Campo(42)))
                .AddWithValue("DataProssimaVisita", DataITA(Campo(43)))
                .AddWithValue("PolizzeVigore", CInt(Campo(44)))
                .AddWithValue("PolizzeStoriche", CInt(Campo(45)))
                .AddWithValue("PremiCorrente", CDbl(Campo(46)))
                .AddWithValue("SinistriCorrente", CInt(Campo(47)))
                .AddWithValue("LiquidatoCorrente", CDbl(Campo(48)))
                .AddWithValue("PremiPrecedente", CDbl(Campo(49)))
                .AddWithValue("SinistriPrecedente", CInt(Campo(50)))
                .AddWithValue("LiquidatoPrecedente", CDbl(Campo(51)))
                .AddWithValue("PremiTotale", CDbl(Campo(52)))
                .AddWithValue("SinistriTotale", CInt(Campo(53)))
                .AddWithValue("LiquidatoTotale", CDbl(Campo(54)))
                .AddWithValue("ConsensoPrivacy", Campo(55))
                .AddWithValue("RilascioPatente", Campo(56))
                .AddWithValue("Email", Campo(57))
                .AddWithValue("Fax", Campo(58))
                .AddWithValue("Cellulare", Campo(59))
                .AddWithValue("TelReferente", Campo(60))
                .AddWithValue("NomeReferente", Campo(61))
                .AddWithValue("TelAziendale", Campo(62))
                .AddWithValue("CodAvvisoScadenza", Campo(63))
                .AddWithValue("AnnoMeseInizioEsclTemp", Campo(64))
                .AddWithValue("AnnoMeseFineEsclTemp", Campo(65))
                .AddWithValue("CodModalitaIncasso", Campo(66))
                .AddWithValue("Flag1", False)
                .AddWithValue("Flag2", False)
                .AddWithValue("Flag3", False)
                .AddWithValue("RisTelefono", "")
                .AddWithValue("RisCellulare", "")
                .AddWithValue("RisMail", "")
                .AddWithValue("RisTelefonoNota", "")
                .AddWithValue("RisCellulareNota", "")
                .AddWithValue("RisMailNota", "")
            End With

            cmd.ExecuteNonQuery()

            'aggiungo il cf alla lista degli importati
            ListaCF.Add(Campo(1))

            Return True

        Catch ex As Exception
            BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
            Return False
        End Try

    End Function

    Friend Function ImportaClienti(ByVal FileDati As String) As Boolean

        IconaNotifica.Text = String.Format("Unitools: {0}importa clienti...", Environment.NewLine)
        AddLog(">>> Clienti")

        Try
            Using cmd As New OleDbCommand

                cmd.Connection = cnArrivi

                'inizializzo command builder
                Using da As New OleDbDataAdapter("SELECT * FROM Clienti WHERE False", cnArrivi)

                    Using cmdBuilder As New OleDbCommandBuilder(da)

                        'creo la stored procedure
                        Try
                            cmd.CommandType = CommandType.Text
                            cmd.CommandText = "Create Procedure InsClienti As " + cmdBuilder.GetInsertCommand.CommandText
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception
                            'la stored c'è già
                        End Try
                    End Using
                End Using

                'imposto il cmd per l'esecuzione della stored
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "InsClienti"

                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                    'legge la prima riga con la data del pacco
                    Dim DataPacco As Date = CDate(sr.ReadLine.Substring(38, 10))
                    Dim DataInizio As Date = DataInizioMese(DataPacco.AddMonths(-1))
                    Dim DataFine As Date = DataFineMese(DataInizio)

                    Dim IDSezione As String = "CLIENTISETUP"
                    Dim NumeroRecord As Integer = TrovaSezione(sr, IDSezione)

                    ListaCF.Clear()

                    For k As Integer = 1 To NumeroRecord
                        If EstraiCampi(sr.ReadLine, sr.ReadLine, cmd) = False Then Throw New System.Exception
                        Application.DoEvents()
                    Next

                    AggiornaCalendarioUt(Glo.Impo.CodAgenzia, _
                                         TipoFileMagia.Anag, _
                                         DataInizio, _
                                         DataFine, _
                                         FileDati)
                End Using
            End Using

            ImportaClienti = True

        Catch ex As Exception
            BoxErrore(ex)
            SvuotaTabella(TipoFileMagia.Anag)
            ImportaClienti = False
        End Try

    End Function

    Friend Function TrovaSezione(ByVal sr As StreamReader, ByVal ID As String) As Integer
        Dim Riga As String = ""
        Do While Not sr.EndOfStream
            Riga = sr.ReadLine
            If Riga.Contains(ID) Then Return CInt(Riga.Substring(15, 6))
        Loop
    End Function

    'Private Sub EliminaClientiDuplicati()

    '    Try
    '        Dim Eliminati As Integer = 0

    '        Using cmd As New OleDb.OleDbCommand

    '            cmd.Connection = cnArrivi
    '            cmd.CommandType = CommandType.Text

    '            'tolgo poi i doppioni con la data inserimento inferiore
    '            cmd.CommandText = "DELETE DISTINCTROW A.* " +
    '                              "FROM Clienti AS A " +
    '                              "INNER JOIN (SELECT Count(*),Max(DataInserimento) AS DataIns,CodiceFiscale " +
    '                                          "FROM Clienti " +
    '                                          "GROUP BY CodiceFiscale " +
    '                                          "HAVING Count(*) > 1) AS B " +
    '                              "ON A.CodiceFiscale = B.CodiceFiscale " +
    '                              "WHERE A.DataInserimento < B.DataIns"
    '            Eliminati = cmd.ExecuteNonQuery()

    '            'tolgo prima i doppioni con lo stato cliente minore (tipo AA)
    '            cmd.CommandText = "DELETE DISTINCTROW A.* " +
    '                              "FROM Clienti AS A " +
    '                              "INNER JOIN (SELECT Count(*),Max(IdStatoCliente) AS ID,CodiceFiscale " +
    '                                          "FROM Clienti " +
    '                                          "GROUP BY CodiceFiscale " +
    '                                          "HAVING Count(*) > 1) AS B " +
    '                              "ON A.CodiceFiscale = B.CodiceFiscale " +
    '                              "WHERE A.IdStatoCliente < B.ID"
    '            Eliminati += cmd.ExecuteNonQuery()

    '            'tolgo poi i doppioni con l'agenzia prevalente inferiore (spesso a zero)
    '            cmd.CommandText = "DELETE DISTINCTROW A.* " +
    '                              "FROM Clienti AS A " +
    '                              "INNER JOIN (SELECT Count(*),Max(AgenziaPrevalente) AS AP,CodiceFiscale " +
    '                                          "FROM Clienti " +
    '                                          "GROUP BY CodiceFiscale " +
    '                                          "HAVING Count(*) > 1) AS B " +
    '                              "ON A.CodiceFiscale = B.CodiceFiscale " +
    '                              "WHERE A.AgenziaPrevalente < B.AP"
    '            Eliminati += cmd.ExecuteNonQuery()

    '            'elimino tutti i doppioni rimanenti perdendo i record clienti
    '            cmd.CommandText = "DELETE DISTINCTROW A.* " +
    '                              "FROM Clienti AS A " +
    '                              "INNER JOIN (SELECT Count(*),CodiceFiscale " +
    '                                          "FROM Clienti " +
    '                                          "GROUP BY CodiceFiscale " +
    '                                          "HAVING Count(*) > 1) AS B " +
    '                              "ON A.CodiceFiscale = B.CodiceFiscale"
    '            Eliminati += cmd.ExecuteNonQuery()

    '            If Eliminati > 0 Then
    '                AddLog(String.Format("*** Eliminati {0} clienti duplicati", Eliminati))
    '            End If
    '        End Using

    '    Catch ex As Exception
    '        BoxErrore(ex)
    '    End Try

    'End Sub

#Region "Storico"

    Friend Sub CreaStoricoClienti()

        Try
            Dim ArchivioAnag As String = Path.Combine(Glo.PathArchivioDatiAgenzia, "Anag")

            If File.Exists(Path.Combine(ArchivioAnag, "Storico.OK")) Then
                Exit Sub 'lo storico già esiste
            End If

            AddLog(">>>Creo storico clienti", True)

            'file SIMA presenti in archivio
            Dim FileSima() As String = Directory.GetFiles(ArchivioAnag, "*_sima_*.*", IO.SearchOption.AllDirectories)

            'li ordino in modo decrescente
            Dim Compare As New DateComparer(DateComparer.Ordinamento.DECRESCENTE)
            Array.Sort(FileSima, Compare)

            'cartella temp di appoggio dedicata allo storico per non interferire con l'importazione corrente
            Dim CartellaUnzip As String = Path.Combine(Glo.UTCartellaTemp, "Unzip\Storico")

            If FileSima.GetUpperBound(0) > 0 Then

                'salto il file di indice 0 (il più recente) perchè è stato appena importato
                For k As Integer = 1 To FileSima.GetUpperBound(0)

                    AddLog(Path.GetFileNameWithoutExtension(FileSima(k)))

                    Dim FileDati As String = UnzipFile(Path.GetFileName(FileSima(k)), FileSima(k), "M:", CartellaUnzip)

                    If File.Exists(FileDati) Then
                        'questo esclude eventuali decompressioni fallite (-ERR:100)
                        ImportaClientiStorico(FileDati)
                        File.Delete(FileDati)
                    Else
                        AddLog("Errore nella decompressione del file")
                    End If
                Next

                'cancello la cartella di appoggio per unzip
                Directory.Delete(CartellaUnzip, True)
            End If

            'scrivo il flag di controllo
            File.WriteAllText(Path.Combine(ArchivioAnag, "Storico.OK"), Now)

        Catch ex As Exception
            BoxErrore(ex)
        End Try
    End Sub

    Private Class DateComparer
        Implements System.Collections.IComparer

        Friend Enum Ordinamento
            CRESCENTE = 0
            DECRESCENTE = 1
        End Enum

        Private mOrdinamento As Ordinamento

        Sub New(ByVal TipoOrdinamento As Ordinamento)
            mOrdinamento = TipoOrdinamento
        End Sub

        Public Function Compare(ByVal File1 As Object,
                                ByVal File2 As Object) As Integer Implements System.Collections.IComparer.Compare

            'confronta 2 file sima prendendo la data dal nome file
            File1 = Path.GetFileNameWithoutExtension(File1)
            File2 = Path.GetFileNameWithoutExtension(File2)

            Dim Mese1 As Integer = DateTime.ParseExact(File1.Split("_")(2), "MMMM", CultureInfo.CurrentCulture).Month
            Dim Anno1 As Integer = File1.Split("_")(3)
            Dim Data1 As Date = New DateTime(Anno1, Mese1, 1)

            Dim Mese2 As Integer = DateTime.ParseExact(File2.Split("_")(2), "MMMM", CultureInfo.CurrentCulture).Month
            Dim Anno2 As Integer = File2.Split("_")(3)
            Dim Data2 As Date = New DateTime(Anno2, Mese2, 1)

            If mOrdinamento = Ordinamento.CRESCENTE Then

                If Data1 >= Data2 Then
                    Return 1
                ElseIf Data1 < Data2 Then
                    Return -1
                Else
                    Return 0
                End If
            Else
                If Data1 <= Data2 Then
                    Return 1
                ElseIf Data1 > Data2 Then
                    Return -1
                Else
                    Return 0
                End If
            End If

        End Function
    End Class

    Friend Function ImportaClientiStorico(ByVal FileDati As String) As Boolean

        IconaNotifica.Text = String.Format("Unitools: {0}storico clienti...", Environment.NewLine)
        AddLog(">>> Clienti")

        Try
            Using cmd As New OleDbCommand

                cmd.Connection = cnArrivi

                'inizializzo command builder
                Using da As New OleDbDataAdapter("SELECT * FROM Clienti WHERE False", cnArrivi)

                    Using cmdBuilder As New OleDbCommandBuilder(da)

                        'creo la stored procedure
                        Try
                            cmd.CommandType = CommandType.Text
                            cmd.CommandText = "Create Procedure InsClienti As " + cmdBuilder.GetInsertCommand.CommandText
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception
                            'la stored c'è già
                        End Try
                    End Using
                End Using

                'imposto il cmd per l'esecuzione della stored
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "InsClienti"

                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                    Dim NumeroRecord As Integer = TrovaSezione(sr, "CLIENTISETUP")

                    For k As Integer = 1 To NumeroRecord
                        If EstraiCampi(sr.ReadLine, sr.ReadLine, cmd) = False Then Throw New System.Exception
                        Application.DoEvents()
                    Next

                End Using
            End Using

            Return True

        Catch ex As Exception
            BoxErrore(ex)
            SvuotaTabella(TipoFileMagia.Anag)
            Return False
        End Try

    End Function

#End Region

End Module
