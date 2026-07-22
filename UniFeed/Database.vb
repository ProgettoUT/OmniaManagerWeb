Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms
Imports Utx.SettingAgenzia

Class Database

    Public HasErrors As Boolean
    Public ErrorNumber As Long
    Public ErrorDescription As String

    Public command As OleDbCommand
    Private agenzia As Utx.AgenziaFigliaOmnia
    'Private Shared contatore As Long = 1

    Public Sub New(agenzia As Utx.AgenziaFigliaOmnia)
        Me.agenzia = agenzia
        'copia modello dbuno nella cartella temp 
        Me.SpostaDbUnoInCartellaLocale()
        'apre connessione
        ApriConnessione(agenzia.ConnectionStringDbUnoTemp)
    End Sub

    Public Sub ApriConnessione(ByRef connectionString As String)
        Try
            command = New OleDbCommand() With {.Connection = New OleDbConnection(connectionString)}
            command.Connection.Open()

            agenzia.Connessione = command.Connection

            If Utx.FunzioniDb.EsisteTabella(agenzia.Connessione, "Polizze4") = False Then
                Dim sql As New Text.StringBuilder
                sql.AppendLine("CREATE TABLE Polizze4 (")
                sql.AppendLine("ProgressivoFile      INTEGER,")
                sql.AppendLine("DataElaborazione     DATE,")
                sql.AppendLine("CodicePuntoVendita   INTEGER,")
                sql.AppendLine("Progressivo          CHAR(2),")
                sql.AppendLine("TipoElaborazione     CHAR(2),")
                sql.AppendLine("Ramo                 SMALLINT,")
                sql.AppendLine("Polizza              INTEGER,")
                sql.AppendLine("ValtNazione          CHAR(03),")
                sql.AppendLine("VassEstensioneRim    CHAR(01),")
                sql.AppendLine("VassFascia           VARCHAR(10),")
                sql.AppendLine("VatrFlPolGratuita    CHAR(01),")
                sql.AppendLine("VatrDichContr        CHAR(01),")
                sql.AppendLine("VatrFlAqua           CHAR(01),")
                sql.AppendLine("VoctDataEdizInfopriv CHAR(08),")
                sql.AppendLine("VoctCodInfopriv      CHAR(10),")
                sql.AppendLine("VoctTitoloModulo     CHAR(01),")
                sql.AppendLine("VoctProprDispos      CHAR(01),")
                sql.AppendLine("VoctContattContr     CHAR(01),")
                sql.AppendLine("VoctConsCommm        CHAR(01),")
                sql.AppendLine("VoctConsProfil       CHAR(01),")
                sql.AppendLine("FeaOmniacrm          VARCHAR(15),")
                sql.AppendLine("Fea                  CHAR(01),")
                sql.AppendLine("FeaMail              CHAR(01),")
                sql.AppendLine("VeicStorico          CHAR(01),")
                sql.AppendLine("ExRete1              CHAR(01),")
                sql.AppendLine("NumArchivio          CHAR(11),")
                sql.AppendLine("PRIMARY KEY(CodicePuntoVendita, Ramo, Polizza))")
                Aggiorna(sql.ToString)
            End If

            If Utx.FunzioniDb.EsisteTabella(agenzia.Connessione, "Clienti1") = False Then
                Dim sql As New Text.StringBuilder
                sql.AppendLine("CREATE TABLE Clienti1(")
                sql.AppendLine("[ProgressivoFile]               INTEGER,")
                sql.AppendLine("[DataElaborazione]              DATE,")
                sql.AppendLine("[CodicePuntoVendita]            CHAR(5),")
                sql.AppendLine("[Progressivo]                   CHAR(2),")
                sql.AppendLine("[TipoElaborazione]              CHAR(2),")
                sql.AppendLine("[AgenziaMadre]                  CHAR(5),")
                sql.AppendLine("[CodiceSubagenziaAnag]          CHAR(5),")
                sql.AppendLine("[CodiceProduttoreAnag]          CHAR(5),")
                sql.AppendLine("[NaturaGiuridica]               CHAR(1),")
                sql.AppendLine("[CodiceFiscale]                 VARCHAR(16),")
                sql.AppendLine("[Cognome]                       VARCHAR(40),")
                sql.AppendLine("[Nome]                          VARCHAR(25),")
                sql.AppendLine("[EntePubblico]                  CHAR(1),")
                sql.AppendLine("[ToponimoResidenza]             VARCHAR(50),")
                sql.AppendLine("[IndirizzoResidenza]            VARCHAR(50),")
                sql.AppendLine("[NumCivicoResidenza]            VARCHAR(15),")
                sql.AppendLine("[LocalitaResidenza]             VARCHAR(50),")
                sql.AppendLine("[ComuneResidenza]               VARCHAR(50),")
                sql.AppendLine("[CapResidenza]                  CHAR(5),")
                sql.AppendLine("[ProvinciaResidenza]            VARCHAR(5),")
                sql.AppendLine("[CodiceStatoResidenza]          CHAR(3),")
                sql.AppendLine("[IndirizzoResidenzaBreve]       VARCHAR(35),")
                sql.AppendLine("[LocalitaResidenzaBreve]        VARCHAR(35),")
                sql.AppendLine("[ComuneResidenzaBreve]          VARCHAR(30),")
                sql.AppendLine("[ToponimoDomicilio]             VARCHAR(50),")
                sql.AppendLine("[IndirizzoDomicilio]            VARCHAR(50),")
                sql.AppendLine("[NumCivicoDomicilio]            VARCHAR(15),")
                sql.AppendLine("[LocalitaDomicilio]             VARCHAR(50),")
                sql.AppendLine("[ComuneDomicilio]               VARCHAR(50),")
                sql.AppendLine("[CapDomicilio]                  CHAR(5),")
                sql.AppendLine("[ProvinciaDomicilio]            VARCHAR(5),")
                sql.AppendLine("[CodiceStatoDomicilio]          CHAR(3),")
                sql.AppendLine("[IndirizzoDomicilioBreve]       VARCHAR(35),")
                sql.AppendLine("[LocalitaDomicilioBreve]        VARCHAR(35),")
                sql.AppendLine("[ComuneDomicilioBreve]          VARCHAR(30),")
                sql.AppendLine("[TelefonoPrincipale]            VARCHAR(14),")
                sql.AppendLine("[Cellulare]                     VARCHAR(14),")
                sql.AppendLine("[IndirizzoEMail]                VARCHAR(100),")
                sql.AppendLine("[IndirizzoPec]                  VARCHAR(100),")
                sql.AppendLine("[FaxPrincipale]                 VARCHAR(14),")
                sql.AppendLine("[TelefonoSecondario]            VARCHAR(14),")
                sql.AppendLine("[TelefonoUfficio]               VARCHAR(14),")
                sql.AppendLine("[TelefonoReferente]             VARCHAR(14),")
                sql.AppendLine("[NominativoReferente]           VARCHAR(40),")
                sql.AppendLine("[TipoCliente]                   CHAR(5),")
                sql.AppendLine("[FlagClienteTop]                CHAR(1),")
                sql.AppendLine("[ClienteTopDal]                 DATE,")
                sql.AppendLine("[Sesso]                         CHAR(1),")
                sql.AppendLine("[DataNascita]                   DATE,")
                sql.AppendLine("[LuogoNascita]                  VARCHAR(30),")
                sql.AppendLine("[TipoConsenso]                  CHAR(2),")
                sql.AppendLine("[DataConsenso]                  DATE,")
                sql.AppendLine("[DataRevocaConsenso]            DATE,")
                sql.AppendLine("[AutorizzazioneFea]             CHAR(1),")
                sql.AppendLine("[DataAutorizzazioneFea]         DATE,")
                sql.AppendLine("[TipoCodiceAtecoAnag]           CHAR(1),")
                sql.AppendLine("[CodiceAtecoAnag]               CHAR(6),")
                sql.AppendLine("[DescrizioneAtecoAnag]          VARCHAR(255),")
                sql.AppendLine("[NumDipendentiAteco]            VARCHAR(10),")
                sql.AppendLine("[FatturatoAteco]                VARCHAR(15),")
                sql.AppendLine("[PercentualeFatturatoEstero]    CHAR(3),")
                sql.AppendLine("[FasciaReddito]                 CHAR(1),")
                sql.AppendLine("[StatoCivile]                   CHAR(1),")
                sql.AppendLine("[Figli]                         CHAR(1),")
                sql.AppendLine("[AnnoNascitaFiglio1]            SHORT,")
                sql.AppendLine("[AnnoNascitaFiglio2]            SHORT,")
                sql.AppendLine("[AnnoNascitaFiglio3]            SHORT,")
                sql.AppendLine("[AnnoNascitaFiglio4]            SHORT,")
                sql.AppendLine("[TitoloStudio]                  CHAR(1),")
                sql.AppendLine("[InteressiFaidate]              CHAR(1),")
                sql.AppendLine("[InteressiMusica]               CHAR(1),")
                sql.AppendLine("[InteressiLettura]              CHAR(1),")
                sql.AppendLine("[InteressiTecnologia]           CHAR(1),")
                sql.AppendLine("[InteressiSport]                CHAR(1),")
                sql.AppendLine("[InteressiViaggi]               CHAR(1),")
                sql.AppendLine("[InteressiSalute]               CHAR(1),")
                sql.AppendLine("[InteressiNatura]               CHAR(1),")
                sql.AppendLine("[InteressiVolontariato]         CHAR(1),")
                sql.AppendLine("[InteressiFoto]                 CHAR(1),")
                sql.AppendLine("[InteressiMotori]               CHAR(1),")
                sql.AppendLine("[InteressiEnogastronomia]       CHAR(1),")
                sql.AppendLine("[InternetAcquisti]              CHAR(1),")
                sql.AppendLine("[InternetApplicazioni]          CHAR(1),")
                sql.AppendLine("[InternetLavoro]                CHAR(1),")
                sql.AppendLine("[InternetSocial]                CHAR(1),")
                sql.AppendLine("[CasaProprieta]                 CHAR(1),")
                sql.AppendLine("[CasaAffitto]                   CHAR(1),")
                sql.AppendLine("[CasaSeconda]                   CHAR(1),")
                sql.AppendLine("[CasaMutuo]                     CHAR(1),")
                sql.AppendLine("[CasaProprietaMutuoSeconda]     CHAR(1),")
                sql.AppendLine("[TipoRisparmiatore]             CHAR(1),")
                sql.AppendLine("[InfoRisparmiarePolizzaAuto]    CHAR(1),")
                sql.AppendLine("[InfoIntegrarePensione]         CHAR(1),")
                sql.AppendLine("[InfoRisparmiareNoRischi]       CHAR(1),")
                sql.AppendLine("[InfoGarantireStudiFigli]       CHAR(1),")
                sql.AppendLine("[InfoFarRendereCapitale]        CHAR(1),")
                sql.AppendLine("[InfoLasciareEredita]           CHAR(1),")
                sql.AppendLine("[InfoAssistenzaSanitaria]       CHAR(1),")
                sql.AppendLine("[InfoTerremoto]                 CHAR(1),")
                sql.AppendLine("[InfoDifesaDanni]               CHAR(1),")
                sql.AppendLine("[InfoIndennizzoMalattia]        CHAR(1),")
                sql.AppendLine("[InfoPerditaImpiego]            CHAR(1),")
                sql.AppendLine("[PrevisioneCambioAuto]          CHAR(1),")
                sql.AppendLine("[PrevisioneCambioCasa]          CHAR(1),")
                sql.AppendLine("[PrevisioneMutuo]               CHAR(1),")
                sql.AppendLine("[PrevisioneNuovaAttivita]       CHAR(1),")
                sql.AppendLine("[PrevisionePromozione]          CHAR(1),")
                sql.AppendLine("[PrevisioneVacanza]             CHAR(1),")
                sql.AppendLine("[PrevisioneFineStudioFigli]     CHAR(1),")
                sql.AppendLine("[PrevisionePensione]            CHAR(1),")
                sql.AppendLine("[DataAggDatiSocioeconomici]     DATE,")
                sql.AppendLine("[TipoDocumento1]                CHAR(3),")
                sql.AppendLine("[NumeroDocumento1]              VARCHAR(15),")
                sql.AppendLine("[AutoritaRilascioDocumento1]    VARCHAR(30),")
                sql.AppendLine("[ProvinciaRilascioDocumento1]   VARCHAR(05),")
                sql.AppendLine("[LocalitaRilascioDocumento1]    VARCHAR(30),")
                sql.AppendLine("[DataRilascioDocumento1]        DATE,")
                sql.AppendLine("[DataScadenzaDocumento1]        DATE,")
                sql.AppendLine("[TipoDocumento2]                CHAR(3),")
                sql.AppendLine("[NumeroDocumento2]              VARCHAR(15),")
                sql.AppendLine("[AutoritaRilascioDocumento2]    VARCHAR(30),")
                sql.AppendLine("[ProvinciaRilascioDocumento2]   VARCHAR(05),")
                sql.AppendLine("[LocalitaRilascioDocumento2]    VARCHAR(30),")
                sql.AppendLine("[DataRilascioDocumento2]        DATE,")
                sql.AppendLine("[DataScadenzaDocumento2]        DATE,")
                sql.AppendLine("[TipoDocumento3]                CHAR(3),")
                sql.AppendLine("[NumeroDocumento3]              VARCHAR(15),")
                sql.AppendLine("[AutoritaRilascioDocumento3]    VARCHAR(30),")
                sql.AppendLine("[ProvinciaRilascioDocumento3]   VARCHAR(05),")
                sql.AppendLine("[LocalitaRilascioDocumento3]    VARCHAR(30),")
                sql.AppendLine("[DataRilascioDocumento3]        DATE,")
                sql.AppendLine("[DataScadenzaDocumento3]        DATE,")
                sql.AppendLine("[PresenzaCapoFamiglia]          CHAR(1),")
                sql.AppendLine("[CodiceFiscaleCapoFamiglia]     VARCHAR(16),")
                sql.AppendLine("[NumeroComponentiNucleo]        CHAR(3),")
                sql.AppendLine("[CodiceFiscaleEnteAppartenenza] VARCHAR(16),")
                sql.AppendLine("[DataInserimentoCliente]        DATE,")
                sql.AppendLine("[DataCessazioneCliente]         DATE,")
                sql.AppendLine("PRIMARY KEY(CodiceFiscale))")
                Aggiorna(sql.ToString)
            End If

            If Utx.FunzioniDb.EsisteCampo(agenzia.Connessione, "Clienti1", "FES") = False Then
                Dim sql As New Text.StringBuilder
                sql.AppendLine("ALTER TABLE Clienti1 ADD COLUMN FES VARCHAR(10)")
                Aggiorna(sql.ToString)
            End If

            If Utx.FunzioniDb.EsisteTabella(agenzia.Connessione, "MovimentiPrimaNota") = False Then
                Dim sql As New Text.StringBuilder
                sql.AppendLine("CREATE TABLE MovimentiPrimaNota (")
                sql.AppendLine("[ProgressivoFile]               INTEGER,")
                sql.AppendLine("[DataElaborazione]              DATE,")
                sql.AppendLine("[CodicePuntoVendita]            CHAR(5),")
                sql.AppendLine("[Progressivo]                   CHAR(2),")
                sql.AppendLine("[TipoElaborazione]              CHAR(2),")
                sql.AppendLine("[CodiceMovimento]	            CHAR(3),")
                sql.AppendLine("[CodiceTipoMovimento]	        CHAR(3),")
                sql.AppendLine("[Descrizione]		            VARCHAR(40),")
                sql.AppendLine("[Categoria]		                INTEGER,")
                sql.AppendLine("[Ramo]			                SMALLINT,")
                sql.AppendLine("[Polizza]		                INTEGER,")
                sql.AppendLine("[DataEffettoTitolo]	            DATE,")
                sql.AppendLine("[Contraente]		            VARCHAR(25),")
                sql.AppendLine("[CodiceSegno]		            CHAR(1),")
                sql.AppendLine("[ImportoCassa]		            CURRENCY,")
                sql.AppendLine("[ImportoBanca]		            CURRENCY,")
                sql.AppendLine("[CodiceBanca]		            CHAR(05),")
                sql.AppendLine("[ProgressivoBonifico]	        INTEGER,")
                sql.AppendLine("[ImportoAltro]		            CURRENCY,")
                sql.AppendLine("[CodicePagamento]	            CHAR(01),")
                sql.AppendLine("[CodiceSubagente]	            CHAR(05),")
                sql.AppendLine("[CodiceConvenzione]	            CHAR(05),")
                sql.AppendLine("[DataRegistrazione]	            DATE,")
                sql.AppendLine("[TimestampInserimento]	        CHAR(26),")
                sql.AppendLine("[MovimentoConfermato]	        CHAR(01),")
                sql.AppendLine("[DataQuadratura]	            DATE,")
                sql.AppendLine("[PuntoVendita]	                CHAR(05),")
                sql.AppendLine("[CodiceEsito]		            CHAR(2),")
                sql.AppendLine("PRIMARY KEY(TimestampInserimento))")
                Aggiorna(sql.ToString)
            End If

            If Utx.FunzioniDb.EsisteCampo(agenzia.Connessione, "MovimentiPrimaNota", "CodiceRUI") = False Then
                Dim sql As New Text.StringBuilder
                sql.AppendLine("ALTER TABLE MovimentiPrimaNota ADD COLUMN CodiceRUI VARCHAR(10)")
                Aggiorna(sql.ToString)
            End If

            If Utx.FunzioniDb.EsisteCampo(agenzia.Connessione, "Titoli", "FlagIncassoFEA") = False Then
                Dim sql As New Text.StringBuilder
                sql.AppendLine("ALTER TABLE Titoli ADD COLUMN ")
                sql.AppendLine("PuntoVendita                CHAR(05),")
                sql.AppendLine("IndicatoreRataIntermedia    CHAR(01),")
                sql.AppendLine("ScadenzaPolizza             DATE,")
                sql.AppendLine("ScadenzaVincolo             DATE,")
                sql.AppendLine("TargaVeicolo                VARCHAR(20),")
                sql.AppendLine("TipoUnibox                  CHAR(01),")
                sql.AppendLine("OraEsito                    CHAR(08),")
                sql.AppendLine("OraCopertura                CHAR(08),")
                sql.AppendLine("PremioRc                    CURRENCY,")
                sql.AppendLine("ProvvigioniRc               CURRENCY,")
                sql.AppendLine("PremioIncendioFurto         CURRENCY,")
                sql.AppendLine("ProvvigioniIncendioFurto    CURRENCY,")
                sql.AppendLine("PremioInfortuni             CURRENCY,")
                sql.AppendLine("ProvvigioniInfortuni        CURRENCY,")
                sql.AppendLine("PremioKasko                 CURRENCY,")
                sql.AppendLine("ProvvigioniKasko            CURRENCY,")
                sql.AppendLine("PremioAssistenza1           CURRENCY,")
                sql.AppendLine("ProvvigioniAssistenza1      CURRENCY,")
                sql.AppendLine("IncrementoProduzione        CURRENCY,")
                sql.AppendLine("Rendita                     CURRENCY,")
                sql.AppendLine("ProdottoVita                VARCHAR(12),")
                sql.AppendLine("DataRegolazionePremio       DATE,")
                sql.AppendLine("Cin                         CHAR(01),")
                sql.AppendLine("Abi                         CHAR(05),")
                sql.AppendLine("Cab                         CHAR(05),")
                sql.AppendLine("Conto                       CHAR(12),")
                sql.AppendLine("RamoGestione                SMALLINT,")
                sql.AppendLine("FlagProvvigioniNuovoMandato CHAR(01),")
                sql.AppendLine("FlagIncassoFEA              CHAR(01)")
                Aggiorna(sql.ToString)
            End If

            'Dim dt As DataTable = agenzia.Connessione.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Indexes, New Object() {Nothing, Nothing, "PERIMP", Nothing, "Sinistri"})
            'If dt.Rows.Count = 0 Then
            '    Utx.FunzioniDb.CreaIndice(agenzia.Connessione, "Sinistri", "PERIMP", {"EsercizioSinistro", "AgenziaSinistro", "RamoSinistro", "NumeroSinistro", "TipoCid", "TipoChiusura", "PrimoPreventivo", "ImportoQuotaPagatoDel", "ImportoQuotaPagatoAl", "ImportoQuotaRecuperatoDel"})
            'End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub ChiudiConnessione()
        Try
            If command IsNot Nothing Then
                If command.Connection IsNot Nothing Then
                    If command.Connection.State = ConnectionState.Open Then
                        command.Connection.Close()
                    End If
                    command.Connection = Nothing
                    Application.DoEvents()
                End If
            End If
        Catch ex As Exception
