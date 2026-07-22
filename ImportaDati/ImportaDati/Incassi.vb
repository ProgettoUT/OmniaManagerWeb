Imports System.IO
Imports System.Data.OleDb

Module Incassi

#Region "Dichiarazioni"
    Dim LunCampo() As Integer = {6, 5, 3, 9, 3, 10, 10, 10, 10, 1, 25, 19, 19, 5, 5, 3, 12, 4, 4, 1, _
                                 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 16}

    Private Campo(UBound(LunCampo)) As String
#End Region

    Private Function EstraiCampi2014(ByVal FileDati As String) As Boolean
        'versione con i dati aggregati per giorno per check essig

        Try
            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                Dim da As New OleDbDataAdapter("SELECT * FROM ControlloIncassi WHERE False", cnArrivi)
                Dim cmdBuilder As New OleDbCommandBuilder(da)
                da.InsertCommand = cmdBuilder.GetInsertCommand

                Dim dt As New DataTable
                da.Fill(dt)

                'leggo la riga di intestazione
                Dim TestataFile() As String = sr.ReadLine().Split(Chr(124)) 'carattere pipe |

                Dim Anno As Integer = CDate(TestataFile(4)).Year
                Dim Mese As Integer = CDate(TestataFile(4)).Month
                Dim Agenzia As Integer = TestataFile(2)

                Dim Record(DateTime.DaysInMonth(Anno, Mese), 2) As Double
                Dim Contatore As Integer = 0

                'analizzo le righe e trasferisco i dati in un array.
                'Gli incassi NON sono in ordine di data ma di ramo/polizza
                Do While Not sr.EndOfStream

                    'sostituisco le virgolette con uno spazio perchè danno fastidio nelle query
                    'uso lo spazio per non alterare la posizione dei campi
                    Dim Riga As String = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                    'estrae le sottostringhe trimmandole e mettendole nella matrice
                    SplitTesto(Riga, 0, LunCampo, Campo)

                    Campo(17) = Campo(17).PadLeft(4, Chr(48))
                    Campo(18) = Campo(18).PadLeft(4, Chr(48))

                    'valuta i codici sub e prod se impostati
                    If FiguraRichiesta(Campo(17), Campo(18)) = True Then

                        Dim Giorno As Integer = CDate(Campo(8)).Day

                        Record(Giorno, 0) += 1
                        Record(Giorno, 1) += CDbl(Campo(20)) + CDbl(Campo(21)) + CDbl(Campo(22))
                        Record(Giorno, 2) += Campo(11)
                    End If

                    Contatore += 1
                Loop

                'trasferisco l'array nella dt
                For Giorno As Integer = 1 To Record.GetUpperBound(0)

                    Dim dr As DataRow = dt.NewRow

                    dr("Agenzia") = Agenzia
                    dr("DataFoglioCassa") = New DateTime(Anno, Mese, Giorno).Date
                    dr("NumeroRecord") = Record(Giorno, 0)
                    dr("Tassabile") = Record(Giorno, 1)
                    dr("TotaleLordo") = Record(Giorno, 2)
                    dr("NumeroCorrezioni") = 0
                    dr("Ignora") = False

                    dt.Rows.Add(dr)
                Next

                da.Update(dt)

                dt.Dispose()
                cmdBuilder.Dispose()
                da.Dispose()

                'controllo numero record incassi del mese
                If CInt(TestataFile(8)) = Contatore Then
                    AddLog(String.Format("Ok: Incassi importati {0} su {1}", Contatore, TestataFile(8)))
                Else
                    LogErrori(String.Format("Errore: {0}", FileDati))
                    LogErrori(String.Format("Incassi importati {0} su {1}", Contatore, TestataFile(8)))
                    Throw New System.Exception
                End If

                AddLog(String.Format("Ok: Verificati incassi mese {0}-{1}", Mese, Anno))
            End Using

            Return True

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            Return False
        End Try

    End Function

    'Private Function EstraiCampi(ByVal FileDati As String) As Boolean

    '    Dim dt As New DataTable
    '    Dim sr As New StreamReader(FileDati, System.Text.Encoding.Default)

    '    Try
    '        Dim da As New OleDbDataAdapter("SELECT * FROM Incassi WHERE False", cnArrivi)
    '        Dim cmdBuilder As New OleDbCommandBuilder(da)
    '        da.InsertCommand = cmdBuilder.GetInsertCommand

    '        da.Fill(dt)

    '        'apro lo stream e leggo la prima riga con il nome dei campi
    '        Dim TestataFile() As String = sr.ReadLine().Split(Chr(124)) 'carattere pipe |

    '        Dim Contatore As Integer = 0

    '        Do While Not sr.EndOfStream

    '            'sostituisco le virgolette con uno spazio perchè danno fastidio nelle query
    '            'uso lo spazio per non alterare la posizione dei campi
    '            Dim Riga As String = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

    '            'estrae le sottostringhe trimmandole e mettendole nella matrice
    '            SplitTesto(Riga, 0, LunCampo, Campo)

    '            Campo(17) = Campo(17).PadLeft(4, Chr(48))
    '            Campo(18) = Campo(18).PadLeft(4, Chr(48))

    '            'valuta i codici sub e prod se impostati
    '            If FiguraRichiesta(Campo(17), Campo(18)) = True Then

    '                Dim dr As DataRow = dt.NewRow

    '                dr("AnnoMeseCompetenza") = Campo(0)
    '                dr("Agenzia") = Campo(1)
    '                dr("Ramo") = Campo(2)
    '                dr("Polizza") = Campo(3)
    '                dr("NumeroAppendice") = Campo(4)
    '                dr("DataEffettoAppendice") = DataITA(Campo(5))
    '                dr("DataEffettoTitolo") = DataITA(Campo(6))
    '                dr("DataScadenzaTitolo") = DataITA(Campo(7))
    '                dr("DataFoglioCassa") = DataITA(Campo(8))
    '                dr("TipoCarico") = Campo(9)
    '                dr("Contraente") = Campo(10)
    '                dr("TotaleTitolo") = Campo(11)
    '                dr("TotaleProvvigioni") = Campo(12)
    '                dr("CodiceProdotto") = Campo(13).PadLeft(5, Chr(48))
    '                dr("Convenzione") = Campo(14)
    '                dr("Delegataria") = Campo(15)
    '                dr("NostraQuota") = Campo(16)
    '                dr("CodiceSubAgente") = Campo(17)
    '                dr("CodiceProduttore") = Campo(18)
    '                dr("Frazionamento") = Campo(19)
    '                dr("PremioNetto") = Campo(20)
    '                dr("InteressiFraz") = Campo(21)
    '                dr("Accessori") = Campo(22)
    '                dr("ProvvAcqC") = Campo(23)
    '                dr("ProvvAcqs") = Campo(24)
    '                dr("Provvinc") = Campo(25)
    '                dr("ProvvAcqCSub") = Campo(26)
    '                dr("ProvvIncSub") = Campo(27)
    '                dr("ProvvAcqCProd") = Campo(28)
    '                dr("ProvvIncProd") = Campo(29)
    '                dr("ConvenzProvvAcq") = Campo(30)
    '                dr("ConvenzProvvInc") = Campo(31)
    '                dr("CapoMaglia1Acq") = Campo(32)
    '                dr("CapoMaglia1Inc") = Campo(33)
    '                dr("CapoMaglia2Acq") = Campo(34)
    '                dr("CapoMaglia2Inc") = Campo(35)
    '                dr("PremioTass") = Campo(36)
    '                dr("PremioTasso") = Campo(37)
    '                dr("CodiceFiscInc") = Campo(38)
    '                dr("Targa") = ""
    '                dr("RamoGestione") = 0

    '                dt.Rows.Add(dr)
    '            End If

    '            Contatore += Contatore
    '        Loop

    '        'controllo numero record incassi del mese
    '        If CInt(TestataFile(8)) = Contatore Then
    '            AddLog(String.Format("Ok: Incassi importati {0} su {1}", Contatore, TestataFile(8)))
    '        Else
    '            LogErrori(String.Format("Errore: {0}", FileDati))
    '            LogErrori(String.Format("Incassi importati {0} - Incassi previsti {1}", Contatore, TestataFile(8)))
    '            Throw New System.Exception
    '        End If

    '        da.Update(dt)

    '        dt.Dispose()
    '        cmdBuilder.Dispose()
    '        da.Dispose()

    '        Return True

    '    Catch ex As Exception
    '        BoxErrore(ex)
    '        LogDataTable(dt, Campo)
    '        Return False
    '    Finally
    '        sr.Close()
    '    End Try

    'End Function

    Friend Sub ImportaIncassi(ByVal FileDati As String)

        IconaNotifica.Text = String.Format("Unitools: {0}importa incassi...", Environment.NewLine)
        AddLog(">>> ImportaIncassi")

        Try
            If EstraiCampi2014(FileDati) = False Then Throw New System.Exception

            'apro lo stream e leggo la prima riga con il nome dei campi
            Dim sr As New StreamReader(FileDati, System.Text.Encoding.Default)
            Dim TestataFile() As String = sr.ReadLine().Split(Chr(124)) 'carattere pipe |

            sr.Close()
            sr.Dispose()

            AggiornaCalendarioUt(mAgenzia.CodiceCollegato, _
                                 Ut.Enumerazioni.TipoFileMagia.Incassi, _
                                 CDate(TestataFile(4)), _
                                 CDate(TestataFile(5)), _
                                 FileDati)

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            SvuotaTabella(Ut.Enumerazioni.TipoFileMagia.Incassi)
        End Try

    End Sub

End Module
