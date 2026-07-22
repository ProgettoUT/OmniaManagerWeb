Imports System.IO
Imports System.Data.OleDb

Public Class Liquidatori

    Private mAgenziaFiglia As Utx.AgenziaFigliaOmnia

    Sub New(ByRef AgenziaFiglia As Utx.AgenziaFigliaOmnia)
        mAgenziaFiglia = AgenziaFiglia
    End Sub

    Public Sub Importa()
        Try
            Dim FileZip As String = Path.Combine(mAgenziaFiglia.Cartelle.CartellaArriviLocaleAgenziaDL, "Liquidatori.zip")
            Dim FileDati As String = Path.ChangeExtension(FileZip, "csv")

            Using wc As New System.Net.WebClient
                'assegno le credenziali al webclient
                wc.Proxy = Utx.Globale.UniProxy.Proxy
                'scarico il file (non lo prendo dalla cache)
                wc.CachePolicy = New Net.Cache.RequestCachePolicy(Net.Cache.RequestCacheLevel.NoCacheNoStore)
                wc.DownloadFile("http://www.utools.it/Unitools/Download/Liquidatori.zip", FileZip)
            End Using

            Utx.LibreriaZip.UnZipFileConNome(FileZip, FileDati)
            ImportaLiquidatori(FileDati)

            File.Delete(FileZip)
            File.Delete(FileDati)

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    Private Function ImportaLiquidatori(ByVal FileDati As String) As Boolean
        Globale.IconaNotifica.Text = String.Format("Unitools: importa liquidatori...")
        Globale.Log.Info(">>> ImportaLiquidatori")

        Try
            Using cmd As New OleDbCommand

                cmd.Connection = mAgenziaFiglia.Connessione

                Using da As New OleDbDataAdapter("SELECT * FROM Liquidatori", mAgenziaFiglia.Connessione)

                    Using cmdBuilder As New OleDbCommandBuilder(da)

                        cmd.CommandType = CommandType.Text

                        'svuoto la tabella 
                        cmd.CommandText = "DELETE * FROM Liquidatori"
                        cmd.ExecuteNonQuery()

                        Try
                            'creo la stored procedure di insert
                            cmd.CommandText = "Create Procedure InsLiquidatore As " + cmdBuilder.GetInsertCommand.CommandText
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception
                            'la stored esiste già
                        End Try
                    End Using
                End Using

                'imposto il cmd per l'esecuzione
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "InsLiquidatore"

                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                    'leggo riga di intestazione
                    sr.ReadLine()

                    Do While Not sr.EndOfStream
                        If EstraiCampi(sr.ReadLine, cmd) = False Then Throw New System.Exception
                        Application.DoEvents()
                    Loop
                End Using
            End Using

            ImportaLiquidatori = True

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
            ImportaLiquidatori = False
        End Try
    End Function

    Private Function EstraiCampi(ByVal Riga As String,
                                 ByRef cmd As OleDbCommand) As Boolean
        Try
            Dim Campo() As String = Riga.Split(";")

            'trimma tutto
            TrimArray(Campo)

            'normalizzo il telefono clg
            Campo(7) = Campo(7).Replace(" ", "")
            If Val(Campo(7)) = 0 Then Campo(7) = ""

            With cmd.Parameters
                .Clear()

                .AddWithValue("Codice", Campo(0))
                .AddWithValue("Nome", Campo(1))
                .AddWithValue("Telefono", Campo(2).Replace("'", "").Replace(" ", ""))
                .AddWithValue("Email", Campo(5))
                .AddWithValue("Clg", Campo(3))
                .AddWithValue("Localita", Campo(4))
                .AddWithValue("Provincia", Campo(6))
                .AddWithValue("TelefonoClg", Campo(7))
            End With

            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
            Globale.Log.LogParametri(Riga, cmd.Parameters)
            Return False
        End Try
    End Function
End Class