#If DEBUG Then
            Globale.Log.Errore(ex)
#Else
            Globale.Log.info(ex)
#End If
        End Try
    End Sub

    Public Shared Function ModelloDbUno() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaModelli, "DbUno.mdb")
    End Function

    Public Function SpostaDbUnoInCartellaLocale() As Boolean
        Globale.Log.Info("PROCEDURA SpostaDbUnoInCartellaLocale")
        IO.File.Copy(ModelloDbUno, agenzia.Cartelle.DatabaseDbUnoTemp, True)
        Application.DoEvents()
        Return True
    End Function

    Public Function InviaDbUno() As Boolean
        If IO.File.Exists(agenzia.Cartelle.DatabaseDbUnoTemp) = False Then
            Return False
        End If

        ChiudiConnessione()

        Utx.OmWeb.InviaFile(Me.agenzia.CodiceAgenziaFiglia,
                            agenzia.Cartelle.DatabaseDbUnoTemp,
                            Utx.ServiziOMW.TipoEvento.CONSOLIDA_MA.ToString, False)
        Return True
    End Function

    Public Function RipristinaDbUno() As Boolean
        If IO.File.Exists(agenzia.Cartelle.DatabaseDbUnoTemp) = False Then
            Return False
        End If

        ChiudiConnessione()

        'compatto il dbuno temp
        Utx.FunzioniDb.CompattaMdb(agenzia.Cartelle.DatabaseDbUnoTemp, False)
        'copio il db su M:
        Dim nomeCopia As String = agenzia.Cartelle.DatabaseDbUno & ".copy"
        If IO.File.Exists(nomeCopia) Then
            IO.File.Delete(nomeCopia)
        End If
        Application.DoEvents()

        IO.File.Copy(agenzia.Cartelle.DatabaseDbUnoTemp, nomeCopia, True)
        Application.DoEvents()

        Dim Timeout As Date = Now.AddSeconds(30)
        Do While Now < Timeout
            Try
                If IO.File.Exists(nomeCopia) And IO.File.Exists(agenzia.Cartelle.DatabaseDbUno) Then
                    IO.File.Delete(agenzia.Cartelle.DatabaseDbUno)
                End If
                FileSystem.Rename(nomeCopia, agenzia.Cartelle.DatabaseDbUno)
                Log.Info("dbUno copiato in M: correttamente")
                Application.DoEvents()
                Exit Do
            Catch ex As Exception
                'non facco niente e riprovo
                Log.Info("Tentativo di cancellazione dbuno fallito")
                Log.Info(ex.Message)
            End Try
            Application.DoEvents()
        Loop

        'IO.File.Delete(agenzia.Cartelle.DatabaseDbUnoTemp) 'non lo cancelliamo perché potrebbe servire
        'Application.DoEvents()
        Return True
    End Function

    Public Function Aggiorna(oTabella As Tabella) As Boolean
        Return Aggiorna(GetSql(oTabella))
    End Function

    Public Function Aggiorna(commandText As String) As Boolean
        Try
            HasErrors = False
            ErrorNumber = 0
            ErrorDescription = vbNullString

            If commandText Is Nothing Then
                Return True
            Else
                command.CommandText = commandText
                Return command.ExecuteNonQuery() >= 0
            End If
        Catch ex As Exception
            HasErrors = True
            ErrorNumber = 1
            ErrorDescription = ex.Message
            Globale.OmniaLog.Info(commandText)
        End Try
        Return False
    End Function

    Public Function GetSql(oTabella As Tabella) As String
        'contatore = contatore + 1
        'If contatore Mod 1000 = 0 Then
        'Globale.Log.Info(oTabella.Operazione & ": aggiornamento tabella " & oTabella.Nome & ": " & contatore)
        'End If

        Select Case oTabella.Operazione
            Case "A"    'AGGIORNAMENTO SE ESISTE, ALTRIMENTI INSERISCI NUOVO
                Return DeteteAndInsertSql(oTabella)
            Case "I"    'INSERIMENTO NUOVO
                Return InsertSql(oTabella)
            Case "E"    'INSERIMENTO SE NON ESISTE
                Return InsertIfNotExists(oTabella)
            Case "U"    'AGGIORNAMENTO SE ESISTE
                Return UpdateSql(oTabella)
            Case "D"    'DELETE
                Return DeleteSql(oTabella)
            Case "N"    'NOTHING - SALTA
                Return Nothing
            Case Else
                Throw New Exception("Tipo operazione '" & oTabella.Operazione & "' Non previsto")
        End Select
    End Function

    Public Function InsertSql(oTabella As Tabella) As String
        Dim sCampi As String = ""
        Dim sValori As String = ""

