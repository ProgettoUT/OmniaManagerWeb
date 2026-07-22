Imports System.Windows.Forms
Imports Microsoft.Web.Services3.Security

Public Class Sinistro

    Public Event SinistroChanged()
    Public Decodifica As Decodifiche

    Sub New(Tabella As String)
        NomeTabella = Tabella
    End Sub

    Sub New(VistaAssociata As Vista.ElencoViste, Tabella As String)
        NomeTabella = Tabella
        mVistaAssociata = VistaAssociata
    End Sub

    Private _Dati As DataRow
    Public Property Dati() As DataRow
        Get
            Return _Dati
        End Get
        Set(value As DataRow)
            _Dati = value

            Decodifica = New Decodifiche(NomeTabella) With {.LetturaDecodifiche = False, .Sinistro = Me}

            Select Case mVistaAssociata
                Case Vista.ElencoViste.NESSUNA
                    MsgBox("Nessuna vista associata al sinistro", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Case Vista.ElencoViste.NORMALE
                    RaiseEvent SinistroChanged()
                Case Vista.ElencoViste.SOPRAVVENIENZE, Vista.ElencoViste.PERIZIE, Vista.ElencoViste.VARIAZIONE_COSTI_MESE_ANNO, Vista.ElencoViste.APERTI_CONTROPARTE
                    'i dati sono incompleti
                    LeggiDatiSinistro()
                    RaiseEvent SinistroChanged()
                Case Vista.ElencoViste.INDICATORE_CLIENTE
                    'non è una griglia per sinistro e quindi non fare niente
            End Select
        End Set
    End Property

    Private _NomeTabella As String
    Public Property NomeTabella() As String
        Get
            Return _NomeTabella
        End Get
        Set(ByVal value As String)
            _NomeTabella = value
        End Set
    End Property
    Private mVistaAssociata As Vista.ElencoViste
    Public Property VistaAssociata() As Vista.ElencoViste
        Get
            Return mVistaAssociata
        End Get
        Set(value As Vista.ElencoViste)
            mVistaAssociata = value
        End Set
    End Property

    Public ReadOnly Property Esiste() As Boolean
        Get
            Return (_Dati IsNot Nothing)
        End Get
    End Property

    Public ReadOnly Property Compagnia() As Integer
        Get
            Return _Dati("Compagnia")
        End Get
    End Property

    Public ReadOnly Property Agenzia() As Integer
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("AgenziaSinistro"))
        End Get
    End Property

    Public ReadOnly Property Esercizio() As Integer
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("EsercizioSinistro"))
        End Get
    End Property

    Public ReadOnly Property Numero() As Integer
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("NumeroSinistro"))
        End Get
    End Property

    Public ReadOnly Property RamoSinistro() As Integer
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("RamoSinistro"))
        End Get
    End Property

    Public ReadOnly Property AgenziaPolizza() As Integer
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("AgenziaPolizza"))
        End Get
    End Property

    Public ReadOnly Property SubAgenzia() As Integer
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("CodiceSubAgenteSima"))
        End Get
    End Property

    Public ReadOnly Property RamoPolizza() As Integer
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("RamoPolizza"))
        End Get
    End Property

    Public ReadOnly Property Polizza() As Integer
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("Polizza"))
        End Get
    End Property

    Public ReadOnly Property DataSinistro() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("DataSinistro"))
        End Get
    End Property

    Public ReadOnly Property DataApertura() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("DataApertura"))
        End Get
    End Property

    Public ReadOnly Property TargaAssicurato() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("TargaAssicurato"))
        End Get
    End Property

    Public ReadOnly Property Controparte() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("CognomeDanneggiato"))
        End Get
    End Property

    Public ReadOnly Property TargaControparte() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("TargaDanneggiato"))
        End Get
    End Property

    Public ReadOnly Property CodiceProdotto() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("CodiceProdotto"))
        End Get
    End Property

    Public ReadOnly Property Convenzione() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("Convenzione"))
        End Get
    End Property

    Public ReadOnly Property NostraQuota() As Double
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("NostraQuota"))
        End Get
    End Property

    Public ReadOnly Property RamoGestione() As Integer
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("RamoGestione"))
        End Get
    End Property

    Public ReadOnly Property Comparto() As Integer
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("Comparto"))
        End Get
    End Property

    Public ReadOnly Property FranchigiaPTF() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("FranchigiaPTF"))
        End Get
    End Property

    Public ReadOnly Property CompagniaControparte() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("CompControparte"))
        End Get
    End Property

    Public ReadOnly Property TipoApplicativo() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("TipoApplicativo"))
        End Get
    End Property

    Public ReadOnly Property TipoCid() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("TipoCid"))
        End Get
    End Property

    Public ReadOnly Property TipoSinistro() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("TipoSx"))
        End Get
    End Property

    Public ReadOnly Property DanniPersoneCose() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("FlagCosePersone"))
        End Get
    End Property

    Public ReadOnly Property Posizioni() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("NrPosizioni"))
        End Get
    End Property

    Public ReadOnly Property Presentatore() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("Presentatore"))
        End Get
    End Property

    Public ReadOnly Property Denunciante() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("Denunciante"))
        End Get
    End Property

    Public ReadOnly Property CodiceLiquidatore() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("CodiceLiquidatore"))
        End Get
    End Property

    Public ReadOnly Property CodicePerito() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("CodicePerito"))
        End Get
    End Property

    Public ReadOnly Property TipoApertura() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("TipoApertura"))
        End Get
    End Property

    Public ReadOnly Property Ispettorato() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("Ispettorato"))
        End Get
    End Property
    Public ReadOnly Property Carrozzeria() As String
        Get
            If Utx.FunzioniDb.NullToValue(_Dati("CarrozzCAnia")) = 0 Then
                Return ""
            Else
                Return String.Format("{0}-{1}",
                                     Utx.FunzioniDb.NullToValue(_Dati("CarrozzProv")),
                                     Utx.FunzioniDb.NullToValue(_Dati("CarrozzCAnia")))

            End If
        End Get
    End Property
    Public ReadOnly Property TipoCarrozzeria() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("CarrozzPrior"))
        End Get
    End Property

    Public ReadOnly Property Pagato() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("PagatoAl"))
        End Get
    End Property

    Public ReadOnly Property Valore() As String
        Get
            Select Case Me.TipoChiusura
                Case "LT", "SS"
                    Return String.Format("Valore {0:C}", Utx.FunzioniDb.NullToNumber(_Dati("PagatoAl")))
                Case Else
                    Return String.Format("Valore {0:C}",
                                         Utx.FunzioniDb.NullToNumber(_Dati("PagatoAl")) +
                                         Utx.FunzioniDb.NullToNumber(_Dati("Riserva")))
            End Select
        End Get
    End Property
    Public ReadOnly Property PrimoPreventivo() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("PrimoPreventivo"))
        End Get
    End Property

    Public ReadOnly Property RiservaTecnica() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("Riserva"))
        End Get
    End Property

    Public ReadOnly Property DeskChiusura() As String
        Get
            Return String.Format("{0} - {1}", Utx.FunzioniDb.NullToValue(_Dati("StatoTecnico")), Utx.FunzioniDb.NullToValue(_Dati("StatoBilancistico")))
        End Get
    End Property

    Public ReadOnly Property TipoChiusura() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("TipoChiusura"))
        End Get
    End Property

    Public ReadOnly Property StatoTecnico() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("StatoTecnico"))
        End Get
    End Property

    Public ReadOnly Property StatoBilancistico() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("StatoBilancistico"))
        End Get
    End Property
    Public ReadOnly Property DataStatoTecnico() As String
        Get
            Dim Data As String = Utx.FunzioniDb.NullToValue(_Dati("DataStatoTecnico"))
            If Data Is Nothing Then
                Return "-"
            ElseIf CDate(Data) < #1/1/1980# Then
                Return "-"
            Else
                Return Data
            End If
        End Get
    End Property
    Public ReadOnly Property DataStatoBilancistico() As String
        Get
            Dim Data As String = Utx.FunzioniDb.NullToValue(_Dati("DataStatoBilancistico"))
            If Data Is Nothing Then
                Return "-"
            ElseIf CDate(Data) < #1/1/1980# Then
                Return "-"
            Else
                Return Data
            End If
        End Get
    End Property
    Public ReadOnly Property UltimoPagamento() As String
        Get
            Dim Data As String = Utx.FunzioniDb.NullToValue(_Dati("DataUltPagam"))
            If Data Is Nothing Then
                Return "-"
            ElseIf CDate(Data) < #1/1/1980# Then
                Return "-"
            Else
                Return Data
            End If
        End Get
    End Property
    Public ReadOnly Property FlagLegale() As String
        Get
            Return Utx.FunzioniDb.NullToValue(_Dati("FlagLegale"))
        End Get
    End Property
    Public ReadOnly Property DataInterventoLegale() As String
        Get
            Dim Data As String = Utx.FunzioniDb.NullToValue(_Dati("LegaleData"))
            If Data Is Nothing Then
                Return "-"
            ElseIf CDate(Data) < #1/1/1980# Then
                Return "-"
            Else
                Try
                    Return String.Format("{0} - dopo {1} gg", Data, DateDiff(DateInterval.Day, CDate(_Dati("DataSinistro")), CDate(Data)))
                Catch ex As Exception
                    Return Data
                End Try
            End If
        End Get
    End Property
    Public Function IdSinistro() As String
        Try
            Return String.Format("{0}-{1}-{2}-{3}",
                                 _Dati("Compagnia"),
                                 Format(_Dati("AgenziaSinistro"), "0000"),
                                 _Dati("EsercizioSinistro"),
                                 Format(_Dati("NumeroSinistro"), "0000000"))

        Catch ex As Exception
            Return "ND"
        End Try
    End Function
    Public Function IdSinistroDesk() As String
        Return String.Format("Sinistro {0}", Me.IdSinistro)
    End Function

    Public Function IdPolizza() As String
        Try
            Return String.Format("{0}.{1}", Me.RamoPolizza, Me.Polizza)
        Catch ex As Exception
            Return "ND"
        End Try
    End Function

    Public Function Assicurato() As String
        Try
            Return Utx.FunzioniDb.NullToString(_Dati("Assicurato"))
        Catch ex As Exception
            Return "ND"
        End Try
    End Function

    Public Function CfAssicurato() As String
        Return Utx.FunzioniDb.NullToValue(_Dati("CODICEFISCCONTRPOL"))
    End Function

    Public Function Cartella() As String
        Return Utx.FunzioniDb.NullToString(_Dati("IdCartella"))
    End Function

    Private Sub LeggiDatiSinistro()
        Try
            Dim Query As New QuerySinistri With {.Tabella = QuerySinistri.TipoTabella.SINISTRI_DELEGA_PROPRIA}
            Dim Comando As String = Query.CommandTextRicercaSinistro(_Dati("Compagnia"),
                                                               _Dati("AgenziaSinistro"),
                                                               _Dati("EsercizioSinistro"),
                                                               _Dati("NumeroSinistro"))
            _Dati = Utx.WsCommand.ExecuteNonQuery(Comando).DataTable.Rows(0)
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Function SinistriCollegati() As DataTable
        Try
            If String.IsNullOrEmpty(Me.Cartella) Then
                Return Nothing
            Else
                Dim Comando As String = String.Format("SELECT AgenziaSinistro AS Ente,EsercizioSinistro AS Esercizio,
                        NumeroSinistro As Numero,CognomeAssicurato AS Assicurato 
                        FROM {0} AS S
                        WHERE (IdCartella = '{1}') AND (IdCartella <> '0') AND (NumeroSinistro <> {2}) 
                        ORDER BY NumeroSinistro", NomeTabella, Me.Cartella, Me.Numero)
                Return Utx.WsCommand.ExecuteNonQuery(Comando).DataTable
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Class Decodifiche

        Sub New(Tabella As String)
            Me.NomeTabella = Tabella
        End Sub

        Private _NomeTabella As String
        Public Property NomeTabella() As String
            Get
                Return _NomeTabella
            End Get
            Set(ByVal value As String)
                _NomeTabella = value
            End Set
        End Property

        Private _Sinistro As Sinistro
        Public WriteOnly Property Sinistro() As Sinistro
            Set(value As Sinistro)
                _Sinistro = value
            End Set
        End Property

        Private _LetturaDecodifiche As Boolean
        Public Property LetturaDecodifiche() As Boolean
            Get
                Return _LetturaDecodifiche
            End Get
            Set(value As Boolean)
                _LetturaDecodifiche = value
            End Set
        End Property

        Private _Decodifiche As DataRow
        Public Property Decodifiche() As DataRow
            Get
                Return _Decodifiche
            End Get
            Set(value As DataRow)
                _Decodifiche = value
            End Set
        End Property

        Public ReadOnly Property TipoApplicativo() As String
            Get
                Select Case _Sinistro.TipoApplicativo
                    Case "A" : Return "Aida"
                    Case "S" : Return "Sertel"
                    Case "M" : Return "Migrato in Liquido e non variato"
                    Case "C" : Return "Liquido"
                    Case Else : Return ""
                End Select
            End Get
        End Property

        Public ReadOnly Property TipoCid() As String
            Get
                Return Utx.FunzioniDb.NullToValue(_Decodifiche("DeskCid"))
            End Get
        End Property

        Public ReadOnly Property CompagniaControparte() As String
            Get
                Return Utx.FunzioniDb.NullToValue(_Decodifiche("Desc_Compagnia"))
            End Get
        End Property

        Public ReadOnly Property Prodotto() As String
            Get
                Return Utx.FunzioniDb.NullToValue(_Decodifiche("Prodotto"))
            End Get
        End Property

        Public ReadOnly Property RamoGestione() As String
            Get
                Return Utx.FunzioniDb.NullToValue(_Decodifiche("DescBreve"))
            End Get
        End Property
        Public ReadOnly Property Comparto() As String
            Get
                Select Case _Sinistro.Comparto
                    Case 1 : Return "AUTO"
                    Case 2 : Return "RDP"
                    Case 3 : Return "AZIENDE"
                    Case 4 : Return "ALTRI RAMI"
                    Case 5 : Return "VITA"
                    Case Else : Return ""
                End Select
            End Get
        End Property
        Public ReadOnly Property RamoSinistro() As String
            Get
                Return Utx.FunzioniDb.NullToValue(_Decodifiche("DesRamoSinistro"))
            End Get
        End Property

        Public ReadOnly Property TipoSinistro() As String
            Get
                Return Utx.FunzioniDb.NullToValue(_Decodifiche("DescTipoSin"))
            End Get
        End Property

        Public ReadOnly Property Figura() As String
            Get
                Return Utx.FunzioniDb.NullToValue(_Decodifiche("FiguraProduttiva"))
            End Get
        End Property

        Public ReadOnly Property Carrozzeria() As String
            Get
                Return Utx.FunzioniDb.NullToValue(_Decodifiche("Desc_Carrozzeria"))
            End Get
        End Property

        Public ReadOnly Property Liquidatore() As String
            Get
                Return Utx.FunzioniDb.NullToValue(_Decodifiche("Nome"))
            End Get
        End Property

        Public ReadOnly Property Ispettorato() As String
            Get
                Return Utx.FunzioniDb.NullToValue(_Sinistro.Dati("DescIspettorato"))
            End Get
        End Property

        Public ReadOnly Property Convenzione() As String
            Get
                Return Utx.FunzioniDb.NullToValue(_Decodifiche("DeskConvenzione"))
            End Get
        End Property
        Public ReadOnly Property DanniPersoneCose() As String
            Get
                Select Case _Sinistro.DanniPersoneCose
                    Case "P" : Return "Danni a persone"
                    Case "C" : Return "Danni a cose"
                    Case Else : Return "solo per ramo sinistro 30"
                End Select
            End Get
        End Property

        Public ReadOnly Property TipoApertura() As String
            Get
                Select Case _Sinistro.TipoApertura
                    Case 0 : Return "Denuncia cartacea"
                    Case 1 : Return "Denuncia telefonica"
                    Case 2 : Return "Denuncia da web"
                    Case Else : Return ""
                End Select
            End Get
        End Property

        Public ReadOnly Property Presentatore() As String
            Get
                Select Case _Sinistro.Presentatore
                    Case "1" : Return "Agenzia"
                    Case "2" : Return "Clg"
                    Case "3" : Return "Carroziere"
                    Case "4" : Return "Altro (Familiare, dipendente ditta, etc.)"
                    Case Else : Return ""
                End Select
            End Get
        End Property

        Public ReadOnly Property Denunciante() As String
            Get
                Select Case _Sinistro.Denunciante
                    Case "A" : Return "Agenzia"
                    Case "B" : Return "Contraente"
                    Case "C" : Return "Controparte"
                    Case "D" : Return "Carrozzeria"
                    Case "E" : Return "Clg"
                    Case "F" : Return "Legale assicurato"
                    Case "G" : Return "legale controparte"
                    Case "H" : Return "Patrocinatore"
                    Case "I" : Return "Pedone"
                    Case Else : Return ""
                End Select
            End Get
        End Property

        Public ReadOnly Property TipoCarrozzeria() As String
            Get
                Dim tc As String = _Sinistro.TipoCarrozzeria
                If tc = "" Then
                    Return ""
                Else
                    Select Case CInt(_Sinistro.TipoCarrozzeria)
                        Case 1 : Return "Area TEST carrozzeria collegata"
                        Case 3 : Return "Carrozzeria gemellata"
                        Case 4 : Return "Carrozzeria di riferimento"
                        Case 5 : Return "Convenzionata (livello informatizzazione elevato)"
                        Case 9 : Return "Centro Riparazione Cristalli"
                        Case 10 : Return "Autorizzata (livello informatizzazione elevato)"
                        Case 20 : Return "Livello di informatizzazione elevato"
                        Case 29 : Return "Carrozzeria informatizzata in prova"
                        Case 50 : Return "Autorizzata (livello informatizzazione basso)"
                        Case 60 : Return "Livello di informatizzazione basso"
                        Case 61 : Return "Livello di informatizzazione basso SOLO LA o VE"
                        Case 80 : Return "Altre"
                        Case 81 : Return "Altre solo LA o VE"
                        Case 90 : Return "Ripara solo Veicoli Industriali"
                        Case 91 : Return "Officina Meccanica"
                        Case 92 : Return "Dati insufficienti"
                        Case 93 : Return "Inesistente o Cessata Attivita'"
                        Case 94 : Return "Non Collaborativa"
                        Case 95 : Return "Non piu aderenti"
                        Case 99 : Return "Inaffidabile"
                        Case Else : Return ""
                    End Select
                End If
            End Get
        End Property

        Public ReadOnly Property InterventoLegale() As String
            Get
                Select Case _Sinistro.FlagLegale
                    Case "1" : Return "Denuncia aperta dal legale (cod.1)"
                    Case "2" : Return "Presenza di anagrafica del legale (cod.2)"
                    Case "3" : Return "Pagamento effettuato al legale (cod.3)"
                    Case Else : Return ""
                End Select
            End Get
        End Property

        Public Shared ReadOnly Property Stato(CodiceStato As String) As String
            Get
                Select Case CodiceStato
                    Case ".." : Return "APERTO"
                    Case "LT" : Return "LIQUIDAZIONE TOTALE"
                    Case "LP" : Return "LIQUIDAZIONE PARZIALE"
                    Case "SS" : Return "SENZA SEGUITO"
                    Case Else : Return ""
                End Select
            End Get
        End Property

        Public Sub LeggiDecodifiche()
            Try
                If _LetturaDecodifiche = True Then
                    Exit Sub
                End If

                Dim sql As String = "SELECT t.DescTipoSin, i.DescIspettorato, ag.DescIspettorato AS DescAgenziaSinistro, trs.DesRamoSinistro, 
                    ca.Desc_Compagnia, cr.Desc_Carrozzeria, f.FiguraProduttiva, liq.Nome, liq.Telefono, liq.Email, liq.Clg, liq.Localita, liq.TelefonoClg, 
                    rg.DescBreve, tc.Desk AS DeskCid, pr.Prodotto, cv.Desk AS DeskConvenzione
                    FROM {0} AS s 
                    LEFT JOIN DB00000.dbo.Ispettorato AS i (NOLOCK) ON s.Ispettorato = i.Ispettorato
                    LEFT JOIN DB00000.dbo.Ispettorato AS ag (NOLOCK) ON s.AgenziaSinistro = ag.Ispettorato
                    LEFT JOIN DB00000.dbo.TipoSinistro AS t (NOLOCK) ON (s.TipoSinistro = t.TipoSinistro) AND (s.RamoSinistro = t.RamoSinistro)
                    LEFT JOIN DB00000.dbo.TipoRamiSinistro AS trs (NOLOCK) ON s.Ramosinistro = trs.RamoSinistro
                    LEFT JOIN DB00000.dbo.CompagniaANIA AS ca (NOLOCK) ON s.CompControparte = ca.Compagnia
                    LEFT JOIN DB00000.dbo.Carrozzeria AS cr (NOLOCK) ON (s.CarrozzCAnia = cr.IdCarrozzeria) AND (s.CarrozzProv = cr.Provincia)
                    LEFT JOIN FigureProduttive AS f (NOLOCK) ON s.CodiceSubAgenteSima = f.IdFiguraProduttiva
                    LEFT JOIN DB00000.dbo.RamoGest AS rg (NOLOCK) ON s.RamoGestione = rg.RamoGestione
                    LEFT JOIN Liquidatori AS liq (NOLOCK) ON s.CodiceLiquidatore = liq.Codice
                    LEFT JOIN DB00000.dbo.TipoCid AS tc (NOLOCK) ON s.TipoCid = tc.TipoCid
                    LEFT JOIN DB00000.dbo.Prodotti AS pr (NOLOCK) ON RIGHT(CONCAT('00000',s.CodiceProdotto),5)=pr.CodiceProdotto
                    LEFT JOIN DB00000.dbo.Convenzioni AS cv (NOLOCK) ON CAST(s.Convenzione AS INT)=cv.Codice
                    WHERE s.Compagnia={1} AND s.EsercizioSinistro={2} AND s.AgenziaSinistro={3} AND s.NumeroSinistro={4}"

                sql = String.Format(sql, NomeTabella, _Sinistro.Compagnia,
                                    _Sinistro.Esercizio, _Sinistro.Agenzia, _Sinistro.Numero)

                Using s As New Utx.ServiziOMW.ServizioDatiOMW
                    s.Proxy = Utx.Globale.UniProxy.Proxy
                    _Decodifiche = Utx.WsCommand.ExecuteNonQuery(sql).DataTable.Rows(0)
                End Using

                _LetturaDecodifiche = True

            Catch ex As Exception
                Globale.Log.Errore(ex)
            End Try
        End Sub
    End Class
End Class
