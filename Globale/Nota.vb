'Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.IO

Public Class Nota

    Public Event CambioTipoNota()

    Public Enum TipoNota
        NOTA
        ATTIVITA
        ATTIVITA_COMPLETATA
    End Enum

    Public Enum CercaNota
        CORPO
        REDATTORE
        ATTIVITA
    End Enum

    Private mNota As DataRow
    Private mTestoSalvato As String

    Sub New()
    End Sub

    Sub New(ByRef dr As DataRow)
        mNota = dr
        mNuovaNota = False
        mModifica = False
        mIdRecord = dr("Id")
        mIdNota = dr("IdNota")
        mCF = Utx.FunzioniDb.NullToString(dr("CodiceFiscale"))
        mUtente = dr("Utente")
        mDataModifica = dr("DataModifica")
        mTesto = Utx.FunzioniDb.NullToString(dr("Memo"))
        mTestoSalvato = mTesto
        Select Case dr("Tipo")
            Case "N"
                mTipo = TipoNota.NOTA
                mAllarme = DBNull.Value
            Case "A"
                mTipo = TipoNota.ATTIVITA
                mAllarme = CDate(Utx.FunzioniDb.NullToValue(dr("Allarme")))
            Case "C"
                mTipo = TipoNota.ATTIVITA_COMPLETATA
                mAllarme = CDate(Utx.FunzioniDb.NullToValue(dr("Allarme")))
        End Select
    End Sub

    Private mNuovaNota As Boolean
    Public Property NuovaNota() As Boolean
        Get
            Return mNuovaNota
        End Get
        Set(value As Boolean)
            mNuovaNota = value
        End Set
    End Property

    Private mIdRecord As Integer
    Public Property IdRecord() As Integer
        Get
            Return mIdRecord
        End Get
        Set(value As Integer)
            mIdRecord = value
        End Set
    End Property

    Private mIdNota As String
    Public Property IdNota() As String
        Get
            Return mIdNota
        End Get
        Set(value As String)
            mIdNota = value
        End Set
    End Property

    Private mCF As String
    Public Property CodiceFiscale() As String
        Get
            Return mCF
        End Get
        Set(value As String)
            mCF = value.Trim
        End Set
    End Property

    Private mUtente As String
    Public Property Utente() As String
        Get
            Return mUtente
        End Get
        Set(value As String)
            mUtente = Left(value.Trim, 14)
        End Set
    End Property

    Private mModifica As Boolean
    Public Property Modifica() As Boolean
        Get
            Return mModifica
        End Get
        Set(value As Boolean)
            mModifica = value
        End Set
    End Property

    Private mTesto As String
    Public Property Testo() As String
        Get
            Return mTesto
        End Get
        Set(value As String)
            If (value <> mTesto) OrElse String.IsNullOrEmpty(mTesto) Then
                mTesto = value
                mModifica = True
            End If
        End Set
    End Property

    Private mTipo As TipoNota
    Public Property Tipo() As TipoNota
        Get
            Return mTipo
        End Get
        Set(value As TipoNota)
            mTipo = value
            mModifica = True
            RaiseEvent CambioTipoNota()
        End Set
    End Property

    Private mAllarme As Object
    Public Property Allarme() As Object
        Get
            Return mAllarme
        End Get
        Set(value As Object)
            If IsDate(value) Then
                If (mAllarme Is DBNull.Value) OrElse (value <> mAllarme) Then
                    mAllarme = CDate(value)
                    mModifica = True
                End If
            Else
                If mAllarme IsNot DBNull.Value Then
                    mAllarme = DBNull.Value
                    mModifica = True
                End If
            End If
        End Set
    End Property

    Private mDataModifica As Date = Now
    Public Property DataModifica() As Date
        Get
            Return mDataModifica
        End Get
        Set(value As Date)
            mDataModifica = value
        End Set
    End Property

    Public Shared Function FlagTipo(Tipo As TipoNota)
        Return IIf(Tipo = TipoNota.NOTA, "N", "A")
    End Function

    Public Function DescrizioneTipo()
        Return IIf(mTipo = TipoNota.NOTA, "Nota", "Attività")
    End Function

    Public Function EsisteAllarme() As Boolean
        Return IIf(IsDate(mAllarme), True, False)
    End Function

    Public Shared Function IdNotaSinistro(CompagniaSinistro As Integer,
                                          AgenziaSinistro As Integer,
                                          EsercizioSinistro As Integer,
                                          NumeroSinistro As Integer) As String
        Return String.Format("{0}-{1:0000}-{2:0000}-{3:0000000}",
                             CompagniaSinistro,
                             AgenziaSinistro,
                             EsercizioSinistro,
                             NumeroSinistro)
    End Function

    Public Function SalvaNota(Optional TextControl As TextBox = Nothing,
                              Optional AggiornaData As Boolean = False) As Boolean
        If mNuovaNota = True Then
            Return AggiungiNota()
        Else
            Return AggiornaNota(TextControl, AggiornaData)
        End If
    End Function

    Public Function AggiungiNota() As Boolean
        Return AggiungiNotaWeb()
    End Function

    Public Function AggiornaNota(Optional TextControl As TextBox = Nothing,
                                 Optional AggiornaData As Boolean = False) As Boolean
        Return AggiornaNotaWeb(TextControl, AggiornaData)
    End Function

    Private Function AggiungiNotaWeb() As Boolean
        Try
            'controllo elementi nota
            If ControlloNota() = False Then
                Return False
            End If

            'aggiungo la nota
            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.AggiungiNota(Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                               Me.IdNota,
                               Me.CodiceFiscale,
                               Me.Utente,
                               Me.DataModifica,
                               IIf(Me.Tipo = TipoNota.NOTA, "N", "A"),
                               IIf(Me.Tipo = TipoNota.NOTA, "", Me.Allarme),
                               Me.Testo,
                               Utx.Globale.Token)
            End Using

            mTestoSalvato = mTesto

            'ora non è più nuova e deve andare in aggiornamento altrimenti si creano duplicati
            mNuovaNota = False
            mModifica = False

            'annoto la data dell'ultima nota se si tratta di un sinistro
            AggiornaDataUltimaNota()

            Return True

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Function AggiornaNotaWeb(Optional TextControl As TextBox = Nothing,
                                     Optional AggiornaData As Boolean = False) As Boolean
        Try
            If (String.IsNullOrEmpty(mTesto) = True) AndAlso (String.IsNullOrEmpty(mTestoSalvato) = False) Then
                'se testo corrente vuoto e testo precedente non vuoto ripristino il testo precedente
                Me.Testo = mTestoSalvato
                'popolo il controllo se è disponibile
                If TextControl IsNot Nothing Then
                    TextControl.Text = mTestoSalvato
                End If
            ElseIf String.IsNullOrEmpty(mTesto) Then
                'testo vuoto non aggiorno
                Return True
            End If
            If mModifica = False Then
                Return True
            End If

            'aggiorno il datarow sottostante la griglia-elenco note
            mNota.Item("Memo") = mTesto
            mNota.Item("Allarme") = mAllarme

            Dim Tipo As String = ""
            Dim Allarme As Object = ""
            Dim DataModifica As Object = Nothing
            Select Case mTipo
                Case TipoNota.NOTA
                    Allarme = ""
                    Tipo = "N"
                Case TipoNota.ATTIVITA
                    Allarme = mAllarme
                    Tipo = "A"
                Case TipoNota.ATTIVITA_COMPLETATA
                    Allarme = mAllarme
                    Tipo = "C"
            End Select
            If AggiornaData = True Then
                DataModifica = Now
                AggiornaDataUltimaNota()
            Else
                DataModifica = mNota.Item("DataModifica")
            End If

            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.AggiornaNota(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, mIdRecord, DataModifica, Tipo, Allarme, mTesto, Utx.Globale.Token)
            End Using
            Return True

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Sub AggiornaDataUltimaNota()
        Try
            'annoto la data dell'ultima nota se si tratta di un sinistro
            If mIdNota Like "#-####-####-#######" Then
                'aggiorno su DP e se esiste aggiorno anche su AC
                Dim Query As String = String.Format("UPDATE SinistriDP 
                    SET DataMemo = '{0:dd/MM/yyyy HH:mm}' 
                    WHERE Compagnia = {1} AND AgenziaSinistro = {2} AND EsercizioSinistro = {3} AND NumeroSinistro = {4}

                    UPDATE SinistriAC
                    SET DataMemo = '{0:dd/MM/yyyy HH:mm}' 
                    WHERE Compagnia = {1} AND AgenziaSinistro = {2} AND EsercizioSinistro = {3} AND NumeroSinistro = {4}",
                    Me.DataModifica, mIdNota.Split("-")(0), mIdNota.Split("-")(1), mIdNota.Split("-")(2), mIdNota.Split("-")(3))

                Utx.WsCommand.ExecuteNonQueryRecord(Query)
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub CancellaNota()
        CancellaNotaWeb()
    End Sub

    Public Sub CancellaNotaWeb()
        Try
            If MsgBox("Confermate la cancellazione della nota selezionata?",
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2,
                      Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then

                Using s As New Utx.ServiziOMW.ServizioDatiOMW
                    s.Proxy = Utx.Globale.UniProxy.Proxy
                    s.CancellaNota(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, mIdRecord, Utx.Globale.Token)
                End Using
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Function LeggiNote(IdNota As String, Tipo As TipoNota) As DataTable
        Try
            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Return s.LeggiNote(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, IdNota, Tipo, Utx.Globale.Token).Tables(0)
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return New DataTable
        End Try
    End Function

    Private Function ControlloNota() As Boolean
        Try
            If (IsNothing(mIdNota) OrElse mIdNota.Trim.Length = 0) Then
                MsgBox("Attenzione: identificativo della nota non valido", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Return False
            End If
            If (IsNothing(mCF) OrElse mCF.Trim.Length = 0) Then
                MsgBox("Attenzione: codice fiscale del cliente non valido o assente", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Return False
            End If
            If (IsNothing(mUtente) OrElse mUtente.Trim.Length = 0) Then
                MsgBox("Attenzione: redattore della nota non valido", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Return False
            End If
            Return True

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function
End Class