#If DEBUG Then
        If oTabella.Nome = "Titoli" Then
            'MsgBox(oTabella.Nome)
        End If
#End If
        ValorizzaPrgCampo(oTabella)

        For Each oCampo In oTabella.Campi.Values
            If oCampo.CampoOk Then
                'If oCampo.CampoChiave Then
                '    If sCampi <> vbNullString Then
                '        sCampi = sCampi & ","
                '        sValori = sValori & ","
                '    End If

                '    sCampi = sCampi & oCampo.Nome
                '    sValori = sValori & oCampo.getValorePerInsert()
                'ElseIf Not oCampo.ValoreIsNull Then
                '    If sCampi <> vbNullString Then
                '        sCampi = sCampi & ", "
                '        sValori = sValori & ", "
                '    End If

                '    sCampi = sCampi & oCampo.Nome
                '    sValori = sValori & oCampo.getValorePerInsert()
                'End If

                If sCampi <> vbNullString Then
                    'aggiungo le virgole
                    sCampi &= ", "
                    sValori &= ", "
                End If

                sCampi &= oCampo.Nome
                sValori &= oCampo.getValorePerInsert()
            End If
        Next

        If sCampi = vbNullString Then
            Throw New Exception("errore in InsertSql(): nessun campo definito in specifica per " & oTabella.Nome)
        End If

        Return String.Format("INSERT INTO {0} ({1}) VALUES ({2})", oTabella.Nome, sCampi, sValori)
    End Function

    Public Function UpdateSql(oTabella As Tabella) As String
        Dim sCampiUpd As String = ""
        Dim sWherCnd As String = ""

        For Each oCampo In oTabella.Campi.Values
            If oCampo.CampoOk Then

                If oCampo.CampoChiave Or oCampo.Storicizzare Then
                    'If Not oCampo.ValoreIsNull Then
                    If sWherCnd = vbNullString Then
                        sWherCnd &= " WHERE "
                    Else
                        sWherCnd &= " AND "
                    End If
                    If oCampo.ValoreIsNull Then
                        sWherCnd &= oCampo.Nome & " IS " & oCampo.getValorePerInsert()
                    Else
                        sWherCnd &= oCampo.Nome & " = " & oCampo.getValorePerInsert()
                    End If
                    'End If

                Else 'If Not oCampo.ValoreIsNull Then

                    If sCampiUpd <> vbNullString Then
                        sCampiUpd &= ", "
                    End If

                    sCampiUpd = sCampiUpd & oCampo.Nome & " = " & oCampo.getValorePerInsert()
                End If
            End If
        Next

        If sCampiUpd = vbNullString Then
            Throw New Exception("errore in UpdateSql(): nessun campo definito in specifica")
        End If

        Return String.Format("UPDATE {0} SET {1} {2}", oTabella.Nome, sCampiUpd, sWherCnd)
    End Function

    Public Function DeleteSql(oTabella As Tabella) As String
        Dim sWherCnd As String = vbNullString

        For Each oCampo In oTabella.Campi.Values
            If oCampo.CampoOk Then
                If oCampo.CampoChiave Or oCampo.Storicizzare Then
                    'If Not oCampo.ValoreIsNull Then
                    If sWherCnd = vbNullString Then
                        sWherCnd &= " WHERE "
                    Else
                        sWherCnd &= " AND "
                    End If
                    If oCampo.ValoreIsNull Then
                        sWherCnd &= oCampo.Nome & " IS " & oCampo.getValorePerInsert()
                    Else
                        sWherCnd &= oCampo.Nome & " = " & oCampo.getValorePerInsert()
                    End If
                    'End If
                End If
            End If
        Next

        If sWherCnd = vbNullString Then
            Throw New Exception("errore in DeleteSql(): nessun campo definito in specifica")
        End If

        Return String.Format("DELETE FROM {0} {1}", oTabella.Nome, sWherCnd)
    End Function

    Public Function DeteteAndInsertSql(oTabella As Tabella) As String

        If oTabella.Campi.ContainsKey("DataElaborazione") Then
            Try
                ' controllo se record più aggiornato
                Dim sCampiUpd As String = vbNullString
                Dim sWherCnd As String = vbNullString
                Dim DataElaborazioneDb As Date = System.DateTime.MinValue
                Dim DataElaborazioneFl As Date = System.DateTime.MinValue

                For Each oCampo In oTabella.Campi.Values
                    If oCampo.CampoOk Then
                        If oCampo.CampoChiave Or oCampo.Storicizzare Then
                            If sWherCnd = vbNullString Then
                                sWherCnd &= " WHERE "
                            Else
                                sWherCnd &= " AND "
                            End If

                            If oCampo.ValoreIsNull And oCampo.Categoria <> Campo.CategoriaDatoEnum.CategoriaStringa Then
                                sWherCnd &= oCampo.Nome & " IS " & oCampo.getValorePerInsert()
                            Else
                                sWherCnd &= oCampo.Nome & " = " & oCampo.getValorePerInsert()
                            End If
                            'End If
                        End If
                    End If
                Next

                Try
                    command.CommandText = "SELECT MAX(DataElaborazione) FROM " & oTabella.Nome & sWherCnd
                    Dim reader = command.ExecuteReader()
                    If reader.Read Then
                        If Not reader.IsDBNull(0) Then
                            DataElaborazioneDb = reader.GetDateTime(0)
                        End If
                    End If
                    reader.Close()
                Catch ex As Exception
                End Try

                Date.TryParse(oTabella.Campi("DataElaborazione").Valore(), DataElaborazioneFl)
                If DataElaborazioneDb >= DataElaborazioneFl Then
                    Return Nothing
                ElseIf DataElaborazioneDb = System.DateTime.MinValue Then
                    Return InsertSql(oTabella)
                End If
            Catch ex As Exception
            End Try
        End If

        If Aggiorna(DeleteSql(oTabella)) Then
            Return InsertSql(oTabella)
        Else
            Return Nothing
        End If
    End Function

    Public Function UpdateOrInsertSql(oTabella As Tabella) As String
        Dim sCampiUpd As String = vbNullString
        Dim sWherCnd As String = vbNullString

        For Each oCampo In oTabella.Campi.Values
            If oCampo.CampoOk Then
                If oCampo.CampoChiave Or oCampo.Storicizzare Then
                    'If Not oCampo.ValoreIsNull Then
                    If sWherCnd = vbNullString Then
                        sWherCnd &= " WHERE "
                    Else
                        sWherCnd &= " AND "
                    End If
                    If oCampo.ValoreIsNull And oCampo.Categoria <> Campo.CategoriaDatoEnum.CategoriaStringa Then
                        sWherCnd &= oCampo.Nome & " IS " & oCampo.getValorePerInsert()
                    Else
                        sWherCnd &= oCampo.Nome & " = " & oCampo.getValorePerInsert()
                    End If
                    'End If
                End If
            End If
        Next

        command.CommandText = "SELECT COUNT(*) FROM " & oTabella.Nome & sWherCnd
        Dim righe As Integer = command.ExecuteScalar()


        If righe > 0 Then
            UpdateOrInsertSql = UpdateSql(oTabella)
        Else
            UpdateOrInsertSql = InsertSql(oTabella)
        End If
    End Function

    Public Function InsertIfNotExists(oTabella As Tabella) As String
        Dim sCampiUpd As String = vbNullString
        Dim sWherCnd As String = vbNullString

        For Each oCampo In oTabella.Campi.Values
            If oCampo.CampoOk Then
                If oCampo.CampoChiave Or oCampo.Storicizzare Then
                    'If Not oCampo.ValoreIsNull Then
                    If sWherCnd = vbNullString Then
                        sWherCnd &= " WHERE "
                    Else
                        sWherCnd &= " AND "
                    End If
                    If oCampo.ValoreIsNull Then
                        sWherCnd &= oCampo.Nome & " IS " & oCampo.getValorePerInsert()
                    Else
                        sWherCnd &= oCampo.Nome & " = " & oCampo.getValorePerInsert()
                    End If
                    'End If
                End If
            End If
        Next

        command.CommandText = "SELECT COUNT(*) FROM " & oTabella.Nome & sWherCnd
        Dim righe As Integer = command.ExecuteScalar()

        If righe = 0 Then
            Return InsertSql(oTabella)
        Else
            Return Nothing
        End If
    End Function


    Public Function TrovaChiaviInterne(oTracciato As Tracciato) As Boolean
        'in questa implementazione (database di primo livello) non si hanno chiavi interne
        Return True
        ''    '    Dim sSql As String
        ''    '    Dim oCampo As Campo
        ''    '    Dim iCampo As Campo

        ''    '    For Each oCampo In oTracciato.CampiChiavi.Values
        ''    '        Select Case oCampo.NomeChiave
        ''    '            Case "CodNDG"
        ''    '                oCampo.Campi("CodiceFiscale").TipoDato = 200
        ''    '                If Not oCampo.Campi("CodiceFiscale").ValoreIsNull Then
        ''    '                    sSql = "SELECT CodNDG FROM ANT001_SoggettoAnagrafico WHERE CodiceFiscale = " _
        ''    '                         & oCampo.Campi("CodiceFiscale").getValorePerInsert()
        ''    '                    With GetRecordset(sSql)
        ''    '                        If .EOF Then
        ''    '                            oCampo.Valore = GetNextValue("Select max(CodNdG) FROM ANT001_SoggettoAnagrafico")
        ''    '                        Else
        ''    '                            oCampo.Valore = .Fields("CodNdG")
        ''    '                        End If
        ''    '                    End With
        ''    '                Else
        ''    '                    oCampo.Valore = 0
        ''    '                End If

        ''    '                '*********************************************************************************
        ''    '            Case "CodCompagnia"
        ''    '                oCampo.Valore = 39
        ''    '            Case "CodPuntoVendita"
        ''    '                oCampo.Valore = 10334
        ''    '            Case "CodContrMatr"
        ''    '                oCampo.Valore = 0
        ''    '                Select Case oCampo.Campi("CodRamo").Valore
        ''    '                    Case "130", "131", "132"
        ''    '                        Dim nPolizza As Long
        ''    '                        nPolizza = oCampo.Campi("Polizza").Valore

        ''    '                        If oCampo.Campi("CodProdotto").Valore = "09012" Then
        ''    '                            nPolizza = nPolizza \ 10
        ''    '                        Else
        ''    '                            nPolizza = nPolizza \ 10000
        ''    '                        End If
        ''    '                        'oCampo.Campi("Polizza").valore = nPolizza
        ''    '                        oCampo.Valore = nPolizza
        ''    '                End Select

        ''    '                '        '*********************************************************************************
        ''    '                '        Case "CodFamiglia"
        ''    '                '            oCampo.Campi("CodiceFiscaleCF").TipoDato = 200
        ''    '                '
        ''    '                '            sSql = "SELECT CodFamiglia FROM  ANT001_SoggettoAnagrafico C INNER JOIN " & _
        ''    '                '                   "ANP005_Familiare F ON C.CodNDG = F.CodNDG WHERE CodiceFiscale = " _
        ''    '                '                 & oCampo.Campi("CodiceFiscaleCF").getValorePerInsert()
        ''    '                '
        ''    '                '            With GetRecordset(sSql)
        ''    '                '                If .EOF Then
        ''    '                '                    oCampo.valore = GetNextValue("Select max(CodFamiglia) FROM ANP004_Famiglia")
        ''    '                '                Else
        ''    '                '                    oCampo.valore = .Fields("CodFamiglia")
        ''    '                '                End If
        ''    '                '            End With
        ''    '                '
        ''    '                '        '*********************************************************************************
        ''    '                '        Case "CodGruppo"
        ''    '                '            oCampo.Campi("CodiceFiscaleEA").TipoDato = 200
        ''    '                '
        ''    '                '            sSql = "SELECT CodGruppo FROM  ANT001_SoggettoAnagrafico C INNER JOIN " & _
        ''    '                '                   "ANT009_DettaglioGruppo G ON C.CodNDG = G.CodNDG WHERE CodiceFiscale = " _
        ''    '                '                 & oCampo.Campi("CodiceFiscaleEA").getValorePerInsert()
        ''    '                '
        ''    '                '            With GetRecordset(sSql)
        ''    '                '                If .EOF Then
        ''    '                '                    oCampo.valore = GetNextValue("Select max(CodGruppo) FROM ANT008_GruppoCommerciale")
        ''    '                '                Else
        ''    '                '                    oCampo.valore = .Fields("CodGruppo")
        ''    '                '                End If
        ''    '                '            End With
        ''    '                '
        ''    '                '        '*********************************************************************************
        ''    '                '        Case "IDPolizza"
        ''    '                '            Dim nPolizza    As Long
        ''    '                '            Dim nPrgVeicolo As Long
        ''    '                '
        ''    '                '            oCampo.Campi("CodPuntoVendita").TipoDato = 3
        ''    '                '            oCampo.Campi("Ramo").TipoDato = 3
        ''    '                '            oCampo.Campi("Polizza").TipoDato = 3
        ''    '                '
        ''    '                '            nPolizza = oCampo.Campi("Polizza").valore
        ''    '                '
        ''    '                '            If oCampo.Campi.Exists("TipoRecord") Then
        ''    '                '                If oCampo.Campi("TipoRecord").valore <> "07" Then
        ''    '                '                    nPrgVeicolo = 1
        ''    '                '                ElseIf oCampo.Campi("CodProdotto").valore = "09012" Then
        ''    '                '                    nPrgVeicolo = nPolizza Mod 10
        ''    '                '                    nPolizza = nPolizza - nPrgVeicolo
        ''    '                '                Else
        ''    '                '                    nPrgVeicolo = nPolizza Mod 10000
        ''    '                '                    nPolizza = nPolizza - nPrgVeicolo
        ''    '                '                End If
        ''    '                '            End If
        ''    '                '
        ''    '                '            If oTracciato.Campi.Exists("PrgVeicolo") Then
        ''    '                '                oTracciato.Campi("PrgVeicolo").valore = nPrgVeicolo
        ''    '                '            End If
        ''    '                '
        ''    '                '            sSql = "SELECT IDPolizza FROM PTT001_Polizza" _
        ''    '                '                 & " WHERE CodPuntoVendita = " & oCampo.Campi("CodPuntoVendita").getValorePerInsert() _
        ''    '                '                 & "   AND CodRamoPolizza = " & oCampo.Campi("Ramo").getValorePerInsert() _
        ''    '                '                 & "   AND Polizza = " & nPolizza
        ''    '                '
        ''    '                '            With GetRecordset(sSql)
        ''    '                '                If .EOF Then
        ''    '                '                    oCampo.valore = GetNextValue("Select max(IDPolizza) FROM PTT001_Polizza")
        ''    '                '                Else
        ''    '                '                    oCampo.valore = .Fields("IDPolizza")
        ''    '                '                End If
        ''    '                '            End With
        ''    '                '
        ''    '                '        '*********************************************************************************
        ''    '            Case "DataEffettoPolizza"
        ''    '                oCampo.Campi("Polizza").TipoDato = 3
        ''    '                sSql = "SELECT max(DataEffettoPolizza) FROM PTT001_Polizza" _
        ''    '                     & " WHERE Polizza = " & oCampo.Campi("Polizza").getValorePerInsert()

        ''    '                With GetRecordset(sSql)
        ''    '                    If IsNull(.Fields(0)) Then
        ''    '                oCampo.valore = Date
        ''    '                    Else
        ''    '                        oCampo.Valore = .Fields(0)
        ''    '                    End If
        ''    '                End With

        ''    '                '*********************************************************************************
        ''    '            Case "IDSinistro"
        ''    '                oCampo.Campi("Esercizio").TipoDato = 3
        ''    '                oCampo.Campi("Numero").TipoDato = 3
        ''    '                sSql = "SELECT IDSinistro FROM SIN001_Sinistro" _
        ''    '                     & " WHERE EsercizioSinistro = " & oCampo.Campi("Esercizio").getValorePerInsert() _
        ''    '                     & "   AND NumeroSinistro    = " & oCampo.Campi("Numero").getValorePerInsert()
        ''    '                With GetRecordset(sSql)
        ''    '                    If .EOF Then
        ''    '                        oCampo.Valore = GetNextValue("Select max(IDSinistro) FROM SIN001_Sinistro")
        ''    '                    Else
        ''    '                        oCampo.Valore = .Fields("IDSinistro")
        ''    '                    End If
        ''    '                End With

        ''    '                '        '*********************************************************************************
        ''    '                '        Case "PrgVeicolo"
        ''    '                '            oCampo.Campi("TargaVeicolo").TipoDato = 200
        ''    '                '            sSql = "SELECT PrgVeicolo FROM  PTT011_Veicolo WHERE TargaVeicolo = " _
        ''    '                '                 & oCampo.Campi("TargaVeicolo").getValorePerInsert()
        ''    '                '            With GetRecordset(sSql)
        ''    '                '                If .EOF Then
        ''    '                '                    oCampo.valore = GetNextValue("Select max(PrgVeicolo) FROM PTT011_Veicolo")
        ''    '                '                Else
        ''    '                '                    oCampo.valore = .Fields("PrgVeicolo")
        ''    '                '                End If
        ''    '                '            End With

        ''    '        End Select

        ''    '    Next
    End Function


    Public Function ValorizzaPrgCampo(oTabella As Tabella) As Boolean
        Dim sWherCnd As String = ""
        Dim oCampo As Campo = Nothing
        Dim oPrgKey As Campo = Nothing


        For Each oCampo In oTabella.Campi.Values
            If oCampo.CampoOk Then
                If oCampo.CampoChiave Then
                    If oCampo.Categoria = Campo.CategoriaDatoEnum.CategoriaNumerico Then
                        If LCase(Left(oCampo.Nome, 3)) = "prg" Then
                            oPrgKey = oCampo
                            Exit For
                        ElseIf LCase(Left(oCampo.Nome, 4)) = "prog" Then
                            oPrgKey = oCampo
                            Exit For
                        End If
                    End If
                End If
            End If
        Next

        If Not oPrgKey Is Nothing Then
            If oPrgKey.ValoreIsNull Then

                For Each oCampo In oTabella.Campi.Values
                    If oCampo.CampoOk Then
                        If oCampo.CampoChiave Then
                            If oCampo.Nome <> oPrgKey.Nome Then
                                If sWherCnd <> vbNullString Then
                                    sWherCnd = sWherCnd & " AND "
                                Else
                                    sWherCnd = " WHERE "
                                End If

                                sWherCnd = sWherCnd & oCampo.Nome & " = " & oCampo.getValorePerInsert()
                            End If
                        End If
                    End If
                Next

                'oPrgKey.Valore = GetNextValue("SELECT 1 + MAX(" & oPrgKey.Nome & ") FROM " & oTabella.Nome & sWherCnd)
                Throw New Exception("implementare Database.GetNextValue()")
                ValorizzaPrgCampo = True
            End If
        End If
        Return ValorizzaPrgCampo
    End Function


    Private Sub EseguiBackup()
        Globale.Log.Info("PROCEDURA ESEGUI BACKUP")
        Try
            Dim nomeCopia As String = agenzia.Cartelle.DatabaseDbUno & ".copy"
            If IO.File.Exists(nomeCopia) And IO.File.Exists(agenzia.Cartelle.DatabaseDbUno) Then
                Globale.Log.Info(String.Format("Esistono i file {0} E {1}", nomeCopia, agenzia.Cartelle.DatabaseDbUno))

                Globale.Log.Info(String.Format("Elimino {0}", agenzia.Cartelle.DatabaseDbUno))
                IO.File.Delete(agenzia.Cartelle.DatabaseDbUno)
                Application.DoEvents()
                Globale.Log.Info(String.Format("Eliminazione OK"))

                Globale.Log.Info(String.Format("Rinomino {0} in {1}", nomeCopia, agenzia.Cartelle.DatabaseDbUno))
                FileSystem.Rename(nomeCopia, agenzia.Cartelle.DatabaseDbUno)
                Application.DoEvents()
                Globale.Log.Info(String.Format("Rinomino OK"))
            End If

            'verifico se la connessione il database è ok
            Dim dbOk As Boolean = False

            Try
                Globale.Log.Info(String.Format("Apro connessione di {0}", agenzia.ConnectionStringDbUno))
                Using c As New OleDbConnection(agenzia.ConnectionStringDbUno)
                    c.Open()
                    Using cmd As New OleDbCommand("SELECT count(*) FROM ARP002_File", c)
                        cmd.ExecuteScalar()
                        dbOk = True
                    End Using
                    c.Close()
                End Using
                Globale.Log.Info(String.Format("Esecuzione SELECT count(*) FROM ARP002_File OK"))
            Catch ex As Exception
                Globale.Log.Errore(ex.Message, False)
            End Try

            Dim filenameMdb As String = agenzia.Cartelle.DatabaseDbUno
            Dim filenameZip As String = filenameMdb & "." & Format(Today, "ddd") & ".zip"
            Dim filenameBak As String = filenameMdb & "." & Format(Today, "ddd") & ".bak"

            If dbOk = False Then
                Globale.Log.Info(String.Format("Esecuzione SELECT count(*) FROM ARP002_File KO"))
                ' recupero l'ultimo database
                Dim di As New IO.DirectoryInfo(IO.Path.GetDirectoryName(filenameMdb))
                Dim lastfilenameBak As IO.FileSystemInfo = Nothing
                For Each File In di.GetFileSystemInfos()
                    If File.Extension = ".bak" Then
                        If lastfilenameBak Is Nothing Then
                            lastfilenameBak = File
                        ElseIf lastfilenameBak.LastWriteTime.Ticks < File.LastWriteTime.Ticks Then
                            lastfilenameBak = File
                        End If
                    End If
                Next
                Globale.Log.Info(String.Format("recupero l'ultimo database {0}", lastfilenameBak))


                If IO.File.Exists(filenameMdb) Then
                    Globale.Log.Info(String.Format("elimino il database {0}", filenameMdb))
                    IO.File.Delete(filenameMdb)
                    Application.DoEvents()
                End If
                If lastfilenameBak IsNot Nothing Then
                    Globale.Log.Info(String.Format("decomprimo il file {0} in {1}", lastfilenameBak.FullName, IO.Path.GetDirectoryName(filenameMdb)))
                    Utx.LibreriaZip.SevenZip.UnzipFile(lastfilenameBak.FullName, IO.Path.GetDirectoryName(filenameMdb))
                    Application.DoEvents()
                End If
            Else
                Globale.Log.Info(String.Format("CREAZIONE DEL FILE BACKUP"))
                If IO.File.Exists(filenameZip) Then
                    Globale.Log.Info(String.Format("Elimino il file {0} (perchè presente)", filenameZip))
                    IO.File.Delete(filenameZip)
                End If

                Globale.Log.Info(String.Format("Comprimo il file {0} in {1}", filenameMdb, filenameZip))
                Utx.LibreriaZip.SevenZip.ZipFile(filenameMdb, filenameZip)
                Application.DoEvents()

                If IO.File.Exists(filenameZip) Then
                    If IO.File.Exists(filenameBak) Then
                        Globale.Log.Info(String.Format("Elimino il file {0} (perchè presente)", filenameBak))
                        IO.File.Delete(filenameBak)
                    End If

                    Application.DoEvents()

                    Globale.Log.Info(String.Format("sposto il file {0} in {1}", filenameZip, filenameBak))
                    IO.File.Move(filenameZip, filenameBak)

                    Application.DoEvents()

                    If IO.File.Exists(filenameZip) Then
                        Globale.Log.Info(String.Format("Elimino il file {0}", filenameZip))
                        IO.File.Delete(filenameZip)
                    End If
                End If
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex, False)
        End Try

    End Sub

    Private Function RecuperaUltimoDbUno() As Boolean
        Try
            ' recupero l'ultimo database
            Globale.Log.Info("recupero mdb da backup")
            Dim di As New IO.DirectoryInfo(IO.Path.GetDirectoryName(agenzia.Cartelle.DatabaseDbUno))
            Dim lastfilenameBak As IO.FileSystemInfo = Nothing
            For Each File In di.GetFileSystemInfos("DbUno.mdb.*.bak")
                If lastfilenameBak Is Nothing Then
                    lastfilenameBak = File
                ElseIf lastfilenameBak.LastWriteTime.Ticks < File.LastWriteTime.Ticks Then
                    lastfilenameBak = File
                End If
            Next

            If lastfilenameBak IsNot Nothing Then
                Try
                    Globale.Log.Info("trovato il db {0}", {lastfilenameBak.FullName})
                    Using c As New OleDbConnection(Utx.Globale.MDBDriver + lastfilenameBak.FullName)
                        c.Open()
                    End Using
                    Globale.Log.Info(String.Format("recupero l'ultimo database funzionante {0}", lastfilenameBak))
                    IO.File.Copy(lastfilenameBak.FullName, agenzia.Cartelle.DatabaseDbUno, True)
                    Application.DoEvents()
                    Return True
                Catch ex As Exception
                    'il file recuperato è corrotto, lo cancello e riprovo
                    Globale.Log.Info("file di backup è corrotto e viene cancellato")
                    lastfilenameBak.Delete()
                    Return RecuperaUltimoDbUno()
                End Try
            Else
                Globale.Log.Info(String.Format("impossibile recuperare l'ultimo database"))
                Return False
            End If
        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            Return False
        End Try
    End Function

    Private Sub EseguiBackup2()
        Globale.Log.Info("PROCEDURA ESEGUI BACKUP 2")
        Try

            'verifico se la connessione il database è ok
            Dim dbOk As Boolean = False

            Try
                Globale.Log.Info(String.Format("Apro connessione di {0}", agenzia.ConnectionStringDbUno))
                Using c As New OleDbConnection(agenzia.ConnectionStringDbUno)
                    c.Open()
                    Using cmd As New OleDbCommand("SELECT count(*) FROM ARP002_File", c)
                        cmd.ExecuteScalar()
                        dbOk = True
                    End Using
                    c.Close()
                End Using
                Globale.Log.Info(String.Format("Esecuzione SELECT count(*) FROM ARP002_File OK"))
            Catch ex As Exception
                Globale.Log.Errore(ex.Message, False)
            End Try

            'Dim filenameMdb As String = agenzia.Cartelle.DatabaseDbUno

            If dbOk = False Then
                RecuperaUltimoDbUno()
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex, False)
        End Try

    End Sub
    Protected Overrides Sub Finalize()
        ChiudiConnessione()
    End Sub

End Class
