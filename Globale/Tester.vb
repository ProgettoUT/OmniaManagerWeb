Public Class Tester

    Public Shared Function GestioneCassa(Agenzia As String) As Boolean
        Return "01949;01197;02212".Contains(Agenzia)
    End Function

    Public Shared Function BDA(Agenzia As String) As Boolean
        Return "01949;02379".Contains(Agenzia)
    End Function

    Public Shared Function Lettere(Agenzia As String) As Boolean
        Return "01949;02379".Contains(Agenzia)
    End Function

    Public Shared Function WhatsApp(Agenzia As String) As Boolean
        Return "01197".Contains(Agenzia)
    End Function

    Public Shared Function SiComunica(Agenzia As String) As Boolean
        Return "01949".Contains(Agenzia)
    End Function

    Public Shared Function NuovoEstrattore(Agenzia As String) As Boolean
        Return "01197;01949;02126;02379".Contains(Agenzia)
    End Function

    Public Shared Function SinistriControparte(Agenzia As String) As Boolean
        Return "01197;01949;02126;02364;02379".Contains(Agenzia)
    End Function

    Public Shared Function Postalizzazione(Agenzia As String) As Boolean
        Return "01949;02126;02178;02364;02379;02406;02486;02534;02675;39329".Contains(Agenzia)
    End Function

    Public Shared Function TestUtente(Agenzia As String) As Boolean
        Return "02364;02379".Contains(Agenzia)
    End Function

    Public Shared Function TestSiaMA(Agenzia As String) As Boolean
#If DEBUG Then
        Return True
#Else
        'Return False
        Return "02379".Contains(Agenzia)
#End If
    End Function

    Public Shared Function EsisteAgenziaXml() As Boolean
        Return IO.File.Exists(FileAgenziaXml)
    End Function

    Public Shared Function FileAgenziaXml() As String
        Return IO.Path.Combine(Utx.Globale.Paths.CartellaApp, "Modelli\Setting\AgenziaTest.setting.xml")
    End Function

    Public Shared Function SettingAgenziaXml() As ApplicationUserSetting
        Return New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.EXTRA, "AgenziaTest")
    End Function

    Public Shared Function BottoneTest(Agenzia As String) As Boolean
#If DEBUG Then
        Return True
#Else
        Return "01197".Contains(Agenzia)
#End If
    End Function
End Class
