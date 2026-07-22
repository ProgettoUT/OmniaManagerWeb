Imports System.Net

<Serializable>
Public Class Utente

    Public Shared Event RichiestaAggiornamentoEssigReti()
    Public Profilo As Utx.ServiziOMW.ProfiloUtente

    Sub New()
    End Sub

    Public ReadOnly Property Dominio() As String
        Get
            Return "uniage"
        End Get
    End Property

    Private mUniageUser As String
    Public Property UniageUser() As String
        Get
            Return mUniageUser
        End Get
        Set(value As String)
            'leggo nome, ruolo e cf
            If String.IsNullOrEmpty(value) Then
                Exit Property
            Else
                Try
                    mUniageUser = value
                    mAgenziaUtente = mUniageUser.Substring(1, 5)

                    Using s As New Utx.ServiziOMW.ServizioDatiOMW
                        s.Proxy = Utx.Globale.UniProxy.Proxy
                        Profilo = s.LeggiProfilo(mAgenziaUtente, Utx.Globale.Token + "|" + mUniageUser) 'il token deve contenere l'utenza
                        If String.IsNullOrEmpty(Profilo.Messaggio) = False Then
                            MsgBox(Profilo.Messaggio, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                        End If
                    End Using

                Catch ex As Exception
                    Utx.Globale.Log.Info(ex)
                    RaiseEvent RichiestaAggiornamentoEssigReti()
                    Profilo.NomeUtente = "xxx"
                    Profilo.Ruolo = "xxx"
                    Profilo.CodiceFiscale = "xxx"
                    Profilo.RUI = "xxx"
                    Profilo.CFValido = False
                    mErroreUtente = "Errore nel recupero dei dati utente: aggiornamento..."
                End Try
            End If
            LogDatiUtente()
        End Set
    End Property

    Public Property UniageUserAssegni() As String
        Get
            Return mUniageUser
        End Get
        Set(value As String)
            'leggo nome, ruolo e cf
            If String.IsNullOrEmpty(value) Then
                Exit Property
            Else
                Try
                    mUniageUser = value
                    mAgenziaUtente = mUniageUser.Substring(1, 5)
                Catch ex As Exception
                    Utx.Globale.Log.Info(ex)
                    RaiseEvent RichiestaAggiornamentoEssigReti()
                    Profilo.NomeUtente = "xxx"
                    Profilo.Ruolo = "xxx"
                    Profilo.CodiceFiscale = "xxx"
                    Profilo.RUI = "xxx"
                    Profilo.CFValido = False
                    mErroreUtente = "Errore nel recupero dei dati utente: aggiornamento..."
                End Try
            End If
        End Set
    End Property

    Public ReadOnly Property UnisaluteUser() As String
        Get
            Return Profilo.UtenzaUnisalute
        End Get
    End Property

    Public ReadOnly Property UserAndPc As String
        Get
            'il machine name viene comunque troncato a 15 caratteri da windows
            Return $"{mUniageUser.ToUpper}:{Environment.MachineName}"
        End Get
    End Property

    Public Shared Function ControlloUniSalute(dt As DataTable) As Boolean
        Try
            For Each Figlia As DataRow In dt.Rows
                If Figlia("Unisalute") = "S" Then
                    If String.IsNullOrEmpty(Utx.Globale.UtenteCorrente.UnisaluteUser) Then
                        Utx.Globale.UtenteCorrente.RichiestaUnisaluteUser()
                    End If

                    If String.IsNullOrEmpty(Utx.Globale.UtenteCorrente.UnisaluteUser) Then
                        dt.Rows.Remove(Figlia)
                        Return False
                    Else
                        If Utx.Globale.LoginUS.IsLogged = False Then
                            If Utx.Globale.LoginUS.LogIn(Utx.Globale.UtenteCorrente.UnisaluteUser, Utx.Globale.UtenteCorrente.UniagePw, "uniage") <> Autenticazione.StatoLogin.LOGIN Then
                                dt.Rows.Remove(Figlia)
                                MsgBox("Login Unisalute fallito. E' necessario impostare la password UniSalute uguale a quella UnipolSai.",
                                       MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                                Return False
                            End If
                        End If
                    End If
                    Exit For
                End If
            Next
            Return True
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Sub RichiestaUnisaluteUser()
        Try
            Dim UtenteUS As String = InputBox(String.Format("Inserite l'utenza Unisalute di {0}", Utx.Globale.UtenteCorrente.UniageUser.ToUpper), "Utenza Unisalute", "")

            If IsUnisaluteUser(UtenteUS) Then
                Profilo.UtenzaUnisalute = UtenteUS
                'registra lo use nel DB
                Dim Query As String = $"INSERT INTO Utenze (Selezionato,Compagnia,Agenzia,CfComponente,NomeComponente,Utenza,StatoUtenza,Ruolo)
                    VALUES(CAST(1 AS bit),4,{mAgenziaUtente},'{Profilo.CodiceFiscale}','{Profilo.NomeUtente.Replace("'", "")}','{Profilo.UtenzaUnisalute.ToUpper}','ATTIVATA','{Profilo.Ruolo}')"

                Utx.WsCommand.ExecuteNonQuery(Query, mAgenziaUtente) 'inserisco nel DB
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Function IsUniageUser(Utente As String) As Boolean
        Return Utente.ToLower Like "1[0-9][0-9][0-9][0-9][0-9][a-z0-9][a-z0-9]"
    End Function

    Public Shared Function IsUnisaluteUser(Utente As String) As Boolean
        Return Utente.ToLower Like "4[0-9][0-9][0-9][0-9][0-9][a-z0-9][a-z0-9]"
    End Function

    Private mUniagePw As String
    Public Property UniagePw() As String
        Get
            Return mUniagePw
        End Get
        Set(value As String)
            mUniagePw = value
        End Set
    End Property

    Private mAgenziaUtente As String
    Public ReadOnly Property AgenziaUtente() As String
        Get
            Return mAgenziaUtente
        End Get
    End Property

    'Private mNomeUtente As String
    Public ReadOnly Property NomeUtente() As String
        Get
            Return Profilo.NomeUtente 'mNomeUtente
        End Get
        'Set(value As String)
        '    mNomeUtente = value
        'End Set
    End Property

    'Private mRuolo As String
    Public ReadOnly Property Ruolo() As String
        Get
#If DEBUG Then
            Return "AGE"
#Else
            Return Profilo.Ruolo
#End If
        End Get
    End Property

    'Private mDeskRuolo As String
    Public ReadOnly Property DeskRuolo() As String
        Get
            Return Profilo.DeskRuolo 'mDeskRuolo
        End Get
    End Property

    'Private mRUI As String
    Public ReadOnly Property RUI() As String
        Get
            Return Profilo.RUI 'mRUI
        End Get
    End Property

    'Private mDataRUI As Date
    Public ReadOnly Property DataRUI() As Date
        Get
            Return Profilo.DataRUI 'mDataRUI
        End Get
    End Property

    'Public Shared Function RuoloUtenza(Utenza As String) As String
    '    Try
    '        Return Utx.FunzioniDb.ExecuteScalar(String.Format("SELECT TOP 1 TRIM(Ruolo) FROM Utenze WHERE Utenza = '{0}'", Utenza))
    '    Catch ex As Exception
    '        Return "ND"
    '    End Try
    'End Function

    'Private mCodiceFiscale As String
    Public ReadOnly Property CodiceFiscale() As String
        Get
            Return Profilo.CodiceFiscale 'mCodiceFiscale
        End Get
    End Property

    Public ReadOnly Property IsAgente() As Boolean
        Get
            Return Profilo.Ruolo.ToUpper.StartsWith("AGE")
        End Get
    End Property

    'Private mCFValido As Boolean
    Public ReadOnly Property CFValido() As Boolean
        Get
            Return Profilo.CFValido 'mCFValido
        End Get
    End Property

    Private Shared mErroreUtente As String
    Public Shared ReadOnly Property ErroreUtente() As String
        Get
            Return mErroreUtente
        End Get
    End Property

    Private mAutenticato As Boolean
    Public Property Autenticato() As Boolean
        Get
            Return mAutenticato
        End Get
        Set(value As Boolean)
            mAutenticato = value
        End Set
    End Property

    Public ReadOnly Property Desktop() As String
        Get
            Return My.Computer.FileSystem.SpecialDirectories.Desktop
        End Get
    End Property

    Public Function CredenzialiInserite() As Boolean
        Return (String.IsNullOrEmpty(mUniageUser) = False) And (String.IsNullOrEmpty(mUniagePw) = False)
    End Function

    Public Shared Sub LeggiCredenziali(ByRef UniageUser As String, ByRef UniagePw As String)
        Try
            UniageUser = ""
            UniagePw = ""

            Dim wrapper As New Utx.Crypto("19011957")

            '+cerco la chiave dell'utente loggato sul pc
            Dim Chiave As String = Utx.Globale.SettingGlobale.LeggiValore(wrapper.EncryptData(Environment.UserName))

            If String.IsNullOrEmpty(Chiave) = False Then
                'se la chiave esiste la decripto
                Dim UtenteRegistrato As String = wrapper.DecryptData(Chiave)
                'l'utente registrato è nella forma utenteuniage:passworduniage:scadenza:nascoste

                UniageUser = UtenteRegistrato.Split(":")(0)
                UniagePw = UtenteRegistrato.Split(":")(1)

                'ATTENZIONE: la pw deve stare prima dello user poiche l'assegnazione dello user scatena dei controlli
                'che hanno bisogno della pw sopratutto in VPN
                Utx.Globale.UtenteCorrente.UniagePw = UniagePw
                Utx.Globale.UtenteCorrente.UniageUser = UniageUser

                'Utx.Globale.ProfiloEnteGestore = New Utx.EnteGestore

                ''se l'agenzia non corrisponde
                'If UtenteGestito(UniageUser) = False Then
                '    UniageUser = ""
                '    UniagePw = ""
                '    CancellaUtente(Environment.UserName)
                '    Utx.Globale.UtenteCorrente.Autenticato = False
                'End If
            Else
                UniageUser = ""
                UniagePw = ""
                Utx.Globale.UtenteCorrente.Autenticato = False
            End If

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            'annullo l'utente
            UniageUser = ""
            UniagePw = ""
            'rimuovo la chiave difettosa
            CancellaUtente(Environment.UserName)
            Utx.Globale.UtenteCorrente.Autenticato = False
        End Try
    End Sub

    Public Function MittentiMail() As String
        Return Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.EMAIL_PREDEFINITE, "")
    End Function

    Public Function MittentePredefinito() As String
        Return Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.EMAIL_PREDEFINITE, "").Split(";")(0)
    End Function

    Public Shared Function NomeUtenza(Utenza As String) As String
        Try
            Dim Nome As Object = WsCommand.ExecuteScalar($"SELECT TOP 1 TRIM(NomeComponente) 
                FROM Utenze 
                WHERE Utenza = '{Utenza}'").Valore
            If Nome IsNot Nothing Then
                Return Nome
            Else
                Return Utenza
            End If
        Catch ex As Exception
            Return Utenza
        End Try
    End Function

    Public Shared Function CodiceFiscaleUtenza(Utenza As String) As String
        Try
            Return WsCommand.ExecuteScalar(String.Format("SELECT TOP 1 CfComponente FROM Utenze WHERE Utenza = '{0}'", Utenza)).Valore
        Catch ex As Exception
            Return "ND"
        End Try
    End Function

    Public Shared Function LeggiUtenze() As DataTable
        Try
            Return Utx.WsCommand.ExecuteNonQuery("SELECT DISTINCT Utenza,TRIM(NomeComponente) AS Nome 
                FROM Utenze WHERE StatoUtenza = 'ATTIVATA'").DataTable
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Shared Function ListaUtenzePassword(FileSetting As String) As List(Of Credenziali)
        Dim wrapper As New Utx.Crypto("19011957")
        Dim Lista As New List(Of Credenziali)

        For Each kvp As KeyValuePair(Of String, String) In Utx.ApplicationUserSetting.LeggiFileSetting(FileSetting)
            Try
                Dim Chiave As String = wrapper.DecryptData(kvp.Key)
                If (Chiave.ToLower Like "######[a-z0-9][a-z0-9]") OrElse (Chiave.ToLower = Environment.UserName) OrElse (Environment.MachineName = "X390-GUIDO") Then
                    Dim Valore As String = wrapper.DecryptData(kvp.Value)
                    If Valore.Split(":")(0).ToLower Like "######[a-z0-9][a-z0-9]" Then
                        Lista.Add(New Credenziali(Valore.Split(":")(0), Valore.Split(":")(1), Valore.Split(":")(2), Chiave))
                    End If
                End If
            Catch ex As Exception
                'le chiavi non criptate vanno in errore
            End Try
        Next
        Lista.Sort(Function(x, y) CDate(x.Scadenza).CompareTo(CDate(y.Scadenza)))
        Return Lista
    End Function

    Public Shared Sub CancellaUtentiScaduti()
        Try
            Dim wrapper As New Utx.Crypto("19011957")
            Dim Lista As List(Of Credenziali) = ListaUtenzePassword(Utx.Globale.SettingGlobale.FileSetting)

            For Each c As Credenziali In Lista
                If (c.Scadenza < Today) AndAlso (c.UtentePc IsNot Nothing) Then
                    Utx.Globale.SettingGlobale.Rimuovi(wrapper.EncryptData(c.UtentePc))
                End If
            Next
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub

    Public Shared Sub CancellaUtente(Utente As String)
        Try
            Dim wrapper As New Utx.Crypto("19011957")
            Dim Lista As List(Of Credenziali) = ListaUtenzePassword(Utx.Globale.SettingGlobale.FileSetting)

            For Each c As Credenziali In Lista
                If c.UtentePc = Utente Then
                    Utx.Globale.SettingGlobale.Rimuovi(wrapper.EncryptData(c.UtentePc))
                    Exit For
                End If
            Next
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub

    Public Function Credenziali() As NetworkCredential
        Return New NetworkCredential(mUniageUser, mUniagePw, Dominio)
    End Function

    Public Sub LogDatiUtente()
        Try
            If Profilo IsNot Nothing Then
                Utx.Globale.Log.Info(Profilo.NomeUtente)
                Utx.Globale.Log.Info(Profilo.CodiceFiscale)
                Utx.Globale.Log.Info(Profilo.CFValido)
                Utx.Globale.Log.Info(Profilo.Ruolo)
                Utx.Globale.Log.Info(Profilo.DeskRuolo)
                Utx.Globale.Log.Info(Profilo.RUI)
                Utx.Globale.Log.Info(Profilo.DataRUI)
                Utx.Globale.Log.Info(Profilo.ProfiloUnipol)
                Utx.Globale.Log.Info(Profilo.Messaggio)
            End If
            ' Ottenere le informazioni sul tipo della classe Persona
            Dim tipo As Type = Profilo.GetType()

            ' Ottenere tutte le proprietà della classe
            Dim proprietà As Reflection.PropertyInfo() = tipo.GetProperties()

            ' Ciclare su ogni proprietà e visualizzarne il nome e il valore
            Console.WriteLine("Proprietà dell'oggetto Persona:")
            For Each prop As Reflection.PropertyInfo In proprietà
                Dim nomeProprietà As String = prop.Name
                Dim valoreProprietà As Object = prop.GetValue(Profilo, Nothing)
                Try
                    Utx.Globale.Log.Info("{0}: {1}", {nomeProprietà, valoreProprietà})
                Catch ex As Exception
                    Utx.Globale.Log.Info("{0}: {1}", {nomeProprietà, ex.Message})
                End Try
            Next
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub
End Class

Public Class Credenziali

    Sub New(User As String, Password As String, Scadenza As Date, Optional UtentePc As String = Nothing)
        mUser = User
        mPassword = Password
        mScadenza = Scadenza
        mUtentePc = UtentePc
    End Sub

    Sub New(User As String, Password As String, Optional UtentePc As String = Nothing)
        mUser = User
        mPassword = Password
        mScadenza = #1/1/2000#
        mUtentePc = UtentePc
    End Sub

    Private mUser As String
    Public Property User() As String
        Get
            Return mUser
        End Get
        Set(value As String)
            mUser = value
        End Set
    End Property

    Private mPassword As String
    Public Property Password() As String
        Get
            Return mPassword
        End Get
        Set(value As String)
            mPassword = value
        End Set
    End Property

    Private mScadenza As Date
    Public Property Scadenza() As String
        Get
            Return mScadenza
        End Get
        Set(value As String)
            mScadenza = value
        End Set
    End Property

    Private mUtentePc As String
    Public Property UtentePc() As String
        Get
            Return mUtentePc
        End Get
        Set(value As String)
            mUtentePc = value
        End Set
    End Property
End Class

Public Class LoginEventArgs
    Inherits EventArgs
    Public Property Stato As String
End Class
