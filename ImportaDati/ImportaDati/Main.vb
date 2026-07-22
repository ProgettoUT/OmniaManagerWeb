Imports System.IO

Public Class FileIntoDatabase

    Private WithEvents AgenziaMadre As Utx.AgenziaOmnia
    Private WithEvents Figlia As Utx.AgenziaFigliaOmnia

    Public Sub Avvio()
        Try
            Application.EnableVisualStyles()

            'controllo disponibilità disco dati condiviso
            If New DriveInfo(Utx.Globale.Paths.NomeUnitaDati).IsReady = False Then
                Utx.Globale.Log.Info(String.Format("Disco dati {0} non pronto o non disponibile", Utx.Globale.Paths.NomeUnitaDati))
                MsgBox(String.Format("Disco dati {0} non pronto o non disponibile", Utx.Globale.Paths.NomeUnitaDati),
                       MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Exit Sub
            End If

            Globale.IconaNotifica = New NotifyIcon
            With Globale.IconaNotifica
                .Text = String.Format("Unitools:{0}ricerca nuovi dati in corso", Environment.NewLine)
                .Icon = Risorse.Immagini.Icon("update_green")
                .Visible = True
            End With

#If DEBUG Then
            AgenziaMadre = New Utx.AgenziaOmnia("1", Utx.Globale.ProfiloEnteGestore.AgenziaMadre, "00")
#Else
            AgenziaMadre = New Utx.AgenziaOmnia()
#End If
            For Each Collegata As String In AgenziaMadre.AgenzieCollegate
                Utx.Globale.Log.Info(String.Format("Importazione dati per codice agenzia {0}", Collegata))

                Figlia = New Utx.AgenziaFigliaOmnia(Collegata, AgenziaMadre.CodiceSede)
                Dim Importa As New ImportaAgenziaFiglia(Figlia)
                Importa.Importa()
            Next

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try

        Utx.Globale.Log.Info("Importazione dati da download agenzia terminata")
        Utx.Globale.Log.Info()

        'distruggo tray icon
        Globale.IconaNotifica.Dispose()
    End Sub

    Private Sub AgenziaMadre_Errore(Modulo As String, Metodo As String, ByRef ex As Exception) Handles AgenziaMadre.Errore
        Globale.LogErrori.Info(Modulo)
        Globale.LogErrori.Info(Metodo)
        Globale.LogErrori.Info(ex)
    End Sub

    Private Sub Figlia_Errore(Modulo As String, Metodo As String, ByRef ex As Exception) Handles Figlia.Errore
        Globale.LogErrori.Info(Modulo)
        Globale.LogErrori.Info(Metodo)
        Globale.LogErrori.Info(ex)
    End Sub
End Class
