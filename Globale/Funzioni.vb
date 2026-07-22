Imports System.IO
Imports System.Data.OleDb
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Office.Interop
Imports System.Windows.Forms
Imports mshtml
Imports System.Data.SqlClient

Namespace Funzioni_OLD_UT

    Public Module Funzioni
        Public Function Guid() As String
            Return "075E27295AFD4173AD794ACD3ACA0984"
        End Function
    End Module
End Namespace

Namespace NetFunc

    Public Module Funzioni

        Public Enum TipoCaratteri
            SoloAlfabetici = 0
            SoloNumerici
            AlfabeticiENumerici
            SoloCaratteri
            SoloCaratteriStampabili
            SoloCaratteriStampabiliSenzaSpazi
        End Enum

        Public Function AltraIstanza(NomeProcesso As String, ProcessoAvviato As Boolean) As Boolean
            'controllo che non vi siano altre istanze già in esecuzione, anche di altri utenti
            'la variabile ProcessoAvviato tiene conto se il controllo avviene dall'interno di un processo già avviato e quindi da bloccare oppure il controllo
            'viene fatto preventivamente prima dell'avvio del processo
            If ProcessoAvviato = True Then
                Return Process.GetProcessesByName(NomeProcesso).Length > 1
            Else
                Return Process.GetProcessesByName(NomeProcesso).Length > 0
            End If
        End Function

        Public Function AltraIstanzaUtente(NomeProcesso As String, ProcessoAvviato As Boolean) As Boolean
            'controllo che non vi siano altre istanze già in esecuzione per l'utente corrente
            'la variabile ProcessoAvviato tiene conto se il controllo avviene dall'interno di un processo già avviato e quindi da bloccare oppure il controllo
            'viene fatto preventivamente prima dell'avvio del processo

            Dim MaxNumeroProcessi As Integer = 0
            If ProcessoAvviato = True Then
                'se il processo è avviato i processi devono essere più di uno perché trova sempre anche se stesso
                MaxNumeroProcessi = 1
            End If

            'id della sessione windows in cui il processo è in esecuzione: serve per più sessioni RDP su server condiviso
            'per singole sessioni su un pc il valore è sempre 1
            Dim currentSessionID As Integer = Process.GetCurrentProcess.SessionId
            Dim Processi() As Process = Process.GetProcessesByName(NomeProcesso)
            Dim Ricorrenze As Integer = 0
            For Each p As Process In Processi
                If p.SessionId = currentSessionID Then
                    Ricorrenze += 1
                End If
            Next

            Return Ricorrenze > MaxNumeroProcessi
            'con uso di linq
            'Return Process.GetProcessesByName(ProcessName).Where(Function(p) p.SessionId = currentSessionID).Count > 1
        End Function

        Public Function ResumeWindow(NomeFinestra As String) As Boolean

            Dim Handle As Long = Utx.API.FindWindow(vbNullString, NomeFinestra)

            If Handle > 0 Then 'è già avviato
                Utx.API.ShowWindow(Handle, Utx.API.SW.SW_RESTORE)
                Utx.NetFunc.FinestraOnTop(Handle, True)
                Utx.NetFunc.FinestraOnTop(Handle, False)
                Return True
            Else
                Return False
            End If
        End Function

        Public Function GetEnvironmentVar(VarName As String) As String
            If Environment.GetEnvironmentVariable(VarName) = Nothing Then
                Return ""
            Else
                Return Environment.GetEnvironmentVariable(VarName)
            End If
        End Function

        Friend Function ImpostaCredenziali(User As String,
                                           Pw As String,
                                           IdAmbiente As Utx.Enumerazioni.TipoAmbiente) As System.Net.NetworkCredential

            If IdAmbiente = Utx.Enumerazioni.TipoAmbiente.DIR Then
                Return System.Net.CredentialCache.DefaultCredentials
            Else
                Return New System.Net.NetworkCredential(User, Pw, "uniage")
            End If
        End Function

        Public Function FileToMD5(FilePath As String) As String
            Try
                If Not File.Exists(FilePath) Then Return "-ERR"

                Dim md5 As New MD5CryptoServiceProvider
                Dim hash As Byte()
                Dim buffer As New StringBuilder

                Using f As New FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
                    hash = md5.ComputeHash(f)
                    f.Close()
                End Using

                For Each hashByte As Byte In hash
                    buffer.Append(String.Format("{0:X2}", hashByte))
                Next

                Return buffer.ToString()

            Catch ex As Exception
                Return "-ERR"
            End Try
        End Function

        Public Function StringToMD5(Stringa As String) As String
            Try
                'istanza dell'oggetto
                Dim md5 As New MD5CryptoServiceProvider()

                'array di byte da passare all'oggetto md
                'converto la stringa passata in modo da prelevare i singoli byte che verranno
                'passati alla funzione per calcolare l'md5
                Dim Stringa_inByte() = System.Text.Encoding.UTF8.GetBytes(Stringa)

                'calcolo l'mdd5 (restituisce un array di byte)
                Dim hash As Byte() = md5.ComputeHash(Stringa_inByte)

                Dim buffer As New StringBuilder

                For Each hashByte As Byte In hash
                    buffer.Append(String.Format("{0:X2}", hashByte))
                Next

                Return buffer.ToString

            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        Public Function FileToSHA256(FilePath As String) As String
            Try
                If Not File.Exists(FilePath) Then Return "-ERR"

                Dim SHA256 As New SHA256Managed
                Dim hash As Byte()
                Dim buffer As New StringBuilder

                Using f As New FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
                    hash = SHA256.ComputeHash(f)
                    f.Close()
                End Using

                For Each hashByte As Byte In hash
                    buffer.Append(String.Format("{0:X2}", hashByte))
                Next

                Return buffer.ToString()

            Catch ex As Exception
                Return "-ERR"
            End Try
        End Function

        Public Function StringToSHA256(Stringa As String) As String
            Try
                'istanza dell'oggetto
                Dim SHA256 As New SHA256Managed

                Dim Stringa_inByte() = System.Text.Encoding.UTF8.GetBytes(Stringa)

                'calcolo sha256 (restituisce un array di byte)
                Dim hash As Byte() = SHA256.ComputeHash(Stringa_inByte)

                Dim buffer As New StringBuilder

                For Each hashByte As Byte In hash
                    buffer.Append(String.Format("{0:X2}", hashByte))
                Next

                Return buffer.ToString.ToLower

            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        Public Sub FinestraOnTop(HandleFinestra As Long,
                                 TopMost As Boolean)

            On Error Resume Next

            If TopMost = True Then
                'porta la finestra in primo piano
                Utx.API.SetWindowPos(HandleFinestra,
                                    Utx.API.HWND_TOPMOST,
                                    0, 0, 0, 0,
                                    Utx.API.SWP.SWP_NOMOVE Or Utx.API.SWP.SWP_NOSIZE)
            Else
                'sblocca l'opzione sempre in primo piano
                Utx.API.SetWindowPos(HandleFinestra,
                                    HWND_NOTOPMOST,
                                    0, 0, 0, 0,
                                    Utx.API.SWP.SWP_NOMOVE Or Utx.API.SWP.SWP_NOSIZE)
            End If

        End Sub

        'Public Function Abilitazione(CostanteAbilitazione As Integer) As Boolean
        '    Return (Val(GetEnvironmentVar("ABILITAZIONE_CHECK")) And CostanteAbilitazione) > 0
        'End Function

        Public Sub DoppioBuffer(ByRef Control As Object)
            Control.GetType.InvokeMember("DoubleBuffered",
                                     Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, Control,
                                     New Object() {True})
        End Sub

        Public Sub Esporta2Excel(DataGrid() As Object,
                                 NomeFoglio() As String,
                                 NomeFile As String,
                                 ColoreSfondoProgressBar As Drawing.Color)
            Try
                Dim excelApp As New Excel.Application()
                Dim excelBook As Excel.Workbook = excelApp.Workbooks.Add

                Try
                    Dim NumFoglio As Int16 = 1
                    For Each ws As Excel.Worksheet In excelBook.Worksheets
                        ws.Name = "xxx" + NumFoglio.ToString 'da cancellare dopo altrimenti va in errore
                        NumFoglio += NumFoglio
                    Next
                Catch ex As Exception
                End Try

                Dim StileTitoli As Excel.Style
                StileTitoli = excelBook.Styles.Add("STitoli")
                With StileTitoli
                    .WrapText = True
                    .Font.Bold = True
                    .Orientation = 90
                    .VerticalAlignment = Excel.XlVAlign.xlVAlignBottom
                End With

                Try
                    Dim Foglio As Int16 = 1
                    For n As Integer = 0 To DataGrid.GetUpperBound(0)

                        Dim pb As New FormProgessBar
                        With pb
                            .StartPosition = FormStartPosition.CenterScreen
                            .TopMost = True
                            .Coloresforndo = ColoreSfondoProgressBar

                            With .ProgressBar1
                                .Visible = True
                                .Minimum = 0
                                .Maximum = DataGrid(n).Rows.Count + 1 '+1 per intestazione
                                .Value = .Minimum
                            End With

                            .Show()
                        End With

                        Dim ws As Excel.Worksheet = excelBook.Worksheets.Add(, excelBook.ActiveSheet)
                        With ws
                            .Name = Left(NomeFoglio(n), 30) 'max dim nome foglio 31 caratteri

                            'inserisce riga di intestazione
                            'stile intestazione
                            .Range("1:1").Style = StileTitoli

                            Dim i As Int16 = 1 'contatore di riga
                            Dim k As Int16 = 1 'contatore di colonna 
                            Dim IdCella As String = "", IdColonna As String, CarColonna As String

                            For Each col As DataGridViewColumn In DataGrid(n).Columns
                                If col.Visible Then
                                    CarColonna = ColonnaStileExcel(k)
                                    IdColonna = CarColonna + "2:" + CarColonna + "100"
                                    IdCella = CarColonna + i.ToString

                                    .Range(IdCella).Value = col.HeaderText

                                    'allineamento
                                    With .Range(IdColonna)
                                        Select Case col.DefaultCellStyle.Alignment
                                            Case DataGridViewContentAlignment.MiddleLeft
                                                .HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                                            Case DataGridViewContentAlignment.MiddleCenter
                                                .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                            Case DataGridViewContentAlignment.MiddleRight
                                                .HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                        End Select
                                    End With

                                    k += 1
                                End If
                            Next

                            'inserisco i dati iterando per righe (i) e colonne (k)
                            'il contatore parte dalla seconda riga, dopo le intestazioni di colonna
                            i = 2
                            For Each r As DataGridViewRow In DataGrid(n).Rows

                                k = 1

                                For Each c As DataGridViewCell In r.Cells
                                    If c.Visible Then
                                        IdCella = ColonnaStileExcel(k) + i.ToString

                                        .Range(IdCella).Value = c.FormattedValue
                                        'colonna successiva
                                        k += 1
                                    End If
                                Next

                                pb.ProgressValue = i

                                'riga successiva
                                i += 1

                                Application.DoEvents()

                                If pb.Annulla = True Then
                                    pb.Close()
                                    excelBook.Saved = True
                                    Exit Try
                                End If
                            Next

                            'autosize delle colonne
                            If Not String.IsNullOrEmpty(IdCella) Then .Columns.Range("A1", IdCella).EntireColumn.AutoFit()

                            pb.Close()
                        End With

                        Foglio += Foglio
                    Next

                    Try
                        For Each ws As Excel.Worksheet In excelBook.Worksheets
                            If ws.Name.Substring(0, 3) = "xxx" Then ws.Delete()
                        Next
                    Catch ex As Exception
                    End Try

                    'seleziona il primo foglio come attivo
                    Dim PrimoFoglio As Excel.Worksheet = excelBook.Worksheets.Item(1)
                    PrimoFoglio.Select()

                    'salvo il file
                    Dim cd As New SaveFileDialog
                    With cd
                        .AddExtension = True
                        .DefaultExt = "xls"
                        .OverwritePrompt = False
                        .Filter = "*.xls|*.xls"
                        .FileName = NomeFile.Trim + "." + .DefaultExt

                        If .ShowDialog() = DialogResult.OK Then
                            excelBook.SaveAs(cd.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel7)
                            If excelBook.Saved Then
                                Call New Utx.NotificaRapida().Visualizza("Esportazione completata")
                            End If
                        Else
                            'senza questa riga c'è la richiesta automatica di salvataggio
                            excelBook.Saved = True
                        End If
                    End With

                Catch ex As Exception
                    'errore 1004 quando il file esiste e si risponde NO alla sostituzione
                    If Err.Number <> 1004 Then
                        Globale.Log.Errore(ex)
                    End If

                    excelBook.Saved = True
                Finally
                    excelBook.Close()
                    excelBook = Nothing
                    excelApp = Nothing
                End Try

            Catch ex As Exception
#If DEBUG Then
                Globale.Log.Errore(ex.Message)
#Else
                Globale.Log.Info(ex.Message)
