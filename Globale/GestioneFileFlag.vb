Imports System.IO

Public Class GestioneFileFlag
    'gestione dei file che fungono da flag

    Public Shared Flag As List(Of FileFlag)

    Public Shared Sub InitFlag()
        'elenco dei flag
        Flag = New List(Of FileFlag)
        With Flag
            .Clear()
            ''non utilizzare il 3/12
            '.Add(New FileFlag("05-12-2016", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Prima manutenzione massiva"))
            ''non utilizzare il 6/12
            '.Add(New FileFlag("20-01-2017", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Aggiornamento anag"))
            '.Add(New FileFlag("01-02-2017", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Aggiornamento polizze"))
            '.Add(New FileFlag("06-02-2017", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Reset PTFCanc"))
            '.Add(New FileFlag("10-02-2017", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("13-02-2017", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Aggiorna marca veicolo"))
            '.Add(New FileFlag("ManutenzioneNote", FileFlag.Tipo.LIVE_CHANGE, Scadenza:=#10/16/2017#, Descrizione:="Manutenzione note"))
            '.Add(New FileFlag("24-02-2017", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("28-02-2017", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("07-03-2017", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("10-03-2017", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("16-03-2017", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("22-03-2017", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("23-03-2017", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("28-03-2017", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Manutenzione liste"))
            '.Add(New FileFlag("03-04-2017", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Modifica layout sinistri"))
            '.Add(New FileFlag("TabelleDbUno", FileFlag.Tipo.LIVE_CHANGE, Scadenza:=#9/16/2018#, Descrizione:="Nuove tabelle DbUno"))
            '.Add(New FileFlag("11-04-2017", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("13-04-2017", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("21-04-2017", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("01-05-2017", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("TabelleComuni", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Aggiornamento tabelle supporto"))
            '.Add(New FileFlag("EsistenzaTabelleComuni", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Esistenza tabelle supporto", Scadenza:=#5/1/2018#))
            '.Add(New FileFlag("ChiaviSupporto", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Chiavi supporto"))
            '.Add(New FileFlag("CompagniaNota", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Compagnia su note"))
            '.Add(New FileFlag("TracciatoPolizze", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Tracciato polizze", Scadenza:=#12/11/2017#))
            '.Add(New FileFlag("CreaIndici", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Crea indici", Scadenza:=#8/22/2017#))
            '.Add(New FileFlag("ModelliAgenzia", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Controllo modelli agenzia", Scadenza:=#5/8/2018#))
            '.Add(New FileFlag("ClientiSub", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="SubAgenzia cliente"))
            '.Add(New FileFlag("TracciatiRete", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("NormalizzaDbUno", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Normalizza DbUno", Scadenza:=#11/13/2018#))
            '.Add(New FileFlag("TabelleBudget", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Tabelle budget"))
            '.Add(New FileFlag("ResetCalendarioOmnia0307", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("ModificaComparti_25072017", FileFlag.Tipo.LIVE_CHANGE))
            '.Add(New FileFlag("RinominaSinistriDP", FileFlag.Tipo.LIVE_CHANGE, Scadenza:=#9/26/2017#, Descrizione:="Tabelle sinistri DP"))
            '.Add(New FileFlag("NormalizzaFlag", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Normalizza file flag"))
            '.Add(New FileFlag("AllineamentoModelli", FileFlag.Tipo.LIVE_CHANGE, Scadenza:=#9/26/2017#, Descrizione:="Modifica tracciati"))
            '.Add(New FileFlag("TabellaUtenti", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Update utenti"))
            '.Add(New FileFlag("ArchiviaIncassi", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Archivia incassi"))
            '.Add(New FileFlag("IndiciDbUno", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Controlla vincoli DbUno", Scadenza:=#11/25/2018#))
            '.Add(New FileFlag("PuliziaDati", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Pulizia cartelle dati", Scadenza:=#3/23/2021#, PeriodoGiorni:=7))
            '.Add(New FileFlag("ContattiCIP", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Contatti CIP", PeriodoGiorni:=7))
            '.Add(New FileFlag("RipartizioneTitoli", FileFlag.Tipo.LIVE_CHANGE, Scadenza:=#11/19/2017#, Descrizione:="Ripartizione titoli"))
            '.Add(New FileFlag("ManutenzioneEvidenze", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Manutenzione evidenze", Scadenza:=#12/16/2020#))
            '.Add(New FileFlag("ArchiviaTitoli", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Archiviazione titoli", PeriodoGiorni:=30))
            '.Add(New FileFlag("Convenzioni", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Controllo convenzioni"))
            '.Add(New FileFlag("Arretrati", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Modifica tabella arretrati", Scadenza:=#3/28/2021#))
            '.Add(New FileFlag("EliminaTabelle", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Eliminazione tabelle"))
            '.Add(New FileFlag("NormalizzaDbSinistri", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Normalizza archivio sinistri", Scadenza:=#3/18/2019#))
            '.Add(New FileFlag("RecuperoSinistri022018", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Recupero sinistri"))
            '.Add(New FileFlag("RiletturaSinistri", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Verifica importazione sinistri"))
            '.Add(New FileFlag("ResetSinistriAia", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Reset sinistri Aia"))
            '.Add(New FileFlag("UpdateDataMemoSinistri", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Aggiorna data memo sinistri", Scadenza:=#12/01/2020#))
            '.Add(New FileFlag("MonitorQTKMS", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Monitor QT KMS"))
            '.Add(New FileFlag("ResetCalendarioAnag", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Reset calendario anag"))
            '.Add(New FileFlag("ResetCalendarioAnagNew", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Reset calendario nuova anag"))
            '.Add(New FileFlag("ResetCalendarioMonQTKMS", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Reset calendario MonQtKms", Scadenza:=#7/23/2020#))
            '.Add(New FileFlag("ResetDbLink", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Manutenzione DbLink", Scadenza:=#4/11/2021#))
            '.Add(New FileFlag("PuliziaEvidenze", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Manutenzione evidenze", PeriodoGiorni:=1))
            '.Add(New FileFlag("TabellaClienti", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Aggiorna tabella clienti"))
            '.Add(New FileFlag("LayoutClienti", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Aggiorna layout clienti"))
            .Add(New FileFlag("ModificaDbUt", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Aggiorna campi DbUt"))
            .Add(New FileFlag("LayoutSinistri", FileFlag.Tipo.LIVE_CHANGE, Descrizione:="Aggiorna layout sinistri", Scadenza:=#10/27/2022#))
            ''extra
            '.Add(New FileFlag("AndamentoSinistriRB", FileFlag.Tipo.LIVE_CHANGE, FileFlag.Categoria.EXTRA, Descrizione:="Andamento riserve"))
            ''tardivi
            '.Add(New FileFlag("25-01-2017", FileFlag.Tipo.LIVE_CHANGE, FileFlag.Categoria.TARDIVO))
            '.Add(New FileFlag("ResetCalendarioSinistri3001", FileFlag.Tipo.LIVE_CHANGE, FileFlag.Categoria.TARDIVO, Descrizione:="Reset calendario sinistri"))
            '.Add(New FileFlag("CorreggiSinistriDbUno", FileFlag.Tipo.LIVE_CHANGE, FileFlag.Categoria.TARDIVO, Descrizione:="Manutenzione sinistri da flusso", Scadenza:=#11/16/2020#))
            '.Add(New FileFlag("ModificaDbSupporto2", FileFlag.Tipo.LIVE_CHANGE, FileFlag.Categoria.TARDIVO))
            '.Add(New FileFlag("22-04-2017", FileFlag.Tipo.LIVE_CHANGE, FileFlag.Categoria.TARDIVO))
            '.Add(New FileFlag("26-04-2017", FileFlag.Tipo.LIVE_CHANGE, FileFlag.Categoria.TARDIVO))
            '.Add(New FileFlag("ResetCip", FileFlag.Tipo.LIVE_CHANGE, FileFlag.Categoria.TARDIVO))
            '.Add(New FileFlag("ChiaveRiletturaIncassi", FileFlag.Tipo.LIVE_CHANGE, FileFlag.Categoria.TARDIVO, Descrizione:="Rilettura incassi"))
            '.Add(New FileFlag("AggiornaPostalizzazione", FileFlag.Tipo.LIVE_CHANGE, FileFlag.Categoria.TARDIVO, Descrizione:="Aggiorna postalizzazione"))
            '.Add(New FileFlag("Postalizzazione", FileFlag.Tipo.LIVE_CHANGE, FileFlag.Categoria.TARDIVO, Descrizione:="Aggiorna postalizzazione"))
            '.Add(New FileFlag("AnomaliaSinistri10032019", FileFlag.Tipo.LIVE_CHANGE, FileFlag.Categoria.TARDIVO, Descrizione:="sinistri 10/03/2019"))
            '.Add(New FileFlag("ForzaturaSinistri", FileFlag.Tipo.LIVE_CHANGE, FileFlag.Categoria.TARDIVO, Descrizione:="Correzione anomalie sinistri", PeriodoGiorni:=30))
            '.Add(New FileFlag("Psico", FileFlag.Tipo.LIVE_CHANGE, FileFlag.Categoria.TARDIVO, Descrizione:="Assistenza psicologica"))
        End With
    End Sub

    Public Shared Sub DisposeFlag()
        If Flag IsNot Nothing Then
            Flag.Clear()
            Flag = Nothing
        End If
    End Sub
End Class

Public Class FileFlag

    Public Enum Tipo
        MIGRAZIONE
        LIVE_CHANGE
        RIAVVIO
    End Enum

    Public Enum Categoria
        NORMALE
        TARDIVO
        EXTRA
    End Enum

    Sub New(Key As String,
            TipoFlag As Tipo,
            Optional CategoriaFlag As Categoria = Categoria.NORMALE,
            Optional Descrizione As String = "",
            Optional Scadenza As Date = #1/1/1900#,
            Optional PeriodoGiorni As Integer = 0)

        mKey = Key
        mCategoriaFlag = CategoriaFlag
        mTipoFlag = TipoFlag
        mScadenza = Scadenza
        mEsito = True
        mEseguito = UltimaEsecuzione()
        mPeriodoGiorni = PeriodoGiorni
        If mPeriodoGiorni > 0 Then
            mScadenza = Format(mEseguito.AddDays(mPeriodoGiorni), "dd/MM/yyyy 07:00:00")
        End If
        If String.IsNullOrEmpty(Descrizione) Then
            mDescrizione = mKey
        Else
            mDescrizione = Descrizione
        End If
    End Sub

    Sub New(FullPathFlag As String)

        Dim Campi() As String = Path.GetFileName(FullPathFlag).Split(".")

        If Campi.GetUpperBound(0) = 1 Then
            mKey = Campi(1)
        Else
            mKey = ""
        End If

        For Each fl As FileFlag In GestioneFileFlag.Flag
            If fl.Key = mKey Then
                mTipoFlag = fl.TipoFlag
                mCategoriaFlag = fl.CategoriaFlag
                mDescrizione = fl.Descrizione
                mScadenza = fl.Scadenza
                mEseguito = UltimaEsecuzione()
                Exit Sub
            End If
        Next

        mTipoFlag = StringaTipo2Tipo(Campi(0))
        mDescrizione = mKey
        mScadenza = #1/1/1900#
        mEseguito = UltimaEsecuzione()
    End Sub

    Private mTipoFlag As String
    Public ReadOnly Property TipoFlag() As String
        Get
            Return mTipoFlag
        End Get
    End Property

    Private mCategoriaFlag As Categoria
    Public ReadOnly Property CategoriaFlag() As Categoria
        Get
            Return mCategoriaFlag
        End Get
    End Property

    Private mKey As String
    Public ReadOnly Property Key() As String
        Get
            Return mKey
        End Get
    End Property

    Private mDescrizione As String
    Public ReadOnly Property Descrizione() As String
        Get
            Return mDescrizione
        End Get
    End Property

    Public ReadOnly Property DescrizioneEx() As String
        Get
            Return String.Format("{0}: nome {1} - ultima esecuzione {2}", mDescrizione, mKey, Me.UltimaEsecuzione)
        End Get
    End Property

    Private mScadenza As Date
    Public Property Scadenza() As Date
        Get
            Return mScadenza
        End Get
        Set(value As Date)
            mScadenza = value
        End Set
    End Property

    Private mEsito As Boolean
    Public Property Esito() As Boolean
        Get
            Return mEsito
        End Get
        Set(value As Boolean)
            mEsito = mEsito And value
        End Set
    End Property

    Private mEseguito As Date
    Public ReadOnly Property Eseguito() As Date
        Get
            Return mEseguito
        End Get
    End Property

    Private mPeriodoGiorni As Integer
    Public ReadOnly Property PeriodoGiorni() As Integer
        Get
            Return mPeriodoGiorni
        End Get
    End Property

    Public Function Esiste() As Boolean
        If File.Exists(FullPath) Then
            If Now < mScadenza Then
                'la scadenza non è ancora arrivata
                Return True
            Else
                '+la scadenza è arrivata e il flag esiste se è stato eseguito dopo la scadenza
                Return mEseguito > mScadenza
            End If
        Else
            Return False
        End If
    End Function

    Private Function UltimaEsecuzione() As Date
        'restituisce la data e ora scritta nel file di flag
        Try
            If File.Exists(FullPath) Then
                Return CDate(Right(File.ReadAllText(FullPath), 19))
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function FullPath() As String
        Select Case mTipoFlag
            Case FileFlag.Tipo.LIVE_CHANGE
                Return String.Format("{0}\LiveChange.{1}", Utx.Globale.Paths.CartellaFlag, mKey)
            Case FileFlag.Tipo.RIAVVIO
                Return String.Format("{0}\Riavvio", Utx.Globale.Paths.CartellaFlagLocale)
            Case FileFlag.Tipo.MIGRAZIONE
                Return String.Format("{0}\Migrazione.ok", Utx.Globale.Paths.CartellaFlag)
        End Select
    End Function

    Public Shared Function StringaTipo2Tipo(StringaTipo As String) As Tipo
        Select Case StringaTipo.ToUpper
            Case "LIVECHANGE"
                Return Tipo.LIVE_CHANGE
            Case "MIGRAZIONE"
                Return Tipo.MIGRAZIONE
            Case "RIAVVIO"
                Return Tipo.RIAVVIO
        End Select
    End Function

    Public Function Definito() As Boolean
        For Each fl As FileFlag In GestioneFileFlag.Flag
            If fl.Key = mKey AndAlso fl.TipoFlag = mTipoFlag Then Return True
        Next
        Return False
    End Function

    Public Sub CreaFlag()
        mEseguito = Now
        File.WriteAllText(FullPath, Format(mEseguito, "dd/MM/yyyy HH:mm:ss"))
    End Sub

    Public Sub CancellaFlag()
        File.Delete(FullPath)
    End Sub
End Class

Public Class BloccoAutomatismi
    Public Shared ReadOnly Property Flag() As String
        Get
            Return Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "BLOCCO_AUTO.flag")
        End Get
    End Property

    Public Shared ReadOnly Property Attivo() As Boolean
        Get
            If File.Exists(Flag) Then
                Dim Attivazione As String = File.ReadAllText(Flag)
                If IsDate(Attivazione) Then
                    If Attivazione < Today Then
                        File.Delete(Flag)
                    End If
                Else
                    File.Delete(Flag)
                End If
            End If
            Return File.Exists(Flag)
        End Get
    End Property

    Public Shared Function Salva(FinoAl As Date) As Boolean
        Try
            File.WriteAllText(Flag, FinoAl)
            Return True
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            Return False
        End Try
    End Function

    Public Shared Sub Rimuovi()
        File.Delete(Flag)
    End Sub
End Class