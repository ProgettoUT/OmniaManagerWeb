Option Compare Text

Imports System.Data.OleDb

Public Class ControlloVersione

    Friend Const LivelloBase As String = "PROD"
    Private Log As ApplicationLog

    Friend Esito As New EsitoServizio

    Sub New(ByVal Compagnia As Integer,
            ByVal CodiceAgenzia As String,
            ByVal VersioneCorrente As String,
            ByVal Ambiente As String,
            ByVal CartellaLog As String)

        mCompagnia = Compagnia
        mCodiceAgenzia = CodiceAgenzia
        mVersioneCorrente = VersioneCorrente
        mAmbiente = Ambiente

        Log = New ApplicationLog(CartellaLog, "ControlloComponenti.log")

        'l'ambiente PP2DIR che viene trasmesso è equivalente a PP
        If mAmbiente = "PP2DIR" Then
            mAmbiente = "PP"
        End If
    End Sub

    Private mCompagnia As String
    Public ReadOnly Property Campagnia() As String
        Get
            Return mCompagnia
        End Get
    End Property

    Private mCodiceAgenzia As String
    Public ReadOnly Property CodiceAgenzia() As String
        Get
            Return mCodiceAgenzia
        End Get
    End Property

    Private mVersioneCorrente As String
    Public ReadOnly Property VersioneCorrente() As String
        Get
            Return mVersioneCorrente
        End Get
    End Property

    Private mAmbiente As String
    Public ReadOnly Property Ambiente() As String
        Get
            Return mAmbiente
        End Get
    End Property

    Private mCnConfigDb As String
    Public WriteOnly Property CnConfigDb() As String
        Set(ByVal value As String)
            mCnConfigDb = value
        End Set
    End Property

    Private mCnControlloVersioneDb As String
    Public WriteOnly Property CnControlloVersioneDb() As String
        Set(ByVal value As String)
            mCnControlloVersioneDb = value
        End Set
    End Property

    Friend Function Componenti(ByRef Agenzia As DatiAgenzia) As DataTable

        Try
            'tabella dei componenti del livello base (PROD)
            Dim dtBase As DataTable = Me.Componenti(ControlloVersione.LivelloBase)

            'restituisco il livello dell'agenzia
            Agenzia.Livello = Me.RilevaLivelloAgenzia

            For Each Livello As String In Agenzia.Livello.Split(";")

                'se il livello è diverso da quello base
                If Livello <> ControlloVersione.LivelloBase Then

                    'tabella dei componenti del livello dell'agenzia
                    Dim dtLivello As DataTable = Me.Componenti(Livello)

                    For Each rowLivello As DataRow In dtLivello.Rows

                        For Each rowBase As DataRow In dtBase.Rows

                            If StessoModulo(rowBase, rowLivello) = True Then
                                'la riga con quel modulo esiste già e quindi la cancello per sostituirla
                                dtBase.Rows.Remove(rowBase)
                                Exit For
                            End If
                        Next

                        'aggiungo la riga
                        dtBase.LoadDataRow(rowLivello.ItemArray, True)
                    Next
                End If
            Next

            Return dtBase

        Catch ex As Exception
            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
            Log.BoxErrore(ex)
            Return New DataTable
        End Try

    End Function

    Friend Function ElementiDaEliminare(ByRef Agenzia As DatiAgenzia,
                                        ByVal TipoElemento As String) As DataTable
        Try
            'tabella base
            Dim dtBase As DataTable = Me.ElementiDaEliminare(ControlloVersione.LivelloBase, TipoElemento)

            For Each Livello As String In Agenzia.Livello.Split(";")

                'se l'agenzia ha un livello diverso da quello base
                If Livello <> ControlloVersione.LivelloBase Then

                    'tabella dei componenti del livello dell'agenzia
                    Dim dtLivello As DataTable = Me.ElementiDaEliminare(Livello, TipoElemento)

                    For Each rowLivello As DataRow In dtLivello.Rows

                        For Each rowBase As DataRow In dtBase.Rows

                            If StessoModulo(rowBase, rowLivello) = True Then
                                'la riga con quel modulo esiste già e quindi la cancello per poi aggiungerla
                                dtBase.Rows.Remove(rowBase)
                                Exit For
                            End If
                        Next

                        'aggiungo la riga
                        dtBase.LoadDataRow(rowLivello.ItemArray, True)
                    Next
                End If
            Next

            Return dtBase

        Catch ex As Exception
            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
            Log.BoxErrore(ex)
            Return New DataTable
        End Try
    End Function

    Private Function StessoModulo(ByRef Base As DataRow,
                                  ByRef Livello As DataRow) As Boolean
        Try
            Return (Base("Ambiente").ToString.ToUpper = Livello("Ambiente").ToString.ToUpper) AndAlso
                   (Base("Modulo").ToString.ToUpper = Livello("Modulo").ToString.ToUpper) AndAlso
                   (Base("Destinazione").ToString.ToUpper = Livello("Destinazione").ToString.ToUpper)

        Catch ex As Exception
            Return False
        End Try
    End Function

    Friend Function Componenti(ByVal LivelloRichiesto As String) As DataTable
        Try
            Using cn As New OleDbConnection(mCnControlloVersioneDb)

                cn.Open()

                Using cmd As New OleDbCommand

                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT cv.*, c.Path AS PathDestinazione, c.Unita " +
                                      "FROM ControlloVersione20 cv " +
                                      "INNER JOIN Cartelle c ON c.Cartella = cv.Destinazione " +
                                      "WHERE (cv.Livello = ?) AND " +
                                            "(cv.VersioneUT = ? AND c.VersioneUT = ?) AND " +
                                            "(Ambiente = ? OR Ambiente = 'DIR/PP') " +
                                      "ORDER BY Modulo"

                    cmd.Parameters.AddWithValue("Livello", LivelloRichiesto)
                    cmd.Parameters.AddWithValue("Versione1", mVersioneCorrente)
                    cmd.Parameters.AddWithValue("Versione2", mVersioneCorrente)
                    cmd.Parameters.AddWithValue("Ambiente", mAmbiente)

                    Dim dt As New DataTable
                    Dim da As New OleDbDataAdapter(cmd)

                    da.Fill(dt)

                    Return dt
                End Using
            End Using

            Esito.EsitoChiamata = True

        Catch ex As Exception
            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
            Log.BoxErrore(ex)
            Return New DataTable
        End Try
    End Function

    Friend Function RilevaLivelloAgenzia() As String
        Try
            Using cn As New OleDbConnection(mCnControlloVersioneDb)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT TOP 1 Livello FROM LivelloAgenzie WHERE Compagnia = ? AND Agenzia = ?"

                    cmd.Parameters.AddWithValue("Compagnia", mCompagnia)
                    cmd.Parameters.AddWithValue("Agenzia", mCodiceAgenzia)

                    RilevaLivelloAgenzia = cmd.ExecuteScalar
                End Using
            End Using

            If String.IsNullOrEmpty(RilevaLivelloAgenzia) Then
                RilevaLivelloAgenzia = LivelloBase
            End If

            Esito.EsitoChiamata = True

            'Log.AddLog(String.Format("{0}.{1} Livello: {2}", mCompagnia, mCodiceAgenzia, RilevaLivelloAgenzia))

        Catch ex As Exception
            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
            Log.BoxErrore(ex)
            RilevaLivelloAgenzia = LivelloBase
            'Log.AddLog(String.Format("{0}.{1} Livello: {2} - Errore: {3}", mCompagnia, mCodiceAgenzia, RilevaLivelloAgenzia, ex.Message))
        End Try
    End Function

    Private Function ElementiDaEliminare(ByVal LivelloRichiesto As String,
                                         ByVal TipoElemento As String) As DataTable
        Try
            Using cn As New OleDbConnection(mCnControlloVersioneDb)

                cn.Open()

                Using cmd As New OleDbCommand

                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT e.*, c.Path AS PathDestinazione, c.Unita  " +
                                      "FROM ElementiDaEliminare e " +
                                      "INNER JOIN Cartelle c ON c.Cartella = e.Destinazione " +
                                      "WHERE (e.Livello = ?) AND " +
                                            "(e.VersioneUT = ? AND c.VersioneUT = ?) AND " +
                                            "(Ambiente = ? OR Ambiente = 'DIR/PP') AND " +
                                            "(Tipo = ?)"

                    cmd.Parameters.AddWithValue("Livello", LivelloRichiesto)
                    cmd.Parameters.AddWithValue("Versione1", mVersioneCorrente)
                    cmd.Parameters.AddWithValue("Versione2", mVersioneCorrente)
                    cmd.Parameters.AddWithValue("Ambiente", mAmbiente)
                    cmd.Parameters.AddWithValue("Tipo", TipoElemento)

                    Dim dt As New DataTable
                    Dim da As New OleDbDataAdapter(cmd)

                    da.Fill(dt)

                    Return dt
                End Using
            End Using

            Esito.EsitoChiamata = True

        Catch ex As Exception
            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
            Log.BoxErrore(ex)
            Return New DataTable
        End Try
    End Function
End Class
