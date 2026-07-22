Imports System.IO
Imports System.Data.OleDb

Public Class ListeQT

    Private mAgenziaFiglia As Utx.AgenziaFigliaOmnia
    Private mRecordConfig As Utx.RecordConfigOmnia
    Private FileDOC As DocCasellario

    Sub New(ByRef AgenziaFiglia As Utx.AgenziaFigliaOmnia,
            ByRef RecordConfig As Utx.RecordConfigOmnia)
        mAgenziaFiglia = AgenziaFiglia
        mRecordConfig = RecordConfig
    End Sub

    Public Sub ImportaListeQT()
        Try
            'blocca il download per le sedi secondarie
            If (mAgenziaFiglia.SedePrincipale = False) AndAlso (mAgenziaFiglia.ConfigSedeSecondaria.ListeQT = False) Then
                Exit Sub
            End If

            'log
            Globale.Log.Info(String.Format("{0}: " + "Liste quietanzamento", mRecordConfig.AgenziaCollegata))

            FileDOC = New DocCasellario With {
                .AgenziaFiglia = mAgenziaFiglia,
                .RecordConfig = mRecordConfig,
                .TipoFile = Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO,
                .ImportazioneDB = True
            }

            'per ciascuna tipologia di doc nella lista quietanzamento
            For Each dr As DataRow In mAgenziaFiglia.TabellaListe.Rows

                If dr("TipoDoc") = Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO Then

                    FileDOC.CodiceDoc = dr("CodiceDoc")
                    FileDOC.FormatoData = dr("FormatoData")
                    FileDOC.PrimoAggiornamento()

                    Do While FileDOC.DataRiferimento <= FileDOC.MaxDataDownload
                        FileDOC.NomeFile = String.Format("{0}{1}{2}.ZIP",
                                                         mRecordConfig.AgenziaCollegata,
                                                         dr("NomeBase"),
                                                         Format(FileDOC.DataRiferimento, dr("FormatoData")))

                        FileDOC.Init() 'ricevuti tutti parametri inizializza
                        FileDOC.ScaricaFile()
                        If FileDOC.ErroreCritico = True Then Exit Try

                        If mAgenziaFiglia.SoloScaricoFile = False Then
                            'se non siamo in modalità creazione archivio e il file è disponibile importo
                            If FileDOC.FileDisponibile = True Then
                                ImportaListaQT(FileDOC.FileScaricato,
                                               FileDOC.DataRiferimento,
                                               FileDOC.CodiceDoc)
                                'file mensili
                                FileDOC.AggiornaCalendarioDocArrivi(Utx.FunzioniData.InizioMese(FileDOC.DataRiferimento),
                                                                    Utx.FunzioniData.FineMese(FileDOC.DataRiferimento))
                            End If
                        End If

                        'funziona solo per file che prevedono la data nella forma "MMyyyy"
                        'non funziona con date che prevedono il giorno (es. vedi elenco flex)
                        FileDOC.ProssimoAggiornamento()
                    Loop
                    Globale.Log.Info()
                End If
            Next

        Catch ex As Exception
            Globale.Log.Info(ex)
        Finally
            Globale.Log.Info()
        End Try
    End Sub

    Public Sub ImportaListeFlex()
        Try
            'blocca il download per le sedi secondarie
            If mAgenziaFiglia.SedePrincipale = False AndAlso mAgenziaFiglia.ConfigSedeSecondaria.ListeQT = False Then
                Exit Sub
            End If

            'log
            Globale.Log.Info(String.Format("{0}: " + "Liste flex", mRecordConfig.AgenziaCollegata))

            'per ciascuna tipologia di doc nella lista flex
            For Each dr As DataRow In mAgenziaFiglia.TabellaListe.Rows

                If dr("TipoDoc") = Utx.Enumerazioni.TipoFileDoc.FLEX Then

                    FileDOC = New DocCasellario()
                    With FileDOC
                        .AgenziaFiglia = mAgenziaFiglia
                        .RecordConfig = mRecordConfig
                        .TipoFile = Utx.Enumerazioni.TipoFileDoc.FLEX
                        .CodiceDoc = dr("CodiceDoc")
                        .FormatoData = dr("FormatoData")
                        .ImportazioneDB = True
                        .PrimoAggiornamento()
                    End With

                    Do While FileDOC.DataRiferimento <= FileDOC.MaxDataDownload
                        FileDOC.NomeFile = String.Format("{0}{1}{2}.exe",
                                                         mRecordConfig.AgenziaCollegata,
                                                         dr("NomeBase"),
                                                         Format(FileDOC.DataRiferimento, "yyyyMMdd"))
                        FileDOC.Init() 'ricevuti tutti parametri inizializza
                        FileDOC.ScaricaFile()
                        If FileDOC.ErroreCritico = True Then Exit Try

                        If mAgenziaFiglia.SoloScaricoFile = False Then
                            'se non siamo in modalità creazione archivio e il file è disponibile importo
                            If FileDOC.FileDisponibile = True Then

                                Dim FinePeriodo As Date
                                If FileDOC.DataRiferimento.Day = 15 Then
                                    FinePeriodo = Utx.FunzioniData.QuindiciDelMese(FileDOC.DataRiferimento)
                                Else
                                    FinePeriodo = Utx.FunzioniData.FineMese(FileDOC.DataRiferimento)
                                End If

                                'se il file è del tipo elenco
                                If FileDOC.CodiceDoc = DocCasellario.TipoDocFlex.ElencoFlex OrElse
                                   FileDOC.CodiceDoc = DocCasellario.TipoDocFlex.ElencoFlexCampagne Then

                                    ImportaListeFlex(FileDOC.FileScaricato,
                                                     FileDOC.DataRiferimento,
                                                     FileDOC.CodiceDoc)

                                    'aggiornamento calendario doc in arrivi
                                    'FileDOC.AggiornaCalendarioDocArrivi(FinePeriodo)
                                Else
                                    'aggiornamento calendario doc direttamente in Info.mdb
                                    FileDOC.AggiornaCalendarioDocInfo(FinePeriodo)
                                End If
                            End If
                        End If
                        'avanzo al periodo successivo
                        FileDOC.ProssimoAggiornamento()
                    Loop
                End If
            Next

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        Finally
            Globale.Log.Info()
        End Try
    End Sub

    Private Function ImportaListaQT(FileDati As String,
                                    DataAggiornamento As Date,
                                    CodiceDoc As DocCasellario.TipoDocQT) As Boolean

        Globale.Log.Info(">>> Importo la lista...")
        'creo la stored procedure di insert e inizializzo command builder
        Using da As New OleDbDataAdapter("SELECT * FROM AttivitaQT WHERE False", mAgenziaFiglia.Connessione)

            Using cmdBuilder As New OleDbCommandBuilder(da)

                Using cmd As New OleDbCommand

                    Try
                        With cmd
                            .Connection = mAgenziaFiglia.Connessione
                            .CommandType = CommandType.Text
                            .CommandText = "Create Procedure InsListaQT As " + cmdBuilder.GetInsertCommand.CommandText
                            .ExecuteNonQuery()
                        End With

                    Catch ex As Exception
                        'la stored c'è già
                    End Try
                End Using
            End Using
        End Using

        Try
            ImportaListaQT = False
            'valuto il tipo di lista e importo
            Select Case CodiceDoc
                Case DocCasellario.TipoDocQT.RcaSospese
                    ImportaListaQT = EstraiRcaSospese(FileDati, DataAggiornamento, CodiceDoc)
                Case DocCasellario.TipoDocQT.ReNonQT
                    ImportaListaQT = EstraiReNoQT(FileDati, DataAggiornamento, CodiceDoc)
                Case DocCasellario.TipoDocQT.ReDaRegolare
                    ImportaListaQT = EstraiReDaRegolare(FileDati, DataAggiornamento, CodiceDoc)
                Case DocCasellario.TipoDocQT.RecuperiFranchigie
                    ImportaListaQT = EstraiRecuperiFranchigie(FileDati, DataAggiornamento, CodiceDoc)
                Case DocCasellario.TipoDocQT.PeriodiRegolazione
                    ImportaListaQT = EstraiPeriodiRegolazione(FileDati, DataAggiornamento, CodiceDoc)
                Case DocCasellario.TipoDocQT.RcaBloccate
                    ImportaListaQT = EstraiRcaBloccate(FileDati, DataAggiornamento, CodiceDoc)
                Case DocCasellario.TipoDocQT.RcaVincolate
                    ImportaListaQT = EstraiRcaVincolate(FileDati, DataAggiornamento, CodiceDoc)
                Case DocCasellario.TipoDocQT.ReCoass
                    ImportaListaQT = EstraiReCoass(FileDati, DataAggiornamento, CodiceDoc)
            End Select

            If ImportaListaQT = True Then
                Globale.Log.Info(">>> Importazione ok")
            End If

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
            ImportaListaQT = False
            Throw New System.Exception
        End Try
    End Function

    Private Function ImportaListeFlex(FileDati As String,
                                       DataAggiornamento As Date,
                                       Riforma As Boolean) As Boolean

        Globale.Log.Info(">>> Elenco flex")

        'creo la stored procedure di insert
        'inizializzo command builder
        Using da As New OleDbDataAdapter("SELECT * FROM ElencoFlex WHERE False", mAgenziaFiglia.Connessione)

            Using cmdBuilder As New OleDbCommandBuilder(da)

                Using cmd As New OleDbCommand

                    Try
                        cmd.Connection = mAgenziaFiglia.Connessione
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "Create Procedure InsFlex As " + cmdBuilder.GetInsertCommand.CommandText
                        cmd.ExecuteNonQuery()

                    Catch ex As Exception
                        'la stored c'è già
                    End Try
                End Using
            End Using
        End Using

        Try
            If EstraiElencoFlex(FileDati, DataAggiornamento, Riforma) = True Then
                Globale.Log.Info(">>> Importazione elenco flex: ok")
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Globale.Log.Info(ex)
            Return False
            Throw New System.Exception
        End Try
    End Function

    Private Function EstraiRcaBloccate(FileDati As String,
                                       DataAggiornamento As Date,
                                       CodiceDoc As Integer) As Boolean

        Using cmd As New OleDbCommand

            'imposto il cmd per l'esecuzione della stored
            cmd.Connection = mAgenziaFiglia.Connessione
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsListaQT"

            Dim Riga As String = ""

            Try
                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                    'prima riga con il nome dei campi
                    'Ag./Ramo/Polizza/Veic/Sub/Conv/Targa/Tipo veicolo/Codice fiscale/Contraente/Indirizzo/Scad. qt/Scad. vinc/
                    'Descrizione Errore/Marca/Modello/Codice Infocar/Imm./Motivo del mancato adeguam.
                    sr.ReadLine()

                    Do While Not sr.EndOfStream

                        'sostituisco le virgolette con uno spazio perchè danno fastidio nelle query
                        Riga = Replace(sr.ReadLine, Chr(34), "", , , CompareMethod.Text)

                        Dim Campi() As String = Riga.Split(";")

                        TrimArray(Campi) 'trimmo tutto

                        With cmd.Parameters
                            .Clear()

                            .AddWithValue("Aggiornato", DataAggiornamento)
                            .AddWithValue("Attivita", CodiceDoc)
                            .AddWithValue("Chiusura", DBNull.Value)
                            .AddWithValue("Agenzia", Campi(0))
                            .AddWithValue("Ramo", Campi(1))
                            .AddWithValue("Polizza", Campi(2))
                            .AddWithValue("Sub", Utx.FunzioniDb.Str2Num(Campi(4)))
                            .AddWithValue("Convenzione", Utx.FunzioniDb.Str2Num(Campi(5)))
                            .AddWithValue("Fraz", 0)
                            .AddWithValue("CodiceFiscale", Campi(8).Replace("=", ""))
                            .AddWithValue("Contraente", Left(Campi(9), 40))
                            .AddWithValue("DataEffettoTitolo", Utx.FunzioniDb.Str2Data(Campi(11)))
                            .AddWithValue("DataScadenzaTitolo", DBNull.Value)
                            .AddWithValue("ScadenzaVincolo", DBNull.Value)
                            .AddWithValue("DataSospensione", DBNull.Value)
                            .AddWithValue("DataImma", Campi(17))
                            .AddWithValue("Clausole", "")
                            .AddWithValue("Veicolo", 0)
                            .AddWithValue("TipoVeicolo", Campi(7))
                            .AddWithValue("Targa", Campi(6))
                            .AddWithValue("Marca", Campi(14))
                            .AddWithValue("Modello", Campi(15))
                            .AddWithValue("Infocar", Campi(16))
                            .AddWithValue("Descrizione", Campi(13))
                            .AddWithValue("Messaggio", Campi(18))
                            .AddWithValue("Premio", 0)
                            .AddWithValue("Quota", 0)
                            .AddWithValue("Delegataria", 0)
                            .AddWithValue("Coass1", 0)
                            .AddWithValue("Quota1", 0)
                            .AddWithValue("PremioCoass1", 0)
                            .AddWithValue("Coass2", 0)
                            .AddWithValue("Quota2", 0)
                            .AddWithValue("PremioCoass2", 0)
                            .AddWithValue("Coass3", 0)
                            .AddWithValue("Quota3", 0)
                            .AddWithValue("PremioCoass3", 0)
                            .AddWithValue("Prodotto", "")
                            .AddWithValue("EsercizioSinistro", 0)
                            .AddWithValue("AgenziaSinistro", 0)
                            .AddWithValue("NumeroSinistro", 0)
                            .AddWithValue("Franchigia", 0)
                        End With

                        cmd.ExecuteNonQuery()
                    Loop

                    Return True

                End Using

            Catch ex As Exception
                Globale.LogErrori.Info(ex)
                Return False
            End Try
        End Using
    End Function

    Private Function EstraiRcaSospese(FileDati As String,
                                      DataAggiornamento As Date,
                                      CodiceDoc As Integer) As Boolean

        Using cmd As New OleDbCommand
            'imposto il cmd per l'esecuzione della stored
            cmd.Connection = mAgenziaFiglia.Connessione
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsListaQT"

            Dim Riga As String = ""

            Try
                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                    'prima riga con il nome dei campi
                    'AGENZIA/RA/POLIZZA/SUB/CONTRAENTE/DT SOSP   
                    sr.ReadLine()

                    Do While Not sr.EndOfStream
                        'sostituisco le virgolette con uno spazio perchè danno fastidio nelle query
                        Riga = Replace(sr.ReadLine, Chr(34), "", , , CompareMethod.Text)
                        Dim Campi() As String = Riga.Split(";")

                        TrimArray(Campi) 'trimmo tutto

                        With cmd.Parameters
                            .Clear()

                            .AddWithValue("Aggiornato", DataAggiornamento)
                            .AddWithValue("Attivita", CodiceDoc)
                            .AddWithValue("Chiusura", DBNull.Value)
                            .AddWithValue("Agenzia", Campi(0))
                            .AddWithValue("Ramo", Campi(1))
                            .AddWithValue("Polizza", Campi(2))
                            .AddWithValue("Sub", Utx.FunzioniDb.Str2Num(Campi(3)))
                            .AddWithValue("Convenzione", 0)
                            .AddWithValue("Fraz", 0)
                            .AddWithValue("CodiceFiscale", "")
                            .AddWithValue("Contraente", Left(Campi(4), 40))
                            .AddWithValue("DataEffettoTitolo", DBNull.Value)
                            .AddWithValue("DataScadenzaTitolo", DBNull.Value)
                            .AddWithValue("ScadenzaVincolo", DBNull.Value)
                            .AddWithValue("DataSospensione", Utx.FunzioniDb.Str2Data(Campi(5)))
                            .AddWithValue("DataImma", "")
                            .AddWithValue("Clausole", "")
                            .AddWithValue("Veicolo", 0)
                            .AddWithValue("TipoVeicolo", "")
                            .AddWithValue("Targa", "")
                            .AddWithValue("Marca", "")
                            .AddWithValue("Modello", "")
                            .AddWithValue("Infocar", "")
                            .AddWithValue("Descrizione", "")
                            .AddWithValue("Messaggio", "")
                            .AddWithValue("Premio", 0)
                            .AddWithValue("Quota", 0)
                            .AddWithValue("Delegataria", 0)
                            .AddWithValue("Coass1", 0)
                            .AddWithValue("Quota1", 0)
                            .AddWithValue("PremioCoass1", 0)
                            .AddWithValue("Coass2", 0)
                            .AddWithValue("Quota2", 0)
                            .AddWithValue("PremioCoass2", 0)
                            .AddWithValue("Coass3", 0)
                            .AddWithValue("Quota3", 0)
                            .AddWithValue("PremioCoass3", 0)
                            .AddWithValue("Prodotto", "")
                            .AddWithValue("EsercizioSinistro", 0)
                            .AddWithValue("AgenziaSinistro", 0)
                            .AddWithValue("NumeroSinistro", 0)
                            .AddWithValue("Franchigia", 0)
                        End With

                        cmd.ExecuteNonQuery()
                    Loop

                    Return True
                End Using

            Catch ex As Exception
                Globale.Log.Info("Errore linea " + Err.Erl.ToString)
                Globale.LogErrori.Info(ex)
                Return False
            End Try
        End Using
    End Function

    Private Function EstraiRcaVincolate(FileDati As String,
                                        DataAggiornamento As Date,
                                        CodiceDoc As Integer) As Boolean

        Using cmd As New OleDbCommand

            'imposto il cmd per l'esecuzione della stored
            cmd.Connection = mAgenziaFiglia.Connessione
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsListaQT"

            Dim Riga As String = ""

            Try
                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                    'prima riga con il nome dei campi
                    'AG./RA/POLIZZA/SUB/CONTRAENTE/DT SCA.VI./CLA/EFF.QUIET.
                    sr.ReadLine()

                    Do While Not sr.EndOfStream

                        'sostituisco le virgolette con uno spazio perchè danno fastidio nelle query
                        Riga = Replace(sr.ReadLine, Chr(34), "", , , CompareMethod.Text)

                        Dim Campi() As String = Riga.Split(";")

                        TrimArray(Campi) 'trimmo tutto

                        With cmd.Parameters
                            .Clear()

                            .AddWithValue("Aggiornato", DataAggiornamento)
                            .AddWithValue("Attivita", CodiceDoc)
                            .AddWithValue("Chiusura", DBNull.Value)
                            .AddWithValue("Agenzia", Campi(0))
                            .AddWithValue("Ramo", Campi(1))
                            .AddWithValue("Polizza", Campi(2))
                            .AddWithValue("Sub", Utx.FunzioniDb.Str2Num(Campi(3)))
                            .AddWithValue("Convenzione", 0)
                            .AddWithValue("Fraz", 0)
                            .AddWithValue("CodiceFiscale", "")
                            .AddWithValue("Contraente", Left(Campi(4), 40))
                            .AddWithValue("DataEffettoTitolo", Utx.FunzioniDb.Str2Data(Campi(7)))
                            .AddWithValue("DataScadenzaTitolo", DBNull.Value)
                            .AddWithValue("ScadenzaVincolo", DBNull.Value)
                            .AddWithValue("DataSospensione", Utx.FunzioniDb.Str2Data(Campi(5)))
                            .AddWithValue("DataImma", "")
                            .AddWithValue("Clausole", Campi(6))
                            .AddWithValue("Veicolo", 0)
                            .AddWithValue("TipoVeicolo", "")
                            .AddWithValue("Targa", "")
                            .AddWithValue("Marca", "")
                            .AddWithValue("Modello", "")
                            .AddWithValue("Infocar", "")
                            .AddWithValue("Descrizione", "")
                            .AddWithValue("Messaggio", "")
                            .AddWithValue("Premio", 0)
                            .AddWithValue("Quota", 0)
                            .AddWithValue("Delegataria", 0)
                            .AddWithValue("Coass1", 0)
                            .AddWithValue("Quota1", 0)
                            .AddWithValue("PremioCoass1", 0)
                            .AddWithValue("Coass2", 0)
                            .AddWithValue("Quota2", 0)
                            .AddWithValue("PremioCoass2", 0)
                            .AddWithValue("Coass3", 0)
                            .AddWithValue("Quota3", 0)
                            .AddWithValue("PremioCoass3", 0)
                            .AddWithValue("Prodotto", "")
                            .AddWithValue("EsercizioSinistro", 0)
                            .AddWithValue("AgenziaSinistro", 0)
                            .AddWithValue("NumeroSinistro", 0)
                            .AddWithValue("Franchigia", 0)
                        End With

                        cmd.CommandText = "InsListaQT"
                        cmd.ExecuteNonQuery()
                    Loop
                End Using

                Return True

            Catch ex As Exception
                Globale.LogErrori.Info(ex)
                Return False
            End Try
        End Using
    End Function

    Private Function EstraiReNoQT(FileDati As String,
                                  DataAggiornamento As Date,
                                  CodiceDoc As Integer) As Boolean

        Using cmd As New OleDbCommand

            'imposto il cmd per l'esecuzione della stored
            cmd.Connection = mAgenziaFiglia.Connessione
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsListaQT"

            Dim Riga As String = ""

            Try
                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                    'prima riga con il nome dei campi
                    'AG./SUB/RA/POLIZZA/FR/EFFETTO/QT/ME/ANNO/RS/TOTALE/NOME/MESSAGGIO                                                             
                    sr.ReadLine()

                    Do While Not sr.EndOfStream

                        'sostituisco le virgolette con uno spazio perchè danno fastidio nelle query
                        Riga = Replace(sr.ReadLine, Chr(34), "", , , CompareMethod.Text)

                        Dim Campi() As String = Riga.Split(";")

                        TrimArray(Campi) 'trimmo tutto

                        With cmd.Parameters
                            .Clear()

                            .AddWithValue("Aggiornato", DataAggiornamento)
                            .AddWithValue("Attivita", CodiceDoc)
                            .AddWithValue("Chiusura", DBNull.Value)
                            .AddWithValue("Agenzia", Campi(0))
                            .AddWithValue("Ramo", Campi(2))
                            .AddWithValue("Polizza", Campi(3))
                            .AddWithValue("Sub", Utx.FunzioniDb.Str2Num(Campi(1)))
                            .AddWithValue("Convenzione", 0)
                            .AddWithValue("Fraz", Campi(4))
                            .AddWithValue("CodiceFiscale", "")
                            .AddWithValue("Contraente", Left(Campi(11), 40))
                            .AddWithValue("DataEffettoTitolo", Utx.FunzioniDb.Str2Data(Campi(5)))
                            .AddWithValue("DataScadenzaTitolo", DBNull.Value)
                            .AddWithValue("ScadenzaVincolo", DBNull.Value)
                            .AddWithValue("DataSospensione", DBNull.Value)
                            .AddWithValue("DataImma", "")
                            .AddWithValue("Clausole", Campi(6))
                            .AddWithValue("Veicolo", 0)
                            .AddWithValue("TipoVeicolo", "")
                            .AddWithValue("Targa", "")
                            .AddWithValue("Marca", "")
                            .AddWithValue("Modello", "")
                            .AddWithValue("Infocar", "")
                            .AddWithValue("Descrizione", "")
                            .AddWithValue("Messaggio", Campi(10))
                            .AddWithValue("Premio", Campi(8))
                            .AddWithValue("Quota", 0)
                            .AddWithValue("Delegataria", 0)
                            .AddWithValue("Coass1", 0)
                            .AddWithValue("Quota1", 0)
                            .AddWithValue("PremioCoass1", 0)
                            .AddWithValue("Coass2", 0)
                            .AddWithValue("Quota2", 0)
                            .AddWithValue("PremioCoass2", 0)
                            .AddWithValue("Coass3", 0)
                            .AddWithValue("Quota3", 0)
                            .AddWithValue("PremioCoass3", 0)
                            .AddWithValue("Prodotto", "")
                            .AddWithValue("EsercizioSinistro", 0)
                            .AddWithValue("AgenziaSinistro", 0)
                            .AddWithValue("NumeroSinistro", 0)
                            .AddWithValue("Franchigia", 0)
                        End With

                        cmd.ExecuteNonQuery()
                    Loop
                End Using

                Return True

            Catch ex As Exception
                Globale.LogErrori.Info(ex)
                Return False
            End Try
        End Using
    End Function

    Private Function EstraiReDaRegolare(FileDati As String,
                                        DataAggiornamento As Date,
                                        CodiceDoc As Integer) As Boolean

        Using cmd As New OleDbCommand

            'imposto il cmd per l'esecuzione della stored
            cmd.Connection = mAgenziaFiglia.Connessione
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsListaQT"

            Dim Riga As String = ""

            Try
                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                    'prima riga con il nome dei campi
                    'AGEN./TIPO STAMPA/COMPAGNIA/RAMO/POLIZZA/DATA INIZIO/DATA FINE/CONTRAENTE/DELEGATARIA/PRODOTTO/
                    'SUBAGENZIA/PARAMETRI RICHIESTI(1)/PARAMETRI RICHIESTI(2)/PARAMETRI RICHIESTI(3)/PARAMETRI RICHIESTI(4)/
                    'PARAMETRI RICHIESTI(5)/PARAMETRI RICHIESTI(6)
                    sr.ReadLine()

                    Do While Not sr.EndOfStream

                        'sostituisco le virgolette con uno spazio perchè danno fastidio nelle query
                        Riga = Replace(sr.ReadLine, Chr(34), "", , , CompareMethod.Text)

                        Dim Campi() As String = Riga.Split(";")

                        TrimArray(Campi) 'trimmo tutto

                        'parametri: campi da 11 a 16
                        Dim Parametri As String = ""

                        For k As Integer = 11 To 16
                            Parametri += Campi(k) + "/"
                        Next

                        With cmd.Parameters
                            .Clear()

                            .AddWithValue("Aggiornato", DataAggiornamento)
                            .AddWithValue("Attivita", CodiceDoc)
                            .AddWithValue("Chiusura", DBNull.Value)
                            .AddWithValue("Agenzia", Campi(0))
                            .AddWithValue("Ramo", Campi(3))
                            .AddWithValue("Polizza", Campi(4))
                            .AddWithValue("Sub", Utx.FunzioniDb.Str2Num(Campi(10)))
                            .AddWithValue("Convenzione", 0)
                            .AddWithValue("Fraz", 0)
                            .AddWithValue("CodiceFiscale", "")
                            .AddWithValue("Contraente", Left(Campi(7), 40))
                            .AddWithValue("DataEffettoTitolo", Utx.FunzioniDb.Str2Data(Campi(5)))
                            .AddWithValue("DataScadenzaTitolo", Utx.FunzioniDb.Str2Data(Campi(6)))
                            .AddWithValue("ScadenzaVincolo", DBNull.Value)
                            .AddWithValue("DataSospensione", DBNull.Value)
                            .AddWithValue("DataImma", "")
                            .AddWithValue("Clausole", "")
                            .AddWithValue("Veicolo", 0)
                            .AddWithValue("TipoVeicolo", "")
                            .AddWithValue("Targa", "")
                            .AddWithValue("Marca", "")
                            .AddWithValue("Modello", "")
                            .AddWithValue("Infocar", "")
                            .AddWithValue("Descrizione", Left(Parametri, 255))
                            .AddWithValue("Messaggio", Campi(1))
                            .AddWithValue("Premio", 0)
                            .AddWithValue("Quota", 0)
                            .AddWithValue("Delegataria", Utx.FunzioniDb.Str2Num(Campi(8)))
                            .AddWithValue("Coass1", 0)
                            .AddWithValue("Quota1", 0)
                            .AddWithValue("PremioCoass1", 0)
                            .AddWithValue("Coass2", 0)
                            .AddWithValue("Quota2", 0)
                            .AddWithValue("PremioCoass2", 0)
                            .AddWithValue("Coass3", 0)
                            .AddWithValue("Quota3", 0)
                            .AddWithValue("PremioCoass3", 0)
                            .AddWithValue("Prodotto", Campi(9))
                            .AddWithValue("EsercizioSinistro", 0)
                            .AddWithValue("AgenziaSinistro", 0)
                            .AddWithValue("NumeroSinistro", 0)
                            .AddWithValue("Franchigia", 0)
                        End With

                        cmd.ExecuteNonQuery()
                    Loop
                End Using

                Return True

            Catch ex As Exception
                Globale.LogErrori.Info(ex)
                Return False
            End Try
        End Using
    End Function

    Private Function EstraiRecuperiFranchigie(FileDati As String,
                                              DataAggiornamento As Date,
                                              CodiceDoc As Integer) As Boolean

        Using cmd As New OleDbCommand

            'imposto il cmd per l'esecuzione della stored
            cmd.Connection = mAgenziaFiglia.Connessione
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsListaQT"

            Dim Riga As String = ""

            Try
                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                    'codice attività: 4
                    'prima riga con il nome dei campi
                    'AGEN./TIPO STAMPA/COGNOME-RAGIONE SOCIALE/NOME/COD.FISC.-P.IVA/TIPO CLIENTE/TARGA ASSICURATO/RAMO/POLIZZA/
                    'ESERCIZIO/AGENZIA/SINISTRO/NUMERO/SINISTRO/DATA DANNO/DATA/LIQUIDAZIONE/IMPORTO/PAGATO/FRANCHIGIA   
                    sr.ReadLine()

                    Do While Not sr.EndOfStream

                        'sostituisco le virgolette con uno spazio perchè danno fastidio nelle query
                        Riga = Replace(sr.ReadLine, Chr(34), "", , , CompareMethod.Text)

                        Dim Campi() As String = Riga.Split(";")

                        TrimArray(Campi) 'trimmo tutto

                        With cmd.Parameters
                            .Clear()

                            .AddWithValue("Aggiornato", DataAggiornamento)
                            .AddWithValue("Attivita", CodiceDoc)
                            .AddWithValue("Chiusura", DBNull.Value)
                            .AddWithValue("Agenzia", Campi(0))
                            .AddWithValue("Ramo", Campi(7))
                            .AddWithValue("Polizza", Campi(8))
                            .AddWithValue("Sub", 0)
                            .AddWithValue("Convenzione", 0)
                            .AddWithValue("Fraz", 0)
                            .AddWithValue("CodiceFiscale", Campi(4).Replace("=", ""))
                            .AddWithValue("Contraente", Left(Campi(2) + " " + Campi(3), 40).Trim)
                            .AddWithValue("DataEffettoTitolo", DBNull.Value)
                            .AddWithValue("DataScadenzaTitolo", DBNull.Value)
                            .AddWithValue("ScadenzaVincolo", DBNull.Value)
                            .AddWithValue("DataSospensione", DBNull.Value)
                            .AddWithValue("DataImma", "")
                            .AddWithValue("Clausole", "")
                            .AddWithValue("Veicolo", 0)
                            .AddWithValue("TipoVeicolo", "")
                            .AddWithValue("Targa", Campi(6))
                            .AddWithValue("Marca", "")
                            .AddWithValue("Modello", "")
                            .AddWithValue("Infocar", "")
                            .AddWithValue("Descrizione", "")
                            .AddWithValue("Messaggio", Campi(1))
                            .AddWithValue("Premio", 0)
                            .AddWithValue("Quota", 0)
                            .AddWithValue("Delegataria", 0)
                            .AddWithValue("Coass1", 0)
                            .AddWithValue("Quota1", 0)
                            .AddWithValue("PremioCoass1", 0)
                            .AddWithValue("Coass2", 0)
                            .AddWithValue("Quota2", 0)
                            .AddWithValue("PremioCoass2", 0)
                            .AddWithValue("Coass3", 0)
                            .AddWithValue("Quota3", 0)
                            .AddWithValue("PremioCoass3", 0)
                            .AddWithValue("Prodotto", "")
                            .AddWithValue("EsercizioSinistro", Utx.FunzioniDb.Str2Num(Campi(9)))
                            .AddWithValue("AgenziaSinistro", Utx.FunzioniDb.Str2Num(Campi(10)))
                            .AddWithValue("NumeroSinistro", Utx.FunzioniDb.Str2Num(Campi(11)))
                            .AddWithValue("Franchigia", Utx.FunzioniDb.Str2Num(Campi(15)))
                        End With

                        cmd.ExecuteNonQuery()
                    Loop
                End Using

                Return True

            Catch ex As Exception
                Globale.LogErrori.Info(ex)
                Return False
            End Try
        End Using
    End Function

    Private Function EstraiPeriodiRegolazione(FileDati As String,
                                              DataAggiornamento As Date,
                                              CodiceDoc As Integer) As Boolean

        Using cmd As New OleDbCommand

            'imposto il cmd per l'esecuzione della stored
            cmd.Connection = mAgenziaFiglia.Connessione
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsListaQT"

            Dim Riga As String = ""

            Try
                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                    'prima riga con il nome dei campi
                    'AGEN./RAMO/POLIZZA/DATA INIZIO/DATA FINE/CONTRAENTE/PRODOTTO/DELEGATARIA/SUBAGENZIA
                    sr.ReadLine()

                    Do While Not sr.EndOfStream

                        'sostituisco le virgolette con uno spazio perchè danno fastidio nelle query
                        Riga = Replace(sr.ReadLine, Chr(34), "", , , CompareMethod.Text)

                        Dim Campi() As String = Riga.Split(";")

                        TrimArray(Campi) 'trimmo tutto

                        With cmd.Parameters
                            .Clear()

                            .AddWithValue("Aggiornato", DataAggiornamento)
                            .AddWithValue("Attivita", CodiceDoc)
                            .AddWithValue("Chiusura", DBNull.Value)
                            .AddWithValue("Agenzia", Campi(0))
                            .AddWithValue("Ramo", Campi(1))
                            .AddWithValue("Polizza", Campi(2))
                            .AddWithValue("Sub", Utx.FunzioniDb.Str2Num(Campi(8)))
                            .AddWithValue("Convenzione", 0)
                            .AddWithValue("Fraz", 0)
                            .AddWithValue("CodiceFiscale", "")
                            .AddWithValue("Contraente", Left(Campi(5), 40))
                            .AddWithValue("DataEffettoTitolo", Utx.FunzioniDb.Str2Data(Campi(3)))
                            .AddWithValue("DataScadenzaTitolo", Utx.FunzioniDb.Str2Data(Campi(4)))
                            .AddWithValue("ScadenzaVincolo", DBNull.Value)
                            .AddWithValue("DataSospensione", DBNull.Value)
                            .AddWithValue("DataImma", "")
                            .AddWithValue("Clausole", "")
                            .AddWithValue("Veicolo", 0)
                            .AddWithValue("TipoVeicolo", "")
                            .AddWithValue("Targa", "")
                            .AddWithValue("Marca", "")
                            .AddWithValue("Modello", "")
                            .AddWithValue("Infocar", "")
                            .AddWithValue("Descrizione", "")
                            .AddWithValue("Messaggio", "")
                            .AddWithValue("Premio", 0)
                            .AddWithValue("Quota", 0)
                            .AddWithValue("Delegataria", Utx.FunzioniDb.Str2Num(Campi(8)))
                            .AddWithValue("Coass1", 0)
                            .AddWithValue("Quota1", 0)
                            .AddWithValue("PremioCoass1", 0)
                            .AddWithValue("Coass2", 0)
                            .AddWithValue("Quota2", 0)
                            .AddWithValue("PremioCoass2", 0)
                            .AddWithValue("Coass3", 0)
                            .AddWithValue("Quota3", 0)
                            .AddWithValue("PremioCoass3", 0)
                            .AddWithValue("Prodotto", Campi(6))
                            .AddWithValue("EsercizioSinistro", 0)
                            .AddWithValue("AgenziaSinistro", 0)
                            .AddWithValue("NumeroSinistro", 0)
                            .AddWithValue("Franchigia", 0)
                        End With

                        cmd.ExecuteNonQuery()
                    Loop
                End Using

                Return True

            Catch ex As Exception
                Globale.LogErrori.Info(ex)
                Return False
            End Try
        End Using
    End Function

    Private Function EstraiReCoass(FileDati As String,
                                   DataAggiornamento As Date,
                                   CodiceDoc As Integer) As Boolean

        Using cmd As New OleDbCommand

            'imposto il cmd per l'esecuzione della stored
            cmd.Connection = mAgenziaFiglia.Connessione
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsListaQT"

            Dim Riga As String = ""

            Try
                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                    'prima riga con il nome dei campi
                    'AGEN./RAMO/POLIZZA/SUBAGENZIA/CONTRAENTE/CODICE/QUOTA/PREMIO DI RATA/CODICE(1)/QUOTA(1)/PREMIO DI RATA(1)/
                    'CODICE(2)/QUOTA(2)/PREMIO DI RATA(2) 
                    sr.ReadLine()

                    Do While Not sr.EndOfStream

                        'sostituisco le virgolette con uno spazio perchè danno fastidio nelle query
                        Riga = Replace(sr.ReadLine, Chr(34), "", , , CompareMethod.Text)

                        Dim Campi() As String = Riga.Split(";")

                        TrimArray(Campi) 'trimmo tutto

                        With cmd.Parameters
                            .Clear()

                            .AddWithValue("Aggiornato", DataAggiornamento)
                            .AddWithValue("Attivita", CodiceDoc)
                            .AddWithValue("Chiusura", DBNull.Value)
                            .AddWithValue("Agenzia", Campi(0))
                            .AddWithValue("Ramo", Campi(1))
                            .AddWithValue("Polizza", Campi(2))
                            .AddWithValue("Sub", Utx.FunzioniDb.Str2Num(Campi(3)))
                            .AddWithValue("Convenzione", 0)
                            .AddWithValue("Fraz", 0)
                            .AddWithValue("CodiceFiscale", "")
                            .AddWithValue("Contraente", Left(Campi(4), 40))
                            .AddWithValue("DataEffettoTitolo", DBNull.Value)
                            .AddWithValue("DataScadenzaTitolo", DBNull.Value)
                            .AddWithValue("ScadenzaVincolo", DBNull.Value)
                            .AddWithValue("DataSospensione", DBNull.Value)
                            .AddWithValue("DataImma", "")
                            .AddWithValue("Clausole", "")
                            .AddWithValue("Veicolo", 0)
                            .AddWithValue("TipoVeicolo", "")
                            .AddWithValue("Targa", "")
                            .AddWithValue("Marca", "")
                            .AddWithValue("Modello", "")
                            .AddWithValue("Infocar", "")
                            .AddWithValue("Descrizione", "")
                            .AddWithValue("Messaggio", "")
                            .AddWithValue("Premio", Utx.FunzioniDb.Str2Num(Campi(7)))
                            .AddWithValue("Quota", Utx.FunzioniDb.Str2Num(Campi(6)))
                            .AddWithValue("Delegataria", Utx.FunzioniDb.Str2Num(Campi(5)))
                            .AddWithValue("Coass1", Utx.FunzioniDb.Str2Num(Campi(8)))
                            .AddWithValue("Quota1", Utx.FunzioniDb.Str2Num(Campi(9)))
                            .AddWithValue("PremioCoass1", Utx.FunzioniDb.Str2Num(Campi(10)))
                            .AddWithValue("Coass2", Utx.FunzioniDb.Str2Num(Campi(11)))
                            .AddWithValue("Quota2", Utx.FunzioniDb.Str2Num(Campi(12)))
                            .AddWithValue("PremioCoass2", Utx.FunzioniDb.Str2Num(Campi(13)))
                            .AddWithValue("Coass3", Utx.FunzioniDb.Str2Num(Campi(14)))
                            .AddWithValue("Quota3", Utx.FunzioniDb.Str2Num(Campi(15)))
                            .AddWithValue("PremioCoass3", Utx.FunzioniDb.Str2Num(Campi(16)))
                            .AddWithValue("Prodotto", "")
                            .AddWithValue("EsercizioSinistro", 0)
                            .AddWithValue("AgenziaSinistro", 0)
                            .AddWithValue("NumeroSinistro", 0)
                            .AddWithValue("Franchigia", 0)
                        End With

                        cmd.ExecuteNonQuery()
                    Loop
                End Using

                Return True

            Catch ex As Exception
                Globale.LogErrori.Info(ex)
                Return False
            End Try
        End Using
    End Function

    Private Function EstraiElencoFlex(FileDati As String,
                                      DataAggiornamento As Date,
                                      Riforma As Boolean) As Boolean

        Using cmd As New OleDbCommand

            'imposto il cmd per l'esecuzione della stored
            cmd.Connection = mAgenziaFiglia.Connessione
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsFlex"

            Dim Riga As String = ""

            Try
                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                    'prima riga con il nome dei campi
                    'Agenzia/Ramo/N.Polizza/Subage/Prodotto/Premio Annuo/Premio Ced/Delta/Data Emis/Quota/Contraente/Movimento
                    sr.ReadLine()

                    Do While Not sr.EndOfStream

                        Riga = Replace(sr.ReadLine, Chr(34), "", , , CompareMethod.Text)

                        Dim Campi() As String = Riga.Split(";")

                        TrimArray(Campi) 'trimmo tutto

                        With cmd.Parameters
                            .Clear()

                            .AddWithValue("Aggiornato", DataAggiornamento)
                            .AddWithValue("Agenzia", Campi(0))
                            .AddWithValue("Ramo", Campi(1))
                            .AddWithValue("Polizza", Campi(2))
                            .AddWithValue("Contraente", Left(Campi(10), 40))
                            .AddWithValue("Sub", Utx.FunzioniDb.Str2Num(Campi(3)))
                            .AddWithValue("Prodotto", Campi(4))
                            .AddWithValue("PremioAnnuo", Campi(5))
                            .AddWithValue("PremioCed", Campi(6))
                            .AddWithValue("Delta", Campi(7))
                            .AddWithValue("DataEmissione", Campi(8))
                            .AddWithValue("Quota", Campi(9))
                            .AddWithValue("Movimento", Campi(11))
                            .AddWithValue("Riforma", Riforma)
                        End With

                        cmd.ExecuteNonQuery()
                    Loop
                End Using

                Return True

            Catch ex As Exception
                Globale.LogErrori.Info(ex)
                Return False
            End Try
        End Using
    End Function
End Class
