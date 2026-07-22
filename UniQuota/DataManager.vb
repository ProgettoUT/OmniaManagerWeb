Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization


Public Class DataManager

    Public Shared Function LoadPreventivo() As Prodotto
        Dim f As New OpenFileDialog
        With f
            .DefaultExt = "up"
            .Filter = "Preventivo (*.up)|*.up"
            .Title = "Apri preventivo"
            .InitialDirectory = CARTELLA_PREVENTIVI
            .ShowDialog()
            If .FileName <> vbNullString Then
                Return LoadPreventivo(.FileName)
            End If
            .Dispose()
        End With

        Return Nothing
    End Function

    Public Shared Function CheckPreventivo(ByVal filename As String) As Prodotto
        Dim prodotto As Prodotto = Nothing

        Dim fs As FileStream = File.Open(filename, FileMode.Open)
        Dim bf As New BinaryFormatter()
        prodotto = CType(bf.Deserialize(fs), Prodotto)
        fs.Close()
        prodotto.NomeFile = filename
        prodotto.New2()

        Return prodotto
    End Function

    Public Shared Function LoadPreventivo(ByVal filename As String) As Prodotto
        Dim prodotto As Prodotto = Nothing
        Try

            If File.Exists(filename) Then
                Dim fs As FileStream = File.Open(filename, FileMode.Open)
                Dim bf As New BinaryFormatter()
                prodotto = CType(bf.Deserialize(fs), Prodotto)
                fs.Close()
                prodotto.NomeFile = filename
                prodotto.New2()
            End If
        Catch e1 As ArgumentException
            MsgBox("Il preventivo non è più compatibile con il nuovo prodotto. Eliminare e crearne un'altro.", MsgBoxStyle.Critical)
        Catch ex As Exception
            MsgBox("Errore nell'apertura del preventivo: " & ex.Message, MsgBoxStyle.Critical)
        End Try

        Return prodotto
    End Function

    Public Shared Function SalvaPreventivo(ByRef preventivo As Prodotto) As Boolean
        Try
            Dim filename As String

            Directory.CreateDirectory(DataManager.CartellaPreventivo(preventivo.Cliente.CodiceFiscale))

            If preventivo.Cliente.CodiceFiscale = vbNullString Then
                filename = InputBox("Inserisci una descrizione sintetica del preventivo", "Quotatore")
                If filename = vbNullString Then Exit Function
            Else
                filename = preventivo.Cliente.CodiceFiscale
            End If

            preventivo.NomeFile = Path.Combine(DataManager.CartellaPreventivo(preventivo.Cliente.CodiceFiscale), filename & "_" & preventivo.CodiceProdotto & "_" & Date.Now.Ticks & ".up")

            Dim fs As FileStream = File.Open(preventivo.NomeFile, FileMode.Create)
            Dim bf As New BinaryFormatter()
            bf.Serialize(fs, preventivo)
            fs.Close()

            'Dim f As New SaveFileDialog
            'With f
            '    .AddExtension = True
            '    .DefaultExt = "up"
            '    .Filter = "Preventivo (*.up)|*.up"
            '    .Title = "Salva preventivo"
            '    .InitialDirectory = DataManager.CartellaPreventivo(preventivo.Cliente.CodiceFiscale)
            '    .FileName = Path.GetFileNameWithoutExtension(preventivo.NomeFile)
            '    .ShowDialog()
            '    If .FileName.EndsWith(".up") Then
            '        preventivo.NomeFile = .FileName
            '        Dim fs As FileStream = .OpenFile
            '        Dim bf As New BinaryFormatter()
            '        bf.Serialize(fs, preventivo)
            '        fs.Close()
            '    End If
            '    .Dispose()
            'End With
        Catch ex As Exception
            MsgBox("Errore nel salvataggio del preventivo: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try

        MsgBox("Preventivo salvato correttamene.", MsgBoxStyle.Information)
        Return True
    End Function

    Public Shared Function CartellaPreventivo(ByRef codiceFiscale As String) As String

        If Trim(codiceFiscale) = vbNullString Then
            CartellaPreventivo = Path.Combine(CARTELLA_PREVENTIVI, "DACATALOGARE")
        Else
            CartellaPreventivo = Path.Combine(CARTELLA_PREVENTIVI, UCase(codiceFiscale))
        End If

    End Function

    Public Shared Function DeletePreventivo(ByVal filename As String) As Boolean
        Try
            If File.Exists(filename) Then
                File.Delete(filename)
                DeletePreventivo = True
            End If
            If Directory.GetFiles(Path.GetDirectoryName(filename)).Length = 0 Then
                Directory.Delete(Path.GetDirectoryName(filename))
            End If
        Catch ex As Exception
        End Try
    End Function


#Region "serialize"

    'Dim props As New Dictionary(Of Integer, String)
    'With preventivo
    '    props.Add(10000, 1) 'PROGRESSIVO

    '    'Caratteristiche prodotto
    '    props.Add(10001, .CodiceRamoPolizza)
    '    props.Add(10002, .CodiceProdotto)
    '    props.Add(10003, .DescrizioneProdotto)
    '    props.Add(10004, .DurataContrattualeMinimaInAnni)
    '    props.Add(10005, .DurataContrattualeMassimaInAnni)
    '    props.Add(10006, .PeriodoMoraInGiorni)
    '    props.Add(10007, .EmissioneAppendici)
    '    props.Add(10008, .TacitoRinnovo)
    '    props.Add(10009, .ContraenzaPersonaFisica)
    '    props.Add(10010, .ContraenzaPersonaGiuridica)
    '    props.Add(10011, .PremioMinimoRata)

    '    props.Add(10100, .AliquotaImpostaAssistenza)
    '    props.Add(10101, .AliquotaImpostaFurto)
    '    props.Add(10102, .AliquotaImpostaIncendio)
    '    props.Add(10103, .AliquotaImpostaResponsabilitaCivile)
    '    props.Add(10104, .AliquotaImpostaTutelaLegale)

    '    props.Add(10200, .Durata)
    '    props.Add(10201, .Frazionamento)
    '    props.Add(10202, .Indicizzazione)
    '    props.Add(10203, .Premio)
    '    props.Add(10204, .Sconto)
    '    props.Add(10205, .Flex)
    '    props.Add(10206, .Interessi)
    '    props.Add(10207, .Tasse)
    '    props.Add(10208, .PremioRata)
    'End With

    'With preventivo.Agenzia
    '    props.Add(11000, .Codice)
    '    props.Add(11001, .Denominazione)
    '    props.Add(11002, .Indirizzo)
    '    props.Add(11003, .Cap)
    '    props.Add(11004, .Localita)
    '    props.Add(11005, .Provincia)
    '    props.Add(11006, .Telefono)
    '    props.Add(11007, .Email)
    '    props.Add(11008, .NumeroIscrizioneIsvap)
    'End With
    'With preventivo.Intermediario
    '    props.Add(12000, .Cognome)
    '    props.Add(12001, .Nome)
    '    props.Add(12002, .NumeroIscrizioneIsvap)
    'End With
    'With preventivo.Cliente
    '    props.Add(13000, .Nominativo)
    '    props.Add(13001, .Indirizzo)
    '    props.Add(13002, .Cap)
    '    props.Add(13003, .Localita)
    '    props.Add(13004, .Provincia)
    '    props.Add(13005, .Telefono)
    '    props.Add(13006, .Email)
    'End With

    'If TypeOf preventivo Is Protetto Then
    '    Dim protetto As Protetto = CType(preventivo, Protetto)
    '    With protetto
    '        ' SezioneAssistenza
    '        props.Add(14000, .SezioneAssistenza.CombinazioneCopertura)
    '        props.Add(14001, .CoperturaAssistenza.Stato)

    '        'tutela legale
    '        props.Add(14002, .SezioneTutelaLegale.CombinazioneCopertura)
    '        props.Add(14003, .CoperturaTutelaLegale.Stato)
    '        props.Add(14004, .PartitaTutelaLegale.SommaAssicurata)

    '        'rc
    '        props.Add(14005, .SezioneResponsabilitaCivile.CombinazioneCopertura)
    '        props.Add(14006, .CoperturaResponsabilitaCivile.Stato)
    '        props.Add(14007, .PartitaResponsabilitaCivile.SommaAssicurata)
    '        props.Add(14008, .CoperturaResponsabilitaCivileAggiuntiva.Stato)
    '        props.Add(14009, "Note")

    '        props.Add(14010, .SezioneIncendio.CombinazioneCopertura)
    '        props.Add(14011, .SezioneFurto.CombinazioneCopertura)

    '        Dim i As Integer = 0
    '        For Each Abitazione As Abitazione In .Abitazioni
    '            With Abitazione
    '                'Abitazione
    '                props.Add(i + 14051, .TipoAbitazione)
    '                props.Add(i + 14052, .ClassificazioneTerritoriale)
    '                props.Add(i + 14053, "Descrizione")
    '                props.Add(i + 14054, "Provincia")
    '                props.Add(i + 14055, "Note")

    '                props.Add(i + 14056, .CoperturaIncendio.Stato)
    '                props.Add(i + 14057, .CoperturaIncendioBase(.PartitaAbitazione).Stato)
    '                props.Add(i + 14058, .PartitaAbitazione.SommaAssicurata)
    '                props.Add(i + 14059, .PartitaAbitazione.FormaDiAssicurazione)

    '                props.Add(i + 14060, .CoperturaIncendioBase(.PartitaRischioLocativo).Stato)
    '                props.Add(i + 14061, .PartitaRischioLocativo.SommaAssicurata)
    '                props.Add(i + 14062, .PartitaRischioLocativo.FormaDiAssicurazione)

    '                props.Add(i + 14063, .CoperturaIncendioBase(.PartitaContenuto).Stato)
    '                props.Add(i + 14064, .PartitaContenuto.SommaAssicurata)
    '                props.Add(i + 14065, .PartitaContenuto.FormaDiAssicurazione)

    '                props.Add(i + 14066, .CoperturaIncendioBase(.PartitaRicorsoTerzi).Stato)
    '                props.Add(i + 14067, .PartitaRicorsoTerzi.SommaAssicurata)
    '                props.Add(i + 14068, .CoperturaIncendioBase(.PartitaDanniElettriciElettronici).Stato)
    '                props.Add(i + 14069, .PartitaDanniElettriciElettronici.SommaAssicurata)

    '                props.Add(i + 14070, .CoperturaEventiEccezionali.Stato)
    '                props.Add(i + 14071, .CoperturaAcquaCondottaFenomeniElettrici.Stato)
    '                props.Add(i + 14072, .RiduzioneFranchigiaAcquaCondotta.Stato)
    '                props.Add(i + 14073, .RiduzioneFranchigiaFenomeniElettrici.Stato)
    '                props.Add(i + 14074, .CoperturaEventiSpeciali.Stato)
    '                props.Add(i + 14075, .CoperturaAcquaPiovanaOcclusioneFuoriuscita.Stato)
    '                props.Add(i + 14076, .CoperturaAttiDiTerrorismo.Stato)
    '                props.Add(i + 14077, .CoperturaPannelliFotovoltaici.Stato)

    '                'Furto
    '                props.Add(i + 14078, .CoperturaFurto.Stato)

    '                props.Add(i + 14079, .CoperturaFurtoContenuto(.PartitaContenutoFurto).Stato)
    '                props.Add(i + 14080, .PartitaContenutoFurto.SommaAssicurata)
    '                props.Add(i + 14081, .PartitaContenutoFurto.FormaDiAssicurazione)

    '                props.Add(i + 14082, .CoperturaFurtoRischiEsterniAbitazione.Stato)
    '                props.Add(i + 14083, .PartitaRischiEsterniAbitazione.SommaAssicurata)

    '                props.Add(i + 14084, .CoperturaFurtoPartitaPreziosiEvalori.Stato)
    '                props.Add(i + 14085, .PartitaPreziosiEvalori.SommaAssicurata)

    '                props.Add(i + 14086, .CoperturaFurtoPartitaPreziosiEvaloriInCassaforte.Stato)
    '                props.Add(i + 14087, .PartitaPreziosiEvaloriInCassaforte.SommaAssicurata)

    '                props.Add(i + 14088, .CondizioneMezziChiusuraTipo24A.Stato)
    '                props.Add(i + 14089, .CondizioneImpiantoDiAllarme.Stato)
    '                props.Add(i + 14090, .CondizionePreziosiEvaloriPortavalori.Stato)
    '                props.Add(i + 14091, .CondizionePreziosiEvalori.Stato)
    '                props.Add(i + 14092, .CondizioneImpiantoFotovoltaico.Stato)
    '                props.Add(i + 14093, .CondizioneFranchigia.Stato)
    '            End With
    '            i += 50
    '        Next
    '    End With
    'End If
#End Region


End Class
