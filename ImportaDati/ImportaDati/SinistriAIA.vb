Imports System.Data.OleDb
Imports System.IO

Public Class SinistriAIA

    Private mAgenziaFiglia As Utx.AgenziaFigliaOmnia
    Private mRecordConfig As Utx.RecordConfigOmnia
    Private FileAIA As FileCasellario

    Sub New(ByRef AgenziaFiglia As Utx.AgenziaFigliaOmnia,
            ByRef RecordConfig As Utx.RecordConfigOmnia)
        mAgenziaFiglia = AgenziaFiglia
        mRecordConfig = RecordConfig
    End Sub

    Public Sub ImportaSinistriAIA()
        Try
            'blocca il download per le sedi secondarie
            If mAgenziaFiglia.ConfigSedeSecondaria.PattoUnipol = False Then
                Exit Sub
            End If

            FileAIA = New FileCasellario() With {
                .AgenziaFiglia = mAgenziaFiglia,
                .RecordConfig = mRecordConfig,
                .TipoFile = Utx.Enumerazioni.TipoFileMagia.SinistriBase,
                .ImportazioneDB = True}
            FileAIA.PrimoAggiornamento()

            Do While FileAIA.DataRiferimento < FileAIA.MaxDataDownload
                Globale.Log.Info(String.Format("Importa sinistri base CONSUNTIVO {0}", FileAIA.DataRiferimento.Year))

                For Each f As FilePattoUnipol In ListaFilePatto(FileAIA.DataRiferimento.Year)
                    FileAIA.NomeFile = String.Format("{0}{1}.ZIP", mRecordConfig.AgenziaCollegata, f.NomeFile)
                    FileAIA.Init()
                    FileAIA.ScaricaFile()
                    If FileAIA.ErroreCritico = True Then Exit Try

                    If FileAIA.FileDisponibile = True Then

                        If f.Importare = True Then
                            ImportaSinistriBase(FileAIA.FileScaricato, f.AnnoCompetenza, mAgenziaFiglia.Connessione)
                        End If
                        'copio il file nella cartella del patto
                        f.CopiaNellaCartellaPatto(FileAIA.AgenziaFiglia.CodiceAgenziaFiglia, FileAIA.FileScaricato)
                        'aggiorno il calendario
                        FileAIA.AggiornaCalendarioUt(New Date(f.AnnoCompetenza, 1, 1), New Date(f.AnnoCompetenza, 12, 31))
                    End If
                Next
                'avanza di un anno e ripete il loop
                FileAIA.ProssimoAggiornamento()
            Loop

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        Finally
            Globale.Log.Info()
        End Try
    End Sub

    Public Shared Function ImportaSinistriBase(FileDati As String,
                                               Anno As Integer,
                                               cn As OleDbConnection) As Boolean

        Globale.Log.Info(">>> Importazione sinistri base {0}: {1}", {Anno, FileDati})
        'Globale.Log.Info("Connessione: {0}", {cn.ConnectionString})
        'inizializzo command builder
        Dim da As New OleDbDataAdapter("SELECT * FROM SinistriAia WHERE False", cn)
        Dim cmdBuilder As New OleDbCommandBuilder(da)
        Dim cmd As New OleDbCommand

        Try
            'creo la stored procedure di insert
            With cmd
                .Connection = cn
                .CommandType = CommandType.Text
                .CommandText = "Create Procedure InsSinistroAia AS " + cmdBuilder.GetInsertCommand.CommandText
                .ExecuteNonQuery()
            End With

        Catch ex As Exception
            'la stored c'è già
            cmdBuilder.Dispose()
            da.Dispose()
        End Try

        'imposto il cmd per l'esecuzione della stored
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "InsSinistroAia"

        Dim NumeroRecord As Integer = 0 'contatore record importati

        Try
            'imposto la connessione a seconda del tipo di file
            Select Case Path.GetExtension(FileDati).ToLower
                Case ".xls" 'file in formato excel
                    Try
                        Using cx As New OleDbConnection(Utx.Globale.XLSDriver + FileDati)
                            cx.Open()

                            Using cmdEx As New OleDbCommand
                                cmdEx.Connection = cx
                                cmdEx.CommandType = CommandType.Text
                                cmdEx.CommandText = "SELECT * FROM [Dati$]"

                                Dim dr As OleDbDataReader

                                'leggo i dati dal file excel
                                dr = cmdEx.ExecuteReader

                                'leggo riga per riga il dr e aggiungo alla tabella in arrivi
                                Do While dr.Read
                                    cmd.Parameters.Clear()

                                    'il db contiene una colonna in più con l'anno di competenza
                                    cmd.Parameters.AddWithValue("Anno", Anno)

                                    'imposta i parametri
                                    For k As Integer = 0 To dr.FieldCount - 1
                                        Select Case k
                                            Case 5
                                                'analisi per correggere errori ex fonsai (05/2016) - vedi 7
                                                If dr(7).ToString.Length = 10 Then
                                                    'prendo i primi 5 caratteri che rappresentano l'agenzia
                                                    cmd.Parameters.AddWithValue(k.ToString, dr(k).ToString.Substring(0, 5))
                                                Else
                                                    cmd.Parameters.AddWithValue(k.ToString, dr(k))
                                                End If
                                            Case 7
                                                'analisi per correggere errori ex fonsai (05/2016)
                                                If dr(k).ToString.Length = 10 Then
                                                    'tolgo i primi 5 caratteri che rappresentano l'agenzia
                                                    'il numero polizza è comunque sbagliato perchè sempre uguale
                                                    cmd.Parameters.AddWithValue(k.ToString, dr(k).ToString.Substring(5))
                                                Else
                                                    cmd.Parameters.AddWithValue(k.ToString, dr(k))
                                                End If
                                            Case 8
                                                'tolgo le virgolette nel campo intestatario polizza
                                                Dim Contraente As String
                                                If dr(k) Is DBNull.Value Then
                                                    Contraente = ""
                                                Else
                                                    Contraente = dr(k).Replace(Chr(34), "")
                                                    Contraente = Contraente.Replace("'", "")
                                                End If

                                                cmd.Parameters.AddWithValue(k.ToString, Contraente)
                                            Case Else
                                                cmd.Parameters.AddWithValue(k.ToString, dr(k))
                                        End Select
                                    Next

                                    'il db contiene una colonna in più, alla fine, con il flag coass
                                    cmd.Parameters.AddWithValue("32", "")

                                    cmd.ExecuteNonQuery()
                                Loop

                                dr.Close()
                            End Using
                        End Using

                    Catch ex As Exception
                        Globale.Log.Info(ex)
                        Globale.Log.Info(">>> Importa sinistri base formato xls: Errore")
                        Throw New System.Exception
                    End Try

                Case ".csv" 'file in formato csv
                    Try
                        Dim Campi() As String

                        Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                            'prima riga con il nome dei campi
                            sr.ReadLine()

                            Do While Not sr.EndOfStream
                                Campi = sr.ReadLine.Split(";")

                                'porto il campo rg dalla sesta all'ultima posizione
                                Dim Rg As String = Campi(5)
                                For k As Integer = 6 To 35
                                    Campi(k - 1) = Campi(k)
                                Next
                                Campi(35) = Rg

                                'tolgo le virgolette nel campo intestatario polizza
                                If Campi(8) Is DBNull.Value Then
                                    Campi(8) = ""
                                Else
                                    Campi(8) = Campi(8).Replace(Chr(34), "").Replace("'", "")
                                End If
                                'analisi per correggere errori ex fonsai (05/2016) - vedi 7
                                If Campi(7).ToString.Length = 10 Then
                                    'prendo i primi 5 caratteri che rappresentano l'agenzia
                                    Campi(5) = Campi(7).ToString.Substring(0, 5)
                                    'gli ultimi 5 caratteri sono il numero di polizza (sbagliato)
                                    Campi(7) = Campi(7).ToString.Substring(5)
                                End If

                                cmd.Parameters.Clear()

                                'il db contiene una colonna in più con l'anno di competenza
                                cmd.Parameters.AddWithValue("Anno", Anno)

                                'imposta i parametri
                                For k As Integer = 0 To Campi.GetUpperBound(0)
                                    'Globale.Log.Info("campo: {0} = '{1}'", {k, Campi(k)}) 'x DEBUG
                                    cmd.Parameters.AddWithValue(k.ToString, Utx.FunzioniDb.NullToString(Campi(k)))
                                Next

                                If Campi.GetUpperBound(0) = 31 Then
                                    'il db contiene una colonna in più, alla fine, con il flag coass
                                    cmd.Parameters.AddWithValue("flag_coass", "")
                                    cmd.Parameters.AddWithValue("classificazione", "")
                                    cmd.Parameters.AddWithValue("id_evento_atmos", "")
                                    cmd.Parameters.AddWithValue("ramo_gest", 0)
                                End If

                                cmd.ExecuteNonQuery()
                                NumeroRecord += 1
                            Loop

                            sr.Close()
                        End Using

                    Catch ex As Exception
                        Globale.Log.Info(ex)
                        Globale.Log.Info(">>> Importa sinistri base formato csv: Errore")
                        Throw New System.Exception
                    End Try
            End Select

            Globale.Log.Info(">>> Importazione sinistri base: esito ok - sinistri importati {0}", {NumeroRecord})
            ImportaSinistriBase = True

        Catch ex As Exception
            Globale.Log.Info(ex)
            Globale.Log.Info(">>> Importa sinistri base: Errore")
            ImportaSinistriBase = False
        End Try
    End Function

    Private Function ListaFilePatto(Anno As Integer) As List(Of FilePattoUnipol)
        Dim ElencoFile As New List(Of FilePattoUnipol)
        'la data di controllo del select è quella in cui viene fatta la lettura che è sempre
        'dell'anno successivo a quello di competenza dei dati
        Select Case Anno
            Case >= 2023
                ElencoFile.Add(New FilePattoUnipol(String.Format("_SX_AUTO_{0:0000}", Anno - 2), Anno - 2, True))
                ElencoFile.Add(New FilePattoUnipol(String.Format("_SX_AUTO_{0:0000}", Anno - 1), Anno - 1, True))
                ElencoFile.Add(New FilePattoUnipol(String.Format("_AUTO_{0}_{1}", Anno - 2002, Anno - 2001), Anno - 1, False, CopiaInPatto:=True,
                                                   CopiaCome:=String.Format("_SP_RCA_{0}_{1}.pdf", Anno - 2002, Anno - 2001)))
                ElencoFile.Add(New FilePattoUnipol("_LEGENDA", Anno - 1, False, CopiaInPatto:=True, CopiaCome:="_LEGENDASX.pdf"))
            Case >= 2016
                ElencoFile.Add(New FilePattoUnipol(String.Format("_SX_{0:0000}", Anno - 2), Anno - 2, True))
                ElencoFile.Add(New FilePattoUnipol(String.Format("_SX_{0:0000}", Anno - 1), Anno - 1, True))
                ElencoFile.Add(New FilePattoUnipol(String.Format("_RCA_{0}_{1}", Anno - 2002, Anno - 2001), Anno - 1, False, CopiaInPatto:=True,
                                                   CopiaCome:=String.Format("_SP_RCA_{0}_{1}.pdf", Anno - 2002, Anno - 2001)))
                ElencoFile.Add(New FilePattoUnipol("_LEGENDASX", Anno - 1, False, CopiaInPatto:=True, CopiaCome:="_LEGENDASX.pdf"))
            Case 2015 'consuntivo 2014
                ElencoFile.Add(New FilePattoUnipol("_BASESX_2013_B13_14", 2013, True))
                ElencoFile.Add(New FilePattoUnipol("_BASESX_2014_B13_14", 2014, True))
                ElencoFile.Add(New FilePattoUnipol("_RCA_13_14", 2014, False, CopiaInPatto:=True, CopiaCome:="_SP_RCA_13_14.pdf"))
                ElencoFile.Add(New FilePattoUnipol("_LEGENDA_13_14", 2014, False, CopiaInPatto:=True, CopiaCome:="_LEGENDASX.pdf"))
            Case 2014 'consuntivo 2013
                ElencoFile.Add(New FilePattoUnipol("_BASESX_2012_B12_13", 2012, True))
                ElencoFile.Add(New FilePattoUnipol("_BASESX_2013_B12_13", 2013, True))
                ElencoFile.Add(New FilePattoUnipol("_RCA_12_13", 2013, False, CopiaInPatto:=True, CopiaCome:="_SP_RCA_12_13.pdf"))
                ElencoFile.Add(New FilePattoUnipol("_LEGENDA_12_13", 2013, False, CopiaInPatto:=True, CopiaCome:="_LEGENDASX.pdf"))
            Case 2013 'consuntivo 2012
                ElencoFile.Add(New FilePattoUnipol("_BASESX_2011_B11_12", 2011, True))
                ElencoFile.Add(New FilePattoUnipol("_BASESX_2012_B11_12", 2012, True))
                ElencoFile.Add(New FilePattoUnipol("_RCA_11_12", 2012, False, CopiaInPatto:=True, CopiaCome:="_SP_RCA_11_12.pdf"))
                ElencoFile.Add(New FilePattoUnipol("_LEGENDA_NEW", 2012, False, CopiaInPatto:=True, CopiaCome:="_LEGENDASX.pdf"))
        End Select
        Return ElencoFile
    End Function
