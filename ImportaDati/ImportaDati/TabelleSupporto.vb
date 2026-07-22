Imports System.IO
Imports System.Data.OleDb

Module TabelleSupporto

    Private Sub EstraiFigure(ByVal sr As StreamReader,
                             ByRef cmd As OleDbCommand)

        AddLog(">>> Figure")
        Dim Riga As String = ""

        Try
            'figure produttive
            Dim NumeroRecord As Integer = TrovaSezione(sr, "FIGUREPRODUTTIVESETUP")

            CreaInsertCommand("FigureProduttive")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsRecord"

            For k As Integer = 1 To NumeroRecord

                Riga = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                With cmd.Parameters
                    .Clear()

                    .AddWithValue("TipoFigura", Riga.Substring(21, 1))
                    .AddWithValue("IDFiguraProduttiva", Riga.Substring(22, 4))
                    .AddWithValue("FiguraProduttiva", Riga.Substring(26, 30).Trim)
                    .AddWithValue("Canale", Riga.Substring(56, 10).Trim)
                    .AddWithValue("DataAttivazione", DataITA(Riga.Substring(66, 10)))
                    .AddWithValue("DataDisattivazione", DataITA(Riga.Substring(76, 10)))
                    .AddWithValue("Email", "")
                    .AddWithValue("Cellulare", "")
                End With

                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
        End Try

        Application.DoEvents()
    End Sub

    Private Sub EstraiComuni(ByVal sr As StreamReader,
                             ByRef cmd As OleDbCommand)

        AddLog(">>> Comuni")
        Dim Riga As String = ""

        Try
            'comuni
            Dim NumeroRecord As Integer = TrovaSezione(sr, "COMUNISETUP")

            CreaInsertCommand("Comuni")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsRecord"

            For k As Integer = 1 To NumeroRecord
                Riga = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                With cmd.Parameters
                    .Clear()

                    .AddWithValue("IDComune", Riga.Substring(21, 4))
                    .AddWithValue("Comune", Riga.Substring(25, 25))
                    .AddWithValue("Provincia", Riga.Substring(50, 2))
                    .AddWithValue("CodiceCAB", Riga.Substring(52, 5))
                End With

                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
        End Try

        Application.DoEvents()
    End Sub

    Private Sub EstraiMercatoPreferenziale(ByVal sr As StreamReader,
                                           ByRef cmd As OleDbCommand)

        AddLog(">>> MercatoPreferenziale")
        Dim Riga As String = ""

        Try
            Dim NumeroRecord As Integer = TrovaSezione(sr, "MERCATOPREFERENZIALESETUP")

            CreaInsertCommand("MercatoPreferenziale")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsRecord"

            For k As Integer = 1 To NumeroRecord
                Riga = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                With cmd.Parameters
                    .Clear()

                    .AddWithValue("Codice", Riga.Substring(21, 2))
                    .AddWithValue("SegmentoMercato", Riga.Substring(23, 30).Trim)
                End With

                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
        End Try

        Application.DoEvents()
    End Sub

    Private Sub EstraiProfessioni(ByVal sr As StreamReader,
                                  ByRef cmd As OleDbCommand)

        AddLog(">>> Professioni")
        Dim Riga As String = ""

        Try
            'professioni
            Dim NumeroRecord As Integer = TrovaSezione(sr, "PROFESSIONISETUP")

            CreaInsertCommand("Professioni")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsRecord"

            For k As Integer = 1 To NumeroRecord
                Riga = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                With cmd.Parameters
                    .Clear()

                    .AddWithValue("IDProfessione", Riga.Substring(21, 3))
                    .AddWithValue("Professione", Riga.Substring(24).Trim)
                End With

                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
        End Try

        Application.DoEvents()
    End Sub

    Private Sub EstraiProdotto(ByVal sr As StreamReader,
                               ByRef cmd As OleDbCommand)

        AddLog(">>> Prodotto")
        Dim Riga As String = ""

        Try
            'prodotti
            Dim IDSezione As String = "TIPOPRODOTTISETUP"

            Dim NumeroRecord As Integer = TrovaSezione(sr, "TIPOPRODOTTISETUP")

            CreaInsertCommand("Prodotti")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsRecord"

            For k As Integer = 1 To NumeroRecord
                Riga = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                With cmd.Parameters
                    .Clear()

                    .AddWithValue("CodiceProdotto", Riga.Substring(21, 5).Trim.PadLeft(5, Chr(48)))
                    .AddWithValue("Prodotto", Riga.Substring(26).Trim)
                End With

                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
        End Try

        Application.DoEvents()
    End Sub

    Private Sub EstraiStatiCliente(ByVal sr As StreamReader,
                                   ByRef cmd As OleDbCommand)

        AddLog(">>> StatiCliente")
        Dim Riga As String = ""

        Try
            'stati cliente
            Dim NumeroRecord As Integer = TrovaSezione(sr, "TIPOSTATICLIENTESETUP")

            CreaInsertCommand("TipoStatiCliente")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsRecord"

            For k As Integer = 1 To NumeroRecord
                Riga = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                With cmd.Parameters
                    .Clear()

                    .AddWithValue("IDStatoCliente", Riga.Substring(21, 2))
                    .AddWithValue("StatoCliente", Riga.Substring(23).Trim)
                End With

                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
        End Try

        Application.DoEvents()
    End Sub

    Private Sub EstraiTipoStorni(ByVal sr As StreamReader,
                                 ByRef cmd As OleDbCommand)

        AddLog(">>> TipoStorni")
        Dim Riga As String = ""

        Try
            'stati cliente
            Dim NumeroRecord As Integer = TrovaSezione(sr, "TIPOSTORNISETUP")

            CreaInsertCommand("TipoStorni")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsRecord"

            For k As Integer = 1 To NumeroRecord
                Riga = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                With cmd.Parameters
                    .Clear()

                    .AddWithValue("IDStorno", Riga.Substring(21, 2))
                    .AddWithValue("Storno", Riga.Substring(23).Trim)
                End With

                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
        End Try

        Application.DoEvents()
    End Sub

    Private Sub EstraiTipoRami(ByVal sr As StreamReader,
                               ByRef cmd As OleDbCommand)

        AddLog(">>> TipoRami")
        Dim Riga As String = ""

        Try
            'rami polizza
            Dim NumeroRecord As Integer = TrovaSezione(sr, "TIPORAMISETUP")

            CreaInsertCommand("TipoRami")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsRecord"

            For k As Integer = 1 To NumeroRecord
                Riga = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                With cmd.Parameters
                    .Clear()

                    .AddWithValue("CodiceRamo", Riga.Substring(21, 3))
                    .AddWithValue("Ramo", Riga.Substring(24).Trim)
                End With

                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
        End Try

        Application.DoEvents()
    End Sub

    Private Sub EstraiRamiGestione(ByVal sr As StreamReader,
                                   ByRef cmd As OleDbCommand)

        AddLog(">>> RamiGestione")
        Dim Riga As String = ""

        Try
            'rami gestione
            Dim NumeroRecord As Integer = TrovaSezione(sr, "TIPORAMIGESTSETUP")

            CreaInsertCommand("RamoGest")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsRecord"

            For k As Integer = 1 To NumeroRecord
                Riga = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                With cmd.Parameters
                    .Clear()

                    .AddWithValue("RamoGestione", Riga.Substring(21, 3))
                    .AddWithValue("DescBreve", Riga.Substring(24, 4).Trim)
                    .AddWithValue("DescRamoGest", Riga.Substring(28).Trim)
                End With

                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
        End Try

        Application.DoEvents()
    End Sub

    Private Sub EstraiRamiSinistro(ByVal sr As StreamReader,
                                   ByRef cmd As OleDbCommand)

        AddLog(">>> RamiSinistro")
        Dim Riga As String = ""

        Try
            'rami sinistro
            Dim NumeroRecord As Integer = TrovaSezione(sr, "TIPORAMISINSETUP")

            CreaInsertCommand("TipoRamiSinistro")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsRecord"

            For k As Integer = 1 To NumeroRecord
                Riga = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                With cmd.Parameters
                    .Clear()

                    .AddWithValue("RamoSinistro", Riga.Substring(21, 3))
                    .AddWithValue("DesRamoSinistro", Riga.Substring(24).Trim)
                End With

                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
        End Try

        Application.DoEvents()
    End Sub

    Private Sub EstraiTipoSinistro(ByVal sr As StreamReader,
                                   ByRef cmd As OleDbCommand)

        AddLog(">>> TipoSinistro")
        Dim Riga As String = ""

        Try
            'tipo sinistro
            Dim NumeroRecord As Integer = TrovaSezione(sr, "TIPOSINSETUP")

            CreaInsertCommand("TipoSinistro")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsRecord"

            For k As Integer = 1 To NumeroRecord
                Riga = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                With cmd.Parameters
                    .Clear()

                    .AddWithValue("RamoSinistro", Riga.Substring(21, 3))
                    .AddWithValue("TipoSinistro", Riga.Substring(24, 2).Trim)
                    .AddWithValue("DescTipoSin", Riga.Substring(26).Trim)
                End With

                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
        End Try

        Application.DoEvents()
    End Sub

    Private Sub EstraiTipoIspSinistro(ByVal sr As StreamReader,
                                      ByRef cmd As OleDbCommand)

        AddLog(">>> TipoIspSinistro (ispettorati sinistro)")

        Dim Riga As String = ""

        Try
            'clg
            Dim NumeroRecord As Integer = TrovaSezione(sr, "TIPOISPESINSETUP")

            CreaInsertCommand("Ispettorato")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsRecord"

            'inserisco un valore 0=non disponibile
            With cmd.Parameters
                .Clear()

                .AddWithValue("Ispettorato", 0)
                .AddWithValue("DescIspettorato", "NON DISPONIBILE")
            End With

            cmd.ExecuteNonQuery()

            'ciclo su tutti i record
            For k As Integer = 1 To NumeroRecord

                'tolgo le virgolette "
                Riga = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                Dim Codice As Integer = Riga.Substring(21, 5)

                'escludo il codice zero della direzione (errore di elaborazione)
                If Codice > 0 Then

                    With cmd.Parameters
                        .Clear()

                        .AddWithValue("Ispettorato", Codice)
                        .AddWithValue("DescIspettorato", Riga.Substring(26).Trim)
                    End With

                    cmd.ExecuteNonQuery()
                End If
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
        End Try

        Application.DoEvents()
    End Sub

    Private Sub EstraiCompagnia(ByVal sr As StreamReader,
                                ByRef cmd As OleDbCommand)

        AddLog(">>> Compagnia")
        Dim Riga As String = ""

        Try
            'compagnie ania
            Dim NumeroRecord As Integer = TrovaSezione(sr, "COMPAGNIAANIAINSETUP")

            CreaInsertCommand("CompagniaANIA")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsRecord"

            For k As Integer = 1 To NumeroRecord
                Riga = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                With cmd.Parameters
                    .Clear()

                    .AddWithValue("Compagnia", Riga.Substring(21, 5))
                    .AddWithValue("Desc_Compagnia", Riga.Substring(26).Trim)
                End With

                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
        End Try

        Application.DoEvents()
    End Sub

    Private Sub EstraiCarrozzeria(ByVal sr As StreamReader,
                                  ByRef cmd As OleDbCommand)

        AddLog(">>> Carrozzeria")
        Dim Riga As String = ""

        Try
            'carrozzerie
            Dim NumeroRecord As Integer = TrovaSezione(sr, "CARROZZERIAINSETUP")

            CreaInsertCommand("Carrozzeria")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsRecord"

            For k As Integer = 1 To NumeroRecord
                Riga = Replace(sr.ReadLine, Chr(34), Chr(32), , , CompareMethod.Text)

                With cmd.Parameters
                    .Clear()

                    .AddWithValue("Provincia", Riga.Substring(21, 2))
                    .AddWithValue("IdCarrozzeria", Riga.Substring(23, 9).Trim)
                    .AddWithValue("Desc_Carrozzeria", Riga.Substring(32).Trim)
                End With

                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
        End Try

        Application.DoEvents()
    End Sub

    Friend Function ImportaTabSupporto(ByVal FileDati As String) As Boolean

        IconaNotifica.Text = String.Format("Unitools: {0}importa altri dati...", Environment.NewLine)

        Try
            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                Using cmd As New OleDbCommand

                    cmd.Connection = cnArrivi

                    'l'ordine di chiamata deve essere questo e non deve essere modificato
                    EstraiFigure(sr, cmd)
                    EstraiComuni(sr, cmd)
                    EstraiMercatoPreferenziale(sr, cmd)
                    EstraiProfessioni(sr, cmd)
                    EstraiProdotto(sr, cmd)
                    EstraiStatiCliente(sr, cmd)
                    EstraiTipoStorni(sr, cmd)
                    EstraiTipoRami(sr, cmd)
                    EstraiRamiGestione(sr, cmd)
                    EstraiRamiSinistro(sr, cmd)
                    EstraiTipoSinistro(sr, cmd)
                    EstraiTipoIspSinistro(sr, cmd)
                    EstraiCompagnia(sr, cmd)
                    EstraiCarrozzeria(sr, cmd)
                End Using
            End Using

            ImportaTabSupporto = True

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            ImportaTabSupporto = False
        End Try
    End Function

    Private Sub CreaInsertCommand(ByVal Tabella As String)

        Try
            Using da As New OleDbDataAdapter("SELECT * FROM " + Tabella, cnArrivi)

                Using cmdBuilder As New OleDbCommandBuilder(da)

                    Using cmd As New OleDbCommand

                        With cmd
                            .Connection = cnArrivi
                            .CommandType = CommandType.Text

                            'cancello la stored se già esiste
                            CancellaTabella(cmd, "InsRecord")

                            'creo la stored procedure
                            .CommandText = "Create Procedure InsRecord As " + cmdBuilder.GetInsertCommand.CommandText
                            .ExecuteNonQuery()
                        End With
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
        End Try
    End Sub

    Friend Sub ImportaProvince()

        AddLog(">>> Importa province")

        Try
            Dim Errore As String = ""
            Dim dt As DataTable = WsSetting.Province(Errore).Tables("Province")

            If Errore.StartsWith("-ERR") Then
                AddLog(Errore)
                Exit Sub
            End If

            Using cmd As New OleDbCommand

                cmd.Connection = cnArrivi
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "INSERT INTO Province(Provincia,Sigla,Regione,AliquotaRca,EffettoAliquotaRca) " +
                                  "VALUES(?,?,?,?,?)"

                For Each dr As DataRow In dt.Rows

                    With cmd.Parameters
                        .Clear()

                        .AddWithValue("Provincia", dr("Provincia"))
                        .AddWithValue("Sigla", dr("Sigla"))
                        .AddWithValue("Regione", dr("Regione"))
                        .AddWithValue("AliquotaRca", dr("AliquotaRca"))
                        .AddWithValue("EffettoAliquotaRca", dr("EffettoAliquotaRca"))
                    End With

                    cmd.ExecuteNonQuery()
                Next
            End Using

        Catch ex As Exception
            AddLog(ex.Message)
        End Try

    End Sub

End Module
