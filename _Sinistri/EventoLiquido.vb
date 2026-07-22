Imports mshtml

Public Class EventoLiquido

    'identificatori nella pagina html
    Public Const IdPolizza As String = "Claim-ClaimInfoBar-combinedid"
    Public Const IdNumeroEvento As String = "Claim-ClaimInfoBar-NumeroEvento"
    Public Const IdDataSinistro As String = "Claim-ClaimInfoBar-LossDate"
    Public Const IdDataApertura As String = "Event:EventViewScreen:EventHistoryLV:0:date"
    Public Const IdLiquidatore As String = "Event-EventViewScreen-0-Liquidatore"
    Public Const IdDescrizione As String = "Event-EventViewScreen-EventDescriptionFieldsInputSet-EventoDescription"
    Public Const IdContraente As String = "Claim-ClaimInfoBar-Contraente"
    Public Const IdCronologia As String = "Event:EventViewScreen:EventHistoryLV"
    Public Const IdGaranzia As String = "Event-EventViewScreen-0-SinistroBarSummaryInputSet-ClaimCoverage"
    Public Const IdUfficio As String = "Claim-ClaimInfoBar-CLG"
    Public Const IdStatus As String = "Event-EventViewScreen-0-SinistroBarSummaryInputSet-ClaimStatus"
    Public IdStringaSinistro As String = "Event-EventViewScreen-0-SinistroPrincipale_button"

    Sub New()
        mCompagnia = 1
        mAgenziaSinistro = ""
        mEsercizioSinistro = ""
        mNumeroSinistro = ""

        CreaIdSinistro()
    End Sub

    'proprietà
    Private mTipo As QuerySinistri.TipoTabella
    Public Property Tipo() As QuerySinistri.TipoTabella
        Get
            Return mTipo
        End Get
        Set(value As QuerySinistri.TipoTabella)
            mTipo = value
        End Set
    End Property

    Public ReadOnly Property DescrizioneTipo() As String
        Get
            If mTipo = QuerySinistri.TipoTabella.SINISTRI_DELEGA_PROPRIA Then
                Return "Sinistri delega propria e 100%"
            Else
                Return "Sinistri cautelativi e altra compagnia"
            End If
        End Get
    End Property

    Public Property IdSinistro() As String
        Get
            Return CreaIdSinistro()
        End Get
        Set(Id As String)
            mCompagnia = Id.Split("-")(0)
            mAgenziaSinistro = Id.Split("-")(1)
            mEsercizioSinistro = Id.Split("-")(2)
            mNumeroSinistro = Id.Split("-")(3)
        End Set
    End Property

    Private mLetturaEventoEffettuata As Boolean
    Public Property LetturaEventoEffettuata() As String
        Get
            Return mLetturaEventoEffettuata
        End Get
        Set(value As String)
            mLetturaEventoEffettuata = value
        End Set
    End Property

    Dim mCompagnia As Integer
    Public Property Compagnia() As String
        Get
            Return mCompagnia
        End Get
        Set(value As String)
            mCompagnia = value
        End Set
    End Property

    Private mAgenziaSinistro As String
    Public Property AgenziaSinistro() As String
        Get
            Return mAgenziaSinistro
        End Get
        Set(value As String)
            mAgenziaSinistro = value
        End Set
    End Property

    Private mEsercizioSinistro As String
    Public Property EsercizioSinistro() As String
        Get
            Return mEsercizioSinistro
        End Get
        Set(value As String)
            mEsercizioSinistro = value
        End Set
    End Property

    Private mNumeroSinistro As String
    Public Property NumeroSinistro() As String
        Get
            Return mNumeroSinistro
        End Get
        Set(value As String)
            mNumeroSinistro = value
        End Set
    End Property

    Private mNumeroPolizza As String
    Public Property NumeroPolizza() As String
        Get
            Return mNumeroPolizza
        End Get
        Set(value As String)
            mNumeroPolizza = value
            mRamo = Split(value, "/")(1)
            mPolizza = Split(value, "/")(2)

            LeggiPolizza()
        End Set
    End Property

    Private mRamoSinistro As String
    Public Property RamoSinistro() As String
        Get
            Return mRamoSinistro
        End Get
        Set(value As String)
            mRamoSinistro = value
        End Set
    End Property

    Private mRamo As String
    Public Property Ramo() As String
        Get
            Return mRamo
        End Get
        Set(value As String)
            mRamo = value
        End Set
    End Property

    Private mPolizza As String
    Public Property Polizza() As String
        Get
            Return mPolizza
        End Get
        Set(value As String)
            mPolizza = value
        End Set
    End Property

    Private mTarga As String
    Public Property Targa() As String
        Get
            Return mTarga
        End Get
        Set(value As String)
            mTarga = value
        End Set
    End Property

    Private mEvento As String
    Public Property Evento() As String
        Get
            Return mEvento
        End Get
        Set(value As String)
            mEvento = Utx.NetFunc.EstraiCaratteri(value, "0123456789/-")
        End Set
    End Property

    Private mDescrizione As String
    Public Property Descrizione() As String
        Get
            Return mDescrizione
        End Get
        Set(value As String)
            mDescrizione = value
        End Set
    End Property

    Private mDataSinistro As Date
    Public Property DataSinistro() As Date
        Get
            Return mDataSinistro
        End Get
        Set(value As Date)
            mDataSinistro = value
        End Set
    End Property

    Private mDataDenuncia As Date
    Public Property DataDenuncia() As Date
        Get
            Return mDataDenuncia
        End Get
        Set(value As Date)
            mDataDenuncia = value
        End Set
    End Property

    Private mDataApertura As Date
    Public Property DataApertura() As Date
        Get
            Return mDataApertura
        End Get
        Set(value As Date)
            mDataApertura = value
        End Set
    End Property

    Private mCF As String
    Public Property CF() As String
        Get
            Return mCF
        End Get
        Set(value As String)
            mCF = value
        End Set
    End Property

    Private mSubAgenzia As String
    Public Property SubAgenzia() As String
        Get
            Return mSubAgenzia
        End Get
        Set(value As String)
            mSubAgenzia = value
        End Set
    End Property

    Private mContraente As String
    Public Property Contraente() As String
        Get
            Return mContraente
        End Get
        Set(value As String)
            mContraente = value
        End Set
    End Property

    Private mGestore As String
    Public Property Gestore() As String
        Get
            Return mGestore
        End Get
        Set(value As String)
            mGestore = value
        End Set
    End Property

    Private mLiquidatore As String
    Public Property Liquidatore() As String
        Get
            Return mLiquidatore
        End Get
        Set(value As String)
            mLiquidatore = LeggiLiquidatore(value)
        End Set
    End Property

    Private mCodiceLiquidatore As Integer
    Public Property CodiceLiquidatore() As Integer
        Get
            Return mCodiceLiquidatore
        End Get
        Set(value As Integer)
            mCodiceLiquidatore = value
        End Set
    End Property

    Private mUfficio As String
    Public Property Ufficio() As String
        Get
            Return mUfficio
        End Get
        Set(value As String)
            mUfficio = Utx.NetFunc.EstraiCaratteri(value, "0123456789")
        End Set
    End Property

    Private Shared mWebView As EO.WebBrowser.WebView
    Public Shared Property WebView() As EO.WebBrowser.WebView
        Get
            Return mWebView
        End Get
        Set(value As EO.WebBrowser.WebView)
            mWebView = value
        End Set
    End Property

    Public Function NotaApertura() As String
        Return String.Format("SINISTRO: {1}{0}CARTELLA: {2}{0}LIQUIDATORE: {3}{0}UFFICIO: {4}{0}DESCRIZIONE: {5}",
                             Environment.NewLine,
                             CreaIdSinistro,
                             mEvento,
                             mLiquidatore,
                             mUfficio,
                             mDescrizione)
    End Function

    'metodi
    Private Function CreaIdSinistro() As String
        Return String.Format("{0}-{1}-{2}-{3}", mCompagnia, mAgenziaSinistro.PadLeft(4, "0"), mEsercizioSinistro, mNumeroSinistro.PadLeft(7, "0"))
    End Function

    Public Sub LeggiPaginaEvento()
        On Error Resume Next
        If String.IsNullOrEmpty(EvalScript("Event-EventViewScreen-ttlBar")) = False Then
            Me.Compagnia = 1
            Me.IdSinistro = EvalScript(IdStringaSinistro)
            Me.Contraente = EvalScript(IdContraente).Replace("Contr:", "")
            'il numero polizza deve stare dopo il contraente perché, se possibile, il contraente viene
            'corretto nel set della proprietà polizza invertendo nome e cognome
            Me.NumeroPolizza = EvalScript(IdPolizza)
            Me.Evento = EvalScript(IdNumeroEvento)
            Me.DataSinistro = Utx.NetFunc.EstraiCaratteri(EvalScript(IdDataSinistro), "0123456789/-")
            Me.Descrizione = EvalScript(IdDescrizione)
            Me.Liquidatore = EvalScript(IdLiquidatore)
            Me.Ufficio = EvalScript(IdUfficio)

            If EvalScript(IdGaranzia) = "RCA" Then
                Me.RamoSinistro = "30"
            End If

            Dim Stato As String = EvalScript(IdStatus)
            If Stato.StartsWith("Aperto da") Then
                Dim Giorni As String = Utx.NetFunc.EstraiCaratteri(EvalScript(IdStatus), "0123456789")
                If IsNumeric(Giorni) Then
                    Me.DataApertura = Today.AddDays(-Giorni)
                Else
                    Me.DataApertura = Today
                End If
            End If

            mLetturaEventoEffettuata = True
        End If
    End Sub

    Public Shared Function EvalScript(Id As String) As String
        Try
            If mWebView.CanEvalScript Then
                Return mWebView.EvalScript(String.Format("document.getElementById('{0}').innerText;", Id))
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub LeggiPolizza()
        Try
            'ricerca per ramo/polizza
            Dim Sql As String = String.Format("SELECT TOP 1 P.*, C.Cognome, C.Nome 
                FROM Polizze AS P 
                INNER JOIN Clienti AS C ON C.CodiceFiscale = P.CodiceFiscale 
                WHERE P.Ramo = {0} AND P.Polizza = {1}", mRamo, mPolizza)

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(Sql)

            If Risposta IsNot Nothing AndAlso Risposta.DataTable.Rows.Count > 0 Then
                Dim dr As DataRow = Risposta.DataTable.Rows(0)
                mCF = Utx.FunzioniDb.NullToString(dr("CodiceFiscale"))
                mContraente = Utx.FunzioniDb.NullToString(String.Format("{0} {1}",
                                                                                dr("Cognome").ToString.Trim,
                                                                                Utx.FunzioniDb.NullToString(dr("Nome").ToString.Trim)))
                mSubAgenzia = Utx.FunzioniDb.NullToString(dr("CodiceSubAgente"), True)
                'escludo le cumulative per la targa che è sempre la stessa
                If "130/131/230/231".Contains(mRamo.Trim.PadLeft(3, "0")) = False Then
                    mTarga = Utx.FunzioniDb.NullToString(dr("Targa"))
                End If
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function LeggiLiquidatore(Nome As String) As String
        Try
            If String.IsNullOrEmpty(Nome) Then
                LeggiLiquidatore = ""
                mCodiceLiquidatore = 0
            Else
                'tolgo dal nome caratteri che danno fastidio alla query
                Nome = Replace(Nome, "'", "", , , vbTextCompare)
                Nome = Replace(Nome, """", "", , , vbTextCompare)
                Nome = Replace(Nome, vbLf, "", , , vbTextCompare)
                Nome = Replace(Nome, vbCrLf, "", , , vbTextCompare)

                Dim Liq() As String = Nome.Split(Space(1))
                Dim Sql As String
                If Liq.GetUpperBound(0) < 1 Then
                    Sql = String.Format("SELECT TOP 1 * FROM Liquidatori WHERE Nome LIKE '%{0}%'", Liq(0))
                Else
                    Sql = String.Format("SELECT TOP 1 * FROM Liquidatori WHERE (Nome LIKE '%{0}%') AND (Nome LIKE '%{1}%')", Liq(0), Liq(1))
                End If

                Dim dr As DataRow = Utx.WsCommand.GetDataRow(Sql)
                If dr IsNot Nothing Then
                    LeggiLiquidatore = String.Format("{0} - Tel: {1} - E-mail: {2}", Nome, dr("Telefono"), dr("Email"))
                    mCodiceLiquidatore = dr("Codice")
                Else
                    LeggiLiquidatore = ""
                    mCodiceLiquidatore = 0
                End If
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
            LeggiLiquidatore = ""
            mCodiceLiquidatore = 0
        End Try
    End Function
End Class
