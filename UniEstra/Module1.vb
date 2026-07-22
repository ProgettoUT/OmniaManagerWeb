#If DEBUG Then
Module Module1
    Sub New()
        System.Environment.SetEnvironmentVariable("UNITOOLS_STRINGA_CONNESSIONE_DB", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=U:\UT\Temp\Guido\DbLink.02379.mdb")
        System.Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_DATI", "C:\ApplicazioniDirezione\UT")
        System.Environment.SetEnvironmentVariable("UNITOOLS_AMBIENTE", "PP")
    End Sub

    Sub Main()
        Dim sql As New UniSql.UniSql


        'test 1
        'Dim cancella As Boolean
        'sql.ShowGridAndGetDataTable("Clienti senza polizze prodotto", cancella, "DBA", "Interroga database", Image.FromFile("C:\Sviluppo\immagini\merge32.gif"))


        ''test 2
        'Dim parametri As New Dictionary(Of String, String)
        'parametri.Add("@subagenzia", "200")
        'Console.WriteLine(sql.GetSqlAsString("Queries\Provvigioni per subagente - dettaglio", parametri))

        'test 3
        Dim parametri As New Dictionary(Of String, String)
        parametri.Add("@subagenzia", "200")
        Dim a = sql.GetDataTable("Clienti con polizze vita", parametri)
        If a IsNot Nothing Then
            Console.WriteLine("Data table is ok!!!")
        End If

        Console.WriteLine("Premi un tasto.")
        Console.ReadKey()
    End Sub

End Module
#End If