#If DEBUG Then
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization

<TestClass>
Public Class TestEssig
    Public TestContext As TestContext

    <TestMethod>
    Public Sub ScaricaAvvisiGenerati()
        Dim annomese As String = "201712"
        Inizializza()
        Dim Login As New Utx.AutenticazioneCRM
        Login.LogIn("164164aa", "Unipol01", "uniage")
        Dim A1 As String = Login.CallWeb("https://essig.unipolsai.it/wps/myportal/CRM/Quietanzamento/AvvisiDiScadenza/GestioneAvvisiGenerati/") 'menu: avvisi generati
        Dim A2 As String = Login.CallWeb("https://essig.unipolsai.it/wps/PA_crm/lilithAS/lth?req=login&ts=" & Now.Ticks.ToString)

        Dim i As Integer = A2.IndexOf("cur_token")
        A2 = A2.Substring(11 + i)
        i = A2.IndexOf("'")
        Dim tk As String = A2.Substring(0, i)

        Dim B1 As String = Login.CallWeb(String.Format("https://essig.unipolsai.it/wps/PA_crm/lilithAS/lth?req=struct&tk={0}&id=0", tk))
        Dim B2 As String = Login.CallWeb(String.Format("https://essig.unipolsai.it/wps/PA_crm/lilithAS/lth?req=dty&type=snippet&tk={0}&id=0&AS_ANNOMESE$={1}", tk, annomese))
        Dim B3 As String = Login.CallWeb(String.Format("https://essig.unipolsai.it/wps/PA_crm/lilithAS/lth?req=struct&tk={0}&id=-1", tk))
        Dim B4 As String = Login.CallWeb(String.Format("https://essig.unipolsai.it/wps/PA_crm/lilithAS/lth?req=chart&tk={0}&id=-1&griddata=0", tk))

        Dim C1 As String = Login.CallWeb(String.Format("https://essig.unipolsai.it/wps/PA_crm/lilithAS/lth?req=dty&type=snippet&tk={0}&datasubmit=OnDashboardClick", tk), "userGrid$=dashboard&userRow$=5&userCol$=c0")
        Dim C2 As String = Login.CallWeb(String.Format("https://essig.unipolsai.it/wps/PA_crm/lilithAS/lth?req=dty&type=snippet&tk={0}&AS_ANNOMESE$={1}", tk, annomese))
        Dim C3 As String = Login.CallWeb(String.Format("https://essig.unipolsai.it/wps/PA_crm/lilithAS/lth?req=struct&tk={0}&id=-1", tk))
        Dim C4 As String = Login.CallWeb(String.Format("https://essig.unipolsai.it/wps/PA_crm/lilithAS/lth?req=chart&tk={0}&id=-1&griddata=0", tk))

        'l'export in csv presuppone un POST con l'invio di tutti i dati. Tanto vale importare direttamente l'xml
        'Dim C5 As String = Login.CallWeb(String.Format("https://essig.unipolsai.it/wps/PA_crm/lilithAS/lth?req=dty&type=snippet&tk={0}&datasubmit=AzioneSaveConfig", tk))
        'Dim C6 As String = Login.CallWeb(String.Format("https://essig.unipolsai.it/wps/PA_crm/lilithAS/lth?req=chart&tk={0}&id=-1&gridcsv=0", tk))

        File.WriteAllText(Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "CRM.xml"), C4)
        Assert.IsTrue(True)
    End Sub

    Private Function getTime() As String
        Dim t As Long = Now.Ticks
        Return "&time=" & Right(t, 6)
    End Function

    <TestMethod>
    Public Sub ScaricaPrimaNota()
        Inizializza()
        Dim Login As New Utx.AutenticazioneEssig
        Login.LogIn("102379ac", "serena11", "uniage")

        Debug.Print(Login.CallWeb("https://essig.unipolsai.it/essigmenu/menu.do?itemId=0401000000&parametri=")) 'menu: contabilità
        Debug.Print(Login.CallWeb("https://essig.unipolsai.it/essigCP/start.do?itemId=0401080000&parametri=CP++PNAG")) 'menu prima nota
        Debug.Print(Login.CallWeb("https://essig.unipolsai.it/essigCP/danni/contabpremi/paginaIC01.do?method=Elabora&paginaRitornoStampa=&funzione.value=1&agenzia.value=2379")) 'ricerca (quadratura provvisoria)
        Debug.Print(Login.CallWeb("https://essig.unipolsai.it/essigCP/danni/contabpremi/paginaIC02.do?method=Elabora&paginaRitornoStampa=&selezione.value=2&codFiscContraente.value=&subagente.value=&userID.value=&banca.value=&dataRegistrazioneDa.value=16%2F06%2F2017&dataRegistrazioneA.value=16%2F06%2F2017")) 'Elabora (per agenzia)
        Debug.Print(Login.CallWeb("https://essig.unipolsai.it/essigCP/danni/contabpremi/exportCsvIC03.do?method=exportCsv&paginaRitornoStampa=&saldoCassa=217%2C47&saldoBanca=-111.719%2C13&saldoAltro=18.252.649%2C77&totaleCassa=261%2C59&totaleBanca=-87.721%2C34&totaleAltro=18.255.794%2C17")) 'Esporta

        Debug.Print(Login.CallWeb("https://essig.unipolsai.it/essigCP/danni/contabpremi/paginaIC02.do?method=Elabora&paginaRitornoStampa=&selezione.value=7&codFiscContraente.value=&subagente.value=&userID.value=&banca.value=&dataRegistrazioneDa.value=16%2F06%2F2017&dataRegistrazioneA.value=16%2F06%2F2017")) 'Elabora (per date)
        Debug.Print(Login.CallWeb("https://essig.unipolsai.it/essigCP/danni/contabpremi/paginaIC03.do?method=Dettaglio&paginaRitornoStampa=&saldoCassa=217%2C47&saldoBanca=-111.719%2C13&saldoAltro=18.252.649%2C77&totaleCassa=261%2C59&totaleBanca=-87.721%2C34&totaleAltro=18.255.794%2C17&selectedItems=1")) 'dettaglio
        Debug.Print(Login.CallWeb("https://essig.unipolsai.it/essigCP/danni/contabpremi/paginaIC05.do?paginaRitornoStampa=&selezione.value=2&method=Elabora")) 'selezione ordinamento (per ) quindi elabora
        Debug.Print(Login.CallWeb("https://essig.unipolsai.it/essigCP/danni/contabpremi/exportCsvIC04.do?method=exportCsv&paginaRitornoStampa=&rowNumber.value=&totaleCassa=44%2C12&totaleBanca=23.997%2C79&totaleAltro=3.144%2C40")) 'esporta

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
        Utx.Globale.AgenziaRichiesta = New Utx.Agenzia(2379)
        Utx.Globale.Log = New Utx.ApplicationLog("OmniaDebug", Nothing, Nothing, True)
        'Utx.Globale.ProfiloEnteGestore.Abilitazioni.LeggiAbilitazioni()
    End Sub

    <TestMethod>
    Public Sub LeggiDatiCliente()
        'Inizializza()
        Essig.Portale = New Utx.AutenticazioneEssig
        Essig.Portale.LogIn("102372ai", "Ferroviario3.", "uniage")

        Dim dt As DataTable = Essig.LeggiDatiCliente("00482280014", "02372")
        Dim f As New Utx.FormDebug(dt)
        f.ShowDialog()

        Essig.Portale = Nothing
        Assert.IsTrue(True)
    End Sub

End Class
#End If
