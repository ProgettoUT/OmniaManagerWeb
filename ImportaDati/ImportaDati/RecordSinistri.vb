Option Compare Text

Public Class RecordSinistri

    Private mDic As New Dictionary(Of String, Object)
    Private mAndamentoSinistri As Boolean
    Private mDataFile As Date

    Sub New(ByVal DataFile As Date,
            Optional ByVal AndamentoSinistri As Boolean = False)

        mDataFile = DataFile
        mAndamentoSinistri = AndamentoSinistri

        If mAndamentoSinistri = True Then
            'nel dizionario andamenti molti campi sono impostati a "non importare"
            DizionarioAndamenti()
        Else
            DizionarioLiquido()

            Select Case DataFile

                Case Is <= #9/30/2012#
                    'ModificaDizionario2010()

                Case #10/1/2012# To #9/30/2014#
                    ModificaDizionario2012()
            End Select
        End If

    End Sub

    Private mTesto As String
    Public WriteOnly Property Testo() As String
        Set(ByVal value As String)
            mTesto = value

            'i file prima di questa data hanno il codice liquidatore di 3 cifre invece che 4. risolvo inserendo uno zero
            If mDataFile <= #9/30/2012# Then
                mTesto = mTesto.Insert(276, "0")
            End If
        End Set
    End Property

    Public Function FineSezione() As Boolean
        Return mTesto.StartsWith("INIZIO")
    End Function

    Public Function EstraiDatiSinistro(ByRef dt As DataTable) As Boolean

        Try
            'se non c'è il consenso per la figura richiesta esce
            'Attenzione: nel file sinistri nel campo <AgenziaMadre> c'è il codice della Figlia
            If FiguraRichiesta(Me.ValoreCampo("CodiceSubAgenteSima"),
                               Me.ValoreCampo("CodiceProduttoreSima"),
                               Me.ValoreCampo("AgenziaMadre")) = False Then
                Return True
            End If

            Dim dr As DataRow = dt.NewRow

            For Each kvp As KeyValuePair(Of String, Object) In mDic

                Select Case mDic(kvp.Key)(2)

                    Case FunzioniSinistri.Importazione.Importa

                        Try
                            Dim Campo As String = mTesto.Substring(mDic(kvp.Key)(0), mDic(kvp.Key)(1)).Trim

                            Select Case dt.Columns(kvp.Key).DataType.Name

                                Case "DateTime"
                                    If IsDate(Campo) AndAlso CDate(Campo) > #1/1/1900# Then
                                        dr(kvp.Key) = CDate(Campo)
                                    Else
                                        dr(kvp.Key) = DBNull.Value
                                    End If

                                Case "String"
                                    dr(kvp.Key) = Campo

                                Case Else
                                    If IsNumeric(Campo) Then
                                        dr(kvp.Key) = Campo
                                    Else
                                        dr(kvp.Key) = 0
                                    End If
                            End Select

                        Catch ex As ArgumentException
                            'se c'è un errore di conversione per un valore errato
                            Select Case dt.Columns(kvp.Key).DataType.Name

                                Case "DateTime"
                                    dr(kvp.Key) = DBNull.Value

                                Case "String"
                                    dr(kvp.Key) = ""

                                Case Else
                                    dr(kvp.Key) = 0
                            End Select

                        Catch ex As Exception
                            BoxErrore(ex)
                            Return False
                        End Try

                    Case FunzioniSinistri.Importazione.ValoreDefault

                        dr(kvp.Key) = mDic(kvp.Key)(1)

                    Case FunzioniSinistri.Importazione.Ignora
                        'non fare niente
                End Select
            Next kvp

            If mAndamentoSinistri = False Then
                ModificaStati(dr)
            End If

            dt.Rows.Add(dr)

            Return True

        Catch ex As Exception
            BoxErrore(ex)
            Return False
        End Try

    End Function

    Public Function ValoreCampo(ByVal Key As String) As String

        Try
            Return mTesto.Substring(mDic(Key)(0), mDic(Key)(1)).Trim

        Catch ex As Exception
            Return ""
        End Try

    End Function

    Private Sub ModificaDizionario2012()

        With mDic
            .Item("StatoTecnico") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
            .Item("DataStatoTecnico") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, DBNull.Value)
            .Item("EsercizioStatoTecnico") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, 0)
            .Item("StatoBilancistico") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
            .Item("DataStatoBilancistico") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, DBNull.Value)
            .Item("EsercizioStatoBilancistico") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, 0)
            .Item("StatoAmministrativo") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
            .Item("DataStatoAmministrativo") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, DBNull.Value)
            .Item("EsercizioStatoAmministrativo") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, 0)
            .Item("StatoRecupero") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
            .Item("DataStatoRecupero") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, DBNull.Value)
            .Item("EsercizioStatoRecupero") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, 0)
            .Item("StatoForfait") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
            .Item("DataStatoForfait") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, DBNull.Value)
            .Item("EsercizioStatoForfait") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, 0)
            .Item("CodicePerito") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
        End With

    End Sub

    Private Sub DizionarioLiquido()

        FunzioniSinistri.InitIdCampo()

        With mDic
            .Add("AnnoMeseCompetenza", FunzioniSinistri.IdCampo(10))
            .Add("EsercizioSinistro", FunzioniSinistri.IdCampo(4))
            'nota per agenzia sinistro:
            'nel tracciato della direzione c'è scritto 4 ma nei file c'è una colonna vuota fra agenziasinistro e ramosinistro
            .Add("AgenziaSinistro", FunzioniSinistri.IdCampo(5))
            .Add("RamoSinistro", FunzioniSinistri.IdCampo(3))
            .Add("NumeroSinistro", FunzioniSinistri.IdCampo(7))
            .Add("Ispettorato", FunzioniSinistri.IdCampo(5))
            .Add("AgenziaPolizza", FunzioniSinistri.IdCampo(5))
            .Add("RamoPolizza", FunzioniSinistri.IdCampo(3))
            .Add("Polizza", FunzioniSinistri.IdCampo(9))
            .Add("CodiceSubAgenteSima", FunzioniSinistri.IdCampo(4))
            .Add("CodiceProduttoreSima", FunzioniSinistri.IdCampo(4))
            .Add("DataSinistro", FunzioniSinistri.IdCampo(10))
            .Add("DataDenuncia", FunzioniSinistri.IdCampo(10))
            .Add("DataProtocollo", FunzioniSinistri.IdCampo(10))
            .Add("TipoCid", FunzioniSinistri.IdCampo(1))
            'il campo tipochiusura passato dal file di direzione, viene messo in codicechiusura
            'mentre TipoChiusura viene impostato a seconda del valore in CodiceChiusura
            .Add("CodiceChiusura", FunzioniSinistri.IdCampo(2))
            .Add("TipoSinistro", FunzioniSinistri.IdCampo(2))
            .Add("FlagCosePersone", FunzioniSinistri.IdCampo(1))
            .Add("NostraQuota", FunzioniSinistri.IdCampo(9))
            .Add("PrimoPreventivo", FunzioniSinistri.IdCampo(17))
            .Add("PagatoDel", FunzioniSinistri.IdCampo(17))
            .Add("PagatoAl", FunzioniSinistri.IdCampo(17))
            .Add("RecuperoDel", FunzioniSinistri.IdCampo(17))
            .Add("RecuperoAl", FunzioniSinistri.IdCampo(17))
            .Add("FranchigiaPtf", FunzioniSinistri.IdCampo(1))
            .Add("Convenzione", FunzioniSinistri.IdCampo(5))
            .Add("CodiceProdotto", FunzioniSinistri.IdCampo(5))
            .Add("CognomeAssicurato", FunzioniSinistri.IdCampo(20))
            .Add("NomeAssicurato", FunzioniSinistri.IdCampo(10))
            .Add("TargaAssicurato", FunzioniSinistri.IdCampo(9))
            .Add("CognomeDanneggiato", FunzioniSinistri.IdCampo(20))
            .Add("TargaDanneggiato", FunzioniSinistri.IdCampo(10))
            .Add("Compagnia", FunzioniSinistri.IdCampo(1))
            .Add("AgenziaPolizzaArrivo", FunzioniSinistri.IdCampo(5))
            .Add("CodiceLiquidatore", FunzioniSinistri.IdCampo(4))
            .Add("TipoDelega", FunzioniSinistri.IdCampo(1))
            .Add("CodiceFiscContrPol", FunzioniSinistri.IdCampo(16))
            .Add("DataUltPagam", FunzioniSinistri.IdCampo(10))
            .Add("DataDenCliente", FunzioniSinistri.IdCampo(10))
            .Add("CompControparte", FunzioniSinistri.IdCampo(5))
            .Add("TipoApplicativo", FunzioniSinistri.IdCampo(1))
            .Add("NrPosizioni", FunzioniSinistri.IdCampo(3))
            .Add("TipoApertura", FunzioniSinistri.IdCampo(1))
            .Add("Presentatore", FunzioniSinistri.IdCampo(1))
            .Add("Denunciante", FunzioniSinistri.IdCampo(1))
            .Add("IdCartella", FunzioniSinistri.IdCampo(9))
            .Add("CodProf", FunzioniSinistri.IdCampo(5))
            .Add("CarrozzProv", FunzioniSinistri.IdCampo(2))
            .Add("CarrozzCAnia", FunzioniSinistri.IdCampo(9))
            .Add("LegaleData", FunzioniSinistri.IdCampo(10))
            .Add("CarrozzPrior", FunzioniSinistri.IdCampo(2))
            .Add("Contatore", FunzioniSinistri.IdCampo(7))
            .Add("CardGest", FunzioniSinistri.IdCampo(7))
            .Add("CardDebito", FunzioniSinistri.IdCampo(7))
            .Add("CardNo", FunzioniSinistri.IdCampo(7))
            .Add("PagatoNoCardAl", FunzioniSinistri.IdCampo(17))
            .Add("PagatoNoCardDel", FunzioniSinistri.IdCampo(17))
            .Add("PagatoCardAl", FunzioniSinistri.IdCampo(17))
            .Add("PagatoCardDel", FunzioniSinistri.IdCampo(17))
            .Add("AgenziaMadre", FunzioniSinistri.IdCampo(5))
            .Add("DataApertura", FunzioniSinistri.IdCampo(10))
            .Add("FlagLegale", FunzioniSinistri.IdCampo(1))
            .Add("TipoDenuncia", FunzioniSinistri.IdCampo(1))
            .Add("Canalizzato", FunzioniSinistri.IdCampo(1))
            .Add("CodCarrPagato", FunzioniSinistri.IdCampo(7))
            .Add("CodCarrCanalizzato", FunzioniSinistri.IdCampo(9))
            .Add("PrevStat", FunzioniSinistri.IdCampo(16))
            .Add("SetTariffa", FunzioniSinistri.IdCampo(1))
            .Add("TipoRamo", FunzioniSinistri.IdCampo(5))
            .Add("Lesioni", FunzioniSinistri.IdCampo(3))
            .Add("Morti", FunzioniSinistri.IdCampo(3))
            .Add("Bar1A", FunzioniSinistri.IdCampo(2))
            .Add("Bar1B", FunzioniSinistri.IdCampo(2))
            .Add("Bar2A", FunzioniSinistri.IdCampo(2))
            .Add("Bar2B", FunzioniSinistri.IdCampo(2))
            .Add("Franchigie", FunzioniSinistri.IdCampo(17))
            .Add("Rivalse", FunzioniSinistri.IdCampo(17))
            .Add("AltroRecupero", FunzioniSinistri.IdCampo(17))
            .Add("FranchigieAl", FunzioniSinistri.IdCampo(17))
            .Add("FranchigieDel", FunzioniSinistri.IdCampo(17))
            .Add("RivalseAl", FunzioniSinistri.IdCampo(17))
            .Add("RivalseDel", FunzioniSinistri.IdCampo(17))
            .Add("AltroAl", FunzioniSinistri.IdCampo(17))
            .Add("AltroDel", FunzioniSinistri.IdCampo(17))
            .Add("SpeseAl", FunzioniSinistri.IdCampo(17))
            .Add("SpeseDel", FunzioniSinistri.IdCampo(17))
            .Add("Riserva", FunzioniSinistri.IdCampo(16))
            .Add("FLagRegContratto", FunzioniSinistri.IdCampo(1))
            .Add("FlagRegAmministrativa", FunzioniSinistri.IdCampo(1))
            .Add("ForCardDAl", FunzioniSinistri.IdCampo(17))
            .Add("ForCardDDel", FunzioniSinistri.IdCampo(17))
            .Add("ForCardGAl", FunzioniSinistri.IdCampo(17))
            .Add("ForCardGDel", FunzioniSinistri.IdCampo(17))
            .Add("ForCardDRiserva", FunzioniSinistri.IdCampo(17))
            .Add("ForCardGRiserva", FunzioniSinistri.IdCampo(17))
            .Add("RamoGestione", FunzioniSinistri.IdCampo(3))
            .Add("StatoBilancistico", FunzioniSinistri.IdCampo(20))
            .Add("DataStatoBilancistico", FunzioniSinistri.IdCampo(10))
            .Add("EsercizioStatoBilancistico", FunzioniSinistri.IdCampo(4))
            .Add("StatoTecnico", FunzioniSinistri.IdCampo(20))
            .Add("DataStatoTecnico", FunzioniSinistri.IdCampo(10))
            .Add("EsercizioStatoTecnico", FunzioniSinistri.IdCampo(4))
            .Add("StatoAmministrativo", FunzioniSinistri.IdCampo(20))
            .Add("DataStatoAmministrativo", FunzioniSinistri.IdCampo(10))
            .Add("EsercizioStatoAmministrativo", FunzioniSinistri.IdCampo(4))
            .Add("StatoRecupero", FunzioniSinistri.IdCampo(20))
            .Add("DataStatoRecupero", FunzioniSinistri.IdCampo(10))
            .Add("EsercizioStatoRecupero", FunzioniSinistri.IdCampo(4))
            .Add("StatoForfait", FunzioniSinistri.IdCampo(20))
            .Add("DataStatoForfait", FunzioniSinistri.IdCampo(10))
            .Add("EsercizioStatoForfait", FunzioniSinistri.IdCampo(4))
            .Add("CodicePerito", FunzioniSinistri.IdCampo(10))
        End With
    End Sub

    Private Sub DizionarioAndamenti()

        FunzioniSinistri.InitIdCampo()

        With mDic
            .Add("AnnoMeseCompetenza", FunzioniSinistri.IdCampo(10))
            .Add("EsercizioSinistro", FunzioniSinistri.IdCampo(4))
            .Add("AgenziaSinistro", FunzioniSinistri.IdCampo(5))
            .Add("RamoSinistro", FunzioniSinistri.IdCampo(3, FunzioniSinistri.Importazione.Ignora))
            .Add("NumeroSinistro", FunzioniSinistri.IdCampo(7))
            .Add("Ispettorato", FunzioniSinistri.IdCampo(5, FunzioniSinistri.Importazione.Ignora))
            .Add("AgenziaPolizza", FunzioniSinistri.IdCampo(5, FunzioniSinistri.Importazione.Ignora))
            .Add("RamoPolizza", FunzioniSinistri.IdCampo(3, FunzioniSinistri.Importazione.Ignora))
            .Add("Polizza", FunzioniSinistri.IdCampo(9, FunzioniSinistri.Importazione.Ignora))
            .Add("CodiceSubAgenteSima", FunzioniSinistri.IdCampo(4, FunzioniSinistri.Importazione.Ignora))
            .Add("CodiceProduttoreSima", FunzioniSinistri.IdCampo(4, FunzioniSinistri.Importazione.Ignora))
            .Add("DataSinistro", FunzioniSinistri.IdCampo(10, FunzioniSinistri.Importazione.Ignora))
            .Add("DataDenuncia", FunzioniSinistri.IdCampo(10, FunzioniSinistri.Importazione.Ignora))
            .Add("DataProtocollo", FunzioniSinistri.IdCampo(10, FunzioniSinistri.Importazione.Ignora))
            .Add("TipoCid", FunzioniSinistri.IdCampo(1))
            .Add("TipoChiusura", FunzioniSinistri.IdCampo(2))
            .Add("TipoSinistro", FunzioniSinistri.IdCampo(2, FunzioniSinistri.Importazione.Ignora))
            .Add("FlagCosePersone", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("NostraQuota", FunzioniSinistri.IdCampo(9, FunzioniSinistri.Importazione.Ignora))
            .Add("PrimoPreventivo", FunzioniSinistri.IdCampo(17))
            .Add("PagatoDel", FunzioniSinistri.IdCampo(17))
            .Add("PagatoAl", FunzioniSinistri.IdCampo(17))
            .Add("RecuperoDel", FunzioniSinistri.IdCampo(17))
            .Add("RecuperoAl", FunzioniSinistri.IdCampo(17))
            .Add("FranchigiaPtf", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("Convenzione", FunzioniSinistri.IdCampo(5, FunzioniSinistri.Importazione.Ignora))
            .Add("CodiceProdotto", FunzioniSinistri.IdCampo(5, FunzioniSinistri.Importazione.Ignora))
            .Add("CognomeAssicurato", FunzioniSinistri.IdCampo(20, FunzioniSinistri.Importazione.Ignora))
            .Add("NomeAssicurato", FunzioniSinistri.IdCampo(10, FunzioniSinistri.Importazione.Ignora))
            .Add("TargaAssicurato", FunzioniSinistri.IdCampo(9, FunzioniSinistri.Importazione.Ignora))
            .Add("CognomeDanneggiato", FunzioniSinistri.IdCampo(20, FunzioniSinistri.Importazione.Ignora))
            .Add("TargaDanneggiato", FunzioniSinistri.IdCampo(10, FunzioniSinistri.Importazione.Ignora))
            .Add("Compagnia", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("AgenziaPolizzaArrivo", FunzioniSinistri.IdCampo(5, FunzioniSinistri.Importazione.Ignora))
            .Add("CodiceLiquidatore", FunzioniSinistri.IdCampo(4, FunzioniSinistri.Importazione.Ignora))
            .Add("TipoDelega", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("CodiceFiscContrPol", FunzioniSinistri.IdCampo(16, FunzioniSinistri.Importazione.Ignora))
            .Add("DataUltPagam", FunzioniSinistri.IdCampo(10))
            .Add("DataDenCliente", FunzioniSinistri.IdCampo(10, FunzioniSinistri.Importazione.Ignora))
            .Add("CompControparte", FunzioniSinistri.IdCampo(5, FunzioniSinistri.Importazione.Ignora))
            .Add("TipoApplicativo", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("NrPosizioni", FunzioniSinistri.IdCampo(3))
            .Add("TipoApertura", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("Presentatore", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("Denunciante", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("IdCartella", FunzioniSinistri.IdCampo(9, FunzioniSinistri.Importazione.Ignora))
            .Add("CodProf", FunzioniSinistri.IdCampo(5, FunzioniSinistri.Importazione.Ignora))
            .Add("CarrozzProv", FunzioniSinistri.IdCampo(2, FunzioniSinistri.Importazione.Ignora))
            .Add("CarrozzCAnia", FunzioniSinistri.IdCampo(9, FunzioniSinistri.Importazione.Ignora))
            .Add("LegaleData", FunzioniSinistri.IdCampo(10, FunzioniSinistri.Importazione.Ignora))
            .Add("CarrozzPrior", FunzioniSinistri.IdCampo(2, FunzioniSinistri.Importazione.Ignora))
            .Add("Contatore", FunzioniSinistri.IdCampo(7, FunzioniSinistri.Importazione.Ignora))
            .Add("CardGest", FunzioniSinistri.IdCampo(7))
            .Add("CardDebito", FunzioniSinistri.IdCampo(7))
            .Add("CardNo", FunzioniSinistri.IdCampo(7))
            .Add("PagatoNoCardAl", FunzioniSinistri.IdCampo(17, FunzioniSinistri.Importazione.Ignora))
            .Add("PagatoNoCardDel", FunzioniSinistri.IdCampo(17, FunzioniSinistri.Importazione.Ignora))
            .Add("PagatoCardAl", FunzioniSinistri.IdCampo(17, FunzioniSinistri.Importazione.Ignora))
            .Add("PagatoCardDel", FunzioniSinistri.IdCampo(17, FunzioniSinistri.Importazione.Ignora))
            .Add("AgenziaMadre", FunzioniSinistri.IdCampo(5, FunzioniSinistri.Importazione.Ignora))
            .Add("DataApertura", FunzioniSinistri.IdCampo(10, FunzioniSinistri.Importazione.Ignora))
            .Add("FlagLegale", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("TipoDenuncia", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("Canalizzato", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("CodCarrPagato", FunzioniSinistri.IdCampo(7, FunzioniSinistri.Importazione.Ignora))
            .Add("CodCarrCanalizzato", FunzioniSinistri.IdCampo(9, FunzioniSinistri.Importazione.Ignora))
            .Add("PrevStat", FunzioniSinistri.IdCampo(16, FunzioniSinistri.Importazione.Ignora))
            .Add("SetTariffa", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("TipoRamo", FunzioniSinistri.IdCampo(5, FunzioniSinistri.Importazione.Ignora))
            .Add("Lesioni", FunzioniSinistri.IdCampo(3, FunzioniSinistri.Importazione.Ignora))
            .Add("Morti", FunzioniSinistri.IdCampo(3, FunzioniSinistri.Importazione.Ignora))
            .Add("Bar1A", FunzioniSinistri.IdCampo(2, FunzioniSinistri.Importazione.Ignora))
            .Add("Bar1B", FunzioniSinistri.IdCampo(2, FunzioniSinistri.Importazione.Ignora))
            .Add("Bar2A", FunzioniSinistri.IdCampo(2, FunzioniSinistri.Importazione.Ignora))
            .Add("Bar2B", FunzioniSinistri.IdCampo(2, FunzioniSinistri.Importazione.Ignora))
            .Add("Franchigie", FunzioniSinistri.IdCampo(17, FunzioniSinistri.Importazione.Ignora))
            .Add("Rivalse", FunzioniSinistri.IdCampo(17, FunzioniSinistri.Importazione.Ignora))
            .Add("AltroRecupero", FunzioniSinistri.IdCampo(17, FunzioniSinistri.Importazione.Ignora))
            .Add("FranchigieAl", FunzioniSinistri.IdCampo(17))
            .Add("FranchigieDel", FunzioniSinistri.IdCampo(17))
            .Add("RivalseAl", FunzioniSinistri.IdCampo(17))
            .Add("RivalseDel", FunzioniSinistri.IdCampo(17))
            .Add("AltroAl", FunzioniSinistri.IdCampo(17))
            .Add("AltroDel", FunzioniSinistri.IdCampo(17))
            .Add("SpeseAl", FunzioniSinistri.IdCampo(17))
            .Add("SpeseDel", FunzioniSinistri.IdCampo(17))
            .Add("Riserva", FunzioniSinistri.IdCampo(16))
            .Add("FLagRegContratto", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("FlagRegAmministrativa", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("ForCardDAl", FunzioniSinistri.IdCampo(17, FunzioniSinistri.Importazione.Ignora))
            .Add("ForCardDDel", FunzioniSinistri.IdCampo(17, FunzioniSinistri.Importazione.Ignora))
            .Add("ForCardGAl", FunzioniSinistri.IdCampo(17, FunzioniSinistri.Importazione.Ignora))
            .Add("ForCardGDel", FunzioniSinistri.IdCampo(17, FunzioniSinistri.Importazione.Ignora))
            .Add("ForCardDRiserva", FunzioniSinistri.IdCampo(17, FunzioniSinistri.Importazione.Ignora))
            .Add("ForCardGRiserva", FunzioniSinistri.IdCampo(17, FunzioniSinistri.Importazione.Ignora))
            .Add("RamoGestione", FunzioniSinistri.IdCampo(3, FunzioniSinistri.Importazione.Ignora))
            .Add("StatoTecnico", FunzioniSinistri.IdCampo(20, FunzioniSinistri.Importazione.Ignora))
            .Add("DataStatoTecnico", FunzioniSinistri.IdCampo(10, FunzioniSinistri.Importazione.Ignora))
            .Add("EsercizioStatoTecnico", FunzioniSinistri.IdCampo(4, FunzioniSinistri.Importazione.Ignora))
            .Add("StatoBilancistico", FunzioniSinistri.IdCampo(20, FunzioniSinistri.Importazione.Ignora))
            .Add("DataStatoBilancistico", FunzioniSinistri.IdCampo(10, FunzioniSinistri.Importazione.Ignora))
            .Add("EsercizioStatoBilancistico", FunzioniSinistri.IdCampo(4, FunzioniSinistri.Importazione.Ignora))
            .Add("StatoAmministrativo", FunzioniSinistri.IdCampo(20, FunzioniSinistri.Importazione.Ignora))
            .Add("DataStatoAmministrativo", FunzioniSinistri.IdCampo(10, FunzioniSinistri.Importazione.Ignora))
            .Add("EsercizioStatoAmministrativo", FunzioniSinistri.IdCampo(4, FunzioniSinistri.Importazione.Ignora))
            .Add("StatoRecupero", FunzioniSinistri.IdCampo(20, FunzioniSinistri.Importazione.Ignora))
            .Add("DataStatoRecupero", FunzioniSinistri.IdCampo(10, FunzioniSinistri.Importazione.Ignora))
            .Add("EsercizioStatoRecupero", FunzioniSinistri.IdCampo(4, FunzioniSinistri.Importazione.Ignora))
            .Add("StatoForfait", FunzioniSinistri.IdCampo(20, FunzioniSinistri.Importazione.Ignora))
            .Add("DataStatoForfait", FunzioniSinistri.IdCampo(10, FunzioniSinistri.Importazione.Ignora))
            .Add("EsercizioStatoForfait", FunzioniSinistri.IdCampo(4, FunzioniSinistri.Importazione.Ignora))
            .Add("CodicePerito", FunzioniSinistri.IdCampo(10, FunzioniSinistri.Importazione.Ignora))
        End With
    End Sub

    Private Sub ModificaStati(ByRef dr As DataRow)

        Try
            CodificaVecchioStato(dr)

            dr("StatoTecnico") = CodificaNuovoStato(dr("StatoTecnico"))
            dr("StatoBilancistico") = CodificaNuovoStato(dr("StatoBilancistico"))
            dr("StatoAmministrativo") = CodificaNuovoStato(dr("StatoAmministrativo"))
            dr("StatoRecupero") = CodificaNuovoStato(dr("StatoRecupero"))
            dr("StatoForfait") = CodificaNuovoStato(dr("StatoForfait"))

        Catch ex As Exception
            BoxErrore(ex)
        End Try

    End Sub

    Private Function CodificaNuovoStato(ByVal Stato As String)

        Select Case Stato

            Case "APERTO"
                Return ".."

            Case "LIQUIDATO_TOTALE"
                Return "LT"

            Case "LIQUIDATO_PARZIALE"
                Return "LP"

            Case "SENZA_SEGUITO"
                Return "SS"

            Case Else
                Return ""
        End Select

    End Function

    Private Sub CodificaVecchioStato(ByRef dr As DataRow)

        'codici di chiusura originali---------------------------------------------------
        '00 oppure blank = sinistro aperto
        '02 = Chiuso Liquidato Totalmente
        '03 = Chiuso Senza Seguito
        '04 = Chiuso con parcella in sospeso
        '05 = Chiuso con recupero in sospeso
        '08 = Parcella pagata nell’esercizio successivo a quello di chiusura del sinistro (ex 04)
        '09 = Recupero avvenuto in un esercizio successivo a quello di chiusura del sinistro (ex 05)
        '--------------------------------------------------------------------------------------------

        Try
            If IsNumeric(dr("CodiceChiusura")) Then

                Select Case Val(dr("CodiceChiusura"))

                    Case 2, Is > 3
                        dr("TipoChiusura") = "LT"

                    Case 3
                        dr("TipoChiusura") = "SS"

                    Case Else
                        dr("TipoChiusura") = ".."
                End Select
            Else
                dr("TipoChiusura") = ".."
            End If

            'modifica SS in LT se il costo è diverso da zero (ci sono dei casi con più posizioni)
            If dr("CodiceChiusura") = "SS" AndAlso dr("PagatoAl") <> 0 Then
                dr("TipoChiusura") = "LT"
            End If

        Catch ex As Exception
            dr("TipoChiusura") = "??"
        End Try

    End Sub

End Class

Public Class RecordIncarichi

    Private mDic As New Dictionary(Of String, Object)

    Sub New(ByVal DataFile As Date)

        FunzioniSinistri.InitIdCampo()

        DizionarioLiquido()

        Select Case DataFile

            Case Is <= #9/30/2012#
                'ModificaDizionario2010()

            Case #10/1/2012# To #9/30/2014#
                ModificaDizionario2012()
        End Select

    End Sub

    Private mTesto As String
    Public WriteOnly Property Testo() As String
        Set(ByVal value As String)
            mTesto = value
        End Set
    End Property

    Public Function FineSezione() As Boolean
        Return mTesto.StartsWith("FINE")
    End Function

    Public Function EstraiDatiIncarico(ByRef dt As DataTable) As Boolean

        Try
            Dim dr As DataRow = dt.NewRow

            For Each kvp As KeyValuePair(Of String, Object) In mDic

                Select Case mDic(kvp.Key)(2)

                    Case FunzioniSinistri.Importazione.Importa
                        Try
                            Dim Campo As String = mTesto.Substring(mDic(kvp.Key)(0), mDic(kvp.Key)(1)).Trim

                            Select Case dt.Columns(kvp.Key).DataType.Name

                                Case "DateTime"
                                    If IsDate(Campo) AndAlso CDate(Campo) > #1/1/1900# Then
                                        dr(kvp.Key) = CDate(Campo)
                                    Else
                                        dr(kvp.Key) = DBNull.Value
                                    End If

                                Case "String"
                                    dr(kvp.Key) = Campo

                                Case Else
                                    If IsNumeric(Campo) Then
                                        dr(kvp.Key) = Campo
                                    Else
                                        dr(kvp.Key) = 0
                                    End If
                            End Select

                        Catch ex As ArgumentException
                            'se c'è un errore di conversione per un valore errato
                            Select Case dt.Columns(kvp.Key).DataType.Name

                                Case "DateTime"
                                    dr(kvp.Key) = DBNull.Value

                                Case "String"
                                    dr(kvp.Key) = ""

                                Case Else
                                    dr(kvp.Key) = 0
                            End Select

                        Catch ex As Exception
                            BoxErrore(ex)
                            Return False
                        End Try

                    Case FunzioniSinistri.Importazione.ValoreDefault
                        dr(kvp.Key) = mDic(kvp.Key)(1)

                    Case FunzioniSinistri.Importazione.Ignora
                End Select
            Next kvp

            dt.Rows.Add(dr)

            Return True

        Catch ex As Exception
            BoxErrore(ex)
            Return False
        End Try

    End Function

    Private Sub ModificaDizionario2012()

        With mDic
            .Item("CodicePeritoSAP") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
            .Item("TipoIncaricoCC") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
            .Item("TipoSpecializzazione") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
            .Item("TipoFiduciario") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
            .Item("StatoIncarico") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
            .Item("StatoIncaricoCarrozzeria") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
            .Item("EsitoPerizia") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
        End With

    End Sub

    Private Sub DizionarioLiquido()

        FunzioniSinistri.InitIdCampo()

        With mDic
            .Add("TipoRecord", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("DataCompetenza", FunzioniSinistri.IdCampo(10))
            .Add("AgenziaArrivoPolizza", FunzioniSinistri.IdCampo(5, FunzioniSinistri.Importazione.Ignora))
            .Add("AgenziaPolizza", FunzioniSinistri.IdCampo(5, FunzioniSinistri.Importazione.Ignora))
            .Add("EsercizioSinistro", FunzioniSinistri.IdCampo(4))
            .Add("AgenziaSinistro", FunzioniSinistri.IdCampo(4))
            .Add("NumeroSinistro", FunzioniSinistri.IdCampo(7))
            .Add("Posizione", FunzioniSinistri.IdCampo(3))
            .Add("CFDanneggiato", FunzioniSinistri.IdCampo(16))
            .Add("Cognome", FunzioniSinistri.IdCampo(40))
            .Add("Nome", FunzioniSinistri.IdCampo(40))
            .Add("CodicePerito", FunzioniSinistri.IdCampo(7))
            .Add("ProfessionePerito", FunzioniSinistri.IdCampo(3))
            .Add("DataIncarico", FunzioniSinistri.IdCampo(10))
            .Add("TipoIncarico", FunzioniSinistri.IdCampo(2))
            .Add("DataRestituzione", FunzioniSinistri.IdCampo(10))
            .Add("TipoRestituzione", FunzioniSinistri.IdCampo(2))
            .Add("AgenziaMadre", FunzioniSinistri.IdCampo(5, FunzioniSinistri.Importazione.Ignora))
            .Add("CodicePeritoSAP", FunzioniSinistri.IdCampo(10))
            .Add("TipoIncaricoCC", FunzioniSinistri.IdCampo(30))
            .Add("TipoSpecializzazione", FunzioniSinistri.IdCampo(50))
            .Add("TipoFiduciario", FunzioniSinistri.IdCampo(50))
            .Add("StatoIncarico", FunzioniSinistri.IdCampo(50))
            .Add("StatoIncaricoCarrozzeria", FunzioniSinistri.IdCampo(50))
            .Add("EsitoPerizia", FunzioniSinistri.IdCampo(30))
        End With
    End Sub

End Class

Public Class RecordPagamenti

    Private mDic As New Dictionary(Of String, Object)

    Sub New(ByVal DataFile As Date)

        DizionarioLiquido()

        Select Case DataFile

            Case Is <= #9/30/2012#
                'ModificaDizionario2010()

            Case #10/1/2012# To #9/30/2014#
                'ModificaDizionario2012()
        End Select

    End Sub

    Private mTesto As String
    Public WriteOnly Property Testo() As String
        Set(ByVal value As String)
            mTesto = value
        End Set
    End Property

    Public Function FineSezione() As Boolean
        Return mTesto.StartsWith("FINE")
    End Function

    Public Function EstraiDatiPagamento(ByRef dt As DataTable) As Boolean

        Try
            Dim dr As DataRow = dt.NewRow

            For Each kvp As KeyValuePair(Of String, Object) In mDic

                Select Case mDic(kvp.Key)(2)

                    Case FunzioniSinistri.Importazione.Importa
                        Try
                            Dim Campo As String = mTesto.Substring(mDic(kvp.Key)(0), mDic(kvp.Key)(1)).Trim

                            Select Case dt.Columns(kvp.Key).DataType.Name

                                Case "DateTime"
                                    If IsDate(Campo) AndAlso CDate(Campo) > #1/1/1900# Then
                                        dr(kvp.Key) = CDate(Campo)
                                    Else
                                        dr(kvp.Key) = DBNull.Value
                                    End If

                                Case "String"
                                    dr(kvp.Key) = Campo

                                Case Else
                                    If IsNumeric(Campo) Then
                                        dr(kvp.Key) = Campo
                                    Else
                                        dr(kvp.Key) = 0
                                    End If
                            End Select

                        Catch ex As ArgumentException
                            'se c'è un errore di conversione per un valore errato
                            Select Case dt.Columns(kvp.Key).DataType.Name

                                Case "DateTime"
                                    dr(kvp.Key) = DBNull.Value

                                Case "String"
                                    dr(kvp.Key) = ""

                                Case Else
                                    dr(kvp.Key) = 0
                            End Select

                        Catch ex As Exception
                            BoxErrore(ex)
                            Return False
                        End Try

                    Case FunzioniSinistri.Importazione.ValoreDefault
                        dr(kvp.Key) = mDic(kvp.Key)(1)

                    Case FunzioniSinistri.Importazione.Ignora
                End Select
            Next kvp

            dt.Rows.Add(dr)

            Return True

        Catch ex As Exception
            BoxErrore(ex)
            Return False
        End Try

    End Function

    Private Sub DizionarioLiquido()

        FunzioniSinistri.InitIdCampo()

        With mDic
            .Add("TipoRecord", FunzioniSinistri.IdCampo(1, FunzioniSinistri.Importazione.Ignora))
            .Add("DataCompetenza", FunzioniSinistri.IdCampo(10))
            .Add("AgenziaArrivoPolizza", FunzioniSinistri.IdCampo(5, FunzioniSinistri.Importazione.Ignora))
            .Add("AgenziaPolizza", FunzioniSinistri.IdCampo(5, FunzioniSinistri.Importazione.Ignora))
            .Add("EsercizioSinistro", FunzioniSinistri.IdCampo(4))
            .Add("AgenziaSinistro", FunzioniSinistri.IdCampo(4))
            .Add("NumeroSinistro", FunzioniSinistri.IdCampo(7))
            .Add("Posizione", FunzioniSinistri.IdCampo(3))
            .Add("CFDanneggiato", FunzioniSinistri.IdCampo(16))
            .Add("Cognome", FunzioniSinistri.IdCampo(40))
            .Add("Nome", FunzioniSinistri.IdCampo(40))
            .Add("Tipo", FunzioniSinistri.IdCampo(2))
            .Add("Forma", FunzioniSinistri.IdCampo(2))
            .Add("Data", FunzioniSinistri.IdCampo(10))
            .Add("Assegno", FunzioniSinistri.IdCampo(15))
            .Add("Importo", FunzioniSinistri.IdCampo(16))
        End With

    End Sub

End Class

Public Class RecordPeriti

    Private mDic As New Dictionary(Of String, Object)

    Sub New(ByVal DataFile As Date)

        DizionarioLiquido()

        Select Case DataFile

            Case Is <= #9/30/2012#
                ModificaDizionario2010()

            Case #10/1/2012# To #9/30/2014#
                ModificaDizionario2012()
        End Select

    End Sub

    Private mTesto As String
    Public Property Testo() As String
        Get
            Return mTesto
        End Get
        Set(ByVal value As String)
            mTesto = value
        End Set
    End Property

    Public Function FineSezione() As Boolean
        Return mTesto.StartsWith("FINE")
    End Function

    Public Function EstraiDatiPerito(ByRef dt As DataTable) As Boolean

        Try
            Dim dr As DataRow = dt.NewRow

            For Each kvp As KeyValuePair(Of String, Object) In mDic

                Select Case mDic(kvp.Key)(2)

                    Case FunzioniSinistri.Importazione.Importa
                        Try
                            Dim Campo As String = mTesto.Substring(mDic(kvp.Key)(0), mDic(kvp.Key)(1)).Trim

                            Select Case dt.Columns(kvp.Key).DataType.Name

                                'ci sono solo campi numerici e testo
                                Case "String"
                                    dr(kvp.Key) = Campo

                                Case Else
                                    If IsNumeric(Campo) Then
                                        dr(kvp.Key) = Campo
                                    Else
                                        dr(kvp.Key) = 0
                                    End If
                            End Select

                        Catch ex As ArgumentException
                            'se c'è un errore di conversione per un valore errato
                            Select Case dt.Columns(kvp.Key).DataType.Name

                                Case "String"
                                    dr(kvp.Key) = ""

                                Case Else
                                    dr(kvp.Key) = 0
                            End Select

                        Catch ex As Exception
                            BoxErrore(ex)
                            Return False
                        End Try

                    Case FunzioniSinistri.Importazione.ValoreDefault
                        dr(kvp.Key) = mDic(kvp.Key)(1)

                    Case FunzioniSinistri.Importazione.Ignora
                End Select
            Next kvp

            dt.Rows.Add(dr)

            Return True

        Catch ex As Exception
            BoxErrore(ex)
            Return False
        End Try

    End Function

    Private Sub ModificaDizionario2010()
        mDic.Item("IdPeritoSAP") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
    End Sub

    Private Sub ModificaDizionario2012()
        mDic.Item("IdPeritoSAP") = FunzioniSinistri.IdCampo(0, FunzioniSinistri.Importazione.ValoreDefault, "")
    End Sub

    Private Sub DizionarioLiquido()

        FunzioniSinistri.InitIdCampo()

        With mDic
            .Add("IdPerito", FunzioniSinistri.IdCampo(5))
            .Add("Tipo", FunzioniSinistri.IdCampo(1))
            .Add("Cognome", FunzioniSinistri.IdCampo(45))
            .Add("Nome", FunzioniSinistri.IdCampo(15))
            .Add("CodiceFiscale", FunzioniSinistri.IdCampo(16))
            .Add("Telefono", FunzioniSinistri.IdCampo(15))
            .Add("Cellulare", FunzioniSinistri.IdCampo(15))
            .Add("Email", FunzioniSinistri.IdCampo(50))
            .Add("IdPeritoSAP", FunzioniSinistri.IdCampo(10))
        End With
    End Sub

End Class

Public Class FunzioniSinistri

    'i campi possono essere:
    '0.presenti nel file origine e da importare
    '1.non presenti nel file origine e da impostare al valore di default nel Db
    '2.presenti nel file origine e non presenti nel Db e quindi da ignorare
    Public Enum Importazione
        Importa = 0
        ValoreDefault = 1
        Ignora = 2
    End Enum

    'puntatore alla posizione iniziale del campo nella stringa. utilizzato da IdCampo
    Private Shared PosizioneCampo As Integer

    Public Shared Sub InitIdCampo()
        PosizioneCampo = 0
    End Sub

    Public Shared Function IdCampo(ByVal Lunghezza As Integer,
                                   Optional ByVal Importa As FunzioniSinistri.Importazione = FunzioniSinistri.Importazione.Importa,
                                   Optional ByVal ValoreDefault As Object = Nothing) As Array

        Select Case Importa

            Case Importazione.Importa
                IdCampo = {PosizioneCampo, Lunghezza, Importa}

            Case Importazione.ValoreDefault
                IdCampo = {0, ValoreDefault, Importa}

            Case Else 'ignora
                IdCampo = {0, Nothing, Importa}
        End Select

        'avanzo alla posizione di inizio del campo successivo
        PosizioneCampo += Lunghezza

    End Function

    Public Shared Function AssegnaParametriCommand(ByVal StoredQuery As String,
                                                   ByRef dt As DataTable) As OleDb.OleDbCommand

        Dim cmd As New OleDb.OleDbCommand

        cmd.Connection = cnArrivi
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = StoredQuery

        cmd.Parameters.Clear()

        'è necessario assegnare esplicitamente dove deve recuperare i valori
        For k As Integer = 0 To dt.Columns.Count - 1
            cmd.Parameters.AddWithValue(k.ToString, dt).SourceColumn = dt.Columns(k).ColumnName
        Next

        Return cmd

    End Function

End Class
