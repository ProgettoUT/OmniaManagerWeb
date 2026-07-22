Imports System.IO

Public Class Globale

    'costanti
    Public Const TitoloApp As String = "Unitools - Gestione assegni"

    ''variabili condivise globali
    Public Shared Log As New Utx.ApplicationLog("Assegni.log")
    Public Shared CnString As String
    Public Shared AgenziaRichiesta As String
    Public Shared AgenziaMadre As String

#Region "Enumerazioni"
    Public Enum TipoAmbiente
        [DIR] = 0
        [PP] = 1
        [PP2DIR] = 2
    End Enum

#End Region

    Friend Shared Function IdApp() As String
        Return "Uniarea." + Format(Today, "yyyy-MM.dddd")
    End Function

    Public Shared Sub ImpostaVariabiliGlobali()
        AgenziaMadre = Utx.NetFunc.GetEnvironmentVar("UNITOOLS_AGENZIA_MADRE")
        AgenziaRichiesta = Utx.NetFunc.GetEnvironmentVar("UNITOOLS_AGENZIA_RICHIESTA")
        'la stringa di connessione fa sempre riferimento al db cassa dell'agenzia madre dove si conservano i dati di tutti gli assegni
        CnString = Utx.NetFunc.GetEnvironmentVar("UNITOOLS_STRINGA_CONNESSIONE_DB_CASSA")
        Utx.Globale.UtenteCorrente.UniageUser = Environment.GetEnvironmentVariable("UNITOOLS_UNIAGE_USER")
        Utx.Globale.UtenteCorrente.UniagePw = Environment.GetEnvironmentVariable("UNITOOLS_UNIAGE_PW")

        Log.Info("Agenzia madre: {0}", {AgenziaMadre})
        Log.Info("Agenzia richiesta: {0}", {AgenziaRichiesta})
        Log.Info("Connessione: {0}", {CnString})
    End Sub

    Friend Shared Function AgenziaSai() As Boolean
        Return (Utx.NetFunc.GetEnvironmentVar("UNITOOLS_AGENZIA_SAI") = "S")
    End Function

    Friend Shared Function ImpostaSai() As Boolean
        Try
            If Utx.NetFunc.GetEnvironmentVar("UNITOOLS_AGENZIA_SAI") = "S" Then

#If DEBUG Then
                Environment.SetEnvironmentVariable("UNITOOLS_AMBIENTE", "PP")
#End If
                If Utx.NetFunc.GetEnvironmentVar("UNITOOLS_AMBIENTE") = "DIR" Then
                    Environment.SetEnvironmentVariable("UNITOOLS_AGENZIA_RICHIESTA", Utx.FunzioniAmbiente.PcToAgenzia)
                Else
                    'non fare niente. il codice viene impostato in ASLoader
                End If

                Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_DATI", "M:\Unitools")
                Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_DOCUMENTI", "M:\Unitools\Documenti")
                Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_TEMP", "C:\ApplicazioniDirezione\Unitools\Temp\" +
                                                   Environment.UserName)

                'creo le cartelle se non esistono
                Directory.CreateDirectory(Utx.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_DATI"))
                Directory.CreateDirectory(Utx.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_DOCUMENTI"))
                Directory.CreateDirectory(Utx.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_TEMP"))

                Dim CartellaDatiAgenzia As String =
                    Utx.Globale.Paths.CartellaDati(Utx.NetFunc.GetEnvironmentVar("UNITOOLS_AGENZIA_RICHIESTA"))
                Directory.CreateDirectory(CartellaDatiAgenzia)

                'controllo esistenza file incassi.mdb
                Dim MdbIncassi As String = Path.Combine(CartellaDatiAgenzia, "Incassi.mdb")
                If File.Exists(MdbIncassi) = False Then
                    File.Copy("C:\ApplicazioniDirezione\Unitools\Modelli\Dati\Agenzia\Incassi.mdb", MdbIncassi)
                End If
                'controllo esistenza file cassa.mdb
                Dim MdbCassa As String = Path.Combine(CartellaDatiAgenzia, "Cassa.mdb")
                If File.Exists(MdbCassa) = False Then
                    File.Copy("C:\ApplicazioniDirezione\Unitools\Modelli\Dati\Agenzia\Cassa.mdb", MdbCassa)
                End If

                Environment.SetEnvironmentVariable("UNITOOLS_STRINGA_CONNESSIONE_DB",
                                                   String.Format("Provider = Microsoft.Jet.OLEDB.4.0; User Id=; Password=;" +
                                                                 "Data Source={0}\Cassa.mdb",
                                                                 CartellaDatiAgenzia))
            End If

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Friend Shared Sub ImpostaDebug()
#If DEBUG Then
        Select Case 1
            Case 1
                Environment.SetEnvironmentVariable("UNITOOLS_AGENZIA_MADRE", "02379")
                Environment.SetEnvironmentVariable("UNITOOLS_AGENZIA_RICHIESTA", "02379")
                Environment.SetEnvironmentVariable("UNITOOLS_AMBIENTE", "PP")
                Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_DATI", "M:\Unitools")
                Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_DOCUMENTI", "M:\Unitools\Documenti")
                Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_TEMP", "C:\ApplicazioniDirezione\Unitools\Temp\Guido")
                Environment.SetEnvironmentVariable("UNITOOLS_ASSEGNI_ID", "Uniarea." + Format(Now, "yyyy-MM.dddd"))
                Environment.SetEnvironmentVariable("UNITOOLS_STRINGA_CONNESSIONE_DB_CASSA",
                                                   "Provider = Microsoft.Jet.OLEDB.4.0; User Id=; Password=;" +
                                                   "Data Source=M:\Unitools\Dati\02379\Cassa.mdb")
            Case 2
                Environment.SetEnvironmentVariable("UNITOOLS_AGENZIA_RICHIESTA", "56595")
                Environment.SetEnvironmentVariable("UNITOOLS_AGENZIA_SAI", "S")
        End Select
#End If
    End Sub

    Public Shared Sub DoppioBuffer(ByRef dgv As DataGridView)
        dgv.GetType.InvokeMember("DoubleBuffered",
                                 Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, dgv,
                                 New Object() {True})
    End Sub

End Class
