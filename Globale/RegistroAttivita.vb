Imports System.Data.OleDb

Public Class RegistroAttivita

    Public Enum TipoAttivita
        NUOVO_SINISTRO = 1
        RICHIESTA_CONSAP = 2
    End Enum

    Public Shared Sub Add(Tipo As TipoAttivita, Protocollo As String)
        'al momento 08/09/2022 non utilizzata
        Try
            Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "INSERT INTO RegistroAttivita (Data,TipoAttivita,Utente,Protocollo) VALUES(?,?,?,?)"

                    cmd.Parameters.Add("data", OleDbType.Date).Value = Now
                    cmd.Parameters.AddWithValue("tipo", Tipo)
                    cmd.Parameters.AddWithValue("utente", Left(Utx.Globale.UtenteCorrente.UniageUser, 15))
                    cmd.Parameters.AddWithValue("protocollo", Left(Protocollo, 20))

                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Sub CreaTabellaTipoAttivita(Agenzia As String)
        Try
            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Agenzia, ConnessioniDb.Db.INFO))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "DELETE FROM TipoAttivita"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "INSERT INTO TipoAttivita (CodTipoAttivita, DesTipoAttivita) VALUES(?, ?)"
                    cmd.Parameters.Add("CodTipoAttivita", OleDbType.SmallInt)
                    cmd.Parameters.Add("DesTipoAttivita", OleDbType.VarChar)

                    For Each elemento As TipoAttivita In System.Enum.GetValues(GetType(TipoAttivita))
                        cmd.Parameters("CodTipoAttivita").Value = elemento
                        cmd.Parameters("DesTipoAttivita").Value = elemento.ToString
                        cmd.ExecuteNonQuery()
                    Next
                End Using
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try

    End Sub
End Class
