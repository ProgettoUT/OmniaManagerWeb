Imports System.IO

Module Globale
    Public Log As New Utx.ApplicationLog("Budget.log")

    Public RgToComparto As DataTable
    Public ElencoRamiGestione As New List(Of Integer)
    Public ElencoComparti As New List(Of Integer)
    Public ElencoSettori As New List(Of Integer)
    Public ElencoAggregati As New List(Of Integer)

    Public Sub RamoGestioneToComparto()
        Try
            RgToComparto = Utx.WsCommand.ExecuteNonQuery("SELECT * FROM DB00000.dbo.Codici1023 ORDER BY Ramogestione,Comparto,Settore,Aggregato").DataTable

            For Each row As DataRow In RgToComparto.Rows
                If ElencoRamiGestione.Contains(row("RamoGestione")) = False AndAlso row("RamoGestione") <> 15 Then
                    ElencoRamiGestione.Add(row("RamoGestione"))
                End If
                If ElencoComparti.Contains(row("Comparto")) = False Then ElencoComparti.Add(row("Comparto"))
                If ElencoSettori.Contains(row("Settore")) = False Then ElencoSettori.Add(row("Settore"))
                If ElencoAggregati.Contains(row("Aggregato")) = False Then ElencoAggregati.Add(row("Aggregato"))
            Next
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Module
