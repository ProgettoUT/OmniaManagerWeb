Public Class TClienti
    Inherits _TClienti

    Private mProduttore As String

    Public ReadOnly Property ProduttoreDescrizione() As String
        Get
            If mProduttore Is Nothing Then
                mProduttore = ""
                Dim codice As Integer = Produttore
                If codice = 0 Then codice = SubAgenzia
                If codice <> 0 Then
                    mProduttore = codice
                    Try
                        Dim rs As DataTableReader = Utx.FunzioniDb.CreaDataTableReader("SELECT FiguraProduttiva FROM FigureProduttive WHERE IDFiguraProduttiva = " & codice)
                        If rs.Read Then
                            mProduttore &= " - " & rs.GetString(0)
                            If mProduttore.Length > 24 Then
                                mProduttore = mProduttore.Substring(0, 23) & "..."
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                End If
            End If
            Return mProduttore
        End Get
    End Property

    Public ReadOnly Property Nominativo() As String
        Get
            Try
                Return Trim(Cognome.Trim & " " & Nome.Trim)
            Catch ex As Exception
                Return CodiceFiscale
            End Try
        End Get
    End Property

    Public ReadOnly Property Eta() As Integer
        Get
            If Sesso = "N" Then
                Return 0
            ElseIf DataNascita.Year = 1 Then
                Return 0
            Else
                Return DateDiff(DateInterval.Year, DataNascita, Now)
            End If
        End Get
    End Property
End Class
