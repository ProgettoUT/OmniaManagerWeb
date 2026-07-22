#If DEBUG Then
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization

<TestClass>
Public Class TestGuido
    Public TestContext As TestContext

    '<TestMethod>
    Public Sub Omnia()
        Dim Madre = New Utx.AgenziaOmnia() 'oppure Ut.AgenziaOmnia("1", "01306", "00")

        For Each Codice As String In Madre.AgenzieCollegate

            Dim Figlia As New Utx.AgenziaFigliaOmnia(Codice, Madre.CodiceSede)

            MsgBox(Figlia.Cartelle.DatabaseDbUno)

            For Each Config As Utx.RecordConfigOmnia In Figlia.Config
                'fai qualcosa
                Debug.Print(Config.AgenziaCollegata)
            Next
        Next
        Assert.IsTrue(True)
    End Sub

    '<TestMethod>
    Public Sub Unzip()
        'LibreriaZip.UnZipToFolder("C:\Users\Guido\Desktop\Omnia.20160424.zip", "U:\UT\Test")
        Assert.IsTrue(True)
    End Sub

    <TestMethod>
    Public Sub testTipoAttivita()
        'Utx.Globale.IdApp(System.Text.Encoding.UTF8.GetString(New Byte() {57, 60, 88, 93, 65, 58, 71}))
        'Utx.Globale.Init()

        'Utx.Globale.UtenteCorrente = New Utx.Utente
        'Utx.Globale.SettingGlobale = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.GLOBALE)
        'Utx.Globale.SettingInterop = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.INTEROP)
        'Utx.Globale.ProfiloEnteGestore = New Utx.EnteGestore
        'Utx.Globale.AgenziaRichiesta = New Utx.Agenzia(CInt(Utx.Globale.ProfiloEnteGestore.AgenziaMadre))
        'RegistroAttivita.CreaTabellaTipoAttivita()
    End Sub


End Class

#End If
