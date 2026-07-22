Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class NetFunc

    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr,
                                         ByVal hWndInsertAfter As IntPtr,
                                         ByVal X As Integer, ByVal Y As Integer,
                                         ByVal cx As Integer, ByVal cy As Integer,
                                         ByVal uFlags As Integer) As Boolean
    End Function

    Private Const SWP_NOSIZE As Integer = &H1
    Private Const SWP_NOMOVE As Integer = &H2

    Private Shared ReadOnly HWND_TOPMOST As New IntPtr(-1)
    Private Shared ReadOnly HWND_NOTOPMOST As New IntPtr(-2)
    '--------------------------------------------------------------------

    Public Shared Function AltraIstanza(ByVal NomeProcesso As String) As Boolean

        Dim NumeroProcessi As Integer = 0

        NomeProcesso = NomeProcesso.Split(".")(0).ToUpper

        Try
            For Each process As Object In GetObject("winmgmts:").ExecQuery("Select * From Win32_Process")

                If NomeProcesso = process.caption.Split(".")(0).ToUpper Then
                    NumeroProcessi += 1
                End If
            Next

        Catch ex As Exception
            Dim AppLog As New ApplicationLog("C:\ApplicazioniDirezione\Unitools\Logs", "NetFunc.log")
            AppLog.AddLog(ex)
        End Try

        'i processi devono essere più di uno perché trova sempre anche se stesso
        Return (NumeroProcessi > 1)

    End Function

    'Public Shared Function AltraIstanzaUtente(ByVal NomeProcesso As String) As Boolean

    '    Dim NumeroProcessi As Integer = 0
    '    Dim Utente As String = Environment.UserName.ToUpper

    '    NomeProcesso = NomeProcesso.ToUpper

    '    For Each process As Object In GetObject("winmgmts:").ExecQuery("Select * From Win32_Process")

    '        Try
    '            If NomeProcesso = Path.GetFileNameWithoutExtension(process.caption).ToUpper Then

    '                'ricavo proprietario del processo
    '                Dim owner As Object = Nothing
    '                process.GetOwner(owner)

    '                If owner.ToString.ToUpper = Utente Then
    '                    NumeroProcessi += 1
    '                End If
    '            End If

    '        Catch ex As Exception
    '            Dim AppLog As New ApplicationLog("C:\ApplicazioniDirezione\Unitools\Logs", "NetFunc.log")
    '            AppLog.AddLog(ex)
    '        End Try

    '    Next

    '    'i processi devono essere più di uno perché trova sempre anche se stesso
    '    Return (NumeroProcessi > 1)

    'End Function

    Public Shared Function MaxDate(ByVal Data1 As Date, ByVal Data2 As Date) As Date
        Return New DateTime(Math.Max(Data1.Ticks, Data2.Ticks))
    End Function

    Public Shared Function MinDate(ByVal Data1 As Date, ByVal Data2 As Date) As Date
        Return New DateTime(Math.Min(Data1.Ticks, Data2.Ticks))
    End Function

    Public Shared Function GetEnvironmentVar(ByVal VarName As String) As String
        If Environment.GetEnvironmentVariable(VarName) = Nothing Then
            GetEnvironmentVar = ""
        Else
            GetEnvironmentVar = Environment.GetEnvironmentVariable(VarName)
        End If
    End Function

    Friend Shared Function ImpostaProxy() As System.Net.WebProxy
        Return New System.Net.WebProxy("proxyu.ha.servizi.gr-u.it", 80)
    End Function

    Friend Shared Function ImpostaCredenziali(ByVal User As String,
                                              ByVal Pw As String,
                                              ByVal IdAmbiente As Globale.TipoAmbiente) As System.Net.NetworkCredential

        If IdAmbiente = Globale.TipoAmbiente.DIR Then
            Return System.Net.CredentialCache.DefaultCredentials
        Else
            Return New System.Net.NetworkCredential(User, Pw, "uniage")
        End If

    End Function

    'Public Shared Sub ZipFile(ByVal FileOrigine As String, ByVal FileDest As String)

    '    If Not File.Exists(FileOrigine) Then Exit Sub

    '    'se il file è già zippato
    '    If Path.GetExtension(FileOrigine) = ".zip" Then
    '        File.Copy(FileOrigine, FileDest)
    '        Exit Sub
    '    End If

    '    Try
    '        Dim oZip As New CGZipLibrary.CGZipFiles
    '        With oZip
    '            'zippa il file con nome *.zip
    '            .ZipFileName = FileDest
    '            .UpdatingZip = False
    '            .IgnorePath = True 'non memorizza il path origine

    '            .AddFile(FileOrigine)

    '            If .MakeZipFile = 0 Then
    '                'tutto ok
    '            Else
    '                MsgBox(oZip.GetLastMessage, vbCritical) 'visualizza qualsiasi errore
    '            End If
    '        End With

    '    Catch ex As Exception
    '        MsgBox("Attenzione: si è verificato un errore inatteso." + vbNewLine + _
    '               "Non è stato possibile comprimere il file <" + FileOrigine + ">.", vbExclamation)
    '    End Try

    'End Sub

    'Public Shared Sub UnZipFile(ByVal FileOrigine As String, ByVal CartellaDestinazione As String)

    '    If Not File.Exists(FileOrigine) Then Exit Sub

    '    Try
    '        Dim oUnZip As New CGZipLibrary.CGUnzipFiles
    '        With oUnZip
    '            .ZipFileName = FileOrigine
    '            .ExtractDir = CartellaDestinazione

    '            If .Unzip <> 0 Then
    '                MsgBox(oUnZip.GetLastMessage, vbCritical) 'visualizza qualsiasi errore
    '            End If
    '        End With

    '    Catch ex As Exception
    '        Globale.Log.BoxErrore(ex, False)
    '    End Try

    'End Sub

    Public Shared Function FileToMD5(ByVal FilePath As String) As String

        Try
            If Not File.Exists(FilePath) Then Return "-ERR"

            Dim md5 As New MD5CryptoServiceProvider

            Using f As New FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
                md5.ComputeHash(f)
                f.Close()
            End Using

            Dim hash As Byte() = md5.Hash
            Dim buffer As StringBuilder = New StringBuilder

            For Each hashByte As Byte In hash
                buffer.Append(String.Format("{0:X2}", hashByte))
            Next

            Return buffer.ToString()

        Catch ex As Exception
            Return "-ERR"
        End Try

    End Function

    Public Shared Function StringToMD5(ByVal Stringa As String) As String

        Try
            'istanza dell'oggetto
            Dim md5 As New Security.Cryptography.MD5CryptoServiceProvider()

            'array di byte da passare all'oggetto md
            'converto la stringa passata in modo da prelevare i singoli byte che verranno
            'passati alla funzione per calcolare l'md5
            Dim Stringa_inByte() = System.Text.Encoding.UTF8.GetBytes(Stringa)

            'calcolo l'mdd5 (restituisce un array di byte)
            Dim hash As Byte() = md5.ComputeHash(Stringa_inByte)

            Dim buffer As StringBuilder = New StringBuilder

            For Each hashByte As Byte In hash
                buffer.Append(String.Format("{0:X2}", hashByte))
            Next

            Return buffer.ToString

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Shared Sub FinestraOnTop(ByVal HandleFinestra As Long,
                                    ByVal TopMost As Boolean)

        On Error Resume Next

        If TopMost = True Then
            'porta la finestra in primo piano
            SetWindowPos(HandleFinestra, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
        Else
            'sblocca l'opzione sempre in primo piano
            SetWindowPos(HandleFinestra, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
        End If

    End Sub

    Public Shared Function Abilitazione(ByVal CostanteAbilitazione As Integer) As Boolean
        Return (Val(GetEnvironmentVar("ABILITAZIONE_CHECK")) And CostanteAbilitazione) > 0
    End Function

    Public Shared Sub DoppioBuffer(ByRef dgv As DataGridView)

        dgv.GetType.InvokeMember("DoubleBuffered",
                                 Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, dgv,
                                 New Object() {True})
    End Sub

    Public Shared Sub Esporta2Excel(ByVal DataGrid() As Object,
                                    ByVal NomeFoglio() As String,
                                    ByVal NomeFile As String,
                                    ByVal ColoreSfondoProgressBar As Drawing.Color)

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
                            MsgBox("Esportazione in formato Excel conclusa correttamente.",
                                   MsgBoxStyle.Information, "Esportazione dati")
                        End If
                    Else
                        'senza questa riga c'è la richiesta automatica di salvataggio
                        excelBook.Saved = True
                    End If
                End With

            Catch ex As Exception
                'errore 1004 quando il file esiste e si risponde NO alla sostituzione
                If Err.Number <> 1004 Then
                    Globale.Log.BoxErrore(ex)
                End If

                excelBook.Saved = True
            Finally
                excelBook.Close()
                excelBook = Nothing
                excelApp = Nothing
            End Try

        Catch ex As Exception
            Globale.Log.AddLog(ex.Message)
        End Try

    End Sub

    Public Shared Function ColonnaStileExcel(ByVal ColumnNumber As Integer) As String
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
            ' Columns A-Z
            ColonnaStileExcel = Chr(ColumnNumber + 64)
        End If
    End Function

    Public Shared Function ColorToHex(ByVal Colore As Drawing.Color) As String
        Return String.Format("#{0:X2}{1:X2}{2:X2}", Colore.R, Colore.G, Colore.B)
    End Function

    Public Shared Function PcInDominio() As Boolean
        Return (Environment.UserDomainName.ToUpper = "UNIAGE") OrElse (Environment.UserDomainName.ToUpper = "AURAGE")
    End Function
End Class
