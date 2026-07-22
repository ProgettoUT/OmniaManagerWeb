Imports System.IO
Imports System.Data.OleDb

Public Class Assegno

    Friend tag As Double

    Public Event CodeLineError()
    Public Event CodeLineOk()

    Private mDeposito As DepositoAssegni
    Private mDataIncasso As Date

    Sub New(ByVal Deposito As DepositoAssegni,
            ByVal DataIncasso As Date,
            ByVal Formato As String)
        mDeposito = Deposito
        mDataIncasso = DataIncasso
        mFormato = Formato
    End Sub

    Private mFormato As String
    Public Property Formato() As String
        Get
            Return mFormato
        End Get
        Set(ByVal value As String)
            mFormato = value
        End Set
    End Property

    Private mIdAssegno As String
    Public ReadOnly Property IdAssegno() As String
        Get
            Return mIdAssegno
        End Get
    End Property

    Private mFronte As String
    Public Property Fronte() As String
        Get
            Return mFronte
        End Get
        Set(ByVal value As String)
            mFronte = value
        End Set
    End Property

    Private mRetro As String
    Public Property Retro() As String
        Get
            Return mRetro
        End Get
        Set(ByVal value As String)
            mRetro = value
        End Set
    End Property

    Private mCodeLine As String
    Public Property CodeLine() As String
        Get
            Return mCodeLine
        End Get
        Set(ByVal value As String)
            mCodeLine = value
            Me.ControlloCodeLine()
        End Set
    End Property

    Private mImportoAssegno As Double
    Public Property ImportoAssegno() As Double
        Get
            Return mImportoAssegno
        End Get
        Set(ByVal value As Double)
            mImportoAssegno = value
        End Set
    End Property

    Private mNote As String
    Public Property Note() As String
        Get
            Return mNote
        End Get
        Set(ByVal value As String)
            mNote = value
        End Set
    End Property

    Private mDatiPolizza As DataRow
    Public Property DatiPolizza() As DataRow
        Get
            Return mDatiPolizza
        End Get
        Set(ByVal value As DataRow)
            mDatiPolizza = value
        End Set
    End Property

    Private mFullPathAssegno As String
    Public Property FullPathAssegno() As String
        Get
            Return mFullPathAssegno
        End Get
        Set(ByVal value As String)
            mFullPathAssegno = value
        End Set
    End Property

    Private mPathTempImg As String
    Public ReadOnly Property PathTempImg() As String
        Get
            Return Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "ImgTemp." + mFormato)
            'Return Path.Combine(mDeposito.CartellaAssegni(Today), "ImgTemp." + mFormato)
        End Get
    End Property

    Public Function RegistraAssegno() As Boolean
        Try
            Using cn As New OleDbConnection(Globale.CnString)

                cn.Open()

                Using cmd As New OleDbCommand

                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "INSERT INTO Assegni (Contraente,Ramo,Polizza,DataEffettoTitolo," +
                                                           "DataFoglioCassa,IdAssegno," +
                                                           "ImportoIncassato,ImportoAssegno,Annotazioni) " +
                                      "VALUES (?,?,?,?,?,?,?,?,?)"

                    cmd.Parameters.AddWithValue("Contraente", Left(Trim(mDatiPolizza("Contraente")), 40))
                    cmd.Parameters.AddWithValue("Ramo", mDatiPolizza("Ramo"))
                    cmd.Parameters.AddWithValue("Polizza", mDatiPolizza("Polizza"))
                    cmd.Parameters.AddWithValue("DataEffetto", mDatiPolizza("DataEffettoTitolo"))
                    cmd.Parameters.AddWithValue("DataFoglioCassa", mDatiPolizza("DataFoglioCassa"))
                    'cmd.Parameters.AddWithValue("DataFoglioCassa", mDataIncasso.Date)
                    cmd.Parameters.AddWithValue("IdAssegno", mIdAssegno)
                    cmd.Parameters.AddWithValue("ImportoIncassato", mDatiPolizza("ImportoIncassato"))
                    cmd.Parameters.AddWithValue("ImportoAssegno", ImportoAssegno)
                    cmd.Parameters.AddWithValue("Annotazioni", Note)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try

    End Function

    Public Shared Function CancellaRecordAssegno(ByVal IdAssegno As String) As Boolean
        Try
            If MsgBox(String.Format("Confermate la cancellazione dell'assegno {1}{0} e delle relative associazioni agli incassi?",
                                    Environment.NewLine, IdAssegno),
                      MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question,
                      Globale.TitoloApp) = MsgBoxResult.Yes Then

                'cancello i record
                Using cn As New OleDbConnection(Globale.CnString)

                    cn.Open()

                    Using cmd As New OleDbCommand

                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "DELETE FROM Assegni WHERE IdAssegno = ?"

                        cmd.Parameters.AddWithValue("Id", IdAssegno)

                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            End If

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try

    End Function

    Public Shared Sub CancellaFileAssegno(ByRef Deposito As GestioneAssegni.DepositoAssegni,
                                          ByVal DataIncasso As Date,
                                          ByVal IdAssegno As String)
        File.Delete(PathAssegno(Deposito, DataIncasso, IdAssegno))
    End Sub

    Public Sub ControlloCodeLine()
        If mCodeLine.IndexOf("?") < 0 Then
            CalcolaIdAssegno()
            RaiseEvent CodeLineOk()
        Else
            RaiseEvent CodeLineError()
        End If
    End Sub

    Public Function PosizioneCarattereNonValido() As Integer
        Return mCodeLine.IndexOf("?")
    End Function

    Private Sub CalcolaIdAssegno()
        Try
            Dim NumeroAssegno As String = ""
            Dim Abi As String = ""
            Dim Cab As String = ""
            Dim Esito As Boolean = False

            Try
                Dim Marcatore1 As String = mCodeLine.IndexOf(">")
                Dim Marcatore2 As String = mCodeLine.IndexOf("-")
                Dim Marcatore3 As String = mCodeLine.IndexOf("#")

                NumeroAssegno = CodeLine.Substring(Marcatore1 + 1, Marcatore2 - 1)
                Abi = CodeLine.Substring(Marcatore2 + 1, 5)
                Cab = CodeLine.Substring(Marcatore2 + 6, 5)

                Esito = True
            Catch ex As Exception
            End Try

            If Esito = False Then
                'questo metodo, che una volta funzionava, sembra non essere più buono per modifica marcatori
                'prima erano > < # mentre ora sembrano essere > - # (nota del 18/01/2021)
                Try
                    Dim Marcatore1 As String = mCodeLine.IndexOf(">")
                    Dim Marcatore2 As String = mCodeLine.IndexOf("<")
                    Dim Marcatore3 As String = mCodeLine.IndexOf("#")

                    NumeroAssegno = CodeLine.Substring(Marcatore1 + 1, Marcatore2 - 1)
                    Abi = CodeLine.Substring(Marcatore2 + 1, 5)
                    Cab = CodeLine.Substring(Marcatore2 + 6, 5)

                    Esito = True
                Catch ex As Exception
                End Try
            End If

            'fallito il primo tentativo riprovo con altro metodo
            If Esito = False Then
                Try
                    NumeroAssegno = mCodeLine.Substring(1, 10)
                    Abi = mCodeLine.Substring(12, 5)
                    Cab = mCodeLine.Substring(17, 5)
                Catch ex As Exception
                    Globale.Log.Errore(ex)
                End Try
            End If

            'normalizzo abi
            Abi = Abi.Trim.PadLeft(5, "0")

            'nome file: data incasso.codice assegno.abi.cab.F.jpg
            'Dim ModelloNomeFile As String = "{0}.{1}.{2}.{3}.{4}.jpg"
            Dim ModelloId As String = "{0}-{1}-{2}"

            mIdAssegno = String.Format(ModelloId, NumeroAssegno, Abi, Cab)
            mFullPathAssegno = Path.Combine(mDeposito.CartellaAssegni(mDataIncasso), mIdAssegno + "." + mFormato)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Shared Function PathAssegno(ByRef Deposito As DepositoAssegni,
                                       ByVal DataIncasso As Date,
                                       ByVal IdAssegno As String) As String
        Dim Cartella As String = Deposito.CartellaAssegni(DataIncasso)
        Return Path.Combine(Cartella, IdAssegno + ".jpg")

    End Function
End Class