End Class

Friend Class FilePattoUnipol

    Private Shared UrlDoc As String = Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, "Documenti_Unipol\Patto_Unipol\Documentazione_SP_Rca")

    Sub New(NomeFile As String,
            Anno As Integer,
            DaImportare As Boolean,
            Optional CopiaInPatto As Boolean = False,
            Optional CopiaCome As String = "")

        mNomeFile = NomeFile
        mAnnoCompetenza = Anno
        mImportare = DaImportare
        mCopiaInPatto = CopiaInPatto
        If String.IsNullOrEmpty(CopiaCome) Then
            mCopiaCome = NomeFile
        Else
            mCopiaCome = CopiaCome
        End If
    End Sub

    Private mNomeFile As String
    Public Property NomeFile() As String
        Get
            Return mNomeFile
        End Get
        Set(value As String)
            mNomeFile = value
        End Set
    End Property

    Private mAnnoCompetenza As Integer
    Public Property AnnoCompetenza() As Integer
        Get
            Return mAnnoCompetenza
        End Get
        Set(value As Integer)
            mAnnoCompetenza = value
        End Set
    End Property

    Private mImportare As Boolean
    Public Property Importare() As Boolean
        Get
            Return mImportare
        End Get
        Set(value As Boolean)
            mImportare = value
        End Set
    End Property

    Private mCopiaInPatto As Boolean
    Public Property CopiaInPatto() As Boolean
        Get
            Return mCopiaInPatto
        End Get
        Set(value As Boolean)
            mCopiaInPatto = value
        End Set
    End Property

    Private mCopiaCome As String
    Public Property CopiaCome() As String
        Get
            Return mCopiaCome
        End Get
        Set(value As String)
            mCopiaCome = value
        End Set
    End Property

    Public Sub CopiaNellaCartellaPatto(Agenzia As String,
                                       FileScaricato As String)
        Try
            If mCopiaInPatto = True Then
                'anno dal 2012 in poi
                Dim Modello As String = String.Concat(Agenzia, mCopiaCome)
                Dim FilePatto As String = Path.Combine(UrlDoc, String.Format("{0}\{1}", mAnnoCompetenza, Modello))
                'creo la cartella se non esiste
                Directory.CreateDirectory(Directory.GetParent(FilePatto).FullName)

                If File.Exists(FileScaricato) And (Not File.Exists(FilePatto)) Then
                    File.Copy(FileScaricato, FilePatto)
                End If
            End If
        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub
End Class