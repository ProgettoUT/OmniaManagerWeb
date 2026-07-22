Imports System.Data.OleDb
Imports System.Text
Imports System.IO

Public Class Esporta

    Public Event Stato(Agenzia As String, Archivio As String, RecordEsportati As Integer, RecordTotali As Integer)
    Public Event EsportazioneCompletata(Archivio As String, Errore As Boolean)
    Public Event CompattazioneFile(Agenzia As String, Archivio As String)
    Public Event Messaggio(Messaggio As String)

    Private specifica As New Specifica()
    Private ReadOnly tracciati As Tracciati
    Private ReadOnly agenziaMadre As New Utx.AgenziaOmnia()
    Private Cartelle As Utx.CartelleAgenziaOmnia
    Private ReadOnly dataElaborazione As String = Today.ToString("yyyyMMdd")
    Private ReadOnly dataEstrazione As String = Today.ToString("yyMMdd")
    Private Const F12V3S = "000000000000.000+;000000000000.000-"
    Private Const F10V3S = "0000000000.000+;0000000000.000-"
    Private Const YYYYMMDD = "yyyyMMdd"
    Private Const DD_MM_YYYY = "dd.MM.yyyy"
    Private Const Z3 = "000"
    Private Const Z4 = "0000"
    Private Const Z5 = "00000"
    Private Const Z7 = "0000000"
    Private Const Z9 = "000000000"
    Private Progressivo As Integer
    Private Passo As Integer = 300
    Private ciSonoErrori As Boolean = False
    Private ListaInviati As List(Of String)

    Shared Sub New()
        Globale.Log = New Utx.ApplicationLog("Esporta_Omnia", Nothing, Nothing, False, True)
    End Sub

    Public Sub New()
        tracciati = specifica.Files.GetFile(UniFeed.Specifica.KEY_FILE_MA).Tracciati
    End Sub

    Public Sub EsportaTutto()
        Globale.InviaEmailAssistenza = True
        'devono stare in questo ordine
        EsportaClienti()
        EsportaPolizze()
        EsportaIncassi()
        EsportaTipoRecord23()
        Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_DATI, Now)
        Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_ERRORE, ciSonoErrori.ToString)
    End Sub

    Public Sub EsportaClienti()

        Globale.Log.Info("EsportaClienti Start")

        Dim nomeFileMa As String

        Try
            Dim tracciatoClienti As Tracciato = tracciati("/00/L6000")
            Dim tracciatoClienti1 As Tracciato = tracciati("/10/L6000")
            Dim tracciatoContatto As Tracciato = tracciati("/C0/L6000")
            Dim tracciatoGruppo As Tracciato = tracciati("/G0/L6000")

            For Each CodiceAgenziaFiglia In agenziaMadre.AgenzieCollegate
                Dim Cartelle = New Utx.CartelleAgenziaOmnia(CodiceAgenziaFiglia)

                If IO.Directory.GetFiles(Cartelle.ArchivioFileEsportati, "MA*UAP.zip").Length = 0 Then

                    Dim agenziaFiglia As Utx.AgenziaFigliaOmnia
#If DEBUG Then
                    If PCSTEFANO Or PCGUIDO Then
                        agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia)
                    Else
                        agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia, agenziaMadre.CodiceSede)
                    End If
#Else
                    agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia, agenziaMadre.CodiceSede)
