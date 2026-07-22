Imports System.Drawing
Imports System.IO

Module Globale

    Friend Const TitoloApp As String = "Scanner RDP"
    Friend Const Dominio As String = "uniage"
    Friend Const CartellaProgrammaUT As String = "C:\ApplicazioniDirezione\Unitools"

    Public Log As New ApplicationLog("ScannerRDP.log")

    Public Enum TipoAmbiente
        DIR = 1
        PP = 2
        PP2DIR = 3
    End Enum

    Sub Main()
        Try
            Using f As New ScannerRDP

                f.StartPosition = FormStartPosition.CenterScreen
                f.ShowDialog()
            End Using
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub
End Module
