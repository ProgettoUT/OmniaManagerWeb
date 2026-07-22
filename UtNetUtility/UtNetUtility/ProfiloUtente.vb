Imports System.Data.OleDb

Public Class ProfiloUtente

    Public Compagnia As Integer
    Public Agenzia As String
    Public Sede As String
    Public CodiceUtente As String

    Private mProfilo As OleDbDataReader

    Sub New(ByRef c As OleDbConnection)
        LeggiProfilo(c)
    End Sub

    Private Sub LeggiProfilo(ByRef c As OleDbConnection)

        Dim cmd As New OleDbCommand

        Try
            cmd.Connection = c
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT TOP 1 * FROM ProfiloUtente"

            mProfilo = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            mProfilo.Read()

            Compagnia = mProfilo("Compagnia")
            Agenzia = mProfilo("Agenzia")
            Sede = mProfilo("CodiceSede")
            CodiceUtente = mProfilo("CodiceUtente")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Unitools")
        End Try

    End Sub

End Class
