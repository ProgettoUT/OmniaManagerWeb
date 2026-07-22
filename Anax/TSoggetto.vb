Public Class TSoggetto
    Inherits _TSoggetto

    Private mConvenzioneDescrizione As String

    Public ReadOnly Property ConvenzioneDescrizione() As String
        Get
            If mConvenzioneDescrizione Is Nothing Then
                mConvenzioneDescrizione = ""

                If Convenzione > 0 Then
                    mConvenzioneDescrizione = Convenzione
                    Try
                        Dim rs As DataTableReader = Utx.FunzioniDb.CreaDataTableReader("SELECT Desk FROM Convenzioni WHERE Codice = " & Convenzione)
                        If rs.Read Then
                            mConvenzioneDescrizione &= " - " & rs.GetString(0)
                            If mConvenzioneDescrizione.Length > 24 Then
                                mConvenzioneDescrizione = mConvenzioneDescrizione.Substring(0, 23) & "..."
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                End If
            End If
            Return mConvenzioneDescrizione
        End Get
    End Property

End Class
