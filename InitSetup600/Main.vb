Imports System.IO

Module Main

    Private Const CartellaUT As String = "M:\Unitools"
    Private Const CartellaUT_OLD As String = "M:\Unitools_OLD"
    Private Flag As String = Path.Combine(CartellaUT_OLD, "Copia.ok")

    Sub Main()
#If DEBUG Then
        'se M: è pronto
        If New DriveInfo("M").IsReady Then

            If File.Exists(Flag) Then
                MsgBox("xxx")
            Else
                CopiaUnitools()
            End If
        End If
#Else
        'se è un pc di direzione
        If (Environment.UserDomainName.ToUpper = "UNIAGE" OrElse Environment.UserDomainName.ToUpper = "AURAGE") Then
            'se M: è pronto
            If New DriveInfo("M").IsReady Then
                CopiaUnitools()
            End If
        End If
#End If
    End Sub

    Private Sub CopiaUnitools()
        Try
            For Each cartella In "Dati;Logs;Modelli;Oggetti".Split(";")

                Dim CartellaOrigine As String = Path.Combine(CartellaUT, cartella)
                Dim CartellaDest As String = Path.Combine(CartellaUT_OLD, cartella)

                My.Computer.FileSystem.CopyDirectory(CartellaOrigine, CartellaDest, True)
            Next

            File.AppendAllText(Flag, String.Format("Copia completata il {0:d}", Now))

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
