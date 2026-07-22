Imports System.IO
Imports System.Data.OleDb

Public Class Convenzioni

    Private mAgenziaFiglia As Utx.AgenziaFigliaOmnia

    Sub New(ByRef AgenziaFiglia As Utx.AgenziaFigliaOmnia)
        mAgenziaFiglia = AgenziaFiglia
    End Sub

    Public Sub Importa()
        Try
            Dim FileZip As String = Path.Combine(mAgenziaFiglia.Cartelle.CartellaArriviLocaleAgenziaDL, "Convenzioni.zip")
            Dim FileDati As String = Path.ChangeExtension(FileZip, "csv")

            Using wc As New System.Net.WebClient
                'assegno le credenziali al webclient
                wc.Proxy = Utx.Globale.UniProxy.Proxy
                'scarico il file (non lo prendo dalla cache)
                wc.CachePolicy = New Net.Cache.RequestCachePolicy(Net.Cache.RequestCacheLevel.NoCacheNoStore)
                wc.DownloadFile("http://www.utools.it/Unitools/Download/Convenzioni.zip", FileZip)
            End Using

            Utx.LibreriaZip.UnZipFileConNome(FileZip, FileDati)
            ImportaConvenzioni(FileDati)

            File.Delete(FileZip)
            File.Delete(FileDati)

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    Private Function ImportaConvenzioni(FileDati As String) As Boolean
        Try
            Globale.IconaNotifica.Text = String.Format("Unitools:{0}importa convenzioni...", Environment.NewLine)
            Globale.Log.Info(">>> ImportaConvenzioni")

            Using cmd As New OleDbCommand

                cmd.Connection = mAgenziaFiglia.Connessione

                Using da As New OleDbDataAdapter("SELECT * FROM Convenzioni WHERE False", mAgenziaFiglia.Connessione)

                    Using cmdBuilder As New OleDbCommandBuilder(da)

                        cmd.CommandType = CommandType.Text

                        'svuoto la tabella 
                        cmd.CommandText = "DELETE * FROM Convenzioni"
                        cmd.ExecuteNonQuery()

                        Try
                            'creo la stored procedure di insert
                            cmd.CommandText = "Create Procedure InsConvenzioni As " + cmdBuilder.GetInsertCommand.CommandText
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception
                            'la stored esiste già
                        End Try
                    End Using
                End Using

                'imposto il cmd per l'esecuzione
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "InsConvenzioni"

                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                    'leggo riga di intestazione
                    sr.ReadLine()

                    Do While Not sr.EndOfStream
                        If EstraiCampi(sr.ReadLine, cmd) = False Then Throw New System.Exception
                        Application.DoEvents()
                    Loop
                End Using

                ImportaConvenzioni = True
            End Using

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
            ImportaConvenzioni = False
        End Try
    End Function

    Private Function EstraiCampi(Riga As String,
                                 ByRef cmd As OleDbCommand) As Boolean
        Try
            Dim Campo() As String = Riga.Split(";")

            'trimma tutto
            TrimArray(Campo)

            With cmd.Parameters
                .Clear()

                .AddWithValue("Compagnia", Campo(0))
                .AddWithValue("Codice", Campo(1))
                .AddWithValue("Desk", Campo(2).Replace("'", "").Replace("""", ""))
                .AddWithValue("DataChiusura", Campo(3))
            End With

            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
            Return False
        End Try
    End Function
End Class