#End If
            End Try

        End Sub

        Public Function ColonnaStileExcel(ColumnNumber As Integer) As String
            If ColumnNumber > 26 Then
                'colonne da AA in poi
                ' 1st character:  Subtract 1 to map the characters to 0-25,
                '                 but you don't have to remap back to 1-26
                '                 after the 'Int' operation since columns
                '                 1-26 have no prefix letter

                ' 2nd character:  Subtract 1 to map the characters to 0-25,
                '                 but then must remap back to 1-26 after
                '                 the 'Mod' operation by adding 1 back in
                '                 (included in the '65')
                ColonnaStileExcel = Chr(Int((ColumnNumber - 1) / 26) + 64) & Chr(((ColumnNumber - 1) Mod 26) + 65)
            Else
                'colonne da A a Z
                ColonnaStileExcel = Chr(ColumnNumber + 64)
            End If
        End Function

        Public Sub Esporta2Csv(Dati() As DataGridView,
                               Descrizione() As String,
                               NomeFile As String,
                               ColoreSfondoProgressBar As Drawing.Color)
            Try
                Dim pb As New FormProgessBar
                Dim sb As New StringBuilder

                For k As Integer = 0 To Dati.Length - 1
                    Dim dgv As DataGridView = Dati(k)
                    With pb
                        .StartPosition = FormStartPosition.CenterScreen
                        .TopMost = True
                        .Coloresforndo = ColoreSfondoProgressBar

                        With .ProgressBar1
                            .Visible = True
                            .Minimum = 0
                            .Maximum = dgv.Rows.Count + 1
                            .Value = .Minimum
                        End With

                        .Show()
                    End With

                    Dim Riga As String = ""

                    'titolo
                    sb.AppendLine(Descrizione(k))
                    'intestazione colonne: i dati sono nell'ordine fisico e non di displayindex
                    For Each col As DataGridViewColumn In dgv.Columns
                        If col.Visible = True Then
                            Riga += col.HeaderText & ";"
                        End If
                    Next
                    sb.AppendLine(Riga) 'appendo testata

                    'inserisco i dati iterando per righe (i) e colonne (k)
                    'il contatore parte dalla seconda riga, dopo le intestazioni di colonna
                    Dim i As Integer = 2
                    For Each r As DataGridViewRow In dgv.Rows

                        Riga = ""
                        For Each c As DataGridViewCell In r.Cells
                            If c.Visible = True Then
                                Riga += Utx.FunzioniDb.NullToString(c.FormattedValue) & ";"
                            End If
                        Next
                        sb.AppendLine(Riga)

                        pb.ProgressValue = i

                        'riga successiva
                        i += 1

                        Application.DoEvents()

                        If pb.Annulla = True Then
                            pb.Close()
                            Exit Try
                        End If
                    Next
                    sb.AppendLine()
                Next

                pb.Close()

                'salvo il file
                Dim cd As New SaveFileDialog
                With cd
                    .AddExtension = True
                    .DefaultExt = "csv"
                    .OverwritePrompt = False
                    .Filter = "*.csv|*.csv"
                    .FileName = NomeFile.Trim + "." + .DefaultExt

                    If .ShowDialog() = DialogResult.OK Then

                        If File.Exists(.FileName) Then
                            If MsgBox("Il file esiste già. Volete sovrascriverlo?",
                                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.No Then
                                Exit Try
                            End If
                        End If
                        File.Delete(.FileName)
                        File.AppendAllText(.FileName, sb.ToString)

                        Call New Utx.NotificaRapida().Visualizza("Esportazione completata.")
                    End If
                End With

            Catch ex As Exception
                Globale.Log.Errore(ex)
            End Try
        End Sub

        Public Sub Esporta2Csv(Dgv As DataGridView,
                               NomeFile As String,
                               ColoreSfondoProgressBar As Drawing.Color)
            Try
                Dim pb As New FormProgessBar
                With pb
                    .StartPosition = FormStartPosition.CenterScreen
                    .TopMost = True
                    .Coloresforndo = ColoreSfondoProgressBar

                    With .ProgressBar1
                        .Visible = True
                        .Minimum = 0
                        .Maximum = Dgv.Rows.Count + 1
                        .Value = .Minimum
                    End With

                    .Show()
                End With

                Dim sb As New StringBuilder
                Dim Riga As String = ""

                '++i dati sono nell'ordine fisico e non di displayindex
                For Each col As DataGridViewColumn In Dgv.Columns
                    If col.Visible = True Then
                        Riga += col.HeaderText & ";"
                    End If
                Next
                sb.AppendLine(Riga) 'appendo testata

                'inserisco i dati iterando per righe (i) e colonne (k)
                'il contatore parte dalla seconda riga, dopo le intestazioni di colonna
                Dim i As Integer = 2
                For Each r As DataGridViewRow In Dgv.Rows

                    Riga = ""
                    For Each c As DataGridViewCell In r.Cells
                        If c.Visible = True Then
                            Riga += Utx.FunzioniDb.NullToString(c.Value) & ";"
                        End If
                    Next
                    sb.AppendLine(Riga)

                    pb.ProgressValue = i

                    'riga successiva
                    i += 1

                    Application.DoEvents()

                    If pb.Annulla = True Then
                        pb.Close()
                        Exit Try
                    End If
                Next

                pb.Close()

                'salvo il file
                Dim cd As New SaveFileDialog
                With cd
                    .InitialDirectory = Utx.Globale.UtenteCorrente.Desktop
                    .AddExtension = True
                    .DefaultExt = "csv"
                    .OverwritePrompt = False
                    .Filter = "*.csv|*.csv"
                    .FileName = NomeFile.Trim + "." + .DefaultExt

                    If .ShowDialog() = DialogResult.OK Then

                        If File.Exists(.FileName) Then
                            If MsgBox("Il file esiste già. Volete sovrascriverlo?",
                                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.No Then
                                Exit Try
                            End If
                        End If
                        File.Delete(.FileName)
                        File.AppendAllText(.FileName, sb.ToString)

                        Call New Utx.NotificaRapida().Visualizza("Esportazione completata.")
                    End If
                End With

            Catch ex As Exception
                Globale.Log.Errore(ex)
            End Try
        End Sub

        Public Sub DataTable2Csv(ByRef dt As DataTable, NomeFile As String, Optional Accoda As Boolean = False)
            'sub usata prevalentemente per debug
            Try
                If Accoda = False AndAlso File.Exists(NomeFile) Then
                    If MsgBox("Il file esiste già. Sovrascrivere?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
                        File.Delete(NomeFile)
                    End If
                End If

                Dim Intestazione As Boolean = (File.Exists(NomeFile) = False)

                Using sw As New StreamWriter(NomeFile, Accoda)
                    Dim tmp As String = ""

                    'riga con nome dei campi
                    If Intestazione = True Then
                        For k As Integer = 0 To dt.Columns.Count - 1
                            tmp += dt.Columns(k).ColumnName + ";"
                        Next
                    End If

                    sw.WriteLine(tmp)

                    'dati
                    For Each r As DataRow In dt.Rows
                        tmp = ""

                        'creo la riga dati
                        For col As Integer = 0 To dt.Columns.Count - 1
                            tmp += r(col).ToString + ";"
                        Next

                        'la scrivo nel file
                        sw.WriteLine(tmp)
                    Next
                End Using

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Sub DataTable2Log(ByRef dt As DataTable, Log As ApplicationLog, Intestazione As Boolean)
            'sub usata prevalentemente per debug
            Try
                'riga con nome dei campi
                Dim tmp As String = ""
                If Intestazione = True Then
                    For k As Integer = 0 To dt.Columns.Count - 1
                        tmp += dt.Columns(k).ColumnName + ";"
                    Next
                End If

                Log.Info(tmp)

                'dati
                For Each r As DataRow In dt.Rows
                    tmp = ""

                    'creo la riga dati
                    For col As Integer = 0 To dt.Columns.Count - 1
                        tmp += r(col).ToString + ";"
                    Next

                    'la scrivo nel file
                    Log.Info(tmp)
                Next

            Catch ex As Exception
                Log.Errore(ex)
            End Try
        End Sub

        Public Function ColorToHex(Colore As Drawing.Color) As String
            Return String.Format("#{0:X2}{1:X2}{2:X2}", Colore.R, Colore.G, Colore.B)
        End Function

        Public Function InIntervallo(Valore As Object,
                                     Minimo As Object,
                                     Massimo As Object) As Boolean

            Try
                Select Case Valore

                    Case Minimo To Massimo
                        Return True

                    Case Else
                        Return False
                End Select

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return False
            End Try
        End Function

        Public Function [In](Of T)(value As Object, Insieme As Collection) As Boolean
            Return Insieme.Contains(value)
        End Function

        ''' <summary>
        ''' svuota la cartella di tutti i file e le sotto-cartelle ma non la elimina
        ''' </summary>
        ''' <param name="Cartella"></param>
        ''' <remarks></remarks>
        Public Sub SvuotaCartella(Cartella As String)
            Try
                If Directory.Exists(Cartella) Then
                    For Each c As String In Directory.GetDirectories(Cartella, "*.*", SearchOption.AllDirectories)

                        For Each f As String In Directory.GetFiles(c, "*.*")
                            File.Delete(f)
                        Next
                        Directory.Delete(c)
                    Next
                    'ora la cartella root
                    For Each f As String In Directory.GetFiles(Cartella, "*.*")
                        File.Delete(f)
                    Next
                End If

            Catch ex As Exception
                Globale.Log.Errore(ex)
            End Try
        End Sub

        ''' <summary>
        ''' Cancella la cartella anche se piena
        ''' </summary>
        ''' <param name="Cartella"></param>
        ''' <remarks></remarks>
        Public Sub CancellaCartella(Cartella As String)
            Try
                SvuotaCartella(Cartella)
                Directory.Delete(Cartella)

            Catch ex As Exception
                Globale.Log.Errore(ex)
            End Try
        End Sub

        Public Function ExGruppo(CodiceAgenzia As Integer) As Utx.Enumerazioni.ExGruppo
            Select Case CodiceAgenzia
                Case Is < 10000
                    Return Enumerazioni.ExGruppo.EX_UNIPOL
                Case 10000 To 39999
                    Return Enumerazioni.ExGruppo.EX_AURORA
                Case 40000 To 69999
                    Return Enumerazioni.ExGruppo.EX_FONSAI
                Case Else
                    Return Enumerazioni.ExGruppo.EX_NAVALE
            End Select
        End Function

        Public Function ValidEmail(Indirizzo As String,
                                   ValidaVuota As Boolean,
                                   VisualizzaMessaggio As Boolean) As Boolean

            ValidEmail = False

            'controllo validità e-mail
            Try
                Indirizzo = Indirizzo.Trim

                'controllo se stringa vuota
                If (String.IsNullOrEmpty(Indirizzo)) AndAlso (ValidaVuota = False) Then Return False

                'posizione del carattere '@'
                Dim i As Integer = Indirizzo.IndexOf("@")

                'almeno 1 carattere PRIMA di '@'
                If i <= 1 Then Return False

                'testo che precede '@'
                Dim Prima As String = Indirizzo.Substring(0, i)
                'testo che segue '@'
                Dim Dopo As String = Indirizzo.Substring(i + 1)

                'posizione dell'ultimo carattere '.'
                i = Dopo.LastIndexOf(".")

                'punto necessario
                If i < 0 Then Return False

                'e almeno 1 carattere DOPO '@' e PRIMA dell'ultimo '.'
                If Dopo.Substring(0, i).Length < 1 Then Return False

                'suffisso finale è lungo da 2 a 4 caratteri
                If Dopo.Substring(i + 1).Length < 2 OrElse Dopo.Substring(i + 1).Length > 4 Then Return False

                'Controlla i caratteri escluso '@' i caratteri leciti sono [a-zA-Z0-9_.-']
                Dim exp As New System.Text.RegularExpressions.Regex("[a-zA-Z0-9_.-]")

                Dim Tutto As String = Prima + Dopo

                For k As Integer = 0 To Tutto.Length - 1
                    'indirizzo non valido se un carattere NON viene trovato fra i leciti
                    If Not exp.IsMatch(Tutto.Substring(k, 1)) Then Return False
                Next

                ValidEmail = True

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return False
            Finally
                If ValidEmail = False AndAlso VisualizzaMessaggio = True Then
                    MsgBox(String.Format("L'indirizzo e-mail '{0}' non è un indirizzo valido.",
                                         Indirizzo), MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                End If
            End Try
        End Function

        Public Function ValidIP4(IP As String) As Boolean
            Dim Temp() As String = IP.Split(".")

            If Temp.GetUpperBound(0) <> 3 Then Return False

            For k As Integer = 0 To 3
                If IsNumeric(Temp(k)) = False Then Return False
                If Temp(k) < 0 Or Temp(k) > 255 Then Return False
            Next

            Return True
        End Function

        Public Sub SincronizzaFolder(FRootOrigine As String,
                                     FRootDest As String,
                                     ByRef Copiati As Double,
                                     Optional CancellaDirVuote As Boolean = False)

            Try
                'controllo e copia di tutti i documenti
                For Each Doc As String In Directory.GetFiles(FRootOrigine)
                    Dim FileDest As String = Path.Combine(FRootDest, Path.GetFileName(Doc))

                    'se il file non esiste già nella copia
                    If File.Exists(FileDest) = False Then
                        File.Copy(Doc, FileDest, True) 'il true per sicurezza (no error)
                        'aggiorna il totale file copiati
                        Copiati = Copiati + 1
                    End If
                Next

                Application.DoEvents() 'importante per dare spazio al sistema operativo

                'crea le subcartelle e effettua la chiamata ricorsiva
                For Each d As String In Directory.GetDirectories(FRootOrigine)
                    'crea la subcartella nella cartella di destinazione
                    Dim CartellaDest As String = Path.Combine(FRootDest, Path.GetDirectoryName(d))
                    Directory.CreateDirectory(CartellaDest)

                    'chiamata ricorsiva per copiare i file nelle sotto-cartelle
                    SincronizzaFolder(d, CartellaDest, Copiati)

                    If CancellaDirVuote = True Then
                        'se non ci sono subfolder e file cancella il folder
                        If Directory.GetDirectories(CartellaDest).Length = 0 And Directory.GetFiles(CartellaDest).Length = 0 Then
                            Directory.Delete(CartellaDest)
                        End If
                    End If
                Next

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try
        End Sub

        Public Function EstraiCaratteri(Stringa As String,
                                        Optional SetDiCaratteri As TipoCaratteri = TipoCaratteri.SoloAlfabetici) As String
            Try
                Dim i As Long, t As String, s As String

                s = Stringa

                Select Case SetDiCaratteri
                    Case TipoCaratteri.AlfabeticiENumerici
                        'conserva solo i caratteri alfabetici A-Z e i caratteri numerici; esclude tutto il resto
                        For i = 1 To Len(s)
                            t = Mid$(s, i, 1)
                            If t Like "*[!0-9A-Za-z]*" Then Stringa = Replace(Stringa, t, "")
                        Next

                    Case TipoCaratteri.SoloAlfabetici
                        'conserva solo i caratteri alfabetici A-Z, elimina anche gli spazi iniziale e finale
                        Stringa = Trim$(Stringa)
                        For i = 1 To Len(s)
                            t = Mid$(s, i, 1)
                            If t Like "*[!A-Za-z]*" Then Stringa = Replace(Stringa, t, "")
                        Next

                    Case TipoCaratteri.SoloCaratteri
                        'elimina i caratteri numerici e conserva il resto, stampabile o no
                        For i = 0 To 9
                            Stringa = Replace(Stringa, i.ToString, "")
                        Next

                    Case TipoCaratteri.SoloNumerici
                        'conserva solo i caratteri numerici; elimina tutti gli altri caratteri (anche gli spazi iniziale e finale)
                        Stringa = Trim$(Stringa)
                        For i = 1 To Len(s)
                            t = Mid$(s, i, 1)
                            If t Like "*[!0-9]*" Then Stringa = Replace(Stringa, t, "")
                        Next

                    Case TipoCaratteri.SoloCaratteriStampabili
                        For i = 1 To Len(s)
                            t = Mid$(s, i, 1)
                            If Asc(t) < 32 Or Asc(t) = 127 Or AscW(t) < 32 Or AscW(t) = 127 Or AscW(t) > 255 Then Stringa = Replace(Stringa, t, "")
                        Next

                    Case TipoCaratteri.SoloCaratteriStampabiliSenzaSpazi
                        Stringa = Trim$(Stringa)
                        For i = 1 To Len(s)
                            t = Mid$(s, i, 1)
                            If Asc(t) < 33 Or Asc(t) = 127 Or AscW(t) < 33 Or AscW(t) = 127 Or AscW(t) > 255 Then Stringa = Replace(Stringa, t, "")
                        Next
                End Select

                Return Stringa

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
                Return ""
            End Try
        End Function

        Public Function EstraiCaratteri(Stringa As String, SetDiCaratteri As String) As String
            Try
                Dim Estratto As String = ""

                For Each car As Char In Stringa
                    If SetDiCaratteri.IndexOf(car, comparisonType:=StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                        Estratto &= car
                    End If
                Next
                Return Estratto
            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
                Return ""
            End Try
        End Function

        Public Function TokenAccessoCasa() As String
            Return StringToMD5($"UT{Today:ddMMyyyy}")
        End Function
        Public Function TokenAccessoCasa2() As String
            Return StringToMD5($"UB{Today:ddMMyyyy}")
        End Function

        Public Sub CryptoSerialize(ByRef obj As Object, FileDestinazione As String, key As String)
            Try
                ' 1. create backing storage stream. In your case a file stream
                Using innerStream As Stream = File.Create(FileDestinazione)
                    ' 2. create a CryptoStream in write mode
                    Dim cryptic As New DESCryptoServiceProvider() With {.Key = ASCIIEncoding.ASCII.GetBytes(key), .IV = .Key}

                    Using cryptoStream As Stream = New CryptoStream(innerStream, cryptic.CreateEncryptor, CryptoStreamMode.Write)
                        ' 3. write to the cryptoStream
                        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                        formatter.Serialize(cryptoStream, obj)
                    End Using
                End Using

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try
        End Sub
        'Public Function CryptoAES(ByRef obj As Object, key As String) As Byte()
        '    Try
        '        ' 2. create a CryptoStream in write mode
        '        Dim cryptic As New AesCryptoServiceProvider() With {.Key = ASCIIEncoding.ASCII.GetBytes(key), .IV = .Key}

        '        ' Create the streams used for encryption.
        '        Dim msEncrypt As New MemoryStream()
        '        Using csEncrypt As New CryptoStream(msEncrypt, cryptic.CreateEncryptor, CryptoStreamMode.Write)
        '            Using swEncrypt As New StreamWriter(csEncrypt)
        '                'Write all data to the stream.
        '                swEncrypt.Write(obj)
        '            End Using
        '            Return msEncrypt.ToArray()
        '        End Using

        '    Catch ex As Exception
        '        Utx.Globale.Log.Errore(ex)
        '    End Try
        'End Function

        Public Sub Serialize(ByRef obj As Object, FileDestinazione As String)
            Try
                File.Delete(FileDestinazione)
                Using fs As New FileStream(FileDestinazione, FileMode.CreateNew)
                    Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    formatter.Serialize(fs, obj)
                End Using
            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try
        End Sub

        Public Function CryptoDeserialize(Of T)(FileOrigine As String, key As String) As Object
            Try
                ' 1. create backing storage stream. In your case a file stream
                Using innerStream As Stream = File.Open(FileOrigine, FileMode.Open)
                    ' 2. create a CryptoStream in read mode
                    Dim cryptic As New DESCryptoServiceProvider()
                    cryptic.Key = ASCIIEncoding.ASCII.GetBytes(key)
                    cryptic.IV = cryptic.Key

                    Using cryptoStream As Stream = New CryptoStream(innerStream, cryptic.CreateDecryptor, CryptoStreamMode.Read)
                        ' 3. read from the cryptoStream
                        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                        Return DirectCast(formatter.Deserialize(cryptoStream), T)
                    End Using
                End Using

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
                Return Nothing
            End Try
        End Function

        Public Function Deserialize(Of T)(FileOrigine As String) As Object
            Try
                ' Open the file containing the data that you want to deserialize.
                Using fs As New FileStream(FileOrigine, FileMode.Open)
                    Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    Return DirectCast(formatter.Deserialize(fs), T)
                End Using
            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
                Return Nothing
            End Try
        End Function

        Public Sub DataGridViewColumnsNoSort(ByRef dgv As DataGridView)
            For Each c As DataGridViewColumn In dgv.Columns
                c.SortMode = DataGridViewColumnSortMode.Programmatic
            Next
        End Sub

        Public Function PrefissiCellulari() As String
            Return "'320','323','327','328','329','380','383','388','389'," +
                   "'330','331','333','334','335','336','337','338','339','360','363','366','368'," +
                   "'340','342','345','346','347','348','349'," +
                   "'370','371','373','377'," +
                   "'390','391','392','393'"
        End Function

        ''' <summary>
        ''' Primo carattere maiuscolo
        ''' </summary>
        ''' <param name="str"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ToTitleCase(str As String) As String
            Dim myTI As Globalization.TextInfo = New Globalization.CultureInfo("it-IT", False).TextInfo
            Return myTI.ToTitleCase(str)
        End Function

        Public Class Crc32
            Shared table As UInteger()

            Shared Sub New()
                Dim poly As UInteger = &HEDB88320UI
                table = New UInteger(255) {}
                Dim temp As UInteger = 0
                For i As UInteger = 0 To table.Length - 1
                    temp = i
                    For j As Integer = 8 To 1 Step -1
                        If (temp And 1) = 1 Then
                            temp = CUInt((temp >> 1) Xor poly)
                        Else
                            temp >>= 1
                        End If
                    Next
                    table(i) = temp
                Next
            End Sub

            Public Shared Function FileChecksum(FilePath As String) As String
                Try
                    Dim bytes As Byte() = File.ReadAllBytes(FilePath)
                    Dim crc As UInteger = &HFFFFFFFFUI
                    For i As Integer = 0 To bytes.Length - 1
                        Dim index As Byte = CByte(((crc) And &HFF) Xor bytes(i))
                        crc = CUInt((crc >> 8) Xor table(index))
                    Next
                    Return (Not crc).ToString("X2")
                Catch ex As Exception
                    Utx.Globale.Log.Errore(ex)
                    Return "-ERR"
                End Try
            End Function

            Public Shared Function StringChecksum(Stringa As String) As String
                Try
                    Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(Stringa)
                    Dim crc As UInteger = &HFFFFFFFFUI
                    For i As Integer = 0 To bytes.Length - 1
                        Dim index As Byte = CByte(((crc) And &HFF) Xor bytes(i))
                        crc = CUInt((crc >> 8) Xor table(index))
                    Next
                    Return (Not crc).ToString("X2")
                Catch ex As Exception
                    Utx.Globale.Log.Errore(ex)
                    Return "-ERR"
                End Try
            End Function
        End Class

        Public Function VersioneModulo(Modulo As String) As String
            Try
                Return FileVersionInfo.GetVersionInfo(Path.Combine(Utx.Globale.Paths.CartellaApp, Modulo)).ProductVersion
            Catch ex As Exception
                Return ""
            End Try
        End Function

        Public Function NumeroPari(Numero As Integer) As Boolean
            Return (Numero Mod 2 = 0)
        End Function

        Public Function GuidUtente() As String
            Return String.Format("{0}-{1}-{2}",
                                 Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                 Utx.Globale.ProfiloEnteGestore.CodiceSede,
                                 Utx.Globale.UtenteCorrente.UniageUser)
        End Function

        Public Sub BloccaOrdinamento(dgv)
            If dgv IsNot Nothing Then
                For Each col As DataGridViewColumn In dgv.Columns
                    col.SortMode = DataGridViewColumnSortMode.Programmatic
                Next
            End If
        End Sub

        Public Function IsCellulare(ByRef telefono As String) As Boolean
            If Not String.IsNullOrEmpty(telefono) Then
                If telefono.StartsWith("+393") Or telefono.StartsWith("3") Then
                    Return True
                End If
            End If
            Return False
        End Function

        Public Function DataModulo(Versione As String) As Date
            Try
                Versione = Versione.Substring(2)
                If IsDate(Versione) Then
                    Return CDate(Versione)
                Else
                    Return #1/1/2000#
                End If
            Catch ex As Exception
                Return #1/1/2000#
            End Try
        End Function

        Public Class StringFormatter
            Private _Stringa As String
            Public ReadOnly Parametri As Dictionary(Of String, Object)

            Public Sub New(Template As String)
                _Stringa = Template
                Parametri = New Dictionary(Of String, Object)()
            End Sub

            Public Sub New()
                _Stringa = ""
                Parametri = New Dictionary(Of String, Object)()
            End Sub

            Private _Template As String
            Public Property Template() As String
                Get
                    Return _Stringa
                End Get
                Set(ByVal value As String)
                    _Stringa = value
                End Set
            End Property

            Public Sub AddToTemplate(Stringa As String)
                _Stringa &= Stringa
            End Sub

            Public Sub Parametro(key As String, value As Object, Optional ToString As Boolean = False)
                If value Is Nothing Then value = ""
                'cancello il parametro se già c'è per sostituirlo
                Parametri.Remove(key)
                'aggiungo il nuovo valore
                'le date vanno inserite come testo formattato
                If ToString = False Then
                    Parametri.Add(key, value)
                Else
                    Parametri.Add(key, Utx.FunzioniDb.TO_STRING(value.ToString))
                End If
            End Sub

            Public Function StringaFormattata() As String
                StringaFormattata = _Stringa
                Try
                    For Each kvp As KeyValuePair(Of String, Object) In Parametri
                        'str() mi garantisce la conversione dei numeri senza cambiare punti con virgole come invece fa tostring
                        'isnumeric quando è presente l'apice (') restituisce false e quindi il parametro 'xxx' resta invariato
                        If IsNumeric(kvp.Value) Then
                            StringaFormattata = Replace(StringaFormattata, kvp.Key, Str(kvp.Value).Trim, Compare:=CompareMethod.Text)
                        Else
                            StringaFormattata = Replace(StringaFormattata, kvp.Key, kvp.Value, Compare:=CompareMethod.Text)
                        End If
                    Next
                Catch ex As Exception
                    Utx.Globale.Log.Errore(ex)
                End Try
            End Function
        End Class

        Public Function TokenUniWeb() As String
            Return StringToMD5($"Unitools-{Today:yyyy}:{Today:ddMM}").ToUpper
        End Function

        'Public Function JSerialize(Oggetto As Object) As String

        '    Dim theJsonSerializerSettings As New Newtonsoft.Json.JsonSerializerSettings()
        '    theJsonSerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All

        '    Return Newtonsoft.Json.JsonConvert.SerializeObject(Oggetto, theJsonSerializerSettings)
        'End Function

        'Public Function JDeserialize(JString As String) As Object
        '    Dim theJsonSerializerSettings As New Newtonsoft.Json.JsonSerializerSettings()
        '    theJsonSerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All

        '    Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of Ut.ApplicationPath)(JString, theJsonSerializerSettings)
        'End Function

        Public Function DimensioneFile(File As String) As String
            Dim fi As New FileInfo(File)

            If fi.Length < 1000000 Then
                Return Format(fi.Length / 1024, "###0.0 KB")
            Else
                Return Format(fi.Length / 1048576, "###0.0 MB")
            End If
        End Function

        Public Function IsTarga(Valore As String) As Boolean
            If Valore Like "[A-Z,a-z][A-Z,a-z]###[A-Z,a-z][A-Z,a-z]" Then Return True
            If Valore Like "[A-Z,a-z][A-Z,a-z]#####" Then Return True
            Return False
        End Function

        Public Function IsAlphabetic(Stringa As String)
            'se contiene caratteri alfabetici
            For Each c As Char In Stringa
                If Char.IsLetter(c) Then
                    Return True
                End If
            Next
            Return False
        End Function

        Public Function MergeFolder(RootOrigine As String, RootDestinazione As String) As Boolean
            Try
                'i file
                Directory.CreateDirectory(RootDestinazione)
                For Each f As String In Directory.GetFiles(RootOrigine)
                    Dim FileDest As String = Path.Combine(RootDestinazione, Path.GetFileName(f))
                    If File.Exists(FileDest) = False Then
                        File.Copy(f, FileDest)
                    End If
                Next
                'le cartelle
                For Each d As String In Directory.GetDirectories(RootOrigine)
                    Dim Destinazione As String = Path.Combine(RootDestinazione, Path.GetFileName(d))
                    MergeFolder(d, Destinazione)
                Next
                Return True
            Catch ex As Exception
                Utx.Globale.Log.Info(ex)
                Return False
            End Try
        End Function
    End Module
End Namespace

Namespace FunzioniData

    Public Module Funzioni

        Public Function Timestamp() As Integer
            Return Convert.ToInt32(Now.Subtract(New DateTime(1970, 1, 1, 0, 0, 0, 0).ToUniversalTime()).TotalSeconds)
        End Function

        Public Function InizioAnno(DataRiferimento As Date) As Date
            Return New DateTime(DataRiferimento.Year, 1, 1)
        End Function

        Public Function InizioAnno(Anno As Integer) As Date
            Return New DateTime(Anno, 1, 1)
        End Function

        Public Function FineAnno(DataRiferimento As Date) As Date
            Return New System.DateTime(DataRiferimento.Year, 12, 31).Date
        End Function

        Public Function FineAnno(Anno As Integer) As Date
            Return New System.DateTime(Anno, 12, 31).Date
        End Function

        Public Function FineMeseCorrente() As Date
            Return New DateTime(Today.Year, Today.Month, DateTime.DaysInMonth(Today.Year, Today.Month))
        End Function

        Public Function FineAnnoPrecedente(Data As Date) As Date
            Return New System.DateTime(Data.Year - 1, 12, 31).Date
        End Function

        ''' <summary>
        ''' dal formato asci yyyymmdd al formato italiano dd-mm-yyyy
        ''' </summary>
        ''' <param name="DataAsci"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AsciToIT(DataAsci As String) As String
            Try
                Return $"{DataAsci.Substring(6, 2)}-{DataAsci.Substring(4, 2)}-{DataAsci.Substring(0, 4)}"
            Catch ex As Exception
                Return ""
            End Try
        End Function

        Public Function Ieri() As Date
            Return Today.AddDays(-1).Date
        End Function

        Public Function InizioMeseCorrente() As Date
            Return New Date(Today.Year, Today.Month, 1).Date
        End Function

        Public Function InizioMese(Mese As Integer, Anno As Integer) As Date
            Return New Date(Anno, Mese, 1).Date
        End Function

        Public Function InizioMese(Data As Date) As Date
            Return New Date(Data.Year, Data.Month, 1).Date
        End Function

        Public Function QuindiciDelMese(Data As Date) As Date
            Return New System.DateTime(Data.Year, Data.Month, 15).Date
        End Function

        Public Function FineMese(Data As Date) As Date
            Return New DateTime(Data.Year, Data.Month, DateTime.DaysInMonth(Data.Year, Data.Month)).Date
        End Function

        Public Function FineMese(Mese As Integer, Anno As Integer) As Date
            Return New DateTime(Anno, Mese, DateTime.DaysInMonth(Anno, Mese)).Date
        End Function

        Public Function FineMese(Data As String) As Date
            Dim d As Date = CDate(Data)
            Return New DateTime(d.Year, d.Month, DateTime.DaysInMonth(d.Year, d.Month)).Date
        End Function

        ''' <summary>
        ''' data del primo lunedì,mardedì,...del mese
        ''' </summary>
        ''' <param name="Data"></param>
        ''' <param name="Giorno"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function TipoPrimoGiornoMese(Data As Date, Giorno As System.DayOfWeek) As Date
            Data = InizioMese(Data)
            Do While Data.DayOfWeek <> Giorno
                Data = Data.AddDays(1) 'avanzo di un giorno
            Loop
            Return Data
        End Function

        Public Function InizioDecade(Data As Date) As Date
            'restituisce la data di inizio della decade 
            Select Case Data.Day
                Case 1 To 10 : Return New DateTime(Data.Year, Data.Month, 1)
                Case 11 To 20 : Return New DateTime(Data.Year, Data.Month, 11)
                Case Else : Return New DateTime(Data.Year, Data.Month, 21)
            End Select
        End Function

        Public Function FineDecade(Data As Date) As Date
            'restituisce la data di fine della decade 
            Select Case Data.Day
                Case 1 To 10 : Return New DateTime(Data.Year, Data.Month, 10)
                Case 11 To 20 : Return New DateTime(Data.Year, Data.Month, 20)
                Case Else : Return FineMese(Data)
            End Select
        End Function

        Public Function InizioProssimaDecade(Data As Date) As Date
            'restituisce la data di inizio della decade successiva
            Select Case Data.Day
                Case 1 To 10
                    'la prossima è la seconda
                    Return New DateTime(Data.Year, Data.Month, 11)
                Case 11 To 20
                    'la prossima è la terza
                    Return New DateTime(Data.Year, Data.Month, 21)
                Case Else
                    'la prossima è la prima
                    Return InizioMese(Data.AddMonths(1))
            End Select
        End Function

        Public Function InizioPrecedenteDecade(Data As Date) As Date
            'restituisce la data di inizio della decade successiva
            Select Case Data.Day
                Case 1 To 10
                    'la decade è la terza del mese precedente
                    Data = Data.AddMonths(-1)
                    Return New DateTime(Data.Year, Data.Month, 21)
                Case 11 To 20
                    'la precdente è la prima
                    Return New DateTime(Data.Year, Data.Month, 1)
                Case Else
                    'la precedente è la seconda
                    Return New DateTime(Data.Year, Data.Month, 11)
            End Select
        End Function

        Public Function FineProssimaDecade(Data As Date) As Date
            'restituisce la data di fine della decade successiva
            Select Case Data.Day
                Case 1 To 10
                    'la prossima è la seconda
                    Return New DateTime(Data.Year, Data.Month, 20)
                Case 11 To 20
                    'la prossima è la terza
                    Return FineMese(Data)
                Case Else
                    'la prossima è la prima del mese successivo
                    Data = Data.AddMonths(1)
                    Return New DateTime(Data.Year, Data.Month, 10)
            End Select
        End Function

        ''' <summary>
        ''' restituisce (per riferimento) le date di inizio e fine della decade successiva
        ''' </summary>
        ''' <param name="Data">data di riferimento</param>
        ''' <param name="Inizio"></param>
        ''' <param name="Fine"></param>
        ''' <remarks></remarks>
        Public Sub ProssimaDecade(Data As Date, ByRef Inizio As Date, ByRef Fine As Date)
            Select Case Data.Day
                Case 1 To 10
                    'la prossima è la seconda
                    Inizio = New DateTime(Data.Year, Data.Month, 11)
                    Fine = New DateTime(Data.Year, Data.Month, 20)
                Case 11 To 20
                    'la prossima è la terza
                    Inizio = New DateTime(Data.Year, Data.Month, 21)
                    Fine = FineMese(Data)
                Case Else
                    'la prossima è la prima
                    Data = Data.AddMonths(1)
                    Inizio = New DateTime(Data.Year, Data.Month, 1)
                    Fine = New DateTime(Data.Year, Data.Month, 10)
            End Select
        End Sub

        Public Function DataToDecade(Data As Date) As Integer
            Select Case Data.Day
                Case 1 To 10 : Return 1
                Case 11 To 20 : Return 2
                Case Else : Return 3
            End Select
        End Function

        Public Function MaxDate(Data1 As Date, Data2 As Date) As Date
            Return New DateTime(Math.Max(Data1.Ticks, Data2.Ticks))
        End Function

        Public Function MinDate(Data1 As Date, Data2 As Date) As Date
            Return New DateTime(Math.Min(Data1.Ticks, Data2.Ticks))
        End Function

        Public Function DataUsa(Data As Date) As String
            Return $"#{Data:MM/dd/yyyy}#"
        End Function

        Public Function ProssimoGiornoDeterminato(Giorno As DayOfWeek) As Date
            Return Today.AddDays((7 + Giorno) - Weekday(Today, FirstDayOfWeek.Monday))
        End Function

        Public Function ListaGiorni(Inizio As Date, Fine As Date) As List(Of Date)
            Dim Lista As New List(Of Date)
            Dim d As Date = Inizio
            Do While d <= Fine
                Lista.Add(d)
                d = d.AddDays(1)
            Loop
            Return Lista
        End Function

        Public Function IsRataIntermedia(DataScadenzaPolizza As Date, DataEffettoTitolo As Date) As Boolean
            '14-marzo-2018: verificato su tabella incassi
            '((12+Month([scadenzapolizza])-mese Mod (12/frazionamento)))
            Return (DataScadenzaPolizza.Month <> DataEffettoTitolo.Month)
        End Function
    End Module
End Namespace

Namespace FunzioniHtml

    Public Module Funzioni

        Public Function GetValueCell(row As mshtml.HTMLTableRow, col As Integer) As String
            Try
#If DEBUG Then
                'For k As Integer = 1 To row.cells.length
                '    Dim element As mshtml.HTMLTableCell = row.cells.item(k)
                '    If element.innerText Is Nothing Then
                '        MsgBox(String.Format("colonna {0}: ''", k))
                '    Else
                '        MsgBox(String.Format("colonna {0}: {1}", k, element.innerText))
                '    End If
                'Next
#End If
                If row.cells.length > col Then
                    Dim element As mshtml.HTMLTableCell = row.cells.item(col)
                    If element.innerText Is Nothing Then
                        Return ""
                    Else
                        Return element.innerText
                    End If
                Else
                    Return ""
                End If
            Catch ex As Exception
                Return ""
            End Try
        End Function

        Public Function Html2Dom(PaginaHtml As String, Tipo As String) As mshtml.HTMLDocument
            Try
                Dim InizioTbl As Integer
                Dim FineTbl As Integer

                Select Case Tipo
                    Case "clienti"
                        InizioTbl = PaginaHtml.IndexOf("<form name=""pagina03Form""")
                        FineTbl = PaginaHtml.IndexOf("</form>", InizioTbl + 7)
                    Case "arretrati"
                        InizioTbl = PaginaHtml.IndexOf("<table cellspacing=""0"" id=""risultato""")
                        FineTbl = PaginaHtml.IndexOf("</table>", InizioTbl + 8)
                End Select
                PaginaHtml = "<html>" + PaginaHtml.Substring(InizioTbl, FineTbl - InizioTbl) + "</html>"

                'Dim Temp As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "PaginaEssig.html")
                'File.WriteAllText(Temp, PaginaHtml)

                Dim Doc As Object = New mshtml.HTMLDocument
                With Doc
                    .open()
                    .write(PaginaHtml)
                End With
                Return Doc

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return New mshtml.HTMLDocument
            End Try
        End Function

        Public Sub InvocaJavaScript(ByRef d As IHTMLDocument2, ByRef Parametri() As String)

            Dim IHTMLDoc2 As IHTMLDocument2
            Dim IWindow2 As IHTMLWindow2

            IHTMLDoc2 = d
            IWindow2 = IHTMLDoc2.parentWindow

            If Not IWindow2 Is Nothing Then

                'creo la stringa dei parametri
                Dim Script As String
                Script = "Events.invokeEvent("

                Dim k As Integer
                For k = 0 To UBound(Parametri)
                    Script = Script + "'" + Parametri(k) + "',"
                Next

                'tolgo l'ultima virgola e aggiungo la parantesi di chiusura
                Script = Left$(Script, Len(Script) - 1) + ")"

                'eseguo lo script
                IWindow2.execScript(Script)
            End If

        End Sub

        Public Function NormalizzaXml(xml As String)
            Dim Coppie As String = "&/&amp;|à/&agrave;|á/&aacute;|è/&egrave;|é/&eacute;|ì/&igrave;|í/&iacute;|ò/&ograve;|ó/&oacute;|ù/&ugrave;|ú/&uacute;"

            For Each Coppia As String In Coppie.Split("|")
                Dim Carattere As String = Coppia.Split("/")(0)
                Dim Sostituto As String = Coppia.Split("/")(1)

                xml = Replace(xml, Carattere, Sostituto, Compare:=CompareMethod.Text)
            Next
            Return xml
        End Function
    End Module
End Namespace

Namespace FunzioniDb

    Public Module Funzioni

        Public Enum TipoEnum
            TIPO_NUMERO
            TIPO_VALUTA
            TIPO_STRINGA
            TIPO_DATA
            TIPO_DATAORA
            TIPO_ENUM
            TIPO_BOOLEAN
        End Enum

        Public Function CreaDataReader(ByRef sql As String) As OleDbDataReader
            Try
                Dim c As New OleDbConnection(Utx.Globale.CnDbLink)
                c.Open()
                Using cmd As New OleDbCommand(sql, c)
                    Return cmd.ExecuteReader()
                End Using
            Catch ex As Exception
                Globale.Log.Info(ex)
                Return Nothing
            End Try
        End Function

        Public Function CreaDataTableReader(sql As String, Optional Agenzia As String = "") As DataTableReader
            Try
                Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(sql, Agenzia)
                If Risposta IsNot Nothing Then
                    Return Risposta.DataTable.CreateDataReader
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Globale.Log.Info(ex)
                Return Nothing
            End Try
        End Function

        Public Function CreaDataReader(ByRef c As OleDbConnection,
                                       ByRef sql As String) As OleDbDataReader
            Try
                Using cmd As New OleDbCommand(sql, c)
                    Return cmd.ExecuteReader()
                End Using
            Catch ex As Exception
                Globale.Log.Info(ex)
                Return Nothing
            End Try
        End Function

        Public Function CreaDataTableFromStored(ByRef Stored As String,
                                                Optional NomeTabella As String = "Tabella1") As DataTable
            Try
                Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                    c.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = Stored

                        Using da As New OleDbDataAdapter(cmd)
                            Dim dt As New DataTable With {.TableName = NomeTabella}
                            da.Fill(dt)

                            Return dt
                        End Using
                    End Using
                End Using

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return Nothing
            End Try
        End Function

        Public Function CreaDataTable(ByRef sSql As String, Optional NomeTabella As String = "Tabella1") As DataTable
            Try
                Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                    c.Open()

                    Using cmd As New OleDbCommand(sSql, c)

                        Using da As New OleDbDataAdapter(cmd)

                            Dim dt As New DataTable With {.TableName = NomeTabella}
                            da.Fill(dt)

                            Return dt
                        End Using
                    End Using
                End Using

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return Nothing
            End Try
        End Function

        Public Function CreaDataTable(ByRef sSql As String,
                                      ByRef c As OleDbConnection,
                                      Optional NomeTabella As String = "Tabella1") As DataTable
            Try
                Using cmd As New OleDbCommand(sSql, c)
                    Using da As New OleDbDataAdapter(cmd)
                        Dim dt As New DataTable
                        dt.TableName = NomeTabella
                        da.Fill(dt)

                        Return dt
                    End Using
                End Using

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return Nothing
            End Try
        End Function

        Public Function CreaDataTable(ByRef cmd As OleDbCommand,
                                      Optional NomeTabella As String = "Tabella1") As DataTable

            Try
                Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                    c.Open()

                    Using da As New OleDbDataAdapter(cmd)
                        cmd.Connection = c

                        Dim dt As New DataTable With {.TableName = NomeTabella}
                        da.Fill(dt)

                        Return dt
                    End Using
                End Using

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return Nothing
            End Try
        End Function

        Public Function CreaDataTable(ByRef cmd As OleDbCommand,
                                      ByRef c As OleDbConnection,
                                      Optional NomeTabella As String = "Tabella1") As DataTable
            Try
                Using da As New OleDbDataAdapter(cmd)
                    cmd.Connection = c

                    Dim dt As New DataTable
                    dt.TableName = NomeTabella
                    da.Fill(dt)

                    Return dt
                End Using

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return Nothing
            End Try
        End Function

        Public Function CreaDataTableDistinct(ByRef dt As DataTable, Colonne() As String) As DataTable
            Return dt.DefaultView.ToTable(True, Colonne)
        End Function

        Public Function CreaDataRow(sSql As String) As DataRow
            Try
                Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(sSql).DataTable
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return Nothing
            End Try
        End Function

        'Public Function CreaDataRow(ByRef cmd As OleDbCommand) As DataRow
        '    Try
        '        Using c As New OleDbConnection(Utx.Globale.CnDbLink)
        '            c.Open()

        '            Using da As New OleDbDataAdapter(cmd)
        '                cmd.Connection = c

        '                Dim dt As New DataTable
        '                da.Fill(dt)

        '                If dt.Rows.Count > 0 Then
        '                    Return dt.Rows(0)
        '                Else
        '                    Return Nothing
        '                End If
        '            End Using
        '        End Using

        '    Catch ex As Exception
        '        Globale.Log.Errore(ex)
        '        Return Nothing
        '    End Try
        'End Function

        'Public Function DuplicaTabella(c As OleDbConnection,
        '                               TabellaOrigine As String,
        '                               TabellaDestinazione As String,
        '                               SovrascrivereDestinazione As Boolean) As Boolean
        '    Try
        '        If Utx.FunzioniDb.EsisteTabella(c, TabellaOrigine) Then
        '            If SovrascrivereDestinazione = True Then
        '                Utx.FunzioniDb.CancellaTabella(c, TabellaDestinazione)
        '            End If

        '            Using cmd As New OleDbCommand
        '                cmd.Connection = c
        '                cmd.CommandType = CommandType.Text
        '                cmd.CommandText = String.Format("SELECT * INTO {0} FROM {1}", TabellaDestinazione, TabellaOrigine)
        '                cmd.ExecuteNonQuery()
        '            End Using
        '        End If
        '        Return True
        '    Catch ex As Exception
        '        Globale.Log.Errore(ex)
        '        Return False
        '    End Try
        'End Function

        Public Function ExecuteScalar(Sql As String, Optional ValoreDefault As Object = Nothing) As Object
            Try
                Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                    c.Open()
                    Using cmd As New OleDbCommand(Sql, c)
                        Dim value As Object = cmd.ExecuteScalar
                        If IsNothing(value) OrElse IsDBNull(value) Then
                            Return ValoreDefault
                        Else
                            Return value
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Utx.Globale.Log.Info(ex.Message)
                Return ValoreDefault
            End Try
        End Function

        Public Function ExecuteScalar(ByRef c As OleDbConnection,
                                      Sql As String,
                                      Optional ValoreDefault As Object = Nothing) As Object
            Try
                Using cmd As New OleDbCommand(Sql, c)
                    Dim value As Object = cmd.ExecuteScalar
                    If IsNothing(value) OrElse IsDBNull(value) Then
                        Return ValoreDefault
                    Else
                        Return value
                    End If
                End Using
            Catch ex As Exception
                Utx.Globale.Log.Info(ex.Message)
                Return ValoreDefault
            End Try
        End Function

        ''' <summary>
        ''' esegue una ExecuteNonQuery su DbLink
        ''' </summary>
        ''' <param name="Sql"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExecuteNonQuery(Sql As String) As Boolean
            Try
                Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                    c.Open()
                    Using cmd As New OleDbCommand(Sql, c)
                        Return cmd.ExecuteNonQuery
                    End Using
                End Using
                Return True
            Catch ex As Exception
                Utx.Globale.Log.Info(ex.Message)
                Return False
            End Try
        End Function

        Public Function ExecuteNonQuery(ByRef c As OleDbConnection,
                                        Sql As String) As Boolean
            Try
                Using cmd As New OleDbCommand(Sql, c)
                    Return cmd.ExecuteNonQuery
                End Using
                Return True
            Catch ex As Exception
                Utx.Globale.Log.Info(ex.Message)
                Return False
            End Try
        End Function

        Public Sub DistinctTabella(Tabella As String, ByRef c As OleDbConnection)
            Try
                Utx.Globale.Log.Info(String.Format("DISTINCT tabella {0}", Tabella))
                'se la tabella esiste
                If Utx.FunzioniDb.EsisteTabella(c, Tabella) Then
                    Dim TabellaTemp As String = Tabella & "_temp"
                    'cancello la tabella temporanea
                    Utx.FunzioniDb.CancellaTabella(c, TabellaTemp)

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        'faccio il distinct in una nuova tabella
                        cmd.CommandText = String.Format("SELECT DISTINCT * INTO {0} FROM {1}", TabellaTemp, Tabella)
                        cmd.ExecuteNonQuery()
                        'svuoto la tabella originale
                        cmd.CommandText = String.Format("DELETE * FROM {0}", Tabella)
                        cmd.ExecuteNonQuery()
                        'copio i record nella tabella originale
                        cmd.CommandText = String.Format("INSERT INTO {0} SELECT * FROM {1}", Tabella, TabellaTemp)
                        cmd.ExecuteNonQuery()
                        'cancello la tabella temporanea
                        cmd.CommandText = String.Format("DROP TABLE {0}", TabellaTemp)
                        cmd.ExecuteNonQuery()
                    End Using
                Else
                    Utx.Globale.Log.Info(String.Format("DISTINCT: la tabella {0} non esiste", Tabella))
                End If

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try
        End Sub

        Public Function Aggiorna(ByRef sql As String) As Integer
            Try
                Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                    c.Open()
                    Using cmd As New OleDbCommand(sql, c)
                        Return cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch e As Exception
                Globale.Log.Info(e)
                Return 0
            End Try
        End Function

        Public Function EsisteCampo(Tabella As String, Campo As String) As Boolean
            Try
                'il controllo avviene utilizzando la connessione dblink
                Campo = Campo.ToUpper
                With CreaDataTable(String.Format("SELECT * FROM {0} WHERE False", Tabella))
                    For Each col As DataColumn In .Columns
                        If col.ColumnName.ToUpper = Campo Then
                            Return True
                        End If
                    Next
                End With
                Return False
            Catch ex As Exception
                Utx.Globale.Log.Info(ex.Message)
                Return False
            End Try
        End Function

        Public Function EsisteCampo(ByRef c As OleDbConnection, Tabella As String, Campo As String) As Boolean
            Try
                Campo = Campo.ToUpper
                With CreaDataTable(String.Format("SELECT * FROM {0} WHERE False", Tabella), c)
                    For Each col As DataColumn In .Columns
                        If col.ColumnName.ToUpper = Campo Then
                            Return True
                        End If
                    Next
                End With
                Return False
            Catch ex As Exception
                Utx.Globale.Log.Info(ex.Message)
                Return False
            End Try
        End Function

        Public Function TO_ENUM(nValue As Integer) As String
            TO_ENUM = TO_STRING(Chr(nValue))
        End Function

        Public Function TO_DATE(Str As String) As String
            Dim Data As Date

            If IsDate(Str) Then
                Data = CDate(Str)
                If Data > Date.MinValue Then
                    TO_DATE = String.Format("'{0}'", Data.ToString("dd/MM/yyyy"))
                Else
                    TO_DATE = "NULL"
                End If
            Else
                TO_DATE = "NULL"
            End If
        End Function

        Public Function TO_DATETIME(Str As String) As String
            Dim Data As Date

            If IsDate(Str) Then
                Data = CDate(Str)
                If Data > Date.MinValue Then
                    Return String.Format("#{0}#", Format(Data, "MM/dd/yyyy HH:mm:ss"))
                Else
                    Return "NULL"
                End If
            Else
                Return "NULL"
            End If
        End Function

        Public Function TO_STRING(stringhe As String()) As String
            Dim elenco As String = ""

            For Each stringa In stringhe
                If stringa <> vbNullString Then
                    elenco &= String.Format(", '{0}'", Replace(stringa, "'", "''"))
                Else
                    elenco &= ", ''"
                End If
            Next
            Return elenco.Substring(2)
        End Function

        Public Function TO_STRING(Str As String) As String
            If Str <> vbNullString Then
                TO_STRING = String.Format("'{0}'", Replace(Str, "'", "''"))
            Else
                TO_STRING = "''"
            End If
        End Function

        Public Function TO_VALUTA(value As String) As String
            If Trim(value) <> vbNullString Then
                TO_VALUTA = Replace(Replace(value, ".", ""), ",", ".")
            Else
                TO_VALUTA = "NULL"
            End If
        End Function

        Public Function TO_NUMBER(value As String) As String
            Select Case Trim(value)
                Case vbNullString, "NaN"
                    Return "NULL"
                Case Else
                    Return Replace(Replace(value, ".", ""), ",", ".")
            End Select
            'If Trim(value) <> vbNullString Then
            '    TO_NUMBER = Replace(Replace(value, ".", ""), ",", ".")
            'Else
            '    TO_NUMBER = "NULL"
            'End If
        End Function

        Public Function TO_DB(value As String, fieldTipo As TipoEnum) As String
            Select Case fieldTipo
                Case TipoEnum.TIPO_NUMERO : Return TO_NUMBER(value)
                Case TipoEnum.TIPO_VALUTA : Return TO_VALUTA(value)
                Case TipoEnum.TIPO_DATA : Return TO_DATE(value)
                Case TipoEnum.TIPO_DATAORA : Return TO_DATETIME(value)
                Case TipoEnum.TIPO_ENUM : Return TO_ENUM(value)
                Case TipoEnum.TIPO_BOOLEAN : Return TO_NUMBER(value)
                Case Else : Return TO_STRING(value)
            End Select
        End Function

        Public Function TO_DEFAULT(fieldTipo As TipoEnum) As String
            Select Case fieldTipo
                Case TipoEnum.TIPO_NUMERO : Return "0"
                Case TipoEnum.TIPO_VALUTA : Return "0"
                Case TipoEnum.TIPO_DATA : Return "01-01-1901"
                Case TipoEnum.TIPO_ENUM : Return "0"
                Case TipoEnum.TIPO_BOOLEAN : Return "False"
                Case Else : Return " "
            End Select
        End Function

        Public Function NullToValue(oggetto As Object) As String
            Try
                If TypeOf oggetto Is DBNull Then
                    Return Nothing
                ElseIf TypeOf oggetto Is Date Then
                    Return CDate(oggetto).ToString("dd/MM/yyyy")
                ElseIf TypeOf oggetto Is String Then
                    Return oggetto.ToString.Trim()
                ElseIf TypeOf oggetto Is Double Then
                    Return FunzioniFormato.FormatoEuro(CDbl(oggetto))
                Else
                    Return oggetto.ToString.Trim()
                End If

            Catch ex As Exception
            End Try
            Return Nothing
        End Function

        'Public Function NullToString(Valore As Object,
        '                             Optional ToZero As Boolean = False) As Object

        '    If Valore Is DBNull.Value Then

        '        If ToZero = True Then
        '            Return 0
        '        Else
        '            Return ""
        '        End If
        '    Else
        '        Return Valore
        '    End If
        'End Function
        Public Function NullToString(Valore As Object,
                                     Optional ToZero As Boolean = False) As Object

            If (Valore Is DBNull.Value) OrElse (Valore Is Nothing) Then

                If ToZero = True Then
                    Return 0
                Else
                    Return ""
                End If
            Else
                Return Valore
            End If
        End Function

        Public Function NullNothingToString(Valore As Object) As Object
            If (Valore Is DBNull.Value) OrElse (Valore Is Nothing) Then
                Return ""
            Else
                Return Valore
            End If
        End Function

        Public Function NullToNumber(Valore As Object) As Double
            If Valore Is DBNull.Value Then
                Return 0
            Else
                Return Valore
            End If
        End Function

        Public Function NullToDate(Data As Object) As Date
            If IsDate(Data) Then
                Return Data
            Else
                Return #1/1/1900#
            End If
        End Function

        Public Function Str2Num(Stringa As String) As Double
            Try
                If String.IsNullOrEmpty(Stringa) Then
                    Return 0
                Else
                    If IsNumeric(Stringa) Then
                        Return Val(Stringa)
                    Else
                        Return 0
                    End If
                End If
            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Function Str2Data(Stringa As String) As Object
            Try
                If Stringa = "00:00:00" Then
                    Return DBNull.Value
                ElseIf IsDate(Stringa) Then
                    Return Utx.FunzioniData.MaxDate(CDate(Stringa), #1/1/1800#)
                Else
                    Return DBNull.Value
                End If

            Catch ex As Exception
                Return DBNull.Value
            End Try
        End Function

        Public Function EsisteTabella(c As OleDbConnection, Tabella As String) As Boolean
            Try
                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("SELECT TOP 1 * FROM {0}", Tabella)
                    cmd.ExecuteNonQuery()
                End Using
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function NumeroRecord(c As OleDbConnection, Tabella As String) As Integer
            Try
                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("SELECT Count(*) FROM {0}", Tabella)
                    Return cmd.ExecuteScalar
                End Using
            Catch ex As Exception
                Return -1
            End Try
        End Function

        Public Function SvuotaTabella(Tabella As String) As Integer
            Try
                Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                    c.Open()
                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = String.Format("DELETE FROM {0}", Tabella)
                        Return cmd.ExecuteNonQuery
                    End Using
                End Using
            Catch ex As Exception
                Return -1
            End Try
        End Function

        Public Function SvuotaTabella(c As OleDbConnection, Tabella As String) As Integer
            Try
                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("DELETE FROM {0}", Tabella)
                    Return cmd.ExecuteNonQuery
                End Using
            Catch ex As Exception
                Return -1
            End Try
        End Function

        Public Function CancellaTabella(cmd As OleDbCommand, Tabella As String) As Boolean
            Try
                cmd.CommandText = String.Format("DROP TABLE {0}", Tabella)
                cmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function CancellaTabella(c As OleDbConnection, Tabella As String) As Boolean
            Try
                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("DROP TABLE {0}", Tabella)
                    cmd.ExecuteNonQuery()
                End Using
                Utx.Globale.Log.Info(String.Format("cancellata la tabella {0} sul db {1}", Tabella, c.DataSource))
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        'Public Function RinominaTabella(ByRef c As OleDbConnection,
        '                        OldName As String,
        '                        NewName As String) As Boolean
        '    Try
        '        Dim cat As New ADOX.Catalog

        '        ' Attribuiamo allo script la connessione
        '        cat.ActiveConnection = c

        '        ' Impostiamo il cambio nome
        '        cat.Tables(OldName).Name = NewName
        '        ' Eseguiamo la rinomina
        '        cat.Tables.Refresh()

        '        cat = Nothing

        '        Return True

        '    Catch ex As Exception
        '        Globale.Log.Errore(ex)
        '        Return False
        '    End Try
        'End Function

        Public Sub CompattaMdb(DbFile As String, Optional MsgErrore As Boolean = True)
            Try
                Dim NomeCopia As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "CompactDb.mdb")
                If File.Exists(NomeCopia) Then
                    File.Delete(NomeCopia)
                End If

                'compatta il file DB
                Dim j As New JRO.JetEngine
                Call j.CompactDatabase("Data Source=" & DbFile & ";", "Data Source=" & NomeCopia & ";")
                'rinomina il file
                File.Delete(DbFile)
                File.Move(NomeCopia, DbFile)

                Utx.Globale.Log.Info(String.Format("{0}: compattazione riuscita.", DbFile))

            Catch ex As Exception
                Utx.Globale.Log.Info(String.Format("*** {0}: compattazione NON riuscita.", DbFile))
                Utx.Globale.Log.Info(ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' compatta tutti i db di unitools
        ''' </summary>
        ''' <param name="Controllo">un controllo che espone la proprietà text</param>
        ''' <remarks></remarks>
        Public Sub CompattaCartelleDati(Optional ByRef Controllo As Object = Nothing)
            Try
                For Each Agenzia As String In Utx.EnteGestore.CodiciGestiti
                    'cartella agenzia
                    For Each f As String In Directory.GetFiles(Utx.ConnessioniDb.CartellaDatiAgenzia(Agenzia), "*.mdb")
                        If Controllo IsNot Nothing Then
                            Controllo.text = String.Format("Compattazione {0}: {1}", Agenzia, Path.GetFileNameWithoutExtension(f))
                        End If
                        Utx.FunzioniDb.CompattaMdb(f, False)
                    Next
                Next

                'cartella comune
                For Each f As String In Directory.GetFiles(Utx.Globale.Paths.CartellaDatiComuni, "*.mdb")
                    If Controllo IsNot Nothing Then
                        Controllo.text = String.Format("Compattazione: {0}", Path.GetFileNameWithoutExtension(f))
                    End If
                    Utx.FunzioniDb.CompattaMdb(f, False)
                Next

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try
        End Sub

        Public Sub CreaStoredDbUno(CodiceAgenzia As String)
            Try
                'creo le stored
                Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, ConnessioniDb.Db.DBUNO))
                    c.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text

                        For Each f As String In Directory.GetFiles(Utx.Globale.Paths.CartellaSetting, "vista_*.txt")
                            'cancello se esistente
                            If (Path.GetFileNameWithoutExtension(f) <> "vista_sinistri_DP") And
                               (Path.GetFileNameWithoutExtension(f) <> "vista_sinistri_DA") And
                               (Path.GetFileNameWithoutExtension(f) <> "vista_clienti") And
                               (Path.GetFileNameWithoutExtension(f) <> "vista_clienti1") Then
                                Utx.FunzioniDb.CancellaTabella(c, Path.GetFileNameWithoutExtension(f))
                                'ri-creo
                                cmd.CommandText = String.Format("Create Procedure {0} AS {1}",
                                                                Path.GetFileNameWithoutExtension(f),
                                                                File.ReadAllText(f))
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                    End Using
                End Using

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try
        End Sub

        Public Sub CreaChiaviDb(Optional ByRef Controllo As Object = Nothing)
            Dim Esito As Boolean = True

            For Each Agenzia As String In Utx.EnteGestore.CodiciGestiti

                If Controllo IsNot Nothing Then
                    Controllo.Text = String.Format("{0}: Controllo chiavi", Agenzia)
                End If

                Utx.Globale.Log.Info("{0}: Creazione chiavi", {Agenzia})

                Esito = Esito And CreaChiaviClienti(Agenzia)
                Esito = Esito And CreaChiaviPolizze(Agenzia)
                Esito = Esito And CreaChiaviSinistri(Agenzia)
                'Esito = Esito And CreaChiaviNote(Agenzia)
            Next
            'chiavi supporto
            If Controllo IsNot Nothing Then
                Controllo.Text = "Controllo chiavi dati comuni"
            End If
            Utx.Globale.Log.Info("00000: Creazione chiavi supporto")
            CreaChiaviSupporto()

            If Controllo IsNot Nothing Then
                Controllo.Text = "Creazione chiavi completata"
            End If
        End Sub

        Public Sub CancellaChiaveDb(ByRef c As OleDbConnection,
                                    Tabella As String,
                                    NomeChiave As String)
            Try
                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("ALTER TABLE {0} DROP CONSTRAINT {1}", Tabella, NomeChiave)
                    cmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Utx.Globale.Log.Info(ex.Message)
            End Try
        End Sub

        Public Sub CancellaIndiciDb(ByRef c As OleDbConnection,
                                    Tabella As String)
            Try
                'GetOleDbSchemaTable recupera sia gli indici che le chiavi primarie
                'documentazione: https://msdn.microsoft.com/en-us/library/system.data.oledb.oledbschemaguid.indexes.aspx
                Dim dt As DataTable = c.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Indexes, New Object() {Nothing, Nothing, Nothing, Nothing, Tabella})
                Dim Indice As String = ""

                For Each row As DataRow In dt.Rows
                    'se si tratta di un indice
                    If row("PRIMARY_KEY") = False Then
                        'se non è l'indice già analizzato (c'è una riga per ogni colonna nell'indice)
                        If row("INDEX_NAME") <> Indice Then
                            Indice = row("INDEX_NAME")
                            'cancello l'indice
                            Utx.Globale.Log.Info("Cancello l'indice '{0}' sulla tabella '{1}'", {Indice, Tabella})
                            Using cmd As New OleDbCommand
                                cmd.Connection = c
                                cmd.CommandType = CommandType.Text
                                cmd.CommandText = String.Format("ALTER TABLE {0} DROP CONSTRAINT {1}", Tabella, Indice)
                                cmd.ExecuteNonQuery()
                            End Using
                        End If
                    End If
                Next
            Catch ex As Exception
                Utx.Globale.Log.Info(ex.Message)
            End Try
        End Sub

        Public Sub CancellaChiaveDb(ByRef c As OleDbConnection,
                                    Tabella As String)
            Try
                'GetOleDbSchemaTable recupera sia gli indici che le chiavi primarie
                'documentazione: https://msdn.microsoft.com/en-us/library/system.data.oledb.oledbschemaguid.indexes.aspx
                Dim dt As DataTable = c.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Indexes, New Object() {Nothing, Nothing, Nothing, Nothing, Tabella})
                Dim Chiave As String = ""

                For Each row As DataRow In dt.Rows
                    'se si tratta della chiave
                    If row("PRIMARY_KEY") = True Then
                        'se non è la chiave già analizzata (c'è una riga per ogni colonna nell'indice)
                        If row("INDEX_NAME") <> Chiave Then
                            Chiave = row("INDEX_NAME")
                            'cancello l'indice
                            Utx.Globale.Log.Info("Cancello la chiave '{0}' sulla tabella '{1}'", {Chiave, Tabella})
                            Using cmd As New OleDbCommand
                                cmd.Connection = c
                                cmd.CommandType = CommandType.Text
                                cmd.CommandText = String.Format("ALTER TABLE {0} DROP CONSTRAINT {1}", Tabella, Chiave)
                                cmd.ExecuteNonQuery()
                            End Using
                        End If
                    End If
                Next
            Catch ex As Exception
                Utx.Globale.Log.Info(ex.Message)
            End Try
        End Sub

        Public Function CreaChiaveDb(ByRef c As OleDbConnection,
                                     Tabella As String,
                                     NomeChiave As String,
                                     ListaCampi As String()) As Boolean
            Try
                Dim Campi As String = ""
                For Each campo As String In ListaCampi
                    Campi += String.Format("{0},", campo)
                Next
                Campi = Left(Campi, Campi.Length - 1)

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("ALTER TABLE {0} ADD CONSTRAINT {1} PRIMARY KEY ({2})", Tabella, NomeChiave, Campi)
                    cmd.ExecuteNonQuery()
                End Using
                Utx.Globale.Log.Info(String.Format("Tabella {0} - Chiave {1}: creata correttamente", Tabella, NomeChiave))
                Return True
            Catch ex As Exception
                Utx.Globale.Log.Info(String.Format("Tabella {0} - Chiave {1}: {2}", Tabella, NomeChiave, ex.Message))
                Return False
            End Try
        End Function

        Public Function CreaVincoliDbUno(Agenzia As String) As Boolean
            Try
                Globale.Log.Info("{0}: creazione chiavi dbuno", {Agenzia}, True)
                Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Agenzia, ConnessioniDb.Db.DBUNO))
                    c.Open()

                    CancellaChiaveDb(c, "arp001_tipofile")
                    CancellaIndiciDb(c, "arp001_tipofile")
                    CreaChiaveDb(c, "arp001_tipofile", "pk_arp001", {"CodTipoFile"})

                    CancellaChiaveDb(c, "arp002_file")
                    CancellaIndiciDb(c, "arp002_file")
                    CreaChiaveDb(c, "arp002_file", "pk_arp002", {"Nome", "CodTipoRecord"})

                    CancellaChiaveDb(c, "Clienti")
                    CreaChiaveDb(c, "Clienti", "pk_clienti", {"CodiceFiscale"})

                    CancellaChiaveDb(c, "Clienti1")
                    CreaChiaveDb(c, "Clienti1", "pk_clienti", {"CodiceFiscale"})

                    CancellaChiaveDb(c, "Polizze1")
                    CreaChiaveDb(c, "Polizze1", "pk_polizze1", {"CodicePuntoVendita", "Ramo", "Polizza"})
                    CancellaChiaveDb(c, "Polizze2")
                    CreaChiaveDb(c, "Polizze2", "pk_polizze2", {"CodicePuntoVendita", "Ramo", "Polizza"})
                    CancellaChiaveDb(c, "Polizze3")
                    CreaChiaveDb(c, "Polizze3", "pk_polizze3", {"CodicePuntoVendita", "Ramo", "Polizza"})
                    CancellaChiaveDb(c, "Polizze4")
                    CreaChiaveDb(c, "Polizze4", "pk_polizze4", {"CodicePuntoVendita", "Ramo", "Polizza"})

                    CancellaChiaveDb(c, "PolizzeClausole")
                    CreaChiaveDb(c, "PolizzeClausole", "pk_PolizzeClausole", {"CodicePuntoVendita", "Ramo", "Polizza", "Clausola"})

                    CancellaChiaveDb(c, "Liquidatori")
                    CreaChiaveDb(c, "Liquidatori", "pk_Liquidatori", {"Codice"})

                    CancellaChiaveDb(c, "Periti")
                    CreaChiaveDb(c, "Periti", "pk_Periti", {"CodicePeritoSAP"})

                    CancellaChiaveDb(c, "Titoli")
                    CancellaIndiciDb(c, "Titoli")
                    CreaIndice(c, "Titoli", "IndiceTitoli", {"Ramo", "Polizza", "EffettoAppendice", "NumeroAppendice", "DataEffetto"})

                    CancellaChiaveDb(c, "TitoliRipartizione")
                    CancellaIndiciDb(c, "TitoliRipartizione")
                    CreaIndice(c, "TitoliRipartizione", "pk_TitoliRipartizione", {"Ramo", "Polizza", "EffettoAppendice", "NumeroAppendice", "DataEffetto"})

                    CancellaChiaveDb(c, "TitoliScopertiCassa")
                    CancellaIndiciDb(c, "TitoliScopertiCassa")
                    CreaIndice(c, "TitoliScopertiCassa", "pk_TitoliScopertiCassa", {"Ramo", "Polizza", "EffettoAppendice", "NumeroAppendice", "DataEffetto"})

                    CancellaChiaveDb(c, "Sinistri")
                    CancellaIndiciDb(c, "Sinistri")
                    CreaIndice(c, "Sinistri", "IndiceSinistri", {"AgenziaSinistro", "EsercizioSinistro", "NumeroSinistro"})

                    CancellaChiaveDb(c, "Incarichi")
                    CancellaIndiciDb(c, "Incarichi")
                    CreaIndice(c, "Incarichi", "IndiceIncarichi", {"AgenziaSinistro", "EsercizioSinistro", "NumeroSinistro"})

                    CancellaChiaveDb(c, "PolizzeSostituite")
                    CancellaIndiciDb(c, "PolizzeSostituite")
                    CreaChiaveDb(c, "PolizzeSostituite", "pk_PolizzeSostituite", {"CodicePuntoVendita", "Ramo", "Polizza"})

                    CancellaChiaveDb(c, "PolizzeCancellate")
                    CancellaIndiciDb(c, "PolizzeCancellate")
                    CreaChiaveDb(c, "PolizzeCancellate", "pk_PolizzeCancellate", {"CodicePuntoVendita", "Ramo", "Polizza"})

                    CancellaChiaveDb(c, "PolizzeRipartizionePremio")
                    CancellaIndiciDb(c, "PolizzeRipartizionePremio")
                    CreaChiaveDb(c, "PolizzeRipartizionePremio", "pk_PolizzeRipartizionePremio", {"CodicePuntoVendita", "Ramo", "Polizza", "CodiceCategoriaRischio"})

                    CancellaChiaveDb(c, "MovimentiPrimaNota")
                    CancellaIndiciDb(c, "MovimentiPrimaNota")
                    CreaChiaveDb(c, "MovimentiPrimaNota", "pk_MovimentiPrimaNota", {"TimestampInserimento"})

                    'senza chiave e indici
                    CancellaChiaveDb(c, "TitoliScopertiNonCassa")
                    CancellaIndiciDb(c, "TitoliScopertiNonCassa")
                    CancellaChiaveDb(c, "PolizzeRipartizioneCoass")
                    CancellaIndiciDb(c, "PolizzeRipartizioneCoass")
                    CancellaChiaveDb(c, "PolizzeRipartizioneCAG")
                    CancellaIndiciDb(c, "PolizzeRipartizioneCAG")
                    CancellaChiaveDb(c, "Pagamenti")
                    CancellaIndiciDb(c, "Pagamenti")
                    CancellaChiaveDb(c, "SubagenziaProduttore")
                    CancellaIndiciDb(c, "SubagenziaProduttore")
                    CancellaChiaveDb(c, "TitoloPNA")
                    CancellaIndiciDb(c, "TitoloPNA")
                    '+debug
                    'Dim dt As DataTable = c.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Indexes, New Object() {Nothing, Nothing, Nothing, Nothing, Nothing})
                    'Dim f As New Utx.FormDebug(dt)
                    'f.ShowDialog()
                End Using
                Return True

            Catch ex As Exception
                Utx.Globale.Log.Info(ex)
                Return False
            End Try
        End Function

        Public Function CreaChiaviSinistri(Agenzia As String) As Boolean
            Try
                Dim Esito As Boolean
                'per sicurezza prima cancello le chiavi e poi le ricreo
                Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Agenzia, ConnessioniDb.Db.SINISTRI))
                    c.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        'le chiavi non possono contenere valori Null
                        cmd.CommandText = "DELETE * FROM SinistriDP WHERE (Compagnia IS NULL) OR (AgenziaSinistro IS NULL) OR (EsercizioSinistro IS NULL) OR (NumeroSinistro IS NULL)"
                        cmd.ExecuteNonQuery()
                    End Using

                    'creo la chiave
                    CancellaChiaveDb(c, "SinistriDP", "pk_sinistri")
                    Esito = CreaChiaveDb(c, "SinistriDP", "pk_sinistri", {"Compagnia", "AgenziaSinistro", "EsercizioSinistro", "NumeroSinistro"})
                End Using

                Utx.Globale.Log.Info(String.Format("Creazione chiavi sinistri. Esito: {0}", Esito))
                Return Esito

            Catch ex As Exception
                Utx.Globale.Log.Info(ex)
                Return False
            Finally
                Utx.Globale.Log.Info()
            End Try
        End Function

        Public Function CreaChiaviClienti(Agenzia As String) As Boolean
            Try
                Dim Esito As Boolean
                'per sicurezza prima cancello le chiavi e poi le ricreo
                Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Agenzia, ConnessioniDb.Db.CLIENTI))
                    c.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        'le chiavi non possono contenere valori Null
                        cmd.CommandText = "DELETE * FROM Clienti WHERE (AgenziaPrevalente IS NULL) OR (CodiceFiscale IS NULL)"
                        cmd.ExecuteNonQuery()
                    End Using

                    'creo la chiave
                    CancellaChiaveDb(c, "Clienti", "pk_clienti")
                    Esito = CreaChiaveDb(c, "Clienti", "pk_clienti", {"AgenziaPrevalente", "CodiceFiscale"})
                End Using

                Utx.Globale.Log.Info(String.Format("{0}: Creazione chiavi clienti. Esito: {1}", Agenzia, Esito))
                Return Esito

            Catch ex As Exception
                Utx.Globale.Log.Info(ex)
                Return False
            Finally
                Utx.Globale.Log.Info()
            End Try
        End Function

        Public Function CreaChiaviPolizze(Agenzia As String) As Boolean
            Try
                Dim Esito As Boolean
                'per sicurezza prima cancello le chiavi e poi le ricreo
                Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Agenzia, ConnessioniDb.Db.POLIZZE))
                    c.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        'le chiavi non possono contenere valori Null
                        cmd.CommandText = "DELETE * FROM Polizze WHERE (Agenzia IS NULL) OR (Ramo IS NULL) OR (Polizza IS NULL)"
                        cmd.ExecuteNonQuery()
                        'creo la chiave
                        CancellaChiaveDb(c, "polizze", "pk_polizze")
                        CreaChiaveDb(c, "Polizze", "pk_polizze", {"Agenzia", "Ramo", "Polizza"})

                        'BDA
                        cmd.CommandText = "DELETE * FROM BDA WHERE Targa IS NULL"
                        cmd.ExecuteNonQuery()
                        'creo la chiave
                        CancellaChiaveDb(c, "BDA", "pk_targa")
                        CancellaChiaveDb(c, "BDA", "ok_targa") 'per correggere un errore di nome. rimuovere a regime
                        Esito = CreaChiaveDb(c, "BDA", "pk_targa", {"Targa"})
                    End Using
                End Using

                Utx.Globale.Log.Info(String.Format("Creazione chiavi polizze. Esito: {0}", Esito))
                Return Esito

            Catch ex As Exception
                Utx.Globale.Log.Info(ex)
                Return False
            Finally
                Utx.Globale.Log.Info()
            End Try
        End Function

        Public Function CreaChiaviNote(Agenzia As String) As Boolean
            Try
                Dim Esito As Boolean
                'per sicurezza prima cancello le chiavi e poi le ricreo
                Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Agenzia, ConnessioniDb.Db.NOTE))
                    c.Open()
                    CancellaChiaveDb(c, "SinistriMemo", "pk_Id")
                    Esito = CreaChiaveDb(c, "SinistriMemo", "pk_Id", {"Id"})
                End Using

                Utx.Globale.Log.Info(String.Format("Creazione chiavi note. Esito: {0}", Esito))
                Return Esito

            Catch ex As Exception
                Utx.Globale.Log.Info(ex)
                Return False
            Finally
                Utx.Globale.Log.Info()
            End Try
        End Function

        Public Function CreaChiaviSupporto() As Boolean
            Try
                'per sicurezza prima cancello le chiavi e poi le ricreo
                Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(ConnessioniDb.Db.SUPPORTO))
                    c.Open()
                    CancellaChiaveDb(c, "Convenzioni", "pk_Convenzione")
                    CreaChiaveDb(c, "Convenzioni", "pk_Convenzione", {"Compagnia", "Codice"})
                    'CancellaChiaveDb(c, "CompagniaANIA", "pk_Compagnia")
                    'CreaChiaveDb(c, "CompagniaANIA", "pk_Compagnia", {"Compagnia"})
                    CancellaChiaveDb(c, "Comuni", "pk_Comune")
                    CreaChiaveDb(c, "Comuni", "pk_Comune", {"IdComune"})
                    CancellaChiaveDb(c, "Ispettorato", "pk_Ispettorato")
                    CreaChiaveDb(c, "Ispettorato", "pk_Ispettorato", {"Ispettorato"})
                    CancellaChiaveDb(c, "Liquidatori", "pk_Codice")
                    CreaChiaveDb(c, "Liquidatori", "pk_Codice", {"Codice"})
                    CancellaChiaveDb(c, "PeritoIncaricato", "pk_Id")
                    CreaChiaveDb(c, "PeritoIncaricato", "pk_Id", {"IdPeritoSAP"})
                    CancellaChiaveDb(c, "Prodotti", "pk_Id")
                    CreaChiaveDb(c, "Prodotti", "pk_Id", {"CodiceProdotto"})
                    CancellaChiaveDb(c, "Province", "pk_Id")
                    CreaChiaveDb(c, "Province", "pk_Id", {"Sigla"})
                    CancellaChiaveDb(c, "TipoRami", "pk_Ramo")
                    CreaChiaveDb(c, "TipoRami", "pk_Ramo", {"CodiceRamo"})
                    CancellaChiaveDb(c, "TipoRamiSinistro", "pk_Ramo")
                    CreaChiaveDb(c, "TipoRamiSinistro", "pk_Ramo", {"RamoSinistro"})
                    CancellaChiaveDb(c, "TipoSinistro", "pk_Id")
                    CreaChiaveDb(c, "TipoSinistro", "pk_Id", {"RamoSinistro", "TipoSinistro"})
                End Using

                Utx.Globale.Log.Info("Creazione chiavi supporto completato")
                Return True

            Catch ex As Exception
                Utx.Globale.Log.Info(ex)
                Return False
            Finally
                Utx.Globale.Log.Info()
            End Try
        End Function

        Public Sub CreaIndice(ByRef c As OleDbConnection,
                              Tabella As String,
                              NomeIndice As String,
                              ListaCampi As String())
            Try
                Dim Campi As String = ""
                For Each campo As String In ListaCampi
                    Campi += String.Format("{0},", campo)
                Next
                Campi = Left(Campi, Campi.Length - 1)

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("CREATE INDEX {0} ON {1} ({2})", NomeIndice, Tabella, Campi)
                    cmd.ExecuteNonQuery()
                End Using
                Utx.Globale.Log.Info(String.Format("Tabella {0} - Indice {1}: creato correttamente", Tabella, NomeIndice))
            Catch ex As Exception
                Utx.Globale.Log.Info(String.Format("Tabella {0} - Indice {1}: Errore >> {2}", Tabella, NomeIndice, ex.Message))
            End Try
        End Sub

        Public Function RamoPolizza2RamoGestione(RamoPolizza As Integer) As Integer
            Return Utx.WsCommand.ExecuteScalar("SELECT RamoGestione 
                FROM DB00000.dbo.RPolToRGest WHERE RamoPolizza = " & RamoPolizza, ValoreDefault:=0).Valore
        End Function
    End Module
End Namespace

Namespace FunzioniFormato

    Public Module Funzioni
        Public Function IsCodiceFiscale(CF As String) As Boolean
            Return CF.ToUpper Like "[A-Z][A-Z][A-Z][A-Z][A-Z][A-Z][0-9][0-9][A-Z][0-9][0-9][A-Z][0-9][0-9][0-9][A-Z]"
        End Function

        Public Function IsPiva(Piva As String) As Boolean
            Return Piva Like "[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]"
        End Function

        Public Function FormatoEuro(numero As Object,
                                    Optional ToZero As Boolean = False) As String
            Try
                If IsNumeric(numero) Then
                    Return CType(numero, Double).ToString("N")
                Else
                    If ToZero = True Then
                        Return 0.ToString("N")
                    Else
                        Return ""
                    End If
                End If
            Catch ex As Exception
                Return ""
            End Try
        End Function

        Public Function FormatoPercento(numero As Double) As String
            Return numero.ToString("P")
        End Function

        Public Function NormalizzaCellulare(Telefono As String) As String
            Try
                'tolgo il +39
                If Telefono.StartsWith("+39") = True Then
                    Telefono = Telefono.Substring(3)
                End If
                'estraggo solo numeri
                Telefono = NetFunc.EstraiCaratteri(Telefono, NetFunc.TipoCaratteri.SoloNumerici)
                If String.IsNullOrEmpty(Telefono) Then
                    Return ""
                End If
                'tolgo il 39 senza segno +
                If Telefono.StartsWith("39") AndAlso Telefono.Length > 10 Then
                    Telefono = Telefono.Substring(2)
                End If
                'se ha meno di 9 cifre è sbagliato
                If Telefono.Length < 9 Then
                    Return ""
                End If
                'normalizza aggiungendo il prefisso dell'italia +39
                Return "+39" & Telefono
            Catch ex As Exception
                Utx.Globale.Log.Info(ex)
                Return ""
            End Try
        End Function
    End Module
End Namespace

Namespace FunzioniRete

    Public Module Funzioni

        Public Function ReteAttivaSiNo() As String
            Return IIf(ReteAttiva() = True, "S", "N")
        End Function

        Public Function PingUniarea() As Boolean
            Try
                Dim Request As HttpWebRequest = HttpWebRequest.Create("https://ws.auaonline.it/public/55467C91D0A1CA484F3217C53958E29A.htm")
                Request.Proxy = Utx.Globale.UniProxy.Proxy
                Request.Timeout = 10000 '10 secondi
                Dim Html As String = New StreamReader(Request.GetResponse.GetResponseStream()).ReadToEnd.ToUpper

                Dim Esito As Boolean = Html.Contains("55467C91D0A1CA484F3217C53958E29A")
                If Esito = True Then
                    Globale.Log.Info("Ping auaonline OK")
                    Return True
                Else
                    Globale.Log.Info("Ping auaonline fallito.")
                    Return True
                End If

            Catch wex As Net.WebException
                Globale.Log.Info("Ping auaonline: " & wex.Status.ToString)
                Return False
            Catch ex As Exception
                Globale.Log.Info("Ping auaonline fallito con errore: " & ex.Message)
                Return False
            End Try
        End Function

        Public Function PcInDominio() As Boolean
#If DEBUG Then
            Return False
#Else
            Return (Environment.UserDomainName.ToUpper = "UNIAGE") OrElse (Environment.UserDomainName.ToUpper = "AURAGE")
#End If
        End Function

        Public Function ReteAttiva() As Boolean
            Return (Utx.Setting.Ambiente <> Utx.Enumerazioni.TipoAmbiente.PP)
        End Function

        Public Function UrlRaggiungibile(Url As String) As Boolean
            Try
                Dim res As Net.WebResponse = Net.WebRequest.Create(Url).GetResponse
                Return True

            Catch ex As System.Net.WebException
                Try
                    Globale.Log.Info(ex.Message)
                    Globale.Log.Info(ex.Status.ToString)

                    Select Case ex.Status
                        Case WebExceptionStatus.NameResolutionFailure, WebExceptionStatus.ConnectFailure, WebExceptionStatus.Timeout
                            Return False
                            'Case WebExceptionStatus.ProtocolError
                            '    Return True
                        Case Else
                            Select Case DirectCast(ex.Response, System.Net.HttpWebResponse).StatusCode
                                Case HttpStatusCode.ProxyAuthenticationRequired, HttpStatusCode.Forbidden
                                    Return True
                                Case Else
                                    Return False
                            End Select
                    End Select
                Catch ex2 As Exception
                    Return False
                End Try
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Module
End Namespace

Namespace FunzioniAmbiente

    Public Module Funzioni
        Declare Unicode Function GetShortPathName Lib "kernel32.dll" Alias "GetShortPathNameW" (longPath As String, <MarshalAs(UnmanagedType.LPTStr)> ShortPath As System.Text.StringBuilder, <MarshalAs(UnmanagedType.U4)> bufferSize As Integer) As Integer

        Public Function AgenziaSedePc() As String
            Return String.Format("{0}-{1}", Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Utx.Globale.ProfiloEnteGestore.CodiceSede)
        End Function

        Public Function PcToAgenzia() As String
            Try
                If Left(Environment.MachineName, 4) = "ASSI" Then
                    'si tratta di assicoop
                    Dim s As New SettingAgenzia.ConfiguraSede
                    Return s.Assicoop2Codice(Environment.MachineName.Split("-")(0))
                Else
                    'agenzie private
                    Dim Agenzia As String = HostName().Split("-")(0)

                    If Agenzia.Length = 6 Then 'ex unipol/navale

                        If Agenzia.StartsWith("U", StringComparison.InvariantCultureIgnoreCase) OrElse
                           Agenzia.StartsWith("1") Then
                            'se l'host name comincia per U/1 si tratta di ex-unipol
                            Return Agenzia.Substring(1, 5)

                        ElseIf Agenzia.StartsWith("7") Then
                            'ex-navale: estraggo il valore e sommo 70000
                            Return Format(Val(Agenzia.Substring(1, 5)) + 70000, "00000")
                        Else
                            Return "" 'c'è un errore
                        End If

                    Else 'ex-aurora: è lungo 5 e non inizia per U
                        Return Agenzia
                    End If
                End If

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return ""
            End Try
        End Function

        Public Function PcToSede() As String
            Try
                If Utx.FunzioniRete.PcInDominio Then
                    If Utx.NetFunc.GetEnvironmentVar("UNIVAR").Length > 0 Then
                        'è presente la variabile UNIVAR
                        Return Utx.NetFunc.GetEnvironmentVar("UNIVAR").Split("-")(1)
                    Else
                        Return Environment.MachineName.Split("-")(1)
                    End If
                Else
                    Return "00" 'fuori dalla intranet sono tutti uguali (e con nomi fantasiosi)
                End If

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return ""
            End Try
        End Function

        Public Function UserToAgenzia() As String
            Return Mid(Utx.Globale.UtenteCorrente.UniageUser, 2, 5)
        End Function

        Public Function UserToAgenzia(UniageUser) As String
            Return Mid(UniageUser, 2, 5)
        End Function

        Public Function UserToCompagnia() As String
            Return Left(Utx.Globale.UtenteCorrente.UniageUser, 1)
        End Function

        Public Function HostName() As String
            Try
                If EsisteUnivar() = True Then
                    Return NetFunc.GetEnvironmentVar("UNIVAR")
                Else
                    Return System.Environment.MachineName
                End If

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return "U99999-99-99"
            End Try
        End Function

        Public Function EsisteUnivar() As Boolean
            Return (NetFunc.GetEnvironmentVar("UNIVAR").Trim.Length > 0)
        End Function

        Public Function Path83(LongPath As String) As String

            Try
                Dim sbShortPath As StringBuilder = New StringBuilder(256)
                GetShortPathName(LongPath, sbShortPath, sbShortPath.Capacity)

                Return sbShortPath.ToString

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
                Return ""
            End Try
        End Function

        Public Function EsisteForm(NomeForm As String) As Boolean
            Try
                For Each f As Form In Application.OpenForms
                    If f.Name = NomeForm Then Return True
                Next

                Return False

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
                Return False
            End Try
        End Function

        Public Function RichiestaForm(NomeForm As String) As Form
            Try
                For Each f As Form In Application.OpenForms
                    If f.Name = NomeForm Then
                        Return f
                    End If
                Next

                Return Nothing

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
                Return Nothing
            End Try
        End Function

        Public Sub CreaCollegamento(TargetName As String, ShortCutPath As String, ShortCutName As String)
            Try
                Dim oShell As Object = CreateObject("WScript.Shell")
                Dim oLink As Object = oShell.CreateShortcut(ShortCutPath & "\" & ShortCutName & ".lnk")

                oLink.TargetPath = TargetName
                oLink.WindowStyle = 1
                oLink.Save()
            Catch ex As Exception
                Utx.Globale.Log.Info(ex)
            End Try
        End Sub

        Public Sub Play(key As String)
            Dim FileAudio As String = String.Format("{0}\{1}.wav", Utx.Globale.Paths.CartellaModelli, key)
            If File.Exists(FileAudio) Then
                My.Computer.Audio.Play(FileAudio, AudioPlayMode.Background)
            End If
        End Sub
    End Module
End Namespace

Namespace Sviluppo

    Public Module Funzioni

        Private TraceFile As String = Path.Combine(Utx.Globale.Paths.CartellaLogs, "Trace.log")

        Public Enum ProcEvent
            ENTRATA = 0
            USCITA = 1
            MARCATORE_1 = 2
        End Enum

        Public Sub AddLog(Messaggio As String)
            Dim Testo As String = LogMsg(Messaggio)
            File.AppendAllText(TraceFile, Testo)
        End Sub

        Private Function LogMsg(Messaggio As String)
            'aggiungo intestazione riga con data e ora e a capo
            LogMsg = String.Format("[{0} {1}]{2}{3}", Now.ToShortDateString, Now.ToLongTimeString, Messaggio, Environment.NewLine)
        End Function

        Public Sub LogProc(Metodo As Reflection.MethodBase, Azione As ProcEvent)
            Dim Passo As Integer = 3
            Static Indent As Integer = -Passo

            Select Case Azione
                Case ProcEvent.ENTRATA
                    Indent += Passo
                    AddLog(String.Format("{0}Entra: {1}",
                                         Space(Indent),
                                         Trim(Replace(Metodo.ToString, "void", "", , , CompareMethod.Text))))
                Case ProcEvent.USCITA
                    AddLog(String.Format("{0}Esce : {1}", Space(Indent), Metodo.Name.Trim))
                    Indent -= Passo
                Case ProcEvent.MARCATORE_1
                    AddLog(String.Format("{0}>>> : {1}", Space(Indent), Azione.ToString))
            End Select
        End Sub
    End Module
End Namespace
