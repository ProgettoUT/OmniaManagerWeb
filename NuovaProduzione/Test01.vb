#If DEBUG Then
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization

<TestClass>
Public Class Test01
    Public TestContext As TestContext

    <TestMethod>
    Public Sub TestNuovaProduzione()
        Inizializza()

        Dim finestra = New frmParametri
        finestra.ShowDialog()
        Assert.IsTrue(True)
    End Sub

    Public Sub Inizializza()
        Utx.Globale.IdApp(System.Text.Encoding.UTF8.GetString(New Byte() {57, 60, 88, 93, 65, 58, 71}))
        Utx.Globale.Paths = New Utx.ApplicationPath
        Utx.Globale.Paths.Inizializza("C:\ApplicazioniDirezione\UT", "X", "M")
        Utx.Globale.UtenteCorrente = New Utx.Utente
        Utx.Globale.SettingGlobale = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.GLOBALE)
        Utx.Globale.SettingInterop = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.INTEROP)
        Utx.Globale.UniProxy = New Utx.Proxy()
        Utx.Globale.ProfiloEnteGestore = New Utx.EnteGestore
        Utx.Globale.AgenziaRichiesta = New Utx.Agenzia(CInt(Utx.Globale.ProfiloEnteGestore.AgenziaMadre))
    End Sub
End Class

#End If
