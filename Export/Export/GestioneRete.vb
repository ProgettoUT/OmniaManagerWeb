Imports System.Net
Imports System.IO
Imports System.Data

Public Class GestioneRete

    Public Enum TipoLista
        CIP = 0
        SOGG = 1
        UTENZ = 2
        PVEND = 3
    End Enum

    Public OpzioniScarico As ExportLib.ConfigScaricoIncassi

    Private WithEvents e As New ExportEventArgs
    Private WithEvents Essig As RichiesteEssig
    Private ds As DataSet

    Sub New()
    End Sub

    Public Function AggiornaListe() As Boolean
        Try
            Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.LISTE, RichiesteEssig.TipoCompagnia.UNIPOL)

            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy

                For Each Agenzia As String In OpzioniScarico.CodiciDaScaricare.Split("/")
                    'inizializzo dataset
                    ds = s.CreaDataSetVuoto(Agenzia, {"CIP", "Utenze", "Soggetti", "Punti_Vendita"}, Utx.Globale.Token)

                    Essig.Compagnia = RichiesteEssig.TipoCompagnia.UNIPOL

                    ImportaCIP(Agenzia)
                    If e.Errore = True Then Globale.Log.Info(e.Messaggio) : Return False
                    ImportaUtenze(Agenzia)
                    If e.Errore = True Then Globale.Log.Info(e.Messaggio) : Return False
                    ImportaSoggetti(Agenzia)
                    If e.Errore = True Then Globale.Log.Info(e.Messaggio) : Return False
                    ImportaPuntiVendita(Agenzia)
                    If e.Errore = True Then Globale.Log.Info(e.Messaggio) : Return False

#If DEBUG Then
                    Dim Config As New Utx.ConfigAgenzia(1, Agenzia)
                    'se esiste un codice unisalute collegato ad agenzia
                    If String.IsNullOrEmpty(Config.CodiceUnisalute) = False Then
                        Essig.Compagnia = RichiesteEssig.TipoCompagnia.UNISALUTE

                        ImportaCIP(Config.CodiceUnisalute)
                        If e.Errore = True Then Globale.Log.Info(e.Messaggio) : Return False
                        ImportaUtenze(Config.CodiceUnisalute)
                        If e.Errore = True Then Globale.Log.Info(e.Messaggio) : Return False
                        ImportaSoggetti(Config.CodiceUnisalute)
                        If e.Errore = True Then Globale.Log.Info(e.Messaggio) : Return False
                        ImportaPuntiVendita(Config.CodiceUnisalute)
                        If e.Errore = True Then Globale.Log.Info(e.Messaggio) : Return False
                    End If

                    Dim f As New Utx.FormDebug(ds.Tables("cip"))
                    f.ShowDialog()
                    f.OrigineDati = ds.Tables("soggetti")
                    f.ShowDialog()
                    f.OrigineDati = ds.Tables("puntivendita")
                    f.ShowDialog()
                    f.OrigineDati = ds.Tables("utenze")
                    f.ShowDialog()
