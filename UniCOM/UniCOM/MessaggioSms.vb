Public Class MessaggioSms

    'la classe contiene il messaggio come testo e le funzioni di gestione

    Public Const DimSingoloSms As Integer = 160
    Public Const MaxDimensioneSms As Integer = 1530

    Sub New()
        mTesto = ""
    End Sub

    Sub New(Testo As String)
        Me.Testo = Testo
    End Sub

    Private mTesto As String
    Public Property Testo() As String
        Get
            Return mTesto
        End Get
        Set(Testo As String)

            If Testo.Trim.Length > MaxDimensioneSms Then
                MsgBox(String.Format("Il testo del messaggio non può superare i {0} caratteri.",
                                      MaxDimensioneSms), MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)

                mTesto = ""
            Else
                mTesto = SostituisciCaratteri(Testo)
                mTesto = NormalizzaToken(mTesto)
            End If
        End Set
    End Property

    Public Sub Reset()
        mTesto = ""
    End Sub

    Public Function EsisteToken(key As String) As Boolean
        Return mTesto.IndexOf(key, 0, StringComparison.InvariantCultureIgnoreCase) >= 0
    End Function

    Private Function NormalizzaToken(Testo As String) As String
        Try
            'poiché la comparazione è NON case sensitive il ciclo sostituisce i token con
            'la loro versione normalizzata in minuscolo
            For Each t As String In Token.ListaTokenUnitools.Split(";")
                Testo = Replace(Testo, t, t, , , CompareMethod.Text)
            Next

            Return Testo

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Public Shared Function CreaTestoSms(TestoBase As String,
                                        ListaToken As List(Of Token)) As String
        Try
            'ogni elemento della lista token è una struttura DatiToken (key-valore)
            'sostituisco le key con i corrispondenti valori
            If ListaToken Is Nothing Then
                Return TestoBase
            Else
                For Each t As Token In ListaToken
                    TestoBase = Replace(TestoBase, t.Key, t.Valore, , , CompareMethod.Text)
                Next

                Return TestoBase
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return "Errore nella creazione del testo"
        End Try
    End Function

    Public Shared Function NumeroCaratteriUtilizzati(Testo As String) As Integer
        'Ci sono alcuni simboli € ^ { } \ [ ] ~ | che nello standard GSM sono composti
        'da 2 caratteri. alla lunghezza originale del messaggio bisogna
        'aggiungere il numero delle ricorrenze così da avere un raddoppio
        Dim Extra As Integer

        For Each c As Char In Testo
            If "€^{}\[]~|".IndexOf(c) >= 0 Then
                Extra += ContaRicorrenze(Testo, c)
            End If
        Next

        Return Testo.Length + Extra
    End Function

    Public Shared Function Msg2NumeroSms(Messaggio As String) As Integer

        Dim NumeroCaratteri As Integer = NumeroCaratteriUtilizzati(Messaggio)

        Select Case NumeroCaratteri
            Case 0
                Return 0

            Case Is <= UniCom.MessaggioSms.DimSingoloSms
                Return 1

            Case Else
                Return Math.Ceiling(NumeroCaratteri / 153)
        End Select
    End Function

    Private Function SostituisciCaratteri(Testo As String) As String

        Testo = Testo.Replace("°", ".")

        Return Testo

    End Function


End Class
