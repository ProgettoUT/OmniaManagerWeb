Imports System.IO
Imports System.Net
Imports System.Xml.Serialization

Public Class DocumentiUpload

    Sub New()
        LeggiLista()
    End Sub

    Private Sub LeggiLista()
        Try
            For Each doc As String In DeserializzaLista()
                Documenti.Add(New Documento(doc))
            Next
            Documenti.Sort(New Comparison(Of Documento)(AddressOf Ordina))
            Documenti.Insert(0, New Documento(String.Format("X-Selezionare il tipo documento da inviare ({0} tipologie)-X", Documenti.Count)))
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Function Help(Cerca As String) As List(Of String)
        Dim Lista As New List(Of String)
        Cerca = Cerca.ToLower
        For Each doc As Documento In Documenti
            If doc.Codice <> "X" AndAlso doc.Descrizione.ToLower.Contains(Cerca) Then
                Lista.Add(doc.Descrizione)
            End If
        Next
        Return Lista
    End Function

    Private Function Ordina(Doc1 As Documento, Doc2 As Documento)
        Return Doc1.Descrizione.CompareTo(Doc2.Descrizione)
    End Function

    Private ReadOnly Documenti As New List(Of Documento)
    Public ReadOnly Property ListaDocumenti() As List(Of Documento)
        Get
            Dim doc(Documenti.Count - 1) As Object
            For k As Integer = 0 To Documenti.Count - 1
                doc(k) = Documenti(k)
            Next
            Return Documenti
        End Get
    End Property

    Public Function ListaFiltrata(Filtro As String) As List(Of Documento)
        Return (From resultValues In Documenti Where resultValues.Descrizione.ToLower.Contains(Filtro.ToLower.Trim) Select resultValues).ToList
    End Function

    Public Shared Sub AggiornaXml()
        Try
            Dim Aggiorna As Boolean = True
            If File.Exists(DocXml) Then
                'aggiorno il file dal servizio una volta a settimana
                Aggiorna = DateDiff(DateInterval.Day, New FileInfo(DocXml).LastWriteTime.Date, Today) >= 7
            End If

            If Aggiorna Then
                Using s As New Utx.ImportaSinistriOMW.Direzione
                    s.Proxy = Utx.Globale.UniProxy.Proxy
                    Dim Esito As Utx.ImportaSinistriOMW.EsitoChiamata = s.ListaDocumentiLiquido(Utx.Globale.UtenteCorrente.UniageUser,
                                                                                                Utx.Globale.UtenteCorrente.UniagePw,
                                                                                                Utx.Globale.Token)

                    If Esito.Esito = True Then
                        File.WriteAllBytes(DocXml, Esito.Documento)
                    End If
                End Using
            End If

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Private Shared Function DocXml() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "DocUp.dat")
    End Function

    Private Shared Function DeserializzaLista() As String()
        'deserializzo il file - faccio 5 tentativi
        Dim Tentativo As Integer = 1
Deserializza:
        Try
            'leggo i dati dal file xml
            Dim ser As New XmlSerializer(GetType(String()))
            Using fs As New StreamReader(DocXml)
                Return ser.Deserialize(fs)
            End Using
        Catch ex As Exception
            'tentativi di lettura e/o recupero del file
            If Tentativo = -1 Then
                'non ha funzionato il recupero del file con aggiornamento
                Globale.Log.Info(ex.Message)
                Globale.Log.Info("cancello il file {0}", {DocXml()})
                File.Delete(DocXml)
                Return {}
            ElseIf Tentativo < 6 Then
                Tentativo += 1
                Threading.Thread.Sleep(500)
                GoTo Deserializza
            Else
                Globale.Log.Info(ex.Message)
                Globale.Log.Info("cancello il file {0}", {DocXml()})
                File.Delete(DocXml)
                AggiornaXml()
                Tentativo = -1
                GoTo Deserializza
            End If
        End Try
    End Function

    Public Class Documento

        Sub New(Doc As String)
            Try
                Dim Elementi() As String = Doc.Split("-")

                If Elementi.GetUpperBound(0) = 2 Then
                    Codice = Elementi(0).Trim
                    Descrizione = Elementi(1).Trim
                    Abbinamento = Elementi(2).Trim.Substring(0, 1)
                Else
                    'quando nella descrizione ci sono dei trattini '-'
                    Codice = Elementi(0).Trim 'primo
                    Abbinamento = Elementi(Elementi.GetUpperBound(0)).Trim.Substring(0, 1) 'ultimo
                    For k As Integer = 1 To Elementi.GetUpperBound(0) - 1
                        Descrizione &= " " & Elementi(k)
                    Next
                    Descrizione = _Descrizione.Trim
                End If
            Catch ex As Exception
                Globale.Log.Errore(ex)
            End Try
        End Sub

        Private _Codice As String
        Public Property Codice() As String
            Get
                Return _Codice
            End Get
            Set(value As String)
                _Codice = value
            End Set
        End Property

        Private _Descrizione As String
        Public Property Descrizione() As String
            Get
                Return _Descrizione
            End Get
            Set(value As String)
                _Descrizione = value
            End Set
        End Property

        Private _Abbinamento As String
        Public Property Abbinamento() As String
            Get
                Return _Abbinamento
            End Get
            Set(value As String)
                If value = "S" Then
                    _Abbinamento = "E"
                Else
                    _Abbinamento = value
                End If
            End Set
        End Property
    End Class
End Class
