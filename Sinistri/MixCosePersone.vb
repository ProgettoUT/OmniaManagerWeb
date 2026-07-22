Public Class MixCosePersone

    Public Enum TipoDanno
        COSE
        PERSONE
    End Enum
    Public Enum TipoMix
        NORMALE
        GESTIONARIO
    End Enum

    Private mInizio As Date
    Public Property Inizio() As Date
        Get
            Return mInizio
        End Get
        Set(value As Date)
            mInizio = value
        End Set
    End Property

    Private mFine As Date
    Public Property Fine() As Date
        Get
            Return mFine
        End Get
        Set(value As Date)
            mFine = value
        End Set
    End Property

    Public Function CreaDataTable() As DataTable
        Try
            Dim sql As String = "SELECT STR(RamoPolizza) AS Ramo,
                0 AS Cose,0 AS Persone,CAST(0 AS decimal) AS Mix,CAST(0 AS decimal) AS Diff,CAST(0 AS decimal) AS GCose,
                0 As GPersone,CAST(0 AS decimal) AS MixGest,CAST(0 AS decimal) AS DiffGest 
                FROM SinistriDP 
                WHERE RamoSinistro = 30 
                GROUP BY RamoPolizza
                ORDER BY RamoPolizza"
            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(sql).DataTable
            'aggiungo la riga totali
            dt.Rows.Add({"Totali", 0, 0, 0, 0, 0, 0, 0, 0})

            Return dt

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Function Calcola(Tipo As TipoDanno,
                            Mix As TipoMix,
                            Ramo As Integer) As Integer
        Try
            Dim Sql As New Utx.NetFunc.StringFormatter("SELECT COUNT(*) AS Nr 
                 FROM SinistriDP
                 WHERE (FlagCosePersone = '@flag') AND  
                       (RamoPolizza = @ramopolizza) AND 
                       (RamoSinistro = 30) AND 
                       (AgenziaSinistro > 0) AND 
                       (DataDenuncia BETWEEN '@inizio' AND '@fine') AND 
                       (TipoCid @tipocid) AND 
                       (StatoBilancistico <> 'SS') AND 
                       (TipoDelega <> '2')")
            'parametri
            With Sql.Parametri
                .Add("@inizio", Format(Inizio, "dd/MM/yyyy"))
                .Add("@fine", Format(Fine, "dd/MM/yyyy"))
                Select Case Mix
                    Case TipoMix.NORMALE : .Add("@tipocid", "NOT IN ('1','5','8')")
                    Case TipoMix.GESTIONARIO : .Add("@tipocid", "IN ('1','5')")
                End Select
                Select Case Tipo
                    Case TipoDanno.COSE : .Add("@flag", "C")
                    Case TipoDanno.PERSONE : .Add("@flag", "P")
                End Select
                .Add("@ramopolizza", Ramo)
            End With

            Return Utx.WsCommand.ExecuteScalar(Sql.StringaFormattata).Valore

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return 0
        End Try
    End Function
End Class
