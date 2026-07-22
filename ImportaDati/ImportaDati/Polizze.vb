Imports System.IO
Imports System.Data.OleDb

Module Polizze

#Region "Dichiarazioni"
    'lunghezza dei campi
    Private LunCampo() As Integer = {21, 16, 16, 16, 5, 3, 9, 10, 10, 1, 10, 4, 4, 4, 4, 5, _
                                     21, 11, 9, 3, 5, 2, 10, 1, 41, 1, 3, 3, 1, 9, 2, _
                                     2, 7, 1, 1, 2, 3, 3, 5, 6, 3, 2}
#End Region

    Private Function EstraiCampi(ByVal FileDati As String) As Boolean

        Dim Campo(UBound(LunCampo)) As String
        Dim dt As New DataTable

        Try
            Dim da As New OleDbDataAdapter("SELECT * FROM Polizze WHERE False", cnArrivi)
            Dim cmdBuilder As New OleDbCommandBuilder(da)
            da.InsertCommand = cmdBuilder.GetInsertCommand
            da.Fill(dt)

            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                Dim IDSezione As String = "POLIZZESETUP"
                Dim NumeroRecord As Integer = TrovaSezione(sr, IDSezione)

                For k As Integer = 1 To NumeroRecord

                    Dim Riga As String = sr.ReadLine.Substring(0, 138) + sr.ReadLine

                    'estrae le sottostringhe trimmandole e mettendole nella matrice
                    SplitTesto(Riga, 0, LunCampo, Campo)

                    'in alcuni casi il codice fiscale è vuoto (polizze molto vecchie)
                    If Campo(1).Trim.Length > 0 Then

                        'produttore e sub 
                        Campo(11) = Campo(11).PadLeft(4, "0")
                        Campo(13) = Campo(13).PadLeft(4, "0")

                        'valuta i codici sub e prod se impostati
                        If FiguraRichiesta(Campo(11), Campo(13), Campo(4)) = True Then

                            Dim dr As DataRow = dt.NewRow

                            'il campo 0 è l'intestazione della prima riga
                            dr("CodiceFiscale") = Campo(1)
                            dr("CodiceFiscaleCF") = Campo(2)
                            dr("CodiceFiscaleEA") = Campo(3)
                            dr("Agenzia") = Campo(4)
                            dr("Ramo") = Campo(5)
                            dr("Polizza") = Campo(6)
                            dr("DataEffetto") = DataITA(Campo(7))
                            dr("DataScadenza") = DataITA(Campo(8))
                            dr("DataPrimaQuietanza") = DBNull.Value 'data prima quietanza nel file non c'è
                            dr("Frazionamento") = Campo(9)
                            dr("Canale") = Campo(10)
                            dr("CodiceSubagente") = Campo(11)
                            dr("CodiceSubagenteSima") = Campo(12)
                            dr("CodiceProduttore") = Campo(13)
                            dr("CodiceProduttoreSima") = Campo(14)
                            dr("CodiceProdotto") = Campo(15).PadLeft(5, "0")
                            'il campo 16 è l'intestazione della seconda riga
                            dr("TotalePremioAnnuo") = Campo(17) / 100
                            dr("Targa") = Campo(18)
                            dr("CavalliFiscali") = Campo(19)
                            dr("Convenzione") = Campo(20)
                            dr("IDStorno") = Campo(21)
                            dr("DataStorno") = DataITA(Campo(22))
                            dr("TipoCarico") = Campo(23)
                            dr("Clausole") = Campo(24)
                            dr("TipoTariffa") = Campo(25)
                            dr("ClasseBonusMalus") = Campo(26)
                            dr("CombinazioneMassimali") = Campo(27)
                            dr("SettoreTariffario") = Campo(28)
                            dr("ValoreIncendioFurto") = Campo(29) / 100
                            dr("CodiceGaranzieAccessorie") = Campo(30)
                            dr("CodiceGaranziaInfortuni") = Campo(31)
                            dr("DiariaRitiroPatente") = IIf(Campo(5) = 89, 0, Campo(32) / 100)
                            dr("CodiceUtilizzoVeicolo") = Campo(33)
                            dr("AlimentazioneVeicolo") = Campo(34)
                            dr("ProfessioneRCA") = Campo(35)
                            dr("CodicePagamento") = Campo(36)
                            dr("CodiceProdottoOld") = "" 'nel file il campo non c'è
                            dr("ClasseRca") = Campo(40).Substring(1)
                            dr("UsoRca") = Campo(41)
                            dr("RamoGestione") = Campo(37)
                            dr("TipoPolProd") = Campo(38)
                            dr("ImmatricVeicolo") = Campo(39)

                            dt.Rows.Add(dr)
                        End If
                    End If
                Next

                da.Update(dt)

                dt.Dispose()
                cmdBuilder.Dispose()
                da.Dispose()
            End Using

            ControlloPolizzeDuplicate()

            Return True

        Catch ex As Exception
            BoxErrore(ex)
            LogDataTable(dt, Campo)
            Return False
        End Try
    End Function

    Friend Function ImportaPolizze(ByVal FileDati As String) As Boolean

        IconaNotifica.Text = String.Format("Unitools: {0}importa polizze...", Environment.NewLine)
        AddLog(">>> Polizze")

        Return EstraiCampi(FileDati)
    End Function

    Private Sub ControlloPolizzeDuplicate()

        Try
            Using cmd As New OleDb.OleDbCommand

                cmd.Connection = cnArrivi
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT DISTINCT A.Agenzia,A.Ramo,A.Polizza,B.Numero " +
                                  "FROM Polizze AS A " +
                                  "INNER JOIN " +
                                      "(SELECT Count(*) AS Numero,Agenzia,Ramo,Polizza " +
                                       "FROM Polizze " +
                                       "GROUP BY Agenzia,Ramo,Polizza " +
                                       "HAVING Count(*) > 1) AS B " +
                                  "ON A.Agenzia = B.Agenzia AND A.Ramo = B.Ramo AND A.Polizza = B.Polizza"

                Dim dr As OleDbDataReader = cmd.ExecuteReader

                If dr.HasRows Then

                    Using cmdDel As New OleDbCommand

                        'elimino duplicate
                        Dim Query = "DELETE FROM (SELECT TOP {0} * " +
                                                 "FROM Polizze " +
                                                 "WHERE Agenzia = ? AND Ramo = ? AND Polizza = ?)"

                        cmdDel.Connection = cnArrivi
                        cmdDel.CommandType = CommandType.Text

                        Do While dr.Read

                            Log.AddLog(String.Format("Polizza duplicata {3} volte: {0}/{1}/{2}",
                                                     dr("Agenzia"), dr("Ramo"), dr("Polizza"), dr("Numero")))

                            cmdDel.CommandText = String.Format(Query, dr("Numero") - 1)

                            cmdDel.Parameters.Clear()
                            cmdDel.Parameters.AddWithValue("Agenzia", dr("Agenzia"))
                            cmdDel.Parameters.AddWithValue("Ramo", dr("Ramo"))
                            cmdDel.Parameters.AddWithValue("Polizza", dr("Polizza"))

                            Log.AddLog(String.Format("Eliminati {0} doppioni", cmdDel.ExecuteNonQuery()))
                        Loop
                    End Using
                End If

                dr.Close()
            End Using

        Catch ex As Exception
            BoxErrore(ex)
        End Try

    End Sub

End Module
