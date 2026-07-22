Imports System.IO

'Public Class Utente
'    Public Property Inizializzato As Boolean
'    Public Property UniageUser As String = ""
'    Public Property UniagePw As String = ""
'    Public Property IdApp As String = ""
'    Public Property Agenzia As String = ""
'    Public Property AgenziaMadre As String = ""
'    Public Property Modo As String = ""

'    Sub New(CommandLine As String)
'        Try
'            'in avvio, dalla riga di comando, passare:
'            'utente;idapp;modalità >> 102379xx/02379;UT;NORMALE/HIDE/FORZATURA
'            Log.Info("Parametri: {0}", {IIf(String.IsNullOrEmpty(CommandLine), "nessun parametro", CommandLine)})

'            If AnalisiUtente(CommandLine) = False Then
'                Inizializzato = False
'                Exit Sub
'            End If
'            If AnalisiApp(CommandLine) = False Then
'                Inizializzato = False
'                Exit Sub
'            End If
'            Inizializzato = True
'            'rilevo l'agenzia madre
'            Using s As New Utx.SettingAgenzia.ConfiguraSede
'                AgenziaMadre = s.AgenziaMadre(Agenzia).Split(";")(0)
'            End Using
'            Inizializzato = True
'        Catch ex As Exception
'            Log.Errore(ex)
'            Inizializzato = False
'        End Try
'    End Sub

'    Public Function PcInDominio() As Boolean
'        Return Environment.UserDomainName.ToUpper = "UNIAGE"
'    End Function

'    Private Function AnalisiUtente(CommandLine As String) As Boolean
'        Try
'            If String.IsNullOrEmpty(CommandLine) Then
'                If PcInDominio() Then
'                    UniageUser = Environment.UserName
'                    Agenzia = UniageUser.Substring(1, 5)
'                    Log.Info("Pc in dominio")
'                    'la pw è già incorporata nel proxy tramite utx
'                Else
'                    MsgBox("Parametri non corretti", MsgBoxStyle.Critical, "Live update")
'                    Return False
'                End If
'            Else
'                Dim Parametri() As String = CommandLine.Split(";")
'                If Parametri(0) Like "#####" Then
'                    UniageUser = ""
'                    Agenzia = Parametri(0)
'                ElseIf Parametri(0).ToLower Like "######[a-z0-9][a-z0-9]" Then
'                    UniageUser = Parametri(0)
'                    Agenzia = UniageUser.Substring(1, 5)
'                Else
'                    MsgBox("Identificativo utente non corretto", MsgBoxStyle.Critical, "Live update")
'                    Return False
'                End If
'            End If
'            Log.Info("Agenzia {0} - Utente {1}", {Agenzia, UniageUser})
'            Return True
'        Catch ex As Exception
'            Log.Errore(ex)
'            Return False
'        End Try
'    End Function

'    Private Function AnalisiApp(CommandLine As String) As Boolean
'        Try
'            Dim Parametri() As String = CommandLine.Split(";")
'            Log.Info("ANALISI UTENTE")

'            If String.IsNullOrEmpty(CommandLine) Then
'                Log.Info("nessun parametro")
'                IdApp = "UT"
'            Else
'                Select Case Parametri.Length
'                    Case 1 'solo utente non vuoto
'                        Log.Info($"solo utente o agenzia ({Parametri(0)})")
'                        If File.Exists(Path.Combine(Utx.Globale.Paths.CartellaApp, "Unitools.exe")) Then
'                            IdApp = "UT"
'                        ElseIf File.Exists(Path.Combine(Utx.Globale.Paths.CartellaApp, "Assegni.exe")) Then
'                            IdApp = "ASSEGNI"
'                        Else
'                            IdApp = "UT"
'                        End If
'                    Case 2
'                        Log.Info($"utente {Parametri(0)} - idapp {Parametri(1)}")
'                        If String.IsNullOrEmpty(Parametri(1)) Then
'                            'se il secondo parametro è una stringa vuota
'                            If File.Exists(Path.Combine(Utx.Globale.Paths.CartellaApp, "Unitools.exe")) Then
'                                IdApp = "UT"
'                            ElseIf File.Exists(Path.Combine(Utx.Globale.Paths.CartellaApp, "Assegni.exe")) Then
'                                IdApp = "ASSEGNI"
'                            Else
'                                IdApp = "UT"
'                            End If
'                        Else
'                            IdApp = Parametri(1).ToUpper
'                        End If
'                    Case 3
'                        Log.Info($"utente {Parametri(0)} - idapp {Parametri(1)} - modalità {Parametri(2)}")
'                        If String.IsNullOrEmpty(Parametri(1)) Then
'                            'se il secondo parametro è una stringa vuota
'                            If File.Exists(Path.Combine(Utx.Globale.Paths.CartellaApp, "Unitools.exe")) Then
'                                IdApp = "UT"
'                            ElseIf File.Exists(Path.Combine(Utx.Globale.Paths.CartellaApp, "Assegni.exe")) Then
'                                IdApp = "ASSEGNI"
'                            Else
'                                IdApp = "UT"
'                            End If
'                        Else
'                            IdApp = Parametri(1).ToUpper
'                        End If
'                        Modo = Parametri(2).ToUpper
'                End Select
'            End If
'            Log.Info($"IdApp: {IdApp}")
'            Return True
'        Catch ex As Exception
'            Log.Errore(ex)
'            Return False
'        End Try
'    End Function
'End Class
