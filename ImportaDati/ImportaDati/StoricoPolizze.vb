Imports System.IO
Imports System.Data.OleDb

Module StoricoPolizze

    Private Function EstraiCampi(ByVal Riga As String,
                                 ByVal DataRif As Date,
                                 ByVal Competenza As String,
                                 ByRef cmd As OleDbCommand) As Boolean
        Try
            Dim Campo(50) As String
            Dim Tmp() As String = Riga.Split(";")

            'prima del file 08/2015
            If DataRif < #8/1/2015# Then
                'elimino i primi 3 campi che non mi servono
                Array.Copy(Tmp, 3, Campo, 0, Tmp.Length - 3)
            Else
                'elimino i primi 3 campi che non mi servono e anche l'ultimo (NUM.VEICOLO) che per ora (09/2015) non importo
                Array.Copy(Tmp, 3, Campo, 0, Tmp.Length - 4)
            End If

            'trimma tutto
            TrimArray(Campo)

            'valuta prod e sub
            Campo(10) = Campo(10).PadLeft(4, Chr(48))
            Campo(12) = Campo(12).PadLeft(4, Chr(48))

            'valuta i codici sub e prod se impostati
            If FiguraRichiesta(Campo(10), Campo(12)) = False Then Return True

            'se va variata o cancellata (VR/DL) la elimino così da poter inserire l'ultima versione
            With cmd.Parameters
                .Clear()

                .AddWithValue("Agenzia", Campo(3))
                .AddWithValue("Ramo", Campo(4))
                .AddWithValue("Polizza", Campo(5))
            End With

            cmd.CommandText = "DelMovimento"
            cmd.ExecuteNonQuery()

            With cmd.Parameters
                .Clear()

                .AddWithValue("CodiceFiscale", Campo(0))
                .AddWithValue("CodiceFiscaleCF", Campo(1))
                .AddWithValue("CodiceFiscaleEA", Campo(2))
                .AddWithValue("Agenzia", Campo(3))
                .AddWithValue("Ramo", Campo(4))
                .AddWithValue("Polizza", Campo(5))
                .AddWithValue("DataEffetto", DataITA(Campo(6)))
                .AddWithValue("DataScadenza", DataITA(Campo(7)))
                .AddWithValue("DataPrimaQuietanza", DBNull.Value)
                .AddWithValue("Frazionamento", Campo(8))
                .AddWithValue("Canale", Campo(9))
                .AddWithValue("CodiceSubagente", Campo(10))
                .AddWithValue("CodiceSubagenteSima", Campo(11))
                .AddWithValue("CodiceProduttore", Campo(12))
                .AddWithValue("CodiceProduttoreSima", Campo(13))
                .AddWithValue("CodiceProdotto", Campo(14).PadLeft(5, Chr(48)))
                .AddWithValue("TotalePremioAnnuo", Campo(15) / 100)
                .AddWithValue("Targa", Campo(16))
                .AddWithValue("CavalliFiscali", Campo(17))
                .AddWithValue("Convenzione", Campo(18))
                .AddWithValue("IDStorno", Campo(19))
                .AddWithValue("DataStorno", DataITA(Campo(20)))
                .AddWithValue("TipoCarico", Campo(21))
                .AddWithValue("Clausole", Campo(22))
                .AddWithValue("TipoTariffa", Campo(23))
                .AddWithValue("ClasseBonusMalus", Campo(24))
                .AddWithValue("CombinazioneMassimali", Campo(25))
                .AddWithValue("SettoreTariffario", Campo(26))
                .AddWithValue("ValoreIncendioFurto", Campo(27) / 100)
                .AddWithValue("CodiceGaranzieAccessorie", Campo(28))
                .AddWithValue("CodiceGaranziaInfortuni", Campo(29))
                .AddWithValue("DiariaRitiroPatente", IIf(Campo(4) = 89, 0, Campo(30) / 100))
                .AddWithValue("CodiceUtilizzoVeicolo", Campo(31))
                .AddWithValue("AlimentazioneVeicolo", Campo(32))
                .AddWithValue("ProfessioneRCA", Campo(33))
                .AddWithValue("CodicePagamento", Campo(34))
                .AddWithValue("Delegataria", Campo(35))
                .AddWithValue("Quota", Campo(36) / 100)
                .AddWithValue("ClasseRca", Campo(37).Substring(1))
                .AddWithValue("UsoRca", Campo(38))
                .AddWithValue("CodiceProdottoOld", Campo(39))
                .AddWithValue("RamoGestione", Campo(40))
                .AddWithValue("TipoPolProd", Campo(41))
                .AddWithValue("ImmatricVeicolo", Campo(42))
                .AddWithValue("CompagniaSost", IIf(Campo(43) = "", 0, Campo(43)))
                .AddWithValue("AgenziaSost", Campo(44))
                .AddWithValue("RamoSost", Campo(45))
                .AddWithValue("PolizzaSost", Campo(46))
                .AddWithValue("AnnoMeseCompetenza", Competenza)
                .AddWithValue("TipoMov", Campo(48))
            End With

            cmd.CommandText = "InsMovimento"
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
            Return False
        End Try
    End Function

    Friend Function ImportaMovimentiPolizze(ByVal FileDati As String) As Boolean

        IconaNotifica.Text = String.Format("Unitools: {0}importa movimenti PTF...", Environment.NewLine)
        AddLog(">>> ImportaMovimentiPTF")

        Try
            Using cmd As New OleDbCommand

                cmd.Connection = cnArrivi

                Using da As New OleDbDataAdapter("SELECT * FROM MovPolizze", cnArrivi)

                    Using cmdBuilder As New OleDbCommandBuilder(da)

                        Try
                            With cmd
                                .CommandType = CommandType.Text

                                'non aggiungo una chiave perchè già esiste

                                'creo la stored procedure di insert
                                .CommandText = "Create Procedure InsMovimento AS " + cmdBuilder.GetInsertCommand.CommandText
                                .ExecuteNonQuery()

                                'creo la stored procedure di delete
                                .CommandText = "Create Procedure DelMovimento AS " + _
                                               "DELETE " + _
                                               "FROM MovPolizze " + _
                                               "WHERE Agenzia = ? AND Ramo = ? AND Polizza = ?"
                                .ExecuteNonQuery()
                            End With

                        Catch ex As Exception
                            'le stored esistono già
                        End Try
                    End Using
                End Using

                'imposto il cmd per l'esecuzione
                cmd.CommandType = CommandType.StoredProcedure

                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                    Dim fi As New FileInfo(FileDati)
                    Dim Competenza As String = fi.Name.Substring(15, 4) + fi.Name.Substring(13, 2)
                    Dim DataRif As Date = New DateTime(fi.Name.Substring(15, 4), fi.Name.Substring(13, 2), 1)
                    Dim NumeroRecord As Integer = 0

                    'leggo riga di intestazione
                    sr.ReadLine()

                    Do While Not sr.EndOfStream
                        If EstraiCampi(sr.ReadLine, DataRif, Competenza, cmd) = False Then Throw New System.Exception
                        NumeroRecord += 1
                        Application.DoEvents()
                    Loop

                    AggiornaCalendarioUt(mAgenzia.CodiceCollegato, _
                                         Ut.Enumerazioni.TipoFileMagia.MovimentiPTF, _
                                         DataInizioMese(DataRif), _
                                         DataFineMese(DataRif), _
                                         FileDati)

                    AddLog(String.Format(">>> Importazione {0} record completata.", NumeroRecord))
                End Using
            End Using

            Return True

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            SvuotaTabella(Ut.Enumerazioni.TipoFileMagia.MovimentiPTF)
            Return False
        End Try
    End Function

End Module