#End If

                    Dim archivi As New Archivi(agenziaMadre, agenziaFiglia, False)

                    nomeFileMa = IO.Path.Combine(Cartelle.ArchivioFileEsportati, String.Format("MA{0}{1}.U00", 100000 + CInt(CodiceAgenziaFiglia), dataEstrazione))

                    Dim workTable As New DataTable("contatti")

                    workTable.Columns.Add("CodiceFiscale", GetType(String))
                    workTable.Columns.Add("RagioneSociale", GetType(String))
                    workTable.Columns.Add("DescrizioneContatto", GetType(String))
                    workTable.Columns.Add("Cellulare", GetType(String))
                    workTable.Columns.Add("Fax", GetType(String))
                    workTable.Columns.Add("Telefono1", GetType(String))
                    workTable.Columns.Add("Telefono2", GetType(String))
                    workTable.Columns.Add("Telefono3", GetType(String))
                    workTable.Columns.Add("Telefono4", GetType(String))
                    workTable.Columns.Add("Telefono5", GetType(String))
                    workTable.Columns.Add("Email1", GetType(String))
                    workTable.Columns.Add("Email2", GetType(String))
                    workTable.Columns.Add("Email3", GetType(String))
                    workTable.Columns.Add("Email4", GetType(String))
                    workTable.Columns.Add("Email5", GetType(String))
                    workTable.PrimaryKey = New DataColumn() {workTable.Columns("CodiceFiscale")}

                    Progressivo = 0
                    Dim file As System.IO.StreamWriter
                    file = My.Computer.FileSystem.OpenTextFileWriter(nomeFileMa, False)

                    Using c As New OleDb.OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenziaFiglia, Utx.ConnessioniDb.Db.CLIENTI))
                        c.Open()

                        Using cmd As New OleDbCommand
                            Utx.FunzioniDb.CancellaTabella(c, "Clienti2")
                            cmd.Connection = c
                            cmd.CommandType = CommandType.Text
                            cmd.CommandText = String.Format("SELECT * INTO Clienti2 FROM Clienti1 IN '{0}' ",
                                                            agenziaFiglia.Cartelle.DatabaseDbUno)
                            cmd.ExecuteNonQuery()

                            Utx.FunzioniDb.CreaIndice(c, "Clienti2", "IC2", {"CodiceFiscale"})
                        End Using

                        'GG.MM.AAAA
                        For Each Campo In tracciatoClienti1.Campi.Values
                            If Campo.Formato = "GG.MM.AAAA" Then
                                Campo.Formato = DD_MM_YYYY
                            Else
                                Campo.Formato = Nothing
                            End If
                        Next

                        Dim cliente1Dt As DataTable = Utx.FunzioniDb.CreaDataTable("SELECT * FROM Clienti2 ORDER BY Cognome, Nome", c)
                        For Each cliente As DataRow In cliente1Dt.Rows
                            Dim row As String = Space(5999) & "*"
                            For Each Campo In tracciatoClienti1.Campi.Values
                                If cliente1Dt.Columns.Contains(Campo.Nome) Then
                                    If Campo.Formato Is Nothing Then
                                        valorizza(row, Campo, cliente(Campo.Nome))
                                    Else
                                        valorizza(row, Campo, cliente(Campo.Nome), Campo.Formato)
                                    End If
                                End If
                            Next
                            valorizza(row, tracciatoClienti.Campi("DataElaborazione"), dataElaborazione)
                            file.WriteLine(row)

                            Progressivo += 1
                            If Progressivo Mod Passo = 0 Then
                                RaiseEvent Stato(CodiceAgenziaFiglia, "Clienti", Progressivo, cliente1Dt.Rows.Count)
                            End If
                        Next

                        Dim sqlClienti As String =
                                  "SELECT C.*" &
                                  " FROM Clienti C" &
                                  " LEFT JOIN Clienti2 C2 ON C.CodiceFiscale = C2.CodiceFiscale" &
                                  " WHERE C2.CodiceFiscale IS NULL" &
                                  " ORDER BY C.Cognome, C.Nome"

                        Progressivo = 0
                        Dim clienteDt As DataTable = Utx.FunzioniDb.CreaDataTable(sqlClienti, c)
                        For Each cliente As DataRow In clienteDt.Rows
                            Dim row As String = Space(5999) & "*"

                            valorizza(row, tracciatoClienti.Campi("DataElaborazione"), dataElaborazione)
                            valorizza(row, tracciatoClienti.Campi("CodicePuntoVendita"), CodiceAgenziaFiglia)
                            valorizza(row, tracciatoClienti.Campi("Progressivo"), "01")
                            valorizza(row, tracciatoClienti.Campi("TipoElaborazione"), "00")
                            valorizza(row, tracciatoClienti.Campi("CodiceFiscale"), cliente("CodiceFiscale"))
                            valorizza(row, tracciatoClienti.Campi("Cognome"), cliente("Cognome"))
                            valorizza(row, tracciatoClienti.Campi("Nome"), cliente("Nome"))
                            If Not IsDBNull(cliente("DataNascita")) Then
                                valorizza(row, tracciatoClienti.Campi("DataNascita"), IIf(IsDate(cliente("DataNascita")), CDate(cliente("DataNascita")).ToString("dd.MM.yyyy"), ""))
                            End If
                            valorizza(row, tracciatoClienti.Campi("Indirizzo"), cliente("Indirizzo"))
                            valorizza(row, tracciatoClienti.Campi("Cap"), cliente("Cap"))
                            valorizza(row, tracciatoClienti.Campi("Comune"), cliente("Localita"))
                            'ComuneCAB
                            'StatoCAB
                            valorizza(row, tracciatoClienti.Campi("Provincia"), cliente("Provincia"))
                            valorizza(row, tracciatoClienti.Campi("Telefono"), cliente("Telefono1"))
                            valorizza(row, tracciatoClienti.Campi("Telefono2"), cliente("Telefono2"))
                            valorizza(row, tracciatoClienti.Campi("Sesso"), cliente("Sesso"))
                            valorizza(row, tracciatoClienti.Campi("FlagCapoFamiglia"), cliente("Capofamiglia"))
                            valorizza(row, tracciatoClienti.Campi("CodiceFiscaleCF"), cliente("CodiceFiscaleCF"))
                            valorizza(row, tracciatoClienti.Campi("CodiceFiscaleEA"), cliente("CodiceFiscaleEA"))
                            'clientetop
                            'DataTop
                            'Produttore
                            valorizza(row, tracciatoClienti.Campi("CodiceStatoCivile"), cliente("StatoCivile"))
                            valorizza(row, tracciatoClienti.Campi("Nucleo"), cliente("NucleoFamiliare"))
                            valorizza(row, tracciatoClienti.Campi("FlagPrimaCasa"), cliente("PrimaCasa"))
                            valorizza(row, tracciatoClienti.Campi("FlagAltriImmobili"), cliente("AltriImmobili"))
                            valorizza(row, tracciatoClienti.Campi("FlagTitoliStato"), cliente("TitoliStato"))
                            'FasciaReddito
                            valorizza(row, tracciatoClienti.Campi("FlagAppertenenzaSindacato"), cliente("Sindacati"))
                            valorizza(row, tracciatoClienti.Campi("PolizzeAltreCompagniePF"), cliente("PolizzeAltreComp"))
                            valorizza(row, tracciatoClienti.Campi("FlagCartaCredito"), cliente("CartaCredito"))
                            valorizza(row, tracciatoClienti.Campi("FlagEnteAppartenenza"), cliente("Ente"))
                            'TipoCliente
                            'IDSegmentoCorrente
                            'IDSegmentoPrecedente
                            'IDStatoCliente
                            'IDZona
                            valorizza(row, tracciatoClienti.Campi("DataInserimento"), cliente("DataInserimento"))
                            valorizza(row, tracciatoClienti.Campi("DataCessazione"), cliente("DataCessazione"))
                            'AgenziaPrevalente
                            valorizza(row, tracciatoClienti.Campi("Subagenzia"), cliente("SubAgenzia"))
                            'SubAgenziaSIMA
                            'DataUltimaVisita
                            'DataProssimaVisita
                            'PolizzeVigore
                            'PolizzeStoriche
                            'PremiCorrente
                            'SinistriCorrente
                            'LiquidatoCorrente, 
                            'PremiPrecedente, 
                            'SinistriPrecedente, 
                            'LiquidatoPrecedente, 
                            'PremiTotale, 
                            'SinistriTotale, 
                            'LiquidatoTotale, 
                            valorizza(row, tracciatoClienti.Campi("CodicePrivacy"), cliente("ConsensoPrivacy"), "00")
                            'RilascioPatente, 
                            valorizza(row, tracciatoClienti.Campi("Email"), cliente("Email"))
                            valorizza(row, tracciatoClienti.Campi("Fax"), cliente("Fax"))
                            valorizza(row, tracciatoClienti.Campi("Cellulare"), cliente("Cellulare"))
                            valorizza(row, tracciatoClienti.Campi("TelReferente"), cliente("TelReferente"))
                            valorizza(row, tracciatoClienti.Campi("NomeReferente"), cliente("NomeReferente"))
                            valorizza(row, tracciatoClienti.Campi("TelAziendale"), cliente("TelAziendale"))
                            'CodAvvisoScadenza, 
                            'AnnoMeseInizioEsclTemp, 
                            'AnnoMeseFineEsclTemp, 
                            'CodModalitaIncasso, 

                            valorizza(row, tracciatoClienti.Campi("IndirizzoProvincia"), cliente("Provincia"))
                            valorizza(row, tracciatoClienti.Campi("IndirizzoComune"), cliente("Localita"))

                            file.WriteLine(row)

                            Progressivo += 1
                            If Progressivo Mod Passo = 0 Then
                                RaiseEvent Stato(CodiceAgenziaFiglia, "Clienti (storico)", Progressivo, clienteDt.Rows.Count)
                            End If
                        Next

                        Globale.Log.Info(String.Format("Esportati {0} Clienti", clienteDt.Rows.Count))

                        Progressivo = 0
                        clienteDt = Utx.FunzioniDb.CreaDataTable("SELECT CodiceFiscale, trim(trim(Cognome) & ' ' & trim(Nome)) as Nominativo, RisTelefono, RisCellulare, RisMail From Clienti where RisTelefono > ' ' or  RisCellulare > ' ' or  RisMail > ' '", c)
                        For Each cliente As DataRow In clienteDt.Rows
                            Dim foundrow As DataRow = workTable.Rows.Find(cliente("CodiceFiscale"))
                            If foundrow Is Nothing Then
                                foundrow = workTable.NewRow
                                foundrow("CodiceFiscale") = cliente("CodiceFiscale")
                                foundrow("RagioneSociale") = cliente("Nominativo")
                                workTable.Rows.Add(foundrow)
                            End If
                            If Not IsDBNull(cliente("RisTelefono")) AndAlso Not String.IsNullOrEmpty(CType(cliente("RisTelefono"), String)) Then
                                foundrow("Telefono1") = cliente("RisTelefono")
                            End If
                            If Not IsDBNull(cliente("RisCellulare")) AndAlso Not String.IsNullOrEmpty(CType(cliente("RisCellulare"), String)) Then
                                foundrow("Cellulare") = cliente("RisCellulare")
                            End If
                            If Not IsDBNull(cliente("RisMail")) AndAlso Not String.IsNullOrEmpty(CType(cliente("RisMail"), String)) Then
                                foundrow("Email1") = cliente("RisMail")
                            End If

                            Progressivo += 1
                            If Progressivo Mod Passo = 0 Then
                                RaiseEvent Stato(CodiceAgenziaFiglia, "Contatti", Progressivo, clienteDt.Rows.Count)
                            End If
                        Next

                        'Gruppi Familiari e Enti di appartenenza
                        Dim gruppi As New Dictionary(Of String, Integer)

                        Dim sql = New Text.StringBuilder()
                        sql.Append("SELECT CodiceFiscale,  CodiceFiscaleCF, CodiceFiscaleEA")
                        sql.Append("  FROM Clienti")
                        sql.Append(" WHERE (CodiceFiscaleCF > ' ' AND CodiceFiscale <> CodiceFiscaleCF)")
                        sql.Append("    OR (CodiceFiscaleEA > ' ' AND CodiceFiscale <> CodiceFiscaleEA)")

                        Progressivo = 0
                        clienteDt = Utx.FunzioniDb.CreaDataTable(sql.ToString, c)
                        For Each cliente As DataRow In clienteDt.Rows
                            Dim row As String = Space(5999) & "*"

                            valorizza(row, tracciatoGruppo.Campi("DataElaborazione"), dataElaborazione)
                            valorizza(row, tracciatoGruppo.Campi("CodicePuntoVendita"), CodiceAgenziaFiglia)
                            valorizza(row, tracciatoGruppo.Campi("Progressivo"), "01")
                            valorizza(row, tracciatoGruppo.Campi("TipoElaborazione"), "G0")
                            valorizza(row, tracciatoGruppo.Campi("CodiceFiscale"), cliente("CodiceFiscale"))

                            If Not IsDBNull(cliente("CodiceFiscaleCF")) AndAlso Not String.IsNullOrEmpty(cliente("CodiceFiscaleCF").ToString.Trim) Then
                                If Not gruppi.ContainsKey(cliente("CodiceFiscaleCF").ToString) Then
                                    gruppi.Add(cliente("CodiceFiscaleCF").ToString, 1 + gruppi.Count)
                                End If
                                valorizza(row, tracciatoGruppo.Campi("CodiceGruppo"), gruppi(cliente("CodiceFiscaleCF").ToString).ToString(Z5))
                                valorizza(row, tracciatoGruppo.Campi("DescrizioneGruppo"), cliente("CodiceFiscaleCF"))
                                If cliente("CodiceFiscale").Equals(cliente("CodiceFiscaleCF")) Then
                                    valorizza(row, tracciatoGruppo.Campi("FlagCapoGruppo"), "S")
                                Else
                                    valorizza(row, tracciatoGruppo.Campi("FlagCapoGruppo"), "N")
                                End If
                            End If
                            If Not IsDBNull(cliente("CodiceFiscaleEA")) AndAlso Not String.IsNullOrEmpty(cliente("CodiceFiscaleEA").ToString.Trim) Then
                                valorizza(row, tracciatoGruppo.Campi("CodiceRelazione"), "00031")
                                valorizza(row, tracciatoGruppo.Campi("CodiceFiscaleEA"), cliente("CodiceFiscaleEA"))
                            End If

                            file.WriteLine(row)

                            Progressivo += 1
                            If Progressivo Mod Passo = 0 Then
                                RaiseEvent Stato(CodiceAgenziaFiglia, "Gruppi/nuclei", Progressivo, clienteDt.Rows.Count)
                            End If
                        Next

                        Globale.Log.Info(String.Format("Esportati {0} Gruppi Clienti", clienteDt.Rows.Count))
                        Utx.FunzioniDb.CancellaTabella(c, "Clienti2")
                    End Using

                    Using c As New OleDb.OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenziaFiglia, Utx.ConnessioniDb.Db.ANAG))
                        c.Open()
                        Dim sql As New Text.StringBuilder()
                        sql.Append("SELECT CodiceFiscale, TelNumero1, TelNumero2, TelNumero3, TelNumero4, EmailIndirizzo1, EmailIndirizzo2 From Ana_Soggetto")
                        sql.Append(" where TelNumero1 > ' ' OR TelNumero2 > ' ' OR TelNumero3 > ' ' OR TelNumero4 > ' ' OR EmailIndirizzo1 > ' ' OR EmailIndirizzo2 > ' '")

                        Progressivo = 0
                        Dim clienteDt As DataTable = Utx.FunzioniDb.CreaDataTable(sql.ToString, c)
                        For Each cliente As DataRow In clienteDt.Rows
                            Dim foundrow As DataRow = workTable.Rows.Find(cliente("CodiceFiscale"))
                            If foundrow Is Nothing Then
                                foundrow = workTable.NewRow
                                foundrow("CodiceFiscale") = cliente("CodiceFiscale")
                                workTable.Rows.Add(foundrow)
                            End If
                            Dim IndiceTelefono As Integer = 1
                            If Not IsDBNull(foundrow("Telefono1")) Then IndiceTelefono = 2

                            If Not IsDBNull(cliente("TelNumero1")) Then
                                foundrow("Telefono" & IndiceTelefono) = cliente("TelNumero1")
                                IndiceTelefono = IndiceTelefono + 1
                            End If
                            If Not IsDBNull(cliente("TelNumero2")) Then
                                foundrow("Telefono" & IndiceTelefono) = cliente("TelNumero2")
                                IndiceTelefono = IndiceTelefono + 1
                            End If
                            If Not IsDBNull(cliente("TelNumero3")) Then
                                foundrow("Telefono" & IndiceTelefono) = cliente("TelNumero3")
                                IndiceTelefono = IndiceTelefono + 1
                            End If
                            If Not IsDBNull(cliente("TelNumero4")) Then
                                foundrow("Telefono" & IndiceTelefono) = cliente("TelNumero4")
                            End If

                            Dim IndiceEmail As Integer = 1
                            If Not IsDBNull(foundrow("Email1")) Then IndiceEmail = 2

                            If Not IsDBNull(cliente("EmailIndirizzo1")) Then
                                foundrow("Email" & IndiceEmail) = cliente("EmailIndirizzo1")
                                IndiceEmail = IndiceEmail + 1
                            End If
                            If Not IsDBNull(cliente("EmailIndirizzo2")) Then
                                foundrow("Email" & IndiceEmail) = cliente("EmailIndirizzo2")
                            End If
                        Next

                        Progressivo += 1
                        If Progressivo Mod Passo = 0 Then
                            RaiseEvent Stato(CodiceAgenziaFiglia, "Altri contatti", Progressivo, clienteDt.Rows.Count)
                        End If
                    End Using

                    Progressivo = 0
                    For Each cliente As DataRow In workTable.Rows
                        If IsDBNull(cliente("RagioneSociale")) Then
                            Using c As New OleDb.OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenziaFiglia, Utx.ConnessioniDb.Db.CLIENTI))
                                c.Open()
                                Dim clienteDt As DataTable = Utx.FunzioniDb.CreaDataTable("SELECT trim(trim(Cognome) & ' ' & trim(Nome)) AS Nominativo FROM Clienti Where CodiceFiscale = '" & CStr(cliente("CodiceFiscale")) & "'", c)
                                For Each cl As DataRow In clienteDt.Rows
                                    cliente("RagioneSociale") = cl("Nominativo")
                                Next
                            End Using
                        End If

                        For i As Integer = 1 To 5
                            If Not IsDBNull(cliente("Telefono" & i)) Or Not IsDBNull(cliente("Email" & i)) Then
                                Dim row As String = Space(5999) & "*"

                                valorizza(row, tracciatoContatto.Campi("DataElaborazione"), dataElaborazione)
                                valorizza(row, tracciatoContatto.Campi("CodicePuntoVendita"), CodiceAgenziaFiglia)
                                valorizza(row, tracciatoContatto.Campi("Progressivo"), i.ToString("00"))
                                valorizza(row, tracciatoContatto.Campi("TipoElaborazione"), "CO")
                                valorizza(row, tracciatoContatto.Campi("CodiceFiscale"), cliente("CodiceFiscale"))
                                valorizza(row, tracciatoContatto.Campi("RagioneSociale"), cliente("RagioneSociale"))
                                valorizza(row, tracciatoContatto.Campi("Telefono"), cliente("Telefono" & i))
                                valorizza(row, tracciatoContatto.Campi("Email"), cliente("Email" & i))

                                If i = 1 And Not IsDBNull(cliente("Cellulare")) Then
                                    valorizza(row, tracciatoContatto.Campi("Cellulare"), cliente("Cellulare"))
                                End If
                                valorizza(row, tracciatoContatto.Campi("DescrizioneContatto"), "Altro contatto")

                                file.WriteLine(row)
                            End If
                        Next
                        Progressivo += 1
                        If Progressivo Mod Passo = 0 Then
                            RaiseEvent Stato(CodiceAgenziaFiglia, "Altri contatti", Progressivo, workTable.Rows.Count)
                        End If
                    Next

                    Globale.Log.Info(String.Format("Esportati Contatti Clienti"))

                    file.Close()

                    RaiseEvent EsportazioneCompletata("Anagrafiche", False)
                Else
                    Globale.Log.Info(String.Format("File cliente del codice agenzia {0} è stato estratto e inviato a SIA", CodiceAgenziaFiglia))
                End If
                System.Windows.Forms.Application.DoEvents()
            Next
        Catch ex As Exception
            ciSonoErrori = True
            Globale.Log.Errore(ex.Message)
            RaiseEvent EsportazioneCompletata("Anagrafiche", True)
        End Try

        Globale.Log.Info("EsportaClienti End")
    End Sub

    Private Sub valorizza(ByRef row As String, ByRef campo As Campo, valore As Object)
        Try
            Mid(row, campo.Posizione, campo.Lunghezza) = Left(valore.ToString, campo.Lunghezza)
        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            Globale.Log.Info(row)
            Globale.Log.Info(campo.Nome)
        End Try
    End Sub

    Private Sub valorizza(ByRef row As String, ByRef campo As Campo, valore As Object, formato As String)
        Try
            If IsDBNull(valore) Then
                If formato = YYYYMMDD Then
                    valorizza(row, campo, "00000000")
                ElseIf formato <> DD_MM_YYYY Then
                    valorizza(row, campo, Format(0, formato))
                End If
            ElseIf TypeOf valore Is String Then
                If IsNumeric(valore) Then
                    valorizza(row, campo, Format(CLng(valore.ToString), formato))
                ElseIf IsDate(valore) And (formato = DD_MM_YYYY) Then
                    valorizza(row, campo, Format(CDate(valore), formato))
                Else
                    valorizza(row, campo, valore)
                End If
            Else
                valorizza(row, campo, Format(valore, formato))
            End If
        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            Globale.Log.Info(row)
            Globale.Log.Info(campo.Nome)
            Globale.Log.Info(formato)
        End Try
    End Sub

    Private Sub valorizza(ByRef row As String, ByRef campo As Campo, valore As Object, scala As Integer, formato As String)
        Try
            If IsDBNull(valore) Then
                valorizza(row, campo, 0, formato)
            Else
                valorizza(row, campo, valore * scala, formato)
            End If
        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            Globale.Log.Info(row)
            Globale.Log.Info(campo.Nome)
            Globale.Log.Info(scala.ToString)
            Globale.Log.Info(formato)
        End Try
    End Sub

    Private Sub valorizza(ByRef row As Char(), ByRef campo As Campo, valore As Object)
        Try
            Dim sValore As Char() = valore.ToString.ToCharArray
            If sValore.Length >= campo.Lunghezza Then
                For i = 0 To campo.Lunghezza - 1
                    row(campo.Posizione + i - 1) = sValore(i)
                Next
            Else
                For i = 0 To sValore.Length - 1
                    row(campo.Posizione + i - 1) = sValore(i)
                Next
            End If
        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            Globale.Log.Info(row)
            Globale.Log.Info(campo.Nome)
        End Try
    End Sub

    Private Sub valorizza(ByRef row As Char(), ByRef campo As Campo, valore As Object, formato As String)
        Try
            If IsDBNull(valore) Then
                If formato = YYYYMMDD Then
                    valorizza(row, campo, "00000000")
                Else
                    valorizza(row, campo, Format(0, formato))
                End If
            ElseIf TypeOf valore Is String Then
                If IsNumeric(valore) Then
                    valorizza(row, campo, Format(CInt(valore.ToString), formato))
                Else
                    valorizza(row, campo, valore)
                End If
            Else
                valorizza(row, campo, Format(valore, formato))
            End If
        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            Globale.Log.Info(row)
            Globale.Log.Info(campo.Nome)
            Globale.Log.Info(formato)
        End Try
    End Sub

    Private Sub valorizza(ByRef row As Char(), ByRef campo As Campo, valore As Object, scala As Integer, formato As String)
        If IsDBNull(valore) Then
            valorizza(row, campo, 0, formato)
        Else
            valorizza(row, campo, valore * scala, formato)
        End If
    End Sub

    Public Sub EsportaIncassi()
        Globale.Log.Info("EsportaIncassi Start")

        'Dim nomeFileMa, nomeFileZip As String

        Try
            Dim tracciatoTitoli As Tracciato = tracciati("/21/L6000")

            For Each Campo In tracciatoTitoli.Campi.Values
                If Campo.Formato = "AAAAMMGG" Then
                    Campo.Formato = YYYYMMDD
                ElseIf Campo.Formato = "9(12),999S" Then
                    Campo.Formato = F12V3S
                ElseIf Campo.Formato = "9(03),99" Then
                    Campo.Formato = "000.00"
                ElseIf Campo.Formato = "9(03),9999" Then
                    Campo.Formato = "000.0000"
                ElseIf Campo.Formato = "9(10),999S" Then
                    Campo.Formato = F10V3S
                ElseIf Campo.Formato IsNot Nothing Then
                    Campo.Formato = ""
                End If
            Next
            tracciatoTitoli.Campi("RamoGestione").Formato = Z5

            For Each CodiceAgenziaFiglia In agenziaMadre.AgenzieCollegate
                Dim Cartelle = New Utx.CartelleAgenziaOmnia(CodiceAgenziaFiglia)

                If IO.Directory.GetFiles(Cartelle.ArchivioFileEsportati, "MA*UT?.zip").Length = 0 Then

                    Dim agenziaFiglia As Utx.AgenziaFigliaOmnia
