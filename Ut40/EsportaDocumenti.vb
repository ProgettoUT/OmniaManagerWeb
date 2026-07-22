Imports System.Data.OleDb
Imports System.IO

Public Class EsportaDocumenti

    Private Shared ReadOnly Log As New Utx.ApplicationLog("EsportaDocumenti", LogCondiviso:=True)
    Private WithEvents Notifica As New Utx.FormNotifica
    Private Shared SinistriValidi As DataTable
    Private Shared ClientiValidi As DataTable
    Private Shared Esportati As String
    Private Shared FileIndice As String
    Private Shared FileIndiceStorico As String
    Private Shared ReadOnly Testata As String = "Tipo Entita;Nome File;Descrizione;Categoria Documento;Tipo Documento;Ragione Sociale;Codice Fiscale;Numero Polizza;Esercizio;Numero Sinistro;Data;" &
        "Compagnia;Ramo;Pacco/Fascicolo;Autore;Operatore;ID Anagrafica;Tipo Documento Cod.;Tipo Documento Descr.;Argomento Cod.;Argomento Descr.;" &
        "Operatore Cod.;Operatore Descr.;Mezzo;Direzione;Firma;Tipologia Consenso"

    Sub New()
        Log.Info("Esportazione documenti verso SIA")
    End Sub

    Public Sub Esporta2FTP()
        Try
            Dim Inizio As Date = Now
            With Notifica
                .Stile = Utx.FormNotifica.Style.ANTRACITE
                .AnnullaOperazione = True
                .Show()
                .Messaggio = "Preparazione invio documenti..."
                .TopMost = True
            End With

            'creo la cartella dei documenti esportati
            Dim SessioneFTP As New SIA40.FTPUpload(Utx.Globale.ProfiloEnteGestore.AgenziaMadre)
            Log.Info("Avvio esportazione: sessione {0}", {SessioneFTP.TagSessione})

            Dim NomeIndice = String.Format("LETTOWEB_{0}.csv", Utx.Globale.AgenziaRichiesta.CodiceAgenzia.PadLeft(9, "0"))
            Dim NomeIndiceStorico = String.Format("LETTOWEB_{0}.storico.csv", Utx.Globale.AgenziaRichiesta.CodiceAgenzia.PadLeft(9, "0"))

            FileIndice = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, NomeIndice)
            FileIndiceStorico = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, NomeIndiceStorico)

            Dim Progressivo As Integer = 0
            Dim Analizzati As Integer = 0
            'scarico un eventuale file indice presente sul server FTP
            Dim Inviati As Integer = SessioneFTP.DownloadIndice(NomeIndice, NomeIndiceStorico)

            Using SW As New StreamWriter(FileIndice)
                'scrivo l'intestazione con il nome dei campi
                SW.WriteLine(Testata)
                'analisi cartella doc
                Dim NumeroCartelle As Integer = Directory.GetDirectories(Utx.Globale.Paths.CartellaDocumenti, "?").Length

                For Each CartellaLettera As String In SortArray(Directory.GetDirectories(Utx.Globale.Paths.CartellaDocumenti, "?"))
                    Dim NumeroFile As Integer = Directory.GetFiles(CartellaLettera, "*", SearchOption.AllDirectories).Length

                    'per ogni cliente
                    For Each CartellaCliente As String In SortArray(Directory.GetDirectories(CartellaLettera))
                        Try
                            Dim Cliente As New ClienteDocumento(CartellaCliente)

                            AggiornaNotifica(Inviati, CartellaLettera, Analizzati, NumeroFile, Cliente.Nome)

                            If Cliente.Esiste Then
                                SessioneFTP.CodiceFiscale = Cliente.CodiceFiscale
                                'doc cliente
                                For Each f As String In SortArray(Directory.GetFiles(CartellaCliente))
                                    Dim Doc As New Documento(Cliente, f, Documento.TipoDoc.ANAG)
                                    'se il documento è uno dei doc trasmissibili e il sinistro è nel range stabilito
                                    If Doc.DocumentoValido = True Then
                                        'se il file non è stato già trasmesso
                                        If Doc.DocumentoSia.GiaTrasmesso = False Then
                                            If File.Exists(Doc.FullPathDocumentoEsportazione) Then
                                                'copio il file
                                                If SessioneFTP.UploadFileCliente(f) = True Then
                                                    'scrivo il doc nell'indice
                                                    SW.WriteLine(Doc.IndiceDocumento(Cliente))
                                                    Inviati += 1
                                                    Log.Trace("Inviato ({0}): {1}", {Inviati, f})
                                                Else
                                                    Log.Info("Errore nell'invio del file {0}", {f})
                                                End If
                                            End If
                                        Else
                                            Log.Trace("Già trasmesso: {0}", {f})
                                        End If
                                    End If
                                    Analizzati += 1

                                    System.Windows.Forms.Application.DoEvents()
                                    AggiornaNotifica(Inviati, CartellaLettera, Analizzati, NumeroFile, Cliente.Nome)
                                    If Notifica.RichiestaAnnullamento = True Then Exit For
                                Next

                                'doc polizze
                                For Each CartellaPolizza As String In SortArray(Directory.GetDirectories(CartellaCliente, "Polizza*"))
                                    'polizza della cartella scritta in modo standard
                                    If Path.GetFileName(CartellaPolizza).Split(" ").GetUpperBound(0) = 1 Then
                                        Cliente.RamoPolizza = CartellaPolizza

                                        For Each f As String In SortArray(Directory.GetFiles(CartellaPolizza))
                                            Dim Doc As New Documento(Cliente, f, Documento.TipoDoc.POLIZZA)
                                            'se il documento è uno dei doc trasmissibili e il sinistro è nel range stabilito
                                            If Doc.DocumentoValido = True Then
                                                'se il file non è stato già trasmesso
                                                If Doc.DocumentoSia.GiaTrasmesso = False Then
                                                    If File.Exists(Doc.FullPathDocumentoEsportazione) Then
                                                        If SessioneFTP.UploadFileCliente(f) = True Then
                                                            'scrivo il doc nell'indice
                                                            SW.WriteLine(Doc.IndiceDocumento(Cliente))
                                                            Inviati += 1
                                                            Log.Trace("Inviato ({0}): {1}", {Inviati, f})
                                                        Else
                                                            Log.Info("Errore nell'invio del file {0}", {f})
                                                        End If
                                                    End If
                                                Else
                                                    Log.Trace("Già trasmesso: {0}", {f})
                                                End If
                                            End If
                                            Analizzati += 1
                                        Next
                                    End If
                                    System.Windows.Forms.Application.DoEvents()
                                    AggiornaNotifica(Inviati, CartellaLettera, Analizzati, NumeroFile, Cliente.Nome)
                                    If Notifica.RichiestaAnnullamento = True Then Exit For
                                Next

                                'doc sinistri
                                For Each CartellaSinistro As String In SortArray(Directory.GetDirectories(CartellaCliente, "Sinistro*"))
                                    'polizza della cartella scritta in modo standard
                                    If Path.GetFileName(CartellaSinistro).Split(" ").GetUpperBound(0) = 1 Then
                                        Cliente.Sinistro = CartellaSinistro

                                        For Each f As String In SortArray(Directory.GetFiles(CartellaSinistro))
                                            Dim Doc As New Documento(Cliente, f, Documento.TipoDoc.SINISTRO)
                                            'se il documento è uno dei doc trasmissibili e il sinistro è nel range stabilito
                                            If Doc.DocumentoValido = True AndAlso Cliente.SinistroValido Then
                                                'se il file non è stato già trasmesso
                                                If Doc.DocumentoSia.GiaTrasmesso = False Then
                                                    If File.Exists(Doc.FullPathDocumentoEsportazione) Then
                                                        'trasmetto il doc
                                                        If SessioneFTP.UploadFileCliente(f) = True Then
                                                            'scrivo il doc nell'indice
                                                            SW.WriteLine(Doc.IndiceDocumento(Cliente))
                                                            Inviati += 1
                                                            Log.Trace("Inviato ({0}): {1}", {Inviati, f})
                                                        Else
                                                            Log.Info("Errore nell'invio del file {0}", {f})
                                                        End If
                                                    End If
                                                Else
                                                    Log.Trace("Già trasmesso: {0}", {f})
                                                End If
                                            End If
                                            Analizzati += 1
                                        Next
                                    End If
                                    System.Windows.Forms.Application.DoEvents()
                                    AggiornaNotifica(Inviati, CartellaLettera, Analizzati, NumeroFile, Cliente.Nome)
                                    If Notifica.RichiestaAnnullamento = True Then Exit For
                                Next
                            Else
                                'cliente non trovato: considero analizzati tutti i file della cartella cliente
                                Analizzati += Directory.GetFiles(CartellaCliente, "*", SearchOption.AllDirectories).Length
                                AggiornaNotifica(Inviati, CartellaLettera, Analizzati, NumeroFile, Cliente.Nome)
                            End If

                            If Notifica.RichiestaAnnullamento = True Then Exit For

                        Catch ex As Exception
                            Log.Info(CartellaCliente)
                            Log.Errore(ex)
                            Notifica.Errore = True
                        End Try
                    Next

                    If Notifica.RichiestaAnnullamento = True Then
                        Log.Info("Annullamento dell'esportazione chiesto dall'utente")
                        Notifica.Messaggio = "Chiusura sessione in corso..."
                        Exit For
                    End If

                    Progressivo += 1
                    AggiornaNotifica(Inviati, CartellaLettera, Analizzati, NumeroFile, "...")
                Next
            End Using

            If Inviati > 0 Then
                'invio indice
                Log.Info("Invio indice di {0} documenti inviati nella sessione {1}", {Inviati, SessioneFTP.TagSessione})
                SessioneFTP.UploadIndice(FileIndice, FileIndiceStorico)
                SessioneFTP.InviaEmailNotifica(Utx.Globale.ProfiloEnteGestore.AgenziaMadre, Inizio, Now, "Invio documenti concluso", Inviati + 1) '+1 per l'indice
            Else
                'rimuovo la cartella di sessione vuota
                SessioneFTP.Sessione.RemoveFiles(SessioneFTP.CartellaSessione)
            End If

            SessioneFTP.ChiudiSessioneFTP()

        Catch ex As Exception
            Log.Info(ex)
            Notifica.Errore = True
        Finally
            Log.Info("Invio documenti: fine")

            If Notifica.Errore = False Then
                Notifica.Messaggio = "Indice documenti creato correttamente"
                Notifica.Chiudi(5)
            Else
                Notifica.Stile = Utx.FormNotifica.Style.BIANCO_ROSSO
                Notifica.Messaggio = "Errore nella creazione dell'indice"
                Notifica.Chiudi(5)
            End If
        End Try
    End Sub

    Private Sub AggiornaNotifica(Inviati As Integer, CartellaLettera As String, Analizzati As Integer, NumeroFile As Integer, Cliente As String)
        Try
            Notifica.Messaggio = String.Format("Documenti inviati: {1} - Cartella: {2} ({3}/{4}){0}{0}{5}",
                                          Environment.NewLine, Inviati, Path.GetFileName(CartellaLettera), Analizzati, NumeroFile, Cliente)
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Class ClienteDocumento

        Sub New(CartellaCliente As String)
            Try
                Dim di As New DirectoryInfo(CartellaCliente)
                mCodiceFiscale = di.Name

                If ClientiValidi Is Nothing Then
                    'riempio la tabella sinistri validi con i dati di tutti i codici gestiti
                    ClientiValidi = New DataTable

                    For Each Agenzia As String In Utx.EnteGestore.CodiciGestiti
                        Dim Query As String = "SELECT DISTINCT CodiceFiscale,Cognome + ' ' + Nome AS Cliente FROM Clienti"
                        ClientiValidi.Merge(Utx.WsCommand.ExecuteNonQuery(Query, Agenzia).DataTable)
                    Next
                    'inserisco una chiave primaria
                    ClientiValidi.PrimaryKey = {ClientiValidi.Columns("CodiceFiscale")}
                End If

                'se si tratta di una piva o un cf
                If (mCodiceFiscale.Length = 11) OrElse (mCodiceFiscale.Length = 16) Then
                    Me.Cliente = ClientiValidi.Rows.Find({mCodiceFiscale})
                    mEsiste = Me.Cliente IsNot Nothing
                Else
                    mEsiste = False
                End If
            Catch ex As Exception
                Log.Errore(ex)
            End Try
        End Sub

        Private mCodiceFiscale As String
        Public ReadOnly Property CodiceFiscale() As String
            Get
                Return mCodiceFiscale
            End Get
        End Property

        Private mNome As String
        Public ReadOnly Property Nome() As String
            Get
                If mCliente Is Nothing Then
                    Return "..."
                Else
                    Return Left(mCliente("Cliente"), 50)
                End If
            End Get
        End Property

        Private mEsiste As Boolean
        Public ReadOnly Property Esiste() As Boolean
            Get
                Return mEsiste
            End Get
        End Property

        Private mCliente As DataRow
        Public Property Cliente() As DataRow
            Get
                Return mCliente
            End Get
            Set(value As DataRow)
                mCliente = value
            End Set
        End Property

        Private mRamoPolizza As String
        Public Property RamoPolizza() As String
            Get
                Return mRamoPolizza
            End Get
            Set(value As String)
                mRamoPolizza = value
                If value.Split(" ").GetUpperBound(0) = 1 Then
                    mRamoPolizza = value.Split(" ")(1).Replace("-", ".").Replace("/", ".")
                    If mRamoPolizza.Split(".").GetUpperBound(0) = 1 Then
                        mRamo = RamoPolizza.Split(".")(0).Trim
                        mPolizza = RamoPolizza.Split(".")(1).Trim
                    Else
                        mRamo = "000"
                        mPolizza = RamoPolizza.Split(".")(0).Trim
                    End If
                Else
                    mRamo = "000"
                    mPolizza = "000000000"
                End If
            End Set
        End Property

        Private mRamo As String
        Public ReadOnly Property Ramo() As String
            Get
                Return mRamo
            End Get
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

        Private _Sinistro As String
        Public Property Sinistro() As String
            Get
                Return _Sinistro
            End Get
            Set(value As String)
                'normalizzo il numero sinistro
                _Sinistro = Path.GetFileName(value).Replace(".", "-")

                If _Sinistro.Split(" ").GetUpperBound(0) = 1 Then
                    _Compagnia = _Sinistro.Split(" ")(1).Split("-")(0)
                    _AgenziaSinistro = _Sinistro.Split(" ")(1).Split("-")(1)
                    _Esercizio = _Sinistro.Split(" ")(1).Split("-")(2)
                    _NumeroSinistro = _Sinistro.Split(" ")(1).Split("-")(3)
                Else
                    _Compagnia = 1
                    _AgenziaSinistro = "0000"
                    _Esercizio = "0000"
                    _Esercizio = "0000000"
                End If
            End Set
        End Property

        Private _Compagnia As Integer
        Public Property Compagnia() As Integer
            Get
                Return _Compagnia
            End Get
            Set(ByVal value As Integer)
                _Compagnia = value
            End Set
        End Property
        Private _AgenziaSinistro As String
        Public Property AgenziaSinistro() As String
            Get
                Return _AgenziaSinistro
            End Get
            Set(ByVal value As String)
                _AgenziaSinistro = value
            End Set
        End Property
        Private _Esercizio As String
        Public Property Esercizio() As String
            Get
                Return _Esercizio
            End Get
            Set(ByVal value As String)
                _Esercizio = value
            End Set
        End Property
        Private _NumeroSinistro As String
        Public Property NumeroSinistro() As String
            Get
                Return _NumeroSinistro
            End Get
            Set(ByVal value As String)
                _NumeroSinistro = value
            End Set
        End Property

        Public Function SinistroValido() As Boolean
            Try
                If SinistriValidi Is Nothing Then
                    'riempio la tabella sinistri validi con i dati di tutti i codici gestiti
                    SinistriValidi = New DataTable

                    For Each Agenzia As String In Utx.EnteGestore.CodiciGestiti
                        For Each tbl As String In "SinistriDP,SinistriDA".Split(",")
                            Dim Query As String = String.Format("SELECT  Compagnia,AgenziaSinistro,EsercizioSinistro,NumeroSinistro
                                FROM {0}
                                WHERE YEAR(AnnoMeseCompetenza) > {1}", tbl, Today.Year - 2)
                            SinistriValidi.Merge(Utx.WsCommand.ExecuteNonQuery(Query, Agenzia).DataTable)
                        Next
                    Next
                    'inserisco una chiave primaria
                    SinistriValidi.PrimaryKey = {SinistriValidi.Columns("Compagnia"),
                        SinistriValidi.Columns("AgenziaSinistro"),
                        SinistriValidi.Columns("EsercizioSinistro"),
                        SinistriValidi.Columns("NumeroSinistro")}
                End If
                'restituisco un valore true se il sinistro è stato trovato
                Return SinistriValidi.Rows.Find({_Compagnia, _AgenziaSinistro, _Esercizio, _NumeroSinistro}) IsNot Nothing

            Catch ex As Exception
                Log.Errore(ex)
                Return False
            End Try
        End Function
    End Class

    Private Class Documento

        Public Enum TipoDoc
            ANAG
            POLIZZA
            SINISTRO
        End Enum

        Private mDocumentoSia As DocSIA
        Private Shared ReadOnly Template As String = "@entita;@path;@nomefile;;;@nome;@cf;@polizza;@esercizio;@numerosinistro;@data;;@ramo;@pacco;;;;@tipo;@desktipo;@cat;@deskcat;;;;IN;@firma;@consenso"

        Sub New(Cliente As ClienteDocumento, Documento As String, Tipo As TipoDoc)
            mDocumento = Documento
            mTipoDocumento = Tipo

            If Path.GetFileName(mDocumento).ToLower <> "thumbs.db" Then
                mDocumentoValido = True
                mDocumentoSia = New DocSIA(Cliente, Documento, Tipo)
            End If
        End Sub

        Private mDocumento As String
        Public ReadOnly Property Documento() As String
            Get
                Return mDocumento
            End Get
        End Property

        Private mTipoDocumento As TipoDoc
        Public Property TipoDocumento() As TipoDoc
            Get
                Return mTipoDocumento
            End Get
            Set(ByVal value As TipoDoc)
                mTipoDocumento = value
            End Set
        End Property

        Private mDocumentoValido As Boolean
        Public ReadOnly Property DocumentoValido() As Boolean
            Get
                Return mDocumentoValido
            End Get
        End Property

        Private mFullPathDocumentoEsportazione As String
        Public ReadOnly Property FullPathDocumentoEsportazione() As String
            Get
                mFullPathDocumentoEsportazione = Replace(mDocumento, "\Documenti\", "\Documenti\" & Path.GetFileName(EsportaDocumenti.Esportati) & "\")
                'crea la dir se non esiste
                Directory.CreateDirectory(Path.GetDirectoryName(mFullPathDocumentoEsportazione))
                Return mFullPathDocumentoEsportazione
            End Get
        End Property

        Public ReadOnly Property DocumentoSia() As DocSIA
            Get
                Return mDocumentoSia
            End Get
        End Property

        Public Function IndiceDocumento(Cliente As ClienteDocumento) As String
            Try
                If DocumentoValido = True Then
                    Dim Riga As New Utx.NetFunc.StringFormatter(Template)
                    With Riga
                        .Parametro("@path", mDocumentoSia.PathRelativo)
                        .Parametro("@nomefile", mDocumentoSia.Nome)
                        .Parametro("@tipo", mDocumentoSia.Tipo)
                        .Parametro("@desktipo", mDocumentoSia.TipoDesk)
                        .Parametro("@cat", mDocumentoSia.Cat)
                        .Parametro("@deskcat", mDocumentoSia.CatDesk)
                        .Parametro("@data", mDocumentoSia.Data)
                        .Parametro("@nome", Cliente.Nome.Trim, True)
                        .Parametro("@cf", Cliente.CodiceFiscale.Trim, True)
                        .Parametro("@consenso", mDocumentoSia.Consenso, True)
#If DEBUG Then
                        .Parametro("@pacco", Format(Now, "dd-MM-yyyy HH:mm:ss")) 'mi serve per capire in debug la sequenza delle varie aggiunte
#Else
                        .Parametro("@pacco", "") 'in release non mettere niente
#End If
                        Select Case TipoDocumento
                            Case TipoDoc.ANAG
                                .Parametro("@entita", "A")
                                .Parametro("@ramo", "")
                                .Parametro("@polizza", "")
                                .Parametro("@esercizio", "")
                                .Parametro("@numerosinistro", "")
                            Case TipoDoc.POLIZZA
                                .Parametro("@entita", "P")
                                .Parametro("@ramo", Cliente.Ramo)
                                .Parametro("@polizza", Cliente.Polizza)
                                .Parametro("@esercizio", "")
                                .Parametro("@numerosinistro", "")
                            Case TipoDoc.SINISTRO
                                .Parametro("@entita", "S")
                                .Parametro("@ramo", "")
                                .Parametro("@polizza", "")
                                .Parametro("@esercizio", Cliente.Esercizio)
                                .Parametro("@numerosinistro", Cliente.NumeroSinistro)
                        End Select

                        If "PRI/PRIC".Contains(mDocumentoSia.Tipo) Then
                            .Parametro("@firma", "1", True)
                        Else
                            .Parametro("@firma", "0", True)
                        End If
                    End With
                    Return Riga.StringaFormattata
                Else
                    Return ""
                End If
            Catch ex As Exception
                Log.Errore(ex)
                Return "ERR"
            End Try
        End Function
    End Class

    Private Class DocSIA
        Sub New(Cliente As ClienteDocumento, FullPath As String, TipoDocumento As Documento.TipoDoc)
            mPathRelativo = String.Format("Esportati/{0}/{1}/{2}", Right(Cliente.CodiceFiscale, 1), Cliente.CodiceFiscale, Path.GetFileName(FullPath))
            mNome = Path.GetFileNameWithoutExtension(FullPath)

            Dim NomeUP As String = Nome.ToUpper

            If NomeUP.StartsWith("7A") Then
                mCat = "DEC" : mCatDesk = "Dichiarazioni" : mTipo = "D7A" : mTipoDesk = "Dichiarazione 7A"
            ElseIf NomeUP.StartsWith("ATTESTATO DI RISCHIO") Then
                mCat = "AUT" : mCatDesk = "Auto" : mTipo = "RA" : mTipoDesk = "Attestato di rischio"
            ElseIf NomeUP.StartsWith("ATTO DI ACCERTAMENTO") Then
                mCat = "CLA" : mCatDesk = "Sinistri" : mTipo = "VER" : mTipoDesk = "Verbale accertamente"
            ElseIf NomeUP.StartsWith("ATTO DI CITAZIONE") Then
                mCat = "CLA" : mCatDesk = "Sinistri" : mTipo = "CIT" : mTipoDesk = "Atto di citazione"
            ElseIf NomeUP.StartsWith("CAI") Then
                mCat = "CLA" : mCatDesk = "Sinistri" : mTipo = "CAI" : mTipoDesk = "Modulo CAI"
            ElseIf NomeUP.StartsWith("CARTA D'IDENTITÀ") Then
                mCat = "IDE" : mCatDesk = "Documento identità" : mTipo = "IDC" : mTipoDesk = "Carta di identità"
            ElseIf NomeUP.StartsWith("CODICE FISCALE") Then
                mCat = "IDE" : mCatDesk = "Documento identità" : mTipo = "TIN" : mTipoDesk = "Codice Fiscale"
            ElseIf NomeUP.StartsWith("COPIA VERBALE AUTORITA") Then
                mCat = "CLA" : mCatDesk = "Sinistri" : mTipo = "VER" : mTipoDesk = "Verbale accertamento"
            ElseIf NomeUP.StartsWith("DENUNCIA") Then
                mCat = "CLA" : mCatDesk = "Sinistri" : mTipo = "DEN" : mTipoDesk = "Denuncia"
            ElseIf NomeUP.StartsWith("DENUNCIA FIRMATA") Then
                mCat = "CLA" : mCatDesk = "Sinistri" : mTipo = "DEN" : mTipoDesk = "Denuncia"
                'ElseIf NomeUP.StartsWith("DOCUMENTAZIONE MEDICA") Then
                'ElseIf NomeUP.StartsWith("ESITO OFFERTA COMMERCIALE") Then
            ElseIf NomeUP.StartsWith("FATTURA") Then
                mCat = "CLA" : mCatDesk = "Sinistri" : mTipo = "FAT" : mTipoDesk = "Fattura"
                'ElseIf NomeUP.StartsWith("Fax Sertel - Liquido") Then
            ElseIf NomeUP.StartsWith("LIBRETTO") Then
                mCat = "AUT" : mCatDesk = "Auto" : mTipo = "CHM" : mTipoDesk = "Carta circolazione"
            ElseIf NomeUP.StartsWith("NEGAZIONE EVENTI") Then
            ElseIf NomeUP.StartsWith("PATENTE") Then
                mCat = "IDE" : mCatDesk = "Documento identità" : mTipo = "DRL" : mTipoDesk = "Patente"
            ElseIf NomeUP.StartsWith("PERIZIA") Then
                mCat = "CLA" : mCatDesk = "Sinistri" : mTipo = "PERZ" : mTipoDesk = "Perizia"
            ElseIf NomeUP.StartsWith("POLIZZA") Then
                mCat = "CON" : mCatDesk = "Portafoglio" : mTipo = "CON" : mTipoDesk = "Contratto"
            ElseIf NomeUP.StartsWith("PREVENTIVO") Then
                mCat = "CON" : mCatDesk = "Portafoglio" : mTipo = "EST" : mTipoDesk = "Preventivo"
            ElseIf NomeUP.StartsWith("RICEVUTA FISCALE") Then
                mCat = "CLA" : mCatDesk = "Sinistri" : mTipo = "RFIS" : mTipoDesk = "Ricevuta fiscale"
            ElseIf NomeUP.StartsWith("RICHIESTA CONSAP") Then
                mCat = "CLA" : mCatDesk = "Sinistri" : mTipo = "CONS" : mTipoDesk = "Richiesta CONSAP"
            ElseIf NomeUP.StartsWith("RICHIESTA DANNI") Then
                mCat = "CLA" : mCatDesk = "Sinistri" : mTipo = "RDM" : mTipoDesk = "Richiesta danni"
            ElseIf NomeUP.StartsWith("TESSERA CONVENZIONE") Then
                mCat = "IDE" : mCatDesk = "Documento identità" : mTipo = "TSS" : mTipoDesk = "Tessera convenzione"
            ElseIf NomeUP.StartsWith("TESTIMONIANZA") Then
                mCat = "CLA" : mCatDesk = "Sinistri" : mTipo = "TEST" : mTipoDesk = "Testimonianza"
            ElseIf NomeUP.StartsWith("PRIVACY AGENZIA EU BASE") Then
                mCat = "DEC" : mCatDesk = "Dichiarazioni" : mTipo = "PRI" : mTipoDesk = "Privacy" : mConsenso = "2" : mFirma = "1"
            ElseIf NomeUP.StartsWith("PRIVACY AGENZIA EU 1") Then
                mCat = "DEC" : mCatDesk = "Dichiarazioni" : mTipo = "PRI" : mTipoDesk = "Privacy" : mConsenso = "2" : mFirma = "1"
            ElseIf NomeUP.StartsWith("PRIVACY AGENZIA EU 2") Then
                mCat = "DEC" : mCatDesk = "Dichiarazioni" : mTipo = "PRI" : mTipoDesk = "Privacy" : mConsenso = "4" : mFirma = "1"
            ElseIf NomeUP.StartsWith("PRIVACY AGENZIA EU 3") Then
                mCat = "DEC" : mCatDesk = "Dichiarazioni" : mTipo = "PRI" : mTipoDesk = "Privacy" : mConsenso = "5" : mFirma = "1"
            ElseIf NomeUP.StartsWith("PRIVACY AGENZIA EU 4") Then
                mCat = "DEC" : mCatDesk = "Dichiarazioni" : mTipo = "PRI" : mTipoDesk = "Privacy" : mConsenso = "1" : mFirma = "1"
            ElseIf NomeUP.StartsWith("PRIVACY AGENZIA") Then
                mCat = "DEC" : mCatDesk = "Dichiarazioni" : mTipo = "PRI" : mTipoDesk = "Privacy" : mConsenso = "4" : mFirma = "1"
            ElseIf NomeUP.StartsWith("PRIVACY COMPAGNIA") Then
                mCat = "DEC" : mCatDesk = "Dichiarazioni" : mTipo = "PRIC" : mTipoDesk = "Privacy Compagnia" : mFirma = "1"
            ElseIf NomeUP.StartsWith("PRIVACY COMPAGNIA EU 1-2") Then
                mCat = "DEC" : mCatDesk = "Dichiarazioni" : mTipo = "PRIC" : mTipoDesk = "Privacy Compagnia" : mFirma = "1"
            ElseIf NomeUP.StartsWith("PRIVACY COMPAGNIA OMNIBUS") Then
                mCat = "DEC" : mCatDesk = "Dichiarazioni" : mTipo = "PRIC" : mTipoDesk = "Privacy Compagnia" : mFirma = "1"
            Else
                Select Case TipoDocumento
                    Case Documento.TipoDoc.ANAG, Documento.TipoDoc.POLIZZA
                        mCat = "CON" : mCatDesk = "Portafoglio" : mTipo = "ALT" : mTipoDesk = "[Altri]"
                    Case Documento.TipoDoc.SINISTRO
                        mCat = "CLA" : mCatDesk = "Sinistri" : mTipo = "ALT" : mTipoDesk = "[Altri]"
                End Select
            End If

            Try
                'riaggiusto le date del protocollo
                Dim str As String = NomeUP.Substring(NomeUP.IndexOf(" DEL ") + 5).Replace(".", ":")
                If IsDate(str) Then
                    mData = Format(CDate(str), "dd/MM/yyyy")
                End If
            Catch ex As Exception
                mData = ""
            End Try
        End Sub
        Private mCat As String
        Public ReadOnly Property Cat() As String
            Get
                Return mCat
            End Get
        End Property
        Private mCatDesk As String
        Public ReadOnly Property CatDesk() As String
            Get
                Return mCatDesk
            End Get
        End Property
        Private mTipo As String
        Public ReadOnly Property Tipo() As String
            Get
                Return mTipo
            End Get
        End Property
        Private mTipoDesk As String
        Public ReadOnly Property TipoDesk() As String
            Get
                Return mTipoDesk
            End Get
        End Property
        Private mData As String = ""
        Public ReadOnly Property Data() As String
            Get
                Return Left(mData, 10)
            End Get
        End Property
        Private mPathRelativo As String
        Public ReadOnly Property PathRelativo() As String
            Get
                Return mPathRelativo.Replace("\", "/")
            End Get
        End Property
        Private mChiave As String
        Public ReadOnly Property Chiave() As String
            Get
                Return Me.PathRelativo.Replace("'", "")
            End Get
        End Property
        Private mNome As String
        Public ReadOnly Property Nome() As String
            Get
                Return mNome
            End Get
        End Property
        Private mConsenso As String
        Public ReadOnly Property Consenso() As String
            Get
                Return mConsenso
            End Get
        End Property
        Private mFirma As String = "0"
        Public ReadOnly Property Firma() As String
            Get
                Return mFirma
            End Get
        End Property

        Public Function GiaTrasmesso() As Boolean
            Try
                If File.Exists(FileIndiceStorico) Then
                    Using sr As New StreamReader(FileIndiceStorico, System.Text.Encoding.Default)
                        sr.ReadLine()

                        Do While Not sr.EndOfStream
                            Dim Riga As String = sr.ReadLine

                            If Riga.Split(";")(1) = Me.Chiave Then
                                Return True
                            End If
                        Loop
                    End Using
                End If
                Return False

            Catch ex As Exception
                Log.Errore(ex)
                Return False
            End Try
        End Function
    End Class

    Private Function SortArray(Origine) As Array
        Array.Sort(Origine)
        Return Origine
    End Function
End Class
