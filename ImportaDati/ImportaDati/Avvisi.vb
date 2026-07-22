Imports System.IO
Imports System.Data.OleDb

Module Avvisi

#Region "Dichiarazioni"
    Dim LunCampoUnipol() As Integer = {1, 5, 3, 9, 3, 7, 5, 5, 3, 1, 5, 5, 5, 16, 67, 3, 5, 1, 2, _
                                       1, 9, 8, 1, 2, 16, 16, 16, 12, 12, 12, 12, 1, 8, 1, 20, 3, 40, _
                                       3, 1, 3, 3, 3, 1, 10, 1, 10, 3, 3, 3, 11, 11, 11, 11, 11, 11, 2}

    Dim LunCampoAurora() As Integer = {1, 5, 3, 9, 3, 7, 5, 5, 3, 1, 5, 5, 5, 16, 67, 3, 5, 1, 2, _
                                       1, 9, 8, 1, 2, 16, 16, 16, 12, 12, 12, 12, 1, 8, 1}
#End Region

    Private Function EstraiCampi(ByVal Riga As String,
                                 ByVal TipoFile As TipoFileMagia,
                                 ByRef cmd As OleDbCommand) As Boolean

        Dim Campo(UBound(LunCampoUnipol)) As String
        Dim Anag() As String

        Try
            'sostituisco le virgolette con uno spazio perchè danno fastidio nelle query
            'uso lo spazio per non alterare la posizione dei campi
            'attenzione: aggiungo 2 spazi bianchi per gli avvisi vita che sono più corti di 2 caratteri
            Riga = Replace(Riga + Space(2), Chr(34), Chr(32), , , CompareMethod.Text)

            Dim Compagnia As Integer = Left(Riga, 1)

            'estrae le sottostringhe trimmandole e mettendole nella matrice
            If (Glo.Impo.CodAgenzia < 10000) OrElse _
               (Glo.Impo.CodAgenzia > 10000 AndAlso TipoFile = TipoFileMagia.Avvisi) Then

                SplitTesto(Riga, 0, LunCampoUnipol, Campo)

            Else 'vita aurora/navale
                SplitTesto(Riga, 0, LunCampoAurora, Campo)
            End If

            'subagenzia lunghezza 3 e prod lunghezza 7: li normalizzo a 4
            Campo(4) = Campo(4).PadLeft(4, "0")
            Campo(5) = Campo(5).Substring(3)

            'valuta i codici sub e prod se impostati
            'negli avvisi il codice produttore è assente
            If FiguraRichiesta(Campo(4), Campo(5)) = False Then Return True

            With cmd.Parameters
                .Clear()

                .AddWithValue("Compagnia", Campo(0))
                .AddWithValue("Agenzia", Campo(1))
                .AddWithValue("Ramo", Campo(2))
                .AddWithValue("Polizza", Campo(3))
                .AddWithValue("SubAgenzia", Campo(4))
                .AddWithValue("Produttore", Campo(5))
                .AddWithValue("ConvenzioneProvv", Campo(6))
                .AddWithValue("Convenzione", Campo(7))
                .AddWithValue("Appendice", Campo(8))
                .AddWithValue("Frazionamento", Campo(9))
                .AddWithValue("Prodotto", Campo(10))
                '11-tipopolprod
                .AddWithValue("TipoCliente", Campo(12))
                .AddWithValue("CodiceFiscale", Campo(13))

                'gestione anagrafica----------------------
                Anag = Campo(14).Split(Chr(42)) 'carattere asterisco *

                .AddWithValue("Contraente", Left(Anag(0).Trim, 40))

                'indirizzo cap e località potrebbero anche mancare o essere troncati
                If UBound(Anag) >= 1 Then
                    If Anag(1).Trim.Length > 0 Then
                        .AddWithValue("Indirizzo", Left(Anag(1).Trim, 50))
                    Else
                        .AddWithValue("Indirizzo", "")
                    End If
                Else
                    .AddWithValue("Indirizzo", "")
                End If

                If UBound(Anag) = 2 Then
                    'cap
                    If Anag(2).Length >= 5 Then
                        .AddWithValue("Cap", Anag(2).Substring(0, 5))
                    Else
                        .AddWithValue("Cap", "00000")
                    End If
                    'località
                    If Anag(2).Length > 5 Then
                        .AddWithValue("Localita", Left(Anag(2).Substring(6), 30).Trim)
                    Else
                        .AddWithValue("Localita", "")
                    End If
                Else
                    .AddWithValue("Cap", "00000")
                    .AddWithValue("Localita", "")
                End If
                '------------------------------------------

                .AddWithValue("Provincia", "")
                .AddWithValue("Sesso", CfToSesso(Campo(13))) 'ricavo da CF
                .AddWithValue("Delegataria", Campo(15))
                .AddWithValue("Quota", Campo(16) / 100)
                .AddWithValue("FlagMigrazione", Campo(17))
                '18-filler
                .AddWithValue("TipoQT", Campo(19))
                .AddWithValue("NumeroQT", Campo(20))
                .AddWithValue("EffettoRata", DataITA(DataAsciToIT(Campo(21))))
                .AddWithValue("FlagScadenzaAnnuale", Campo(22))
                '23-GiornoScadenza
                .AddWithValue("PremioRataNetto", Campo(24) / 100)
                .AddWithValue("Accessori", Campo(25) / 100)
                .AddWithValue("PremioRataLordo", Campo(26) / 100)
                .AddWithValue("ProvvAcquisto", Campo(27) / 100)
                .AddWithValue("ProvvIncasso", Campo(28) / 100)
                .AddWithValue("ProvvIncassoSub", Campo(29) / 100)
                .AddWithValue("ProvvAcquistoSub", Campo(30) / 100)
                .AddWithValue("TipoPolArd", Campo(31))
                .AddWithValue("ScadenzaRata", DataITA(DataAsciToIT(Campo(32))))
                .AddWithValue("TipoOrd", Campo(33))

                'i campi seguenti mancano nei file avvisi vita di aurora
                If (Glo.Impo.CodAgenzia > 10000) AndAlso (TipoFile = TipoFileMagia.AvvisiVita) Then
                    .AddWithValue("Targa", "")
                    .AddWithValue("Marca", "")
                    .AddWithValue("Modello", "")
                    .AddWithValue("TipoPagamento", 0)
                    .AddWithValue("StampaDirezione", "")
                    .AddWithValue("IdCriterioSel", 0)
                    .AddWithValue("PrioritaCriterioSel", 0)
                    .AddWithValue("IdModelloStampa", 0)
                    .AddWithValue("FranchigiaFruttuosa", "")
                    .AddWithValue("CauzioneFranFru", 0)
                    .AddWithValue("UniboxAurobox", "")
                    .AddWithValue("CanoneBox", 0)
                    .AddWithValue("TipoComunicazione", 0)
                    .AddWithValue("CodMsgDirezione", 0)
                    .AddWithValue("CodMsgAgenzia", 0)
                    .AddWithValue("MassimaleSinistroPreqt", 0)
                    .AddWithValue("MassimalePersonePreqt", 0)
                    .AddWithValue("MassimaleCoseAnimaliPreqt", 0)
                    .AddWithValue("MassimaleSinistroPostqt", 0)
                    .AddWithValue("MassimalePersonePostqt", 0)
                    .AddWithValue("MassimaleCoseAnimaliPostqt", 0)
                    .AddWithValue("RiformaMassimali", "")
                Else
                    .AddWithValue("Targa", Campo(34))
                    .AddWithValue("Marca", Campo(35))
                    .AddWithValue("Modello", Campo(36))
                    .AddWithValue("TipoPagamento", Campo(37))
                    .AddWithValue("StampaDirezione", Campo(38))
                    .AddWithValue("IdCriterioSel", Campo(39))
                    .AddWithValue("PrioritaCriterioSel", Campo(40))
                    .AddWithValue("IdModelloStampa", Campo(41))
                    .AddWithValue("FranchigiaFruttuosa", Campo(42))
                    .AddWithValue("CauzioneFranFru", Campo(43) / 100)
                    .AddWithValue("UniboxAurobox", Campo(44))
                    .AddWithValue("CanoneBox", Campo(45) / 100)
                    .AddWithValue("TipoComunicazione", Campo(46))
                    .AddWithValue("CodMsgDirezione", Campo(47))
                    .AddWithValue("CodMsgAgenzia", Campo(48))
                    .AddWithValue("MassimaleSinistroPreqt", Campo(49) / 100)
                    .AddWithValue("MassimalePersonePreqt", Campo(50) / 100)
                    .AddWithValue("MassimaleCoseAnimaliPreqt", Campo(51) / 100)
                    .AddWithValue("MassimaleSinistroPostqt", Campo(52) / 100)
                    .AddWithValue("MassimalePersonePostqt", Campo(53) / 100)
                    .AddWithValue("MassimaleCoseAnimaliPostqt", Campo(54) / 100)
                    'può essere di 1 carattere negli avvisi vita o 2 nei danni
                    .AddWithValue("RiformaMassimali", Campo(55))
                End If
            End With

            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            BoxErrore(ex)
            LogParametri(Riga, cmd.Parameters)
            Return False
        End Try
    End Function

    Friend Sub ImportaAvvisi(ByVal FileDati As String, ByVal TipoFile As TipoFileMagia)
        IconaNotifica.Text = "Unitools: importa avvisi..."
        AddLog(">>> ImportaAvvisi")

        Using cmd As New OleDbCommand

            cmd.Connection = cnArrivi

            Using da As New OleDbDataAdapter("SELECT * FROM Avvisi", cnArrivi)

                Using cmdBuilder As New OleDbCommandBuilder(da)

                    'creo la stored procedure
                    Try
                        cmdBuilder.QuotePrefix = "["
                        cmdBuilder.QuoteSuffix = "]"

                        With cmd
                            .CommandType = CommandType.Text
                            .CommandText = "Create Procedure InsAvviso As " + cmdBuilder.GetInsertCommand.CommandText

                            .ExecuteNonQuery()
                        End With
                    Catch ex As Exception
                        'la stored c'è già
                    End Try
                End Using
            End Using

            'imposto il cmd per l'esecuzione
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "InsAvviso"

            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                Try
                    'START FILE|AURORA|01949|01|01/11/2008|30/11/2008|1|1|406|1|184730|01949_novembre_2008|N|N|N|14/10/2008
                    Dim TestataFile() As String = sr.ReadLine().Split(Chr(124))

                    Dim DataInizio As Date = CDate(TestataFile(4))
                    Dim DataFine As Date = CDate(TestataFile(5))

                    Do While Not sr.EndOfStream
                        If EstraiCampi(sr.ReadLine, TipoFile, cmd) = False Then Throw New System.Exception
                        Application.DoEvents()
                    Loop

                    AggiornaCalendarioUt(Glo.Impo.CodAgenzia, _
                                         TipoFile, _
                                         DataInizio, _
                                         DataFine, _
                                         FileDati)

                Catch ex As Exception
                    BoxErrore(ex)
                    SvuotaTabella(TipoFile)
                End Try

                sr.Close()
            End Using
        End Using
    End Sub

End Module
