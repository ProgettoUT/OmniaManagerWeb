#If DEBUG Then
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization

<TestClass>
Public Class Test01
    Public TestContext As TestContext


    <TestMethod>
    Public Sub CreaCumuloMA()
        Inizializza()
        Dim cumulatore = New Cumulatore
        cumulatore.CreaFiles()
        Assert.IsTrue(True)
    End Sub

    <TestMethod>
    Public Sub StoricizzaDbUno()
        Inizializza()
        Dim agenzia As New Utx.AgenziaFigliaOmnia("02379")
        Dim database As New Database(agenzia)
        Storico.creaLink(agenzia)
        'Storico.ArchiviaPolizze(agenzia)
        'Storico.ArchiviaTabelle(agenzia)
        Dim tabelle As String() = {"polizze1", "polizze2", "polizze3", "polizze4", "sinistri", "titoli"}

        For Each tabella As String In tabelle
            Storico.RestoreTabella(tabella, agenzia)
        Next


        Assert.IsTrue(True)
    End Sub


    <TestMethod>
    Public Sub CercaInFileOmnia()
        Inizializza()

        'Dim f As New FileIntoDatabase()
        'f.PubblicaTTYCreo()

        Dim f As New CercaInFiles()
        f.ShowDialog()

        'Dim scansione As New Scansione()
        ''scansione.TipiRecord.Add("00")
        'scansione.Contiene = "SABRINA"
        'scansione.ChiaveValore.Add("CodiceFiscale", "")
        'scansione.ChiaveValore.Add("Cognome", "")
        'scansione.ChiaveValore.Add("Nome", "")
        'scansione.ChiaveValore.Add("IndirizzoComune", "")
        'scansione.ChiaveValore.Add("IndirizzoCap", "")
        'scansione.DataInizio = #1/1/2017#
        'scansione.DataFine = #5/31/2017#
        'scansione.Cerca()
        Assert.IsTrue(True)
    End Sub


    <TestMethod>
    Public Sub ImportaFileInDbUno()
        Inizializza()

        'With New Database(New Utx.AgenziaFigliaOmnia("02379"))
        '    Dim specifica As New Specifica()
        '    For Each File In specifica.Files.Values
        '        If File.SelectCaseStart = 1 Then
        '            For Each tracciato In File.Tracciati.Values
        '                For Each tabella In tracciato.Tabelle
        '                    Dim sql As String = ""
        '                    For Each campo In tabella.Campi.Values
        '                        If Not campo.Nome.ToUpper.StartsWith("FILLER") And _
        '                           Not campo.Nome.ToUpper.StartsWith("TIPORECORD") Then
        '                            sql &= String.Format(", {0} CHAR({1}) ", campo.Nome, campo.Lunghezza)
        '                        End If
        '                    Next
        '                    sql = "Create Table " & tabella.Nome & " (" & sql.Substring(1) & ")"
        '                    '.Aggiorna("DROP TABLE " & tabella.Nome)
        '                    '.Aggiorna(sql)
        '                    Debug.Print(sql)
        '                Next
        '            Next
        '        End If
        '    Next
        'End With

        'With New Database(New Utx.AgenziaFigliaOmnia("02379"))
        '    .Aggiorna("DELETE FROM arp002_file WHERE nome in ('MA102379180301080.ZIP', 'MA102379180301.080')")
        'End With

        'Utx.ApplicationLog.LivelloLog = Utx.ApplicationLog.Livello.DEBUG
        Dim ImportaFiles = New FileIntoDatabase
        'ImportaFiles.ImportaTutto(#8/16/2016#, #8/16/2016#, FileIntoDatabase.TIPORECORD_SINISTRI)
        'ImportaFiles.ImportaTutto(#8/16/2016#, #8/16/2016#)
        'ImportaFiles.ImportaTutto(#1/1/2018#, #12/31/2018#, FileIntoDatabase.TIPORECORD_TITOLI, "02379")
        ImportaFiles.ImportaTutto()

        Assert.IsTrue(True)
    End Sub

    <TestMethod>
    Public Sub schemadb()
        'Dim conString = "Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=C:\ApplicazioniDirezione\UT\ArchivioDati\02379\OMNIA\dbUno.mdb"
        Dim conString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\ApplicazioniDirezione\UT\Dati\02379\clienti.mdb"

        Using connection As New OleDb.OleDbConnection(conString)
            connection.Open()

            Dim table As DataTable = connection.GetSchema("Columns", {Nothing, Nothing, "Clienti1"})

            ' Display the contents of the table.
            For Each row As DataRow In table.Rows
                Debug.Print("{0}\t{1}\t{2}", row("COLUMN_NAME"), Utx.AnalisiDb.TipoCampo(row("DATA_TYPE")), row("CHARACTER_MAXIMUM_LENGTH"))
            Next
            'Debug.Print("============================")

            '' Display the contents of the table.
            'For Each row As DataRow In table.Rows
            '    For Each col As DataColumn In table.Columns
            '        Debug.Print("{0} = {1}", col.ColumnName, row(col))
            '    Next
            '    Debug.Print("============================")
            'Next

            'Dim PrimaryKeys As DataTable = connection.GetSchema("Indexes", {Nothing, Nothing, Nothing, Nothing, "incassi"})
            'For Each row As DataRow In PrimaryKeys.Rows
            '    For Each col As DataColumn In PrimaryKeys.Columns
            '        Debug.Print("{0} = {1}", col.ColumnName, row(col))
            '    Next
            '    Debug.Print("============================")
            'Next

        End Using
    End Sub

    <TestMethod>
    Public Sub DecodeRow()
        'Dim sRow As String = "201903070237901230301248816992019011500320190115320200115        20190117        IT        000000000318,390+000000000000,000+000000000000,000+000000000394,000+000000000000,000+000000000000,000+000000000000,000+000000000041,040+000000000026,940+300C              J20190117         0040100305000000000000000000   000000000000,000+  000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00000000000000000000000,000+000000000000,000+000000000000,000+000000000000,000+000,00BRMFNC62R31B157JABRAMI FRANCO            100000    20190115000000,0000000000000                                                                                                                                                                                                                                                                                                                                 000,00000,00000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+00000000000000000,000+000000000000,000+000000000008,010+87214N2020011518991230EP869XL              24.00.0024.00.00000000000256,730+000000000022,580+000000000000,000+000000000000,000+000000000000,080+000000000000,000+000000000000,000+000000000000,000+000000000061,580+000000000018,460+000000000033,750-0000000000,000+            00000000A031271170000000000000000001                 *"
        Dim sRow As String = "20191129023790113231000049977450000000009013000001000          09012N20151025202010252020102520151022201710250000000020161025  0000000000000000  00000000000000000000231000045645000000000000000000000000000000000000000000000000000000000000000240005300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002445640234     CENTRO SERVIZI CGIL SRL*VIA LUIGI SETTEMBRINI 6*37123 VERONA VR    3712330010000000024082000000000000000000000000000000000024082000000002408200000000273340000000000000210030000000024082000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000D0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000                  GDZ 979 NZ           00101 0000000000000000 B01500000000000000000000000    SUZ0083882200911200911N****************L78100000000N 000000 000000 000000000 00000000000000000 000VR000 00000000000000000000000000000000000000000000000005722000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000050000000000000000000250000000010000000000002408200000 0000000000000000000000000000000000000000000000000000000000 SWIFT (2005-200000000020191025 0000 0000000       U    0000000000000  00000  00000000000000000000000000000000000000000                          00000   S 0000000 00000000          00000000N1           0000000000000000000000            0000000000000000000000             0000000000000000000000 KASKO       0000002500000000000000             0000000000000000000000             0000000000000000000000             0000000000000000000000000000000000000000 00000000000            00000000000            00000000000             00000000000             00000000000                          00000000000000000000000000000000000000000000      0000000    00000000000      00000000000   000            00000000000 00000000000000            0000000000000000000000000            0000000000000000000000000            0000000000000000000000000            0000000000000000000000000            0000000000000000000000000            0000000000000000000000000            0000000000000000000000000            0000000000000000000000000             00000000000000             000000000000000000000000000000000000000000000000005000000000000000000000                                         000000            0000000000000000000000000            0000000000000000000000000            00000000000000            0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000 000000000000000000000000000000000000000000000000000000000000000000000000000 000000000000                              0 000     0000000000000000000000000  0000000            000                 00000000               NN 10011170587500000000000000000000000000                              N000                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                *"

        Inizializza()

        Using connection As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=C:\ApplicazioniDirezione\UT\ArchivioDati\02379\OMNIA\dbUno.mdb")
            connection.Open()

            Dim specifica = New Specifica(connection)

            Dim oFile As File = specifica.Files.GetFileByPattern("MA102379160530.004")
            Dim oTracciato = oFile.GetTracciatoByInput(sRow)
            StampaCampi(oTracciato.Campi, 1, sRow)

        End Using
        Assert.IsTrue(True)
    End Sub

    Private Sub StampaCampi(ByRef oCampi As Campi, ByRef nPos As Integer, ByRef sRow As String)

        For Each oCampo In oCampi.Values
            If Not oCampo.CampoCalcolato Then
                If oCampo.Occorrenze = 1 Then
                    If oCampo.HasChild Then
                        StampaCampi(oCampo.Campi, nPos, sRow)
                    Else
                        oCampo.Valore = Mid(sRow, nPos, oCampo.Lunghezza)
                        Debug.Print(Format(nPos, "00000") & ": " & oCampo.DettaglioCampo4Debug())
                        nPos = nPos + oCampo.Lunghezza
                    End If
                Else
                    For i = 1 To oCampo.Occorrenze
                        With oCampo.Campi(oCampo.Nome & i)
                            If .HasChild Then
                                StampaCampi(.Campi, nPos, sRow)
                            Else
                                .Valore = Mid(sRow, nPos, .Lunghezza)
                                Debug.Print(Format(nPos, "00000") & ": " & oCampo.DettaglioCampo4Debug())
                                nPos = nPos + .Lunghezza
                            End If
                        End With
                    Next
                End If
            End If
        Next
    End Sub

    Public Sub Inizializza()
        Utx.Globale.IdApp(System.Text.Encoding.UTF8.GetString(New Byte() {57, 60, 88, 93, 65, 58, 71}))
        Utx.Globale.Paths = New Utx.ApplicationPath
        Utx.Globale.Paths.Inizializza("C:\ApplicazioniDirezione\UT", "X", "M")
        Utx.Globale.UtenteCorrente = New Utx.Utente
        Utx.Globale.SettingGlobale = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.GLOBALE)
        Utx.Globale.SettingInterop = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.INTEROP)
        Utx.Globale.UniProxy = New Utx.Proxy()
        Utx.Globale.ProfiloEnteGestore = New Utx.EnteGestore
        'Utx.Globale.AgenziaRichiesta = New Utx.Agenzia(CInt(Utx.Globale.ProfiloEnteGestore.AgenziaMadre))
        Utx.Globale.AgenziaRichiesta = New Utx.Agenzia(2379)
        Utx.Globale.Log = New Utx.ApplicationLog("Unitools", Nothing, Nothing, True)
        UniFeed.Globale.Log = Utx.Globale.Log
        'Utx.Globale.ProfiloEnteGestore.Abilitazioni.LeggiAbilitazioni() '++???????
    End Sub


    <TestMethod>
    Public Sub NormalizzaTabelleDecodifica()
        Dim data As String = Format(Now, "yyMMdd")
        Dim path As String = "C:\Sviluppo\UniTools\OmniaFiles\"

        Dim sorgente1 As Byte() = IO.File.ReadAllBytes(path & "OMNIA.TXT")
        Dim sorgente2 As Byte() = IO.File.ReadAllBytes(path & "OMNIA.TREC82.TXT")

        Dim sorgente(sorgente1.Length + sorgente2.Length - 1) As Byte

        System.Buffer.BlockCopy(sorgente1, 0, sorgente, 0, sorgente1.Length)
        System.Buffer.BlockCopy(sorgente2, 0, sorgente, sorgente1.Length, sorgente2.Length)

        For i As Integer = 0 To sorgente.Length - 1
            Select Case sorgente(i)
                Case 10, 13
                Case Is < 32
                    sorgente(i) = 32
                Case 63, 128
                    sorgente(i) = 32
                Case Is = 195
                    sorgente(i) = 65
            End Select
        Next

        Dim nomeFileMe As String = String.Format("{0}ME100000{1}.001", Path, Data)
        Dim nomeFileZip As String = String.Format("ME100000{0}001.ZIP", data)

        IO.File.WriteAllBytes(nomeFileMe, sorgente)
        Utx.LibreriaZip.SevenZip.ZipFile(nomeFileMe, path & nomeFileZip)

        Dim contenuto As String = String.Format("<?xml version=""1.0"" encoding=""UTF-8""?><files><file>{0}</file></files>", nomeFileZip)
        IO.File.WriteAllText(path & "ListaFiles.xml", contenuto)

        If IO.File.Exists(nomeFileMe) Then
            IO.File.Delete(nomeFileMe)
        End If
    End Sub


    <TestMethod>
    Public Sub Esporta()
        'Dim s = "abcdefghilmnopqrstuvz"
        'Mid(s, 10, 3) = "AA"
        'MsgBox(s)

        Inizializza()
        Dim a As New Esporta()
        'a.EsportaClienti()
        'a.EsportaIncassi()
        a.EsportaPolizze()
        Assert.IsTrue(True)
    End Sub

    <TestMethod>
    Public Sub ImportaListaDaSia()
        Inizializza()
        Dim lista As String() = Utx.SIA.ListaFileInviati("02379", #01/01/2019#, #12/31/2019#)
        Assert.IsTrue(True)
    End Sub

    <TestMethod>
    Public Sub testFtpSia()
        ' Setup session options
        Dim sessionOptions As New WinSCP.SessionOptions
        With sessionOptions
            .Protocol = WinSCP.Protocol.Sftp
            .HostName = "services.siaspa.com"
            .UserName = "uniarea"
            .Password = "QZSWwh8HDA9W"
            '.SshHostKeyFingerprint = "ssh-rsa 2048 xx:xx:xx:xx:xx:xx:xx:xx..."
            .GiveUpSecurityAndAcceptAnySshHostKey = True

            'https://winscp.net/eng/docs/rawsettings
            .AddRawSettings("ProxyMethod", "3")
            .AddRawSettings("ProxyHost", "xxxx")
            .AddRawSettings("ProxyUsername", "xxxxx")
            .AddRawSettings("ProxyPassword", "xxxxx")

        End With

        Using session As New WinSCP.Session
            ' Will continuously report progress of synchronization
            'AddHandler session.FileTransferred, AddressOf FileTransferred

            ' Connect
            session.Open(sessionOptions)

            'Dim directory As WinSCP.RemoteDirectoryInfo = session.ListDirectory("/upload")

            'Dim fileInfo As WinSCP.RemoteFileInfo
            'For Each fileInfo In directory.Files
            '    Console.WriteLine(
            '        "{0} with size {1}, permissions {2} and last modification at {3}",
            '        fileInfo.Name, fileInfo.Length, fileInfo.FilePermissions,
            '        fileInfo.LastWriteTime)
            'Next


            ' Synchronize files
            Dim synchronizationResult As WinSCP.SynchronizationResult
            synchronizationResult = session.SynchronizeDirectories(WinSCP.SynchronizationMode.Remote, "C:\ApplicazioniDirezione\UT\Preventivi", "/upload", False)

            ' Throw on any error
            synchronizationResult.Check()
        End Using

        Assert.IsTrue(True)
    End Sub
End Class



#End If
