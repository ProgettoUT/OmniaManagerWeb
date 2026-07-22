Imports System.IO
Imports System.Net
Imports System.Data

Public Class GiornaleCassa

    Public OpzioniScarico As ExportLib.ConfigScaricoIncassi

    Private WithEvents e As New ExportEventArgs
    Private WithEvents Essig As RichiesteEssig

    Private dt As New DataTable

    Public Sub New()
        dt.Columns.Add("Data", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("PuntoVendita", System.Type.GetType("System.Int32"))
        dt.Columns.Add("Cassa", System.Type.GetType("System.String"))
        dt.Columns.Add("OraEsito", System.Type.GetType("System.String"))
        dt.Columns.Add("HH", System.Type.GetType("System.Int32"))
        dt.Columns.Add("Giornata", System.Type.GetType("System.String"))
    End Sub

    Private mCookie As CookieContainer
    Public Property Cookie() As CookieContainer
        Get
            Return mCookie
        End Get
        Set(value As CookieContainer)
            mCookie = value
        End Set
    End Property

    Public Sub AnalisiFasceOrarie(Agenzia As String, Giorno As Date)
        Dim Inizio As Date = Utx.FunzioniData.InizioMese(Giorno)
        Dim Fine As Date = Utx.FunzioniData.FineMese(Giorno)

        Dim Data As Date = Inizio

        Do While Data <= Fine
            ImportaDati(ScaricaDati(Agenzia, Data), Data)
            Data = Data.AddDays(1)
        Loop

        Dim f As New Utx.FormDebug(dt)
        f.ShowDialog()

        Dim Fasce As New DataTable
        Fasce.Columns.Add("PuntoVendita", System.Type.GetType("System.Int32"))
        Fasce.Columns.Add("Ora", System.Type.GetType("System.Int32"))
        Fasce.Columns.Add("Incassi", System.Type.GetType("System.Int32"))
        Fasce.PrimaryKey = {Fasce.Columns("PuntoVendita"), Fasce.Columns("Ora")}

        For Each row As DataRow In dt.Rows
            'casse più lunghe in genere sono rid o direzione
            If row("Cassa").ToString.Length = 2 Then
                Dim dr As DataRow = Fasce.Rows.Find({row("PuntoVendita"), row("HH")})

                If dr Is Nothing Then
                    Fasce.Rows.Add(row("PuntoVendita"), row("HH"), 1)
                Else
                    dr("Incassi") += 1
                End If
            End If
        Next

        f.OrigineDati = Fasce
        f.ShowDialog()
    End Sub

    Private Function ScaricaDati(Agenzia As String, Giorno As Date) As String
        Try
            Dim FileScaricati As New List(Of String)
            Dim FileDati As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "GiornaleCassa.csv")

            'chiamo il menù: necessario per settaggio parametri
            Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.GIORNALECASSA)
            Essig.ChiamaMenu()
            If Essig.EventArgs.Errore = True Then
                e = Essig.EventArgs
                Return ""
            End If

            'richiedo i dati
            Essig.RichiestaDati(Agenzia, Giorno)
            If Essig.EventArgs.Errore = True Then
                e = Essig.EventArgs
                Return ""
            End If

            'salvo il file nella cartella temporanea
            Using sw As New StreamWriter(FileDati)
                sw.Write(Essig.EsportaDati)
            End Using
            If e.Errore = True Then
                Return ""
            End If

            Return FileDati

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
            Return ""
        End Try
    End Function

    Private Sub ImportaDati(FileDati As String, Giorno As Date)
        Try
            Dim Giornata As String = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(Giorno.DayOfWeek)

            'apro lo stream
            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                'leggo l'intestazione che non mi serve
                sr.ReadLine()

                Dim Campi() As String

                Do While Not sr.EndOfStream

                    Dim Riga As String = sr.ReadLine

                    'controllo perché capita di avere una riga vuota specialmente in coda
                    If Riga.Trim.Length > 0 Then

                        Campi = Riga.Split(";")
                        'trimma tutto
                        TrimArray(Campi)

                        Dim dr As DataRow = dt.NewRow

                        dr("Data") = Giorno
                        dr("PuntoVendita") = Utx.FunzioniDb.NullToNumber(Campi(Tracciati.ESITATI.PuntoVendita))
                        dr("Cassa") = Campi(Tracciati.ESITATI.CodiceCassa)
                        dr("OraEsito") = Campi(Tracciati.ESITATI.OraEsito)
                        dr("HH") = Left(dr("OraEsito"), 2)
                        dr("Giornata") = Giornata

                        dt.Rows.Add(dr)
                    End If
                Loop
            End Using

            File.Delete(FileDati)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub
End Class
