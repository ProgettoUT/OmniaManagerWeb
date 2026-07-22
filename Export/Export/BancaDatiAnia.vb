Imports System.Net
Imports mshtml
Imports System.IO
'Imports System.Data.OleDb
Imports System.Data

Public Class BancaDatiAnia

    Public Event StatoImportazione(e As ExportEventArgs)

    Public Enum TipoFile
        STORNATE = 0
        ARRETRATI = 1
        UTENTE = 2
        DB = 3
        TARGASINGOLA = 4
    End Enum

    Public Structure Opzioni
        Dim TipoFile As TipoFile
        Dim FileOrigine As String
        Dim Dati As DataTable
        Dim SoloAutovetture As Boolean
        Dim PeriodoAggiornamento As Integer 'in giorni
        Dim TargaSingola As String
        Dim ClasseRca As String
    End Structure

    Public Structure IndiciColonna
        Dim Targa As Integer
        Dim Classe As Integer
        Dim Ramo As Integer
        Dim Storno As Integer
        Dim DataStorno As Integer
        Dim CF As Integer
        Dim Prodotto As Integer
        Dim Polizza As Integer
        Dim Effetto As Integer
        Dim Scadenza As Integer
        Dim Frazionamento As Integer
        Dim Convenzione As Integer
        Dim Incendio As Integer
        Dim UltimoPremio As Integer
    End Structure
    Private Colonna As IndiciColonna

    Private Structure PolizzaTarga
        Dim Prodotto As String
        Dim Ramo As Integer
        Dim Polizza As Integer
        Dim Effetto As Date
        Dim Scadenza As Date
        Dim Frazionamento As Integer
        Dim Convenzione As String
        Dim IDStorno As String
        Dim DataStorno As Date
        Dim IncendioFurto As Double
        Dim UltimoPremio As Single
    End Structure
    Dim Polizza As PolizzaTarga

    Private WithEvents e As New ExportEventArgs
    Private WithEvents Essig As RichiesteEssig

    Private Enum BDA
        CartaCircolazione = 0
        MotivoEmissioneCarta = 1
        Immatricolazione = 2
        Telaio = 4
        Omologazione = 6
        Modello = 8
        Nazionalita = 10
        TipoVeicolo = 12
        Categoria = 14
        Uso = 16
        Carrozzeria = 18
        Cilindrata = 20
        Cilindri = 22
        Peso = 24
        HP = 28
        Marce = 30
        KW = 36
        Alimentazione = 44
        Posti = 50
        CodiceCompagnia = 52
        Compagnia = 54
        CF = 57
        Effetto = 59
        ScadenzaCopertura = 63
        ScadenzaContratto = 65
        Tariffa = 71
        ClasseTariffa = 73
        DataSinistro = 79
    End Enum

    Public Sub New()
    End Sub

    Private mProvenienzaTarga As String

    Private mOpzioniBDA As Opzioni
    Public Property OpzioniBDA() As Opzioni
        Get
            Return mOpzioniBDA
        End Get
        Set(value As Opzioni)
            mOpzioniBDA = value

            Select Case OpzioniBDA.TipoFile
                Case TipoFile.STORNATE
                    mProvenienzaTarga = "ST"
                Case TipoFile.ARRETRATI
                    mProvenienzaTarga = "AR"
                Case Else
                    mProvenienzaTarga = "UT"
            End Select
        End Set
    End Property

    Public Sub InterrogaBDA(ByRef Annulla As Boolean)
        Select Case OpzioniBDA.TipoFile
            Case TipoFile.STORNATE, TipoFile.ARRETRATI
                EstrazioneToBDA(Annulla)
            Case TipoFile.UTENTE
                FileToBDA(Annulla)
            Case TipoFile.TARGASINGOLA
                AggiornaTarga(Annulla)
        End Select
    End Sub

    Public Sub EstrazioneToBDA(ByRef Annulla As Boolean)
        Try
            Globale.Log.Info("Avvio interrogazione BDA")
            e.Messaggio = "avvio..."

            'leggo l'intestazione
            If RilevaIndiciColonne() = False Then
                Exit Sub
            End If

            'tolgo gli spazi bianchi
            NormalizzaTarghe()

            'conto le targhe nuove da interrogare
            Dim NumeroTarghe As Integer = ConteggioTarghe()

            If NumeroTarghe = 0 Then
                MsgBox("Non ci sono nuove targhe da interrogare.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Exit Sub
            Else
                If MsgBox(String.Format("Procedere con l'interrogazione di {0} nuove targhe non ancora in archivio?", NumeroTarghe),
                          MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2,
                          Utx.Globale.TitoloApp) = MsgBoxResult.No Then

                    e.Messaggio = "Interrogazione annullata"
                    Exit Sub
                End If
            End If

            Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.BDA, RichiesteEssig.TipoCompagnia.UNIPOL)

            Dim ContatoreTarga As Integer = 0
            Dim Targa As String = ""

            'leggo le righe dati
            For Each r As DataRow In DistinctTarghe().Rows

                Targa = r("Targa")

                'se la targa non è vuota
                If Targa.Length > 0 Then
                    'il consenso è stato dato in conteggio  altrimenti la targhe viene cancellata

                    Dim DatiTarga As DataRow

                    If OpzioniBDA.TipoFile = TipoFile.STORNATE Then
                        'cerco le targhe nella tabella principale: nella prima riga (indice zero) 
                        'ci sarà l'ultima polizza stornata
                        DatiTarga = OpzioniBDA.Dati.Select(String.Format("Targa = '{0}'", Targa), "[Data storno] DESC")(0)
                    Else
                        'arretrati. ordino per effetto titolo
                        DatiTarga = OpzioniBDA.Dati.Select(String.Format("Targa = '{0}'", Targa), "[Effetto titolo] DESC")(0)
                    End If

                    ContatoreTarga += 1
                    e.Messaggio = String.Format("Interrogazione BDA: targa {0} ({1}/{2})", Targa, ContatoreTarga, NumeroTarghe)

                    'chiamo il menù: necessario per settaggio parametri
                    Essig.ChiamaMenu()
                    If Essig.EventArgs.Errore = True Then
                        e = Essig.EventArgs
                    End If

                    'ottengo la pagina dati
                    Dim DatiBDA As String = Essig.RichiestaDati(TipoTarga(Targa, DatiTarga(Colonna.Classe)), Targa, "")
                    If e.Errore = True Then
                        Exit Try
                    End If

                    'estraggo i dati BDA dalla pagina
                    Dim Dati() As String = EstraiDatiBDA(Html2Dom(DatiBDA))

                    'se non ci sono errori salvo nel db
                    If e.Errore = False Then

                        'recupera i dati della polizza per salvarli nel db BDA
                        DatiPolizza(DatiTarga)

                        'salva interrogazione
                        SalvaTarga(Targa, DatiTarga, Dati)

                        If e.Errore = True Then
                            Exit Try
                        End If
                    End If

                    If Annulla = True Then
                        Exit For
                    End If
                End If
            Next

            Globale.Log.Info(String.Format("Interrogazione BDA di {0} targhe completata", ContatoreTarga))

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Sub FileToBDA(ByRef Annulla As Boolean)
        Try
            Globale.Log.Info("Avvio interrogazione BDA")
            e.Messaggio = "avvio..."

            Dim TotaleRighe As Integer = File.ReadAllLines(OpzioniBDA.FileOrigine).Length

            Using sr As New StreamReader(OpzioniBDA.FileOrigine)

                'leggo l'intestazione
                If RilevaIndiciColonne(sr.ReadLine) = False Then
                    Exit Sub
                End If

                Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.BDA)

                'cancello i precedenti dati provenienti da file utente
                Utx.WsCommand.ExecuteNonQuery("DELETE FROM BDA WHERE ProvenienzaTarga = 'UT'")

                Dim ContatoreTarga As Integer = 0
                Dim Targa As String = ""

                'leggo le righe dati
                Do While sr.EndOfStream = False

                    'leggo la riga
                    Dim Campi() As String = sr.ReadLine.Split(";")

                    'se c'è consenso
                    If ConsensoInterrogazione(Campi) = True Then

                        Targa = Campi(Colonna.Targa).Replace(" ", "")

                        'cancello la targa se esiste per reinserirla come richiesta da file utente
                        CancellaTarga(Targa)

                        ContatoreTarga += 1
                        e.Messaggio = String.Format("Interrogazione BDA: targa {0} ({1}/{2})",
                                                        Targa, ContatoreTarga, TotaleRighe)

                        'chiamo il menù: necessario per settaggio parametri
                        Essig.ChiamaMenu()
                        If Essig.EventArgs.Errore = True Then
                            e = Essig.EventArgs
                        End If

                        'ottengo la pagina dati
                        Dim DatiBDA As String = Essig.RichiestaDati(TipoTarga(Targa, Campi(Colonna.Classe)), Targa, "")
                        If e.Errore = True Then
                            Exit Try
                        End If

                        'estraggo i dati BDA dalla pagina
                        Dim Dati() As String = EstraiDatiBDA(Html2Dom(DatiBDA))

                        'se non ci sono errori salvo nel db
                        If e.Errore = False Then

                            'recupera i dati della polizza per salvarli nel db BDA
                            DatiPolizza(Campi)
                            'salva interrogazione
                            SalvaTarga(Targa, Campi, Dati)

                            If e.Errore = True Then
                                Exit Try
                            End If
                        End If

                        If Annulla = True Then
                            Exit Do
                        End If
                    End If
                Loop
                Globale.Log.Info(String.Format("Interrogazione BDA di {0} targhe completata", ContatoreTarga))
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Sub NormalizzaTarghe()
        Try
            'tolgo gli spazi bianchi
            For Each r As DataRow In OpzioniBDA.Dati.Rows
                r("Targa") = r("Targa").Replace(" ", "")
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function DistinctTarghe() As DataTable
        Try
            Dim dv As New DataView(OpzioniBDA.Dati)
            Dim dt As DataTable = dv.ToTable(True, {"Targa"})
            Return dt
        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
            Return New DataTable
        End Try
    End Function

    Public Function ConteggioTarghe() As Integer

        ConteggioTarghe = 0
        Try
            Globale.Log.Info("Conteggio targhe...")
            e.Messaggio = "Conteggio targhe..."

            'archivio targhe contiene le targhe già nell'archivio BDA
            Dim ArchivioBDA As DataTable = ArchivioTarghe()

            If ArchivioBDA.Rows.Count = 0 Then
                ConteggioTarghe = OpzioniBDA.Dati.Rows.Count
            Else
                'targhe già in archivio
                ArchivioBDA.PrimaryKey = {ArchivioBDA.Columns("Targa")}

                'leggo le righe dati estratte: DistinctTarghe contiene tutte le targhe estratte (una sola volta)
                For Each r As DataRow In DistinctTarghe().Rows

                    Dim TargaEstratta() As DataRow

                    If OpzioniBDA.TipoFile = TipoFile.STORNATE Then
                        'cerco le targhe nella estrazione: nella prima riga ci sarà l'ultima polizza stornata
                        TargaEstratta = OpzioniBDA.Dati.Select(String.Format("Targa = '{0}'", r("Targa")), "[Data storno] DESC")
                    Else
                        TargaEstratta = OpzioniBDA.Dati.Select(String.Format("Targa = '{0}'", r("Targa")), "[Effetto titolo] DESC")
                    End If

                    'se c'è consenso per la targa
                    If ConsensoInterrogazione(TargaEstratta(0)) = True Then

                        'cerco le targhe nell'archivio
                        Dim TargaArchivio As DataRow = ArchivioBDA.Rows.Find(r("Targa"))

                        If TargaArchivio Is Nothing Then
                            'la targa non esiste
                            ConteggioTarghe += 1
                        Else
                            'esiste in archivio
                            If (mProvenienzaTarga = "ST") Then
                                'sto analizzando gli stornati e in archivio è AR 
                                If (TargaArchivio("ProvenienzaTarga") = "AR") Then
                                    'cancello dall'archivio per interrogare di nuovo
                                    CancellaTarga(r("Targa"))
                                    ConteggioTarghe += 1
                                Else
                                    'cancello la targa dalla tabella principale così non sarà interrogata
                                    For k As Integer = 0 To TargaEstratta.GetUpperBound(0)
                                        TargaEstratta(k)("Targa") = ""
                                    Next
                                End If
                            Else
                                'cancello la targa dalla tabella principale così non sarà interrogata
                                For k As Integer = 0 To TargaEstratta.GetUpperBound(0)
                                    TargaEstratta(k)("Targa") = ""
                                Next
                            End If
                        End If
                    Else
                        'cancello la targa dalla tabella principale così non sarà interrogata
                        For k As Integer = 0 To TargaEstratta.GetUpperBound(0)
                            TargaEstratta(k)("Targa") = ""
                        Next
                    End If

                    e.Messaggio = String.Format("Conteggio targhe...{0}", ConteggioTarghe)
                Next
            End If
            e.Messaggio = String.Format("Nuove targhe {0}", ConteggioTarghe)
            Globale.Log.Info(String.Format("Targhe da interrogare: {0}", ConteggioTarghe))

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Function

    Private Sub DatiPolizza(ByRef Campi As DataRow)
        Try
            'reset polizza
            With Polizza
                .Prodotto = "00000"
                .Ramo = 0
                .Polizza = 0
                .Effetto = Nothing
                .Scadenza = Nothing
                .Frazionamento = 0
                .Convenzione = "00000"
                .IDStorno = "00"
                .DataStorno = Nothing
                .IncendioFurto = 0
                .UltimoPremio = 0
            End With

            Select Case OpzioniBDA.TipoFile

                Case TipoFile.STORNATE
                    With Polizza
                        .Prodotto = Campi(Colonna.Prodotto)
                        .Ramo = Left(Campi(Colonna.Ramo), 3)
                        .Polizza = Campi(Colonna.Polizza)
                        .Effetto = Campi(Colonna.Effetto)
                        .Scadenza = Campi(Colonna.Scadenza)
                        .Frazionamento = Campi(Colonna.Frazionamento)
                        .Convenzione = Campi(Colonna.Convenzione)
                        .IDStorno = Campi(Colonna.Storno)
                        .DataStorno = Campi(Colonna.DataStorno)
                        .IncendioFurto = StringToNumber(Campi(Colonna.Incendio))
                        .UltimoPremio = StringToNumber(Campi(Colonna.UltimoPremio))
                    End With

                Case TipoFile.ARRETRATI

            End Select

        Catch ex As Exception

            Globale.Log.Info(ex.Message)

            With Polizza
                .Prodotto = "00000"
                .Ramo = 0
                .Polizza = 0
                .Effetto = Nothing
                .Scadenza = Nothing
                .Frazionamento = 0
                .Convenzione = "00000"
                .IDStorno = "00"
                .DataStorno = Nothing
                .IncendioFurto = 0
                .UltimoPremio = 0
            End With
        End Try
    End Sub

    Private Sub DatiPolizza(ByRef Campi() As String)
        Try
            'reset polizza
            With Polizza
                .Prodotto = "00000"
                .Ramo = 0
                .Polizza = 0
                .Effetto = Nothing
                .Scadenza = Nothing
                .Frazionamento = 0
                .Convenzione = "00000"
                .IDStorno = "00"
                .DataStorno = Nothing
                .IncendioFurto = 0
                .UltimoPremio = 0
            End With

            Select Case OpzioniBDA.TipoFile

                Case TipoFile.STORNATE
                    With Polizza
                        .Prodotto = Campi(Colonna.Prodotto)
                        .Ramo = Left(Campi(Colonna.Ramo), 3)
                        .Polizza = Campi(Colonna.Polizza)
                        .Effetto = Campi(Colonna.Effetto)
                        .Scadenza = Campi(Colonna.Scadenza)
                        .Frazionamento = Campi(Colonna.Frazionamento)
                        .Convenzione = Campi(Colonna.Convenzione)
                        .IDStorno = Campi(Colonna.Storno)
                        .DataStorno = Campi(Colonna.DataStorno)
                        .IncendioFurto = StringToNumber(Campi(Colonna.Incendio))
                        .UltimoPremio = StringToNumber(Campi(Colonna.UltimoPremio))
                    End With

                Case TipoFile.ARRETRATI

            End Select

        Catch ex As Exception

            Globale.Log.Info(ex.Message)

            With Polizza
                .Prodotto = "00000"
                .Ramo = 0
                .Polizza = 0
                .Effetto = Nothing
                .Scadenza = Nothing
                .Frazionamento = 0
                .Convenzione = "00000"
                .IDStorno = "00"
                .DataStorno = Nothing
                .IncendioFurto = 0
                .UltimoPremio = 0
            End With
        End Try
    End Sub

    Private Function RilevaIndiciColonne(Testata As String) As Boolean
        Try
            Dim Campi() As String = Testata.Split(";")

            'rilevo gli indici delle colonne contenenti i dati
            With Colonna
                .Targa = -1
                .Classe = -1
                .Ramo = -1
                .Storno = -1
                .CF = -1
                .Prodotto = -1
                .Polizza = -1
                .Effetto = -1
                .Scadenza = -1
                .Frazionamento = -1
                .Convenzione = -1
                .Storno = -1
                .DataStorno = -1
                .Incendio = -1
            End With

            For k As Integer = 0 To Campi.GetUpperBound(0)

                If String.Equals(Campi(k).Trim, "Targa", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Targa = k
                ElseIf String.Equals(Campi(k).Trim, "Classe RCA", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Classe = k
                ElseIf String.Equals(Campi(k).Trim, "Ramo", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Ramo = k
                ElseIf String.Equals(Campi(k).Trim, "Codice storno", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Storno = k
                ElseIf Campi(k).Trim.StartsWith("Data storno", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.DataStorno = k
                ElseIf Campi(k).Trim.StartsWith("Codice fiscale", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.CF = k
                ElseIf Campi(k).Trim.StartsWith("Prodotto", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Prodotto = k
                ElseIf String.Equals(Campi(k).Trim, "Polizza", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Polizza = k
                ElseIf String.Equals(Campi(k).Trim, "Data effetto", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Effetto = k
                ElseIf String.Equals(Campi(k).Trim, "Data scadenza", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Scadenza = k
                ElseIf Campi(k).Trim.StartsWith("Frazionamento", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Frazionamento = k
                ElseIf Campi(k).Trim.StartsWith("Convenzione", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Convenzione = k
                ElseIf Campi(k).Trim.IndexOf("Incendio", StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                    Colonna.Incendio = k
                ElseIf Campi(k).Trim.IndexOf("Ultimo premio", StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                    Colonna.UltimoPremio = k
                End If
            Next

            If Colonna.Targa < 0 OrElse Colonna.Classe < 0 Then
                MsgBox("Campi 'Targa' e/o 'Classe Rca' non trovati. Il file deve avere una riga di intestazione con i nomei dei campi. Utilizzare il modello fornito (bottone modello).", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            Return False
        End Try
    End Function

    Private Function RilevaIndiciColonne() As Boolean
        Try
            'rilevo gli indici delle colonne contenenti i dati
            With Colonna
                .Targa = -1
                .Classe = -1
                .Ramo = -1
                .Storno = -1
                .CF = -1
                .Prodotto = -1
                .Polizza = -1
                .Effetto = -1
                .Scadenza = -1
                .Frazionamento = -1
                .Convenzione = -1
                .Storno = -1
                .DataStorno = -1
                .Incendio = -1
            End With

            Dim Campo As String

            For k As Integer = 0 To OpzioniBDA.Dati.Columns.Count - 1

                Campo = OpzioniBDA.Dati.Columns(k).ColumnName

                If String.Equals(Campo, "Targa", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Targa = k
                ElseIf String.Equals(Campo, "Classe RCA", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Classe = k
                ElseIf String.Equals(Campo, "Ramo", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Ramo = k
                ElseIf String.Equals(Campo, "Codice storno", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Storno = k
                ElseIf Campo.StartsWith("Data storno", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.DataStorno = k
                ElseIf Campo.StartsWith("Codice fiscale", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.CF = k
                ElseIf Campo.StartsWith("Prodotto", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Prodotto = k
                ElseIf String.Equals(Campo, "Polizza", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Polizza = k
                ElseIf String.Equals(Campo, "Data effetto", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Effetto = k
                ElseIf String.Equals(Campo, "Data scadenza", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Scadenza = k
                ElseIf Campo.StartsWith("Frazionamento", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Frazionamento = k
                ElseIf Campo.StartsWith("Convenzione", StringComparison.InvariantCultureIgnoreCase) = True Then
                    Colonna.Convenzione = k
                ElseIf Campo.IndexOf("Incendio", StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                    Colonna.Incendio = k
                ElseIf Campo.IndexOf("Ultimo premio", StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                    Colonna.UltimoPremio = k
                End If
            Next

            If Colonna.Targa < 0 OrElse Colonna.Classe < 0 Then
                MsgBox("Campi Targa e/o Classe Rca non trovati", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            Return False
        End Try
    End Function

    Public Sub AggiornaBDA(ByRef Annulla As Boolean)
        'l'aggiornamento viene fatto solo sulle stornate
        'Try
        '    Globale.Log.Info("Avvio interrogazione BDA per aggiornamento")
        '    e.Messaggio = "Aggiornamento archivio"

        '    Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.BDA, mCookie)

        '    Dim Blocco As Integer = 50
        '    'leggo le targhe scadute
        '    Dim Query As String = String.Format("SELECT TOP {0} Aggiornato,CartaCircolazione,MotivoEmissioneCarta,Immatricolazione,
        '        CodiceCompagnia,Effetto,Targa,ClasseRca,ScadenzaCopertura,ScadenzaContratto,Tariffa,ClasseTariffa,DataSinistro,
        '        BloccoTarga,CodiceFiscale 
        '        FROM Bda 
        '        WHERE (ScadenzaContratto <= '{1:dd/MM/yyyy}') AND (ProvenienzaTarga = 'ST') AND (BloccoTarga = cast(0 as bit))",
        '                                        Blocco, Today.AddDays(OpzioniBDA.PeriodoAggiornamento))

        '    Dim da As New OleDbDataAdapter(cmd)
        '            Dim dt As New DataTable

        '            Using cb As New OleDbCommandBuilder(da)
        '                'creo il command per l'update
        '                da.UpdateCommand = cb.GetUpdateCommand

        '                Dim Progressivo As Integer = 0

        '                Do While True
        '                    da.Fill(dt)
        '                    Progressivo += 1

        '                    If dt.Rows.Count = 0 Then
        '                        Exit Do
        '                    End If

        '                    For k As Integer = 0 To Math.Min(Blocco - 1, dt.Rows.Count - 1)

        '                        Dim r As DataRow = dt.Rows(k)

        '                e.Messaggio = String.Format("Aggiornamento BDA: targa {0} ({1}/blocco {2}x{3})",
        '                                                    r("Targa"), k + 1, Progressivo, Blocco)

        '                'chiamo il menù: necessario per settaggio parametri
        '                Essig.ChiamaMenu()
        '                        If Essig.EventArgs.Errore = True Then
        '                            e = Essig.EventArgs
        '                        End If

        '                        'ottengo la pagina dati
        '                        Dim DatiBDA As String = Essig.RichiestaDati(TipoTarga(r("Targa"), r("ClasseRca")), r("Targa"), "")
        '                        If e.Errore = True Then
        '                            Exit Try
        '                        End If

        '                        'estraggo i dati BDA dalla pagina
        '                        Dim Dati() As String = EstraiDatiBDA(Html2Dom(DatiBDA))

        '                        'aggiorno la riga
        '                        r("Aggiornato") = Today
        '                        r("CartaCircolazione") = StringToDate(Dati(BDA.CartaCircolazione))
        '                        r("MotivoEmissioneCarta") = Left(Dati(BDA.MotivoEmissioneCarta), 40)
        '                        r("Immatricolazione") = StringToDate(Dati(BDA.Immatricolazione))
        '                        r("CodiceCompagnia") = StringToNumber(Dati(BDA.CodiceCompagnia))
        '                        r("Effetto") = StringToDate(Dati(BDA.Effetto))
        '                        r("ScadenzaCopertura") = StringToDate(Dati(BDA.ScadenzaCopertura))
        '                        r("ScadenzaContratto") = StringToDate(Dati(BDA.ScadenzaContratto))
        '                        r("Tariffa") = Left(Dati(BDA.Tariffa), 15)
        '                        r("ClasseTariffa") = Left(Dati(BDA.ClasseTariffa), 10)
        '                        r("DataSinistro") = StringToDate(Dati(BDA.DataSinistro))
        '                        'se la copertura è scaduta da oltre 2 mesi blocco la targa
        '                        If IsDate(r("ScadenzaCopertura")) AndAlso CDate(r("ScadenzaCopertura")).AddMonths(-2) < Today Then
        '                            r("BloccoTarga") = True
        '                        End If

        '                        If (Dati(BDA.CF).Length > 0) Then
        '                            r("CodiceFiscale") = Dati(BDA.CF)
        '                        End If
        '                    Next
        '                    'salvo eventuali record residui (non arrivo a 100)
        '                    e.Messaggio = "Salvataggio dei dati..."
        '                    da.Update(dt)
        '                    'svuoto il dt
        '                    dt.Rows.Clear()

        '                    If Annulla = True Then
        '                        Exit Do
        '                    End If
        '                Loop
        '            End Using

        '            Globale.Log.Info(String.Format("Interrogazione BDA di {0} targhe completata", dt.Rows.Count))
        '        End Using
        '    End Using

        'Catch ex As Exception
        '    Globale.Log.Info(ex.Message)
        '    e.Messaggio = ex.Message
        '    e.Errore = True
        'End Try
    End Sub

    Public Sub AggiornaTarga(ByRef Annulla As Boolean)
        'l'aggiornamento singola targa
        Try
            Globale.Log.Info(String.Format("Aggiornamento targa {0}", OpzioniBDA.TargaSingola))

            Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.BDA)

            Dim Query As String = String.Format("SELECT * FROM Bda WHERE Targa = '{0}'", OpzioniBDA.TargaSingola)
            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            'la targa è una sola
            For k As Integer = 0 To dt.Rows.Count - 1

                Dim r As DataRow = dt.Rows(k)

                e.Messaggio = String.Format("Aggiornamento BDA: targa {0} ({1}/{2})", r("Targa"), k + 1, dt.Rows.Count)

                'chiamo il menù: necessario per settaggio parametri
                Essig.ChiamaMenu()
                If Essig.EventArgs.Errore = True Then
                    e = Essig.EventArgs
                End If

                'ottengo la pagina dati
                Dim DatiBDA As String = Essig.RichiestaDati(TipoTarga(r("Targa"), r("ClasseRca")), r("Targa"), "")
                If e.Errore = True Then
                    Exit Try
                End If

                'estraggo i dati BDA dalla pagina
                Dim Dati() As String = EstraiDatiBDA(Html2Dom(DatiBDA))

                'aggiorno la riga
                r("Aggiornato") = Today
                r("CartaCircolazione") = StringToDate(Dati(BDA.CartaCircolazione))
                r("MotivoEmissioneCarta") = Left(Dati(BDA.MotivoEmissioneCarta), 40)
                r("Immatricolazione") = StringToDate(Dati(BDA.Immatricolazione))
                r("CodiceCompagnia") = StringToNumber(Dati(BDA.CodiceCompagnia))
                r("Effetto") = StringToDate(Dati(BDA.Effetto))
                r("ScadenzaCopertura") = StringToDate(Dati(BDA.ScadenzaCopertura))
                r("ScadenzaContratto") = StringToDate(Dati(BDA.ScadenzaContratto))
                r("Tariffa") = Left(Dati(BDA.Tariffa), 15)
                r("ClasseTariffa") = Left(Dati(BDA.ClasseTariffa), 10)
                r("DataSinistro") = StringToDate(Dati(BDA.DataSinistro))

                If (Dati(BDA.CF).Length > 0) Then
                    r("CodiceFiscale") = Dati(BDA.CF)
                End If

                If Annulla = True Then
                    Exit For
                End If
            Next

            If dt.Rows.Count > 0 Then
                Using s As New Utx.ServiziOMW.ServizioDatiOMW
                    s.Proxy = Utx.Globale.UniProxy.Proxy
                    s.AggiornaBDA(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, dt, Utx.NetFunc.TokenUniWeb)
                End Using
            End If
            Globale.Log.Info("Interrogazione BDA completata")

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Public Function InterrogaTargaSingola(Targa As String, ClasseRca As String) As BDATarga
        'l'aggiornamento singola targa
        Try
            Globale.Log.Info($"Interrogo targa singola {Targa}")

            Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.BDA)

            'chiamo il menù: necessario per settaggio parametri
            Essig.ChiamaMenu()
            If Essig.EventArgs.Errore = True Then
                e.Errore = True
                Call New Utx.NotificaRapida(Utx.FormNotifica.AltezzaNotifica.MEZZA).VisualizzaErrore(Essig.EventArgs.Messaggio)
                Return New BDATarga With {.EsitoBDA = False}
            End If

            'ottengo la pagina dati
            Dim DatiBDA As String = Essig.RichiestaDati(TipoTarga(Targa, ClasseRca), Targa, "")
            If Essig.EventArgs.Errore = True Then
                e.Errore = True
                Return New BDATarga With {.EsitoBDA = False}
            End If

            'estraggo i dati BDA dalla pagina
            Dim BDA As New BDATarga(Targa, ClasseRca, EstraiDatiBDA(Html2Dom(DatiBDA)))
            If BDA.EsitoBDA = True Then
                Return BDA
            Else
                Return New BDATarga With {.EsitoBDA = False}
            End If

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            e.Messaggio = ex.Message
            e.Errore = True
            Return New BDATarga With {.EsitoBDA = False}
        End Try
    End Function

    Private Function EstraiDatiBDA(ByRef PaginaBDA As mshtml.HTMLDocument) As String()

        Dim Dati(130) As String 'per sicurezza (ne servono di meno)

        Try
            Dim row As IHTMLTableRow
            Dim cell As IHTMLTableCell

            Dim e As IHTMLElement, x As IHTMLElement, y As IHTMLElement, z As IHTMLElement, i As IHTMLElement

            Dim k As Integer = 0

            'dati tecnici veicoli
            Dim Tbl As Object = CType(PaginaBDA.getElementById("risultato"), IHTMLTable)

            For Each row In Tbl.rows
                For Each cell In row.cells
                    e = cell

                    For Each x In e.children
                        For Each y In x.children
                            For Each z In y.children
                                For Each i In z.children
                                    Dati(k) = Trim(i.innerText)
                                    k += 1
                                Next
                            Next
                        Next
                    Next
                Next
            Next

            k = 51

            'posizione assicurativa
            Tbl = PaginaBDA.getElementById("risultatoPossAss")

            For Each row In Tbl.rows
                For Each cell In row.cells
                    e = cell

                    For Each x In e.children
                        For Each y In x.children
                            For Each z In y.children
                                For Each i In z.children
                                    Dati(k) = Trim(i.innerText)
                                    k += 1
                                Next
                            Next
                        Next
                    Next
                Next
            Next

            'sinistri
            Tbl = PaginaBDA.getElementById("risultatoSin")

            For Each row In Tbl.rows
                For Each cell In row.cells
                    e = cell

                    For Each x In e.children
                        For Each y In x.children
                            For Each z In y.children
                                For Each i In z.children
                                    Dati(k) = Trim(i.innerText)
                                    k += 1
                                Next
                            Next
                        Next
                    Next
                Next
            Next

            If Dati(BDA.Immatricolazione) Is Nothing Then
                Dati(BDA.Modello) = "Dati non trovati"
                Dati(BDA.Cilindrata) = "0"
                Dati(BDA.HP) = "0"
                Dati(BDA.KW) = "0"
            Else
                'nell'ordine 2/1/0
                Dati(2) = Trim(Mid(Dati(1), 23, 10))
                Dati(1) = Trim(Mid(Dati(0), 47, 100))
                Dati(0) = Trim(Mid(Dati(0), 33, 10))

                ''normalizza date
                Dati(0) = Dati(0).Replace(".", "/")
                Dati(2) = Dati(2).Replace(".", "/")
                Dati(59) = Dati(59).Replace(".", "/")
                Dati(61) = Dati(61).Replace(".", "/")
                Dati(63) = Dati(63).Replace(".", "/")
            End If

            For k = 0 To Dati.GetUpperBound(0)
                If Dati(k) Is Nothing Then Dati(k) = ""
            Next

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try

#If DEBUG Then
        For k As Integer = 0 To Dati.GetUpperBound(0)
            Debug.Print(String.Format("{0}: {1}", k, Dati(k)))
        Next
#End If

        Return Dati
    End Function

    Private Sub CancellaTarga(Targa As String)
        Try
            Dim Query As String = String.Format("DELETE FROM Bda WHERE Targa = '{0}'", Targa)
            If Utx.WsCommand.ExecuteNonQueryRecord(Query) = 1 Then
                Globale.Log.Info("la targa {0} è stata cancellata correttamente dall'archivio", {Targa})
            Else
                Globale.Log.Info("cancellazione della targa {0} non riuscita", {Targa})
            End If
        Catch ex As Exception
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Function EsisteTarga(Targa As String) As Boolean
        Try
            Dim Query As String = String.Format("SELECT Count(*) FROM Bda WHERE Targa = '{0}'", Targa)
            Return (Utx.WsCommand.ExecuteScalar(Query).Valore > 0)
        Catch ex As Exception
            e.Messaggio = ex.Message
            e.Errore = True
            Return False
        End Try
    End Function

    Private Function ArchivioTarghe() As DataTable
        Try
            Return Utx.WsCommand.ExecuteNonQuery("SELECT Targa,ProvenienzaTarga FROM Bda").DataTable
        Catch ex As Exception
            e.Messaggio = ex.Message
            e.Errore = True
            Return New DataTable
        End Try
    End Function

    Private Sub SalvaTarga(Targa As String, ByRef DatiTarga As DataRow, ByRef DatiBDA() As String)
        Try
            'se la taga proviene dagli arretrati ed è ancora unipol (082) non la salvo
            If mProvenienzaTarga = "AR" AndAlso StringToNumber(DatiBDA(BDA.CodiceCompagnia)) = 82 Then
                Exit Sub
            End If

            Dim Query As New Utx.NetFunc.StringFormatter("INSERT INTO Bda 
                (BloccoTarga,Aggiornato,ProvenienzaTarga,CodiceFiscaleStorno,Targa,ClasseRca,CartaCircolazione,MotivoEmissioneCarta,
                Immatricolazione,Modello,Cilindrata,HP,KW,Alimentazione,CodiceCompagnia,CodiceFiscale,Effetto,ScadenzaCopertura,
                ScadenzaContratto,Tariffa,ClasseTariffa,DataSinistro,Prodotto,Ramo,Polizza,DataEffetto,DataScadenza,Frazionamento,
                Convenzione,IdStorno,DataStorno,UltimoPremio,IncendioFurto) 
                VALUES (cast(0 as bit),@oggi,@provenienza,@cfstorno,@targa,@classerca,@carta,@motivo,
                    @imma,@modello,@cc,@hp,@kw,@alimentazione,@compagnia,@cf,@bdaeffetto,@copertura,
                    @contratto,@tariffa,@classetariffa,@datasinistro,@prodotto,@ramo,@polizza,@effetto,@scadenza,@fraz,
                    @convenzione,@idstorno,@datastorno,@premio,@if)")

            With Query
                .Parametro("@oggi", Format(Today, "dd/MM/yyyy"), True)
                .Parametro("@provenienza", mProvenienzaTarga, True)
                .Parametro("@cfstorno", DatiTarga(Colonna.CF), True)
                .Parametro("@targa", Targa, True)
                .Parametro("@classerca", DatiTarga(Colonna.Classe), True)
                .Parametro("@carta", DatiBDA(BDA.CartaCircolazione), True)
                .Parametro("@motivo", Left(DatiBDA(BDA.MotivoEmissioneCarta), 40), True)
                .Parametro("@imma", DatiBDA(BDA.Immatricolazione), True)
                .Parametro("@modello", Left(DatiBDA(BDA.Modello), 40), True)
                .Parametro("@cc", StringToNumber(DatiBDA(BDA.Cilindrata)))
                .Parametro("@hp", StringToNumber(DatiBDA(BDA.HP)))
                .Parametro("@kw", StringToNumber(DatiBDA(BDA.KW)))
                .Parametro("@alimentazione", Left(DatiBDA(BDA.Alimentazione), 5), True)
                .Parametro("@compagnia", StringToNumber(DatiBDA(BDA.CodiceCompagnia)))
                .Parametro("@cf", DatiBDA(BDA.CF), True)
                .Parametro("@bdaeffetto", DatiBDA(BDA.Effetto), True)
                .Parametro("@copertura", StringToDate(DatiBDA(BDA.ScadenzaCopertura)), True)
                .Parametro("@contratto", StringToDate(DatiBDA(BDA.ScadenzaContratto)), True)
                .Parametro("@tariffa", Left(DatiBDA(BDA.Tariffa), 15), True)
                .Parametro("@classetariffa", Left(DatiBDA(BDA.ClasseTariffa), 10), True)
                .Parametro("@datasinistro", StringToDate(DatiBDA(BDA.DataSinistro)), True)
                .Parametro("@prodotto", Polizza.Prodotto, True)
                .Parametro("@ramo", StringToNumber(Polizza.Ramo))
                .Parametro("@polizza", StringToNumber(Polizza.Polizza))
                .Parametro("@effetto", StringToDate(Polizza.Effetto), True)
                .Parametro("@scadenza", StringToDate(Polizza.Scadenza), True)
                .Parametro("@fraz", StringToNumber(Polizza.Frazionamento))
                .Parametro("@convenzione", Polizza.Convenzione, True)
                .Parametro("@idstorno", Polizza.IDStorno, True)
                .Parametro("@datastorno", StringToDate(Polizza.DataStorno), True)
                .Parametro("@premio", StringToNumber(Polizza.UltimoPremio))
                .Parametro("@if", StringToNumber(Polizza.IncendioFurto))
            End With
            Globale.Log.Info("inserito {0} record per la targa {1}", {Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata), Targa})

        Catch ex As Exception
            Globale.Log.Info(String.Format("Errore: targa {0}", Targa))
            Globale.Log.Info(ex.Message)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Sub SalvaTarga(Targa As String, ByRef Campi() As String, ByRef Dati() As String)
        Try
            Dim Query As New Utx.NetFunc.StringFormatter("INSERT INTO Bda 
                (BloccoTarga,Aggiornato,ProvenienzaTarga,CodiceFiscaleStorno,Targa,ClasseRca,CartaCircolazione,MotivoEmissioneCarta,
                Immatricolazione,Modello,Cilindrata,HP,KW,Alimentazione,CodiceCompagnia,CodiceFiscale,Effetto,ScadenzaCopertura,
                ScadenzaContratto,Tariffa,ClasseTariffa,DataSinistro,Prodotto,Ramo,Polizza,DataEffetto,DataScadenza,Frazionamento,
                Convenzione,IdStorno,DataStorno,UltimoPremio,IncendioFurto) 
                VALUES (cast(0 as bit),@oggi,@provenienza,@cfstorno,@targa,@classerca,@carta,@motivo,
                    @imma,@modello,@cc,@hp,@kw,@alimentazione,@compagnia,@cf,@bdaeffetto,@copertura,
                    @contratto,@tariffa,@classetariffa,@datasinistro,@prodotto,@ramo,@polizza,@effetto,@scadenza,@fraz,
                    @convenzione,@idstorno,@datastorno,@premio,@if)")

            With Query
                .Parametro("@oggi", Format(Today, "dd/MM/yyyy"))
                .Parametro("@provenienza", mProvenienzaTarga, True)
                If Colonna.CF >= 0 Then
                    .Parametro("@cfstorno", Campi(Colonna.CF), True)
                Else
                    .Parametro("@cfstorno", "")
                End If
                .Parametro("@targa", Targa, True)
                .Parametro("@classerca", Campi(Colonna.Classe), True)
                .Parametro("@carta", Dati(BDA.CartaCircolazione), True)
                .Parametro("@motivo", Left(Dati(BDA.MotivoEmissioneCarta), 40), True)
                .Parametro("@imma", Dati(BDA.Immatricolazione), True)
                .Parametro("@modello", Left(Dati(BDA.Modello), 40), True)
                .Parametro("@cc", StringToNumber(Dati(BDA.Cilindrata)))
                .Parametro("@hp", StringToNumber(Dati(BDA.HP)))
                .Parametro("@kw", StringToNumber(Dati(BDA.KW)))
                .Parametro("@alimentazione", Left(Dati(BDA.Alimentazione), 5), True)
                .Parametro("@compagnia", StringToNumber(Dati(BDA.CodiceCompagnia)))
                .Parametro("@cf", Dati(BDA.CF), True)
                .Parametro("@bdaeffetto", Dati(BDA.Effetto), True)
                .Parametro("@copertura", StringToDate(Dati(BDA.ScadenzaCopertura)), True)
                .Parametro("@contratto", StringToDate(Dati(BDA.ScadenzaContratto)), True)
                .Parametro("@tariffa", Left(Dati(BDA.Tariffa), 15), True)
                .Parametro("@classetariffa", Left(Dati(BDA.ClasseTariffa), 10), True)
                .Parametro("@datasinistro", StringToDate(Dati(BDA.DataSinistro)), True)
                .Parametro("@prodotto", Polizza.Prodotto, True)
                .Parametro("@ramo", StringToNumber(Polizza.Ramo))
                .Parametro("@polizza", StringToNumber(Polizza.Polizza))
                .Parametro("@effetto", StringToDate(Polizza.Effetto), True)
                .Parametro("@scadenza", StringToDate(Polizza.Scadenza), True)
                .Parametro("@fraz", StringToNumber(Polizza.Frazionamento))
                .Parametro("@convenzione", Polizza.Convenzione, True)
                .Parametro("@idstorno", Polizza.IDStorno, True)
                .Parametro("@datastorno", StringToDate(Polizza.DataStorno), True)
                .Parametro("@premio", StringToNumber(Polizza.UltimoPremio))
                .Parametro("@if", StringToNumber(Polizza.IncendioFurto))
            End With
            Globale.Log.Info("inserito {0} record per la targa {1}", {Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata), Targa})

        Catch ex As Exception
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Function TipoTarga(Targa As String, ClasseRca As String) As String
        Try
            'per quando arriva da file
            Select Case ClasseRca
                Case "CICLOMOTORI" : ClasseRca = "030"
                Case "MOTOCICLI" : ClasseRca = "031"
            End Select

            'tolgo gli spazi e rendo maiuscolo
            Targa = Targa.Replace(Space(1), Space(0)).ToUpper
            ClasseRca = ClasseRca.PadLeft(3, "0")

            'G tipo targa nuova
            '1 tipo targa vecchia
            If "001;003;070".IndexOf(ClasseRca, StringComparison.InvariantCultureIgnoreCase) >= 0 Then 'autovetture/autocarri
                If Targa Like "[A-Z][A-Z]###[A-Z][A-Z]" Then
                    TipoTarga = "G"
                Else
                    TipoTarga = "1"
                End If

            ElseIf ClasseRca = "031" Then  'motoveicoli
                If Targa Like "[A-Z][A-Z]#####" Then
                    TipoTarga = "G"
                Else
                    TipoTarga = "1"
                End If

            ElseIf ClasseRca = "030" Then  'ciclomotori
                'da analizzare
                TipoTarga = "G"

            Else 'altro
                TipoTarga = "G"
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            TipoTarga = "G"
        End Try
    End Function

    Private Sub e_CambiaStato() Handles e.CambiaStato
        RaiseEvent StatoImportazione(e)
    End Sub

    Private Sub Essig_Stato(e As ExportEventArgs) Handles Essig.Stato
        RaiseEvent StatoImportazione(e)
    End Sub

    Private Function ConsensoInterrogazione(Campi() As String) As Boolean
        Try
            If (OpzioniBDA.SoloAutovetture = True) AndAlso (Campi(Colonna.Classe) <> "001") Then
                Return False
            Else
                Select Case OpzioniBDA.TipoFile

                    Case TipoFile.STORNATE
                        Return (Left(Campi(Colonna.Ramo), 3) = 30) AndAlso
                               ("A3/A6/AA".Contains(Campi(Colonna.Storno)))

                    Case TipoFile.ARRETRATI
                        Return (Left(Campi(Colonna.Ramo), 3) = 30)

                    Case Else 'consenso sempre a tutto quello che l'utente ha passato nel file
                        Return True
                End Select
            End If

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            Return False
        End Try
    End Function

    Private Function ConsensoInterrogazione(ByRef DatiTarga As DataRow) As Boolean
        Try
            If IsDBNull(DatiTarga(Colonna.Classe)) OrElse
                ((OpzioniBDA.SoloAutovetture = True) AndAlso (DatiTarga(Colonna.Classe) <> "001")) Then
                Return False
            Else
                Select Case OpzioniBDA.TipoFile

                    Case TipoFile.STORNATE
                        Return (Left(DatiTarga(Colonna.Ramo), 3) = 30) AndAlso
                               ("A3/A6/AA".Contains(DatiTarga(Colonna.Storno)))

                    Case TipoFile.ARRETRATI
                        'Globale.Log.AddLog(String.Format("{0}.{1}.{2}={3}", DatiTarga(Colonna.Targa), Left(DatiTarga(Colonna.Ramo), 3), DatiTarga("Effetto titolo"), (Left(DatiTarga(Colonna.Ramo), 3) = 30) AndAlso (DatiTarga("Effetto titolo") <= (Today.AddDays(-10)))))
                        Return (Left(DatiTarga(Colonna.Ramo), 3) = 30) AndAlso
                               (DatiTarga("Effetto titolo") <= (Today.AddDays(-10)))

                    Case Else 'consenso sempre a tutto quello che l'utente ha passato nel file
                        Return True
                End Select
            End If

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            Return False
        End Try
    End Function

    Public Class BDATarga
        Public DatiTrovati As Boolean
        Public TargaInterrogata As String
        Public ClasseVeicolo As String
        Public CartaCircolazione As Date
        Public MotivoEmissioneCarta As String
        Public Immatricolazione As Date
        Public CodiceCompagnia As Integer
        Public Compagnia As String
        Public Effetto As Date
        Public ScadenzaCopertura As Date
        Public ScadenzaContratto As Date
        Public Tariffa As String
        Public ClasseTariffa As String
        Public DataSinistro As Date
        Public CodiceFiscale As String
        Public Aggiornato As Date

        Sub New()
        End Sub

        Sub New(Targa As String, ClasseRca As String, Dati() As String)
            Try
                Aggiornato = Now
                TargaInterrogata = Targa
                ClasseVeicolo = ClasseRca
                If Dati(BDA.Modello).ToLower <> "dati non trovati" Then
                    DatiTrovati = True
                    CartaCircolazione = StringToDate(Dati(BDA.CartaCircolazione))
                    MotivoEmissioneCarta = Left(Dati(BDA.MotivoEmissioneCarta), 40)
                    Immatricolazione = StringToDate(Dati(BDA.Immatricolazione))
                    CodiceCompagnia = StringToNumber(Dati(BDA.CodiceCompagnia))
                    Effetto = StringToDate(Dati(BDA.Effetto))
                    ScadenzaCopertura = StringToDate(Dati(BDA.ScadenzaCopertura))
                    ScadenzaContratto = StringToDate(Dati(BDA.ScadenzaContratto))
                    Tariffa = Left(Dati(BDA.Tariffa), 15)
                    ClasseTariffa = Left(Dati(BDA.ClasseTariffa), 10)
                    If IsDate(Dati(BDA.DataSinistro)) Then
                        DataSinistro = Dati(BDA.DataSinistro)
                    Else
                        DataSinistro = #1/1/1900#
                    End If
                    If (Dati(BDA.CF).Length > 0) Then
                        CodiceFiscale = Dati(BDA.CF)
                    End If
                    Compagnia = CompagniaAnia(CodiceCompagnia)
                End If
                _EsitoBDA = True
            Catch ex As Exception
                Globale.Log.Info(ex.Message)
                _EsitoBDA = False
            End Try
        End Sub

        Private _EsitoBDA As Boolean
        Public Property EsitoBDA() As Boolean
            Get
                Return _EsitoBDA
            End Get
            Set(value As Boolean)
                _EsitoBDA = value
            End Set
        End Property

        Public Shared Function CompagniaAnia(CodiceCompagnia As Integer) As String
            Try
                Return Utx.WsCommand.ExecuteScalar("SELECT Desc_Compagnia FROM CompagniaAnia WHERE Compagnia = " & CodiceCompagnia).Valore
            Catch ex As Exception
                Return "Non definita"
            End Try
        End Function
    End Class
End Class
