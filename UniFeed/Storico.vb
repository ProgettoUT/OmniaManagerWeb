Imports System.Data.OleDb

Class Storico

    Public Shared Sub creaLink(agenzia As Utx.AgenziaFigliaOmnia)
        Dim StUnoFile = agenzia.Cartelle.DatabaseDbUno.Replace("DbUno", "StUno")
        Dim tabelle As String() = {"s_polizze1", "s_polizze2", "s_polizze3", "s_polizze4", "s_sinistri", "s_titoli"}

        If agenzia.Connessione IsNot Nothing Then
            For Each tabella As String In tabelle
                Utx.FunzioniDb.CancellaTabella(agenzia.Connessione, tabella)
                Using cmd As New OleDbCommand
                    cmd.Connection = agenzia.Connessione
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("CREATE PROCEDURE {0} AS SELECT * FROM {0} IN '{1}'", tabella, StUnoFile)
                    cmd.ExecuteNonQuery()
                End Using
            Next
        End If
    End Sub

    Public Shared Sub SvecchiaDbUno(agenzia As Utx.AgenziaFigliaOmnia)
        Try

            Exit Sub
            If agenzia.Connessione IsNot Nothing Then
                creaLink(agenzia)
                SvecchiaPolizze(agenzia)
                SvecchiaTabelle(agenzia)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub SvecchiaPolizze(agenzia As Utx.AgenziaFigliaOmnia)
        Dim sql1 As String = "INSERT INTO s_{0} SELECT A.* FROM {0} A INNER JOIN polizze1 B ON A.codicepuntovendita = B.codicepuntovendita AND A.ramo = B.ramo AND A.polizza = B.polizza WHERE B.codicetipostorno >= 'A0'"
        Dim sql2 As String = "DELETE FROM {0} A WHERE EXISTS (SELECT 1 FROM polizze1 B WHERE A.codicepuntovendita = B.codicepuntovendita AND A.ramo = B.ramo AND A.polizza = B.polizza AND B.codicetipostorno >= 'A0')"

        Dim tabelle As String() = {"polizze2", "polizze3", "polizze4"}

        For Each tabella As String In tabelle
            Using cmd As New OleDbCommand
                cmd.Connection = agenzia.Connessione
                cmd.CommandType = CommandType.Text
                cmd.CommandText = String.Format(sql1, tabella)
                cmd.ExecuteNonQuery()
                cmd.CommandText = String.Format(sql2, tabella)
                cmd.ExecuteNonQuery()
            End Using
        Next
        Using cmd As New OleDbCommand
            cmd.Connection = agenzia.Connessione
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "INSERT INTO s_polizze1 SELECT * FROM polizze1 WHERE codicetipostorno >= 'A0'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE FROM polizze1 WHERE codicetipostorno >= 'A0'"
            cmd.ExecuteNonQuery()
        End Using

    End Sub


    Public Shared Sub SvecchiaTabelle(agenzia As Utx.AgenziaFigliaOmnia)
        Dim sql1 As String = "INSERT INTO s_{0} SELECT * FROM {0} WHERE dataelaborazione < #{1}#"
        Dim sql2 As String = "DELETE FROM {0} WHERE dataelaborazione < #{1}#"
        Dim tabelle As String() = {"sinistri", "titoli"}

        For Each tabella As String In tabelle
            Using cmd As New OleDbCommand
                Dim data As String = DataStoricizzazione(tabella, agenzia)
                cmd.Connection = agenzia.Connessione
                cmd.CommandType = CommandType.Text
                cmd.CommandText = String.Format(sql1, tabella, data)
                cmd.ExecuteNonQuery()
                cmd.CommandText = String.Format(sql2, tabella, data)
                cmd.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Public Shared Sub RestoreTabella(tabella As String, agenzia As Utx.AgenziaFigliaOmnia)
        Dim sql1 As String = "INSERT INTO {0} SELECT * FROM s_{0}"
        'Dim sql2 As String = "DELETE FROM s_{0}"
        Using cmd As New OleDbCommand
            cmd.Connection = agenzia.Connessione
            cmd.CommandType = CommandType.Text
            cmd.CommandText = String.Format(sql1, tabella)
            cmd.ExecuteNonQuery()
            'cmd.CommandText = String.Format(sql2, tabella)
            'cmd.ExecuteNonQuery()
        End Using

    End Sub

    Public Shared Function DataStoricizzazione(tabella As String, agenzia As Utx.AgenziaFigliaOmnia) As String
        Return "01/01/2017"
    End Function
End Class
