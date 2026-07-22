'Enumerazioni
Public Enum GravitaEvidenza
    Normale = 1
End Enum
Public Enum TipoEvidenza
    Generica = 0
    RichiestaDocumenti = 1
    Compleanno = 2
    RinnovoPatente = 3
End Enum
Public Enum TipoOggetto
    Nessuno = 0
    Polizza = 1
    Cliente = 2
    Produttore = 3
    Veicolo = 4
End Enum

Public Class Anagrafica

    Private mCodiceFiscale As String

    Private mCliente As TClienti
    Private mSoggetto As TSoggetto
    Private mAbitazioni As TList(Of TAbitazione)
    Private mAttivitas As TList(Of TAttivita)
    Private mFinanzacose As TList(Of TFinanzaCose)
    Private mFinanzastrumenti As TList(Of TFinanzaStrumento)
    Private mNucleofamiliari As TList(Of TNucleoFamiliare)
    Private mPolizzeAltrui As TList(Of TPolizza)
    Private mAnalisiRca As TList(Of TAnalisiRca)
    Private mPolizzeNostre As TList(Of TPolizze)
    Private mPolizzeSocietari As TList(Of TPolizze)
    Private mSpesapiani As TList(Of TSpesaPiano)
    Private mHobbies As TList(Of THobby)
    Private mArretrati As TList(Of TArretrati)
    Private mDiari As TList(Of TDiario)
    Private mEvidenze As TList(Of TEvidenza)
    Private mFasiVendita As TList(Of TFasiVendita)
    Private mPianoCodici As List(Of TPianoCodici)
    Private mOpzioni As List(Of TOpzione)
    Private mElencoCodiciFiscaliFamiglia As String = Nothing

    Public Sub New()

    End Sub

    Public Sub New(CodiceFiscale As String)
        Load(CodiceFiscale)
    End Sub

    Public Function Load(CodiceFiscale As String) As Boolean
        mCodiceFiscale = CodiceFiscale

        mCliente = Nothing
        mSoggetto = Nothing
        mAbitazioni = Nothing
        mAttivitas = Nothing
        mFinanzacose = Nothing
        mFinanzastrumenti = Nothing
        mNucleofamiliari = Nothing
        mPolizzeAltrui = Nothing
        mAnalisiRca = Nothing
        mPolizzeNostre = Nothing
        mSpesapiani = Nothing
        mHobbies = Nothing
        mArretrati = Nothing
        mDiari = Nothing
        mEvidenze = Nothing
        mOpzioni = Nothing
        Return True
    End Function

    Public ReadOnly Property ElencoCodiciFiscaliFamiglia() As String
        Get
            If mElencoCodiciFiscaliFamiglia Is Nothing Then
                Dim cfs As String = ", " & Utx.FunzioniDb.TO_STRING(Me.CodiceFiscale)
                For Each familiare As TNucleoFamiliare In Me.Nucleofamiliari
                    If familiare.CodiceFiscaleFamiliare IsNot Nothing Then
                        cfs &= ", " & Utx.FunzioniDb.TO_STRING(familiare.CodiceFiscaleFamiliare)
                    End If
                Next
                mElencoCodiciFiscaliFamiglia = cfs.Substring(2)
            End If

            Return mElencoCodiciFiscaliFamiglia
        End Get
    End Property


    Public ReadOnly Property CodiceFiscale() As String
        Get
            Return mCodiceFiscale
        End Get
    End Property

    Public ReadOnly Property Soggetto() As TSoggetto
        Get
            If mSoggetto Is Nothing Then
                mSoggetto = New TSoggetto

                If mCodiceFiscale <> vbNullString Then
                    mSoggetto.LoadByKey(mCodiceFiscale)
                End If
            End If
            Return mSoggetto
        End Get
    End Property

    Public ReadOnly Property Cliente() As TClienti
        Get
            If mCliente Is Nothing Then
                mCliente = New TClienti

                If mCodiceFiscale <> vbNullString Then
                    mCliente.LoadByKey(mCodiceFiscale)
                End If
            End If

            Return mCliente
        End Get
    End Property


    Public ReadOnly Property Abitazioni() As TList(Of TAbitazione)
        Get
            If mAbitazioni Is Nothing Then
                With New BaseList(Of TAbitazione)
                    mAbitazioni = .GetList(mCodiceFiscale, "where CodiceFiscale = " & Utx.FunzioniDb.TO_STRING(mCodiceFiscale), 4)
                End With
                For Each abitazione As TAbitazione In mAbitazioni
                    abitazione.CodiceFiscale = mCodiceFiscale
                Next
            End If

            Return mAbitazioni
        End Get
    End Property

    Public ReadOnly Property Attivitas() As TList(Of TAttivita)
        Get
            If mAttivitas Is Nothing Then
                With New BaseList(Of TAttivita)
                    mAttivitas = .GetList(mCodiceFiscale, "where CodiceFiscale = " & Utx.FunzioniDb.TO_STRING(mCodiceFiscale), 2)
                End With
                For Each attivita As TAttivita In mAttivitas
                    attivita.CodiceFiscale = mCodiceFiscale
                Next
            End If

            Return mAttivitas
        End Get
    End Property

    Public ReadOnly Property Finanzacose() As TList(Of TFinanzaCose)
        Get
            Dim Finanzacosa As TFinanzaCose

            If mFinanzacose Is Nothing Then
                mFinanzacose = New TList(Of TFinanzaCose)

                If mCodiceFiscale <> vbNullString Then
                    Dim sql As String
                    sql = "SELECT TOP 6 a.CodServizio, a.DesServizio, " & Utx.FunzioniDb.TO_STRING(mCodiceFiscale) & "  AS CodiceFiscale, b.CodSoddisfazione"
                    sql = sql & " FROM Ana_FinanzaCoseTipo a LEFT JOIN"
                    sql = sql & " (SELECT * FROM Ana_FinanzaCose WHERE CodiceFiscale=" & Utx.FunzioniDb.TO_STRING(mCodiceFiscale) & ") b"
                    sql = sql & " ON a.CodServizio=b.CodServizio"
                    sql = sql & " Order by 1"

                    Dim rs As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(sql)
                    Do While rs.Read
                        Finanzacosa = New TFinanzaCose
                        If Finanzacosa.GetFields(rs) Then
                            mFinanzacose.Add(Finanzacosa)
                        End If
                        Finanzacosa = Nothing
                    Loop
                    rs.Close()
                    rs = Nothing
                End If
            End If

            Return mFinanzacose
        End Get
    End Property

    Public ReadOnly Property Finanzastrumenti() As TList(Of TFinanzaStrumento)
        Get
            If mFinanzastrumenti Is Nothing Then
                With New BaseList(Of TFinanzaStrumento)
                    mFinanzastrumenti = .GetList(mCodiceFiscale, "where CodiceFiscale = " & Utx.FunzioniDb.TO_STRING(mCodiceFiscale), 8)
                End With
                For Each finanzastrumento As TFinanzaStrumento In mFinanzastrumenti
                    finanzastrumento.CodiceFiscale = mCodiceFiscale
                Next
            End If

            Return mFinanzastrumenti
        End Get
    End Property

    Public ReadOnly Property Nucleofamiliari() As TList(Of TNucleoFamiliare)
        Get
            If mNucleofamiliari Is Nothing Then
                With New BaseList(Of TNucleoFamiliare)
                    mNucleofamiliari = .GetList(mCodiceFiscale, "WHERE CodiceFiscale = " & Utx.FunzioniDb.TO_STRING(mCodiceFiscale), 7)
                End With
                For Each nucleoFamiliare As TNucleoFamiliare In mNucleofamiliari
                    nucleoFamiliare.CodiceFiscale = mCodiceFiscale
                Next
                If mNucleofamiliari.IsNew() Then
                    Dim Query As String = String.Format("SELECT CodiceFiscale, TRIM(Cognome + ' ' + Nome) AS Nome, 
                        (YEAR(GETDATE()) - YEAR(DataNascita))  AS Eta 
                        FROM CLIENTI 
                        WHERE CodiceFiscale <> '{0}' AND CodiceFiscaleCF IN 
                            (SELECT CodiceFiscaleCF FROM CLIENTI WHERE NOT CodiceFiscaleCF IS NULL
                            AND TRIM(CodiceFiscaleCF) <> '' AND CodiceFiscale = '{0}')", mCodiceFiscale)

                    Dim rs As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query)
                    Dim Index = 0
                    Do While rs.Read And Index < mNucleofamiliari.Count
                        mNucleofamiliari(Index).CodiceFiscaleFamiliare = rs.GetValue(0)
                        mNucleofamiliari(Index).Nome = rs.GetValue(1)
                        If Not rs.IsDBNull(2) Then
                            mNucleofamiliari(Index).Eta = rs.GetValue(2)
                        End If
                        Index += 1
                    Loop
                    rs.Close()
                    rs = Nothing
                End If
            End If

            Return mNucleofamiliari
        End Get
    End Property

    Public ReadOnly Property PolizzeAltrui() As TList(Of TPolizza)
        Get
            If mPolizzeAltrui Is Nothing Then
                With New BaseList(Of TPolizza)
                    mPolizzeAltrui = .GetList(mCodiceFiscale, "where CodiceFiscale = " & Utx.FunzioniDb.TO_STRING(mCodiceFiscale), 8)
                End With
                For Each polizza As TPolizza In mPolizzeAltrui
                    polizza.CodiceFiscale = mCodiceFiscale
                Next
            End If

            Return mPolizzeAltrui
        End Get
    End Property

    Public ReadOnly Property AnalisiRca() As TList(Of TAnalisiRca)
        Get
            If mAnalisiRca Is Nothing Then
                With New BaseList(Of TAnalisiRca)
                    mAnalisiRca = .GetList(mCodiceFiscale, "WHERE CodiceFiscale = " & Utx.FunzioniDb.TO_STRING(mCodiceFiscale), 7)
                End With
                For Each polizzaRca As TAnalisiRca In mAnalisiRca
                    polizzaRca.CodiceFiscale = mCodiceFiscale
                Next

                If mAnalisiRca.IsNew() Then
                    With New TString
                        .add("SELECT ")
                        .add("   P.CodiceFiscale")     '0
                        .add(" , P.Polizza")           '1
                        .add(" , P.Convenzione")       '2
                        .add(" , P.DataScadenza")      '3
                        .add(" , P.Targa")             '4
                        .add(" , P.TotalePremioAnnuo") '5
                        .add(" , A.Marca")             '6
                        .add(" , A.Modello")           '7
                        .add(" , A.UniboxAurobox")     '8
                        .add(" , (year(GETDATE()) - year(DataNascita))  AS Eta") '9
                        .add(" , (Select MAX(S.DataSinistro) FROM SinistriDP AS S WHERE S.Polizza = P.Polizza) AS DataUltSx") '10
                        .add(" , A.Frazionamento")     '11
                        .add(" , A.PremioRataNetto")   '12
                        .add(" , M.RiparazioneFS")     '13
                        .add(" , M.PercFlexIF")        '14
                        .add(" , M.InMalus")           '15
                        .add(" , M.TotRataLordoOld")   '16
                        .add(" , M.TotRataLordoNew")   '17
                        .add(" , M.TipoVeicolo")       '18

                        .add("   FROM ((POLIZZE P")
                        .add("  INNER JOIN CLIENTI C")
                        .add("     ON P.CodiceFiscale = C.CodiceFiscale)")

                        .add("   LEFT JOIN AVVISI A")
                        .add("     ON P.Agenzia = A.Agenzia")
                        .add("    AND P.Ramo = A.Ramo")
                        .add("    AND P.Polizza = A.Polizza")
                        .add("    AND P.DataScadenza = A.EffettoRata)")
                        .add("   LEFT JOIN MonitorQT M")
                        .add("     ON P.Agenzia = M.Agenzia")
                        .add("    AND P.Polizza = M.Polizza")
                        .add(" WHERE P.RamoGestione = 1")
                        .add("   AND NOT P.IdStorno IS NULL")
                        .add("   AND P.DataScadenza > GETDATE()")
                        .add("   AND P.CodiceFiscale IN ({0})", Me.ElencoCodiciFiscaliFamiglia)
                        .add("   AND M.Effetto = (SELECT MAX(Effetto) ")
                        .add("                      FROM MonitorQT Q ")
                        .add("                     WHERE Q.Agenzia = M.Agenzia ")
                        .add("                       AND Q.Polizza = M.Polizza)")
                        .add("   ORDER BY P.DataScadenza")

                        Dim rs As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(.ToString)
                        Dim Index As Integer = 0
                        Do While rs.Read And Index < mAnalisiRca.Count
                            mAnalisiRca(Index).CodiceFiscale = rs.GetValue(0)
                            mAnalisiRca(Index).Polizza = rs.GetValue(1)
                            mAnalisiRca(Index).Convenzione = rs.GetValue(2)
                            mAnalisiRca(Index).DataScadenza = rs.GetValue(3)
                            mAnalisiRca(Index).Targa = rs.GetValue(4)
                            mAnalisiRca(Index).PremioOld = rs.GetValue(5)
                            If Not rs.IsDBNull(6) Then mAnalisiRca(Index).Marca = rs.GetValue(6)
                            If Not rs.IsDBNull(7) Then mAnalisiRca(Index).Modello = rs.GetValue(7)
                            'mAnalisiRca(Index).PremioNew = Nothing
                            If Not rs.IsDBNull(8) AndAlso rs.GetValue(8) = "S" Then
                                mAnalisiRca(Index).Unibox = "D"
                            ElseIf rs.GetValue(5) < 300 Then
                                mAnalisiRca(Index).Unibox = "A"
                            End If
                            If Not rs.IsDBNull(9) Then
                                If rs.GetValue(9) < 30 Or rs.GetValue(9) > 65 Then
                                    mAnalisiRca(Index).GuidaEsperta = "A"
                                End If
                            End If
                            'mAnalisiRca(Index).Finanziamento = ""
                            If Not rs.IsDBNull(10) Then
                                mAnalisiRca(Index).SinistroData = rs.GetValue(10)
                                mAnalisiRca(Index).SinistroSoN = "S"
                            End If
                            'If Not rs.IsDBNull(11) AndAlso rs.GetValue(11) = 1 Then
                            '    mAnalisiRca(Index).PremioNew = rs.GetValue(12)
                            'End If
                            If Not rs.IsDBNull(13) AndAlso rs.GetValue(13) = "S" Then
                                mAnalisiRca(Index).Riparazione = "D"
                            End If
                            If Not rs.IsDBNull(14) Then
                                mAnalisiRca(Index).FlexIncendioFurto = rs.GetValue(14)
                            End If
                            If Not rs.IsDBNull(15) Then
                                mAnalisiRca(Index).SinistroMalus = rs.GetValue(15)
                            End If
                            If Not rs.IsDBNull(16) Then
                                mAnalisiRca(Index).PremioOld = rs.GetValue(16)
                            End If
                            If Not rs.IsDBNull(17) Then
                                mAnalisiRca(Index).PremioNew = rs.GetValue(17)
                            End If
                            If Not rs.IsDBNull(18) Then
                                mAnalisiRca(Index).TipoVeicolo = rs.GetValue(18)
                            End If
                            Index += 1
                        Loop
                        rs.Close()
                        rs = Nothing
                    End With
                End If
            End If

            Return mAnalisiRca
        End Get
    End Property

    Public ReadOnly Property PolizzeNostre() As TList(Of TPolizze)
        Get
            If mPolizzeNostre Is Nothing Then
                Dim where As New TString
                With where
                    .add(" WHERE CodiceFiscale IN ({0})", Me.ElencoCodiciFiscaliFamiglia)
                End With
                With New BaseList(Of TPolizze)
                    mPolizzeNostre = .GetList(mCodiceFiscale, where.ToString)
                End With
                'For Each polizza As TPolizze In mPolizzeNostre
                'polizza.CodiceFiscale = mCodiceFiscale
                'Next
            End If

            Return mPolizzeNostre
        End Get
    End Property

    Public ReadOnly Property PolizzeSocietari() As TList(Of TPolizze)
        Get
            If mPolizzeSocietari Is Nothing Then
                With New BaseList(Of TPolizze)
                    mPolizzeSocietari = .GetList(mCodiceFiscale, "where CodiceFiscaleEA = " & Utx.FunzioniDb.TO_STRING(mCliente.CodiceFiscaleEA), 7)
                End With
                For Each polizza As TPolizze In mPolizzeSocietari
                    polizza.CodiceFiscale = mCodiceFiscale
                Next
            End If

            Return mPolizzeSocietari
        End Get
    End Property

    Public ReadOnly Property Spesapiani() As TList(Of TSpesaPiano)
        Get
            Dim Spesapiano As TSpesaPiano

            If mSpesapiani Is Nothing Then
                mSpesapiani = New TList(Of TSpesaPiano)

                If mCodiceFiscale <> vbNullString Then
                    Dim sql As String
                    sql = "SELECT a.idSpesa, a.Descrizione, a.Dettaglio, " & Utx.FunzioniDb.TO_STRING(mCodiceFiscale) & "  AS CodiceFiscale, b.SpesaImporto"
                    sql = sql & " FROM Ana_SpesaTipo a LEFT JOIN"
                    sql = sql & " (SELECT * FROM Ana_SpesaPiano WHERE CodiceFiscale=" & Utx.FunzioniDb.TO_STRING(mCodiceFiscale) & ") b"
                    sql = sql & " ON a.IdSpesa=b.IdSpesa "

                    Dim rs As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(sql)
                    Do While rs.Read
                        Spesapiano = New TSpesaPiano
                        If Spesapiano.GetFields(rs) Then
                            mSpesapiani.Add(Spesapiano)
                        End If

                        Spesapiano = Nothing
                    Loop
                    rs.Close()
                    rs = Nothing
                End If
            End If

            Return mSpesapiani
        End Get
    End Property

    Public ReadOnly Property Hobbies() As TList(Of THobby)
        Get
            If mHobbies Is Nothing Then
                With New BaseList(Of THobby)
                    mHobbies = .GetList(mCodiceFiscale, "where CodiceFiscale = " & Utx.FunzioniDb.TO_STRING(mCodiceFiscale), 4)
                End With
                For Each hobby As THobby In mHobbies
                    hobby.CodiceFiscale = mCodiceFiscale
                Next
            End If

            Return mHobbies
        End Get
    End Property

    Public ReadOnly Property Diari() As TList(Of TDiario)
        Get
            If mDiari Is Nothing Then
                With New BaseList(Of TDiario)
                    mDiari = .GetList(mCodiceFiscale, "where CodiceFiscale = " & Utx.FunzioniDb.TO_STRING(mCodiceFiscale))
                End With
            End If

            Return mDiari
        End Get
    End Property

    Public ReadOnly Property Evidenze() As TList(Of TEvidenza)
        Get
            If mEvidenze Is Nothing Then
                With New BaseList(Of TEvidenza)
                    mEvidenze = .GetList(mCodiceFiscale, "where CodiceFiscale = " & Utx.FunzioniDb.TO_STRING(mCodiceFiscale))
                End With
            End If

            Return mEvidenze
        End Get
    End Property

    Public ReadOnly Property Arretrati() As TList(Of TArretrati)
        Get
            If mArretrati Is Nothing Then
                With New BaseList(Of TArretrati)
                    mArretrati = .GetList(mCodiceFiscale, "where CodiceFiscale = " & Utx.FunzioniDb.TO_STRING(mCodiceFiscale), 7)
                End With
                For Each arretrato As TArretrati In mArretrati
                    arretrato.CodiceFiscale = mCodiceFiscale
                Next
            End If

            Return mArretrati
        End Get
    End Property

    Public ReadOnly Property FasiVendita() As TList(Of TFasiVendita)
        Get
            Dim faseVendita As TFasiVendita

            If mFasiVendita Is Nothing Then
                mFasiVendita = New TList(Of TFasiVendita)

                If mCodiceFiscale <> vbNullString Then
                    Dim sql As String
                    sql = "SELECT a.Codice as fase, a.Idioma, " & Utx.FunzioniDb.TO_STRING(mCodiceFiscale) & "  AS CodiceFiscale, b.Data, b.Utente"
                    sql = sql & " FROM (SELECT * FROM Ana_PianoCodici WHERE Tipologia = 'V') a"
                    sql = sql & " LEFT JOIN (SELECT * FROM Ana_FasiVendita WHERE CodiceFiscale=" & Utx.FunzioniDb.TO_STRING(mCodiceFiscale) & ") b"
                    sql = sql & "   ON a.Codice=b.fase"

                    Dim rs As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(sql)
                    Do While rs.Read
                        faseVendita = New TFasiVendita
                        If faseVendita.GetFields(rs) Then
                            mFasiVendita.Add(faseVendita)
                        End If

                        faseVendita = Nothing
                    Loop
                    rs.Close()
                    rs = Nothing
                End If
            End If

            Return mFasiVendita
        End Get
    End Property

    Public ReadOnly Property Opzioni() As TList(Of TOpzione)
        Get
            If mOpzioni Is Nothing Then
                With New BaseList(Of TOpzione)
                    mOpzioni = .GetList()
                End With
            End If

            Return mOpzioni
        End Get
    End Property

    Public ReadOnly Property PolizzeSituazione() As TList(Of TPolizza)
        Get
            Dim polizze As New TList(Of TPolizza)

            For Each polizzaNostra As TPolizze In PolizzeNostre
                If polizzaNostra.IsUpdated() Then
                    Dim polizza As New TPolizza With {
                        .CodiceFiscale = polizzaNostra.CodiceFiscale,
                        .Compagnia = "Unipol",
                        .DataScadenza = polizzaNostra.DataScadenza,
                        .DataDisdetta = polizzaNostra.DataStorno,
                        .Polizza = polizzaNostra.ToString,
                        .Targa = polizzaNostra.Targa}

                    If polizzaNostra.CodiceFiscaleCF <> "" Then
                        If polizzaNostra.CodiceFiscale <> polizzaNostra.CodiceFiscaleCF Then
                            polizza.Polizza &= "*"
                        End If
                    End If


                    If polizzaNostra.RamoGestione <= 2 Then
                        If polizzaNostra.SettoreTariffario = "5" Then
                            polizza.Sezione = "B" 'moto
                        Else
                            polizza.Sezione = "A" 'auto
                        End If
                    ElseIf polizzaNostra.CodiceProdotto.StartsWith("07") Then
                        polizza.Sezione = "C" 'casa
                    ElseIf polizzaNostra.CodiceProdotto.StartsWith("01") Then
                        polizza.Sezione = "D" 'infortuni
                    ElseIf Not polizzaNostra.CodiceProdotto.StartsWith("0") Then
                        If Not polizzaNostra.CodiceProdotto.StartsWith("P") Then
                            polizza.Sezione = "G" 'investimento
                        Else
                            polizza.Sezione = "F" 'risparmio
                        End If
                    Else
                        polizza.Sezione = "E" 'professione
                    End If

                    polizze.Add(polizza)
                End If
            Next

            polizze.AddRange(PolizzeAltrui)

            Return polizze
        End Get
    End Property


    Public ReadOnly Property PianoCodici() As TList(Of TPianoCodici)
        Get
            If mPianoCodici Is Nothing Then
                With New BaseList(Of TPianoCodici)
                    mPianoCodici = .GetList("", 0)
                End With
            End If

            Return mPianoCodici
        End Get
    End Property

    Public Function Save() As Boolean
        Soggetto.Save()
        Cliente.Save()
        Abitazioni.Save()
        Attivitas.Save()
        FasiVendita.Save()
        Finanzacose.Save()
        Finanzastrumenti.Save()
        Nucleofamiliari.Save()
        PolizzeAltrui.Save()
        AnalisiRca.Save()
        Spesapiani.Save()
        Hobbies.Save()
        Evidenze.Save()
        Opzioni.Save()
        Return True
    End Function

    Public Function IsModifiedState() As Boolean
        If Soggetto.IsModifiedState Then Return True
        If Cliente.IsModifiedState Then Return True
        If Abitazioni.IsModifiedState Then Return True
        If Attivitas.IsModifiedState Then Return True
        If FasiVendita.IsModifiedState Then Return True
        If Finanzacose.IsModifiedState Then Return True
        If Finanzastrumenti.IsModifiedState Then Return True
        If Nucleofamiliari.IsModifiedState Then Return True
        If PolizzeAltrui.IsModifiedState Then Return True
        If AnalisiRca.IsModifiedState Then Return True
        If Spesapiani.IsModifiedState Then Return True
        If Hobbies.IsModifiedState Then Return True
        If Evidenze.IsModifiedState Then Return True
        If Opzioni.IsModifiedState Then Return True
        Return False
    End Function

    Public Function IsNew() As Boolean
        If Not Soggetto.IsNew Then Return False
        If Not Cliente.IsNew Then Return False
        If Not Abitazioni.IsNew Then Return False
        If Not Attivitas.IsNew Then Return False
        If Not FasiVendita.IsNew Then Return False
        If Not Finanzacose.IsNew Then Return False
        If Not Finanzastrumenti.IsNew Then Return False
        If Not Nucleofamiliari.IsNew Then Return False
        If Not PolizzeAltrui.IsNew Then Return False
        If Not Spesapiani.IsNew Then Return False
        If Not Hobbies.IsNew Then Return False
        If Not Evidenze.IsNew Then Return False
        If Not Opzioni.IsNew Then Return False
        Return True
    End Function

    Public Function IsValid() As Boolean
        If Not Soggetto.IsValid Then Return False
        If Not Cliente.IsValid Then Return False
        If Not Abitazioni.IsValid Then Return False
        If Not Attivitas.IsValid Then Return False
        If Not FasiVendita.IsValid Then Return False
        If Not Finanzacose.IsValid Then Return False
        If Not Finanzastrumenti.IsValid Then Return False
        If Not Nucleofamiliari.IsValid Then Return False
        If Not PolizzeAltrui.IsValid Then Return False
        If Not Spesapiani.IsValid Then Return False
        If Not Hobbies.IsValid Then Return False
        If Not Evidenze.IsValid Then Return False
        If Not Opzioni.IsValid Then Return False
        Return True
    End Function
End Class
