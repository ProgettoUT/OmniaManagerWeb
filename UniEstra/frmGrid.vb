Class frmGrid
    Inherits UniSql.frmGrid

    'per eseguire l'estrattore ed ottenere il dt
#If DEBUG Then
    'Shared Sub New()
    '    System.Environment.SetEnvironmentVariable("UNITOOLS_STRINGA_CONNESSIONE_DB", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=U:\Unitools\Dati\dblink.mdb")
    '    System.Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_DATI", "C:\Sviluppo\Unitools\Risorse\Dati\")
    '    System.Environment.SetEnvironmentVariable("UNITOOLS_AMBIENTE", "PP")
    'End Sub

    'Sub New()
    '    UsoStampa = True
    'End Sub
#End If

#If DEBUG Then
    'Dim sObj As String = Command()
    'Dim sql As New UniSql.UniSql

    'Dim cancella As Boolean
    'Dim i = sql.ExistObject("Polizze sostituite e stornate")
    'Dim manifesto = sql.GetSqlAsObject("Polizze sostituite e stornate")
    'Dim t = sql.ShowGridAndGetDataTable(sObj, cancella, "DBA", "Interroga database", Image.FromFile("C:\Sviluppo\immagini\merge32.gif"))
    'Dim k = MsgBox(cancella)
    'Dim a = sql.AggiornaCatalogoEstrazioni(False)

    Private Sub frmGrid_Load1(sender As Object, e As EventArgs) Handles Me.Load
        'ExecuteMfs("Titoli arretrati")
        Dim sObj As String = Command()
        ExecuteMfs(sObj)
    End Sub
#Else
    Private Sub frmGrid_Load1(sender As Object, e As EventArgs) Handles Me.Load
        Dim sObj As String = Command()
        ExecuteMfs(sObj)
    End Sub
#End If
End Class