#End If

                    'i nomi delle tabelle del dataset sono l'id dell'evento
                    Utx.OmWeb.InviaDataSet(Agenzia, ds)
                Next
            End Using

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Function ScaricaFile(Lista As TipoLista,
                                 Agenzia As String) As String
        Try
            'chiamo il menù: necessario per settaggio parametri
            Essig.ChiamaMenu()
            If Essig.EventArgs.Errore = True Then
                e = Essig.EventArgs
                Return ""
            End If

            'richiedo i dati
            Essig.RichiestaDati(Lista.ToString, Agenzia)
            If Essig.EventArgs.Errore = True Then
                e = Essig.EventArgs
                Return ""
            End If

            'esporto il file dati in formato csv
            Dim FileDati As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, $"Lista.{Lista}.csv")
            If Essig.EventArgs.Errore = True Then
                e = Essig.EventArgs
                Return ""
            End If

            'salvo il file
            Using sw As New StreamWriter(FileDati)
                sw.Write(Essig.EsportaDati)
            End Using

            Return FileDati

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
            Return ""
        End Try
    End Function

    Private Sub ImportaCIP(Agenzia As String)
        Try
            Globale.Log.Info($"Importazione CIP codice {Agenzia}")

            Dim FileDati As String = ScaricaFile(TipoLista.CIP, Agenzia)
            If e.Errore Then Exit Sub
            AddToPacchettoZip(Agenzia, FileDati)

            'pulisco il file da eventuali null
            ClearFileFromNull(FileDati)
            File.WriteAllText(FileDati, File.ReadAllText(FileDati).Replace("=""", "").Replace(""";", ";"))

            Dim dt As DataTable = ds.Tables("CIP")

            'apro lo stream
            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                'leggo la prima riga con il nome dei campi
                sr.ReadLine()

                Do While Not sr.EndOfStream
                    Dim Campi() As String = sr.ReadLine.Split(";")

                    'trimma tutto
                    TrimArray(Campi)

                    Dim dr As DataRow = dt.NewRow

                    dr("Compagnia") = Campi(Tracciati.CIP.Compagnia)
                    dr("Agenzia") = Campi(Tracciati.CIP.Agenzia)
                    dr("Cip") = Campi(Tracciati.CIP.Cip)
                    dr("DeskCip") = Left(Campi(Tracciati.CIP.DeskCip), 40)
                    dr("CognomeComponente") = Left(Campi(Tracciati.CIP.CognomeComponente), 40)
                    dr("NomeComponente") = Left(Campi(Tracciati.CIP.NomeComponente), 20)
                    dr("PuntoVendita") = Campi(Tracciati.CIP.PuntoVendita)
                    dr("RegimeFiscale") = Campi(Tracciati.CIP.RegimeFiscale)
                    dr("DeskRegimeFiscale") = Left(Campi(Tracciati.CIP.DeskRegimeFiscale), 20)
                    dr("EstrattoConto") = Campi(Tracciati.CIP.EstrattoConto)
                    dr("Flessibilita") = Campi(Tracciati.CIP.Flex)
                    dr("DerogaAgenzia") = Campi(Tracciati.CIP.DerogaAgenzia)
                    dr("DerogaPolizza") = Campi(Tracciati.CIP.DerogaPolizza)
                    dr("CognomeSoggetto") = Left(Campi(Tracciati.CIP.CognomeSoggetto), 40)
                    dr("NomeSoggetto") = Left(Campi(Tracciati.CIP.NomeSoggetto), 20)
                    dr("CfComponente") = Campi(Tracciati.CIP.CfComponente)
                    dr("CfSoggetto") = Campi(Tracciati.CIP.CfSoggetto)
                    dr("Ruolo") = Campi(Tracciati.CIP.Ruolo)
                    dr("DeskRuolo") = Left(Campi(Tracciati.CIP.DeskRuolo), 22)
                    dr("PD00") = Campi(Tracciati.CIP.PD00)
                    dr("EnteGestore") = Campi(Tracciati.CIP.EnteGestore)
                    dr("AgenziaMadre") = Campi(Tracciati.CIP.AgenziaMadre)
                    dr("DataInizio") = Utx.FunzioniDb.Str2Data(Campi(Tracciati.CIP.DataInizio))
                    dr("DataFine") = Utx.FunzioniDb.Str2Data(Campi(Tracciati.CIP.DataFine))
                    dr("CaricoProvv") = Campi(Tracciati.CIP.CaricoProvv)
                    dr("TipoCip") = Left(Campi(Tracciati.CIP.TipoCip), 12)
                    dr("TipoSede") = Left(Campi(Tracciati.CIP.TipoSede), 20)
                    dr("NumeroRegistro") = Campi(Tracciati.CIP.NumeroRegistro)
                    dr("DataRegistro") = Utx.FunzioniDb.Str2Data(Campi(Tracciati.CIP.DataRegistro))
                    dr("Flex") = Campi(Tracciati.CIP.Flex)
                    dr("FlexInizio") = Utx.FunzioniDb.Str2Data(Campi(Tracciati.CIP.FlexInizio))
                    dr("FlexFine") = Utx.FunzioniDb.Str2Data(Campi(Tracciati.CIP.FlexFine))
                    dr("Selezionato") = dr("DataFine") Is DBNull.Value

                    dt.Rows.Add(dr)
                Loop
            End Using
            Globale.Log.Info(String.Format("Agenzia {0} - CIP importati: {1}", Agenzia, dt.Rows.Count))
            File.Delete(FileDati)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Errore = True
        End Try
    End Sub

    Private Sub ImportaSoggetti(Agenzia As String)
        Try
            Globale.Log.Info($"Importazione SOGGETTI codice {Agenzia}")

            Dim FileDati As String = ScaricaFile(TipoLista.SOGG, Agenzia)
            If e.Errore Then Exit Sub
            AddToPacchettoZip(Agenzia, FileDati)

            'pulisco il file da eventuali null
            ClearFileFromNull(FileDati)
            File.WriteAllText(FileDati, File.ReadAllText(FileDati).Replace("=""", "").Replace(""";", ";"))

            Dim dt As DataTable = ds.Tables("SOGGETTI")

            'apro lo stream
            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                'leggo la prima riga con il nome dei campi
                sr.ReadLine()

                Do While Not sr.EndOfStream
                    Dim Campi() As String = sr.ReadLine.Split(";")

                    'trimma tutto
                    TrimArray(Campi)

                    Dim dr As DataRow = dt.NewRow

                    dr("Compagnia") = Campi(Tracciati.SOGGETTI.Compagnia)
                    dr("Agenzia") = Campi(Tracciati.SOGGETTI.Agenzia)
                    dr("EnteGestore") = Campi(Tracciati.SOGGETTI.EnteGestore)
                    dr("CfSoggetto") = Campi(Tracciati.SOGGETTI.CfSoggetto)
                    dr("CognomeSoggetto") = Left(Campi(Tracciati.SOGGETTI.CognomeSoggetto), 40)
                    dr("NomeSoggetto") = Left(Campi(Tracciati.SOGGETTI.NomeSoggetto), 20)
                    dr("CfComponente") = Campi(Tracciati.SOGGETTI.CfComponente)
                    dr("CognomeComponente") = Left(Campi(Tracciati.SOGGETTI.CognomeComponente), 40)
                    dr("NomeComponente") = Left(Campi(Tracciati.SOGGETTI.NomeComponente), 20)
                    dr("Sesso") = Campi(Tracciati.SOGGETTI.Sesso)
                    dr("RuoloEssig") = Campi(Tracciati.SOGGETTI.RuoloEssig)
                    dr("DeskRuoloEssig") = Left(Campi(Tracciati.SOGGETTI.DeskRuoloEssig), 100)
                    dr("DataInizioRuolo") = Utx.FunzioniDb.Str2Data(Campi(Tracciati.SOGGETTI.DataInizioRuolo))
                    dr("IncaricoEssig") = Campi(Tracciati.SOGGETTI.IncaricoEssig)
                    dr("DeskIncaricoEssig") = Left(Campi(Tracciati.SOGGETTI.DeskIncaricoEssig), 20)
                    dr("CodiceIsvap") = Campi(Tracciati.SOGGETTI.CodiceIsvap)
                    dr("DeskCodiceIsvap") = Left(Campi(Tracciati.SOGGETTI.DeskCodiceIsvap), 100)
                    dr("RamoRca") = Campi(Tracciati.SOGGETTI.RamoRca)
                    dr("RamoPersone") = Campi(Tracciati.SOGGETTI.RamoPersone)
                    dr("RamoAziende") = Campi(Tracciati.SOGGETTI.RamoAziende)
                    dr("RamoVita") = Campi(Tracciati.SOGGETTI.RamoVita)
                    dr("ProdottiBancari") = Campi(Tracciati.SOGGETTI.ProdottiBancari)
                    dr("InizioMandato") = Utx.FunzioniDb.Str2Data(Campi(Tracciati.SOGGETTI.InizioMandato))
                    dr("FineMandato") = Utx.FunzioniDb.Str2Data(Campi(Tracciati.SOGGETTI.FineMandato))
                    dr("CausaleFineMandato") = Left(Campi(Tracciati.SOGGETTI.CausaleFineMandato), 20)
                    dr("EstrattoConto") = Campi(Tracciati.SOGGETTI.EstrattoConto)
                    dr("DerogaAgenzia") = Campi(Tracciati.SOGGETTI.DerogaAgenzia)
                    dr("FormaSoc") = Campi(Tracciati.SOGGETTI.FormaSoc)
                    dr("DeskFormaSoc") = Left(Campi(Tracciati.SOGGETTI.DeskFormaSoc), 20)
                    dr("NumeroRegistro") = Campi(Tracciati.SOGGETTI.NumeroRegistro)
                    dr("DataRegistro") = Utx.FunzioniDb.Str2Data(Campi(Tracciati.SOGGETTI.DataRegistro))
                    dr("OreFormazione") = Campi(Tracciati.SOGGETTI.OreFormazione)
                    dr("Plurimandatario") = Campi(Tracciati.SOGGETTI.Plurimandatario)
                    dr("RegimeFiscale") = Campi(Tracciati.SOGGETTI.RegimeFiscale)
                    dr("DeskRegimeFiscale") = Left(Campi(Tracciati.SOGGETTI.DeskRegimeFiscale), 20)
                    dr("Telefono1") = Campi(Tracciati.SOGGETTI.Telefono1)
                    dr("Telefono2") = Campi(Tracciati.SOGGETTI.Telefono2)
                    dr("Promotore") = Campi(Tracciati.SOGGETTI.Promotore)
                    dr("GruppoUnipol") = Campi(Tracciati.SOGGETTI.GruppoUnipol)
                    dr("PresenzaPD") = Campi(Tracciati.SOGGETTI.PresenzaPD)
                    dr("RuoloPD") = Campi(Tracciati.SOGGETTI.RuoloPD)
                    dr("TipoOrario") = Campi(Tracciati.SOGGETTI.TipoOrario)
                    dr("Email") = Left(Campi(Tracciati.SOGGETTI.Email), 50)
                    dr("PrimoReferente") = Left(Campi(Tracciati.SOGGETTI.PrimoReferente), 30)
                    dr("NumeroIscrizione") = Campi(Tracciati.SOGGETTI.NumeroIscrizione)
                    dr("Incarico") = Left(Campi(Tracciati.SOGGETTI.Incarico), 20)
                    dr("Contatti") = Left(Campi(Tracciati.SOGGETTI.Contatti), 40)
                    dr("Selezionato") = dr("FineMandato") Is DBNull.Value

                    dt.Rows.Add(dr)
                Loop
            End Using
            Globale.Log.Info(String.Format("Agenzia {0} - SOGGETTI importati: {1}", Agenzia, dt.Rows.Count))
            File.Delete(FileDati)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Errore = True
        End Try
    End Sub

    Private Sub ImportaUtenze(Agenzia As String)
        Try
            Globale.Log.Info($"Importazione UTENZE codice {Agenzia}")

            Dim FileDati As String = ScaricaFile(TipoLista.UTENZ, Agenzia)
            If e.Errore Then Exit Sub
            AddToPacchettoZip(Agenzia, FileDati)

            'pulisco il file da eventuali null
            ClearFileFromNull(FileDati)
            File.WriteAllText(FileDati, File.ReadAllText(FileDati).Replace("=""", "").Replace(""";", ";"))

            Dim dt As DataTable = ds.Tables("UTENZE")

            'apro lo stream
            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                'leggo la prima riga con il nome dei campi
                sr.ReadLine()

                Do While Not sr.EndOfStream
                    Dim Campi() As String = sr.ReadLine.Split(";")

                    'trimma tutto
                    TrimArray(Campi)

                    Globale.Log.Trace("Importazione utente: " & Left(Campi(Tracciati.UTENTI.NomeComponente).Trim, 60))

                    Dim dr As DataRow = dt.NewRow

                    dr("Compagnia") = Campi(Tracciati.UTENTI.Compagnia)
                    dr("Agenzia") = Campi(Tracciati.UTENTI.Agenzia)
                    dr("CfComponente") = Campi(Tracciati.UTENTI.CfComponente)
                    dr("NomeComponente") = Left(Campi(Tracciati.UTENTI.NomeComponente).Trim, 60)
                    dr("Utenza") = Campi(Tracciati.UTENTI.Utenza)
                    dr("StatoUtenza") = Left(Campi(Tracciati.UTENTI.StatoUtenza), 15)
                    dr("Profilo") = Left(Campi(Tracciati.UTENTI.Profilo), 20)
                    dr("Ruolo") = Campi(Tracciati.UTENTI.Ruolo)
                    dr("NomeSoggetto") = Left(Campi(Tracciati.UTENTI.NomeSoggetto), 40)
                    dr("Selezionato") = dr("StatoUtenza") = "ATTIVATA"

                    dt.Rows.Add(dr)
                Loop
            End Using
            Globale.Log.Info(String.Format("Agenzia {0} - UTENZE importati: {1}", Agenzia, dt.Rows.Count))
            'recupero flag
            'If Utx.FunzioniDb.EsisteTabella(c, "OldUtenze") AndAlso Utx.FunzioniDb.EsisteCampo(c, "OldUtenze", "Selezionato") Then
            '            'recupero le impostazioni precedenti
            '            Utx.FunzioniDb.ExecuteNonQuery(c, "UPDATE Utenze AS A " +
            '                                              "INNER JOIN OldUtenze AS B " +
            '                                              "ON A.Utenza = B.Utenza AND A.Profilo = B.Profilo AND A.Ruolo = B.Ruolo " +
            '                                              "SET A.Selezionato = B.Selezionato")
            '            Utx.FunzioniDb.CancellaTabella(c, "OldUtenze")
            '        End If
            File.Delete(FileDati)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Errore = True
        End Try
    End Sub

    Private Sub ImportaPuntiVendita(Agenzia As String)
        Try
            Globale.Log.Info($"Importazione PUNTI VENDITA codice {Agenzia}")

            Dim FileDati As String = ScaricaFile(TipoLista.PVEND, Agenzia)
            If e.Errore Then Exit Sub
            AddToPacchettoZip(Agenzia, FileDati)

            'pulisco il file da eventuali null
            ClearFileFromNull(FileDati)
            File.WriteAllText(FileDati, File.ReadAllText(FileDati).Replace("=""", "").Replace(""";", ";"))

            Dim dt As DataTable = ds.Tables("PUNTI_VENDITA")

            'apro lo stream
            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                'leggo la prima riga con il nome dei campi
                sr.ReadLine()

                Do While Not sr.EndOfStream
                    Dim Campi() As String = sr.ReadLine.Split(";")

                    'trimma tutto
                    TrimArray(Campi)

                    'normalizza campi
                    '....

                    Dim dr As DataRow = dt.NewRow

                    dr("Compagnia") = Campi(Tracciati.PVENDITA.Compagnia)
                    dr("Agenzia") = Campi(Tracciati.PVENDITA.Agenzia)
                    dr("PuntoVenditaAgenzia") = Campi(Tracciati.PVENDITA.PuntoVenditaAgenzia)
                    dr("PuntoVenditaLivello2") = Campi(Tracciati.PVENDITA.PuntoVenditaLivello2)
                    dr("PuntoVenditaLivello3") = Campi(Tracciati.PVENDITA.PuntoVenditaLivello3)
                    dr("DeskPuntoVendita") = Left(Campi(Tracciati.PVENDITA.DeskPuntoVendita), 40)
                    dr("TipoPuntoVendita") = Left(Campi(Tracciati.PVENDITA.TipoPuntoVendita), 20)
                    dr("Indirizzo") = Left(Campi(Tracciati.PVENDITA.Indirizzo), 40)
                    dr("CAP") = Campi(Tracciati.PVENDITA.CAP)
                    dr("Localita") = Left(Campi(Tracciati.PVENDITA.Localita), 30)
                    dr("Provincia") = Campi(Tracciati.PVENDITA.Provincia)
                    dr("DataInizio") = Utx.FunzioniDb.Str2Data(Campi(Tracciati.PVENDITA.DataInizio))
                    dr("DataFine") = Utx.FunzioniDb.Str2Data(Campi(Tracciati.PVENDITA.DataFine))
                    dr("Meccanizzazione") = Left(Campi(Tracciati.PVENDITA.Meccanizzazione), 20)
                    dr("Telefono1") = Campi(Tracciati.PVENDITA.Telefono1)
                    dr("Telefono2") = Campi(Tracciati.PVENDITA.Telefono2)
                    dr("Telefono3") = Campi(Tracciati.PVENDITA.Telefono3)
                    dr("Fax") = Campi(Tracciati.PVENDITA.Fax)
                    dr("Selezionato") = dr("DataFine") Is DBNull.Value

                    dt.Rows.Add(dr)
                Loop
            End Using
            Globale.Log.Info(String.Format("Agenzia {0} - PUNTI VENDITA importati: {1}", Agenzia, dt.Rows.Count))
            'recupero flag
            'If Utx.FunzioniDb.EsisteTabella(c, "OldPV") AndAlso Utx.FunzioniDb.EsisteCampo(c, "OldPV", "Selezionato") Then
            '    'recupero le impostazioni precedenti
            '    Utx.FunzioniDb.ExecuteNonQuery(c, "UPDATE Punti_Vendita AS A " +
            '                                      "INNER JOIN OldPV AS B " +
            '                                      "ON A.PuntoVenditaAgenzia = B.PuntoVenditaAgenzia AND A.PuntoVenditaLivello2 = B.PuntoVenditaLivello2 AND A.PuntoVenditaLivello3 = B.PuntoVenditaLivello3 " +
            '                                      "SET A.Selezionato = B.Selezionato")
            '    Utx.FunzioniDb.CancellaTabella(c, "OldPV")
            'End If
            File.Delete(FileDati)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Errore = True
        End Try
    End Sub

    'Public Sub InviaUtenze(Agenzia As String,
    '                       FileUtenze As String)
    '    Try
    '        'invio lista a uniarea
    '        If File.Exists(FileUtenze) Then
    '            'dichiaro servizio
    '            Dim s As New Utx.ServizioListe.WSApp
    '            s.Proxy = Utx.Globale.UniProxy.Proxy
    '            s.inserisciUtenze(Utx.NetFunc.TokenAccessoCasa2,
    '                              Agenzia,
    '                              Utx.Globale.ProfiloEnteGestore.Compagnia,
    '                              Utx.Globale.UtenteCorrente.UniageUser,
    '                              File.ReadAllText(FileUtenze))
    '        End If
    '    Catch ex As Exception
    '        Globale.Log.Errore(ex)
    '    End Try
    'End Sub

    'Public Sub InviaSoggetti(Agenzia As String,
    '                         FileSoggetti As String)
    '    Try
    '        'invio lista a uniarea
    '        If File.Exists(FileSoggetti) Then
    '            'dichiaro servizio
    '            Dim s As New Utx.ServizioListe.WSApp
    '            s.Proxy = Utx.Globale.UniProxy.Proxy
    '            s.inserisciSoggetti(Utx.NetFunc.TokenAccessoCasa2,
    '                                Agenzia,
    '                                Utx.Globale.ProfiloEnteGestore.Compagnia,
    '                                Utx.Globale.UtenteCorrente.UniageUser,
    '                                File.ReadAllText(FileSoggetti))
    '        End If
    '    Catch ex As Exception
    '        Globale.Log.Errore(ex)
    '    End Try
    'End Sub

    Private Function AddToPacchettoZip(Agenzia As String, File As String) As Boolean
        Try
            If String.IsNullOrEmpty(File) = False Then
                Dim Esito As New Utx.LibreriaZip.EsitoZip
                Dim Lista As New List(Of String)
                Lista.Add(File)
                Return Utx.LibreriaZip.UpdateZipFile(Lista, PacchettoZip(Agenzia), Esito)
            Else
                Return True
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Function PacchettoZip(Agenzia As String) As String
        Return String.Format("{0}\{1}_Essig_Reti_{2:yyMMdd}.zip", Utx.Globale.Paths.CartellaTempUtente, Agenzia, Today)
    End Function
End Class
