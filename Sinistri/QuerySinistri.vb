Public Class QuerySinistri

#Region "Enum"
    Public Enum CercaIn
        NO_RICERCA
        ASSICURATO
        CONTROPARTE
        TARGA_ASSICURATO
        TARGA_CONTROPARTE
        CF_ASSICURATO
        NUMERO_SINISTRO
        DATA_SINISTRO
        NOTE_SINISTRO_CORPO
        NOTE_SINISTRO_REDATTORE
    End Enum
    Public Enum DefaultElenco
        SELEZIONE
        COMPLETO
        ATTIVITA
    End Enum
    Public Enum TipoChiusura
        TUTTI
        APERTI
        CHIUSI
    End Enum
    Public Enum TipoTabella
        SINISTRI_DELEGA_PROPRIA
        SINISTRI_DELEGA_ALTRUI
        SINISTRI_ALTRA_COMPAGNIA
        SINISTRI_DP_ALTRI
    End Enum
#End Region

    Public Event QueryChanged()
    Public Event EserciziChanged()

    Private ReadOnly CampiRicerca As New Dictionary(Of Integer, String)
    Private mModificata As Boolean

    Sub New()
        'lista esercizi e mesi: tutti
        mListaEsercizi = New List(Of Integer)
        mListaMesi = New List(Of Integer)
        'nomi dei campi di ricerca
        CampiRicerca.Add(CercaIn.ASSICURATO, "CognomeAssicurato")
        CampiRicerca.Add(CercaIn.CF_ASSICURATO, "CODICEFISCCONTRPOL")
        CampiRicerca.Add(CercaIn.CONTROPARTE, "CognomeDanneggiato")
        CampiRicerca.Add(CercaIn.DATA_SINISTRO, "DataSinistro")
        CampiRicerca.Add(CercaIn.NUMERO_SINISTRO, "NumeroSinistro")
        CampiRicerca.Add(CercaIn.TARGA_ASSICURATO, "TargaAssicurato")
        CampiRicerca.Add(CercaIn.TARGA_CONTROPARTE, "TargaDanneggiato")
        'chiave
        mChiaveRicerca = ""
        mModificata = False
    End Sub

    Private mTipoRicerca As CercaIn
    Public Property TipoRicerca() As CercaIn
        Get
            Return mTipoRicerca
        End Get
        Set(value As CercaIn)
            mTipoRicerca = value
        End Set
    End Property

    Private mChiusura As TipoChiusura
    Public Property Chiusura() As TipoChiusura
        Get
            Return mChiusura
        End Get
        Set(value As TipoChiusura)
            mChiusura = value
            If mAbilitata = True Then
                RaiseEvent QueryChanged()
            Else
                mModificata = True
            End If
        End Set
    End Property

    Private mTabella As TipoTabella
    Public Property Tabella() As TipoTabella
        Get
            Return mTabella
        End Get
        Set(value As TipoTabella)
            mTabella = value
            Select Case mTabella
                Case TipoTabella.SINISTRI_DELEGA_PROPRIA : _NomeTabella = "SinistriDP"
                Case TipoTabella.SINISTRI_DELEGA_ALTRUI : _NomeTabella = "SinistriDA"
                Case TipoTabella.SINISTRI_ALTRA_COMPAGNIA : _NomeTabella = "SinistriAC"
                Case TipoTabella.SINISTRI_DP_ALTRI : _NomeTabella = "(SELECT * FROM SinistriDP UNION ALL SELECT * FROM SinistriAC)"
                Case Else : _NomeTabella = "" 'non deve mai essere qui
            End Select

            If mAbilitata = True Then
                RaiseEvent QueryChanged()
            Else
                mModificata = True
            End If
        End Set
    End Property

    Private _NomeTabella As String
    Public ReadOnly Property NomeTabella() As String
        Get
            Return _NomeTabella
        End Get
    End Property

    Private mUtente As String
    Public Property Utente() As String
        Get
            Return mUtente
        End Get
        Set(value As String)
            mUtente = value
        End Set
    End Property

    Private mChiaveRicerca As String
    Public Property ChiaveRicerca() As String
        Get
            Return mChiaveRicerca
        End Get
        Set(value As String)
            If mChiaveRicerca <> value.Trim Then
                mChiaveRicerca = value.Trim.Replace("'", "")
                If mAbilitata = True Then
                    RaiseEvent QueryChanged()
                Else
                    mModificata = True
                End If
            End If
        End Set
    End Property

    Private mCorrispondenzaEsatta As Boolean
    Public Property CorrispondenzaEsatta() As Boolean
        Get
            Return mCorrispondenzaEsatta
        End Get
        Set(value As Boolean)
            mCorrispondenzaEsatta = value
            If mAbilitata = True Then
                RaiseEvent QueryChanged()
            Else
                mModificata = True
            End If
        End Set
    End Property

    Private mTipoElenco As DefaultElenco
    Public Property TipoElenco() As DefaultElenco
        Get
            Return mTipoElenco
        End Get
        Set(value As DefaultElenco)
            mTipoElenco = value
            'quando cambio il tipo elenco (selezione/completo) se c'è la chiave non serve aggiornare
            If mChiaveRicerca.Length = 0 Then
                If mAbilitata = True Then
                    RaiseEvent QueryChanged()
                Else
                    mModificata = True
                End If
            End If
        End Set
    End Property

    Private mTipoRicercaNota As Utx.Nota.CercaNota
    Public Property TipoRicercaNota() As Utx.Nota.CercaNota
        Get
            Return mTipoRicercaNota
        End Get
        Set(value As Utx.Nota.CercaNota)
            mTipoRicercaNota = value
        End Set
    End Property

    Private mListaEsercizi As List(Of Integer)
    Public Property ListaEsercizi() As List(Of Integer)
        Get
            Return mListaEsercizi
        End Get
        Set(value As List(Of Integer))
            mListaEsercizi = value
            RaiseEvent EserciziChanged()
            If mAbilitata = True Then
                RaiseEvent QueryChanged()
            Else
                mModificata = True
            End If
        End Set
    End Property

    Private mListaMesi As List(Of Integer)
    Public Property ListaMesi() As List(Of Integer)
        Get
            Return mListaMesi
        End Get
        Set(value As List(Of Integer))
            mListaMesi = value
            RaiseEvent EserciziChanged()
            If mAbilitata = True Then
                RaiseEvent QueryChanged()
            Else
                mModificata = True
            End If
        End Set
    End Property
    Public Sub ImpostaEserciziMesi(Esercizi As List(Of Integer), Mesi As List(Of Integer))
        mListaEsercizi = Esercizi
        mListaMesi = Mesi
        RaiseEvent EserciziChanged()
        If mAbilitata = True Then
            RaiseEvent QueryChanged()
        Else
            mModificata = True
        End If
    End Sub

    Public ReadOnly Property ListaEserciziStringa(Optional Separatore As String = "/") As String
        Get
            If mListaEsercizi.Count = 0 Then
                Return "tutti"
            Else
                Dim value As String = ""
                For Each e As String In mListaEsercizi
                    value += e + Separatore
                Next
                Return value.Substring(0, value.Length - 1)
            End If
        End Get
    End Property

    Public Sub ResetEsercizi()
        Me.ListaEsercizi = New List(Of Integer)
        Me.ListaMesi = New List(Of Integer)
    End Sub

    Private mAbilitata As Boolean
    Public Property Abilitata() As Boolean
        Get
            Return mAbilitata
        End Get
        Set(value As Boolean)
            mAbilitata = value
            If (mAbilitata = True) AndAlso (mModificata = True) Then
                RaiseEvent QueryChanged()
            End If
        End Set
    End Property

    Private mAttivitaDal As Date
    Public Property AttivitaDal() As Date
        Get
            Return mAttivitaDal
        End Get
        Set(value As Date)
            mAttivitaDal = value
        End Set
    End Property

    Private mAttivitaAl As Date
    Public Property AttivitaAl() As Date
        Get
            Return mAttivitaAl
        End Get
        Set(value As Date)
            mAttivitaAl = value
        End Set
    End Property

    Public Function CommandText() As String
        Try
            If mAbilitata = False Then
                Return ""
            End If

            Dim Operatore As String = ""

            If mCorrispondenzaEsatta = False Then
                Operatore = "%"
            End If

            If mChiaveRicerca.Trim.Length = 0 Then
                'se non c'è una chiave di ricerca >> per tipo elenco
                Select Case mTipoElenco
                    Case DefaultElenco.SELEZIONE
                        CommandText = "" 'non deve restituire niente
                    Case DefaultElenco.COMPLETO
                        CommandText = String.Format("{0} WHERE {1} AND {2} AND {3}",
                                                    QueryBaseCompleta,
                                                    WhereEsercizi,
                                                    WhereMesi,
                                                    WhereChiusura)
                    Case DefaultElenco.ATTIVITA
                        CommandText = String.Format(QueryBaseCompletaNoteWeb, mAttivitaDal, mAttivitaAl, mUtente)
                End Select
            Else
                Select Case mTipoRicerca
                    Case CercaIn.NUMERO_SINISTRO
                        CommandText = String.Format("{0} WHERE {1} AND {2} AND {3} AND (Sinistri.NumeroSinistro = {4})",
                                                    QueryBaseCompleta,
                                                    WhereEsercizi,
                                                    WhereMesi,
                                                    WhereChiusura,
                                                    mChiaveRicerca)
                    Case CercaIn.NOTE_SINISTRO_CORPO, CercaIn.NOTE_SINISTRO_REDATTORE
                        CommandText = QueryRicercaInNote()
                    Case Else
                        CommandText = String.Format("{0} WHERE {1} AND {2} AND {3} AND (Sinistri.{4} LIKE '{5}{6}%')",
                                                    QueryBaseCompleta,
                                                    WhereEsercizi,
                                                    WhereMesi,
                                                    WhereChiusura,
                                                    CampiRicerca(mTipoRicerca),
                                                    Operatore,
                                                    mChiaveRicerca)
                End Select
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            CommandText = ""
        End Try
        Globale.Log.Trace(CommandText)
    End Function

    Public Function CommandTextRicercaSinistro(Compagnia As Integer, Ente As Integer, Esercizio As Integer, Numero As Integer) As String
        Try
            Return String.Format("{0} WHERE Sinistri.Compagnia = {1} AND
                Sinistri.AgenziaSinistro = {2} AND 
                Sinistri.EsercizioSinistro = {3} AND 
                Sinistri.NumeroSinistro = {4}", QueryBaseCompleta, Compagnia, Ente, Esercizio, Numero)
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Function QueryBaseCompleta(Optional Distinct As Boolean = False) As String
        Dim Query As String = "
            WITH Andamento AS (SELECT Max(AnnoMeseCompetenza) AS MaxAnnoMeseCompetenza,
                AgenziaSinistro,EsercizioSinistro,NumeroSinistro 
                FROM AndamentoSinistri WITH (NOLOCK)
                GROUP BY AgenziaSinistro,EsercizioSinistro,NumeroSinistro)

            SELECT {0} MaxAnnoMeseCompetenza, s.AnnoMeseCompetenza, s.EsercizioSinistro, s.AgenziaSinistro, 
            s.RamoSinistro,TipoRamiSinistro.DesRamoSinistro,s.NumeroSinistro,
            s.Ispettorato, TblIspettorato.DescIspettorato, s.AgenziaPolizza, s.RamoPolizza, s.Polizza, 
            s.CodiceSubAgenteSima,s.CodiceProduttoreSima,s.DataSinistro,s.DataDenuncia,s.DataProtocollo,
            s.TipoCid,TblTipoCid.Desk AS DeskCid,s.TipoChiusura,s.CodiceChiusura,s.TipoSinistro AS TipoSx,
            TipoSinistro.DescTipoSin,s.FlagCosePersone,s.NostraQuota,s.PrimoPreventivo,
            s.PagatoDel, s.PagatoAl, s.RecuperoDel, s.RecuperoAl, s.FranchigiaPtf, 
            s.Convenzione,s.CodiceProdotto,
            s.CognomeAssicurato + s.NomeAssicurato AS Assicurato,s.TargaAssicurato,s.CognomeDanneggiato,
            s.TargaDanneggiato,s.Compagnia,s.AgenziaPolizzaArrivo,
            s.CodiceLiquidatore,Liquidatori.Nome AS NomeLiquidatore,s.TipoDelega,s.CODICEFISCCONTRPOL,
            s.DataUltPagam,s.DataDenCliente,s.CompControparte,
            s.TipoApplicativo, s.NrPosizioni, s.TipoApertura, 
            s.Presentatore,s.Denunciante,
            s.IdCartella, s.CodProf, s.CarrozzProv, s.CarrozzCAnia, 
            s.LegaleData,s.CarrozzPrior,s.DataMemo,s.Unibox,
            s.CardGest, s.CardDebito, s.CardNo, 
            s.PagatoNoCardAl,s.PagatoNoCardDel,s.PagatoCardAl,s.PagatoCardDel,
            s.AgenziaMadre, s.DataApertura, s.FlagLegale, s.TipoDenuncia, 
            s.Canalizzato,s.CodCarrPagato,s.CodCarrCanalizzato,
            s.PrevStat, s.SetTariffa, s.TipoRamo, s.Lesioni, s.Morti, s.Franchigie, 
            s.Rivalse,s.Riserva,s.RamoGestione,s.CodicePerito,
            PI.Cognome + ' ' + PI.Nome + ' (' + PI.Telefono + ')' AS NomePerito,
            s.Lira, s.RiservaBilancio, s.IdStatoCliente, s.IdGestione, s.FlagUtente, s.Modifica, s.Comparto, 
            s.StatoTecnico,s.DataStatoTecnico,s.StatoBilancistico,s.DataStatoBilancistico,
            TblApp.Descrizione AS DeskApp, TblComparto.Descrizione AS DeskComparto, Convenzioni.Desk AS DeskConv
            FROM {1} AS Sinistri
            LEFT JOIN DB00000.dbo.Ispettorato AS TblIspettorato WITH (NOLOCK) ON Sinistri.Ispettorato = TblIspettorato.Ispettorato 
            LEFT JOIN DB00000.dbo.TipoRamiSinistro WITH (NOLOCK) ON Sinistri.RamoSinistro = TipoRamiSinistro.RamoSinistro 
            LEFT JOIN DB00000.dbo.TipoSinistro WITH (NOLOCK) ON Sinistri.TipoSinistro = TipoSinistro.TipoSinistro AND Sinistri.RamoSinistro = TipoSinistro.RamoSinistro 
            LEFT JOIN Liquidatori WITH (NOLOCK) ON Sinistri.CodiceLiquidatore = Liquidatori.Codice 
            LEFT JOIN DB00000.dbo.TipoCid AS TblTipoCid WITH (NOLOCK) ON Sinistri.TipoCid = TblTipoCid.TipoCid 
            LEFT JOIN DB00000.dbo.Convenzioni WITH (NOLOCK) ON CAST(Sinistri.Convenzione AS Int) = Convenzioni.Codice 
            LEFT JOIN DB00000.dbo.Comparto AS TblComparto WITH (NOLOCK) ON Sinistri.Comparto = TblComparto.Codice 
            LEFT JOIN DB00000.dbo.ApplicativoSinistri AS TblApp WITH (NOLOCK) ON Sinistri.TipoApplicativo = TblApp.Codice 
            LEFT JOIN PeritoIncaricato AS PI WITH (NOLOCK) ON Sinistri.CodicePerito = PI.IdPeritoSAP 
            LEFT JOIN Andamento ON Andamento.AgenziaSinistro = Sinistri.AgenziaSinistro AND 
            Andamento.EsercizioSinistro = Sinistri.EsercizioSinistro AND 
            Andamento.NumeroSinistro = Sinistri.NumeroSinistro"

        If Distinct = False Then
            Return String.Format(Query, "", Me.NomeTabella).Replace("s.", "Sinistri.")
        Else
            Return String.Format(Query, "DISTINCT", Me.NomeTabella).Replace("s.", "Sinistri.")
        End If
    End Function

    Private Function QueryBaseCompletaNoteWeb() As String
        Dim Query As String = "SELECT DISTINCT s.AnnoMeseCompetenza,s.EsercizioSinistro,s.AgenziaSinistro,s.RamoSinistro,
            TipoRamiSinistro.DesRamoSinistro,s.NumeroSinistro,s.Ispettorato,TblIspettorato.DescIspettorato,s.AgenziaPolizza,
            s.RamoPolizza,s.Polizza,s.CodiceSubAgenteSima,s.CodiceProduttoreSima,s.DataSinistro,s.DataDenuncia,s.DataProtocollo,
            s.TipoCid,TblTipoCid.Desk AS DeskCid,s.TipoChiusura,s.CodiceChiusura,s.TipoSinistro AS TipoSx,TipoSinistro.DescTipoSin,
            s.FlagCosePersone,s.NostraQuota,s.PrimoPreventivo,s.PagatoDel,s.PagatoAl,s.RecuperoDel,s.RecuperoAl,s.FranchigiaPtf,
            s.Convenzione,s.CodiceProdotto,s.CognomeAssicurato + s.NomeAssicurato AS Assicurato,s.TargaAssicurato,s.CognomeDanneggiato,
            s.TargaDanneggiato,s.Compagnia,s.AgenziaPolizzaArrivo,s.CodiceLiquidatore,Liquidatori.Nome AS NomeLiquidatore,s.TipoDelega,
            s.CODICEFISCCONTRPOL,s.DataUltPagam,s.DataDenCliente,s.CompControparte,s.TipoApplicativo,s.NrPosizioni,s.TipoApertura,
            s.Presentatore,s.Denunciante,s.IdCartella,s.CodProf,s.CarrozzProv,s.CarrozzCAnia,s.LegaleData,s.CarrozzPrior,s.DataMemo,s.Unibox,
            s.CardGest,s.CardDebito,s.CardNo,s.PagatoNoCardAl,s.PagatoNoCardDel,s.PagatoCardAl,s.PagatoCardDel,s.AgenziaMadre,s.DataApertura,
            s.FlagLegale,s.TipoDenuncia,s.Canalizzato,s.CodCarrPagato,s.CodCarrCanalizzato,s.PrevStat,s.SetTariffa,s.TipoRamo,s.Lesioni,
            s.Morti,s.Franchigie,s.Rivalse,s.Riserva,s.RamoGestione,s.CodicePerito,
            PI.Cognome + ' ' + PI.Nome + ' (' + PI.Telefono + ')' AS NomePerito,s.Lira,s.RiservaBilancio,s.IdStatoCliente,s.IdGestione,
            s.FlagUtente,s.Modifica,s.Comparto,s.StatoTecnico,s.DataStatoTecnico,s.StatoBilancistico,s.DataStatoBilancistico
            FROM @tabella AS Sinistri
            INNER JOIN (SELECT SUBSTRING(IdNota,1,1) AS Compagnia,SUBSTRING(IdNota,3,4) AS Ente,SUBSTRING(IdNota,8,4) AS Esercizio,
                SUBSTRING(IdNota,13,7) AS Numero,Utente
                FROM SinistriMemo 
                WHERE (Tipo = 'A') AND (Allarme BETWEEN '{0:dd/MM/yyyy}' AND '{1:dd/MM/yyyy}') AND (LEN(IdNota) = 19)) AS M
			ON s.Compagnia = M.Compagnia AND s.AgenziaSinistro = M.Ente AND s.EsercizioSinistro = M.Esercizio AND  s.NumeroSinistro = M.Numero
            LEFT JOIN Ispettorato AS TblIspettorato ON Sinistri.Ispettorato = TblIspettorato.Ispettorato
            LEFT JOIN TipoRamiSinistro ON Sinistri.RamoSinistro = TipoRamiSinistro.RamoSinistro
            LEFT JOIN TipoSinistro ON Sinistri.TipoSinistro = TipoSinistro.TipoSinistro AND Sinistri.RamoSinistro = TipoSinistro.RamoSinistro
            LEFT JOIN Liquidatori ON Sinistri.CodiceLiquidatore = Liquidatori.Codice
            LEFT JOIN TipoCid AS TblTipoCid ON Sinistri.TipoCid = TblTipoCid.TipoCid
            LEFT JOIN PeritoIncaricato AS PI ON Sinistri.CodicePerito = PI.IdPeritoSAP
            WHERE M.Utente LIKE '%{2}%'"
        Return Replace(Query.Replace("@tabella", Me.NomeTabella), "s.", "Sinistri.", Compare:=CompareMethod.Text)
    End Function

    Private Function QueryRicercaInNote() As String
        Dim Query As String = String.Format("SELECT DISTINCT s.AnnoMeseCompetenza,s.EsercizioSinistro,s.AgenziaSinistro,s.RamoSinistro,
            TipoRamiSinistro.DesRamoSinistro,s.NumeroSinistro,s.Ispettorato,TblIspettorato.DescIspettorato,s.AgenziaPolizza,
            s.RamoPolizza,s.Polizza,s.CodiceSubAgenteSima,s.CodiceProduttoreSima,s.DataSinistro,s.DataDenuncia,s.DataProtocollo,
            s.TipoCid,TblTipoCid.Desk AS DeskCid,s.TipoChiusura,s.CodiceChiusura,s.TipoSinistro AS TipoSx,TipoSinistro.DescTipoSin,
            s.FlagCosePersone,s.NostraQuota,s.PrimoPreventivo,s.PagatoDel,s.PagatoAl,s.RecuperoDel,s.RecuperoAl,s.FranchigiaPtf,
            s.Convenzione,s.CodiceProdotto,s.CognomeAssicurato + s.NomeAssicurato AS Assicurato,s.TargaAssicurato,s.CognomeDanneggiato,
            s.TargaDanneggiato,s.Compagnia,s.AgenziaPolizzaArrivo,s.CodiceLiquidatore,Liquidatori.Nome AS NomeLiquidatore,s.TipoDelega,
            s.CODICEFISCCONTRPOL,s.DataUltPagam,s.DataDenCliente,s.CompControparte,s.TipoApplicativo,s.NrPosizioni,s.TipoApertura,
            s.Presentatore,s.Denunciante,s.IdCartella,s.CodProf,s.CarrozzProv,s.CarrozzCAnia,s.LegaleData,s.CarrozzPrior,s.DataMemo,s.Unibox,
            s.CardGest,s.CardDebito,s.CardNo,s.PagatoNoCardAl,s.PagatoNoCardDel,s.PagatoCardAl,s.PagatoCardDel,s.AgenziaMadre,s.DataApertura,
            s.FlagLegale,s.TipoDenuncia,s.Canalizzato,s.CodCarrPagato,s.CodCarrCanalizzato,s.PrevStat,s.SetTariffa,s.TipoRamo,s.Lesioni,
            s.Morti,s.Franchigie,s.Rivalse,s.Riserva,s.RamoGestione,s.CodicePerito,
            PI.Cognome + ' ' + PI.Nome + ' (' + PI.Telefono + ')' AS NomePerito,s.Lira,s.RiservaBilancio,s.IdStatoCliente,s.IdGestione,
            s.FlagUtente,s.Modifica,s.Comparto,s.StatoTecnico,s.DataStatoTecnico,s.StatoBilancistico,s.DataStatoBilancistico
            FROM {0} AS Sinistri
            INNER JOIN SinistriMemo AS M
			ON SUBSTRING(IdNota,1,1) = s.Compagnia AND SUBSTRING(IdNota,3,4) = s.AgenziaSinistro AND 
               SUBSTRING(IdNota,8,4) = s.EsercizioSinistro AND SUBSTRING(IdNota,13,7) = s.NumeroSinistro
            LEFT JOIN Ispettorato AS TblIspettorato ON Sinistri.Ispettorato = TblIspettorato.Ispettorato
            LEFT JOIN TipoRamiSinistro ON Sinistri.RamoSinistro = TipoRamiSinistro.RamoSinistro
            LEFT JOIN TipoSinistro ON Sinistri.TipoSinistro = TipoSinistro.TipoSinistro AND Sinistri.RamoSinistro = TipoSinistro.RamoSinistro
            LEFT JOIN Liquidatori ON Sinistri.CodiceLiquidatore = Liquidatori.Codice
            LEFT JOIN TipoCid AS TblTipoCid ON Sinistri.TipoCid = TblTipoCid.TipoCid
            LEFT JOIN PeritoIncaricato AS PI ON Sinistri.CodicePerito = PI.IdPeritoSAP
            WHERE LEN(M.IdNota) = 19 AND M.Memo LIKE '%{1}%'", Me.NomeTabella, mChiaveRicerca)
        Return Replace(Query, "s.", "Sinistri.", Compare:=CompareMethod.Text)
    End Function

    Public Function CommandTextSopravvenienze() As String
        Try
            Return "DECLARE @maxanno AS int = (SELECT MAX(AnnoCompetenza) AS Anno FROM SinistriAia);

                WITH B AS (SELECT age_sin_3 AS agenziasinistro,esercizio_sx_4 AS eserciziosinistro,num_sin_5 AS numerosinistro,
                    tipo_chius_10 AS chiusura3112,IIf(eser_den_11 = 'EC',costo_sx_ec_plafonato_21,-sopravv_32) AS Impatto,
                    IIf(eser_den_11='EC',costo_sx_ec_plafonato_21,costo_fin_sx_ep_plafonato_31) AS CostoPrecedentePlafonato,
                    soglia_anno_corrente_13 AS Soglia 
                    FROM SinistriAia WITH(NOLOCK)
                    WHERE (AnnoCompetenza = @maxanno)),
				
                C AS (SELECT AgenziaSinistro,EsercizioSinistro,NumeroSinistro,
                    Iif(TipoChiusura = 'LT',PagatoAl,PagatoAl + Riserva) AS CostoCorrente 
                    FROM SinistriDP WITH(NOLOCK)
                    WHERE EsercizioSinistro <= @maxanno  AND YEAR(AnnoMeseCompetenza) > @maxanno),

                ASI AS (SELECT MAX(AnnoMeseCompetenza) AS MaxAnnoMeseCompetenza,AgenziaSinistro,EsercizioSinistro,NumeroSinistro 
                    FROM AndamentoSinistri WITH(NOLOCK)
                    GROUP BY AgenziaSinistro,EsercizioSinistro,NumeroSinistro)

                SELECT DISTINCT S.AnnoMeseCompetenza,S.Compagnia,S.AgenziaSinistro,S.EsercizioSinistro,S.NumeroSinistro,
                S.CodiceSubAgenteSima,S.CognomeAssicurato + S.NomeAssicurato AS Assicurato,B.chiusura3112,S.StatoTecnico,
                S.DataStatoTecnico,S.TipoCid,S.DataUltPagam,S.StatoBilancistico,S.DataStatoBilancistico,B.Impatto,B.CostoPrecedentePlafonato,
                C.CostoCorrente,Iif(C.CostoCorrente <= B.soglia,C.CostoCorrente,B.Soglia) AS CostoCorrentePlafonato,
                (Iif(C.CostoCorrente <= B.soglia,C.CostoCorrente,B.Soglia) - B.CostoPrecedentePlafonato) AS Sopravvenienza,
                S.CODICEFISCCONTRPOL,B.soglia,S.RamoPolizza,S.Polizza,ASI.MaxAnnoMeseCompetenza,S.TipoApplicativo 
                FROM SinistriDP AS S WITH(NOLOCK)
                INNER JOIN B ON S.NumeroSinistro = B.NumeroSinistro AND S.EsercizioSinistro = B.EsercizioSinistro AND S.AgenziaSinistro = B.AgenziaSinistro
                INNER JOIN C ON S.NumeroSinistro = C.NumeroSinistro AND S.EsercizioSinistro = C.EsercizioSinistro AND S.AgenziaSinistro = C.AgenziaSinistro
                LEFT JOIN ASI ON ASI.AgenziaSinistro = S.AgenziaSinistro AND ASI.EsercizioSinistro = S.EsercizioSinistro AND ASI.NumeroSinistro = S.NumeroSinistro 
                WHERE (S.EsercizioSinistro <= @maxanno) AND (YEAR(S.AnnoMeseCompetenza) > @maxanno AND (NOT S.StatoBilancistico IN ('LT','SS'))) 
                ORDER BY S.EsercizioSinistro DESC,S.CognomeAssicurato + S.NomeAssicurato"

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Public Function CommandTextPerizie() As String
        Try
            Return "SELECT MAX(I.DataCompetenza) AS DataCompetenza,S.Compagnia,I.AgenziaSinistro,I.EsercizioSinistro,I.NumeroSinistro,S.DataSinistro,S.Canalizzato,
                S.CognomeAssicurato,TblComparto.Descrizione AS Comparto,S.RamoPolizza,S.Polizza,S.CodiceSubAgenteSima,I.Posizione,I.CFDanneggiato,TRIM(I.Cognome) + Space(1) + TRIM(I.Nome) AS Danneggiato,
                TRIM(I.TipoIncaricoCC) AS TipoIncaricoCC,I.DataIncarico,I.DataRestituzione,I.StatoIncarico,I.StatoIncaricoCarrozzeria,
                I.EsitoPerizia,TRIM(I.TipoFiduciario) AS TipoFiduciario,TRIM(P.Cognome) + Space(1) + TRIM(P.Nome) AS Perito,P.Telefono,
                P.Cellulare,P.IdPeritoSAP,L.Codice AS CodiceLiquidatore,L.Nome AS NomeLiquidatore,S.Riserva
                FROM SIncarichi AS I WITH(NOLOCK) 
                INNER JOIN PeritoIncaricato AS P WITH(NOLOCK) ON P.IdPeritoSAP = I.CodicePeritoSAP
                INNER JOIN SinistriDP AS S WITH(NOLOCK) ON S.AgenziaSinistro = I.AgenziaSinistro AND S.EsercizioSinistro = I.EsercizioSinistro AND S.NumeroSinistro = I.NumeroSinistro
                LEFT JOIN Liquidatori AS L WITH(NOLOCK) ON S.CodiceLiquidatore = L.Codice
                LEFT JOIN DB00000.dbo.Comparto AS TblComparto WITH (NOLOCK) ON S.Comparto = TblComparto.Codice 
                WHERE (S.StatoTecnico IN ('..','LP')) AND (NOT I.CodicePeritoSAP IS NULL) AND (I.CodicePeritoSAP <> '') AND (StatoIncarico NOT LIKE 'REVOCATO%')
                GROUP BY S.Compagnia,I.AgenziaSinistro,I.EsercizioSinistro,I.NumeroSinistro,S.DataSinistro,S.Canalizzato,S.CognomeAssicurato,S.RamoPolizza,S.Polizza,TblComparto.Descrizione,
                S.CodiceSubAgenteSima,I.Posizione,I.CFDanneggiato,TRIM(I.Cognome) + Space(1) + TRIM(I.Nome),
                TRIM(I.TipoIncaricoCC),I.DataIncarico,I.DataRestituzione,I.StatoIncarico,I.StatoIncaricoCarrozzeria,
                I.EsitoPerizia,TRIM(I.TipoFiduciario),TRIM(P.Cognome) + Space(1) + TRIM(P.Nome),P.Telefono,P.Cellulare,P.IdPeritoSAP,L.Codice,L.Nome,S.Riserva
                ORDER BY MAX(I.DataCompetenza) DESC,I.DataIncarico DESC"
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Function WhereCercaNote() As String
        Try
            mChiaveRicerca = Replace(mChiaveRicerca, """", "", , , CompareMethod.Text)
            mChiaveRicerca = Replace(mChiaveRicerca, "'", "", , , CompareMethod.Text)

            Dim CampoRicerca As String
            If mTipoRicerca = CercaIn.NOTE_SINISTRO_CORPO Then
                CampoRicerca = " m.Memo LIKE '%{0}%'"
            Else
                CampoRicerca = " m.Utente LIKE '%{0}%'"
            End If

            Dim Parole() As String
            Parole = Split(mChiaveRicerca, Space(1), , CompareMethod.Text)

            Dim ClausolaWhere As String = ""

            For Each p As String In Parole
                If ClausolaWhere.Length > 0 Then
                    ClausolaWhere += " AND "
                End If

                ClausolaWhere += ClausolaWhere + String.Format(CampoRicerca, p.Trim)
            Next

            Return ClausolaWhere

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Function WhereEsercizi() As String
        Try
            If mListaEsercizi.Count = 0 Then
                Return " 0=0 "
            Else
                Dim Clausola As String = " (Sinistri.EsercizioSinistro IN ({0})) "

                For Each e As Integer In mListaEsercizi
                    Clausola = String.Format(Clausola, e.ToString + ",{0}")
                Next

                'tolgo l'ultimo segnaposto
                Clausola = Replace(Clausola, ",{0}", "", , , CompareMethod.Text)
                Return Clausola
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Function WhereMesi() As String
        Try
            If mListaMesi.Count = 0 Then
                Return " 0=0 "
            Else
                Dim Clausola As String = " (Month(Sinistri.DataProtocollo) IN ({0})) "

                For Each e As Integer In mListaMesi
                    Clausola = String.Format(Clausola, e.ToString + ",{0}")
                Next

                'tolgo l'ultimo segnaposto
                Clausola = Replace(Clausola, ",{0}", "", , , CompareMethod.Text)
                Return Clausola
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Function WhereChiusura() As String
        Try
            Select Case mChiusura
                Case TipoChiusura.APERTI
                    Return " (Sinistri.StatoTecnico IN ('..','LP')) "
                Case TipoChiusura.CHIUSI
                    Return " (Sinistri.StatoTecnico IN ('LT','SS')) "
                Case Else
                    Return " 0=0 "
            End Select

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return " True "
        End Try
    End Function

    Private Function WhereCercaAttivita() As String
        Return String.Format("(m.Tipo = 'A') AND (m.Allarme BETWEEN #{0}# AND #{1}#) AND (m.IdNota <> m.CodiceFiscale)",
                             Format(mAttivitaDal, "MM/dd/yyyy"),
                             Format(mAttivitaAl, "MM/dd/yyyy"))
    End Function
End Class

Public Class ItemTipoChiusura

    Sub New(Descrizione As String,
            Tipo As QuerySinistri.TipoChiusura)
        mDescrizione = Descrizione
        mTipo = Tipo
    End Sub

    Private mDescrizione As String
    Public ReadOnly Property Descrizione() As String
        Get
            Return mDescrizione
        End Get
    End Property

    Private mTipo As QuerySinistri.TipoChiusura
    Public ReadOnly Property Tipo() As QuerySinistri.TipoChiusura
        Get
            Return mTipo
        End Get
    End Property
End Class

Public Class ItemTipoTabella

    Sub New(Descrizione As String,
            Tipo As QuerySinistri.TipoTabella)
        mDescrizione = Descrizione
        mTipo = Tipo
    End Sub

    Private mDescrizione As String
    Public ReadOnly Property Descrizione() As String
        Get
            Return mDescrizione
        End Get
    End Property

    Private mTipo As QuerySinistri.TipoTabella
    Public ReadOnly Property Tipo() As QuerySinistri.TipoTabella
        Get
            Return mTipo
        End Get
    End Property
End Class

Public Class ItemRicerca

    Sub New(Descrizione As String,
            TipoRicerca As QuerySinistri.CercaIn,
            Optional Valore As String = "",
            Optional DescrizioneBreve As String = "")
        mDescrizione = Descrizione
        mTipoRicerca = TipoRicerca
        mValore = Valore

        If DescrizioneBreve.Length = 0 Then
            mDescrizioneBreve = mDescrizione
        Else
            mDescrizioneBreve = DescrizioneBreve
        End If
    End Sub

    Private mDescrizione As String
    Public ReadOnly Property Descrizione() As String
        Get
            Return mDescrizione
        End Get
    End Property

    Private mDescrizioneBreve As String
    Public ReadOnly Property DescrizioneBreve() As String
        Get
            Return mDescrizioneBreve
        End Get
    End Property

    Private mTipoRicerca As QuerySinistri.CercaIn
    Public ReadOnly Property TipoRicerca() As QuerySinistri.CercaIn
        Get
            Return mTipoRicerca
        End Get
    End Property

    Private mValore As String
    Public Property Valore() As String
        Get
            Return mValore
        End Get
        Set(value As String)
            mValore = value
        End Set
    End Property
End Class
