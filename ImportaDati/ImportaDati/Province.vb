Imports System.Data.OleDb

Public Class Province

    Public Shared Sub ImportaProvince(ByRef cnArrivi As OleDbConnection)
        Try
            Globale.Log.Info(">>> Importa province")

            Dim dt As DataTable
            Dim Errore As String = ""

            Using s As New Utx.SettingAgenzia.ConfiguraSede
                s.Url = "http://www.utools.it/asp/SettingAgenzia/SettingAgenzia.asmx"
                s.Timeout = 60000
                s.Proxy = Utx.Globale.UniProxy.Proxy
                'scarico la tabella
                dt = s.Province(Errore).Tables("Province")
            End Using
            'se c'è un errore sul server
            If Errore.StartsWith("-ERR") Then
                Globale.Log.Info(Errore)
                Exit Sub
            End If

            Using cmd As New OleDbCommand
                cmd.Connection = cnArrivi
                cmd.CommandType = CommandType.Text
                'se l'importazione non è già avvenuta
                cmd.CommandText = "SELECT COUNT(*) FROM Province"
                If cmd.ExecuteScalar = 0 Then
                    'importo
                    cmd.CommandText = "INSERT INTO Province(Provincia,Sigla,Regione,AliquotaRca,EffettoAliquotaRca) " +
                                      "VALUES(?,?,?,?,?)"

                    For Each dr As DataRow In dt.Rows

                        With cmd.Parameters
                            .Clear()

                            .AddWithValue("Provincia", dr("Provincia"))
                            .AddWithValue("Sigla", dr("Sigla"))
                            .AddWithValue("Regione", dr("Regione"))
                            .AddWithValue("AliquotaRca", dr("AliquotaRca"))
                            .AddWithValue("EffettoAliquotaRca", dr("EffettoAliquotaRca"))
                        End With

                        cmd.ExecuteNonQuery()
                    Next
                End If
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
        End Try
    End Sub

End Class
