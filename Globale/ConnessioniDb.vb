Imports System.IO

Public Class ConnessioniDb

    Public Enum Db
        ANAG
        ANDAMENTI
        BUDGET
        CASSA
        CLIENTI
        EVIDENZE
        INCASSI
        INFO
        LISTE
        NOTE
        POLIZZE
        PRIMANOTA
        REPLICA
        SINISTRI
        SINISTRIEXTRA
        UNICOOP
        UTSTORICO
        SMS
        SUPPORTO
        TITOLI
        DBUNO
        DBLINK
    End Enum

    Public Shared Function ConnectionString(Database As Db) As String
        'connessioni per l'agenzia corrente
        Select Case Database
            Case Db.DBUNO
                Return String.Format("{0}{1}\{2}\OMNIA\{3}.mdb",
                                     Utx.Globale.MDBDriver,
                                     Utx.Globale.Paths.CartellaArchivioDati,
                                     Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                     Database.ToString)
            Case Db.SMS, Db.SUPPORTO
                Return String.Format("{0}{1}\00000\{2}.mdb",
                                     Utx.Globale.MDBDriver,
                                     Utx.Globale.Paths.CartellaDati,
                                     Database.ToString)
            Case Else
                Return String.Format("{0}{1}\{2}\{3}.mdb",
                                     Utx.Globale.MDBDriver,
                                     Utx.Globale.Paths.CartellaDati,
                                     Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                     Database.ToString)
        End Select
    End Function

    Public Shared Function ConnectionString(Database As String) As String
        Database = Path.GetFileNameWithoutExtension(Database).ToLower
        'connessioni per l'agenzia corrente
        Select Case Database
            Case "dbuno"
                Return String.Format("{0}{1}\{2}\OMNIA\{3}.mdb",
                                     Utx.Globale.MDBDriver,
                                     Utx.Globale.Paths.CartellaArchivioDati,
                                     Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                     Database)
            Case "sms", "supporto"
                Return String.Format("{0}{1}\00000\{2}.mdb",
                                     Utx.Globale.MDBDriver,
                                     Utx.Globale.Paths.CartellaDati,
                                     Database)
            Case Else
                Return String.Format("{0}{1}\{2}\{3}.mdb",
                                     Utx.Globale.MDBDriver,
                                     Utx.Globale.Paths.CartellaDati,
                                     Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                     Database)
        End Select
    End Function

    Public Shared Function ConnectionString(Agenzia As String,
                                            Database As Db) As String
        Agenzia = Agenzia.PadLeft(5, "0")

        Select Case Database
            Case Db.DBUNO
                Return String.Format("{0}{1}\{2}\OMNIA\{3}.mdb",
                                 Utx.Globale.MDBDriver,
                                 Utx.Globale.Paths.CartellaArchivioDati,
                                 Agenzia,
                                 Database.ToString)
            Case Db.DBLINK
                Return String.Format("{0}{1}\DbLink.{2}.mdb",
                                     Utx.Globale.MDBDriver,
                                     Utx.Globale.Paths.CartellaTempUtente,
                                     Agenzia)
            Case Else
                If Agenzia = "00000" Then
                    Return String.Format("{0}{1}\{2}.mdb",
                                     Utx.Globale.MDBDriver,
                                     Utx.Globale.Paths.CartellaDatiComuni,
                                     Database.ToString)
                Else
                    Return String.Format("{0}{1}\{2}\{3}.mdb",
                                     Utx.Globale.MDBDriver,
                                     Utx.Globale.Paths.CartellaDati,
                                     Agenzia,
                                     Database.ToString)
                End If
        End Select
    End Function

    Public Shared Function ConnectionString(Agenzia As String,
                                            Database As String) As String
        Agenzia = Agenzia.PadLeft(5, "0")
        Database = Path.GetFileNameWithoutExtension(Database).ToLower

        If Database = "dbuno" Then
            Return String.Format("{0}{1}\{2}\OMNIA\{3}.mdb",
                                 Utx.Globale.MDBDriver,
                                 Utx.Globale.Paths.CartellaArchivioDati,
                                 Agenzia,
                                 Database)
        Else
            If Agenzia = "00000" Then
                Return String.Format("{0}{1}\{2}.mdb",
                                     Utx.Globale.MDBDriver,
                                     Utx.Globale.Paths.CartellaDatiComuni,
                                     Database)
            Else
                Return String.Format("{0}{1}\{2}\{3}.mdb",
                                     Utx.Globale.MDBDriver,
                                     Utx.Globale.Paths.CartellaDati,
                                     Agenzia,
                                     Database)
            End If
        End If
    End Function

    ''' <summary>
    ''' Full path database per l'agenzia selezionata
    ''' </summary>
    ''' <param name="Database"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PathMdb(Database As Db) As String
        Select Case Database
            Case Db.DBUNO
                Return String.Format("{0}\{1}\OMNIA\{2}.mdb",
                                     Utx.Globale.Paths.CartellaArchivioDati,
                                     Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                     Database.ToString)
            Case Db.SMS, Db.SUPPORTO
                Return Path.Combine(Utx.Globale.Paths.CartellaDatiComuni, Utx.NetFunc.ToTitleCase(Database.ToString.ToLower) + ".mdb")
            Case Else
                Return Path.Combine(Utx.Globale.AgenziaRichiesta.CartellaDati, Utx.NetFunc.ToTitleCase(Database.ToString.ToLower) + ".mdb")
        End Select
    End Function

    ''' <summary>
    ''' Full path del database per il codice agenzia
    ''' </summary>
    ''' <param name="Database"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PathMdbAgenzia(Agenzia As String, Database As Db) As String
        Select Case Database
            Case Db.DBUNO
                Return String.Format("{0}\{1}\OMNIA\{2}.mdb",
                                     Utx.Globale.Paths.CartellaArchivioDati,
                                     Agenzia,
                                     Database.ToString)
            Case Db.DBLINK
                Return String.Format("{0}\DbLink.{1}.mdb", Utx.Globale.Paths.CartellaTempUtente, Agenzia)
            Case Db.SMS, Db.SUPPORTO
                Return String.Format("{0}\Dati\00000\{1}.mdb", Utx.Globale.Paths.CartellaUnitoolsRete, Database.ToString.ToLower)
            Case Else
                Return String.Format("{0}\Dati\{1}\{2}.mdb", Utx.Globale.Paths.CartellaUnitoolsRete, Agenzia, Database.ToString.ToLower)
        End Select
    End Function

    Public Shared Function PathMdbAgenzia(Agenzia As String, Database As String) As String
        Database = Path.GetFileNameWithoutExtension(Database).ToLower
        Select Case Database
            Case "dbuno"
                Return String.Format("{0}\{1}\OMNIA\{2}.mdb",
                                     Utx.Globale.Paths.CartellaArchivioDati,
                                     Agenzia,
                                     Database)
            Case "dblink"
                Return String.Format("{0}\DbLink.{1}.mdb", Utx.Globale.Paths.CartellaTempUtente, Database)
            Case "sms", "supporto"
                Return String.Format("{0}\Dati\00000\{1}.mdb", Utx.Globale.Paths.CartellaUnitoolsRete, Database)
            Case Else
                Return String.Format("{0}\Dati\{1}\{2}.mdb", Utx.Globale.Paths.CartellaUnitoolsRete, Agenzia, Database)
        End Select
    End Function

    Public Shared Function PathMdbModello(Database As Db) As String
        Select Case Database
            Case Db.DBUNO, Db.DBLINK
                Return String.Format("{0}\{1}.mdb", Utx.Globale.Paths.CartellaModelli, Database.ToString)
            Case Db.SMS, Db.SUPPORTO
                Return String.Format("{0}\{1}.mdb", Utx.Globale.Paths.CartellaModelliDatiComuni, Database.ToString)
            Case Else
                Return String.Format("{0}\{1}.mdb", Utx.Globale.Paths.CartellaModelliDatiAgenzia, Database.ToString)
        End Select
    End Function

    Public Shared Function PathMdbModello(Database As String) As String
        Database = Path.GetFileNameWithoutExtension(Database).ToLower
        Select Case Database
            Case "dbuno", "dblink"
                Return String.Format("{0}\{1}.mdb", Utx.Globale.Paths.CartellaModelli, Database)
            Case "sms", "supporto"
                Return String.Format("{0}\{1}.mdb", Utx.Globale.Paths.CartellaModelliDatiComuni, Database)
            Case Else
                Return String.Format("{0}\{1}.mdb", Utx.Globale.Paths.CartellaModelliDatiAgenzia, Database)
        End Select
    End Function

    Public Shared Function PathMdbLocale(Database As Db) As String
        Select Case Database
            Case Db.SMS, Db.SUPPORTO
                Return String.Format("{0}\Dati\00000\{1}.mdb",
                                     Utx.Globale.Paths.CartellaApp,
                                     Database.ToString.ToLower)
            Case Else
                Return String.Format("{0}\Dati\{1}\{2}.mdb",
                                     Utx.Globale.Paths.CartellaApp,
                                     Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                     Database.ToString.ToLower)
        End Select
    End Function

    Public Shared Function EsisteDbUno(Agenzia As String) As String
        Return File.Exists(String.Format("{0}\{1}\OMNIA\DbUno.mdb", Utx.Globale.Paths.CartellaArchivioDati, Agenzia))
    End Function

    Public Shared Function EsisteDb(Agenzia As String, Db As Db) As Boolean
        Return File.Exists(PathMdbAgenzia(Agenzia, Db))
    End Function

    Public Shared Function CartellaDatiAgenzia(Agenzia As String) As String
        Return String.Format("{0}\{1}", Utx.Globale.Paths.CartellaDati, Agenzia)
    End Function
End Class
