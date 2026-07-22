Imports System.Xml

Class Specifica
    Public Const KEY_FILE_MA = "M[AC]############.###"
    Public ReadOnly Files As New Files
    Public ReadOnly PreImportazione As New List(Of String)
    Public ReadOnly PostImportazione As New List(Of String)

    Public Sub New()
        LeggiSpecifiche()
    End Sub

    Public Sub New(connessione As OleDb.OleDbConnection)
        Globale.Log.Info("creo nuova specifica")

        LeggiSpecifiche()
        AllineaConDatabase(connessione)

        Globale.Log.Info("creazione specifica ok")
    End Sub

    Private Function LeggiSpecifiche() As Boolean
        Globale.Log.Info("Cartella dove sono cercate le specifiche (specifica-*.xml): " & Utx.Globale.Paths.CartellaSetting)

        For Each sFileXml In IO.Directory.GetFiles(Utx.Globale.Paths.CartellaSetting, "specifica-*.xml")
            Globale.Log.Info("Trovato " & sFileXml)
            Dim dd = New XmlDataDocument()

            dd.Load(sFileXml)

            Dim xml As XmlElement = dd.DocumentElement

            Globale.Log.Info("versione specifica: " & getNamedItem(xml.SelectSingleNode("/specifica"), "versione"))
            Globale.Log.Info("versione Unifeed  : " & GetType(Specifica).Assembly.GetName.Version.ToString)

            Dim xFile As XmlNode
            Dim xTracciato As XmlNode
            For Each xFile In xml.SelectNodes("/specifica/file")
                Dim oFile As File
                Dim sFilePatterns As String

                sFilePatterns = getNamedItem(xFile, "patterns")

                oFile = Files.GetFile(sFilePatterns)
                oFile.SelectCase = getNamedItem(xFile, "select-case")
                oFile.FilePatterns = getNamedItem(xFile, "patterns")

                Select Case getNamedItem(xFile, "tipofile")
                    Case "excel" : oFile.TipoFile = File.TipoFileEnum.TipoFileExcel
                    Case Else : oFile.TipoFile = File.TipoFileEnum.TipoFileTesto
                End Select

                For Each xTracciato In xFile.SelectNodes("tracciato")
                    Dim oTracciato As New Tracciato With {
                        .DeleteFirst = ("vero" = getNamedItem(xTracciato, "deleteFirst")),
                        .Obsoleto = ("vero" = getNamedItem(xTracciato, "obsoleto")) Or ("falso" = getNamedItem(xTracciato, "importare")),
                        .PerEsportazione = ("vero" = getNamedItem(xTracciato, "perEsportazione")),
                        .TipoRecord = getNamedItem(xTracciato, "ifcases")
                    }

                    Dim TracciatoIsComplesso As Boolean
                    TracciatoIsComplesso = ("vero" = getNamedItem(xTracciato, "complesso"))

                    Dim sKeyTracciato As String
                    Dim ifcase As String
                    Dim iflength As String
                    iflength = getNamedItem(xTracciato, "iflength")
                    If getNamedItem(xTracciato, "ifcases") = vbNullString Then
                        oFile.Tracciati.Add("a", oTracciato)
                    Else
                        For Each ifcase In Split(getNamedItem(xTracciato, "ifcases"), ",")
                            sKeyTracciato = oTracciato.BuildKeyTracciato(ifcase, iflength)
                            oFile.Tracciati.Add(sKeyTracciato, oTracciato)
                        Next
                    End If

                    oTracciato.Lunghezza = LoadCampi(xTracciato.SelectSingleNode("campi"), oTracciato.Campi)
                    oTracciato.Foglio = getNamedItem(xTracciato, "foglio")
                    CalcolaPolizioneCampo(oTracciato.Campi, 1)

                    Dim oTabella As Tabella

                    If TracciatoIsComplesso Then
                        Dim xTabella As XmlNode
                        For Each xTabella In xTracciato.SelectNodes("tabelle/tabella")
                            oTabella = New Tabella With {
                                .Nome = getNamedItem(xTabella, "nome"),
                                .IfNotNull = getNamedItem(xTabella, "ifnotnull"),
                                .IfTag = getNamedItem(xTabella, "if"),
                                .Equals = getNamedItem(xTabella, "equals"),
                                .NotEquals = getNamedItem(xTabella, "notequals"),
                                .InList = getNamedItem(xTabella, "inlist"),
                                .Operazione = getNamedItem(xTabella, "operazione", "I"),
                                .PerOccorrenzaDi = getNamedItem(xTabella, "per-occorrenza-di")
                            }

                            If xTabella.HasChildNodes Then
                                Dim sRif As String
                                Dim oCampo As Campo = Nothing
                                Dim xCampo As XmlNode

                                For Each xCampo In xTabella.SelectNodes("campi/campo")
                                    'temporaneamente per caricare tutti i dati conosciuti
                                    If getNamedItem(xCampo, "stato") = "ok" Then
                                        sRif = getNamedItem(xCampo, "nome-rif")
                                        If sRif = vbNullString Then
                                            sRif = getNamedItem(xCampo, "nome")
                                        End If

                                        If oTracciato.Campi.ContainsKey(sRif) Then
                                            oCampo = oTracciato.Campi(sRif).Clone
                                            oCampo.Storicizzare = (getNamedItem(xCampo, "storicizzare") = "si")

                                        ElseIf oTabella.PerOccorrenzaDi IsNot Nothing AndAlso oTracciato.Campi.ContainsKey(oTabella.PerOccorrenzaDi) Then
                                            Dim enumerator = oTracciato.Campi(oTabella.PerOccorrenzaDi).Campi.Keys.GetEnumerator()
                                            If enumerator.MoveNext() Then
                                                Dim c As Campo = oTracciato.Campi(oTabella.PerOccorrenzaDi).Campi(enumerator.Current)

                                                If c.Campi.ContainsKey(sRif) Then
                                                    oCampo = c.Campi(sRif).Clone
                                                    oCampo.Storicizzare = (getNamedItem(xCampo, "storicizzare") = "si")
                                                Else
                                                    Debug.Print("sRif: " & oTabella.PerOccorrenzaDi & "-" & sRif)
                                                End If
                                            Else
                                                Debug.Print("enumerator.MoveNext(): " & oTabella.PerOccorrenzaDi & "-" & sRif)
                                            End If
                                        Else
                                            oCampo = Nothing
                                        End If

                                        If oCampo Is Nothing Then
                                            oCampo = New Campo
                                        End If

                                        oCampo.Nome = getNamedItem(xCampo, "nome")
                                        oCampo.NomeRif = sRif
                                        oCampo.Formato = getNamedItem(xCampo, "formato")
                                        oCampo.Valore = getNamedItem(xCampo, "valore")
                                        oCampo.DefaultSeNullo = getNamedItem(xCampo, "senullo")

                                        oTabella.Campi.Add(oCampo.Nome, oCampo)
                                    End If
                                Next
                            Else
                                oTabella.Campi = oTracciato.Campi.Clone
                            End If

                            oTracciato.Tabelle.Add(oTabella)
                        Next xTabella
                    Else
                        Dim sNome As String
                        For Each sNome In Split(getNamedItem(xTracciato, "tabelle"), ",")
                            oTabella = New Tabella
                            oTabella.Nome = sNome
                            oTabella.Operazione = getNamedItem(xTracciato, "operazione")
                            oTracciato.Tabelle.Add(oTabella)
                            oTabella.Campi = oTracciato.Campi.Clone
                        Next
                    End If

                    Call oTracciato.Buid()

                Next xTracciato
            Next xFile

            For Each xSql As XmlNode In xml.SelectNodes("/specifica/elaborazioni/pre-importazione/sql")
                Dim innerText As String = xSql.InnerText
                PreImportazione.Add(innerText)
            Next
            For Each xSql As XmlNode In xml.SelectNodes("/specifica/elaborazioni/post-importazione/sql")
                Dim innerText As String = xSql.InnerText
                PostImportazione.Add(innerText)
            Next
        Next sFileXml

        Return True
    End Function

    Private Function LoadCampi(xCampi As XmlNode, oCampi As Campi) As Integer
        Dim xCampo As XmlNode
        Dim oCampo As Campo
        Dim iCampo As Campo
        Dim i As Integer
        Dim lunghezza As Integer = 0

        For Each xCampo In xCampi.SelectNodes("campo")
            'oCampo.Occorrenze = getNamedItem(xCampo, "occorrenze", 1)
            oCampo = New Campo With {
                .Nome = getNamedItem(xCampo, "nome"),
                .NomeChiave = getNamedItem(xCampo, "nome-chiave"),
                .NomeRif = getNamedItem(xCampo, "nome-rif"),
                .Occorrenze = CType(getNamedItem(xCampo, "occorrenze", "1"), Integer),
                .Formato = getNamedItem(xCampo, "formato"),
                .Valore = getNamedItem(xCampo, "valore")
            }

            oCampi.Add(oCampo.Nome, oCampo)

            If oCampo.Occorrenze > 1 Then
                For i = 1 To oCampo.Occorrenze
                    iCampo = New Campo
                    oCampo.Campi.Add(oCampo.Nome & i, iCampo)

                    If xCampo.HasChildNodes Then
                        iCampo.Lunghezza = LoadCampi(xCampo, iCampo.Campi)
                    Else
                        'iCampo.Lunghezza = getNamedItem(xCampo, "lunghezza", 0)
                        iCampo.Lunghezza = CType(getNamedItem(xCampo, "lunghezza", "0"), Integer)
                    End If

                    oCampo.Lunghezza += iCampo.Lunghezza
                Next
            Else
                If xCampo.HasChildNodes Then
                    oCampo.Lunghezza = LoadCampi(xCampo, oCampo.Campi)
                Else
                    'oCampo.Lunghezza = getNamedItem(xCampo, "lunghezza", 0)
                    oCampo.Lunghezza = CType(getNamedItem(xCampo, "lunghezza", "0"), Integer)
                End If
            End If

            lunghezza += oCampo.Lunghezza
        Next
        Return lunghezza
    End Function

    Private Sub CalcolaPolizioneCampo(oCampi As Campi, ByRef nPos As Integer)
        For Each oCampo In oCampi.Values
            If Not oCampo.CampoCalcolato Then
                If oCampo.Occorrenze = 1 Then
                    If oCampo.HasChild Then
                        CalcolaPolizioneCampo(oCampo.Campi, nPos)
                    Else
                        oCampo.Posizione = nPos
                        nPos += oCampo.Lunghezza
                    End If
                Else
                    For i = 1 To oCampo.Occorrenze
                        With oCampo.Campi(oCampo.Nome & i)
                            If .HasChild Then
                                CalcolaPolizioneCampo(.Campi, nPos)
                            Else
                                oCampo.Posizione = nPos
                                nPos += .Lunghezza
                            End If
                        End With
                    Next
                End If
            End If
        Next
    End Sub

    Private Function getNamedItem(nodo As XmlNode, attributo As String, Optional sDefault As String = vbNullString) As String
        If Not nodo.Attributes.GetNamedItem(attributo) Is Nothing Then
            getNamedItem = nodo.Attributes.GetNamedItem(attributo).Value
        Else
            getNamedItem = sDefault
        End If
    End Function

    Public Sub AllineaConDatabase(connessione As OleDb.OleDbConnection)
        'puo essere utile
        'https://www.mssqltips.com/sqlservertutorial/183/informationschemacolumns/
        Try
            Globale.Log.Info("Controllo tabelle...")

            ''per debug
            'For Each oFile In Files.Values
            '    Globale.Log.Info(oFile.FilePatterns)
            '    For Each oTracciato In oFile.Tracciati.Values
            '        For Each oTabella In oTracciato.Tabelle
            '            Globale.Log.Info("tipo record: {0} - tabella: {1}", {oTracciato.TipoRecord, oTabella.Nome})
            '        Next
            '    Next
            'Next

            For Each oFile In Files.Values
                For Each oTracciato In oFile.Tracciati.Values
                    If oTracciato.PerEsportazione = False And oTracciato.Obsoleto = False Then
                        For Each oTabella In oTracciato.Tabelle
                            If 1 = 1 Then
                                Globale.Log.Trace("Controllo tabella {0}", {oTabella.Nome})

                                Dim chiavi As New Dictionary(Of String, String)
                                For Each chiave In oTabella.Campi.Keys
                                    chiavi.Add(chiave.ToLower, chiave)
                                Next

                                Dim table As DataTable = connessione.GetSchema("Columns", {Nothing, Nothing, oTabella.Nome})

                                oTabella.TabellaIsOk = table.Rows.Count > 0

                                For Each row As DataRow In table.Rows
                                    Dim nomeColonna As String = row("COLUMN_NAME").ToString.ToLower

                                    If chiavi.ContainsKey(nomeColonna) Then
                                        With oTabella.Campi(chiavi(nomeColonna))
                                            .CampoOk = True
                                            .TipoDato = CInt(row("DATA_TYPE"))
                                            .CampoChiave = False
                                            If .TipoDato = 8 OrElse .TipoDato = 129 OrElse .TipoDato = 130 OrElse .TipoDato = 200 OrElse .TipoDato = 201 OrElse .TipoDato = 202 OrElse .TipoDato = 203 Then
                                                If .Lunghezza > CInt(row("CHARACTER_MAXIMUM_LENGTH")) Then
                                                    Globale.Log.Info("Errore allineamento specifica > tabella [{0}] colonna [{1}] lunghezza nel DB [{2}], lunghezza nella specifica [{3}]",
                                                                     {oTabella.Nome, nomeColonna, row("CHARACTER_MAXIMUM_LENGTH").ToString, .Lunghezza.ToString})
                                                End If
                                            End If
                                        End With
                                    Else
                                        Globale.Log.Debug(String.Format("DEBUG: colonna '{0}'.'{1}' non è stata trovata in specifica", oTabella.Nome, nomeColonna))
                                    End If
                                Next

                                'controllo che i campi della specifica siano presenti nel database
                                For Each Campo In oTabella.Campi.Values
                                    If Campo.CampoOk = False Then
                                        If Campo.Nome <> "TipoRecord" And Campo.Nome.StartsWith("Filler") = False Then
                                            Globale.Log.Info(String.Format("WARNING: colonna '{0}'.'{1}' non è stata trovata nel database", oTabella.Nome, Campo.Nome))
                                        End If
                                    End If
                                Next

                                Try
                                    Globale.Log.Debug(String.Format("Leggo primary key della tabella {0}.", oTabella.Nome))
                                    Dim PrimaryKeys As DataTable = connessione.GetSchema("Indexes", {Nothing, Nothing, Nothing, Nothing, oTabella.Nome})
                                    For Each row As DataRow In PrimaryKeys.Rows
                                        If CBool(row("PRIMARY_KEY")) = True Then
                                            Dim nomeColonna As String = row("COLUMN_NAME").ToString.ToLower
                                            With oTabella.Campi(chiavi(nomeColonna))
                                                .CampoChiave = True
                                            End With
                                        End If
                                    Next
                                Catch ex As Exception
                                    Globale.Log.Info("ERRORE:")
                                    Globale.Log.Info(ex)
                                End Try

                                'controllo, in caso di operazione 'A', che
                                'ci siano dei campi chiave o storici, altrimenti 
                                'l'unico tipo di operazione ammessa è "I" = inserimento

                                If "AEUD".Contains(oTabella.Operazione) Then
                                    Dim tabellaIsOk As Boolean = False
                                    For Each Campo In oTabella.Campi.Values
                                        If Campo.CampoChiave = True OrElse Campo.Storicizzare = True Then
                                            tabellaIsOk = True
                                            Exit For
                                        End If
                                    Next
                                    If tabellaIsOk = False Then
                                        oTabella.Operazione = "I"
                                        Globale.Log.Info(String.Format("Errore nella specifica. La tabella {0} non presenta campi chiavi. Unica operazione ammessa è 'I'", oTabella.Nome))
                                    End If
                                End If
                            End If
                        Next oTabella
                    End If
                Next oTracciato
            Next oFile

        Catch ex As Exception
            OmniaLog.Info("ERRORE:")
            OmniaLog.Info(ex.Message)
        End Try
    End Sub

    Public Function FileCanUpload(sInFile As String) As Boolean
        FileCanUpload = Files.GetFileByPattern(sInFile) IsNot Nothing
    End Function

#If DEBUGING Then
Public Sub WriteVerifica()
    Dim oFile      As File
    Dim oTracciato As Tracciato
    Dim oTabella   As Tabella
    Dim oCampo     As Campo

    For Each oFile In Files
        For Each oTracciato In oFile.Tracciati
            For Each oTabella In oTracciato.Tabelle
                For Each oCampo In oTabella.Campi
                    If Not oCampo.CampoOk Then
                        If oCampo.Nome <> oTabella.IfNotNull _
                        And oCampo.Nome <> oTabella.IfTag Then
                        ogLog.Append "Not CampoOk: " & oTabella.Nome & "." & oCampo.Nome
                        End If
                    End If
                Next oCampo
            Next oTabella
        Next oTracciato
    Next oFile
End Sub
#End If


End Class
