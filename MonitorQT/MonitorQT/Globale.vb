Imports System.IO

Module Globale

    Public Log As New Utx.ApplicationLog("MonitorQT.log")

#If DEBUG Then
    Dim x As New CDebug
#End If

    'Friend Structure GlobalSet
    '    Friend ChiamataOk As Boolean
    '    Friend PathExe As String
    '    Friend PathDb As String
    '    Friend FullNameDbLink As String
    '    Friend DbBudget As String
    '    Friend UTModelliLoc As String
    '    Friend UTCartellaTemp As String
    '    Friend MDBProvider As String
    '    Friend MDBConnectionString As String
    '    Friend HelpFile As String
    '    Friend ReteAttiva As Boolean
    '    Friend Errore As Boolean
    'End Structure
    'Friend Glo As GlobalSet

    'Friend Sub ImpostaVariabiliGlobali()
    '    With Glo
    '        'controllo sulla chiamata da unitools
    '        .ChiamataOk = LeggiParametri()

    '        .PathExe = "C:\ApplicazioniDirezione\Unitools"
    '        If .ReteAttiva Then
    '            .PathDb = "M:\Unitools"
    '        Else
    '            .PathDb = "U:\Unitools"
    '        End If

    '        .UTModelliLoc = Path.Combine(Glo.PathExe, "Modelli")
    '        .UTCartellaTemp = Path.Combine(Glo.PathExe, "Temp")
    '        .MDBProvider = "Provider = Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source="
    '        .MDBConnectionString = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_STRINGA_CONNESSIONE_DB")
    '        .HelpFile = Path.Combine(Glo.PathExe, "Unitools.chm")
    '    End With

    '    Using c As New OleDb.OleDbConnection(Glo.MDBConnectionString)
    '        Glo.FullNameDbLink = c.DataSource
    '    End Using
    'End Sub

    'Private Function LeggiParametri() As Boolean
    '    Try
    '        Dim LineaComando As String = Microsoft.VisualBasic.Command()
    '        Dim Var() As String = LineaComando.Split(";")

    '        'controllo chiamata
    '        If UBound(Var) < 1 Then 'almeno 2 elementi (0 e 1)
    '            LeggiParametri = False
    '        Else
    '            If Var(0) = "075E27295AFD4173AD794ACD3ACA0984" Then
    '                Glo.ReteAttiva = (Var(1) = "DIR")
    '                LeggiParametri = True
    '            Else
    '                LeggiParametri = False
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Unitools", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        LeggiParametri = False
    '    End Try
    'End Function
End Module

#If DEBUG Then

Public Class CDebug

    Sub New()

        Environment.SetEnvironmentVariable("UNITOOLS_STRINGA_CONNESSIONE_DB",
                                           "Provider = Microsoft.Jet.OLEDB.4.0; User Id=; Password=;" +
                                           "Data Source=C:\ApplicazioniDirezione\Unitools\DbLink.Guido.mdb")
    End Sub
End Class

#End If

