Imports System.Environment
Public Class Email

    Private Declare Function LeggiBag Lib "C:\ApplicazioniDirezione\Unitools\DLL\FunzUt.dll" (ByVal ProcessId As String, ByVal VarName As String, Optional ByRef Cancella As Boolean = False) As String
    Private Declare Function FileBag Lib "C:\ApplicazioniDirezione\Unitools\DLL\FunzUt.dll" (Optional ByRef Unicode_Renamed As Boolean = False) As String
    Private Declare Sub ClearBag Lib "C:\ApplicazioniDirezione\Unitools\DLL\FunzUt.dll" (ByVal ProcessId As String)

    Private mCartellaEmail As String

    Public Function Invia(ByVal InviaA As String, ByVal InviaCc As String, ByVal InviaCcn As String, ByVal oggetto As String, ByVal Testo As String) As Boolean
        If EMAIL_SMTP = vbNullString Then
            MsgBox("Attenzione email non inviata." & vbNewLine & "L'invio è consentito solo se il quotatore è attivato da unitools.", MsgBoxStyle.Exclamation)
            Exit Function
        Else
            Dim Pid As String = Environ("USERNAME") & TimeOfDay.ToString("hhmmss")

            Try
                Dim postino As String = IO.Path.Combine(CARTELLA_EXE, "Postino.exe")

                If Not System.IO.File.Exists(postino) Then
                    MsgBox("Attenzione: componente per l'invio delle e-mail non trovato.", MsgBoxStyle.Exclamation)
                    Exit Function
                End If

                SetEnvironmentVariable("POSTINO_PID", Pid)
                SetEnvironmentVariable("POSTINO_MITTENTE", EMAIL_MITTENTE)
                SetEnvironmentVariable("POSTINO_A", InviaA)
                SetEnvironmentVariable("POSTINO_CC", InviaCc)
                SetEnvironmentVariable("POSTINO_CCN", InviaCcn)
                SetEnvironmentVariable("POSTINO_OGGETTO", oggetto)
                SetEnvironmentVariable("POSTINO_TESTO", Testo)

                If RETEATTIVA = "S" Then
                    SetEnvironmentVariable("POSTINO_TIPO_INVIO", "0")
                Else
                    SetEnvironmentVariable("POSTINO_TIPO_INVIO", "9")
                End If

                SetEnvironmentVariable("POSTINO_SMTP", EMAIL_SMTP)
                SetEnvironmentVariable("POSTINO_CARTELLA_MAIL", mCartellaEmail)

                Shell(postino & " " & POSTINO_GUID, AppWinStyle.NormalNoFocus, True, 60000)

                Invia = ("+OK" = Split(LeggiBag(Pid, "POSTINO_ESITO", True), ";", , CompareMethod.Text)(0))
                Exit Function

            Catch ex As Exception
            End Try

            Try
                ClearBag(Pid)
            Catch ex As Exception
            End Try
        End If
    End Function

    Public Sub New()
        SvuotaCartellaEmail()
    End Sub

    Public Sub SvuotaCartellaEmail()
        Try
            mCartellaEmail = System.IO.Path.Combine(CARTELLA_TEMP, "Emails")
            If Not System.IO.Directory.Exists(mCartellaEmail) Then
                System.IO.Directory.CreateDirectory(mCartellaEmail)
            End If
            Kill(mCartellaEmail & "\*.*")
        Catch ex As Exception
        End Try
    End Sub

    Public ReadOnly Property CartellaEmail() As String
        Get
            CartellaEmail = mCartellaEmail
        End Get
    End Property

End Class
