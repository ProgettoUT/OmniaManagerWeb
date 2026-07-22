Imports System.IO

Public Class CriptaQuery

    Private CartellaLavoroEstrazioni As String

    Public Shared Sub CreaQueryCriptata(NomeEstrazione As String)
        'questa funzione viene usata solo in fase di debug/sviluppo per generare la query criptata da distribuire in produzione
        Try
            Dim XmlEstrazione As String = Path.Combine(Utx.Globale.Paths.CartellaEstrazioni,
                                                       "QChiaro",
                                                       NomeEstrazione,
                                                       NomeEstrazione.Replace("""", "")) & ".xml"

            If IO.File.Exists(XmlEstrazione) Then
                Dim FileInChiaro As Byte() = My.Computer.FileSystem.ReadAllBytes(XmlEstrazione)

                Dim NuovoNomeFile As String = Path.Combine(Utx.Globale.Paths.CartellaEstrazioni,
                                                           "Queries\" & Path.GetFileNameWithoutExtension(XmlEstrazione),
                                                           IO.Path.GetFileName(XmlEstrazione))
                Dim NuovaCartella As String = Path.GetDirectoryName(NuovoNomeFile)

                If Directory.Exists(NuovaCartella) Then
                    Directory.Delete(NuovaCartella, True)
                End If

                Directory.CreateDirectory(NuovaCartella)
                My.Computer.FileSystem.WriteAllBytes(NuovoNomeFile, RC43(FileInChiaro, (FileInChiaro(0) = 60)), False)
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Shared Function RC43(inp() As Byte, Job As Boolean) As Byte()
        Try
            Dim i As Integer
            Dim j As Integer
            Dim temp As Byte
            Dim Y As Integer
            Dim t As Integer
            Dim TempOutPut As Integer

            Dim lenOutp As Integer = inp.Length + IIf(Job, +4, -4)

            Dim Outp(lenOutp - 1) As Byte
            If Job = True Then
                Dim result As Byte() = BitConverter.GetBytes(inp.Length)
                Outp(0) = result(0)
                Outp(1) = result(1)
                Outp(2) = result(2)
                Outp(3) = result(3)
            End If
            Const Key As String = "unitools"
            Const Length As Integer = 256

            Dim ss(Length - 1) As Byte
            Dim k(Length - 1) As Byte

            For i = 0 To (Length - 1)
                ss(i) = i
            Next

            j = 1
            For i = 0 To (Length - 1)
                If j > Len(Key) Then j = 1
                k(i) = Asc(Mid(Key, j, 1))
                j = j + 1
            Next i

            j = 0
            For i = 0 To (Length - 1)
                j = (j + ss(i) + k(i)) Mod (Length)
                temp = ss(i)
                ss(i) = ss(j)
                ss(j) = temp
            Next i

            Dim s(Length - 1) As Byte
            For i = 0 To (Length - 1)
                s(i) = ss(i)
            Next

            i = 0
            j = 0

            For X As Integer = IIf(Job, 0, 4) To inp.Length - 1
                i = (i + 1) Mod (Length)
                j = (j + s(i)) Mod (Length)
                temp = s(i)
                s(i) = s(j)
                s(j) = temp
                t = (0 + s(i) + s(j)) Mod (Length)
                Y = s(t)

                TempOutPut = inp(X)

                If Job = True Then
                    Outp(4 + X) = (TempOutPut + Y) Mod Length
                    'Outp = Outp & Chr((TempOutPut + Y) Mod Length)
                ElseIf TempOutPut < Y Then
                    Outp(X - 4) = TempOutPut - Y + Length
                    'Outp = Outp & Chr(Length + TempOutPut - Y)
                Else
                    Outp(X - 4) = TempOutPut - Y
                    'Outp = Outp & Chr(TempOutPut - Y)
                End If
            Next

            Return Outp
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Shared Sub CreaCatalogo(DataCatalogo As Date)
        Try
            Dim Catalogo As String = String.Format("{0}\Catalogo.{1:yyyyMMdd}.zip", Utx.Globale.Paths.CartellaEstrazioni, DataCatalogo)
            Dim Origine As String = Path.Combine(Utx.Globale.Paths.CartellaEstrazioni, "Queries\*")

            'C:\Program Files\7-Zip\7z.exe" a destinazione origine
            Using p As New Process
                p.StartInfo.FileName = Path.Combine(Path.Combine(Utx.Globale.Paths.CartellaApp, "7z.exe"))
                p.StartInfo.Arguments = String.Format("a {0} {1}", Catalogo, Origine)
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                p.Start()
                p.WaitForExit()
            End Using
            MsgBox(String.Format("Catalogo '{0:yyyyMMdd}' creato correttamente", DataCatalogo), MsgBoxStyle.Information)
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
