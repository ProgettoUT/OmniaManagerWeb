Imports System.IO
Imports System.Data.OleDb

Public Class GestioneModelli

    Public Shared Function PathModelloDatabase(Database As Utx.ConnessioniDb.Db) As String

        Dim NomeDb As String = Path.GetFileNameWithoutExtension(Database.ToString)

        Select Case NomeDb
            Case Utx.ConnessioniDb.Db.SUPPORTO.ToString, Utx.ConnessioniDb.Db.SMS.ToString
                Return Path.Combine(Utx.Globale.Paths.CartellaModelliDatiComuni, NomeDb + ".mdb")
            Case Utx.ConnessioniDb.Db.DBUNO.ToString
                Return Path.Combine(Utx.Globale.Paths.CartellaModelli, NomeDb + ".mdb")
            Case Else
                Return Path.Combine(Utx.Globale.Paths.CartellaModelliDatiAgenzia, NomeDb + ".mdb")
        End Select
    End Function

    Public Shared Function CopiaModelloTabella(CodiceAgenzia As String,
                                               Database As ConnessioniDb.Db,
                                               TabellaOrigine As String,
                                               Optional TabellaDestinazione As String = "",
                                               Optional CopiaDati As Boolean = False,
                                               Optional Sovrascrivi As Boolean = False) As Boolean
        Try
            'se il nome destinazione non c'è lo fa uguale al nome origine
            If String.IsNullOrEmpty(TabellaDestinazione) Then
                TabellaDestinazione = TabellaOrigine
            End If

            'se il codice agenzia
            Dim DbOrigine As String = PathModelloDatabase(Database)

            If File.Exists(DbOrigine) Then
                Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, Database))
                    c.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = String.Format("SELECT * INTO {0} FROM {1} IN '{2}' WHERE {3}",
                                                        TabellaDestinazione, TabellaOrigine, DbOrigine, CopiaDati)
                        If Sovrascrivi = True Then
                            'per sovrascrivere cancello la tabella ed eseguo la query
                            Utx.FunzioniDb.CancellaTabella(c, TabellaDestinazione)
                            cmd.ExecuteNonQuery()
                            Utx.Globale.Log.Info(String.Format("Copiato modello della tabella '{0}' con nome '{1}' in '{2}'",
                                                                TabellaOrigine, TabellaDestinazione, Database.ToString))
                        Else
                            'non devo sovrascrivere ed eseguo la query solo se la tabella non esiste
                            If Utx.FunzioniDb.EsisteTabella(c, TabellaDestinazione) = False Then
                                cmd.ExecuteNonQuery()
                                Utx.Globale.Log.Info(String.Format("Copiato modello della tabella '{0}' con nome '{1}' in '{2}'",
                                                                    TabellaOrigine, TabellaDestinazione, Database.ToString))
                            End If
                        End If
                    End Using
                End Using
            Else
                Globale.Log.Info("Il database modello non esiste")
            End If

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Function CopiaModelloDatabase(CodiceAgenzia As String,
                                                Database As ConnessioniDb.Db,
                                                Optional Sovrascrivi As Boolean = False) As Boolean
        Try
            Dim Modello As String = PathModelloDatabase(Database)
            Dim Db As String = Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Database)

            If File.Exists(Modello) Then
                If File.Exists(Db) Then
                    If Sovrascrivi = True Then
                        File.Delete(Db)
                    Else
                        Return False
                    End If
                End If
                File.Copy(Modello, Db, True)
            Else
                Globale.Log.Info("Il database modello non esiste")
            End If
            Return True
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function
End Class
