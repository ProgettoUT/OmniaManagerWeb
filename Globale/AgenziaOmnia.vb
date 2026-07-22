Imports System.IO

Public Class AgenziaOmnia

    Public Event Errore(Modulo As String, Metodo As String, ByRef ex As Exception)

    Sub New()
        '''''''''''''''''''''''''''''''
        'AD USO TEST
        '''''''''''''''''''''''''''''''
        mCompagnia = Utx.Globale.ProfiloEnteGestore.Compagnia
        mAgenziaMadre = Utx.Globale.ProfiloEnteGestore.AgenziaMadre
        mCodiceSede = Utx.Globale.ProfiloEnteGestore.CodiceSede
    End Sub

    Sub New(Compagnia As String, AgenziaMadre As String, CodiceSede As String)
        mCompagnia = Compagnia
        mAgenziaMadre = AgenziaMadre
        mCodiceSede = CodiceSede
    End Sub

    Private mCompagnia As String
    Public ReadOnly Property Compagnia() As String
        Get
            Return mCompagnia
        End Get
    End Property

    Private mAgenziaMadre As String
    Public ReadOnly Property AgenziaMadre() As String
        Get
            Return mAgenziaMadre
        End Get
    End Property

    Private mCodiceSede As String
    Public ReadOnly Property CodiceSede() As String
        Get
            Return mCodiceSede
        End Get
    End Property

    Public Function AgenzieCollegate() As List(Of String)
        Dim ListaCollegate As New List(Of String)
        Try
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Dim Agenzie As String = s.AgenzieCollegate(mCompagnia, mAgenziaMadre, mCodiceSede)

                For Each a As String In Agenzie.Split("/")
                    ListaCollegate.Add(a)
                Next
            End Using

        Catch ex As Exception
            RaiseEvent Errore(Me.ToString, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            ListaCollegate.Clear()
#If DEBUG Then
            ListaCollegate.Add(mAgenziaMadre)
#End If
        End Try
        Return ListaCollegate
    End Function

    'Public Shared Function ImportazioneInCorso(Tipo As GestioneFlag.TipoFlag, MassimaDurataInMinuti As Integer) As Boolean
    '    Return Utx.GestioneFlag.EsisteFlag(Tipo, MassimaDurataInMinuti)
    'End Function

    'Public Shared Sub IniziaImportazione(Tipo As GestioneFlag.TipoFlag)
    '    Utx.GestioneFlag.CreaFlag(Tipo)
    'End Sub

    'Public Shared Sub FineImportazione(Tipo As GestioneFlag.TipoFlag)
    '    Utx.GestioneFlag.CancellaFlag(Tipo)
    'End Sub
End Class

Public Class AgenziaFigliaOmnia
    Public Event Errore(Modulo As String, Metodo As String, ByRef ex As Exception)

    Private WithEvents RigaConfig As RecordConfigOmnia

    Sub New(CodiceAgenziaFiglia As String)

        mCodiceAgenziaFiglia = CodiceAgenziaFiglia
        mSedeAgenziaFiglia = "00"
        mCartelle = New CartelleAgenziaOmnia(mCodiceAgenziaFiglia)
        mConsensoImportazione = True
        mConfig = New List(Of RecordConfigOmnia) From {New RecordConfigOmnia(CodiceAgenziaFiglia)}
    End Sub

    Sub New(CodiceAgenziaFiglia As String,
            SedeAgenziaFiglia As String,
            Optional LeggiConfig As Boolean = True)

        mCodiceAgenziaFiglia = CodiceAgenziaFiglia
        mSedeAgenziaFiglia = SedeAgenziaFiglia

        mCartelle = New CartelleAgenziaOmnia(mCodiceAgenziaFiglia)
        If LeggiConfig = True Then LeggiConfigFiglia()
    End Sub

    Private mCodiceAgenziaFiglia As String
    Public ReadOnly Property CodiceAgenziaFiglia() As String
        Get
            Return mCodiceAgenziaFiglia
        End Get
    End Property

    Private mSedeAgenziaFiglia As String
    Public ReadOnly Property SedeAgenziaFiglia() As String
        Get
            Return mSedeAgenziaFiglia
        End Get
    End Property

    Public ReadOnly Property SedePrincipale() As Boolean
        Get
            Return (mSedeAgenziaFiglia = "00")
        End Get
    End Property

    Public ReadOnly Property ConnectionStringDbUno() As String
        Get
            Return Utx.Globale.MDBDriver + Me.Cartelle.DatabaseDbUno
        End Get
    End Property

    Public ReadOnly Property ConnectionStringDbUnoTemp() As String
        Get
            Return Utx.Globale.MDBDriver + Me.Cartelle.DatabaseDbUnoTemp
        End Get
    End Property

    Public ReadOnly Property ConnectionStringArrivi() As String
        Get
            Return Utx.Globale.MDBDriver + Me.Cartelle.DatabaseArrivi
        End Get
    End Property

    Public ReadOnly Property ConnectionStringArriviRete() As String
        Get
            Return Utx.Globale.MDBDriver + Me.Cartelle.DatabaseArriviRete
        End Get
    End Property

    Public ReadOnly Property ConnectionStringDbInfo() As String
        Get
            Return Utx.Globale.MDBDriver + Path.Combine(Me.Cartelle.CartellaDati, "Info.mdb")
        End Get
    End Property

    Private mConnessione As OleDb.OleDbConnection
    Public Property Connessione() As OleDb.OleDbConnection
        Get
            Return mConnessione
        End Get
        Set(value As OleDb.OleDbConnection)
            mConnessione = value
        End Set
    End Property

    Private mCartelle As CartelleAgenziaOmnia
    Public ReadOnly Property Cartelle() As CartelleAgenziaOmnia
        Get
            Return mCartelle
        End Get
    End Property

    Private mConsensoImportazione As Boolean
    Public ReadOnly Property ConsensoImportazione() As Boolean
        Get
            Return mConsensoImportazione
        End Get
    End Property

    Private mConfig As List(Of RecordConfigOmnia)
    Public ReadOnly Property Config() As List(Of RecordConfigOmnia)
        Get
            Return mConfig
        End Get
    End Property

    Private mConfigUnicont As AgenziaUnicont
    Public ReadOnly Property ConfigUnicont() As AgenziaUnicont
        Get
            Return mConfigUnicont
        End Get
    End Property

    Private mConfigSedeSecondaria As RecordConfigSedeSecondaria
    Public ReadOnly Property ConfigSedeSecondaria() As RecordConfigSedeSecondaria
        Get
            Return mConfigSedeSecondaria
        End Get
    End Property

    Private mSoloScaricoFile As Boolean
    Public ReadOnly Property SoloScaricoFile() As Boolean
        Get
            Return False 'pc alla Luisa! (non serve più)
            'Return (File.Exists(Path.Combine(mCartelle.ArchivioDati, "Archivio.OK")) = False)
        End Get
    End Property

    Private mTabellaListe As DataTable
    Public ReadOnly Property TabellaListe() As DataTable
        Get
            Return mTabellaListe
        End Get
    End Property

    Private mTabellaForzature As DataTable
    Public ReadOnly Property TabellaForzature() As DataTable
        Get
            Return mTabellaForzature
        End Get
    End Property

    Private Function CodiceControllo() As Integer
        'per non bloccare: da definire successivamente
        Return 20200113 '13/1/2020
    End Function

    Public Sub ScriviFlagStoricoArchivi()
        File.CreateText(File.Exists(Path.Combine(mCartelle.CartellaDati, "Archivi.OK")))
    End Sub

    Private Sub LeggiConfigFiglia()
        Dim ds As DataSet
        Dim ErroreConfig As String = ""
        Dim ErroreForzature As String = ""
        Dim ErroreListe As String = ""

        Try
            'leggo config web e viene restituito un dataset con 4 tabelle
            'Config,Forzature,Liste,Contabilita,AbilitazioniSede
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                's.Url = "http://www.utools.it/asp/SettingAgenzia/SettingAgenzia.asmx"
                s.Timeout = 60000
                s.Proxy = Utx.Globale.UniProxy.Proxy

                ds = s.CodiciDownloadEx(Utx.Globale.ProfiloEnteGestore.Compagnia,
                                        mCodiceAgenziaFiglia,
                                        mSedeAgenziaFiglia,
                                        Me.CodiceControllo,
                                        mConsensoImportazione,
                                        ErroreConfig,
                                        ErroreForzature,
                                        ErroreListe)
            End Using

            'controllo errori server
            If ErroreConfig <> "+OK" OrElse ErroreForzature <> "+OK" OrElse ErroreListe <> "+OK" Then
                Throw New Exception(String.Format("Errore server: {1}{0}{2}{0}{3}{0}",
                                                  Environment.NewLine,
                                                  ErroreConfig,
                                                  ErroreForzature,
                                                  ErroreListe))
            End If

            'scrivo il log
            ScriviLogConfig(ds.Tables("Config"), ds.Tables("AbilitazioniSede"))

            If mConsensoImportazione = True Then
                'config
                mConfig = New List(Of RecordConfigOmnia)
                For Each row As DataRow In ds.Tables("Config").Rows
                    RigaConfig = New RecordConfigOmnia(row)
                    mConfig.Add(RigaConfig)
                Next
                'config contabilità
                mConfigUnicont = New AgenziaUnicont(ds.Tables("Contabilita"))
                'config sede secondaria
                mConfigSedeSecondaria = New RecordConfigSedeSecondaria(ds.Tables("AbilitazioniSede"))
                'liste
                mTabellaListe = ds.Tables("Liste")
                'forzature
                mTabellaForzature = ds.Tables("Forzature")
            End If

        Catch ex As Exception
            RaiseEvent Errore(Me.ToString, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
        End Try
    End Sub

    Private Sub ScriviLogConfig(ByRef dtConfig As DataTable, dtSede As DataTable)
        Try
            Globale.Log.Info(String.Format("Trovati {0} record di configurazione", dtConfig.Rows.Count))

            For Each dr As DataRow In dtConfig.Rows

                Globale.Log.Info(StrDup(40, "-"))

                For k As Integer = 0 To dtConfig.Columns.Count - 1
                    Globale.Log.Info(String.Format("{0}: {1}", dtConfig.Columns(k).ColumnName, dr(k)))
                Next
            Next

            Globale.Log.Info()

            'abilitazioni della sede
            Globale.Log.Info("Abilitazioni della sede:")

            For Each dr As DataRow In dtSede.Rows
                For k As Integer = 0 To dtSede.Columns.Count - 1
                    Globale.Log.Info(String.Format("{0}: {1}", dtSede.Columns(k).ColumnName, dr(k)))
                Next
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Globale.Log.Info()
        End Try
    End Sub

#If DEBUG Then
    Private Function ConfiguraSessioneDebug(Compagnia As Integer,
                                            CodiceAgenzia As String,
                                            DataInizio As Date,
                                            ByRef ConsensoImportazione As Boolean,
                                            ByRef ErroreConfig As String,
                                            ByRef ErroreForzature As String,
                                            ByRef ErroreListe As String) As DataSet

        Dim dsConfig As New DataSet
        Try
            'dataset config agenzia
            dsConfig.Tables.Add("Config")

            'creo la tabella con i campi che mi servono
            With dsConfig.Tables("Config").Columns
                .Add("Compagnia", Type.GetType("System.Int32"))
                .Add("Agenzia", Type.GetType("System.String"))
                .Add("AgenziaPrevalente", Type.GetType("System.String"))
                .Add("Sede", Type.GetType("System.String"))
                .Add("Desk", Type.GetType("System.String"))
                .Add("Collegata", Type.GetType("System.String"))
                .Add("CodiciSub", Type.GetType("System.String"))
                .Add("CodiciProd", Type.GetType("System.String"))
                .Add("DataInizio", Type.GetType("System.DateTime"))
                .Add("DataFine", Type.GetType("System.DateTime"))
                .Add("Provvigioni", Type.GetType("System.String"))
                .Add("DatiAggregati", Type.GetType("System.String"))
                .Add("Avvisi", Type.GetType("System.String"))
                .Add("ClientiPolizze", Type.GetType("System.String"))
                .Add("Incassi", Type.GetType("System.String"))
                .Add("Sinistri", Type.GetType("System.String"))
            End With

            'cosa scaricare
            Dim Provvigioni As String = "S"
            Dim DatiAggregati As String = "N"
            Dim Avvisi As String = "S"
            Dim ClientiPolizze As String = "S"
            Dim Incassi As String = "S"
            Dim Sinistri As String = "S"

            Dim rowArray() As Object

            Select Case 1
                Case 1 'agenzie private
                    rowArray = {Compagnia, CodiceAgenzia, False, "00", "", CodiceAgenzia, "", "",
                                DataInizio, #12/31/2100#, Provvigioni, DatiAggregati, Avvisi, ClientiPolizze, Incassi, Sinistri}

                Case Else 'assicoop
                    rowArray = {Compagnia, "02466", True, "00", "", "02465", "", "",
                                DataInizio, #12/31/2100#, Provvigioni, DatiAggregati, Avvisi, ClientiPolizze, Incassi, Sinistri}
            End Select

            dsConfig.Tables("Config").Rows.Add(rowArray)

            'tabella delle forzature
            dsConfig.Tables.Add("Forzature")

            With dsConfig.Tables("Forzature").Columns
                .Add("TipoFile", Type.GetType("System.String"))
                .Add("NomeFile", Type.GetType("System.String"))
                .Add("DataInizio", Type.GetType("System.DateTime"))
                .Add("TipoDoc", Type.GetType("System.String"))
                .Add("AnnoCompetenza", Type.GetType("System.Int32"))
                .Add("SalvaIn", Type.GetType("System.String"))
            End With

            With dsConfig.Tables("Forzature").Rows
                .Add({"05", String.Format("{0}_SINISTRI_31_DICEMBRE_2014.EXE", CodiceAgenzia), #8/4/2015#, "D", 2015})
            End With

            'tabella delle liste
            dsConfig.Tables.Add("Liste")

            With dsConfig.Tables("Liste").Columns
                .Add("TipoDoc", Type.GetType("System.Int32"))
                .Add("CodiceDoc", Type.GetType("System.Int32"))
                .Add("NomeBase", Type.GetType("System.String"))
                .Add("Desk", Type.GetType("System.String"))
                .Add("FormatoData", Type.GetType("System.String"))
                .Add("GiorniPeriodo", Type.GetType("System.Int32"))
                .Add("CartellaBase", Type.GetType("System.String"))
            End With

            'qt
            With dsConfig.Tables("Liste").Rows
                '.Add({0, 0, "_RCA_POLSOSP_DEL_", "", "MMyyyy", 30, "Documenti_Unipol\Liste_Quietanzamento"})
                '.Add({0, 1, "_RCA_POLCFIS_VUOTI_DEL_", "", "MMyyyy", 30, "Documenti_Unipol\Liste_Quietanzamento"})
                '.Add({0, 2, "_RE_POLNOQT_DEL_", "", "MMyyyy", 30, "Documenti_Unipol\Liste_Quietanzamento"})
                '.Add({0, 3, "_RE_REGPR_DEL_MESE_", "", "MMyyyy", 30, "Documenti_Unipol\Liste_Quietanzamento"})
                '.Add({0, 4, "_SINI_RECUP_FRANC_DEL_", "", "MMyyyy", 30, "Documenti_Unipol\Liste_Quietanzamento"})
                '.Add({0, 5, "_RE_REGPR_NO_LISTA_RE_DEL_", "", "MMyyyy", 30, "Documenti_Unipol\Liste_Quietanzamento"})
                '.Add({0, 6, "_RCA_BLOC_NON_ADEG_DEL_", "", "MMyyyy", 30, "Documenti_Unipol\Liste_Quietanzamento"})
                '.Add({0, 7, "_RCA_RE_POLCOAS_DEL_", "", "MMyyyy", 30, "Documenti_Unipol\Liste_Quietanzamento"})
                '.Add({0, 8, "_RCA_POLVINC_RE_RCA_DEL_", "", "MMyyyy", 30, "Documenti_Unipol\Liste_Quietanzamento"})
                '.Add({0, 9, "_RE_POL_RISC_EST_DEL_", "", "MMyyyy", 30, "Documenti_Unipol\Liste_Quietanzamento"})

                '.Add({2, 0, "_ELENCO_FLEX_AL", "", "yyyyMMdd", 15, "Documenti_Unipol\Liste_Quietanzamento"})
                '.Add({2, 1, "_ELENCO_FLEX_11RRIFPROD_AL", "", "yyyyMMdd", 15, "Documenti_Unipol\Liste_Quietanzamento"})

                'buste
                .Add({3, 1, "_RCA_SINGOLE_DECADE_D", "", "MM-yyyy", 10, "Documenti_Unipol\Buste"})
                .Add({3, 2, "_RCA_CUMULATIVE_DECADE_D", "", "MM-yyyy", 10, "Documenti_Unipol\Buste"})
                .Add({3, 3, "_RAMI_ELEMENTARI_DECADE_D", "", "MM-yyyy", 10, "Documenti_Unipol\Buste"})
                .Add({3, 4, "_CAUZIONI_DECADE_D", "", "MM-yyyy", 10, "Documenti_Unipol\Buste"})
                .Add({3, 5, "_RIASSICURAZIONE_DECADE_D", "", "MM-yyyy", 10, "Documenti_Unipol\Buste"})
            End With

            'tabella abilitazioni sede
            dsConfig.Tables.Add("AbilitazioniSede")

            With dsConfig.Tables("AbilitazioniSede").Columns
                .Add("Compagnia", Type.GetType("System.Int32"))
                .Add("Agenzia", Type.GetType("System.String"))
                .Add("Sede", Type.GetType("System.String"))
                .Add("PattoUnipol", Type.GetType("System.String"))
                .Add("ListeQT", Type.GetType("System.String"))
                .Add("Archivio", Type.GetType("System.String"))
                .Add("Buste", Type.GetType("System.String"))
            End With

            dsConfig.Tables("AbilitazioniSede").Rows.Add({Compagnia, CodiceAgenzia, "00", "S", "S", "S", "S"})

            'contabilità
            'tabella abilitazioni sede
            dsConfig.Tables.Add("Contabilita")

            With dsConfig.Tables("Contabilita").Columns
                .Add("Agenzia", Type.GetType("System.String"))
                .Add("DataInizio", Type.GetType("System.DateTime"))
                .Add("DataFine", Type.GetType("System.DateTime"))
                .Add("Sede", Type.GetType("System.String"))
                .Add("Forzatura", Type.GetType("System.DateTime"))
            End With

            'dsConfig.Tables("Contabilita").Rows.Add({CodiceAgenzia, Now.Date, #12/31/2100#, "00", System.DBNull.Value})

            'segnalazione errori
            ConsensoImportazione = True
            ErroreConfig = "+OK"
            ErroreForzature = "+OK"
            ErroreListe = "+OK"

        Catch ex As Exception
            ConsensoImportazione = False
            ErroreConfig = "-ERR"
            ErroreForzature = "-ERR"
            ErroreListe = "-ERR"

            MsgBox(ex.Message)
        End Try
        Return dsConfig
    End Function
#End If

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Try
            If Connessione IsNot Nothing Then
                If Connessione.State <> ConnectionState.Closed Then
                    Connessione.Close()
                End If
                Connessione = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class

Public Class CartelleAgenziaOmnia
    Private Const CartellaOmnia As String = "OMNIA"
    Private Const CartellaDL As String = "DL"
    Private Const DepositoFile As String = "FileRicevuti"
    Private Const FileInviati As String = "FileInviati"
    Private Const FileEsportati As String = "FileEsportati"
    Private Const DbUno As String = "DbUno.mdb"
    Private Const DbArrivi As String = "Arrivi.mdb"

    Private mAgenzia As String

    Sub New(Agenzia As String)
        mAgenzia = Agenzia

        'controllo esistenza cartelle
        Directory.CreateDirectory(Me.ArchivioDati)
        Directory.CreateDirectory(Me.ArchivioDatiOmnia)
        Directory.CreateDirectory(Me.ArchivioFileOmnia)
        Directory.CreateDirectory(Me.ArchivioFileInviati)
        Directory.CreateDirectory(Me.ArchivioFileEsportati)
        Directory.CreateDirectory(Me.CartellaArriviLocale)
        Directory.CreateDirectory(Me.CartellaArriviRete)
        Directory.CreateDirectory(Me.CartellaArriviAgenziaRete)
        Directory.CreateDirectory(Me.CartellaArriviLocaleAgenzia)
        Directory.CreateDirectory(Me.CartellaArriviLocaleAgenziaOmnia)
        Directory.CreateDirectory(Me.CartellaArriviLocaleTempOmnia)
        Directory.CreateDirectory(Me.CartellaArriviLocaleTempDL)
        'esistenza di dbuno
        If File.Exists(Me.DatabaseDbUno) = False Then
            File.Copy(Path.Combine(Utx.Globale.Paths.CartellaModelli, DbUno), Me.DatabaseDbUno)
        End If
    End Sub

    Public ReadOnly Property CartellaDati() As String
        Get
            Return Path.Combine(Utx.Globale.Paths.CartellaDati, mAgenzia)
        End Get
    End Property

    Public ReadOnly Property ArchivioDati() As String
        Get
            Return Path.Combine(Utx.Globale.Paths.CartellaArchivioDati, mAgenzia)
        End Get
    End Property

    Public ReadOnly Property ArchivioDatiOmnia() As String
        Get
            Return Path.Combine(Me.ArchivioDati, CartellaOmnia)
        End Get
    End Property

    Public ReadOnly Property ArchivioFileOmnia() As String
        Get
            Return Path.Combine(Me.ArchivioDatiOmnia, DepositoFile)
        End Get
    End Property

    Public ReadOnly Property ArchivioFileInviati() As String
        Get
            Return Path.Combine(Me.ArchivioDatiOmnia, FileInviati)
        End Get
    End Property

    Public ReadOnly Property ArchivioFileEsportati() As String
        Get
            Return Path.Combine(Me.ArchivioDatiOmnia, FileEsportati)
        End Get
    End Property

    Public ReadOnly Property DatabaseDbUno() As String
        Get
            Return Path.Combine(Me.ArchivioDatiOmnia, DbUno)
        End Get
    End Property

    Public ReadOnly Property DatabaseDbUnoTemp() As String
        Get
            Return Path.Combine(Me.CartellaArriviLocaleAgenziaOmnia, DbUno)
        End Get
    End Property

    Public ReadOnly Property DatabaseArrivi() As String
        Get
            Return Path.Combine(Me.CartellaArriviLocaleAgenziaDL, DbArrivi)
        End Get
    End Property

    Public ReadOnly Property DatabaseArriviRete() As String
        Get
            Return Path.Combine(Me.CartellaArriviAgenziaRete, DbArrivi)
        End Get
    End Property

    Public ReadOnly Property CartellaArriviLocale() As String
        Get
            Return Path.Combine(Utx.Globale.Paths.CartellaApp, "Arrivi")
        End Get
    End Property

    Public ReadOnly Property CartellaArriviRete() As String
        Get
            Return Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, "Arrivi")
        End Get
    End Property

    Public ReadOnly Property CartellaArriviAgenziaRete() As String
        Get
            Return Path.Combine(Me.CartellaArriviRete, mAgenzia)
        End Get
    End Property

    Public ReadOnly Property CartellaArriviLocaleAgenzia() As String
        Get
            Return Path.Combine(Me.CartellaArriviLocale, mAgenzia)
        End Get
    End Property

    Public ReadOnly Property CartellaArriviLocaleAgenziaOmnia() As String
        Get
            Return Path.Combine(Me.CartellaArriviLocaleAgenzia, CartellaOmnia)
        End Get
    End Property

    Public ReadOnly Property CartellaArriviLocaleAgenziaDL() As String
        Get
            Return Path.Combine(Me.CartellaArriviLocaleAgenzia, CartellaDL)
        End Get
    End Property

    Public ReadOnly Property CartellaArriviLocaleTempOmnia() As String
        Get
            Return Path.Combine(Me.CartellaArriviLocaleAgenziaOmnia, "Temp")
        End Get
    End Property

    Public ReadOnly Property CartellaArriviLocaleTempDL() As String
        Get
            Return Path.Combine(Me.CartellaArriviLocaleAgenziaDL, "Temp")
        End Get
    End Property

    Public ReadOnly Property CartellaArriviDiscoK() As String
        Get
#If DEBUG Then
            Return Path.Combine(Utx.Globale.Paths.CartellaTempComune, "download")
#Else
            Return "K:\casella\download\"
#End If
        End Get
    End Property

    Public ReadOnly Property CartellaArriviDiscoKBackup() As String
        Get
            Return Path.Combine(CartellaArriviDiscoK, "backup")
        End Get
    End Property
End Class


Public Class CartelleArchivioDati

    Private Cartelle As CartelleAgenziaOmnia

    Sub New(Agenzia As String)
        Cartelle = New CartelleAgenziaOmnia(Agenzia)

#If DEBUG Then
        mArchiviazioneAbilitata = Directory.Exists(Cartelle.ArchivioDati)
#Else
        If Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP Then
            mArchiviazioneAbilitata = False
        Else
            mArchiviazioneAbilitata = Directory.Exists(Cartelle.ArchivioDati)
        End If
#End If
    End Sub

    Public ReadOnly Property Disponibile() As Boolean
        Get
            Return Directory.Exists(Cartelle.ArchivioDati)
        End Get
    End Property

    Private mArchiviazioneAbilitata As Boolean
    Public Property ArchiviazioneAbilitata() As Boolean
        Get
            Return mArchiviazioneAbilitata
        End Get
        Set(value As Boolean)
            mArchiviazioneAbilitata = value
        End Set
    End Property

    Public ReadOnly Property Incassi(Anno As Integer, Mese As Integer) As String
        Get
            Return String.Format("{0}\Incassi\{1:0000}\{2:00}", Cartelle.ArchivioDati, Anno, Mese)
        End Get
    End Property

    Public ReadOnly Property Sinistri(Anno As Integer) As String
        Get
            Return String.Format("{0}\Sinistri\{1:0000}", Cartelle.ArchivioDati, Anno)
        End Get
    End Property

    Public ReadOnly Property PrimaNota(Anno As Integer) As String
        Get
            Return String.Format("{0}\PrimaNota\{1:0000}", Cartelle.ArchivioDati, Anno)
        End Get
    End Property
End Class

Public Class RecordConfigOmnia

    Public Event Errore(Modulo As String, Metodo As String, ByRef ex As Exception)

    Sub New(Agenzia As String)
        mAgenziaFiglia = Agenzia
        mAgenziaPrevalente = Agenzia
        mAgenziaCollegata = Agenzia
        mCodiceSede = "00"
        mDataInizio = #1/1/2001#
        mDataFine = #12/31/2099#
        mProvvigioni = True
        mAvvisi = True
        mIncassi = True
        mClientiPolizze = True
        mSinistri = True
        mUnisalute = False

        'codici sub
        mListaSub = New List(Of Integer)
        'ListaSub.Add(410)

        'codici prod
        mListaProd = New List(Of Integer)
        'ListaSub.Add(Val(s))

        'le cartelle della collegata
        mCartelle = New CartelleAgenziaOmnia(mAgenziaCollegata)
    End Sub

    Sub New(ByRef Dati As DataRow)
        mAgenziaFiglia = Dati("Agenzia")
        mAgenziaPrevalente = Dati("AgenziaPrevalente")
        mAgenziaCollegata = Dati("Collegata")
        mCodiceSede = Dati("Sede")
        mDataInizio = Dati("DataInizio")
        mDataFine = Dati("DataFine")
        mProvvigioni = (Dati("Provvigioni") = "S")
        mAvvisi = (Dati("Avvisi") = "S")
        mIncassi = (Dati("Incassi") = "S")
        mClientiPolizze = (Dati("ClientiPolizze") = "S")
        mSinistri = (Dati("Sinistri") = "S")
        mUnisalute = (Dati("Unisalute") = "S")
        'codici sub
        mListaSub = New List(Of Integer)
        'se la stringa non è vuota
        If String.IsNullOrEmpty(Dati("CodiciSub")) = False Then
            For Each s As String In Dati("CodiciSub").ToString.Split("/")
                If IsNumeric(s) Then ListaSub.Add(Val(s))
            Next
        End If
        'codici prod
        mListaProd = New List(Of Integer)
        'se la stringa non è vuota
        If String.IsNullOrEmpty(Dati("CodiciProd")) = False Then
            For Each s As String In Dati("CodiciProd").ToString.Split("/")
                If IsNumeric(s) Then ListaSub.Add(Val(s))
            Next
        End If
        'le cartelle della collegata
        mCartelle = New CartelleAgenziaOmnia(mAgenziaCollegata)
    End Sub

    Private mAgenziaFiglia As String
    Public ReadOnly Property AgenziaFiglia() As String
        Get
            Return mAgenziaFiglia
        End Get
    End Property

    Private mAgenziaPrevalente As Boolean
    Public ReadOnly Property AgenziaPrevalente() As Boolean
        Get
            Return mAgenziaPrevalente
        End Get
    End Property

    Private mAgenziaCollegata As String
    Public ReadOnly Property AgenziaCollegata() As String
        Get
            Return mAgenziaCollegata
        End Get
    End Property

    Private mCodiceSede As String
    Public ReadOnly Property CodiceSede() As String
        Get
            Return mCodiceSede
        End Get
    End Property

    Private mListaSub As List(Of Integer)
    Public ReadOnly Property ListaSub() As List(Of Integer)
        Get
            Return mListaSub
        End Get
    End Property

    Private mListaProd As List(Of Integer)
    Public ReadOnly Property ListaProd() As List(Of Integer)
        Get
            Return mListaProd
        End Get
    End Property

    Private mDataInizio As Date
    Public ReadOnly Property DataInizio() As Date
        Get
            Return mDataInizio
        End Get
    End Property

    Private mDataFine As Date
    Public ReadOnly Property DataFine() As Date
        Get
            Return mDataFine
        End Get
    End Property

    Private mProvvigioni As Boolean
    Public ReadOnly Property Provvigioni() As Boolean
        Get
            Return mProvvigioni
        End Get
    End Property

    Private mAvvisi As Boolean
    Public ReadOnly Property Avvisi() As Boolean
        Get
            Return mAvvisi
        End Get
    End Property

    Private mIncassi As Boolean
    Public ReadOnly Property Incassi() As Boolean
        Get
            Return mIncassi
        End Get
    End Property

    Private mClientiPolizze As Boolean
    Public ReadOnly Property ClientiPolizze() As Boolean
        Get
            Return mClientiPolizze
        End Get
    End Property

    Private mSinistri As Boolean
    Public ReadOnly Property Sinistri() As Boolean
        Get
            Return mSinistri
        End Get
    End Property

    Private mUnisalute As Boolean
    Public ReadOnly Property Unisalute() As Boolean
        Get
            Return mUnisalute
        End Get
    End Property

    Private mCartelle As CartelleAgenziaOmnia
    Public ReadOnly Property Cartelle() As CartelleAgenziaOmnia
        Get
            Return mCartelle
        End Get
    End Property

    Private mSoloScaricoFile As Boolean
    Public ReadOnly Property SoloScaricoFile() As Boolean
        Get
            Return (File.Exists(Path.Combine(mCartelle.CartellaDati, "Archivi.OK")) = False)
        End Get
    End Property

    Public Function ConsensoImportazione(CodiceSub As String,
                                         Optional CodiceProd As String = "0") As Boolean
        Try
            If mListaSub.Count = 0 AndAlso mListaProd.Count = 0 Then
                Return True
            Else
                If (IsNumeric(CodiceSub) = False) OrElse (IsNumeric(CodiceProd) = False) Then
                    Throw New Exception(String.Format("Figura non valida: {0}", CodiceSub))
                Else
                    Return mListaSub.Contains(Val(CodiceSub)) OrElse mListaProd.Contains(Val(CodiceProd))
                End If
            End If

        Catch ex As Exception
            RaiseEvent Errore(Me.ToString, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function
End Class

Public Class RecordConfigSedeSecondaria

    Public Event Errore(Modulo As String, Metodo As String, ByRef ex As Exception)

    Sub New(ByRef Dati As DataTable)
        If Dati.Rows.Count > 0 Then
            With Dati.Rows(0)
                mAgenziaFiglia = .Item("Agenzia")
                mCodiceSede = .Item("Sede")
                mPattoUnipol = (.Item("PattoUnipol") = "S")
                mListeQT = (.Item("ListeQT") = "S")
                mArchivio = (.Item("Archivio") = "S")
                mBuste = (.Item("Buste") = "S")
            End With
        End If
    End Sub

    Private mAgenziaFiglia As String
    Public ReadOnly Property AgenziaFiglia() As String
        Get
            Return mAgenziaFiglia
        End Get
    End Property

    Private mCodiceSede As String
    Public ReadOnly Property CodiceSede() As String
        Get
            Return mCodiceSede
        End Get
    End Property

    Private mPattoUnipol As Boolean
    Public ReadOnly Property PattoUnipol() As Boolean
        Get
            Return mPattoUnipol
        End Get
    End Property

    Private mListeQT As Boolean
    Public ReadOnly Property ListeQT() As Boolean
        Get
            Return mListeQT
        End Get
    End Property

    Private mArchivio As Boolean
    Public ReadOnly Property Archivio() As Boolean
        Get
            Return mArchivio
        End Get
    End Property

    Private mBuste As Boolean
    Public ReadOnly Property Buste() As Boolean
        Get
            Return mBuste
        End Get
    End Property
End Class

Public Class AgenziaUnicont

    Private mAgenzia As String

    Sub New(ByRef ConfigUniarea As DataTable)
        mAbilitazioneUniarea = (ConfigUniarea.Rows.Count > 0)

        If mAbilitazioneUniarea = True Then
            With ConfigUniarea.Rows(0)
                mAgenzia = .Item("Agenzia")
                mDataInizio = .Item("DataInizio")
                mDataFine = .Item("DataFine")
                mForzatura = .Item("Forzatura")
            End With
            LeggiAbilitazioneSIA()
        End If
    End Sub

    Private mAbilitazioneUniarea As Boolean
    Public ReadOnly Property AbilitazioneUniarea() As Boolean
        Get
            Return mAbilitazioneUniarea
        End Get
    End Property

    Private mAbilitazioneSIA As Boolean
    Public ReadOnly Property AbilitazioneSIA() As Boolean
        Get
            Return mAbilitazioneSIA
        End Get
    End Property

    Private mDataUltimoInvioSia As Date
    Public ReadOnly Property DataUltimoInvioSia() As Date
        Get
            Return mDataUltimoInvioSia
        End Get
    End Property

    Private mDataInizio As Date
    Public ReadOnly Property DataInizio() As Date
        Get
            Return mDataInizio
        End Get
    End Property

    Private mDataFine As Date
    Public ReadOnly Property DataFine() As Date
        Get
            Return mDataFine
        End Get
    End Property

    Private mForzatura As Object
    Public ReadOnly Property Forzatura() As Object
        Get
            Return mForzatura
        End Get
    End Property

    Private Sub LeggiAbilitazioneSIA()
        Try
            Using Sia As New UploadSiaMA.WsUploader
                'configuro il servizio
                With Sia
                    .Url = "https://omaportal.siaspa.com/SIA.FTA.Portal/WsUploader.asmx"
                    .Timeout = 60000 '60 secondi
                    .Proxy = Utx.Globale.UniProxy.Proxy
                End With

                'controllo se l'agenzia è abilitata da SIA altrimenti esco
                If Sia.IsAgeUnipolActive(mAgenzia) Then
                    Globale.Log.Info(String.Format("{0}: Agenzia abilitata a ricevere i file MA presso SIA", mAgenzia))

                    'controllo data ultimo invio
                    mDataUltimoInvioSia = Sia.GetLastDateUploader(mAgenzia)

                    'se è impostata una forzatura
                    If IsDate(mForzatura) Then
                        'se la data è maggiore della forzatura
                        If mDataUltimoInvioSia > mForzatura Then
                            'si riparte dalla forzatura
                            mDataUltimoInvioSia = mForzatura
                        End If
                    End If

                    mAbilitazioneSIA = True
                Else
                    Globale.Log.Info(String.Format("{0}: Agenzia NON abilitata a ricevere i file MA presso SIA", mAgenzia))
                    mAbilitazioneSIA = False
                End If
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
        End Try
    End Sub

    'Private Sub LeggiAbilitazioneSIA()
    '    Try
    '        Using Sia As New UploadSia.FileUploader
    '            'configuro il servizio
    '            With Sia
    '                .Url = "https://omaportal.siaspa.com/WS_UGF/FileUploader.asmx"
    '                .Timeout = 60000 '60 secondi
    '                .Proxy = Utx.Globale.UniProxy.Proxy
    '            End With

    '            'controllo se l'agenzia è abilitata da SIA altrimenti esco
    '            If Sia.IsAgeActive(mAgenzia) Then
    '                Globale.Log.Info(String.Format("{0}: Agenzia abilitata a Unicont presso SIA", mAgenzia))

    '                'controllo data ultimo invio
    '                mDataUltimoInvioSia = Sia.GetLastDateUploader(mAgenzia)

    '                'se è impostata una forzatura
    '                If IsDate(mForzatura) Then
    '                    'se la data è maggiore della forzatura
    '                    If mDataUltimoInvioSia > mForzatura Then
    '                        'si riparte dalla forzatura
    '                        mDataUltimoInvioSia = mForzatura
    '                    End If
    '                End If

    '                mAbilitazioneSIA = True
    '            Else
    '                Globale.Log.Info(String.Format("{0}: Agenzia NON abilitata a Unicont presso SIA", mAgenzia))
    '                mAbilitazioneSIA = False
    '            End If
    '        End Using

    '    Catch ex As Exception
    '        Globale.Log.Info(ex.Message)
    '    End Try
    'End Sub
End Class

