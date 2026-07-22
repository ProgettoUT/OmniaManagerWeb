Imports System.Xml.Serialization
Imports System.IO
Imports System.IO.Compression
Imports System.Windows.Forms

Public Class CManifestoLight

    Public Property Pacchetto As String
    'Public Property Gruppo As String
    'Public Property Tipo As String
    Public Property Nome As String
    Public Property DisplayNome As String
    Public Property Descrizione As String
    Public Property Documentazione As String
    Public Property AltezzaDocumentazione As Long = 0
    'Public Property Contenuto As String
    Public Property Note As String
    'Public Property Dominio As String
    'Public Property Categoria As String
    'Public Property Proprietario As String
    'Public Property Stato As String
    'Public Property UltAgg As String
    'Public Property Visibile As Boolean
    'Public Property RootPath As String

    Public Property PreferitoUtente As String
    Public Property Recente As Boolean
    Public Property UltimoUtilizzo As Long
    Public Property UltimoUtente As String
    Public Property Profilo As String = PRF_TUTTI
    Public Property Applicazioni As String

    Public Sub New()
    End Sub

    Public Shared ReadOnly Property Gruppo() As String
        Get
            Return "queries"
        End Get
    End Property

    Public Shared Function Load() As Dictionary(Of String, CManifestoLight)
        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            Dim sFileManifesti = IO.Path.Combine(CARTELLA_SETTING, "manifesti.zml")
            Dim manifesti As List(Of CManifestoLight) = Nothing

            Try
                If File.Exists(sFileManifesti) Then
                    Dim ser As New XmlSerializer(GetType(List(Of CManifestoLight)))
                    Using inputFile As New IO.FileStream(sFileManifesti, FileMode.Open)
                        Using input As New GZipStream(inputFile, CompressionMode.Decompress, False)
                            Using fs As New StreamReader(input)
                                manifesti = ser.Deserialize(fs)
                            End Using
                        End Using
                    End Using
                End If
            Catch ex As Exception
                'file probabilmente danneggiato
                manifesti = Nothing
            End Try

            If manifesti Is Nothing OrElse manifesti.Count = 0 Then

                manifesti = New List(Of CManifestoLight)

                Dim estrazioni = mgrMfs.ManifestiLoad(Utente, Gruppo())

                For Each estrazione As CManifestoSql In estrazioni.Values
                    Dim manifesto As New CManifestoLight() With {.Nome = estrazione.Nome,
                        .DisplayNome = estrazione.DisplayNome,
                        .Pacchetto = estrazione.Pacchetto,
                        .Descrizione = estrazione.Descrizione,
                        .Documentazione = estrazione.Documentazione,
                        .AltezzaDocumentazione = estrazione.AltezzaDocumentazione,
                        .Note = estrazione.Note,
                        .Profilo = estrazione.ProfiloPrincipale,
                        .Applicazioni = estrazione.Applicazioni}
                    manifesti.Add(manifesto)

                    'al momento non utilizzati:
                    'manifesto.RootPath = estrazione.RootPath
                    'manifesto.Gruppo = estrazione.Gruppo
                    'manifesto.Categoria = estrazione.Categoria
                    'manifesto.Dominio = estrazione.Dominio
                    'manifesto.Proprietario = estrazione.Proprietario
                    'manifesto.Stato = manifesto.Stato
                    'manifesto.UltAgg = estrazione.UltAgg
                    'manifesto.Contenuto = estrazione.Contenuto
                Next

                If manifesti.Count > 0 Then
                    Dim ser As New XmlSerializer(GetType(List(Of CManifestoLight)))
                    Using inputFile As New IO.FileStream(sFileManifesti, FileMode.Create)
                        Using input As New GZipStream(inputFile, CompressionMode.Compress, False)
                            Using fs As New StreamWriter(input)
                                ser.Serialize(fs, manifesti)
                            End Using
                        End Using
                    End Using

                End If
            End If

            Dim dizionario As New Dictionary(Of String, CManifestoLight)
            If manifesti IsNot Nothing Then
                For Each manifesto In manifesti
                    dizionario.Add(manifesto.Nome, manifesto)
                Next
            End If

            Return dizionario

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try

        Return Nothing
    End Function

    Public Shared Sub DeleteFile()
        Dim sFileManifesti = IO.Path.Combine(CARTELLA_SETTING, "manifesti.zml")
        If File.Exists(sFileManifesti) Then
            File.Delete(sFileManifesti)
        End If
    End Sub

    Public ReadOnly Property HaDocumentazione() As Boolean
        Get
            Return Not String.IsNullOrEmpty(Documentazione)
        End Get
    End Property



End Class