#If DEBUG Then
                    If PCSTEFANO Or PCGUIDO Then
                        agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia)
                    Else
                        agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia, agenziaMadre.CodiceSede)
                    End If
#Else
                    agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia, agenziaMadre.CodiceSede)
#End If

                    Dim archivi As New Archivi(agenziaMadre, agenziaFiglia, False)

                    Dim ProgressivoFile As Integer = 1
                    Dim ProgressivoRecord As Integer = 0
                    'nomeFileMa = IO.Path.Combine(Cartelle.ArchivioFileEsportati, String.Format("MA{0}{1}.UT{2}", 100000 + CInt(CodiceAgenziaFiglia), dataEstrazione, ProgressivoFile))
                    'nomeFileZip = IO.Path.Combine(Cartelle.ArchivioFileEsportati, String.Format("MA{0}{1}UT{2}.zip", 100000 + CInt(CodiceAgenziaFiglia), dataEstrazione, ProgressivoFile))

                    Dim file As System.IO.StreamWriter
                    file = My.Computer.FileSystem.OpenTextFileWriter(FileTitoliMA(Cartelle.ArchivioFileEsportati, CodiceAgenziaFiglia, ProgressivoFile), False)

                    Using c As New OleDb.OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenziaFiglia, Utx.ConnessioniDb.Db.INCASSI))
                        c.Open()

                        Globale.Log.Info("importazione TitoliUno-Start")
                        Using cmd As New OleDbCommand
                            Try
                                Utx.FunzioniDb.CancellaTabella(c, "TitoliUno")
                                cmd.Connection = c
                                cmd.CommandType = CommandType.Text
                                cmd.CommandText = String.Format("SELECT * INTO TitoliUno FROM Titoli IN '{0}' ",
                                                                agenziaFiglia.Cartelle.DatabaseDbUno)
                                cmd.ExecuteNonQuery()
                            Catch ex As Exception
                            End Try
                        End Using
                        Globale.Log.Info("importazione TitoliUno-end")

                        Progressivo = 0

                        Globale.Log.Info("Esportazione TitoliUno-Start")
                        Dim titoliDt As DataTable = Utx.FunzioniDb.CreaDataTable("SELECT * FROM TitoliUno", c)
                        For Each cliente As DataRow In titoliDt.Rows
                            Dim row As String = Space(5999) & "*"
                            For Each Campo In tracciatoTitoli.Campi.Values
                                If titoliDt.Columns.Contains(Campo.Nome) Then
                                    If Campo.Formato Is Nothing Then
                                        valorizza(row, Campo, cliente(Campo.Nome))
                                    Else
                                        valorizza(row, Campo, cliente(Campo.Nome), Campo.Formato)
                                    End If
                                End If
                            Next
                            valorizza(row, tracciatoTitoli.Campi("DataElaborazione"), dataElaborazione)
                            file.WriteLine(row)

                            ProgressivoRecord += 1
                            If ProgressivoRecord Mod 50000 = 0 Then
                                ProgressivoFile += 1
                                file.Close()
                                file = My.Computer.FileSystem.OpenTextFileWriter(FileTitoliMA(Cartelle.ArchivioFileEsportati, CodiceAgenziaFiglia, ProgressivoFile), False)
                                ProgressivoRecord = 0
                            End If

                            Progressivo += 1
                            If Progressivo Mod Passo = 0 Then
                                RaiseEvent Stato(CodiceAgenziaFiglia, "Titoli", Progressivo, titoliDt.Rows.Count)
                            End If
                        Next
                        Globale.Log.Info("Esportazione TitoliUno-End: " & titoliDt.Rows.Count)

                        Progressivo = 0

                        Globale.Log.Info("Titoli mancanti-start")
                        Dim titoli As DataTable = Utx.FunzioniDb.CreaDataTable("SELECT I.* FROM Incassi I" &
                                                                               " LEFT JOIN (SELECT DISTINCT clng(Ramo) as xRamo, clng(Polizza) as xPolizza, DataEffetto, DataFoglioCassa FROM TitoliUno) T" &
                                                                               " ON I.Ramo = T.xRamo AND I.Polizza=T.xPolizza AND I.DataEffettoTitolo=T.DataEffetto AND I.DataFoglioCassa = T.DataFoglioCassa" &
                                                                               " WHERE T.DataFoglioCassa IS NULL", c)
                        Globale.Log.Info("Titoli mancanti-esportazione start")
                        For Each titolo As DataRow In titoli.Rows
                            Dim row As String = Space(5999) & "*"

                            valorizza(row, tracciatoTitoli.Campi("DataElaborazione"), dataElaborazione)
                            valorizza(row, tracciatoTitoli.Campi("CodicePuntoVendita"), CodiceAgenziaFiglia)
                            valorizza(row, tracciatoTitoli.Campi("Progressivo"), "01")
                            valorizza(row, tracciatoTitoli.Campi("TipoElaborazione"), "23")

                            'valorizza(row, tracciatoTitoli.Campi("CodicePuntoVendita"), titolo("Agenzia"))
                            valorizza(row, tracciatoTitoli.Campi("Ramo"), titolo("Ramo"), Z3)
                            valorizza(row, tracciatoTitoli.Campi("Polizza"), titolo("Polizza"), Z9)
                            valorizza(row, tracciatoTitoli.Campi("EffettoAppendice"), titolo("DataEffettoAppendice"), YYYYMMDD)
                            valorizza(row, tracciatoTitoli.Campi("NumeroAppendice"), titolo("NumeroAppendice"), Z3)
                            valorizza(row, tracciatoTitoli.Campi("DataEffetto"), titolo("DataEffettoTitolo"), YYYYMMDD)
                            valorizza(row, tracciatoTitoli.Campi("TipoCarico"), titolo("TipoCarico"))
                            valorizza(row, tracciatoTitoli.Campi("DataScadenza"), titolo("DataScadenzaTitolo"), YYYYMMDD)
                            'data emissione
                            valorizza(row, tracciatoTitoli.Campi("DataFoglioCassa"), titolo("DataFoglioCassa"), YYYYMMDD)
                            'datastorno
                            valorizza(row, tracciatoTitoli.Campi("CodiceEsito"), titolo("Esito"))
                            'valorizza(row, tracciatoTitoli.Campi("TerminaleCassa"), titolo("CodiceCassa"))
                            'TerminaleCassa
                            'CodiceTerminale
                            valorizza(row, tracciatoTitoli.Campi("PremioNetto"), titolo("Tassabile"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("Interessi"), 0, F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("Accessori"), 0, F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("TotaleLordo"), titolo("TotaleTitolo"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("Abbuono"), 0, F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("ProvvigioneAcquisto"), titolo("PrvAcq"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("ProvvigioneAcquistoRic"), 0, F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("ProvvigioneIncasso"), titolo("PrvInc"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("ImpostaSSN"), titolo("SSN"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("Valuta"), 300)
                            valorizza(row, tracciatoTitoli.Campi("TipoMatricola"), titolo("TipoMat"))
                            'codice ultima transazione
                            valorizza(row, tracciatoTitoli.Campi("TipoQuietanza"), titolo("Tipo"))
                            'data sistema
                            'CodiceCaricoProvvigionale
                            valorizza(row, tracciatoTitoli.Campi("CodiceTipoPagamento"), titolo("TipoPagamento"))
                            valorizza(row, tracciatoTitoli.Campi("DataEffetivoPagamento"), titolo("EffettivoPagamento"), YYYYMMDD)
                            'FlagEmessoPregresso
                            'DataEffettoMovimento
                            valorizza(row, tracciatoTitoli.Campi("CodiceSubagente"), titolo("CodiceSubAgente"), Z5)
                            valorizza(row, tracciatoTitoli.Campi("CodiceProduttore"), titolo("CodiceProduttore"), Z5)
                            valorizza(row, tracciatoTitoli.Campi("CodiceConvenzioneProvvigionata"), titolo("ConvProvv"), Z5)
                            valorizza(row, tracciatoTitoli.Campi("CodiceConvenzione"), titolo("Convenzione"), Z5)
                            valorizza(row, tracciatoTitoli.Campi("DataTrasferimentoTitolo"), "00000000")
                            'FlagTipoRamo
                            'FlagTitoloEsente
                            'CodiceCombinazioneAurFF
                            valorizza(row, tracciatoTitoli.Campi("ImportoAurobox"), titolo("CanoneBox"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("CodiceFiscale"), titolo("CodiceFiscInc"))
                            valorizza(row, tracciatoTitoli.Campi("Contraente"), titolo("Contraente"))
                            valorizza(row, tracciatoTitoli.Campi("Frazionamento"), titolo("Frazionamento"))
                            valorizza(row, tracciatoTitoli.Campi("CodiceProdotto"), titolo("CodiceProdotto"), Z5)
                            'tipomatricola vita
                            valorizza(row, tracciatoTitoli.Campi("DataEffettoPolizza"), titolo("EffettoPolizza"), YYYYMMDD)
                            valorizza(row, tracciatoTitoli.Campi("CompagniaDelegataria"), titolo("Delegataria"), Z3)
                            valorizza(row, tracciatoTitoli.Campi("QuotaCoass"), titolo("Quota"), "000.0000")
                            valorizza(row, tracciatoTitoli.Campi("NumeroTesta"), Z9)
                            'flag rid
                            'flag incasso direzione
                            valorizza(row, tracciatoTitoli.Campi("AliquotaProvvigionaleIncasso"), titolo("AliqPrvAcq"), "000.00")
                            valorizza(row, tracciatoTitoli.Campi("AliquotaProvvigionaleAcquisto"), titolo("AliqPrvInc"), "000.00")
                            valorizza(row, tracciatoTitoli.Campi("PremioTutela"), titolo("Tutela"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("PremioAssistenza"), titolo("Assistenza"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("ImportoCAV"), titolo("CavRCA"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("PuntoVendita"), titolo("PuntoVendita"), Z5)
                            valorizza(row, tracciatoTitoli.Campi("IndicatoreRataIntermedia"), titolo("RataIntermedia"))
                            valorizza(row, tracciatoTitoli.Campi("ScadenzaPolizza"), titolo("ScadenzaPolizza"), YYYYMMDD)
                            valorizza(row, tracciatoTitoli.Campi("ScadenzaVincolo"), titolo("ScadenzaVincolo"), YYYYMMDD)
                            valorizza(row, tracciatoTitoli.Campi("TargaVeicolo"), titolo("Targa"))
                            valorizza(row, tracciatoTitoli.Campi("TipoUnibox"), titolo("TipoUnibox"))
                            valorizza(row, tracciatoTitoli.Campi("OraEsito"), "24.00.00")
                            valorizza(row, tracciatoTitoli.Campi("OraCopertura"), "24.00.00")

                            valorizza(row, tracciatoTitoli.Campi("PremioRc"), titolo("PremioRC"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("ProvvigioniRc"), titolo("PrvFisseRC"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("PremioIncendioFurto"), titolo("PrIF"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("ProvvigioniIncendioFurto"), titolo("PrvIF"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("PremioInfortuni"), titolo("PrINF"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("ProvvigioniInfortuni"), titolo("PrvINF"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("PremioKasko"), titolo("PrKasko"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("ProvvigioniKasko"), titolo("PrvKasko"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("PremioAssistenza1"), titolo("PrAssistenza"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("ProvvigioniAssistenza1"), titolo("PrvAssistenza"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("IncrementoProduzione"), titolo("IncrProduzione"), F12V3S)
                            valorizza(row, tracciatoTitoli.Campi("Rendita"), titolo("RenditaPrevista"), F10V3S)
                            valorizza(row, tracciatoTitoli.Campi("ProdottoVita"), titolo("ProdottoVita"))
                            'valorizza(row, tracciatoTitoli.Campi("DataRegolazionePremio"), titolo("DataRegolazione"), YYYYMMDD)
                            valorizza(row, tracciatoTitoli.Campi("DataRegolazionePremio"), "00000000")
                            valorizza(row, tracciatoTitoli.Campi("Cin"), titolo("Cin"))
                            valorizza(row, tracciatoTitoli.Campi("Abi"), titolo("Abi"), Z5)
                            valorizza(row, tracciatoTitoli.Campi("Cab"), titolo("Cab"), Z5)
                            valorizza(row, tracciatoTitoli.Campi("Conto"), titolo("ContoCorrente"), "000000000000")
                            valorizza(row, tracciatoTitoli.Campi("RamoGestione"), titolo("RamoGestione"), Z5)
                            'FlagProvvigioniNuovoMandato
                            'FlagIncassoFEA


                            For i As Integer = 1 To 40
                                valorizza(row, tracciatoTitoli.Campi("dettaglioA").Campi("dettaglioA" & i).Campi("CodiceCategoriaRischioA"), 0, Z5)
                                valorizza(row, tracciatoTitoli.Campi("dettaglioA").Campi("dettaglioA" & i).Campi("CodiceTassazioneA"), 0, Z4)
                                valorizza(row, tracciatoTitoli.Campi("dettaglioA").Campi("dettaglioA" & i).Campi("PremioNettoA"), 0, F12V3S)
                                valorizza(row, tracciatoTitoli.Campi("dettaglioA").Campi("dettaglioA" & i).Campi("InteressiA"), 0, F12V3S)
                                valorizza(row, tracciatoTitoli.Campi("dettaglioA").Campi("dettaglioA" & i).Campi("AccessoriA"), 0, F12V3S)
                                valorizza(row, tracciatoTitoli.Campi("dettaglioA").Campi("dettaglioA" & i).Campi("TasseA"), 0, F12V3S)
                                valorizza(row, tracciatoTitoli.Campi("dettaglioA").Campi("dettaglioA" & i).Campi("AliquotaTasseA"), 0, "000.00")

                                valorizza(row, tracciatoTitoli.Campi("dettaglioB").Campi("dettaglioB" & i).Campi("CodiceCategoriaRischioB"), 0, Z5)
                                valorizza(row, tracciatoTitoli.Campi("dettaglioB").Campi("dettaglioB" & i).Campi("TassabileB"), 0, F12V3S)
                                valorizza(row, tracciatoTitoli.Campi("dettaglioB").Campi("dettaglioB" & i).Campi("ProvvigioniB"), 0, F12V3S)
                            Next

                            file.WriteLine(row)

                            ProgressivoRecord += 1
                            If ProgressivoRecord Mod 50000 = 0 Then
                                ProgressivoFile += 1
                                file.Close()
                                file = My.Computer.FileSystem.OpenTextFileWriter(FileTitoliMA(Cartelle.ArchivioFileEsportati, CodiceAgenziaFiglia, ProgressivoFile), False)
                                ProgressivoRecord = 0
                            End If
                            'per la notifica %
                            Progressivo += 1
                            If Progressivo Mod Passo = 0 Then
                                RaiseEvent Stato(CodiceAgenziaFiglia, "Incassi", Progressivo, titoli.Rows.Count)
                            End If
                        Next
                        Globale.Log.Info(String.Format("Esportati {0} incassi nei file MA*.UT?", titoli.Rows.Count))
                        Utx.FunzioniDb.CancellaTabella(c, "TitoliUno")
                    End Using

                    file.Close()
                    RaiseEvent CompattazioneFile(CodiceAgenziaFiglia, "Incassi")
                    For Each f As String In Directory.GetFiles(Cartelle.ArchivioFileEsportati, "MA*.UT?")
                        Dim NomeFileZip As String = Path.Combine(Cartelle.ArchivioFileEsportati, Path.GetFileName(f).Replace(".", "") & ".zip")
                        Utx.LibreriaZip.SevenZip.ZipFile(f, NomeFileZip)
                        IO.File.Delete(f)
                    Next

                    RaiseEvent EsportazioneCompletata("Incassi", False)
                Else
                    Globale.Log.Info(String.Format("File incassi del codice agenzia {0} è stato estratto e inviato a SIA", CodiceAgenziaFiglia))
                End If
                System.Windows.Forms.Application.DoEvents()
            Next
        Catch ex As Exception
            ciSonoErrori = True
            Globale.Log.Errore(ex.Message)
            RaiseEvent EsportazioneCompletata("Incassi", True)
        End Try

        Globale.Log.Info("EsportaIncassi End")
    End Sub

    Private Function FileTitoliMA(Cartella As String, Agenzia As String, Progressivo As Integer) As String
        Return IO.Path.Combine(Cartella, String.Format("MA{0}{1}.UT{2}", 100000 + CInt(Agenzia), dataEstrazione, Progressivo))
    End Function

    Public Sub EsportaPolizze()
        Globale.Log.Info("EsportaPolizze Start")
        Try
            Passo = 500
            Dim tracciatoPolizze As Tracciato = tracciati("/05/L6000")

            For Each CodiceAgenziaFiglia In agenziaMadre.AgenzieCollegate
                Dim Cartelle = New Utx.CartelleAgenziaOmnia(CodiceAgenziaFiglia)

                If IO.Directory.GetFiles(Cartelle.ArchivioFileEsportati, "MA*UAP.zip").Length = 0 Then

                    Dim agenziaFiglia As Utx.AgenziaFigliaOmnia
#If DEBUG Then
                    If PCSTEFANO Or PCGUIDO Then
                        agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia)
                    Else
                        agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia, agenziaMadre.CodiceSede)
                    End If
#Else
                    agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia, agenziaMadre.CodiceSede)
#End If

                    Dim archivi As New Archivi(agenziaMadre, agenziaFiglia, False)

                    Dim nomeFileMa As String = IO.Path.Combine(Cartelle.ArchivioFileEsportati, String.Format("MA{0}{1}.U02", 100000 + CInt(CodiceAgenziaFiglia), dataEstrazione))

                    Using c As New OleDb.OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenziaFiglia, Utx.ConnessioniDb.Db.POLIZZE))
                        c.Open()

                        Using cmd As New OleDbCommand
                            Try
                                Utx.FunzioniDb.CancellaTabella(c, "Polizze1")
                                cmd.Connection = c
                                cmd.CommandType = CommandType.Text
                                cmd.CommandText = String.Format("SELECT dataelaborazione, CodicePuntoVendita, ramo, polizza, flagtiporamo, premionetto," &
                                                                "DataEmissioneStorno, interessi, accessori, premiotassabile, premiolordo, Kilowatt" &
                                                                ", ClasseVeicolo, UsoVeicolo, SettoreTariffa" &
                                                                " INTO Polizze1 FROM Polizze1 IN '{0}' ",
                                                                agenziaFiglia.Cartelle.DatabaseDbUno)
                                cmd.ExecuteNonQuery()

                                Utx.FunzioniDb.CreaIndice(c, "Polizze1", "IP1", {"CodicePuntoVendita", "Ramo", "Polizza"})
                                Utx.FunzioniDb.CreaIndice(c, "MovPolizze", "IMP", {"PolizzaSost", "RamoSost"})

                            Catch ex As Exception

                            End Try

                        End Using

                        Dim campi As String = "P1.DataElaborazione, Agenzia, P.Ramo, P.Polizza, CodiceSubAgente, CodiceProduttore, CodiceProdotto" &
                            ", TipoPolProd, Frazionamento, CodicePagamento, Convenzione, DataEffetto, DataScadenza, IDStorno" &
                            ", DataStorno, DataEmissioneStorno, FlagSospesa, DataEffettoSospesa, Clausole, CodiceFiscale, TotalePremioAnnuo, Targa" &
                            ", UsoRca, SettoreTariffario, CodiceUtilizzoVeicolo, AlimentazioneVeicolo, CavalliFiscali" &
                            ", ImmatricVeicolo, TipoTariffa, CombinazioneMassimali, FlagFlessibilita, PercentualeFlessibilita" &
                            ", ValoreIncendioFurto, CodiceGaranziaInfortuni, DiariaRitiroPatente, CodiceGaranzieAccessorie" &
                            ", MarcaVeicolo, FlagRegolazionePremio, EsercizioCompetenza, ClasseBonusMalus, RamoGestione" &
                            ", flagtiporamo, premionetto, interessi, accessori, premiotassabile, premiolordo, Kilowatt" &
                            ", ClasseVeicolo, UsoVeicolo, SettoreTariffa, (SELECT count(*) FROM MovPolizze M WHERE M.PolizzaSost = P.Polizza AND M.RamoSost = P.ramo) as NP"

                        Dim file As System.IO.StreamWriter
                        file = My.Computer.FileSystem.OpenTextFileWriter(nomeFileMa, False)

                        Dim sql As String = "SELECT {0} FROM Polizze P" &
                                            "  LEFT JOIN Polizze1 P1 ON P.Agenzia = P1.CodicePuntoVendita" &
                                            "   AND P.Ramo = P1.Ramo AND P.Polizza = P1.Polizza" &
                                            " UNION SELECT {0} FROM MovPolizze P" &
                                            "  LEFT JOIN Polizze1 P1 ON P.Agenzia = P1.CodicePuntoVendita" &
                                            "   AND P.Ramo = P1.Ramo AND P.Polizza = P1.Polizza"

                        Progressivo = 0
                        Dim polizze As DataTable = Utx.FunzioniDb.CreaDataTable(String.Format(sql, campi), c)

                        'sistemazione della data di elaborazione
                        For Each polizza As DataRow In polizze.Rows
                            If Not IsDBNull(polizza("DataElaborazione")) Then
                                'non fare niente: è già ok
                            ElseIf IsDBNull(polizza("DataStorno")) Then
                                polizza("IDStorno") = ""
                                polizza("DataElaborazione") = polizza("DataEffetto")
                            ElseIf polizza("DataStorno") < #1/1/1900# Then
                                polizza("IDStorno") = ""
                                polizza("DataStorno") = DBNull.Value
                                polizza("DataElaborazione") = polizza("DataEffetto")
                            Else
                                polizza("DataElaborazione") = polizza("DataStorno")
                                polizza("DataEmissioneStorno") = polizza("DataStorno")
                            End If
                        Next
#If DEBUG Then
                        'Using f As New Utx.FormDebug(polizze)
                        '    f.ShowDialog()
                        'End Using
#End If

                        For Each polizza As DataRow In polizze.Rows
                            Dim row As String = "00000000000000000000000000000000000000000000000000000          00000 00000000000000000000000000000000000000000000000000000000  0000000000000000  000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000                                         0                                         0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000 0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000                      000              00000000000000000000000 00000000000000000000000000       0000000000000000000                     00000000  000000 000000 000000000 00000000000000000 000  000 0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000 000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000 0000000000000000000000000000000000000000000000000000000000       0       0000000000000000 0000 0000000            0000000000000  00000  00000000000000000000000000000000000000000                          00000     0000000 00000000          00000000             0000000000000000000000            0000000000000000000000             0000000000000000000000             0000000000000000000000             0000000000000000000000             0000000000000000000000             0000000000000000000000000000000000000000 00000000000            00000000000            00000000000             00000000000             00000000000                          00000000000000000000000000000000000000000000      0000000    00000000000      00000000000   000            00000000000 00000000000000            0000000000000000000000000            0000000000000000000000000            0000000000000000000000000            0000000000000000000000000            0000000000000000000000000            0000000000000000000000000            0000000000000000000000000            0000000000000000000000000             00000000000000             000000000000000000000000000000000000000000000000000000000000000000000000                                         000000            0000000000000000000000000            0000000000000000000000000            00000000000000            0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000 000000000000000000000000000000000000000000000000000000000000000000000000000 000000000000                              0 000    00000000000000000000000000  0000000            000    000/00       00000000                   00000000000                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            *"

                            valorizza(row, tracciatoPolizze.Campi("DataElaborazione"), polizza("dataelaborazione"), YYYYMMDD)
                            valorizza(row, tracciatoPolizze.Campi("CodicePuntoVendita"), CodiceAgenziaFiglia)
                            valorizza(row, tracciatoPolizze.Campi("Progressivo"), "01")
                            valorizza(row, tracciatoPolizze.Campi("TipoElaborazione"), "05")
                            valorizza(row, tracciatoPolizze.Campi("Ramo"), polizza("Ramo"), Z3)
                            valorizza(row, tracciatoPolizze.Campi("Polizza"), polizza("Polizza"), Z9)
                            valorizza(row, tracciatoPolizze.Campi("CodiceSubagenzia"), polizza("CodiceSubAgente"), Z3)
                            valorizza(row, tracciatoPolizze.Campi("CodiceProduttore"), polizza("CodiceProduttore"), Z7)
                            valorizza(row, tracciatoPolizze.Campi("CodiceProdotto"), polizza("CodiceProdotto"))
                            valorizza(row, tracciatoPolizze.Campi("TipoPolizza"), polizza("TipoPolProd"), Z5)
                            valorizza(row, tracciatoPolizze.Campi("Frazionamento"), polizza("Frazionamento"))
                            valorizza(row, tracciatoPolizze.Campi("CodicePagamento"), polizza("CodicePagamento"), Z3)
                            valorizza(row, tracciatoPolizze.Campi("CodiceConvenzione"), polizza("Convenzione"))
                            valorizza(row, tracciatoPolizze.Campi("DataEffettoPolizza"), polizza("DataEffetto"), YYYYMMDD)
                            valorizza(row, tracciatoPolizze.Campi("DataScadenzaPolizza"), polizza("DataScadenza"), YYYYMMDD)
                            valorizza(row, tracciatoPolizze.Campi("CodiceTipoStorno"), polizza("IDStorno"))
                            valorizza(row, tracciatoPolizze.Campi("DataEffettoStorno"), polizza("DataStorno"), YYYYMMDD)
                            valorizza(row, tracciatoPolizze.Campi("DataEmissioneStorno"), polizza("DataEmissioneStorno"), YYYYMMDD)
                            valorizza(row, tracciatoPolizze.Campi("FlagSospesa"), polizza("FlagSospesa"))
                            valorizza(row, tracciatoPolizze.Campi("DataEffettoSospesa"), polizza("DataEffettoSospesa"), YYYYMMDD)

                            Dim i As Integer = 0
                            For Each clausola As String In polizza("Clausole").ToString.Split("*"c)
                                If clausola <> "" Then
                                    i = i + 1
                                    If i <= 20 Then
                                        valorizza(row, tracciatoPolizze.Campi("PolizzeClausole").Campi("PolizzeClausole" & i).Campi("Clausola"), clausola)
                                    End If
                                End If
                            Next
                            valorizza(row, tracciatoPolizze.Campi("CodiceFiscale"), polizza("CodiceFiscale"))
                            valorizza(row, tracciatoPolizze.Campi("TargaVeicolo"), polizza("Targa"))
                            valorizza(row, tracciatoPolizze.Campi("UsoVeicolo"), polizza("UsoRca"))
                            valorizza(row, tracciatoPolizze.Campi("SettoreTariffa"), polizza("SettoreTariffario"))
                            valorizza(row, tracciatoPolizze.Campi("UtilizzoAuto"), polizza("CodiceUtilizzoVeicolo"))
                            valorizza(row, tracciatoPolizze.Campi("TipoAlimentazione"), polizza("AlimentazioneVeicolo"))
                            valorizza(row, tracciatoPolizze.Campi("HpVeicolo"), polizza("CavalliFiscali"), "000")
                            valorizza(row, tracciatoPolizze.Campi("AnnoMeseImmatricolazione"), polizza("ImmatricVeicolo"))
                            valorizza(row, tracciatoPolizze.Campi("TipoTariffa"), polizza("TipoTariffa"))
                            valorizza(row, tracciatoPolizze.Campi("CombinazioniMassimali"), polizza("CombinazioneMassimali"))
                            valorizza(row, tracciatoPolizze.Campi("FlagFlessibilita"), polizza("FlagFlessibilita"))
                            valorizza(row, tracciatoPolizze.Campi("PercentualeFlessibilita"), polizza("PercentualeFlessibilita"), 10000, Z7)
                            valorizza(row, tracciatoPolizze.Campi("IncendioCapitale"), polizza("ValoreIncendioFurto"), 100, "0000000000000")
                            valorizza(row, tracciatoPolizze.Campi("InfortuniCombinazione"), polizza("CodiceGaranziaInfortuni"))
                            valorizza(row, tracciatoPolizze.Campi("RitiroPatenteDiaria"), polizza("DiariaRitiroPatente"), 100, "00000000000")
                            valorizza(row, tracciatoPolizze.Campi("GaranzieAccessorieCombinazione"), polizza("CodiceGaranzieAccessorie"))
                            valorizza(row, tracciatoPolizze.Campi("MarcaVeicolo"), polizza("MarcaVeicolo"))
                            valorizza(row, tracciatoPolizze.Campi("FlagRegolazionePremio"), polizza("FlagRegolazionePremio"))
                            valorizza(row, tracciatoPolizze.Campi("EsercizioCompetenza"), polizza("EsercizioCompetenza"))
                            valorizza(row, tracciatoPolizze.Campi("ScalaBonusMaius"), polizza("ClasseBonusMalus"))

                            If polizza("NP") > 0 Then
                                i = 0
                                For Each sostituita As DataRow In Utx.FunzioniDb.CreaDataTable(String.Format("SELECT Ramo, Polizza FROM MovPolizze WHERE PolizzaSost = {1} AND RamoSost = {0}", polizza("Ramo"), polizza("Polizza")), c).Rows
                                    i = i + 1
                                    If i <= 6 Then
                                        valorizza(row, tracciatoPolizze.Campi("PolizzeSostituite").Campi("PolizzeSostituite" & i).Campi("VecchioCodiceRamo"), sostituita("Ramo"), Z3)
                                        valorizza(row, tracciatoPolizze.Campi("PolizzeSostituite").Campi("PolizzeSostituite" & i).Campi("VecchioNumeroPolizza"), sostituita("Polizza"), Z9)
                                    End If
                                Next
                            End If

                            If IsDBNull(polizza("flagtiporamo")) Then
                                Dim tipoRamo As Integer = 2
                                If polizza("RamoGestione") < 3 Then
                                    tipoRamo = 1
                                ElseIf polizza("RamoGestione") >= 18 And polizza("RamoGestione") <= 20 Then
                                    tipoRamo = 3
                                End If

                                valorizza(row, tracciatoPolizze.Campi("FlagTipoRamo"), tipoRamo)
                                valorizza(row, tracciatoPolizze.Campi("PremioTassabile"), polizza("TotalePremioAnnuo"), 100, "0000000000000")
                            Else
                                valorizza(row, tracciatoPolizze.Campi("FlagTipoRamo"), polizza("flagtiporamo"))
                                valorizza(row, tracciatoPolizze.Campi("PremioNetto"), polizza("premionetto"), 100, "0000000000000")
                                valorizza(row, tracciatoPolizze.Campi("Interessi"), polizza("interessi"), 100, "0000000000000")
                                valorizza(row, tracciatoPolizze.Campi("Accessori"), polizza("accessori"), 100, "0000000000000")
                                valorizza(row, tracciatoPolizze.Campi("PremioTassabile"), polizza("premiotassabile"), 100, "0000000000000")
                                valorizza(row, tracciatoPolizze.Campi("PremioLordo"), polizza("premiolordo"), 100, "0000000000000")
                                valorizza(row, tracciatoPolizze.Campi("Kilowatt"), polizza("Kilowatt"))
                                valorizza(row, tracciatoPolizze.Campi("ClasseVeicolo"), polizza("ClasseVeicolo"))
                                valorizza(row, tracciatoPolizze.Campi("UsoVeicolo"), polizza("UsoVeicolo"))
                                valorizza(row, tracciatoPolizze.Campi("SettoreTariffa"), polizza("SettoreTariffa"))
                            End If
                            file.WriteLine(row)

                            Progressivo += 1
                            If Progressivo Mod Passo = 0 Then
                                RaiseEvent Stato(CodiceAgenziaFiglia, "Polizze", Progressivo, polizze.Rows.Count)
                            End If
                        Next

                        file.Close()
                        Globale.Log.Info(String.Format("Esportati {0} polizze", polizze.Rows.Count))
                        Utx.FunzioniDb.CancellaTabella(c, "Polizze1")
                        Utx.FunzioniDb.CancellaChiaveDb(c, "MovPolizze", "IMP")
                    End Using

                    RaiseEvent CompattazioneFile(CodiceAgenziaFiglia, "Polizze")

                    Dim nomeFileZip As String = Path.Combine(Cartelle.ArchivioFileEsportati, String.Format("MA{0}{1}UAP.zip", 100000 + CInt(CodiceAgenziaFiglia), dataEstrazione))
                    For Each f As String In Directory.GetFiles(Cartelle.ArchivioFileEsportati, "MA*.U??")
                        Utx.LibreriaZip.SevenZip.ZipFile(f, nomeFileZip)
                        IO.File.Delete(f)
                    Next

                    RaiseEvent EsportazioneCompletata("Polizze", False)
                Else
                    Globale.Log.Info(String.Format("File polizze del codice agenzia {0} è stato estratto e inviato a SIA", CodiceAgenziaFiglia))
                End If
                System.Windows.Forms.Application.DoEvents()
            Next
        Catch ex As Exception
            ciSonoErrori = True
            Globale.Log.Errore(ex.Message)
            RaiseEvent EsportazioneCompletata("Polizze", True)
        End Try

        Globale.Log.Info("EsportaPolizze End")
    End Sub

    Public Function InviaDati2SIA() As Boolean
#If Not DEBUG Then
        If My.Computer.Name.ToUpper = "X390-GUIDO" Then
            Return True
        End If
#End If
        Try
            Dim Patterns As New List(Of String)
            Dim Filtro As String = Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "Esporta2Sia.ini")

            If IO.File.Exists(Filtro) Then
                For Each est As String In IO.File.ReadAllText(Filtro).Split(";"c)
                    Patterns.Add(est)
                Next
            Else
                Patterns.Add("MA*U??.ZIP")
            End If

            ListaInviati = New List(Of String)

            For Each CodiceAgenziaFiglia In agenziaMadre.AgenzieCollegate
                Dim Cartelle = New Utx.CartelleAgenziaOmnia(CodiceAgenziaFiglia)

                For Each p As String In Patterns
                    Dim FileTotali As Integer = Directory.GetFiles(Cartelle.ArchivioFileEsportati, p).Length
                    Dim Progressivo As Integer = 0

                    For Each f As String In Directory.GetFiles(Cartelle.ArchivioFileEsportati, p)
                        Progressivo += 1

                        RaiseEvent Messaggio(String.Format("{0}: invio file {1} ({2}/{3})",
                                                           CodiceAgenziaFiglia, Path.GetFileName(f), Progressivo, FileTotali))
                        'invio a SIA
                        Dim Esito As String = Utx.SIA.InviaFileMA(CodiceAgenziaFiglia, f)
                        Globale.Log.Info("Invio file {0} - Esito: {1}", {f, Esito})
                        System.Windows.Forms.Application.DoEvents()

                        If Esito.StartsWith("OK") Then
                            ListaInviati.Add(String.Format("{0} - {1}", Path.GetFileName(f), Utx.NetFunc.DimensioneFile(f)))
                        Else
                            RaiseEvent Messaggio("Si è verificato un errore nell'invio dei file.")
                            ciSonoErrori = True
                            Return False
                        End If
                    Next
                Next
            Next
            Return True
        Catch ex As Exception
            ciSonoErrori = True
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Sub EsportaTipoRecord23()
        Globale.Log.Info("EsportaTipoRecord23 Start")
        Dim ProgressivoRecord As Integer = 0
        Try
            Passo = 500

            For Each CodiceAgenziaFiglia In agenziaMadre.AgenzieCollegate
                Dim Cartelle = New Utx.CartelleAgenziaOmnia(CodiceAgenziaFiglia)

                If IO.Directory.GetFiles(Cartelle.ArchivioFileEsportati, "MA*UB?.zip").Length > 0 Then
                    Globale.Log.Info(String.Format("File Tipo Record 23 del codice agenzia {0} è stato estratto e inviato a SIA", CodiceAgenziaFiglia))
                Else

                    Dim agenziaFiglia As Utx.AgenziaFigliaOmnia
#If DEBUG Then
                    If PCSTEFANO Or PCGUIDO Then
                        agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia)
                    Else
                        agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia, agenziaMadre.CodiceSede)
                    End If
#Else
                    agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia, agenziaMadre.CodiceSede)
#End If

                    Dim fileOut As System.IO.StreamWriter
                    Dim ProgressivoFile As Integer = 1
                    Dim nomeFileOut As String = IO.Path.Combine(Cartelle.ArchivioFileEsportati, String.Format("MA{0}{1}.UB{2}", 100000 + CInt(CodiceAgenziaFiglia), dataEstrazione, ProgressivoFile))
                    fileOut = My.Computer.FileSystem.OpenTextFileWriter(nomeFileOut, False)

                    Progressivo = 0

                    Dim sb As New StringBuilder

                    For Each Codice In agenziaFiglia.Config
                        For Each fileIn In IO.Directory.GetFiles(Codice.Cartelle.ArchivioFileOmnia)
                            Dim nomeFilein = IO.Path.GetFileName(fileIn).ToUpper
                            Dim nomeFileMA As String = Archivio.NomeSenzaEstenzioneZip(nomeFilein)

                            If (nomeFileMA.ToUpper Like "MA############.###") Then
                                If Codice.AgenziaCollegata.Equals(nomeFileMA.Substring(3, 5)) Then

                                    Dim archivi As List(Of String) = Utx.LibreriaZip.SevenZip.UnZipFile(fileIn, Codice.Cartelle.CartellaArriviLocaleTempOmnia)

                                    For Each archivio In archivi
                                        Globale.Log.Info(String.Format("elaborazione del file {0}", archivio))

                                        Dim FullPathArchivio As String = Path.Combine(Codice.Cartelle.CartellaArriviLocaleTempOmnia, archivio)

                                        Using reader = New IO.StreamReader(FullPathArchivio)
                                            Dim rownumber As Integer = 0

                                            While (reader.Peek() <> -1)
                                                Dim sRow As String = reader.ReadLine()

                                                If sRow.Length = 6000 AndAlso sRow.Substring(15, 2) = "23" Then
                                                    'fileOut.WriteLine(sRow)
                                                    sb.AppendLine(sRow)

                                                    ProgressivoRecord += 1
                                                    If ProgressivoRecord = 50000 Then
                                                        ProgressivoFile += 1
                                                        fileOut.Write(sb.ToString)
                                                        sb.Clear()
                                                        fileOut.Close()

                                                        nomeFileOut = IO.Path.Combine(Cartelle.ArchivioFileEsportati, String.Format("MA{0}{1}.UB{2}", 100000 + CInt(CodiceAgenziaFiglia), dataEstrazione, ProgressivoFile))
                                                        fileOut = My.Computer.FileSystem.OpenTextFileWriter(nomeFileOut, False)
                                                        ProgressivoRecord = 0
                                                    End If

                                                    Progressivo += 1
                                                    If Progressivo Mod Passo = 0 Then
                                                        fileOut.Write(sb.ToString)
                                                        sb.Clear()
                                                        RaiseEvent Stato(CodiceAgenziaFiglia, "Tipo Record 23: ", Progressivo, 0)
                                                    End If
                                                ElseIf sRow.Length = 100 Then
                                                    Globale.Log.Info(String.Format("errore in file {0}: lunghezza row = {1}", nomeFileMA, sRow.Length))
                                                    Globale.Log.Info(sRow)
                                                End If
                                            End While

                                            reader.Close()
                                        End Using

                                        IO.File.Delete(FullPathArchivio)
                                    Next
                                End If
                            End If
                        Next
                    Next

                    fileOut.Close()
                    Globale.Log.Info(String.Format("Esportati {0} Tipo Record 23", Progressivo))

                    RaiseEvent CompattazioneFile(CodiceAgenziaFiglia, "Tipo Record 23")

                    For Each f As String In Directory.GetFiles(Cartelle.ArchivioFileEsportati, "MA*.UB?")
                        Dim NomeFileZip As String = Path.Combine(Cartelle.ArchivioFileEsportati, Path.GetFileName(f).Replace(".", "") & ".zip")
                        Utx.LibreriaZip.SevenZip.ZipFile(f, NomeFileZip)
                        IO.File.Delete(f)
                    Next
                    RaiseEvent EsportazioneCompletata("Tipo Record 23", False)
                End If
                System.Windows.Forms.Application.DoEvents()
            Next
        Catch ex As Exception
            ciSonoErrori = True
            Globale.Log.Errore(ex.Message)
            RaiseEvent EsportazioneCompletata("Tipo Record 23", True)
        End Try

        Globale.Log.Info("EsportaTipoRecord23 End")
    End Sub

    Public Sub InviaNotifica()
        Globale.Log.Info("Invio notifiche")

        Dim logs As New List(Of String) From {Globale.Log.FullPathLogFile}

        Try
            Dim sb As New Text.StringBuilder
            With sb
                .AppendLine(String.Format("Agenzia madre: {0} - {1}", Utx.Globale.ProfiloEnteGestore.AgenziaMadre, Utx.Globale.ProfiloEnteGestore.Localita))
                .AppendLine(String.Format("Versione: {0}", Windows.Forms.Application.ProductVersion))
                .AppendLine(String.Format("Pc: {0}", Environment.MachineName))
                .AppendLine(String.Format("Utente pc: {0}", Environment.UserName))
                .AppendLine(String.Format("Utente uniage: {0}", Utx.Globale.UtenteCorrente.UniageUser))
                .AppendLine()

                If ListaInviati.Count = 0 Then
                    .AppendLine("Non è stato inviato alcun file.")
                Else
                    .AppendLine("File inviati:")
                    For Each f As String In ListaInviati
                        .AppendLine(f)
                    Next
                End If
            End With

            Dim p As New UniCom.Postino
            With p
                'testo
                .Testo = sb.ToString
                'allego i log
                Dim logzipfile As String = IO.Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "logs.zip")

                If IO.File.Exists(logzipfile) Then
                    IO.File.Delete(logzipfile)
                End If

                If Utx.LibreriaZip.SevenZip.ZipFile(logs.ToArray(), logzipfile) Then
                    .AddAllegato(logzipfile)
                Else
                    For Each l In logs
                        .AddAllegato(l)
                    Next
                End If
                'oggetto
                If CBool(Utx.Globale.SettingInterop.LeggiValore(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_ERRORE, "False")) = True Then
                    .Oggetto = String.Format("Migrazione dati Agenzia {0} - {1}: ERRORE", Utx.Globale.ProfiloEnteGestore.AgenziaMadre, Utx.Globale.ProfiloEnteGestore.Localita)
                Else
                    .Oggetto = String.Format("Migrazione dati Agenzia {0} - {1}: OK", Utx.Globale.ProfiloEnteGestore.AgenziaMadre, Utx.Globale.ProfiloEnteGestore.Localita)
                End If
                'mittente e destinatari
                .EmailAutomatica = True
                .Mittente = UniCom.Postino.MittenteAgenzia
                .NomeMittente = "Migrazione dati"
                .InviaA.Add("guidolampo@tiscali.it")
#If Not DEBUG Then
                    .InviaCc.Add("SIA_omniamanager@siaspa.com")
#End If
                .InviaMail()

                IO.File.Delete(logzipfile)
            End With

        Catch ex As Exception
            Globale.Log.Info("Errore nell'invio delle notifiche")
            Globale.Log.Info(ex)
        End Try
    End Sub
End Class
