Imports System.IO
Imports System.Data.OleDb

Public Class Globale

    Public Shared Log As Utx.ApplicationLog

    Private Shared mModo As String
    Public Shared ReadOnly Property Modo() As String
        Get
            Return mModo
        End Get
    End Property

    Private Shared mAgenzia As String
    Public Shared ReadOnly Property Agenzia() As String
        Get
            Return mAgenzia
        End Get
    End Property

    Private Shared mErrore As Boolean
    Public Shared Property Errore() As Boolean
        Get
            Return mErrore
        End Get
        Set(ByVal value As Boolean)
            mErrore = value
        End Set
    End Property

    Private Shared mRilevataAnomalia As Boolean
    Public Shared Property RilevataAnomalia() As Boolean
        Get
            Return mRilevataAnomalia
        End Get
        Set(ByVal value As Boolean)
            mRilevataAnomalia = value
        End Set
    End Property

    Private Shared mDbComuni As List(Of Database)
    Public Shared Property DbComuni() As List(Of Database)
        Get
            Return mDbComuni
        End Get
        Set(ByVal value As List(Of Database))
            mDbComuni = value
        End Set
    End Property

    Private Shared mDbAgenzia As List(Of Database)
    Public Shared Property DbAgenzia() As List(Of Database)
        Get
            Return mDbAgenzia
        End Get
        Set(ByVal value As List(Of Database))
            mDbAgenzia = value
        End Set
    End Property

    Private Shared mStrutturaTabelle As List(Of Tabella)
    Public Shared Property StrutturaTabelle() As List(Of Tabella)
        Get
            Return mStrutturaTabelle
        End Get
        Set(ByVal value As List(Of Tabella))
            mStrutturaTabelle = value
        End Set
    End Property

    Private Shared mVisualizzaNotifica As Boolean
    Public Shared Property VisualizzaNotifica() As Boolean
        Get
            Return mVisualizzaNotifica
        End Get
        Set(ByVal value As Boolean)
            mVisualizzaNotifica = value
        End Set
    End Property

    Friend Shared Sub ImpostaParametri()
        'command deve contenere i seguenti paramentri
        '0: modo operativo (B=backup/R=ripristino/T=recupero automatico tabelle)
        '1: visualizzazione notifica
        '2: elenco agenzie gestite (0 tutte/codice agenzia)
        Try
            mModo = Command.Split(";")(0)
            mVisualizzaNotifica = Command.Split(";")(1)
            mAgenzia = Command.Split(";")(2).PadLeft(5, "0")
            mErrore = False

        Catch ex As Exception
            'se non vengono passati dati va in modalità ripristino
            mModo = "R"
            mAgenzia = "00000"
            mErrore = False
        End Try
    End Sub

    Friend Shared Function ImpostaDatiGlobali() As Boolean
        Try
            'controlla esistenza di log mdb
            ControlloMdbLog()
            'inizializza array list struttura
            Return ElencoDatabaseUnitools() And ElencoTabelle()

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Shared Function ElencoDatabaseUnitools() As Boolean
        Try
            '+leggo i database dalla tabella struttura in DbLink
            Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT DISTINCT Database FROM Struttura ORDER BY Database"

                    Dim dr As OleDbDataReader = cmd.ExecuteReader

                    Globale.DbAgenzia = New List(Of Database)
                    Globale.DbComuni = New List(Of Database)

                    Do While dr.Read
                        'struttura oggetto: Database,check
                        If dr("Database") = "Supporto" OrElse dr("Database") = "Sms" Then
                            Globale.DbComuni.Add(New Database(dr("Database"), True))
                        Else
                            Globale.DbAgenzia.Add(New Database(dr("Database"), True))
                        End If
                    Loop

                    dr.Close()
                End Using
            End Using

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Shared Function ElencoTabelle() As Boolean
        Try
            Using cn As New OleDbConnection(Utx.Globale.CnDbLink)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Database,Tabella,Iif(Descrizione IS NULL,'',Descrizione) AS Desk " +
                                      "FROM Struttura " +
                                      "ORDER BY Database,Tabella"

                    Dim dr As OleDbDataReader = cmd.ExecuteReader

                    Globale.StrutturaTabelle = New List(Of Tabella)

                    Dim DbPrecedente As String = ""
                    Dim TblPrecedente As String = ""

                    Do While dr.Read
                        'struttura oggetto: Database,Tabella,Descrizione,numero record,check
                        If Not (dr("Database") = DbPrecedente And dr("Tabella") = TblPrecedente) Then
                            Globale.StrutturaTabelle.Add(New Tabella(dr("Database"), dr("Tabella"), dr("Desk"), 0, True))

                            DbPrecedente = dr("Database")
                            TblPrecedente = dr("Tabella")
                        End If
                    Loop

                    dr.Close()
                End Using
            End Using

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function
End Class
