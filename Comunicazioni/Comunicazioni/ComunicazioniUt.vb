Imports System.Net
Imports System.IO
Imports System.Data.OleDb

Public Module Main
    Sub Main()
        Try
            Application.EnableVisualStyles()
#If DEBUG Then
            Dim CartellaSerializzazioni As String = "C:\ApplicazioniDirezione\UT\Temp\Guido"
            Dim TipoVista As Integer = 0
#Else
            Dim TipoVista As Integer = Command.Split(";")(0)
            Dim CartellaSerializzazioni As String = Command.Split(";")(1)
#End If
            Dim ComUt As New ComunicazioniUt()
            ComunicazioniUt.TipoVista = TipoVista
            ComunicazioniUt.CartellaSerializzazioni = CartellaSerializzazioni
            'inizializza
            ComUt.Init()

            ComUt.Controlla()

        Catch ex As Exception
            'non fare niente
        End Try
    End Sub
End Module

Public Class ComunicazioniUt

    'log
    Friend Shared Log As Utx.ApplicationLog

    'dichiarazioni globali
    Friend Shared PathDb As String
    Friend Shared dsDoc As New DataSet
    Friend Shared UrlBaseDoc As String 'recuperato per riferimento dal servizio

    Friend Bag As Utx.Bag

    Public Enum QualiDoc
        ALL = 0
        DOC_DA_LEGGERE = 1
    End Enum

    Sub New()
        Utx.Globale.Init()
    End Sub

    Private Shared mTipoVista As QualiDoc
    Public Shared Property TipoVista() As QualiDoc
        Get
            Return mTipoVista
        End Get
        Set(value As QualiDoc)
            mTipoVista = value
        End Set
    End Property

    Private Shared mCartellaSerializzazioni As String
    Public Shared Property CartellaSerializzazioni() As String
        Get
            Return mCartellaSerializzazioni
        End Get
        Set(value As String)
            mCartellaSerializzazioni = value
        End Set
    End Property

    Public Sub Init()
        'leggo bag
        Bag = Utx.NetFunc.CryptoDeserialize(Of Utx.Bag)(Path.Combine(mCartellaSerializzazioni, "Utx.Bag"), "guido&st")

        Log = New Utx.ApplicationLog("Comunicazioni.log", CartellaLog:=Bag.Paths.CartellaLogs)
        PathDb = Path.Combine(Bag.Paths.CartellaSetting, "Comunicazioni.mdb")
    End Sub

    Public Sub Controlla()
        Try
            Dim TabellaDoc As String = Bag.Utente.UniageUser

            Log.Info(String.Format("Avvio comunicazioni: {0}", Application.ProductVersion))
            Log.Info(String.Format("Utente: {0}", TabellaDoc))

            'controllo esistenza db comunicazioni
            If Not File.Exists(PathDb) Then
                File.Copy(Path.Combine(Bag.Paths.CartellaModelli, "Comunicazioni.mdb"), PathDb)
            End If

            Using cn As New OleDb.OleDbConnection(Utx.Globale.MDBDriver + PathDb)
                Try
                    cn.Open()
                Catch ex As Exception
                    File.Delete(PathDb)
                    Exit Sub
                End Try

                'controllo l'esistenza della tabella utente
                ControlloTabellaDoc(cn, TabellaDoc)
                'scarico l'indice dei doc
                ScaricaIndiceDoc(cn, TabellaDoc)

                'tipo visualizzazione ALL visualizza comunque i documenti altrimenti la finestra
                'apparirà solo se ci sono documenti non letti
                If mTipoVista = QualiDoc.ALL Then
                    Log.Info("Visualizzo tutti i documenti")

                    Using f As New FormComunicazioni
                        f.Comunicazioni = Me
                        f.cn = cn
                        f.TabellaDoc = TabellaDoc

                        f.ShowDialog()
                    End Using
                Else
                    Using cmd As New OleDb.OleDbCommand
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = String.Format("SELECT Count(*) FROM {0} WHERE Letto = False", TabellaDoc)

                        'se ci sono documenti non letti
                        If cmd.ExecuteScalar > 0 Then
                            Log.Info("Visualizzo tutti i documenti non letti")

                            Using f As New FormComunicazioni

                                f.cn = cn
                                f.TabellaDoc = TabellaDoc

                                f.ShowDialog()
                            End Using
                        Else
                            Log.Info("Non ci sono documenti da leggere")
                        End If
                    End Using
                End If

            End Using

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Log.Info()
        End Try
    End Sub

    Private Shared Sub ControlloTabellaDoc(ByRef cn As OleDbConnection,
                                           TabellaDoc As String)
        Try
            If Utx.FunzioniDb.EsisteTabella(cn, TabellaDoc) = False Then
                'la tabella non esiste: la creo
                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("SELECT * INTO {0} FROM Documenti WHERE False", TabellaDoc)
                    cmd.ExecuteNonQuery()
                End Using
            End If

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Friend Sub ScaricaIndiceDoc(ByRef cn As OleDb.OleDbConnection,
                                TabellaDoc As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            Using ws As New WsComunicazioni.Service1
                'assegno eventuale proxy
                If Utx.Setting.Ambiente <> Utx.Enumerazioni.TipoAmbiente.PP Then
                    ws.Proxy = Bag.Proxy.Proxy
                End If

                'scarico la lista dei documenti
                Log.Info("Scarico documenti attivi")

                Dim Errore As String = ""
                UrlBaseDoc = ""

                dsDoc.Clear()
                dsDoc = ws.ListaDocumenti(UrlBaseDoc, Errore)

                If Errore.StartsWith("+OK") Then
                    AnalisiDoc(cn, TabellaDoc, True)
                End If
            End Using

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Friend Sub ScaricaDocArchivio(InizioPeriodo As Date,
                                  FinePeriodo As Date,
                                  ByRef cn As OleDb.OleDbConnection,
                                  tabellaDoc As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            Using ws As New WsComunicazioni.Service1
                'assegno eventuale proxy
                If Utx.Setting.Ambiente <> Utx.Enumerazioni.TipoAmbiente.PP Then
                    ws.Proxy = Bag.Proxy.Proxy
                End If

                'scarico il file
                Log.Info("Scarico doc archivio")

                Dim Errore As String = ""
                UrlBaseDoc = ""

                dsDoc.Clear()
                dsDoc = ws.ListaDocumentiArchivio(InizioPeriodo, FinePeriodo, UrlBaseDoc, Errore)

                If Errore.StartsWith("+OK") Then
                    AnalisiDoc(cn, tabellaDoc, False)
                End If
            End Using

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Friend Sub AnalisiDoc(ByRef cn As OleDb.OleDbConnection,
                          TabellaDoc As String,
                          CancellaDocScaduti As Boolean)
        Try
            Log.Info("Analisi documenti")

            Utx.FunzioniDb.CancellaTabella(cn, String.Format("Copia{0}", TabellaDoc))

            Using cmd As New OleDb.OleDbCommand
                cmd.Connection = cn
                cmd.CommandType = CommandType.Text

                'copio i documenti nella tabella copia
                cmd.CommandText = String.Format("SELECT * INTO Copia{0} FROM {0}", TabellaDoc)
                cmd.ExecuteNonQuery()

                'cancello i record dalla tabella documenti
                cmd.CommandText = String.Format("DELETE * FROM {0}", TabellaDoc)
                cmd.ExecuteNonQuery()

                cmd.CommandText = String.Format("INSERT INTO {0}(Codice,Titolo,Link,Data,Scadenza) VALUES(?,?,?,?,?)", TabellaDoc)

                For Each dr As DataRow In dsDoc.Tables("Documenti").Rows
                    'carico solo i documenti del profilo agenzia o con profilo zero
                    If (dr.Item("Profilo") = Bag.Ente.ProfiloApp) OrElse (dr.Item("Profilo") = 0) Then

                        Dim OkDoc As Boolean = True

                        'ordine priorità: agenzia-provincia-regione
                        If dr.Item("Regione") <> 0 Then OkDoc = (Bag.Ente.Regione = dr.Item("Regione"))
                        If dr.Item("Provincia").ToString.ToUpper <> "XX" Then OkDoc = (Bag.Ente.Provincia = dr.Item("Provincia"))
                        If dr.Item("Agenzia") <> "TUTTE" Then OkDoc = dr.Item("Agenzia").ToString.Contains(Bag.Ente.AgenziaMadre)

                        If OkDoc Then
                            Try
                                'se sono comunicazioni (C) e non link (L)
                                If dr.Item("TipoDoc") = "C" Then
                                    dr.Item("Link") = String.Format("{0}/{1}", UrlBaseDoc, dr.Item("Link"))
                                End If

                                cmd.Parameters.Clear()
                                cmd.Parameters.AddWithValue("Codice", dr.Item("Codice"))
                                cmd.Parameters.AddWithValue("Titolo", dr.Item("Titolo"))
                                cmd.Parameters.AddWithValue("Link", dr.Item("Link"))
                                cmd.Parameters.AddWithValue("Data", dr.Item("Data"))
                                cmd.Parameters.AddWithValue("Scadenza", dr.Item("Scadenza"))

                                cmd.ExecuteNonQuery()

                            Catch ex As Exception
                                Log.Errore(ex)
                            End Try
                        End If
                    End If
                Next

                'aggiorno il campo letto prendendolo dalla tabella copia
                cmd.CommandText = String.Format("UPDATE {0} d " +
                                                "INNER JOIN Copia{0} c ON d.Codice = c.Codice " +
                                                "SET d.Letto = c.Letto",
                                                TabellaDoc)
                cmd.ExecuteNonQuery()

                If CancellaDocScaduti = True Then
                    'elimina eventuali documenti scaduti
                    cmd.CommandText = String.Format("DELETE * FROM {0} WHERE Scadenza < ?", TabellaDoc)

                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("Scadenza", Today)

                    cmd.ExecuteNonQuery()
                End If

                'cancello la tabella copia
                Utx.FunzioniDb.CancellaTabella(cn, String.Format("DROP TABLE Copia{0}", TabellaDoc))
            End Using

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub
End Class
